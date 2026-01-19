---
title: الحصول على تنسيق ملف العرض التقديمي
type: docs
weight: 50
url: /ar/net/get-the-file-format-of-presentation/
---

لكي تحصل على تنسيق الملف. يرجى اتباع الخطوات أدناه:

- إنشاء مثيل من الفئة **IPresentationInfo**
- الحصول على معلومات حول العرض التقديمي

في المثال المعطى أدناه، حصلنا على تنسيق الملف.
## **مثال**
``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string FileName = FilePath + "Getting the format of a file.pptx";

IPresentationInfo info;

info = PresentationFactory.Instance.GetPresentationInfo(FileName);


switch (info.LoadFormat)

{

    case LoadFormat.Pptx:

        {

            break;

        }

    case LoadFormat.Unknown:

        {

            break;

        }

}

``` 
## **تنزيل الكود النموذجي**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
## **تنزيل المثال التشغيلي**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/Getting%20the%20format%20of%20a%20file)