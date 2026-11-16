---
title: C++ में प्रस्तुति दृश्य गुणों को पुनः प्राप्त और अद्यतन करें
linktitle: दृश्य गुण
type: docs
weight: 80
url: /hi/cpp/presentation-view-properties/
keywords: 
- दृश्य गुण
- सामान्य दृश्य
- रूपरेखा सामग्री
- रूपरेखा आइकन
- लंबवत विभाजक स्नैप
- एकल दृश्य
- बार स्थिति
- आयाम आकार
- स्वचालित समायोजन
- डिफ़ॉल्ट ज़ूम
- PowerPoint
- OpenDocument
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ का उपयोग करके PowerPoint प्रस्तुतियों में सामान्य दृश्य लेआउट, स्लाइड और नोट्स ज़ूम, ग्रिड अंतराल, और टिप्पणी दृश्यमानता को कॉन्फ़िगर करें।"
---
## **परिचय**

PowerPoint के सामान्य दृश्य में, स्लाइड साइड पेन (थंबनेल या रूपरेखा) और नीचे नोट्स पेन के बीच दिखाई देती है। Aspose.Slides for C++ प्रस्तुति की सहेजी गई संपादन प्राथमिकताओं को [Presentation::get_ViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_viewproperties/) के माध्यम से उजागर करता है। इनमें पेन लेआउट, ज़ूम स्तर, ग्रिड अंतराल, और टिप्पणी दृश्यमानता शामिल हैं।

## **INormalViewProperties के बारे में**

[ get_NormalViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/iviewproperties/get_normalviewproperties/) का उपयोग करके आप [INormalViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/) इंटरफ़ेस तक पहुँच सकते हैं। [set_ShowOutlineIcons](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/set_showoutlineicons/) निर्धारित करता है कि रूपरेखा में स्लाइड शीर्षकों के बगल में प्रतीक दिखें या नहीं। [set_SnapVerticalSplitter](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/set_snapverticalsplitter/) उपयोगकर्ता द्वारा साइड पेन को संकुचित करने पर उसे न्यूनतम स्थिति में स्नैप करने की सुविधा देता है। [set_PreferSingleView](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/set_prefersingleview/) पूर्ण विंडो में एक पेन प्रदर्शित करने की प्राथमिकता को दर्शाता है।

[set_VerticalBarState](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/set_verticalbarstate/) साइड पेन और स्लाइड के बीच विभाजक को नियंत्रित करता है। [set_HorizontalBarState](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/set_horizontalbarstate/) नोट्स पेन के ऊपर विभाजक को नियंत्रित करता है। दोनों [SplitterBarStateType](https://reference.aspose.com/slides/cpp/aspose.slides/splitterbarstatetype/) का मान `Minimized`, `Maximized`, या `Restored` स्वीकार करते हैं।

## **INormalViewProperties को पुनर्स्थापित करने के बारे में**

जब विभाजक पुनर्स्थापित किया जाता है, तो [get_RestoredLeft](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/get_restoredleft/) साइड पेन का सहेचा आकार प्रदान करता है और [get_RestoredTop](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/get_restoredtop/) ऊपर के स्लाइड क्षेत्र का सहेचा आकार प्रदान करता है। दोनों [INormalViewRestoredProperties](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewrestoredproperties/) को उजागर करते हैं। इसका [set_DimensionSize](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewrestoredproperties/set_dimensionsize/) मेथड 0 से 100 प्रतिशत तक का मान लेता है, और [set_AutoAdjust](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewrestoredproperties/set_autoadjust/) नियंत्रित करता है कि विंडो आकार बदलने पर संपादक आकार को स्वचालित रूप से समायोजित करे या नहीं।

यह उदाहरण मौजूदा प्रस्तुति को अपडेट करता है। यह क्षैतिज विभाजक को पुनर्स्थापित करता है, [get_RestoredTop](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/get_restoredtop/) द्वारा उजागर ऊपर के स्लाइड क्षेत्र का आकार 80 % पर सेट करता है तथा स्वचालित समायोजन सक्षम करता है, और लंबवत विभाजक को अधिकतम करता है। यह रूपरेखा दृश्य के लिए [set_ShowOutlineIcons](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/set_showoutlineicons/) के साथ रूपरेखा आइकनों को भी सक्षम करता है।

```cpp
#include <DOM/INormalViewProperties.h>
#include <DOM/INormalViewRestoredProperties.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <DOM/SplitterBarStateType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

auto normalView = presentation->get_ViewProperties()->get_NormalViewProperties();
normalView->set_HorizontalBarState(SplitterBarStateType::Restored);
normalView->set_VerticalBarState(SplitterBarStateType::Maximized);
auto restoredTop = normalView->get_RestoredTop();
restoredTop->set_AutoAdjust(true);
restoredTop->set_DimensionSize(80.0f);
normalView->set_ShowOutlineIcons(true);

presentation->Save(u"presentation_normal_view_state.pptx", SaveFormat::Pptx);
```

## **डिफ़ॉल्ट ज़ूम मान सेट करें**

[get_SlideViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/iviewproperties/get_slideviewproperties/) और [get_NotesViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/iviewproperties/get_notesviewproperties/) संपादक के लिए स्वतंत्र ज़ूम सेटिंग्स संग्रहीत करते हैं। ये सेटिंग्स स्लाइड आयाम, स्लाइड‑शो प्लेबैक, या छवि निर्यात रिज़ॉल्यूशन को प्रभावित नहीं करतीं।

यह उदाहरण मौजूदा प्रस्तुति को खोलता है और स्लाइड को संपादन विंडो में फ़िट करने के लिए [set_VariableScale](https://reference.aspose.com/slides/cpp/aspose.slides/icommonslideviewproperties/set_variablescale/) के साथ स्वचालित स्केलिंग सक्षम करता है। नोट्स पेज के लिए यह स्वचालित स्केलिंग को निष्क्रिय करता है और एक स्थिर 80 % ज़ूम सेट करने के लिये [set_Scale](https://reference.aspose.com/slides/cpp/aspose.slides/icommonslideviewproperties/set_scale/) का उपयोग करता है।

```cpp
#include <DOM/ICommonSlideViewProperties.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

auto viewProperties = presentation->get_ViewProperties();
viewProperties->get_SlideViewProperties()->set_VariableScale(true);
auto notesView = viewProperties->get_NotesViewProperties();
notesView->set_VariableScale(false);
notesView->set_Scale(80);

presentation->Save(u"zoom.pptx", SaveFormat::Pptx);
```

## **ग्रिड अंतराल सेट करें**

[set_GridSpacing](https://reference.aspose.com/slides/cpp/aspose.slides/iviewproperties/set_gridspacing/) प्रस्तुति में संपादन ग्रिड रेखाओं के बीच की दूरी निर्धारित करता है। यह पॉइंट में सकारात्मक मान लेता है, जहाँ 1 इंच में 72 पॉइंट होते हैं। यह उदाहरण मौजूदा प्रस्तुति में वर्तमान अंतराल को प्रदर्शित करता है और अंतराल को 18 पॉइंट (एक चौथाई इंच) पर सेट करके क्वार्टर‑इंच ग्रिड सहेजता है।

```cpp
#include <system/console.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

auto viewProperties = presentation->get_ViewProperties();
auto gridSpacing = viewProperties->get_GridSpacing();
System::Console::WriteLine(u"Current grid spacing: {0} points", gridSpacing);

viewProperties->set_GridSpacing(18.0f);

presentation->Save(u"grid-spacing.pptx", SaveFormat::Pptx);
```

ग्रिड एक निश्चित अंतराल पर दोहराता है। [Drawing guides](/slides/hi/cpp/drawing-guides/) व्यक्तिगत क्षैतिज या लंबवत स्थितियों को चिह्नित करते हैं। दोनों ही संपादन सहायक हैं और केवल उन संपादकों में दिखते हैं जो इन्हें प्रदर्शित करते हैं। स्लाइड‑शो और PDF, छवि, या SVG निर्यात में इन्हें छोड़ दिया जाता है।

## **प्रेज़ेंटेशन खोलते समय टिप्पणी दिखाएँ या छुपाएँ**

[set_ShowComments](https://reference.aspose.com/slides/cpp/aspose.slides/iviewproperties/set_showcomments/) एक पसंद संग्रहीत करता है जिसे संगत संपादक प्रेज़ेंटेशन खोलते समय उपयोग करते हैं। टिप्पणियों वाले मौजूदा प्रेज़ेंटेशन के लिये यह उदाहरण वर्तमान सेटिंग को प्रदर्शित करता है और टिप्पणी छिपी हुई एक प्रति सहेजता है। यह साथ ही [set_LastView](https://reference.aspose.com/slides/cpp/aspose.slides/iviewproperties/set_lastview/) को [ViewType::SlideView](https://reference.aspose.com/slides/cpp/aspose.slides/viewtype/) के साथ कॉल करता है ताकि प्रतिलिपि स्लाइड दृश्य में खुले।

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

auto viewProperties = presentation->get_ViewProperties();
auto showComments = viewProperties->get_ShowComments();
System::Console::WriteLine(u"Current comment visibility: {0}", showComments);

viewProperties->set_ShowComments(NullableBool::False);
viewProperties->set_LastView(ViewType::SlideView);

presentation->Save(u"comments-hidden.pptx", SaveFormat::Pptx);
```

टिप्पणियों को छुपाने से उनका पाठ, लेखक, स्थिति, जवाब, और स्टेटस संरक्षित रहता है। स्वयं टिप्पणी को बदलने के लिये देखें [Presentation Comments](/slides/hi/cpp/presentation-comments/)। निर्यात सेटिंग्स यह नियंत्रित करती हैं कि टिप्पणी PDF, HTML, छवियों, नोट्स, या हैंडआउट्स में दिखें या न दिखें।

## **अक्सर पूछे जाने वाले प्रश्न**

**ग्रिड को पुनः खोलने पर वह क्यों छिपा रहता है?**  
प्रेज़ेंटेशन ग्रिड अंतराल को संग्रहीत करता है। ग्रिड देखने के लिए संपादक में ग्रिड दृश्यमानता को सक्षम करें।

**ड्राइंग गाइड्स को साफ़ करने से ग्रिड अंतराल बदलता है क्या?**  
नहीं। गाइड जोड़ने, स्थानांतरित करने या हटाने से ग्रिड अंतराल अपरिवर्तित रहता है।

**क्या प्रेज़ेंटेशन के विभिन्न भागों के अलग‑अलग दृश्य सेटिंग्स हो सकते हैं?**  
नहीं। [Presentation::get_ViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_viewproperties/) पूरी प्रस्तुति पर लागू होता है।

**क्या मैं विभिन्न उपयोगकर्ताओं के लिये अलग‑अलग दृश्य सेटिंग्स सहेज सकता हूँ?**  
फ़ाइल सभी के लिये एक ही सेट की दृश्य गुण संग्रहीत करती है। एक संपादक उपयोगकर्ता की स्थानीय प्राथमिकताओं को भी लागू कर सकता है।

**क्या मैं टेम्प्लेट में दृश्य सेटिंग्स सहेज सकता हूँ?**  
हां। टेम्प्लेट से बनायी गई प्रस्तुतियों में उसके सहेजे हुए दृश्य सेटिंग्स विरासत में मिलते हैं।