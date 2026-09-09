---
title: Python में PPT को PPTX में बदलें
linktitle: PPT से PPTX
type: docs
weight: 20
url: /hi/python-java/convert-ppt-to-pptx/
keywords:
- PowerPoint बदलें
- प्रेजेंटेशन बदलें
- स्लाइड बदलें
- PPT बदलें
- PPT से PPTX
- PPT को PPTX के रूप में सहेजें
- PPT को PPTX में निर्यात करें
- PowerPoint
- प्रेजेंटेशन
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides के साथ Python में लेगेसी PPT फ़ाइलों को PPTX में बदलें। एकल फ़ाइल और बैच रूपांतरण, त्रुटि हैंडलिंग, और सटीकता नोट्स के लिए Python उदाहरण शामिल हैं।"
---
## **समीक्षा**

PPT लेगेसी बाइनरी PowerPoint फ़ॉर्मेट है, जबकि PPTX नया Open XML फ़ॉर्मेट है। Aspose.Slides for Python via Java Microsoft PowerPoint के बिना PPT फ़ाइल को लोड कर सकता है और उसे PPTX के रूप में सहेज सकता है। यह लेख दिखाता है कि एक फ़ाइल या फ़ाइलों की डायरेक्टरी को कैसे बदलें और रूपांतरण के बाद क्या सत्यापित किया जाए।

प्रत्येक उदाहरण आवश्यकता होने पर Java वर्चुअल मशीन को प्रारंभ करता है और उपयोग के बाद प्रस्तुति को रिलीज़ करता है। उदाहरण पथों को अपने फ़ाइल या डायरेक्टरी पथों से बदल दें।

## **PPT फ़ाइल को PPTX में बदलें**

स्रोत फ़ाइल को [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास से लोड करें, फिर [Presentation.save](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#save) को [SaveFormat.Pptx](https://reference.aspose.com/slides/hi/python-java/aspose.slides/saveformat/#Pptx) के साथ कॉल करें। `finally` ब्लॉक प्रस्तुति को नष्ट कर देता है और उसके संसाधनों को रिलीज़ करता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# लेगेसी PPT प्रस्तुति लोड करें।
presentation = Presentation("presentation.ppt")
try:
    # प्रस्तुति को PPTX फ़ॉर्मेट में सहेजें।
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

फ़ाइल विस्तार स्वयं आउटपुट फ़ॉर्मेट को चयन नहीं करता; यह [SaveFormat.Pptx](https://reference.aspose.com/slides/hi/python-java/aspose.slides/saveformat/#Pptx) तर्क करता है। यदि आपको मूल PPT फ़ाइल को बनाए रखना है तो इनपुट और आउटपुट पथ अलग रखें।

## **कई PPT फ़ाइलों को बदलें**

निम्नलिखित उदाहरण एक डायरेक्टरी में प्रत्येक `.ppt` फ़ाइल को बदलता है। प्रत्येक फ़ाइल स्वतंत्र रूप से प्रोसेस की जाती है, इसलिए एक विफल रूपांतरण बाकी बैच को नहीं रोकता।

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

input_directory = Path("input")
output_directory = Path("output")

try:
    output_directory.mkdir(parents=True, exist_ok=True)
    input_files = list(input_directory.iterdir())
except OSError as error:
    print(f"Cannot prepare the conversion directories: {error}")
else:
    for input_file in input_files:
        if not input_file.is_file() or input_file.suffix.lower() != ".ppt":
            continue

        output_file = output_directory / (input_file.stem + ".pptx")
        input_path = str(input_file)
        output_path = str(output_file)
        presentation = None

        try:
            presentation = Presentation(input_path)
            presentation.save(output_path, SaveFormat.Pptx)
            print(f"Converted: {input_path}")
        except Exception as error:
            print(f"Failed: {input_path} ({error})")
        finally:
            if presentation is not None:
                presentation.dispose()
```

प्रोडक्शन वर्कलोड के लिए, पूर्ण अपवाद को लॉग करें, यह तय करें कि मौजूदा आउटपुट फ़ाइल को ओवरराइट किया जा सकता है या नहीं, और विफल फ़ाइल नामों को पुनः प्रयास या समीक्षा कतार में लिखें। भ्रष्ट फ़ाइलें, पासवर्ड-प्रोटेक्टेड फ़ाइलें जो आवश्यक पासवर्ड के बिना खोली गई हैं, पहुंच से बाहर पथ, और असमर्थित सामग्री सभी रूपांतरण को विफल कर सकते हैं। एन्क्रिप्टेड फ़ाइलों को लोड करने के लिए देखें [Password-Protected Presentations](/slides/hi/python-java/password-protected-presentation/)।

## **सटीकता और लेगेसी विशेषताएँ**

रूपांतरण आम तौर पर स्लाइड्स, मास्टर्स, लेआउट्स, टेक्स्ट, शॅप्स, इमेजेज, टेबल्स और चार्ट्स को संरक्षित रखता है। हालांकि, PPT और PPTX हर फीचर को बिल्कुल उसी तरह प्रदर्शित नहीं करते। कोई लेगेसी फीचर जिसके पास PPTX समकक्ष नहीं है, या जो लाइब्रेरी द्वारा समर्थित नहीं है, उसे सामान्यीकृत, हटाया या अलग ढंग से दिखाया जा सकता है।

रूपांतरित फ़ाइल की जाँच करें जब उसमें एनीमेशन, ट्रांज़िशन, एम्बेडेड या लिंक्ड OLE ऑब्जेक्ट्स, ActiveX कंट्रोल्स, एम्बेडेड मीडिया, दुर्लभ फ़ॉन्ट्स, या VBA मैक्रो हों। साधारण PPTX फ़ाइल मैक्रो-समर्थित फॉर्मेट नहीं है, इसलिए जब VBA उपलब्ध रहना आवश्यक हो तो उपयुक्त मैक्रो-समर्थित वर्कफ़्लो का उपयोग करें। यह भी सत्यापित करें कि आवश्यक फ़ॉन्ट्स और बाहरी संसाधन उस वातावरण में मौजूद हैं जहाँ रूपांतरित प्रस्तुति खोली या रेंडर की जाएगी।

महत्वपूर्ण दस्तावेज़ों के लिए, उत्पन्न PPTX को प्रोग्रामैटिकली पुन: खोलें और प्रमुख स्लाइड गिनती व सामग्री का निरीक्षण करें, फिर इसे इच्छित व्यूअर में दिखावट और स्लाइड‑शो व्यवहार से तुलना करें। यह न मानें कि सफल [Presentation.save](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#save) कॉल यह प्रमाण है कि हर लेगेसी फीचर का सटीक PPTX प्रतिनिधित्व है।

## **PPTX कब उपयोग करें**

PPTX का उपयोग तब करें जब प्रस्तुति को वर्तमान PowerPoint संस्करणों में संपादित किया जाएगा, उन सिस्टमों के साथ आदान‑प्रदान किया जाएगा जो Open XML पैकेजों के साथ काम करते हैं, या ऐसे फ़ॉर्मेट में संग्रहीत किया जाएगा जो लेगेसी बाइनरी PPT की तुलना में निरीक्षण और पुनर्स्थापन में आसान हो। जब तक रूपांतरित प्रस्तुति ने आपके सटीकता परीक्षण पास नहीं कर ली है, तब तक मूल PPT को अभिलेखीय या रोलबैक प्रतिलिपि के रूप में रखें।

यदि आपको इसके बजाय PDF, HTML, इमेजेज, XPS, या कोई अन्य आउटपुट प्रकार चाहिए, तो सभी लक्ष्यों को वैरैबल PowerPoint फीचर्स संरक्षित मानने के बजाय [Convert Presentations to Multiple Formats](/slides/hi/python-java/convert-presentation/) में दी गई फ़ॉर्मेट‑विशिष्ट मार्गदर्शिका का उपयोग करें।

## **ऑनलाइन कनवर्टर**

कभी‑कभार की फ़ाइल या तेज़ तुलना के लिए, आप [online PPT to PPTX converter](https://products.aspose.app/slides/hi/conversion/ppt-to-pptx) का उपयोग कर सकते हैं। दोहराने योग्य रूपांतरण, बैच प्रोसेसिंग, या एप्लिकेशन‑स्तर की त्रुटि हैंडलिंग के लिए, Python via Java API का उपयोग करें।

## **संबंधित लेख**

- [PPT बनाम PPTX](/slides/hi/python-java/ppt-vs-pptx/)
- [Python में प्रस्तुति सहेजें](/slides/hi/python-java/save-presentation/)
- [समर्थित फ़ाइल फ़ॉर्मेट्स](/slides/hi/python-java/supported-file-formats/)
- [Python में प्रस्तुतियों को खोलें](/slides/hi/python-java/open-presentation/)

## **FAQ**

**क्या मैं Microsoft PowerPoint स्थापित किए बिना PPT को PPTX में बदल सकता हूँ?**

हाँ। Aspose.Slides for Python via Java प्रस्तुति फ़ाइलों को लोड और सहेज सकता है बिना Microsoft PowerPoint की आवश्यकता के।

**क्या PPT‑to‑PPTX रूपांतरण सभी सामग्री को बिल्कुल संरक्षित रखेगा?**

यह सामान्य प्रस्तुति सामग्री को संरक्षित रखता है, लेकिन हर लेगेसी या असमर्थित फीचर के लिए सटीक सटीकता की गारंटी नहीं है। जब उत्पन्न फ़ाइल में मैक्रो, OLE या ActiveX ऑब्जेक्ट, मीडिया, विशेष एनीमेशन, या दुर्लभ फ़ॉन्ट्स हों तो उसकी समीक्षा करें।

**क्या मैं पासवर्ड‑प्रोटेक्टेड PPT फ़ाइल को बदल सकता हूँ?**

हाँ, यदि आप फ़ाइल लोड करते समय सही पासवर्ड प्रदान करते हैं। पासवर्ड की कमी या गलत पासवर्ड लोड ऑपरेशन को विफल कर देता है।

**क्या मुझे रूपांतरण के बाद PPT फ़ाइल को हटाना चाहिए?**

मूल फ़ाइल रखें जब तक आप PPTX को उन व्यूअर्स और वर्कफ़्लोज़ में सत्यापित न कर लें जो आपके लिए महत्वपूर्ण हैं। यह एक रोलबैक प्रतिलिपि प्रदान करता है यदि कोई लेगेसी फीचर अलग तरीके से बदलता है।