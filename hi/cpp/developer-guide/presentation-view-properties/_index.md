---
title: "C++ में प्रस्तुति व्यू प्रॉपर्टीज़ को पुनः प्राप्त करें और अपडेट करें"
linktitle: "व्यू प्रॉपर्टीज़"
type: docs
weight: 80
url: /hi/cpp/presentation-view-properties/
keywords:
- "व्यू प्रॉपर्टीज़"
- "सामान्य दृश्य"
- "रूपरेखा सामग्री"
- "रूपरेखा आइकॉन"
- "वर्टिकल स्प्लिटर स्नैप"
- "एकल व्यू"
- "बार स्थिति"
- "आयाम आकार"
- "स्वचालित समायोजन"
- "डिफ़ॉल्ट ज़ूम"
- "PowerPoint"
- "OpenDocument"
- "प्रस्तुति"
- "C++"
- "Aspose.Slides"
description: "Aspose.Slides for C++ के व्यू प्रॉपर्टीज़ को खोजें ताकि PPT, PPTX और ODP स्लाइड्स के फ़ॉर्मेट को कस्टमाइज़ कर सकें—लेआउट, ज़ूम स्तर और डिस्प्ले सेटिंग्स को समायोजित करें।"
---
## **परिचय**

सामान्य दृश्य में तीन कंटेंट क्षेत्र होते हैं: स्वयं स्लाइड, एक साइड कंटेंट क्षेत्र, और एक नीचे का कंटेंट क्षेत्र। विभिन्न कंटेंट क्षेत्रों की पोजिशनिंग से संबंधित प्रॉपर्टी। यह जानकारी एप्लिकेशन को अपने दृश्य स्थिति को फ़ाइल में सहेजने की अनुमति देती है, ताकि फिर से खोलने पर दृश्य वही स्थिति में हो जैसा कि प्रस्तुति को आखिरी बार सहेजा गया था।

Method [IViewProperties::get_NormalViewProperties](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iviewproperties/get_normalviewproperties/) को प्रस्तुति के सामान्य दृश्य प्रॉपर्टी तक पहुँच प्रदान करने के लिए जोड़ा गया है। 

[INormalViewProperties](https://reference.aspose.com/slides/hi/cpp/aspose.slides/inormalviewproperties/), [INormalViewRestoredProperties](https://reference.aspose.com/slides/hi/cpp/aspose.slides/inormalviewrestoredproperties/) इंटरफ़ेस और उनके जनक, [SplitterBarStateType](https://reference.aspose.com/slides/hi/cpp/aspose.slides/splitterbarstatetype/) एनम को जोड़ा गया है।

## **INormalViewProperties के बारे में**

सामान्य दृश्य प्रॉपर्टी को दर्शाता है।

प्रॉपर्टी **ShowOutlineIcons** यह निर्दिष्ट करती है कि सामान्य दृश्य मोड में किसी भी कंटेंट क्षेत्र में रूपरेखा कंटेंट प्रदर्शित करते समय एप्लिकेशन को आइकॉन दिखाने चाहिए या नहीं।

प्रॉपर्टी **SnapVerticalSplitter** यह निर्दिष्ट करती है कि साइड क्षेत्र पर्याप्त छोटा होने पर वर्टिकल स्प्लिटर को न्यूनतम स्थिति में स्नैप करना चाहिए या नहीं।

प्रॉपर्टी **PreferSingleView** यह निर्दिष्ट करती है कि उपयोगकर्ता तीन कंटेंट क्षेत्रों वाले मानक सामान्य दृश्य की बजाय पूरे विंडो में एकल‑कंटेंट क्षेत्र देखना पसंद करता है या नहीं। यदि सक्षम किया गया, तो एप्लिकेशन पूरे विंडो में किसी एक कंटेंट क्षेत्र को प्रदर्शित करना चुन सकता है।

प्रॉपर्टी **VerticalBarState** और **HorizontalBarState** यह निर्दिष्ट करती हैं कि क्षैतिज या ऊर्ध्वाधर स्प्लिटर बार को कौनसी स्थिति में दिखाया जाना चाहिए। एक क्षैतिज स्प्लिटर बार स्लाइड को नीचे के कंटेंट क्षेत्र से अलग करता है, जबकि ऊर्ध्वाधर स्प्लिटर बार स्लाइड को साइड कंटेंट क्षेत्र से अलग करता है। संभावित मान हैं: **SplitterBarStateType.Minimized, SplitterBarStateType.Maximized** और **SplitterBarStateType.Restored**।

प्रॉपर्टी **RestoredLeft** और **RestoredTop** यह निर्दिष्ट करती हैं कि सामान्य दृश्य के ऊर्ध्वाधर और क्षैतिज बार के लिए **SplitterBarStateType.Restored** मान लागू होने पर स्लाइड के शीर्ष या साइड क्षेत्र का आकार क्या होगा।

## **INormalViewProperties को पुनर्स्थापित करने के बारे में**

यह निर्दिष्ट करता है कि सामान्य दृश्य के स्लाइड क्षेत्र (चौड़ाई जब RestoredTop का चाइल्ड हो, ऊँचाई जब RestoredLeft का चाइल्ड हो) का आकार क्या होगा, जब वह क्षेत्र परिवर्तनीय पुनर्स्थापित आकार (न तो न्यूनतम और न ही अधिकतम) में हो।

प्रॉपर्टी **DimensionSize** स्लाइड क्षेत्र (RestoredTop का चाइल्ड होने पर चौड़ाई, RestoredLeft का चाइल्ड होने पर ऊँचाई) का आकार निर्धारित करती है।

प्रॉपर्टी **AutoAdjust** यह निर्दिष्ट करती है कि साइड कंटेंट क्षेत्र का आकार नई विंडो आकार के अनुसार स्वतः समायोजित होना चाहिए या नहीं, जब एप्लिकेशन में view को पुनः आकार दिया जाता है।

नीचे दिया गया उदाहरण दिखाता है कि आप प्रस्तुति के **ViewProperties.NormalViewProperties** प्रॉपर्टी तक कैसे पहुँच सकते हैं।

``` cpp
#include <DOM/INormalViewProperties.h>
#include <DOM/INormalViewRestoredProperties.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <DOM/SplitterBarStateType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"demo.pptx");
pres->get_ViewProperties()->get_NormalViewProperties()->set_HorizontalBarState(SplitterBarStateType::Restored);
pres->get_ViewProperties()->get_NormalViewProperties()->set_VerticalBarState(SplitterBarStateType::Maximized);

// प्रस्तुति की व्यू प्रॉपर्टीज़ को पुनर्स्थापित करें
pres->get_ViewProperties()->get_NormalViewProperties()->get_RestoredTop()->set_AutoAdjust(true);
pres->get_ViewProperties()->get_NormalViewProperties()->get_RestoredTop()->set_DimensionSize(80.0f);
pres->get_ViewProperties()->get_NormalViewProperties()->set_ShowOutlineIcons(true);

pres->Save(u"presentation_normal_view_state.pptx", SaveFormat::Pptx);
```

## **डिफ़ॉल्ट ज़ूम वैल्यू सेट करें**

Aspose.Slides for C++ अब प्रस्तुति के लिए डिफ़ॉल्ट ज़ूम वैल्यू सेट करने का समर्थन करता है, ताकि प्रस्तुति खोलते समय ज़ूम पहले से निर्धारित हो। यह प्रस्तुति की [ViewProperties](https://reference.aspose.com/slides/hi/cpp/aspose.slides/viewproperties/) को सेट करके किया जा सकता है। स्लाइड व्यू प्रॉपर्टी के साथ-साथ [get_NotesViewProperties](https://reference.aspose.com/slides/hi/cpp/aspose.slides/viewproperties/get_notesviewproperties/) को भी प्रोग्रामेटिकली सेट किया जा सकता है। इस टॉपिक में, हम एक उदाहरण के साथ दिखाएंगे कि Aspose.Slides में प्रस्तुति की View Properties कैसे सेट करें।

व्यू प्रॉपर्टी सेट करने के लिए नीचे दिए गए चरणों का पालन करें:

1. एक [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) क्लास का इंस्टेंस बनाएं
1. प्रस्तुति की View [Properties](https://reference.aspose.com/slides/hi/cpp/aspose.slides/viewproperties/) सेट करें
1. प्रस्तुति को PPTX फ़ाइल के रूप में लिखें

नीचे दिए गए उदाहरण में, हमने स्लाइड व्यू और नोट्स व्यू दोनों के लिए ज़ूम वैल्यू सेट की है।

``` cpp
#include <DOM/ICommonSlideViewProperties.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

// प्रस्तुति की व्यू प्रॉपर्टीज़ सेट करना
presentation->get_ViewProperties()->get_SlideViewProperties()->set_Scale(100); // स्लाइड व्यू के लिए प्रतिशत में ज़ूम मान
presentation->get_ViewProperties()->get_NotesViewProperties()->set_Scale(100); // नोट्स व्यू के लिए प्रतिशत में ज़ूम मान

presentation->Save(u"Zoom_out.pptx", SaveFormat::Pptx);
```

## **ग्रिड स्पेसिंग सेट करें**

प्रस्तुति‑व्यापी दृश्य सेटिंग्स तक पहुँचने के लिए [Presentation::get_ViewProperties](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/get_viewproperties/) का उपयोग करें। [IViewProperties::get_GridSpacing](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iviewproperties/get_gridspacing/) और [IViewProperties::set_GridSpacing](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iviewproperties/set_gridspacing/) मेथड्स मूल एडिटिंग ग्रिड के अंतराल को पढ़ते या बदलते हैं। यह सेटिंग पूरी प्रस्तुति पर लागू होती है, न कि किसी व्यक्तिगत स्लाइड पर। ग्रिड स्पेसिंग पॉइंट्स में निर्दिष्ट की जाती है, जहाँ 72 पॉइंट्स एक इंच के बराबर होते हैं। API दस्तावेज़ द्वारा अपेक्षित के अनुसार एक सकारात्मक मान का उपयोग करें।

निम्न उदाहरण एक मौजूदा `demo.pptx` खोलता है, उसकी वर्तमान ग्रिड स्पेसिंग प्रिंट करता है, एक चतुर्थांश‑इंच अंतराल सेट करता है, और परिणाम को सहेजता है।

```cpp
#include <system/console.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");
auto gridSpacing = presentation->get_ViewProperties()->get_GridSpacing();
System::Console::WriteLine(u"Current grid spacing: {0} points", gridSpacing);

presentation->get_ViewProperties()->set_GridSpacing(18.0f);
presentation->Save(u"grid-spacing.pptx", SaveFormat::Pptx);
```

ग्रिड [ड्रॉइंग गाइड्स](/slides/hi/cpp/drawing-guides/) से अलग है। ग्रिड स्पेसिंग नियत अंतराल को नियंत्रित करती है, जबकि ड्रॉइंग गाइड्स व्यक्तिगत रूप से स्थित क्षैतिज या ऊर्ध्वाधर संरेखण रेखाएँ होती हैं। ड्रॉइंग गाइड्स को जोड़ने, ले जाने या साफ़ करने से ग्रिड स्पेसिंग नहीं बदलती।

ग्रिड और ड्रॉइंग गाइड्स दोनों ही एडिटिंग सहायता हैं। उन्हें PDF, छवियों, SVG या स्लाइडशो में स्लाइड कंटेंट के रूप में रेंडर नहीं किया जाता। ग्रिड स्पेसिंग को संग्रहीत करने से यह गारंटी नहीं मिलती कि एडीटर ग्रिड दिखाएगा: इसकी दृश्यता एडीटर या व्यूअर की प्राथमिकताओं पर भी निर्भर करती है।

## **अक्सर पूछे जाने वाले प्रश्न**

**ग्रिड क्यों नहीं दिख रहा है जब मैं प्रस्तुति को फिर से खोलता हूँ?**

फ़ाइल ग्रिड स्पेसिंग को संग्रहीत करती है, लेकिन एडीटर यह नियंत्रित करता है कि ग्रिड प्रदर्शित हो या नहीं। एडीटर की ग्रिड दृश्यता सेटिंग्स की जाँच करें।

**क्या ड्रॉइंग गाइड्स को साफ़ करने से ग्रिड स्पेसिंग बदलती है?**

नहीं। ड्रॉइंग गाइड्स और ग्रिड स्पेसिंग स्वतंत्र सेटिंग्स हैं। गाइड्स को साफ़ करने से संग्रहीत ग्रिड अंतराल अपरिवर्तित रहता है।

**क्या मैं प्रस्तुति के विभिन्न सेक्शनों के लिए अलग‑अलग व्यू सेटिंग्स सेट कर सकता हूँ?**

[View settings](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/get_viewproperties/) प्रस्तुति स्तर पर परिभाषित होते हैं ([Normal View](https://reference.aspose.com/slides/hi/cpp/aspose.slides/viewproperties/get_normalviewproperties/)/[Slide View](https://reference.aspose.com/slides/hi/cpp/aspose.slides/viewproperties/get_slideviewproperties/)), सेक्शन‑वार नहीं, इसलिए एक ही पैरामीटर सेट पूरी डॉक्यूमेंट के खुलने पर लागू होता है।

**क्या मैं विभिन्न उपयोगकर्ताओं के लिए अलग‑अलग व्यू स्टेट्स पूर्वनिर्धारित कर सकता हूँ?**

नहीं। सेटिंग्स फ़ाइल में संग्रहीत होती हैं और साझा की जाती हैं। व्यूअर एप्लिकेशन उपयोगकर्ता प्राथमिकताओं को मान सकते हैं, लेकिन फ़ाइल स्वयं केवल एक सेट व्यू प्रॉपर्टी रखती है।

**क्या मैं एक टेम्पलेट तैयार कर सकता हूँ जिसमें पूर्वनिर्धारित View Properties हों, ताकि नई प्रस्तुतियों का खुलना समान हो?**

हां। क्योंकि [view properties](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/get_viewproperties/) प्रस्तुति स्तर पर संग्रहीत होती हैं, आप उन्हें टेम्पलेट में एम्बेड कर सकते हैं और नई डॉक्यूमेंट्स को उसी प्रारंभिक व्यू कॉन्फ़िगरेशन के साथ बना सकते हैं।