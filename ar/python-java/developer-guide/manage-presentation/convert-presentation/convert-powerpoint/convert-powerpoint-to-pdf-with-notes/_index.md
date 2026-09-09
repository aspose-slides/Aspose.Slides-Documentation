---
title: تحويل عروض PowerPoint إلى PDF مع الملاحظات في Python
linktitle: PowerPoint إلى PDF مع الملاحظات
type: docs
weight: 50
url: /ar/python-java/convert-powerpoint-to-pdf-with-notes/
keywords:
- تحويل PowerPoint
- تحويل العرض
- تحويل PPT
- تحويل PPTX
- PowerPoint إلى PDF
- العرض إلى PDF
- PPT إلى PDF
- PPTX إلى PDF
- حفظ العرض كـ PDF
- تصدير PPT إلى PDF
- تصدير PPTX إلى PDF
- ملاحظات المتحدث
- PDF مع الملاحظات
- Python
- Java
- Aspose.Slides
description: "تحويل عروض PPT و PPTX إلى PDF مع ملاحظات المتحدث باستخدام Aspose.Slides لـ Python عبر Java. قم بتكوين موضع الملاحظات والحفاظ على الملاحظات الطويلة."
---
## **نظرة عامة**

يشرح هذا المقال كيفية تحويل عروض PowerPoint إلى PDF مع ملاحظات المتحدث باستخدام Aspose.Slides for Python via Java. يمكنك تضمين الملاحظات أسفل كل شريحة والسماح للملاحظات الطويلة بالاستمرار في صفحات إضافية. للحصول على إعدادات تصدير PDF أخرى، راجع [Convert PowerPoint to PDF](/slides/ar/python-java/convert-powerpoint-to-pdf/).

## **تحويل PowerPoint إلى PDF مع الملاحظات**

استخدم طريقة [save](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#save) من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) لتصدير عرض PPT أو PPTX إلى PDF. لتضمين ملاحظات المتحدث، أنشئ كائنًا من النوع [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ar/python-java/aspose.slides/notescommentslayoutingoptions/) وقم بتكوين موضع الملاحظة باستخدام طريقة [setNotesPosition](https://reference.aspose.com/slides/ar/python-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition). عيّن هذا التخطيط إلى [PdfOptions](https://reference.aspose.com/slides/ar/python-java/aspose.slides/pdfoptions/) باستخدام طريقة [setSlidesLayoutOptions](https://reference.aspose.com/slides/ar/python-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions).

المثال التالي يقوم بتحميل `sample.pptx` وتصديره إلى `output.pdf` مع ملاحظات المتحدث أسفل الشرائح:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NotesCommentsLayoutingOptions, NotesPositions, PdfOptions, Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    # تهيئة خيارات PDF لعرض ملاحظات المتحدث.
    notes_options = NotesCommentsLayoutingOptions()
    notes_options.setNotesPosition(NotesPositions.BottomFull)

    pdf_options = PdfOptions()
    pdf_options.setSlidesLayoutOptions(notes_options)

    # حفظ العرض إلى PDF مع ملاحظات المتحدث.
    presentation.save("output.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

{{% alert color="info" title="ملاحظة" %}}
يمكنك أيضًا تجربة [محول PowerPoint إلى PDF عبر الإنترنت](https://products.aspose.app/slides/ar/conversion).
{{% /alert %}}

## **الأسئلة المتكررة**

**كيف يمكنني منع قطع الملاحظات الطويلة للمتحدث؟**

استخدم [NotesPositions.BottomFull](https://reference.aspose.com/slides/ar/python-java/aspose.slides/notespositions/#BottomFull) كما في المثال أعلاه. هذا الإعداد يعرض الملاحظات بالكامل، ويستخدم صفحات إضافية عند الحاجة.

**هل يمكنني الاحتفاظ بكل شريحة وملاحظاتها على صفحة واحدة؟**

استخدم [NotesPositions.BottomTruncated](https://reference.aspose.com/slides/ar/python-java/aspose.slides/notespositions/#BottomTruncated). هذا الإعداد يقتصر الملاحظات على صفحة واحدة، لذا قد تُقَصّ الملاحظات التي لا تتسع.

**كيف أصدر الشرائح بدون ملاحظات المتحدث؟**

تجاوز تكوين تخطيط الملاحظات واستخدم تصدير PDF القياسي الموضح في [Convert PowerPoint to PDF](/slides/ar/python-java/convert-powerpoint-to-pdf/).