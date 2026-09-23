---
title: C++ में प्रस्तुति व्यू प्रॉपर्टीज़ को प्राप्त करें और अपडेट करें
linktitle: व्यू प्रॉपर्टीज़
type: docs
weight: 80
url: /hi/cpp/presentation-view-properties/
keywords:
- व्यू प्रॉपर्टीज़
- नॉर्मल व्यू
- आउटलाइन कंटेंट
- आउटलाइन आइकॉन
- स्नैप वर्टिकल स्प्लिटर
- सिंगल व्यू
- बार स्टेट
- डायमेंशन साइज
- ऑटो एडजस्ट
- डिफ़ॉल्ट ज़ूम
- पावरपॉइंट
- ओपनडॉक्यूमेंट
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ व्यू प्रॉपर्टीज़ की खोज करें ताकि आप PPT, PPTX और ODP स्लाइड्स के फॉर्मेट को अनुकूलित कर सकें—लेआउट, ज़ूम लेवल और डिस्प्ले सेटिंग्स समायोजित करें।"
---
## **परिचय**

Normal view में तीन सामग्री क्षेत्रों होते हैं: स्लाइड स्वयं, एक साइड सामग्री क्षेत्र, और एक बॉटम सामग्री क्षेत्र। विभिन्न सामग्री क्षेत्रों की स्थिति से संबंधित प्रॉपर्टीज़। यह जानकारी एप्लिकेशन को अपनी व्यू स्टेट को फ़ाइल में सहेजने की अनुमति देती है, ताकि जब इसे फिर से खोला जाए तो व्यू उसी स्थिति में हो जैसा कि प्रस्तुति को अंतिम बार सहेजा गया था।

प्रेजेंटेशन के नॉर्मल व्यू प्रॉपर्टीज़ तक पहुँच प्रदान करने के लिए मेथड [IViewProperties::get_NormalViewProperties](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iviewproperties/get_normalviewproperties/) को जोड़ा गया है।  

इंटरफ़ेस [INormalViewProperties](https://reference.aspose.com/slides/hi/cpp/aspose.slides/inormalviewproperties/), [INormalViewRestoredProperties](https://reference.aspose.com/slides/hi/cpp/aspose.slides/inormalviewrestoredproperties/) और उनके वंशज, तथा एन्‍युम [SplitterBarStateType](https://reference.aspose.com/slides/hi/cpp/aspose.slides/splitterbarstatetype/) को जोड़ा गया है।

## **INormalViewProperties के बारे में**

सामान्य दृश्य (नॉर्मल व्यू) प्रॉपर्टीज़ का प्रतिनिधित्व करता है।

प्रॉपर्टी **ShowOutlineIcons** यह निर्धारित करती है कि नॉर्मल व्यू मोड में किसी भी सामग्री क्षेत्र में आउटलाइन कंटेंट प्रदर्शित करते समय एप्लिकेशन को आइकॉन दिखाने चाहिए या नहीं।

प्रॉपर्टी **SnapVerticalSplitter** यह निर्दिष्ट करती है कि जब साइड क्षेत्र पर्याप्त छोटा हो तो वर्टिकल स्प्लिटर को न्यूनतम स्थिति में स्नैप किया जाना चाहिए या नहीं।

प्रॉपर्टी **PreferSingleView** यह निर्धारित करती है कि उपयोगकर्ता को तीन सामग्री क्षेत्रों वाले मानक सामान्य दृश्य की बजाय एक पूर्ण-विंडो एकल-समग्री क्षेत्र देखना पसंद है या नहीं। यदि सक्षम किया जाता है, तो एप्लिकेशन एक सामग्री क्षेत्र को पूरी विंडो में दिखाने का चयन कर सकता है।

प्रॉपर्टी **VerticalBarState** और **HorizontalBarState** यह निर्धारित करती हैं कि क्षैतिज या लंबवत स्प्लिटर बार किस स्थिति में दिखाया जाना चाहिए। एक क्षैतिज स्प्लिटर बार स्लाइड को नीचे की सामग्री क्षेत्र से अलग करता है, जबकि लंबवत स्प्लिटर बार स्लाइड को साइड सामग्री क्षेत्र से अलग करता है। संभावित मान हैं: **SplitterBarStateType.Minimized, SplitterBarStateType.Maximized** और **SplitterBarStateType.Restored**।

प्रॉपर्टी **RestoredLeft** और **RestoredTop** यह निर्दिष्ट करती हैं कि जब **VerticalBarState** और **HorizontalBarState** के लिए **SplitterBarStateType.Restored** मान लागू हो, तब नॉर्मल व्यू के शीर्ष या साइड स्लाइड क्षेत्र का आकार क्या होना चाहिए।

## **INormalViewProperties को पुनर्स्थापित करने के बारे में**

जब क्षेत्र का आकार परिवर्तनीय पुनर्स्थापित (न्यूनतम या अधिकतम नहीं) हो, तो नॉर्मल व्यू में स्लाइड क्षेत्र (RestoredTop का बच्चा होने पर चौड़ाई, RestoredLeft का बच्चा होने पर ऊँचाई) का आकार निर्दिष्ट करता है।

प्रॉपर्टी **DimensionSize** स्लाइड क्षेत्र (RestoredTop का बच्चा होने पर चौड़ाई, RestoredLeft का बच्चा होने पर ऊँचाई) का आकार निर्दिष्ट करती है।

प्रॉपर्टी **AutoAdjust** यह निर्धारित करती है कि जब एप्लिकेशन में व्यू को रखे गए विंडो का आकार बदलते समय साइड सामग्री क्षेत्र का आकार नई विंडो आकार के अनुरूप समायोजित होना चाहिए या नहीं।

नीचे दिया गया उदाहरण दर्शाता है कि आप प्रस्तुति के लिए **ViewProperties.NormalViewProperties** प्रॉपर्टीज़ तक कैसे पहुँच सकते हैं।

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

// प्रेजेंटेशन की व्यू प्रॉपर्टीज़ को पुनर्स्थापित करें
pres->get_ViewProperties()->get_NormalViewProperties()->get_RestoredTop()->set_AutoAdjust(true);
pres->get_ViewProperties()->get_NormalViewProperties()->get_RestoredTop()->set_DimensionSize(80.0f);
pres->get_ViewProperties()->get_NormalViewProperties()->set_ShowOutlineIcons(true);

pres->Save(u"presentation_normal_view_state.pptx", SaveFormat::Pptx);
```

## **डिफ़ॉल्ट जूम वैल्यू सेट करें**

Aspose.Slides for C++ अब प्रस्तुति के लिए डिफ़ॉल्ट ज़ूम मान सेट करने का समर्थन करता है जिससे प्रस्तुति खोलते समय ज़ूम पहले से सेट हो जाता है। यह प्रस्तुति के [ViewProperties](https://reference.aspose.com/slides/hi/cpp/aspose.slides/viewproperties/) को सेट करके किया जा सकता है। स्लाइड व्यू प्रॉपर्टीज़ तथा [get_NotesViewProperties](https://reference.aspose.com/slides/hi/cpp/aspose.slides/viewproperties/get_notesviewproperties/) को प्रोग्रामेटिक रूप से सेट किया जा सकता है। इस विषय में, हम एक उदाहरण के साथ दिखाएंगे कि Aspose.Slides में प्रस्तुति की व्यू प्रॉपर्टीज़ कैसे सेट करें।

व्यू प्रॉपर्टीज़ सेट करने के लिए नीचे दिए गए चरणों का पालन करें:

1. [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं
2. प्रस्तुति के व्यू [Properties](https://reference.aspose.com/slides/hi/cpp/aspose.slides/viewproperties/) सेट करें
3. प्रस्तुति को PPTX फ़ाइल के रूप में लिखें

नीचे दिए गए उदाहरण में, हमने स्लाइड व्यू और नोट्स व्यू दोनों के लिए ज़ूम मान सेट किया है।

``` cpp
#include <DOM/ICommonSlideViewProperties.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

// प्रेजेंटेशन की व्यू प्रॉपर्टीज़ सेट करना
presentation->get_ViewProperties()->get_SlideViewProperties()->set_Scale(100); // स्लाइड व्यू के लिए प्रतिशत में ज़ूम मान
presentation->get_ViewProperties()->get_NotesViewProperties()->set_Scale(100); // नोट्स व्यू के लिए प्रतिशत में ज़ूम मान

presentation->Save(u"Zoom_out.pptx", SaveFormat::Pptx);
```

## **ग्रिड स्पेसिंग सेट करें**

[Presentation::get_ViewProperties](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/get_viewproperties/) का उपयोग करके प्रस्तुति-व्यापी व्यू सेटिंग्स तक पहुँचें। मेथड [IViewProperties::get_GridSpacing](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iviewproperties/get_gridspacing/) और [IViewProperties::set_GridSpacing](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iviewproperties/set_gridspacing/) मूल संपादन ग्रिड के अंतराल को पढ़ते या बदलते हैं। यह सेटिंग पूरी प्रस्तुति पर लागू होती है, न कि व्यक्तिगत स्लाइड पर। ग्रिड स्पेसिंग पॉइंट में निर्दिष्ट होती है, जहाँ 72 पॉइंट एक इंच के बराबर होते हैं। API दस्तावेज़ द्वारा आवश्यक होने के अनुसार सकारात्मक मान उपयोग करें।

निम्नलिखित उदाहरण एक मौजूदा `demo.pptx` खोलता है, उसकी वर्तमान ग्रिड स्पेसिंग को प्रिंट करता है, एक चौथाई इंच का अंतराल सेट करता है, और परिणाम को सहेजता है।

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

ग्रिड [drawing guides](/slides/hi/cpp/drawing-guides/) से अलग है। ग्रिड स्पेसिंग एक नियमित अंतराल को नियंत्रित करती है, जबकि ड्राइंग गाइड्स व्यक्तिगत रूप से स्थित क्षैतिज या लंबवत संरेखण रेखाएँ होती हैं। ड्राइंग गाइड्स को जोड़ने, स्थानांतरित करने या हटाने से ग्रिड स्पेसिंग नहीं बदलती।

ग्रिड और ड्राइंग गाइड्स दोनों ही संपादन सहायक हैं। वे PDF, छवियों, SVG, या स्लाइड शो में स्लाइड कंटेंट के रूप में नहीं रेंडर होते। ग्रिड स्पेसिंग को सहेजना यह गारंटी नहीं देता कि एडिटर ग्रिड दिखाएगा: इसकी दृश्यता दर्शक या एडिटर की पसंद पर भी निर्भर करती है।

## **प्रेजेंटेशन खोलते समय टिप्पणियाँ दिखाएँ या छिपाएँ**

[Presentation::get_ViewProperties](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/get_viewproperties/) का उपयोग करके प्रस्तुति-व्यापी व्यू सेटिंग्स तक पहुँचें। मेथड [IViewProperties::get_ShowComments](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iviewproperties/get_showcomments/) और [IViewProperties::set_ShowComments](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iviewproperties/set_showcomments/) का उपयोग करके यह पसंद संग्रहीत करें कि प्रेजेंटेशन PowerPoint या किसी अन्य संगत एडिटर में खोलते समय टिप्पणियों को दिखाया जाना चाहिए या नहीं।

यह सेटिंग केवल संग्रहीत व्यू पसंदको नियंत्रित करती है। यह टिप्पणियों को जोड़ने, हटाने, संपादित करने या हल करने का काम नहीं करती। टिप्पणियों को छिपाने से उनकी सामग्री, लेखक, स्थान, उत्तर और स्थिति बनी रहती है। टिप्पणियों में किए जाने वाले परिवर्तन के लिए देखें [Presentation Comments](/slides/hi/cpp/presentation-comments/)।

निम्नलिखित उदाहरण को एक मौजूदा `comments.pptx` की आवश्यकता है जिसमें टिप्पणियाँ हों। यह वर्तमान दृश्यता सेटिंग को प्रिंट करता है, टिप्पणियों को छिपाने की अनुरोध करता है, और कोई टिप्पणी हटाए बिना नया PPTX सेव करता है। यह प्रारंभिक संपादन व्यू को टिप्पणी दृश्यता के साथ कॉन्फ़िगर करने के लिए [IViewProperties::set_LastView](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iviewproperties/set_lastview/) को [ViewType::SlideView](https://reference.aspose.com/slides/hi/cpp/aspose.slides/viewtype/) के साथ भी उपयोग करता है।

```cpp
#include <system/console.h>
#include <DOM/IViewProperties.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <ViewType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"comments.pptx");
auto showComments = presentation->get_ViewProperties()->get_ShowComments();
System::Console::WriteLine(u"Current comment visibility: {0}", showComments);

presentation->get_ViewProperties()->set_ShowComments(NullableBool::False);
presentation->get_ViewProperties()->set_LastView(ViewType::SlideView);
presentation->Save(u"comments-hidden.pptx", SaveFormat::Pptx);
```

यह सेटिंग यह निर्धारित नहीं करती कि टिप्पणियाँ PDF, HTML, इमेज, नोट्स या हैंडआउट निर्यातों में शामिल हैं या नहीं। संबंधित निर्यात-विशिष्ट विकल्पों को अलग से कॉन्फ़िगर करें।

## **अक्सर पूछे जाने वाले प्रश्न**

**प्रेजेंटेशन पुनः खोलने के बाद ग्रिड क्यों नहीं दिख रही है?**  
फ़ाइल ग्रिड स्पेसिंग सहेजती है, लेकिन एडिटर नियंत्रित करता है कि ग्रिड दिखाया जाए या नहीं। एडिटर की ग्रिड दृश्यता सेटिंग्स जांचें।

**ड्राइंग गाइड्स को साफ़ करने से ग्रिड स्पेसिंग बदलती है क्या?**  
नहीं। ड्राइंग गाइड्स और ग्रिड स्पेसिंग स्वतंत्र सेटिंग्स हैं। गाइड्स को साफ़ करने से संग्रहीत ग्रिड अंतराल अपरिवर्तित रहता है।

**क्या मैं प्रेजेंटेशन के विभिन्न सेक्शन के लिए अलग-अलग व्यू सेटिंग्स सेट कर सकता हूँ?**  
[View settings](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/get_viewproperties/) प्रस्तुति स्तर पर परिभाषित होते हैं ([Normal View](https://reference.aspose.com/slides/hi/cpp/aspose.slides/viewproperties/get_normalviewproperties/)/[Slide View](https://reference.aspose.com/slides/hi/cpp/aspose.slides/viewproperties/get_slideviewproperties/)), न कि सेक्शन के अनुसार, इसलिए एक ही पैरामीटर सेट पूरे दस्तावेज़ पर लागू होता है जब वह खुलता है।

**क्या मैं विभिन्न उपयोगकर्ताओं के लिए अलग-अलग व्यू स्टेट्स पहले से परिभाषित कर सकता हूँ?**  
नहीं। सेटिंग्स फ़ाइल में सहेजी जाती हैं और साझा की जाती हैं। व्यूअर एप्लिकेशन उपयोगकर्ता प्राथमिकताओं का सम्मान कर सकते हैं, लेकिन फ़ाइल स्वयं केवल एक ही सेट व्यू प्रॉपर्टीज़ रखती है।

**क्या मैं पूर्वनिर्धारित View Properties के साथ एक टेम्प्लेट तैयार कर सकता हूँ ताकि नई प्रेजेंटेशन उसी तरीके से खुलें?**  
हां। क्योंकि [view properties](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/get_viewproperties/) प्रस्तुति स्तर पर संग्रहीत होते हैं, आप उन्हें टेम्प्लेट में एम्बेड कर सकते हैं और उसी प्रारंभिक व्यू कॉन्फ़िगरेशन के साथ नई दस्तावेज़ बना सकते हैं।