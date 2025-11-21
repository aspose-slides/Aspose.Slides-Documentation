---
title: تحويل عروض PowerPoint التقديمية إلى فلاش SWF في .NET
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
- حفظ PPT كـ SWF
- حفظ PPTX كـ SWF
- تصدير PPT إلى SWF
- تصدير PPTX إلى SWF
- PowerPoint
- العرض التقديمي
- .NET
- C#
- Aspose.Slides
description: "تحويل PowerPoint (PPT/PPTX) إلى فلاش SWF في .NET باستخدام Aspose.Slides. أمثلة كود C# خطوة بخطوة، إخراج سريع عالي الجودة، دون أتمتة PowerPoint."
---

## **تحويل العروض التقديمية إلى فلاش**

يمكن استخدام طريقة [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save/index) المعروضة بواسطة فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) لتحويل العرض التقديمي بالكامل إلى ملف SWF. يمكنك أيضًا تضمين التعليقات في ملف SWF المُولد باستخدام فئة [SWFOptions](https://reference.aspose.com/slides/net/aspose.slides.export/swfoptions) وواجهة [INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/inotescommentslayoutingoptions). يُظهر المثال التالي كيفية تحويل عرض تقديمي إلى ملف SWF باستخدام الخيارات المتوفرة في فئة SWFOptions.
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

نعم. قم بتمكين الخيار [ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/swfoptions/showhiddenslides/) في [SwfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/swfoptions/). بشكل افتراضي، لا يتم تصدير الشرائح المخفية.

**كيف يمكنني التحكم في الضغط وحجم ملف SWF النهائي؟**

استخدم علم [Compressed](https://reference.aspose.com/slides/net/aspose.slides.export/swfoptions/compressed/) (مُفعل افتراضيًا) واضبط [JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/swfoptions/jpegquality/) لتحقيق التوازن بين حجم الملف وجودة الصورة.

**ما هو الغرض من 'ViewerIncluded' ومتى يجب إيقاف تشغيله؟**

[ViewerIncluded](https://reference.aspose.com/slides/net/aspose.slides.export/swfoptions/viewerincluded/) يضيف واجهة مستخدم مشغل مدمج (عناصر تحكم التنقل، اللوحات، البحث). قم بإيقاف تشغيله إذا كنت تنوي استخدام مشغلك الخاص أو تحتاج إلى إطار SWF بسيط دون واجهة.

**ماذا يحدث إذا كان الخط المصدر غير موجود على جهاز التصدير؟**

ستقوم Aspose.Slides باستبدال الخط الذي تحدده عبر [DefaultRegularFont](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/defaultregularfont/) في [SwfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/) لتجنب اللجوء غير المقصود إلى خط بديل.