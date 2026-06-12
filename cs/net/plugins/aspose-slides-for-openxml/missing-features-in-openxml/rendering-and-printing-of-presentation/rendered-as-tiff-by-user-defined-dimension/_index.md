---
title: Vykresleno jako TIFF s uživatelem definovanými rozměry
type: docs
weight: 40
url: /cs/net/rendered-as-tiff-by-user-defined-dimension/
---
Následující příklad ukazuje, jak převést prezentaci do TIFF dokumentu s přizpůsobenou velikostí obrázku pomocí **TiffOptions** třídy.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Converting to Tiff as defined format.tiff";

//Vytvořte objekt Presentation, který představuje soubor prezentace

Presentation pres = new Presentation(srcFileName);

//Vytvořte instanci třídy TiffOptions

Aspose.Slides.Export.TiffOptions opts = new Aspose.Slides.Export.TiffOptions();

//Nastavení typu komprese

opts.CompressionType = TiffCompressionTypes.Default;

//Typy komprese

//Default - Určuje výchozí schéma komprese (LZW).

//None - Určuje žádnou kompresi.

//CCITT3

//CCITT4

//LZW

//RLE

//Depth - závisí na typu komprese a nelze jej nastavit ručně.

//Resolution unit - je vždy rovno "2" (bodů na palec)

//Nastavení DPI obrázku

opts.DpiX = 200;

opts.DpiY = 100;

//Nastavení velikosti obrázku

opts.ImageSize = new Size(1728, 1078);

//Uložte prezentaci do TIFF s určenou velikostí obrázku

pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Tiff, opts);

``` 
## **Stáhnout ukázkový kód**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Converting%20to%20Tiff%20as%20defined%20format%20%28Aspose.Slides%29.zip)