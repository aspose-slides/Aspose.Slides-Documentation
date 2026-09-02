---
title: PHP में प्रस्तुति आकारों के थंबनेल बनाएं
linktitle: आकार थंबनेल
type: docs
weight: 70
url: /hi/php-java/create-shape-thumbnails/
keywords:
- आकार थंबनेल
- आकार छवि
- आकार रेंडर
- आकार रेंडरिंग
- दृश्य सीमाएँ
- आकार सीमाएँ
- PowerPoint
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java के साथ PowerPoint स्लाइड्स से उच्च‑गुणवत्ता वाले आकार थंबनेल उत्पन्न करें – आसानी से प्रस्तुति थंबनेल बनाएं और निर्यात करें।"
---
## **परिचय**

Aspose.Slides का उपयोग प्रस्तुति फ़ाइलें बनाने के लिए किया जाता है जहाँ प्रत्येक पृष्ठ एक स्लाइड होता है। इन स्लाइडों को Microsoft PowerPoint का उपयोग करके प्रस्तुति फ़ाइलों को खोलकर देखा जा सकता है। लेकिन कभी‑कभी, डेवलपर्स को आकारों की छवियों को अलग‑अलग इमेज व्यूअर में देखना पड़ सकता है। ऐसे मामलों में, Aspose.Slides आपको स्लाइड आकारों की थंबनेल छवियाँ बनाने में मदद करता है। इस सुविधा का उपयोग कैसे करें, इस लेख में वर्णित है।

यह लेख विभिन्न तरीकों से स्लाइड थंबनेल बनाने के बारे में समझाता है:

- एक स्लाइड के भीतर आकार का थंबनेल बनाना।
- उपयोगकर्ता द्वारा परिभाषित आयामों के साथ स्लाइड आकार के लिए आकार का थंबनेल बनाना।
- आकार की उपस्थिति की सीमा के भीतर आकार का थंबनेल बनाना।

## **एक स्लाइड से आकार का थंबनेल बनाना**
Aspose.Slides for PHP via Java का उपयोग करके किसी भी स्लाइड से आकार का थंबनेल बनाने के लिए, यह करें:

1. [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation) क्लास का एक इंस्टेंस बनाएं।
2. उसके ID या इंडेक्स का उपयोग करके किसी भी स्लाइड का रेफ़रेंस प्राप्त करें।
3. [Get the shape thumbnail image](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shape/#getImage) डिफ़ॉल्ट स्केल पर रेफ़रेंस्ड स्लाइड की आकार थंबनेल छवि प्राप्त करें।
4. थंबनेल छवि को अपने पसंदीदा इमेज फॉर्मेट में सहेजें।

```php
  # प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का इंस्टेंस बनाएं
  $pres = new Presentation("Thumbnail.pptx");
  try {
    # पूरा स्केल इमेज बनाएं
    $slideImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage();
    # इमेज को PNG फ़ॉर्मेट में डिस्क पर सहेजें
    try {
      $slideImage->save("output.png", ImageFormat::Png);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **उपयोगकर्ता‑परिभाषित स्केलिंग फैक्टर थंबनेल बनाना**
Aspose.Slides for PHP via Java का उपयोग करके स्लाइड का आकार थंबनेल बनाने के लिए, यह करें:

1. [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation) क्लास का एक इंस्टेंस बनाएं।
2. उसके ID या इंडेक्स का उपयोग करके किसी भी स्लाइड का रेफ़रेंस प्राप्त करें।
3. उपयोगकर्ता‑परिभाषित आयामों के साथ रेफ़रेंस्ड स्लाइड की आकार थंबनेल छवि प्राप्त करें। ([Get the shape thumbnail image](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shape/#getImage))
4. थंबनेल छवि को अपने पसंदीदा इमेज फॉर्मेट में सहेजें।

```php
  # प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंशिएट करें
  $pres = new Presentation("Thumbnail.pptx");
  try {
    # पूरा स्केल इमेज बनाएं
    $slideImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage(ShapeThumbnailBounds->Shape, 1, 1);
    # इमेज को PNG फ़ॉर्मेट में डिस्क पर सहेजें
    try {
      $slideImage->save("output.png", ImageFormat::Png);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **सीमा‑आधारित आकार उपस्थिति थंबनेल बनाना**
आकारों के थंबनेल बनाने की यह विधि डेवलपर्स को आकार की उपस्थिति की सीमा में थंबनेल बनाने की अनुमति देती है। यह सभी आकार प्रभावों को ध्यान में रखती है। निर्मित आकार थंबनेल स्लाइड की सीमाओं द्वारा सीमित होता है। अपनी उपस्थिति की सीमा में स्लाइड आकार का थंबनेल बनाने के लिए, यह करें:

1. [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation) क्लास का एक इंस्टेंस बनाएं।
2. उसके ID या इंडेक्स का उपयोग करके किसी भी स्लाइड का रेफ़रेंस प्राप्त करें।
3. आकार की उपस्थिति को सीमा के रूप में उपयोग करके रेफ़रेंस्ड स्लाइड की थंबनेल छवि प्राप्त करें।
4. थंबनेल छवि को अपने पसंदीदा इमेज फॉर्मेट में सहेजें।

```php
  # प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंशिएट करें
  $pres = new Presentation("Thumbnail.pptx");
  try {
    # पूर्ण स्केल इमेज बनाएं
    $slideImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage(ShapeThumbnailBounds->Appearance, 1, 1);
    # इमेज को PNG फ़ॉर्मेट में डिस्क पर सहेजें
    try {
      $slideImage->save("output.png", ImageFormat::Png);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **आकार की वास्तविक विजुअल बाउंड्स प्राप्त करें**

फ़्रेम गुणधर्म [Shape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shape/)—`Shape::getX()`, `Shape::getY()`, `Shape::getWidth()`, और `Shape::getHeight()`—प्रेज़ेंटेशन मॉडल में संग्रहीत आयत को वर्णित करते हैं। वास्तव में रेंडर की गई सामग्री उस फ़्रेम से परे जा सकती है या किसी अलग अक्ष‑संरेखित आयत में हो सकती है। रोटेशन, आउटलाइन, तीर सिरा, टेक्स्ट लेआउट और ओवरफ़्लो, जेनरेटेड SmartArt जियोमेट्री, और अन्य रेंडरिंग इफ़ेक्ट्स सभी कब्ज़ा किए गए क्षेत्र को बदल सकते हैं।

छवि बनाए बिना उस कब्ज़ा किए गए क्षेत्र की गणना करने के लिए [Shape::getVisualBounds](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shape/#getVisualBounds) का उपयोग करें। यह मेथड स्लाइड कोऑर्डिनेट्स में एक [Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html) लौटाता है। लौटाया गया आयत स्लाइड तक क्लिप नहीं किया जाता, इसलिए जब सामग्री स्लाइड मूल बिंदु से परे विस्तारित हो तो उसके कोऑर्डिनेट्स नकारात्मक हो सकते हैं।

निम्नलिखित उदाहरण फ़्रेम और विजुअल बाउंड्स को प्राप्त करता है और तुलना करता है:

```php
  $presentation = new Presentation("example.pptx");
  try {
      $slide = $presentation->getSlides()->get_Item(0);
      $shape = $slide->getShapes()->get_Item(0);

      $visualBounds = $shape->getVisualBounds();

      $frameX = $shape->getX();
      $frameY = $shape->getY();
      $frameWidth = $shape->getWidth();
      $frameHeight = $shape->getHeight();

      $visualX = $visualBounds->getX();
      $visualY = $visualBounds->getY();
      $visualWidth = $visualBounds->getWidth();
      $visualHeight = $visualBounds->getHeight();

      echo "Frame bounds (x, y, width, height): $frameX, $frameY, $frameWidth, $frameHeight\n";
      echo "Visual bounds (x, y, width, height): $visualX, $visualY, $visualWidth, $visualHeight\n";
  } finally {
      $presentation->dispose();
  }
```

इसी [Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html) का उपयोग निकटवर्ती आकारों को उसके बाएँ, दाएँ, ऊपर या नीचे किनारे पर संरेखित करने, निर्मित लेआउट में पर्याप्त जगह आरक्षित करने, या अनुमत क्षेत्र के बाहर की सामग्री का पता लगाने के लिए किया जा सकता है। विजुअल बाउंड्स विशेष रूप से SmartArt, टेक्स्ट बॉक्स, तीर, चित्र, घुमाए गए आकार, और समूह आकारों के लिए उपयोगी होते हैं, जहाँ संग्रहीत फ़्रेम पूर्ण रेंडर परिणाम को दर्शा नहीं सकता।

जब आपको लेआउट या वैलिडेशन के लिए कोऑर्डिनेट्स चाहिए और बिटमैप की आवश्यकता नहीं है, तो [Shape::getVisualBounds] का उपयोग करें। जब आपको आकार को रेंडर करने की आवश्यकता हो, तो [Shape::getImage] का उपयोग करें। [ShapeThumbnailBounds] के साथ, `ShapeThumbnailBounds::Shape` आकार की सीमाओं से, आउटलाइन सेटिंग्स सहित, इमेज का आकार निर्धारित करता है, जबकि `ShapeThumbnailBounds::Appearance` आकार की उपस्थिति से इमेज का आकार देता है और परिणाम को स्लाइड की सीमाओं तक सीमित करता है। इसके विपरीत, `Shape::getVisualBounds` केवल गणना किया गया आयत लौटाता है और इसे स्लाइड तक क्लिप नहीं करता।

## **अक्सर पूछे जाने वाले प्रश्न**

**आकार थंबनेल को सहेजते समय कौन से इमेज फ़ॉर्मेट का उपयोग किया जा सकता है?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/hi/php-java/aspose.slides/imageformat/), और अन्य। आकारों को भी [exported as vector SVG](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shape/writeassvg/) के रूप में निर्यात किया जा सकता है।

**थंबनेल रेंडर करने के समय Shape और Appearance बाउंड्स में क्या अंतर है?**

`Shape` आकार की ज्योमेट्री का उपयोग करता है; `Appearance` [visual effects](/slides/hi/php-java/shape-effect/) (छायाएँ, चमक, आदि) को ध्यान में रखता है।

**यदि कोई आकार छिपा (hidden) चिह्नित किया गया है तो क्या होगा? क्या यह अभी भी थंबनेल के रूप में रेंडर होगा?**

एक छिपा हुआ आकार मॉडल का हिस्सा बना रहता है और रेंडर किया जा सकता है; hidden फ़्लैग स्लाइडशो प्रदर्शन को प्रभावित करता है लेकिन आकार की छवि उत्पन्न करने से नहीं रोकता।

**क्या समूह आकार, चार्ट, SmartArt और अन्य जटिल वस्तुएँ समर्थित हैं?**

हाँ। कोई भी वस्तु जो [Shape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shape/) (जिसमें [GroupShape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chart/), और [SmartArt](https://reference.aspose.com/slides/hi/php-java/aspose.slides/smartart/)) के रूप में दर्शाई गई है, उसे थंबनेल या SVG के रूप में सहेजा जा सकता है।

**क्या सिस्टम‑इंस्टॉल फ़ॉन्ट्स टेक्स्ट आकारों के थंबनेल की गुणवत्ता को प्रभावित करते हैं?**

हाँ। आपको [provide the required fonts](/slides/hi/php-java/custom-font/) (या [configure font substitutions](/slides/hi/php-java/font-substitution/)) प्रदान करने चाहिए ताकि अनपेक्षित फ़ॉन्ट प्रतिस्थापन और टेक्स्ट रीफ़्लो से बचा जा सके।