---
title: Python के साथ प्रस्तुति स्थानीयकरण को स्वचालित करें
linktitle: प्रस्तुति स्थानीयकरण
type: docs
weight: 100
url: /hi/python-net/presentation-localization/
keywords:
- भाषा बदलें
- वर्तनी जांच
- भाषा पहचानकर्ता
- PowerPoint
- प्रस्तुति
- Python
- Aspose.Slides
description: "Python के साथ Aspose.Slides का उपयोग करके PowerPoint और OpenDocument स्लाइड स्थानीयकरण को स्वचालित करें, व्यावहारिक कोड उदाहरण और तेज़ वैश्विक रोलआउट के लिए टिप्स के साथ।"
---
## **अवलोकन**

यह लेख Aspose.Slides का उपयोग करके प्रस्तुति में पाठ के लिए `language_id` सेट करने के तरीकों को समझाता है। यह दिखाता है कि प्रस्तुति कैसे खोलें, पाठ के साथ एक आकार जोड़ें, पाठ भाग को भाषा पहचानकर्ता असाइन करें, और परिणाम को PPTX फ़ाइल के रूप में सहेजें।

## **प्रस्तुति और आकार के पाठ के लिए भाषा बदलें**
- Presentation क्लास का एक उदाहरण बनाएं। [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/)
- इंडेक्स का उपयोग करके स्लाइड का संदर्भ प्राप्त करें।
- स्लाइड में Rectangle प्रकार का AutoShape जोड़ें।
- TextFrame में कुछ पाठ जोड़ें।
- पाठ में Language Id सेट करें।
- प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 50)
    shape.add_text_frame("Text to apply spellcheck language")
    shape.text_frame.paragraphs[0].portions[0].portion_format.language_id = "en-EN"

    pres.save("test1.pptx", slides.export.SaveFormat.PPTX)
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या language ID स्वतः पाठ अनुवाद ट्रिगर करता है?**

नहीं। Aspose.Slides में [language_id](https://reference.aspose.com/slides/hi/python-net/aspose.slides/portionformat/language_id/) वर्तनी जांच और व्याकरण प्रूफ़िंग के लिए भाषा संग्रहीत करता है, लेकिन यह पाठ सामग्री का अनुवाद या परिवर्तन नहीं करता। यह मेटाडेटा है जिसे PowerPoint प्रूफ़िंग के लिए समझता है।

**क्या language ID रेंडरिंग के दौरान हाइफ़नेशन और लाइन ब्रेक को प्रभावित करती है?**

Aspose.Slides में [language_id](https://reference.aspose.com/slides/hi/python-net/aspose.slides/portionformat/language_id/) प्रूफ़िंग के लिए है। हाइफ़नेशन की गुणवत्ता और लाइन रैपिंग मुख्यतः [proper fonts](/slides/hi/python-net/powerpoint-fonts/) की उपलब्धता तथा लेखन प्रणाली के लेआउट/लाइन‑ब्रेक सेटिंग्स पर निर्भर करती है। सही रेंडरिंग सुनिश्चित करने के लिए आवश्यक फ़ॉन्ट उपलब्ध कराएँ, [font substitution rules](/slides/hi/python-net/font-substitution/) कॉन्फ़िगर करें, और/या प्रस्तुति में [embed fonts](/slides/hi/python-net/embedded-font/) शामिल करें।

**क्या मैं एक ही पैराग्राफ में विभिन्न भाषाएँ सेट कर सकता हूँ?**

हाँ। [language_id](https://reference.aspose.com/slides/hi/python-net/aspose.slides/portionformat/language_id/) पाठ भाग स्तर पर लागू होता है, इसलिए एक पैराग्राफ में कई भाषाओं को अलग‑अलग प्रूफ़िंग सेटिंग्स के साथ मिश्रित किया जा सकता है।