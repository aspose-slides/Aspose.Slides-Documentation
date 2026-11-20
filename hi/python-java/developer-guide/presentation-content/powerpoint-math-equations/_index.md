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

PowerPoint समीकरणों को Office Math Markup Language (OMML) के रूप में संग्रहीत करता है। Aspose.Slides for Python via Java के साथ, आप प्रोग्रामेटिक रूप से उसी प्रकार की गणितीय सामग्री बना सकते हैं: अंश, मूल, फ़ंक्शन, सीमाएँ, N-ary ऑपरेटर्स, मैट्रिक्स, एरेज़, और स्वरूपित गणित ब्लॉक्स।

PowerPoint में, उपयोगकर्ता सामान्यतः **Insert > Equation** से समीकरण जोड़ते हैं:

![PowerPoint Insert टैब जिसमें Equation कमांड चयनित है](powerpoint-math-equations_1.png)

परिणाम स्लाइड में संपादन योग्य गणितीय पाठ है:

![एक PowerPoint स्लाइड जिसमें संपादन योग्य गणितीय समीकरण है](powerpoint-math-equations_2.png)

Aspose.Slides उस गणितीय पाठ को तीन मुख्य वस्तुओं के माध्यम से बनाता है:

- एक गणितीय आकार, जिसे [addMathShape](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addMathShape) द्वारा बनाया गया है, वह आकार है जिसमें समीकरण शामिल है।
- [MathPortion](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/) आकार के टेक्स्ट फ्रेम के भीतर गणितीय सामग्री संग्रहीत करता है।
- [MathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathparagraph/) एक या अधिक [MathBlock](https://reference.aspose.com/slides/python-java/aspose.slides/mathblock/) वस्तुओं को शामिल करता है।

नीचे के अधिकांश उदाहरण [MathematicalText](https://reference.aspose.com/slides/python-java/aspose.slides/mathematicaltext/) और [MathElementBase](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/) की प्रवाही विधियों का उपयोग करते हैं ताकि कोड संक्षिप्त और पढ़ने योग्य बना रहे।

MathML निर्यात परिदृश्यों के लिए, देखें [Python में प्रस्तुतियों से गणितीय समीकरण निर्यात करें](/slides/hi/python-java/exporting-math-equations/)।

## **समीकरण बनाएं**

यह उदाहरण [addMathShape](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addMathShape) का उपयोग करके एक गणितीय आकार बनाता है और पाइथागोरस सिद्धांत जोड़ता है:

![c वर्ग बराबर a वर्ग + b वर्ग समीकरण](powerpoint-math-equations_3.png)

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
[addMathShape](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addMathShape) एक आकार बनाता है जिसमें पहले से ही एक गणितीय पैराग्राफ शामिल होता है। पहले [MathPortion](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/) तक पहुँचें, [getMathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/#getMathParagraph) को कॉल करें, और इसमें गणितीय ब्लॉक्स या गणितीय तत्व जोड़ें।
{{% /alert %}}

### **गणितीय ब्लॉक्स को मिलाएँ**

जब समीकरण के भाग स्वतंत्र रूप से [MathBlock](https://reference.aspose.com/slides/python-java/aspose.slides/mathblock/) वस्तुओं के रूप में बनते हैं, तो उन्हें मिलाने के लिए [joinBlock](https://reference.aspose.com/slides/python-java/aspose.slides/mathblock/#joinBlock) का उपयोग करें। उदाहरण बाएँ ब्लॉक में `c² =` बनाता है और दाए ब्लॉक में `a² + b²` जोड़ता है। [setSuperscript](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setSuperscript) सभी तीन पावरों के लिए संपादन योग्य गणितीय सुपरसक्रिप्ट बनाता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addMathShape(20, 20, 600, 100)
    math_portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    math_paragraph = math_portion.getMathParagraph()

    left_block = MathBlock()
    left_block.add(MathematicalText("c").setSuperscript("2"))
    left_block.add(MathematicalText("="))

    right_block = MathBlock()
    right_block.add(MathematicalText("a").setSuperscript("2"))
    right_block.add(MathematicalText("+"))
    right_block.add(MathematicalText("b").setSuperscript("2"))

    combined_block = left_block.joinBlock(right_block)
    math_paragraph.add(combined_block)

    presentation.save("equation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

[joinBlock](https://reference.aspose.com/slides/python-java/aspose.slides/mathblock/#joinBlock) `left_block` को स्वयं लौटाता है, अब क्रम में दोनों भाग शामिल हैं, और `right_block` को खाली छोड़ देता है। संयुक्त ब्लॉक को केवल एक बार [MathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathparagraph/) में जोड़ें। `equation.pptx` को फिर खोलने के बाद, पैराग्राफ में एक ब्लॉक होगा जो `c² = a² + b²` को दर्शाता है, और सभी तीन पावर गणितीय सुपरसक्रिप्ट के रूप में संरक्षित रहते हैं।

[add](https://reference.aspose.com/slides/python-java/aspose.slides/mathblock/#add) को `left_block.add(right_block)` के रूप में कॉल करना एक ब्लॉक को सीधे दूसरे के अंदर नेस्ट करने का प्रयास करता है और `InvalidOperationException` उठाता है।

## **भिन्न जोड़ें**

[divide](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#divide) का उपयोग करके एक भिन्न बनाएँ। आप [MathFractionTypes](https://reference.aspose.com/slides/python-java/aspose.slides/mathfractiontypes/) के साथ भिन्न शैली चुन सकते हैं।

![एक झुका हुआ गणितीय भिन्न जो 1 को x से विभाजित दिखाता है](powerpoint-math-equations_4.png)

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

एक स्टैक्ड भिन्न के लिए, [MathFractionTypes.Bar](https://reference.aspose.com/slides/python-java/aspose.slides/mathfractiontypes/#Bar) का उपयोग करें:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathFractionTypes, MathematicalText

stacked_fraction = MathematicalText("x + 1").divide("y - 1", MathFractionTypes.Bar)
```

## **रैडिकल्स जोड़ें**

[radical](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#radical) का उपयोग करके वर्ग मूल, घन मूल या अन्य मूल बनाएँ। वर्तमान तत्व आधार बन जाता है, और तर्क डिग्री बन जाता है।

![x के नीचे मूल चिह्न के साथ एक n-थ मूल अभिव्यक्ति](powerpoint-math-equations_5.png)

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

### **वर्ग मूल की डिग्री दिखाएँ या छिपाएँ**

वर्ग मूल स्पष्ट 2 दिखा सकता है या परम्परागत √x संकेत का उपयोग कर सकता है। [MathRadical](https://reference.aspose.com/slides/python-java/aspose.slides/mathradical/) की [setHideDegree](https://reference.aspose.com/slides/python-java/aspose.slides/mathradical/#setHideDegree) विधि नियंत्रित करती है कि कौन सा रूप दिखाई दे। दोनों रूप डिग्री 2 और radicand x को संपादन योग्य समीकरण में रखते हैं।

![बाएँ में डिग्री दृश्यमान और दाएँ में छिपी हुई समान वर्ग मूल](square-root-degree.png)

उदाहरण समान वर्ग मूल को दो बार सहेजता है। `visible-degree.pptx` में 2 दृश्यमान है। `hidden-degree.pptx` में यह छिपी हुई है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    radical = MathematicalText("x").radical("2")
    math_block = MathBlock(radical)

    math_shape = slide.getShapes().addMathShape(20, 20, 200, 100)
    math_paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph()
    math_paragraph.add(math_block)

    radical.setHideDegree(False)
    presentation.save("visible-degree.pptx", SaveFormat.Pptx)

    radical.setHideDegree(True)
    presentation.save("hidden-degree.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **फ़ंक्शन और सीमाएँ जोड़ें**

[asArgumentOfFunction](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#asArgumentOfFunction) या [function](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#function) का उपयोग `sin(x)`, `log(x)` या कस्टम फ़ंक्शन नामों के लिए करें। सीमाओं के लिए, `lim` को [MathLimit](https://reference.aspose.com/slides/python-java/aspose.slides/mathlimit/) में रखें या [setLowerLimit](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setLowerLimit) का उपयोग करें।

![x का सीमा जब x अनन्त की ओर बढ़ता है](powerpoint-math-equations_8.png)

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

कस्टम फ़ंक्शन नाम के लिए, फ़ंक्शन नाम को वर्तमान तत्व बनाएँ और उसके तर्क के साथ [function](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#function) को कॉल करें:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathematicalText

custom_function = MathematicalText("f").function("x + 1")
```

## **N-ary ऑपरेटर्स और इंटीग्रल जोड़ें**

सारांश, संघ, प्रतिच्छेदन और अन्य बड़े ऑपरेटर्स के लिए [nary](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#nary) का उपयोग करें। इंटीग्रल के लिए [integral](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#integral) का उपयोग करें। दोनों विधियों से निचली और ऊपरी सीमाएँ निर्धारित की जा सकती हैं।

![निचली और ऊपरी सीमाओं के साथ एक सारांश](powerpoint-math-equations_7.png)

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

N-ary ऑपरेटर्स बड़े ऑपरेटर्स होते हैं जिनमें वैकल्पिक सीमाएँ हो सकती हैं। सरल ऑपरेटर्स जैसे `+`, `-`, और `=` आमतौर पर [MathematicalText](https://reference.aspose.com/slides/python-java/aspose.slides/mathematicaltext/) से जोड़े जाते हैं और अभिव्यक्ति में सम्मिलित किए जाते हैं।

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

पंक्तियों और स्तंभों के लिए [MathMatrix](https://reference.aspose.com/slides/python-java/aspose.slides/mathmatrix/) का उपयोग करें। मैट्रिस में डिफ़ॉल्ट रूप से ब्रैकेट नहीं होते, इसलिए जब कोष्ठक, वर्ग ब्रेस या कर्ली ब्रेस चाहिए तो मैट्रिस को घेरें।

![एक दो‑पंक्तीय गणित मैट्रिस जिसमें एक खाली सेल है](powerpoint-math-equations_10.png)

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

### **मौजूदा मैट्रिस संपादित करें**

मान लें कि एक रैखिक बीजगणित पाठ `matrix.pptx` में कोएफ़िशिएंट मैट्रिस से शुरू होता है, जो पिछले उदाहरण द्वारा सहेजा गया है। अगले अभ्यास के लिए, पहली समीकरण रखें, दूसरी को दो नई समीकरणों से बदलें, और वेरिएबल सेट को संशोधित करें। मौजूदा मैट्रिस को [MathMatrix](https://reference.aspose.com/slides/python-java/aspose.slides/mathmatrix/) के माध्यम से खोलें ताकि जो कोएफ़िशिएंट अभी भी लागू हैं वे बनाए रहें।

![पहली पंक्ति में 1, x और एक खाली सेल, तथा दूसरी पंक्ति में x, 2, y के साथ मूल दो‑पंक्तीय कोएफ़िशिएंट मैट्रिस](matrix-before-edit.png)

पंक्ति और स्तंभ सूचकांक शून्य से शुरू होते हैं और प्रत्येक कॉल पर वर्तमान मैट्रिस को दर्शाते हैं। सूचकांक 1 से पहले पंक्ति डालने से मूल दूसरी पंक्ति सूचकांक 2 पर चली जाती है। सूचकांक 2 के बाद डालने से एक पंक्ति अंत में जुड़ती है। पंक्ति 2 को हटाने से मूल दूसरी समीकरण हट जाती है और जुड़ी हुई पंक्ति एक स्थान ऊपर आ जाती है। स्तंभ उसी तरह शिफ्ट होते हैं।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathHorizontalAlignment, MathematicalText, Presentation, SaveFormat

presentation = Presentation("matrix.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    matrix = portion.getMathParagraph().get_Item(0).get_Item(0)

    matrix.insertRowBefore(1)
    matrix.insertRowAfter(2)
    matrix.deleteRow(2)

    matrix.insertColumnBefore(1)
    matrix.insertColumnAfter(3)
    matrix.deleteColumn(3)

    # नई कोशिकाएँ प्रारम्भ में खाली होती हैं। गैर‑शून्य गुणांक पहले सेट करें।
    matrix.set_Item(1, 0, MathematicalText("12"))
    matrix.set_Item(1, 1, MathematicalText("1"))
    matrix.set_Item(2, 2, MathematicalText("10"))
    matrix.set_Item(2, 3, MathematicalText("1"))
    for row in range(matrix.getRowCount()):
        for column in range(matrix.getColumnCount()):
            if matrix.get_Item(row, column) is None:
                matrix.set_Item(row, column, MathematicalText("0"))

    matrix.setColumnAlignment(0, MathHorizontalAlignment.Left)
    matrix.setColumnsAlignment(1, 3, MathHorizontalAlignment.Right)
    
    presentation.save("updated-matrix.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

[setColumnAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/mathmatrix/#setColumnAlignment) पहली स्तम्भ को बाएँ संरेखित करता है। [setColumnsAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/mathmatrix/#setColumnsAlignment) शेष तीन स्तम्भों को दाएँ, सूचकांक 1 से शुरू, संरेखित करता है। `updated-matrix.pptx` में मैट्रिस में तीन समीकरण और चार वेरिएबल हैं। मूल पहली‑पंक्ति के कोएफ़िशिएंट `1` और `x` अब पहली और तीसरी स्तम्भ में दिखते हैं।

![अपडेटेड तीन‑पंक्तीय मैट्रिस जिसमें पंक्तियाँ 1, 0, x, 0; 12, 1, 0, 0; और 0, 0, 10, 1 दिखाए गये हैं](matrix-after-edit.png)

## **समीकरण एरेज़ जोड़ें**

जब आपको संरेखित समीकरणों या अभिव्यक्तियों की लंबवत स्टैक की जरूरत हो तो [toMathArray](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#toMathArray) का उपयोग करें।

![ऊपर x और नीचे y के साथ एक लंबवत गणित एरे](powerpoint-math-equations_11.png)

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

### **आस‑पास के तत्वों के साथ एरे संरेखित करें**

[setBaseJustification](https://reference.aspose.com/slides/python-java/aspose.slides/matharray/#setBaseJustification) एरे को उसके बगल के गणितीय तत्वों के सापेक्ष लंबवत संरेखण नियंत्रित करता है। नीचे दिया गया उदाहरण पहले पंक्ति, एरे का केंद्र, और अंतिम पंक्ति के साथ संरेखण की तुलना करता है।

निम्न उदाहरण तीन समान एरे बनाता है, प्रत्येक में तीन पंक्तियाँ हैं और पड़ोसी तत्व `A=` और `=B` हैं। सभी गणितीय पाठ Cambria Math 24 पॉइंट पर हैं। केवल एरे संरेखण बदलता है।

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

नीचे की तुलना में PowerPoint में सहेजी प्रस्तुति दिखती है। प्रत्येक एरे के बगल में `A=` और `=B` की स्थिति पर ध्यान दें।

![PowerPoint में टॉप, सेंटर और बॉटम संरेखण वाला समीकरण एरे और समान पड़ोसी तत्व](equation-array-alignment.png)

### **पंक्ति स्पेसिंग कॉन्फ़िगर करें**

[setRowSpacingRule](https://reference.aspose.com/slides/python-java/aspose.slides/matharray/#setRowSpacingRule) एरे के भीतर पंक्तियों के लिए स्पेसिंग नियम चुनता है। [setRowSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/matharray/#setRowSpacing) स्पष्ट स्पेसिंग नियम के लिए संख्यात्मक मान प्रदान करता है और प्रीसेट नियमों द्वारा अनदेखा किया जाता है।

सटीक स्पेसिंग के लिए मान पॉइंट में मापा जाता है। अनुपातिक स्पेसिंग के लिए इसे आधी‑लाइन में मापा जाता है: उदाहरण में मान `3` 1.5 लाइनों को दर्शाता है। स्पष्ट मान निर्दिष्ट करते समय दोनों गुणधर्म सेट करें; केवल संख्यात्मक मान बदलने से स्पेसिंग नियम नहीं चुना जाता।

नीचे का उदाहरण समान समीकरण, संरेखण, और फ़ॉन्ट सेटिंग्स के साथ पाँच प्रस्तुतियों को सहेजता है। पहले तीन प्रीसेट हैं; अंतिम दो स्पष्ट मान दिखाते हैं।

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

एरे पंक्ति स्पेसिंग पैराग्राफ स्पेसिंग से अलग होती है। [setSpaceBefore](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setSpaceBefore) और [setSpaceAfter](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setSpaceAfter) कंटेनिंग पैराग्राफ के चारों ओर अंतराल जोड़ते हैं, न कि एरे पंक्तियों के बीच। इसी प्रकार, [MathParagraph.setJustification](https://reference.aspose.com/slides/python-java/aspose.slides/mathparagraph/#setJustification) पूरे गणित पैराग्राफ को क्षैतिज रूप से स्थित करता है; यह एरे की लंबवत संरेखण सेटिंग को प्रतिस्थापित नहीं करता।

## **त्रिकोणमितीय फ़ंक्शन जोड़ें**

जब तर्क वर्तमान तत्व है और फ़ंक्शन नाम ज्ञात है, तो [asArgumentOfFunction](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#asArgumentOfFunction) का उपयोग करें।

![त्रिकोणमितीय फ़ंक्शन cos को 2x पर लागू किया गया है](powerpoint-math-equations_6.png)

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

## **सबस्क्रिप्ट और सुपरसक्रिप्ट जोड़ें**

इंडेक्स और पावर के लिए सबस्क्रिप्ट और सुपरसक्रिप्ट हेल्पर का उपयोग करें। जब इंडेक्स बेस के बाएँ पक्ष में दिखने चाहिए, तो [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setSubSuperscriptOnTheLeft) का उपयोग करें।

![बाएँ‑साइड सबस्क्रिप्ट 1 और सुपरसक्रिप्ट n के साथ एक बड़ा Y](powerpoint-math-equations_9.png)

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

### **दाएँ सबस्क्रिप्ट और सुपरसक्रिप्ट संरेखित करें**

जब एक सबस्क्रिप्ट और एक सुपरसक्रिप्ट एक ही बेस साझा करते हैं, तो [MathRightSubSuperscriptElement](https://reference.aspose.com/slides/python-java/aspose.slides/mathrightsubsuperscriptelement/) का उपयोग करें। इसकी [setAlignScripts](https://reference.aspose.com/slides/python-java/aspose.slides/mathrightsubsuperscriptelement/#setAlignScripts) विधि उनके क्षैतिज स्थितियों को नियंत्रित करती है। डिफ़ॉल्ट `False` पर प्रत्येक स्क्रिप्ट बेस के रूपरेखा का अनुसरण करती है। `True` पर स्क्रिप्ट समान क्षैतिज स्थिति से शुरू होती हैं।

यह उदाहरण दो समान संपादन योग्य अभिव्यक्तियों को बगल में रखता है। दोनों 72‑पॉइंट Cambria Math में गणितीय इटैलिक f (U+1D453) के साथ सबस्क्रिप्ट 1 और सुपरसक्रिप्ट 2 उपयोग करते हैं। f की ढलान अंतर को PowerPoint में स्पष्ट बनाती है। उदाहरण चलाने से पहले Cambria Math स्थापित करें।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, MathBlock, MathematicalText, MathRightSubSuperscriptElement
from asposeslides.api import PortionFormat, Presentation, SaveFormat, SlideSizeScaleType

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(900, 250, SlideSizeScaleType.DoNotScale)
    slide = presentation.getSlides().get_Item(0)

    text_format = PortionFormat()
    font = FontData("Cambria Math")
    text_format.setFontHeight(72)
    text_format.setLatinFont(font)

    for left, align_scripts in [(40, False), (480, True)]:
        shape = slide.getShapes().addMathShape(left, 75, 380, 150)
        base = MathematicalText("\U0001D453", text_format)
        subscript = MathematicalText("1", text_format)
        superscript = MathematicalText("2", text_format)
        scripts = MathRightSubSuperscriptElement(base, subscript, superscript)
        scripts.setAlignScripts(align_scripts)

        portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
        portion.getPortionFormat().setFontHeight(text_format.getFontHeight())
        portion.getPortionFormat().setLatinFont(font)
        block = MathBlock(scripts)
        portion.getMathParagraph().add(block)

    presentation.save("aligned-scripts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![बाएँ पर setAlignScripts False और दाएँ पर True के साथ दो संपादन योग्य अभिव्यक्तियाँ](aligned-scripts.png)

बाएँ पर, सबस्क्रिप्ट फ की रूपरेखा का पालन करते हुए बाएँ अधिक दूर से शुरू होती है। दाएँ पर, दोनों स्क्रिप्ट के बाएँ किनारे संरेखित होते हैं।

## **डिलीमीटर जोड़ें**

[enclose](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#enclose) का उपयोग करके किसी अभिव्यक्ति को डिलीमीटर के भीतर रखें। आप कई तत्वों वाली डिलीमीटर अभिव्यक्तियों के लिए अलगाव अक्षर भी सेट कर सकते हैं।

![x, y, और z को ऊर्ध्वाधर बार द्वारा अलग किया गया डिलीमीटर अभिव्यक्ति](powerpoint-math-equations_13.png)

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

### **डिलीमीटर का आकार और संरेखण**

[parentheses] को लंबा बनाने के लिए [setGrowToMatchOperandHeight](https://reference.aspose.com/slides/python-java/aspose.slides/mathdelimiter/#setGrowToMatchOperandHeight) को `True` पास करें, या सामान्य आकार बनाए रखने के लिए `False` पास करें। [setDelimiterShape](https://reference.aspose.com/slides/python-java/aspose.slides/mathdelimiter/#setDelimiterShape) के साथ दो में से एक [MathDelimiterShape](https://reference.aspose.com/slides/python-java/aspose.slides/mathdelimitershape/) मान चुनें। `Centered` पैरेंथाइसिस को गणितीय अक्ष पर केंद्रित करता है, जो बराबर चिह्न के मध्य से चलता है। `Match` उन्हें शामिल सामग्री के साथ संरेखित करता है। दोनों सेटिंग केवल डिलीमीटर को प्रभावित करती हैं; अंदर की अभिव्यक्ति वही रहती है।

उदाहरण `x` के घात में एक भिन्न रखता है जिससे अभिव्यक्ति बेसलाइन के ऊपर अधिक विस्तृत होती है। सभी चार समीकरण समान पैरेंथाइसिस और फ़ॉन्ट सेटिंग्स का उपयोग करते हैं।

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

PowerPoint में पंक्तियों की तुलना करके वृद्धि प्रभाव देखें। शीर्ष पंक्ति में पैरेंथाइसिस घात को घेरते हुए बढ़ते हैं और दोनों आकार समान दिखते हैं। नीचे की पंक्ति में वृद्धि बंद है। बाएँ (`Centered`) छोटे पैरेंथाइसिस बराबर चिह्न के साथ संरेखित होते हैं, जबकि दाएँ (`Match`) अधिक ऊँचे होते हैं।

![चार समीकरण PowerPoint में जहाँ ऊपर वृद्धि सक्रिय और नीचे निष्क्रिय है, बाएँ `Centered` और दाएँ `Match`](delimiter-sizing.png)

## **बॉर्डर बॉक्स जोड़ें**

भिन्न पर [toBorderBox](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#toBorderBox) कॉल करके पूरी अभिव्यक्ति को फ्रेम करें। लौटाया गया [MathBorderBox](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/) डिफ़ॉल्ट रूप से चारों ओर दिखाता है। व्यक्तिगत किनारों को हटाने के लिए [setHideTop](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setHideTop), [setHideBottom](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setHideBottom), [setHideLeft](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setHideLeft), और [setHideRight](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setHideRight) का उपयोग करें।

उदाहरण में एक ही भिन्न के छह प्रतिलिपियाँ एक स्लाइड पर रखी गईं। रद्दीकरण दिखाने के लिए सभी चार किनारे छिपाएँ और उठता हुआ तिरकोण (↗) के लिए [setStrikethroughBottomLeftToTopRight](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setStrikethroughBottomLeftToTopRight) को `True` पास करें या गिरता हुआ तिरकोण (↘) के लिए [setStrikethroughTopLeftToBottomRight](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setStrikethroughTopLeftToBottomRight) को `True` पास करें। आप किसी भी संयोजन में दृश्यमान किनारों के साथ [setStrikethroughHorizontal](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setStrikethroughHorizontal) या [setStrikethroughVertical](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setStrikethroughVertical) का भी उपयोग कर सकते हैं।

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

![छह संपादन योग्य भिन्न PowerPoint में। शीर्ष पंक्ति: पूर्ण बॉर्डर, निचला और बायाँ पक्ष, उठता तिरकोण। निचली पंक्ति: गिरता तिरकोण, क्षैतिज स्ट्राइक, पूर्ण बॉर्डर के साथ लंबवत स्ट्राइक।](border-box-fractions.png)

इस भिन्न पर, क्षैतिज स्ट्राइक भिन्न बार के ऊपर ओवरलैप करता है। लंबवत स्ट्राइक अंश और हर दोनों को काटता है जबकि चारों ओर का बॉर्डर दृश्य रहता है। ये रेखाएँ पूरी अभिव्यक्ति को सजाती हैं। सामान्य टेक्स्ट स्ट्राइकथ्रू केवल टेक्स्ट रन के अक्षरों पर लागू होता है। PowerPoint में प्रस्तुति फिर से खोलने के बाद भी आप अंश और हर को स्वतंत्र रूप से संपादित कर सकते हैं।

## **फ़ैंटम तत्वों के साथ दृश्यता और लेआउट नियंत्रित करें**

किसी अभिव्यक्ति को [MathPhantom](https://reference.aspose.com/slides/python-java/aspose.slides/mathphantom/) में रखें ताकि उसकी दृश्यता और वह समीकरण में जो स्थान लेता है, स्वतंत्र रूप से नियंत्रित हो सके। [MathPhantom](https://reference.aspose.com/slides/python-java/aspose.slides/mathphantom/) की विधियाँ निम्नांकित को नियंत्रित करती हैं:

| Method | Effect |
| --- | --- |
| [setShow](https://reference.aspose.com/slides/python-java/aspose.slides/mathphantom/#setShow) | `False` पास करने से अभिव्यक्ति छिप जाती है। इसके आयाम लेआउट में तब भी योगदान देते हैं जब तक नीचे दी गई विधियाँ `True` न हों। |
| [setZeroWidth](https://reference.aspose.com/slides/python-java/aspose.slides/mathphantom/#setZeroWidth) | अभिव्यक्ति की क्षैतिज चौड़ाई को शून्य मानें, जिससे पड़ोसी तत्व एक‑दूसरे के पास आ सकें। |
| [setZeroAsc](https://reference.aspose.com/slides/python-java/aspose.slides/mathphantom/#setZeroAsc) | उसकी ऊपर की सीमा (बेसलाइन के ऊपर की ऊँचाई) को शून्य मानें, जिससे ऊपर की जगह कम हो सकती है। |
| [setZeroDesc](https://reference.aspose.com/slides/python-java/aspose.slides/mathphantom/#setZeroDesc) | उसकी नीचे की सीमा (बेसलाइन के नीचे की गहराई) को शून्य मानें, जिससे भिन्न बार या अन्य सामग्री नीचे की जगह कम हो सकती है। |

बेसलाइन वह संदर्भ रेखा है जिस पर सामान्य गणितीय अक्षर बसे होते हैं। सामग्री को छिपाने से उसके आयाम नहीं हटते, और आयाम को शून्य मानने से अभिव्यक्ति हटती नहीं है। मूल अभिव्यक्ति अभी भी [getBase](https://reference.aspose.com/slides/python-java/aspose.slides/mathphantom/#getBase) द्वारा उपलब्ध है। फिर से दिखाने के लिए [setShow](https://reference.aspose.com/slides/python-java/aspose.slides/mathphantom/#setShow) को `True` पास करें; आयाम सेटिंग अपरिवर्तित रहती है।

नीचे का उदाहरण पाँच बगल‑बगल वैरिएंट बनाता है: एक दृश्यमान भिन्न, एक छिपा हुआ भिन्न जो जगह रखता है, और तीन छिपे हुए भिन्न जिनमें एक आयाम शून्य किया गया है। प्रत्येक वैरिएंट समान आसपास की अभिव्यक्ति और 24‑पॉइंट Cambria Math का उपयोग करता है। सभी समीकरण आकार समान शीर्ष स्थिति पर हैं, जिसे ग्रे गाइड द्वारा दर्शाया गया है। बाहरी भिन्न के अंश में फ़ैंटम रखने से लंबवत लेआउट बदलावों को देखना आसान हो जाता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, MathBlock, MathFraction, MathematicalText, MathPhantom, Presentation, SaveFormat, ShapeType, SlideSizeScaleType, TextAnchorType
from java.awt import Color


def create_text(value):
    text = MathematicalText(value)
    text.getFormat().setFontHeight(24)
    text.getFormat().setLatinFont(FontData("Cambria Math"))
    return text


presentation = Presentation()
try:
    presentation.getSlideSize().setSize(1000, 180, SlideSizeScaleType.DoNotScale)
    slide = presentation.getSlides().get_Item(0)

    labels = ("Visible", "Hidden: reserves space", "Hidden: ZeroWidth", "Hidden: ZeroAsc", "Hidden: ZeroDesc")

    guide = slide.getShapes().addAutoShape(ShapeType.Line, 10, 60, 980, 0)
    guide.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    guide.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.LIGHT_GRAY)

    for index, name in enumerate(labels):
        left = 10 + index * 200
        
        label = slide.getShapes().addAutoShape(ShapeType.Rectangle, left, 10, 190, 30)
        label.getFillFormat().setFillType(FillType.NoFill)
        label.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
        label.getTextFrame().setText(name)
        label_format = label.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat()
        label_format.setFontHeight(14)
        label_format.getFillFormat().setFillType(FillType.Solid)
        label_format.getFillFormat().getSolidFillColor().setColor(Color.BLACK)

        fraction_numerator = create_text("a+b")
        fraction_denominator = create_text("c+d")
        fraction = MathFraction(fraction_numerator, fraction_denominator)
        phantom = MathPhantom(fraction)
        phantom.setShow(index == 0)
        phantom.setZeroWidth(index == 2)
        phantom.setZeroAsc(index == 3)
        phantom.setZeroDesc(index == 4)

        left_text = create_text("x+")
        right_text = create_text("+y")
        numerator = MathBlock(left_text).join(phantom).join(right_text)
        denominator = create_text("z")
        equation = MathFraction(numerator, denominator)

        shape = slide.getShapes().addMathShape(left, 60, 190, 100)
        shape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Top)
        math_portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
        math_paragraph = math_portion.getMathParagraph()
        math_block = MathBlock(equation)
        math_paragraph.add(math_block)

    presentation.save("math-phantom.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![एक दृश्यमान भिन्न, एक छिपा हुआ भिन्न जो जगह रखता है, और ZeroWidth, ZeroAsc, या ZeroDesc के साथ तीन छिपे हुए भिन्नों की तुलना करते हुए पाँच समीकरण](math-phantom.png)

## **टर्म समूहित करें**

[group](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#group) का उपयोग करके अभिव्यक्ति के ऊपर या नीचे समूहिंग चरित्र रखें। समूहित टर्म को लेबल करने के लिए सीमा जोड़ें।

![x + y अभिव्यक्ति को समूहित करके नीचे कोई भी टेक्स्ट लेबल के साथ](powerpoint-math-equations_15.png)

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

## **गणितीय तत्वों का स्वरूपित करें**

स्वरूपण हेल्पर केवल तब उपयोग करें जब वे सूत्र को स्पष्ट बनाते हों। उदाहरण के लिए, [overbar](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#overbar) गणितीय तत्व के ऊपर एक बार रखता है।

![overbar के साथ ABC गणितीय अभिव्यक्ति](powerpoint-math-equations_14.png)

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

एक मौजूदा समीकरण में टेक्स्ट को स्वरूपित करने के लिए, प्रत्येक गणित ब्लॉक के तत्व वृक्ष को ट्रैवर्स करें। [MathElementBase.getChildren](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#getChildren) केवल सीधी संतानें लौटाता है, इसलिए नेस्टेड संरचनाओं जैसे भिन्न, स्क्रिप्ट, रैडिकल आदि तक पहुँचने के लिए इसे पुनरावर्ती रूप से कॉल करें। वर्तमान तत्व और उसकी संतानें दोनों की जांच करें ताकि जब वह [MathematicalText](https://reference.aspose.com/slides/python-java/aspose.slides/mathematicaltext/) हो तो प्रारंभिक तत्व भी शामिल हो।

यह उदाहरण मानता है कि `input.pptx` में `z = xᵢ / ∛y` जैसा समीकरण है, जिसमें अंश के अंश में सबस्क्रिप्ट और हर में रैडिकल है। केवल ब्लॉक के शीर्ष‑स्तर तत्वों को प्रोसेस करने से भिन्न के भीतर का टेक्स्ट छूट जाता। यह उदाहरण स्लाइड टेक्स्ट फ़्रेम में गणितीय भाग खोजता है, उनके ब्लॉकों को [MathPortion.getMathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/#getMathParagraph) द्वारा प्राप्त करता है, और प्रत्येक टेक्स्ट तत्व के [getFormat](https://reference.aspose.com/slides/python-java/aspose.slides/mathematicaltext/#getFormat) विधि के माध्यम से [setFontHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setFontHeight) से फ़ॉन्ट आकार 28 पॉइंट सेट करता है।

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

सहेजी गई प्रस्तुति प्रत्येक प्रोसेस किए गए समीकरण के हर स्तर पर अद्यतन टेक्स्ट स्वरूपण रखती है, जबकि उसका टेक्स्ट सामग्री और गणितीय संरचना समान रहती है।

## **त्वरित संदर्भ**

| कार्य | मुख्य API |
| --- | --- |
| गणितीय पाठ बनाना | [MathematicalText](https://reference.aspose.com/slides/python-java/aspose.slides/mathematicaltext/) |
| तत्वों को मिलाना | [MathElementBase.join](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#join) |
| अंश बनाना | [MathElementBase.divide](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#divide) |
| सुपरसक्रिप्ट या सबस्क्रिप्ट जोड़ना | [setSuperscript](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setSuperscript), [setSubscript](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setSubscript) |
| फ़ंक्शन जोड़ना | [function](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#function), [asArgumentOfFunction](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#asArgumentOfFunction) |
| रैडिकल जोड़ना | [MathElementBase.radical](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#radical) |
| सीमाएँ जोड़ना | [setLowerLimit](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setLowerLimit), [setUpperLimit](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setUpperLimit) |
| बाएँ‑साइड स्क्रिप्ट जोड़ना | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setSubSuperscriptOnTheLeft) |
| सारांश और इंटीग्रल जोड़ना | [nary](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#nary), [integral](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#integral) |
| मैट्रिस जोड़ना | [MathMatrix](https://reference.aspose.com/slides/python-java/aspose.slides/mathmatrix/) |
| समीकरण एरेज़ जोड़ना | [toMathArray](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#toMathArray) |
| डिलीमीटर जोड़ना | [enclose](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#enclose) |
| बार और बॉर्डर जोड़ना | [overbar](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#overbar), [toBorderBox](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#toBorderBox) |
| टर्म समूहित करना | [group](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#group) |

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं मौजूदा PowerPoint समीकरण को संपादित कर सकता हूँ?**

हाँ। प्रस्तुति खोलें, उस आकार को खोजें जिसमें [MathPortion](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/) है, [getMathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/#getMathParagraph) को कॉल करें, और उस पैराग्राफ में गणित ब्लॉकों को अपडेट करें।

**क्या समीकरण संपादन योग्य PowerPoint गणित के रूप में सहेजे जाते हैं?**

हाँ। PPTX में सहेजते समय, Aspose.Slides समीकरण को संपादन योग्य Office गणित सामग्री के रूप में लिखता है।

**क्या मैं समीकरणों को LaTeX में निर्यात कर सकता हूँ?**

हाँ। समीकरण के [MathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathparagraph/) को उसके [MathPortion](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/) से प्राप्त करके, [MathParagraph.toLatex](https://reference.aspose.com/slides/python-java/aspose.slides/mathparagraph/#toLatex) को कॉल करें। पूर्ण उदाहरण के लिए देखें [Python में प्रस्तुतियों से गणितीय समीकरण निर्यात करें](/slides/hi/python-java/exporting-math-equations/#export-math-equations-to-latex)।