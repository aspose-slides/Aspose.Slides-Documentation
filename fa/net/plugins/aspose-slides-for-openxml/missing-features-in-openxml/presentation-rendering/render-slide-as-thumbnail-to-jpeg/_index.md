---
title: رندر اسلاید به‌صورت تصویر بندانگشتی به JPEG
type: docs
weight: 60
url: /fa/net/render-slide-as-thumbnail-to-jpeg/
---
**Aspose.Slides for .NET** برای ایجاد فایل‌های ارائه‌ای حاوی اسلایدها استفاده می‌شود. این اسلایدها می‌توانند با باز کردن فایل‌های ارائه با Microsoft PowerPoint مشاهده شوند. اما گاهی توسعه‌دهندگان ممکن است نیاز داشته باشند اسلایدها را به‌عنوان تصویر با مرورگر تصویر دلخواه خود ببینند. در چنین مواردی، Aspose.Slides for .NET به شما کمک می‌کند تصاویر بندانگشتی اسلایدها را تولید کنید.

برای تولید تصویر بندانگشتی هر اسلاید دلخواه با استفاده از Aspose.Slides for .NET:

1. یک نمونه از کلاس **Presentation** ایجاد کنید.
1. مرجع هر اسلاید دلخواه را با استفاده از شناسه یا اندیس آن به‌دست آورید.
1. تصویر بندانگشتی اسلاید مرجع‌شده را در مقیاس مشخص دریافت کنید.
1. تصویر بندانگشتی را در هر قالب تصویری دلخواه ذخیره کنید.

``` csharp
using Aspose.Slides;

string filePath = @"..\..\..\Sample Files\";
string srcFileName = filePath + "Slide Thumbnail to JPEG.pptx";
string destFileName = filePath + "Slide Thumbnail to JPEG.jpg";

//نمونه‌سازی کلاس Presentation که فایل ارائه را نمایندگی می‌کند
using (Presentation pres = new Presentation(srcFileName))
{
    //دسترسی به اولین اسلاید
    ISlide sld = pres.Slides[0];

    //ایجاد تصویر با مقیاس کامل
    using (IImage image = sld.GetImage(1f, 1f))
    {
        //ذخیره تصویر به‌صورت JPEG روی دیسک
        image.Save(destFileName, ImageFormat.Jpeg);
    }
}
``` 

## **کد نمونه را دانلود کنید**
- [گیت‌هاب](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [بیت‌برد](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Slide%20Thumbnail%20to%20JPEG%20%28Aspose.Slides%29.zip)