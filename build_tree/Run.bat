SET TESSERACT_DLL_PATH=.\Tesseract.dll
SET TESSDATA_PATH=.\tessdata
SET BIN_PATH=.\OCR_Tool.exe


csc /out:"%BIN_PATH%" /target:winexe /reference:"%TESSERACT_DLL_PATH%"  FromApp1.Designer.cs FromApp1.cs Program.cs FileDataProcessing.cs /reference:"C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\v3.0\PresentationFramework.dll" /reference:"C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\v3.0\WindowsBase.dll" /reference:"C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\v3.0\PresentationCore.dll"

OCR_Tool

