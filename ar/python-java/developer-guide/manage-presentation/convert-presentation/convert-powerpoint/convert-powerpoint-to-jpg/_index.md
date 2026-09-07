---
title: تحويل PPT و PPTX إلى JPG في Python
linktitle: PowerPoint إلى JPG
type: docs
weight: 60
url: /ar/python-java/convert-powerpoint-to-jpg/
keywords:
- تحويل PowerPoint
- تحويل العرض
- تحويل الشريحة
- PowerPoint إلى JPG
- PPT إلى JPG
- PPTX إلى JPG
- حفظ الشريحة كـ JPG
- تصدير PPT إلى JPG
- تصدير PPTX إلى JPG
- Python
- Java
- Aspose.Slides
description: "تحويل شرائح PowerPoint (PPT، PPTX) إلى صور JPG في Python عبر Java. تحديد أبعاد الصورة المخصصة وتصيير الملاحظات والتعليقات باستخدام Aspose.Slides."
---
## **المقدمة**

تتيح لك Aspose.Slides للغة Python عبر Java تحويل عروض PowerPoint وOpenDocument (PPT وPPTX وODP) إلى صور JPEG. يمكنك تصدير كل شريحة أو شريحة محددة لإنشاء صور مصغرة، وبناء عارض عروض، أو تضمين معاينات الشرائح في موقع ويب أو تطبيق.

## **تحويل PowerPoint PPT/PPTX إلى JPG**

1. قم بتحميل العرض باستخدام [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/).
2. استرجع الشرائح باستخدام [getSlides](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#getSlides).
3. استدعِ [Slide.getImage](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slide/#getImage) مع عوامل المقياس الأفقية والعمودية لعرض كل شريحة.
4. احفظ كل صورة مُعالجة كـ JPEG باستخدام [ImageFormat.Jpeg](https://reference.aspose.com/slides/ar/python-java/aspose.slides/imageformat/#Jpeg)، ثم حرّر موارد الصورة.

{{% alert color="info" title="ملاحظة" %}}
إن تصدير إلى JPG ينشئ صورة منفصلة لكل شريحة. احفظ الصورة المعالجة بدلاً من حفظ العرض مباشرةً بتنسيق صورة.
{{% /alert %}}

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("presentation.pptx")
try:
    for slide in presentation.getSlides():
        slide_image = slide.getImage(1.0, 1.0)
        try:
            slide_image.save(f"Slide_{slide.getSlideNumber()}.jpg", ImageFormat.Jpeg)
        finally:
            slide_image.dispose()
finally:
    presentation.dispose()
```

## **تحويل PowerPoint PPT/PPTX إلى JPG بأبعاد مخصصة**

احسب عوامل المقياس الأفقية والعمودية من أبعاد البكسل المطلوبة وحجم الشريحة الأصلي، ثم مرّرها إلى [Slide.getImage](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slide/#getImage). المثال التالي يستهدف صورة بحجم 1200 × 800 لكل شريحة.

استخدام عوامل مقياس مختلفة قد يمدد الشريحة. للحفاظ على نسبة العرض إلى الارتفاع، استخدم نفس عامل المقياس لكلا المحورين؛ سيُطابق العرض والارتفاع الناتجان نسب الشريحة الأصلية.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("presentation.pptx")
try:
    desired_width = 1200
    desired_height = 800
    slide_size = presentation.getSlideSize().getSize()
    scale_x = desired_width / slide_size.getWidth()
    scale_y = desired_height / slide_size.getHeight()

    for slide in presentation.getSlides():
        slide_image = slide.getImage(scale_x, scale_y)
        try:
            slide_image.save(f"Slide_{slide.getSlideNumber()}.jpg", ImageFormat.Jpeg)
        finally:
            slide_image.dispose()
finally:
    presentation.dispose()
```

## **تصيير التعليقات عند حفظ الشرائح كصور**

استخدم [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ar/python-java/aspose.slides/notescommentslayoutingoptions/) لتكوين الملاحظات والتعليقات، وطبق التخطيط عبر [RenderingOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/ar/python-java/aspose.slides/renderingoptions/#setSlidesLayoutOptions). يضع هذا المثال الملاحظات في الأسفل، مقصًّا الملاحظات التي لا تتسع، ويعرض التعليقات على اليمين في مساحة عرضها 200 بكسل. يحفظ كل شريحة مُصورة كصورة JPG.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CommentsPositions, ImageFormat, NotesCommentsLayoutingOptions, NotesPositions, Presentation, RenderingOptions
from java.awt import Dimension

presentation = Presentation("presentation.pptx")
try:
    layout_options = NotesCommentsLayoutingOptions()
    layout_options.setNotesPosition(NotesPositions.BottomTruncated)
    layout_options.setCommentsPosition(CommentsPositions.Right)
    layout_options.setCommentsAreaWidth(200)

    rendering_options = RenderingOptions()
    rendering_options.setSlidesLayoutOptions(layout_options)
    image_size = Dimension(740, 960)

    for slide in presentation.getSlides():
        slide_image = slide.getImage(rendering_options, image_size)
        try:
            slide_image.save(f"Slide_{slide.getSlideNumber()}.jpg", ImageFormat.Jpeg)
        finally:
            slide_image.dispose()
finally:
    presentation.dispose()
```

## **الأسئلة الشائعة**

**هل يمكنني تحويل عدة شرائح أو عروض تقديمية إلى JPG؟**

نعم. تقوم الأمثلة بتكرار جميع الشرائح وحفظ ملف JPG واحد لكل شريحة. لمعالجة عروض تقديمية متعددة، كرّر التحويل لكل ملف إدخال واستخدم مجلدات إخراج منفصلة أو أسماء ملفات فريدة لتجنب استبدال الصور.

**هل تشمل المخططات وSmartArt والجداول والأشكال في الصور؟**

هذه الكائنات تُصوَّر كجزء من الشريحة. احرص على توفير الخطوط المستخدمة في العرض ضمن بيئة التحويل لتقليل الاختلافات الناجمة عن استبدال الخطوط.

**كيف يمكنني تقليل استهلاك الذاكرة عند تصدير عروض تقديمية كبيرة؟**

عالج الصور واحدةً تلو الأخرى، حرّر كل صورة بعد حفظها، وتجنّب أبعاد إخراج غير ضرورية كبيرة. تعتمد متطلبات الذاكرة على محتوى الشريحة وحجم الصورة.

## **انظر أيضًا**

- [تحويل PowerPoint إلى PNG](/slides/ar/python-java/convert-powerpoint-to-png/).
- [تصيير شريحة كصورة SVG](/slides/ar/python-java/render-a-slide-as-an-svg-image/).