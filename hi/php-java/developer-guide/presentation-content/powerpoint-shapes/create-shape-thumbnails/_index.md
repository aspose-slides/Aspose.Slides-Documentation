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
- PowerPoint
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java का उपयोग करके PowerPoint स्लाइड्स से उच्च‑गुणवत्ता वाले आकार थंबनेल उत्पन्न करें – आसानी से प्रस्तुति थंबनेल बनाएं और निर्यात करें।"
---
## **परिचय**

Aspose.Slides का उपयोग प्रस्तुति फ़ाइलें बनाने के लिए किया जाता है जहाँ प्रत्येक पृष्ठ एक स्लाइड होता है। इन स्लाइडों को Microsoft PowerPoint का उपयोग करके प्रस्तुति फ़ाइलें खोलकर देखा जा सकता है। लेकिन कभी‑कभी, डेवलपर्स को आकारों (shapes) की छवियों को अलग-अलग इमेज व्यूअर में देखना पड़ता है। ऐसे मामलों में, Aspose.Slides स्लाइड आकारों की थंबनेल छवियां उत्पन्न करने में मदद करता है। इस सुविधा का उपयोग कैसे करें, यह लेख में वर्णित है।

यह लेख विभिन्न तरीकों से स्लाइड थंबनेल उत्पन्न करने के बारे में बताता है:

- स्लाइड के भीतर एक आकार (shape) की थंबनेल बनाना।
- उपयोगकर्ता‑परिभाषित आकारों के साथ एक स्लाइड आकार की थंबनेल बनाना।
- आकार की उपस्थिति (appearance) की सीमाओं में थंबनेल बनाना।

## **स्लाइड से शैप थंबनेल जनरेट करें**
Aspose.Slides for PHP via Java का उपयोग करके किसी भी स्लाइड से शैप थंबनेल उत्पन्न करने के लिए, निम्न चरण करें:

1. [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation) क्लास का एक इंस्टेंस बनाएँ।
1. इसका ID या इंडेक्स उपयोग करके किसी भी स्लाइड का रेफ़रेंस प्राप्त करें।
1. [Get the shape thumbnail image](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shape/#getImage) को डिफ़ॉल्ट स्केल पर रेफ़रेंस्ड स्लाइड के लिए प्राप्त करें।
1. थंबनेल छवि को अपनी पसंद के इमेज फ़ॉर्मेट में सहेजें।

यह नमूना कोड दिखाता है कि स्लाइड से शैप थंबनेल कैसे उत्पन्न करें:

```php
  # प्रेजेंटेशन फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का इंस्टेंसेस बनाएं
  $pres = new Presentation("Thumbnail.pptx");
  try {
    # पूर्ण स्केल छवि बनाएं
    $slideImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage();
    # छवि को PNG फ़ॉर्मेट में डिस्क पर सहेजें
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

## **उपयोगकर्ता‑परिभाषित स्केलिंग फ़ैक्टर थंबनेल जनरेट करें**
Aspose.Slides for PHP via Java का उपयोग करके स्लाइड की शैप थंबनेल उत्पन्न करने के लिए, निम्न चरण करें:

1. [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation) क्लास का एक इंस्टेंस बनाएँ।
1. इसका ID या इंडेक्स उपयोग करके किसी भी स्लाइड का रेफ़रेंस प्राप्त करें।
1. [Get the shape thumbnail image](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shape/#getImage) को उपयोगकर्ता‑परिभाषित आयामों के साथ रेफ़रेंस्ड स्लाइड के लिए प्राप्त करें।
1. थंबनेल छवि को अपनी पसंद के इमेज फ़ॉर्मेट में सहेजें।

यह नमूना कोड दिखाता है कि परिभाषित स्केलिंग फ़ैक्टर के आधार पर शैप थंबनेल कैसे उत्पन्न करें:

```php
  # प्रेजेंटेशन फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टेंशिएट करें
  $pres = new Presentation("Thumbnail.pptx");
  try {
    # पूर्ण स्केल छवि बनाएं
    $slideImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage(ShapeThumbnailBounds->Shape, 1, 1);
    # छवि को PNG फ़ॉर्मेट में डिस्क पर सहेजें
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

## **बाउंड‑बेस्ड शैप अपीयरेंस थंबनेल बनाएं**
यह विधि डेवलपर्स को आकार (shape) की उपस्थिति की सीमाओं में थंबनेल उत्पन्न करने की अनुमति देती है। यह सभी शैप इफ़ेक्ट्स को ध्यान में रखती है। उत्पन्न शैप थंबनेल स्लाइड सीमाओं द्वारा सीमित रहता है। आकार की उपस्थिति की सीमा में स्लाइड शैप की थंबनेल उत्पन्न करने के लिए, निम्न चरण करें:

1. [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation) क्लास का एक इंस्टेंस बनाएँ।
1. इसका ID या इंडेक्स उपयोग करके किसी भी स्लाइड का रेफ़रेंस प्राप्त करें।
1. रेफ़रेंस्ड स्लाइड की थंबनेल छवि को शैप बाउंड्स को अपीयरेंस के रूप में लेकर प्राप्त करें।
1. थंबनेल छवि को अपनी पसंद के इमेज फ़ॉर्मेट में सहेजें।

उपर्युक्त चरणों के आधार पर यह नमूना कोड है:

```php
  # प्रेजेंटेशन फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टेंशिएट करें
  $pres = new Presentation("Thumbnail.pptx");
  try {
    # पूर्ण स्केल छवि बनाएं
    $slideImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage(ShapeThumbnailBounds->Appearance, 1, 1);
    # छवि को PNG फ़ॉर्मेट में डिस्क पर सहेजें
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

## **FAQ**

**थंबनेल सहेजते समय कौन‑से इमेज फ़ॉर्मेट उपयोग किए जा सकते हैं?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/hi/php-java/aspose.slides/imageformat/), तथा अन्य। शैप को [वेक्टर SVG के रूप में निर्यात भी किया जा सकता है](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shape/writeassvg/) जब शैप की सामग्री को SVG के रूप में सहेजा जाता है।

**थंबनेल रेंडर करते समय Shape और Appearance बाउंड्स में क्या अंतर है?**

`Shape` आकार की ज्योमेट्री का उपयोग करता है; `Appearance` दृश्य प्रभावों को ध्यान में रखता है, जैसे छाया (shadows), चमक (glows) आदि।

**यदि किसी शैप को छिपा (hidden) चिह्नित किया गया है तो क्या वह थंबनेल के रूप में रेंडर होगी?**

छिपा शैप मॉडल का हिस्सा बना रहता है और रेंडर किया जा सकता है; छिपा फ़्लैग स्लाइडशो प्रदर्शन को प्रभावित करता है लेकिन शैप की छवि उत्पन्न करने से नहीं रोकता।

**क्या समूह शैप (group shapes), चार्ट, SmartArt, और अन्य जटिल ऑब्जेक्ट्स समर्थित हैं?**

हाँ। कोई भी ऑब्जेक्ट जो [Shape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shape/) के रूप में दर्शाया गया है (जैसे [GroupShape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chart/), और [SmartArt](https://reference.aspose.com/slides/hi/php-java/aspose.slides/smartart/)) को थंबनेल या SVG के रूप में सहेजा जा सकता है।

**क्या सिस्टम‑इंस्टॉल्ड फ़ॉन्ट्स टेक्स्ट शैप्स की थंबनेल गुणवत्ता को प्रभावित करते हैं?**

हाँ। आपको आवश्यक फ़ॉन्ट्स प्रदान करने चाहिए (/slides/hi/php-java/custom-font/) या फ़ॉन्ट प्रतिस्थापन को कॉन्फ़िगर करना चाहिए (/slides/hi/php-java/font-substitution/) ताकि अनपेक्षित फ़ॉलबैक और टेक्स्ट रीफ़्लो से बचा जा सके।