---
title: Python में प्रस्तुतियों को खोलें
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
description: "Aspose.Slides for Python के जरिए .NET पर PowerPoint (.pptx, .ppt) और OpenDocument (.odp) प्रस्तुतियों को सहजता से खोलें—तेज़, विश्वसनीय, पूरी तरह से सुविधाजनक।"
---
## **परिचय**

शुरू से PowerPoint प्रस्तुतियों को बनाने के अलावा, Aspose.Slides आपको मौजूदा प्रस्तुतियों को खोलने की सुविधा भी देता है। प्रस्तुति लोड करने के बाद, आप उसके बारे में जानकारी प्राप्त कर सकते हैं, स्लाइड की सामग्री संपादित कर सकते हैं, नई स्लाइड जोड़ सकते हैं, मौजूदा स्लाइड हटा सकते हैं, और भी बहुत कुछ कर सकते हैं।

## **प्रेजेंटेशन खोलें**

मौजूदा प्रस्तुति को खोलने के लिए, [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास को इंस्टैंशिएट करें और उसके कंस्ट्रक्टर में फ़ाइल पाथ पास करें।

निम्नलिखित Python उदाहरण दिखाता है कि प्रस्तुति को कैसे खोलें और उसकी स्लाइड गिनती कैसे प्राप्त करें:

```python
import aspose.slides as slides

# Presentation क्लास को इंस्टैंशिएट करें और उसके कंस्ट्रक्टर में फ़ाइल पाथ पास करें।
with slides.Presentation("sample.pptx") as presentation:
    # प्रस्तुति में कुल स्लाइडों की संख्या प्रिंट करें।
    print(presentation.slides.length)
```

## **पासवर्ड-संरक्षित प्रस्तुतियों को खोलें**

जब आपको पासवर्ड-संरक्षित प्रस्तुति खोलनी हो, तो पासवर्ड को [password](https://reference.aspose.com/slides/hi/python-net/aspose.slides/loadoptions/password/) प्रॉपर्टी के माध्यम से [LoadOptions](https://reference.aspose.com/slides/hi/python-net/aspose.slides/loadoptions/) क्लास में पास करके उसे डिक्रिप्ट और लोड करें। निम्नलिखित Python कोड इस ऑपरेशन को दर्शाता है:

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "YOUR_PASSWORD"

with slides.Presentation("sample.pptx", load_options) as presentation:
    # डिक्रिप्ट की गई प्रस्तुति पर संचालन करें।
```

## **बड़ी प्रस्तुतियों को खोलें**

Aspose.Slides विकल्प प्रदान करता है—विशेषकर [blob_management_options](https://reference.aspose.com/slides/hi/python-net/aspose.slides/loadoptions/blob_management_options/) प्रॉपर्टी [LoadOptions](https://reference.aspose.com/slides/hi/python-net/aspose.slides/loadoptions/) क्लास में—जो आपको बड़ी प्रस्तुतियों को लोड करने में मदद करती है।

यह Python कोड बड़ी प्रस्तुति (उदाहरण के लिए, 2 GB) को लोड करने का तरीका दर्शाता है:

```python
import aspose.slides as slides
import os

file_path = "LargePresentation.pptx"

load_options = slides.LoadOptions()
# KeepLocked व्यवहार चुनें—प्रेजेंटेशन फ़ाइल लाइफ़टाइम के दौरान लॉक रहती है 
# प्रेजेंटेशन इंस्टेंस का, लेकिन इसे मेमोरी में लोड करने या अस्थायी फ़ाइल में कॉपी करने की ज़रूरत नहीं है।
load_options.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
load_options.blob_management_options.is_temporary_files_allowed = True
load_options.blob_management_options.max_blobs_bytes_in_memory = 10 * 1024 * 1024  # 10 MB

with slides.Presentation(file_path, load_options) as presentation:
    # बड़ी प्रस्तुति लोड हो गई है और उपयोग की जा सकती है, जबकि मेमोरी खपत कम रहती है।

    # प्रस्तुति में बदलाव करें।
    presentation.slides[0].name = "Large presentation"

    # प्रस्तुति को दूसरी फ़ाइल में सहेजें। इस प्रक्रिया में मेमोरी खपत कम रहती है।
    presentation.save("LargePresentation-copy.pptx", slides.export.SaveFormat.PPTX)

    # ऐसा न करें! एक I/O अपवाद फेंका जाएगा क्योंकि फ़ाइल तब तक लॉक रहेगी जब तक प्रेज़ेंटेशन ऑब्जेक्ट डिस्पोज़ नहीं हो जाता।
    os.remove(file_path)

# यहाँ करने के लिए ठीक है। स्रोत फ़ाइल अब प्रेज़ेंटेशन ऑब्जेक्ट द्वारा लॉक नहीं है।
os.remove(file_path)
```

{{% alert color="info" title="सूचना" %}}
स्ट्रीम के साथ काम करते समय कुछ सीमाओं को पार करने के लिए, Aspose.Slides एक स्ट्रीम की सामग्री को कॉपी कर सकता है। स्ट्रीम से बड़ी प्रस्तुति लोड करने से प्रस्तुति कॉपी हो जाती है और लोडिंग धीमी हो सकती है। इसलिए, जब आपको बड़ी प्रस्तुति लोड करनी हो, तो हम दृढ़ता से अनुशंसा करते हैं कि आप स्ट्रीम के बजाय प्रस्तुति फ़ाइल पाथ का उपयोग करें।

जब आप ऐसी प्रस्तुति बना रहे हों जिसमें बड़े ऑब्जेक्ट (वीडियो, ऑडियो, हाई‑रिज़ोल्यूशन छवियां, आदि) शामिल हों, तो आप [BLOB management](/slides/hi/python-net/manage-blob/) का उपयोग करके मेमोरी खपत को कम कर सकते हैं।
{{%/alert %}}

## **बिना एम्बेडेड बाइनरी ऑब्जेक्ट्स के प्रस्तुतियों को लोड करें**

एक PowerPoint प्रस्तुति निम्न प्रकार के एम्बेडेड बाइनरी ऑब्जेक्ट रख सकती है:

- VBA प्रोजेक्ट (जिसे [Presentation.vba_project](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/vba_project/) के माध्यम से एक्सेस किया जा सकता है);
- OLE ऑब्जेक्ट एम्बेडेड डेटा (जिसे [OleEmbeddedDataInfo.embedded_file_data](https://reference.aspose.com/slides/hi/python-net/aspose.slides/ioleembeddeddatainfo/embedded_file_data/) के माध्यम से एक्सेस किया जा सकता है);
- ActiveX कंट्रोल बाइनरी डेटा (जिसे [Control.active_x_control_binary](https://reference.aspose.com/slides/hi/python-net/aspose.slides/control/active_x_control_binary/) के माध्यम से एक्सेस किया जा सकता है)।

[LoadOptions.delete_embedded_binary_objects](https://reference.aspose.com/slides/hi/python-net/aspose.slides/loadoptions/delete_embedded_binary_objects/) प्रॉपर्टी का उपयोग करके आप प्रस्तुति को बिना किसी एम्बेडेड बाइनरी ऑब्जेक्ट के लोड कर सकते हैं।

यह प्रॉपर्टी संभावित दुर्भावनापूर्ण बाइनरी सामग्री को हटाने में उपयोगी है। निम्नलिखित Python कोड दर्शाता है कि बाइनरी सामग्री के बिना प्रस्तुति कैसे लोड करें:

```py
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.delete_embedded_binary_objects = True

with slides.Presentation("malware.ppt", load_options) as presentation:
    # प्रस्तुति पर संचालन करें।
```

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं कैसे पता करूं कि फ़ाइल भ्रष्ट है और खोल नहीं सकती?**

लोड करते समय आपको पार्सिंग/फ़ॉर्मेट वैलिडेशन एक्सेप्शन मिलेगा। ऐसी त्रुटियों में अक्सर अमान्य ZIP संरचना या टूटे हुए PowerPoint रिकॉर्ड का उल्लेख होता है।

**यदि आवश्यक फ़ॉन्ट खो गए हों तो क्या होगा?**

फ़ाइल खुल जाएगी, लेकिन बाद में [rendering/export](/slides/hi/python-net/convert-presentation/) फ़ॉन्ट को प्रतिस्थापित कर सकता है। रनटाइम वातावरण में फ़ॉन्ट प्रतिस्थापन को कॉन्फ़िगर करने के लिए [Configure font substitutions](/slides/hi/python-net/font-substitution/) या आवश्यक फ़ॉन्ट जोड़ने के लिए [add the required fonts](/slides/hi/python-net/custom-font/) का उपयोग करें।

**खोलते समय एम्बेडेड मीडिया (वीडियो/ऑडियो) के बारे में क्या?**

वे प्रस्तुति संसाधनों के रूप में उपलब्ध हो जाते हैं। यदि मीडिया बाहरी पाथ से संदर्भित है, तो सुनिश्चित करें कि वह पाथ आपके वातावरण में उपलब्ध हो; अन्यथा [rendering/export](/slides/hi/python-net/convert-presentation/) मीडिया को छोड़ सकता है।