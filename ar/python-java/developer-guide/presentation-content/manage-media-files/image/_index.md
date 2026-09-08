---
title: "تحسين إدارة الصور في العروض التقديمية باستخدام بايثون"
linktitle: "إدارة الصور"
type: docs
weight: 10
url: /ar/python-java/image/
keywords:
- إضافة صورة
- إضافة صورة داخل إطار
- استبدال صورة
- مجموعة الصور
- إطار صورة
- صورة مرتبطة
- خلفية
- إضافة PNG
- إضافة JPG
- إضافة SVG
- تحويل SVG إلى أشكال
- موارد SVG الخارجية
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Java
- Aspose.Slides
description: "تعرف على كيفية إضافة وإعادة استخدام وربط واستبدال وإدارة الصور النقطية وSVG في عروض PowerPoint وOpenDocument باستخدام Aspose.Slides for Python via Java."
---
## **مقدمة**

توفر Aspose.Slides for Python via Java عدة طرق للعمل مع الصور، ويخدم كل منها غرضًا مختلفًا. يمكنك تخزين صورة في عرض تقديمي، عرضها في إطار صورة، استخدامها كخلفية شريحة، ربطها بصورة خارجية، استبدال مورد صورة مشترك، أو تحويل محتوى SVG إلى أشكال قابلة للتحرير.

للقص والشفافية والتأثيرات والتمدد وغيرها من التنسيقات المطبقة على إطار صورة فردي، راجع [إطار الصورة](/slides/ar/python-java/picture-frame/).

## **فهم نموذج الصورة**

المفاهيم التالية في API مرتبطة ارتباطًا وثيقًا لكنها ليست تبادلية:

- تخزن [مجموعة صور العرض التقديمي](https://reference.aspose.com/slides/ar/python-java/aspose.slides/imagecollection/) موارد الصور المستخدمة في العرض. استخدم [ImageCollection.addImage](https://reference.aspose.com/slides/ar/python-java/aspose.slides/imagecollection/#addImage) لإضافة بيانات الصورة والحصول على مورد [PPImage](https://reference.aspose.com/slides/ar/python-java/aspose.slides/ppimage/).
- إطار الصورة هو شكل يعرض صورة على شريحة أو تخطيط أو رئيس. استخدم [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shapecollection/#addPictureFrame) لوضع مورد صورة على شريحة.
- خلفية الشريحة تستخدم صورة كجزء من تعبئة الشريحة وليس كشكل. لذلك لا تتصرف كإطار صورة.
- [PPImage.replaceImage](https://reference.aspose.com/slides/ar/python-java/aspose.slides/ppimage/#replaceImage) يستبدل مورد صورة. إذا استخدم عدة عناصر في العرض هذا المورد، فإنها جميعًا ستستخدم البديل.
- تحويل SVG إلى أشكال يُنشئ أشكال شرائح قابلة للتحرير. بعد التحويل، لا يُدار المحتوى كموارد صورة واحدة.

لذلك، سير العمل النموذجي يكون: إضافة بيانات الصورة إلى مجموعة الصور، الحصول على [PPImage](https://reference.aspose.com/slides/ar/python-java/aspose.slides/ppimage/)، ثم استخدام هذا المورد في إطار صورة واحد أو أكثر أو في التعبئات.

## **إضافة صورة مضمنة**

لإدراج صورة محلية، حمّل الملف، أضفه إلى مجموعة الصور، وأنشئ إطار صورة يستخدم [PPImage](https://reference.aspose.com/slides/ar/python-java/aspose.slides/ppimage/).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    source_image = Images.fromFile("photo.png")
    try:
        image = presentation.getImages().addImage(source_image)
    finally:
        source_image.dispose()

    slide = presentation.getSlides().get_Item(0)
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, image)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

الصورة التي تُضاف بهذه الطريقة تكون مضمنة في العرض، وبالتالي لا يعتمد الملف الناتج على توافر ملف الصورة الأصلي.

### **إضافة صورة من الويب**

عند توفر صورة عبر HTTP أو HTTPS، حمّل بايتاتها، أضفها إلى مجموعة صور العرض، واستخدم مورد الصورة المعاد بنفس طريقة الصورة المحلية.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from urllib.request import urlopen
from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    with urlopen("https://example.com/image.png", timeout=10) as response:
        image_data = response.read()

    image_bytes = jpype.JArray(jpype.JByte)(image_data)
    image = presentation.getImages().addImage(image_bytes)
    slide = presentation.getSlides().get_Item(0)
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, image)

    presentation.save("presentation-from-web.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

في التطبيقات طويلة التشغيل، يُفضَّل إعادة استخدام عميل HTTP أو استراتيجية إدارة الاتصالات المناسبة للتطبيق بدلاً من إنشاء بنية شبكية غير ضرورية بشكل متكرر. كما يجب التحقق من صحة عناوين URL البعيدة، أحجام الاستجابة، وأنواع المحتوى عندما لا تكون المصدر موثوقًا.

## **إعادة استخدام الصور عبر الشرائح**

إذا كان هناك حاجة لنفس الصورة أكثر من مرة، أضفها إلى العرض مرة واحدة وأعد استخدام [PPImage](https://reference.aspose.com/slides/ar/python-java/aspose.slides/ppimage/) المعاد عند إنشاء أطر صور إضافية. هذا يمنع تحميل نفس البيانات المصدرية مرارًا ويجعل العلاقة بين مورد الصورة المشترك واستخداماته واضحة.

للرسومات التي يجب أن تظهر تلقائيًا على العديد من الشرائح، مثل شعار الشركة، يُنصح بوضع إطار الصورة على [قالب الشريحة](/slides/ar/python-java/slide-master/) أو التخطيط بدلاً من إضافة شكل مماثل إلى كل شريحة.

## **استخدام صورة كخلفية شريحة**

يتم تعيين صورة الخلفية إلى تعبئة الشريحة؛ لا تُضيف كشكل إطار صورة. وهذا مفيد عندما يجب أن تغطي الصورة خلفية الشريحة ولا ينبغي معالجتها ككائن شريحة عادي.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, PictureFillMode, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_image = Images.fromFile("background.jpg")
    try:
        image = presentation.getImages().addImage(source_image)
    finally:
        source_image.dispose()

    slide.getBackground().setType(BackgroundType.OwnBackground)
    slide.getBackground().getFillFormat().setFillType(FillType.Picture)
    slide.getBackground().getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch)
    slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().setImage(image)

    presentation.save("background-image.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

لخيارات خلفية إضافية، بما في ذلك خلفيات القوالب والتخطيطات، راجع [خلفية العرض التقديمي](/slides/ar/python-java/presentation-background/).

## **الصور المضمنة والمرتبطة**

- **الصورة المضمنة:** تُخزن بيانات الصورة داخل العرض. يكون العرض ذاتيًا، لكن حجم الملف يتضمن بيانات الصورة.
- **الصورة المرتبطة:** يقوم العرض بتخزين مسار أو URL لصورة خارجية. يمكن لهذا أن يقلل حجم العرض، لكن يجب أن يبقى المورد الخارجي متاحًا عند فتح أو عرض العرض.

يمكن إنشاء صورة مرتبطة عن طريق تعيين المسار أو URL الخارجي عبر [Picture.setLinkPathLong](https://reference.aspose.com/slides/ar/python-java/aspose.slides/picture/#setLinkPathLong) بدلاً من تضمين بيانات الصورة.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, None)
    picture_frame.getPictureFormat().getPicture().setLinkPathLong("https://example.com/image.png")

    presentation.save("linked-image.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

استخدم الصور المرتبطة فقط عندما يكون بإمكان بيئة النشر الوصول الموثوق إلى المورد الخارجي. بالنسبة للعروض التي يجب أن تعمل بلا اتصال أو تُنقل بين أنظمة، تكون الصور المضمنة عادةً أكثر أمانًا.

## **التعامل مع صور SVG**

SVG هو تنسيق متجّهه، لذا يمكن أن يكون مفيدًا للأيقونات، المخططات، والرسومات الأخرى التي يجب أن تتكّسّ دون فقدان التفاصيل كما في الصور النقطية. تدعم Aspose.Slides SVG كموارد صورة ومصدرًا لأشكال شرائح قابلة للتحرير.

### **إضافة SVG كصورة**

أنشئ [SvgImage](https://reference.aspose.com/slides/ar/python-java/aspose.slides/svgimage/)، أضفه إلى مجموعة الصور، وضع مورد الصورة الناتج في إطار صورة.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import Presentation, SaveFormat, ShapeType, SvgImage

presentation = Presentation()
try:
    svg_content = Path("icon.svg").read_text(encoding="utf-8")
    svg_image = SvgImage(svg_content)

    image = presentation.getImages().addImage(svg_image)
    slide = presentation.getSlides().get_Item(0)
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 200, 200, image)

    presentation.save("svg-image.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **ملفات SVG مع موارد خارجية**

يمكن أن يشير SVG إلى صور، أوراق أنماط، أو خطوط خارجية. لهذه الحالات، توفر [SvgImage](https://reference.aspose.com/slides/ar/python-java/aspose.slides/svgimage/) مُنشئات تقبل [ExternalResourceResolver](https://reference.aspose.com/slides/ar/python-java/aspose.slides/externalresourceresolver/) وURI أساسي. يمكن للمُحَلِّل ربط URI نسبي بـ URI مطلق مسموح وإرجاع تدفق للمورد المطلوب.

يسمح المُحَلِّل بالوصول إلى الموارد الخارجية أثناء معالجة Aspose.Slides للـ SVG، لكنه لا يُعيد كتابة الـ SVG إلى مستند ذاتي‑التضمين. إذا كان من الضروري أن يبقى SVG قابلًا للنقل، فإنّ تضمين موارده المطلوبة داخل الـ SVG نفسه، على سبيل المثال باستخدام عناوين `data:` للصور المرتبطة، هو الحل.

عند جلب ملفات SVG من مصادر غير موثوقة، قُصّ نطاق المخططات، مواقع الملفات، والمضيفين التي يمكن للمُحَلِّل الوصول إليها. يجب أن تطبق المحلِّلات الشبكية مهلات زمنية، حدود لحجم الاستجابة، والتحقق من المحتوى.

### **تحويل SVG إلى أشكال قابلة للتحرير**

يمكن لـ Aspose.Slides تحويل SVG إلى مجموعة من الأشكال القابلة للتحرير، مشابهًا لأمر PowerPoint المقابل.

![PowerPoint Popup Menu](img_01_01.png)

استخدم التحميل الزائد لـ [ShapeCollection.addGroupShape](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shapecollection/#addGroupShape) الذي يقبل [SvgImage](https://reference.aspose.com/slides/ar/python-java/aspose.slides/svgimage/) لإجراء التحويل.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import Presentation, SaveFormat, SvgImage

presentation = Presentation()
try:
    svg_content = Path("diagram.svg").read_text(encoding="utf-8")
    svg_image = SvgImage(svg_content)

    slide_size = presentation.getSlideSize().getSize()
    slide = presentation.getSlides().get_Item(0)
    slide_width = jpype.JFloat(slide_size.getWidth())
    slide_height = jpype.JFloat(slide_size.getHeight())
    slide.getShapes().addGroupShape(svg_image, 0, 0, slide_width, slide_height)

    presentation.save("editable-svg-shapes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

استخدم تحويل SVG إلى أشكال عندما تحتاج عناصر المتجه الفردية إلى تعديل كأشكال PowerPoint. إذا كان الهدف فقط عرض الـ SVG، فإن بقاءه كصورة أبسط ويجنب إنشاء العديد من الأشكال المنفصلة.

## **استبدال مورد صورة موجود**

استخدم [PPImage.replaceImage](https://reference.aspose.com/slides/ar/python-java/aspose.slides/ppimage/#replaceImage) عندما تريد استبدال مورد صورة موجود. هذا مفيد بشكل خاص للرسومات المشتركة مثل الشعارات.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat

presentation = Presentation("input.pptx")
try:
    image_to_replace = presentation.getImages().get_Item(0)

    replacement_image = Images.fromFile("new-logo.png")
    try:
        image_to_replace.replaceImage(replacement_image)
    finally:
        replacement_image.dispose()

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

إذا استخدمت أطر صور، خلفيات، رؤوس أو تخطيطات متعددة نفس مورد الصورة، فإن استبدال هذا المورد سيحدّث جميع الاستخدامات. إذا كان من المفترض تغيير إطار صورة واحد فقط، فعيّن صورة مختلفة لهذا الإطار بدلاً من استبدال المورد المشترك.

[PPImage.replaceImage](https://reference.aspose.com/slides/ar/python-java/aspose.slides/ppimage/#replaceImage) يوفر أيضًا تحميلًا زائدًا يقبل مصفوفة بايت أو [PPImage] آخر.

## **إرشادات عملية لإدارة الصور**

### **التحكم في حجم العرض التقديمي**

يمكن أن تجعل الصور النقطية الكبيرة العرض كبيرًا جدًا دون ضرورة. استخدم صورًا بأبعاد ملائمة لحجم العرض المستهدف، وأعد استخدام موارد الصور المشتركة حيثما أمكن، وتجنب تضمين نسخ مكررة من نفس الرسمة عالية الدقة.

للصور النقطية التي تم وضعها بالفعل في أطر صور، يمكن لـ [PictureFillFormat.compressImage](https://reference.aspose.com/slides/ar/python-java/aspose.slides/picturefillformat/#compressImage) تقليل بيانات الصورة وفقًا للدقة وإعدادات القص المختارة. هذا يُعالج أطر الصور وليس إدارة مجموعة الصور، لذا راجع [إطار الصورة](/slides/ar/python-java/picture-frame/) للعمليات المتعلقة بالتنسيق.

### **الاختيار بين المحتوى المضمّن والمرتبط**

التضمين يجعل العرض محمولًا لأن جميع بيانات الصورة المطلوبة تسافر مع الملف. الربط قد يقلل من حجم الملف، لكنه يُدخل اعتمادًا خارجيًا. استخدم الروابط فقط عندما يكون هذا الاعتماد مقبولًا ومستقرًا.

### **إعادة استخدام العلامة التجارية المشتركة**

للشعارات المتكررة، العلامات المائية، أو الرسومات الزخرفية، استخدم مورد صورة واحد وأعد استخدامه. إذا كان الرسم جزءًا من تصميم العرض بدلاً من محتوى الشريحة، ضعّه على قالب أو تخطيط ليُورّث إلى الشرائح المناسبة.

### **الحفاظ على موارد SVG قابلة للنقل**

SVG ذاتي‑التضمين أسهل للنقل والعرض المتسق مقارنةً بـ SVG يعتمد على ملفات أو موارد شبكة خارجية. متى ما كان ممكنًا، قم بتضمين الموارد المطلوبة قبل استيراد الـ SVG. حوِّل SVG إلى أشكال فقط عندما تحتاج إلى تعديل العناصر المتجهة الفردية.

### **استخدام واجهة برمجة التطبيقات الحديثة للصور عبر الأنظمة**

في كود Python عبر Java الجديد، استخدم كائنات الصور متعددة الأنظمة في Aspose.Slides وواجهة برمجة التطبيقات [Images](https://reference.aspose.com/slides/ar/python-java/aspose.slides/images/) بدلاً من API العامة القديمة القائمة على `java.awt.image.BufferedImage`. راجع [الواجهة الحديثة](/slides/ar/python-java/modern-api/) لتوجيهات الهجرة.

تتطلب صيغ WMF و EMF اعتبارات خاصة. عند تمرير هذه الصيغ عبر كائن صورة متعدد الأنظمة، يقوم [ImageCollection.addImage](https://reference.aspose.com/slides/ar/python-java/aspose.slides/imagecollection/#addImage) بتحويل الملف التعريفي إلى تمثيل PNG نقطي قبل الإدراج. إذا كان الحفاظ على بيانات الملف التعريفي أمرًا مهمًا، استخدم التحميل الزائد القائم على التدفق لـ [ImageCollection.addImage](https://reference.aspose.com/slides/ar/python-java/aspose.slides/imagecollection/#addImage). توليد محتوى EMF من جداول البيانات أو منتجات أخرى هو سير عمل تكامل منفصل ولا يندرج ضمن نطاق هذا المقال.

## **الأسئلة المتداولة**

**ما هو الفرق بين مجموعة الصور وإطار الصورة؟**

مجموعة الصور تخزن موارد الصور القابلة لإعادة الاستخدام. إطار الصورة هو شكل شريحة يعرض أحد هذه الموارد ويوفر تنسيقات خاصة بالصورة مثل القص والتأثيرات.

**ما هي أفضل طريقة لاستبدال الشعار نفسه في جميع المواضع؟**

إذا كان الشعار مُشاركًا كمورد صورة واحد، استبدل ذلك المورد باستخدام [PPImage.replaceImage](https://reference.aspose.com/slides/ar/python-java/aspose.slides/ppimage/#replaceImage). للعلامة التجارية على مستوى العرض، يمكن أيضًا وضع الشعار على قالب أو تخطيط لتقليل تكرار محتوى الشرائح.

**لماذا تختفي الصورة المرتبطة على جهاز كمبيوتر آخر؟**

الصورة المرتبطة تعتمد على ملفها الخارجي أو URL الخاص بها. إذا تعذّر الوصول إلى ذلك المورد من الجهاز الآخر، قد تصبح الصورة غير متوفرة. يُفضَّل تضمين الصورة عندما يجب أن يكون العرض ذاتيًا.

**هل يمكن تحرير SVG مدخل كأشكال PowerPoint؟**

نعم. حوّل SVG باستخدام [ShapeCollection.addGroupShape](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shapecollection/#addGroupShape)؛ المجموعة الناتجة تحتوي على أشكال شريحة قابلة للتحرير بدلاً من صورة SVG واحدة.

**كيف يمكنني الحفاظ على عروض تقديمية تحتوي على العديد من الصور أصغر حجمًا؟**

أعد استخدام موارد الصور المشتركة، تجنّب مصادر نقطية كبيرة غير ضرورية، اضغط الصور النقطية المناسبة عندما يلزم، احتفظ بالعلامات التجارية المتكررة على القوالب أو التخطيطات، واستخدم الصور المرتبطة فقط عندما يكون الاعتماد الخارجي مقبولًا.