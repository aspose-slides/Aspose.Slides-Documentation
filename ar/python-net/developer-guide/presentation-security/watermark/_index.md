---
title: إضافة علامات مائية إلى العروض التقديمية في Python
linktitle: علامة مائية
type: docs
weight: 40
url: /ar/python-net/developer-guide/presentation-security/watermark/
keywords:
- علامة مائية
- علامة مائية نصية
- علامة مائية صورة
- إضافة علامة مائية
- تعديل علامة مائية
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
description: "تعرف على كيفية إدارة علامات مائية نصية وصورية في عروض PowerPoint وOpenDocument باستخدام Python للإشارة إلى مسودة أو معلومات سرية أو حقوق نشر وغيرها."
---

## **حول العلامات المائية**

**العلامة المائية** في العرض التقديمي هي طابع نصي أو صوري يُستخدم على شريحة أو على جميع شرائح العرض. عادةً ما تُستعمل العلامة المائية للإشارة إلى أن العرض مسودة (مثال: العلامة المائية "مسودة")، أو أنه يحتوي على معلومات سرية (مثال: العلامة المائية "سرية")، أو لتحديد الشركة المالكة (مثال: العلامة المائية "اسم الشركة")، أو لتحديد مؤلف العرض، إلخ. تساعد العلامة المائية في منع انتهاك حقوق النشر عبر الإشارة إلى أن العرض لا يجب نسخه. تُستخدم العلامات المائية في صيغتي PowerPoint وOpenOffice. في Aspose.Slides، يمكنك إضافة علامة مائية إلى صيغ ملفات PowerPoint PPT وPPTX وOpenOffice ODP.

في [**Aspose.Slides**](https://products.aspose.com/slides/python-net/)، هناك طرق متعددة لإنشاء علامات مائية في مستندات PowerPoint أو OpenOffice وتعديل تصميمها وسلوكها. الجانب المشترك هو أنه لإضافة علامات مائية نصية، يجب استخدام الفصل [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/)، ولإضافة علامات مائية صورية، استخدم الفصل [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) أو ملء شكل العلامة المائية بصورة. `PictureFrame` يطبق الفصل [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) مما يتيح لك استخدام جميع إعدادات الشكل المرنة. بما أن `TextFrame` ليس شكلاً وإعداداته محدودة، فُرص على تغليفه في كائن [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/).

هناك طريقتان لتطبيق العلامة المائية: على شريحة واحدة أو على جميع شرائح العرض. يُستخدم Slide Master لتطبيق العلامة المائية على جميع الشرائح — تُضاف العلامة المائية إلى Slide Master، تُصمم بالكامل هناك، وتُطبق على جميع الشرائح دون التأثير على إمكانية تعديل العلامة المائية على الشرائح الفردية.

عادةً ما تُعتبر العلامة المائية غير قابلة للتعديل من قبل المستخدمين الآخرين. لمنع تعديل العلامة المائية (أو بالأحرى الشكل الأب للعلامة المائية)، توفر Aspose.Slides خاصية قفل الشكل. يمكن قفل شكل معين على شريحة عادية أو على Slide Master. عندما يُقفل شكل العلامة المائية على Slide Master، سيُقفل على جميع شرائح العرض.

يمكنك تعيين اسم للعلامة المائية بحيث يمكنك مستقبلاً العثور عليها بحذفها عبر اسمها في أشكال الشريحة.

يمكنك تصميم العلامة المائية بأي طريقة؛ ومع ذلك، غالبًا ما توجد خصائص مشتركة في العلامات المائية، مثل المحاذاة للوسط، الدوران، الموضع الأمامي، إلخ. سنوضح كيفية استخدام هذه الخصائص في الأمثلة أدناه.

## **علامة مائية نصية**

### **إضافة علامة مائية نصية إلى شريحة**

لإضافة علامة مائية نصية في PPT أو PPTX أو ODP، يمكنك أولاً إضافة شكل إلى الشريحة، ثم إضافة إطار نص إلى هذا الشكل. يُمثَّل إطار النص بالفصل [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/). هذا النوع غير مُورّث من [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/)، الذي يحتوي على مجموعة واسعة من الخصائص لتحديد موقع العلامة المائية بطريقة مرنة. لذلك، يُغلف كائن [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) داخل كائن [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/). لإضافة نص العلامة المائية إلى الشكل، استخدم طريقة [add_text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/add_text_frame/#str) كما هو موضح أدناه.

```py
watermark_text = "CONFIDENTIAL"

with Presentation() as presentation:
    slide = presentation.slides[0]

    watermark_shape = slide.shapes.add_auto_shape(ShapeType.RECTANGLE, 100, 100, 400, 40)
    watermark_frame = watermark_shape.add_text_frame(watermark_text)
```

{{% alert color="primary" title="انظر أيضًا" %}} 
- [كيفية استخدام الفصل TextFrame](/slides/ar/python-net/text-formatting/)
{{% /alert %}}

### **إضافة علامة مائية نصية إلى عرض تقديمي**

إذا رغبت في إضافة علامة مائية نصية إلى العرض بالكامل (أي جميع الشرائح مرة واحدة)، أضفها إلى [MasterSlide](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/). بقية المنطق هي نفسها كما عند إضافة علامة مائية إلى شريحة واحدة — أنشئ كائنًا من نوع [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) ثم أضف العلامة المائية إليه باستخدام طريقة [add_text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/add_text_frame/#str).

```py
watermark_text = "CONFIDENTIAL"

with Presentation() as presentation:
    master_slide = presentation.masters[0]

    watermark_shape = master_slide.shapes.add_auto_shape(ShapeType.RECTANGLE, 100, 100, 400, 40)
    watermark_frame = watermark_shape.add_text_frame(watermark_text)
```

{{% alert color="primary" title="انظر أيضًا" %}} 
- [كيفية استخدام Slide Master](/slides/ar/python-net/slide-master/)
{{% /alert %}}

### **تعيين شفافية شكل العلامة المائية**

بشكل افتراضي، يُصبح شكل المستطيل مُصممًا بتعبئة ولون حد. تجعل السطور التالية الشكل شفافًا.

```py
watermark_shape.fill_format.fill_type = FillType.NO_FILL
watermark_shape.line_format.fill_format.fill_type = FillType.NO_FILL
```

### **تعيين خط العلامة المائية النصية**

يمكنك تغيير خط العلامة المائية النصية كما هو موضح أدناه.

```py
text_format = watermark_frame.paragraphs[0].paragraph_format.default_portion_format
text_format.latin_font = FontData("Arial")
text_format.font_height = 50
```

### **تعيين لون نص العلامة المائية**

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

### **تمركز العلامة المائية النصية**

يمكن تمركز العلامة المائية على الشريحة، وذلك عبر ما يلي:

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

الصورة أدناه توضح النتيجة النهائية.

![The text watermark](text_watermark.png)

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

## **قفل العلامة المائية من التحرير**

إذا كان من الضروري منع تعديل العلامة المائية، استخدم الخاصية [AutoShape.auto_shape_lock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/auto_shape_lock/) على الشكل. بهذه الخاصية يمكنك حماية الشكل من الاختيار، تغيير الحجم، إعادة التوضع، التجميع مع عناصر أخرى، قفل النص من التحرير، وأكثر:

```py
# قفل شكل العلامة المائية من التعديل
watermark_shape.auto_shape_lock.select_locked = True
watermark_shape.auto_shape_lock.size_locked = True
watermark_shape.auto_shape_lock.text_locked = True
watermark_shape.auto_shape_lock.position_locked = True
watermark_shape.auto_shape_lock.grouping_locked = True
```

## **إحضار العلامة المائية إلى الأمام**

في Aspose.Slides، يمكن ضبط ترتيب الشكل في محور Z عبر طريقة [ShapeCollection.reorder](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/reorder/#int-ishape). للقيام بذلك، استدعِ هذه الطريقة من قائمة شرائح العرض ومرّر مرجع الشكل ورقمه الترتيبي. بهذه الطريقة يمكن إحضار الشكل إلى الأمام أو إرساله إلى الخلف. هذه الميزة مفيدة خصوصًا إذا أردت وضع العلامة المائية أمام محتوى العرض:

```py
shape_count = len(slide.shapes)
slide.shapes.reorder(shape_count - 1, watermark_shape)
```

## **تعيين دوران العلامة المائية**

فيما يلي مثال على تعديل دوران العلامة المائية لتكون مائلة قطريًا عبر الشريحة:

```py
diagonal_angle = math.atan(slide_size.height / slide_size.width) * 180 / math.pi

watermark_shape.rotation = float(diagonal_angle)
```

## **تعيين اسم للعلامة المائية**

تسمح Aspose.Slides بتعيين اسم للشكل. باستخدام اسم الشكل يمكنك الوصول إليه مستقبلاً لتعديله أو حذفه. لتعيين اسم شكل العلامة المائية، عيّن الخاصية [AutoShape.name](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/name/):

```py
watermark_shape.name = "watermark"
```

## **إزالة العلامة المائية**

لإزالة شكل العلامة المائية، استخدم طريقة [AutoShape.name](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/name/) للعثور عليه في أشكال الشريحة. ثم مرّر شكل العلامة المائية إلى طريقة [ShapeCollection.remove](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/remove/#ishape):

```py
slide_shapes = list(slide.shapes)
for shape in slide_shapes:
    if shape.name == "watermark":
        slide.shapes.remove(watermark_shape)
```

## **مثال حي**

قد ترغب في تجربة أدوات **Aspose.Slides المجانية** لإضافة العلامة المائية [Add Watermark](https://products.aspose.app/slides/watermark) وإزالة العلامة المائية [Remove Watermark](https://products.aspose.app/slides/watermark/remove-watermark) عبر الإنترنت.

![Online tools to add and remove watermarks](online_tools.png)

## **الأسئلة المتكررة**

**ما هي العلامة المائية ولماذا يجب استخدامها؟**

العلامة المائية هي طبقة نصية أو صورية تُطبق على الشرائح للمساعدة في حماية الملكية الفكرية، تعزيز التعرف على العلامة التجارية، أو منع الاستخدام غير المصرح به للعروض.

**هل يمكنني إضافة علامة مائية إلى جميع الشرائح في العرض؟**

نعم، يتيح Aspose.Slides إضافة علامة مائية إلى كل شريحة في العرض. يمكنك التجول عبر جميع الشرائح وتطبيق إعدادات العلامة المائية على كل منها.

**كيف يمكنني تعديل شفافية العلامة المائية؟**

يمكنك تعديل شفافية العلامة المائية عن طريق تعديل إعدادات التعبئة ([FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/)) للشكل. يضمن ذلك أن تكون العلامة المائية خفيفة ولا تشوش محتوى الشريحة.

**ما صيغ الصور المدعومة للعلامات المائية؟**

يدعم Aspose.Slides صيغ صور متعددة مثل PNG وJPEG وGIF وBMP وSVG وغيرها.

**هل يمكنني تخصيص الخط وأسلوب العلامة المائية النصية؟**

نعم، يمكنك اختيار أي خط وحجم وأسلوب لتتناسب مع تصميم عرضك وتحافظ على اتساق العلامة التجارية.

**كيف أغير موضع أو اتجاه العلامة المائية؟**

يمكنك تعديل موضع واتجاه العلامة المائية عن طريق تعديل إحداثيات الشكل، حجمه، وخصائص الدوران.