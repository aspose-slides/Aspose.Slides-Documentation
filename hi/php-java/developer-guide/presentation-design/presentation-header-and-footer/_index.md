---
title: PHP में प्रस्तुति हेडर और फ़ुटर प्रबंधित करें
linktitle: हेडर और फ़ुटर
type: docs
weight: 140
url: /hi/php-java/presentation-header-and-footer/
keywords:
- हेडर
- हेडर पाठ
- फ़ुटर
- फ़ुटर पाठ
- हेडर सेट करें
- फ़ुटर सेट करें
- हैंडआउट
- नोट्स
- PowerPoint
- OpenDocument
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java के साथ स्लाइड्स, नोट्स पेज और हैंडआउट्स पर फुटर, तिथि‑समय, स्लाइड‑नंबर और हेडर प्लेसहोल्डर को प्रबंधित करना सीखें।"
---
## **सारांश**

PowerPoint विभिन्न पृष्ठ प्रकारों के आधार पर अलग-अलग हेडर और फुटर प्लेसहोल्डर का उपयोग करता है। Aspose.Slides for PHP via Java आपको इन प्लेसहोल्डर के पाठ और दृश्यता को हेडर/फुटर मैनेजर क्लासों के माध्यम से नियंत्रित करने की सुविधा देता है।

उपलब्ध प्लेसहोल्डर स्कोप पर निर्भर करते हैं:

| स्कोप | हेडर | फुटर | तिथि/समय | स्लाइड/पेज संख्या |
|---|---|---|---|---|
| साधारण स्लाइड | नहीं | हाँ | हाँ | हाँ |
| नोट्स मास्टर | हाँ | हाँ | हाँ | हाँ |
| नोट्स स्लाइड | हाँ | हाँ | हाँ | हाँ |
| हैंडआउट मास्टर | हाँ | हाँ | हाँ | हाँ |

एक सामान्य प्रस्तुति स्लाइड में हेडर प्लेसहोल्डर नहीं होता है। हेडर नोट्स पृष्ठों और हैंडआउट्स में उपलब्ध होते हैं। सामान्य स्लाइड्स के लिए, फुटर, तिथि/समय, और स्लाइड-नंबर प्लेसहोल्डर का उपयोग करें।

परिवर्तन का स्कोप उस मैनेजर पर निर्भर करता है जिसका आप उपयोग करते हैं। [`SlideHeaderFooterManager`](https://reference.aspose.com/slides/hi/php-java/aspose.slides/slideheaderfootermanager/) क्लास एक सामान्य स्लाइड को नियंत्रित करती है। [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/hi/php-java/aspose.slides/notesslideheaderfootermanager/) क्लास एक नोट्स स्लाइड को नियंत्रित करती है। मास्टर और लेआउट मैनेजर्स भी सेटिंग्स को निर्भर स्लाइड्स तक पहुँचाने में सक्षम होते हैं, जबकि [`MasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/hi/php-java/aspose.slides/masterhandoutslideheaderfootermanager/) क्लास हैंडआउट मास्टर को नियंत्रित करती है।

## **सामान्य स्लाइड्स पर फुटर, तिथि/समय और स्लाइड नंबर सेट करें**

सामान्य स्लाइड्स के लिए, बुनियादी कार्य‑प्रवाह यह है कि प्रत्येक स्लाइड के हेडर/फुटर मैनेजर तक पहुँचें, फुटर और तिथि/समय का पाठ सेट करें, आवश्यक प्लेसहोल्डर को सक्षम करें, और प्रस्तुति को सहेजें। स्लाइड नंबर प्रस्तुति द्वारा उत्पन्न होते हैं, इसलिए आपको केवल उनकी दृश्यता को नियंत्रित करने की आवश्यकता है।

[`setFooterText`](https://reference.aspose.com/slides/hi/php-java/aspose.slides/baseslideheaderfootermanager/setfootertext/) और [`setDateTimeText`](https://reference.aspose.com/slides/hi/php-java/aspose.slides/baseslideheaderfootermanager/setdatetimetext/) का उपयोग करके पाठ सेट करें, और [`setFooterVisibility`](https://reference.aspose.com/slides/hi/php-java/aspose.slides/baseslideheaderfootermanager/setfootervisibility/), [`setDateTimeVisibility`](https://reference.aspose.com/slides/hi/php-java/aspose.slides/baseslideheaderfootermanager/setdatetimevisibility/), तथा [`setSlideNumberVisibility`](https://reference.aspose.com/slides/hi/php-java/aspose.slides/baseslideheaderfootermanager/setslidenumbervisibility/) का उपयोग करके संबंधित प्लेसहोल्डर को दिखाएँ।

निम्नलिखित end‑to‑end उदाहरण सभी सामान्य स्लाइड्स पर एक ही फुटर, तिथि/समय पाठ और स्लाइड‑नंबर दृश्यता लागू करता है:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    foreach ($presentation->getSlides() as $slide) {
        $headerFooterManager = $slide->getHeaderFooterManager();

        $headerFooterManager->setFooterText("Company Confidential");
        $headerFooterManager->setFooterVisibility(true);

        $headerFooterManager->setDateTimeText("Date and time text");
        $headerFooterManager->setDateTimeVisibility(true);

        $headerFooterManager->setSlideNumberVisibility(true);
    }

    $presentation->save("presentation_with_slide_footers.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

यदि आपको केवल एक स्लाइड को अपडेट करना है, तो पूरी संग्रह को इटररेट करने के बजाय [`getSlides`](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/getslides/) मेथड के माध्यम से सीधे उस स्लाइड तक पहुँचें।

## **नोट्स मास्टर पर हेडर और फुटर सेट करें**

नोट्स मास्टर नोट्स पृष्ठों के लिए सामान्य फ़ॉर्मेटिंग और प्लेसहोल्डर व्यवहार को परिभाषित करता है। जब आप केवल नोट्स मास्टर को बदलना चाहते हैं, तो [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/hi/php-java/aspose.slides/masternotesslideheaderfootermanager/) क्लास का उपयोग करें।

निम्नलिखित उदाहरण नोट्स मास्टर पर हेडर, फुटर और तिथि/समय पाठ सेट करता है और उस मास्टर पर सभी समर्थित प्लेसहोल्डर को दृश्य बनाता है:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    $masterNotesSlide = $presentation->getMasterNotesSlideManager()->getMasterNotesSlide();

    if (!java_is_null($masterNotesSlide)) {
        $headerFooterManager = $masterNotesSlide->getHeaderFooterManager();

        $headerFooterManager->setHeaderText("Notes header");
        $headerFooterManager->setHeaderVisibility(true);

        $headerFooterManager->setFooterText("Notes footer");
        $headerFooterManager->setFooterVisibility(true);

        $headerFooterManager->setDateTimeText("Date and time text");
        $headerFooterManager->setDateTimeVisibility(true);

        $headerFooterManager->setSlideNumberVisibility(true);
    }

    $presentation->save("presentation_with_notes_master_footers.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

[`getMasterNotesSlide`](https://reference.aspose.com/slides/hi/php-java/aspose.slides/masternotesslidemanager/getmasternotesslide/) मेथड तब `null` लौटाता है जब प्रस्तुति में नोट्स मास्टर मौजूद नहीं होता।

## **नोट्स मास्टर सेटिंग्स को चाइल्ड नोट्स स्लाइड्स पर लागू करें**

एक नोट्स मास्टर अपने स्वयं के हेडर और फुटर सेटिंग्स को सभी निर्भर नोट्स स्लाइड्स पर लागू कर सकता है। जब समान सेटिंग्स को नोट्स पदानुक्रम में सभी स्तरों पर लागू करना हो, तो [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/hi/php-java/aspose.slides/masternotesslideheaderfootermanager/) पर समर्पित प्रोपेगेशन मेथड का उपयोग करें।

उदाहरण के लिए, [`setHeaderAndChildHeadersText`](https://reference.aspose.com/slides/hi/php-java/aspose.slides/masternotesslideheaderfootermanager/setheaderandchildheaderstext/) और [`setHeaderAndChildHeadersVisibility`](https://reference.aspose.com/slides/hi/php-java/aspose.slides/masternotesslideheaderfootermanager/setheaderandchildheadersvisibility/) नोट्स मास्टर हेडर और सभी चाइल्ड हेडर को अपडेट करते हैं। फुटर, तिथि/समय और स्लाइड नंबर के लिए भी समान मेथड उपलब्ध हैं।

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    $masterNotesSlide = $presentation->getMasterNotesSlideManager()->getMasterNotesSlide();

    if (!java_is_null($masterNotesSlide)) {
        $headerFooterManager = $masterNotesSlide->getHeaderFooterManager();

        $headerFooterManager->setHeaderAndChildHeadersText("Notes header");
        $headerFooterManager->setHeaderAndChildHeadersVisibility(true);

        $headerFooterManager->setFooterAndChildFootersText("Notes footer");
        $headerFooterManager->setFooterAndChildFootersVisibility(true);

        $headerFooterManager->setDateTimeAndChildDateTimesText("Date and time text");
        $headerFooterManager->setDateTimeAndChildDateTimesVisibility(true);

        $headerFooterManager->setSlideNumberAndChildSlideNumbersVisibility(true);
    }

    $presentation->save("presentation_with_child_notes_footers.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

ऊपर उपयोग किए गए प्रोपेगेशन मेथड हैं [`setFooterAndChildFootersText`](https://reference.aspose.com/slides/hi/php-java/aspose.slides/masternotesslideheaderfootermanager/setfooterandchildfooterstext/), [`setFooterAndChildFootersVisibility`](https://reference.aspose.com/slides/hi/php-java/aspose.slides/masternotesslideheaderfootermanager/setfooterandchildfootersvisibility/), [`setDateTimeAndChildDateTimesText`](https://reference.aspose.com/slides/hi/php-java/aspose.slides/masternotesslideheaderfootermanager/setdatetimeandchilddatetimestext/), [`setDateTimeAndChildDateTimesVisibility`](https://reference.aspose.com/slides/hi/php-java/aspose.slides/masternotesslideheaderfootermanager/setdatetimeandchilddatetimesvisibility/), तथा [`setSlideNumberAndChildSlideNumbersVisibility`](https://reference.aspose.com/slides/hi/php-java/aspose.slides/masternotesslideheaderfootermanager/setslidenumberandchildslidenumbersvisibility/)।

## **एक व्यक्तिगत नोट्स स्लाइड पर हेडर और फुटर सेट करें**

एक नोट्स स्लाइड एक विशिष्ट सामान्य स्लाइड से जुड़ी होती है। जब आप केवल उस नोट्स पृष्ठ को कस्टमाइज़ करना चाहते हैं, तो उसके [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/hi/php-java/aspose.slides/notesslideheaderfootermanager/) क्लास का उपयोग करें।

[`addNotesSlide`](https://reference.aspose.com/slides/hi/php-java/aspose.slides/notesslidemanager/addnotesslide/) मेथड वर्तमान स्लाइड के लिए नोट्स स्लाइड लौटाता है और यदि वह पहले से मौजूद नहीं है तो एक नई बनाता है। निम्नलिखित उदाहरण पहली प्रस्तुति स्लाइड से संबद्ध नोट्स पृष्ठ को कॉन्फ़िगर करता है:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $notesSlide = $slide->getNotesSlideManager()->addNotesSlide();
    $headerFooterManager = $notesSlide->getHeaderFooterManager();

    $headerFooterManager->setHeaderText("Header for the first notes page");
    $headerFooterManager->setHeaderVisibility(true);

    $headerFooterManager->setFooterText("Footer for the first notes page");
    $headerFooterManager->setFooterVisibility(true);

    $headerFooterManager->setDateTimeText("Date and time text");
    $headerFooterManager->setDateTimeVisibility(true);

    $headerFooterManager->setSlideNumberVisibility(true);

    $presentation->save("presentation_with_custom_notes_footers.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

यदि आप पहले नोट्स मास्टर से सेटिंग्स प्रोपेगेट करते हैं और फिर व्यक्तिगत नोट्स स्लाइड को बदलते हैं, तो बाद की प्रति‑स्लाइड सेटिंग्स आपको उस नोट्स पृष्ठ को स्वतंत्र रूप से कस्टमाइज़ करने देती हैं।

## **हैंडआउट मास्टर पर हेडर और फुटर सेट करें**

हैंडआउट पेज अपने हेडर, फुटर, तिथि/समय और पेज‑नंबर प्लेसहोल्डर के लिए हैंडआउट मास्टर का उपयोग करते हैं। नोट्स पृष्ठों के विपरीत, हैंडआउट सेटिंग्स व्यक्तिगत हैंडआउट स्लाइड्स के बजाय हैंडआउट मास्टर द्वारा प्रबंधित की जाती हैं।

[`getMasterHandoutSlide`](https://reference.aspose.com/slides/hi/php-java/aspose.slides/masterhandoutslidemanager/getmasterhandoutslide/) मेथड का उपयोग करके हैंडआउट मास्टर तक पहुँचें। यदि वह मौजूद नहीं है, तो डिफ़ॉल्ट हैंडआउट मास्टर बनाने के लिए [`setDefaultMasterHandoutSlide`](https://reference.aspose.com/slides/hi/php-java/aspose.slides/masterhandoutslidemanager/setdefaultmasterhandoutslide/) को कॉल करें।

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    $masterHandoutSlide = $presentation->getMasterHandoutSlideManager()->getMasterHandoutSlide();

    if (java_is_null($masterHandoutSlide)) {
        $masterHandoutSlide = $presentation->getMasterHandoutSlideManager()->setDefaultMasterHandoutSlide();
    }

    if (!java_is_null($masterHandoutSlide)) {
        $headerFooterManager = $masterHandoutSlide->getHeaderFooterManager();

        $headerFooterManager->setHeaderText("Handout header");
        $headerFooterManager->setHeaderVisibility(true);

        $headerFooterManager->setFooterText("Handout footer");
        $headerFooterManager->setFooterVisibility(true);

        $headerFooterManager->setDateTimeText("Date and time text");
        $headerFooterManager->setDateTimeVisibility(true);

        $headerFooterManager->setSlideNumberVisibility(true);
    }

    $presentation->save("presentation_with_handout_footers.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **स्कोप और विरासत को समझें**

वह हेडर/फुटर मैनेजर चुनें जो उस स्कोप से मेल खाता हो जिसे आप बदलना चाहते हैं:

- [`SlideHeaderFooterManager`](https://reference.aspose.com/slides/hi/php-java/aspose.slides/slideheaderfootermanager/) एक सामान्य स्लाइड के लिए फुटर, तिथि/समय और स्लाइड‑नंबर सेटिंग्स बदलता है।
- [`LayoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/hi/php-java/aspose.slides/layoutslideheaderfootermanager/) एक लेआउट स्लाइड को नियंत्रित करता है और समर्थित सेटिंग्स को निर्भर स्लाइड्स तक पहुँचाने में सक्षम है।
- [`MasterSlideHeaderFooterManager`](https://reference.aspose.com/slides/hi/php-java/aspose.slides/masterslideheaderfootermanager/) एक सामान्य स्लाइड मास्टर को नियंत्रित करता है और समर्थित सेटिंग्स को निर्भर स्लाइड्स तक पहुँचाने में सक्षम है।
- [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/hi/php-java/aspose.slides/masternotesslideheaderfootermanager/) नोट्स मास्टर को नियंत्रित करता है और सभी निर्भर नोट्स स्लाइड्स को सेटिंग्स प्रोपेगेट कर सकता है।
- [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/hi/php-java/aspose.slides/notesslideheaderfootermanager/) एक नोट्स स्लाइड को बदलता है और फुटर, तिथि/समय और स्लाइड नंबर के अलावा हेडर प्लेसहोल्डर भी समर्थन करता है।
- [`MasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/hi/php-java/aspose.slides/masterhandoutslideheaderfootermanager/) हैंडआउट मास्टर को बदलता है और सभी चार प्लेसहोल्डर प्रकारों का समर्थन करता है।

जब समान सेटिंग को उसकी पदानुक्रम के पूरे भाग में लागू करना हो, तो मास्टर या लेआउट से प्रोपेगेशन उपयोग करें। जब आपको एक पृष्ठ के लिए स्थानीय सेटिंग चाहिए, तो व्यक्तिगत स्लाइड या नोट्स‑स्लाइड मैनेजर का उपयोग करें।

## **FAQ**

**क्या मैं सामान्य स्लाइड में हेडर जोड़ सकता हूँ?**

नहीं। PowerPoint सामान्य स्लाइड्स के लिए हेडर प्लेसहोल्डर परिभाषित नहीं करता है। सामान्य स्लाइड्स पर, फुटर, तिथि/समय, और स्लाइड‑नंबर प्लेसहोल्डर का उपयोग करें। हेडर प्लेसहोल्डर नोट्स पृष्ठों और हैंडआउट्स पर उपलब्ध हैं।

**यदि फुटर, तिथि/समय या स्लाइड‑नंबर प्लेसहोल्डर दृश्य नहीं है तो क्या करें?**

संबंधित हेडर/फुटर मैनेजर का उपयोग करके उसकी दृश्यता की जाँच करें और आवश्यक होने पर उसे सक्षम करें। उदाहरण के लिए, [`isFooterVisible`](https://reference.aspose.com/slides/hi/php-java/aspose.slides/baseslideheaderfootermanager/isfootervisible/) बताता है कि फुटर प्लेसहोल्डर उपस्थित है या नहीं, और [`setFooterVisibility`](https://reference.aspose.com/slides/hi/php-java/aspose.slides/baseslideheaderfootermanager/setfootervisibility/) उसकी दृश्यता को बदलता है।

**मैं स्लाइड नंबरिंग को 1 से अलग मान से कैसे शुरू करूँ?**

प्रेजेंटेशन की [`setFirstSlideNumber`](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/setfirstslidenumber/) मेथड को कॉल करें। फिर स्लाइड‑नंबर प्लेसहोल्डर अपडेटेड क्रमांक क्रम का उपयोग करेंगे।

**PDF, इमेज या HTML में निर्यात करते समय हेडर और फुटर का क्या होता है?**

दृश्य हेडर और फुटर तत्व आउटपुट फ़ॉर्मेट में प्रस्तुति सामग्री के साथ रेंडर होते हैं। उनका दिखना निर्यात किए जा रहे पृष्ठ प्रकार और संबंधित प्लेसहोल्डर दृश्यता सेटिंग्स पर निर्भर करता है।