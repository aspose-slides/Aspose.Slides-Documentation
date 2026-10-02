---
title: إدارة فقرات نص PowerPoint في بايثون
linktitle: إدارة الفقرة
type: docs
weight: 40
url: /ar/python-net/manage-paragraph/
aliases:
  - /python-net/paragraph/
  - /python-net/portion/
keywords:
- إضافة نص
- إضافة فقرة
- إدارة النص
- إدارة الفقرة
- إدارة نقط
- مسافة بادئة للفقرة
- مسافة بادئة معلقة
- نقطة الفقرة
- قائمة مرقمة
- قائمة نقطية
- خصائص الفقرة
- استيراد HTML
- نص إلى HTML
- فقرة إلى HTML
- فقرة إلى صورة
- نص إلى صورة
- تصدير الفقرة
- PowerPoint
- عرض تقديمي
- Python
- Aspose.Slides
description: "تعلم كيفية إنشاء وتنسيق الفقرات، الأجزاء، النقاط، القوائم المرقمة، المسافات البادئة، محتوى HTML، وصور الفقرات باستخدام Aspose.Slides للبايثون عبر .NET."
---
## **نظرة عامة**

Aspose.Slides for Python عبر .NET تمثّل النص كهرمية تتكوّن من إطارات النص، الفقرات، والأجزاء:

* [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) يمثل حاوية النص داخل الشكل ويوفر إمكانية الوصول إلى مجموعة الفقرات الخاصة به.
* [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) يمثل فقرة واحدة داخل إطار النص ويوفر إمكانية الوصول إلى أجزائه وتنسيق مستوى الفقرة.
* [Portion](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) يمثل مجموعة نصية داخل الفقرة. يمكن لكل جزء أن يحتوي على نصه الخاص وتنسيق مستوى الحرف.

وبالتالي يمكن للفقرة أن تحتوي على نص بخطوط، ألوان، أحجام، وتنسيقات أخرى مختلفة باستخدام أجزاء متعددة.

## **إنشاء وتنسيق الفقرات**

### **إنشاء فقرات مع عدة أجزاء**

الخطوات التالية تنشئ إطار نص يحتوي على ثلاث فقرات، كل فقرة تحتوي على ثلاثة أجزاء:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. الوصول إلى الشريحة المعنية عبر الفهرس الخاص بها.
3. إضافة [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) مستطيلة إلى الشريحة.
4. الوصول إلى [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) الخاص بالشكل.
5. استخدام الفقرة الافتراضية وإضافة كائنين إضافيين من نوع [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) إلى إطار النص.
6. إضافة عدد كافٍ من كائنات [Portion](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) لكل فقرة لتحتوي على ثلاثة أجزاء. الفقرة الافتراضية تحتوي بالفعل على جزء فارغ واحد.
7. تعيين النص لكل جزء.
8. تطبيق تنسيق مستوى الحرف عبر [Portion.portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/portion/portion_format/).
9. حفظ العرض التقديمي المعدّل.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 300, 150)
    text_frame = shape.text_frame

    first_paragraph = text_frame.paragraphs[0]
    first_paragraph.portions.add(slides.Portion())
    first_paragraph.portions.add(slides.Portion())

    second_paragraph = slides.Paragraph()
    second_paragraph.portions.add(slides.Portion())
    second_paragraph.portions.add(slides.Portion())
    second_paragraph.portions.add(slides.Portion())
    text_frame.paragraphs.add(second_paragraph)

    third_paragraph = slides.Paragraph()
    third_paragraph.portions.add(slides.Portion())
    third_paragraph.portions.add(slides.Portion())
    third_paragraph.portions.add(slides.Portion())
    text_frame.paragraphs.add(third_paragraph)

    for paragraph_index in range(text_frame.paragraphs.count):
        paragraph = text_frame.paragraphs[paragraph_index]
        for portion_index in range(paragraph.portions.count):
            portion = paragraph.portions[portion_index]
            portion.text = f"Portion {paragraph_index + 1}.{portion_index + 1}"

            if portion_index == 0:
                portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
                portion.portion_format.fill_format.solid_fill_color.color = draw.Color.red
                portion.portion_format.font_bold = slides.NullableBool.TRUE
                portion.portion_format.font_height = 15
            elif portion_index == 1:
                portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
                portion.portion_format.fill_format.solid_fill_color.color = draw.Color.blue
                portion.portion_format.font_italic = slides.NullableBool.TRUE
                portion.portion_format.font_height = 18

    presentation.save("paragraphs_with_portions.pptx", slides.export.SaveFormat.PPTX)
```

## **إنشاء قوائم نقطية ومرتبة**

### **إنشاء قائمة نقطية أو مرتبة**

تجعل القوائم النقطية والمرتبة العناصر المرتبطة أسهل في القراءة. في Aspose.Slides، يتم تعريف إعدادات القائمة عبر [BulletFormat](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/).

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. الوصول إلى الشريحة المعنية عبر الفهرس الخاص بها.
3. إضافة [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) إلى الشريحة المختارة.
4. الوصول إلى [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) الخاص بالشكل.
5. إزالة الفقرة الافتراضية من إطار النص.
6. إنشاء [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) لرمز نقطة.
7. تعيين [BulletFormat.type](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/type/) إلى [BulletType.SYMBOL](https://reference.aspose.com/slides/python-net/aspose.slides/bullettype/) وتحديد حرف النقطة.
8. تعيين نص الفقرة، والمسافة البادئة، ولون النقطة، وارتفاع النقطة.
9. إضافة الفقرة إلى إطار النص.
10. إنشاء فقرة ثانية وتعيين [BulletFormat.type](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/type/) إلى [BulletType.NUMBERED](https://reference.aspose.com/slides/python-net/aspose.slides/bullettype/).
11. تهيئة نمط النقطة المرتبة وإضافة الفقرة إلى إطار النص.
12. حفظ العرض التقديمي.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)
    text_frame = shape.text_frame
    text_frame.paragraphs.clear()

    symbol_paragraph = slides.Paragraph()
    symbol_paragraph.text = "Welcome to Aspose.Slides"
    symbol_paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    symbol_paragraph.paragraph_format.bullet.char = chr(0x2022)
    symbol_paragraph.paragraph_format.indent = 25
    symbol_paragraph.paragraph_format.bullet.color.color_type = slides.ColorType.RGB
    symbol_paragraph.paragraph_format.bullet.color.color = draw.Color.black
    symbol_paragraph.paragraph_format.bullet.is_bullet_hard_color = slides.NullableBool.TRUE
    symbol_paragraph.paragraph_format.bullet.height = 100
    text_frame.paragraphs.add(symbol_paragraph)

    numbered_paragraph = slides.Paragraph()
    numbered_paragraph.text = "This is a numbered item"
    numbered_paragraph.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    numbered_paragraph.paragraph_format.bullet.numbered_bullet_style = slides.NumberedBulletStyle.BULLET_CIRCLE_NUM_WD_BLACK_PLAIN
    numbered_paragraph.paragraph_format.indent = 25
    numbered_paragraph.paragraph_format.bullet.color.color_type = slides.ColorType.RGB
    numbered_paragraph.paragraph_format.bullet.color.color = draw.Color.black
    numbered_paragraph.paragraph_format.bullet.is_bullet_hard_color = slides.NullableBool.TRUE
    numbered_paragraph.paragraph_format.bullet.height = 100
    text_frame.paragraphs.add(numbered_paragraph)

    presentation.save("bulleted_and_numbered_list.pptx", slides.export.SaveFormat.PPTX)
```

### **استخدام نقاط صورة**

استخدام نقاط صورة يتيح لك استبدال الرمز أو الرقم بصورة مخصصة.

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. الوصول إلى الشريحة المعنية عبر الفهرس الخاص بها.
3. إضافة [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) والوصول إلى [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) الخاص به.
4. إزالة الفقرة الافتراضية من إطار النص.
5. تحميل صورة النقطة وإضافتها إلى مجموعة الصور في العرض التقديمي ككائن [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/).
6. إنشاء [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) وتعيين نصه.
7. تعيين [BulletFormat.type](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/type/) إلى [BulletType.PICTURE](https://reference.aspose.com/slides/python-net/aspose.slides/bullettype/).
8. تعيين الصورة عبر [BulletFormat.picture](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/picture/) وتحديد ارتفاع النقطة.
9. إضافة الفقرة إلى إطار النص.
10. حفظ العرض التقديمي المعدّل.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("bullets.png") as bullet_image:
        presentation_image = presentation.images.add_image(bullet_image)

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)
    text_frame = shape.text_frame
    text_frame.paragraphs.clear()

    paragraph = slides.Paragraph()
    paragraph.text = "Welcome to Aspose.Slides"
    paragraph.paragraph_format.bullet.type = slides.BulletType.PICTURE
    paragraph.paragraph_format.bullet.picture.image = presentation_image
    paragraph.paragraph_format.bullet.height = 100
    text_frame.paragraphs.add(paragraph)

    presentation.save("picture_bullet.pptx", slides.export.SaveFormat.PPTX)
    presentation.save("picture_bullet.ppt", slides.export.SaveFormat.PPT)
```

### **إنشاء قائمة متعددة المستويات**

قم بتعيين [ParagraphFormat.depth](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/depth/) لوضع الفقرات في مستويات مختلفة من القائمة. المستوى الأعلى له عمق يساوي `0`.

1. إنشاء [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) والوصول إلى شريحة.
2. إضافة [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) ومحو الفقرة الافتراضية من إطار النص الخاص به.
3. إنشاء أربع فقرات وتكوين رموز النقاط الخاصة بها.
4. تعيين قيم [ParagraphFormat.depth](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/depth/) الخاصة بها إلى `0`، `1`، `2`، و`3`.
5. إضافة الفقرات إلى إطار النص وحفظ العرض التقديمي.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)
    text_frame = shape.text_frame
    text_frame.paragraphs.clear()

    first_paragraph = slides.Paragraph()
    first_paragraph.text = "Content"
    first_paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    first_paragraph.paragraph_format.bullet.char = chr(0x2022)
    first_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    first_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    first_paragraph.paragraph_format.depth = 0

    second_paragraph = slides.Paragraph()
    second_paragraph.text = "Second level"
    second_paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    second_paragraph.paragraph_format.bullet.char = "-"
    second_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    second_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    second_paragraph.paragraph_format.depth = 1

    third_paragraph = slides.Paragraph()
    third_paragraph.text = "Third level"
    third_paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    third_paragraph.paragraph_format.bullet.char = chr(0x2022)
    third_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    third_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    third_paragraph.paragraph_format.depth = 2

    fourth_paragraph = slides.Paragraph()
    fourth_paragraph.text = "Fourth level"
    fourth_paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    fourth_paragraph.paragraph_format.bullet.char = "-"
    fourth_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    fourth_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    fourth_paragraph.paragraph_format.depth = 3

    text_frame.paragraphs.add(first_paragraph)
    text_frame.paragraphs.add(second_paragraph)
    text_frame.paragraphs.add(third_paragraph)
    text_frame.paragraphs.add(fourth_paragraph)

    presentation.save("multilevel_list.pptx", slides.export.SaveFormat.PPTX)
```

### **بدء عناصر القائمة المرتبة بقيم مخصصة**

استخدم [BulletFormat.numbered_bullet_start_with](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/numbered_bullet_start_with/) لتعيين الرقم الأولي المعروض لفقرة مرتبة.

1. إنشاء [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) وإضافة [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) إلى شريحة.
2. مسح الفقرة الافتراضية من إطار النص الخاص بالشكل.
3. إنشاء ثلاث فقرات مرتبة.
4. تعيين [BulletFormat.numbered_bullet_start_with](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/numbered_bullet_start_with/) إلى `2`، `3`، و`7` للفقرات المعنية.
5. إضافة الفقرات إلى إطار النص وحفظ العرض التقديمي.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)
    text_frame = shape.text_frame
    text_frame.paragraphs.clear()

    first_paragraph = slides.Paragraph()
    first_paragraph.text = "Start at 2"
    first_paragraph.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    first_paragraph.paragraph_format.bullet.numbered_bullet_start_with = 2
    text_frame.paragraphs.add(first_paragraph)

    second_paragraph = slides.Paragraph()
    second_paragraph.text = "Start at 3"
    second_paragraph.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    second_paragraph.paragraph_format.bullet.numbered_bullet_start_with = 3
    text_frame.paragraphs.add(second_paragraph)

    third_paragraph = slides.Paragraph()
    third_paragraph.text = "Start at 7"
    third_paragraph.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    third_paragraph.paragraph_format.bullet.numbered_bullet_start_with = 7
    text_frame.paragraphs.add(third_paragraph)

    presentation.save("custom_numbered_list.pptx", slides.export.SaveFormat.PPTX)
```

## **التحكم في تنسيق الفقرة وخصائص النهاية**

### **تعيين مسافة بادئة للسطر الأول**

استخدم خاصية [ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/) للتحكم في المسافة البادئة للسطر الأول في الفقرة. هذه الخاصية تحرك السطر الأول فقط بالنسبة إلى الهامش الأيسر للفقرة. القيمة الموجبة تُحرك السطر الأول إلى اليمين، بينما تبقى الأسطر الأخرى محاذية مع جسم الفقرة.

استخدم [ParagraphFormat.margin_left](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_left/) عندما تحتاج إلى نقل الفقرة بأكملها. استخدم [ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/) عندما تحتاج إلى نقل السطر الأول فقط.

المثال أدناه ينشئ عدة فقرات ويطبق قيم مختلفة لـ [ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/) لتوضيح كيفية تأثير المسافة البادئة للسطر الأول على تنسيق الفقرة.

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. الوصول إلى الشريحة المستهدفة.
3. إضافة [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) مستطيلة إلى الشريحة.
4. الوصول إلى [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) الخاص بالشكل وإزالة الفقرة الافتراضية.
5. إنشاء عدة فقرات وتعيين قيم مختلفة لـ [ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/) لكل منها.
6. إضافة الفقرات إلى إطار النص.
7. حفظ العرض التقديمي المعدّل.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 420, 220)
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.gray

    text_frame = shape.text_frame
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE
    text_frame.paragraphs.clear()

    first_paragraph = slides.Paragraph()
    first_paragraph.text = "No first-line indent. Wrapped lines start at the same position as the first line."
    first_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    first_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    first_paragraph.paragraph_format.margin_left = 20
    first_paragraph.paragraph_format.indent = 0

    second_paragraph = slides.Paragraph()
    second_paragraph.text = "First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body."
    second_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    second_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    second_paragraph.paragraph_format.margin_left = 20
    second_paragraph.paragraph_format.indent = 20

    third_paragraph = slides.Paragraph()
    third_paragraph.text = "First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see."
    third_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    third_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    third_paragraph.paragraph_format.margin_left = 20
    third_paragraph.paragraph_format.indent = 40

    text_frame.paragraphs.add(first_paragraph)
    text_frame.paragraphs.add(second_paragraph)
    text_frame.paragraphs.add(third_paragraph)

    presentation.save("paragraph_indent.pptx", slides.export.SaveFormat.PPTX)
```

النتيجة:

![المسافة البادئة للسطر الأول في الفقرات](first_line_indent.png)

### **تعيين مسافة بادئة معلقة**

المسافة البادئة المعلقة هي تنسيق فقرة يكون فيه السطر الأول يبدأ إلى اليسار من بقية الأسطر. في Aspose.Slides، تُنشئ هذا التأثير باستخدام خاصية [ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/). عيّن `indent` إلى قيمة سالبة لتحريك السطر الأول إلى اليسار نسبياً إلى جسم الفقرة.

عملياً، يحدد [ParagraphFormat.margin_left](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_left/) موضع جسم الفقرة على اليسار، وتحدد [ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/) موضع السطر الأول بالنسبة إلى ذلك الهامش. لإنشاء مسافة بادئة معلقة، عيّن قيمة `margin_left` موجبة وقيمة `indent` سالبة.

هذا التنسيق مفيد للمراجع، الببليوغرافيات، مداخل القواميس، وغيرها من الفقرات التي يجب أن تكون الأسطر الملتفة محاذية تحت جسم الفقرة بدلاً من الحرف الأول للسطر الأول.

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. الوصول إلى الشريحة المستهدفة.
3. إضافة [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) مستطيلة إلى الشريحة.
4. الوصول إلى [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) الخاص بالشكل وإزالة الفقرة الافتراضية.
5. إنشاء فقرات وتعيين قيمة موجبة لـ [ParagraphFormat.margin_left](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_left/) لكل فقرة.
6. تعيين قيمة سالبة لـ [ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/) لإنشاء تأثير المسافة البادئة المعلقة.
7. إضافة الفقرات إلى إطار النص.
8. حفظ العرض التقديمي المعدّل.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 420, 220)
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.gray

    text_frame = shape.text_frame
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE
    text_frame.paragraphs.clear()

    first_paragraph = slides.Paragraph()
    first_paragraph.text = "A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body."
    first_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    first_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    first_paragraph.paragraph_format.margin_left = 40
    first_paragraph.paragraph_format.indent = -20

    second_paragraph = slides.Paragraph()
    second_paragraph.text = "This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare."
    second_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    second_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    second_paragraph.paragraph_format.margin_left = 60
    second_paragraph.paragraph_format.indent = -30

    text_frame.paragraphs.add(first_paragraph)
    text_frame.paragraphs.add(second_paragraph)

    presentation.save("hanging_indent.pptx", slides.export.SaveFormat.PPTX)
```

النتيجة:

![المسافة البادئة المعلقة في الفقرات](hanging_indent.png)

### **تعيين خصائص تشغيل نهاية الفقرة**

خاصية [Paragraph.end_paragraph_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/end_paragraph_portion_format/) تتحكم في تنسيق علامة نهاية الفقرة. المثال التالي يعيّن حجم خط وخط لاتيني لعلامة النهاية في الفقرة الثانية:

1. تحميل [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) والوصول إلى شريحة.
2. إضافة [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) ومسح الفقرة الافتراضية الخاصة به.
3. إنشاء فقرتين وإضافة أجزاء نصية لهما.
4. إنشاء [PortionFormat](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/) لعلامة النهاية في الفقرة الثانية.
5. تعيين [PortionFormat.font_height](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/font_height/) و[PortionFormat.latin_font](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/latin_font/).
6. إلحاق التنسيق بـ [Paragraph.end_paragraph_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/end_paragraph_portion_format/) وحفظ العرض التقديمي.

```python
import aspose.slides as slides

with slides.Presentation("Test.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 200, 250)
    text_frame = shape.text_frame
    text_frame.paragraphs.clear()

    first_paragraph = slides.Paragraph()
    first_paragraph.portions.add(slides.Portion("Sample text"))

    second_paragraph = slides.Paragraph()
    second_paragraph.portions.add(slides.Portion("Sample text 2"))

    end_paragraph_format = slides.PortionFormat()
    end_paragraph_format.font_height = 48
    end_paragraph_format.latin_font = slides.FontData("Times New Roman")
    second_paragraph.end_paragraph_portion_format = end_paragraph_format

    text_frame.paragraphs.add(first_paragraph)
    text_frame.paragraphs.add(second_paragraph)

    presentation.save("end_paragraph_format.pptx", slides.export.SaveFormat.PPTX)
```

## **عدد الأسطر المُعرضة**

للقواعد المتعلقة بالفقرات والتي تؤثر على الالتفاف التلقائي وعلامات الترقيم عند نهايات السطر، راجع [التحكم في كسر السطر](/slides/ar/python-net/text-formatting/#control-line-breaking) و[التحكم في الوقف المعلق](/slides/ar/python-net/text-formatting/#control-hanging-punctuation).

استخدم [Paragraph.get_lines_count](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_lines_count/) لحساب عدد الأسطر التي يشغلها النص داخل الفقرة بعد ترتيب النص، بما في ذلك الالتفاف التلقائي. هذا مفيد عند فحص طول النص وتنسيقه في قوالب العروض التقديمية.

الفقرة هي عنصر واحد في [TextFrame.paragraphs](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/paragraphs/)، ويمكنها أن تحتل عدة أسطر مُعرضة. كسر السطر الصريح داخل الفقرة يُجبر على سطر جديد دون إنشاء فقرة أخرى. الالتفاف التلقائي ينشئ أسطراً بناءً على العرض المتاح دون إدخال فواصل سطر صريحة في النص. لذلك لا يعطي عدّ الفقرات أو أحرف كسر السطر عدد الأسطر المُعرضة.

المثال التالي ينشئ شكل نص، يحسب أسطره، يضيق الشكل، ثم يستبدل النص بسلسلة أقصر. تم تمكين الالتفاف وتعطيل الضبط التلقائي بحيث يتحكم عرض الشكل في الالتفاف دون تقليص النص أو تغيير حجم الشكل تلقائياً. أبعاد الشكل بوحدات النقاط. أخيراً، يضيف المثال فقرة أخرى ويجمع عدد الأسطر عبر إطار النص.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 400, 200)
    text_frame = shape.text_frame
    text_frame.text_frame_format.wrap_text = slides.NullableBool.TRUE
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.NONE

    paragraph = text_frame.paragraphs[0]
    paragraph.paragraph_format.default_portion_format.font_height = 20
    paragraph.text = "This text demonstrates how automatic wrapping changes the number of rendered lines."
    print(f"Original width: {paragraph.get_lines_count()}")

    shape.width = 150
    print(f"Narrower shape: {paragraph.get_lines_count()}")

    paragraph.text = "Short text."
    print(f"Shorter text: {paragraph.get_lines_count()}")

    second_paragraph = slides.Paragraph()
    second_paragraph.text = "Another paragraph."
    second_paragraph.paragraph_format.default_portion_format.font_height = 20
    text_frame.paragraphs.add(second_paragraph)

    total_line_count = 0
    for current_paragraph in text_frame.paragraphs:
        total_line_count += current_paragraph.get_lines_count()
    print(f"Total lines in the text frame: {total_line_count}")
```

مع هذا النص وهذه الأبعاد، يؤدي تضييق الشكل إلى زيادة عدد الأسطر، بينما يؤدي استبدال النص بالسلسلة القصيرة إلى تقليله. قد تختلف الأعداد الدقيقة بحسب توفر الخطوط والاستبدال، حجم الخط، الهوامش، المسافة البادئة، الالتفاف، وإعدادات الضبط التلقائي. استخدم الخطوط وإعدادات التخطيط المقصودة للبيئة المستهدفة عند فحص القالب.

عدد الأسطر وحده لا يحدّد ما إذا كان النص سيتجاوز حاويته. الارتفاع المتاح، ارتفاع الأسطر، تباعد الفقرة والسطر، وسلوك الضبط التلقائي أيضاً مهم؛ حتى سطر واحد قد يتجاوز العرض المتاح إذا كان الالتفاف معطلاً.

## **استيراد وتصدير محتوى الفقرة**

### **استيراد نص HTML إلى الفقرات**

استخدم [ParagraphCollection.add_from_html](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphcollection/add_from_html/) لتحويل ترميز HTML إلى فقرات وأجزاء داخل إطار نص.

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. الوصول إلى شريحة وإضافة [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/).
3. الوصول إلى [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) الخاص بالشكل ومسح الفقرة الافتراضية.
4. قراءة ملف HTML المصدر.
5. تمرير سلسلة HTML إلى [ParagraphCollection.add_from_html](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphcollection/add_from_html/).
6. حفظ العرض التقديمي المعدّل.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape_width = presentation.slide_size.size.width - 20
    shape_height = presentation.slide_size.size.height - 20
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, shape_width, shape_height)
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.text_frame.paragraphs.clear()

    with open("file.html", "r", encoding="utf-8") as html_stream:
        html = html_stream.read()

    shape.text_frame.paragraphs.add_from_html(html)
    presentation.save("html_text.pptx", slides.export.SaveFormat.PPTX)
```

### **تصدير نص الفقرة إلى HTML**

استخدم [ParagraphCollection.export_to_html](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphcollection/export_to_html/) لتصدير مجموعة مختارة من الفقرات كملف HTML.

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) وتحميل العرض المطلوب.
2. الوصول إلى الشريحة والعثور على [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) الذي يحتوي على النص.
3. الوصول إلى [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) الخاص بالشكل.
4. استدعاء [ParagraphCollection.export_to_html](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphcollection/export_to_html/) مع مؤشر الفقرة البداية وعدد الفقرات المراد تصديرها.
5. كتابة سلسلة HTML المرجعة إلى ملف.

```python
import aspose.slides as slides

with slides.Presentation("ExportingHTMLText.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    if isinstance(shape, slides.AutoShape) and shape.text_frame is not None:
        paragraphs = shape.text_frame.paragraphs
        html = paragraphs.export_to_html(0, paragraphs.count, None)
        with open("paragraphs.html", "w", encoding="utf-8") as html_stream:
            html_stream.write(html)
    else:
        print("The first shape is not a text shape.")
```

### **عرض الفقرة كصورة**

[Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) يوفر الطريقة `get_image` لعرض فقرة فردية مباشرة. تُعيد الطريقة كائن [IImage](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/) يمكنك حفظه إلى ملف أو تدفق باستخدام [IImage.save](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/save/). لا تحتاج إلى عرض الشكل المحتوي أو قص صورة يدوية.

قد تُعيد طريقة `get_image` القيمة `None` إذا لم يُعثر على الفقرة في مجموعة الأب، أو لا توجد حدود عرض صالحة، أو لا يمكن عرضها. تحقق من النتيجة قبل حفظها واستخدم الصورة المرجعة كمدير سياق لإطلاق مواردها.

#### **عرض الفقرة بالمقياس الافتراضي**

لنفترض أن لدينا ملف عرض تقديمي يُدعى sample.pptx يحتوي على شريحة واحدة، حيث الشكل الأول هو مربع نص يحتوي على ثلاث فقرات.

![مربع النص مع ثلاث فقرات](paragraph_to_image_input.png)

المثال التالي يعرض الفقرة الثانية في شكل نص عادي بالمقياس الافتراضي ويحفظ الصورة المرجعة بصيغة PNG:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    if isinstance(shape, slides.AutoShape) and shape.text_frame is not None and shape.text_frame.paragraphs.count > 1:
        paragraph = shape.text_frame.paragraphs[1]
        paragraph_image = paragraph.get_image()

        if paragraph_image is not None:
            with paragraph_image:
                paragraph_image.save("paragraph.png", slides.ImageFormat.PNG)
        else:
            print("The paragraph could not be rendered.")
    else:
        print("The expected text shape or paragraph was not found.")
```

النتيجة:

![صورة الفقرة](paragraph_to_image_output.png)

#### **عرض الفقرة في خلية جدول مع التحجيم**

مرّر عوامل التحجيم الأفقية والعمودية إلى `get_image` للتحكم في حجم الفقرة المعروضة. المثال التالي ينشئ جدولًا، يعرض الفقرة في خليةه الأولى بعرض وارتفاع مضاعفين، ويحفظ النتيجة كصورة PNG:

```python
import aspose.slides as slides

scale_x = 2
scale_y = 2

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    table = slide.shapes.add_table(50, 50, [300], [80])
    paragraph = table.rows[0][0].text_frame.paragraphs[0]
    paragraph.text = "Text in a table cell"

    paragraph_image = paragraph.get_image(scale_x, scale_y)
    if paragraph_image is not None:
        with paragraph_image:
            paragraph_image.save("table_paragraph.png", slides.ImageFormat.PNG)
    else:
        print("The paragraph could not be rendered.")
```

عامل التحجيم `1` يبقي هذا المحور بحجمه الأصلي بالبكسل. على سبيل المثال، `2` لكلا العاملين ينتج صورة عرضها وارتفاعها تقريباً ضعف الأبعاد الافتراضية، ما يساوي أربعة أضعاف عدد البكسلات. العوامل الأكبر عمومًا تنتج نصًا أوضح للتكبير أو الإخراج عالي الدقة، لكنها تزيد أيضًا من استهلاك الذاكرة وحجم الملف. العوامل الأقل من `1` تنتج صورًا أصغر بتفاصيل أقل. استخدم عوامل متساوية للحفاظ على نسبة عرض الفقرة إلى ارتفاعها؛ العوامل الأفقية والعمودية المختلفة تمدد الناتج بشكل مستقل.

ما زال عرض الشكل الكامل باستخدام [Shape.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_image/) مفيدًا عندما يجب أن يتضمن المخرج تعبئة الشكل أو حدوده أو سياقه البصري الآخر. لعرض صورة فقرية فقط، استخدم `Paragraph.get_image`.

## **الأسئلة الشائعة**

**هل يمكنني تعطيل التفاف السطر تمامًا داخل إطار النص؟**

نعم. عيّن [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/wrap_text/) لتعطيل الالتفاف بحيث لا تنكسر الأسطر على حواف إطار النص.

**كيف يمكنني الحصول على حدود الفقرة على الشريحة بدقة؟**

استخدم [Paragraph.get_rect](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_rect/) لاسترجاع المستطيل المحيط بالفقرة. توفر [Portion.get_rect](https://reference.aspose.com/slides/python-net/aspose.slides/portion/get_rect/) حدود الجزء الفردي.

**أين يتم التحكم في محاذاة الفقرة (اليسار، اليمين، الوسط، أو الضبط)?**

[ParagraphFormat.alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) هو إعداد على مستوى الفقرة ويُطبّق على الفقرة بأكملها بغض النظر عن تنسيق الأجزاء الفردية.

لتحاذي الخطوط ذات الأحجام المختلفة داخل كل سطر رأسيًا، راجع [محاذاة الخطوط داخل السطر](/slides/ar/python-net/text-formatting/#align-fonts-within-a-line).

**هل يمكنني تعيين لغة التدقيق لجزء من الفقرة؟**

نعم. عيّن [PortionFormat.language_id](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/language_id/) للأجزاء الفردية، بحيث يمكن لفقرة واحدة أن تحتوي على نص بعدة لغات.