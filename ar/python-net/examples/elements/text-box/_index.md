---
title: مربع النص
type: docs
weight: 40
url: /ar/python-net/examples/elements/text-box/
keywords:
- مربع النص
- إضافة مربع نص
- الوصول إلى مربع النص
- إزالة مربع النص
- أمثلة على الكود
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "إنشاء وتنسيق مربعات النص في بايثون باستخدام Aspose.Slides: تعيين الخطوط، المحاذاة، الالتفاف، التملأ التلقائي، والروابط لتحسين الشرائح لبرنامج PowerPoint وOpenDocument."
---
في Aspose.Slides، يُمثَّل **مربع النص** بواسطة `AutoShape`. يمكن لأي شكل تقريبًا أن يحتوي على نص، لكن مربع النص النموذجي لا يحتوي على تعبئة أو حد ويعرض النص فقط.

يشرح هذا الدليل كيفية إضافة مربعات النص والوصول إليها وإزالتها برمجيًا.

## **إضافة مربع نص**

مربع النص هو ببساطة `AutoShape` دون تعبئة أو حد وبعض النص المنسق. إليك كيفية إنشاء واحد:

```py
def add_text_box():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # إنشاء شكل مستطيل (الإعدادات الافتراضية تكون مملوءة بحد ولا يحتوي على نص).
        # إزالة التعبئة والحد لجعله يشبه مربع النص النموذجي.
        # تعيين تنسيق النص.
        # تعيين محتوى النص الفعلي.

        text_box = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 75, 150, 100)

        # Remove fill and border to make it look like a typical text box.
        text_box.fill_format.fill_type = slides.FillType.NO_FILL
        text_box.line_format.fill_format.fill_type = slides.FillType.NO_FILL

        # Set text formatting.
        paragraph_format = text_box.text_frame.paragraphs[0].paragraph_format
        paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
        paragraph_format.default_portion_format.fill_format.solid_fill_color.color = drawing.Color.black

        # Assign the actual text content.
        text_box.text_frame.text = "Some text..."

        presentation.save("text_box.pptx", slides.export.SaveFormat.PPTX)
```

> 💡 **ملاحظة:** أي `AutoShape` يحتوي على `TextFrame` غير فارغ يمكن أن يعمل كمربع نص.

## **الوصول إلى مربعات النص حسب المحتوى**

للعثور على جميع مربعات النص التي تحتوي على كلمة مفتاحية محددة (مثال: "Slide"), قم بالتكرار عبر الأشكال وتحقق من نصها:

```py
def access_text_box():
    with slides.Presentation("text_box.pptx") as presentation:
        slide = presentation.slides[0]

        for shape in slide.shapes:
            # يمكن فقط لـ AutoShapes أن تحتوي على نص قابل للتحرير.
            if isinstance(shape, slides.AutoShape):
                if "Slide" in shape.text_frame.text:
                    # قم بعمل شيء مع مربع النص المتطابق.
                    pass
```

## **إزالة مربعات النص حسب المحتوى**

يبحث هذا المثال ويحذف جميع مربعات النص في الشريحة الأولى التي تحتوي على كلمة مفتاحية محددة:

```py
def remove_text_boxes():
    with slides.Presentation("text_box.pptx") as presentation:
        slide = presentation.slides[0]

        # العثور على الأشكال التي يجب إزالتها وهي AutoShapes تحتوي على كلمة "Slide".
        shapes_to_remove = [
            shape for shape in slide.shapes
            if isinstance(shape, slides.AutoShape) and "Slide" in shape.text_frame.text
        ]

        # إزالة كل شكل مطابق من الشريحة.
        for shape in shapes_to_remove:
            slide.shapes.remove(shape)

        presentation.save("text_boxes_removed.pptx", slides.export.SaveFormat.PPTX)
```

> 💡 **نصيحة:** احرص دائمًا على إنشاء نسخة من مجموعة الأشكال قبل تعديلها أثناء التكرار لتجنب أخطاء تعديل المجموعة.