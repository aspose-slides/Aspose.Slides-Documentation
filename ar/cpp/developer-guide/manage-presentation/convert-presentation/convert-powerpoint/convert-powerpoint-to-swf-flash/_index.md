---
title: تحويل عروض PowerPoint إلى فلاش SWF في C++
linktitle: PowerPoint إلى SWF
type: docs
weight: 80
url: /ar/cpp/convert-powerpoint-to-swf-flash/
keywords:
- تحويل PowerPoint
- تحويل العرض
- تحويل الشريحة
- تحويل PPT
- تحويل PPTX
- PowerPoint إلى SWF
- العرض إلى SWF
- الشريحة إلى SWF
- PPT إلى SWF
- PPTX إلى SWF
- PowerPoint إلى فلاش
- العرض إلى فلاش
- الشريحة إلى فلاش
- PPT إلى فلاش
- PPTX إلى فلاش
- حفظ PPT كـ SWF
- حفظ PPTX كـ SWF
- تصدير PPT إلى SWF
- تصدير PPTX إلى SWF
- PowerPoint
- العرض
- C++
- Aspose.Slides
description: "تحويل PowerPoint (PPT/PPTX) إلى فلاش SWF في C++ باستخدام Aspose.Slides. عينات شفرة خطوة بخطوة، إخراج سريع عالي الجودة، دون أتمتة PowerPoint."
---

## **تحويل العروض التقديمية إلى فلاش**

يمكن استخدام الطريقة [Save](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) التي توفرها الفئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) لتحويل العرض التقديمي بالكامل إلى مستند SWF. يمكنك أيضًا تضمين التعليقات في ملف SWF المُنشأ باستخدام الفئة [SWFOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.swf_options) والواجهة [INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_notes_comments_layouting_options). يوضح المثال التالي كيفية تحويل عرض تقديمي إلى مستند SWF باستخدام الخيارات المتوفرة في فئة SWFOptions.
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


## **الأسئلة المتكررة**

**هل يمكنني تضمين الشرائح المخفية في ملف SWF؟**

نعم. استخدم الطريقة [set_ShowHiddenSlides](https://reference.aspose.com/slides/cpp/aspose.slides.export/swfoptions/set_showhiddenslides/) في الفئة [SwfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/swfoptions/). بشكل افتراضي، لا يتم تصدير الشرائح المخفية.

**كيف يمكنني التحكم في الضغط وحجم ملف SWF النهائي؟**

استخدم الطريقة [set_Compressed](https://reference.aspose.com/slides/cpp/aspose.slides.export/swfoptions/set_compressed/) واضبط [JPEG quality](https://reference.aspose.com/slides/cpp/aspose.slides.export/swfoptions/set_jpegquality/) لتحقيق التوازن بين حجم الملف وجودة الصورة.

**ما هدف 'set_ViewerIncluded' ومتى يجب استخدامه؟**

تضيف الطريقة [set_ViewerIncluded](https://reference.aspose.com/slides/cpp/aspose.slides.export/swfoptions/set_viewerincluded/) واجهة مستخدم مدمجة للمشغل (عناصر تحكم التنقل، اللوحات، البحث). عطلها إذا كنت تخطط لاستخدام مشغل خاص بك أو تحتاج إلى إطار SWF بسيط بدون واجهة.

**ماذا يحدث إذا كان الخط الأصلي غير موجود على جهاز التصدير؟**

ستستبدل Aspose.Slides الخط الذي تحدده عبر الطريقة [set_DefaultRegularFont](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_defaultregularfont/) في الفئة [SwfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/swfoptions/) لتجنب الاعتماد على خط احتياطي غير مقصود.