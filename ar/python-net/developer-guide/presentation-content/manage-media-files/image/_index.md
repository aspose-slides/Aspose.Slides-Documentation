---
title: تحسين إدارة الصور في العروض التقديمية باستخدام Python
linktitle: إدارة الصور
type: docs
weight: 10
url: /ar/python-net/image/
keywords:
- إضافة صورة
- إضافة صورة
- استبدال صورة
- مجموعة الصور
- إطار الصورة
- صورة مرتبطة
- خلفية
- إضافة PNG
- إضافة JPG
- إضافة SVG
- SVG إلى أشكال
- موارد SVG الخارجية
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "تعرّف على كيفية إضافة وإعادة استخدام وربط واستبدال وإدارة الصور النقطية وSVG في عروض PowerPoint وOpenDocument مع Aspose.Slides للبايثون عبر .NET."
---
## **المقدمة**

توفر Aspose.Slides for Python عبر .NET عدة طرق للعمل مع الصور، ويؤدي كل منها غرضًا مختلفًا. يمكنك تخزين صورة في العرض التقديمي، عرضها في إطار صورة، استخدامها كخلفية شريحة، ربطها بصورة خارجية، استبدال مورد صورة مشترك، أو تحويل محتوى SVG إلى أشكال قابلة للتعديل.

تركّز هذه المقالة على موارد الصورة وكيفية استخدامها عبر العرض التقديمي. لتقليل القص، الشفافية، التأثيرات، التمدد، وغيرها من التنسيقات المطبقة على إطار صورة فردي، راجع [إطار الصورة](/slides/ar/python-net/picture-frame/).

## **فهم نموذج الصورة**

المفاهيم التالية في واجهة برمجة التطبيقات مرتبطة ارتباطًا وثيقًا لكنها ليست قابلة للتبادل:

- تخزن [مجموعة صور العرض التقديمي](https://reference.aspose.com/slides/ar/python-net/aspose.slides/imagecollection/) موارد الصور المستخدمة في العرض التقديمي. استخدم [ImageCollection.add_image](https://reference.aspose.com/slides/ar/python-net/aspose.slides/imagecollection/add_image/) لإضافة بيانات الصورة والحصول على مورد [IPPImage](https://reference.aspose.com/slides/ar/python-net/aspose.slides/ippimage/).
- [إطار صورة](https://reference.aspose.com/slides/ar/python-net/aspose.slides/ipictureframe/) هو شكل يعرض صورة على شريحة أو تخطيط أو ماستر. استخدم [ShapeCollection.add_picture_frame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/shapecollection/add_picture_frame/) لوضع مورد صورة على شريحة.
- خلفية الشريحة تستخدم صورة كجزء من تعبئة الشريحة بدلاً من كونها شكلاً. لذلك لا تتصرف كإطار صورة.
- تستبدل [IPPImage.replace_image](https://reference.aspose.com/slides/ar/python-net/aspose.slides/ippimage/replace_image/) مورد صورة. إذا استخدم عدة عناصر في العرض التقديمي ذلك المورد، فستستعمل جميعها البديل.
- تحويل SVG إلى أشكال ينشئ أشكال شريحة قابلة للتعديل. بعد التحويل، لا يُدار المحتوى كموارد صورة واحدة.

لذلك فإن سير العمل النموذجي هو: إضافة بيانات الصورة إلى مجموعة الصور، الحصول على [IPPImage]، ثم استخدام ذلك المورد في إطار صورة واحد أو أكثر أو تعبئات.

## **إضافة صورة مضمّنة**

لإدراج صورة محلية، اقرأ الملف، أضف بياناته إلى مجموعة الصور، وأنشئ إطار صورة يستخدم الـ`IPPImage` المرجع.

```python
import aspose.slides as slides

with open("photo.png", "rb") as image_stream:
    image_data = image_stream.read()

with slides.Presentation() as presentation:
    image = presentation.images.add_image(image_data)
    slide = presentation.slides[0]
    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 20, 320, 180, image)

    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

الصورة التي تُضاف بهذه الطريقة تكون مضمّنة في العرض التقديمي، وبالتالي لا يعتمد الملف الناتج على توافر ملف الصورة الأصلي.

### **إضافة صورة من الويب**

عند توفر صورة عبر HTTP أو HTTPS، قم بتنزيل بايتاتها، أضفها إلى مجموعة صور العرض التقديمي، واستخدم مورد الصورة المرجع بنفس طريقة الصورة المحلية.

```python
from urllib.request import urlopen

import aspose.slides as slides

image_url = "https://example.com/image.png"
with urlopen(image_url) as response:
    image_data = response.read()

with slides.Presentation() as presentation:
    image = presentation.images.add_image(image_data)
    slide = presentation.slides[0]
    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 20, 320, 180, image)

    presentation.save("presentation-from-web.pptx", slides.export.SaveFormat.PPTX)
```

في التطبيقات طويلة الأمد، أعد استخدام عميل HTTP أو مجموعة اتصالات حيثما كان ذلك مناسبًا بدلاً من إنشاء اتصال جديد لكل طلب. كما يجب التحقق من صحة عناوين URL البعيدة، أحجام الاستجابات، وأنواع المحتوى عندما لا يكون المصدر موثوقًا.

## **إعادة استخدام الصور عبر الشرائح**

إذا كانت الصورة نفسها مطلوبة أكثر من مرة، أضفها إلى العرض التقديمي مرة واحدة وأعد استخدام الـ[IPPImage] المرجع عند إنشاء إطارات صور إضافية. يؤدي ذلك إلى تجنب تحميل بيانات المصدر نفسها مرارًا ويجعل العلاقة بين مورد الصورة المشترك واستخداماته واضحة.

للرسوم التي يجب أن تظهر تلقائيًا على العديد من الشرائح، مثل شعار الشركة، ضع إطار الصورة على [ماستر الشريحة](/slides/ar/python-net/slide-master/) أو التخطيط بدلاً من إضافة شكل مكافئ إلى كل شريحة.

## **استخدام صورة كخلفية شريحة**

يُعين صورة الخلفية لتعبئة الشريحة؛ ولا تُضاف كقالب إطار صورة. يكون ذلك مفيدًا عندما يجب أن تغطي الصورة خلفية الشريحة ولا ينبغي تعديلها ككائن شريحة عادي.

```python
import aspose.slides as slides

with open("background.jpg", "rb") as image_stream:
    image_data = image_stream.read()

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    image = presentation.images.add_image(image_data)
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.PICTURE
    slide.background.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH
    slide.background.fill_format.picture_fill_format.picture.image = image

    presentation.save("background-image.pptx", slides.export.SaveFormat.PPTX)
```

لخيارات خلفية إضافية، بما في ذلك خلفيات الماستر والتخطيط، راجع [خلفية العرض التقديمي](/slides/ar/python-net/presentation-background/).

## **الصور المضمّنة والروابط**

تتميز الصور المضمّنة والمرتبطة بمقايضات مختلفة من حيث القابلية للنقل وحجم الملف:

- **الصورة المضمّنة:** يتم تخزين بيانات الصورة داخل العرض التقديمي. يكون العرض التقديمي مستقلًا، لكن حجم الملف يتضمن بيانات الصورة.
- **الصورة المرتبطة:** يخزن العرض التقديمي مسارًا أو عنوان URL لصورة خارجية. يمكن لهذا أن يقلل من حجم العرض التقديمي، لكن يجب أن يظل المورد الخارجي متاحًا عند فتح أو عرض العرض.

يمكن إنشاء صورة مرتبطة عن طريق تعيين المسار أو URL الخارجي عبر [ISlidesPicture.link_path_long](https://reference.aspose.com/slides/ar/python-net/aspose.slides/islidespicture/link_path_long/) بدلاً من تضمين بيانات الصورة.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 20, 320, 180, None)
    picture_frame.picture_format.picture.link_path_long = "https://example.com/image.png"

    presentation.save("linked-image.pptx", slides.export.SaveFormat.PPTX)
```

استخدم الصور المرتبطة فقط عندما يمكن لبيئة النشر الوصول إلى المورد الخارجي بموثوقية. بالنسبة للعرض التقديمي الذي يجب أن يعمل دون اتصال أو يتم نقله بين الأنظمة، تكون الصور المضمّنة عادةً أكثر أمانًا.

## **العمل مع صور SVG**

SVG هو تنسيق متجه، لذا يمكن أن يكون مفيدًا للأيقونات، المخططات، والرسومات الأخرى التي يجب أن تتوسع دون فقدان التفاصيل كما في الصور النقطية. يدعم Aspose.Slides تنسيق SVG كموارد صورة ومصدر لأشكال شريحة قابلة للتعديل.

### **إضافة SVG كصورة**

أنشئ [SvgImage](https://reference.aspose.com/slides/ar/python-net/aspose.slides/svgimage/)، أضفه إلى مجموعة الصور، وضع مورد الصورة الناتج في إطار صورة.

```python
import aspose.slides as slides

with open("icon.svg", "r", encoding="utf-8") as svg_stream:
    svg_content = svg_stream.read()

svg_image = slides.SvgImage(svg_content)

with slides.Presentation() as presentation:
    image = presentation.images.add_image(svg_image)
    slide = presentation.slides[0]
    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 20, 200, 200, image)

    presentation.save("svg-image.pptx", slides.export.SaveFormat.PPTX)
```

### **تحويل SVG إلى أشكال قابلة للتعديل**

يمكن لـ Aspose.Slides تحويل SVG إلى مجموعة من الأشكال القابلة للتعديل في الشريحة، مماثلة للأمر المقابل في PowerPoint.

![PowerPoint Popup Menu](img_01_01.png)

استخدم الحمولة الزائدة لـ [ShapeCollection.add_group_shape](https://reference.aspose.com/slides/ar/python-net/aspose.slides/shapecollection/add_group_shape/) التي تقبل [ISvgImage](https://reference.aspose.com/slides/ar/python-net/aspose.slides/isvgimage/) لتنفيذ التحويل.

```python
import aspose.slides as slides

with open("diagram.svg", "r", encoding="utf-8") as svg_stream:
    svg_content = svg_stream.read()

svg_image = slides.SvgImage(svg_content)

with slides.Presentation() as presentation:
    slide_size = presentation.slide_size.size
    slide = presentation.slides[0]
    slide.shapes.add_group_shape(svg_image, 0, 0, slide_size.width, slide_size.height)

    presentation.save("editable-svg-shapes.pptx", slides.export.SaveFormat.PPTX)
```

استخدم تحويل SVG إلى أشكال عندما تحتاج العناصر المتجهة الفردية إلى تعديل كأشكال PowerPoint. إذا كان الهدف فقط عرض SVG، فإن إبقائه كصورة يكون أبسط ويتجنب إنشاء العديد من الأشكال المنفصلة.

## **استبدال مورد صورة موجود**

استخدم [IPPImage.replace_image](https://reference.aspose.com/slides/ar/python-net/aspose.slides/ippimage/replace_image/) عندما ترغب في استبدال مورد صورة موجود. يكون هذا مفيدًا خاصة للرسومات المشتركة مثل الشعارات.

```python
import aspose.slides as slides

with open("new-logo.png", "rb") as image_stream:
    image_data = image_stream.read()

with slides.Presentation("input.pptx") as presentation:
    image_to_replace = presentation.images[0]
    image_to_replace.replace_image(image_data)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

إذا استخدمت إطارات صور متعددة، خلفيات، ماسترات أو تخطيطات نفس مورد الصورة، فإن استبدال ذلك المورد سيحدّث جميع الاستخدامات. إذا كان يجب تغيير إطار صورة واحد فقط، فقم بتعيين صورة مختلفة لذلك الإطار بدلاً من استبدال المورد المشترك.

`replace_image` توفر أيضًا أحمالًا زائدة تقبل [IImage](https://reference.aspose.com/slides/ar/python-net/aspose.slides/iimage/) أو [IPPImage] آخر.

## **إرشادات عملية لإدارة الصور**

### **التحكم في حجم العرض التقديمي**

يمكن أن تجعل الصور النقطية الكبيرة العرض التقديمي كبيرًا جدًا دون حاجة. استخدم صورًا مصدرية بأبعاد مناسبة لحجم العرض المقصود، وأعد استخدام موارد الصور المشتركة حيثما أمكن، وتجنب تضمين نسخ مكررة من نفس الرسمة ذات الدقة الكاملة.

لصور النقطية التي تم وضعها بالفعل في إطارات صور، يمكن لـ [PictureFillFormat.compress_image](https://reference.aspose.com/slides/ar/python-net/aspose.slides/picturefillformat/compress_image/) تقليل بيانات الصورة وفقًا للقرار المختار وإعدادات القص. هذا معالجة لإطار الصورة وليس إدارة مجموعة الصور، لذا راجع [إطار الصورة](/slides/ar/python-net/picture-frame/) للعمليات التنسيقية ذات الصلة.

### **الاختيار بين المحتوى المضمّن والمرتبط**

يجعل التضمين العرض التقديمي قابلًا للنقل لأن جميع بيانات الصورة المطلوبة تسافر مع الملف. يمكن للربط أن يقلل من حجم الملف، لكنه يضيف تبعية خارجية. استخدم الروابط فقط عندما تكون تلك التبعية مقبولة ومستقرة.

### **إعادة استخدام العلامة التجارية المشتركة**

للشعارات المتكررة أو العلامات المائية أو الرسومات الزخرفية، استخدم مورد صورة واحد وأعد استخدامه. إذا كانت الرسمة تتعلق بتصميم العرض التقديمي وليس بمحتوى الشريحة، ضعها على ماستر أو تخطيط لتوريثها إلى الشرائح المناسبة.

### **اجعل موارد SVG قابلة للنقل**

يكون SVG المستقل أسهل في النقل والعرض بشكل متسق من SVG يعتمد على ملفات خارجية أو موارد شبكة. عندما يكون ذلك ممكنًا، قم بتضمين الموارد المطلوبة قبل استيراد SVG. حوّل SVG إلى أشكال فقط عندما تحتاج العناصر المتجهة الفردية إلى تعديل.

### **استخدام واجهة برمجة التطبيقات الحديثة للصور عبر الأنظمة**

لكود Python عبر .NET الجديد، استخدم واجهات Aspose.Slides [IImage](https://reference.aspose.com/slides/ar/python-net/aspose.slides/iimage/) و[Images](https://reference.aspose.com/slides/ar/python-net/aspose.slides/images/) بدلاً من واجهات `aspose.pydrawing.Image` أو `aspose.pydrawing.Bitmap` التي عُدلت. راجع [Modern API](/slides/ar/python-net/modern-api/) لتوجيهات الترحيل.

يتطلب WMF و EMF اعتبارًا خاصًا. عندما يتم تمرير هذه الصيغ عبر [IImage](https://reference.aspose.com/slides/ar/python-net/aspose.slides/iimage/)، تقوم [ImageCollection.add_image](https://reference.aspose.com/slides/ar/python-net/aspose.slides/imagecollection/add_image/) بتحويل ملف الميتافيلي إلى تمثيل PNG نقطي قبل الإدراج. إذا كان الحفاظ على بيانات الميتافيلي مهمًا، استخدم الحمولة الزائدة القائمة على التدفق لـ [ImageCollection.add_image](https://reference.aspose.com/slides/ar/python-net/aspose.slides/imagecollection/add_image/). إنشاء محتوى EMF من جداول البيانات أو منتجات أخرى هو سير عمل تكامل منفصل وخارج نطاق هذه المقالة.

## **الأسئلة المتكررة**

**ما الفرق بين مجموعة الصور وإطار الصورة؟**

مجموعة الصور تخزن موارد صورة قابلة لإعادة الاستخدام. إطار الصورة هو شكل شريحة يعرض أحد تلك الموارد ويوفر تنسيقات خاصة بالصورة مثل القص والتأثيرات.

**ما هي أفضل طريقة لاستبدال الشعار نفسه في كل مكان؟**

إذا كان الشعار مشتركًا كمورد صورة واحد، استبدل ذلك المورد باستخدام [IPPImage.replace_image](https://reference.aspose.com/slides/ar/python-net/aspose.slides/ippimage/replace_image/). للعلامة التجارية على مستوى كامل للعرض، يمكن أيضًا وضع الشعار على ماستر أو تخطيط لتقليل تكرار محتوى الشرائح.

**لماذا تختفي صورة مرتبطة على كمبيوتر آخر؟**

الصورة المرتبطة تعتمد على ملفها الخارجي أو URL. إذا لم يمكن الوصول إلى ذلك المورد من الكمبيوتر الآخر، قد تكون الصورة غير متاحة. قم بتضمين الصورة عندما يجب أن يكون العرض التقديمي ذاتيًا.

**هل يمكن تحرير SVG مدخل كأشكال PowerPoint؟**

نعم. حوّل SVG باستخدام [ShapeCollection.add_group_shape](https://reference.aspose.com/slides/ar/python-net/aspose.slides/shapecollection/add_group_shape/)؛ المجموعة الناتجة تحتوي على أشكال شريحة قابلة للتعديل بدلاً من صورة SVG واحدة.

**كيف يمكنني إبقاء العروض التقديمية التي تحتوي على الكثير من الصور أصغر حجمًا؟**

أعد استخدام موارد الصور المشتركة، تجنب المصادر النقطية الكبيرة غير الضرورية، ضغط الصور النقطية المناسبة عندما يلزم، ضع العلامات التجارية المتكررة على ماسترات أو تخطيطات، واستخدم الصور المرتبطة فقط عندما تكون التبعية الخارجية مقبولة.