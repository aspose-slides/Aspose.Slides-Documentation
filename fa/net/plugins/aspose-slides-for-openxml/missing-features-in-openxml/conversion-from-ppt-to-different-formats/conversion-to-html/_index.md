---
title: تبدیل به HTML
type: docs
weight: 20
url: /fa/net/conversion-to-html/
---
**HTML** یکی از چندین قالب گسترده‌ استفاده‌شده برای تبادل داده است. **Aspose.Slides for .NET** پشتیبانی از تبدیل یک ارائه به HTML را فراهم می‌کند. در زیر قطعه کدی آمده که نحوه انجام آن را نشان می‌دهد.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Converting to HTML.html";

//یک شی Presentation ایجاد کنید که نمایانگر یک فایل ارائه است

Presentation pres = new Presentation(srcFileName);

HtmlOptions htmlOpt = new HtmlOptions();

htmlOpt.HtmlFormatter = HtmlFormatter.CreateDocumentFormatter("", false);

//ذخیرهٔ ارائه به فرمت HTML

pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Html, htmlOpt);

``` 
## **دریافت نمونه کد**
- [گیت‌هاب](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [بیت‌باکت](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Converting%20to%20HTML%20%28Aspose.Slides%29.zip)