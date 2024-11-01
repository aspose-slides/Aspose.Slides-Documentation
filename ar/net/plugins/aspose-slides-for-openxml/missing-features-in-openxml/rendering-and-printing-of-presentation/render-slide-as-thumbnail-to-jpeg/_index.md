---
title: عرض الشريحة كصورة مصغرة بصيغة JPEG
type: docs
weight: 60
url: /ar/net/render-slide-as-thumbnail-to-jpeg/
---

**Aspose.Slides لـ .NET** تُستخدم لإنشاء ملفات العروض التقديمية التي تحتوي على الشرائح. يمكن عرض هذه الشرائح من خلال فتح ملفات العروض التقديمية باستخدام Microsoft PowerPoint. ولكن في بعض الأحيان، قد يحتاج المطورون إلى عرض الشرائح كصور باستخدام عارض الصور المفضل لديهم. في مثل هذه الحالات، تساعدك Aspose.Slides لـ .NET في إنشاء صور مصغرة للشرائح.

لإنشاء صورة مصغرة لأي شريحة مرغوبة باستخدام Aspose.Slides لـ .NET:

1. أنشئ مثيلًا من فئة **Presentation**.
1. احصل على مرجع لأي شريحة مرغوبة باستخدام معرفها أو فهرسها.
1. احصل على صورة المصغرة للشريحة المرجعية على مقياس محدد.
1. احفظ صورة المصغرة بأي صيغة صورة مرغوبة.

``` csharp
string filePath = @"..\..\..\Sample Files\";
string srcFileName = filePath + "Slide Thumbnail to JPEG.pptx";
string destFileName = filePath + "Slide Thumbnail to JPEG.jpg";

//Instantiate the Presentation class that represents the presentation file
using (Presentation pres = new Presentation(srcFileName))
{
    //Access the first slide
    ISlide sld = pres.Slides[0];

    //Create a full scale image
    using (IImage image = sld.GetImage(1f, 1f))
    {
        //Save the image to disk in JPEG format
        image.Save(destFileName, ImageFormat.Jpeg);
    }
}
``` 

## **تنزيل كود العينة**
- [Codeplex](https://asposeslidesopenxml.codeplex.com/releases/view/619597)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Slide%20Thumbnail%20to%20JPEG%20%28Aspose.Slides%29.zip)