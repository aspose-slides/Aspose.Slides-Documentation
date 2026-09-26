---
title: C++ में नोट्स पेज आकार और अभिमुखीकरण बदलें
linktitle: नोट्स पेज आकार
type: docs
weight: 10
url: /hi/cpp/notes-size/
keywords:
- नोट्स पेज आकार
- नोट्स अभिमुखीकरण
- लैंडस्केप नोट्स
- पोर्ट्रेट नोट्स
- हैंडआउट आकार
- PowerPoint
- प्रेज़ेंटेशन
- PPT
- PPTX
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ में नोट्स पेज आयाम पढ़ें और बदलें, अभिमुखीकरण बदलें, सहेजे गए आकारों की पुष्टि करें, और नोट्स या हैंडआउट को PDF तथा छवियों में निर्यात करें।"
---
## **सारांश**

[Presentation::get_NotesSize](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/get_notessize/) का उपयोग करके आप प्रेजेंटेशन की नोट्स पेज सेटिंग्स तक पहुँच सकते हैं। यह एक [INotesSize] ऑब्जेक्ट लौटाता है, जिसका [set_Size] मेथड आयाम सेट करता है। हालाँकि नोट्स सेटिंग्स ऑब्जेक्ट को बदला नहीं जा सकता, आप उसके आकार को बदल सकते हैं।

चौड़ाई और ऊँचाई **पॉइंट्स** में निर्दिष्ट की जाती हैं, जहाँ 1 इंच में 72 पॉइंट्स होते हैं। उदाहरण के लिए, 900 × 600 पॉइंट्स 12.5 × 8⅓ इंच के बराबर है। ये सेटिंग्स पूरे प्रेजेंटेशन पर लागू होती हैं, न कि किसी व्यक्तिगत स्लाइड के नोट्स पर।

| सेटिंग | उद्देश्य |
| --- | --- |
| [Presentation::get_NotesSize](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/get_notessize/) | नोट्स पेज के आयाम और हैंडआउट निर्यात के लिए उपयोग होने वाले पेज आयामों को नियंत्रित करता है। |
| [Presentation::get_SlideSize](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/get_slidesize/) | [ISlideSize](https://reference.aspose.com/slides/hi/cpp/aspose.slides/islidesize/) के माध्यम से नियमित प्रेजेंटेशन स्लाइड के आयामों को नियंत्रित करता है। |

एक सेटिंग को बदलने से दूसरी सेटिंग स्वचालित रूप से नहीं बदलती। नोट्स पेज अभिमुखीकरण को बदलने से नियमित स्लाइडों का घुमाव नहीं होता। नियमित स्लाइडों का आकार बदलने के लिए [स्लाइड आकार](/slides/hi/cpp/slide-size/) देखें।

नीचे के उदाहरण एक मौजूदा `sample.pptx` का उपयोग करते हैं। निर्यात उदाहरणों के लिए कम से कम एक स्लाइड जिसमें स्पीकर नोट्स हों, वाला प्रेजेंटेशन उपयोग करें। प्रत्येक उदाहरण स्वतंत्र रूप से चलाया जा सकता है।

## **नोट्स पेज आकार और अभिमुखीकरण पढ़ें**

चौड़ाई और ऊँचाई पढ़ें और उनकी तुलना करके अभिमुखीकरण निर्धारित करें: यदि पेज चौड़ा है तो वह लैंडस्केप होता है, यदि ऊँचा है तो पोर्ट्रेट, और यदि आयाम समान हैं तो वह वर्गाकार पेज होता है। यह उदाहरण वास्तविक आयामों को पॉइंट्स में प्रिंट करता है, बिना किसी मानक कागज़ आकार मानें।

```cpp
#include <DOM/Presentation.h>
#include <DOM/INotesSize.h>
#include <drawing/size_f.h>
#include <system/console.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto size = presentation->get_NotesSize()->get_Size();
auto orientation = String(u"Square");

if (size.get_Width() > size.get_Height())
    orientation = u"Landscape";
else if (size.get_Width() < size.get_Height())
    orientation = u"Portrait";

Console::WriteLine(u"Notes page: {0} x {1} points", size.get_Width(), size.get_Height());
Console::WriteLine(u"Orientation: {0}", orientation);
```

## **कागज का आकार बदले बिना लैंडस्केप में बदलें**

केवल अभिमुखीकरण बदलने के लिए मौजूदा चौड़ाई और ऊँचाई को अदला‑बदली करें। इससे दोनों पक्षों की लंबाई बरकरार रहती है, जिसमें कस्टम कागज़ आकार भी शामिल है। नीचे की शर्त पहले से लैंडस्केप पेज को फिर से पोर्ट्रेट में बदलने से रोकती है और वर्गाकार पेज को अपरिवर्तित छोड़ती है।

```cpp
#include <DOM/Presentation.h>
#include <DOM/INotesSize.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto size = presentation->get_NotesSize()->get_Size();

if (size.get_Width() < size.get_Height())
    presentation->get_NotesSize()->set_Size(SizeF(size.get_Height(), size.get_Width()));

presentation->Save(u"landscape-notes.pptx", SaveFormat::Pptx);
```

पोर्ट्रेट अभिमुखीकरण के लिए वही असाइनमेंट तब उपयोग करें जब `size.get_Width() > size.get_Height()` हो। जब तक आप कागज़ का आकार भी बदलना चाहते हैं, तब तक A4 या लेटर आयामों को न बदलें।

## **कस्टम नोट्स पेज आकार सेट करें और सत्यापित करें**

दोनों आयामों को साथ‑साथ असाइन करें, फिर प्रेजेंटेशन को लिखने के लिए [Presentation::Save](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/save/) का उपयोग करें। यह उदाहरण 900 × 600‑पॉइंट लैंडस्केप पेज सेट करता है, इसे PPTX के रूप में सहेजता है, और फिर सहेजी गई फ़ाइल को फिर से खोलकर स्थायी मानों की जाँच करता है। तुलना के दौरान फ्लोटिंग‑पॉइंट मानों के लिए 0.01‑पॉइंट सहनशीलता अपनाई जाती है; यह सभी फ़ाइल फॉर्मेट में सटीकता की गारंटी नहीं है।

```cpp
#include <DOM/Presentation.h>
#include <DOM/INotesSize.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
#include <system/console.h>
#include <system/smart_ptr.h>
#include <cmath>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto expectedSize = SizeF(900, 600);
presentation->get_NotesSize()->set_Size(expectedSize);
presentation->Save(u"custom-notes.pptx", SaveFormat::Pptx);

auto reopened = MakeObject<Presentation>(u"custom-notes.pptx");
auto actualSize = reopened->get_NotesSize()->get_Size();
auto widthMatches = std::abs(actualSize.get_Width() - expectedSize.get_Width()) < 0.01f;
auto heightMatches = std::abs(actualSize.get_Height() - expectedSize.get_Height()) < 0.01f;
auto preserved = widthMatches && heightMatches;

Console::WriteLine(u"Stored notes page: {0} x {1} points", actualSize.get_Width(), actualSize.get_Height());
Console::WriteLine(u"Size preserved: {0}", preserved);
```

अपेक्षित परिणाम `900 x 600 points` और `Size preserved: True` होना चाहिए। नई खोली गई प्रेजेंटेशन की जाँच करने से सहेजी गई फ़ाइल की पुष्टि होती है, न कि केवल स्मृति‑में रखे सेटिंग्स की।

## **नोट्स और हैंडआउट निर्यात करें**

पेज आयाम नोट्स या हैंडआउट लेआउट के उपलब्ध क्षेत्र को निर्धारित करते हैं। केवल इन आयामों से लेआउट सक्षम नहीं होते; निर्यात विकल्पों को भी कॉन्फ़िगर करें। नियमित स्लाइड निर्यात अभी भी स्लाइड आयामों को उपयोग करता है।

### **नोट्स को पीडीएफ और पीएनजी में निर्यात करें**

[NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/notescommentslayoutingoptions/) को [PdfOptions::set_SlidesLayoutOptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/pdfoptions/set_slideslayoutoptions/) में असाइन करके PDF में नोट्स शामिल किए जा सकते हैं। यह उदाहरण पहले स्लाइड के नोट्स को PNG में भी रेंडर करता है, जिसके लिये [Slide::GetImage](https://reference.aspose.com/slides/hi/cpp/aspose.slides/slide/getimage/) और [RenderingOptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/renderingoptions/) का उपयोग किया गया है।

[BottomTruncated](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/notespositions/) मोड नोट्स को एक ही पेज पर रखता है; जो नोट्स फिट नहीं होते उन्हें कट दिया जाता है। PDF 900 × 600‑पॉइंट पेज उपयोग करता है। नीचे 1 × 1 के इमेज स्केल पर PNG का आकार 900 × 600 पिक्सेल होता है। पॉइंट्स पेज ज्योमेट्री का वर्णन करते हैं; पिक्सेल रास्टर आउटपुट का वर्णन करते हैं, जिसकी आयाम रेंडरिंग स्केल पर भी निर्भर करती है।

```cpp
#include <DOM/Presentation.h>
#include <DOM/INotesSize.h>
#include <DOM/ISlide.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/NotesPositions.h>
#include <Export/PdfOptions.h>
#include <Export/RenderingOptions.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <drawing/size_f.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
presentation->get_NotesSize()->set_Size(SizeF(900, 600));

auto layout = MakeObject<NotesCommentsLayoutingOptions>();
layout->set_NotesPosition(NotesPositions::BottomTruncated);

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(layout);

presentation->Save(u"notes.pdf", SaveFormat::Pdf, pdfOptions);

auto renderingOptions = MakeObject<RenderingOptions>();
renderingOptions->set_SlidesLayoutOptions(layout);

auto image = presentation->get_Slide(0)->GetImage(renderingOptions, 1.0f, 1.0f);
image->Save(u"first-slide-notes.png", ImageFormat::Png);
image->Dispose();
```

लंबे नोट्स वाले PDF निर्यात के लिए [BottomFull](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/notespositions/) अतिरिक्त पेज बनाए रखने की अनुमति देता है। इसे ऊपर के सिंगल‑स्लाइड इमेज कॉल के साथ प्रयोग न करें, क्योंकि वह इसे समर्थन नहीं करता। आकार बदलने के बाद आउटपुट की जाँच करें—कटे हुए नोट्स और मौजूदा नोट‑मास्टर ऑब्जेक्ट्स की स्थिति देखें; केवल पेज आयाम बदलने से यह गारंटी नहीं मिलती कि सभी सामग्री फिट हो जाएगी। अधिक नोट्स निर्यात जानकारी के लिये देखें [नोट्स के साथ पॉवरपॉइंट को पीडीएफ में बदलें](/slides/hi/cpp/convert-powerpoint-to-pdf-with-notes/)।

### **हैंडआउट को पीडीएफ में निर्यात करें**

[HandoutLayoutingOptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/handoutlayoutingoptions/) का उपयोग करके एक पेज पर कई स्लाइड थंबनेल रखे जा सकते हैं। नीचे का उदाहरण 900 × 600‑पॉइंट पेज सेट करता है और [HandoutType::Handout4Horizontal](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/handouttype/) का उपयोग करके एक पेज पर अधिकतम चार स्लाइड व्यवस्थित करता है। क्षैतिज प्रीसेट स्लाइड क्रम तय करता है; पेज अभिमुखीकरण उसकी चौड़ाई और ऊँचाई से निर्धारित होता है।

```cpp
#include <DOM/Presentation.h>
#include <DOM/INotesSize.h>
#include <Export/HandoutLayoutingOptions.h>
#include <Export/HandoutType.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
presentation->get_NotesSize()->set_Size(SizeF(900, 600));

auto layout = MakeObject<HandoutLayoutingOptions>();
layout->set_Handout(HandoutType::Handouts4Horizontal);

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(layout);

presentation->Save(u"handouts.pdf", SaveFormat::Pdf, pdfOptions);
```

पेज आकार बदलने से हैंडआउट ग्रिड के उपलब्ध क्षेत्र में बदलाव आता है, जबकि स्रोत स्लाइडों के आयाम नहीं बदलते। हैंडआउट इमेज के लिये, व्यक्तिगत स्लाइड की इमेज मेथड के बजाय हैंडआउट लेआउट के साथ [Presentation::GetImages](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/getimages/) का उपयोग करें। Aspose.Slides में प्रेजेंटेशन‑लेवल हैंडआउट रेंडरिंग नोट्स पेज आयामों को उपयोग करता है, जबकि व्यक्तिगत स्लाइड इमेज कॉल हैंडआउट पेज नहीं बनाता। लेआउट विकल्पों के लिये देखें [हैंडआउट मोड](/slides/hi/cpp/convert-powerpoint-in-handout-mode/)।

## **व्यूअर्स, निर्यात, और प्रिंटिंग में पेज आकार**

सहेजे गए प्रेजेंटेशन आकार, निर्यात पेज आकार, और प्रिंटेड पेपर आकार को अलग रखें:

- **प्रेजेंटेशन व्यूअर्स:** एक व्यूअर अपने स्वयं के लेआउट नियमों के अनुसार नोट्स प्रदर्शित या प्रिंट कर सकता है। यदि कोई अन्य एप्लिकेशन फ़ाइल को सहेजता है, तो उसे फिर से खोलें और आयाम दोबारा जांचें; उस एप्लिकेशन की फ़ॉर्मेट कन्वर्ज़न आयामों को सामान्य कर सकती है।
- **निर्यात फॉर्मेट:** ऊपर के नोट्स और हैंडआउट पीडीएफ उदाहरण कॉन्फ़िगर किए गए पेज आयामों का उपयोग करते हैं। रास्टर इमेज पूर्णांक पिक्सेल आयाम और रेंडरिंग स्केल का प्रयोग करती हैं, इसलिए अंशीय पॉइंट मान इमेज आउटपुट में गोल हो सकते हैं। नियमित स्लाइड निर्यात में नोट्स पेज आकार लागू नहीं होता।
- **प्रिंटर ड्राइवर्स:** पेपर चयन, ऑटो‑रोटेशन, और फिट‑टू‑पेज सेटिंग्स भौतिक आउटपुट को बदल सकती हैं, जबकि प्रेजेंटेशन या पीडीएफ में संग्रहीत आयाम अपरिवर्तित रहते हैं। विशिष्ट पेपर आकार के लिये प्रिंटर सेटिंग्स से मेल करें और प्रिंट प्रीव्यू की जाँच करें।

## **FAQ**

**क्या मैं केवल एक स्लाइड के लिए नोट्स आकार सेट कर सकता हूँ?**

नोट्स पेज आकार प्रेजेंटेशन‑लेवल सेटिंग है। व्यक्तिगत स्लाइडों का नोट्स कंटेंट अलग हो सकता है, लेकिन यह प्रॉपर्टी प्रत्येक स्लाइड के लिये अलग पेज आकार प्रदान नहीं करती।

**नोट्स अभिमुखीकरण बदलने से मेरे स्लाइड क्यों नहीं बदले?**

नोट्स पेज और नियमित स्लाइड के आयाम स्वतंत्र होते हैं। स्लाइड स्वयं को री‑साइज़ करने के लिये नियमित स्लाइड आकार सेटिंग्स का उपयोग करें।

**मेरे सहेजे या प्रिंटेड परिणाम का आकार अलग क्यों है?**

पहले सहेजे गए प्रेजेंटेशन को फिर से खोलें और उसके नोट्स आयाम देखें। यदि वे बदल गए हैं, तो जांचें कि किसी अन्य एप्लिकेशन में फ़ाइल सहेजने या कन्वर्ट करने से पेज सेटिंग्स बदलीं या नहीं। यदि नहीं बदले, तो निर्यात लेआउट, इमेज स्केल, व्यूअर सेटिंग्स, और प्रिंटर पेपर चयन की जाँच करें।