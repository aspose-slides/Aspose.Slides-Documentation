---
title: JavaScript में PowerPoint प्रस्तुतियों में गणितीय समीकरण जोड़ें
linktitle: PowerPoint गणितीय समीकरण
type: docs
weight: 80
url: /hi/nodejs-java/powerpoint-math-equations/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java के साथ PowerPoint PPT और PPTX में गणितीय समीकरण सम्मिलित करें और संपादित करें, जो OMML, स्वरूपण नियंत्रण, और स्पष्ट JavaScript कोड उदाहरणों का समर्थन करता है।"
---
## **अवलोकन**

PowerPoint समीकरणों को Office Math Markup Language (OMML) के रूप में संग्रहीत करता है। Aspose.Slides for Node.js via Java का उपयोग करके, आप समान प्रकार की गणितीय सामग्री प्रोग्रामmatically बना सकते हैं: भाग, मूल, फ़ंक्शन, सीमाएँ, N-ary ऑपरेटर, मैट्रिक्स, एरे, और स्वरूपित गणितीय ब्लॉक।

PowerPoint में, उपयोगकर्ता सामान्यतः समीकरण **Insert > Equation** से जोड़ते हैं:

![PowerPoint Insert टैब में Equation कमांड चयनित](powerpoint-math-equations_1.png)

परिणाम स्लाइड पर संपादनीय गणितीय पाठ है:

![संपादनीय गणितीय समीकरण सम्मिलित PowerPoint स्लाइड](powerpoint-math-equations_2.png)

Aspose.Slides इस गणितीय पाठ को तीन मुख्य वस्तुओं के माध्यम से बनाता है:

- A math shape, created with [addMathShape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/shapecollection/#addMathShape), is the shape that contains the equation.
- [MathPortion](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/mathportion/) stores math content inside the shape text frame.
- [MathParagraph](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/mathparagraph/) contains one or more [MathBlock](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/mathblock/) objects.

अधिकतर उदाहरण नीचे [MathematicalText](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/mathematicaltext/) और [MathElementBase](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/mathelementbase/) की फ़्लुएंट विधियों का उपयोग करके कोड को छोटा और पढ़ने योग्य बनाते हैं।

MathML निर्यात परिदृश्यों के लिए, देखें [Export Math Equations from Presentations in Node.js via Java](/slides/hi/nodejs-java/exporting-math-equations/)।

## **एक समीकरण बनाएं**

यह उदाहरण एक गणितीय आकार बनाता है और पाइथागोरस प्रमेय जोड़ता है:

![समीकरण c वर्ग बराबर a वर्ग प्लस b वर्ग](powerpoint-math-equations_3.png)

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 120);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let equation = new aspose.slides.MathematicalText("c")
            .setSuperscript("2")
            .join("=")
            .join(new aspose.slides.MathematicalText("a").setSuperscript("2"))
            .join("+")
            .join(new aspose.slides.MathematicalText("b").setSuperscript("2"));

    mathParagraph.add(equation);

    presentation.save("pythagorean-theorem.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="primary" %}}
`addMathShape` एक ऐसा आकार बनाता है जिसमें पहले से ही एक गणित पैराग्राफ होता है। पहला `MathPortion` प्राप्त करें, उसका `MathParagraph` लें, और उसमें गणित ब्लॉक या गणित तत्व जोड़ें।
{{% /alert %}}

## **भिन्न जोड़ें**

भिन्न बनाने के लिए [`divide`](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/mathelementbase/) का उपयोग करें। आप [MathFractionTypes](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/mathfractiontypes/) के साथ एक भिन्न शैली चुन सकते हैं।

![एक झुका हुआ गणितीय भिन्न जहाँ एक को x से विभाजित किया गया है](powerpoint-math-equations_4.png)

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let fraction = new aspose.slides.MathematicalText("1")
            .divide("x", aspose.slides.MathFractionTypes.Skewed);

    mathParagraph.add(new aspose.slides.MathBlock(fraction));

    presentation.save("fraction.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

स्टैक्ड भिन्न के लिए, `MathFractionTypes.Bar` का उपयोग करें:

```javascript
let stackedFraction = new aspose.slides.MathematicalText("x + 1").divide("y - 1", aspose.slides.MathFractionTypes.Bar);
```

## **रैडिकल जोड़ें**

एक वर्गमूल, घनमूल या अन्य मूल बनाने के लिए [`radical`](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/mathelementbase/) का उपयोग करें। वर्तमान तत्व बेस बन जाता है, और तर्क डिग्री बन जाता है।

![एक n-वें मूल (रैडिकल) अभिव्यक्ति जहाँ x रैडिकल चिह्न के नीचे है](powerpoint-math-equations_5.png)

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let radical = new aspose.slides.MathematicalText("x")
            .radical("n");

    mathParagraph.add(new aspose.slides.MathBlock(radical));

    presentation.save("radical.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **फ़ंक्शन और सीमाएँ जोड़ें**

फ़ंक्शन जैसे `sin(x)`, `log(x)` या कस्टम फ़ंक्शन नामों के लिए [`asArgumentOfFunction`](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/mathelementbase/) या [`function`](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/mathelementbase/) का उपयोग करें। सीमाओं के लिए, `lim` को एक [MathLimit](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/mathlimit/) में रखें या [`setLowerLimit`](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/mathelementbase/) का उपयोग करें।

![जब x अनंत की ओर बढ़ता है तो x की सीमा](powerpoint-math-equations_8.png)

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let limit = new aspose.slides.MathematicalText("lim")
            .setLowerLimit("x\u2192\u221E")
            .function("x");

    mathParagraph.add(new aspose.slides.MathBlock(limit));

    presentation.save("functions-and-limits.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

कस्टम फ़ंक्शन नाम के लिए, फ़ंक्शन नाम को वर्तमान तत्व बनाएं:

```javascript
let customFunction = new aspose.slides.MathematicalText("f").function("x + 1");
```

## **N-ary ऑपरेटर और समाकल जोड़ें**

योग, संघ, अंतःक्रिया और अन्य बड़े ऑपरेटरों के लिए [`nary`](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/mathelementbase/) का उपयोग करें। समाकलों के लिए [`integral`](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/mathelementbase/) का उपयोग करें। दोनों विधियों से आप निचली और ऊपरी सीमाएँ सेट कर सकते हैं।

![निचली और ऊपरी सीमाओं के साथ एक योग](powerpoint-math-equations_7.png)

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 120);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let summationBase = new aspose.slides.MathematicalText("x")
            .setSuperscript("k")
            .join(new aspose.slides.MathematicalText("a").setSuperscript("n-k"));

    let summation = summationBase.nary(aspose.slides.MathNaryOperatorTypes.Summation, "k=0", "n");

    mathParagraph.add(new aspose.slides.MathBlock(summation));

    presentation.save("nary-operators.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

N-ary ऑपरेटर बड़े ऑपरेटरों के लिए होते हैं जिनमें वैकल्पिक सीमाएँ हो सकती हैं। `+`, `-` और `=` जैसे साधारण ऑपरेटर आमतौर पर `MathematicalText` के रूप में जोड़े जाते हैं और अभिव्यक्ति में सम्मिलित होते हैं।

समाकल के लिए, `integral` का उपयोग करें:

```javascript
let integralBase = new aspose.slides.MathematicalText("x").join(new aspose.slides.MathematicalText("dx").toBox());
let integral = integralBase.integral(aspose.slides.MathIntegralTypes.Simple, "0", "1");
```

## **मैट्रिक्स जोड़ें**

पंक्तियों और स्तंभों के लिए [MathMatrix](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/mathmatrix/) का उपयोग करें। मैट्रिक्स में डिफ़ॉल्ट रूप से कोष्ठक नहीं होते, इसलिए आवश्यक होने पर कोष्ठक, ब्रैकेट या कर्ली ब्रेसेस के साथ घेरें।

![एक दो-पंक्तियों वाला गणितीय मैट्रिक्स जिसमें एक खाली सेल है](powerpoint-math-equations_10.png)

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 120);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let matrix = new aspose.slides.MathMatrix(2, 3);
    matrix.set_Item(0, 0, new aspose.slides.MathematicalText("1"));
    matrix.set_Item(0, 1, new aspose.slides.MathematicalText("x"));
    matrix.set_Item(1, 0, new aspose.slides.MathematicalText("x"));
    matrix.set_Item(1, 1, new aspose.slides.MathematicalText("2"));
    matrix.set_Item(1, 2, new aspose.slides.MathematicalText("y"));

    mathParagraph.add(new aspose.slides.MathBlock(matrix));

    presentation.save("matrix.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **समीकरण एरे जोड़ें**

जब आपको संरेखित समीकरण या अभिव्यक्तियों का लंबवत स्टैक चाहिए, तो [`toMathArray`](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/mathelementbase/) का उपयोग करें।

![एक लंबवत गणितीय एरे जहाँ x y के ऊपर है](powerpoint-math-equations_11.png)

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 140);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let equationArray = new aspose.slides.MathematicalText("x")
            .join("y")
            .toMathArray();

    mathParagraph.add(new aspose.slides.MathBlock(equationArray));

    presentation.save("equation-array.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **त्रिकोणमितीय फ़ंक्शन जोड़ें**

जब तर्क वर्तमान तत्व हो और फ़ंक्शन नाम ज्ञात हो, तो [`asArgumentOfFunction`](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/mathelementbase/) का उपयोग करें।

![त्रिकोणमितीय फ़ंक्शन cos को 2x पर लागू किया गया](powerpoint-math-equations_6.png)

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let cosine = new aspose.slides.MathematicalText("2x")
            .asArgumentOfFunction(aspose.slides.MathFunctionsOfOneArgument.Cos);

    mathParagraph.add(new aspose.slides.MathBlock(cosine));

    presentation.save("trigonometric-function.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **सबस्क्रिप्ट और सुपरस्क्रिप्ट जोड़ें**

इंडेक्स और घातांक के लिए सबस्क्रिप्ट और सुपरस्क्रिप्ट सहायक का उपयोग करें। जब इंडेक्स बेस के बाएँ पक्ष में दिखने चाहिए, तो [`setSubSuperscriptOnTheLeft`](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/mathelementbase/) का उपयोग करें।

![एक बड़े Y के बाएँ पक्ष पर सबस्क्रिप्ट 1 और सुपरस्क्रिप्ट n](powerpoint-math-equations_9.png)

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let scripts = new aspose.slides.MathematicalText("Y")
            .setSubSuperscriptOnTheLeft("1", "n");

    mathParagraph.add(new aspose.slides.MathBlock(scripts));

    presentation.save("subscript-superscript.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **डिलीमीटर जोड़ें**

एक अभिव्यक्ति को डिलीमीटर के भीतर रखने के लिए [`enclose`](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/mathelementbase/) का उपयोग करें। कई तत्वों वाली डिलीमीटर अभिव्यक्तियों के लिए आप विभाजक अक्षर भी सेट कर सकते हैं।

![एक डिलीमीटर अभिव्यक्ति जिसमें x, y, और z को लंबवत बार द्वारा अलग किया गया है](powerpoint-math-equations_13.png)

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let delimiter = new aspose.slides.MathematicalText("x")
            .join("y")
            .join("z")
            .enclose(java.newChar('<'), java.newChar('>'));
    delimiter.setSeparatorCharacter(java.newChar('|'));

    mathParagraph.add(new aspose.slides.MathBlock(delimiter));

    presentation.save("delimiters.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **बॉर्डर बॉक्स जोड़ें**

जब समीकरण स्वयं को फ्रेम में दिखाना हो, तो [`toBorderBox`](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/mathelementbase/) का उपयोग करें।

![एक बॉक्स्ड समीकरण जहाँ a वर्ग बराबर b वर्ग प्लस c वर्ग है](powerpoint-math-equations_12.png)

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let boxedEquation = new aspose.slides.MathematicalText("a")
            .setSuperscript("2")
            .join("=")
            .join(new aspose.slides.MathematicalText("b").setSuperscript("2"))
            .join("+")
            .join(new aspose.slides.MathematicalText("c").setSuperscript("2"))
            .toBorderBox();

    mathParagraph.add(new aspose.slides.MathBlock(boxedEquation));

    presentation.save("border-box.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **टर्म्स को समूहित करें**

एक अभिव्यक्ति के ऊपर या नीचे समूहित अक्षर रखने के लिए [`group`](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/mathelementbase/) का उपयोग करें। समूहित टर्म्स को लेबल करने के लिए एक सीमा जोड़ें।

![अभिव्यक्ति x + y को समूहित किया गया है और उसके नीचे लेबल कोई भी टेक्स्ट है](powerpoint-math-equations_15.png)

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 120);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let grouped = new aspose.slides.MathematicalText("x + y")
            .group(java.newChar('\u23DF'), aspose.slides.MathTopBotPositions.Bottom, aspose.slides.MathTopBotPositions.Top)
            .setLowerLimit("any text");

    mathParagraph.add(new aspose.slides.MathBlock(grouped));

    presentation.save("grouped-terms.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **गणितीय तत्वों को स्वरूपित करें**

फ़ॉर्मेटिंग सहायक केवल तभी उपयोग करें जब वे सूत्र को स्पष्ट करें। उदाहरण के लिए, [`overbar`](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/mathelementbase/) एक गणितीय तत्व के ऊपर एक बार रखता है।

![एक गणितीय अभिव्यक्ति ABC के ऊपर एक ओवरबार](powerpoint-math-equations_14.png)

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let overbar = new aspose.slides.MathematicalText("ABC").overbar();

    mathParagraph.add(new aspose.slides.MathBlock(overbar));

    presentation.save("overbar.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **त्वरित संदर्भ**

| कार्य | मुख्य API |
| --- | --- |
| गणितीय पाठ बनाएं | [MathematicalText](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/mathematicaltext/) |
| तत्वों को संयोजित करें | [join](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/mathelementbase/) |
| भिन्न बनाएं | [divide](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/mathelementbase/) |
| सुपरस्क्रिप्ट या सबस्क्रिप्ट जोड़ें | [setSuperscript](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/mathelementbase/), [setSubscript](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/mathelementbase/) |
| फ़ंक्शन जोड़ें | [function](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/mathelementbase/), [asArgumentOfFunction](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/mathelementbase/) |
| रैडिकल जोड़ें | [radical](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/mathelementbase/) |
| सीमाएँ जोड़ें | [setLowerLimit](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/mathelementbase/), [setUpperLimit](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/mathelementbase/) |
| बाएँ-साइड स्क्रिप्ट जोड़ें | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/mathelementbase/) |
| योग और समाकल जोड़ें | [nary](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/mathelementbase/), [integral](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/mathelementbase/) |
| मैट्रिक्स जोड़ें | [MathMatrix](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/mathmatrix/) |
| समीकरण एरे जोड़ें | [toMathArray](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/mathelementbase/) |
| डिलीमीटर जोड़ें | [enclose](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/mathelementbase/) |
| बार और बॉर्डर जोड़ें | [overbar](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/mathelementbase/), [toBorderBox](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/mathelementbase/) |
| टर्म्स को समूहित करें | [group](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/mathelementbase/) |

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं मौजूदा PowerPoint समीकरण को संपादित कर सकता हूँ?**

हाँ। प्रस्तुति खोलें, उस आकार को खोजें जिसमें `MathPortion` है, उसका `MathParagraph` प्राप्त करें, और उस पैराग्राफ में गणित ब्लॉक्स को अपडेट करें।

**क्या समीकरण संपादनीय PowerPoint गणित के रूप में सहेजे जाते हैं?**

हाँ। जब आप PPTX में सहेजते हैं, Aspose.Slides समीकरण को संपादनीय Office गणित सामग्री के रूप में लिखता है।

**क्या मैं समीकरणों को LaTeX में निर्यात कर सकता हूँ?**

Aspose.Slides गणितीय समीकरणों को MathML में निर्यात करता है। यदि आपको LaTeX चाहिए, तो पहले MathML में निर्यात करें और फिर एक ऐसे टूल से MathML को अपने इच्छित LaTeX डायलैक्ट में परिवर्तित करें जो इसे समर्थन करता हो।