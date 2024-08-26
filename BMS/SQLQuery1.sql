create database BMS;
CREATE TABLE UserAccounts (
    full_name VARCHAR(100),
    user_id INT UNIQUE,
    password VARCHAR(100),
    account_type VARCHAR(50),
    account_no INT PRIMARY KEY,
    email_id VARCHAR(100),
    mobile_no VARCHAR(15),
    date_of_birth DATE,
    address VARCHAR(255)
);
select *from UserAccounts;