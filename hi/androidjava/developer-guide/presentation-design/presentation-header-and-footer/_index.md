---
title: एंड्रॉइड पर प्रस्तुति हेडर और फ़ूटर प्रबंधित करें
linktitle: हेडर और फ़ूटर
type: docs
weight: 140
url: /hi/androidjava/presentation-header-and-footer/
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
- एंड्रॉइड
- जावा
- Aspose.Slides
description: "Aspose.Slides for Android via Java के साथ स्लाइड, नोट्स पेज और हैंडआउट में फ़ूटर, तारीख‑समय, स्लाइड‑नंबर और हेडर प्लेसहोल्डर को कैसे प्रबंधित करें सीखें।"
---
## **समीक्षा**

PowerPoint पृष्ठ प्रकार के अनुसार विभिन्न हेडर और फ़ूटर प्लेसहोल्डर का उपयोग करता है। Aspose.Slides for Android via Java आपको इन प्लेसहोल्डर के टेक्स्ट और दृश्यता को हेडर/फ़ूटर मैनेज़र इंटरफ़ेस के माध्यम से नियंत्रित करने की सुविधा देता है।

उपलब्ध प्लेसहोल्डर दायरा पर निर्भर करते हैं:

| दायरा | हेडर | फ़ूटर | तारीख/समय | स्लाइड/पृष्ठ संख्या |
|---|---|---|---|---|
| सामान्य स्लाइड | नहीं | हाँ | हाँ | हाँ |
| नोट्स मास्टर | हाँ | हाँ | हाँ | हाँ |
| नोट्स स्लाइड | हाँ | हाँ | हाँ | हाँ |
| हैंडआउट मास्टर | हाँ | हाँ | हाँ | हाँ |

एक सामान्य प्रस्तुति स्लाइड में हेडर प्लेसहोल्डर नहीं होता है। हेडर नोट्स पृष्ठों और हैंडआउट में उपलब्ध हैं। सामान्य स्लाइड के लिए फ़ूटर, तारीख/समय और स्लाइड-नंबर प्लेसहोल्डर का उपयोग करें।

परिवर्तन का दायरा उस मैनेज़र पर निर्भर करता है जिसका आप उपयोग करते हैं। [`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/islideheaderfootermanager/) इंटरफ़ेस एक सामान्य स्लाइड को नियंत्रित करता है। [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/inotesslideheaderfootermanager/) इंटरफ़ेस एक नोट्स स्लाइड को नियंत्रित करता है। मास्टर और लेआउट मैनेज़र सेटिंग्स को आश्रित स्लाइडों पर भी प्रसारित कर सकते हैं, जबकि [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/imasterhandoutslideheaderfootermanager/) इंटरफ़ेस हैंडआउट मास्टर को नियंत्रित करता है।

## **सामान्य स्लाइडों पर फ़ूटर, तारीख/समय और स्लाइड नंबर सेट करें**

सामान्य स्लाइडों के लिए मूल कार्यप्रवाह यह है कि प्रत्येक स्लाइड के हेडर/फ़ूटर मैनेज़र तक पहुँचें, फ़ूटर और तारीख/समय टेक्स्ट सेट करें, आवश्यक प्लेसहोल्डर को सक्षम करें, और प्रस्तुति को सहेजें। स्लाइड नंबर प्रस्तुति द्वारा उत्पन्न होते हैं, इसलिए आपको केवल उनकी दृश्यता को नियंत्रित करना होता है।

[`setFooterText`](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/baseslideheaderfootermanager/#setFooterText-java.lang.String-) और [`setDateTimeText`](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/baseslideheaderfootermanager/#setDateTimeText-java.lang.String-) का उपयोग टेक्स्ट सेट करने के लिए किया जाता है, और [`setFooterVisibility`](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/baseslideheaderfootermanager/#setFooterVisibility-boolean-), [`setDateTimeVisibility`](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/baseslideheaderfootermanager/#setDateTimeVisibility-boolean-), तथा [`setSlideNumberVisibility`](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/baseslideheaderfootermanager/#setSlideNumberVisibility-boolean-) का उपयोग संबंधित प्लेसहोल्डर को दिखाने के लिए किया जाता है।

नीचे दिया गया एंड-टू-एंड उदाहरण सभी सामान्य स्लाइडों पर समान फ़ूटर, तारीख/समय टेक्स्ट और स्लाइड-नंबर दृश्यता लागू करता है:

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

यदि आपको केवल एक स्लाइड को अपडेट करना है, तो पूरे संग्रह को इटररेट करने के बजाय[`getSlides`](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/#getSlides--) मेथड के माध्यम से उस स्लाइड तक सीधे पहुँचें।

## **नोट्स मास्टर पर हेडर और फ़ूटर सेट करें**

नोट्स मास्टर नोट्स पृष्ठों के लिए सामान्य फ़ॉर्मेटिंग और प्लेसहोल्डर व्यवहार को परिभाषित करता है। जब आप केवल नोट्स मास्टर को बदलना चाहते हैं तो [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/) इंटरफ़ेस का उपयोग करें।

नीचे का उदाहरण नोट्स मास्टर पर हेडर, फ़ूटर और तारीख/समय टेक्स्ट सेट करता है और उस मास्टर पर सभी समर्थित प्लेसहोल्डर को दृश्य बनाता है:

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

[`getMasterNotesSlide`](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/imasternotesslidemanager/#getMasterNotesSlide--) मेथड `null` लौटाता है जब प्रस्तुति में नोट्स मास्टर नहीं होता है।

## **नोट्स मास्टर सेटिंग्स को चाइल्ड नोट्स स्लाइड्स पर लागू करें**

एक नोट्स मास्टर अपने स्वयं के हेडर और फ़ूटर सेटिंग्स को स्वयं तथा सभी आश्रित नोट्स स्लाइड्स पर लागू कर सकता है। जब समान सेटिंग्स को नोट्स पदानुक्रम में सभी स्तरों पर लागू करना हो तो [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/) पर समर्पित प्रसार मेथड का उपयोग करें।

उदाहरण के लिए, [`setHeaderAndChildHeadersText`](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/#setHeaderAndChildHeadersText-java.lang.String-) और [`setHeaderAndChildHeadersVisibility`](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/#setHeaderAndChildHeadersVisibility-boolean-) नोट्स मास्टर हेडर और सभी चाइल्ड हेडर को अपडेट करते हैं। फ़ूटर, तारीख/समय और स्लाइड नंबर के लिए समकक्ष मेथड उपलब्ध हैं।

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

ऊपर उपयोग किए गए प्रसार मेथड हैं [`setFooterAndChildFootersText`](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/#setFooterAndChildFootersText-java.lang.String-), [`setFooterAndChildFootersVisibility`](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/#setFooterAndChildFootersVisibility-boolean-), [`setDateTimeAndChildDateTimesText`](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesText-java.lang.String-), [`setDateTimeAndChildDateTimesVisibility`](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesVisibility-boolean-), तथा [`setSlideNumberAndChildSlideNumbersVisibility`](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/#setSlideNumberAndChildSlideNumbersVisibility-boolean-)।

## **व्यक्तिगत नोट्स स्लाइड पर हेडर और फ़ूटर सेट करें**

एक नोट्स स्लाइड एक विशिष्ट सामान्य स्लाइड से जुड़ी होती है। जब आप केवल उस नोट्स पृष्ठ को अनुकूलित करना चाहते हैं तो उसके [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/inotesslideheaderfootermanager/) इंटरफ़ेस का उपयोग करें।

[`addNotesSlide`](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/inotesslidemanager/#addNotesSlide--) मेथड वर्तमान स्लाइड के लिए नोट्स स्लाइड लौटाता है और यदि यह पहले से मौजूद नहीं है तो एक नया बनाता है। नीचे का उदाहरण पहले प्रस्तुति स्लाइड से जुड़े नोट्स पृष्ठ को कॉन्फ़िगर करता है:

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

यदि आप पहले नोट्स मास्टर से सेटिंग्स प्रसारित करते हैं और फिर व्यक्तिगत नोट्स स्लाइड को बदलते हैं, तो बाद की प्रति-स्लाइड सेटिंग्स आपको उस नोट्स पृष्ठ को स्वतंत्र रूप से अनुकूलित करने की अनुमति देती हैं।

## **हैंडआउट मास्टर पर हेडर और फ़ूटर सेट करें**

हैंडआउट पृष्ठ अपने हेडर, फ़ूटर, तारीख/समय और पृष्ठ-नंबर प्लेसहोल्डर के लिए हैंडआउट मास्टर का उपयोग करते हैं। नोट्स पृष्ठों के विपरीत, हैंडआउट सेटिंग्स व्यक्तिगत हैंडआउट स्लाइडों के बजाय हैंडआउट मास्टर द्वारा प्रबंधित की जाती हैं।

हैंडआउट मास्टर तक पहुँचने के लिए[`getMasterHandoutSlide`](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/imasterhandoutslidemanager/#getMasterHandoutSlide--) मेथड का उपयोग करें। यदि यह मौजूद नहीं है, तो डिफ़ॉल्ट हैंडआउट मास्टर बनाने के लिए[`setDefaultMasterHandoutSlide`](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/imasterhandoutslidemanager/#setDefaultMasterHandoutSlide--) को कॉल करें।

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

## **दायरा और विरासत को समझें**

उस दायरे के अनुसार हेडर/फ़ूटर मैनेज़र चुनें जिसे आप बदलना चाहते हैं:

- [`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/islideheaderfootermanager/) एक सामान्य स्लाइड के फ़ूटर, तारीख/समय और स्लाइड-नंबर सेटिंग्स को बदलता है।
- [`ILayoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ilayoutslideheaderfootermanager/) एक लेआउट स्लाइड को नियंत्रित करता है और समर्थित सेटिंग्स को आश्रित स्लाइडों में प्रसारित कर सकता है।
- [`IMasterSlideHeaderFooterManager`](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/imasterslideheaderfootermanager/) एक सामान्य स्लाइड मास्टर को नियंत्रित करता है और समर्थित सेटिंग्स को आश्रित स्लाइडों में प्रसारित कर सकता है।
- [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/) नोट्स मास्टर को नियंत्रित करता है और सभी आश्रित नोट्स स्लाइडों में सेटिंग्स को प्रसारित कर सकता है।
- [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/inotesslideheaderfootermanager/) एक नोट्स स्लाइड को बदलता है और फ़ूटर, तारीख/समय तथा स्लाइड नंबर के अलावा एक हेडर प्लेसहोल्डर का समर्थन करता है।
- [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/imasterhandoutslideheaderfootermanager/) हैंडआउट मास्टर को बदलता है और सभी चार प्रकार के प्लेसहोल्डर का समर्थन करता है।

जब एक ही सेटिंग को पूरे पदानुक्रम में लागू करना हो तो मास्टर या लेआउट से प्रसारण उपयोग करें। जब केवल एक पृष्ठ के लिए स्थानीय सेटिंग की आवश्यकता हो तो व्यक्तिगत स्लाइड या नोट्स-स्लाइड मैनेज़र उपयोग करें।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं सामान्य स्लाइड में हेडर जोड़ सकता हूँ?**

नहीं। PowerPoint सामान्य स्लाइडों के लिए हेडर प्लेसहोल्डर परिभाषित नहीं करता है। सामान्य स्लाइडों पर फ़ूटर, तारीख/समय और स्लाइड-नंबर प्लेसहोल्डर का उपयोग करें। हेडर प्लेसहोल्डर नोट्स पृष्ठों और हैंडआउट में उपलब्ध हैं।

**यदि फ़ूटर, तारीख/समय या स्लाइड-नंबर प्लेसहोल्डर दिखाई नहीं दे रहे हैं तो क्या करें?**

संबंधित हेडर/फ़ूटर मैनेज़र का उपयोग करके उसकी दृश्यता जांचें और आवश्यक होने पर उसे सक्षम करें। उदाहरण के लिए, [`isFooterVisible`](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/baseslideheaderfootermanager/#isFooterVisible--) यह रिपोर्ट करता है कि फ़ूटर प्लेसहोल्डर मौजूद है या नहीं, और [`setFooterVisibility`](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/baseslideheaderfootermanager/#setFooterVisibility-boolean-) उसकी दृश्यता बदलता है।

**मैं स्लाइड नंबरिंग को 1 से अलग मान से कैसे शुरू करूँ?**

प्रस्तुति के [`setFirstSlideNumber`](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/#setFirstSlideNumber-int-) मेथड को कॉल करें। उसके बाद स्लाइड-नंबर प्लेसहोल्डर अपडेटेड क्रमांक अनुक्रम का उपयोग करेंगे।

**PDF, इमेज या HTML में निर्यात करते समय हेडर और फ़ूटर का क्या होता है?**

दृश्यमान हेडर और फ़ूटर तत्व आउटपुट फ़ॉर्मेट में प्रस्तुति की शेष सामग्री के साथ रेंडर होते हैं। उनका स्वरूप निर्यात किए जा रहे पृष्ठ प्रकार और संबंधित प्लेसहोल्डर दृश्यता सेटिंग्स पर निर्भर करता है।