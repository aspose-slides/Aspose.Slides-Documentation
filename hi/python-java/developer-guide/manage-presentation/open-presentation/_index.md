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
- सुरक्षित प्रस्तुति
- बड़ी प्रस्तुति
- बाहरी संसाधन
- बाइनरी ऑब्जेक्ट
- Python
- Java
- Aspose.Slides
description: "Python के माध्यम से Java में PowerPoint और OpenDocument प्रस्तुतियों को कैसे खोलें, खोलने के पासवर्ड प्रदान करना, संसाधन लोडिंग को नियंत्रित करना, और Aspose.Slides for Python via Java के साथ मेमोरी उपयोग को कम करना सीखें।"
---
## **परिचय**

[Aspose.Slides for Python via Java](https://products.aspose.com/slides/hi/python-java/) फाइलों और स्ट्रीम्स से PowerPoint और OpenDocument प्रस्तुतियों को लोड कर सकता है। प्रस्तुति लोड होने के बाद, आप उसकी संरचना का निरीक्षण कर सकते हैं, स्लाइड्स को संपादित कर सकते हैं, संसाधनों का प्रबंधन कर सकते हैं, और इसे मूल या किसी अन्य समर्थित प्रारूप में सहेज सकते हैं।

लोडिंग व्यवहार को [LoadOptions](https://reference.aspose.com/slides/hi/python-java/aspose.slides/loadoptions/) क्लास के माध्यम से अनुकूलित किया जा सकता है। उदाहरण के लिए, आप एक खोलने का पासवर्ड प्रदान कर सकते हैं, बड़े बाइनरी ऑब्जेक्ट्स को Java हीप मेमोरी के बाहर रख सकते हैं, बाहरी संसाधनों को नियंत्रित कर सकते हैं, या एम्बेडेड बाइनरी डेटा को छोड़ सकते हैं।

## **प्रस्तुतियों को खोलें**

फ़ाइल या स्ट्रीम लोड करने के बाद, आप [उसका मूल प्रस्तुति स्वरूप निर्धारित करें](/slides/hi/python-java/detect-presentation-source-format/) चुन सकते हैं कि आपका एप्लिकेशन इसे कैसे प्रोसेस करेगा।

एक मौजूदा प्रस्तुति खोलने के लिए, इसके फ़ाइल पथ को [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) कंस्ट्रक्टर में पास करें। उपयोग के बाद प्रस्तुति को डिस्पोज़ करें ताकि फ़ाइल हैंडल, अस्थायी डेटा और अन्य संसाधन तुरंत रिलीज़ हो जाएँ।

निम्नलिखित Python उदाहरण दिखाता है कि कैसे एक प्रस्तुति खोली जाए और उसकी स्लाइड गिनती प्राप्त की जाए:

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

## **पासवर्ड-संरक्षित प्रस्तुतियों को खोलें**

एक खोलने वाला पासवर्ड प्रस्तुति की सामग्री को एन्क्रिप्ट करता है। पूर्ण प्रस्तुति लोड करने के लिए, सही पासवर्ड को [LoadOptions.setPassword](https://reference.aspose.com/slides/hi/python-java/aspose.slides/loadoptions/#setPassword) पर पास करें और विकल्पों को [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) कंस्ट्रक्टर को दें। यदि पासवर्ड अनुपस्थित या गलत है तो लोडिंग विफल हो जाता है।

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

पासवर्ड पहचान, मान्यकरण, और एन्क्रिप्शन कार्यप्रवाह के लिए देखें [पासवर्ड-रक्षित प्रस्तुतियां](/slides/hi/python-java/password-protected-presentation/). यदि किसी एन्क्रिप्टेड प्रस्तुति को जानबूझकर सार्वजनिक दस्तावेज़ गुणों के साथ सहेजा गया हो, तो उन गुणों को पासवर्ड के बिना पढ़ा जा सकता है; देखें [प्रस्तुति गुण प्रबंधित करें](/slides/hi/python-java/presentation-properties/).

## **बड़ी प्रस्तुतियों को खोलें**

[LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/hi/python-java/aspose.slides/loadoptions/#getBlobManagementOptions) विकल्प लौटाता है जो नियंत्रित करता है कि Aspose.Slides इमेज, ऑडियो और वीडियो जैसी बाइनरी बड़े ऑब्जेक्ट्स (BLOB) को कैसे संभालता है। आप स्रोत फ़ाइल को लॉक्ड रख सकते हैं, अस्थायी फ़ाइलों की अनुमति दे सकते हैं, और मेमोरी में रखे जाने वाले BLOB डेटा की मात्रा को सीमित कर सकते हैं।

निम्नलिखित Python कोड दिखाता है कि कैसे एक बड़ी प्रस्तुति (उदाहरण के लिए, 2 GB) लोड की जाए:

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
जब [PresentationLockingBehavior.KeepLocked](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentationlockingbehavior/#KeepLocked) का उपयोग किया जाता है, तो स्रोत फ़ाइल तब तक लॉक्ड रहती है जब तक प्रस्तुति इंस्टेंस को डिस्पोज़ नहीं किया जाता। उस इंस्टेंस के सक्रिय रहने के दौरान स्रोत फ़ाइल को स्थानांतरित, ओवरराइट या हटाएँ नहीं।

Aspose.Slides लोडिंग के दौरान इनपुट स्ट्रीम की सामग्री को कॉपी कर सकता है। बड़ी प्रस्तुतियों के मामले में, फ़ाइल पथ आमतौर पर स्ट्रीम की तुलना में अधिक कुशल होता है। अतिरिक्त स्टॉरेज और मेमोरी प्रबंधन विकल्पों के लिए देखें [BLOB प्रबंधित करें](/slides/hi/python-java/manage-blob/).
{{% /alert %}}

## **बाहरी संसाधनों को नियंत्रित करें**

[LoadOptions.setResourceLoadingCallback](https://reference.aspose.com/slides/hi/python-java/aspose.slides/loadoptions/#setResourceLoadingCallback) JPype प्रॉक्सी स्वीकार करता है जो जावा रिसोर्स-लोडिंग कॉलबैक इंटरफ़ेस को लागू करता है। कॉलबैक प्रतिस्थापन डेटा प्रदान कर सकता है, संसाधन को पुनर्निर्देशन कर सकता है, डिफ़ॉल्ट लोडर का उपयोग कर सकता है, या संसाधन को स्किप कर सकता है। यह तब उपयोगी होता है जब प्रस्तुतियों में बाहरी छवियाँ होती हैं जिन्हें एप्लिकेशन-विशिष्ट सुरक्षा या संग्रहण नियमों के अनुसार हल किया जाना चाहिए।

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

एक प्रस्तुति में एम्बेडेड बाइनरी डेटा हो सकता है जिसकी एप्लिकेशन को आवश्यकता नहीं होती या जिसे वह रखना नहीं चाहता। उदाहरण में शामिल हैं:

- VBA प्रोजेक्ट्स, जो [Presentation.getVbaProject](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#getVbaProject) के माध्यम से उपलब्ध हैं;
- एम्बेडेड OLE डेटा, जो [OleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/hi/python-java/aspose.slides/oleembeddeddatainfo/#getEmbeddedFileData) के माध्यम से उपलब्ध है;
- ActiveX कंट्रोल डेटा, जो [Control.getActiveXControlBinary](https://reference.aspose.com/slides/hi/python-java/aspose.slides/control/#getActiveXControlBinary) के माध्यम से उपलब्ध है।

[LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/hi/python-java/aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects) को `True` पर सेट करें ताकि लोड करते समय यह बाइनरी डेटा हटाया जा सके। स्वच्छ परिणाम को बनाए रखने के लिए लोड की गई प्रस्तुति को सहेजें।

यह विकल्प अनचाहे एम्बेडेड पेलोड्स के संपर्क को कम करता है, लेकिन यह पूर्ण मालवेयर-डिटेक्शन या सामग्री-सेनिटाइज़ेशन प्रणाली नहीं है।

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

**मैं कैसे जानूँ कि फ़ाइल भ्रष्ट है और खोल नहीं सकती?**

Aspose.Slides लोडिंग के दौरान पार्सिंग या फ़ॉर्मेट अपवाद फेंकती है। इस विफलता को गलत पासवर्ड त्रुटि से अलग ढंग से हैंडल करें ताकि एप्लिकेशन कारण को सटीक रूप से रिपोर्ट कर सके।

**यदि आवश्यक फ़ॉन्ट्स गायब हों तो क्या होता है?**

प्रस्तुति फिर भी लोड हो सकती है, लेकिन रेंडरिंग और एक्सपोर्ट फ़ॉन्ट्स को प्रतिस्थापित कर सकते हैं। आप आउटपुट को अधिक पूर्वानुमानित बनाने के लिए [फ़ॉन्ट सब्स्टिट्यूशन कॉन्फ़िगर](/slides/hi/python-java/font-substitution/) कर सकते हैं या [कस्टम फ़ॉन्ट प्रदान](/slides/hi/python-java/custom-font/) करें।

**क्या प्रस्तुति लोड करने से उसकी एम्बेडेड मीडिया भी लोड हो जाती है?**

एम्बेडेड ऑडियो और वीडियो प्रस्तुति ऑब्जेक्ट मॉडल के माध्यम से उपलब्ध हो जाते हैं। बाहरी संसाधनों को कॉन्फ़िगर किए गए रिसोर्स-लोडिंग व्यवहार के अनुसार हल किया जाता है और यदि उनके स्थान तक पहुँच नहीं सके तो वे अनुपलब्ध हो सकते हैं।