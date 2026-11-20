---
title: Android पर PowerPoint प्रस्तुतियों में गणितीय समीकरण जोड़ें
linktitle: PowerPoint गणितीय समीकरण
type: docs
weight: 80
url: /hi/androidjava/powerpoint-math-equations/
keywords:
- गणितीय समीकरण
- गणितीय संकेत
- गणितीय सूत्र
- गणितीय पाठ
- गणितीय समीकरण जोड़ें
- गणितीय संकेत जोड़ें
- गणितीय सूत्र जोड़ें
- गणितीय पाठ जोड़ें
- PowerPoint
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android के साथ PowerPoint PPT और PPTX में गणितीय समीकरण सम्मिलित और संपादित करें, OMML का समर्थन, स्वरूपण नियंत्रण, और स्पष्ट Java कोड नमूनों के साथ।"
---
## **अवलोकन**

PowerPoint समीकरणों को Office Math Markup Language (OMML) के रूप में सहेजता है। Aspose.Slides for Android via Java के साथ आप प्रोग्रामैटिक रूप से उसी प्रकार की गणितीय सामग्री बना सकते हैं: भिन्न, मूल, फ़ंक्शन, सीमाएँ, N-ary ऑपरेटर, मैट्रिक्स, एरे, और स्वरूपित गणित ब्लॉक।

PowerPoint में, उपयोगकर्ता सामान्य रूप से **Insert > Equation** से समीकरण जोड़ते हैं:

![PowerPoint Insert टैब में Equation कमांड चयनित है](powerpoint-math-equations_1.png)

परिणाम स्लाइड पर संपादन योग्य गणितीय पाठ होगा:

![एक PowerPoint स्लाइड जिसमें एक संपादन योग्य गणितीय समीकरण है](powerpoint-math-equations_2.png)

Aspose.Slides उस गणितीय पाठ को तीन मुख्य ऑब्जेक्ट्स के माध्यम से बनाता है:

- एक गणितीय आकार, जिसे [addMathShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/) से बनाया जाता है, वह आकार है जिसमें समीकरण होता है।
- [MathPortion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathportion/) आकार के टेक्स्ट फ़्रेम के भीतर गणितीय सामग्री संग्रहीत करता है।
- [MathParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathparagraph/) में एक या अधिक [MathBlock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathblock/) ऑब्जेक्ट होते हैं।

नीचे के अधिकांश उदाहरण [MathematicalText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathematicaltext/) और [IMathElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) की फ्लुएंट मेथड्स का उपयोग करते हैं ताकि कोड छोटा और पठनीय रहे।

MathML निर्यात परिदृश्यों के लिए, देखें [Export Math Equations from Presentations on Android](/slides/hi/androidjava/exporting-math-equations/)।

## **समीकरण बनाएं**

यह उदाहरण [addMathShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addMathShape-float-float-float-float-) का प्रयोग करके एक गणितीय आकार बनाता है और पायथागोरस प्रमेय जोड़ता है:

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
[addMathShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addMathShape-float-float-float-float-) एक आकार बनाता है जिसमें पहले से ही एक गणितीय पैराग्राफ होता है। पहले [MathPortion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathportion/) तक पहुंचें, [getMathParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathportion/#getMathParagraph--) को कॉल करें, और उसमें गणितीय ब्लॉक या तत्व जोड़ें।
{{% /alert %}}

### **गणित ब्लॉकों को मिलाएं**

जब समीकरण के भाग स्वतंत्र रूप से [IMathBlock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathblock/) ऑब्जेक्ट्स के रूप में बनते हैं, तो उन्हें मिलाने के लिए [joinBlock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathblock/#joinBlock-com.aspose.slides.IMathBlock-) का उपयोग करें। यह उदाहरण बाएँ ब्लॉक में `c² =` और दाएँ ब्लॉक में `a² + b²` बनाता है। [setSuperscript](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#setSuperscript-java.lang.String-) सभी तीन पावर के लिए संपादन योग्य गणितीय सुपरस्क्रिप्ट बनाता है।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addMathShape(20, 20, 600, 100);
    IMathPortion mathPortion = (IMathPortion) shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    IMathParagraph mathParagraph = mathPortion.getMathParagraph();

    MathBlock leftBlock = new MathBlock();
    leftBlock.add(new MathematicalText("c").setSuperscript("2"));
    leftBlock.add(new MathematicalText("="));

    MathBlock rightBlock = new MathBlock();
    rightBlock.add(new MathematicalText("a").setSuperscript("2"));
    rightBlock.add(new MathematicalText("+"));
    rightBlock.add(new MathematicalText("b").setSuperscript("2"));

    IMathBlock combinedBlock = leftBlock.joinBlock(rightBlock);
    mathParagraph.add(combinedBlock);

    presentation.save("equation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[joinBlock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathblock/#joinBlock-com.aspose.slides.IMathBlock-) `leftBlock` स्वयं को लौटाता है, अब क्रम में दोनों भाग शामिल होते हैं, और `rightBlock` को खाली छोड़ देता है। मिलाए गए ब्लॉक को केवल एक बार [IMathParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathparagraph/) में जोड़ें। `equation.pptx` को पुनः खोलने के बाद, पैराग्राफ में एक ब्लॉक होगा जो `c² = a² + b²` का प्रतिनिधित्व करता है, जिसमें सभी तीन पावर गणितीय सुपरस्क्रिप्ट के रूप में संरक्षित रहते हैं।

[add](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelementcollection/#add-com.aspose.slides.IMathElement-) को `leftBlock.add(rightBlock)` के रूप में कॉल करने से एक ब्लॉक को सीधे दूसरे के भीतर नेस्ट करने की कोशिश की जाती है और यह `InvalidOperationException` उत्पन्न करता है।

## **भिन्न जोड़ें**

एक भिन्न बनाने के लिए [divide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#divide-com.aspose.slides.IMathElement-) का उपयोग करें। आप [MathFractionTypes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathfractiontypes/) से एक भिन्न शैली चुन सकते हैं।

![एक विकृत गणितीय भिन्न जहाँ एक को x से विभाजित किया गया है](powerpoint-math-equations_4.png)

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

एक वर्गमूल, घनमूल या अन्य मूल बनाने के लिए [radical](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#radical-com.aspose.slides.IMathElement-) का प्रयोग करें। वर्तमान तत्व बेस बन जाता है, और तर्क डिग्री बन जाता है।

![एक n-थ मूल अभिव्यक्ति जहाँ x मूल चिह्न के नीचे है](powerpoint-math-equations_5.png)

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

### **वर्गमूल की डिग्री दिखाएं या छिपाएं**

एक वर्गमूल स्पष्ट 2 दिखा सकता है या पारम्परिक √x स्वरूप का उपयोग कर सकता है। [IMathRadical](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathradical/) की [setHideDegree](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathradical/#setHideDegree-boolean-) मेथड यह नियंत्रित करती है कि कौन सा रूप दिखाई दे। दोनों रूप में डिग्री 2 और radicand x संपादन योग्य समीकरण में बने रहते हैं।

![एक ही वर्गमूल जहाँ बाएँ में डिग्री दिखाई देती है और दाएँ में छिपी हुई है](square-root-degree.png)

उदाहरण समान वर्गमूल को दो बार सहेजता है। `visible-degree.pptx` में 2 दिखाई देता है। `hidden-degree.pptx` में यह छिपा हुआ है।

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

[asArgumentOfFunction](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#asArgumentOfFunction-com.aspose.slides.IMathElement-) या [function](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#function-com.aspose.slides.IMathElement-) का उपयोग कर `sin(x)`, `log(x)` या कस्टम फ़ंक्शन नाम जोड़ सकते हैं। सीमाओं के लिये, `lim` को एक [MathLimit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathlimit/) में रखें या [setLowerLimit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#setLowerLimit-com.aspose.slides.IMathElement-) का प्रयोग करें।

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
            .setLowerLimit("x→∞")
            .function("x");

    mathParagraph.add(new MathBlock(limit));

    presentation.save("functions-and-limits.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

कस्टम फ़ंक्शन नाम के लिये, फ़ंक्शन नाम को वर्तमान तत्व बनाएं और उसके तर्क के साथ [function](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#function-com.aspose.slides.IMathElement-) को कॉल करें:

```java
import com.aspose.slides.*;

IMathFunction customFunction = new MathematicalText("f").function("x + 1");
```

## **N-ary ऑपरेटर और इंटीग्रल जोड़ें**

समेशन, संघ, प्रतिच्छेदन और अन्य बड़े ऑपरेटरों के लिये [nary](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#nary-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-) का प्रयोग करें। इंटीग्रल के लिये [integral](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#integral-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-) का प्रयोग करें। दोनों मेथड्स आपको निचली और ऊपरी सीमाएँ सेट करने देते हैं।

![एक समेशन जिसमें निचली और ऊपरी सीमाएँ हैं](powerpoint-math-equations_7.png)

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

N-ary ऑपरेटर बड़े ऑपरेटर होते हैं जिनमें वैकल्पिक सीमाएँ हो सकती हैं। साधारण ऑपरेटर जैसे `+`, `-`, और `=` सामान्यतः [MathematicalText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathematicaltext/) के रूप में जोड़े जाते हैं और अभिव्यक्ति में सम्मिलित होते हैं।

इंटीग्रल के लिये, [integral](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#integral-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-) का प्रयोग करें:

```java
import com.aspose.slides.*;

IMathBlock integralBase = new MathematicalText("x").join(new MathematicalText("dx").toBox());
IMathNaryOperator integral = integralBase.integral(MathIntegralTypes.Simple, "0", "1");
```

## **मैट्रिक्स जोड़ें**

पंक्तियों और स्तंभों के लिये [MathMatrix](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathmatrix/) का प्रयोग करें। डिफ़ॉल्ट रूप से मैट्रिक्स में ब्रैक्ट नहीं होते, इसलिए यदि आपको कोष्ठक, ब्रैकेट या कर्ली ब्रेसेस चाहिए तो मैट्रिक्स को उनमें घेरें।

![दो पंक्तियों वाला एक गणितीय मैट्रिक्स जहाँ एक सेल खाली है](powerpoint-math-equations_10.png)

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

### **मौजूदा मैट्रिक्स को संपादित करें**

मान लीजिए एक रैखिक बीजगणित पाठ में `matrix.pptx` में गुणांक मैट्रिक्स है, जो पिछले उदाहरण से सहेजा गया है। अगले अभ्यास में, पहली समीकरण रखें, दूसरी को दो नई समीकरणों से बदलें, और चर सेट को संशोधित करें। मौजूदा मैट्रिक्स को खोलने के लिये [IMathMatrix](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathmatrix/) का प्रयोग करें ताकि लागू होने वाले गुणांक बरकरार रहें।

![दो पंक्तियों वाला मूल गुणांक मैट्रिक्स जहाँ पहली पंक्ति में 1, x और एक खाली सेल है तथा दूसरी पंक्ति में x, 2 और y हैं](matrix-before-edit.png)

पंक्ति और स्तंभ सूचक शून्य से शुरू होते हैं और प्रत्येक कॉल पर मैट्रिक्स की वर्तमान स्थिति को दर्शाते हैं। सूचक 1 से पहले पंक्ति डालने से मूल दूसरी पंक्ति सूचक 2 पर चली जाती है। सूचक 2 के बाद डालने से एक पंक्ति जोड़ दी जाती है। पंक्ति 2 को हटाने से मूल दूसरी समीकरण हट जाता है और जोड़ी गई पंक्ति एक स्थान ऊपर आ जाती है। स्तंभ भी उसी प्रकार शिफ्ट होते हैं।

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

    // नई कोशिकाएँ प्रारंभ में null होती हैं। गैर-शून्य गुणांक पहले सेट करें।
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

[setColumnAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathmatrix/#setColumnAlignment-int-int-) पहला स्तंभ बाएँ संरेखित करता है। [setColumnsAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathmatrix/#setColumnsAlignment-int-long-int-) तीन लगातार स्तंभों को दाएँ संरेखित करता है, सूचक 1 से शुरू करके। `updated-matrix.pptx` में, मैट्रिक्स में तीन समीकरण और चार चर हैं। मूल पहली पंक्ति के गुणांक `1` और `x` अब पहले और तीसरे स्तंभ में दिखते हैं।

![अपडेट किया गया तीन पंक्तियों वाला मैट्रिक्स जहाँ पंक्तियाँ 1, 0, x, 0; 12, 1, 0, 0; और 0, 0, 10, 1 हैं](matrix-after-edit.png)

## **समीकरण एरे जोड़ें**

जब आपको संरेखित समीकरण या अभिव्यक्तियों का एक लंबवत स्टैक चाहिए, तो [toMathArray](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#toMathArray--) का प्रयोग करें।

![एक लंबवत गणितीय एरे जहाँ x ऊपर और y नीचे है](powerpoint-math-equations_11.png)

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

### **परिधीय तत्वों के साथ एरे संरेखित करें**

[setBaseJustification](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imatharray/#setBaseJustification-int-) एरे की लंबवत संरेखण को उसके बगल में स्थित गणितीय तत्वों के सापेक्ष नियंत्रित करता है। नीचे का उदाहरण पहला पंक्ति, एरे का मध्य, और अंतिम पंक्ति के साथ संरेखण की तुलना करता है।

निम्नलिखित उदाहरण तीन समान एरे बनाता है, प्रत्येक में तीन पंक्तियाँ और पड़ोसी तत्व `A=` और `=B` हैं। सभी गणितीय पाठ Cambria Math में 24 पॉइंट आकार के हैं। केवल एरे की संरेखण बदलती है।

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

नीचे का तुलना PowerPoint में सहेजे गए प्रस्तुति को दर्शाता है। देखें कि प्रत्येक एरे के बगल में `A=` और `=B` की स्थिति कैसे है।

![PowerPoint में समीकरण एरे जिसमें Top, Center, और Bottom संरेखण हैं और समान पड़ोसी तत्व हैं](equation-array-alignment.png)

### **पंक्ति स्पेसिंग कॉन्फ़िगर करें**

[setRowSpacingRule](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imatharray/#setRowSpacingRule-int-) एरे की पंक्तियों के भीतर स्पेसिंग नियम चुनता है। [setRowSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imatharray/#setRowSpacing-long-) स्पष्ट स्पेसिंग नियम के लिये संख्यात्मक मान प्रदान करता है और प्रीसेट नियमों द्वारा अनदेखा किया जाता है।

सटीक स्पेसिंग के लिये मान को पॉइंट में मापा जाता है। अनुपाती स्पेसिंग के लिये इसे आधी-रेखाओं में मापा जाता है: उदाहरण में `3` मान 1.5 रेखाओं को दर्शाता है। स्पष्ट मान निर्दिष्ट करते समय दोनों गुणधर्म सेट करें; केवल संख्यात्मक मान बदलने से स्पेसिंग नियम नहीं बदलता।

नीचे का उदाहरण समान समीकरण, संरेखण और फ़ॉन्ट सेटिंग्स के साथ पाँच प्रस्तुति सहेजता है। पहले तीन प्रीसेट हैं; अंतिम दो स्पष्ट मान दिखाते हैं।

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

एरे पंक्ति स्पेसिंग पैराग्राफ स्पेसिंग से अलग है। [setSpaceBefore](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setSpaceBefore-float-) और [setSpaceAfter](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setSpaceAfter-float-) कंटेनिंग पैराग्राफ के चारों ओर स्थान जोड़ते हैं, न कि एरे पंक्तियों के बीच। इसी तरह, [IMathParagraph.setJustification](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathparagraph/#setJustification-int-) पूरे गणितीय पैराग्राफ को क्षैतिज रूप से स्थित करता है; यह एरे की लंबवत संरेखण सेटिंग को बदलता नहीं है।

## **त्रिकोणमितीय फ़ंक्शन जोड़ें**

जब तर्क वर्तमान तत्व है और फ़ंक्शन नाम ज्ञात है, तब [asArgumentOfFunction](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#asArgumentOfFunction-com.aspose.slides.IMathElement-) का उपयोग करें।

![त्रिकोणमितीय फ़ंक्शन cos को 2x पर लागू किया गया है](powerpoint-math-equations_6.png)

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

इंडेक्स और पावर के लिये सबस्क्रिप्ट और सुपरसक्रिप्ट हेल्पर का उपयोग करें। जब इंडेक्स बेस के बाएँ पक्ष में दिखना चाहिए, तो [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#setSubSuperscriptOnTheLeft-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-) का प्रयोग करें।

![एक बड़े Y के बाएँ‑साइड सबस्क्रिप्ट 1 और सुपरसक्रिप्ट n के साथ](powerpoint-math-equations_9.png)

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

### **दाएँ‑साइड सबस्क्रिप्ट और सुपरसक्रिप्ट संरेखित करें**

जब दोनों स्क्रिप्ट एक ही बेस से जुड़ी हों, तो [MathRightSubSuperscriptElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathrightsubsuperscriptelement/) का प्रयोग करें। इसकी [setAlignScripts](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathrightsubsuperscriptelement/#setAlignScripts-boolean-) मेथड उनके क्षैतिज स्थान को नियंत्रित करती है: `false` (डिफ़ॉल्ट) उन्हें बेस की रूपरेखा के अनुसार रखती है, जबकि `true` दोनों स्क्रिप्ट को आपस में क्षैतिज रूप से संरेखित करती है।

यह उदाहरण दो समान संपादन योग्य अभिव्यक्तियों को बगल‑बगल रखता है। दोनों में गणितीय इटैलिक f (U+1D453), नीचे‑स्क्रिप्ट 1, ऊपर‑स्क्रिप्ट 2, और Cambria Math 72 पॉइंट है। ढलान वाला बेस PowerPoint में अंतर को स्पष्ट दिखाता है। उदाहरण चलाने से पहले Cambria Math स्थापित करें।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(900, 250, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    PortionFormat format = new PortionFormat();
    format.setFontHeight(72);
    format.setLatinFont(new FontData("Cambria Math"));

    for (int i = 0; i < 2; i++) {
        int left = 40 + i * 440;
        IAutoShape shape = slide.getShapes().addMathShape(left, 75, 380, 150);

        MathematicalText baseText = new MathematicalText("\uD835\uDC53", format);
        MathematicalText subscript = new MathematicalText("1", format);
        MathematicalText superscript = new MathematicalText("2", format);
        MathRightSubSuperscriptElement scripts = new MathRightSubSuperscriptElement(baseText, subscript, superscript);
        scripts.setAlignScripts(i == 1);

        MathPortion portion = (MathPortion) shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
        portion.getPortionFormat().setFontHeight(format.getFontHeight());
        portion.getPortionFormat().setLatinFont(format.getLatinFont());
        portion.getMathParagraph().add(new MathBlock(scripts));
    }

    presentation.save("aligned-scripts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![दो संपादन योग्य अभिव्यक्तियाँ जहाँ बाएँ पर setAlignScripts false है और दाएँ पर true है](aligned-scripts.png)

बाएँ पर, निचला स्क्रिप्ट बेस की रूपरेखा के अनुसार अधिक बाएँ शुरू होता है। दाएँ पर, दोनों स्क्रिप्ट एक‑दूसरे के साथ क्षैतिज रूप से संरेखित होते हैं।

## **डिलिमिटर जोड़ें**

एक अभिव्यक्ति को डिलिमिटर के भीतर रखने के लिये [enclose](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#enclose-char-char-) का प्रयोग करें। आप कई तत्वों वाली अभिव्यक्तियों के लिये एक विभाजक वर्ण भी सेट कर सकते हैं।

![एक डिलिमिटर अभिव्यक्ति जिसमें x, y और z को लंबवत बार से अलग किया गया है](powerpoint-math-equations_13.png)

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

### **डिलिमिटर के आकार और संरेखण**

[parentheses] को लंबे ऑपरेन्ड के चारों ओर बढ़ाने हेतु [setGrowToMatchOperandHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathdelimiter/#setGrowToMatchOperandHeight-boolean-) को `true` पास करें, या सामान्य आकार रखने हेतु `false` पास करें। [setDelimiterShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathdelimiter/#setDelimiterShape-int-) के साथ दो में से एक [MathDelimiterShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathdelimitershape/) मान चुनें। `Centered` पैरेंथिसिस को गणित अक्ष पर केंद्रित करता है, जो बराबर‐चिह्न के मध्य से गुजरता है। `Match` उन्हें संलग्न सामग्री के साथ संरेखित करता है। दोनों सेटिंग केवल डिलिमिटर को प्रभावित करती है; अंदर की अभिव्यक्ति समान रहती है।

उदाहरण में `x` के एक्सपोनेंट में एक भिन्न रखा गया है ताकि अभिव्यक्ति बेसलाइन से ऊपर अधिक विस्तारित हो। सभी चार समीकरण एक ही पैरेंथिसिस और फ़ॉन्ट सेटिंग्स उपयोग करते हैं।

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

PowerPoint में पंक्तियों की तुलना करके वृद्धि प्रभाव देखें। शीर्ष पंक्ति में पैरेंथिसिस एक्सपोनेंट को घेरता है और दोनों आकृतियों में समान दिखता है। निचली पंक्ति में वृद्धि बंद है। बाएँ (`Centered`) पैरेंथिसिस बराबर‑चिह्न के साथ संरेखित है, जबकि दाएँ (`Match`) अभिव्यक्ति के चारों ओर ऊँचा स्थित है।

![चार समीकरण PowerPoint में जहाँ डिलिमिटर वृद्धि ऊपर सक्षम है और नीचे निष्क्रिय, बाएँ `Centered` और दाएँ `Match`](delimiter-sizing.png)

## **बॉर्डर बॉक्स जोड़ें**

एक भिन्न पर [toBorderBox](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#toBorderBox--) कॉल करके पूरी अभिव्यत्ति को फ्रेम करें। लौटाया गया [IMathBorderBox](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathborderbox/) डिफ़ॉल्ट रूप से चारों पक्ष दिखाता है। व्यक्तिगत पक्षों को हटाने के लिये [setHideTop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathborderbox/#setHideTop-boolean-), [setHideBottom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathborderbox/#setHideBottom-boolean-), [setHideLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathborderbox/#setHideLeft-boolean-), और [setHideRight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathborderbox/#setHideRight-boolean-) का प्रयोग करें।

उदाहरण में एक ही भिन्न के छह कॉपी एक स्लाइड पर रखे गये हैं। रद्दीकरण दिखाने के लिये सभी चार पक्ष छिपाएँ और उठती विकर्ण (↗) के लिये [setStrikethroughBottomLeftToTopRight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathborderbox/#setStrikethroughBottomLeftToTopRight-boolean-) या गिरती विकर्ण (↘) के लिये [setStrikethroughTopLeftToBottomRight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathborderbox/#setStrikethroughTopLeftToBottomRight-boolean-) पास करें। आप किसी भी संयोजन में दृश्यमान पक्षों के साथ [setStrikethroughHorizontal](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathborderbox/#setStrikethroughHorizontal-boolean-) या [setStrikethroughVertical](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathborderbox/#setStrikethroughVertical-boolean-) का भी प्रयोग कर सकते हैं।

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

![छह संपादन योग्य भिन्न PowerPoint में। शीर्ष पंक्ति: पूर्ण बॉर्डर, नीचे व बाएँ पक्ष, उठती विकर्ण। निचली पंक्ति: गिरती विकर्ण, क्षैतिज स्ट्राइक, लंबवत स्ट्राइक पूर्ण बॉर्डर के साथ](border-box-fractions.png)

इस भिन्न पर, क्षैतिज स्ट्राइक भिन्न बार के ऊपर ओवरलैप करता है। लंबवत स्ट्राइक अंश तथा हर (numerator और denominator) दोनों को काटता है, जबकि आसपास का बॉर्डर दृश्यमान रहता है। ये रेखाएँ पूरी अभिव्यत्ति को सजाती हैं। साधारण टेक्स्ट स्ट्राइक‑थ्रू केवल टेक्स्ट रन के वर्णों पर लागू होता है। प्रस्तुति को PowerPoint में पुनः खोलने पर आप अंश और हर को स्वतंत्र रूप से संपादित कर सकते हैं।

## **फ़ैंटम तत्वों के साथ दृश्यता और लेआउट नियंत्रित करें**

एक अभिव्यक्ति को [MathPhantom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathphantom/) में घेरें ताकि उसकी दृश्यता और समीकरण में उसका योगदान स्वतंत्र रूप से नियंत्रित हो। [IMathPhantom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathphantom/) की मेथड्स निम्नलिखित को नियंत्रित करती हैं:

| Method | Effect |
| --- | --- |
| [setShow](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathphantom/#setShow-boolean-) | `false` पास करने से अभिव्यक्ति छिप जाती है। इसके आयाम लेआउट में योगदान देते रहते हैं जब तक कि नीचे की मेथड्स `true` न हों। |
| [setZeroWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathphantom/#setZeroWidth-boolean-) | अभिव्यक्ति की क्षैतिज चौड़ाई को शून्य मानें, जिससे पड़ोसी तत्व करीब आ सकते हैं। |
| [setZeroAsc](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathphantom/#setZeroAsc-boolean-) | उसके ऊपर‑उठान (baseline के ऊपर की ऊँचाई) को शून्य मानें। यह पड़ोसी तत्वों के ऊपर आरक्षित स्थान को कम कर सकता है। |
| [setZeroDesc](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathphantom/#setZeroDesc-boolean-) | उसके नीचे‑गिरावट (baseline के नीचे की गहराई) को शून्य मानें। यह भिन्न बार या अन्य सामग्री को नीचे की अभिव्यक्ति से करीब लाने में मदद करता है। |

baseline वह संदर्भ रेखा है जिस पर सामान्य गणितीय अक्षर स्थित होते हैं। सामग्री को छिपाने से उसके आयाम हटते नहीं हैं, और आयाम को शून्य करने से अभिव्यक्ति हटती नहीं है। मूल अभिव्यक्ति अभी भी [getBase](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathphantom/#getBase--) के द्वारा उपलब्ध है। इसे फिर से दिखाने के लिये [setShow](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathphantom/#setShow-boolean-) को `true` पास करें; आयाम सेटिंग्स अपरिवर्तित रहती हैं।

नीचे का उदाहरण पाँच बगल‑बगल विविधताएँ बनाता है: एक दृश्यमान भिन्न, एक छिपा हुआ भिन्न जो स्थान आरक्षित करता है, और तीन छिपे हुए भिन्न जहाँ एक आयाम को शून्य किया गया है। प्रत्येक विविधता समान परिधीय अभिव्यक्ति और Cambria Math 24 पॉइंट में है। सभी समीकरण आकार समान शीर्ष स्थिति से शुरू होते हैं, जो ग्रे गाइड द्वारा चिह्नित है। बाहरी भिन्न के अंश में फ़ैंटम रखने से लंबवत लेआउट परिवर्तन और स्पष्ट होते हैं।

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
    presentation.getSlideSize().setSize(1000, 180, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    String[] labels = { "Visible", "Hidden: reserves space", "Hidden: ZeroWidth", "Hidden: ZeroAsc", "Hidden: ZeroDesc" };

    IAutoShape guide = slide.getShapes().addAutoShape(ShapeType.Line, 10, 60, 980, 0);
    guide.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    guide.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.LTGRAY);

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

![PowerPoint में पाँच समीकरण जो एक दृश्यमान भिन्न, एक छिपा हुआ भिन्न जो स्थान रखता है, और ZeroWidth, ZeroAsc, या ZeroDesc सक्रिय वाले छिपे हुए भिन्नों की तुलना करते हैं](math-phantom.png)

## **शब्द समूह बनाएं**

[group](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#group-char-int-int-) का प्रयोग करके अभिव्यक्ति के ऊपर या नीचे एक समूहिंग वर्ण रखें। समूहित शब्दों को लेबल करने के लिये एक सीमा (limit) जोड़ें।

![एक अभिव्यक्ति x + y को समूहित किया गया है जिसमें नीचे लेबल 'any text' है](powerpoint-math-equations_15.png)

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

## **गणितीय तत्वों का स्वरूपित करें**

सिर्फ तब स्वरूपण हेल्पर का प्रयोग करें जब वे सूत्र को स्पष्ट बनाते हों। उदाहरण के लिये, [overbar](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#overbar--) एक तत्व के ऊपर एक रेखा रखता है।

![एक गणितीय अभिव्यक्ति ABC जिसके ऊपर overbar है](powerpoint-math-equations_14.png)

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

### **मौजूदा समीकरण में पाठ का स्वरूपण करें**

मौजूदा समीकरण में संपूर्ण पाठ को स्वरूपित करने के लिये, प्रत्येक गणितीय ब्लॉक के तत्व वृक्ष को ट्रवर्स करें। [IMathElement.getChildren](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#getChildren--) केवल तत्काल बच्चों को लौटाता है, इसलिए फ़्रैक्शन, स्क्रिप्ट, मूल आदि में भीतर के पाठ तक पहुँचने के लिये इसे पुनरावर्ती रूप से कॉल करें। मौजूदा तत्व के साथ-साथ उसके बच्चों को भी देखें ताकि जब वह [MathematicalText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathematicaltext/) हो तो उसे भी शामिल किया जा सके।

यह उदाहरण मानता है कि `input.pptx` में ऐसा समीकरण है जैसे `z = xᵢ / ∛y`, जहाँ भिन्न के अंश में सबस्क्रिप्ट और हर में मूल है। केवल ब्लॉक के शीर्ष‑स्तर के तत्वों को प्रोसेस करने से भिन्न के भीतर के पाठ छूट जाता। उदाहरण स्लाइड टेक्स्ट फ़्रेम में गणितीय भागों को खोजता है, उनके ब्लॉकों को [IMathPortion.getMathParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathportion/#getMathParagraph--) से एक्सेस करता है, और प्रत्येक टेक्स्ट तत्व के [getFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathematicaltext/#getFormat--) मेथड के साथ [setFontHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-) को 28 पॉइंट पर सेट करता है।

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

सहेजी गई प्रस्तुति प्रत्येक प्रोसेस किए गये समीकरण के सभी स्तरों पर अद्यतित फ़ॉन्ट आकार रखती है, जबकि उसके पाठ सामग्री और गणितीय संरचना को बरकरार रखती है।

## **त्वरित संदर्भ**

| Task | Main API |
| --- | --- |
| गणितीय पाठ बनाएं | [MathematicalText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathematicaltext/) |
| तत्व मिलाएं | [IMathElement.join](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) |
| भिन्न बनाएं | [IMathElement.divide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) |
| सुपर‑स्क्रिप्ट या सब‑स्क्रिप्ट जोड़ें | [setSuperscript](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/), [setSubscript](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) |
| फ़ंक्शन जोड़ें | [function](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/), [asArgumentOfFunction](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) |
| मूल जोड़ें | [IMathElement.radical](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) |
| सीमाएँ जोड़ें | [setLowerLimit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/), [setUpperLimit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) |
| बाएँ‑साइड स्क्रिप्ट जोड़ें | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) |
| समेशन और इंटीग्रल जोड़ें | [nary](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/), [integral](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) |
| मैट्रिक्स जोड़ें | [MathMatrix](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathmatrix/) |
| समीकरण एरे जोड़ें | [toMathArray](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) |
| डिलिमिटर जोड़ें | [enclose](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) |
| बार और बॉर्डर जोड़ें | [overbar](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/), [toBorderBox](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) |
| शब्द समूह बनाएं | [group](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) |

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं मौजूदा PowerPoint समीकरण को संपादित कर सकता हूँ?**

हां। प्रस्तुति खोलें, वह आकार खोजें जिसमें एक [MathPortion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathportion/) है, [getMathParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathportion/#getMathParagraph--) को कॉल करें, और उस पैराग्राफ में गणितीय ब्लॉकों को अपडेट करें।

**क्या समीकरण को संपादन योग्य PowerPoint गणित के रूप में सहेजा जाता है?**

हां। PPTX में सहेजते समय, Aspose.Slides समीकरण को संपादन योग्य Office math सामग्री के रूप में लिखता है।

**क्या मैं समीकरणों को LaTeX में निर्यात कर सकता हूँ?**

हां। समीकरण के [IMathParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathparagraph/) को उसके [IMathPortion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathportion/) से प्राप्त करें, और [IMathParagraph.toLatex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathparagraph/#toLatex--) को कॉल करके सीधे निर्यात करें। एक पूर्ण उदाहरण के लिये देखें [Export Math Equations from Presentations in Android via Java](/slides/hi/androidjava/exporting-math-equations/#export-math-equations-to-latex)।