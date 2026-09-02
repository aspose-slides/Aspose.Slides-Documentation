---
title: معروض كـ Tiff
type: docs
weight: 30
url: /ar/net/rendered-as-tiff/
---
يُعرف تنسيق TIFF بمرونته التي تسمح باستيعاب الصور المتعددة الصفحات والبيانات. مع الأخذ في الاعتبار أهمية وشعبية تنسيق TIFF، توفر Aspose.Slides لـ .NET الدعم لتحويل العروض التقديمية إلى مستند TIFF.
توضح هذه المقالة كيفية خيارات تصدير TIFF المختلفة:

- تحويل العرض التقديمي إلى TIFF بالحجم الافتراضي.
- تحويل العرض التقديمي إلى TIFF بحجم مخصص.

يمكن للمطورين استدعاء طريقة **Save** التي توفرها الفئة **Presentation** لتحويل العرض التقديمي بالكامل إلى مستند **TIFF**. بالإضافة إلى ذلك، تكشف فئة TiffOptions عن الخاصية ImageSize التي تمكّن المطور من تحديد حجم الصورة إذا لزم الأمر.

``` csharp
using Aspose.Slides;


 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Conversion to Tiff.tiff";

//إنشاء كائن Presentation يمثل ملف العرض التقديمي

using (Presentation pres = new Presentation(srcFileName))

{

    //حفظ العرض التقديمي إلى مستند TIFF

    pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Tiff);

}
``` 
## **تنزيل كود العينة**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Conversion%20to%20Tiff%20%28Aspose.Slides%29.zip)