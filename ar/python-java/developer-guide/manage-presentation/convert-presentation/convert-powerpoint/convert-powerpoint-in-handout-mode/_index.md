---
title: تحويل عروض PowerPoint التقديمية إلى وضع النشرة باستخدام Python
linktitle: وضع النشرة
type: docs
weight: 150
url: /ar/python-java/convert-powerpoint-in-handout-mode/
keywords:
- تحويل PowerPoint
- تحويل العرض التقديمي
- وضع النشرة
- نشرة
- PPT
- PPTX
- PowerPoint
- عرض تقديمي
- Python
- Java
- Aspose.Slides
description: "تحويل عروض PowerPoint التقديمية إلى نشرات في Python عبر Java. ترتيب عدة شرائح في كل صفحة وتصدير إلى PDF باستخدام Aspose.Slides."
---
## **المقدمة**

Aspose.Slides for Python via Java يتيح لك تصدير العروض التقديمية في وضع النشرة، حيث يتم ترتيب عدة شرائح على صفحة واحدة. هذا مفيد لطباعة مواد العرض للمؤتمرات والندوات والفعاليات المشابهة.

قم بتكوين التخطيط عبر طريقة [setSlidesLayoutOptions](https://reference.aspose.com/slides/ar/python-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions). تدعم تخطيطات النشرة الخيارات [PdfOptions](https://reference.aspose.com/slides/ar/python-java/aspose.slides/pdfoptions/)، [RenderingOptions](https://reference.aspose.com/slides/ar/python-java/aspose.slides/renderingoptions/)، [HtmlOptions](https://reference.aspose.com/slides/ar/python-java/aspose.slides/htmloptions/)، و[TiffOptions](https://reference.aspose.com/slides/ar/python-java/aspose.slides/tiffoptions/). استخدم كائن [HandoutLayoutingOptions](https://reference.aspose.com/slides/ar/python-java/aspose.slides/handoutlayoutingoptions/) لتحديد إعدادات التخطيط والعرض.

لضبط أبعاد صفحة النشرة واتجاهها قبل التصدير، انظر [Notes Page Size](/slides/ar/python-java/notes-size/).

## **تصدير وضع النشرة**

لتصدير عرض تقديمي في وضع النشرة، أنشئ مثيلًا من [HandoutLayoutingOptions](https://reference.aspose.com/slides/ar/python-java/aspose.slides/handoutlayoutingoptions/) وعيّنها إلى خيارات التصدير المستهدفة باستخدام [setSlidesLayoutOptions](https://reference.aspose.com/slides/ar/python-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions).

المثال التالي يقوم بتحميل `sample.pptx` ويصدّره إلى PDF بأربع شرائح لكل صفحة بترتيب أفقي. يتضمن أرقام الشرائح وإطارات حول الشرائح، ويستثني التعليقات.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HandoutLayoutingOptions, HandoutType, PdfOptions, Presentation, SaveFormat

# تحميل عرض تقديمي.
presentation = Presentation("sample.pptx")
try:
    # تهيئة تخطيط النشرة.
    slides_layout_options = HandoutLayoutingOptions()
    slides_layout_options.setHandout(HandoutType.Handouts4Horizontal)
    slides_layout_options.setPrintSlideNumbers(True)
    slides_layout_options.setPrintFrameSlide(True)
    slides_layout_options.setPrintComments(False)

    pdf_options = PdfOptions()
    pdf_options.setSlidesLayoutOptions(slides_layout_options)

    # تصدير العرض التقديمي إلى PDF باستخدام التخطيط المختار.
    presentation.save("output.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

{{% alert color="warning" title="Warning" %}}
تنطبق إعدادات تخطيط النشرة على صيغ الإخراج المدعومة، مثل PDF وHTML وTIFF والصور المرسومة. ولا تعيد ترتيب الشرائح في العرض التقديمي الأصلي.
{{% /alert %}}

## **الأسئلة الشائعة**

**ما هو الحد الأقصى لعدد صور الشرائح المصغرة لكل صفحة في وضع النشرة؟**

يدعم Aspose.Slides ما يصل إلى تسع صور مصغرة لكل صفحة. توفر إعدادات [HandoutType](https://reference.aspose.com/slides/ar/python-java/aspose.slides/handouttype/) مسبقة التكوين خيارات لشرائح واحدة، أو اثنتين، أو ثلاث، أو أربع، أو ست أو تسع شرائح لكل صفحة. توفر إعدادات الأربعة والست والتسع شرائح ترتيبًا أفقيًا وعموديًا.

**هل يمكنني تعريف شبكة مخصصة، مثل خمس أو ثمان شرائح لكل صفحة؟**

لا. يتم التحكم في عدد وترتيب الصور المصغرة بواسطة قيم [HandoutType](https://reference.aspose.com/slides/ar/python-java/aspose.slides/handouttype/) المحددة مسبقًا. لا تدعم إعدادات تخطيط النشرة شبكات عشوائية.

**هل يمكنني تضمين الشرائح المخفية في ناتج النشرة؟**

نعم. فعل الشرائح المخفية في إعدادات التصدير للصيغة المستهدفة. بالنسبة إلى PDF، استدعِ [PdfOptions.setShowHiddenSlides](https://reference.aspose.com/slides/ar/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) مع القيمة `True` قبل حفظ العرض التقديمي.