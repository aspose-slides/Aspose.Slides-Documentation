---
title: رندر اسلاید به عنوان تصویر بندانگشتی به JPEG با مقادیر تعریف‌شده توسط کاربر
type: docs
weight: 70
url: /fa/net/render-slide-as-thumbnail-to-jpeg-by-user-defined-values/
---
برای تولید تصویر بندانگشتی از هر اسلاید دلخواه با استفاده از Aspose.Slides برای .NET:

1. یک نمونه از کلاس **Presentation** ایجاد کنید.
1. مرجع هر اسلاید دلخواه را با استفاده از شناسه یا ایندکس آن به‌دست آورید.
1. عامل‌های مقیاس X و Y را بر اساس ابعاد X و Y تعریف‌شده توسط کاربر دریافت کنید.
1. تصویر بندانگشتی اسلاید مرجع را در مقیاس مشخص دریافت کنید.
1. تصویر بندانگشتی را در هر فرمت تصویری دلخواه ذخیره کنید.

```csharp
using Aspose.Slides;

string filePath = @"..\..\..\Sample Files\";
string srcFileName = filePath + "User Defined Thumbnail.pptx";
string destFileName = filePath + "User Defined Thumbnail.jpg";

//نماد سازی کلاس Presentation که فایل ارائه را نمایندگی می‌کند
using (Presentation pres = new Presentation(srcFileName))
{
    //دسترسی به اولین اسلاید
    ISlide sld = pres.Slides[0];

    //ابعاد تعریف‌شده توسط کاربر
    int desiredX = 1200;
    int desiredY = 800;

    //دریافت مقدار مقیاس‌دار X و Y
    float scaleX = (float)(1.0 / pres.SlideSize.Size.Width) * desiredX;
    float scaleY = (float)(1.0 / pres.SlideSize.Size.Height) * desiredY;

    //ایجاد تصویر با مقیاس کامل
    using (IImage image = sld.GetImage(scaleX, scaleY))
    {
        //ذخیره تصویر در دیسک با فرمت JPEG
        image.Save(destFileName, ImageFormat.Jpeg);
    }
}
``` 
## **کد نمونه را دانلود کنید**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/User%20Defined%20Thumbnail%20%28Aspose.Slides%29.zip)