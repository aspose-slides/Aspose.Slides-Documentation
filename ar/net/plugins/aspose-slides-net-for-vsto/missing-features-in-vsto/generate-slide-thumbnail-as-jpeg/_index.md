---
title: إنشاء مصغرة شريحة بصيغة JPEG
type: docs
weight: 90
url: /ar/net/generate-slide-thumbnail-as-jpeg/
---

لإنشاء مصغرة لأي شريحة مرغوبة باستخدام Aspose.Slides لـ .NET:

- أنشئ مثيلًا من فئة Presentation.
- احصل على إشارة إلى أي شريحة مرغوبة باستخدام معرفها أو فهرسها.
- احصل على صورة المصغرة للشريحة المرجعية على مقياس محدد.
- احفظ صورة المصغرة بأي تنسيق صورة مرغوب.

## **مثال**
```cs
//قم بإنشاء مثيل من فئة Presentation التي تمثل ملف العرض التقديمي
using (Presentation pres = new Presentation("Slides Test Presentation.pptx"))
{
    //الوصول إلى الشريحة الأولى
    ISlide sld = pres.Slides[0];

    //إنشاء صورة بمقياس كامل
    using (IImage image = sld.GetImage(1f, 1f))
    {
        //حفظ الصورة على القرص في صيغة JPEG
        image.Save("Test Thumbnail.jpg", ImageFormat.Jpeg);
    }
}
``` 
## **تحميل المثال القابل للتشغيل**
- [CodePlex](https://asposeslidesvsto.codeplex.com/SourceControl/latest#Aspose.Slides Features missing in VSTO/Slide Thumbnail to JPEG/)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Slide%20Thumbnail%20to%20JPEG)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-78d1d03d/view/SourceCode)
## **تحميل كود العينة**
- [CodePlex](https://asposeslidesvsto.codeplex.com/releases/view/620001)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-78d1d03d#content)

{{% alert color="primary" %}} 

لمزيد من التفاصيل، قم بزيارة [إنشاء صورة مصغرة الشرائح](/slides/ar/net/presentation-viewer/#presentationviewer-creatingslidesthumbnailimage).

{{% /alert %}}