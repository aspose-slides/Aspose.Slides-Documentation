---
title: Android पर प्रस्तुति नोट्स प्रबंधित करें
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
- मुख्य नोट्स
- PowerPoint
- OpenDocument
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android को Java के माध्यम से उपयोग करके प्रस्तुति नोट्स को अनुकूलित करें। PowerPoint और OpenDocument नोट्स के साथ सहजता से काम करें ताकि आपकी उत्पादकता बढ़े।"
---
## **सारांश**

Aspose.Slides प्रस्तुतियों से नोट्स स्लाइड को हटाने का समर्थन करता है। इस विषय में हम इस सुविधा का परिचय देंगे, जिसमें नोट्स को हटाने और प्रस्तुतियों में नोट्स स्लाइड पर स्टाइल लागू करने के तरीके शामिल हैं। Aspose.Slides आपको किसी भी स्लाइड से नोट्स हटाने और मौजूदा नोट्स पर स्टाइल लागू करने की अनुमति देता है। डेवलपर्स नीचे दिए गए तरीकों से नोट्स हटा सकते हैं:

- एक प्रस्तुति की विशिष्ट स्लाइड से नोट्स हटाएँ।
- एक प्रस्तुति की सभी स्लाइड्स से नोट्स हटाएँ।

नोट्स पेज के आयाम पढ़ने या बदलने, अभिविन्यास स्विच करने, और निर्यात व्यवहार जांचने के लिए, देखें [नोट्स पेज आकार](/slides/hi/androidjava/notes-size/)।

## **स्लाइड से नोट्स हटाना**
विशिष्ट स्लाइड से नोट्स नीचे दिए गए उदाहरण के अनुसार हटाए जा सकते हैं:

```java
import com.aspose.slides.*;

// एक Presentation ऑब्जेक्ट बनाता है जो एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है
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

## **प्रस्तुति से नोट्स हटाना**
प्रस्तुति की सभी स्लाइड्स से नोट्स नीचे दिए गए उदाहरण के अनुसार हटाए जा सकते हैं:

```java
import com.aspose.slides.*;

// एक Presentation ऑब्जेक्ट बनाता है जो प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है
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

## **नोट्स स्टाइल जोड़ें**
[getNotesStyle](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IMasterNotesSlide#getNotesStyle--) मेथड को [IMasterNotesSlide](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IMasterNotesSlide) इंटरफ़ेस और [MasterNotesSlide](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/MasterNotesSlide) क्लास में क्रमशः जोड़ा गया है। यह प्रॉपर्टी नोट्स टेक्स्ट की शैली निर्दिष्ट करती है। कार्यान्वयन नीचे दिए गए उदाहरण में दिखाया गया है।

```java
import com.aspose.slides.*;

// एक Presentation ऑब्जेक्ट बनाता है जो प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है
Presentation pres = new Presentation("demo.pptx");
try {
    IMasterNotesSlide notesMaster = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    
    if (notesMaster != null)
    {
        // MasterNotesSlide टेक्स्ट शैली प्राप्त करें
        ITextStyle notesStyle = notesMaster.getNotesStyle();
    
        //प्रतीक बुलेट पहले स्तर के पैराग्राफ़ों के लिए सेट करें
        IParagraphFormat paragraphFormat = notesStyle.getLevel(0);
        paragraphFormat.getBullet().setType(BulletType.Symbol);
    }
    pres.save("NotesSlideWithNotesStyle.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**कौन सा API इकाई विशिष्ट स्लाइड के नोट्स तक पहुँच प्रदान करती है?**

नोट्स स्लाइड के नोट्स मैनेजर के माध्यम से पहुँचा जाता है: स्लाइड में एक [NotesSlideManager](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/notesslidemanager/) और एक [method](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/notesslidemanager/#getNotesSlide--) है जो नोट्स ऑब्जेक्ट लौटाता है, या यदि कोई नोट्स नहीं हैं तो `null`।

**क्या लाइब्रेरी द्वारा समर्थित पावरपॉइंट संस्करणों में नोट्स समर्थन में अंतर है?**

यह लाइब्रेरी माइक्रोसॉफ्ट पावरपॉइंट के व्यापक रेंज (97‑नए संस्करण) और ODP फ़ॉर्मेट को लक्षित करती है; इन फ़ॉर्मेट में नोट्स समर्थित हैं और पावरपॉइंट की स्थापित कॉपी पर निर्भर नहीं होते।