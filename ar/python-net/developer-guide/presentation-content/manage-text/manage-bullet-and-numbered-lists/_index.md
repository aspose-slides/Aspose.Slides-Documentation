---
title: إدارة القوائم النقطية والعددية في العروض التقديمية باستخدام بايثون
linktitle: إدارة القوائم
type: docs
weight: 70
url: /ar/python-net/manage-bullet-and-numbered-lists/
keywords:
- نقطة
- قائمة نقطية
- قائمة رقمية
- نقطة رمزية
- نقطة صورة
- نقطة مخصصة
- قائمة متعددة المستويات
- إنشاء نقطة
- إضافة نقطة
- إضافة قائمة
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "تعلم كيفية إدارة القوائم النقطية والعددية في عروض PowerPoint وOpenDocument باستخدام Aspose.Slides for Python عبر .NET. دليل خطوة بخطوة مع أمثلة على الشفرة لمساعدتك على البدء بسرعة."
---

## **نظرة عامة**

إدارة القوائم النقطية والعددية بفعالية أمر مهم عند إنشاء عروض تقديمية ذات تأثير. باستخدام Aspose.Slides for Python، يمكنك بسهولة أتمتة تنسيق القوائم في شرائحك برمجياً. يرشدك هذا المقال من خلال أمثلة واضحة على كيفية إنشاء وتعديل وتخصيص القوائم النقطية والعددية باستخدام Python. اكتشف طرقًا بسيطة ولكن قوية للتحكم في الإزاحة، والتنسيق، وأنظمة الترقيم، والنقاط، مما يجعل عروضك تبدو احترافية ومتسقة في كل مرة.

**لماذا نستخدم القوائم النقطية؟**

تساعد القوائم النقطية على تنظيم المعلومات وعرضها بوضوح، مما يعزز قابلية القراءة والتفاعل. عادةً ما تخدم القائمة النقطية ثلاثة أغراض رئيسية:

- تسلط الضوء على المعلومات الهامة، مما يجذب الانتباه فورًا.
- تمكّن القراء من مسح النص بسرعة وتحديد النقاط الرئيسة.
- تنقل التفاصيل الأساسية بكفاءة في صيغة مختصرة.

**لماذا نستخدم القوائم العددية؟**

القوائم العددية أداة قيمة أخرى لتنظيم المحتوى وعرضه بوضوح. تكون مفيدة خصوصًا عندما يكون ترتيب أو تسلسل العناصر مهمًا. استخدم القوائم العددية بدلًا من القوائم النقطية عندما يجب أن تتبع الخطوات أو العناصر ترتيبًا محددًا (مثل *الخطوة 1، الخطوة 2، الخطوة 3*، إلخ)، أو عندما تحتاج إلى الإشارة إلى خطوات معينة لاحقًا في النص (مثل *الرجوع إلى الخطوة 3*). يجعل ذلك التعليمات أو الشرح أكثر وضوحًا وسهولة في المتابعة، ويضمن إمكانية التنقل والإشارة إلى المحتوى بسهولة.

## **إنشاء نقاط رمزية**

لإنشاء قائمة نقطية، اتبع الخطوات التالية:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. الوصول إلى الشريحة (التي تريد إضافة القائمة النقطية إليها) من مجموعة الشرائح باستخدام كائن [ISlide](https://reference.aspose.com/slides/python-net/aspose.slides/islide/).
1. إضافة [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) إلى الشريحة المحددة.
1. الوصول إلى [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) للشكل المضاف.
1. إزالة الفقرة الافتراضية في إطار النص.
1. إنشاء الفقرة الأولى باستخدام الفئة [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/).
1. ضبط نوع النقطة إلى `SYMBOL`، وتعريف حرف النقطة.
1. ضبط نص الفقرة.
1. ضبط إزاحة الفقرة للتحكم في موضع النقطة.
1. ضبط لون النقطة.
1. ضبط ارتفاع النقطة.
1. إضافة الفقرة التي تم إنشاؤها إلى مجموعة فقرات إطار النص.
1. إضافة فقرة ثانية وتكرار الخطوات 7–12.
1. حفظ العرض التقديمي.

الكود التالي في Python يوضح كيفية إنشاء قائمة نقطية في شريحة:
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

![النقاط الرمزية](symbol_bullets.png)

## **إنشاء نقاط صورة**

يتيح Aspose.Slides for Python via .NET تخصيص النقاط في القوائم النقطية. يمكنك استبدال النقاط القياسية برموز أو صور مخصصة. إذا رغبت في إضافة اهتمام بصري إلى قائمة أو جذب مزيد من الانتباه إلى مدخلات محددة، يمكنك استخدام صورتك الخاصة كنقطة.

{{% alert color="primary" %}}
من المثالي، إذا كنت تخطط لاستبدال رمز النقطة العادي بصورة، أن تختار رسماً بسيطًا بخلفية شفافة. تعمل هذه الصور جيدًا كرموز نقاط مخصصة.

ضع في الاعتبار أن الصورة سيتم تصغيرها إلى حجم صغير جدًا. لهذا السبب، نوصي بشدة باختيار صورة تبقى واضحة وذات فاعلية بصرية عندما تُستخدم كنقطة في قائمة.
{{% /alert %}}

لإنشاء نقطة صورة، اتبع الخطوات التالية:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. الوصول إلى الشريحة المطلوبة من مجموعة الشرائح باستخدام كائن [ISlide](https://reference.aspose.com/slides/python-net/aspose.slides/islide/).
1. إضافة [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) إلى الشريحة المحددة باستخدام طريقة `add_auto_shape`.
1. الوصول إلى [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) للشكل المضاف.
1. إزالة الفقرة الافتراضية من إطار النص.
1. تحميل صورة من القرص، وإضافتها إلى [Presentation.images](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/images/)، والحصول على مثيل [IPPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ippimage/) الذي تُرجعه طريقة [add_image](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/#methods).
1. إنشاء مثيل الفقرة الأولى باستخدام الفئة [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/).
1. ضبط نوع النقطة إلى `PICTURE`، ثم تعيين الصورة.
1. ضبط نص الفقرة.
1. ضبط إزاحة الفقرة لتحديد موضع النقطة.
1. ضبط لون النقطة.
1. ضبط ارتفاع النقطة.
1. إضافة الفقرة إلى مجموعة فقرات إطار النص.
1. إضافة فقرة ثانية وتكرار الخطوات 8–13.
1. حفظ العرض التقديمي.

لنفترض أن لدينا ملفًا يسمى "image.png":

![صورة للنقاط](picture_for_bullets.png)

الكود التالي في Python يوضح كيفية إنشاء نقاط صورة في شريحة:
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

![النقاط الصورة](picture_bullets.png)

## **إنشاء قوائم متعددة المستويات**

لإنشاء قائمة نقطية تحتوي على عناصر على مستويات متعددة (قوائم فرعية تحت النقاط الرئيسية)، اتبع الخطوات التالية:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. الوصول إلى الشريحة المطلوبة من مجموعة الشرائح باستخدام كائن [ISlide](https://reference.aspose.com/slides/python-net/aspose.slides/islide/).
1. إضافة [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) إلى الشريحة المحددة باستخدام طريقة `add_auto_shape`.
1. الوصول إلى [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) للشكل المضاف.
1. إزالة الفقرة الافتراضية من إطار النص.
1. إنشاء أول مثيل من الفئة [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) وضبط عمقه إلى 0 (المستوى الرئيسي).
1. إنشاء الفقرة الثانية وضبط عمقها إلى 1 (المستوى الفرعي الأول).
1. إنشاء الفقرة الثالثة وضبط عمقها إلى 2 (المستوى الفرعي الثاني).
1. إنشاء الفقرة الرابعة وضبط عمقها إلى 3 (المستوى الفرعي الثالث).
1. إضافة جميع الفقرات التي تم إنشاؤها إلى مجموعة فقرات إطار النص.
1. حفظ العرض التقديمي.

الكود التالي في Python يوضح كيفية إنشاء قائمة نقطية متعددة المستويات:
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

![القائمة متعددة المستويات](multilevel_list.png)

## **إنشاء نقاط عددية**

إنشاء قوائم عددية واضحة ومنظمة يكون سهلًا مع Aspose.Slides for Python. القوائم العددية تعزز بشكل كبير قابلية القراءة وتساعد في توجيه الجمهور عبر الخطوات أو المعلومات المرتبة بوضوح. سواء كنت تُعدّ شرائح تعليمية، أو توثّق عمليات، أو تخطط لعروض تقديمية، فإن القوائم العددية تضمن بقاء رسالتك منظمة وسهلة المتابعة.

يتيح Aspose.Slides لك إضافة القوائم العددية وتخصيصها وتنسيقها برمجيًا. يمكنك تحديد أنماط ترقيم مختلفة—مثل الرقمي (1، 2، 3)، أو الأبجدي (A، B، C)، أو الأرقام الرومانية (I، II، III)—لتتناسب مع سياق أو أسلوب عروضك.

الكود التالي في Python يوضح كيفية إنشاء قائمة عددية في شريحة:
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

![القائمة العددية](numbered_bullets.png)

## **الأسئلة الشائعة**

**هل يمكن تصدير القوائم النقطية والعددية التي تم إنشاؤها باستخدام Aspose.Slides إلى تنسيقات أخرى مثل PDF أو الصور؟**

نعم، يحافظ Aspose.Slides بالكامل على تنسيق وبنية القوائم النقطية والعددية عند تصدير العروض إلى تنسيقات مثل PDF أو الصور وغيرها، مما يضمن نتائج متسقة.

**هل من الممكن استيراد القوائم النقطية أو العددية من عروض تقديمية موجودة؟**

نعم، يتيح Aspose.Slides استيراد وتعديل القوائم النقطية أو العددية من عروض تقديمية موجودة مع الحفاظ على تنسيقها ومظهرها الأصلي.

**هل يدعم Aspose.Slides القوائم النقطية والعددية في العروض التي تم إنشاؤها بلغات متعددة؟**

نعم، يدعم Aspose.Slides بالكامل العروض متعددة اللغات، مما يسمح بإنشاء قوائم نقطية وعددية بأي لغة، بما في ذلك استخدام الأحرف الخاصة أو غير اللاتينية.