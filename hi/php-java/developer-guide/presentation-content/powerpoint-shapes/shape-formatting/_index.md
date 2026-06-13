---
title: PHP में PowerPoint आकृतियों का स्वरूपण
linktitle: आकृति स्वरूपण
type: docs
weight: 20
url: /hi/php-java/shape-formatting/
keywords:
- आकार स्वरूपित करें
- रेखा स्वरूपित करें
- जॉइन शैली स्वरूपित करें
- ग्रेडिएंट भराव
- पैटर्न भराव
- चित्र भराव
- टेक्सचर भराव
- एकसमान रंग भराव
- आकृति पारदर्शिता
- आकृति घुमाएँ
- 3D बिवेल प्रभाव
- 3D घूर्णन प्रभाव
- स्वरूपण रीसेट करें
- PowerPoint
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Aspose.Slides का उपयोग करके PHP में PowerPoint आकृतियों को स्वरूपित करना सीखें—PPT, PPTX और ODP फ़ाइलों के लिए भराव, रेखा और प्रभाव शैलियों को सटीकता और पूर्ण नियंत्रण के साथ सेट करें।"
---
## **परिचय**

PowerPoint में, आप स्लाइड्स में आकृतियों को जोड़ सकते हैं। चूँकि आकृतियाँ रेखाओं से बनती हैं, आप उनके बाहरी रूपरेखा को संशोधित या प्रभाव लागू करके स्वरूपित कर सकते हैं। इसके अतिरिक्त, आप आकृतियों को उनके अंदरूनी भाग को कैसे भरना है, इस सेटिंग को निर्धारित करके भी स्वरूपित कर सकते हैं।

![PowerPoint में आकृति स्वरूपण](format-shape-powerpoint.png)

Aspose.Slides for PHP via Java वह क्लास और मेथड प्रदान करता है जो आपको PowerPoint में उपलब्ध वही विकल्पों का उपयोग करके आकृतियों को स्वरूपित करने की अनुमति देता है।

## **रेखाओं का स्वरूपण**

Aspose.Slides का उपयोग करके, आप एक आकृति के लिए कस्टम रेखा शैली निर्दिष्ट कर सकते हैं। निम्नलिखित चरण प्रक्रिया को रेखांकित करते हैं:

1. [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) वर्ग का एक उदाहरण बनाएँ।
1. इंडेक्स द्वारा एक स्लाइड का संदर्भ प्राप्त करें।
1. स्लाइड में एक [AutoShape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/autoshape/) जोड़ें।
1. आकृति की [line style](https://reference.aspose.com/slides/hi/php-java/aspose.slides/linestyle/) सेट करें।
1. रेखा की चौड़ाई सेट करें।
1. रेखा की [dash style](https://reference.aspose.com/slides/hi/php-java/aspose.slides/linedashstyle/) सेट करें।
1. आकृति के लिए रेखा का रंग सेट करें।
1. परिवर्तित प्रेजेंटेशन को PPTX फ़ाइल के रूप में सहेजें।

निम्नलिखित PHP कोड दर्शाता है कि कैसे एक आयत `AutoShape` को स्वरूपित किया जाए:

```php
// Presentation क्लास को इंस्टैंशिएट करें जो एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है।
$presentation = new Presentation();
try {
    // पहली स्लाइड प्राप्त करें।
    $slide = $presentation->getSlides()->get_Item(0);

    // Rectangle प्रकार की एक ऑटो शेप जोड़ें।
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 150, 75);

    // Rectangle आकृति के लिए भराव रंग सेट करें।
    $shape->getFillFormat()->setFillType(FillType::NoFill);

    // Rectangle की रेखाओं पर स्वरूपण लागू करें।
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

![प्रेजेंटेशन में स्वरूपित रेखाएँ](formatted-lines.png)

## **जॉइन शैली का स्वरूपण**

यहाँ तीन जॉइन प्रकार विकल्प हैं:

* Round
* Miter
* Bevel

डिफ़ॉल्ट रूप से, जब PowerPoint दो रेखाओं को कोण पर जोड़ता है (जैसे आकृति के कोने पर), यह **Round** सेटिंग का उपयोग करता है। हालांकि, यदि आप तीखे कोण वाली आकृति बना रहे हैं, तो आप **Miter** विकल्प को पसंद कर सकते हैं।

![प्रेजेंटेशन में जॉइन शैली](join-style-powerpoint.png)

निम्नलिखित PHP कोड दर्शाता है कि ऊपर दिखी छवि में तीन आयतें Miter, Bevel और Round जॉइन प्रकार सेटिंग्स का उपयोग करके कैसे बनाई गईं:

```php
// Presentation क्लास को इंस्टैंशिएट करें जो एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है।
$presentation = new Presentation();
try {
    // पहली स्लाइड प्राप्त करें।
    $slide = $presentation->getSlides()->get_Item(0);

    // Rectangle प्रकार की तीन ऑटो शेप्स जोड़ें।
    $shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 150, 75);
    $shape2 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 210, 20, 150, 75);
    $shape3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 135, 150, 75);

    // प्रत्येक आयत आकृति के लिए भराव रंग सेट करें।
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

PowerPoint में, Gradient Fill एक स्वरूपण विकल्प है जो आपको एक आकृति पर निरंतर रंगों का मिश्रण लागू करने की अनुमति देता है। उदाहरण के लिए, आप दो या अधिक रंग इस तरह लागू कर सकते हैं कि एक धीरे‑धीरे दूसरे में मिल जाए।

Aspose.Slides का उपयोग करके एक आकृति पर ग्रेडिएंट फ़िल लागू करने का तरीका इस प्रकार है:

1. [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) वर्ग का एक उदाहरण बनाएँ।
1. इंडेक्स द्वारा एक स्लाइड का संदर्भ प्राप्त करें।
1. स्लाइड में एक [AutoShape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/autoshape/) जोड़ें।
1. आकृति की [FillType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/filltype/) को `Gradient` सेट करें।
1. [GradientFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/gradientformat/) वर्ग द्वारा प्रदत्त ग्रेडिएंट स्टॉप संग्रह की `add` विधियों का उपयोग करके परिभाषित स्थितियों के साथ अपनी दो पसंदीदा रंग जोड़ें।
1. परिवर्तित प्रेजेंटेशन को PPTX फ़ाइल के रूप में सहेजें।

```php
// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाले Presentation क्लास को इंस्टैंशिएट करें।
$presentation = new Presentation();
try {
    // पहली स्लाइड प्राप्त करें।
    $slide = $presentation->getSlides()->get_Item(0);

    // Ellipse प्रकार की एक ऑटो शेप जोड़ें।
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 50, 150, 75);

    // दीप्तिक (ellipse) पर ग्रेडिएंट स्वरूपण लागू करें।
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

![ग्रेडिएंट फ़िल के साथ दीर्घवृत्त](gradient-fill.png)

## **पैटर्न फ़िल**

PowerPoint में, Pattern Fill एक स्वरूपण विकल्प है जो आपको आकृति पर दो‑रंगी डिज़ाइन—जैसे बिंदु, धारियाँ, क्रॉसहैच या चेक—लगाने की अनुमति देता है। आप पैटर्न के अग्रभूमि और पृष्ठभूमि के लिए कस्टम रंग चुन सकते हैं।

Aspose.Slides 45 से अधिक पूर्वनिर्धारित पैटर्न शैलियाँ प्रदान करता है जिन्हें आप अपनी प्रस्तुतियों की दृश्य अपील बढ़ाने के लिए आकृतियों पर लागू कर सकते हैं। पूर्वनिर्धारित पैटर्न चुनने के बाद भी आप उसके द्वारा उपयोग किए जाने वाले सटीक रंग निर्दिष्ट कर सकते हैं।

Aspose.Slides का उपयोग करके एक आकृति पर पैटर्न फ़िल लागू करने का तरीका इस प्रकार है:

1. [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) वर्ग का एक उदाहरण बनाएँ।
1. इंडेक्स द्वारा एक स्लाइड का संदर्भ प्राप्त करें।
1. स्लाइड में एक [AutoShape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/autoshape/) जोड़ें।
1. आकृति की [FillType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/filltype/) को `Pattern` सेट करें।
1. प्राथमिक विकल्पों से एक पैटर्न शैली चुनें।
1. [Background Color](https://reference.aspose.com/slides/hi/php-java/aspose.slides/patternformat/#getBackColor) सेट करें।
1. [Foreground Color](https://reference.aspose.com/slides/hi/php-java/aspose.slides/patternformat/#getForeColor) सेट करें।
1. परिवर्तित प्रेजेंटेशन को PPTX फ़ाइल के रूप में सहेजें।

```php
// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाले Presentation क्लास को इंस्टैंशिएट करें।
$presentation = new Presentation();
try {
    // पहली स्लाइड प्राप्त करें।
    $slide = $presentation->getSlides()->get_Item(0);

    // Rectangle प्रकार की एक ऑटो शेप जोड़ें।
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // भराव प्रकार को Pattern सेट करें।
    $shape->getFillFormat()->setFillType(FillType::Pattern);

    // पैटर्न शैली सेट करें।
    $shape->getFillFormat()->getPatternFormat()->setPatternStyle(PatternStyle::Trellis);

    // पैटर्न पृष्ठभूमि और अग्रभूमि रंग सेट करें।
    $shape->getFillFormat()->getPatternFormat()->getBackColor()->setColor(java("java.awt.Color")->LIGHT_GRAY);
    $shape->getFillFormat()->getPatternFormat()->getForeColor()->setColor(java("java.awt.Color")->YELLOW);

    // PPTX फ़ाइल को डिस्क पर सहेजें।
    $presentation->save("pattern_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

परिणाम:

![पैटर्न फ़िल के साथ आयत](pattern-fill.png)

## **चित्र फ़िल**

PowerPoint में, Picture Fill एक स्वरूपण विकल्प है जो आपको एक आकृति के भीतर एक छवि सम्मिलित करने की अनुमति देता है—वास्तव में छवि को आकृति की पृष्ठभूमि के रूप में उपयोग करता है।

Aspose.Slides का उपयोग करके एक आकृति पर चित्र फ़िल लागू करने का तरीका इस प्रकार है:

1. [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) वर्ग का एक उदाहरण बनाएँ।
1. इंडेक्स द्वारा एक स्लाइड का संदर्भ प्राप्त करें।
1. स्लाइड में एक [AutoShape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/autoshape/) जोड़ें।
1. आकृति की [FillType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/filltype/) को `Picture` सेट करें।
1. चित्र फ़िल मोड को `Tile` (या कोई अन्य पसंदीदा मोड) सेट करें।
1. आप जिस चित्र का उपयोग करना चाहते हैं, उससे एक [PPImage](https://reference.aspose.com/slides/hi/php-java/aspose.slides/ppimage/) ऑब्जेक्ट बनाएँ।
1. इमेज को `SlidesPicture.setImage` मेथड में पास करें।
1. परिवर्तित प्रेजेंटेशन को PPTX फ़ाइल के रूप में सहेजें।

```php
// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाले Presentation क्लास को इंस्टैंशिएट करें।
$presentation = new Presentation();
try {
    // पहली स्लाइड प्राप्त करें।
    $slide = $presentation->getSlides()->get_Item(0);

    // Rectangle प्रकार की एक ऑटो शेप जोड़ें।
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 255, 130);

    // भराव प्रकार को Picture सेट करें।
    $shape->getFillFormat()->setFillType(FillType::Picture);

    // चित्र भराव मोड सेट करें।
    $shape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Tile);

    // एक छवि लोड करें और उसे प्रस्तुति संसाधनों में जोड़ें।
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

![चित्र फ़िल के साथ आकृति](picture-fill.png)

### **टाइल चित्र को टेक्सचर के रूप में**

यदि आप एक टाइल की गई चित्र को टेक्सचर के रूप में सेट करना चाहते हैं और टाइलिंग व्यवहार को अनुकूलित करना चाहते हैं, तो आप [PictureFillFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/picturefillformat/) वर्ग की निम्नलिखित मेथड्स का उपयोग कर सकते हैं:

- [setPictureFillMode](https://reference.aspose.com/slides/hi/php-java/aspose.slides/picturefillformat/#setPictureFillMode): चित्र फ़िल मोड सेट करता है—`Tile` या `Stretch`।
- [setTileAlignment](https://reference.aspose.com/slides/hi/php-java/aspose.slides/picturefillformat/#setTileAlignment): आकृति के भीतर टाइल्स की संरेखण निर्दिष्ट करता है।
- [setTileFlip](https://reference.aspose.com/slides/hi/php-java/aspose.slides/picturefillformat/#setTileFlip): निर्धारित करता है कि टाइल को क्षैतिज, लंबवत या दोनों दिशा में उलटा किया जाए।
- [setTileOffsetX](https://reference.aspose.com/slides/hi/php-java/aspose.slides/picturefillformat/#setTileOffsetX): आकृति की मूल बिन्दु से टाइल का क्षैतिज ऑफ़सेट (पॉइंट्स में) सेट करता है।
- [setTileOffsetY](https://reference.aspose.com/slides/hi/php-java/aspose.slides/picturefillformat/#setTileOffsetY): आकृति की मूल बिन्दु से टाइल का लंबवत ऑफ़सेट (पॉइंट्स में) सेट करता है।
- [setTileScaleX](https://reference.aspose.com/slides/hi/php-java/aspose.slides/picturefillformat/#setTileScaleX): टाइल का क्षैतिज स्केल प्रतिशत के रूप में परिभाषित करता है।
- [setTileScaleY](https://reference.aspose.com/slides/hi/php-java/aspose.slides/picturefillformat/#setTileScaleY): टाइल का लंबवत स्केल प्रतिशत के रूप में परिभाषित करता है।

```php
// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाले Presentation क्लास को इंस्टैंशिएट करें।
$presentation = new Presentation();
try {
    // पहली स्लाइड प्राप्त करें।
    $firstSlide = $presentation->getSlides()->get_Item(0);

    // एक आयत ऑटो शेप जोड़ें।
    $shape = $firstSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 190, 95);

    // आकृति का भराव प्रकार Picture सेट करें।
    $shape->getFillFormat()->setFillType(FillType::Picture);

    // छवि लोड करें और उसे प्रस्तुति संसाधनों में जोड़ें।
    $sourceImage = Images::fromFile("lotus.png");
    $presentationImage = $presentation->getImages()->addImage($sourceImage);
    $sourceImage->dispose();

    // छवि को आकृति को सौंपें।
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

## **सॉलिड कलर फ़िल**

PowerPoint में, Solid Color Fill एक स्वरूपण विकल्प है जो एक आकृति को एक ही समान रंग से भरता है। यह साधारण पृष्ठभूमि रंग कोई ग्रेडिएंट, टेक्सचर या पैटर्न के बिना लागू किया जाता है।

Aspose.Slides का उपयोग करके एक आकृति पर सॉलिड कलर फ़िल लागू करने के लिए, इन चरणों का पालन करें:

1. [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) वर्ग का एक उदाहरण बनाएँ।
1. इंडेक्स द्वारा एक स्लाइड का संदर्भ प्राप्त करें।
1. स्लाइड में एक [AutoShape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/autoshape/) जोड़ें।
1. आकृति की [FillType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/filltype/) को `Solid` सेट करें।
1. अपनी पसंदीदा भराव रंग आकृति को सौंपें।
1. परिवर्तित प्रेजेंटेशन को PPTX फ़ाइल के रूप में सहेजें।

```php
// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाले Presentation क्लास को इंस्टैंशिएट करें।
$presentation = new Presentation();
try {
    // पहली स्लाइड प्राप्त करें।
    $slide = $presentation->getSlides()->get_Item(0);

    // Rectangle प्रकार की एक ऑटो शेप जोड़ें।
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // भराव प्रकार को Solid सेट करें।
    $shape->getFillFormat()->setFillType(FillType::Solid);

    // भराव रंग सेट करें।
    $shape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);

    // PPTX फ़ाइल को डिस्क पर सहेजें।
    $presentation->save("solid_color_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

परिणाम:

![सॉलिड कलर फ़िल के साथ आकृति](solid-color-fill.png)

## **पारदर्शिता सेट करें**

PowerPoint में, जब आप एक आकृति पर सॉलिड कलर, ग्रेडिएंट, चित्र या टेक्सचर फ़िल लागू करते हैं, तो आप फ़िल की अपारदर्शिता को नियंत्रित करने के लिए पारदर्शिता स्तर भी सेट कर सकते हैं। अधिक पारदर्शिता मान आकृति को अधिक पारदर्शी बनाते हैं, जिससे पृष्ठभूमि या नीचे की वस्तुएँ आंशिक रूप से दिखाई देती हैं।

Aspose.Slides आपको फ़िल में उपयोग किए गए रंग के अल्फा मान को समायोजित करके पारदर्शिता स्तर सेट करने की अनुमति देता है। इसे करने का तरीका इस प्रकार है:

1. [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) वर्ग का एक उदाहरण बनाएँ।
1. इंडेक्स द्वारा एक स्लाइड का संदर्भ प्राप्त करें।
1. स्लाइड में एक [AutoShape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/autoshape/) जोड़ें।
1. [FillType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/filltype/) को `Solid` सेट करें।
1. `Color` का उपयोग करके पारदर्शिता सहित एक रंग परिभाषित करें (अल्फा घटक पारदर्शिता नियंत्रित करता है)।
1. प्रस्तुति को सहेजें।

```php
// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाले Presentation क्लास को इंस्टैंशिएट करें।
$presentation = new Presentation();
try {
    // पहली स्लाइड प्राप्त करें।
    $slide = $presentation->getSlides()->get_Item(0);

    // एक ठोस आयत ऑटो शेप जोड़ें।
    $solidShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // ठोस आकृति के ऊपर एक पारदर्शी आयत ऑटो शेप जोड़ें।
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

![पारदर्शी आकृति](shape-transparency.png)

## **आकृतियों को घुमाएँ**

Aspose.Slides आपको PowerPoint प्रस्तुतियों में आकृतियों को घुमााने की सुविधा देता है। यह विशिष्ट संरेखण या डिजाइन आवश्यकताओं के साथ विज़ुअल तत्वों को स्थित करने में उपयोगी हो सकता है।

स्लाइड पर एक आकृति को घुमाने के लिए, इन चरणों का पालन करें:

1. [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) वर्ग का एक उदाहरण बनाएँ।
1. इंडेक्स द्वारा एक स्लाइड का संदर्भ प्राप्त करें।
1. स्लाइड में एक [AutoShape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/autoshape/) जोड़ें।
1. आकृति की घुमाव प्रॉपर्टी को वांछित कोण पर सेट करें।
1. प्रस्तुति को सहेजें।

```php
// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाले Presentation क्लास को इंस्टैंशिएट करें।
$presentation = new Presentation();
try {
    // पहली स्लाइड प्राप्त करें।
    $slide = $presentation->getSlides()->get_Item(0);

    // Rectangle प्रकार की एक ऑटो शेप जोड़ें।
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // आकृति को 5 डिग्री घुमाएँ।
    $shape->setRotation(5);

    // PPTX फ़ाइल को डिस्क पर सहेजें।
    $presentation->save("shape_rotation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

परिणाम:

![आकृति का घुमाव](shape-rotation.png)

## **3D बिवेल प्रभाव जोड़ें**

Aspose.Slides आपको उनके [ThreeDFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/threedformat/) गुणों को कॉन्फ़िगर करके आकृतियों पर 3D बिवेल प्रभाव लागू करने की सुविधा देता है।

स्लाइड पर आकृतियों को 3D बिवेल प्रभाव लागू करने के लिए, इन चरणों का पालन करें:

1. [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) वर्ग का एक उदाहरण बनाएँ।
1. इंडेक्स द्वारा एक स्लाइड का संदर्भ प्राप्त करें।
1. स्लाइड में एक [AutoShape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/autoshape/) जोड़ें।
1. आकृति के [ThreeDFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/threedformat/) को कॉन्फ़िगर करके बिवेल सेटिंग्स परिभाषित करें।
1. प्रस्तुति को सहेजें।

```php
// Presentation क्लास का एक उदाहरण बनाएँ।
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // स्लाइड में एक आकृति जोड़ें।
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 50, 100, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->ORANGE);
    $shape->getLineFormat()->setWidth(2.0);

    // आकृति की ThreeDFormat प्रॉपर्टीज़ सेट करें।
    $shape->getThreeDFormat()->setDepth(4);
    $shape->getThreeDFormat()->getBevelTop()->setBevelType(BevelPresetType::Circle);
    $shape->getThreeDFormat()->getBevelTop()->setHeight(6);
    $shape->getThreeDFormat()->getBevelTop()->setWidth(6);
    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::ThreePt);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);

    // प्रेजेंटेशन को PPTX फ़ाइल के रूप में सहेजें।
    $presentation->save("3D_bevel_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

परिणाम:

![3D बिवेल प्रभाव](3D-bevel-effect.png)

## **3D घूर्णन प्रभाव जोड़ें**

Aspose.Slides आपको उनके [ThreeDFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/threedformat/) गुणों को कॉन्फ़िगर करके आकृतियों पर 3D घूर्णन प्रभाव लागू करने की अनुमति देता है।

एक आकृति पर 3D घूर्णन लागू करने के लिए:

1. [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) वर्ग का एक उदाहरण बनाएँ।
1. इंडेक्स द्वारा एक स्लाइड का संदर्भ प्राप्त करें।
1. स्लाइड में एक [AutoShape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/autoshape/) जोड़ें।
1. [setCameraType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/camera/#setCameraType) और [setLightType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/lightrig/#setLightType) का उपयोग करके 3D घूर्णन परिभाषित करें।
1. प्रस्तुति को सहेजें।

```php
// Presentation क्लास का एक उदाहरण बनाएँ।
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
    $autoShape->getTextFrame()->setText("Hello, Aspose!");

    $autoShape->getThreeDFormat()->setDepth(6);
    $autoShape->getThreeDFormat()->getCamera()->setRotation(40, 35, 20);
    $autoShape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::IsometricLeftUp);
    $autoShape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);

    // प्रेजेंटेशन को PPTX फ़ाइल के रूप में सहेजें।
    $presentation->save("3D_rotation_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

परिणाम:

![3D घूर्णन प्रभाव](3D-rotation-effect.png)

## **फ़ॉर्मेट रीसेट करें**

निम्नलिखित Java कोड दिखाता है कि कैसे एक स्लाइड का फ़ॉर्मेट रीसेट किया जाए और [LayoutSlide](https://reference.aspose.com/slides/hi/php-java/aspose.slides/layoutslide/) पर प्लेसहोल्डर वाली सभी आकृतियों की स्थिति, आकार और फ़ॉर्मेट को उनकी डिफ़ॉल्ट सेटिंग्स पर पुनर्स्थापित किया जाए:

```php
$presentation = new Presentation("sample.pptx");
try {
    for ($i = 0; $i < java_values($presentation->getSlides()->size()); $i++) {
        $slide = $presentation->getSlides()->get_Item($i);
        // लेआउट पर प्लेसहोल्डर वाले स्लाइड की प्रत्येक आकृति को रीसेट करें।
        $slide->reset();
    }
    $presentation->save("reset_formatting.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या आकृति का स्वरूपण अंतिम प्रस्तुति फ़ाइल आकार को प्रभावित करता है?**

केवल न्यूनतम रूप से। एम्बेडेड छवियों और मीडिया फ़ाइलों में अधिकांश फ़ाइल आकार होता है, जबकि आकृति के पैरामीटर जैसे रंग, प्रभाव और ग्रेडिएंट मेटाडेटा के रूप में संग्रहीत होते हैं और लगभग कोई अतिरिक्त आकार नहीं जोड़ते।

**मैं कैसे पता लगा सकता हूँ कि कौन सी आकृतियों के फ़ॉर्मेट समान हैं ताकि मैं उन्हें समूहित कर सकूँ?**

प्रत्येक आकृति के प्रमुख स्वरूपण गुणों—फ़िल, रेखा और प्रभाव सेटिंग्स—की तुलना करें। यदि सभी संबंधित मान समान हैं, तो उनके शैलियों को समान मानें और उन आकृतियों को तार्किक रूप से समूहित करें, जिससे बाद में शैली प्रबंधन आसान हो जाता है।

**क्या मैं कस्टम आकृति शैलियों का एक सेट अलग फ़ाइल में सहेज कर अन्य प्रस्तुतियों में पुनः उपयोग कर सकता हूँ?**

हाँ। वांछित शैलियों वाली नमूना आकृतियों को एक टेम्पलेट स्लाइड डेक या .POTX टेम्पलेट फ़ाइल में सहेजें। नई प्रस्तुति बनाते समय टेम्पलेट खोलें, आवश्यक शैली वाली आकृतियों को क्लोन करें, और जहाँ भी आवश्यक हो, उनके स्वरूपण को पुनः लागू करें।