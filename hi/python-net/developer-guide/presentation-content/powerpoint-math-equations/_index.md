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
- गणितीय पाठ
- गणितीय समीकरण जोड़ें
- गणितीय प्रतीक जोड़ें
- गणितीय सूत्र जोड़ें
- गणितीय पाठ जोड़ें
- PowerPoint
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET के साथ PowerPoint PPT और PPTX में गणितीय समीकरण डालना और संपादित करना, OMML का समर्थन, स्वरूपण नियंत्रण, और स्पष्ट Python कोड उदाहरण प्रदान करता है।"
---
## **अवलोकन**

PowerPoint समीकरणों को Office Math Markup Language (OMML) के रूप में संग्रहीत करता है। Aspose.Slides for Python via .NET के साथ, आप प्रोग्रामेटिक रूप से समान प्रकार की गणितीय सामग्री बना सकते हैं: भिन्न, मूल, फ़ंक्शन, सीमा, N-ary ऑपरेटर, मैट्रिक्स, ऐरे, और स्वरूपित गणित ब्लॉक।

PowerPoint में, उपयोगकर्ता सामान्यतः **Insert > Equation** से समीकरण जोड़ते हैं:

![PowerPoint Insert टैब जिसमें Equation कमांड चयनित है](powerpoint-math-equations_1.png)

परिणाम स्लाइड पर संपादन योग्य गणितीय पाठ है:

![एक PowerPoint स्लाइड जिसमें संपादन योग्य गणितीय समीकरण है](powerpoint-math-equations_2.png)

Aspose.Slides यह गणितीय पाठ तीन मुख्य वस्तुओं के माध्यम से बनाता है:

- एक गणितीय आकार, जिसे [add_math_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_math_shape/) द्वारा बनाया गया है, वह आकार है जो समीकरण को शामिल करता है।
- [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) आकार के टेक्स्ट फ्रेम के भीतर गणितीय सामग्री संग्रहीत करता है।
- [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) एक या अधिक [MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/) वस्तुओं को शामिल करता है।

नीचे के अधिकांश उदाहरण [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) और [IMathElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/) की प्रवाहशील विधियों का उपयोग करते हैं ताकि कोड संक्षिप्त और पठनीय रहे।

MathML निर्यात परिदृश्यों के लिए, देखें [Python के माध्यम से .NET में प्रस्तुतियों से गणितीय समीकरणों को निर्यात करें](/slides/hi/python-net/exporting-math-equations/)।

## **समीकरण बनाएँ**

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
[add_math_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_math_shape/) एक आकार बनाता है जिसमें पहले से ही एक गणितीय पैराग्राफ होता है। पहले [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) तक पहुंचें, उसका [math_paragraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/math_paragraph/) प्राप्त करें, और उसमें गणितीय ब्लॉक्स या गणितीय तत्व जोड़ें।
{{% /alert %}}

## **भिन्न जोड़ें**

[divide](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/divide/) का उपयोग करके भिन्न बनाएँ। आप [MathFractionTypes](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfractiontypes/) के साथ भिन्न शैली चुन सकते हैं।

![एक तिरछा गणितीय भिन्न जो एक को x से विभाजित दर्शाता है](powerpoint-math-equations_4.png)

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

स्टैक्ड भिन्न के लिए, [MathFractionTypes.BAR](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfractiontypes/) का उपयोग करें:

```py
import aspose.slides.mathtext as math

stacked_fraction = math.MathematicalText("x + 1").divide("y - 1", math.MathFractionTypes.BAR)
```

## **मूल जोड़ें**

[radical](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/radical/) का उपयोग करके वर्ग मूल, घन मूल, या अन्य मूल बनाएँ। वर्तमान तत्व आधार बन जाता है, और तर्क डिग्री बन जाता है।

![एक n-वें मूल का अभिव्यक्ति जिसमें x मूल चिह्न के नीचे है](powerpoint-math-equations_5.png)

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

[as_argument_of_function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/) या [function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/function/) का उपयोग उन फ़ंक्शनों के लिए करें जैसे `sin(x)`, `log(x)`, या कस्टम फ़ंक्शन नाम। सीमाओं के लिए, `lim` को एक [MathLimit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathlimit/) में रखें या [set_lower_limit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_lower_limit/) का प्रयोग करें।

![x की सीमा जब x अनंत की ओर बढ़ता है](powerpoint-math-equations_8.png)

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

सम (summations), संघ (unions), प्रतिच्छेद (intersections), और अन्य बड़े ऑपरेटरों के लिए [nary](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/nary/) का उपयोग करें। इंटीग्रल के लिए [integral](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/integral/) का उपयोग करें। दोनों विधियाँ आपको निचली और ऊपरी सीमाएँ निर्धारित करने देती हैं।

![निचली और ऊपरी सीमाओं के साथ एक समेशन](powerpoint-math-equations_7.png)

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

N-ary ऑपरेटर बड़े ऑपरेटरों के लिए होते हैं जिनमें वैकल्पिक सीमाएँ हो सकती हैं। सरल ऑपरेटर जैसे `+`, `-`, और `=` आमतौर पर [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) के रूप में जोड़े जाते हैं और अभिव्यक्ति में सम्मिलित होते हैं।

इंटीग्रल के लिए, [integral](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/integral/) का उपयोग करें:

```py
import aspose.slides.mathtext as math

integral_base = math.MathematicalText("x").join(math.MathematicalText("dx").to_box())
integral = integral_base.integral(math.MathIntegralTypes.SIMPLE, "0", "1")
```

## **मैट्रिक्स जोड़ें**

पंक्तियों और स्तंभों के लिए [MathMatrix](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathmatrix/) का उपयोग करें। मैट्रिक्स डिफ़ॉल्ट रूप से वर्ग कोष्ठक शामिल नहीं करते, इसलिए यदि आपको गोल कोष्ठक, वर्ग कोष्ठक, या कर्ली ब्रेसेस की आवश्यकता हो तो मैट्रिक्स को घेरें।

![एक दो-पंक्तियों वाला गणितीय मैट्रिक्स जिसमें एक खाली सेल है](powerpoint-math-equations_10.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 120)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    matrix = math.MathMatrix(2, 3)

    # एक मैट्रिक्स में अपने आप कोई कोष्ठक नहीं होते, इसलिए इसे पारेंथिसिस में घेरें।
    math_paragraph.add(math.MathBlock(matrix.enclose("(", ")")))

    presentation.save("matrix.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="warning" title="Warning" %}}
`MathMatrix` पंक्तियों और स्तंभों का ग्रिड बनाता है, उनके बीच के अंतर को सेट करता है, और स्तंभों को संरेखित करता है, लेकिन Aspose.Slides for Python via .NET व्यक्तिगत मैट्रिक्स सेल के लिए कोई एक्सेसर प्रदान नहीं करता। कोड में बनाया गया मैट्रिक्स इसलिए खाली सेल रखता है; मौजूदा प्रस्तुति से आया मैट्रिक्स के सेल को `get_children` से पढ़ा जा सकता है। जब आपको कोड से पंक्तियों को भरना हो तो समीकरण ऐरे का उपयोग करें।
{{% /alert %}}

## **समीकरण एरे जोड़ें**

[to_math_array](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/to_math_array/) का उपयोग तब करें जब आपको संरेखित समीकरण या अभिव्यक्तियों का लंबवत स्टैक चाहिए।

![एक लंबवत गणितीय एरे जिसमें x y के ऊपर है](powerpoint-math-equations_11.png)

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

[as_argument_of_function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/) का उपयोग तब करें जब तर्क वर्तमान तत्व हो और फ़ंक्शन नाम ज्ञात हो।

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

## **सबस्क्रिप्ट और सुपर्सक्रिप्ट जोड़ें**

सूचकांक और घात के लिए सबस्क्रिप्ट और सुपर्सक्रिप्ट सहायक का उपयोग करें। जब सूचकांक को आधार के बाएँ पक्ष पर प्रदर्शित करना हो, तो [set_sub_superscript_on_the_left](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_sub_superscript_on_the_left/) का उपयोग करें।

![एक बड़ा Y जिसका बाएँ‑पार्श्वीय सबस्क्रिप्ट 1 और सुपर्सक्रिप्ट n है](powerpoint-math-equations_9.png)

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

एक अभिव्यक्ति को डिलिमिटर में रखने के लिए [enclose](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/enclose/) का उपयोग करें। आप कई तत्वों वाली डिलिमिटर अभिव्यक्तियों के लिए एक विभाजक अक्षर भी सेट कर सकते हैं।

![एक डिलिमिटर अभिव्यक्ति जिसमें x, y, और z ऊर्ध्वाधर बार द्वारा अलग किए गए हैं](powerpoint-math-equations_13.png)

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

परंथेसिस को एक ऊँचे ऑपरेण्ड के चारों ओर बढ़ने देने के लिए [grow_to_match_operand_height](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathdelimiter/grow_to_match_operand_height/) को `True` सेट करें, या सामान्य आकार रखने के लिए `False` सेट करें। [delimiter_shape](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathdelimiter/delimiter_shape/) दो में से एक [MathDelimiterShape](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathdelimitershape/) मान लेता है। `CENTERED` परन्‍थेसिस को गणितीय अक्ष पर केंद्रित करता है, जो बराबर संकेत के मध्य से होकर जाता है। `MATCH` उन्हें सम्मिलित सामग्री के साथ संरेखित करता है। दोनों सेटिंग केवल डिलिमिटर को प्रभावित करती हैं। अंदर की अभिव्यक्ति समान रहती है।

उदाहरण में `x` की घात में एक भिन्न रखा गया है ताकि अभिव्यक्ति बेसलाइन के ऊपर अधिक विस्तारित हो बनिस्बत नीचे के। सभी चार समीकरण एक ही परन्‍थेसिस और फ़ॉन्ट सेटिंग्स का उपयोग करते हैं।

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

PowerPoint में, पंक्तियों की तुलना करके वृद्धि का प्रभाव देखें। शीर्ष पंक्ति में, परन्‍थेसिस घात को घेरने के लिए बढ़ते हैं और दोनों आकारों में समान दिखते हैं। नीचे की पंक्ति में, वृद्धि बंद है। बाएँ तरफ छोटा परन्‍थेसिस (`CENTERED`) बराबर संकेत के साथ संरेखित होता है, जबकि दाएँ (`MATCH`) अभिव्यक्ति के ऊपर अधिक स्थित होता है।

![PowerPoint में चार समीकरण जिनमें डिलिमिटर वृद्धि ऊपर सक्षम और नीचे अक्षम है, बाएँ ओर Centered और दाएँ ओर Match](delimiter-sizing.png)

## **बॉर्डर बॉक्स जोड़ें**

[to_border_box](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/to_border_box/) का उपयोग तब करें जब स्वयं समीकरण को फ्रेम किया जाना चाहिए।

![एक बॉक्स वाला समीकरण जिसमें a वर्ग बराबर b वर्ग प्लस c वर्ग दिखाया गया है](powerpoint-math-equations_12.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 100)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    boxed_equation = (
        math.MathematicalText("a")
        .set_superscript("2")
        .join("=")
        .join(math.MathematicalText("b").set_superscript("2"))
        .join("+")
        .join(math.MathematicalText("c").set_superscript("2"))
        .to_border_box()
    )

    math_paragraph.add(math.MathBlock(boxed_equation))

    presentation.save("border-box.pptx", slides.export.SaveFormat.PPTX)
```

## **टर्म्स को समूहित करें**

[group](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/group/) का उपयोग करके अभिव्यक्ति के ऊपर या नीचे एक समूहित चरित्र रखें। समूहित टर्म्स को लेबल करने के लिए एक सीमा जोड़ें।

![अभिव्यक्ति x + y को समूहित किया गया है, जिसके नीचे कोई भी टेक्स्ट लेबल है](powerpoint-math-equations_15.png)

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

स्वरूपण सहायक का उपयोग केवल तब करें जब वे सूत्र को स्पष्ट करते हों। उदाहरण के लिए, [overbar](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/overbar/) गणितीय तत्व के ऊपर एक बार रखता है।

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

### **मौजूदा समीकरण में पाठ का स्वरूपण**

एक मौजूदा समीकरण में पूरे पाठ को स्वरूपित करने के लिए, प्रत्येक गणित ब्लॉक के तत्व वृक्ष को पार करें। [IMathElement.get_children](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/get_children/) केवल तत्काल चाइल्ड लौटाता है, इसलिए भिन्नों, स्क्रिप्ट, मूल और अन्य नेस्टेड संरचनाओं के भीतर के पाठ तक पहुंचने के लिए इसे पुनरावर्तित रूप से कॉल करें। वर्तमान तत्व और उसके चाइल्ड दोनों की जांच करें ताकि यदि वह [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) है तो प्रारंभिक तत्व भी शामिल हो।

यह उदाहरण मानता है कि `input.pptx` में एक समीकरण है जैसे `z = xᵢ / ∛y`, जिसमें अंश में अंशांक में सबस्क्रिप्ट और हर में मूल शामिल है। केवल ब्लॉक के टॉप‑लेवल तत्वों को प्रोसेस करने से भिन्न के भीतर का पाठ छूट जाएगा। यह उदाहरण स्लाइड टेक्स्ट फ्रेम में गणितीय भागों को खोजता है, उनके ब्लॉक को [MathPortion.math_paragraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/math_paragraph/) के माध्यम से एक्सेस करता है, और प्रत्येक टेक्स्ट तत्व के [format](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/format/) प्रॉपर्टी के माध्यम से [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/font_height/) को 28 पॉइंट सेट करता है।

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

सहेजा गया प्रस्तुतीकरण प्रत्येक प्रोसेस किए गए समीकरण के हर स्तर पर अद्यतन टेक्स्ट स्वरूपण रखता है, जबकि इसकी टेक्स्ट सामग्री और गणितीय संरचना को बना रहता है।

## **त्वरित संदर्भ**

| Task | Main API |
| --- | --- |
| गणितीय पाठ बनाएँ | [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) |
| तत्वों को संयोजित करें | [IMathElement.join](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/join/) |
| भिन्न बनाएँ | [IMathElement.divide](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/divide/) |
| सुपर्सक्रिप्ट या सबस्क्रिप्ट जोड़ें | [set_superscript](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_superscript/), [set_subscript](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_subscript/) |
| फ़ंक्शन जोड़ें | [function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/function/), [as_argument_of_function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/) |
| मूल जोड़ें | [radical](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/radical/) |
| सीमाएँ जोड़ें | [set_lower_limit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_lower_limit/), [set_upper_limit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_upper_limit/) |
| बाएँ‑पार्श्वीय स्क्रिप्ट जोड़ें | [set_sub_superscript_on_the_left](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_sub_superscript_on_the_left/) |
| समेशन और इंटीग्रल जोड़ें | [nary](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/nary/), [integral](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/integral/) |
| मैट्रिक्स जोड़ें | [MathMatrix](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathmatrix/) |
| समीकरण एरे जोड़ें | [to_math_array](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/to_math_array/) |
| डिलिमिटर जोड़ें | [enclose](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/enclose/) |
| बार और बॉर्डर जोड़ें | [overbar](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/overbar/), [to_border_box](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/to_border_box/) |
| टर्म्स को समूहित करें | [group](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/group/) |

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं मौजूदा PowerPoint समीकरण को संपादित कर सकता हूँ?**

हाँ। प्रस्तुतीकरण खोलें, वह आकार खोजें जिसमें [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) शामिल है, उसका [math_paragraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/math_paragraph/) प्राप्त करें, और उस पैराग्राफ में गणितीय ब्लॉक्स को अपडेट करें।

**क्या समीकरण संपादन योग्य PowerPoint गणित के रूप में संचित होते हैं?**

हाँ। जब आप PPTX में सहेजते हैं, Aspose.Slides समीकरण को संपादन योग्य Office गणित सामग्री के रूप में लिखता है।

**क्या मैं समीकरणों को LaTeX में निर्यात कर सकता हूँ?**

हाँ। समीकरण के [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) को उसके [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) से प्राप्त करें, और सीधे निर्यात करने के लिए [MathParagraph.to_latex](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/to_latex/) को कॉल करें। पूर्ण उदाहरण के लिए देखें [Python के माध्यम से .NET में प्रस्तुतियों से गणितीय समीकरणों को निर्यात करें](/slides/hi/python-net/exporting-math-equations/#export-math-equations-to-latex).