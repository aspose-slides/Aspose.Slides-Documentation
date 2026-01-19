---
title: معروض كـ Tiff
type: docs
weight: 30
url: /ar/net/rendered-as-tiff/
---

معروف عن تنسيق TIFF مرونته في استيعاب الصور المتعددة الصفحات والبيانات. بالنظر إلى أهمية وشعبية تنسيق TIFF، تقدم Aspose.Slides for .NET الدعم لتحويل العروض التقديمية إلى مستند TIFF.
توضح هذه المقالة خيارات تصدير TIFF المختلفة:

- تحويل العرض التقديمي إلى TIFF بالحجم الافتراضي.
- تحويل العرض التقديمي إلى TIFF بحجم مخصص.

يمكن للمطورين استدعاء طريقة **Save** التي توفرها فئة **Presentation** لتحويل العرض التقديمي بالكامل إلى مستند **TIFF**. بالإضافة إلى ذلك، تكشف فئة TiffOptions عن خاصية ImageSize التي تمكن المطور من تحديد حجم الصورة إذا لزم الأمر.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Conversion to Tiff.tiff";

//Instantiate a Presentation object that represents a presentation file

using (Presentation pres = new Presentation(srcFileName))

{

    //Saving the presentation to TIFF document

    pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Tiff);

}

``` 
## **Download Sample Code**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Conversion%20to%20Tiff%20%28Aspose.Slides%29.zip)