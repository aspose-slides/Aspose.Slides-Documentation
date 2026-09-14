---
title: Python के माध्यम से Java में प्रस्तुति हेडर और फुटर प्रबंधित करें
linktitle: हेडर और फुटर
type: docs
weight: 140
url: /hi/python-java/presentation-header-and-footer/
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
- प्रेजेंटेशन
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java के साथ स्लाइड्स, नोट्स पेज और हैंडआउट्स में फुटर, तिथि-समय, स्लाइड-नंबर और हेडर प्लेसहोल्डर्स को कैसे प्रबंधित करें, सीखें।"
---
## **सारांश**

PowerPoint पेज प्रकार के आधार पर विभिन्न हेडर और फुटर प्लेसहोल्डर्स का उपयोग करता है। Aspose.Slides for Python via Java आपको इन प्लेसहोल्डर्स के टेक्स्ट और दृश्यता को हेडर/फुटर मैनेजर क्लासेज़ के माध्यम से नियंत्रित करने की अनुमति देता है।

उपलब्ध प्लेसहोल्डर्स स्कोप पर निर्भर करते हैं:

| स्कोप | हेडर | फुटर | तिथि/समय | स्लाइड/पेज संख्या |
|---|---|---|---|---|
| सामान्य स्लाइड | नहीं | हां | हां | हां |
| नोट्स मास्टर | हां | हां | हां | हां |
| नोट्स स्लाइड | हां | हां | हां | हां |
| हैंडआउट मास्टर | हां | हां | हां | हां |

एक सामान्य प्रेजेंटेशन स्लाइड में हेडर प्लेसहोल्डर नहीं होता है। हेडर नोट्स पेज और हैंडआउट्स में उपलब्ध होते हैं। सामान्य स्लाइड्स के लिए, फुटर, तिथि/समय, और स्लाइड-नंबर प्लेसहोल्डर्स का उपयोग करें।

बदलाव का स्कोप आपके द्वारा उपयोग किए जाने वाले मैनेजर पर निर्भर करता है। [SlideHeaderFooterManager](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slideheaderfootermanager/) क्लास एक सामान्य स्लाइड को नियंत्रित करती है। [NotesSlideHeaderFooterManager](https://reference.aspose.com/slides/hi/python-java/aspose.slides/notesslideheaderfootermanager/) क्लास एक नोट्स स्लाइड को नियंत्रित करती है। मास्टर और लेआउट मैनेजर्स सेटिंग्स को डिपेंडेंट स्लाइड्स में भी प्रसारित कर सकते हैं, जबकि [MasterHandoutSlideHeaderFooterManager](https://reference.aspose.com/slides/hi/python-java/aspose.slides/masterhandoutslideheaderfootermanager/) क्लास हैंडआउट मास्टर को नियंत्रित करती है।

## **सामान्य स्लाइड्स पर फुटर, तिथि/समय, और स्लाइड नंबर सेट करें**

सामान्य स्लाइड्स के लिए, मूल कार्यप्रवाह यह है कि प्रत्येक स्लाइड के हेडर/फुटर मैनेजर तक पहुँचें, फुटर और तिथि/समय टेक्स्ट सेट करें, आवश्यक प्लेसहोल्डर्स को सक्रिय करें, और प्रेजेंटेशन को सहेजें। स्लाइड नंबर प्रेजेंटेशन द्वारा उत्पन्न होते हैं, इसलिए आपको केवल उनकी दृश्यता को नियंत्रित करने की आवश्यकता है।

टेक्स्ट सेट करने के लिए [setFooterText](https://reference.aspose.com/slides/hi/python-java/aspose.slides/baseslideheaderfootermanager/#setFooterText) और [setDateTimeText](https://reference.aspose.com/slides/hi/python-java/aspose.slides/baseslideheaderfootermanager/#setDateTimeText) का उपयोग करें, और संबंधित प्लेसहोल्डर्स को दिखाने के लिए [setFooterVisibility](https://reference.aspose.com/slides/hi/python-java/aspose.slides/baseslideheaderfootermanager/#setFooterVisibility), [setDateTimeVisibility](https://reference.aspose.com/slides/hi/python-java/aspose.slides/baseslideheaderfootermanager/#setDateTimeVisibility), और [setSlideNumberVisibility](https://reference.aspose.com/slides/hi/python-java/aspose.slides/baseslideheaderfootermanager/#setSlideNumberVisibility) का उपयोग करें।

निम्नलिखित एंड-टू-एंड उदाहरण सभी सामान्य स्लाइड्स पर समान फुटर, तिथि/समय टेक्स्ट, और स्लाइड-नंबर दृश्यता लागू करता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    for slide in presentation.getSlides():
        header_footer_manager = slide.getHeaderFooterManager()

        header_footer_manager.setFooterText("Company Confidential")
        header_footer_manager.setFooterVisibility(True)

        header_footer_manager.setDateTimeText("Date and time text")
        header_footer_manager.setDateTimeVisibility(True)

        header_footer_manager.setSlideNumberVisibility(True)

    presentation.save("presentation_with_slide_footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

यदि आपको केवल एक स्लाइड को अपडेट करने की आवश्यकता है, तो पूरे कलेक्शन पर इटरेट करने के बजाय [getSlides](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#getSlides) मेथड के माध्यम से उस स्लाइड तक सीधे पहुँचें।

## **नोट्स मास्टर पर हेडर और फुटर सेट करें**

नोट्स मास्टर नोट्स पेजों के लिए सामान्य फ़ॉर्मेटिंग और प्लेसहोल्डर व्यवहार को परिभाषित करता है। जब आप केवल नोट्स मास्टर को बदलना चाहते हैं, तो [MasterNotesSlideHeaderFooterManager](https://reference.aspose.com/slides/hi/python-java/aspose.slides/masternotesslideheaderfootermanager/) क्लास का उपयोग करें।

निम्नलिखित उदाहरण नोट्स मास्टर पर हेडर, फुटर, और तिथि/समय टेक्स्ट सेट करता है और उस मास्टर पर सभी समर्थित प्लेसहोल्डर्स को दृश्य बनाता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    master_notes_slide = presentation.getMasterNotesSlideManager().getMasterNotesSlide()

    if master_notes_slide is not None:
        header_footer_manager = master_notes_slide.getHeaderFooterManager()

        header_footer_manager.setHeaderText("Notes header")
        header_footer_manager.setHeaderVisibility(True)

        header_footer_manager.setFooterText("Notes footer")
        header_footer_manager.setFooterVisibility(True)

        header_footer_manager.setDateTimeText("Date and time text")
        header_footer_manager.setDateTimeVisibility(True)

        header_footer_manager.setSlideNumberVisibility(True)

    presentation.save("presentation_with_notes_master_footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

`getMasterNotesSlide` मेथड `None` लौटाता है जब प्रेजेंटेशन में नोट्स मास्टर मौजूद नहीं होता है।

## **नोट्स मास्टर सेटिंग्स को चाइल्ड नोट्स स्लाइड्स पर लागू करें**

एक नोट्स मास्टर अपने आप और सभी डिपेंडेंट नोट्स स्लाइड्स पर हेडर और फुटर सेटिंग्स लागू कर सकता है। जब समान सेटिंग्स को नोट्स हिंरार्की में पूरे स्तर पर लागू करना हो, तो [MasterNotesSlideHeaderFooterManager](https://reference.aspose.com/slides/hi/python-java/aspose.slides/masternotesslideheaderfootermanager/) पर समर्पित प्रसारण मेथड्स का उपयोग करें।

उदाहरण के लिए, [setHeaderAndChildHeadersText](https://reference.aspose.com/slides/hi/python-java/aspose.slides/masternotesslideheaderfootermanager/#setHeaderAndChildHeadersText) और [setHeaderAndChildHeadersVisibility](https://reference.aspose.com/slides/hi/python-java/aspose.slides/masternotesslideheaderfootermanager/#setHeaderAndChildHeadersVisibility) नोट्स मास्टर हेडर और सभी चाइल्ड हेडर्स को अपडेट करते हैं। फुटर, तिथि/समय, और स्लाइड नंबर के लिए समान मेथड्स उपलब्ध हैं।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    master_notes_slide = presentation.getMasterNotesSlideManager().getMasterNotesSlide()

    if master_notes_slide is not None:
        header_footer_manager = master_notes_slide.getHeaderFooterManager()

        header_footer_manager.setHeaderAndChildHeadersText("Notes header")
        header_footer_manager.setHeaderAndChildHeadersVisibility(True)

        header_footer_manager.setFooterAndChildFootersText("Notes footer")
        header_footer_manager.setFooterAndChildFootersVisibility(True)

        header_footer_manager.setDateTimeAndChildDateTimesText("Date and time text")
        header_footer_manager.setDateTimeAndChildDateTimesVisibility(True)

        header_footer_manager.setSlideNumberAndChildSlideNumbersVisibility(True)

    presentation.save("presentation_with_child_notes_footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

उपर्युक्त प्रसारण मेथड्स हैं: [setFooterAndChildFootersText](https://reference.aspose.com/slides/hi/python-java/aspose.slides/masternotesslideheaderfootermanager/#setFooterAndChildFootersText), [setFooterAndChildFootersVisibility](https://reference.aspose.com/slides/hi/python-java/aspose.slides/masternotesslideheaderfootermanager/#setFooterAndChildFootersVisibility), [setDateTimeAndChildDateTimesText](https://reference.aspose.com/slides/hi/python-java/aspose.slides/masternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesText), [setDateTimeAndChildDateTimesVisibility](https://reference.aspose.com/slides/hi/python-java/aspose.slides/masternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesVisibility), और [setSlideNumberAndChildSlideNumbersVisibility](https://reference.aspose.com/slides/hi/python-java/aspose.slides/masternotesslideheaderfootermanager/#setSlideNumberAndChildSlideNumbersVisibility)।

## **एक व्यक्तिगत नोट्स स्लाइड पर हेडर और फुटर सेट करें**

एक नोट्स स्लाइड एक विशिष्ट सामान्य स्लाइड से जुड़ी होती है। जब आप केवल उस नोट्स पेज को कस्टमाइज़ करना चाहते हैं, तो उसके [NotesSlideHeaderFooterManager](https://reference.aspose.com/slides/hi/python-java/aspose.slides/notesslideheaderfootermanager/) क्लास का उपयोग करें।

[addNotesSlide](https://reference.aspose.com/slides/hi/python-java/aspose.slides/notesslidemanager/#addNotesSlide) मेथड वर्तमान स्लाइड के लिए नोट्स स्लाइड लौटाता है और यदि वह पहले से मौजूद नहीं है तो उसे बनाता है। निम्नलिखित उदाहरण पहले प्रेजेंटेशन स्लाइड से जुड़ी नोट्स पेज को कॉन्फ़िगर करता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    notes_slide = slide.getNotesSlideManager().addNotesSlide()
    header_footer_manager = notes_slide.getHeaderFooterManager()

    header_footer_manager.setHeaderText("Header for the first notes page")
    header_footer_manager.setHeaderVisibility(True)

    header_footer_manager.setFooterText("Footer for the first notes page")
    header_footer_manager.setFooterVisibility(True)

    header_footer_manager.setDateTimeText("Date and time text")
    header_footer_manager.setDateTimeVisibility(True)

    header_footer_manager.setSlideNumberVisibility(True)

    presentation.save("presentation_with_custom_notes_footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

यदि आप पहले नोट्स मास्टर से सेटिंग्स प्रसारित करते हैं और फिर व्यक्तिगत नोट्स स्लाइड को बदलते हैं, तो बाद की प्रति-स्लाइड सेटिंग्स आपको उस नोट्स पेज को स्वतंत्र रूप से कस्टमाइज़ करने की अनुमति देती हैं।

## **हैंडआउट मास्टर पर हेडर और फुटर सेट करें**

हैंडआउट पेज अपने हेडर, फुटर, तिथि/समय, और पेज-नंबर प्लेसहोल्डर्स के लिए हैंडआउट मास्टर का उपयोग करते हैं। नोट्स पेजों के विपरीत, हैंडआउट सेटिंग्स व्यक्तिगत हैंडआउट स्लाइड्स के बजाय हैंडआउट मास्टर के माध्यम से प्रबंधित की जाती हैं।

`getMasterHandoutSlide` मेथड का उपयोग करके हैंडआउट मास्टर तक पहुँचें। यदि वह मौजूद नहीं है, तो `setDefaultMasterHandoutSlide` को कॉल करके डिफ़ॉल्ट हैंडआउट मास्टर बनाएँ।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    master_handout_slide = presentation.getMasterHandoutSlideManager().getMasterHandoutSlide()

    if master_handout_slide is None:
        master_handout_slide = presentation.getMasterHandoutSlideManager().setDefaultMasterHandoutSlide()

    if master_handout_slide is not None:
        header_footer_manager = master_handout_slide.getHeaderFooterManager()

        header_footer_manager.setHeaderText("Handout header")
        header_footer_manager.setHeaderVisibility(True)

        header_footer_manager.setFooterText("Handout footer")
        header_footer_manager.setFooterVisibility(True)

        header_footer_manager.setDateTimeText("Date and time text")
        header_footer_manager.setDateTimeVisibility(True)

        header_footer_manager.setSlideNumberVisibility(True)

    presentation.save("presentation_with_handout_footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **स्कोप और इनहेरिटेंस समझें**

जिस स्कोप को आप बदलना चाहते हैं, उसके अनुरूप हेडर/फुटर मैनेजर चुनें:

- [SlideHeaderFooterManager](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slideheaderfootermanager/) एक सामान्य स्लाइड के लिए फुटर, तिथि/समय, और स्लाइड-नंबर सेटिंग्स बदलता है।
- [LayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/hi/python-java/aspose.slides/layoutslideheaderfootermanager/) एक लेआउट स्लाइड को नियंत्रित करता है और समर्थित सेटिंग्स को डिपेंडेंट स्लाइड्स में प्रसारित कर सकता है।
- [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/hi/python-java/aspose.slides/masterslideheaderfootermanager/) एक सामान्य स्लाइड मास्टर को नियंत्रित करता है और समर्थित सेटिंग्स को डिपेंडेंट स्लाइड्स में प्रसारित कर सकता है।
- [MasterNotesSlideHeaderFooterManager](https://reference.aspose.com/slides/hi/python-java/aspose.slides/masternotesslideheaderfootermanager/) नोट्स मास्टर को नियंत्रित करता है और सभी डिपेंडेंट नोट्स स्लाइड्स में सेटिंग्स को प्रसारित कर सकता है।
- [NotesSlideHeaderFooterManager](https://reference.aspose.com/slides/hi/python-java/aspose.slides/notesslideheaderfootermanager/) एक नोट्स स्लाइड को बदलता है और फुटर, तिथि/समय, स्लाइड नंबर के अलावा हेडर प्लेसहोल्डर का समर्थन करता है।
- [MasterHandoutSlideHeaderFooterManager](https://reference.aspose.com/slides/hi/python-java/aspose.slides/masterhandoutslideheaderfootermanager/) हैंडआउट मास्टर को बदलता है और सभी चार प्रकार के प्लेसहोल्डर्स का समर्थन करता है।

जब समान सेटिंग को पूरी हिस्ट्रिक में लागू करना हो, तो मास्टर या लेआउट से प्रसार का उपयोग करें। जब आपको एक पेज के लिए स्थानीय सेटिंग चाहिए, तो व्यक्तिगत स्लाइड या नोट्स-स्लाइड मैनेजर का उपयोग करें।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं सामान्य स्लाइड में हेडर जोड़ सकता हूँ?**

नहीं। PowerPoint सामान्य स्लाइड्स के लिए हेडर प्लेसहोल्डर परिभाषित नहीं करता है। सामान्य स्लाइड्स पर फुटर, तिथि/समय, और स्लाइड-नंबर प्लेसहोल्डर्स का उपयोग करें। हेडर प्लेसहोल्डर नोट्स पेज और हैंडआउट्स में उपलब्ध होते हैं।

**यदि फुटर, तिथि/समय, या स्लाइड-नंबर प्लेसहोल्डर दृश्य नहीं है तो क्या करें?**

संबंधित हेडर/फुटर मैनेजर का उपयोग करके उसकी दृश्यता जाँचें और आवश्यकता होने पर इसे सक्रिय करें। उदाहरण के लिए, [isFooterVisible](https://reference.aspose.com/slides/hi/python-java/aspose.slides/baseslideheaderfootermanager/#isFooterVisible) रिपोर्ट करता है कि फुटर प्लेसहोल्डर मौजूद है या नहीं, और [setFooterVisibility](https://reference.aspose.com/slides/hi/python-java/aspose.slides/baseslideheaderfootermanager/#setFooterVisibility) उसकी दृश्यता को बदलता है।

**स्लाइड नंबरिंग को 1 के अलावा किसी मान से शुरू कैसे करूँ?**

प्रेजेंटेशन की [setFirstSlideNumber](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#setFirstSlideNumber) मेथड को कॉल करें। इसके बाद स्लाइड-नंबर प्लेसहोल्डर अपडेटेड क्रमांक अनुक्रम का उपयोग करेंगे।

**PDF, इमेज या HTML में एक्सपोर्ट करते समय हेडर और फुटर का क्या होता है?**

दृश्यमान हेडर और फुटर तत्व आउटपुट फॉर्मेट में प्रेजेंटेशन की बाकी सामग्री के साथ रेंडर होते हैं। उनका स्वरूप उस पेज प्रकार और संबंधित प्लेसहोल्डर दृश्यता सेटिंग्स पर निर्भर करता है।