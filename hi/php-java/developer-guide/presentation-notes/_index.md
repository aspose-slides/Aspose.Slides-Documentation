---
title: "PHP में प्रस्तुति नोट्स को प्रबंधित करें"
linktitle: "प्रस्तुति नोट्स"
type: docs
weight: 110
url: /hi/php-java/presentation-notes/
keywords:
- "नोट्स"
- "नोट स्लाइड"
- "नोट्स जोड़ें"
- "नोट्स हटाएँ"
- "नोट्स शैली"
- "मुख्य नोट्स"
- "PowerPoint"
- "OpenDocument"
- "प्रस्तुति"
- "PHP"
- "Aspose.Slides"
description: "Aspose.Slides for PHP via Java के साथ प्रस्तुति नोट्स को कस्टमाइज़ करें। PowerPoint और OpenDocument नोट्स के साथ सहजता से काम करें ताकि आपकी उत्पादकता बढ़े।"
---
## **अवलोकन**

Aspose.Slides प्रस्तुति से नोट स्लाइड्स को हटाने का समर्थन करता है। इस विषय में हम इस सुविधा को परिचित कराएँगे, जिसमें नोट्स को कैसे हटाएँ और प्रस्तुति में नोट स्लाइड्स पर शैली कैसे लागू करें शामिल है। Aspose.Slides आपको किसी भी स्लाइड से नोट्स हटाने और मौजूदा नोट्स पर शैली लागू करने की अनुमति देता है। डेवलपर्स निम्नलिखित तरीकों से नोट्स हटा सकते हैं:

- प्रस्तुति में किसी विशिष्ट स्लाइड से नोट्स हटाएँ।
- प्रस्तुति की सभी स्लाइड्स से नोट्स हटाएँ।

## **स्लाइड से नोट्स हटाएँ**
किसी विशेष स्लाइड के नोट्स को नीचे दर्शाए गए उदाहरण के अनुसार हटाया जा सकता है:

```php
  # प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाला Presentation ऑब्जेक्ट बनाएं
  $pres = new Presentation("presWithNotes.pptx");
  try {
    # पहली स्लाइड के नोट्स हटाएँ
    $mgr = $pres->getSlides()->get_Item(0)->getNotesSlideManager();
    $mgr->removeNotesSlide();
    # प्रस्तुति को डिस्क पर सहेजना
    $pres->save("test.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **प्रस्तुति से नोट्स हटाएँ**
प्रस्तुति की सभी स्लाइड्स के नोट्स को नीचे दर्शाए गए उदाहरण के अनुसार हटाया जा सकता है:

```php
  # प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाला Presentation ऑब्जेक्ट बनाएं
  $pres = new Presentation("presWithNotes.pptx");
  try {
    # सभी स्लाइड्स के नोट्स हटाएँ
    $mgr = null;
    for($i = 0; $i < java_values($pres->getSlides()->size()) ; $i++) {
      $mgr = $pres->getSlides()->get_Item($i)->getNotesSlideManager();
      $mgr->removeNotesSlide();
    }
    # प्रस्तुति को डिस्क पर सहेजना
    $pres->save("test.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **नोट्स शैली जोड़ें**
[getNotesStyle](https://reference.aspose.com/slides/hi/php-java/aspose.slides/MasterNotesSlide#getNotesStyle) मेथड को [MasterNotesSlide](https://reference.aspose.com/slides/hi/php-java/aspose.slides/MasterNotesSlide) क्लास में क्रमशः जोड़ा गया है। यह प्रॉपर्टी नोट्स टेक्स्ट की शैली निर्दिष्ट करती है। कार्यान्वयन नीचे दिए गए उदाहरण में दिखाया गया है।

```php
  # प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाला Presentation ऑब्जेक्ट बनाएं
  $pres = new Presentation("demo.pptx");
  try {
    $notesMaster = $pres->getMasterNotesSlideManager()->getMasterNotesSlide();
    if (!java_is_null($notesMaster)) {
      # MasterNotesSlide टेक्स्ट शैली प्राप्त करें
      $notesStyle = $notesMaster->getNotesStyle();
      # प्रथम स्तर के पैराग्राफ़ के लिए प्रतीक बुलेट सेट करें
      $paragraphFormat = $notesStyle->getLevel(0);
      $paragraphFormat::getBullet()->setType(BulletType::Symbol);
    }
    $pres->save("NotesSlideWithNotesStyle.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **अक्सर पूछे जाने वाले प्रश्न**

**कौन सा API एंटिटी एक विशिष्ट स्लाइड के नोट्स तक पहुँच प्रदान करता है?**

नोट्स स्लाइड के नोट्स मैनेजर के माध्यम से एक्सेस किए जाते हैं: स्लाइड में एक [NotesSlideManager](https://reference.aspose.com/slides/hi/php-java/aspose.slides/notesslidemanager/) और एक [method](https://reference.aspose.com/slides/hi/php-java/aspose.slides/notesslidemanager/getnotesslide/) होता है जो नोट्स ऑब्जेक्ट लौटाता है, या यदि कोई नोट नहीं है तो `null`।

**क्या लाइब्रेरी द्वारा समर्थित PowerPoint संस्करणों में नोट्स समर्थन में अंतर हैं?**

लाइब्रेरी Microsoft PowerPoint के विस्तृत रेंज (97–नया) और ODP प्रारूपों को लक्षित करती है; इन प्रारूपों में नोट्स का समर्थन किया जाता है, चाहे PowerPoint की इंस्टॉल की गई प्रति मौजूद हो या न हो।