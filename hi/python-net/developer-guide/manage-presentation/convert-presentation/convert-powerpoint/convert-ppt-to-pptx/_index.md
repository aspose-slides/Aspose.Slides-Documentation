---
title: Python में PPT को PPTX में बदलें
linktitle: PPT से PPTX
type: docs
weight: 20
url: /hi/python-net/convert-ppt-to-pptx/
keywords:
- PowerPoint को बदलें
- प्रेजेंटेशन को बदलें
- स्लाइड को बदलें
- PPT को बदलें
- PPT से PPTX
- PPT को PPTX के रूप में सेव करें
- PPT को PPTX में निर्यात करें
- PowerPoint
- प्रेजेंटेशन
- Python
- Aspose.Slides
description: "Aspose.Slides के साथ Python में लेगेसी PPT फ़ाइलों को PPTX में बदलें। इसमें एकल फ़ाइल और बैच रूपांतरण, त्रुटि प्रबंधन, और सटीकता नोट्स के उदाहरण शामिल हैं।"
---
## **अवलोकन**

PPT लेगेसी बाइनरी PowerPoint फ़ॉर्मेट है, जबकि PPTX नया Open XML फ़ॉर्मेट है। Aspose.Slides for Python via .NET Microsoft PowerPoint के बिना PPT फ़ाइल को लोड कर PPTX के रूप में सहेज सकता है। यह लेख दिखाता है कि कैसे एक फ़ाइल या फ़ाइलों की डायरेक्टरी को बदलें और रूपांतरण के बाद क्या सत्यापित करें।

## **PPT फ़ाइल को PPTX में बदलें**

स्रोत फ़ाइल को [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास के साथ लोड करें, फिर [Presentation.save](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/save/) को [SaveFormat.PPTX](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/saveformat/) के साथ कॉल करें। `with` स्टेटमेंट प्रस्तुति को डिस्पोज़ करता है और ब्लॉक समाप्त होने पर उसके संसाधनों को रिलीज़ कर देता है।

```python
import aspose.slides as slides

# लेगेसी PPT प्रस्तुति को लोड करें।
with slides.Presentation("presentation.ppt") as presentation:
    # PPTX फ़ॉर्मेट में प्रस्तुति सहेजें।
    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

फ़ाइल एक्सटेंशन स्वयं आउटपुट फ़ॉर्मेट का चयन नहीं करता; [SaveFormat.PPTX](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/saveformat/) आर्ग्युमेंट करता है। यदि आपको मूल PPT फ़ाइल रखना है तो इनपुट और आउटपुट पाथ अलग रखें।

## **एकाधिक PPT फ़ाइलों को बदलें**

निम्न उदाहरण एक डायरेक्टरी में प्रत्येक `.ppt` फ़ाइल को बदलता है। प्रत्येक फ़ाइल स्वतंत्र रूप से प्रोसेस होती है, इसलिए एक फ़ाइल का विफल रूपांतरण शेष बैच को नहीं रोकता।

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

प्रोडक्शन वर्कलोड के लिए, संपूर्ण एक्सेप्शन लॉग करें, निर्णय लें कि क्या मौजूदा आउटपुट फ़ाइल को ओवरराइट किया जा सकता है, और विफल फ़ाइल नामों को रीट्राई या रिव्यू कतार में लिखें। करप्ट फ़ाइलें, पासवर्ड-प्रोटेक्टेड फ़ाइलें जो आवश्यक पासवर्ड के बिना खोली गई हैं, इनएक्सेसिबल पाथ, और असमर्थित कंटेंट सभी रूपांतरण को विफल बना सकते हैं। एन्क्रिप्टेड फ़ाइलों को लोड करने के लिए देखें [Password-Protected Presentations](/slides/hi/python-net/password-protected-presentation/)।

## **सटीकता और लेगेसी फीचर्स**

रूपांतरण सामान्यतः स्लाइड्स, मास्टर्स, लेआउट्स, टेक्स्ट, शैप्स, इमेजेज, टेबल्स और चार्ट्स को संरक्षित करता है। हालांकि, PPT और PPTX हर फीचर को बिल्कुल समान तरीके से प्रतिनिधित्व नहीं करते। कोई लेगेसी फीचर जिसका PPTX में समकक्ष नहीं है, या जो लाइब्रेरी द्वारा सपोर्ट नहीं है, उसे सामान्यीकृत, छोड़ दिया जा सकता है, या अलग तरीके से प्रदर्शित किया जा सकता है।

जब रूपांतरित फ़ाइल में एनीमेशन, ट्रांज़िशन, एम्बेडेड या लिंक्ड OLE ऑब्जेक्ट्स, ActiveX कंट्रोल्स, एम्बेडेड मीडिया, असामान्य फ़ॉन्ट्स, या VBA मैक्रो होते हैं तो फ़ाइल की जाँच करें। साधारण PPTX फ़ाइल मैक्रो-समर्थित फ़ॉर्मेट नहीं है, इसलिए जब VBA उपलब्ध रहना आवश्यक हो तो उचित मैक्रो-समर्थित वर्कफ़्लो उपयोग करें। साथ ही यह भी सत्यापित करें कि आवश्यक फ़ॉन्ट्स और बाहरी संसाधन उस पर्यावरण में मौजूद हैं जहाँ रूपांतरित प्रस्तुति को खोला या रेंडर किया जाएगा।

महत्वपूर्ण दस्तावेज़ों के लिए, उत्पन्न PPTX को प्रोग्रामेटिक रूप से पुनः खोलें और प्रमुख स्लाइड गिनती और सामग्री का निरीक्षण करें, फिर इच्छित व्यूअर में उसके रूप और स्लाइड-शो व्यवहार की तुलना करें। यह न मानें कि सफल [Presentation.save](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/save/) कॉल यह प्रमाण है कि प्रत्येक लेगेसी फीचर का सटीक PPTX प्रतिनिधित्व है।

## **जब PPTX का उपयोग करें**

जब प्रस्तुति को वर्तमान PowerPoint वर्ज़न में एडिट किया जाएगा, Open XML पैकेज वाले सिस्टम्स के साथ एक्सचेंज किया जाएगा, या लेगेसी बाइनरी PPT की तुलना में जांचने और रिकवरी में आसान फ़ॉर्मेट में संग्रहीत किया जाएगा, तब PPTX का उपयोग करें। रूपांतरित प्रस्तुति आपके सटीकता जांच पास करने तक मूल PPT को अभिलेखीय या रोलबैक कॉपी के रूप में रखें।

यदि आपको PDF, HTML, इमेजेज, XPS, या कोई अन्य आउटपुट टाइप चाहिए, तो सभी टार्गेट्स एडिटेबल PowerPoint फीचर्स को संरक्षित करेंगे ऐसा मानने के बजाय [Convert Presentations to Multiple Formats](/slides/hi/python-net/convert-presentation/) में दी गई फ़ॉर्मेट-विशिष्ट गाइडेंस का उपयोग करें।

## **ऑनलाइन कन्वर्टर**

कभी-कभी फ़ाइल या त्वरित तुलना के लिए, आप [online PPT to PPTX converter](https://products.aspose.app/slides/hi/conversion/ppt-to-pptx) का उपयोग कर सकते हैं। दोहराने योग्य रूपांतरण, बैच प्रोसेसिंग, या एप्लिकेशन-लेवल एरर हैंडलिंग के लिए Python API का उपयोग करें।

## **संबंधित लेख**

- [PPT बनाम PPTX](/slides/hi/python-net/ppt-vs-pptx/)
- [Python में प्रस्तुति सहेजें](/slides/hi/python-net/save-presentation/)
- [समर्थित फ़ाइल फ़ॉर्मेट](/slides/hi/python-net/supported-file-formats/)
- [Python में प्रस्तुति खोलें](/slides/hi/python-net/open-presentation/)

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं Microsoft PowerPoint स्थापित किए बिना PPT को PPTX में बदल सकता हूँ?**

हाँ। Aspose.Slides for Python via .NET Microsoft PowerPoint की आवश्यकता के बिना प्रस्तुति फ़ाइलों को लोड और सहेजता है।

**क्या PPT‑to‑PPTX रूपांतरण सभी सामग्री को बिल्कुल संरक्षित करेगा?**

यह सामान्य प्रस्तुति सामग्री को संरक्षित करता है, लेकिन प्रत्येक लेगेसी या असमर्थित फीचर के लिए सटीक फ़िडेलिटी की गारंटी नहीं है। जब उत्पन्न फ़ाइल में मैक्रो, OLE या ActiveX ऑब्जेक्ट्स, मीडिया, विशिष्ट एनीमेशन, या असामान्य फ़ॉन्ट्स हों तो फ़ाइल की समीक्षा करें।

**क्या मैं पासवर्ड‑प्रोटेक्टेड PPT फ़ाइल को बदल सकता हूँ?**

हाँ, यदि आप फ़ाइल लोड करते समय सही पासवर्ड प्रदान करते हैं। अनुपलब्ध या गलत पासवर्ड लोड ऑपरेशन को विफल बना देता है।

**क्या रूपांतरण के बाद मुझे PPT फ़ाइल हटानी चाहिए?**

मूल फ़ाइल को तब तक रखें जब तक कि आप PPTX को उन व्यूअर्स और वर्कफ़्लो में सत्यापित नहीं कर लेते जो आपके लिए महत्वपूर्ण हैं। यदि कोई लेगेसी फीचर अलग तरीके से बदलता है तो यह रोलबैक कॉपी प्रदान करता है।