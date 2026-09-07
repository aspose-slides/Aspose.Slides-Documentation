---
title: Python में PPTX को PPT में बदलें
linktitle: PPTX से PPT
type: docs
weight: 21
url: /hi/python-java/convert-pptx-to-ppt/
keywords:
- PowerPoint को बदलें
- प्रेजेंटेशन को बदलें
- स्लाइड को बदलें
- PPTX को बदलें
- PPTX से PPT
- PPTX को PPT के रूप में सहेजें
- PPTX को PPT में निर्यात करें
- PowerPoint
- प्रेजेंटेशन
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java के साथ Python में PPTX को पुरानी PPT फ़ॉर्मेट में बदलें। इसमें कोड उदाहरण और अनुकूलता तथा सुरक्षित फ़ाइलों के बारे में नोट्स शामिल हैं।"
---
## **समीक्षा**

Aspose.Slides for Python via Java आपको PPTX प्रस्तुति को PowerPoint 97–2003 द्वारा उपयोग किए जाने वाले पुराने PPT फ़ॉर्मेट में बदलने की अनुमति देता है, बिना Microsoft PowerPoint स्थापित किए। नीचे दिखाए अनुसार PPTX फ़ाइल को लोड करें और इसे PPT आउटपुट फ़ॉर्मेट के साथ सहेजें।

## **PPTX को PPT में बदलें**

स्रोत फ़ाइल को [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास से लोड करें, फिर आउटपुट पाथ और [SaveFormat.Ppt](https://reference.aspose.com/slides/hi/python-java/aspose.slides/saveformat/#Ppt) के साथ [Presentation.save](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#save) को कॉल करें।

निम्नलिखित उदाहरण आवश्यक होने पर Java वर्चुअल मशीन को शुरू करता है और डिफ़ॉल्ट विकल्पों का उपयोग करके `template.pptx` को `output.ppt` में बदलता है। पाथ को अपने फ़ाइल नामों से बदलें। `finally` ब्लॉक सहेजने में विफलता होने पर भी प्रस्तुति संसाधनों को मुक्त करता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# PPTX प्रस्तुति लोड करें।
presentation = Presentation("template.pptx")
try:
    # प्रेजेंटेशन को PPT फ़ॉर्मेट में सहेजें।
    presentation.save("output.ppt", SaveFormat.Ppt)
finally:
    presentation.dispose()
```

[SaveFormat.Ppt](https://reference.aspose.com/slides/hi/python-java/aspose.slides/saveformat/#Ppt) तर्क आउटपुट फ़ॉर्मेट चुनता है; केवल फ़ाइल एक्सटेंशन बदलने से प्रस्तुति परिवर्तित नहीं होती। मूल PPTX फ़ाइल को रखें ताकि यदि कोई नया फीचर PPT में समकक्ष न हो तो आप वापस जा सकें।

## **PPTX को अन्य फ़ॉर्मेट में बदलें**

Aspose.Slides अन्य आउटपुट फ़ॉर्मेट भी समर्थन करता है। फ़ॉर्मेट-विशिष्ट विकल्पों और उदाहरणों के लिए संबंधित लेख देखें:

- [PowerPoint को Python में PDF में बदलें](/slides/hi/python-java/convert-powerpoint-to-pdf/)
- [PowerPoint को Python में XPS में बदलें](/slides/hi/python-java/convert-powerpoint-to-xps/)
- [PowerPoint को Python में HTML में बदलें](/slides/hi/python-java/convert-powerpoint-to-html/)
- [Python में प्रस्तुतियों को ODP के रूप में सहेजें](/slides/hi/python-java/save-presentation/)
- [PowerPoint को Python में PNG में बदलें](/slides/hi/python-java/convert-powerpoint-to-png/)

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या सभी PPTX प्रभाव और सुविधाएँ PPT में रूपांतरण के बाद भी बनी रहती हैं?**

हमेशा नहीं। पुराना PPT फ़ॉर्मेट PPTX में उपलब्ध सभी सुविधाओं को समर्थन नहीं देता। कुछ प्रभाव, ऑब्जेक्ट या व्यवहार सरलित या भिन्न रूप से दिखाए जा सकते हैं। परिवर्तित प्रस्तुति को लक्षित दर्शक में देखें, विशेष रूप से जब इसमें नई PowerPoint सुविधाएँ हों।

**क्या मैं केवल चयनित स्लाइड्स को PPT में बदल सकता हूँ?**

PPT में सहेजने से पूरी प्रस्तुति लिखी जाती है। चयनित स्लाइड्स को बदलने के लिए, एक नई प्रस्तुति बनाएं, इसकी प्रारंभिक खाली स्लाइड को हटाएँ, आवश्यक स्लाइड्स को क्लोन करें, और इसे PPT के रूप में सहेजें। देखें [Python में स्लाइड्स क्लोन करें](/slides/hi/python-java/clone-slides/)।

**क्या मैं पासवर्ड-प्रोटेक्टेड PPTX फ़ाइल को बदल सकता हूँ?**

हां, यदि आप स्रोत प्रस्तुति लोड करते समय सही पासवर्ड प्रदान करते हैं। आप आउटपुट फ़ाइल के लिए भी सुरक्षा कॉन्फ़िगर कर सकते हैं। देखें [पासवर्ड-प्रोटेक्टेड प्रस्तुतियाँ](/slides/hi/python-java/password-protected-presentation/).