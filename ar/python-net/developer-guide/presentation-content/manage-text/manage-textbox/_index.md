---
title: إدارة مربعات النص في العروض التقديمية باستخدام بايثون
linktitle: إدارة مربع النص
type: docs
weight: 20
url: /ar/python-net/manage-textbox/
keywords:
- مربع النص
- إطار النص
- إضافة نص
- تحديث النص
- إنشاء مربع نص
- فحص مربع النص
- إضافة عمود نص
- إضافة ارتباط تشعبي
- PowerPoint
- عرض تقديمي
- Python
- Aspose.Slides
description: "تُسهل Aspose.Slides للبايثون عبر .NET إنشاء وتحرير واستنساخ مربعات النص في ملفات PowerPoint وOpenDocument، مما يُحسّن أتمتة العروض التقديمية الخاصة بك."
---

## **نظرة عامة**

عادةً ما تكون النصوص على الشرائح موجودة في مربعات النص أو الأشكال. لذلك، لإضافة نص إلى شريحة، عليك إضافة مربع نص ثم وضع بعض النص داخل مربع النص. توفر Aspose.Slides للبايثون الفئة [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) التي تسمح لك بإضافة شكل يحتوي على نص.

{{% alert title="معلومات" color="info" %}}
توفر Aspose.Slides أيضًا الفئة [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/). ومع ذلك، لا يمكن لجميع الأشكال احتواء نص.
{{% /alert %}}

{{% alert title="ملاحظة" color="warning" %}}
لذلك، عند التعامل مع شكل تريد إضافة نص إليه، قد ترغب في التحقق والتأكد من أنه تم تحويله عبر الفئة [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/). فقط بعد ذلك ستتمكن من العمل مع [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/)، وهي خاصية تحت فئة [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/). راجع قسم [Update Text](/slides/ar/python-net/manage-textbox/#update-text) في هذه الصفحة.
{{% /alert %}}

## **إنشاء مربعات نص على الشرائح**

لإنشاء مربع نص على شريحة:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. الحصول على مرجع إلى الشريحة الأولى.
3. إضافة [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) من النوع `ShapeType.RECTANGLE` في الموضع المطلوب على الشريحة.
4. تعيين النص في [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) الخاص بالشكل.
5. حفظ العرض التقديمي كملف PPTX.

المثال التالي في بايثون يطبق هذه الخطوات:

```py
import aspose.slides as slides

# إنشاء كائن من فئة Presentation.
with slides.Presentation() as presentation:

    # الحصول على الشريحة الأولى في العرض التقديمي.
    slide = presentation.slides[0]

    # إضافة AutoShape من النوع RECTANGLE.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 150, 50)

    shape.text_frame.text = "Aspose TextBox"

    # حفظ العرض التقديمي إلى القرص.
    presentation.save("TextBox.pptx", slides.export.SaveFormat.PPTX)
```

## **التحقق مما إذا كان الشكل مربع نص**

توفر Aspose.Slides الخاصية [is_text_box](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/is_text_box/) على فئة [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/)، والتي تتيح لك تحديد ما إذا كان الشكل مربع نص.

![Text box and shape](istextbox.png)

هذا المثال في بايثون يُظهر كيفية التحقق مما إذا كان الشكل تم إنشاؤه كمربع نص:

```python
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if isinstance(shape, slides.AutoShape):
                print("shape is a text box" if shape.is_text_box else "shape is not a text box")
```

لاحظ أنه إذا أضفت [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) باستخدام فئة [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/)، فستُعيد خاصية `is_text_box` القيمة `False`. ومع ذلك، بعد إضافة نص—إما عبر طريقة `add_text_frame` أو عن طريق تعيين خاصية `text`—ستصبح `is_text_box` `True`.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 40)
    # shape1.is_text_box غير صحيح
    shape1.add_text_frame("shape 1")
    # shape1.is_text_box صحيح

    shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 110, 100, 40)
    # shape2.is_text_box غير صحيح
    shape2.text_frame.text = "shape 2"
    # shape2.is_text_box صحيح

    shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 210, 100, 40)
    # shape3.is_text_box غير صحيح
    shape3.add_text_frame("")
    # shape3.is_text_box غير صحيح

    shape4 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 310, 100, 40)
    # shape4.is_text_box غير صحيح
    shape4.text_frame.text = ""
    # shape4.is_text_box غير صحيح
```

## **إضافة أعمدة إلى مربعات النص**

توفر Aspose.Slides الخاصيتين [column_count](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/column_count/) و [column_spacing](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/column_spacing/) على فئة [TextFrameFormat](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/) لإضافة أعمدة إلى مربعات النص. يمكنك تحديد عدد الأعمدة وضبط التباعد (بنقاط) بين الأعمدة.

الكود التالي في بايثون يوضح هذه العملية:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:

	# الحصول على الشريحة الأولى في العرض التقديمي.
	slide = presentation.slides[0]

	# إضافة AutoShape من النوع RECTANGLE.
	shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 300, 300)

	# إضافة TextFrame إلى المستطيل.
	shape.add_text_frame("All of these columns are confined to a single text container—" +
	"you can add or delete text, and any new or remaining text automatically reflows " +
	"within the container. You cannot have text flow from one container to another, " +
	"though—PowerPoint’s column options for text are limited!")

	# الحصول على تنسيق النص في TextFrame.
	format = shape.text_frame.text_frame_format

	# تحديد عدد الأعمدة في TextFrame.
	format.column_count = 3

	# تحديد التباعد بين الأعمدة.
	format.column_spacing = 10

	# حفظ العرض التقديمي.
	presentation.save("ColumnCount.pptx", slides.export.SaveFormat.PPTX)
```

## **تحديث النص**

تسمح لك Aspose.Slides بتحديث النص في مربع نص واحد أو عبر العرض التقديمي كله.

المثال التالي في بايثون يُظهر كيفية تحديث جميع النصوص في عرض تقديمي:

```py
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if type(shape) is slides.AutoShape:
                for paragraph in shape.text_frame.paragraphs:
                    for portion in paragraph.portions:
                        portion.text = portion.text.replace("years", "months")
                        portion.portion_format.font_bold = 1
  
    # حفظ العرض التقديمي المعدل.
    presentation.save("TextChanged.pptx", slides.export.SaveFormat.PPTX)
```

## **إضافة مربعات نص مع روابط تشعبية**

يمكنك إدراج رابط في مربع نص. عند النقر على مربع النص، يفتح الرابط.

لإضافة مربع نص يحتوي على رابط تشعبي، اتبع الخطوات التالية:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. الحصول على مرجع إلى الشريحة الأولى.
3. إضافة [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) من النوع `ShapeType.RECTANGLE` في الموضع المطلوب على الشريحة.
4. تعيين النص في [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) الخاص بالشكل.
5. الحصول على مرجع إلى [HyperlinkManager](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkmanager/).
6. استخدم خاصية `hyperlink_manager` لتعيين رابط تشعبي خارجي للنقر.
7. حفظ العرض التقديمي كملف PPTX.

المثال التالي في بايثون يُظهر كيفية إضافة مربع نص مع رابط تشعبي إلى شريحة:

```py
import aspose.slides as slides

# إنشاء كائن من فئة Presentation.
with slides.Presentation() as presentation:

    # الحصول على الشريحة الأولى في العرض التقديمي.
    slide = presentation.slides[0]

    # إضافة AutoShape من النوع RECTANGLE.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 150, 150, 50)

    text_portion = shape.text_frame.paragraphs[0].portions[0]

    # إضافة نص إلى الإطار.
    text_portion.text = "Aspose.Slides"

    # تعيين رابط تشعبي لنص الجزء.
    hyperlink_manager = text_portion.portion_format.hyperlink_manager
    hyperlink_manager.set_external_hyperlink_click("http://www.aspose.com")

    # حفظ العرض التقديمي كملف PPTX.
    presentation.save("Hyperlink.pptx", slides.export.SaveFormat.PPTX)
```

## **الأسئلة المتكررة**

**ما الفرق بين مربع النص وعنصر نائب النص عند العمل مع الشرائح الرئيسية؟**

[نائب](/slides/ar/python-net/manage-placeholder/) يرث النمط/الموقع من الـ[الماستر](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/) ويمكن تجاوزه في الـ[التصاميم](https://reference.aspose.com/slides/python-net/aspose.slides/layoutslide/)، بينما مربع النص العادي هو كائن مستقل على شريحة محددة ولا يتغير عند تبديل التصاميم.

**كيف يمكنني إجراء استبدال نص جماعي عبر العرض التقديمي دون تعديل النص داخل المخططات والجداول وSmartArt؟**

قصر التكرار على الأشكال التي تحتوي على إطارات نص واستبعاد الكائنات المدمجة ([المخططات](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/), [الجداول](https://reference.aspose.com/slides/python-net/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/)) من خلال استعراض مجموعاتها بشكل منفصل أو تخطي تلك الأنواع من الكائنات.