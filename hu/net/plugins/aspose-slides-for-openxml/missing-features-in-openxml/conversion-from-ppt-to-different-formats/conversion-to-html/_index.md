---
title: HTML konvertálás
type: docs
weight: 20
url: /hu/net/conversion-to-html/
---
**HTML** az adatcserére széles körben használt formátumok egyike. **Aspose.Slides for .NET** támogatást nyújt a prezentációk HTML-re konvertálásához. Az alábbi kódrészlet megmutatja, hogyan lehet ezt megtenni.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Converting to HTML.html";

//Példányosít egy Presentation objektumot, amely egy prezentációs fájlt reprezentál
Presentation pres = new Presentation(srcFileName);

HtmlOptions htmlOpt = new HtmlOptions();

htmlOpt.HtmlFormatter = HtmlFormatter.CreateDocumentFormatter("", false);

//A prezentáció mentése HTML-be
pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Html, htmlOpt);

```
## **Minta kód letöltése**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Converting%20to%20HTML%20%28Aspose.Slides%29.zip)