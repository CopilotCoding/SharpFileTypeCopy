# FAIR WARNING!
If you say, input the path to your main logical drive, this program will find every single file of the type you gave it and copy them to a single folder.

This will possibly make a massive amounts of large files in a single folder.
You could easily cause your drive to fill up with this program if used improperly.

# SearchForFilesOfTypeAndCopyToNewFolder
Searches through the path you provide to find files of the type you provide and copies them to a new location you provide.

# Known issues:
Error throws when trying to access unauthorized paths, such as hidden or otherwise protected paths or files.
System.UnauthorizedAccessException throws when these are accessed.

If somebody could tell me how I could avoid accessing these paths and files without hard coding all of those paths, that would be very helpful.
