---
title: PHP में PPT और PPTX को JPG में बदलें
linktitle: PowerPoint से JPG
type: docs
weight: 60
url: /hi/php-java/convert-powerpoint-to-jpg/
keywords:
- PowerPoint को बदलें
- प्रेज़ेंटेशन को बदलें
- स्लाइड को बदलें
- PPT को बदलें
- PPTX को बदलें
- PowerPoint से JPG
- प्रेज़ेंटेशन से JPG
- स्लाइड से JPG
- PPT से JPG
- PPTX से JPG
- PowerPoint को JPG के रूप में सेव करें
- प्रेज़ेंटेशन को JPG के रूप में सेव करें
- स्लाइड को JPG के रूप में सेव करें
- PPT को JPG के रूप में सेव करें
- PPTX को JPG के रूप में सेव करें
- PPT को JPG में निर्यात करें
- PPTX को JPG में निर्यात करें
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP का उपयोग करके PHP में PowerPoint (PPT, PPTX) स्लाइड्स को उच्च-गुणवत्ता वाली JPG छवियों में तेज़ और विश्वसनीय कोड उदाहरणों के साथ बदलें।"
---
## **परिचय**

PowerPoint और OpenDocument प्रस्तुतियों को JPG छवियों में रूपांतरित करने से स्लाइड्स को साझा करना, प्रदर्शन को अनुकूलित करना और वेबसाइटों या एप्लिकेशन में सामग्री एम्बेड करना आसान हो जाता है। Aspose.Slides आपको PPTX, PPT, और ODP फ़ाइलों को उच्च गुणवत्ता वाली JPEG छवियों में बदलने की सुविधा देता है। यह गाइड रूपांतरण के विभिन्न तरीकों को समझाता है।

इन सुविधाओं के साथ, अपना खुद का प्रेज़ेंटेशन व्यूअर लागू करना और प्रत्येक स्लाइड के लिए थंबनेल बनाना आसान हो जाता है। यह उपयोगी हो सकता है यदि आप प्रेज़ेंटेशन स्लाइड्स को कॉपी से बचाना चाहते हैं या प्रेज़ेंटेशन को केवल-पीढ़न मोड में प्रदर्शित करना चाहते हैं। Aspose.Slides आपको पूरी प्रेज़ेंटेशन या किसी विशिष्ट स्लाइड को इमेज फ़ॉर्मैट्स में बदलने की अनुमति देता है।

## **PowerPoint PPT/PPTX को JPG में रूपांतरित करें**

PPT/PPTX को JPG में बदलने के चरण इस प्रकार हैं:

1. एक [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/Presentation) प्रकार का इंस्टेंस बनाएं।
2. [Presentation::getSlides()](https://reference.aspose.com/slides/hi/php-java/aspose.slides/Presentation#getSlides--) संग्रह से [Slide](https://reference.aspose.com/slides/hi/php-java/aspose.slides/slide/) प्रकार की स्लाइड ऑब्जेक्ट प्राप्त करें।
3. प्रत्येक स्लाइड का थंबनेल बनाएं और फिर उसे JPG में रूपांतरित करें। [**Slide::getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/hi/php-java/aspose.slides/slide/#getImage) मेथड का उपयोग स्लाइड का थंबनेल प्राप्त करने के लिए किया जाता है। [getImage](https://reference.aspose.com/slides/hi/php-java/aspose.slides/slide/#getImage) मेथड को आवश्यक स्लाइड के [Slide](https://reference.aspose.com/slides/hi/php-java/aspose.slides/slide/) प्रकार से कॉल करना होता है, परिणामी थंबनेल के स्केल्स को मेथड में पास किया जाता है।
4. स्लाइड थंबनेल प्राप्त करने के बाद, थंबनेल ऑब्जेक्ट से [**IImage::save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/hi/php-java/aspose.slides/IImage#save(String formatName, int imageFormat)) मेथड को कॉल करें। परिणामी फ़ाइल नाम और इमेज फ़ॉर्मेट इसे पास करें।

{{% alert color="primary" %}}

**नोट**: PPT/PPTX को JPG रूपांतरण Aspose.Slides API में अन्य प्रकारों के रूपांतरण से अलग है। अन्य प्रकारों के लिए, आप आमतौर पर [**Presentation::Save(String fname, int format, SaveOptions options)**](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/save/) मेथड का उपयोग करते हैं, लेकिन यहाँ आपको [**IImage::save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/hi/php-java/aspose.slides/IImage#save(String formatName, int imageFormat)) मेथड की आवश्यकता होती है।

{{% /alert %}}

```php
  $pres = new Presentation("PowerPoint-Presentation.pptx");
  try {
    foreach($pres->getSlides() as $sld) {
      # पूर्ण आकार की छवि बनाता है
      $slideImage = $sld->getImage(1.0, 1.0);
      # छवि को JPEG फ़ॉर्मेट में डिस्क पर सहेजता है
      try {
        $slideImage->save(String->format("Slide_%d.jpg", $sld->getSlideNumber()), ImageFormat::Jpeg);
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

## **PowerPoint PPT/PPTX को अनुकूलित आयामों के साथ JPG में रूपांतरित करें**

परिणामी थंबनेल और JPG छवि के आयाम बदलने के लिए, आप *ScaleX* और *ScaleY* मानों को [**Slide::getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/hi/php-java/aspose.slides/slide/#getImage) मेथड में पास करके सेट कर सकते हैं:

```php
  $pres = new Presentation("PowerPoint-Presentation.pptx");
  try {
    # आयाम निर्धारित करता है
    $desiredX = 1200;
    $desiredY = 800;
    # X और Y के स्केल्ड मान प्राप्त करता है
    $ScaleX = 1.0 / $pres->getSlideSize()->getSize()->getWidth() * $desiredX;
    $ScaleY = 1.0 / $pres->getSlideSize()->getSize()->getHeight() * $desiredY;
    foreach($pres->getSlides() as $sld) {
      # पूर्ण आकार की छवि बनाता है
      $slideImage = $sld->getImage($ScaleX, $ScaleY);
      # छवि को JPEG फ़ॉर्मेट में डिस्क पर सहेजता है
      try {
        $slideImage->save(String->format("Slide_%d.jpg", $sld->getSlideNumber()), ImageFormat::Jpeg);
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

## **स्लाइड्स को इमेज के रूप में सहेजते समय टिप्पणियों को रेंडर करें**

Aspose.Slides for PHP via Java एक सुविधा प्रदान करता है जो आपको स्लाइड्स को इमेज में बदलते समय प्रस्तुति की स्लाइड्स में टिप्पणी रेंडर करने देती है। यह PHP कोड इस ऑपरेशन को दर्शाता है:

```php
  $pres = new Presentation("presentation.pptx");
  try {
    $notesOptions = new NotesCommentsLayoutingOptions();
    $notesOptions->setNotesPosition(NotesPositions::BottomTruncated);
    $opts = new RenderingOptions();
    $opts->setSlidesLayoutOptions($notesOptions);
    foreach($pres->getSlides() as $sld) {
      $slideImage = $sld->getImage($opts, new Java("java.awt.Dimension", 740, 960));
      try {
        $slideImage->save(String->format("Slide_%d.png", $sld->getSlideNumber()));
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

{{% alert title="Tip" color="primary" %}}

Aspose एक [फ़्री कोलाज वेब ऐप](https://products.aspose.app/slides/hi/collage) प्रदान करता है। इस ऑनलाइन सेवा का उपयोग करके आप [JPG से JPG](https://products.aspose.app/slides/hi/collage/jpg) या PNG से PNG छवियों को मर्ज कर सकते हैं, [फ़ोटो ग्रिड्स](https://products.aspose.app/slides/hi/collage/photo-grid) बना सकते हैं, आदि।

इस लेख में वर्णित समान सिद्धांतों का उपयोग करके आप छवियों को एक फ़ॉर्मेट से दूसरे में रूपांतरित कर सकते हैं। अधिक जानकारी के लिए इन पृष्ठों को देखें: [image to JPG](https://products.aspose.com/slides/hi/php-java/conversion/image-to-jpg/) को रूपांतरित करें; [JPG to image](https://products.aspose.com/slides/hi/php-java/conversion/jpg-to-image/) को रूपांतरित करें; [JPG to PNG](https://products.aspose.com/slides/hi/php-java/conversion/jpg-to-png/) को रूपांतरित करें, [PNG to JPG](https://products.aspose.com/slides/hi/php-java/conversion/png-to-jpg/) को रूपांतरित करें; [PNG to SVG](https://products.aspose.com/slides/hi/php-java/conversion/png-to-svg/) को रूपांतरित करें, [SVG to PNG](https://products.aspose.com/slides/hi/php-java/conversion/svg-to-png/) को रूपांतरित करें।

{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या यह विधि बैच रूपांतरण का समर्थन करती है?**

हां, Aspose.Slides एक ही ऑपरेशन में कई स्लाइड्स को JPG में बैच रूपांतरण की अनुमति देता है।

**क्या रूपांतरण SmartArt, चार्ट और अन्य जटिल ऑब्जेक्ट्स को समर्थन देता है?**

हां, Aspose.Slides सभी सामग्री को रेंडर करता है, जिसमें SmartArt, चार्ट, टेबल, आकृतियां और अधिक शामिल हैं। हालांकि, रेंडरिंग की सटीकता PowerPoint की तुलना में थोड़ा भिन्न हो सकती है, विशेषकर कस्टम या अनुपलब्ध फ़ॉन्ट्स के उपयोग पर।

**क्या प्रोसेस किए जा सकने वाले स्लाइड्स की संख्या पर कोई सीमा है?**

Aspose.Slides स्वयं प्रोसेस किए जाने वाले स्लाइड्स की संख्या पर कोई सख्त सीमा नहीं लगाता। हालांकि, बड़े प्रस्तुतियों या उच्च-रिज़ॉल्यूशन छवियों के साथ काम करते समय आप मेमोरी समाप्ति त्रुटि का सामना कर सकते हैं।

## **संबंधित देखें**

PPT/PPTX को छवि में बदलने के अन्य विकल्प देखें जैसे:

- [PPT/PPTX से SVG रूपांतरण](/slides/hi/php-java/render-a-slide-as-an-svg-image/).