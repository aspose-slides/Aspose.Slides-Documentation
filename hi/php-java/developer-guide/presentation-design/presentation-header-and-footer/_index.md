---
title: PHP में प्रस्तुति हेडर और फूटर प्रबंधित करें
linktitle: हेडर और फूटर
type: docs
weight: 140
url: /hi/php-java/presentation-header-and-footer/
keywords:
- हेडर
- हेडर टेक्स्ट
- फूटर
- फूटर टेक्स्ट
- हेडर सेट करें
- फूटर सेट करें
- हैंडआउट
- नोट्स
- PowerPoint
- OpenDocument
- प्रस्तुति
- PHP
- Aspose.Slides
description: "PowerPoint और OpenDocument प्रस्तुतियों में पेशेवर लुक के लिए Aspose.Slides for PHP via Java का उपयोग करके हेडर और फूटर जोड़ें और अनुकूलित करें।"
---
## **अवलोकन**

Aspose.Slides आपको PowerPoint प्रस्तुतियों में हेडर और फूटर सेटिंग्स को प्रबंधित करने की सुविधा देता है। हेडर और फूटर प्रस्तुति मास्टर स्तर पर संभाले जाते हैं, और API फ़ूटर टेक्स्ट सेट करने, फ़ूटर दृश्यता बदलने, तथा मास्टर नोट्स स्लाइड पर हेडर टेक्स्ट अपडेट करने के लिए मेथड प्रदान करता है।

आप हैंडआउट और नोट्स स्लाइड के लिए भी हेडर और फूटर प्रबंधित कर सकते हैं। इसमें नोट्स मास्टर, सभी चाइल्ड नोट्स स्लाइड या व्यक्तिगत नोट्स स्लाइड के लिए हेडर, फूटर, स्लाइड नंबर, और तारीख‑समय प्लेसहोल्डर्स की दृश्यता और टेक्स्ट बदलना शामिल है।

## **प्रस्तुति में हेडर और फूटर प्रबंधित करें**

कुछ विशिष्ट स्लाइड के नोट्स को नीचे दिखाए गए उदाहरण की तरह हटाया जा सकता है:

```php
  # प्रस्तुति लोड करें
  $pres = new Presentation("headerTest.pptx");
  try {
    # फ़ूटर सेट करना
    $pres->getHeaderFooterManager()->setAllFootersText("My Footer text");
    $pres->getHeaderFooterManager()->setAllFootersVisibility(true);
    # हेडर तक पहुँचें और अद्यतन करें
    $masterNotesSlide = $pres->getMasterNotesSlideManager()->getMasterNotesSlide();
    if (null != $masterNotesSlide) {
      updateHeaderFooterText($masterNotesSlide);
    }
    # प्रस्तुति सहेजें
    $pres->save("HeaderFooterJava.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
```php

```

## **हैंडआउट और नोट्स स्लाइड पर हेडर और फूटर प्रबंधित करें**
Aspose.Slides for PHP via Java Handout और नोट्स स्लाइड में Header और Footer को समर्थन देता है। कृपया नीचे दिए गए चरणों का पालन करें:

- एक [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/Presentation) लोड करें जिसमें वीडियो हो।
- नोट्स मास्टर और सभी नोट्स स्लाइड के लिए Header और Footer सेटिंग्स बदलें।
- मास्टर नोट्स स्लाइड और सभी चाइल्ड फ़ूटर प्लेसहोल्डर्स को दृश्य रखें।
- मास्टर नोट्स स्लाइड और सभी चाइल्ड तारीख और समय प्लेसहोल्डर्स को दृश्य रखें।
- केवल पहली नोट्स स्लाइड के लिए Header और Footer सेटिंग्स बदलें।
- नोट्स स्लाइड का Header प्लेसहोल्डर दृश्य रखें।
- नोट्स स्लाइड Header प्लेसहोल्डर में टेक्स्ट सेट करें।
- नोट्स स्लाइड तारीख‑समय प्लेसहोल्डर में टेक्स्ट सेट करें।
- संशोधित प्रस्तुति फ़ाइल लिखें।

नीचे दिए गए उदाहरण में कोड स्निपेट उपलब्ध है।

```php
  $pres = new Presentation("presentation.pptx");
  try {
    # नोट्स मास्टर और सभी नोट्स स्लाइड के लिए हेडर और फूटर सेटिंग्स बदलें
    $masterNotesSlide = $pres->getMasterNotesSlideManager()->getMasterNotesSlide();
    if (!java_is_null($masterNotesSlide)) {
      $headerFooterManager = $masterNotesSlide->getHeaderFooterManager();
      $headerFooterManager->setHeaderAndChildHeadersVisibility(true);// मास्टर नोट्स स्लाइड और सभी चाइल्ड फ़ूटर प्लेसहोल्डर्स को दृश्यमान बनाएं

      $headerFooterManager->setFooterAndChildFootersVisibility(true);// मास्टर नोट्स स्लाइड और सभी चाइल्ड हेडर प्लेसहोल्डर्स को दृश्यमान बनाएं

      $headerFooterManager->setSlideNumberAndChildSlideNumbersVisibility(true);// मास्टर नोट्स स्लाइड और सभी चाइल्ड स्लाइड नंबर प्लेसहोल्डर्स को दृश्यमान बनाएं

      $headerFooterManager->setDateTimeAndChildDateTimesVisibility(true);// मास्टर नोट्स स्लाइड और सभी चाइल्ड डेट और टाइम प्लेसहोल्डर्स को दृश्यमान बनाएं

      $headerFooterManager->setHeaderAndChildHeadersText("Header text");// मास्टर नोट्स स्लाइड और सभी चाइल्ड हेडर प्लेसहोल्डर्स में टेक्स्ट सेट करें

      $headerFooterManager->setFooterAndChildFootersText("Footer text");// मास्टर नोट्स स्लाइड और सभी चाइल्ड फ़ूटर प्लेसहोल्डर्स में टेक्स्ट सेट करें

      $headerFooterManager->setDateTimeAndChildDateTimesText("Date and time text");// मास्टर नोट्स स्लाइड और सभी चाइल्ड डेट और टाइम प्लेसहोल्डर्स में टेक्स्ट सेट करें

    }
    # केवल पहली नोट्स स्लाइड के लिए हेडर और फ़ूटर सेटिंग्स बदलें
    $notesSlide = $pres->getSlides()->get_Item(0)->getNotesSlideManager()->getNotesSlide();
    if (!java_is_null($notesSlide)) {
      $headerFooterManager = $notesSlide->getHeaderFooterManager();
      if (!$headerFooterManager->isHeaderVisible()) {
        $headerFooterManager->setHeaderVisibility(true);
      }// इस नोट्स स्लाइड हेडर प्लेसहोल्डर को दृश्यमान बनाएं

      if (!$headerFooterManager->isFooterVisible()) {
        $headerFooterManager->setFooterVisibility(true);
      }// इस नोट्स स्लाइड फ़ूटर प्लेसहोल्डर को दृश्यमान बनाएं

      if (!$headerFooterManager->isSlideNumberVisible()) {
        $headerFooterManager->setSlideNumberVisibility(true);
      }// इस नोट्स स्लाइड स्लाइड नंबर प्लेसहोल्डर को दृश्यमान बनाएं

      if (!$headerFooterManager->isDateTimeVisible()) {
        $headerFooterManager->setDateTimeVisibility(true);
      }// इस नोट्स स्लाइड डेट-टाइम प्लेसहोल्डर को दृश्यमान बनाएं

      $headerFooterManager->setHeaderText("New header text");// नोट्स स्लाइड हेडर प्लेसहोल्डर में टेक्स्ट सेट करें

      $headerFooterManager->setFooterText("New footer text");// नोट्स स्लाइड फ़ूटर प्लेसहोल्डर में टेक्स्ट सेट करें

      $headerFooterManager->setDateTimeText("New date and time text");// नोट्स स्लाइड डेट-टाइम प्लेसहोल्डर में टेक्स्ट सेट करें

    }
    $pres->save("testresult.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं सामान्य स्लाइड में “हेडर” जोड़ सकता हूँ?**

PowerPoint में “हेडर” केवल नोट्स और हैंडआउट के लिए मौजूद होता है; सामान्य स्लाइड में समर्थित तत्व फ़ूटर, तारीख/समय, और स्लाइड नंबर होते हैं। Aspose.Slides में भी यही सीमाएँ लागू होती हैं: हेडर केवल नोट्स/हैंडआउट के लिए, और स्लाइड में — फ़ूटर/DateTime/SlideNumber।

**यदि लेआउट में फ़ूटर क्षेत्र नहीं है तो क्या मैं उसकी दृश्यता “ऑन” कर सकता हूँ?**

हाँ। हेडर/फ़ूटर मैनेजर के माध्यम से दृश्यता जांचें और आवश्यक हो तो इसे सक्षम करें। ये API संकेतक और मेथड उन स्थितियों के लिए तैयार किए गए हैं जब प्लेसहोल्डर अनुपलब्ध या छिपा हुआ हो।

**मैं स्लाइड नंबर को 1 के बजाय किसी अन्य मान से कैसे शुरू करूँ?**

प्रस्तुति के [first slide number](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/setfirstslidenumber/) को सेट करें; इसके बाद सभी नंबरिंग पुनः गणना हो जाएगी। उदाहरण के लिए, आप इसे 0 या 10 से शुरू कर सकते हैं, और शीर्षक स्लाइड पर नंबर को छिपा भी सकते हैं।

**PDF/इमेज/HTML में निर्यात करते समय हेडर/फ़ूटर का क्या होता है?**

वे प्रस्तुति के सामान्य टेक्स्ट तत्वों की तरह रेंडर होते हैं। अर्थात, यदि ये तत्व स्लाइड/नोट्स पृष्ठों पर दृश्य हैं, तो वे आउटपुट फ़ॉर्मेट में भी अन्य सामग्री के साथ दिखाई देंगे।