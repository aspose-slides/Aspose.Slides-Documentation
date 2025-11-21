---
title: توطين العرض
type: docs
weight: 100
url: /ar/net/presentation-localization/
keywords: "تغيير اللغة, تدقيق إملائي, تدقيق الإملاء, مدقق إملائي, عرض PowerPoint, C#, Csharp, Aspose.Slides for .NET"
description: "تغيير أو فحص اللغة في عرض PowerPoint. تدقيق إملائي للنص في C# أو .NET"
---

## **تغيير اللغة للعرض ونص الشكل**
- إنشاء مثيل لفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) .
- الحصول على مرجع الشريحة باستخدام الفهرس الخاص بها.
- إضافة AutoShape من نوع Rectangle إلى الشريحة.
- إضافة بعض النص إلى TextFrame.
- تعيين Language Id للنص.
- حفظ العرض كملف PPTX.

يتم توضيح تنفيذ الخطوات المذكورة أعلاه أدناه في مثال.
```c#
using (Presentation pres = new Presentation("test0.pptx"))
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);
    shape.AddTextFrame("Text to apply spellcheck language");
    shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.LanguageId = "en-EN";

    pres.Save("test1.pptx",Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **الأسئلة المتكررة**

**هل يُؤدي معرف اللغة إلى ترجمة النص تلقائيًا؟**

لا. [LanguageId](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/languageid/) في Aspose.Slides يخزن اللغة لتدقيق الإملاء وإثبات القواعد، لكنه لا يترجم أو يغيّر محتوى النص. إنه بيانات وصفية يفهمها PowerPoint لإثبات النص.

**هل يؤثر معرف اللغة على الفواصل والكسرة أثناء العرض؟**

في Aspose.Slides، [LanguageId](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/languageid/) مخصص للإثبات. جودة الفواصل والكسرة تعتمد بشكل أساسي على توفر [الخطوط المناسبة](/slides/ar/net/powerpoint-fonts/) وإعدادات التخطيط/الكسرة للنظام الكتابي. لضمان عرض صحيح، احرص على توفر الخطوط المطلوبة، وتكوين [قواعد استبدال الخط](/slides/ar/net/font-substitution/)، و/أو [تضمين الخطوط](/slides/ar/net/embedded-font/) في العرض.

**هل يمكنني تعيين لغات مختلفة داخل فقرة واحدة؟**

نعم. يتم تطبيق [LanguageId](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/languageid/) على مستوى جزء النص، لذا يمكن لفقرة واحدة أن تمزج عدة لغات بإعدادات إثبات مختلفة.