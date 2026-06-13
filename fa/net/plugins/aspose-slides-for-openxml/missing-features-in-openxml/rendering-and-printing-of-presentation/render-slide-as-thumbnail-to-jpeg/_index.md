---
title: رندر اسلاید به‌صورت تصویر کوچک به JPEG
type: docs
weight: 60
url: /fa/net/render-slide-as-thumbnail-to-jpeg/
---
**Aspose.Slides for .NET** برای ایجاد فایل‌های ارائه حاوی اسلایدها استفاده می‌شود. این اسلایدها می‌توانند با باز کردن فایل‌های ارائه با استفاده از Microsoft PowerPoint مشاهده شوند. اما گاهی اوقات، توسعه‌دهندگان ممکن است نیاز داشته باشند اسلایدها را به صورت تصویر با استفاده از نمایشگر تصویر مورد علاقه خود مشاهده کنند. در چنین مواردی، Aspose.Slides for .NET به شما کمک می‌کند تصاویر کوچک اسلایدها را تولید کنید.

برای تولید تصویر کوچک هر اسلاید دلخواه با استفاده از Aspose.Slides for .NET:

1. یک نمونه از کلاس **Presentation** ایجاد کنید.
1. مرجع هر اسلاید دلخواه را با استفاده از شناسه یا ایندکس آن به دست آورید.
1. تصویر کوچک اسلاید مرجع را در مقیاس مشخص دریافت کنید.
1. تصویر کوچک را در هر فرمت تصویر دلخواه ذخیره کنید.

``` csharp
string filePath = @"..\..\..\Sample Files\";
string srcFileName = filePath + "Slide Thumbnail to JPEG.pptx";
string destFileName = filePath + "Slide Thumbnail to JPEG.jpg";

// یک نمونه از کلاس Presentation که فایل ارائه را نمایندگی می‌کند ایجاد کنید
using (Presentation pres = new Presentation(srcFileName))
{
    // دسترسی به اولین اسلاید
    ISlide sld = pres.Slides[0];

    // یک تصویر با مقیاس کامل ایجاد کنید
    using (IImage image = sld.GetImage(1f, 1f))
    {
        // ذخیره تصویر در دیسک به فرمت JPEG
        image.Save(destFileName, ImageFormat.Jpeg);
    }
}
``` 

## **نمونه کد را دانلود کنید**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Slide%20Thumbnail%20to%20JPEG%20%28Aspose.Slides%29.zip)