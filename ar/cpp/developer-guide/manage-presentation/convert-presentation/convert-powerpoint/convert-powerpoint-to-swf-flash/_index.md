---
title: تحويل PowerPoint إلى SWF فلاش
type: docs
weight: 80
url: /ar/cpp/convert-powerpoint-to-swf-flash/
keywords: "PPT، PPTX إلى SWF"
description: "تحويل PowerPoint PPT، PPTX إلى صيغة SWF فلاش باستخدام واجهة برمجة تطبيقات Aspose.Slides."
---

يمكن استخدام طريقة [Save](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) التي تعرضها [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) لتحويل العرض التقديمي بالكامل إلى مستند SWF. يمكنك أيضًا تضمين التعليقات في SWF المُنتَج باستخدام [SWFOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.swf_options) وواجهة [INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_notes_comments_layouting_options). يوضح المثال التالي كيفية تحويل عرض تقديمي إلى مستند SWF باستخدام الخيارات المقدمة من فئة SWFOptions.

``` cpp
// المسار إلى دليل المستندات.
    System::String dataDir = GetDataPath();

    // إنشاء كائن Presentation يُمثل ملف عرض تقديمي
    auto presentation = System::MakeObject<Presentation>(dataDir + u"HelloWorld.pptx");

    auto swfOptions = System::MakeObject<SwfOptions>();
    swfOptions->set_ViewerIncluded(false);

    auto notesOptions = swfOptions->get_NotesCommentsLayouting();
    notesOptions->set_NotesPosition(NotesPositions::BottomFull);

    // حفظ صفحات العرض التقديمي والملاحظات
    presentation->Save(dataDir + u"SaveAsSwf_out.swf", SaveFormat::Swf, swfOptions);
    swfOptions->set_ViewerIncluded(true);
    presentation->Save(dataDir + u"SaveNotes_out.swf", SaveFormat::Swf, swfOptions);
```