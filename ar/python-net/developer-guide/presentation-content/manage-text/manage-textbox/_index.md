---
title: إدارة صناديق النص في العروض التقديمية باستخدام بايثون
linktitle: إدارة صندوق النص
type: docs
weight: 20
url: /ar/python-net/manage-textbox/
keywords:
- صندوق نص
- إطار نص
- إضافة نص
- تحديث النص
- إنشاء صندوق نص
- التحقق من صندوق النص
- إضافة عمود نص
- إضافة رابط تشعبي
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET يجعل من السهل إنشاء وتحرير واستنساخ صناديق النص في ملفات PowerPoint و OpenDocument، مما يعزز أتمتة عروضك التقديمية."
---

## **نظرة عامة**

عادةً ما تكون النصوص على الشرائح موجودة في صناديق نص أو أشكال. لذلك، لإضافة نص إلى شريحة، عليك إضافة صندوق نص ثم وضع بعض النص داخل صندوق النص. توفر Aspose.Slides for Python فئة [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) التي تسمح لك بإضافة شكل يحتوي على نص.

{{% alert title="Info" color="info" %}}
تقدم Aspose.Slides أيضًا فئة [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/). ومع ذلك، لا يمكن لكل الأشكال احتواء نص.
{{% /alert %}}

{{% alert title="Note" color="warning" %}}
لذلك، عند التعامل مع شكل تريد إضافة نص إليه، قد ترغب في التحقق والتأكد من أنه تم تحويله عبر فئة [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/). فقط عندها ستتمكن من العمل مع [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/)، وهي خاصية داخل [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/). راجع قسم [Update Text](/slides/ar/python-net/manage-textbox/#update-text) في هذه الصفحة.
{{% /alert %}}

## **إنشاء صناديق نص على الشرائح**

لإنشاء صندوق نص على شريحة:

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. الحصول على مرجع إلى الشريحة الأولى.
3. إضافة [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) باستخدام `ShapeType.RECTANGLE` في الموضع المطلوب على الشريحة.
4. تعيين النص في [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) الخاص بالشكل.
5. حفظ العرض التقديمي كملف PPTX.

 المثال التالي بلغة Python يطبق هذه الخطوات:
```py
import aspose.slides as slides

# إنشاء كائن من الفئة Presentation.
with slides.Presentation() as presentation:

    # الحصول على الشريحة الأولى في العرض التقديمي.
    slide = presentation.slides[0]

    # إضافة AutoShape من النوع RECTANGLE.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 150, 50)

    shape.text_frame.text = "Aspose TextBox"

    # حفظ العرض التقديمي على القرص.
    presentation.save("TextBox.pptx", slides.export.SaveFormat.PPTX)
```


## **التحقق مما إذا كان الشكل صندوق نص**

توفر Aspose.Slides الخاصية [is_text_box](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/is_text_box/) على فئة [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) التي تسمح لك بتحديد ما إذا كان الشكل صندوق نص.

![صندوق النص والشكل](istextbox.png)

هذا المثال بلغة Python يوضح كيفية التحقق مما إذا كان الشكل قد تم إنشاؤه كصندوق نص:
```python
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if isinstance(shape, slides.AutoShape):
                print("shape is a text box" if shape.is_text_box else "shape is not a text box")
```


لاحظ أنه إذا أضفت [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) باستخدام فئة [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/)، فإن الخاصية `is_text_box` تعيد `False`. ومع ذلك، بعد إضافة النص—إما باستخدام طريقة `add_text_frame` أو عبر تعيين الخاصية `text`—تعود `is_text_box` قيمتها `True`.
```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 40)
    # shape1.is_text_box خاطئ
    shape1.add_text_frame("shape 1")
    # shape1.is_text_box صحيح

    shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 110, 100, 40)
    # shape2.is_text_box خاطئ
    shape2.text_frame.text = "shape 2"
    # shape2.is_text_box صحيح

    shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 210, 100, 40)
    # shape3.is_text_box خاطئ
    shape3.add_text_frame("")
    # shape3.is_text_box خاطئ

    shape4 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 310, 100, 40)
    # shape4.is_text_box خاطئ
    shape4.text_frame.text = ""
    # shape4.is_text_box خاطئ
```


## **إضافة أعمدة إلى صناديق النص**

توفر Aspose.Slides الخاصيتين [column_count](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/column_count/) و[column_spacing](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/column_spacing/) على فئة [TextFrameFormat](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/) لإضافة أعمدة إلى صناديق النص. يمكنك تحديد عدد الأعمدة وتعيين المسافة (بالنقاط) بين الأعمدة.

الكود التالي بلغة Python يوضح هذه العملية:
```py
import aspose.slides as slides

with slides.Presentation() as presentation:

	# احصل على الشريحة الأولى في العرض التقديمي.
	slide = presentation.slides[0]

	# أضف AutoShape من النوع RECTANGLE.
	shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 300, 300)

	# أضف TextFrame إلى المربع.
	shape.add_text_frame("All of these columns are confined to a single text container—" +
	"you can add or delete text, and any new or remaining text automatically reflows " +
	"within the container. You cannot have text flow from one container to another, " +
	"though—PowerPoint’s column options for text are limited!")

	# احصل على تنسيق النص في TextFrame.
	format = shape.text_frame.text_frame_format

	# حدد عدد الأعمدة في TextFrame.
	format.column_count = 3

	# حدد التباعد بين الأعمدة.
	format.column_spacing = 10

	# احفظ العرض التقديمي.
	presentation.save("ColumnCount.pptx", slides.export.SaveFormat.PPTX)
```


## **تحديث النص**

تسمح لك Aspose.Slides بتحديث النص في صندوق نص واحد أو عبر العرض التقديمي بأكمله.

المثال التالي بلغة Python يوضح كيفية تحديث جميع النصوص في عرض تقديمي:
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
  
    # احفظ العرض التقديمي المعدل.
    presentation.save("TextChanged.pptx", slides.export.SaveFormat.PPTX)
```


## **إضافة صناديق نص مع روابط تشعبية**

يمكنك إدراج رابط في صندوق نص. عندما يتم النقر على صندوق النص، يفتح الرابط.

لإضافة صندوق نص يحتوي على رابط تشعبي، اتبع الخطوات التالية:

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. الحصول على مرجع إلى الشريحة الأولى.
3. إضافة [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) باستخدام `ShapeType.RECTANGLE` في الموضع المطلوب على الشريحة.
4. تعيين النص في [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) الخاص بالشكل.
5. الحصول على مرجع إلى [HyperlinkManager](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkmanager/).
6. استخدام خاصية `hyperlink_manager` لتعيين رابط تشعبي خارجي للنقرة.
7. حفظ العرض التقديمي كملف PPTX.

هذا المثال بلغة Python يوضح كيفية إضافة صندوق نص مع رابط تشعبي إلى شريحة:
```py
import aspose.slides as slides

# إنشاء كائن من الفئة Presentation.
with slides.Presentation() as presentation:

    # الحصول على الشريحة الأولى في العرض التقديمي.
    slide = presentation.slides[0]

    # إضافة AutoShape من النوع RECTANGLE.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 150, 150, 50)

    text_portion = shape.text_frame.paragraphs[0].portions[0]

    # إضافة نص إلى الإطار.
    text_portion.text = "Aspose.Slides"

    # تعيين ارتباط تشعبي لنص الجزء.
    hyperlink_manager = text_portion.portion_format.hyperlink_manager
    hyperlink_manager.set_external_hyperlink_click("http://www.aspose.com")

    # حفظ العرض التقديمي كملف PPTX.
    presentation.save("Hyperlink.pptx", slides.export.SaveFormat.PPTX)
```


## **الأسئلة الشائعة**

**ما الفرق بين صندوق النص وعنصر النائب النصي عند العمل مع الشرائح الرئيسية؟**  
يٌورِث [placeholder](/slides/ar/python-net/manage-placeholder/) النمط/الموضع من الـ[master](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/) ويمكن تجاوزه في الـ[layouts](https://reference.aspose.com/slides/python-net/aspose.slides/layoutslide/)، بينما صندوق النص العادي هو كائن مستقل على شريحة محددة ولا يتغير عند تبديل التخطيطات.

**كيف يمكنني إجراء استبدال نصي جماعي عبر العرض التقديمي دون التأثير على النص داخل المخططات والجداول وSmartArt؟**  
قصر التكرار على الأشكال الذاتية التي تحتوي على إطارات نصية واستبعاد الكائنات المدمجة ([charts](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/)، [tables](https://reference.aspose.com/slides/python-net/aspose.slides/table/)، [SmartArt](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/)) عن طريق استعراض مجموعاتهم بصورة منفصلة أو تخطي تلك الأنواع.