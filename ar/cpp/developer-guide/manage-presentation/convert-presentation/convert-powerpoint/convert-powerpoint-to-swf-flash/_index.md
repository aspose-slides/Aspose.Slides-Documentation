---
title: تحويل عروض PowerPoint التقديمية إلى SWF Flash باستخدام C++
linktitle: PowerPoint إلى SWF
type: docs
weight: 80
url: /ar/cpp/convert-powerpoint-to-swf-flash/
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
- C++
- Aspose.Slides
description: "تحويل PowerPoint (PPT/PPTX) إلى SWF Flash باستخدام C++ و Aspose.Slides. أمثلة شفرة خطوة بخطوة، إخراج سريع وعالي الجودة، بدون أتمتة PowerPoint."
---

## **تحويل العروض إلى فلاش**

يمكن استخدام طريقة [Save](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) التي توفرها فئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) لتحويل العرض التقديمي بالكامل إلى مستند SWF. يمكنك أيضًا تضمين التعليقات في ملف SWF المُنشأ باستخدام فئة [SWFOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.swf_options) وفئة [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/notescommentslayoutingoptions/) . يوضح المثال التالي كيفية تحويل عرض تقديمي إلى مستند SWF باستخدام الخيارات المتوفرة في فئة SWFOptions.
``` cpp
// مسار دليل المستندات.
    System::String dataDir = GetDataPath();

    // إنشاء كائن Presentation يمثل ملف عرض تقديمي
    auto presentation = System::MakeObject<Presentation>(dataDir + u"HelloWorld.pptx");

    auto swfOptions = System::MakeObject<SwfOptions>();
    swfOptions->set_ViewerIncluded(false);

    auto notesOptions = swfOptions->get_NotesCommentsLayouting();
    notesOptions->set_NotesPosition(NotesPositions::BottomFull);

    // حفظ العرض التقديمي وصفحات الملاحظات
    presentation->Save(dataDir + u"SaveAsSwf_out.swf", SaveFormat::Swf, swfOptions);
    swfOptions->set_ViewerIncluded(true);
    presentation->Save(dataDir + u"SaveNotes_out.swf", SaveFormat::Swf, swfOptions);
```


## **FAQ**

**هل يمكنني تضمين الشرائح المخفية في ملف SWF؟**

نعم. استخدم طريقة [set_ShowHiddenSlides](https://reference.aspose.com/slides/cpp/aspose.slides.export/swfoptions/set_showhiddenslides/) في فئة [SwfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/swfoptions/). بشكل افتراضي، لا يتم تصدير الشرائح المخفية.

**كيف يمكنني التحكم في الضغط وحجم ملف SWF النهائي؟**

استخدم طريقة [set_Compressed](https://reference.aspose.com/slides/cpp/aspose.slides.export/swfoptions/set_compressed/) واضبط [JPEG quality](https://reference.aspose.com/slides/cpp/aspose.slides.export/swfoptions/set_jpegquality/) لتحقيق التوازن بين حجم الملف وجودة الصورة.

**ما هو الغرض من 'set_ViewerIncluded' ومتى ينبغي استخدامه؟**

تضيف [set_ViewerIncluded](https://reference.aspose.com/slides/cpp/aspose.slides.export/swfoptions/set_viewerincluded/) واجهة تشغيل مدمجة (عناصر تحكم تنقل، لوحات، بحث). قم بتعطيله إذا كنت تخطط لاستخدام مشغل خاص بك أو تحتاج إلى إطار SWF بسيط دون واجهة مستخدم.

**ماذا يحدث إذا كان الخط الأصلي غير متوفر على جهاز التصدير؟**

سوف يقوم Aspose.Slides باستبدال الخط الذي تحدده عبر [set_DefaultRegularFont](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_defaultregularfont/) في فئة [SwfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/swfoptions/) لتجنب الانتقال إلى خط افتراضي غير مقصود.