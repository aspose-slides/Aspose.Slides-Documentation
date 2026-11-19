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
description: "Aspose.Slides for Java के साथ PowerPoint PPT और PPTX में गणितीय समीकरण डालें और संपादित करें, OMML का समर्थन, स्वरूपण नियंत्रण, और स्पष्ट Java कोड उदाहरण।"
---
## **अवलोकन**

PowerPoint समीकरणों को Office Math Markup Language (OMML) के रूप में संग्रहित करता है। Aspose.Slides for Java के साथ, आप प्रोग्रामेटिकली समान प्रकार की गणितीय सामग्री बना सकते हैं: भिन्न, मूल, फ़ंक्शन, सीमा, N-ary ऑपरेटर, मैट्रिक्स, ऐरे, और स्वरूपित गणित ब्लॉक।

PowerPoint में, उपयोगकर्ता सामान्यतः **Insert > Equation** से समीकरण जोड़ते हैं:

![PowerPoint Insert tab with the Equation command selected](powerpoint-math-equations_1.png)

परिणाम स्लाइड पर संपादन योग्य गणितीय पाठ है:

![A PowerPoint slide containing an editable math equation](powerpoint-math-equations_2.png)

Aspose.Slides उस गणितीय पाठ को तीन मुख्य वस्तुओं के माध्यम से बनाता है:

- एक गणितीय आकार, जिसे [addMathShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addMathShape-float-float-float-float-) द्वारा बनाया गया है, वह आकार है जिसमें समीकरण होता है।
- [MathPortion](https://reference.aspose.com/slides/java/com.aspose.slides/mathportion/) आकार के टेक्स्ट फ्रेम के भीतर गणितीय सामग्री संग्रहीत करता है।
- [MathParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/mathparagraph/) में एक या अधिक [MathBlock](https://reference.aspose.com/slides/java/com.aspose.slides/mathblock/) वस्तुएँ होती हैं।

नीचे के अधिकांश उदाहरण [MathematicalText](https://reference.aspose.com/slides/java/com.aspose.slides/mathematicaltext/) और [IMathElement](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/) की प्रवाहमान विधियों का उपयोग करते हैं ताकि कोड छोटा और पठनीय रहे।

[जावा में प्रस्तुतियों से गणितीय समीकरण निर्यात](/slides/hi/java/exporting-math-equations/)

## **समीकरण बनाएं**

यह उदाहरण [addMathShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addMathShape-float-float-float-float-) का उपयोग करके एक गणितीय आकार बनाता है और पायथागोरस प्रमेय जोड़ता है:

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

{{% alert color="info" title="Note" %}}
[addMathShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addMathShape-float-float-float-float-) एक आकार बनाता है जिसमें पहले से ही एक गणितीय पैराग्राफ शामिल होता है। पहले [MathPortion](https://reference.aspose.com/slides/java/com.aspose.slides/mathportion/) तक पहुँचें, [getMathParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/imathportion/#getMathParagraph--) को कॉल करें, और उसमें गणितीय ब्लॉक या तत्व जोड़ें।
{{% /alert %}}

### **गणितीय ब्लॉक संयोजित करें**

जब समीकरण के भाग स्वतंत्र रूप से [IMathBlock](https://reference.aspose.com/slides/java/com.aspose.slides/imathblock/) वस्तुएँ के रूप में बनाए जाते हैं, तो उन्हें संयोजित करने के लिए [joinBlock](https://reference.aspose.com/slides/java/com.aspose.slides/imathblock/#joinBlock-com.aspose.slides.IMathBlock-) का उपयोग करें। उदाहरण बाएँ ब्लॉक में `c² =` और दाएँ ब्लॉक में `a² + b²` बनाता है। [setSuperscript](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#setSuperscript-java.lang.String-) तीनों घातों के लिए संपादन योग्य गणितीय सुपरस्क्रिप्ट बनाता है।

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

[joinBlock](https://reference.aspose.com/slides/java/com.aspose.slides/imathblock/#joinBlock-com.aspose.slides.IMathBlock-) `leftBlock` को स्वयं लौटाता है, जिसमें अब क्रम में दोनों भाग होते हैं, और `rightBlock` को खाली छोड़ देता है। संयोजित ब्लॉक को केवल एक बार [IMathParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/imathparagraph/) में जोड़ें। `equation.pptx` को पुनः खोलने के बाद, पैराग्राफ में `c² = a² + b²` को दर्शाता एक ब्लॉक होता है, जिसमें तीनों घात गणितीय सुपरस्क्रिप्ट के रूप में संरक्षित रहते हैं।

[add](https://reference.aspose.com/slides/java/com.aspose.slides/imathelementcollection/#add-com.aspose.slides.IMathElement-) को `leftBlock.add(rightBlock)` के रूप में कॉल करने से एक ब्लॉक को सीधे दूसरे के भीतर नेस्ट करने का प्रयास होता है और यह `InvalidOperationException` उत्पन्न करता है।

## **भिन्न जोड़ें**

भिन्न बनाने के लिए [divide](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#divide-com.aspose.slides.IMathElement-) का उपयोग करें। आप [MathFractionTypes](https://reference.aspose.com/slides/java/com.aspose.slides/mathfractiontypes/) के साथ एक भिन्न शैली चुन सकते हैं।

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

स्टैक्ड (बढ़ा हुआ) भिन्न के लिए, [MathFractionTypes.Bar](https://reference.aspose.com/slides/java/com.aspose.slides/mathfractiontypes/#Bar) का उपयोग करें:

```java
import com.aspose.slides.*;

IMathFraction stackedFraction = new MathematicalText("x + 1").divide("y - 1", MathFractionTypes.Bar);
```

## **रैडिकल जोड़ें**

[radical](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#radical-com.aspose.slides.IMathElement-) का उपयोग करके वर्गमूल, घनमूल या अन्य मूल बनाएं। वर्तमान तत्व आधार बन जाता है, और तर्क डिग्री बनता है।

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

### **वर्गमूल की डिग्री दिखाएँ या छुपाएँ**

वर्गमूल स्पष्ट 2 दिखा सकता है या पारंपरिक √x संकेतन का उपयोग कर सकता है। [IMathRadical](https://reference.aspose.com/slides/java/com.aspose.slides/imathradical/) की [setHideDegree](https://reference.aspose.com/slides/java/com.aspose.slides/imathradical/#setHideDegree-boolean-) विधि निर्धारित करती है कि कौन सा रूप प्रदर्शित हो। दोनों रूप संपादन योग्य समीकरण में डिग्री 2 और radicand x को बनाए रखते हैं।

![The same square root with the degree visible on the left and hidden on the right](square-root-degree.png)

उदाहरण एक ही वर्गमूल को दो बार सहेजता है। `visible-degree.pptx` में, 2 दिखाई देता है। `hidden-degree.pptx` में, वह छुपा रहता है।

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

`sin(x)`, `log(x)` या कस्टम फ़ंक्शन नाम जैसे फ़ंक्शन के लिए [asArgumentOfFunction](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#asArgumentOfFunction-com.aspose.slides.IMathElement-) या [function](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#function-com.aspose.slides.IMathElement-) का उपयोग करें। सीमाओं के लिए, `lim` को एक [MathLimit](https://reference.aspose.com/slides/java/com.aspose.slides/mathlimit/) में रखें या [setLowerLimit](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#setLowerLimit-com.aspose.slides.IMathElement-) का उपयोग करें।

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

समेकन, संघ, प्रतिच्छेदन और अन्य बड़े ऑपरेटरों के लिए [nary](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#nary-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-) का उपयोग करें। इंटीग्रल के लिए [integral](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#integral-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-) का उपयोग करें। दोनों विधियों से आप निचली और ऊपरी सीमाएँ निर्धारित कर सकते हैं।

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

N-ary ऑपरेटर बड़े ऑपरेटरों के लिए होते हैं जिनमें वैकल्पिक सीमाएँ हो सकती हैं। सरल ऑपरेटर जैसे `+`, `-`, और `=` आम तौर पर [MathematicalText](https://reference.aspose.com/slides/java/com.aspose.slides/mathematicaltext/) के रूप में जोड़े जाते हैं और अभिव्यक्ति में सम्मिलित होते हैं।

इंटीग्रल के लिए, [integral](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#integral-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-) का उपयोग करें:

```java
import com.aspose.slides.*;

IMathBlock integralBase = new MathematicalText("x").join(new MathematicalText("dx").toBox());
IMathNaryOperator integral = integralBase.integral(MathIntegralTypes.Simple, "0", "1");
```

## **मैट्रिक्स जोड़ें**

पंक्तियों और स्तंभों के लिए [MathMatrix](https://reference.aspose.com/slides/java/com.aspose.slides/mathmatrix/) का उपयोग करें। मैट्रिक्स में डिफ़ॉल्ट रूप से कोष्ठक नहीं होते, इसलिए जब आपको कोष्ठक, ब्रैकेट या कर्ली ब्रैकेट चाहिए तब मैट्रिक्स को इनके साथ घेरें।

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

### **मौजूदा मैट्रिक्स संपादित करें**

मान लें कि एक रैखिक बीजगणित पाठ `matrix.pptx` में कोएफ़िशिएंट मैट्रिक्स से शुरू होता है, जो पिछले उदाहरण द्वारा सहेजा गया है। अगले अभ्यास के लिए, पहले समीकरण को बनाए रखें, दूसरे को दो नए समीकरणों से बदलें, और चर सेट को संशोधित करें। मौजूदा मैट्रिक्स को [IMathMatrix](https://reference.aspose.com/slides/java/com.aspose.slides/imathmatrix/) के माध्यम से खोलें ताकि अभी भी लागू कोएफ़िशिएंट्स को बरकरार रखा जा सके।

![Original two-row coefficient matrix with entries 1, x, and an empty cell in the first row and x, 2, and y in the second](matrix-before-edit.png)

पंक्ति और स्तंभ सूचकांक शून्य से शुरू होते हैं और प्रत्येक कॉल के समय मैट्रिक्स को दर्शाते हैं। सूचकांक 1 से पहले एक पंक्ति सम्मिलित करने से मूल दूसरी पंक्ति सूचकांक 2 पर चली जाएगी। सूचकांक 2 के बाद सम्मिलित करने से एक पंक्ति जोड़ दी जाएगी। पंक्ति 2 को हटाने से मूल दूसरी समीकरण हट जाता है और जोड़ी गई पंक्ति एक स्थिति ऊपर आ जाती है। स्तंभ भी इसी प्रकार शिफ्ट होते हैं।

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

    // नई कोशिकाएँ प्रारंभ में null होती हैं। पहले शून्य नहीं वाले गुणांक सेट करें।
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

[setColumnAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/imathmatrix/#setColumnAlignment-int-int-) पहला स्तम्भ बाएँ संरेखित करता है। [setColumnsAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/imathmatrix/#setColumnsAlignment-int-long-int-) एक साथ तीन स्तम्भों को दाएँ संरेखित करता है, सूचकांक 1 से शुरू। `updated-matrix.pptx` में, मैट्रिक्स में तीन समीकरण और चार चर हैं। मूल पहली पंक्ति के कोएफ़िशिएंट `1` और `x` अब पहले और तीसरे स्तम्भों में दिखाए जाते हैं।

![Updated three-row matrix showing the rows 1, 0, x, 0; 12, 1, 0, 0; and 0, 0, 10, 1](matrix-after-edit.png)

## **समीकरण एरे जोड़ें**

[toMathArray](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#toMathArray--) का उपयोग तब करें जब आपको संरेखित समीकरण या अभिव्यक्तियों का लंबवत स्टैक चाहिए।

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

### **एरे को आसपास के तत्वों के साथ संरेखित करें**

[setBaseJustification](https://reference.aspose.com/slides/java/com.aspose.slides/imatharray/#setBaseJustification-int-) एरे की वैरिटिकल संरेखण को उसके बगल में स्थित गणितीय तत्वों के सापेक्ष नियंत्रित करता है। नीचे का उदाहरण पहली पंक्ति, एरे के केंद्र, और अंतिम पंक्ति के साथ संरेखण की तुलना करता है।

निम्न उदाहरण तीन समान एरे बनाता है, प्रत्येक में तीन पंक्तियाँ और पड़ोसी तत्व `A=` तथा `=B` होते हैं। सभी गणितीय पाठ Cambria Math 24 पॉइंट में उपयोग करता है। केवल एरे का संरेखण बदलता है।

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

नीचे की तुलना PowerPoint में सहेजे गए प्रस्तुति को दिखाती है। `A=` और `=B` के स्थान को प्रत्येक एरे के बगल में देखें।

![Equation arrays in PowerPoint with Top, Center, and Bottom alignment and identical neighboring elements](equation-array-alignment.png)

### **पंक्ति स्पेसिंग कॉन्फ़िगर करें**

[setRowSpacingRule](https://reference.aspose.com/slides/java/com.aspose.slides/imatharray/#setRowSpacingRule-int-) एरे के भीतर पंक्तियों के लिए स्पेसिंग नियम चुनता है। [setRowSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/imatharray/#setRowSpacing-long-) स्पष्ट स्पेसिंग नियम के लिए संख्यात्मक मान देता है और प्रीसेट नियमों द्वारा अनदेखा किया जाता है।

सटीक स्पेसिंग के लिए, मान पॉइंट में मापा जाता है। अनुपातिक स्पेसिंग के लिए, यह आधी लाइनों में मापा जाता है: उदाहरण में मान `3` 1.5 लाइनों को दर्शाता है। स्पष्ट मान निर्दिष्ट करने पर दोनों गुणधर्म सेट करें; केवल संख्यात्मक मान बदलने से स्पेसिंग नियम नहीं चुना जाता।

नीचे का उदाहरण समान समीकरण, संरेखण और फ़ॉन्ट सेटिंग के साथ पाँच प्रस्तुतियों को सहेजता है। पहले तीन प्रीसेट उपयोग करते हैं; अंतिम दो स्पष्ट मान दिखाते हैं।

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

एरे पंक्ति स्पेसिंग पैराग्राफ स्पेसिंग से अलग है। [setSpaceBefore](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setSpaceBefore-float-) और [setSpaceAfter](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setSpaceAfter-float-) सम्पूर्ण पैराग्राफ के चारों ओर स्थान जोड़ते हैं, न कि एरे पंक्तियों के बीच। इसी तरह, [IMathParagraph.setJustification](https://reference.aspose.com/slides/java/com.aspose.slides/imathparagraph/#setJustification-int-) पूरी गणितीय पैराग्राफ को क्षैतिज रूप से स्थित करता है; यह एरे की वैरिटिकल संरेखण सेटिंग को बदलता नहीं है।

## **त्रिकोणमितीय फ़ंक्शन जोड़ें**

जब तर्क वर्तमान तत्व हो और फ़ंक्शन नाम ज्ञात हो, तब [asArgumentOfFunction](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#asArgumentOfFunction-com.aspose.slides.IMathElement-) का उपयोग करें।

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

सूचकांक और घात के लिए सबस्क्रिप्ट और सुपरस्क्रिप्ट हेल्पर का उपयोग करें। जब सूचकांकों को बेस के बाएँ पक्ष में दिखाना हो, तब [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#setSubSuperscriptOnTheLeft-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-) का उपयोग करें।

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

## **डिलिमीटर जोड़ें**

एक अभिव्यक्ति को डिलिमीटर के भीतर रखने के लिए [enclose](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#enclose-char-char-) का उपयोग करें। आप कई तत्वों वाली डिलिमीटर अभिव्यक्तियों के लिए विभाजक अक्षर भी सेट कर सकते हैं।

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

### **डिलिमीटर का आकार और संरेखण**

[setGrowToMatchOperandHeight](https://reference.aspose.com/slides/java/com.aspose.slides/imathdelimiter/#setGrowToMatchOperandHeight-boolean-) को `true` पास करें जिससे कोष्ठक लंबी ऑपरेण्ड के चारों ओर बढ़ें, या `false` पास करने से उनका सामान्य आकार बना रहे। दो [MathDelimiterShape](https://reference.aspose.com/slides/java/com.aspose.slides/mathdelimitershape/) मानों में से किसी एक के साथ [setDelimiterShape](https://reference.aspose.com/slides/java/com.aspose.slides/imathdelimiter/#setDelimiterShape-int-) का उपयोग करें। `Centered` कोष्ठकों को गणितीय अक्ष पर केंद्रित करता है, जो बराबर संकेत के मध्य से गुजरता है। `Match` उन्हें संलग्न सामग्री के साथ संरेखित करता है। दोनों सेटिंग्स केवल डिलिमीटर को प्रभावित करती हैं। अंदर की अभिव्यक्ति वही रहती है।

उदाहरण में `x` के एक्सपोनेंट में एक भिन्न रखा गया है जिससे अभिव्यक्ति बेसलाइन के ऊपर अधिक विस्तृत होती है बनिस्पत नीचे। सभी चार समीकरण समान कोष्ठक और फ़ॉन्ट सेटिंग्स का उपयोग करते हैं।

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

PowerPoint में, पंक्तियों की तुलना करके वृद्धि का प्रभाव देखें। शीर्ष पंक्ति में, कोष्ठक एक्सपोनेंट को घेरने के लिए बढ़ते हैं और दोनों आकार समान दिखते हैं। नीचे की पंक्ति में वृद्धि बंद है। बाएँ पर छोटे कोष्ठक (`Centered`) बराबर संकेत के साथ संरेखित होते हैं, जबकि दाएँ (`Match`) अभिव्यक्ति के ऊपर उच्च होते हैं।

![Four equations in PowerPoint with delimiter growth enabled above and disabled below, and Centered on the left and Match on the right](delimiter-sizing.png)

## **बॉर्डर बॉक्स जोड़ें**

भिन्न पर [toBorderBox](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#toBorderBox--) को कॉल करें ताकि पूरी अभिव्यक्ति के चारों ओर बॉर्डर बॉक्स बन सके। लौटाए गए [IMathBorderBox](https://reference.aspose.com/slides/java/com.aspose.slides/imathborderbox/) में डिफ़ॉल्ट रूप से चारों पक्ष दिखाए जाते हैं। व्यक्तिगत पक्ष हटाने के लिए [setHideTop](https://reference.aspose.com/slides/java/com.aspose.slides/imathborderbox/#setHideTop-boolean-), [setHideBottom](https://reference.aspose.com/slides/java/com.aspose.slides/imathborderbox/#setHideBottom-boolean-), [setHideLeft](https://reference.aspose.com/slides/java/com.aspose.slides/imathborderbox/#setHideLeft-boolean-), और [setHideRight](https://reference.aspose.com/slides/java/com.aspose.slides/imathborderbox/#setHideRight-boolean-) का उपयोग करें।

उदाहरण में एक स्लाइड पर समान भिन्न की छह प्रतियां रखी गई हैं। रद्दीकरण दिखाने के लिए, सभी चार पक्षों को छुपाएँ और एक बढ़ती विकर्ण (↗) के लिए [setStrikethroughBottomLeftToTopRight](https://reference.aspose.com/slides/java/com.aspose.slides/imathborderbox/#setStrikethroughBottomLeftToTopRight-boolean-) को `true` पास करें या गिरती विकर्ण (↘) के लिए [setStrikethroughTopLeftToBottomRight](https://reference.aspose.com/slides/java/com.aspose.slides/imathborderbox/#setStrikethroughTopLeftToBottomRight-boolean-) को `true` पास करें। आप किसी भी दृश्यमान पक्षों के संयोजन के साथ [setStrikethroughHorizontal](https://reference.aspose.com/slides/java/com.aspose.slides/imathborderbox/#setStrikethroughHorizontal-boolean-) या [setStrikethroughVertical](https://reference.aspose.com/slides/java/com.aspose.slides/imathborderbox/#setStrikethroughVertical-boolean-) का भी उपयोग कर सकते हैं।

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

इस भिन्न पर, क्षैतिज स्ट्राइक फ्रैक्शन बार के ऊपर ओवरलैप करता है। लंबवत स्ट्राइक अंश और हर दोनों को पार करता है जबकि बाउंडर दृश्यमान रहता है। ये रेखाएँ पूरी अभिव्यक्ति को सजाती हैं। सामान्य पाठ स्ट्राइकथ्रू व्यक्तिगत अक्षरों पर लागू होता है। प्रस्तुति को PowerPoint में पुनः खोलने के बाद, आप अभी भी अंश और हर को स्वतंत्र रूप से संपादित कर सकते हैं।

## **Phantom तत्वों के साथ दृश्यता और लेआउट नियंत्रित करें**

[MathPhantom](https://reference.aspose.com/slides/java/com.aspose.slides/mathphantom/) में अभिव्यक्ति को लपेटें ताकि उसकी दृश्यता और समीकरण में इस द्वारा योगदानित स्थान को स्वतंत्र रूप से नियंत्रित किया जा सके। [IMathPhantom](https://reference.aspose.com/slides/java/com.aspose.slides/imathphantom/) की विधियां निम्नलिखित को नियंत्रित करती हैं:

| विधि | प्रभाव |
| --- | --- |
| [setShow](https://reference.aspose.com/slides/java/com.aspose.slides/imathphantom/#setShow-boolean-) | `false` पास करके अभिव्यक्ति को छुपाएँ। इसके आयाम अभी भी लेआउट में योगदान देते हैं जब तक नीचे की संबंधित विधियां `true` न हों। |
| [setZeroWidth](https://reference.aspose.com/slides/java/com.aspose.slides/imathphantom/#setZeroWidth-boolean-) | अभिव्यक्ति की क्षैतिज चौड़ाई को शून्य मानें, जिससे पड़ोसी तत्व करीब आ सकें। |
| [setZeroAsc](https://reference.aspose.com/slides/java/com.aspose.slides/imathphantom/#setZeroAsc-boolean-) | अभिव्यक्ति के एसेंट, अर्थात बेसलाइन के ऊपर की ऊँचाई को शून्य मानें। इससे पड़ोसी तत्वों के ऊपर आरक्षित स्थान घट सकता है। |
| [setZeroDesc](https://reference.aspose.com/slides/java/com.aspose.slides/imathphantom/#setZeroDesc-boolean-) | अभिव्यक्ति के डिसेंट, अर्थात बेसलाइन के नीचे की गहराई को शून्य मानें। इससे फ्रैक्शन बार या अन्य सामग्री नीचे के अभिव्यक्ति के पास करीब आ सकता है। |

बेसलाइन वह संदर्भ रेखा है जिस पर सामान्य गणितीय अक्षर स्थित होते हैं। सामग्री को छुपाने से उसके आयाम हटते नहीं हैं, और आयाम को शून्य मानने से अभिव्यक्ति हटती नहीं है। निहित अभिव्यक्ति [getBase](https://reference.aspose.com/slides/java/com.aspose.slides/imathphantom/#getBase--) के माध्यम से उपलब्ध रहती है। [setShow](https://reference.aspose.com/slides/java/com.aspose.slides/imathphantom/#setShow-boolean-) को `true` पास करके इसे फिर से दिखाएँ; आयाम सेटिंग्स अपरिवर्तित रहेंगे।

नीचे का उदाहरण पाँच साइड- बाय-साइड वैरिएंट बनाता है: एक दृश्यमान भिन्न, एक छुपा भिन्न जो स्थान आरक्षित करता है, और तीन छुपे भिन्न जिनमें से एक आयाम शून्य सेट है। प्रत्येक वैरिएंट समान आसपास की अभिव्यक्ति और Cambria Math 24 पॉइंट पर उपयोग करता है। सभी समीकरण आकृतियों की शीर्ष स्थिति समान है, जो ग्रे गाइड द्वारा चिह्नित है। बाहरी भिन्न के अंश में फ़ैंटम रखने से लंबवत लेआउट परिवर्तन देखना आसान हो जाता है।

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

![Five equations in PowerPoint comparing a visible fraction, a hidden fraction that reserves space, and hidden fractions with ZeroWidth, ZeroAsc, or ZeroDesc enabled](math-phantom.png)

## **टर्म समूहित करें**

[group](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#group-char-int-int-) का उपयोग करके अभिव्यक्ति के ऊपर या नीचे एक समूहित अक्षर रखें। समूहित टर्म को लेबल करने के लिए एक सीमा जोड़ें।

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

## **गणितीय तत्वों का स्वरूप**

फ़ॉर्मेटिंग हेल्पर का उपयोग केवल तब करें जब वे सूत्र को स्पष्ट करें। उदाहरण के लिए, [overbar](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#overbar--) गणितीय तत्व के ऊपर एक बार रखता है।

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

### **मौजूदा समीकरण में पाठ को स्वरूपित करें**

मौजूदा समीकरण में पूरे पाठ को स्वरूपित करने के लिए, प्रत्येक गणितीय ब्लॉक के तत्व वृक्ष को पार करें। [IMathElement.getChildren](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#getChildren--) केवल तत्काल बच्चों को लौटाता है, इसलिए भिन्‍न, स्क्रिप्ट, रैडिकल और अन्य नेस्टेड संरचनाओं के भीतर पाठ तक पहुँचने के लिए इसे पुनरावर्ती रूप से कॉल करें। जब वर्तमान तत्व [MathematicalText](https://reference.aspose.com/slides/java/com.aspose.slides/mathematicaltext/) हो तो उसे भी शामिल करने के लिए वर्तमान तत्व और उसके बच्चों दोनों की जाँच करें।

यह उदाहरण मानता है कि `input.pptx` में `z = xᵢ / ∛y` जैसा समीकरण है, जहाँ भिन्न के अंश में सबस्क्रिप्ट और हर में रैडिकल है। केवल ब्लॉक के शीर्ष-स्तर तत्वों को प्रोसेस करने से भिन्न के भीतर का पाठ छूट जाएगा। उदाहरण स्लाइड टेक्स्ट फ्रेम में गणितीय भागों को खोजता है, उनके ब्लॉकों को [IMathPortion.getMathParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/imathportion/#getMathParagraph--) के माध्यम से एक्सेस करता है, और प्रत्येक टेक्स्ट तत्व के [getFormat](https://reference.aspose.com/slides/java/com.aspose.slides/mathematicaltext/#getFormat--) के माध्यम से फ़ॉन्ट आकार को 28 पॉइंट सेट करने के लिए [setFontHeight](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/#setFontHeight-float-) का उपयोग करता है।

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

सहेजा गया प्रस्तुतीकरण प्रत्येक प्रोसेस किए गए समीकरण के हर स्तर पर अद्यतन पाठ स्वरूपण रखता है, जबकि उसकी पाठ सामग्री और गणितीय संरचना को बनाए रखता है।

## **त्वरित संदर्भ**

| कार्य | मुख्य API |
| --- | --- |
| गणितीय पाठ बनाएं | [MathematicalText](https://reference.aspose.com/slides/java/com.aspose.slides/mathematicaltext/) |
| तत्वों को संयोजित करें | [IMathElement.join](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#join-com.aspose.slides.IMathElement-) |
| भिन्न बनाएं | [IMathElement.divide](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#divide-com.aspose.slides.IMathElement-) |
| सुपरस्क्रिप्ट या सबस्क्रिप्ट जोड़ें | [setSuperscript](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#setSuperscript-com.aspose.slides.IMathElement-), [setSubscript](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#setSubscript-com.aspose.slides.IMathElement-) |
| फ़ंक्शन जोड़ें | [function](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#function-com.aspose.slides.IMathElement-), [asArgumentOfFunction](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#asArgumentOfFunction-com.aspose.slides.IMathElement-) |
| रैडिकल जोड़ें | [IMathElement.radical](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#radical-com.aspose.slides.IMathElement-) |
| सीमा जोड़ें | [setLowerLimit](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#setLowerLimit-com.aspose.slides.IMathElement-), [setUpperLimit](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#setUpperLimit-com.aspose.slides.IMathElement-) |
| बाएँ पक्ष के स्क्रिप्ट जोड़ें | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#setSubSuperscriptOnTheLeft-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-) |
| समाकलन और इंटीग्रल जोड़ें | [nary](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#nary-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-), [integral](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#integral-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-) |
| मैट्रिक्स जोड़ें | [MathMatrix](https://reference.aspose.com/slides/java/com.aspose.slides/mathmatrix/) |
| समीकरण एरे जोड़ें | [toMathArray](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#toMathArray--) |
| डिलिमीटर जोड़ें | [enclose](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#enclose-char-char-) |
| बार और बॉर्डर जोड़ें | [overbar](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#overbar--), [toBorderBox](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#toBorderBox--) |
| टर्म समूहित करें | [group](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#group-char-int-int-) |

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं मौजूदा PowerPoint समीकरण को संपादित कर सकता हूँ?**

हाँ। प्रस्तुति खोलें, उस आकार को खोजें जिसमें [MathPortion](https://reference.aspose.com/slides/java/com.aspose.slides/mathportion/) हो, [getMathParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/imathportion/#getMathParagraph--) को कॉल करें, और उस पैराग्राफ में गणितीय ब्लॉक को अपडेट करें।

**क्या समीकरण संपादन योग्य PowerPoint गणित के रूप में सहेजे जाते हैं?**

हाँ। जब आप PPTX के रूप में सहेजते हैं, Aspose.Slides समीकरण को संपादन योग्य Office गणित सामग्री के रूप में लिखता है।

**क्या मैं समीकरणों को LaTeX में निर्यात कर सकता हूँ?**

हाँ। समीकरण के [IMathParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/imathparagraph/) को उसके [IMathPortion](https://reference.aspose.com/slides/java/com.aspose.slides/imathportion/) से प्राप्त करें, और [IMathParagraph.toLatex](https://reference.aspose.com/slides/java/com.aspose.slides/imathparagraph/#toLatex--) को कॉल करके सीधे निर्यात करें। पूर्ण उदाहरण के लिए, देखें [जावा में प्रस्तुतियों से गणितीय समीकरण निर्यात](/slides/hi/java/exporting-math-equations/#export-math-equations-to-latex).