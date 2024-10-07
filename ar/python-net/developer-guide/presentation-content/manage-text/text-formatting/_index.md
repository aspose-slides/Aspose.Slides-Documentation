---
title: تنسيق النص
type: docs
weight: 50
url: /python-net/text-formatting/
keywords:
- تسليط الضوء على النص
- التعبير العادي
- محاذاة فقرات النص
- شفافية النص
- خصائص خط الفقرة
- عائلة الخط
- تدوير النص
- تدوير بزاوية مخصصة
- إطار النص
- تباعد الأسطر
- خاصية الملائمة التلقائية
- ربط إطار النص
- تبويب النص
- النمط الافتراضي للنص
- بايثون
- Aspose.Slides لبايثون
description: "إدارة ومعالجة خصائص النص وإطار النص في بايثون"
---

## **تسليط الضوء على النص**
تم إضافة طريقة HighlightText جديدة إلى واجهة ITextFrame وClass TextFrame.

تسمح بتسليط الضوء على جزء من النص بلون الخلفية باستخدام نموذج النص، مماثل للأداة "لون تسليط الضوء على النص" في PowerPoint 2019.

يعرض المقتطف البرمجي أدناه كيفية استخدام هذه الميزة:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation(path + "SomePresentation.pptx") as presentation:
    presentation.slides[0].shapes[0].text_frame.highlight_text("title", draw.Color.light_blue)

    opts = slides.TextHighlightingOptions()
    opts.whole_words_only = True
    presentation.slides[0].shapes[0].text_frame.highlight_text("to", draw.Color.violet, opts)

    presentation.save("SomePresentation-out2.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="primary" %}} 

تقدم Aspose خدمة [تحرير PowerPoint مجانية عبر الإنترنت](https://products.aspose.app/slides/editor).

{{% /alert %}} 


## **تسليط الضوء على النص باستخدام التعبير العادي**
تم إضافة طريقة HighlightRegex جديدة إلى واجهة ITextFrame وClass TextFrame.

تسمح بتسليط الضوء على جزء من النص بلون الخلفية باستخدام regex، مماثل للأداة "لون تسليط الضوء على النص" في PowerPoint 2019.

يعرض المقتطف البرمجي أدناه كيفية استخدام هذه الميزة:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation(path + "SomePresentation.pptx") as presentation:
    options = slides.TextHighlightingOptions()

    presentation.slides[0].shapes[0].text_frame.highlight_regex("\\b[^\s]{5,}\\b", draw.Color.blue, options) 
    presentation.save("SomePresentation-out3.pptx", slides.export.SaveFormat.PPTX)
```


## **تعيين لون خلفية النص**

يسمح Aspose.Slides بتحديد اللون المفضل لديك لخلفية النص.

يوضح هذا الكود بلغة بايثون كيفية تعيين لون الخلفية لنص كامل: 

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    autoShape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)
    autoShape.text_frame.paragraphs.clear()

    para = slides.Paragraph()

    portion1 = slides.Portion("أسود")
    portion1.portion_format.font_bold = 1
    
    portion2 = slides.Portion(" أحمر ")
    
    portion3 = slides.Portion("أسود")
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

يوضح هذا الكود بلغة بايثون كيفية تعيين لون الخلفية لجزء فقط من نص:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    autoShape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)
    autoShape.text_frame.paragraphs.clear()

    para = slides.Paragraph()

    portion1 = slides.Portion("أسود")
    portion1.portion_format.font_bold = 1
    
    portion2 = slides.Portion(" أحمر ")
    
    portion3 = slides.Portion("أسود")
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

    redPortion = list(p for p in autoShape.text_frame.paragraphs[0].portions if 'أحمر' in p.text)[0]
    redPortion.portion_format.highlight_color.color = draw.Color.blue

    pres.save("text-red.pptx", slides.export.SaveFormat.PPTX)
```


## **محاذاة فقرات النص**
يعتبر تنسيق النص أحد العناصر الأساسية أثناء إنشاء أي نوع من الوثائق أو العروض التقديمية. نعلم أن Aspose.Slides لبايثون عبر .NET تدعم إضافة النص إلى الشرائح، لكن في هذا الموضوع، سنرى كيف يمكننا التحكم في محاذاة فقرات النص في الشريحة. يرجى اتباع الخطوات أدناه لمحاذاة فقرات النص باستخدام Aspose.Slides لبايثون عبر .NET :

1. إنشاء مثيل من [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
2. الحصول على مرجع لشريحة باستخدام الفهرس الخاص بها.
3. الوصول إلى أشكال النماذج الموجودة في الشريحة وتحويلها إلى AutoShape.
4. الحصول على الفقرة (التي تحتاج إلى محاذاة) من TextFrame المعروض بواسطة AutoShape.
5. محاذاة الفقرة. يمكن محاذاة الفقرة إلى اليمين، اليسار، المركز، والتبرير.
6. كتابة العرض المعدل كملف PPTX.

يتم تقديم تنفيذ الخطوات أعلاه أدناه.

```py
import aspose.slides as slides

# Instantiate a Presentation object that represents a PPTX file
with slides.Presentation(path + "ParagraphsAlignment.pptx") as presentation:
    # Accessing first slide
    slide = presentation.slides[0]

    # Accessing the first and second placeholder in the slide and typecasting it as AutoShape
    tf1 = slide.shapes[0].text_frame
    tf2 = slide.shapes[1].text_frame

    # Change the text in both placeholders
    tf1.text = "محاذاة مركزية بواسطة Aspose"
    tf2.text = "محاذاة مركزية بواسطة Aspose"

    # Getting the first paragraph of the placeholders
    para1 = tf1.paragraphs[0]
    para2 = tf2.paragraphs[0]

    # Aligning the text paragraph to center
    para1.paragraph_format.alignment = slides.TextAlignment.CENTER
    para2.paragraph_format.alignment = slides.TextAlignment.CENTER

    #Writing the presentation as a PPTX file
    presentation.save("Centeralign_out.pptx", slides.export.SaveFormat.PPTX)
```


## **تعيين الشفافية للنص**
توضح هذه المقالة كيفية تعيين خاصية الشفافية لأي شكل نص باستخدام Aspose.Slides لبايثون عبر .NET. لتعيين الشفافية للنص. يرجى اتباع الخطوات أدناه:

1. إنشاء مثيل من [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
2. الحصول على مرجع لشريحة.
3. تعيين لون الظل
4. كتابة العرض كملف PPTX.

يتم تقديم تنفيذ الخطوات أعلاه أدناه.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation(path + "transparency.pptx") as pres:
    shape = pres.slides[0].shapes[0]
    effects = shape.text_frame.paragraphs[0].portions[0].portion_format.effect_format

    outerShadowEffect = effects.outer_shadow_effect

    shadowColor = outerShadowEffect.shadow_color.color
    print("{color} - الشفافية هي: {value}".format(color = shadowColor, value = (shadowColor.a / 255) * 100))
    # set transparency to zero percent
    outerShadowEffect.shadow_color.color = draw.Color.from_argb(255, shadowColor)

    pres.save("transparency-2.pptx", slides.export.SaveFormat.PPTX)
```


## **تعيين تباعد الأحرف للنص**

يسمح Aspose.Slides بتعيين المسافة بين الأحرف في مربع النص. بهذه الطريقة، يمكنك ضبط الكثافة البصرية لسطر أو كتلة من النص عن طريق توسيع أو تقليص المسافة بين الأحرف.

يوضح هذا الكود بلغة بايثون كيفية توسيع المسافة لخط واحد من النص وتقليص المسافة لخط آخر: 

```python
import aspose.slides as slides

with slides.Presentation("in.pptx") as pres:

    textBox1 = pres.slides[0].shapes[0]
    textBox2 = pres.slides[0].shapes[1]

    textBox1.text_frame.paragraphs[0].paragraph_format.default_portion_format.spacing = 20 # expand
    textBox2.text_frame.paragraphs[0].paragraph_format.default_portion_format.spacing = -2 # condense

    pres.save("out.pptx", slides.export.SaveFormat.PPTX)
```


## **إدارة خصائص خط الفقرة**
تحتوي العروض التقديمية عادةً على نصوص وصور. يمكن تنسيق النص بطرق مختلفة، إما لتسليط الضوء على أقسام وكلمات معينة، أو للامتثال لأنماط الشركات. يساعد تنسيق النص المستخدمين في تغيير المظهر والشعور بمحتوى العرض التقديمي. توضح هذه المقالة كيفية استخدام Aspose.Slides لبايثون عبر .NET لتكوين خصائص خط فقرات النص على الشرائح. لإدارة خصائص خط فقرة باستخدام Aspose.Slides لبايثون عبر .NET :

1. إنشاء مثيل من [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
1. الحصول على مرجع شريحة باستخدام الفهرس الخاص بها.
1. الوصول إلى أشكال النماذج في الشريحة وتحويلها إلى AutoShape.
1. الحصول على الفقرة من TextFrame المعروض بواسطة AutoShape.
1. تبرير الفقرة.
1. الوصول إلى جزء نص الفقرة.
1. تحديد الخط باستخدام FontData وتعيين الخط لجزء النص وفقًا لذلك.
   1. تعيين الخط كبولد.
   1. تعيين الخط كإيطالي.
1. تعيين لون الخط باستخدام FillFormat المعروض بواسطة كائن Portion.
1. كتابة العرض المعدل إلى ملف [PPTX](https://docs.fileformat.com/presentation/pptx/) .

يتم تقديم تنفيذ الخطوات أعلاه أدناه. يأخذ عرضًا بدون تزيين ويقوم بتنسيق الخطوط على أحد الشرائح.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Instantiate a Presentation object that represents a PPTX file
with slides.Presentation(path + "FontProperties.pptx") as pres:
    # Accessing a slide using its slide position
    slide = pres.slides[0]

    # Accessing the first and second placeholder in the slide and typecasting it as AutoShape
    tf1 = slide.shapes[0].text_frame
    tf2 = slide.shapes[1].text_frame

    # Accessing the first Paragraph
    para1 = tf1.paragraphs[0]
    para2 = tf2.paragraphs[0]

    # Accessing the first portion
    port1 = para1.portions[0]
    port2 = para2.portions[0]

    # Define new fonts
    fd1 = slides.FontData("فيليب")
    fd2 = slides.FontData("كاستيلار")

    # Assign new fonts to portion
    port1.portion_format.latin_font = fd1
    port2.portion_format.latin_font = fd2

    # Set font to Bold
    port1.portion_format.font_bold = 1
    port2.portion_format.font_bold = 1

    # Set font to Italic
    port1.portion_format.font_italic = 1
    port2.portion_format.font_italic = 1

    # Set font color
    port1.portion_format.fill_format.fill_type = slides.FillType.SOLID
    port1.portion_format.fill_format.solid_fill_color.color = draw.Color.purple
    port2.portion_format.fill_format.fill_type = slides.FillType.SOLID
    port2.portion_format.fill_format.solid_fill_color.color = draw.Color.peru

    #Write the PPTX to disk
    pres.save("WelcomeFont_out.pptx", slides.export.SaveFormat.PPTX)
```


## **إدارة عائلة الخط للنص**
يتم استخدام جزء لاحتواء النص بأسلوب تنسيق مشابه في فقرة. توضح هذه المقالة كيفية استخدام Aspose.Slides لبايثون لإنشاء مربع نص مع بعض النص، ثم تحديد خط معين، وخصائص متنوعة أخرى من فئة عائلة الخط. لإنشاء مربع نص وتعيين خصائص الخط للنص فيه:

1. إنشاء مثيل من [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
2. الحصول على مرجع لشريحة باستخدام الفهرس الخاص بها.
3. إضافة AutoShape من النوع Rectangle إلى الشريحة.
4. إزالة نمط التعبئة المرتبط بـ AutoShape.
5. الوصول إلى TextFrame المرتبطة بـ AutoShape.
6. إضافة بعض النص إلى TextFrame.
7. الوصول إلى كائن Portion المرتبط بـ TextFrame.
8. تحديد الخط الذي يجب استخدامه لـ Portion.
9. تعيين خصائص الخط الأخرى مثل بولد، إيطالي، تحته خط، لون وارتفاع باستخدام الخصائص ذات الصلة المعروضة بواسطة كائن Portion.
10. كتابة العرض المعدل كملف PPTX.

يتم تقديم تنفيذ الخطوات أعلاه أدناه.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Instantiate Presentation
with slides.Presentation() as presentation:
    # Get first slide
    sld = presentation.slides[0]

    # Add an AutoShape of Rectangle type
    ashp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 50)

    # Remove any fill style associated with the AutoShape
    ashp.fill_format.fill_type = slides.FillType.NO_FILL

    # Access the TextFrame associated with the AutoShape
    tf = ashp.text_frame
    tf.text = "مربع نص أسبوز"

    # Access the Portion associated with the TextFrame
    port = tf.paragraphs[0].portions[0]

    # Set the Font for the Portion
    port.portion_format.latin_font = slides.FontData("Times New Roman")

    # Set Bold property of the Font
    port.portion_format.font_bold = 1

    # Set Italic property of the Font
    port.portion_format.font_italic = 1

    # Set Underline property of the Font
    port.portion_format.font_underline = slides.TextUnderlineType.SINGLE

    # Set the Height of the Font
    port.portion_format.font_height = 25

    # Set the color of the Font
    port.portion_format.fill_format.fill_type = slides.FillType.SOLID
    port.portion_format.fill_format.solid_fill_color.color = draw.Color.blue

    # Write the PPTX to disk 
    presentation.save("SetTextFontProperties_out.pptx", slides.export.SaveFormat.PPTX)
```


## **تعيين حجم الخط للنص**

يسمح Aspose.Slides لك باختيار حجم الخط المفضل لديك للنص الحالي في فقرة وأي نصوص أخرى قد تتم إضافتها إلى الفقرة لاحقًا.

يوضح هذا الكود بلغة بايثون كيفية تعيين حجم الخط للنصوص الموجودة في فقرة: 

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:

    # Gets the first shape, for example.
    shape = presentation.slides[0].shapes[0]

    if type(shape) is slides.AutoShape:
        # Gets the first paragraph, for example.
        paragraph = shape.text_frame.paragraphs[0]

        # Sets the default font size to 20 pt for all text portions in the paragraph. 
        paragraph.paragraph_format.default_portion_format.font_height = 20

        # Sets the font size to 20 pt for current text portions in the paragraph. 
        for portion in paragraph.portions:
            portion.portion_format.font_height = 20

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)

```


## **تدوير النص**
يسمح Aspose.Slides لبايثون عبر .NET للمطورين بتدوير النص. يمكن تعيين النص ليظهر أفقيًا، رأسيًا، عمودي 270، WordArt عمودي، EastAsian عمودي، Mongolian عمودي أو WordArt عمودي من اليمين إلى اليسار. لتدوير نص أي TextFrame، يرجى اتباع الخطوات أدناه:

1. إنشاء مثيل من [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
2. الوصول إلى الشريحة الأولى.
3. إضافة أي شكل إلى الشريحة.
4. الوصول إلى TextFrame.
5. تدوير النص.
6. حفظ الملف على القرص.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Create an instance of Presentation class
with slides.Presentation() as presentation:
    # Get the first slide 
    slide = presentation.slides[0]

    # Add an AutoShape of Rectangle type
    ashp = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 350, 350)

    # Add TextFrame to the Rectangle
    ashp.add_text_frame(" ")
    ashp.fill_format.fill_type = slides.FillType.NO_FILL

    # Accessing the text frame
    txtFrame = ashp.text_frame
    txtFrame.text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL270

    # Create the Paragraph object for text frame
    para = txtFrame.paragraphs[0]

    # Create Portion object for paragraph
    portion = para.portions[0]
    portion.text = "ثعلب بني سريع يقفز فوق الكلب الكسول. ثعلب بني سريع يقفز فوق الكلب الكسول."
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black

    # Save Presentation
    presentation.save("RotateText_out.pptx", slides.export.SaveFormat.PPTX)
```


## **تعيين زاوية دوران مخصصة لإطار النص**
يدعم Aspose.Slides لبايثون عبر .NET الآن، تعيين زاوية دوران مخصصة لإطار النص. في هذا الموضوع، سنرى بمثال كيفية تعيين خاصية RotationAngle في Aspose.Slides. تم إضافة الخاصية الجديدة RotationAngle إلى واجهتي IChartTextBlockFormat وITextFrameFormat، مما يسمح بتعيين زاوية الدوران المخصصة لإطار النص. لتعيين خاصية RotationAngle، يرجى اتباع الخطوات أدناه:

1. إنشاء مثيل من [Presentation ](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)class.
2. إضافة مخطط على الشريحة.
3. تعيين خاصية RotationAngle.
4. كتابة العرض كملف PPTX.

في المثال المعطى أدناه، نقوم بتعيين خاصية RotationAngle.

```py
import aspose.slides as slides

# Create an instance of Presentation class
with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(slides.charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 300)

    series = chart.chart_data.series[0]

    series.labels.default_data_label_format.show_value = True
    series.labels.default_data_label_format.text_format.text_block_format.rotation_angle = 65

    chart.has_title = True
    chart.chart_title.add_text_frame_for_overriding("عنوان مخصص").text_frame_format.rotation_angle = -30

    # Save Presentation
    presentation.save("textframe-rotation_out.pptx", slides.export.SaveFormat.PPTX)
```


## **تباعد الأسطر للفقرة**
يوفر Aspose.Slides خصائص ضمن `paragraph_format`—`space_after`، `space_before` و`space_within`—تسمح لك بإدارة تباعد الأسطر لفقرة. يتم استخدام الخصائص الثلاث بالطريقة التالية:

* لتحديد تباعد الأسطر لفقرة كنسبة مئوية، استخدم قيمة إيجابية. 
* لتحديد تباعد الأسطر لفقرة بالنقاط، استخدم قيمة سلبية.

على سبيل المثال، يمكنك تطبيق تباعد بمقدار 16 نقطة لفقرة عن طريق تعيين خاصية `space_before` إلى -16.

هذا هو كيف تحدد تباعد الأسطر لفقرة معينة:

1. تحميل عرض يحتوي على AutoShape مع بعض النصوص فيه.
2. الحصول على مرجع للشريحة من خلال فهرسها.
3. الوصول إلى TextFrame.
4. الوصول إلى الفقرة.
5. تعيين خصائص الفقرة.
6. حفظ العرض.

يوضح هذا الكود بلغة بايثون كيفية تحديد تباعد الأسطر لفقرات:

```py
import aspose.slides as slides

# Create an instance of Presentation class
with slides.Presentation(path + "Fonts.pptx") as presentation:

    # Obtain a slide's reference by its index
    sld = presentation.slides[0]

    # Access the TextFrame
    tf1 = sld.shapes[0].text_frame

    # Access the Paragraph
    para1 = tf1.paragraphs[0]

    # Set properties of Paragraph
    para1.paragraph_format.space_within = 80
    para1.paragraph_format.space_before = 40
    para1.paragraph_format.space_after = 40
    # Save Presentation
    presentation.save("LineSpacing_out.pptx", slides.export.SaveFormat.PPTX)
```


## **تعيين خاصية AutofitType لإطار النص**
في هذا الموضوع، سنستكشف خصائص التنسيق المختلفة لإطار النص. تغطي هذه المقالة كيفية تعيين خاصية AutofitType لإطار النص، ربط النص وتدوير النص في العرض. يسمح Aspose.Slides لبايثون عبر .NET للمطورين بتعيين خاصية AutofitType لأي إطار نص. يمكن تعيين AutofitType إلى Normal أو Shape. إذا تم تعيينه إلى Normal، فسيظل الشكل كما هو في حين سيتم ضبط النص دون التسبب في تغيير الشكل نفسه، بينما إذا تم تعيين AutofitType إلى الشكل، فسيتم تعديل الشكل بحيث يتم احتواء النص المطلوب فقط فيه. لتعيين خاصية AutofitType لإطار النص، يرجى اتباع الخطوات أدناه:

1. إنشاء مثيل من [Presentation ](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)class.
2. الوصول إلى الشريحة الأولى.
3. إضافة أي شكل إلى الشريحة.
4. الوصول إلى TextFrame.
5. تعيين AutofitType لإطار النص.
6. حفظ الملف على القرص.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Create an instance of Presentation class
with slides.Presentation() as presentation:

    # Access the first slide 
    slide = presentation.slides[0]

    # Add an AutoShape of Rectangle type
    ashp = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 350, 350)

    # Add TextFrame to the Rectangle
    ashp.add_text_frame(" ")
    ashp.fill_format.fill_type = slides.FillType.NO_FILL

    # Accessing the text frame
    txtFrame = ashp.text_frame
    txtFrame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE

    # Create the Paragraph object for text frame
    para = txtFrame.paragraphs[0]

    # Create Portion object for paragraph
    portion = para.portions[0]
    portion.text = "ثعلب بني سريع يقفز فوق الكلب الكسول. ثعلب بني سريع يقفز فوق الكلب الكسول."
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black

    # Save Presentation
    presentation.save("formatText_out.pptx", slides.export.SaveFormat.PPTX) 
```


## **تعيين ربط إطار النص**
يسمح Aspose.Slides لبايثون عبر .NET للمطورين بتعيين ربط أي إطار نص. تحدد TextAnchorType مكان النص داخل الشكل. يمكن تعيين TextAnchorType إلى أعلى أو وسط أو أسفل أو مبرر أو موزع. لتعيين ربط أي إطار نص، يرجى اتباع الخطوات أدناه:

1. إنشاء مثيل من [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
2. الوصول إلى الشريحة الأولى.
3. إضافة أي شكل إلى الشريحة.
4. الوصول إلى TextFrame.
5. تعيين TextAnchorType لإطار النص.
6. حفظ الملف على القرص.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Create an instance of Presentation class
with slides.Presentation() as presentation:
    # Get the first slide 
    slide = presentation.slides[0]

    # Add an AutoShape of Rectangle type
    ashp = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 350, 350)

    # Add TextFrame to the Rectangle
    ashp.add_text_frame(" ")
    ashp.fill_format.fill_type = slides.FillType.NO_FILL

    # Accessing the text frame
    txtFrame = ashp.text_frame
    txtFrame.text_frame_format.anchoring_type = slides.TextAnchorType.BOTTOM

    # Create the Paragraph object for text frame
    para = txtFrame.paragraphs[0]

    # Create Portion object for paragraph
    portion = para.portions[0]
    portion.text = "ثعلب بني سريع يقفز فوق الكلب الكسول. ثعلب بني سريع يقفز فوق الكلب الكسول."
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black

    # Save Presentation
    presentation.save("AnchorText_out.pptx", slides.export.SaveFormat.PPTX)
```


## **تعيين تبويب النص**
- EffectiveTabs.ExplicitTabCount (2 في حالتنا) الخاصية تساوي Tabs.Count.
- تشمل مجموعة EffectiveTabs جميع التبويبات (من مجموعة Tabs والتبويبات الافتراضية)
- EffectiveTabs.ExplicitTabCount (2 في حالتنا) الخاصية تساوي Tabs.Count.
- EffectiveTabs.DefaultTabSize (294) الخاصةية تحدد المسافة بين التبويبات الافتراضية (3 و4 في مثالنا).
- EffectiveTabs.GetTabByIndex(index) مع index = 0 ستعيد أول تبويب صريح (Position = 731)، index = 1 - التبويب الثاني (Position = 1241). إذا حاولت الحصول على التبويب التالي مع index = 2، فسوف تعيد أول تبويب افتراضي (Position = 1470) وهكذا.
- EffectiveTabs.GetTabAfterPosition(pos) يستخدم للحصول على التبويب التالي بعد نص معين. على سبيل المثال لديك نص: "Helloworld!". لرسم مثل هذا النص يجب أن تعرف من أين تبدأ رسم "world!". أولاً، يجب عليك حساب طول "Hello" بالبكسل واستدعاء GetTabAfterPosition مع هذه القيمة. ستحصل على موقع التبويب التالي لرسم "world!".


## **تعيين النمط الافتراضي للنص**

إذا كنت بحاجة إلى تطبيق نفس تنسيق النص الافتراضي على جميع عناصر النص في العرض في آن واحد، يمكنك استخدام خاصية `default_text_style` من [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class وتعيين التنسيق المفضل. المثال أدناه يوضح كيفية تعيين الخط العريض الافتراضي (14 نقطة) للنص على جميع الشرائح في عرض تقديمي جديد.

```py
with slides.Presentation() as presentation:
    # احصل على تنسيق الفقرة من المستوى الأعلى.
    paragraphFormat = presentation.default_text_style.get_level(0)

    if paragraphFormat is not None:
        paragraphFormat.default_portion_format.font_height = 14
        paragraphFormat.default_portion_format.font_bold = slides.NullableBool.TRUE

    presentation.save("DefaultTextStyle.pptx", slides.export.SaveFormat.PPTX)
```