---
title: إنشاء صورة مصغرة من شريحة مع أبعاد محددة من قبل المستخدم
type: docs
weight: 100
url: /ar/net/generating-a-thumbnail-from-a-slide-with-user-defined-dimensions/
---

لإنشاء صورة مصغرة لأي شريحة مرغوبة باستخدام Aspose.Slides لـ .NET:

- انشئ مثيل من فئة Presentation.
- احصل على مرجع لأي شريحة مرغوبة باستخدام معرفها أو فهرسها.
- احصل على عوامل التحجيم X و Y بناءً على الأبعاد المحددة من قبل المستخدم.
- احصل على صورة مصغرة للشريحة المرجعية بمقياس محدد.
- قم بحفظ صورة المصغرة في أي تنسيق صورة مرغوب.

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
## **تحميل المثال القابل للتشغيل**
- [CodePlex](https://asposeslidesvsto.codeplex.com/SourceControl/latest#Aspose.Slides Features missing in VSTO/User Defined Thumbnail/)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/User%20Defined%20Thumbnail)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-78d1d03d/view/SourceCode)
## **تحميل كود العينة**
- [CodePlex](https://asposeslidesvsto.codeplex.com/releases/view/620001)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-78d1d03d#content)

{{% alert color="primary" %}} 

للحصول على مزيد من التفاصيل، قم بزيارة [إنشاء صورة مصغرة للشرائح](/slides/ar/net/presentation-viewer/#creating-slides-thumbnail-image).

{{% /alert %}}