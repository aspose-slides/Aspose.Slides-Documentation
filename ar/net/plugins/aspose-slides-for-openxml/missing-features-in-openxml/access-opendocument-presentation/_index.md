---
title: الوصول إلى تقديم OpenDocument
type: docs
weight: 10
url: /ar/net/access-opendocument-presentation/
---

يقدم Aspose.Slides لـ .NET فئة **Presentation** التي تمثل ملف تقديم. يمكن الآن لفئة **Presentation** أيضًا الوصول إلى **ODP** من خلال منشئ **Presentation** عند إنشاء الكائن.
## **مثال**
``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "OpenDocument Presentation.odp";

string destFileName = FilePath + "OpenDocument Presentation.pptx";

// إنشاء كائن Presentation يمثل ملف تقديم

using (Presentation pres = new Presentation(srcFileName))

{

    // حفظ التقديم بصيغة PPTX

    pres.Save(destFileName, SaveFormat.Pptx);

}

``` 
## **تحميل مثال الشيفرة**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
## **تحميل مثال التشغيل**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/OpenDocument%20Presentation)