---
title: PowerPoint प्रस्तुतियों को नोट्स के साथ TIFF में Python के द्वारा बदलें
linktitle: PowerPoint को नोट्स के साथ TIFF में बदलें
type: docs
weight: 100
url: /hi/python-net/convert-powerpoint-to-tiff-with-notes/
keywords:
- PowerPoint बदलें
- प्रस्तुति बदलें
- स्लाइड बदलें
- PPT बदलें
- PPTX बदलें
- PowerPoint से TIFF
- प्रस्तुति से TIFF
- स्लाइड से TIFF
- PPT से TIFF
- PPTX से TIFF
- नोट्स के साथ PowerPoint
- नोट्स के साथ प्रस्तुति
- नोट्स के साथ स्लाइड
- नोट्स के साथ PPT
- नोट्स के साथ PPTX
- नोट्स के साथ TIFF
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET का उपयोग करके PowerPoint प्रस्तुतियों को नोट्स के साथ TIFF में बदलें। स्पीकर नोट्स के साथ स्लाइड्स को कुशलता से निर्यात करना सीखें।"
---
## **परिचय**

Aspose.Slides for Python via .NET, PowerPoint और OpenDocument प्रस्तुतियों (PPT, PPTX, और ODP) को नोट्स के साथ TIFF फ़ॉर्मेट में बदलने के लिए एक सरल समाधान प्रदान करता है। यह फ़ॉर्मेट उच्च‑गुणवत्ता वाली छवि संग्रहीत, प्रिंटिंग और दस्तावेज़ संग्रहण के लिए व्यापक रूप से उपयोग होता है। Aspose.Slides के साथ, आप न केवल पूरे प्रेजेंटेशन को स्पीकर नोट्स के साथ निर्यात कर सकते हैं, बल्कि Notes Slide दृश्य में स्लाइड थंबनेल भी जनरेट कर सकते हैं। परिवर्तन प्रक्रिया सरल और कुशल है, जो पूरे प्रेजेंटेशन को TIFF छवियों की श्रृंखला में परिवर्तित करने के लिए `save` मेथड का उपयोग करती है, जबकि नोट्स और लेआउट को बरकरार रखती है। यह `save` मेथड [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास का है।

## **नोट्स के साथ प्रेजेंटेशन को TIFF में बदलें**

Aspose.Slides for Python via .NET का उपयोग करके नोट्स के साथ PowerPoint या OpenDocument प्रेजेंटेशन को TIFF में सेव करने के लिए निम्नलिखित चरणों का पालन करें:

1. [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएं: PowerPoint या OpenDocument फ़ाइल लोड करें।
1. आउटपुट लेआउट विकल्प कॉन्फ़िगर करें: नोट्स और कमेंट्स को कैसे प्रदर्शित किया जाना चाहिए, यह निर्दिष्ट करने के लिए [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/notescommentslayoutingoptions/) क्लास का उपयोग करें।
1. प्रेजेंटेशन को TIFF में सेव करें: कॉन्फ़िगर किए गए विकल्पों को [save](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/save/#str-asposeslidesexportsaveformat-asposeslidesexportisaveoptions) मेथड को पास करें।

मान लीजिए हमारे पास "speaker_notes.pptx" फ़ाइल है जिसमें निम्नलिखित स्लाइड है:

![स्पीकर नोट्स वाली प्रस्तुति स्लाइड](slide_with_notes.png)

नीचे दिया गया कोड स्निपेट दिखाता है कि कैसे [slides_layout_options](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/tiffoptions/slides_layout_options/) प्रॉपर्टी का उपयोग करके नोट्स स्लाइड व्यू में प्रेजेंटेशन को TIFF छवि में परिवर्तित किया जा सकता है।

```py
# प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का उदाहरण बनाएं।
with slides.Presentation("speaker_notes.pptx") as presentation:
    
    notes_options = slides.export.NotesCommentsLayoutingOptions()
    notes_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL  # स्लाइड के नीचे नोट्स प्रदर्शित करें।
    
    # नोट्स लेआउट के साथ TIFF विकल्प कॉन्फ़िगर करें।
    tiff_options = slides.export.TiffOptions()
    tiff_options.dpi_x = 300
    tiff_options.dpi_y = 300
    tiff_options.slides_layout_options = notes_options
    
    # प्रस्तुति को स्पीकर नोट्स के साथ TIFF में सहेजें।
    presentation.save("TIFF_with_notes.tiff", slides.export.SaveFormat.TIFF, tiff_options)
```

परिणाम:

![नोट्स के साथ TIFF छवि](TIFF_with_notes.png)

{{% alert title="Tip" color="primary" %}}

Aspose [Free PowerPoint to Poster Converter](https://products.aspose.app/slides/hi/conversion/convert-ppt-to-poster-online) देखें।

{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं उत्पन्न TIFF में नोट्स क्षेत्र की स्थिति को नियंत्रित कर सकता हूँ?**

हाँ। आप [नोट्स लेआउट सेटिंग्स](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/tiffoptions/slides_layout_options/) का उपयोग करके `NONE`, `BOTTOM_TRUNCATED`, या `BOTTOM_FULL` जैसे विकल्पों में से चुन सकते हैं, जो क्रमशः नोट्स को छुपाते हैं, उन्हें एक ही पृष्ठ में फिट करते हैं, या अतिरिक्त पृष्ठों पर विस्तार की अनुमति देते हैं।

**नोट्स के साथ TIFF फ़ाइल का आकार गुणवत्ता में दिखाई देने वाली कमी के बिना कैसे घटाया जाए?**

एक [प्रभावी संपीड़न](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/tiffoptions/compression_type/) चुनें (जैसे `LZW` या `RLE`), उपयुक्त DPI निर्धारित करें, और यदि स्वीकार्य हो तो एक निम्नतर [पिक्सेल फ़ॉर्मेट](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/tiffoptions/pixel_format/) (जैसे मोनोक्रोम के लिए 8 bpp या 1 bpp) उपयोग करें। थोड़ा-सा [छवि आकार](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/tiffoptions/image_size/) घटाना भी बिना स्पष्ट पठनीयता हानि के मदद कर सकता है।

**क्या नोट्स में फ़ॉन्ट का प्रभाव परिणाम को बदलता है यदि मूल फ़ॉन्ट सिस्टम में उपलब्ध नहीं हैं?**

हाँ। अनुपलब्ध फ़ॉन्ट्स [स्थापना](/slides/hi/python-net/font-selection-sequence/) को ट्रिगर करते हैं, जिससे टेक्स्ट मेट्रिक्स और रूप‑रंग बदल सकता है। इसे रोकने के लिए, आवश्यक फ़ॉन्ट्स [सप्लाई](/slides/hi/python-net/custom-font/) करें या डिफ़ॉल्ट [फ़ॉलबैक फ़ॉन्ट](/slides/hi/python-net/fallback-font/) सेट करें ताकि इच्छित टाइपफ़ेस उपयोग हो सके।