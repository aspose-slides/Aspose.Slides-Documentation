---
title: Python में प्रस्तुतियों को पासवर्ड-सेक्योर करें
linktitle: पासवर्ड सुरक्षा
type: docs
weight: 20
url: /hi/python-net/password-protected-presentation/
keywords:
- पासवर्ड-सेक्योर प्रस्तुति
- ओपनिंग पासवर्ड
- PowerPoint एन्क्रिप्ट करें
- PowerPoint डिक्रिप्ट करें
- प्रस्तुति पासवर्ड मान्य करें
- प्रस्तुति पासवर्ड जाँचें
- एन्क्रिप्टेड प्रस्तुति खोलें
- एन्क्रिप्शन हटाएँ
- PowerPoint
- PPT
- PPTX
- प्रस्तुति
- Python
- Aspose.Slides
description: Python में Aspose.Slides के साथ पासवर्ड-सेक्योर PowerPoint PPT और PPTX प्रस्तुतियों को एन्क्रिप्ट, पता लगाएँ, मान्य करें, खोलें और डिक्रिप्ट करें।
---
## **समीक्षा**

एक ओपनिंग पासवर्ड प्रस्तुति को एन्क्रिप्ट करता है। सामग्री को लोड करने और देखने के लिए सही पासवर्ड आवश्यक होता है, इस प्रकार यह सुरक्षा गोपनीयता प्रदान करती है।

ओपनिंग पासवर्ड लिखने-से-सुरक्षित पासवर्ड से अलग होता है। लिखने की सुरक्षा संशोधन को प्रतिबंधित करती है लेकिन सामग्री को एन्क्रिप्ट नहीं करती या प्रस्तुति को लोड होने से नहीं रोकती। प्रस्तुतियों को संशोधित करने के लिए पासवर्ड प्रबंधन के बारे में जानकारी के लिए देखें [Write-Protect Presentations](/slides/hi/python-net/write-protected-presentation/)।

नीचे दिए गए वर्कफ़्लो PPT और PPTX दोनों प्रस्तुतियों पर लागू होते हैं। उदाहरण दोनों फ़ॉर्मेट का उपयोग करते हैं जहाँ फ़ाइल-आधारित और स्ट्रीम-आधारित व्यवहार महत्वपूर्ण होता है।

## **एक ओपनिंग पासवर्ड के साथ प्रस्तुति एन्क्रिप्ट करें**

एक ओपनिंग पासवर्ड असाइन करने के लिए [ProtectionManager.encrypt](https://reference.aspose.com/slides/hi/python-net/aspose.slides/protectionmanager/encrypt/) का प्रयोग करें। फिर एन्क्रिप्टेड प्रस्तुति को सहेजने के लिए [Presentation.save](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/save/) का उपयोग करें।

निम्नलिखित उदाहरण PPTX प्रस्तुति को एन्क्रिप्ट करता है:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.protection_manager.encrypt("open_password")
    presentation.save("encrypted-pres.pptx", slides.export.SaveFormat.PPTX)
```

## **एन्क्रिप्टेड प्रस्तुति लोड करें**

[LoadOptions.password](https://reference.aspose.com/slides/hi/python-net/aspose.slides/loadoptions/password/) को ओपनिंग पासवर्ड पर सेट करें और फ़ाइल लोड करते समय विकल्पों को [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) को पास करें। जब ओपनिंग पासवर्ड आवश्यक हो लेकिन प्रदान किया गया पासवर्ड अनुपलब्ध या गलत हो, तो लोडिंग विफल हो जाती है।

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation("encrypted-pres.pptx", load_options) as presentation:
    # डिक्रिप्टेड प्रस्तुति के साथ काम करें।
    pass
```

## **प्रस्तुति से एन्क्रिप्शन हटाएँ**

प्रस्तुति को उसके ओपनिंग पासवर्ड के साथ लोड करें, फिर [ProtectionManager.remove_encryption](https://reference.aspose.com/slides/hi/python-net/aspose.slides/protectionmanager/remove_encryption/) को कॉल करें और परिणाम को सहेजें। सहेजी गई प्रस्तुति अब बिना पासवर्ड के लोड की जा सकती है।

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation("encrypted-pres.pptx", load_options) as presentation:
    presentation.protection_manager.remove_encryption()
    presentation.save("encryption-removed.pptx", slides.export.SaveFormat.PPTX)
```

## **लोड करने से पहले ओपनिंग पासवर्ड की वैधता जांचें**

एक पूर्ण प्रस्तुति इंस्टेंस बनाये बिना [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentationfactory/get_presentation_info/) का उपयोग करके [PresentationInfo](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentationinfo/) प्राप्त करें। पासवर्ड का अनुरोध या वैधता जांचने से पहले [PresentationInfo.is_password_protected](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentationinfo/is_password_protected/) जांचें। जब सुरक्षा मौजूद हो, तो प्रदान किए गए मान को [PresentationInfo.check_password](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentationinfo/check_password/) से वैध करें।

### **फ़ाइल-मार्ग वर्कफ़्लो**

निम्नलिखित उदाहरण PPTX फ़ाइल के लिए ओपनिंग पासवर्ड को वैध करता है, वैध मान को [LoadOptions.password](https://reference.aspose.com/slides/hi/python-net/aspose.slides/loadoptions/password/) को पास करता है, और फिर पूर्ण प्रस्तुति लोड करता है:

```python
import aspose.slides as slides

file_path = "protected-presentation.pptx"
password = "open_password"
presentation_info = slides.PresentationFactory.instance.get_presentation_info(file_path)

if not presentation_info.is_password_protected:
    print("The presentation does not have an opening password.")
elif not presentation_info.check_password(password):
    print("The opening password is incorrect.")
else:
    load_options = slides.LoadOptions()
    load_options.password = password

    with slides.Presentation(file_path, load_options) as presentation:
        print("The presentation was validated and loaded successfully.")
```

### **स्ट्रीम वर्कफ़्लो**

[PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentationfactory/get_presentation_info/) का स्ट्रीम ओवरलोड समान वर्कफ़्लो प्रदान करता है। पूर्ण प्रस्तुति को उस स्ट्रीम से लोड करने से पहले एक seekable स्ट्रीम की पोज़िशन रीसेट करें।

निम्नलिखित उदाहरण PPT फ़ाइल का उपयोग करता है:

```python
import aspose.slides as slides

password = "open_password"

with open("protected-presentation.ppt", "rb") as presentation_stream:
    presentation_info = slides.PresentationFactory.instance.get_presentation_info(presentation_stream)

    if not presentation_info.is_password_protected:
        print("The presentation does not have an opening password.")
    elif not presentation_info.check_password(password):
        print("The opening password is incorrect.")
    else:
        presentation_stream.seek(0)
        load_options = slides.LoadOptions()
        load_options.password = password

        with slides.Presentation(presentation_stream, load_options) as presentation:
            print("The presentation was validated and loaded successfully.")
```

### **CheckPassword वापसी मान**

[PresentationInfo.check_password](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentationinfo/check_password/) केवल तब `True` लौटाता है जब प्रस्तुति में ओपनिंग पासवर्ड हो और प्रदान किया गया पासवर्ड सही हो। यह प्रत्येक निम्न मामलों में `False` लौटाता है:

- पासवर्ड गलत है।
- प्रस्तुति में ओपनिंग पासवर्ड नहीं है।
- प्रदान किया गया पासवर्ड `None` या खाली है।

यह व्यवहार PPT और PPTX दोनों प्रस्तुतियों के लिए समान है।

## **जाँचें कि लोड की गई प्रस्तुति एन्क्रिप्टेड है या नहीं**

सही पासवर्ड के साथ प्रस्तुति लोड करने के बाद, यह पुष्टि करने के लिए [ProtectionManager.is_encrypted](https://reference.aspose.com/slides/hi/python-net/aspose.slides/protectionmanager/is_encrypted/) को निरीक्षण करें कि मूल प्रस्तुति एन्क्रिप्टेड थी। लोड करने से पहले ओपनिंग-पासवर्ड संरक्षण का पता लगाने के लिए ऊपर दिखाए अनुसार `PresentationInfo.is_password_protected` का उपयोग करें।

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation("encrypted-pres.pptx", load_options) as presentation:
    is_encrypted = presentation.protection_manager.is_encrypted
    print("The presentation is encrypted: " + str(is_encrypted))
```

## **सुरक्षा अनुशंसाएँ**

{{% alert color="warning" title="Security" %}}
ओपनिंग पासवर्ड को लॉग न करें या उन्हें निदान संदेशों में शामिल न करें। अनावश्यक पुनरावृत्ति वाले वैधता प्रयासों से बचें, पासवर्ड को मेमोरी में केवल आवश्यक अवधि तक रखें, और प्रस्तुति को तुरंत लोड करते समय सफल वैधता परिणाम को पुनः उपयोग करें।
{{% /alert %}}

## **ऑनलाइन प्रस्तुति को पासवर्ड-सेक्योर करें**

1. [Aspose.Slides Lock](https://products.aspose.app/slides/hi/lock) एप्लिकेशन खोलें।
2. प्रस्तुति चुनें या अपलोड करें।
3. देखने की सुरक्षा के लिए पासवर्ड दर्ज करें।
4. वैकल्पिक रूप से संपादन सुरक्षा के लिए एक अलग पासवर्ड दर्ज करें।
5. सुरक्षा लागू करें और परिणामी फ़ाइल को डाउनलोड करें।

{{% alert color="info" title="See also" %}}
- [प्रस्तुति लिखने-से-सुरक्षित करें](/slides/hi/python-net/write-protected-presentation/)
- [PowerPoint में डिजिटल सिग्नेचर](/slides/hi/python-net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**एक ओपनिंग पासवर्ड और लिखने-से-सुरक्षित पासवर्ड में क्या अंतर है?**

एक ओपनिंग पासवर्ड प्रस्तुति को एन्क्रिप्ट करता है और इसकी सामग्री को लोड करने के लिए आवश्यक होता है। लिखने-से-सुरक्षित पासवर्ड सामग्री को एन्क्रिप्ट किए बिना संशोधन को प्रतिबंधित करता है।

**क्या मैं सभी स्लाइड्स लोड किए बिना ओपनिंग पासवर्ड की वैधता जांच सकता हूँ?**

हाँ। प्रस्तुति की जानकारी प्राप्त करें, देखें कि ओपनिंग पासवर्ड सुरक्षा मौजूद है या नहीं, और पूर्ण प्रस्तुति इंस्टेंस बनाये बिना पासवर्ड को वैध करें।

**क्या पासवर्ड‑जांच वर्कफ़्लो PPT और PPTX दोनों को समर्थन देते हैं?**

हाँ। फ़ाइल‑मार्ग और स्ट्रीम‑आधारित पासवर्ड डिटेक्शन और वैधता दोनों PPT और PPTX प्रस्तुतियों के लिए समान रूप से कार्य करती है।