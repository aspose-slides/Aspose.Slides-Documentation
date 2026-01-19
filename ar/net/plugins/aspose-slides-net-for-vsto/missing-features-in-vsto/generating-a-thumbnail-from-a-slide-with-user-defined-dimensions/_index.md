---
title: إنشاء صورة مصغرة من شريحة بأبعاد محددة من قبل المستخدم
type: docs
weight: 100
url: /ar/net/generating-a-thumbnail-from-a-slide-with-user-defined-dimensions/
---

لإنشاء صورة مصغرة لأي شريحة مرغوبة باستخدام Aspose.Slides لـ .NET:

- إنشاء نسخة من فئة Presentation.
- الحصول على مرجع أي شريحة مرغوبة باستخدام معرفها أو فهرسها.
- الحصول على عوامل مقياس X و Y بناءً على الأبعاد X و Y المعرفة من قبل المستخدم.
- الحصول على صورة مصغرة للشريحة المرجعية على مقياس محدد.
- حفظ صورة المصغرة بأي صيغة صورة مرغوبة.
## **مثال**
```cs
//Instantiate the Presentation class that represents the presentation file
using (Presentation pres = new Presentation("TestPresentation.pptx"))
{
    //Access the first slide
    ISlide sld = pres.Slides[0];

    //User defined dimension
    int desiredX = 1200;
    int desiredY = 800;

    //Getting scaled value  of X and Y
    float scaleX = (float)(1.0 / pres.SlideSize.Size.Width) * desiredX;
    float scaleY = (float)(1.0 / pres.SlideSize.Size.Height) * desiredY;

    //Create a full scale image
    using (IImage image = sld.GetImage(scaleX, scaleY))
    {
        //Save the image to disk in JPEG format
        image.Save("Thumbnail2.jpg", ImageFormat.Jpeg);
    }
}
``` 
## **تنزيل المثال التشغيلي**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/User%20Defined%20Thumbnail)
## **تنزيل عينة الكود**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 
لمزيد من التفاصيل، زر [تحويل الشريحة](/slides/ar/net/convert-slide/).
{{% /alert %}}