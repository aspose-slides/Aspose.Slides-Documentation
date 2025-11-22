---
title: تحويل PowerPoint إلى فلاش SWF
type: docs
weight: 80
url: /ar/net/convert-powerpoint-to-swf-flash/
keywords: "تحويل PowerPoint, عرض تقديمي, PowerPoint إلى SWF, فلاش SWF PPT إلى SWF, PPTX إلى SWF, C#, Csharp, .NET"
description: "تحويل عرض تقديمي PowerPoint إلى فلاش SWF في C# أو .NET"
---

## **تحويل العروض التقديمية إلى فلاش**

يمكن استخدام طريقة [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save/index) التي يعرّفها الصف [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) لتحويل العرض التقديمي بالكامل إلى مستند SWF. يمكنك أيضًا تضمين التعليقات في ملف SWF المُولَّد باستخدام الصف [SWFOptions](https://reference.aspose.com/slides/net/aspose.slides.export/swfoptions) والواجهة [INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/inotescommentslayoutingoptions). يوضح المثال التالي كيفية تحويل عرض تقديمي إلى مستند SWF باستخدام الخيارات التي توفرها الصف [SWFOptions](https://reference.aspose.com/slides/net/aspose.slides.export/swfoptions).
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

نعم. فعّل خيار [ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/swfoptions/showhiddenslides/) في [SwfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/swfoptions/). بشكل افتراضي، لا يتم تصدير الشرائح المخفية.

**كيف يمكنني التحكم في الضغط وحجم ملف SWF النهائي؟**

استخدم علم [Compressed](https://reference.aspose.com/slides/net/aspose.slides.export/swfoptions/compressed/) (مفعّل بشكل افتراضي) واضبط [JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/swfoptions/jpegquality/) لتحقيق توازن بين حجم الملف وجودة الصورة.

**ما هو الغرض من 'ViewerIncluded' ومتى يجب تعطيله؟**

[ViewerIncluded](https://reference.aspose.com/slides/net/aspose.slides.export/swfoptions/viewerincluded/) يضيف واجهة مستخدم مشغل مدمج (عناصر تحكم تنقل، لوحات، بحث). عطلها إذا كنت تخطط لاستخدام مشغل خاص بك أو تحتاج إلى إطار SWF بسيط بدون واجهة.

**ماذا يحدث إذا كان الخط الأصلي مفقودًا على جهاز التصدير؟**

ستستبدل Aspose.Slides الخط الذي تحدده عبر [DefaultRegularFont](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/defaultregularfont/) في [SwfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/) لتجنب الرجوع غير المقصود إلى خط آخر.