---
title: "जावास्क्रिप्ट में PowerPoint प्रस्तुतियों में गणितीय समीकरण जोड़ें"
linktitle: "PowerPoint गणितीय समीकरण"
type: docs
weight: 80
url: /hi/nodejs-java/powerpoint-math-equations/
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
- प्रस्तुति
- Node.js
- जावास्क्रिप्ट
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java का उपयोग करके PowerPoint PPT और PPTX में गणितीय समीकरण सम्मिलित और संपादित करें, OMML, स्वरूपण नियंत्रण, और स्पष्ट जावास्क्रिप्ट कोड नमूने समर्थन के साथ."
---
## **परिचय**

PowerPoint समीकरणों को Office Math Markup Language (OMML) के रूप में संग्रहीत करता है। Aspose.Slides for Node.js via Java के साथ, आप प्रोग्रामेटिक रूप से वही प्रकार की गणितीय सामग्री बना सकते हैं: भिन्न, मूल, फ़ंक्शन, सीमाएँ, N-ary ऑपरेटर, मैट्रिक्स, एरे, और स्वरूपित गणितीय ब्लॉक।

PowerPoint में, उपयोगकर्ता सामान्यतः **Insert > Equation** से समीकरण जोड़ते हैं:

![PowerPoint Insert टैब जिसमें Equation कमांड चुना गया है](powerpoint-math-equations_1.png)

परिणाम स्लाइड पर संपादन योग्य गणितीय टेक्स्ट होता है:

![एक PowerPoint स्लाइड जिसमें संपादन योग्य गणितीय समीकरण है](powerpoint-math-equations_2.png)

Aspose.Slides इस गणितीय टेक्स्ट को तीन मुख्य वस्तुओं के माध्यम से बनाता है:

- एक गणितीय आकार, जिसे [addMathShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addMathShape) के साथ बनाया गया है, वह आकार है जिसमें समीकरण होता है।
- [MathPortion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/) आकार के टेक्स्ट फ्रेम के भीतर गणितीय सामग्री संग्रहीत करता है।
- [MathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathparagraph/) में एक या अधिक [MathBlock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathblock/) ऑब्जेक्ट होते हैं।

नीचे कई उदाहरण [MathematicalText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathematicaltext/) और [MathElementBase](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) की फ़्लुएंट मेथड्स का उपयोग करते हैं ताकि कोड संक्षिप्त और पठनीय रहे।

Node.js के माध्यम से Java में प्रस्तुतियों से गणितीय समीकरण निर्यात के लिए देखें [Export Math Equations from Presentations in Node.js via Java](/slides/hi/nodejs-java/exporting-math-equations/)।

## **एक समीकरण बनाएँ**

यह उदाहरण [addMathShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addMathShape) का उपयोग करके एक गणितीय आकार बनाता है और पाइथागोरस प्रमेय जोड़ता है:

![c² = a² + b² समीकरण](powerpoint-math-equations_3.png)

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

{{% alert color="info" title="Note" %}}
[addMathShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addMathShape) एक ऐसा आकार बनाता है जिसमें पहले से ही एक गणितीय पैराग्राफ होता है। पहले [MathPortion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/) तक पहुँचें, [getMathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/#getMathParagraph) को कॉल करें, और उससे गणितीय ब्लॉक या तत्व जोड़ें।
{{% /alert %}}

### **गणित ब्लॉक्स को मिलाएँ**

जब किसी समीकरण के भाग स्वतंत्र रूप से [MathBlock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathblock/) ऑब्जेक्ट के रूप में निर्मित होते हैं, तो उन्हें मिलाने के लिए [joinBlock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathblock/#joinBlock) का प्रयोग करें। यह उदाहरण बाएँ ब्लॉक में `c² =` और दाएँ ब्लॉक में `a² + b²` बनाता है। सभी तीन घातों के लिए संपादन योग्य गणितीय सुपरस्क्रिप्ट बनाने हेतु [setSuperscript](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#setSuperscript) का उपयोग किया गया है।

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addMathShape(20, 20, 600, 100);
    const mathPortion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    const mathParagraph = mathPortion.getMathParagraph();

    const leftBlock = new slides.MathBlock();
    leftBlock.add(new slides.MathematicalText("c").setSuperscript("2"));
    leftBlock.add(new slides.MathematicalText("="));

    const rightBlock = new slides.MathBlock();
    rightBlock.add(new slides.MathematicalText("a").setSuperscript("2"));
    rightBlock.add(new slides.MathematicalText("+"));
    rightBlock.add(new slides.MathematicalText("b").setSuperscript("2"));

    const combinedBlock = leftBlock.joinBlock(rightBlock);
    mathParagraph.add(combinedBlock);

    presentation.save("equation.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[joinBlock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathblock/#joinBlock) `leftBlock` को स्वयं लौटाता है, जिसमें अब क्रम में दोनों भाग सम्मिलित हैं, जबकि `rightBlock` खाली रहता है। सम्मिलित ब्लॉक को केवल एक बार [MathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathparagraph/) में जोड़ें। `equation.pptx` को पुनः खोलने पर पैराग्राफ में एक ब्लॉक रहता है जो `c² = a² + b²` को दर्शाता है, तथा सभी तीन घातों को गणितीय सुपरस्क्रिप्ट के रूप में संरक्षित रखता है।

[leftBlock.add(rightBlock)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathblock/#add) को कॉल करने से एक ब्लॉक को सीधे दूसरे के भीतर नेस्ट करने का प्रयास किया जाता है और यह `InvalidOperationException` उत्पन्न करता है।

## **भिन्न जोड़ें**

एक भिन्न बनाने के लिए [divide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#divide) का उपयोग करें। आप [MathFractionTypes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathfractiontypes/) के साथ भिन्न शैली चुन सकते हैं।

![x द्वारा विभाजित एक तिरछा गणितीय भिन्न](powerpoint-math-equations_4.png)

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

स्थिर भिन्न के लिए, [MathFractionTypes.Bar](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathfractiontypes/#Bar) का प्रयोग करें:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let stackedFraction = new aspose.slides.MathematicalText("x + 1").divide("y - 1", aspose.slides.MathFractionTypes.Bar);
```

## **मूल जोड़ें**

एक वर्गमूल, घनमूल या अन्य मूल बनाने के लिए [radical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#radical) का उपयोग करें। वर्तमान तत्व आधार बन जाता है, और तर्क डिग्री बन जाता है।

![x के नीचे मूल चिह्न के साथ n‑थ मूल अभिव्यक्ति](powerpoint-math-equations_5.png)

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

### **वर्गमूल की डिग्री दिखाएँ या छुपाएँ**

वर्गमूल स्पष्ट 2 दिखा सकता है या पारम्परिक √x नोटेशन का उपयोग कर सकता है। [MathRadical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathradical/) की [setHideDegree](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathradical/#setHideDegree) विधि यह नियंत्रित करती है कि कौन‑सा रूप प्रकट हो। दोनों रूप डिग्री 2 और मूल x को संपादन योग्य समीकरण में रखते हैं।

![बाएँ और दाएँ क्रमशः दृश्य और छिपी डिग्री वाले समान वर्गमूल](square-root-degree.png)

उदाहरण समान वर्गमूल को दो बार सहेजता है। `visible-degree.pptx` में 2 दिखाई देता है। `hidden-degree.pptx` में यह छुपा रहता है।

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let radical = new aspose.slides.MathematicalText("x").radical("2");
    
    let shape = slide.getShapes().addMathShape(20, 20, 200, 100);
    let portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.getMathParagraph().add(new aspose.slides.MathBlock(radical));

    radical.setHideDegree(false);
    presentation.save("visible-degree.pptx", aspose.slides.SaveFormat.Pptx);

    radical.setHideDegree(true);
    presentation.save("hidden-degree.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **फ़ंक्शन और लिमिट जोड़ें**

[asArgumentOfFunction](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#asArgumentOfFunction) या [function](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#function) का उपयोग `sin(x)`, `log(x)` या कस्टम फ़ंक्शन नामों के लिये करें। लिमिट के लिये, `lim` को एक [MathLimit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathlimit/) में रखें या [setLowerLimit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#setLowerLimit) का प्रयोग करें।

![असीम पर x की लिमिट की अभिव्यक्ति](powerpoint-math-equations_8.png)

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

कस्टम फ़ंक्शन नाम के लिये, फ़ंक्शन नाम को वर्तमान तत्व बनाकर उसके तर्क के साथ [function](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#function) को कॉल करें:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let customFunction = new aspose.slides.MathematicalText("f").function("x + 1");
```

## **N‑ary ऑपरेटर और इंटीग्रल जोड़ें**

समूहीकरण, यूनियन, इंटरसेक्शन और अन्य बड़े ऑपरेटरों के लिये [nary](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#nary) का प्रयोग करें। इंटीग्रल के लिये [integral](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#integral) का प्रयोग करें। दोनों विधियों में निचली और ऊपरी सीमाएँ सेट की जा सकती हैं।

![निचली और ऊपरी सीमाओं के साथ समूहीकरण](powerpoint-math-equations_7.png)

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

N‑ary ऑपरेटर बड़े ऑपरेटर होते हैं जिनमें वैकल्पिक सीमाएँ होती हैं। साधारण ऑपरेटर जैसे `+`, `-` और `=` आमतौर पर [MathematicalText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathematicaltext/) के साथ जोड़े जाते हैं।

इंटीग्रल के लिये, [integral](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#integral) का प्रयोग करें:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let integralBase = new aspose.slides.MathematicalText("x").join(new aspose.slides.MathematicalText("dx").toBox());
let integral = integralBase.integral(aspose.slides.MathIntegralTypes.Simple, "0", "1");
```

## **मैट्रिक्स जोड़ें**

पंक्तियों और स्तंभों के लिये [MathMatrix](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathmatrix/) का प्रयोग करें। मैट्रिक्स में डिफ़ॉल्ट रूप से ब्रैकेट नहीं होते, इसलिए आवश्यक होने पर कोष्ठक, ब्रेस या कर्ली ब्रैकेट जोड़ें।

![एक खाली सेल के साथ दो‑पंक्ति गणितीय मैट्रिक्स](powerpoint-math-equations_10.png)

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

### **मौज़ूद मैट्रिक्स को संपादित करें**

मान लीजिए एक रैखिक बीजगणित पाठ्यक्रम `matrix.pptx` में गुणांक मैट्रिक्स के साथ शुरू होता है, जैसा कि पिछले उदाहरण में सहेजा गया था। अगले अभ्यास में, पहली समीकरण रखें, दूसरी को दो नई समीकरणों से बदलें, और चर सेट को संशोधित करें। मौज़ूद मैट्रिक्स को [MathMatrix](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathmatrix/) के द्वारा खोलें ताकि अभी भी लागू गुणांक बरकरार रहें।

![पहली पंक्ति में 1, x और खाली सेल तथा दूसरी पंक्ति में x, 2, y वाले मूल दो‑पंक्ति गुणांक मैट्रिक्स](matrix-before-edit.png)

पंक्ति और स्तंभ सूचकांक शून्य से शुरू होते हैं और प्रत्येक कॉल के समय वर्तमान मैट्रिक्स को दर्शाते हैं। सूचकांक 1 से पहले पंक्ति सम्मिलित करने पर मूल दूसरी पंक्ति सूचकांक 2 पर चली जाती है। सूचकांक 2 के बाद सम्मिलित करने से नई पंक्ति जुड़ती है। पंक्ति 2 को हटाने से मूल दूसरी समीकरण हट जाता है और जोड़ी गई पंक्ति एक स्थान ऊपर चली जाती है। स्तंभ भी इसी तरह शिफ्ट होते हैं।

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("matrix.pptx");
try {
    const shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    const matrix = portion.getMathParagraph().get_Item(0).get_Item(0);

    matrix.insertRowBefore(1);
    matrix.insertRowAfter(2);
    matrix.deleteRow(2);

    matrix.insertColumnBefore(1);
    matrix.insertColumnAfter(3);
    matrix.deleteColumn(3);

    // नई कोशिकाएँ प्रारम्भ में null होती हैं। पहले गैर शून्य गुणांक सेट करें।
    matrix.set_Item(1, 0, new slides.MathematicalText("12"));
    matrix.set_Item(1, 1, new slides.MathematicalText("1"));
    matrix.set_Item(2, 2, new slides.MathematicalText("10"));
    matrix.set_Item(2, 3, new slides.MathematicalText("1"));
    for (let row = 0; row < matrix.getRowCount(); row++) {
        for (let column = 0; column < matrix.getColumnCount(); column++) {
            if (matrix.get_Item(row, column) == null) {
                matrix.set_Item(row, column, new slides.MathematicalText("0"));
            }
        }
    }

    matrix.setColumnAlignment(0, slides.MathHorizontalAlignment.Left);
    matrix.setColumnsAlignment(1, 3, slides.MathHorizontalAlignment.Right);

    presentation.save("updated-matrix.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[setColumnAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathmatrix/#setColumnAlignment) पहले स्तंभ को बाएँ संरेखित करता है। [setColumnsAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathmatrix/#setColumnsAlignment) सूचकांक 1 से शुरू होकर तीन क्रमागत स्तंभों को दाएँ संरेखित करता है। `updated-matrix.pptx` में मैट्रिक्स में तीन समीकरण और चार चर होते हैं। मूल प्रथम‑पंक्ति के गुणांक `1` और `x` अब प्रथम और तृतीय स्तंभ में दिखाई देते हैं।

![अपडेटेड तीन‑पंक्ति मैट्रिक्स जिसमें पंक्तियाँ 1, 0, x, 0; 12, 1, 0, 0; तथा 0, 0, 10, 1 हैं](matrix-after-edit.png)

## **समीकरण एरे जोड़ें**

वर्टिकल स्टैक या संरेखित समीकरणों के लिये [toMathArray](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#toMathArray) का प्रयोग करें।

![x ऊपर y के साथ एक वर्टिकल गणित एरे](powerpoint-math-equations_11.png)

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

### **आसपास के तत्वों के साथ एरे संरेखित करें**

[setBaseJustification](https://reference.aspose.com/slides/nodejs-java/aspose.slides/matharray/#setBaseJustification) एरे को उसके बगल के गणितीय तत्वों के सापेक्ष वर्टिकल संरेखण नियंत्रित करता है। नीचे दिया उदाहरण पहली पंक्ति, एरे का मध्य, और अंतिम पंक्ति के साथ संरेखण की तुलना करता है।

निम्न उदाहरण तीन समान एरे बनाता है, प्रत्येक में तीन पंक्तियाँ और पड़ोसी तत्व `A=` तथा `=B` होते हैं। सभी गणितीय टेक्स्ट Cambria Math 24 पॉइंट पर है। केवल एरे संरेखण बदलता है।

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

function createText(value) {
    const text = new slides.MathematicalText(value);
    text.getFormat().setFontHeight(24);
    text.getFormat().setLatinFont(new slides.FontData("Cambria Math"));
    return text;
}

const presentation = new slides.Presentation();
try {
    presentation.getSlideSize().setSize(780, 200, slides.SlideSizeScaleType.DoNotScale);
    const slide = presentation.getSlides().get_Item(0);

    const alignments = [slides.MathVerticalAlignment.Top, slides.MathVerticalAlignment.Center, slides.MathVerticalAlignment.Bottom];
    const alignmentNames = ["Top", "Center", "Bottom"];

    for (let i = 0; i < alignments.length; i++) {
        const label = slide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 20 + i * 260, 10, 240, 30);
        label.getFillFormat().setFillType(java.newByte(slides.FillType.NoFill));
        label.getLineFormat().getFillFormat().setFillType(java.newByte(slides.FillType.NoFill));
        label.getTextFrame().setText(alignmentNames[i]);
        const labelFormat = label.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
        labelFormat.setFontHeight(16);
        labelFormat.getFillFormat().setFillType(java.newByte(slides.FillType.Solid));
        labelFormat.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));

        const mathShape = slide.getShapes().addMathShape(20 + i * 260, 60, 240, 130);
        mathShape.getTextFrame().getTextFrameFormat().setAnchoringType(java.newByte(slides.TextAnchorType.Top));
        const mathParagraph = mathShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph();
        mathParagraph.setJustification(slides.MathJustification.LeftJustified);

        const rows = [createText("x+y=3"), createText("x-y=1"), createText("x=2")];
        const equationArray = new slides.MathArray(rows[0]);
        equationArray.getArguments().add(rows[1]);
        equationArray.getArguments().add(rows[2]);
        equationArray.setBaseJustification(alignments[i]);
        const leftText = createText("A=");
        const rightText = createText("=B");
        const equation = new slides.MathBlock(leftText).join(equationArray).join(rightText);
        mathParagraph.add(equation);
    }

    presentation.save("equation-array-alignment.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

नीचे तुलना में PowerPoint में सहेजे गये प्रस्तुतीकरण को दिखाया गया है। प्रत्येक एरे के बगल में `A=` और `=B` की स्थिति देखें।

![PowerPoint में शीर्ष, मध्य और निचले संरेखण के साथ समीकरण एरे और समान पड़ोसी तत्व](equation-array-alignment.png)

### **पंक्ति अंतराल कॉन्फ़िगर करें**

[setRowSpacingRule](https://reference.aspose.com/slides/nodejs-java/aspose.slides/matharray/#setRowSpacingRule) एरे के भीतर पंक्तियों के अंतराल नियम को चुनता है। [setRowSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/matharray/#setRowSpacing) स्पष्ट अंतराल के लिये संख्यात्मक मान प्रदान करता है और पूर्वनिर्धारित नियमों द्वारा अनदेखा किया जाता है।

सटीक अंतराल के लिये मान को पॉइंट में मापा जाता है। अनुपातिक अंतराल के लिये इसे आधे‑लाइन में मापा जाता है: उदाहरण में मान `3` 1.5 लाइनों के बराबर है। स्पष्ट मान निर्दिष्ट करने पर दोनों गुणधर्म सेट करें; केवल संख्यात्मक मान बदलने से अंतराल नियम नहीं बदलेगा।

नीचे दिया उदाहरण पाँच प्रस्तुतीकरणों को समान समीकरण, संरेखण और फ़ॉन्ट सेटिंग के साथ सहेजता है। पहला‑तीन पूर्वनिर्धारित हैं; अंतिम दो स्पष्ट मान दर्शाते हैं।

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

function createText(value) {
    const text = new slides.MathematicalText(value);
    text.getFormat().setFontHeight(24);
    text.getFormat().setLatinFont(new slides.FontData("Cambria Math"));
    return text;
}

const rules = [slides.MathRowSpacingRule.SingleLineGap, slides.MathRowSpacingRule.OneAndAHalfLineGap, slides.MathRowSpacingRule.TwoLineGap, slides.MathRowSpacingRule.Exactly, slides.MathRowSpacingRule.Multiple];
const spacingValues = [0, 0, 0, 20, 3];
const ruleNames = ["SingleLineGap", "OneAndAHalfLineGap", "TwoLineGap", "Exactly", "Multiple"];

for (let i = 0; i < rules.length; i++) {
    const fileName = "equation-array-" + ruleNames[i] + ".pptx";
    const presentation = new slides.Presentation();
    try {
        const mathShape = presentation.getSlides().get_Item(0).getShapes().addMathShape(20, 20, 600, 300);
        const paragraph = mathShape.getTextFrame().getParagraphs().get_Item(0);
        paragraph.getParagraphFormat().setSpaceBefore(0);
        paragraph.getParagraphFormat().setSpaceAfter(0);
        const mathParagraph = paragraph.getPortions().get_Item(0).getMathParagraph();
        mathParagraph.setJustification(slides.MathJustification.LeftJustified);

        const rows = [createText("x+y=3"), createText("x-y=1"), createText("x=2")];
        const equationArray = new slides.MathArray(rows[0]);
        equationArray.getArguments().add(rows[1]);
        equationArray.getArguments().add(rows[2]);
        equationArray.setBaseJustification(slides.MathVerticalAlignment.Center);
        equationArray.setRowSpacingRule(rules[i]);
        equationArray.setRowSpacing(java.newLong(spacingValues[i]));
        const leftText = createText("A=");
        const rightText = createText("=B");
        const equation = new slides.MathBlock(leftText).join(equationArray).join(rightText);
        mathParagraph.add(equation);

        presentation.save(fileName, slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

एरे पंक्ति अंतराल पैराग्राफ अंतराल से अलग है। [setSpaceBefore](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setSpaceBefore) और [setSpaceAfter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setSpaceAfter) कंटेनर पैराग्राफ के आसपास स्थान जोड़ते हैं, न कि एरे पंक्तियों के बीच। इसी प्रकार, [MathParagraph.setJustification](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathparagraph/#setJustification) पूरे गणितीय पैराग्राफ को क्षैतिज रूप से स्थित करता है; यह एरे के वर्टिकल संरेखण सेटिंग को नहीं बदलता।

## **त्रिकोणमितीय फ़ंक्शन्स जोड़ें**

जब तर्क वर्तमान तत्व है और फ़ंक्शन नाम ज्ञात है, तो [asArgumentOfFunction](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#asArgumentOfFunction) का प्रयोग करें।

![cos फ़ंक्शन 2x पर लागू किया गया](powerpoint-math-equations_6.png)

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

## **सबस्क्रिप्ट और सुपरसक्रिप्ट जोड़ें**

सूचकांक और घात के लिये सबस्क्रिप्ट और सुपरसक्रिप्ट हेल्पर का उपयोग करें। जब सूचकांक आधार के बाएँ पक्ष पर दिखाई देने चाहिए, तो [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#setSubSuperscriptOnTheLeft) का प्रयोग करें।

![बाएँ‑साइड सबस्क्रिप्ट 1 और सुपरसक्रिप्ट n के साथ बड़ा Y](powerpoint-math-equations_9.png)

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

## **डिलिमिटर जोड़ें**

एक अभिव्यक्ति को डिलिमिटर के भीतर रखने के लिये [enclose](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#enclose) का प्रयोग करें। कई तत्वों वाली डिलिमिटर अभिव्यक्तियों के लिये विभाजक अक्षर भी सेट किया जा सकता है।

![x, y, z को ऊर्ध्वाधर बार द्वारा अलग किया गया डिलिमिटर अभिव्यक्ति](powerpoint-math-equations_13.png)

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

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

### **डिलिमिटर का आकार और संरेखण**

[setGrowToMatchOperandHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathdelimiter/#setGrowToMatchOperandHeight) को `true` पास करने से पैरेंट ऑपेरेंड के अनुसार कोष्ठक आकार बढ़ते हैं, अन्यथा `false` देने पर सामान्य आकार रहता है। [setDelimiterShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathdelimiter/#setDelimiterShape) को दो में से किसी एक [MathDelimiterShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathdelimitershape/) मान के साथ प्रयोग करें। `Centered` कोष्ठकों को गणितीय अक्ष पर मध्य में रखता है, जो बराबर‑साइन के मध्य में चलता है। `Match` कोष्ठकों को enclosed सामग्री के साथ संरेखित करता है। दोनों सेटिंग केवल डिलिमिटर को प्रभावित करती हैं; अंदर की अभिव्यक्ति वही रहती है।

उदाहरण में `x` के एक्सपोनेंट में एक भिन्न रखा गया है जिससे अभिव्यक्ति baseline से ऊपर अधिक विस्तारित होती है। सभी चार समीकरण समान कोष्ठक और फ़ॉन्ट सेटिंग का उपयोग करते हैं।

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    for (let row = 0; row < 2; row++) {
        for (let column = 0; column < 2; column++) {
            const fraction = new slides.MathematicalText("a + b").divide("c + d");
            const power = new slides.MathematicalText("x").setSuperscript(fraction);
            const delimiter = power.enclose(java.newChar('('), java.newChar(')'));
            delimiter.setGrowToMatchOperandHeight(row === 0);
            delimiter.setDelimiterShape(column === 0 ? slides.MathDelimiterShape.Centered : slides.MathDelimiterShape.Match);

            const mathShape = slide.getShapes().addMathShape(20 + 330 * column, 20 + 120 * row, 300, 100);
            const portion = mathShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
            portion.getPortionFormat().setFontHeight(32);
            const equation = new slides.MathematicalText("y = ").join(delimiter);
            portion.getMathParagraph().add(equation);
        }
    }
    presentation.save("delimiter-sizing.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

PowerPoint में प्रभाव देखने के लिये पंक्तियों की तुलना करें। शीर्ष पंक्ति में कोष्ठक एक्सपोनेंट को घेरने के लिये बढ़ते हैं और दोनों आकार समान दिखते हैं। निचली पंक्ति में वृद्धि बंद है। बाएँ कोष्ठक (`Centered`) बराबर‑साइन के साथ संरेखित होते हैं, जबकि दाएँ कोष्ठक (`Match`) अभिव्यक्ति के ऊपर अधिक स्थित होते हैं।

![चार समीकरण PowerPoint में जहाँ डिलिमिटर वृद्धि शीर्ष पंक्ति में सक्रिय है और निचली पंक्ति में निष्क्रिय, बाएँ `Centered` और दाएँ `Match`](delimiter-sizing.png)

## **बॉर्डर बॉक्स जोड़ें**

भिन्न पर [toBorderBox](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#toBorderBox) को कॉल करके पूरी अभिव्यक्ति को फ्रेम दें। डिफ़ॉल्ट रूप से लौटाया गया [MathBorderBox](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/) चारों किनारे दिखाता है। व्यक्तिगत किनारों को हटाने के लिये [setHideTop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setHideTop), [setHideBottom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setHideBottom), [setHideLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setHideLeft) और [setHideRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setHideRight) का प्रयोग करें।

उदाहरण में एक ही भिन्न की छह प्रतियां एक स्लाइड पर रखी गई हैं। निरस्तीकरण दिखाने के लिये सभी चार किनारे छुपाए जाते हैं और [setStrikethroughBottomLeftToTopRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setStrikethroughBottomLeftToTopRight) को `true` पास करके ऊपर‑से‑बाएँ से नीचे‑से‑दाएँ एक तिरछी रेखा (↗) बनाई जाती है, या [setStrikethroughTopLeftToBottomRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setStrikethroughTopLeftToBottomRight) से नीचे‑से‑दाएँ (↘) बनती है। आप किसी भी संयोजन के साथ [setStrikethroughHorizontal](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setStrikethroughHorizontal) या [setStrikethroughVertical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setStrikethroughVertical) का भी उपयोग कर सकते हैं।

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    presentation.getSlideSize().setSize(540, 220, slides.SlideSizeScaleType.DoNotScale);
    const slide = presentation.getSlides().get_Item(0);

    function addFraction(x, y, hideBorder) {
        const fraction = new slides.MathematicalText("x+1").divide("y+2");
        const box = fraction.toBorderBox();
        box.setHideTop(hideBorder);
        box.setHideBottom(hideBorder);
        box.setHideLeft(hideBorder);
        box.setHideRight(hideBorder);

        const shape = slide.getShapes().addMathShape(x, y, 160, 90);
        const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
        portion.getPortionFormat().setFontHeight(28);
        const block = new slides.MathBlock(box);
        portion.getMathParagraph().add(block);
        return box;
    }

    addFraction(10, 10, false);

    const partial = addFraction(190, 10, false);
    partial.setHideTop(true);
    partial.setHideRight(true);

    addFraction(370, 10, true).setStrikethroughBottomLeftToTopRight(true);
    addFraction(10, 120, true).setStrikethroughTopLeftToBottomRight(true);
    addFraction(190, 120, true).setStrikethroughHorizontal(true);
    addFraction(370, 120, false).setStrikethroughVertical(true);

    presentation.save("border-box.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![छह संपादन योग्य भिन्न PowerPoint में। शीर्ष पंक्ति: पूर्ण बॉर्डर, निचले और बाएँ किनारे, ऊपर‑से‑बाएँ तिरछी रेखा। निचली पंक्ति: नीचे‑से‑दाएँ तिरछी रेखा, क्षैतिज स्ट्राइक, लंबवत स्ट्राइक पूर्ण बॉर्डर के साथ](border-box-fractions.png)

इस भिन्न में क्षैतिज स्ट्राइक भिन्न रेखा पर ओवरलैप करता है। लंबवत स्ट्राइक अंश और हर दोनों को काटता है जबकि चारों ओर का बॉर्डर दिखाई देता रहता है। ये रेखाएँ पूरी अभिव्यक्ति को सजाती हैं। सामान्य टेक्स्ट स्ट्राइक‑थ्रु केवल टेक्स्ट रन के अक्षर पर लागू होती है। PowerPoint में प्रस्तुति को पुनः खोलने के बाद भी आप अंश और हर को स्वतंत्र रूप से संपादित कर सकते हैं।

## **फ़ैंटम तत्वों के साथ दृश्यता और लेआउट नियंत्रित करें**

एक अभिव्यक्ति को [MathPhantom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathphantom/) में लपेटें ताकि उसकी दृश्यता और समीकरण में योगदान देने वाली जगह को स्वतंत्र रूप से नियंत्रित किया जा सके। [MathPhantom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathphantom/) की विधियाँ निम्नलिखित नियंत्रित करती हैं:

| Method | Effect |
| --- | --- |
| [setShow](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathphantom/#setShow) | `false` पास करने से अभिव्यक्ति छिप जाती है। इसके आयाम अभी भी लेआउट में योगदान देते हैं, जब तक कि नीचे दी गई संबंधित विधियों को `true` न किया जाए। |
| [setZeroWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathphantom/#setZeroWidth) | अभिव्यक्ति की क्षैतिज चौड़ाई को शून्य मानें, जिससे पड़ोसी तत्व एक‑दूसरे के करीब आ सकें। |
| [setZeroAsc](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathphantom/#setZeroAsc) | उसकी आरोहण (baseline के ऊपर की ऊँचाई) को शून्य मानें। इससे पड़ोसी तत्वों के ऊपर आरक्षित जगह घट सकती है। |
| [setZeroDesc](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathphantom/#setZeroDesc) | उसका अवरोहण (baseline के नीचे की गहराई) को शून्य मानें। इससे भिन्न रेखा या अन्य सामग्री अभिव्यक्ति के नीचे पड़ोसी तत्वों के करीब आ सकती है। |

baseline वह संदर्भ रेखा है जिसपर सामान्य गणितीय अक्षर स्थित होते हैं। सामग्री को छिपाने से उसके आयाम हटते नहीं हैं, और आयाम को शून्य मानने से अभिव्यक्ति हटती नहीं है। मूल अभिव्यक्ति [getBase](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathphantom/#getBase) से उपलब्ध रहती है। फिर से दिखाने के लिये [setShow](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathphantom/#setShow) को `true` पास करें; आयाम सेटिंग्स अपरिवर्तित रहती हैं।

नीचे पाँच साइड‑बाय‑साइड वैरिएंट बनाए गए हैं: एक दृश्य भिन्न, एक छिपा भिन्न जो जगह रखता है, और तीन छिपे भिन्न जिनमें से एक आयाम शून्य है। प्रत्येक वैरिएंट समान बाहर की अभिव्यक्ति और Cambria Math 24 पॉइंट का उपयोग करता है। सभी समीकरण आकार समान शीर्ष स्थान पर होते हैं, जिसे ग्रे गाइड द्वारा चिह्नित किया गया है। बाहरी भिन्न के अंश में फ़ैंटम रखने से वर्टिकल लेआउट बदलाव देखना आसान हो जाता है।

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

function createText(value) {
    const text = new slides.MathematicalText(value);
    text.getFormat().setFontHeight(24);
    text.getFormat().setLatinFont(new slides.FontData("Cambria Math"));
    return text;
}

const presentation = new slides.Presentation();
try {
    presentation.getSlideSize().setSize(1000, 180, slides.SlideSizeScaleType.DoNotScale);
    const slide = presentation.getSlides().get_Item(0);

    const labels = [ "Visible", "Hidden: reserves space", "Hidden: ZeroWidth", "Hidden: ZeroAsc", "Hidden: ZeroDesc" ];

    const guide = slide.getShapes().addAutoShape(slides.ShapeType.Line, 10, 60, 980, 0);
    guide.getLineFormat().getFillFormat().setFillType(java.newByte(slides.FillType.Solid));
    guide.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));

    for (let i = 0; i < labels.length; i++) {
        const left = 10 + i * 200;

        const label = slide.getShapes().addAutoShape(slides.ShapeType.Rectangle, left, 10, 190, 30);
        label.getFillFormat().setFillType(java.newByte(slides.FillType.NoFill));
        label.getLineFormat().getFillFormat().setFillType(java.newByte(slides.FillType.NoFill));
        label.getTextFrame().setText(labels[i]);

        const labelFormat = label.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
        labelFormat.setFontHeight(14);
        labelFormat.getFillFormat().setFillType(java.newByte(slides.FillType.Solid));
        labelFormat.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));

        const fractionNumerator = createText("a+b");
        const fractionDenominator = createText("c+d");
        const fraction = new slides.MathFraction(fractionNumerator, fractionDenominator);
        const phantom = new slides.MathPhantom(fraction);
        phantom.setShow(i === 0);
        phantom.setZeroWidth(i === 2);
        phantom.setZeroAsc(i === 3);
        phantom.setZeroDesc(i === 4);

        const leftText = createText("x+");
        const rightText = createText("+y");
        const numerator = new slides.MathBlock(leftText).join(phantom).join(rightText);
        const denominator = createText("z");
        const equation = new slides.MathFraction(numerator, denominator);

        const shape = slide.getShapes().addMathShape(left, 60, 190, 100);
        shape.getTextFrame().getTextFrameFormat().setAnchoringType(java.newByte(slides.TextAnchorType.Top));

        const mathPortion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
        const mathParagraph = mathPortion.getMathParagraph();
        mathParagraph.add(new slides.MathBlock(equation));
    }

    presentation.save("math-phantom.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![विज़िबल फ्रैक्शन, स्पेस रिज़र्व करने वाला हाइडन फ्रैक्शन, तथा ZeroWidth, ZeroAsc या ZeroDesc सक्रिय वाले हाइडन फ्रैक्शन की तुलना करते हुए पाँच समीकरण PowerPoint में](math-phantom.png)

## **टर्म समूहित करें**

एक अभिव्यक्ति के ऊपर या नीचे समूहित करने वाला चरित्र रखने के लिये [group](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#group) का प्रयोग करें। समूहित टर्म को लेबल करने के लिये एक सीमा (limit) जोड़ें।

![x + y अभिव्यक्ति को नीचे लेबल any text के साथ समूहित किया गया है](powerpoint-math-equations_15.png)

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

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

## **गणितीय तत्वों का स्वरूप निर्धारित करें**

फ़ॉर्मेटिंग हेल्पर केवल तब प्रयोग करें जब वे सूत्र को स्पष्ट बनाते हों। उदाहरण के लिये, [overbar](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#overbar) गणितीय तत्व के ऊपर एक रेखा लगाता है।

![ABC अभिव्यक्ति के ऊपर ओवरबार के साथ](powerpoint-math-equations_14.png)

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

### **मौज़ूद समीकरण में टेक्स्ट को फ़ॉर्मेट करें**

मौज़ूद समीकरण में सम्पूर्ण टेक्स्ट को फ़ॉर्मेट करने के लिये प्रत्येक गणितीय ब्लॉक के तत्व वृक्ष को ट्रैवर्स करें। [MathElementBase.getChildren](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#getChildren) केवल तत्काल बाल लौटाता है, इसलिए इसे पुनरावर्ती रूप से कॉल करके भिन्न, स्क्रिप्ट, मूल आदि की नेस्टेड संरचनाओं में टेक्स्ट तक पहुंचें। जब वर्तमान तत्व [MathematicalText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathematicaltext/) हो तो उसे भी शामिल करें।

यह उदाहरण मानता है कि `input.pptx` में `z = xᵢ / ∛y` जैसा समीकरण है, जिसमें अंश में सबस्क्रिप्ट और हर में मूल है। केवल ब्लॉक के शीर्ष‑स्तर के तत्वों को प्रोसेस करने से भिन्न के भीतर का टेक्स्ट छूट जाएगा। यह उदाहरण स्लाइड टेक्स्ट फ्रेम में गणितीय भागों को खोजता है, उनके ब्लॉक को [MathPortion.getMathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/#getMathParagraph) से प्राप्त करता है, और प्रत्येक टेक्स्ट तत्व के [getFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathematicaltext/#getFormat) मेथड से [setFontHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight) को कॉल करके फ़ॉन्ट आकार 28 पॉइंट सेट करता है।

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

function formatMathText(element) {
    if (java.instanceOf(element, "com.aspose.slides.MathematicalText")) {
        element.getFormat().setFontHeight(28);
    }

    let children = element.getChildren();
    for (let i = 0; i < children.length; i++) {
        formatMathText(children[i]);
    }
}

let presentation = new aspose.slides.Presentation("input.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        let slide = presentation.getSlides().get_Item(i);
        for (let j = 0; j < slide.getShapes().size(); j++) {
            let shape = slide.getShapes().get_Item(j);
            if (!java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                continue;
            }

            let textFrame = shape.getTextFrame();
            if (textFrame == null) {
                continue;
            }

            for (let k = 0; k < textFrame.getParagraphs().getCount(); k++) {
                let paragraph = textFrame.getParagraphs().get_Item(k);
                for (let l = 0; l < paragraph.getPortions().getCount(); l++) {
                    let portion = paragraph.getPortions().get_Item(l);
                    if (java.instanceOf(portion, "com.aspose.slides.IMathPortion")) {
                        let mathParagraph = portion.getMathParagraph();
                        for (let m = 0; m < mathParagraph.getCount(); m++) {
                            formatMathText(mathParagraph.get_Item(m));
                        }
                    }
                }
            }
        }
    }

    presentation.save("formatted-equations.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

सहेजा गया प्रस्तुतीकरण प्रत्येक प्रोसेस किए गये समीकरण के सभी स्तरों पर अपडेटेड टेक्स्ट फ़ॉर्मेटिंग रखता है, जबकि उसके टेक्स्ट कंटेंट और गणितीय संरचना को संरक्षित रखता है।

## **त्वरित संदर्भ**

| कार्य | मुख्य API |
| --- | --- |
| गणितीय टेक्स्ट बनाएँ | [MathematicalText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathematicaltext/) |
| तत्व मिलाएँ | [join](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| भिन्न बनाएँ | [divide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| सुपरसक्रिप्ट या सबस्क्रिप्ट जोड़ें | [setSuperscript](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/), [setSubscript](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| फ़ंक्शन जोड़ें | [function](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/), [asArgumentOfFunction](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| मूल जोड़ें | [radical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| लिमिट जोड़ें | [setLowerLimit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/), [setUpperLimit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| बाएँ‑साइड स्क्रिप्ट जोड़ें | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| समूहीकरण और इंटीग्रल जोड़ें | [nary](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/), [integral](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| मैट्रिक्स जोड़ें | [MathMatrix](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathmatrix/) |
| समीकरण एरे जोड़ें | [toMathArray](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| डिलिमिटर जोड़ें | [enclose](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| बार और बॉर्डर जोड़ें | [overbar](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/), [toBorderBox](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| टर्म समूहित करें | [group](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं मौज़ूद PowerPoint समीकरण को संपादित कर सकता हूँ?**

हाँ। प्रस्तुतीकरण खोलें, वह आकार खोजें जिसमें [MathPortion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/) हो, [getMathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/#getMathParagraph) को कॉल करें, और उस पैराग्राफ में गणितीय ब्लॉक को अपडेट करें।

**क्या समीकरण को संपादन योग्य PowerPoint गणित के रूप में सहेजा जाता है?**

हाँ। PPTX के रूप में सहेजने पर Aspose.Slides समीकरण को संपादन योग्य Office गणित सामग्री के रूप में लिखता है।

**क्या मैं समीकरणों को LaTeX में निर्यात कर सकता हूँ?**

हाँ। उसके [MathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathparagraph/) को उसके [MathPortion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/) से प्राप्त करें, और सीधे निर्यात करने के लिये [MathParagraph.toLatex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathparagraph/#toLatex) को कॉल करें। पूर्ण उदाहरण के लिये देखें [Export Math Equations from Presentations in Node.js via Java](/slides/hi/nodejs-java/exporting-math-equations/#export-math-equations-to-latex)।