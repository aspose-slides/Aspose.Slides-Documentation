---
title: تبدیل به PDF
type: docs
weight: 30
url: /fa/net/conversion-to-pdf/
---
اسناد PDF به‌طور گسترده‌ای به‌عنوان فرمت استانداردی برای تبادل اسناد بین سازمان‌ها، بخش‌های دولتی و افراد استفاده می‌شود. این فرمت محبوب است، بنابراین اغلب از توسعه‌دهندگان خواسته می‌شود تا فایل‌های ارائه Microsoft PowerPoint را به اسناد PDF تبدیل کنند. با درک این نیاز احتمالی، Aspose.Slides برای .NET تبدیل ارائه‌ها به اسناد PDF را بدون استفاده از هیچ مؤلفهٔ دیگری پشتیبانی می‌کند.

**Aspose.Slides for .NET** کلاس Presentation را ارائه می‌دهد که نمایانگر یک فایل ارائه است. کلاس **Presentation** متد Save را در دسترس می‌گذارد که می‌تواند برای تبدیل کل ارائه به یک سند **PDF** فراخوانی شود. کلاس **PdfOptions** گزینه‌هایی برای ایجاد **PDF** مانند JpegQuality، TextCompression، Compliance و سایر موارد فراهم می‌کند. این گزینه‌ها می‌توانند برای دستیابی به استاندارد موردنظر PDF استفاده شوند.

```csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Converting to PDF.pdf";

//یک شی Presentation ایجاد کنید که نمایانگر یک فایل ارائه است

Presentation pres = new Presentation(srcFileName);

//ارائه را با گزینه‌های پیش‌فرض به PDF ذخیره کنید

pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Pdf);

``` 
## **دانلود کد نمونه**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Converting%20to%20PDF%20%28Aspose.Slides%29.zip)