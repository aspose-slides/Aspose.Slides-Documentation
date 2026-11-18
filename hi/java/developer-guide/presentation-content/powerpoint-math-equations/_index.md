---
title: Java में PowerPoint प्रस्तुतियों में गणितीय समीकरण जोड़ें
linktitle: PowerPoint गणितीय समीकरण
type: docs
weight: 80
url: /hi/java/powerpoint-math-equations/
keywords:
- गणितीय समीकरण
- गणितीय चिन्ह
- गणितीय सूत्र
- गणितीय पाठ
- गणितीय समीकरण जोड़ें
- गणितीय चिन्ह जोड़ें
- गणितीय सूत्र जोड़ें
- गणितीय पाठ जोड़ें
- PowerPoint
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java के साथ PowerPoint PPT और PPTX में गणितीय समीकरण सम्मिलित और संपादित करें, OMML का समर्थन, स्वरूपण नियंत्रण, और स्पष्ट Java कोड उदाहरण प्रदान करता है।"
---
## **परिचय**

PowerPoint समीकरणों को Office Math Markup Language (OMML) के रूप में संग्रहित करता है। Aspose.Slides for Java के साथ, आप प्रोग्रामmatically वही प्रकार की गणितीय सामग्री बना सकते हैं: अंश, मूल, फ़ंक्शन, सीमाएँ, N-ary ऑपरेटर, मैट्रिक्स, एरे, और स्वरूपित गणित ब्लॉक।

PowerPoint में, उपयोगकर्ता सामान्यतः **Insert > Equation** से समीकरण जोड़ते हैं:

![PowerPoint Insert टैब जिसमें Equation कमांड चयनित है](powerpoint-math-equations_1.png)

परिणाम स्लाइड पर संपादन योग्य गणितीय पाठ है:

![एक PowerPoint स्लाइड जिसमें संपादन योग्य गणितीय समीकरण है](powerpoint-math-equations_2.png)

Aspose.Slides उस गणितीय पाठ को तीन मुख्य वस्तुओं के माध्यम से बनाता है:

- एक गणितीय आकार, जो [addMathShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addMathShape-float-float-float-float-) के साथ बनाया जाता है, वह आकार है जिसमें समीकरण सम्मिलित होता है।
- [MathPortion](https://reference.aspose.com/slides/java/com.aspose.slides/mathportion/) आकार के पाठ फ्रेम के भीतर गणितीय सामग्री संग्रहीत करता है।
- [MathParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/mathparagraph/) एक या अधिक [MathBlock](https://reference.aspose.com/slides/java/com.aspose.slides/mathblock/) वस्तुओं को शामिल करता है।

नीचे के अधिकांश उदाहरण [MathematicalText](https://reference.aspose.com/slides/java/com.aspose.slides/mathematicaltext/) और [IMathElement](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/) की fluent मेथड्स का उपयोग करके कोड को छोटा और पठनीय बनाते हैं।

MathML निर्यात परिदर्श्यों के लिए, देखें [Java में प्रस्तुतियों से गणितीय समीकरण निर्यात](/slides/hi/java/exporting-math-equations/)।

## **समीकरण बनाएं**

यह उदाहरण [addMathShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addMathShape-float-float-float-float-) का उपयोग करके एक गणितीय आकार बनाता है और पाइथागोरस सिद्धांत जोड़ता है:

![c वर्ग बराबर a वर्ग प्लस b वर्ग का समीकरण](powerpoint-math-equations_3.png)

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
[addMathShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addMathShape-float-float-float-float-) एक आकार बनाता है जिसमें पहले से ही एक गणितीय पैराग्राफ शामिल होता है। पहले [MathPortion](https://reference.aspose.com/slides/java/com.aspose.slides/mathportion/) तक पहुँचें, [getMathParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/imathportion/#getMathParagraph--) को कॉल करें, और उसमें गणितीय ब्लॉकों या तत्वों को जोड़ें।
{{% /alert %}}

## **अंश जोड़ें**

एक अंश बनाने के लिए [divide](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#divide-com.aspose.slides.IMathElement-) का उपयोग करें। आप एक अंश शैली चुन सकते हैं [MathFractionTypes](https://reference.aspose.com/slides/java/com.aspose.slides/mathfractiontypes/) से।

![एक तिरछा गणितीय अंश जिसमें एक को x से विभाजित दिखाया गया है](powerpoint-math-equations_4.png)

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

स्टैक्ड अंश के लिए, [MathFractionTypes.Bar](https://reference.aspose.com/slides/java/com.aspose.slides/mathfractiontypes/#Bar) का उपयोग करें:

```java
import com.aspose.slides.*;

IMathFraction stackedFraction = new MathematicalText("x + 1").divide("y - 1", MathFractionTypes.Bar);
```

## **मूल जोड़ें**

एक वर्गमूल, घनमूल या अन्य मूल बनाने के लिए [radical](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#radical-com.aspose.slides.IMathElement-) का उपयोग करें। वर्तमान तत्व आधार बन जाता है और तर्क डिग्री बन जाता है।

![एक n-वीं मूल अभिव्यक्ति जिसमें x मूल संकेत के नीचे है](powerpoint-math-equations_5.png)

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

### **वर्गमूल की डिग्री दिखाएँ या छुपाएँ**

एक वर्गमूल स्पष्ट 2 प्रदर्शित कर सकता है या पारंपरिक √x स्वरूप का उपयोग कर सकता है। [IMathRadical](https://reference.aspose.com/slides/java/com.aspose.slides/imathradical/) का [setHideDegree](https://reference.aspose.com/slides/java/com.aspose.slides/imathradical/#setHideDegree-boolean-) मेथड निर्धारित करता है कि कौन सा रूप दिखेगा। दोनों रूप डिग्री 2 और radicand x को संपादन योग्य समीकरण में रखेंगे।

![बाएँ तरफ डिग्री दिखता हुआ और दाएँ तरफ छिपा हुआ समान वर्गमूल](square-root-degree.png)

उदाहरण समान वर्गमूल को दो बार सहेजता है। `visible-degree.pptx` में 2 दिखता है। `hidden-degree.pptx` में यह छिपा रहता है।

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

## **फ़ंक्शन और सीमाएँ जोड़ें**

`sin(x)`, `log(x)` या कस्टम फ़ंक्शन नामों जैसे फ़ंक्शन के लिए [asArgumentOfFunction](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#asArgumentOfFunction-com.aspose.slides.IMathElement-) या [function](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#function-com.aspose.slides.IMathElement-) का प्रयोग करें। सीमाओं के लिए, `lim` को एक [MathLimit](https://reference.aspose.com/slides/java/com.aspose.slides/mathlimit/) में रखें या [setLowerLimit](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#setLowerLimit-com.aspose.slides.IMathElement-) का उपयोग करें।

![x का सीमा जब x अनंत की ओर जाता है](powerpoint-math-equations_8.png)

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

कस्टम फ़ंक्शन नाम के लिए, फ़ंक्शन नाम को वर्तमान तत्व बनाएँ और उसके तर्क के साथ [function](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#function-com.aspose.slides.IMathElement-) को कॉल करें:

```java
import com.aspose.slides.*;

IMathFunction customFunction = new MathematicalText("f").function("x + 1");
```

## **N-ary ऑपरेटर और इंटेग्रल जोड़ें**

समिश्रण, संघ, प्रतिच्छेद और अन्य बड़े ऑपरेटरों के लिए [nary](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#nary-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-) का उपयोग करें। इंटेग्रल के लिए [integral](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#integral-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-) का उपयोग करें। दोनों मेथड निचली और ऊपरी सीमाएँ सेट करने की अनुमति देते हैं।

![एक समिश्रण जिसमें निचली और ऊपरी सीमाएँ हैं](powerpoint-math-equations_7.png)

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

N-ary ऑपरेटर बड़े ऑपरेटर होते हैं जिनमें वैकल्पिक सीमाएँ हो सकती हैं। `+`, `-`, `=` जैसे साधारण ऑपरेटर सामान्यतः [MathematicalText](https://reference.aspose.com/slides/java/com.aspose.slides/mathematicaltext/) के रूप में जोड़े जाते हैं और अभिव्यक्ति में सम्मिलित किए जाते हैं।

इंटेग्रल के लिए, [integral](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#integral-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-) का उपयोग करें:

```java
import com.aspose.slides.*;

IMathBlock integralBase = new MathematicalText("x").join(new MathematicalText("dx").toBox());
IMathNaryOperator integral = integralBase.integral(MathIntegralTypes.Simple, "0", "1");
```

## **मैट्रिक्स जोड़ें**

पंक्तियों और स्तम्भों के लिए [MathMatrix](https://reference.aspose.com/slides/java/com.aspose.slides/mathmatrix/) का उपयोग करें। मैट्रिक्स में डिफ़ॉल्ट रूप से ब्रेस नहीं होते, इसलिए कोष्ठक, ब्रैकेट या कर्ली ब्रेसेस की आवश्यकता होने पर उन्हें स्वयं जोड़ें।

![एक दो-पंक्तियों वाला गणितीय मैट्रिक्स जिसमें एक खाली सेल है](powerpoint-math-equations_10.png)

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

### **मौजूदा मैट्रिक्स संपादित करें**

मान लीजिए एक रैखिक बीजगणित पाठ `matrix.pptx` में कोफ़िशिएंट मैट्रिक्स से शुरू होता है, जो पिछले उदाहरण द्वारा सहेजा गया था। अगले अभ्यास के लिए, पहली समीकरण को रखें, दूसरी को दो नई समीकरणों से बदलें, और चर सेट को संशोधित करें। मौजूदा मैट्रिक्स को [IMathMatrix](https://reference.aspose.com/slides/java/com.aspose.slides/imathmatrix/) के माध्यम से खोलें ताकि लागू रहने वाले कोफ़िशिएंट बरकरार रहें।

![मूल दो-पंक्तियों वाला गुणांक मैट्रिक्स जिसमें प्रविष्टियाँ 1, x और पहली पंक्ति में एक खाली सेल और दूसरी पंक्ति में x, 2 और y हैं](matrix-before-edit.png)

पंक्ति और स्तम्भ इंडेक्स शून्य से प्रारंभ होते हैं और प्रत्येक कॉल पर वर्तमान मैट्रिक्स को संदर्भित करते हैं। इंडेक्स 1 से पहले पंक्ति डालने से मूल दूसरी पंक्ति इंडेक्स 2 पर चली जाती है। इंडेक्स 2 के बाद डालने से एक पंक्ति जोड़ती है। पंक्ति 2 को हटाने से मूल दूसरी समीकरण हट जाता है और जोड़ी गई पंक्ति एक स्थान ऊपर चली आती है। स्तम्भ भी इसी तरह शिफ्ट होते हैं।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("matrix.pptx");
try {
    IAutoShape shape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IMathPortion portion = (IMathPortion) shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    IMathMatrix matrix = (IMathMatrix) portion.getMathParagraph().get_Item(0).get_Item(0);

    matrix.insertRowBefore(1);
    matrix.insertRowAfter(2);
    matrix.deleteRow(2);

    matrix.insertColumnBefore(1);
    matrix.insertColumnAfter(3);
    matrix.deleteColumn(3);

    // नई कोशिकाएँ प्रारंभ में null होती हैं। पहले गैर-शून्य गुणांक सेट करें।
    matrix.set_Item(1, 0, new MathematicalText("12"));
    matrix.set_Item(1, 1, new MathematicalText("1"));
    matrix.set_Item(2, 2, new MathematicalText("10"));
    matrix.set_Item(2, 3, new MathematicalText("1"));
    for (int row = 0; row < matrix.getRowCount(); row++) {
        for (int column = 0; column < matrix.getColumnCount(); column++) {
            if (matrix.get_Item(row, column) == null) {
                matrix.set_Item(row, column, new MathematicalText("0"));
            }
        }
    }

    matrix.setColumnAlignment(0, MathHorizontalAlignment.Left);
    matrix.setColumnsAlignment(1, 3, MathHorizontalAlignment.Right);

    presentation.save("updated-matrix.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[setColumnAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/imathmatrix/#setColumnAlignment-int-int-) पहली स्तम्भ को बाएँ संरेखित करता है। [setColumnsAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/imathmatrix/#setColumnsAlignment-int-long-int-) तीन लगातार स्तम्भों को दाएँ संरेखित करता है, इंडेक्स 1 से शुरू। `updated-matrix.pptx` में मैट्रिक्स में तीन समीकरण और चार चर हैं। मूल पहली‑पंक्ति के कोफ़िशिएंट `1` और `x` अब पहली और तीसरी स्तम्भ में दिखाई देते हैं।

![अपडेट किया गया तीन‑पंक्तियों वाला मैट्रिक्स जिसमें पंक्तियाँ 1, 0, x, 0; 12, 1, 0, 0; और 0, 0, 10, 1 दिखाए गए हैं](matrix-after-edit.png)

## **समीकरण एरे जोड़ें**

जब आपको संरेखित समीकरण या अभिव्यक्तियों की ऊर्ध्वाधर स्टैक चाहिए, तो [toMathArray](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#toMathArray--) का उपयोग करें।

![एक ऊर्ध्वाधर गणित एरे जिसमें x ऊपर y है](powerpoint-math-equations_11.png)

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

### **आस‑पास के तत्वों के साथ एरे को संरेखित करें**

[setBaseJustification](https://reference.aspose.com/slides/java/com.aspose.slides/imatharray/#setBaseJustification-int-) एरे की ऊर्ध्वाधर संरेखण को उसके बगल में मौजूद गणितीय तत्वों के सापेक्ष नियंत्रित करता है। नीचे का उदाहरण पहली पंक्ति, एरे के मध्य और अंतिम पंक्ति के साथ संरेखण की तुलना करता है।

निम्न उदाहरण तीन समान एरे बनाता है, प्रत्येक में तीन पंक्तियाँ और पास के तत्व `A=` और `=B` हैं। सभी गणितीय पाठ Cambria Math के 24 पॉइंट आकार के हैं। केवल एरे संरेखण बदलता है।

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

निम्न तुलना PowerPoint में सहेजे गए प्रस्तुतीकरण को दिखाती है। प्रत्येक एरे के बगल में `A=` और `=B` की स्थिति देखें।

![PowerPoint में समीकरण एरे के साथ शीर्ष, मध्य और नीचे संरेखण और समान पास के तत्व](equation-array-alignment.png)

### **पंक्ति अंतराल कॉन्फ़िगर करें**

[setRowSpacingRule](https://reference.aspose.com/slides/java/com.aspose.slides/imatharray/#setRowSpacingRule-int-) एरे में पंक्तियों के बीच अंतराल नियम चुनता है। [setRowSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/imatharray/#setRowSpacing-long-) स्पष्ट अंतराल नियम के लिए संख्यात्मक मान देता है और प्रीसेट नियमों को अनदेखा करता है।

सटीक अंतराल के लिए मान को पॉइंट में मापा जाता है। अनुपातिक अंतराल के लिए इसे आधी‑लाइन में मापा जाता है: उदाहरण में मान `3` 1.5 लाइन का प्रतिनिधित्व करता है। स्पष्ट मान निर्दिष्ट करने पर दोनों गुणधर्म सेट करें; केवल संख्यात्मक मान बदलने से अंतराल नियम चयनित नहीं होता।

नीचे का उदाहरण पाँच प्रस्तुतियों को समान समीकरण, संरेखण और फ़ॉन्ट सेटिंग्स के साथ सहेजता है। पहली तीन प्रीसेट प्रयोग करती हैं; अंतिम दो स्पष्ट मान दिखाती हैं।

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

एरे पंक्ति अंतराल पैराग्राफ अंतराल से अलग है। [setSpaceBefore](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setSpaceBefore-float-) और [setSpaceAfter](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setSpaceAfter-float-) पैराग्राफ के चारों ओर स्थान जोड़ते हैं, न कि एरे पंक्तियों के बीच। इसी प्रकार, [IMathParagraph.setJustification](https://reference.aspose.com/slides/java/com.aspose.slides/imathparagraph/#setJustification-int-) संपूर्ण गणित पैराग्राफ को क्षैतिज रूप से स्थित करता है; यह एरे की ऊर्ध्वाधर संरेखण सेटिंग को नहीं बदलता।

## **त्रिकोणमितीय फ़ंक्शन जोड़ें**

जब तर्क वर्तमान तत्व हो और फ़ंक्शन नाम ज्ञात हो, तो [asArgumentOfFunction](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#asArgumentOfFunction-com.aspose.slides.IMathElement-) का उपयोग करें।

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

सूचकांकों और घातांक के लिए सबस्क्रिप्ट और सुपरसक्रिप्ट हेल्पर का उपयोग करें। जब सूचकांकों को आधार के बाएँ पक्ष पर प्रदर्शित करना हो, तो [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#setSubSuperscriptOnTheLeft-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-) का उपयोग करें।

![एक बड़ा Y जिसके बाएँ पक्ष पर सबस्क्रिप्ट 1 और सुपरसक्रिप्ट n है](powerpoint-math-equations_9.png)

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

## **डेलीमीटर जोड़ें**

एक अभिव्यक्ति को डेलीमीटर में रखने के लिए [enclose](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#enclose-char-char-) का उपयोग करें। कई तत्वों वाले डेलीमीटर अभिव्यक्तियों के लिए आप एक विभाजक वर्ण भी सेट कर सकते हैं।

![एक डेलीमीटर अभिव्यक्ति जिसमें x, y और z ऊर्ध्वाधर रेखाओं द्वारा अलग किए गए हैं](powerpoint-math-equations_13.png)

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

### **डेलीमीटर का आकार और संरेखण**

[setGrowToMatchOperandHeight](https://reference.aspose.com/slides/java/com.aspose.slides/imathdelimiter/#setGrowToMatchOperandHeight-boolean-) को `true` पास करने से बड़े ऑपरेण्ड के आसपास कोष्ठक बढ़ते हैं, या `false` पास करने से वे सामान्य आकार पर रहते हैं। एक [MathDelimiterShape](https://reference.aspose.com/slides/java/com.aspose.slides/mathdelimitershape/) मान के साथ [setDelimiterShape](https://reference.aspose.com/slides/java/com.aspose.slides/imathdelimiter/#setDelimiterShape-int-) का उपयोग करें। `Centered` कोष्ठकों को गणित अक्ष पर केंद्रित करता है, जो बराबर चिन्ह के मध्य से चलता है। `Match` उन्हें सम्मिलित सामग्री के साथ संरेखित करता है। दोनों सेटिंग केवल डेलीमीटर को प्रभावित करती हैं; अंदर का अभिव्यक्ति समान रहता है।

उदाहरण ने `x` के घात में एक अंश रखा है ताकि अभिव्यक्ति बेसलाइन से ऊपर नीचे दोनों की तुलना में अधिक विस्तारित हो। सभी चार समीकरण समान कोष्ठक और फ़ॉन्ट सेटिंग्स का उपयोग करते हैं।

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

PowerPoint में पंक्तियों की तुलना करके वृद्धि प्रभाव देखें। शीर्ष पंक्ति में कोष्ठक घात को घेरते हुए बढ़ते हैं और दोनों आकार समान दिखते हैं। नीचे की पंक्ति में वृद्धि बंद है। बाएँ (`Centered`) छोटे कोष्ठक बराबर चिन्ह के साथ संरेखित होते हैं, जबकि दाएँ (`Match`) अभिव्यक्ति के ऊपर ऊँचे होते हैं।

![PowerPoint में चार समीकरण जिसमें डेलीमीटर वृद्धि सक्षम और निष्क्रिय, बाएँ तरफ Centered और दाएँ तरफ Match](delimiter-sizing.png)

## **एक बॉर्डर बॉक्स जोड़ें**

एक अंश पर [toBorderBox](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#toBorderBox--) को कॉल करके पूरी अभिव्यक्ति को फ्रेम करें। लौटाया गया [IMathBorderBox](https://reference.aspose.com/slides/java/com.aspose.slides/imathborderbox/) डिफ़ॉल्ट रूप से चारों ओर दिखाता है। व्यक्तिगत पक्ष हटाने के लिए [setHideTop](https://reference.aspose.com/slides/java/com.aspose.slides/imathborderbox/#setHideTop-boolean-), [setHideBottom](https://reference.aspose.com/slides/java/com.aspose.slides/imathborderbox/#setHideBottom-boolean-), [setHideLeft](https://reference.aspose.com/slides/java/com.aspose.slides/imathborderbox/#setHideLeft-boolean-), और [setHideRight](https://reference.aspose.com/slides/java/com.aspose.slides/imathborderbox/#setHideRight-boolean-) का उपयोग करें।

उदाहरण ने एक ही अंश की छह प्रतियाँ एक ही स्लाइड पर रखी हैं। रद्द करने के लिए सभी चार पक्ष छिपाएँ और [setStrikethroughBottomLeftToTopRight](https://reference.aspose.com/slides/java/com.aspose.slides/imathborderbox/#setStrikethroughBottomLeftToTopRight-boolean-) को `true` पास करके आरोही विकर्ण (↗) बनाएं या [setStrikethroughTopLeftToBottomRight](https://reference.aspose.com/slides/java/com.aspose.slides/imathborderbox/#setStrikethroughTopLeftToBottomRight-boolean-) को `true` पास करके अवरोही विकर्ण (↘) बनाएं। आप [setStrikethroughHorizontal](https://reference.aspose.com/slides/java/com.aspose.slides/imathborderbox/#setStrikethroughHorizontal-boolean-) या [setStrikethroughVertical](https://reference.aspose.com/slides/java/com.aspose.slides/imathborderbox/#setStrikethroughVertical-boolean-) को भी किसी भी दृश्य पक्ष के साथ संयोजन में उपयोग कर सकते हैं।

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

![छह संपादन योग्य अंश PowerPoint में। शीर्ष पंक्ति: पूरा बॉर्डर, नीचे और बाएँ पक्ष, ऊपर की ओर तिरछी रेखा। नीचे पंक्ति: नीचे की ओर तिरछी रेखा, क्षैतिज स्ट्राइक, पूर्ण बॉर्डर के साथ लंबवत स्ट्राइक।](border-box-fractions.png)

इस अंश पर क्षैतिज स्ट्राइक अंश रेखा के ऊपर ओवरले करता है। लंबवत स्ट्राइक अंश के अंशांक और हर तथा को दोनों को काटता है जबकि आसपास का बॉर्डर दृश्यमान रहता है। ये रेखाएँ पूरी अभिव्यक्ति को सजाते हैं। सामान्य पाठ स्ट्राइकथ्रू केवल पाठ रन के अक्षरों पर लागू होता है। PowerPoint में प्रस्तुति पुनः खोलने के बाद आप अंशांक और हर को स्वतंत्र रूप से संपादित कर सकते हैं।

## **Phantom तत्वों के साथ दृश्यता और लेआउट नियंत्रित करें**

[MathPhantom](https://reference.aspose.com/slides/java/com.aspose.slides/mathphantom/) में अभिव्यक्ति को लपेटकर आप उसकी दृश्यता और समीकरण में योगदान देने वाले स्थान को स्वतंत्र रूप से नियंत्रित कर सकते हैं। [IMathPhantom](https://reference.aspose.com/slides/java/com.aspose.slides/imathphantom/) की मेथड्स निम्नलिखित को नियंत्रित करती हैं:

| विधि | प्रभाव |
| --- | --- |
| [setShow](https://reference.aspose.com/slides/java/com.aspose.slides/imathphantom/#setShow-boolean-) | `false` पास करके अभिव्यक्ति को छिपाएँ। इसके आयाम अभी भी लेआउट में योगदान देते हैं जब तक नीचे की मेथड्स `true` नहीं करतीं। |
| [setZeroWidth](https://reference.aspose.com/slides/java/com.aspose.slides/imathphantom/#setZeroWidth-boolean-) | अभिव्यक्ति की क्षैतिज चौड़ाई को शून्य मानें, जिससे पड़ोसी तत्व एक‑दूसरे के करीब आ सकें। |
| [setZeroAsc](https://reference.aspose.com/slides/java/com.aspose.slides/imathphantom/#setZeroAsc-boolean-) | उसकी आरोह (बेसलाइन के ऊपर की ऊँचाई) को शून्य मानें। इससे पड़ोसी तत्वों के ऊपर आरक्षित स्थान घट सकता है। |
| [setZeroDesc](https://reference.aspose.com/slides/java/com.aspose.slides/imathphantom/#setZeroDesc-boolean-) | उसकी अवरोह (बेसलाइन के नीचे की गहराई) को शून्य मानें। इससे अंश रेखा या अन्य सामग्री अभिव्यक्ति के नीचे पड़ोसियों के करीब आ सकती है। |

बेसलाइन वह संदर्भ रेखा है जिस पर सामान्य गणितीय अक्षर स्थित होते हैं। सामग्री को छिपाने से उसके आयाम नहीं हटते, और आयाम को शून्य मानने से अभिव्यक्ति हटती नहीं है। मूल अभिव्यक्ति [getBase](https://reference.aspose.com/slides/java/com.aspose.slides/imathphantom/#getBase--) के माध्यम से अभी भी उपलब्ध है। फिर से दिखाने के लिए [setShow](https://reference.aspose.com/slides/java/com.aspose.slides/imathphantom/#setShow-boolean-) को `true` पास करें; आयाम सेटिंग अपरिवर्तित रहती हैं।

नीचे का उदाहरण पाँच समानांतर वैरिएंट बनाता है: एक दृश्यमान अंश, एक छिपा अंश जो स्थान सुरक्षित रखता है, और शून्य‑चौड़ाई, शून्य‑उत्थान या शून्य‑अवरोह वाले तीन छिपे अंश। प्रत्येक वैरिएंट समान आस‑पास की अभिव्यक्ति और Cambria Math के 24 पॉइंट आकार का उपयोग करता है। सभी समीकरण आकार समान शीर्ष स्थिति के साथ होते हैं, जो ग्रे गाइड द्वारा चिह्नित होते हैं। बाहरी अंश के अंशांक में Phantom रखने से ऊर्ध्वाधर लेआउट परिवर्तन स्पष्ट दिखते हैं।

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

![PowerPoint में पाँच समीकरण जहाँ एक दृश्यमान अंश, एक छिपा अंश जो स्थान सुरक्षित रखता है, और शून्य‑चौड़ाई, शून्य‑उत्थान या शून्य‑अवरोह वाला छिपा अंश दिखाया गया है](math-phantom.png)

## **शर्तों को समूहित करें**

एक अभिव्यक्ति के ऊपर या नीचे समूहिंग अक्षर रखने के लिए [group](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#group-char-int-int-) का उपयोग करें। समूहित शर्तों को लेबल करने के लिए एक सीमा जोड़ें।

![अभिव्यक्ति x प्लस y को समूहित किया गया, नीचे कोई लेबल टेक्स्ट के साथ](powerpoint-math-equations_15.png)

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

## **गणितीय तत्वों का स्वरूप**

फ़ॉर्मेटिंग हेल्पर केवल तभी उपयोग करें जब वे सूत्र को स्पष्ट बनाते हों। उदाहरण के लिए, [overbar](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#overbar--) गणितीय तत्व के ऊपर एक बार रखता है।

![एक गणितीय अभिव्यक्ति ABC के ऊपर ओवरबार](powerpoint-math-equations_14.png)

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

एक मौजूदा समीकरण में पूरे टेक्स्ट को स्वरूपित करने के लिए प्रत्येक गणित ब्लॉक के तत्व वृक्ष को पार करें। [IMathElement.getChildren](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#getChildren--) केवल तत्काल संतानों को लौटाता है, इसलिए फ़्रैक्शन, स्क्रिप्ट, मूल और अन्य नेस्टेड संरचनाओं के भीतर के पाठ तक पहुँचने के लिए इसे पुनरावर्तित रूप से कॉल करें। वर्तमान तत्व और उसकी संतानों दोनों की जाँच करें ताकि प्रारंभिक तत्व को शामिल किया जा सके जब वह [MathematicalText](https://reference.aspose.com/slides/java/com.aspose.slides/mathematicaltext/) हो।

यह उदाहरण मानता है कि `input.pptx` में एक समीकरण है जैसे `z = xᵢ / ∛y`, जहाँ अंश में अंशांक में एक सबस्क्रिप्ट और हर में एक मूल है। केवल ब्लॉक के शीर्ष‑स्तर तत्वों को प्रोसेस करने से अंश के भीतर का पाठ छूट जाएगा। उदाहरण स्लाइड पाठ फ्रेम में गणितीय भागों को खोजता है, उनके ब्लॉकों को [IMathPortion.getMathParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/imathportion/#getMathParagraph--) से प्राप्त करता है, और प्रत्येक टेक्स्ट तत्व की [getFormat](https://reference.aspose.com/slides/java/com.aspose.slides/mathematicaltext/#getFormat--) मेथड के माध्यम से [setFontHeight](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/#setFontHeight-float-) को 28 पॉइंट सेट करता है।

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

सहेजा गया प्रस्तुतिकरण प्रत्येक प्रोसेस किए गए समीकरण के हर स्तर पर अद्यतन टेक्स्ट स्वरूपण शामिल करता है, जबकि उसकी टेक्स्ट सामग्री और गणितीय संरचना को संरक्षित रखता है।

## **त्वरित संदर्भ**

| कार्य | मुख्य API |
| --- | --- |
| गणितीय पाठ बनाएं | [MathematicalText](https://reference.aspose.com/slides/java/com.aspose.slides/mathematicaltext/) |
| तत्वों को मिलाएँ | [IMathElement.join](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#join-com.aspose.slides.IMathElement-) |
| अंश बनाएं | [IMathElement.divide](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#divide-com.aspose.slides.IMathElement-) |
| सुपरसक्रिप्ट या सबस्क्रिप्ट जोड़ें | [setSuperscript](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#setSuperscript-com.aspose.slides.IMathElement-), [setSubscript](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#setSubscript-com.aspose.slides.IMathElement-) |
| फ़ंक्शन जोड़ें | [function](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#function-com.aspose.slides.IMathElement-), [asArgumentOfFunction](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#asArgumentOfFunction-com.aspose.slides.IMathElement-) |
| मूल जोड़ें | [IMathElement.radical](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#radical-com.aspose.slides.IMathElement-) |
| सीमाएँ जोड़ें | [setLowerLimit](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#setLowerLimit-com.aspose.slides.IMathElement-), [setUpperLimit](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#setUpperLimit-com.aspose.slides.IMathElement-) |
| बाएँ‑साइड स्क्रिप्ट जोड़ें | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#setSubSuperscriptOnTheLeft-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-) |
| समिश्रण और इंटेग्रल जोड़ें | [nary](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#nary-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-), [integral](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#integral-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-) |
| मैट्रिक्स जोड़ें | [MathMatrix](https://reference.aspose.com/slides/java/com.aspose.slides/mathmatrix/) |
| समीकरण एरे जोड़ें | [toMathArray](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#toMathArray--) |
| डेलीमीटर जोड़ें | [enclose](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#enclose-char-char-) |
| बार और बॉर्डर जोड़ें | [overbar](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#overbar--), [toBorderBox](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#toBorderBox--) |
| शर्तें समूहित करें | [group](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#group-char-int-int-) |

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं मौजूदा PowerPoint समीकरण को संपादित कर सकता हूँ?**

हाँ। प्रस्तुतीकरण खोलें, उस आकार को खोजें जिसमें एक [MathPortion](https://reference.aspose.com/slides/java/com.aspose.slides/mathportion/) हो, [getMathParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/imathportion/#getMathParagraph--) को कॉल करें, और उस पैराग्राफ में गणितीय ब्लॉक को अपडेट करें।

**क्या समीकरणों को संपादन योग्य PowerPoint गणित के रूप में सहेजा जाता है?**

हाँ। PPTX में सहेजते समय, Aspose.Slides समीकरण को संपादन योग्य Office गणित सामग्री के रूप में लिखता है।

**क्या मैं समीकरणों को LaTeX में निर्यात कर सकता हूँ?**

हाँ। समीकरण के [IMathParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/imathparagraph/) को उसके [IMathPortion](https://reference.aspose.com/slides/java/com.aspose.slides/imathportion/) से प्राप्त करें, और सीधे निर्यात करने के लिए [IMathParagraph.toLatex](https://reference.aspose.com/slides/java/com.aspose.slides/imathparagraph/#toLatex--) को कॉल करें। पूर्ण उदाहरण के लिये देखें [Java में प्रस्तुतियों से गणितीय समीकरण निर्यात](/slides/hi/java/exporting-math-equations/#export-math-equations-to-latex)।