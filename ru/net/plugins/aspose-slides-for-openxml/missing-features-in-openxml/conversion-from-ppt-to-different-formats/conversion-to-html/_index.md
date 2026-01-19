---
title: Преобразование в HTML
type: docs
weight: 20
url: /ru/net/conversion-to-html/
---

**HTML** — один из нескольких широко используемых форматов для обмена данными. **Aspose.Slides for .NET** предоставляет поддержку преобразования презентации в HTML. Ниже приведён фрагмент кода, показывающий, как это сделать.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Converting to HTML.html";

//Создать объект Presentation, представляющий файл презентации
Presentation pres = new Presentation(srcFileName);

HtmlOptions htmlOpt = new HtmlOptions();

htmlOpt.HtmlFormatter = HtmlFormatter.CreateDocumentFormatter("", false);

//Сохранение презентации в HTML
pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Html, htmlOpt);

``` 
## **Скачать пример кода**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Converting%20to%20HTML%20%28Aspose.Slides%29.zip)