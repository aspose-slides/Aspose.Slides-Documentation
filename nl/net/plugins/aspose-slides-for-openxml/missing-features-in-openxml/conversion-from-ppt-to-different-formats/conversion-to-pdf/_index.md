---
title: Conversie naar PDF
type: docs
weight: 30
url: /nl/net/conversion-to-pdf/
---
PDF‑documenten worden veel gebruikt als een standaardformaat voor het uitwisselen van documenten tussen organisaties, overheidssectoren en particulieren. Het is een populair formaat, waardoor ontwikkelaars vaak wordt gevraagd Microsoft PowerPoint‑presentatiebestanden naar PDF‑documenten te converteren. Met dit mogelijke verzoek in gedachten ondersteunt Aspose.Slides for .NET het converteren van presentaties naar PDF‑documenten zonder een ander component te gebruiken.

**Aspose.Slides for .NET** biedt de Presentation‑klasse die een presentatie‑bestand vertegenwoordigt. De **Presentation**‑klasse biedt de Save‑methode die kan worden aangeroepen om de volledige presentatie te converteren naar een **PDF**‑document. De **PdfOptions**‑klasse biedt opties voor het maken van de **PDF**, zoals JpegQuality, TextCompression, Compliance en andere. Deze opties kunnen worden gebruikt om de gewenste PDF‑standaard te behalen.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Converting to PDF.pdf";

//Instantieer een Presentation-object dat een presentatiebestand vertegenwoordigt

Presentation pres = new Presentation(srcFileName);

//Sla de presentatie op als PDF met de standaardopties

pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Pdf);

``` 
## **Voorbeeldcode downloaden**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Converting%20to%20PDF%20%28Aspose.Slides%29.zip)