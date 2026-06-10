---
title: Átalakítás PPT formátumból PPTX formátumba
type: docs
weight: 20
url: /hu/net/conversion-from-ppt-to-pptx-format/
---
Az Aspose.Slides egyedi funkciója rugalmasságot biztosít a verziókonverziókban, anélkül hogy a munkát befolyásolná.
A SaveFormat egy felsorolás, amely a lenti táblázatban megadott kiterjesztésekkel képes konvertálni a dokumentumot.

|**Tag neve**|**Érték**|**Leírás**|
| :- | :- | :- |
|HTML|13| |
|ODP|6| |
|PDF|1| |
|PDF Notes|12| |
|POTM|11| |
|POTX|10| |
|PPS|0| |
|PPSM|9| |
|PPSX|4| |
|PPT|0| |
|PPTM|7| |
|PPTX|3| |
|TIFF|5| |
|TiffNotes|14| |
|XPS|2| |
Az alábbi kódrészlet bemutatja a PPT‑ről PPTX‑re történő konverciót; visszafelé is megtehető.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion PPT to PPTX.ppt";

string destFileName = FilePath + "Conversion PPT to PPTX.pptx";

//Példányosít egy Presentation objektumot, amely egy PPTX fájlt reprezentál

Presentation pres = new Presentation(srcFileName);

//A PPTX prezentáció mentése PPTX formátumba

pres.Save(destFileName, SaveFormat.Pptx);

``` 
## **Minta Kód Letöltése**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Conversion%20between%20different%20presentation%20version%20%28Aspose.Slides%29.zip)