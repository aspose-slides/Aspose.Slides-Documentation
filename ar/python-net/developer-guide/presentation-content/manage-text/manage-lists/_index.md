---
title: إدارة القوائم النقطية والمرقّمة في العروض التقديمية بلغة Python
linktitle: إدارة القوائم
type: docs
weight: 70
url: /ar/python-net/manage-lists/
keywords:
- رصاصة
- قائمة نقطية
- قائمة مرقّمة
- رصاصة رمزية
- رصاصة صورة
- رصاصة مخصصة
- قائمة متعددة المستويات
- إنشاء رصاصة
- إضافة رصاصة
- إضافة قائمة
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "تعلم كيفية إنشاء وتنسيق القوائم النقطية، والقوائم المصورة، والقوائم متعددة المستويات، والقوائم المرقّمة في عروض PowerPoint وOpenDocument باستخدام Aspose.Slides لـ Python عبر .NET."
---
## **نظرة عامة**

Aspose.Slides for Python عبر .NET يتيح لك إنشاء وتنسيق القوائم النقطية والمرقمة في عروض PowerPoint وOpenDocument. عنصر القائمة هو فقرة تُتحكم إعدادات الرصاصة الخاصة به من خلال تنسيق الفقرة.

استخدم خاصية [Paragraph.paragraph_format](https://reference.aspose.com/slides/ar/python-net/aspose.slides/paragraph/paragraph_format/) للوصول إلى إعدادات القائمة على مستوى الفقرة. نقطة الدخول الرئيسية هي [ParagraphFormat.bullet](https://reference.aspose.com/slides/ar/python-net/aspose.slides/paragraphformat/bullet/)، التي تُعيد كائنًا من نوع [BulletFormat](https://reference.aspose.com/slides/ar/python-net/aspose.slides/bulletformat/). باستخدام هذا الكائن، يمكنك ضبط نوع الرصاصة، الرمز، الصورة، اللون، الحجم، نمط الترقيم، ورقم البداية.

تُظهر هذه المقالة كيفية:

- إنشاء قائمة نقطية برمز مخصص
- إنشاء رصاصة صورة
- إنشاء قائمة متعددة المستويات عبر ضبط عمق الفقرة
- إنشاء قائمة مرقّمة
- فحص وتغيير تنسيق القوائم في عرض تقديمي موجود

## **إنشاء قائمة نقطية**

لإنشاء قائمة نقطية، أضف كائنات [Paragraph](https://reference.aspose.com/slides/ar/python-net/aspose.slides/paragraph/) إلى [TextFrame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframe/) واضبط [BulletFormat.type](https://reference.aspose.com/slides/ar/python-net/aspose.slides/bulletformat/type/) إلى [BulletType.SYMBOL](https://reference.aspose.com/slides/ar/python-net/aspose.slides/bullettype/). يمكنك بعد ذلك ضبط [BulletFormat.char](https://reference.aspose.com/slides/ar/python-net/aspose.slides/bulletformat/char/)، و[BulletFormat.color](https://reference.aspose.com/slides/ar/python-net/aspose.slides/bulletformat/color/)، و[BulletFormat.height](https://reference.aspose.com/slides/ar/python-net/aspose.slides/bulletformat/height/) للتحكم في مظهر الرصاصة.

الكود التالي بلغة Python يوضح كيفية إنشاء قائمة نقطية في شريحة:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

def create_paragraph(text):
    paragraph = slides.Paragraph()
    paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph.paragraph_format.bullet.char = '*'
    paragraph.paragraph_format.indent = 15
    paragraph.paragraph_format.bullet.is_bullet_hard_color = slides.NullableBool.TRUE
    paragraph.paragraph_format.bullet.color.color = draw.Color.indian_red
    paragraph.paragraph_format.bullet.height = 100
    paragraph.text = text
    return paragraph


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 200, 50)

    text_frame = auto_shape.text_frame
    text_frame.paragraphs.clear()

    paragraph1 = create_paragraph("The first paragraph")
    text_frame.paragraphs.add(paragraph1)

    paragraph2 = create_paragraph("The second paragraph")
    text_frame.paragraphs.add(paragraph2)

    presentation.save("symbol_bullets.pptx", slides.export.SaveFormat.PPTX)
```

النتيجة:

![الرّموز النقطية](symbol_bullets.png)

## **إنشاء قائمة مرقّمة**

استخدم القوائم المرقّمة عندما يكون ترتيب العناصر مهمًا. اضبط [BulletFormat.type](https://reference.aspose.com/slides/ar/python-net/aspose.slides/bulletformat/type/) إلى [BulletType.NUMBERED](https://reference.aspose.com/slides/ar/python-net/aspose.slides/bullettype/). يمكنك أيضًا اختيار تنسيق ترقيم عبر [BulletFormat.numbered_bullet_style](https://reference.aspose.com/slides/ar/python-net/aspose.slides/bulletformat/numbered_bullet_style/) أو ضبط [BulletFormat.numbered_bullet_start_with](https://reference.aspose.com/slides/ar/python-net/aspose.slides/bulletformat/numbered_bullet_start_with/) عندما يجب أن تبدأ القائمة من قيمة غير 1.

الكود التالي بلغة Python يوضح كيفية إنشاء قائمة مرقّمة في شريحة:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 90, 80)

    text_frame = auto_shape.text_frame
    text_frame.paragraphs.clear()

    paragraph1 = slides.Paragraph()
    paragraph1.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    paragraph1.text = "Apple"
    text_frame.paragraphs.add(paragraph1)

    paragraph2 = slides.Paragraph()
    paragraph2.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    paragraph2.text = "Orange"
    text_frame.paragraphs.add(paragraph2)

    paragraph3 = slides.Paragraph()
    paragraph3.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    paragraph3.text = "Banana"
    text_frame.paragraphs.add(paragraph3)

    presentation.save("numbered_bullets.pptx", slides.export.SaveFormat.PPTX)
```

النتيجة:

![الرموز المرقمة](numbered_bullets.png)

## **إنشاء رصاصة صورة**

Aspose.Slides يتيح لك استبدال رمز الرصاصة العادي بصورة. تعمل رصاصات الصور بشكل أفضل مع صور بسيطة تظل قابلة للقراءة بحجم صغير، مثل الأيقونات أو ملفات PNG الشفافة الصغيرة.

{{% alert color="primary" %}}
من المثالي، إذا كنت تخطط لاستبدال رمز الرصاصة العادي بصورة، أن تختار رسمًا بسيطًا بخلفية شفافة. تُعد هذه الصور مناسبة كرموز رصاصات مخصصة.
{{% /alert %}}

لإنشاء رصاصة صورة، أضف صورة إلى [Presentation.images](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/images/) وعيّن كائن الصورة المرجع إلى [BulletFormat.picture](https://reference.aspose.com/slides/ar/python-net/aspose.slides/bulletformat/picture/). اضبط [BulletFormat.type](https://reference.aspose.com/slides/ar/python-net/aspose.slides/bulletformat/type/) إلى [BulletType.PICTURE](https://reference.aspose.com/slides/ar/python-net/aspose.slides/bullettype/) قبل إسناد الصورة.

لنفترض أن لدينا ملف "image.png":

![صورة للرصاصات](picture_for_bullets.png)

الكود التالي بلغة Python يوضح كيفية إنشاء رصاصات صورة في شريحة:

```py
import aspose.slides as slides

def create_paragraph(text, image):
    paragraph = slides.Paragraph()
    paragraph.paragraph_format.bullet.type = slides.BulletType.PICTURE
    paragraph.paragraph_format.bullet.picture.image = image
    paragraph.paragraph_format.indent = 15
    paragraph.paragraph_format.bullet.height = 100
    paragraph.text = text
    return paragraph


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 200, 50)

    text_frame = auto_shape.text_frame
    text_frame.paragraphs.clear()

    with open("image.png", "rb") as image_stream:
        bullet_image = presentation.images.add_image(image_stream)

    paragraph1 = create_paragraph("The first paragraph", bullet_image)
    text_frame.paragraphs.add(paragraph1)

    paragraph2 = create_paragraph("The second paragraph", bullet_image)
    text_frame.paragraphs.add(paragraph2)

    presentation.save("picture_bullets.pptx", slides.export.SaveFormat.PPTX)
```

النتيجة:

![الرصاصات المصورة](picture_bullets.png)

## **إنشاء قائمة متعددة المستويات**

استخدم [ParagraphFormat.depth](https://reference.aspose.com/slides/ar/python-net/aspose.slides/paragraphformat/depth/) لوضع عناصر القائمة على مستويات مختلفة. المستوى 0 هو المستوى العلوي، المستوى 1 متداخل تحته، وهكذا.

الكود التالي بلغة Python يوضح كيفية إنشاء قائمة نقطية متعددة المستويات:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 260, 110)

    text_frame = auto_shape.text_frame
    text_frame.paragraphs.clear()

    paragraph1 = slides.Paragraph()
    paragraph1.paragraph_format.depth = 0
    paragraph1.text = "My text - Depth 0"
    text_frame.paragraphs.add(paragraph1)

    paragraph2 = slides.Paragraph()
    paragraph2.paragraph_format.depth = 1
    paragraph2.text = "My text - Depth 1"
    text_frame.paragraphs.add(paragraph2)

    paragraph3 = slides.Paragraph()
    paragraph3.paragraph_format.depth = 2
    paragraph3.text = "My text - Depth 2"
    text_frame.paragraphs.add(paragraph3)

    paragraph4 = slides.Paragraph()
    paragraph4.paragraph_format.depth = 3
    paragraph4.text = "My text - Depth 3"
    text_frame.paragraphs.add(paragraph4)

    presentation.save("multilevel_bullets.pptx", slides.export.SaveFormat.PPTX)
```

النتيجة:

![القائمة المتعددة المستويات](multilevel_list.png)

## **تغيير قائمة موجودة**

لتغيير تنسيق القائمة في عرض تقديمي موجود، احصل على الفقرة المستهدفة وقم بتحديث إعدادات [ParagraphFormat.bullet](https://reference.aspose.com/slides/ar/python-net/aspose.slides/paragraphformat/bullet/). يمكن استخدام نفس الخصائص المستخدمة لإنشاء القوائم لفحص أو تعديل القوائم التي تم تحميلها من ملف PPT أو PPTX أو ODP.

الكود التالي بلغة Python يُغيّر الفقرة الأولى في إطار نص ليستخدم نمط قائمة مرقّمة:

```py
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    paragraph.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    paragraph.paragraph_format.bullet.numbered_bullet_style = slides.NumberedBulletStyle.BULLET_ROMAN_UC_PERIOD
    paragraph.paragraph_format.bullet.numbered_bullet_start_with = 1
    paragraph.paragraph_format.margin_left = 30
    paragraph.paragraph_format.indent = -20

    presentation.save("updated_list.pptx", slides.export.SaveFormat.PPTX)
```

## **الأسئلة الشائعة**

**هل يمكن تصدير القوائم النقطية والمرقّمة إلى PDF أو صور؟**

نعم. Aspose.Slides يحافظ على تنسيق القوائم عندما يدعم التنسيق الهدف تخطيط النص وميزات الرصاصة المقابلة.

**هل يمكن تعديل القوائم في العروض التقديمية الموجودة؟**

نعم. حمّل العرض التقديمي، وصل إلى الفقرة المستهدفة، افحص أو حدّث إعدادات [ParagraphFormat.bullet](https://reference.aspose.com/slides/ar/python-net/aspose.slides/paragraphformat/bullet/) الخاصة بها، ثم احفظ العرض التقديمي.

**هل يمكن أن تحتوي القوائم على نص غير لاتيني؟**

نعم. يمكن أن يحتوي نص عنصر القائمة على أحرف Unicode، لذا يمكنك إنشاء قوائم في عروض تقديمية متعددة اللغات. تأكد من أن الخطوط المستخدمة في العرض تدعم الأحرف التي تحتاجها.