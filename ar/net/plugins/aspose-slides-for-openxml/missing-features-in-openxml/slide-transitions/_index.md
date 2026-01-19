---
title: انتقالات الشرائح
type: docs
weight: 80
url: /ar/net/slide-transitions/
---

لتسهيل الفهم، قمنا بتوضيح كيفية استخدام Aspose.Slides for .NET لإدارة انتقالات الشرائح البسيطة. يمكن للمطورين ليس فقط تطبيق تأثيرات انتقال مختلفة على الشرائح، بل أيضًا تخصيص سلوك هذه التأثيرات.

لإنشاء تأثير انتقال شريحة بسيط، اتبع الخطوات التالية:

- إنشاء كائن من فئة Presentation
- تطبيق نوع انتقال الشريحة من أحد تأثيرات الانتقال المتوفرة في Aspose.Slides for .NET عبر عدد **TransitionType**
- كتابة ملف العرض المعدل.

## **مثال**
``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string FileName = FilePath + "Managing Slides Transitions.pptx";

//Instantiate Presentation class that represents a presentation file

using (Presentation pres = new Presentation(FileName))

{

    //Apply circle type transition on slide 1

    pres.Slides[0].SlideShowTransition.Type = TransitionType.Circle;

    //Apply comb type transition on slide 2

    pres.Slides[1].SlideShowTransition.Type = TransitionType.Comb;

    //Apply zoom type transition on slide 3

    pres.Slides[2].SlideShowTransition.Type = TransitionType.Zoom;

    //Write the presentation to disk

    pres.Save(FileName, SaveFormat.Pptx);

}

``` 
## **تنزيل كود العينة**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)

## **تنزيل المثال التشغيلي**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/Managing%20Slides%20Transitions)

{{% alert color="primary" %}} 

لمزيد من التفاصيل، زر [إدارة انتقالات الشرائح](/slides/ar/net/slide-transition/).

{{% /alert %}}