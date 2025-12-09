---
title: تحويل عروض PowerPoint التقديمية إلى SWF Flash في .NET
linktitle: PowerPoint إلى SWF
type: docs
weight: 80
url: /ar/net/convert-powerpoint-to-swf-flash/
keywords:
- تحويل PowerPoint
- تحويل العرض التقديمي
- تحويل الشريحة
- تحويل PPT
- تحويل PPTX
- PowerPoint إلى SWF
- العرض التقديمي إلى SWF
- الشريحة إلى SWF
- PPT إلى SWF
- PPTX إلى SWF
- PowerPoint إلى Flash
- العرض التقديمي إلى Flash
- الشريحة إلى Flash
- PPT إلى Flash
- PPTX إلى Flash
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "تحويل PowerPoint (PPT/PPTX) إلى SWF Flash في .NET باستخدام Aspose.Slides. أمثلة شفرة C# خطوة بخطوة، مخرجات سريعة وعالية الجودة، دون أتمتة PowerPoint."
---

## **تحويل العروض التقديمية إلى فلاش**

يمكن استخدام طريقة [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save/index) المعروضة بواسطة فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) لتحويل العرض التقديمي بالكامل إلى مستند SWF. يمكنك أيضًا تضمين التعليقات في ملف SWF الناتج باستخدام فئة [SWFOptions](https://reference.aspose.com/slides/net/aspose.slides.export/swfoptions) وواجهة [INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/inotescommentslayoutingoptions). يوضح المثال التالي كيفية تحويل عرض تقديمي إلى مستند SWF باستخدام الخيارات التي توفرها فئة SWFOptions.

```c#
 // إنشاء كائن Presentation يمثل ملف عرض تقديمي
using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    SwfOptions swfOptions = new SwfOptions();
    swfOptions.ViewerIncluded = false;


    INotesCommentsLayoutingOptions notesOptions = swfOptions.NotesCommentsLayouting;
    notesOptions.NotesPosition = NotesPositions.BottomFull;

    // حفظ العرض التقديمي وصفحات الملاحظات
    presentation.Save("SaveAsSwf_out.swf", SaveFormat.Swf, swfOptions);
    swfOptions.ViewerIncluded = true;
    presentation.Save("SaveNotes_out.swf", SaveFormat.Swf, swfOptions);
}
```


## **الأسئلة الشائعة**

**هل يمكنني تضمين الشرائح المخفية في ملف SWF؟**

نعم. فعّل خيار [ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/swfoptions/showhiddenslides/) في [SwfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/swfoptions/). بشكلٍ افتراضي، لا يتم تصدير الشرائح المخفية.

**كيف يمكنني التحكم في الضغط وحجم ملف SWF النهائي؟**

استخدم العلامة [Compressed](https://reference.aspose.com/slides/net/aspose.slides.export/swfoptions/compressed/) (مفعلة بشكلٍ افتراضي) وقم بضبط [JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/swfoptions/jpegquality/) لتحقيق التوازن بين حجم الملف وجودة الصورة.

**ما هو غرض 'ViewerIncluded' ومتى يجب تعطيله؟**

يضيف [ViewerIncluded](https://reference.aspose.com/slides/net/aspose.slides.export/swfoptions/viewerincluded/) واجهة مستخدم مدمجة للمشغل (أدوات التنقل، اللوحات، البحث). عطلها إذا كنت تنوي استخدام مشغل خاص بك أو تحتاج إلى إطار SWF بسيط بدون واجهة.

**ماذا يحدث إذا كان الخط المصدر غير موجود على جهاز التصدير؟**

ستستبدل Aspose.Slides الخط الذي تحدده عبر [DefaultRegularFont](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/defaultregularfont/) في [SwfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/) لتجنب الانتقال غير المقصود إلى خط آخر.