---
title: PHP का उपयोग करके प्रस्तुतियों में फ़ॉन्ट एंबेड करें
linktitle: फ़ॉन्ट एंबेडिंग
type: docs
weight: 40
url: /hi/php-java/embedded-font/
keywords:
- फ़ॉन्ट जोड़ें
- फ़ॉन्ट एंबेड करें
- फ़ॉन्ट एंबेडिंग
- एंबेडेड फ़ॉन्ट प्राप्त करें
- एंबेडेड फ़ॉन्ट जोड़ें
- एंबेडेड फ़ॉन्ट हटाएँ
- एंबेडेड फ़ॉन्ट संपीड़ित करें
- PowerPoint
- OpenDocument
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Aspose.Slides फॉर PHP वाया जावा के साथ PowerPoint और OpenDocument प्रस्तुतियों में TrueType फ़ॉन्ट एंबेड करें, जिससे सभी प्लेटफ़ॉर्म पर सटीक रेंडरिंग सुनिश्चित हो।"
---
## **परिचय**

**PowerPoint में एंबेडेड फ़ॉन्ट** उपयोगी हैं जब आप चाहते हैं कि आपका प्रेज़ेंटेशन किसी भी सिस्टम या डिवाइस पर खोलने पर सही दिखे। यदि आपने अपने काम में रचनात्मकता दिखाते हुए थर्ड‑पार्टी या गैर‑मानक फ़ॉन्ट का उपयोग किया है, तो आपको फ़ॉन्ट एंबेड करने के और भी कारण मिलते हैं। अन्यथा (बिना एंबेडेड फ़ॉन्ट के), आपके स्लाइड्स पर टेक्स्ट या नंबर, लेआउट, स्टाइलिंग आदि बदल सकते हैं या उलझन भरे आयताकार में बदल सकते हैं।

The [FontsManager](https://reference.aspose.com/slides/hi/php-java/aspose.slides/FontsManager) क्लास, [FontData](https://reference.aspose.com/slides/hi/php-java/aspose.slides/fontdata/) क्लास और [Compress](https://reference.aspose.com/slides/hi/php-java/aspose.slides/compress/) क्लास में अधिकांश मेथड्स होते हैं जिनकी आपको PowerPoint प्रेज़ेंटेशन्स में एंबेडेड फ़ॉन्ट्स के साथ काम करने के लिए आवश्यकता है।

## **एंबेडेड फ़ॉन्ट्स प्राप्त करें और हटाएँ**

Aspose.Slides [getEmbeddedFonts](https://reference.aspose.com/slides/hi/php-java/aspose.slides/fontsmanager/#getEmbeddedFonts) मेथड (जो [FontsManager](https://reference.aspose.com/slides/hi/php-java/aspose.slides/FontsManager) क्लास द्वारा प्रदान किया गया है) आपको प्रेज़ेंटेशन में एंबेडेड फ़ॉन्ट्स प्राप्त (या पता लगाने) की अनुमति देता है। फ़ॉन्ट्स हटाने के लिए, वही क्लास द्वारा प्रदान किया गया [removeEmbeddedFont](https://reference.aspose.com/slides/hi/php-java/aspose.slides/fontsmanager/#removeEmbeddedFont) मेथड उपयोग किया जाता है।

यह PHP कोड आपको दिखाता है कि प्रेज़ेंटेशन से एंबेडेड फ़ॉन्ट्स को कैसे प्राप्त और हटाया जाए:

```php
  # एक Presentation ऑब्जेक्ट बनाता है जो प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है
  $pres = new Presentation("EmbeddedFonts.pptx");
  try {
    # एक स्लाइड रेंडर करता है जिसमें एक टेक्स्ट फ्रेम है जो एंबेडेड "FunSized" का उपयोग करता है
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(new Java("java.awt.Dimension", 960, 720));
    # छवि को JPEG फ़ॉर्मेट में डिस्क पर सहेजें
    try {
      $slideImage->save("picture1_out.jpg", ImageFormat::Jpeg);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
    $fontsManager = $pres->getFontsManager();
    # सभी एंबेडेड फ़ॉन्ट्स प्राप्त करता है
    $embeddedFonts = $fontsManager->getEmbeddedFonts();
    # "Calibri" फ़ॉन्ट को खोजता है
    $calibriEmbeddedFont = null;
    $Array = new java_class("java.lang.reflect.Array");
    for($i = 0; $i < java_values($Array->getLength($embeddedFonts)) ; $i++) {
      echo("" . $embeddedFonts[$i]->getFontName());
      if ("Calibri"->equals($embeddedFonts[$i]->getFontName())) {
        $calibriEmbeddedFont = $embeddedFonts[$i];
        break;
      }
    }
    # "Calibri" फ़ॉन्ट को हटाता है
    $fontsManager->removeEmbeddedFont($calibriEmbeddedFont);
    # प्रस्तुति को रेंडर करता है; "Calibri" फ़ॉन्ट को एक मौजूदा फ़ॉन्ट से बदल दिया जाता है
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(new Java("java.awt.Dimension", 960, 720));
    # छवि को JPEG फ़ॉर्मेट में डिस्क पर सहेजें
    try {
      $slideImage->save("picture2_out.jpg", ImageFormat::Jpeg);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
    # प्रस्तुति को एंबेडेड "Calibri" फ़ॉन्ट के बिना डिस्क पर सहेजता है
    $pres->save("WithoutManageEmbeddedFonts_out.ppt", SaveFormat::Ppt);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **एंबेडेड फ़ॉन्ट्स जोड़ें**

आप [EmbedFontCharacters](https://reference.aspose.com/slides/hi/php-java/aspose.slides/embedfontcharacters/) क्लास और [addEmbeddedFont](https://reference.aspose.com/slides/hi/php-java/aspose.slides/fontsmanager/#addEmbeddedFont) मेथड के दो ओवरलोड का उपयोग करके, प्रेज़ेंटेशन में फ़ॉन्ट्स को एंबेड करने के लिए अपनी पसंदीदा (एंबेडिंग) नियम चुन सकते हैं। यह PHP कोड आपको दिखाता है कि प्रेज़ेंटेशन में फ़ॉन्ट्स को कैसे एंबेड और जोड़ें:

```php
  # प्रस्तुति लोड करता है
  $pres = new Presentation("Fonts.pptx");
  try {
    $allFonts = $pres->getFontsManager()->getFonts();
    $embeddedFonts = $pres->getFontsManager()->getEmbeddedFonts();
    $Array = new java_class("java.lang.reflect.Array");
    foreach($allFonts as $font) {
      $embeddedFontsContainsFont = false;
      for($i = 0; $i < java_values($Array->getLength($embeddedFonts)) ; $i++) {
        if ($embeddedFonts[$i]->equals($font)) {
          $embeddedFontsContainsFont = true;
          break;
        }
      }
      if (!$embeddedFontsContainsFont) {
        $pres->getFontsManager()->addEmbeddedFont($font, EmbedFontCharacters->All);
        $embeddedFonts = $pres->getFontsManager()->getEmbeddedFonts();
      }
    }
    # प्रस्तुति को डिस्क पर सहेजता है
    $pres->save("AddEmbeddedFont_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **एंबेडेड फ़ॉन्ट्स संपीड़ित करें**

प्रेज़ेंटेशन में एंबेडेड फ़ॉन्ट्स को संपीड़ित करके फ़ाइल आकार घटाने के लिए, Aspose.Slides [compressEmbeddedFonts](https://reference.aspose.com/slides/hi/php-java/aspose.slides/compress/#compressEmbeddedFonts) मेथड (जो [Compress](https://reference.aspose.com/slides/hi/php-java/aspose.slides/compress/) क्लास द्वारा प्रदान किया गया है) प्रदान करता है।

यह PHP कोड आपको दिखाता है कि एंबेडेड PowerPoint फ़ॉन्ट्स को कैसे संपीड़ित किया जाए:

```php
  $pres = new Presentation("pres.pptx");
  try {
    Compress->compressEmbeddedFonts($pres);
    $pres->save("pres-out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं कैसे पता कर सकता हूँ कि प्रस्तुति में एक विशिष्ट फ़ॉन्ट एंबेडिंग के बावजूद रेंडरिंग के समय अभी भी प्रतिस्थापित होगा?**  
फ़ॉन्ट मैनेज़र में [substitution information](/slides/hi/php-java/font-substitution/) और [fallback/substitution rules](/slides/hi/php-java/fallback-font/) देखें: यदि फ़ॉन्ट उपलब्ध नहीं है या प्रतिबंधित है, तो फ़ॉलबैक उपयोग किया जाएगा।

**क्या Arial/Calibri जैसी “सिस्टम” फ़ॉन्ट्स को एंबेड करना मूल्यवान है?**  
आमतौर पर नहीं—ये लगभग हमेशा उपलब्ध होते हैं। लेकिन “thin” परिवेशों (Docker, पूर्व-स्थापित फ़ॉन्ट्स के बिना Linux सर्वर) में पूरी पोर्टेबिलिटी के लिए, सिस्टम फ़ॉन्ट्स को एंबेड करने से अनपेक्षित प्रतिस्थापन का जोखिम समाप्त हो सकता है।