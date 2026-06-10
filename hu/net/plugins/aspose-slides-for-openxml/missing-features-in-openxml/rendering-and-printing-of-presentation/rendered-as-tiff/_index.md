---
title: Renderelt TIFFként
type: docs
weight: 30
url: /hu/net/rendered-as-tiff/
---
A TIFF formátum híres rugalmasságáról, amely képes többoldalas képek és adatok kezelésére. Figyelembe véve a TIFF formátum jelentőségét és népszerűségét, az Aspose.Slides for .NET támogatja a prezentációk TIFF dokumentummá konvertálását.
Ez a cikk bemutatja a különböző TIFF exportálási beállításokat:

- Prezentáció konvertálása TIFF-be alapértelmezett mérettel.
- Prezentáció konvertálása TIFF-be egyedi mérettel.

A **Presentation** osztály által biztosított **Save** metódus meghívható a fejlesztők által a teljes prezentáció **TIFF** dokumentummá konvertálásához. Továbbá a TiffOptions osztály az ImageSize tulajdonságot kínálja, amely lehetővé teszi a fejlesztő számára a kép méretének meghatározását, ha szükséges.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Conversion to Tiff.tiff";

//Példányosít egy Presentation objektumot, amely egy prezentációs fájlt képvisel

using (Presentation pres = new Presentation(srcFileName))

{

    //A prezentáció mentése TIFF dokumentumba

    pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Tiff);

}

``` 
## **Minta kód letöltése**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Conversion%20to%20Tiff%20%28Aspose.Slides%29.zip)