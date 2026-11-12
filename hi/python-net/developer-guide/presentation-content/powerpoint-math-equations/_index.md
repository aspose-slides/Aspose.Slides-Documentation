---
title: Python में PowerPoint प्रस्तुतियों में गणितीय समीकरण जोड़ें
linktitle: PowerPoint गणितीय समीकरण
type: docs
weight: 80
url: /hi/python-net/powerpoint-math-equations/
keywords:
- गणितीय समीकरण
- गणितीय प्रतीक
- गणितीय सूत्र
- गणितीय टेक्स्ट
- गणितीय समीकरण जोड़ें
- गणितीय प्रतीक जोड़ें
- गणितीय सूत्र जोड़ें
- गणितीय टेक्स्ट जोड़ें
- PowerPoint
- प्रस्तुतीकरण
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET के साथ PowerPoint PPT और PPTX में गणितीय समीकरण सम्मिलित और संपादित करें, OMML को समर्थन, स्वरूपण नियंत्रण, और स्पष्ट Python कोड उदाहरण प्रदान करता है।"
---
## **परिचय**

PowerPoint समीकरणों को Office Math Markup Language (OMML) के रूप में संग्रहित करता है। Aspose.Slides for Python via .NET के साथ, आप प्रोग्रामेटिक रूप से वही प्रकार की गणितीय सामग्री बना सकते हैं: भिन्न, मूलांक, फलन, सीमा, N-ary ऑपरेटर, मैट्रिक्स, ऐरे, और स्वरूपित गणित ब्लॉक।

In PowerPoint, उपयोगकर्ता सामान्यतः **Insert > Equation** से समीकरण जोड़ते हैं:

![PowerPoint Insert टैब जिसमें Equation कमांड चयनित है](powerpoint-math-equations_1.png)

परिणाम स्लाइड पर संपादन योग्य गणितीय टेक्स्ट होता है:

![एक PowerPoint स्लाइड जिसमें संपादन योग्य गणितीय समीकरण है](powerpoint-math-equations_2.png)

Aspose.Slides उस गणितीय टेक्स्ट को तीन मुख्य वस्तुओं के माध्यम से बनाता है:

- एक गणितीय आकार, जिसे [add_math_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_math_shape/) के साथ बनाया जाता है, वह आकार है जिसमें समीकरण रहता है।
- [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) आकार के टेक्स्ट फ्रेम के भीतर गणितीय सामग्री संग्रहीत करता है।
- [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) एक या अधिक [MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/) वस्तुओं को समाहित करता है।

नीचे के अधिकांश उदाहरण [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) और [IMathElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/) के प्रवाही मेथड्स का उपयोग करते हैं ताकि कोड छोटा और पठनीय रहे।

MathML निर्यात परिस्थितियों के लिए, देखें [Export Math Equations from Presentations in Python via .NET](/slides/hi/python-net/exporting-math-equations/)।

## **समीकरण बनाएं**

यह उदाहरण [add_math_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_math_shape/) का उपयोग करके एक गणितीय आकार बनाता है और पाइथागोरस प्रमेय को जोड़ता है:

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

[add_math_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_math_shape/) एक आकार बनाता है जिसमें पहले से ही एक गणितीय पैराग्राफ मौजूद होता है। पहले [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) को एक्सेस करें, उसका [math_paragraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/math_paragraph/) प्राप्त करें, और उसमें गणितीय ब्लॉक्स या घटक जोड़ें।

{{% /alert %}}

## **भिन्न जोड़ें**

[divide](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/divide/) का उपयोग करके एक भिन्न बनाएं। आप [MathFractionTypes](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfractiontypes/) के साथ भिन्न शैली चुन सकते हैं।

![एक झुका हुआ गणितीय भिन्न जिसमें एक को x से विभाजित दिखाया गया है](powerpoint-math-equations_4.png)

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

एक स्टैक्ड भिन्न के लिए, [MathFractionTypes.BAR](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfractiontypes/) का उपयोग करें:

```py
import aspose.slides.mathtext as math

stacked_fraction = math.MathematicalText("x + 1").divide("y - 1", math.MathFractionTypes.BAR)
```

## **मूल जोड़ें**

[radical](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/radical/) का उपयोग करके वर्गमूल, घनमूल या अन्य मूल बनाएं। वर्तमान तत्व बेस बन जाता है, और आर्ग्यूमेंट डिग्री बन जाता है।

![एक n-थ मूल अभिव्यक्ति जिसमें x मूल चिह्न के नीचे है](powerpoint-math-equations_5.png)

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

[as_argument_of_function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/) या [function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/function/) का उपयोग करें फ़ंक्शन जैसे `sin(x)`, `log(x)`, या कस्टम फ़ंक्शन नामों के लिए। सीमाओं के लिए, `lim` को एक [MathLimit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathlimit/) में रखें या [set_lower_limit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_lower_limit/) का उपयोग करें।

![जब x अनंत की ओर जाता है तब x की सीमा](powerpoint-math-equations_8.png)

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

कस्टम फ़ंक्शन नाम के लिए, फ़ंक्शन नाम को वर्तमान तत्व बनाएं और उसके आर्ग्यूमेंट के साथ [function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/function/) को कॉल करें:

```py
import aspose.slides.mathtext as math

custom_function = math.MathematicalText("f").function("x + 1")
```

## **N-ary ऑपरेटर्स और इंटीग्रल जोड़ें**

[nary](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/nary/) का उपयोग करके योग, यूनियन, इंटरसेक्शन और अन्य बड़े ऑपरेटर्स बनाएं। इंटीग्रल के लिए [integral](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/integral/) का उपयोग करें। दोनों मेथड आपको निचली और ऊपरी सीमाएँ सेट करने देते हैं।

![एक योग जिसमें निचली और ऊपरी सीमाएँ हैं](powerpoint-math-equations_7.png)

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

N-ary ऑपरेटर्स बड़े ऑपरेटर्स के लिए होते हैं जिनमें वैकल्पिक सीमाएँ हो सकती हैं। सरल ऑपरेटर्स जैसे `+`, `-`, और `=` आमतौर पर [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) के रूप में जोड़े जाते हैं और अभिव्यक्ति में मिलाए जाते हैं।

इंटीग्रल के लिए, [integral](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/integral/) का उपयोग करें:

```py
import aspose.slides.mathtext as math

integral_base = math.MathematicalText("x").join(math.MathematicalText("dx").to_box())
integral = integral_base.integral(math.MathIntegralTypes.SIMPLE, "0", "1")
```

## **मैट्रिक्स जोड़ें**

पंक्तियों और स्तंभों के लिए [MathMatrix](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathmatrix/) का उपयोग करें। मैट्रिक्स डिफ़ॉल्ट रूप से ब्रैकेट नहीं शामिल करता, इसलिए जब आपको कोष्ठक, ब्रेस या ब्रैसेस चाहिए तो मैट्रिक्स को घेरें।

![एक दो-पंक्तियों वाला गणितीय मैट्रिक्स जिसमें एक खाली सेल है](powerpoint-math-equations_10.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 120)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    matrix = math.MathMatrix(2, 3)

    # एक मैट्रिक्स में अपने आप कोई कोष्ठक नहीं होते, इसलिए इसे कोष्ठकों में घेरें।
    math_paragraph.add(math.MathBlock(matrix.enclose("(", ")")))

    presentation.save("matrix.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="warning" title="Warning" %}}
`MathMatrix` पंक्तियों और स्तंभों की ग्रिड बनाता है, उनके बीच गैप सेट करता है, और स्तंभों को संरेखित करता है, लेकिन Aspose.Slides for Python via .NET व्यक्तिगत मैट्रिक्स सेल के लिए एक्सेसर नहीं प्रदान करता। कोड में बनाया गया मैट्रिक्स इसलिए खाली सेल रखता है; मौजूदा प्रस्तुति से प्राप्त मैट्रिक्स के सेल `get_children` से पढ़े जा सकते हैं। जब आपको कोड से पंक्तियों को भरना हो तो समीकरण एरे का उपयोग करें।
{{% /alert %}}

## **समीकरण एरे जोड़ें**

जब आपको संरेखित समीकरण या वर्टिकल स्टैक अभिव्यक्तियों की आवश्यकता हो, तो [to_math_array](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/to_math_array/) का उपयोग करें।

![एक वर्टिकल गणित एरे जिसमें x y के ऊपर है](powerpoint-math-equations_11.png)

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

## **त्रिकोणमितीय फ़ंक्शन जोड़ें**

जब आर्ग्यूमेंट वर्तमान तत्व हो और फ़ंक्शन नाम ज्ञात हो, तो [as_argument_of_function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/) का उपयोग करें।

![त्रिकोणमितीय फ़ंक्शन cos को 2x पर लागू किया गया](powerpoint-math-equations_6.png)

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

सबस्क्रिप्ट और सुपरस्क्रिप्ट हेल्पर का उपयोग करें ... जब इंडेक्स बेस के बाएँ पक्ष पर दिखने चाहिए, तो [set_sub_superscript_on_the_left](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_sub_superscript_on_the_left/) का उपयोग करें।

![एक बड़े अक्षर Y जिसमें बाएँ‑साइड सबस्क्रिप्ट 1 और सुपरस्क्रिप्ट n है](powerpoint-math-equations_9.png)

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

[enclose](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/enclose/) का उपयोग करके अभिव्यक्ति को डिलिमिटर के भीतर रखें। आप कई तत्वों वाले डिलिमिटर अभिव्यक्तियों के लिए एक separator character भी सेट कर सकते हैं।

![एक डिलिमिटर अभिव्यक्ति जिसमें x, y, और z को वर्टिकल बार द्वारा अलग किया गया है](powerpoint-math-equations_13.png)

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

[grow_to_match_operand_height](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathdelimiter/grow_to_match_operand_height/) को `True` सेट करें ताकि कोष्ठक ऊँचे ऑपरेण्ड के आसपास बढ़ सकें, या `False` सेट करें ताकि उनका सामान्य आकार बना रहे। [delimiter_shape](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathdelimiter/delimiter_shape/) दो में से एक [MathDelimiterShape](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathdelimitershape/) मान लेता है। `CENTERED` कोष्ठकों को गणितीय अक्ष पर केंद्रित करता है, जो बराबर चिह्न के मध्य से होकर गुजरती है। `MATCH` उन्हें enclosed सामग्री के साथ संरेखित करता है। दोनों सेटिंग्स केवल डिलिमिटर को प्रभावित करती हैं। अंदर की अभिव्यक्ति वही रहती है।

उदाहरण में `x` के एक्सपोनेंट में एक भिन्न रखा गया है ताकि अभिव्यक्ति बेसलाइन से ऊपर अधिक विस्तार करे। सभी चार समीकरण एक ही कोष्ठक और फ़ॉन्ट सेटिंग्स का उपयोग करते हैं।

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

PowerPoint में, वृद्धि प्रभाव देखने के लिए पंक्तियों की तुलना करें। शीर्ष पंक्ति में, कोष्ठक एक्सपोनेंट को घेरने के लिए बढ़ते हैं और दोनों आकारों में समान दिखते हैं। नीचे की पंक्ति में, वृद्धि बंद है। बाएँ कोष्ठक (`CENTERED`) बराबर चिन्ह के साथ संरेखित होते हैं, जबकि दाएँ (`MATCH`) अभिव्यक्ति के चारों ओर ऊँचे होते हैं।

![PowerPoint में चार समीकरण जहाँ डिलिमिटर वृद्धि ऊपर सक्षम है और नीचे अक्षम, बाएँ `CENTERED` और दाएँ `MATCH`](delimiter-sizing.png)

## **बॉर्डर बॉक्स जोड़ें**

भिन्न पर [to_border_box](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/to_border_box/) कॉल करके पूरी अभिव्यक्ति को फ्रेम करें। लौटाए गए [IMathBorderBox](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/) में डिफ़ॉल्ट रूप से चारों पक्ष दिखते हैं। व्यक्तिगत पक्ष हटाने के लिए [hide_top](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/hide_top/), [hide_bottom](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/hide_bottom/), [hide_left](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/hide_left/), और [hide_right](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/hide_right/) का उपयोग करें।

उदाहरण में एक स्लाइड पर समान भिन्न की छह प्रतियां रखी गई हैं। रद्द करने के दिखाने के लिए, सभी चार पक्ष छिपाएँ और एक उठते हुए तिरछे (↗) के लिए [strikethrough_bottom_left_to_top_right](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/strikethrough_bottom_left_to_top_right/), या गिरते हुए तिरछे (↘) के लिए [strikethrough_top_left_to_bottom_right](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/strikethrough_top_left_to_bottom_right/) सेट करें। आप किसी भी दिखाई देने वाले पक्ष के साथ [strikethrough_horizontal](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/strikethrough_horizontal/) या [strikethrough_vertical](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/strikethrough_vertical/) भी उपयोग कर सकते हैं।

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

![PowerPoint में छह संपादन योग्य भिन्न। शीर्ष पंक्ति: पूरी बॉर्डर, निचला और बायाँ पक्ष, उठती तिरछी रेखा। नीचे पंक्ति: गिरती तिरछी, क्षैतिज स्ट्राइक, ऊर्ध्विक स्ट्राइक पूरी बॉर्डर के साथ।](border-box-fractions.png)

इस भिन्न में, क्षैतिज स्ट्राइक भिन्न बार को ढकता है। ऊर्ध्विक स्ट्राइक अंश और हर दोनों को पार करता है जबकि आसपास की बॉर्डर दिखाई देती रहती है। ये रेखाएँ पूरी अभिव्यक्ति को सजाती हैं। सामान्य टेक्स्ट स्ट्राइकथ्रू केवल टेक्स्ट रन के अक्षरों पर लागू होता है। PowerPoint में प्रस्तुति को पुनः खोलने के बाद, आप अभी भी अंश और हर को स्वतंत्र रूप से संपादित कर सकते हैं।

## **शब्दों को समूहित करें**

[group](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/group/) का उपयोग करके अभिव्यक्ति के ऊपर या नीचे एक समूह चिन्ह रखें। समूहित शब्दों को लेबल करने के लिए एक सीमा जोड़ें।

![अभिव्यक्ति x + y को नीचे किसी भी टेक्स्ट लेबल के साथ समूहित किया गया](powerpoint-math-equations_15.png)

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

फ़ॉर्मेटिंग हेल्पर केवल तभी उपयोग करें जब वे सूत्र को स्पष्ट करें। उदाहरण के लिए, [overbar](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/overbar/) गणितीय तत्व के ऊपर एक बार रखता है।

![एक गणितीय अभिव्यक्ति ABC जिसमें एक ओवरबार है](powerpoint-math-equations_14.png)

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

मौजूदा समीकरण में पूरे टेक्स्ट को स्वरूपित करने के लिए, प्रत्येक गणित ब्लॉक की एलिमेंट ट्री को ट्रावर्स करें। [IMathElement.get_children](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/get_children/) केवल सीधे बच्चों को लौटाता है, इसलिए इसे पुनरावर्ती रूप से कॉल करें ताकि भिन्न, स्क्रिप्ट, मूल और अन्य नेस्टेड संरचनाओं के भीतर के टेक्स्ट तक पहुँच सकें। जब वर्तमान तत्व [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) हो, तो उसे और उसके बच्चों को चेक करें ताकि प्रारम्भिक तत्व भी शामिल हो।

यह उदाहरण मानता है कि `input.pptx` में एक समीकरण है जैसे `z = xᵢ / ∛y`, जिसमें अंश में अंश के अंशांश में सबस्क्रिप्ट और हर में मूल है। केवल ब्लॉक के टॉप‑लेवल तत्वों को प्रोसेस करने से भिन्न के भीतर का टेक्स्ट छूट जाएगा। उदाहरण स्लाइड टेक्स्ट फ्रेम में गणितीय हिस्से खोजता है, उनके ब्लॉक्स को [MathPortion.math_paragraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/math_paragraph/) के माध्यम से एक्सेस करता है, और प्रत्येक टेक्स्ट एलिमेंट की [format](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/format/) प्रॉपर्टी के माध्यम से [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/font_height/) को 28 पॉइंट सेट करता है।

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

सहेजा गया प्रस्तुतीकरण प्रत्येक प्रोसेस्ड समीकरण के हर स्तर पर अद्यतन टेक्स्ट फ़ॉर्मेटिंग रखता है, जबकि उसका टेक्स्ट कंटेंट और गणितीय संरचना बनी रहती है।

## **त्वरित संदर्भ**

| कार्य | मुख्य API |
| --- | --- |
| गणितीय टेक्स्ट बनाएं | [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) |
| तत्वों को मिलाएं | [IMathElement.join](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/join/) |
| भिन्न बनाएं | [IMathElement.divide](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/divide/) |
| सुपरस्क्रिप्ट या सबस्क्रिप्ट जोड़ें | [set_superscript](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_superscript/), [set_subscript](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_subscript/) |
| फ़ंक्शन जोड़ें | [function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/function/), [as_argument_of_function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/) |
| मूल जोड़ें | [radical](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/radical/) |
| सीमाएँ जोड़ें | [set_lower_limit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_lower_limit/), [set_upper_limit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_upper_limit/) |
| बाएँ‑साइड स्क्रिप्ट जोड़ें | [set_sub_superscript_on_the_left](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_sub_superscript_on_the_left/) |
| योग और इंटीग्रल जोड़ें | [nary](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/nary/), [integral](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/integral/) |
| मैट्रिक्स जोड़ें | [MathMatrix](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathmatrix/) |
| समीकरण एरे जोड़ें | [to_math_array](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/to_math_array/) |
| डिलिमिटर जोड़ें | [enclose](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/enclose/) |
| बार और बॉर्डर जोड़ें | [overbar](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/overbar/), [to_border_box](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/to_border_box/) |
| शब्दों को समूहित करें | [group](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/group/) |

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं मौजूदा PowerPoint समीकरण को संपादित कर सकता हूँ?**

हां। प्रस्तुतीकरण खोलें, वह आकार खोजें जिसमें एक [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) हो, उसका [math_paragraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/math_paragraph/) प्राप्त करें, और उस पैराग्राफ में गणितीय ब्लॉक्स को अपडेट करें।

**क्या समीकरण को संपादन योग्य PowerPoint गणित के रूप में सहेजा जाता है?**

हां। जब आप PPTX में सहेजते हैं, Aspose.Slides समीकरण को संपादन योग्य Office गणित सामग्री के रूप में लिखता है।

**क्या मैं समीकरणों को LaTeX में निर्यात कर सकता हूँ?**

हां। समीकरण के [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) को उसके [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) से प्राप्त करें, और सीधे निर्यात करने के लिए [MathParagraph.to_latex](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/to_latex/) को कॉल करें। पूर्ण उदाहरण के लिए, देखें [Export Math Equations from Presentations in Python via .NET](/slides/hi/python-net/exporting-math-equations/#export-math-equations-to-latex)।