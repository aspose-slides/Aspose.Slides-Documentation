---
title: Python में प्रस्तुतियों को पासवर्ड‑सुरक्षित बनाना
linktitle: पासवर्ड सुरक्षा
type: docs
weight: 20
url: /hi/python-net/password-protected-presentation/
keywords:
- पासवर्ड‑सुरक्षित प्रस्तुति
- ओपनिंग पासवर्ड
- PowerPoint को एन्क्रिप्ट करें
- PowerPoint को डिक्रिप्ट करें
- प्रेज़ेंटेशन पासवर्ड सत्यापित करें
- प्रेज़ेंटेशन पासवर्ड जाँचें
- एन्क्रिप्टेड प्रस्तुति खोलें
- एन्क्रिप्शन हटाएँ
- PowerPoint
- PPT
- PPTX
- प्रेज़ेंटेशन
- Python
- Aspose.Slides
description: "Python में Aspose.Slides के साथ पासवर्ड‑सुरक्षित PowerPoint PPT और PPTX प्रस्तुतियों को एन्क्रिप्ट, पहचान, सत्यापित, खोल और डिक्रिप्ट करें।"
---
## **अवलोकन**

एक ओपनिंग पासवर्ड प्रस्तुति को एन्क्रिप्ट करता है। सही पासवर्ड आवश्यक होता है प्रस्तुति की सामग्री को लोड और देखने के लिए, इसलिए यह सुरक्षा गोपनीयता प्रदान करती है।

एक ओपनिंग पासवर्ड लिखित-रक्षा पासवर्ड से अलग होता है। लिखित सुरक्षा संशोधन को प्रतिबंधित करती है लेकिन सामग्री को एन्क्रिप्ट नहीं करती या प्रस्तुति को लोड होने से नहीं रोकती। प्रस्तुति को संशोधित करने के पासवर्ड प्रबंधन के लिए, देखें [प्रेज़ेंटेशन को लिखित-रक्षा देना](/slides/hi/python-net/write-protected-presentation/)।

नीचे दिए गए कार्यप्रवाह दोनों PPT और PPTX प्रस्तुतियों पर लागू होते हैं। उदाहरण दोनों स्वरूपों का उपयोग करते हैं जहाँ उनकी फ़ाइल-आधारित और स्ट्रीम-आधारित व्यवहार महत्वपूर्ण है।

## **ओपनिंग पासवर्ड के साथ प्रस्तुति को एन्क्रिप्ट करें**

एक ओपनिंग पासवर्ड असाइन करने के लिए [ProtectionManager.encrypt](https://reference.aspose.com/slides/hi/python-net/aspose.slides/protectionmanager/encrypt/) का उपयोग करें। फिर एन्क्रिप्टेड प्रस्तुति को सहेजने के लिए [Presentation.save](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/save/) का उपयोग करें।

निम्न उदाहरण PPTX प्रस्तुति को एन्क्रिप्ट करता है:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.protection_manager.encrypt("open_password")
    presentation.save("encrypted-pres.pptx", slides.export.SaveFormat.PPTX)
```

## **डॉक्यूमेंट प्रॉपर्टीज़ को सार्वजनिक रखें**

डिफ़ॉल्ट रूप से, Aspose.Slides प्रस्तुति एन्क्रिप्शन में दस्तावेज़ प्रॉपर्टीज़ शामिल करता है। यह व्यवहार [ProtectionManager.encrypt_document_properties](https://reference.aspose.com/slides/hi/python-net/aspose.slides/protectionmanager/encrypt_document_properties/) प्रॉपर्टी द्वारा स्लाइड-समग्री एन्क्रिप्शन से स्वतंत्र रूप से नियंत्रित होता है। जब कोई इंडेक्सिंग, वर्गीकरण, खोज, या दस्तावेज़‑प्रबंधन प्रणाली को ओपनिंग पासवर्ड के बिना मेटाडेटा पढ़ना आवश्यक हो, तो [ProtectionManager.encrypt](https://reference.aspose.com/slides/hi/python-net/aspose.slides/protectionmanager/encrypt/) को कॉल करने से पहले इसे `False` सेट करें।

निम्न उदाहरण एक एन्क्रिप्टेड PPTX प्रस्तुति बनाता है जबकि इसकी अंतर्निहित दस्तावेज़ प्रॉपर्टीज़ को सार्वजनिक रखता है:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    properties = presentation.document_properties
    properties.author = "Contoso Knowledge Management"
    properties.title = "Quarterly Product Roadmap"
    properties.keywords = "roadmap, planning, internal"

    presentation.slides[0].name = "Encrypted presentation content"
    presentation.protection_manager.encrypt_document_properties = False
    presentation.protection_manager.encrypt("open_password")
    presentation.save("public-properties-encrypted.pptx", slides.export.SaveFormat.PPTX)
```

`encrypt_document_properties` को `False` सेट करने से स्लाइड्स, मास्टर्स, लेआउट्स, शैप्स, मीडिया या अन्य प्रस्तुति सामग्री सार्वजनिक नहीं बनती। यह केवल दस्तावेज़ प्रॉपर्टीज़ को प्रभावित करता है। एन्क्रिप्टेड सामग्री लोड किए बिना इन प्रॉपर्टीज़ को पढ़ने के लिए, देखें [प्रेज़ेंटेशन प्रॉपर्टीज़ प्रबंधित करें](/slides/hi/python-net/presentation-properties/)।

## **एन्क्रिप्टेड प्रस्तुति लोड करें**

फ़ाइल लोड करते समय ओपनिंग पासवर्ड के लिए [LoadOptions.password](https://reference.aspose.com/slides/hi/python-net/aspose.slides/loadoptions/password/) सेट करें और विकल्पों को [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) को पास करें। यदि ओपनिंग पासवर्ड आवश्यक है लेकिन दिया गया पासवर्ड गायब या गलत है, तो लोडिंग विफल हो जाएगी।

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation("encrypted-pres.pptx", load_options) as presentation:
    # डिक्रिप्टेड प्रस्तुति के साथ काम करें।
    pass
```

## **प्रेज़ेंटेशन से एन्क्रिप्शन हटाएँ**

प्रेज़ेंटेशन को उसके ओपनिंग पासवर्ड के साथ लोड करें, फिर [ProtectionManager.remove_encryption](https://reference.aspose.com/slides/hi/python-net/aspose.slides/protectionmanager/remove_encryption/) को कॉल करें और परिणाम को सहेजें। सहेजी गई प्रस्तुति को अब पासवर्ड के बिना लोड किया जा सकता है।

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation("encrypted-pres.pptx", load_options) as presentation:
    presentation.protection_manager.remove_encryption()
    presentation.save("encryption-removed.pptx", slides.export.SaveFormat.PPTX)
```

## **लोड करने से पहले ओपनिंग पासवर्ड की वैधता जाँचें**

एक पूरी प्रस्तुति इंस्टेंस बनाए बिना [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentationfactory/get_presentation_info/) का उपयोग करके [PresentationInfo](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentationinfo/) प्राप्त करें। पासवर्ड का अनुरोध या वैधता करने से पहले [PresentationInfo.is_password_protected](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentationinfo/is_password_protected/) की जाँच करें। जब सुरक्षा मौजूद हो, तो दिए गए मान को [PresentationInfo.check_password](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentationinfo/check_password/) के साथ मान्य करें।

### **फ़ाइल‑पाथ कार्यप्रवाह**

निम्न उदाहरण PPTX फ़ाइल के लिए ओपनिंग पासवर्ड को मान्य करता है, मान्य मान को [LoadOptions.password](https://reference.aspose.com/slides/hi/python-net/aspose.slides/loadoptions/password/) को पास करता है, और फिर पूरी प्रस्तुति को लोड करता है:

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

### **स्ट्रीम कार्यप्रवाह**

[PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentationfactory/get_presentation_info/) का स्ट्रीम ओवरलोड वही कार्यप्रवाह प्रदान करता है। उस स्ट्रीम से पूरी प्रस्तुति लोड करने से पहले एक seekable स्ट्रीम की पोज़ीशन रीसेट करें।

निम्न उदाहरण PPT फ़ाइल का उपयोग करता है:

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

### **CheckPassword रिटर्न वैल्यूज़**

[PresentationInfo.check_password](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentationinfo/check_password/) केवल तभी `True` लौटाता है जब प्रस्तुति में ओपनिंग पासवर्ड हो और दिया गया पासवर्ड सही हो। यह प्रत्येक निम्न मामलों में `False` लौटाता है:

- पासवर्ड गलत है।
- प्रस्तुति में ओपनिंग पासवर्ड नहीं है।
- दिया गया पासवर्ड `None` या खाली है।

यह व्यवहार PPT और PPTX प्रस्तुतियों के लिए समान है।

## **जांचें कि लोड की गई प्रस्तुति एन्क्रिप्टेड है या नहीं**

सही पासवर्ड के साथ प्रस्तुति को लोड करने के बाद, स्रोत प्रस्तुति एन्क्रिप्टेड थी यह पुष्टि करने के लिए [ProtectionManager.is_encrypted](https://reference.aspose.com/slides/hi/python-net/aspose.slides/protectionmanager/is_encrypted/) को जांचें। लोड करने से पहले ओपनिंग‑पासवर्ड सुरक्षा का पता लगाने के लिए, ऊपर दिखाए अनुसार `PresentationInfo.is_password_protected` का उपयोग करें।

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation("encrypted-pres.pptx", load_options) as presentation:
    is_encrypted = presentation.protection_manager.is_encrypted
    print("The presentation is encrypted: " + str(is_encrypted))
```

## **सुरक्षा अनुशंसाएँ**

{{% alert color="warning" title="सुरक्षा" %}}
ओपनिंग पासवर्ड को लॉग न करें या उन्हें डायग्नोस्टिक संदेशों में शामिल न करें। अनावश्यक दोहराए गए वैधता प्रयासों से बचें, पासवर्ड को मेमोरी में केवल आवश्यक समय तक रखें, और प्रस्तुति को तुरंत लोड करते समय सफल वैधता परिणाम को पुनः उपयोग करें।

सार्वजनिक दस्तावेज़ प्रॉपर्टीज़ लेखक नाम, शीर्षक, विषय, कीवर्ड, कंपनी जानकारी, टिप्पणी और कस्टम मान प्रकट कर सकती हैं जबकि प्रस्तुति सामग्री एन्क्रिप्टेड होती है। संवेदनशील मेटाडेटा को प्रस्तुति के साथ एन्क्रिप्ट करें। प्रॉपर्टीज़ को सार्वजनिक छोड़ना केवल तभी स्पष्ट निर्णय होना चाहिए जब सिस्टम को ओपनिंग पासवर्ड के बिना फ़ाइल को इंडेक्स, वर्गीकृत, खोज या प्रबंधित करना आवश्यक हो।
{{% /alert %}}

## **ऑनलाइन प्रस्तुति को पासवर्ड‑सुरक्षित करें**

1. [Aspose.Slides Lock](https://products.aspose.app/slides/hi/lock) एप्लिकेशन खोलें।
2. प्रेज़ेंटेशन चुनें या अपलोड करें।
3. देखने की सुरक्षा के लिए पासवर्ड दर्ज करें।
4. वैकल्पिक रूप से संपादन सुरक्षा के लिए अलग पासवर्ड दर्ज करें।
5. सुरक्षा लागू करें और परिणामी फ़ाइल डाउनलोड करें।

{{% alert color="info" title="और देखें" %}}
- [प्रेज़ेंटेशन को लिखित-रक्षा देना](/slides/hi/python-net/write-protected-presentation/)
- [PowerPoint में डिजिटल सिग्नेचर](/slides/hi/python-net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**ओपनिंग पासवर्ड और लिखित-रक्षा पासवर्ड में क्या अंतर है?**

एक ओपनिंग पासवर्ड प्रस्तुति को एन्क्रिप्ट करता है और उसकी सामग्री को लोड करने के लिए आवश्यक होता है। लिखित-रक्षा पासवर्ड संशोधन को सीमित करता है बिना सामग्री को एन्क्रिप्ट किए।

**क्या मैं सभी स्लाइड्स लोड किए बिना ओपनिंग पासवर्ड की वैधता जाँच सकता हूँ?**

हां। प्रस्तुति जानकारी प्राप्त करें, जांचें कि ओपनिंग‑पासवर्ड सुरक्षा मौजूद है या नहीं, और पूरी प्रस्तुति इंस्टेंस बनाने से पहले पासवर्ड की वैधता करें।

**क्या कोई एप्लिकेशन ओपनिंग पासवर्ड के बिना मेटाडेटा पढ़ सकता है?**

हां, लेकिन केवल तब जब प्रस्तुति को `encrypt_document_properties` को `False` पर सेट करके एन्क्रिप्ट किया गया हो। तब एप्लिकेशन को [प्रेज़ेंटेशन प्रॉपर्टीज़ प्रबंधित करें](/slides/hi/python-net/presentation-properties/) में वर्णित दस्तावेज़‑प्रॉपर्टी‑केवल लोडिंग मोड का उपयोग करना होगा।

**क्या पासवर्ड‑जाँच कार्यप्रवाह PPT और PPTX दोनों का समर्थन करते हैं?**

हां। फ़ाइल‑पाथ और स्ट्रीम‑आधारित पासवर्ड डिटेक्शन और वैधता दोनों PPT और PPTX प्रस्तुतियों के लिए समान रूप से कार्य करती हैं।