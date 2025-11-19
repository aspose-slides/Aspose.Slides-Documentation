---
title: إدارة العناصر النائبة في العروض التقديمية باستخدام بايثون
linktitle: إدارة العناصر النائبة
type: docs
weight: 10
url: /ar/python-net/manage-placeholder/
keywords:
- عنصر نائب
- عنصر نائب للنص
- عنصر نائب للصور
- عنصر نائب للمخطط
- نص التوجيه
- PowerPoint
- عرض تقديمي
- Python
- Aspose.Slides
description: "إدارة العناصر النائبة بسهولة في Aspose.Slides للبايثون عبر .NET: استبدال النص، تخصيص نصوص التوجيه، وضبط شفافية الصور في PowerPoint وOpenDocument."
---

## **نظرة عامة**

تحدد العناصر النائبة المناطق المحجوزة على القوالب الرئيسية، التخطيطات، والشرائح—مثل العنوان، النص الرئيسي، الصورة، المخطط، التاريخ/الوقت، رقم الشريحة، والتذييل—التي تتحكم في موضع المحتوى وكيفية ورثه للتنسيق. باستخدام Aspose.Slides for Python يمكنك اكتشاف العناصر النائبة في شريحة، أو تخطيطها، أو القالب الرئيسي عن طريق التحقق من أن `shape.placeholder` ليس `None`، وفحص `placeholder.type`، ثم قراءة أو تعديل المحتوى والتنسيق المرتبط. تتيح لك واجهة برمجة التطبيقات إضافة عناصر نائبة جديدة إلى القالب الرئيسي أو التخطيط بحيث تنتشر إلى الشرائح التابعة، وإعادة وضعها وتغيير حجمها، وتحويل عنصر نائبة إلى شكل عادي عندما تحتاج إلى تحكم كامل، أو إزالته لتبسيط التصميم. توضح الأمثلة أدناه كيفية تعداد العناصر النائبة، وتحديث النص والنمط، والحفاظ على تناسق التخطيطات بتطبيق التغييرات على المستوى المناسب.

## **تغيير النص في العناصر النائبة**

باستخدام Aspose.Slides for Python، يمكنك العثور على العناصر النائبة في الشرائح داخل عرض تقديمي وتعديلها. يسمح لك Aspose.Slides بتعديل النص داخل عنصر نائبة.

**المتطلبات المسبقة:** تحتاج إلى عرض تقديمي يحتوي على عنصر نائبة. يمكنك إنشاء مثل هذا العرض باستخدام Microsoft PowerPoint.

هذه هي طريقة استخدام Aspose.Slides لاستبدال النص في عنصر نائبة:

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) وتمرير العرض التقديمي كوسيطة.
1. الحصول على مرجع إلى الشريحة بواسطة فهرستها.
1. التجول في الأشكال للعثور على العنصر النائب.
1. تغيير النص باستخدام [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) المرتبط بـ [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/).
1. احفظ العرض التقديمي المعدل.

هذا الكود Python يوضح كيفية تغيير النص في عنصر نائبة:
```python
import aspose.slides as slides

# إنشاء كائن من فئة Presentation.
with slides.Presentation("ReplacingText.pptx") as presentation:
    # الوصول إلى الشريحة الأولى.
    slide = presentation.slides[0]

    # التنقل عبر الأشكال للعثور على العناصر النائبة.
    for shape in slide.shapes:
        if shape.placeholder is not None:
            # تغيير النص في كل عنصر نائب.
            shape.text_frame.text = "This is Placeholder"

    # حفظ العرض التقديمي إلى القرص.
    presentation.save("ReplacingText_out.pptx", slides.export.SaveFormat.PPTX)
```


## **تعيين نص التوجيه لعنصر نائبة**

تتضمن التخطيطات القياسية والمصممة مسبقًا نصوص توجيهية للعنصر النائب مثل **Click to add a title** أو **Click to add a subtitle**. باستخدام Aspose.Slides، يمكنك استبدال هذه النصوص التوجيهية بنصك الخاص في تخطيطات العناصر النائبة.

مثال Python التالي يوضح كيفية تعيين نص التوجيه لعنصر نائبة:
```python
import aspose.slides as slides

with slides.Presentation("PromptText.pptx") as presentation:
    slide = presentation.slides[0]

    # التنقل عبر الأشكال للعثور على العناصر النائبة.
    for shape in slide.slide.shapes:
        if shape.placeholder is not None and type(shape) is slides.AutoShape:
            if shape.placeholder.type == slides.PlaceholderType.CENTERED_TITLE:
                text = "Add Title"
            elif shape.placeholder.type == slides.PlaceholderType.SUBTITLE:
                text = "Add Subtitle"

            shape.text_frame.text = text
            print(f"Placeholder with text: {text}")

    presentation.save("PromptText_out.pptx", slides.export.SaveFormat.PPTX)
```


## **تعيين شفافية الصورة في عنصر نائبة**

يتيح لك Aspose.Slides تعيين شفافية صورة الخلفية في عنصر نائبة نصية. من خلال ضبط شفافية الصورة داخل ذلك الإطار، يمكنك إبراز النص أو الصورة حسب الألوان المستخدمة.

مثال Python التالي يوضح كيفية تعيين شفافية صورة الخلفية داخل شكل:
```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 100)
    auto_shape.fill_format.fill_type = slides.FillType.PICTURE

    with open("image.png", "rb") as image_stream:
        auto_shape.fill_format.picture_fill_format.picture.image = presentation.images.add_image(image_stream)
        auto_shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH
        auto_shape.fill_format.picture_fill_format.picture.image_transform.add_alpha_modulate_fixed_effect(75)
```


## **الأسئلة المتداولة**

**ما هو العنصر النائب الأساسي، وكيف يختلف عن الشكل المحلي في شريحة؟**

العنصر النائب الأساسي هو الشكل الأصلي على التخطيط أو القالب الرئيسي الذي يرث منه شكل الشريحة—النوع، الموضع، وبعض التنسيقات تأتي منه. الشكل المحلي مستقل؛ إذا لم يوجد عنصر نائبة أساسي، لا يُطبق الوراثة.

**كيف يمكنني تحديث جميع العناوين أو التسميات التوضيحية عبر العرض التقديمي دون iterating over كل شريحة؟**

قم بتحرير العنصر النائب المقابل على التخطيط أو القالب الرئيسي. الشرائح المبنية على تلك التخطيطات/القالب ستحصل تلقائيًا على التغيير.

**كيف يمكنني التحكم في عناصر النائب القياسية للترويسة/التذييل—التاريخ والوقت، رقم الشريحة، ونص التذييل؟**

استخدم مديري HeaderFooter في النطاق المناسب (الشرائح العادية، التخطيطات، القالب الرئيسي، الملاحظات/النشرات) لتفعيل أو إلغاء تفعيل تلك العناصر النائبة وتعيين محتواها.