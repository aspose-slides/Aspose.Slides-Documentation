---
title: JavaScript में प्रस्तुति नोट्स को प्रबंधित करें
linktitle: प्रस्तुति नोट्स
type: docs
weight: 110
url: /hi/nodejs-java/presentation-notes/
keywords:
- नोट्स
- नोट्स स्लाइड
- नोट्स जोड़ें
- नोट्स हटाएँ
- नोट्स शैली
- मास्टर नोट्स
- PowerPoint
- OpenDocument
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js के साथ JavaScript में प्रस्तुति नोट्स को अनुकूलित करें। PowerPoint और OpenDocument नोट्स के साथ सहजता से काम करके अपनी उत्पादन क्षमता बढ़ाएँ।"
---
## **अवलोकन**

Aspose.Slides प्रस्तुतियों से नोट्स स्लाइड्स को हटाने का समर्थन करता है। इस विषय में, हम इस सुविधा को प्रस्तुत करेंगे, जिसमें नोट्स को कैसे हटाएँ और प्रस्तुति में नोट्स स्लाइड्स पर शैली कैसे लागू करें शामिल है। Aspose.Slides आपको किसी भी स्लाइड से नोट्स हटाने और मौजूदा नोट्स पर शैली लागू करने की अनुमति देता है। डेवलपर्स निम्नलिखित तरीकों से नोट्स हटा सकते हैं:

- एक प्रस्तुती में किसी विशिष्ट स्लाइड से नोट्स हटाएँ।
- एक प्रस्तुती में सभी स्लाइड्स से नोट्स हटाएँ।

नोट्स पेज की आयाम पढ़ने या बदलने, अभिविन्यास स्विच करने और निर्यात व्यवहार जांचने के लिए, देखें [Notes Page Size](/slides/hi/nodejs-java/notes-size/).

## **स्लाइड से नोट्स हटाएँ**
एक विशिष्ट स्लाइड से नोट्स नीचे दिए गए उदाहरण में दिखाए अनुसार हटाए जा सकते हैं:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// एक Presentation ऑब्जेक्ट बनाएं जो एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है
var pres = new aspose.slides.Presentation("presWithNotes.pptx");
try {
    // पहली स्लाइड के नोट्स को हटाना
    var mgr = pres.getSlides().get_Item(0).getNotesSlideManager();
    mgr.removeNotesSlide();
    // प्रस्तुति को डिस्क पर सहेजना
    pres.save("test.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **प्रस्तुति से नोट्स हटाएँ**
एक प्रस्तुति में सभी स्लाइड्स से नोट्स नीचे दिए गए उदाहरण में दिखाए अनुसार हटाए जा सकते हैं:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// एक Presentation ऑब्जेक्ट बनाएं जो एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है
var pres = new aspose.slides.Presentation("presWithNotes.pptx");
try {
    // सभी स्लाइड्स के नोट्स को हटाना
    var mgr = null;
    for (var i = 0; i < pres.getSlides().size(); i++) {
        mgr = pres.getSlides().get_Item(i).getNotesSlideManager();
        mgr.removeNotesSlide();
    }
    // प्रस्तुति को डिस्क पर सहेजना
    pres.save("test.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **NotesStyle जोड़ें**
[getNotesStyle](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/MasterNotesSlide#getNotesStyle--) मेथड को [MasterNotesSlide](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/MasterNotesSlide) क्लास और [MasterNotesSlide](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/MasterNotesSlide) क्लास में क्रमशः जोड़ा गया है। यह प्रॉपर्टी नोट्स टेक्स्ट की शैली निर्दिष्ट करती है। कार्यान्वयन नीचे दिए गए उदाहरण में दर्शाया गया है।

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// एक Presentation ऑब्जेक्ट बनाएं जो एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है
var pres = new aspose.slides.Presentation("demo.pptx");
try {
    var notesMaster = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (notesMaster != null) {
        // MasterNotesSlide टेक्स्ट शैली प्राप्त करें
        var notesStyle = notesMaster.getNotesStyle();
        // पहले स्तर के पैराग्राफ़ के लिए सिम्बल बुलेट सेट करें
        var paragraphFormat = notesStyle.getLevel(0);
        paragraphFormat.getBullet().setType(java.newByte(aspose.slides.BulletType.Symbol));
    }
    pres.save("NotesSlideWithNotesStyle.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**कौन सा API एंटिटी विशिष्ट स्लाइड के नोट्स तक पहुँच प्रदान करता है?**

नोट्स स्लाइड के नोट्स मैनेजर के माध्यम से पहुँच योग्य होते हैं: स्लाइड में एक [NotesSlideManager](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/notesslidemanager/) और एक [method](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/notesslidemanager/getnotesslide/) होता है जो नोट्स ऑब्जेक्ट लौटाता है, या यदि नोट्स नहीं हैं तो `null`।

**क्या लाइब्रेरी द्वारा समर्थित PowerPoint संस्करणों में नोट्स समर्थन में अंतर है?**

लाइब्रेरी Microsoft PowerPoint फ़ॉर्मेट (97‑नया) और ODP की विस्तृत श्रृंखला को लक्षित करती है; इन फ़ॉर्मेट में नोट्स का समर्थन किया जाता है बिना किसी स्थापित PowerPoint कॉपी पर निर्भर किए।