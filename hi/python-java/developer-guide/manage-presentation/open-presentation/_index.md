---
title: Python के माध्यम से Java में प्रस्तुतियों को खोलें
linktitle: प्रस्तुति खोलें
type: docs
weight: 20
url: /hi/python-java/open-presentation/
keywords:
- PowerPoint खोलें
- प्रस्तुति खोलें
- PPTX खोलें
- PPT खोलें
- ODP खोलें
- प्रस्तुति लोड करें
- PPTX लोड करें
- PPT लोड करें
- ODP लोड करें
- संरक्षित प्रस्तुति
- बड़ी प्रस्तुति
- बाहरी संसाधन
- बाइनरी ऑब्जेक्ट
- Python
- Java
- Aspose.Slides
description: "Python के माध्यम से Java में PowerPoint और OpenDocument प्रस्तुतियों को कैसे खोलें, खोलने के पासवर्ड प्रदान करें, संसाधन लोडिंग को नियंत्रित करें, और Aspose.Slides for Python via Java के साथ मेमोरी उपयोग को कम करें, यह सीखें।"
---
## **परिचय**

[Aspose.Slides for Python via Java](https://products.aspose.com/slides/hi/python-java/) फ़ाइलों और स्ट्रीमों से PowerPoint और OpenDocument प्रस्तुतियों को लोड कर सकता है। एक बार प्रस्तुति लोड हो जाने के बाद, आप इसकी संरचना की जांच कर सकते हैं, स्लाइड्स को संपादित कर सकते हैं, संसाधनों का प्रबंधन कर सकते हैं, और इसे मूल या किसी अन्य समर्थित फॉर्मेट में सहेज सकते हैं।

लोडिंग व्यवहार को [LoadOptions](https://reference.aspose.com/slides/hi/python-java/aspose.slides/loadoptions/) क्लास के माध्यम से अनुकूलित किया जा सकता है। उदाहरण के लिए, आप एक खोलने वाला पासवर्ड प्रदान कर सकते हैं, बड़े बाइनरी ऑब्जेक्ट्स को Java हीप मेमोरी से बाहर रख सकते हैं, बाहरी संसाधनों को नियंत्रित कर सकते हैं, या एम्बेडेड बाइनरी डेटा को छोड़ सकते हैं।

## **प्रस्तुतियों को खोलें**

एक मौजूदा प्रस्तुति खोलने के लिए, उसके फ़ाइल पथ को [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) कन्स्ट्रक्टर में पास करें। उपयोग के बाद प्रस्तुति को डिस्पोज़ करें ताकि फ़ाइल हैंडल, अस्थायी डेटा और अन्य संसाधन तुरंत रिलीज़ हो जाएँ।

निम्नलिखित Python उदाहरण दिखाता है कि कैसे प्रस्तुति खोलें और उसकी स्लाइड गिनती प्राप्त करें:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("sample.pptx")
try:
    print("Slide count:", presentation.getSlides().size())
finally:
    presentation.dispose()
```

## **पासवर्ड-प्रोटेक्टेड प्रस्तुतियों को खोलें**

एक खोलने वाला पासवर्ड प्रस्तुति सामग्री को एन्क्रिप्ट करता है। पूरी प्रस्तुति लोड करने के लिए, सही पासवर्ड को [LoadOptions.setPassword](https://reference.aspose.com/slides/hi/python-java/aspose.slides/loadoptions/#setPassword) में पास करें और विकल्पों को [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) कन्स्ट्रक्टर को प्रदान करें। पासवर्ड अनुपलब्ध या गलत होने पर लोडिंग विफल हो जाती है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation

load_options = LoadOptions()
load_options.setPassword("open_password")

presentation = Presentation("encrypted-presentation.pptx", load_options)
try:
    print("Slide count:", presentation.getSlides().size())
finally:
    presentation.dispose()
```

पासवर्ड पहचान, सत्यापन और एन्क्रिप्शन वर्कफ़्लो के लिए देखें [Password-Protect Presentations](/slides/hi/python-java/password-protected-presentation/). यदि एन्क्रिप्टेड प्रस्तुति को जानबूझकर सार्वजनिक दस्तावेज़ गुणों के साथ सहेजा गया है, तो उन गुणों को पासवर्ड के बिना पढ़ा जा सकता है; देखें [Manage Presentation Properties](/slides/hi/python-java/presentation-properties/)।

## **बड़ी प्रस्तुतियों को खोलें**

[LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/hi/python-java/aspose.slides/loadoptions/#getBlobManagementOptions) विकल्प लौटाता है जो नियंत्रित करता है कि Aspose.Slides छवियों, ऑडियो और वीडियो जैसे बाइनरी बड़े ऑब्जेक्ट्स को कैसे संभालता है। आप स्रोत फ़ाइल को लॉक रख सकते हैं, अस्थायी फ़ाइलों की अनुमति दे सकते हैं, और मेमोरी में रखे जाने वाले BLOB डेटा की मात्रा को सीमित कर सकते हैं।

निम्नलिखित Python कोड एक बड़ी प्रस्तुति (उदाहरण के लिए 2 GB) को लोड करने का प्रदर्शन करता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, PresentationLockingBehavior, SaveFormat

file_path = "large-presentation.pptx"

load_options = LoadOptions()
load_options.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked)
load_options.getBlobManagementOptions().setTemporaryFilesAllowed(True)
load_options.getBlobManagementOptions().setMaxBlobsBytesInMemory(10 * 1024 * 1024)

presentation = Presentation(file_path, load_options)
try:
    presentation.getSlides().get_Item(0).setName("Large presentation")
    presentation.save("large-presentation-copy.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
[PresentationLockingBehavior.KeepLocked](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentationlockingbehavior/#KeepLocked) के साथ, स्रोत फ़ाइल तब तक लॉक रहती है जब तक प्रस्तुति इंस्टेंस को डिस्पोज़ नहीं किया जाता। उस इंस्टेंस के सक्रिय रहने के दौरान स्रोत फ़ाइल को न स्थानांतरित करें, न अधिलेखित करें, न हटाएँ।

Aspose.Slides लोडिंग के दौरान इनपुट स्ट्रीम की सामग्री को कॉपी कर सकता है। बड़ी प्रस्तुतियों के लिए, फ़ाइल पथ आम तौर पर स्ट्रीम की तुलना में अधिक कुशल होता है। अतिरिक्त स्टोरेज और मेमोरी‑प्रबंधन विकल्पों के लिए देखें [Manage BLOBs](/slides/hi/python-java/manage-blob/)।
{{% /alert %}}

## **बाहरी संसाधनों को नियंत्रित करें**

[LoadOptions.setResourceLoadingCallback](https://reference.aspose.com/slides/hi/python-java/aspose.slides/loadoptions/#setResourceLoadingCallback) एक JPype प्रॉक्सी स्वीकार करता है जो Java संसाधन‑लोडिंग कॉलबैक इंटरफ़ेस को लागू करता है। इस कॉलबैक से प्रतिस्थापन डेटा प्रदान किया जा सकता है, किसी संसाधन को पुनःनिर्देशित किया जा सकता है, डिफ़ॉल्ट लोडर का उपयोग किया जा सकता है, या संसाधन को छोड़ दिया जा सकता है। यह तब उपयोगी है जब प्रस्तुतियों में बाहरी छवियां होती हैं जिन्हें एप्लिकेशन‑विशिष्ट सुरक्षा या स्टोरेज नियमों के अनुसार हल करना आवश्यक होता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import LoadOptions, Presentation, ResourceLoadingAction

class ImageLoadingHandler:
    def resourceLoading(self, resource_loading_arguments):
        is_jpeg = str(resource_loading_arguments.getOriginalUri()).lower().endswith(".jpg")
        approved_image_path = Path("approved-image.jpg")
        if not is_jpeg or not approved_image_path.exists():
            return ResourceLoadingAction.Skip

        try:
            image_data = approved_image_path.read_bytes()
            java_image_data = jpype.JArray(jpype.JByte)(image_data)
            resource_loading_arguments.setData(java_image_data)
            return ResourceLoadingAction.UserProvided
        except OSError:
            print("The approved replacement image could not be read.")
            return ResourceLoadingAction.Skip

load_options = LoadOptions()
image_loading_handler = ImageLoadingHandler()
callback = jpype.JProxy("com.aspose.slides.IResourceLoadingCallback", inst=image_loading_handler)
load_options.setResourceLoadingCallback(callback)

presentation = Presentation("presentation-with-external-images.pptx", load_options)
try:
    print("Slide count:", presentation.getSlides().size())
finally:
    presentation.dispose()
```

## **एम्बेडेड बाइनरी ऑब्जेक्ट्स के बिना प्रस्तुतियों को लोड करें**

एक प्रस्तुति में एम्बेडेड बाइनरी डेटा हो सकता है जिसकी एप्लिकेशन को आवश्यकता नहीं है या वह उसे रखना नहीं चाहती। उदाहरण शामिल हैं:

- VBA प्रोजेक्ट्स, जो [Presentation.getVbaProject](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#getVbaProject) के माध्यम से उपलब्ध हैं;
- एम्बेडेड OLE डेटा, जो [OleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/hi/python-java/aspose.slides/oleembeddeddatainfo/#getEmbeddedFileData) के माध्यम से उपलब्ध है;
- ActiveX नियंत्रण डेटा, जो [Control.getActiveXControlBinary](https://reference.aspose.com/slides/hi/python-java/aspose.slides/control/#getActiveXControlBinary) के माध्यम से उपलब्ध है।

लोड करते समय इस बाइनरी डेटा को हटाने के लिए [LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/hi/python-java/aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects) को `True` सेट करें। साफ़ किए गए परिणाम को बनाए रखने के लिए लोड की गई प्रस्तुति को सहेजें।

यह विकल्प अनपेक्षित एम्बेडेड पेलोड्स के जोखिम को कम करता है, लेकिन यह पूर्ण मालवेयर‑डिटेक्शन या कंटेंट‑सैनिटाइज़ेशन प्रणाली नहीं है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, SaveFormat

load_options = LoadOptions()
load_options.setDeleteEmbeddedBinaryObjects(True)

presentation = Presentation("presentation-with-embedded-data.pptx", load_options)
try:
    presentation.save("presentation-without-embedded-data.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं कैसे पता कर सकता हूँ कि फ़ाइल भ्रष्ट है और नहीं खोली जा सकती?**  
Aspose.Slides लोडिंग के दौरान पैरसिंग या फॉर्मेट अपवाद फेंकता है। इस विफलता को गलत‑पासवर्ड त्रुटि से अलग तरीके से संभालें ताकि एप्लिकेशन सटीक कारण रिपोर्ट कर सके।

**यदि आवश्यक फ़ॉन्ट गायब हैं तो क्या होता है?**  
प्रस्तुति अभी भी लोड हो सकती है, लेकिन रेंडरिंग और निर्यात फ़ॉन्ट को प्रतिस्थापित कर सकते हैं। आउटपुट को अधिक पूर्वानुमेय बनाने के लिए आप [फ़ॉन्ट प्रतिस्थापन को कॉन्फ़िगर](/slides/hi/python-java/font-substitution/) कर सकते हैं या [कस्टम फ़ॉन्ट प्रदान](/slides/hi/python-java/custom-font/) कर सकते हैं।

**क्या प्रस्तुति को लोड करने से उसके एम्बेडेड मीडिया भी लोड हो जाते हैं?**  
एम्बेडेड ऑडियो और वीडियो प्रस्तुति ऑब्जेक्ट मॉडल के माध्यम से उपलब्ध हो जाते हैं। बाहरी संसाधन कॉन्फ़िगर किए गए संसाधन‑लोडिंग व्यवहार के अनुसार हल होते हैं और यदि उनके स्थान तक पहुंच नहीं है तो उपलब्ध नहीं हो सकते।