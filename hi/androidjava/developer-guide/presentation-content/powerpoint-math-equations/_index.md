---
title: Android पर PowerPoint प्रस्तुतियों में गणितीय समीकरण जोड़ें
linktitle: PowerPoint गणितीय समीकरण
type: docs
weight: 80
url: /hi/androidjava/powerpoint-math-equations/
keywords:
- गणितीय समीकरण
- गणित चिह्न
- गणितीय सूत्र
- गणितीय पाठ
- गणितीय समीकरण जोड़ें
- गणित चिह्न जोड़ें
- गणितीय सूत्र जोड़ें
- गणितीय पाठ जोड़ें
- PowerPoint
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android के साथ PowerPoint PPT और PPTX में गणितीय समीकरण सम्मिलित और संपादित करें, OMML का समर्थन, फ़ॉर्मेटिंग नियंत्रण, और स्पष्ट Java कोड नमूने।"
---
## **अवलोकन**

PowerPoint समीकरणों को Office Math Markup Language (OMML) के रूप में संग्रहीत करता है। Aspose.Slides for Android via Java के साथ, आप प्रोग्रामेटिक रूप से वही प्रकार की गणितीय सामग्री बना सकते हैं: भिन्न, रैडिकल, फ़ंक्शन, सीमाएँ, N-आरी ऑपरेटर, मैट्रिक्स, एरे, और स्वरूपित गणित ब्लॉक।

PowerPoint में, उपयोगकर्ता आमतौर पर **Insert > Equation** से समीकरण जोड़ते हैं:

![PowerPoint Insert tab with the Equation command selected](powerpoint-math-equations_1.png)

परिणाम स्लाइड पर एक संपादन योग्य गणितीय टेक्स्ट होता है:

![A PowerPoint slide containing an editable math equation](powerpoint-math-equations_2.png)

Aspose.Slides इस गणितीय टेक्स्ट को तीन मुख्य वस्तुओं के माध्यम से बनाता है:

- एक गणितीय शैल, जिसे [addMathShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/) से बनाया जाता है, वह शैल है जिसमें समीकरण सम्मिलित होता है।
- [MathPortion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathportion/) शैल के टेक्स्ट फ्रेम के भीतर गणितीय सामग्री संग्रहीत करता है।
- [MathParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathparagraph/) एक या अधिक [MathBlock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathblock/) वस्तुओं को शामिल करता है।

नीचे के अधिकांश उदाहरण [MathematicalText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathematicaltext/) और [IMathElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) की फ्लुएंट मेथड्स का उपयोग करके कोड को छोटा और पठनीय रखते हैं।

MathML निर्यात परिदृश्यों के लिए, देखें [Export Math Equations from Presentations on Android](/slides/hi/androidjava/exporting-math-equations/)।

## **समीकरण बनाएँ**

यह उदाहरण [addMathShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addMathShape-float-float-float-float-) का उपयोग करके एक गणितीय शैल बनाता है और पाइथागोरस प्रमेय जोड़ता है:

![The equation c squared equals a squared plus b squared](powerpoint-math-equations_3.png)

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

{{% alert color="info" title="ध्यान दें" %}}

[addMathShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addMathShape-float-float-float-float-) एक ऐसी शैल बनाता है जिसमें पहले से ही एक गणितीय पैराग्राफ शामिल होता है। पहले [MathPortion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathportion/) तक पहुँचें, [getMathParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathportion/#getMathParagraph--) को कॉल करें, और उसमें गणितीय ब्लॉक या तत्व जोड़ें।

{{% /alert %}}

## **भिन्न जोड़ें**

एक भिन्न बनाने के लिए [divide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#divide-com.aspose.slides.IMathElement-) का उपयोग करें। आप [MathFractionTypes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathfractiontypes/) के साथ भिन्न शैली चुन सकते हैं।

![A skewed math fraction showing one divided by x](powerpoint-math-equations_4.png)

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

## **वर्गमूल जोड़ें**

एक वर्गमूल, घनमूल या अन्य मूल बनाने के लिए [radical](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#radical-com.aspose.slides.IMathElement-) का उपयोग करें। वर्तमान तत्व आधार बन जाता है, और तर्क डिग्री बन जाता है।

![An n-th root radical expression with x under the radical sign](powerpoint-math-equations_5.png)

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

फ़ंक्शन जैसे `sin(x)`, `log(x)` या कस्टम फ़ंक्शन नामों के लिए [asArgumentOfFunction](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#asArgumentOfFunction-com.aspose.slides.IMathElement-) या [function](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#function-com.aspose.slides.IMathElement-) का उपयोग करें। सीमाओं के लिए, `lim` को एक [MathLimit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathlimit/) में रखें, या [setLowerLimit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#setLowerLimit-com.aspose.slides.IMathElement-) का प्रयोग करें।

![The limit of x as x approaches infinity](powerpoint-math-equations_8.png)

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

कस्टम फ़ंक्शन नाम के लिये, फ़ंक्शन नाम को वर्तमान तत्व बनायें और उसके तर्क के साथ [function](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#function-com.aspose.slides.IMathElement-) को कॉल करें:

```java
import com.aspose.slides.*;

IMathFunction customFunction = new MathematicalText("f").function("x + 1");
```

## **N-आरी ऑपरेटर और समाकल जोड़ें**

संकलन, संघ, प्रतिच्छेद और अन्य बड़े ऑपरेटरों के लिये [nary](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#nary-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-) का उपयोग करें। समाकलों के लिये [integral](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#integral-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-) का उपयोग करें। दोनों मेथड आपको निचली और ऊपरी सीमाएँ सेट करने की अनुमति देते हैं।

![A summation with lower and upper limits](powerpoint-math-equations_7.png)

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

N-आरी ऑपरेटर बड़े ऑपरेटरों के लिये होते हैं जिनमें वैकल्पिक सीमाएँ हो सकती हैं। साधारण ऑपरेटर जैसे `+`, `-`, और `=` आमतौर पर [MathematicalText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathematicaltext/) के रूप में जोड़े जाते हैं और अभिव्यक्ति में सम्मिलित होते हैं।

समाकल के लिये, [integral](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#integral-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-) का उपयोग करें:

```java
import com.aspose.slides.*;

IMathBlock integralBase = new MathematicalText("x").join(new MathematicalText("dx").toBox());
IMathNaryOperator integral = integralBase.integral(MathIntegralTypes.Simple, "0", "1");
```

## **मैट्रिक्स जोड़ें**

पंक्तियों और स्तम्भों के लिये [MathMatrix](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathmatrix/) का उपयोग करें। डिफ़ॉल्ट रूप से मैट्रिक्स में ब्रैकेट नहीं होते, इसलिए जब आपको कोष्ठक, ब्रेस या कर्ली ब्रेसेस चाहिए हों तो मैट्रिक्स को घेरें।

![A two-row math matrix with one empty cell](powerpoint-math-equations_10.png)

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

## **समीकरण एरे जोड़ें**

जब आप संरेखित समीकरणों या वर्टिकल स्टैक अभिव्यक्तियों की आवश्यकता हों तो [toMathArray](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#toMathArray--) का उपयोग करें।

![A vertical math array with x above y](powerpoint-math-equations_11.png)

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

### **आस-पास के तत्वों के साथ एरे को संरेखित करें**

[setBaseJustification](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imatharray/#setBaseJustification-int-) एरे को आसपास के गणितीय तत्वों के सापेक्ष ऊर्ध्वाधर संरेखण को नियंत्रित करता है। नीचे दिया गया उदाहरण पहली पंक्ति, एरे के केंद्र, और अंतिम पंक्ति के साथ संरेखण की तुलना करता है।

निम्न उदाहरण तीन समान एरे बनाता है, प्रत्येक में तीन पंक्तियाँ हैं और पड़ोसी तत्व `A=` और `=B` हैं। सभी गणितीय टेक्स्ट Cambria Math फ़ॉन्ट में 24 पॉइंट के साथ है। केवल एरे का संरेखण बदलता है।

```java
import com.aspose.slides.*;
import android.graphics.Color;

class MathTextFactory {
    MathematicalText createText(String value) {
        MathematicalText text = new MathematicalText(value);
        text.getFormat().setFontHeight(24);
        text.getFormat().setLatinFont(new FontData("Cambria Math"));
        return text;
    }
}

MathTextFactory factory = new MathTextFactory();
Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(780, 200, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    int[] alignments = { MathVerticalAlignment.Top, MathVerticalAlignment.Center, MathVerticalAlignment.Bottom };
    String[] alignmentNames = { "Top", "Center", "Bottom" };

    for (int i = 0; i < alignments.length; i++) {
        IAutoShape label = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20 + i * 260, 10, 240, 30);
        label.getFillFormat().setFillType(FillType.NoFill);
        label.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
        label.getTextFrame().setText(alignmentNames[i]);
        IPortionFormat labelFormat = label.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
        labelFormat.setFontHeight(16);
        labelFormat.getFillFormat().setFillType(FillType.Solid);
        labelFormat.getFillFormat().getSolidFillColor().setColor(Color.BLACK);

        IAutoShape mathShape = slide.getShapes().addMathShape(20 + i * 260, 60, 240, 130);
        mathShape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Top);
        IMathParagraph mathParagraph = ((IMathPortion) mathShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)).getMathParagraph();
        mathParagraph.setJustification(MathJustification.LeftJustified);

        IMathElement[] rows = { factory.createText("x+y=3"), factory.createText("x-y=1"), factory.createText("x=2") };
        MathArray equationArray = new MathArray(rows[0]);
        equationArray.getArguments().add(rows[1]);
        equationArray.getArguments().add(rows[2]);
        equationArray.setBaseJustification(alignments[i]);
        MathematicalText leftText = factory.createText("A=");
        MathematicalText rightText = factory.createText("=B");
        IMathBlock equation = new MathBlock(leftText).join(equationArray).join(rightText);
        mathParagraph.add(equation);
    }

    presentation.save("equation-array-alignment.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

नीचे का तुलना PowerPoint में सहेजी गई प्रस्तुति दिखाता है। प्रत्येक एरे के बगल में `A=` और `=B` की स्थिति देखें।

![Equation arrays in PowerPoint with Top, Center, and Bottom alignment and identical neighboring elements](equation-array-alignment.png)

### **पंक्ति अंतराल सेट करें**

[setRowSpacingRule](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imatharray/#setRowSpacingRule-int-) एरे के भीतर पंक्तियों के अंतराल नियम को चुनता है। [setRowSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imatharray/#setRowSpacing-long-) स्पष्ट अंतराल नियम के लिये संख्यात्मक मान प्रदान करता है और प्रीसेट नियमों को अनदेखा करता है।

सटीक अंतराल के लिये, मान पॉइंट्स में मापा जाता है। अनुपातिक अंतराल के लिये, यह आधी‑लाइन में मापा जाता है: उदाहरण में मान `3` का अर्थ 1.5 लाइन्स है। स्पष्ट मान निर्दिष्ट करते समय दोनों गुणधर्म सेट करें; केवल संख्यात्मक मान बदलने से अंतराल नियम नहीं चुना जाता।

नीचे का उदाहरण पाँच प्रस्तुतियों को समान समीकरणों, संरेखण, और फ़ॉन्ट सेटिंग्स के साथ सहेजता है। पहली तीन में प्रीसेट उपयोग होते हैं; अंतिम दो में स्पष्ट मान दर्शाए गए हैं।

```java
import com.aspose.slides.*;

class MathTextFactory {
    MathematicalText createText(String value) {
        MathematicalText text = new MathematicalText(value);
        text.getFormat().setFontHeight(24);
        text.getFormat().setLatinFont(new FontData("Cambria Math"));
        return text;
    }
}

MathTextFactory factory = new MathTextFactory();
int[] rules = { MathRowSpacingRule.SingleLineGap, MathRowSpacingRule.OneAndAHalfLineGap, MathRowSpacingRule.TwoLineGap, MathRowSpacingRule.Exactly, MathRowSpacingRule.Multiple };
int[] spacingValues = { 0, 0, 0, 20, 3 };
String[] ruleNames = { "SingleLineGap", "OneAndAHalfLineGap", "TwoLineGap", "Exactly", "Multiple" };

for (int i = 0; i < rules.length; i++) {
    String fileName = "equation-array-" + ruleNames[i] + ".pptx";
    Presentation presentation = new Presentation();
    try {
        IAutoShape mathShape = presentation.getSlides().get_Item(0).getShapes().addMathShape(20, 20, 600, 300);
        IParagraph paragraph = mathShape.getTextFrame().getParagraphs().get_Item(0);
        paragraph.getParagraphFormat().setSpaceBefore(0);
        paragraph.getParagraphFormat().setSpaceAfter(0);
        IMathParagraph mathParagraph = ((IMathPortion) paragraph.getPortions().get_Item(0)).getMathParagraph();
        mathParagraph.setJustification(MathJustification.LeftJustified);

        IMathElement[] rows = { factory.createText("x+y=3"), factory.createText("x-y=1"), factory.createText("x=2") };
        MathArray equationArray = new MathArray(rows[0]);
        equationArray.getArguments().add(rows[1]);
        equationArray.getArguments().add(rows[2]);
        equationArray.setBaseJustification(MathVerticalAlignment.Center);
        equationArray.setRowSpacingRule(rules[i]);
        equationArray.setRowSpacing(spacingValues[i]);
        MathematicalText leftText = factory.createText("A=");
        MathematicalText rightText = factory.createText("=B");
        IMathBlock equation = new MathBlock(leftText).join(equationArray).join(rightText);
        mathParagraph.add(equation);

        presentation.save(fileName, SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

एरे पंक्ति अंतराल पैराग्राफ अंतराल से अलग होता है। [setSpaceBefore](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setSpaceBefore-float-) और [setSpaceAfter](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setSpaceAfter-float-) कंटेनिंग पैराग्राफ के चारों ओर स्थान जोड़ते हैं, न कि एरे पंक्तियों के बीच। इसी तरह, [IMathParagraph.setJustification](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathparagraph/#setJustification-int-) पूरे गणितीय पैराग्राफ को क्षैतिज रूप से स्थित करता है; यह एरे की ऊर्ध्वाधर संरेखण सेटिंग को नहीं बदलता।

## **त्रिकोणमितीय फ़ंक्शन जोड़ें**

जब तर्क वर्तमान तत्व है और फ़ंक्शन नाम ज्ञात है, तब [asArgumentOfFunction](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#asArgumentOfFunction-com.aspose.slides.IMathElement-) का उपयोग करें।

![The trigonometric function cos applied to 2x](powerpoint-math-equations_6.png)

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

इंडेक्स और घातांक के लिये सबस्क्रिप्ट और सुपरस्क्रिप्ट सहायक का प्रयोग करें। जब इंडेक्स को आधार के बायीं ओर दिखाना हो, तो [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#setSubSuperscriptOnTheLeft-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-) का प्रयोग करें।

![A capital Y with left-side subscript 1 and superscript n](powerpoint-math-equations_9.png)

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

एक अभिव्यक्ति को डिलिमिटर में रखने के लिये [enclose](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#enclose-char-char-) का प्रयोग करें। आप कई तत्वों वाली डिलिमिटर अभिव्यक्तियों के लिये एक विभाजक अक्षर भी सेट कर सकते हैं।

![A delimiter expression containing x, y, and z separated by vertical bars](powerpoint-math-equations_13.png)

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

[setGrowToMatchOperandHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathdelimiter/#setGrowToMatchOperandHeight-boolean-) को `true` पास करके बड़े ऑपरेण्ड के आसपास कोष्ठक को बढ़ने दें, या `false` पास करके उन्हें सामान्य आकार में रखें। [setDelimiterShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathdelimiter/#setDelimiterShape-int-) को दो में से एक [MathDelimiterShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathdelimitershape/) मान के साथ उपयोग करें। `Centered` कोष्ठकों को गणितीय अक्ष पर केंद्रित करता है, जो बराबर चिह्न के मध्य से होकर जाता है। `Match` उन्हें सम्मिलित सामग्री के अनुसार संरेखित करता है। दोनों सेटिंग्स केवल डिलिमिटर को प्रभावित करती हैं; अभिव्यक्ति अंदर वही रहती है।

उदाहरण में `x` के घातांक में एक भिन्न रखा गया है ताकि अभिव्यक्ति बेसलाइन के ऊपर अधिक विस्तृत हो। सभी चार समीकरण एक ही कोष्ठक और फ़ॉन्ट सेटिंग्स का उपयोग करते हैं।

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

PowerPoint में, पंक्तियों की तुलना करके वृद्धि का प्रभाव देखें। शीर्ष पंक्ति में, कोष्ठक घातांक को घेरने के लिये बढ़ते हैं और दोनों आकार समान दिखते हैं। नीचे की पंक्ति में, वृद्धि बंद है। बाएँ कोष्ठक (`Centered`) बराबर चिह्न के साथ संरेखित होते हैं, जबकि दाएँ (`Match`) अभिव्यक्ति के ऊपर अधिक स्थित होते हैं।

![Four equations in PowerPoint with delimiter growth enabled above and disabled below, and Centered on the left and Match on the right](delimiter-sizing.png)

## **एक बॉर्डर बॉक्स जोड़ें**

भिन्न पर [toBorderBox](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#toBorderBox--) को कॉल करके पूरी अभिव्यक्ति को फ्रेम करें। डिफ़ॉल्ट रूप से लौटाया गया [IMathBorderBox](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathborderbox/) चारों ओर की सीमाएँ दिखाता है। व्यक्तिगत पक्षों को हटाने के लिये [setHideTop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathborderbox/#setHideTop-boolean-), [setHideBottom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathborderbox/#setHideBottom-boolean-), [setHideLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathborderbox/#setHideLeft-boolean-), और [setHideRight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathborderbox/#setHideRight-boolean-) का प्रयोग करें।

उदाहरण में समान भिन्न की छह प्रतियों को एक स्लाइड पर रखा गया है। रद्दीकरण दिखाने के लिये, सभी चार पक्षों को छिपाएँ और [setStrikethroughBottomLeftToTopRight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathborderbox/#setStrikethroughBottomLeftToTopRight-boolean-) को `true` पास करके एक बढ़ते तिरछे रेखा (↗) जोड़ें या [setStrikethroughTopLeftToBottomRight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathborderbox/#setStrikethroughTopLeftToBottomRight-boolean-) को `true` पास करके एक गिरती तिरछी रेखा (↘) जोड़ें। आप किसी भी संयोजन में [setStrikethroughHorizontal](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathborderbox/#setStrikethroughHorizontal-boolean-) या [setStrikethroughVertical](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathborderbox/#setStrikethroughVertical-boolean-) का भी उपयोग कर सकते हैं।

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

![Six editable fractions in PowerPoint. Top row: full border, bottom and left sides, rising diagonal. Bottom row: falling diagonal, horizontal strike, vertical strike with a full border.](border-box-fractions.png)

इस भिन्न में, क्षैतिज स्ट्राइक भिन्न रेखा के ऊपर ओवरलैप करता है। ऊर्ध्वाधर स्ट्राइक अंश और हर दोनों को काटता है जबकि आसपास की बॉर्डर दृश्य रहती है। ये रेखाएँ पूरी अभिव्यक्ति को सजाती हैं। सामान्य टेक्स्ट स्ट्राइक‑थ्रू केवल टेक्स्ट रन के अक्षरों पर लागू होता है। PowerPoint में प्रस्तुति को पुनः खोलने के बाद, आप अभी भी अंश और हर को स्वतंत्र रूप से संपादित कर सकते हैं।

## **टर्म्स को समूहित करें**

[group](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#group-char-int-int-) का उपयोग करके अभिव्यक्ति के ऊपर या नीचे एक समूहित अक्षर रखें। समूहित टर्म्स को लेबल करने के लिये एक सीमा जोड़ें।

![The expression x plus y grouped with the label any text below it](powerpoint-math-equations_15.png)

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

## **गणितीय तत्वों को फॉर्मेट करें**

केवल तभी फॉर्मेटिंग हेल्पर्स का उपयोग करें जब वे फ़ॉर्मूला को स्पष्ट बनाते हों। उदाहरण के लिये, [overbar](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#overbar--) एक गणितीय तत्व के ऊपर एक रेखा रखता है।

![A math expression ABC with an overbar](powerpoint-math-equations_14.png)

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

### **मौजूदा समीकरण में टेक्स्ट फॉर्मेट करें**

एक मौजूदा समीकरण में संपूर्ण टेक्स्ट को फॉर्मेट करने के लिये, प्रत्येक गणितीय ब्लॉक के तत्व वृक्ष को पार करें। [IMathElement.getChildren](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#getChildren--) केवल तत्काल बच्चों को लौटाता है, इसलिए भिन्नों, स्क्रिप्टों, रैडिकलों और अन्य नेस्टेड संरचनाओं के भीतर के टेक्स्ट तक पहुँचने के लिये इसे पुनरावर्ती रूप से कॉल करें। वर्तमान तत्व और उसके बच्चे दोनों को जाँचें ताकि प्रारंभिक तत्व को भी शामिल किया जा सके जब वह [MathematicalText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathematicaltext/) हो।

यह उदाहरण मानता है कि `input.pptx` में `z = xᵢ / ∛y` जैसा समीकरण है, जिसमें भिन्न के अंश में सबस्क्रिप्ट और हर में रैडिकल है। केवल ब्लॉक के शीर्ष‑स्तर के तत्वों को प्रोसेस करने से भिन्न के भीतर का टेक्स्ट छूट जाएगा। यह उदाहरण स्लाइड टेक्स्ट फ्रेम में गणितीय भागों को खोजता है, उनके ब्लॉकों तक पहुँचता है [IMathPortion.getMathParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathportion/#getMathParagraph--), और प्रत्येक टेक्स्ट तत्व की [getFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathematicaltext/#getFormat--) मेथड के माध्यम से [setFontHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-) को 28 पॉइंट फ़ॉन्ट आकार सेट करता है।

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

सहेजा गया प्रस्तुतीकरण प्रत्येक प्रोसेस किए गए समीकरण के हर स्तर पर अपडेटेड टेक्स्ट फॉर्मेटिंग रखता है, जबकि उसकी टेक्स्ट सामग्री और गणितीय संरचना को संरक्षित रखता है।

## **त्वरित संदर्भ**

| कार्य | मुख्य API |
| --- | --- |
| गणितीय टेक्स्ट बनाएँ | [MathematicalText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathematicaltext/) |
| तत्वों को संयोजित करें | [IMathElement.join](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) |
| भिन्न बनाएँ | [IMathElement.divide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) |
| सुपरस्क्रिप्ट या सबस्क्रिप्ट जोड़ें | [setSuperscript](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/), [setSubscript](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) |
| फ़ंक्शन जोड़ें | [function](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/), [asArgumentOfFunction](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) |
| रैडिकल जोड़ें | [IMathElement.radical](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) |
| सीमाएँ जोड़ें | [setLowerLimit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/), [setUpperLimit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) |
| बाएँ‑साइड स्क्रिप्ट जोड़ें | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) |
| संकलन और समाकल जोड़ें | [nary](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/), [integral](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) |
| मैट्रिक्स जोड़ें | [MathMatrix](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathmatrix/) |
| समीकरण एरे जोड़ें | [toMathArray](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) |
| डिलिमिटर जोड़ें | [enclose](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) |
| रेखाएँ और बॉर्डर जोड़ें | [overbar](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/), [toBorderBox](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) |
| टर्म्स को समूहित करें | [group](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) |

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं मौजूदा PowerPoint समीकरण को संपादित कर सकता हूँ?**

हाँ। प्रस्तुति खोलें, उस शैल को खोजें जिसमें एक [MathPortion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathportion/) हो, [getMathParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathportion/#getMathParagraph--) को कॉल करें, और उस पैराग्राफ में गणितीय ब्लॉक को अपडेट करें।

**क्या समीकरणों को संपादनयोग्य PowerPoint गणित के रूप में सहेजा जाता है?**

हाँ। PPTX में सहेजते समय, Aspose.Slides समीकरण को संपादन योग्य Office गणित सामग्री के रूप में लिखता है।

**क्या मैं समीकरणों को LaTeX में निर्यात कर सकता हूँ?**

हाँ। उसके [IMathPortion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathportion/) से [IMathParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathparagraph/) प्राप्त करें, और सीधे निर्यात करने के लिये [IMathParagraph.toLatex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathparagraph/#toLatex--) को कॉल करें। एक पूर्ण उदाहरण के लिये देखें [Export Math Equations from Presentations in Android via Java](/slides/hi/androidjava/exporting-math-equations/#export-math-equations-to-latex).