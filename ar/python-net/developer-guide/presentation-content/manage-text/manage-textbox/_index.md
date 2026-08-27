---
title: إدارة مربعات النص في العروض التقديمية باستخدام Python
linktitle: إدارة مربع النص
type: docs
weight: 20
url: /ar/python-net/manage-textbox/
keywords:
- مربع نص
- إطار نص
- إضافة نص
- تحديث النص
- إنشاء مربع نص
- تحقق من مربع النص
- إضافة عمود نص
- إضافة رابط تشعبي
- PowerPoint
- عرض تقديمي
- Python
- Aspose.Slides
description: "Aspose.Slides for Python عبر .NET يجعل إنشاء وتعديل واستنساخ مربعات النص في ملفات PowerPoint وOpenDocument أمرًا سهلاً، مما يعزز أتمتة العروض التقديمية الخاصة بك."
---
## **المقدمة**

عادةً ما تكون النصوص على الشرائح موجودة في مربعات النص أو الأشكال. لذلك، لإضافة نص إلى شريحة، يجب عليك إضافة مربع نص ثم وضع بعض النص داخل مربع النص. توفر Aspose.Slides for Python الفئة [AutoShape](https://reference.aspose.com/slides/ar/python-net/aspose.slides/autoshape/) التي تتيح لك إضافة شكل يحتوي على نص.

{{% alert title="Info" color="info" %}}
توفر Aspose.Slides أيضًا الفئة [Shape](https://reference.aspose.com/slides/ar/python-net/aspose.slides/shape/). ومع ذلك، لا يمكن لجميع الأشكال احتواء النص.
{{% /alert %}}

{{% alert title="Note" color="warning" %}}
لذلك، عند التعامل مع شكل تريد إضافة نص إليه، قد ترغب في التحقق والتأكد من أنه تم تحويله عبر الفئة [AutoShape](https://reference.aspose.com/slides/ar/python-net/aspose.slides/autoshape/). فقط عندها ستتمكن من العمل مع [TextFrame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframe/)، وهي خاصية ضمن [AutoShape](https://reference.aspose.com/slides/ar/python-net/aspose.slides/autoshape/). راجع قسم [Update Text](/slides/ar/python-net/manage-textbox/#update-text) في هذه الصفحة.
{{% /alert %}}

## **إنشاء مربعات نص على الشرائح**

لإنشاء مربع نص على شريحة:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/).
2. الحصول على مرجع إلى الشريحة الأولى.
3. إضافة [AutoShape](https://reference.aspose.com/slides/ar/python-net/aspose.slides/autoshape/) باستخدام `ShapeType.RECTANGLE` في الموقع المطلوب على الشريحة.
4. تعيين النص في [TextFrame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframe/) الخاص بالشكل.
5. حفظ العرض التقديمي كملف PPTX.

مثال Python التالي يطبق هذه الخطوات:

```py
import aspose.slides as slides

# إنشاء مثيل لفئة Presentation.
with slides.Presentation() as presentation:

    # الحصول على الشريحة الأولى في العرض التقديمي.
    slide = presentation.slides[0]

    # إضافة AutoShape من النوع RECTANGLE.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 150, 50)

    shape.text_frame.text = "Aspose TextBox"

    # حفظ العرض التقديمي على القرص.
    presentation.save("TextBox.pptx", slides.export.SaveFormat.PPTX)
```

## **التحقق مما إذا كان الشكل مربع نص**

توفر Aspose.Slides الخاصية [is_text_box](https://reference.aspose.com/slides/ar/python-net/aspose.slides/autoshape/is_text_box/) في الفئة [AutoShape](https://reference.aspose.com/slides/ar/python-net/aspose.slides/autoshape/)، والتي تسمح لك بتحديد ما إذا كان الشكل مربع نص.

![مربع نص وشكل](istextbox.png)

يوضح مثال Python التالي كيفية التحقق مما إذا كان الشكل قد تم إنشاؤه كمربع نص:

```python
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if isinstance(shape, slides.AutoShape):
                print("shape is a text box" if shape.is_text_box else "shape is not a text box")
```

لاحظ أنه إذا أضفت [AutoShape](https://reference.aspose.com/slides/ar/python-net/aspose.slides/autoshape/) باستخدام الفئة [ShapeCollection](https://reference.aspose.com/slides/ar/python-net/aspose.slides/shapecollection/)، فإن خاصية `is_text_box` للشكل تُرجع `False`. ومع ذلك، بعد إضافة النص—إما باستخدام طريقة `add_text_frame` أو عن طريق تعيين خاصية `text`—تُرجع `is_text_box` القيمة `True`.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 40)
    # shape1.is_text_box هو خطأ
    shape1.add_text_frame("shape 1")
    # shape1.is_text_box هو صحيح

    shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 110, 100, 40)
    # shape2.is_text_box هو خطأ
    shape2.text_frame.text = "shape 2"
    # shape2.is_text_box هو صحيح

    shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 210, 100, 40)
    # shape3.is_text_box هو خطأ
    shape3.add_text_frame("")
    # shape3.is_text_box هو خطأ

    shape4 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 310, 100, 40)
    # shape4.is_text_box هو خطأ
    shape4.text_frame.text = ""
    # shape4.is_text_box هو خطأ
```

## **العثور على الشكل الذي يمتلك إطار النص**

في شفرة معالجة النص العامة، قد تتلقى [TextFrame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframe/) دون معرفة مسبقة أي كائن عرض تقديمي يحتويه. استخدم الخاصية [TextFrame.parent_shape](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframe/parent_shape/) للتنقل مرة أخرى إلى الـ[Shape](https://reference.aspose.com/slides/ar/python-net/aspose.slides/shape/) المالك.

بالنسبة لإطار نص ينتمي إلى [AutoShape](https://reference.aspose.com/slides/ar/python-net/aspose.slides/autoshape/) أو شكل آخر يحتوي على نص، تكون الخاصية [TextFrame.parent_shape](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframe/parent_shape/) مُعينة وتكون الخاصية [TextFrame.parent_cell](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframe/parent_cell/) `None`. كلا الخاصيتين خاصيتان للملاحة للقراءة فقط، لذا فإن قراءتهما لا يغيّر الملكية. دائمًا تحقق من القيمة المرتجعة لتكون ليست `None` قبل الوصول إلى الشكل.

لمثال كامل يحدد مالكي الشكل وخلايا الجدول، بما في ذلك الأشكال المرتبطة بعقد SmartArt، راجع [Search and Replace Text](/slides/ar/python-net/search-and-replace-text/).

## **إضافة أعمدة إلى مربعات النص**

توفر Aspose.Slides الخاصيتين [column_count](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframeformat/column_count/) و[column_spacing](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframeformat/column_spacing/) في الفئة [TextFrameFormat](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframeformat/) لإضافة أعمدة إلى مربعات النص. يمكنك تحديد عدد الأعمدة وضبط المسافة (بالنقاط) بين الأعمدة.

الكود Python التالي يوضح هذه العملية:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:

	# احصل على الشريحة الأولى في العرض التقديمي.
	slide = presentation.slides[0]

	# أضف AutoShape من النوع RECTANGLE.
	shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 300, 300)

	# أضف TextFrame إلى المستطيل.
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

تسمح لك Aspose.Slides بتحديث النص في مربع نص واحد أو عبر العرض التقديمي بأكمله.

مثال Python التالي يوضح كيفية تحديث جميع النصوص في عرض تقديمي:

```py
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if type(shape) is slides.AutoShape:
                for paragraph in shape.text_frame.paragraphs:
                    for portion in paragraph.portions:
                        portion.text = portion.text.replace("years", "months")
                        portion.portion_format.font_bold = slides.NullableBool.TRUE
  
    # احفظ العرض التقديمي المعدل.
    presentation.save("TextChanged.pptx", slides.export.SaveFormat.PPTX)
```

## **إضافة مربعات نص مع روابط تشعبية**

يمكنك إدراج رابط في مربع نص. عند النقر على مربع النص، يفتح الرابط.

لإضافة مربع نص يحتوي على رابط تشعبي، اتبع الخطوات التالية:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/).
2. الحصول على مرجع إلى الشريحة الأولى.
3. إضافة [AutoShape](https://reference.aspose.com/slides/ar/python-net/aspose.slides/autoshape/) باستخدام `ShapeType.RECTANGLE` في الموقع المطلوب على الشريحة.
4. تعيين النص في [TextFrame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframe/) الخاص بالشكل.
5. الحصول على مرجع إلى [HyperlinkManager](https://reference.aspose.com/slides/ar/python-net/aspose.slides/hyperlinkmanager/).
6. استخدام خاصية `hyperlink_manager` لتعيين رابط تشعبي خارجي للنقر.
7. حفظ العرض التقديمي كملف PPTX.

مثال Python التالي يوضح كيفية إضافة مربع نص مع رابط تشعبي إلى شريحة:

```py
import aspose.slides as slides

# إنشاء مثيل لفئة Presentation.
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

**ما الفرق بين مربع النص وعناصر النائب النصي عند العمل مع الشرائح الرئيسية؟**

[placeholder](/slides/ar/python-net/manage-placeholder/) يرث النمط/الموقع من الـ[master](https://reference.aspose.com/slides/ar/python-net/aspose.slides/masterslide/) ويمكن تجاوزها في الـ[layouts](https://reference.aspose.com/slides/ar/python-net/aspose.slides/layoutslide/)، بينما مربع النص العادي هو كائن مستقل على شريحة معينة ولا يتغير عند تغيير التخطيطات.

**كيف يمكنني إجراء استبدال نصي شامل عبر العرض التقديمي دون التأثير على النص داخل المخططات والجداول وSmartArt؟**

قصر التكرار على الأشكال الذاتية التي لديها إطارات نصية واستثنِ الكائنات المدمجة ([charts](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chart/), [tables](https://reference.aspose.com/slides/ar/python-net/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/ar/python-net/aspose.slides.smartart/smartart/)) عبر استعراض مجموعاتها بشكل منفصل أو تخطي تلك الأنواع من الكائنات.