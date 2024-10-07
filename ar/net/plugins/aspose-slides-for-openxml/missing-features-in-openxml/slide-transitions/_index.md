---
title: تأثيرات انتقال الشريحة
type: docs
weight: 80
url: /net/slide-transitions/
---

لتسهيل الفهم، قمنا بعرض استخدام Aspose.Slides لـ .NET لإدارة تأثيرات انتقال الشريحة البسيطة. يمكن للمطورين تطبيق تأثيرات انتقال مختلفة على الشرائح، بالإضافة إلى تخصيص سلوك هذه التأثيرات الانتقالية. لإنشاء تأثير انتقال بسيط للشريحة، اتبع الخطوات أدناه:

- إنشاء مثيل من فئة Presentation
- تطبيق نوع تأثير انتقال الشريحة على الشريحة من بين تأثيرات الانتقال التي تقدمها Aspose.Slides لـ .NET من خلال **TransitionType** enum
- كتابة ملف العرض المعدل.
## **مثال**
``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string FileName = FilePath + "Managing Slides Transitions.pptx";

//إنشاء مثيل لفئة Presentation تمثل ملف عرض تقديمي

using (Presentation pres = new Presentation(FileName))

{

    //تطبيق تأثير انتقال دائري على الشريحة 1

    pres.Slides[0].SlideShowTransition.Type = TransitionType.Circle;

    //تطبيق تأثير انتقال مجمع على الشريحة 2

    pres.Slides[1].SlideShowTransition.Type = TransitionType.Comb;

    //تطبيق تأثير انتقال زووم على الشريحة 3

    pres.Slides[2].SlideShowTransition.Type = TransitionType.Zoom;

    //حفظ العرض التقديمي على القرص

    pres.Save(FileName, SaveFormat.Pptx);

}

``` 
## **تنزيل كود العينة**
- [Codeplex](https://asposeslidesopenxml.codeplex.com/releases/view/619597)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c)
## **تنزيل المثال القابل للتشغيل**
- [Codeplex](https://asposeslidesopenxml.codeplex.com/SourceControl/latest#Aspose.Slides Features missing in OpenXML/Managing Slides Transitions/)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/Managing%20Slides%20Transitions)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c/view/SourceCode)

{{% alert color="primary" %}} 

للحصول على مزيد من التفاصيل، قم بزيارة [إدارة تأثيرات انتقال الشرائح](/slides/net/slide-transition/).

{{% /alert %}}