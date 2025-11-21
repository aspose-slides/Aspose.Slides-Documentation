---
title: أتمتة تعريب العروض التقديمية في .NET
linktitle: تعريب العروض التقديمية
type: docs
weight: 100
url: /ar/net/presentation-localization/
keywords:
- تغيير اللغة
- تدقيق إملائي
- معرف اللغة
- PowerPoint
- العرض التقديمي
- .NET
- C#
- Aspose.Slides
description: "أتمتة تعريب شرائح PowerPoint وOpenDocument في .NET باستخدام Aspose.Slides، مع أمثلة عملية على كود C# ونصائح لتسريع النشر العالمي."
---

## **تغيير اللغة لعرض النص في العروض التقديمية والشكل**
- إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) .
- الحصول على مرجع الشريحة باستخدام فهرسها.
- إضافة AutoShape من نوع Rectangle إلى الشريحة.
- إضافة بعض النص إلى TextFrame.
- ضبط معرف اللغة (Language Id) للنص.
- حفظ العرض التقديمي كملف PPTX.

يتم توضيح تنفيذ الخطوات المذكورة أعلاه في المثال أدناه.
```c#
using (Presentation pres = new Presentation("test0.pptx"))
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);
    shape.AddTextFrame("Text to apply spellcheck language");
    shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.LanguageId = "en-EN";

    pres.Save("test1.pptx",Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **FAQ**

**هل يؤدي معرف اللغة إلى ترجمة النص تلقائيًا؟**

لا. [LanguageId](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/languageid/) في Aspose.Slides يخزن اللغة لتدقيق الإملاء وإثبات القواعد، لكنه لا يترجم أو يغير محتوى النص. إنها بيانات وصفية يفهمها PowerPoint للإثبات.

**هل يؤثر معرف اللغة على التجزئة والسطور أثناء العرض؟**

في Aspose.Slides، [LanguageId](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/languageid/) مخصص للإثبات. جودة التجزئة وتغليف السطر تعتمد بشكل أساسي على توفر [الخطوط المناسبة](/slides/ar/net/powerpoint-fonts/) وإعدادات التخطيط/فواصل السطر لنظام الكتابة. لضمان عرض صحيح، احرص على توفير الخطوط المطلوبة، وتكوين [قواعد استبدال الخط](/slides/ar/net/font-substitution/)، و/أو [تضمين الخطوط](/slides/ar/net/embedded-font/) في العرض التقديمي.

**هل يمكنني تعيين لغات مختلفة داخل فقرة واحدة؟**

نعم. يتم تطبيق [LanguageId](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/languageid/) على مستوى جزء النص، وبالتالي يمكن لفقرة واحدة أن تحتوي على عدة لغات بإعدادات إثبات مختلفة.