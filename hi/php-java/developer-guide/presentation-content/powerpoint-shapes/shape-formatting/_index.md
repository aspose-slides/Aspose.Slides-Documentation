---
title: PHP में PowerPoint शैपे फ़ॉर्मेट करें
linktitle: शैपे फ़ॉर्मेटिंग
type: docs
weight: 20
url: /hi/php-java/shape-formatting/
keywords:
- शैपे फ़ॉर्मेट
- लाइन फ़ॉर्मेट
- स्केच प्रभाव
- स्केच शैपे लाइन
- जॉइन शैली फ़ॉर्मेट
- ग्रेडिएंट फ़िल
- पैटर्न फ़िल
- पिक्चर फ़िल
- टेक्सचर फ़िल
- सॉलिड कलर फ़िल
- शैपे पारदर्शिता
- ब्लैक‑एंड‑व्हाइट शैपे रेंडरिंग
- ग्रेस्केल शैपे रेंडरिंग
- शैपे घुमाएँ
- 3D बिवेल प्रभाव
- 3D घुमाव प्रभाव
- फ़ॉर्मेट रीसेट
- PowerPoint
- प्रेज़ेंटेशन
- PHP
- Aspose.Slides
description: "Aspose.Slides का उपयोग करके PHP में PowerPoint शैपे को फ़ॉर्मेट करना सीखें—PPT, PPTX और ODP फ़ाइलों के लिए फ़िल, लाइन और इफ़ेक्ट शैलियों को सटीकता और पूर्ण नियंत्रण के साथ सेट करें।"
---
## **परिचय**

PowerPoint में आप स्लाइड्स में शैपे जोड़ सकते हैं। चूंकि शैपे रेखाओं से बनी होती हैं, आप उनके रूपरेखा को संशोधित कर या प्रभाव लागू कर स्वरूपित कर सकते हैं। अतिरिक्त रूप से, आप शैपे को इस तरह सेट कर सकते हैं कि उनके आंतरिक भाग कैसे भरे जाएँ, इसे नियंत्रित करने वाले सेटिंग्स निर्दिष्ट करके।

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for PHP via Java क्लास और मेथड प्रदान करता है जो आपको PowerPoint में उपलब्ध समान विकल्पों का उपयोग करके शैपे स्वरूपित करने की अनुमति देता है।

## **रेखाओं को स्वरूपित करें**

Aspose.Slides का उपयोग करके आप किसी शैपे के लिए एक कस्टम लाइन स्टाइल निर्दिष्ट कर सकते हैं। नीचे दी गई चरणों में प्रक्रिया दर्शाई गई है:

1. एक [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) क्लास का इंस्टेंस बनाएँ।  
1. उसके इंडेक्स द्वारा एक स्लाइड का रेफ़रेंस प्राप्त करें।  
1. स्लाइड में एक [AutoShape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/autoshape/) जोड़ें।  
1. शैपे की [line style](https://reference.aspose.com/slides/hi/php-java/aspose.slides/linestyle/) सेट करें।  
1. लाइन की चौड़ाई सेट करें।  
1. लाइन की [dash style](https://reference.aspose.com/slides/hi/php-java/aspose.slides/linedashstyle/) सेट करें।  
1. शैपे के लिए लाइन का रंग सेट करें।  
1. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

नीचे दिया गया PHP कोड एक आयताकार `AutoShape` को स्वरूपित करने का तरीका दर्शाता है:

```php
// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का इंस्टेंस बनाएं।
$presentation = new Presentation();
try {
    // पहला स्लाइड प्राप्त करें।
    $slide = $presentation->getSlides()->get_Item(0);

    // Rectangle प्रकार का ऑटो शैपे जोड़ें।
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 150, 75);

    // आयताकार शैपे के लिए फ़िल रंग सेट करें।
    $shape->getFillFormat()->setFillType(FillType::NoFill);

    // आयताकार की लाइनों पर फ़ॉर्मेटिंग लागू करें।
    $shape->getLineFormat()->setStyle(LineStyle::ThickThin);
    $shape->getLineFormat()->setWidth(7);
    $shape->getLineFormat()->setDashStyle(LineDashStyle::Dash);

    // आयताकार की लाइन के लिए रंग सेट करें।
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);

    // PPTX फ़ाइल को डिस्क पर सहेजें।
    $presentation->save("formatted_lines.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

परिणाम:

![The formatted lines in the presentation](formatted-lines.png)

## **शैपे रेखाओं पर स्केच प्रभाव लागू करें**

एक स्केच प्रभाव शैपे लाइन को हाथ से खींचा हुआ दिखाता है। रेखा सेटिंग्स तक पहुंचने के लिए [Shape.getLineFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shape/) का उपयोग करें, स्केच सेटिंग्स तक पहुंचने के लिए [LineFormat.getSketchFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/lineformat/) का उपयोग करें, और [SketchFormat.setSketchType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/sketchformat/) का उपयोग करके [LineSketchType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/linesketchtype/) एन्ह्यूमरेशन से मान चुनें।

नीचे दिया गया PHP कोड एक [LineSketchType.Curved](https://reference.aspose.com/slides/hi/php-java/aspose.slides/linesketchtype/) प्रभाव लागू करने, स्पष्ट रूप से असाइन किया गया मान पढ़ने, और [LineSketchType.None](https://reference.aspose.com/slides/hi/php-java/aspose.slides/linesketchtype/) के साथ प्रभाव हटाने का तरीका दिखाता है:

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);

    // शैपे के लाइन फ़ॉर्मेट और उसके स्केच फ़ॉर्मेट तक पहुंचें।
    $sketchFormat = $shape->getLineFormat()->getSketchFormat();

    // एक स्केच प्रभाव लागू करें।
    $sketchFormat->setSketchType(LineSketchType::Curved);

    // शैपे को सीधे असाइन किए गए स्केच प्रभाव को पढ़ें।
    $explicitSketchType = $sketchFormat->getSketchType();
    echo "Explicit sketch type: " . $explicitSketchType . PHP_EOL;

    // स्केच प्रभाव हटाएँ।
    $sketchFormat->setSketchType(LineSketchType::None);
} finally {
    $presentation->dispose();
}
```

[SketchFormat.getSketchType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/sketchformat/) द्वारा लौटाया गया मान शैपे को सीधे असाइन किए गए सेटिंग को दर्शाता है। यदि लाइन फ़ॉर्मेटिंग थीम, मास्टर स्लाइड, या लेआउट स्लाइड से विरासत में ली जा सकती है, तो [LineFormat.getEffective](https://reference.aspose.com/slides/hi/php-java/aspose.slides/lineformat/) का उपयोग करें, लौटाए गए ऑब्जेक्ट की `getSketchFormat` मेथड को कॉल करें, और उसका `getSketchType` मान पढ़ें। प्रभावी मान वह फ़ॉर्मेटिंग दर्शाता है जो विरासत हल होने के बाद वास्तव में लागू होता है:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $lineFormat = $shape->getLineFormat();

    $explicitSketchType = $lineFormat->getSketchFormat()->getSketchType();
    $effectiveLineFormat = $lineFormat->getEffective();
    $effectiveSketchType = $effectiveLineFormat->getSketchFormat()->getSketchType();

    echo "Explicit sketch type: " . $explicitSketchType . PHP_EOL;
    echo "Effective sketch type: " . $effectiveSketchType . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **जॉइन स्टाइल स्वरूपित करें**

तीन जॉइन प्रकार विकल्प हैं:

* Round  
* Miter  
* Bevel  

डिफ़ॉल्ट रूप से, जब PowerPoint दो रेखाओं को कोण पर जोड़ता है (जैसे शैपे के कोने पर), यह **Round** सेटिंग का उपयोग करता है। हालांकि, यदि आप तीखे कोण वाले शैपे बना रहे हैं, तो आप **Miter** विकल्प को पसंद कर सकते हैं।

![The join style in the presentation](join-style-powerpoint.png)

नीचे दिया गया PHP कोड दिखाता है कि ऊपर दी गई छवि में दिखाए गए तीन आयताकार (Miter, Bevel, और Round जॉइन प्रकार सेटिंग्स) कैसे बनाए गए:

```php
// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का इंस्टेंस बनाएं।
$presentation = new Presentation();
try {
    // पहला स्लाइड प्राप्त करें।
    $slide = $presentation->getSlides()->get_Item(0);

    // Rectangle प्रकार के तीन ऑटो शैपे जोड़ें।
    $shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 150, 75);
    $shape2 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 210, 20, 150, 75);
    $shape3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 135, 150, 75);

    // प्रत्येक आयताकार शैपे के लिए फ़िल रंग सेट करें।
    $shape1->getFillFormat()->setFillType(FillType::Solid);
    $shape1->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $shape2->getFillFormat()->setFillType(FillType::Solid);
    $shape2->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $shape3->getFillFormat()->setFillType(FillType::Solid);
    $shape3->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);

    // लाइन की चौड़ाई सेट करें।
    $shape1->getLineFormat()->setWidth(15);
    $shape2->getLineFormat()->setWidth(15);
    $shape3->getLineFormat()->setWidth(15);

    // प्रत्येक आयताकार की लाइन के लिए रंग सेट करें।
    $shape1->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape1->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $shape2->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape2->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $shape3->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape3->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);

    // जॉइन शैली सेट करें।
    $shape1->getLineFormat()->setJoinStyle(LineJoinStyle::Miter);
    $shape2->getLineFormat()->setJoinStyle(LineJoinStyle::Bevel);
    $shape3->getLineFormat()->setJoinStyle(LineJoinStyle::Round);

    // प्रत्येक आयताकार में टेक्स्ट जोड़ें।
    $shape1->getTextFrame()->setText("Miter Join Style");
    $shape2->getTextFrame()->setText("Bevel Join Style");
    $shape3->getTextFrame()->setText("Round Join Style");

    // PPTX फ़ाइल को डिस्क पर सहेजें।
    $presentation->save("join_styles.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **ग्रेडिएंट फ़िल**

PowerPoint में ग्रेडिएंट फ़िल एक फ़ॉर्मेटिंग विकल्प है जो आपको शैपे पर लगातार रंग मिश्रण लागू करने देता है। उदाहरण के तौर पर, आप दो या अधिक रंग इस प्रकार लागू कर सकते हैं कि एक धीरे‑धीरे दूसरे में मिलते जाए।

Aspose.Slides का उपयोग करके शैपे पर ग्रेडिएंट फ़िल लागू करने के चरण:

1. एक [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) क्लास का इंस्टेंस बनाएँ।  
1. उसके इंडेक्स द्वारा एक स्लाइड का रेफ़रेंस प्राप्त करें।  
1. स्लाइड में एक [AutoShape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/autoshape/) जोड़ें।  
1. शैपे की [FillType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/filltype/) को `Gradient` सेट करें।  
1. ग्रेडिएंट स्टॉप कलेक्शन द्वारा प्रदान किए गए `add` मेथड का उपयोग करके दो इच्छित रंगों को परिभाषित स्थितियों के साथ जोड़ें, जिसे [GradientFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/gradientformat/) क्लास एक्सपोज़ करता है।  
1. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

नीचे दिया गया PHP कोड एक दीर्घवृत्त पर ग्रेडिएंट फ़िल प्रभाव लागू करने का तरीका दर्शाता है:

```php
// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का इंस्टेंस बनाएं।
$presentation = new Presentation();
try {
    // पहला स्लाइड प्राप्त करें।
    $slide = $presentation->getSlides()->get_Item(0);

    // Ellipse प्रकार का ऑटो शैपे जोड़ें।
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 50, 150, 75);

    // एलिप्स पर ग्रेडिएंट फ़ॉर्मेटिंग लागू करें।
    $shape->getFillFormat()->setFillType(FillType::Gradient);
    $shape->getFillFormat()->getGradientFormat()->setGradientShape(GradientShape::Linear);

    // ग्रेडिएंट की दिशा सेट करें।
    $shape->getFillFormat()->getGradientFormat()->setGradientDirection(GradientDirection::FromCorner2);

    // दो ग्रेडिएंट स्टॉप जोड़ें।
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->addPresetColor(1.0, PresetColor::Purple);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->addPresetColor(0, PresetColor::Red);

    // PPTX फ़ाइल को डिस्क पर सहेजें।
    $presentation->save("gradient_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

परिणाम:

![The ellipse with gradient fill](gradient-fill.png)

## **पैटर्न फ़िल**

PowerPoint में पैटर्न फ़िल एक फ़ॉर्मेटिंग विकल्प है जो आपको दो‑रंगी डिज़ाइन—जैसे बिंदु, स्ट्राइप, क्रॉसहैच, या चेक—शैपे पर लागू करने देता है। आप पैटर्न के अग्रभूमि और पृष्ठभूमि के लिए कस्टम रंग चुन सकते हैं।

Aspose.Slides 45 से अधिक पूर्वनिर्धारित पैटर्न स्टाइल प्रदान करता है जिन्हें आप शैपे पर लागू करके अपनी प्रस्तुतियों की दृश्य आकर्षण बढ़ा सकते हैं। पूर्वनिर्धारित पैटर्न चुनने के बाद भी आप उसे प्रयोग करने वाले सटीक रंग निर्दिष्ट कर सकते हैं।

निचे दिया गया चरणों में पैटर्न फ़िल लागू करने का तरीका है:

1. एक [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) क्लास का इंस्टेंस बनाएँ।  
1. उसके इंडेक्स द्वारा एक स्लाइड का रेफ़रेंस प्राप्त करें।  
1. स्लाइड में एक [AutoShape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/autoshape/) जोड़ें।  
1. शैпе की [FillType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/filltype/) को `Pattern` सेट करें।  
1. पूर्वनिर्धारित विकल्पों में से एक पैटर्न स्टाइल चुनें।  
1. पैटर्न की [Background Color](https://reference.aspose.com/slides/hi/php-java/aspose.slides/patternformat/#getBackColor) सेट करें।  
1. पैटर्न की [Foreground Color](https://reference.aspose.com/slides/hi/php-java/aspose.slides/patternformat/#getForeColor) सेट करें।  
1. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

नीचे दिया गया PHP कोड एक आयत पर पैटर्न फ़िल लागू करने का तरीका दर्शाता है:

```php
// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का इंस्टेंस बनाएं।
$presentation = new Presentation();
try {
    // पहला स्लाइड प्राप्त करें।
    $slide = $presentation->getSlides()->get_Item(0);

    // Rectangle प्रकार का ऑटो शैपे जोड़ें।
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // फ़िल प्रकार को Pattern पर सेट करें।
    $shape->getFillFormat()->setFillType(FillType::Pattern);

    // पैटर्न शैली सेट करें।
    $shape->getFillFormat()->getPatternFormat()->setPatternStyle(PatternStyle::Trellis);

    // पैटर्न की पृष्ठभूमि और अग्रभूमि रंग सेट करें।
    $shape->getFillFormat()->getPatternFormat()->getBackColor()->setColor(java("java.awt.Color")->LIGHT_GRAY);
    $shape->getFillFormat()->getPatternFormat()->getForeColor()->setColor(java("java.awt.Color")->YELLOW);

    // PPTX फ़ाइल को डिस्क पर सहेजें।
    $presentation->save("pattern_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

परिणाम:

![The rectangle with pattern fill](pattern-fill.png)

## **पिक्चर फ़िल**

PowerPoint में पिक्चर फ़िल एक फ़ॉर्मेटिंग विकल्प है जो आपको शैपे के अंदर एक छवि सम्मिलित करने देता है—व्यावहारिक रूप से छवि को शैपे की पृष्ठभूमि के रूप में उपयोग करता है।

Aspose.Slides का उपयोग करके शैपे पर पिक्चर फ़िल लागू करने के चरण:

1. एक [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) क्लास का इंस्टेंस बनाएँ।  
1. उसके इंडेक्स द्वारा एक स्लाइड का रेफ़रेंस प्राप्त करें।  
1. स्लाइड में एक [AutoShape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/autoshape/) जोड़ें।  
1. शैपे की [FillType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/filltype/) को `Picture` सेट करें।  
1. पिक्चर फ़िल मोड को `Tile` (या कोई अन्य पसंदीदा मोड) सेट करें।  
1. उपयोग करने वाली छवि से एक [PPImage](https://reference.aspose.com/slides/hi/php-java/aspose.slides/ppimage/) ऑब्जेक्ट बनाएं।  
1. छवि को `SlidesPicture.setImage` मेथड को पास करें।  
1. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

मान लें कि हमारे पास "lotus.png" फ़ाइल है जिसमें निम्नलिखित चित्र है:

![The lotus picture](lotus.png)

नीचे दिया गया PHP कोड शैपे को पिक्चर से भरने का तरीका दिखाता है:

```php
// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का इंस्टेंस बनाएं।
$presentation = new Presentation();
try {
    // पहला स्लाइड प्राप्त करें।
    $slide = $presentation->getSlides()->get_Item(0);

    // Rectangle प्रकार का ऑटो शैपे जोड़ें।
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 255, 130);

    // फ़िल प्रकार को Picture पर सेट करें।
    $shape->getFillFormat()->setFillType(FillType::Picture);

    // पिक्चर फ़िल मोड सेट करें।
    $shape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Tile);

    // एक चित्र लोड करें और इसे प्रस्तुति संसाधनों में जोड़ें।
    $image = Images::fromFile("lotus.png");
    $picture = $presentation->getImages()->addImage($image);
    $image->dispose();

    // चित्र सेट करें।
    $shape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);

    // PPTX फ़ाइल को डिस्क पर सहेजें।
    $presentation->save("picture_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

परिणाम:

![The shape with picture fill](picture-fill.png)

### **टाइल पिक्चर को टेक्सचर के रूप में उपयोग करें**

यदि आप टाइल्ड पिक्चर को टेक्सचर के रूप में सेट करना और टाइलिंग व्यवहार को अनुकूलित करना चाहते हैं, तो आप [PictureFillFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/picturefillformat/) क्लास की निम्नलिखित मेथड का उपयोग कर सकते हैं:

- [setPictureFillMode](https://reference.aspose.com/slides/hi/php-java/aspose.slides/picturefillformat/#setPictureFillMode): पिक्चर फ़िल मोड सेट करता है—`Tile` या `Stretch`।  
- [setTileAlignment](https://reference.aspose.com/slides/hi/php-java/aspose.slides/picturefillformat/#setTileAlignment): शैपे के भीतर टाइल की संरेखण निर्दिष्ट करता है।  
- [setTileFlip](https://reference.aspose.com/slides/hi/php-java/aspose.slides/picturefillformat/#setTileFlip): टाइल को क्षैतिज, लंबवत या दोनों दिशा में फ़्लिप करने को नियंत्रित करता है।  
- [setTileOffsetX](https://reference.aspose.com/slides/hi/php-java/aspose.slides/picturefillformat/#setTileOffsetX): शैपे के मूल बिंदु से टाइल का क्षैतिज ऑफ़सेट (पॉइंट्स में) सेट करता है।  
- [setTileOffsetY](https://reference.aspose.com/slides/hi/php-java/aspose.slides/picturefillformat/#setTileOffsetY): शैपे के मूल बिंदु से टाइल का लंबवत ऑफ़सेट (पॉइंट्स में) सेट करता है।  
- [setTileScaleX](https://reference.aspose.com/slides/hi/php-java/aspose.slides/picturefillformat/#setTileScaleX): टाइल का क्षैतिज स्केल प्रतिशत में परिभाषित करता है।  
- [setTileScaleY](https://reference.aspose.com/slides/hi/php-java/aspose.slides/picturefillformat/#setTileScaleY): टाइल का लंबवत स्केल प्रतिशत में परिभाषित करता है।

नीचे दिया गया कोड नमूना टाइल्ड पिक्चर फ़िल के साथ एक आयत शैपे जोड़ने और टाइल विकल्पों को कॉन्फ़िगर करने का तरीका दर्शाता है:

```php
// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का इंस्टेंस बनाएं।
$presentation = new Presentation();
try {
    // पहला स्लाइड प्राप्त करें।
    $firstSlide = $presentation->getSlides()->get_Item(0);

    // एक आयताकार ऑटो शैपे जोड़ें।
    $shape = $firstSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 190, 95);

    // शैपे का फ़िल प्रकार Picture पर सेट करें।
    $shape->getFillFormat()->setFillType(FillType::Picture);

    // छवि लोड करें और इसे प्रस्तुति संसाधनों में जोड़ें।
    $sourceImage = Images::fromFile("lotus.png");
    $presentationImage = $presentation->getImages()->addImage($sourceImage);
    $sourceImage->dispose();

    // छवि को शैपे को असाइन करें।
    $pictureFillFormat = $shape->getFillFormat()->getPictureFillFormat();
    $pictureFillFormat->getPicture()->setImage($presentationImage);

    // पिक्चर फ़िल मोड और टाइलिंग गुण कॉन्फ़िगर करें।
    $pictureFillFormat->setPictureFillMode(PictureFillMode::Tile);
    $pictureFillFormat->setTileOffsetX(-32);
    $pictureFillFormat->setTileOffsetY(-32);
    $pictureFillFormat->setTileScaleX(50);
    $pictureFillFormat->setTileScaleY(50);
    $pictureFillFormat->setTileAlignment(RectangleAlignment::BottomRight);
    $pictureFillFormat->setTileFlip(TileFlip::FlipBoth);

    // PPTX फ़ाइल को डिस्क पर सहेजें।
    $presentation->save("tile.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

परिणाम:

![The tile options](tile-options.png)

## **सॉलिड कलर फ़िल**

PowerPoint में सॉलिड कलर फ़िल एक फ़ॉर्मेटिंग विकल्प है जो शैपे को एकल समान रंग से भरता है। यह साधारण पृष्ठभूमि रंग बिना किसी ग्रेडिएंट, टेक्सचर या पैटर्न के लागू किया जाता है।

Aspose.Slides का उपयोग करके शैपे पर सॉलिड कलर फ़िल लागू करने के चरण:

1. एक [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) क्लास का इंस्टेंस बनाएँ।  
1. उसके इंडेक्स द्वारा एक स्लाइड का रेफ़रेंस प्राप्त करें।  
1. स्लाइड में एक [AutoShape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/autoshape/) जोड़ें।  
1. शैपे की [FillType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/filltype/) को `Solid` सेट करें।  
1. शैपे को अपनी पसंदीदा फ़िल रंग सौंपें।  
1. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

नीचे दिया गया PHP कोड PowerPoint स्लाइड में एक आयत पर सॉलिड कलर फ़िल लागू करने का तरीका दर्शाता है:

```php
// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का इंस्टेंस बनाएं।
$presentation = new Presentation();
try {
    // पहला स्लाइड प्राप्त करें।
    $slide = $presentation->getSlides()->get_Item(0);

    // Rectangle प्रकार का ऑटो शैपे जोड़ें।
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // फ़िल प्रकार को Solid पर सेट करें।
    $shape->getFillFormat()->setFillType(FillType::Solid);

    // फ़िल रंग सेट करें।
    $shape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);

    // PPTX फ़ाइल को डिस्क पर सहेजें।
    $presentation->save("solid_color_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

परिणाम:

![The shape with solid color fill](solid-color-fill.png)

## **पारदर्शिता सेट करें**

PowerPoint में जब आप शैपे पर सॉलिड कलर, ग्रेडिएंट, पिक्चर या टेक्सचर फ़िल लागू करते हैं, तो आप फ़िल की अपारदर्शिता को नियंत्रित करने के लिए एक पारदर्शिता स्तर भी सेट कर सकते हैं। अधिक पारदर्शिता मान शैपे को अधिक पारदर्शी बनाता है, जिससे पृष्ठभूमि या नीचे मौजूद वस्तुएँ आंशिक रूप से दिखाई देती हैं।

Aspose.Slides आपको फ़िल के लिए उपयोग किए गए रंग के अल्फा मान को समायोजित करके पारदर्शिता स्तर सेट करने देता है। तरीका इस प्रकार है:

1. एक [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) क्लास का इंस्टेंस बनाएँ।  
1. उसके इंडेक्स द्वारा एक स्लाइड का रेफ़रेंस प्राप्त करें।  
1. स्लाइड में एक [AutoShape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/autoshape/) जोड़ें।  
1. [FillType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/filltype/) को `Solid` सेट करें।  
1. `Color` का उपयोग करके एक ऐसा रंग परिभाषित करें जिसमें पारदर्शिता (alpha घटक) हो।  
1. प्रस्तुति को सहेजें।

नीचे दिया गया PHP कोड एक आयत पर पारदर्शी फ़िल रंग लागू करने का तरीका दर्शाता है:

```php
// प्रेज़ेंटेशन फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का इंस्टेंस बनाएं।
$presentation = new Presentation();
try {
    // पहला स्लाइड प्राप्त करें।
    $slide = $presentation->getSlides()->get_Item(0);

    // एक ठोस आयताकार ऑटो शैपे जोड़ें।
    $solidShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // ठोस शैपे के ऊपर एक पारदर्शी आयताकार ऑटो शैपे जोड़ें।
    $transparentShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 80, 80, 150, 75);
    $transparentShape->getFillFormat()->setFillType(FillType::Solid);
    $transparentShape->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", 255, 255, 0, 204));

    // PPTX फ़ाइल को डिस्क पर सहेजें।
    $presentation->save("shape_transparency.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

परिणाम:

![The transparent shape](shape-transparency.png)

## **शैपे घुमाएँ**

Aspose.Slides आपको PowerPoint प्रस्तुतियों में शैपे को घुमाने की सुविधा देता है। यह उन दृश्य तत्वों को विशिष्ट संरेखन या डिज़ाइन आवश्यकताओं के साथ स्थिति देने में उपयोगी हो सकता है।

किसी स्लाइड पर शैपे को घुमाने के चरण:

1. एक [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) क्लास का इंस्टेंस बनाएँ।  
1. उसके इंडेक्स द्वारा एक स्लाइड का रेफ़रेंस प्राप्त करें।  
1. स्लाइड में एक [AutoShape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/autoshape/) जोड़ें।  
1. शैपे की घुमाव प्रॉपर्टी को इच्छित डिग्री पर सेट करें।  
1. प्रस्तुति को सहेजें।

नीचे दिया गया PHP कोड शैपे को 5 डिग्री से घुमाने का तरीका दर्शाता है:

```php
// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का इंस्टेंस बनाएं।
$presentation = new Presentation();
try {
    // पहला स्लाइड प्राप्त करें।
    $slide = $presentation->getSlides()->get_Item(0);

    // Rectangle प्रकार का ऑटो शैपे जोड़ें।
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // शैपे को 5 डिग्री घुमाएँ।
    $shape->setRotation(5);

    // PPTX फ़ाइल को डिस्क पर सहेजें।
    $presentation->save("shape_rotation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

परिणाम:

![The shape rotation](shape-rotation.png)

## **3D बिवेल प्रभाव जोड़ें**

Aspose.Slides आपको शैपे पर 3D बिवेल प्रभाव लागू करने की अनुमति देता है, जिसके लिए आप उनके [ThreeDFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/threedformat/) प्रॉपर्टी को कॉन्फ़िगर करते हैं।

3D बिवेल प्रभाव जोड़ने के चरण:

1. एक [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) क्लास का इंस्टेंस बनाएँ।  
1. उसके इंडेक्स द्वारा एक स्लाइड का रेफ़रेंस प्राप्त करें।  
1. स्लाइड में एक [AutoShape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/autoshape/) जोड़ें।  
1. शैपे के [ThreeDFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/threedformat/) को कॉन्फ़िगर करके बिवेल सेटिंग्स परिभाषित करें।  
1. प्रस्तुति को सहेजें।

नीचे दिया गया PHP कोड शैपे पर 3D बिवेल प्रभाव लागू करने का तरीका दर्शाता है:

```php
// Presentation क्लास का इंस्टेंस बनाएं।
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // स्लाइड में एक शैपे जोड़ें।
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 50, 100, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->ORANGE);
    $shape->getLineFormat()->setWidth(2.0);

    // शैपे के ThreeDFormat गुण सेट करें।
    $shape->getThreeDFormat()->setDepth(4);
    $shape->getThreeDFormat()->getBevelTop()->setBevelType(BevelPresetType::Circle);
    $shape->getThreeDFormat()->getBevelTop()->setHeight(6);
    $shape->getThreeDFormat()->getBevelTop()->setWidth(6);
    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::ThreePt);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);

    // प्रेज़ेंटेशन को PPTX फ़ाइल के रूप में सहेजें।
    $presentation->save("3D_bevel_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

परिणाम:

![The 3D bevel effect](3D-bevel-effect.png)

## **3D घुमाव प्रभाव जोड़ें**

Aspose.Slides आपको शैपे पर 3D घुमाव प्रभाव लागू करने की अनुमति देता है, जिसके लिए आप उनके [ThreeDFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/threedformat/) प्रॉपर्टी को कॉन्फ़िगर करते हैं।

3D घुमाव लागू करने के चरण:

1. एक [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) क्लास का इंस्टेंस बनाएँ।  
1. उसके इंडेक्स द्वारा एक स्लाइड का रेफ़रेंस प्राप्त करें।  
1. स्लाइड में एक [AutoShape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/autoshape/) जोड़ें।  
1. 3D घुमाव को परिभाषित करने के लिए [setCameraType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/camera/#setCameraType) और [setLightType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/lightrig/#setLightType) का उपयोग करें।  
1. प्रस्तुति को सहेजें।

नीचे दिया गया PHP कोड शैपे पर 3D घुमाव प्रभाव लागू करने का तरीका दर्शाता है:

```php
// Presentation क्लास का इंस्टेंस बनाएं।
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
    $autoShape->getTextFrame()->setText("Hello, Aspose!");

    $autoShape->getThreeDFormat()->setDepth(6);
    $autoShape->getThreeDFormat()->getCamera()->setRotation(40, 35, 20);
    $autoShape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::IsometricLeftUp);
    $autoShape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);

    // प्रेज़ेंटेशन को PPTX फ़ाइल के रूप में सहेजें।
    $presentation->save("3D_rotation_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

परिणाम:

![The 3D rotation effect](3D-rotation-effect.png)

## **शैपे के लिए काला‑सफ़ेद रेंडरिंग नियंत्रित करें**

[Shape::setBlackWhiteMode](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shape/#setBlackWhiteMode) मेथड तय करता है कि जब प्रस्तुति को काला‑सफ़ेद मोड में देखा या प्रोसेस किया जाता है, तो व्यक्तिगत शैपे कैसे रेंडर किया जाए। यह स्वयं काला‑सफ़ेद डिस्प्ले को सक्षम नहीं करता, और यह सामान्य रंग मोड में शैपे के फ़िल, लाइन या अन्य फ़ॉर्मेटिंग को नहीं बदलता।

वांछित व्यवहार चुनने के लिए आप [BlackWhiteMode](https://reference.aspose.com/slides/hi/php-java/aspose.slides/blackwhitemode/) क्लास के मान का उपयोग कर सकते हैं। उदाहरण के लिए, `Automatic` रेंडरिंग एप्लिकेशन को रूपांतरण चुनने देता है, `Gray` और `LightGray` ग्रे रंग का उपयोग करते हैं, `BlackWhite` केवल काला और सफ़ेद इस्तेमाल करता है, `Black` और `White` एक ही रंग को मजबूर करते हैं, `Color` सामान्य रंग बनाए रखता है, और `Hidden` काला‑सफ़ेद मोड में शैपे को छोड़ देता है। `NotDefined` का अर्थ है कि शैपे‑स्तर का कोई मोड असाइन नहीं किया गया है।

नीचे दिया गया PHP कोड एक रंगीन शैपे बनाता है और काला‑सफ़ेद डिस्प्ले मोड में उसे ग्रे दिखाता है:

```php
use aspose\slides\BlackWhiteMode;
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $orange = new Java("java.awt.Color", 255, 165, 0);
    $shape->getFillFormat()->getSolidFillColor()->setColor($orange);

    // रंग मोड में नारंगी फ़िल को रखें, लेकिन काला-सफ़ेद मोड में शैपे को ग्रे रंग में रेंडर करें।
    $shape->setBlackWhiteMode(BlackWhiteMode::Gray);

    $presentation->save("shape_black_white_mode.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

सामान्य रंग मोड में आयत का नारंगी फ़िल बना रहता है। काला‑सफ़ेद डिस्प्ले वर्कफ़्लो में, इसका रंग ग्रे दिखता है क्योंकि उसका मोड `Gray` पर सेट है। यह आपको पूर्ण‑रंग स्लाइड को संरक्षित रखने और प्रिंटिंग, प्रीव्यू या अन्य वर्कफ़्लो के लिए अलग‑अलग दिखावट परिभाषित करने देता है जो काला‑सफ़ेद डिस्प्ले सेटिंग्स का सम्मान करता है।

## **फ़ॉर्मेट रीसेट करें**

नीचे दिया गया Java कोड दिखाता है कि कैसे स्लाइड की फ़ॉर्मेटिंग रीसेट की जाए और [LayoutSlide](https://reference.aspose.com/slides/hi/php-java/aspose.slides/layoutslide/) पर सभी प्लेसहोल्डर वाले शैपतों की स्थिति, आकार और फ़ॉर्मेटिंग को उनके डिफ़ॉल्ट सेटिंग्स पर लाया जाए:

```php
$presentation = new Presentation("sample.pptx");
try {
    for ($i = 0; $i < java_values($presentation->getSlides()->size()); $i++) {
        $slide = $presentation->getSlides()->get_Item($i);
        // लेआउट में प्लेसहोल्डर वाले स्लाइड पर प्रत्येक शैपे को रीसेट करें।
        $slide->reset();
    }
    $presentation->save("reset_formatting.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**क्या शैपे फ़ॉर्मेटिंग अंतिम प्रस्तुति फ़ाइल आकार को प्रभावित करती है?**

बहुत कम। एम्बेडेड छवियाँ और मीडिया फ़ाइलें अधिकांश स्थान लेती हैं, जबकि शैपे पैरामीटर जैसे रंग, प्रभाव और ग्रेडिएंट मेटा‑डेटा के रूप में संग्रहीत होते हैं और लगभग कोई अतिरिक्त आकार नहीं जोड़ते।

**मैं कैसे उन शैपतों का पता लगा सकता हूँ जो एक ही फ़ॉर्मेटिंग साझा करते हैं ताकि उन्हें समूहित कर सकूँ?**

प्रत्येक शैपे की प्रमुख फ़ॉर्मेटिंग प्रॉपर्टीज़—फ़िल, लाइन और इफ़ेक्ट सेटिंग्स—की तुलना करें। यदि सभी संबंधित मान मेल खाते हैं, तो उनकी शैली को समान मानें और तर्कसंगत रूप से उन शैपतों को समूहित करें, जिससे बाद में शैली प्रबंधन सरल हो जाता है।

**क्या मैं कस्टम शैपे स्टाइल का एक सेट अलग फ़ाइल में सहेज कर अन्य प्रस्तुतियों में पुनः उपयोग कर सकता हूँ?**

हाँ। इच्छित शैलियों वाले नमूना शैपे को एक टेम्पलेट स्लाइड डेक या .POTX टेम्पलेट फ़ाइल में सहेजें। नई प्रस्तुति बनाते समय टेम्पलेट खोलें, आवश्यक शैपे को क्लोन करें, और जहाँ भी आवश्यक हो उनके फ़ॉर्मेटिंग को पुनः लागू करें।