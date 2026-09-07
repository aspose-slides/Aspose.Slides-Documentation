---
title: تحويل عروض PowerPoint إلى TIFF في Python
linktitle: PowerPoint إلى TIFF
type: docs
weight: 90
url: /ar/python-java/convert-powerpoint-to-tiff/
keywords:
- تحويل PowerPoint
- تحويل OpenDocument
- تحويل عرض تقديمي
- تحويل شريحة
- تحويل PPT
- تحويل PPTX
- PowerPoint إلى TIFF
- عرض تقديمي إلى TIFF
- شريحة إلى TIFF
- PPT إلى TIFF
- PPTX إلى TIFF
- حفظ PPT كـ TIFF
- حفظ PPTX كـ TIFF
- تصدير PPT إلى TIFF
- تصدير PPTX إلى TIFF
- Python
- Java
- Aspose.Slides
description: "تعلم كيفية تحويل عروض PowerPoint (PPT، PPTX) بسهولة إلى صور TIFF عالية الجودة باستخدام Aspose.Slides للـ Python عبر Java، مع أمثلة على الشيفرة."
---
## **المقدمة**

TIFF (Tagged Image File Format) هو تنسيق صورة نقطية يدعم صفحات متعددة وضغط بدون فقد. إنه مفيد لتخزين الشرائح المُعالجة في ملف صورة واحد.

باستخدام Aspose.Slides for Python عبر Java، يمكنك تحويل عروض PowerPoint (PPT، PPTX) ووثائق OpenDocument (ODP) إلى TIFF. كل مثال أدناه يبدأ آلة Java الافتراضية إذا لزم الأمر ويحرّر العرض التقديمي بعد الاستخدام. 

## **تحويل عرض تقديمي إلى TIFF**

باستخدام طريقة [save](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#save) المقدمة من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) يمكنك بسرعة تحويل عرض PowerPoint كامل إلى TIFF. يحتوي ملف TIFF متعدد الصفحات الناتج على صورة مُعالجة لكل شريحة بالحجم الافتراضي.

هذا الكود يوضح كيفية تحويل عرض PowerPoint إلى TIFF:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    # حفظ جميع الشرائح في ملف TIFF متعدد الصفحات.
    presentation.save("output.tiff", SaveFormat.Tiff)
finally:
    presentation.dispose()
```

## **تحويل عرض تقديمي إلى TIFF بالأبيض والأسود**

تتيح الطريقة [setBwConversionMode](https://reference.aspose.com/slides/ar/python-java/aspose.slides/tiffoptions/#setBwConversionMode) في الفئة [TiffOptions](https://reference.aspose.com/slides/ar/python-java/aspose.slides/tiffoptions/) لك تحديد الخوارزمية المستخدمة عند تحويل شريحة ملونة أو صورة إلى TIFF بالأبيض والأسود. لاحظ أن هذا الإعداد يُطبق فقط عندما تكون طريقة [setCompressionType](https://reference.aspose.com/slides/ar/python-java/aspose.slides/tiffoptions/#setCompressionType) مُحددة إلى [TiffCompressionTypes.CCITT4](https://reference.aspose.com/slides/ar/python-java/aspose.slides/tiffcompressiontypes/#CCITT4) أو [TiffCompressionTypes.CCITT3](https://reference.aspose.com/slides/ar/python-java/aspose.slides/tiffcompressiontypes/#CCITT3).

{{% alert color="info" title="ملاحظة" %}}
[TiffOptions.setBwConversionMode](https://reference.aspose.com/slides/ar/python-java/aspose.slides/tiffoptions/#setBwConversionMode) هو إعداد على مستوى التصدير يحدد خوارزمية تحويل البكسل لكامل صورة TIFF. لتحديد كيفية ظهور شكل فردي عندما يكون وضع العرض بالأبيض والأسود نشطًا، استخدم [Shape.setBlackWhiteMode](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shape/#setBlackWhiteMode). راجع [Control Black-and-White Rendering for Shapes](/slides/ar/python-java/shape-formatting/#control-black-and-white-rendering-for-shapes) للحصول على أمثلة.
{{% /alert %}}

لنفترض أن لدينا ملف "sample.pptx" بالشفرة التالية:

![شريحة عرض تقديمي](slide_black_and_white.png)

هذا الكود يوضح كيفية تحويل الشريحة الملونة إلى TIFF بالأبيض والأسود:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BlackWhiteConversionMode, Presentation, SaveFormat, TiffCompressionTypes, TiffOptions

tiff_options = TiffOptions()
tiff_options.setCompressionType(TiffCompressionTypes.CCITT4)
tiff_options.setBwConversionMode(BlackWhiteConversionMode.Dithering)

presentation = Presentation("sample.pptx")
try:
    presentation.save("output.tiff", SaveFormat.Tiff, tiff_options)
finally:
    presentation.dispose()
```

النتيجة:

![TIFF بالأبيض والأسود](TIFF_black_and_white.png)

## **تحويل عرض تقديمي إلى TIFF بحجم مخصص**

إذا كنت تحتاج إلى صورة TIFF بأبعاد محددة، يمكنك ضبط القيم المطلوبة باستخدام الطرق المتاحة في [TiffOptions](https://reference.aspose.com/slides/ar/python-java/aspose.slides/tiffoptions/). على سبيل المثال، تسمح طريقة [setImageSize](https://reference.aspose.com/slides/ar/python-java/aspose.slides/tiffoptions/#setImageSize) لك بتحديد حجم الصورة الناتجة.

هذا الكود يوضح كيفية تحويل عرض PowerPoint إلى صور TIFF بحجم مخصص:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpape.startJVM()

from asposeslides.api import NotesCommentsLayoutingOptions, NotesPositions, Presentation, SaveFormat, TiffCompressionTypes, TiffOptions
from java.awt import Dimension

presentation = Presentation("presentation.pptx")
try:
    tiff_options = TiffOptions()
    tiff_options.setCompressionType(TiffCompressionTypes.Default)

    # ضبط الدقة الأفقية والعمودية.
    tiff_options.setDpiX(200)
    tiff_options.setDpiY(200)

    # ضبط أبعاد الإخراج بالبكسل.
    image_size = Dimension(1728, 1078)
    tiff_options.setImageSize(image_size)

    # تضمين ملاحظات المتحدث الكاملة أسفل كل شريحة.
    notes_options = NotesCommentsLayoutingOptions()
    notes_options.setNotesPosition(NotesPositions.BottomFull)
    tiff_options.setSlidesLayoutOptions(notes_options)

    presentation.save("tiff-ImageSize.tiff", SaveFormat.Tiff, tiff_options)
finally:
    presentation.dispose()
```

## **تحويل عرض تقديمي إلى TIFF بتنسيق بكسل مخصص للصورة**

باستخدام طريقة [setPixelFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/tiffoptions/#setPixelFormat) من الفئة [TiffOptions](https://reference.aspose.com/slides/ar/python-java/aspose.slides/tiffoptions/) يمكنك تحديد تنسيق البكسل المفضل للصورة TIFF الناتجة.

هذا الكود يوضح كيفية تحويل عرض PowerPoint إلى صورة TIFF بتنسيق بكسل مخصص:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImagePixelFormat, Presentation, SaveFormat, TiffOptions

presentation = Presentation("presentation.pptx")
try:
    tiff_options = TiffOptions()
    tiff_options.setPixelFormat(ImagePixelFormat.Format8bppIndexed)

    presentation.save("Tiff-PixelFormat.tiff", SaveFormat.Tiff, tiff_options)
finally:
    presentation.dispose()
```

{{% alert title="نصيحة" color="success" %}}
تحقق من Aspose's [محول PowerPoint إلى ملصق مجاني](https://products.aspose.app/slides/ar/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **الأسئلة الشائعة**

**هل يمكنني تحويل شريحة فردية بدلاً من العرض التقديمي الكامل إلى TIFF؟**

نعم. يتيح Aspose.Slides لك تحويل شرائح فردية من عروض PowerPoint وOpenDocument إلى صور TIFF بشكل منفصل.

**هل هناك أي حد لعدد الشرائح عند تحويل عرض تقديمي إلى TIFF؟**

لا يوجد حد ثابت لعدد الشرائح لتصدير TIFF. الذاكرة المتاحة وتعقيد الشرائح وأبعاد الإخراج تؤثر على حجم العروض التي يمكنك معالجتها.

**هل يتم الحفاظ على الرسوم المتحركة وتأثيرات الانتقال في PowerPoint عند تحويل الشرائح إلى TIFF؟**

لا، TIFF هو تنسيق صورة ثابت. لذلك، لا يتم حفظ الرسوم المتحركة وتأثيرات الانتقال؛ يتم تصدير لقطات ثابتة فقط من الشرائح.