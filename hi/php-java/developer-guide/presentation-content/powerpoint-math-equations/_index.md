---
title: PHP में PowerPoint प्रस्तुतियों में गणितीय समीकरण जोड़ें
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
description: "Aspose.Slides for PHP via Java का उपयोग करके PowerPoint PPT और PPTX में गणितीय समीकरण सम्मिलित और संपादित करें, जो OMML, स्वरूपण नियंत्रण, और स्पष्ट PHP कोड उदाहरणों का समर्थन करता है।"
---
## **अवलोकन**

PowerPoint समीकरणों को Office Math Markup Language (OMML) के रूप में संग्रहीत करता है। Aspose.Slides for PHP via Java का उपयोग करके आप समान प्रकार की गणितीय सामग्री प्रोग्रामेटिक रूप से बना सकते हैं: भिन्न, मूल, फ़ंक्शन, सीमा, N-ary ऑपरेटर, मैट्रिसेज़, एरेज़, और स्वरूपित गणितीय ब्लॉक्स।

PowerPoint में, उपयोगकर्ता सामान्यतः **Insert > Equation** से समीकरण जोड़ते हैं:

![PowerPoint Insert टैब जिसमें Equation कमांड चयनित है](powerpoint-math-equations_1.png)

परिणाम स्लाइड पर संपादन योग्य गणितीय टेक्स्ट होता है:

![एक PowerPoint स्लाइड जिसमें संपादन योग्य गणितीय समीकरण है](powerpoint-math-equations_2.png)

Aspose.Slides इस गणितीय टेक्स्ट को तीन मुख्य ऑब्जेक्ट्स के माध्यम से बनाता है:

- एक गणितीय शैप, जिसे [addMathShape](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addMathShape) से बनाया जाता है, वह शैप है जिसमें समीकरण होता है।
- [MathPortion](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/) शैप के टेक्स्ट फ्रेम के भीतर गणितीय सामग्री को संग्रहीत करता है।
- [MathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathparagraph/) एक या अधिक [MathBlock](https://reference.aspose.com/slides/php-java/aspose.slides/mathblock/) ऑब्जेक्ट्स को शामिल करता है।

नीचे के अधिकांश उदाहरण [MathematicalText](https://reference.aspose.com/slides/php-java/aspose.slides/mathematicaltext/) और [MathElementBase](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) की फ्लुएंट मेथड्स का उपयोग करते हैं ताकि कोड छोटा और पढ़ने योग्य रहे।

MathML निर्यात परिदृश्यों के लिए, देखें [Export Math Equations from Presentations in PHP via Java](/slides/hi/php-java/exporting-math-equations/)।

## **एक समीकरण बनाएं**

यह उदाहरण [addMathShape](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addMathShape) का उपयोग करके एक गणितीय शैप बनाता है और पाइथागोरस प्रमेय जोड़ता है:

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

{{% alert color="info" title="Note" %}}
[addMathShape](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addMathShape) एक ऐसा शैप बनाता है जिसमें पहले से ही एक गणितीय पैराग्राफ होता है। पहले [MathPortion](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/) तक पहुँचें, [getMathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/#getMathParagraph) को कॉल करें, और उसमें गणितीय ब्लॉक्स या गणितीय एलिमेंट्स जोड़ें।
{{% /alert %}}

## **भिन्न जोड़ें**

भिन्न बनाने के लिए [divide](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#divide) का उपयोग करें। आप [MathFractionTypes](https://reference.aspose.com/slides/php-java/aspose.slides/mathfractiontypes/) के साथ भिन्न शैली चुन सकते हैं।

![एक तिरछा गणितीय भिन्न जो x से विभाजित एक को दिखा रहा है](powerpoint-math-equations_4.png)

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

वर्ग मूल, घन मूल, या अन्य मूल बनाने के लिए [radical](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#radical) का उपयोग करें। वर्तमान एलिमेंट बेस बन जाता है, और आर्ग्युमेंट डिग्री बन जाता है।

![एक n‑th मूल अभिव्यक्ति जहाँ x मूल चिन्ह के नीचे है](powerpoint-math-equations_5.png)

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

`sin(x)`, `log(x)` जैसी फ़ंक्शनों के लिए या कस्टम फ़ंक्शन नामों के लिए [asArgumentOfFunction](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#asArgumentOfFunction) या [function](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#function) का उपयोग करें। सीमाओं के लिए, `lim` को एक [MathLimit](https://reference.aspose.com/slides/php-java/aspose.slides/mathlimit/) में रखें, या [setLowerLimit](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#setLowerLimit) का उपयोग करें।

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

कस्टम फ़ंक्शन नाम के लिए, फ़ंक्शन नाम को वर्तमान एलिमेंट बनाएँ और उसके आर्ग्युमेंट के साथ [function](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#function) को कॉल करें:

```php
$customFunction = (new MathematicalText("f"))->function("x + 1");
```

## **N-ary ऑपरेटर और इंटीग्रल जोड़ें**

समेशन, यूनियन, इंटरसेक्शन और अन्य बड़े ऑपरेटरों के लिए [nary](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#nary) का उपयोग करें। इंटीग्रल के लिये [integral](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#integral) का उपयोग करें। दोनों मेथड नीचे और ऊपर की सीमाएँ सेट करने की अनुमति देते हैं।

![नीचे और ऊपर की सीमाओं के साथ एक समेशन](powerpoint-math-equations_7.png)

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

N-ary ऑपरेटर बड़े ऑपरेटरों के लिये होते हैं जिनके वैकल्पिक सीमाएँ हो सकती हैं। सरल ऑपरेटर जैसे `+`, `-`, `=` को सामान्यतः [MathematicalText](https://reference.aspose.com/slides/php-java/aspose.slides/mathematicaltext/) के द्वारा जोड़ते हैं और अभिव्यक्ति में सम्मिलित करते हैं।

इंटीग्रल के लिए, [integral](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#integral) का उपयोग करें:

```php
$integralBase = (new MathematicalText("x"))->join((new MathematicalText("dx"))->toBox());
$integral = $integralBase->integral(MathIntegralTypes::Simple, "0", "1");
```

## **मैट्रिसेज़ जोड़ें**

पंक्तियों और स्तम्भों के लिये [MathMatrix](https://reference.aspose.com/slides/php-java/aspose.slides/mathmatrix/) का उपयोग करें। मैट्रिसेज़ में डिफ़ॉल्ट रूप से कोष्ठक नहीं होते, इसलिए जब कोष्ठक, ब्रैकेट या ब्रेस की आवश्यकता हो तो उन्हें स्वयं जोड़ें।

![एक दो‑पंक्तियों वाला मैट्रिकस जिसमें एक खाली सेल है](powerpoint-math-equations_10.png)

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

## **समीकरण एरेज़ जोड़ें**

संरेखित समीकरणों या लंबवत अभिव्यक्तियों के स्टैक की आवश्यकता होने पर [toMathArray](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#toMathArray) का उपयोग करें।

![एक लंबवत गणितीय एरे जहाँ x y के ऊपर है](powerpoint-math-equations_11.png)

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

### **एरे को आसपास के एलिमेंट्स के साथ संरेखित करें**

[setBaseJustification](https://reference.aspose.com/slides/php-java/aspose.slides/matharray/#setBaseJustification) एरे की ऊर्ध्वाधर संरेखण को उसके बगल में मौजूद गणितीय एलिमेंट्स के सापेक्ष नियंत्रित करता है। नीचे दिया गया उदाहरण पहली पंक्ति, एरे के केंद्र और अंतिम पंक्ति के साथ संरेखण की तुलना करता है।

निम्न उदाहरण तीन समान एरे बनाता है, प्रत्येक में तीन पंक्तियाँ और पड़ोसी एलिमेंट्स `A=` तथा `=B` हैं। सभी गणितीय टेक्स्ट Cambria Math, 24 पॉइंट में हैं। केवल एरे संरेखण बदलता है।

```php
use aspose\slides\FillType;
use aspose\slides\FontData;
use aspose\slides\MathArray;
use aspose\slides\MathBlock;
use aspose\slides\MathJustification;
use aspose\slides\MathVerticalAlignment;
use aspose\slides\MathematicalText;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;
use aspose\slides\TextAnchorType;

$createText = static function (string $value) {
    $text = new MathematicalText($value);
    $text->getFormat()->setFontHeight(24);
    $text->getFormat()->setLatinFont(new FontData("Cambria Math"));
    return $text;
};

$alignments = ["Top" => MathVerticalAlignment::Top, "Center" => MathVerticalAlignment::Center, "Bottom" => MathVerticalAlignment::Bottom];
$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(780, 200, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);
    $x = 20;
    foreach ($alignments as $name => $alignment) {
        $label = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, $x, 10, 240, 30);
        $label->getFillFormat()->setFillType(FillType::NoFill);
        $label->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
        $label->getTextFrame()->setText($name);
        $labelFormat = $label->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat();
        $labelFormat->setFontHeight(16);
        $labelFormat->getFillFormat()->setFillType(FillType::Solid);
        $labelFormat->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);

        $mathShape = $slide->getShapes()->addMathShape($x, 60, 240, 130);
        $mathShape->getTextFrame()->getTextFrameFormat()->setAnchoringType(TextAnchorType::Top);
        $paragraph = $mathShape->getTextFrame()->getParagraphs()->get_Item(0);
        $mathParagraph = $paragraph->getPortions()->get_Item(0)->getMathParagraph();
        $mathParagraph->setJustification(MathJustification::LeftJustified);

        $firstRow = $createText("x+y=3");
        $equationArray = new MathArray($firstRow);
        foreach (["x-y=1", "x=2"] as $value) {
            $row = $createText($value);
            $equationArray->getArguments()->add($row);
        }
        $equationArray->setBaseJustification($alignment);
        $leftText = $createText("A=");
        $rightText = $createText("=B");
        $equation = (new MathBlock($leftText))->join($equationArray)->join($rightText);
        $mathParagraph->add($equation);
        $x += 260;
    }
    $presentation->save("equation-array-alignment.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

नीचे की तुलना PowerPoint में सहेजी गई प्रस्तुति को दिखाती है। प्रत्येक एरे के बगल में `A=` और `=B` की स्थिति पर ध्यान दें।

![PowerPoint में समीकरण एरेज़ के शीर्ष, मध्य और निचले संरेखण तथा समान पड़ोसी एलिमेंट्स के साथ](equation-array-alignment.png)

### **पंक्ति अंतराल कॉन्फ़िगर करें**

[setRowSpacingRule](https://reference.aspose.com/slides/php-java/aspose.slides/matharray/#setRowSpacingRule) एरे के भीतर पंक्तियों के लिए अंतराल नियम चुनता है। [setRowSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/matharray/#setRowSpacing) स्पष्ट अंतराल मान प्रदान करता है और प्रीसेट नियमों द्वारा अनदेखा किया जाता है।

सटीक अंतराल के लिये मान पॉइंट में मापा जाता है। अनुपातिक अंतराल के लिये यह अर्ध‑रेखाओं में मापा जाता है: उदाहरण में `3` का अर्थ 1.5 रेखा है। स्पष्ट मान निर्दिष्ट करते समय दोनों गुणधर्म सेट करें; केवल संख्यात्मक मान बदलने से नियम नहीं बदलेगा।

नीचे का उदाहरण पाँच प्रस्तुतियों को समान समीकरणों, संरेखण और फ़ॉन्ट सेटिंग्स के साथ सहेजता है। पहले तीन प्रीसेट्स का उपयोग करते हैं; अंतिम दो स्पष्ट मान दिखाते हैं।

```php
use aspose\slides\FontData;
use aspose\slides\MathArray;
use aspose\slides\MathBlock;
use aspose\slides\MathJustification;
use aspose\slides\MathRowSpacingRule;
use aspose\slides\MathVerticalAlignment;
use aspose\slides\MathematicalText;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$createText = static function (string $value) {
    $text = new MathematicalText($value);
    $text->getFormat()->setFontHeight(24);
    $text->getFormat()->setLatinFont(new FontData("Cambria Math"));
    return $text;
};

$settings = [
    "SingleLineGap" => [MathRowSpacingRule::SingleLineGap, 0],
    "OneAndAHalfLineGap" => [MathRowSpacingRule::OneAndAHalfLineGap, 0],
    "TwoLineGap" => [MathRowSpacingRule::TwoLineGap, 0],
    "Exactly" => [MathRowSpacingRule::Exactly, 20],
    "Multiple" => [MathRowSpacingRule::Multiple, 3],
];

foreach ($settings as $name => [$rule, $spacing]) {
    $presentation = new Presentation();
    try {
        $mathShape = $presentation->getSlides()->get_Item(0)->getShapes()->addMathShape(20, 20, 600, 300);
        $paragraph = $mathShape->getTextFrame()->getParagraphs()->get_Item(0);
        $paragraph->getParagraphFormat()->setSpaceBefore(0);
        $paragraph->getParagraphFormat()->setSpaceAfter(0);
        $mathParagraph = $paragraph->getPortions()->get_Item(0)->getMathParagraph();
        $mathParagraph->setJustification(MathJustification::LeftJustified);

        $firstRow = $createText("x+y=3");
        $equationArray = new MathArray($firstRow);
        foreach (["x-y=1", "x=2"] as $value) {
            $row = $createText($value);
            $equationArray->getArguments()->add($row);
        }
        $equationArray->setBaseJustification(MathVerticalAlignment::Center);
        $equationArray->setRowSpacingRule($rule);
        $equationArray->setRowSpacing($spacing);
        $leftText = $createText("A=");
        $rightText = $createText("=B");
        $equation = (new MathBlock($leftText))->join($equationArray)->join($rightText);
        $mathParagraph->add($equation);
        $presentation->save("equation-array-$name.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

एरे पंक्ति अंतराल पैराग्राफ अंतराल से अलग है। [setSpaceBefore](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setSpaceBefore) और [setSpaceAfter](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setSpaceAfter) कंटेनिंग पैराग्राफ के चारों ओर स्थान जोड़ते हैं, न कि एरे पंक्तियों के बीच। इसी प्रकार, [MathParagraph::setJustification](https://reference.aspose.com/slides/php-java/aspose.slides/mathparagraph/#setJustification) पूरे गणितीय पैराग्राफ को क्षैतिज रूप से स्थित करता है; यह एरे की ऊर्ध्वाधर संरेखण सेटिंग को नहीं बदलता।

## **त्रिकोणमितीय फ़ंक्शन जोड़ें**

जब आर्ग्युमेंट वर्तमान एलिमेंट हो और फ़ंक्शन नाम ज्ञात हो, तो [asArgumentOfFunction](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#asArgumentOfFunction) का उपयोग करें।

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

## **सबस्क्रिप्ट और सुपरसक्रिप्ट जोड़ें**

इंडेक्स और घात के लिये सबस्क्रिप्ट और सुपरसक्रिप्ट हेल्पर का उपयोग करें। जब इंडेक्स बेस के बाईं ओर दिखाई देने चाहिए, तो [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#setSubSuperscriptOnTheLeft) का उपयोग करें।

![एक बड़े अक्षर Y जिसमें बायीं ओर सबस्क्रिप्ट 1 और सुपरसक्रिप्ट n हैं](powerpoint-math-equations_9.png)

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

## **डिलिमीटर जोड़ें**

एक अभिव्यक्ति को डिलिमीटर के अंदर रखने के लिये [enclose](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#enclose) का उपयोग करें। कई एलिमेंट्स वाले डिलिमीटर अभिव्यक्तियों के लिये आप एक सेपरेटर अक्षर भी सेट कर सकते हैं।

![एक डिलिमीटर अभिव्यक्ति जिसमें x, y, और z को वर्टिकल बार द्वारा अलग किया गया है](powerpoint-math-equations_13.png)

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

### **डिलिमीटर का आकार और संरेखण**

[parentheses] को ऊँची ऑपरेण्ड के साथ मिलाने के लिये `true` को [setGrowToMatchOperandHeight](https://reference.aspose.com/slides/php-java/aspose.slides/mathdelimiter/#setGrowToMatchOperandHeight) में पास करें, या सामान्य आकार बनाए रखने के लिये `false` पास करें। दो में से एक [MathDelimiterShape](https://reference.aspose.com/slides/php-java/aspose.slides/mathdelimitershape/) मान के साथ [setDelimiterShape](https://reference.aspose.com/slides/php-java/aspose.slides/mathdelimiter/#setDelimiterShape) का प्रयोग करें। `Centered` कोष्ठकों को गणितीय अक्ष पर केंद्रित करता है, जबकि `Match` उन्हें समाहित सामग्री के अनुसार संरेखित करता है। दोनों सेटिंग केवल डिलिमीटर को प्रभावित करती हैं; अंदर की अभिव्यक्ति समान रहती है।

उदाहरण में `x` के घात के भीतर एक भिन्न रखा गया है, जिससे अभिव्यक्ति बेसलाइन से ऊपर अधिक विस्तारित होती है। चारों समीकरण समान कोष्ठक और फ़ॉन्ट सेटिंग्स का उपयोग करते हैं।

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

PowerPoint में, पंक्तियों की तुलना करके वृद्धि का प्रभाव देखें। शीर्ष पंक्ति में कोष्ठक घात को समाहित करने के लिये बढ़ते हैं और दोनों आकार समान दिखते हैं। निचली पंक्ति में वृद्धि बंद है। बायीं ओर छोटे कोष्ठक (`Centered`) बराबर संकेत के साथ संरेखित होते हैं, जबकि दायीं ओर (`Match`) अभिव्यक्ति के ऊपर स्थित होते हैं।

![PowerPoint में चार समीकरण जिनमें डिलिमीटर वृद्धि सक्षम और अक्षम है, तथा बायीं ओर Centered और दायीं ओर Match है](delimiter-sizing.png)

## **बॉर्डर बॉक्स जोड़ें**

भिन्न पर [toBorderBox](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#toBorderBox) को कॉल करके पूरी अभिव्यक्ति को फ्रेम किया जा सकता है। डिफ़ॉल्ट रूप में लौटाया गया [MathBorderBox](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/) चारों किनारे दिखाता है। व्यक्तिगत किनारों को हटाने के लिये [setHideTop](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setHideTop), [setHideBottom](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setHideBottom), [setHideLeft](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setHideLeft), और [setHideRight](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setHideRight) का उपयोग करें।

उदाहरण में एक ही भिन्न की छह कॉपी एक स्लाइड पर रखी गई हैं। रद्द करने के लिये सभी चार किनारे छिपाएँ और उठते हुए विकर्ण (↗) के लिये [setStrikethroughBottomLeftToTopRight](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setStrikethroughBottomLeftToTopRight) को `true` पास करें या गिरते हुए विकर्ण (↘) के लिये [setStrikethroughTopLeftToBottomRight](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setStrikethroughTopLeftToBottomRight) को `true` पास करें। आप किसी भी संयोजन के साथ [setStrikethroughHorizontal](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setStrikethroughHorizontal) या [setStrikethroughVertical](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setStrikethroughVertical) का भी प्रयोग कर सकते हैं।

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

![PowerPoint में छह संपादन योग्य भिन्न। शीर्ष पंक्ति: पूर्ण बॉर्डर, नीचे और बाएँ किनारे, उठता विकर्ण। निचली पंक्ति: गिरता विकर्ण, क्षैतिज स्ट्राइक, ऊर्ध्वाधर स्ट्राइक सहित पूर्ण बॉर्डर।](border-box-fractions.png)

इस भिन्न पर, क्षैतिज स्ट्राइक भिन्न रेखा को ओवरलैप करता है। ऊर्ध्वाधर स्ट्राइक न्यूमेरटर और डिनोमिनेटर दोनों को काटता है जबकि आसपास का बॉर्डर दिखता रहता है। ये रेखाएँ पूरी अभिव्यक्ति को सजाते हैं। सामान्य टेक्स्ट स्ट्राइकथ्रू व्यक्तिगत टेक्स्ट रन पर लागू होता है। PowerPoint में प्रस्तुति पुनः खोलने के बाद भी आप न्यूमेरटर और डिनोमिनेटर को स्वतंत्र रूप से संपादित कर सकते हैं।

## **टर्म समूहित करें**

एक अभिव्यक्ति के ऊपर या नीचे समूहिंग चिन्ह रखने के लिये [group](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#group) का उपयोग करें। समूहित टर्म को लेबल करने के लिये सीमा जोड़ें।

![x + y अभिव्यक्ति को नीचे लेबल के साथ समूहित किया गया है](powerpoint-math-equations_15.png)

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

## **गणितीय एलिमेंट्स का स्वरूप दें**

केवल तभी स्वरूपण हेल्पर का उपयोग करें जब वह फ़ॉर्मूला को स्पष्ट बनाता हो। उदाहरण के लिये, [overbar](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#overbar) एक गणितीय एलिमेंट के ऊपर बार लगाता है।

![overbar वाला गणितीय अभिव्यक्ति ABC](powerpoint-math-equations_14.png)

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

### **मौजूदा समीकरण में टेक्स्ट का स्वरूप दें**

एक मौजूदा समीकरण के पूरे टेक्स्ट को स्वरूपित करने के लिये, प्रत्येक गणितीय ब्लॉक के एलिमेंट ट्री को ट्रैवर्स करें। [MathElementBase::getChildren](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#getChildren) केवल तत्काल चाइल्ड लौटाता है, इसलिए फ्रैक्शन, स्क्रिप्ट, रैडिकल और अन्य नेस्टेड स्ट्रक्चर के भीतर टेक्स्ट तक पहुँचने के लिये इसे पुनरावर्ती रूप से कॉल करें। वर्तमान एलिमेंट के साथ-साथ उसके चाइल्ड को भी जांचें ताकि प्रारंभिक एलिमेंट, यदि वह [MathematicalText](https://reference.aspose.com/slides/php-java/aspose.slides/mathematicaltext/) है, शामिल हो सके।

यह उदाहरण मानता है कि `input.pptx` में `z = xᵢ / ∛y` जैसा समीकरण है, जिसमें न्यूमेरटर में सबस्क्रिप्ट और डिनोमिनेटर में रैडिकल है। केवल ब्लॉक की टॉप‑लेवल एलिमेंट्स को प्रोसेस करने से फ्रैक्शन के भीतर का टेक्स्ट छूट जाएगा। उदाहरण स्लाइड टेक्स्ट फ्रेम में गणितीय पोर्शन खोजता है, उनके ब्लॉक्स को [MathPortion::getMathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/#getMathParagraph) के द्वारा एक्सेस करता है, और प्रत्येक टेक्स्ट एलिमेंट के [getFormat](https://reference.aspose.com/slides/php-java/aspose.slides/mathematicaltext/#getFormat) मेथड के माध्यम से [setFontHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight) को 28 पॉइंट सेट करता है।

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

सहेजी गई प्रस्तुति प्रत्येक प्रोसेस्ड समीकरण के हर स्तर पर अपडेटेड टेक्स्ट स्वरूपण रखती है, जबकि मूल टेक्स्ट सामग्री और गणितीय संरचना अपरिवर्तित रहती है।

## **त्वरित संदर्भ**

| कार्य | मुख्य API |
| --- | --- |
| गणितीय टेक्स्ट बनाएं | [MathematicalText](https://reference.aspose.com/slides/php-java/aspose.slides/mathematicaltext/) |
| एलिमेंट्स को संयोजित करें | [join](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| भिन्न बनाएं | [divide](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| सुपरसक्रिप्ट या सबस्क्रिप्ट जोड़ें | [setSuperscript](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/), [setSubscript](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| फ़ंक्शन जोड़ें | [function](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/), [asArgumentOfFunction](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| रैडिकल जोड़ें | [radical](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| सीमाएँ जोड़ें | [setLowerLimit](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/), [setUpperLimit](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| बाएँ‑साइड स्क्रिप्ट जोड़ें | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| समेशन और इंटीग्रल जोड़ें | [nary](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/), [integral](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| मैट्रिसेज़ जोड़ें | [MathMatrix](https://reference.aspose.com/slides/php-java/aspose.slides/mathmatrix/) |
| समीकरण एरेज़ जोड़ें | [toMathArray](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| डिलिमीटर जोड़ें | [enclose](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| बार और बॉर्डर जोड़ें | [overbar](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/), [toBorderBox](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| टर्म समूहित करें | [group](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं मौजूदा PowerPoint समीकरण को संपादित कर सकता हूँ?**

हाँ। प्रस्तुति खोलें, उस शैप को खोजें जिसमें एक [MathPortion](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/) हो, [getMathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/#getMathParagraph) को कॉल करें, और उस पैराग्राफ में गणितीय ब्लॉक्स को अपडेट करें।

**क्या समीकरण को संपादन योग्य PowerPoint गणित के रूप में सहेजा जाता है?**

हाँ। PPTX में सहेजते समय, Aspose.Slides समीकरण को संपादन योग्य Office गणित सामग्री के रूप में लिखता है।

**क्या मैं समीकरणों को LaTeX में निर्यात कर सकता हूँ?**

हाँ। उसके [MathPortion](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/) से [MathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathparagraph/) प्राप्त करें, और सीधे निर्यात करने के लिये [MathParagraph::toLatex](https://reference.aspose.com/slides/php-java/aspose.slides/mathparagraph/#toLatex) को कॉल करें। पूर्ण उदाहरण के लिये देखें [Export Math Equations from Presentations in PHP via Java](/slides/hi/php-java/exporting-math-equations/#export-math-equations-to-latex).