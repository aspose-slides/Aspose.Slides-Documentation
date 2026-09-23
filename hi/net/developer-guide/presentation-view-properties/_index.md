---
title: ".NET में प्रस्तुति व्यू प्रॉपर्टीज़ को पुनः प्राप्त करें और अपडेट करें"
linktitle: "व्यू प्रॉपर्टीज़"
type: docs
weight: 80
url: /hi/net/presentation-view-properties/
keywords:
- "व्यू प्रॉपर्टीज़"
- "नॉर्मल व्यू"
- "आउटलाइन सामग्री"
- "आउटलाइन आइकन"
- "वर्टिकल स्प्लिटर को स्नैप करें"
- "सिंगल व्यू"
- "बार स्टेट"
- "डायमेंशन साइज"
- "ऑटो एडजस्ट"
- "डिफ़ॉल्ट ज़ूम"
- "PowerPoint"
- "OpenDocument"
- "प्रस्तुति"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Aspose.Slides for .NET के व्यू प्रॉपर्टीज़ की खोज करें ताकि आप PPT, PPTX, और ODP स्लाइड्स के फॉर्मेट को कस्टमाइज़ कर सकें—लेआउट, ज़ूम लेवल और डिस्प्ले सेटिंग्स को समायोजित करें।"
---
## **परिचय**

Normal view में तीन सामग्री क्षेत्रों होते हैं: स्लाइड स्वयं, एक साइड सामग्री क्षेत्र, और नीचे का सामग्री क्षेत्र। विभिन्न सामग्री क्षेत्रों की स्थिति से संबंधित प्रॉपर्टीज़। यह जानकारी एप्लिकेशन को व्यू स्थिति को फ़ाइल में सहेजने की अनुमति देती है, ताकि जब पुनः खोला जाए तो व्यू उसी स्थिति में हो जैसा कि प्रस्तुति को अंतिम बार सहेजे जाने पर था।

Property [IViewProperties.NormalViewProperties](https://reference.aspose.com/slides/hi/net/aspose.slides/iviewproperties/properties/normalviewproperties) को प्रस्तुति की normal view प्रॉपर्टीज़ तक पहुँच प्रदान करने के लिए जोड़ा गया है। 

[INormalViewProperties](https://reference.aspose.com/slides/hi/net/aspose.slides/inormalviewproperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/hi/net/aspose.slides/inormalviewrestoredproperties) इंटरफ़ेस और उनके उत्तराधिकारी, [SplitterBarStateType](https://reference.aspose.com/slides/hi/net/aspose.slides/splitterbarstatetype) एनम को जोड़ा गया है।

## **INormalViewProperties के बारे में**

Normal view प्रॉपर्टीज़ का प्रतिनिधित्व करता है।

प्रॉपर्टी **ShowOutlineIcons** यह निर्दिष्ट करती है कि normal view मोड के किसी भी सामग्री क्षेत्र में रूपरेखा सामग्री प्रदर्शित करते समय एप्लिकेशन को आइकन दिखाने चाहिए या नहीं।

प्रॉपर्टी **SnapVerticalSplitter** यह निर्दिष्ट करती है कि साइड क्षेत्र पर्याप्त छोटा होने पर वर्टिकल स्प्लिटर को न्यूनतम स्थिति में स्नैप करना चाहिए या नहीं।

प्रॉपर्टी **PreferSingleView** यह निर्दिष्ट करती है कि उपयोगकर्ता मानक normal view (तीन सामग्री क्षेत्रों के साथ) की तुलना में पूर्ण-विंडो एक-समग्री क्षेत्र देखना पसंद करता है या नहीं। यदि सक्षम किया गया, तो एप्लिकेशन पूरे विंडो में किसी एक सामग्री क्षेत्र को प्रदर्शित करने का चयन कर सकता है।

प्रॉपर्टी **VerticalBarState** और **HorizontalBarState** यह निर्दिष्ट करती हैं कि क्षैतिज या वर्टिकल स्प्लिटर बार को किस स्थिति में दिखाया जाना चाहिए। एक क्षैतिज स्प्लिटर बार स्लाइड को नीचे के सामग्री क्षेत्र से अलग करता है, वर्टिकल स्प्लिटर बार स्लाइड को साइड सामग्री क्षेत्र से अलग करता है। संभावित मान हैं: **SplitterBarStateType.Minimized, SplitterBarStateType.Maximized** और **SplitterBarStateType.Restored**।

प्रॉपर्टी **RestoredLeft** और **RestoredTop** यह निर्दिष्ट करती हैं कि normal view में शीर्ष या साइड स्लाइड क्षेत्र का आकार क्या होना चाहिए, जब **VerticalBarState** और **HorizontalBarState** के लिए **SplitterBarStateType.Restored** मान लागू किया गया हो।

## **INormalViewProperties को पुनर्स्थापित करने के बारे में**

जब क्षेत्र परिवर्ती पुनर्स्थापित आकार (न्यूनतम या अधिकतम नहीं) का हो तो normal view में स्लाइड क्षेत्र (RestoredTop की उपशाखा होने पर चौड़ाई, RestoredLeft की उपशाखा होने पर ऊँचाई) का आकार निर्दिष्ट करता है।

प्रॉपर्टी **DimensionSize** स्लाइड क्षेत्र (restoredTop की उपशाखा होने पर चौड़ाई, restoredLeft की उपशाखा होने पर ऊँचाई) का आकार निर्दिष्ट करती है।

प्रॉपर्टी **AutoAdjust** यह निर्दिष्ट करती है कि विंडो को री-साइज़ करने पर साइड सामग्री क्षेत्र का आकार नई विंडो के आकार के अनुसार समायोजित होना चाहिए या नहीं।

नीचे दिया गया उदाहरण दर्शाता है कि आप प्रस्तुति के लिए **ViewProperties.NormalViewProperties** प्रॉपर्टीज़ तक कैसे पहुँच सकते हैं।

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("demo.pptx"))
{
    pres.ViewProperties.NormalViewProperties.HorizontalBarState = SplitterBarStateType.Restored;
    pres.ViewProperties.NormalViewProperties.VerticalBarState = SplitterBarStateType.Maximized;

    // प्रस्तुति की व्यू प्रॉपर्टीज़ को पुनर्स्थापित करें
    pres.ViewProperties.NormalViewProperties.RestoredTop.AutoAdjust = true;
    pres.ViewProperties.NormalViewProperties.RestoredTop.DimensionSize = 80;
    pres.ViewProperties.NormalViewProperties.ShowOutlineIcons = true;

    pres.Save("presentation_normal_view_state.pptx", SaveFormat.Pptx);
}
```

## **डिफ़ॉल्ट ज़ूम मान सेट करें**

Aspose.Slides for .NET अब प्रस्तुति के लिए डिफ़ॉल्ट ज़ूम मान सेट करने का समर्थन करता है, ताकि जब प्रस्तुति खोली जाए, ज़ूम पहले से ही सेट हो। यह प्रस्तुति की [ViewProperties](https://reference.aspose.com/slides/hi/net/aspose.slides/viewproperties) को सेट करके किया जा सकता है। स्लाइड व्यू प्रॉपर्टीज़ तथा [NotesViewProperties](https://reference.aspose.com/slides/hi/net/aspose.slides/viewproperties/properties/notesviewproperties) को प्रोग्रामैटिकली स्थापित किया जा सकता है। इस विषय में, हम एक उदाहरण के साथ देखेंगे कि Aspose.Slides में प्रस्तुति की व्यू प्रॉपर्टीज़ को कैसे सेट किया जाता है।

व्यू प्रॉपर्टीज़ सेट करने के लिए नीचे दिए गए चरणों का पालन करें:

1. Create an instance of [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) class
1. Set View [Properties](https://reference.aspose.com/slides/hi/net/aspose.slides/viewproperties) of Presentation
1. Write the presentation as a PPTX file

नीचे दिए गए उदाहरण में, हमने स्लाइड व्यू तथा नोट्स व्यू दोनों के लिए ज़ूम मान सेट किया है।

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("demo.pptx"))
{
    // प्रस्तुति की व्यू प्रॉपर्टीज़ सेट करना
    presentation.ViewProperties.SlideViewProperties.Scale = 100; // स्लाइड व्यू के लिए प्रतिशत में ज़ूम मान
    presentation.ViewProperties.NotesViewProperties.Scale = 100; // नोट्स व्यू के लिए प्रतिशत में ज़ूम मान 

    presentation.Save("Zoom_out.pptx", SaveFormat.Pptx);
}
```

## **ग्रिड स्पेसिंग सेट करें**

प्रस्तुति-व्यापी व्यू सेटिंग्स तक पहुँचने के लिए [Presentation.ViewProperties](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/viewproperties/) का उपयोग करें। प्रॉपर्टी [IViewProperties.GridSpacing](https://reference.aspose.com/slides/hi/net/aspose.slides/iviewproperties/gridspacing/) अंतर्निहित एडिटिंग ग्रिड के अंतराल को पढ़ती या बदलती है। यह सेटिंग संपूर्ण प्रस्तुति पर लागू होती है, व्यक्तिगत स्लाइड पर नहीं। ग्रिड स्पेसिंग पॉइंट्स में निर्दिष्ट की जाती है, जहाँ 72 पॉइंट्स एक इंच के बराबर होते हैं। API दस्तावेज़ द्वारा आवश्यकतानुसार सकारात्मक मान उपयोग करें।

निम्न उदाहरण एक मौजूदा `demo.pptx` खोलता है, उसकी वर्तमान ग्रिड स्पेसिंग प्रिंट करता है, एक क्वार्टर-इंच अंतराल सेट करता है, और परिणाम सहेजता है।

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

ग्रिड [drawing guides](/slides/hi/net/drawing-guides/) से अलग है। ग्रिड स्पेसिंग नियमित अंतराल को नियंत्रित करती है, जबकि ड्राइंग गाइड्स व्यक्तिगत रूप से स्थित क्षैतिज या वर्टिकल संरेखण रेखाएँ होती हैं। ड्राइंग गाइड्स को जोड़ना, हटाना या साफ़ करना ग्रिड स्पेसिंग को बदलता नहीं है।

ग्रिड और ड्राइंग गाइड दोनों ही एडिटिंग सहायक हैं। वे PDF, इमेज, SVG, या स्लाइड शो में स्लाइड सामग्री के रूप में रेंडर नहीं होते। ग्रिड स्पेसिंग को संग्रहीत करना यह सुनिश्चित नहीं करता कि कोई एडिटर ग्रिड दिखाएगा: इसकी दृश्यता दर्शक या एडिटर की प्राथमिकताओं पर भी निर्भर करती है।

## **प्रस्तुति खोलते समय टिप्पणियाँ दिखाएँ या छिपाएँ**

[Presentation.ViewProperties](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/viewproperties/) का उपयोग करके प्रस्तुति-व्यापी व्यू सेटिंग्स तक पहुँचें। व्यू खोलते समय टिप्पणियों को दिखाने के लिए प्राथमिकता संग्रहीत करने हेतु [IViewProperties.ShowComments](https://reference.aspose.com/slides/hi/net/aspose.slides/iviewproperties/showcomments/) को पढ़ें या बदलें।

यह सेटिंग केवल सहेजी गई व्यू प्राथमिकता को नियंत्रित करती है। यह टिप्पणियों को जोड़ती, हटाती, संपादित करती या हल नहीं करती। टिप्पणियों को छिपाने से उनकी सामग्री, लेखक, स्थान, उत्तर और स्थिति संरक्षित रहती है। टिप्पणियों में परिवर्तन करने वाले ऑपरेशनों के लिए देखें [Presentation Comments](/slides/hi/net/presentation-comments/)।

निम्न उदाहरण के लिए एक मौजूदा `comments.pptx` आवश्यक है जिसमें टिप्पणियाँ हों। यह वर्तमान दृश्यता सेटिंग को प्रिंट करता है, टिप्पणियों को छिपाने का अनुरोध करता है, और बिना किसी टिप्पणी को हटाए नया PPTX सहेजता है। यह प्रारंभिक संपादन व्यू को टिप्पणी दृश्यता के साथ कॉन्फ़िगर करने हेतु [IViewProperties.LastView](https://reference.aspose.com/slides/hi/net/aspose.slides/iviewproperties/lastview/) को [ViewType.SlideView](https://reference.aspose.com/slides/hi/net/aspose.slides/viewtype/) पर सेट करता है।

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("comments.pptx");
var showComments = presentation.ViewProperties.ShowComments;
Console.WriteLine($"Current comment visibility: {showComments}");

presentation.ViewProperties.ShowComments = NullableBool.False;
presentation.ViewProperties.LastView = ViewType.SlideView;
presentation.Save("comments-hidden.pptx", SaveFormat.Pptx);
```

यह सेटिंग यह निर्धारित नहीं करती कि टिप्पणियाँ PDF, HTML, इमेज, नोट्स या हैंडआउट निर्यात में शामिल होंगी या नहीं। संबंधित निर्यात‑विशिष्ट विकल्पों को अलग से कॉन्फ़िगर करें।

## **FAQ**

**ग्रिड को पुनः खोलने के बाद क्यों नहीं दिख रहा है?**

फ़ाइल ग्रिड स्पेसिंग संग्रहीत करती है, लेकिन एडिटर यह नियंत्रित करता है कि ग्रिड प्रदर्शित हो या नहीं। एडिटर की ग्रिड दृश्यता सेटिंग्स जाँचें।

**क्या ड्राइंग गाइड्स को साफ़ करने से ग्रिड स्पेसिंग बदलती है?**

नहीं। ड्राइंग गाइड्स और ग्रिड स्पेसिंग स्वतंत्र सेटिंग्स हैं। गाइड्स को साफ़ करने से संग्रहीत ग्रिड अंतराल अपरिवर्तित रहता है।

**क्या मैं प्रस्तुति के विभिन्न सेक्शन के लिए अलग‑अलग व्यू सेटिंग्स निर्धारित कर सकता हूँ?**

[View settings](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/viewproperties/) प्रस्तुति स्तर पर परिभाषित होते हैं ([Normal View](https://reference.aspose.com/slides/hi/net/aspose.slides/viewproperties/normalviewproperties/)/[Slide View](https://reference.aspose.com/slides/hi/net/aspose.slides/viewproperties/slideviewproperties/)), सेक्शन‑प्रति नहीं, इसलिए एक ही पैरामीटर सेट पूरे दस्तावेज़ पर लागू होता है जब वह खुलता है।

**क्या मैं विभिन्न उपयोगकर्ताओं के लिए अलग‑अलग व्यू स्टेट्स पूर्वनिर्धारित कर सकता हूँ?**

नहीं। सेटिंग्स फ़ाइल में संग्रहीत होती हैं और सभी उपयोगकर्ताओं के बीच साझा होती हैं। व्यूअर एप्लिकेशन उपयोगकर्ता प्राथमिकताओं को सम्मानित कर सकते हैं, लेकिन फ़ाइल स्वयं केवल एक सेट व्यू प्रॉपर्टीज़ रखती है।

**क्या मैं एक टेम्पलेट तैयार कर सकता हूँ जिसमें पूर्वनिर्धारित View Properties हों, ताकि नई प्रस्तुतियों का खुलना समान हो?**

हाँ। चूँकि [view properties](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/viewproperties/) प्रस्तुति स्तर पर संग्रहीत होते हैं, आप उन्हें टेम्पलेट में एम्बेड कर सकते हैं और उससे बनाए गए नए दस्तावेज़ उसी प्रारंभिक व्यू कॉन्फ़िगरेशन के साथ खुलेंगे।