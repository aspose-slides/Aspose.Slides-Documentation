---
title: تنسيق نص PowerPoint باستخدام Python
linktitle: تنسيق النص
type: docs
weight: 50
url: /ar/python-net/text-formatting/
keywords:
- تمييز النص
- تعبير نمطي
- محاذاة الفقرة
- نمط النص
- خلفية النص
- شفافية النص
- تباعد الأحرف
- خصائص الخط
- عائلة الخط
- تدوير النص
- زاوية الدوران
- إطار النص
- تباعد الأسطر
- خاصية الملاءمة التلقائية
- مرساة إطار النص
- تبويب النص
- اللغة الافتراضية
- PowerPoint
- OpenDocument
- العرض التقديمي
- Python
- Aspose.Slides
description: "تعلم كيفية تنسيق وتزيين النص في عروض PowerPoint و OpenDocument باستخدام Aspose.Slides للغة Python عبر .NET. خصّص الخطوط والألوان والمحاذاة والمزيد باستخدام أمثلة شفرة Python قوية."
---

## **تمييز النص**

طريقة `highlight_text` في فئة [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) تسمح لك بتمييز جزء من النص بلون خلفية باستخدام عينة نصية، مشابهة لأداة تلوين النص في PowerPoint 2019.

المقتطف البرمجي التالي يوضح كيفية استخدام هذه الميزة:
```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation("SomePresentation.pptx") as presentation:
    presentation.slides[0].shapes[0].text_frame.highlight_text("title", draw.Color.light_blue)

    opts = slides.TextHighlightingOptions()
    opts.whole_words_only = True
    presentation.slides[0].shapes[0].text_frame.highlight_text("to", draw.Color.violet, opts)

    presentation.save("SomePresentation-out2.pptx", slides.export.SaveFormat.PPTX)
```


## **تمييز النص باستخدام تعبيرات نمطية**

طريقة `highlight_regex` في فئة [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) تتيح لك تمييز جزء من النص بلون خلفية باستخدام تعبير نمطي، مشابهة لأداة تلوين النص في PowerPoint 2019.

المقتطف البرمجي أدناه يوضح كيفية استخدام هذه الميزة:
```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation("SomePresentation.pptx") as presentation:
    options = slides.TextHighlightingOptions()

    presentation.slides[0].shapes[0].text_frame.highlight_regex("\\b[^\s]{5,}\\b", draw.Color.blue, options) 
    presentation.save("SomePresentation-out3.pptx", slides.export.SaveFormat.PPTX)
```


## **تعيين لون خلفية النص**

تسمح لك Aspose.Slides بتحديد لون الخلفية المفضل للنص. يُظهر الكود بايثون أدناه كيفية تعيين لون الخلفية للنص بالكامل:
```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    autoShape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)
    autoShape.text_frame.paragraphs.clear()

    para = slides.Paragraph()

    portion1 = slides.Portion("Black")
    portion1.portion_format.font_bold = 1
    
    portion2 = slides.Portion(" Red ")
    
    portion3 = slides.Portion("Black")
    portion3.portion_format.font_bold = 1
    
    para.portions.add(portion1)
    para.portions.add(portion2)
    para.portions.add(portion3)
    autoShape.text_frame.paragraphs.add(para)
    
    pres.save("text.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("text.pptx") as pres:
    autoShape = pres.slides[0].shapes[0]

    for portion in autoShape.text_frame.paragraphs[0].portions:
        portion.portion_format.highlight_color.color = draw.Color.blue

    pres.save("text-red.pptx", slides.export.SaveFormat.PPTX)
```


هذا الكود بايثون يوضح كيفية تعيين لون الخلفية لجزء من النص فقط:
```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    autoShape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)
    autoShape.text_frame.paragraphs.clear()

    para = slides.Paragraph()

    portion1 = slides.Portion("Black")
    portion1.portion_format.font_bold = 1
    
    portion2 = slides.Portion(" Red ")
    
    portion3 = slides.Portion("Black")
    portion3.portion_format.font_bold = 1
    
    para.portions.add(portion1)
    para.portions.add(portion2)
    para.portions.add(portion3)
    autoShape.text_frame.paragraphs.add(para)
    
    pres.save("text.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("text.pptx") as pres:
    autoShape = pres.slides[0].shapes[0]

    for portion in autoShape.text_frame.paragraphs[0].portions:
        print (portion.text)

    redPortion = list(p for p in autoShape.text_frame.paragraphs[0].portions if 'Red' in p.text)[0]
    redPortion.portion_format.highlight_color.color = draw.Color.blue

    pres.save("text-red.pptx", slides.export.SaveFormat.PPTX)
```


## **محاذاة فقرات النص**

تنسيق النص عنصر أساسي عند إنشاء المستندات أو العروض التقديمية. يدعم Aspose.Slides for Python via .NET إضافة النص إلى الشرائح؛ في هذا القسم سنستعرض كيفية التحكم في محاذاة الفقرات داخل شريحة. اتبع الخطوات التالية لمحاذاة فقرات النص باستخدام Aspose.Slides for Python via .NET:

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. الحصول على مرجع إلى شريحة بواسطة فهرستها.
1. الوصول إلى الأشكال النائبة في الشريحة وتحويلها إلى [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/).
1. من خلال الـ [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) الذي يُعرض عبر الـ [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/)، الحصول على الفقرة التي تحتاج إلى محاذاة.
1. محاذاة الفقرة. يمكن محاذاة الفقرة إلى `LEFT` أو `RIGHT` أو `CENTER` أو `JUSTIFY` أو `JUSTIFY_LOW` أو `DISTRIBUTED`.
1. حفظ العرض المعدل كملف PPTX.

التنفيذ العملي لهذه الخطوات موضح أدناه.
```py
import aspose.slides as slides

# إنشاء كائن Presentation يمثل ملف PPTX
with slides.Presentation("ParagraphsAlignment.pptx") as presentation:
    # الوصول إلى الشريحة الأولى
    slide = presentation.slides[0]

    # الوصول إلى العنصر النائب الأول والثاني في الشريحة وتحويله إلى AutoShape
    tf1 = slide.shapes[0].text_frame
    tf2 = slide.shapes[1].text_frame

    # تغيير النص في العنصريّن النائبين
    tf1.text = "Center Align by Aspose"
    tf2.text = "Center Align by Aspose"

    # الحصول على الفقرة الأولى من العناصر النائبة
    para1 = tf1.paragraphs[0]
    para2 = tf2.paragraphs[0]

    # محاذاة فقرة النص إلى الوسط
    para1.paragraph_format.alignment = slides.TextAlignment.CENTER
    para2.paragraph_format.alignment = slides.TextAlignment.CENTER

    # كتابة العرض التقديمي كملف PPTX
    presentation.save("Centeralign_out.pptx", slides.export.SaveFormat.PPTX)
```


## **تعيين شفافية النص**

يوضح هذا القسم كيفية تعيين خاصية الشفافية لأي شكل نص باستخدام Aspose.Slides for Python via .NET. لتعيين شفافية النص، اتبع الخطوات التالية:

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. الحصول على مرجع إلى شريحة.
1. تعيين لون الظل.
1. حفظ العرض كملف PPTX.

التنفيذ العملي لهذه الخطوات موضح أدناه.
```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation("transparency.pptx") as pres:
    shape = pres.slides[0].shapes[0]
    effects = shape.text_frame.paragraphs[0].portions[0].portion_format.effect_format

    outerShadowEffect = effects.outer_shadow_effect

    shadowColor = outerShadowEffect.shadow_color.color
    print("{color} - transparency is: {value}".format(color = shadowColor, value = (shadowColor.a / 255) * 100))
    # تعيين الشفافية إلى صفر بالمائة
    outerShadowEffect.shadow_color.color = draw.Color.from_argb(255, shadowColor)

    pres.save("transparency-2.pptx", slides.export.SaveFormat.PPTX)
```


## **تعيين تباعد الأحرف للنص**

تتيح لك Aspose.Slides تعديل التباعد بين الأحرف داخل مربع نص. يتيح ذلك التحكم في كثافة السطر أو الفقرة بتوسيع أو تقليص المسافة بين الأحرف.

المثال بايثون أدناه يوضح كيفية توسيع التباعد لسطر نص واحد وتقليصه لسطر آخر:
```python
import aspose.slides as slides

with slides.Presentation("in.pptx") as pres:

    textBox1 = pres.slides[0].shapes[0]
    textBox2 = pres.slides[0].shapes[1]

    textBox1.text_frame.paragraphs[0].paragraph_format.default_portion_format.spacing = 20 # توسيع
    textBox2.text_frame.paragraphs[0].paragraph_format.default_portion_format.spacing = -2 # تكثيف

    pres.save("out.pptx", slides.export.SaveFormat.PPTX)
```


## **إدارة خصائص خط الفقرة**

عادةً ما تحتوي العروض التقديمية على نصوص وصور. يمكن تنسيق النص بطرق مختلفة—إما لتمييز أقسام وكلمات محددة أو للامتثال للأنماط المؤسسية. يساعد تنسيق النص المستخدمين على تعديل مظهر المحتوى.

يوضح هذا القسم كيفية استخدام Aspose.Slides for Python via .NET لتكوين خصائص الخط للفقرات داخل نص الشريحة. لإدارة خصائص خط الفقرة باستخدام Aspose.Slides for Python via .NET:

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. الحصول على مرجع إلى شريحة باستخدام فهرستها.
1. الوصول إلى الأشكال النائبة في الشريحة وتحويلها إلى [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/).
1. الحصول على الفقرة من الـ [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) الذي يُعرض عبر الـ [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/).
1. موازنة الفقرة.
1. الوصول إلى جزء النص للفقرة.
1. تعريف الخط باستخدام [FontData](https://reference.aspose.com/slides/python-net/aspose.slides/fontdata/) وتعيين الخط للجزء وفقًا لذلك.
   1. تعيين الخط إلى غامق.
   1. تعيين الخط إلى مائل.
1. تعيين لون الخط باستخدام [FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/) الذي يُعرض عبر كائن [Portion](https://reference.aspose.com/slides/python-net/aspose.slides/portion/).
1. حفظ العرض المعدل كملف PPTX.

التنفيذ العملي للخطوات أعلاه موضح أدناه. يطبق تنسيق الخط على أحد الشرائح في عرض بسيط.
```py
import aspose.slides as slides
import aspose.pydrawing as draw

# إنشاء كائن Presentation يمثل ملف PPTX
with slides.Presentation("FontProperties.pptx") as pres:
    # الوصول إلى شريحة باستخدام موقعها
    slide = pres.slides[0]

    # الوصول إلى العنصر النائب الأول والثاني في الشريحة وتحويله إلى AutoShape
    tf1 = slide.shapes[0].text_frame
    tf2 = slide.shapes[1].text_frame

    # الوصول إلى الفقرة الأولى
    para1 = tf1.paragraphs[0]
    para2 = tf2.paragraphs[0]

    # الوصول إلى الجزء الأول
    port1 = para1.portions[0]
    port2 = para2.portions[0]

    # تعريف خطوط جديدة
    fd1 = slides.FontData("Elephant")
    fd2 = slides.FontData("Castellar")

    # تعيين خطوط جديدة إلى الجزء
    port1.portion_format.latin_font = fd1
    port2.portion_format.latin_font = fd2

    # تعيين الخط إلى غامق
    port1.portion_format.font_bold = 1
    port2.portion_format.font_bold = 1

    # تعيين الخط إلى مائل
    port1.portion_format.font_italic = 1
    port2.portion_format.font_italic = 1

    # تعيين لون الخط
    port1.portion_format.fill_format.fill_type = slides.FillType.SOLID
    port1.portion_format.fill_format.solid_fill_color.color = draw.Color.purple
    port2.portion_format.fill_format.fill_type = slides.FillType.SOLID
    port2.portion_format.fill_format.solid_fill_color.color = draw.Color.peru

    #اكتب ملف PPTX إلى القرص
    pres.save("WelcomeFont_out.pptx", slides.export.SaveFormat.PPTX)
```


## **إدارة عائلة الخط للنص**

تُستخدم كائنات [Portion](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) لحفظ النص ذو نمط تنسيق موحد داخل الفقرة. يوضح هذا القسم كيفية استخدام Aspose.Slides for Python لإنشاء مربع نص، إضافة نص إليه، ثم تعريف خط محدد مع خصائص عائلة الخط المختلفة.

لإنشاء مربع نص وتعيين خصائص الخط للنص داخله:

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. الحصول على مرجع إلى شريحة بواسطة فهرستها.
1. إضافة [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) من النوع `RECTANGLE` إلى الشريحة.
1. إزالة نمط الملء المرتبط بالـ [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/).
1. الوصول إلى الـ [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) الخاص بالـ AutoShape.
1. إضافة نص إلى الـ [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/).
1. الوصول إلى كائن [Portion](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) المرتبط بالـ [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/).
1. تعريف الخط الذي سيُستخدم للـ [Portion](https://reference.aspose.com/slides/python-net/aspose.slides/portion/).
1. تعيين خصائص الخط الأخرى مثل الغامق، المائل، التحريض، اللون والارتفاع باستخدام الخصائص المتاحة في كائن [Portion](https://reference.aspose.com/slides/python-net/aspose.slides/portion/).
1. حفظ العرض المعدل كملف PPTX.

التنفيذ العملي للخطوات أعلاه موضح أدناه.
```py
import aspose.slides as slides
import aspose.pydrawing as draw

# إنشاء كائن Presentation
with slides.Presentation() as presentation:
    # الحصول على الشريحة الأولى
    sld = presentation.slides[0]

    # إضافة AutoShape من نوع Rectangle
    ashp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 50)

    # إزالة أي نمط تعبئة مرتبط بـ AutoShape
    ashp.fill_format.fill_type = slides.FillType.NO_FILL

    # الوصول إلى TextFrame المرتبط بـ AutoShape
    tf = ashp.text_frame
    tf.text = "Aspose TextBox"

    # الوصول إلى Portion المرتبط بـ TextFrame
    port = tf.paragraphs[0].portions[0]

    # ضبط الخط للجزء
    port.portion_format.latin_font = slides.FontData("Times New Roman")

    # ضبط خاصية الغامق للخط
    port.portion_format.font_bold = 1

    # ضبط خاصية المائل للخط
    port.portion_format.font_italic = 1

    # ضبط خاصية التسطير للخط
    port.portion_format.font_underline = slides.TextUnderlineType.SINGLE

    # ضبط ارتفاع الخط
    port.portion_format.font_height = 25

    # ضبط لون الخط
    port.portion_format.fill_format.fill_type = slides.FillType.SOLID
    port.portion_format.fill_format.solid_fill_color.color = draw.Color.blue

    # كتابة ملف PPTX إلى القرص 
    presentation.save("SetTextFontProperties_out.pptx", slides.export.SaveFormat.PPTX)
```


## **تعيين حجم الخط للنص**

تتيح لك Aspose.Slides تعيين حجم الخط المفضل للنص الموجود بالفعل في الفقرة، وكذلك لأي نص قد يُضاف إلى الفقرة لاحقًا.

المثال بايثون أدناه يوضح كيفية تعيين حجم الخط للنص داخل الفقرة:
```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:

    # يحصل على الشكل الأول، على سبيل المثال.
    shape = presentation.slides[0].shapes[0]

    if type(shape) is slides.AutoShape:
        # يحصل على الفقرة الأولى، على سبيل المثال.
        paragraph = shape.text_frame.paragraphs[0]

        # يحدد حجم الخط الافتراضي إلى 20 نقطة لجميع أجزاء النص في الفقرة.
        paragraph.paragraph_format.default_portion_format.font_height = 20

        # يحدد حجم الخط إلى 20 نقطة لأجزاء النص الحالية في الفقرة.
        for portion in paragraph.portions:
            portion.portion_format.font_height = 20

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)

```


## **تعيين دوران النص**

يُتيح Aspose.Slides for Python via .NET للمطورين تدوير النص. يمكن تعيين النص ليظهر كـ `HORIZONTAL` أو `VERTICAL` أو `VERTICAL270` أو `WORD_ART_VERTICAL` أو `EAST_ASIAN_VERTICAL` أو `MONGOLIAN_VERTICAL` أو `WORD_ART_VERTICAL_RIGHT_TO_LEFT`.

لتدوير النص في أي [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/)، اتبع الخطوات التالية:

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. الوصول إلى الشريحة الأولى.
1. إضافة شكل إلى الشريحة.
1. الوصول إلى الـ [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/).
1. تطبيق دوران النص المطلوب.
1. حفظ الملف على القرص.
```py
import aspose.slides as slides
import aspose.pydrawing as draw

# إنشاء مثيل من فئة Presentation
with slides.Presentation() as presentation:
    # الحصول على الشريحة الأولى 
    slide = presentation.slides[0]

    # إضافة AutoShape من نوع Rectangle
    ashp = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 350, 350)

    # إضافة TextFrame إلى المستطيل
    ashp.add_text_frame(" ")
    ashp.fill_format.fill_type = slides.FillType.NO_FILL

    # الوصول إلى TextFrame
    txtFrame = ashp.text_frame
    txtFrame.text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL270

    # إنشاء كائن Paragraph لإطار النص
    para = txtFrame.paragraphs[0]

    # إنشاء كائن Portion للفقرة
    portion = para.portions[0]
    portion.text = "A quick brown fox jumps over the lazy dog. A quick brown fox jumps over the lazy dog."
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black

    # حفظ العرض التقديمي
    presentation.save("RotateText_out.pptx", slides.export.SaveFormat.PPTX)
```


## **تعيين زاوية دوران مخصصة لـ TextFrame**

يدعم Aspose.Slides for Python via .NET تعيين زاوية دوران مخصصة لـ [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/). في هذا القسم سنوضح كيفية استخدام خاصية `rotation_angle` في Aspose.Slides.

لتعيين خاصية `rotation_angle`، اتبع الخطوات التالية:

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. إضافة مخطط إلى الشريحة.
1. تعيين خاصية `rotation_angle`.
1. حفظ العرض كملف PPTX.

في المثال أدناه، قمنا بتعيين خاصية `rotation_angle`.
```py
import aspose.slides as slides

# إنشاء مثيل من فئة Presentation
with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(slides.charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 300)

    series = chart.chart_data.series[0]

    series.labels.default_data_label_format.show_value = True
    series.labels.default_data_label_format.text_format.text_block_format.rotation_angle = 65

    chart.has_title = True
    chart.chart_title.add_text_frame_for_overriding("Custom title").text_frame_format.rotation_angle = -30

    # حفظ العرض التقديمي
    presentation.save("textframe-rotation_out.pptx", slides.export.SaveFormat.PPTX)
```


## **تعيين تباعد الأسطر للفقرات**

توفر Aspose.Slides خصائص `space_after` و `space_before` و `space_within` ضمن فئة [ParagraphFormat](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/) للتحكم بتباعد الأسطر للفقرة. تعمل هذه الخصائص كما يلي:

* لتحديد تباعد الأسطر كنسبة مئوية، استخدم قيمة موجبة.
* لتحديد تباعد الأسطر بالنقاط، استخدم قيمة سالبة.

على سبيل المثال، لتطبيق تباعد 16 نقطة قبل الفقرة، عيّن خاصية `space_before` إلى `-16`.

إليك كيفية تعيين تباعد الأسطر لفقرة محددة:

1. تحميل عرض يحتوي على [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) به نص.
1. الحصول على مرجع إلى الشريحة بواسطة فهرستها.
1. الوصول إلى الـ [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/).
1. الوصول إلى الـ [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/).
1. تعيين خصائص الفقرة المطلوبة.
1. حفظ العرض.

المثال بايثون التالي يوضح كيفية تعيين تباعد الأسطر لفقرة:
```py
import aspose.slides as slides

# إنشاء مثال من فئة Presentation
with slides.Presentation("Fonts.pptx") as presentation:

    # الحصول على مرجع الشريحة بواسطة فهرستها
    sld = presentation.slides[0]

    # الوصول إلى TextFrame
    tf1 = sld.shapes[0].text_frame

    # الوصول إلى الفقرة
    para1 = tf1.paragraphs[0]

    # ضبط خصائص الفقرة
    para1.paragraph_format.space_within = 80
    para1.paragraph_format.space_before = 40
    para1.paragraph_format.space_after = 40
    # حفظ العرض التقديمي
    presentation.save("LineSpacing_out.pptx", slides.export.SaveFormat.PPTX)
```


## **تعيين خاصية AutofitType لـ TextFrame**

في هذا القسم نستكشف خصائص تنسيق مختلفة لـ [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/)، بما في ذلك تعيين `autofit_type`، تعديل مرساة النص، وتدوير النص في العرض.

يتيح Aspose.Slides for Python via .NET للمطورين تعيين خاصية `autofit_type` لأي [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/). يمكن تعيين `autofit_type` إلى `NORMAL` أو `SHAPE`:

* إذا تم تعيينه إلى `NORMAL`، يبقى الشكل ثابتًا بينما يُضبط النص ليتناسب داخله.
* إذا تم تعيينه إلى `SHAPE`، يُعاد تحجيم الشكل ليتسع فقط للنص المطلوب.

لتعيين خاصية `autofit_type` لـ [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/)، اتبع الخطوات التالية:

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. الوصول إلى الشريحة الأولى.
1. إضافة شكل إلى الشريحة.
1. الوصول إلى الـ [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/).
1. تعيين `autofit_type` للـ [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/).
1. حفظ الملف على القرص.
```py
import aspose.slides as slides
import aspose.pydrawing as draw

# إنشاء مثيل من فئة Presentation
with slides.Presentation() as presentation:

    # الوصول إلى الشريحة الأولى 
    slide = presentation.slides[0]

    # إضافة AutoShape من نوع Rectangle
    ashp = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 350, 350)

    # إضافة TextFrame إلى المستطيل
    ashp.add_text_frame(" ")
    ashp.fill_format.fill_type = slides.FillType.NO_FILL

    # الوصول إلى TextFrame
    txtFrame = ashp.text_frame
    txtFrame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE

    # إنشاء كائن Paragraph لإطار النص
    para = txtFrame.paragraphs[0]

    # إنشاء كائن Portion للفقرة
    portion = para.portions[0]
    portion.text = "A quick brown fox jumps over the lazy dog. A quick brown fox jumps over the lazy dog."
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black

    # حفظ العرض التقديمي
    presentation.save("formatText_out.pptx", slides.export.SaveFormat.PPTX) 
```


## **تعيين مرساة TextFrame**

يتيح Aspose.Slides for Python via .NET للمطورين تعيين موقع مرساة أي [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/). تحدد خاصية [TextAnchorType](https://reference.aspose.com/slides/python-net/aspose.slides/textanchortype/) مكان وضع النص داخل الشكل. يمكن تعيينها إلى `TOP` أو `CENTER` أو `BOTTOM` أو `JUSTIFIED` أو `DISTRIBUTED`.

لتعيين مرساة [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/)، اتبع الخطوات التالية:

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. الوصول إلى الشريحة الأولى.
1. إضافة شكل إلى الشريحة.
1. الوصول إلى الـ [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/).
1. تعيين [TextAnchorType](https://reference.aspose.com/slides/python-net/aspose.slides/textanchortype/) للـ [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/).
1. حفظ الملف على القرص.
```py
import aspose.slides as slides
import aspose.pydrawing as draw

# إنشاء مثيل من فئة Presentation
with slides.Presentation() as presentation:
    # الحصول على الشريحة الأولى 
    slide = presentation.slides[0]

    # إضافة AutoShape من نوع Rectangle
    ashp = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 350, 350)

    # إضافة TextFrame إلى المستطيل
    ashp.add_text_frame(" ")
    ashp.fill_format.fill_type = slides.FillType.NO_FILL

    # الوصول إلى TextFrame
    txtFrame = ashp.text_frame
    txtFrame.text_frame_format.anchoring_type = slides.TextAnchorType.BOTTOM

    # إنشاء كائن Paragraph لإطار النص
    para = txtFrame.paragraphs[0]

    # إنشاء كائن Portion للفقرة
    portion = para.portions[0]
    portion.text = "A quick brown fox jumps over the lazy dog. A quick brown fox jumps over the lazy dog."
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black

    # حفظ العرض التقديمي
    presentation.save("AnchorText_out.pptx", slides.export.SaveFormat.PPTX)
```


## **تعيين النمط النصي الافتراضي**

إذا رغبت في تطبيق نفس تنسيق النص الافتراضي على جميع عناصر النص في عرض، يمكنك استخدام خاصية `default_text_style` في فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) وتعيين التنسيق المطلوب.

المثال أدناه يوضح كيفية تعيين الخط الافتراضي إلى غامق، بحجم 14 نقطة، لجميع النصوص عبر كل الشرائح في عرض جديد.
```py
with slides.Presentation() as presentation:
    # الحصول على تنسيق الفقرة المستوى الأعلى.
    paragraphFormat = presentation.default_text_style.get_level(0)

    if paragraphFormat is not None:
        paragraphFormat.default_portion_format.font_height = 14
        paragraphFormat.default_portion_format.font_bold = slides.NullableBool.TRUE

    presentation.save("DefaultTextStyle.pptx", slides.export.SaveFormat.PPTX)
```


## **استخراج النص مع تأثير الأحرف الكبيرة بالكامل**

في PowerPoint، يؤدي تطبيق تأثير الخط **All Caps** إلى ظهور النص بأحرف كبيرة على الشريحة حتى وإن كُتب أصلاً بأحرف صغيرة. عند استرجاع مثل هذا الجزء من النص باستخدام Aspose.Slides، تُعيد المكتبة النص كما تم إدخاله. لمعالجة ذلك، تحقق من [TextCapType](https://reference.aspose.com/slides/python-net/aspose.slides/textcaptype/)—إذا أظهر `ALL`، حوّل السلسلة المسترجعة إلى أحرف كبيرة بحيث يطابق الناتج ما يراه المستخدمون على الشريحة.

لنفترض أن لدينا مربع نص التالي على الشريحة الأولى من الملف sample2.pptx.

![The All Caps effect](all_caps_effect.png)

الكود المثال أدناه يوضح كيفية استخراج النص مع تطبيق تأثير **All Caps**:
```py
with slides.Presentation("sample2.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    text_portion = auto_shape.text_frame.paragraphs[0].portions[0]

    print("Original text:", text_portion.text)

    text_format = text_portion.portion_format.get_effective()
    if text_format.text_cap_type == slides.TextCapType.ALL:
        text = text_portion.text.upper()
        print("All-Caps effect:", text)
```


الناتج:
```text
النص الأصلي: Hello, Aspose!
تأثير الأحرف الكبيرة: HELLO, ASPOSE!
```


{{% alert color="primary" %}}

Aspose توفر خدمة تحرير PowerPoint مجانية عبر الإنترنت [free online PowerPoint editing service](https://products.aspose.app/slides/editor).

{{% /alert %}}

## **FAQ**

**هل يمكنني تطبيق تنسيق مختلف لأجزاء معينة من النص داخل فقرة واحدة (مثل جعل كلمتين فقط غامقتين)، وكيف يتفاعل ذلك مع الأنماط الموروثة من التخطيطات والسمات؟**

نعم. يتم تعيين التنسيق على مستوى “جزء النص” داخل الفقرة ويتجاوز نمط السمات/التخطيط لتلك القطع المختارة فقط. عندما يتغير النمط، يتم تحديث المناطق التي لا تحوي تنسيقًا محليًا صريحًا فقط.

**كيف يعمل الخط على Linux وفي حاويات Docker التي لا تحتوي على خطوط نظام مثبتة؟**

تستخدم المكتبة اكتشاف/استبدال الخطوط. في الأنظمة التي لا تحتوي على خطوط، يجب عليك الإشارة صراحةً إلى أدلة الخطوط عبر [point to font directories](/slides/ar/python-net/custom-font/) أو تكوين [جدول الاستبدال](/slides/ar/python-net/font-substitution/) لتفادي الاعتماد على خطوط غير مناسبة وتغيّرات التخطيط.

**كيف يختلف تنسيق النص في العناصر النائبة عن تنسيق النص في الأشكال العادية؟**

العناصر النائبة ترث الأنماط من الشريحة الأساسية والتخطيط بقوة أكبر من الأشكال العادية. يمكن إجراء تغييرات محلية في العناصر النائبة، لكن عند تغيير التخطيط فإنها تميل إلى العودة إلى أنماط السمات ما لم تقم بتجاوز التنسيق على مستوى جزء النص.