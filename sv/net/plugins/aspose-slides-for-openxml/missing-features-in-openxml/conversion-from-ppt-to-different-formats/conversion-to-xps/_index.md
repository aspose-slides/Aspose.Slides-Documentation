---
title: Konvertering till XPS
type: docs
weight: 40
url: /sv/net/conversion-to-xps/
---
**XPS**-formatet används också i stor utsträckning för datautbyte. Aspose.Slides för .NET tar hänsyn till dess betydelse och erbjuder inbyggt stöd för att konvertera en presentation till ett XPS-dokument.

**Save**-metoden som exponeras av Presentation‑klassen kan användas för att konvertera hela presentationen till ett **XPS**‑dokument. Dessutom exponerar **XpsOptions**‑klassen egenskapen **SaveMetafileAsPng** som kan sättas till true eller false enligt krav.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Converting to XPS.xps";

//Skapa ett Presentation-objekt som representerar en presentationsfil

Presentation pres = new Presentation(srcFileName);

//Sparar presentationen till TIFF-dokument

pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Xps);

``` 
## **Ladda ner exempelkod**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Converting%20to%20XPS%20%28Aspose.Slides%29.zip)