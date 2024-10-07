---
title: تحويل PowerPoint إلى SWF فلاش
type: docs
weight: 80
url: /python-net/convert-powerpoint-to-swf-flash/
keywords: "تحويل PowerPoint, عرض تقديمي, PowerPoint إلى SWF, فلاش SWF PPT إلى SWF, PPTX إلى SWF, بايثون"
description: "تحويل عرض PowerPoint التقديمي إلى SWF فلاش في بايثون"
---

يمكن استخدام [Save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) لأسلوب الذي توفره [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) لتحويل العرض التقديمي بالكامل إلى مستند SWF. يمكنك أيضًا تضمين التعليقات في SWF المُولد باستخدام [SWFOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/swfoptions/) و [INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/inotescommentslayoutingoptions/) واجهة. المثال التالي يوضح كيفية تحويل عرض تقديمي إلى مستند SWF باستخدام الخيارات التي توفرها فئة SWFOptions.

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