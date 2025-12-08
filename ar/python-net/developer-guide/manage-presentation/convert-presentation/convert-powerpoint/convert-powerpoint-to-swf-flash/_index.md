---
title: تحويل عروض PowerPoint إلى SWF Flash في Python
linktitle: PowerPoint إلى SWF Flash
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
description: "تحويل PowerPoint (PPT/PPTX) إلى SWF Flash في Python باستخدام Aspose.Slides. أمثلة شفرة خطوة بخطوة، مخرجات سريعة وعالية الجودة، دون الحاجة إلى أتمتة PowerPoint."
---

## **Convert Presentations to Flash**

يمكن استخدام طريقة Save المعروضة في الفئة Presentation لتحويل العرض التقديمي بالكامل إلى مستند SWF. يمكنك أيضًا تضمين التعليقات في ملف SWF المُولد باستخدام الفئة SWFOptions والواجهة INotesCommentsLayoutingOptions. يظهر المثال التالي كيفية تحويل عرض تقديمي إلى مستند SWF باستخدام الخيارات التي توفرها الفئة SWFOptions.
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


## **FAQ**

**Can I include hidden slides in the SWF?**

نعم. قم بتمكين الخيار [show_hidden_slides](https://reference.aspose.com/slides/python-net/aspose.slides.export/swfoptions/show_hidden_slides/) في الفئة [SwfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/swfoptions/). بشكل افتراضي، لا يتم تصدير الشرائح المخفية.

**How can I control compression and the final SWF size?**

استخدم علامة [compressed](https://reference.aspose.com/slides/python-net/aspose.slides.export/swfoptions/compressed/) (مفعلة بشكل افتراضي) وقم بضبط [jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/swfoptions/jpeg_quality/) لتحقيق التوازن بين حجم الملف ودقة الصورة.

**What is 'viewer_included' for, and when should I disable it?**

[viewer_included](https://reference.aspose.com/slides/python-net/aspose.slides.export/swfoptions/viewer_included/) يضيف واجهة مستخدم مشغل مدمجة (عناصر تحكم التنقل، اللوحات، البحث). عطلها إذا كنت تنوي استخدام مشغل خاص بك أو تحتاج إلى إطار SWF بسيط بدون واجهة مستخدم.

**What happens if a source font is missing on the export machine?**

ستقوم Aspose.Slides باستبدال الخط الذي تحدده عبر [default_regular_font](https://reference.aspose.com/slides/python-net/aspose.slides.export/swfoptions/default_regular_font/) في الفئة [SwfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/swfoptions/) لتجنب الانتقال إلى خط بديل غير مقصود.