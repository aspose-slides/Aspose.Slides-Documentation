---
title: Vykresleno jako TIFF s uživatelem definovanými rozměry
type: docs
weight: 40
url: /cs/net/rendered-as-tiff-by-user-defined-dimension/
---
Následující příklad ukazuje, jak převést prezentaci do TIFF dokumentu s přizpůsobenou velikostí obrazu pomocí třídy **TiffOptions**.

``` csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;


 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Converting to Tiff as defined format.tiff";

//Vytvořit objekt Presentation, který představuje soubor prezentace
Presentation pres = new Presentation(srcFileName);

//Vytvořit instanci třídy TiffOptions
Aspose.Slides.Export.TiffOptions opts = new Aspose.Slides.Export.TiffOptions();

//Nastavení typu komprese
opts.CompressionType = TiffCompressionTypes.Default;

//Typy komprese
//Default - Specifikuje výchozí kompresní schéma (LZW).
//None - Specifikuje žádnou kompresi.
//CCITT3
//CCITT4
//LZW
//RLE
//Depth - závisí na typu komprese a nelze nastavit ručně.
//Resolution unit - je vždy rovno "2" (bodů na palec)
//Nastavení DPI obrazu
opts.DpiX = 200;

opts.DpiY = 100;

//Nastavit velikost obrazu
opts.ImageSize = new Size(1728, 1078);

//Save the presentation to TIFF with specified image size
pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Tiff, opts);

``` 
## **Stáhnout ukázkový kód**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Converting%20to%20Tiff%20as%20defined%20format%20%28Aspose.Slides%29.zip)