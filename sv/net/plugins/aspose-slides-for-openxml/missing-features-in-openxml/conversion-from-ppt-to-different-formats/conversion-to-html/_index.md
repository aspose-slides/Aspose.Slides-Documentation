---
title: Konvertering till HTML
type: docs
weight: 20
url: /sv/net/conversion-to-html/
---
**HTML** är ett av flera ofta använda format för utbyte av data. **Aspose.Slides for .NET** erbjuder stöd för att konvertera en presentation till HTML. Nedan är ett kodexempel som visar hur du gör.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Converting to HTML.html";

//Instansiera ett Presentation-objekt som representerar en presentationsfil

Presentation pres = new Presentation(srcFileName);

HtmlOptions htmlOpt = new HtmlOptions();

htmlOpt.HtmlFormatter = HtmlFormatter.CreateDocumentFormatter("", false);

//Spara presentationen som HTML

pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Html, htmlOpt);

``` 
## **Ladda ner exempelkod**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Converting%20to%20HTML%20%28Aspose.Slides%29.zip)