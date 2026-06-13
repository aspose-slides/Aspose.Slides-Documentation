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
- आउटलाइन आइकॉन्स
- वर्टिकल स्प्लिटर स्नैप
- सिंगल व्यू
- बार स्टेट
- डाइमेंशन साइज
- ऑटो एडजस्ट
- डिफ़ॉल्ट ज़ूम
- PowerPoint
- OpenDocument
- प्रेज़ेंटेशन
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ के व्यू प्रॉपर्टीज़ को खोजें और PPT, PPTX, तथा ODP स्लाइड फ़ॉर्मेट को कस्टमाइज़ करें—लेआउट, ज़ूम स्तर, और डिस्प्ले सेटिंग्स को समायोजित करें।"
---
## **परिचय**

सामान्य दृश्य में तीन सामग्री क्षेत्र होते हैं: स्वयं स्लाइड, एक साइड सामग्री क्षेत्र, और एक बॉटम सामग्री क्षेत्र। विभिन्न सामग्री क्षेत्रों की स्थितियों से संबंधित गुण। यह जानकारी एप्लिकेशन को दृश्य स्थिति को फ़ाइल में सहेजने की अनुमति देती है, ताकि पुनः खोलने पर दृश्य उसी स्थिति में हो जैसा कि प्रस्तुति को अंतिम बार सहेजा गया था।

मेथड [IViewProperties::get_NormalViewProperties](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iviewproperties/get_normalviewproperties/) को जोड़ा गया है ताकि प्रस्तुति के सामान्य दृश्य गुणों तक पहुंच प्रदान की जा सके।

[INormalViewProperties](https://reference.aspose.com/slides/hi/cpp/aspose.slides/inormalviewproperties/), [INormalViewRestoredProperties](https://reference.aspose.com/slides/hi/cpp/aspose.slides/inormalviewrestoredproperties/) इंटरफ़ेस और उनके उत्तराधिकारियों, साथ ही [SplitterBarStateType](https://reference.aspose.com/slides/hi/cpp/aspose.slides/splitterbarstatetype/) एनम को जोड़ा गया है।

## **INormalViewProperties के बारे में**

सामान्य दृश्य गुणों का प्रतिनिधित्व करता है।

प्रॉपर्टी **ShowOutlineIcons** निर्दिष्ट करती है कि जब सामान्य दृश्य मोड में किसी भी सामग्री क्षेत्र में रूपरेखा सामग्री प्रदर्शित हो रही हो तो एप्लिकेशन को आइकॉन दिखाने चाहिए या नहीं।

प्रॉपर्टी **SnapVerticalSplitter** निर्दिष्ट करती है कि साइड क्षेत्र पर्याप्त छोटा होने पर लंबवत स्प्लिटर को न्यूनतम स्थिति में स्नैप किया जाना चाहिए या नहीं।

प्रॉपर्टी **PreferSingleView** निर्दिष्ट करती है कि उपयोगकर्ता तीन सामग्री क्षेत्रों वाले मानक सामान्य दृश्य के बजाय पूरी‑खिड़की का एकल‑सामग्री क्षेत्र देखना पसंद करता है या नहीं। यदि सक्षम किया गया है, तो एप्लिकेशन पूरी विंडो में एक सामग्री क्षेत्र प्रदर्शित करने का चयन कर सकता है।

प्रॉपर्टी **VerticalBarState** और **HorizontalBarState** निर्दिष्ट करती हैं कि क्षैतिज या लंबवत स्प्लिटर बार को किस स्थिति में दिखाया जाना चाहिए। क्षैतिज स्प्लिटर बार स्लाइड को नीचे की सामग्री क्षेत्र से अलग करता है, जबकि लंबवत स्प्लिटर बार स्लाइड को साइड सामग्री क्षेत्र से अलग करता है। संभावित मान हैं: **SplitterBarStateType.Minimized**, **SplitterBarStateType.Maximized** और **SplitterBarStateType.Restored**।

प्रॉपर्टी **RestoredLeft** और **RestoredTop** निर्दिष्ट करती हैं कि सामान्य दृश्य में स्लाइड के शीर्ष या साइड क्षेत्र का आकार क्या होना चाहिए, जब **VerticalBarState** और **HorizontalBarState** के लिये क्रमशः **SplitterBarStateType.Restored** मान लागू किया गया हो।

## **INormalViewProperties को पुनर्स्थापित करने के बारे में**

सामान्य दृश्य में स्लाइड क्षेत्र का आकार (RestoredTop का चाइल्ड होने पर चौड़ाई, RestoredLeft का चाइल्ड होने पर ऊँचाई) निर्दिष्ट करता है, जब क्षेत्र एक परिवर्तनीय पुनर्स्थापित आकार (न तो न्यूनतम और न ही अधिकतम) में हो।

प्रॉपर्टी **DimensionSize** स्लाइड क्षेत्र का आकार (RestoredTop का चाइल्ड होने पर चौड़ाई, RestoredLeft का चाइल्ड होने पर ऊँचाई) निर्दिष्ट करती है।

प्रॉपर्टी **AutoAdjust** निर्दिष्ट करती है कि साइड सामग्री क्षेत्र का आकार नई विंडो आकार बदलने पर पुनर्संगत होना चाहिए या नहीं।

नीचे एक उदाहरण दिया गया है जो दिखाता है कि आप प्रस्तुति के लिए **ViewProperties.NormalViewProperties** गुणों तक कैसे पहुंच सकते हैं।

``` cpp
auto pres = System::MakeObject<Presentation>(u"demo.pptx");
pres->get_ViewProperties()->get_NormalViewProperties()->set_HorizontalBarState(SplitterBarStateType::Restored);
pres->get_ViewProperties()->get_NormalViewProperties()->set_VerticalBarState(SplitterBarStateType::Maximized);

// प्रस्तुति की व्यू प्रॉपर्टीज़ को पुनर्स्थापित करें
pres->get_ViewProperties()->get_NormalViewProperties()->get_RestoredTop()->set_AutoAdjust(true);
pres->get_ViewProperties()->get_NormalViewProperties()->get_RestoredTop()->set_DimensionSize(80.0f);
pres->get_ViewProperties()->get_NormalViewProperties()->set_ShowOutlineIcons(true);

pres->Save(u"presentation_normal_view_state.pptx", SaveFormat::Pptx);
```

## **डिफ़ॉल्ट ज़ूम मान सेट करें**

Aspose.Slides for C++ अब प्रस्तुति के लिए डिफ़ॉल्ट ज़ूम मान सेट करने का समर्थन करता है ताकि प्रस्तुति खोलने पर ज़ूम पहले से ही सेट हो। यह प्रस्तुति की [ViewProperties](https://reference.aspose.com/slides/hi/cpp/aspose.slides/viewproperties/) सेट करके किया जा सकता है। स्लाइड व्यू प्रॉपर्टीज़ के साथ-साथ [get_NotesViewProperties](https://reference.aspose.com/slides/hi/cpp/aspose.slides/viewproperties/get_notesviewproperties/) को भी प्रोग्रामेटिकली सेट किया जा सकता है। इस विषय में, हम एक उदाहरण के साथ देखेंगे कि Aspose.Slides में प्रस्तुति की व्यू प्रॉपर्टीज़ कैसे सेट की जाती हैं।

व्यू प्रॉपर्टीज़ सेट करने के लिए नीचे दिए गए चरणों का पालन करें:

1. एक [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) क्लास का उदाहरण बनाएं
1. प्रस्तुति की व्यू [Properties](https://reference.aspose.com/slides/hi/cpp/aspose.slides/viewproperties/) सेट करें
1. प्रस्तुति को PPTX फ़ाइल के रूप में लिखें

नीचे दिए गए उदाहरण में, हमने स्लाइड व्यू तथा नोट्स व्यू दोनों के लिए ज़ूम मान सेट किया है।

``` cpp
auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

// प्रस्तुति की व्यू प्रॉपर्टीज़ सेट करना
presentation->get_ViewProperties()->get_SlideViewProperties()->set_Scale(100); // स्लाइड व्यू के लिए प्रतिशत में ज़ूम मान
presentation->get_ViewProperties()->get_NotesViewProperties()->set_Scale(100); // नोट्स व्यू के लिए प्रतिशत में ज़ूम मान 

presentation->Save(u"Zoom_out.pptx", SaveFormat::Pptx);
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं प्रस्तुति के विभिन्न अनुभागों के लिए अलग-अलग व्यू सेटिंग्स सेट कर सकता हूँ?**

[View settings](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/get_viewproperties/) प्रस्तुति स्तर पर परिभाषित होते हैं ([Normal View](https://reference.aspose.com/slides/hi/cpp/aspose.slides/viewproperties/get_normalviewproperties/)/[Slide View](https://reference.aspose.com/slides/hi/cpp/aspose.slides/viewproperties/get_slideviewproperties/)), न कि प्रत्येक अनुभाग के लिए, इसलिए खुलते समय पूरे दस्तावेज़ पर एक ही पैरामीटर सेट लागू होता है।

**क्या मैं विभिन्न उपयोगकर्ताओं के लिए अलग-अलग व्यू स्थिति पूर्वनिर्धारित कर सकता हूँ?**

नहीं। सेटिंग्स फ़ाइल में संग्रहीत होती हैं और साझा की जाती हैं। व्यूअर एप्लिकेशन उपयोगकर्ता की प्राथमिकताओं का सम्मान कर सकते हैं, लेकिन फ़ाइल स्वयं में केवल एक सेट व्यू प्रॉपर्टी होती है।

**क्या मैं पूर्वनिर्धारित व्यू प्रॉपर्टीज़ के साथ एक टेम्पलेट तैयार कर सकता हूँ ताकि नई प्रस्तुतियाँ समान रूप से खुलें?**

हाँ। क्योंकि [view properties](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/get_viewproperties/) प्रस्तुति स्तर पर संग्रहीत होते हैं, आप उन्हें एक टेम्पलेट में एम्बेड कर सकते हैं और उसी प्रारंभिक व्यू कॉन्फ़िगरेशन के साथ नए दस्तावेज़ बना सकते हैं।