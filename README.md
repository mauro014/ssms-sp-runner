# ssms-sp-runner
Runner for SSMS SP - Run set of Stored Procedures with single console app. Could be setup as a Task in Windows Task Manager. Only admits from 0 to 2 parameters.

# IDE 
Visual Studio 2022 + Needs .Net 8.0

# Setup
- Set BD URL in App.config keys.
- Change LogPath and csv_SPs_file if you wish.
- Change Stored Procedures list in /Files/sp_list.csv or path defined.
- - Name: Stored Procedure Name.
  - TimeOut: Stored Procedure TimeOut. 0 if default.
  - nPar0 [Nullable]: Name of parameter 0.
  - vPar0 [Nullable]: Value of parameter 0.
  - nPar1 [Nullable]: Name of parameter 1.
  - vPar0 [Nullable]: Value of parameter 1.
