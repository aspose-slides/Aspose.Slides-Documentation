---
title: Android पर प्रस्तुति नोट्स का प्रबंधन
linktitle: प्रस्तुति नोट्स
type: docs
weight: 110
url: /hi/androidjava/presentation-notes/
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
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android द्वारा Java के माध्यम से प्रस्तुति नोट्स को अनुकूलित करें। PowerPoint और OpenDocument नोट्स के साथ सहजता से काम करें ताकि आपकी उत्पादकता बढ़े।"
---
## **अवलोकन**

Aspose.Slides प्रस्तुति से नोट्स स्लाइड हटाने का समर्थन करता है। इस विषय में हम इस सुविधा को प्रस्तुत करेंगे, जिसमें नोट्स को कैसे हटाएँ और प्रस्तुति में नोट्स स्लाइड पर शैली कैसे लागू करें शामिल है। Aspose.Slides आपको किसी भी स्लाइड से नोट्स हटाने और मौजूदा नोट्स पर शैली लागू करने की अनुमति देता है। डेवलपर्स निम्नलिखित तरीकों से नोट्स हटाए जा सकते हैं:

- एक प्रस्तुति में किसी विशिष्ट स्लाइड से नोट्स हटाएँ।
- एक प्रस्तुति की सभी स्लाइडों से नोट्स हटाएँ।

## **स्लाइड से नोट्स हटाएँ**
नोट्स को किसी विशिष्ट स्लाइड से नीचे दर्शाए गए उदाहरण के अनुसार हटाया जा सकता है:

```java
// एक Presentation ऑब्जेक्ट बनाएं जो प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है
Presentation pres = new Presentation("presWithNotes.pptx");
try {
    // पहली स्लाइड के नोट्स हटाना
    INotesSlideManager mgr = pres.getSlides().get_Item(0).getNotesSlideManager();
    mgr.removeNotesSlide();

    // प्रस्तुति को डिस्क पर सहेजना
    pres.save("test.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **प्रस्तुति से नोट्स हटाएँ**
प्रस्तुति की सभी स्लाइडों से नोट्स को नीचे दर्शाए गए उदाहरण के अनुसार हटाया जा सकता है:

```java
// एक Presentation ऑब्जेक्ट बनाएं जो प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है
Presentation pres = new Presentation("presWithNotes.pptx");
try {
    // सभी स्लाइडों के नोट्स हटाना
    INotesSlideManager mgr = null;
    for (int i = 0; i < pres.getSlides().size(); i++) {
        mgr = pres.getSlides().get_Item(i).getNotesSlideManager();
        mgr.removeNotesSlide();
    }
    
    // प्रस्तुति को डिस्क पर सहेजना
    pres.save("test.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **नोट्स शैली जोड़ें**
[getNotesStyle](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IMasterNotesSlide#getNotesStyle--) method को क्रमशः [IMasterNotesSlide](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IMasterNotesSlide) interface और [MasterNotesSlide](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/MasterNotesSlide) class में जोड़ा गया है। यह प्रॉपर्टी नोट्स टेक्स्ट की शैली को निर्दिष्ट करती है। नीचे दिए गए उदाहरण में कार्यान्वयन दिखाया गया है।

```java
// एक Presentation ऑब्जेक्ट बनाएं जो प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है
Presentation pres = new Presentation("demo.pptx");
try {
    IMasterNotesSlide notesMaster = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    
    if (notesMaster != null)
    {
        // MasterNotesSlide टेक्स्ट शैली प्राप्त करें
        ITextStyle notesStyle = notesMaster.getNotesStyle();
    
        //पहले स्तर के पैराग्राफ़ के लिए सिंबल बुलेट सेट करें
        IParagraphFormat paragraphFormat = notesStyle.getLevel(0);
        paragraphFormat.getBullet().setType(BulletType.Symbol);
    }
    pres.save("NotesSlideWithNotesStyle.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**कौन सा API इकाई विशिष्ट स्लाइड के नोट्स तक पहुंच प्रदान करती है?**

नोट्स स्लाइड के नोट्स मैनेजर के माध्यम से एक्सेस किए जाते हैं: स्लाइड के पास एक [NotesSlideManager](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/notesslidemanager/) है और एक [method](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/notesslidemanager/#getNotesSlide--) है जो नोट्स ऑब्जेक्ट लौटाता है, या `null` यदि कोई नोट्स नहीं हैं।

**क्या लाइब्रेरी द्वारा समर्थित PowerPoint संस्करणों में नोट्स समर्थन में अंतर है?**

लाइब्रेरी Microsoft PowerPoint फ़ॉर्मेट (97–नवीनतम) और ODP की व्यापक श्रृंखला को लक्षित करती है; इन फ़ॉर्मेट्स में नोट्स का समर्थन किया जाता है बिना किसी स्थापित PowerPoint कॉपी पर निर्भर हुए।