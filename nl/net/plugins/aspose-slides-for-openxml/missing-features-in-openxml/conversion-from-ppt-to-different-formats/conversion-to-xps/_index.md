---
title: Conversie naar XPS
type: docs
weight: 40
url: /nl/net/conversion-to-xps/
---
**XPS**-formaat wordt ook veel gebruikt voor gegevensuitwisseling. Aspose.Slides voor .NET houdt rekening met het belang ervan en biedt ingebouwde ondersteuning voor het converteren van een presentatie naar een **XPS**-document.

De **Save**-methode die door de Presentation-klasse wordt aangeboden, kan worden gebruikt om de volledige presentatie om te zetten naar een **XPS**-document. Daarnaast exposeert de **XpsOptions**-klasse de eigenschap **SaveMetafileAsPng**, die naar behoefte op true of false kan worden ingesteld.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Converting to XPS.xps";

//Instantieer een Presentation-object dat een presentatiebestand vertegenwoordigt

Presentation pres = new Presentation(srcFileName);

//Opslaan van de presentatie als TIFF-document

pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Xps);

``` 
## **Voorbeeldcode downloaden**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Converting%20to%20XPS%20%28Aspose.Slides%29.zip)