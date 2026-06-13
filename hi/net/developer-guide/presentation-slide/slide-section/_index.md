---
title: .NET में प्रस्तुतियों में स्लाइड सेक्शन प्रबंधित करें
linktitle: स्लाइड सेक्शन
type: docs
weight: 100
url: /hi/net/slide-section/
keywords:
- सेक्शन बनाएं
- सेक्शन जोड़ें
- सेक्शन संपादित करें
- सेक्शन बदलें
- सेक्शन नाम
- PowerPoint
- OpenDocument
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET के साथ PowerPoint और OpenDocument में स्लाइड सेक्शन को सरल बनाएं — विभाजित करें, पुनःनामित करें, और पुन: क्रमबद्ध करें ताकि PPTX और ODP वर्कफ़्लो को अनुकूलित किया जा सके।"
---
## **परिचय**

Aspose.Slides for .NET के साथ, आप एक PowerPoint प्रस्तुति को सेक्शन में व्यवस्थित कर सकते हैं। आप विशिष्ट स्लाइड्स वाले सेक्शन बना सकते हैं।

आप निम्नलिखित स्थितियों में सेक्शन बनाकर स्लाइड्स को तार्किक भागों में व्यवस्थित या विभाजित करना चाह सकते हैं:

- जब आप बड़ी प्रस्तुति पर अन्य लोगों या टीम के साथ काम कर रहे हों - और आपको कुछ स्लाइड्स को सहयोगी या टीम के सदस्यों को असाइन करना हो। 
- जब आपकी प्रस्तुति में बहुत सारी स्लाइड्स हों - और आप एक साथ उसकी सामग्री को प्रबंधित या संपादित करने में कठिनाई महसूस कर रहे हों।

आदर्श रूप में, आपको एक ऐसा सेक्शन बनाना चाहिए जिसमें समान स्लाइड्स हों - स्लाइड्स में कोई सामान्य विशेषता हो या वे किसी नियम के आधार पर समूहित हो सकते हों - और सेक्शन को ऐसा नाम दें जो इसके अंदर की स्लाइड्स का वर्णन करे।

## **प्रेजेंटेशन में सेक्शन बनाएं**

प्रेजेंटेशन में स्लाइड्स को रखने वाले सेक्शन को जोड़ने के लिए, Aspose.Slides for .NET AddSection मेथड प्रदान करता है जो आपको बनाने वाले सेक्शन का नाम और वह स्लाइड निर्दिष्ट करने की अनुमति देता है जहाँ सेक्शन शुरू होता है।

यह नमूना कोड आपको C# में प्रेजेंटेशन में एक सेक्शन बनाने का तरीका दिखाता है:

```c#
using (Presentation pres = new Presentation())
{
    ISlide defaultSlide = pres.Slides[0];
    ISlide newSlide1 = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);
    ISlide newSlide2 = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);
    ISlide newSlide3 = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);
    ISlide newSlide4 = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);

    ISection section1 = pres.Sections.AddSection("Section 1", newSlide1);
    ISection section2 = pres.Sections.AddSection("Section 2", newSlide3); // section1 को newSlide2 पर समाप्त किया जाएगा और उसके बाद section2 शुरू होगा   

    pres.Save("pres-sections.pptx", SaveFormat.Pptx);
    
    pres.Sections.ReorderSectionWithSlides(section2, 0);
    pres.Save("pres-sections-moved.pptx", SaveFormat.Pptx);
    
    pres.Sections.RemoveSectionWithSlides(section2);
    
    pres.Sections.AppendEmptySection("Last empty section");
    
    pres.Save("pres-section-with-empty.pptx",SaveFormat.Pptx);
}
```

## **सेक्शन के नाम बदलें**

PowerPoint प्रेजेंटेशन में एक सेक्शन बन जाने के बाद, आप उसका नाम बदलना चाह सकते हैं।

यह नमूना कोड आपको Aspose.Slides का उपयोग करके C# में प्रेजेंटेशन में एक सेक्शन का नाम बदलने का तरीका दिखाता है:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   ISection section = pres.Sections[0];
   section.Name = "My section";
}
```

## **FAQ**

**क्या PPT (PowerPoint 97–2003) फ़ॉर्मेट में सहेजते समय सेक्शन संरक्षित रहते हैं?**

नहीं। PPT फ़ॉर्मेट सेक्शन मेटाडेटा को समर्थन नहीं देता, इसलिए सेक्शन समूहण .ppt में सहेजते समय खो जाता है।

**क्या पूरी सेक्शन को "छुपाया" जा सकता है?**

नहीं। केवल व्यक्तिगत स्लाइड्स को छुपाया जा सकता है। एक सेक्शन एक इकाई के रूप में कोई "छुपा" स्थिति नहीं रखता।

**क्या मैं एक स्लाइड के आधार पर सेक्शन को जल्दी ढूंढ सकता हूँ और इसके विपरीत, सेक्शन की पहली स्लाइड को?**

हां। एक सेक्शन अपनी प्रारंभिक स्लाइड द्वारा अद्वितीय रूप से परिभाषित होता है; किसी स्लाइड को दिया जाने पर आप निर्धारित कर सकते हैं कि वह किस सेक्शन में है, और एक सेक्शन के लिए आप उसकी पहली स्लाइड तक पहुंच सकते हैं।