---
title: PHP में PowerPoint प्रस्तुतियों में गणितीय समीकरण जोड़ें
linktitle: PowerPoint गणितीय समीकरण
type: docs
weight: 80
url: /hi/php-java/powerpoint-math-equations/
keywords:
- गणितीय समीकरण
- गणितीय चिह्न
- गणितीय सूत्र
- गणितीय पाठ
- गणितीय समीकरण जोड़ें
- गणितीय चिह्न जोड़ें
- गणितीय सूत्र जोड़ें
- गणितीय पाठ जोड़ें
- PowerPoint
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java के साथ PowerPoint PPT और PPTX में गणितीय समीकरण डालें और संपादित करें, OMML को सपोर्ट करता है, फ़ॉर्मेटिंग नियंत्रण उपलब्ध हैं, और स्पष्ट PHP कोड उदाहरण प्रदान करता है।"
---
## **अवलोकन**

PowerPoint समीकरणों को Office Math Markup Language (OMML) के रूप में संग्रहीत करता है। Aspose.Slides for PHP via Java के साथ, आप प्रोग्रामेटिक रूप से समान प्रकार की गणितीय सामग्री बना सकते हैं: भिन्न, मूल, फ़ंक्शन, सीमाएँ, N-ary ऑपरेटर, मैट्रिस, एरे, और फ़ॉर्मेटेड गणित ब्लॉक।

PowerPoint में, उपयोगकर्ता आमतौर पर **Insert > Equation** से समीकरण जोड़ते हैं:

![PowerPoint Insert टैब जिसमें Equation कमांड चयनित है](powerpoint-math-equations_1.png)

परिणाम स्लाइड पर संपादन योग्य गणितीय पाठ है:

![एक PowerPoint स्लाइड जिसमें संपादन योग्य गणितीय समीकरण है](powerpoint-math-equations_2.png)

Aspose.Slides इस गणितीय पाठ को तीन मुख्य ऑब्जेक्ट्स के माध्यम से बनाता है:

- एक गणितीय आकार, जिसे [addMathShape](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addMathShape) से बनाया जाता है, वह आकार है जिसमें समीकरण शामिल होता है।
- [MathPortion](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/) आकार के टेक्स्ट फ्रेम के अंदर गणितीय सामग्री संग्रहीत करता है।
- [MathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathparagraph/) एक या अधिक [MathBlock](https://reference.aspose.com/slides/php-java/aspose.slides/mathblock/) ऑब्जेक्ट्स को समाहित करता है।

नीचे के अधिकांश उदाहरण [MathematicalText](https://reference.aspose.com/slides/php-java/aspose.slides/mathematicaltext/) और [MathElementBase](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) के फ्लुएंट मेथड्स का उपयोग करते हैं ताकि कोड छोटा और पठनीय रहे।

MathML निर्यात परिदृश्यों के लिए, देखें [Export Math Equations from Presentations in PHP via Java](/slides/hi/php-java/exporting-math-equations/)।

## **समीकरण बनाएं**

यह उदाहरण [addMathShape](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addMathShape) का उपयोग करके एक गणितीय आकार बनाता है और पाइथागोरस प्रमेय जोड़ता है:

![समीकरण c वर्ग बराबर a वर्ग प्लस b वर्ग](powerpoint-math-equations_3.png)

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

{{% alert color="info" title="Note" %}}
[addMathShape](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addMathShape) एक आकार बनाता है जिसमें पहले से ही एक गणितीय पैराग्राफ शामिल होता है। पहले [MathPortion](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/) तक पहुँचें, [getMathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/#getMathParagraph) को कॉल करें, और उसमें गणितीय ब्लॉक या तत्व जोड़ें।
{{% /alert %}}

## **भिन्न जोड़ें**

एक भिन्न बनाने के लिए [divide](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#divide) का उपयोग करें। आप [MathFractionTypes](https://reference.aspose.com/slides/php-java/aspose.slides/mathfractiontypes/) से भिन्न शैली चुन सकते हैं।

![एक तिरछा गणितीय भिन्न जिसमें 1 को x से विभाजित दिखाया गया है](powerpoint-math-equations_4.png)

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

स्टैक्ड भिन्न के लिए, [MathFractionTypes::Bar](https://reference.aspose.com/slides/php-java/aspose.slides/mathfractiontypes/#Bar) का उपयोग करें।

```php
$stackedFraction = (new MathematicalText("x + 1"))->divide("y - 1", MathFractionTypes::Bar);
```

## **मूल जोड़ें**

[radical](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#radical) का उपयोग करके वर्गमूल, घनमूल या अन्य मूल बनाएं। वर्तमान तत्व बेस बन जाता है, और तर्क डिग्री बन जाता है।

![एक n‑था मूल अभिव्यक्ति जिसमें x मूल चिह्न के नीचे है](powerpoint-math-equations_5.png)

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

## **फ़ंक्शन और सीमा जोड़ें**

फ़ंक्शन जैसे `sin(x)`, `log(x)`, या कस्टम फ़ंक्शन नामों के लिए [asArgumentOfFunction](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#asArgumentOfFunction) या [function](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#function) का उपयोग करें। सीमाओं के लिए, `lim` को एक [MathLimit](https://reference.aspose.com/slides/php-java/aspose.slides/mathlimit/) में रखें या [setLowerLimit](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#setLowerLimit) का उपयोग करें।

![x की सीमा जब x अनंत की ओर बढ़ता है](powerpoint-math-equations_8.png)

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

## **N-ary ऑपरेटर और इंटेग्रल जोड़ें**

योग, संघ, अंतर्संघ, और अन्य बड़े ऑपरेटरों के लिए [nary](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#nary) का उपयोग करें। इंटेग्रल के लिए [integral](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#integral) का उपयोग करें। दोनों मेथड आपको निचली और ऊपरी सीमाएँ सेट करने देते हैं।

![निचली और ऊपरी सीमाओं के साथ एक योग](powerpoint-math-equations_7.png)

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

N-ary ऑपरेटर वैकल्पिक सीमाओं के साथ बड़े ऑपरेटरों के लिए होते हैं। सरल ऑपरेटर जैसे `+`, `-`, और `=` आमतौर पर [MathematicalText](https://reference.aspose.com/slides/php-java/aspose.slides/mathematicaltext/) के रूप में जोड़े जाते हैं और अभिव्यक्ति में मिलाए जाते हैं।

इंटेग्रल के लिए, [integral](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#integral) का उपयोग करें:

```php
$integralBase = (new MathematicalText("x"))->join((new MathematicalText("dx"))->toBox());
$integral = $integralBase->integral(MathIntegralTypes::Simple, "0", "1");
```

## **मैट्रिस जोड़ें**

पंक्तियों और कॉलम के लिए [MathMatrix](https://reference.aspose.com/slides/php-java/aspose.slides/mathmatrix/) का उपयोग करें। मैट्रिस डिफ़ॉल्ट रूप से कोष्ठक शामिल नहीं करती, इसलिए जब आपको कोष्ठक, ब्रेस या कर्ली ब्रेसेस चाहिए हों तो मैट्रिस को घेरें।

![एक दो-पंक्तियों वाला गणितीय मैट्रिस जिसमें एक खाली सेल है](powerpoint-math-equations_10.png)

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

## **समीकरण एरे जोड़ें**

जब आपको संरेखित समीकरणों या अभिव्यक्तियों के लम्बवत स्टैक की आवश्यकता हो, तब [toMathArray](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#toMathArray) का उपयोग करें।

![एक लंबवत गणितीय एरे जिसमें x y के ऊपर है](powerpoint-math-equations_11.png)

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

जब तर्क वर्तमान तत्व है और फ़ंक्शन नाम ज्ञात है, तब [asArgumentOfFunction](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#asArgumentOfFunction) का उपयोग करें।

![त्रिकोणमितीय फ़ंक्शन cos को 2x पर लागू किया गया](powerpoint-math-equations_6.png)

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

## **सबस्क्रिप्ट और सुपरस्क्रिप्ट जोड़ें**

सूचकांक और पावर के लिए सबस्क्रिप्ट और सुपरस्क्रिप्ट हेल्पर का उपयोग करें। जब सूचकांक बेस के बाएँ‑पक्ष में दिखना आवश्यक हो, तो [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#setSubSuperscriptOnTheLeft) का उपयोग करें।

![एक बड़े Y के बाएँ‑पक्ष में सबस्क्रिप्ट 1 और सुपरस्क्रिप्ट n](powerpoint-math-equations_9.png)

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

एक अभिव्यक्ति को डिलिमिटर के भीतर रखने के लिए [enclose](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#enclose) का उपयोग करें। आप कई तत्वों वाली डिलिमिटर अभिव्यक्तियों के लिए एक विभाजक अक्षर भी सेट कर सकते हैं।

![एक डिलिमिटर अभिव्यक्ति जिसमें x, y, और z लंबवत बार द्वारा विभक्त हैं](powerpoint-math-equations_13.png)

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

`true` को [setGrowToMatchOperandHeight](https://reference.aspose.com/slides/php-java/aspose.slides/mathdelimiter/#setGrowToMatchOperandHeight) में पास करके कोष्ठकों को ऊँची ऑपरेन्ड के चारों ओर बढ़ने दें, या `false` पास करके इन्हें सामान्य आकार पर रखें। दो में से किसी एक [MathDelimiterShape](https://reference.aspose.com/slides/php-java/aspose.slides/mathdelimitershape/) मान के साथ [setDelimiterShape](https://reference.aspose.com/slides/php-java/aspose.slides/mathdelimiter/#setDelimiterShape) का उपयोग करें। `Centered` कोष्ठकों को गणितीय अक्ष पर केंद्रित करता है, जो बराबर चिह्न के मध्य से गुजरता है। `Match` उन्हें सम्मिलित सामग्री के साथ संरेखित करता है। दोनों सेटिंग्स केवल डिलिमिटर को प्रभावित करती हैं। भीतर की अभिव्यक्ति वही रहती है।

उदाहरण में `x` के एक्सपोनेंट में एक भिन्न रखा गया है ताकि अभिव्यक्ति बेसलाइन के ऊपर अधिक विस्तारित हो। सभी चार समीकरण समान कोष्ठकों और फ़ॉन्ट सेटिंग्स का उपयोग करते हैं।

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

PowerPoint में, वृद्धि के प्रभाव को देखने के लिए पंक्तियों की तुलना करें। शीर्ष पंक्ति में, कोष्ठक एक्सपोनेंट को घेरने के लिए बढ़ते हैं और दोनों आकार समान दिखते हैं। निचली पंक्ति में, वृद्धि बंद है। बाएँ तरफ छोटे कोष्ठक (`Centered`) बराबर चिह्न के साथ संरेखित होते हैं, जबकि दाएँ (`Match`) अभिव्यक्ति के ऊपर उच्चता पर होते हैं।

![PowerPoint में चार समीकरण जिसमें डिलिमिटर वृद्धि ऊपर सक्षम और नीचे अक्षम है, और बाएँ Centered तथा दाएँ Match है](delimiter-sizing.png)

## **बॉर्डर बॉक्स जोड़ें**

जब समीकरण स्वयं को फ्रेम किया जाना चाहिए, तब [toBorderBox](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#toBorderBox) का उपयोग करें।

![एक बॉक्स्ड समीकरण जिसमें a वर्ग बराबर b वर्ग प्लस c वर्ग दिखाया गया है](powerpoint-math-equations_12.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 100);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $boxedEquation = (new MathematicalText("a"))
        - >setSuperscript("2")
        - >join("=")
        - >join((new MathematicalText("b"))->setSuperscript("2"))
        - >join("+")
        - >join((new MathematicalText("c"))->setSuperscript("2"))
        - >toBorderBox();

    $mathParagraph->add(new MathBlock($boxedEquation));

    $presentation->save("border-box.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **शर्तों को समूहित करें**

[group](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#group) का उपयोग करके अभिव्यक्ति के ऊपर या नीचे एक ग्रुपिंग कैरेक्टर रखें। समूहित शर्तों को लेबल करने के लिए सीमा जोड़ें।

![अभिव्यक्ति x + y को समूहित किया गया है और नीचे कोई भी टेक्स्ट लेबल है](powerpoint-math-equations_15.png)

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

## **गणितीय तत्वों का फ़ॉर्मैट**

फ़ॉर्मेटिंग हेल्पर केवल तब उपयोग करें जब वे सूत्र को स्पष्ट करें। उदाहरण के लिए, [overbar](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#overbar) गणितीय तत्व के ऊपर एक बार रखता है।

![एक गणितीय अभिव्यक्ति ABC जिसके ऊपर एक बार है](powerpoint-math-equations_14.png)

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

### **मौजूदा समीकरण में टेक्स्ट फ़ॉर्मैट करें**

मौजूदा समीकरण में पूरे टेक्स्ट को फ़ॉर्मैट करने के लिए, प्रत्येक गणित ब्लॉक के तत्व ट्री को ट्रैवर्स करें। [MathElementBase::getChildren](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#getChildren) केवल त्वरित चिल्ड्रेन लौटाता है, इसलिए फ़्रैक्शन, स्क्रिप्ट, रैडिकल और अन्य नेस्टेड स्ट्रक्चर के अंदर टेक्स्ट तक पहुँचने के लिए इसे पुनरावर्तित रूप से कॉल करें। वर्तमान तत्व और उसके चाइल्ड्स दोनों को जाँचें ताकि जब वह [MathematicalText](https://reference.aspose.com/slides/php-java/aspose.slides/mathematicaltext/) हो तो प्रारंभिक तत्व को भी शामिल किया जा सके।

यह उदाहरण मानता है कि `input.pptx` में `z = xᵢ / ∛y` जैसा समीकरण है, जिसमें अंश के न्यूमेरेटर में एक सबस्क्रिप्ट और डिनॉमिनेटर में एक रैडिकल है। केवल ब्लॉक के टॉप‑लेवल तत्वों को प्रोसेस करने से अंश के अंदर का टेक्स्ट छूट जाएगा। उदाहरण स्लाइड टेक्स्ट फ्रेम में गणितीय भाग खोजता है, उनके ब्लॉक को [MathPortion::getMathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/#getMathParagraph) से एक्सेस करता है, और प्रत्येक टेक्स्ट तत्व के [getFormat](https://reference.aspose.com/slides/php-java/aspose.slides/mathematicaltext/#getFormat) मेथड के माध्यम से फ़ॉन्ट आकार को 28 पॉइंट सेट करने के लिए [setFontHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight) का उपयोग करता है।

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

सहेजा गया प्रेज़ेंटेशन प्रत्येक प्रोसेस किए गए समीकरण के हर स्तर पर अद्यतन टेक्स्ट फ़ॉर्मैटिंग रखता है, जबकि उसके टेक्स्ट कंटेंट और गणितीय संरचना को संरक्षित रखता है।

## **त्वरित संदर्भ**

| कार्य | मुख्य API |
| --- | --- |
| गणितीय पाठ बनाएं | [MathematicalText](https://reference.aspose.com/slides/php-java/aspose.slides/mathematicaltext/) |
| तत्वों को मिलाएं | [join](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| भिन्न बनाएं | [divide](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| सुपरस्क्रिप्ट या सबस्क्रिप्ट जोड़ें | [setSuperscript](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/), [setSubscript](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| फ़ंक्शन जोड़ें | [function](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/), [asArgumentOfFunction](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| रैडिकल जोड़ें | [radical](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| सीमाएँ जोड़ें | [setLowerLimit](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/), [setUpperLimit](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| बाएँ‑पक्ष स्क्रिप्ट जोड़ें | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| योग और इंटेग्रल जोड़ें | [nary](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/), [integral](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| मैट्रिस जोड़ें | [MathMatrix](https://reference.aspose.com/slides/php-java/aspose.slides/mathmatrix/) |
| समीकरण एरे जोड़ें | [toMathArray](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| डिलिमिटर जोड़ें | [enclose](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| बार और बॉर्डर जोड़ें | [overbar](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/), [toBorderBox](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| शर्तों को समूहित करें | [group](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |

## **FAQ**

**क्या मैं मौजूदा PowerPoint समीकरण को संपादित कर सकता हूँ?**

हां। प्रेज़ेंटेशन खोलें, वह आकार खोजें जिसमें एक [MathPortion](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/) हो, [getMathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/#getMathParagraph) को कॉल करें, और उस पैराग्राफ में गणितीय ब्लॉक अपडेट करें।

**क्या समीकरण संपादन योग्य PowerPoint गणित के रूप में सहेजे जाते हैं?**

हां। जब आप PPTX में सहेजते हैं, Aspose.Slides समीकरण को संपादन योग्य Office गणित सामग्री के रूप में लिखता है।

**क्या मैं समीकरणों को LaTeX में निर्यात कर सकता हूँ?**

हां। उसके [MathPortion](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/) से समीकरण का [MathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathparagraph/) प्राप्त करें, और सीधे निर्यात करने के लिए [MathParagraph::toLatex](https://reference.aspose.com/slides/php-java/aspose.slides/mathparagraph/#toLatex) को कॉल करें। पूर्ण उदाहरण के लिए, देखें [PHP via Java में प्रस्तुतियों से गणितीय समीकरण निर्यात](/slides/hi/php-java/exporting-math-equations/#export-math-equations-to-latex)।