---
title: تبدیل اسلاید به تصویر بندانگشتی JPEG با مقادیر تعریف‌شده توسط کاربر
type: docs
weight: 70
url: /fa/net/render-slide-as-thumbnail-to-jpeg-by-user-defined-values/
---
برای تولید تصویر بندانگشتی هر اسلاید موردنظر با استفاده از Aspose.Slides برای .NET:

1. یک نمونه از کلاس **Presentation** ایجاد کنید.
1. با استفاده از شناسه یا اندیس اسلاید موردنظر، مرجع آن را دریافت کنید.
1. عامل‌های مقیاس X و Y را بر اساس ابعاد X و Y تعریف‌شده توسط کاربر دریافت کنید.
1. تصویر بندانگشتی اسلاید مرجع را در مقیاس مشخص دریافت کنید.
1. تصویر بندانگشتی را در هر فرمت تصویری موردنظر ذخیره کنید.

``` csharp
string filePath = @"..\..\..\Sample Files\";
string srcFileName = filePath + "User Defined Thumbnail.pptx";
string destFileName = filePath + "User Defined Thumbnail.jpg";

//نمونه‌سازی کلاس Presentation که نمایانگر فایل ارائه است
using (Presentation pres = new Presentation(srcFileName))
{
    //دسترسی به اولین اسلاید
    ISlide sld = pres.Slides[0];

    //بعد تعریف‌شده توسط کاربر
    int desiredX = 1200;
    int desiredY = 800;

    //دریافت مقدار مقیاس‌دار X و Y
    float scaleX = (float)(1.0 / pres.SlideSize.Size.Width) * desiredX;
    float scaleY = (float)(1.0 / pres.SlideSize.Size.Height) * desiredY;

    //ایجاد تصویر با مقیاس کامل
    using (IImage image = sld.GetImage(scaleX, scaleY))
    {
        //ذخیره تصویر بر روی دیسک با فرمت JPEG
        image.Save(destFileName, ImageFormat.Jpeg);
    }
}
``` 
## **بارگیری کد نمونه**
- [گیت‌هاب](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [بیت‌باکت](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/User%20Defined%20Thumbnail%20%28Aspose.Slides%29.zip)