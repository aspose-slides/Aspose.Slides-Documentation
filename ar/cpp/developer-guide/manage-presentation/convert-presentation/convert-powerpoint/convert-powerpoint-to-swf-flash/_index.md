---
title: تحويل عروض PowerPoint إلى فلاش SWF في C++
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
- PowerPoint إلى فلاش
- العرض التقديمي إلى فلاش
- الشريحة إلى فلاش
- PPT إلى فلاش
- PPTX إلى فلاش
- حفظ PPT كـ SWF
- حفظ PPTX كـ SWF
- تصدير PPT إلى SWF
- تصدير PPTX إلى SWF
- PowerPoint
- العرض التقديمي
- C++
- Aspose.Slides
description: "تحويل PowerPoint (PPT/PPTX) إلى فلاش SWF في C++ باستخدام Aspose.Slides. عينات شفرة خطوة بخطوة، إخراج سريع وعالي الجودة، دون أتمتة PowerPoint."
---

## **تحويل العروض التقديمية إلى فلاش**

يمكن استخدام طريقة [Save](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) التي يوفرها صنف [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) لتحويل العرض التقديمي بالكامل إلى مستند SWF. يمكنك أيضًا تضمين التعليقات في ملف SWF المُولد باستخدام صنف [SWFOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.swf_options) وواجهة [INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_notes_comments_layouting_options). يوضح المثال التالي كيفية تحويل عرض تقديمي إلى مستند SWF باستخدام الخيارات التي يوفرها صنف SWFOptions.
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


## **أسئلة شائعة**

**هل يمكنني تضمين الشرائح المخفية في ملف SWF؟**

نعم. استخدم طريقة [set_ShowHiddenSlides](https://reference.aspose.com/slides/cpp/aspose.slides.export/swfoptions/set_showhiddenslides/) في [SwfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/swfoptions/). بشكل افتراضي، لا يتم تصدير الشرائح المخفية.

**كيف يمكنني التحكم في الضغط وحجم ملف SWF النهائي؟**

استخدم طريقة [set_Compressed](https://reference.aspose.com/slides/cpp/aspose.slides.export/swfoptions/set_compressed/) واضبط [JPEG quality](https://reference.aspose.com/slides/cpp/aspose.slides.export/swfoptions/set_jpegquality/) لتحقيق توازن بين حجم الملف وجودة الصورة.

**ما هو هدف 'set_ViewerIncluded' ومتى يجب استخدامه؟**

يضيف [set_ViewerIncluded](https://reference.aspose.com/slides/cpp/aspose.slides.export/swfoptions/set_viewerincluded/) واجهة مستخدم مدمجة للمشغل (أدوات تنقل، لوحات، بحث). عطلها إذا كنت تنوي استخدام مشغلك الخاص أو تحتاج إلى إطار SWF بسيط بدون واجهة.

**ماذا يحدث إذا كان خط المصدر غير موجود على جهاز التصدير؟**

سيستبدل Aspose.Slides الخط المحدد عبر [set_DefaultRegularFont](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_defaultregularfont/) في [SwfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/swfoptions/) لتجنب الانتقال إلى خط بديل غير مقصود.