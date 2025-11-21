---
title: تحويل عروض PowerPoint التقديمية إلى SWF فلاش في .NET
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
- PowerPoint إلى فلاش
- العرض التقديمي إلى فلاش
- الشريحة إلى فلاش
- PPT إلى فلاش
- PPTX إلى فلاش
- PowerPoint
- العرض التقديمي
- .NET
- C#
- Aspose.Slides
description: "تحويل PowerPoint (PPT/PPTX) إلى SWF فلاش في .NET باستخدام Aspose.Slides. عينات كود C# خطوة بخطوة، إخراج سريع وعالي الجودة، دون أتمتة PowerPoint."
---

## **تحويل العروض التقديمية إلى فلاش**

يمكن استخدام طريقة [حفظ](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save/index) التي توفرها فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) لتحويل العرض التقديمي بالكامل إلى مستند SWF. يمكنك أيضًا تضمين التعليقات في ملف SWF المُولَّد باستخدام فئة [SWFOptions](https://reference.aspose.com/slides/net/aspose.slides.export/swfoptions) وواجهة [INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/inotescommentslayoutingoptions). في المثال التالي يتم إظهار كيفية تحويل عرض تقديمي إلى مستند SWF باستخدام الخيارات التي توفرها فئة SWFOptions.
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


## **الأسئلة المتكررة**

**هل يمكنني تضمين الشرائح المخفية في ملف SWF؟**

نعم. فعّل خيار [ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/swfoptions/showhiddenslides/) في فئة [SwfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/swfoptions/). بشكل افتراضي، لا يتم تصدير الشرائح المخفية.

**كيف يمكنني التحكم في الضغط وحجم ملف SWF النهائي؟**

استخدم علامة [Compressed](https://reference.aspose.com/slides/net/aspose.slides.export/swfoptions/compressed/) (مفعَّلة افتراضيًا) واضبط [JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/swfoptions/jpegquality/) لتحقيق التوازن بين حجم الملف وجودة الصورة.

**ما هدف 'ViewerIncluded' ومتى يجب تعطيله؟**

يضيف [ViewerIncluded](https://reference.aspose.com/slides/net/aspose.slides.export/swfoptions/viewerincluded/) واجهة مستخدم مشغّل مدمجة (أدوات تنقل، لوحات، بحث). عطلها إذا كنت تنوي استخدام مشغّل خاص بك أو تحتاج إلى إطار SWF خالٍ من واجهة المستخدم.

**ماذا يحدث إذا كان الخط الأصلي مفقودًا على جهاز التصدير؟**

ستقوم Aspose.Slides باستبدال الخط الذي تحدده عبر [DefaultRegularFont](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/defaultregularfont/) في فئة [SwfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/) لتجنب الانتقال إلى خط بديل غير مقصود.