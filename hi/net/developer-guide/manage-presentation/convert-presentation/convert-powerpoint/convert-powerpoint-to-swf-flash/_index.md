---
title: .NET में PowerPoint प्रस्तुतियों को SWF फ़्लैश में बदलें
linktitle: PowerPoint से SWF
type: docs
weight: 80
url: /hi/net/convert-powerpoint-to-swf-flash/
keywords:
- PowerPoint बदलें
- प्रस्तुति बदलें
- स्लाइड बदलें
- PPT बदलें
- PPTX बदलें
- PowerPoint से SWF
- प्रस्तुति से SWF
- स्लाइड से SWF
- PPT से SWF
- PPTX से SWF
- PowerPoint से फ़्लैश
- प्रस्तुति से फ़्लैश
- स्लाइड से फ़्लैश
- PPT से फ़्लैश
- PPTX से फ़्लैश
- PPT को SWF के रूप में सहेजें
- PPTX को SWF के रूप में सहेजें
- PPT को SWF में निर्यात करें
- PPTX को SWF में निर्यात करें
- PowerPoint
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: ".NET में Aspose.Slides के साथ PowerPoint (PPT/PPTX) को SWF फ़्लैश में बदलें। चरण-बद्ध C# कोड उदाहरण, तेज़ गुणवत्ता आउटपुट, कोई PowerPoint स्वचालन नहीं।"
---
## **अवलोकन**

यह लेख Aspose.Slides का उपयोग करके PowerPoint प्रस्तुतियों को SWF में परिवर्तित करने की प्रक्रिया समझाता है। यह बताता है कि प्रस्तुतीकरण को SWF फ़ाइल के रूप में कैसे सहेजा जाए[Presentation.Save](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/save/) मेथड का उपयोग करके और निर्यात को[SwfOptions](https://reference.aspose.com/slides/hi/net/aspose.slides.export/swfoptions/) के साथ कैसे कॉन्फ़िगर किया जाए, जिसमें व्यूअर सेटिंग्स तथा नोट्स या टिप्पणी लेआउट शामिल हैं।

## **प्रस्तुतियों को फ़्लैश में परिवर्तित करें**

जो[Save](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/methods/save/index) मेथड[Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) क्लास द्वारा प्रदान किया गया है, उसे संपूर्ण प्रस्तुति को SWF दस्तावेज़ में बदलने के लिए उपयोग किया जा सकता है। आप उत्पन्न SWF में टिप्पणियाँ शामिल करने के लिए[SWFOptions](https://reference.aspose.com/slides/hi/net/aspose.slides.export/swfoptions) क्लास और[INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/hi/net/aspose.slides.export/inotescommentslayoutingoptions) इंटरफ़ेस का भी उपयोग कर सकते हैं। नीचे दिया गया उदाहरण दिखाता है कि कैसे SWFOptions क्लास द्वारा प्रदान किए गए विकल्पों का उपयोग करके प्रस्तुति को SWF दस्तावेज़ में बदला जाए।

```c#
// एक Presentation ऑब्जेक्ट बनाएं जो प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है
using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    SwfOptions swfOptions = new SwfOptions();
    swfOptions.ViewerIncluded = false;


    INotesCommentsLayoutingOptions notesOptions = swfOptions.NotesCommentsLayouting;
    notesOptions.NotesPosition = NotesPositions.BottomFull;

    // प्रस्तुति और नोट्स पृष्ठों को सहेजना
    presentation.Save("SaveAsSwf_out.swf", SaveFormat.Swf, swfOptions);
    swfOptions.ViewerIncluded = true;
    presentation.Save("SaveNotes_out.swf", SaveFormat.Swf, swfOptions);
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं SWF में छिपी स्लाइड्स शामिल कर सकता हूँ?**

हाँ।[SwfOptions](https://reference.aspose.com/slides/hi/net/aspose.slides.export/swfoptions/)में[ShowHiddenSlides](https://reference.aspose.com/slides/hi/net/aspose.slides.export/swfoptions/showhiddenslides/) विकल्प को सक्षम करें। डिफ़ॉल्ट रूप से, छिपी स्लाइड्स निर्यात नहीं की जातीं।

**मैं संपीडन और अंतिम SWF आकार को कैसे नियंत्रित कर सकता हूँ?**

डिफ़ॉल्ट रूप से सक्षम[Compressed](https://reference.aspose.com/slides/hi/net/aspose.slides.export/swfoptions/compressed/) फ़्लैग का उपयोग करें और फ़ाइल आकार व छवि गुणवत्ता के बीच संतुलन बनाने के लिए[JpegQuality](https://reference.aspose.com/slides/hi/net/aspose.slides.export/swfoptions/jpegquality/) को समायोजित करें।

**'ViewerIncluded' का उद्देश्य क्या है, और इसे कब अक्षम करना चाहिए?**

[ViewerIncluded](https://reference.aspose.com/slides/hi/net/aspose.slides.export/swfoptions/viewerincluded/) एक एम्बेडेड प्लेयर UI (नेविगेशन नियंत्रण, पैनल, खोज) जोड़ता है। यदि आप अपना प्लेयर उपयोग करने की योजना बनाते हैं या बिना UI के शुद्ध SWF फ्रेम चाहिए, तो इसे अक्षम करें।

**यदि निर्यात मशीन पर स्रोत फ़ॉन्ट अनुपलब्ध हो तो क्या होता है?**

Aspose.Slides निर्यात के दौरान निर्दिष्ट फ़ॉन्ट को[DefaultRegularFont](https://reference.aspose.com/slides/hi/net/aspose.slides.export/saveoptions/defaultregularfont/) के माध्यम से[SwfOptions](https://reference.aspose.com/slides/hi/net/aspose.slides.export/saveoptions/) में प्रतिस्थापित करेगा, ताकि अनचाहा fallback न हो।