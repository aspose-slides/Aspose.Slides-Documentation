---
title: تحويل عروض PowerPoint إلى PDF مع ملاحظات في Python
linktitle: PowerPoint إلى PDF مع ملاحظات
type: docs
weight: 50
url: /ar/python-java/convert-powerpoint-to-pdf-with-notes/
keywords:
- تحويل PowerPoint
- تحويل العرض التقديمي
- تحويل PPT
- تحويل PPTX
- PowerPoint إلى PDF
- العرض التقديمي إلى PDF
- PPT إلى PDF
- PPTX إلى PDF
- حفظ العرض التقديمي كـ PDF
- تصدير PPT إلى PDF
- تصدير PPTX إلى PDF
- ملاحظات المتحدث
- PDF مع ملاحظات
- Python
- Java
- Aspose.Slides
description: "تحويل عروض PPT و PPTX إلى PDF مع ملاحظات المتحدث باستخدام Aspose.Slides for Python عبر Java. ضبط موضع الملاحظات والحفاظ على الملاحظات الطويلة."
---
## **نظرة عامة**

توضح هذه المقالة كيفية تحويل عروض PowerPoint إلى PDF مع ملاحظات المتحدث باستخدام Aspose.Slides for Python عبر Java. يمكنك تضمين الملاحظات أسفل كل شريحة والسماح للملاحظات الطويلة بالاستمرار على صفحات إضافية. للحصول على إعدادات تصدير PDF أخرى، راجع [تحويل PowerPoint إلى PDF](/slides/ar/python-java/convert-powerpoint-to-pdf/).

لتحديد أبعاد صفحة الملاحظات واتجاهها قبل التصدير، راجع [حجم صفحة الملاحظات](/slides/ar/python-java/notes-size/).

## **تحويل PowerPoint إلى PDF مع الملاحظات**

استخدم طريقة [save](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#save) من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) لتصدير عرض PPT أو PPTX إلى PDF. لتضمين ملاحظات المتحدث، أنشئ كائنًا من النوع [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ar/python-java/aspose.slides/notescommentslayoutingoptions/) وقم بتكوين موضع الملاحظة باستخدام طريقة [setNotesPosition](https://reference.aspose.com/slides/ar/python-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition). عيّن هذا التخطيط إلى [PdfOptions](https://reference.aspose.com/slides/ar/python-java/aspose.slides/pdfoptions/) باستخدام [setSlidesLayoutOptions](https://reference.aspose.com/slides/ar/python-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions).

المثال التالي يحمل الملف `sample.pptx` ويصدره إلى `output.pdf` مع ملاحظات المتحدث أسفل الشرائح:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NotesCommentsLayoutingOptions, NotesPositions, PdfOptions, Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    # تكوين خيارات PDF لتصوير ملاحظات المتحدث.
    notes_options = NotesCommentsLayoutingOptions()
    notes_options.setNotesPosition(NotesPositions.BottomFull)

    pdf_options = PdfOptions()
    pdf_options.setSlidesLayoutOptions(notes_options)

    # حفظ العرض التقديمي كملف PDF مع ملاحظات المتحدث.
    presentation.save("output.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
يمكنك أيضًا تجربة [محول PowerPoint إلى PDF عبر الإنترنت]https://products.aspose.app/slides/ar/conversion.
{{% /alert %}}

## **الأسئلة الشائعة**

**كيف يمكنني منع قطع ملاحظات المتحدث الطويلة؟**

استخدم [NotesPositions.BottomFull](https://reference.aspose.com/slides/ar/python-java/aspose.slides/notespositions/#BottomFull) كما هو موضح في المثال أعلاه. هذا الإعداد يعرض الملاحظات بالكامل، مستخدمًا صفحات إضافية عند الحاجة.

**هل يمكنني إبقاء كل شريحة وملاحظاتها على صفحة واحدة؟**

استخدم [NotesPositions.BottomTruncated](https://reference.aspose.com/slides/ar/python-java/aspose.slides/notespositions/#BottomTruncated). هذا الإعداد يقتصر الملاحظات على صفحة واحدة، لذا قد تُقصّ الملاحظات التي لا تت fitting.

**كيف يمكنني تصدير الشرائح بدون ملاحظات المتحدث؟**

تجاهل تكوين تخطيط الملاحظات واستخدم تصدير PDF القياسي الموضح في [تحويل PowerPoint إلى PDF](/slides/ar/python-java/convert-powerpoint-to-pdf/).