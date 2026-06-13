---
title: .NET में प्रस्तुतिकरण स्लाइड्स को SVG छवियों के रूप में रेंडर करें
linktitle: स्लाइड से SVG
type: docs
weight: 50
url: /hi/net/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint से SVG
- प्रस्तुति से SVG
- स्लाइड से SVG
- PPT से SVG
- PPTX से SVG
- PPT को SVG के रूप में सहेजें
- PPTX को SVG के रूप में सहेजें
- PPT को SVG में निर्यात करें
- PPTX को SVG में निर्यात करें
- स्लाइड रेंडर करें
- स्लाइड परिवर्तित करें
- स्लाइड निर्यात करें
- वेक्टर छवि
- PowerPoint
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET का उपयोग करके PowerPoint स्लाइड्स को SVG छवियों के रूप में रेंडर करना सीखें। सरल C# कोड उदाहरणों के साथ उच्च-गुणवत्ता वाले दृश्य।"
---
## **अवलोकन**

यह लेख Aspose.Slides का उपयोग करके प्रस्तुति स्लाइड्स को SVG छवियों के रूप में प्रस्तुत करने की प्रक्रिया समझाता है। यह SVG फ़ॉर्मेट और इसके फायदों, जैसे कि स्केलेबिलिटी, एक्सेसेबिलिटी, और वेब विकास के लिए उपयुक्तता, का वर्णन करता है।

आप सीखेंगे कि प्रस्तुति फ़ाइल को कैसे लोड किया जाए, उसकी स्लाइड्स में कैसे इटरेट किया जाए, और प्रत्येक स्लाइड को अलग-अलग SVG फ़ाइल के रूप में कैसे सहेजा जाए। लेख PowerPoint और OpenDocument प्रस्तुति फ़ॉर्मेट्स, जैसे PPT, PPTX, ODP, और PPS को कवर करता है, और यह दिखाता है कि `Presentation` क्लास और `WriteAsSvg` मेथड का उपयोग करके परिवर्तन को प्रोग्रामेटिक रूप से कैसे किया जाए।

## **SVG फ़ॉर्मेट**
SVG—Scalable Vector Graphics का संक्षिप्त रूप है—एक मानक ग्राफिक प्रकार या फ़ॉर्मेट है जिसका उपयोग द्वि-आयामी छवियों को रेंडर करने के लिए किया जाता है। SVG छवियों को XML में वेक्टर के रूप में संग्रहीत करता है जिनमें उनके व्यवहार या रूप को परिभाषित करने वाले विवरण होते हैं। 

SVG कुछ ही छवि फ़ॉर्मेट्स में से एक है जो इन मानकों को बहुत उच्च स्तर पर पूरा करता है: स्केलेबिलिटी, इंटरैक्टिविटी, प्रदर्शन, एक्सेसेबिलिटी, प्रोग्रामबिलिटी, आदि। इन कारणों से, इसे वेब विकास में सामान्यतः उपयोग किया जाता है। 

आप SVG फ़ाइलें तब उपयोग करना चाह सकते हैं जब आपको

- **अपने प्रस्तुतीकरण को *बहुत बड़े फ़ॉर्मेट* में प्रिंट करें।** SVG छवियां किसी भी रिज़ॉल्यूशन या स्तर तक स्केल हो सकती हैं। आप गुणवत्ता खोए बिना आवश्यकतानुसार कई बार SVG छवियों का आकार बदल सकते हैं।  
- **अपनी स्लाइड्स के चार्ट और ग्राफ़ को *विभिन्न माध्यमों या प्लेटफ़ॉर्म* में उपयोग करें**। अधिकांश रीडर SVG फ़ाइलों को समझ सकते हैं।  
- **छवियों के *सबसे छोटे संभव आकार* का उपयोग करें**। SVG फ़ाइलें सामान्यतः अन्य फ़ॉर्मेट्स की उच्च-रिज़ॉल्यूशन समकक्षों से छोटी होती हैं, विशेषकर बिटमैप (JPEG या PNG) आधारित फ़ॉर्मेट्स।

## **एक स्लाइड को SVG छवि के रूप में रेंडर करें**

Aspose.Slides for .NET आपको आपकी प्रस्तुति की स्लाइड्स को SVG छवियों के रूप में निर्यात करने की अनुमति देता है। SVG छवियों को उत्पन्न करने के लिए इन चरणों का पालन करें:

_Steps: PowerPoint to SVG Conversions in C#_

निम्नलिखित उदाहरण कोड .NET का उपयोग करके इन रूपांतरणों को समझाता है।

- <a name="csharp-powerpoint-to-svg" id="csharp-powerpoint-to-svg"><strong>चरण: PowerPoint को C# में SVG में बदलें</strong></a>
- <a name="csharp-ppt-to-svg" id="csharp-ppt-to-svg"><strong>चरण: PPT को C# में SVG में बदलें</strong></a>
- <a name="csharp-pptx-to-svg" id="csharp-pptx-to-svg"><strong>चरण: PPTX को C# में SVG में बदलें</strong></a>
- <a name="csharp-odp-to-svg" id="csharp-odp-to-svg"><strong>चरण: ODP को C# में SVG में बदलें</strong></a>

_Code Steps:_

1. एक instance बनाएं [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) क्लास की।  
   * _.ppt_ एक्सटेंशन का उपयोग करके **PPT** फ़ाइल को _Presentation_ क्लास में लोड करें।  
   * _.pptx_ एक्सटेंशन का उपयोग करके **PPTX** फ़ाइल को _Presentation_ क्लास में लोड करें।  
   * _.odp_ एक्सटेंशन का उपयोग करके **ODP** फ़ाइल को _Presentation_ क्लास में लोड करें।  
   * _.pps_ एक्सटेंशन का उपयोग करके **PPS** फ़ाइल को _Presentation_ क्लास में लोड करें।  
2. प्रस्तुति की सभी स्लाइड्स के माध्यम से इटरेट करें।  
3. फ़ाइलस्ट्रीम के माध्यम से प्रत्येक स्लाइड को उसकी स्वयं की SVG फ़ाइल में लिखें।

{{% alert color="primary" %}} 
आप हमारे [फ़्री वेब एप्लिकेशन](https://products.aspose.app/slides/hi/conversion/ppt-to-svg) को आज़मा सकते हैं, जिसमें हमने Aspose.Slides for .NET से PPT को SVG में कन्वर्ज़न फ़ंक्शन लागू किया है।
{{% /alert %}} 

यह C# में उदाहरण कोड दर्शाता है कि Aspose.Slides का उपयोग करके PowerPoint को SVG में कैसे बदलें: 

``` csharp
// Presentation ऑब्जेक्ट PPT, PPTX, ODP आदि जैसे PowerPoint फ़ॉर्मेट लोड कर सकता है।
using (Presentation pres = new Presentation("pres.pptx"))
{
    for (var index = 0; index < pres.Slides.Count; index++)
    {
        ISlide slide = pres.Slides[index];

        using (FileStream fileStream = new FileStream($"slide-{index}.svg", FileMode.Create, FileAccess.Write))
        {
            slide.WriteAsSvg(fileStream);   
        }
    }
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**परिणामी SVG विभिन्न ब्राउज़रों में अलग क्यों दिख सकता है?**

ब्राउज़र इंजन विभिन्न SVG सुविधाओं को अलग ढंग से लागू करते हैं। [SVGOptions](https://reference.aspose.com/slides/hi/net/aspose.slides.export/svgoptions/) पैरामीटर असंगतियों को कम करने में मदद करते हैं।

**क्या केवल स्लाइड्स ही नहीं, बल्कि व्यक्तिगत शेप्स को भी SVG में निर्यात करना संभव है?**

हाँ। कोई भी [shape को अलग SVG के रूप में सहेजा जा सकता है](https://reference.aspose.com/slides/hi/net/aspose.slides/shape/writeassvg/), जो आइकन, पिक्टोग्राम और ग्राफ़िक्स को पुनः उपयोग करने के लिए सुविधाजनक है।

**क्या कई स्लाइड्स को एकल SVG (स्ट्रिप/डॉक्यूमेंट) में मिलाया जा सकता है?**

मानक परिदृश्य एक स्लाइड → एक SVG है। कई स्लाइड्स को एकल SVG कैनवास में मिलाना एक पोस्ट-प्रोसेसिंग चरण है जो एप्लिकेशन स्तर पर किया जाता है।

## **संबंधित लिंक**

यह लेख इन विषयों को भी कवर करता है। कोड ऊपर जैसा ही हैं.

_फ़ॉर्मेट_: **PowerPoint**
- [C# PowerPoint को SVG कोड](#csharp-powerpoint-to-svg)
- [C# PowerPoint को SVG API](#csharp-powerpoint-to-svg)
- [C# PowerPoint को SVG प्रोग्रामेटिकली](#csharp-powerpoint-to-svg)
- [C# PowerPoint को SVG लाइब्रेरी](#csharp-powerpoint-to-svg)
- [C# PowerPoint को SVG के रूप में सहेजें](#csharp-powerpoint-to-svg)
- [C# PowerPoint से SVG जेनरेट करें](#csharp-powerpoint-to-svg)
- [C# PowerPoint से SVG बनाएं](#csharp-powerpoint-to-svg)
- [C# PowerPoint को SVG कनवर्टर](#csharp-powerpoint-to-svg)

_फ़ॉर्मेट_: **PPT**
- [C# PPT को SVG कोड](#csharp-ppt-to-svg)
- [C# PPT को SVG API](#csharp-ppt-to-svg)
- [C# PPT को SVG प्रोग्रामेटिकली](#csharp-ppt-to-svg)
- [C# PPT को SVG लाइब्रेरी](#csharp-ppt-to-svg)
- [C# PPT को SVG के रूप में सहेजें](#csharp-ppt-to-svg)
- [C# PPT से SVG जेनरेट करें](#csharp-ppt-to-svg)
- [C# PPT से SVG बनाएं](#csharp-ppt-to-svg)
- [C# PPT को SVG कनवर्टर](#csharp-ppt-to-svg)

_फ़ॉर्मेट_: **PPTX**
- [C# PPTX को SVG कोड](#csharp-pptx-to-svg)
- [C# PPTX को SVG API](#csharp-pptx-to-svg)
- [C# PPTX को SVG प्रोग्रामेटिकली](#csharp-pptx-to-svg)
- [C# PPTX को SVG लाइब्रेरी](#csharp-pptx-to-svg)
- [C# PPTX को SVG के रूप में सहेजें](#csharp-pptx-to-svg)
- [C# PPTX से SVG जेनरेट करें](#csharp-pptx-to-svg)
- [C# PPTX से SVG बनाएं](#csharp-pptx-to-svg)
- [C# PPTX को SVG कनवर्टर](#csharp-pptx-to-svg)

_फ़ॉर्मेट_: **ODP**
- [C# ODP को SVG कोड](#csharp-odp-to-svg)
- [C# ODP को SVG API](#csharp-odp-to-svg)
- [C# ODP को SVG प्रोग्रामेटिकली](#csharp-odp-to-svg)
- [C# ODP को SVG लाइब्रेरी](#csharp-odp-to-svg)
- [C# ODP को SVG के रूप में सहेजें](#csharp-odp-to-svg)
- [C# ODP से SVG जेनरेट करें](#csharp-odp-to-svg)
- [C# ODP से SVG बनाएं](#csharp-odp-to-svg)
- [C# ODP को SVG कनवर्टर](#csharp-odp-to-svg)