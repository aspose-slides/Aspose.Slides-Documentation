---
title: عرض الشريحة كصورة مصغرة إلى JPEG
type: docs
weight: 60
url: /ar/net/render-slide-as-thumbnail-to-jpeg/
---

**Aspose.Slides for .NET** يُستخدم لإنشاء ملفات عروض تقديمية تحتوي على شرائح. يمكن عرض هذه الشرائح بفتح ملفات العرض باستخدام Microsoft PowerPoint. ولكن أحيانًا قد يحتاج المطورون إلى عرض الشرائح كصور باستخدام عارض الصور المفضل لديهم. في مثل هذه الحالات، تساعدك Aspose.Slides for .NET على إنشاء صور مصغرة للشرائح.

لإنشاء صورة مصغرة لأي شريحة مرغوبة باستخدام Aspose.Slides for .NET:

1. إنشاء كائن من الفئة **Presentation**.
1. الحصول على مرجع أي شريحة مرغوبة باستخدام معرّفها أو فهرستها.
1. الحصول على صورة مصغرة للشريحة المشار إليها بمقياس محدد.
1. حفظ صورة المصغرة بأي تنسيق صورة مرغوب.

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
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Slide%20Thumbnail%20to%20JPEG%20%28Aspose.Slides%29.zip)