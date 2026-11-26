---
title: "Python में प्रस्तुति गुणों का प्रबंधन"
linktitle: "प्रस्तुति गुण"
type: docs
weight: 70
url: /hi/python-java/presentation-properties/
keywords:
- "PowerPoint गुण"
- "प्रस्तुति गुण"
- "दस्तावेज़ गुण"
- "बिल्ट‑इन गुण"
- "कस्टम गुण"
- "उन्नत गुण"
- "गुणों का प्रबंधन"
- "गुणों में संशोधन"
- "दस्तावेज़ मेटाडेटा"
- "मेटाडेटा संपादित करें"
- "प्रूफ़िंग भाषा"
- "डिफ़ॉल्ट भाषा"
- "PowerPoint"
- "OpenDocument"
- "प्रस्तुति"
- "Python"
- "Aspose.Slides"
description: "Aspose.Slides for Python via Java में प्रस्तुति गुणों को मास्टर करें और अपने PowerPoint और OpenDocument फ़ाइलों में खोज, ब्रांडिंग और कार्यप्रवाह को सुव्यवस्थित करें।"
---
## **परिचय**

Aspose.Slides for Python via Java **बिल्ट‑इन** और **कस्टम** दस्तावेज़ गुणों को समर्थन देता है। इन गुणों का उपयोग प्रस्तुति मेटाडेटा को पढ़ने और अपडेट करने के लिए किया जाता है, जैसे लेखक, शीर्षक, और उपयोगकर्ता‑परिभाषित मान।

Aspose.Slides आपको प्रस्तुति दस्तावेज़ गुणों के साथ काम करने की अनुमति देता है [DocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/) क्लास के माध्यम से। इस क्लास का एक उदाहरण [Presentation.getDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getDocumentProperties) द्वारा लौटाया जाता है। निम्नलिखित उदाहरण दिखाते हैं कि इन गुणों को कैसे पढ़ा, संशोधित और प्रबंधित किया जाए।

{{% alert color="info" title="Note" %}}
Aspose.Slides प्रस्तुतियों को सहेजते समय एप्लिकेशन और प्रोड्यूसर मेटाडेटा को प्रबंधित करता है; ये फ़ील्ड उस सॉफ़्टवेयर की पहचान करती हैं जिसने आउटपुट बनाया।
{{% /alert %}}

## **प्रस्तुति गुणों का प्रबंधन**

Document properties प्रस्तुति सामग्री के साथ वर्णनात्मक जानकारी संग्रहीत करती हैं। वे दो वर्गों में विभाजित होती हैं:

- **बिल्ट‑इन गुण** मानक मेटाडेटा रखते हैं, जैसे शीर्षक, लेखक, और दस्तावेज़ आँकड़े।
- **कस्टम गुण** उपयोगकर्ता‑परिभाषित नाम/मान जोड़े संग्रहीत करते हैं।

Aspose.Slides for Python via Java दोनों वर्गों तक पहुँच प्रदान करता है। PowerPoint में, दस्तावेज़ मेटाडेटा देखने के लिए **File → Info → Properties → Advanced Properties** चुनें। संवाद जानकारी को **Summary**, **Statistics**, **Contents**, और **Custom** टैब में समूहित करता है। उपयोगकर्ता‑परिभाषित गुणों को प्रबंधित करने के लिए **Custom** टैब का उपयोग करें।

## **एन्क्रिप्टेड प्रस्तुति से सार्वजनिक गुण पढ़ें**

एक खोलने वाला पासवर्ड सामान्यतः प्रस्तुति सामग्री और दस्तावेज़ गुण दोनों को सुरक्षित रखता है। जब प्रस्तुति को [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) को `False` के साथ बुलाकर एन्क्रिप्ट किया जाता है, उसका दस्तावेज़ गुण सार्वजनिक रहता है। फिर एप्लिकेशन [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) को `True` के साथ बुलाकर खोलने वाला पासवर्ड प्रदान किए बिना सार्वजनिक मेटाडेटा पढ़ सकता है।

[LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) यह नियंत्रित करता है कि Aspose.Slides क्या लोड करता है; यह कुछ भी डिक्रिप्ट नहीं करता। यदि गुण एन्क्रिप्शन में शामिल थे, तो पासवर्ड के बिना उन्हें लोड करना विफल रहेगा। यदि प्रस्तुति एन्क्रिप्टेड नहीं है, तो यह विकल्प अनदेखा किया जाता है और पूरी प्रस्तुति लोड हो जाती है।

यह उदाहरण एक एन्क्रिप्टेड प्रस्तुति की आवश्यकता रखता है जिसके दस्तावेज़ गुण सार्वजनिक छोड़ दिए गये हों। यह लोडिंग मोड को [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/python-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) के माध्यम से जाँचता है और फिर [Presentation.getDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getDocumentProperties) से बिल्ट‑इन गुण पढ़ता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, LoadOptions

load_options = LoadOptions()
load_options.setOnlyLoadDocumentProperties(True)

presentation = Presentation("public-properties-encrypted.pptx", load_options)
try:
    if presentation.getProtectionManager().isOnlyDocumentPropertiesLoaded():
        properties = presentation.getDocumentProperties()

        print("Author: ", properties.getAuthor())
        print("Title: ", properties.getTitle())
        print("Keywords: ", properties.getKeywords())
    else:
        print("The presentation was not loaded in document-properties-only mode.")

finally:
    presentation.dispose()
```

इस मोड में स्लाइड सामग्री लोड नहीं होती। स्लाइड्स, मास्टर, लेआउट, शैप्स, मीडिया और अन्य प्रस्तुति ऑब्जेक्ट उपलब्ध नहीं होते। एप्लिकेशन को हमेशा [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/python-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) जाँचना चाहिए इससे पहले कि वह ऐसी कार्रवाई करे जो पूरी प्रस्तुति ऑब्जेक्ट मॉडल की आवश्यकता रखती हो।

{{% alert color="warning" title="Warning" %}}
सार्वजनिक मेटाडेटा में लेखक नाम, शीर्षक, विषय, कुंजी‑शब्द, कंपनी जानकारी, टिप्पणी, और कस्टम मान दिख सकते हैं। संवेदनशील गुणों को प्रस्तुति के साथ एन्क्रिप्ट करें। इन्हें केवल तभी सार्वजनिक रखें जब इंडेक्सिंग, वर्गीकरण, खोज, या दस्तावेज़‑प्रबंधन सिस्टम को पासवर्ड‑बिना एक्सेस करने की विशिष्ट आवश्यकता हो।
{{% /alert %}}

## **एन्क्रिप्टेड प्रस्तुति के गुण अपडेट करें**

एक एन्क्रिप्टेड PPTX फ़ाइल के लिए, [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) को `True` के साथ बुलाकर लोड किया गया प्रस्तुति केवल सार्वजनिक मेटाडेटा पढ़ने के उद्देश्य से होता है। Aspose.Slides उस मेटाडेटा‑केवल ऑब्जेक्ट से बदले हुए गुणों को सहेज नहीं सकता क्योंकि सार्वजनिक गुणों को एन्क्रिप्टेड प्रस्तुति के भीतर संबंधित डेटा के साथ सुसंगत रहना चाहिए। इसलिए अपडेट करने के लिए सही खोलने वाला पासवर्ड और पूरी लोड आवश्यक है।

यह उदाहरण एक एन्क्रिप्टेड PPTX प्रस्तुति की आवश्यकता रखता है जिसमें सार्वजनिक दस्तावेज़ गुण और ज्ञात खोलने वाला पासवर्ड हो। यह पूरी प्रस्तुति को [LoadOptions.setPassword](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setPassword) के साथ खोलता है, सार्वजनिक बिल्ट‑इन गुण अपडेट करता है, और परिणाम सहेजता है। फिर यह [PresentationInfo.isEncrypted](https://reference.aspose.com/slides/python-java/aspose.slides/presentationinfo/#isEncrypted) का उपयोग करके एन्क्रिप्शन बना रहे होने की पुष्टि करता है और पासवर्ड‑बिना सार्वजनिक मेटाडेटा को फिर से खोलकर नई मानों की जाँच करता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, LoadOptions, PresentationFactory, SaveFormat

input_path = "public-properties-encrypted.pptx"
output_path = "updated-public-properties-encrypted.pptx"

load_options = LoadOptions()
load_options.setPassword("open_password")

presentation = Presentation(input_path, load_options)
try:
    presentation.getDocumentProperties().setTitle("Updated Product Roadmap")
    presentation.getDocumentProperties().setKeywords("roadmap, planning, indexed")
    
    presentation.save(output_path, SaveFormat.Pptx)
finally:
    presentation.dispose()

presentation_info = PresentationFactory.getInstance().getPresentationInfo(output_path)
print("The presentation is encrypted: ", presentation_info.isEncrypted())

metadata_load_options = LoadOptions()
metadata_load_options.setOnlyLoadDocumentProperties(True)

metadata_presentation = Presentation(output_path, metadata_load_options)
try:
    if metadata_presentation.getProtectionManager().isOnlyDocumentPropertiesLoaded():
        print("Title: ", metadata_presentation.getDocumentProperties().getTitle())
        print("Keywords: ", metadata_presentation.getDocumentProperties().getKeywords())
    else:
        print("The presentation was not loaded in document-properties-only mode.")

finally:
    metadata_presentation.dispose()
```

यदि कोई एप्लिकेशन प्रस्तुति सामग्री को डिक्रिप्ट या लोड करने की अनुमति नहीं रखता, तो उसे एन्क्रिप्टेड PPTX फ़ाइल के सार्वजनिक गुणों को केवल‑पढ़ने‑योग्य मानना चाहिए।

## **बिल्ट‑इन गुणों का एक्सेस**

[DocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/) क्लास गेटर मेथड्स के माध्यम से बिल्ट‑इन मेटाडेटा प्रदान करती है, जिसमें [getAuthor](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getAuthor), [getTitle](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getTitle), और [getCreatedTime](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getCreatedTime) शामिल हैं। यह उदाहरण एक मौजूदा प्रस्तुति खोलता है और उसके संग्रहीत मेटाडेटा को कंसोल में प्रिंट करता है। मान इनपुट प्रस्तुति पर निर्भर करते हैं; कुछ फ़ील्ड खाली हो सकते हैं।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("AccessBuiltInProperties.pptx")
try:
    document_properties = presentation.getDocumentProperties()

    print("Category:", document_properties.getCategory())
    print("Content status:", document_properties.getContentStatus())
    print("Creation date:", document_properties.getCreatedTime())
    print("Author:", document_properties.getAuthor())
    print("Comments:", document_properties.getComments())
    print("Keywords:", document_properties.getKeywords())
    print("Last modified by:", document_properties.getLastSavedBy())
    print("Manager:", document_properties.getManager())
    print("Modified date:", document_properties.getLastSavedTime())
    print("Presentation format:", document_properties.getPresentationFormat())
    print("Last print date:", document_properties.getLastPrinted())
    print("Is shared between producers:", document_properties.getSharedDoc())
    print("Subject:", document_properties.getSubject())
    print("Title:", document_properties.getTitle())
finally:
    presentation.dispose()
```

### **रिवीजन नंबर और संपादन समय रिपोर्ट करें**

`presentations` फ़ोल्डर में प्रत्येक PPTX फ़ाइल के लिए एक पंक्ति रिपोर्ट करने हेतु, [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/python-java/aspose.slides/presentationfactory/#getPresentationInfo) और [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentationinfo/#readDocumentProperties) का उपयोग करके स्लाइड्स को लोड किए बिना उसके [DocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/) को पढ़ा जाता है। Python via Java API संपादन अवधि को मिलीसेकंड में लौटाता है। उदाहरण इसे घंटे, मिनट और सेकंड में फ़ॉर्मेट करता है, और 24 घंटे या अधिक अवधि के लिए दिन गिनती भी दिखाता है।

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PresentationFactory

factory = PresentationFactory.getInstance()
print("File | RevisionNumber | TotalEditingTime")
for path in sorted(Path("presentations").glob("*.pptx")):
    if not path.is_file():
        continue

    info = factory.getPresentationInfo(str(path))
    properties = info.readDocumentProperties()
    total_seconds = int(properties.getTotalEditingTime()) // 1000
    days, remaining_seconds = divmod(total_seconds, 86400)
    hours, remaining_seconds = divmod(remaining_seconds, 3600)
    minutes, seconds = divmod(remaining_seconds, 60)
    editing_time = f"{hours:02d}:{minutes:02d}:{seconds:02d}"
    if days:
        editing_time = f"{days}.{editing_time}"

    print(f"{path.name} | {properties.getRevisionNumber()} | {editing_time}")
```

1 दिन, 2 घंटे और 5 मिनट की रिकॉर्डेड संपादन समय वाली प्रस्तुति के लिए रिपोर्ट निम्न आउटपुट दर्शाती है।

```text
File | RevisionNumber | TotalEditingTime
long.pptx | 17 | 1.02:05:00
```

[getRevisionNumber](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getRevisionNumber) वह मान पढ़ता है जिसे एप्लिकेशन [setRevisionNumber](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setRevisionNumber) से बदल सकते हैं। केवल रिवीजन नंबर यह निर्धारित नहीं कर सकता कि प्रस्तुति कितनी बार सहेजी गई या उसका संस्करण इतिहास क्या है।

[getTotalEditingTime](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getTotalEditingTime) फ़ाइल में रिकॉर्डेड संपादन अवधि पढ़ता है। `00:00:00` का मान दर्शाता है कि संग्रहित अवधि शून्य है, भले ही किसी ने प्रस्तुति को संपादित किया हो।

## **बिल्ट‑इन गुणों को संशोधित करें**

बिल्ट‑इन मेटाडेटा अपडेट करने के लिए, [Presentation.getDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getDocumentProperties) द्वारा लौटाए गए ऑब्जेक्ट पर सेट्टर मेथड्स का उपयोग करें। यह उदाहरण एक मौजूदा प्रस्तुति खोलता है, [setAuthor](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setAuthor), [setTitle](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setTitle), [setSubject](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setSubject), [setComments](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setComments), और [setManager](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setManager) को कॉल करता है, फिर [Presentation.save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) से अद्यतन प्रस्तुति सहेजता है। सहेजी गई PPTX में नया मेटाडेटा होगा।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("ModifyBuiltInProperties.pptx")
try:
    document_properties = presentation.getDocumentProperties()

    document_properties.setAuthor("Aspose.Slides for Python via Java")
    document_properties.setTitle("Manage PowerPoint Presentation Properties")
    document_properties.setSubject("Modify Built-in Properties")
    document_properties.setComments("Aspose description")
    document_properties.setManager("Aspose manager")

    presentation.save("DocumentProperties_output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **हायपरलिंक बेस प्रबंधन**

[DocumentProperties.getHyperlinkBase](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getHyperlinkBase) रिलेटिव हाइपरलिंक्स के लिए दस्तावेज़‑स्तर बेस लौटाता है। इसे बदलने या साफ़ करने के लिए [DocumentProperties.setHyperlinkBase](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setHyperlinkBase) का उपयोग करें। यह तब उपयोगी होता है जब आप प्रस्तुति और उसकी लिंक्ड फाइलों को किसी अन्य स्थान पर ले जाते हैं। यह व्यक्तिगत हाइपरलिंक के [Hyperlink.getExternalUrl](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#getExternalUrl) से अलग है: बेस बदलने से संग्रहीत लिंक पते नहीं बदलते और न ही निरपेक्ष गंतव्य बदलता है।

यह उदाहरण एक ऐसी प्रस्तुति की आवश्यकता रखता है जिसमें एक रिलेटिव लिंक (`target.html`) और एक एब्सॉल्यूट लिंक (`https://example.org/absolute.html`) दोनों हों। यह मौजूदा बेस पढ़ता है, नया बेस पता असाइन करता है, फिर मूल्य जाँचने के लिए प्रस्तुति को सहेजता और पुनः खोलता है। फिर यह बेस को खाली स्ट्रिंग से साफ़ करता है और एक अलग सहेजी फ़ाइल में खाली मान की पुष्टि करता है। उदाहरण बेस पते को अपने लिंक्ड फ़ाइलों के स्थान से बदलें।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("hyperlinks.pptx")
try:
    print("Original base:", presentation.getDocumentProperties().getHyperlinkBase())

    new_base = "https://example.com/new/"
    presentation.getDocumentProperties().setHyperlinkBase(new_base)
    presentation.save("hyperlinks-updated.pptx", SaveFormat.Pptx)

    updated_presentation = Presentation("hyperlinks-updated.pptx")
    try:
        print("Base preserved:", new_base == updated_presentation.getDocumentProperties().getHyperlinkBase())

        updated_presentation.getDocumentProperties().setHyperlinkBase("")
        updated_presentation.save("hyperlinks-cleared.pptx", SaveFormat.Pptx)

        cleared_presentation = Presentation("hyperlinks-cleared.pptx")
        try:
            print("Base cleared:", "" == cleared_presentation.getDocumentProperties().getHyperlinkBase())
        finally:
            cleared_presentation.dispose()
    finally:
        updated_presentation.dispose()
finally:
    presentation.dispose()
```

दो वैरिफिकेशन संदेश `True` प्रिंट करने चाहिए। बेस साफ़ करने से व्यक्तिगत हाइपरलिंक एड्रेस अपरिवर्तित रहता है।

यदि बेस `old` फ़ोल्डर की ओर इशारा कर रहा था, तो रिलेटिव लिंक `target.pptx` `old/target.pptx` खोलता था। बेस को `new` फ़ोल्डर में बदलने, सहेजने और पुनः खोलने के बाद वही लिंक `new/target.pptx` खोलता है। एब्सॉल्यूट लिंक वही फ़ाइल खोलता रहता है। बेस बदलने या प्रस्तुति को स्थानांतरित करने से पहले और बाद में अपने रिलेटिव लिंक को PowerPoint में परीक्षण करें।

## **कस्टम प्रस्तुति गुण जोड़ें**

कस्टम गुण उन मेटाडेटा को संग्रहीत करते हैं जिनका कोई बिल्ट‑इन फ़ील्ड नहीं होता। [DocumentProperties.set_Item](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#set_Item) मेथड आपको गुण नाम से मान असाइन करने की अनुमति देता है। यह उदाहरण एक प्रस्तुति बनाता है, दो टेक्स्ट मान और एक पूर्णांक संस्करण मान (`jpype.JInt` का उपयोग करके जावा पूर्णांक पास किया गया) जोड़ता है, और [Presentation.save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) से प्रस्तुति सहेजता है। मौजूदा नाम को पुनः असाइन करने से वह गुण का मान बदल जाता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    document_properties = presentation.getDocumentProperties()

    document_properties.set_Item("Reviewed by", "John Smith")
    document_properties.set_Item("Confidentiality level", "Internal")
    document_properties.set_Item("Document version", jpype.JInt(2))

    presentation.save("CustomDocumentProperties_output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **कस्टम गुणों का एक्सेस और संशोधन**

यह उदाहरण कस्टम गुणों वाले प्रस्तुति को खोलता है और [getCountOfCustomProperties](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getCountOfCustomProperties) से उनका आयतन लेता है। [getCustomPropertyName](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getCustomPropertyName) शून्य‑आधारित इंडेक्स लेता है और वह नाम लौटाता है जिसका उपयोग [DocumentProperties.set_Item](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#set_Item) किया गया था। उदाहरण प्रत्येक मूल नाम और मान को प्रिंट करता है, सभी मानों को क्रमिक स्ट्रिंग से बदल देता है, और बदलाव सहेजता है। यदि कस्टम गुण नहीं हैं, तो लूप कोई परिवर्तन नहीं करता।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("AccessAndModifyProperties.pptx")
try:
    document_properties = presentation.getDocumentProperties()

    for i in range(document_properties.getCountOfCustomProperties()):
        property_name = document_properties.getCustomPropertyName(i)
        property_value = document_properties.get_Item(property_name)

        print("Custom property name:", property_name)
        print("Custom property value:", property_value)

        document_properties.set_Item(property_name, f"New Value {i + 1}")

    presentation.save("CustomProperties_output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **लाइव उदाहरण**

ऑनलाइन ऐप [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/metadata) को आज़माएँ और Aspose.Slides API के साथ दस्तावेज़ गुणों के साथ काम करने का तरीका देखें:

[![PowerPoint मेटाडेटा देखें और संपादित करें](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **FAQ**

**एक प्रस्तुति से बिल्ट‑इन गुण को कैसे हटाएँ?**

बिल्ट‑इन गुण प्रस्तुति का अभिन्न हिस्सा होते हैं और उन्हें पूरी तरह हटाया नहीं जा सकता। हालांकि, आप उनके मान बदल सकते हैं या, यदि संबंधित गुण अनुमति देता है, तो उन्हें खाली सेट कर सकते हैं।

**यदि मैं ऐसा कस्टम गुण जोड़ूँ जो पहले से मौजूद है तो क्या होगा?**

यदि आप ऐसा कस्टम गुण जोड़ते हैं जो पहले से मौजूद है, तो उसका मौजूदा मान नए मान से ओवरराइट हो जाएगा। आपको पहले से हटाने या जांचने की जरूरत नहीं है; Aspose.Slides स्वतः ही गुण के मान को अपडेट कर देता है।

**क्या मैं पूरी प्रस्तुति को लोड किए बिना प्रस्तुति गुणों तक पहुँच सकता हूँ?**

हाँ। पहले [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/python-java/aspose.slides/presentationfactory/#getPresentationInfo) को कॉल करें और फिर [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentationinfo/#readDocumentProperties) का उपयोग करके दस्तावेज़ मेटाडेटा पढ़ें, बिना [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) इंस्टेंस बनाये। पूर्ण रिपोर्टिंग उदाहरण और फ़ॉर्मेट‑विशिष्ट सीमाओं के लिए देखें [Build a Lightweight Presentation Inventory](/slides/hi/python-java/examine-presentation/)।

**क्या मैं एन्क्रिप्टेड प्रस्तुति के सार्वजनिक गुणों को उसके खोलने वाले पासवर्ड के बिना पढ़ सकता हूँ?**

हाँ। प्रस्तुति को [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) को `False` के साथ बुलाकर एन्क्रिप्ट किया जाना चाहिए, और इसे [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) को `True` के साथ बुलाकर लोड किया जाना चाहिए।

**क्या मैं डॉक्यूमेंट‑प्रॉपर्टीज‑ओनली मोड में एन्क्रिप्टेड PPTX फ़ाइल को अपडेट कर सकता हूँ?**

नहीं। सार्वजनिक और एन्क्रिप्टेड गुण डेटा को सुसंगत रहना चाहिए, इसलिए एन्क्रिप्टेड PPTX फ़ाइल को अपडेट करने के लिए सही खोलने वाला पासवर्ड के साथ पूरी प्रस्तुति को लोड करना आवश्यक है।