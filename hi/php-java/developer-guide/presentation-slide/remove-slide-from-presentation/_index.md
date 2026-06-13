---
title: "PHP में प्रस्तुति से स्लाइड हटाएँ"
linktitle: "स्लाइड हटाएँ"
type: docs
weight: 30
url: /hi/php-java/remove-slide-from-presentation/
keywords:
- "स्लाइड हटाएँ"
- "स्लाइड को हटाएँ"
- "अप्रयुक्त स्लाइड हटाएँ"
- PowerPoint
- OpenDocument
- "प्रस्तुति"
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java के साथ PowerPoint और OpenDocument प्रस्तुतियों से स्लाइड को आसानी से हटाएँ। स्पष्ट कोड उदाहरण प्राप्त करें और अपने कार्यप्रवाह को तेज़ बनाएँ।"
---
## **परिचय**

यदि कोई स्लाइड (या उसकी सामग्री) अनावश्यक हो जाए, तो आप उसे हटा सकते हैं। Aspose.Slides [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) क्लास प्रदान करता है जो [SlideCollection](https://reference.aspose.com/slides/hi/php-java/aspose.slides/slidecollection/) को समाहित करता है, जो एक प्रस्तुति में सभी स्लाइडों के लिए रिपोजिटरी है। किसी ज्ञात [Slide](https://reference.aspose.com/slides/hi/php-java/aspose.slides/slide/) के लिए संकेतकों (संदर्भ या Index) का उपयोग करके, आप वह स्लाइड निर्दिष्ट कर सकते हैं जिसे आप हटाना चाहते हैं।

## **संदर्भ द्वारा स्लाइड हटाएँ**

1. एक [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) क्लास का उदाहरण बनाएं।  
2. अपनी ID या Index के माध्यम से वह स्लाइड जिसका आप हटाना चाहते हैं, उसका संदर्भ प्राप्त करें।  
3. प्रस्तुति से संदर्भित स्लाइड को हटाएं।  
4. संशोधित प्रस्तुति को सहेजें।  

```php
  # एक Presentation वस्तु बनाएं जो प्रस्तुति फ़ाइल का प्रतिनिधित्व करती है
  $pres = new Presentation("demo.pptx");
  try {
    # स्लाइड संग्रह में इसके इंडेक्स के माध्यम से एक स्लाइड तक पहुंचता है
    $slide = $pres->getSlides()->get_Item(0);
    # संदर्भ के माध्यम से एक स्लाइड हटाता है
    $pres->getSlides()->remove($slide);
    # संशोधित प्रस्तुति को सहेजता है
    $pres->save("modified.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **सूचकांक द्वारा स्लाइड हटाएँ**

1. एक [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) क्लास का उदाहरण बनाएं।  
2. प्रस्तुति से स्लाइड को उसके Index स्थिति के माध्यम से हटाएं।  
3. संशोधित प्रस्तुति को सहेजें।  

```php
  # एक Presentation वस्तु बनाता है जो प्रस्तुति फ़ाइल का प्रतिनिधित्व करती है
  $pres = new Presentation("demo.pptx");
  try {
    # स्लाइड इंडेक्स के माध्यम से एक स्लाइड हटाता है
    $pres->getSlides()->removeAt(0);
    # संशोधित प्रस्तुति को सहेजता है
    $pres->save("modified.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **अप्रयुक्त लेआउट स्लाइड हटाएँ**

Aspose.Slides [removeUnusedLayoutSlides](https://reference.aspose.com/slides/hi/php-java/aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) मेथड (जो [Compress](https://reference.aspose.com/slides/hi/php-java/aspose.slides/compress/) क्लास से है) प्रदान करता है जो आपको अनावश्यक और अप्रयुक्त लेआउट स्लाइड्स को हटाने की अनुमति देता है। यह PHP कोड दिखाता है कि PowerPoint प्रस्तुति से लेआउट स्लाइड कैसे हटाएं:

```php
  $pres = new Presentation("pres.pptx");
  try {
    Compress->removeUnusedLayoutSlides($pres);
    $pres->save("pres-out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **अप्रयुक्त मास्टर स्लाइड हटाएँ**

Aspose.Slides [removeUnusedMasterSlides](https://reference.aspose.com/slides/hi/php-java/aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) मेथड (जो [Compress](https://reference.aspose.com/slides/hi/php-java/aspose.slides/compress/) क्लास से है) प्रदान करता है जो आपको अनावश्यक और अप्रयुक्त मास्टर स्लाइड्स को हटाने की अनुमति देता है। यह PHP कोड दिखाता है कि PowerPoint प्रस्तुति से मास्टर स्लाइड कैसे हटाएं:

```php
  $pres = new Presentation("pres.pptx");
  try {
    Compress->removeUnusedMasterSlides($pres);
    $pres->save("pres-out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **अक्सर पूछे जाने वाले प्रश्न**

**स्लाइड को हटाने के बाद स्लाइड इंडेक्स के साथ क्या होता है?**  
हटाने के बाद, [collection](https://reference.aspose.com/slides/hi/php-java/aspose.slides/slidecollection/) पुनः इंडेक्स करता है: प्रत्येक बाद की स्लाइड एक स्थान बाएँ खिसकती है, इसलिए पहले के इंडेक्स नंबर पुराने हो जाते हैं। यदि आपको एक स्थिर संदर्भ चाहिए, तो प्रत्येक स्लाइड का स्थायी ID उपयोग करें, न कि उसका इंडेक्स।

**क्या स्लाइड का ID उसके इंडेक्स से अलग है, और क्या यह पड़ोसी स्लाइड हटाने पर बदलता है?**  
हाँ। इंडेक्स स्लाइड की स्थिति है और स्लाइड जोड़ने या हटाने पर बदलता है। स्लाइड ID एक स्थायी पहचानकर्ता है और अन्य स्लाइड हटाने पर नहीं बदलता।

**स्लाइड को हटाने से स्लाइड सेक्शन पर क्या प्रभाव पड़ता है?**  
यदि स्लाइड किसी सेक्शन का हिस्सा थी, तो वह सेक्शन बस एक स्लाइड कम रखेगा। सेक्शन की संरचना बनी रहती है; यदि कोई सेक्शन खाली हो जाता है, तो आप आवश्यकतानुसार [सेक्शन हटाएँ या पुनर्गठित करें](/slides/hi/php-java/slide-section/) कर सकते हैं।

**स्लाइड हटाने पर उससे जुड़े नोट्स और कमेंट्स के साथ क्या होता है?**  
[Notes](/slides/hi/php-java/presentation-notes/) और [comments](/slides/hi/php-java/presentation-comments/) उस विशिष्ट स्लाइड से जुड़े होते हैं और वह हटने पर साथ ही हट जाते हैं। अन्य स्लाइडों की सामग्री अपरिवर्तित रहती है।

**स्लाइड्स को हटाना और अप्रयुक्त लेआउट/मास्टर की सफाई में क्या अंतर है?**  
डिलीट करने से डेक से विशिष्ट सामान्य स्लाइड्स हटती हैं। अप्रयुक्त लेआउट/मास्टर को साफ करने से उन लेआउट या मास्टर स्लाइड्स को हटाया जाता है जिनका कोई भी रेफरेंस नहीं है, जिससे फ़ाइल आकार कम होता है बिना शेष स्लाइड सामग्री को बदले। ये क्रियाएँ आपस में पूरक हैं: आम तौर पर पहले डिलीट करें, फिर सफाई करें।