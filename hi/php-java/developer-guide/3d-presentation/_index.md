---
title: PHP का उपयोग करके प्रस्तुतियों में 3D प्रभाव बनाएं
linktitle: 3D प्रस्तुति
type: docs
weight: 232
url: /hi/php-java/3d-presentation/
keywords:
- 3D PowerPoint
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
description: "Aspose.Slides के साथ PHP में PowerPoint आकार और टेक्स्ट के लिए 3D प्रभाव लागू करें और रेंडर करें। कैमरा, लाइटिंग, सामग्री, एक्सट्रूज़न, फिल्स और 3D टेक्स्ट को कॉन्फ़िगर करें।"
---
## **अवलोकन**

Aspose.Slides for PHP via Java आकारों और टेक्स्ट के लिए PowerPoint-शैली 3D फॉर्मेटिंग बना, संपादित, संरक्षित और रेंडर कर सकता है। यह लेख घूर्णन, एक्सट्रूज़न, बिवेल, लाइटिंग, मटीरियल, ग्रेडिएंट या पिक्चर फिल्स, और 3D टेक्स्ट जैसे 3D इफ़ेक्ट्स को कवर करता है।

{{% alert color="info" title="Note" %}}
यह लेख PowerPoint आकारों और टेक्स्ट पर 3D फॉर्मेटिंग इफ़ेक्ट्स के बारे में है। यह स्वयंस्थ 3D मॉडल फ़ाइलों को सम्मिलित या संपादित करने के बारे में नहीं है। जब आप स्लाइड को छवि, PDF, या HTML में निर्यात करते हैं, तो Aspose.Slides उन 3D इफ़ेक्ट्स को निर्यातित 2D आउटपुट में रेंडर करता है।
{{% /alert %}}

## **3D फॉर्मेटिंग अवधारणाएँ**

एक आकार पर 3D फॉर्मेटिंग लागू करने के लिए [Shape::getThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getThreeDFormat) मेथड का उपयोग करें। यह मेथड [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/) लौटाता है, जो उस आकार के लिए 3D सीन को नियंत्रित करता है।

टेक्स्ट के लिए, [TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#getThreeDFormat) मेथड का उपयोग करें। यह आकार के बॉडी की बजाय टेक्स्ट फ्रेम पर 3D फॉर्मेटिंग लागू करता है।

सबसे महत्वपूर्ण API सदस्य हैं:

| API सदस्य | नियंत्रित क्या करता है | कब उपयोग करें |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getCamera) | दृश्य बिंदु, पूर्व निर्धारित कैमरा प्रकार, घूर्णन, ज़ूम, और परिप्रेक्ष्य। | 3D स्थान में वस्तु को घुमाएँ या PowerPoint 3D घूर्णन प्रीसेट से मिलाएँ। |
| [getLightRig](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getLightRig) | लाइट प्रीसेट, दिशा, और लाइट घूर्णन। | 3D सतह पर हाइलाइट्स और शैडोज़ की उपस्थिति बदलें। |
| [getMaterial](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getMaterial) and [setMaterial](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#setMaterial) | सतह सामग्री, जैसे फ्लैट, मैट, प्लास्टिक, या धातु। | इसी ज्यामिति को सपाट, नरम, चमकदार, या धातु जैसा दिखाएँ। |
| [getExtrusionHeight](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getExtrusionHeight) and [setExtrusionHeight](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#setExtrusionHeight) | आकार अपने सामने के चेहरे से पीछे कितनी दूर तक विस्तारित होता है। | एक सपाट आकार को स्पष्ट रूप से मोटे 3D वस्तु में बदलें। |
| [getExtrusionColor](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getExtrusionColor) | एक्सट्रूज़न वाली पक्षों का रंग। | गहराई को दृश्यमान बनाएं या साइड के रंग को सामने के फिल के साथ समन्वयित करें। |
| [getDepth](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getDepth) and [setDepth](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#setDepth) | PowerPoint 3D फॉर्मेटिंग द्वारा उपयोग किया गया अतिरिक्त 3D गहराई। | आकार या टेक्स्ट के लिए गहराई को बारीकी से समायोजित करें, विशेष रूप से बिवेल और सामग्री सेटिंग्स के साथ। |
| [getBevelTop](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getBevelTop) and [getBevelBottom](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getBevelBottom) | सामने और पीछे के चेहरों पर उठे या गोल किनारे। | तीखे सपाट चेहरे के बजाय एक मुलायम या ढाला हुआ किनारा जोड़ें। |
| [getContourColor](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getContourColor) and [getContourWidth](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getContourWidth) and [setContourWidth](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#setContourWidth) | 3D वस्तु के चारों ओर का रूपरेखा। | रेंडर किए गए आउटपुट में वस्तु की सीमा को उजागर करें। |

## **3D आकार बनाएं**

एक आकार को विश्वसनीय रूप से 3D दिखने से पहले सामान्यतः चार प्रकार की सेटिंग्स की आवश्यकता होती है:

- कैमरा सेटिंग्स, क्योंकि डिफ़ॉल्ट आगे का दृश्य एक्सट्रूज़न को छिपा सकता है।
- लाइट सेटिंग्स, क्योंकि प्रकाश सतहों और किनारों को पढ़ने योग्य बनाता है।
- सामग्री सेटिंग्स, क्योंकि सतह यह प्रभावित करती है कि प्रकाश कैसे रेंडर होता है।
- एक्सट्रूज़न या गहराई सेटिंग्स, क्योंकि एक सपाट आकार को मोटाई चाहिए।

निम्न उदाहरण एक आयत बनाता है, उसके सामने के चेहरे पर टेक्स्ट जोड़ता है, और 3D फॉर्मेटिंग लागू करता है। कैमरा घूर्णन मान डिग्री में हैं, और एक्सट्रूज़न ऊँचाई 100 पॉइंट्स है। उदाहरण स्लाइड को डिफ़ॉल्ट आकार से दो गुना PNG छवि में रेंडर करता है और प्रस्तुति को PPTX के रूप में सहेजता है।

```php
use aspose\slides\CameraPresetType;
use aspose\slides\FillType;
use aspose\slides\ImageFormat;
use aspose\slides\LightingDirection;
use aspose\slides\LightRigPresetType;
use aspose\slides\MaterialPresetType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

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

रेंडर की गई स्लाइड छवि में आयत को एक मोटी 3D ब्लॉक के रूप में दिखाया गया है:

![फ़्रंट फेस पर सफेद 3D टेक्स्ट वाला नीला 3D आयत रेंडर किया गया](img_01_01.png)

## **कैमरा के साथ आकार को घुमाएँ**

PowerPoint में, 3D घूर्णन को 3-D Rotation पैन से कॉन्फ़िगर किया जाता है। X, Y, और Z घूर्णन मान कैमरा API के माध्यम से सेट किए गए घूर्णन के अनुरूप होते हैं।

![X, Y, और Z घूर्णन मानों को हाइलाइट किया गया PowerPoint 3-D Rotation पैन](img_02_01.png)

Aspose.Slides में, कैमरा तक पहुंचने के लिए [ThreeDFormat::getCamera](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getCamera) का उपयोग करें। यह उदाहरण एक आयत बनाता है, ऑर्थोग्राफिक फ्रंट व्यू चुनता है, और क्रमशः X, Y, और Z घूर्णन को 20, 30, और 40 डिग्री सेट करता है। यह आकार को मेमोरी में कॉन्फ़िगर करता है बिना फ़ाइल सहेजे:

```php
use aspose\slides\CameraPresetType;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 200, 200);

    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getCamera()->setRotation(20, 30, 40);
} finally {
    $presentation->dispose();
}
```

कैमरा का उपयोग तब करें जब आपको दर्शक के वस्तु देखने के तरीके को बदलने की आवश्यकता हो। यह स्लाइड पर 2D आकार की ज्यामिति नहीं बदलता। यह PowerPoint और Aspose.Slides द्वारा रेंडरिंग के समय उपयोग किए जाने वाले 3D दृष्टिकोण को बदलता है।

### **टेम्प्लेट आकार से कैमरा अभिविन्यास कॉपी करें**

टेम्प्लेट आकार की अभिविन्यास मिलाने के लिए, उसके कैमरा प्रीसेट को [Camera::getCameraType](https://reference.aspose.com/slides/php-java/aspose.slides/camera/#getCameraType) से पढ़ें और उसके घूर्णन कोणों को [Camera::getRotation](https://reference.aspose.com/slides/php-java/aspose.slides/camera/#getRotation) से पढ़ें। यह उदाहरण `template.pptx` खोलता है और पहले स्लाइड के पहले आकार से दूसरे आकार में कैमरा अभिविन्यास कॉपी करता है। दोनों आकारों में पहले से ही 3D लाइटिंग है, और दूसरे आकार में कोई स्पष्ट कैमरा घूर्णन नहीं है।

कोण डिग्री में हैं। इंडेक्स `0` अक्षांश है, इंडेक्स `1` देशांतर है, और इंडेक्स `2` घूर्णन है। इन्हें उसी क्रम में [Camera::setRotation](https://reference.aspose.com/slides/php-java/aspose.slides/camera/#setRotation) को पास करें। यदि स्रोत `null` लौटाता है, तो उसका कोई स्पष्ट घूर्णन नहीं है, इसलिए दूसरे आकार के कोण को अनसेट छोड़ दें। `(0, 0, 0)` का स्पष्ट घूर्णन तीन शून्य लौटाता है और इसे कॉपी किया जाना चाहिए।

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("template.pptx");
try {
    $shapes = $presentation->getSlides()->get_Item(0)->getShapes();
    
    $sourceCamera = $shapes->get_Item(0)->getThreeDFormat()->getCamera();
    $destinationCamera = $shapes->get_Item(1)->getThreeDFormat()->getCamera();

    $destinationCamera->setCameraType($sourceCamera->getCameraType());
    $angles = java_values($sourceCamera->getRotation());
    if ($angles !== null) {
        $destinationCamera->setRotation($angles[0], $angles[1], $angles[2]);
    }

    $presentation->save("camera-copy.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

`camera-copy.pptx` को PowerPoint में पुनः खोलने पर, दाएँ तरफ़ वाला तीर बाएँ तरफ़ के आयत के समान कैमरा प्रीसेट और घूर्णन रखता है। दोनों आकार समान लाइटिंग और एक्सट्रूज़न गहराई का उपयोग करते हैं।

![एक नीला 3D आयत और दाएँ ओर का तीर समान कैमरा अभिविन्यास के साथ, ऊपर और दाएँ से देखा गया](camera-orientation.png)

## **एक्सट्रूज़न और गहराई जोड़ें**

एक्सट्रूज़न एक आकार को उसके सामने के चेहरे के पीछे बढ़ाकर मोटा बनाता है। PowerPoint में, गहराई नियंत्रण इस दृश्यमान मोटाई को निर्धारित करता है, और रंग नियंत्रण साइड फेस के रंग को सेट करता है।

![PowerPoint गहराई नियंत्रण एक्सट्रूज़न रंग और एक्सट्रूज़न ऊँचाई गुणों से जुड़े हुए](img_02_02.png)

[ThreeDFormat::setExtrusionHeight](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#setExtrusionHeight) का उपयोग करके मोटाई सेट करें और [ThreeDFormat::getExtrusionColor](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getExtrusionColor) से साइड रंग प्राप्त करें। यह उदाहरण आयत को 100 पॉइंट एक्सट्रूज़न के साथ बैंगनी साइड्स देता है और उसकी मोटाई दिखाने के लिए कैमरा घुमाता है। यह आकार को मेमोरी में कॉन्फ़िगर करता है बिना फ़ाइल सहेजे:

```php
use aspose\slides\CameraPresetType;
use aspose\slides\LightingDirection;
use aspose\slides\LightRigPresetType;
use aspose\slides\MaterialPresetType;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 200, 200);

    $extrusionColor = new Java("java.awt.Color", 128, 0, 128);

    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getCamera()->setRotation(20, 30, 40);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Flat);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $shape->getThreeDFormat()->setMaterial(MaterialPresetType::Flat);
    $shape->getThreeDFormat()->setExtrusionHeight(100);
    $shape->getThreeDFormat()->getExtrusionColor()->setColor($extrusionColor);
} finally {
    $presentation->dispose();
}
```

[ThreeDFormat::setDepth](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#setDepth) मेथड एक 3D आकार की गहराई सेट करता है। [setExtrusionHeight](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#setExtrusionHeight) मेथड एक्सट्रूज़न प्रभाव की ऊँचाई नियंत्रित करता है, जैसा कि इस उदाहरण में दिखाया गया है।

## **3D इफ़ेक्ट्स के साथ ग्रेडिएंट या पिक्चर फिल्स का उपयोग करें**

3D फॉर्मेटिंग आकार की भराव से स्वतंत्र है। आप सामने के चेहरे पर ठोस रंग, ग्रेडिएंट, पैटर्न, या पिक्चर फिल लागू कर सकते हैं और फिर भी वही कैमरा, लाइट, मटीरियल, और एक्सट्रूज़न सेटिंग्स उपयोग कर सकते हैं।

यह उदाहरण सामने के चेहरे पर नीले से नारंगी ग्रेडिएंट लागू करता है और 150 पॉइंट एक्सट्रूज़न के लिए गहरा नारंगी रंग सेट करता है। ग्रेडिएंट स्टॉप 0 और 100 पर क्रमशः ग्रेडिएंट की शुरुआत और अंत को चिह्नित करते हैं। कैमरा घूर्णन मान डिग्री में हैं। स्लाइड को दो गुना डिफ़ॉल्ट आकार में PNG छवि के रूप में रेंडर किया गया है:

```php
use aspose\slides\CameraPresetType;
use aspose\slides\FillType;
use aspose\slides\ImageFormat;
use aspose\slides\LightingDirection;
use aspose\slides\LightRigPresetType;
use aspose\slides\MaterialPresetType;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$imageScale = 2;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 250, 250);

    $shape->getTextFrame()->setText("3D Gradient");
    $shape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(64);

    $shape->getFillFormat()->setFillType(FillType::Gradient);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->add(0, java("java.awt.Color")->BLUE);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->add(100, new Java("java.awt.Color", 255, 165, 0));

    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getCamera()->setRotation(10, 20, 30);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Flat);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $shape->getThreeDFormat()->setMaterial(MaterialPresetType::Flat);
    $extrusionColor = new Java("java.awt.Color", 255, 140, 0);
    $shape->getThreeDFormat()->setExtrusionHeight(150);
    $shape->getThreeDFormat()->getExtrusionColor()->setColor($extrusionColor);

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

![नीले से नारंगी ग्रेडिएंट भराव और नारंगी एक्सट्रूज़न वाला रेंडर किया गया 3D आयत](img_02_03.png)

पिक्चर भराव उपयोग करने के लिए, छवि को प्रस्तुति में जोड़ें और उसे आकार भराव में असाइन करें। इस उदाहरण को कार्य निर्देशिका में "image.jpg" नामक मौजूदा फ़ाइल की आवश्यकता है। यह पिक्चर को आयत में स्ट्रेच करता है, 150 पॉइंट एक्सट्रूज़न लागू करता है, और कैमरा घूर्णन को डिग्री में सेट करता है। यह आकार को मेमोरी में कॉन्फ़िगर करता है बिना फ़ाइल सहेजे या रेंडर किए:

```php
use aspose\slides\CameraPresetType;
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\LightingDirection;
use aspose\slides\LightRigPresetType;
use aspose\slides\MaterialPresetType;
use aspose\slides\PictureFillMode;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 250, 250);

    $sourceImage = Images::fromFile("image.jpg");

    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        $sourceImage->dispose();
    }

    $shape->getFillFormat()->setFillType(FillType::Picture);
    $shape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($image);
    $shape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Stretch);

    $extrusionColor = new Java("java.awt.Color", 255, 140, 0);
    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getCamera()->setRotation(10, 20, 30);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Flat);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $shape->getThreeDFormat()->setMaterial(MaterialPresetType::Flat);
    $shape->getThreeDFormat()->setExtrusionHeight(150);
    $shape->getThreeDFormat()->getExtrusionColor()->setColor($extrusionColor);
} finally {
    $presentation->dispose();
}
```

![सामने के चेहरे पर फोटो भराव और नारंगी एक्सट्रूज़न वाला रेंडर किया गया 3D आयत](img_02_04.png)

## **टेक्स्ट पर 3D फॉर्मेटिंग लागू करें**

आकार की 3D फॉर्मेटिंग आकार के बॉडी को प्रभावित करती है। टेक्स्ट की 3D फॉर्मेटिंग टेक्स्ट फ्रेम को प्रभावित करती है। यह WordArt जैसे इफ़ेक्ट्स के लिए उपयोगी है जहाँ अक्षरों को स्वयं एक्सट्रूज़न, मटीरियल, लाइटिंग, और कैमरा सेटिंग्स की आवश्यकता होती है।

निम्न उदाहरण नारंगी-और-सेफ़ेद ग्रिड पैटर्न के साथ टेक्स्ट बनाता है, एक ऊपर की ओर चाप लागू करता है, और [TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#getThreeDFormat) के माध्यम से 3D सेटिंग्स कॉन्फ़िगर करता है। एक्सट्रूज़न ऊँचाई और गहराई पॉइंट्स में हैं, और लाइट घूर्णन डिग्री में है। आकार भराव और रूपरेखा छिपी हुई है ताकि केवल टेक्स्ट दिखाई दे। उदाहरण दो गुना डिफ़ॉल्ट स्लाइड आकार में PNG छवि रेंडर करता है और प्रस्तुति को PPTX के रूप में सहेजता है:

```php
use aspose\slides\CameraPresetType;
use aspose\slides\FillType;
use aspose\slides\ImageFormat;
use aspose\slides\LightingDirection;
use aspose\slides\LightRigPresetType;
use aspose\slides\MaterialPresetType;
use aspose\slides\PatternStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextShapeType;

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
    $patternColor = new Java("java.awt.Color", 255, 140, 0);
    $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->getForeColor()->setColor($patternColor);
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

![एक चाप वाला WordArt ट्रांसफ़ॉर्म, नारंगी पैटर्न भराव, और गहरा एक्सट्रूज़न वाला रेंडर किया गया 3D टेक्स्ट](img_02_05.png)

## **3D आकार पर टेक्स्ट को सपाट रखें**

एक आकार की 3D उपस्थिति को बनाए रखते हुए टेक्स्ट को पठनीय रखने के लिए, [TextFrame::getTextFrameFormat](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/#getTextFrameFormat) के माध्यम से [TextFrameFormat::setKeepTextFlat](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setKeepTextFlat) को कॉल करें। जब मान `true` हो, तो टेक्स्ट 3D सीन के बाहर रहता है। जब यह `false` हो, तो टेक्स्ट सीन में भाग लेता है और उसकी 3D अभिविन्यास का अनुसरण करता है।

यह सेटिंग आकार की 3D फॉर्मेटिंग को नहीं हटाती: उसका कैमरा, लाइटिंग, मटीरियल, और एक्सट्रूज़न [Shape::getThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getThreeDFormat) के माध्यम से कॉन्फ़िगर रहता है। यह सामान्य घूर्णन से भी अलग है। [Shape::setRotation](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setRotation) स्लाइड प्लेन में आकार को घुमाता है, जबकि [TextFrameFormat::setRotationAngle](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setRotationAngle) टेक्स्ट के बाउंडिंग बॉक्स के भीतर कस्टम घूर्णन को नियंत्रित करता है। टेक्स्ट को 3D सीन से बाहर रखना इन कोणों में से किसी को भी रीसेट नहीं करता।

निम्नलिखित स्वतंत्र उदाहरण एक नीला आयत टेक्स्ट के साथ बनाता है और उसे मूल के बगल में क्लोन करता है। दोनों आकारों में समान 3D फॉर्मेटिंग है; केवल टेक्स्ट सेटिंग अलग है: बाएँ पर `false` और दाएँ पर `true`। कैमरा कोण डिग्री में हैं, और एक्सट्रूज़न ऊँचाई 40 पॉइंट्स है। उदाहरण प्रस्तुति को PPTX के रूप में सहेजता है और तुलना स्लाइड को दो गुना डिफ़ॉल्ट आकार में PNG में रेंडर करता है।

```php
use aspose\slides\CameraPresetType;
use aspose\slides\FillType;
use aspose\slides\ImageFormat;
use aspose\slides\LightingDirection;
use aspose\slides\LightRigPresetType;
use aspose\slides\MaterialPresetType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextAlignment;
use aspose\slides\TextAnchorType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 70, 160, 240, 140);

    $shape->getTextFrame()->setText("Readable text");
    $shape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(28);
    $shape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->setAlignment(TextAlignment::Center);
    $shape->getTextFrame()->getTextFrameFormat()->setAnchoringType(TextAnchorType::Center);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setColor(new Java("java.awt.Color", 100, 149, 237));

    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getCamera()->setRotation(30, 30, 0);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Flat);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $shape->getThreeDFormat()->setMaterial(MaterialPresetType::Flat);
    $shape->getThreeDFormat()->setExtrusionHeight(40);
    $shape->getThreeDFormat()->getExtrusionColor()->setColor(new Java("java.awt.Color", 65, 105, 225));
    $shape->getTextFrame()->getTextFrameFormat()->setKeepTextFlat(false);

    $flatTextShape = $slide->getShapes()->addClone($shape, 400, 160);
    $flatTextShape->getTextFrame()->getTextFrameFormat()->setKeepTextFlat(true);

    $presentation->save("keep_text_flat.pptx", SaveFormat::Pptx);
    $image = $slide->getImage(2, 2);
    try {
        $image->save("keep_text_flat.png", ImageFormat::Png);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

![बाएं पर टेक्स्ट 3D अभिविन्यास का अनुसरण करता हुआ और दाएं पर सपाट रहता हुआ साइड-बाय-साइड 3D आयतें](keep_text_flat.png)

## **निर्यात और रेंडरिंग व्यवहार**

Aspose.Slides PPTX जैसे PowerPoint स्वरूप में सहेजते समय 3D फॉर्मेटिंग को संरक्षित रखता है। जब स्थिर-लेआउट स्वरूपों में रेंडर या निर्यात किया जाता है, तो 3D सीन को रास्टराइज़ किया जाता है या आउटपुट में 2D परिणाम के रूप में खींचा जाता है। यह तब लागू होता है जब आप स्लाइड को [PNG](/slides/hi/php-java/convert-powerpoint-to-png/) में रेंडर करते हैं, [PDF](/slides/hi/php-java/convert-powerpoint-to-pdf/) में निर्यात करते हैं, [HTML](/slides/hi/php-java/convert-powerpoint-to-html/) में निर्यात करते हैं, या [वीडियो रूपांतरण](/slides/hi/php-java/convert-powerpoint-to-video/) के लिए फ़्रेम्स जनरेट करते हैं।

- निर्यातित छवियां और PDF इंटरैक्टिव नहीं होते। निर्यात के बाद दर्शक वस्तु को घुमा नहीं सकता।
- अंतिम दिखावट कैमरा, लाइट रिग, मटीरियल, एक्सट्रूज़न, भराव, और स्लाइड स्केलिंग के संयोजन पर निर्भर करती है।
- यदि आपको विरासत में मिली या थीम-आधारित फॉर्मेटिंग मानों की जांच करनी है, तो [प्रभावी आकार गुण](/slides/hi/php-java/shape-effective-properties/) पढ़ें।
- कुछ आउटपुट स्वरूप संपादनीय PowerPoint 3D फॉर्मेटिंग को सहेज नहीं सकते। उन स्वरूपों में, दृश्य परिणाम को रेंडर किया जाता है न कि संपादनीय 3D सेटिंग्स के रूप में संरक्षित किया जाता है।

## **प्रश्नोत्तर**

**क्या Aspose.Slides इंटरैक्टिव 3D प्रस्तुतियां बना सकता है?**

Aspose.Slides आकारों और टेक्स्ट के लिए PowerPoint 3D इफ़ेक्ट्स बनाता और रेंडर करता है। यह निर्यातित छवियों, PDFs, या HTML पृष्ठों को इंटरैक्टिव 3D सीन नहीं बनाता जिसे दर्शक घुमा सके। PPTX में, जहाँ फ़ॉर्मेट समर्थन करता है, 3D फॉर्मेटिंग PowerPoint में संपादनीय रहती है।

**3D मॉडल और 3D इफ़ेक्ट में क्या अंतर है?**

3D मॉडल एक अलग 3D वस्तु है जिसे प्रस्तुति में सम्मिलित किया जाता है। 3D इफ़ेक्ट एक सामान्य PowerPoint आकार या टेक्स्ट पर लागू फॉर्मेटिंग है, जैसे घूर्णन, एक्सट्रूज़न, बिवेल, लाइटिंग, और मटीरियल। यह लेख 3D इफ़ेक्ट्स को कवर करता है।

**एक दृश्य 3D आकार के लिए कौन सी सेटिंग्स आवश्यक हैं?**

न्यूनतम रूप से, एक कैमरा घूर्णन और एक्सट्रूज़न या गहराई सेट करें। व्यावहारिक रूप से, लाइट रिग और मटीरियल भी सेट करें ताकि रेंडर किए गए चेहरे में स्पष्ट हाइलाइट्स और शैडोज़ हों।

**क्या मैं आकारों और टेक्स्ट दोनों पर 3D इफ़ेक्ट लागू कर सकता हूँ?**

हां। आकार के बॉडी के लिए [Shape::getThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getThreeDFormat) और टेक्स्ट के लिए [TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#getThreeDFormat) उपयोग करें।

**क्या 3D इफ़ेक्ट्स छवियों, PDF, HTML, या वीडियो फ़्रेम्स में निर्यात करने पर दिखेंगे?**

हां। Aspose.Slides स्लाइड छवियां, PDF आउटपुट, HTML आउटपुट, और वीडियो रूपांतरण के लिए उपयोग किए गए फ़्रेम बनाते समय 3D इफ़ेक्ट्स को रेंडर करता है। निर्यातित आउटपुट में रेंडर की गई दिखावट होती है, न कि संपादनीय 3D वस्तु।

**विरासत और थीम सेटिंग्स लागू होने के बाद अंतिम 3D मान कैसे पढ़ सकता हूँ?**

हां। अंतिम कैमरा, लाइट रिग, बिवेल, और संबंधित 3D मान पढ़ने के लिए [आकार प्रभावी गुण](/slides/hi/php-java/shape-effective-properties/) में वर्णित प्रभावी फॉर्मेटिंग APIs का उपयोग करें।