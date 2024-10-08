---
title: إدارة فقرة PowerPoint في Python
type: docs
weight: 40
url: /ar/python-net/manage-paragraph/
keywords: "إضافة فقرة PowerPoint، إدارة الفقرات، مسافة الفقرة، خصائص الفقرة، نص HTML، تصدير نص الفقرة، عرض PowerPoint، Python، Aspose.Slides لـ Python عبر .NET"
description: "إنشاء وإدارة فقرة، نص، مسافة، وخصائص في عروض PowerPoint باستخدام Python"
---

توفر Aspose.Slides جميع الواجهات والفئات التي تحتاجها للعمل مع نصوص PowerPoint، والفقرات، والأجزاء في Python.

* توفر Aspose.Slides واجهة [ITextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/itextframe/) التي تتيح لك إضافة كائنات تمثل فقرة. يمكن أن يحتوي كائن `ITextFrame` على فقرة واحدة أو أكثر (كل فقرة يتم إنشاؤها من خلال العودة إلى السطر).
* توفر Aspose.Slides واجهة [IParagraph](https://reference.aspose.com/slides/python-net/aspose.slides/iparagraph/) التي تتيح لك إضافة كائنات تمثل الأجزاء. يمكن أن يحتوي كائن `IParagraph` على جزء واحد أو أكثر (مجموعة من كائنات iPortions).
* توفر Aspose.Slides واجهة [IPortion](https://reference.aspose.com/slides/python-net/aspose.slides/iportion/) التي تتيح لك إضافة كائنات تمثل النصوص وخصائص تنسيقها.

يمكن لكائن `IParagraph` التعامل مع نصوص ذات خصائص تنسيق مختلفة من خلال كائناته الأساسية `IPortion`.

## **إضافة عدة فقرات تحتوي على عدة أجزاء**

توضح هذه الخطوات كيفية إضافة إطار نص يحتوي على 3 فقرات وكل فقرة تحتوي على 3 أجزاء:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. الوصول إلى إشارة الشريحة ذات الصلة من خلال فهرسها.
3. إضافة شكل مستطيل [IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/) إلى الشريحة.
4. الحصول على ITextFrame المرتبط مع [IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/).
5. إنشاء كائنين [IParagraph](https://reference.aspose.com/slides/python-net/aspose.slides/iparagraph/) وإضافتهما إلى مجموعة `IParagraphs` من [ITextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/itextframe/).
6. إنشاء ثلاثة كائنات [IPortion](https://reference.aspose.com/slides/python-net/aspose.slides/iportion/) لكل فقرة جديدة `IParagraph` (كائنان Portion للفقرة الافتراضية) وإضافة كل كائن `IPortion` إلى مجموعة IPortion لكل `IParagraph`.
7. تعيين نص لبعض الأجزاء.
8. تطبيق ميزات التنسيق المفضلة لديك على كل جزء باستخدام خصائص التنسيق المعروضة بواسطة كائن `IPortion`.
9. حفظ العرض المعدل.

هذا الكود بلغة Python هو تنفيذ للخطوات الخاصة بإضافة الفقرات التي تحتوي على الأجزاء:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# إنشاء مثيل لفئة Presentation تمثل ملف PPTX
with slides.Presentation() as pres:
    # الوصول إلى الشريحة الأولى
    slide = pres.slides[0]

    # إضافة شكل AutoShape من نوع Rectangle
    ashp = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 300, 150)

    # الوصول إلى TextFrame من AutoShape
    tf = ashp.text_frame

    # إنشاء فقرات وأجزاء بتنسيقات نصية مختلفة
    para0 = tf.paragraphs[0]
    port01 = slides.Portion()
    port02 = slides.Portion()
    para0.portions.add(port01)
    para0.portions.add(port02)

    para1 = slides.Paragraph()
    tf.paragraphs.add(para1)
    port10 = slides.Portion()
    port11 = slides.Portion()
    port12 = slides.Portion()
    para1.portions.add(port10)
    para1.portions.add(port11)
    para1.portions.add(port12)

    para2 = slides.Paragraph()
    tf.paragraphs.add(para2)
    port20 = slides.Portion()
    port21 = slides.Portion()
    port22 = slides.Portion()
    para2.portions.add(port20)
    para2.portions.add(port21)
    para2.portions.add(port22)

    for i in range(3):
        for j in range(3):
            tf.paragraphs[i].portions[j].text = "Portion0" + str(j)
            if j == 0:
                tf.paragraphs[i].portions[j].portion_format.fill_format.fill_type = slides.FillType.SOLID
                tf.paragraphs[i].portions[j].portion_format.fill_format.solid_fill_color.color = draw.Color.red
                tf.paragraphs[i].portions[j].portion_format.font_bold = 1
                tf.paragraphs[i].portions[j].portion_format.font_height = 15
            elif j == 1:
                tf.paragraphs[i].portions[j].portion_format.fill_format.fill_type = slides.FillType.SOLID
                tf.paragraphs[i].portions[j].portion_format.fill_format.solid_fill_color.color = draw.Color.blue
                tf.paragraphs[i].portions[j].portion_format.font_italic = 1
                tf.paragraphs[i].portions[j].portion_format.font_height = 18

    # كتابة PPTX إلى القرص
    pres.save("multiParaPort_out.pptx", slides.export.SaveFormat.PPTX)
```


## **إدارة رموز الفقرات**

تساعد قوائم الرموز في تنظيم وتقديم المعلومات بسرعة وكفاءة. الفقرات ذات النقاط الرمزية تكون دائمًا أسهل قراءة وفهمًا.

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. الوصول إلى إشارة الشريحة ذات الصلة من خلال فهرسها.
3. إضافة [autoshape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/) إلى الشريحة المحددة.
4. الوصول إلى [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/itextframe/) لـ autoshape.
5. إزالة الفقرة الافتراضية في `TextFrame`.
6. إنشاء مثيل الفقرة الأولى باستخدام فئة [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/).
7. تعيين نوع الرمز `Type` للفقرة إلى `Symbol` وتعيين حرف الرمز.
8. تعيين `Text` للفقرة.
9. تعيين `Indent` للفقرة للرمز.
10. تعيين لون للرمز.
11. تعيين ارتفاع الرمز.
12. إضافة الفقرة الجديدة إلى مجموعة فقرات `TextFrame`.
13. إضافة الفقرة الثانية وتكرار العملية الممنوحة في الخطوات من 7 إلى 13.
14. حفظ العرض.

هذا الكود بلغة Python يوضح كيفية إضافة رمز فقرة:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# إنشاء مثيل عرض تقديمي
with slides.Presentation() as pres:
    # الوصول إلى الشريحة الأولى
    slide = pres.slides[0]

    # إضافة والوصول إلى AutoShape
    aShp = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # الوصول إلى إطار النص من AutoShape الذي تم إنشاؤه
    txtFrm = aShp.text_frame

    # إزالة الفقرة الافتراضية الموجودة
    txtFrm.paragraphs.remove_at(0)

    # إنشاء فقرة
    para = slides.Paragraph()

    # تعيين نمط رمز الفقرة والرمز
    para.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    para.paragraph_format.bullet.char = chr(8226)

    # تعيين نص الفقرة
    para.text = "مرحبًا بكم في Aspose.Slides"

    # تعيين المسافة للرمز
    para.paragraph_format.indent = 25

    # تعيين لون الرمز
    para.paragraph_format.bullet.color.color_type = slides.ColorType.RGB
    para.paragraph_format.bullet.color.color = draw.Color.black
    para.paragraph_format.bullet.is_bullet_hard_color = 1

    # تعيين ارتفاع الرمز
    para.paragraph_format.bullet.height = 100

    # إضافة فقرة إلى إطار النص
    txtFrm.paragraphs.add(para)

    # إنشاء فقرة ثانية
    para2 = slides.Paragraph()

    # تعيين نوع الرموز ونمط الفقرة
    para2.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    para2.paragraph_format.bullet.numbered_bullet_style = slides.NumberedBulletStyle.BULLET_CIRCLE_NUM_WDBLACK_PLAIN

    # إضافة نص إلى الفقرة
    para2.text = "هذا هو الرمز عددي"

    # تعيين المسافة للرمز
    para2.paragraph_format.indent = 25

    para2.paragraph_format.bullet.color.color_type = slides.ColorType.RGB
    para2.paragraph_format.bullet.color.color = draw.Color.black
    para2.paragraph_format.bullet.is_bullet_hard_color = 1

    # تعيين ارتفاع الرمز
    para2.paragraph_format.bullet.height = 100

    # إضافة فقرة إلى إطار النص
    txtFrm.paragraphs.add(para2)

    # كتابة العرض كملف PPTX
    pres.save("bullet_out.pptx", slides.export.SaveFormat.PPTX)
```


## **إدارة رموز الصور**

تساعد قوائم الرموز في تنظيم وتقديم المعلومات بسرعة وكفاءة. الفقرات ذات الصور سهلة القراءة والفهم.

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. الوصول إلى إشارة الشريحة ذات الصلة من خلال فهرسها.
3. إضافة [autoshape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/) إلى الشريحة.
4. الوصول إلى [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/itextframe/) الخاص بـ autoshape.
5. إزالة الفقرة الافتراضية في `TextFrame`.
6. إنشاء مثيل الفقرة الأولى باستخدام فئة [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/).
7. تحميل الصورة في [IPPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ippimage/).
8. تعيين نوع الرمز إلى [Picture](https://reference.aspose.com/slides/python-net/aspose.slides/ippimage/) وتعيين الصورة.
9. تعيين `Text` للفقرة.
10. تعيين `Indent` للفقرة للرمز.
11. تعيين لون للرمز.
12. تعيين ارتفاع للرمز.
13. إضافة الفقرة الجديدة إلى مجموعة فقرات `TextFrame`.
14. إضافة الفقرة الثانية وتكرار العملية بناءً على الخطوات السابقة.
15. حفظ العرض المعدل.

هذا الكود بلغة Python يوضح كيفية إضافة وإدارة رموز الصور:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:

    # الوصول إلى الشريحة الأولى
    slide = presentation.slides[0]

    # إعداد الصورة للرموز
    image = draw.Bitmap(path + "bullets.png")
    ippxImage = presentation.images.add_image(image)

    # إضافة والوصول إلى AutoShape
    autoShape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # الوصول إلى إطار النص من AutoShape الذي تم إنشاؤه
    textFrame = autoShape.text_frame

    # إزالة الفقرة الافتراضية الموجودة
    textFrame.paragraphs.remove_at(0)

    # إنشاء فقرة جديدة
    paragraph = slides.Paragraph()
    paragraph.text = "مرحبًا بكم في Aspose.Slides"

    # تعيين نمط رمز الفقرة والصورة
    paragraph.paragraph_format.bullet.type = slides.BulletType.PICTURE
    paragraph.paragraph_format.bullet.picture.image = ippxImage

    # تعيين ارتفاع الرمز
    paragraph.paragraph_format.bullet.height = 100

    # إضافة فقرة إلى إطار النص
    textFrame.paragraphs.add(paragraph)

    # كتابة العرض كملف PPTX
    presentation.save("ParagraphPictureBulletsPPTX_out.pptx", slides.export.SaveFormat.PPTX)
    # كتابة العرض كملف PPT
    presentation.save("ParagraphPictureBulletsPPT_out.ppt", slides.export.SaveFormat.PPT)
```


## **إدارة النقاط متعددة المستويات**

تساعد قوائم الرموز في تنظيم وتقديم المعلومات بسرعة وكفاءة. النقاط متعددة المستويات سهلة القراءة والفهم.

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. الوصول إلى إشارة الشريحة ذات الصلة من خلال فهرسها.
3. إضافة [autoshape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/) في الشريحة الجديدة.
4. الوصول إلى [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/itextframe/) لـ autoshape.
5. إزالة الفقرة الافتراضية في `TextFrame`.
6. إنشاء مثيل الفقرة الأولى من خلال فئة [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) وتعيين العمق إلى 0.
7. إنشاء مثيل الفقرة الثانية من خلال فئة `Paragraph` وتعيين العمق إلى 1.
8. إنشاء مثيل الفقرة الثالثة من خلال فئة `Paragraph` وتعيين العمق إلى 2.
9. إنشاء مثيل الفقرة الرابعة من خلال فئة `Paragraph` وتعيين العمق إلى 3.
10. إضافة الفقرات الجديدة إلى مجموعة فقرات `TextFrame`.
11. حفظ العرض المعدل.

هذا الكود بلغة Python يوضح كيفية إضافة وإدارة الرموز متعددة المستويات:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# إنشاء مثيل عرض تقديمي
with slides.Presentation() as pres:
    # الوصول إلى الشريحة الأولى
    slide = pres.slides[0]
    
    # إضافة والوصول إلى AutoShape
    aShp = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # الوصول إلى إطار النص من AutoShape الذي تم إنشاؤه
    text = aShp.add_text_frame("")
    
    # مسح الفقرة الافتراضية
    text.paragraphs.clear()

    # إضافة الفقرة الأولى
    para1 = slides.Paragraph()
    para1.text = "المحتوى"
    para1.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    para1.paragraph_format.bullet.char = chr(8226)
    para1.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    para1.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # تعيين مستوى الرمز
    para1.paragraph_format.depth = 0

    # إضافة الفقرة الثانية
    para2 = slides.Paragraph()
    para2.text = "المستوى الثاني"
    para2.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    para2.paragraph_format.bullet.char = '-'
    para2.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    para2.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # تعيين مستوى الرمز
    para2.paragraph_format.depth = 1

    # إضافة الفقرة الثالثة
    para3 = slides.Paragraph()
    para3.text = "المستوى الثالث"
    para3.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    para3.paragraph_format.bullet.char = chr(8226)
    para3.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    para3.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # تعيين مستوى الرمز
    para3.paragraph_format.depth = 2

    # إضافة الفقرة الرابعة
    para4 = slides.Paragraph()
    para4.text = "المستوى الرابع"
    para4.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    para4.paragraph_format.bullet.char = '-'
    para4.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    para4.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # تعيين مستوى الرمز
    para4.paragraph_format.depth = 3

    # إضافة الفقرات إلى المجموعة
    text.paragraphs.add(para1)
    text.paragraphs.add(para2)
    text.paragraphs.add(para3)
    text.paragraphs.add(para4)

    # كتابة العرض كملف PPTX
    pres.save("MultilevelBullet.pptx", slides.export.SaveFormat.PPTX)
```


## **إدارة فقرة مع قائمة مرقمة مخصصة**

توفر واجهة [IBulletFormat](https://reference.aspose.com/slides/python-net/aspose.slides/ibulletformat/#ibulletformat/) خاصية `NumberedBulletStartWith` وأخرى تسمح لك بإدارة الفقرات مع ترقيم أو تنسيق مخصص.

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. الوصول إلى الشريحة التي تحتوي على الفقرة.
3. إضافة [autoshape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/) إلى الشريحة.
4. الوصول إلى [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/itextframe/) الخاص بـ autoshape.
5. إزالة الفقرة الافتراضية في `TextFrame`.
6. إنشاء مثيل الفقرة الأولى عبر فئة [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) وتعيين `NumberedBulletStartWith` إلى 2.
7. إنشاء مثيل الفقرة الثانية عبر فئة `Paragraph` وتعيين `NumberedBulletStartWith` إلى 3.
8. إنشاء مثيل الفقرة الثالثة عبر فئة `Paragraph` وتعيين `NumberedBulletStartWith` إلى 7.
9. إضافة الفقرات الجديدة إلى مجموعة فقرات `TextFrame`.
10. حفظ العرض المعدل.

هذا الكود بلغة Python يوضح لك كيفية إضافة وإدارة الفقرات مع الترقيم أو التنسيق المخصص:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # الوصول إلى إطار النص من AutoShape الذي تم إنشاؤه
    textFrame = shape.text_frame

    # إزالة الفقرة الافتراضية الموجودة
    textFrame.paragraphs.remove_at(0)

    # القائمة الأولى
    paragraph1 = slides.Paragraph()
    paragraph1.text = "bullet 2"
    paragraph1.paragraph_format.depth = 4 
    paragraph1.paragraph_format.bullet.numbered_bullet_start_with = 2
    paragraph1.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    textFrame.paragraphs.add(paragraph1)

    paragraph2 = slides.Paragraph()
    paragraph2.text = "bullet 3"
    paragraph2.paragraph_format.depth = 4
    paragraph2.paragraph_format.bullet.numbered_bullet_start_with = 3 
    paragraph2.paragraph_format.bullet.type = slides.BulletType.NUMBERED  
    textFrame.paragraphs.add(paragraph2)


    paragraph5 = slides.Paragraph()
    paragraph5.text = "bullet 7"
    paragraph5.paragraph_format.depth = 4
    paragraph5.paragraph_format.bullet.numbered_bullet_start_with = 7
    paragraph5.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    textFrame.paragraphs.add(paragraph5)

    presentation.save("SetCustomBulletsNumber-slides.pptx", slides.export.SaveFormat.PPTX)
```


## **تعيين المسافة للفقرة**

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. الوصول إلى إشارة الشريحة ذات الصلة من خلال فهرسها.
1. إضافة شكل مستطيل [autoshape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/) إلى الشريحة.
1. إضافة [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/itextframe/) مع ثلاث فقرات إلى شكل المستطيل.
1. إخفاء خطوط المستطيل.
1. تعيين المسافة لكل [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) من خلال خاصية BulletOffset.
1. كتابة العرض المعدل كملف PPT.

هذا الكود بلغة Python يوضح لك كيفية تعيين مسافة الفقرة:

```python
import aspose.slides as slides

# إنشاء مثيل لفئة Presentation
with slides.Presentation() as pres:

    # الحصول على الشريحة الأولى
    sld = pres.slides[0]

    # إضافة الشكل المستطيل
    rect = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 500, 150)

    # إضافة TextFrame إلى المستطيل
    tf = rect.add_text_frame("هذا هو السطر الأول \rهذا هو السطر الثاني \rهذا هو السطر الثالث")

    # تعيين النص ليتناسب مع الشكل
    tf.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE

    # إخفاء خطوط المستطيل
    rect.line_format.fill_format.fill_type = slides.FillType.SOLID

    # الحصول على أول فقرة في TextFrame وتعيين مسافتها
    para1 = tf.paragraphs[0]
    # تعيين نمط رمز الفقرة والرمز
    para1.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    para1.paragraph_format.bullet.char = chr(8226)
    para1.paragraph_format.alignment = slides.TextAlignment.LEFT

    para1.paragraph_format.depth = 2
    para1.paragraph_format.indent = 30

    # الحصول على الفقرة الثانية في TextFrame وتعيين مسافتها
    para2 = tf.paragraphs[1]
    para2.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    para2.paragraph_format.bullet.char = chr(8226)
    para2.paragraph_format.alignment = slides.TextAlignment.LEFT
    para2.paragraph_format.depth = 2
    para2.paragraph_format.indent = 40

    # الحصول على الفقرة الثالثة في TextFrame وتعيين مسافتها
    para3 = tf.paragraphs[2]
    para3.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    para3.paragraph_format.bullet.char = chr(8226)
    para3.paragraph_format.alignment = slides.TextAlignment.LEFT
    para3.paragraph_format.depth = 2
    para3.paragraph_format.indent = 50

    # كتابة العرض إلى القرص
    pres.save("InOutDent_out.pptx", slides.export.SaveFormat.PPTX)
```

## **تعيين مسافة معلقة للفقرة**

هذا الكود بلغة Python يوضح لك كيفية تعيين مسافة معلقة لفقرة:

```python
import aspose.slides as slides

with slides.Presentation() as pres:
    auto_shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 250, 550, 150)

    para1 = slides.Paragraph()
    para1.text = "مثال"
    para2 = slides.Paragraph()
    para2.text = "تعيين مسافة معلقة للفقرة"
    para3 = slides.Paragraph()
    para3.text = "يوضح لك هذا الكود كيفية تعيين المسافة المعلقة لفقرة: "

    para2.paragraph_format.margin_left = 10
    para3.paragraph_format.margin_left = 20

    paragraphs = auto_shape.text_frame.paragraphs
    paragraphs.add(para1)
    paragraphs.add(para2)
    paragraphs.add(para3)

    pres.save("pres.pptx", slides.export.SaveFormat.PPTX)
```

## **إدارة خصائص نهاية فقرة الفقرة**

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
1. الحصول على الإشارة إلى الشريحة التي تحتوي على الفقرة من خلال موضعها.
1. إضافة شكل مستطيل [autoshape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/) إلى الشريحة.
1. إضافة [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/itextframe/) مع فقرتين إلى المستطيل.
1. تعيين `FontHeight` ونوع الخط للفقرات.
1. تعيين خصائص النهاية للفقرات.
1. كتابة العرض المعدل كملف PPTX.

هذا الكود بلغة Python يوضح لك كيفية تعيين خصائص النهاية للفقرات في PowerPoint:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 200, 250)

    para1 = slides.Paragraph()
    para1.portions.add(slides.Portion("نص عينة"))

    para2 = slides.Paragraph()
    para2.portions.add(slides.Portion("نص عينة 2"))
    endParagraphPortionFormat = slides.PortionFormat()
    endParagraphPortionFormat.font_height = 48
    endParagraphPortionFormat.latin_font = slides.FontData("Times New Roman")
    para2.end_paragraph_portion_format = endParagraphPortionFormat

    shape.text_frame.paragraphs.add(para1)
    shape.text_frame.paragraphs.add(para2)

    pres.save("pres.pptx", slides.export.SaveFormat.PPTX)
```


## **استيراد نص HTML إلى الفقرات**

توفر Aspose.Slides دعمًا معززًا لاستيراد نص HTML إلى الفقرات.

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. الوصول إلى إشارة الشريحة ذات الصلة من خلال فهرسها.
3. إضافة [autoshape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/) إلى الشريحة.
4. إضافة والوصول إلى `autoshape` [ITextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/itextframe/).
5. إزالة الفقرة الافتراضية في `ITextFrame`.
6. قراءة ملف HTML المصدر في TextReader.
7. إنشاء المثيل الأول للفقرة من خلال فئة [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) .
8. إضافة محتوى ملف HTML المقروء إلى مجموعة فقرات TextFrame [ParagraphCollection](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphcollection/).
9. حفظ العرض المعدل.

هذا الكود بلغة Python هو تنفيذ للخطوات الخاصة باستيراد نصوص HTML في الفقرات:

```python
import aspose.slides as slides

# إنشاء مثيل عرض تقديمي فارغ
with slides.Presentation() as pres:
    # الوصول إلى الشريحة الأولى الافتراضية في العرض التقديمي
    slide = pres.slides[0]

    # إضافة شكل AutoShape لاستيعاب محتوى HTML
    ashape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, pres.slide_size.size.width - 20, pres.slide_size.size.height - 10)

    ashape.fill_format.fill_type = slides.FillType.NO_FILL

    # إضافة إطار نص إلى الشكل
    ashape.add_text_frame("")

    # مسح جميع الفقرات في إطار النص المضاف
    ashape.text_frame.paragraphs.clear()

    # تحميل ملف HTML باستخدام قارئ التدفق
    with open(path + "file.html", "rt") as tr:
        # إضافة النص من تدفق HTML إلى إطار النص
        ashape.text_frame.paragraphs.add_from_html(tr.read())

    # حفظ العرض
    pres.save("output_out.pptx", slides.export.SaveFormat.PPTX)
```


## **تصدير نصوص الفقرات إلى HTML**

توفر Aspose.Slides دعمًا معززًا لتصدير النصوص (الموجودة في الفقرات) إلى HTML.

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) وتحميل العرض التقديمي المطلوب.
2. الوصول إلى إشارة الشريحة ذات الصلة من خلال فهرسها.
3. الوصول إلى الشكل الذي يحتوي على النص الذي سيتم تصديره إلى HTML.
4. الوصول إلى [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) الخاص بالشكل.
5. إنشاء مثيل من `StreamWriter` وإضافة ملف HTML الجديد.
6. توفير فهرس بداية إلى StreamWriter وتصدير الفقرات المفضلة لديك.

هذا الكود بلغة Python يوضح لك كيفية تصدير نصوص الفقرات من PowerPoint إلى HTML:

```python
import aspose.slides as slides

# تحميل ملف العرض التقديمي
with slides.Presentation(path + "ExportingHTMLText.pptx") as pres:
    # الوصول إلى الشريحة الأولى الافتراضية في العرض التقديمي
    slide = pres.slides[0]

    # الفهرس المطلوب
    index = 0

    # الوصول إلى الشكل المضاف
    ashape = slide.shapes[index]

    with open("output_out.html", "w") as sw:
        # كتابة بيانات الفقرات إلى HTML من خلال توفير فهرس بداية الفقرة، إجمالي الفقرات التي سيتم نسخها
        sw.write(ashape.text_frame.paragraphs.export_to_html(0, ashape.text_frame.paragraphs.count, None))
```