---
title: "Python में PowerPoint प्रस्तुतियों में गणितीय समीकरण जोड़ें"
linktitle: "PowerPoint गणितीय समीकरण"
type: docs
weight: 80
url: /hi/python-net/powerpoint-math-equations/
keywords:
- "गणितीय समीकरण"
- "गणितीय प्रतीक"
- "गणितीय सूत्र"
- "गणितीय पाठ"
- "गणितीय समीकरण जोड़ें"
- "गणितीय प्रतीक जोड़ें"
- "गणितीय सूत्र जोड़ें"
- "गणितीय पाठ जोड़ें"
- "PowerPoint"
- "प्रस्तुति"
- "Python"
- "Aspose.Slides"
description: "Aspose.Slides for Python via .NET के साथ PowerPoint PPT और PPTX में गणितीय समीकरण डालें और संपादित करें, OMML का समर्थन, स्वरूपण नियंत्रण, और स्पष्ट Python कोड उदाहरण प्रदान करता है।"
---
## **परिचय**

PowerPoint समीकरणों को Office Math Markup Language (OMML) के रूप में संग्रहीत करता है। Aspose.Slides for Python via .NET के साथ, आप प्रोग्रामmatically समान प्रकार की गणितीय सामग्री बना सकते हैं: भिन्न, मूल, फ़ंक्शन, सीमा, N-ary ऑपरेटर, मैट्रिक्स, एरे, और स्वरूपित गणित ब्लॉक।

PowerPoint में, उपयोगकर्ता सामान्यतः समीकरण **Insert > Equation** से जोड़ते हैं:

![PowerPoint Insert टैब जिसमें Equation कमांड चयनित है](powerpoint-math-equations_1.png)

परिणाम में स्लाइड पर संपाद्य गणित पाठ दिखता है:

![एक PowerPoint स्लाइड जिसमें एक संपाद्य गणित समीकरण है](powerpoint-math-equations_2.png)

Aspose.Slides उस गणित पाठ को तीन मुख्य ऑब्जेक्ट्स के माध्यम से बनाता है:

- एक math shape, जिसे [add_math_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_math_shape/) से बनाया गया है, वह shape है जिसमें समीकरण होता है।
- [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) shape के टेक्स्ट फ्रेम के भीतर गणित सामग्री को संग्रहीत करता है।
- [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) में एक या अधिक [MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/) ऑब्जेक्ट होते हैं।

नीचे के अधिकांश उदाहरण [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) और [MathElementBase](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/) की fluent विधियों का उपयोग करते हैं ताकि कोड छोटा और पठनीय रहे।

MathML निर्यात परिदृश्यों के लिए, देखें [Python के माध्यम से .NET में प्रस्तुतियों से गणितीय समीकरण निर्यात](/slides/hi/python-net/exporting-math-equations/)।

## **समीकरण बनाएं**

यह उदाहरण [add_math_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_math_shape/) का उपयोग करके एक math shape बनाता है और पाइथागोरस प्रमेय जोड़ता है:

![समीकरण c² = a² + b²](powerpoint-math-equations_3.png)

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

{{% alert color="info" title="नोट" %}}
[add_math_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_math_shape/) एक shape बनाता है जिसमें पहले से ही एक math paragraph होता है। पहले [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) तक पहुंचें, उसका [math_paragraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/math_paragraph/) प्राप्त करें, और उसमें math blocks या math elements जोड़ें।
{{% /alert %}}

### **Math Blocks को मिलाएँ**

जब समीकरण के भाग स्वतंत्र रूप से [MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/) ऑब्जेक्ट्स के रूप में बनते हैं, तो उन्हें मिलाने के लिए [join_block](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/join_block/) का उपयोग करें। उदाहरण में बाएँ ब्लॉक में `c² =` और दाएँ ब्लॉक में `a² + b²` बनाया गया है। [set_superscript](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/set_superscript/) सभी तीन पावरों के लिए संपाद्य गणितीय superscripts बनाता है।

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_math_shape(20, 20, 600, 100)
    math_paragraph = shape.text_frame.paragraphs[0].portions[0].math_paragraph

    left_block = math.MathBlock()
    left_block.add(math.MathematicalText("c").set_superscript("2"))
    left_block.add(math.MathematicalText("="))

    right_block = math.MathBlock()
    right_block.add(math.MathematicalText("a").set_superscript("2"))
    right_block.add(math.MathematicalText("+"))
    right_block.add(math.MathematicalText("b").set_superscript("2"))

    combined_block = left_block.join_block(right_block)
    math_paragraph.add(combined_block)

    presentation.save("equation.pptx", slides.export.SaveFormat.PPTX)
```

[join_block](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/join_block/) `left_block` को स्वयं वापस देता है, अब क्रम में दोनों भाग सम्मिलित होते हैं, और `right_block` को खाली छोड़ देता है। संयुक्त ब्लॉक को केवल एक बार [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) में जोड़ें। `equation.pptx` को पुनः खोलने के बाद, पैराग्राफ में एक ब्लॉक होता है जो `c² = a² + b²` को दर्शाता है, और सभी तीन पावर गणितीय superscripts के रूप में संरक्षित रहते हैं।

[add](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/add/) को `left_block.add(right_block)` के रूप में कॉल करने पर एक ब्लॉक को सीधे दूसरे के अंदर नेस्ट करने का प्रयास किया जाता है और यह .NET `InvalidOperationException` को लपेटते हुए `RuntimeError` उत्पन्न करता है।

## **भिन्न जोड़ें**

[divide](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/divide/) का उपयोग करके एक भिन्न बनाएं। आप [MathFractionTypes](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfractiontypes/) से भिन्न शैली चुन सकते हैं।

![एक विकृति भिन्न जिसमें एक को x से विभाजित दिखाया गया है](powerpoint-math-equations_4.png)

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

एक stacked भिन्न के लिए, [MathFractionTypes.BAR](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfractiontypes/) का उपयोग करें:

```py
import aspose.slides.mathtext as math

stacked_fraction = math.MathematicalText("x + 1").divide("y - 1", math.MathFractionTypes.BAR)
```

## **रैडिकल जोड़ें**

[radical](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/radical/) का उपयोग करके একটি वर्गमूल, क्यूब रूट, या अन्य मूल बनाएं। वर्तमान तत्व आधार बन जाता है, और तर्क डिग्री बन जाता है।

![एक n-ठ मूल (radical) अभिव्यक्ति जिसमें x मूल चिह्न के नीचे है](powerpoint-math-equations_5.png)

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

### **वर्गमूल की डिग्री दिखाएँ या छिपाएँ**

वर्गमूल स्पष्ट 2 दिखा सकता है या पारंपरिक √x नोटेशन का उपयोग कर सकता है। [hide_degree](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathradical/hide_degree/) प्रॉपर्टी [MathRadical](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathradical/) की निर्धारित करती है कि कौन सा रूप दिखे। दोनों रूपों में डिग्री 2 और radicand x संपाद्य समीकरण में रहते हैं।

![x का वर्गमूल, बाएँ में डिग्री 2 दृश्यमान और दाएँ में छिपा हुआ](square-root-degree.png)

उदाहरण समान वर्गमूल दो बार सहेजता है। 2 `visible-degree.pptx` में दृश्यमान है और `hidden-degree.pptx` में छिपा है।

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    
    radical = math.MathematicalText("x").radical("2")

    shape = slide.shapes.add_math_shape(20, 20, 200, 100)
    portion = shape.text_frame.paragraphs[0].portions[0]
    portion.math_paragraph.add(math.MathBlock(radical))

    radical.hide_degree = False
    presentation.save("visible-degree.pptx", slides.export.SaveFormat.PPTX)

    radical.hide_degree = True
    presentation.save("hidden-degree.pptx", slides.export.SaveFormat.PPTX)
```

## **फ़ंक्शन और सीमा जोड़ें**

[as_argument_of_function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/as_argument_of_function/) या [function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/function/) का उपयोग `sin(x)`, `log(x)` जैसे फ़ंक्शन या कस्टम फ़ंक्शन नामों के लिए करें। सीमाओं के लिए, `lim` को एक [MathLimit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathlimit/) में रखें या [set_lower_limit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/set_lower_limit/) का उपयोग करें।

![x की सीमा जब x अनंत की ओर जाता है](powerpoint-math-equations_8.png)

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

कस्टम फ़ंक्शन नाम के लिए, फ़ंक्शन नाम को वर्तमान तत्व बनाएं और उसके तर्क के साथ [function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/function/) को कॉल करें:

```py
import aspose.slides.mathtext as math

custom_function = math.MathematicalText("f").function("x + 1")
```

## **N-ary ऑपरेटर और इंटीग्रल जोड़ें**

[summations, unions, intersections, and other large operators] के लिए [nary](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/nary/) का उपयोग करें। इंटीग्रल के लिए [integral](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/integral/) का उपयोग करें। दोनों विधियों से आप निचली और ऊपरी सीमाएं सेट कर सकते हैं।

![एक समिश्र (summation) जिसमें निचली और ऊपरी सीमाएं हैं](powerpoint-math-equations_7.png)

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

N-ary ऑपरेटर बड़े ऑपरेटरों के लिए होते हैं जिनमें वैकल्पिक सीमाएं होती हैं। सरल ऑपरेटर जैसे `+`, `-`, और `=` आमतौर पर [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) के रूप में जोड़े जाते हैं और अभिव्यक्ति में सम्मिलित होते हैं।

इंटीग्रल के लिए, [integral](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/integral/) का उपयोग करें:

```py
import aspose.slides.mathtext as math

integral_base = math.MathematicalText("x").join(math.MathematicalText("dx").to_box())
integral = integral_base.integral(math.MathIntegralTypes.SIMPLE, "0", "1")
```

## **मैट्रिक्स जोड़ें**

[pंक्तियों और स्तंभों] के लिए [MathMatrix](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathmatrix/) का उपयोग करें। मैट्रिक्स में डिफ़ॉल्ट रूप से कोष्ठक नहीं होते, इसलिए जब आप कोष्ठक, ब्रैकेट, या ब्रेस की आवश्यकता हो तो मैट्रिक्स को घेरें।

![दो पंक्तियों वाला गणितीय मैट्रिक्स जिसमें एक खाली सेल है](powerpoint-math-equations_10.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 120)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    matrix = math.MathMatrix(2, 3)

    matrix[0, 0] = math.MathematicalText("1")
    matrix[0, 1] = math.MathematicalText("x")
    matrix[1, 0] = math.MathematicalText("x")
    matrix[1, 1] = math.MathematicalText("2")
    matrix[1, 2] = math.MathematicalText("y")
    math_paragraph.add(math.MathBlock(matrix))

    presentation.save("matrix.pptx", slides.export.SaveFormat.PPTX)
```

### **मौजूदा मैट्रिक्स संपादित करें**

मान लें कि एक रैखिक बीजगणित पाठ में `matrix.pptx` में गुणांक मैट्रिक्स है, जो पिछले उदाहरण द्वारा सहेजा गया है। अगले अभ्यास में, पहली समीकरण रखें, दूसरी को दो नई समीकरणों से बदलें, और चर सेट को संशोधित करें। मौजूदा मैट्रिक्स को [MathMatrix](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathmatrix/) के रूप में एक्सेस करके उन गुणांक को रखें जो अभी भी लागू हैं।

![मूल दो-पंक्तियों वाला गुणांक मैट्रिक्स जिसमें पहली पंक्ति में 1, x और एक खाली सेल, और दूसरी पंक्ति में x, 2, तथा y हैं](matrix-before-edit.png)

पंक्ति और स्तंभ सूचकांक शून्य से शुरू होते हैं और प्रत्येक कॉल के अनुसार वर्तमान मैट्रिक्स को दर्शाते हैं। सूचकांक 1 से पहले पंक्ति डालने से मूल दूसरी पंक्ति सूचकांक 2 पर चली जाती है। सूचकांक 2 के बाद डालने से एक पंक्ति जोड़ जाती है। पंक्ति 2 को हटाने से मूल दूसरी समीकरण हट जाती है और जोड़ी गई पंक्ति एक स्थान ऊपर चली जाती है। स्तंभ भी इसी प्रकार शिफ्ट होते हैं।

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation("matrix.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    portion = shape.text_frame.paragraphs[0].portions[0]
    matrix = portion.math_paragraph[0][0]

    matrix.insert_row_before(1)
    matrix.insert_row_after(2)
    matrix.delete_row(2)

    matrix.insert_column_before(1)
    matrix.insert_column_after(3)
    matrix.delete_column(3)

    matrix[1, 0] = math.MathematicalText("12")
    matrix[1, 1] = math.MathematicalText("1")
    matrix[2, 2] = math.MathematicalText("10")
    matrix[2, 3] = math.MathematicalText("1")
    for row in range(matrix.row_count):
        for column in range(matrix.column_count):
            if matrix[row, column] is None:
                matrix[row, column] = math.MathematicalText("0")

    matrix.set_column_alignment(0, math.MathHorizontalAlignment.LEFT)
    matrix.set_columns_alignment(1, 3, math.MathHorizontalAlignment.RIGHT)

    presentation.save("updated-matrix.pptx", slides.export.SaveFormat.PPTX)
```

[set_column_alignment](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathmatrix/set_column_alignment/) पहली स्तंभ को बाएँ संरेखित करता है। [set_columns_alignment](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathmatrix/set_columns_alignment/) एक साथ तीन स्तंभों को दाएँ संरेखित करता है, सूचकांक 1 से शुरू करके। `updated-matrix.pptx` में, मैट्रिक्स में तीन समीकरण और चार चर हैं। मूल पहली पंक्तियों के गुणांक `1` और `x` अब पहली और तीसरी स्तंभ में दिखाई देते हैं।

![अपडेटेड तीन-पंक्तियों वाला मैट्रिक्स जिसमें पंक्तियाँ 1, 0, x, 0; 12, 1, 0, 0; और 0, 0, 10, 1 दिखाए गए हैं](matrix-after-edit.png)

## **समीकरण एरे जोड़ें**

जब आपको संरेखित समीकरणों या अभिव्यक्तियों की वर्टिकल स्टैक की आवश्यकता हो, तो [to_math_array](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/to_math_array/) का उपयोग करें।

![एक वर्टिकल गणित एरे जिसमें x ऊपर y है](powerpoint-math-equations_11.png)

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

### **आसपास के तत्वों के साथ एरे संरेखित करें**

[MathArray.base_justification](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/matharray/base_justification/) एरे को उसके बगल में स्थित गणितीय तत्वों के सापेक्ष वर्टिकल संरेखण को नियंत्रित करता है। नीचे का उदाहरण पहली पंक्ति, एरे के केंद्र, और अंतिम पंक्ति के साथ संरेखण की तुलना करता है।

निम्न उदाहरण तीन समान एरे बनाता है, प्रत्येक में तीन पंक्तियाँ और पड़ोसी तत्व `A=` और `=B` हैं। सभी गणितीय पाठ Cambria Math पर 24 पॉइंट के साथ है। केवल एरे संरेखण बदलता है।

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

निम्न तुलना PowerPoint में सहेजी गई प्रस्तुति को दिखाती है। प्रत्येक एरे के बगल में `A=` और `=B` की स्थिति देखें।

![Top, Center, और Bottom संरेखण के साथ PowerPoint में समीकरण एरे और समान पड़ोसी तत्व](equation-array-alignment.png)

### **पंक्ति अंतराल कॉन्फ़िगर करें**

[row_spacing_rule](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/matharray/row_spacing_rule/) एरे के भीतर पंक्तियों के लिए अंतराल नियम चुनता है। [row_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/matharray/row_spacing/) स्पष्ट अंतराल नियम के लिए संख्यात्मक मान प्रदान करता है और प्रीसेट नियमों द्वारा अनदेखा किया जाता है।

सटीक अंतराल के लिए मान पॉइंट में मापा जाता है। अनुपातिक अंतराल के लिए यह आधी लाइनों में मापा जाता है: उदाहरण में मान `3` 1.5 लाइनों को दर्शाता है। स्पष्ट मान निर्दिष्ट करते समय दोनों प्रॉपर्टी सेट करें; केवल संख्यात्मक मान बदलने से अंतराल नियम नहीं चुना जाता।

नीचे वाला उदाहरण समान समीकरण, संरेखण, और फ़ॉन्ट सेटिंग्स के साथ पाँच प्रस्तुति सहेजता है। पहले तीन प्रीसेट उपयोग करते हैं; अंतिम दो स्पष्ट मान दिखाते हैं।

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

एरे पंक्ति अंतराल पैराग्राफ अंतराल से अलग है। [space_before](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_before/) और [space_after](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_after/) कंटेनिंग पैराग्राफ के चारों ओर स्थान जोड़ते हैं, एरे पंक्तियों के बीच नहीं। इसी प्रकार, [MathParagraph.justification](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/justification/) पूरे गणित पैराग्राफ को क्षैतिज रूप से स्थित करता है; यह एरे की वर्टिकल संरेखण सेटिंग को प्रतिस्थापित नहीं करता।

## **त्रिकोणमितीय फ़ंक्शन जोड़ें**

जब तर्क वर्तमान तत्व है और फ़ंक्शन नाम ज्ञात है, तो [as_argument_of_function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/as_argument_of_function/) का उपयोग करें।

![त्रिकोणमितीय फ़ंक्शन cos को 2x पर लागू किया गया है](powerpoint-math-equations_6.png)

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

## **सबस्क्रिप्ट और सुपरसक्रिप्ट जोड़ें**

सूचकांक और पावर के लिए सबस्क्रिप्ट और सुपरसक्रिप्ट हेल्पर्स का उपयोग करें। जब सूचकांक को आधार के बाएं पक्ष पर दिखाना हो, तो [set_sub_superscript_on_the_left](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/set_sub_superscript_on_the_left/) का उपयोग करें।

![बायें‑साइड सबस्क्रिप्ट 1 और सुपरस्क्रिप्ट n के साथ एक बड़ा Y](powerpoint-math-equations_9.png)

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

## **डिलीमीटर जोड़ें**

[enclose](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/enclose/) का उपयोग करके अभिव्यक्ति को डिलीमीटर में रखें। कई तत्वों वाले डिलीमीटर अभिव्यक्तियों के लिए आप एक विभाजक अक्षर भी सेट कर सकते हैं।

![x, y, और z को वर्टिकल बार द्वारा अलग किया गया एक डिलीमीटर अभिव्यक्ति](powerpoint-math-equations_13.png)

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

### **डिलीमीटर का आकार और संरेखण**

`True` करने पर [grow_to_match_operand_height](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathdelimiter/grow_to_match_operand_height/) पैरेंट ऑपरेन्ड की ऊँचाई के अनुसार कोष्ठकों को बड़ा बनाता है, `False` करने पर सामान्य आकार बना रहता है। [delimiter_shape](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathdelimiter/delimiter_shape/) दो में से एक [MathDelimiterShape](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathdelimitershape/) मान लेता है। `CENTERED` कोष्ठकों को गणितीय अक्ष पर केंद्रित करता है, जो बराबर चिन्ह के मध्य से चलता है। `MATCH` उन्हें enclosed सामग्री के साथ संरेखित करता है। ये सेटिंग केवल डिलीमीटर को प्रभावित करती है; अंदर की अभिव्यक्ति वही रहती है।

उदाहरण में `x` के एक्सपोनेंट में एक भिन्न रखा गया है, जिससे अभिव्यक्ति बेसलाइन के ऊपर अधिक विस्तारित होती है। चारों समीकरण समान कोष्ठकों और फ़ॉन्ट सेटिंग्स का उपयोग करते हैं।

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

PowerPoint में पंक्तियों की तुलना करके वृद्धि प्रभाव देखें। ऊपर की पंक्ति में कोष्ठक एक्सपोनेंट को घेरने के लिए बढ़ते हैं और दोनों आकार समान दिखते हैं। नीचे की पंक्ति में वृद्धि बंद है। बाएँ ( `CENTERED` ) कोष्ठक बराबर चिन्ह के साथ संरेखित हैं, जबकि दाएँ (`MATCH`) कोष्ठक अभिव्यक्ति के ऊपर स्थित हैं।

![ऊपर और नीचे दोनों में डिलीमीटर वृद्धि के साथ और बिना, बाएँ में Centered और दाएँ में Match के साथ चार समीकरण](delimiter-sizing.png)

## **बॉर्डर बॉक्स जोड़ें**

एक भिन्न पर [to_border_box](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/to_border_box/) को कॉल करके पूरी अभिव्यक्ति को फ्रेम करें। लौटाया गया [MathBorderBox](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathborderbox/) डिफ़ॉल्ट रूप से चारों पक्ष दिखाता है। व्यक्तिगत पक्ष हटाने के लिए [hide_top](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathborderbox/hide_top/), [hide_bottom](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathborderbox/hide_bottom/), [hide_left](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathborderbox/hide_left/), और [hide_right](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathborderbox/hide_right/) का उपयोग करें।

उदाहरण में एक ही भिन्न की छह प्रतियां एक स्लाइड पर रखी गईं। रद्द करने के लिए सभी चार पक्ष छिपाए गए और ऊपर‑बाएँ से नीचे‑दाएँ की ओर उठती हुई विकर्ण (↗) के लिए [strikethrough_bottom_left_to_top_right](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathborderbox/strikethrough_bottom_left_to_top_right/) या नीचे‑बाएँ से ऊपर‑दाएँ की ओर गिरती हुई विकर्ण (↘) के लिए [strikethrough_top_left_to_bottom_right](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathborderbox/strikethrough_top_left_to_bottom_right/) सेट किया गया है। आप किसी भी संयोजन के साथ [strikethrough_horizontal](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathborderbox/strikethrough_horizontal/) या [strikethrough_vertical](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathborderbox/strikethrough_vertical/) भी उपयोग कर सकते हैं।

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

![ऊपर की पंक्ति: पूर्ण बॉर्डर, नीचे और बाएँ पक्ष, उठती हुई विकर्ण। नीचे की पंक्ति: गिरती हुई विकर्ण, क्षैतिज स्ट्राइक, पूर्ण बॉर्डर के साथ वर्टिकल स्ट्राइक के साथ छह संपाद्य भिन्न।](border-box-fractions.png)

इस भिन्न में, क्षैतिज स्ट्राइक भिन्न रेखा के ऊपर ओवरलैप करता है। वर्टिकल स्ट्राइक अंश और हर दोनों को काटता है जबकि आसपास का बॉर्डर दिखाई देता है। ये रेखाएं पूरी अभिव्यक्ति को सजाते हैं। सामान्य पाठ स्ट्राइक‑थ्रू केवल टेक्स्ट रन के अक्षरों पर लागू होता है। PowerPoint में प्रस्तुति को पुनः खोलने के बाद, आप अभी भी अंश और हर को स्वतंत्र रूप से संपादित कर सकते हैं।

## **Phantom तत्वों के साथ दृश्यता और लेआउट नियंत्रण**

एक अभिव्यक्ति को [MathPhantom](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathphantom/) में लपेटें ताकि उसकी दृश्यता और वह समीकरण में जो स्थान लेता है, स्वतंत्र रूप से नियंत्रित हो सके। इसकी प्रॉपर्टी नीचे दी गई हैं:

| प्रॉपर्टी | प्रभाव |
| --- | --- |
| [show](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathphantom/show/) | `False` पर सेट करने से अभिव्यक्ति छिप जाती है। इसके परिमाण फिर भी लेआउट में योगदान देते हैं जब तक कि नीचे दी गई संबंधित प्रॉपर्टी `True` न हो। |
| [zero_width](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathphantom/zero_width/) | अभिव्यक्ति की क्षैतिज चौड़ाई को शून्य मानें, जिससे पड़ोसी तत्व एक-दूसरे के करीब आ सकें। |
| [zero_asc](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathphantom/zero_asc/) | इसका आरोह (baseline के ऊपर की ऊँचाई) शून्य मानें। इससे पड़ोसी तत्वों के ऊपर आरक्षित स्थान कम हो सकता है। |
| [zero_desc](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathphantom/zero_desc/) | इसका अवरोह (baseline के नीचे की गहराई) शून्य मानें। इससे भिन्न रेखा या अन्य सामग्री जो अभिव्यक्ति के नीचे है, पड़ोसी तत्वों के करीब आ सकती है। |

baseline वह संदर्भ रेखा है जिसपर सामान्य गणितीय अक्षर स्थित होते हैं। सामग्री को छुपाने से उसके परिमाण नहीं हटते, और परिमाण को शून्य मानने से अभिव्यक्ति नहीं हटती। अंतर्निहित अभिव्यक्ति [base](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathphantom/base/) के द्वारा उपलब्ध रहती है। फिर से दिखाने के लिए [show](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathphantom/show/) को `True` सेट करें; परिमाण सेटिंग्स अपरिवर्तित रहती हैं।

निचला उदाहरण पांच साइड‑बाय‑साइड वैरिएंट बनाता है: एक दृश्यमान भिन्न, एक छिपा हुआ भिन्न जो स्थान आरक्षित रखता है, और तीन छिपे हुए भिन्न जिनमें एक परिमाण शून्य माना गया है। प्रत्येक वैरिएंट समान आसपास की अभिव्यक्ति और Cambria Math पर 24 पॉइंट फ़ॉन्ट का उपयोग करता है। सभी समीकरण आकार समान शीर्ष स्थिति में होते हैं, जो ग्रे गाइड द्वारा चिह्नित है। बाहरी भिन्न के अंश में phantom रखने से वर्टिकल लेआउट परिवर्तन आसानी से देखे जा सकते हैं।

```py
import aspose.slides as slides
import aspose.slides.mathtext as math


def create_text(value):
    text = math.MathematicalText(value)
    text.format.font_height = 24
    text.format.latin_font = slides.FontData("Cambria Math")
    return text


with slides.Presentation() as presentation:
    presentation.slide_size.set_size(1000, 180, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]
    labels = ["Visible", "Hidden: reserves space", "Hidden: ZeroWidth", "Hidden: ZeroAsc", "Hidden: ZeroDesc"]

    guide = slide.shapes.add_auto_shape(slides.ShapeType.LINE, 10, 60, 980, 0)
    guide.line_format.fill_format.fill_type = slides.FillType.SOLID
    guide.line_format.fill_format.solid_fill_color.color = slides.Color.light_gray

    for i, label_text in enumerate(labels):
        left = 10 + i * 200
        label = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, left, 10, 190, 30)
        label.fill_format.fill_type = slides.FillType.NO_FILL
        label.line_format.fill_format.fill_type = slides.FillType.NO_FILL
        label.text_frame.text = label_text
        label_format = label.text_frame.paragraphs[0].portions[0].portion_format
        label_format.font_height = 14
        label_format.fill_format.fill_type = slides.FillType.SOLID
        label_format.fill_format.solid_fill_color.color = slides.Color.black

        fraction_numerator = create_text("a+b")
        fraction_denominator = create_text("c+d")
        fraction = math.MathFraction(fraction_numerator, fraction_denominator)
        phantom = math.MathPhantom(fraction)
        phantom.show = i == 0
        phantom.zero_width = i == 2
        phantom.zero_asc = i == 3
        phantom.zero_desc = i == 4

        left_text = create_text("x+")
        right_text = create_text("+y")
        numerator = math.MathBlock(left_text).join(phantom).join(right_text)
        denominator = create_text("z")
        equation = math.MathFraction(numerator, denominator)

        shape = slide.shapes.add_math_shape(left, 60, 190, 100)
        shape.text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.TOP
        math_paragraph = shape.text_frame.paragraphs[0].portions[0].math_paragraph
        math_paragraph.add(math.MathBlock(equation))

    presentation.save("math-phantom.pptx", slides.export.SaveFormat.PPTX)
```

![दृश्यमान भिन्न, स्थान आरक्षित करने वाला छिपा भिन्न, और ZeroWidth, ZeroAsc, या ZeroDesc सक्षम वाले छिपे भिन्नों की तुलना करने वाले पाँच PowerPoint समीकरणों की छवि](math-phantom.png)

## **शब्द समूहित करें**

[group](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/group/) का उपयोग करके अभिव्यक्ति के ऊपर या नीचे एक समूहिंग अक्षर रखें। समूहित शब्दों को लेबल करने के लिए एक सीमा जोड़ें।

![x + y अभिव्यक्ति को नीचे किसी भी पाठ के लेबल के साथ समूहित किया गया है](powerpoint-math-equations_15.png)

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

## **गणित तत्वों को स्वरूपित करें**

फ़ॉर्मेटिंग हेल्पर्स का केवल तभी उपयोग करें जब वे सूत्र को स्पष्ट करें। उदाहरण के लिए, [overbar](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/overbar/) गणितीय तत्व के ऊपर एक बार रखता है।

![एक गणितीय अभिव्यक्ति ABC जिसमें एक overbar है](powerpoint-math-equations_14.png)

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

### **मौजूदा समीकरण में पाठ स्वरूपित करें**

एक मौजूदा समीकरण में पूरे पाठ को स्वरूपित करने के लिए, प्रत्येक गणित ब्लॉक के तत्व वृक्ष को पार करें। [MathElementBase.get_children](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/get_children/) केवल तत्काल बच्चों को लौटाता है, इसलिए इसे पुनरावर्ती रूप से कॉल करें ताकि आप भिन्नों, स्क्रिप्ट्स, रैडिकल्स और अन्य नेस्टेड संरचनाओं के अंदर के पाठ तक पहुंच सकें। वर्तमान तत्व और उसके बच्चों दोनों की जाँच करें ताकि जब वह [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) हो तो प्रारंभिक तत्व भी शामिल हो।

यह उदाहरण मानता है कि `input.pptx` में एक समीकरण है जैसे `z = xᵢ / ∛y`, जिसमें अंश में सबस्क्रिप्ट और हर में रैडिकल है। केवल ब्लॉक के शीर्ष‑स्तर तत्वों को प्रोसेस करने से भिन्न के अंदर का पाठ छूट जाता। उदाहरण स्लाइड टेक्स्ट फ्रेम में गणितीय हिस्सों को खोजता है, उनके ब्लॉकों को [MathPortion.math_paragraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/math_paragraph/) के माध्यम से एक्सेस करता है, और प्रत्येक पाठ तत्व के [format](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/format/) प्रॉपर्टी के माध्यम से [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/font_height/) को 28 पॉइंट सेट करता है।

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

सहेजा गया प्रस्तुति प्रत्येक प्रोसेस किए गए समीकरण के हर स्तर पर अद्यतन पाठ स्वरूपण रखता है, जबकि उसका पाठ सामग्री और गणितीय संरचना बनी रहती है।

## **त्वरित संदर्भ**

| कार्य | मुख्य API |
| --- | --- |
| गणित पाठ बनाएं | [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) |
| तत्वों को मिलाएँ | [MathElementBase.join](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/join/) |
| भिन्न बनाएं | [MathElementBase.divide](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/divide/) |
| superscript या subscript जोड़ें | [set_superscript](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/set_superscript/), [set_subscript](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/set_subscript/) |
| फ़ंक्शन जोड़ें | [function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/function/), [as_argument_of_function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/as_argument_of_function/) |
| मूल (radicals) जोड़ें | [radical](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/radical/) |
| सीमाएँ जोड़ें | [set_lower_limit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/set_lower_limit/), [set_upper_limit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/set_upper_limit/) |
| बाएँ‑साइड स्क्रिप्ट जोड़ें | [set_sub_superscript_on_the_left](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/set_sub_superscript_on_the_left/) |
| समिश्र और इंटीग्रल जोड़ें | [nary](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/nary/), [integral](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/integral/) |
| मैट्रिक्स जोड़ें | [MathMatrix](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathmatrix/) |
| समीकरण एरे जोड़ें | [to_math_array](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/to_math_array/) |
| डिलीमीटर जोड़ें | [enclose](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/enclose/) |
| बार और बॉर्डर जोड़ें | [overbar](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/overbar/), [to_border_box](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/to_border_box/) |
| शब्द समूहित करें | [group](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/group/) |

## **FAQ**

**क्या मैं मौजूदा PowerPoint समीकरण को संपादित कर सकता हूँ?**

हाँ। प्रस्तुति खोलें, उस shape को खोजें जिसमें एक [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) हो, उसका [math_paragraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/math_paragraph/) प्राप्त करें, और उस पैराग्राफ में गणित ब्लॉक को अपडेट करें।

**क्या समीकरण संपाद्य PowerPoint गणित के रूप में सहेजे जाते हैं?**

हाँ। PPTX में सहेजते समय, Aspose.Slides समीकरण को संपाद्य Office Math सामग्री के रूप में लिखता है।

**क्या मैं समीकरण को LaTeX में निर्यात कर सकता हूँ?**

हाँ। समीकरण के [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) को उसके [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) से प्राप्त करें, और [MathParagraph.to_latex](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/to_latex/) को कॉल करके सीधे निर्यात करें। पूर्ण उदाहरण के लिए देखें [Python के माध्यम से .NET में प्रस्तुतियों से गणितीय समीकरण निर्यात](/slides/hi/python-net/exporting-math-equations/#export-math-equations-to-latex)।