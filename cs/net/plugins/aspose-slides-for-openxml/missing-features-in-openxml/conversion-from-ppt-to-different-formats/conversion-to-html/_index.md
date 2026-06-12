---
title: Konverze do HTML
type: docs
weight: 20
url: /cs/net/conversion-to-html/
---
**HTML** je jedním z několika široce používaných formátů pro výměnu dat. **Aspose.Slides for .NET** poskytuje podporu pro převod prezentace do HTML. Níže je ukázkový kód, který vám ukazuje, jak na to.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Converting to HTML.html";

//Vytvořte objekt Presentation, který představuje soubor prezentace

Presentation pres = new Presentation(srcFileName);

HtmlOptions htmlOpt = new HtmlOptions();

htmlOpt.HtmlFormatter = HtmlFormatter.CreateDocumentFormatter("", false);

//Ukládání prezentace do HTML

pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Html, htmlOpt);

``` 
## **Stáhnout ukázkový kód**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Converting%20to%20HTML%20%28Aspose.Slides%29.zip)