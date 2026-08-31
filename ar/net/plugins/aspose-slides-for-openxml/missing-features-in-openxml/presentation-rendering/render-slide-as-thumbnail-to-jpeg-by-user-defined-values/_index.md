---
title: تحويل الشريحة إلى صورة مصغرة بصيغة JPEG بالقيم المحددة من قبل المستخدم
type: docs
weight: 70
url: /ar/net/render-slide-as-thumbnail-to-jpeg-by-user-defined-values/
---
لإنشاء صورة مصغرة لأي شريحة مرغوبة باستخدام Aspose.Slides for .NET:

1. إنشاء نسخة من الفئة **Presentation**.
1. الحصول على مرجع أي شريحة مرغوبة باستخدام معرّفها أو فهرستها.
1. الحصول على عوامل المقياس X و Y بناءً على أبعاد X و Y المحددة من قبل المستخدم.
1. الحصول على صورة مصغرة للشريحة المرجعية على مقياس محدد.
1. حفظ صورة المصغرة بأي تنسيق صورة مرغوب.

``` csharp
using Aspose.Slides;

string filePath = @"..\..\..\Sample Files\";
string srcFileName = filePath + "User Defined Thumbnail.pptx";
string destFileName = filePath + "User Defined Thumbnail.jpg";

//إنشاء مثيل لفئة Presentation التي تمثل ملف العرض التقديمي
using (Presentation pres = new Presentation(srcFileName))
{
    //الوصول إلى الشريحة الأولى
    ISlide sld = pres.Slides[0];

    //البُعد المحدد من قبل المستخدم
    int desiredX = 1200;
    int desiredY = 800;

    //حساب القيمة المُقاسة لـ X و Y
    float scaleX = (float)(1.0 / pres.SlideSize.Size.Width) * desiredX;
    float scaleY = (float)(1.0 / pres.SlideSize.Size.Height) * desiredY;

    //إنشاء صورة بالحجم الكامل
    using (IImage image = sld.GetImage(scaleX, scaleY))
    {
        //حفظ الصورة على القرص بصيغة JPEG
        image.Save(destFileName, ImageFormat.Jpeg);
    }
}
``` 
## **تنزيل مثال الكود**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/User%20Defined%20Thumbnail%20%28Aspose.Slides%29.zip)