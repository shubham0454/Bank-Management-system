select * from UserAccounts;
CREATE TABLE BankInfo (
    account_no INT NOT NULL,
    balance BIGINT,
    Ttype NVARCHAR(50),
    TDate DATE,
    TAmount BIGINT,
    CONSTRAINT FK_BankInfo_UserAccounts FOREIGN KEY (account_no) REFERENCES UserAccounts(account_no)
);
