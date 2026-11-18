---
title: Java में PowerPoint प्रस्तुतियों में गणितीय समीकरण जोड़ें
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
description: "Java के लिए Aspose.Slides के साथ PowerPoint PPT और PPTX में गणितीय समीकरण डालें और संपादित करें, OMML का समर्थन, स्वरूपण नियंत्रण, और स्पष्ट Java कोड उदाहरण प्रदान करता है।"
---
## **परिचय**

PowerPoint समीकरणों को Office Math Markup Language (OMML) के रूप में संग्रहीत करता है। Aspose.Slides for Java का उपयोग करके आप प्रोग्रामmatically वही गणितीय सामग्री बना सकते हैं: भाग, मूल, फ़ंक्शन, सीमाएँ, N-ary ऑपरेटर्स, मैट्रिक्स, ऐरे, और स्वरूपित गणितीय ब्लॉक।

PowerPoint में, उपयोगकर्ता सामान्यतः **Insert > Equation** से समीकरण जोड़ते हैं:

![PowerPoint Insert टैब जिसमें Equation कमांड चयनित है](powerpoint-math-equations_1.png)

परिणाम स्लाइड पर संपादन योग्य गणितीय टेक्स्ट है:

![एक PowerPoint स्लाइड जिसमें संपादन योग्य गणितीय समीकरण है](powerpoint-math-equations_2.png)

Aspose.Slides इस गणितीय टेक्स्ट को तीन मुख्य ऑब्जेक्ट्स के माध्यम से बनाता है:

- एक गणितीय आकार, जिसे [addMathShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addMathShape-float-float-float-float-) द्वारा बनाया जाता है, वह आकार है जिसमें समीकरण होता है।
- [MathPortion](https://reference.aspose.com/slides/java/com.aspose.slides/mathportion/) आकार के टेक्स्ट फ्रेम के भीतर गणितीय सामग्री संग्रहीत करता है।
- [MathParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/mathparagraph/) एक या अधिक [MathBlock](https://reference.aspose.com/slides/java/com.aspose.slides/mathblock/) ऑब्जेक्ट्स रखता है।

नीचे के अधिकांश उदाहरण [MathematicalText](https://reference.aspose.com/slides/java/com.aspose.slides/mathematicaltext/) और [IMathElement](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/) की fluent मेथड्स का उपयोग करते हैं ताकि कोड संक्षिप्त और पढ़ने योग्य रहे।

MathML निर्यात परिदृश्यों के लिए, देखें [Export Math Equations from Presentations in Java](/slides/hi/java/exporting-math-equations/)।

## **समीकरण बनाएं**

यह उदाहरण [addMathShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addMathShape-float-float-float-float-) का उपयोग करके एक गणितीय आकार बनाता है और पायथागोरस प्रमेय जोड़ता है:

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
[addMathShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addMathShape-float-float-float-float-) एक ऐसा आकार बनाता है जिसमें पहले से ही एक गणितीय अनुच्छेद होता है। पहले [MathPortion](https://reference.aspose.com/slides/java/com.aspose.slides/mathportion/) तक पहुँचें, [getMathParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/imathportion/#getMathParagraph--) को कॉल करें, और उसमें गणितीय ब्लॉक या तत्व जोड़ें।
{{% /alert %}}

## **भिन्न जोड़ें**

भिन्न बनाने के लिए [divide](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#divide-com.aspose.slides.IMathElement-) का उपयोग करें। आप [MathFractionTypes](https://reference.aspose.com/slides/java/com.aspose.slides/mathfractiontypes/) के साथ एक भिन्न शैली चुन सकते हैं।

![एक तिरछा गणितीय भिन्न जो 1 को x से विभाजित दिखाता है](powerpoint-math-equations_4.png)

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

[radical](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#radical-com.aspose.slides.IMathElement-) का उपयोग करके वर्गमूल, घनमूल या अन्य मूल बनाएं। वर्तमान तत्व आधार बन जाता है, और आर्ग्युमेंट डिग्री बन जाता है।

![एक n-वीं मूल अभिव्यक्ति जिसमें x मूल चिह्न के नीचे है](powerpoint-math-equations_5.png)

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

### **वर्गमूल का डिग्री दिखाएँ या छुपाएँ**

वर्गमूल स्पष्ट 2 दिखा सकता है या पारंपरिक √x नोटेशन का उपयोग कर सकता है। [IMathRadical](https://reference.aspose.com/slides/java/com.aspose.slides/imathradical/) का [setHideDegree](https://reference.aspose.com/slides/java/com.aspose.slides/imathradical/#setHideDegree-boolean-) मेथड निर्धारित करता है कि कौन‑सा रूप दिखेगा। दोनों रूप संपादन योग्य समीकरण में डिग्री 2 और रेडिकैंड x को बनाए रखते हैं।

![एक ही वर्गमूल जिसमें बाएँ डिग्री दिखाया गया है और दाएँ छुपाया गया है](square-root-degree.png)

उदाहरण समान वर्गमूल को दो बार सहेजता है। `visible-degree.pptx` में 2 दिखता है। `hidden-degree.pptx` में यह छुपा होता है।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    IMathRadical radical = new MathematicalText("x").radical("2");

    IAutoShape shape = slide.getShapes().addMathShape(20, 20, 200, 100);
    IMathPortion portion = (IMathPortion) shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.getMathParagraph().add(new MathBlock(radical));

    radical.setHideDegree(false);
    presentation.save("visible-degree.pptx", SaveFormat.Pptx);

    radical.setHideDegree(true);
    presentation.save("hidden-degree.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **फ़ंक्शन और सीमा जोड़ें**

फ़ंक्शन जैसे `sin(x)`, `log(x)` या कस्टम फ़ंक्शन नामों के लिए [asArgumentOfFunction](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#asArgumentOfFunction-com.aspose.slides.IMathElement-) या [function](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#function-com.aspose.slides.IMathElement-) का उपयोग करें। सीमाओं के लिए, `lim` को एक [MathLimit](https://reference.aspose.com/slides/java/com.aspose.slides/mathlimit/) में रखें या [setLowerLimit](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#setLowerLimit-com.aspose.slides.IMathElement-) का प्रयोग करें।

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

कस्टम फ़ंक्शन नाम के लिए, फ़ंक्शन नाम को वर्तमान तत्व बनाएं और उसके आर्ग्युमेंट के साथ [function](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#function-com.aspose.slides.IMathElement-) को कॉल करें:

```java
import com.aspose.slides.*;

IMathFunction customFunction = new MathematicalText("f").function("x + 1");
```

## **N-ary ऑपरेटर और इंटीग्रल जोड़ें**

समेशन, यूनियन, इंटरसेक्शन और अन्य बड़े ऑपरेटर्स के लिए [nary](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#nary-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-) का उपयोग करें। इंटीग्रल के लिए [integral](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#integral-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-) का उपयोग करें। दोनों मेथड निचली और ऊपरी सीमाओं को सेट करने की अनुमति देते हैं।

![निचली और ऊपरी सीमाओं के साथ एक योग](powerpoint-math-equations_7.png)

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

N-ary ऑपरेटर्स बड़े ऑपरेटर्स के लिये होते हैं जिनमें वैकल्पिक सीमाएँ हो सकती हैं। `+`, `-`, `=` जैसे सरल ऑपरेटर्स आमतौर पर [MathematicalText](https://reference.aspose.com/slides/java/com.aspose.slides/mathematicaltext/) के रूप में जोड़े जाते हैं और अभिव्यक्ति में सम्मिलित किए जाते हैं।

इंटीग्रल हेतु, [integral](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#integral-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-) का उपयोग करें:

```java
import com.aspose.slides.*;

IMathBlock integralBase = new MathematicalText("x").join(new MathematicalText("dx").toBox());
IMathNaryOperator integral = integralBase.integral(MathIntegralTypes.Simple, "0", "1");
```

## **मैट्रिक्स जोड़ें**

पंक्तियों और स्तंभों के लिये [MathMatrix](https://reference.aspose.com/slides/java/com.aspose.slides/mathmatrix/) का प्रयोग करें। डिफ़ॉल्ट रूप से मैट्रिक्स में कोष्ठक नहीं होते, इसलिए आवश्यकता अनुसार पेरेंथिसिस, ब्रैकेट या ब्रेसेज़ की जाँच करें।

![एक दो-पंक्ति वाला गणितीय मैट्रिक्स जिसमें एक खाली कोशिका है](powerpoint-math-equations_10.png)

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

समानांतर समीकरण या वर्टिकल स्टैक वाली अभिव्यक्तियों के लिये [toMathArray](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#toMathArray--) का प्रयोग करें।

![एक लंबवत गणितीय ऐरे जिसमें x y के ऊपर है](powerpoint-math-equations_11.png)

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

### **पर्याप्त तत्वों के साथ ऐरे को संरेखित करें**

[setBaseJustification](https://reference.aspose.com/slides/java/com.aspose.slides/imatharray/#setBaseJustification-int-) ऐरे की वर्टिकल संरेखण को उसके बगल के गणितीय तत्वों के सापेक्ष नियंत्रित करता है। नीचे दिया गया उदाहरण पहली पंक्ति, ऐरे के मध्य, और अंतिम पंक्ति के साथ संरेखण की तुलना करता है।

निम्न उदाहरण तीन समान ऐरे बनाता है, प्रत्येक में तीन पंक्तियाँ और पड़ोसी तत्व `A=` तथा `=B` हैं। सभी गणितीय टेक्स्ट Cambria Math पर 24 पॉइंट में है। केवल ऐरे का संरेखण बदलता है।

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

नीचे तुलना से पता चलता है कि PowerPoint में सहेजा गया प्रेज़ेंटेशन कैसा दिखता है। प्रत्येक ऐरे के बगल में `A=` और `=B` की स्थिति देखें।

![PowerPoint में समीकरण ऐरे टॉप, सेंटर, और बॉटम संरेखण के साथ और समान समीपस्थ तत्वों के साथ](equation-array-alignment.png)

### **पंक्ति अंतराल कॉन्फ़िगर करें**

[setRowSpacingRule](https://reference.aspose.com/slides/java/com.aspose.slides/imatharray/#setRowSpacingRule-int-) ऐरे के भीतर पंक्तियों के अंतराल नियम को चुनता है। [setRowSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/imatharray/#setRowSpacing-long-) स्पष्ट अंतराल नियम के लिये संख्यात्मक मान देता है और प्रीसेट नियमों द्वारा अनदेखा किया जाता है।

सटीक अंतराल के लिये मान पॉइंट में मापा जाता है। अनुपातिक अंतराल के लिये यह आधी‑लाइन में मापा जाता है: उदाहरण में मान `3` 1.5 लाइनों के बराबर है। स्पष्ट मान निर्दिष्ट करने पर दोनों गुणधर्म सेट करें; केवल संख्यात्मक मान बदलने से नियम चयनित नहीं होता।

निम्न उदाहरण समान समीकरण, संरेखण, और फ़ॉन्ट सेटिंग्स के साथ पाँच प्रेज़ेंटेशन सहेजता है। पहले तीन प्रीसेट उपयोग करते हैं; अंतिम दो स्पष्ट मान दिखाते हैं।

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

ऐरे पंक्ति का अंतराल पैराग्राफ अंतराल से अलग होता है। [setSpaceBefore](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setSpaceBefore-float-) और [setSpaceAfter](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setSpaceAfter-float-) कंटेनिंग पैराग्राफ के चारों ओर स्थान जोड़ते हैं, न कि ऐरे पंक्तियों के बीच। इसी प्रकार, [IMathParagraph.setJustification](https://reference.aspose.com/slides/java/com.aspose.slides/imathparagraph/#setJustification-int-) पूरे गणितीय पैराग्राफ को क्षैतिज रूप से स्थित करता है; यह ऐरे की वर्टिकल संरेखण सेटिंग को बदलता नहीं है।

## **त्रिकोणमितीय फ़ंक्शन जोड़ें**

जब आर्ग्युमेंट वर्तमान तत्व है और फ़ंक्शन नाम ज्ञात है, तब [asArgumentOfFunction](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#asArgumentOfFunction-com.aspose.slides.IMathElement-) का उपयोग करें।

![त्रिकोणमितीय फ़ंक्शन cos को 2x पर लागू किया गया](powerpoint-math-equations_6.png)

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

इंडेक्स और पावर के लिये सबस्क्रिप्ट और सुपरसक्रिप्ट हेल्पर का उपयोग करें। जब इंडेक्स बेस के बाएँ पक्ष में दिखने चाहिए, तो [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#setSubSuperscriptOnTheLeft-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-) का प्रयोग करें।

![एक बड़ा Y जिसके बाएँ तरफ सबस्क्रिप्ट 1 और सुपरसक्रिप्ट n है](powerpoint-math-equations_9.png)

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

एक अभिव्यक्ति को डिलिमिटर्स के भीतर रखने के लिये [enclose](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#enclose-char-char-) का उपयोग करें। आप कई तत्वों वाली डिलिमिटर अभिव्यक्तियों के लिये एक विभाजक अक्षर भी सेट कर सकते हैं।

![एक डिलिमिटर अभिव्यक्ति जिसमें x, y, और z को लम्बवत बार द्वारा विभाजित किया गया है](powerpoint-math-equations_13.png)

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

[parentheses] की ऊँचाई के अनुसार उन्हें बढ़ाने के लिये `true` को [setGrowToMatchOperandHeight](https://reference.aspose.com/slides/java/com.aspose.slides/imathdelimiter/#setGrowToMatchOperandHeight-boolean-) में पास करें, या सामान्य आकार रखने के लिये `false` पास करें। दो में से एक [MathDelimiterShape](https://reference.aspose.com/slides/java/com.aspose.slides/mathdelimitershape/) मान के साथ [setDelimiterShape](https://reference.aspose.com/slides/java/com.aspose.slides/imathdelimiter/#setDelimiterShape-int-) का प्रयोग करें। `Centered` पैरेंथिसिस को गणितीय अक्ष पर केंद्रित करता है, जो बराबर चिन्ह के मध्य में चलता है। `Match` उन्हें समाहित सामग्री के साथ संरेखित करता है। दोनों सेटिंग केवल डिलिमिटर्स को प्रभावित करती हैं; भीतर की अभिव्यक्ति समान रहती है।

उदाहरण `x` के एक्सपोनेंट में एक भिन्न रखता है ताकि अभिव्यक्ति बेसलाइन के ऊपर अधिक विस्तारित हो। सभी चार समीकरण समान पैरेंथिसिस और फ़ॉन्ट सेटिंग्स उपयोग करते हैं।

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

PowerPoint में पंक्तियों की तुलना करके वृद्धि प्रभाव देखें। शीर्ष पंक्ति में पैरेंथिसिस एक्सपोनेंट को घेरने के लिये बढ़ते हैं और दोनों आकार समान दिखते हैं। निचली पंक्ति में वृद्धि बंद है। बाएँ (`Centered`) छोटे पैरेंथिसिस बराबर चिन्ह के साथ संरेखित होते हैं, जबकि दाएँ (`Match`) अभिव्यक्ति के चारों ओर ऊँचे स्थित होते हैं।

![PowerPoint में चार समीकरण जहाँ डिलिमिटर वृद्धि ऊपर सक्षम है और नीचे अक्षम, तथा बाएँ `Centered` और दाएँ `Match`](delimiter-sizing.png)

## **बॉर्डर बॉक्स जोड़ें**

एक भिन्न पर [toBorderBox](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#toBorderBox--) को कॉल करें ताकि पूरी अभिव्यक्ति को फ्रेम किया जा सके। डिफ़ॉल्ट रूप से लौटाया गया [IMathBorderBox](https://reference.aspose.com/slides/java/com.aspose.slides/imathborderbox/) चारों ओर दिखाता है। व्यक्तिगत पक्षों को हटाने के लिये [setHideTop](https://reference.aspose.com/slides/java/com.aspose.slides/imathborderbox/#setHideTop-boolean-), [setHideBottom](https://reference.aspose.com/slides/java/com.aspose.slides/imathborderbox/#setHideBottom-boolean-), [setHideLeft](https://reference.aspose.com/slides/java/com.aspose.slides/imathborderbox/#setHideLeft-boolean-), और [setHideRight](https://reference.aspose.com/slides/java/com.aspose.slides/imathborderbox/#setHideRight-boolean-) का उपयोग करें।

उदाहरण समान भिन्न के छह प्रतिलिपियों को एक स्लाइड पर रखता है। निरस्तीकरण दिखाने के लिये चारों पक्ष छुपाएँ और उभरते विकर्ण (↗) के लिये `true` को [setStrikethroughBottomLeftToTopRight](https://reference.aspose.com/slides/java/com.aspose.slides/imathborderbox/#setStrikethroughBottomLeftToTopRight-boolean-) में, या गिरते विकर्ण (↘) के लिये [setStrikethroughTopLeftToBottomRight](https://reference.aspose.com/slides/java/com.aspose.slides/imathborderbox/#setStrikethroughTopLeftToBottomRight-boolean-) में पास करें। आप किसी भी संयोजन में विज़िबल पक्षों के साथ [setStrikethroughHorizontal](https://reference.aspose.com/slides/java/com.aspose.slides/imathborderbox/#setStrikethroughHorizontal-boolean-) या [setStrikethroughVertical](https://reference.aspose.com/slides/java/com.aspose.slides/imathborderbox/#setStrikethroughVertical-boolean-) का भी उपयोग कर सकते हैं।

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

![छह संपादन योग्य भिन्न PowerPoint में। शीर्ष पंक्ति: पूर्ण बॉर्डर, निचला और बायाँ पक्ष, उभरता विकर्ण। निचली पंक्ति: गिरता विकर्ण, क्षैतिज स्ट्राइक, वैर्टिकल स्ट्राइक पूर्ण बॉर्डर के साथ](border-box-fractions.png)

इस भिन्न में, क्षैतिज स्ट्राइक भिन्न रेखा के ऊपर जाता है। वैर्टिकल स्ट्राइक अंश और हर दोनों को काटता है जबकि चारों ओर का बॉर्डर दिखाई देता रहता है। ये रेखाएँ पूरी अभिव्यक्ति को सजाते हैं। सामान्य टेक्स्ट स्ट्राइक‑थ्रू केवल टेक्स्ट रन के अक्षरों पर लागू होता है। PowerPoint में प्रस्तुति फिर से खोलने पर आप अभी भी अंश और हर को स्वतंत्र रूप से संपादित कर सकते हैं।

## **फ़ैंटम तत्वों के साथ दृश्यता और लेआउट नियंत्रित करें**

एक अभिव्यक्ति को [MathPhantom](https://reference.aspose.com/slides/java/com.aspose.slides/mathphantom/) में लपेटें ताकि उसकी दृश्यता और समीकरण में योगदान वाले स्थान को स्वतंत्र रूप से नियंत्रित किया जा सके। [IMathPhantom](https://reference.aspose.com/slides/java/com.aspose.slides/imathphantom/) की विधियाँ निम्नलिखित को नियंत्रित करती हैं:

| विधि | प्रभाव |
| --- | --- |
| [setShow](https://reference.aspose.com/slides/java/com.aspose.slides/imathphantom/#setShow-boolean-) | `false` पास करने पर अभिव्यक्ति छुप जाती है। इसके आयाम अभी भी लेआउट में योगदान देते हैं जब तक नीचे दी गई विधियों में `true` न दिया जाए। |
| [setZeroWidth](https://reference.aspose.com/slides/java/com.aspose.slides/imathphantom/#setZeroWidth-boolean-) | अभिव्यक्ति की क्षैतिज चौड़ाई को शून्य मानें, जिससे पड़ोसी तत्व करीब आ सकें। |
| [setZeroAsc](https://reference.aspose.com/slides/java/com.aspose.slides/imathphantom/#setZeroAsc-boolean-) | उसकी आरोह (baseline से ऊपर की ऊँचाई) को शून्य मानें। इससे पड़ोसी तत्वों के ऊपर आरक्षित स्थान कम हो सकता है। |
| [setZeroDesc](https://reference.aspose.com/slides/java/com.aspose.slides/imathphantom/#setZeroDesc-boolean-) | उसकी अवरोह (baseline के नीचे की गहराई) को शून्य मानें। इससे भिन्न रेखा या अन्य सामग्री जो अभिव्यक्ति के नीचे है, वह पड़ोसियों के करीब आ सकती है। |

baseline वह संदर्भ रेखा है जिस पर सामान्य गणितीय अक्षर स्थित होते हैं। सामग्री को छुपाने से उसके आयाम हटते नहीं हैं, और आयाम को शून्य मानने से अभिव्यक्ति हटती नहीं है। अंतर्निहित अभिव्यक्ति [getBase](https://reference.aspose.com/slides/java/com.aspose.slides/imathphantom/#getBase--) के माध्यम से उपलब्ध रहती है। उसे फिर से दिखाने के लिये [setShow](https://reference.aspose.com/slides/java/com.aspose.slides/imathphantom/#setShow-boolean-) को `true` पास करें; आयाम सेटिंग अपरिवर्तित रहती है।

निम्न उदाहरण पाँच साइड‑बाय‑साइड वैरिएंट बनाता है: एक दृश्य भिन्न, एक छुपा भिन्न जो स्थान आरक्षित रखता है, और शून्य‑आयाम वाले तीन छुपे भिन्न। प्रत्येक वैरिएंट समान आस‑पास की अभिव्यक्ति और Cambria Math 24 पॉइंट पर उपयोग करता है। सभी समीकरण आकारों की शीर्ष स्थिति समान है, जिसे ग्रे गाइड द्वारा दर्शाया गया है। बाहरी भिन्न के अंश में फ़ैंटम रखने से वर्टिकल लेआउट परिवर्तन स्पष्ट दिखते हैं।

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
    presentation.getSlideSize().setSize(1000, 180, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    String[] labels = { "Visible", "Hidden: reserves space", "Hidden: ZeroWidth", "Hidden: ZeroAsc", "Hidden: ZeroDesc" };

    IAutoShape guide = slide.getShapes().addAutoShape(ShapeType.Line, 10, 60, 980, 0);
    guide.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    guide.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.LIGHT_GRAY);

    for (int i = 0; i < labels.length; i++) {
        int left = 10 + i * 200;

        IAutoShape label = slide.getShapes().addAutoShape(ShapeType.Rectangle, left, 10, 190, 30);
        label.getFillFormat().setFillType(FillType.NoFill);
        label.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
        label.getTextFrame().setText(labels[i]);

        IPortionFormat labelFormat = label.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
        labelFormat.setFontHeight(14);
        labelFormat.getFillFormat().setFillType(FillType.Solid);
        labelFormat.getFillFormat().getSolidFillColor().setColor(Color.BLACK);

        MathematicalText fractionNumerator = factory.createText("a+b");
        MathematicalText fractionDenominator = factory.createText("c+d");
        MathFraction fraction = new MathFraction(fractionNumerator, fractionDenominator);
        MathPhantom phantom = new MathPhantom(fraction);
        phantom.setShow(i == 0);
        phantom.setZeroWidth(i == 2);
        phantom.setZeroAsc(i == 3);
        phantom.setZeroDesc(i == 4);

        MathematicalText leftText = factory.createText("x+");
        MathematicalText rightText = factory.createText("+y");
        IMathBlock numerator = new MathBlock(leftText).join(phantom).join(rightText);
        MathematicalText denominator = factory.createText("z");
        MathFraction equation = new MathFraction(numerator, denominator);

        IAutoShape shape = slide.getShapes().addMathShape(left, 60, 190, 100);
        shape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Top);

        IMathPortion mathPortion = (IMathPortion) shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
        IMathParagraph mathParagraph = mathPortion.getMathParagraph();
        mathParagraph.add(new MathBlock(equation));
    }

    presentation.save("math-phantom.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![PowerPoint में पाँच समीकरण जिसमें एक दृश्य भिन्न, एक छुपा भिन्न जो स्थान आरक्षित रखता है, तथा ZeroWidth, ZeroAsc, या ZeroDesc सक्रिय वाले छुपे भिन्न दिखाए गए हैं](math-phantom.png)

## **टर्म समूहित करें**

एक अभिव्यक्ति के ऊपर या नीचे एक समूहिंग अक्षर रखने के लिये [group](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#group-char-int-int-) का प्रयोग करें। समूहित टर्म को लेबल करने के लिये एक सीमा जोड़ें।

![अभिव्यक्ति x + y को एक लेबल any text के साथ नीचे समूहित किया गया है](powerpoint-math-equations_15.png)

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

केवल जहाँ फ़ॉर्मूला स्पष्ट हो, वहाँ ही फ़ॉर्मेटिंग हेल्पर का उपयोग करें। उदाहरण के तौर पर, [overbar](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#overbar--) गणितीय तत्व के ऊपर एक बार रखता है।

![एक गणितीय अभिव्यक्ति ABC के ऊपर एक ओवरबार](powerpoint-math-equations_14.png)

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

### **मौजूदा समीकरण में टेक्स्ट स्वरूपित करें**

एक मौजूदा समीकरण में पूरे टेक्स्ट को स्वरूपित करने के लिये प्रत्येक गणितीय ब्लॉक के तत्व वृक्ष को ट्रैवर्स करें। [IMathElement.getChildren](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#getChildren--) केवल तत्काल बच्चों को लौटाता है, इसलिए फ़्रैक्शन, स्क्रिप्ट, मूल और अन्य नेस्टेड संरचनाओं के भीतर टेक्स्ट तक पहुँचने के लिये इसे पुनरावर्ती रूप से कॉल करें। जब वर्तमान तत्व [MathematicalText](https://reference.aspose.com/slides/java/com.aspose.slides/mathematicaltext/) हो तो प्रारंभिक तत्व को भी शामिल करने हेतु उसकी जाँच करें।

यह उदाहरण मानता है कि `input.pptx` में `z = xᵢ / ∛y` जैसा समीकरण है, जिसमें अंश में सबस्क्रिप्ट और हर में मूल है। केवल ब्लॉक के शीर्ष‑स्तर तत्वों को प्रोसेस करने से भिन्न के भीतर का टेक्स्ट छूट जाता। उदाहरण स्लाइड टेक्स्ट फ्रेम में गणितीय हिस्से खोजता है, उनके ब्लॉक को [IMathPortion.getMathParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/imathportion/#getMathParagraph--) से प्राप्त करता है, और प्रत्येक टेक्स्ट तत्व के [getFormat](https://reference.aspose.com/slides/java/com.aspose.slides/mathematicaltext/#getFormat--) मेथड के माध्यम से [setFontHeight](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/#setFontHeight-float-) को 28 पॉइंट सेट करता है।

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

सहेजा गया प्रेज़ेंटेशन प्रत्येक प्रोसेस किए गए समीकरण के हर स्तर पर अद्यतन टेक्स्ट फ़ॉर्मेटिंग रखता है, जबकि उसका टेक्स्ट कंटेंट और गणितीय संरचना अपरिवर्तित रहती है।

## **शीघ्र संदर्भ**

| कार्य | मुख्य API |
| --- | --- |
| गणितीय टेक्स्ट बनाएं | [MathematicalText](https://reference.aspose.com/slides/java/com.aspose.slides/mathematicaltext/) |
| तत्व मिलाएँ | [IMathElement.join](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#join-com.aspose.slides.IMathElement-) |
| भिन्न बनाएं | [IMathElement.divide](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#divide-com.aspose.slides.IMathElement-) |
| सुपरसक्रिप्ट या सबस्क्रिप्ट जोड़ें | [setSuperscript](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#setSuperscript-com.aspose.slides.IMathElement-), [setSubscript](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#setSubscript-com.aspose.slides.IMathElement-) |
| फ़ंक्शन जोड़ें | [function](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#function-com.aspose.slides.IMathElement-), [asArgumentOfFunction](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#asArgumentOfFunction-com.aspose.slides.IMathElement-) |
| मूल जोड़ें | [IMathElement.radical](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#radical-com.aspose.slides.IMathElement-) |
| सीमा जोड़ें | [setLowerLimit](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#setLowerLimit-com.aspose.slides.IMathElement-), [setUpperLimit](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#setUpperLimit-com.aspose.slides.IMathElement-) |
| बाएँ‑हाथ स्क्रिप्ट जोड़ें | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#setSubSuperscriptOnTheLeft-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-) |
| योग और इंटीग्रल जोड़ें | [nary](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#nary-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-), [integral](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#integral-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-) |
| मैट्रिक्स जोड़ें | [MathMatrix](https://reference.aspose.com/slides/java/com.aspose.slides/mathmatrix/) |
| समीकरण ऐरे जोड़ें | [toMathArray](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#toMathArray--) |
| डिलिमिटर जोड़ें | [enclose](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#enclose-char-char-) |
| बार और बॉर्डर जोड़ें | [overbar](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#overbar--), [toBorderBox](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#toBorderBox--) |
| टर्म समूहित करें | [group](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#group-char-int-int-) |

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं मौजूदा PowerPoint समीकरण को संपादित कर सकता हूँ?**

हाँ। प्रेज़ेंटेशन खोलें, उस आकार को खोजें जिसमें एक [MathPortion](https://reference.aspose.com/slides/java/com.aspose.slides/mathportion/) है, [getMathParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/imathportion/#getMathParagraph--) को कॉल करें, और उस पैराग्राफ में गणितीय ब्लॉक अपडेट करें।

**क्या समीकरण संपादन योग्य PowerPoint गणित के रूप में सहेजे जाते हैं?**

हाँ। PPTX में सहेजते समय, Aspose.Slides समीकरण को संपादन योग्य Office गणित सामग्री के रूप में लिखता है।

**क्या मैं समीकरणों को LaTeX में निर्यात कर सकता हूँ?**

हाँ। समीकरण के [IMathParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/imathparagraph/) को उसके [IMathPortion](https://reference.aspose.com/slides/java/com.aspose.slides/imathportion/) से प्राप्त करें, और सीधे निर्यात करने के लिये [IMathParagraph.toLatex](https://reference.aspose.com/slides/java/com.aspose.slides/imathparagraph/#toLatex--) को कॉल करें। पूर्ण उदाहरण के लिये देखें [Export Math Equations from Presentations in Java](/slides/hi/java/exporting-math-equations/#export-math-equations-to-latex)।