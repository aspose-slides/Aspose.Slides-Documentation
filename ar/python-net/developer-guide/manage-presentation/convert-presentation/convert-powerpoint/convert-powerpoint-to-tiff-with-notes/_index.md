---
title: تحويل عروض PowerPoint إلى تنسيق TIFF مع الملاحظات باستخدام بايثون
linktitle: PowerPoint إلى TIFF مع الملاحظات
type: docs
weight: 100
url: /ar/python-net/convert-powerpoint-to-tiff-with-notes/
keywords:
- تحويل PowerPoint
- تحويل العرض التقديمي
- تحويل الشريحة
- تحويل PPT
- تحويل PPTX
- PowerPoint إلى TIFF
- العرض التقديمي إلى TIFF
- الشريحة إلى TIFF
- PPT إلى TIFF
- PPTX إلى TIFF
- PowerPoint مع الملاحظات
- العرض التقديمي مع الملاحظات
- الشريحة مع الملاحظات
- PPT مع الملاحظات
- PPTX مع الملاحظات
- TIFF مع الملاحظات
- Python
- Aspose.Slides
description: "تحويل عروض PowerPoint إلى تنسيق TIFF مع الملاحظات باستخدام Aspose.Slides for Python via .NET. تعلم كيفية تصدير الشرائح مع ملاحظات المتحدث بفعالية."
---

## **نظرة عامة**

Aspose.Slides for Python via .NET توفر حلاً بسيطاً لتحويل عروض PowerPoint وOpenDocument (PPT، PPTX، وODP) مع الملاحظات إلى تنسيق TIFF. يُستخدم هذا التنسيق على نطاق واسع لتخزين الصور عالية الجودة، والطباعة، وأرشفة المستندات. باستخدام Aspose.Slides، يمكنك ليس فقط تصدير العروض الكاملة مع ملاحظات المتحدث بل أيضًا إنشاء صور مصغرة للشرائح في عرض ملاحظات الشريحة. عملية التحويل بسيطة وفعّالة، حيث تُستَخدم طريقة `save` الخاصة بفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) لتحويل العرض بالكامل إلى سلسلة من صور TIFF مع الحفاظ على الملاحظات والتنسيق.

## **تحويل عرض تقديمي إلى TIFF مع الملاحظات**

حفظ عرض PowerPoint أو OpenDocument إلى TIFF مع الملاحظات باستخدام Aspose.Slides for Python via .NET يتضمن الخطوات التالية:

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/): تحميل ملف PowerPoint أو OpenDocument.  
2. تكوين خيارات تخطيط الخرج: استخدم فئة [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/notescommentslayoutingoptions/) لتحديد كيفية عرض الملاحظات والتعليقات.  
3. حفظ العرض بصيغة TIFF: مرّر الخيارات المُكوَّنة إلى طريقة [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/#str-asposeslidesexportsaveformat-asposeslidesexportisaveoptions).

لنفترض أن لدينا ملفًا باسم "speaker_notes.pptx" يحتوي على الشريحة التالية:

![شريحة العرض التقديمي مع ملاحظات المتحدث](slide_with_notes.png)

المقتطع البرمجي أدناه يوضح كيفية تحويل العرض إلى صورة TIFF في عرض ملاحظات الشريحة باستخدام خاصية [slides_layout_options](https://reference.aspose.com/slides/python-net/aspose.slides.export/tiffoptions/slides_layout_options/):

```py
# إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
with slides.Presentation("speaker_notes.pptx") as presentation:
    
    notes_options = slides.export.NotesCommentsLayoutingOptions()
    notes_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL  # عرض الملاحظات أسفل الشريحة.
    
    # تكوين خيارات TIFF مع ترتيب الملاحظات.
    tiff_options = slides.export.TiffOptions()
    tiff_options.dpi_x = 300
    tiff_options.dpi_y = 300
    tiff_options.slides_layout_options = notes_options
    
    # حفظ العرض التقديمي إلى TIFF مع ملاحظات المتحدث.
    presentation.save("TIFF_with_notes.tiff", slides.export.SaveFormat.TIFF, tiff_options)
```

النتيجة:

![صورة TIFF مع ملاحظات المتحدث](TIFF_with_notes.png)

{{% alert title="Tip" color="primary" %}}

Check out Aspose [Free PowerPoint to Poster Converter](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online).

{{% /alert %}}

## **الأسئلة المتكررة**

**هل يمكنني التحكم في موضع منطقة الملاحظات في ملف TIFF الناتج؟**

نعم. استخدم [إعدادات تخطيط الملاحظات](https://reference.aspose.com/slides/python-net/aspose.slides.export/tiffoptions/slides_layout_options/) لاختيار أحد الخيارات مثل `NONE`، `BOTTOM_TRUNCATED`، أو `BOTTOM_FULL`، والتي تُخفي الملاحظات، أو تُلائمها في صفحة واحدة، أو تسمح لها بالانتشار إلى صفحات إضافية على التوالي.

**كيف يمكنني تقليل حجم ملف TIFF مع الملاحظات دون فقدان واضح في الجودة؟**

اختر [ضغطًا فعالًا](https://reference.aspose.com/slides/python-net/aspose.slides.export/tiffoptions/compression_type/) (مثل `LZW` أو `RLE`)، عيّن DPI معقول، وإذا كان مقبولًا، استخدم [تنسيق بكسل](https://reference.aspose.com/slides/python-net/aspose.slides.export/tiffoptions/pixel_format/) أقل (مثل 8 بت أو 1 بت للون أحادي). يمكن أيضًا تقليل [أبعاد الصورة](https://reference.aspose.com/slides/python-net/aspose.slides.export/tiffoptions/image_size/) قليلًا دون أن يؤثر ذلك بشكل ملحوظ على وضوح القراءة.

**هل يؤثر الخط في الملاحظات على النتيجة إذا كانت الخطوط الأصلية مفقودة من النظام؟**

نعم. الخطوط المفقودة تُ triggers [الاستبدال](/slides/ar/python-net/font-selection-sequence/)، مما قد يغيّر مقاييس النص ومظهره. لتجنب ذلك، [قم بتوفير الخطوط المطلوبة](/slides/ar/python-net/custom-font/) أو عيّن [خط احتياطي افتراضي](/slides/ar/python-net/fallback-font/) حتى تُستخدم الخطوط المقصودة.