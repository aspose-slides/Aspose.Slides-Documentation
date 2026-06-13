---
title: JavaScript में प्रेजेंटेशन नोट्स प्रबंधित करें
linktitle: प्रेजेंटेशन नोट्स
type: docs
weight: 110
url: /hi/nodejs-java/presentation-notes/
keywords:
- नोट्स
- नोट्स स्लाइड
- नोट्स जोड़ें
- नोट्स हटाएँ
- नोट्स शैली
- मुख्य नोट्स
- PowerPoint
- OpenDocument
- प्रेजेंटेशन
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js के साथ JavaScript में प्रेजेंटेशन नोट्स को कस्टमाइज़ करें। PowerPoint और OpenDocument नोट्स के साथ सहजता से काम करें और अपनी उत्पादकता बढ़ाएँ।"
---
## **अवलोकन**

Aspose.Slides प्रस्तुति से नोट्स स्लाइड हटाने का समर्थन करता है। इस विषय में हम इस सुविधा का परिचय देंगे, जिसमें नोट्स कैसे हटाएँ और प्रस्तुति में नोट्स स्लाइड पर शैली कैसे लागू करें शामिल है। Aspose.Slides आपको किसी भी स्लाइड से नोट्स हटाने और मौजूदा नोट्स पर शैली लागू करने की अनुमति देता है। डेवलपर्स निम्नलिखित तरीकों से नोट्स हटा सकते हैं:

- प्रस्तुति में किसी विशिष्ट स्लाइड से नोट्स हटाएँ।
- प्रस्तुति की सभी स्लाइड्स से नोट्स हटाएँ।

## **स्लाइड से नोट्स हटाएँ**
नीचे दिखाए गए उदाहरण की तरह किसी विशिष्ट स्लाइड के नोट्स हटाए जा सकते हैं:

```javascript
// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाला एक Presentation ऑब्जेक्ट बनाएं
var pres = new aspose.slides.Presentation("presWithNotes.pptx");
try {
    // पहली स्लाइड के नोट्स हटाना
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
नीचे दिखाए गए उदाहरण की तरह प्रस्तुति की सभी स्लाइड्स के नोट्स हटाए जा सकते हैं:

```javascript
// प्रेजेंटेशन फ़ाइल का प्रतिनिधित्व करने वाला एक Presentation ऑब्जेक्ट बनाएं
var pres = new aspose.slides.Presentation("presWithNotes.pptx");
try {
    // सभी स्लाइड्स के नोट्स हटाना
    var mgr = null;
    for (var i = 0; i < pres.getSlides().size(); i++) {
        mgr = pres.getSlides().get_Item(i).getNotesSlideManager();
        mgr.removeNotesSlide();
    }
    // प्रेजेंटेशन को डिस्क पर सहेजना
    pres.save("test.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **NotesStyle जोड़ें**
[getNotesStyle](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/MasterNotesSlide#getNotesStyle--) मेथड को [MasterNotesSlide](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/MasterNotesSlide) क्लास और [MasterNotesSlide](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/MasterNotesSlide) क्लास में क्रमशः जोड़ा गया है। यह प्रॉपर्टी नोट्स टेक्स्ट की शैली निर्धारित करती है। कार्यान्वयन नीचे उदाहरण में दर्शाया गया है।

```javascript
// प्रेजेंटेशन फ़ाइल का प्रतिनिधित्व करने वाला एक Presentation ऑब्जेक्ट बनाएं
var pres = new aspose.slides.Presentation("demo.pptx");
try {
    var notesMaster = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (notesMaster != null) {
        // MasterNotesSlide टेक्स्ट शैली प्राप्त करें
        var notesStyle = notesMaster.getNotesStyle();
        // पहले स्तर के पैराग्राफ़ों के लिए सिम्बॉल बुलेट सेट करें
        var paragraphFormat = notesStyle.getLevel(0);
        paragraphFormat.getBullet().setType(aspose.slides.BulletType.Symbol);
    }
    pres.save("NotesSlideWithNotesStyle.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**कौन सा API इकाई विशिष्ट स्लाइड के नोट्स तक पहुँच प्रदान करती है?**

नोट्स स्लाइड के नोट्स मैनेजर के माध्यम से एक्सेस किए जाते हैं: स्लाइड में एक [NotesSlideManager](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/notesslidemanager/) है और एक [method](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/notesslidemanager/getnotesslide/) जो नोट्स ऑब्जेक्ट लौटाता है, या यदि नोट्स नहीं हैं तो `null` लौटाता है।

**क्या लाइब्रेरी द्वारा समर्थन किए जाने वाले PowerPoint संस्करणों में नोट्स समर्थन के अंतर हैं?**

लाइब्रेरी Microsoft PowerPoint के विस्तृत रेंज (97–नया) और ODP फ़ॉर्मेट को लक्षित करती है; इन फ़ॉर्मेट्स में नोट्स समर्थन स्थापित PowerPoint की आवश्यकता के बिना उपलब्ध है।