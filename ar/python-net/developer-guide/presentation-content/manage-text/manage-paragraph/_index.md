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
  - إدارة نص
  - إدارة فقرة
  - إدارة علامة تعداد
  - إزاحة الفقرة
  - إزاحة معلقة
  - علامة تعداد الفقرة
  - قائمة مرقمة
  - قائمة نقطية
  - خصائص الفقرة
  - استيراد HTML
  - نص إلى HTML
  - فقرة إلى HTML
  - فقرة إلى صورة
  - نص إلى صورة
  - تصدير فقرة
  - PowerPoint
  - عرض تقديمي
  - Python
  - Aspose.Slides
description: "تعلم كيفية إنشاء وتنسيق الفقرات، الأقسام، العلامات النقطية، القوائم المرقمة، الإزاحات، محتوى HTML، وصور الفقرات باستخدام Aspose.Slides للغة Python عبر .NET."
---
## **نظرة عامة**

يمثل Aspose.Slides for Python عبر .NET النص كهرمية من TextFrame، Paragraph، و Portion:

* [TextFrame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframe/) يمثل حاوية النص في الشكل ويُوفر وصولًا إلى مجموعة الفقرات الخاصة به.
* [Paragraph](https://reference.aspose.com/slides/ar/python-net/aspose.slides/paragraph/) يمثل فقرة واحدة في TextFrame ويوفر وصولًا إلى Portion وتنسيق على مستوى الفقرة.
* [Portion](https://reference.aspose.com/slides/ar/python-net/aspose.slides/portion/) يمثل تشغيل نص داخل Paragraph. يمكن لكل Portion أن يمتلك نصه وتنسيق على مستوى الأحرف.

وبالتالي يمكن للفقرة أن تحتوي نصًا بخطوط، ألوان، أحجام، وتنسيقات أخرى مختلفة باستخدام عدة Portion.

## **إنشاء وتنسيق الفقرات**

### **إنشاء فقرات مع عدة Portion**

الخطوات التالية تنشئ TextFrame يحتوي على ثلاث فقرات، كل منها يحتوي على ثلاثة Portion:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/).
2. الوصول إلى الشريحة ذات الصلة عبر فهرسها.
3. إضافة [AutoShape](https://reference.aspose.com/slides/ar/python-net/aspose.slides/autoshape/) مستطيلة إلى الشريحة.
4. الوصول إلى [TextFrame] الخاص بالشكل.
5. استخدام الفقرة الافتراضية وإضافة كائنين إضافيين من نوع [Paragraph](https://reference.aspose.com/slides/ar/python-net/aspose.slides/paragraph/) إلى TextFrame.
6. إضافة ما يكفي من كائنات [Portion](https://reference.aspose.com/slides/ar/python-net/aspose.slides/portion/) لكل فقرة لتحتوي على ثلاثة Portion. الفقرة الافتراضية تحتوي بالفعل على Portion فارغ واحد.
7. تعيين نص كل Portion.
8. تطبيق تنسيق على مستوى الأحرف عبر [Portion.portion_format](https://reference.aspose.com/slides/ar/python-net/aspose.slides/portion/portion_format/).
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

## **إنشاء القوائم النقطية والمرقمة**

### **إنشاء قائمة نقطية أو مرقمة**

تُسهّل الرموز النقطية والمرقمة من مسح العناصر ذات الصلة. في Aspose.Slides، يتم تعريف إعدادات القوائم من خلال [BulletFormat](https://reference.aspose.com/slides/ar/python-net/aspose.slides/bulletformat/).

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/).
2. الوصول إلى الشريحة ذات الصلة عبر فهرسها.
3. إضافة [AutoShape](https://reference.aspose.com/slides/ar/python-net/aspose.slides/autoshape/) إلى الشريحة المختارة.
4. الوصول إلى [TextFrame] الخاص بالشكل.
5. إزالة الفقرة الافتراضية من TextFrame.
6. إنشاء [Paragraph](https://reference.aspose.com/slides/ar/python-net/aspose.slides/paragraph/) لرمز نقطي.
7. تعيين [BulletFormat.type] إلى [BulletType.SYMBOL] وتحديد حرف الرمز النقطي.
8. تعيين نص الفقرة، والمسافة البادئة، ولون الرمز النقطي، وارتفاع الرمز النقطي.
9. إضافة الفقرة إلى TextFrame.
10. إنشاء فقرة ثانية وتعيين [BulletFormat.type] إلى [BulletType.NUMBERED].
11. تكوين نمط الرمز المرقم وإضافة الفقرة إلى TextFrame.
12. حفظ العرض التقديمي.

هذا المثال بلغة Python ينشئ رمزًا نقطيًا ورمزًا مرقمًا:

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

### **استخدام رموز نقطية بصورة**

تتيح رموز النقطية بالصورة استخدام صورة مخصصة بدلاً من رمز أو رقم.

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/).
2. الوصول إلى الشريحة ذات الصلة عبر فهرسها.
3. إضافة [AutoShape](https://reference.aspose.com/slides/ar/python-net/aspose.slides/autoshape/) والوصول إلى [TextFrame] الخاص به.
4. إزالة الفقرة الافتراضية من TextFrame.
5. تحميل صورة الرمز النقطي وإضافتها إلى مجموعة صور العرض التقديمي كـ [PPImage](https://reference.aspose.com/slides/ar/python-net/aspose.slides/ppimage/).
6. إنشاء [Paragraph](https://reference.aspose.com/slides/ar/python-net/aspose.slides/paragraph/) وتعيين نصه.
7. تعيين [BulletFormat.type] إلى [BulletType.PICTURE].
8. تعيين الصورة عبر [BulletFormat.picture](https://reference.aspose.com/slides/ar/python-net/aspose.slides/bulletformat/picture/) وتعيين ارتفاع الرمز النقطي.
9. إضافة الفقرة إلى TextFrame.
10. حفظ العرض التقديمي المعدل.

هذا المثال بلغة Python ينشئ رمزًا نقطيًا بصورة:

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

تعيين [ParagraphFormat.depth](https://reference.aspose.com/slides/ar/python-net/aspose.slides/paragraphformat/depth/) لتحديد الفقرات على مستويات مختلفة من القائمة. المستوى الأعلى له عمق `0`.

1. إنشاء [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/) والوصول إلى شريحة.
2. إضافة [AutoShape](https://reference.aspose.com/slides/ar/python-net/aspose.slides/autoshape/) وإزالة الفقرة الافتراضية من TextFrame الخاص به.
3. إنشاء أربع فقرات وتكوين رموزها النقطية.
4. تعيين قيم [ParagraphFormat.depth](https://reference.aspose.com/slides/ar/python-net/aspose.slides/paragraphformat/depth/) إلى `0`، `1`، `2`، و`3`.
5. إضافة الفقرات إلى TextFrame وحفظ العرض التقديمي.

هذا المثال بلغة Python ينشئ قائمة نقطية بأربعة مستويات:

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
2. إزالة الفقرة الافتراضية من TextFrame الخاص بالشكل.
3. إنشاء ثلاث فقرات مرقمة.
4. تعيين [BulletFormat.numbered_bullet_start_with](https://reference.aspose.com/slides/ar/python-net/aspose.slides/bulletformat/numbered_bullet_start_with/) إلى `2`، `3`، و`7` لكل فقرة على حدة.
5. إضافة الفقرات إلى TextFrame وحفظ العرض التقديمي.

هذا المثال بلغة Python يعيّن رقمًا ابتدائيًا مخصصًا لكل فقرة:

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

استخدام الخاصية [ParagraphFormat.indent](https://reference.aspose.com/slides/ar/python-net/aspose.slides/paragraphformat/indent/) للتحكم في إزاحة السطر الأول للفقرة. هذه الخاصية تحرك السطر الأول فقط بالنسبة لهامش الفقرة الأيسر. القيمة الموجبة تحرك السطر الأول إلى اليمين، بينما تبقى الأسطر المتبقية محاذاة إلى جسم الفقرة.

استخدم [ParagraphFormat.margin_left](https://reference.aspose.com/slides/ar/python-net/aspose.slides/paragraphformat/margin_left/) عندما تحتاج إلى تحريك الفقرة بأكملها. استخدم [ParagraphFormat.indent](https://reference.aspose.com/slides/ar/python-net/aspose.slides/paragraphformat/indent/) عندما تحتاج إلى تحريك السطر الأول فقط.

المثال أدناه ينشئ عدة فقرات ويطبق قيمًا مختلفة لـ [ParagraphFormat.indent](https://reference.aspose.com/slides/ar/python-net/aspose.slides/paragraphformat/indent/) لتوضيح تأثير إزاحة السطر الأول على تخطيط الفقرة.

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/).
2. الوصول إلى الشريحة المستهدفة.
3. إضافة [AutoShape](https://reference.aspose.com/slides/ar/python-net/aspose.slides/autoshape/) مستطيلة إلى الشريحة.
4. الوصول إلى [TextFrame] الخاص بالشكل وإزالة الفقرة الافتراضية.
5. إنشاء عدة فقرات وتعيين قيم مختلفة لـ [ParagraphFormat.indent](https://reference.aspose.com/slides/ar/python-net/aspose.slides/paragraphformat/indent/) لها.
6. إضافة الفقرات إلى TextFrame.
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

الإزاحة المعلقة هي تخطيط فقرة يبدأ فيه السطر الأول إلى اليسار من الأسطر المتبقية. في Aspose.Slides، يمكنك إنشاء هذا التأثير باستخدام الخاصية [ParagraphFormat.indent](https://reference.aspose.com/slides/ar/python-net/aspose.slides/paragraphformat/indent/). عيّن `indent` إلى قيمة سالبة لتحريك السطر الأول إلى اليسار بالنسبة إلى جسم الفقرة.

عمليًا، يحدد [ParagraphFormat.margin_left](https://reference.aspose.com/slides/ar/python-net/aspose.slides/paragraphformat/margin_left/) الموضع الأيسر لجسم الفقرة، وتحدد [ParagraphFormat.indent](https://reference.aspose.com/slides/ar/python-net/aspose.slides/paragraphformat/indent/) موضع السطر الأول بالنسبة إلى ذلك الهامش. لإنشاء إزاحة معلقة، عيّن قيمة `margin_left` موجبة وقيمة `indent` سالبة.

هذا التنسيق مفيد للمراجع، الملاحظات، مدخلات القاموس، وغيرها من الفقرات التي يجب أن تكون الأسطر المتطوية محاذية تحت جسم الفقرة بدلاً من الحرف الأول للسطر الأول.

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/).
2. الوصول إلى الشريحة المستهدفة.
3. إضافة [AutoShape](https://reference.aspose.com/slides/ar/python-net/aspose.slides/autoshape/) مستطيلة إلى الشريحة.
4. الوصول إلى [TextFrame] الخاص بالشكل وإزالة الفقرة الافتراضية.
5. إنشاء فقرات وتعيين قيمة موجبة لـ [ParagraphFormat.margin_left](https://reference.aspose.com/slides/ar/python-net/aspose.slides/paragraphformat/margin_left/) لكل فقرة.
6. تعيين قيمة سالبة لـ [ParagraphFormat.indent](https://reference.aspose.com/slides/ar/python-net/aspose.slides/paragraphformat/indent/) لإنشاء تأثير الإزاحة المعلقة.
7. إضافة الفقرات إلى TextFrame.
8. حفظ العرض التقديمي المعدل.

هذا الكود يوضح كيفية تعيين إزاحة معلقة لفقرة:

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

### **تعيين خصائص تشغيل نهاية الفقرة**

الخاصية [Paragraph.end_paragraph_portion_format](https://reference.aspose.com/slides/ar/python-net/aspose.slides/paragraph/end_paragraph_portion_format/) تتحكم في تنسيق علامة نهاية الفقرة. يحدد المثال التالي حجم الخط والخط اللاتيني لعلامة النهاية للفقرة الثانية:

1. تحميل [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/) والوصول إلى شريحة.
2. إضافة [AutoShape](https://reference.aspose.com/slides/ar/python-net/aspose.slides/autoshape/) ومسح الفقرة الافتراضية.
3. إنشاء فقرتين وإضافة Portion نصية لهما.
4. إنشاء [PortionFormat](https://reference.aspose.com/slides/ar/python-net/aspose.slides/portionformat/) لعلامة نهاية الفقرة الثانية.
5. تعيين [PortionFormat.font_height](https://reference.aspose.com/slides/ar/python-net/aspose.slides/portionformat/font_height/) و[PortionFormat.latin_font](https://reference.aspose.com/slides/ar/python-net/aspose.slides/portionformat/latin_font/).
6. إسناد التنسيق إلى [Paragraph.end_paragraph_portion_format](https://reference.aspose.com/slides/ar/python-net/aspose.slides/paragraph/end_paragraph_portion_format/) وحفظ العرض التقديمي.

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

## **عدد الأسطر المُرصدة**

للتحكم في قواعد الفقرة التي تؤثر على الالتفاف الآلي وعلامات الترقيم عند نهايات الأسطر، راجع [Control Line Breaking](/slides/ar/python-net/text-formatting/#control-line-breaking) و[Control Hanging Punctuation](/slides/ar/python-net/text-formatting/#control-hanging-punctuation).

استخدم [Paragraph.get_lines_count](https://reference.aspose.com/slides/ar/python-net/aspose.slides/paragraph/get_lines_count/) لحساب عدد الأسطر التي يشغلها فقرة بعد تخطيط النص، بما في ذلك الالتفاف الآلي. هذا مفيد عند فحص طول النص وتخطيطه في قوالب العروض التقديمية.

الفقرة هي عنصر واحد في [TextFrame.paragraphs](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframe/paragraphs/)، ويمكن أن تحتل عدة أسطر مُرصدة. يكسر السطر الصريح داخل الفقرة سطرًا جديدًا دون إنشاء فقرة جديدة. الالتفاف الآلي ينشئ أسطرًا بناءً على العرض المتاح دون إدراج فواصل صريحة في النص. لذا فإن عد الفقرات أو أحرف كسر السطر لا يعطي عدد الأسطر المُرصدة.

المثال التالي ينشئ شكل نص، يحسب أسطره، يضيق الشكل، ثم يستبدل النص بسلسلة أقصر. يتم تمكين الالتفاف وتعطيل الضبط التلقائي بحيث يتحكم عرض الشكل في الالتفاف دون تصغير النص أو تغيير حجم الشكل تلقائيًا. أبعاد الشكل بوحدات النقاط. أخيرًا، يضيف المثال فقرة أخرى ويجمع عدد الأسطر عبر TextFrame.

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

مع هذا النص وهذه الأبعاد، يؤدي تضييق الشكل إلى زيادة عدد الأسطر، بينما يؤدي استبدال النص بالسلسلة القصيرة إلى تقليله. قد تختلف الأعداد الدقيقة تبعًا لتوفر الخطوط والاستبدال، حجم الخط، الهوامش، الإزاحة، الالتفاف، وإعدادات الضبط التلقائي. استخدم الخطوط وإعدادات التخطيط المقصودة للبيئة المستهدفة عند فحص القالب.

عدد الأسطر وحده لا يحدد ما إذا كان النص سيتجاوز الحاوية. الارتفاع المتاح، ارتفاع الأسطر، تباعد الفقرات والأسطر، وسلوك الضبط التلقائي أيضًا مهم؛ فحتى سطر واحد يمكن أن يتجاوز العرض المتاح عندما يكون الالتفاف معطلًا.

## **استيراد وتصدير محتوى الفقرات**

### **استيراد نص HTML إلى الفقرات**

استخدم [ParagraphCollection.add_from_html](https://reference.aspose.com/slides/ar/python-net/aspose.slides/paragraphcollection/add_from_html/) لتحويل علامات HTML إلى فقرات وPortion في TextFrame.

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/).
2. الوصول إلى شريحة وإضافة [AutoShape](https://reference.aspose.com/slides/ar/python-net/aspose.slides/autoshape/).
3. الوصول إلى [TextFrame] الخاص بالشكل ومسح الفقرة الافتراضية.
4. قراءة ملف HTML المصدر.
5. تمرير سلسلة HTML إلى [ParagraphCollection.add_from_html](https://reference.aspose.com/slides/ar/python-net/aspose.slides/paragraphcollection/add_from_html/).
6. حفظ العرض التقديمي المعدل.

هذا المثال بلغة Python يستورد HTML إلى TextFrame:

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

استخدم [ParagraphCollection.export_to_html](https://reference.aspose.com/slides/ar/python-net/aspose.slides/paragraphcollection/export_to_html/) لتصدير نطاق محدد من الفقرات كـ HTML.

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/) وتحميل العرض المطلوب.
2. الوصول إلى الشريحة والعثور على [AutoShape](https://reference.aspose.com/slides/ar/python-net/aspose.slides/autoshape/) الذي يحتوي على النص.
3. الوصول إلى [TextFrame] الخاص بالشكل.
4. استدعاء [ParagraphCollection.export_to_html](https://reference.aspose.com/slides/ar/python-net/aspose.slides/paragraphcollection/export_to_html/) مع فهرس الفقرة الابتدائي وعدد الفقرات المراد تصديرها.
5. كتابة سلسلة HTML المسترجعة إلى ملف.

هذا المثال بلغة Python يصدر جميع الفقرات من شكل النص الأول:

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

### **رندرة فقرة كصورة**

[Paragraph](https://reference.aspose.com/slides/ar/python-net/aspose.slides/paragraph/) يوفر الطريقة `get_image` لرندرة فقرة منفردة مباشرة. تُعيد الطريقة كائنًا من نوع [IImage](https://reference.aspose.com/slides/ar/python-net/aspose.slides/iimage/) يمكنك حفظه إلى ملف أو تدفق باستخدام [IImage.save](https://reference.aspose.com/slides/ar/python-net/aspose.slides/iimage/save/). لا حاجة إلى رندرة الشكل المحتوي أو قص صورة يدوية.

قد تُعيد الطريقة `get_image` القيمة `None` إذا لم يتم العثور على الفقرة في مجموعتها الأصلية، أو لا توجد حدود رندرة صالحة، أو لا يمكن رندرها. تحقق من النتيجة قبل حفظها واستخدم الصورة المرجعية لإدارة الموارد.

#### **رندرة فقرة بالمقياس الافتراضي**

لنفترض أن لدينا ملف عرض تقديمي باسم sample.pptx يحتوي على شريحة واحدة، حيث يكون الشكل الأول صندوق نص يحتوي على ثلاث فقرات.

![صندوق النص مع ثلاث فقرات](paragraph_to_image_input.png)

المثال التالي يرندرب الفقرة الثانية في شكل نص عادي بالمقياس الافتراضي وي保存 الصورة المسترجعة بصيغة PNG:

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

#### **رندرة فقرة داخل خلية جدول مع масштаб**

تمرير عوامل مقياس أفقية ورأسية إلى `get_image` للتحكم في حجم الفقرة المرسومة. المثال التالي ينشئ جدولًا، يرندرب الفقرة في خليه الأولى بمضاعفة العرض والارتفاع الافتراضيين، ويحفظ النتيجة كصورة PNG:

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

عامل المقياس `1` يحافظ على ذلك المحور بحجمه الافتراضي بالبكسل. على سبيل المثال، `2` لكلا العاملين ينتج صورة يكون عرضها وارتفاعها تقريبًا ضعف الأبعاد الافتراضية، مما ينتج أربعة أضعاف عدد البكسلات. العوامل الأكبر عادةً ما تُنتج نصًا أكثر حدة للتكبير أو الإخراج عالي الدقة، لكنها تزيد أيضًا من استهلاك الذاكرة وحجم الملف. العوامل الأقل من `1` تنتج صورًا أصغر بتفاصيل أقل. استخدم عوامل متساوية للحفاظ على نسبة عرض الفقرة إلى ارتفاعها؛ العوامل الأفقية والرأسية المختلفة تُمدد المخرج بشكل مستقل.

رندرة شكل كامل باستخدام [Shape.get_image](https://reference.aspose.com/slides/ar/python-net/aspose.slides/shape/get_image/) يظل مفيدًا عندما يجب تضمين تعبئة الشكل، حافته، أو سياقه البصري. للحصول على صورة تحوي الفقرة فقط، استخدم `Paragraph.get_image`.

## **الأسئلة المتكررة**

**هل يمكنني تعطيل الالتفاف داخل TextFrame تمامًا؟**

نعم. عيّن [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframeformat/wrap_text/) لتعطيل الالتفاف بحيث لا تنكسر الأسطر عند حواف TextFrame.

**كيف يمكنني الحصول على حدود الفقرة المحددة على الشريحة؟**

استخدم [Paragraph.get_rect](https://reference.aspose.com/slides/ar/python-net/aspose.slides/paragraph/get_rect/) لاسترجاع مستطيل حدود الفقرة. توفر [Portion.get_rect](https://reference.aspose.com/slides/ar/python-net/aspose.slides/portion/get_rect/) حدود Portion فردي.

**أين يتم التحكم في محاذاة الفقرة (يسار، يمين، وسط، أو ضبط)?**

[ParagraphFormat.alignment](https://reference.aspose.com/slides/ar/python-net/aspose.slides/paragraphformat/alignment/) هو إعداد على مستوى الفقرة وينطبق على الفقرة بأكملها بغض النظر عن تنسيق الأجزاء الفردية.

**هل يمكنني تعيين لغة التدقيق لجزء من الفقرة؟**

نعم. عيّن [PortionFormat.language_id](https://reference.aspose.com/slides/ar/python-net/aspose.slides/portionformat/language_id/) للأجزاء الفردية، بحيث يمكن لفقرة واحدة أن تحتوي نصًا بلغات متعددة.