---
title: PowerPoint प्रस्तुतियों में PHP के साथ गणितीय समीकरण जोड़ें
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
description: "Aspose.Slides for PHP via Java के साथ PowerPoint PPT और PPTX में गणितीय समीकरण सम्मिलित और संपादित करें, OMML, स्वरूपण नियंत्रण, और स्पष्ट PHP कोड उदाहरणों का समर्थन करता है।"
---
## **परिचय**

PowerPoint समीकरणों को Office Math Markup Language (OMML) में संग्रहित करता है। Aspose.Slides for PHP via Java के साथ, आप कार्यक्रमात्मक रूप से वही प्रकार की गणितीय सामग्री बना सकते हैं: अंश, मूल, फ़ंक्शन, सीमाएँ, N-ary ऑपरेटर, मैट्रिक्स, ऐरे, और स्वरूपित गणित ब्लॉक्स।

In PowerPoint, users normally add equations from **Insert > Equation**:

![PowerPoint Insert टैब जिसमें Equation कमांड चयनित है](powerpoint-math-equations_1.png)

परिणाम स्लाइड पर संपादित करने योग्य गणितीय टेक्स्ट होता है:

![PowerPoint स्लाइड जिसमें संपादित करने योग्य गणितीय समीकरण है](powerpoint-math-equations_2.png)

Aspose.Slides उस गणितीय टेक्स्ट को तीन मुख्य वस्तुओं के माध्यम से बनाता है:

- एक गणितीय आकार, जिसे [addMathShape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shapecollection/#addMathShape) से बनाया जाता है, वह आकार है जिसमें समीकरण रहता है।
- [MathPortion](https://reference.aspose.com/slides/hi/php-java/aspose.slides/mathportion/) आकार के टेक्स्ट फ़्रेम के भीतर गणितीय सामग्री संग्रहीत करता है।
- [MathParagraph](https://reference.aspose.com/slides/hi/php-java/aspose.slides/mathparagraph/) एक या अधिक [MathBlock](https://reference.aspose.com/slides/hi/php-java/aspose.slides/mathblock/) वस्तुओं को सम्मिलित करता है।

नीचे अधिकांश उदाहरणों में कोड को छोटा और पठनीय रखने के लिए [MathematicalText](https://reference.aspose.com/slides/hi/php-java/aspose.slides/mathematicaltext/) और [MathElementBase](https://reference.aspose.com/slides/hi/php-java/aspose.slides/mathelementbase/) के फ़्लुएंट मेथड्स का उपयोग किया जाता है।

MathML निर्यात परिदृश्यों के लिए देखें [Export Math Equations from Presentations in PHP via Java](/slides/hi/php-java/exporting-math-equations/).

## **समीकरण बनाएं**

यह उदाहरण एक गणितीय आकार बनाता है और पाइथागोरस प्रमेय जोड़ता है:

![c वर्ग बराबर a वर्ग प्लस b वर्ग](powerpoint-math-equations_3.png)

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

{{% alert color="primary" %}}
`addMathShape` एक ऐसा आकार बनाता है जिसमें पहले से ही एक गणितीय पैराग्राफ होता है। पहले `MathPortion` तक पहुँचें, उसका `MathParagraph` प्राप्त करें, और उसमें गणितीय ब्लॉक्स या गणितीय तत्व जोड़ें।
{{% /alert %}}

## **अंश जोड़ें**

`divide` का उपयोग करके अंश बनाएं। आप [MathFractionTypes](https://reference.aspose.com/slides/hi/php-java/aspose.slides/mathfractiontypes/) से अंश शैली चुन सकते हैं।

![एक तिरछा गणितीय अंश जिसमें एक को x से विभाजित दिखाया गया है](powerpoint-math-equations_4.png)

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

स्टैक्ड अंश के लिए, `MathFractionTypes::Bar` का उपयोग करें:

```php
$stackedFraction = (new MathematicalText("x + 1"))->divide("y - 1", MathFractionTypes::Bar);
```

## **मूल जोड़ें**

`radical` का उपयोग करके वर्गमूल, घनमूल, या अन्य मूल बनाएं। वर्तमान तत्व आधार बन जाता है, और तर्क डिग्री बन जाता है।

![एक n‑थ मूल अभिव्यक्ति जिसमें x मूल चिह्न के नीचे है](powerpoint-math-equations_5.png)

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

फ़ंक्शन जैसे `sin(x)`, `log(x)`, या कस्टम फ़ंक्शन नामों के लिए [`asArgumentOfFunction`](https://reference.aspose.com/slides/hi/php-java/aspose.slides/mathelementbase/) या [`function`](https://reference.aspose.com/slides/hi/php-java/aspose.slides/mathelementbase/) का उपयोग करें। सीमाओं के लिए, `lim` को एक [MathLimit](https://reference.aspose.com/slides/hi/php-java/aspose.slides/mathlimit/) में रखें या [`setLowerLimit`](https://reference.aspose.com/slides/hi/php-java/aspose.slides/mathelementbase/) का उपयोग करें।

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

कस्टम फ़ंक्शन नाम के लिए, फ़ंक्शन नाम को वर्तमान तत्व बनाएं:

```php
$customFunction = (new MathematicalText("f"))->function("x + 1");
```

## **N-ary ऑपरेटर और इंटीग्रल जोड़ें**

योग, यूनियन, इंटरसेक्शन और अन्य बड़े ऑपरेटरों के लिए [`nary`](https://reference.aspose.com/slides/hi/php-java/aspose.slides/mathelementbase/) का उपयोग करें। इंटीग्रल के लिए [`integral`](https://reference.aspose.com/slides/hi/php-java/aspose.slides/mathelementbase/) का प्रयोग करें। दोनों विधियों से आप निचली और ऊपरी सीमाएँ सेट कर सकते हैं।

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

N-ary ऑपरेटर बड़े ऑपरेटरों के लिए होते हैं जिनमें वैकल्पिक सीमाएँ हो सकती हैं। सरल ऑपरेटर जैसे `+`, `-`, और `=` आमतौर पर `MathematicalText` के रूप में जोड़े जाते हैं और अभिव्यक्ति में सम्मिलित होते हैं।

इंटीग्रल के लिए, `integral` का उपयोग करें:

```php
$integralBase = (new MathematicalText("x"))->join((new MathematicalText("dx"))->toBox());
$integral = $integralBase->integral(MathIntegralTypes::Simple, "0", "1");
```

## **मैट्रिक्स जोड़ें**

पंक्तियों और स्तंभों के लिए [MathMatrix](https://reference.aspose.com/slides/hi/php-java/aspose.slides/mathmatrix/) का उपयोग करें। मैट्रिक्स में डिफॉल्ट रूप से ब्रैकेट नहीं होते, इसलिए यदि आपको कोष्ठक, ब्रेस या कर्ली ब्रेसेस चाहिए तो मैट्रिक्स को घेरें।

![एक दो-रो वाला गणितीय मैट्रिक्स जिसमें एक खाली सेल है](powerpoint-math-equations_10.png)

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

## **समीकरण एरेज जोड़ें**

जब आपको संरेखित समीकरणों या अभिव्यक्तियों की ऊर्ध्वाधर स्टैक चाहिए, तो [`toMathArray`](https://reference.aspose.com/slides/hi/php-java/aspose.slides/mathelementbase/) का उपयोग करें।

![ऊपर x नीचे y के साथ एक ऊर्ध्वाधर गणितीय एरे](powerpoint-math-equations_11.png)

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

जब तर्क वर्तमान तत्व है और फ़ंक्शन नाम ज्ञात है, तो [`asArgumentOfFunction`](https://reference.aspose.com/slides/hi/php-java/aspose.slides/mathelementbase/) का उपयोग करें।

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

इंडेक्स और पावर के लिए सबस्क्रिप्ट और सुपरस्क्रिप्ट हेल्पर का उपयोग करें। जब इंडेक्स बेस के बाएँ side पर दिखना आवश्यक हो, तो [`setSubSuperscriptOnTheLeft`](https://reference.aspose.com/slides/hi/php-java/aspose.slides/mathelementbase/) का उपयोग करें।

![बड़ा Y बाएँ पक्ष पर सबस्क्रिप्ट 1 और सुपरस्क्रिप्ट n के साथ](powerpoint-math-equations_9.png)

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

एक अभिव्यक्ति को डिलिमिटर्स के भीतर रखने के लिए [`enclose`](https://reference.aspose.com/slides/hi/php-java/aspose.slides/mathelementbase/) का उपयोग करें। आप उन डिलिमिटर अभिव्यक्तियों के लिए एक सेपरेटर अक्षर भी सेट कर सकते हैं जिनमें कई तत्व हों।

![x, y, और z को ऊर्ध्वाधर बार द्वारा अलग किए गए डिलिमिटर अभिव्यक्ति](powerpoint-math-equations_13.png)

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

## **बॉर्डर बॉक्स जोड़ें**

जब समीकरण को स्वयं फ्रेम किया जाना चाहिए, तो [`toBorderBox`](https://reference.aspose.com/slides/hi/php-java/aspose.slides/mathelementbase/) का उपयोग करें।

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

एक अभिव्यक्ति के ऊपर या नीचे ग्रुपिंग कैरेक्टर रखने के लिए [`group`](https://reference.aspose.com/slides/hi/php-java/aspose.slides/mathelementbase/) का उपयोग करें। समूहित शर्तों को लेबल करने के लिए एक सीमा जोड़ें।

![x प्लस y अभिव्यक्ति को लेबल 'any text' के साथ नीचे समूहित किया गया](powerpoint-math-equations_15.png)

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

## **गणितीय तत्वों को स्वरूपित करें**

फ़ॉर्मेटिंग हेल्पर केवल तब उपयोग करें जब वे फ़ॉर्मूले को स्पष्ट करें। उदाहरण के लिए, [`overbar`](https://reference.aspose.com/slides/hi/php-java/aspose.slides/mathelementbase/) एक गणितीय तत्व के ऊपर बार रखता है।

![ABC अभिव्यक्ति के ऊपर overbar](powerpoint-math-equations_14.png)

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

## **त्वरित संदर्भ**

| कार्य | मुख्य API |
| --- | --- |
| गणितीय टेक्स्ट बनाएं | [MathematicalText](https://reference.aspose.com/slides/hi/php-java/aspose.slides/mathematicaltext/) |
| तत्वों को संयोजित करें | [join](https://reference.aspose.com/slides/hi/php-java/aspose.slides/mathelementbase/) |
| अंश बनाएं | [divide](https://reference.aspose.com/slides/hi/php-java/aspose.slides/mathelementbase/) |
| सुपरस्क्रिप्ट या सबस्क्रिप्ट जोड़ें | [setSuperscript](https://reference.aspose.com/slides/hi/php-java/aspose.slides/mathelementbase/), [setSubscript](https://reference.aspose.com/slides/hi/php-java/aspose.slides/mathelementbase/) |
| फ़ंक्शन जोड़ें | [function](https://reference.aspose.com/slides/hi/php-java/aspose.slides/mathelementbase/), [asArgumentOfFunction](https://reference.aspose.com/slides/hi/php-java/aspose.slides/mathelementbase/) |
| मूल जोड़ें | [radical](https://reference.aspose.com/slides/hi/php-java/aspose.slides/mathelementbase/) |
| सीमाएँ जोड़ें | [setLowerLimit](https://reference.aspose.com/slides/hi/php-java/aspose.slides/mathelementbase/), [setUpperLimit](https://reference.aspose.com/slides/hi/php-java/aspose.slides/mathelementbase/) |
| बाएँ‑साइड स्क्रिप्ट जोड़ें | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/hi/php-java/aspose.slides/mathelementbase/) |
| योग और इंटीग्रल जोड़ें | [nary](https://reference.aspose.com/slides/hi/php-java/aspose.slides/mathelementbase/), [integral](https://reference.aspose.com/slides/hi/php-java/aspose.slides/mathelementbase/) |
| मैट्रिक्स जोड़ें | [MathMatrix](https://reference.aspose.com/slides/hi/php-java/aspose.slides/mathmatrix/) |
| समीकरण एरेज जोड़ें | [toMathArray](https://reference.aspose.com/slides/hi/php-java/aspose.slides/mathelementbase/) |
| डिलिमिटर जोड़ें | [enclose](https://reference.aspose.com/slides/hi/php-java/aspose.slides/mathelementbase/) |
| बार और बॉर्डर जोड़ें | [overbar](https://reference.aspose.com/slides/hi/php-java/aspose.slides/mathelementbase/), [toBorderBox](https://reference.aspose.com/slides/hi/php-java/aspose.slides/mathelementbase/) |
| शर्तों को समूहित करें | [group](https://reference.aspose.com/slides/hi/php-java/aspose.slides/mathelementbase/) |

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं मौजूदा PowerPoint समीकरण को संपादित कर सकता हूँ?**

हां। प्रस्तुति खोलें, वह आकार खोजें जिसमें `MathPortion` हो, उसका `MathParagraph` प्राप्त करें, और उस पैराग्राफ में गणितीय ब्लॉक्स को अपडेट करें।

**क्या समीकरण संपादित करने योग्य PowerPoint गणित के रूप में सहेजे जाते हैं?**

हां। जब आप PPTX में सहेजते हैं, तो Aspose.Slides समीकरण को संपादित करने योग्य Office गणित सामग्री के रूप में लिखता है।

**क्या मैं समीकरणों को LaTeX में निर्यात कर सकता हूँ?**

Aspose.Slides गणितीय समीकरणों को MathML में निर्यात करता है। यदि आपको LaTeX चाहिए, तो पहले MathML में निर्यात करें और फिर किसी ऐसे टूल से MathML को परिवर्तित करें जो आपके लक्षित LaTeX डायलेक्ट का समर्थन करता हो।