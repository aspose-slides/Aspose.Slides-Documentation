---
title: Python में PPT को PPTX में बदलें
linktitle: PPT से PPTX
type: docs
weight: 20
url: /hi/python-java/convert-ppt-to-pptx/
keywords:
- PowerPoint बदलें
- प्रेज़ेंटेशन बदलें
- स्लाइड बदलें
- PPT बदलें
- PPT से PPTX
- PPT को PPTX के रूप में सहेजें
- PPT को PPTX में निर्यात करें
- PowerPoint
- प्रेज़ेंटेशन
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides के साथ Python में लेगेसी PPT फ़ाइलों को PPTX में बदलें। इसमें एकल फ़ाइल और बैच रूपांतरण, त्रुटि हैंडलिंग, और सटीकता नोट्स के लिए Python उदाहरण शामिल हैं।"
---
## **सारांश**

PPT लेगसी बाइनरी PowerPoint फ़ॉर्मेट है, जबकि PPTX नया Open XML फ़ॉर्मेट है। Aspose.Slides for Python via Java Microsoft PowerPoint के बिना PPT फ़ाइल को लोड कर सकता है और उसे PPTX के रूप में सहेज सकता है। यह लेख दिखाता है कि एक फ़ाइल या फ़ाइलों की डायरेक्टरी को कैसे बदलें और रूपांतरण के बाद क्या सत्यापित करें।

प्रत्येक उदाहरण आवश्यक होने पर Java वर्चुअल मशीन शुरू करता है और उपयोग के बाद प्रेज़ेंटेशन को रिलीज़ करता है। उदाहरण पथों को अपने स्वयं के फ़ाइल या डायरेक्टरी पथों से बदलें।

## **PPT फ़ाइल को PPTX में बदलें**

सोर्स फ़ाइल को [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास से लोड करें, फिर [Presentation.save](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#save) को [SaveFormat.Pptx](https://reference.aspose.com/slides/hi/python-java/aspose.slides/saveformat/#Pptx) के साथ कॉल करें। `finally` ब्लॉक प्रेज़ेंटेशन को डिस्पोज़ करता है और उसके संसाधनों को रिलीज़ करता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# लेगेसी PPT प्रस्तुति लोड करें।
presentation = Presentation("presentation.ppt")
try:
    # प्रेज़ेंटेशन को PPTX फ़ॉर्मेट में सहेजें।
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

फ़ाइल एक्स्टेंशन स्वयं आउटपुट फ़ॉर्मेट का चयन नहीं करता; यह [SaveFormat.Pptx](https://reference.aspose.com/slides/hi/python-java/aspose.slides/saveformat/#Pptx) तर्क करता है। यदि आपको मूल PPT फ़ाइल को बनाए रखना है तो इनपुट और आउटपुट पाथ अलग रखें।

## **एकाधिक PPT फ़ाइलें बदलें**

निम्न उदाहरण एक डायरेक्टरी में मौजूद प्रत्येक `.ppt` फ़ाइल को बदलता है। प्रत्येक फ़ाइल स्वतंत्र रूप से प्रोसेस की जाती है, इसलिए एक फ़ाइल का परिवर्तन असफल होने से बाकी बैच रुकता नहीं है।

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

प्रोडक्शन वर्कलोड्स के लिए, पूरी एक्सेप्शन को लॉग करें, तय करें कि मौजूदा आउटपुट फ़ाइल को ओवरराइट किया जा सकता है या नहीं, और विफल फ़ाइल नामों को रीट्राय या रिव्यू क्यू में लिखें। करप्ट फ़ाइलें, पासवर्ड‑प्रोटेक्टेड फ़ाइलें जो आवश्यक पासवर्ड के बिना खोली गई हों, पहुँच न योग्य पाथ, और असमर्थित कंटेंट सभी परिवर्तन को विफल कर सकते हैं। एन्क्रिप्टेड फ़ाइलों को लोड करने के लिए [Password-Protected Presentations](/slides/hi/python-java/password-protected-presentation/) देखें।

## **सटीकता और लेगेसी फीचर**

परिवर्तन सामान्यतः स्लाइड्स, मास्टर्स, लेआउट्स, टेक्स्ट, शैप्स, इमेजेज, टेबल्स और चार्ट्स को संरक्षित करता है। हालांकि, PPT और PPTX हर फीचर को बिल्कुल उसी तरह नहीं दर्शाते। एक लेगेसी फीचर जिसका PPTX में समतुल्य नहीं है, या जो लाइब्रेरी द्वारा समर्थित नहीं है, उसे सामान्यीकृत, हटाया या अलग तरीके से दिखाया जा सकता है।

परिवर्तित फ़ाइल को तब जांचें जब उसमें एनीमेशन, ट्रांज़िशन, एंबेडेड या लिंक्ड OLE ऑब्जेक्ट्स, ActiveX कंट्रोल्स, एंबेडेड मीडिया, अनकमन फ़ॉन्ट्स, या VBA मैक्रो शामिल हों। साधा PPTX फ़ाइल मैक्रो‑एनेबल्ड फ़ॉर्मेट नहीं है, इसलिए जब VBA उपलब्ध रहना आवश्यक हो तो उचित मैक्रो‑एनेबल्ड वर्कफ़्लो का उपयोग करें। यह भी सुनिश्चित करें कि आवश्यक फ़ॉन्ट्स और बाहरी संसाधन उस वातावरण में मौजूद हों जहाँ परिवर्तित प्रेज़ेंटेशन खोला या रेंडर किया जाएगा।

महत्वपूर्ण दस्तावेज़ों के लिए, उत्पन्न PPTX को प्रोग्रामेटिकली पुनः खोलें और प्रमुख स्लाइड गिनती व कंटेंट की जाँच करें, फिर इच्छित व्यूअर में उसके लुक और स्लाइड‑शो व्यवहार की तुलना करें। यह नहीं सोचना चाहिए कि एक सफल [Presentation.save](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#save) कॉल यह प्रमाण है कि प्रत्येक लेगेसी फ़ीचर का सटीक PPTX प्रतिनिधित्व मौजूद है।

## **जब PPTX का उपयोग करें**

PPTX का उपयोग तब करें जब प्रेज़ेंटेशन को वर्तमान PowerPoint संस्करणों में संपादित किया जाएगा, Open XML पैकेजों के साथ काम करने वाले सिस्टमों के साथ विनिमय किया जाएगा, या ऐसे फ़ॉर्मेट में संग्रहीत किया जाए जो लेगेसी बाइनरी PPT की तुलना में जांच और पुनर्प्राप्ति में आसान हो। जब तक परिवर्तित प्रेज़ेंटेशन आपके सटीकता जांच पास नहीं करता, मूल PPT को आर्काइवल या रोलबैक कॉपी के रूप में रखें।

यदि आपको PDF, HTML, इमेजेज, XPS, या कोई अन्य आउटपुट टाइप चाहिए, तो सभी लक्ष्य संपादन योग्य PowerPoint फीचर्स को संरक्षित रखेंगे यह मानने के बजाय [Convert Presentations to Multiple Formats](/slides/hi/python-java/convert-presentation/) में विशिष्ट फ़ॉर्मेट गाइडेंस का उपयोग करें।

## **ऑनलाइन कन्वर्टर**

कभी‑कभी की फ़ाइल या त्वरित तुलना के लिए, आप [online PPT to PPTX converter](https://products.aspose.app/slides/hi/conversion/ppt-to-pptx) का उपयोग कर सकते हैं। निरंतर परिवर्तनों, बैच प्रोसेसिंग, या एप्लिकेशन‑लेवल एरर हैंडलिंग के लिए, Python via Java API का उपयोग करें।

## **संबंधित लेख**

- [PPT बनाम PPTX](/slides/hi/python-java/ppt-vs-pptx/)
- [Python में प्रेज़ेंटेशन सहेजें](/slides/hi/python-java/save-presentation/)
- [समर्थित फ़ाइल फ़ॉर्मेट](/slides/hi/python-java/supported-file-formats/)
- [Python में प्रेज़ेंटेशन खोलें](/slides/hi/python-java/open-presentation/)

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं Microsoft PowerPoint स्थापित किए बिना PPT को PPTX में बदल सकता हूँ?**

हाँ। Aspose.Slides for Python via Java Microsoft PowerPoint की आवश्यकता के बिना प्रेज़ेंटेशन फ़ाइलों को लोड और सहेजता है।

**क्या PPT‑to‑PPTX रूपांतरण सभी कंटेंट को बिल्कुल सटीक रूप से संरक्षित करेगा?**

यह सामान्य प्रेज़ेंटेशन कंटेंट को संरक्षित करता है, लेकिन प्रत्येक लेगेसी या असमर्थित फ़ीचर के लिए सटीक सटीकता की गारंटी नहीं है। जब उत्पन्न फ़ाइल में मैक्रो, OLE या ActiveX ऑब्जेक्ट्स, मीडिया, विशेष एनीमेशन, या अनकमन फ़ॉन्ट्स हों तो फ़ाइल की समीक्षा करें।

**क्या मैं पासवर्ड‑प्रोटेक्टेड PPT फ़ाइल को बदल सकता हूँ?**

हाँ, यदि आप फ़ाइल लोड करते समय सही पासवर्ड प्रदान करते हैं। एक गायब या गलत पासवर्ड लोड ऑपरेशन को विफल कर देता है।

**क्या मुझे रूपांतरण के बाद PPT फ़ाइल को हटाना चाहिए?**

जब तक आप PPTX को उन व्यूअर्स और वर्कफ़्लोज़ में सत्यापित नहीं कर लेते जो आपके लिए महत्वपूर्ण हैं, मूल फ़ाइल को रखें। यदि कोई लेगेसी फ़ीचर अलग तरीके से बदलता है तो यह एक रोलबैक कॉपी प्रदान करता है।