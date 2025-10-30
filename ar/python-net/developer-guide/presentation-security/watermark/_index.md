---
title: إضافة علامة مائية إلى العروض التقديمية باستخدام Python
linktitle: علامة مائية
type: docs
weight: 40
url: /ar/python-net/watermark/
keywords:
- علامة مائية
- علامة مائية نصية
- علامة مائية صورة
- إضافة علامة مائية
- تعديل العلامة المائية
- إزالة العلامة المائية
- حذف العلامة المائية
- إضافة علامة مائية إلى PPT
- إضافة علامة مائية إلى PPTX
- إضافة علامة مائية إلى ODP
- إزالة العلامة المائية من PPT
- إزالة العلامة المائية من PPTX
- إزالة العلامة المائية من ODP
- حذف العلامة المائية من PPT
- حذف العلامة المائية من PPTX
- حذف العلامة المائية من ODP
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "تعرف على كيفية إدارة العلامات المائية النصية والصورية في عروض PowerPoint وOpenDocument باستخدام Python للإشارة إلى مسودة، معلومات سرية، حقوق نشر، والمزيد."
---

## **حول العلامات المائية**

**العلامة المائية** في العرض التقديمي هي ختم نصي أو صوري يُستخدم على شريحة أو على جميع شرائح العرض. عادةً ما تُستخدم العلامة المائية للإشارة إلى أن العرض مسودة (مثل علامة مائية "مسودة")، أو يحتوي على معلومات سرية (مثل علامة مائية "سري")، لتحديد الشركة المالكة (مثل علامة مائية "اسم الشركة")، لتحديد مؤلف العرض، إلخ. تساعد العلامة المائية على منع انتهاك حقوق النشر من خلال الإشارة إلى أن العرض لا ينبغي نسخه. تُستخدم العلامات المائية في صيغتي PowerPoint وOpenOffice. في Aspose.Slides، يمكنك إضافة علامة مائية إلى ملفات PPT، PPTX، وODP.

في [**Aspose.Slides**](https://products.aspose.com/slides/python-net/)، هناك طرق متعددة لإنشاء علامات مائية في مستندات PowerPoint أو OpenOffice وتعديل تصميمها وسلوكها. الجانب المشترك هو أنه لإضافة علامات مائية نصية، يجب عليك استخدام فئة [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/)، ولإضافة علامات مائية صورية، استخدم فئة [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) أو املأ شكل العلامة المائية بصورة. `PictureFrame` تُطبق فئة [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) مما يتيح لك استخدام جميع إعدادات الشكل المرنة. بما أن `TextFrame` ليس شكلاً وإعداداته محدودة، فإنه يُغلف داخل كائن [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/).

هناك طريقتان لتطبيق العلامة المائية: على شريحة واحدة أو على جميع شرائح العرض. يُستخدم Slide Master لتطبيق العلامة المائية على جميع الشرائح — تُضاف العلامة المائية إلى Slide Master، تُصمم بالكامل هناك، وتُطبق على جميع الشرائح دون التأثير على إمكانية تعديل العلامة المائية على الشرائح الفردية.

تُعتبر العلامة المائية عادةً غير قابلة للتحرير من قبل المستخدمين الآخرين. لمنع تحرير العلامة المائية (أو الشكل الأب للعلامة المائية)، توفر Aspose.Slides وظيفة قفل الشكل. يمكن قفل شكل معين على شريحة عادية أو على Slide Master. عندما يُقفل شكل العلامة المائية على Slide Master، سيُقفل على جميع الشرائح.

يمكنك تعيين اسم للعلامة المائية بحيث يمكنك في المستقبل، إذا رغبت في حذفها، العثور عليها في أشكال الشريحة بالاسم.

يمكنك تصميم العلامة المائية بأي طريقة؛ ومع ذلك، هناك ميزات شائعة في العلامات المائية مثل المحاذاة المركزية، الدوران، الموقع الأمامي، إلخ. سنستعرض كيفية استخدام هذه في الأمثلة أدناه.

## **علامة مائية نصية**

### **إضافة علامة مائية نصية إلى شريحة**

لإضافة علامة مائية نصية في PPT أو PPTX أو ODP، يمكنك أولاً إضافة شكل إلى الشريحة، ثم إضافة إطار نص إلى هذا الشكل. يُمثّل إطار النص فئة [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/). هذا النوع ليس موروثًا من [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/)، التي تحتوي على مجموعة واسعة من الخصائص لتحديد موضع العلامة المائية بطريقة مرنة. لذلك، يُغلف كائن [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) داخل كائن [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/). لإضافة نص العلامة المائية إلى الشكل، استخدم طريقة [add_text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/add_text_frame/#str) كما هو موضح أدناه.

```py
watermark_text = "CONFIDENTIAL"

with Presentation() as presentation:
    slide = presentation.slides[0]

    watermark_shape = slide.shapes.add_auto_shape(ShapeType.RECTANGLE, 100, 100, 400, 40)
    watermark_frame = watermark_shape.add_text_frame(watermark_text)
```

{{% alert color="primary" title="انظر أيضا" %}} 
- [كيفية استخدام فئة TextFrame](/slides/ar/python-net/text-formatting/)
{{% /alert %}}

### **إضافة علامة مائية نصية إلى عرض تقديمي**

إذا أردت إضافة علامة مائية نصية إلى العرض بالكامل (أي جميع الشرائح مرةً واحدة)، أضفها إلى [MasterSlide](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/). بقية المنطق هي نفسها عند إضافة علامة مائية إلى شريحة واحدة — أنشئ كائن [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) ثم أضف العلامة المائية إليه باستخدام طريقة [add_text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/add_text_frame/#str).

```py
watermark_text = "CONFIDENTIAL"

with Presentation() as presentation:
    master_slide = presentation.masters[0]

    watermark_shape = master_slide.shapes.add_auto_shape(ShapeType.RECTANGLE, 100, 100, 400, 40)
    watermark_frame = watermark_shape.add_text_frame(watermark_text)
```

{{% alert color="primary" title="انظر أيضا" %}} 
- [كيفية استخدام Slide Master](/slides/ar/python-net/slide-master/)
{{% /alert %}}

### **تعيين شفافية شكل العلامة المائية**

بشكل افتراضي، يُصمم شكل المستطيل بألوان تعبئة وخط. السطور التالية تجعل الشكل شفافًا.

```py
watermark_shape.fill_format.fill_type = FillType.NO_FILL
watermark_shape.line_format.fill_format.fill_type = FillType.NO_FILL
```

### **تعيين الخط للعلامة المائية النصية**

يمكنك تغيير خط العلامة المائية النصية كما هو موضح أدناه.

```py
text_format = watermark_frame.paragraphs[0].paragraph_format.default_portion_format
text_format.latin_font = FontData("Arial")
text_format.font_height = 50
```

### **تعيين لون نص العلامة المائية**

لتحديد لون نص العلامة المائية، استخدم الشفرة التالية:

```py
alpha = 150
red = 200
green = 200
blue = 200

fill_format = watermark_frame.paragraphs[0].paragraph_format.default_portion_format.fill_format
fill_format.fill_type = FillType.SOLID
fill_format.solid_fill_color.color = drawing.Color.from_argb(alpha, red, green, blue)
```

### **محاذاة العلامة المائية النصية إلى المركز**

يمكنك توسيط العلامة المائية على الشريحة، ولتحقيق ذلك، يمكنك تنفيذ التالي:

```py
slide_size = presentation.slide_size.size

watermark_width = 400
watermark_height = 40
watermark_x = (slide_size.width - watermark_width) / 2
watermark_y = (slide_size.height - watermark_height) / 2

watermark_shape = slide.shapes.add_auto_shape(
    ShapeType.RECTANGLE, watermark_x, watermark_y, watermark_width, watermark_height)

watermark_frame = watermark_shape.add_text_frame(watermark_text)
```

الصورة أدناه تُظهر النتيجة النهائية.

![علامة مائية نصية](text_watermark.png)

## **علامة مائية صورية**

### **إضافة علامة مائية صورية إلى عرض تقديمي**

لإضافة علامة مائية صورية إلى شريحة عرض، يمكنك تنفيذ التالي:

```py
with open("watermark.png", "rb") as image_stream:
    image = presentation.images.add_image(image_stream.read())

    watermark_shape.fill_format.fill_type = FillType.PICTURE
    watermark_shape.fill_format.picture_fill_format.picture.image = image
    watermark_shape.fill_format.picture_fill_format.picture_fill_mode = PictureFillMode.STRETCH
```

## **قفل العلامة المائية من التحرير**

إذا كان من الضروري منع تعديل العلامة المائية، استخدم خاصية [AutoShape.auto_shape_lock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/auto_shape_lock/) على الشكل. بهذه الخاصية، يمكنك حماية الشكل من الاختيار، إعادة التحجيم، إعادة التموضع، التجميع مع عناصر أخرى، قفل نصه من التحرير، وأكثر:

```py
# قفل شكل العلامة المائية من التعديل
watermark_shape.auto_shape_lock.select_locked = True
watermark_shape.auto_shape_lock.size_locked = True
watermark_shape.auto_shape_lock.text_locked = True
watermark_shape.auto_shape_lock.position_locked = True
watermark_shape.auto_shape_lock.grouping_locked = True
```

## **إحضار العلامة المائية إلى المقدمة**

في Aspose.Slides، يمكن تعيين ترتيب الأشكال عبر طريقة [ShapeCollection.reorder](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/reorder/#int-ishape). للقيام بذلك، عليك استدعاء هذه الطريقة من قائمة شرائح العرض وتمرير مرجع الشكل ورقم ترتيبه إلى الطريقة. بهذه الطريقة، يمكن إحضار الشكل إلى المقدمة أو إرساله إلى الخلف.

```py
shape_count = len(slide.shapes)
slide.shapes.reorder(shape_count - 1, watermark_shape)
```

## **تعيين دوران العلامة المائية**

فيما يلي مثال على كيفية ضبط دوران العلامة المائية لتكون مائلة قطريًا عبر الشريحة:

```py
diagonal_angle = math.atan(slide_size.height / slide_size.width) * 180 / math.pi

watermark_shape.rotation = float(diagonal_angle)
```

## **تعيين اسم للعلامة المائية**

تسمح لك Aspose.Slides بتعيين اسم للشكل. باستخدام اسم الشكل، يمكنك الوصول إليه في المستقبل لتعديله أو حذفه. لتعيين اسم شكل العلامة المائية، عينه إلى خاصية [AutoShape.name](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/name/):

```py
watermark_shape.name = "watermark"
```

## **إزالة العلامة المائية**

لإزالة شكل العلامة المائية، استخدم طريقة [AutoShape.name](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/name/) للعثور عليها في أشكال الشريحة. ثم، مرّر شكل العلامة المائية إلى طريقة [ShapeCollection.remove](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/remove/#ishape):

```py
slide_shapes = list(slide.shapes)
for shape in slide_shapes:
    if shape.name == "watermark":
        slide.shapes.remove(watermark_shape)
```

## **مثال حي**

قد ترغب في تجربة أدوات Aspose.Slides المجانية **Add Watermark** و**Remove Watermark** عبر الإنترنت.

![أدوات الإنترنت لإضافة وإزالة العلامات المائية](online_tools.png)

## **الأسئلة الشائعة**

**ما هي العلامة المائية ولماذا يجب استخدامها؟**

العلامة المائية هي تغطية نصية أو صورية تُطبق على الشرائح لتساعد في حماية الملكية الفكرية، تعزيز التعرف على العلامة التجارية، أو منع الاستخدام غير المصرح به للعروض.

**هل يمكنني إضافة علامة مائية إلى جميع الشرائح في عرض تقديمي؟**

نعم، تتيح لك Aspose.Slides إضافة علامة مائية إلى كل شريحة في العرض. يمكنك التنقل عبر جميع الشرائح وتطبيق إعدادات العلامة المائية على كل منها.

**كيف يمكنني تعديل شفافية العلامة المائية؟**

يمكنك تعديل شفافية العلامة المائية بتغيير إعدادات التعبئة ([FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/)) للشكل. يضمن ذلك أن تكون العلامة المائية خفيفة ولا تشتت الانتباه عن محتوى الشريحة.

**ما صيغ الصور المدعومة للعلامات المائية؟**

تدعم Aspose.Slides صيغ صور متعددة مثل PNG وJPEG وGIF وBMP وSVG وغير ذلك.

**هل يمكنني تخصيص الخط والنمط للعلامة المائية النصية؟**

نعم، يمكنك اختيار أي خط، حجم، ونمط لتتناسب مع تصميم عرضك وتضمن اتساق العلامة التجارية.

**كيف أغيّر موضع أو توجيه العلامة المائية؟**

يمكنك تعديل موضع وتوجيه العلامة المائية عن طريق تعديل إحداثيات الشكل، حجمه، وخصائص الدوران الخاصة به.