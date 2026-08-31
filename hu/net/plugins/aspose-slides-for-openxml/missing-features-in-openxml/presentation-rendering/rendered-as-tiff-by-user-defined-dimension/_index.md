---
title: Megjelenítve Tiff formátumban felhasználó által meghatározott mérettel
type: docs
weight: 40
url: /hu/net/rendered-as-tiff-by-user-defined-dimension/
---
Az alábbi példa bemutatja, hogyan lehet egy prezentációt TIFF dokumentummá konvertálni testreszabott képmérettel a **TiffOptions** osztály használatával.

``` csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;


 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Converting to Tiff as defined format.tiff";

//Példányosítsa a Presentation objektumot, amely egy prezentáció fájlt képvisel
Presentation pres = new Presentation(srcFileName);

//Példányosítsa a TiffOptions osztályt
Aspose.Slides.Export.TiffOptions opts = new Aspose.Slides.Export.TiffOptions();

//A tömörítési típus beállítása
opts.CompressionType = TiffCompressionTypes.Default;

//Tömörítési típusok
//Default - Az alapértelmezett tömörítési sémát határozza meg (LZW).
//None - Nincs tömörítés.
//CCITT3
//CCITT4
//LZW
//RLE
//Depth - a tömörítési típustól függ és nem állítható be manuálisan.
//Resolution unit - mindig "2" értékű (pont per hüvelyk)
//A kép DPI beállítása
opts.DpiX = 200;

opts.DpiY = 100;

//Kép méretének beállítása
opts.ImageSize = new Size(1728, 1078);

//Mentse a prezentációt TIFF formátumba a megadott képmérettel
pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Tiff, opts);
``` 
## **Minta Kód Letöltése**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Converting%20to%20Tiff%20as%20defined%20format%20%28Aspose.Slides%29.zip)