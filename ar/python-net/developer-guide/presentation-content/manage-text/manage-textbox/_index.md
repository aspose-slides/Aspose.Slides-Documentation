---
title: إدارة صناديق النص في العروض التقديمية باستخدام بايثون
linktitle: إدارة صندوق النص
type: docs
weight: 20
url: /ar/python-net/manage-textbox/
keywords:
- صندوق النص
- إطار النص
- إضافة نص
- تحديث النص
- إنشاء صندوق نص
- التحقق من صندوق النص
- إضافة عمود نص
- إضافة ارتباط تشعبي
- PowerPoint
- عرض تقديمي
- Python
- Aspose.Slides
description: "تتيح لك Aspose.Slides لبايثون عبر .NET إنشاء وتحرير واستنساخ صناديق النص في ملفات PowerPoint وOpenDocument بسهولة، مما يعزز أتمتة عروضك التقديمية."
---

## **نظرة عامة**

عادةً ما تكون النصوص على الشرائح موجودة في صناديق النص أو الأشكال. لذلك، لإضافة نص إلى شريحة، عليك إضافة صندوق نص ثم وضع بعض النص داخل الصندوق. توفر Aspose.Slides لبايثون فئة [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) التي تتيح لك إضافة شكل يحتوي على نص.

{{% alert title="معلومات" color="info" %}}

تقدم Aspose.Slides أيضًا فئة [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/). ومع ذلك، لا يمكن لجميع الأشكال احتواء نص.

{{% /alert %}}

{{% alert title="ملاحظة" color="warning" %}}

لذلك، عند التعامل مع شكل ترغب في إضافة نص إليه، قد ترغب في التحقق والتأكد من أنه تم تحويله عبر فئة [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/). فقط عندها يمكنك العمل مع [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/)، وهو خاصية ضمن [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/). راجع قسم [Update Text](/slides/ar/python-net/manage-textbox/#update-text) في هذه الصفحة.

{{% /alert %}}

## **إنشاء صناديق نص على الشرائح**

لإنشاء صندوق نص على شريحة:

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. الحصول على إشارة إلى الشريحة الأولى.
3. إضافة [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) من النوع `ShapeType.RECTANGLE` في الموضع المطلوب على الشريحة.
4. تعيين النص في [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) الخاص بالشكل.
5. حفظ العرض التقديمي كملف PPTX.

مثال بايثون التالي ينفذ هذه الخطوات:

```py
import aspose.slides as slides

# Instantiate the Presentation class.
with slides.Presentation() as presentation:

    # Get the first slide in the presentation.
    slide = presentation.slides[0]

    # Add an AutoShape of type RECTANGLE.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 150, 50)

    shape.text_frame.text = "Aspose TextBox"

    # Save the presentation to disk.
    presentation.save("TextBox.pptx", slides.export.SaveFormat.PPTX)
```

## **التحقق مما إذا كان الشكل صندوق نص**

توفر Aspose.Slides الخاصية [is_text_box](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/is_text_box/) على فئة [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/)، والتي تتيح لك تحديد ما إذا كان الشكل صندوق نص.

![صندوق نص وشكل](istextbox.png)

هذا المثال بايثون يوضح كيفية التحقق مما إذا كان الشكل تم إنشاؤه كصندوق نص:

```python
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if isinstance(shape, slides.AutoShape):
                print("shape is a text box" if shape.is_text_box else "shape is not a text box")
```

لاحظ أنه إذا قمت بإضافة [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) باستخدام فئة [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/)، فإن خاصية `is_text_box` للشكل تُعيد `False`. ومع ذلك، بعد إضافة النص — إما باستخدام طريقة `add_text_frame` أو عبر تعيين الخاصية `text` — تُعيد `is_text_box` القيمة `True`.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 40)
    # shape1.is_text_box is false
    shape1.add_text_frame("shape 1")
    # shape1.is_text_box is true

    shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 110, 100, 40)
    # shape2.is_text_box is false
    shape2.text_frame.text = "shape 2"
    # shape2.is_text_box is true

    shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 210, 100, 40)
    # shape3.is_text_box is false
    shape3.add_text_frame("")
    # shape3.is_text_box is false

    shape4 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 310, 100, 40)
    # shape4.is_text_box is false
    shape4.text_frame.text = ""
    # shape4.is_text_box is false
```

## **إضافة أعمدة إلى صناديق النص**

توفر Aspose.Slides الخاصيتين [column_count](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/column_count/) و [column_spacing](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/column_spacing/) على فئة [TextFrameFormat](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/) لإضافة أعمدة إلى صناديق النص. يمكنك تحديد عدد الأعمدة وتعيين المسافة (بالنقاط) بين الأعمدة.

الكود التالي بايثون يوضح هذه العملية:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:

	# Get the first slide in the presentation.
	slide = presentation.slides[0]

	# Add an AutoShape of type RECTANGLE.
	shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 300, 300)

	# Add a TextFrame to the rectangle.
	shape.add_text_frame("All of these columns are confined to a single text container—" +
	"you can add or delete text, and any new or remaining text automatically reflows " +
	"within the container. You cannot have text flow from one container to another, " +
	"though—PowerPoint’s column options for text are limited!")

	# Get the text format of the TextFrame.
	format = shape.text_frame.text_frame_format

	# Specify the number of columns in the TextFrame.
	format.column_count = 3

	# Specify the spacing between columns.
	format.column_spacing = 10

	# Save the presentation.
	presentation.save("ColumnCount.pptx", slides.export.SaveFormat.PPTX)
```

## **تحديث النص**

تتيح لك Aspose.Slides تحديث النص في صندوق نص واحد أو عبر كامل العرض التقديمي.

المثال التالي بايثون يوضح كيفية تحديث جميع النصوص في عرض تقديمي:

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
  
    # Save the modified presentation.
    presentation.save("TextChanged.pptx", slides.export.SaveFormat.PPTX)
```

## **إضافة صناديق نص مع ارتباطات تشعبية** 

يمكنك إدراج رابط في صندوق نص. عند النقر على صندوق النص، يفتح الرابط.

لإضافة صندوق نص يحتوي على ارتباط تشعبي، اتبع الخطوات التالية:

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. الحصول على إشارة إلى الشريحة الأولى.
3. إضافة [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) مع `ShapeType.RECTANGLE` في الموضع المطلوب على الشريحة.
4. تعيين النص في [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) الخاص بالشكل.
5. الحصول على إشارة إلى [HyperlinkManager](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkmanager/).
6. استخدام الخاصية `hyperlink_manager` لتعيين ارتباط تشعبي خارجي للنقر.
7. حفظ العرض التقديمي كملف PPTX.

هذا المثال بايثون يوضح كيفية إضافة صندوق نص مع ارتباط تشعبي إلى شريحة:

```py
import aspose.slides as slides

# Instantiate the Presentation class.
with slides.Presentation() as presentation:

    # Get the first slide in the presentation.
    slide = presentation.slides[0]

    # Add an AutoShape of type RECTANGLE.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 150, 150, 50)

    text_portion = shape.text_frame.paragraphs[0].portions[0]

    # Add text to the frame.
    text_portion.text = "Aspose.Slides"

    # Set a hyperlink for the portion text.
    hyperlink_manager = text_portion.portion_format.hyperlink_manager
    hyperlink_manager.set_external_hyperlink_click("http://www.aspose.com")

    # Save the presentation as a PPTX file.
    presentation.save("Hyperlink.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**ما الفرق بين صندوق النص وعنصر نائب نصّي عند العمل مع الشرائح الرئيسية؟**

يُورِث [placeholder](/slides/ar/python-net/manage-placeholder/) النمط/الموقع من الـ [master](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/) ويمكن تجاوزها في الـ [layouts](https://reference.aspose.com/slides/python-net/aspose.slides/layoutslide/)، بينما صندوق النص العادي هو كائن مستقل على شريحة محددة ولا يتغيّر عند تبديل التخطيطات.

**كيف يمكنني إجراء استبدال نصي شامل عبر العرض التقديمي دون التأثير على النص داخل المخططات والجداول وSmartArt؟**

قصر التكرار على الأشكال ذات إطارات النص واستبعاد الكائنات المدمجة ([charts](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/), [tables](https://reference.aspose.com/slides/python-net/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/)) عبر استعراض مجموعاتهم بشكل منفصل أو تخطي تلك الأنواع من الكائنات.