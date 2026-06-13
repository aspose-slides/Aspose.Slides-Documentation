---
title: PHP में प्रस्तुति स्लाइड्स तक पहुंचें
linktitle: स्लाइड तक पहुंचें
type: docs
weight: 20
url: /hi/php-java/access-slide-in-presentation/
keywords:
- स्लाइड तक पहुंचें
- स्लाइड इंडेक्स
- स्लाइड आईडी
- स्लाइड स्थिति
- स्थिति बदलें
- स्लाइड गुण
- स्लाइड नंबर
- PowerPoint
- OpenDocument
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java के साथ PowerPoint और OpenDocument प्रस्तुतियों में स्लाइड्स तक पहुंचने और उनका प्रबंधन करना सीखें। कोड उदाहरणों से उत्पादकता बढ़ाएँ।"
---
## **सारांश**

यह लेख Aspose.Slides का उपयोग करके प्रस्तुति में स्लाइड्स तक पहुंचने और उनका प्रबंधन करने के तरीके को समझाता है। यह स्लाइड संग्रह से शून्य-आधारित अनुक्रमणिका द्वारा स्लाइड्स को पुनः प्राप्त करने और `getSlideById` मेथड का उपयोग करके किसी स्लाइड को उसके अद्वितीय आईडी द्वारा पहुंचने का तरीका दिखाता है।

आप `setSlideNumber` मेथड का उपयोग करके स्लाइड की स्थिति बदलना और `setFirstSlideNumber` मेथड के साथ प्रस्तुति के लिए प्रारंभिक स्लाइड नंबर निर्धारित करना भी सीखेंगे। उदाहरणों में प्रस्तुति लोड करना, स्लाइड संदर्भ प्राप्त करना, स्लाइड क्रम या क्रमांक को अपडेट करना, और संशोधित प्रस्तुति को सहेजना दर्शाया गया है।

## **इंडेक्स द्वारा स्लाइड तक पहुंचें**

एक प्रस्तुति में सभी स्लाइड्स को स्लाइड स्थिति के आधार पर संख्यात्मक रूप से व्यवस्थित किया जाता है और यह 0 से शुरू होती है। पहला स्लाइड इंडेक्स 0 के माध्यम से पहुँच सकता है; दूसरा स्लाइड इंडेक्स 1 के माध्यम से पहुँचता है; आदि।

Presentation क्लास, जो एक प्रस्तुति फ़ाइल को दर्शाता है, सभी स्लाइड्स को एक [SlideCollection](https://reference.aspose.com/slides/hi/php-java/aspose.slides/slidecollection/) संग्रह ([Slide](https://reference.aspose.com/slides/hi/php-java/aspose.slides/slide/) ऑब्जेक्ट्स का संग्रह) के रूप में उजागर करता है। यह PHP कोड आपको दिखाता है कि कैसे इंडेक्स के माध्यम से स्लाइड तक पहुंचा जाए:

```php
  # एक Presentation ऑब्जेक्ट बनाता है जो एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है
  $pres = new Presentation("demo.pptx");
  try {
    # स्लाइड को उसके स्लाइड इंडेक्स से एक्सेस करता है
    $slide = $pres->getSlides()->get_Item(0);
  } finally {
    $pres->dispose();
  }
```

## **आईडी द्वारा स्लाइड तक पहुंचें**

प्रस्तुति की प्रत्येक स्लाइड का एक अद्वितीय आईडी होता है। आप उस आईडी को लक्षित करने के लिए [getSlideById](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/#getSlideById-long-) मेथड (जो [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) क्लास द्वारा उपलब्ध कराया गया है) का उपयोग कर सकते हैं। यह PHP कोड आपको दिखाता है कि वैध स्लाइड आईडी कैसे प्रदान करें और [getSlideById](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/#getSlideById-long-) मेथड के माध्यम से उस स्लाइड तक कैसे पहुंचें:

```php
  # एक Presentation ऑब्जेक्ट बनाता है जो एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है
  $pres = new Presentation("demo.pptx");
  try {
    # एक स्लाइड आईडी प्राप्त करता है
    $id = $pres->getSlides()->get_Item(0)->getSlideId();
    # अपने आईडी के माध्यम से स्लाइड तक पहुंचता है
    $slide = $pres->getSlideById($id);
  } finally {
    $pres->dispose();
  }
```

## **स्लाइड स्थिति बदलें**

Aspose.Slides आपको स्लाइड की स्थिति बदलने की अनुमति देता है। उदाहरण के तौर पर, आप यह निर्दिष्ट कर सकते हैं कि पहला स्लाइड दूसरा स्लाइड बन जाए।

1. [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) क्लास की एक इंस्टेंस बनाएं।
1. इंडेक्स के माध्यम से स्लाइड का रेफ़रेंस प्राप्त करें (जिसकी स्थिति आप बदलना चाहते हैं)।
1. स्लाइड के लिए नई स्थिति सेट करने के लिए [setSlideNumber](https://reference.aspose.com/slides/hi/php-java/aspose.slides/slide/#setSlideNumber) मेथड का उपयोग करें।
1. संशोधित प्रस्तुति को सहेजें।

यह PHP कोड दर्शाता है कि स्थिति 1 में स्थित स्लाइड को स्थिति 2 पर कैसे ले जाया जाता है:

```php
  # एक Presentation ऑब्जेक्ट बनाता है जो एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है
  $pres = new Presentation("Presentation.pptx");
  try {
    # वह स्लाइड प्राप्त करता है जिसकी स्थिति बदलनी है
    $sld = $pres->getSlides()->get_Item(0);
    # स्लाइड के लिए नई स्थिति सेट करता है
    $sld->setSlideNumber(2);
    # परिवर्तित प्रस्तुति को सहेजता है
    $pres->save("helloworld_Pos.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

पहला स्लाइड दूसरा बन गया; दूसरा स्लाइड पहला बन गया। जब आप स्लाइड की स्थिति बदलते हैं, तो अन्य स्लाइड्स स्वचालित रूप से समायोजित हो जाती हैं।

## **स्लाइड नंबर सेट करें**

[setFirstSlideNumber](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/#setFirstSlideNumber-int-) मेथड (जो [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) क्लास द्वारा उपलब्ध कराया गया है) का उपयोग करके आप प्रस्तुति में पहले स्लाइड के लिए नया नंबर निर्दिष्ट कर सकते हैं। यह ऑपरेशन अन्य स्लाइड नंबरों को पुनः गणना करता है।

1. Presentation क्लास की एक इंस्टेंस बनाएं।
1. स्लाइड नंबर प्राप्त करें।
1. स्लाइड नंबर सेट करें।
1. संशोधित प्रस्तुति को सहेजें।

यह PHP कोड दर्शाता है कि पहला स्लाइड नंबर 10 पर कैसे सेट किया जाता है:

```php
  # एक Presentation ऑब्जेक्ट बनाता है जो एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है
  $pres = new Presentation("HelloWorld.pptx");
  try {
    # स्लाइड नंबर प्राप्त करता है
    $firstSlideNumber = $pres->getFirstSlideNumber();
    # स्लाइड नंबर सेट करता है
    $pres->setFirstSlideNumber(10);
    # परिवर्तित प्रस्तुति को सहेजता है
    $pres->save("Set_Slide_Number_out.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

यदि आप पहला स्लाइड स्किप करना चाहते हैं, तो आप नंबरिंग दूसरे स्लाइड से शुरू कर सकते हैं (और पहले स्लाइड के लिए नंबरिंग को छिपा सकते हैं) इस प्रकार:

```php
  $presentation = new Presentation();
  try {
    $layoutSlide = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);
    $presentation->getSlides()->addEmptySlide($layoutSlide);
    $presentation->getSlides()->addEmptySlide($layoutSlide);
    $presentation->getSlides()->addEmptySlide($layoutSlide);
    # पहले प्रस्तुति स्लाइड के लिए नंबर सेट करता है
    $presentation->setFirstSlideNumber(0);
    # सभी स्लाइड्स के लिए स्लाइड नंबर दिखाता है
    $presentation->getHeaderFooterManager()->setAllSlideNumbersVisibility(true);
    # पहले स्लाइड के लिए स्लाइड नंबर छिपाता है
    $presentation->getSlides()->get_Item(0)->getHeaderFooterManager()->setSlideNumberVisibility(false);
    # परिवर्तित प्रस्तुति को सहेजता है
    $presentation->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या उपयोगकर्ता द्वारा देखी गई स्लाइड संख्या संग्रह की शून्य-आधारित इंडेक्स के बराबर होती है?**

स्लाइड पर दिखाया गया नंबर मनमाने मान (जैसे 10) से शुरू हो सकता है और उसे इंडेक्स से मेल नहीं करना जरूरी है; यह संबंध प्रस्तुति के प्रथम स्लाइड नंबर सेटिंग द्वारा नियंत्रित होता है।

**क्या छिपी हुई स्लाइड्स इंडेक्सिंग को प्रभावित करती हैं?**

हाँ। एक छिपी हुई स्लाइड संग्रह में बनी रहती है और इंडेक्सिंग में गिनी जाती है; "छिपी" स्थिति केवल प्रदर्शित होने से संबंधित है, न कि संग्रह में उसकी स्थिति से।

**क्या अन्य स्लाइड्स जोड़ने या हटाने पर स्लाइड का इंडेक्स बदलता है?**

हाँ। इंडेक्स हमेशा स्लाइड्स के वर्तमान क्रम को दर्शाते हैं और सम्मिलन, विलोपन और स्थानांतरण ऑपरेशनों के बाद पुनः गणना किए जाते हैं।