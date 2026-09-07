---
title: تحويل عروض PowerPoint إلى وضع النشرة باستخدام Python
linktitle: وضع النشرة
type: docs
weight: 150
url: /ar/python-java/convert-powerpoint-in-handout-mode/
keywords:
- تحويل PowerPoint
- تحويل العرض
- وضع النشرة
- نشرة
- PPT
- PPTX
- PowerPoint
- عرض
- Python
- Java
- Aspose.Slides
description: "تحويل عروض PowerPoint إلى نشرات باستخدام Python عبر Java. ترتيب عدة شرائح في الصفحة وتصديرها إلى PDF باستخدام Aspose.Slides."
---
## **المقدمة**

يتيح Aspose.Slides for Python عبر Java تصدير العروض التقديمية في وضع النشرة، حيث يتم ترتيب عدة شرائح على صفحة واحدة. هذا مفيد لطباعة مواد العروض للمؤتمرات والندوات والفعاليات المشابهة.

قم بتكوين التخطيط عبر طريقة [setSlidesLayoutOptions](https://reference.aspose.com/slides/ar/python-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions). تدعم تخطيطات النشرات [PdfOptions](https://reference.aspose.com/slides/ar/python-java/aspose.slides/pdfoptions/)، [RenderingOptions](https://reference.aspose.com/slides/ar/python-java/aspose.slides/renderingoptions/)، [HtmlOptions](https://reference.aspose.com/slides/ar/python-java/aspose.slides/htmloptions/)، و[TiffOptions](https://reference.aspose.com/slides/ar/python-java/aspose.slides/tiffoptions/). استخدم كائن [HandoutLayoutingOptions](https://reference.aspose.com/slides/ar/python-java/aspose.slides/handoutlayoutingoptions/) لتحديد إعدادات التخطيط والعرض.

## **تصدير وضع النشرة**

لتصدير عرض تقديمي في وضع النشرة، أنشئ مثيلًا من [HandoutLayoutingOptions](https://reference.aspose.com/slides/ar/python-java/aspose.slides/handoutlayoutingoptions/) وعيّنها في خيارات التصدير المستهدفة باستخدام [setSlidesLayoutOptions](https://reference.aspose.com/slides/ar/python-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions).

المثال التالي يحمل `sample.pptx` ويصدّره إلى PDF بأربع شرائح لكل صفحة بترتيب أفقي. يتضمن أرقام الشرائح وإطارات حولها، ويستثني التعليقات.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HandoutLayoutingOptions, HandoutType, PdfOptions, Presentation, SaveFormat

# تحميل عرض تقديمي.
presentation = Presentation("sample.pptx")
try:
    # تكوين تخطيط النشرة.
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

{{% alert color="warning" title="تحذير" %}}
تنطبق إعدادات تخطيط النشرة على صيغ الإخراج المدعومة مثل PDF وHTML وTIFF والصور المُرَسمة. ولا تقوم بإعادة ترتيب الشرائح في العرض التقديمي الأصلي.
{{% /alert %}}

## **الأسئلة الشائعة**

**ما هو الحد الأقصى لعدد مصغرات الشرائح لكل صفحة في وضع النشرة؟**

يدعم Aspose.Slides ما يصل إلى تسع مصغرات لكل صفحة. توفر إعدادات [HandoutType](https://reference.aspose.com/slides/ar/python-java/aspose.slides/handouttype/) مسبقات تعطي شريحة واحدة أو اثنتين أو ثلاث أو أربع أو ست أو تسع شرائح لكل صفحة. تتيح الإعدادات المسبقة لأربع و ست و تسع شرائح ترتيبًا أفقيًا وعموديًا.

**هل يمكنني تعريف شبكة مخصصة، مثل خمس أو ثمان شرائح لكل صفحة؟**

لا. يتم التحكم في عدد وترتيب المصغرات بواسطة قيم [HandoutType](https://reference.aspose.com/slides/ar/python-java/aspose.slides/handouttype/) المحددة مسبقًا. لا تدعم إعدادات تخطيط النشرة شبكات عشوائية.

**هل يمكنني تضمين الشرائح المخفية في مخرجات النشرة؟**

نعم. فعل الشرائح المخفية في إعدادات التصدير للصيغة المستهدفة. بالنسبة إلى PDF، استدعِ [PdfOptions.setShowHiddenSlides](https://reference.aspose.com/slides/ar/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) مع `True` قبل حفظ العرض التقديمي.