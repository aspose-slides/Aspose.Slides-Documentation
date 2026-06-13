---
title: .NET में प्रस्तुति व्यू गुणों को प्राप्त करें और अपडेट करें
linktitle: व्यू गुण
type: docs
weight: 80
url: /hi/net/presentation-view-properties/
keywords:
- व्यू गुण
- सामान्य दृश्य
- रूपरेखा सामग्री
- रूपरेखा आइकन
- ऊर्ध्वाधर स्प्लिटर को स्नैप करें
- एकल दृश्य
- बार स्थिति
- आयाम आकार
- स्वतः समायोजन
- डिफ़ॉल्ट ज़ूम
- PowerPoint
- OpenDocument
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET व्यू गुणों की खोज करें ताकि आप PPT, PPTX और ODP स्लाइड फ़ॉर्मैट्स को अनुकूलित कर सकें—लेआउट, ज़ूम स्तर और डिस्प्ले सेटिंग्स को समायोजित करें।"
---
## **परिचय**

सामान्य दृश्य में तीन सामग्री क्षेत्रों होते हैं: स्लाइड स्वयं, एक साइड सामग्री क्षेत्र, और नीचे का सामग्री क्षेत्र। विभिन्न सामग्री क्षेत्रों की स्थिति से संबंधित गुण। यह जानकारी एप्लिकेशन को अपने दृश्य स्थिति को फ़ाइल में सहेजने की अनुमति देती है, ताकि फ़ाइल को पुनः खोलने पर दृश्य वही स्थिति में हो जैसा कि प्रस्तुति को अंतिम बार सहेजा गया था।

Property [IViewProperties.NormalViewProperties](https://reference.aspose.com/slides/hi/net/aspose.slides/iviewproperties/properties/normalviewproperties) को प्रस्तुति के सामान्य दृश्य गुणों तक पहुंच प्रदान करने के लिए जोड़ा गया है।

[INormalViewProperties](https://reference.aspose.com/slides/hi/net/aspose.slides/inormalviewproperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/hi/net/aspose.slides/inormalviewrestoredproperties) इंटरफ़ेस और उनके अवयव, [SplitterBarStateType](https://reference.aspose.com/slides/hi/net/aspose.slides/splitterbarstatetype) एनम को जोड़ा गया है।

## **INormalViewProperties के बारे में**

सामान्य दृश्य गुणों को दर्शाता है।

Property **ShowOutlineIcons** निर्दिष्ट करता है कि सामान्य दृश्य मोड में किसी भी सामग्री क्षेत्र में रूपरेखा सामग्री दिखाते समय एप्लिकेशन को आइकन दिखाने चाहिए या नहीं।

Property **SnapVerticalSplitter** निर्दिष्ट करता है कि साइड क्षेत्र पर्याप्त छोटा होने पर ऊर्ध्वाधर स्प्लिटर को न्यूनतम स्थिति में स्नैप किया जाना चाहिए या नहीं।

Property **PreferSingleView** निर्दिष्ट करता है कि उपयोगकर्ता तीन सामग्री क्षेत्रों वाले मानक सामान्य दृश्य की बजाय पूरे विंडो में एकल‑सामग्री क्षेत्र देखना पसंद करता है या नहीं। यदि सक्षम किया गया, तो एप्लिकेशन एक सामग्री क्षेत्र को पूरे विंडो में प्रदर्शित करना चुन सकता है।

Properties **VerticalBarState** और **HorizontalBarState** निर्दिष्ट करते हैं कि क्षैतिज या ऊर्ध्वाधर स्प्लिटर बार किस स्थिति में दिखाया जाना चाहिए। एक क्षैतिज स्प्लिटर बार स्लाइड को नीचे के सामग्री क्षेत्र से अलग करता है, जबकि ऊर्ध्वाधर स्प्लिटर बार स्लाइड को साइड सामग्री क्षेत्र से अलग करता है। संभावित मान हैं: **SplitterBarStateType.Minimized**, **SplitterBarStateType.Maximized** और **SplitterBarStateType.Restored**।

Properties **RestoredLeft** और **RestoredTop** सामान्य दृश्य के शीर्ष या साइड स्लाइड क्षेत्र के आकार को निर्दिष्ट करते हैं, जब **VerticalBarState** और **HorizontalBarState** के लिए क्रमशः **SplitterBarStateType.Restored** मान लागू हो।

## **INormalViewProperties को पुनर्स्थापित करने के बारे में**

जब क्षेत्र का आकार परिवर्तनीय पुनर्स्थापित आकार (न्यूनतम या अधिकतम नहीं) हो, तो सामान्य दृश्य के स्लाइड क्षेत्र (RestoredTop का चाइल्ड होने पर चौड़ाई, RestoredLeft का चाइल्ड होने पर ऊँचाई) के आकार को निर्दिष्ट करता है।

Property **DimensionSize** स्लाइड क्षेत्र का आकार (restoredTop का चाइल्ड होने पर चौड़ाई, restoredLeft का चाइल्ड होने पर ऊँचाई) निर्दिष्ट करता है।

Property **AutoAdjust** निर्दिष्ट करता है कि विंडो का आकार बदलने पर साइड सामग्री क्षेत्र का आकार नई स्थिति के लिए कैसे समायोजित होना चाहिए।

नीचे दिया गया उदाहरण दिखाता है कि आप प्रस्तुति के लिए **ViewProperties.NormalViewProperties** गुणों तक कैसे पहुंच सकते हैं।

```c#
using (Presentation pres = new Presentation("demo.pptx"))
{
    pres.ViewProperties.NormalViewProperties.HorizontalBarState = SplitterBarStateType.Restored;
    pres.ViewProperties.NormalViewProperties.VerticalBarState = SplitterBarStateType.Maximized;

    // प्रस्तुति के दृश्य गुणों को पुनर्स्थापित करें
    pres.ViewProperties.NormalViewProperties.RestoredTop.AutoAdjust = true;
    pres.ViewProperties.NormalViewProperties.RestoredTop.DimensionSize = 80;
    pres.ViewProperties.NormalViewProperties.ShowOutlineIcons = true;

    pres.Save("presentation_normal_view_state.pptx", SaveFormat.Pptx);
}
```

## **डिफ़ॉल्ट ज़ूम मान सेट करें**

Aspose.Slides for .NET अब प्रस्तुति के लिए डिफ़ॉल्ट ज़ूम मान सेट करने का समर्थन करता है ताकि प्रस्तुति खोलते समय ज़ूम पहले से ही सेट हो। इसे प्रस्तुति के [ViewProperties](https://reference.aspose.com/slides/hi/net/aspose.slides/viewproperties) को सेट करके किया जा सकता है। स्लाइड व्यू प्रॉपर्टीज़ के साथ-साथ [NotesViewProperties](https://reference.aspose.com/slides/hi/net/aspose.slides/viewproperties/properties/notesviewproperties) को भी प्रोग्रामेटिकली सेट किया जा सकता है। इस विषय में, हम एक उदाहरण के साथ देखेंगे कि Aspose.Slides में प्रस्तुति की View Properties को कैसे सेट करें।

व्यू प्रॉपर्टीज़ सेट करने के लिए नीचे दिए गए चरणों का पालन करें:

1. [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) क्लास का एक उदाहरण बनाएँ
1. प्रस्तुति की View [Properties](https://reference.aspose.com/slides/hi/net/aspose.slides/viewproperties) सेट करें
1. प्रस्तुति को PPTX फ़ाइल के रूप में लिखें

नीचे दिए गये उदाहरण में, हमने स्लाइड व्यू और नोट्स व्यू दोनों के लिए ज़ूम मान सेट किया है।

```c#
using (Presentation presentation = new Presentation("demo.pptx"))
{
    // प्रस्तुति के व्यू गुण सेट करना
    presentation.ViewProperties.SlideViewProperties.Scale = 100; // स्लाइड व्यू के लिए प्रतिशत में ज़ूम मान
    presentation.ViewProperties.NotesViewProperties.Scale = 100; // नोट्स व्यू के लिए प्रतिशत में ज़ूम मान 

    presentation.Save("Zoom_out.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**क्या मैं प्रस्तुति के विभिन्न सेक्शन के लिए अलग‑अलग दृश्य सेटिंग्स सेट कर सकता हूँ?**

[View settings](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/viewproperties/) प्रस्तुति स्तर पर परिभाषित होते हैं ([Normal View](https://reference.aspose.com/slides/hi/net/aspose.slides/viewproperties/normalviewproperties/)/[Slide View](https://reference.aspose.com/slides/hi/net/aspose.slides/viewproperties/slideviewproperties/)), न कि प्रति सेक्शन, इसलिए जब फ़ाइल खुलती है तो पूरे दस्तावेज़ पर एक ही पैरामीटर सेट लागू होता है।

**क्या मैं विभिन्न उपयोगकर्ताओं के लिए अलग‑अलग दृश्य स्थितियों को पूर्वपरिभाषित कर सकता हूँ?**

नहीं। सेटिंग्स फ़ाइल में संग्रहीत होती हैं और सभी के बीच साझा की जाती हैं। व्यूअर एप्लिकेशन उपयोगकर्ता की प्राथमिकताओं को मान सकते हैं, लेकिन फ़ाइल स्वयं केवल एक सेट दृश्य गुणों को रखती है।

**क्या मैं एक टेम्प्लेट तैयार कर सकता हूँ जिसमें पूर्वनिर्धारित View Properties हों ताकि नई प्रस्तुतियाँ उसी तरह खुलें?**

हां। क्योंकि [view properties](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/viewproperties/) प्रस्तुति स्तर पर संग्रहीत होते हैं, आप उन्हें टेम्प्लेट में एंबेड कर सकते हैं और नई दस्तावेज़ उसी प्रारंभिक दृश्य कॉन्फ़िगरेशन के साथ बना सकते हैं।