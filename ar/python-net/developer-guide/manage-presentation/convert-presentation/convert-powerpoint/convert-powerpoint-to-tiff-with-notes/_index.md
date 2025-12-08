---
title: تحويل عروض PowerPoint إلى TIFF مع الملاحظات في Python
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
description: "تحويل عروض PowerPoint إلى TIFF مع الملاحظات باستخدام Aspose.Slides لـ Python عبر .NET. تعلم كيفية تصدير الشرائح مع ملاحظات المتحدث بفعالية."
---

## **نظرة عامة**

Aspose.Slides for Python via .NET يوفر حلاً بسيطاً لتحويل عروض PowerPoint وOpenDocument (PPT وPPTX وODP) مع الملاحظات إلى تنسيق TIFF. يُستخدم هذا التنسيق على نطاق واسع لتخزين الصور عالية الجودة، والطباعة، وأرشفة المستندات. مع Aspose.Slides، يمكنك ليس فقط تصدير العروض بالكامل مع ملاحظات المتحدث بل أيضاً إنشاء صور مصغرة للشرائح في وضع ملاحظات الشريحة. عملية التحويل بسيطة وفعّالة، باستخدام طريقة `save` من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) لتحويل العرض بالكامل إلى سلسلة من صور TIFF مع الحفاظ على الملاحظات والتخطيط.

## **تحويل عرض تقديمي إلى TIFF مع الملاحظات**

حفظ عرض PowerPoint أو OpenDocument إلى TIFF مع الملاحظات باستخدام Aspose.Slides for Python via .NET يتضمن الخطوات التالية:

1. إنشاء كائن الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/): تحميل ملف PowerPoint أو OpenDocument.  
2. تكوين خيارات تخطيط الإخراج: استخدم الفئة [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/notescommentslayoutingoptions/) لتحديد طريقة عرض الملاحظات والتعليقات.  
3. حفظ العرض إلى TIFF: مرّر الخيارات التي تم تكوينها إلى طريقة [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/#str-asposeslidesexportsaveformat-asposeslidesexportisaveoptions).

لنفترض أن لدينا ملف "speaker_notes.pptx" يحتوي على الشريحة التالية:

![The presentation slide with speaker notes](slide_with_notes.png)

المقتطف البرمجي أدناه يوضح كيفية تحويل العرض إلى صورة TIFF في وضع ملاحظات الشريحة باستخدام الخاصية [slides_layout_options](https://reference.aspose.com/slides/python-net/aspose.slides.export/tiffoptions/slides_layout_options/).
```py
# إنشاء فئة Presentation التي تمثل ملف عرض تقديمي.
with slides.Presentation("speaker_notes.pptx") as presentation:
    
    notes_options = slides.export.NotesCommentsLayoutingOptions()
    notes_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL  # عرض الملاحظات أسفل الشريحة.
    
    # تكوين خيارات TIFF مع تخطيط الملاحظات.
    tiff_options = slides.export.TiffOptions()
    tiff_options.dpi_x = 300
    tiff_options.dpi_y = 300
    tiff_options.slides_layout_options = notes_options
    
    # حفظ العرض تقديمي إلى TIFF مع ملاحظات المتحدث.
    presentation.save("TIFF_with_notes.tiff", slides.export.SaveFormat.TIFF, tiff_options)
```


النتيجة:

![The TIFF image with speaker notes](TIFF_with_notes.png)

{{% alert title="Tip" color="primary" %}}
تحقق من أداة Aspose **Free PowerPoint to Poster Converter** عبر الرابط التالي: [Free PowerPoint to Poster Converter](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **الأسئلة الشائعة**

**هل يمكنني التحكم في موضع منطقة الملاحظات في ملف TIFF الناتج؟**

نعم. استخدم [notes layout settings](https://reference.aspose.com/slides/python-net/aspose.slides.export/tiffoptions/slides_layout_options/) للاختيار بين الخيارات مثل `NONE` أو `BOTTOM_TRUNCATED` أو `BOTTOM_FULL`، والتي على التوالي تخفي الملاحظات، أو تلائمها في صفحة واحدة، أو تسمح لها بالانتقال إلى صفحات إضافية.

**كيف يمكنني تقليل حجم ملف TIFF مع الملاحظات دون فقد واضح في الجودة؟**

اختر [efficient compression](https://reference.aspose.com/slides/python-net/aspose.slides.export/tiffoptions/compression_type/) (مثل `LZW` أو `RLE`)، وحدد DPI معقول، وإذا كان مقبولاً، استخدم [pixel format](https://reference.aspose.com/slides/python-net/aspose.slides.export/tiffoptions/pixel_format/) أقل (مثل 8 bpp أو 1 bpp للصور أحادية اللون). يمكن أيضاً تقليل [image dimensions](https://reference.aspose.com/slides/python-net/aspose.slides.export/tiffoptions/image_size/) قليلاً دون أن يؤثر ملحوظاً على قابلية القراءة.

**هل يؤثر الخط في الملاحظات على النتيجة إذا كانت الخطوط الأصلية غير موجودة على النظام؟**

نعم. الخطوط المفقودة تُفَعِّل [substitution](/slides/ar/python-net/font-selection-sequence/)، مما قد يغيّر أبعاد النص ومظهره. لتجنب ذلك، قم بـ [supply the required fonts](/slides/ar/python-net/custom-font/) أو اضبط [fallback font](/slides/ar/python-net/fallback-font/) افتراضيًا حتى تُستخدم الخطوط المقصودة.