---
title: تحويل الشريحة إلى صورة مصغرة بصيغة JPEG
type: docs
weight: 60
url: /ar/net/render-slide-as-thumbnail-to-jpeg/
---
**Aspose.Slides for .NET** تُستخدم لإنشاء ملفات عروض تقديمية تحتوي على شرائح. يمكن عرض هذه الشرائح بفتح ملفات العروض باستخدام Microsoft PowerPoint. ولكن في بعض الأحيان قد يحتاج المطورون إلى عرض الشرائح كصور باستخدام عارض الصور المفضل لديهم. في مثل هذه الحالات، يساعدك Aspose.Slides for .NET على إنشاء صور مصغرة للشرائح.

لإنشاء صورة مصغرة لأي شريحة مرغوبة باستخدام Aspose.Slides for .NET:

1. إنشاء مثيل لفئة **Presentation**.
1. الحصول على مرجع أي شريحة مرغوبة باستخدام رقم التعريف (ID) أو الفهرس الخاص بها.
1. الحصول على صورة مصغرة للشريحة المرجعية بمقياس محدد.
1. حفظ الصورة المصغرة بأي تنسيق صور مرغوب.

``` csharp
using Aspose.Slides;

string filePath = @"..\..\..\Sample Files\";
string srcFileName = filePath + "Slide Thumbnail to JPEG.pptx";
string destFileName = filePath + "Slide Thumbnail to JPEG.jpg";

//إنشاء فئة Presentation التي تمثل ملف العرض التقديمي
using (Presentation pres = new Presentation(srcFileName))
{
    //الوصول إلى الشريحة الأولى
    ISlide sld = pres.Slides[0];

    //إنشاء صورة بالحجم الكامل
    using (IImage image = sld.GetImage(1f, 1f))
    {
        //حفظ الصورة على القرص بصيغة JPEG
        image.Save(destFileName, ImageFormat.Jpeg);
    }
}
``` 

## **تنزيل مثال الكود**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Slide%20Thumbnail%20to%20JPEG%20%28Aspose.Slides%29.zip)