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
- إدارة النقطة
- إزاحة الفقرة
- إزاحة معلقة
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
description: "أتقن تنسيق الفقرات باستخدام Aspose.Slides للـ Python عبر .NET—حسّن المحاذاة والمسافات والأسلوب في عروض PowerPoint وOpenDocument في Python لجذب المشاهدين."
---
## **المقدمة**

توفر Aspose.Slides الفئات التي تحتاجها للعمل مع نص PowerPoint في Python.

* توفر Aspose.Slides فئة [TextFrame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframe/) لإنشاء كائنات إطار النص. يمكن لكائن `TextFrame` أن يحتوي على فقرة واحدة أو أكثر (كل فقرة مفصولة بإرجاع السطر).
* توفر Aspose.Slides فئة [Paragraph](https://reference.aspose.com/slides/ar/python-net/aspose.slides/paragraph/) لإنشاء كائنات الفقرة. يمكن لكائن `Paragraph` أن يحتوي على جزء نصي واحد أو أكثر.
* توفر Aspose.Slides فئة [Portion](https://reference.aspose.com/slides/ar/python-net/aspose.slides/portion/) لإنشاء كائنات الجزء النصي وتحديد خصائص التنسيق الخاصة بها.

يمكن لكائن `Paragraph` معالجة النص بخصائص تنسيق مختلفة عبر كائنات `Portion` الأساسية الخاصة به.

## **إضافة فقرات متعددة تحتوي على أجزاء متعددة**

تظهر هذه الخطوات كيفية إضافة إطار نص يحتوي على ثلاث فقرات، كل منها يحتوي على ثلاثة أجزاء:

1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/).
1. الحصول على مرجع إلى الشريحة المستهدفة عبر فهرستها.
1. إضافة [AutoShape](https://reference.aspose.com/slides/ar/python-net/aspose.slides/autoshape/) مستطيل إلى الشريحة.
1. الحصول على الـ[TextFrame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframe/) المرتبط بـ[AutoShape](https://reference.aspose.com/slides/ar/python-net/aspose.slides/autoshape/).
1. إنشاء كائنين من فئة [Paragraph](https://reference.aspose.com/slides/ar/python-net/aspose.slides/paragraph/) وإضافتهما إلى مجموعة الفقرات في الـ[TextFrame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframe/) (مع الفقرة الافتراضية، ينتج عن ذلك ثلاث فقرات).
1. لكل فقرة، إنشاء ثلاثة كائنات من فئة [Portion](https://reference.aspose.com/slides/ar/python-net/aspose.slides/portion/) وإضافتها إلى مجموعة الأجزاء الخاصة بتلك الفقرة.
1. تعيين النص لكل جزء.
1. تطبيق أي تنسيق مطلوب على كل جزء نصي باستخدام الخصائص التي توفرها فئة [Portion](https://reference.aspose.com/slides/ar/python-net/aspose.slides/portion/).
1. حفظ العرض التقديمي المعدل.

الكود التالي بلغة Python يطبق هذه الخطوات:

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

    # حفظ ملف PPTX إلى القرص.
    presentation.save("paragraphs_and_portions_out.pptx", slides.export.SaveFormat.PPTX)
```

## **إدارة نقاط الفقرات**

قوائم النقاط تساعدك على تنظيم المعلومات وعرضها بسرعة وكفاءة. الفقرات النقطية غالبًا ما تكون أسهل في القراءة والفهم.

1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/).
1. الوصول إلى الشريحة المستهدفة عبر فهرستها.
1. إضافة [AutoShape](https://reference.aspose.com/slides/ar/python-net/aspose.slides/autoshape/) إلى الشريحة.
1. الوصول إلى الـ[TextFrame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframe/) الخاص بالشكل.
1. إزالة الفقرة الافتراضية من الـ[TextFrame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframe/).
1. إنشاء الفقرة الأولى باستخدام فئة [Paragraph](https://reference.aspose.com/slides/ar/python-net/aspose.slides/paragraph/).
1. تعيين نوع نقطة الفقرة إلى `SYMBOL` وتحديد حرف النقطة.
1. تعيين نص الفقرة.
1. تعيين مسافة إزاحة النقطة للفقرة.
1. تعيين لون النقطة.
1. تعيين حجم النقطة (الارتفاع).
1. إضافة الفقرة إلى مجموعة فقرات الـ[TextFrame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframe/).
1. إضافة فقرة ثانية وتكرار الخطوات 7–12.
1. حفظ العرض التقديمي.

هذا الكود بلغة Python يوضح كيفية إضافة فقرات نقطية:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# إنشاء مثيل من العرض التقديمي.
with slides.Presentation() as presentation:

    # الوصول إلى الشريحة الأولى.
    slide = presentation.slides[0]

    # إضافة AutoShape والوصول إليه.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # الوصول إلى TextFrame الخاص بـ AutoShape الذي تم إنشاؤه.
    text_frame = shape.text_frame

    # إزالة الفقرة الافتراضية.
    text_frame.paragraphs.remove_at(0)

    # إنشاء فقرة.
    paragraph = slides.Paragraph()

    # تعيين نمط نقطة الفقرة والرمز.
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

    # إضافة الفقرة إلى TextFrame.
    text_frame.paragraphs.add(paragraph)

    # إنشاء الفقرة الثانية.
    paragraph2 = slides.Paragraph()

    # تعيين نوع ونمط نقطة الفقرة.
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

    # إضافة الفقرة إلى TextFrame.
    text_frame.paragraphs.add(paragraph2)

    # حفظ العرض التقديمي كملف PPTX.
    presentation.save("bullets_out.pptx", slides.export.SaveFormat.PPTX)
```

## **إدارة نقاط الصورة**

قوائم النقاط تساعدك على تنظيم المعلومات وعرضها بسرعة وكفاءة. نقاط الصورة سهلة القراءة والفهم.

1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/).
1. الوصول إلى الشريحة المستهدفة عبر فهرستها.
1. إضافة [AutoShape](https://reference.aspose.com/slides/ar/python-net/aspose.slides/autoshape/) إلى الشريحة.
1. الوصول إلى الـ[TextFrame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframe/) الخاص بالشكل.
1. إزالة الفقرة الافتراضية من الـ[TextFrame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframe/).
1. إنشاء الفقرة الأولى باستخدام فئة [Paragraph](https://reference.aspose.com/slides/ar/python-net/aspose.slides/paragraph/).
1. تحميل صورة إلى كائن [PPImage](https://reference.aspose.com/slides/ar/python-net/aspose.slides/ppimage/).
1. تعيين نوع النقطة إلى [PPImage](https://reference.aspose.com/slides/ar/python-net/aspose.slides/ppimage/) وربط الصورة.
1. تعيين نص الفقرة.
1. تعيين إزاحة الفقرة للنقطة.
1. تعيين لون النقطة.
1. تعيين ارتفاع النقطة.
1. إضافة الفقرة الجديدة إلى مجموعة فقرات الـ[TextFrame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframe/).
1. إضافة فقرة ثانية وتكرار الخطوات 8–12.
1. حفظ العرض التقديمي.

هذا الكود بلغة Python يوضح كيفية إضافة وإدارة نقاط الصورة:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:

    # الوصول إلى الشريحة الأولى.
    slide = presentation.slides[0]

    # تحميل صورة النقطة.
    image = draw.Bitmap("bullets.png")
    pp_image = presentation.images.add_image(image)

    # إضافة AutoShape والوصول إليه.
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # الوصول إلى TextFrame الخاص بـ AutoShape الذي تم إنشاؤه.
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

قوائم النقاط تساعدك على تنظيم المعلومات وعرضها بسرعة وكفاءة. النقاط متعددة المستويات سهلة القراءة والفهم.

1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/).
1. الوصول إلى الشريحة المستهدفة عبر فهرستها.
1. إضافة [AutoShape](https://reference.aspose.com/slides/ar/python-net/aspose.slides/autoshape/) إلى الشريحة.
1. الوصول إلى [AutoShape](https://reference.aspose.com/slides/ar/python-net/aspose.slides/autoshape/)'s [TextFrame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframe/).
1. إزالة الفقرة الافتراضية من الـ[TextFrame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframe/).
1. إنشاء الفقرة الأولى باستخدام فئة [Paragraph](https://reference.aspose.com/slides/ar/python-net/aspose.slides/paragraph/) وتعيين عمقها إلى 0.
1. إنشاء الفقرة الثانية باستخدام فئة [Paragraph](https://reference.aspose.com/slides/ar/python-net/aspose.slides/paragraph/) وتعيين عمقها إلى 1.
1. إنشاء الفقرة الثالثة باستخدام فئة [Paragraph](https://reference.aspose.com/slides/ar/python-net/aspose.slides/paragraph/) وتعيين عمقها إلى 2.
1. إنشاء الفقرة الرابعة باستخدام فئة [Paragraph](https://reference.aspose.com/slides/ar/python-net/aspose.slides/paragraph/) وتعيين عمقها إلى 3.
1. إضافة الفقرات الجديدة إلى مجموعة فقرات الـ[TextFrame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframe/).
1. حفظ العرض التقديمي.

الكود التالي بلغة Python يوضح كيفية إضافة وإدارة النقاط متعددة المستويات:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# إنشاء مثيل للعرض التقديمي.
with slides.Presentation() as presentation:

    # الوصول إلى الشريحة الأولى.
    slide = presentation.slides[0]
    
    # إضافة AutoShape.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # الوصول إلى TextFrame الخاص بـ AutoShape الذي تم إنشاؤه.
    text_frame = auto_shape.text_frame
    
    # مسح الفقرة الافتراضية.
    text_frame.paragraphs.clear()

    # إضافة الفقرة الأولى.
    paragraph1 = slides.Paragraph()
    paragraph1.text = "Content"
    paragraph1.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph1.paragraph_format.bullet.char = chr(8226)
    paragraph1.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph1.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # تعيين مستوى النقطة.
    paragraph1.paragraph_format.depth = 0

    # إضافة الفقرة الثانية.
    paragraph2 = slides.Paragraph()
    paragraph2.text = "Second Level"
    paragraph2.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph2.paragraph_format.bullet.char = '-'
    paragraph2.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph2.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # تعيين مستوى النقطة.
    paragraph2.paragraph_format.depth = 1

    # إضافة الفقرة الثالثة.
    paragraph3 = slides.Paragraph()
    paragraph3.text = "Third Level"
    paragraph3.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph3.paragraph_format.bullet.char = chr(8226)
    paragraph3.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph3.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # تعيين مستوى النقطة.
    paragraph3.paragraph_format.depth = 2

    # إضافة الفقرة الرابعة.
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

## **إدارة الفقرات مع قوائم رقمية مخصصة**

توفر فئة [BulletFormat](https://reference.aspose.com/slides/ar/python-net/aspose.slides/bulletformat/) الخاصية `numbered_bullet_start_with` (وغيرها) للتحكم في الترقيم المخصص وتنسيق الفقرات.

1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/).
1. الوصول إلى الشريحة التي ستحتوي على الفقرات.
1. إضافة [AutoShape](https://reference.aspose.com/slides/ar/python-net/aspose.slides/autoshape/) إلى الشريحة.
1. الوصول إلى الـ[TextFrame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframe/) الخاص بالشكل.
1. إزالة الفقرة الافتراضية من الـ[TextFrame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframe/).
1. إنشاء الفقرة الأولى عبر فئة [Paragraph](https://reference.aspose.com/slides/ar/python-net/aspose.slides/paragraph/) وتعيين `numbered_bullet_start_with` إلى 2.
1. إنشاء الفقرة الثانية عبر فئة [Paragraph](https://reference.aspose.com/slides/ar/python-net/aspose.slides/paragraph/) وتعيين `numbered_bullet_start_with` إلى 3.
1. إنشاء الفقرة الثالثة عبر فئة [Paragraph](https://reference.aspose.com/slides/ar/python-net/aspose.slides/paragraph/) وتعيين `numbered_bullet_start_with` إلى 7.
1. إضافة الفقرات إلى مجموعة الـ[TextFrame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframe/).
1. حفظ العرض التقديمي.

الكود التالي بلغة Python يوضح كيفية إضافة وإدارة الفقرات مع ترقيم وتنسيق مخصص:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:

    # إضافة والوصول إلى AutoShape.
    shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # الوصول إلى TextFrame الخاص بـ AutoShape الذي تم إنشاؤه.
    text_frame = shape.text_frame

    # إزالة الفقرة الافتراضية الحالية.
    text_frame.paragraphs.remove_at(0)

    # إنشاء العنصر الرقمي الأول (ابدأ بـ 2، مستوى العمق 4).
    paragraph1 = slides.Paragraph()
    paragraph1.text = "bullet 2"
    paragraph1.paragraph_format.depth = 4 
    paragraph1.paragraph_format.bullet.numbered_bullet_start_with = 2
    paragraph1.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    text_frame.paragraphs.add(paragraph1)

    # إنشاء العنصر الرقمي الثاني (ابدأ بـ 3، مستوى العمق 4).
    paragraph2 = slides.Paragraph()
    paragraph2.text = "bullet 3"
    paragraph2.paragraph_format.depth = 4
    paragraph2.paragraph_format.bullet.numbered_bullet_start_with = 3 
    paragraph2.paragraph_format.bullet.type = slides.BulletType.NUMBERED  
    text_frame.paragraphs.add(paragraph2)

    # إنشاء العنصر الرقمي الثالث (ابدأ بـ 7، مستوى العمق 4).
    paragraph5 = slides.Paragraph()
    paragraph5.text = "bullet 7"
    paragraph5.paragraph_format.depth = 4
    paragraph5.paragraph_format.bullet.numbered_bullet_start_with = 7
    paragraph5.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    text_frame.paragraphs.add(paragraph5)

    presentation.save("custom_bullets_out.pptx", slides.export.SaveFormat.PPTX)
```

## **تعيين إزاحة السطر الأول للفقرة**

استخدم الخاصية [ParagraphFormat.indent](https://reference.aspose.com/slides/ar/python-net/aspose.slides/paragraphformat/indent/) للتحكم في إزاحة السطر الأول للفقرة. هذه الخاصية تحرك السطر الأول فقط بالنسبة لهامش الفقرة الأيسر. القيمة الموجبة تحرك السطر الأول إلى اليمين، بينما تبقى الأسطر المتبقية محاذية إلى جسم الفقرة.

استخدم [ParagraphFormat.margin_left](https://reference.aspose.com/slides/ar/python-net/aspose.slides/paragraphformat/margin_left/) عندما تحتاج إلى تحريك الفقرة بأكملها. استخدم [ParagraphFormat.indent](https://reference.aspose.com/slides/ar/python-net/aspose.slides/paragraphformat/indent/) عندما تحتاج إلى تحريك السطر الأول فقط.

المثال أدناه ينشئ عدة فقرات ويطبق قيم `indent` مختلفة لتوضيح تأثير إزاحة السطر الأول على تخطيط الفقرة.

1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/).
2. الوصول إلى الشريحة المستهدفة.
3. إضافة [AutoShape](https://reference.aspose.com/slides/ar/python-net/aspose.slides/autoshape/) مستطيل إلى الشريحة.
4. إضافة [TextFrame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframe/) فارغ إلى الشكل وإزالة الفقرة الافتراضية.
5. إنشاء عدة فقرات وتعيين قيم مختلفة للخاصية [indent](https://reference.aspose.com/slides/ar/python-net/aspose.slides/paragraphformat/indent/) لها.
6. إضافة الفقرات إلى إطار النص.
7. حفظ العرض التقديمي المعدل.

هذا الكود يوضح كيفية تعيين إزاحة الفقرة:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    rectangle = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 420, 220)
    rectangle.fill_format.fill_type = slides.FillType.NO_FILL
    rectangle.line_format.fill_format.fill_type = slides.FillType.SOLID
    rectangle.line_format.fill_format.solid_fill_color.color = draw.Color.gray

    text_frame = rectangle.add_text_frame("")
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE
    text_frame.paragraphs.remove_at(0)

    first_paragraph = slides.Paragraph()
    first_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    first_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    first_paragraph.text = "No first-line indent. Wrapped lines start at the same position as the first line."
    first_paragraph.paragraph_format.margin_left = 20.0
    first_paragraph.paragraph_format.indent = 0.0

    second_paragraph = slides.Paragraph()
    second_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    second_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    second_paragraph.text = "First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body."
    second_paragraph.paragraph_format.margin_left = 20.0
    second_paragraph.paragraph_format.indent = 20.0

    third_paragraph = slides.Paragraph()
    third_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    third_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    third_paragraph.text = "First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see."
    third_paragraph.paragraph_format.margin_left = 20.0
    third_paragraph.paragraph_format.indent = 40.0

    text_frame.paragraphs.add(first_paragraph)
    text_frame.paragraphs.add(second_paragraph)
    text_frame.paragraphs.add(third_paragraph)

    presentation.save("paragraph_indent.pptx", slides.export.SaveFormat.PPTX)
```

النتيجة:

![المسافة البادئة للسطر الأول للفقرات](first_line_indent.png)

## **تعيين إزاحة معلقة للفقرة**

الإزاحة المعلقة هي تخطيط فقرة يبدأ فيه السطر الأول إلى يسار الأسطر المتبقية. في Aspose.Slides، يمكنك إنشاء هذا التأثير باستخدام الخاصية [ParagraphFormat.indent](https://reference.aspose.com/slides/ar/python-net/aspose.slides/paragraphformat/indent/). عيّن `indent` إلى قيمة سالبة لتحريك السطر الأول إلى اليسار بالنسبة إلى جسم الفقرة.

عمليًا، تحدد الخاصية [ParagraphFormat.margin_left](https://reference.aspose.com/slides/ar/python-net/aspose.slides/paragraphformat/margin_left/) الموضع الأيسر لجسم الفقرة، وتحدد الخاصية [ParagraphFormat.indent](https://reference.aspose.com/slides/ar/python-net/aspose.slides/paragraphformat/indent/) موضع السطر الأول نسبةً إلى هذا الهامش. لإنشاء إزاحة معلقة، عيّن قيمة `margin_left` موجبة وقيمة `indent` سالبة.

هذا التنسيق مفيد للمراجع، القوائم الببليوغرافية، مدخلات القاموس، وغيرها من الفقرات التي يجب أن تكون الأسطر المغلّفة محاذية تحت جسم الفقرة بدلاً من الحرف الأول للسطر الأول.

1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/).
2. الوصول إلى الشريحة المستهدفة.
3. إضافة [AutoShape](https://reference.aspose.com/slides/ar/python-net/aspose.slides/autoshape/) مستطيل إلى الشريحة.
4. إضافة [TextFrame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframe/) فارغ إلى الشكل وإزالة الفقرة الافتراضية.
5. إنشاء فقرات وتعيين قيمة موجبة للخاصية [margin_left](https://reference.aspose.com/slides/ar/python-net/aspose.slides/paragraphformat/margin_left/) لكل فقرة.
6. تعيين قيمة سالبة للخاصية [indent](https://reference.aspose.com/slides/ar/python-net/aspose.slides/paragraphformat/indent/) لإنشاء تأثير الإزاحة المعلقة.
7. إضافة الفقرات إلى إطار النص.
8. حفظ العرض التقديمي المعدل.

هذا الكود يوضح كيفية تعيين إزاحة معلقة للفقرة:

```py
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    rectangle = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 420, 220)
    rectangle.fill_format.fill_type = slides.FillType.NO_FILL
    rectangle.line_format.fill_format.fill_type = slides.FillType.SOLID
    rectangle.line_format.fill_format.solid_fill_color.color = draw.Color.gray

    text_frame = rectangle.add_text_frame("")
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE
    text_frame.paragraphs.remove_at(0)

    first_paragraph = slides.Paragraph()
    first_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    first_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    first_paragraph.text = "A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body."
    first_paragraph.paragraph_format.margin_left = 40.0
    first_paragraph.paragraph_format.indent = -20.0

    second_paragraph = slides.Paragraph()
    second_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    second_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    second_paragraph.text = "This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare."
    second_paragraph.paragraph_format.margin_left = 60.0
    second_paragraph.paragraph_format.indent = -30.0

    text_frame.paragraphs.add(first_paragraph)
    text_frame.paragraphs.add(second_paragraph)

    presentation.save("hanging_indent.pptx", slides.export.SaveFormat.PPTX)
```

النتيجة:

![الإزاحة المعلقة للفقرات](hanging_indent.png)

## **إدارة تنسيق جزء النهاية للفقرة**

عند الحاجة إلى التحكم في تنسيق "نهاية" الفقرة (التنسيق المطبق بعد آخر جزء نصي)، استخدم الخاصية `end_paragraph_portion_format`. يطبق المثال أدناه خطًا أكبر من نوع Times New Roman على نهاية الفقرة الثانية.

1. إنشاء أو فتح ملف [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/).
1. الحصول على الشريحة المستهدفة عبر الفهرس.
1. إضافة [AutoShape](https://reference.aspose.com/slides/ar/python-net/aspose.slides/autoshape/) مستطيل إلى الشريحة.
1. استخدام [TextFrame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframe/) الخاص بالشكل وإنشاء فقرتين.
1. إنشاء كائن [PortionFormat](https://reference.aspose.com/slides/ar/python-net/aspose.slides/portionformat/) بحجم 48 نقطة من نوع Times New Roman وتطبيقه كتنسيق جزء نهاية الفقرة.
1. تعيينه إلى الخاصية `end_paragraph_portion_format` للفقرة (يطبق على نهاية الفقرة الثانية).
1. كتابة العرض التقديمي المعدل كملف PPTX.

هذا الكود بلغة Python يوضح كيفية تعيين تنسيق نهاية الفقرة للفقرة الثانية:

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

توفر Aspose.Slides دعمًا محسنًا لاستيراد نص HTML إلى الفقرات.

1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/).
1. الوصول إلى الشريحة المستهدفة عبر فهرستها.
1. إضافة [AutoShape](https://reference.aspose.com/slides/ar/python-net/aspose.slides/autoshape/) إلى الشريحة.
1. الوصول إلى [TextFrame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframe/) الخاص بـ[AutoShape](https://reference.aspose.com/slides/ar/python-net/aspose.slides/autoshape/).
1. إزالة الفقرة الافتراضية من الـ[TextFrame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframe/).
1. قراءة ملف HTML المصدر.
1. إنشاء الفقرة الأولى باستخدام فئة [Paragraph](https://reference.aspose.com/slides/ar/python-net/aspose.slides/paragraph/).
1. إضافة محتوى HTML إلى مجموعة فقرات الـ[TextFrame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframe/).
1. حفظ العرض التقديمي المعدل.

الكود التالي بلغة Python ينفذ هذه الخطوات لاستيراد نص HTML إلى الفقرات:

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

توفر Aspose.Slides دعمًا محسنًا لتصدير النص إلى HTML.

1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/) وتحميل العرض التقديمي المستهدف.
1. الوصول إلى الشريحة المطلوبة عبر فهرستها.
1. اختيار الشكل الذي يحتوي على النص المراد تصديره.
1. الوصول إلى [TextFrame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframe/) الخاص بالشكل.
1. فتح تدفق ملف لكتابة مخرجات HTML.
1. تحديد الفهرس الابتدائي وتصدير الفقرات المطلوبة.

هذا المثال بلغة Python يوضح كيفية تصدير نص الفقرة إلى HTML:

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
        # كتابة بيانات الفقرة إلى HTML عن طريق توفير فهرس الفقرة الابتدائي والعدد الكلي للفقرات المراد تصديرها.
        html_stream.write(shape.text_frame.paragraphs.export_to_html(0, shape.text_frame.paragraphs.count, None))
```

## **حفظ الفقرة كصورة**

في هذا القسم، نستعرض مثالين يوضحان كيفية حفظ فقرة نصية، ممثلة بفئة [Paragraph](https://reference.aspose.com/slides/ar/python-net/aspose.slides/paragraph/)، كصورة. كلا المثالين يتضمنان الحصول على صورة الشكل الذي يحتوي الفقرة باستخدام طرق `get_image` من فئة [Shape](https://reference.aspose.com/slides/ar/python-net/aspose.slides/shape/)، حساب حدود الفقرة داخل الشكل، وتصديرها كصورة bitmap. تتيح هذه الأساليب استخراج أجزاء محددة من النص من عروض PowerPoint وحفظها كصور منفصلة، مما قد يكون مفيدًا لاستخدامها في سيناريوهات مختلفة.

دعونا نفترض أن لدينا ملف عرض تقديمي اسمه sample.pptx يحتوي على شريحة واحدة، حيث الشكل الأول هو صندوق نص يحتوي على ثلاث فقرات.

![صندوق النص مع ثلاث فقرات](paragraph_to_image_input.png)

**مثال 1**

في هذا المثال، نحصل على الفقرة الثانية كصورة. للقيام بذلك، نستخرج صورة الشكل من الشريحة الأولى للعرض التقديمي ثم نحسب حدود الفقرة الثانية في إطار النص الخاص بالشكل. ثم تُعاد رسم الفقرة على صورة bitmap جديدة تُحفظ بصيغة PNG. تكون هذه الطريقة مفيدة عندما تحتاج إلى حفظ فقرة محددة كصورة منفصلة مع الحفاظ على الأبعاد والتنسيق الأصلي للنص.

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

    # حساب إحداثيات وحجم الصورة الناتجة (الحد الأدنى - بكسل واحد × بكسل واحد).
    image_left = math.floor(paragraph_rectangle.x)
    image_top = math.floor(paragraph_rectangle.y)
    image_right = image_left + max(1, math.ceil(paragraph_rectangle.width))
    image_bottom = image_top + max(1, math.ceil(paragraph_rectangle.height))

    # قص صورة الشكل للحصول على صورة الفقرة فقط.
    paragraph_bitmap = shape_bitmap.crop((image_left, image_top, image_right, image_bottom))

    paragraph_bitmap.save("paragraph.png")
```

النتيجة:

![صورة الفقرة](paragraph_to_image_output.png)

**مثال 2**

في هذا المثال، نوسع النهج السابق بإضافة عوامل مقياس إلى صورة الفقرة. يتم استخراج الشكل من العرض التقديمي وحفظه كصورة بعامل مقياس `2`. يتيح ذلك مخرجات ذات دقة أعلى عند تصدير الفقرة. ثم تُحسب حدود الفقرة مع مراعاة المقياس. يمكن أن يكون المقياس مفيدًا عندما تحتاج إلى صورة أكثر تفصيلاً، على سبيل المثال للاستخدام في مواد مطبوعة عالية الجودة.

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

    # حساب الإحداثيات والحجم للصورة الناتجة (الحد الأدنى - بكسل واحد × بكسل واحد).
    image_left = math.floor(paragraph_rectangle.x)
    image_top = math.floor(paragraph_rectangle.y)
    image_right = image_left + max(1, math.ceil(paragraph_rectangle.width))
    image_bottom = image_top + max(1, math.ceil(paragraph_rectangle.height))

    # قص صورة الشكل للحصول على صورة الفقرة فقط.
    paragraph_bitmap = shape_bitmap.crop((image_left, image_top, image_right, image_bottom))

    paragraph_bitmap.save("paragraph.png")
```

## **الأسئلة الشائعة**

**هل يمكنني تعطيل التفاف السطر داخل إطار النص تمامًا؟**

نعم. استخدم إعداد التفاف النص في إطار النص ([wrap_text](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframeformat/wrap_text/)) لإيقاف التفاف السطور بحيث لا تنكسر عند حدود الإطار.

**كيف يمكنني الحصول على الحدود الدقيقة للفقرة على الشريحة؟**

يمكنك استخراج المستطيل الحدودي للفقرة (وحتى للجزء النصي الفردي) لمعرفة موقعها الدقيق وحجمها على الشريحة.

**أين يتم التحكم في محاذاة الفقرة (اليسار/اليمين/الوسط/مساواة)?**

[Alignment](https://reference.aspose.com/slides/ar/python-net/aspose.slides/paragraphformat/alignment/) هو إعداد على مستوى الفقرة في [ParagraphFormat](https://reference.aspose.com/slides/ar/python-net/aspose.slides/paragraphformat/); يُطبق على الفقرة بأكملها بغض النظر عن تنسيق الأجزاء الفردية.

**هل يمكنني تعيين لغة التدقيق الإملائي لجزء فقط من الفقرة (مثل كلمة واحدة)؟**

نعم. يتم تعيين اللغة على مستوى الجزء ([PortionFormat.language_id](https://reference.aspose.com/slides/ar/python-net/aspose.slides/portionformat/language_id/))، لذا يمكن أن تت coexist عدة لغات داخل الفقرة نفسها.