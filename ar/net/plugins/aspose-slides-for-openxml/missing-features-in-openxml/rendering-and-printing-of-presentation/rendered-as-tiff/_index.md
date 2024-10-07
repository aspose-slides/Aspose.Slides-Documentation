---
title: تم تقديمه كـ Tiff
type: docs
weight: 30
url: /net/rendered-as-tiff/
---

تنسيق TIFF معروف بمرونته لاستيعاب الصور المتعددة الصفحات والبيانات. مع الأخذ في الاعتبار أهمية وشعبية تنسيق TIFF، توفر Aspose.Slides لـ .NET دعمًا لتحويل العروض التقديمية إلى مستند TIFF.
تتناول هذه المقالة كيفية تصدير tiff مع خيارات مختلفة:

- تحويل العرض التقديمي إلى TIFF بالحجم الافتراضي.
- تحويل العرض التقديمي إلى TIFF بحجم مخصص.

يمكن للمطورين استدعاء طريقة **Save** التي تعرضها فئة **Presentation** لتحويل العرض التقديمي بالكامل إلى مستند **TIFF**. علاوة على ذلك، تعرض فئة TiffOptions خاصية ImageSize التي تمكن المطور من تحديد حجم الصورة إذا لزم الأمر.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Conversion to Tiff.tiff";

//إنشاء كائن Presentation يمثل ملف عرض تقديمي

using (Presentation pres = new Presentation(srcFileName))

{

    //حفظ العرض التقديمي في مستند TIFF

    pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Tiff);

}

``` 
## **تنزيل رمز العينة**
- [Codeplex](https://asposeslidesopenxml.codeplex.com/releases/view/619597)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Conversion%20to%20Tiff%20%28Aspose.Slides%29.zip)