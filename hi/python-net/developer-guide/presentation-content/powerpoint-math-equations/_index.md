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
description: "Python के लिए Aspose.Slides via .NET के साथ PowerPoint PPT और PPTX में गणितीय समीकरण जोड़ें और संपादित करें, OMML का समर्थन, स्वरूपण नियंत्रण, और स्पष्ट Python कोड उदाहरण प्रदान करता है।"
---
## **अवलोकन**

PowerPoint समीकरणों को Office Math Markup Language (OMML) के रूप में संग्रहित करता है। Aspose.Slides for Python via .NET के साथ, आप प्रोग्रामेटिक रूप से समान प्रकार की गणितीय सामग्री बना सकते हैं: भिन्न, मूल, फ़ंक्शन, सीमाएँ, N-ary ऑपरेटर, मैट्रिक्स, ऐरे, और स्वरूपित गणितीय ब्लॉक।

PowerPoint में, उपयोगकर्ता सामान्यतः **Insert > Equation** से समीकरण जोड़ते हैं:

![PowerPoint Insert टैब जिसमें Equation कमांड चयनित है](powerpoint-math-equations_1.png)

परिणाम स्लाइड पर संपादन योग्य गणितीय पाठ है:

![एक PowerPoint स्लाइड जिसमें संपादन योग्य गणितीय समीकरण है](powerpoint-math-equations_2.png)

Aspose.Slides इस गणितीय पाठ को तीन मुख्य वस्तुओं के माध्यम से बनाता है:

- एक गणितीय आकार, जो [add_math_shape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/shapecollection/add_math_shape/) के साथ बनाया गया है, वह आकार है जो समीकरण रखता है।
- [MathPortion](https://reference.aspose.com/slides/hi/python-net/aspose.slides.mathtext/mathportion/) आकार के टेक्स्ट फ़्रेम के भीतर गणितीय सामग्री संग्रहीत करता है।
- [MathParagraph](https://reference.aspose.com/slides/hi/python-net/aspose.slides.mathtext/mathparagraph/) एक या अधिक [MathBlock](https://reference.aspose.com/slides/hi/python-net/aspose.slides.mathtext/mathblock/) वस्तुओं को समाहित करता है।

नीचे अधिकांश उदाहरण [MathematicalText](https://reference.aspose.com/slides/hi/python-net/aspose.slides.mathtext/mathematicaltext/) और [IMathElement](https://reference.aspose.com/slides/hi/python-net/aspose.slides.mathtext/imathelement/) की fluent विधियों का उपयोग करके कोड को छोटा और पठनीय रखते हैं।

MathML निर्यात परिदृश्यों के लिए, देखें [Export Math Equations from Presentations in Python via .NET](/slides/hi/python-net/exporting-math-equations/)।

## **एक समीकरण बनाएं**

यह उदाहरण एक गणितीय आकार बनाता है और पाइथागोरस प्रमेय जोड़ता है:

![c वर्ग बराबर a वर्ग प्लस b वर्ग](powerpoint-math-equations_3.png)

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

{{% alert color="primary" %}}
`add_math_shape` एक ऐसा आकार बनाता है जिसमें पहले से ही एक गणितीय पैराग्राफ होता है। पहले `MathPortion` को एक्सेस करें, उसका `MathParagraph` प्राप्त करें, और उसमें गणितीय ब्लॉक्स या गणितीय तत्व जोड़ें।
{{% /alert %}}

## **भिन्न जोड़ें**

एक भिन्न बनाने के लिए [`divide`](https://reference.aspose.com/slides/hi/python-net/aspose.slides.mathtext/imathelement/divide/) का प्रयोग करें। आप भिन्न शैली को [MathFractionTypes](https://reference.aspose.com/slides/hi/python-net/aspose.slides.mathtext/mathfractiontypes/) से चुन सकते हैं।

![एक तिरछा गणितीय भिन्न जिसमें 1 को x से विभाजित दिखाया गया है](powerpoint-math-equations_4.png)

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

स्टैक्ड भिन्न के लिए, `MathFractionTypes.BAR` का उपयोग करें:

```py
stacked_fraction = math.MathematicalText("x + 1").divide("y - 1", math.MathFractionTypes.BAR)
```

## **मूल जोड़ें**

एक वर्गमूल, घनमूल या अन्य मूल बनाने के लिए [`radical`](https://reference.aspose.com/slides/hi/python-net/aspose.slides.mathtext/imathelement/radical/) का प्रयोग करें। वर्तमान तत्व आधार बन जाता है, और तर्क डिग्री बन जाता है।

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

फ़ंक्शन जैसे `sin(x)`, `log(x)` या कस्टम फ़ंक्शन नामों के लिए [`as_argument_of_function`](https://reference.aspose.com/slides/hi/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/) या [`function`](https://reference.aspose.com/slides/hi/python-net/aspose.slides.mathtext/imathelement/function/) का उपयोग करें। सीमाओं के लिए, `lim` को एक [MathLimit](https://reference.aspose.com/slides/hi/python-net/aspose.slides.mathtext/mathlimit/) में रखें या [`set_lower_limit`](https://reference.aspose.com/slides/hi/python-net/aspose.slides.mathtext/imathelement/set_lower_limit/) का उपयोग करें।

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

कस्टम फ़ंक्शन नाम के लिए, फ़ंक्शन नाम को वर्तमान तत्व बनाएं:

```py
custom_function = math.MathematicalText("f").function("x + 1")
```

## **N-ary ऑपरेटर और इंटीग्रल जोड़ें**

योग, संघ, प्रतिच्छेदन और अन्य बड़े ऑपरेटरों के लिए [`nary`](https://reference.aspose.com/slides/hi/python-net/aspose.slides.mathtext/imathelement/nary/) का प्रयोग करें। इंटीग्रल के लिए [`integral`](https://reference.aspose.com/slides/hi/python-net/aspose.slides.mathtext/imathelement/integral/) का उपयोग करें। दोनों विधियाँ आपको नीचे और ऊपर सीमाएँ निर्धारित करने देती हैं।

![नीचे और ऊपर सीमाओं के साथ एक योग](powerpoint-math-equations_7.png)

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

N-ary ऑपरेटर बड़े ऑपरेटरों के लिए होते हैं जिनमें वैकल्पिक सीमाएँ हो सकती हैं। `+`, `-`, और `=` जैसे सरल ऑपरेटर आमतौर पर `MathematicalText` के रूप में जोड़े जाते हैं और अभिव्यक्ति में सम्मिलित होते हैं।

इंटीग्रल के लिए, `integral` का उपयोग करें:

```py
integral_base = math.MathematicalText("x").join(math.MathematicalText("dx").to_box())
integral = integral_base.integral(math.MathIntegralTypes.SIMPLE, "0", "1")
```

## **मैट्रिक्स जोड़ें**

पंक्तियों और स्तम्भों के लिए [MathMatrix](https://reference.aspose.com/slides/hi/python-net/aspose.slides.mathtext/mathmatrix/) का प्रयोग करें। मैट्रिक्स में डिफ़ॉल्ट रूप से कोष्ठक नहीं होते, इसलिए जब कोष्ठक, ब्रैकेट या कर्ली ब्रेसेस चाहिए हों तो मैट्रिक्स को घेरें।

![दो पंक्तियों वाला गणितीय मैट्रिक्स जिसमें एक खाली कोशिका है](powerpoint-math-equations_10.png)

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

## **समीकरण ऐरे जोड़ें**

निर्देशित समीकरणों या अभिव्यक्तियों के लम्बवत स्टैक की आवश्यकता होने पर [`to_math_array`](https://reference.aspose.com/slides/hi/python-net/aspose.slides.mathtext/imathelement/to_math_array/) का प्रयोग करें।

![एक लम्बवत गणितीय ऐरे जिसमें x y के ऊपर है](powerpoint-math-equations_11.png)

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

जब तर्क वर्तमान तत्व है और फ़ंक्शन नाम ज्ञात है, तो [`as_argument_of_function`](https://reference.aspose.com/slides/hi/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/) का उपयोग करें।

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

सूचकांक और घात के लिए सबस्क्रिप्ट और सुपर्सक्रिप्ट सहायक विधियों का प्रयोग करें। जब सूचकांक को आधार के बाएँ पक्ष पर दिखाना हो, तो [`set_sub_superscript_on_the_left`](https://reference.aspose.com/slides/hi/python-net/aspose.slides.mathtext/imathelement/set_sub_superscript_on_the_left/) का प्रयोग करें।

![एक बड़े अक्षर Y जिसमें बाएँ ओर सबस्क्रिप्ट 1 और सुपर्सक्रिप्ट n है](powerpoint-math-equations_9.png)

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

एक अभिव्यक्ति को डिलिमिटर के अंदर रखने के लिए [`enclose`](https://reference.aspose.com/slides/hi/python-net/aspose.slides.mathtext/imathelement/enclose/) का प्रयोग करें। आप कई तत्वों वाली डिलिमिटर अभिव्यक्तियों के लिए एक विभाजन वर्ण भी निर्धारित कर सकते हैं।

![एक डिलिमिटर अभिव्यक्ति जिसमें x, y, और z लम्बवत बार द्वारा अलग किए गए हैं](powerpoint-math-equations_13.png)

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

## **बॉर्डर बॉक्स जोड़ें**

जब स्वयं समीकरण को फ्रेम किया जाना हो, तो [`to_border_box`](https://reference.aspose.com/slides/hi/python-net/aspose.slides.mathtext/imathelement/to_border_box/) का प्रयोग करें।

![एक बॉक्स्ड समीकरण जिसमें a वर्ग बराबर b वर्ग प्लस c वर्ग दिखाया गया है](powerpoint-math-equations_12.png)

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

## **शब्दों को समूहित करें**

एक अभिव्यक्ति के ऊपर या नीचे समूहित करने वाला अक्षर रखने के लिए [`group`](https://reference.aspose.com/slides/hi/python-net/aspose.slides.mathtext/imathelement/group/) का प्रयोग करें। समूहित शब्दों को लेबल करने के लिए एक सीमा जोड़ें।

![x प्लस y अभिव्यक्ति को समूहित करके उसके नीचे लेबल any text के साथ](powerpoint-math-equations_15.png)

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

फ़ॉर्मेटिंग सहायक केवल तब उपयोग करें जब वे सूत्र को स्पष्ट करें। उदाहरण के लिए, [`overbar`](https://reference.aspose.com/slides/hi/python-net/aspose.slides.mathtext/imathelement/overbar/) गणितीय तत्व के ऊपर एक बार लगाता है।

![एक गणितीय अभिव्यक्ति ABC जिसके ऊपर एक ओवरबार है](powerpoint-math-equations_14.png)

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

## **त्वरित संदर्भ**

| कार्य | मुख्य API |
| --- | --- |
| गणितीय पाठ बनाएं | [MathematicalText](https://reference.aspose.com/slides/hi/python-net/aspose.slides.mathtext/mathematicaltext/) |
| तत्वों को मिलाएं | [IMathElement.join](https://reference.aspose.com/slides/hi/python-net/aspose.slides.mathtext/imathelement/join/) |
| भिन्न बनाएं | [IMathElement.divide](https://reference.aspose.com/slides/hi/python-net/aspose.slides.mathtext/imathelement/divide/) |
| सुपरस्क्रिप्ट या सबस्क्रिप्ट जोड़ें | [set_superscript](https://reference.aspose.com/slides/hi/python-net/aspose.slides.mathtext/imathelement/set_superscript/), [set_subscript](https://reference.aspose.com/slides/hi/python-net/aspose.slides.mathtext/imathelement/set_subscript/) |
| फ़ंक्शन जोड़ें | [function](https://reference.aspose.com/slides/hi/python-net/aspose.slides.mathtext/imathelement/function/), [as_argument_of_function](https://reference.aspose.com/slides/hi/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/) |
| मूल जोड़ें | [radical](https://reference.aspose.com/slides/hi/python-net/aspose.slides.mathtext/imathelement/radical/) |
| सीमाएँ जोड़ें | [set_lower_limit](https://reference.aspose.com/slides/hi/python-net/aspose.slides.mathtext/imathelement/set_lower_limit/), [set_upper_limit](https://reference.aspose.com/slides/hi/python-net/aspose.slides.mathtext/imathelement/set_upper_limit/) |
| बाएँ‑साइड स्क्रिप्ट जोड़ें | [set_sub_superscript_on_the_left](https://reference.aspose.com/slides/hi/python-net/aspose.slides.mathtext/imathelement/set_sub_superscript_on_the_left/) |
| योग और इंटीग्रल जोड़ें | [nary](https://reference.aspose.com/slides/hi/python-net/aspose.slides.mathtext/imathelement/nary/), [integral](https://reference.aspose.com/slides/hi/python-net/aspose.slides.mathtext/imathelement/integral/) |
| मैट्रिक्स जोड़ें | [MathMatrix](https://reference.aspose.com/slides/hi/python-net/aspose.slides.mathtext/mathmatrix/) |
| समीकरण ऐरे जोड़ें | [to_math_array](https://reference.aspose.com/slides/hi/python-net/aspose.slides.mathtext/imathelement/to_math_array/) |
| डिलिमिटर जोड़ें | [enclose](https://reference.aspose.com/slides/hi/python-net/aspose.slides.mathtext/imathelement/enclose/) |
| बार और बॉर्डर जोड़ें | [overbar](https://reference.aspose.com/slides/hi/python-net/aspose.slides.mathtext/imathelement/overbar/), [to_border_box](https://reference.aspose.com/slides/hi/python-net/aspose.slides.mathtext/imathelement/to_border_box/) |
| शब्दों को समूहित करें | [group](https://reference.aspose.com/slides/hi/python-net/aspose.slides.mathtext/imathelement/group/) |

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं मौजूदा PowerPoint समीकरण को संपादित कर सकता हूँ?**

हाँ। प्रस्तुति खोलें, वह आकार खोजें जिसमें `MathPortion` है, उसका `MathParagraph` प्राप्त करें, और उस पैराग्राफ में गणितीय ब्लॉक्स को अपडेट करें।

**क्या समीकरण संपादन योग्य PowerPoint गणित के रूप में सहेजे जाते हैं?**

हाँ। PPTX में सहेजते समय, Aspose.Slides समीकरण को संपादन योग्य Office गणित सामग्री के रूप में लिखता है।

**क्या मैं समीकरणों को LaTeX में निर्यात कर सकता हूँ?**

Aspose.Slides गणितीय समीकरणों को MathML में निर्यात करता है। यदि आपको LaTeX चाहिए, तो पहले MathML में निर्यात करें और फिर उस MathML को ऐसे टूल के साथ परिवर्तित करें जो आपके लक्ष्य LaTeX संस्करण का समर्थन करता हो।