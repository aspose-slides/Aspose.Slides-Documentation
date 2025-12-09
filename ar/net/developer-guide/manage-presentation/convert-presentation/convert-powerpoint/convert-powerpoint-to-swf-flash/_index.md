---
title: تحويل عروض PowerPoint إلى فلاش SWF في .NET
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
description: "تحويل PowerPoint (PPT/PPTX) إلى فلاش SWF في .NET باستخدام Aspose.Slides. عينات كود C# خطوة بخطوة، إخراج سريع الجودة، دون أتمتة PowerPoint."
---

## **تحويل العروض التقديمية إلى فلاش**

يمكن استخدام طريقة [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save/index) التي يوفرها فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) لتحويل العرض التقديمي بالكامل إلى مستند SWF. يمكنك أيضًا تضمين التعليقات في ملف SWF المُنشأ باستخدام فئة [SWFOptions](https://reference.aspose.com/slides/net/aspose.slides.export/swfoptions) والواجهة [INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/inotescommentslayoutingoptions). يوضح المثال التالي كيفية تحويل عرض تقديمي إلى مستند SWF باستخدام الخيارات التي توفرها فئة SWFOptions.
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

نعم. قم بتمكين الخيار [ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/swfoptions/showhiddenslides/) في [SwfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/swfoptions/). بشكل افتراضي، لا يتم تصدير الشرائح المخفية.

**كيف يمكنني التحكم في الضغط وحجم ملف SWF النهائي؟**

استخدم العلم [Compressed](https://reference.aspose.com/slides/net/aspose.slides.export/swfoptions/compressed/) (مفعل افتراضيًا) وقم بضبط [JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/swfoptions/jpegquality/) لتحقيق التوازن بين حجم الملف وجودة الصورة.

**ما هو الغرض من 'ViewerIncluded' ومتى ينبغي تعطيله؟**

[ViewerIncluded](https://reference.aspose.com/slides/net/aspose.slides.export/swfoptions/viewerincluded/) يضيف واجهة مستخدم مشغل مدمجة (عناصر تحكم التنقل، اللوحات، البحث). عطلها إذا كنت تخطط لاستخدام مشغل خاص بك أو تحتاج إلى إطار SWF بسيط بدون واجهة.

**ماذا يحدث إذا كان الخط الأصلي غير موجود على جهاز التصدير؟**

ستقوم Aspose.Slides باستبدال الخط المحدد عبر [DefaultRegularFont](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/defaultregularfont/) في [SwfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/) لتجنب الانتقال إلى خط بديل غير مقصود.