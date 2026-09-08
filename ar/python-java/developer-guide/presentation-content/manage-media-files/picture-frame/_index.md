---
title: إدارة إطارات الصور في العروض التقديمية باستخدام بايثون
linktitle: إطار الصورة
type: docs
weight: 10
url: /ar/python-java/picture-frame/
keywords:
- إطار صورة
- إضافة إطار صورة
- إنشاء إطار صورة
- صورة مضمّنة
- صورة مرتبطة
- استخراج صورة
- صورة نقطية
- صورة SVG
- قص صورة
- حذف المناطق المقصوصة
- ضغط صورة
- StretchOffset
- تنسيق إطار الصورة
- مقياس نسبي
- تأثير صورة
- نسبة العرض إلى الارتفاع
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Java
- Aspose.Slides
description: "إنشاء وتنسيق وربط وقص واستخراج وضغط إطارات الصور في العروض التقديمية باستخدام Aspose.Slides للبايثون عبر جافا."
---
## **نظرة عامة**

إطار الصورة هو شكل شريحة يعرض صورة. في Aspose.Slides، مورد الصورة والشكل الذي يعرضها كائنات منفصلة: a [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) يمتلك موارد الصور المضمنة عبر [ImageCollection](https://reference.aspose.com/slides/ar/python-java/aspose.slides/imagecollection/)، بينما [PictureFrame](https://reference.aspose.com/slides/ar/python-java/aspose.slides/pictureframe/) يتحكم في موضع الصورة، حجمها، تنسيق الخط، التدوير، القص، تأثيرات الصورة، وإعدادات الإطار الأخرى.

هذه الفصلية مفيدة عندما تُعرض الصورة نفسها أكثر من مرة. أضف الصورة إلى العرض مرة واحدة، احتفظ بـ [PPImage](https://reference.aspose.com/slides/ar/python-java/aspose.slides/ppimage/) الذي تم إرجاعه، واستخدم مورد الصورة هذا عند إنشاء إطارات الصور.

يمكن لإطارات الصور احتواء صور نقطية مثل PNG أو JPEG وصور SVG متجهة. يمكنها أيضاً الإشارة إلى صور مرتبطة بدلاً من تخزين بايتات الصورة في العرض. هذا الاختيار يؤثر على قابلية النقل، حجم الملف، الاستخراج، وسلوك التصدير، لذا من المفيد تحديد كيفية تخزين الصورة قبل تطبيق التنسيق أو التحسين.

## **إضافة وتنسيق صورة مضمّنة**

بالنسبة لصورة مضمّنة، أضف بيانات الصورة إلى العرض وأنشئ إطار صورة باستخدام [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shapecollection/#addPictureFrame). تصبح الصورة جزءاً من حزمة العرض، لذا يبقى العرض مستقلاً عندما يُنقل إلى جهاز كمبيوتر آخر.

المثال التالي يضيف صورة JPEG، ينشئ إطاراً بأبعاد الصورة الأصلية، ويطبق تنسيق الخط والتدوير:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from java.awt import Color
from asposeslides.api import FillType, Images, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_image = Images.fromFile("photo.jpg")
    try:
        image = presentation.getImages().addImage(source_image)
    finally:
        source_image.dispose()

    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 100, image.getWidth(), image.getHeight(), image)
    picture_frame.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    picture_frame.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    picture_frame.getLineFormat().setWidth(3)
    picture_frame.setRotation(15)

    presentation.save("picture-frame.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

يتحكم إطار الصورة في الشكل المعروض؛ تغيير حجم الإطار لا يغيّر أبعاد البكسل الأصلية المخزنة في مورد الصورة المضمّن. هذا التمييز يصبح مهمًا عند قص الصورة أو ضغطها لاحقًا.

## **استخدام المقياس النسبي**

[PictureFrame](https://reference.aspose.com/slides/ar/python-java/aspose.slides/pictureframe/) يوفر مقياس العرض والارتفاع النسبي للإطار عبر [setRelativeScaleWidth](https://reference.aspose.com/slides/ar/python-java/aspose.slides/pictureframe/#setRelativeScaleWidth) و[setRelativeScaleHeight](https://reference.aspose.com/slides/ar/python-java/aspose.slides/pictureframe/#setRelativeScaleHeight). قيمة `1.0` تمثل 100 % من حجم الصورة الأصلي. المقياس النسبي مفيد عندما تحتاج سير عمل إلى الحفاظ على علاقة بحجم الصورة المصدر بدلاً من حساب الأبعاد النهائية يدويًا.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_image = Images.fromFile("photo.jpg")
    try:
        image = presentation.getImages().addImage(source_image)
    finally:
        source_image.dispose()

    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, image)
    picture_frame.setRelativeScaleWidth(1.35)
    picture_frame.setRelativeScaleHeight(0.8)

    presentation.save("relative-scale.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

يغير المقياس النسبي إعدادات مقياس الإطار؛ لا يعيد أخذ العينات ولا يضغط الصورة المضمنة.

## **الصور المضمّنة والمرتبطة**

الصورة المضمّنة تخزن بيانات الصورة داخل العرض وبالتالي هي الخيار الأكثر أمانًا للقابلية للنقل وعرض موثوق به. الصورة المرتبطة تخزن موقعًا خارجيًا عبر طريقة [Picture.setLinkPathLong](https://reference.aspose.com/slides/ar/python-java/aspose.slides/picture/#setLinkPathLong) بدلاً من تضمين بيانات الصورة بنفس الطريقة.

يمكن للصور المرتبطة تقليل كمية بيانات الصور المخزنة في PPTX، لكنها تُدخل اعتمادًا خارجيًا. يجب أن يبقى الملف المرتبط قابلًا للوصول للتطبيق الذي يفتح أو يعرض العرض. إذا تغير المسار أو تم نقل الملف أو كان المورد غير متاح، قد لا يتم عرض الصورة المرتبطة كما هو متوقع. بالنسبة للعروض التي يجب إرسالها بالبريد الإلكتروني أو أرشفتها أو عرضها في بيئات معزولة، تكون الصور المضمّنة عادة أكثر موثوقية.

### **إضافة صورة مرتبطة**

المثال التالي ينشئ إطار صورة ويشير إليه إلى ملف صورة محلي. يتعامل فقط مع ربط الصورة؛ ربط الفيديو هو سير عمل وسائط منفصل ولا يُدمج عمدًا في هذا المثال.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 320, 180, None)
    linked_image_file = Path("linked-image.jpg").resolve()
    link_path = str(linked_image_file)
    picture_frame.getPictureFormat().getPicture().setLinkPathLong(link_path)

    presentation.save("linked-image.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

استخدم الروابط عندما يكون إدارة الملفات الخارجية هدفًا مقصودًا. لا تستخدمها كبديل للضغط فقط: PPTX صغير مع تبعيات صور مكسورة عادةً ما يكون أقل فائدة من عرض أكبر مكتمل ذاتيًا.

## **استخراج الصور من إطارات الصور**

قبل استخراج صورة من عرض موجود، تأكد أن الشكل هو فعلاً [PictureFrame](https://reference.aspose.com/slides/ar/python-java/aspose.slides/pictureframe/) وأنه يحتوي على صورة مضمّنة. قد لا تحتوي إطارات الصور المرتبطة على بايتات صورة يمكن استخراجها بنفس الطريقة.

### **استخراج صورة نقطية**

واجهة برمجة التطبيقات الحديثة للصور تعمل مع الصور النقطية مباشرة ولا تتطلب غلاف Java القديم للصور. المثال التالي يجد أول صورة نقطية مضمّنة على شريحة ويحفظها كـ PNG:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation, PictureFrame

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        if not isinstance(shape, PictureFrame):
            continue

        picture_frame = shape
        embedded_image = picture_frame.getPictureFormat().getPicture().getImage()
        if embedded_image is None or embedded_image.getSvgImage() is not None:
            continue

        raster_image = embedded_image.getImage()
        try:
            raster_image.save("extracted-image.png", ImageFormat.Png)
        finally:
            raster_image.dispose()
        break
finally:
    presentation.dispose()
```

حفظ الصورة النقطية يحول الصورة المستخرجة إلى تنسيق الإخراج المطلوب. إذا كنت تحتاج البايتات المشفرة المخزنة في العرض بدلاً من ملف نقطي محوّل، استخدم البيانات الثنائية لمورد الصورة بدلاً من ذلك.

### **استخراج صورة SVG**

لصورة SVG، يُظهر [PPImage](https://reference.aspose.com/slides/ar/python-java/aspose.slides/ppimage/) كائنًا من نوع [SvgImage](https://reference.aspose.com/slides/ar/python-java/aspose.slides/svgimage/). يتيح لك ذلك استرجاع بيانات SVG مباشرة بدلاً من تحويل الصورة إلى نقطية أولًا.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import Presentation, PictureFrame

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        if not isinstance(shape, PictureFrame):
            continue

        picture_frame = shape
        embedded_image = picture_frame.getPictureFormat().getPicture().getImage()
        svg_image = embedded_image.getSvgImage() if embedded_image is not None else None
        if svg_image is None:
            continue

        svg_data = svg_image.getSvgData()
        Path("extracted-image.svg").write_bytes(bytes(svg_data))
        break
finally:
    presentation.dispose()
```

الحفاظ على محتوى SVG كـ SVG يحافظ على المصدر المتجه داخل العرض. تصديرات النقطية مثل PNG أو JPEG تحتاج إلى تحويل ذلك المحتوى المتجه إلى بكسلات. تصدير الشريحة إلى PDF أو SVG هو أيضًا عملية عرض، لذا لا يجب اعتبار الرسومات المصدَّرة نسخة byte‑for‑byte من SVG المضمّن الأصلي؛ استخدم بيانات [SvgImage.getSvgData](https://reference.aspose.com/slides/ar/python-java/aspose.slides/svgimage/#getSvgData) المضمَّنة عندما يكون المورد المتجه الأصلي مطلوبًا.

## **قص الصورة**

القص يغيّر أي جزء من الصورة مرئي داخل الإطار. قيم القص على [PictureFillFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/picturefillformat/) هي نسب مئوية لأبعاد الصورة المصدر. القص لا يحذف البكسلات المخفية من الصورة المضمّنة في البداية؛ إنه يغيّر فقط المنطقة المرئية.

المثال التالي يجد إطار صورة بأمان ويطبق قيم القص:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, PictureFrame

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    picture_frame = None

    for shape in slide.getShapes():
        if isinstance(shape, PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        picture_frame.getPictureFormat().setCropLeft(23.6)
        picture_frame.getPictureFormat().setCropRight(21.5)
        picture_frame.getPictureFormat().setCropTop(3)
        picture_frame.getPictureFormat().setCropBottom(31)
        presentation.save("cropped-image.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

نظرًا لأن بيانات الصورة المخفية ما زالت موجودة، يمكن تغيير القص لاحقًا دون فقدان البكسلات الأصلية. إذا كان حجم الملف أهم من القابلية للعكس، يمكن إزالة المناطق المقصوصة فعليًا كما هو موضح في القسم التالي.

## **إزالة بيانات الصورة المقصوصة**

[PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/ar/python-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) يزيل بيانات الصورة خارج مستطيل القص الحالي ويعيد مورد الصورة الناتج. يمكن لهذا أن يقلل حجم الملف، لكنه تحسين مدمر: بعد حفظ العرض، لا تتوفر البكسلات التي أزيلت لعملية إلغاء قص لاحقة.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, PictureFrame

presentation = Presentation("cropped-image.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    picture_frame = None

    for shape in slide.getShapes():
        if isinstance(shape, PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        cropped_image = picture_frame.getPictureFormat().deletePictureCroppedAreas()
        if cropped_image is not None:
            presentation.save("cropped-data-removed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

قد تضيف الطريقة مورد صورة جديد إلى العرض. إذا كانت الصورة الأصلية مستخدمة أيضًا من قبل إطارات صور أخرى، فإن هذه الإطارات لا تزال تحتاج إلى موردها الحالي، لذا حذف المناطق المقصوصة لا يقلل بالضرورة من إجمالي عدد الصور. قص محتوى WMF أو EMF بهذه الطريقة يحول النتيجة المقصوصة إلى PNG.

## **ضغط الصور النقطية**

[PictureFillFormat.compressImage](https://reference.aspose.com/slides/ar/python-java/aspose.slides/picturefillformat/#compressImage) يقلل دقة الصورة النقطية نسبةً إلى الحجم الذي تُعرض فيه الصورة. يمكنه أيضًا إزالة المناطق المقصوصة في العملية نفسها. تُعيد الطريقة `True` عندما تم تغيير حجم أو قص الصورة و`False` عندما لا يكون هناك تغيير ضروري.

استخدم قيمة [PicturesCompression](https://reference.aspose.com/slides/ar/python-java/aspose.slides/picturescompression/) مسبقة التعريف عندما يكون دقة هدف قياسية كافية:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PicturesCompression, Presentation, SaveFormat, PictureFrame

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    picture_frame = None

    for shape in slide.getShapes():
        if isinstance(shape, PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        compressed = picture_frame.getPictureFormat().compressImage(True, PicturesCompression.Dpi150)
        print("The image was compressed." if compressed else "No compression was necessary.")
        presentation.save("compressed-image.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

يمكن تمرير قيمة DPI موجبة مخصصة بدلًا من قيمة مسبقة التعريف عندما يكون هدف محدد مطلوبًا.

الضغط مخصص للصور النقطية. محتوى SVG وملفات الميتافايل لا يُقلَّص بواسطة هذا سير عمل الضغط النقطي. تذكّر أيضًا أن الدقة الأقل والمناطق المقصوصة المحذوفة لا يمكن استرجاعها من العرض المُحسَّن. اختر دقة الهدف بناءً على أكبر حجم سيُعرض فيه الصورة فعليًا أو يُصدَّر بدلاً من تطبيق أقل DPI عالميًا.

## **إدارة تأثيرات تحويل الصورة**

للحصول على سير عمل كامل يغطي السطوع، التباين، تحويلات اللون، التشويش، تأثيرات ألفا، سلاسل مرتبة، الفحص، الإزالة، والتحقق المتبادل، راجع [Image Transform Effects](/slides/ar/python-java/image-transform-effects/).

## **قفل هندسة إطار الصورة**

إعدادات [PictureFrameLock](https://reference.aspose.com/slides/ar/python-java/aspose.slides/pictureframelock/) تتحكم في أي عمليات تحرير تُعطَّل لإطار الصورة. على سبيل المثال، [setAspectRatioLocked](https://reference.aspose.com/slides/ar/python-java/aspose.slides/pictureframelock/#setAspectRatioLocked) يحافظ على نسب الشكل أثناء تغيير حجمه.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_image = Images.fromFile("photo.jpg")
    try:
        image = presentation.getImages().addImage(source_image)
    finally:
        source_image.dispose()

    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 100, image.getWidth(), image.getHeight(), image)
    picture_frame.getPictureFrameLock().setAspectRatioLocked(True)

    presentation.save("locked-picture-frame.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

القفل يُطبق على شكل إطار الصورة. لا يجبر الصورة المصدر على أخذ عينات أو تغيير دائم لنفس نسبة الأبعاد.

## **ضبط قيم StretchOffset**

عند وضع ملء الصورة على الوضع “stretch”، تحدد قيم offset على [PictureFillFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/picturefillformat/) مستطيل الملء نسبةً إلى صندوق إطارات الصورة. النسب المئوية الإيجابية تنشئ تقليصًا من الحافة، بينما النسب السالبة تنشئ بروزًا.

هذا مختلف عن القص. قيم القص تُحدِّد أي جزء من الصورة المصدر يكون مرئيًا؛ قيم offset تغير المستطيل الذي يُمدد فيه ملء الصورة المرئي.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, PictureFillMode, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_image = Images.fromFile("photo.png")
    try:
        image = presentation.getImages().addImage(source_image)
    finally:
        source_image.dispose()

    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 400, 300, image)
    picture_frame.getPictureFormat().setPictureFillMode(PictureFillMode.Stretch)
    picture_frame.getPictureFormat().setStretchOffsetLeft(12)
    picture_frame.getPictureFormat().setStretchOffsetRight(12)
    picture_frame.getPictureFormat().setStretchOffsetTop(8)
    picture_frame.getPictureFormat().setStretchOffsetBottom(8)

    presentation.save("stretch-offsets.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

استخدم offset للموضع داخل الملء. استخدم خصائص القص عندما يكون الهدف إخفاء حواف الصورة المصدر.

## **الاعتبارات الخاصة بالتخزين وحجم الملف والتصدير**

التوازنات الرئيسية تكون أسهل عندما يتم التعامل مع تخزين الصورة وتنسيق إطار الصورة بصورة منفصلة:

- **الصور المضمّنة** تجعل العرض مكتملًا ذاتيًا وتُعد الأكثر موثوقية للمشاركة والعرض على الخوادم، لكن الصور النقطية الكبيرة تزيد من حجم PPTX واستخدام الذاكرة.
- **الصور المرتبطة** يمكن أن تحافظ على حجم الحزمة أصغر، لكن العرض يعتمد على وجود الملفات الخارجية في المسارات أو المواقع المخزنة.
- **القص** يكون في البداية غير مدمر. تظل البكسلات المخفية مضمّنة حتى يتم حذف المناطق المقصوصة صراحة أو إزالتها أثناء الضغط.
- **الضغط** يمكن أن يقلل حجم الملف بشكل كبير للصور النقطية الكبيرة، لكنه يضحي بدقة المصدر. يجب تطبيقه بعد معرفة الحجم الفعلي على الشريحة.
- **صور SVG** يجب أن تبقى كـ SVG عندما تكون حفظ المتجهات مهمًا. استخرج SVG المضمّن مباشرة عندما تحتاج المورد المتجه نفسه. تصديرات الشرائح النقطية دائمًا ما تحول الشريحة المرسومة إلى بكسلات.
- **الصور المتكررة** يجب أن تُعيد استخدام مورد [PPImage](https://reference.aspose.com/slides/ar/python-java/aspose.slides/ppimage/) موجود عندما يكون ذلك ممكنًا بدلاً من تحميل الملف نفسه مرارًا إلى سير عمل العرض.

للعروض الكبيرة، يكون تحسين الصور أكثر فاعلية عندما يُطبق بصورة انتقائية: احفظ الشعارات والرسوم التخطيطية كمحتوى متجه، اضغط الصور الفوتوغرافية وفقًا لحجم العرض الفعلي، أزل البكسلات المقصوصة فقط عندما لا تكون عمليات التحرير المستقبلية مطلوبة، وتجنب الروابط الخارجية إلا إذا كان إدارة التبعيات جزءًا من تصميم النشر.

## **الأسئلة المتكررة**

**ما الفرق بين إطار الصورة ومورد الصورة؟**

[PPImage](https://reference.aspose.com/slides/ar/python-java/aspose.slides/ppimage/) يمثل مورد صورة مرتبط بالعرض. [PictureFrame](https://reference.aspose.com/slides/ar/python-java/aspose.slides/pictureframe/) هو شكل على شريحة يعرض صورة ويخزن هندسة الإطار والتنسيق مثل الحجم، التدوير، قيم القص، التأثيرات، والقفل.

**هل يجب أن أضمّن الصور أم أربطها؟**

ضمّن الصور عندما يجب أن يكون العرض قابلًا للنقل، مؤرشفًا، أو معروضًا دون الحاجة إلى موارد خارجية. اربط الصور فقط عندما يكون حفظ ملفات الصور خارج PPTX مقصودًا ويمكن الحفاظ على المواقع الخارجية بشكل موثوق.

**هل يقلل القص من حجم ملف PPTX؟**

ليس بحاله نفسه. إعدادات القص العادية تخفي أجزاء من الصورة المصدر ولكنها تحتفظ بالبكسلات الأساسية. استخدم [PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/ar/python-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) أو ضغط الصورة مع إزالة المناطق المقصوصة عندما يمكن التخلص من تلك البكسلات نهائيًا.

**هل يمكن استعادة جودة الصورة بعد الضغط؟**

لا. الضغط قد يقلل من دقة الصورة النقطية المخزنة، وإزالة المناطق المقصوصة تحذف بيانات الصورة. احتفظ بالصورة الأصلية خارج العرض إذا كان قد يلزم تحرير عالي الدقة لاحقًا.

**كيف يجب التعامل مع صور SVG؟**

احتفظ بمحتوى SVG كـ SVG عندما تكون دقة المتجه مهمة. يمكن استخراج [SvgImage](https://reference.aspose.com/slides/ar/python-java/aspose.slides/svgimage/) المضمّن مباشرة. عرض شريحة إلى تنسيق نقطي مثل PNG أو JPEG يحول SVG إلى بكسلات كجزء من صورة الشريحة.

**كيف يمكن تجنب التحويلات غير الآمنة عند قراءة الشرائح الموجودة؟**

تحقق من نوع الشكل قبل استخدام الأعضاء الخاصة بإطار الصورة. فحص `isinstance` ضد [PictureFrame](https://reference.aspose.com/slides/ar/python-java/aspose.slides/pictureframe/) يمنع التحويلات غير الصالحة ويسمح للكود بالتعامل مع الشرائح التي لا تحتوي على إطارات صور.