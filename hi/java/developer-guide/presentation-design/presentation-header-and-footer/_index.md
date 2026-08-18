---
title: Java में प्रस्तुति हेडर और फुटर प्रबंधन
linktitle: हेडर और फुटर
type: docs
weight: 140
url: /hi/java/presentation-header-and-footer/
keywords:
- हेडर
- हेडर टेक्स्ट
- फुटर
- फुटर टेक्स्ट
- हेडर सेट करें
- फुटर सेट करें
- हैंडआउट
- नोट्स
- PowerPoint
- OpenDocument
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java के साथ स्लाइड्स, नोट्स पेज और हैंडआउट में फुटर, तारीख‑समय, स्लाइड‑नंबर और हेडर प्लेसहोल्डर्स को कैसे प्रबंधित करें, सीखें।"
---
## **अवलोकन**

PowerPoint पृष्ठ प्रकार के अनुसार विभिन्न हेडर और फुटर प्लेसहोल्डर्स का उपयोग करता है। Aspose.Slides for Java आपको इन प्लेसहोल्डर्स के टेक्स्ट और दृश्यता को हेडर/फुटर प्रबंधक इंटरफ़ेसेस के माध्यम से नियंत्रित करने देता है।

उपलब्ध प्लेसहोल्डर्स स्कोप पर निर्भर करते हैं:

| स्कोप | हेडर | फुटर | तारीख/समय | स्लाइड/पृष्ठ संख्या |
|---|---|---|---|---|
| सामान्य स्लाइड | नहीं | हाँ | हाँ | हाँ |
| नोट्स मास्टर | हाँ | हाँ | हाँ | हाँ |
| नोट्स स्लाइड | हाँ | हाँ | हाँ | हाँ |
| हैंडआउट मास्टर | हाँ | हाँ | हाँ | हाँ |

एक सामान्य प्रस्तुति स्लाइड में हेडर प्लेसहोल्डर नहीं होता। हेडर नोट्स पेज और हैंडआउट में उपलब्ध होते हैं। सामान्य स्लाइड्स के लिए, इसके बजाय फुटर, तारीख/समय और स्लाइड-नंबर प्लेसहोल्डर्स का उपयोग करें।

परिवर्तन का स्कोप उस प्रबंधक पर निर्भर करता है जिसका आप उपयोग करते हैं। [`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/hi/java/com.aspose.slides/islideheaderfootermanager/) इंटरफ़ेस एक सामान्य स्लाइड को नियंत्रित करता है। [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/hi/java/com.aspose.slides/inotesslideheaderfootermanager/) इंटरफ़ेस एक नोट्स स्लाइड को नियंत्रित करता है। मास्टर और लेआउट प्रबंधक सेटिंग्स को निर्भरत स्लाइड्स में प्रसारित भी कर सकते हैं, जबकि [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/hi/java/com.aspose.slides/imasterhandoutslideheaderfootermanager/) इंटरफ़ेस हैंडआउट मास्टर को नियंत्रित करता है।

## **सामान्य स्लाइड्स पर फुटर, तारीख/समय और स्लाइड नंबर सेट करें**

सामान्य स्लाइड्स के लिए, बुनियादी कार्यप्रवाह यह है कि प्रत्येक स्लाइड के हेडर/फुटर प्रबंधक तक पहुंचें, फुटर और तारीख/समय टेक्स्ट सेट करें, आवश्यक प्लेसहोल्डर्स को सक्षम करें, और प्रस्तुति को सहेजें। स्लाइड नंबर प्रस्तुति द्वारा जनरेट होते हैं, इसलिए आपको केवल उनकी दृश्यता को नियंत्रित करने की आवश्यकता है।

टेक्स्ट सेट करने के लिए [`setFooterText`](https://reference.aspose.com/slides/hi/java/com.aspose.slides/baseslideheaderfootermanager/#setFooterText-java.lang.String-) और [`setDateTimeText`](https://reference.aspose.com/slides/hi/java/com.aspose.slides/baseslideheaderfootermanager/#setDateTimeText-java.lang.String-) का उपयोग करें, और संबंधित प्लेसहोल्डर्स दिखाने के लिए [`setFooterVisibility`](https://reference.aspose.com/slides/hi/java/com.aspose.slides/baseslideheaderfootermanager/#setFooterVisibility-boolean-), [`setDateTimeVisibility`](https://reference.aspose.com/slides/hi/java/com.aspose.slides/baseslideheaderfootermanager/#setDateTimeVisibility-boolean-), और [`setSlideNumberVisibility`](https://reference.aspose.com/slides/hi/java/com.aspose.slides/baseslideheaderfootermanager/#setSlideNumberVisibility-boolean-) का प्रयोग करें।

निम्नलिखित अंत‑से‑अंत उदाहरण सभी सामान्य स्लाइड्स पर समान फुटर, तारीख/समय टेक्स्ट और स्लाइड‑नंबर दृश्यता लागू करता है:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        ISlideHeaderFooterManager headerFooterManager = slide.getHeaderFooterManager();

        headerFooterManager.setFooterText("Company Confidential");
        headerFooterManager.setFooterVisibility(true);

        headerFooterManager.setDateTimeText("Date and time text");
        headerFooterManager.setDateTimeVisibility(true);

        headerFooterManager.setSlideNumberVisibility(true);
    }

    presentation.save("presentation_with_slide_footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

यदि आपको केवल एक स्लाइड को अपडेट करना है, तो पूरे संग्रह पर इटरेट करने के बजाय [`getSlides`](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/#getSlides--) मेथड के माध्यम से उस स्लाइड तक सीधे पहुंचें।

## **नोट्स मास्टर पर हेडर और फुटर सेट करें**

नोट्स मास्टर नोट्स पेजों के लिए सामान्य फ़ॉर्मेटिंग और प्लेसहोल्डर व्यवहार को परिभाषित करता है। जब आप केवल नोट्स मास्टर स्वयं को बदलना चाहते हैं, तब [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/hi/java/com.aspose.slides/imasternotesslideheaderfootermanager/) इंटरफ़ेस का उपयोग करें।

निम्नलिखित उदाहरण नोट्स मास्टर पर हेडर, फुटर और तारीख/समय टेक्स्ट सेट करता है और उस मास्टर पर सभी समर्थित प्लेसहोल्डर्स को दृश्य बनाता है:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterNotesSlide masterNotesSlide = presentation.getMasterNotesSlideManager().getMasterNotesSlide();

    if (masterNotesSlide != null) {
        IMasterNotesSlideHeaderFooterManager headerFooterManager = masterNotesSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderText("Notes header");
        headerFooterManager.setHeaderVisibility(true);

        headerFooterManager.setFooterText("Notes footer");
        headerFooterManager.setFooterVisibility(true);

        headerFooterManager.setDateTimeText("Date and time text");
        headerFooterManager.setDateTimeVisibility(true);

        headerFooterManager.setSlideNumberVisibility(true);
    }

    presentation.save("presentation_with_notes_master_footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

जब प्रस्तुति में नोट्स मास्टर नहीं होता, तो [`getMasterNotesSlide`](https://reference.aspose.com/slides/hi/java/com.aspose.slides/imasternotesslidemanager/#getMasterNotesSlide--) मेथड `null` लौटाता है।

## **नोट्स मास्टर सेटिंग्स को चाइल्ड नोट्स स्लाइड्स पर लागू करें**

एक नोट्स मास्टर हेडर और फुटर सेटिंग्स को स्वयं और सभी निर्भरत नोट्स स्लाइड्स पर लागू कर सकता है। जब वही सेटिंग्स नोट्स पदानुक्रम में सभी स्तरों पर लागू करनी हों, तब [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/hi/java/com.aspose.slides/imasternotesslideheaderfootermanager/) पर समर्पित प्रसारण मेथड्स का उपयोग करें।

उदाहरण के लिए, [`setHeaderAndChildHeadersText`](https://reference.aspose.com/slides/hi/java/com.aspose.slides/imasternotesslideheaderfootermanager/#setHeaderAndChildHeadersText-java.lang.String-) और [`setHeaderAndChildHeadersVisibility`](https://reference.aspose.com/slides/hi/java/com.aspose.slides/imasternotesslideheaderfootermanager/#setHeaderAndChildHeadersVisibility-boolean-) नोट्स मास्टर हेडर और सभी चाइल्ड हेडर्स को अपडेट करते हैं। फुटर, तारीख/समय और स्लाइड नंबर के लिए समान मेथड उपलब्ध हैं।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterNotesSlide masterNotesSlide = presentation.getMasterNotesSlideManager().getMasterNotesSlide();

    if (masterNotesSlide != null) {
        IMasterNotesSlideHeaderFooterManager headerFooterManager = masterNotesSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderAndChildHeadersText("Notes header");
        headerFooterManager.setHeaderAndChildHeadersVisibility(true);

        headerFooterManager.setFooterAndChildFootersText("Notes footer");
        headerFooterManager.setFooterAndChildFootersVisibility(true);

        headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");
        headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);

        headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);
    }

    presentation.save("presentation_with_child_notes_footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ऊपर उपयोग किए गए प्रसारण मेथड्स हैं [`setFooterAndChildFootersText`](https://reference.aspose.com/slides/hi/java/com.aspose.slides/imasternotesslideheaderfootermanager/#setFooterAndChildFootersText-java.lang.String-), [`setFooterAndChildFootersVisibility`](https://reference.aspose.com/slides/hi/java/com.aspose.slides/imasternotesslideheaderfootermanager/#setFooterAndChildFootersVisibility-boolean-), [`setDateTimeAndChildDateTimesText`](https://reference.aspose.com/slides/hi/java/com.aspose.slides/imasternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesText-java.lang.String-), [`setDateTimeAndChildDateTimesVisibility`](https://reference.aspose.com/slides/hi/java/com.aspose.slides/imasternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesVisibility-boolean-), और [`setSlideNumberAndChildSlideNumbersVisibility`](https://reference.aspose.com/slides/hi/java/com.aspose.slides/imasternotesslideheaderfootermanager/#setSlideNumberAndChildSlideNumbersVisibility-boolean-)।

## **एक व्यक्तिगत नोट्स स्लाइड पर हेडर और फुटर सेट करें**

एक नोट्स स्लाइड विशिष्ट सामान्य स्लाइड से जुड़ी होती है। जब आप केवल उस नोट्स पेज को कस्टमाइज़ करना चाहते हैं, तब उसकी [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/hi/java/com.aspose.slides/inotesslideheaderfootermanager/) इंटरफ़ेस का उपयोग करें।

[`addNotesSlide`](https://reference.aspose.com/slides/hi/java/com.aspose.slides/inotesslidemanager/#addNotesSlide--) मेथड वर्तमान स्लाइड के लिए नोट्स स्लाइड लौटाता है और यदि मौजूद नहीं है तो एक नई बनाता है। निम्नलिखित उदाहरण पहली प्रस्तुति स्लाइड से जुड़े नोट्स पेज को कॉन्फ़िगर करता है:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    INotesSlide notesSlide = slide.getNotesSlideManager().addNotesSlide();
    INotesSlideHeaderFooterManager headerFooterManager = notesSlide.getHeaderFooterManager();

    headerFooterManager.setHeaderText("Header for the first notes page");
    headerFooterManager.setHeaderVisibility(true);

    headerFooterManager.setFooterText("Footer for the first notes page");
    headerFooterManager.setFooterVisibility(true);

    headerFooterManager.setDateTimeText("Date and time text");
    headerFooterManager.setDateTimeVisibility(true);

    headerFooterManager.setSlideNumberVisibility(true);

    presentation.save("presentation_with_custom_notes_footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

यदि आप पहले नोट्स मास्टर से सेटिंग्स प्रसारित करते हैं और फिर व्यक्तिगत नोट्स स्लाइड बदलते हैं, तो बाद की प्रति‑स्लाइड सेटिंग्स आपको उस नोट्स पेज को स्वतंत्र रूप से कस्टमाइज़ करने देती हैं।

## **हैंडआउट मास्टर पर हेडर और फुटर सेट करें**

हैंडआउट पेज अपने हेडर, फुटर, तारीख/समय और पृष्ठ‑संख्या प्लेसहोल्डर्स के लिए हैंडआउट मास्टर का उपयोग करते हैं। नोट्स पेजों के विपरीत, हैंडआउट सेटिंग्स व्यक्तिगत हैंडआउट स्लाइड्स के बजाय हैंडआउट मास्टर द्वारा प्रबंधित की जाती हैं।

हैंडआउट मास्टर तक पहुंचने के लिए [`getMasterHandoutSlide`](https://reference.aspose.com/slides/hi/java/com.aspose.slides/imasterhandoutslidemanager/#getMasterHandoutSlide--) मेथड का उपयोग करें। यदि यह मौजूद नहीं है, तो डिफ़ॉल्ट हैंडआउट मास्टर बनाने के लिए [`setDefaultMasterHandoutSlide`](https://reference.aspose.com/slides/hi/java/com.aspose.slides/imasterhandoutslidemanager/#setDefaultMasterHandoutSlide--) को कॉल करें।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterHandoutSlide masterHandoutSlide = presentation.getMasterHandoutSlideManager().getMasterHandoutSlide();

    if (masterHandoutSlide == null) {
        masterHandoutSlide = presentation.getMasterHandoutSlideManager().setDefaultMasterHandoutSlide();
    }

    if (masterHandoutSlide != null) {
        IMasterHandoutSlideHeaderFooterManager headerFooterManager = masterHandoutSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderText("Handout header");
        headerFooterManager.setHeaderVisibility(true);

        headerFooterManager.setFooterText("Handout footer");
        headerFooterManager.setFooterVisibility(true);

        headerFooterManager.setDateTimeText("Date and time text");
        headerFooterManager.setDateTimeVisibility(true);

        headerFooterManager.setSlideNumberVisibility(true);
    }

    presentation.save("presentation_with_handout_footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **स्कोप और इनहेरिटेंस को समझें**

वह हेडर/फुटर प्रबंधक चुनें जो आप बदलना चाहते हैं उस स्कोप से मेल खाता हो:

- [`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/hi/java/com.aspose.slides/islideheaderfootermanager/) एक सामान्य स्लाइड के लिए फुटर, तारीख/समय और स्लाइड‑नंबर सेटिंग्स बदलता है।
- [`ILayoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ilayoutslideheaderfootermanager/) लेआउट स्लाइड को नियंत्रित करता है और समर्थित सेटिंग्स को निर्भरत स्लाइड्स में प्रसारित कर सकता है।
- [`IMasterSlideHeaderFooterManager`](https://reference.aspose.com/slides/hi/java/com.aspose.slides/imasterslideheaderfootermanager/) सामान्य स्लाइड मास्टर को नियंत्रित करता है और समर्थित सेटिंग्स को निर्भरत स्लाइड्स में प्रसारित कर सकता है।
- [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/hi/java/com.aspose.slides/imasternotesslideheaderfootermanager/) नोट्स मास्टर को नियंत्रित करता है और सभी निर्भरत नोट्स स्लाइड्स में सेटिंग्स प्रसारित कर सकता है।
- [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/hi/java/com.aspose.slides/inotesslideheaderfootermanager/) एक नोट्स स्लाइड को बदलता है और फुटर, तारीख/समय और स्लाइड नंबर के अतिरिक्त हेडर प्लेसहोल्डर को सपोर्ट करता है।
- [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/hi/java/com.aspose.slides/imasterhandoutslideheaderfootermanager/) हैंडआउट मास्टर को बदलता है और सभी चार प्लेसहोल्डर प्रकारों को सपोर्ट करता है।

जब वही सेटिंग पूरी पदानुक्रम में लागू होनी हो, तो मास्टर या लेआउट से प्रसारण उपयोग करें। जब आपको केवल एक पेज के लिए स्थानीय सेटिंग चाहिए, तो व्यक्तिगत स्लाइड या नोट्स‑स्लाइड प्रबंधक उपयोग करें।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं सामान्य स्लाइड में हेडर जोड़ सकता हूँ?**

नहीं। PowerPoint सामान्य स्लाइड के लिए हेडर प्लेसहोल्डर नहीं परिभाषित करता। सामान्य स्लाइड्स पर फुटर, तारीख/समय और स्लाइड‑नंबर प्लेसहोल्डर्स का उपयोग करें। हेडर प्लेसहोल्डर नोट्स पेज और हैंडआउट में उपलब्ध होते हैं।

**यदि फुटर, तारीख/समय, या स्लाइड‑नंबर प्लेसहोल्डर दृश्य नहीं है तो क्या करें?**

संबंधित हेडर/फुटर प्रबंधक का उपयोग करके उसकी दृश्यता जांचें और आवश्यकता पड़ने पर उसे सक्षम करें। उदाहरण के लिए, [`isFooterVisible`](https://reference.aspose.com/slides/hi/java/com.aspose.slides/baseslideheaderfootermanager/#isFooterVisible--) रिपोर्ट करता है कि फुटर प्लेसहोल्डर मौजूद है या नहीं, और [`setFooterVisibility`](https://reference.aspose.com/slides/hi/java/com.aspose.slides/baseslideheaderfootermanager/#setFooterVisibility-boolean-) उसकी दृश्यता बदलता है।

**मैं स्लाइड नंबरिंग को 1 से अलग मान से कैसे शुरू करूँ?**

प्रेजेंटेशन की [`setFirstSlideNumber`](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/#setFirstSlideNumber-int-) मेथड को कॉल करें। तब स्लाइड‑नंबर प्लेसहोल्डर अपडेटेड क्रम का उपयोग करेंगे।

**PDF, इमेज़ या HTML में एक्सपोर्ट करने पर हेडर और फुटर का क्या होता है?**

दृश्य हेडर और फुटर तत्व आउटपुट फ़ॉर्मेट में प्रस्तुति सामग्री के साथ रेंडर होते हैं। उनका स्वरूप निर्यात किए जा रहे पृष्ठ प्रकार और संबंधित प्लेसहोल्डर दृश्यता सेटिंग्स पर निर्भर करता है।