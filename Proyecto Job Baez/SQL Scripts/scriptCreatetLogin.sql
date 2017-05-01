USE JobBaezDB
GO
CREATE TABLE tLogin(
	logID int PRIMARY KEY,
	logUser char(20) NOT NULL,
	logPassword char(15) NOT NULL
)