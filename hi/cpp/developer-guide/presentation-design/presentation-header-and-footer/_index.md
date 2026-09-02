---
title: C++ में प्रस्तुति हेडर और फुटर को प्रबंधित करें
linktitle: हेडर और फुटर
type: docs
weight: 140
url: /hi/cpp/presentation-header-and-footer/
keywords:
- हेडर
- हेडर पाठ
- फुटर
- फुटर पाठ
- हेडर सेट करें
- फुटर सेट करें
- हैंडआउट
- नोट्स
- PowerPoint
- OpenDocument
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ के साथ स्लाइड्स, नोट्स पेजों और हैंडआउट्स में फुटर, तिथि-समय, स्लाइड-नंबर और हेडर प्लेसहोल्डर को कैसे प्रबंधित करें जानें।"
---
## **अवलोकन**

PowerPoint पृष्ठ प्रकार के आधार पर विभिन्न हेडर और फुटर प्लेसहोल्डर का उपयोग करता है। Aspose.Slides for C++ आपको इन प्लेसहोल्डर के पाठ और दृश्यता को हेडर/फुटर मैनेजर इंटरफ़ेस के माध्यम से नियंत्रित करने देता है।

उपलब्ध प्लेसहोल्डर स्कोप पर निर्भर करते हैं:

| स्कोप | हेडर | फुटर | तिथि/समय | स्लाइड/पृष्ठ संख्या |
|---|---|---|---|---|
| सामान्य स्लाइड | नहीं | हाँ | हाँ | हाँ |
| नोट्स मास्टर | हाँ | हाँ | हाँ | हाँ |
| नोट्स स्लाइड | हाँ | हाँ | हाँ | हाँ |
| हैंडआउट मास्टर | हाँ | हाँ | हाँ | हाँ |

एक सामान्य प्रस्तुति स्लाइड में हेडर प्लेसहोल्डर नहीं होता। हेडर नोट्स पृष्ठों और हैंडआउट में उपलब्ध होते हैं। सामान्य स्लाइड्स के लिए, फुटर, तिथि/समय और स्लाइड‑नंबर प्लेसहोल्डर का उपयोग करें।

परिवर्तन का स्कोप उस मैनेजर पर निर्भर करता है जिसे आप उपयोग करते हैं। [`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/hi/cpp/aspose.slides/islideheaderfootermanager/) इंटरफ़ेस एक सामान्य स्लाइड को नियंत्रित करता है। [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/hi/cpp/aspose.slides/inotesslideheaderfootermanager/) इंटरफ़ेस एक नोट्स स्लाइड को नियंत्रित करता है। मास्टर और लेआउट मैनेजर्स सेटिंग्स को आश्रित स्लाइड्स में प्रसारित कर सकते हैं, जबकि [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/hi/cpp/aspose.slides/imasterhandoutslideheaderfootermanager/) इंटरफ़ेस हैंडआउट मास्टर को नियंत्रित करता है।

## **सामान्य स्लाइड्स पर फुटर, तिथि/समय और स्लाइड संख्या सेट करें**

सामान्य स्लाइड्स के लिए मूल वर्कफ़्लो यह है कि प्रत्येक स्लाइड के हेडर/फ़ुटर मैनेजर तक पहुँचें, फुटर और तिथि/समय का पाठ सेट करें, आवश्यक प्लेसहोल्डर सक्रिय करें, और प्रस्तुति सहेजें। स्लाइड संख्याएँ प्रस्तुति द्वारा उत्पन्न होती हैं, इसलिए आपको केवल उनकी दृश्यता को नियंत्रित करने की आवश्यकता है।

पाठ सेट करने के लिए [`SetFooterText`](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ibaseslideheaderfootermanager/setfootertext/) और [`SetDateTimeText`](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ibaseslideheaderfootermanager/setdatetimetext/) का उपयोग करें, और संबंधित प्लेसहोल्डर दिखाने के लिए [`SetFooterVisibility`](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ibaseslideheaderfootermanager/setfootervisibility/), [`SetDateTimeVisibility`](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ibaseslideheaderfootermanager/setdatetimevisibility/), तथा [`SetSlideNumberVisibility`](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ibaseslideheaderfootermanager/setslidenumbervisibility/) का उपयोग करें।

निम्नलिखित एंड‑टू‑एंड उदाहरण सभी सामान्य स्लाइड्स में एक ही फुटर, तिथि/समय पाठ और स्लाइड‑नंबर दृश्यता लागू करता है:

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideHeaderFooterManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/enumerator_adapter.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

for (const auto& slide : System::IterateOver(presentation->get_Slides()))
{
    auto headerFooterManager = slide->get_HeaderFooterManager();

    headerFooterManager->SetFooterText(u"Company Confidential");
    headerFooterManager->SetFooterVisibility(true);

    headerFooterManager->SetDateTimeText(u"Date and time text");
    headerFooterManager->SetDateTimeVisibility(true);

    headerFooterManager->SetSlideNumberVisibility(true);
}

presentation->Save(u"presentation_with_slide_footers.pptx", SaveFormat::Pptx);
```

यदि आपको केवल एक स्लाइड को अपडेट करना है, तो पूरे स्लाइड संग्रह को पुनरावृति करने के बजाय [`Presentation::get_Slide`](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/get_slide/) के माध्यम से उस स्लाइड तक सीधे पहुँचें।

## **नोट्स मास्टर पर हेडर और फुटर सेट करें**

नोट्स मास्टर नोट्स पृष्ठों के लिए सामान्य स्वरूपण और प्लेसहोल्डर व्यवहार को परिभाषित करता है। केवल नोट्स मास्टर को बदलना चाहते हैं तो [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/hi/cpp/aspose.slides/imasternotesslideheaderfootermanager/) इंटरफ़ेस का उपयोग करें।

निम्न उदाहरण नोट्स मास्टर पर हेडर, फुटर और तिथि/समय पाठ सेट करता है और उस मास्टर पर सभी समर्थित प्लेसहोल्डर को दृश्य बनाता है:

```cpp
#include <DOM/IMasterNotesSlide.h>
#include <DOM/IMasterNotesSlideHeaderFooterManager.h>
#include <DOM/IMasterNotesSlideManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto masterNotesSlide = presentation->get_MasterNotesSlideManager()->get_MasterNotesSlide();

if (masterNotesSlide != nullptr)
{
    auto headerFooterManager = masterNotesSlide->get_HeaderFooterManager();

    headerFooterManager->SetHeaderText(u"Notes header");
    headerFooterManager->SetHeaderVisibility(true);

    headerFooterManager->SetFooterText(u"Notes footer");
    headerFooterManager->SetFooterVisibility(true);

    headerFooterManager->SetDateTimeText(u"Date and time text");
    headerFooterManager->SetDateTimeVisibility(true);

    headerFooterManager->SetSlideNumberVisibility(true);
}

presentation->Save(u"presentation_with_notes_master_footers.pptx", SaveFormat::Pptx);
```

[`IMasterNotesSlideManager::get_MasterNotesSlide`](https://reference.aspose.com/slides/hi/cpp/aspose.slides/imasternotesslidemanager/get_masternotesslide/) मेथड `nullptr` लौटाता है जब प्रस्तुति में नोट्स मास्टर नहीं होता।

## **नोट्स मास्टर सेटिंग्स को चाइल्ड नोट्स स्लाइड्स पर लागू करें**

नोट्स मास्टर अपने और सभी आश्रित नोट्स स्लाइड्स पर हेडर और फुटर सेटिंग्स लागू कर सकता है। जब समान सेटिंग्स नोट्स पदानुक्रम में सभी स्तरों पर लागू करनी हों, तो [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/hi/cpp/aspose.slides/imasternotesslideheaderfootermanager/) पर समर्पित प्रसार मेथड्स का उपयोग करें।

उदाहरण के लिए, [`SetHeaderAndChildHeadersText`](https://reference.aspose.com/slides/hi/cpp/aspose.slides/imasternotesslideheaderfootermanager/setheaderandchildheaderstext/) और [`SetHeaderAndChildHeadersVisibility`](https://reference.aspose.com/slides/hi/cpp/aspose.slides/imasternotesslideheaderfootermanager/setheaderandchildheadersvisibility/) नोट्स मास्टर हेडर और सभी चाइल्ड हेडर्स को अपडेट करते हैं। फुटर, तिथि/समय, और स्लाइड नंबर के लिए समान मेथड उपलब्ध हैं।

```cpp
#include <DOM/IMasterNotesSlide.h>
#include <DOM/IMasterNotesSlideHeaderFooterManager.h>
#include <DOM/IMasterNotesSlideManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto masterNotesSlide = presentation->get_MasterNotesSlideManager()->get_MasterNotesSlide();

if (masterNotesSlide != nullptr)
{
    auto headerFooterManager = masterNotesSlide->get_HeaderFooterManager();

    headerFooterManager->SetHeaderAndChildHeadersText(u"Notes header");
    headerFooterManager->SetHeaderAndChildHeadersVisibility(true);

    headerFooterManager->SetFooterAndChildFootersText(u"Notes footer");
    headerFooterManager->SetFooterAndChildFootersVisibility(true);

    headerFooterManager->SetDateTimeAndChildDateTimesText(u"Date and time text");
    headerFooterManager->SetDateTimeAndChildDateTimesVisibility(true);

    headerFooterManager->SetSlideNumberAndChildSlideNumbersVisibility(true);
}

presentation->Save(u"presentation_with_child_notes_footers.pptx", SaveFormat::Pptx);
```

उपरोक्त में उपयोग किए गए प्रसार मेथड्स हैं [`SetFooterAndChildFootersText`](https://reference.aspose.com/slides/hi/cpp/aspose.slides/imasternotesslideheaderfootermanager/setfooterandchildfooterstext/), [`SetFooterAndChildFootersVisibility`](https://reference.aspose.com/slides/hi/cpp/aspose.slides/imasternotesslideheaderfootermanager/setfooterandchildfootersvisibility/), [`SetDateTimeAndChildDateTimesText`](https://reference.aspose.com/slides/hi/cpp/aspose.slides/imasternotesslideheaderfootermanager/setdatetimeandchilddatetimestext/), [`SetDateTimeAndChildDateTimesVisibility`](https://reference.aspose.com/slides/hi/cpp/aspose.slides/imasternotesslideheaderfootermanager/setdatetimeandchilddatetimesvisibility/), तथा [`SetSlideNumberAndChildSlideNumbersVisibility`](https://reference.aspose.com/slides/hi/cpp/aspose.slides/imasternotesslideheaderfootermanager/setslidenumberandchildslidenumbersvisibility/)।

## **व्यक्तिगत नोट्स स्लाइड पर हेडर और फुटर सेट करें**

एक नोट्स स्लाइड एक विशिष्ट सामान्य स्लाइड से जुड़ी होती है। केवल उस नोट्स पृष्ठ को अनुकूलित करना चाहते हैं तो उसके [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/hi/cpp/aspose.slides/inotesslideheaderfootermanager/) इंटरफ़ेस का उपयोग करें।

[`INotesSlideManager::AddNotesSlide`](https://reference.aspose.com/slides/hi/cpp/aspose.slides/inotesslidemanager/addnotesslide/) मेथड वर्तमान स्लाइड के लिए नोट्स स्लाइड लौटाता है और यदि वह मौजूद नहीं है तो इसे बनाता है। निम्न उदाहरण पहली प्रस्तुति स्लाइड से सम्बंधित नोट्स पृष्ठ को कॉन्फ़िगर करता है:

```cpp
#include <DOM/INotesSlide.h>
#include <DOM/INotesSlideHeaderFooterManager.h>
#include <DOM/INotesSlideManager.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto slide = presentation->get_Slide(0);
auto notesSlide = slide->get_NotesSlideManager()->AddNotesSlide();
auto headerFooterManager = notesSlide->get_HeaderFooterManager();

headerFooterManager->SetHeaderText(u"Header for the first notes page");
headerFooterManager->SetHeaderVisibility(true);

headerFooterManager->SetFooterText(u"Footer for the first notes page");
headerFooterManager->SetFooterVisibility(true);

headerFooterManager->SetDateTimeText(u"Date and time text");
headerFooterManager->SetDateTimeVisibility(true);

headerFooterManager->SetSlideNumberVisibility(true);

presentation->Save(u"presentation_with_custom_notes_footers.pptx", SaveFormat::Pptx);
```

यदि आप पहले नोट्स मास्टर से सेटिंग्स प्रसारित करते हैं और फिर व्यक्तिगत नोट्स स्लाइड बदलते हैं, तो बाद की प्रति‑स्लाइड सेटिंग्स आपको उस नोट्स पृष्ठ को स्वतंत्र रूप से अनुकूलित करने देती है।

## **हैंडआउट मास्टर पर हेडर और फुटर सेट करें**

हैंडआउट पृष्ठ अपने हेडर, फुटर, तिथि/समय और पृष्ठ‑संख्या प्लेसहोल्डर के लिए हैंडआउट मास्टर का उपयोग करते हैं। नोट्स पृष्ठों के विपरीत, हैंडआउट सेटिंग्स व्यक्तिगत हैंडआउट स्लाइड्स के माध्यम से नहीं, बल्कि हैंडआउट मास्टर के माध्यम से प्रबंधित होती हैं।

हैंडआउट मास्टर तक पहुँचने के लिए [`IMasterHandoutSlideManager::get_MasterHandoutSlide`](https://reference.aspose.com/slides/hi/cpp/aspose.slides/imasterhandoutslidemanager/get_masterhandoutslide/) का उपयोग करें। यदि यह मौजूद नहीं है, तो डिफ़ॉल्ट हैंडआउट मास्टर बनाने के लिए [`IMasterHandoutSlideManager::SetDefaultMasterHandoutSlide`](https://reference.aspose.com/slides/hi/cpp/aspose.slides/imasterhandoutslidemanager/setdefaultmasterhandoutslide/) को कॉल करें।

```cpp
#include <DOM/IMasterHandoutSlide.h>
#include <DOM/IMasterHandoutSlideHeaderFooterManager.h>
#include <DOM/IMasterHandoutSlideManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto masterHandoutSlideManager = presentation->get_MasterHandoutSlideManager();
auto masterHandoutSlide = masterHandoutSlideManager->get_MasterHandoutSlide();

if (masterHandoutSlide == nullptr)
{
    masterHandoutSlide = masterHandoutSlideManager->SetDefaultMasterHandoutSlide();
}

if (masterHandoutSlide != nullptr)
{
    auto headerFooterManager = masterHandoutSlide->get_HeaderFooterManager();

    headerFooterManager->SetHeaderText(u"Handout header");
    headerFooterManager->SetHeaderVisibility(true);

    headerFooterManager->SetFooterText(u"Handout footer");
    headerFooterManager->SetFooterVisibility(true);

    headerFooterManager->SetDateTimeText(u"Date and time text");
    headerFooterManager->SetDateTimeVisibility(true);

    headerFooterManager->SetSlideNumberVisibility(true);
}

presentation->Save(u"presentation_with_handout_footers.pptx", SaveFormat::Pptx);
```

## **स्कोप और इनहेरिटेंस को समझें**

उस हेडर/फुटर मैनेजर को चुनें जो आपके बदलने वाले स्कोप से मेल खाता हो:

- [`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/hi/cpp/aspose.slides/islideheaderfootermanager/) एक सामान्य स्लाइड के लिए फुटर, तिथि/समय और स्लाइड‑नंबर सेटिंग्स बदलता है।
- [`ILayoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ilayoutslideheaderfootermanager/) एक लेआउट स्लाइड को नियंत्रित करता है और समर्थित सेटिंग्स को आश्रित स्लाइड्स में प्रसारित कर सकता है।
- [`IMasterSlideHeaderFooterManager`](https://reference.aspose.com/slides/hi/cpp/aspose.slides/imasterslideheaderfootermanager/) एक सामान्य स्लाइड मास्टर को नियंत्रित करता है और समर्थित सेटिंग्स को आश्रित स्लाइड्स में प्रसारित कर सकता है।
- [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/hi/cpp/aspose.slides/imasternotesslideheaderfootermanager/) नोट्स मास्टर को नियंत्रित करता है और सभी आश्रित नोट्स स्लाइड्स में सेटिंग्स प्रसारित कर सकता है।
- [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/hi/cpp/aspose.slides/inotesslideheaderfootermanager/) एक नोट्स स्लाइड को बदलता है और फुटर, तिथि/समय तथा स्लाइड‑नंबर के अतिरिक्त हेडर प्लेसहोल्डर का समर्थन करता है।
- [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/hi/cpp/aspose.slides/imasterhandoutslideheaderfootermanager/) हैंडआउट मास्टर को बदलता है और सभी चार प्रकार के प्लेसहोल्डर का समर्थन करता है।

जब एक ही सेटिंग पूरे पदानुक्रम में लागू करनी हो तो मास्टर या लेआउट से प्रसारण का प्रयोग करें। जब केवल एक पृष्ठ के लिए स्थानीय सेटिंग चाहिए तो व्यक्तिगत स्लाइड या नोट्स‑स्लाइड मैनेजर का उपयोग करें।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं नियमित स्लाइड में हेडर जोड़ सकता हूँ?**

नहीं। PowerPoint नियमित स्लाइड्स के लिए हेडर प्लेसहोल्डर परिभाषित नहीं करता। नियमित स्लाइड्स पर फुटर, तिथि/समय और स्लाइड‑नंबर प्लेसहोल्डर का उपयोग करें। हेडर प्लेसहोल्डर नोट्स पृष्ठों और हैंडआउट में उपलब्ध होते हैं।

**यदि फुटर, तिथि/समय, या स्लाइड‑नंबर प्लेसहोल्डर दिखाई नहीं दे रहा है तो क्या करें?**

संबंधित हेडर/फ़ुटर मैनेजर का उपयोग करके उसकी दृश्यता जांचें और आवश्यक होने पर इसे सक्रिय करें। उदाहरण के लिए, [`get_IsFooterVisible`](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ibaseslideheaderfootermanager/get_isfootervisible/) बताता है कि फुटर प्लेसहोल्डर मौजूद है या नहीं, और [`SetFooterVisibility`](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ibaseslideheaderfootermanager/setfootervisibility/) उसकी दृश्यता बदलता है।

**मैं स्लाइड नम्बरिंग को 1 के बजाय किसी अन्य मान से कैसे शुरू करूँ?**

[`Presentation::set_FirstSlideNumber`](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/set_firstslidenumber/) का उपयोग करके पहली स्लाइड संख्या सेट करें। इसके बाद स्लाइड‑नंबर प्लेसहोल्डर अद्यतन क्रमांक अनुक्रम का उपयोग करेंगे।

**PDF, इमेज या HTML में निर्यात करते समय हेडर और फुटर का क्या होता है?**

दृश्यमान हेडर और फुटर तत्व आउटपुट फ़ॉर्मेट में प्रस्तुति की शेष सामग्री के साथ रेंडर होते हैं। उनका स्वरूप निर्यात किए जा रहे पृष्ठ प्रकार और संबंधित प्लेसहोल्डर दृश्यता सेटिंग्स पर निर्भर करता है।