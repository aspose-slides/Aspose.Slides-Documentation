---
title: Python में प्रस्तुतियों को पासवर्ड‑सुरक्षित बनाना
linktitle: पासवर्ड सुरक्षा
type: docs
weight: 20
url: /hi/python-java/password-protected-presentation/
keywords:
- पासवर्ड‑सुरक्षित प्रस्तुति
- खोलने वाला पासवर्ड
- PowerPoint एन्क्रिप्ट करें
- PowerPoint डिक्रिप्ट करें
- प्रस्तुति पासवर्ड को मान्य करें
- प्रस्तुति पासवर्ड जाँचें
- एन्क्रिप्टेड प्रस्तुति खोलें
- एन्क्रिप्शन हटाएँ
- PowerPoint
- PPT
- PPTX
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via Java के साथ पासवर्ड‑सुरक्षित PowerPoint PPT और PPTX प्रस्तुतियों को एन्क्रिप्ट, पता लगाएँ, मान्य करें, खोलें और डिक्रिप्ट करें।"
---
## **अवलोकन**

एक खोलने वाला पासवर्ड प्रस्तुति को एन्क्रिप्ट करता है। सही पासवर्ड आवश्यक है प्रस्तुति सामग्री को लोड और देख पाने के लिए, इसलिए यह सुरक्षा गोपनीयता प्रदान करती है।

एक खोलने वाला पासवर्ड लिखने‑रोकथाम पासवर्ड से अलग है। लिखने‑रोकथाम संशोधन को सीमित करता है लेकिन सामग्री को एन्क्रिप्ट नहीं करता या प्रस्तुति को लोड होने से नहीं रोकता। प्रस्तुतियों को संशोधित करने के पासवर्ड प्रबंधित करने के लिए, देखें [Write-Protect Presentations](/slides/hi/python-java/write-protected-presentation/)।

नीचे दिया गया कार्य‑प्रवाह दोनों PPT और PPTX प्रस्तुतियों पर लागू होते हैं। उदाहरण दोनों स्वरूपों का उपयोग करते हैं जहाँ फ़ाइल‑आधारित और स्ट्रीम‑आधारित व्यवहार महत्वपूर्ण है।

## **एक खोलने वाले पासवर्ड के साथ प्रस्तुति एन्क्रिप्ट करें**

[ProtectionManager.encrypt] का उपयोग करके खोलने वाला पासवर्ड असाइन करें। फिर [Presentation.save] का उपयोग करके एन्क्रिप्टेड प्रस्तुति को सहेजें।

नीचे दिया गया उदाहरण PPTX प्रस्तुति को एन्क्रिप्ट करता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    presentation.getProtectionManager().encrypt("open_password")
    presentation.save("encrypted-pres.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **दस्तावेज़ गुण सार्वजनिक रखें**

डिफ़ॉल्ट रूप से, Aspose.Slides प्रस्तुति एन्क्रिप्शन में दस्तावेज़ गुण शामिल करता है। यह व्यवहार स्लाइड‑सामग्री एन्क्रिप्शन से स्वतंत्र रूप से नियंत्रित करने के लिए [ProtectionManager.setEncryptDocumentProperties] मेथड उपयोग किया जाता है। जब कोई अनुक्रमण, वर्गीकरण, खोज या दस्तावेज़‑प्रबंधन प्रणाली पासवर्ड के बिना मेटा‑डेटा पढ़नी चाहती है, तो [ProtectionManager.encrypt] को कॉल करने से पहले `False` पास करें।

नीचे दिया गया उदाहरण दस्तावेज़ गुण सार्वजनिक रखते हुए एक एन्क्रिप्टेड PPTX प्रस्तुति बनाता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    properties = presentation.getDocumentProperties()
    properties.setAuthor("Contoso Knowledge Management")
    properties.setTitle("Quarterly Product Roadmap")
    properties.setKeywords("roadmap, planning, internal")

    presentation.getSlides().get_Item(0).setName("Encrypted presentation content")
    presentation.getProtectionManager().setEncryptDocumentProperties(False)
    presentation.getProtectionManager().encrypt("open_password")
    presentation.save("public-properties-encrypted.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

[ProtectionManager.setEncryptDocumentProperties] को `False` पास करने से स्लाइड, मास्टर, लेआउट, शैप, मीडिया या अन्य प्रस्तुति सामग्री सार्वजनिक नहीं होती। यह केवल दस्तावेज़ गुणों को प्रभावित करता है। उन गुणों को एन्क्रिप्टेड सामग्री लोड किए बिना पढ़ने के लिए, देखें [Manage Presentation Properties](/slides/hi/python-java/presentation-properties/)।

## **एन्क्रिप्टेड प्रस्तुति लोड करें**

[LoadOptions.setPassword] को खोलने वाले पासवर्ड पर सेट करें और फ़ाइल लोड करते समय विकल्प को [Presentation] को पास करें। जब खोलने वाला पासवर्ड आवश्यक है लेकिन पासवर्ड नहीं दिया गया या गलत है, तो लोडिंग विफल हो जाती है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation

load_options = LoadOptions()
load_options.setPassword("open_password")

presentation = Presentation("encrypted-pres.pptx", load_options)
try:
    # डिक्रिप्टेड प्रस्तुति के साथ काम करें.
    pass
finally:
    presentation.dispose()
```

## **एक प्रस्तुति से एन्क्रिप्शन हटाएं**

प्रस्तुति को उसके खोलने वाले पासवर्ड के साथ लोड करें, [ProtectionManager.removeEncryption] को कॉल करें, और परिणाम सहेजें। सहेजी गई प्रस्तुति अब बिना पासवर्ड के लोड की जा सकती है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, SaveFormat

load_options = LoadOptions()
load_options.setPassword("open_password")

presentation = Presentation("encrypted-pres.pptx", load_options)
try:
    presentation.getProtectionManager().removeEncryption()
    presentation.save("encryption-removed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **लोड करने से पहले खोलने वाले पासवर्ड की वैधता जांचें**

[PresentationFactory.getPresentationInfo] का उपयोग करके [PresentationInfo] प्राप्त करें बिना पूर्ण प्रस्तुति इंस्टेंस बनाए। पासवर्ड का अनुरोध या वैधता जांचने से पहले [PresentationInfo.isPasswordProtected] की जाँच करें। जब सुरक्षा मौजूद हो, तो प्रदान किए गए मान को [PresentationInfo.checkPassword] से वैध करें।

### **फ़ाइल‑पाथ कार्य‑प्रवाह**

नीचे दिया गया उदाहरण PPTX फ़ाइल के लिए खोलने वाले पासवर्ड की वैधता जांचता है, वैध मान को [LoadOptions.setPassword] को पास करता है, और फिर पूर्ण प्रस्तुति लोड करता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, PresentationFactory

file_path = "protected-presentation.pptx"
password = "open_password"
presentation_info = PresentationFactory.getInstance().getPresentationInfo(file_path)

if not presentation_info.isPasswordProtected():
    print("The presentation does not have an opening password.")
elif not presentation_info.checkPassword(password):
    print("The opening password is incorrect.")
else:
    load_options = LoadOptions()
    load_options.setPassword(password)

    presentation = Presentation(file_path, load_options)
    try:
        print("The presentation was validated and loaded successfully.")
    finally:
        presentation.dispose()
```

### **स्ट्रीम कार्य‑प्रवाह**

[PresentationFactory.getPresentationInfo] का स्ट्रीम ओवरलोड समान कार्य‑प्रवाह प्रदान करता है। पूर्ण प्रस्तुति को उस स्ट्रीम से लोड करने से पहले सीक‑एबल स्ट्रीम की पोजीशन रीसेट करें।

नीचे दिया गया उदाहरण PPT फ़ाइल का उपयोग करता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, PresentationFactory

FileInputStream = jpype.JClass("java.io.FileInputStream")

password = "open_password"

presentation_stream = FileInputStream("protected-presentation.ppt")
try:
    presentation_info = PresentationFactory.getInstance().getPresentationInfo(presentation_stream)

    if not presentation_info.isPasswordProtected():
        print("The presentation does not have an opening password.")
    elif not presentation_info.checkPassword(password):
        print("The opening password is incorrect.")
    else:
        presentation_stream.getChannel().position(0)

        load_options = LoadOptions()
        load_options.setPassword(password)

        presentation = Presentation(presentation_stream, load_options)
        try:
            print("The presentation was validated and loaded successfully.")
        finally:
            presentation.dispose()
finally:
    presentation_stream.close()
```

### **checkPassword लौटाने वाले मान**

[PresentationInfo.checkPassword] केवल तब `True` लौटाता है जब प्रस्तुति में खोलने वाला पासवर्ड हो और प्रदान किया गया पासवर्ड सही हो। यह प्रत्येक निम्नलिखित मामलों में `False` लौटाता है:

- पासवर्ड गलत है।
- प्रस्तुति में खोलने वाला पासवर्ड नहीं है।
- प्रदान किया गया पासवर्ड `None` या खाली है।

यह व्यवहार PPT और PPTX दोनों प्रस्तुतियों के लिए समान है।

## **लोड की गई प्रस्तुति एन्क्रिप्टेड है या नहीं जांचें**

सही पासवर्ड के साथ प्रस्तुति लोड करने के बाद, स्रोत प्रस्तुति एन्क्रिप्टेड थी या नहीं, यह पुष्टि करने के लिए [ProtectionManager.isEncrypted] देखें। लोड करने से पहले खोलने‑पासवर्ड सुरक्षा का पता लगाने के लिए, ऊपर दिखाए अनुसार [PresentationInfo.isPasswordProtected] का उपयोग करें।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation

load_options = LoadOptions()
load_options.setPassword("open_password")

presentation = Presentation("encrypted-pres.pptx", load_options)
try:
    is_encrypted = presentation.getProtectionManager().isEncrypted()
    print(f"The presentation is encrypted: {is_encrypted}")
finally:
    presentation.dispose()
```

## **सुरक्षा सिफ़ारिशें**

{{% alert color="warning" title="Security" %}}
खोलने वाले पासवर्ड को लॉग न करें या उन्हें डायग्नोस्टिक संदेशों में न शामिल करें। अनावश्यक दोहराए गए वैधता प्रयासों से बचें, पासवर्ड को केवल आवश्यक समय तक मेमोरी में रखें, और तुरंत प्रस्तुति लोड करते समय सफल वैधता परिणाम को पुनः उपयोग करें।

सार्वजनिक दस्तावेज़ गुण लेखक नाम, शीर्षक, विषय, कुंजी‑शब्द, कंपनी जानकारी, टिप्पणी और कस्टम मान प्रकट कर सकते हैं जबकि प्रस्तुति सामग्री एन्क्रिप्टेड है। संवेदनशील मेटा‑डेटा को प्रस्तुति के साथ एन्क्रिप्ट करें। गुणों को सार्वजनिक रखना केवल तभी स्पष्ट निर्णय होना चाहिए जब सिस्टम को फ़ाइल को इंडेक्स, वर्गीकृत, खोज या प्रबंधित करना हो बिना खोलने वाले पासवर्ड के।
{{% /alert %}}

## **ऑनलाइन प्रस्तुति को पासवर्ड‑प्रोटेक्ट करें**

1. [Aspose.Slides Lock] (https://products.aspose.app/slides/hi/lock) एप्लिकेशन खोलें।
2. प्रस्तुति चुनें या अपलोड करें।
3. दृश्य सुरक्षा के लिए पासवर्ड दर्ज करें।
4. वैकल्पिक रूप से संपादन सुरक्षा के लिए अलग पासवर्ड दर्ज करें।
5. सुरक्षा लागू करें और परिणामी फ़ाइल डाउनलोड करें।

{{% alert color="info" title="See also" %}}
- [Write-Protect Presentations](/slides/hi/python-java/write-protected-presentation/)
- [Digital Signature in PowerPoint](/slides/hi/python-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**एक खोलने वाला पासवर्ड और लिखने‑रोकथाम पासवर्ड में क्या अंतर है?**

एक खोलने वाला पासवर्ड प्रस्तुति को एन्क्रिप्ट करता है और उसकी सामग्री लोड करने के लिए आवश्यक है। लिखने‑रोकथाम पासवर्ड संशोधन को सीमित करता है बिना सामग्री को एन्क्रिप्ट किए।

**क्या मैं सभी स्लाइड लोड किए बिना खोलने वाले पासवर्ड की वैधता जांच सकता हूँ?**

हां। प्रस्तुति जानकारी प्राप्त करें, देखें कि खोलने‑पासवर्ड सुरक्षा मौजूद है या नहीं, और पूर्ण प्रस्तुति इंस्टेंस बनाने से पहले पासवर्ड वैध करें।

**क्या कोई एप्लिकेशन खोलने वाले पासवर्ड के बिना मेटा‑डेटा पढ़ सकता है?**

हां, लेकिन केवल तब जब दस्तावेज़‑गुण एन्क्रिप्शन बंद हो। तब एप्लिकेशन को [Manage Presentation Properties](/slides/hi/python-java/presentation-properties/) में वर्णित दस्तावेज़‑गुण‑केवल लोड मोड का उपयोग करना होगा।

**क्या पासवर्ड‑जांच कार्य‑प्रवाह PPT और PPTX दोनों को समर्थन देते हैं?**

हां। फ़ाइल‑पाथ और स्ट्रीम‑आधारित पासवर्ड डिटेक्शन एवं वैधता दोनों PPT और PPTX प्रस्तुतियों के लिए समान रूप से कार्य करती हैं।