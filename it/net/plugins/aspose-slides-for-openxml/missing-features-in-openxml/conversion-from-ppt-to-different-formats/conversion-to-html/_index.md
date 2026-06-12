---
title: Conversione in HTML
type: docs
weight: 20
url: /it/net/conversion-to-html/
---
**HTML** è uno dei numerosi formati ampiamente utilizzati per lo scambio di dati. **Aspose.Slides for .NET** fornisce il supporto per la conversione di una presentazione in HTML. Di seguito è mostrato uno snippet di codice che indica come fare.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Converting to HTML.html";

//Istanziare un oggetto Presentation che rappresenta un file di presentazione

Presentation pres = new Presentation(srcFileName);

HtmlOptions htmlOpt = new HtmlOptions();

htmlOpt.HtmlFormatter = HtmlFormatter.CreateDocumentFormatter("", false);

//Salvataggio della presentazione in HTML

pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Html, htmlOpt);

``` 
## **Scarica il codice di esempio**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Converting%20to%20HTML%20%28Aspose.Slides%29.zip)