---
title: عرض الشريحة كصورة مصغرة بصيغة JPEG باستخدام قيم محددة من المستخدم
type: docs
weight: 70
url: /ar/net/render-slide-as-thumbnail-to-jpeg-by-user-defined-values/
---

لإنشاء مصغّر لأي شريحة مرغوبة باستخدام Aspose.Slides for .NET:

1. إنشاء كائن من الفئة **Presentation**.
1. الحصول على مرجع أي شريحة مرغوبة باستخدام معرفها أو فهرستها.
1. الحصول على عوامل مقياس X و Y بناءً على الأبعاد X و Y المحددة من قبل المستخدم.
1. الحصول على صورة المصغّر للشريحة المرجعية بمقياس محدد.
1. حفظ صورة المصغّر بأي تنسيق صورة مرغوب.

``` csharp
string filePath = @"..\..\..\Sample Files\";
string srcFileName = filePath + "User Defined Thumbnail.pptx";
string destFileName = filePath + "User Defined Thumbnail.jpg";

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
## **تنزيل شفرة العينة**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/User%20Defined%20Thumbnail%20%28Aspose.Slides%29.zip)