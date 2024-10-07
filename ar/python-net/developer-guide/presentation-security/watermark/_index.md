---
title: علامة مائية
type: docs
weight: 40
url: /python-net/watermark/
keywords:
- علامة مائية
- إضافة علامة مائية
- علامة مائية نصية
- علامة مائية صورة
- باور بوينت
- عرض تقديمي
- بايثون
- Aspose.Slides لـ بايثون عبر .NET
description: "إضافة علامات مائية نصية وصورية إلى عروض باور بوينت في بايثون"
---

## **حول العلامات المائية**

**العلامة المائية** في عرض تقديمي هي ختم نصي أو صوري يستخدم على شريحة أو عبر جميع شرائح العرض. عادة ما تُستخدم العلامة المائية للإشارة إلى أن العرض هو مسودة (مثل، علامة مائية "مسودة")، أنها تحتوي على معلومات سرية (مثل، علامة مائية "سري")، لتحديد الشركة التي تنتمي إليها (مثل، علامة مائية "اسم الشركة")، لتحديد مؤلف العرض، وما إلى ذلك. تساعد العلامة المائية في منع انتهاكات حقوق النشر بالإشارة إلى أنه لا ينبغي نسخ العرض. تُستخدم العلامات المائية في كلا من تنسيقات عروض باور بوينت وOpenOffice. في Aspose.Slides، يمكنك إضافة علامة مائية إلى تنسيقات ملفات باور بوينت PPT وPPTX وOpenOffice ODP.

في [**Aspose.Slides**](https://products.aspose.com/slides/python-net/)، هناك طرق مختلفة يمكنك من خلالها إنشاء علامات مائية في مستندات باور بوينت أو OpenOffice وتعديل تصميمها وسلوكها. الجانب المشترك هو أنه لإضافة علامات مائية نصية، ينبغي عليك استخدام فئة [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/)، ولإضافة علامات مائية صورة، استخدم فئة [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) أو املأ شكل علامة مائية بصورة. `PictureFrame` تنفذ الفئة [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) مما يتيح لك استخدام جميع إعدادات كائن الشكل المرنة. نظرًا لأن `TextFrame` ليست شكلاً وإعداداتها محدودة، فهي مغطاة ككائن [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/).

هناك طريقتان يمكن تطبيق العلامة المائية من خلالهما: على شريحة واحدة أو على جميع شرائح العرض. يتم استخدام القالب الرئيسي (Slide Master) لتطبيق علامة مائية على جميع شرائح العرض—تُضاف العلامة المائية إلى القالب الرئيسي، وتُصمم بالكامل هناك، وتطبق على جميع الشرائح دون التأثير على الإذن لتعديل العلامة المائية على الشرائح الفردية.

عادة ما تعتبر العلامة المائية غير متاحة للتحرير من قبل المستخدمين الآخرين. لمنع العلامة المائية (أو بالأحرى الشكل الأصلي للعلامة المائية) من التعديل، توفر Aspose.Slides وظيفة قفل الشكل. يمكن قفل شكل معين على شريحة عادية أو على قالب رئيسي. عند قفل شكل العلامة المائية على القالب الرئيسي، فإنه يبقى مقفلاً على جميع شرائح العرض.

يمكنك تعيين اسم للعلامة المائية بحيث إذا كنت ترغب في حذفها في المستقبل، يمكنك العثور عليها في أشكال الشريحة حسب الاسم.

يمكنك تصميم العلامة المائية بأي طريقة؛ ومع ذلك، عادة ما تكون هناك ميزات شائعة في العلامات المائية، مثل التمركز، الدوران، الموضع الأمامي، وما إلى ذلك. سوف ننظر في كيفية استخدام هذه الميزات في الأمثلة أدناه.

## **علامة مائية نصية**

### **إضافة علامة مائية نصية إلى شريحة**

لإضافة علامة مائية نصية في PPT أو PPTX أو ODP، يمكنك أولاً إضافة شكل إلى الشريحة، ثم إضافة إطار نصي إلى هذا الشكل. يتم تمثيل إطار النص بواسطة فئة [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/). هذا النوع لا يُرث من [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/)، الذي يحتوي على مجموعة واسعة من الخصائص لوضع العلامة المائية بطريقة مرنة. لذلك، يتم تغليف كائن [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) في كائن [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/). لإضافة نص العلامة المائية إلى الشكل، استخدم طريقة [add_text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/add_text_frame/#str) كما هو موضح أدناه.

```py
watermark_text = "سري"

with Presentation() as presentation:
    slide = presentation.slides[0]

    watermark_shape = slide.shapes.add_auto_shape(ShapeType.RECTANGLE, 100, 100, 400, 40)
    watermark_frame = watermark_shape.add_text_frame(watermark_text)
```

{{% alert color="primary" title="انظر أيضاً" %}} 
- [كيفية استخدام فئة TextFrame](/slides/python-net/text-formatting/)
{{% /alert %}}

### **إضافة علامة مائية نصية إلى العرض التقديمي**

إذا كنت ترغب في إضافة علامة مائية نصية إلى العرض التقديمي بالكامل (أي، جميع الشرائح مرة واحدة)، أضفها إلى [MasterSlide](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/). بقية المنطق مشابه لما هو عليه عند إضافة علامة مائية إلى شريحة واحدة — قم بإنشاء كائن [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) ثم أضف العلامة المائية إليه باستخدام طريقة [add_text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/add_text_frame/#str).

```py
watermark_text = "سري"

with Presentation() as presentation:
    master_slide = presentation.masters[0]

    watermark_shape = master_slide.shapes.add_auto_shape(ShapeType.RECTANGLE, 100, 100, 400, 40)
    watermark_frame = watermark_shape.add_text_frame(watermark_text)
```

{{% alert color="primary" title="انظر أيضاً" %}} 
- [كيفية استخدام القالب الرئيسي للشريحة](/slides/python-net/slide-master/)
{{% /alert %}}

### **تعيين شفافية شكل العلامة المائية**

بشكل افتراضي، يتم تنسيق الشكل المستطيل بألوان تعبئة وخط. تضع الأسطر التالية من التعليمات البرمجية الشكل في حالة شفافة.

```py
watermark_shape.fill_format.fill_type = FillType.NO_FILL
watermark_shape.line_format.fill_format.fill_type = FillType.NO_FILL
```

### **تعيين الخط لعلامة مائية نصية**

يمكنك تغيير خط نص العلامة المائية كما هو موضح أدناه.

```py
text_format = watermark_frame.paragraphs[0].paragraph_format.default_portion_format
text_format.latin_font = FontData("Arial")
text_format.font_height = 50
```

### **تعيين لون نص العلامة المائية**

لتعيين لون نص العلامة المائية، استخدم هذا الكود:

```py
alpha = 150
red = 200
green = 200
blue = 200

fill_format = watermark_frame.paragraphs[0].paragraph_format.default_portion_format.fill_format
fill_format.fill_type = FillType.SOLID
fill_format.solid_fill_color.color = drawing.Color.from_argb(alpha, red, green, blue)
```

### **محاذاة علامة مائية نصية في المنتصف**

من الممكن محاذاة العلامة المائية في وسط الشريحة، ولتحقيق ذلك، يمكنك القيام بما يلي:

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

تظهر الصورة أدناه النتيجة النهائية.

![العلامة المائية النصية](text_watermark.png)

## **علامة مائية صورية**

### **إضافة علامة مائية صورية إلى عرض تقديمي**

لإضافة علامة مائية صورية إلى شريحة عرض تقديمي، يمكنك القيام بما يلي:

```py
with open("watermark.png", "rb") as image_stream:
    image = presentation.images.add_image(image_stream.read())

    watermark_shape.fill_format.fill_type = FillType.PICTURE
    watermark_shape.fill_format.picture_fill_format.picture.image = image
    watermark_shape.fill_format.picture_fill_format.picture_fill_mode = PictureFillMode.STRETCH
```

## **قفل علامة مائية من التحرير**

إذا كانت هناك حاجة لمنع تعديل علامة مائية، استخدم خاصية [AutoShape.auto_shape_lock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/auto_shape_lock/) على الشكل. من خلال هذه الخاصية، يمكنك حماية الشكل من التحديد، تغيير الحجم، إعادة التمركز، التجميع مع عناصر أخرى، قفل نصه من التحرير، والمزيد:

```py
# قفل شكل العلامة المائية من التعديل
watermark_shape.auto_shape_lock.select_locked = True
watermark_shape.auto_shape_lock.size_locked = True
watermark_shape.auto_shape_lock.text_locked = True
watermark_shape.auto_shape_lock.position_locked = True
watermark_shape.auto_shape_lock.grouping_locked = True
```

## **تقديم علامة مائية إلى الأمام**

في Aspose.Slides، يمكن تعيين ترتيب Z للأشكال عبر طريقة [ShapeCollection.reorder](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/reorder/#int-ishape). لتحقيق ذلك، تحتاج إلى استدعاء هذه الطريقة من قائمة شرائح العرض وتمرير مرجع الشكل ورقم ترتيبه إلى الطريقة. بهذه الطريقة، من الممكن تقديم شكل إلى المقدمة أو إرساله إلى الجزء الخلفي من الشريحة. هذه الميزة مفيدة بشكل خاص إذا كنت بحاجة إلى وضع علامة مائية أمام العرض:

```py
shape_count = len(slide.shapes)
slide.shapes.reorder(shape_count - 1, watermark_shape)
```

## **تعيين دوران العلامة المائية**

إليك مثال على كيفية ضبط دوران العلامة المائية بحيث تكون موضوعة بشكل قطري عبر الشريحة:

```py
diagonal_angle = math.atan(slide_size.height / slide_size.width) * 180 / math.pi

watermark_shape.rotation = float(diagonal_angle)
```

## **تعيين اسم لعلامة مائية**

تسمح لك Aspose.Slides بتعيين اسم لشكل. باستخدام اسم الشكل، يمكنك الوصول إليه في المستقبل لتعديله أو حذفه. لتعيين اسم الشكل للعلامة المائية، عيّنه إلى خاصية [AutoShape.name](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/name/):

```py
watermark_shape.name = "علامة مائية"
```

## **إزالة علامة مائية**

لإزالة شكل العلامة المائية، استخدم طريقة [AutoShape.name](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/name/) للعثور عليه في أشكال الشريحة. ثم، مرر شكل العلامة المائية إلى طريقة [ShapeCollection.remove](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/remove/#ishape):

```py
slide_shapes = list(slide.shapes)
for shape in slide_shapes:
    if shape.name == "علامة مائية":
        slide.shapes.remove(watermark_shape)
```

## **مثال حي**

قد ترغب في التحقق من **Aspose.Slides المجانية** [إضافة علامة مائية](https://products.aspose.app/slides/watermark) و[إزالة علامة مائية](https://products.aspose.app/slides/watermark/remove-watermark) الأدوات عبر الإنترنت.

![أدوات على الإنترنت لإضافة وإزالة العلامات المائية](online_tools.png)