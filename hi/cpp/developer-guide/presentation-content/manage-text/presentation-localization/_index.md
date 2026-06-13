---
title: C++ में प्रस्तुति स्थानीयकरण को स्वचालित करें
linktitle: प्रस्तुति स्थानीयकरण
type: docs
weight: 100
url: /hi/cpp/presentation-localization/
keywords:
- भाषा बदलें
- वर्तनी जांच
- भाषा आईडी
- PowerPoint
- OpenDocument
- प्रस्तुति
- C++
- Aspose.Slides
description: "C++ में Aspose.Slides के साथ PowerPoint और OpenDocument स्लाइड स्थानीयकरण को स्वचालित करें, व्यावहारिक कोड नमूने और तेज़ वैश्विक rollout के लिए टिप्स का उपयोग करके।"
---
## **Overview**

यह लेख Aspose.Slides का उपयोग करके प्रस्तुति में टेक्स्ट के लिए `LanguageId` सेट करने का तरीका समझाता है। यह दिखाता है कि कैसे एक प्रस्तुति खोली जाए, टेक्स्ट वाला शैप जोड़ा जाए, टेक्स्ट भाग को भाषा पहचानकर्ता सौंपा जाए, और परिणाम को PPTX फ़ाइल के रूप में सहेजा जाए।

## **Change Language for a Presentation and Shape Text**
- [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।
- इंडेक्स का उपयोग करके स्लाइड का रेफरेंस प्राप्त करें।
- स्लाइड में Rectangle प्रकार का AutoShape जोड़ें।
- TextFrame में कुछ टेक्स्ट जोड़ें।
- टेक्स्ट में Language Id सेट करें।
- प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।

उपर्युक्त चरणों की कार्यान्वयन नीचे एक उदाहरण में प्रदर्शित किया गया है।

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-TextBoxOnSlideProgram-TextBoxOnSlideProgram.cpp" >}}

## **FAQ**

**Does language ID trigger automatic text translation?**

No. [Language ID](https://reference.aspose.com/slides/hi/cpp/aspose.slides/baseportionformat/set_languageid/) Aspose.Slides में वर्तनी जाँच और व्याकरण प्रूफ़िंग के लिए भाषा संग्रहीत करता है, लेकिन यह टेक्स्ट सामग्री का अनुवाद या परिवर्तन नहीं करता। यह मेटाडेटा है जिसे PowerPoint प्रूफ़िंग के लिए समझता है।

**Does language ID affect hyphenation and line breaks during rendering?**

In Aspose.Slides, [Language ID](https://reference.aspose.com/slides/hi/cpp/aspose.slides/baseportionformat/set_languageid/) प्रूफ़िंग के लिए है। हाइफ़नेशन की गुणवत्ता और लाइन रैपिंग मुख्यतः [सही फ़ॉन्ट](/slides/hi/cpp/powerpoint-fonts/) की उपलब्धता और लेखन प्रणाली की लेआउट/लाइन‑ब्रेक सेटिंग्स पर निर्भर करती है। सही रेंडरिंग सुनिश्चित करने के लिए आवश्यक फ़ॉन्ट उपलब्ध कराएँ, [फ़ॉन्ट प्रतिस्थापन नियम](/slides/hi/cpp/font-substitution/) कॉन्फ़िगर करें, और/या [फ़ॉन्ट एम्बेड](/slides/hi/cpp/embedded-font/) को प्रस्तुति में एम्बेड करें।

**Can I set different languages within a single paragraph?**

Yes. [Language ID](https://reference.aspose.com/slides/hi/cpp/aspose.slides/baseportionformat/set_languageid/) टेक्स्ट भाग स्तर पर लागू होता है, इसलिए एक पैराग्राफ विभिन्न प्रमाणन सेटिंग्स के साथ कई भाषाओं को मिला सकता है।