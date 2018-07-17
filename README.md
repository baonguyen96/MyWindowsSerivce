# MyWindowsService

## Intro

This is a demo repository for me to learn how to setup Windows Service using TopShelf and also create MSI package.

## References

- [TopShelf tutorial](http://docs.topshelf-project.com/en/latest/configuration/quickstart.html)
- [VS missing project installer](https://stackoverflow.com/questions/48475183/missing-visual-studio-installer-in-setup-deployment-category)
- [How to create a MSI](https://www.youtube.com/watch?v=cp2aFNtcZfk&t=256s)
  - [Add commit/rollback custom actions that execute .VBS file](#) (run the actual .exe file)
- [VBS tutorial](https://www.tutorialspoint.com/vbscript/)
  - [Passing parameter to .exe using VBS](https://www.tek-tips.com/viewthread.cfm?qid=657483)

## Issues

- Seem like [MSI cannot execute VB](https://support.symantec.com/en_US/article.TECH25640.html)
- Some walk-around ideas if want to use (sort of) an automated fashion to install TopShelf service:
  - __Installation__: Create .bat file that move the .exe to the specific folder (usually inside _Program Files_ or _Program Files (x86)_) then execute the .exe with parameter
  - __Unintallation__: Can manually navigate to that folder and use TopShelf command to uninstall

## Solutions

- Create a package project that build and zip all files in [Debug](./MyWindowsSerivce/bin/Debug) directory + [Installation.bat](./Installation.bat) file
- Once unzip, just run the _.bat_ file. It will do the rest for you.
  - NOTE: Have to zip __all__ files in the _Debug_ directory to the zip file, then have to move __all__ files in the zip file to the target directory (in the bat file)