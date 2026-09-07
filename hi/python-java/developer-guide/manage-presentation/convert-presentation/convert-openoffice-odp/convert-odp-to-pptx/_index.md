---
title: Python में ODP को PPTX में परिवर्तित करें
linktitle: ODP से PPTX
type: docs
weight: 10
url: /hi/python-java/convert-odp-to-pptx/
keywords:
- OpenDocument परिवर्तित करें
- प्रस्तुति परिवर्तित करें
- स्लाइड परिवर्तित करें
- ODP परिवर्तित करें
- OpenDocument से PPTX
- ODP से PPTX
- ODP को PPTX के रूप में सहेजें
- ODP को PPTX में निर्यात करें
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java के साथ ODP प्रस्तुतियों को PPTX में परिवर्तित करें। PowerPoint या LibreOffice स्थापित किए बिना एक संपूर्ण Python उदाहरण का उपयोग करें।"
---
## **सारांश**

यह लेख बताता है कि कैसे OpenDocument (ODP) प्रस्तुति को PowerPoint (PPTX) फ़ॉर्मेट में Aspose.Slides for Python via Java का उपयोग करके परिवर्तित किया जा सकता है।

## **ODP को PPTX में परिवर्तित करें**

The [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास सीधे ODP फ़ाइल को लोड कर सकता है। लोड की गई प्रस्तुति को PPTX फ़ॉर्मेट में [SaveFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/saveformat/) का उपयोग करके सहेजें।

[स्थापना निर्देश](/slides/hi/python-java/installation/) का पालन करें उदाहरण चलाने से पहले। कार्य निर्देशिका में `AccessOpenDoc.odp` नाम की ODP प्रस्तुति रखें। निम्नलिखित कोड आवश्यक होने पर JVM शुरू करता है, ODP फ़ाइल खोलता है, और इसे `AccessOpenDoc_out.pptx` के रूप में सहेजता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("AccessOpenDoc.odp")
try:
    # ODP प्रस्तुति को PPTX फ़ॉर्मेट में सहेजें।
    presentation.save("AccessOpenDoc_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **लाइव उदाहरण**

Aspose.Slides द्वारा संचालित ODP से PPTX परिवर्तन को देखने के लिए [Aspose.Slides Conversion](https://products.aspose.app/slides/hi/conversion/) वेब एप्लिकेशन आज़माएँ।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या ODP को PPTX में परिवर्तित करने के लिए मुझे Microsoft PowerPoint या LibreOffice स्थापित करना आवश्यक है?**

नहीं। Aspose.Slides for Python via Java किसी भी एप्लिकेशन के बिना प्रस्तुति फ़ाइलों को पढ़ और लिख सकता है। आपको केवल Python पैकेज और उपयुक्त Java रनटाइम की आवश्यकता है।

**क्या रूपांतरण के दौरान मास्टर स्लाइड, लेआउट और थीम संरक्षित रहते हैं?**

Aspose.Slides स्रोत प्रस्तुति की संरचना और फ़ॉर्मेटिंग को PPTX में मैप करता है। हालांकि, ODP और PPTX विभिन्न सुविधाओं का समर्थन करते हैं, इसलिए कुछ तत्व रूपांतरण के बाद अलग दिख सकते हैं। आवश्यक फॉन्ट उपलब्ध कराएँ और जटिल फ़ॉर्मेटिंग वाली प्रस्तुतियों की समीक्षा करें। सामंजस्यशीलता विचारों के लिए देखें [OpenDocument रूपांतरण](/slides/hi/python-java/convert-openoffice-odp/)।

**क्या मैं पासवर्ड-संरक्षित ODP फ़ाइलों को परिवर्तित कर सकता हूँ?**

हां, जब आप फ़ाइल को खोलने के लिए आवश्यक पासवर्ड प्रदान करते हैं। विभिन्न फ़ॉर्मेट में सहेजने से पहले संरक्षित फ़ाइलों को लोड करने के विवरण के लिए देखें [पासवर्ड-संरक्षित प्रस्तुतियाँ](/slides/hi/python-java/password-protected-presentation/)।

**क्या Aspose.Slides क्लाउड या REST-आधारित रूपांतरण सेवाओं के लिए उपयुक्त है?**

हां। आप अपने बैकएंड में आवश्यक Java रनटाइम के साथ Aspose.Slides for Python via Java का उपयोग कर सकते हैं। REST API के लिए देखें [Aspose.Slides Cloud](https://products.aspose.cloud/slides/hi/family/).