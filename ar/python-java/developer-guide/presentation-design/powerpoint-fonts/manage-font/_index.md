---
title: إدارة الخطوط في العروض التقديمية باستخدام Python عبر Java
linktitle: إدارة الخطوط
type: docs
weight: 10
url: /ar/python-java/manage-fonts/
keywords:
- إدارة الخطوط
- خصائص الخط
- فقرة
- تنسيق النص
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Java
- Aspose.Slides
description: "تحكم في الخطوط في Python عبر Java باستخدام Aspose.Slides: دمج، استبدال، وتحميل خطوط مخصصة للحفاظ على عروض PPT و PPTX و ODP واضحة، متوافقة مع العلامة التجارية، ومتسقة."
---
## **نظرة عامة**

تتيح لك Aspose.Slides إدارة خصائص الخط في نص العرض التقديمي مباشرة من الشيفرة الخاصة بك. يمكنك الوصول إلى النص في الشرائح عبر الأشكال، إطارات النص، الفقرات، والأجزاء، ثم تطبيق التنسيق على النص المحدد.

تشرح هذه المقالة كيفية تكوين خصائص الخط للنص الموجود في عرض تقديمي، بما في ذلك عائلة الخط، الأنماط الغامقة والمائلة، محاذاة الفقرة، ولون الخط. كما توضح كيفية إنشاء مربع نص، إضافة نص إليه، وتعيين خصائص الخط مثل عائلة الخط، الغامق، المائل، الخط تحت النص، حجم الخط، واللون قبل حفظ النتيجة كملف PPTX.

## **إدارة الخصائص المتعلقة بالخط**
{{% alert color="info" title="Note" %}} 

عادةً ما يحتوي العرض التقديمي على كل من النصوص والصور. يمكن تنسيق النص بطرق مختلفة، إما لتسليط الضوء على أقسام وكلمات معينة أو للامتثال للأنماط المؤسسية. يساعد تنسيق النص المستخدمين على تنويع مظهر ومضمون العرض التقديمي. توضح هذه المقالة كيفية استخدام Aspose.Slides for Python via Java لتكوين خصائص الخط للفقرات النصية في الشرائح.

{{% /alert %}} 

لإدارة خصائص الخط لفقرة باستخدام Aspose.Slides for Python via Java:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/).
1. الحصول على مرجع الشريحة باستخدام فهرسها.
1. الوصول إلى أشكال [Placeholder](https://reference.aspose.com/slides/ar/python-java/aspose.slides/placeholder/) في الشريحة كـ [AutoShape](https://reference.aspose.com/slides/ar/python-java/aspose.slides/autoshape/).
1. الحصول على الـ [Paragraph](https://reference.aspose.com/slides/ar/python-java/aspose.slides/paragraph/) من الـ [TextFrame](https://reference.aspose.com/slides/ar/python-java/aspose.slides/textframe/) الذي توفره الـ [AutoShape](https://reference.aspose.com/slides/ar/python-java/aspose.slides/autoshape/).
1. توسيط الفقرة.
1. الوصول إلى نص الـ [Paragraph](https://reference.aspose.com/slides/ar/python-java/aspose.slides/paragraph/) عبر الـ [Portion](https://reference.aspose.com/slides/ar/python-java/aspose.slides/portion/).
1. تعريف الخط باستخدام [FontData](https://reference.aspose.com/slides/ar/python-java/aspose.slides/fontdata/) وتعيين **Font** للـ [Portion](https://reference.aspose.com/slides/ar/python-java/aspose.slides/portion/) وفقًا لذلك.
   1. جعل الخط غامقًا.
   1. جعل الخط مائلًا.
1. تعيين لون الخط باستخدام الـ [FillFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/fillformat/) الذي توفره كائن الـ [Portion](https://reference.aspose.com/slides/ar/python-java/aspose.slides/portion/).
1. حفظ العرض التقديمي المعدل كملف PPTX.

التنفيذ للخطوات أعلاه موضح أدناه. يأخذ عرضًا تقديميًا غير مزيّن ويُنسّق الخطوط في إحدى الشرائح. تُظهر اللقطات التي تلي ذلك ملف الإدخال وكيفية تعديل الشيفرة له. تُغيّر الشيفرة الخط، اللون، ونمط الخط.

|![Text in the input presentation](https://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**الشكل: النص في ملف الإدخال**|


|![Text with updated font formatting](https://i.imgur.com/rY27Lt9.png)|
| :- |
|**الشكل: نفس النص مع تنسيق محدث**|

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, NullableBool, Presentation, SaveFormat, TextAlignment
from java.awt import Color

# تحميل العرض التقديمي.
presentation = Presentation("FontProperties.pptx")
try:
    # الوصول إلى الشريحة الأولى وإطارات النص للعنصرين النائبين الأولين.
    slide = presentation.getSlides().get_Item(0)
    title_text_frame = slide.getShapes().get_Item(0).getTextFrame()
    body_text_frame = slide.getShapes().get_Item(1).getTextFrame()

    # الوصول إلى الفقرة الأولى في كل إطار نص.
    title_paragraph = title_text_frame.getParagraphs().get_Item(0)
    body_paragraph = body_text_frame.getParagraphs().get_Item(0)
    body_paragraph.getParagraphFormat().setAlignment(TextAlignment.JustifyLow)

    # الوصول إلى الجزء الأول في كل فقرة.
    title_portion = title_paragraph.getPortions().get_Item(0)
    body_portion = body_paragraph.getPortions().get_Item(0)

    # تعريف وتعيين خطوط جديدة.
    title_font = FontData("Elephant")
    body_font = FontData("Castellar")
    title_portion.getPortionFormat().setLatinFont(title_font)
    body_portion.getPortionFormat().setLatinFont(body_font)

    # ضبط الخطوط لتصبح غامقة ومائلة.
    title_portion.getPortionFormat().setFontBold(NullableBool.True_)
    body_portion.getPortionFormat().setFontBold(NullableBool.True_)
    title_portion.getPortionFormat().setFontItalic(NullableBool.True_)
    body_portion.getPortionFormat().setFontItalic(NullableBool.True_)

    # ضبط ألوان الخط.
    title_portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    title_portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    body_portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    body_portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GREEN)

    # حفظ العرض التقديمي.
    presentation.save("WelcomeFont.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **تعيين خصائص خط النص**
{{% alert color="info" title="Note" %}} 

كما ذُكر في **إدارة الخصائص المتعلقة بالخط**، يُستخدم الـ [Portion](https://reference.aspose.com/slides/ar/python-java/aspose.slides/portion/) لحفظ نص بستايل تنسيق موحد داخل الفقرة. تُظهر هذه المقالة كيفية استخدام Aspose.Slides for Python via Java لإنشاء مربع نص مع بعض النصوص ثم تحديد خط معين وعدة خصائص أخرى للخط.

{{% /alert %}} 

لإنشاء مربع نص وتعيين خصائص الخط للنص داخلها:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/).
1. الحصول على مرجع الشريحة باستخدام فهرسها.
1. إضافة [AutoShape](https://reference.aspose.com/slides/ar/python-java/aspose.slides/autoshape/) من النوع **Rectangle** إلى الشريحة.
1. إزالة نمط التعبئة المرتبط بالـ [AutoShape](https://reference.aspose.com/slides/ar/python-java/aspose.slides/autoshape/).
1. الوصول إلى الـ [TextFrame](https://reference.aspose.com/slides/ar/python-java/aspose.slides/textframe/) الخاص بالـ [AutoShape](https://reference.aspose.com/slides/ar/python-java/aspose.slides/autoshape/).
1. إضافة بعض النص إلى الـ [TextFrame](https://reference.aspose.com/slides/ar/python-java/aspose.slides/textframe/).
1. الوصول إلى كائن الـ [Portion](https://reference.aspose.com/slides/ar/python-java/aspose.slides/portion/) المرتبط بالـ [TextFrame](https://reference.aspose.com/slides/ar/python-java/aspose.slides/textframe/).
1. تعريف الخط الذي سيُستخدم للـ [Portion](https://reference.aspose.com/slides/ar/python-java/aspose.slides/portion/).
1. تعيين خصائص خط أخرى مثل الغامق، المائل، الخط تحت النص، اللون والارتفاع باستخدام الخصائص ذات الصلة التي توفرها كائن الـ [Portion](https://reference.aspose.com/slides/ar/python-java/aspose.slides/portion/).
1. كتابة العرض التقديمي المعدل كملف PPTX.

التنفيذ للخطوات أعلاه موضح أدناه.

|![Text with font properties applied](https://i.imgur.com/n5r12dS.jpg)|
| :- |
|**الشكل: نص مع بعض خصائص الخط التي تم ضبطها بواسطة Aspose.Slides for Python via Java**|

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, NullableBool, Presentation, SaveFormat, ShapeType, TextUnderlineType
from java.awt import Color

presentation = Presentation()
try:
    # احصل على الشريحة الأولى وأضف مستطيلًا.
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 50)

    # احذف تعبئة الشكل.
    shape.getFillFormat().setFillType(FillType.NoFill)

    # أضف نصًا إلى إطار نص الشكل.
    text_frame = shape.getTextFrame()
    text_frame.setText("Aspose TextBox")
    portion = text_frame.getParagraphs().get_Item(0).getPortions().get_Item(0)

    # اضبط عائلة الخط.
    font = FontData("Times New Roman")
    portion.getPortionFormat().setLatinFont(font)

    # اضبط الخط الغامق والمائل وتحت الخط وحجم الخط.
    portion.getPortionFormat().setFontBold(NullableBool.True_)
    portion.getPortionFormat().setFontItalic(NullableBool.True_)
    portion.getPortionFormat().setFontUnderline(TextUnderlineType.Single)
    portion.getPortionFormat().setFontHeight(25)

    # اضبط لون الخط.
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    # احفظ العرض التقديمي.
    presentation.save("pptxFont.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```