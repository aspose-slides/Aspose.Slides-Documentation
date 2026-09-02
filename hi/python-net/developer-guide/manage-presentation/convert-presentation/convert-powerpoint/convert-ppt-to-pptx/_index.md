---
title: Python में PPT को PPTX में बदलें
linktitle: PPT से PPTX
type: docs
weight: 20
url: /hi/python-net/convert-ppt-to-pptx/
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
- Aspose.Slides
description: "Aspose.Slides के साथ Python में लेगेसी PPT फ़ाइलों को PPTX में बदलें। एकल फ़ाइल और बैच रूपांतरण, त्रुटि प्रबंधन, और फ़िडेलिटी नोट्स के उदाहरण शामिल हैं।"
---
## **अवलोकन**

PPT एक लेगसी बाइनरी PowerPoint फ़ॉर्मेट है, जबकि PPTX नया Open XML फ़ॉर्मेट है। Aspose.Slides for Python via .NET Microsoft PowerPoint के बिना PPT फ़ाइल को लोड कर PPTX के रूप में सहेज सकता है। यह लेख एक फ़ाइल या फ़ाइलों की डायरेक्टरी को कैसे परिवर्तित किया जाए और परिवर्तन के बाद क्या जांचें, दिखाता है।

## **PPT फ़ाइल को PPTX में बदलें**

स्रोत फ़ाइल को [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास से लोड करें, फिर [Presentation.save](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/save/) को [SaveFormat.PPTX](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/saveformat/) के साथ कॉल करें। `with` स्टेटमेंट प्रस्तुति को डिस्पोज़ करता है और ब्लॉक समाप्त होने पर उसके संसाधनों को रिलीज़ करता है।

```python
import aspose.slides as slides

# लेगेसी PPT प्रस्तुति लोड करें।
with slides.Presentation("presentation.ppt") as presentation:
    # प्रस्तुति को PPTX फ़ॉर्मेट में सहेजें।
    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

फ़ाइल एक्सटेंशन स्वयं आउटपुट फ़ॉर्मेट नहीं चुनता; यह [SaveFormat.PPTX](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/saveformat/) तर्क करता है। यदि आपको मूल PPT फ़ाइल को बरकरार रखना है तो इनपुट और आउटपुट पाथ को अलग रखें।

## **कई PPT फ़ाइलें बदलें**

निम्न उदाहरण एक डायरेक्टरी में प्रत्येक `.ppt` फ़ाइल को बदलता है। प्रत्येक फ़ाइल स्वतंत्र रूप से प्रोसेस की जाती है, इसलिए एक असफल परिवर्तन बाकी बैच को नहीं रोकता।

```python
from pathlib import Path

import aspose.slides as slides

input_directory = Path("input")
output_directory = Path("output")
output_directory.mkdir(parents=True, exist_ok=True)

for input_path in input_directory.glob("*.ppt"):
    output_path = output_directory / f"{input_path.stem}.pptx"

    try:
        with slides.Presentation(str(input_path)) as presentation:
            presentation.save(str(output_path), slides.export.SaveFormat.PPTX)
        print(f"Converted: {input_path}")
    except Exception as exception:
        print(f"Failed: {input_path} ({exception})")
```

प्रोडक्शन वर्कलोड के लिए, पूरा एक्सेप्शन लॉग करें, तय करें कि मौजूदा आउटपुट फ़ाइल को ओवरराइट किया जा सकता है या नहीं, और विफल फ़ाइल नामों को पुनः प्रयास या समीक्षा क्यू में लिखें। खराब फ़ाइलें, पासवर्ड‑सुरक्षित फ़ाइलें जो आवश्यक पासवर्ड के बिना खोली गईं, inaccesible पथ, और असमर्थित कंटेंट सभी परिवर्तन को विफल कर सकते हैं। एन्क्रिप्टेड फ़ाइलों को लोड करने के लिए देखें [Password-Protected Presentations](/python-net/password-protected-presentation/)।

## **फ़िडेलिटी और लेगसी फ़ीचर**

परिवर्तन सामान्यतः स्लाइड्स, मास्टर्स, लेआउट्स, टेक्स्ट, शेप्स, इमेजेज, टेबल्स और चार्ट्स को बरकरार रखता है। हालांकि, PPT और PPTX हर फ़ीचर को बिल्कुल उसी तरह प्रस्तुत नहीं करते। ऐसा लेगसी फ़ीचर जिसका PPTX में समकक्ष नहीं है, या जो लाइब्रेरी द्वारा समर्थित नहीं है, सामान्यीकृत, हटाया या अलग तरीके से दिखाया जा सकता है।

जब परिवर्तित फ़ाइल में एनीमेशन, ट्रांज़िशन, एम्बेडेड या लिंक्ड OLE ऑब्जेक्ट्स, ActiveX कंट्रोल्स, एम्बेडेड मीडिया, दुर्लभ फ़ॉन्ट्स, या VBA मैक्रोज़ हों तो फ़ाइल की जाँच करें। साधारण PPTX फ़ाइल मैक्रो‑सक्षम फ़ॉर्मेट नहीं है, इसलिए जब VBA को उपलब्ध रखना आवश्यक हो तो उचित मैक्रो‑सक्षम वर्कफ़्लो का उपयोग करें। साथ ही यह सत्यापित करें कि आवश्यक फ़ॉन्ट्स और बाहरी संसाधन उस पर्यावरण में मौजूद हैं जहाँ परिवर्तित प्रस्तुति को खोला या रेंडर किया जाएगा।

महत्वपूर्ण दस्तावेज़ों के लिए, उत्पन्न PPTX को प्रोग्रामmatically पुनः खोलें और प्रमुख स्लाइड संख्या और सामग्री की जाँच करें, फिर इच्छित व्यूअर में उसकी उपस्थिति और स्लाइड‑शो व्यवहार की तुलना करें। सफल [Presentation.save](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/save/) कॉल को यह साबित न समझें कि हर लेगसी फ़ीचर का सटीक PPTX प्रतिनिधित्व मौजूद है।

## **कब PPTX का उपयोग करें**

जब प्रस्तुति को वर्तमान PowerPoint संस्करणों में संपादित किया जाएगा, Open XML पैकेजों के साथ काम करने वाली प्रणालियों के साथ बदला जाएगा, या लेगसी बाइनरी PPT की तुलना में निरीक्षण और पुनर्प्राप्ति में आसान फ़ॉर्मेट में संग्रहीत किया जाएगा, तब PPTX का उपयोग करें। जब तक परिवर्तित प्रस्तुति आपकी फ़िडेलिटी जाँच पास न कर ले, मूल PPT को एक अभिलेखीय या रोलबैक प्रतिलिपि के रूप में रखें।

यदि आपको PDF, HTML, इमेजेज, XPS, या कोई अन्य आउटपुट प्रकार चाहिए, तो सभी लक्ष्य संपादन योग्य PowerPoint फ़ीचर को बरकरार रखते हैं, यह मानने के बजाय [Convert Presentations to Multiple Formats](/python-net/convert-presentation/) में विशिष्ट मार्गदर्शन का उपयोग करें।

## **ऑनलाइन कन्वर्टर**

कभी‑कभार फ़ाइल या तेज़ तुलना के लिए, आप [online PPT to PPTX converter](https://products.aspose.app/slides/hi/conversion/ppt-to-pptx) का उपयोग कर सकते हैं। आवर्ती परिवर्तन, बैच प्रोसेसिंग, या एप्लिकेशन‑लेवल त्रुटि हैंडलिंग के लिए, Python API का उपयोग करें।

## **संबंधित लेख**

- [PPT vs PPTX](/python-net/ppt-vs-pptx/)
- [Save Presentations in Python](/python-net/save-presentation/)
- [Supported File Formats](/python-net/supported-file-formats/)
- [Open Presentations in Python](/python-net/open-presentation/)

## **FAQ**

**क्या मैं Microsoft PowerPoint स्थापित किए बिना PPT को PPTX में बदल सकता हूँ?**

हाँ। Aspose.Slides for Python via .NET Microsoft PowerPoint की आवश्यकता के बिना प्रस्तुति फ़ाइलों को लोड और सहेजता है।

**क्या PPT‑to‑PPTX परिवर्तन सभी सामग्री को बिल्कुल समान रूप में रखेगा?**

यह सामान्य प्रस्तुति सामग्री को बरकरार रखता है, लेकिन प्रत्येक लेगसी या असमर्थित फ़ीचर के लिए सटीक फ़िडेलिटी की गारंटी नहीं देता। जब फ़ाइल में मैक्रो, OLE या ActiveX ऑब्जेक्ट्स, मीडिया, विशेष एनीमेशन, या दुर्लभ फ़ॉन्ट्स हों, तो उत्पन्न फ़ाइल की समीक्षा करें।

**क्या मैं पासवर्ड‑सुरक्षित PPT फ़ाइल को बदल सकता हूँ?**

हाँ, यदि आप फ़ाइल लोड करते समय सही पासवर्ड प्रदान करते हैं। अनुपलब्ध या गलत पासवर्ड लोड ऑपरेशन को विफल कर देगा।

**क्या मुझे परिवर्तन के बाद PPT फ़ाइल को हटाना चाहिए?**

मूल फ़ाइल को तब तक रखें जब तक आप अपने व्यूअर्स और वर्कफ़्लो में PPTX को सत्यापित न कर लें। यह एक रोलबैक कॉपी प्रदान करता है यदि कोई लेगसी फ़ीचर अलग तरीके से बदल जाता है।