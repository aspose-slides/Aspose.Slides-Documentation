---
title: Felhasználó által definiált mérettel Tiff formátumban renderelve
type: docs
weight: 40
url: /hu/net/rendered-as-tiff-by-user-defined-dimension/
---
A következő példa bemutatja, hogyan lehet egy bemutatót TIFF dokumentummá konvertálni egyedi képmérettel a **TiffOptions** osztály használatával.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Converting to Tiff as defined format.tiff";

//Egy Presentation objektum példányosítása, amely egy prezentációs fájlt képvisel

Presentation pres = new Presentation(srcFileName);

//A TiffOptions osztály példányosítása

Aspose.Slides.Export.TiffOptions opts = new Aspose.Slides.Export.TiffOptions();

//A tömörítési típus beállítása

opts.CompressionType = TiffCompressionTypes.Default;

//Tömörítési típusok

//Default - Alapértelmezett tömörítési sémát határoz meg (LZW).

//None - Nincs tömörítés.

//CCITT3

//CCITT4

//LZW

//RLE

//Depth - a tömörítési típustól függ és nem állítható manuálisan.

//Resolution unit - mindig "2"-nek (dots per inch) megfelelő érték.

//A kép DPI beállítása

opts.DpiX = 200;

opts.DpiY = 100;

//Kép méretének beállítása

opts.ImageSize = new Size(1728, 1078);

//A prezentáció mentése TIFF formátumba a megadott képmérettel

pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Tiff, opts);

``` 
## **Minta kód letöltése**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Converting%20to%20Tiff%20as%20defined%20format%20%28Aspose.Slides%29.zip)