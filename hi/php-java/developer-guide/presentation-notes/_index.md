---
title: PHP में प्रस्तुति नोट्स प्रबंधन
linktitle: प्रस्तुति नोट्स
type: docs
weight: 110
url: /hi/php-java/presentation-notes/
keywords:
- नोट्स
- नोट्स स्लाइड
- नोट्स जोड़ें
- नोट्स हटाएँ
- नोट्स शैली
- मास्टर नोट्स
- पावरपॉइंट
- ओपनडॉक्यूमेंट
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java के साथ प्रस्तुति नोट्स को कस्टमाइज़ करें। पावरपॉइंट और ओपनडॉक्यूमेंट नोट्स के साथ सहजता से काम करके अपनी उत्पादकता बढ़ाएँ।"
---
## **अवलोकन**

Aspose.Slides प्रस्तुति से नोट स्लाइड्स हटाने का समर्थन करता है। इस विषय में, हम इस सुविधा की जानकारी देंगे, जिसमें नोट्स को कैसे हटाएँ और प्रस्तुति में नोट स्लाइड्स पर शैली कैसे लागू करें शामिल है। Aspose.Slides आपको किसी भी स्लाइड से नोट्स हटाने और मौजूदा नोट्स पर शैली लागू करने की अनुमति देता है। डेवलपर्स निम्नलिखित तरीकों से नोट्स हटा सकते हैं:

- प्रस्तुति में किसी विशिष्ट स्लाइड से नोट्स हटाएँ।
- प्रस्तुति की सभी स्लाइड्स से नोट्स हटाएँ।

नोट पृष्ठ आकार पढ़ने या बदलने, अभिविन्यास स्विच करने, और निर्यात व्यवहार जांचने के लिए, देखें [नोट पृष्ठ आकार](/slides/hi/php-java/notes-size/)।

## **स्लाइड से नोट्स हटाएँ**
एक विशिष्ट स्लाइड से नोट्स नीचे दिखाए गए उदाहरण के अनुसार हटाए जा सकते हैं:

```php
  # एक Presentation ऑब्जेक्ट बनाएं जो प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है
  $pres = new Presentation("presWithNotes.pptx");
  try {
    # पहली स्लाइड के नोट्स हटाना
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
प्रस्तुति की सभी स्लाइड्स से नोट्स नीचे दिखाए गए उदाहरण में हटाए जा सकते हैं:

```php
  # एक Presentation ऑब्जेक्ट बनाएं जो प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है
  $pres = new Presentation("presWithNotes.pptx");
  try {
    # सभी स्लाइडों के नोट्स हटाना
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

## **एक नोट शैली जोड़ें**
[getNotesStyle](https://reference.aspose.com/slides/hi/php-java/aspose.slides/MasterNotesSlide#getNotesStyle) मेथड, जो [MasterNotesSlide](https://reference.aspose.com/slides/hi/php-java/aspose.slides/MasterNotesSlide) क्लास का हिस्सा है, नोट्स के टेक्स्ट शैली तक पहुँच प्रदान करता है। कार्यान्वयन नीचे दिखाए गए उदाहरण में प्रदर्शित किया गया है।

```php
  # एक Presentation ऑब्जेक्ट बनाएं जो प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है
  $pres = new Presentation("demo.pptx");
  try {
    $notesMaster = $pres->getMasterNotesSlideManager()->getMasterNotesSlide();
    if (!java_is_null($notesMaster)) {
      # MasterNotesSlide टेक्स्ट शैली प्राप्त करें
      $notesStyle = $notesMaster->getNotesStyle();
      # पहले स्तर के पैराग्राफ़ के लिए प्रतीक बुलेट सेट करें
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

## **FAQ**

**कौन सा API एंटिटी विशिष्ट स्लाइड के नोट्स तक पहुँच प्रदान करता है?**

नोट्स स्लाइड के नोट्स मैनेजर के माध्यम से पहुँचा जाता है: स्लाइड में एक [NotesSlideManager](https://reference.aspose.com/slides/hi/php-java/aspose.slides/notesslidemanager/) और एक [method](https://reference.aspose.com/slides/hi/php-java/aspose.slides/notesslidemanager/getnotesslide/) है जो नोट्स ऑब्जेक्ट लौटाता है, या यदि नोट्स नहीं हैं तो `null` देता है।

**क्या लाइब्रेरी द्वारा समर्थित PowerPoint संस्करणों में नोट्स समर्थन में अंतर होते हैं?**

लाइब्रेरी Microsoft PowerPoint फ़ॉर्मैट (97–नया) और ODP की एक विस्तृत रेंज को लक्षित करती है; इन फ़ॉर्मैट्स में नोट्स का समर्थन होता है और यह PowerPoint की इंस्टॉल की गई प्रतिलिपि पर निर्भर नहीं करता।