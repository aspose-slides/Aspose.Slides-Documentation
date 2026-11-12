---
title: PowerPoint प्रस्तुतियों में Python के साथ गणित समीकरण जोड़ें
linktitle: PowerPoint गणित समीकरण
type: docs
weight: 80
url: /hi/python-java/powerpoint-math-equations/
keywords:
- गणित समीकरण
- गणित चिह्न
- गणित सूत्र
- गणित पाठ
- गणित समीकरण जोड़ें
- गणित चिह्न जोड़ें
- गणित सूत्र जोड़ें
- गणित पाठ जोड़ें
- PowerPoint
- प्रस्तुति
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java के साथ PowerPoint PPT और PPTX में गणित समीकरण सम्मिलित और संपादित करें, OMML समर्थन, स्वरूपण नियंत्रण, और स्पष्ट Python कोड नमूने प्रदान करता है।"
---
## **अवलोकन**

PowerPoint समीकरणों को Office Math Markup Language (OMML) के रूप में संग्रहीत करता है। Aspose.Slides for Python via Java के साथ, आप प्रोग्रामेटिक रूप से वही प्रकार की गणित सामग्री बना सकते हैं: अंश, मूल, फ़ंक्शन, सीमाएँ, N-ary ऑपरेटर, मैट्रिक्स, एरे, और स्वरूपित गणित ब्लॉक।

PowerPoint में, उपयोगकर्ता सामान्यतः **Insert > Equation** से समीकरण जोड़ते हैं:

![PowerPoint इंसर्ट टैब जिसमें Equation कमांड चयनित है](powerpoint-math-equations_1.png)

परिणाम स्लाइड पर संपादन योग्य गणित टेक्स्ट होता है:

![एक PowerPoint स्लाइड जिसमें संपादन योग्य गणित समीकरण है](powerpoint-math-equations_2.png)

Aspose.Slides इस गणित टेक्स्ट को तीन मुख्य वस्तुओं के माध्यम से बनाता है:

- एक गणित आकार, जिसे [addMathShape](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addMathShape) से बनाया जाता है, वह आकार है जिसमें समीकरण होता है।
- [MathPortion](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/) आकार के टेक्स्ट फ्रेम में गणित सामग्री संग्रहीत करता है।
- [MathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathparagraph/) एक या अधिक [MathBlock](https://reference.aspose.com/slides/python-java/aspose.slides/mathblock/) वस्तुओं को शामिल करता है।

नीचे के अधिकांश उदाहरण [MathematicalText](https://reference.aspose.com/slides/python-java/aspose.slides/mathematicaltext/) और [MathElementBase](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/) की फ्लुएंट विधियों का उपयोग करके कोड को छोटा और पठनीय रखते हैं।

MathML निर्यात परिदृश्यों के लिए देखें [Export Math Equations from Presentations in Python](/slides/hi/python-java/exporting-math-equations/)।

## **समीकरण बनाएं**

यह उदाहरण [addMathShape](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addMathShape) का उपयोग करके एक गणित आकार बनाता है और पायथागोरस प्रमेय जोड़ता है:

![c वर्ग बराबर a वर्ग प्लस b वर्ग समीकरण](powerpoint-math-equations_3.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    math_shape = slide.getShapes().addMathShape(20, 20, 700, 120)
    math_paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph()

    a_squared = MathematicalText("a").setSuperscript("2")
    b_squared = MathematicalText("b").setSuperscript("2")
    equation = MathematicalText("c").setSuperscript("2").join("=").join(a_squared).join("+").join(b_squared)

    math_paragraph.add(equation)

    presentation.save("pythagorean-theorem.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
[addMathShape](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addMathShape) एक ऐसा आकार बनाता है जिसमें पहले से ही एक गणित पैराग्राफ होता है। पहले [MathPortion](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/) तक पहुँचें, [getMathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/#getMathParagraph) को कॉल करें, और उसमें गणित ब्लॉक या गणित तत्व जोड़ें।
{{% /alert %}}

## **अंश जोड़ें**

[divide](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#divide) का उपयोग करके आप एक अंश बना सकते हैं। आप [MathFractionTypes](https://reference.aspose.com/slides/python-java/aspose.slides/mathfractiontypes/) के साथ अंश शैली चुन सकते हैं।

![एक तिरछा गणित अंश जो एक को x से विभाजित दिखाता है](powerpoint-math-equations_4.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathFractionTypes, MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    math_shape = slide.getShapes().addMathShape(20, 20, 700, 100)
    math_paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph()

    fraction = MathematicalText("1").divide("x", MathFractionTypes.Skewed)

    math_block = MathBlock(fraction)
    math_paragraph.add(math_block)

    presentation.save("fraction.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

स्टैक्ड अंश के लिए, उपयोग करें [MathFractionTypes.Bar](https://reference.aspose.com/slides/python-java/aspose.slides/mathfractiontypes/#Bar):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathFractionTypes, MathematicalText

stacked_fraction = MathematicalText("x + 1").divide("y - 1", MathFractionTypes.Bar)
```

## **मूल जोड़ें**

[radical](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#radical) का उपयोग करके आप वर्गमूल, घनमूल या अन्य मूल बना सकते हैं। वर्तमान तत्व आधार बन जाता है, और तर्क डिग्री बन जाता है।

![एक n‑th मूल अभिव्यक्ति जिसमें x मूल चिह्न के नीचे है](powerpoint-math-equations_5.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    math_shape = slide.getShapes().addMathShape(20, 20, 700, 100)
    math_paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph()

    radical = MathematicalText("x").radical("n")

    math_block = MathBlock(radical)
    math_paragraph.add(math_block)

    presentation.save("radical.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **फ़ंक्शन और सीमाएँ जोड़ें**

फ़ंक्शन के लिए [asArgumentOfFunction](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#asArgumentOfFunction) या [function](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#function) का उपयोग करें, जैसे `sin(x)`, `log(x)`, या कस्टम फ़ंक्शन नाम। सीमाओं के लिए, `lim` को एक [MathLimit](https://reference.aspose.com/slides/python-java/aspose.slides/mathlimit/) में रखें या [setLowerLimit](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setLowerLimit) का उपयोग करें।

![x का सीमा जब x अनंत की ओर जाता है](powerpoint-math-equations_8.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    math_shape = slide.getShapes().addMathShape(20, 20, 700, 100)
    math_paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph()

    limit = MathematicalText("lim").setLowerLimit("x\u2192\u221E").function("x")

    math_block = MathBlock(limit)
    math_paragraph.add(math_block)

    presentation.save("functions-and-limits.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

कस्टम फ़ंक्शन नाम के लिए, फ़ंक्शन नाम को वर्तमान तत्व बनाएं और उसके तर्क के साथ [function](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#function) को कॉल करें:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathematicalText

custom_function = MathematicalText("f").function("x + 1")
```

## **N-ary ऑपरेटर और समाकल जोड़ें**

सम, संघ, अंतर्गठन और अन्य बड़े ऑपरेटरों के लिए [nary](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#nary) का उपयोग करें। समाकलों के लिए [integral](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#integral) का उपयोग करें। दोनों विधियाँ नीचे और ऊपर सीमाएँ निर्धारित करने की अनुमति देती हैं।

![निचली और ऊपरी सीमाओं के साथ एक समष्टि](powerpoint-math-equations_7.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathNaryOperatorTypes, MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    math_shape = slide.getShapes().addMathShape(20, 20, 700, 120)
    math_paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph()

    a_power = MathematicalText("a").setSuperscript("n-k")
    summation_base = MathematicalText("x").setSuperscript("k").join(a_power)

    summation = summation_base.nary(MathNaryOperatorTypes.Summation, "k=0", "n")

    math_block = MathBlock(summation)
    math_paragraph.add(math_block)

    presentation.save("nary-operators.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

N-ary ऑपरेटर बड़े ऑपरेटर के लिए होते हैं जिनमें वैकल्पिक सीमाएँ हो सकती हैं। सरल ऑपरेटर जैसे `+`, `-`, और `=` आमतौर पर [MathematicalText](https://reference.aspose.com/slides/python-java/aspose.slides/mathematicaltext/) के रूप में जोड़े जाते हैं और अभिव्यक्ति में सम्मिलित होते हैं।

समाकल के लिए, उपयोग करें [integral](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#integral):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathIntegralTypes, MathematicalText

differential = MathematicalText("dx").toBox()
integral_base = MathematicalText("x").join(differential)
integral = integral_base.integral(MathIntegralTypes.Simple, "0", "1")
```

## **मैट्रिक्स जोड़ें**

पंक्तियों और स्तंभों के लिए [MathMatrix](https://reference.aspose.com/slides/python-java/aspose.slides/mathmatrix/) का उपयोग करें। डिफ़ॉल्ट रूप से मैट्रिक्स में कोष्ठक नहीं होते, इसलिए यदि आपको कोष्ठक, ब्रैकेट या ब्रेस की आवश्यकता हो तो मैट्रिक्स को घेरें।

![एक दो-पंक्तियों वाला गणित मैट्रिक्स जिसमें एक खाली सेल है](powerpoint-math-equations_10.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathMatrix, MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    math_shape = slide.getShapes().addMathShape(20, 20, 700, 120)
    math_paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph()

    matrix = MathMatrix(2, 3)
    cell_0_0 = MathematicalText("1")
    matrix.set_Item(0, 0, cell_0_0)
    cell_0_1 = MathematicalText("x")
    matrix.set_Item(0, 1, cell_0_1)
    cell_1_0 = MathematicalText("x")
    matrix.set_Item(1, 0, cell_1_0)
    cell_1_1 = MathematicalText("2")
    matrix.set_Item(1, 1, cell_1_1)
    cell_1_2 = MathematicalText("y")
    matrix.set_Item(1, 2, cell_1_2)

    math_block = MathBlock(matrix)
    math_paragraph.add(math_block)

    presentation.save("matrix.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **समीकरण एरे जोड़ें**

जब आपको संरेखित समीकरणों या ऊर्ध्वाधर अभिव्यक्तियों की स्टैक की आवश्यकता हो, तो [toMathArray](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#toMathArray) का उपयोग करें।

![एक ऊर्ध्वाधर गणित एरे जिसमें x y के ऊपर है](powerpoint-math-equations_11.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    math_shape = slide.getShapes().addMathShape(20, 20, 700, 140)
    math_paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph()

    equation_array = MathematicalText("x").join("y").toMathArray()

    math_block = MathBlock(equation_array)
    math_paragraph.add(math_block)

    presentation.save("equation-array.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **त्रिकोणमितीय फ़ंक्शन जोड़ें**

जब तर्क वर्तमान तत्व हो और फ़ंक्शन नाम ज्ञात हो, तो [asArgumentOfFunction](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#asArgumentOfFunction) का उपयोग करें।

![cos त्रिकोणमितीय फ़ंक्शन को 2x पर लागू किया गया है](powerpoint-math-equations_6.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathFunctionsOfOneArgument, MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    math_shape = slide.getShapes().addMathShape(20, 20, 700, 100)
    math_paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph()

    cosine = MathematicalText("2x").asArgumentOfFunction(MathFunctionsOfOneArgument.Cos)

    math_block = MathBlock(cosine)
    math_paragraph.add(math_block)

    presentation.save("trigonometric-function.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **सबस्क्रिप्ट और सुपरस्क्रिप्ट जोड़ें**

सूचकांक और घात के लिए सबस्क्रिप्ट और सुपरस्क्रिप्ट सहायक का उपयोग करें। जब सूचकांक को आधार के बाएँ पक्ष पर प्रदर्शित करना हो, तो [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setSubSuperscriptOnTheLeft) का उपयोग करें।

![बाएँ‑साइड सबस्क्रिप्ट 1 और सुपरस्क्रिप्ट n के साथ एक बड़ा Y](powerpoint-math-equations_9.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    math_shape = slide.getShapes().addMathShape(20, 20, 700, 100)
    math_paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph()

    scripts = MathematicalText("Y").setSubSuperscriptOnTheLeft("1", "n")

    math_block = MathBlock(scripts)
    math_paragraph.add(math_block)

    presentation.save("subscript-superscript.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **डिलिमिटर जोड़ें**

एक अभिव्यक्ति को डिलिमिटर के भीतर रखने के लिए [enclose](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#enclose) का उपयोग करें। आप कई तत्वों वाले डिलिमिटर अभिव्यक्तियों के लिए विभाजक अक्षर भी निर्धारित कर सकते हैं।

![x, y और z को लंबवत बार से अलग करने वाला डिलिमिटर अभिव्यक्ति](powerpoint-math-equations_13.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    math_shape = slide.getShapes().addMathShape(20, 20, 700, 100)
    math_paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph()

    delimiter = MathematicalText("x").join("y").join("z").enclose('<', '>')
    delimiter.setSeparatorCharacter('|')

    math_block = MathBlock(delimiter)
    math_paragraph.add(math_block)

    presentation.save("delimiters.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **डिलिमिटर का आकार और संरेखण**

`True` को [setGrowToMatchOperandHeight](https://reference.aspose.com/slides/python-java/aspose.slides/mathdelimiter/#setGrowToMatchOperandHeight) में पास करें ताकि लंबा ऑपरेण्ड होने पर कोष्ठक का आकार बढ़े, या `False` पास करके उनका सामान्य आकार रखें। दो में से किसी एक [MathDelimiterShape](https://reference.aspose.com/slides/python-java/aspose.slides/mathdelimitershape/) मान के साथ [setDelimiterShape](https://reference.aspose.com/slides/python-java/aspose.slides/mathdelimiter/#setDelimiterShape) का उपयोग करें। `Centered` कोष्ठक को गणित अक्ष पर मध्य में रखता है, जो बराबर चिन्ह के मध्य से चलता है। `Match` कोष्ठकों को सम्मिलित सामग्री के साथ संरेखित करता है। दोनों सेटिंग केवल डिलिमिटर को प्रभावित करती हैं; अंदर की अभिव्यक्ति वही रहती है।

यह उदाहरण `x` के एक्सपोनेंट में एक अंश रखता है ताकि अभिव्यक्ति बेसलाइन के ऊपर अधिक विस्तारित हो। सभी चार समीकरण समान कोष्ठक और फ़ॉन्ट सेटिंग्स का उपयोग करते हैं।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathDelimiterShape, MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    for row, grow in enumerate((True, False)):
        for column, shape in enumerate((MathDelimiterShape.Centered, MathDelimiterShape.Match)):
            fraction = MathematicalText("a + b").divide("c + d")
            power = MathematicalText("x").setSuperscript(fraction)
            delimiter = power.enclose("(", ")")
            delimiter.setGrowToMatchOperandHeight(grow)
            delimiter.setDelimiterShape(shape)

            math_shape = slide.getShapes().addMathShape(20 + 330 * column, 20 + 120 * row, 300, 100)
            portion = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
            portion.getPortionFormat().setFontHeight(32)
            equation = MathematicalText("y = ").join(delimiter)
            portion.getMathParagraph().add(equation)

    presentation.save("delimiter-sizing.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

PowerPoint में पंक्तियों की तुलना करके वृद्धि प्रभाव देखिए। ऊपर की पंक्ति में, कोष्ठक एक्सपोनेंट को घेरने के लिए बढ़ते हैं और दोनों आकारों में समान दिखते हैं। नीचे की पंक्ति में वृद्धि बंद है। बाएँ का छोटा कोष्ठक (`Centered`) बराबर चिन्ह के साथ संरेखित होता है, जबकि दाएँ का (`Match`) अभिव्यक्ति के चारों ओर ऊँचा रहता है।

![PowerPoint में चार समीकरण जिनमें डिलिमिटर वृद्धि ऊपर सक्षम और नीचे अक्षम है, बाएँ `Centered` और दाएँ `Match`](delimiter-sizing.png)

## **बॉर्डर बॉक्स जोड़ें**

एक अंश पर [toBorderBox](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#toBorderBox) को कॉल करके पूरी अभिव्यक्ति को फ्रेम किया जा सकता है। डिफ़ॉल्ट रूप से लौटाया गया [MathBorderBox](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/) चारों ओर की धारा दिखाता है। व्यक्तिगत पक्षों को हटाने के लिए [setHideTop](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setHideTop), [setHideBottom](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setHideBottom), [setHideLeft](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setHideLeft) और [setHideRight](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setHideRight) का उपयोग करें।

उदाहरण एक ही अंश की छह प्रतियां एक स्लाइड पर रखता है। रद्द करना दिखाने के लिए, चारों पक्षों को छुपाएँ और ऊपर‑बाएँ से नीचे‑दाएँ तक तिरछी रेखा (↗) के लिए [setStrikethroughBottomLeftToTopRight](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setStrikethroughBottomLeftToTopRight) को `True` पास करें या नीचे‑बाएँ से ऊपर‑दाएँ (↘) के लिए [setStrikethroughTopLeftToBottomRight](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setStrikethroughTopLeftToBottomRight) पास करें। आप किसी भी संयोजन के साथ [setStrikethroughHorizontal](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setStrikethroughHorizontal) या [setStrikethroughVertical](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setStrikethroughVertical) का भी उपयोग कर सकते हैं।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathematicalText, Presentation, SaveFormat, SlideSizeScaleType

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(540, 220, SlideSizeScaleType.DoNotScale)
    slide = presentation.getSlides().get_Item(0)

    def add_fraction(x, y, hide_border):
        fraction = MathematicalText("x+1").divide("y+2")
        box = fraction.toBorderBox()
        box.setHideTop(hide_border)
        box.setHideBottom(hide_border)
        box.setHideLeft(hide_border)
        box.setHideRight(hide_border)

        shape = slide.getShapes().addMathShape(x, y, 160, 90)
        portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
        portion.getPortionFormat().setFontHeight(28)
        math_block = MathBlock(box)
        portion.getMathParagraph().add(math_block)
        return box

    add_fraction(10, 10, False)

    partial = add_fraction(190, 10, False)
    partial.setHideTop(True)
    partial.setHideRight(True)

    add_fraction(370, 10, True).setStrikethroughBottomLeftToTopRight(True)
    add_fraction(10, 120, True).setStrikethroughTopLeftToBottomRight(True)
    add_fraction(190, 120, True).setStrikethroughHorizontal(True)
    add_fraction(370, 120, False).setStrikethroughVertical(True)

    presentation.save("border-box.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![PowerPoint में छह संपादन योग्य अंश। ऊपर की पंक्ति: पूर्ण बॉर्डर, नीचे और बाएँ पक्ष, ऊपर‑बाएँ से नीचे‑दाएँ तिरछी रेखा। नीचे की पंक्ति: नीचे‑बाएँ से ऊपर‑दाएँ तिरछी रेखा, क्षैतिज स्ट्राइक, ऊर्ध्वाधर स्ट्राइक पूर्ण बॉर्डर के साथ।](border-box-fractions.png)

इस अंश पर, क्षैतिज स्ट्राइक अंश रेखा को ओवरलैप करता है। ऊर्ध्वाधर स्ट्राइक अंश के अंश और हर के दोनों को काटता है जबकि घेरने वाला बॉर्डर दिखाई देता रहता है। ये रेखाएँ पूरी अभिव्यक्ति को सजाते हैं। सामान्य टेक्स्ट स्ट्राइक‑थ्रू अक्षरों पर लागू होता है। PowerPoint में प्रस्तुति को पुनः खोलने के बाद आप अभी भी अंश और हर को स्वतंत्र रूप से संपादित कर सकते हैं।

## **शर्तों को समूहित करें**

[group](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#group) का उपयोग करके आप अभिव्यक्ति के ऊपर या नीचे एक समूह‑चर जोड़ सकते हैं। समूहित शर्तों को लेबल करने के लिए एक सीमा जोड़ें।

![x प्लस y अभिव्यक्ति को नीचे लेबल वाले समूह में दर्शाया गया है](powerpoint-math-equations_15.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathTopBotPositions, MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    math_shape = slide.getShapes().addMathShape(20, 20, 700, 120)
    math_paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph()

    grouped = MathematicalText("x + y").group('\u23DF', MathTopBotPositions.Bottom, MathTopBotPositions.Top).setLowerLimit("any text")

    math_block = MathBlock(grouped)
    math_paragraph.add(math_block)

    presentation.save("grouped-terms.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **गणितीय तत्वों को स्वरूपित करें**

केवल जहां यह सूत्र को स्पष्ट करता है, उन ही स्थानों पर स्वरूपण सहायक का उपयोग करें। उदाहरण के लिए, [overbar](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#overbar) एक गणित तत्व के ऊपर बार रखता है।

![ABC गणित अभिव्यक्ति के ऊपर एक ओवरबार के साथ](powerpoint-math-equations_14.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    math_shape = slide.getShapes().addMathShape(20, 20, 700, 100)
    math_paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph()

    overbar = MathematicalText("ABC").overbar()

    math_block = MathBlock(overbar)
    math_paragraph.add(math_block)

    presentation.save("overbar.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **मौजूदा समीकरण में टेक्स्ट स्वरूपित करें**

एक मौजूदा समीकरण में पूरे टेक्स्ट को स्वरूपित करने के लिए प्रत्येक गणित ब्लॉक के तत्व‑वृक्ष को पार करें। [MathElementBase.getChildren](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#getChildren) केवल सीधे बच्चों को लौटाता है, इसलिए आप इसे पुनः‑आह्वान कर अंश, स्क्रिप्ट, मूल और अन्य नेस्टेड संरचनाओं के भीतर के टेक्स्ट तक पहुँच सकते हैं। [MathematicalText](https://reference.aspose.com/slides/python-java/aspose.slides/mathematicaltext/) होने पर शुरुआत के तत्व को भी शामिल करने के लिए वर्तमान तत्व और उसके बच्चों दोनों की जाँच करें।

यह उदाहरण मानता है कि `input.pptx` में एक समीकरण है जैसे `z = xᵢ / ∛y`, जिसमें अंश के अंश में सबस्क्रिप्ट और हर में मूल शामिल है। केवल ब्लॉक के शीर्ष‑स्तर के तत्वों को प्रोसेस करने से अंश के भीतर का टेक्स्ट छूट जाता। उदाहरण स्लाइड टेक्स्ट फ्रेम में गणितीय भाग खोजता है, उनके ब्लॉकों को [MathPortion.getMathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/#getMathParagraph) के माध्यम से पहुँचता है, और प्रत्येक टेक्स्ट तत्व के [getFormat](https://reference.aspose.com/slides/python-java/aspose.slides/mathematicaltext/#getFormat) मेथड के साथ [setFontHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setFontHeight) को कॉल करके फ़ॉन्ट आकार 28 पॉइंट पर सेट करता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, MathematicalText, MathPortion, Presentation, SaveFormat


def format_math_text(element):
    if isinstance(element, MathematicalText):
        element.getFormat().setFontHeight(28)

    for child in element.getChildren():
        format_math_text(child)


presentation = Presentation("input.pptx")
try:
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if not isinstance(shape, AutoShape):
                continue

            if shape.getTextFrame() is None:
                continue

            for paragraph in shape.getTextFrame().getParagraphs():
                for portion in paragraph.getPortions():
                    if isinstance(portion, MathPortion):
                        for block in portion.getMathParagraph():
                            format_math_text(block)

    presentation.save("formatted-equations.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

सहेजी गई प्रस्तुति प्रत्येक प्रोसेस किए गए समीकरण के हर स्तर पर अपडेटेड टेक्स्ट स्वरूपण रखती है, जबकि उसका टेक्स्ट कंटेंट और गणितीय संरचना बनी रहती है।

## **त्वरित संदर्भ**

| कार्य | मुख्य API |
| --- | --- |
| गणित टेक्स्ट बनाएं | [MathematicalText](https://reference.aspose.com/slides/python-java/aspose.slides/mathematicaltext/) |
| तत्वों को मिलाएं | [MathElementBase.join](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#join) |
| अंश बनाएं | [MathElementBase.divide](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#divide) |
| सुपरस्क्रिप्ट या सबस्क्रिप्ट जोड़ें | [setSuperscript](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setSuperscript), [setSubscript](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setSubscript) |
| फ़ंक्शन जोड़ें | [function](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#function), [asArgumentOfFunction](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#asArgumentOfFunction) |
| मूल जोड़ें | [MathElementBase.radical](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#radical) |
| सीमाएँ जोड़ें | [setLowerLimit](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setLowerLimit), [setUpperLimit](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setUpperLimit) |
| बाएँ‑साइड स्क्रिप्ट जोड़ें | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setSubSuperscriptOnTheLeft) |
| समष्टि और समाकल जोड़ें | [nary](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#nary), [integral](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#integral) |
| मैट्रिक्स जोड़ें | [MathMatrix](https://reference.aspose.com/slides/python-java/aspose.slides/mathmatrix/) |
| समीकरण एरे जोड़ें | [toMathArray](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#toMathArray) |
| डिलिमिटर जोड़ें | [enclose](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#enclose) |
| बार और बॉर्डर जोड़ें | [overbar](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#overbar), [toBorderBox](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#toBorderBox) |
| शर्तों को समूहित करें | [group](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#group) |

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं मौजूदा PowerPoint समीकरण को संपादित कर सकता हूँ?**

हां। प्रस्तुति खोलें, उस आकार को खोजें जिसमें एक [MathPortion](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/) हो, [getMathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/#getMathParagraph) को कॉल करें, और उस पैराग्राफ में गणित ब्लॉकों को अपडेट करें।

**क्या समीकरण संपादन योग्य PowerPoint गणित के रूप में संग्रहीत होते हैं?**

हां। PPTX में सहेजते समय, Aspose.Slides समीकरण को संपादन योग्य Office गणित सामग्री के रूप में लिखता है।

**क्या मैं समीकरणों को LaTeX में निर्यात कर सकता हूँ?**

हां। उसके [MathPortion](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/) से [MathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathparagraph/) प्राप्त करें, और सीधे निर्यात के लिए [MathParagraph.toLatex](https://reference.aspose.com/slides/python-java/aspose.slides/mathparagraph/#toLatex) को कॉल करें। पूर्ण उदाहरण के लिए देखें [Export Math Equations from Presentations in Python](/slides/hi/python-java/exporting-math-equations/#export-math-equations-to-latex).