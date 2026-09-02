---
title: .NET में प्रस्तुति हेडर और फुटर प्रबंधित करें
linktitle: हेडर और फुटर
type: docs
weight: 140
url: /hi/net/presentation-header-and-footer/
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
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET के साथ स्लाइड, नोट्स पृष्ठ और हैंडआउट पर फुटर, तारीख‑समय, स्लाइड‑नंबर और हेडर प्लेसहोल्डर को प्रबंधित करना सीखें।"
---
## **अवलोकन**

PowerPoint पृष्ठ प्रकार के आधार पर विभिन्न हेडर और फुटर प्लेसहोल्डर का उपयोग करता है। Aspose.Slides for .NET आपको इन प्लेसहोल्डरों के पाठ और दृश्यता को हेडर/फुटर प्रबंधन इंटरफ़ेस के माध्यम से नियंत्रित करने की अनुमति देता है।

उपलब्ध प्लेसहोल्डर स्कोप पर निर्भर करते हैं:

| स्कोप | हेडर | फुटर | तारीख/समय | स्लाइड/पृष्ठ संख्या |
|---|---|---|---|---|
| साधारण स्लाइड | नहीं | हाँ | हाँ | हाँ |
| नोट्स मास्टर | हाँ | हाँ | हाँ | हाँ |
| नोट्स स्लाइड | हाँ | हाँ | हाँ | हाँ |
| हैंडआउट मास्टर | हाँ | हाँ | हाँ | हाँ |

एक साधारण प्रस्तुति स्लाइड में हेडर प्लेसहोल्डर नहीं होता है। हेडर नोट्स पृष्ठों और हैंडआउट में उपलब्ध होते हैं। साधारण स्लाइड के लिए, फुटर, तारीख/समय, और स्लाइड‑नंबर प्लेसहोल्डर का उपयोग करें।

परिवर्तन का स्कोप आपके द्वारा उपयोग किए जाने वाले प्रबंधक पर निर्भर करता है। [`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/hi/net/aspose.slides/islideheaderfootermanager/) इंटरफ़ेस एक साधारण स्लाइड को नियंत्रित करता है। [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/hi/net/aspose.slides/inotesslideheaderfootermanager/) इंटरफ़ेस एक नोट्स स्लाइड को नियंत्रित करता है। मास्टर और लेआउट प्रबंधक सेटिंग्स को निर्भर स्लाइडों तक भी प्रसारित कर सकते हैं, जबकि [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/hi/net/aspose.slides/imasterhandoutslideheaderfootermanager/) इंटरफ़ेस हैंडआउट मास्टर को नियंत्रित करता है।

## **साधारण स्लाइड पर फुटर, तारीख/समय और स्लाइड नंबर सेट करें**

साधारण स्लाइडों के लिए, मूल कार्यप्रवाह यह है कि प्रत्येक स्लाइड के हेडर/फुटर प्रबंधक तक पहुँचें, फुटर और तारीख/समय का पाठ सेट करें, आवश्यक प्लेसहोल्डर सक्षम करें, और प्रस्तुति को सहेजें। स्लाइड नंबर प्रस्तुति द्वारा उत्पन्न होते हैं, इसलिए आपको केवल उनकी दृश्यता को नियंत्रित करना होता है।

टेक्स्ट सेट करने के लिए [`SetFooterText`](https://reference.aspose.com/slides/hi/net/aspose.slides/baseslideheaderfootermanager/setfootertext/) और [`SetDateTimeText`](https://reference.aspose.com/slides/hi/net/aspose.slides/baseslideheaderfootermanager/setdatetimetext/) का उपयोग करें, और संबंधित प्लेसहोल्डर दिखाने के लिए [`SetFooterVisibility`](https://reference.aspose.com/slides/hi/net/aspose.slides/baseslideheaderfootermanager/setfootervisibility/), [`SetDateTimeVisibility`](https://reference.aspose.com/slides/hi/net/aspose.slides/baseslideheaderfootermanager/setdatetimevisibility/) और [`SetSlideNumberVisibility`](https://reference.aspose.com/slides/hi/net/aspose.slides/baseslideheaderfootermanager/setslidenumbervisibility/) का उपयोग करें।

नीचे दिया गया अंत‑से‑अंत उदाहरण सभी साधारण स्लाइडों पर समान फुटर, तारीख/समय पाठ और स्लाइड‑नंबर दृश्यता लागू करता है:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

foreach (var slide in presentation.Slides)
{
    var headerFooterManager = slide.HeaderFooterManager;

    headerFooterManager.SetFooterText("Company Confidential");
    headerFooterManager.SetFooterVisibility(true);

    headerFooterManager.SetDateTimeText("Date and time text");
    headerFooterManager.SetDateTimeVisibility(true);

    headerFooterManager.SetSlideNumberVisibility(true);
}

presentation.Save("presentation_with_slide_footers.pptx", SaveFormat.Pptx);
```

यदि आपको केवल एक स्लाइड को अपडेट करना है, तो पूरी संग्रह पर इटरशन करने के बजाय [`Slides`](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/slides/hi/) संग्रह के माध्यम से उस स्लाइड तक सीधे पहुँचें।

## **नोट्स मास्टर पर हेडर और फुटर सेट करें**

नोट्स मास्टर नोट्स पृष्ठों के लिए सामान्य फ़ॉर्मेटिंग और प्लेसहोल्डर व्यवहार निर्धारित करता है। जब आप केवल नोट्स मास्टर को बदलना चाहते हैं, तो [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/hi/net/aspose.slides/imasternotesslideheaderfootermanager/) इंटरफ़ेस का उपयोग करें।

निम्न उदाहरण नोट्स मास्टर पर हेडर, फुटर और तारीख/समय पाठ सेट करता है और उस मास्टर पर सभी समर्थित प्लेसहोल्डर को दृश्य बनाता है:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var masterNotesSlide = presentation.MasterNotesSlideManager.MasterNotesSlide;

if (masterNotesSlide != null)
{
    var headerFooterManager = masterNotesSlide.HeaderFooterManager;

    headerFooterManager.SetHeaderText("Notes header");
    headerFooterManager.SetHeaderVisibility(true);

    headerFooterManager.SetFooterText("Notes footer");
    headerFooterManager.SetFooterVisibility(true);

    headerFooterManager.SetDateTimeText("Date and time text");
    headerFooterManager.SetDateTimeVisibility(true);

    headerFooterManager.SetSlideNumberVisibility(true);
}

presentation.Save("presentation_with_notes_master_footers.pptx", SaveFormat.Pptx);
```

`[`MasterNotesSlide`](https://reference.aspose.com/slides/hi/net/aspose.slides/imasternotesslidemanager/masternotesslide/)` प्रॉपर्टी `null` लौटाती है जब प्रस्तुति में नोट्स मास्टर नहीं होता है।

## **नोट्स मास्टर सेटिंग्स को चाइल्ड नोट्स स्लाइड्स पर लागू करें**

एक नोट्स मास्टर हेडर और फुटर सेटिंग्स को स्वयं और सभी निर्भर नोट्स स्लाइड्स पर लागू कर सकता है। जब समान सेटिंग्स को नोट्स क्रम में लागू करने की आवश्यकता हो, तो [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/hi/net/aspose.slides/imasternotesslideheaderfootermanager/) पर समर्पित प्रसरण विधियों का उपयोग करें।

उदाहरण के लिए, [`SetHeaderAndChildHeadersText`](https://reference.aspose.com/slides/hi/net/aspose.slides/masternotesslideheaderfootermanager/setheaderandchildheaderstext/) और [`SetHeaderAndChildHeadersVisibility`](https://reference.aspose.com/slides/hi/net/aspose.slides/masternotesslideheaderfootermanager/setheaderandchildheadersvisibility/) नोट्स मास्टर हेडर और सभी चाइल्ड हेडर को अपडेट करते हैं। फुटर, तारीख/समय और स्लाइड नंबर के लिए समान विधियां उपलब्ध हैं।

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var masterNotesSlide = presentation.MasterNotesSlideManager.MasterNotesSlide;

if (masterNotesSlide != null)
{
    var headerFooterManager = masterNotesSlide.HeaderFooterManager;

    headerFooterManager.SetHeaderAndChildHeadersText("Notes header");
    headerFooterManager.SetHeaderAndChildHeadersVisibility(true);

    headerFooterManager.SetFooterAndChildFootersText("Notes footer");
    headerFooterManager.SetFooterAndChildFootersVisibility(true);

    headerFooterManager.SetDateTimeAndChildDateTimesText("Date and time text");
    headerFooterManager.SetDateTimeAndChildDateTimesVisibility(true);

    headerFooterManager.SetSlideNumberAndChildSlideNumbersVisibility(true);
}

presentation.Save("presentation_with_child_notes_footers.pptx", SaveFormat.Pptx);
```

ऊपर उपयोग की गई प्रसरण विधियां हैं [`SetFooterAndChildFootersText`](https://reference.aspose.com/slides/hi/net/aspose.slides/masternotesslideheaderfootermanager/setfooterandchildfooterstext/), [`SetFooterAndChildFootersVisibility`](https://reference.aspose.com/slides/hi/net/aspose.slides/masternotesslideheaderfootermanager/setfooterandchildfootersvisibility/), [`SetDateTimeAndChildDateTimesText`](https://reference.aspose.com/slides/hi/net/aspose.slides/masternotesslideheaderfootermanager/setdatetimeandchilddatetimestext/), [`SetDateTimeAndChildDateTimesVisibility`](https://reference.aspose.com/slides/hi/net/aspose.slides/masternotesslideheaderfootermanager/setdatetimeandchilddatetimesvisibility/), और [`SetSlideNumberAndChildSlideNumbersVisibility`](https://reference.aspose.com/slides/hi/net/aspose.slides/masternotesslideheaderfootermanager/setslidenumberandchildslidenumbersvisibility/)।

## **व्यक्तिगत नोट्स स्लाइड पर हेडर और फुटर सेट करें**

एक नोट्स स्लाइड एक विशिष्ट साधारण स्लाइड से जुड़ी होती है। जब आप केवल उस नोट्स पृष्ठ को कस्टमाइज़ करना चाहते हैं, तो उसके [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/hi/net/aspose.slides/inotesslideheaderfootermanager/) इंटरफ़ेस का उपयोग करें।

[`AddNotesSlide`](https://reference.aspose.com/slides/hi/net/aspose.slides/inotesslidemanager/addnotesslide/) मेथड वर्तमान स्लाइड के लिए नोट्स स्लाइड लौटाता है और यदि वह मौजूद नहीं है तो एक नया बनाता है। नीचे दिया गया उदाहरण पहली प्रस्तुति स्लाइड से संबंधित नोट्स पृष्ठ को कॉन्फ़िगर करता है:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var notesSlide = presentation.Slides[0].NotesSlideManager.AddNotesSlide();
var headerFooterManager = notesSlide.HeaderFooterManager;

headerFooterManager.SetHeaderText("Header for the first notes page");
headerFooterManager.SetHeaderVisibility(true);

headerFooterManager.SetFooterText("Footer for the first notes page");
headerFooterManager.SetFooterVisibility(true);

headerFooterManager.SetDateTimeText("Date and time text");
headerFooterManager.SetDateTimeVisibility(true);

headerFooterManager.SetSlideNumberVisibility(true);

presentation.Save("presentation_with_custom_notes_footers.pptx", SaveFormat.Pptx);
```

यदि आप पहले नोट्स मास्टर से सेटिंग्स प्रसारित करें और फिर व्यक्तिगत नोट्स स्लाइड में परिवर्तन करें, तो बाद की प्रति‑स्लाइड सेटिंग्स आपको उस नोट्स पृष्ठ को स्वतंत्र रूप से कस्टमाइज़ करने देती हैं।

## **हैंडआउट मास्टर पर हेडर और फुटर सेट करें**

हैंडआउट पेज अपने हेडर, फुटर, तारीख/समय और पेज‑नंबर प्लेसहोल्डर के लिए हैंडआउट मास्टर का उपयोग करते हैं। नोट्स पेजों के विपरीत, हैंडआउट सेटिंग्स व्यक्तिगत हैंडआउट स्लाइडों के बजाय हैंडआउट मास्टर के माध्यम से प्रबंधित की जाती हैं।

`[`MasterHandoutSlide`](https://reference.aspose.com/slides/hi/net/aspose.slides/imasterhandoutslidemanager/masterhandoutslide/)` प्रॉपर्टी का उपयोग करके हैंडआउट मास्टर तक पहुँचें। यदि यह मौजूद नहीं है, तो डिफ़ॉल्ट हैंडआउट मास्टर बनाने के लिए [`SetDefaultMasterHandoutSlide`](https://reference.aspose.com/slides/hi/net/aspose.slides/imasterhandoutslidemanager/setdefaultmasterhandoutslide/) को कॉल करें।

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var masterHandoutSlide = presentation.MasterHandoutSlideManager.MasterHandoutSlide;

if (masterHandoutSlide == null)
{
    presentation.MasterHandoutSlideManager.SetDefaultMasterHandoutSlide();
    masterHandoutSlide = presentation.MasterHandoutSlideManager.MasterHandoutSlide;
}

if (masterHandoutSlide != null)
{
    var headerFooterManager = masterHandoutSlide.HeaderFooterManager;

    headerFooterManager.SetHeaderText("Handout header");
    headerFooterManager.SetHeaderVisibility(true);

    headerFooterManager.SetFooterText("Handout footer");
    headerFooterManager.SetFooterVisibility(true);

    headerFooterManager.SetDateTimeText("Date and time text");
    headerFooterManager.SetDateTimeVisibility(true);

    headerFooterManager.SetSlideNumberVisibility(true);
}

presentation.Save("presentation_with_handout_footers.pptx", SaveFormat.Pptx);
```

## **स्कोप और विरासत को समझें**

स्कोप चुनें जो आप बदलना चाहते हैं और उसके अनुसार हेडर/फुटर प्रबंधक चुनें:

- [`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/hi/net/aspose.slides/islideheaderfootermanager/) एक साधारण स्लाइड के लिए फुटर, तारीख/समय और स्लाइड‑नंबर सेटिंग्स बदलता है।
- [`ILayoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/hi/net/aspose.slides/ilayoutslideheaderfootermanager/) लेआउट स्लाइड को नियंत्रित करता है और समर्थित सेटिंग्स को निर्भर स्लाइडों तक प्रसारित कर सकता है।
- [`IMasterSlideHeaderFooterManager`](https://reference.aspose.com/slides/hi/net/aspose.slides/imasterslideheaderfootermanager/) साधारण स्लाइड मास्टर को नियंत्रित करता है और समर्थित सेटिंग्स को निर्भर स्लाइडों तक प्रसारित कर सकता है।
- [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/hi/net/aspose.slides/imasternotesslideheaderfootermanager/) नोट्स मास्टर को नियंत्रित करता है और सभी निर्भर नोट्स स्लाइडों तक सेटिंग्स को प्रसारित कर सकता है।
- [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/hi/net/aspose.slides/inotesslideheaderfootermanager/) एक नोट्स स्लाइड को बदलता है और फुटर, तारीख/समय, स्लाइड नंबर के अतिरिक्त हेडर प्लेसहोल्डर का समर्थन करता है।
- [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/hi/net/aspose.slides/imasterhandoutslideheaderfootermanager/) हैंडआउट मास्टर को बदलता है और सभी चार प्रकार के प्लेसहोल्डर का समर्थन करता है।

जब एक ही सेटिंग को उसकी पूरी पदानुक्रम में लागू करना हो, तो मास्टर या लेआउट से प्रसारण का उपयोग करें। जब आपको केवल एक पृष्ठ के लिए स्थानीय सेटिंग की आवश्यकता हो, तो व्यक्तिगत स्लाइड या नोट्स‑स्लाइड प्रबंधक का उपयोग करें।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं साधारण स्लाइड में हेडर जोड़ सकता हूँ?**

नहीं। PowerPoint साधारण स्लाइडों के लिए हेडर प्लेसहोल्डर परिभाषित नहीं करता है। साधारण स्लाइडों पर फुटर, तारीख/समय और स्लाइड‑नंबर प्लेसहोल्डर का उपयोग करें। हेडर प्लेसहोल्डर नोट्स पृष्ठों और हैंडआउट पर उपलब्ध होते हैं।

**यदि फुटर, तारीख/समय या स्लाइड‑नंबर प्लेसहोल्डर दिखाई नहीं दे रहा है तो क्या करें?**

संबंधित हेडर/फुटर प्रबंधक का उपयोग करके उसकी दृश्यता जाँचें और आवश्यकता होने पर उसे सक्षम करें। उदाहरण के लिए, [`IsFooterVisible`](https://reference.aspose.com/slides/hi/net/aspose.slides/baseslideheaderfootermanager/isfootervisible/) बताता है कि फुटर प्लेसहोल्डर मौजूद है या नहीं, और [`SetFooterVisibility`](https://reference.aspose.com/slides/hi/net/aspose.slides/baseslideheaderfootermanager/setfootervisibility/) उसकी दृश्यता बदलता है।

**मैं स्लाइड नंबरिंग को 1 के अलावा किसी मान से कैसे शुरू करूँ?**

प्रस्तुति की [`FirstSlideNumber`](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/firstslidenumber/) प्रॉपर्टी सेट करें। फिर स्लाइड‑नंबर प्लेसहोल्डर अपडेटेड क्रमांक श्रृंखला का उपयोग करेंगे।

**PDF, इमेज या HTML में निर्यात करते समय हेडर और फुटर का क्या होता है?**

दृश्यमान हेडर और फुटर तत्व आउटपुट फ़ॉर्मेट में प्रस्तुति की बाकी सामग्री के साथ रेंडर होते हैं। उनका स्वरूप निर्यात किए जा रहे पृष्ठ प्रकार और संबंधित प्लेसहोल्डर दृश्यता सेटिंग्स पर निर्भर करता है।