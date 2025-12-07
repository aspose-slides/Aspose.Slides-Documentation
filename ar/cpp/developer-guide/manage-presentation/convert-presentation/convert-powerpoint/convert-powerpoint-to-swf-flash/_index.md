---
title: تحويل عروض PowerPoint إلى فلاش SWF باستخدام C++
linktitle: PowerPoint إلى SWF
type: docs
weight: 80
url: /ar/cpp/convert-powerpoint-to-swf-flash/
keywords:
- تحويل PowerPoint
- تحويل عرض تقديمي
- تحويل شريحة
- تحويل PPT
- تحويل PPTX
- PowerPoint إلى SWF
- عرض تقديمي إلى SWF
- شريحة إلى SWF
- PPT إلى SWF
- PPTX إلى SWF
- PowerPoint إلى فلاش
- عرض تقديمي إلى فلاش
- شريحة إلى فلاش
- PPT إلى فلاش
- PPTX إلى فلاش
- حفظ PPT كـ SWF
- حفظ PPTX كـ SWF
- تصدير PPT إلى SWF
- تصدير PPTX إلى SWF
- PowerPoint
- عرض تقديمي
- C++
- Aspose.Slides
description: "تحويل PowerPoint (PPT/PPTX) إلى فلاش SWF باستخدام C++ و Aspose.Slides. عينات شفرة خطوة بخطوة، إخراج سريع وعالي الجودة، بدون أتمتة PowerPoint."
---

## **تحويل العروض التقديمية إلى فلاش**

يمكن استخدام طريقة [Save](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) المعروضة من فئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) لتحويل كامل العرض التقديمي إلى مستند SWF. يمكنك أيضًا تضمين التعليقات في ملف SWF المُولد باستخدام فئة [SWFOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.swf_options) وواجهة [INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_notes_comments_layouting_options). المثال التالي يوضح كيفية تحويل عرض تقديمي إلى مستند SWF باستخدام الخيارات التي توفرها فئة SWFOptions.
```cpp
// مسار دليل المستندات.
    System::String dataDir = GetDataPath();

    // إنشاء كائن Presentation الذي يمثل ملف عرض تقديمي
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


## **الأسئلة الشائعة**

**هل يمكنني تضمين الشرائح المخفية في ملف SWF؟**

نعم. استخدم طريقة [set_ShowHiddenSlides](https://reference.aspose.com/slides/cpp/aspose.slides.export/swfoptions/set_showhiddenslides/) في فئة [SwfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/swfoptions/). بشكل افتراضي، لا يتم تصدير الشرائح المخفية.

**كيف يمكنني التحكم في الضغط وحجم ملف SWF النهائي؟**

استخدم طريقة [set_Compressed](https://reference.aspose.com/slides/cpp/aspose.slides.export/swfoptions/set_compressed/) واضبط [JPEG quality](https://reference.aspose.com/slides/cpp/aspose.slides.export/swfoptions/set_jpegquality/) لتحقيق التوازن بين حجم الملف ودقة الصور.

**ما هو الغرض من 'set_ViewerIncluded' ومتى يجب عليّ استخدامه؟**

تضيف طريقة [set_ViewerIncluded](https://reference.aspose.com/slides/cpp/aspose.slides.export/swfoptions/set_viewerincluded/) واجهة مستخدم مشغٍّ مدمجة (أدوات التنقل، اللوحات، البحث). عطلها إذا كنت تخطط لاستخدام مشغٍّ خاص بك أو تحتاج إلى إطار SWF بسيط دون واجهة.

**ماذا يحدث إذا كان خط المصدر غير موجود على جهاز التصدير؟**

سيستبدل Aspose.Slides الخط الذي تحدده عبر [set_DefaultRegularFont](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_defaultregularfont/) في فئة [SwfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/swfoptions/) لتجنب الاعتماد على خط بديل غير مقصود.