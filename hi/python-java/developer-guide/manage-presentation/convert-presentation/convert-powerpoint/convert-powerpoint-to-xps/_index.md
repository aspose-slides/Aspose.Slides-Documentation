---
title: Python में PowerPoint प्रस्तुतियों को XPS में परिवर्तित करें
linktitle: PowerPoint से XPS
type: docs
weight: 70
url: /hi/python-java/convert-powerpoint-to-xps/
keywords:
- PowerPoint परिवर्तित करें
- प्रस्तुति परिवर्तित करें
- PPT परिवर्तित करें
- PPTX परिवर्तित करें
- PowerPoint से XPS
- प्रस्तुति से XPS
- PPT से XPS
- PPTX से XPS
- PPT को XPS के रूप में सहेजें
- PPTX को XPS के रूप में सहेजें
- PPT को XPS में निर्यात करें
- PPTX को XPS में निर्यात करें
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java का उपयोग करके Python में PowerPoint PPT और PPTX प्रस्तुतियों को XPS में परिवर्तित करें, डिफ़ॉल्ट या कस्टम निर्यात सेटिंग्स के साथ."
---
## **अवलोकन**

Aspose.Slides for Python via Java आपको PowerPoint प्रस्तुतियों को XPS में परिवर्तित करने की अनुमति देता है, PPT या PPTX फ़ाइल को XPS फ़ॉर्मेट में सहेजकर। यह लेख बताता है कि XPS कब उपयोगी हो सकता है और दिखाता है कि डिफ़ॉल्ट सेटिंग्स या कस्टम [XpsOptions](https://reference.aspose.com/slides/hi/python-java/aspose.slides/xpsoptions/) सेटिंग्स का उपयोग करके प्रस्तुति को कैसे निर्यात किया जाए।

## **XPS के बारे में**

XPS (XML Paper Specification) माइक्रोसॉफ्ट द्वारा विकसित एक XML-आधारित दस्तावेज़ फ़ॉर्मेट है। यह स्थिर पृष्ठों का वर्णन करता है, पाठ और ग्राफिक्स की लेआउट को संरक्षित रखता है ताकि संगत सॉफ़्टवेयर के साथ देखी और प्रिंट की जा सके।

## **Microsoft XPS फ़ॉर्मेट को कब उपयोग करें**

जब दस्तावेज़ कार्यप्रवाह को साझा करने या XPS-समर्थित उपकरणों के माध्यम से प्रिंट करने के लिए स्थिर-लेआउट फ़ाइलों की आवश्यकता हो तो XPS का उपयोग करें। प्राप्तकर्ताओं को XPS का समर्थन करने वाले सॉफ़्टवेयर की आवश्यकता होती है। यदि आपका कार्यप्रवाह PDF की मांग करता है, तो देखें [Convert PowerPoint to PDF](/slides/hi/python-java/convert-powerpoint-to-pdf/)।

{{% alert color="info" title="Note" %}}
PPT या PPTX प्रस्तुति को XPS में परिवर्तित करने का प्रयास करने के लिए, [free online converter](https://products.aspose.app/slides/hi/conversion) का उपयोग करें।
{{% /alert %}}

| इनपुट PowerPoint प्रस्तुति | आउटपुट XPS दस्तावेज़ |
| --- | --- |
| ![मूल PowerPoint प्रस्तुति](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png) | ![XPS में परिवर्तित प्रस्तुति](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png) |

## **Aspose.Slides के साथ XPS रूपांतरण**

[Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास के [save](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#save) मेथड को [SaveFormat.Xps](https://reference.aspose.com/slides/hi/python-java/aspose.slides/saveformat/#Xps) के साथ उपयोग करके एक प्रस्तुति को निर्यात करें। आप डिफ़ॉल्ट निर्यात सेटिंग्स का उपयोग कर सकते हैं या आउटपुट को अनुकूलित करने के लिए [XpsOptions](https://reference.aspose.com/slides/hi/python-java/aspose.slides/xpsoptions/) प्रदान कर सकते हैं।

नीचे प्रत्येक उदाहरण आवश्यक होने पर Java वर्चुअल मशीन शुरू करता है और उपयोग के बाद प्रस्तुति को रिलीज़ करता है। इनपुट फ़ाइलनाम को अपने PPT या PPTX फ़ाइल के पथ से बदलें।

### **डिफ़ॉल्ट सेटिंग्स का उपयोग करके प्रस्तुतियों को XPS में परिवर्तित करें**

निम्नलिखित Python कोड डिफ़ॉल्ट सेटिंग्स का उपयोग करके एक प्रस्तुति को XPS में परिवर्तित करता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    # प्रस्तुति को XPS दस्तावेज़ के रूप में सहेजें।
    presentation.save("output.xps", SaveFormat.Xps)
finally:
    presentation.dispose()
```

### **कस्टम सेटिंग्स का उपयोग करके प्रस्तुतियों को XPS में परिवर्तित करें**

निम्नलिखित उदाहरण परिणामस्वरूप XPS दस्तावेज़ में मेटाफाइल्स को PNG छवियों के रूप में सहेजने के लिए [XpsOptions.setSaveMetafilesAsPng](https://reference.aspose.com/slides/hi/python-java/aspose.slides/xpsoptions/#setSaveMetafilesAsPng) का उपयोग करता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, XpsOptions

presentation = Presentation("presentation.pptx")
try:
    xps_options = XpsOptions()
    xps_options.setSaveMetafilesAsPng(True)

    # कस्टम XPS सेटिंग्स के साथ प्रस्तुति को सहेजें।
    presentation.save("output_custom.xps", SaveFormat.Xps, xps_options)
finally:
    presentation.dispose()
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं XPS को फ़ाइल के बजाय स्ट्रीम में सहेज सकता हूँ?**

हाँ। [Presentation.save](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#save) मेथड में ऐसे ओवरलोड मौजूद हैं जो Java आउटपुट स्ट्रीम को स्वीकार करते हैं। Python via Java के साथ, JPype के माध्यम से एक संगत Java स्ट्रीम, जैसे कि Java बाइट-ऐरे आउटपुट स्ट्रीम, का उपयोग करके निर्यात किए गए डेटा को मेमोरी में रखें।

**क्या छिपी स्लाइड्स XPS आउटपुट में शामिल हैं?**

डिफ़ॉल्ट रूप से छिपी स्लाइड्स को बाहर रखा जाता है। उन्हें शामिल करने के लिए, सहेजने से पहले [XpsOptions.setShowHiddenSlides](https://reference.aspose.com/slides/hi/python-java/aspose.slides/xpsoptions/#setShowHiddenSlides) को `True` सेट करें।

**क्या एनिमेशन और स्लाइड ट्रांज़िशन XPS में संरक्षित रहते हैं?**

नहीं। XPS में स्थिर पृष्ठ होते हैं, इसलिए निर्यातित स्लाइड्स एनिमेशन या ट्रांज़िशन इफ़ेक्ट नहीं चलाते।