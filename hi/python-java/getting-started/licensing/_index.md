---
title: लाइसेंसिंग
type: docs
weight: 80
url: /hi/python-java/licensing/
keywords:
- Aspose.Slides
- Python
- Java
- लाइसेंस फ़ाइल
- अस्थायी लाइसेंस
- मीटरड लाइसेंसिंग
- मूल्यांकन सीमाएँ
description: "Aspose.Slides for Python via Java में फ़ाइल, बाइट-आधारित या मीटरड लाइसेंस लागू करें और अपने अनुप्रयोगों से मूल्यांकन सीमाओं को हटाएँ।"
---
## **समीक्षा**

Aspose.Slides for Python via Java को मूल्यांकन मोड में या लाइसेंस के साथ चलाया जा सकता है। यह लेख फ़ाइल या बाइट्स से लाइसेंस कैसे लागू किया जाए और मीटरड लाइसेंसिंग को कैसे कॉन्फ़िगर किया जाए, यह समझाता है।

खरीद विकल्पों के लिए देखें [मूल्य जानकारी](https://purchase.aspose.com/pricing/slides/hi/family)। सामान्य लाइसेंसिंग और खरीद प्रश्नों के लिए देखें [खरीद नीतियाँ और FAQ](https://purchase.aspose.com/policies)।

मूल्यांकन सीमाओं और अस्थायी लाइसेंस का अनुरोध कैसे करें, यह जानने के लिए देखें [Aspose.Slides का मूल्यांकन](/slides/hi/python-java/evaluate-aspose-slides/)। खरीदे गए लाइसेंस फ़ाइल की तरह ही अस्थायी लाइसेंस लागू करें।

## **लाइसेंस के बारे में**

एक लाइसेंस फ़ाइल में उत्पाद नाम, लाइसेंस प्राप्त डेवलपर्स की संख्या और सब्सक्रिप्शन समाप्ति तिथि जैसी जानकारी होती है। फ़ाइल डिजिटल रूप से हस्ताक्षरित XML होती है।

{{% alert color="warning" title="Warning" %}}
लाइसेंस फ़ाइल को संपादित न करें। एक अतिरिक्त लाइन ब्रेक भी उसकी डिजिटल सिग्नेचर को अमान्य कर सकता है।
{{% /alert %}}

लाइसेंस को प्रत्येक एप्लिकेशन या प्रक्रिया के लिए एक बार लागू करें, प्रस्तुतियों को बनाने या अन्य Aspose.Slides ऑपरेशनों को करने से पहले। लाइसेंस फ़ाइल के लिए, [License](https://reference.aspose.com/slides/hi/python-java/aspose.slides/license/) क्लास का प्रयोग करें। मीटरड लाइसेंसिंग लाइसेंस फ़ाइल की बजाय एक पब्लिक और प्राइवेट कुंजी जोड़ी का उपयोग करता है।

## **लाइसेंस लागू करें**

निम्न उदाहरण मानते हैं कि Aspose.Slides for Python via Java और इसकी पूर्व शर्तें स्थापित हैं। प्रत्येक उदाहरण एक अलग स्क्रिप्ट है जो JVM शुरू करता है, API को इम्पोर्ट करता है, और लाइसेंस लागू करता है। आपके एप्लिकेशन में, लाइसेंस लागू करने के बाद अपनी प्रस्तुति ऑपरेशन्स करें और सभी Aspose.Slides कार्य पूर्ण होने के बाद JVM को बंद करें।

### **फ़ाइल से लाइसेंस लागू करें**

[License.setLicense](https://reference.aspose.com/slides/hi/python-java/aspose.slides/license/#setLicense) को लाइसेंस फ़ाइल पथ पास करें। `Aspose.Slides.lic` को अपनी लाइसेंस फ़ाइल के पथ से बदलें।

```python
from pathlib import Path

import jpype
import asposeslides

jpype.startJVM()

try:
    from asposeslides.api import License

    license_path = Path("Aspose.Slides.lic")
    if license_path.is_file():
        license = License()
        license.setLicense(str(license_path))
        print("Licensed:", license.isLicensed())
        # यहाँ प्रस्तुति संचालन करें, JVM को शटडाउन करने से पहले।
    else:
        print("License file not found. Set the path to your license file.")
finally:
    jpype.shutdownJVM()
```

सटीक फ़ाइल नाम, सहित इसका एक्स्टेंशन, उपयोग करें। उदाहरण के लिए, यदि फ़ाइल का नाम `Aspose.Slides.lic.xml` है, तो पथ में `.xml` शामिल करें। एक एब्सोल्यूट पाथ एप्लिकेशन के वर्किंग डायरेक्टरी के बारे में भ्रम को रोकता है।

उदाहरण [License.isLicensed](https://reference.aspose.com/slides/hi/python-java/aspose.slides/license/#isLicensed) का उपयोग करके जांचता है कि लाइसेंस लागू हुआ है या नहीं।

### **बाइट्स से लाइसेंस लागू करें**

जब लाइसेंस Python बाइट्स के रूप में उपलब्ध हो, तो [License.setLicenseFromBytes](https://reference.aspose.com/slides/hi/python-java/aspose.slides/license/#setLicenseFromBytes) का उपयोग करें। निम्न उदाहरण फ़ाइल को बाइनरी मोड में पढ़ता है और लाइसेंस लागू करने से पहले उसे बंद कर देता है।

```python
from pathlib import Path

import jpype
import asposeslides

jpype.startJVM()

try:
    from asposeslides.api import License

    license_path = Path("Aspose.Slides.lic")
    if license_path.is_file():
        with license_path.open("rb") as license_file:
            license_data = license_file.read()

        license = License()
        license.setLicenseFromBytes(license_data)
        print("Licensed:", license.isLicensed())
        # यहाँ प्रस्तुति संचालन करें, JVM को शटडाउन करने से पहले।
    else:
        print("License file not found. Set the path to your license file.")
finally:
    jpype.shutdownJVM()
```

मूल बाइट्स को अपरिवर्तित रखें। लाइसेंस सामग्री को लागू करने से पहले डिकोड, रीफ़ॉर्मेट या किसी भी प्रकार से संशोधित न करें।

## **मीटरड लाइसेंस लागू करें**

मीटरड लाइसेंसिंग API उपयोग के अनुसार आपको बिल करती है। मीटरड लाइसेंस प्राप्त करने के बाद, उसके सार्वजनिक और निजी कुंजियों को [Metered.setMeteredKey](https://reference.aspose.com/slides/hi/python-java/aspose.slides/metered/#setMeteredKey) के साथ लागू करें। एप्लिकेशन स्टार्टअप पर एक बार [Metered](https://reference.aspose.com/slides/hi/python-java/aspose.slides/metered/) ऑब्जेक्ट को इनिशियलाइज़ करें और कुंजियों को लागू करें।

निम्न उदाहरण `ASPOSE_METERED_PUBLIC_KEY` और `ASPOSE_METERED_PRIVATE_KEY` पर्यावरण चर से कुंजियों को पढ़ता है। स्क्रिप्ट चलाने से पहले दोनों चर सेट करें।

```python
import os

import jpype
import asposeslides

jpype.startJVM()

try:
    from asposeslides.api import Metered

    public_key = os.environ.get("ASPOSE_METERED_PUBLIC_KEY")
    private_key = os.environ.get("ASPOSE_METERED_PRIVATE_KEY")

    if public_key and private_key:
        metered = Metered()
        metered.setMeteredKey(public_key, private_key)
        # यहाँ प्रस्तुति संचालन करें, JVM को शटडाउन करने से पहले।
    else:
        print("Set both metered licensing environment variables before running this example.")
finally:
    jpype.shutdownJVM()
```

{{% alert color="info" title="Note" %}}
मीटरड लाइसेंसिंग को कुंजियों को वैध करने और उपयोग रिपोर्ट करने के लिए इंटरनेट कनेक्शन की आवश्यकता होती है। प्राइवेट कुंजी को स्रोत कोड और लॉग्स से बाहर रखें। कनेक्टिविटी और बिलिंग विवरण के लिए देखें [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered)।
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या लाइसेंस खरीदने के बाद मुझे कोई अलग पैकेज स्थापित करने की आवश्यकता है?**  
नहीं। उस ही पैकेज पर लाइसेंस लागू करें जिसे आपने मूल्यांकन के लिए उपयोग किया था।

**क्या मुझे प्रत्येक प्रस्तुति के लिए लाइसेंस लागू करना चाहिए?**  
नहीं। एप्लिकेशन स्टार्टअप के दौरान एक बार लाइसेंस लागू करें, प्रस्तुति बनाने या लोड करने से पहले।

**क्या मैं लाइसेंस फ़ाइल का नाम बदल सकता हूँ?**  
हां। अपने कोड में बिल्कुल वही नया फ़ाइल नाम उपयोग करें और फ़ाइल की सामग्री अपरिवर्तित रखें।

**क्या मैं बाइट-आधारित उदाहरण के साथ अस्थायी लाइसेंस का उपयोग कर सकता हूँ?**  
हां। अस्थायी लाइसेंस फ़ाइल को बाइट्स के रूप में पढ़ें और इसे खरीदे गए लाइसेंस की तरह ही लागू करें।