---
title: إدارة صندوق النص
type: docs
weight: 20
url: /ar/python-net/manage-textbox/
keywords: "صندوق نص, إطار نص, إضافة صندوق نص, صندوق نص مع رابط, بايثون, Aspose.Slides لبايثون عبر .NET"
description: "إضافة صندوق نص أو إطار نص إلى عروض PowerPoint في بايثون أو .NET"
---

يوجد النص عادةً على الشرائح في صناديق النص أو الأشكال. لذلك، لإضافة نص إلى شريحة، يجب عليك إضافة صندوق نص ثم إدخال بعض النصوص داخل صندوق النص. يوفر Aspose.Slides لبايثون عبر .NET واجهة [IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/) التي تتيح لك إضافة شكل يحتوي على نص.

{{% alert title="معلومات" color="info" %}}

يوفر Aspose.Slides أيضًا واجهة [IShape](https://reference.aspose.com/slides/python-net/aspose.slides/ishape/) التي تتيح لك إضافة أشكال إلى الشرائح. ولكن، ليس جميع الأشكال المضافة من خلال واجهة `IShape` يمكن أن تحتوي على نص. ولكن الأشكال المضافة من خلال واجهة [IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/) قد تحتوي على نص.

{{% /alert %}}

{{% alert title="ملاحظة" color="warning" %}}

لذلك، عند التعامل مع شكل تريد إضافة نص إليه، قد ترغب في التحقق والتأكد من أنه تم تحويله من خلال واجهة `IAutoShape`. فقط عندها ستكون قادرًا على العمل مع [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/)، وهو خاصية ضمن `IAutoShape`. راجع قسم [تحديث النص](https://docs.aspose.com/slides/python-net/manage-textbox/#update-text) في هذه الصفحة.

{{% /alert %}}

## **إنشاء صندوق نص على الشريحة**

لإنشاء صندوق نص على الشريحة، اتبع هذه الخطوات:

1. قم بإنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. احصل على مرجع لأولى الشرائح في العرض التقديمي الذي تم إنشاؤه حديثًا.
3. أضف كائن [IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/) مع تعيين [ShapeType](https://reference.aspose.com/slides/python-net/aspose.slides/igeometryshape/) كـ `RECTANGLE` في موضع محدد على الشريحة واحصل على مرجع لكائن `IAutoShape` الذي تمت إضافته حديثًا.
4. أضف خاصية `text_frame` إلى كائن `IAutoShape` الذي سيحتوي على نص. في المثال أدناه، أضفنا هذا النص: *Aspose TextBox*
5. أخيرًا، قم بكتابة ملف PPTX من خلال كائن `Presentation`.

يوضح هذا الكود بلغة بايثون—تنفيذ الخطوات أعلاه—كيفية إضافة نص إلى شريحة:

```py
import aspose.slides as slides

# إنشاء عرض تقديمي
with slides.Presentation() as pres:

    # الحصول على أول شريحة في العرض التقديمي
    sld = pres.slides[0]

    # إضافة شكل تلقائي نوعه مستطيل
    ashp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 150, 50)

    # إضافة إطار نص إلى المستطيل
    ashp.add_text_frame(" ")

    # الوصول إلى إطار النص
    txtFrame = ashp.text_frame

    # إنشاء كائن فقرة لإطار النص
    para = txtFrame.paragraphs[0]

    # إنشاء كائن Portion للفقرة
    portion = para.portions[0]

    # تعيين النص
    portion.text = "Aspose TextBox"

    # حفظ العرض التقديمي على القرص
    pres.save("TextBox_out.pptx", slides.export.SaveFormat.PPTX)
```

## **التحقق من شكل صندوق النص**

يوفر Aspose.Slides خاصية `is_text_box` (من فئة [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/)) لتسمح لك بفحص الأشكال والعثور على صناديق النص.

![صندوق نص وشكل](istextbox.png)

يوضح هذا الكود بلغة بايثون كيفية التحقق مما إذا كان الشكل قد تم إنشاؤه كصندوق نص:

```python
from aspose.slides import Presentation, AutoShape

with Presentation("pres.pptx") as pres:
    for slide in pres.slides:
        for shape in slide.shapes:
            if (type(shape) is AutoShape):
                print("الشكل هو صندوق نص" if shape.is_text_box else "الشكل ليس صندوق نص")
```

## **إضافة عمود في صندوق النص**

يوفر Aspose.Slides خاصيتي [column_count](https://reference.aspose.com/slides/python-net/aspose.slides/itextframeformat/) و [column_spacing](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/) (من واجهة [ITextFrameFormat](https://reference.aspose.com/slides/python-net/aspose.slides/itextframeformat/) وفئة [text_frame_format](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/)) التي تسمح لك بإضافة أعمدة إلى صناديق النص. يمكنك تحديد عدد الأعمدة في صندوق نص وتعيين مقدار الفاصل بين الأعمدة بالنقاط.

يوضح هذا الكود بلغة بايثون العملية الموصوفة:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
	# الحصول على أول شريحة في العرض التقديمي
	slide = presentation.slides[0]

	# إضافة شكل تلقائي نوعه مستطيل
	aShape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 300, 300)

	# إضافة إطار نص إلى المستطيل
	aShape.add_text_frame("جميع هذه الأعمدة مقيدة للبقاء ضمن حاوية نص واحدة -- " +
	"يمكنك إضافة أو حذف نص والنص الجديد أو المتبقي يتكيف تلقائيًا " +
	"لتدفقه داخل الحاوية. لا يمكنك جعل النص يتدفق من حاوية إلى أخرى -- " +
	"لقد أخبرناك أن خيارات الأعمدة في PowerPoint محدودة!")

	# الحصول على تنسيق النص لإطار النص
	format = aShape.text_frame.text_frame_format

	# تحديد عدد الأعمدة في إطار النص
	format.column_count = 3

	# تحديد الفاصل بين الأعمدة
	format.column_spacing = 10

	# حفظ العرض التقديمي
	presentation.save("ColumnCount.pptx", slides.export.SaveFormat.PPTX)
```

## **إضافة عمود في إطار النص**

يوفر Aspose.Slides لبايثون عبر .NET خاصية [ColumnCount](https://reference.aspose.com/slides/python-net/aspose.slides/itextframeformat/) (من واجهة [ITextFrameFormat](https://reference.aspose.com/slides/python-net/aspose.slides/itextframeformat/)) التي تتيح لك إضافة أعمدة في إطارات النص. من خلال هذه الخاصية، يمكنك تحديد عدد الأعمدة المفضل لديك في إطار النص.

يوضح هذا الكود بلغة بايثون كيفية إضافة عمود داخل إطار نص:

```py
import aspose.slides as slides

outPptxFileName = "ColumnsTest.pptx"
with slides.Presentation() as pres:
    shape1 = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 300, 300)
    format = shape1.text_frame.text_frame_format

    format.column_count = 2
    shape1.text_frame.text = """جميع هذه الأعمدة ملزمة بالبقاء ضمن حاوية نص واحدة -- 
        يمكنك إضافة أو حذف نص - ويتكيف النص الجديد أو المتبقي 
        ليبقى ضمن الحاوية. لا يمكنك جعل النص يتسرب من حاوية واحدة 
        إلى أخرى، لكن-- لأن خيارات الأعمدة في PowerPoint محدودة!
        pres.save(outPptxFileName, slides.export.SaveFormat.PPTX)"""

    with slides.Presentation(path + outPptxFileName) as test:
        print(test.slides[0].shapes[0].text_frame.text_frame_format.column_count)
        print(test.slides[0].shapes[0].text_frame.text_frame_format.column_spacing)

    format.column_spacing = 20
    pres.save(path + outPptxFileName, slides.export.SaveFormat.PPTX)

    with slides.Presentation(path + outPptxFileName) as test:
        print(test.slides[0].shapes[0].text_frame.text_frame_format.column_count)
        print(test.slides[0].shapes[0].text_frame.text_frame_format.column_spacing)

    format.column_count = 3
    format.column_spacing = 15
    pres.save(path + outPptxFileName, slides.export.SaveFormat.PPTX)

    with slides.Presentation(path + outPptxFileName) as test:
        print(test.slides[0].shapes[0].text_frame.text_frame_format.column_count)
        print(test.slides[0].shapes[0].text_frame.text_frame_format.column_spacing)
```

## **تحديث النص**

يتيح لك Aspose.Slides تغيير أو تحديث النص الموجود في صندوق النص أو جميع النصوص الموجودة في عرض تقديمي.

يوضح هذا الكود بلغة بايثون عملية حيث يتم تحديث أو تغيير جميع النصوص في عرض تقديمي:

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    for slide in pres.slides:
        for shape in slide.shapes:
            if type(shape) is slides.AutoShape:
                for paragraph in shape.text_frame.paragraphs:
                    for portion in paragraph.portions:
                        portion.text = portion.text.replace("سنوات", "أشهر")
                        portion.portion_format.font_bold = 1
  
    # حفظ العرض التقديمي المعدل
    pres.save("text-changed.pptx", slides.export.SaveFormat.PPTX)
```

## **إضافة صندوق نص مع رابط**

يمكنك إدراج رابط داخل صندوق نص. عند النقر على صندوق النص، يتم توجيه المستخدمين لفتح الرابط.

لإضافة صندوق نص يحتوي على رابط، اتبع هذه الخطوات:

1. قم بإنشاء مثيل من فئة `Presentation`.
2. احصل على مرجع لأولى الشرائح في العرض التقديمي الذي تم إنشاؤه حديثًا.
3. أضف كائن `AutoShape` مع تعيين `ShapeType` كـ `RECTANGLE` في موضع محدد على الشريحة واحصل على مرجع لكائن AutoShape الذي تمت إضافته حديثًا.
4. أضف `text_frame` إلى كائن `AutoShape` الذي يحتوي على *Aspose TextBox* كنص افتراضي له.
5. قم بإنشاء مثيل لفئة `hyperlink_manager`.
6. قم بتعيين كائن `hyperlink_manager` إلى خاصية [HyperlinkClick](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) المرتبطة بالنص المفضل لديك في `TextFrame`.
7. أخيرًا، قم بكتابة ملف PPTX من خلال كائن `Presentation`.

يوضح هذا الكود بلغة بايثون—تنفيذ الخطوات أعلاه—كيفية إضافة صندوق نص مع رابط إلى شريحة:

```py
import aspose.slides as slides

# إنشاء عرض تقديمي يمثل PPTX
with slides.Presentation() as pptxPresentation:
    # الحصول على أول شريحة في العرض التقديمي
    slide = pptxPresentation.slides[0]

    # إضافة كائن AutoShape نوعه مستطيل
    pptxShape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 150, 150, 50)

    # الوصول إلى خاصية ITextFrame المرتبطة بـ AutoShape
    pptxShape.add_text_frame("")

    textFrame = pptxShape.text_frame

    # إضافة نص إلى الإطار
    textFrame.paragraphs[0].portions[0].text = "Aspose.Slides"

    # تعيين الرابط للنص portion
    hm = textFrame.paragraphs[0].portions[0].portion_format.hyperlink_manager
    hm.set_external_hyperlink_click("http://www.aspose.com")
    # حفظ العرض التقديمي PPTX
    pptxPresentation.save("hLinkPPTX_out.pptx", slides.export.SaveFormat.PPTX)
```