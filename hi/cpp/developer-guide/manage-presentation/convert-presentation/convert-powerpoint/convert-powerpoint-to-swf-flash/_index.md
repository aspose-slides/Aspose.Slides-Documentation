---
title: C++ में PowerPoint प्रस्तुतियों को SWF Flash में परिवर्तित करें
linktitle: PowerPoint से SWF
type: docs
weight: 80
url: /hi/cpp/convert-powerpoint-to-swf-flash/
keywords:
- PowerPoint परिवर्तित करें
- प्रेजेंटेशन को बदलें
- स्लाइड को बदलें
- PPT को बदलें
- PPTX को बदलें
- PowerPoint से SWF
- प्रेजेंटेशन से SWF
- स्लाइड से SWF
- PPT से SWF
- PPTX से SWF
- PowerPoint से Flash
- प्रेजेंटेशन से Flash
- स्लाइड से Flash
- PPT से Flash
- PPTX से Flash
- PPT को SWF के रूप में सहेजें
- PPTX को SWF के रूप में सहेजें
- PPT को SWF में निर्यात करें
- PPTX को SWF में निर्यात करें
- PowerPoint
- प्रेजेंटेशन
- C++
- Aspose.Slides
description: "Aspose.Slides के साथ C++ में PowerPoint (PPT/PPTX) को SWF Flash में बदलें। चरण‑बद्ध कोड उदाहरण, तेज़ गुणवत्ता आउटपुट, कोई PowerPoint ऑटोमेशन नहीं।"
---
## **परिचय**

यह लेख बताता है कि Aspose.Slides का उपयोग करके PowerPoint प्रस्तुतियों को SWF में कैसे परिवर्तित किया जाए। यह दिखाता है कि कैसे प्रस्तुति को SWF फ़ाइल के रूप में [Presentation::Save](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/save/) विधि से सहेजा जा सकता है और कैसे निर्यात को [SwfOptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/swfoptions/) के साथ कॉन्फ़िगर किया जाए, जिसमें व्यूअर सेटिंग्स और नोट्स या टिप्पणी लेआउट शामिल हैं।

## **प्रस्तुतियों को फ़्लैश में बदलें**

[Save] विधि जिसे [Presentation] वर्ग प्रदान करता है, पूरी प्रस्तुति को SWF दस्तावेज़ में बदलने के लिए उपयोग की जा सकती है। आप उत्पन्न SWF में टिप्पणियाँ शामिल कर सकते हैंโดย [SWFOptions] वर्ग और [NotesCommentsLayoutingOptions] वर्ग का उपयोग करके। निम्न उदाहरण दिखाता है कि कैसे SWFOptions वर्ग द्वारा प्रदान किए गए विकल्पों का उपयोग करके प्रस्तुति को SWF दस्तावेज़ में बदला जाए।

``` cpp
// दस्तावेज़ निर्देशिका का पथ।
    System::String dataDir = GetDataPath();

    // एक Presentation ऑब्जेक्ट बनाते हैं जो एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है
    auto presentation = System::MakeObject<Presentation>(dataDir + u"HelloWorld.pptx");

    auto swfOptions = System::MakeObject<SwfOptions>();
    swfOptions->set_ViewerIncluded(false);

    auto notesOptions = swfOptions->get_NotesCommentsLayouting();
    notesOptions->set_NotesPosition(NotesPositions::BottomFull);

    // प्रस्तुति और नोट्स पृष्ठ सहेज रहे हैं
    presentation->Save(dataDir + u"SaveAsSwf_out.swf", SaveFormat::Swf, swfOptions);
    swfOptions->set_ViewerIncluded(true);
    presentation->Save(dataDir + u"SaveNotes_out.swf", SaveFormat::Swf, swfOptions);
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं SWF में छिपी हुई स्लाइड्स शामिल कर सकता हूँ?**  
हाँ। [set_ShowHiddenSlides](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/swfoptions/set_showhiddenslides/) विधि को [SwfOptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/swfoptions/) में उपयोग करें। डिफ़ॉल्ट रूप से, छिपी हुई स्लाइड्स निर्यात नहीं की जाती हैं।

**मैं संपीड़न और अंतिम SWF आकार को कैसे नियंत्रित कर सकता हूँ?**  
फ़ाइल आकार और छवि गुणवत्ता के बीच संतुलन बनाने के लिए आप [set_Compressed](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/swfoptions/set_compressed/) विधि का उपयोग करें और [JPEG quality](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/swfoptions/set_jpegquality/) को समायोजित करें।

**'set_ViewerIncluded' किस लिए है, और मुझे इसे कब उपयोग करना चाहिए?**  
[set_ViewerIncluded](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/swfoptions/set_viewerincluded/) एक एम्बेडेड प्लेयर UI (नेविगेशन कंट्रोल, पैनल, सर्च) जोड़ता है। यदि आप अपना प्लेयर उपयोग करने की योजना बनाते हैं या बिना UI के शुद्ध SWF फ्रेम चाहिए तो इसे अक्षम करें।

**यदि निर्यात मशीन पर स्रोत फ़ॉन्ट अनुपलब्ध है तो क्या होता है?**  
Aspose.Slides उन फ़ॉन्ट को बदल देगा जो आप [set_DefaultRegularFont](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/saveoptions/set_defaultregularfont/) के माध्यम से [SwfOptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/swfoptions/) में निर्दिष्ट करते हैं ताकि अनजाने में फ़ॉन्ट बदलने से बचा जा सके।