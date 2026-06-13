---
title: जावा में प्रस्तुति नोट्स प्रबंधित करें
linktitle: प्रस्तुति नोट्स
type: docs
weight: 110
url: /hi/java/presentation-notes/
keywords:
- नोट्स
- नोट्स स्लाइड
- नोट्स जोड़ें
- नोट्स हटाएँ
- नोट्स शैली
- मुख्य नोट्स
- PowerPoint
- OpenDocument
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java के साथ प्रस्तुति नोट्स को अनुकूलित करें। PowerPoint और OpenDocument नोट्स के साथ सहजता से काम करके अपनी उत्पादकता को बढ़ाएँ।"
---
## **अवलोकन**

Aspose.Slides प्रस्तुति से नोट्स स्लाइड हटाने को समर्थन देता है। इस विषय में हम इस सुविधा का परिचय देंगे, जिसमें नोट्स को कैसे हटाया जाए और प्रस्तुति में नोट्स स्लाइड पर शैली कैसे लागू की जाए, शामिल है। Aspose.Slides आपको किसी भी स्लाइड से नोट्स हटाने और मौजूदा नोट्स पर स्टाइल लागू करने की अनुमति देता है। डेवलपर्स नोट्स को निम्नलिखित तरीकों से हटा सकते हैं:

- प्रस्तुति में एक विशिष्ट स्लाइड से नोट्स हटाएँ।
- प्रस्तुति में सभी स्लाइड्स से नोट्स हटाएँ।

## **स्लाइड से नोट्स हटाएँ**
कुछ विशेष स्लाइड के नोट्स नीचे दिए गए उदाहरण के अनुसार हटाए जा सकते हैं:

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

## **प्रेजेंटेशन से नोट्स हटाएँ**
प्रेजेंटेशन की सभी स्लाइड्स के नोट्स नीचे दिए गए उदाहरण के अनुसार हटाए जा सकते हैं:

```java
// एक Presentation ऑब्जेक्ट बनाएं जो प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है
Presentation pres = new Presentation("presWithNotes.pptx");
try {
    // सभी स्लाइड्स के नोट्स हटाना
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
[getNotesStyle](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IMasterNotesSlide#getNotesStyle--) मेथड को [IMasterNotesSlide](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IMasterNotesSlide) इंटरफ़ेस और [MasterNotesSlide](https://reference.aspose.com/slides/hi/java/com.aspose.slides/MasterNotesSlide) क्लास में क्रमशः जोड़ा गया है। यह प्रॉपर्टी नोट्स टेक्स्ट की शैली को निर्दिष्ट करती है। कार्यान्वयन नीचे दिए गए उदाहरण में दर्शाया गया है।

```java
// एक Presentation ऑब्जेक्ट बनाएं जो प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है
Presentation pres = new Presentation("demo.pptx");
try {
    IMasterNotesSlide notesMaster = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    
    if (notesMaster != null)
    {
        // MasterNotesSlide टेक्स्ट शैली प्राप्त करें
        ITextStyle notesStyle = notesMaster.getNotesStyle();
    
        //Set पहले स्तर के पैराग्राफ़ के लिए प्रतीक बुलेट
        IParagraphFormat paragraphFormat = notesStyle.getLevel(0);
        paragraphFormat.getBullet().setType(BulletType.Symbol);
    }
    pres.save("NotesSlideWithNotesStyle.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**कौन सा API एंटिटी विशेष स्लाइड के नोट्स तक पहुँच प्रदान करती है?**

नोट्स स्लाइड के नोट्स मैनेजर के माध्यम से पहुँचाए जाते हैं: स्लाइड के पास एक [NotesSlideManager](https://reference.aspose.com/slides/hi/java/com.aspose.slides/notesslidemanager/) और एक [method](https://reference.aspose.com/slides/hi/java/com.aspose.slides/notesslidemanager/#getNotesSlide--) है जो नोट्स ऑब्जेक्ट लौटाता है, या यदि कोई नोट्स न हों तो `null`।

**क्या लाइब्रेरी द्वारा समर्थित PowerPoint संस्करणों में नोट्स सपोर्ट में अंतर है?**

लाइब्रेरी माइक्रोसॉफ्ट PowerPoint के कई प्रारूपों (97–नई) और ODP को लक्षित करती है; इन प्रारूपों में नोट्स समर्थित होते हैं और इसे PowerPoint की स्थापित कॉपी पर निर्भर नहीं होना पड़ता।