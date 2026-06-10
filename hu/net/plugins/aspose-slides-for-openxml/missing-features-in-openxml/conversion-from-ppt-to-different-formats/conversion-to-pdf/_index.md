---
title: PDF-re konvertálás
type: docs
weight: 30
url: /hu/net/conversion-to-pdf/
---
A PDF dokumentumok széles körben használatosak szabványos formátumként a szervezetek, kormányzati szektorok és magánszemélyek közötti dokumentumcsere során. Népszerű formátum, ezért a fejlesztőktől gyakran kérik, hogy a Microsoft PowerPoint prezentációs fájlokat PDF dokumentumokká konvertálják. Ezt a lehetséges igényt szem előtt tartva, az Aspose.Slides for .NET támogatja a prezentációk PDF dokumentumokká alakítását anélkül, hogy bármely más komponensre szükség lenne.

**Aspose.Slides for .NET** kínál egy Presentation osztályt, amely egy prezentációs fájlt képvisel. A **Presentation** osztály a Save metódust teszi elérhetővé, amelyet a teljes prezentáció **PDF** dokumentummá való konvertálásához lehet meghívni. A **PdfOptions** osztály lehetőségeket biztosít a **PDF** létrehozásához, például JpegQuality, TextCompression, Compliance és egyebek. Ezeket a beállításokat a kívánt PDF szabvány eléréséhez lehet használni.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Converting to PDF.pdf";

//Példányosít egy Presentation objektumot, amely egy prezentációs fájlt reprezentál

Presentation pres = new Presentation(srcFileName);

//Mentse a prezentációt PDF-be alapértelmezett beállításokkal

pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Pdf);

``` 
## **Minta kód letöltése**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Converting%20to%20PDF%20%28Aspose.Slides%29.zip)