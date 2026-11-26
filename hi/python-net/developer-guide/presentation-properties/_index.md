---
title: Python के साथ प्रस्तुति गुणों का प्रबंधन
linktitle: प्रस्तुति गुण
type: docs
weight: 70
url: /hi/python-net/presentation-properties/
keywords:
- PowerPoint गुण
- प्रस्तुति गुण
- दस्तावेज़ गुण
- बिल्ट‑इन गुण
- कस्टम गुण
- उन्नत गुण
- गुण प्रबंधित करें
- गुण संशोधित करें
- दस्तावेज़ मेटाडेटा
- मेटाडेटा संपादित करें
- प्रूफिंग भाषा
- डिफ़ॉल्ट भाषा
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET में प्रस्तुति गुणों को मास्टर करें और अपने PowerPoint फ़ाइलों में खोज, ब्रांडिंग और वर्कफ़्लो को सरल बनाएं।"
---
## **परिचय**

Aspose.Slides for Python via .NET **बिल्ट‑इन** और **कस्टम** दस्तावेज़ गुणों का समर्थन करता है। इन गुणों का उपयोग प्रस्तुति मेटाडेटा पढ़ने और अपडेट करने के लिए करें, जैसे लेखक, शीर्षक, और उपयोगकर्ता‑परिभाषित मान।

Aspose.Slides आपको प्रस्तुति दस्तावेज़ गुणों के साथ काम करने की अनुमति देता है [DocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/) वर्ग के माध्यम से। इस वर्ग का एक उदाहरण [Presentation.document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/document_properties/) द्वारा लौटाया जाता है। निम्नलिखित उदाहरण दिखाते हैं कि इन गुणों को कैसे पढ़ा, संशोधित और प्रबंधित किया जाए।

{{% alert color="info" title="Note" %}}
Aspose.Slides प्रस्तुतियों को सहेजते समय अनुप्रयोग और निर्माता मेटाडेटा का प्रबंधन करता है; ये फ़ील्ड उस सॉफ़्टवेयर की पहचान करती हैं जिसने आउटपुट उत्पन्न किया।
{{% /alert %}}

## **प्रस्तुति गुणों का प्रबंधन**

दस्तावेज़ गुण प्रस्तुति सामग्री के साथ वर्णनात्मक जानकारी संग्रहीत करते हैं। वे दो श्रेणियों में विभाजित होते हैं:

- **Built-in properties** मानक मेटाडेटा रखते हैं, जैसे शीर्षक, लेखक, और दस्तावेज़ आँकड़े।
- **Custom properties** उपयोगकर्ता‑परिभाषित नाम/मान युग्म संग्रहीत करते हैं।

Aspose.Slides for Python via .NET दोनों श्रेणियों तक पहुँच प्रदान करता है। PowerPoint में, दस्तावेज़ मेटाडेटा जांचने के लिये **File → Info → Properties → Advanced Properties** चुनें। संवाद जानकारी को **Summary**, **Statistics**, **Contents**, और **Custom** जैसे टैब में व्यवस्थित करता है। उपयोगकर्ता‑परिभाषित गुणों का प्रबंधन करने के लिये **Custom** टैब का उपयोग करें।

## **एन्क्रिप्टेड प्रस्तुति से सार्वजनिक गुण पढ़ें**

एक खोलने वाला पासवर्ड सामान्यतः प्रस्तुति सामग्री और दस्तावेज़ गुणों दोनों की सुरक्षा करता है। जब कोई प्रस्तुति [ProtectionManager.encrypt_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/encrypt_document_properties/) को `False` पर सेट करके एन्क्रिप्ट की जाती है, तो उसके दस्तावेज़ गुण सार्वजनिक रहते हैं। फिर एक एप्लिकेशन [LoadOptions.only_load_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/only_load_document_properties/) को `True` सेट कर सकता है और खोलने वाला पासवर्ड प्रदान किए बिना सार्वजनिक मेटाडेटा पढ़ सकता है।

[LoadOptions.only_load_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/only_load_document_properties/) यह नियंत्रित करता है कि Aspose.Slides क्या लोड करता है; यह कुछ भी डिक्रिप्ट नहीं करता। यदि गुण एन्क्रिप्शन में सम्मिलित थे, तो पासवर्ड के बिना उन्हें लोड करना विफल हो जाता है। यदि प्रस्तुति एन्क्रिप्ट नहीं है, तो विकल्प को उपेक्षित किया जाता है और पूरी प्रस्तुति लोड की जाती है।

उदाहरण के लिये एक एन्क्रिप्टेड प्रस्तुति चाहिए जिसकी दस्तावेज़ गुण सार्वजनिक रखे गये हों। यह लोडिंग मोड को [ProtectionManager.is_only_document_properties_loaded](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/is_only_document_properties_loaded/) द्वारा सत्यापित करता है और फिर [Presentation.document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/document_properties/) के माध्यम से बिल्ट‑इन गुण पढ़ता है:

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.only_load_document_properties = True

with slides.Presentation("public-properties-encrypted.pptx", load_options) as presentation:
    if presentation.protection_manager.is_only_document_properties_loaded:
        document_properties = presentation.document_properties

        print("Author: " + document_properties.author)
        print("Title: " + document_properties.title)
        print("Keywords: " + document_properties.keywords)
    else:
        print("The presentation was not loaded in document-properties-only mode.")
```

इस मोड में, स्लाइड सामग्री लोड नहीं होती। स्लाइड्स, मास्टर, लेआउट, शैप्स, मीडिया, और अन्य प्रस्तुति वस्तुएँ उपलब्ध नहीं होतीं। एप्लिकेशन को हमेशा [ProtectionManager.is_only_document_properties_loaded](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/is_only_document_properties_loaded/) जांचना चाहिए इससे पहले कि वह ऐसी क्रिया करे जिसके लिये पूरी प्रस्तुति ऑब्जेक्ट मॉडल की आवश्यकता हो।

{{% alert color="warning" title="Security" %}}
सार्वजनिक मेटाडेटा लेखक नाम, शीर्षक, विषय, कीवर्ड, कंपनी जानकारी, टिप्पणी और कस्टम मान प्रकट कर सकता है। संवेदनशील गुणों को प्रस्तुति के साथ एन्क्रिप्ट करें। इन्हें केवल तब सार्वजनिक रखें जब इंडेक्सिंग, वर्गीकरण, खोज, या दस्तावेज़‑प्रबंधन सिस्टम को पासवर्ड के बिना उन तक पहुँचने की विशिष्ट आवश्यकता हो।
{{% /alert %}}

## **एन्क्रिप्टेड प्रस्तुति के गुण अपडेट करें**

एक एन्क्रिप्टेड PPTX फ़ाइल के लिये, [LoadOptions.only_load_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/only_load_document_properties/) के साथ लोड की गई प्रस्तुति सार्वजनिक मेटाडेटा पढ़ने के लिये अभिप्रेत है। Aspose.Slides उस केवल‑मेटाडेटा ऑब्जेक्ट से बदलें हुए गुण सहेज नहीं सकता क्योंकि सार्वजनिक गुणों को एन्क्रिप्टेड प्रस्तुति के भीतर संबंधित डेटा के साथ संगत रहना आवश्यक है। इसलिए उन्हें अपडेट करने के लिये सही खोलने वाला पासवर्ड और पूरी लोड आवश्यक है।

उदाहरण के लिये एक एन्क्रिप्टेड PPTX प्रस्तुति चाहिए जिसमें सार्वजनिक दस्तावेज़ गुण और ज्ञात खोलने वाला पासवर्ड हो। यह पूर्ण प्रस्तुति को [LoadOptions.password](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/password/) के साथ खोलता है, सार्वजनिक बिल्ट‑इन गुण अपडेट करता है, और परिणाम सहेजता है। फिर यह [PresentationInfo.is_encrypted](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/is_encrypted/) का उपयोग करके यह सत्यापित करता है कि एन्क्रिप्शन बना रहता है और पासवर्ड के बिना सार्वजनिक मेटाडेटा पुनः खोल कर नए मानों की पुष्टि करता है:

```python
import aspose.slides as slides

input_path = "public-properties-encrypted.pptx"
output_path = "updated-public-properties-encrypted.pptx"

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation(input_path, load_options) as presentation:
    document_properties = presentation.document_properties
    document_properties.title = "Updated Product Roadmap"
    document_properties.keywords = "roadmap, planning, indexed"
    
    presentation.save(output_path, slides.export.SaveFormat.PPTX)

presentation_info = slides.PresentationFactory.instance.get_presentation_info(output_path)
print("The presentation is encrypted: " + str(presentation_info.is_encrypted))

metadata_load_options = slides.LoadOptions()
metadata_load_options.only_load_document_properties = True

with slides.Presentation(output_path, metadata_load_options) as metadata_presentation:
    if metadata_presentation.protection_manager.is_only_document_properties_loaded:
        print("Title: " + metadata_presentation.document_properties.title)
        print("Keywords: " + metadata_presentation.document_properties.keywords)
    else:
        print("The presentation was not loaded in document-properties-only mode.")
```

यदि कोई एप्लिकेशन प्रस्तुति सामग्री को डिक्रिप्ट या लोड करने की अनुमति नहीं रखता, तो उसे एन्क्रिप्टेड PPTX फ़ाइल के सार्वजनिक गुणों को केवल‑पढ़ने योग्य मानना चाहिए।

## **बिल्ट‑इन गुणों तक पहुँचें**

[DocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/) वर्ग टाइप्ड प्रॉपर्टीज़ के माध्यम से बिल्ट‑इन मेटाडेटा उजागर करता है, जिसमें [DocumentProperties.author](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/author/), [DocumentProperties.title](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/title/), और [DocumentProperties.created_time](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/created_time/) शामिल हैं। यह उदाहरण मौजूदा प्रस्तुति खोलता है और उसके संग्रहीत मेटाडेटा को कंसोल पर प्रिंट करता है। मान इनपुट प्रस्तुति पर निर्भर करते हैं; कुछ फ़ील्ड खाली हो सकते हैं।

```python
import aspose.slides as slides

with slides.Presentation("AccessBuiltInProperties.pptx") as presentation:
    document_properties = presentation.document_properties

    print("Category:", document_properties.category)
    print("Content status:", document_properties.content_status)
    print("Creation date:", document_properties.created_time)
    print("Author:", document_properties.author)
    print("Comments:", document_properties.comments)
    print("Keywords:", document_properties.keywords)
    print("Last modified by:", document_properties.last_saved_by)
    print("Manager:", document_properties.manager)
    print("Modified date:", document_properties.last_saved_time)
    print("Presentation format:", document_properties.presentation_format)
    print("Last print date:", document_properties.last_printed)
    print("Is shared between producers:", document_properties.shared_doc)
    print("Subject:", document_properties.subject)
    print("Title:", document_properties.title)
```

### **संस्करण संख्या और संपादन समय की रिपोर्ट**

`presentations` फ़ोल्डर में प्रत्येक PPTX फ़ाइल के लिये संस्करण संख्या और कुल संपादन समय की रिपोर्ट करने हेतु, [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/read_document_properties/) का उपयोग करके स्लाइड्स को संपादन हेतु लोड किए बिना उसके [DocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/) प्राप्त करें। Python अवधि को `timedelta` के रूप में दिखाता है, जिसमें 24 घंटे तक पहुँचने पर दिन की गणना भी शामिल होती है।

```python
from pathlib import Path

import aspose.slides as slides

print("File | RevisionNumber | TotalEditingTime")
for path in Path("presentations").glob("*.pptx"):
    if path.is_file():
        info = slides.PresentationFactory.instance.get_presentation_info(str(path))
        properties = info.read_document_properties()
        print(f"{path.name} | {properties.revision_number} | {properties.total_editing_time}")
```

यदि किसी प्रस्तुति में 1 दिन, 2 घंटे और 5 मिनट का रिकॉर्ड किया गया संपादन समय है, तो रिपोर्ट में निम्न पंक्ति होगी।

```text
File | RevisionNumber | TotalEditingTime
long.pptx | 17 | 1 day, 2:05:00
```

[DocumentProperties.revision_number](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/revision_number/) लिखने योग्य मेटाडेटा है। इसका मान अकेले यह निर्धारित नहीं कर सकता कि प्रस्तुति कितनी बार सहेजी गई या उसका संस्करण इतिहास पुनः स्थापित कर सके।

[DocumentProperties.total_editing_time](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/total_editing_time/) फ़ाइल में संग्रहीत संपादन अवधि की रिपोर्ट करता है। `0:00:00` मान का अर्थ है कि रिकॉर्ड किया गया अवधि शून्य है, भले ही किसी ने प्रस्तुति संपादित की हो।

## **बिल्ट‑इन गुणों को संशोधित करें**

बिल्ट‑इन मेटाडेटा अपडेट करने के लिये, [Presentation.document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/document_properties/) द्वारा उजागर लिखने योग्य प्रॉपर्टीज़ को मान सौंपें। यह उदाहरण मौजूदा प्रस्तुति खोलता है, [DocumentProperties.author](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/author/), [DocumentProperties.title](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/title/), [DocumentProperties.subject](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/subject/), [DocumentProperties.comments](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/comments/), और [DocumentProperties.manager](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/manager/) सेट करता है, फिर [Presentation.save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) के साथ अपडेट की गई प्रस्तुति सहेजता है। सहेजा गया PPTX नया मेटाडेटा रखता है।

```python
import aspose.slides as slides

with slides.Presentation("ModifyBuiltInProperties.pptx") as presentation:
    document_properties = presentation.document_properties

    document_properties.author = "Aspose.Slides for Python via .NET"
    document_properties.title = "Manage PowerPoint Presentation Properties"
    document_properties.subject = "Modify Built-in Properties"
    document_properties.comments = "Aspose description"
    document_properties.manager = "Aspose manager"

    presentation.save("DocumentProperties_output.pptx", slides.export.SaveFormat.PPTX)
```

## **हाइपरलिंक बेस का प्रबंधन**

[DocumentProperties.hyperlink_base](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/hyperlink_base/) सापेक्ष हाइपरलिंक के लिए दस्तावेज़‑स्तर का बेस संग्रहीत करता है। यह तब उपयोगी होता है जब प्रस्तुति और उसकी लिंक्ड फ़ाइलें किसी अन्य स्थान पर स्थानांतरित की जाती हैं। यह व्यक्तिगत हाइपरलिंक के [Hyperlink.external_url](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/external_url/) से अलग है: बेस बदलने से संग्रहीत लिंक पते नहीं बदलते और न ही पूर्ण गंतव्य बदलते हैं।

उदाहरण के लिये ऐसी प्रस्तुति चाहिए जिसमें एक सापेक्ष लिंक, जैसे `target.html`, और एक पूर्ण लिंक किसी फ़ाइल या वेब साइट पर हो। यह मौजूदा बेस पढ़ता है, नया बेस पता असाइन करता है, और मूल्य जांचने के लिये प्रस्तुति सहेजकर पुनः खोलता है। फिर यह बेस को `""` से साफ़ करता है और अलग सहेजी फ़ाइल में खाली मान की पुष्टि करता है। उदाहरण बेस पते को अपने लिंक्ड फ़ाइलों के स्थान से बदलें।

```python
import aspose.slides as slides

with slides.Presentation("hyperlinks.pptx") as presentation:
    print("Original base:", presentation.document_properties.hyperlink_base)

    new_base = "https://example.com/new/"
    presentation.document_properties.hyperlink_base = new_base
    presentation.save("hyperlinks-updated.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("hyperlinks-updated.pptx") as updated_presentation:
    print("Base preserved:", updated_presentation.document_properties.hyperlink_base == new_base)

    updated_presentation.document_properties.hyperlink_base = ""
    updated_presentation.save("hyperlinks-cleared.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("hyperlinks-cleared.pptx") as cleared_presentation:
    print("Base cleared:", cleared_presentation.document_properties.hyperlink_base == "")
```

दोनों सत्यापन संदेश `True` प्रिंट करने चाहिए। बेस को साफ़ करने से व्यक्तिगत हाइपरलिंक पते अपरिवर्तित रहते हैं।

`target.pptx` का सापेक्ष लिंक तब `old/target.pptx` खोलता था जब बेस `old` फ़ोल्डर की ओर इशारा करता था। बेस को `new` फ़ोल्डर में बदलने, सहेजने और प्रस्तुति को पुनः खोलने के बाद वही लिंक `new/target.pptx` खोलता है। एक पूर्ण लिंक वही फ़ाइल खोलता ही रहता है। प्रस्तुति को स्थानांतरित करने या उसके बेस को बदलने से पहले और बाद में PowerPoint में अपने सापेक्ष लिंक का परीक्षण करें।

## **कस्टम प्रस्तुति गुण जोड़ें**

कस्टम गुण वह मेटाडेटा संग्रहीत करते हैं जिसका कोई संबंधित बिल्ट‑इन फ़ील्ड नहीं होता। [DocumentProperties.set_custom_property_value](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/set_custom_property_value/) मेथड आपको गुण नाम द्वारा मान असाइन करने की अनुमति देता है। यह उदाहरण एक प्रस्तुति बनाता है, दो टेक्स्ट मान और एक पूर्णांक संस्करण मान जोड़ता है, और [Presentation.save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) के साथ प्रस्तुति सहेजता है। मौजूदा नाम को मान असाइन करने से उस गुण का मान बदल जाता है।

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    document_properties = presentation.document_properties

    document_properties.set_custom_property_value("Reviewed by", "John Smith")
    document_properties.set_custom_property_value("Confidentiality level", "Internal")
    document_properties.set_custom_property_value("Document version", 2)

    presentation.save("CustomDocumentProperties_output.pptx", slides.export.SaveFormat.PPTX)
```

## **कस्टम गुणों तक पहुँचें और संशोधित करें**

यह उदाहरण कस्टम गुणों वाली प्रस्तुति खोलता है और उन पर इटरेट करने के लिये [DocumentProperties.count_of_custom_properties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/count_of_custom_properties/) का उपयोग करता है। [DocumentProperties.get_custom_property_name](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/get_custom_property_name/) शून्य‑आधारित इंडेक्स लेता है और [DocumentProperties.set_custom_property_value](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/set_custom_property_value/) द्वारा उपयोग किए गए नाम को लौटाता है। उदाहरण के लिये ऐसी प्रस्तुति चाहिए जिसकी कस्टम गुण सभी स्ट्रिंग हों। यह प्रत्येक मूल नाम और मान को प्रिंट करता है, प्रत्येक मान को क्रमांकित स्ट्रिंग से बदलता है, और परिवर्तन सहेजता है। यदि कोई कस्टम गुण नहीं है, तो लूप कोई परिवर्तन नहीं करता।

```python
import aspose.slides as slides

with slides.Presentation("AccessAndModifyProperties.pptx") as presentation:
    document_properties = presentation.document_properties

    for i in range(document_properties.count_of_custom_properties):
        property_name = document_properties.get_custom_property_name(i)
        property_value = [""]
        document_properties.get_custom_property_value(property_name, property_value)

        print("Custom property name:", property_name)
        print("Custom property value:", property_value[0])

        document_properties.set_custom_property_value(property_name, "New Value " + str(i + 1))

    presentation.save("CustomProperties_output.pptx", slides.export.SaveFormat.PPTX)
```

[DocumentProperties.get_custom_property_value](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/get_custom_property_value/) दूसरे तर्क में पास की गई एक‑तत्वीय सूची के माध्यम से मान लौटाता है। प्लेसहोल्डर को संग्रहीत गुण के प्रकार से मेल खाना चाहिए: स्ट्रिंग के लिये `[""]` या पूर्णांक के लिये `[0]` उपयोग करें। प्रकार में असंगति होने पर `InvalidCastException` उत्पन्न होती है; अपने कस्टम‑प्रॉपर्टी स्कीमा के अनुसार प्लेसहोल्डर चुनें।

## **सीधा उदाहरण**

Aspose.Slides API का उपयोग करके दस्तावेज़ गुणों के साथ काम करने का तरीका देखने के लिये ऑनलाइन ऐप [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/metadata) आज़माएँ:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **FAQ**

**मैं प्रस्तुति से बिल्ट‑इन गुण कैसे हटाऊँ?**

बिल्ट‑इन गुण प्रस्तुति का अभिन्न हिस्सा होते हैं और उन्हें पूरी तरह हटाया नहीं जा सकता। हालांकि, आप उनके मान बदल सकते हैं या विशिष्ट गुण की अनुमति होने पर उन्हें खाली सेट कर सकते हैं।

**यदि मैं ऐसा कस्टम गुण जोड़ूँ जो पहले से मौजूद है तो क्या होगा?**

यदि आप ऐसा कस्टम गुण जोड़ते हैं जो पहले से मौजूद है, तो उसका मौजूदा मान नए मान से ओवरराइट हो जाएगा। आपको पहले से गुण को हटाने या जाँचने की आवश्यकता नहीं है, क्योंकि Aspose.Slides स्वतः ही गुण के मान को अपडेट कर देता है।

**क्या मैं पूरी प्रस्तुति लोड किए बिना प्रस्तुति गुणों तक पहुँच सकता हूँ?**

हाँ। [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/python-net/aspose.slides/presentationfactory/get_presentation_info/) का उपयोग करें और फिर [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/read_document_properties/) के माध्यम से stored दस्तावेज़ मेटाडेटा को बिना [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) इंस्टैंस बनाए पढ़ें। पूर्ण रिपोर्टिंग उदाहरण और फ़ॉर्मेट‑विशिष्ट प्रतिबंधों के लिये [Build a Lightweight Presentation Inventory](/slides/hi/python-net/examine-presentation/) देखें।

**क्या मैं एन्क्रिप्टेड प्रस्तुति के सार्वजनिक गुणों को बिना खोलने वाले पासवर्ड के पढ़ सकता हूँ?**

हाँ। प्रस्तुति को [ProtectionManager.encrypt_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/encrypt_document_properties/) को `False` पर सेट करके एन्क्रिप्ट किया गया होना चाहिए, और इसे [LoadOptions.only_load_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/only_load_document_properties/) को `True` पर सेट करके लोड किया जाना चाहिए।

**क्या मैं दस्तावेज़‑गुण‑केवल मोड में एन्क्रिप्टेड PPTX फ़ाइल को अपडेट कर सकता हूँ?**

नहीं। सार्वजनिक और एन्क्रिप्टेड गुण डेटा को संगत रहना चाहिए, इसलिए एन्क्रिप्टेड PPTX फ़ाइल को अपडेट करने के लिये सही खोलने वाले पासवर्ड के साथ पूरी प्रस्तुति को लोड करना आवश्यक है।