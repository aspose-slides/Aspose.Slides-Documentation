---
title: .NET में प्रस्तुति दृश्य गुणों को प्राप्त करें और अपडेट करें
linktitle: दृश्य गुण
type: docs
weight: 80
url: /hi/net/presentation-view-properties/
keywords:
- दृश्य गुण
- सामान्य दृश्य
- आउटलाइन सामग्री
- आउटलाइन आइकन
- वर्टिकल स्प्लिटर स्नैप
- एकल दृश्य
- बार स्थिति
- आकार आयाम
- स्वतः समायोजित
- डिफ़ॉल्ट ज़ूम
- PowerPoint
- OpenDocument
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET के दृश्य गुणों की खोज करें ताकि PPT, PPTX और ODP स्लाइड्स के स्वरूप को अनुकूलित किया जा सके—लेआउट, ज़ूम स्तर और डिस्प्ले सेटिंग्स को समायोजित करें।"
---
## **परिचय**

सामान्य दृश्य में तीन सामग्री क्षेत्र होते हैं: स्वयं स्लाइड, एक साइड सामग्री क्षेत्र, और एक बॉटम सामग्री क्षेत्र। विभिन्न सामग्री क्षेत्रों की स्थिति से संबंधित गुण। यह जानकारी एप्लिकेशन को अपने दृश्य स्थिति को फ़ाइल में सहेजने की अनुमति देती है, ताकि जब पुनः खोलें तो दृश्य उसी स्थिति में हो जैसा कि प्रस्तुति को अंतिम बार सहेजा गया था।

Property [IViewProperties.NormalViewProperties](https://reference.aspose.com/slides/hi/net/aspose.slides/iviewproperties/properties/normalviewproperties) को प्रस्तुति के सामान्य दृश्य गुणों तक पहुंच प्रदान करने के लिए जोड़ा गया है।

[INormalViewProperties](https://reference.aspose.com/slides/hi/net/aspose.slides/inormalviewproperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/hi/net/aspose.slides/inormalviewrestoredproperties) इंटरफ़ेस और उनके उत्तराधिकारी, [SplitterBarStateType](https://reference.aspose.com/slides/hi/net/aspose.slides/splitterbarstatetype) एन्‍युम को जोड़ा गया है।

## **INormalViewProperties के बारे में**

सामान्य दृश्य गुणों का प्रतिनिधित्व करता है।

Property **ShowOutlineIcons** निर्धारित करता है कि क्या एप्लिकेशन को सामान्य दृश्य मोड के किसी भी सामग्री क्षेत्र में रूपरेखा सामग्री प्रदर्शित करते समय आइकन दिखाने चाहिए।

Property **SnapVerticalSplitter** निर्धारित करता है कि जब साइड क्षेत्र पर्याप्त छोटा हो तो वर्टिकल स्प्लिटर को न्यूनतम स्थिति में स्नैप करना चाहिए या नहीं।

Property **PreferSingleView** निर्धारित करता है कि उपयोगकर्ता मानक तीन सामग्री क्षेत्रों वाले सामान्य दृश्य के बजाय पूरी विंडो में एकल‑सामग्री क्षेत्र देखना पसंद करता है या नहीं। यदि सक्षम किया गया, तो एप्लिकेशन एक सामग्री क्षेत्र को पूरी विंडो में प्रदर्शित करने का विकल्प चुन सकता है।

Properties **VerticalBarState** और **HorizontalBarState** निर्धारित करते हैं कि क्षैतिज या लंबवत स्प्लिटर बार को किस स्थिति में दिखाया जाना चाहिए। एक क्षैतिज स्प्लिटर बार स्लाइड को नीचे की सामग्री क्षेत्र से अलग करता है, जबकि लंबवत स्प्लिटर बार स्लाइड को साइड सामग्री क्षेत्र से अलग करता है। संभावित मान हैं: **SplitterBarStateType.Minimized, SplitterBarStateType.Maximized** और **SplitterBarStateType.Restored**।

Properties **RestoredLeft** और **RestoredTop** निर्धारित करते हैं कि सामान्य दृश्य के बाएँ या शीर्ष स्लाइड क्षेत्र का आकार क्या होना चाहिए, जब **VerticalBarState** और **HorizontalBarState** के लिए **SplitterBarStateType.Restored** मान लागू किया गया हो।

## **INormalViewProperties को पुनर्स्थापित करने के बारे में**

सामान्य दृश्य के स्लाइड क्षेत्र (चौड़ाई जब RestoredTop का उप‑तत्व हो, ऊँचाई जब RestoredLeft का उप‑तत्व हो) का आकार निर्धारित करता है, जब वह क्षेत्र परिवर्तनीय पुनर्स्थापित आकार (न्यूनतम या अधिकतम नहीं) में हो।

Property **DimensionSize** स्लाइड क्षेत्र (RestoredTop के उप‑तत्व होने पर चौड़ाई, RestoredLeft के उप‑तत्व होने पर ऊँचाई) का आकार निर्दिष्ट करता है।

Property **AutoAdjust** निर्धारित करता है कि जब एप्लिकेशन के भीतर दृश्य वाली विंडो का आकार बदलते समय साइड सामग्री क्षेत्र को नए आकार के अनुसार समायोजित करना चाहिए या नहीं।

नीचे दिया गया उदाहरण दिखाता है कि आप प्रस्तुति के लिए **ViewProperties.NormalViewProperties** गुणों तक कैसे पहुंच सकते हैं।

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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

Aspose.Slides for .NET अब प्रस्तुति के लिए डिफ़ॉल्ट ज़ूम मान सेट करने का समर्थन करता है ताकि प्रस्तुति खोलते समय ज़ूम पहले से सेट हो। यह कार्य [ViewProperties](https://reference.aspose.com/slides/hi/net/aspose.slides/viewproperties) को सेट करके किया जा सकता है। स्लाइड दृश्य गुणों के साथ-साथ [NotesViewProperties](https://reference.aspose.com/slides/hi/net/aspose.slides/viewproperties/properties/notesviewproperties) को भी प्रोग्रामेटिक रूप से सेट किया जा सकता है। इस विषय में, हम एक उदाहरण के साथ देखेंगे कि Aspose.Slides में प्रस्तुति के दृश्य गुणों को कैसे सेट किया जाए।

व्यू गुण सेट करने के लिए, नीचे दिए गए चरणों का पालन करें:

1. एक [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) क्लास का इंस्टेंस बनाएँ
1. प्रस्तुति के View **Properties** सेट करें
1. प्रस्तुति को PPTX फ़ाइल के रूप में लिखें

नीचे दिए गए उदाहरण में, हमने स्लाइड दृश्य और नोट्स दृश्य दोनों के लिए ज़ूम मान सेट किया है।

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("demo.pptx"))
{
    // प्रस्तुति के दृश्य गुण सेट कर रहे हैं
    presentation.ViewProperties.SlideViewProperties.Scale = 100; // स्लाइड दृश्य के लिए प्रतिशत में ज़ूम मान
    presentation.ViewProperties.NotesViewProperties.Scale = 100; // नोट्स दृश्य के लिए प्रतिशत में ज़ूम मान 

    presentation.Save("Zoom_out.pptx", SaveFormat.Pptx);
}
```

## **ग्रिड स्पेसिंग सेट करें**

प्रस्तुति‑व्यापी दृश्य सेटिंग्स तक पहुंचने के लिए [Presentation.ViewProperties](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/viewproperties/) का उपयोग करें। Property [IViewProperties.GridSpacing](https://reference.aspose.com/slides/hi/net/aspose.slides/iviewproperties/gridspacing/) अंतर्निहित संपादन ग्रिड का अंतराल पढ़ता या बदलता है। यह सेटिंग पूरी प्रस्तुति पर लागू होती है, न कि व्यक्तिगत स्लाइड पर। ग्रिड स्पेसिंग पॉइंट्स में निर्दिष्ट की जाती है, जहाँ 72 पॉइंट एक इंच के बराबर होते हैं। API दस्तावेज़ के अनुसार, आवश्यक मान के रूप में सकारात्मक मान का उपयोग करें।

निम्न उदाहरण एक मौजूदा `demo.pptx` खोलता है, उसकी वर्तमान ग्रिड स्पेसिंग प्रिंट करता है, एक चौथाई‑इंच अंतराल सेट करता है, और परिणाम को सहेजता है।

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("demo.pptx");
var gridSpacing = presentation.ViewProperties.GridSpacing;
Console.WriteLine($"Current grid spacing: {gridSpacing} points");

presentation.ViewProperties.GridSpacing = 18f;
presentation.Save("grid-spacing.pptx", SaveFormat.Pptx);
```

ग्रिड, [ड्राइंग गाइड्स](/slides/hi/net/drawing-guides/) से अलग होता है। ग्रिड स्पेसिंग एक नियमित अंतराल नियंत्रित करती है, जबकि ड्राइंग गाइड्स व्यक्तिगत रूप से स्थित क्षैतिज या लंबवत संरेखण रेखाएँ होती हैं। ड्राइंग गाइड्स को जोड़ने, स्थानांतरित करने या साफ़ करने से ग्रिड स्पेसिंग बदलती नहीं है।

ग्रिड और ड्राइंग गाइड दोनों ही संपादन सहायता हैं। इन्हें PDF, इमेज, SVG, या स्लाइड शो में स्लाइड सामग्री के रूप में रेंडर नहीं किया जाता। ग्रिड स्पेसिंग को सहेजने से यह गारंटी नहीं मिलती कि किसी एडिटर में ग्रिड दिखेगा; इसकी दृश्यता दर्शक या एडिटर की प्राथमिकताओं पर भी निर्भर करती है।

## **अक्सर पूछे जाने वाले प्रश्न**

**प्रेज़ेंटेशन को पुनः खोलने के बाद ग्रिड क्यों दिखाई नहीं देता?**  
फ़ाइल ग्रिड स्पेसिंग को संग्रहीत करती है, लेकिन एडिटर नियंत्रित करता है कि ग्रिड प्रदर्शित हो या नहीं। एडिटर की ग्रिड दृश्यता सेटिंग्स की जाँच करें।

**क्या ड्राइंग गाइड्स को साफ़ करने से ग्रिड स्पेसिंग बदलती है?**  
नहीं। ड्राइंग गाइड्स और ग्रिड स्पेसिंग स्वतंत्र सेटिंग्स हैं। गाइड्स को साफ़ करने से संग्रहीत ग्रिड अंतराल अपरिवर्तित रहता है।

**क्या मैं प्रस्तुति के विभिन्न सेक्शन के लिए अलग‑अलग दृश्य सेटिंग्स सेट कर सकता हूँ?**  
[View settings](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/viewproperties/) प्रस्तुति स्तर पर परिभाषित होती हैं ([Normal View](https://reference.aspose.com/slides/hi/net/aspose.slides/viewproperties/normalviewproperties/)/[Slide View](https://reference.aspose.com/slides/hi/net/aspose.slides/viewproperties/slideviewproperties/)), न कि सेक्शन‑वाइज़, इसलिए एक ही पैरामीटर सेट पूरे दस्तावेज़ के खुलने पर लागू होता है।

**क्या मैं विभिन्न उपयोगकर्ताओं के लिए अलग‑अलग दृश्य स्थिति पूर्वनिर्धारित कर सकता हूँ?**  
नहीं। सेटिंग्स फ़ाइल में संग्रहीत होती हैं और साझा होती हैं। व्यूअर एप्लिकेशन उपयोगकर्ता प्राथमिकताओं का सम्मान कर सकते हैं, लेकिन फ़ाइल में केवल एक सेट दृश्य गुण होते हैं।

**क्या मैं एक टेम्पलेट तैयार कर सकता हूँ जिसमें पूर्वनिर्धारित View Properties हों ताकि नई प्रस्तुति समान रूप से खुले?**  
हां। क्योंकि [view properties](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/viewproperties/) प्रस्तुति स्तर पर संग्रहीत होती हैं, आप उन्हें टेम्पलेट में एंबेड कर सकते हैं और उसी प्रारंभिक दृश्य कॉन्फ़िगरेशन के साथ नई दस्तावेज़ बना सकते हैं।