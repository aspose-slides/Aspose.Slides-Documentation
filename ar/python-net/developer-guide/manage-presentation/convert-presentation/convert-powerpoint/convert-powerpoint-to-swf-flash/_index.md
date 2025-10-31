---
title: تحويل عروض PowerPoint التقديمية إلى SWF فلاش في Python
linktitle: PowerPoint إلى SWF فلاش
type: docs
weight: 80
url: /ar/python-net/convert-powerpoint-to-swf-flash/
keywords:
- تحويل PowerPoint
- تحويل العرض التقديمي
- تحويل الشريحة
- PowerPoint إلى SWF
- العرض التقديمي إلى SWF
- الشريحة إلى SWF
- PPT إلى SWF
- PPTX إلى SWF
- PowerPoint
- العرض التقديمي
- Python
- Aspose.Slides
description: "تحويل PowerPoint (PPT/PPTX) إلى SWF فلاش باستخدام Python و Aspose.Slides. أمثلة شفرة خطوة بخطوة، إخراج سريع عالي الجودة، بدون أتمتة PowerPoint."
---

## **تحويل العروض التقديمية إلى فلاش**

يمكن استخدام طريقة [Save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) المعروضة من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) لتحويل العرض التقديمي بالكامل إلى مستند SWF. يمكنك أيضًا تضمين التعليقات في ملف SWF المُولد باستخدام فئة [SWFOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/swfoptions/) وواجهة [INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/inotescommentslayoutingoptions/). يوضح المثال التالي كيفية تحويل عرض تقديمي إلى ملف SWF باستخدام الخيارات المتوفرة في فئة SWFOptions.

```py
import aspose.slides as slides

# إنشاء كائن Presentation يمثل ملف عرض تقديمي
presentation = slides.Presentation("pres.pptx")

swfOptions = slides.export.SwfOptions()
swfOptions.viewer_included = False
swfOptions.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL

# حفظ العرض التقديمي وصفحات الملاحظات
presentation.save("SaveAsSwf_out.swf", slides.export.SaveFormat.SWF, swfOptions)
swfOptions.viewer_included = True
presentation.save("SaveNotes_out.swf", slides.export.SaveFormat.SWF, swfOptions)
```

## **الأسئلة المتكررة**

**هل يمكنني تضمين الشرائح المخفية في ملف SWF؟**

نعم. فعّل خيار [show_hidden_slides](https://reference.aspose.com/slides/python-net/aspose.slides.export/swfoptions/show_hidden_slides/) في [SwfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/swfoptions/). بشكل افتراضي، لا يتم تصدير الشرائح المخفية.

**كيف يمكنني التحكم في الضغط وحجم ملف SWF النهائي؟**

استخدم علامة [compressed](https://reference.aspose.com/slides/python-net/aspose.slides.export/swfoptions/compressed/) (مفعلة افتراضياً) وضبط [jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/swfoptions/jpeg_quality/) لتحقيق توازن بين حجم الملف وجودة الصورة.

**ما الغرض من ’viewer_included‘ ومتى يجب تعطيله؟**

[viewer_included](https://reference.aspose.com/slides/python-net/aspose.slides.export/swfoptions/viewer_included/) يضيف واجهة تشغيل مدمجة (ضوابط التنقل، اللوحات، البحث). عطلها إذا كنت تخطط لاستخدام مشغّلك الخاص أو تحتاج إلى إطار SWF خالٍ من واجهة المستخدم.

**ماذا يحدث إذا كان خط المصدر مفقوداً على جهاز التصدير؟**

ستستبدل Aspose.Slides الخط الذي تحدده عبر [default_regular_font](https://reference.aspose.com/slides/python-net/aspose.slides.export/swfoptions/default_regular_font/) في [SwfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/swfoptions/) لتجنب الاعتماد غير المقصود على خط بديل.