---
title: Python के साथ प्रस्तुति हेडर और फुटर प्रबंधित करें
linktitle: हेडर और फुटर
type: docs
weight: 140
url: /hi/python-net/presentation-header-and-footer/
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
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET का उपयोग करके स्लाइड्स, नोट्स पेज़ और हैंडआउट्स पर फुटर, तारीख‑समय, स्लाइड‑नंबर और हेडर प्लेसहोल्डर को कैसे प्रबंधित करें, जानें।"
---
## **परिचय**

PowerPoint विभिन्न पृष्ठ प्रकारों के आधार पर अलग‑अलग हेडर और फुटर प्लेसहोल्डर का उपयोग करता है। Aspose.Slides for Python via .NET आपको इन प्लेसहोल्डर के टेक्स्ट और दृश्यता को हेडर/फुटर मैनेजर क्लासों के माध्यम से नियंत्रित करने देता है।

उपलब्ध प्लेसहोल्डर क्षेत्र पर निर्भर करते हैं:

| क्षेत्र | हेडर | फुटर | तारीख/समय | स्लाइड/पृष्ठ संख्या |
|---|---|---|---|---|
| Regular slide | नहीं | हाँ | हाँ | हाँ |
| Notes master | हाँ | हाँ | हाँ | हाँ |
| Notes slide | हाँ | हाँ | हाँ | हाँ |
| Handout master | हाँ | हाँ | हाँ | हाँ |

एक नियमित प्रस्तुति स्लाइड में हेडर प्लेसहोल्डर नहीं होता। हेडर नोट पृष्ठों और हैंडआउट्स में उपलब्ध होते हैं। नियमित स्लाइड्स के लिए फुटर, तारीख/समय, और स्लाइड‑नंबर प्लेसहोल्डर का उपयोग करें।

परिवर्तन का दायरा उस मैनेजर पर निर्भर करता है जिसका आप उपयोग करते हैं। [`SlideHeaderFooterManager`](https://reference.aspose.com/slides/hi/python-net/aspose.slides/slideheaderfootermanager/) क्लास एक नियमित स्लाइड को नियंत्रित करती है। [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/hi/python-net/aspose.slides/notesslideheaderfootermanager/) क्लास एक नोट्स स्लाइड को नियंत्रित करती है। मास्टर और लेआउट मैनेजर्स भी सेटिंग्स को निर्भर स्लाइड्स तक पहुँचाने में सक्षम होते हैं, जबकि [`MasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/hi/python-net/aspose.slides/masterhandoutslideheaderfootermanager/) क्लास हैंडआउट मास्टर को नियंत्रित करती है।

## **नियमित स्लाइड्स पर फुटर, तारीख/समय, और स्लाइड नंबर सेट करना**

नियमित स्लाइड्स के लिए बुनियादी वर्कफ़्लो यह है कि प्रत्येक स्लाइड के हेडर/फुटर मैनेजर तक पहुँचें, फुटर और तारीख/समय टेक्स्ट सेट करें, आवश्यक प्लेसहोल्डर को सक्षम करें, और प्रस्तुति सहेजें। स्लाइड नंबर प्रस्तुति द्वारा उत्पन्न होते हैं, इसलिए आपको केवल उनकी दृश्यता को नियंत्रित करना होता है।

टेक्स्ट सेट करने के लिए [`set_footer_text`](https://reference.aspose.com/slides/hi/python-net/aspose.slides/baseslideheaderfootermanager/set_footer_text/) और [`set_date_time_text`](https://reference.aspose.com/slides/hi/python-net/aspose.slides/baseslideheaderfootermanager/set_date_time_text/) का उपयोग करें, और संबंधित प्लेसहोल्डर दिखाने के लिए [`set_footer_visibility`](https://reference.aspose.com/slides/hi/python-net/aspose.slides/baseslideheaderfootermanager/set_footer_visibility/), [`set_date_time_visibility`](https://reference.aspose.com/slides/hi/python-net/aspose.slides/baseslideheaderfootermanager/set_date_time_visibility/), और [`set_slide_number_visibility`](https://reference.aspose.com/slides/hi/python-net/aspose.slides/baseslideheaderfootermanager/set_slide_number_visibility/) का उपयोग करें।

नीचे दिया गया एंड‑टू‑एंड उदाहरण सभी नियमित स्लाइड्स पर समान फुटर, तारीख/समय टेक्स्ट, और स्लाइड‑नंबर दृश्यता लागू करता है:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for slide in presentation.slides:
        header_footer_manager = slide.header_footer_manager

        header_footer_manager.set_footer_text("Company Confidential")
        header_footer_manager.set_footer_visibility(True)

        header_footer_manager.set_date_time_text("Date and time text")
        header_footer_manager.set_date_time_visibility(True)

        header_footer_manager.set_slide_number_visibility(True)

    presentation.save("presentation_with_slide_footers.pptx", slides.export.SaveFormat.PPTX)
```

यदि आपको केवल एक स्लाइड को अद्यतन करना है, तो पूरी कलेक्शन को इटररेट करने के बजाय सीधे उस स्लाइड को [`slides`](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/slides/hi/) कलेक्शन से एक्सेस करें।

## **Notes Master पर हेडर और फुटर सेट करना**

Notes master नोट्स पृष्ठों के लिये सामान्य फॉर्मेटिंग और प्लेसहोल्डर व्यवहार को परिभाषित करता है। जब आप केवल नोट्स मास्टर को बदलना चाहते हैं, तो [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/hi/python-net/aspose.slides/masternotesslideheaderfootermanager/) क्लास का प्रयोग करें।

निम्न उदाहरण notes master पर हेडर, फुटर, और तारीख/समय टेक्स्ट सेट करता है और उस मास्टर पर सभी समर्थित प्लेसहोल्डर को दिखाई देने योग्य बनाता है:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    master_notes_slide = presentation.master_notes_slide_manager.master_notes_slide

    if master_notes_slide is not None:
        header_footer_manager = master_notes_slide.header_footer_manager

        header_footer_manager.set_header_text("Notes header")
        header_footer_manager.set_header_visibility(True)

        header_footer_manager.set_footer_text("Notes footer")
        header_footer_manager.set_footer_visibility(True)

        header_footer_manager.set_date_time_text("Date and time text")
        header_footer_manager.set_date_time_visibility(True)

        header_footer_manager.set_slide_number_visibility(True)

    presentation.save("presentation_with_notes_master_footers.pptx", slides.export.SaveFormat.PPTX)
```

प्रस्तुति में notes master मौजूद नहीं हो सकता, इसलिए इसे बदलने से पहले `None` के लिये लौटाए गए मान की जाँच करें।

## **Child Notes Slides पर Notes Master सेटिंग्स लागू करना**

Notes master स्वयं और सभी निर्भर नोट्स स्लाइड्स पर हेडर और फुटर सेटिंग्स लागू कर सकता है। जब समान सेटिंग्स को नोट्स पदानुक्रम में सभी स्तरों पर लागू करना हो, तो [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/hi/python-net/aspose.slides/masternotesslideheaderfootermanager/) की समर्पित प्रसारण विधियों का उपयोग करें।

उदाहरण के लिये, [`set_header_and_child_headers_text`](https://reference.aspose.com/slides/hi/python-net/aspose.slides/masternotesslideheaderfootermanager/set_header_and_child_headers_text/) और [`set_header_and_child_headers_visibility`](https://reference.aspose.com/slides/hi/python-net/aspose.slides/masternotesslideheaderfootermanager/set_header_and_child_headers_visibility/) notes master हेडर और सभी चाइल्ड हेडर को अपडेट करते हैं। फुटर, तारीख/समय, और स्लाइड नंबर के लिये समकक्ष विधियाँ उपलब्ध हैं।

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    master_notes_slide = presentation.master_notes_slide_manager.master_notes_slide

    if master_notes_slide is not None:
        header_footer_manager = master_notes_slide.header_footer_manager

        header_footer_manager.set_header_and_child_headers_text("Notes header")
        header_footer_manager.set_header_and_child_headers_visibility(True)

        header_footer_manager.set_footer_and_child_footers_text("Notes footer")
        header_footer_manager.set_footer_and_child_footers_visibility(True)

        header_footer_manager.set_date_time_and_child_date_times_text("Date and time text")
        header_footer_manager.set_date_time_and_child_date_times_visibility(True)

        header_footer_manager.set_slide_number_and_child_slide_numbers_visibility(True)

    presentation.save("presentation_with_child_notes_footers.pptx", slides.export.SaveFormat.PPTX)
```

उपरोक्त प्रसारण विधियाँ हैं [`set_footer_and_child_footers_text`](https://reference.aspose.com/slides/hi/python-net/aspose.slides/masternotesslideheaderfootermanager/set_footer_and_child_footers_text/), [`set_footer_and_child_footers_visibility`](https://reference.aspose.com/slides/hi/python-net/aspose.slides/masternotesslideheaderfootermanager/set_footer_and_child_footers_visibility/), [`set_date_time_and_child_date_times_text`](https://reference.aspose.com/slides/hi/python-net/aspose.slides/masternotesslideheaderfootermanager/set_date_time_and_child_date_times_text/), [`set_date_time_and_child_date_times_visibility`](https://reference.aspose.com/slides/hi/python-net/aspose.slides/masternotesslideheaderfootermanager/set_date_time_and_child_date_times_visibility/), और [`set_slide_number_and_child_slide_numbers_visibility`](https://reference.aspose.com/slides/hi/python-net/aspose.slides/masternotesslideheaderfootermanager/set_slide_number_and_child_slide_numbers_visibility/)।

## **व्यक्तिगत नोट्स स्लाइड पर हेडर और फुटर सेट करना**

एक नोट्स स्लाइड विशेष नियमित स्लाइड से जुड़ी होती है। जब आप केवल उसी नोट्स पृष्ठ को अनुकूलित करना चाहते हैं, तो उसकी [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/hi/python-net/aspose.slides/notesslideheaderfootermanager/) क्लास का प्रयोग करें।

[`add_notes_slide`](https://reference.aspose.com/slides/hi/python-net/aspose.slides/notesslidemanager/add_notes_slide/) मेथड वर्तमान स्लाइड के लिये नोट्स स्लाइड लौटाता है और यदि वह पहले से मौजूद नहीं है तो नई बनाता है। निम्न उदाहरण प्रथम प्रस्तुति स्लाइड से संबंधित नोट्स पृष्ठ को कॉन्फ़िगर करता है:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    notes_slide = presentation.slides[0].notes_slide_manager.add_notes_slide()
    header_footer_manager = notes_slide.header_footer_manager

    header_footer_manager.set_header_text("Header for the first notes page")
    header_footer_manager.set_header_visibility(True)

    header_footer_manager.set_footer_text("Footer for the first notes page")
    header_footer_manager.set_footer_visibility(True)

    header_footer_manager.set_date_time_text("Date and time text")
    header_footer_manager.set_date_time_visibility(True)

    header_footer_manager.set_slide_number_visibility(True)

    presentation.save("presentation_with_custom_notes_footers.pptx", slides.export.SaveFormat.PPTX)
```

यदि आप पहले नोट्स मास्टर से सेटिंग्स प्रसारित करें और फिर व्यक्तिगत नोट्स स्लाइड को बदलें, तो बाद की प्रति‑स्लाइड सेटिंग्स आपको उस नोट्स पृष्ठ को स्वतंत्र रूप से अनुकूलित करने देती हैं।

## **Handout Master पर हेडर और फुटर सेट करना**

Handout पृष्ठ अपने हेडर, फुटर, तारीख/समय, और पृष्ठ‑संख्या प्लेसहोल्डर के लिये handout master का उपयोग करते हैं। नोट्स पृष्ठों के विपरीत, handout सेटिंग्स व्यक्तिगत handout स्लाइड्स के बजाय handout master के माध्यम से प्रबंधित की जाती हैं।

हैंडआउट मास्टर तक पहुँचने के लिये [`master_handout_slide`](https://reference.aspose.com/slides/hi/python-net/aspose.slides/imasterhandoutslidemanager/master_handout_slide/) प्रॉपर्टी का उपयोग करें। यदि यह मौजूद नहीं है, तो डिफ़ॉल्ट handout master बनाने के लिये [`set_default_master_handout_slide`](https://reference.aspose.com/slides/hi/python-net/aspose.slides/imasterhandoutslidemanager/set_default_master_handout_slide/) को कॉल करें।

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    master_handout_slide = presentation.master_handout_slide_manager.master_handout_slide

    if master_handout_slide is None:
        presentation.master_handout_slide_manager.set_default_master_handout_slide()
        master_handout_slide = presentation.master_handout_slide_manager.master_handout_slide

    if master_handout_slide is not None:
        header_footer_manager = master_handout_slide.header_footer_manager

        header_footer_manager.set_header_text("Handout header")
        header_footer_manager.set_header_visibility(True)

        header_footer_manager.set_footer_text("Handout footer")
        header_footer_manager.set_footer_visibility(True)

        header_footer_manager.set_date_time_text("Date and time text")
        header_footer_manager.set_date_time_visibility(True)

        header_footer_manager.set_slide_number_visibility(True)

    presentation.save("presentation_with_handout_footers.pptx", slides.export.SaveFormat.PPTX)
```

## **दायरा और विरासत को समझना**

उस हेडर/फुटर मैनेजर को चुनें जो आपके परिवर्तन के दायरे से मेल खाता हो:

- [`SlideHeaderFooterManager`](https://reference.aspose.com/slides/hi/python-net/aspose.slides/slideheaderfootermanager/) एक नियमित स्लाइड के लिये फुटर, तारीख/समय, और स्लाइड‑नंबर सेटिंग्स बदलता है।
- [`LayoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/hi/python-net/aspose.slides/layoutslideheaderfootermanager/) लेआउट स्लाइड को नियंत्रित करता है और समर्थित सेटिंग्स को निर्भर स्लाइड्स तक प्रसारित कर सकता है।
- [`MasterSlideHeaderFooterManager`](https://reference.aspose.com/slides/hi/python-net/aspose.slides/masterslideheaderfootermanager/) नियमित स्लाइड मास्टर को नियंत्रित करता है और समर्थित सेटिंग्स को निर्भर स्लाइड्स तक प्रसारित कर सकता है।
- [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/hi/python-net/aspose.slides/masternotesslideheaderfootermanager/) नोट्स मास्टर को नियंत्रित करता है और सभी निर्भर नोट्स स्लाइड्स को सेटिंग्स प्रसारित कर सकता है।
- [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/hi/python-net/aspose.slides/notesslideheaderfootermanager/) एक नोट्स स्लाइड को बदलता है तथा फुटर, तारीख/समय, और स्लाइड‑नंबर के अतिरिक्त हेडर प्लेसहोल्डर का समर्थन करता है।
- [`MasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/hi/python-net/aspose.slides/masterhandoutslideheaderfootermanager/) handout मास्टर को बदलता है और सभी चार प्रकार के प्लेसहोल्डर का समर्थन करता है।

जब एक ही सेटिंग पूरी पदानुक्रम में लागू होनी चाहिए, तो मास्टर या लेआउट से प्रसारण उपयोग करें। जब आपको एक पृष्ठ के लिये स्थानीय सेटिंग चाहिए, तो व्यक्तिगत स्लाइड या नोट्स‑स्लाइड मैनेजर का प्रयोग करें।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं नियमित स्लाइड में हेडर जोड़ सकता हूँ?**

नहीं। PowerPoint नियमित स्लाइड्स के लिये हेडर प्लेसहोल्डर परिभाषित नहीं करता। नियमित स्लाइड्स पर फुटर, तारीख/समय, और स्लाइड‑नंबर प्लेसहोल्डर का उपयोग करें। हेडर प्लेसहोल्डर नोट पृष्ठों और हैंडआउट्स में उपलब्ध होते हैं।

**यदि फुटर, तारीख/समय, या स्लाइड‑नंबर प्लेसहोल्डर दृश्यमान नहीं है तो क्या करना चाहिए?**

संबंधित हेडर/फुटर मैनेजर का उपयोग करके उसकी दृश्यता जाँचें और आवश्यकता पड़ने पर सक्षम करें। उदाहरण के लिये, [`is_footer_visible`](https://reference.aspose.com/slides/hi/python-net/aspose.slides/baseslideheaderfootermanager/is_footer_visible/) यह बताता है कि फुटर प्लेसहोल्डर मौजूद है या नहीं, और [`set_footer_visibility`](https://reference.aspose.com/slides/hi/python-net/aspose.slides/baseslideheaderfootermanager/set_footer_visibility/) उसकी दृश्यता बदलता है।

**मैं स्लाइड नंबरिंग को 1 के अलावा किसी अन्य मान से कैसे शुरू करूँ?**

प्रस्तुति की [`first_slide_number`](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/first_slide_number/) प्रॉपर्टी सेट करें। स्लाइड‑नंबर प्लेसहोल्डर तब अद्यतन क्रम का उपयोग करेंगे।

**PDF, इमेज, या HTML में निर्यात करते समय हेडर और फुटर क्या होते हैं?**

दृश्यमान हेडर और फुटर तत्व आउटपुट फॉर्मेट में प्रस्तुति सामग्री के साथ रेंडर होते हैं। उनका स्वरूप निर्यात किए जा रहे पृष्ठ प्रकार और संबंधित प्लेसहोल्डर की दृश्यता सेटिंग्स पर निर्भर करता है।