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
description: "Aspose.Slides for Node.js via Java के साथ PowerPoint PPT और PPTX में गणितीय समीकरण डालें और संपादित करें, OMML का समर्थन, स्वरूपण नियंत्रण, और स्पष्ट JavaScript कोड उदाहरण प्रदान करता है।"
---
## **सारांश**

PowerPoint समीकरणों को Office Math Markup Language (OMML) के रूप में संग्रहीत करता है। Aspose.Slides for Node.js via Java के साथ, आप समान प्रकार की गणितीय सामग्री को प्रोग्रामेटिक रूप से बना सकते हैं: भिन्न, मूल, फ़ंक्शन, सीमाएँ, N-ary ऑपरेटर्स, मैट्रिक्स, एरे, और स्वरूपित गणित ब्लॉकों।

PowerPoint में, उपयोगकर्ता सामान्यतः **Insert > Equation** से समीकरण जोड़ते हैं:

![PowerPoint Insert टैब जिसमें Equation कमांड चुना गया है](powerpoint-math-equations_1.png)

परिणाम स्लाइड पर संपादन योग्य गणितीय टेक्स्ट होता है:

![एक PowerPoint स्लाइड जिसमें एक संपादन योग्य गणितीय समीकरण है](powerpoint-math-equations_2.png)

Aspose.Slides उस गणितीय टेक्स्ट को तीन मुख्य ऑब्जेक्ट्स के माध्यम से बनाता है:

- एक गणितीय रूप, जिसे [addMathShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addMathShape) से बनाया गया है, वह रूप है जो समीकरण को समाहित करता है।
- [MathPortion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/) आकार के टेक्स्ट फ्रेम के भीतर गणितीय सामग्री संग्रहीत करता है।
- [MathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathparagraph/) में एक या अधिक [MathBlock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathblock/) ऑब्जेक्ट होते हैं।

नीचे के अधिकांश उदाहरण [MathematicalText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathematicaltext/) और [MathElementBase](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) की फ़्लुएंट मेथड्स का उपयोग करके कोड को छोटा और पठनीय रखते हैं।

MathML निर्यात परिदृश्यों के लिए, देखें [Export Math Equations from Presentations in Node.js via Java](/slides/hi/nodejs-java/exporting-math-equations/)।

## **समीकरण बनाना**

यह उदाहरण [addMathShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addMathShape) का उपयोग करके एक गणितीय रूप बनाता है और पाइथागोरस प्रमेय जोड़ता है:

![समीकरण c² = a² + b² की छवि](powerpoint-math-equations_3.png)

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
[addMathShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addMathShape) एक रूप बनाता है जिसमें पहले से ही एक गणितीय पैराग्राफ शामिल होता है। पहले [MathPortion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/) तक पहुंचें, [getMathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/#getMathParagraph) को कॉल करें, और उसमें गणितीय ब्लॉक या गणितीय तत्व जोड़ें।
{{% /alert %}}

## **भिन्न जोड़ना**

भिन्न बनाने के लिए [divide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#divide) का उपयोग करें। आप [MathFractionTypes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathfractiontypes/) के साथ एक भिन्न शैली चुन सकते हैं।

![भिन्न में x द्वारा विभाजित 1 दिखाते हुए एक तिरछा गणितीय भिन्न](powerpoint-math-equations_4.png)

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

स्टैक्ड भिन्न के लिए, [MathFractionTypes.Bar](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathfractiontypes/#Bar) का उपयोग करें:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let stackedFraction = new aspose.slides.MathematicalText("x + 1").divide("y - 1", aspose.slides.MathFractionTypes.Bar);
```

## **मूल जोड़ना**

[radical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#radical) का उपयोग करके वर्ग मूल, घन मूल, या अन्य मूल बनाएं। वर्तमान तत्व आधार बन जाता है, और तर्क डिग्री बन जाता है।

![x के नीचे मूल चिह्न के साथ n‑th मूल अभिव्यक्ति](powerpoint-math-equations_5.png)

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

### **वर्ग मूल की डिग्री दिखाना या छिपाना**

वर्ग मूल स्पष्ट 2 दिखा सकता है या पारम्परिक √x नोटेशन उपयोग कर सकता है। [MathRadical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathradical/) की [setHideDegree](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathradical/#setHideDegree) मेथड निर्धारित करती है कि कौन सा रूप दिखाई दे। दोनों रूपों में डिग्री 2 और रेडिकेंड x संपादन योग्य समीकरण में बना रहता है।

![बाईं ओर डिग्री दिखाई देने वाला और दाईं ओर छिपा हुआ समान वर्ग मूल](square-root-degree.png)

उदाहरण दो बार समान वर्ग मूल को सहेजता है। `visible-degree.pptx` में 2 दिखाई देता है। `hidden-degree.pptx` में यह छिपा हुआ है।

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

## **फ़ंक्शन और सीमाएँ जोड़ना**

फ़ंक्शन जैसे `sin(x)`, `log(x)`, या कस्टम फ़ंक्शन नामों के लिए [asArgumentOfFunction](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#asArgumentOfFunction) या [function](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#function) का उपयोग करें। सीमाओं के लिए, `lim` को एक [MathLimit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathlimit/) में रखें या [setLowerLimit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#setLowerLimit) का उपयोग करें।

![x के अनंत की ओर बढ़ते हुए सीमा का चित्रण](powerpoint-math-equations_8.png)

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

कस्टम फ़ंक्शन नाम के लिए, फ़ंक्शन नाम को वर्तमान तत्व बनाएं और उसके तर्क के साथ [function](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#function) को कॉल करें:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let customFunction = new aspose.slides.MathematicalText("f").function("x + 1");
```

## **N‑ary ऑपरेटर्स और इंटीग्रल जोड़ना**

समेशन, यूनियन, इंटरसेक्शन, और अन्य बड़े ऑपरेटर्स के लिए [nary](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#nary) का उपयोग करें। इंटीग्रल के लिए [integral](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#integral) का उपयोग करें। दोनों मेथड नीचे और ऊपर की सीमाएँ सेट करने की अनुमति देते हैं।

![नीचे और ऊपर की सीमाओं के साथ एक समेशन](powerpoint-math-equations_7.png)

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

N‑ary ऑपरेटर्स बड़े ऑपरेटर्स के लिए होते हैं जिनमें वैकल्पिक सीमाएँ हो सकती हैं। साधारण ऑपरेटर्स जैसे `+`, `-`, और `=` आमतौर पर [MathematicalText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathematicaltext/) के रूप में जोड़े जाते हैं और अभिव्यक्ति में सम्मिलित होते हैं।

इंटीग्रल के लिए, [integral](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#integral) का उपयोग करें:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let integralBase = new aspose.slides.MathematicalText("x").join(new aspose.slides.MathematicalText("dx").toBox());
let integral = integralBase.integral(aspose.slides.MathIntegralTypes.Simple, "0", "1");
```

## **मैट्रिक्स जोड़ना**

पंक्तियों और स्तंभों के लिए [MathMatrix](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathmatrix/) का उपयोग करें। डिफ़ॉल्ट रूप से मैट्रिक्स में कोष्ठक नहीं होते, इसलिए जब आपको कोष्ठक, ब्रैकेट या ब्रेस की आवश्यकता हो तो मैट्रिक्स को घेरें।

![एक दो‑पंक्ति वाला गणितीय मैट्रिक्स जिसमें एक खाली सेल है](powerpoint-math-equations_10.png)

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

## **समीकरण एरे जोड़ना**

संरेखित समीकरणों या ऊर्ध्वाधर अभिव्यक्तियों के स्टैक के लिए [toMathArray](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#toMathArray) का उपयोग करें।

![ऊपर y के ऊपर x वाले एक ऊर्ध्वाधर गणितीय एरे की छवि](powerpoint-math-equations_11.png)

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

### **एरे को आस-पास के तत्वों के साथ संरेखित करना**

[setBaseJustification](https://reference.aspose.com/slides/nodejs-java/aspose.slides/matharray/#setBaseJustification) एरे की ऊर्ध्वाधर संरेखण को उसके बगल में मौजूद गणितीय तत्वों के सापेक्ष नियंत्रित करता है। नीचे का उदाहरण पहली पंक्ति, एरे के केंद्र तथा अंतिम पंक्ति के साथ संरेखण की तुलना करता है।

निम्न उदाहरण तीन समान एरे बनाता है, प्रत्येक में तीन पंक्तियाँ हैं और बगल में `A=` तथा `=B` हैं। सभी गणितीय टेक्स्ट Cambria Math फ़ॉन्ट के 24 पॉइंट में है। केवल एरे का संरेखण बदलता है।

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

निम्न तुलना PowerPoint में सहेजे गए प्रस्तुतीकरण को दिखाती है। प्रत्येक एरे के बगल में `A=` तथा `=B` की स्थिति पर ध्यान दें।

![ऊपर, मध्य और नीचे संरेखित समीकरण एरे PowerPoint में, समान बगल के तत्वों के साथ](equation-array-alignment.png)

### **पंक्ति अंतराल कॉन्फ़िगर करना**

[setRowSpacingRule](https://reference.aspose.com/slides/nodejs-java/aspose.slides/matharray/#setRowSpacingRule) एरे के भीतर पंक्तियों के अंतराल नियम को चुनता है। [setRowSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/matharray/#setRowSpacing) स्पष्ट अंतराल नियम के लिए संख्यात्मक मान प्रदान करता है और प्रीसेट नियमों द्वारा अनदेखा किया जाता है।

सटीक अंतराल के लिए मान पॉइंट में मापा जाता है। अनुपातिक अंतराल के लिए यह आधी‑लाइन में मापा जाता है: उदाहरण में मान `3` 1.5 लाइनों को दर्शाता है। स्पष्ट मान निर्दिष्ट करते समय दोनों गुणधर्म सेट करें; केवल संख्यात्मक मान बदलने से अंतराल नियम नहीं बदलता।

नीचे का उदाहरण समान समीकरण, संरेखण और फ़ॉन्ट सेटिंग के साथ पाँच प्रस्तुतीकरण सहेजता है। पहले तीन प्रीसेट उपयोग करते हैं; आख़िरी दो स्पष्ट मान दिखाते हैं।

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

एरे पंक्ति अंतराल पैराग्राफ अंतराल से अलग होता है। [setSpaceBefore](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setSpaceBefore) और [setSpaceAfter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setSpaceAfter) कंटेनर पैराग्राफ के चारों ओर स्थान जोड़ते हैं, न कि एरे पंक्तियों के बीच। इसी प्रकार, [MathParagraph.setJustification](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathparagraph/#setJustification) पूरे गणितीय पैराग्राफ को क्षैतिज रूप से स्थित करता है; यह एरे की ऊर्ध्वाधर संरेखण सेटिंग को प्रतिस्थापित नहीं करता।

## **त्रिकोणमितीय फ़ंक्शन जोड़ना**

जब तर्क वर्तमान तत्व है और फ़ंक्शन का नाम ज्ञात है, तो [asArgumentOfFunction](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#asArgumentOfFunction) का उपयोग करें।

![cos फ़ंक्शन 2x पर लागू किया गया है का चित्रण](powerpoint-math-equations_6.png)

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

## **सबस्क्रिप्ट और सुपरसक्रिप्ट जोड़ना**

इंडेक्स और घात के लिए सबस्क्रिप्ट और सुपरसक्रिप्ट हेल्पर्स का उपयोग करें। जब इंडेक्स को आधार के बाएँ पक्ष में दिखाना हो, तो [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#setSubSuperscriptOnTheLeft) का उपयोग करें।

![बाएँ‑साइड सबस्क्रिप्ट 1 और सुपरसक्रिप्ट n के साथ एक बड़े Y का चित्रण](powerpoint-math-equations_9.png)

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

## **डिलिमिटर जोड़ना**

[enclose](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#enclose) का उपयोग करके अभिव्यक्ति को डिलिमिटर के भीतर रखें। कई तत्वों वाली अभिव्यक्तियों के लिए आप एक विभाजक अक्षर भी सेट कर सकते हैं।

![x, y और z को ऊर्ध्वाधर बार द्वारा अलग किया गया डिलिमिटर अभिव्यक्ति](powerpoint-math-equations_13.png)

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

परिणाम की ऊँचाई के अनुसार कोष्ठकों को विस्तारित करने के लिए `true` को [setGrowToMatchOperandHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathdelimiter/#setGrowToMatchOperandHeight) में पास करें, या सामान्य आकार बनाए रखने के लिए `false` पास करें। दो में से एक [MathDelimiterShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathdelimitershape/) मान के साथ [setDelimiterShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathdelimiter/#setDelimiterShape) का प्रयोग करें। `Centered` कोष्ठकों को गणितीय अक्ष पर केंद्रित करता है, जो बराबर संकेत के मध्य में चलता है। `Match` उन्हें समाहित सामग्री के साथ संरेखित करता है। दोनों सेटिंग केवल डिलिमिटर को प्रभावित करती हैं। अभिव्यक्ति अंदर वही रहती है।

उदाहरण में `x` के एक्सपोनेंट में एक भिन्न रखा गया है ताकि अभिव्यक्ति बेसलाइन के ऊपर अधिक विस्तृत हो। सभी चार समीकरण समान कोष्ठक और फ़ॉन्ट सेटिंग का उपयोग करते हैं।

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

PowerPoint में पंक्तियों की तुलना करके वृद्धि प्रभाव देखें। शीर्ष पंक्ति में, कोष्ठक एक्सपोनेंट को घेरने के लिए बड़े होते हैं और दोनों रूप समान दिखते हैं। नीचे की पंक्ति में वृद्धि बंद है। बाएँ पर छोटे कोष्ठक (`Centered`) बराबर संकेत के साथ संरेखित होते हैं, जबकि दाएँ पर (`Match`) अभिव्यक्ति के आसपास ऊपर की ओर स्थित होते हैं।

![चार समीकरण PowerPoint में, डिलिमिटर वृद्धि सक्षम (ऊपर) और अक्षम (नीचे) के साथ, बाएँ `Centered` और दाएँ `Match`](delimiter-sizing.png)

## **बॉर्डर बॉक्स जोड़ना**

भिन्न पर [toBorderBox](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#toBorderBox) को कॉल करके पूरी अभिव्यक्ति को फ्रेम करें। लौटाया गया [MathBorderBox](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/) डिफ़ॉल्ट रूप से सभी चार पक्ष दिखाता है। व्यक्तिगत पक्षों को हटाने के लिए [setHideTop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setHideTop), [setHideBottom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setHideBottom), [setHideLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setHideLeft) और [setHideRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setHideRight) का उपयोग करें।

उदाहरण में एक ही भिन्न की छह प्रतियां एक ही स्लाइड पर रखी गई हैं। रद्दीकरण दिखाने के लिए सभी चार पक्ष छिपाएँ और ऊपर से नीचे की ओर तिरछी रेखा (↗) के लिए [setStrikethroughBottomLeftToTopRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setStrikethroughBottomLeftToTopRight) को `true` पास करें, या नीचे से ऊपर की ओर तिरछी रेखा (↘) के लिए [setStrikethroughTopLeftToBottomRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setStrikethroughTopLeftToBottomRight) को `true` पास करें। आप किसी भी संयोजन में दृश्यमान पक्षों के साथ [setStrikethroughHorizontal](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setStrikethroughHorizontal) या [setStrikethroughVertical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setStrikethroughVertical) भी उपयोग कर सकते हैं।

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

![छह संपादन योग्य भिन्न PowerPoint में। शीर्ष पंक्ति: पूर्ण बॉर्डर, नीचे और बाएँ पक्ष, ऊँची तिरछी रेखा। नीचे पंक्ति: नीचे की तिरछी रेखा, क्षैतिज स्ट्राइक, ऊर्ध्वाधर स्ट्राइक पूर्ण बॉर्डर के साथ।](border-box-fractions.png)

इस भिन्न में, क्षैतिज स्ट्राइक भिन्न बार के ऊपर ओवरलैप करता है। ऊर्ध्वाधर स्ट्राइक न्यूमेरटर और डिनॉमिनेटर दोनों को काटता है जबकि आसपास का बॉर्डर दृश्यमान रहता है। ये रेखाएं पूरी अभिव्यक्ति को सजाती हैं। सामान्य टेक्स्ट स्ट्राइक‑थ्रू केवल टेक्स्ट रन के अक्षरों पर लागू होता है। प्रस्तुतीकरण को PowerPoint में पुनः खोलने के बाद आप अभी भी न्यूमेरटर और डिनॉमिनेटर को स्वतंत्र रूप से संपादित कर सकते हैं।

## **फैंटम तत्वों के साथ दृश्यता और लेआउट नियंत्रित करना**

एक अभिव्यक्ति को [MathPhantom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathphantom/) में घेरें ताकि उसकी दृश्यता और वह समीकरण में जो स्थान लेता है, स्वतंत्र रूप से नियंत्रित किया जा सके। [MathPhantom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathphantom/) की विधियां निम्नलिखित को नियंत्रित करती हैं:

| विधि | प्रभाव |
| --- | --- |
| [setShow](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathphantom/#setShow) | `false` पास करके अभिव्यक्ति को छिपाएँ। उसके आयाम अभी भी लेआउट में योगदान देंगे जब तक कि नीचे दी गई विधियां `true` न प्राप्त करें। |
| [setZeroWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathphantom/#setZeroWidth) | अभिव्यक्ति की क्षैतिज चौड़ाई को शून्य मानें, जिससे पड़ोसी तत्व नज़दीक आ सकें। |
| [setZeroAsc](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathphantom/#setZeroAsc) | उसके आरोह (baseline के ऊपर की ऊँचाई) को शून्य मानें। इससे पड़ोसी तत्वों के ऊपर आरक्षित स्थान घट सकता है। |
| [setZeroDesc](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathphantom/#setZeroDesc) | उसके अवरोह (baseline के नीचे की गहराई) को शून्य मानें। इससे भिन्न बार या अन्य सामग्री नीचे के हिस्से में पड़ोसी तत्वों के अधिक नज़दीक आ सकती है। |

baseline वह संदर्भ रेखा है जिस पर सामान्य गणितीय अक्षर स्थित होते हैं। सामग्री को छिपाने से उसके आयाम हटते नहीं हैं, और आयाम को शून्य बनाना अभिव्यक्ति को हटाता नहीं है। मूल अभिव्यक्ति [getBase](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathphantom/#getBase) के माध्यम से उपलब्ध रहती है। [setShow](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathphantom/#setShow) को `true` पास करके इसे फिर से दिखा सकते हैं; आयाम सेटिंग अपरिवर्तित रहती है।

निम्न उदाहरण पाँच साइड‑बाय‑साइड वैरिएंट बनाता है: एक दृश्यभिन्‍न भिन्न, एक छिपा हुआ भिन्‍न जो स्थान आरक्षित रखता है, और तीन छिपे हुए भिन्‍न जिनमें एक आयाम शून्य बनाया गया है। प्रत्येक वैरिएंट समान चारों ओर की अभिव्यक्ति और Cambria Math के 24 पॉइंट फ़ॉन्ट का उपयोग करता है। सभी समीकरण रूपों की ऊँचाई समान है, ग्रे गाइड द्वारा चिह्नित। बाहरी भिन्न के न्यूमेरटर में फैंटम रखने से ऊर्ध्वाधर लेआउट परिवर्तन स्पष्ट दिखते हैं।

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

![पाँच समीकरण PowerPoint में, एक दृश्यभिन्‍न, एक छिपा हुआ भिन्‍न जो स्थान आरक्षित रखता है, तथा ZeroWidth, ZeroAsc या ZeroDesc सक्षम किए गए छिपे हुए भिन्‍न की तुलना करते हुए](math-phantom.png)

## **शर्तें समूहित करना**

[group](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#group) का उपयोग करके अभिव्यक्ति के ऊपर या नीचे समूह‑चरित्र रखें। समूहित शर्तों को लेबल करने के लिए एक सीमा जोड़ें।

![x + y अभिव्यक्ति को नीचे लेबल के साथ समूहित करने का चित्रण](powerpoint-math-equations_15.png)

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

## **गणितीय तत्वों का स्वरूपण**

केवल तब स्वरूपण हेल्पर्स का उपयोग करें जब वे सूत्र को स्पष्ट बनाते हों। उदाहरण के लिए, [overbar](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#overbar) गणितीय तत्व के ऊपर एक रेखा रखता है।

![एक गणितीय अभिव्यक्ति ABC जिसके ऊपर ओवरबार है](powerpoint-math-equations_14.png)

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

### **मौजूदा समीकरण में टेक्स्ट को स्वरूपित करना**

मौजूदा समीकरण में पूरे टेक्स्ट को स्वरूपित करने के लिए प्रत्येक गणितीय ब्लॉक के तत्व‑वृक्ष को पार करें। [MathElementBase.getChildren](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#getChildren) केवल प्रत्यक्ष बाल लौटाता है, इसलिए इसे पुनरावर्ती रूप से कॉल करके भिन्न, स्क्रिप्ट, मूल और अन्य नेस्टेड संरचनाओं के भीतर टेक्स्ट तक पहुँचें। वर्तमान तत्व के साथ-साथ उसके बच्चों को भी जांचें ताकि जब वह [MathematicalText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathematicaltext/) हो तो शुरुआत का तत्व भी शामिल हो।

यह उदाहरण मानता है कि `input.pptx` में ऐसा समीकरण है जैसे `z = xᵢ / ∛y`, जिसमें न्यूमेरटर में सबस्क्रिप्ट और डिनॉमिनेटर में मूल है। केवल ब्लॉक की शीर्ष‑स्तरीय तत्वों को प्रोसेस करने से भिन्न के अंदर का टेक्स्ट छूट जाएगा। यह उदाहरण स्लाइड टेक्स्ट फ्रेम में गणितीय भागों को खोजता है, उन्हें [MathPortion.getMathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/#getMathParagraph) के माध्यम से ब्लॉकों तक पहुँचाता है, और प्रत्येक टेक्स्ट तत्व की [getFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathematicaltext/#getFormat) विधि का उपयोग करके फ़ॉन्ट आकार को 28 पॉइंट पर सेट करने के लिए [setFontHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight) को कॉल करता है।

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

सहेजा गया प्रस्तुतीकरण प्रत्येक संसाधित समीकरण के प्रत्येक स्तर पर अद्यतन टेक्स्ट स्वरूपण सहित होता है, जबकि उसका टेक्स्ट सामग्री और गणितीय संरचना अपरिवर्तित रहती है।

## **त्वरित संदर्भ**

| कार्य | मुख्य API |
| --- | --- |
| गणितीय टेक्स्ट बनाना | [MathematicalText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathematicaltext/) |
| तत्वों को मिलाना | [join](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| भिन्न बनाना | [divide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| सुपरसक्रिप्ट या सबस्क्रिप्ट जोड़ना | [setSuperscript](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/), [setSubscript](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| फ़ंक्शन जोड़ना | [function](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/), [asArgumentOfFunction](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| मूल जोड़ना | [radical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| सीमा जोड़ना | [setLowerLimit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/), [setUpperLimit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| बाएँ‑साइड स्क्रिप्ट जोड़ना | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| समेशन और इंटीग्रल जोड़ना | [nary](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/), [integral](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| मैट्रिक्स जोड़ना | [MathMatrix](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathmatrix/) |
| समीकरण एरे जोड़ना | [toMathArray](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| डिलिमिटर जोड़ना | [enclose](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| बार और बॉर्डर जोड़ना | [overbar](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/), [toBorderBox](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| शर्तें समूहित करना | [group](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं मौजूदा PowerPoint समीकरण को संपादित कर सकता हूँ?**

हां। प्रस्तुतीकरण खोलें, उस रूप को खोजें जिसमें एक [MathPortion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/) हो, [getMathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/#getMathParagraph) को कॉल करें, और उस पैराग्राफ में गणितीय ब्लॉक को अपडेट करें।

**क्या समीकरण संपादन योग्य PowerPoint गणित के रूप में सहेजे जाते हैं?**

हां। जब आप PPTX में सहेजते हैं, तो Aspose.Slides समीकरण को संपादन योग्य Office गणित सामग्री के रूप में लिखता है।

**क्या मैं समीकरण को LaTeX में निर्यात कर सकता हूँ?**

हां। समीकरण के [MathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathparagraph/) को उसके [MathPortion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/) से प्राप्त करें, और सीधे निर्यात करने के लिए [MathParagraph.toLatex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathparagraph/#toLatex) को कॉल करें। पूर्ण उदाहरण के लिए देखें [Export Math Equations from Presentations in Node.js via Java](/slides/hi/nodejs-java/exporting-math-equations/#export-math-equations-to-latex)।