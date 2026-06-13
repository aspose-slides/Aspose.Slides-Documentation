---
title: पाइथन में प्रस्तुति दृश्य गुण प्राप्त करें और अपडेट करें
linktitle: दृश्य गुण
type: docs
weight: 80
url: /hi/python-net/presentation-view-properties/
keywords:
- दृश्य गुण
- सामान्य दृश्य
- रूपरेखा सामग्री
- रूपरेखा आइकॉन
- वर्टिकल स्प्लिटर स्नैप
- सिंगल व्यू
- बार स्थिति
- आयाम आकार
- स्व समायोजन
- डिफ़ॉल्ट ज़ूम
- पावरपॉइंट
- प्रस्तुति
- पाइथन
- Aspose.Slides
description: "Aspose.Slides for Python via .NET के दृश्य गुणों का उपयोग करके PPT, PPTX और ODP स्लाइड्स को अनुकूलित करें—लेआउट, ज़ूम स्तर और प्रदर्शन सेटिंग्स को समायोजित करें।"
---
## **परिचय**

सामान्य दृश्य में तीन सामग्री क्षेत्रों होते हैं: स्वयं स्लाइड, एक साइड सामग्री क्षेत्र, और नीचे का सामग्री क्षेत्र। विभिन्न सामग्री क्षेत्रों की स्थिति से संबंधित गुण। यह जानकारी एप्लिकेशन को दृश्य स्थिति को फ़ाइल में सहेजने की अनुमति देती है, ताकि जब इसे फिर से खोला जाए तो दृश्य उसी स्थिति में हो जैसा कि प्रस्तुति अंतिम बार सहेजे जाने पर थी।

प्रॉपर्टी [ViewProperties.normal_view_properties](https://reference.aspose.com/slides/hi/python-net/aspose.slides/viewproperties/normal_view_properties/) को प्रस्तुति के सामान्य दृश्य गुणों तक पहुँच प्रदान करने के लिए जोड़ा गया है।  

[NormalViewProperties](https://reference.aspose.com/slides/hi/python-net/aspose.slides/normalviewproperties/), [NormalViewRestoredProperties](https://reference.aspose.com/slides/hi/python-net/aspose.slides/normalviewrestoredproperties/) क्लासें और उनकी संतानें, तथा [SplitterBarStateType](https://reference.aspose.com/slides/hi/python-net/aspose.slides/splitterbarstatetype/) एनीम जोड़ी गई हैं।

## **INormalViewProperties के बारे में** 

सामान्य दृश्य गुणों का प्रतिनिधित्व करता है।

प्रॉपर्टी **ShowOutlineIcons** निर्धारित करती है कि क्या एप्लिकेशन को सामान्य दृश्य मोड में किसी भी सामग्री क्षेत्र में रूपरेखा सामग्री प्रदर्शित करते समय आइकॉन दिखाने चाहिए।  

प्रॉपर्टी **SnapVerticalSplitter** निर्धारित करती है कि क्या साइड क्षेत्र पर्याप्त छोटा होने पर वर्टिकल स्प्लिटर को न्यूनतम स्थिति में स्नैप करना चाहिए।  

प्रॉपर्टी **PreferSingleView** निर्धारित करती है कि उपयोगकर्ता मानक तीन सामग्री क्षेत्रों वाले सामान्य दृश्य के बजाय पूर्ण‑खिड़की एकल‑सामग्री क्षेत्र देखना पसंद करता है या नहीं। यदि सक्षम किया गया, तो एप्लिकेशन संपूर्ण खिड़की में किसी एक सामग्री क्षेत्र को प्रदर्शित करने का विकल्प चुन सकता है।  

प्रॉपर्टी **VerticalBarState** और **HorizontalBarState** निर्धारित करती हैं कि क्षैतिज या लंबवत स्प्लिटर बार किस स्थिति में दिखाया जाना चाहिए। एक क्षैतिज स्प्लिटर बार स्लाइड को नीचे के सामग्री क्षेत्र से अलग करता है, जबकि लंबवत स्प्लिटर बार स्लाइड को साइड सामग्री क्षेत्र से अलग करता है। संभावित मान हैं: **SplitterBarStateType.Minimized, SplitterBarStateType.Maximized** और **SplitterBarStateType.Restored**।  

प्रॉपर्टी **RestoredLeft** और **RestoredTop** निर्धारित करती हैं कि सामान्य दृश्य के ऊपरी या साइड स्लाइड क्षेत्र का आकार क्या होना चाहिए, जब **VerticalBarState** और **HorizontalBarState** के लिए क्रमशः **SplitterBarStateType.Restored** मान लागू किया गया हो।  

## **INormalViewProperties को पुनर्स्थापित करने के बारे में** 

सामान्य दृश्य में स्लाइड क्षेत्र (RestoredTop का बच्चा होने पर चौड़ाई, RestoredLeft का बच्चा होने पर ऊँचाई) का आकार निर्दिष्ट करता है, जब क्षेत्र का आकार परिवर्तनशील पुनर्स्थापित आकार (न तो न्यूनतम और न ही अधिकतम) होता है।  

प्रॉपर्टी **DimensionSize** स्लाइड क्षेत्र का आकार (RestoredTop का बच्चा होने पर चौड़ाई, RestoredLeft का बच्चा होने पर ऊँचाई) निर्दिष्ट करती है।  

प्रॉपर्टी **AutoAdjust** निर्धारित करती है कि जब एप्लिकेशन में दृश्य वाली विंडो को पुन:आकारित किया जाता है, तो साइड सामग्री क्षेत्र का आकार नई आकार के अनुसार स्वयं समायोजित होना चाहिए या नहीं।  

नीचे दिया गया उदाहरण दर्शाता है कि आप प्रस्तुति के लिए **ViewProperties.NormalViewProperties** प्रॉपर्टी तक कैसे पहुँच सकते हैं।  

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as pres:
    pres.view_properties.normal_view_properties.horizontal_bar_state = slides.SplitterBarStateType.RESTORED
    pres.view_properties.normal_view_properties.vertical_bar_state = slides.SplitterBarStateType.MAXIMIZED

    # प्रस्तुति के दृश्य गुणों को पुनर्स्थापित करें
    pres.view_properties.normal_view_properties.restored_top.auto_adjust = True
    pres.view_properties.normal_view_properties.restored_top.dimension_size = 80
    pres.view_properties.normal_view_properties.show_outline_icons = True

    pres.save("presentation_normal_view_state.pptx", slides.export.SaveFormat.PPTX)
```

## **डिफ़ॉल्ट ज़ूम मान सेट करें** 

Aspose.Slides for Python via .NET अब प्रस्तुति के लिए डिफ़ॉल्ट ज़ूम मान सेट करने का समर्थन करता है ताकि जब प्रस्तुति खोली जाए तो ज़ूम पहले से सेट हो। यह किसी प्रस्तुति के [view_properties](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/view_properties/) को सेट करके किया जा सकता है। स्लाइड दृश्य प्रॉपर्टी तथा [notes_view_properties](https://reference.aspose.com/slides/hi/python-net/aspose.slides/viewproperties/notes_view_properties/) को प्रोग्रामेटिक रूप से सेट किया जा सकता है। इस विषय में, हम एक उदाहरण के साथ दिखाएंगे कि Aspose.Slides में प्रस्तुति की View Properties कैसे सेट करें।  

View Properties सेट करने के लिए, कृपया नीचे दिए गए चरणों का पालन करें:

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास का उदाहरण बनाएँ
1. प्रस्तुति की [view properties](https://reference.aspose.com/slides/hi/python-net/aspose.slides/viewproperties/) सेट करें
1. प्रस्तुति को PPTX फ़ाइल के रूप में लिखें

नीचे दिए गए उदाहरण में, हमने स्लाइड दृश्य और नोट्स दृश्य दोनों के लिए ज़ूम मान सेट किया है।  

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # प्रस्तुति के दृश्य गुण सेट करना
    presentation.view_properties.slide_view_properties.scale = 100 # स्लाइड दृश्य के लिए प्रतिशत में ज़ूम मान
    presentation.view_properties.notes_view_properties.scale = 100 # नोट्स दृश्य के लिए प्रतिशत में ज़ूम मान 

    presentation.save("Zoom_out.pptx", slides.export.SaveFormat.PPTX)
```

## **अक्सर पूछे जाने वाले प्रश्न** 

**क्या मैं प्रस्तुति के विभिन्न सेक्शन के लिए अलग-अलग दृश्य सेटिंग्स सेट कर सकता हूँ?**  

[View settings](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/view_properties/) प्रस्तुति स्तर पर ([Normal View](https://reference.aspose.com/slides/hi/python-net/aspose.slides/viewproperties/normal_view_properties/)/[Slide View](https://reference.aspose.com/slides/hi/python-net/aspose.slides/viewproperties/slide_view_properties/)) पर परिभाषित होते हैं, न कि प्रत्येक सेक्शन पर, इसलिए एक ही पैरामीटर सेट पूरे दस्तावेज़ पर लागू होता है जब वह खुलता है।  

**क्या मैं विभिन्न उपयोगकर्ताओं के लिए अलग-अलग दृश्य स्थितियाँ पहले से परिभाषित कर सकता हूँ?**  

नहीं। सेटिंग्स फ़ाइल में संग्रहीत रहती हैं और सभी के बीच साझा की जाती हैं। व्यूअर एप्लिकेशन उपयोगकर्ता प्राथमिकताओं का सम्मान कर सकते हैं, परंतु फ़ाइल में केवल एक ही सेट के दृश्य प्रॉपर्टी होते हैं।  

**क्या मैं पूर्वनिर्धारित View Properties के साथ एक टेम्पलेट तैयार कर सकता हूँ ताकि नई प्रस्तुतियों को वही तरीके से खुला जा सके?**  

हां। क्योंकि [view properties](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/view_properties/) प्रस्तुति स्तर पर संग्रहीत होते हैं, आप उन्हें एक टेम्पलेट में एम्बेड कर सकते हैं और उसी प्रारंभिक दृश्य कॉन्फ़िगरेशन के साथ नई दस्तावेज़ बना सकते हैं।