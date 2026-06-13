---
title: PHP में PowerPoint स्लाइड्स को PNG में बदलें
linktitle: PowerPoint से PNG
type: docs
weight: 30
url: /hi/php-java/convert-powerpoint-to-png/
keywords:
- PowerPoint परिवर्तित करें
- प्रेजेंटेशन परिवर्तित करें
- स्लाइड परिवर्तित करें
- PPT परिवर्तित करें
- PPTX परिवर्तित करें
- PowerPoint से PNG
- प्रेजेंटेशन से PNG
- स्लाइड से PNG
- PPT से PNG
- PPTX से PNG
- PPT को PNG के रूप में सहेजें
- PPTX को PNG के रूप में सहेजें
- PPT को PNG में निर्यात करें
- PPTX को PNG में निर्यात करें
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java के साथ PowerPoint प्रस्तुतियों को उच्च-गुणवत्ता PNG छवियों में शीघ्रता से बदलें, सटीक एवं स्वचालित परिणाम सुनिश्चित करते हुए।"
---
## **परिचय**

यह लेख Aspose.Slides का उपयोग करके PowerPoint प्रस्तुतियों को PNG छवियों में परिवर्तित करने की विधि बताता है। यह दिखाता है कि PPT, PPTX, और ODP जैसे फॉर्मेट में प्रस्तुतियों को कैसे लोड करें, स्लाइड को छवि के रूप में रेंडर करें, और परिणाम को PNG फॉर्मेट में सहेजें।

यह लेख यह भी दर्शाता है कि स्केल मान सेट करके या इच्छित चौड़ाई और ऊँचाई निर्दिष्ट करके उत्पन्न PNG छवियों को कैसे अनुकूलित किया जा सकता है।

## **PowerPoint को PNG में परिवर्तित करें**

निम्न चरणों का पालन करें:

1. [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएं।
2. [Slide](https://reference.aspose.com/slides/hi/php-java/aspose.slides/slide/) क्लास के तहत [Presentation.getSlides()](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/#getSlides) संग्रह से स्लाइड ऑब्जेक्ट प्राप्त करें।
3. प्रत्येक स्लाइड के लिए थंबनेल पाने हेतु [Slide.getImage()](https://reference.aspose.com/slides/hi/php-java/aspose.slides/slide/#getImage) मेथड का उपयोग करें।
4. स्लाइड थंबनेल को PNG फॉर्मेट में सहेजने हेतु [IImage.save(String formatName, int imageFormat)](https://reference.aspose.com/slides/hi/php-java/aspose.slides/iimage/#save) मेथड का उपयोग करें।

यह PHP कोड दिखाता है कि PowerPoint प्रस्तुति को PNG में कैसे परिवर्तित किया जाए:

```php
  $pres = new Presentation("pres.pptx");
  try {
    for($index = 0; $index < java_values($pres->getSlides()->size()) ; $index++) {
      $slide = $pres->getSlides()->get_Item($index);
      $slideImage = $slide->getImage();
      try {
        $slideImage->save("image_java_" . $index . ".png", ImageFormat::Png);
      } finally {
        if (!java_is_null($slideImage)) {
          $slideImage->dispose();
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **PowerPoint को कस्टम आयामों के साथ PNG में परिवर्तित करें**

यदि आप किसी निश्चित स्केल के आसपास PNG फ़ाइलें प्राप्त करना चाहते हैं, तो आप `desiredX` और `desiredY` मान सेट कर सकते हैं, जो परिणामी थंबनेल के आयाम निर्धारित करते हैं।

यह कोड वर्णित प्रक्रिया को प्रदर्शित करता है:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $scaleX = 2.0;
    $scaleY = 2.0;
    for($index = 0; $index < java_values($pres->getSlides()->size()) ; $index++) {
      $slide = $pres->getSlides()->get_Item($index);
      $slideImage = $slide->getImage($scaleX, $scaleY);
      try {
        $slideImage->save("image_java_" . $index . ".png", ImageFormat::Png);
      } finally {
        if (!java_is_null($slideImage)) {
          $slideImage->dispose();
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **PowerPoint को कस्टम आकार के साथ PNG में परिवर्तित करें**

यदि आप किसी निश्चित आकार के आसपास PNG फ़ाइलें प्राप्त करना चाहते हैं, तो आप `ImageSize` के लिए अपनी पसंदीदा `width` और `height` आर्ग्यूमेंट पास कर सकते हैं।

यह कोड दिखाता है कि इमेज के आकार को निर्दिष्ट करते हुए PowerPoint को PNG में कैसे परिवर्तित किया जाए:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $size = new Java("java.awt.Dimension", 960, 720);
    for($index = 0; $index < java_values($pres->getSlides()->size()) ; $index++) {
      $slide = $pres->getSlides()->get_Item($index);
      $slideImage = $slide->getImage($size);
      try {
        $slideImage->save("image_java_" . $index . ".png", ImageFormat::Png);
      } finally {
        if (!java_is_null($slideImage)) {
          $slideImage->dispose();
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं पूरे स्लाइड के बजाय केवल एक विशिष्ट आकार (जैसे चार्ट या चित्र) को निर्यात कैसे करूँ?**

Aspose.Slides व्यक्तिगत आकारों के लिए [थंबनेल उत्पन्न करने](/slides/hi/php-java/create-shape-thumbnails/) का समर्थन करता है; आप आकार को PNG छवि में रेंडर कर सकते हैं।

**क्या सर्वर पर समानांतर रूपांतरण समर्थित है?**

हां, लेकिन [एक ही प्रस्तुति इंस्टेंस को थ्रेड्स के बीच साझा न करें](/slides/hi/php-java/multithreading/)। प्रत्येक थ्रेड या प्रक्रिया के लिए अलग इंस्टेंस उपयोग करें।

**PNG निर्यात करते समय ट्रायल-वर्शन सीमाएँ क्या हैं?**

मूल्यांकन मोड आउटपुट छवियों में वॉटरमार्क जोड़ता है और लाइसेंस लागू होने तक [अन्य प्रतिबंध](/slides/hi/php-java/licensing/) लागू करता है।