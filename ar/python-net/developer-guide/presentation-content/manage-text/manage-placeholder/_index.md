---
title: إدارة العنصر النائب
type: docs
weight: 10
url: /ar/python-net/manage-placeholder/
keywords: "عنصر نائب, نص العنصر النائب, نص الموجه, عرض PowerPoint, بايثون, Aspose.Slides لبايثون عبر .NET"
description: "تغيير نص العنصر النائب ونص الموجه في عروض PowerPoint باستخدام بايثون"
---

## **تغيير النص في العنصر النائب**

باستخدام [Aspose.Slides لبايثون عبر .NET](/slides/ar/python-net/)، يمكنك العثور على العناصر النائبة وتعديلها في الشرائح في العروض التقديمية. يسمح لك Aspose.Slides بإجراء تغييرات على النص في العنصر النائب.

**المتطلبات الأساسية**: تحتاج إلى عرض تقديمي يحتوي على عنصر نائب. يمكنك إنشاء مثل هذا العرض التقديمي في تطبيق Microsoft PowerPoint القياسي.

هذه هي الطريقة التي تستخدم بها Aspose.Slides لاستبدال النص في العنصر النائب في ذلك العرض التقديمي:

1. قم بإنشاء كائن من فئة [`Presentation`](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) ومرر العرض التقديمي كوسيط.
2. احصل على مرجع الشريحة من خلال فهرسها.
3. اضغط عبر الأشكال للعثور على العنصر النائب.
4. قم بتحويل شكل العنصر النائب إلى [`AutoShape`](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) وغيّر النص باستخدام [`TextFrame`](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) المرتبط بـ [`AutoShape`](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/).
5. احفظ العرض التقديمي المعدل.

يوضح كود بايثون هذا كيفية تغيير النص في العنصر النائب:

```python
import aspose.slides as slides

# ينشئ كائن من فئة Presentation
with slides.Presentation(path + "ReplacingText.pptx") as pres:
    # الوصول إلى الشريحة الأولى
    sld = pres.slides[0]

    # يكرر عبر الأشكال للعثور على العنصر النائب
    for shp in sld.shapes:
        if shp.placeholder != None:
            # يغير النص في كل عنصر نائب
            shp.text_frame.text = "هذا هو العنصر النائب"

    # يحفظ العرض التقديمي على القرص
    pres.save("output_out.pptx", slides.export.SaveFormat.PPTX)
```


## **تعيين نص الموجه في العنصر النائب**
تحتوي التخطيطات القياسية والمبنية مسبقاً على نصوص موجهة للعنصر النائب مثل ***انقر لإضافة عنوان*** أو ***انقر لإضافة ترقية فرعية***. باستخدام Aspose.Slides، يمكنك إدخال نصوصك الموجهة المفضلة في تخطيطات العناصر النائبة.

يوضح كود بايثون هذا كيفية تعيين نص الموجه في العنصر النائب:

```python
import aspose.slides as slides

with slides.Presentation(path + "Presentation2.pptx") as pres:
    slide = pres.slides[0]
    for shape in slide.slide.shapes: # يكرر عبر الشريحة
        if shape.placeholder != None and type(shape) is slides.AutoShape:
            text = ""
            if shape.placeholder.type == slides.PlaceholderType.CENTERED_TITLE: # يعرض PowerPoint "انقر لإضافة عنوان". 
                text = "أضف عنوان"
            elif shape.placeholder.type == slides.PlaceholderType.SUBTITLE: # يضيف ترقية فرعية.
                text = "أضف ترقية فرعية"

            shape.text_frame.text = text

            print("عنصر نائب مع النص: {text}".format(text = text))

    pres.save("Placeholders_PromptText.pptx", slides.export.SaveFormat.PPTX)
```

## **تعيين شفافية صورة العنصر النائب**

يسمح لك Aspose.Slides بتعيين شفافية الصورة الخلفية في عنصر نائب نصي. من خلال ضبط شفافية الصورة في مثل هذا الإطار، يمكنك جعل النص أو الصورة بارزًا (اعتمادًا على ألوان النص والصورة).

يوضح كود بايثون هذا كيفية تعيين الشفافية لخلفية الصورة (داخل شكل):

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    autoShape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 100)
    
    autoShape.fill_format.fill_type = slides.FillType.PICTURE
    with open("image.png", "rb") as in_file:
        autoShape.fill_format.picture_fill_format.picture.image = presentation.images.add_image(in_file)

        autoShape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH
        autoShape.fill_format.picture_fill_format.picture.image_transform.add_alpha_modulate_fixed_effect(75)

```