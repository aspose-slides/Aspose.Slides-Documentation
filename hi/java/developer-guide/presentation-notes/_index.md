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
- मास्टर नोट्स
- PowerPoint
- OpenDocument
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java के साथ प्रस्तुति नोट्स को अनुकूलित करें। PowerPoint और OpenDocument नोट्स के साथ सहजता से काम करके अपनी उत्पादकता बढ़ाएँ।"
---
## **अवलोकन**

Aspose.Slides एक प्रस्तुति से नोट्स स्लाइड को हटाने का समर्थन करता है। इस विषय में हम इस सुविधा को प्रस्तुत करेंगे, जिसमें नोट्स कैसे हटाए जाएँ और प्रस्तुति में नोट्स स्लाइड पर शैली कैसे लागू की जाए, शामिल हैं। Aspose.Slides आपको किसी भी स्लाइड से नोट्स हटाने और मौजूदा नोट्स पर स्टाइल लागू करने की अनुमति देता है। डेवलपर नीचे दिए गए तरीकों से नोट्स हटा सकते हैं:

- प्रस्तुति में किसी विशिष्ट स्लाइड से नोट्स हटाएँ।
- प्रस्तुति में सभी स्लाइडों से नोट्स हटाएँ।

नोट्स पेज आयाम पढ़ने या बदलने, अभिविन्यास स्विच करने, और निर्यात व्यवहार जांचने के लिए देखें [नोट्स पेज आकार](/slides/hi/java/notes-size/)।

## **नोट्स को स्लाइड से हटाएँ**
एक विशिष्ट स्लाइड से नोट्स को नीचे दिए गए उदाहरण के अनुसार हटाया जा सकता है:

```java
import com.aspose.slides.*;

// एक Presentation ऑब्जेक्ट बनाएं जो एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है
Presentation pres = new Presentation("presWithNotes.pptx");
try {
    // पहले स्लाइड के नोट्स हटाना
    INotesSlideManager mgr = pres.getSlides().get_Item(0).getNotesSlideManager();
    mgr.removeNotesSlide();

    // प्रेजेंटेशन को डिस्क पर सेव करना
    pres.save("test.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **प्रेजेंटेशन से नोट्स हटाएँ**
प्रेजेंटेशन में सभी स्लाइडों से नोट्स को नीचे दिए गए उदाहरण के अनुसार हटाया जा सकता है:

```java
import com.aspose.slides.*;

// एक Presentation ऑब्जेक्ट बनाएं जो एक प्रस्तुति फ़ाइल को दर्शाता है
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
[getNotesStyle](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IMasterNotesSlide#getNotesStyle--) मेथड को [IMasterNotesSlide](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IMasterNotesSlide) इंटरफ़ेस और [MasterNotesSlide](https://reference.aspose.com/slides/hi/java/com.aspose.slides/MasterNotesSlide) क्लास में क्रमशः जोड़ा गया है। यह प्रॉपर्टी नोट्स टेक्स्ट की शैली को निर्दिष्ट करती है। कार्यान्वयन नीचे दिए गए उदाहरण में प्रदर्शित है।

```java
import com.aspose.slides.*;

// एक Presentation ऑब्जेक्ट बनाएं जो एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है
Presentation pres = new Presentation("demo.pptx");
try {
    IMasterNotesSlide notesMaster = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    
    if (notesMaster != null)
    {
        // MasterNotesSlide टेक्स्ट शैली प्राप्त करें
        ITextStyle notesStyle = notesMaster.getNotesStyle();
    
        //Set पहले स्तर के पैराग्राफ़ के लिए सिंबल बुलेट
        IParagraphFormat paragraphFormat = notesStyle.getLevel(0);
        paragraphFormat.getBullet().setType(BulletType.Symbol);
    }
    pres.save("NotesSlideWithNotesStyle.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**कौन सा API इकाई एक विशिष्ट स्लाइड के नोट्स तक पहुंच प्रदान करती है?**

नोट्स स्लाइड के नोट्स मैनेज़र के माध्यम से एक्सेस किए जाते हैं: स्लाइड में एक [NotesSlideManager](https://reference.aspose.com/slides/hi/java/com.aspose.slides/notesslidemanager/) और एक [method](https://reference.aspose.com/slides/hi/java/com.aspose.slides/notesslidemanager/#getNotesSlide--) होता है जो नोट्स ऑब्जेक्ट लौटाता है, या यदि कोई नोट्स नहीं हैं तो `null`।

**क्या लाइब्रेरी द्वारा समर्थित PowerPoint संस्करणों में नोट्स समर्थन में अंतर हैं?**

लाइब्रेरी Microsoft PowerPoint के व्यापक रेंज (97‑नया) और ODP फॉर्मैट को लक्षित करती है; इन फॉर्मैट में नोट्स का समर्थन किया जाता है और इसके लिए स्थापित PowerPoint की आवश्यकता नहीं होती।