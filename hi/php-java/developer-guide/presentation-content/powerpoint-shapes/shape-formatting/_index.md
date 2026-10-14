---
title: PHP में PowerPoint शैलियों को स्वरूपित करें
linktitle: आकृति स्वरूपण
type: docs
weight: 20
url: /hi/php-java/shape-formatting/
keywords:
- आकार स्वरूपण
- रेखा स्वरूपण
- स्केच प्रभाव
- स्केच आकार रेखा
- जॉइन शैली स्वरूपण
- ग्रेडिएंट भराव
- पैटर्न भराव
- चित्र भराव
- टेक्सचर भराव
- एकरंगी भराव
- आकार ट्रांसपैरेंसी
- ब्लैक-एंड-व्हाइट आकार रेंडरिंग
- ग्रेस्केल आकार रेंडरिंग
- आकार घुमाएँ
- 3D बिवेल प्रभाव
- 3D घूर्णन प्रभाव
- फ़ॉर्मेट रीसेट
- PowerPoint
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Aspose.Slides का उपयोग करके PHP में PowerPoint शकलों को स्वरूपित करना सीखें—PPT, PPTX और ODP फ़ाइलों के लिये भराव, रेखा और प्रभाव शैलियों को सटीकता और पूर्ण नियंत्रण के साथ सेट करें।"
---
## **परिचय**

PowerPoint में, आप स्लाइड में शकलें जोड़ सकते हैं। चूँकि शकलें लाइनों से बनी होती हैं, आप उनकी रूपरेखा को परिवर्तित करके या प्रभाव लगाकर स्वरूपित कर सकते हैं। अतिरिक्त रूप से, आप शकलों को इस प्रकार सेटिंग्स निर्दिष्ट करके स्वरूपित कर सकते हैं जो नियंत्रित करती हैं कि उनके अंदरूनी भाग को कैसे भरा जाए।

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for PHP via Java क्लास और मेथड प्रदान करता है जो आपको PowerPoint में उपलब्ध वही विकल्पों का उपयोग करके शकलें स्वरूपित करने की अनुमति देते हैं।

## **लाइन स्वरूपित करें**

Aspose.Slides का उपयोग करके, आप किसी शकल के लिये कस्टम लाइन शैली निर्दिष्ट कर सकते हैं। निम्नलिखित चरण प्रक्रिया को रेखांकित करते हैं:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) class.
2. Get a reference to a slide by its index.
3. Add an [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) to the slide.
4. Set the [line style](https://reference.aspose.com/slides/php-java/aspose.slides/linestyle/) of the shape.
5. Set the line width.
6. Set the [dash style](https://reference.aspose.com/slides/php-java/aspose.slides/linedashstyle/) of the line.
7. Set the line color for the shape.
8. Save the modified presentation as a PPTX file.

The following PHP code demonstrates how to format a rectangle `AutoShape`:

```php
// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंशिएट करें।
$presentation = new Presentation();
try {
    // पहली स्लाइड प्राप्त करें।
    $slide = $presentation->getSlides()->get_Item(0);

    // Rectangle प्रकार की एक ऑटो शकल जोड़ें।
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 150, 75);

    // Rectangle शकल के लिए भराव रंग सेट करें।
    $shape->getFillFormat()->setFillType(FillType::NoFill);

    // Rectangle की लाइनों पर स्वरूपण लागू करें।
    $shape->getLineFormat()->setStyle(LineStyle::ThickThin);
    $shape->getLineFormat()->setWidth(7);
    $shape->getLineFormat()->setDashStyle(LineDashStyle::Dash);

    // Rectangle की रेखा का रंग सेट करें।
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);

    // PPTX फ़ाइल को डिस्क पर सहेजें।
    $presentation->save("formatted_lines.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

परिणाम:

![प्रस्तुति में स्वरूपित लाइन्स](formatted-lines.png)

## **आकार लाइनों पर स्केच प्रभाव लागू करें**

स्केच प्रभाव किसी शकल की लाइन को हाथ‑से‑खींचा हुआ दिखाता है। लाइन सेटिंग्स तक पहुँचने के लिए [Shape.getLineFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) का उपयोग करें, स्केच सेटिंग्स तक पहुँचने के लिये [LineFormat.getSketchFormat](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/) का उपयोग करें, और [SketchFormat.setSketchType](https://reference.aspose.com/slides/php-java/aspose.slides/sketchformat/) का उपयोग करके [LineSketchType](https://reference.aspose.com/slides/php-java/aspose.slides/linesketchtype/) एन्ह्यूमरेशन से मान चुनें।

निम्न PHP कोड दर्शाता है कि कैसे [LineSketchType.Curved](https://reference.aspose.com/slides/php-java/aspose.slides/linesketchtype/) प्रभाव लागू किया जाए, स्पष्ट रूप से निर्धारित मान पढ़ा जाए, और [LineSketchType.None](https://reference.aspose.com/slides/php-java/aspose.slides/linesketchtype/) के साथ प्रभाव हटाया जाए:

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);

    // शकल के लाइन फ़ॉर्मेट और उसके स्केच फ़ॉर्मेट तक पहुँचें।
    $sketchFormat = $shape->getLineFormat()->getSketchFormat();

    // एक स्केच प्रभाव लागू करें।
    $sketchFormat->setSketchType(LineSketchType::Curved);

    // शकल को सीधे सौंपे गए स्केच प्रभाव को पढ़ें।
    $explicitSketchType = $sketchFormat->getSketchType();
    echo "Explicit sketch type: " . $explicitSketchType . PHP_EOL;

    // स्केच प्रभाव हटाएँ।
    $sketchFormat->setSketchType(LineSketchType::None);
} finally {
    $presentation->dispose();
}
```

[SketchFormat.getSketchType](https://reference.aspose.com/slides/php-java/aspose.slides/sketchformat/) द्वारा लौटाया गया मान शकल को सीधे सौंपे गए सेटिंग को दर्शाता है। यदि लाइन फ़ॉर्मेट थीम, मास्टर स्लाइड या लेआउट स्लाइड से विरासत में मिला हो, तो [LineFormat.getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/) का उपयोग करें, लौटाए गये ऑब्जेक्ट की `getSketchFormat` मेथड को एक्सेस करें, और उसके `getSketchType` मान को पढ़ें। प्रभावी मान उस फ़ॉर्मेट को दर्शाता है जो विरासत के हल होने के बाद वास्तविक रूप से लागू होता है:

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

## **जॉइन शैलियों को स्वरूपित करें**

तीन जॉइन प्रकार विकल्प हैं:

* Round
* Miter
* Bevel

डिफ़ॉल्ट रूप से, जब PowerPoint दो लाइनों को कोण पर (जैसे शकल के कोने पर) जोड़ता है, तो यह **Round** सेटिंग का उपयोग करता है। हालांकि, यदि आप तीखे कोण वाली शकल बना रहे हैं, तो आप **Mitter** विकल्प को प्राथमिकता दे सकते हैं।

![प्रस्तुति में जॉइन स्टाइल](join-style-powerpoint.png)

निम्न PHP कोड दर्शाता है कि ऊपर दिखाए गए चित्र में Miter, Bevel, और Round जॉइन प्रकार सेटिंग्स का उपयोग करके तीन आयतें कैसे बनाई गईं:

```php
// एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंशिएट करें।
$presentation = new Presentation();
try {
    // पहली स्लाइड प्राप्त करें।
    $slide = $presentation->getSlides()->get_Item(0);

    // Rectangle प्रकार की तीन ऑटो शकलें जोड़ें।
    $shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 150, 75);
    $shape2 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 210, 20, 150, 75);
    $shape3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 135, 150, 75);

    // प्रत्येक आयत शकल के लिए भराव रंग सेट करें।
    $shape1->getFillFormat()->setFillType(FillType::Solid);
    $shape1->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $shape2->getFillFormat()->setFillType(FillType::Solid);
    $shape2->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $shape3->getFillFormat()->setFillType(FillType::Solid);
    $shape3->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);

    // रेखा की चौड़ाई सेट करें।
    $shape1->getLineFormat()->setWidth(15);
    $shape2->getLineFormat()->setWidth(15);
    $shape3->getLineFormat()->setWidth(15);

    // प्रत्येक आयत की रेखा का रंग सेट करें।
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

    // प्रत्येक आयत में टेक्स्ट जोड़ें।
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

PowerPoint में, Gradient Fill एक फ़ॉर्मेटिंग विकल्प है जो आपको शकल पर निरन्तर रंग मिश्रण लागू करने की अनुमति देता है। उदाहरण के लिये, आप दो या अधिक रंग इस प्रकार लागू कर सकते हैं कि एक धीरे‑धीरे दूसरे में मिल जाए।

Aspose.Slides का उपयोग करके शकल पर ग्रेडिएंट फ़िल लागू करने के लिये:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) class.
2. Get a reference to a slide by its index.
3. Add an [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) to the slide.
4. Set the shape's [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) to `Gradient`.
5. Add your two preferred colors with defined positions using the `add` methods of the gradient stop collection exposed by the [GradientFormat](https://reference.aspose.com/slides/php-java/aspose.slides/gradientformat/) class.
6. Save the modified presentation as a PPTX file.

निम्न PHP कोड दर्शाता है कि कैसे एक दीर्घवृत्त पर ग्रेडिएंट फ़िल प्रभाव लागू किया जाए:

```php
// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंशिएट करें।
$presentation = new Presentation();
try {
    // पहली स्लाइड प्राप्त करें।
    $slide = $presentation->getSlides()->get_Item(0);

    // Ellipse प्रकार की एक ऑटो शकल जोड़ें।
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 50, 150, 75);

    // दीर्घवृत्त पर ग्रेडिएंट फ़ॉर्मेटिंग लागू करें।
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

![ग्रेडिएंट फ़िल वाले दीर्घवृत्त](gradient-fill.png)

यदि ग्रेडिएंट निर्यातित चित्र में PowerPoint की तुलना में अलग दिखता है, तो देखें [Choose a Gradient Rendering Style](/slides/hi/php-java/convert-powerpoint-to-png/#choose-a-gradient-rendering-style)। आप प्रस्तुति में संग्रहीत ग्रेडिएंट फ़िल को बदले बिना रेंडरिंग शैली चुन सकते हैं।

## **पैटर्न फ़िल**

PowerPoint में, Pattern Fill एक फ़ॉर्मेटिंग विकल्प है जो आपको दो‑रंग की डिज़ाइन—जैसे डॉट्स, स्ट्राइप्स, क्रॉसहैचेज़ या चेक्स—शकल पर लागू करने देता है। आप पैटर्न के अग्रभूमि और पृष्ठभूमि के लिये कस्टम रंग चुन सकते हैं।

Aspose.Slides 45 से अधिक पूर्वनिर्धारित पैटर्न शैलियों को प्रदान करता है जिन्हें आप शकलों पर लागू करके प्रस्तुति की दृश्य आकर्षण बढ़ा सकते हैं। पूर्वनिर्धारित पैटर्न चुनने के बाद भी, आप सटीक रंग निर्दिष्ट कर सकते हैं।

शकल पर पैटर्न फ़िल लागू करने के लिये:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) class.
2. Get a reference to a slide by its index.
3. Add an [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) to the slide.
4. Set the shape’s [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) to `Pattern`.
5. Choose a pattern style from the predefined options.
6. Set the [Background Color](https://reference.aspose.com/slides/php-java/aspose.slides/patternformat/#getBackColor) of the pattern.
7. Set the [Foreground Color](https://reference.aspose.com/slides/php-java/aspose.slides/patternformat/#getForeColor) of the pattern.
8. Save the modified presentation as a PPTX file.

निम्न PHP कोड दर्शाता है कि कैसे एक आयत पर पैटर्न फ़िल लागू किया जाए:

```php
// एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंशिएट करें।
$presentation = new Presentation();
try {
    // पहली स्लाइड प्राप्त करें।
    $slide = $presentation->getSlides()->get_Item(0);

    // Rectangle प्रकार की एक ऑटो शकल जोड़ें।
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // भरण प्रकार को Pattern सेट करें।
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

![पैटर्न फ़िल वाली आयत](pattern-fill.png)

## **चित्र फ़िल**

PowerPoint में, Picture Fill एक फ़ॉर्मेटिंग विकल्प है जो आपको शकल के भीतर चित्र डालने की अनुमति देता है—वास्तव में चित्र को शकल की पृष्ठभूमि के रूप में उपयोग करता है।

Aspose.Slides का उपयोग करके शकल पर पिक्चर फ़िल लागू करने के लिये:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) class.
2. Get a reference to a slide by its index.
3. Add an [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) to the slide.
4. Set the shape's [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) to `Picture`.
5. Set the picture fill mode to `Tile` (or another preferred mode).
6. Create an [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) object from the image you want to use.
7. Pass the image to the `SlidesPicture.setImage` method.
8. Save the modified presentation as a PPTX file.

मान लें कि हमारे पास "lotus.png" फ़ाइल है जिसमें यह चित्र है:

![लोटस चित्र](lotus.png)

निम्न PHP कोड दर्शाता है कि कैसे शकल को चित्र से भरा जाए:

```php
// एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंशिएट करें।
$presentation = new Presentation();
try {
    // पहली स्लाइड प्राप्त करें।
    $slide = $presentation->getSlides()->get_Item(0);

    // Rectangle प्रकार की एक ऑटो शकल जोड़ें।
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 255, 130);

    // भरण प्रकार को Picture सेट करें।
    $shape->getFillFormat()->setFillType(FillType::Picture);

    // चित्र भराव मोड सेट करें।
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

![चित्र फ़िल वाला शकल](picture-fill.png)

### **टाइल चित्र को टेक्सचर के रूप में उपयोग करें**

यदि आप टाइल्ड चित्र को टेक्सचर के रूप में सेट करना और टाइलिंग व्यवहार को अनुकूलित करना चाहते हैं, तो आप [PictureFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/) क्लास की निम्न विधियों का उपयोग कर सकते हैं:

- [setPictureFillMode](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setPictureFillMode): टाइलिंग मोड सेट करता है—`Tile` या `Stretch`।
- [setTileAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileAlignment): शकल के भीतर टाइलों की संरेखण निर्धारित करता है।
- [setTileFlip](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileFlip): टाइल को क्षैतिज, ऊर्ध्वाधर या दोनों दिशा में फ्लिप करने को नियंत्रित करता है।
- [setTileOffsetX](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileOffsetX): शकल की मूल बिंदु से टाइल का क्षैतिज ऑफ़सेट सेट करता है (पॉइंट्स में)।
- [setTileOffsetY](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileOffsetY): शकल की मूल बिंदु से टाइल का ऊर्ध्वाधर ऑफ़सेट सेट करता है (पॉइंट्स में)।
- [setTileScaleX](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileScaleX): टाइल का क्षैतिज स्केल प्रतिशत में परिभाषित करता है।
- [setTileScaleY](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileScaleY): टाइल का ऊर्ध्वाधर स्केल प्रतिशत में परिभाषित करता है।

निम्न कोड नमूना दिखाता है कि कैसे एक आयत शकल को टाइल्ड चित्र फ़िल के साथ जोड़ें और टाइल विकल्प कॉन्फ़िगर करें:

```php
// एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंशिएट करें।
$presentation = new Presentation();
try {
    // पहली स्लाइड प्राप्त करें।
    $firstSlide = $presentation->getSlides()->get_Item(0);

    // एक आयत ऑटो शकल जोड़ें।
    $shape = $firstSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 190, 95);

    // शकल के भरण प्रकार को Picture सेट करें।
    $shape->getFillFormat()->setFillType(FillType::Picture);

    // चित्र लोड करें और इसे प्रस्तुति संसाधनों में जोड़ें।
    $sourceImage = Images::fromFile("lotus.png");
    $presentationImage = $presentation->getImages()->addImage($sourceImage);
    $sourceImage->dispose();

    // चित्र को शकल में असाइन करें।
    $pictureFillFormat = $shape->getFillFormat()->getPictureFillFormat();
    $pictureFillFormat->getPicture()->setImage($presentationImage);

    // चित्र भराव मोड और टाइलिंग गुण कॉन्फ़िगर करें।
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

![टाइल विकल्प](tile-options.png)

## **एकरंगी फ़िल**

PowerPoint में, Solid Color Fill एक फ़ॉर्मेटिंग विकल्प है जो शकल को एक ही समान रंग से भरता है। यह साधारण पृष्ठभूमि रंग बिना किसी ग्रेडिएंट, टेक्सचर या पैटर्न के लागू किया जाता है।

Aspose.Slides का उपयोग करके शकल पर एकरंगी फ़िल लागू करने के लिये, नीचे दिए गये चरणों का पालन करें:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) class.
2. Get a reference to a slide by its index.
3. Add an [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) to the slide.
4. Set the shape’s [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) to `Solid`.
5. Assign your preferred fill color to the shape.
6. Save the modified presentation as a PPTX file.

निम्न PHP कोड दर्शाता है कि कैसे एक आयत पर एकरंगी फ़िल लागू किया जाए:

```php
// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंशिएट करें।
$presentation = new Presentation();
try {
    // पहली स्लाइड प्राप्त करें।
    $slide = $presentation->getSlides()->get_Item(0);

    // Rectangle प्रकार की एक ऑटो शकल जोड़ें।
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // भरण प्रकार को Solid सेट करें।
    $shape->getFillFormat()->setFillType(FillType::Solid);

    // भरण रंग सेट करें।
    $shape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);

    // PPTX फ़ाइल को डिस्क पर सहेजें।
    $presentation->save("solid_color_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

परिणाम:

![एकरंगी फ़िल वाला शकल](solid-color-fill.png)

## **ट्रांसपैरेंसी सेट करें**

PowerPoint में, जब आप शकलों पर सॉलिड रंग, ग्रेडिएंट, चित्र या टेक्सचर फ़िल लागू करते हैं, तो आप फ़िल की अपारदर्शिता स्तर को सेट करके उसकी पारदर्शिता नियंत्रित कर सकते हैं। उच्च ट्रांसपैरेंसी मान शकल को अधिक पारदर्शी बनाता है, जिससे पृष्ठभूमि या नीचे की वस्तुएँ आंशिक रूप से दिखाई देती हैं।

Aspose.Slides आपको फ़िल के लिये उपयोग किए गए रंग के अल्फा मान को समायोजित करके ट्रांसपैरेंसी स्तर सेट करने की अनुमति देता है। यह करने के लिए:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) class.
2. Get a reference to a slide by its index.
3. Add an [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) to the slide.
4. Set the [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) to `Solid`.
5. Use `Color` to define a color with transparency (the `alpha` component controls transparency).
6. Save the presentation.

निम्न PHP कोड दर्शाता है कि कैसे एक आयत पर पारदर्शी फ़िल रंग लागू किया जाए:

```php
// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंशिएट करें।
$presentation = new Presentation();
try {
    // पहली स्लाइड प्राप्त करें।
    $slide = $presentation->getSlides()->get_Item(0);

    // एक सॉलिड आयत ऑटो शकल जोड़ें।
    $solidShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // सॉलिड शकल के ऊपर एक पारदर्शी आयत ऑटो शकल जोड़ें।
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

![पारदर्शी शकल](shape-transparency.png)

## **शकलें घुमाएँ**

Aspose.Slides आपको PowerPoint प्रस्तुतियों में शकलों को घुमाने की सुविधा देता है। यह विशिष्ट संरेखण या डिज़ाइन आवश्यकताओं के साथ दृश्य तत्वों को स्थान देने में उपयोगी हो सकता है।

किसी स्लाइड पर शकल को घुमाने के लिये, नीचे दिए गये चरणों का पालन करें:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) class.
2. Get a reference to a slide by its index.
3. Add an [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) to the slide.
4. Set the shape’s rotation property to the desired angle.
5. Save the presentation.

निम्न PHP कोड दर्शाता है कि कैसे शकल को 5 डिग्री घुमाया जाए:

```php
// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंशिएट करें।
$presentation = new Presentation();
try {
    // पहली स्लाइड प्राप्त करें।
    $slide = $presentation->getSlides()->get_Item(0);

    // Rectangle प्रकार की एक ऑटो शकल जोड़ें।
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // शकल को 5 डिग्री घुमाएँ।
    $shape->setRotation(5);

    // PPTX फ़ाइल को डिस्क पर सहेजें।
    $presentation->save("shape_rotation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

परिणाम:

![शकल का रोटेशन](shape-rotation.png)

## **3D बिवेल इफ़ेक्ट जोड़ें**

Aspose.Slides आपको शकलों पर 3D बिवेल प्रभाव लागू करने की अनुमति देता है, जिसके लिये आप उनके [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/) गुणों को कॉन्फ़िगर करते हैं।

शकल पर 3D बिवेल प्रभाव जोड़ने के लिये, नीचे दिए गये चरणों का पालन करें:

1. Instantiate the [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) class.
2. Get a reference to a slide by its index.
3. Add an [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) to the slide.
4. Configure the shape’s [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/) to define bevel settings.
5. Save the presentation.

निम्न PHP कोड दर्शाता है कि कैसे शकल पर 3D बिवेल प्रभाव लागू किया जाए:

```php
// Presentation क्लास का एक इंस्टेंस बनाएं।
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // स्लाइड में एक शकल जोड़ें।
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 50, 100, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->ORANGE);
    $shape->getLineFormat()->setWidth(2.0);

    // शकल की ThreeDFormat गुण सेट करें।
    $shape->getThreeDFormat()->setDepth(4);
    $shape->getThreeDFormat()->getBevelTop()->setBevelType(BevelPresetType::Circle);
    $shape->getThreeDFormat()->getBevelTop()->setHeight(6);
    $shape->getThreeDFormat()->getBevelTop()->setWidth(6);
    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::ThreePt);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);

    // प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।
    $presentation->save("3D_bevel_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

परिणाम:

![3D बिवेल प्रभाव](3D-bevel-effect.png)

## **3D रोटेशन इफ़ेक्ट जोड़ें**

Aspose.Slides आपको शकलों पर 3D रोटेशन प्रभाव लागू करने की अनुमति देता है, जिसके लिये आप उनके [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/) गुणों को कॉन्फ़िगर करते हैं।

शकल पर 3D रोटेशन लागू करने के लिये:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) class.
2. Get a reference to a slide by its index.
3. Add an [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) to the slide.
4. Use the [setCameraType](https://reference.aspose.com/slides/php-java/aspose.slides/camera/#setCameraType) and [setLightType](https://reference.aspose.com/slides/php-java/aspose.slides/lightrig/#setLightType) to define the 3D rotation.
5. Save the presentation.

निम्न PHP कोड दर्शाता है कि कैसे शकल पर 3D रोटेशन प्रभाव लागू किया जाए:

```php
// Presentation क्लास का एक इंस्टेंस बनाएं।
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
    $autoShape->getTextFrame()->setText("Hello, Aspose!");

    $autoShape->getThreeDFormat()->setDepth(6);
    $autoShape->getThreeDFormat()->getCamera()->setRotation(40, 35, 20);
    $autoShape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::IsometricLeftUp);
    $autoShape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);

    // प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।
    $presentation->save("3D_rotation_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

परिणाम:

![3D रोटेशन प्रभाव](3D-rotation-effect.png)

## **शकलों के लिए ब्लैक-एंड-व्हाइट रेंडरिंग नियंत्रित करें**

[Shape::setBlackWhiteMode](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setBlackWhiteMode) मेथड यह निर्दिष्ट करता है कि जब प्रस्तुति को ब्लैक‑एंड‑व्हाइट मोड में देखा या प्रोसेस किया जाता है तो व्यक्तिगत शकल कैसे रेंडर की जाती है। यह स्वयं ब्लैक‑एंड‑व्हाइट डिस्प्ले सक्षम नहीं करता, और सामान्य रंग मोड में शकल की फ़िल, लाइन या अन्य फ़ॉर्मेटिंग को नहीं बदलता।

इच्छित व्यवहार चुनने के लिये आप [BlackWhiteMode](https://reference.aspose.com/slides/php-java/aspose.slides/blackwhitemode/) क्लास के मान का उपयोग कर सकते हैं। उदाहरण के लिये, `Automatic` रेंडरिंग एप्लिकेशन को रूपांतरण चुनने देता है, `Gray` और `LightGray` ग्रे रंग का उपयोग करते हैं, `BlackWhite` केवल काली और सफेद का उपयोग करता है, `Black` और `White` एकल रंग को लागू करते हैं, `Color` सामान्य रंग बनाए रखता है, और `Hidden` ब्लैक‑एंड‑व्हाइट मोड में शकल को छोड़ देता है। `NotDefined` का अर्थ है कि शकल‑स्तर का कोई मोड निर्धारित नहीं है।

निम्न PHP कोड एक रंगीन शकल बनाता है और ब्लैक‑एंड‑व्हाइट डिस्प्ले मोड में इसे ग्रे दिखाता है:

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

    // रंग मोड में नारंगी भराव रखें, लेकिन ब्लैक-एंड-व्हाइट मोड में शकल को ग्रे रंग में रेंडर करें।
    $shape->setBlackWhiteMode(BlackWhiteMode::Gray);

    $presentation->save("shape_black_white_mode.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

सामान्य रंग मोड में, आयत अपनी नारंगी फ़िल बरकरार रखती है। ब्लैक‑एंड‑व्हाइट डिस्प्ले वर्कफ़्लो में, इसका मोड `Gray` होने के कारण यह ग्रे रंग दिखाता है। यह आपको पूर्ण‑रंग स्लाइड बनाए रखने और प्रिंटिंग, प्रीव्यू या अन्य वर्कफ़्लो में अलग दिखावट परिभाषित करने की सुविधा देता है।

## **फ़ॉर्मेट रीसेट करें**

निम्न Java कोड दिखाता है कि कैसे स्लाइड का फ़ॉर्मेट रीसेट किया जाए और [LayoutSlide](https://reference.aspose.com/slides/php-java/aspose.slides/layoutslide/) पर प्लेसहोल्डर वाले सभी शकलों की स्थिति, आकार और फ़ॉर्मेट को उनकी डिफ़ॉल्ट सेटिंग्स पर वापस लाया जाए:

```php
$presentation = new Presentation("sample.pptx");
try {
    for ($i = 0; $i < java_values($presentation->getSlides()->size()); $i++) {
        $slide = $presentation->getSlides()->get_Item($i);
        // लेआउट पर प्लेसहोल्डर वाला स्लाइड में प्रत्येक शकल को रीसेट करें।
        $slide->reset();
    }
    $presentation->save("reset_formatting.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या शकल फ़ॉर्मेटिंग अंतिम प्रस्तुति फ़ाइल आकार को प्रभावित करती है?**

केवल न्यूनतम रूप से। एम्बेडेड छवियों और मीडिया फ़ाइलें अधिकांश स्थान लेती हैं, जबकि शकल पैरामीटर जैसे रंग, प्रभाव और ग्रेडिएंट मेटाडेटा के रूप में संग्रहीत होते हैं और लगभग कोई अतिरिक्त आकार नहीं जोड़ते।

**मैं कैसे उन शकलों का पता लगा सकता हूँ जो स्लाइड पर समान फ़ॉर्मेटिंग साझा करती हैं ताकि मैं उन्हें समूहित कर सकूँ?**

प्रत्येक शकल के मुख्य फ़ॉर्मेटिंग गुण—फ़िल, लाइन और प्रभाव सेटिंग्स—की तुलना करें। यदि सभी संबंधित मान मेल खाते हैं, तो उनके स्टाइल को समान मानें और उन शकलों को तर्कसंगत रूप से समूहित करें, जिससे बाद में स्टाइल प्रबंधन आसान हो जाता है।

**क्या मैं कस्टम शकल शैलियों का एक सेट अलग फ़ाइल में सहेज सकता हूँ ताकि अन्य प्रस्तुतियों में पुनः उपयोग किया जा सके?**

हां। वांछित शैलियों वाले नमूना शकलों को टेम्पलेट स्लाइड डेक या .POTX टेम्पलेट फ़ाइल में संग्रहीत करें। नया प्रस्तुति बनाते समय टेम्पलेट खोलें, आवश्यक शैलियों वाले शकलों को क्लोन करें, और जहाँ आवश्यक हो फ़ॉर्मेटिंग पुनः लागू करें।