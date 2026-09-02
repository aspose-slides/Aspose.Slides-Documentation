---
title: Renderad som Tiff med användardefinierad dimension
type: docs
weight: 40
url: /sv/net/rendered-as-tiff-by-user-defined-dimension/
---
Följande exempel visar hur du konverterar en presentation till ett TIFF-dokument med anpassad bildstorlek med hjälp av **TiffOptions**-klassen.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

 
 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Converting to Tiff as defined format.tiff";

//Skapa ett Presentation-objekt som representerar en presentationsfil
Presentation pres = new Presentation(srcFileName);

//Skapa ett TiffOptions-objekt
Aspose.Slides.Export.TiffOptions opts = new Aspose.Slides.Export.TiffOptions();

//Ställer in komprimeringstyp
opts.CompressionType = TiffCompressionTypes.Default;

//Komprimeringstyper

//Default - Anger standardskomprimeringsschemat (LZW).

//None - Anger ingen komprimering.

//CCITT3

//CCITT4

//LZW

//RLE

//Depth - beror på komprimeringstypen och kan inte sättas manuellt.

//Resolution unit - är alltid lika med \"2\" (punkter per tum)

//Ställer in bildens DPI
opts.DpiX = 200;

opts.DpiY = 100;

//Ställ in bildstorlek
opts.ImageSize = new Size(1728, 1078);

//Save the presentation to TIFF with specified image size
pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Tiff, opts);
``` 
## **Ladda ner exempelkod**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Converting%20to%20Tiff%20as%20defined%20format%20%28Aspose.Slides%29.zip)