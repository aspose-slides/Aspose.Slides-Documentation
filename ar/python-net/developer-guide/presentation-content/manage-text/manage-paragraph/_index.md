---
title: إدارة فقرات نص PowerPoint في Python
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
- إدارة الرصاصة
- إزاحة الفقرة
- إزاحة معلقة
- رصاصة الفقرة
- قائمة مرقمة
- قائمة نقطية
- خصائص الفقرة
- استيراد HTML
- النص إلى HTML
- الفقرة إلى HTML
- الفقرة إلى صورة
- النص إلى صورة
- تصدير الفقرة
- PowerPoint
- عرض تقديمي
- Python
- Aspose.Slides
description: "تعلم كيفية إنشاء وتنسيق الفقرات، الأجزاء، الرصاصات، القوائم المرقمة، الإزاحات، محتوى HTML، وصور الفقرات باستخدام Aspose.Slides for Python via .NET."
---
## **نظرة عامة**

تمثّل Aspose.Slides for Python via .NET النص كهرمية من إطارات النص، الفقرات، والأجزاء:

* [TextFrame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframe/) يمثل حاوية النص داخل الشكل ويتيح الوصول إلى مجموعة الفقرات الخاصة به.
* [Paragraph](https://reference.aspose.com/slides/ar/python-net/aspose.slides/paragraph/) يمثل فقرة واحدة في إطار النص ويوفر الوصول إلى أجزائه وتنسيق الفقرة.
* [Portion](https://reference.aspose.com/slides/ar/python-net/aspose.slides/portion/) يمثل تشكيلة نصية داخل الفقرة. يمكن لكل جزء أن يمتلك نصه وتنسيق الأحرف الخاص به.

بالتالي يمكن للفقرة أن تحتوي نصًا بخطوط، ألوان، أحجام، وتنسيقات أخرى مختلفة باستخدام عدة أجزاء.

## **إنشاء وتنسيق الفقرات**

### **إنشاء فقرات بأجزاء متعددة**

الخطوات التالية تنشئ إطار نص يحتوي على ثلاث فقرات، كل منها يحتوي على ثلاثة أجزاء:

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/).
2. الوصول إلى الشريحة المطلوبة عبر الفهرس الخاص بها.
3. إضافة [AutoShape](https://reference.aspose.com/slides/ar/python-net/aspose.slides/autoshape/) مستطيل إلى الشريحة.
4. الوصول إلى [TextFrame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframe/) الخاص بالشكل.
5. استخدام الفقرة الافتراضية وإضافة كائنين آخرين من نوع [Paragraph](https://reference.aspose.com/slides/ar/python-net/aspose.slides/paragraph/) إلى إطار النص.
6. إضافة ما يكفي من كائنات [Portion](https://reference.aspose.com/slides/ar/python-net/aspose.slides/portion/) لكل فقرة لتحتوي على ثلاثة أجزاء. الفقرة الافتراضية تحتوي بالفعل على جزء فارغ واحد.
7. تعيين نص كل جزء.
8. تطبيق تنسيق الأحرف عبر [Portion.portion_format](https://reference.aspose.com/slides/ar/python-net/aspose.slides/portion/portion_format/).
9. حفظ العرض التقديمي المعدل.

هذا المثال بلغة Python يطبق الخطوات:

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

## **إنشاء قوائم نقطية ومرقمة**

### **إنشاء قائمة نقطية أو مرقمة**

النقاط والترقيم يجعل العناصر المرتبطة أسهل في القراءة. في Aspose.Slides، يتم تعريف إعدادات القائمة عبر [BulletFormat](https://reference.aspose.com/slides/ar/python-net/aspose.slides/bulletformat/).

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/).
2. الوصول إلى الشريحة المطلوبة عبر الفهرس.
3. إضافة [AutoShape](https://reference.aspose.com/slides/ar/python-net/aspose.slides/autoshape/) إلى الشريحة المختارة.
4. الوصول إلى [TextFrame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframe/) الخاص بالشكل.
5. إزالة الفقرة الافتراضية من إطار النص.
6. إنشاء [Paragraph](https://reference.aspose.com/slides/ar/python-net/aspose.slides/paragraph/) لرمز النقطة.
7. تعيين [BulletFormat.type](https://reference.aspose.com/slides/ar/python-net/aspose.slides/bulletformat/type/) إلى [BulletType.SYMBOL](https://reference.aspose.com/slides/ar/python-net/aspose.slides/bullettype/) وتحديد حرف النقطة.
8. تعيين نص الفقرة، والمسافة البادئة، ولون النقطة، وارتفاع النقطة.
9. إضافة الفقرة إلى إطار النص.
10. إنشاء فقرة ثانية وتعيين [BulletFormat.type](https://reference.aspose.com/slides/ar/python-net/aspose.slides/bulletformat/type/) إلى [BulletType.NUMBERED](https://reference.aspose.com/slides/ar/python-net/aspose.slides/bullettype/).
11. تكوين نمط الترقيم وإضافة الفقرة إلى إطار النص.
12. حفظ العرض التقديمي.

هذا المثال بلغة Python يخلق نقطة رمز ونقطة مرقمة:

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

نقاط الصورة تتيح لك استخدام صورة مخصصة بدلاً من رمز أو رقم.

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/).
2. الوصول إلى الشريحة المطلوبة عبر الفهرس.
3. إضافة [AutoShape](https://reference.aspose.com/slides/ar/python-net/aspose.slides/autoshape/) والوصول إلى [TextFrame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframe/) الخاص به.
4. إزالة الفقرة الافتراضية من إطار النص.
5. تحميل صورة النقطة وإضافتها إلى مجموعة صور العرض التقديمي كـ [PPImage](https://reference.aspose.com/slides/ar/python-net/aspose.slides/ppimage/).
6. إنشاء [Paragraph](https://reference.aspose.com/slides/ar/python-net/aspose.slides/paragraph/) وتعيين نصها.
7. تعيين [BulletFormat.type](https://reference.aspose.com/slides/ar/python-net/aspose.slides/bulletformat/type/) إلى [BulletType.PICTURE](https://reference.aspose.com/slides/ar/python-net/aspose.slides/bullettype/).
8. ربط الصورة عبر [BulletFormat.picture](https://reference.aspose.com/slides/ar/python-net/aspose.slides/bulletformat/picture/) وتعيين ارتفاع النقطة.
9. إضافة الفقرة إلى إطار النص.
10. حفظ العرض التقديمي المعدل.

هذا المثال بلغة Python ينشئ نقطة صورة:

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

تعيين [ParagraphFormat.depth](https://reference.aspose.com/slides/ar/python-net/aspose.slides/paragraphformat/depth/) يضع الفقرات في مستويات مختلفة من القائمة. المستوى العلوي له عمق `0`.

1. إنشاء [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/) والوصول إلى شريحة.
2. إضافة [AutoShape](https://reference.aspose.com/slides/ar/python-net/aspose.slides/autoshape/) وإزالة الفقرة الافتراضية من إطار النص الخاص به.
3. إنشاء أربع فقرات وتكوين رموز النقاط الخاصة بها.
4. تعيين قيم [ParagraphFormat.depth](https://reference.aspose.com/slides/ar/python-net/aspose.slides/paragraphformat/depth/) إلى `0`، `1`، `2`، و`3`.
5. إضافة الفقرات إلى إطار النص وحفظ العرض التقديمي.

هذا المثال بلغة Python ينشئ قائمة نقطية بأربع مستويات:

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

### **بدء عناصر القائمة المرقمة بقيم مخصصة**

استخدام [BulletFormat.numbered_bullet_start_with](https://reference.aspose.com/slides/ar/python-net/aspose.slides/bulletformat/numbered_bullet_start_with/) لتعيين الرقم الأول المعروض لفقرة مرقمة.

1. إنشاء [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/) وإضافة [AutoShape](https://reference.aspose.com/slides/ar/python-net/aspose.slides/autoshape/) إلى شريحة.
2. مسح الفقرة الافتراضية من إطار النص الخاص بالشكل.
3. إنشاء ثلاث فقرات مرقمة.
4. تعيين [BulletFormat.numbered_bullet_start_with](https://reference.aspose.com/slides/ar/python-net/aspose.slides/bulletformat/numbered_bullet_start_with/) إلى `2`، `3`، و`7` للفقرات المقابلة.
5. إضافة الفقرات إلى إطار النص وحفظ العرض التقديمي.

هذا المثال بلغة Python يعيّن رقم بدء مخصص لكل فقرة:

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

## **التحكم في تخطيط الفقرة وخصائص النهاية**

### **تعيين إزاحة السطر الأول**

استخدام الخاصية [ParagraphFormat.indent](https://reference.aspose.com/slides/ar/python-net/aspose.slides/paragraphformat/indent/) للتحكم في إزاحة السطر الأول للفقرة. هذه الخاصية تحرك السطر الأول فقط نسبياً إلى هامش الفقرة الأيسر. القيمة الموجبة تحرك السطر الأول إلى اليمين، بينما تبقى الأسطر المتبقية محاذاة إلى النص الأساسي.

استخدم [ParagraphFormat.margin_left](https://reference.aspose.com/slides/ar/python-net/aspose.slides/paragraphformat/margin_left/) عندما تحتاج إلى تحريك الفقرة بأكملها. واستخدم [ParagraphFormat.indent](https://reference.aspose.com/slides/ar/python-net/aspose.slides/paragraphformat/indent/) عندما تريد تحريك السطر الأول فقط.

المثال أدناه ينشئ عدة فقرات ويطبق قيم مختلفة لـ [ParagraphFormat.indent](https://reference.aspose.com/slides/ar/python-net/aspose.slides/paragraphformat/indent/) لتوضيح تأثير إزاحة السطر الأول على تخطيط الفقرة.

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/).
2. الوصول إلى الشريحة الهدف.
3. إضافة [AutoShape](https://reference.aspose.com/slides/ar/python-net/aspose.slides/autoshape/) مستطيل إلى الشريحة.
4. الوصول إلى [TextFrame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframe/) الخاص بالشكل وإزالة الفقرة الافتراضية.
5. إنشاء عدة فقرات وتعيين قيم مختلفة لـ [ParagraphFormat.indent](https://reference.aspose.com/slides/ar/python-net/aspose.slides/paragraphformat/indent/) لها.
6. إضافة الفقرات إلى إطار النص.
7. حفظ العرض التقديمي المعدل.

هذا الكود يوضح كيفية تعيين إزاحة الفقرة:

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

![إزاحة السطر الأول للفقرات](first_line_indent.png)

### **تعيين إزاحة معلقة**

الإزاحة المعلقة هي تخطيط فقرة يبدأ فيه السطر الأول إلى اليسار من باقي الأسطر. في Aspose.Slides، يمكنك إنشاء هذا التأثير باستخدام الخاصية [ParagraphFormat.indent](https://reference.aspose.com/slides/ar/python-net/aspose.slides/paragraphformat/indent/). عيّن `indent` إلى قيمة سالبة لتحريك السطر الأول إلى اليسار بالنسبة إلى جسم الفقرة.

عمليًا، الخاصية [ParagraphFormat.margin_left](https://reference.aspose.com/slides/ar/python-net/aspose.slides/paragraphformat/margin_left/) تحدد الموضع الأيسر لجسم الفقرة، وتحدد [ParagraphFormat.indent](https://reference.aspose.com/slides/ar/python-net/aspose.slides/paragraphformat/indent/) موضع السطر الأول نسبةً إلى ذلك الهامش. لإنشاء إزاحة معلقة، عيّن قيمة موجبة لـ `margin_left` وقيمة سالبة لـ `indent`.

هذا التنسيق مفيد في المراجع، القوائم الببليوغرافية، إدخالات القاموس، وغيرها من الفقرات التي يجب أن تتطابق الأسطر الملتفة تحت جسم الفقرة وليس تحت أول حرف من السطر الأول.

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/).
2. الوصول إلى الشريحة الهدف.
3. إضافة [AutoShape](https://reference.aspose.com/slides/ar/python-net/aspose.slides/autoshape/) مستطيل إلى الشريحة.
4. الوصول إلى [TextFrame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframe/) الخاص بالشكل وإزالة الفقرة الافتراضية.
5. إنشاء فقرات وتعيين قيمة موجبة لـ [ParagraphFormat.margin_left](https://reference.aspose.com/slides/ar/python-net/aspose.slides/paragraphformat/margin_left/) لكل فقرة.
6. تعيين قيمة سالبة لـ [ParagraphFormat.indent](https://reference.aspose.com/slides/ar/python-net/aspose.slides/paragraphformat/indent/) لإنشاء تأثير الإزاحة المعلقة.
7. إضافة الفقرات إلى إطار النص.
8. حفظ العرض التقديمي المعدل.

هذا الكود يوضح كيفية تعيين إزاحة معلقة للفقرة:

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

![إزاحة معلقة للفقرات](hanging_indent.png)

### **تعيين خصائص نهاية الفقرة**

الخاصية [Paragraph.end_paragraph_portion_format](https://reference.aspose.com/slides/ar/python-net/aspose.slides/paragraph/end_paragraph_portion_format/) تتحكم في تنسيق علامة نهاية الفقرة. المثال التالي يعيّن حجم الخط والخط اللاتيني لعلامة النهاية في الفقرة الثانية:

1. تحميل [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/) والوصول إلى شريحة.
2. إضافة [AutoShape](https://reference.aspose.com/slides/ar/python-net/aspose.slides/autoshape/) ومسح الفقرة الافتراضية.
3. إنشاء فقرتين وإضافة أجزاء نصية إليهما.
4. إنشاء [PortionFormat](https://reference.aspose.com/slides/ar/python-net/aspose.slides/portionformat/) لعلامة نهاية الفقرة الثانية.
5. تعيين [PortionFormat.font_height](https://reference.aspose.com/slides/ar/python-net/aspose.slides/portionformat/font_height/) و[PortionFormat.latin_font](https://reference.aspose.com/slides/ar/python-net/aspose.slides/portionformat/latin_font/).
6. ربط التنسيق بـ [Paragraph.end_paragraph_portion_format](https://reference.aspose.com/slides/ar/python-net/aspose.slides/paragraph/end_paragraph_portion_format/) وحفظ العرض التقديمي.

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

## **استيراد وتصدير محتوى الفقرة**

### **استيراد نص HTML إلى الفقرات**

استخدام [ParagraphCollection.add_from_html](https://reference.aspose.com/slides/ar/python-net/aspose.slides/paragraphcollection/add_from_html/) لتحويل ترميز HTML إلى فقرات وأجزاء داخل إطار نص.

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/).
2. الوصول إلى شريحة وإضافة [AutoShape](https://reference.aspose.com/slides/ar/python-net/aspose.slides/autoshape/).
3. الوصول إلى [TextFrame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframe/) الخاص بالشكل ومسح الفقرة الافتراضية.
4. قراءة ملف HTML المصدر.
5. تمرير سلسلة HTML إلى [ParagraphCollection.add_from_html](https://reference.aspose.com/slides/ar/python-net/aspose.slides/paragraphcollection/add_from_html/).
6. حفظ العرض التقديمي المعدل.

هذا المثال بلغة Python يستورد HTML إلى إطار نص:

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

استخدام [ParagraphCollection.export_to_html](https://reference.aspose.com/slides/ar/python-net/aspose.slides/paragraphcollection/export_to_html/) لتصدير مجموعة محددة من الفقرات كملف HTML.

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/) وتحميل العرض التقديمي المطلوب.
2. الوصول إلى الشريحة والعثور على [AutoShape](https://reference.aspose.com/slides/ar/python-net/aspose.slides/autoshape/) الذي يحتوي على النص.
3. الوصول إلى [TextFrame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframe/) الخاص بالشكل.
4. استدعاء [ParagraphCollection.export_to_html](https://reference.aspose.com/slides/ar/python-net/aspose.slides/paragraphcollection/export_to_html/) مع فهرس الفقرة البداية وعدد الفقرات المراد تصديرها.
5. كتابة سلسلة HTML المسترجعة إلى ملف.

هذا المثال بلغة Python يصدر جميع الفقرات من الشكل النصي الأول:

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

### **تحويل الفقرة إلى صورة**

[Paragraph](https://reference.aspose.com/slides/ar/python-net/aspose.slides/paragraph/) يوفر الطريقة `get_image` لتصوير فقرة فردية مباشرة. تُعيد الطريقة كائنًا من نوع [IImage](https://reference.aspose.com/slides/ar/python-net/aspose.slides/iimage/) يمكنك حفظه إلى ملف أو تدفق باستخدام [IImage.save](https://reference.aspose.com/slides/ar/python-net/aspose.slides/iimage/save/). لا تحتاج إلى تصيير الشكل الحاوي أو قص صورة يدوية.

قد تُعيد الطريقة `get_image` القيمة `None` إذا لم تُعثر على الفقرة في المجموعة الأصلية، أو لا يوجد حدود تصوير صالحة، أو لا يمكن تصويرها. تحقق من النتيجة قبل حفظها واستخدم الصورة المرجعية لإدارة مواردها.

#### **تصوير الفقرة بالمقياس الافتراضي**

نفترض أن لدينا ملف عرض تقديمي يُدعى sample.pptx يحتوي على شريحة واحدة، حيث الشكل الأول هو مربع نص يحتوي على ثلاث فقرات.

![مربع النص مع ثلاث فقرات](paragraph_to_image_input.png)

المثال التالي يصور الفقرة الثانية داخل شكل نص عادي بالمقياس الافتراضي ويحفظ الصورة المستخرجة بصيغة PNG:

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

#### **تصوير الفقرة في خلية جدول مع تحجيم**

تمرير عوامل التحجيم الأفقي والعمودي إلى `get_image` للتحكم في حجم الفقرة المصورة. المثال التالي ينشئ جدولًا، يصور الفقرة في خليةه الأولى بعرض وارتفاع مرتين عن المقياس الافتراضي، ويحفظ النتيجة كصورة PNG:

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

عامل التحجيم `1` يبقي المحور عند حجمه الافتراضي بالبكسل. على سبيل المثال، `2` لكل العاملين ينتج صورة عرضها وارتفاعها تقريبًا ضعف الأبعاد الافتراضية، أي أربعة أضعاف عدد البكسلات. العوامل الأكبر عادةً ما تُنتج نصًا أكثر وضوحًا للتكبير أو الإخراج عالي الدقة، لكنها تزيد من استهلاك الذاكرة وحجم الملف. القيم الأقل من `1` تُنتج صورًا أصغر مع تفاصيل أقل. استخدم عوامل متساوية للحفاظ على نسبة أبعاد الفقرة؛ العوامل المختلفة للعرض والارتفاع ستمد الصورة بشكل مستقل.

تصيير شكل كامل باستخدام [Shape.get_image](https://reference.aspose.com/slides/ar/python-net/aspose.slides/shape/get_image/) يظل مفيدًا عندما يحتاج الإخراج إلى تضمين تعبئة الشكل، حدوده، أو سياقه البصري. للحصول على صورة للفقرة فقط، استخدم `Paragraph.get_image`.

## **الأسئلة الشائعة**

**هل يمكنني تعطيل التفاف السطر تمامًا داخل إطار النص؟**

نعم. عيّن [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframeformat/wrap_text/) لتعطيل التفاف السطر بحيث لا تنكسر الأسطر عند حواف إطار النص.

**كيف يمكنني الحصول على حدود الفقرة المحددة داخل الشريحة بدقة؟**

استخدم [Paragraph.get_rect](https://reference.aspose.com/slides/ar/python-net/aspose.slides/paragraph/get_rect/) لاسترجاع المستطيل الحدودي للفقرة. كما توفر [Portion.get_rect](https://reference.aspose.com/slides/ar/python-net/aspose.slides/portion/get_rect/) حدود الجزء الفردي.

**أين يتم التحكم بموضع محاذاة الفقرة (اليسار، اليمين، الوسط، أو الضبط الكامل)؟**

[ParagraphFormat.alignment](https://reference.aspose.com/slides/ar/python-net/aspose.slides/paragraphformat/alignment/) هو إعداد على مستوى الفقرة ويطبق على الفقرة بأكملها بغض النظر عن تنسيق الأجزاء الفردية.

**هل يمكنني تعيين لغة التدقيق لجزء من الفقرة؟**

نعم. عيّن [PortionFormat.language_id](https://reference.aspose.com/slides/ar/python-net/aspose.slides/portionformat/language_id/) للأجزاء الفردية، بحيث يمكن لفقرة واحدة أن تحتوي نصًا بعدة لغات.