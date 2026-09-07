---
title: تحويل عروض PowerPoint إلى SWF Flash في Python عبر Java
linktitle: PowerPoint إلى SWF
type: docs
weight: 80
url: /ar/python-java/convert-powerpoint-to-swf-flash/
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
- PowerPoint إلى Flash
- العرض إلى Flash
- الشريحة إلى Flash
- PPT إلى Flash
- PPTX إلى Flash
- حفظ PPT كـ SWF
- حفظ PPTX كـ SWF
- تصدير PPT إلى SWF
- تصدير PPTX إلى SWF
- Python
- Java
- Aspose.Slides
description: تحويل عروض PowerPoint إلى SWF Flash في Python عبر Java باستخدام Aspose.Slides. تكوين العارض، الملاحظات، الشرائح المخفية، الضغط، والخطوط.
---
## **نظرة عامة**

Aspose.Slides for Python via Java يتيح لك تحويل عروض PowerPoint إلى SWF دون الحاجة إلى Microsoft PowerPoint. استخدم [Presentation.save](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#save) لتصدير العرض و[SwfOptions](https://reference.aspose.com/slides/ar/python-java/aspose.slides/swfoptions/) لتكوين إعدادات العارض وجودة الصورة وتخطيط الملاحظات أو التعليقات.

## **تحويل العروض إلى فلاش**

قم بتحميل الملف المصدر باستخدام [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/)، قم بتهيئة [SwfOptions](https://reference.aspose.com/slides/ar/python-java/aspose.slides/swfoptions/)، واحفظه باستخدام [SaveFormat.Swf](https://reference.aspose.com/slides/ar/python-java/aspose.slides/saveformat/#Swf).

المثال التالي يصدر `presentation.pptx` إلى `presentation.swf`. يقوم بتعطيل العارض المدمج عبر [setViewerIncluded](https://reference.aspose.com/slides/ar/python-java/aspose.slides/swfoptions/#setViewerIncluded) ويضمّن ملاحظات المتحدث أسفل الشرائح باستخدام [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ar/python-java/aspose.slides/notescommentslayoutingoptions/).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NotesCommentsLayoutingOptions, NotesPositions, Presentation, SaveFormat, SwfOptions

presentation = Presentation("presentation.pptx")
try:
    layout_options = NotesCommentsLayoutingOptions()
    layout_options.setNotesPosition(NotesPositions.BottomFull)

    swf_options = SwfOptions()
    swf_options.setViewerIncluded(False)
    swf_options.setSlidesLayoutOptions(layout_options)

    presentation.save("presentation.swf", SaveFormat.Swf, swf_options)
finally:
    presentation.dispose()
```

قبل تشغيل المثال، [install Aspose.Slides for Python via Java](/slides/ar/python-java/installation/) وضع `presentation.pptx` في دليل العمل. يتم تشغيل JVM مرة واحدة لكل عملية Python.

يطبق المثال [NotesPositions.BottomFull](https://reference.aspose.com/slides/ar/python-java/aspose.slides/notespositions/#BottomFull) عبر [setNotesPosition](https://reference.aspose.com/slides/ar/python-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition) ويمرّر التخطيط إلى [SwfOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/ar/python-java/aspose.slides/swfoptions/#setSlidesLayoutOptions). لتضمين التعليقات أيضًا، قم بتكوين [NotesCommentsLayoutingOptions.setCommentsPosition](https://reference.aspose.com/slides/ar/python-java/aspose.slides/notescommentslayoutingoptions/#setCommentsPosition) قبل التصدير.

## **الأسئلة الشائعة**

**هل يمكنني تضمين الشرائح المخفية في ملف SWF؟**

نعم. استدعِ [SwfOptions.setShowHiddenSlides](https://reference.aspose.com/slides/ar/python-java/aspose.slides/swfoptions/#setShowHiddenSlides) مع `True`. بشكل افتراضي، لا يتم تصدير الشرائح المخفية.

**كيف يمكنني التحكم في الضغط وحجم ملف SWF النهائي؟**

استخدم [SwfOptions.setCompressed](https://reference.aspose.com/slides/ar/python-java/aspose.slides/swfoptions/#setCompressed) لتمكين أو تعطيل الضغط و[SwfOptions.setJpegQuality](https://reference.aspose.com/slides/ar/python-java/aspose.slides/swfoptions/#setJpegQuality) لضبط جودة صورة JPEG. جودة JPEG منخفضة يمكن أن تقلل حجم الملف على حساب دقة الصورة.

**ما هو الغرض من العارض المدمج ومتى يجب تعطيله؟**

[SwfOptions.setViewerIncluded](https://reference.aspose.com/slides/ar/python-java/aspose.slides/swfoptions/#setViewerIncluded) يتحكم فيما إذا كان الـ SWF المتولد يتضمن العارض. مرّر `False` عندما تحتاج إلى الشرائح المصدرة بدون العارض المدمج، كما هو موضح في المثال أعلاه.

**ماذا يحدث إذا كان الخط الأصلي غير موجود على جهاز التصدير؟**

يمكنك تحديد خط عادي افتراضي باستخدام [setDefaultRegularFont](https://reference.aspose.com/slides/ar/python-java/aspose.slides/saveoptions/#setDefaultRegularFont)، والذي يُورث إلى [SwfOptions](https://reference.aspose.com/slides/ar/python-java/aspose.slides/swfoptions/). اختر خطًا متاحًا لعملية التصدير؛ قد تؤدي استبدالات الخط إلى تغيير مظهر النص وتخطيطه.