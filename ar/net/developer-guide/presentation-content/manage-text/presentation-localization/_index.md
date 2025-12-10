---
title: أتمتة تعريب العروض التقديمية في .NET
linktitle: تعريب العرض التقديمي
type: docs
weight: 100
url: /ar/net/presentation-localization/
keywords:
- تغيير اللغة
- التدقيق الإملائي
- معرف اللغة
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "أتمتة تعريب شرائح PowerPoint وOpenDocument في .NET باستخدام Aspose.Slides، مع أمثلة عملية على شفرة C# ونصائح لتسريع النشر العالمي."
---

## **تغيير اللغة لعرض تقديمي ونص الشكل**
- إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
- الحصول على مرجع الشريحة باستخدام الفهرس الخاص بها.
- إضافة AutoShape من النوع Rectangle إلى الشريحة.
- إضافة بعض النص إلى TextFrame.
- تعيين Language Id للنص.
- حفظ العرض التقديمي كملف PPTX.

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


## **الأسئلة الشائعة**

**هل يُؤدي Language ID إلى ترجمة النص تلقائياً؟**

لا. [LanguageId](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/languageid/) في Aspose.Slides يخزن اللغة للتدقيق الإملائي وإثبات القواعد، لكنه لا يترجم أو يغير محتوى النص. إنها بيانات وصفية يفهمها PowerPoint للإثبات.

**هل يؤثر Language ID على التجزئة والفواصل أثناء العرض؟**

في Aspose.Slides، [LanguageId](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/languageid/) مخصص للإثبات. تعتمد جودة التجزئة وتغليف السطر أساساً على توفر [proper fonts](/slides/ar/net/powerpoint-fonts/) وإعدادات التخطيط/إدراج الفواصل لنظام الكتابة. لضمان العرض الصحيح، احرص على توفير الخطوط المطلوبة، وتكوين [font substitution rules](/slides/ar/net/font-substitution/)، و/أو [embed fonts](/slides/ar/net/embedded-font/) في العرض التقديمي.

**هل يمكنني تعيين لغات مختلفة داخل فقرة واحدة؟**

نعم. يتم تطبيق [LanguageId](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/languageid/) على مستوى جزء النص، لذا يمكن لفقرة واحدة دمج عدة لغات بإعدادات إثبات متميزة.