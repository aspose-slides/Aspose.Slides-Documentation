---
title: जावास्क्रिप्ट में प्रस्तुति हेडर और फ़ूटर प्रबंधित करें
linktitle: हेडर और फ़ूटर
type: docs
weight: 140
url: /hi/nodejs-java/presentation-header-and-footer/
keywords:
- हेडर
- हेडर टेक्स्ट
- फ़ूटर
- फ़ूटर टेक्स्ट
- हेडर सेट करें
- फ़ूटर सेट करें
- हैंडआउट
- नोट्स
- PowerPoint
- OpenDocument
- प्रस्तुति
- Node.js
- जावास्क्रिप्ट
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java के साथ स्लाइड्स, नोट्स पेज और हैंडआउट्स में फ़ूटर, तारीख‑समय, स्लाइड‑नंबर और हेडर प्लेसहोल्डर कैसे प्रबंधित करें, सीखें।"
---
## **सारांश**

PowerPoint पृष्ठ प्रकार के आधार पर विभिन्न हैडर और फ़ूटर प्लेसहोल्डर का उपयोग करता है। Aspose.Slides for Node.js via Java आपको इन प्लेसहोल्डर के पाठ और दृश्यता को हैडर/फ़ूटर मैनेजर क्लासों के माध्यम से नियंत्रित करने की अनुमति देता है।

उपलब्ध प्लेसहोल्डर परिधि पर निर्भर करते हैं:

| परिधि | हैडर | फ़ूटर | तारीख/समय | स्लाइड/पेज संख्या |
|---|---|---|---|---|
| सामान्य स्लाइड | नहीं | हाँ | हाँ | हाँ |
| नोट्स मास्टर | हाँ | हाँ | हाँ | हाँ |
| नोट्स स्लाइड | हाँ | हाँ | हाँ | हाँ |
| हैंडआउट मास्टर | हाँ | हाँ | हाँ | हाँ |

एक सामान्य प्रस्तुति स्लाइड में हैडर प्लेसहोल्डर नहीं होता। हैडर नोट्स पेज और हैंडआउट पर उपलब्ध होते हैं। सामान्य स्लाइड्स के लिए फ़ूटर, तारीख/समय, और स्लाइड-नंबर प्लेसहोल्डर का उपयोग करें।

परिवर्तन की परिधि उस मैनेजर पर निर्भर करती है जिसे आप उपयोग करते हैं। [`SlideHeaderFooterManager`](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/slideheaderfootermanager/) क्लास एक सामान्य स्लाइड को नियंत्रित करती है। [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/notesslideheaderfootermanager/) क्लास एक नोट्स स्लाइड को नियंत्रित करती है। मास्टर और लेआउट मैनेजर भी सेटिंग्स को निर्भर स्लाइड्स तक प्रसारित कर सकते हैं, जबकि [`MasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/masterhandoutslideheaderfootermanager/) क्लास हैंडआउट मास्टर को नियंत्रित करती है।

## **सामान्य स्लाइड्स पर फ़ूटर, तारीख/समय, और स्लाइड नंबर सेट करें**

सामान्य स्लाइड्स के लिए बुनियादी कार्यप्रवाह यह है कि प्रत्येक स्लाइड के हैडर/फ़ूटर मैनेजर तक पहुँचें, फ़ूटर और तारीख/समय का पाठ सेट करें, आवश्यक प्लेसहोल्डर को सक्षम करें, और प्रस्तुति को सहेजें। स्लाइड नंबर प्रस्तुति द्वारा उत्पन्न होते हैं, इसलिए आपको केवल उनकी दृश्यता नियंत्रित करनी होती है।

पाठ सेट करने के लिए [`setFooterText`](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/baseslideheaderfootermanager/#setFooterText) और [`setDateTimeText`](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/baseslideheaderfootermanager/#setDateTimeText) का उपयोग करें, तथा संबंधित प्लेसहोल्डर दिखाने के लिए [`setFooterVisibility`](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/baseslideheaderfootermanager/#setFooterVisibility), [`setDateTimeVisibility`](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/baseslideheaderfootermanager/#setDateTimeVisibility), और [`setSlideNumberVisibility`](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/baseslideheaderfootermanager/#setSlideNumberVisibility) का उपयोग करें।

निम्नलिखित अंत‑से‑अंत उदाहरण सभी सामान्य स्लाइड्स पर समान फ़ूटर, तारीख/समय पाठ, और स्लाइड‑नंबर दृश्यता लागू करता है:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        const slide = presentation.getSlides().get_Item(i);
        const headerFooterManager = slide.getHeaderFooterManager();

        headerFooterManager.setFooterText("Company Confidential");
        headerFooterManager.setFooterVisibility(true);

        headerFooterManager.setDateTimeText("Date and time text");
        headerFooterManager.setDateTimeVisibility(true);

        headerFooterManager.setSlideNumberVisibility(true);
    }

    presentation.save("presentation_with_slide_footers.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

यदि आपको केवल एक स्लाइड को अपडेट करना है, तो पूरे संग्रह को इटरित करने के बजाय [`getSlides`](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/getslides/) मेथड के द्वारा सीधे उस स्लाइड तक पहुँचें।

## **नोट्स मास्टर पर हैडर और फ़ूटर सेट करें**

नोट्स मास्टर नोट्स पेज के लिए सामान्य फॉर्मेटिंग और प्लेसहोल्डर व्यवहार को परिभाषित करता है। जब आप केवल नोट्स मास्टर को बदलना चाहते हैं, तो [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/) क्लास का उपयोग करें।

निम्न उदाहरण नोट्स मास्टर पर हैडर, फ़ूटर, और तारीख/समय पाठ सेट करता है और उस मास्टर पर सभी समर्थित प्लेसहोल्डर को दृश्य बनाता है:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    const masterNotesSlide = presentation.getMasterNotesSlideManager().getMasterNotesSlide();

    if (masterNotesSlide !== null) {
        const headerFooterManager = masterNotesSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderText("Notes header");
        headerFooterManager.setHeaderVisibility(true);

        headerFooterManager.setFooterText("Notes footer");
        headerFooterManager.setFooterVisibility(true);

        headerFooterManager.setDateTimeText("Date and time text");
        headerFooterManager.setDateTimeVisibility(true);

        headerFooterManager.setSlideNumberVisibility(true);
    }

    presentation.save("presentation_with_notes_master_footers.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[`getMasterNotesSlide`](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/masternotesslidemanager/#getMasterNotesSlide) मेथड तब `null` लौटाता है जब प्रस्तुति में नोट्स मास्टर मौजूद नहीं होता।

## **नोट्स मास्टर सेटिंग्स को चाइल्ड नोट्स स्लाइड्स पर लागू करें**

एक नोट्स मास्टर हैडर और फ़ूटर सेटिंग्स को स्वयं तथा सभी निर्भर नोट्स स्लाइड्स पर लागू कर सकता है। जब समान सेटिंग्स नोट्स पदानुक्रम के सभी स्तरों पर लागू करनी हों, तो [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/) पर समर्पित प्रसार मेथड का उपयोग करें।

उदाहरण के लिए, [`setHeaderAndChildHeadersText`](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setHeaderAndChildHeadersText) और [`setHeaderAndChildHeadersVisibility`](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setHeaderAndChildHeadersVisibility) नोट्स मास्टर हैडर और सभी चाइल्ड हैडर को अपडेट करते हैं। फ़ूटर, तारीख/समय, और स्लाइड नंबर के लिए समान मेथड उपलब्ध हैं।

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    const masterNotesSlide = presentation.getMasterNotesSlideManager().getMasterNotesSlide();

    if (masterNotesSlide !== null) {
        const headerFooterManager = masterNotesSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderAndChildHeadersText("Notes header");
        headerFooterManager.setHeaderAndChildHeadersVisibility(true);

        headerFooterManager.setFooterAndChildFootersText("Notes footer");
        headerFooterManager.setFooterAndChildFootersVisibility(true);

        headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");
        headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);

        headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);
    }

    presentation.save("presentation_with_child_notes_footers.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ऊपर उपयोग किए गए प्रसार मेथड हैं [`setFooterAndChildFootersText`](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setFooterAndChildFootersText), [`setFooterAndChildFootersVisibility`](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setFooterAndChildFootersVisibility), [`setDateTimeAndChildDateTimesText`](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesText), [`setDateTimeAndChildDateTimesVisibility`](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesVisibility), और [`setSlideNumberAndChildSlideNumbersVisibility`](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setSlideNumberAndChildSlideNumbersVisibility)।

## **एक व्यक्तिगत नोट्स स्लाइड पर हैडर और फ़ूटर सेट करें**

एक नोट्स स्लाइड एक विशिष्ट सामान्य स्लाइड से संबंधित होती है। जब आप केवल उस नोट्स पेज को अनुकूलित करना चाहते हैं, तो उसके [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/notesslideheaderfootermanager/) क्लास का उपयोग करें।

[`addNotesSlide`](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/notesslidemanager/#addNotesSlide) मेथड वर्तमान स्लाइड के लिए नोट्स स्लाइड लौटाता है और यदि वह पहले से मौजूद नहीं है तो एक नया बनाता है। निम्न उदाहरण प्रथम प्रस्तुति स्लाइड से संबद्ध नोट्स पेज को कॉन्फ़िगर करता है:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const headerFooterManager = slide.getNotesSlideManager().addNotesSlide().getHeaderFooterManager();

    headerFooterManager.setHeaderText("Header for the first notes page");
    headerFooterManager.setHeaderVisibility(true);

    headerFooterManager.setFooterText("Footer for the first notes page");
    headerFooterManager.setFooterVisibility(true);

    headerFooterManager.setDateTimeText("Date and time text");
    headerFooterManager.setDateTimeVisibility(true);

    headerFooterManager.setSlideNumberVisibility(true);

    presentation.save("presentation_with_custom_notes_footers.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

यदि आप पहले नोट्स मास्टर से सेटिंग्स प्रसारित करें और फिर एक व्यक्तिगत नोट्स स्लाइड बदलें, तो बाद की प्रति‑स्लाइड सेटिंग्स आपको उस नोट्स पेज को स्वतंत्र रूप से अनुकूलित करने की अनुमति देती हैं।

## **हैंडआउट मास्टर पर हैडर और फ़ूटर सेट करें**

हैंडआउट पेज अपने हैडर, फ़ूटर, तारीख/समय, और पेज‑नंबर प्लेसहोल्डर के लिए हैंडआउट मास्टर का उपयोग करता है। नोट्स पेज के विपरीत, हैंडआउट सेटिंग्स व्यक्तिगत हैंडआउट स्लाइड्स के बजाय हैंडआउट मास्टर के माध्यम से प्रबंधित की जाती हैं।

[`getMasterHandoutSlide`](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/masterhandoutslidemanager/#getMasterHandoutSlide) का उपयोग करके हैंडआउट मास्टर तक पहुँचें। यदि वह मौजूद नहीं है, तो डिफ़ॉल्ट हैंडआउट मास्टर बनाने के लिए [`setDefaultMasterHandoutSlide`](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/masterhandoutslidemanager/#setDefaultMasterHandoutSlide) को कॉल करें।

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    let masterHandoutSlide = presentation.getMasterHandoutSlideManager().getMasterHandoutSlide();

    if (masterHandoutSlide === null) {
        masterHandoutSlide = presentation.getMasterHandoutSlideManager().setDefaultMasterHandoutSlide();
    }

    if (masterHandoutSlide !== null) {
        const headerFooterManager = masterHandoutSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderText("Handout header");
        headerFooterManager.setHeaderVisibility(true);

        headerFooterManager.setFooterText("Handout footer");
        headerFooterManager.setFooterVisibility(true);

        headerFooterManager.setDateTimeText("Date and time text");
        headerFooterManager.setDateTimeVisibility(true);

        headerFooterManager.setSlideNumberVisibility(true);
    }

    presentation.save("presentation_with_handout_footers.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **परिधि और वारिसी को समझें**

उस हैडर/फ़ूटर मैनेजर को चुनें जो आप जिस परिधि को बदलना चाहते हैं, उसके साथ मेल खाता हो:

- [`SlideHeaderFooterManager`](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/slideheaderfootermanager/) एक सामान्य स्लाइड के फ़ूटर, तारीख/समय, और स्लाइड‑नंबर सेटिंग्स बदलता है।
- [`LayoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/layoutslideheaderfootermanager/) एक लेआउट स्लाइड को नियंत्रित करता है और समर्थित सेटिंग्स को निर्भर स्लाइड्स तक प्रसारित कर सकता है।
- [`MasterSlideHeaderFooterManager`](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/masterslideheaderfootermanager/) एक सामान्य स्लाइड मास्टर को नियंत्रित करता है और समर्थित सेटिंग्स को निर्भर स्लाइड्स तक प्रसारित कर सकता है।
- [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/) नोट्स मास्टर को नियंत्रित करता है और सभी निर्भर नोट्स स्लाइड्स तक सेटिंग्स प्रसारित कर सकता है।
- [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/notesslideheaderfootermanager/) एक नोट्स स्लाइड को बदलता है और फ़ूटर, तारीख/समय, स्लाइड नंबर के साथ एक हैडर प्लेसहोल्डर का समर्थन करता है।
- [`MasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/masterhandoutslideheaderfootermanager/) हैंडआउट मास्टर को बदलता है और चारों प्रकार के प्लेसहोल्डर को समर्थन देता है।

जब समान सेटिंग पूरे पदानुक्रम में लागू होनी हो, तो मास्टर या लेआउट से प्रसार करें। जब एक पेज के लिए स्थानीय सेटिंग आवश्यक हो, तो व्यक्तिगत स्लाइड या नोट्स‑स्लाइड मैनेजर का उपयोग करें।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं सामान्य स्लाइड पर हैडर जोड़ सकता हूँ?**

नहीं। PowerPoint सामान्य स्लाइड्स के लिए हैडर प्लेसहोल्डर निर्धारित नहीं करता। सामान्य स्लाइड्स पर फ़ूटर, तारीख/समय, और स्लाइड‑नंबर प्लेसहोल्डर का उपयोग करें। हैडर प्लेसहोल्डर नोट्स पेज और हैंडआउट पर उपलब्ध होते हैं।

**यदि फ़ूटर, तारीख/समय, या स्लाइड‑नंबर प्लेसहोल्डर दिखाई नहीं दे रहा है तो क्या करें?**

संबंधित हैडर/फ़ूटर मैनेजर का उपयोग करके उसकी दृश्यता जांचें और आवश्यक होने पर उसे सक्षम करें। उदाहरण के लिए, [`isFooterVisible`](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/baseslideheaderfootermanager/#isFooterVisible) दर्शाता है कि फ़ूटर प्लेसहोल्डर मौजूद है या नहीं, और [`setFooterVisibility`](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/baseslideheaderfootermanager/#setFooterVisibility) उसकी दृश्यता बदलता है।

**मैं स्लाइड नंबरिंग को 1 के अलावा किसी अन्य मान से कैसे शुरू करूँ?**

प्रेजेंटेशन के [`setFirstSlideNumber`](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/setfirstslidenumber/) मेथड को कॉल करें। तब स्लाइड‑नंबर प्लेसहोल्डर अपडेटेड क्रमांक अनुक्रम का उपयोग करेंगे।

**PDF, इमेज या HTML में निर्यात करते समय हैडर और फ़ूटर का क्या होता है?**

दृश्यमान हैडर और फ़ूटर तत्व आउटपुट फ़ॉर्मेट में प्रस्तुति की शेष सामग्री के साथ रेंडर होते हैं। उनका रूपांतरण निर्यात किए जा रहे पेज प्रकार और संबंधित प्लेसहोल्डर दृश्यता सेटिंग्स पर निर्भर करता है।