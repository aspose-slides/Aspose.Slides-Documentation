---
title: Python में प्रस्तुतियों को खोलना
linktitle: प्रस्तुतियों को खोलें
type: docs
weight: 20
url: /hi/python-net/open-presentation/
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
- Aspose.Slides
description: "Python में PowerPoint और OpenDocument प्रस्तुतियों को खोलना, खोलने के पासवर्ड प्रदान करना, और Aspose.Slides for Python via .NET के साथ स्मृति उपयोग को कम करना सीखें।"
---
## **परिचय**

[Aspose.Slides for Python via .NET](https://products.aspose.com/slides/hi/python-net/) फ़ाइलों और स्ट्रीम्स से PowerPoint और OpenDocument प्रस्तुतियों को लोड कर सकता है। प्रस्तुतिअनलोड होने के बाद, आप उसकी संरचना का निरीक्षण कर सकते हैं, स्लाइड्स को संपादित कर सकते हैं, संसाधनों का प्रबंधन कर सकते हैं, और इसे मूल या किसी अन्य समर्थित प्रारूप में सहेज सकते हैं।

लोडिंग व्यवहार को [LoadOptions](https://reference.aspose.com/slides/hi/python-net/aspose.slides/loadoptions/) वर्ग के माध्यम से कस्टमाइज़ किया जा सकता है। उदाहरण के लिए, आप खोलने का पासवर्ड प्रदान कर सकते हैं, बड़े बाइनरी ऑब्जेक्ट्स को मेमोरी के बाहर रख सकते हैं, या एम्बेडेड बाइनरी डेटा को छोड़ सकते हैं।

## **प्रस्तुति खोलें**

किसी मौजूदा प्रस्तुति को खोलने के लिए, उसका फ़ाइल पथ [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) कन्स्ट्रक्टर को पास करें। फ़ाइल हैंडल, अस्थायी डेटा और अन्य संसाधनों को तुरंत रिलीज़ करने के लिये `with` स्टेटमेंट का उपयोग करें।

निम्नलिखित Python उदाहरण दिखाता है कि कैसे प्रस्तुति को खोलें और उसकी स्लाइड गिनती प्राप्त करें:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    print("Slide count: " + str(len(presentation.slides)))
```

## **पासवर्ड-संरक्षित प्रस्तुतियों को खोलें**

एक खोलने वाला पासवर्ड प्रस्तुति सामग्री को एन्क्रिप्ट करता है। पूरी प्रस्तुति को लोड करने के लिये, सही पासवर्ड को [LoadOptions.password](https://reference.aspose.com/slides/hi/python-net/aspose.slides/loadoptions/password/) में असाइन करें और विकल्पों को [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) कन्स्ट्रक्टर में पास करें। पासवर्ड अनुपलब्ध या गलत होने पर लोडिंग विफल हो जाएगी।

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation("encrypted-presentation.pptx", load_options) as presentation:
    print("Slide count: " + str(len(presentation.slides)))
```

पासवर्ड डिटेक्शन, वैधता और एन्क्रिप्शन वर्कफ़्लोज़ के लिये, देखें [Password-Protect Presentations](/slides/hi/python-net/password-protected-presentation/)। यदि एन्क्रिप्टेड प्रस्तुति को जानबूझकर सार्वजनिक दस्तावेज़ गुणों के साथ सहेजा गया हो, तो उन गुणों को बिना पासवर्ड के पढ़ा जा सकता है; देखें [Manage Presentation Properties](/slides/hi/python-net/presentation-properties/)।

## **बड़ी प्रस्तुतियों को खोलें**

[LoadOptions.blob_management_options](https://reference.aspose.com/slides/hi/python-net/aspose.slides/loadoptions/blob_management_options/) नियंत्रित करता है कि Aspose.Slides छवियों, ऑडियो और वीडियो जैसे बाइनरी बड़े ऑब्जेक्ट्स को कैसे संभालता है। आप स्रोत फ़ाइल को लॉक रख सकते हैं, अस्थायी फ़ाइलों की अनुमति दे सकते हैं, और मेमोरी में रखे जाने वाले BLOB डेटा की मात्रा को सीमित कर सकते हैं।

यह Python कोड बड़ी प्रस्तुति (उदाहरण के लिये, 2 GB) को लोड करने का प्रदर्शन करता है:

```python
import aspose.slides as slides
file_path = "large-presentation.pptx"

load_options = slides.LoadOptions()
load_options.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
load_options.blob_management_options.is_temporary_files_allowed = True
load_options.blob_management_options.max_blobs_bytes_in_memory = 10 * 1024 * 1024

with slides.Presentation(file_path, load_options) as presentation:
    presentation.slides[0].name = "Large presentation"
    presentation.save("large-presentation-copy.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="info" title="नोट" %}}

`PresentationLockingBehavior.KEEP_LOCKED` के साथ, स्रोत फ़ाइल तब तक लॉक रहती है जब तक `Presentation` ऑब्जेक्ट नष्ट नहीं हो जाता। उस ऑब्जेक्ट के जीवित रहने के दौरान स्रोत फ़ाइल को न स्थानांतरित करें, न ओवरराइट करें, न हटाएँ।

Aspose.Slides लोडिंग के दौरान इनपुट स्ट्रीम की सामग्री को कॉपी कर सकता है। बड़ी प्रस्तुतियों के लिये, फ़ाइल पाथ आम तौर पर स्ट्रीम से अधिक कुशल होता है। अतिरिक्त स्टोरेज और मेमोरी‑प्रबंधन विकल्पों के लिये देखें [Manage BLOBs](/slides/hi/python-net/manage-blob/)।

{{% /alert %}}

## **एम्बेडेड बाइनरी ऑब्जेक्ट्स के बिना प्रस्तुतियों को लोड करें**

प्रस्तुति में ऐसे एम्बेडेड बाइनरी डेटा हो सकते हैं जिसकी एप्लिकेशन को आवश्यकता नहीं होती या वह उसे रखना नहीं चाहती। उदाहरण के लिये:

- VBA प्रोजेक्ट्स, जिन्हें आप [Presentation.vba_project](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/vba_project/) से प्राप्त कर सकते हैं;
- एम्बेडेड OLE डेटा, जिसे आप [OleEmbeddedDataInfo.embedded_file_data](https://reference.aspose.com/slides/hi/python-net/aspose.slides/ioleembeddeddatainfo/embedded_file_data/) से प्राप्त कर सकते हैं;
- ActiveX कंट्रोल डेटा, जिसे आप [Control.active_x_control_binary](https://reference.aspose.com/slides/hi/python-net/aspose.slides/control/active_x_control_binary/) से प्राप्त कर सकते हैं।

लोड करते समय इस बाइनरी डेटा को हटाने के लिये [LoadOptions.delete_embedded_binary_objects](https://reference.aspose.com/slides/hi/python-net/aspose.slides/loadoptions/delete_embedded_binary_objects/) को `True` पर सेट करें। लोड की गई प्रस्तुति को सहेजें ताकि साफ‑सुथरा परिणाम बना रहे।

यह विकल्प अनचाहे एम्बेडेड पेलोड्स के प्रति एक्सपोजर को कम करता है, लेकिन यह पूर्ण मैलबेयर‑डिटेक्शन या कंटेंट‑सैनिटाइज़ेशन सिस्टम नहीं है।

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.delete_embedded_binary_objects = True

with slides.Presentation("presentation-with-embedded-data.pptx", load_options) as presentation:
    presentation.save("presentation-without-embedded-data.pptx", slides.export.SaveFormat.PPTX)
```

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं कैसे पहचानूँ कि फ़ाइल दूषित है और नहीं खोली जा सकती?**

Aspose.Slides लोडिंग के दौरान पार्सिंग या फ़ॉर्मेट एक्ससेप्शन उठाता है। इसे पासवर्ड‑त्रुटि से अलग रूप से हैंडल करें ताकि एप्लिकेशन कारण को सटीक रूप से रिपोर्ट कर सके।

**यदि आवश्यक फोंट उपलब्ध नहीं हों तो क्या होता है?**

प्रस्तुति अभी भी लोड हो सकती है, पर रेंडरिंग और एक्सपोर्ट फ़ॉन्ट प्रतिस्थापन कर सकते हैं। आप [फ़ॉन्ट प्रतिस्थापन को कॉन्फ़िगर](/slides/hi/python-net/font-substitution/) कर सकते हैं या आउटपुट को अधिक पूर्वानुमेय बनाने के लिये [कस्टम फ़ॉन्ट प्रदान](/slides/hi/python-net/custom-font/) कर सकते हैं।

**क्या प्रस्तुति लोड करने से उसका एम्बेडेड मीडिया भी लोड हो जाता है?**

एम्बेडेड ऑडियो और वीडियो प्रस्तुति ऑब्जेक्ट मॉडल के माध्यम से उपलब्ध हो जाते हैं। बाहरी संसाधनों को डिफ़ॉल्ट रिसोर्स‑लोडिंग व्यवहार के अनुसार हल किया जाता है और यदि उनके स्थान तक पहुँच नहीं हो पाती तो उपलब्ध नहीं रह सकते।