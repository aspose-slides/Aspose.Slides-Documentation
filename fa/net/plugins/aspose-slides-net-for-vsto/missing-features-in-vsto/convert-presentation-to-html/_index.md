---
title: تبدیل ارائه به HTML
type: docs
weight: 40
url: /fa/net/convert-presentation-to-html/
---
**HTML** یکی از چندین فرمت پرکاربرد برای تبادل داده است. **Aspose.Slides for .NET** پشتیبانی از تبدیل یک ارائه به HTML را فراهم می‌کند. در زیر قطعه کدی آمده است که نشان می‌دهد چگونه.
## **مثال**
``` 

 //یک نمونه از شی Presentation ایجاد می‌کند که فایل ارائه را نشان می‌دهد

Presentation pres = new Presentation("Conversion.ppt");

HtmlOptions htmlOpt = new HtmlOptions();

htmlOpt.HtmlFormatter = HtmlFormatter.CreateDocumentFormatter("", false);

//در حال ذخیرهٔ ارائه به HTML

pres.Save("Converted.html", Aspose.Slides.Export.SaveFormat.Html, htmlOpt);

``` 
## **بارگیری مثال اجرایی**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Converting%20to%20HTML)
## **بارگیری نمونه کد**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 

برای جزئیات بیشتر، به [تبدیل ارائه‌های پاورپوینت به HTML در .NET](/slides/fa/net/convert-powerpoint-to-html/) مراجعه کنید.

{{% /alert %}}