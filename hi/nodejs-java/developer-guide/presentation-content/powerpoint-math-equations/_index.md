---
title: PowerPoint प्रस्तुतियों में जावास्क्रिप्ट के साथ गणितीय समीकरण जोड़ें
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
- जावास्क्रिप्ट
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java का उपयोग करके PowerPoint PPT और PPTX में गणितीय समीकरण डालें और संपादित करें, जो OMML, फ़ॉर्मेटिंग नियंत्रण और स्पष्ट जावास्क्रिप्ट कोड उदाहरणों का समर्थन करता है।"
---
## **अवलोकन**

PowerPoint समीकरणों को Office Math Markup Language (OMML) के रूप में संग्रहीत करता है। Aspose.Slides for Node.js via Java के साथ, आप प्रोग्रामेटिक रूप से समान प्रकार की गणितीय सामग्री बना सकते हैं: भिन्न, मूल, फ़ंक्शन, सीमाएँ, N-ary ऑपरेटर्स, मैट्रिसेज, ऐरे और फ़ॉर्मेटेड गणित ब्लॉक्स।

PowerPoint में, उपयोगकर्ता सामान्यतः **Insert > Equation** से समीकरण जोड़ते हैं:

![PowerPoint Insert टैब जिसमें Equation कमांड चयनित है](powerpoint-math-equations_1.png)

परिणाम स्लाइड पर संपादन योग्य गणितीय पाठ होता है:

![एक PowerPoint स्लाइड जिसमें संपादन योग्य गणितीय समीकरण है](powerpoint-math-equations_2.png)

Aspose.Slides इस गणितीय पाठ को तीन मुख्य वस्तुओं के माध्यम से बनाता है:

- एक गणितीय आकार, जिसे [addMathShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addMathShape) द्वारा बनाया जाता है, वह आकार है जो समीकरण को सम्मिलित करता है।
- [MathPortion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/) आकार के टेक्स्ट फ्रेम के भीतर गणितीय सामग्री को संग्रहीत करता है।
- [MathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathparagraph/) में एक या अधिक [MathBlock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathblock/) वस्तुएँ होती हैं।

नीचे के अधिकांश उदाहरण [MathematicalText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathematicaltext/) और [MathElementBase](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) की फ़्लुएंट मेथड्स का उपयोग करके कोड को छोटा और पठनीय रखते हैं।

MathML निर्यात परिदृश्यों के लिए, देखें [Export Math Equations from Presentations in Node.js via Java](/slides/hi/nodejs-java/exporting-math-equations/)।

## **समीकरण बनाएं**

यह उदाहरण [addMathShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addMathShape) का उपयोग करके एक गणितीय आकार बनाता है और पाइथागोरस प्रमेय जोड़ता है:

![समीकरण c² = a² + b²](powerpoint-math-equations_3.png)

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
[addMathShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addMathShape) एक ऐसा आकार बनाता है जिसमें पहले से ही एक गणितीय पैराग्राफ शामिल होता है। पहले [MathPortion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/) तक पहुंचें, [getMathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/#getMathParagraph) को कॉल करें, और उसमें गणितीय ब्लॉक या तत्व जोड़ें।
{{% /alert %}}

## **भिन्न जोड़ें**

एक भिन्न बनाने के लिए [divide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#divide) का उपयोग करें। आप [MathFractionTypes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathfractiontypes/) के साथ भिन्न शैली चुन सकते हैं।

![एक तिरछा गणितीय भिन्न जिसमें एक को x द्वारा विभाजित दिखाया गया है](powerpoint-math-equations_4.png)

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

## **मूल जोड़ें**

एक वर्गमूल, घनमूल या अन्य मूल बनाने के लिए [radical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#radical) का प्रयोग करें। वर्तमान तत्व आधार बन जाता है, और तर्क डिग्री बन जाता है।

![एक n-थ मूल अभिव्यक्ति जिसमें x मूल चिह्न के नीचे है](powerpoint-math-equations_5.png)

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

## **फ़ंक्शन और सीमाएँ जोड़ें**

फ़ंक्शन जैसे `sin(x)`, `log(x)` या कस्टम फ़ंक्शन नामों के लिए [asArgumentOfFunction](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#asArgumentOfFunction) या [function](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#function) का उपयोग करें। सीमाओं के लिए, `lim` को एक [MathLimit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathlimit/) में रखें या [setLowerLimit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#setLowerLimit) का प्रयोग करें।

![x की सीमा जब x अनन्त की ओर बढ़ता है](powerpoint-math-equations_8.png)

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

कस्टम फ़ंक्शन नाम के लिए, वर्तमान तत्व को फ़ंक्शन नाम बनाएं और उसके तर्क के साथ [function](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#function) को कॉल करें:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let customFunction = new aspose.slides.MathematicalText("f").function("x + 1");
```

## **N-ary ऑपरेटर्स और इंटीग्रल जोड़ें**

समिश्रण, संघ, प्रतिच्छेद और अन्य बड़े ऑपरेटर्स के लिए [nary](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#nary) का उपयोग करें। इंटीग्रल के लिए [integral](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#integral) का प्रयोग करें। दोनों मेथड्स आपको निचली और ऊपरी सीमाएँ सेट करने देते हैं।

![निचली और ऊपरी सीमाओं के साथ एक समिश्रण](powerpoint-math-equations_7.png)

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

N-ary ऑपरेटर्स बड़े ऑपरेटर्स होते हैं जिनमें वैकल्पिक सीमाएँ हो सकती हैं। साधारण ऑपरेटर्स जैसे `+`, `-`, `=` आमतौर पर [MathematicalText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathematicaltext/) के रूप में जोड़े जाते हैं और अभिव्यक्ति में सम्मिलित होते हैं।

इंटीग्रल के लिए, [integral](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#integral) का उपयोग करें:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let integralBase = new aspose.slides.MathematicalText("x").join(new aspose.slides.MathematicalText("dx").toBox());
let integral = integralBase.integral(aspose.slides.MathIntegralTypes.Simple, "0", "1");
```

## **मैट्रिसेज़ जोड़ें**

पंक्तियों और स्तंभों के लिए [MathMatrix](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathmatrix/) का उपयोग करें। मैट्रिसेज़ में डिफ़ॉल्ट रूप से कोष्ठक नहीं होते, इसलिए कोष्ठक, ब्रैकेट या ब्रेसेस की आवश्यकता होने पर उन्हें स्वयं घेरें।

![एक दो-पंक्ति का गणितीय मैट्रिक्स जिसमें एक खाली सेल है](powerpoint-math-equations_10.png)

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

## **समीकरण ऐरे जोड़ें**

जब आपको संरेखित समीकरण या अभिव्यक्तियों की вертикल स्टैक चाहिए, तो [toMathArray](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#toMathArray) का प्रयोग करें।

![एक लंबवत गणितीय ऐरे जिसमें x ऊपर y है](powerpoint-math-equations_11.png)

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

## **त्रिकोणमितीय फ़ंक्शन जोड़ें**

जब तर्क वर्तमान तत्व है और फ़ंक्शन नाम ज्ञात है, तो [asArgumentOfFunction](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#asArgumentOfFunction) का उपयोग करें।

![त्रिकोणमितीय फ़ंक्शन cos को 2x पर लागू किया गया है](powerpoint-math-equations_6.png)

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

## **सबस्क्रिप्ट और सुपरस्क्रिप्ट जोड़ें**

सूचकांक और घातांक के लिए सबस्क्रिप्ट और सुपरस्क्रिप्ट हेल्पर्स का उपयोग करें। जब सूचकांक आधार के बाएँ पक्ष पर दिखाई देना चाहिए, तो [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#setSubSuperscriptOnTheLeft) का उपयोग करें।

![बाएँ‑साइड सबस्क्रिप्ट 1 और सुपरस्क्रिप्ट n के साथ बड़ा Y अक्षर](powerpoint-math-equations_9.png)

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

## **डिलीमीटर जोड़ें**

एक अभिव्यक्ति को डिलीमीटर के भीतर रखने के लिए [enclose](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#enclose) का प्रयोग करें। कई तत्वों वाले डिलीमीटर अभिव्यक्तियों के लिए आप एक विभाजक वर्ण भी सेट कर सकते हैं।

![डिलीमीटर अभिव्यक्ति जिसमें x, y, और z को वर्टिकल बार द्वारा अलग किया गया है](powerpoint-math-equations_13.png)

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

### **डिलीमीटर का आकार और संरेखण**

टालें `true` को [setGrowToMatchOperandHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathdelimiter/#setGrowToMatchOperandHeight) में पास करके कोष्ठकों को बड़े ऑपरेन्ड के आसपास बढ़ने दें, या `false` पास करके उनका सामान्य आकार रखें। [setDelimiterShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathdelimiter/#setDelimiterShape) को दो में से किसी एक [MathDelimiterShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathdelimitershape/) मान के साथ प्रयोग करें। `Centered` कोष्ठकों को गणितीय अक्ष पर केंद्रित करता है, जो बराबर चिह्न के मध्य से गुजरता है। `Match` उन्हें सम्मिलित सामग्री के साथ संरेखित करता है। दोनों सेटिंग्स केवल डिलीमीटर को प्रभावित करती हैं; अंदर की अभिव्यक्ति वही रहती है।

उदाहरण `x` के घातांक में एक भिन्न रखता है ताकि अभिव्यक्ति baseline से ऊपर अधिक विस्तारित हो। सभी चार समीकरण समान कोष्ठक और फ़ॉन्ट सेटिंग्स का उपयोग करते हैं।

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

PowerPoint में, प्रभाव देखने के लिए पंक्तियों की तुलना करें। शीर्ष पंक्ति में, कोष्ठक घातांक को encloses करते हैं और दोनों आकारों में समान दिखते हैं। निचली पंक्ति में, वृद्धि बंद है। बाएँ तरफ छोटे कोष्ठक (`Centered`) बराबर चिह्न के साथ संरेखित होते हैं, जबकि दाएँ (`Match`) अभिव्यक्ति के ऊपर अधिक ऊँचे होते हैं।

![PowerPoint में चार समीकरण जहाँ डिलीमीटर वृद्धि सक्षम और अक्षम है, बाएँ `Centered` और दाएँ `Match`](delimiter-sizing.png)

## **बॉर्डर बॉक्स जोड़ें**

भिन्न पर [toBorderBox](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#toBorderBox) कॉल करें ताकि पूरी अभिव्यक्ति को फ्रेम किया जा सके। लौटाया गया [MathBorderBox](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/) डिफ़ॉल्ट रूप से सभी चार पक्ष दिखाता है। व्यक्तिगत पक्ष हटाने के लिए [setHideTop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setHideTop), [setHideBottom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setHideBottom), [setHideLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setHideLeft), और [setHideRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setHideRight) का प्रयोग करें।

उदाहरण में एक ही भिन्न के छह प्रतियों को एक स्लाइड पर रखा गया है। निरस्तीकरण दिखाने के लिए सभी चार पक्षों को छिपाएँ और `true` को [setStrikethroughBottomLeftToTopRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setStrikethroughBottomLeftToTopRight) में पास करके एक उठती हुई विकर्ण (↗) बनायें या गिरती हुई विकर्ण (↘) के लिए [setStrikethroughTopLeftToBottomRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setStrikethroughTopLeftToBottomRight) का प्रयोग करें। आप किसी भी संयोजन के साथ दृश्यमान पक्षों को रखकर [setStrikethroughHorizontal](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setStrikethroughHorizontal) या [setStrikethroughVertical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setStrikethroughVertical) का भी उपयोग कर सकते हैं।

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

![PowerPoint में छह संपादन योग्य भिन्न। शीर्ष पंक्ति: पूरा बॉर्डर, निचला और बायाँ पक्ष, उठती हुई विकर्ण। निचली पंक्ति: गिरती विकर्ण, क्षैतिज स्ट्राइक, लंबवत स्ट्राइक पूर्ण बॉर्डर के साथ।](border-box-fractions.png)

इस भिन्न में, क्षैतिज स्ट्राइक भिन्न रेखा को ओवरले करता है। लंबवत स्ट्राइक अंश और हरण दोनों को काटता है जबकि आस-पास का बॉर्डर दिखाई देता रहता है। ये लाइनों पूरे अभिव्यक्ति को सजाते हैं। सामान्य टेक्स्ट स्ट्राइक‑थ्रू केवल टेक्स्ट रन के अक्षर पर लागू होता है। PowerPoint में प्रस्तुति को पुनः खोलने के बाद भी आप अंश और हरण को स्वतंत्र रूप से संपादित कर सकते हैं।

## **शर्तें समूहबद्ध करें**

एक अभिव्यक्ति के ऊपर या नीचे समूहबद्ध अक्षर रखने के लिए [group](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#group) का उपयोग करें। समूहबद्ध शर्तों को लेबल करने के लिए एक सीमा जोड़ें।

![अभिव्यक्ति x + y को लेबल "any text" के साथ नीचे समूहित किया गया है](powerpoint-math-equations_15.png)

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

## **गणितीय तत्वों को फ़ॉर्मेट करें**

फ़ॉर्मेटिंग हेल्पर्स का उपयोग केवल तभी करें जब वे सूत्र को स्पष्ट बनाते हों। उदाहरण के लिए, [overbar](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#overbar) एक गणितीय तत्व के ऊपर एक बार रखता है।

![एक गणितीय अभिव्यक्ति ABC के ऊपर ओवरबार के साथ](powerpoint-math-equations_14.png)

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

### **मौजूदा समीकरण में टेक्स्ट फ़ॉर्मेट करें**

एक मौजूद समीकरण में पूरे टेक्स्ट को फ़ॉर्मेट करने के लिए, प्रत्येक गणितीय ब्लॉक की तत्व वृक्ष को ट्रैवर्स करें। [MathElementBase.getChildren](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#getChildren) केवल तत्काल बच्चों को लौटाता है, इसलिए फ़्रैक्शन, स्क्रिप्ट, मूल और अन्य नेस्टेड संरचनाओं के भीतर टेक्स्ट तक पहुँचने के लिए इसे पुनरावृत्त रूप से कॉल करें। वर्तमान तत्व और उसके बच्चों दोनों की जाँच करें ताकि जब वह [MathematicalText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathematicaltext/) हो तो उसे भी शामिल किया जा सके।

यह उदाहरण मानता है कि `input.pptx` में एक समीकरण है, जैसे `z = xᵢ / ∛y`, जहाँ अंश में एक सबस्क्रिप्ट और हर में एक मूल है। केवल ब्लॉक के शीर्ष‑स्तर तत्वों को प्रोसेस करने से फ़्रैक्शन के भीतर का टेक्स्ट छूट जाएगा। उदाहरण स्लाइड टेक्स्ट फ्रेम में गणितीय भागों को ढूँढता है, उनके ब्लॉकों तक [MathPortion.getMathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/#getMathParagraph) के माध्यम से पहुँचता है, और प्रत्येक टेक्स्ट तत्व के [getFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathematicaltext/#getFormat) मेथड के साथ [setFontHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight) को 28 पॉइंट पर सेट करता है।

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

सहेजी गई प्रस्तुति प्रत्येक प्रोसेस किए गए समीकरण के सभी स्तरों पर अपडेटेड टेक्स्ट फ़ॉर्मेटिंग रखती है, जबकि उसके टेक्स्ट कंटेंट और गणितीय संरचना को अपरिवर्तित रखती है।

## **त्वरित संदर्भ**

| कार्य | मुख्य API |
| --- | --- |
| गणितीय टेक्स्ट बनाएं | [MathematicalText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathematicaltext/) |
| तत्वों को मिलाएं | [join](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| भिन्न बनाएं | [divide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| सुपरस्क्रिप्ट या सबस्क्रिप्ट जोड़ें | [setSuperscript](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/), [setSubscript](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| फ़ंक्शन जोड़ें | [function](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/), [asArgumentOfFunction](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| मूल जोड़ें | [radical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| सीमाएँ जोड़ें | [setLowerLimit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/), [setUpperLimit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| बाएँ‑साइड स्क्रिप्ट जोड़ें | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| समिश्रण और इंटीग्रल जोड़ें | [nary](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/), [integral](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| मैट्रिसेज़ जोड़ें | [MathMatrix](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathmatrix/) |
| समीकरण ऐरे जोड़ें | [toMathArray](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| डिलीमीटर जोड़ें | [enclose](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| बार और बॉर्डर जोड़ें | [overbar](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/), [toBorderBox](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| शर्तें समूहबद्ध करें | [group](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं मौजूदा PowerPoint समीकरण को संपादित कर सकता हूँ?**

हाँ। प्रस्तुति खोलें, उस आकार को खोजें जिसमें एक [MathPortion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/) हो, [getMathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/#getMathParagraph) को कॉल करें, और उस पैराग्राफ में गणितीय ब्लॉकों को अपडेट करें।

**क्या समीकरणों को संपादन योग्य PowerPoint गणित के रूप में सहेजा जाता है?**

हाँ। PPTX में सहेजते समय, Aspose.Slides समीकरण को संपादन योग्य Office गणित सामग्री के रूप में लिखता है।

**क्या मैं समीकरणों को LaTeX में निर्यात कर सकता हूँ?**

हाँ। उसके [MathPortion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/) से [MathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathparagraph/) प्राप्त करें, और सीधे निर्यात करने के लिए [MathParagraph.toLatex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathparagraph/#toLatex) को कॉल करें। पूर्ण उदाहरण के लिए देखें [Export Math Equations from Presentations in Node.js via Java](/slides/hi/nodejs-java/exporting-math-equations/#export-math-equations-to-latex)।