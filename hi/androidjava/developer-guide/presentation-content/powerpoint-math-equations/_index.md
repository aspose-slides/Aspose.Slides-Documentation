---
title: Android पर PowerPoint प्रस्तुतियों में गणितीय समीकरण जोड़ें
linktitle: PowerPoint गणितीय समीकरण
type: docs
weight: 80
url: /hi/androidjava/powerpoint-math-equations/
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
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android के साथ PowerPoint PPT और PPTX में गणितीय समीकरण सम्मिलित और संपादित करें, OMML को समर्थन, स्वरूपण नियंत्रण, और स्पष्ट Java कोड नमूने प्रदान करता है।"
---
## **अवलोकन**

PowerPoint समीकरणों को Office Math Markup Language (OMML) के रूप में संग्रहीत करता है। Aspose.Slides for Android via Java के साथ, आप प्रोग्रामmatically वही प्रकार की गणितीय सामग्री बना सकते हैं: भिन्न, मूल, फ़ंक्शन, सीमाएँ, N-ary ऑपरेटर, मैट्रिक्स, ऐरे, और स्वरूपित गणित ब्लॉक।

PowerPoint में, उपयोगकर्ता सामान्यतः **Insert > Equation** से समीकरण जोड़ते हैं:

![PowerPoint Insert टैब जिसमें Equation कमांड चयनित है](powerpoint-math-equations_1.png)

परिणाम स्लाइड पर एक संपादन योग्य गणितीय टेक्स्ट है:

![PowerPoint स्लाइड जिसमें एक संपादन योग्य गणितीय समीकरण है](powerpoint-math-equations_2.png)

Aspose.Slides वह गणितीय टेक्स्ट तीन मुख्य वस्तुओं के माध्यम से बनाता है:

- एक गणितीय आकार, जिसे [addMathShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/) से बनाया जाता है, वह आकार है जो समीकरण को शामिल करता है।
- [MathPortion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathportion/) आकार के टेक्स्ट फ्रेम के भीतर गणितीय सामग्री संग्रहीत करता है।
- [MathParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathparagraph/) एक या अधिक [MathBlock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathblock/) वस्तुओं को रखता है।

नीचे के अधिकांश उदाहरण [MathematicalText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathematicaltext/) और [IMathElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) की फ्लुएंट विधियों का उपयोग करके कोड को छोटा और पढ़ने योग्य रखते हैं।

MathML निर्यात परिदृश्यों के लिए, देखें [Export Math Equations from Presentations on Android](/slides/hi/androidjava/exporting-math-equations/)।

## **समीकरण बनाएँ**

यह उदाहरण [addMathShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addMathShape-float-float-float-float-) का उपयोग करके एक गणितीय आकार बनाता है और पायथागोरस प्रमेय जोड़ता है:

![समीकरण c² = a² + b²](powerpoint-math-equations_3.png)

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 120);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathBlock equation = new MathematicalText("c")
            .setSuperscript("2")
            .join("=")
            .join(new MathematicalText("a").setSuperscript("2"))
            .join("+")
            .join(new MathematicalText("b").setSuperscript("2"));

    mathParagraph.add(equation);

    presentation.save("pythagorean-theorem.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
[addMathShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addMathShape-float-float-float-float-) एक आकार बनाता है जिसमें पहले से ही एक गणितीय पैराग्राफ शामिल होता है। पहले के [MathPortion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathportion/) तक पहुँचें, [getMathParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathportion/#getMathParagraph--) को कॉल करें, और उसमें गणितीय ब्लॉक या तत्व जोड़ें।
{{% /alert %}}

## **भिन्न जोड़ें**

[divide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#divide-com.aspose.slides.IMathElement-) का उपयोग करके एक भिन्न बनाएँ। आप [MathFractionTypes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathfractiontypes/) के साथ एक भिन्न शैली चुन सकते हैं।

![एक तिरछा गणितीय भिन्न जिसमें एक को x से विभाजित दिखाया गया है](powerpoint-math-equations_4.png)

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathFraction fraction = new MathematicalText("1")
            .divide("x", MathFractionTypes.Skewed);

    mathParagraph.add(new MathBlock(fraction));

    presentation.save("fraction.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

स्टैक्ड भिन्न के लिए, [MathFractionTypes.Bar](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathfractiontypes/#Bar) का उपयोग करें:

```java
import com.aspose.slides.*;

IMathFraction stackedFraction = new MathematicalText("x + 1").divide("y - 1", MathFractionTypes.Bar);
```

## **मूल जोड़ें**

[radical](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#radical-com.aspose.slides.IMathElement-) का उपयोग करके वर्गमूल, घनमूल, या अन्य मूल बनाएँ। वर्तमान तत्व आधार बन जाता है, और तर्क डिग्री बन जाता है।

![एक n‑था मूल अभिव्यक्ति जिसमें x मूल चिह्न के नीचे है](powerpoint-math-equations_5.png)

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathRadical radical = new MathematicalText("x")
            .radical("n");

    mathParagraph.add(new MathBlock(radical));

    presentation.save("radical.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **फ़ंक्शन और सीमाएँ जोड़ें**

[asArgumentOfFunction](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#asArgumentOfFunction-com.aspose.slides.IMathElement-) या [function](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#function-com.aspose.slides.IMathElement-) का उपयोग करके `sin(x)`, `log(x)` या कस्टम फ़ंक्शन नाम बनाएँ। सीमाओं के लिए, `lim` को [MathLimit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathlimit/) में रखें या [setLowerLimit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#setLowerLimit-com.aspose.slides.IMathElement-) का उपयोग करें।

![x का सीमांत मान जब x अनंत की ओर बढ़ता है](powerpoint-math-equations_8.png)

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathFunction limit = new MathematicalText("lim")
            .setLowerLimit("x→∞")
            .function("x");

    mathParagraph.add(new MathBlock(limit));

    presentation.save("functions-and-limits.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

कस्टम फ़ंक्शन नाम के लिए, फ़ंक्शन नाम को वर्तमान तत्व बनाएँ और उसके तर्क के साथ [function](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#function-com.aspose.slides.IMathElement-) को कॉल करें:

```java
import com.aspose.slides.*;

IMathFunction customFunction = new MathematicalText("f").function("x + 1");
```

## **N-ary ऑपरेटर और इंटीग्रल जोड़ें**

सम, यूनियन, इंटरसेक्शन और अन्य बड़े ऑपरेटर के लिए [nary](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#nary-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-) का उपयोग करें। इंटीग्रल के लिए [integral](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#integral-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-) का उपयोग करें। दोनों विधियां निचली और ऊपरी सीमाएँ सेट करने की अनुमति देती हैं।

![निचली और ऊपरी सीमाओं के साथ एक समाकलन](powerpoint-math-equations_7.png)

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 120);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathBlock summationBase = new MathematicalText("x")
            .setSuperscript("k")
            .join(new MathematicalText("a").setSuperscript("n-k"));

    IMathNaryOperator summation = summationBase.nary(MathNaryOperatorTypes.Summation, "k=0", "n");

    mathParagraph.add(new MathBlock(summation));

    presentation.save("nary-operators.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

N-ary ऑपरेटर बड़े ऑपरेटर होते हैं जिनमें वैकल्पिक सीमाएँ हो सकती हैं। सरल ऑपरेटर जैसे `+`, `-`, और `=` आमतौर पर [MathematicalText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathematicaltext/) द्वारा जोड़े जाते हैं और अभिव्यक्ति में सम्मिलित किए जाते हैं।

इंटीग्रल के लिए, [integral](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#integral-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-) का उपयोग करें:

```java
import com.aspose.slides.*;

IMathBlock integralBase = new MathematicalText("x").join(new MathematicalText("dx").toBox());
IMathNaryOperator integral = integralBase.integral(MathIntegralTypes.Simple, "0", "1");
```

## **मैट्रिक्स जोड़ें**

पंक्तियों और स्तंभों के लिए [MathMatrix](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathmatrix/) का उपयोग करें। मैट्रिक्स डिफ़ॉल्ट रूप से कोष्ठक शामिल नहीं करता, इसलिए जब आपको कोष्ठक, ब्रैकेट या कर्ली ब्रेसेस चाहिए तब उन्हें स्वयं जोड़ें।

![दो पंक्तियों वाला गणितीय मैट्रिक्स जिसमें एक खाली सेल है](powerpoint-math-equations_10.png)

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 120);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    MathMatrix matrix = new MathMatrix(2, 3);
    matrix.set_Item(0, 0, new MathematicalText("1"));
    matrix.set_Item(0, 1, new MathematicalText("x"));
    matrix.set_Item(1, 0, new MathematicalText("x"));
    matrix.set_Item(1, 1, new MathematicalText("2"));
    matrix.set_Item(1, 2, new MathematicalText("y"));

    mathParagraph.add(new MathBlock(matrix));

    presentation.save("matrix.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **समीकरण ऐरे जोड़ें**

जब आपको संरेखित समीकरण या अभिव्यक्तियों का लंबवत स्टैक चाहिए, तब [toMathArray](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#toMathArray--) का उपयोग करें।

![ऊपर x और नीचे y के साथ एक लंबवत गणितीय ऐरे](powerpoint-math-equations_11.png)

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 140);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathArray equationArray = new MathematicalText("x")
            .join("y")
            .toMathArray();

    mathParagraph.add(new MathBlock(equationArray));

    presentation.save("equation-array.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **त्रिकोणमितीय फ़ंक्शन जोड़ें**

जब तर्क वर्तमान तत्व है और फ़ंक्शन नाम ज्ञात है, तब [asArgumentOfFunction](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#asArgumentOfFunction-com.aspose.slides.IMathElement-) का उपयोग करें।

![cos फ़ंक्शन को 2x पर लागू किया गया है](powerpoint-math-equations_6.png)

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathFunction cosine = new MathematicalText("2x")
            .asArgumentOfFunction(MathFunctionsOfOneArgument.Cos);

    mathParagraph.add(new MathBlock(cosine));

    presentation.save("trigonometric-function.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **सबस्क्रिप्ट और सुपरस्क्रिप्ट जोड़ें**

इंडेक्स और घात के लिए सबस्क्रिप्ट और सुपरस्क्रिप्ट सहायक का उपयोग करें। जब इंडेक्स बाएँ ओर दिखाई देना चाहिए, तो [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#setSubSuperscriptOnTheLeft-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-) का उपयोग करें।

![बाएँ‑साइड सबस्क्रिप्ट 1 और सुपरस्क्रिप्ट n के साथ बड़ा Y](powerpoint-math-equations_9.png)

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathLeftSubSuperscriptElement scripts = new MathematicalText("Y")
            .setSubSuperscriptOnTheLeft("1", "n");

    mathParagraph.add(new MathBlock(scripts));

    presentation.save("subscript-superscript.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **डिलिमिटर जोड़ें**

एक अभिव्यक्ति को डिलिमिटर के भीतर रखने के लिए [enclose](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#enclose-char-char-) का उपयोग करें। आप कई तत्वों वाली अभिव्यक्तियों के लिए विभाजक वर्ण भी सेट कर सकते हैं।

![x, y और z को लंबवत बार द्वारा अलग किया गया डिलिमिटर अभिव्यक्ति](powerpoint-math-equations_13.png)

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathDelimiter delimiter = new MathematicalText("x")
            .join("y")
            .join("z")
            .enclose('<', '>');
    delimiter.setSeparatorCharacter('|');

    mathParagraph.add(new MathBlock(delimiter));

    presentation.save("delimiters.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **डिलिमिटर का आकार और संरेखण**

`[setGrowToMatchOperandHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathdelimiter/#setGrowToMatchOperandHeight-boolean-)` को `true` सेट करके बड़े ऑपरेन्ड के आसपास कोष्ठक बढ़ने दें, या `false` सेट करके उनका सामान्य आकार रखें। `[setDelimiterShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathdelimiter/#setDelimiterShape-int-)` को दो में से किसी एक `[MathDelimiterShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathdelimitershape/)` मान के साथ उपयोग करें। `Centered` कोष्ठकों को गणितीय अक्ष पर केंद्रित करता है, जो बराबर चिह्न के मध्य में होता है। `Match` उन्हें सम्मिलित सामग्री के साथ संरेखित करता है। दोनों सेटिंग केवल डिलिमिटर को प्रभावित करती हैं; अभिव्यक्ति स्वयं अपरिवर्तित रहती है।

उदाहरण में `x` के एक्सपोनेंट में एक भिन्न रखा गया है जिससे अभिव्यक्ति बेसलाइन के ऊपर अधिक विस्तारित होती है। सभी चार समीकरण समान कोष्ठक और फ़ॉन्ट सेटिंग्स का उपयोग करते हैं।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    for (int row = 0; row < 2; row++) {
        for (int column = 0; column < 2; column++) {
            IMathFraction fraction = new MathematicalText("a + b").divide("c + d");
            IMathSuperscriptElement power = new MathematicalText("x").setSuperscript(fraction);
            IMathDelimiter delimiter = power.enclose('(', ')');
            delimiter.setGrowToMatchOperandHeight(row == 0);
            delimiter.setDelimiterShape(column == 0 ? MathDelimiterShape.Centered : MathDelimiterShape.Match);

            IAutoShape mathShape = slide.getShapes().addMathShape(20 + 330 * column, 20 + 120 * row, 300, 100);
            MathPortion portion = (MathPortion) mathShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
            portion.getPortionFormat().setFontHeight(32);
            IMathBlock equation = new MathematicalText("y = ").join(delimiter);
            portion.getMathParagraph().add(equation);
        }
    }
    presentation.save("delimiter-sizing.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

PowerPoint में, पंक्तियों की तुलना करके वृद्धि का प्रभाव देखें। शीर्ष पंक्ति में, कोष्ठक एक्सपोनेंट को घेरने के लिए बढ़ते हैं और दोनों आकार समान दिखते हैं। नीचे की पंक्ति में, वृद्धि बंद है। बाएँ ओर छोटे कोष्ठक (`Centered`) बराबर चिह्न के साथ संरेखित होते हैं, जबकि दाएँ ओर (`Match`) अभिव्यक्ति के ऊपर अधिक स्थित होते हैं।

![PowerPoint में चार समीकरण जिनमें डिलिमिटर वृद्धि सक्षम और अक्षम है, बाएँ `Centered` और दाएँ `Match`](delimiter-sizing.png)

## **बॉर्डर बॉक्स जोड़ें**

किसी भिन्न पर [toBorderBox](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#toBorderBox--) को कॉल करके पूरे अभिव्यक्ति को फ़्रेम करें। लौटाया गया [IMathBorderBox](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathborderbox/) डिफ़ॉल्ट रूप से चारों पक्ष दिखाता है। `[setHideTop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathborderbox/#setHideTop-boolean-)`, `[setHideBottom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathborderbox/#setHideBottom-boolean-)`, `[setHideLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathborderbox/#setHideLeft-boolean-)` और `[setHideRight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathborderbox/#setHideRight-boolean-)` का उपयोग करके व्यक्तिगत पक्ष को हटाएँ।

उदाहरण में एक ही स्लाइड पर समान भिन्न की छह प्रतियां रखी गई हैं। रद्दीकरण दिखाने के लिए सभी चार पक्षों को छिपाएँ और `[setStrikethroughBottomLeftToTopRight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathborderbox/#setStrikethroughBottomLeftToTopRight-boolean-)` को `true` सेट करके एक ऊपर‑बाएँ से नीचे‑दाएँ तिर्यक (↗) बनाएँ या `[setStrikethroughTopLeftToBottomRight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathborderbox/#setStrikethroughTopLeftToBottomRight-boolean-)` को `true` सेट करके नीचे‑बाएँ से ऊपर‑दाएँ तिर्यक (↘) बनाएँ। आप किसी भी दृश्यमान पक्ष के साथ `[setStrikethroughHorizontal](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathborderbox/#setStrikethroughHorizontal-boolean-)` या `[setStrikethroughVertical](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathborderbox/#setStrikethroughVertical-boolean-)` का भी उपयोग कर सकते हैं।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(540, 220, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    class FractionBuilder {
        IMathBorderBox addFraction(float x, float y, boolean hideBorder) {
            IMathFraction fraction = new MathematicalText("x+1").divide("y+2");
            IMathBorderBox box = fraction.toBorderBox();
            box.setHideTop(hideBorder);
            box.setHideBottom(hideBorder);
            box.setHideLeft(hideBorder);
            box.setHideRight(hideBorder);

            IAutoShape shape = slide.getShapes().addMathShape(x, y, 160, 90);
            MathPortion portion = (MathPortion) shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
            portion.getPortionFormat().setFontHeight(28);
            portion.getMathParagraph().add(new MathBlock(box));
            return box;
        }
    }

    FractionBuilder builder = new FractionBuilder();
    builder.addFraction(10, 10, false);

    IMathBorderBox partial = builder.addFraction(190, 10, false);
    partial.setHideTop(true);
    partial.setHideRight(true);

    builder.addFraction(370, 10, true).setStrikethroughBottomLeftToTopRight(true);
    builder.addFraction(10, 120, true).setStrikethroughTopLeftToBottomRight(true);
    builder.addFraction(190, 120, true).setStrikethroughHorizontal(true);
    builder.addFraction(370, 120, false).setStrikethroughVertical(true);

    presentation.save("border-box.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![छह संपादन योग्य भिन्न PowerPoint में। शीर्ष पंक्ति: पूर्ण बॉर्डर, नीचे और बाएँ पक्ष, बढ़ता तिर्यक। नीचे पंक्ति: गिरता तिर्यक, क्षैतिज स्ट्राइक, लंबवत स्ट्राइक पूर्ण बॉर्डर के साथ।](border-box-fractions.png)

इस भिन्न पर, क्षैतिज स्ट्राइक भिन्न रेखा को ओवरलैप करता है। लंबवत स्ट्राइक अंसर दोनों अंश और हर को पार करता है जबकि चारों ओर का बॉर्डर दृश्यमान रहता है। ये रेखाएँ पूरी अभिव्यक्ति को सजाती हैं। सामान्य टेक्स्ट स्ट्राइकथ्रू अक्षर रन में लागू होता है। PowerPoint में प्रस्तुति को पुनः खोलने के बाद, आप अंश और हर को स्वतंत्र रूप से संपादित कर सकते हैं।

## **टर्म समूहित करें**

[group](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#group-char-int-int-) का उपयोग करके किसी अभिव्यक्ति के ऊपर या नीचे ग्रुपिंग कैरेक्टर रखें। समूहित टर्म को लेबल करने के लिए एक सीमा जोड़ें।

![अभिव्यक्ति x + y को नीचे किसी पाठ के लेबल के साथ समूहित किया गया है](powerpoint-math-equations_15.png)

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 120);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathLimit grouped = new MathematicalText("x + y")
            .group('\u23DF', MathTopBotPositions.Bottom, MathTopBotPositions.Top)
            .setLowerLimit("any text");

    mathParagraph.add(new MathBlock(grouped));

    presentation.save("grouped-terms.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **गणितीय तत्वों को स्वरूपित करें**

केवल तभी स्वरूपण सहायक का उपयोग करें जब वह सूत्र को स्पष्ट बनाता हो। उदाहरण के लिये, [overbar](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#overbar--) गणितीय तत्व के ऊपर एक बार रखता है।

![एक गणितीय अभिव्यक्ति ABC जिसमें ओवरबार है](powerpoint-math-equations_14.png)

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathBar overbar = new MathematicalText("ABC").overbar();

    mathParagraph.add(new MathBlock(overbar));

    presentation.save("overbar.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **मौजूद समीकरण में टेक्स्ट स्वरूपित करें**

मौजूद समीकरण में पूरे टेक्स्ट को स्वरूपित करने के लिए, प्रत्येक गणितीय ब्लॉक के तत्व वृक्ष को पार करें। `[IMathElement.getChildren](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#getChildren--)` केवल सीधे बच्चे लौटाता है, इसलिए भिन्न, स्क्रिप्ट, मूल और अन्य नेस्टेड संरचनाओं के भीतर टेक्स्ट तक पहुँचने के लिए इसे पुनरावर्ती रूप से कॉल करें। वर्तमान तत्व और उसके बच्चों दोनों को जांचें ताकि प्रारंभिक तत्व को भी शामिल किया जाए जब वह [MathematicalText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathematicaltext/) हो।

यह उदाहरण मानता है कि `input.pptx` में `z = xᵢ / ∛y` जैसा समीकरण है, जिसमें अंश में एक सबस्क्रिप्ट और हर में एक मूल है। केवल ब्लॉक के शीर्ष‑स्तर के तत्वों को प्रोसेस करने से भिन्न के भीतर का टेक्स्ट छूट जाएगा। उदाहरण स्लाइड टेक्स्ट फ्रेम में गणितीय भाग खोजता है, उनके ब्लॉक को `[IMathPortion.getMathParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathportion/#getMathParagraph--)` से प्राप्त करता है, और प्रत्येक टेक्स्ट तत्व के `[getFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathematicaltext/#getFormat--)` मेथड के माध्यम से `[setFontHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-)` को 28 पॉइंट पर सेट करता है।

```java
import com.aspose.slides.*;

class MathTextFormatter {
    void formatMathText(IMathElement element) {
        if (element instanceof MathematicalText) {
            MathematicalText text = (MathematicalText) element;
            text.getFormat().setFontHeight(28);
        }

        for (IMathElement child : element.getChildren()) {
            formatMathText(child);
        }
    }
}

MathTextFormatter formatter = new MathTextFormatter();
Presentation presentation = new Presentation("input.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (!(shape instanceof IAutoShape)) {
                continue;
            }

            IAutoShape autoShape = (IAutoShape) shape;
            if (autoShape.getTextFrame() == null) {
                continue;
            }

            for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs()) {
                for (IPortion portion : paragraph.getPortions()) {
                    if (portion instanceof IMathPortion) {
                        IMathPortion mathPortion = (IMathPortion) portion;
                        for (IMathBlock block : mathPortion.getMathParagraph()) {
                            formatter.formatMathText(block);
                        }
                    }
                }
            }
        }
    }

    presentation.save("formatted-equations.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

सहेजी गई प्रस्तुति प्रत्येक प्रोसेस किए गए समीकरण के हर स्तर पर अद्यतन टेक्स्ट स्वरूपण रखती है, जबकि उसके टेक्स्ट कंटेंट और गणितीय संरचना को संरक्षित करती है।

## **त्वरित संदर्भ**

| कार्य | मुख्य API |
| --- | --- |
| गणितीय टेक्स्ट बनाएँ | [MathematicalText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathematicaltext/) |
| तत्वों को जोड़ें | [IMathElement.join](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) |
| भिन्न बनाएँ | [IMathElement.divide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) |
| सुपरस्क्रिप्ट या सबस्क्रिप्ट जोड़ें | [setSuperscript](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/), [setSubscript](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) |
| फ़ंक्शन जोड़ें | [function](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/), [asArgumentOfFunction](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) |
| मूल जोड़ें | [IMathElement.radical](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) |
| सीमाएँ जोड़ें | [setLowerLimit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/), [setUpperLimit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) |
| बाएँ‑साइड स्क्रिप्ट जोड़ें | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) |
| सम और इंटीग्रल जोड़ें | [nary](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/), [integral](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) |
| मैट्रिक्स जोड़ें | [MathMatrix](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathmatrix/) |
| समीकरण ऐरे जोड़ें | [toMathArray](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) |
| डिलिमिटर जोड़ें | [enclose](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) |
| बार और बॉर्डर जोड़ें | [overbar](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/), [toBorderBox](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) |
| टर्म समूहित करें | [group](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) |

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं मौजूदा PowerPoint समीकरण को संपादित कर सकता हूँ?**

हाँ। प्रस्तुति खोलें, वह आकार खोजें जिसमें एक [MathPortion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathportion/) हो, [getMathParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathportion/#getMathParagraph--) को कॉल करें, और उस पैराग्राफ में गणितीय ब्लॉक अपडेट करें।

**क्या समीकरण संपादन योग्य PowerPoint गणित के रूप में सहेजे जाते हैं?**

हाँ। PPTX में सहेजते समय, Aspose.Slides समीकरण को संपादन योग्य Office गणित सामग्री के रूप में लिखता है।

**क्या मैं समीकरणों को LaTeX में निर्यात कर सकता हूँ?**

हाँ। उसका [IMathParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathparagraph/) उसके [IMathPortion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathportion/) से प्राप्त करें, और [IMathParagraph.toLatex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathparagraph/#toLatex--) को कॉल करके सीधे निर्यात करें। पूर्ण उदाहरण के लिए देखें [Export Math Equations from Presentations in Android via Java](/slides/hi/androidjava/exporting-math-equations/#export-math-equations-to-latex)।