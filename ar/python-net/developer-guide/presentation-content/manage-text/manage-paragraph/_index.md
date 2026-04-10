---
title: إدارة فقرات نص PowerPoint باستخدام Python
linktitle: إدارة الفقرة
type: docs
weight: 40
url: /ar/python-net/manage-paragraph/
keywords:
- إضافة نص
- إضافة فقرة
- إدارة النص
- إدارة الفقرة
- إدارة النقاط
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
description: "أتقن تنسيق الفقرات باستخدام Aspose.Slides للـ Python عبر .NET—حسن المحاذاة والمسافات والأسلوب في عروض PowerPoint وOpenDocument باستخدام Python لجذب المشاهدين."
---
## **نظرة عامة**

توفر Aspose.Slides الفئات التي تحتاجها للعمل مع نص PowerPoint في Python.

* توفر Aspose.Slides فئة [TextFrame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframe/) لإنشاء كائنات إطار النص. يمكن لكائن `TextFrame` أن يحتوي على فقرة واحدة أو أكثر (كل فقرة مفصولة بعائد سطر).
* توفر Aspose.Slides فئة [Paragraph](https://reference.aspose.com/slides/ar/python-net/aspose.slides/paragraph/) لإنشاء كائنات الفقرة. يمكن لكائن `Paragraph` أن يحتوي على جزء نصي واحد أو أكثر.
* توفر Aspose.Slides فئة [Portion](https://reference.aspose.com/slides/ar/python-net/aspose.slides/portion/) لإنشاء كائنات الجزء النصي وتحديد خصائص تنسيقه.

يمكن لكائن `Paragraph` التعامل مع النص بخصائص تنسيق مختلفة من خلال كائنات `Portion` التابعة له.

## **إضافة فقرات متعددة تحتوي على أجزاء متعددة**

تُظهر هذه الخطوات كيفية إضافة إطار نص يحتوي على ثلاث فقرات، كل منها يحتوي على ثلاثة أجزاء:

1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/) .
1. الحصول على مرجع إلى الشريحة المستهدفة باستخدام الفهرس الخاص بها.
1. إضافة [AutoShape](https://reference.aspose.com/slides/ar/python-net/aspose.slides/autoshape/) مستطيلة إلى الشريحة.
1. الحصول على [TextFrame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframe/) المرتبط بـ [AutoShape](https://reference.aspose.com/slides/ar/python-net/aspose.slides/autoshape/) .
1. إنشاء كائنين من فئة [Paragraph](https://reference.aspose.com/slides/ar/python-net/aspose.slides/paragraph/) وإضافتهما إلى مجموعة الفقرات في [TextFrame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframe/) (مع الفقرة الافتراضية، ينتج عن ذلك ثلاث فقرات).
1. لكل فقرة، إنشاء ثلاثة كائنات من فئة [Portion](https://reference.aspose.com/slides/ar/python-net/aspose.slides/portion/) وإضافتها إلى مجموعة الأجزاء الخاصة بتلك الفقرة.
1. تعيين النص لكل جزء.
1. تطبيق أي تنسيق مرغوب لكل جزء نصي باستخدام الخصائص التي توفرها فئة [Portion](https://reference.aspose.com/slides/ar/python-net/aspose.slides/portion/) .
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

    # حفظ ملف PPTX على القرص.
    presentation.save("paragraphs_and_portions_out.pptx", slides.export.SaveFormat.PPTX)
```

## **إدارة نقاط الفقرات**

قوائم النقاط تساعدك على تنظيم وعرض المعلومات بسرعة وكفاءة. الفقرات ذات النقاط غالبًا ما تكون أسهل في القراءة والفهم.

1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/) .
2. الوصول إلى الشريحة المستهدفة باستخدام الفهرس الخاص بها.
3. إضافة [AutoShape](https://reference.aspose.com/slides/ar/python-net/aspose.slides/autoshape/) إلى الشريحة.
4. الوصول إلى [TextFrame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframe/) الخاص بالشكل.
5. إزالة الفقرة الافتراضية من [TextFrame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframe/) .
6. إنشاء الفقرة الأولى باستخدام فئة [Paragraph](https://reference.aspose.com/slides/ar/python-net/aspose.slides/paragraph/) .
7. تعيين نوع النقطة في الفقرة إلى `SYMBOL` وتحديد حرف النقطة.
8. تعيين نص الفقرة.
9. تعيين إزاحة النقطة للفقرة.
10. تعيين لون النقطة.
11. تعيين حجم النقطة (الارتفاع).
12. إضافة الفقرة إلى مجموعة الفقرات في [TextFrame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframe/) .
13. إضافة فقرة ثانية وتكرار الخطوات من 7 إلى 12.
14. حفظ العرض التقديمي.

هذا الكود بلغة Python يوضح كيفية إضافة فقرات ذات نقاط:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# إنشاء مثيل للعرض التقديمي.
with slides.Presentation() as presentation:

    # الوصول إلى الشريحة الأولى.
    slide = presentation.slides[0]

    # إضافة والوصول إلى AutoShape.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # الوصول إلى إطار النص لـ AutoShape المُنشئ.
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

    # تعيين نوع النقطة للفقرة والنمط.
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

قوائم النقاط تساعدك على تنظيم وعرض المعلومات بسرعة وكفاءة. نقاط الصور سهلة القراءة والفهم.

1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/) .
2. الوصول إلى الشريحة المستهدفة باستخدام الفهرس الخاص بها.
3. إضافة [AutoShape](https://reference.aspose.com/slides/ar/python-net/aspose.slides/autoshape/) إلى الشريحة.
4. الوصول إلى [TextFrame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframe/) الخاص بالشكل.
5. إزالة الفقرة الافتراضية من [TextFrame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframe/) .
6. إنشاء الفقرة الأولى باستخدام فئة [Paragraph](https://reference.aspose.com/slides/ar/python-net/aspose.slides/paragraph/) .
7. تحميل صورة إلى كائن [PPImage](https://reference.aspose.com/slides/ar/python-net/aspose.slides/ppimage/) .
8. تعيين نوع النقطة إلى [PPImage](https://reference.aspose.com/slides/ar/python-net/aspose.slides/ppimage/) وتعيين الصورة.
9. تعيين نص الفقرة.
10. تعيين إزاحة الفقرة للنقطة.
11. تعيين لون النقطة.
12. تعيين ارتفاع النقطة.
13. إضافة الفقرة الجديدة إلى مجموعة الفقرات في [TextFrame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframe/) .
14. إضافة فقرة ثانية وتكرار الخطوات من 8 إلى 12.
15. حفظ العرض التقديمي.

هذا الكود بلغة Python يوضح كيفية إضافة وإدارة نقاط الصور:

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

    # الوصول إلى TextFrame الخاص بـ AutoShape المُنشئ.
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

    # إضافة الفقرة إلى إطار النص.
    text_frame.paragraphs.add(paragraph)

    # حفظ العرض التقديمي كملف PPTX.
    presentation.save("picture_bullets_out.pptx", slides.export.SaveFormat.PPTX)
    # حفظ العرض التقديمي كملف PPT.
    presentation.save("picture_bullets_out.ppt", slides.export.SaveFormat.PPT)
```

## **إدارة النقاط المتعددة المستويات**

قوائم النقاط تساعدك على تنظيم وعرض المعلومات بسرعة وكفاءة. النقاط المتعددة المستويات سهلة القراءة والفهم.

1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/) .
2. الوصول إلى الشريحة المستهدفة باستخدام الفهرس الخاص بها.
3. إضافة [AutoShape](https://reference.aspose.com/slides/ar/python-net/aspose.slides/autoshape/) إلى الشريحة.
4. الوصول إلى [TextFrame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframe/) الخاص بـ [AutoShape](https://reference.aspose.com/slides/ar/python-net/aspose.slides/autoshape/) .
5. إزالة الفقرة الافتراضية من [TextFrame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframe/) .
6. إنشاء الفقرة الأولى باستخدام فئة [Paragraph](https://reference.aspose.com/slides/ar/python-net/aspose.slides/paragraph/) وتعيين عمقها إلى 0.
7. إنشاء الفقرة الثانية باستخدام فئة [Paragraph](https://reference.aspose.com/slides/ar/python-net/aspose.slides/paragraph/) وتعيين عمقها إلى 1.
8. إنشاء الفقرة الثالثة باستخدام فئة [Paragraph](https://reference.aspose.com/slides/ar/python-net/aspose.slides/paragraph/) وتعيين عمقها إلى 2.
9. إنشاء الفقرة الرابعة باستخدام فئة [Paragraph](https://reference.aspose.com/slides/ar/python-net/aspose.slides/paragraph/) وتعيين عمقها إلى 3.
10. إضافة الفقرات الجديدة إلى مجموعة الفقرات في [TextFrame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframe/) .
11. حفظ العرض التقديمي.

الكود التالي بلغة Python يوضح كيفية إضافة وإدارة النقاط المتعددة المستويات:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# إنشاء مثيل للعرض التقديمي.
with slides.Presentation() as presentation:

    # الوصول إلى الشريحة الأولى.
    slide = presentation.slides[0]
    
    # إضافة AutoShape.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # الوصول إلى TextFrame الخاص بـ AutoShape المُنشأ.
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

## **إدارة الفقرات مع قوائم مرقمة مخصصة**

توفر فئة [BulletFormat](https://reference.aspose.com/slides/ar/python-net/aspose.slides/bulletformat/) الخاصية `numbered_bullet_start_with` (وأخرى) للتحكم في الترقيم والتنسيق المخصص للفقرات.

1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/) .
2. الوصول إلى الشريحة التي ستحتوي على الفقرات.
3. إضافة [AutoShape](https://reference.aspose.com/slides/ar/python-net/aspose.slides/autoshape/) إلى الشريحة.
4. الوصول إلى [TextFrame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframe/) الخاص بالشكل.
5. إزالة الفقرة الافتراضية من [TextFrame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframe/) .
6. إنشاء الفقرة الأولى من فئة [Paragraph](https://reference.aspose.com/slides/ar/python-net/aspose.slides/paragraph/) وتعيين `numbered_bullet_start_with` إلى 2.
7. إنشاء الفقرة الثانية من فئة [Paragraph](https://reference.aspose.com/slides/ar/python-net/aspose.slides/paragraph/) وتعيين `numbered_bullet_start_with` إلى 3.
8. إنشاء الفقرة الثالثة من فئة [Paragraph](https://reference.aspose.com/slides/ar/python-net/aspose.slides/paragraph/) وتعيين `numbered_bullet_start_with` إلى 7.
9. إضافة الفقرات إلى مجموعة [TextFrame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframe/) .
10. حفظ العرض التقديمي.

الكود التالي بلغة Python يوضح كيفية إضافة وإدارة الفقرات مع ترقيم وتنسيق مخصص.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:

    # إضافة AutoShape والوصول إليه.
    shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # الوصول إلى TextFrame الخاص بـ AutoShape المُنشأ.
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

## **تعيين إزاحة السطر الأول للفقرة**

استخدم الخاصية [ParagraphFormat.indent](https://reference.aspose.com/slides/ar/python-net/aspose.slides/paragraphformat/indent/) للتحكم في إزاحة السطر الأول للفقرة. تنقل هذه الخاصية السطر الأول فقط بالنسبة لهامش الفقرة الأيسر. القيمة الموجبة تحرك السطر الأول إلى اليمين، بينما تبقى السطور المتبقية محاذية لجسم الفقرة.

استخدم [ParagraphFormat.margin_left](https://reference.aspose.com/slides/ar/python-net/aspose.slides/paragraphformat/margin_left/) عندما تحتاج إلى نقل الفقرة بأكملها. استخدم [ParagraphFormat.indent](https://reference.aspose.com/slides/ar/python-net/aspose.slides/paragraphformat/indent/) عندما تحتاج إلى نقل السطر الأول فقط.

المثال أدناه ينشئ عدة فقرات ويطبق قيم `indent` مختلفة لتوضيح تأثير إزاحة السطر الأول على تخطيط الفقرة.

1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/) .
2. الوصول إلى الشريحة المستهدفة.
3. إضافة [AutoShape](https://reference.aspose.com/slides/ar/python-net/aspose.slides/autoshape/) مستطيلة إلى الشريحة.
4. إضافة [TextFrame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframe/) فارغ إلى الشكل وإزالة الفقرة الافتراضية.
5. إنشاء عدة فقرات وتعيين قيم مختلفة للخاصية [indent](https://reference.aspose.com/slides/ar/python-net/aspose.slides/paragraphformat/indent/) لكل منها.
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

![إزاحة السطر الأول للفقرات](first_line_indent.png)

## **تعيين إزاحة معلقة للفقرة**

إزاحة معلقة هي تخطيط للفقرة حيث يبدأ السطر الأول إلى اليسار من باقي السطور. في Aspose.Slides، يمكنك إنشاء هذا التأثير باستخدام الخاصية [ParagraphFormat.indent](https://reference.aspose.com/slides/ar/python-net/aspose.slides/paragraphformat/indent/) . حدد `indent` بقيمة سالبة لتحريك السطر الأول إلى اليسار بالنسبة لجسم الفقرة.

عمليًا، تحدد الخاصية [ParagraphFormat.margin_left](https://reference.aspose.com/slides/ar/python-net/aspose.slides/paragraphformat/margin_left/) موضع الهامش الأيسر لجسم الفقرة، وتحدد الخاصية [ParagraphFormat.indent](https://reference.aspose.com/slides/ar/python-net/aspose.slides/paragraphformat/indent/) موضع السطر الأول بالنسبة لذلك الهامش. لإنشاء إزاحة معلقة، حدد قيمة `margin_left` موجبة وقيمة `indent` سالبة.

هذا التنسيق مفيد للملاحق، المراجع، مدخلات القاموس، وغيرها من الفقرات التي يجب أن تكون الأسطر الملتفة محاذية تحت جسم الفقرة بدلاً من تحت الحرف الأول للسطر الأول.

1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/) .
2. الوصول إلى الشريحة المستهدفة.
3. إضافة [AutoShape](https://reference.aspose.com/slides/ar/python-net/aspose.slides/autoshape/) مستطيلة إلى الشريحة.
4. إضافة [TextFrame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframe/) فارغ إلى الشكل وإزالة الفقرة الافتراضية.
5. إنشاء الفقرات وتعيين قيمة موجبة للخاصية [margin_left](https://reference.aspose.com/slides/ar/python-net/aspose.slides/paragraphformat/margin_left/) لكل فقرة.
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

## **إدارة تنسيق الجزء في نهاية الفقرة**

عندما تحتاج إلى التحكم في نمط "نهاية" الفقرة (التنسيق المطبَّق بعد الجزء النصي الأخير)، استخدم الخاصية `end_paragraph_portion_format`. يطبق المثال أدناه خط Times New Roman أكبر على نهاية الفقرة الثانية.

1. إنشاء أو فتح ملف [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/) .
2. الحصول على الشريحة المستهدفة باستخدام الفهرس.
3. إضافة [AutoShape](https://reference.aspose.com/slides/ar/python-net/aspose.slides/autoshape/) مستطيل إلى الشريحة.
4. استخدام [TextFrame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframe/) الخاص بالشكل وإنشاء فقرتين.
5. إنشاء [PortionFormat](https://reference.aspose.com/slides/ar/python-net/aspose.slides/portionformat/) محدد بخط Times New Roman بحجم 48 نقطة وتطبيقه كتنسيق جزء نهاية الفقرة.
6. تعيينه إلى الخاصية `end_paragraph_portion_format` للفقرة (يطبق على نهاية الفقرة الثانية).
7. حفظ العرض التقديمي المعدل كملف PPTX.

هذا الكود بلغة Python يوضح كيفية تعيين تنسيق الجزء في نهاية الفقرة للفقرة الثانية:

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

1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/) .
2. الوصول إلى الشريحة المستهدفة باستخدام الفهرس الخاص بها.
3. إضافة [AutoShape](https://reference.aspose.com/slides/ar/python-net/aspose.slides/autoshape/) إلى الشريحة.
4. الوصول إلى [TextFrame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframe/) الخاص بـ [AutoShape](https://reference.aspose.com/slides/ar/python-net/aspose.slides/autoshape/) .
5. إزالة الفقرة الافتراضية من [TextFrame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframe/) .
6. قراءة ملف HTML المصدر.
7. إنشاء الفقرة الأولى باستخدام فئة [Paragraph](https://reference.aspose.com/slides/ar/python-net/aspose.slides/paragraph/) .
8. إضافة محتوى HTML إلى مجموعة الفقرات في [TextFrame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframe/) .
9. حفظ العرض التقديمي المعدل.

```python
import aspose.slides as slides

# إنشاء مثال فارغ من فئة Presentation.
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
2. الوصول إلى الشريحة المطلوبة باستخدام الفهرس.
3. تحديد الشكل الذي يحتوي على النص المراد تصديره.
4. الوصول إلى [TextFrame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframe/) الخاص بالشكل.
5. فتح تدفق ملف لكتابة مخرجات HTML.
6. تحديد الفهرس الابتدائي وتصدير الفقرات المطلوبة.

هذا المثال بلغة Python يوضح كيفية تصدير نص الفقرة إلى HTML.

```python
import aspose.slides as slides

# تحميل ملف العرض التقديمي.
with slides.Presentation("exporting_HTML_text.pptx") as presentation:
    # الوصول إلى الشريحة الأولى في العرض التقديمي.
    slide = presentation.slides[0]

    # مؤشر الشكل المستهدف.
    index = 0

    # الوصول إلى الشكل حسب المؤشر.
    shape = slide.shapes[index]

    with open("output.html", "w") as html_stream:
        # كتابة بيانات الفقرات إلى HTML عن طريق توفير فهرس الفقرة الابتدائي وإجمالي عدد الفقرات للتصدير.
        html_stream.write(shape.text_frame.paragraphs.export_to_html(0, shape.text_frame.paragraphs.count, None))
```

## **حفظ الفقرة كصورة**

في هذا القسم، سنستعرض مثالين يوضحان كيفية حفظ فقرة نصية، ممثلة بفئة [Paragraph](https://reference.aspose.com/slides/ar/python-net/aspose.slides/paragraph/) ، كصورة. كلا المثالين يتضمنان الحصول على صورة للشكل الذي يحتوي على الفقرة باستخدام طرق `get_image` من فئة [Shape](https://reference.aspose.com/slides/ar/python-net/aspose.slides/shape/) ، حساب حدود الفقرة داخل الشكل، وتصديرها كصورة bitmap. هذه الأساليب تسمح لك باستخراج أجزاء محددة من النص من عروض PowerPoint وحفظها كصور منفصلة، مما قد يكون مفيدًا لاستخدامها لاحقًا في سيناريوهات متعددة.

لنفترض أن لدينا ملف عرض تقديمي اسمه sample.pptx يحتوي على شريحة واحدة، حيث الشكل الأول هو مربع نص يحتوي على ثلاث فقرات.

![مربع النص يحتوي على ثلاث فقرات](paragraph_to_image_input.png)

**مثال 1**

في هذا المثال، نحصل على الفقرة الثانية كصورة. للقيام بذلك، نستخرج صورة الشكل من الشريحة الأولى للعرض ثم نحسب حدود الفقرة الثانية في إطار النص الخاص بالشكل. تُعاد رسم الفقرة على صورة bitmap جديدة، تُحفظ بصيغة PNG. هذه الطريقة مفيدة عندما تحتاج إلى حفظ فقرة معينة كصورة منفصلة مع الحفاظ على الأبعاد والتنسيق الدقيق للنص.

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

    # حساب الإحداثيات والحجم للصورة الناتجة (الحد الأدنى للحجم - 1×1 بكسل).
    image_left = math.floor(paragraph_rectangle.x)
    image_top = math.floor(paragraph_rectangle.y)
    image_right = image_left + max(1, math.ceil(paragraph_rectangle.width))
    image_bottom = image_top + max(1, math.ceil(paragraph_rectangle.height))

    # قص صورة النقاط للشكل للحصول على صورة الفقرة فقط.
    paragraph_bitmap = shape_bitmap.crop((image_left, image_top, image_right, image_bottom))

    paragraph_bitmap.save("paragraph.png")
```

النتيجة:

![صورة الفقرة](paragraph_to_image_output.png)

**مثال 2**

في هذا المثال، نوسع النهج السابق بإضافة عوامل مقياس إلى صورة الفقرة. يُستخرج الشكل من العرض ويُحفظ كصورة بعامل مقياس `2`. يسمح ذلك بإنتاج مخرج عالي الدقة عند تصدير الفقرة. تُحسب حدود الفقرة مع مراعاة المقياس. يمكن أن يكون المقياس مفيدًا عندما تحتاج إلى صورة أكثر تفصيلاً، على سبيل المثال للاستخدام في مواد مطبوعة عالية الجودة.

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

    # حساب الإحداثيات والحجم للصورة الناتجة (الحد الأدنى للحجم - 1×1 بكسل).
    image_left = math.floor(paragraph_rectangle.x)
    image_top = math.floor(paragraph_rectangle.y)
    image_right = image_left + max(1, math.ceil(paragraph_rectangle.width))
    image_bottom = image_top + max(1, math.ceil(paragraph_rectangle.height))

    # قص صورة النقاط للشكل للحصول على صورة الفقرة فقط.
    paragraph_bitmap = shape_bitmap.crop((image_left, image_top, image_right, image_bottom))

    paragraph_bitmap.save("paragraph.png")
```

## **الأسئلة الشائعة**

**هل يمكنني تعطيل التفاف السطر بالكامل داخل إطار النص؟**

نعم. استخدم إعداد التفاف إطار النص ([wrap_text](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframeformat/wrap_text/)) لتعطيل التفاف السطر بحيث لا تنكسر الأسطر عند حواف الإطار.

**كيف يمكنني الحصول على حدود الفقرة المحددة على الشريحة بدقة؟**

يمكنك استرجاع المستطيل المحدد للفقرة (وحتى للجزء الفردي) لمعرفة موقعها الدقيق وحجمها على الشريحة.

**أين يتم التحكم في محاذاة الفقرة (يسار/يمين/وسط/ضبط)؟**

[Alignment](https://reference.aspose.com/slides/ar/python-net/aspose.slides/paragraphformat/alignment/) هو إعداد على مستوى الفقرة في [ParagraphFormat](https://reference.aspose.com/slides/ar/python-net/aspose.slides/paragraphformat/)؛ يطبق على كامل الفقرة بغض النظر عن تنسيق الأجزاء الفردية.

**هل يمكنني تعيين لغة تدقيق إملائي لجزء فقط من الفقرة (مثل كلمة واحدة)؟**

نعم. تُحدد اللغة على مستوى الجزء ([PortionFormat.language_id](https://reference.aspose.com/slides/ar/python-net/aspose.slides/portionformat/language_id/))، لذا يمكن أن تتعايش لغات متعددة داخل فقرة واحدة.