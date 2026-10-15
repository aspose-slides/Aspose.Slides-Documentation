---
title: إدارة فقرات نص PowerPoint باستخدام Python
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
- إدارة التعداد
- إزاحة الفقرة
- إزاحة معلقة
- نقطة الفقرة
- قائمة مرقمة
- قائمة منقطة
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
description: "تعلم كيفية إنشاء وتنسيق الفقرات، والأقسام، والنقاط، والقوائم المرقمة، والإزاحات، ومحتوى HTML، وصور الفقرات باستخدام Aspose.Slides للغة Python عبر .NET."
---
## **نظرة عامة**

يمثل Aspose.Slides for Python عبر .NET النص كهَرَمِيّة من إطارات النص، الفقرات، والأجزاء:

* [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) يمثل حاوية النص داخل شكل ويوفر الوصول إلى مجموعة الفقرات الخاصة به.
* [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) يمثل فقرة واحدة في إطار نص ويوفر الوصول إلى أجزائه وتنسيق مستوى الفقرة.
* [Portion](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) يمثل مقطع نص داخل الفقرة. يمكن لكل جزء أن يحتوي على نصه وتنسيق مستوى الحرف الخاص به.

يمكن للفقرة وبالتالي أن تحتوي على نص بخطوط، ألوان، أحجام، وتنسيقات أخرى مختلفة باستخدام عدة أجزاء.

## **إنشاء وتنسيق الفقرات**

إنشاء فقرات في إطار النص الخاص بالشكل واستخدام الأجزاء لتنسيق مقاطع النص الفردية. يوضح هذا القسم كيفية دمج عدة أجزاء داخل كل فقرة وتطبيق ألوان، أحجام خطوط، وأنماط مختلفة.

### **إنشاء فقرات متعددة الأجزاء**

المثال التالي بلغة Python ينشئ ثلاث فقرات، كل منها يحتوي على ثلاث مقاطع نص في مجموعة [Paragraph.portions](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/portions/). يعيد استخدام الفقرة الافتراضية والجزء الفارغ، ثم يضيف الفقرات والأجزاء المتبقية. يتم تطبيق التنسيق عبر [Portion.portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/portion/portion_format/): الجزء الأول في كل فقرة أحمر، عريض، و15 نقطة؛ الثاني أزرق، مائِل، و18 نقطة. الجزء الثالث يحتفظ بالتنسيق الافتراضي:

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

## **إنشاء القوائم المنقطة والمرقمة**

تنظيم نص الفقرة في قوائم باستخدام رموز أو أرقام أو صور مخصصة. تغطي الأمثلة في هذا القسم تنسيق النقاط، القوائم متعددة المستويات، وأعداد البدء المخصصة.

### **إنشاء قائمة منقطة أو مرقمة**

تجعل النقاط والترقيم العناصر المتعلقة أسهل في المسح. في Aspose.Slides يتم تعريف إعدادات القائمة عبر [BulletFormat](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/).

يضيف المثال التالي بلغة Python نقطة رمزية وعنصر مرقم إلى نفس إطار النص. يختار [BulletFormat.type](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/type/) نوع النقطة، بينما يوفر [BulletFormat.char](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/char/) الرمز و[BulletFormat.numbered_bullet_style](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/numbered_bullet_style/) يحدد نمط الترقيم. كلا العنصرين يستخدمان نقاط سوداء بارتفاع 100٪ وإزاحة فقرة 25 نقطة:

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

### **استخدام النقاط المصورة**

تتيح النقاط المصورة لك استخدام صورة مخصصة بدلاً من رمز أو رقم.

يتطلب المثال وجود `bullets.png` في دليل العمل. يضيف المثال التالي بلغة Python صورة إلى مجموعة صور العرض كـ [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) ويستخدمها كنقطة فقرة. يضبط [BulletFormat.type](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/type/) لاستخدام نقطة مصورة ويعين الصورة عبر [BulletFormat.picture](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/picture/). يُضبط [BulletFormat.height](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/height/) على 100٪ لتحديد حجم النقطة بالنسبة لنص الفقرة:

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

ضبط [ParagraphFormat.depth](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/depth/) لتحديد مستويات الفقرات في القائمة. المستوى العلوي له عمق `0`.

يُعين المثال التالي بلغة Python قيم [ParagraphFormat.depth](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/depth/) من 0 إلى 3 لأربع فقرات، مُنشئًا هرمًا داخل إطار نص واحد. كل فقرة تستخدم نقطة رمزية، مع تبديل [BulletFormat.char](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/char/) بين نقطة دائرية وشرطة لتتمييز المستويات المتجاورة:

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

استخدام [BulletFormat.numbered_bullet_start_with](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/numbered_bullet_start_with/) لتعيين الرقم الأول المعروض لفقرة مرقمة.

يضبط المثال التالي بلغة Python [BulletFormat.type](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/type/) لاستخدام الترقيم لثلاث فقرات ويعين قيم [BulletFormat.numbered_bullet_start_with](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/numbered_bullet_start_with/) 2 و3 و7. يتم تكوين قيمة البداية بشكل منفصل لكل فقرة، مما يسمح بتخطي القيم المعروضة:

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

ضبط هوامش الفقرة والإزاحات للتحكم في موضع السطر الأول والسطر الملتف. يمكنك أيضًا تنسيق علامة نهاية الفقرة منفصلًا عن أجزاء النص المرئية.

### **ضبط إزاحة السطر الأول**

استخدام خاصية [ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/) للتحكم في إزاحة السطر الأول للفقرة. هذه الخاصية تحرك السطر الأول فقط بالنسبة لهامش الفقرة الأيسر. القيمة الموجبة تحرك السطر الأول إلى اليمين، بينما تظل السطور المتبقية محاذية إلى جسم الفقرة.

استخدم [ParagraphFormat.margin_left](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_left/) عندما تحتاج إلى تحريك الفقرة بأكملها. استخدم [ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/) عندما تحتاج إلى تحريك السطر الأول فقط.

يعطي المثال التالي ثلاث فقرات نفس [ParagraphFormat.margin_left](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_left/) بقيمة 20 نقطة و[ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/) بقيم 0 و20 و40 نقطة. تبدأ الأسطر الأولى بتعويضات متزايدة، بينما تحتفظ الأسطر الملتفة بنفس الهامش الأيسر:

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

### **ضبط إزاحة معلقة**

الإزاحة المعلقة هي تخطيط فقرة يبدأ فيه السطر الأول إلى اليسار من السطور المتبقية. في Aspose.Slides يمكنك إنشاء هذا التأثير باستخدام خاصية [ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/). اضبط `indent` على قيمة سالبة لتحريك السطر الأول إلى اليسار بالنسبة إلى جسم الفقرة.

عمليًا، يحدد [ParagraphFormat.margin_left](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_left/) الموضع الأيسر لجسم الفقرة، وتحدد [ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/) موضع السطر الأول بالنسبة لهذا الهامش. لإنشاء إزاحة معلقة، اضبط قيمة `margin_left` موجبة وقيمة `indent` سالبة.

هذا التنسيق مفيد للببليوجرافيا، المراجع، مدخلات القاموس، وغيرها من الفقرات التي يجب أن تكون الأسطر الملتفة تحت جسم الفقرة وليس تحت الحرف الأول للسطر الأول.

يربط المثال التالي بلغة Python قيم [ParagraphFormat.margin_left](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_left/) 40 و60 نقطة مع قيم [ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/) -20 و-30 نقطة. في كل فقرة يبدأ السطر الأول إلى اليسار من الأسطر الملتفة؛ الفقرة الثانية لها إزاحة معلقة أعمق:

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

### **ضبط خصائص تشغيل نهاية الفقرة**

خاصية [Paragraph.end_paragraph_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/end_paragraph_portion_format/) تتحكم في تنسيق علامة نهاية الفقرة. يحمل المثال ملف `Test.pptx` الذي يجب أن يحتوي على شريحة واحدة على الأقل، وينشئ [PortionFormat](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/) مع [PortionFormat.font_height](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/font_height/) مضبوطة على 48 نقطة و[PortionFormat.latin_font](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/latin_font/) إلى Times New Roman. يعين هذا التنسيق إلى علامة نهاية الفقرة الثانية، تاركًا أجزاء النص المرئية دون تغيير:

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

## **عد الأسطر المرسومة**

للقواعد المتعلقة بتغليف النص التلقائي وعلامات الترقيم عند نهايات الأسطر، راجع [التحكم في كسر السطر](/slides/ar/python-net/text-formatting/#control-line-breaking) و[التحكم في علامات الترقيم المتدلية](/slides/ar/python-net/text-formatting/#control-hanging-punctuation).

استخدم [Paragraph.get_lines_count](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_lines_count/) لعد الأسطر التي يشغلها الفقرة بعد تخطيط النص، بما في ذلك التغليف التلقائي. هذا مفيد عند التحقق من طول النص وتخطيطه في قوالب العروض.

الفقرة هي عنصر واحد في [TextFrame.paragraphs](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/paragraphs/)، ويمكن أن تحتل عدة أسطر مرسومة. كسر السطر الصريح داخل الفقرة يُدخل سطرًا جديدًا دون إنشاء فقرة أخرى. التغليف التلقائي يُنشئ أسطرًا بناءً على العرض المتاح دون إدراج كسر سطر صريح في النص. لذلك لا يعطي عد الفقرات أو أحرف كسر السطر عدد الأسطر المرسومة.

ينشئ المثال التالي شكل نص، يعد أسطره، يضيق الشكل، ثم يستبدل النص بسلسلة أقصر. يُفعِّل المثال [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/wrap_text/) ويعطّل [TextFrameFormat.autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/) بحيث يتحكم عرض الشكل في التغليف دون تصغير النص أو تغيير حجم الشكل تلقائيًا. كل قياس يستخدم [Paragraph.get_lines_count](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_lines_count/). أبعاد الشكل بالنقاط. أخيرًا، يضيف المثال فقرة أخرى ويجمع عدد الأسطر عبر إطار النص.

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

بهذا النص وهذه الأبعاد، يؤدي تضييق الشكل إلى زيادة عدد الأسطر، بينما استبدال النص بالسلسلة القصيرة يقلل منه. قد تختلف الأعداد الدقيقة حسب توفر الخطوط والاستبدال، حجم الخط، الهوامش، الإزاحات، التغليف، وإعدادات الضبط التلقائي. استخدم الخطوط وإعدادات التخطيط المقصودة للبيئة المستهدفة عند فحص القالب.

عدد الأسطر وحده لا يحدد ما إذا كان النص يتجاوز حاويته. الارتفاع المتاح، ارتفاع الأسطر، مسافات الفقرة والسطر، وسلوك الضبط التلقائي مهم أيضًا؛ حتى سطر واحد قد يتجاوز العرض المتاح إذا تم تعطيل التغليف.

## **استيراد وتصدير محتوى الفقرة**

استخدم HTML لإدخال النص إلى عرض تقديمي أو لتصدير فقرات موجودة للاستخدام خارجه. يظهر هذا القسم أيضًا كيفية تصيير فقرات فردية كصور، بما في ذلك الفقرات داخل خلايا الجداول.

### **استيراد نص HTML إلى الفقرات**

استخدم [ParagraphCollection.add_from_html](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphcollection/add_from_html/) لتحويل ترميز HTML إلى فقرات وأجزاء داخل إطار نص.

يقرأ المثال التالي بلغة Python HTML من `file.html` في دليل العمل ويمرره إلى [ParagraphCollection.add_from_html](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphcollection/add_from_html/). يمسح الفقرة الافتراضية لإطار النص بحيث يحتوي الإطار فقط على المحتوى المستورد. يترك الشكل المستطيل هامشًا 10 نقاط على كل جانب من الشريحة:

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

استخدم [ParagraphCollection.export_to_html](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphcollection/export_to_html/) لتصدير نطاق مختار من الفقرات كـ HTML. عند إعادة استخدام نص العرض على موقع ويب، قد ترغب في الحفاظ على التنسيق المحلي دون نقل خط العرض أو حجمه أو أنماط صندوق النص. اضبط [TextToHtmlConversionOptions.text_inheritance_limit](https://reference.aspose.com/slides/python-net/aspose.slides.export/texttohtmlconversionoptions/text_inheritance_limit/) للتحكم في مدى متابعة المصدِّر لتورّث التنسيق.

حمّل [العرض التقديمي النموذجي](text-inheritance.pptx) وضعه في دليل عمل التطبيق. يحتوي الشريحة الأولى على شكل نص واحد بالنص "Inherited text; explicit red 18pt". يستخدم الإدخال عدة مستويات تنسيق عمدًا:

- النمط النصي الافتراضي للعرض يزود بـ Calibri وحجم 28 pt.
- نمط النص من المستوى الأول لإطار النص يزود بنص أزرق ومائل.
- الفقرة تعيين نصًا عريضًا صراحةً.
- الجزء الثاني، "explicit red 18pt"، يحدد نصًا أحمر وحجم 18 pt صراحةً.

يصدِّر المثال الكامل التالي الفقرات نفسها ثلاث مرات. يمرّر [TextToHtmlConversionOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/texttohtmlconversionoptions/) إلى طريقة التصدير ويكتب كل نتيجة كملف HTML UTF-8 منفصل:

```python
import aspose.slides as slides

with slides.Presentation("text-inheritance.pptx") as presentation:
    text_shape = presentation.slides[0].shapes[0]
    paragraphs = text_shape.text_frame.paragraphs
    
    modes = {
        "All": slides.export.TextInheritanceLimit.ALL,
        "TextBox": slides.export.TextInheritanceLimit.TEXT_BOX,
        "ParagraphOnly": slides.export.TextInheritanceLimit.PARAGRAPH_ONLY,
    }

    for name, mode in modes.items():
        options = slides.export.TextToHtmlConversionOptions()
        options.text_inheritance_limit = mode

        html = paragraphs.export_to_html(0, paragraphs.count, options)
        with open(f"{name}.html", "w", encoding="utf-8") as html_stream:
            html_stream.write(html)
```

يحتوي HTML المُنشأ على CSS التالي للجزء الأول، "Inherited text; ". تُظهر الجدول الإعلانات ذات الصلة؛ تُحذف الخصائص المُولَّدة الأخرى للوضوح.

| المخرج | CSS ذي الصلة للجزء الأول | المظهر |
| --- | --- | --- |
| `All.html` | `font-family:'Calibri'; font-size:28pt; color:#0000ff; font-style:italic; font-weight:bold` | نص أزرق، عريض، مائل بحجم 28 pt في Calibri إذا كان الخط متاحًا. |
| `TextBox.html` | `color:#0000ff; font-style:italic; font-weight:bold` | نص أزرق، عريض، مائل؛ الصفحة أو المتصفح يزودان عائلة الخط والحجم. |
| `ParagraphOnly.html` | `font-weight:bold` | نص عريض؛ الصفحة أو المتصفح يزودان عائلة الخط، الحجم، اللون، والنمط المائل. |

الجزء الثاني يحتفظ بـ `color:#ff0000`، `font-size:18pt`، و`font-weight:bold` في جميع المخرجات الثلاث. كما يحتفظ بالمائل في `ALL` و`TEXT_BOX`، لكن ليس في `PARAGRAPH_ONLY`. لذلك لا يزيل تقييد التوريث التنسيق المعين صراحةً لفقرة أو جزء.

افتح الملفات في المتصفح نفسه لمقارنتها. في الوضعين المقيدين، تُحل الخصائص CSS المحذوفة بواسطة أنماط الصفحة المستهدفة أو الإعدادات الافتراضية للمتصفح، لذا يعتمد المظهر النهائي على مكان استخدام HTML.

### **تصيير الفقرة كصورة**

[Paragraph.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_image/) يصيّر فقرة فردية مباشرة ويعيد [IImage](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/). احفظ النتيجة إلى ملف أو تدفق باستخدام [IImage.save](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/save/). لا تحتاج إلى تصوير الشكل الحاوي أو قص صورة يدوية.

يمكن أن تُعيد [Paragraph.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_image/) `None` إذا تعذر العثور على الفقرة في مجموعتها الأصلية، أو لا توجد حدود عرض صالحة، أو لا يمكن تصييرها. تحقّق من النتيجة قبل حفظها وتخلص من الصورة المرتجعة بعد الاستخدام.

#### **تصيير الفقرة على المقياس الافتراضي**

يستخدم المثال `sample.pptx`، عرض تقديمي بشريحة واحدة حيث الشكل الأول هو صندوق نص يحتوي على ثلاث فقرات.

![صندوق النص بثلاث فقرات](paragraph_to_image_input.png)

يختار المثال التالي الفقرة الثانية عند الفهرس 1 ويستدعي [Paragraph.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_image/) بدون معاملات مقياس. يتحقق من أن الشكل يحتوي على الفقرة المطلوبة وأن التصيير يُعيد صورة قبل استدعاء [IImage.save](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/save/) لحفظها بصيغة PNG. يُحرّر مدير السياق موارد الصورة بعد الاستخدام.

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

#### **تصيير الفقرة في خلية جدول مع التكبير**

استخدم overload من [Paragraph.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_image/) الذي يقبل معاملات `scale_x` و`scale_y` لتحديد عوامل التكبير الأفقي والعمودي. ينشئ المثال التالي جدولًا، يصيّر الفقرة في خليةه الأولى بعرض وارتفاع مضاعفين، ويحفظ النتيجة كصورة PNG.

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

عامل التكبير `1` يحافظ على هذا المحور بالحجم البكسلي الافتراضي. على سبيل المثال، `2` لكلا العاملين ينتج صورة عرضها وارتفاعها تقريبًا ضعف الأبعاد الافتراضية، ما يؤدي إلى أربعة أضعاف عدد البكسلات. عادةً ما تُنتج القيم الأكبر نصًا أكثر حدة للتكبير أو مخرجات عالية الدقة، لكنها تزيد أيضًا من استهلاك الذاكرة وحجم الملف. القيم الأقل من `1` تُنتج صورًا أصغر بتفاصيل أقل. استخدم عوامل متساوية للحفاظ على نسبة أبعاد الفقرة؛ العوامل الأفقية والرأسية المختلفة تمتد المخرج بشكل مستقل.

يبقى تصيير الشكل بالكامل باستخدام [Shape.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_image/) مفيدًا عندما يجب أن يتضمن الإخراج تعبئة الشكل أو حدوده أو سياقه البصري الآخر. للحصول على صورة للفقرة فقط، استخدم [Paragraph.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_image/).

## **الأسئلة الشائعة**

**هل يمكنني إلغاء تغليف السطر بالكامل داخل إطار النص؟**

نعم. اضبط [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/wrap_text/) لإلغاء التغليف بحيث لا تنكسر الأسطر على حواف إطار النص.

**كيف يمكنني الحصول على حدود الفقرة الدقيقة على الشريحة؟**

استخدم [Paragraph.get_rect](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_rect/) لاسترجاع المستطيل المحيط بالفقرة. يقدم [Portion.get_rect](https://reference.aspose.com/slides/python-net/aspose.slides/portion/get_rect/) حدود الجزء الفردي.

**أين يتم التحكم في محاذاة الفقرة (يسار، يمين، وسط، أو ضبط)؟**

[ParagraphFormat.alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) هو إعداد على مستوى الفقرة وينطبق على الفقرة بأكملها بغض النظر عن تنسيق الأجزاء الفردية.

للمحاذاة العمودية لأجزاء بأحجام خطوط مختلفة داخل كل سطر، راجع [Align Fonts Within a Line](/slides/ar/python-net/text-formatting/#align-fonts-within-a-line).

**هل يمكنني تعيين لغة التدقيق لجزء من الفقرة؟**

نعم. اضبط [PortionFormat.language_id](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/language_id/) للأجزاء الفردية، بحيث تستطيع الفقرة احتواء نصوص بعدة لغات.