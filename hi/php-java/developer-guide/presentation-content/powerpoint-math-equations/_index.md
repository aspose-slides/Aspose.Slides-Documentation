---
title: PHP में PowerPoint प्रस्तुतियों के लिए गणितीय समीकरण जोड़ें
linktitle: PowerPoint गणितीय समीकरण
type: docs
weight: 80
url: /hi/php-java/powerpoint-math-equations/
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
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java का उपयोग करके PowerPoint PPT और PPTX में गणितीय समीकरण डालें और संपादित करें, OMML समर्थन, स्वरूपण नियंत्रण और स्पष्ट PHP कोड उदाहरण प्रदान करता है।"
---
## **अवलोकन**

PowerPoint समीकरणों को Office Math Markup Language (OMML) के रूप में संग्रहीत करता है। Aspose.Slides for PHP via Java के साथ, आप प्रोग्रामेटिक रूप से वही प्रकार की गणितीय सामग्री बना सकते हैं: भिन्न, मूल, फ़ंक्शन, सीमा, N‑ary ऑपरेटर, मैट्रिक्स, ऐरे, और स्वरूपित गणित ब्लॉक।

PowerPoint में, उपयोगकर्ता सामान्यतः **Insert > Equation** से समीकरण जोड़ते हैं:

![PowerPoint Insert टैब जिसमें Equation कमांड चयनित है](powerpoint-math-equations_1.png)

परिणाम स्लाइड पर संपादन योग्य गणितीय पाठ होता है:

![एक PowerPoint स्लाइड जिसमें एक संपादन योग्य गणितीय समीकरण है](powerpoint-math-equations_2.png)

Aspose.Slides इस गणितीय पाठ को तीन मुख्य वस्तुओं के माध्यम से बनाता है:

- एक गणितीय आकार, जिसे [addMathShape](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addMathShape) से बनाया जाता है, वह आकार है जो समीकरण को रखता है।
- [MathPortion](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/) आकार के टेक्स्ट फ्रेम के भीतर गणितीय सामग्री संग्रहीत करता है।
- [MathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathparagraph/) एक या अधिक [MathBlock](https://reference.aspose.com/slides/php-java/aspose.slides/mathblock/) वस्तुओं को रखता है।

नीचे के अधिकांश उदाहरण [MathematicalText](https://reference.aspose.com/slides/php-java/aspose.slides/mathematicaltext/) और [MathElementBase](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) के फ़्लुएंट मेथड्स का उपयोग कोड को संक्षिप्त और पठनीय रखने के लिए करते हैं।

MathML निर्यात परिदृश्यों के लिए देखें [Export Math Equations from Presentations in PHP via Java](/slides/hi/php-java/exporting-math-equations/)।

## **एक समीकरण बनाएँ**

यह उदाहरण [addMathShape](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addMathShape) का उपयोग कर एक गणितीय आकार बनाता है और पायथागोरस सिद्धान्त जोड़ता है:

![समीकरण c² = a² + b²](powerpoint-math-equations_3.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 120);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $equation = (new MathematicalText("c"))
        - >setSuperscript("2")
        - >join("=")
        - >join((new MathematicalText("a"))->setSuperscript("2"))
        - >join("+")
        - >join((new MathematicalText("b"))->setSuperscript("2"));

    $mathParagraph->add($equation);

    $presentation->save("pythagorean-theorem.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

{{% alert color="info" title="ध्यान दें" %}}

[addMathShape](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addMathShape) एक ऐसा आकार बनाता है जिसमें पहले से ही एक गणितीय अनुच्छेद सम्मिलित होता है। पहले [MathPortion](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/) तक पहुंचें, [getMathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/#getMathParagraph) को कॉल करें, और उस पर गणितीय ब्लॉक या तत्व जोड़ें।

{{% /alert %}}

## **भिन्न जोड़ें**

[divide](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#divide) का उपयोग कर एक भिन्न बनाएं। आप [MathFractionTypes](https://reference.aspose.com/slides/php-java/aspose.slides/mathfractiontypes/) के साथ भिन्न शैली चुन सकते हैं।

![एक झुका हुआ गणितीय भिन्न जिसमें एक को x से विभाजित दिखाया गया है](powerpoint-math-equations_4.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 100);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $fraction = (new MathematicalText("1"))
        - >divide("x", MathFractionTypes::Skewed);

    $mathParagraph->add(new MathBlock($fraction));

    $presentation->save("fraction.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

स्टैक्ड भिन्न के लिए, [MathFractionTypes::Bar](https://reference.aspose.com/slides/php-java/aspose.slides/mathfractiontypes/#Bar) का उपयोग करें:

```php
$stackedFraction = (new MathematicalText("x + 1"))->divide("y - 1", MathFractionTypes::Bar);
```

## **मूल जोड़ें**

[radical](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#radical) का उपयोग कर वर्गमूल, घनमूल या अन्य मूल बनाएं। वर्तमान तत्व आधार बन जाता है, और तर्क घातांक बन जाता है।

![एक n‑वाँ मूल अभिव्यक्ति जिसमें x मूल चिह्न के नीचे है](powerpoint-math-equations_5.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 100);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $radical = (new MathematicalText("x"))
        - >radical("n");

    $mathParagraph->add(new MathBlock($radical));

    $presentation->save("radical.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **फ़ंक्शन और सीमाएँ जोड़ें**

फ़ंक्शन जैसे `sin(x)`, `log(x)` या कस्टम फ़ंक्शन नामों के लिए [asArgumentOfFunction](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#asArgumentOfFunction) या [function](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#function) का उपयोग करें। सीमाओं के लिए, `lim` को एक [MathLimit](https://reference.aspose.com/slides/php-java/aspose.slides/mathlimit/) में रखें या [setLowerLimit](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#setLowerLimit) का उपयोग करें।

![x की सीमा जब x अनंत की ओर जाता है](powerpoint-math-equations_8.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 100);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $limit = (new MathematicalText("lim"))
        - >setLowerLimit("x\u{2192}\u{221E}")
        - >function("x");

    $mathParagraph->add(new MathBlock($limit));

    $presentation->save("functions-and-limits.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

कस्टम फ़ंक्शन नाम के लिए, फ़ंक्शन नाम को वर्तमान तत्व बनाएं और उसके तर्क के साथ [function](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#function) को कॉल करें:

```php
$customFunction = (new MathematicalText("f"))->function("x + 1");
```

## **N‑ary ऑपरेटर और इंटीग्रल जोड़ें**

समिकरण, संघ, प्रतिच्छेद और अन्य बड़े ऑपरेटरों के लिए [nary](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#nary) का उपयोग करें। इंटीग्रल के लिए [integral](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#integral) का उपयोग करें। दोनों मेथड्स आपको निचली और ऊपरी सीमाएँ सेट करने की अनुमति देते हैं।

![निचली और ऊपरी सीमाओं के साथ एक समिकरण](powerpoint-math-equations_7.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 120);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $summationBase = (new MathematicalText("x"))
        - >setSuperscript("k")
        - >join((new MathematicalText("a"))->setSuperscript("n-k"));

    $summation = $summationBase->nary(MathNaryOperatorTypes::Summation, "k=0", "n");

    $mathParagraph->add(new MathBlock($summation));

    $presentation->save("nary-operators.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

N‑ary ऑपरेटर बड़े ऑपरेटर होते हैं जिनमें वैकल्पिक सीमाएँ हो सकती हैं। सरल ऑपरेटर जैसे `+`, `-`, और `=` आमतौर पर [MathematicalText](https://reference.aspose.com/slides/php-java/aspose.slides/mathematicaltext/) के रूप में जोड़े जाते हैं और अभिव्यक्ति में सम्मिलित किए जाते हैं।

इंटीग्रल के लिए, [integral](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#integral) का उपयोग करें:

```php
$integralBase = (new MathematicalText("x"))->join((new MathematicalText("dx"))->toBox());
$integral = $integralBase->integral(MathIntegralTypes::Simple, "0", "1");
```

## **मैट्रिक्स जोड़ें**

पंक्तियों और स्तम्भों के लिए [MathMatrix](https://reference.aspose.com/slides/php-java/aspose.slides/mathmatrix/) का उपयोग करें। मैट्रिक्स डिफ़ॉल्ट रूप से कोष्ठक नहीं शामिल करता, इसलिए आवश्यकता होने पर कोष्ठकों, स्क्वायर ब्रैकेट या कर्ली ब्रैकेट से घेरें।

![एक दो‑पंक्ति वाला गणितीय मैट्रिक्स जिसमें एक खाली सेल है](powerpoint-math-equations_10.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 120);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $matrix = new MathMatrix(2, 3);
    $matrix->set_Item(0, 0, new MathematicalText("1"));
    $matrix->set_Item(0, 1, new MathematicalText("x"));
    $matrix->set_Item(1, 0, new MathematicalText("x"));
    $matrix->set_Item(1, 1, new MathematicalText("2"));
    $matrix->set_Item(1, 2, new MathematicalText("y"));

    $mathParagraph->add(new MathBlock($matrix));

    $presentation->save("matrix.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **समीकरण ऐरे जोड़ें**

समीकरणों को क्षैतिज रूप से संरेखित करने या अभिव्यक्तियों की लंबवत स्टैक बनाने के लिए [toMathArray](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#toMathArray) का उपयोग करें।

![एक लंबवत गणितीय ऐरे जिसमें x ऊपर y है](powerpoint-math-equations_11.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 140);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $equationArray = (new MathematicalText("x"))
        - >join("y")
        - >toMathArray();

    $mathParagraph->add(new MathBlock($equationArray));

    $presentation->save("equation-array.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **त्रिकोणमितीय फ़ंक्शन जोड़ें**

जब तर्क वर्तमान तत्व हो और फ़ंक्शन नाम ज्ञात हो, तो [asArgumentOfFunction](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#asArgumentOfFunction) का उपयोग करें।

![त्रिकोणमितीय फ़ंक्शन cos को 2x पर लागू किया गया है](powerpoint-math-equations_6.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 100);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $cosine = (new MathematicalText("2x"))
        - >asArgumentOfFunction(MathFunctionsOfOneArgument::Cos);

    $mathParagraph->add(new MathBlock($cosine));

    $presentation->save("trigonometric-function.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **सुपरस्क्रिप्ट और सबस्क्रिप्ट जोड़ें**

इंडेक्स और घात के लिए सबस्क्रिप्ट और सुपरस्क्रिप्ट हेल्पर का प्रयोग करें। जब इंडेक्स को आधार के बाएँ पक्ष पर दिखाना हो, तो [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#setSubSuperscriptOnTheLeft) का प्रयोग करें।

![बाएँ‑साइड सबस्क्रिप्ट 1 और सुपरस्क्रिप्ट n के साथ एक बड़े Y अक्षर](powerpoint-math-equations_9.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 100);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $scripts = (new MathematicalText("Y"))
        - >setSubSuperscriptOnTheLeft("1", "n");

    $mathParagraph->add(new MathBlock($scripts));

    $presentation->save("subscript-superscript.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **डिलिमिटर जोड़ें**

एक अभिव्यक्ति को डिलिमिटर के भीतर रखने के लिए [enclose](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#enclose) का उपयोग करें। कई तत्वों वाले डिलिमिटर अभिव्यक्तियों के लिए आप एक विभाजक अक्षर भी सेट कर सकते हैं।

![x, y, और z को लंबवत बार द्वारा विभाजित किया गया एक डिलिमिटर अभिव्यक्ति](powerpoint-math-equations_13.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 100);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $delimiter = (new MathematicalText("x"))
        - >join("y")
        - >join("z")
        - >enclose(new Java("java.lang.Character", "<"), new Java("java.lang.Character", ">"));
    $delimiter->setSeparatorCharacter(new Java("java.lang.Character", "|"));

    $mathParagraph->add(new MathBlock($delimiter));

    $presentation->save("delimiters.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

### **डिलिमिटर का आकार और संरेखण**

पैरेंथीसिस को ऊँचे ऑपरेण्ड के अनुसार बढ़ाने के लिए `true` को [setGrowToMatchOperandHeight](https://reference.aspose.com/slides/php-java/aspose.slides/mathdelimiter/#setGrowToMatchOperandHeight) में पास करें, या सामान्य आकार में रखने के लिए `false` पास करें। दो उपलब्ध [MathDelimiterShape](https://reference.aspose.com/slides/php-java/aspose.slides/mathdelimitershape/) मानों में से एक को चुनने के लिये [setDelimiterShape](https://reference.aspose.com/slides/php-java/aspose.slides/mathdelimiter/#setDelimiterShape) का प्रयोग करें। `Centered` पैरेंथीसिस को गणितीय अक्ष के केंद्र में रखता है, जो बराबर साइन के बीच से गुजरता है। `Match` उन्हें समाविष्ट सामग्री के साथ संरेखित करता है। दोनों सेटिंग्स केवल डिलिमिटर को प्रभावित करती हैं; अंदर की अभिव्यक्ति अपरिवर्तित रहती है।

उदाहरण में `x` के घात में एक भिन्न रखा गया है, जिससे अभिव्यक्ति बेसलाइन से ऊपर अधिक विस्तारित होती है। सभी चार समीकरण समान पैरेंथीसिस और फ़ॉन्ट सेटिंग्स का उपयोग करते हैं।

```php
use aspose\slides\MathDelimiterShape;
use aspose\slides\MathematicalText;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $opening = new Java("java.lang.Character", "(");
    $closing = new Java("java.lang.Character", ")");
    for ($row = 0; $row < 2; $row++) {
        for ($column = 0; $column < 2; $column++) {
            $fraction = (new MathematicalText("a + b"))->divide("c + d");
            $power = (new MathematicalText("x"))->setSuperscript($fraction);
            $delimiter = $power->enclose($opening, $closing);
            $delimiter->setGrowToMatchOperandHeight($row === 0);
            $delimiter->setDelimiterShape($column === 0 ? MathDelimiterShape::Centered : MathDelimiterShape::Match);

            $mathShape = $slide->getShapes()->addMathShape(20 + 330 * $column, 20 + 120 * $row, 300, 100);
            $portion = $mathShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
            $portion->getPortionFormat()->setFontHeight(32);
            $equation = (new MathematicalText("y = "))->join($delimiter);
            $portion->getMathParagraph()->add($equation);
        }
    }
    $presentation->save("delimiter-sizing.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

PowerPoint में पंक्तियों की तुलना करके वृद्धि प्रभाव देखें। शीर्ष पंक्ति में पैरेंथीसिस घात को घेरने के लिये बढ़ते हैं और दोनों आकार समान दिखते हैं। नीचे की पंक्तियों में वृद्धि बंद है। बाएँ पैरेंथीसिस (`Centered`) बराबर साइन के साथ संरेखित होते हैं, जबकि दाएँ पैरेंथीसिस (`Match`) अभिव्यक्ति के ऊपर अधिक उठे होते हैं।

![चार समीकरण जिसमें ऊपर पैरेंथीसिस वृद्धि सक्रिय है और नीचे निष्क्रिय, बाएँ `Centered` और दाएँ `Match`](delimiter-sizing.png)

## **बॉर्डर बॉक्स जोड़ें**

एक भिन्न पर [toBorderBox](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#toBorderBox) को कॉल करके पूरी अभिव्यक्ति को फ्रेम करें। डिफ़ॉल्ट रूप से लौटाया गया [MathBorderBox](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/) चारों ओर दिखाता है। व्यक्तिगत पक्षों को हटाने के लिये [setHideTop](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setHideTop), [setHideBottom](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setHideBottom), [setHideLeft](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setHideLeft), और [setHideRight](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setHideRight) का प्रयोग करें।

उदाहरण में समान भिन्न की छह प्रतियां एक स्लाइड पर रखी गई हैं। हटाने के लिये सभी चार पक्ष छिपाएँ और उठते हुए तिरछे स्ट्राइक‑थ्रू के लिये `true` को [setStrikethroughBottomLeftToTopRight](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setStrikethroughBottomLeftToTopRight) में पास करें (↗) या गिरते हुए तिरछे स्ट्राइक‑थ्रू के लिये [setStrikethroughTopLeftToBottomRight](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setStrikethroughTopLeftToBottomRight) (↘) में पास करें। आप किसी भी संयोजन के लिये [setStrikethroughHorizontal](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setStrikethroughHorizontal) या [setStrikethroughVertical](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setStrikethroughVertical) का भी प्रयोग कर सकते हैं।

```php
use aspose\slides\MathBlock;
use aspose\slides\MathematicalText;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(540, 220, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    $addFraction = function ($x, $y, $hideBorder) use ($slide) {
        $fraction = (new MathematicalText("x+1"))->divide("y+2");
        $box = $fraction->toBorderBox();
        $box->setHideTop($hideBorder);
        $box->setHideBottom($hideBorder);
        $box->setHideLeft($hideBorder);
        $box->setHideRight($hideBorder);

        $shape = $slide->getShapes()->addMathShape($x, $y, 160, 90);
        $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
        $portion->getPortionFormat()->setFontHeight(28);
        $mathBlock = new MathBlock($box);
        $portion->getMathParagraph()->add($mathBlock);
        return $box;
    };

    $addFraction(10, 10, false);

    $partial = $addFraction(190, 10, false);
    $partial->setHideTop(true);
    $partial->setHideRight(true);

    $addFraction(370, 10, true)->setStrikethroughBottomLeftToTopRight(true);
    $addFraction(10, 120, true)->setStrikethroughTopLeftToBottomRight(true);
    $addFraction(190, 120, true)->setStrikethroughHorizontal(true);
    $addFraction(370, 120, false)->setStrikethroughVertical(true);

    $presentation->save("border-box.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![PowerPoint में छह संपादन योग्य भिन्न। शीर्ष पंक्ति: पूर्ण बॉर्डर, नीचे तथा बाएँ पक्ष, उठता तिरछा स्ट्राइक‑थ्रू। नीचे पंक्ति: गिरता तिरछा, क्षैतिज स्ट्राइक‑थ्रू, लंबवत स्ट्राइक‑थ्रू पूर्ण बॉर्डर के साथ।](border-box-fractions.png)

इस भिन्न में, क्षैतिज स्ट्राइक‑थ्रू भिन्न रेखा के ऊपर से गुज़रता है। लंबवत स्ट्राइक‑थ्रू अंश और हर दोनों को पार करता है जबकि आसपास का बॉर्डर दृश्यमान रहता है। ये रेखाएँ पूरी अभिव्यक्ति को सजा रही हैं। सामान्य टेक्स्ट स्ट्राइक‑थ्रू केवल टेक्स्ट रन के अक्षरों पर लागू होता है। PowerPoint में प्रस्तुति को पुनः खोलने के बाद आप अंश और हर को स्वतंत्र रूप से संपादित कर सकते हैं।

## **शब्द समूह बनाएं**

एक अभिव्यक्ति के ऊपर या नीचे समूह चिन्ह रखने के लिये [group](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#group) का उपयोग करें। समूहित शब्दों को लेबल करने के लिये सीमा जोड़ें।

![अभिव्यक्ति x + y को नीचे लेबल वाले समूह के साथ दिखाया गया है](powerpoint-math-equations_15.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 120);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $grouped = (new MathematicalText("x + y"))
        - >group(new Java("java.lang.Character", "\u{23DF}"), MathTopBotPositions::Bottom, MathTopBotPositions::Top)
        - >setLowerLimit("any text");

    $mathParagraph->add(new MathBlock($grouped));

    $presentation->save("grouped-terms.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **गणितीय तत्वों का स्वरूपित करें**

केवल तभी स्वरूपण सहायक उपयोग करें जब वह सूत्र को स्पष्ट करे। उदाहरण के लिये, [overbar](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#overbar) एक गणितीय तत्व के ऊपर बार रखता है।

![एक गणितीय अभिव्यक्ति ABC के ऊपर ओवरबार के साथ](powerpoint-math-equations_14.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 100);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $overbar = (new MathematicalText("ABC"))->overbar();

    $mathParagraph->add(new MathBlock($overbar));

    $presentation->save("overbar.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

### **मौजूद समीकरण में टेक्स्ट स्वरूपित करें**

किसी मौजूदा समीकरण में पूरे टेक्स्ट को स्वरूपित करने के लिये प्रत्येक गणितीय ब्लॉक के तत्व वृक्ष को पार करें। [MathElementBase::getChildren](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#getChildren) केवल तत्काल बच्चों को लौटाता है, इसलिए घटकों को पुनरावृत्त रूप से कॉल करें ताकि भिन्न, स्क्रिप्ट, मूल और अन्य नेस्टेड संरचनाओं के भीतर के टेक्स्ट तक पहुँचा जा सके। जब वर्तमान तत्व [MathematicalText](https://reference.aspose.com/slides/php-java/aspose.slides/mathematicaltext/) हो तो उसे भी शामिल करें।

यह उदाहरण मानता है कि `input.pptx` में `z = xᵢ / ∛y` जैसा समीकरण है, जिसमें अंश में सबस्क्रिप्ट और हर में मूल है। केवल ब्लॉक के शीर्ष‑स्तर के तत्वों को प्रोसेस करने से भिन्न के भीतर का टेक्स्ट छूट जाएगा। उदाहरण स्लाइड के टेक्स्ट फ्रेम में गणितीय भागों को खोजता है, उनके ब्लॉकों को [MathPortion::getMathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/#getMathParagraph) से प्राप्त करता है, और प्रत्येक टेक्स्ट तत्व के [getFormat](https://reference.aspose.com/slides/php-java/aspose.slides/mathematicaltext/#getFormat) मेथड के माध्यम से [setFontHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight) को 28 पॉइंट पर सेट करता है।

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

function formatMathText($element, $mathematicalTextClass) {
    if (java_instanceof($element, $mathematicalTextClass)) {
        $element->getFormat()->setFontHeight(28);
    }

    foreach ($element->getChildren() as $child) {
        formatMathText($child, $mathematicalTextClass);
    }
}

$mathematicalTextClass = new JavaClass("com.aspose.slides.MathematicalText");
$autoShapeClass = new JavaClass("com.aspose.slides.IAutoShape");
$mathPortionClass = new JavaClass("com.aspose.slides.IMathPortion");

$presentation = new Presentation("input.pptx");
try {
    for ($slideIndex = 0; $slideIndex < java_values($presentation->getSlides()->size()); $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        for ($shapeIndex = 0; $shapeIndex < java_values($slide->getShapes()->size()); $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            if (!java_instanceof($shape, $autoShapeClass)) {
                continue;
            }

            $textFrame = $shape->getTextFrame();
            if (java_is_null($textFrame)) {
                continue;
            }

            for ($paragraphIndex = 0; $paragraphIndex < java_values($textFrame->getParagraphs()->getCount()); $paragraphIndex++) {
                $paragraph = $textFrame->getParagraphs()->get_Item($paragraphIndex);
                for ($portionIndex = 0; $portionIndex < java_values($paragraph->getPortions()->getCount()); $portionIndex++) {
                    $portion = $paragraph->getPortions()->get_Item($portionIndex);
                    if (java_instanceof($portion, $mathPortionClass)) {
                        for ($blockIndex = 0; $blockIndex < java_values($portion->getMathParagraph()->getCount()); $blockIndex++) {
                            $block = $portion->getMathParagraph()->get_Item($blockIndex);
                            formatMathText($block, $mathematicalTextClass);
                        }
                    }
                }
            }
        }
    }

    $presentation->save("formatted-equations.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

सहेजा गया प्रस्तुतीकरण प्रत्येक प्रोसेस किए गए समीकरण के हर स्तर पर अद्यतित टेक्स्ट स्वरूपण रखता है, जबकि उसका टेक्स्ट कंटेंट और गणितीय संरचना अपरिवर्तित रहती है।

## **त्वरित संदर्भ**

| कार्य | मुख्य API |
| --- | --- |
| गणितीय पाठ बनाएं | [MathematicalText](https://reference.aspose.com/slides/php-java/aspose.slides/mathematicaltext/) |
| तत्व मिलाएँ | [join](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| भिन्न बनाएं | [divide](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| सुपरस्क्रिप्ट या सबस्क्रिप्ट जोड़ें | [setSuperscript](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/), [setSubscript](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| फ़ंक्शन जोड़ें | [function](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/), [asArgumentOfFunction](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| मूल जोड़ें | [radical](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| सीमाएँ जोड़ें | [setLowerLimit](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/), [setUpperLimit](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| बाएँ‑साइड स्क्रिप्ट जोड़ें | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| समिकरण और इंटीग्रल जोड़ें | [nary](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/), [integral](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| मैट्रिक्स जोड़ें | [MathMatrix](https://reference.aspose.com/slides/php-java/aspose.slides/mathmatrix/) |
| समीकरण ऐरे जोड़ें | [toMathArray](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| डिलिमिटर जोड़ें | [enclose](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| बार और बॉर्डर जोड़ें | [overbar](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/), [toBorderBox](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| शब्द समूह बनाएं | [group](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं मौजूदा PowerPoint समीकरण को संपादित कर सकता हूँ?**

हाँ। प्रस्तुतीकरण खोलें, उस आकार को खोजें जिसमें एक [MathPortion](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/) हो, [getMathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/#getMathParagraph) को कॉल करें, और उस अनुच्छेद में गणितीय ब्लॉक को अपडेट करें।

**क्या समीकरण संपादन योग्य PowerPoint गणित के रूप में सहेजे जाते हैं?**

हाँ। PPTX में सहेजते समय Aspose.Slides समीकरण को संपादन योग्य Office गणित सामग्री के रूप में लिखता है।

**क्या मैं समीकरणों को LaTeX में निर्यात कर सकता हूँ?**

हाँ। उसके [MathPortion](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/) से [MathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathparagraph/) प्राप्त करें, और सीधे निर्यात के लिये [MathParagraph::toLatex](https://reference.aspose.com/slides/php-java/aspose.slides/mathparagraph/#toLatex) को कॉल करें। पूर्ण उदाहरण के लिये देखें [Export Math Equations from Presentations in PHP via Java](/slides/hi/php-java/exporting-math-equations/#export-math-equations-to-latex)।