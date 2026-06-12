---
title: Převést prezentaci do HTML
type: docs
weight: 40
url: /cs/net/convert-presentation-to-html/
---
**HTML** je jedním z několika široce používaných formátů pro výměnu dat. **Aspose.Slides for .NET** poskytuje podporu pro převod prezentace do HTML. Níže je ukázkový kód, který ukazuje, jak na to.
## **Příklad**
``` 

 //Vytvořte objekt Presentation, který představuje soubor prezentace

Presentation pres = new Presentation("Conversion.ppt");

HtmlOptions htmlOpt = new HtmlOptions();

htmlOpt.HtmlFormatter = HtmlFormatter.CreateDocumentFormatter("", false);

//Ukládání prezentace do HTML

pres.Save("Converted.html", Aspose.Slides.Export.SaveFormat.Html, htmlOpt);

``` 
## **Stáhnout běžící příklad**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Converting%20to%20HTML)
## **Stáhnout ukázkový kód**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 

Pro více podrobností navštivte [Převod PowerPoint prezentací do HTML v .NET](/slides/cs/net/convert-powerpoint-to-html/).

{{% /alert %}}