---
title: Python के माध्यम से Java में PowerPoint प्रस्तुतियों को XML में बदलें
linktitle: PowerPoint से XML
type: docs
weight: 145
url: /hi/python-java/convert-powerpoint-to-xml/
keywords:
- PowerPoint को XML में बदलें
- प्रस्तुति को XML में बदलें
- PPT को XML में
- PPTX को XML में
- ODP को XML में
- PowerPoint XML प्रस्तुतीकरण
- SaveFormat.Xml
- प्रस्तुति को XML के रूप में सहेजें
- प्रस्तुति को XML में निर्यात करें
- XML स्ट्रीम
- Python
- Java
- Aspose.Slides
description: "Python के माध्यम से Java में Aspose.Slides for Python via Java का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों को PowerPoint XML फ़ाइलों या स्ट्रीम में परिवर्तित करें।"
---
## **परिचय**

Aspose.Slides for Python via Java PowerPoint प्रस्तुतियों को PowerPoint XML Presentation फ़ॉर्मेट में परिवर्तित कर सकता है। XML आउटपुट उपयोगी है जब आपको प्रस्तुति की संरचना की जांच, उत्पन्न दस्तावेज़ों की समस्या निवारण, स्वचालित परीक्षणों में आउटपुट की तुलना, या ऐसी वर्कफ़्लो के साथ एकीकरण करने की आवश्यकता हो जो प्रस्तुति पैकेज के बजाय XML का उपयोग करता है।

Presentation.save विधि का उपयोग करें और [SaveFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/saveformat/) वर्ग से [Xml](https://reference.aspose.com/slides/hi/python-java/aspose.slides/saveformat/#Xml) मान को पास करें। आप परिणाम को सीधे फ़ाइल या स्ट्रीम में लिख सकते हैं।

{{% alert color="info" title="Note" %}}
[SaveFormat.Xml](https://reference.aspose.com/slides/hi/python-java/aspose.slides/saveformat/#Xml) PowerPoint XML Presentation बनाता है। यह PPTX पैकेज के भीतर संग्रहीत व्यक्तिगत Office Open XML भागों को नहीं निकालता है। यदि आपको सटीक PPTX पैकेज भागों की आवश्यकता है, जैसे `ppt/presentation.xml` या व्यक्तिगत स्लाइड XML फ़ाइलें, तो स्वयं PPTX पैकेज का निरीक्षण करें।
{{% /alert %}}

## **एक प्रस्तुति को XML फ़ाइल में बदलें**

[Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) वर्ग का उपयोग करके स्रोत प्रस्तुति लोड करें, फिर आउटपुट पथ और [SaveFormat.Xml](https://reference.aspose.com/slides/hi/python-java/aspose.slides/saveformat/#Xml) को [Presentation.save](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#save) को पास करें। स्रोत कोई भी लोडिंग समर्थित प्रस्तुति फ़ॉर्मेट हो सकता है, जैसे PPT, PPTX, या ODP।

निम्नलिखित उदाहरण PPTX प्रस्तुति को XML फ़ाइल में परिवर्तित करता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation.xml", SaveFormat.Xml)
finally:
    presentation.dispose()
```

## **XML आउटपुट को स्ट्रीम में लिखें**

जब XML को स्मृति में रखना हो या किसी अन्य घटक को पास करना हो, जैसे वेब सेवा, स्टोरेज प्रदाता, या XML प्रोसेसिंग पाइपलाइन, तो [Presentation.save](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#save) के स्ट्रीम ओवरलोड का उपयोग करें। निम्नलिखित उदाहरण परिणाम को [ByteArrayOutputStream](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/io/ByteArrayOutputStream.html) में लिखता है और परिणामी XML को Python बाइट्स ऑब्जेक्ट के रूप में प्राप्त करता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

presentation = Presentation("presentation.pptx")
try:
    xml_stream = ByteArrayOutputStream()
    try:
        presentation.save(xml_stream, SaveFormat.Xml)
        java_bytes = xml_stream.toByteArray()
        xml_data = bytes(java_bytes)

        # xml_data को वर्कफ़्लो में अगले घटक को पास करें।
    finally:
        xml_stream.close()
finally:
    presentation.dispose()
```

## **XML की तुलना प्रस्तुति और निर्यात फ़ॉर्मेट से करें**

परिणाम के उपयोग के अनुसार आउटपुट फ़ॉर्मेट चुनें:

| फ़ॉर्मेट | आउटपुट | सामान्य उपयोग |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | PowerPoint XML Presentation | संरचना की जांच, समस्या निवारण, उत्पन्न आउटपुट की तुलना, और XML-आधारित एकीकरण |
| PPT (`.ppt`) | लेगेसी बाइनरी प्रस्तुति फ़ाइल | पुराने PowerPoint वर्कफ़्लो के साथ संगतता |
| PPTX (`.pptx`) | कई भागों वाला Office Open XML पैकेज | सामान्य PowerPoint संपादन और प्रस्तुति आदान‑प्रदान |
| PDF or TIFF | स्थिर लेआउट पृष्ठ या बहुपृष्ठ छवि | देखना, प्रिंट करना, और अभिलेखण |
| PNG, JPEG, or SVG | व्यक्तिगत स्लाइड का रेंडर किया हुआ प्रतिनिधित्व | थंबनेल, पूर्वावलोकन, और छवि एसेट्स |
| HTML or HTML5 | वेब‑उन्मुख प्रस्तुति आउटपुट | ब्राउज़र में देखना और वेब प्रकाशन |

PPT और PPTX के विपरीत, XML आउटपुट मुख्यतः निरीक्षण और डेटा‑उन्मुख वर्कफ़्लो के लिए अभिप्रेत है। PDF, TIFF, HTML, और स्लाइड इमेज फ़ॉर्मेट के विपरीत, यह स्लाइडों को पृष्ठों या दृश्य एसेट्स के रूप में रेंडर करने के बजाय प्रस्तुति डेटा का प्रतिनिधित्व करता है। [समर्थित फ़ाइल फ़ॉर्मेट](/slides/hi/python-java/supported-file-formats/) तालिका में PowerPoint XML Presentation केवल‑सेव फ़ॉर्मेट के रूप में सूचीबद्ध है, इसलिए जब किसी वर्कफ़्लो को निर्यातित फ़ाइल को फिर से Aspose.Slides में लोड करके संपादन जारी रखने की आवश्यकता हो, तो इसका उपयोग न करें।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या XML निर्यात PPTX फ़ाइल को सहेजने के समान है?**

नहीं। PPTX कई Office Open XML भागों वाला एक पैकेज है, जबकि [SaveFormat.Xml](https://reference.aspose.com/slides/hi/python-java/aspose.slides/saveformat/#Xml) एक PowerPoint XML Presentation फ़ाइल बनाता है।

**क्या मैं डिस्क पर फ़ाइल बनाए बिना XML आउटपुट सहेज सकता हूँ?**

हां। एक लिखने योग्य Java आउटपुट स्ट्रीम को [Presentation.save](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#save) को पास करें। उदाहरण के लिए, इन‑मेमोरी प्रोसेसिंग के लिए [ByteArrayOutputStream](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/io/ByteArrayOutputStream.html) का उपयोग करें।

**क्या Aspose.Slides निर्यातित XML फ़ाइल को फिर से लोड कर सकता है?**

नहीं। वर्तमान में PowerPoint XML Presentation केवल सहेजने के लिए समर्थित है, लोड करने के लिए नहीं। यदि राउंड‑ट्रिप संपादन आवश्यक है तो PPTX या कोई अन्य समर्थित प्रस्तुति फ़ॉर्मेट का उपयोग करें।

**क्या XML रूपांतरण प्रत्येक स्लाइड को पृष्ठ या छवि के रूप में रेंडर करता है?**

नहीं। XML रूपांतरण संरचित प्रस्तुति डेटा लिखता है। पृष्ठ‑उन्मुख आउटपुट के लिए PDF या TIFF का उपयोग करें, या व्यक्तिगत स्लाइड छवियों के लिए PNG, JPEG, और SVG का प्रयोग करें।