---
title: باز کردن یک ارائه در VSTO و Aspose.Slides
type: docs
weight: 120
url: /fa/net/opening-a-presentation-in-vsto-and-aspose-slides/
---
## **VSTO**
در زیر قطعه کد باز کردن یک ارائه آورده شده است:

``` csharp

  string FileName = "Open Presentation.pptx";

 Application.Presentations.Open(FileName);


``` 
## **Aspose.Slides**
Aspose.Slides برای .NET کلاس **Presentation** را ارائه می‌دهد که برای باز کردن یک ارائه موجود استفاده می‌شود. این کلاس چند سازندهٔ overload دارد و می‌توانیم از یکی از سازنده‌های مناسب کلاس **Presentation** برای ایجاد شیء آن بر پایهٔ یک ارائه موجود استفاده کنیم. در مثال زیر نام فایل ارائه (که باید باز شود) را به سازندهٔ کلاس Presentation پاس می‌دهیم. پس از باز شدن فایل، تعداد کل اسلایدهای موجود در ارائه را به‌دست می‌آوریم تا روی صفحه چاپ شود.

``` csharp

  string FileName = "Open Presentation.pptx";

 Presentation MyPresentation = new Presentation(FileName);

``` 
## **دانلود کد اجرایی**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsVSTOv1.1)
## **دانلود نمونه کد**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Code%20Comparison%20of%20Common%20Features/Opening%20a%20Presentation)