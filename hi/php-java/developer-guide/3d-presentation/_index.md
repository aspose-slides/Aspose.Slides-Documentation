---
title: PHP का उपयोग करके प्रस्तुतियों में 3D प्रभाव बनाएं
linktitle: 3D प्रस्तुति
type: docs
weight: 232
url: /hi/php-java/3d-presentation/
keywords:
- 3D पावरपॉइंट
- 3D प्रस्तुति
- 3D घूर्णन
- 3D गहराई
- 3D एक्सट्रूज़न
- 3D ग्रेडिएंट
- 3D टेक्स्ट
- PowerPoint
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Aspose.Slides के साथ PHP में PowerPoint आकार और टेक्स्ट के लिए 3D प्रभाव लागू करें और रेंडर करें। कैमरा, लाइटिंग, मैटेरियल, एक्सट्रूज़न, फ़िल्स और 3D टेक्स्ट को कॉन्फ़िगर करें।"
---
## **अवलोकन**

Aspose.Slides for PHP via Java आकारों और टेक्स्ट के लिए PowerPoint‑स्टाइल 3D फ़ॉर्मेटिंग बना, संपादित, संरक्षित और रेंडर कर सकता है। यह लेख घूर्णन, एक्सट्रूज़न, बिवेल, लाइटिंग, मैटेरियल, ग्रेडिएंट या पिक्चर फ़िल्स, और 3D टेक्स्ट जैसे 3D प्रभावों को कवर करता है।

{{% alert color="primary" %}}

यह लेख PowerPoint आकारों और टेक्स्ट पर 3D फ़ॉर्मेटिंग प्रभावों के बारे में है। यह स्वतंत्र 3D मॉडल फ़ाइलों को सम्मिलित या संपादित करने के बारे में नहीं है। जब आप स्लाइड को इमेज, PDF या HTML में एक्सपोर्ट करते हैं, तो Aspose.Slides इन 3D प्रभावों को एक्सपोर्टेड 2D आउटपुट में रेंडर करता है।

{{% /alert %}}

## **3D फ़ॉर्मेटिंग अवधारणाएँ**

[Shape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shape/) क्लास और उसकी [Shape::getThreeDFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shape/#getThreeDFormat--) मेथड का उपयोग करके किसी आकार पर 3D फ़ॉर्मेटिंग लागू करें। यह मेथड [ThreeDFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/threedformat/) लौटाता है, जो उस आकार के लिए 3D सीन को नियंत्रित करता है।

टेक्स्ट के लिए, [TextFrameFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframeformat/) क्लास और उसकी [TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframeformat/#getThreeDFormat--) मेथड का प्रयोग करें। यह आकार बॉडी के बजाय टेक्स्ट फ़्रेम पर 3D फ़ॉर्मेटिंग लागू करता है।

सबसे महत्वपूर्ण सेटिंग्स हैं:

| मेथड या सेटिंग | यह क्या नियंत्रित करता है | कब उपयोग करें |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/hi/php-java/aspose.slides/threedformat/#getCamera--) | व्यूपॉइंट, प्रीसेट कैमरा प्रकार, घूर्णन, ज़ूम और परिप्रेक्ष्य। | 3D स्पेस में वस्तु को घुमाएँ या PowerPoint के 3D घूर्णन प्रीसेट से मिलाएँ। |
| [getLightRig](https://reference.aspose.com/slides/hi/php-java/aspose.slides/threedformat/#getLightRig--) | लाइट प्रीसेट, दिशा, और लाइट घूर्णन। | 3D सतह पर हाइलाइट्स और शैडोज़ के दिखने के तरीके को बदलें। |
| [setMaterial](https://reference.aspose.com/slides/hi/php-java/aspose.slides/threedformat/#setMaterial-byte-) | सतह सामग्री, जैसे फ्लैट, मैट, प्लास्टिक, या मेटल। | समान ज्योमेट्री को अधिक सपाट, नरम, चमकदार या धातू जैसा बनाएँ। |
| [setExtrusionHeight](https://reference.aspose.com/slides/hi/php-java/aspose.slides/threedformat/#setExtrusionHeight-double-) | आकार अपने फ्रंट फेस से कितनी दूरी तक पीछे तक एक्सट्रूड होता है। | एक सपाट आकार को स्पष्ट रूप से मोटे 3D ऑब्जेक्ट में बदलें। |
| [getExtrusionColor](https://reference.aspose.com/slides/hi/php-java/aspose.slides/threedformat/#getExtrusionColor--) | एक्सट्रूडेड साइड्स का रंग। | गहराई दिखाएँ या साइड रंग को फ्रंट फ़िल के साथ समन्वयित करें। |
| [setDepth](https://reference.aspose.com/slides/hi/php-java/aspose.slides/threedformat/#setDepth-double-) | PowerPoint 3D फ़ॉर्मेटिंग द्वारा उपयोग की जाने वाली अतिरिक्त 3D गहराई। | आकार या टेक्स्ट के लिए गहराई को फाइन‑ट्यून करें, विशेषकर बिवेल और मैटेरियल सेटिंग्स के साथ। |
| [getBevelTop](https://reference.aspose.com/slides/hi/php-java/aspose.slides/threedformat/#getBevelTop--) और [getBevelBottom](https://reference.aspose.com/slides/hi/php-java/aspose.slides/threedformat/#getBevelBottom--) | फ्रंट और बैक फेस के ऊपर या नीचे उठे हुए या गोल किनारे। | तेज़ सपाट सतह की जगह नरम या आकारित किनारा जोड़ें। |
| [getContourColor](https://reference.aspose.com/slides/hi/php-java/aspose.slides/threedformat/#getContourColor--) और [setContourWidth](https://reference.aspose.com/slides/hi/php-java/aspose.slides/threedformat/#setContourWidth-double-) | 3D ऑब्जेक्ट के चारों ओर का आउटलाइन। | रेंडर किए गए आउटपुट में ऑब्जेक्ट की सीमा को स्पष्ट करें। |

## **3D आकार बनाना**

एक आकार को विश्वसनीय 3D दिखाने के लिए आमतौर पर चार प्रकार की सेटिंग्स की आवश्यकता होती है:

- कैमरा सेटिंग्स, क्योंकि डिफ़ॉल्ट फ्रंट व्यू एक्सट्रूज़न को छिपा सकता है।
- लाइट सेटिंग्स, क्योंकि लाइटिंग फेस और साइड्स को पढ़ने योग्य बनाती है।
- मैटेरियल सेटिंग्स, क्योंकि सतह यह निर्धारित करती है कि लाइट कैसे रेंडर होती है।
- एक्सट्रूज़न या डेप्थ सेटिंग्स, क्योंकि एक सपाट आकार को मोटाई चाहिए।

निम्न उदाहरण एक आयत बनाता है, उसके फ्रंट फेस पर टेक्स्ट जोड़ता है, 3D फ़ॉर्मेटिंग लागू करता है, प्रेजेंटेशन को PPTX के रूप में सहेजता है, और स्लाइड को PNG इमेज में रेंडर करता है।

```php
$imageScale = 2;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 200, 200);
    $shape->getTextFrame()->setText("3D");
    $shape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(64);

    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setColor(new Java("java.awt.Color", 100, 149, 237));

    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getCamera()->setRotation(20, 30, 40);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Flat);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $shape->getThreeDFormat()->setMaterial(MaterialPresetType::Flat);
    $shape->getThreeDFormat()->setExtrusionHeight(100);
    $shape->getThreeDFormat()->getExtrusionColor()->setColor(java("java.awt.Color")->BLUE);

    $thumbnail = $slide->getImage($imageScale, $imageScale);
    try {
        $thumbnail->save("shape_3d.png", ImageFormat::Png);
    } finally {
        $thumbnail->dispose();
    }

    $presentation->save("shape_3d.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

रेंडर की गई स्लाइड इमेज आयत को मोटे 3D ब्लॉक के रूप में दिखाती है:

![Rendered blue 3D rectangle with white 3D text on the front face](img_01_01.png)

## **कैमरा से आकार को घुमाएँ**

PowerPoint में, 3‑D Rotation पैन से 3D घूर्णन कॉन्फ़िगर किया जाता है। X, Y, और Z घूर्णन मान कैमरा API के माध्यम से सेट किए गए घूर्णन के अनुरूप होते हैं।

![PowerPoint 3-D Rotation pane with X, Y, and Z rotation values highlighted](img_02_01.png)

Aspose.Slides में, कैमरा प्रकार और घूर्णन को [ThreeDFormat::getCamera](https://reference.aspose.com/slides/hi/php-java/aspose.slides/threedformat/#getCamera--) के माध्यम से सेट करें:

```php
$shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
$shape->getThreeDFormat()->getCamera()->setRotation(20, 30, 40);
```

विचारकर्ता को वस्तु कैसे दिखती है, इसे बदलने की आवश्यकता होने पर कैमरा का प्रयोग करें। यह स्लाइड पर 2D आकार ज्योमेट्री को नहीं बदलता। यह PowerPoint और Aspose.Slides द्वारा रेंडरिंग के समय उपयोग किए जाने वाले 3D व्यूपॉइंट को बदलता है।

## **एक्सट्रूज़न और डेप्थ जोड़ें**

एक्सट्रूज़न आकार को मोटा बनाता है, जिससे वह फ्रंट फेस के पीछे बढ़ जाता है। PowerPoint में, डेप्थ नियंत्रण इस दिखाई देने वाली मोटाई को सेट करता है, और रंग नियंत्रण साइड फेस के रंग को निर्धारित करता है।

![PowerPoint depth controls mapped to extrusion color and extrusion height properties](img_02_02.png)

मोटाई के लिए [ThreeDFormat::setExtrusionHeight](https://reference.aspose.com/slides/hi/php-java/aspose.slides/threedformat/#setExtrusionHeight-double-) और साइड रंग के लिए [ThreeDFormat::getExtrusionColor](https://reference.aspose.com/slides/hi/php-java/aspose.slides/threedformat/#getExtrusionColor--) सेट करें:

```php
$shape->getThreeDFormat()->getCamera()->setRotation(20, 30, 40);
$shape->getThreeDFormat()->setExtrusionHeight(100);
$shape->getThreeDFormat()->getExtrusionColor()->setColor(new Java("java.awt.Color", 128, 0, 128));
```

जब आपको सीधे PowerPoint की डेप्थ वैल्यू के साथ काम करना हो या डेप्थ को बिवेल, मैटेरियल और टेक्स्ट प्रभावों के साथ संयोजित करना हो, तो [ThreeDFormat::setDepth](https://reference.aspose.com/slides/hi/php-java/aspose.slides/threedformat/#setDepth-double-) का उपयोग करें। कई आकार परिदृश्यों में, `setExtrusionHeight` स्पष्ट सेटिंग है क्योंकि यह सीधे दिखाई देने वाली एक्सट्रूज़न को व्यक्त करता है।

## **3D प्रभावों के साथ ग्रेडिएंट या पिक्चर फ़िल्स उपयोग करें**

3D फ़ॉर्मेटिंग shape fill से स्वतंत्र है। आप फ्रंट फेस पर सॉलिड कलर, ग्रेडिएंट, पैटर्न या पिक्चर फ़िल लागू कर सकते हैं और फिर भी वही कैमरा, लाइट, मैटेरियल और एक्सट्रूज़न सेटिंग्स रख सकते हैं।

नीचे का उदाहरण shape पर ग्रेडिएंट फ़िल और साइड्स पर गहरा एक्सट्रूज़न रंग लागू करता है:

```php
$imageScale = 2;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 250, 250);
    $shape->getTextFrame()->setText("3D Gradient");
    $shape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(64);

    $shape->getFillFormat()->setFillType(FillType::Gradient);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->add(0, java("java.awt.Color")->BLUE);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->add(100, java("java.awt.Color")->ORANGE);

    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getCamera()->setRotation(10, 20, 30);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Flat);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $shape->getThreeDFormat()->setMaterial(MaterialPresetType::Flat);
    $shape->getThreeDFormat()->setExtrusionHeight(150);
    $shape->getThreeDFormat()->getExtrusionColor()->setColor(new Java("java.awt.Color", 255, 140, 0));

    $thumbnail = $slide->getImage($imageScale, $imageScale);
    try {
        $thumbnail->save("gradient_3d.png", ImageFormat::Png);
    } finally {
        $thumbnail->dispose();
    }
} finally {
    $presentation->dispose();
}
```

रेंडर किया गया आउटपुट फ्रंट फेस पर ग्रेडिएंट रखता है और एक्सट्रूज़न को अलग से रेंडर करता है:

![Rendered 3D rectangle with a blue-to-orange gradient fill and orange extrusion](img_02_03.png)

पिक्चर फ़िल उपयोग करने के लिए, इमेज को प्रेजेंटेशन में जोड़ें और उसे shape फ़िल में असाइन करें:

```php
$image = Images::fromFile("image.jpg");
try {
    $picture = $presentation->getImages()->addImage($image);
} finally {
    $image->dispose();
}

$shape->getFillFormat()->setFillType(FillType::Picture);
$shape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);
$shape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Stretch);

$shape->getThreeDFormat()->getCamera()->setRotation(10, 20, 30);
$shape->getThreeDFormat()->setExtrusionHeight(150);
$shape->getThreeDFormat()->getExtrusionColor()->setColor(new Java("java.awt.Color", 255, 140, 0));
```

चित्र फ्रंट फेस पर रेंडर होता है, जबकि एक्सट्रूज़न 3D साइड सतह के रूप में रेंडर होता है:

![Rendered 3D rectangle with a photo fill on the front face and orange extrusion](img_02_04.png)

## **टेक्स्ट पर 3D फ़ॉर्मेटिंग लागू करें**

Shape की 3D फ़ॉर्मेटिंग आकार बॉडी को प्रभावित करती है। टेक्स्ट की 3D फ़ॉर्मेटिंग टेक्स्ट फ़्रेम को प्रभावित करती है। यह WordArt‑जैसे प्रभावों के लिए उपयोगी है जहाँ अक्षरों को स्वयं एक्सट्रूज़न, मैटेरियल, लाइटिंग और कैमरा सेटिंग्स की आवश्यकता होती है।

निम्न उदाहरण पैटर्न फ़िल के साथ टेक्स्ट बनाता है, WordArt ट्रांसफ़ॉर्म लागू करता है, और [TextFrameFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframeformat/) पर 3D सेटिंग्स कॉन्फ़िगर करता है:

```php
$imageScale = 2;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 250, 250);
    $shape->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getTextFrame()->setText("3D Text");

    $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Pattern);
    $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->getForeColor()->setColor(new Java("java.awt.Color", 255, 140, 0));
    $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->getBackColor()->setColor(java("java.awt.Color")->WHITE);
    $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->setPatternStyle(PatternStyle::LargeGrid);

    $shape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(128);

    $textFrameFormat = $shape->getTextFrame()->getTextFrameFormat();
    $textFrameFormat->setTransform(TextShapeType::ArchUp);
    $textFrameFormat->getThreeDFormat()->setExtrusionHeight(3.5);
    $textFrameFormat->getThreeDFormat()->setDepth(3);
    $textFrameFormat->getThreeDFormat()->setMaterial(MaterialPresetType::Plastic);
    $textFrameFormat->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $textFrameFormat->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);
    $textFrameFormat->getThreeDFormat()->getLightRig()->setRotation(0, 0, 40);
    $textFrameFormat->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::PerspectiveContrastingRightFacing);

    $thumbnail = $slide->getImage($imageScale, $imageScale);
    try {
        $thumbnail->save("text_3d.png", ImageFormat::Png);
    } finally {
        $thumbnail->dispose();
    }

    $presentation->save("text_3d.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

टेक्स्ट कर्व्ड, एक्सट्रूज़न वाले 3D लेटरिंग के रूप में रेंडर होता है:

![Rendered 3D text with an arched WordArt transform, orange pattern fill, and dark extrusion](img_02_05.png)

## **एक्सपोर्ट और रेंडरिंग व्यवहार**

Aspose.Slides PPTX जैसे PowerPoint फ़ॉर्मेट में सहेजते समय 3D फ़ॉर्मेटिंग को संरक्षित रखता है। जब रेंडरिंग या फ़िक्स्ड‑लेआउट फ़ॉर्मेट्स में एक्सपोर्ट किया जाता है, तो 3D सीन को रास्टराइज़ किया जाता है या 2D परिणाम के रूप में आउटपुट में ड्रॉ किया जाता है। यह तब लागू होता है जब आप स्लाइड्स को [PNG](/slides/hi/php-java/convert-powerpoint-to-png/) पर रेंडर करते हैं, [PDF](/slides/hi/php-java/convert-powerpoint-to-pdf/) में एक्सपोर्ट करते हैं, [HTML](/slides/hi/php-java/convert-powerpoint-to-html/) में एक्सपोर्ट करते हैं, या [video conversion](/slides/hi/php-java/convert-powerpoint-to-video/) के लिए फ्रेम उत्पन्न करते हैं।

ध्यान रखने योग्य बिंदु:

- एक्सपोर्टेड इमेज और PDF इंटरैक्टिव नहीं होते। एक्सपोर्ट के बाद दर्शक ऑब्जेक्ट को घुमा नहीं सकता।
- अंतिम रूप कैमरा, लाइट रिग, मैटेरियल, एक्सट्रूज़न, फ़िल और स्लाइड स्केलिंग के संयोजन पर निर्भर करता है।
- यदि आपको इनहेरिटेड या थीम‑आधारित फ़ॉर्मेट मानों को निरीक्षण करना है, तो [effective shape properties](/slides/hi/php-java/shape-effective-properties/) पढ़ें।
- कुछ आउटपुट फ़ॉर्मेट संपादन योग्य PowerPoint 3D फ़ॉर्मेटिंग को संग्रहीत नहीं कर सकते। उन फ़ॉर्मेट्स में दृश्य परिणाम रेंडर किया जाता है न कि संपादन योग्य 3D सेटिंग्स के रूप में संरक्षित।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या Aspose.Slides इंटरैक्टिव 3D प्रेजेंटेशन बना सकता है?**

Aspose.Slides आकारों और टेक्स्ट के लिए PowerPoint 3D प्रभाव बनाता और रेंडर करता है। यह एक्सपोर्टेड इमेज, PDF या HTML पेज को इंटरैक्टिव 3D सीन नहीं बनाता जिसे दर्शक घुमा सके। PPTX में, 3D फ़ॉर्मेटिंग PowerPoint में संपादन योग्य रहती है जहाँ फ़ॉर्मेट समर्थन करता है।

**3D मॉडल और 3D प्रभाव में क्या अंतर है?**

3D मॉडल एक अलग 3D ऑब्जेक्ट है जिसे प्रेजेंटेशन में सम्मिलित किया जाता है। 3D प्रभाव सामान्य PowerPoint आकार या टेक्स्ट पर लागू फ़ॉर्मेटिंग है, जैसे घूर्णन, एक्सट्रूज़न, बिवेल, लाइटिंग और मैटेरियल। यह लेख 3D प्रभावों को कवर करता है।

**दृश्यमान 3D आकार के लिए कौन सी सेटिंग्स आवश्यक हैं?**

न्यूनतम रूप से कैमरा घूर्णन और एक्सट्रूज़न या डेप्थ सेट करें। व्यावहारिक रूप से लाइट रिग और मैटेरियल भी सेट करें ताकि रेंडर किए गए फेस में स्पष्ट हाइलाइट्स और शैडोज़ हों।

**क्या मैं 3D प्रभाव दोनों आकार और टेक्स्ट पर लागू कर सकता हूँ?**

हाँ। आकार बॉडी के लिए [Shape::getThreeDFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shape/#getThreeDFormat--) और टेक्स्ट के लिए [TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframeformat/#getThreeDFormat--) का प्रयोग करें।

**क्या 3D प्रभाव इमेज, PDF, HTML या वीडियो फ्रेम में एक्सपोर्ट करने पर दिखेंगे?**

हाँ। Aspose.Slides स्लाइड इमेज, PDF आउटपुट, HTML आउटपुट, और वीडियो रूपांतरण के लिए उपयोग किए जाने वाले फ्रेम बनाते समय 3D प्रभाव रेंडर करता है। एक्सपोर्टेड आउटपुट रेंडर किया हुआ दृश्य रखता है, न कि संपादन योग्य 3D ऑब्जेक्ट।

**क्या मैं इनहेरिटेंस और थीम सेटिंग्स लागू होने के बाद अंतिम 3D मान पढ़ सकता हूँ?**

हाँ। [Shape Effective Properties](/slides/hi/php-java/shape-effective-properties/) में वर्णित प्रभावी फ़ॉर्मेटिंग API का उपयोग करके अंतिम कैमरा, लाइट रिग, बिवेल और संबंधित 3D मान पढ़ें।