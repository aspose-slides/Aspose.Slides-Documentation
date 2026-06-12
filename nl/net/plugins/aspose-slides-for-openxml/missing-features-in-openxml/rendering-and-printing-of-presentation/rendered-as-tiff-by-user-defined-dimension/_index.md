---
title: Weergegeven als Tiff met door de gebruiker gedefinieerde afmeting
type: docs
weight: 40
url: /nl/net/rendered-as-tiff-by-user-defined-dimension/
---
Het volgende voorbeeld laat zien hoe u een presentatie kunt converteren naar een TIFF-document met een aangepaste afbeeldingsgrootte met behulp van de **TiffOptions**-klasse.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Converting to Tiff as defined format.tiff";

//Instantieer een Presentation-object dat een presentatiebestand vertegenwoordigt
Presentation pres = new Presentation(srcFileName);

//Instantieer de TiffOptions-klasse
Aspose.Slides.Export.TiffOptions opts = new Aspose.Slides.Export.TiffOptions();

//Instellen compressietype
opts.CompressionType = TiffCompressionTypes.Default;

//Compressietypen
//Standaard - Specificeert het standaard compressieschema (LZW).
//Geen - Specificeert geen compressie.
//CCITT3
//CCITT4
//LZW
//RLE
//Diepte - hangt af van het compressietype en kan niet handmatig worden ingesteld.
//Resolutie-eenheid - is altijd gelijk aan "2" (punten per inch)
//Instellen afbeelding DPI
opts.DpiX = 200;

opts.DpiY = 100;

//Instellen afbeeldingsgrootte
opts.ImageSize = new Size(1728, 1078);

//Save the presentation to TIFF with specified image size
pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Tiff, opts);

``` 
## **Download Sample Code**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Converting%20to%20Tiff%20as%20defined%20format%20%28Aspose.Slides%29.zip)