create database BMS;
CREATE TABLE UserAccounts (
    full_name VARCHAR(50),
    user_id VARCHAR(50) UNIQUE,
    password VARCHAR(50),
    account_type VARCHAR(50),
    account_no INT IDENTITY(1000000000,1) PRIMARY KEY, -- Starts at a large number and increments by 1
    email_id VARCHAR(50),
    mobile_no BIGINT UNIQUE, -- Changed to BIGI NT to store 10-digit numbers
    date_of_birth DATE,
    address VARCHAR(50)
);
select * from UserAccounts;