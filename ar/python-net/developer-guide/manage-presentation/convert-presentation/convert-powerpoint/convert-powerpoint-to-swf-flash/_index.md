---
title: تحويل عروض PowerPoint إلى فلاش SWF في Python
linktitle: PowerPoint إلى فلاش SWF
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
description: "تحويل PowerPoint (PPT/PPTX) إلى فلاش SWF في Python باستخدام Aspose.Slides. أمثلة شفرة خطوة بخطوة، إخراج سريع عالي الجودة، دون أتمتة PowerPoint."
---

## **تحويل العروض التقديمية إلى فلاش**

يمكن استخدام طريقة [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) التي يوفرها صف [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) لتحويل العرض التقديمي بالكامل إلى مستند SWF. يمكنك أيضًا تضمين التعليقات في ملف SWF المُنشأ باستخدام صف [SWFOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/swfoptions/) وصف [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/notescommentslayoutingoptions/). يوضح المثال التالي كيفية تحويل عرض تقديمي إلى مستند SWF باستخدام الخيارات المتاحة في صف SWFOptions.
```py
import aspose.slides as slides

# إنشاء كائن Presentation الذي يمثل ملف عرض تقديمي
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

نعم. فعّل الخيار [show_hidden_slides](https://reference.aspose.com/slides/python-net/aspose.slides.export/swfoptions/show_hidden_slides/) في صف [SwfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/swfoptions/). بشكل افتراضي، لا يتم تصدير الشرائح المخفية.

**كيف يمكنني التحكم في الضغط وحجم ملف SWF النهائي؟**

استخدم علامة [compressed](https://reference.aspose.com/slides/python-net/aspose.slides.export/swfoptions/compressed/) (مفعلة افتراضيًا) وقم بضبط [jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/swfoptions/jpeg_quality/) لتحقيق التوازن بين حجم الملف وجودة الصورة.

**ما الغرض من 'viewer_included' ومتى يجب إيقافه؟**

يضيف [viewer_included](https://reference.aspose.com/slides/python-net/aspose.slides.export/swfoptions/viewer_included/) واجهة مشغل مدمجة (عناصر تحكم التنقل، الألواح، البحث). قم بإيقافه إذا كنت تخطط لاستخدام مشغل خاص بك أو إذا كنت بحاجة إلى إطار SWF بسيط بدون واجهة.

**ماذا يحدث إذا كان خط المصدر مفقودًا على جهاز التصدير؟**

ستقوم Aspose.Slides باستبدال الخط الذي تحدده عبر [default_regular_font](https://reference.aspose.com/slides/python-net/aspose.slides.export/swfoptions/default_regular_font/) في صف [SwfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/swfoptions/) لتجنب الانتقال غير المقصود إلى خط بديل.