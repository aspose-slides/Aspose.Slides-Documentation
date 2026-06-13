---
title: ایجاد تصویر بندانگشتی اسلاید به فرمت JPEG
type: docs
weight: 90
url: /fa/net/generate-slide-thumbnail-as-jpeg/
---
برای تولید تصویر بندانگشتی هر اسلاید دلخواه با استفاده از Aspose.Slides برای .NET:

- یک نمونه از کلاس Presentation ایجاد کنید.
- با استفاده از شناسه یا اندیس، مرجع هر اسلاید دلخواه را به دست آورید.
- تصویر بندانگشتی اسلاید مرجع را در مقیاس مشخص دریافت کنید.
- تصویر بندانگشتی را در هر قالب تصویر دلخواه ذخیره کنید.
## **مثال**
```cs
//نمونه‌سازی کلاس Presentation که فایل ارائه را نشان می‌دهد
using (Presentation pres = new Presentation("Slides Test Presentation.pptx"))
{
    //دسترسی به اولین اسلاید
    ISlide sld = pres.Slides[0];

    //ایجاد تصویر با مقیاس کامل
    using (IImage image = sld.GetImage(1f, 1f))
    {
        //ذخیره تصویر در دیسک به فرمت JPEG
        image.Save("Test Thumbnail.jpg", ImageFormat.Jpeg);
    }
}
``` 
## **دانلود مثال اجرایی**
- [گیت‌هاب](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Slide%20Thumbnail%20to%20JPEG)
## **دانلود کد نمونه**
- [گیت‌هاب](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 
برای جزئیات بیشتر، به [تبدیل PPT و PPTX به JPG در .NET](/slides/fa/net/convert-powerpoint-to-jpg/) مراجعه کنید.
{{% /alert %}}