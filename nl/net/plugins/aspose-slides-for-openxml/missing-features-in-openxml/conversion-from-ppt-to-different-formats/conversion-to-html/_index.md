---
title: Conversie naar HTML
type: docs
weight: 20
url: /nl/net/conversion-to-html/
---
**HTML** is een van de verschillende veelgebruikte formaten voor het uitwisselen van gegevens. **Aspose.Slides for .NET** biedt ondersteuning voor het converteren van een presentatie naar HTML. Hieronder staat een codefragment dat laat zien hoe.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Converting to HTML.html";

//Instantieer een Presentation-object dat een presentatiebestand vertegenwoordigt

Presentation pres = new Presentation(srcFileName);

HtmlOptions htmlOpt = new HtmlOptions();

htmlOpt.HtmlFormatter = HtmlFormatter.CreateDocumentFormatter("", false);

//De presentatie opslaan naar HTML

pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Html, htmlOpt);

``` 
## **Voorbeeldcode downloaden**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Converting%20to%20HTML%20%28Aspose.Slides%29.zip)