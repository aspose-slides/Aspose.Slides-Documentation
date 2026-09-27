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
- मीटर लाइसेंसिंग
- मूल्यांकन सीमाएँ
description: "Aspose.Slides for Python via Java में फ़ाइल‑आधारित, बाइट‑आधारित या मीटर लाइसेंस लागू करें और अपनी एप्लिकेशनों से मूल्यांकन सीमाओं को हटाएँ।"
---
## **अवलोकन**

Aspose.Slides for Python via Java मूल्यांकन मोड में या लाइसेंस के साथ चल सकता है। मूल्यांकन मोड में, यह प्रत्येक प्रस्तुति को सहेजते समय प्रत्येक स्लाइड में एक मूल्यांकन वाटरमार्क टेक्स्ट बॉक्स जोड़ता है और आपके कोड द्वारा प्रस्तुतियों से पढ़े गए टेक्स्ट को काट देता है। यह लेख फ़ाइल या बाइट्स से लाइसेंस लागू करने और मीटर लाइसेंसिंग को कॉन्फ़िगर करने के तरीके को समझाता है।

For purchase options, see [मूल्य जानकारी](https://purchase.aspose.com/pricing/slides/hi/family). For general licensing and purchasing questions, see [क्रय नीतियां और अक्सर पूछे जाने वाले प्रश्न](https://purchase.aspose.com/policies).

For evaluation limitations and how to request a temporary license, see [Aspose.Slides का मूल्यांकन करें](/slides/hi/python-java/evaluate-aspose-slides/). Apply a temporary license in the same way as a purchased license file.

{{% alert color="warning" title="चेतावनी" %}}
लाइसेंस फ़ाइल को संपादित न करें। अतिरिक्त लाइन ब्रेक भी उसकी डिजिटल सिग्नेचर को अमान्य कर सकता है।
{{% /alert %}}

Apply the license once per application or process, before creating presentations or performing other Aspose.Slides operations. For a license file, use the [License](https://reference.aspose.com/slides/hi/python-java/aspose.slides/license/) class. Metered licensing uses a public and private key pair instead of a license file.

## **लाइसेंस लागू करना**

The following examples assume that Aspose.Slides for Python via Java and its prerequisites are installed. Each example is a standalone script that starts the JVM, imports the API, and applies a license. In your application, perform your presentation operations after applying the license and shut down the JVM only after all Aspose.Slides work is complete.

### **फ़ाइल से लाइसेंस लागू करना**

Pass the license file path to [License.setLicense](https://reference.aspose.com/slides/hi/python-java/aspose.slides/license/#setLicense). Replace `Aspose.Slides.lic` with the path to your license file.

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
        # यहाँ प्रस्तुति संचालन करें, JVM को बंद करने से पहले।
    else:
        print("License file not found. Set the path to your license file.")
finally:
    jpype.shutdownJVM()
```

Use the exact file name, including its extension. For example, if the file is named `Aspose.Slides.lic.xml`, include `.xml` in the path. An absolute path avoids ambiguity about the application's working directory.

The example uses [License.isLicensed](https://reference.aspose.com/slides/hi/python-java/aspose.slides/license/#isLicensed) to check whether the license has been applied.

### **बाइट्स से लाइसेंस लागू करना**

Use [License.setLicenseFromBytes](https://reference.aspose.com/slides/hi/python-java/aspose.slides/license/#setLicenseFromBytes) when the license is available as Python bytes. The following example reads the file in binary mode and closes it before applying the license.

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
        # यहाँ प्रस्तुति संचालन करें, JVM को बंद करने से पहले।
    else:
        print("License file not found. Set the path to your license file.")
finally:
    jpype.shutdownJVM()
```

Keep the original bytes unchanged. Do not decode, reformat, or otherwise modify the license content before applying it.

## **मीटर लाइसेंस लागू करना**

Metered licensing bills you according to API usage. After obtaining a metered license, apply its public and private keys with [Metered.setMeteredKey](https://reference.aspose.com/slides/hi/python-java/aspose.slides/metered/#setMeteredKey). Initialize the [Metered](https://reference.aspose.com/slides/hi/python-java/aspose.slides/metered/) object and apply the keys once at application startup.

The following example reads the keys from the `ASPOSE_METERED_PUBLIC_KEY` and `ASPOSE_METERED_PRIVATE_KEY` environment variables. Set both variables before running the script.

```python
import os

import jpype
import asposeslides

jpile.startJVM()

try:
    from asposeslides.api import Metered

    public_key = os.environ.get("ASPOSE_METERED_PUBLIC_KEY")
    private_key = os.environ.get("ASPOSE_METERED_PRIVATE_KEY")

    if public_key and private_key:
        metered = Metered()
        metered.setMeteredKey(public_key, private_key)
        # यहाँ प्रस्तुति संचालन करें, JVM को बंद करने से पहले।
    else:
        print("Set both metered licensing environment variables before running this example.")
finally:
    jpype.shutdownJVM()
```

{{% alert color="info" title="नोट" %}}
Metered licensing requires an Internet connection to validate the keys and report usage. Keep the private key out of source code and logs. See the [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered) for connectivity and billing details.
{{% /alert %}}

## **FAQ**

**क्या लाइसेंस खरीदने के बाद मुझे कोई अलग पैकेज स्थापित करना पड़ता है?**

नहीं। मूल्यांकन के लिए उपयोग किए गए वही पैकेज पर लाइसेंस लागू करें।

**क्या प्रत्येक प्रस्तुति के लिए लाइसेंस लागू करना आवश्यक है?**

नहीं। एप्लिकेशन स्टार्टअप के दौरान एक बार लागू करें, प्रस्तुति बनाने या लोड करने से पहले।

**क्या मैं लाइसेंस फ़ाइल का नाम बदल सकता हूँ?**

हाँ। कोड में नया फ़ाइल नाम ठीक उसी तरह प्रयोग करें और फ़ाइल की सामग्री अपरिवर्तित रखें।

**क्या मैं अस्थायी लाइसेंस को बाइट‑आधारित उदाहरण में उपयोग कर सकता हूँ?**

हाँ। अस्थायी लाइसेंस फ़ाइल को बाइट्स के रूप में पढ़ें और इसे उसी तरह लागू करें जैसा आप खरीदे हुए लाइसेंस को लागू करते हैं।