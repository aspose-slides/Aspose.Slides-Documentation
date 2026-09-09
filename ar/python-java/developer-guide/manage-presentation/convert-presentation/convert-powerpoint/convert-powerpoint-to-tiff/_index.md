---
title: تحويل عروض PowerPoint إلى TIFF باستخدام Python
linktitle: PowerPoint إلى TIFF
type: docs
weight: 90
url: /ar/python-java/convert-powerpoint-to-tiff/
keywords:
- تحويل PowerPoint
- تحويل OpenDocument
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
- Python
- Java
- Aspose.Slides
description: "تعلم كيفية تحويل عروض PowerPoint (PPT، PPTX) بسهولة إلى صور TIFF عالية الجودة باستخدام Aspose.Slides للغة Python عبر Java، مع أمثلة على الشيفرة."
---
## **المقدمة**

TIFF (**Tagged Image File Format**) هو تنسيق صورة نقطية يدعم صفحات متعددة وضغط بدون فقدان. وهو مفيد لتخزين الشرائح المُعالجة في ملف صورة واحد.

باستخدام Aspose.Slides للغة Python عبر Java، يمكنك تحويل عروض PowerPoint (PPT، PPTX) وعروض OpenDocument (ODP) إلى TIFF. كل مثال أدناه يبدأ آلة Java الافتراضية إذا لزم الأمر ويُطلق العرض بعد الاستخدام. 

## **تحويل عرض تقديمي إلى TIFF**

باستخدام طريقة [save](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#save) المقدمة من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/)، يمكنك بسرعة تحويل عرض PowerPoint كامل إلى TIFF. يحتوي ملف TIFF متعدد الصفحات الناتج على صورة مُعالجة لكل شريحة بالحجم الافتراضي.

يوضح هذا الكود كيفية تحويل عرض PowerPoint إلى TIFF:

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

## **تحويل عرض تقديمي إلى TIFF أبيض وأسود**

الطريقة [setBwConversionMode](https://reference.aspose.com/slides/ar/python-java/aspose.slides/tiffoptions/#setBwConversionMode) في الفئة [TiffOptions](https://reference.aspose.com/slides/ar/python-java/aspose.slides/tiffoptions/) تتيح لك تحديد الخوارزمية المستخدمة عند تحويل شريحة أو صورة ملونة إلى TIFF أبيض وأسود. لاحظ أن هذا الإعداد يُطبق فقط عندما تكون طريقة [setCompressionType](https://reference.aspose.com/slides/ar/python-java/aspose.slides/tiffoptions/#setCompressionType) مُضبوطة على [TiffCompressionTypes.CCITT4](https://reference.aspose.com/slides/ar/python-java/aspose.slides/tiffcompressiontypes/#CCITT4) أو [TiffCompressionTypes.CCITT3](https://reference.aspose.com/slides/ar/python-java/aspose.slides/tiffcompressiontypes/#CCITT3).

{{% alert color="info" title="Note" %}}
[TiffOptions.setBwConversionMode](https://reference.aspose.com/slides/ar/python-java/aspose.slides/tiffoptions/#setBwConversionMode) هو إعداد على مستوى التصدير يحدد خوارزمية تحويل البكسل لصورة TIFF بالكامل. لتحديد كيفية ظهور شكل فردي عندما يكون وضع العرض بالأبيض والأسود نشطًا، استخدم [Shape.setBlackWhiteMode](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shape/#setBlackWhiteMode). راجع [Control Black-and-White Rendering for Shapes](/slides/ar/python-java/shape-formatting/#control-black-and-white-rendering-for-shapes) للحصول على أمثلة.
{{% /alert %}}

لنفترض أن لدينا ملف "sample.pptx" يحتوي على الشريحة التالية:

![شريحة عرض تقديمي](slide_black_and_white.png)

يوضح هذا الكود كيفية تحويل الشريحة الملونة إلى TIFF أبيض وأسود:

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

![TIFF أبيض وأسود](TIFF_black_and_white.png)

## **تحويل عرض تقديمي إلى TIFF بحجم مخصص**

إذا كنت بحاجة إلى صورة TIFF بأبعاد محددة، يمكنك تعيين القيم المطلوبة باستخدام الطرق المتوفرة في [TiffOptions](https://reference.aspose.com/slides/ar/python-java/aspose.slides/tiffoptions/). على سبيل المثال، تسمح لك طريقة [setImageSize](https://reference.aspose.com/slides/ar/python-java/aspose.slides/tiffoptions/#setImageSize) بتحديد حجم الصورة الناتجة.

يوضح هذا الكود كيفية تحويل عرض PowerPoint إلى صور TIFF بحجم مخصص:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NotesCommentsLayoutingOptions, NotesPositions, Presentation, SaveFormat, TiffCompressionTypes, TiffOptions
from java.awt import Dimension

presentation = Presentation("presentation.pptx")
try:
    tiff_options = TiffOptions()
    tiff_options.setCompressionType(TiffCompressionTypes.Default)

    # تحديد الدقة الأفقية والعمودية.
    tiff_options.setDpiX(200)
    tiff_options.setDpiY(200)

    # تحديد أبعاد الإخراج بالبكسل.
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

## **تحويل عرض تقديمي إلى TIFF بتنسيق بكسل صورة مخصص**

باستخدام طريقة [setPixelFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/tiffoptions/#setPixelFormat) من الفئة [TiffOptions](https://reference.aspose.com/slides/ar/python-java/aspose.slides/tiffoptions/)، يمكنك تحديد تنسيق البكسل المفضل للصورة TIFF الناتجة.

يوضح هذا الكود كيفية تحويل عرض PowerPoint إلى صورة TIFF بتنسيق بكسل مخصص:

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

{{% alert title="Tip" color="success" %}}
تحقق من [محوّل PowerPoint إلى بوستر مجاني من Aspose](https://products.aspose.app/slides/ar/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **الأسئلة المتكررة**

**هل يمكنني تحويل شريحة فردية بدلاً من عرض PowerPoint كامل إلى TIFF؟**

نعم. يتيح لك Aspose.Slides تحويل الشرائح الفردية من عروض PowerPoint وOpenDocument إلى صور TIFF بشكل منفصل.

**هل هناك أي حد لعدد الشرائح عند تحويل عرض تقديمي إلى TIFF؟**

لا يوجد حد ثابت لعدد الشرائح لتصدير TIFF. تؤثر الذاكرة المتاحة وتعقيد الشرائح وأبعاد الإخراج على حجم العروض التي يمكنك معالجتها.

**هل يتم الاحتفاظ بحركات PowerPoint وتأثيرات الانتقال عند تحويل الشرائح إلى TIFF؟**

لا، TIFF هو تنسيق صورة ثابت. لذلك لا يتم الاحتفاظ بالحركات أو تأثيرات الانتقال؛ يتم تصدير لقطات ثابتة فقط من الشرائح.