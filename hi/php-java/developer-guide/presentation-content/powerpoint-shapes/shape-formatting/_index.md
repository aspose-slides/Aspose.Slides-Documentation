---
title: PHP में PowerPoint शैप को फ़ॉर्मेट करें
linktitle: शैप फ़ॉर्मेटिंग
type: docs
weight: 20
url: /hi/php-java/shape-formatting/
keywords:
- शैप फ़ॉर्मेट
- लाइन फ़ॉर्मेट
- स्केच प्रभाव
- शैप लाइन का स्केच
- जॉइन शैली फ़ॉर्मेट
- ग्रेडिएंट फ़िल
- पैटर्न फ़िल
- चित्र फ़िल
- टेक्सचर फ़िल
- सॉलिड कलर फ़िल
- शैप पारदर्शिता
- शैप घुमाना
- 3D बीवेल प्रभाव
- 3D घूर्णन प्रभाव
- फ़ॉर्मेट रीसेट
- PowerPoint
- प्रेज़ेंटेशन
- PHP
- Aspose.Slides
description: "Aspose.Slides का उपयोग कर PHP में PowerPoint शैप को फ़ॉर्मेट करना सीखें - PPT, PPTX, और ODP फ़ाइलों के लिए फ़िल, लाइन और इफ़ेक्ट शैलियों को सटीकता और पूर्ण नियंत्रण के साथ सेट करें।"
---
## **परिचय**

PowerPoint में, आप स्लाइड्स में शैप जोड़ सकते हैं। चूँकि शैप रेखाओं से बने होते हैं, आप उनके किनारों को संशोधित करके या प्रभाव लागू करके फ़ॉर्मेट कर सकते हैं। इसके अतिरिक्त, आप शैप के अंदर के भाग को भरने के लिये सेटिंग्स निर्दिष्ट करके फ़ॉर्मेट कर सकते हैं।

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for PHP via Java में ऐसी क्लास और मेथड्स हैं जो PowerPoint में उपलब्ध वही विकल्पों से शैप को फ़ॉर्मेट करने की अनुमति देते हैं।

## **लाइन फ़ॉर्मेट करना**

Aspose.Slides का उपयोग करके आप किसी शैप के लिये एक कस्टम लाइन शैली निर्दिष्ट कर सकते हैं। नीचे दी गई चरणों में इस प्रक्रिया को बताया गया है:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) class.
1. Get a reference to a slide by its index.
1. Add an [AutoShape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/autoshape/) to the slide.
1. Set the [line style](https://reference.aspose.com/slides/hi/php-java/aspose.slides/linestyle/) of the shape.
1. Set the line width.
1. Set the [dash style](https://reference.aspose.com/slides/hi/php-java/aspose.slides/linedashstyle/) of the line.
1. Set the line color for the shape.
1. Save the modified presentation as a PPTX file.

निम्नलिखित PHP कोड दिखाता है कि कैसे एक आयताकार `AutoShape` को फ़ॉर्मेट किया जाता है:

```php
// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाले Presentation क्लास को इंस्टैंसिएट करें।
$presentation = new Presentation();
try {
    // पहला स्लाइड प्राप्त करें।
    $slide = $presentation->getSlides()->get_Item(0);

    // Rectangle प्रकार का एक ऑटो शैप जोड़ें।
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 150, 75);

    // आयताकार शैप के लिए फ़िल रंग सेट करें।
    $shape->getFillFormat()->setFillType(FillType::NoFill);

    // आयताकार की लाइनों पर फ़ॉर्मेटिंग लागू करें।
    $shape->getLineFormat()->setStyle(LineStyle::ThickThin);
    $shape->getLineFormat()->setWidth(7);
    $shape->getLineFormat()->setDashStyle(LineDashStyle::Dash);

    // आयताकार की लाइन के लिए रंग सेट करें।
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);

    // PPTX फ़ाइल को डिस्क पर सेव करें।
    $presentation->save("formatted_lines.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

परिणाम:

![The formatted lines in the presentation](formatted-lines.png)

## **शैप लाइनों पर स्केच प्रभाव लागू करना**

एक स्केच प्रभाव शैप की लाइन को हाथ से बनी हुई दिखाता है। लाइन सेटिंग्स तक पहुँचने के लिए आप [Shape.getLineFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shape/) का उपयोग करें, स्केच सेटिंग्स तक पहुँचने के लिये [LineFormat.getSketchFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/lineformat/) और स्केच प्रकार चुनने के लिये [SketchFormat.setSketchType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/sketchformat/) को [LineSketchType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/linesketchtype/) enumeration से चुनें।

निम्नलिखित PHP कोड दिखाता है कि कैसे [LineSketchType.Curved](https://reference.aspose.com/slides/hi/php-java/aspose.slides/linesketchtype/) प्रभाव लागू किया जाता है, स्पष्ट रूप से नियत मान पढ़ा जाता है, और [LineSketchType.None](https://reference.aspose.com/slides/hi/php-java/aspose.slides/linesketchtype/) से प्रभाव हटाया जाता है:

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);

    // शैप के लाइन फ़ॉर्मेट और उसके स्केच फ़ॉर्मेट तक पहुँचें।
    $sketchFormat = $shape->getLineFormat()->getSketchFormat();

    // एक स्केच प्रभाव लागू करें।
    $sketchFormat->setSketchType(LineSketchType::Curved);

    // शैप को सीधे असाइन किए गए स्केच प्रभाव को पढ़ें।
    $explicitSketchType = $sketchFormat->getSketchType();
    echo "Explicit sketch type: " . $explicitSketchType . PHP_EOL;

    // स्केच प्रभाव हटाएँ।
    $sketchFormat->setSketchType(LineSketchType::None);
} finally {
    $presentation->dispose();
}
```

[SketchFormat.getSketchType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/sketchformat/) द्वारा लौटाया गया मान सीधे शैप पर नियत सेटिंग को दर्शाता है। यदि लाइन फ़ॉर्मेटिंग थीम, मास्टर स्लाइड या लेआउट स्लाइड से विरासत में मिली हो, तो आप [LineFormat.getEffective](https://reference.aspose.com/slides/hi/php-java/aspose.slides/lineformat/) का उपयोग करके लौटाए गए ऑब्जेक्ट की `getSketchFormat` मेथड को एक्सेस करें और उसका `getSketchType` मान पढ़ें। प्रभावी मान वह फ़ॉर्मेटिंग दर्शाता है जो विरासत हल होने के बाद वास्तविक रूप से लागू होती है:

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

## **जॉइन शैली फ़ॉर्मेट करना**

तीन जॉइन प्रकार विकल्प हैं:

* Round
* Miter
* Bevel

डिफ़ॉल्ट रूप से, जब PowerPoint दो लाइनों को कोण पर जोड़ता है (जैसे शैप के कोने पर), यह **Round** सेटिंग का उपयोग करता है। हालांकि, यदि आप तीखे कोण वाले शैप बना रहे हैं, तो आप **Miter** विकल्प को पसंद कर सकते हैं।

![The join style in the presentation](join-style-powerpoint.png)

निम्नलिखित PHP कोड दर्शाता है कि कैसे ऊपर की छवि में दिखाए गए तीन आयतों को Miter, Bevel और Round जॉइन प्रकार सेटिंग्स का उपयोग करके बनाया गया:

```php
// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाले Presentation क्लास को इंस्टैंसिएट करें।
$presentation = new Presentation();
try {
    // पहला स्लाइड प्राप्त करें।
    $slide = $presentation->getSlides()->get_Item(0);

    // Rectangle प्रकार के तीन ऑटो शैप जोड़ें।
    $shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 150, 75);
    $shape2 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 210, 20, 150, 75);
    $shape3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 135, 150, 75);

    // प्रत्येक आयताकार शैप के लिए फ़िल रंग सेट करें।
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

    // PPTX फ़ाइल को डिस्क पर सेव करें।
    $presentation->save("join_styles.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **ग्रेडिएंट फ़िल**

PowerPoint में, Gradient Fill एक फ़ॉर्मेटिंग विकल्प है जो शैप पर निरंतर रंग मिश्रण लागू करने की अनुमति देता है। उदाहरण के लिये, आप दो या अधिक रंगों को इस प्रकार लागू कर सकते हैं कि एक धीरे‑धीरे दूसरे में मिल जाता है।

Aspose.Slides का उपयोग करके शैप पर ग्रेडिएंट फ़िल लागू करने के चरण इस प्रकार हैं:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) class.
1. Get a reference to a slide by its index.
1. Add an [AutoShape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/autoshape/) to the slide.
1. Set the shape's [FillType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/filltype/) to `Gradient`.
1. Add your two preferred colors with defined positions using the `add` methods of the gradient stop collection exposed by the [GradientFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/gradientformat/) class.
1. Save the modified presentation as a PPTX file.

निम्नलिखित PHP कोड दिखाता है कि कैसे एक अण्डाकार पर ग्रेडिएंट फ़िल प्रभाव लागू किया जाता है:

```php
// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाले Presentation क्लास को इंस्टैंसिएट करें।
$presentation = new Presentation();
try {
    // पहला स्लाइड प्राप्त करें।
    $slide = $presentation->getSlides()->get_Item(0);

    // Ellipse प्रकार का एक ऑटो शैप जोड़ें।
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 50, 150, 75);

    // एलिप्स पर ग्रेडिएंट फ़ॉर्मेटिंग लागू करें।
    $shape->getFillFormat()->setFillType(FillType::Gradient);
    $shape->getFillFormat()->getGradientFormat()->setGradientShape(GradientShape::Linear);

    // ग्रेडिएंट की दिशा सेट करें।
    $shape->getFillFormat()->getGradientFormat()->setGradientDirection(GradientDirection::FromCorner2);

    // दो ग्रेडिएंट स्टॉप जोड़ें।
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->addPresetColor(1.0, PresetColor::Purple);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->addPresetColor(0, PresetColor::Red);

    // PPTX फ़ाइल को डिस्क पर सेव करें।
    $presentation->save("gradient_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

परिणाम:

![The ellipse with gradient fill](gradient-fill.png)

## **पैटर्न फ़िल**

PowerPoint में, Pattern Fill एक फ़ॉर्मेटिंग विकल्प है जो आपको दो‑रंग की डिज़ाइन—जैसे डॉट्स, स्ट्राइप्स, क्रॉसहैचेज़ या चे़क्स—शैप पर लागू करने की अनुमति देता है। आप पैटर्न के अग्रभूमि और पृष्ठभूमि के लिये कस्टम रंग चुन सकते हैं।

Aspose.Slides में 45 से अधिक पहले से परिभाषित पैटर्न शैलियां उपलब्ध हैं जिन्हें आप शैप पर लागू करके अपनी प्रस्तुतियों की दृश्य अपील बढ़ा सकते हैं। पहले से परिभाषित पैटर्न चुनने के बाद भी आप उपयोग किए जाने वाले सटीक रंग निर्दिष्ट कर सकते हैं।

निम्नलिखित चरणों से आप शैप पर पैटर्न फ़िल लागू कर सकते हैं:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) class.
1. Get a reference to a slide by its index.
1. Add an [AutoShape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/autoshape/) to the slide.
1. Set the shape’s [FillType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/filltype/) to `Pattern`.
1. Choose a pattern style from the predefined options.
1. Set the [Background Color](https://reference.aspose.com/slides/hi/php-java/aspose.slides/patternformat/#getBackColor) of the pattern.
1. Set the [Foreground Color](https://reference.aspose.com/slides/hi/php-java/aspose.slides/patternformat/#getForeColor) of the pattern.
1. Save the modified presentation as a PPTX file.

निम्नलिखित PHP कोड दिखाता है कि कैसे एक आयत पर पैटर्न फ़िल लागू किया जाता है:

```php
// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाले Presentation क्लास को इंस्टैंसिएट करें।
$presentation = new Presentation();
try {
    // पहला स्लाइड प्राप्त करें।
    $slide = $presentation->getSlides()->get_Item(0);

    // Rectangle प्रकार का एक ऑटो शैप जोड़ें।
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // फ़िल प्रकार को Pattern पर सेट करें।
    $shape->getFillFormat()->setFillType(FillType::Pattern);

    // पैटर्न शैली सेट करें।
    $shape->getFillFormat()->getPatternFormat()->setPatternStyle(PatternStyle::Trellis);

    // पैटर्न पृष्ठभूमि और अग्रभूमि रंग सेट करें।
    $shape->getFillFormat()->getPatternFormat()->getBackColor()->setColor(java("java.awt.Color")->LIGHT_GRAY);
    $shape->getFillFormat()->getPatternFormat()->getForeColor()->setColor(java("java.awt.Color")->YELLOW);

    // PPTX फ़ाइल को डिस्क पर सेव करें।
    $presentation->save("pattern_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

परिणाम:

![The rectangle with pattern fill](pattern-fill.png)

## **चित्र फ़िल**

PowerPoint में, Picture Fill एक फ़ॉर्मेटिंग विकल्प है जो आपको शैप के भीतर एक चित्र डालने की अनुमति देता है—वास्तव में चित्र को शैप की पृष्ठभूमि के रूप में उपयोग करता है।

Aspose.Slides का उपयोग करके शैप पर चित्र फ़िल लागू करने के चरण इस प्रकार हैं:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) class.
1. Get a reference to a slide by its index.
1. Add an [AutoShape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/autoshape/) to the slide.
1. Set the shape's [FillType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/filltype/) to `Picture`.
1. Set the picture fill mode to `Tile` (or another preferred mode).
1. Create an [PPImage](https://reference.aspose.com/slides/hi/php-java/aspose.slides/ppimage/) object from the image you want to use.
1. Pass the image to the `SlidesPicture.setImage` method.
1. Save the modified presentation as a PPTX file.

मान लीजिए हमारे पास "lotus.png" नाम की फ़ाइल है जिसमें निम्न चित्र है:

![The lotus picture](lotus.png)

निम्नलिखित PHP कोड दिखाता है कि कैसे शैप को चित्र से भर सकते हैं:

```php
// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाले Presentation क्लास को इंस्टैंसिएट करें।
$presentation = new Presentation();
try {
    // पहला स्लाइड प्राप्त करें।
    $slide = $presentation->getSlides()->get_Item(0);

    // Rectangle प्रकार का एक ऑटो शैप जोड़ें।
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 255, 130);

    // फ़िल प्रकार को Picture पर सेट करें।
    $shape->getFillFormat()->setFillType(FillType::Picture);

    // चित्र फ़िल मोड सेट करें।
    $shape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Tile);

    // एक चित्र लोड करें और उसे प्रस्तुति संसाधनों में जोड़ें।
    $image = Images::fromFile("lotus.png");
    $picture = $presentation->getImages()->addImage($image);
    $image->dispose();

    // चित्र सेट करें।
    $shape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);

    // PPTX फ़ाइल को डिस्क पर सेव करें।
    $presentation->save("picture_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

परिणाम:

![The shape with picture fill](picture-fill.png)

### **टाइल चित्र को बनावट के रूप में उपयोग करना**

यदि आप टाइल्ड चित्र को बनावट के रूप में सेट करना चाहते हैं और टाइलिंग व्यवहार को अनुकूलित करना चाहते हैं, तो आप [PictureFillFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/picturefillformat/) क्लास की निम्नलिखित मेथड्स का उपयोग कर सकते हैं:

- [setPictureFillMode](https://reference.aspose.com/slides/hi/php-java/aspose.slides/picturefillformat/#setPictureFillMode): तस्वीर फ़िल मोड सेट करता है—या तो `Tile` या `Stretch`।
- [setTileAlignment](https://reference.aspose.com/slides/hi/php-java/aspose.slides/picturefillformat/#setTileAlignment): शैप के भीतर टाइलों की संरेखण निर्दिष्ट करता है।
- [setTileFlip](https://reference.aspose.com/slides/hi/php-java/aspose.slides/picturefillformat/#setTileFlip): टाइल को क्षैतिज, लंबवत या दोनों दिशा में फ्लिप करने को नियंत्रित करता है।
- [setTileOffsetX](https://reference.aspose.com/slides/hi/php-java/aspose.slides/picturefillformat/#setTileOffsetX): शैप की मूलस्थिति से टाइल का क्षैतिज ऑफसेट (पॉइंट्स में) सेट करता है।
- [setTileOffsetY](https://reference.aspose.com/slides/hi/php-java/aspose.slides/picturefillformat/#setTileOffsetY): शैप की मूलस्थिति से टाइल का लंबवत ऑफसेट (पॉइंट्स में) सेट करता है।
- [setTileScaleX](https://reference.aspose.com/slides/hi/php-java/aspose.slides/picturefillformat/#setTileScaleX): टाइल की क्षैतिज स्केल को प्रतिशत में परिभाषित करता है।
- [setTileScaleY](https://reference.aspose.com/slides/hi/php-java/aspose.slides/picturefillformat/#setTileScaleY): टाइल की लंबवत स्केल को प्रतिशत में परिभाषित करता है।

निम्नलिखित कोड नमूना दिखाता है कि कैसे एक आयताकार शैप को टाइल्ड चित्र फ़िल के साथ जोड़कर टाइल विकल्प कॉन्फ़िगर किए जाएँ:

```php
// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाले Presentation क्लास को इंस्टैंसिएट करें।
$presentation = new Presentation();
try {
    // पहला स्लाइड प्राप्त करें।
    $firstSlide = $presentation->getSlides()->get_Item(0);

    // एक आयताकार ऑटो शैप जोड़ें।
    $shape = $firstSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 190, 95);

    // शैप के फ़िल प्रकार को Picture पर सेट करें।
    $shape->getFillFormat()->setFillType(FillType::Picture);

    // चित्र लोड करें और उसे प्रस्तुति संसाधनों में जोड़ें।
    $sourceImage = Images::fromFile("lotus.png");
    $presentationImage = $presentation->getImages()->addImage($sourceImage);
    $sourceImage->dispose();

    // चित्र को शैप में असाइन करें।
    $pictureFillFormat = $shape->getFillFormat()->getPictureFillFormat();
    $pictureFillFormat->getPicture()->setImage($presentationImage);

    // चित्र फ़िल मोड और टाइलिंग गुण कॉन्फ़िगर करें।
    $pictureFillFormat->setPictureFillMode(PictureFillMode::Tile);
    $pictureFillFormat->setTileOffsetX(-32);
    $pictureFillFormat->setTileOffsetY(-32);
    $pictureFillFormat->setTileScaleX(50);
    $pictureFillFormat->setTileScaleY(50);
    $pictureFillFormat->setTileAlignment(RectangleAlignment::BottomRight);
    $pictureFillFormat->setTileFlip(TileFlip::FlipBoth);

    // PPTX फ़ाइल को डिस्क पर सेव करें।
    $presentation->save("tile.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

परिणाम:

![The tile options](tile-options.png)

## **सॉलिड कलर फ़िल**

PowerPoint में, Solid Color Fill एक फ़ॉर्मेटिंग विकल्प है जो शैप को एक समान रंग से भरता है। यह सादा पृष्ठभूमि रंग कोई ग्रेडिएंट, बनावट या पैटर्न के बिना लागू किया जाता है।

Aspose.Slides का उपयोग करके शैप पर सॉलिड कलर फ़िल लागू करने के चरण:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) class.
1. Get a reference to a slide by its index.
1. Add an [AutoShape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/autoshape/) to the slide.
1. Set the shape’s [FillType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/filltype/) to `Solid`.
1. Assign your preferred fill color to the shape.
1. Save the modified presentation as a PPTX file.

निम्नलिखित PHP कोड दिखाता है कि कैसे एक आयत पर सॉलिड कलर फ़िल लागू किया जाता है:

```php
// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाले Presentation क्लास को इंस्टैंसिएट करें।
$presentation = new Presentation();
try {
    // पहला स्लाइड प्राप्त करें।
    $slide = $presentation->getSlides()->get_Item(0);

    // Rectangle प्रकार का एक ऑटो शैप जोड़ें।
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // फ़िल प्रकार को Solid पर सेट करें।
    $shape->getFillFormat()->setFillType(FillType::Solid);

    // फ़िल रंग सेट करें।
    $shape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);

    // PPTX फ़ाइल को डिस्क पर सेव करें।
    $presentation->save("solid_color_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

परिणाम:

![The shape with solid color fill](solid-color-fill.png)

## **पारदर्शिता सेट करना**

PowerPoint में, जब आप शैप पर सॉलिड कलर, ग्रेडिएंट, चित्र या बनावट फ़िल लागू करते हैं, तो आप फ़िल की अपारदर्शिता को नियंत्रित करने के लिये पारदर्शिता स्तर भी सेट कर सकते हैं। उच्च पारदर्शिता मान शैप को अधिक पारदर्शी बनाता है, जिससे पृष्ठभूमि या नीचे के ऑब्जेक्ट कुछ हद तक दिखाई देते हैं।

Aspose.Slides आपको फ़िल में उपयोग किए गए रंग के अल्फा मान को समायोजित करके पारदर्शिता स्तर सेट करने की अनुमति देता है। इसे करने के चरण इस प्रकार हैं:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) class.
1. Get a reference to a slide by its index.
1. Add an [AutoShape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/autoshape/) to the slide.
1. Set the [FillType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/filltype/) to `Solid`.
1. Use `Color` to define a color with transparency (the `alpha` component controls transparency).
1. Save the presentation.

निम्नलिखित PHP कोड दिखाता है कि कैसे एक आयत पर पारदर्शी फ़िल रंग लागू किया जाता है:

```php
// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाले Presentation क्लास को इंस्टैंसिएट करें।
$presentation = new Presentation();
try {
    // पहला स्लाइड प्राप्त करें।
    $slide = $presentation->getSlides()->get_Item(0);

    // एक सॉलिड आयताकार ऑटो शैप जोड़ें।
    $solidShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // सॉलिड शैप के ऊपर एक पारदर्शी आयताकार ऑटो शैप जोड़ें।
    $transparentShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 80, 80, 150, 75);
    $transparentShape->getFillFormat()->setFillType(FillType::Solid);
    $transparentShape->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", 255, 255, 0, 204));

    // PPTX फ़ाइल को डिस्क पर सेव करें।
    $presentation->save("shape_transparency.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

परिणाम:

![The transparent shape](shape-transparency.png)

## **शैप घुमाना**

Aspose.Slides आपको PowerPoint प्रस्तुतियों में शैप घुमाने की सुविधा देता है। यह विशेष संरेखण या डिज़ाइन आवश्यकताओं के साथ दृश्य तत्वों को स्थित करने में उपयोगी हो सकता है।

शैप को स्लाइड पर घुमाने के लिये नीचे दिए चरणों का पालन करें:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) class.
1. Get a reference to a slide by its index.
1. Add an [AutoShape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/autoshape/) to the slide.
1. Set the shape’s rotation property to the desired angle.
1. Save the presentation.

निम्नलिखित PHP कोड दिखाता है कि कैसे शैप को 5 डिग्री घुमाया जाता है:

```php
// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाले Presentation क्लास को इंस्टैंसिएट करें।
$presentation = new Presentation();
try {
    // पहला स्लाइड प्राप्त करें।
    $slide = $presentation->getSlides()->get_Item(0);

    // Rectangle प्रकार का एक ऑटो शैप जोड़ें।
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // शैप को 5 डिग्री घुमाएँ।
    $shape->setRotation(5);

    // PPTX फ़ाइल को डिस्क पर सेव करें।
    $presentation->save("shape_rotation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

परिणाम:

![The shape rotation](shape-rotation.png)

## **3D बीवेल प्रभाव जोड़ना**

Aspose.Slides आपको शैप पर 3D बीवेल प्रभाव लागू करने की अनुमति देता है, जिसके लिये आप उनके [ThreeDFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/threedformat/) गुणों को कॉन्फ़िगर करते हैं।

3D बीवेल प्रभाव जोड़ने के लिये नीचे दिए चरणों का पालन करें:

1. Instantiate the [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) class.
1. Get a reference to a slide by its index.
1. Add an [AutoShape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/autoshape/) to the slide.
1. Configure the shape’s [ThreeDFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/threedformat/) to define bevel settings.
1. Save the presentation.

निम्नलिखित PHP कोड दिखाता है कि कैसे शैप पर 3D बीवेल प्रभाव लागू किया जाता है:

```php
// Presentation क्लास का एक इंस्टेंस बनाएँ।
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // स्लाइड में एक शैप जोड़ें।
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 50, 100, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->ORANGE);
    $shape->getLineFormat()->setWidth(2.0);

    // शैप की ThreeDFormat प्रॉपर्टीज़ सेट करें।
    $shape->getThreeDFormat()->setDepth(4);
    $shape->getThreeDFormat()->getBevelTop()->setBevelType(BevelPresetType::Circle);
    $shape->getThreeDFormat()->getBevelTop()->setHeight(6);
    $shape->getThreeDFormat()->getBevelTop()->setWidth(6);
    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::ThreePt);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);

    // प्रेजेंटेशन को PPTX फ़ाइल के रूप में सेव करें।
    $presentation->save("3D_bevel_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

परिणाम:

![The 3D bevel effect](3D-bevel-effect.png)

## **3D घूर्णन प्रभाव जोड़ना**

Aspose.Slides आपको शैप पर 3D घूर्णन प्रभाव लागू करने की अनुमति देता है, जिसके लिये आप उनके [ThreeDFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/threedformat/) गुणों को कॉन्फ़िगर करते हैं।

3D घूर्णन लागू करने के लिये नीचे दिए कदमों का पालन करें:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) class.
1. Get a reference to a slide by its index.
1. Add an [AutoShape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/autoshape/) to the slide.
1. Use the [setCameraType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/camera/#setCameraType) and [setLightType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/lightrig/#setLightType) to define the 3D rotation.
1. Save the presentation.

निम्नलिखित PHP कोड दिखाता है कि कैसे शैप पर 3D घूर्णन प्रभाव लागू किया जाता है:

```php
// Presentation क्लास का एक इंस्टेंस बनाएँ।
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
    $autoShape->getTextFrame()->setText("Hello, Aspose!");

    $autoShape->getThreeDFormat()->setDepth(6);
    $autoShape->getThreeDFormat()->getCamera()->setRotation(40, 35, 20);
    $autoShape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::IsometricLeftUp);
    $autoShape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);

    // प्रेजेंटेशन को PPTX फ़ाइल के रूप में सेव करें।
    $presentation->save("3D_rotation_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

परिणाम:

![The 3D rotation effect](3D-rotation-effect.png)

## **फ़ॉर्मेट रीसेट करना**

निम्नलिखित Java कोड दिखाता है कि कैसे स्लाइड की फ़ॉर्मेटिंग रीसेट की जाती है और सभी प्लेसहोल्डर वाले शैप की स्थिति, आकार एवं फ़ॉर्मेटिंग को [LayoutSlide](https://reference.aspose.com/slides/hi/php-java/aspose.slides/layoutslide/) पर डिफ़ॉल्ट सेटिंग्स पर लौटाया जाता है:

```php
$presentation = new Presentation("sample.pptx");
try {
    for ($i = 0; $i < java_values($presentation->getSlides()->size()); $i++) {
        $slide = $presentation->getSlides()->get_Item($i);
        // लेआउट में प्लेसहोल्डर वाले स्लाइड के प्रत्येक शैप को रीसेट करें।
        $slide->reset();
    }
    $presentation->save("reset_formatting.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या शैप फ़ॉर्मेटिंग अंतिम प्रेजेंटेशन फ़ाइल आकार को प्रभावित करती है?**

बहुत कम हद तक। एम्बेडेड चित्र और मीडिया फ़ाइलें फ़ाइल आकार का अधिकांश हिस्सा लेती हैं, जबकि शैप पैरामीटर जैसे रंग, प्रभाव और ग्रेडिएंट मेटाडेटा के रूप में संग्रहीत होते हैं और लगभग कोई अतिरिक्त आकार नहीं जोड़ते।

**मैं कैसे पहचान सकता हूँ कि स्लाइड पर कौन‑से शैप समान फ़ॉर्मेटिंग साझा करते हैं ताकि मैं उन्हें समूहित कर सकूँ?**

प्रत्येक शैप की प्रमुख फ़ॉर्मेटिंग प्रॉपर्टीज़—फ़िल, लाइन और इफ़ेक्ट सेटिंग्स—की तुलना करें। यदि सभी संबंधित मान मेल खाते हैं, तो उनके स्टाइल को समान मानें और उन शैप को तार्किक रूप से समूहित करें, जिससे बाद में स्टाइल प्रबंधन सरल हो जाता है।

**क्या मैं कस्टम शैप शैली का सेट किसी अलग फ़ाइल में सेव करके अन्य प्रस्तुतियों में पुनः उपयोग कर सकता हूँ?**

हाँ। इच्छित शैली वाले नमूना शैप को टेम्पलेट स्लाइड डेक या .POTX टेम्पलेट फ़ाइल में संग्रहीत करें। नई प्रस्तुति बनाते समय टेम्पलेट खोलें, आवश्यक स्टाइल वाले शैप को क्लोन करें और जहाँ‑जहाँ जरूरत हो फ़ॉर्मेटिंग पुनः लागू करें।