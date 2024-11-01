---
title: Conversion from PPT to PPTX format
type: docs
weight: 20
url: /net/conversion-from-ppt-to-pptx-format/
---

Aspose.Slides unique feature that provide flexibility in version conversions without affecting work.
SaveFormat is enumeration that can convert document in the extensions given below in table.

|**Member Name**|**Value**|**Description**|
| :- | :- | :- |
|HTML|13| |
|ODP|6| |
|PDF|1| |
|PDF Notes|12| |
|POTM|11| |
|POTX|10| |
|PPS|0| |
|PPSM|9| |
|PPSX|4| |
|PPT|0| |
|PPTM|7| |
|PPTX|3| |
|TIFF|5| |
|TiffNotes|14| |
|XPS|2| |
Below is a code snippet that shows conversion from PPT to PPTX you can do it vice versa as well.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion PPT to PPTX.ppt";

string destFileName = FilePath + "Conversion PPT to PPTX.pptx";

//Instantiate a Presentation object that represents a PPTX file

Presentation pres = new Presentation(srcFileName);

//Saving the PPTX presentation to PPTX format

pres.Save(destFileName, SaveFormat.Pptx);

``` 
## **Download Sample Code**
- [Codeplex](https://asposeslidesopenxml.codeplex.com/releases/view/619597)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Conversion%20between%20different%20presentation%20version%20%28Aspose.Slides%29.zip)
