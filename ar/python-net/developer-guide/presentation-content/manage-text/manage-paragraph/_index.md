---
title: إدارة فقرات نص PowerPoint باستخدام بايثون
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
- إدارة الرصاص
- إزاحة الفقرة
- إزاحة معلقة
- رصاص الفقرة
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
description: "تعلم كيفية إنشاء وتنسيق الفقرات، الأجزاء، الرصاص، القوائم المرقمة، الإزاحات، محتوى HTML، وصور الفقرات باستخدام Aspose.Slides للبايثون عبر .NET."
---
## **نظرة عامة**

يمثل Aspose.Slides for Python عبر .NET النص كهرمية من إطارات النص والفقرات والأجزاء:

* [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) يمثل حاوية النص داخل الشكل ويوفر الوصول إلى مجموعة الفقرات الخاصة به.
* [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) يمثل فقرة واحدة في إطار النص ويوفر الوصول إلى أجزائه وتنسيق سطح الفقرة.
* [Portion](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) يمثل سلسلة نصية داخل الفقرة. يمكن لكل جزء أن يحتوي على نصه الخاص وتنسيق الحروف.

يمكن أن تحتوي الفقرة بالتالي على نص بخطوط وألوان وأحجام وتنسيقات أخرى مختلفة باستخدام أجزاء متعددة.

## **إنشاء وتنسيق الفقرات**

إنشاء فقرات في إطار النص الخاص بالشكل واستخدام الأجزاء لتنسيق سلاسل النص الفردية. يوضح هذا القسم كيفية دمج أجزاء متعددة داخل كل فقرة وتطبيق ألوان وأحجام خطوط وأنماط مختلفة.

### **إنشاء فقرات مع عدة أجزاء**

مثال Python التالي ينشئ ثلاث فقرات، كل منها يحتوي على ثلاث سلاسل نصية في مجموعة [Paragraph.portions](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/portions/). يتم إعادة استخدام الفقرة الافتراضية والجزء الفارغ، ثم إضافة الفقرات والأجزاء المتبقية. يُطبق التنسيق عبر [Portion.portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/portion/portion_format/): الجزء الأول في كل فقرة أحمر، عريض، و15 نقطة؛ الثاني أزرق، مائل، و18 نقطة. الجزء الثالث يحتفظ بالتنسيق الافتراضي:

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

## **إنشاء قوائم نقطية ورقمية**

تنظيم نص الفقرة في قوائم باستخدام رموز أو أرقام أو صور مخصصة. تغطي الأمثلة في هذا القسم تنسيق الرصاص، القوائم متعددة المستويات، وأرقام البداية المخصصة.

### **إنشاء قائمة نقطية أو رقمية**

تسهّل النقاط والأرقام مسح العناصر ذات الصلة. في Aspose.Slides، يتم تعريف إعدادات القائمة عبر [BulletFormat](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/).

يضيف مثال Python هذا رصاصة رمزية وبندًا مرقماً إلى نفس إطار النص. يحدد [BulletFormat.type](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/type/) نوع الرصاص، بينما يزود [BulletFormat.char](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/char/) الرمز و[BulletFormat.numbered_bullet_style](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/numbered_bullet_style/) نمط الترقيم. كلا العنصرين يستخدمان رصاصًا أسود بارتفاع 100 بالمئة وإزاحة فقرة 25 نقطة:

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

### **استخدام رصاصات صورة**

تتيح رصاصات الصورة استخدام صورة مخصصة بدلًا من رمز أو رقم.

يتطلب المثال وجود `bullets.png` في دليل العمل. يضيف مثال Python هذا صورة إلى مجموعة صور العرض كـ[PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) ويستخدمها كرصاص للفقرة. يضبط [BulletFormat.type](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/type/) لاستخدام رصاص صورة ويعيّن الصورة عبر [BulletFormat.picture](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/picture/). يُضبط [BulletFormat.height](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/height/) على 100 بالمئة لتحديد حجم الرصاص نسبةً إلى نص الفقرة:

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

اضبط [ParagraphFormat.depth](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/depth/) لتحديد مستويات الفقرات داخل القائمة. المستوى العلوي له عمق `0`.

يُعيّن مثال Python هذا قيم [ParagraphFormat.depth](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/depth/) من 0 إلى 3 لأربع فقرات، مكوّنًا هرمًا داخل إطار نص واحد. تستخدم كل فقرة رصاصًا رمزيًا، مع تبديل [BulletFormat.char](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/char/) بين رصاص دائري وشرطة لتمييز المستويات المتجاورة:

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

### **بدء عناصر القائمة الرقمية بقيم مخصصة**

استخدم [BulletFormat.numbered_bullet_start_with](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/numbered_bullet_start_with/) لتحديد الرقم الأول المعروض للفقرة الرقمية.

يحدد مثال Python هذا [BulletFormat.type](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/type/) استعمال الترقيم لثلاث فقرات ويعيّن قيم [BulletFormat.numbered_bullet_start_with](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/numbered_bullet_start_with/) بـ 2 و3 و7. تُضبط القيمة الابتدائية بشكل منفصل لكل فقرة، مما يسمح بتخطي الأرقام:

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

ضبط هوامش الفقرة والإزاحات للتحكم في موضع السطر الأول والسطر الملتف. يمكنك أيضًا تنسيق علامة نهاية الفقرة بشكل منفصل عن أجزاء النص الظاهرة.

### **ضبط إزاحة السطر الأول**

استخدم الخاصية [ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/) للتحكم في إزاحة السطر الأول للفقرة. هذه الخاصية تنقل السطر الأول فقط بالنسبة لهامش الفقرة الأيسر. القيمة الموجبة تحرك السطر الأول إلى اليمين، بينما تبقى السطور المتبقية محاذية إلى جسم الفقرة.

استخدم [ParagraphFormat.margin_left](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_left/) عندما تحتاج إلى نقل الفقرة بأكملها. استخدم [ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/) عندما تحتاج إلى نقل السطر الأول فقط.

يعطي المثال التالي ثلاث فقرات نفس [ParagraphFormat.margin_left](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_left/) بقيمة 20 نقطة وقيم [ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/) بـ 0 و20 و40 نقطة. تبدأ الأسطر الأولى بإزاحات متزايدة، بينما تحتفظ الأسطر الملتفة بنفس الهامش الأيسر:

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

### **ضبط إزاحة معلقة**

الإزاحة المعلقة هي تخطيط فقرة يبدأ فيه السطر الأول إلى اليسار من باقي السطور. في Aspose.Slides، تُنشئ هذا التأثير باستخدام الخاصية [ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/). اضبط `indent` على قيمة سالبة لتحريك السطر الأول إلى اليسار بالنسبة إلى جسم الفقرة.

عمليًا، تُحدد [ParagraphFormat.margin_left](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_left/) موضع الفقرة الأيسر، وتُحدد [ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/) موضع السطر الأول نسبةً إلى ذلك الهامش. لإنشاء إزاحة معلقة، اضبط قيمة `margin_left` موجبة وقيمة `indent` سالبة.

هذا التنسيق مفيد للمراجع، والاستشهادات، ومدخلات القاموس، وغيرها من الفقرات التي يجب أن تكون الأسطر الملتفة محاذية تحت جسم الفقرة بدلاً من تحت الحرف الأول للسطر الأول.

يربط مثال Python التالي قيم [ParagraphFormat.margin_left](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_left/) بـ 40 و60 نقطة مع قيم [ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/) بـ -20 و-30 نقطة. في كل فقرة يبدأ السطر الأول إلى اليسار من الأسطر الملتفة؛ الفقرة الثانية لها إزاحة معلقة أعمق:

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

![الإزاحة المعلقة للفقرات](hanging_indent.png)

### **ضبط خصائص تشغيل نهاية الفقرة**

تتحكم الخاصية [Paragraph.end_paragraph_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/end_paragraph_portion_format/) في تنسيق علامة نهاية الفقرة. يحمل المثال ملف `Test.pptx` الذي يجب أن يحتوي على شريحة واحدة على الأقل، وينشئ [PortionFormat](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/) حيث يُضبط [PortionFormat.font_height](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/font_height/) على 48 نقطة و[PortionFormat.latin_font](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/latin_font/) على Times New Roman. يُعيّن هذا التنسيق إلى علامة النهاية للفقرة الثانية، مع ترك أجزاء النص الظاهرة دون تغيير:

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

## **حساب عدد الأسطر المرسومة**

للقواعد المتعلقة بالتفاف النص تلقائيًا وعلامات الترقيم في نهايات الأسطر، راجع [Control Line Breaking](/slides/ar/python-net/text-formatting/#control-line-breaking) و[Control Hanging Punctuation](/slides/ar/python-net/text-formatting/#control-hanging-punctuation).

استخدم [Paragraph.get_lines_count](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_lines_count/) لحساب عدد الأسطر التي تشغلها الفقرة بعد تخطيط النص، بما في ذلك الالتفاف التلقائي. يُفيد ذلك عند فحص طول النص وتخطيطه في قوالب العروض التقديمية.

الفقرة هي عنصر واحد في [TextFrame.paragraphs](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/paragraphs/)، ويمكن أن تشغل عدة أسطر مرسومة. يُجبر كسر السطر الصريح داخل الفقرة على سطر جديد دون إنشاء فقرة أخرى. يُنشئ الالتفاف التلقائي أسطرًا بناءً على العرض المتاح دون إدخال كسر سطر صريح في النص. لذلك لا يُعطي عدّ الفقرات أو أحرف كسر السطر عدد الأسطر المرسومة.

ينشئ المثال التالي شكل نص، يحسب أسطره، يضيق الشكل، ثم يستبدل النص بسلسلة أقصر. يُفعّل المثال [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/wrap_text/) ويعطّل [TextFrameFormat.autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/) بحيث يتحكم عرض الشكل في الالتفاف دون تقليص النص تلقائيًا أو تعديل حجم الشكل. يستخدم كل قياس [Paragraph.get_lines_count](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_lines_count/). أبعاد الشكل بوحدة النقاط. في النهاية يضيف المثال فقرة أخرى ويجمع عدد الأسطر عبر إطار النص.

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

مع هذا النص وهذه الأبعاد، يؤدي تضييق الشكل إلى زيادة عدد الأسطر، بينما يقلل استبدال النص بالسلسلة القصيرة العدد. قد تختلف الأعداد الفعلية حسب توفر الخطوط والاستبدال، وحجم الخط، والهوامش، والإزاحة، والالتفاف، وإعدادات الملاءمة التلقائية. استخدم الخطوط وإعدادات التخطيط المقصودة للبيئة المستهدفة عند فحص القالب.

عدد الأسطر وحده لا يحدد ما إذا كان النص يتجاوز الحاوية. الارتفاع المتاح، وارتفاعات الأسطر، وتباعد الفقرات والأسطر، وسلوك الملاءمة التلقائية كلها عوامل مهمة؛ حتى سطر واحد قد يتجاوز العرض المتاح عندما يُعطَّل الالتفاف.

## **استيراد وتصدير محتوى الفقرة**

استخدم HTML لجلب النص إلى عرض تقديمي أو لتصدير الفقرات الحالية لاستخدامها خارجه. يُظهر هذا القسم أيضًا كيفية تصيّر فقرات فردية كصور، بما في ذلك الفقرات داخل خلايا الجداول.

### **استيراد نص HTML إلى الفقرات**

استخدم [ParagraphCollection.add_from_html](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphcollection/add_from_html/) لتحويل ترميز HTML إلى فقرات وأجزاء في إطار النص.

يقرأ مثال Python هذا HTML من `file.html` في دليل العمل ويمرّر الترميز إلى [ParagraphCollection.add_from_html](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphcollection/add_from_html/). يُنظّف الفقرة الافتراضية لإطار النص بحيث يحتوي الإطار فقط على المحتوى المستورد. يترك الشكل المستطيل هامشًا قدره 10 نقاط على كل جانب من الشريحة:

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

استخدم [ParagraphCollection.export_to_html](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphcollection/export_to_html/) لتصدير نطاق محدد من الفقرات كـHTML. عند إعادة استخدام نص العرض على موقع ويب، قد ترغب في الحفاظ على التأكيد المحلي دون نقل خط العرض أو حجمه أو أنماط مربع النص. اضبط [TextToHtmlConversionOptions.text_inheritance_limit](https://reference.aspose.com/slides/python-net/aspose.slides.export/texttohtmlconversionoptions/text_inheritance_limit/) للتحكم في مدى اتباع المُصدّر لتوارث التنسيق.

حمّل [العرض التوضيحي](text-inheritance.pptx) وضعه في دليل عمل التطبيق. يحتوي شريحته الأولى على شكل نص واحد بالنص "Inherited text; explicit red 18pt". يستخدم الإدخال عمدًا عدة مستويات تنسيق:

- يُوفّر نمط النص الافتراضي للعرض خط Calibri وحجم 28 نقطة.
- يُوفّر نمط النص من المستوى الأول في إطار النص نصًا أزرق ومائل.
- تُعيّن الفقرة بنص عريض صراحةً.
- الجزء الثاني، "explicit red 18pt"، يُعيّن نصًا أحمر وحجم 18 نقطة صراحةً.

يصدر المثال الكامل التالي نفس الفقرات ثلاث مرات. يمرّر [TextToHtmlConversionOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/texttohtmlconversionoptions/) إلى طريقة التصدير ويكتب كل نتيجة كملف HTML UTF-8 منفصل:

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

ينتج عن HTML التالي CSS للجزء الأول، "Inherited text; ". تُظهر الجدول الإعلانات ذات الصلة؛ تُحذف الخصائص المُنشأة الأخرى للوضوح.

| المخرجات | CSS ذي الصلة للجزء الأول | المظهر |
| --- | --- | --- |
| `All.html` | `font-family:'Calibri'; font-size:28pt; color:#0000ff; font-style:italic; font-weight:bold` | نص أزرق عريض مائل بحجم 28pt بخط Calibri، إذا كان هذا الخط متاحًا. |
| `TextBox.html` | `color:#0000ff; font-style:italic; font-weight:bold` | نص أزرق عريض مائل؛ الصفحة أو المتصفح المحيط يوفّر عائلة الخط والحجم. |
| `ParagraphOnly.html` | `font-weight:bold` | نص عريض؛ الصفحة أو المتصفح المحيط يوفّر عائلة الخط والحجم واللون والنمط المائل. |

يحتفظ الجزء الثاني بـ `color:#ff0000` و`font-size:18pt` و`font-weight:bold` في جميع المخرجات الثلاث. كما يحتفظ بالمائل في `ALL` و`TEXT_BOX`، لكن ليس في `PARAGRAPH_ONLY`. لذا فإن تقييد التوارث لا يزيل التنسيق المعين صراحةً إلى فقرة أو جزء.

افتح الملفات في نفس المتصفح للمقارنة. في الوضعين المقيدين، تُحل الخصائص CSS المحذوفة بواسطة أنماط الصفحة الهدف أو القيم الافتراضية للمتصفح، وبالتالي يعتمد المظهر النهائي على مكان استخدام HTML.

### **إنشاء مقطع HTML للوحة الحافظة**

[ParagraphCollection.export_to_html](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphcollection/export_to_html/) يُعيد سلسلة HTML. اضبط [TextToHtmlConversionOptions.add_clipboard_fragment_header](https://reference.aspose.com/slides/python-net/aspose.slides.export/texttohtmlconversionoptions/add_clipboard_fragment_header/) إلى `False` للحصول على HTML عادي أو إلى `True` لتضمين رأس لوحة الحافظة الخاصة بـ Windows. يوفّر الرأس إزاحات بايت UTF-8 للـHTML المحيط (`StartHTML` و`EndHTML`) والجزء الذي يُلصق (`StartFragment` و`EndFragment`).

يصدّر هذا المثال فقرتين مُنسّقتين كـHTML عادي (`html`) وكجزء لوحة حافظة HTML (`clipboard_html`). كتابة الجزء إلى لوحة الحافظة نظامية خطوة تطبيق منفصلة. إذا كان API للوحة الحافظة يتوقع بايتات خام، شفر الجزء كـUTF-8 بدون BOM.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 0, 0, 400, 100)
    paragraphs = shape.text_frame.paragraphs
    paragraphs.clear()
    paragraphs.add_from_html("<p>Status: <b>Ready</b></p><p><i>Next steps</i></p>")

    options = slides.export.TextToHtmlConversionOptions()
    options.add_clipboard_fragment_header = False
    html = paragraphs.export_to_html(0, paragraphs.count, options)

    options.add_clipboard_fragment_header = True
    clipboard_html = paragraphs.export_to_html(0, paragraphs.count, options)
```

### **تصيّر فقرة كصورة**

[Paragraph.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_image/) يُصوّر فقرة فردية مباشرةً ويُعيد [IImage](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/). احفظ النتيجة في ملف أو تدفق باستخدام [IImage.save](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/save/). لا تحتاج إلى تصوير الشكل الحاوي أو قص صورة نقطية يدويًا.

قد تُعيد [Paragraph.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_image/) `None` إذا لم تُعثر الفقرة في مجموعتها الأصلية، أو لم تكن لها حدود صالحة للتصوير، أو لا يمكن تصويرها. تحقق من النتيجة قبل حفظها وتخلص من الصورة المرجعة بعد الاستخدام.

#### **تصيّر الفقرة بالمقياس الافتراضي**

يستخدم المثال `sample.pptx`، عرضًا يحتوي على شريحة واحدة وإطار نص أولها صندوق نص يحتوي على ثلاث فقرات.

![صندوق النص بثلاث فقرات](paragraph_to_image_input.png)

يختار المثال الفقرة الثانية بالمؤشر 1 ويستدعي [Paragraph.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_image/) دون معلمات مقياس. يتحقق من وجود الفقرة المطلوبة وأن التصوير أعاد صورة قبل استدعاء [IImage.save](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/save/) لحفظها بصيغة PNG. يدير مدير السياق موارد الصورة بعد الاستخدام.

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

#### **تصيّر الفقرة في خلية جدول مع ضبط المقياس**

استخدم التحميل الزائد لـ[Paragraph.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_image/) الذي يقبل معلمات `scale_x` و`scale_y` لتحديد عوامل المقياس الأفقي والرأسي. ينشئ المثال جدولًا، يصوّر الفقرة في خليةه الأولى بمضاعفة العرض والارتفاع الافتراضيين، ويحفظ النتيجة كصورة PNG.

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

العامل المقياسي `1` يحافظ على ذلك المحور بحجمه البكسلي الافتراضي. على سبيل المثال، `2` لكل العاملين ينتج صورة بعرض وارتفاع يقرب من ضعف الأبعاد الافتراضية، أي أربعة أضعاف عدد البكسلات. العوامل الأكبر عمومًا تُنتج نصًا أكثر وضوحًا للتكبير أو الإخراج عالي الدقة، لكنها تزيد أيضًا من استهلاك الذاكرة وحجم الملف. العوامل أقل من `1` تُنتج صورًا أصغر مع تفاصيل أقل. استخدم عوامل متساوية للحفاظ على نسبة أبعاد الفقرة؛ العوامل الأفقية والرأسية المختلفة تمدِّن النتيجة بصورة مستقلة.

يظل تصوير الشكل كاملًا باستخدام [Shape.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_image/) مفيدًا عندما يجب تضمين تعبئة الشكل أو حدوده أو سياق بصري آخر. للحصول على صورة للفقرة فقط، استخدم [Paragraph.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_image/).

## **الأسئلة المتكررة**

**هل يمكنني إلغاء تفعيل التفاف السطر بالكامل داخل إطار النص؟**

نعم. اضبط [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/wrap_text/) لتعطيل الالتفاف بحيث لا تنكسر الأسطر عند حواف إطار النص.

**كيف يمكنني الحصول على حدود الفقرة على الشريحة بدقة؟**

استخدم [Paragraph.get_rect](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_rect/) لاسترجاع المستطيل المحيط بالفقرة. يوفّر [Portion.get_rect](https://reference.aspose.com/slides/python-net/aspose.slides/portion/get_rect/) حدود الجزء الفردي.

**أين يتم التحكم في محاذاة الفقرة (يسار، يمين، وسط أو مضاهاة)؟**

[ParagraphFormat.alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) هو إعداد مستوى الفقرة ويُطبق على الفقرة بأكملها بغض النظر عن تنسيق الأجزاء الفردية.

للمحاذاة العمودية لأجزاء مختلفة الأحجام داخل كل سطر، راجع [Align Fonts Within a Line](/slides/ar/python-net/text-formatting/#align-fonts-within-a-line).

**هل يمكنني تعيين لغة التدقيق لجزء من الفقرة؟**

نعم. اضبط [PortionFormat.language_id](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/language_id/) للأجزاء الفردية، بحيث يمكن لفقرة واحدة أن تحتوي نصًا بعدة لغات.