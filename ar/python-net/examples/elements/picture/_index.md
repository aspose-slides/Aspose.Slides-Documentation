---
title: صورة
type: docs
weight: 50
url: /ar/python-net/examples/elements/picture/
keywords:
- صورة
- إطار صورة
- إضافة صورة
- الوصول إلى صورة
- أمثلة على الكود
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "العمل مع الصور في بايثون باستخدام Aspose.Slides: الإدراج، الاستبدال، الاقتصاص، الضغط، تعديل الشفافية والتأثيرات، تعبئة الأشكال، وتصدير لملفات PPT، PPTX و ODP."
---
يوضح كيفية إدراج والوصول إلى الصور من الصور المخزنة في الذاكرة باستخدام **Aspose.Slides for Python via .NET**. الأمثلة أدناه تنشئ صورة في الذاكرة، تضعها على شريحة، ثم تسترجعها.

## **إضافة صورة**

يقوم هذا الكود بتحميل صورة من ملف وإدراجها كإطار صورة على الشريحة الأولى.

```py
def add_picture():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # تحميل صورة من ملف.
        with open("image.png", "rb") as image_stream:
            # إضافة الصورة إلى موارد العرض التقديمي.
            image = presentation.images.add_image(image_stream)

        # إدراج إطار صورة يعرض الصورة على الشريحة الأولى.
        slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

        presentation.save("picture.pptx", slides.export.SaveFormat.PPTX)
```

## **الوصول إلى صورة**

يتأكد هذا المثال من أن الشريحة تحتوي على إطار صورة ثم يصل إلى أول إطار يجده.

```py
def access_picture():
    with slides.Presentation("picture.pptx") as presentation:
        slide = presentation.slides[0]

        # الوصول إلى أول إطار صورة على الشريحة.
        picture_frame = next(shape for shape in slide.shapes if isinstance(shape, slides.PictureFrame))
```