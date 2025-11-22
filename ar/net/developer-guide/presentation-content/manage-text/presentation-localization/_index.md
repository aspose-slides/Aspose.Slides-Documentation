---
title: توطين العرض التقديمي
type: docs
weight: 100
url: /ar/net/presentation-localization/
keywords: "تغيير اللغة, تدقيق إملائي, تدقيق إملاء, مدقق إملائي, عرض PowerPoint, C#, Csharp, Aspose.Slides for .NET"
description: "تغيير أو فحص اللغة في عرض PowerPoint. تدقيق إملائي للنص في C# أو .NET"
---

## **تغيير اللغة للعرض ونص الشكل**
- إنشاء مثيل لفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) class.
- الحصول على مرجع شريحة باستخدام فهرسها.
- إضافة AutoShape من النوع Rectangle إلى الشريحة.
- إضافة بعض النص إلى TextFrame.
- تعيين Language Id للنص.
- كتابة العرض بصيغة ملف PPTX.

يتم توضيح تنفيذ الخطوات المذكورة أعلاه في مثال أدناه.
```c#
using (Presentation pres = new Presentation("test0.pptx"))
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);
    shape.AddTextFrame("Text to apply spellcheck language");
    shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.LanguageId = "en-EN";

    pres.Save("test1.pptx",Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **الأسئلة الشائعة**

**هل يقوم language_id بتفعيل الترجمة التلقائية للنص؟**

لا. [language_id](https://reference.aspose.com/slides/net/aspose.slides/portionformat/languageid/) في Aspose.Slides يخزن اللغة للتدقيق الإملائي وإثبات القواعد، لكنه لا يترجم أو يغير محتوى النص. إنها بيانات وصفية يفهمها PowerPoint للإثبات.

**هل يؤثر language_id على التقسيم إلى مقاطع والفواصل خلال العرض؟**

في Aspose.Slides، [LanguageId](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/languageid/) مخصص للإثبات. جودة التقسيم إلى مقاطع وتفاف السطر تعتمد أساساً على توفر [proper fonts](/slides/ar/net/powerpoint-fonts/) وإعدادات التخطيط/فواصل السطر لنظام الكتابة. لضمان العرض الصحيح، احرص على توفير الخطوط المطلوبة، وتكوين [font substitution rules](/slides/ar/net/font-substitution/)، و/أو [embed fonts](/slides/ar/net/embedded-font/) في العرض.

**هل يمكنني تعيين لغات مختلفة داخل فقرة واحدة؟**

نعم. يتم تطبيق [LanguageId](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/languageid/) على مستوى جزء النص، لذا يمكن لفقرة واحدة دمج لغات متعددة بإعدادات إثبات مختلفة.