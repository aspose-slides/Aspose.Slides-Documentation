---
title: إدارة فقرات نص PowerPoint في بايثون
linktitle: إدارة الفقرة
type: docs
weight: 40
url: /ar/python-net/manage-paragraph/
keywords:
- إضافة نص
- إضافة فقرة
- إدارة النص
- إدارة الفقرة
- إدارة النقطة
- إزاحة الفقرة
- إزاحة معلقة
- نقطة الفقرة
- قائمة مرقمة
- قائمة نقطية
- خصائص الفقرة
- استيراد HTML
- تحويل النص إلى HTML
- تحويل الفقرة إلى HTML
- تحويل الفقرة إلى صورة
- تحويل النص إلى صورة
- تصدير الفقرة
- PowerPoint
- عرض تقديمي
- Python
- Aspose.Slides
description: "إتقان تنسيق الفقرات باستخدام Aspose.Slides لبايثون عبر .NET — تحسين المحاذاة والمسافات والأسلوب في عروض PowerPoint وOpenDocument في بايثون لجذب المشاهدين."
---

## **نظرة عامة**

توفر Aspose.Slides الفئات التي تحتاجها للعمل مع نص PowerPoint في بايثون.

* توفر Aspose.Slides الفئة [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) لإنشاء كائنات إطار النص. يمكن لكائن `TextFrame` أن يحتوي على فقرة واحدة أو أكثر (يتم الفصل بين الفقرات بإدخال عودة السطر).
* توفر Aspose.Slides الفئة [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) لإنشاء كائنات الفقرة. يمكن لكائن `Paragraph` أن يحتوي على جزء نصي واحد أو أكثر.
* توفر Aspose.Slides الفئة [Portion](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) لإنشاء كائنات الجزء النصي وتحديد خصائص تنسيقها.

يمكن لكائن `Paragraph` معالجة النص بخصائص تنسيق مختلفة من خلال كائنات `Portion` الأساسية الخاصة به.

## **إضافة فقرات متعددة تحتوي على أجزاء متعددة**

توضح هذه الخطوات كيفية إضافة إطار نص يحتوي على ثلاث فقرات، كل منها يحتوي على ثلاثة أجزاء:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. الحصول على مرجع إلى الشريحة المستهدفة بواسطة فهرستها.
1. إضافة [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) مستطيلة إلى الشريحة.
1. الحصول على الـ [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) المرتبط بـ [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/).
1. إنشاء كائنين من النوع [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) وإضافتهما إلى مجموعة الفقرات في الـ [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) (مع الفقرة الافتراضية، يصبح لدينا ثلاث فقرات).
1. لكل فقرة، إنشاء ثلاثة كائنات من النوع [Portion](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) وإضافتها إلى مجموعة الأجزاء الخاصة بتلك الفقرة.
1. تعيين النص لكل جزء.
1. تطبيق أي تنسيق مطلوب على كل جزء نصي باستخدام الخصائص التي توفرها فئة [Portion](https://reference.aspose.com/slides/python-net/aspose.slides/portion/).
1. حفظ العرض التقديمي المعدل.

الكود التالي بلغة بايثون ينفذ هذه الخطوات:
```python
import aspose.slides as slides
import aspose.pydrawing as draw

# إنشاء كائن من فئة Presentation لإنشاء ملف PPTX جديد.
with slides.Presentation() as presentation:

    # الوصول إلى الشريحة الأولى.
    slide = presentation.slides[0]

    # إضافة AutoShape مستطيل.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 300, 150)

    # الوصول إلى TextFrame الخاص بـ AutoShape.
    text_frame = shape.text_frame

    # إنشاء فقرات وأجزاء؛ يتم تطبيق التنسيق أدناه.
    paragraph0 = text_frame.paragraphs[0]
    portion01 = slides.Portion()
    portion02 = slides.Portion()
    paragraph0.portions.add(portion01)
    paragraph0.portions.add(portion02)

    paragraph1 = slides.Paragraph()
    text_frame.paragraphs.add(paragraph1)
    portion10 = slides.Portion()
    portion11 = slides.Portion()
    portion12 = slides.Portion()
    paragraph1.portions.add(portion10)
    paragraph1.portions.add(portion11)
    paragraph1.portions.add(portion12)

    paragraph2 = slides.Paragraph()
    text_frame.paragraphs.add(paragraph2)
    portion20 = slides.Portion()
    portion21 = slides.Portion()
    portion22 = slides.Portion()
    paragraph2.portions.add(portion20)
    paragraph2.portions.add(portion21)
    paragraph2.portions.add(portion22)

    for i in range(3):
        for j in range(3):
            text_frame.paragraphs[i].portions[j].text = "Portion0" + str(j)
            if j == 0:
                text_frame.paragraphs[i].portions[j].portion_format.fill_format.fill_type = slides.FillType.SOLID
                text_frame.paragraphs[i].portions[j].portion_format.fill_format.solid_fill_color.color = draw.Color.red
                text_frame.paragraphs[i].portions[j].portion_format.font_bold = 1
                text_frame.paragraphs[i].portions[j].portion_format.font_height = 15
            elif j == 1:
                text_frame.paragraphs[i].portions[j].portion_format.fill_format.fill_type = slides.FillType.SOLID
                text_frame.paragraphs[i].portions[j].portion_format.fill_format.solid_fill_color.color = draw.Color.blue
                text_frame.paragraphs[i].portions[j].portion_format.font_italic = 1
                text_frame.paragraphs[i].portions[j].portion_format.font_height = 18

    # حفظ ملف PPTX على القرص.
    presentation.save("paragraphs_and_portions_out.pptx", slides.export.SaveFormat.PPTX)
```


## **إدارة نقاط الفقرات**

تساعد القوائم النقطية على تنظيم وعرض المعلومات بسرعة وكفاءة. الفقرات ذات النقاط غالبًا ما تكون أسهل للقراءة والفهم.

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. الوصول إلى الشريحة المستهدفة بواسطة فهرستها.
1. إضافة [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) إلى الشريحة.
1. الوصول إلى الـ [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) الخاص بالشكل.
1. إزالة الفقرة الافتراضية من الـ [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/).
1. إنشاء الفقرة الأولى باستخدام فئة [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/).
1. ضبط نوع النقطة للفقرة إلى `SYMBOL` وتحديد حرف النقطة.
1. تعيين نص الفقرة.
1. ضبط مسافة إزاحة النقطة للفقرة.
1. ضبط لون النقطة.
1. ضبط حجم النقطة (الارتفاع).
1. إضافة الفقرة إلى مجموعة فقرات الـ [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/).
1. إضافة فقرة ثانية وتكرار الخطوات من 7 إلى 12.
1. حفظ العرض التقديمي.

الكود التالي بلغة بايثون يوضح كيفية إضافة فقرات نقطية:
```python
import aspose.slides as slides
import aspose.pydrawing as draw

# إنشاء مثيل للعرض التقديمي.
with slides.Presentation() as presentation:

    # الوصول إلى الشريحة الأولى.
    slide = presentation.slides[0]

    # إضافة والوصول إلى AutoShape.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # الوصول إلى إطار النص للـ AutoShape الذي تم إنشاؤه.
    text_frame = shape.text_frame

    # إزالة الفقرة الافتراضية.
    text_frame.paragraphs.remove_at(0)

    # إنشاء فقرة.
    paragraph = slides.Paragraph()

    # تعيين نمط النقطة للفقرة والرمز.
    paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph.paragraph_format.bullet.char = chr(8226)

    # تعيين نص الفقرة.
    paragraph.text = "Welcome to Aspose.Slides"

    # تعيين إزاحة النقطة.
    paragraph.paragraph_format.indent = 25

    # تعيين لون النقطة.
    paragraph.paragraph_format.bullet.color.color_type = slides.ColorType.RGB
    paragraph.paragraph_format.bullet.color.color = draw.Color.black
    paragraph.paragraph_format.bullet.is_bullet_hard_color = 1 

    # تعيين ارتفاع النقطة.
    paragraph.paragraph_format.bullet.height = 100

    # إضافة الفقرة إلى إطار النص.
    text_frame.paragraphs.add(paragraph)

    # إنشاء الفقرة الثانية.
    paragraph2 = slides.Paragraph()

    # تعيين نوع النقطية للفقرة ونمطها.
    paragraph2.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    paragraph2.paragraph_format.bullet.numbered_bullet_style = slides.NumberedBulletStyle.BULLET_CIRCLE_NUM_WDBLACK_PLAIN

    # تعيين نص الفقرة.
    paragraph2.text = "This is numbered bullet"

    # تعيين إزاحة النقطة.
    paragraph2.paragraph_format.indent = 25

    # تعيين لون النقطة.
    paragraph2.paragraph_format.bullet.color.color_type = slides.ColorType.RGB
    paragraph2.paragraph_format.bullet.color.color = draw.Color.black
    paragraph2.paragraph_format.bullet.is_bullet_hard_color = 1

    # تعيين ارتفاع النقطة.
    paragraph2.paragraph_format.bullet.height = 100

    # إضافة الفقرة إلى إطار النص.
    text_frame.paragraphs.add(paragraph2)

    # حفظ العرض التقديمي كملف PPTX.
    presentation.save("bullets_out.pptx", slides.export.SaveFormat.PPTX)
```


## **إدارة نقاط الصور**

تساعد القوائم النقطية على تنظيم وعرض المعلومات بسرعة وكفاءة. نقاط الصور سهلة القراءة والفهم.

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. الوصول إلى الشريحة المستهدفة بواسطة فهرستها.
1. إضافة [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) إلى الشريحة.
1. الوصول إلى الـ [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) الخاص بالشكل.
1. إزالة الفقرة الافتراضية من الـ [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/).
1. إنشاء الفقرة الأولى باستخدام فئة [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/).
1. تحميل صورة إلى كائن [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/).
1. ضبط نوع النقطة إلى [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) وتعيين الصورة.
1. تعيين نص الفقرة.
1. ضبط مسافة إزاحة الفقرة للنقطة.
1. ضبط لون النقطة.
1. ضبط ارتفاع النقطة.
1. إضافة الفقرة الجديدة إلى مجموعة فقرات الـ [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/).
1. إضافة فقرة ثانية وتكرار الخطوات من 8 إلى 12.
1. حفظ العرض التقديمي.

الكود التالي بلغة بايثون يوضح كيفية إضافة وإدارة نقاط الصور:
```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:

    # الوصول إلى الشريحة الأولى.
    slide = presentation.slides[0]

    # تحميل صورة النقطة.
    image = draw.Bitmap("bullets.png")
    pp_image = presentation.images.add_image(image)

    # إضافة والوصول إلى AutoShape.
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # الوصول إلى TextFrame للـ AutoShape الذي تم إنشاؤه.
    text_frame = auto_shape.text_frame

    # إزالة الفقرة الافتراضية.
    text_frame.paragraphs.remove_at(0)

    # إنشاء فقرة جديدة.
    paragraph = slides.Paragraph()
    paragraph.text = "Welcome to Aspose.Slides"

    # تعيين نوع نقطة الفقرة إلى صورة وتعيين الصورة.
    paragraph.paragraph_format.bullet.type = slides.BulletType.PICTURE
    paragraph.paragraph_format.bullet.picture.image = pp_image

    # تعيين ارتفاع النقطة.
    paragraph.paragraph_format.bullet.height = 100

    # إضافة الفقرة إلى TextFrame.
    text_frame.paragraphs.add(paragraph)

    # حفظ العرض التقديمي كملف PPTX.
    presentation.save("picture_bullets_out.pptx", slides.export.SaveFormat.PPTX)
    # حفظ العرض التقديمي كملف PPT.
    presentation.save("picture_bullets_out.ppt", slides.export.SaveFormat.PPT)
```


## **إدارة النقاط المتعددة المستويات**

تساعد القوائم النقطية على تنظيم وعرض المعلومات بسرعة وكفاءة. النقاط المتعددة المستويات سهلة القراءة والفهم.

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. الوصول إلى الشريحة المستهدفة بواسطة فهرستها.
1. إضافة [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) إلى الشريحة.
1. الوصول إلى الـ [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) الـ [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/).
1. إزالة الفقرة الافتراضية من الـ [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/).
1. إنشاء الفقرة الأولى باستخدام فئة [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) وضبط عمقها إلى 0.
1. إنشاء الفقرة الثانية باستخدام فئة [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) وضبط عمقها إلى 1.
1. إنشاء الفقرة الثالثة باستخدام فئة [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) وضبط عمقها إلى 2.
1. إنشاء الفقرة الرابعة باستخدام فئة [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) وضبط عمقها إلى 3.
1. إضافة الفقرات الجديدة إلى مجموعة فقرات الـ [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/).
1. حفظ العرض التقديمي.

الكود التالي بلغة بايثون يوضح كيفية إضافة وإدارة النقاط المتعددة المستويات:
```python
import aspose.slides as slides
import aspose.pydrawing as draw

# إنشاء مثيل للعرض التقديمي.
with slides.Presentation() as presentation:

    # الوصول إلى الشريحة الأولى.
    slide = presentation.slides[0]
    
    # إضافة AutoShape.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # الوصول إلى TextFrame للـ AutoShape الذي تم إنشاؤه.
    text_frame = auto_shape.text_frame
    
    # مسح الفقرة الافتراضية.
    text_frame.paragraphs.clear()

    # Add the first paragraph.
    paragraph1 = slides.Paragraph()
    paragraph1.text = "Content"
    paragraph1.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph1.paragraph_format.bullet.char = chr(8226)
    paragraph1.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph1.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # تعيين مستوى النقطة.
    paragraph1.paragraph_format.depth = 0

    # Add the second paragraph.
    paragraph2 = slides.Paragraph()
    paragraph2.text = "Second Level"
    paragraph2.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph2.paragraph_format.bullet.char = '-'
    paragraph2.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph2.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # تعيين مستوى النقطة.
    paragraph2.paragraph_format.depth = 1

    # Add the third paragraph.
    paragraph3 = slides.Paragraph()
    paragraph3.text = "Third Level"
    paragraph3.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph3.paragraph_format.bullet.char = chr(8226)
    paragraph3.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph3.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # تعيين مستوى النقطة.
    paragraph3.paragraph_format.depth = 2

    # Add the fourth paragraph.
    paragraph4 = slides.Paragraph()
    paragraph4.text = "Fourth Level"
    paragraph4.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph4.paragraph_format.bullet.char = '-'
    paragraph4.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph4.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # تعيين مستوى النقطة.
    paragraph4.paragraph_format.depth = 3

    # إضافة الفقرات إلى المجموعة.
    text_frame.paragraphs.add(paragraph1)
    text_frame.paragraphs.add(paragraph2)
    text_frame.paragraphs.add(paragraph3)
    text_frame.paragraphs.add(paragraph4)

    # حفظ العرض التقديمي كملف PPTX.
    presentation.save("multilevel_bullets_out.pptx", slides.export.SaveFormat.PPTX)
```


## **إدارة الفقرات بقوائم مرقمة مخصصة**

توفر فئة [BulletFormat](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/) الخاصية `numbered_bullet_start_with` (وغيرها) للتحكم في الترقيم والتنسيق المخصص للفقرات.

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. الوصول إلى الشريحة التي ستحتوي على الفقرات.
1. إضافة [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) إلى الشريحة.
1. الوصول إلى الـ [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) الخاص بالشكل.
1. إزالة الفقرة الافتراضية من الـ [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/).
1. إنشاء الفقرة الأولى من النوع [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) وضبط `numbered_bullet_start_with` إلى 2.
1. إنشاء الفقرة الثانية من النوع [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) وضبط `numbered_bullet_start_with` إلى 3.
1. إنشاء الفقرة الثالثة من النوع [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) وضبط `numbered_bullet_start_with` إلى 7.
1. إضافة الفقرات إلى مجموعة الـ [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/).
1. حفظ العرض التقديمي.

الكود التالي بلغة بايثون يوضح كيفية إضافة وإدارة فقرات بقوائم مرقمة مخصصة وتنسيقها.
```python
import aspose.slides as slides

with slides.Presentation() as presentation:

    # إضافة والوصول إلى AutoShape.
    shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # الوصول إلى TextFrame للـ AutoShape الذي تم إنشاؤه.
    text_frame = shape.text_frame

    # إزالة الفقرة الافتراضية الموجودة.
    text_frame.paragraphs.remove_at(0)

    # إنشاء العنصر الرقمي الأول (ابدأ من 2، مستوى العمق 4).
    paragraph1 = slides.Paragraph()
    paragraph1.text = "bullet 2"
    paragraph1.paragraph_format.depth = 4 
    paragraph1.paragraph_format.bullet.numbered_bullet_start_with = 2
    paragraph1.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    text_frame.paragraphs.add(paragraph1)

    # إنشاء العنصر الرقمي الثاني (ابدأ من 3، مستوى العمق 4).
    paragraph2 = slides.Paragraph()
    paragraph2.text = "bullet 3"
    paragraph2.paragraph_format.depth = 4
    paragraph2.paragraph_format.bullet.numbered_bullet_start_with = 3 
    paragraph2.paragraph_format.bullet.type = slides.BulletType.NUMBERED  
    text_frame.paragraphs.add(paragraph2)

    # إنشاء العنصر الرقمي الثالث (ابدأ من 7، مستوى العمق 4).
    paragraph5 = slides.Paragraph()
    paragraph5.text = "bullet 7"
    paragraph5.paragraph_format.depth = 4
    paragraph5.paragraph_format.bullet.numbered_bullet_start_with = 7
    paragraph5.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    text_frame.paragraphs.add(paragraph5)

    presentation.save("custom_bullets_out.pptx", slides.export.SaveFormat.PPTX)
```


## **ضبط مسافة إزاحة الفقرة**

تساعد مسافة إزاحة الفقرة على إنشاء هيكل قراءة واضح على الشريحة وضبط محاذاة النص. يوضح المثال أدناه كيفية ضبط مسافات الإزاحة العامة والمسافة الأولى في Aspose.Slides للبايثون عبر خصائص [ParagraphFormat](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/).

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. الوصول إلى الشريحة المستهدفة بواسطة فهرستها.
1. إضافة [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) مستطيلة إلى الشريحة.
1. إضافة [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) يحتوي على ثلاث فقرات إلى الـ [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/).
1. إخفاء حدود المستطيل.
1. ضبط مسافة الإزاحة لكل [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) باستخدام خاصية `paragraph_format`.
1. حفظ العرض التقديمي المعدل كملف PPT.

الكود التالي بللغة بايثون يوضح كيفية ضبط مسافات إزاحة الفقرات:
```python
import aspose.slides as slides

# إنشاء مثيل لفئة Presentation.
with slides.Presentation() as presentation:

    # الوصول إلى الشريحة الأولى.
    slide = presentation.slides[0]

    # إضافة شكل مستطيل.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 500, 150)

    # إضافة TextFrame إلى المستطيل.
    text_frame = shape.add_text_frame("This is first line \rThis is second line \rThis is third line")

    # ضبط النص ليتناسب مع الشكل.
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE

    # تعيين حد صلب للمستطيل.
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID

    # الحصول على الفقرة الأولى في TextFrame وتعيين نقطتها وإزاحتها.
    paragraph1 = text_frame.paragraphs[0]
    # تعيين نمط نقطة الفقرة والرمز.
    paragraph1.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph1.paragraph_format.bullet.char = chr(8226)
    paragraph1.paragraph_format.alignment = slides.TextAlignment.LEFT

    paragraph1.paragraph_format.depth = 2
    paragraph1.paragraph_format.indent = 30

    # الحصول على الفقرة الثانية في TextFrame وتعيين نقطتها وإزاحتها.
    paragraph2 = text_frame.paragraphs[1]
    paragraph2.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph2.paragraph_format.bullet.char = chr(8226)
    paragraph2.paragraph_format.alignment = slides.TextAlignment.LEFT
    paragraph2.paragraph_format.depth = 2
    paragraph2.paragraph_format.indent = 40

    # الحصول على الفقرة الثالثة في TextFrame وتعيين نقطتها وإزاحتها.
    paragraph3 = text_frame.paragraphs[2]
    paragraph3.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph3.paragraph_format.bullet.char = chr(8226)
    paragraph3.paragraph_format.alignment = slides.TextAlignment.LEFT
    paragraph3.paragraph_format.depth = 2
    paragraph3.paragraph_format.indent = 50

    # كتابة العرض التقديمي إلى القرص.
    presentation.save("indent_out.pptx", slides.export.SaveFormat.PPTX)
```


## **ضبط إزاحة معلقة للفقرات**

هذا الكود بلغة بايثون يوضح كيفية ضبط إزاحة معلقة لفقرة:
```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    auto_shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 250, 550, 150)

    paragraph1 = slides.Paragraph()
    paragraph1.text = "Example"
    paragraph2 = slides.Paragraph()
    paragraph2.text = "Set Hanging Indent for Paragraphs"
    paragraph3 = slides.Paragraph()
    paragraph3.text = "This Python code shows how to set a hanging indent for a paragraph: "

    paragraph2.paragraph_format.margin_left = 10
    paragraph3.paragraph_format.margin_left = 20

    paragraphs = auto_shape.text_frame.paragraphs
    paragraphs.add(paragraph1)
    paragraphs.add(paragraph2)
    paragraphs.add(paragraph3)

    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```


## **إدارة تنسيق جزء نهاية الفقرة**

عند الحاجة للتحكم في تنسيق “نهاية” الفقرة (التنسيق المطبق بعد آخر جزء نصي)، استخدم الخاصية `end_paragraph_portion_format`. يطبق المثال أدناه خط Times New Roman أكبر على نهاية الفقرة الثانية.

1. إنشاء أو فتح ملف [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. الحصول على الشريحة المستهدفة بواسطة الفهرس.
1. إضافة [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) مستطيلة إلى الشريحة.
1. استخدام الـ [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) الخاص بالشكل وإنشاء فقرتين.
1. إنشاء [PortionFormat](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/) بحجم 48 نقطة من نوع Times New Roman وتطبيقه كتنسيق نهاية الفقرة.
1. تعيينه إلى خاصية `end_paragraph_portion_format` للفقرة (يطبق على نهاية الفقرة الثانية).
1. كتابة العرض التقديمي المعدل كملف PPTX.

الكود التالي بلغة بايثون يوضح كيفية ضبط تنسيق نهاية الفقرة للفقرة الثانية:
```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
	shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 200, 250)

	paragraph1 = slides.Paragraph()
	paragraph1.portions.add(slides.Portion("Sample text"))

	end_paragraph_portion_format = slides.PortionFormat()
	end_paragraph_portion_format.font_height = 48
	end_paragraph_portion_format.latin_font = slides.FontData("Times New Roman")

	paragraph2 = slides.Paragraph()
	paragraph2.portions.add(slides.Portion("Sample text 2"))
	paragraph2.end_paragraph_portion_format = end_paragraph_portion_format

	shape.text_frame.paragraphs.add(paragraph1)
	shape.text_frame.paragraphs.add(paragraph2)

	presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```


## **استيراد نص HTML إلى الفقرات**

توفر Aspose.Slides دعمًا محسّنًا لاستيراد نص HTML إلى الفقرات.

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. الوصول إلى الشريحة المستهدفة بواسطة فهرستها.
1. إضافة [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) إلى الشريحة.
1. الوصول إلى الـ [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) الخاص بـ [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/).
1. إزالة الفقرة الافتراضية من الـ [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/).
1. قراءة ملف HTML المصدر.
1. إنشاء الفقرة الأولى باستخدام فئة [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/).
1. إضافة محتوى HTML إلى مجموعة فقرات الـ [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/).
1. حفظ العرض التقديمي المعدل.

الكود التالي بلغة بايثون ينفذ هذه الخطوات لاستيراد نص HTML إلى الفقرات.
```python
import aspose.slides as slides

# إنشاء مثيل Presentation فارغ.
with slides.Presentation() as presentation:

    # الوصول إلى الشريحة الأولى في العرض التقديمي.
    slide = presentation.slides[0]

    slide_width = presentation.slide_size.size.width
    slide_height = presentation.slide_size.size.height

    # إضافة AutoShape لاستيعاب محتوى HTML.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, slide_width - 20, slide_height - 10)

    # مسح جميع الفقرات في إطار النص المضاف.
    shape.text_frame.paragraphs.clear()

    # تحميل ملف HTML.
    with open("file.html", "rt") as html_stream:
        # إضافة النص من ملف HTML إلى إطار النص.
        shape.text_frame.paragraphs.add_from_html(html_stream.read())

    # حفظ العرض التقديمي.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **تصدير نص الفقرة إلى HTML**

توفر Aspose.Slides دعمًا محسّنًا لتصدير النص إلى HTML.

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) وتحميل العرض التقديمي المستهدف.
1. الوصول إلى الشريحة المطلوبة بواسطة فهرستها.
1. تحديد الشكل الذي يحتوي على النص المراد تصديره.
1. الوصول إلى الـ [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) الخاص بالشكل.
1. فتح تدفق ملف لكتابة المخرجات بصيغة HTML.
1. تحديد الفهرس المبدئي وتصدير الفقرات المطلوبة.

هذا المثال بلغة بايثون يوضح كيفية تصدير نص الفقرة إلى HTML.
```python
import aspose.slides as slides

# تحميل ملف العرض التقديمي.
with slides.Presentation("exporting_HTML_text.pptx") as presentation:
    # الوصول إلى الشريحة الأولى في العرض التقديمي.
    slide = presentation.slides[0]

    # فهرس الشكل المستهدف.
    index = 0

    # الوصول إلى الشكل عبر الفهرس.
    shape = slide.shapes[index]

    with open("output.html", "w") as html_stream:
        # كتابة بيانات الفقرة إلى HTML عبر توفير فهرس الفقرة الابتدائي وإجمالي عدد الفقرات المراد تصديرها.
        html_stream.write(shape.text_frame.paragraphs.export_to_html(0, shape.text_frame.paragraphs.count, None))
```


## **حفظ فقرة كنص صورة**

في هذا القسم نستعرض مثالين يوضحان كيفية حفظ فقرة نصية، ممثلة بفئة [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/)، كصورة. يتضمن كلا المثالين الحصول على صورة الشكل الذي يحتوي الفقرة باستخدام طريقة `get_image` من فئة [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/)، حساب حدود الفقرة داخل الشكل، وتصديرها كصورة بتنسيق bitmap. تُتيح هذه الأساليب استخراج أجزاء محددة من النص من عروض PowerPoint وحفظها كصور منفصلة، مما قد يكون مفيدًا في سيناريوهات مختلفة.

لنفترض أن لدينا ملف عرض تقديمي اسمه sample.pptx يحتوي شريحة واحدة، حيث الشكل الأول هو مربع نص يحتوي على ثلاث فقرات.

![The text box with three paragraphs](paragraph_to_image_input.png)

**مثال 1**

في هذا المثال نحصل على الفقرة الثانية كصورة. للقيام بذلك، نستخرج صورة الشكل من الشريحة الأولى للعرض ثم نحسب حدود الفقرة الثانية داخل إطار النص الخاص بالشكل. تُعاد رسم الفقرة على صورة bitmap جديدة، ثم تُحفظ بصيغة PNG. تُفيد هذه الطريقة عندما تحتاج إلى حفظ فقرة محددة كصورة منفصلة مع الحفاظ على الأبعاد والتنسيق الأصلي للنص.
```py
import aspose.slides as slides
import math
import io
from PIL import Image

with slides.Presentation("sample.pptx") as presentation:
    first_shape = presentation.slides[0].shapes[0]

    # حفظ الشكل في الذاكرة كصورة نقطية.
    with first_shape.get_image() as shape_image:
        shape_image_stream = io.BytesIO()
        shape_image.save(shape_image_stream, slides.ImageFormat.PNG)

    # إنشاء صورة نقطية للشكل من الذاكرة.
    shape_image_stream.seek(0)
    shape_bitmap = Image.open(shape_image_stream)

    # حساب حدود الفقرة الثانية.
    second_paragraph = first_shape.text_frame.paragraphs[1]
    paragraph_rectangle = second_paragraph.get_rect()

    # حساب إحداثيات وحجم الصورة الناتجة (أقل حجم - بكسل واحد 1x1).
    image_left = math.floor(paragraph_rectangle.x)
    image_top = math.floor(paragraph_rectangle.y)
    image_right = image_left + max(1, math.ceil(paragraph_rectangle.width))
    image_bottom = image_top + max(1, math.ceil(paragraph_rectangle.height))

    # قص صورة الشكل للحصول على صورة الفقرة فقط.
    paragraph_bitmap = shape_bitmap.crop((image_left, image_top, image_right, image_bottom))

    paragraph_bitmap.save("paragraph.png")
```


النتيجة:

![The paragraph image](paragraph_to_image_output.png)

**مثال 2**

في هذا المثال نمدّ النهج السابق بإضافة عوامل تكبير إلى صورة الفقرة. يُستخرج الشكل من العرض ويحفظ كصورة بعامل تكبير `2`. يتيح ذلك إخراجًا بدقة أعلى عند تصدير الفقرة. ثم تُحسب حدود الفقرة مع مراعاة التكبير. يكون التكبير مفيدًا عند الحاجة إلى صورة أكثر تفصيلًا، على سبيل المثال للاستخدام في مواد مطبوعة عالية الجودة.
```py
import aspose.slides as slides
import math
import io
from PIL import Image

image_scale_x = 2
image_scale_y = image_scale_x

with slides.Presentation("sample.pptx") as presentation:
    first_shape = presentation.slides[0].shapes[0]

    # حفظ الشكل في الذاكرة كصورة نقطية.
    with first_shape.get_image(slides.ShapeThumbnailBounds.SHAPE, image_scale_x, image_scale_y) as shape_image:
        shape_image_stream = io.BytesIO()
        shape_image.save(shape_image_stream, slides.ImageFormat.PNG)

    # إنشاء صورة نقطية للشكل من الذاكرة.
    shape_image_stream.seek(0)
    shape_bitmap = Image.open(shape_image_stream)

    # حساب حدود الفقرة الثانية.
    second_paragraph = first_shape.text_frame.paragraphs[1]
    paragraph_rectangle = second_paragraph.get_rect()
    paragraph_rectangle.x *= image_scale_x
    paragraph_rectangle.y *= image_scale_y
    paragraph_rectangle.width *= image_scale_x
    paragraph_rectangle.height *= image_scale_y

    # حساب الإحداثيات والحجم للصورة الناتجة (أقل حجم - بكسل واحد 1x1).
    image_left = math.floor(paragraph_rectangle.x)
    image_top = math.floor(paragraph_rectangle.y)
    image_right = image_left + max(1, math.ceil(paragraph_rectangle.width))
    image_bottom = image_top + max(1, math.ceil(paragraph_rectangle.height))

    # قص صورة الشكل للحصول على صورة الفقرة فقط.
    paragraph_bitmap = shape_bitmap.crop((image_left, image_top, image_right, image_bottom))

    paragraph_bitmap.save("paragraph.png")
```


## **الأسئلة المتكررة**

**هل يمكنني تعطيل التفاف النص تمامًا داخل إطار النص؟**

نعم. استخدم إعداد التفاف إطار النص ([wrap_text](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/wrap_text/)) لإيقاف التفاف النص بحيث لا تنكسر السطور عند حواف الإطار.

**كيف يمكنني الحصول على حدود الفقرة المحددة على الشريحة بدقة؟**

يمكنك استرجاع المستطيل المحيط بالفقرة (وحتى بالجزء النصي الفردي) لمعرفة موقعها وحجمها الدقيق على الشريحة.

**أين يتم التحكم في محاذاة الفقرة (يسار/يمين/وسط/ضبط)؟**

[Alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) هو إعداد على مستوى الفقرة في [ParagraphFormat](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/); يطبق على الفقرة بأكملها بغض النظر عن تنسيق الأجزاء الفردية.

**هل يمكنني تعيين لغة تدقيق إملائي لجزء فقط من الفقرة (مثلاً كلمة واحدة)؟**

نعم. تُحدد اللغة على مستوى الجزء ([PortionFormat.language_id](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/language_id/))، لذا يمكن وجود لغات متعددة داخل فقرة واحدة.