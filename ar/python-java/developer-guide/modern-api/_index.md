---
title: تحسين معالجة الصور باستخدام API الحديث في بايثون
linktitle: API الحديث
type: docs
weight: 237
url: /ar/python-java/modern-api/
keywords:
- API الحديث
- الرسم
- مصغرة الشريحة
- تحويل الشريحة إلى صورة
- مصغرة الشكل
- تحويل الشكل إلى صورة
- مصغرة العرض
- تحويل العرض إلى صور
- إضافة صورة
- إضافة صورة
- بايثون
- جافا
- Aspose.Slides
description: "تحديث معالجة الصور في بايثون عبر جافا: عرض الشرائح والأشكال، إضافة الصور، وترحيل استدعاءات التصوير المهجورة إلى API الحديث لـ Aspose.Slides."
---
## **المقدمة**

Aspose.Slides for Python via Java يصل إلى مكتبة Java عبر JPype. يستخدم API معالجة الصور القديم [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html) و[Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) من `java.awt`.

قامت مكتبة Java بإهمال هذه واجهات البرمجة للصور بدءًا من الإصدار 24.4. يستخدم API الحديث [IImage](https://reference.aspose.com/slides/ar/python-java/aspose.slides/iimage/) لتحميل الصور وعرضها وحفظها. استخدمه في شفرة Python الجديدة وعند ترحيل سير عمل معالجة الصور الحالي.

{{% alert color="info" title="ملاحظة" %}}

أسماء الطرق القديمة أدناه هي مراجع للترحيل. لم تعد متوفرة في الإصدارات الحالية. الأمثلة القابلة للتنفيذ تستخدم API الحديث.

هذا التغيير لا يلغي جميع الأنواع `java.awt`: لا يزال تجاوز حجم الصورة ولون النمط يقبلان [Dimension](https://docs.oracle.com/javase/8/docs/api/java/awt/Dimension.html) و[Color](https://docs.oracle.com/javase/8/docs/api/java/awt/Color.html).

{{% /alert %}}

## **API الحديث**

أنواع معالجة الصور الرئيسية هي:

- [IImage](https://reference.aspose.com/slides/ar/python-java/aspose.slides/iimage/) — تمثّل صورة نقطية أو متجهة.
- [ImageFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/imageformat/) — توفر ثوابت صيغ ملفات الصور.
- [Images](https://reference.aspose.com/slides/ar/python-java/aspose.slides/images/) — تنشئ صورًا، على سبيل المثال باستخدام [Images.fromFile](https://reference.aspose.com/slides/ar/python-java/aspose.slides/images/#fromFile).

استخدم [Slide.getImage](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slide/#getImage) أو [Shape.getImage](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shape/#getImage) لعرض شريحة واحدة أو شكل واحد. استخدم [Presentation.getImages](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#getImages) مع خيارات العرض لعرض عدة شرائح. التحميل بدون وسائط يعيد مجموعة صور العرض بدلاً من ذلك.

حمّل صورة باستخدام [Images.fromFile](https://reference.aspose.com/slides/ar/python-java/aspose.slides/images/#fromFile)، أضفها باستخدام [ImageCollection.addImage](https://reference.aspose.com/slides/ar/python-java/aspose.slides/imagecollection/#addImage)، أو حدّث صورة عرض موجودة باستخدام [PPImage.replaceImage](https://reference.aspose.com/slides/ar/python-java/aspose.slides/ppimage/#replaceImage). كلتا العمليتين على مجموعة الصور تقبلان [IImage](https://reference.aspose.com/slides/ar/python-java/aspose.slides/iimage/).

أطلق سراح كل صورة تقوم بتحميلها أو عرضها عن طريق استدعاء طريقة `dispose` داخل كتلة `finally`. أطلق سراح العرض باستخدام [Presentation.dispose](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#dispose).

### **إعداد بيئة Python**

ثبّت الحزم كما هو موضح في [Installation](/slides/ar/python-java/installation/). يستورد كل مثال `asposeslides` قبل بدء تشغيل JVM، ثم يستورد الـ API بعد تشغيل JVM. تترك الأمثلة JVM قيد التشغيل بحيث يمكن إعادة استخدامها. راجع [Limitations and API Differences](/slides/ar/python-java/limitations-and-api-differences/#import-the-library) لتوجيهات حول دفتر الملاحظات ودورة حياة JVM.

الأمثلة التي تفتح `pres.pptx` تتطلّب وجود عرض في دليل العمل. الأمثلة التي تحمل `image.png` تتطلّب ملف صورة موجود.

### **تحميل صورة وعرض شريحة**

هذا المثال يضيف صورة إلى الشريحة الأولى ويحفظ الشريحة كصورة JPEG. [IImage.save](https://reference.aspose.com/slides/ar/python-java/aspose.slides/iimage/#save) يكتب الصورة المعروضة بالصيغ المحددة.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Images, Presentation, ShapeType
from java.awt import Dimension

presentation = Presentation()
try:
    image = Images.fromFile("image.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    slide = presentation.getSlides().get_Item(0)
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture)

    image_size = Dimension(1920, 1080)
    slide_image = slide.getImage(image_size)
    try:
        slide_image.save("slide1.jpeg", ImageFormat.Jpeg)
    finally:
        slide_image.dispose()
finally:
    presentation.dispose()
```

## **استبدال الشيفرة القديمة بـ API الحديث**

استبدل استدعاءات المصغرات القديمة بطرق تُعيد [IImage](https://reference.aspose.com/slides/ar/python-java/aspose.slides/iimage/)، ثم احفظ النتيجة باستخدام [IImage.save](https://reference.aspose.com/slides/ar/python-java/aspose.slides/iimage/#save). يزيل هذا الحاجة لتمرير الصور المعروضة إلى [ImageIO.write](https://docs.oracle.com/javase/8/docs/api/javax/imageio/ImageIO.html#write-java.awt.image.RenderedImage-java.lang.String-java.io.File-).

### **عرض شريحة بحجم محدد**

استبدل استدعاء `slide.getThumbnail(image_size)` القديم بـ [Slide.getImage](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slide/#getImage) باستخدام نفس حجم الصورة.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation
from java.awt import Dimension

presentation = Presentation("pres.pptx")
try:
    if presentation.getSlides().size() > 0:
        image_size = Dimension(1920, 1080)
        slide_image = presentation.getSlides().get_Item(0).getImage(image_size)
        try:
            slide_image.save("image.png", ImageFormat.Png)
        finally:
            slide_image.dispose()
    else:
        print("The presentation contains no slides.")
finally:
    presentation.dispose()
```

### **الحصول على مصغرة شريحة**

استبدل استدعاء `slide.getThumbnail()` القديم بـ [Slide.getImage](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slide/#getImage) بدون وسائط.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("pres.pptx")
try:
    if presentation.getSlides().size() > 0:
        slide_image = presentation.getSlides().get_Item(0).getImage()
        try:
            slide_image.save("slide1.png", ImageFormat.Png)
        finally:
            slide_image.dispose()
    else:
        print("The presentation contains no slides.")
finally:
    presentation.dispose()
```

### **الحصول على مصغرة شكل**

استبدل استدعاء `shape.getThumbnail()` القديم بـ [Shape.getImage](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shape/#getImage). تأكد من أن الشريحة تحتوي على شكل قبل الوصول إليه.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("pres.pptx")
try:
    if presentation.getSlides().size() > 0:
        slide = presentation.getSlides().get_Item(0)
        if slide.getShapes().size() > 0:
            shape_image = slide.getShapes().get_Item(0).getImage()
            try:
                shape_image.save("shape.png", ImageFormat.Png)
            finally:
                shape_image.dispose()
        else:
            print("The first slide contains no shapes.")
    else:
        print("The presentation contains no slides.")
finally:
    presentation.dispose()
```

### **الحصول على مصغرة عرض**

استبدل استدعاء `presentation.getThumbnails(options, image_size)` القديم بـ [Presentation.getImages](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#getImages). استخدم [RenderingOptions](https://reference.aspose.com/slides/ar/python-java/aspose.slides/renderingoptions/) لتكوين العرض.

كرر عبر المصفوفة المرتجعة مباشرةً باستخدام `enumerate` في Python. حرّر كل صورة مرتجعة داخل كتلة `finally` حتى لا يترك فشل الحفظ الصور المتبقية غير مُحررة.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation, RenderingOptions
from java.awt import Dimension

presentation = Presentation("pres.pptx")
try:
    rendering_options = RenderingOptions()
    image_size = Dimension(1920, 1080)
    images = presentation.getImages(rendering_options, image_size)
    try:
        for index, image in enumerate(images, start=1):
            image.save(f"slide{index}.png", ImageFormat.Png)
    finally:
        for image in images:
            image.dispose()
finally:
    presentation.dispose()
```

### **إضافة صورة إلى عرض**

استبدل التحميل عبر [ImageIO.read](https://docs.oracle.com/javase/8/docs/api/javax/imageio/ImageIO.html#read-java.io.File-) بـ [Images.fromFile](https://reference.aspose.com/slides/ar/python-java/aspose.slides/images/#fromFile)، ثم مرّر الصورة الناتجة إلى [ImageCollection.addImage](https://reference.aspose.com/slides/ar/python-java/aspose.slides/imagecollection/#addImage). أضف الصورة إلى الشريحة واحفظ العرض.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    image = Images.fromFile("image.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    slide = presentation.getSlides().get_Item(0)
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture)
    presentation.save("picture.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **الطرق المهجورة واستبدالاتها في API الحديث**

الجداول تستخدم تدوين استدعاءات Python. الأسماء في العمود القديم تحدد الـ API التي أزيلت؛ استخدم الطرق المرتبطة كبدائل. طرق عرض الصور الحديثة تُعيد كائنات [IImage](https://reference.aspose.com/slides/ar/python-java/aspose.slides/iimage/) بدلاً من صور Java المخبّأة.

### **Presentation**

[Presentation.getImages](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#getImages) يُعيد مصفوفة من الصور المعروضة عندما يُستدعى مع خيارات العرض.

| الاستدعاء القديم | الاستبدال الحديث |
| --- | --- |
| `presentation.getThumbnails(options)` | [getImages](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#getImages) مع `options` |
| `presentation.getThumbnails(options, scale_x, scale_y)` | [getImages](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#getImages) مع `options, scale_x, scale_y` |
| `presentation.getThumbnails(options, slides)` | [getImages](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#getImages) مع `options, slides` |
| `presentation.getThumbnails(options, slides, scale_x, scale_y)` | [getImages](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#getImages) مع `options, slides, scale_x, scale_y` |
| `presentation.getThumbnails(options, slides, image_size)` | [getImages](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#getImages) مع `options, slides, image_size` |
| `presentation.getThumbnails(options, image_size)` | [getImages](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#getImages) مع `options, image_size` |

هنا، `slides` هو مصفوفة Java `int[]` من أرقام الشرائح المبدوءة بـ 1؛ أنشئها بـ `jpype.JArray(jpype.JInt)([1, 3])` لاختيار الشرائح 1 و3. `image_size` هو [Dimension](https://docs.oracle.com/javase/8/docs/api/java/awt/Dimension.html).

### **Shape**

| الاستدعاء القديم | الاستبدال الحديث |
| --- | --- |
| `shape.getThumbnail()` | [getImage](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shape/#getImage) بدون وسائط |
| `shape.getThumbnail(bounds, scale_x, scale_y)` | [getImage](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shape/#getImage) مع `bounds, scale_x, scale_y` |

### **Slide**

| الاستدعاء القديم | الاستبدال الحديث |
| --- | --- |
| `slide.getThumbnail()` | [getImage](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slide/#getImage) بدون وسائط |
| `slide.getThumbnail(scale_x, scale_y)` | [getImage](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slide/#getImage) مع `scale_x, scale_y` |
| `slide.getThumbnail(options)` | [getImage](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slide/#getImage) مع `options` |
| `slide.getThumbnail(options, scale_x, scale_y)` | [getImage](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slide/#getImage) مع `options, scale_x, scale_y` |
| `slide.getThumbnail(options, image_size)` | [getImage](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slide/#getImage) مع `options, image_size` |
| `slide.getThumbnail(tiff_options)` | [getImage](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slide/#getImage) مع `tiff_options` |
| `slide.getThumbnail(image_size)` | [getImage](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slide/#getImage) مع `image_size` |
| `slide.renderToGraphics(options, graphics)` | لا يوجد بديل مباشر؛ اعرض إلى صورة بدلاً من ذلك |
| `slide.renderToGraphics(options, graphics, scale_x, scale_y)` | لا يوجد بديل مباشر؛ اعرض إلى صورة بدلاً من ذلك |
| `slide.renderToGraphics(options, graphics, image_size)` | لا يوجد بديل مباشر؛ اعرض إلى صورة بدلاً من ذلك |

هنا، `options` هو [RenderingOptions](https://reference.aspose.com/slides/ar/python-java/aspose.slides/renderingoptions/)، و`tiff_options` هو [TiffOptions](https://reference.aspose.com/slides/ar/python-java/aspose.slides/tiffoptions/).

### **Output**

| الاستدعاء القديم | الاستبدال الحديث |
| --- | --- |
| `output.add(path, buffered_image)` | [Output.add](https://reference.aspose.com/slides/ar/python-java/aspose.slides/output/#add) مع `path, image`، حيث `image` هو [IImage](https://reference.aspose.com/slides/ar/python-java/aspose.slides/iimage/) |

### **ImageCollection**

| الاستدعاء القديم | الاستبدال الحديث |
| --- | --- |
| `collection.addImage(buffered_image)` | [ImageCollection.addImage](https://reference.aspose.com/slides/ar/python-java/aspose.slides/imagecollection/#addImage) مع [IImage](https://reference.aspose.com/slides/ar/python-java/aspose.slides/iimage/) |

### **PPImage**

| الاستدعاء القديم | الاستبدال الحديث |
| --- | --- |
| `picture.getSystemImage()` | [PPImage.getImage](https://reference.aspose.com/slides/ar/python-java/aspose.slides/ppimage/#getImage) |

للاستبدال محتوى صورة عرض موجودة، استخدم [PPImage.replaceImage](https://reference.aspose.com/slides/ar/python-java/aspose.slides/ppimage/#replaceImage) مع [IImage](https://reference.aspose.com/slides/ar/python-java/aspose.slides/iimage/).

### **PatternFormat**

| الاستدعاء القديم | الاستبدال الحديث |
| --- | --- |
| `pattern.getTileImage(style_color)` | [PatternFormat.getTile](https://reference.aspose.com/slides/ar/python-java/aspose.slides/patternformat/#getTile) مع `style_color` |
| `pattern.getTileImage(background, foreground)` | [PatternFormat.getTile](https://reference.aspose.com/slides/ar/python-java/aspose.slides/patternformat/#getTile) مع `background, foreground` |

تبقى معاملات اللون ككائنات Java [Color](https://docs.oracle.com/javase/8/docs/api/java/awt/Color.html).

### **PatternFormatEffectiveData**

بالنسبة للبيانات الفعّالة للنمط التي تُعيدها واجهة Java عبر JPype، تبقى الطريقة البديلة باسم `getTileIImage`.

| الاستدعاء القديم | الاستبدال الحديث |
| --- | --- |
| `effective_pattern.getTileImage(background, foreground)` | `effective_pattern.getTileIImage(background, foreground)`، تُعيد [IImage](https://reference.aspose.com/slides/ar/python-java/aspose.slides/iimage/) |

## **دعم API لـ Graphics2D**

كانت التحميلات الزائدة `renderToGraphics` القديمة ترسم في سياق [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) المزوّد من قبل المُستدعي. لا يمتلك API الحديث بديلًا مباشرًا يرسم في ذلك السياق.

استخدم [Slide.getImage](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slide/#getImage) لعرض شريحة أو [Presentation.getImages](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#getImages) لعرض عدة شرائح، ثم احفظ الصور المرتجعة باستخدام [IImage.save](https://reference.aspose.com/slides/ar/python-java/aspose.slides/iimage/#save). يجب على التطبيقات التي كانت تجمع بين عرض الشرائح والرسم المخصّص في Java تعديل خطوة التجميع.

## **الأسئلة الشائعة**

**لماذا تم استبدال واجهة برمجة التطبيقات القديمة للصور في Java؟**

ينقل API الحديث تحميل الصور وعرضها وحفظها إلى [IImage](https://reference.aspose.com/slides/ar/python-java/aspose.slides/iimage/). يمنح هذا هذه سيرورات عمل تجريدًا موحدًا للصور بدلاً من كشف صور Java المخبأة أو سياق رسومات Java.

**هل لا أزال بحاجة إلى Java وJPype؟**

نعم. لا يزال Aspose.Slides for Python via Java يعمل على JVM. تغيّر API الحديث استدعاءات معالجة الصور فقط، وليس متطلبات وقت التشغيل. راجع [System Requirements](/slides/ar/python-java/system-requirements/).

**كيف يُمكن تحرير الصور في Python؟**

استدعِ `dispose` على كل صورة تقوم بتحميلها أو عرضها داخل كتلة `finally`. إذا كنت تعرض عدة شرائح، حرّر كل صورة في المصفوفة المرتجعة. حرّر العرض منفصلًا باستخدام [Presentation.dispose](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#dispose).

**هل يضمن الانتقال إلى API الحديث تحسينًا في سرعة إنشاء المصغرات؟**

لا يُضمن أي تحسين في الأداء. تدعم البدائل خيارات العرض، والتكبير، وأحجام الصور؛ قس الأداء باستخدام عروضك وإعدادات الإخراج.

**لماذا تُرجع طريقة الحصول على الصورة أحيانًا مجموعة؟**

[Presentation.getImages](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#getImages) بدون وسائط تُعيد الصور المضمّنة في العرض. تحمّلها مع خيارات العرض تُعيد صور الشرائح المعروضة.