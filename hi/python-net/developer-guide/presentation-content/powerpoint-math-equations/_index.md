---
title: PowerPoint प्रस्तुतियों में गणितीय समीकरण जोड़ें Python में
linktitle: PowerPoint गणितीय समीकरण
type: docs
weight: 80
url: /hi/python-net/powerpoint-math-equations/
keywords:
- गणितीय समीकरण
- गणितीय प्रतीक
- गणितीय सूत्र
- गणितीय पाठ
- गणितीय समीकरण जोड़ें
- गणितीय प्रतीक जोड़ें
- गणितीय सूत्र जोड़ें
- गणितीय पाठ जोड़ें
- PowerPoint
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET के साथ PowerPoint PPT और PPTX में गणितीय समीकरण सम्मिलित और संपादित करें, OMML का समर्थन, स्वरूपण नियंत्रण, और स्पष्ट Python कोड उदाहरण प्रदान करता है।"
---
## **परिचय**

PowerPoint समीकरणों को Office Math Markup Language (OMML) के रूप में संग्रहीत करता है। Aspose.Slides for Python via .NET के साथ, आप प्रोग्रामेटिक रूप से वही प्रकार की गणितीय सामग्री बना सकते हैं: भाग, मूल, फ़ंक्शन, सीमाएँ, N-ary ऑपरेटर, मैट्रिक्स, एरे, और स्वरूपित गणित ब्लॉकों।

PowerPoint में, उपयोगकर्ता सामान्यतः समीकरण **Insert > Equation** से जोड़ते हैं:

![PowerPoint Insert टैब में Equation कमांड चयनित](powerpoint-math-equations_1.png)

परिणाम स्लाइड पर संपादन योग्य गणितीय टेक्स्ट होता है:

![एक PowerPoint स्लाइड जिसमें संपादन योग्य गणितीय समीकरण है](powerpoint-math-equations_2.png)

Aspose.Slides इस गणितीय टेक्स्ट को तीन मुख्य ऑब्जेक्ट्स के माध्यम से बनाता है:

- एक गणितीय आकार, जिसे [add_math_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_math_shape/) से बनाया गया है, वह आकार है जिसमें समीकरण रहता है।
- [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) आकार के टेक्स्ट फ्रेम के भीतर गणितीय सामग्री संग्रहीत करता है।
- [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) में एक या अधिक [MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/) ऑब्जेक्ट्स होते हैं।

नीचे अधिकांश उदाहरण [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) और [IMathElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/) की फ़्लुएंट मेथड्स का उपयोग करके कोड को छोटा और पठनीय रखते हैं।

MathML निर्यात परिदृश्यों के लिए, देखें [Export Math Equations from Presentations in Python via .NET](/slides/hi/python-net/exporting-math-equations/)।

## **समीकरण बनाएं**

यह उदाहरण [add_math_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_math_shape/) का उपयोग करके एक गणितीय आकार बनाता है और पाइथागोरस प्रमेय जोड़ता है:

![समीकरण c वर्ग बराबर a वर्ग प्लस b वर्ग](powerpoint-math-equations_3.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 120)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    equation = (
        math.MathematicalText("c")
        .set_superscript("2")
        .join("=")
        .join(math.MathematicalText("a").set_superscript("2"))
        .join("+")
        .join(math.MathematicalText("b").set_superscript("2"))
    )

    math_paragraph.add(equation)

    presentation.save("pythagorean-theorem.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="info" title="Note" %}}
[add_math_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_math_shape/) एक आकार बनाता है जिसमें पहले से ही एक गणितीय पैराग्राफ शामिल होता है। पहले [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) को एक्सेस करें, उसका [math_paragraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/math_paragraph/) प्राप्त करें, और उसमें गणितीय ब्लॉक्स या तत्व जोड़ें।
{{% /alert %}}

## **भाग जोड़ें**

भाग बनाने के लिए [divide](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/divide/) का उपयोग करें। आप [MathFractionTypes](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfractiontypes/) से एक भाग शैली चुन सकते हैं।

![एक तिरछा गणितीय भाग जिसमें एक को x से विभाजित दिखाया गया है](powerpoint-math-equations_4.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 100)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    fraction = math.MathematicalText("1").divide("x", math.MathFractionTypes.SKEWED)

    math_paragraph.add(math.MathBlock(fraction))

    presentation.save("fraction.pptx", slides.export.SaveFormat.PPTX)
```

स्टैक्ड भाग के लिए, [MathFractionTypes.BAR](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfractiontypes/) का उपयोग करें:

```py
import aspose.slides.mathtext as math

stacked_fraction = math.MathematicalText("x + 1").divide("y - 1", math.MathFractionTypes.BAR)
```

## **मूल जोड़ें**

वर्गमूल, घनमूल या अन्य मूल बनाने के लिए [radical](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/radical/) का उपयोग करें। वर्तमान तत्व बेस बन जाता है, और तर्क डिग्री बन जाता है।

![एक n-वें मूल को अभिव्यक्ति जिसमें x मूल चिह्न के नीचे है](powerpoint-math-equations_5.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 100)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    radical = math.MathematicalText("x").radical("n")

    math_paragraph.add(math.MathBlock(radical))

    presentation.save("radical.pptx", slides.export.SaveFormat.PPTX)
```

## **फ़ंक्शन और सीमाएँ जोड़ें**

फ़ंक्शन जैसे `sin(x)`, `log(x)` या कस्टम फ़ंक्शन नामों के लिए [as_argument_of_function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/) या [function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/function/) का उपयोग करें। सीमाओं के लिए, [MathLimit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathlimit/) में `lim` रखें या [set_lower_limit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_lower_limit/) का उपयोग करें।

![x की सीमा जब x अनन्त की ओर बढ़ता है](powerpoint-math-equations_8.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 100)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    limit = (
        math.MathematicalText("lim")
        .set_lower_limit("x\u2192\u221E")
        .function("x")
    )

    math_paragraph.add(math.MathBlock(limit))

    presentation.save("functions-and-limits.pptx", slides.export.SaveFormat.PPTX)
```

कस्टम फ़ंक्शन नाम के लिए, फ़ंक्शन नाम को वर्तमान तत्व बनाएं और उसके तर्क के साथ [function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/function/) को कॉल करें:

```py
import aspose.slides.mathtext as math

custom_function = math.MathematicalText("f").function("x + 1")
```

## **N-ary ऑपरेटर और इंटीग्रल जोड़ें**

समिश्र, संघ, प्रतिच्छेद और अन्य बड़े ऑपरेटरों के लिए [nary](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/nary/) का उपयोग करें। इंटीग्रल के लिए [integral](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/integral/) का उपयोग करें। दोनों मेथड आपको निचली और ऊपरी सीमाएँ सेट करने की अनुमति देते हैं।

![निचली और ऊपरी सीमाओं के साथ एक समिश्रण](powerpoint-math-equations_7.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 120)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    summation_base = (
        math.MathematicalText("x")
        .set_superscript("k")
        .join(math.MathematicalText("a").set_superscript("n-k"))
    )

    summation = summation_base.nary(math.MathNaryOperatorTypes.SUMMATION, "k=0", "n")

    math_paragraph.add(math.MathBlock(summation))

    presentation.save("nary-operators.pptx", slides.export.SaveFormat.PPTX)
```

N-ary ऑपरेटर बड़े ऑपरेटरों के लिए होते हैं जिनमें वैकल्पिक सीमाएँ हो सकती हैं। साधारण ऑपरेटर जैसे `+`, `-`, और `=` आमतौर पर [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) के रूप में जोड़े जाते हैं और अभिव्यक्ति में सम्मिलित होते हैं।

इंटीग्रल के लिए, [integral](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/integral/) का उपयोग करें:

```py
import aspose.slides.mathtext as math

integral_base = math.MathematicalText("x").join(math.MathematicalText("dx").to_box())
integral = integral_base.integral(math.MathIntegralTypes.SIMPLE, "0", "1")
```

## **मैट्रिक्स जोड़ें**

पंक्तियों और स्तंभों के लिए [MathMatrix](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathmatrix/) का उपयोग करें। मैट्रिक्स डिफ़ॉल्ट रूप से कोष्ठक शामिल नहीं करता, इसलिए जब आपको कोष्ठक, ब्रेस या ब्रैकेट चाहिए, तो मैट्रिक्स को घेरें।

![एक दो-पंक्ति गणितीय मैट्रिक्स जिसमें एक खाली कोशिका है](powerpoint-math-equations_10.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 120)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    matrix = math.MathMatrix(2, 3)

    # एक मैट्रिक्स में अपने आप कोष्ठक नहीं होते, इसलिए इसे कोष्ठकों में घेरें।
    math_paragraph.add(math.MathBlock(matrix.enclose("(", ")")))

    presentation.save("matrix.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="warning" title="Warning" %}}
`MathMatrix` पंक्तियों और स्तंभों का ग्रिड बनाता है, उनके बीच गैप सेट करता है, और स्तंभों को संरेखित करता है, लेकिन Aspose.Slides for Python via .NET व्यक्तिगत मैट्रिक्स कोशिकाओं के लिए कोई एक्सेसर नहीं देता। कोड से बनाया गया मैट्रिक्स इसलिए खाली कोशिकाएँ रखता है; मौजूदा प्रस्तुति से आया मैट्रिक्स `get_children` से पढ़ा जा सकता है। जब आपको कोड से पंक्तियों को भरना हो तो समीकरण एरे का उपयोग करें।
{{% /alert %}}

## **समीकरण एरे जोड़ें**

जब आपको संरेखित समीकरण या अभिव्यक्तियों की ऊर्ध्वाधर स्टैक चाहिए तो [to_math_array](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/to_math_array/) का उपयोग करें।

![x ऊपर y के साथ एक ऊर्ध्वाधर गणितीय एरे](powerpoint-math-equations_11.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 140)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    equation_array = (
        math.MathematicalText("x")
        .join("y")
        .to_math_array()
    )

    math_paragraph.add(math.MathBlock(equation_array))

    presentation.save("equation-array.pptx", slides.export.SaveFormat.PPTX)
```

### **आसपास के तत्वों के साथ एरे को संरेखित करें**

[IMathArray.base_justification](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imatharray/base_justification/) एरे की ऊर्ध्वाधर संरेखण को उसके बगल के गणितीय तत्वों के सापेक्ष नियंत्रित करता है। नीचे दिया गया उदाहरण पहले पंक्ति, एरे के केंद्र, और अंतिम पंक्ति के साथ संरेखण की तुलना करता है।

निम्न उदाहरण तीन समान एरे बनाता है, प्रत्येक में तीन पंक्तियाँ और बगल के तत्व `A=` और `=B` हैं। सभी गणितीय टेक्स्ट Cambria Math 24 पॉइंट में हैं। केवल एरे का संरेखण बदला गया है।

```py
import aspose.slides as slides
import aspose.slides.mathtext as math


def create_text(value):
    text = math.MathematicalText(value)
    text.format.font_height = 24
    text.format.latin_font = slides.FontData("Cambria Math")
    return text


with slides.Presentation() as presentation:
    presentation.slide_size.set_size(780, 200, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]
    alignments = [math.MathVerticalAlignment.TOP, math.MathVerticalAlignment.CENTER, math.MathVerticalAlignment.BOTTOM]
    labels = ["Top", "Center", "Bottom"]

    for i, alignment in enumerate(alignments):
        label = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20 + i * 260, 10, 240, 30)
        label.fill_format.fill_type = slides.FillType.NO_FILL
        label.line_format.fill_format.fill_type = slides.FillType.NO_FILL
        label.text_frame.text = labels[i]
        label_format = label.text_frame.paragraphs[0].portions[0].portion_format
        label_format.font_height = 16
        label_format.fill_format.fill_type = slides.FillType.SOLID
        label_format.fill_format.solid_fill_color.color = slides.Color.black

        math_shape = slide.shapes.add_math_shape(20 + i * 260, 60, 240, 130)
        math_shape.text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.TOP
        math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph
        math_paragraph.justification = math.MathJustification.LEFT_JUSTIFIED

        rows = [create_text("x+y=3"), create_text("x-y=1"), create_text("x=2")]
        equation_array = math.MathArray(rows)
        equation_array.base_justification = alignment
        left_text = create_text("A=")
        right_text = create_text("=B")
        equation = math.MathBlock(left_text).join(equation_array).join(right_text)
        math_paragraph.add(equation)

    presentation.save("equation-array-alignment.pptx", slides.export.SaveFormat.PPTX)
```

नीचे तुलना में PowerPoint में सहेजी गई प्रस्तुति दिखती है। प्रत्येक एरे के बगल में `A=` और `=B` की स्थिति देखें।

![PowerPoint में शीर्ष, मध्य और निचले संरेखण वाले समीकरण एरे और समान बगल के तत्व](equation-array-alignment.png)

### **पंक्ति अंतराल कॉन्फ़िगर करें**

[row_spacing_rule](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imatharray/row_spacing_rule/) एरे के भीतर पंक्तियों के अंतराल नियम को चुनता है। [row_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imatharray/row_spacing/) स्पष्ट अंतराल नियम के लिए संख्यात्मक मान प्रदान करता है और प्रीसेट नियमों द्वारा अनदेखा किया जाता है।

सटीक अंतराल के लिए मान पॉइंट में मापा जाता है। अनुपातिक अंतराल के लिए यह आधी लाइनों में मापा जाता है: उदाहरण में मान `3` 1.5 लाइनों को दर्शाता है। स्पष्ट मान निर्दिष्ट करते समय दोनों गुणधर्म सेट करें; केवल संख्यात्मक मान बदलने से अंतराल नियम नहीं बदलता।

नीचे दिया गया उदाहरण समान समीकरण, संरेखण और फ़ॉन्ट सेटिंग्स के साथ पाँच प्रस्तुति सहेजता है। पहले तीन प्रीसेट उपयोग करते हैं; अंतिम दो स्पष्ट मान दिखाते हैं।

```py
import aspose.slides as slides
import aspose.slides.mathtext as math


def create_text(value):
    text = math.MathematicalText(value)
    text.format.font_height = 24
    text.format.latin_font = slides.FontData("Cambria Math")
    return text


settings = [
    (math.MathRowSpacingRule.SINGLE_LINE_GAP, 0),
    (math.MathRowSpacingRule.ONE_AND_A_HALF_LINE_GAP, 0),
    (math.MathRowSpacingRule.TWO_LINE_GAP, 0),
    (math.MathRowSpacingRule.EXACTLY, 20),
    (math.MathRowSpacingRule.MULTIPLE, 3)
]

for rule, spacing in settings:
    file_name = f"equation-array-{rule.name}.pptx"
    with slides.Presentation() as presentation:
        math_shape = presentation.slides[0].shapes.add_math_shape(20, 20, 600, 300)
        paragraph = math_shape.text_frame.paragraphs[0]
        paragraph.paragraph_format.space_before = 0
        paragraph.paragraph_format.space_after = 0
        math_paragraph = paragraph.portions[0].math_paragraph
        math_paragraph.justification = math.MathJustification.LEFT_JUSTIFIED

        rows = [create_text("x+y=3"), create_text("x-y=1"), create_text("x=2")]
        equation_array = math.MathArray(rows)
        equation_array.base_justification = math.MathVerticalAlignment.CENTER
        equation_array.row_spacing_rule = rule
        equation_array.row_spacing = spacing
        left_text = create_text("A=")
        right_text = create_text("=B")
        equation = math.MathBlock(left_text).join(equation_array).join(right_text)
        math_paragraph.add(equation)

        presentation.save(file_name, slides.export.SaveFormat.PPTX)
```

एरे पंक्ति अंतराल पैराग्राफ अंतराल से अलग होता है। [space_before](https://reference.aspose.com/slides/python-net/aspose.slides/iparagraphformat/space_before/) और [space_after](https://reference.aspose.com/slides/python-net/aspose.slides/iparagraphformat/space_after/) कंटेनिंग पैराग्रफ़ के चारों ओर अंतराल जोड़ते हैं, न कि एरे पंक्तियों के बीच। इसी प्रकार, [IMathParagraph.justification](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathparagraph/justification/) पूरे गणितीय पैराग्राफ को水平 रूप से स्थित करता है; यह एरे की ऊर्ध्वाधर संरेखण सेटिंग को प्रतिस्थापित नहीं करता।

## **त्रिकोणमितीय फ़ंक्शन जोड़ें**

जब तर्क वर्तमान तत्व है और फ़ंक्शन नाम ज्ञात है, तब [as_argument_of_function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/) का उपयोग करें।

![cos त्रिकोणमितीय फ़ंक्शन 2x पर लागू किया गया](powerpoint-math-equations_6.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 100)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    cosine = math.MathematicalText("2x").as_argument_of_function(
        math.MathFunctionsOfOneArgument.COS
    )

    math_paragraph.add(math.MathBlock(cosine))

    presentation.save("trigonometric-function.pptx", slides.export.SaveFormat.PPTX)
```

## **सबस्क्रिप्ट और सुपरस्क्रिप्ट जोड़ें**

सूचकांक और घातों के लिए सबस्क्रिप्ट और सुपरस्क्रिप्ट हेल्पर का उपयोग करें। जब सूचकांकों को बेस के बाएँ पक्ष पर दिखाना हो, तो [set_sub_superscript_on_the_left](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_sub_superscript_on_the_left/) का उपयोग करें।

![बाएँ तरफ सबस्क्रिप्ट 1 और सुपरस्क्रिप्ट n के साथ बड़ा Y](powerpoint-math-equations_9.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 100)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    scripts = math.MathematicalText("Y").set_sub_superscript_on_the_left("1", "n")

    math_paragraph.add(math.MathBlock(scripts))

    presentation.save("subscript-superscript.pptx", slides.export.SaveFormat.PPTX)
```

## **डिलिमिटर जोड़ें**

एक अभिव्यक्ति को डिलिमिटर के अंदर रखने के लिए [enclose](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/enclose/) का उपयोग करें। आप कई तत्वों वाले डिलिमिटर अभिव्यक्तियों के लिए विभाजक अक्षर भी सेट कर सकते हैं।

![x, y, और z को ऊर्ध्वाधर बार द्वारा अलग किए गए डिलिमिटर अभिव्यक्ति](powerpoint-math-equations_13.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 100)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    delimiter = (
        math.MathematicalText("x")
        .join("y")
        .join("z")
        .enclose("<", ">")
    )
    delimiter.separator_character = "|"

    math_paragraph.add(math.MathBlock(delimiter))

    presentation.save("delimiters.pptx", slides.export.SaveFormat.PPTX)
```

### **डिलिमिटर का आकार और संरेखण**

[grow_to_match_operand_height](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathdelimiter/grow_to_match_operand_height/) को `True` सेट करने से कोष्ठक लंबे ऑपरेण्ड के चारों ओर बढ़ते हैं, या `False` रखने से उनका सामान्य आकार रहता है। [delimiter_shape](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathdelimiter/delimiter_shape/) दो में से एक [MathDelimiterShape](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathdelimitershape/) मान लेता है। `CENTERED` कोष्ठकों को गणितीय अक्ष पर केंद्रित करता है, जो बराबर चिह्न के बीच से गुजरता है। `MATCH` उन्हें घिरे सामग्री के साथ संरेखित करता है। दोनों सेटिंग केवल डिलिमिटर को प्रभावित करती हैं। भीतर की अभिव्यक्ति वही रहती है।

उदाहरण में `x` के घात में एक भाग रखा गया है ताकि अभिव्यक्ति बेसलाइन के ऊपर अधिक विस्तारित हो। सभी चार समीकरण एक ही कोष्ठक और फ़ॉन्ट सेटिंग्स का उपयोग करते हैं।

```python
import aspose.slides as slides
import aspose.slides.mathtext as math


def add_expression(slide, left, top, grow, shape):
    fraction = math.MathematicalText("a + b").divide("c + d")
    power = math.MathematicalText("x").set_superscript(fraction)
    delimiter = power.enclose("(", ")")
    delimiter.grow_to_match_operand_height = grow
    delimiter.delimiter_shape = shape

    math_shape = slide.shapes.add_math_shape(left, top, 300, 100)
    portion = math_shape.text_frame.paragraphs[0].portions[0]
    portion.portion_format.font_height = 32
    equation = math.MathematicalText("y = ").join(delimiter)
    portion.math_paragraph.add(equation)


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    add_expression(slide, 20, 20, True, math.MathDelimiterShape.CENTERED)
    add_expression(slide, 350, 20, True, math.MathDelimiterShape.MATCH)
    add_expression(slide, 20, 140, False, math.MathDelimiterShape.CENTERED)
    add_expression(slide, 350, 140, False, math.MathDelimiterShape.MATCH)

    presentation.save("delimiter-sizing.pptx", slides.export.SaveFormat.PPTX)
```

PowerPoint में, प्रभाव देखने के लिए पंक्तियों की तुलना करें। ऊपर की पंक्ति में कोष्ठक घात को घेरने के लिए बढ़ते हैं और दोनों आकार समान दिखते हैं। नीचे की पंक्ति में वृद्धि बंद है। बाएँ (`CENTERED`) छोटे कोष्ठक बराबर चिह्न के साथ संरेखित होते हैं, जबकि दाएँ (`MATCH`) अभिव्यक्ति के चारों ओर ऊँचे होते हैं।

![PowerPoint में चार समीकरण, ऊपर कोष्ठक वृद्धि सक्रिय और नीचे निष्क्रिय, बाएँ centered और दाएँ match](delimiter-sizing.png)

## **बॉर्डर बॉक्स जोड़ें**

भाग पर [to_border_box](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/to_border_box/) को कॉल करके पूरी अभिव्यक्ति को फ्रेम करें। लौटाया गया [IMathBorderBox](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/) डिफ़ॉल्ट रूप से चारों पक्ष दिखाता है। व्यक्तिगत पक्ष हटाने के लिए [hide_top](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/hide_top/), [hide_bottom](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/hide_bottom/), [hide_left](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/hide_left/), और [hide_right](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/hide_right/) का उपयोग करें।

उदाहरण में एक ही भाग के छह प्रतियां एक स्लाइड पर रखी गई हैं। निरस्त्रीकरण दिखाने के लिए सभी चार पक्ष छिपाएँ और ऊपर‑से‑नीचे‑डायगोनल के लिए [strikethrough_bottom_left_to_top_right](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/strikethrough_bottom_left_to_top_right/) या नीचे‑से‑ऊपर‑डायगोनल के लिए [strikethrough_top_left_to_bottom_right](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/strikethrough_top_left_to_bottom_right/) सेट करें। आप किसी भी संयोजन के साथ दृश्यमान पक्षों के साथ [strikethrough_horizontal](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/strikethrough_horizontal/) या [strikethrough_vertical](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/strikethrough_vertical/) भी उपयोग कर सकते हैं।

```py
import aspose.slides as slides
import aspose.slides.mathtext as math


def add_fraction(slide, x, y, hide_border=False):
    fraction = math.MathematicalText("x+1").divide("y+2")
    box = fraction.to_border_box()
    box.hide_top = box.hide_bottom = box.hide_left = box.hide_right = hide_border

    shape = slide.shapes.add_math_shape(x, y, 160, 90)
    portion = shape.text_frame.paragraphs[0].portions[0]
    portion.portion_format.font_height = 28
    portion.math_paragraph.add(math.MathBlock(box))
    return box


with slides.Presentation() as presentation:
    presentation.slide_size.set_size(540, 220, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    add_fraction(slide, 10, 10)

    partial = add_fraction(slide, 190, 10)
    partial.hide_top = True
    partial.hide_right = True

    add_fraction(slide, 370, 10, hide_border=True).strikethrough_bottom_left_to_top_right = True
    add_fraction(slide, 10, 120, hide_border=True).strikethrough_top_left_to_bottom_right = True
    add_fraction(slide, 190, 120, hide_border=True).strikethrough_horizontal = True
    add_fraction(slide, 370, 120).strikethrough_vertical = True

    presentation.save("border-box.pptx", slides.export.SaveFormat.PPTX)
```

![PowerPoint में छह संपादन योग्य भाग। शीर्ष पंक्ति: पूरा बॉर्डर, नीचे और बाएँ पक्ष, ऊँची डायगोनल। नीचे पंक्ति: नीचे‑की‑डायगोनल, क्षैतिज स्ट्राइक, पूर्ण बॉर्डर के साथ लंबवत स्ट्राइक।](border-box-fractions.png)

इस भाग में, क्षैतिज स्ट्राइक भाग बार को ओवरलैप करता है। लंबवत स्ट्राइक अंश और हर दोनों को काटता है जबकि आसपास का बॉर्डर दृश्यमान रहता है। ये रेखाएँ पूरी अभिव्यक्ति को सजाती हैं। सामान्य टेक्स्ट स्ट्राइक‑थ्रू अक्षरों पर लागू होता है। PowerPoint में प्रस्तुति पुनः खोलने के बाद भी आप अंश और हर को स्वतंत्र रूप से संपादित कर सकते हैं।

## **टर्म समूहित करें**

एक अभिव्यक्ति के ऊपर या नीचे समूहिंग अक्षर रखने के लिए [group](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/group/) का उपयोग करें। समूहित टर्म को लेबल करने के लिए सीमा जोड़ें।

![x प्लस y अभिव्यक्ति को लेबल any text के साथ नीचे समूहित किया गया](powerpoint-math-equations_15.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 120)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    grouped = (
        math.MathematicalText("x + y")
        .group(chr(0x23DF), math.MathTopBotPositions.BOTTOM, math.MathTopBotPositions.TOP)
        .set_lower_limit("any text")
    )

    math_paragraph.add(math.MathBlock(grouped))

    presentation.save("grouped-terms.pptx", slides.export.SaveFormat.PPTX)
```

## **गणितीय तत्वों को स्वरूपित करें**

केवल तभी स्वरूपण हेल्पर का उपयोग करें जब वह सूत्र को स्पष्ट करता हो। उदाहरण के लिए, [overbar](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/overbar/) गणितीय तत्व के ऊपर एक बार रखता है।

![एक गणितीय अभिव्यक्ति ABC के ऊपर ओवरबार](powerpoint-math-equations_14.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 100)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    overbar = math.MathematicalText("ABC").overbar()

    math_paragraph.add(math.MathBlock(overbar))

    presentation.save("overbar.pptx", slides.export.SaveFormat.PPTX)
```

### **मौजूदा समीकरण में टेक्स्ट स्वरूपित करें**

मौजूदा समीकरण में पूरे टेक्स्ट को स्वरूपित करने के लिए प्रत्येक गणितीय ब्लॉक के तत्व वृक्ष को पार करें। [IMathElement.get_children](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/get_children/) केवल तत्काल बच्चों को लौटाता है, इसलिए इसे पुनरावर्ती रूप से कॉल करके भागों, स्क्रिप्ट, मूल और अन्य नेस्टेड संरचनाओं के भीतर के टेक्स्ट तक पहुँचें। वर्तमान तत्व और उसके बच्चों दोनों की जाँच करें ताकि जब वह [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) हो तो शुरूआती तत्व भी शामिल हो।

यह उदाहरण मानता है कि `input.pptx` में एक समीकरण है जैसे `z = xᵢ / ∛y`, जिसमें अंश के अंश में एक सबस्क्रिप्ट और हर में एक मूल है। केवल ब्लॉक के शीर्ष‑स्तर तत्वों को प्रोसेस करने से भाग के अंदर का टेक्स्ट छूट जाएगा। उदाहरण स्लाइड टेक्स्ट फ्रेम में गणितीय हिस्से खोजता है, उनके ब्लॉकों को [MathPortion.math_paragraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/math_paragraph/) के माध्यम से एक्सेस करता है, और प्रत्येक टेक्स्ट तत्व के [format](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/format/) प्रॉपर्टी के माध्यम से [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/font_height/) को 28 पॉइंट सेट करता है।

```py
import aspose.slides as slides
import aspose.slides.mathtext as math


def format_math_text(element):
    if isinstance(element, math.MathematicalText):
        element.format.font_height = 28

    for child in element.get_children():
        format_math_text(child)


with slides.Presentation("input.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if not isinstance(shape, slides.AutoShape) or shape.text_frame is None:
                continue

            for paragraph in shape.text_frame.paragraphs:
                for portion in paragraph.portions:
                    if isinstance(portion, math.MathPortion):
                        for block in portion.math_paragraph:
                            format_math_text(block)

    presentation.save("formatted-equations.pptx", slides.export.SaveFormat.PPTX)
```

सहेजा गया प्रस्तुति प्रत्येक प्रोसेस किए गये समीकरण के प्रत्येक स्तर पर अद्यतन टेक्स्ट स्वरूपण रखता है, जबकि उसके टेक्स्ट कंटेंट और गणितीय संरचना को बरकरार रखता है।

## **त्वरित संदर्भ**

| कार्य | मुख्य API |
| --- | --- |
| गणितीय टेक्स्ट बनाएं | [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) |
| तत्व संयोजित करें | [IMathElement.join](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/join/) |
| भाग बनाएं | [IMathElement.divide](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/divide/) |
| सुपरस्क्रिप्ट या सबस्क्रिप्ट जोड़ें | [set_superscript](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_superscript/), [set_subscript](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_subscript/) |
| फ़ंक्शन जोड़ें | [function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/function/), [as_argument_of_function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/) |
| मूल जोड़ें | [radical](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/radical/) |
| सीमाएँ जोड़ें | [set_lower_limit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_lower_limit/), [set_upper_limit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_upper_limit/) |
| बाएँ‑साइड स्क्रिप्ट जोड़ें | [set_sub_superscript_on_the_left](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_sub_superscript_on_the_left/) |
| समिश्रण और इंटीग्रल जोड़ें | [nary](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/nary/), [integral](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/integral/) |
| मैट्रिक्स जोड़ें | [MathMatrix](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathmatrix/) |
| समीकरण एरे जोड़ें | [to_math_array](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/to_math_array/) |
| डिलिमिटर जोड़ें | [enclose](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/enclose/) |
| बार और बॉर्डर जोड़ें | [overbar](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/overbar/), [to_border_box](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/to_border_box/) |
| टर्म समूहित करें | [group](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/group/) |

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं मौजूदा PowerPoint समीकरण को संपादित कर सकता हूँ?**

हां। प्रस्तुति खोलें, उस आकार को खोजें जिसमें एक [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) हो, उसका [math_paragraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/math_paragraph/) प्राप्त करें, और उस पैराग्राफ में गणितीय ब्लॉक्स को अपडेट करें।

**क्या समीकरण को संपादन योग्य PowerPoint गणित के रूप में सहेजा जाता है?**

हां। PPTX में सहेजते समय, Aspose.Slides समीकरण को संपादन योग्य Office गणित सामग्री के रूप में लिखता है।

**क्या मैं समीकरण को LaTeX में निर्यात कर सकता हूँ?**

हां। उसके [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) से [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) प्राप्त करें, और सीधे निर्यात करने के लिए [MathParagraph.to_latex](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/to_latex/) को कॉल करें। पूर्ण उदाहरण के लिए देखें [Export Math Equations from Presentations in Python via .NET](/slides/hi/python-net/exporting-math-equations/#export-math-equations-to-latex)।