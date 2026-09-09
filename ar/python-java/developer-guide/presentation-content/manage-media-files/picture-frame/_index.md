---
title: إدارة إطارات الصور في العروض التقديمية باستخدام Python
linktitle: إطار الصورة
type: docs
weight: 10
url: /ar/python-java/picture-frame/
keywords:
- إطار الصورة
- إضافة إطار صورة
- إنشاء إطار صورة
- صورة مضمَّنة
- صورة مربوطة
- استخراج صورة
- صورة نقطية
- صورة SVG
- اقتصاص صورة
- حذف المناطق المقصوصة
- ضغط صورة
- StretchOffset
- تنسيق إطار الصورة
- مقياس نسبي
- تأثير الصورة
- نسبة العرض إلى الارتفاع
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Java
- Aspose.Slides
description: "إنشاء، تنسيق، ربط، قص، استخراج وضغط إطارات الصور في العروض التقديمية باستخدام Aspose.Slides للPython عبر Java."
---
## **نظرة عامة**

إطار الصورة هو شكل شريحة يعرض صورة. في Aspose.Slides، مورد الصورة والشكل الذي يعرضها كائنان منفصلان: يمتلك الـ[Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) موارد الصور المضمَّنة عبر الـ[ImageCollection](https://reference.aspose.com/slides/ar/python-java/aspose.slides/imagecollection/)، بينما يتحكم الـ[PictureFrame](https://reference.aspose.com/slides/ar/python-java/aspose.slides/pictureframe/) في موضع الصورة وحجمها وتنسيق الخط والدوران والاقتصاص وتأثيرات الصورة وغيرها من إعدادات مستوى الإطار.

هذا الفصل مفيد عندما يتم عرض الصورة نفسها أكثر من مرة. أضف الصورة إلى العرض التقديمي مرة واحدة، احتفظ بالـ[PPImage](https://reference.aspose.com/slides/ar/python-java/aspose.slides/ppimage/) الذي تم إرجاعه، واستخدم مورد الصورة هذا عند إنشاء إطارات الصورة.

يمكن لإطارات الصورة أن تحتوي على صور نقطية مثل PNG أو JPEG وصور SVG متجهة. كما يمكنها الإشارة إلى صور مرتبطة بدلًا من تخزين بايتات الصورة داخل العرض التقديمي. يؤثر الاختيار على قابلية النقل، حجم الملف، الاستخراج، وسلوك التصدير، لذا من المفيد تحديد كيفية تخزين الصورة قبل تطبيق التنسيق أو التحسين.

## **إضافة وتنسيق صورة مضمَّنة**

لصورة مضمَّنة، أضف بيانات الصورة إلى العرض التقديمي وأنشئ إطار صورة باستخدام [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shapecollection/#addPictureFrame). تصبح الصورة جزءًا من حزمة العرض التقديمي، وبالتالي يظل العرض التقديمي مستقلًا عند نقله إلى جهاز كمبيوتر آخر.

المثال التالي يضيف صورة JPEG، ينشئ إطارًا بأبعاد الصورة الأصلية، ويطبق تنسيق الخط والدوران:

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

يتحكم إطار الصورة في الهندسة المعروضة؛ تغيير حجم الإطار لا يغير أبعاد البكسل الأصلية المخزَّنة في مورد الصورة المضمَّن. يصبح هذا التمييز مهمًا عند اقتصاص الصورة أو ضغطها لاحقًا.

## **استخدام المقياس النسبي**

يُظهر الـ[PictureFrame](https://reference.aspose.com/slides/ar/python-java/aspose.slides/pictureframe/) مقياس العرض والارتفاع النسبي للإطار عبر [setRelativeScaleWidth](https://reference.aspose.com/slides/ar/python-java/aspose.slides/pictureframe/#setRelativeScaleWidth) و[setRelativeScaleHeight](https://reference.aspose.com/slides/ar/python-java/aspose.slides/pictureframe/#setRelativeScaleHeight). القيمة `1.0` تمثل 100 % من حجم الصورة الأصلي. المقياس النسبي مفيد عندما تحتاج سير عمل إلى الحفاظ على علاقة بحجم الصورة المصدر بدلاً من حساب الأبعاد النهائية يدويًا.

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

يغيّر المقياس النسبي إعدادات مقياس الإطار؛ لا يقوم بإعادة أخذ عينات أو ضغط الصورة المضمَّنة.

## **الصور المضمَّنة والمربوطة**

الصورة المضمَّنة تخزن بيانات الصورة داخل العرض التقديمي وبالتالي هي الخيار الأكثر أمانًا من حيث القابلية للنقل والعرض المتوقع. الصورة المربوطة تخزن موقعًا خارجيًا عبر طريقة [Picture.setLinkPathLong](https://reference.aspose.com/slides/ar/python-java/aspose.slides/picture/#setLinkPathLong) بدلاً من تضمين بيانات الصورة بنفس الطريقة.

يمكن للصور المربوطة تقليل كمية بيانات الصورة المخزَّنة في ملف PPTX، لكنها تُدخل اعتمادًا خارجيًا. يجب أن يظل الملف المرتبط متاحًا للتطبيق الذي يفتح أو يعرض العرض التقديمي. إذا تغير المسار أو تم نقل الملف أو كان المورد غير متوفر، قد لا يُعرض الإطار المربوط كما هو متوقع. بالنسبة للعرض التقديمي الذي يجب إرساله بالبريد الإلكتروني أو أرشفته أو عرضه في بيئات معزولة، تكون الصور المضمَّنة عادةً أكثر موثوقية.

### **إضافة صورة مربوطة**

المثال التالي يُنشئ إطار صورة ويشير إليه إلى ملف صورة محلي. يتعامل فقط مع ربط الصورة؛ ربط الفيديو هو سير عمل وسائط منفصل ولا يتم دمجه في هذا المثال عن قصد.

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

استخدم الروابط عندما تكون إدارة الملفات الخارجية مقصودة. لا تستخدمها كبديل للضغط فقط: ملف PPTX صغير يحتوي على تبعيات صورة مكسورة عادةً ما يكون أقل فائدة من عرض تقديمي أكبر مستقل.

## **استخراج الصور من إطارات الصورة**

قبل استخراج صورة من عرض تقديمي موجود، تحقق من أن الشكل هو فعليًا ‎[PictureFrame](https://reference.aspose.com/slides/ar/python-java/aspose.slides/pictureframe/) وأنه يحتوي على صورة مضمَّنة. قد لا تحتوي إطارات الصورة المربوطة على بايتات صورة يمكن استخراجها بنفس الطريقة.

### **استخراج صورة نقطية**

واجهة برمجة التطبيقات الحديثة للصور تعمل مع الصور النقطية مباشرة ولا تتطلب غلاف الصورة Java القديم. المثال التالي يجد أول صورة نقطية مضمَّنة على شريحة ويحفظها كـ PNG:

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

تحويل الصورة النقطية إلى PNG يحوّل الصورة المستخرجة إلى تنسيق الإخراج المطلوب. إذا كنت تحتاج إلى البايتات المشفَّرة المخزَّنة في العرض التقديمي بدلاً من ملف نقطي محوَّل، استخدم البيانات الثنائية لمورد الصورة بدلاً من ذلك.

### **استخراج صورة SVG**

بالنسبة لصورة SVG، يُظهر الـ[PPImage](https://reference.aspose.com/slides/ar/python-java/aspose.slides/ppimage/) كائنًا ‎[SvgImage](https://reference.aspose.com/slides/ar/python-java/aspose.slides/svgimage/). يتيح لك ذلك استرجاع بيانات SVG مباشرة بدلًا من تحويل الصورة إلى نقطية أولًا.

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

الحفاظ على محتوى SVG كـ SVG يحافظ على المصدر المتجه داخل العرض التقديمي. تصدير نقطي مثل PNG أو JPEG يُجبر بشكل ضروري على تحويل هذا المحتوى المتجه إلى بكسلات. تصدير الشريحة إلى PDF أو SVG هو أيضًا عملية عرض، لذا لا يجب اعتبار الرسومات المصدَّرة نسخة مطابقة بايتًا بايتًا من SVG المضمَّن الأصلي؛ استخدم بيانات ‎[SvgImage.getSvgData](https://reference.aspose.com/slides/ar/python-java/aspose.slides/svgimage/#getSvgData) عندما يُطلب المورد المتجه الأصلي.

## **اقتصاص الصورة**

يُغيّر الاقتصاص الجزء الظاهر من الصورة داخل الإطار. قيم الاقتصاص على ‎[PictureFillFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/picturefillformat/) هي نسب مئوية لأبعاد الصورة المصدر. لا يحذف الاقتصاص البكسلات المخفية من الصورة المضمَّنة في البداية؛ بل يغيّر المنطقة الظاهرة فقط.

المثال التالي يجد إطار صورة بأمان ويطبق قيم الاقتصاص:

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

نظرًا لأن بيانات الصورة المخفية لا تزال موجودة، يمكن تعديل الاقتصاص لاحقًا دون فقدان البكسلات الأصلية. إذا كان حجم الملف مهمًا أكثر من القابلية للعكس، يمكن إزالة المناطق المقتصَة فعليًا كما هو موضح في القسم التالي.

## **إزالة بيانات الصورة المقتصَة**

يُزيل ‎[PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/ar/python-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) بيانات الصورة خارج مستطيل الاقتصاص الحالي ويعيد مورد الصورة الناتج. يمكن لهذا أن يقلل حجم الملف، لكنه تحسين تدميري: بعد حفظ العرض التقديمي، لا تعود البكسلات التي أُزيلت متاحة لعملية إلغاء الاقتصاص لاحقًا.

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

قد تضيف الطريقة مورد صورة جديد إلى العرض التقديمي. إذا كانت الصورة الأصلية مستخدمة أيضًا في إطارات صورة أخرى، فإن تلك الإطارات لا تزال تحتاج إلى موردها الحالي، لذا حذف المناطق المقتصَة لا يقلل بالضرورة من إجمالي عدد الصور. اقتصاص محتوى WMF أو EMF بهذه الطريقة يُحوِّل النتيجة المقتصَة إلى PNG.

## **ضغط الصور النقطية**

يُقلل ‎[PictureFillFormat.compressImage](https://reference.aspose.com/slides/ar/python-java/aspose.slides/picturefillformat/#compressImage) من دقة الصورة النقطية نسبة إلى الحجم الذي تُعرض به الصورة. يمكنه أيضًا إزالة المناطق المقتصَة في نفس العملية. تُعيد الطريقة `True` عندما يتم تغيير حجم الصورة أو اقتصاصها و`False` عندما لا يكون هناك تغيير ضروري.

استخدم قيمة ‎[PicturesCompression](https://reference.aspose.com/slides/ar/python-java/aspose.slides/picturescompression/) المعرفة مسبقًا عندما تكون دقة الهدف القياسية كافية:

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

يمكن تمرير قيمة DPI موجبة مخصصة بدلاً من قيمة مُعرَّفة مسبقًا عندما يكون هدف معين مطلوبًا.

الضغط مخصص للصور النقطية. محتوى SVG والملفات الوصفية لا يتم تقليله عبر هذه العملية. تذكَّر أيضًا أن الدقة الأقل والمناطق المقتصَة المحذوفة لا يمكن استرجاعها من العرض التقديمي المحسّن. اختر دقة الهدف بناءً على أكبر حجم سيُعرض أو يُصدر فيه الصورة فعليًا بدلاً من تطبيق أقل DPI عالميًا.

## **إدارة تأثيرات تحويل الصورة**

للحصول على سير عمل كامل يغطي السطوع، التباين، تحولات اللون، التشويش، تأثيرات ألفا، السلاسل المرتبة، الفحص، الإزالة، والتحقق من الذهاب والإياب، راجع ‎[Image Transform Effects](/slides/ar/python-java/image-transform-effects/)‎.

## **قفل هندسة إطار الصورة**

تتحكم إعدادات ‎[PictureFrameLock](https://reference.aspose.com/slides/ar/python-java/aspose.slides/pictureframelock/) في أي عمليات تحرير تُعطَّل لإطار الصورة. على سبيل المثال، ‎[setAspectRatioLocked](https://reference.aspose.com/slides/ar/python-java/aspose.slides/pictureframelock/#setAspectRatioLocked) يحافظ على نسب الشكل أثناء تغيير حجمه.

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

القفل ينطبق على شكل إطار الصورة. لا يجبر الصورة المصدر على إعادة أخذ عينات أو تغيير دائم إلى نفس نسبة العرض إلى الارتفاع.

## **ضبط قيم StretchOffset**

عند كون وضع ملء الصورة هو تمديد، تُعرِّف قيم الـstretch‑offset على ‎[PictureFillFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/picturefillformat/) مستطيل الملء نسبة إلى حدود إطار الصورة. النسب المئوية الإيجابية تخلق تقليلًا من الحافة، بينما النسب السالبة تخلق توسعًا.

هذا مختلف عن الاقتصاص. قيم الاقتصاص تختار أي جزء من الصورة المصدر يُظهر، بينما تغير قيم الـstretch‑offset المستطيل الذي يُمدد فيه ملء الصورة الظاهر.

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

استخدم قيم الـstretch‑offset لتحديد موضع الملء. استخدم خصائص الاقتصاص عندما يكون الهدف إخفاء حواف الصورة المصدر.

## **الاعتبارات المتعلقة بالتخزين، حجم الملف، والتصدير**

التوازنات الرئيسية تكون أسهل إدارةً عندما يتم معالجة تخزين الصورة وتنسيق إطار الصورة بشكل منفصل:

- **الصور المضمَّنة** تجعل العرض التقديمي مستقلًا وتُعد الأكثر موثوقية للمشاركة والعرض على الخادم، لكن الصور النقطية الكبيرة تزيد من حجم PPTX واستهلاك الذاكرة.
- **الصور المربوطة** يمكن أن تحافظ على الحزمة أصغر، لكن العرض التقديمي يعتمد على بقاء الملفات الخارجية متاحة في المسارات أو المواقع المخزَّنة.
- **الاقتصاص** في البداية غير تدميري. البكسلات المخفية تظل مضمَّنة حتى يتم حذف المناطق المقتصَة صراحةً أو أثناء الضغط.
- **الضغط** يمكن أن يقلل حجم الملف بشكل كبير للصور النقطية الضخمة، لكنه يضحي بدقة المصدر. يجب تطبيقه بعد معرفة الحجم النهائي على الشريحة.
- **صور SVG** يجب أن تبقى كـ SVG عندما تكون الحفاظ على المتجه مهمًا. استخرج SVG المضمَّن مباشرة عندما تحتاج إلى المورد المتجه نفسه. تصدير الشرائح إلى تنسيق نقطي دائمًا ما يحول الشريحة المرسومة إلى بكسلات.
- **الصور المتكررة** ينبغي إعادة استخدام مورد ‎[PPImage](https://reference.aspose.com/slides/ar/python-java/aspose.slides/ppimage/) موجود عندما يكون ذلك ممكنًا بدلاً من تحميل نفس الملف مرارًا وتكرارًا في سير عمل العرض التقديمي.

في العروض التقديمية الكبيرة، يكون تحسين الصورة عادةً أكثر فعالية عندما يُطبق انتقائيًا: احتفظ بالشعارات والرسوميات كمتجهات، ضغط الصور الفوتوغرافية وفقًا لحجم عرضها الفعلي، قم بإزالة البكسلات المقتصَة فقط عندما لا تكون تعديل لاحق مطلوبًا، وتجنب الروابط الخارجية إلا إذا كان إدارة التبعيات جزءًا من تصميم النشر.

## **الأسئلة المتكررة**

**ما الفرق بين إطار الصورة ومورد الصورة؟**

يمثل ‎[PPImage](https://reference.aspose.com/slides/ar/python-java/aspose.slides/ppimage/) مورد صورة مرتبط بالعرض التقديمي. يُعد ‎[PictureFrame](https://reference.aspose.com/slides/ar/python-java/aspose.slides/pictureframe/) شكلًا على الشريحة يعرض صورة ويخزن هندسة وإعدادات الإطار مثل الحجم، الدوران، قيم الاقتصاص، التأثيرات، والقفل.

**هل يجب أن أضمّن الصور أم أربطها؟**

ضمّن الصور عندما يجب أن يكون العرض التقديمي قابلًا للنقل، مؤرشفًا، أو معروضًا دون الحاجة إلى موارد خارجية. اربط الصور فقط عندما يكون حفظ ملفات الصور خارج ملف PPTX مقصودًا ويمكن الحفاظ على المواقع الخارجية بدرجة موثوقية.

**هل يقلل الاقتصاص من حجم ملف PPTX؟**

ليس بمفرده. إعدادات الاقتصاص العادية تُخفي أجزاء من الصورة المصدر لكن تُبقي البكسلات الأساسية. استخدم ‎[PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/ar/python-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) أو ضغط الصورة مع إزالة المناطق المقتصَة عندما يمكن حذف تلك البكسلات نهائيًا.

**هل يمكن استعادة جودة الصورة بعد الضغط؟**

لا. يمكن للضغط أن يقلل من دقة الصورة المخزَّنة، وإزالة المناطق المقتصَة تُهدر بيانات الصورة. احتفظ بالصورة المصدر الأصلية خارج العرض التقديمي إذا كان قد يلزم تحرير عالي الدقة لاحقًا.

**كيف يجب التعامل مع صور SVG؟**

احتفظ بمحتوى SVG كـ SVG عندما تكون دقة المتجه مهمة. يمكن استخراج ‎[SvgImage](https://reference.aspose.com/slides/ar/python-java/aspose.slides/svgimage/) المضمَّن مباشرة. تحويل شريحة إلى تنسيق نقطي مثل PNG أو JPEG يُحوِّل SVG إلى بكسلات كجزء من صورة الشريحة.

**كيف يمكن تجنّب عمليات التحويل غير الآمنة عند قراءة شرائح موجودة؟**

تحقق من نوع الشكل قبل استخدام خصائص إطار الصورة. فحص ‎`isinstance`‎ ضد ‎[PictureFrame](https://reference.aspose.com/slides/ar/python-java/aspose.slides/pictureframe/)‎ يُجنب التحويلات غير الصالحة ويسمح للشفرة بالتعامل مع الشرائح التي لا تحتوي على إطارات صورة.