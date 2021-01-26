--Function to calculate premium based on death sum insured, age and occupation of the member
--returns -1 if member details not matched.

CREATE FUNCTION [dbo].[CalculatePremium](@memberId NVARCHAR(10),@deathSumInsured NUMERIC(18, 2), @age INT, @occupation NVARCHAR(50)) 
RETURNS NUMERIC(18,2)
AS
BEGIN
	DECLARE @premium NUMERIC(18,2);
	DECLARE @rating_factor NUMERIC(5,2);
	IF NOT EXISTS(select 1 from dbo.Member where MemberId = @memberId
	and Age = @age and DeathSumInsured = @deathSumInsured and Occupation = @occupation)
	RETURN -1;

	SELECT @rating_factor = Factor FROM dbo.RATINGS WHERE rating = (select rating from dbo.OCCUPATION 
	where OccupationName = @occupation)

    SET @premium = ((@deathSumInsured * @rating_factor * @age)/1000) * 12;
	RETURN @premium
END