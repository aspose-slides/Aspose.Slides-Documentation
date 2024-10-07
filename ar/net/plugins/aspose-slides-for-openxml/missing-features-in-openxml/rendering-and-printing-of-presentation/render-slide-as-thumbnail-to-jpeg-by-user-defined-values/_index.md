---
title: عرض الشريحة كصور مصغرة بصيغة JPEG وفقًا لقيم يحددها المستخدم
type: docs
weight: 70
url: /net/render-slide-as-thumbnail-to-jpeg-by-user-defined-values/
---

لتوليد الصورة المصغرة لأي شريحة مرغوبة باستخدام Aspose.Slides لـ .NET:

1. إنشاء مثيل من فئة **Presentation**.
1. الحصول على مرجع لأي شريحة مرغوبة باستخدام معرّفها أو فهرسها.
1. الحصول على عوامل قياس X و Y بناءً على الأبعاد المحددة من قبل المستخدم.
1. الحصول على صورة مصغرة للشريحة المرجعية على مقياس محدد.
1. حفظ الصورة المصغرة بأي صيغة صورة مرغوبة.

``` csharp
string filePath = @"..\..\..\Sample Files\";
string srcFileName = filePath + "صورة مصغرة محددة من قبل المستخدم.pptx";
string destFileName = filePath + "صورة مصغرة محددة من قبل المستخدم.jpg";

//Instantiate the Presentation class that represents the presentation file
using (Presentation pres = new Presentation(srcFileName))
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
        image.Save(destFileName, ImageFormat.Jpeg);
    }
}
``` 
## **تحميل مثال الكود**
- [Codeplex](https://asposeslidesopenxml.codeplex.com/releases/view/619597)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/User%20Defined%20Thumbnail%20%28Aspose.Slides%29.zip)