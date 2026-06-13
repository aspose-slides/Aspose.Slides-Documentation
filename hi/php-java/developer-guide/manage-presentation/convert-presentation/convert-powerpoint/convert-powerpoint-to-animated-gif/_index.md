---
title: PHP में PowerPoint प्रस्तुतियों को एनिमेटेड GIF में परिवर्तित करें
linktitle: PowerPoint से GIF
type: docs
weight: 65
url: /hi/php-java/convert-powerpoint-to-animated-gif/
keywords:
- एनिमेटेड GIF
- PowerPoint को परिवर्तित करें
- प्रस्तुति को परिवर्तित करें
- स्लाइड को परिवर्तित करें
- PPT को परिवर्तित करें
- PPTX को परिवर्तित करें
- PowerPoint से GIF
- प्रस्तुति से GIF
- स्लाइड से GIF
- PPT से GIF
- PPTX से GIF
- PPT को GIF के रूप में सहेजें
- PPTX को GIF के रूप में सहेजें
- PPT को GIF के रूप में निर्यात करें
- PPTX को GIF के रूप में निर्यात करें
- डिफ़ॉल्ट सेटिंग्स
- कस्टम सेटिंग्स
- PowerPoint
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java के साथ PowerPoint प्रस्तुतियों (PPT, PPTX) को आसानी से एनिमेटेड GIF में परिवर्तित करें। तेज, उच्च-गुणवत्ता परिणाम।"
---
## **अवलोकन**

Aspose.Slides आपको केवल कुछ पंक्तियों के कोड के साथ PowerPoint प्रस्तुतीकरण को एनिमेटेड GIF फ़ाइलों में रूपांतरित करने की सुविधा देता है। यह तब उपयोगी होता है जब आपको स्लाइड सामग्री को हल्के, व्यापक रूप से समर्थित एनिमेटेड फ़ॉर्मेट में साझा करना हो, जिसे वेब पृष्ठों, मैसेंजर्स या दस्तावेज़ों में एम्बेड किया जा सकता है। यह लेख डिफ़ॉल्ट सेटिंग्स का उपयोग करके प्रस्तुतीकरण को GIF में निर्यात करने और फ्रेम आकार, स्लाइड देरी, और ट्रांज़िशन फ्रेम रेट जैसे विकल्पों को कॉन्फ़िगर करके आउटपुट को अनुकूलित करने की प्रक्रिया को [GifOptions](https://reference.aspose.com/slides/hi/php-java/aspose.slides/gifoptions/) के माध्यम से समझाता है।

## **डिफ़ॉल्ट सेटिंग्स का उपयोग करके प्रस्तुतियों को एनिमेटेड GIF में परिवर्तित करें**

यह नमूना कोड आपको मानक सेटिंग्स का उपयोग करके प्रस्तुतीकरण को एनिमेटेड GIF में बदलना दिखाता है:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $pres->save("pres.gif", SaveFormat::Gif);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

एनिमेटेड GIF डिफ़ॉल्ट पैरामीटरों के साथ बनाई जाएगी।

{{%  alert  title="TIP"  color="primary"  %}} 
यदि आप GIF के पैरामीटर को अनुकूलित करना चाहते हैं, तो आप [GifOptions](https://reference.aspose.com/slides/hi/php-java/aspose.slides/GifOptions) क्लास का उपयोग कर सकते हैं। नीचे नमूना कोड देखें।
{{% /alert %}} 

## **कस्टम सेटिंग्स का उपयोग करके प्रस्तुतियों को एनिमेटेड GIF में परिवर्तित करें**
यह नमूना कोड आपको कस्टम सेटिंग्स का उपयोग करके प्रस्तुतीकरण को एनिमेटेड GIF में बदलना दिखाता है :

```php
  $pres = new Presentation("pres.pptx");
  try {
    $gifOptions = new GifOptions();
    $gifOptions->setFrameSize(new Java("java.awt.Dimension", 960, 720));// निर्मित GIF का आकार

    $gifOptions->setDefaultDelay(2000);// प्रत्येक स्लाइड को कितनी देर तक दिखाया जाएगा जब तक वह अगली पर नहीं बदलता

    $gifOptions->setTransitionFps(35);// बेहतर संक्रमण एनीमेशन गुणवत्ता के लिये FPS बढ़ाएँ

    $pres->save("pres.gif", SaveFormat::Gif, $gifOptions);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="Info" color="info" %}}
आप Aspose द्वारा विकसित एक मुफ्त [Text to GIF](https://products.aspose.app/slides/hi/text-to-gif) कनवर्टर को देखना चाहेंगे।
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**यदि प्रस्तुतीकरण में उपयोग किए गए फ़ॉन्ट सिस्टम पर स्थापित नहीं हैं तो क्या होगा?**

गायब फ़ॉन्ट स्थापित करें या [configure fallback fonts](/slides/hi/php-java/powerpoint-fonts/) कॉन्फ़िगर करें। Aspose.Slides प्रतिस्थापन करेगा, लेकिन रूपांतरण भिन्न हो सकता है। ब्रांडिंग के लिए हमेशा सुनिश्चित करें कि आवश्यक टाइपफ़ेस स्पष्ट रूप से उपलब्ध हों।

**क्या मैं GIF फ्रेमों पर वॉटरमार्क ओवरले कर सकता हूँ?**

हां। निर्यात से पहले मास्टर स्लाइड या व्यक्तिगत स्लाइडों में [Add a semi-transparent object/logo](/slides/hi/php-java/watermark/) जोड़ें — वॉटरमार्क प्रत्येक फ्रेम पर प्रदर्शित होगा।