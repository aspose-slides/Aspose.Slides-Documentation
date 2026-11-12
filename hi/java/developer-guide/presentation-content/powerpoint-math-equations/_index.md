---
title: PowerPoint प्रस्तुतियों में जावा के लिए गणितीय समीकरण जोड़ें
linktitle: PowerPoint गणितीय समीकरण
type: docs
weight: 80
url: /hi/java/powerpoint-math-equations/
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
- Java
- Aspose.Slides
description: "Aspose.Slides for Java के साथ PowerPoint PPT और PPTX में गणितीय समीकरण सम्मिलित करें और संपादित करें, OMML का समर्थन, स्वरूपण नियंत्रण, और स्पष्ट Java कोड उदाहरण प्रदान करता है।"
---
## **सारांश**

PowerPoint समीकरणों को Office Math Markup Language (OMML) के रूप में संग्रहीत करता है। Aspose.Slides for Java के साथ, आप वही प्रकार की गणितीय सामग्री प्रोग्रामmatically बना सकते हैं: भिन्न, मूल, फ़ंक्शन, सीमा, N-ary ऑपरेटर, मैट्रिसेज़, ऐरेज़, और स्वरूपित गणित ब्लॉक्स।

PowerPoint में, उपयोगकर्ता सामान्यतः **Insert > Equation** से समीकरण जोड़ते हैं:

![PowerPoint Insert टैब में Equation कमांड चयनित स्थिति](powerpoint-math-equations_1.png)

परिणामस्वरूप स्लाइड पर संपादन योग्य गणितीय पाठ मिलता है:

![एक PowerPoint स्लाइड जिसमें संपादन योग्य गणितीय समीकरण है](powerpoint-math-equations_2.png)

Aspose.Slides इस गणितीय पाठ को तीन मुख्य वस्तुओं के माध्यम से बनाता है:

- एक गणितीय आकार, जो [addMathShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addMathShape-float-float-float-float-) से बनाया जाता है, वह आकार है जो समीकरण को रखता है।
- [MathPortion](https://reference.aspose.com/slides/java/com.aspose.slides/mathportion/) आकार के टेक्स्ट फ्रेम के भीतर गणित सामग्री को संग्रहीत करता है।
- [MathParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/mathparagraph/) एक या अधिक [MathBlock](https://reference.aspose.com/slides/java/com.aspose.slides/mathblock/) वस्तुओं को सम्मिलित करता है।

नीचे के अधिकांश उदाहरण [MathematicalText](https://reference.aspose.com/slides/java/com.aspose.slides/mathematicaltext/) और [IMathElement](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/) की फ़्लुएंट विधियों का उपयोग करते हैं ताकि कोड संक्षिप्त और पठनीय रहे।

MathML निर्यात परिदृश्यों के लिए, देखें [Export Math Equations from Presentations in Java](/slides/hi/java/exporting-math-equations/)।

## **समीकरण बनाएं**

यह उदाहरण [addMathShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addMathShape-float-float-float-float-) का उपयोग करके एक गणितीय आकार बनाता है और पाइथागोरस सिद्धांत जोड़ता है:

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

[addMathShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addMathShape-float-float-float-float-) ऐसा आकार बनाता है जिसमें पहले से ही एक गणितीय पैराग्राफ होता है। पहले [MathPortion](https://reference.aspose.com/slides/java/com.aspose.slides/mathportion/) तक पहुँचें, [getMathParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/imathportion/#getMathParagraph--) को कॉल करें, और उसमें गणित ब्लॉक्स या गणित तत्व जोड़ें।

{{% /alert %}}

## **भिन्न जोड़ें**

भिन्न बनाने के लिए [divide](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#divide-com.aspose.slides.IMathElement-) का उपयोग करें। आप [MathFractionTypes](https://reference.aspose.com/slides/java/com.aspose.slides/mathfractiontypes/) से भिन्न शैली चुन सकते हैं।

![एक तिरछा गणितीय भिन्न जिसमें 1 को x से विभाजित दिखाया गया है](powerpoint-math-equations_4.png)

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

स्टैक्ड भिन्न के लिए, [MathFractionTypes.Bar](https://reference.aspose.com/slides/java/com.aspose.slides/mathfractiontypes/#Bar) का उपयोग करें:

```java
import com.aspose.slides.*;

IMathFraction stackedFraction = new MathematicalText("x + 1").divide("y - 1", MathFractionTypes.Bar);
```

## **मूल जोड़ें**

स्क्वायर रूट, क्यूब रूट या अन्य मूल बनाने के लिए [radical](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#radical-com.aspose.slides.IMathElement-) का उपयोग करें। वर्तमान तत्व आधार बन जाता है, और तर्क डिग्री बन जाता है।

![एक n‑th मूल अभिव्यक्ति जिसमें x मूल चिह्न के नीचे है](powerpoint-math-equations_5.png)

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

फ़ंक्शन जैसे `sin(x)`, `log(x)` या कस्टम फ़ंक्शन नामों के लिए [asArgumentOfFunction](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#asArgumentOfFunction-com.aspose.slides.IMathElement-) या [function](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#function-com.aspose.slides.IMathElement-) का उपयोग करें। सीमाओं के लिए, `lim` को एक [MathLimit](https://reference.aspose.com/slides/java/com.aspose.slides/mathlimit/) में रखें, या [setLowerLimit](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#setLowerLimit-com.aspose.slides.IMathElement-) का उपयोग करें।

![x की सीमा जब x अनंत की ओर बढ़ता है](powerpoint-math-equations_8.png)

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathFunction limit = new MathematicalText("lim")
            .setLowerLimit("x\u2192\u221E")
            .function("x");

    mathParagraph.add(new MathBlock(limit));

    presentation.save("functions-and-limits.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

कस्टम फ़ंक्शन नाम के लिए, फ़ंक्शन नाम को वर्तमान तत्व बनाएं और उसके तर्क के साथ [function](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#function-com.aspose.slides.IMathElement-) को कॉल करें:

```java
import com.aspose.slides.*;

IMathFunction customFunction = new MathematicalText("f").function("x + 1");
```

## **N-ary ऑपरेटर और इंटीग्रल जोड़ें**

समीकरण, यूनियन, इंटरसेक्शन और अन्य बड़े ऑपरेटरों के लिए [nary](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#nary-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-) का उपयोग करें। इंटीग्रल के लिए [integral](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#integral-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-) का उपयोग करें। दोनों विधियां निचली और ऊपरी सीमाएँ सेट करने की अनुमति देती हैं।

![निचली और ऊपरी सीमाओं के साथ एक समेटीकरण](powerpoint-math-equations_7.png)

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

N-ary ऑपरेटर बड़े ऑपरेटरों के लिए होते हैं जिनमें वैकल्पिक सीमाएँ हो सकती हैं। सरल ऑपरेटर जैसे `+`, `-`, और `=` आमतौर पर [MathematicalText](https://reference.aspose.com/slides/java/com.aspose.slides/mathematicaltext/) के रूप में जोड़े जाते हैं और अभिव्यक्ति में सम्मिलित होते हैं।

इंटीग्रल के लिए, [integral](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#integral-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-) का उपयोग करें:

```java
import com.aspose.slides.*;

IMathBlock integralBase = new MathematicalText("x").join(new MathematicalText("dx").toBox());
IMathNaryOperator integral = integralBase.integral(MathIntegralTypes.Simple, "0", "1");
```

## **मैट्रिक्स जोड़ें**

पंक्तियों और स्तंभों के लिए [MathMatrix](https://reference.aspose.com/slides/java/com.aspose.slides/mathmatrix/) का उपयोग करें। मैट्रिक्स में डिफ़ॉल्ट रूप से कोष्ठक नहीं होते, इसलिए जब आपको ब्रैकेट, स्क्वायर ब्रैकेट या कर्ली ब्रैकेट की आवश्यकता हो तो मैट्रिक्स को इन्हीं में घेरें।

![एक दो‑पंक्ति गणितीय मैट्रिक्स जिसमें एक खाली कोशिक़ा है](powerpoint-math-equations_10.png)

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

जब आपको संरेखित समीकरण या अभिव्यक्तियों का एक लंबवत स्टैक चाहिए, तो [toMathArray](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#toMathArray--) का उपयोग करें।

![x के ऊपर y के साथ एक लंबवत गणितीय ऐरे](powerpoint-math-equations_11.png)

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

### **परिचित तत्वों के साथ ऐरे को संरेखित करें**

[setBaseJustification](https://reference.aspose.com/slides/java/com.aspose.slides/imatharray/#setBaseJustification-int-) ऐरे की ऊर्ध्वाधर संरेखण को उसके बगल में मौजूद गणितीय तत्वों के सापेक्ष नियंत्रित करता है। नीचे का उदाहरण पहली पंक्ति, ऐरे के मध्य और अंतिम पंक्ति के साथ संरेखण की तुलना करता है।

निम्न उदाहरण तीन समान ऐरे बनाता है, प्रत्येक में तीन पंक्तियां और पड़ोसी तत्व `A=` और `=B` होते हैं। सभी गणितीय पाठ Cambria Math 24 पॉइंट में है। केवल ऐरे का संरेखण बदलता है।

```java
import com.aspose.slides.*;
import java.awt.Color;

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

निम्न तुलना PowerPoint में सहेजे गए प्रस्तुतिकरण को दिखाती है। प्रत्येक ऐरे के बगल में `A=` और `=B` की स्थिति देखें।

![PowerPoint में शीर्ष, मध्य, और निचले संरेखण वाले समीकरण ऐरे, सभी के साथ समान पड़ोसी तत्व](equation-array-alignment.png)

### **पंक्ति अंतराल कॉन्फ़िगर करें**

[setRowSpacingRule](https://reference.aspose.com/slides/java/com.aspose.slides/imatharray/#setRowSpacingRule-int-) ऐरे के भीतर पंक्तियों के लिए अंतराल नियम चुनता है। [setRowSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/imatharray/#setRowSpacing-long-) स्पष्ट अंतराल नियम के लिए संख्यात्मक मान प्रदान करता है और प्रीसेट नियमों द्वारा अनदेखा किया जाता है।

सटीक अंतराल के लिए, मान पॉइंट में मापा जाता है। अनुपातिक अंतराल के लिए, मान आधी रेखा में मापा जाता है: उदाहरण में `3` का अर्थ 1.5 रेखा है। स्पष्ट मान निर्दिष्ट करते समय दोनों गुणधर्म सेट करें; केवल संख्यात्मक मान बदलने से अंतराल नियम नहीं चुना जाता।

नीचे का उदाहरण समान समीकरण, संरेखण और फ़ॉन्ट सेटिंग्स के साथ पाँच प्रस्तुतिकरण सहेजता है। पहले तीन प्रीसेट हैं; अंतिम दो स्पष्ट मान दिखाते हैं।

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

ऐरे पंक्ति अंतराल पैराग्राफ अंतराल से अलग है। [setSpaceBefore](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setSpaceBefore-float-) और [setSpaceAfter](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setSpaceAfter-float-) कंटेनिंग पैराग्राफ के चारों ओर अंतराल जोड़ते हैं, न कि ऐरे पंक्तियों के बीच। इसी प्रकार, [IMathParagraph.setJustification](https://reference.aspose.com/slides/java/com.aspose.slides/imathparagraph/#setJustification-int-) पूरी गणितीय पैराग्राफ को क्षैतिज रूप से स्थित करता है; यह ऐरे की ऊर्ध्वाधर संरेखण सेटिंग को प्रतिस्थापित नहीं करता।

## **त्रिकोणमितीय फ़ंक्शन जोड़ें**

जब तर्क वर्तमान तत्व है और फ़ंक्शन नाम ज्ञात है, तो [asArgumentOfFunction](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#asArgumentOfFunction-com.aspose.slides.IMathElement-) का उपयोग करें।

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

## **सबस्क्रिप्ट और सुपरसक्रिप्ट जोड़ें**

इंडेक्स और घात के लिए सबस्क्रिप्ट और सुपरसक्रिप्ट सहायक का उपयोग करें। जब इंडेक्स को आधार के बायें तरफ दिखाना हो, तो [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#setSubSuperscriptOnTheLeft-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-) का प्रयोग करें।

![बायें‑साइड सबस्क्रिप्ट 1 और सुपरसक्रिप्ट n वाला बड़ा Y](powerpoint-math-equations_9.png)

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

एक अभिव्यक्ति को डिलिमिटर के अंदर रखने के लिए [enclose](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#enclose-char-char-) का उपयोग करें। आप कई तत्वों वाले डिलिमिटर अभिव्यक्तियों के लिए विभाजक अक्षर भी निर्धारित कर सकते हैं।

![x, y और z को लंबवत बार से अलग किया गया डिलिमिटर अभिव्यक्ति](powerpoint-math-equations_13.png)

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

ऑपरेण्ड की ऊँचाई के अनुसार कोष्ठक को बढ़ाने के लिए [setGrowToMatchOperandHeight](https://reference.aspose.com/slides/java/com.aspose.slides/imathdelimiter/#setGrowToMatchOperandHeight-boolean-) को `true` पास करें, या सामान्य आकार रखने के लिए `false` पास करें। दो में से एक [MathDelimiterShape](https://reference.aspose.com/slides/java/com.aspose.slides/mathdelimitershape/) मान के साथ [setDelimiterShape](https://reference.aspose.com/slides/java/com.aspose.slides/imathdelimiter/#setDelimiterShape-int-) का उपयोग करें। `Centered` कोष्ठकों को गणितीय अक्ष पर केंद्रित करता है, जो बराबर चिह्न के मध्य से चलता है। `Match` कोष्ठकों को enclosed सामग्री के साथ संरेखित करता है। दोनों सेटिंग केवल डिलिमिटर को प्रभावित करती हैं; अंदर की अभिव्यक्ति समान रहती है।

उदाहरण में `x` के घात में एक भिन्न रखा गया है, जिससे अभिव्यक्ति बेसलाइन के ऊपर अधिक विस्तृत हो जाती है। चारों समीकरण समान कोष्ठक और फ़ॉन्ट सेटिंग्स का उपयोग करते हैं।

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

PowerPoint में, पंक्तियों की तुलना करके वृद्धि प्रभाव देखें। शीर्ष पंक्ति में, कोष्ठक घात को घेरते हुए बढ़ते हैं और दोनों रूप समान दिखते हैं। निचली पंक्ति में, वृद्धि बंद है। बाएँ (`Centered`) छोटे कोष्ठक बराबर चिह्न के साथ संरेखित होते हैं, जबकि दाएँ (`Match`) अभिव्यक्ति के ऊपर ऊँचे रहते हैं।

![चार समीकरण PowerPoint में, ऊपर डिलिमिटर वृद्धि सक्रिय और नीचे निष्क्रिय, बाएँ Centred और दाएँ Match के साथ](delimiter-sizing.png)

## **बॉर्डर बॉक्स जोड़ें**

एक भिन्न पर [toBorderBox](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#toBorderBox--) को कॉल करें ताकि संपूर्ण अभिव्यक्ति को फ्रेम किया जा सके। डिफ़ॉल्ट रूप से लौटाया गया [IMathBorderBox](https://reference.aspose.com/slides/java/com.aspose.slides/imathborderbox/) चारों पक्ष दिखाता है। व्यक्तिगत पक्षों को हटाने के लिए [setHideTop](https://reference.aspose.com/slides/java/com.aspose.slides/imathborderbox/#setHideTop-boolean-), [setHideBottom](https://reference.aspose.com/slides/java/com.aspose.slides/imathborderbox/#setHideBottom-boolean-), [setHideLeft](https://reference.aspose.com/slides/java/com.aspose.slides/imathborderbox/#setHideLeft-boolean-), और [setHideRight](https://reference.aspose.com/slides/java/com.aspose.slides/imathborderbox/#setHideRight-boolean-) का उपयोग करें।

उदाहरण में एक ही भिन्न की छह प्रतियां एक स्लाइड पर रखी गई हैं। रद्दीकरण दिखाने के लिए, चारों पक्ष छिपाएँ और उठते तिरछे (↗) के लिए [setStrikethroughBottomLeftToTopRight](https://reference.aspose.com/slides/java/com.aspose.slides/imathborderbox/#setStrikethroughBottomLeftToTopRight-boolean-) को `true` पास करें या गिरते तिरछे (↘) के लिए [setStrikethroughTopLeftToBottomRight](https://reference.aspose.com/slides/java/com.aspose.slides/imathborderbox/#setStrikethroughTopLeftToBottomRight-boolean-) का उपयोग करें। आप [setStrikethroughHorizontal](https://reference.aspose.com/slides/java/com.aspose.slides/imathborderbox/#setStrikethroughHorizontal-boolean-) या [setStrikethroughVertical](https://reference.aspose.com/slides/java/com.aspose.slides/imathborderbox/#setStrikethroughVertical-boolean-) को किसी भी संयोजन के साथ प्रयोग कर सकते हैं।

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

![छह संपादन योग्य भिन्न PowerPoint में। शीर्ष पंक्ति: पूर्ण बॉर्डर, निचला और बायां पक्ष, उठता तिरछा। नीचे पंक्ति: गिरता तिरछा, क्षैतिज स्ट्राइक, ऊर्ध्वाधर स्ट्राइक के साथ पूर्ण बॉर्डर।](border-box-fractions.png)

इस भिन्न पर, क्षैतिज स्ट्राइक भिन्न रेखा को ओवरलैप करता है। ऊर्ध्वाधर स्ट्राइक अंश और हर दोनों को काटता है जबकि चारों ओर का बॉर्डर दिखाई देता है। ये रेखाएं पूरी अभिव्यक्ति को सजाते हैं। सामान्य टेक्स्ट स्ट्राइक्रथ्रू केवल टेक्स्ट रन के अक्षरों पर लागू होता है। PowerPoint में प्रस्तुति को पुनः खोलने के बाद भी आप अंश और हर को स्वतंत्र रूप से संपादित कर सकते हैं।

## **शब्द समूहित करें**

एक अभिव्यक्ति के ऊपर या नीचे समूहित अक्षर रखने के लिए [group](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#group-char-int-int-) का उपयोग करें। समूहित शब्दों को लेबल करने के लिए सीमा जोड़ें।

![x + y अभिव्यक्ति को नीचे लेबल वाली कोई भी टेक्स्ट के साथ समूहित किया गया है](powerpoint-math-equations_15.png)

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

केवल तब स्वरूपण सहायक का उपयोग करें जब वह सूत्र को स्पष्ट करता हो। उदाहरण के लिए, [overbar](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#overbar--) एक गणितीय तत्व के ऊपर बार रखता है।

![ABC गणितीय अभिव्यक्ति के ऊपर एक ओवरबार के साथ](powerpoint-math-equations_14.png)

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

### **मौजूदा समीकरण में पाठ को स्वरूपित करें**

मौजूदा समीकरण में पूरे पाठ को स्वरूपित करने के लिए, प्रत्येक गणितीय ब्लॉक के तत्व वृक्ष को पार करें। [IMathElement.getChildren](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#getChildren--) केवल तत्काल बच्चों को लौटाता है, इसलिए फ्रैक्शन, स्क्रिप्ट, रैडिकल और अन्य नेस्टेड संरचनाओं के भीतर पाठ तक पहुँचने के लिए इसे पुनरावर्ती रूप से कॉल करें। वर्तमान तत्व और उसके बच्चों दोनों की जाँच करें ताकि शुरुआती तत्व को शामिल किया जा सके जब वह [MathematicalText](https://reference.aspose.com/slides/java/com.aspose.slides/mathematicaltext/) हो।

यह उदाहरण मानता है कि `input.pptx` में `z = xᵢ / ∛y` जैसा समीकरण है, जिसमें अंश में उपस्क्रिप्ट और हर में रैडिकल है। केवल ब्लॉक के शीर्ष‑स्तर के तत्वों को प्रोसेस करने से फ्रैक्शन के भीतर का पाठ छूट जाता। उदाहरण स्लाइड टेक्स्ट फ्रेम में गणितीय हिस्सों को खोजता है, उनके ब्लॉकों तक [IMathPortion.getMathParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/imathportion/#getMathParagraph--) से पहुँचता है, और प्रत्येक टेक्स्ट तत्व के [getFormat](https://reference.aspose.com/slides/java/com.aspose.slides/mathematicaltext/#getFormat--) विधि के माध्यम से फ़ॉन्ट आकार को 28 पॉइंट पर सेट करने के लिए [setFontHeight](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/#setFontHeight-float-) का उपयोग करता है।

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

सहेजा गया प्रस्तुतीकरण प्रत्येक प्रोसेस किए गए समीकरण के सभी स्तरों पर अद्यतन पाठ स्वरूपण रखता है, जबकि उसके पाठ सामग्री और गणितीय संरचना को बनाए रखता है।

## **त्वरित संदर्भ**

| कार्य | मुख्य API |
| --- | --- |
| गणितीय पाठ बनाएं | [MathematicalText](https://reference.aspose.com/slides/java/com.aspose.slides/mathematicaltext/) |
| तत्व जोड़ें | [IMathElement.join](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#join-com.aspose.slides.IMathElement-) |
| भिन्न बनाएं | [IMathElement.divide](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#divide-com.aspose.slides.IMathElement-) |
| सुपरसक्रिप्ट या सबस्क्रिप्ट जोड़ें | [setSuperscript](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#setSuperscript-com.aspose.slides.IMathElement-), [setSubscript](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#setSubscript-com.aspose.slides.IMathElement-) |
| फ़ंक्शन जोड़ें | [function](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#function-com.aspose.slides.IMathElement-), [asArgumentOfFunction](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#asArgumentOfFunction-com.aspose.slides.IMathElement-) |
| मूल जोड़ें | [IMathElement.radical](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#radical-com.aspose.slides.IMathElement-) |
| सीमाएँ जोड़ें | [setLowerLimit](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#setLowerLimit-com.aspose.slides.IMathElement-), [setUpperLimit](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#setUpperLimit-com.aspose.slides.IMathElement-) |
| बाएँ‑साइड स्क्रिप्ट जोड़ें | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#setSubSuperscriptOnTheLeft-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-) |
| समेटीकरण और इंटीग्रल जोड़ें | [nary](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#nary-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-), [integral](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#integral-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-) |
| मैट्रिक्स जोड़ें | [MathMatrix](https://reference.aspose.com/slides/java/com.aspose.slides/mathmatrix/) |
| समीकरण ऐरे जोड़ें | [toMathArray](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#toMathArray--) |
| डिलिमिटर जोड़ें | [enclose](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#enclose-char-char-) |
| बार और बॉर्डर जोड़ें | [overbar](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#overbar--), [toBorderBox](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#toBorderBox--) |
| शब्द समूहित करें | [group](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#group-char-int-int-) |

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं मौजूदा PowerPoint समीकरण को संपादित कर सकता हूँ?**

हां। प्रस्तुतीकरण खोलें, उस आकार को खोजें जिसमें एक [MathPortion](https://reference.aspose.com/slides/java/com.aspose.slides/mathportion/) है, [getMathParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/imathportion/#getMathParagraph--) को कॉल करें, और उस पैराग्राफ में गणितीय ब्लॉक्स को अपडेट करें।

**क्या समीकरण को संपादन योग्य PowerPoint गणित के रूप में सहेजा जाता है?**

हां। PPTX में सहेजते समय, Aspose.Slides समीकरण को संपादन योग्य Office गणित सामग्री के रूप में लिखता है।

**क्या मैं समीकरण को LaTeX में निर्यात कर सकता हूँ?**

हां। समीकरण के [IMathParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/imathparagraph/) को उसके [IMathPortion](https://reference.aspose.com/slides/java/com.aspose.slides/imathportion/) से प्राप्त करें, और सीधे निर्यात करने के लिए [IMathParagraph.toLatex](https://reference.aspose.com/slides/java/com.aspose.slides/imathparagraph/#toLatex--) को कॉल करें। पूर्ण उदाहरण के लिए देखें [Export Math Equations from Presentations in Java](/slides/hi/java/exporting-math-equations/#export-math-equations-to-latex)।