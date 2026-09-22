---
title: Python में प्रस्तुतियाँ खोलें
linktitle: प्रस्तुतियाँ खोलें
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
- सुरक्षित प्रस्तुति
- बड़ी प्रस्तुति
- बाहरी संसाधन
- बाइनरी ऑब्जेक्ट
- Python
- Aspose.Slides
description: "Python में PowerPoint और OpenDocument प्रस्तुतियों को कैसे खोलें, ओपनिंग पासवर्ड कैसे प्रदान करें, और Aspose.Slides for Python via .NET के साथ मेमोरी उपयोग को कैसे कम करें, यह जानें।"
---
## **परिचय**

[Aspose.Slides for Python via .NET](https://products.aspose.com/slides/hi/python-net/) फ़ाइलों और स्ट्रीम्स से PowerPoint और OpenDocument प्रस्तुतियों को लोड कर सकता है। एक बार प्रस्तुति लोड हो जाने के बाद, आप इसकी संरचना की जाँच कर सकते हैं, स्लाइड्स को संपादित कर सकते हैं, संसाधनों का प्रबंधन कर सकते हैं, और इसे मूल या किसी अन्य समर्थित फ़ॉर्मेट में सहेज सकते हैं।

लोडिंग व्यवहार को [LoadOptions](https://reference.aspose.com/slides/hi/python-net/aspose.slides/loadoptions/) क्लास के माध्यम से अनुकूलित किया जा सकता है। उदाहरण के लिए, आप एक ओपनिंग पासवर्ड प्रदान कर सकते हैं, बड़े बाइनरी ऑब्जेक्ट्स को मेमोरी के बाहर रख सकते हैं, या एंबेडेड बाइनरी डेटा को छोड़ सकते हैं।

## **प्रस्तुति खोलें**

फ़ाइल या स्ट्रीम को लोड करने के बाद, आप [उसके मूल प्रस्तुति फ़ॉर्मेट का निर्धारण करें](/slides/hi/python-net/detect-presentation-source-format/) ताकि आप तय कर सकें कि आपका एप्लिकेशन इसे कैसे प्रोसेस करता है।

मौजूदा प्रस्तुति को खोलने के लिए, उसकी फ़ाइल पाथ को [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) कंस्ट्रक्टर में पास करें। एक `with` स्टेटमेंट का उपयोग करें ताकि फ़ाइल हैंडल, अस्थायी डेटा, और अन्य संसाधन तुरंत मुक्त हो जाएँ।

निम्नलिखित Python उदाहरण दिखाता है कि प्रस्तुति को कैसे खोलें और उसकी स्लाइड गिनती प्राप्त करें:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    print("Slide count: " + str(len(presentation.slides)))
```

## **पासवर्ड-संरक्षित प्रस्तुतियों को खोलें**

एक ओपनिंग पासवर्ड प्रस्तुति सामग्री को एन्क्रिप्ट करता है। पूरी प्रस्तुति लोड करने के लिए, सही पासवर्ड को [LoadOptions.password](https://reference.aspose.com/slides/hi/python-net/aspose.slides/loadoptions/password/) को असाइन करें और विकल्पों को [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) कंस्ट्रक्टर में पास करें। यदि पासवर्ड नहीं दिया गया या गलत है तो लोडिंग विफल हो जाती है।

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation("encrypted-presentation.pptx", load_options) as presentation:
    print("Slide count: " + str(len(presentation.slides)))
```

पासवर्ड डिटेक्शन, वैधता, और एन्क्रिप्शन वर्कफ़्लोज़ के लिए, देखें [पासवर्ड-सुरक्षित प्रस्तुतियों](/slides/hi/python-net/password-protected-presentation/)। यदि किसी एन्क्रिप्टेड प्रस्तुति को जानबूझकर सार्वजनिक दस्तावेज़ गुणों के साथ सहेजा गया हो, तो उन गुणों को पासवर्ड के बिना पढ़ा जा सकता है; देखें [प्रेज़ेंटेशन गुण प्रबंधित करें](/slides/hi/python-net/presentation-properties/)।

## **बड़ी प्रस्तुतियों को खोलें**

[LoadOptions.blob_management_options](https://reference.aspose.com/slides/hi/python-net/aspose.slides/loadoptions/blob_management_options/) नियंत्रित करता है कि Aspose.Slides बाइनरी बड़े ऑब्जेक्ट्स जैसे इमेजेज़, ऑडियो, और वीडियो को कैसे संभालता है। आप स्रोत फ़ाइल को लॉक रख सकते हैं, अस्थायी फ़ाइलों की अनुमति दे सकते हैं, और मेमोरी में रखे जाने वाले BLOB डेटा की मात्रा को सीमित कर सकते हैं।

यह Python कोड बड़ी प्रस्तुति (उदाहरण के लिए, 2 GB) को लोड करने का प्रदर्शन करता है:

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

{{% alert color="info" title="Note" %}}
`PresentationLockingBehavior.KEEP_LOCKED` के साथ, स्रोत फ़ाइल तब तक लॉक रहती है जब तक `Presentation` ऑब्जेक्ट नष्ट नहीं हो जाता। उस ऑब्जेक्ट के जीवनकाल में स्रोत फ़ाइल को न स्थानांतरित करें, न अधिलेखित करें, न हटाएँ।

Aspose.Slides लोडिंग के दौरान इनपुट स्ट्रीम की सामग्री की प्रतिलिपि बन सकता है। बड़ी प्रस्तुतियों के लिए, फ़ाइल पाथ आमतौर पर स्ट्रीम की तुलना में अधिक कुशल होता है। अतिरिक्त स्टोरेज और मेमोरी-प्रबंधन विकल्पों के लिए देखें [BLOB प्रबंधन](/slides/hi/python-net/manage-blob/)।
{{% /alert %}}

## **एंबेडेड बाइनरी ऑब्जेक्ट्स के बिना प्रस्तुतियों को लोड करें**

एक प्रस्तुति में एंबेडेड बाइनरी डेटा हो सकता है जिसे ऐप्लिकेशन को आवश्यक नहीं है या वह संरक्षित नहीं करना चाहता। उदाहरण के लिए:

- VBA प्रोजेक्ट्स, उपलब्ध हैं [Presentation.vba_project](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/vba_project/) के माध्यम से;
- एंबेडेड OLE डेटा, उपलब्ध है [OleEmbeddedDataInfo.embedded_file_data](https://reference.aspose.com/slides/hi/python-net/aspose.slides/ioleembeddeddatainfo/embedded_file_data/) के माध्यम से;
- ActiveX कंट्रोल डेटा, उपलब्ध है [Control.active_x_control_binary](https://reference.aspose.com/slides/hi/python-net/aspose.slides/control/active_x_control_binary/) के माध्यम से।

लोडिंग के दौरान इस बाइनरी डेटा को हटाने के लिए [LoadOptions.delete_embedded_binary_objects](https://reference.aspose.com/slides/hi/python-net/aspose.slides/loadoptions/delete_embedded_binary_objects/) को `True` सेट करें। साफ़ किया गया परिणाम संरक्षित करने के लिए लोड की गई प्रस्तुति को सहेजें।

यह विकल्प अवांछित एंबेडेड पेलोड्स के संपर्क को कम करता है, लेकिन यह पूर्ण मैलवेयर-डिटेक्शन या कंटेंट-सैनिटाइजेशन प्रणाली नहीं है।

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.delete_embedded_binary_objects = True

with slides.Presentation("presentation-with-embedded-data.pptx", load_options) as presentation:
    presentation.save("presentation-without-embedded-data.pptx", slides.export.SaveFormat.PPTX)
```

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं कैसे जानूँ कि फ़ाइल भ्रष्ट है और खोल नहीं सकती?**

लोडिंग के दौरान Aspose.Slides पार्सिंग या फ़ॉर्मेट अपवाद उत्पन्न करता है। इस विफलता को गलत पासवर्ड त्रुटि से अलग से संभालें ताकि ऐप्लिकेशन सटीक कारण रिपोर्ट कर सके।

**यदि आवश्यक फ़ॉन्ट्स अनुपलब्ध हों तो क्या होता है?**

प्रस्तुति अभी भी लोड हो सकती है, लेकिन रेंडरिंग और एक्सपोर्ट में फ़ॉन्ट्स बदल हो सकते हैं। आप आउटपुट को अधिक पूर्वानुमेय बनाने के लिए [फ़ॉन्ट प्रतिस्थापन को कॉन्फ़िगर](/slides/hi/python-net/font-substitution/) या [कस्टम फ़ॉन्ट्स प्रदान](/slides/hi/python-net/custom-font/) कर सकते हैं।

**क्या प्रस्तुति को लोड करने से उसके एंबेडेड मीडिया भी लोड हो जाते हैं?**

एंबेडेड ऑडियो और वीडियो प्रस्तुति ऑब्जेक्ट मॉडल के माध्यम से उपलब्ध होते हैं। बाहरी संसाधनों को डिफ़ॉल्ट रिसोर्स-लोडिंग व्यवहार के अनुसार हल किया जाता है और यदि उनके स्थान तक पहुंच नहीं हो पाती तो वे अनुपलब्ध हो सकते हैं।