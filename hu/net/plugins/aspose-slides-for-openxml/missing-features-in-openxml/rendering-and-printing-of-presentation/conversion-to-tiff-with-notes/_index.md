---
title: Átalakítás Tiff formátumba jegyzetekkel
type: docs
weight: 10
url: /hu/net/conversion-to-tiff-with-notes/
---
A TIFF a számos széles körben használt képfájlformátum közül az, amelyet az Aspose.Slides for .NET támogat a jegyzetekkel ellátott prezentációk képekké konvertálásához. A Jegyzetes Diák nézetben is létrehozhat diaképépképeket. Az alábbiakban két kódrészlet látható, amelyek bemutatják, hogyan generáljunk TIFF képeket egy prezentációról a Jegyzetes Diák nézetben.

A **Presentation** osztály által biztosított **Save** metódus használható a teljes prezentáció Jegyzetes Diák nézetben történő TIFF formátumba konvertálásához. Egyedi diákhoz is létrehozhat diaképépképet a Jegyzetes Diák nézetben.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Tiff conversion with note.pptx";

string destFileName = FilePath + "Tiff conversion with note.tiff";

//Egy Presentation objektum példányosítása, amely egy prezentációs fájlt képvisel

Presentation pres = new Presentation(srcFileName);

//A prezentáció mentése TIFF jegyzetekkel

pres.Save(destFileName, SaveFormat.TiffNotes);
``` 
## **Minta kód letöltése**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Tiff%20conversion%20with%20note%20%28Aspose.Slides%29.zip)