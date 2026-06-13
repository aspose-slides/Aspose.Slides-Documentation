---
title: Python में PowerPoint प्रस्तुतियों को SWF Flash में परिवर्तित करें
linktitle: PowerPoint को SWF Flash में
type: docs
weight: 80
url: /hi/python-net/convert-powerpoint-to-swf-flash/
keywords:
- PowerPoint परिवर्तित करें
- प्रेजेंटेशन परिवर्तित करें
- स्लाइड परिवर्तित करें
- PowerPoint से SWF
- प्रेजेंटेशन से SWF
- स्लाइड से SWF
- PPT से SWF
- PPTX से SWF
- PowerPoint
- प्रेजेंटेशन
- Python
- Aspose.Slides
description: "Aspose.Slides के साथ Python में PowerPoint (PPT/PPTX) को SWF Flash में परिवर्तित करें। चरण-दर-चरण कोड नमूने, तेज़ गुणवत्ता आउटपुट, कोई PowerPoint स्वचालन नहीं।"
---
## **सारांश**

यह लेख Aspose.Slides का उपयोग करके PowerPoint प्रस्तुतियों को SWF में परिवर्तित करने के तरीके को समझाता है। यह दिखाता है कि कैसे प्रस्तुति को [Presentation.save](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/save/) मेथड से SWF फ़ाइल के रूप में सहेजा जाए और निर्यात को [SwfOptions](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/swfoptions/) के साथ कैसे कॉन्फ़िगर किया जाए, जिसमें व्यूअर सेटिंग्स और नोट्स या टिप्पणी लेआउट शामिल हैं।

## **प्रस्तुतियों को फ़्लैश में बदलें**

क्लास [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) द्वारा प्रदर्शित [save](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/save/) मेथड का उपयोग पूरी प्रस्तुति को SWF दस्तावेज़ में बदलने के लिए किया जा सकता है। आप जनरेट किए गए SWF में टिप्पणी शामिल करने के लिए [SWFOptions](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/swfoptions/) क्लास और [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/notescommentslayoutingoptions/) क्लास का उपयोग कर सकते हैं। नीचे दिया गया उदाहरण दर्शाता है कि कैसे SWFOptions क्लास द्वारा प्रदान किए गए विकल्पों का उपयोग करके प्रस्तुति को SWF दस्तावेज़ में बदला जाए।

```py
import aspose.slides as slides

# एक Presentation ऑब्जेक्ट बनाता है जो प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है
presentation = slides.Presentation("pres.pptx")

swfOptions = slides.export.SwfOptions()
swfOptions.viewer_included = False
swfOptions.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL

# Saving presentation and notes pages
presentation.save("SaveAsSwf_out.swf", slides.export.SaveFormat.SWF, swfOptions)
swfOptions.viewer_included = True
presentation.save("SaveNotes_out.swf", slides.export.SaveFormat.SWF, swfOptions)
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं SWF में छिपी स्लाइड्स शामिल कर सकता हूँ?**

हाँ। [SwfOptions](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/swfoptions/) में [show_hidden_slides](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/swfoptions/show_hidden_slides/) विकल्प को सक्षम करें। डिफ़ॉल्ट रूप से, छिपी स्लाइड्स निर्यात नहीं की जाती हैं।

**मैं संपीड़न और अंतिम SWF आकार को कैसे नियंत्रित कर सकता हूँ?**

[compressed](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/swfoptions/compressed/) फ़्लैग (डिफ़ॉल्ट रूप से सक्षम) का उपयोग करें और फ़ाइल आकार और छवि गुणवत्ता के संतुलन के लिए [jpeg_quality](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/swfoptions/jpeg_quality/) को समायोजित करें।

**'viewer_included' किस लिए है, और मुझे इसे कब निष्क्रिय करना चाहिए?**

[viewer_included](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/swfoptions/viewer_included/) एक एम्बेडेड प्लेयर UI (नेविगेशन कंट्रोल, पैनल, सर्च) जोड़ता है। यदि आप अपना स्वयं का प्लेयर उपयोग करने की योजना बनाते हैं या UI के बिना केवल एक साधारण SWF फ्रेम चाहिए, तो इसे निष्क्रिय करें।

**यदि निर्यात मशीन पर स्रोत फ़ॉन्ट अनुपस्थित हो तो क्या होता है?**

Aspose.Slides [SwfOptions](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/swfoptions/) में [default_regular_font](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/swfoptions/default_regular_font/) द्वारा निर्दिष्ट फ़ॉन्ट को प्रतिस्थापित करेगा ताकि अनपेक्षित फ़ॉन्ट फॉलबैक से बचा जा सके।