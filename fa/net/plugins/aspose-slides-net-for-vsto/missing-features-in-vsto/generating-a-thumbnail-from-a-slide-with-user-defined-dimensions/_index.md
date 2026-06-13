---
title: تولید تصویر بندانگشتی از اسلاید با ابعاد تعریف‌شده توسط کاربر
type: docs
weight: 100
url: /fa/net/generating-a-thumbnail-from-a-slide-with-user-defined-dimensions/
---
برای تولید تصویر بندانگشتی هر اسلاید دلخواه با استفاده از Aspose.Slides برای .NET:

- یک نمونه از کلاس Presentation ایجاد کنید.
- مرجع هر اسلاید دلخواه را با استفاده از شناسه یا اندیس آن دریافت کنید.
- مقادیر مقیاس X و Y را بر اساس ابعاد X و Y تعریف‌شده توسط کاربر به دست آورید.
- تصویر بندانگشتی اسلاید مرجع را در مقیاس مشخص دریافت کنید.
- تصویر بندانگشتی را در هر فرمت تصویری دلخواه ذخیره کنید.
## **مثال**
```cs
//یک نمونه از کلاس Presentation که نمایانگر فایل ارائه است را ایجاد کنید
using (Presentation pres = new Presentation("TestPresentation.pptx"))
{
    //دسترسی به اسلاید اول
    ISlide sld = pres.Slides[0];

    //ابعاد تعریف‌شده توسط کاربر
    int desiredX = 1200;
    int desiredY = 800;

    //دریافت مقدار مقیاس‌دار X و Y
    float scaleX = (float)(1.0 / pres.SlideSize.Size.Width) * desiredX;
    float scaleY = (float)(1.0 / pres.SlideSize.Size.Height) * desiredY;

    //یک تصویر با مقیاس کامل ایجاد کنید
    using (IImage image = sld.GetImage(scaleX, scaleY))
    {
        //تصویر را در قالب JPEG روی دیسک ذخیره کنید
        image.Save("Thumbnail2.jpg", ImageFormat.Jpeg);
    }
}
``` 
## **بارگیری مثال اجرایی**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/User%20Defined%20Thumbnail)
## **بارگیری کد نمونه**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 
برای جزئیات بیشتر به [تبدیل اسلاید](/slides/fa/net/convert-slide/) مراجعه کنید.
{{% /alert %}}