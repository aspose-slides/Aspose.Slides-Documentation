---
title: إضافة علامات مائية إلى العروض التقديمية في بايثون
linktitle: علامة مائية
type: docs
weight: 40
url: /ar/python-net/watermark/
keywords:
- علامة مائية
- علامة مائية نصية
- علامة مائية صورة
- إضافة علامة مائية
- تغيير علامة مائية
- إزالة علامة مائية
- حذف علامة مائية
- إضافة علامة مائية إلى PPT
- إضافة علامة مائية إلى PPTX
- إضافة علامة مائية إلى ODP
- إزالة علامة مائية من PPT
- إزالة علامة مائية من PPTX
- إزالة علامة مائية من ODP
- حذف علامة مائية من PPT
- حذف علامة مائية من PPTX
- حذف علامة مائية من ODP
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "تعرف على كيفية إدارة العلامات المائية النصية والصورية في عروض PowerPoint وOpenDocument باستخدام بايثون للإشارة إلى مسودة، معلومات سرية، حقوق طبع ونشر، والمزيد."
---

## **حول العلامات المائية**

**العلامة المائية** في العرض التقديمي هي ختم نصي أو صوري يُستخدم على شريحة واحدة أو على جميع شرائح العرض. عادةً ما تُستخدم العلامة المائية للإشارة إلى أن العرض مسودة (مثل علامة "مسودة")، أو يحتوي على معلومات سرية (مثل علامة "سري")، أو لتحديد الشركة المالكة (مثل علامة "اسم الشركة")، أو لتحديد مؤلف العرض، إلخ. تساعد العلامة المائية في منع انتهاكات حقوق النشر من خلال الإشارة إلى أنه لا يجب نسخ العرض. تُستعمل العلامات المائية في صيغ PowerPoint وOpenOffice. في Aspose.Slides، يمكنك إضافة علامة مائية إلى ملفات PowerPoint PPT، PPTX، وOpenOffice ODP.

في [**Aspose.Slides**](https://products.aspose.com/slides/python-net/)، هناك طرق مختلفة لإنشاء علامات مائية في مستندات PowerPoint أو OpenOffice وتعديل تصميمها وسلوكها. الجانب المشترك هو أنه لإضافة علامات مائية نصية، يجب استخدام فئة [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/)، ولإضافة علامات مائية صورية، استخدم فئة [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) أو املأ شكل العلامة المائية بصورة. `PictureFrame` تنفذ فئة [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) مما يتيح لك استخدام جميع الإعدادات المرنة لكائن الشكل. بما أن `TextFrame` ليست شكلاً وإعداداتها محدودة، فتم تغليفها في كائن [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/).

هناك طريقتان لتطبيق العلامة المائية: على شريحة واحدة أو على جميع شرائح العرض. يُستخدم Slide Master لتطبيق العلامة المائية على جميع الشرائح — تُضاف العلامة المائية إلى الـ Slide Master، يتم تصميمها بالكامل هناك، وتُطبق على جميع الشرائح دون التأثير على إمكانية تعديل العلامة على الشرائح الفردية.

عادةً ما تُعتبر العلامة المائية غير قابلة للتحرير من قبل المستخدمين الآخرين. لمنع تعديل العلامة المائية (أو شكلها الأب)، يوفر Aspose.Slides وظيفة قفل الأشكال. يمكن قفل شكل معين على شريحة عادية أو على Slide Master. عندما يتم قفل شكل العلامة المائية على الـ Slide Master، سيُقفل على جميع شرائح العرض.

يمكنك تعيين اسم للعلامة المائية بحيث يمكنك مستقبلاً العثور عليها في أشكال الشريحة وحذفها إذا رغبت.

يمكنك تصميم العلامة المائية بأي طريقة؛ ومع ذلك، هناك سمات شائعة عادةً في العلامات المائية مثل المحاذاة في الوسط، الدوران، الموضع الأمامي، إلخ. سنستعرض كيفية استخدام هذه السمات في الأمثلة أدناه.

## **علامة مائية نصية**

### **إضافة علامة مائية نصية إلى شريحة**

لإضافة علامة مائية نصية في PPT أو PPTX أو ODP، يمكنك أولاً إضافة شكل إلى الشريحة، ثم إضافة إطار نص إلى هذا الشكل. يُمثَّل إطار النص بفئة [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/). هذا النوع لا يُورث من [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/)، الذي يحتوي على مجموعة واسعة من الخصائص لتحديد موضع العلامة المائية بطريقة مرنة. لذلك، يُغلف كائن [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) في كائن [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/). لإضافة نص العلامة المائية إلى الشكل، استخدم طريقة [add_text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/add_text_frame/#str) كما هو موضح أدناه.

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

إذا رغبت في إضافة علامة مائية نصية إلى كامل العرض (أي إلى جميع الشرائح مرة واحدة)، أضفها إلى [MasterSlide](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/). باقي المنطق هو نفسه عند إضافة علامة مائية إلى شريحة واحدة — أنشئ كائن [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) ثم أضف العلامة المائية إليه باستخدام طريقة [add_text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/add_text_frame/#str).

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

### **ضبط شفافية شكل العلامة المائية**

بشكل افتراضي، يتم تنسيق الشكل المستطيل بألوان التعبئة والخط. السطرين التاليين يجعلان الشكل شفافاً.

```py
watermark_shape.fill_format.fill_type = FillType.NO_FILL
watermark_shape.line_format.fill_format.fill_type = FillType.NO_FILL
```

### **ضبط الخط لعلامة مائية نصية**

يمكنك تغيير خط العلامة المائية النصية كما هو موضح أدناه.

```py
text_format = watermark_frame.paragraphs[0].paragraph_format.default_portion_format
text_format.latin_font = FontData("Arial")
text_format.font_height = 50
```

### **ضبط لون نص العلامة المائية**

لتعيين لون نص العلامة المائية، استخدم الشيفرة التالية:

```py
alpha = 150
red = 200
green = 200
blue = 200

fill_format = watermark_frame.paragraphs[0].paragraph_format.default_portion_format.fill_format
fill_format.fill_type = FillType.SOLID
fill_format.solid_fill_color.color = drawing.Color.from_argb(alpha, red, green, blue)
```

### **محاذاة علامة مائية نصية في الوسط**

يمكنك مركزية العلامة المائية على الشريحة كما يلي:

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

![The text watermark](text_watermark.png)

## **علامة مائية صورية**

### **إضافة علامة مائية صورية إلى عرض تقديمي**

لإضافة علامة مائية صورية إلى شريحة عرض تقديمي، يمكنك تنفيذ ما يلي:

```py
with open("watermark.png", "rb") as image_stream:
    image = presentation.images.add_image(image_stream.read())

    watermark_shape.fill_format.fill_type = FillType.PICTURE
    watermark_shape.fill_format.picture_fill_format.picture.image = image
    watermark_shape.fill_format.picture_fill_format.picture_fill_mode = PictureFillMode.STRETCH
```

## **قفل علامة مائية من التحرير**

إذا كان من الضروري منع تحرير العلامة المائية، استخدم الخاصية [AutoShape.auto_shape_lock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/auto_shape_lock/) على الشكل. تتيح لك هذه الخاصية حماية الشكل من الاختيار، تغيير الحجم، إعادة التموقع، التجميع مع عناصر أخرى، قفل النص من التحرير، وأكثر من ذلك:

```py
# Lock the watermark shape from modifying
watermark_shape.auto_shape_lock.select_locked = True
watermark_shape.auto_shape_lock.size_locked = True
watermark_shape.auto_shape_lock.text_locked = True
watermark_shape.auto_shape_lock.position_locked = True
watermark_shape.auto_shape_lock.grouping_locked = True
```

## **إحضار علامة مائية إلى الأمام**

في Aspose.Slides، يمكن تحديد ترتيب الأشكال عبر طريقة [ShapeCollection.reorder](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/reorder/#int-ishape). للقيام بذلك، استدعِ الطريقة من قائمة شرائح العرض ومرّر مرجع الشكل ورقمه المرتب:

```py
shape_count = len(slide.shapes)
slide.shapes.reorder(shape_count - 1, watermark_shape)
```

## **ضبط دوران العلامة المائية**

فيما يلي مثال برمجي لضبط دوران العلامة المائية بحيث تكون مائلة قطرياً عبر الشريحة:

```py
diagonal_angle = math.atan(slide_size.height / slide_size.width) * 180 / math.pi

watermark_shape.rotation = float(diagonal_angle)
```

## **تعيين اسم للعلامة المائية**

يسمح Aspose.Slides بتعيين اسم للشكل. باستخدام اسم الشكل، يمكنك الوصول إليه لاحقاً لتعديله أو حذفه. لتعيين اسم لشكل العلامة المائية، عيّن الخاصية [AutoShape.name](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/name/):

```py
watermark_shape.name = "watermark"
```

## **إزالة علامة مائية**

لإزالة شكل العلامة المائية، استخدم طريقة [AutoShape.name](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/name/) للعثور عليه ضمن أشكال الشريحة. ثم مرّر الشكل إلى طريقة [ShapeCollection.remove](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/remove/#ishape):

```py
slide_shapes = list(slide.shapes)
for shape in slide_shapes:
    if shape.name == "watermark":
        slide.shapes.remove(watermark_shape)
```

## **مثال حي**

قد ترغب في تجربة أدوات Aspose.Slides المجانية **Add Watermark** و**Remove Watermark** عبر الإنترنت:

![Online tools to add and remove watermarks](online_tools.png)

## **الأسئلة الشائعة**

**ما هي العلامة المائية ولماذا يجب استخدامها؟**

العلامة المائية هي طبقة نصية أو صورية تُطبق على الشرائح لتساعد في حماية الملكية الفكرية، تعزيز التعرف على العلامة التجارية، أو منع الاستخدام غير المصرح به للعرض.

**هل يمكنني إضافة علامة مائية إلى جميع الشرائح في عرض تقديمي؟**

نعم، يتيح Aspose.Slides إضافة علامة مائية إلى كل شريحة في العرض. يمكنك تكرار جميع الشرائح وتطبيق إعدادات العلامة المائية على كل منها.

**كيف يمكنني ضبط شفافية العلامة المائية؟**

يمكنك تعديل شفافية العلامة المائية عن طريق تغيير إعدادات التعبئة ([FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/)) للشكل. هذا يضمن أن تكون العلامة المائية خفيفة ولا تشوش محتوى الشريحة.

**ما صيغ الصور المدعومة للعلامات المائية؟**

يدعم Aspose.Slides صيغ صور متعددة مثل PNG، JPEG، GIF، BMP، SVG، وغيرها.

**هل يمكنني تخصيص الخط والنمط للعلامة المائية النصية؟**

نعم، يمكنك اختيار أي خط، حجم، ونمط يتناسب مع تصميم العرض ويحافظ على تناسق العلامة التجارية.

**كيف أغير موضع أو اتجاه العلامة المائية؟**

يمكنك تعديل موضع واتجاه العلامة المائية بتغيير إحداثيات الشكل، حجمه، وخصائص الدوران.