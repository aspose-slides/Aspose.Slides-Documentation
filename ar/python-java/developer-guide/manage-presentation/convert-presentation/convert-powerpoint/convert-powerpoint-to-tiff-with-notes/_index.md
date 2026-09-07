---
title: تحويل عروض PowerPoint إلى TIFF مع الملاحظات في Python
linktitle: PowerPoint إلى TIFF مع الملاحظات
type: docs
weight: 100
url: /ar/python-java/convert-powerpoint-to-tiff-with-notes/
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
- حفظ PPT كـ TIFF
- حفظ PPTX كـ TIFF
- تصدير PPT إلى TIFF
- تصدير PPTX إلى TIFF
- PowerPoint مع ملاحظات
- العرض التقديمي مع ملاحظات
- الشريحة مع ملاحظات
- PPT مع ملاحظات
- PPTX مع ملاحظات
- TIFF مع ملاحظات
- Python
- Java
- Aspose.Slides
description: "تحويل عروض PowerPoint إلى TIFF مع الملاحظات باستخدام Aspose.Slides للـ Python عبر Java. تعلّم كيفية تصدير الشرائح مع ملاحظات المتحدث بكفاءة."
---
## **المقدمة**

Aspose.Slides for Python via Java يوفر حلاً بسيطًا لتحويل عروض PowerPoint وOpenDocument (PPT, PPTX, وODP) مع الملاحظات إلى تنسيق TIFF. يُستخدم هذا التنسيق على نطاق واسع لتخزين الصور عالية الجودة والطباعة وأرشفة المستندات. استخدم طريقة [save](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#save) لفئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) لتصدير الشرائح وملاحظات المتحدث إلى ملف TIFF متعدد الصفحات.

## **تحويل عرض تقديمي إلى TIFF مع الملاحظات**

حفظ عرض PowerPoint أو OpenDocument إلى TIFF مع الملاحظات باستخدام Aspose.Slides for Python via Java يتضمن الخطوات التالية:

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/): تحميل ملف PowerPoint أو OpenDocument.  
1. تكوين خيارات تخطيط المخرجات: استخدم فئة [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ar/python-java/aspose.slides/notescommentslayoutingoptions/) لتحديد كيفية عرض الملاحظات والتعليقات.  
1. حفظ العرض التقديمي إلى TIFF: مرّر الخيارات المكوّنة إلى طريقة [save](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#save).

لنفترض أن لدينا ملف "speaker_notes.pptx" يحتوي على الشريحة التالية:

![شريحة العرض التقديمي مع ملاحظات المتحدث](slide_with_notes.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NotesCommentsLayoutingOptions, NotesPositions, Presentation, SaveFormat, TiffOptions

presentation = Presentation("speaker_notes.pptx")
try:
    # عرض ملاحظات المتحدث الكاملة أسفل كل شريحة.
    notes_options = NotesCommentsLayoutingOptions()
    notes_options.setNotesPosition(NotesPositions.BottomFull)

    # تكوين دقة TIFF وتخطيط الملاحظات.
    tiff_options = TiffOptions()
    tiff_options.setDpiX(300)
    tiff_options.setDpiY(300)
    tiff_options.setSlidesLayoutOptions(notes_options)

    # حفظ العرض التقديمي كملف TIFF مع ملاحظات المتحدث.
    presentation.save("TIFF_with_notes.tiff", SaveFormat.Tiff, tiff_options)
finally:
    presentation.dispose()
```

النتيجة:

![صورة TIFF مع ملاحظات المتحدث](TIFF_with_notes.png)

{{% alert title="Tip" color="success" %}}
تحقق من Aspose [Free PowerPoint to Poster Converter](https://products.aspose.app/slides/ar/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **الأسئلة المتكررة**

**هل يمكنني التحكم في موضع منطقة الملاحظات في ملف TIFF الناتج؟**

نعم. قم بتكوين [setNotesPosition](https://reference.aspose.com/slides/ar/python-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition) باستخدام [NotesPositions.BottomTruncated](https://reference.aspose.com/slides/ar/python-java/aspose.slides/notespositions/#BottomTruncated) لتلائم الملاحظات في صفحة واحدة، مع إمكانية قصها، أو استخدم [NotesPositions.BottomFull](https://reference.aspose.com/slides/ar/python-java/aspose.slides/notespositions/#BottomFull) لعرض جميع الملاحظات باستخدام صفحات إضافية عند الحاجة. لتصدير الشرائح دون ملاحظات، احذف تكوين تخطيط الملاحظات كما هو موضح في [Convert PowerPoint to TIFF](/slides/ar/python-java/convert-powerpoint-to-tiff/).

**كيف يمكنني تقليل حجم ملف TIFF مع الملاحظات دون فقدان جودة الصورة؟**

استخدم ضغط [LZW compression](https://reference.aspose.com/slides/ar/python-java/aspose.slides/tiffcompressiontypes/#LZW) غير فقدان الجودة عبر [setCompressionType](https://reference.aspose.com/slides/ar/python-java/aspose.slides/tiffoptions/#setCompressionType). يمكن لتقليل الدقة أو عمق اللون تقليل حجم الملف أكثر، لكن قد يؤثر ذلك على جودة الصورة وقابلية قراءة الملاحظات. راجع [TIFF export settings](/slides/ar/python-java/convert-powerpoint-to-tiff/) لمزيد من الخيارات.

**هل يؤثر الخط في الملاحظات على النتيجة إذا كانت الخطوط الأصلية غير موجودة في النظام؟**

نعم. الخطوط المفقودة تُؤدي إلى [font substitution](/slides/ar/python-java/font-selection-sequence/)، مما قد يغيّر مقاييس النص ومظهره. [Supply the required fonts](/slides/ar/python-java/custom-font/) للحفاظ على الخطوط المطلوبة.