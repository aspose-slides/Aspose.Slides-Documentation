---
title: Python में PowerPoint प्रस्तुतियों में गणितीय समीकरण जोड़ें
linktitle: PowerPoint गणितीय समीकरण
type: docs
weight: 80
url: /hi/python-java/powerpoint-math-equations/
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
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java का उपयोग करके PowerPoint PPT और PPTX में गणितीय समीकरण डालें और संपादित करें, OMML का समर्थन, स्वरूपण नियंत्रण, और स्पष्ट Python कोड नमूने प्रदान करता है।"
---
## **अवलोकन**

PowerPoint समीकरणों को Office Math Markup Language (OMML) के रूप में संग्रहीत करता है। Aspose.Slides for Python via Java के साथ, आप प्रोग्रामेटिक रूप से समान प्रकार की गणितीय सामग्री बना सकते हैं: भिन्न, मूल, फ़ंक्शन, सीमा, N-ary ऑपरेटर, मैट्रिस, एरे और स्वरूपित गणित ब्लॉक्स।

PowerPoint में, उपयोगकर्ता सामान्यतः समीकरण **Insert > Equation** से जोड़ते हैं:

![PowerPoint Insert tab with the Equation command selected](powerpoint-math-equations_1.png)

परिणाम स्लाइड पर संपादन योग्य गणितीय पाठ है:

![A PowerPoint slide containing an editable math equation](powerpoint-math-equations_2.png)

Aspose.Slides उस गणितीय पाठ को तीन मुख्य ऑब्जेक्ट्स के माध्यम से बनाता है:

- एक गणितीय आकार, जो [addMathShape](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addMathShape) से बनाया गया है, वह आकार है जिसमें समीकरण रहता है।
- [MathPortion](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/) आकार के टेक्स्ट फ्रेम के भीतर गणितीय सामग्री संग्रहीत करता है।
- [MathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathparagraph/) एक या अधिक [MathBlock](https://reference.aspose.com/slides/python-java/aspose.slides/mathblock/) ऑब्जेक्ट्स को रखता है।

नीचे के अधिकांश उदाहरण [MathematicalText](https://reference.aspose.com/slides/python-java/aspose.slides/mathematicaltext/) और [MathElementBase](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/) की फ़्लुएंट मेथड्स का उपयोग करते हैं ताकि कोड छोटा और पढ़ने योग्य रहे।

MathML निर्यात परिदृश्यों के लिए देखें [Python में प्रस्तुतियों से गणितीय समीकरण निर्यात](/slides/hi/python-java/exporting-math-equations/)।

## **समीकरण बनाएं**

यह उदाहरण [addMathShape](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addMathShape) का उपयोग करके एक गणितीय आकार बनाता है और पाइथागोरस प्रमेय जोड़ता है:

![The equation c squared equals a squared plus b squared](powerpoint-math-equations_3.png)

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
[addMathShape](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addMathShape) एक ऐसा आकार बनाता है जिसमें पहले से ही एक गणितीय पैराग्राफ शामिल होता है। पहला [MathPortion](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/) एक्सेस करें, [getMathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/#getMathParagraph) को कॉल करें, और उसमें गणितीय ब्लॉक्स या तत्व जोड़ें।
{{% /alert %}}

## **भिन्न जोड़ें**

भिन्न बनाने के लिए [divide](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#divide) का उपयोग करें। आप [MathFractionTypes](https://reference.aspose.com/slides/python-java/aspose.slides/mathfractiontypes/) के साथ एक भिन्न शैली चुन सकते हैं।

![A skewed math fraction showing one divided by x](powerpoint-math-equations_4.png)

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

स्टैक्ड भिन्न के लिए, [MathFractionTypes.Bar](https://reference.aspose.com/slides/python-java/aspose.slides/mathfractiontypes/#Bar) का उपयोग करें:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathFractionTypes, MathematicalText

stacked_fraction = MathematicalText("x + 1").divide("y - 1", MathFractionTypes.Bar)
```

## **मूल जोड़ें**

एक वर्गमूल, घनमूल या अन्य मूल बनाने के लिए [radical](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#radical) का उपयोग करें। वर्तमान तत्व आधार बन जाता है, और तर्क डिग्री बन जाता है।

![An n-th root radical expression with x under the radical sign](powerpoint-math-equations_5.png)

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

## **फ़ंक्शन और सीमाएं जोड़ें**

`sin(x)`, `log(x)` या कस्टम फ़ंक्शन नामों जैसे फ़ंक्शन के लिए [asArgumentOfFunction](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#asArgumentOfFunction) या [function](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#function) का उपयोग करें। सीमाओं के लिए, `lim` को एक [MathLimit](https://reference.aspose.com/slides/python-java/aspose.slides/mathlimit/) में रखें या [setLowerLimit](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setLowerLimit) का उपयोग करें।

![The limit of x as x approaches infinity](powerpoint-math-equations_8.png)

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

## **N-ary ऑपरेटर और इंटीग्रल जोड़ें**

समिश्रण, संघ, प्रतिच्छेद और अन्य बड़े ऑपरेटरों के लिए [nary](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#nary) का उपयोग करें। इंटीग्रल के लिए [integral](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#integral) का उपयोग करें। दोनों मेथड नीचे और ऊपर की सीमाएं सेट करने की अनुमति देते हैं।

![A summation with lower and upper limits](powerpoint-math-equations_7.png)

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

N-ary ऑपरेटर बड़े ऑपरेटरों के लिए होते हैं जिनमें वैकल्पिक सीमाएं हो सकती हैं। सरल ऑपरेटर जैसे `+`, `-`, `=` सामान्यतः [MathematicalText](https://reference.aspose.com/slides/python-java/aspose.slides/mathematicaltext/) के रूप में जोड़े जाते हैं और अभिव्यक्ति में सम्मिलित होते हैं।

इंटीग्रल के लिए, [integral](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#integral) का उपयोग करें:

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

## **मैट्रिस जोड़ें**

पंक्तियों और स्तंभों के लिए [MathMatrix](https://reference.aspose.com/slides/python-java/aspose.slides/mathmatrix/) का उपयोग करें। मैट्रिस में डिफ़ॉल्ट रूप से कोष्ठक नहीं होते, इसलिए जब आपको कोष्ठक, ब्रेस या कर्ली ब्रैकेट की आवश्यकता हो तो मैट्रिस को घेरें।

![A two-row math matrix with one empty cell](powerpoint-math-equations_10.png)

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

जब आपको संरेखित समीकरण या ऊर्ध्वाधर अभिव्यक्तियों का स्टैक चाहिए, तो [toMathArray](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#toMathArray) का उपयोग करें।

![A vertical math array with x above y](powerpoint-math-equations_11.png)

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

### **एरे को आसपास के तत्वों के साथ संरेखित करें**

[setBaseJustification](https://reference.aspose.com/slides/python-java/aspose.slides/matharray/#setBaseJustification) एरे की वर्टिकल संरेखण को उसके बगल के गणितीय तत्वों के सापेक्ष नियंत्रित करता है। नीचे का उदाहरण पहली पंक्ति, एरे के केंद्र और अंतिम पंक्ति के साथ संरेखण की तुलना करता है।

निम्नलिखित उदाहरण तीन समान एरे बनाता है, प्रत्येक में तीन पंक्तियां और पड़ोसी तत्व `A=` तथा `=B` हैं। सभी गणितीय पाठ Cambria Math पर 24 पॉइंट का है। केवल एरे का संरेखण बदलता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, MathArray, MathBlock, MathJustification, MathematicalText, MathVerticalAlignment, Presentation, SaveFormat, ShapeType, SlideSizeScaleType, TextAnchorType
from java.awt import Color

def create_text(value):
    text = MathematicalText(value)
    text.getFormat().setFontHeight(24)
    text.getFormat().setLatinFont(FontData("Cambria Math"))
    return text


presentation = Presentation()
try:
    presentation.getSlideSize().setSize(780, 200, SlideSizeScaleType.DoNotScale)
    slide = presentation.getSlides().get_Item(0)
    
    alignments = (("Top", MathVerticalAlignment.Top), ("Center", MathVerticalAlignment.Center), ("Bottom", MathVerticalAlignment.Bottom))
    for index, (name, alignment) in enumerate(alignments):
        x = 20 + index * 260
        label = slide.getShapes().addAutoShape(ShapeType.Rectangle, x, 10, 240, 30)
        label.getFillFormat().setFillType(FillType.NoFill)
        label.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
        label.getTextFrame().setText(name)
        label_format = label.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat()
        label_format.setFontHeight(16)
        label_format.getFillFormat().setFillType(FillType.Solid)
        label_format.getFillFormat().getSolidFillColor().setColor(Color.BLACK)

        math_shape = slide.getShapes().addMathShape(x, 60, 240, 130)
        math_shape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Top)
        paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0)
        math_paragraph = paragraph.getPortions().get_Item(0).getMathParagraph()
        math_paragraph.setJustification(MathJustification.LeftJustified)

        equation_array = MathArray(create_text("x+y=3"))
        equation_array.getArguments().add(create_text("x-y=1"))
        equation_array.getArguments().add(create_text("x=2"))
        equation_array.setBaseJustification(alignment)
        equation = MathBlock(create_text("A=")).join(equation_array).join(create_text("=B"))
        math_paragraph.add(equation)

    presentation.save("equation-array-alignment.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

निम्न तुलना में PowerPoint में सहेजी गई प्रस्तुति दिखायी गई है। प्रत्येक एरे के बगल में `A=` और `=B` की स्थिति देखें।

![Equation arrays in PowerPoint with Top, Center, and Bottom alignment and identical neighboring elements](equation-array-alignment.png)

### **पंक्ति अंतराल कॉन्फ़िगर करें**

[setRowSpacingRule](https://reference.aspose.com/slides/python-java/aspose.slides/matharray/#setRowSpacingRule) एरे के भीतर पंक्तियों के लिए अंतराल नियम चुनता है। [setRowSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/matharray/#setRowSpacing) स्पष्ट अंतराल नियम के लिए संख्यात्मक मान देता है और प्रीसेट नियमों द्वारा अनदेखा किया जाता है।

सटीक अंतराल के लिए, मान पॉइंट में मापा जाता है। आनुपातिक अंतराल के लिए, यह आधी-लाइन में मापा जाता है: उदाहरण में मान `3` 1.5 लाइनों का प्रतिनिधित्व करता है। स्पष्ट मान निर्दिष्ट करते समय दोनों गुणों को सेट करें; केवल संख्यात्मक मान बदलने से अंतराल नियम नहीं चुना जाता।

नीचे का उदाहरण समान समीकरण, संरेखण और फ़ॉन्ट सेटिंग वाले पाँच प्रस्तुतियों को सहेजता है। पहली तीन प्रीसेट का उपयोग करती हैं; अंतिम दो स्पष्ट मान दिखाती हैं।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, MathArray, MathBlock, MathJustification, MathematicalText, MathRowSpacingRule, MathVerticalAlignment, Presentation, SaveFormat

def create_text(value):
    text = MathematicalText(value)
    text.getFormat().setFontHeight(24)
    text.getFormat().setLatinFont(FontData("Cambria Math"))
    return text


settings = (("SingleLineGap", MathRowSpacingRule.SingleLineGap, 0), ("OneAndAHalfLineGap", MathRowSpacingRule.OneAndAHalfLineGap, 0), ("TwoLineGap", MathRowSpacingRule.TwoLineGap, 0), ("Exactly", MathRowSpacingRule.Exactly, 20), ("Multiple", MathRowSpacingRule.Multiple, 3))
for name, rule, spacing in settings:
    presentation = Presentation()
    try:
        slide = presentation.getSlides().get_Item(0)
        math_shape = slide.getShapes().addMathShape(20, 20, 600, 300)
        paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0)
        paragraph.getParagraphFormat().setSpaceBefore(0)
        paragraph.getParagraphFormat().setSpaceAfter(0)
        math_paragraph = paragraph.getPortions().get_Item(0).getMathParagraph()
        math_paragraph.setJustification(MathJustification.LeftJustified)

        equation_array = MathArray(create_text("x+y=3"))
        equation_array.getArguments().add(create_text("x-y=1"))
        equation_array.getArguments().add(create_text("x=2"))
        equation_array.setBaseJustification(MathVerticalAlignment.Center)
        equation_array.setRowSpacingRule(rule)
        equation_array.setRowSpacing(spacing)
        equation = MathBlock(create_text("A=")).join(equation_array).join(create_text("=B"))
        math_paragraph.add(equation)

        presentation.save(f"equation-array-{name}.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()
```

एरे पंक्ति अंतराल पैराग्राफ अंतराल से अलग होता है। [setSpaceBefore](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setSpaceBefore) और [setSpaceAfter](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setSpaceAfter) कंटेनिंग पैराग्राफ के चारों ओर जगह जोड़ते हैं, एरे पंक्तियों के बीच नहीं। इसी प्रकार, [MathParagraph.setJustification](https://reference.aspose.com/slides/python-java/aspose.slides/mathparagraph/#setJustification) पूरे गणितीय पैराग्राफ को क्षैतिज रूप से स्थित करता है; यह एरे की वर्टिकल संरेखण सेटिंग को बदलता नहीं है।

## **त्रिकोणमितीय फ़ंक्शन जोड़ें**

जब तर्क वर्तमान तत्व हो और फ़ंक्शन नाम ज्ञात हो, तो [asArgumentOfFunction](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#asArgumentOfFunction) का उपयोग करें।

![The trigonometric function cos applied to 2x](powerpoint-math-equations_6.png)

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

सूचकांक और घातांकों के लिए सबस्क्रिप्ट और सुपरस्क्रिप्ट हेल्पर का उपयोग करें। जब सूचकांक बेस के बाएँ पक्ष में दिखना चाहिए, तो [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setSubSuperscriptOnTheLeft) का उपयोग करें।

![A capital Y with left-side subscript 1 and superscript n](powerpoint-math-equations_9.png)

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

एक अभिव्यक्ति को डिलिमिटर के भीतर रखने के लिए [enclose](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#enclose) का उपयोग करें। आप कई तत्वों वाले डिलिमिटर अभिव्यक्तियों के लिए एक विभाजक कैरेक्टर भी सेट कर सकते हैं।

![A delimiter expression containing x, y, and z separated by vertical bars](powerpoint-math-equations_13.png)

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

[setGrowToMatchOperandHeight](https://reference.aspose.com/slides/python-java/aspose.slides/mathdelimiter/#setGrowToMatchOperandHeight) को `True` पास करके कोष्ठक को लंबे ऑपरेण्ड के आसपास बढ़ने दें, या `False` पास करके उन्हें सामान्य आकार पर रखें। दो [MathDelimiterShape](https://reference.aspose.com/slides/python-java/aspose.slides/mathdelimitershape/) मानों में से एक के साथ [setDelimiterShape](https://reference.aspose.com/slides/python-java/aspose.slides/mathdelimiter/#setDelimiterShape) का उपयोग करें। `Centered` कोष्ठकों को गणितीय अक्ष पर केंद्रित करता है, जो बराबर चिह्न के मध्य से गुजरता है। `Match` उन्हें संलग्न सामग्री के साथ संरेखित करता है। दोनों सेटिंग केवल डिलिमिटर को प्रभावित करती हैं। अंदर की अभिव्यक्ति समान रहती है।

उदाहरण में `x` के घातांक में एक भिन्न रखा गया है ताकि अभिव्यक्ति बेसलाइन के ऊपर अधिक विस्तारित हो। सभी चार समीकरण एक ही कोष्ठकों और फ़ॉन्ट सेटिंग्स का उपयोग करते हैं।

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

PowerPoint में, प्रभाव को देखने के लिए पंक्तियों की तुलना करें। शीर्ष पंक्ति में, कोष्ठक घातांक को घेरने के लिए बढ़ते हैं और दोनों आकार समान दिखते हैं। निचली पंक्ति में, वृद्धि बंद है। बाएँ तरफ छोटे कोष्ठक (`Centered`) बराबर चिह्न के साथ संरेखित होते हैं, जबकि दाएँ (`Match`) अभिव्यक्ति के ऊपर अधिक स्थित होते हैं।

![Four equations in PowerPoint with delimiter growth enabled above and disabled below, and Centered on the left and Match on the right](delimiter-sizing.png)

## **बॉर्डर बॉक्स जोड़ें**

एक भिन्न पर [toBorderBox](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#toBorderBox) कॉल करके संपूर्ण अभिव्यक्ति को फ़्रेम में रखें। लौटाया गया [MathBorderBox](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/) डिफ़ॉल्ट रूप से सभी चार किनारे दिखाता है। व्यक्तिगत किनारे हटाने के लिए [setHideTop](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setHideTop), [setHideBottom](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setHideBottom), [setHideLeft](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setHideLeft), और [setHideRight](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setHideRight) का उपयोग करें।

उदाहरण में एक ही भिन्न के छह प्रतियां एक स्लाइड पर रखी गई हैं। रद्दीकरण दिखाने के लिए सभी चार पक्ष छिपाएँ और `True` को [setStrikethroughBottomLeftToTopRight](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setStrikethroughBottomLeftToTopRight) को पास करें ताकि एक ऊपर की ओर विकर्ण (↗) बने, या [setStrikethroughTopLeftToBottomRight](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setStrikethroughTopLeftToBottomRight) को पास करके नीचे की ओर विकर्ण (↘) बनाएं। आप किसी भी संयोजन के साथ दृश्यमान पक्षों के साथ [setStrikethroughHorizontal](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setStrikethroughHorizontal) या [setStrikethroughVertical](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setStrikethroughVertical) का भी उपयोग कर सकते हैं।

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

![Six editable fractions in PowerPoint. Top row: full border, bottom and left sides, rising diagonal. Bottom row: falling diagonal, horizontal strike, vertical strike with a full border.](border-box-fractions.png)

इस भिन्न पर, क्षैतिज स्ट्राइक भिन्न रेखा को ओवरलैप करता है। लंबवत स्ट्राइक अंश और हर दोनों को काटता है जबकि आस-पास का बॉर्डर दिखाई देता रहता है। ये रेखाएँ संपूर्ण अभिव्यक्ति को सजाती हैं। सामान्य स्ट्राइकथ्रू केवल टेक्स्ट रन के अक्षरों पर लागू होता है। PowerPoint में प्रस्तुति को पुनः खोलने के बाद भी आप अंश और हर को स्वतंत्र रूप से संपादित कर सकते हैं।

## **टर्म को समूहित करें**

[group](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#group) का उपयोग करके अभिव्यक्ति के ऊपर या नीचे एक समूहिंग कैरेक्टर रखें। समूहित टर्म्स को लेबल करने के लिए सीमा जोड़ें।

![The expression x plus y grouped with the label any text below it](powerpoint-math-equations_15.png)

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

## **गणितीय तत्वों का स्वरूपण करें**

केवल जहाँ फॉर्मूला स्पष्ट हो, स्वरूपण हेल्पर का उपयोग करें। उदाहरण के लिए, [overbar](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#overbar) एक गणितीय तत्व के ऊपर बार रखता है।

![A math expression ABC with an overbar](powerpoint-math-equations_14.png)

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

### **मौजूदा समीकरण में पाठ का स्वरूपण करें**

एक मौजूदा समीकरण में पूरे पाठ को स्वरूपित करने के लिए, प्रत्येक गणितीय ब्लॉक के तत्व वृक्ष को ट्रावर्स करें। [MathElementBase.getChildren](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#getChildren) केवल तत्काल बच्चों को लौटाता है, इसलिए फ्रैक्शन, स्क्रिप्ट, रेडिकल और अन्य नेस्टेड संरचनाओं के भीतर के पाठ तक पहुँचने के लिए इसे पुनरावर्ती रूप से कॉल करें। वर्तमान तत्व और उसके बच्चों दोनों को जांचें ताकि जब वह [MathematicalText](https://reference.aspose.com/slides/python-java/aspose.slides/mathematicaltext/) हो तो प्रारंभिक तत्व भी शामिल हो।

यह उदाहरण मानता है कि `input.pptx` में `z = xᵢ / ∛y` जैसा समीकरण है, जिसमें अंश में सबस्क्रिप्ट और हर में रेडिकल है। केवल ब्लॉक के शीर्ष‑स्तर तत्वों को प्रोसेस करने से फ्रैक्शन के भीतर के पाठ को मिस किया जाएगा। उदाहरण स्लाइड टेक्स्ट फ्रेम्स में गणितीय पोर्शन खोजता है, उनके ब्लॉकों को [MathPortion.getMathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/#getMathParagraph) के माध्यम से एक्सेस करता है, और प्रत्येक टेक्स्ट तत्व के [getFormat](https://reference.aspose.com/slides/python-java/aspose.slides/mathematicaltext/#getFormat) मेथड पर [setFontHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setFontHeight) को कॉल करके फ़ॉन्ट आकार 28 पॉइंट सेट करता है।

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

सहेजा गया प्रस्तुतीकरण प्रत्येक प्रोसेस किए गए समीकरण के प्रत्येक स्तर पर अपडेटेड टेक्स्ट स्वरूपण रखता है, जबकि उसके टेक्स्ट कंटेंट और गणितीय संरचना को बरकरार रखता है।

## **त्वरित संदर्भ**

| कार्य | मुख्य API |
| --- | --- |
| गणितीय पाठ बनाएं | [MathematicalText](https://reference.aspose.com/slides/python-java/aspose.slides/mathematicaltext/) |
| तत्वों को मिलाएं | [MathElementBase.join](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#join) |
| भिन्न बनाएं | [MathElementBase.divide](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#divide) |
| सुपरस्क्रिप्ट या सबस्क्रिप्ट जोड़ें | [setSuperscript](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setSuperscript), [setSubscript](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setSubscript) |
| फ़ंक्शन जोड़ें | [function](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#function), [asArgumentOfFunction](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#asArgumentOfFunction) |
| मूल जोड़ें | [MathElementBase.radical](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#radical) |
| सीमाएं जोड़ें | [setLowerLimit](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setLowerLimit), [setUpperLimit](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setUpperLimit) |
| बाएँ‑पक्ष स्क्रिप्ट जोड़ें | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setSubSuperscriptOnTheLeft) |
| समिश्रण और इंटीग्रल जोड़ें | [nary](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#nary), [integral](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#integral) |
| मैट्रिस जोड़ें | [MathMatrix](https://reference.aspose.com/slides/python-java/aspose.slides/mathmatrix/) |
| समीकरण एरे जोड़ें | [toMathArray](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#toMathArray) |
| डिलिमिटर जोड़ें | [enclose](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#enclose) |
| बार और बॉर्डर जोड़ें | [overbar](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#overbar), [toBorderBox](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#toBorderBox) |
| टर्म समूहित करें | [group](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#group) |

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं मौजूदा PowerPoint समीकरण को संपादित कर सकता हूँ?**

हाँ। प्रस्तुति खोलें, उस आकार को खोजें जिसमें एक [MathPortion](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/) हो, [getMathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/#getMathParagraph) को कॉल करें, और उस पैराग्राफ में गणितीय ब्लॉक्स को अपडेट करें।

**क्या समीकरणों को संपादन योग्य PowerPoint गणित के रूप में सहेजा जाता है?**

हाँ। जब आप PPTX में सहेजते हैं, Aspose.Slides समीकरण को संपादन योग्य Office गणित सामग्री के रूप में लिखता है।

**क्या मैं समीकरणों को LaTeX में निर्यात कर सकता हूँ?**

हाँ। समीकरण के [MathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathparagraph/) को उसके [MathPortion](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/) से प्राप्त करें, और सीधे निर्यात करने के लिए [MathParagraph.toLatex](https://reference.aspose.com/slides/python-java/aspose.slides/mathparagraph/#toLatex) को कॉल करें। पूरी उदाहरण के लिए देखें [Python में प्रस्तुतियों से गणितीय समीकरण निर्यात](/slides/hi/python-java/exporting-math-equations/#export-math-equations-to-latex)।