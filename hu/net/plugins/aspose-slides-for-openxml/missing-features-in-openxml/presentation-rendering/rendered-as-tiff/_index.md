---
title: Tiff formátumban renderelve
type: docs
weight: 30
url: /hu/net/rendered-as-tiff/
---
A TIFF formátum híres rugalmasságáról, amely többoldalas képek és adatok kezelésére alkalmas. Figyelembe véve a TIFF formátum fontosságát és népszerűségét, az Aspose.Slides for .NET támogatja a prezentációk TIFF dokumentummá konvertálását.
Ez a cikk bemutatja, hogyan működnek a különböző TIFF exportálási beállítások:

- Prezentáció konvertálása TIFF-be alapértelmezett mérettel.
- Prezentáció konvertálása TIFF-be egyéni mérettel.

A **Presentation** osztály által biztosított **Save** metódus meghívható a fejlesztők számára, hogy az egész prezentációt **TIFF** dokumentummá konvertálják. Továbbá a TiffOptions osztály az ImageSize tulajdonságot kínálja, amely lehetővé teszi a fejlesztő számára a kép méretének meghatározását, ha szükséges.

``` csharp
using Aspose.Slides;


 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Conversion to Tiff.tiff";

//Példányosít egy Presentation objektumot, amely egy prezentációs fájlt reprezentál

using (Presentation pres = new Presentation(srcFileName))

{

    //A prezentáció mentése TIFF dokumentumba

    pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Tiff);

}
``` 
## **Minta kód letöltése**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Conversion%20to%20Tiff%20%28Aspose.Slides%29.zip)