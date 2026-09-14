---
title: "Python में प्रस्तुति प्रॉपर्टीज़ का प्रबंधन"
linktitle: "प्रस्तुति प्रॉपर्टीज़"
type: docs
weight: 70
url: /hi/python-java/presentation-properties/
keywords:
- "PowerPoint प्रॉपर्टीज़"
- "प्रस्तुति प्रॉपर्टीज़"
- "दस्तावेज़ प्रॉपर्टीज़"
- "बिल्ट‑इन प्रॉपर्टीज़"
- "कस्टम प्रॉपर्टीज़"
- "उन्नत प्रॉपर्टीज़"
- "प्रॉपर्टीज़ प्रबंधित करें"
- "प्रॉपर्टीज़ संशोधित करें"
- "दस्तावेज़ मेटाडेटा"
- "मेटाडेटा संपादित करें"
- "प्रूफ़िंग भाषा"
- "डिफ़ॉल्ट भाषा"
- "PowerPoint"
- "OpenDocument"
- "प्रस्तुति"
- "Python"
- "Aspose.Slides"
description: "Aspose.Slides for Python via Java में प्रस्तुति प्रॉपर्टीज़ को मास्टर करें और अपने PowerPoint और OpenDocument फ़ाइलों में खोज, ब्रांडिंग और कार्यप्रवाह को सुव्यवस्थित करें।"
---
## **परिचय**

Aspose.Slides दो प्रकार की दस्तावेज़ प्रॉपर्टीज़ को समर्थन देता है: **Built-in** और **Custom**। इन दोनों प्रॉपर्टी प्रकारों को Aspose.Slides API का उपयोग करके आसानी से एक्सेस और प्रबंधित किया जा सकता है।

Aspose.Slides आपको प्रस्तुति दस्तावेज़ प्रॉपर्टीज़ के साथ काम करने की अनुमति देता है [DocumentProperties](https://reference.aspose.com/slides/hi/python-java/aspose.slides/documentproperties/) वर्ग के माध्यम से। इस वर्ग का एक उदाहरण [Presentation.getDocumentProperties](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#getDocumentProperties) द्वारा लौटाया जाता है। नीचे दिया गया उदाहरण दिखाता है कि इन प्रॉपर्टीज़ को कैसे पढ़ें, संशोधित करें और प्रबंधित करें।

{{% alert color="info" title="नोट" %}}
कृपया ध्यान दें कि **Application** और **AppVersion** फ़ील्ड को संशोधित नहीं किया जा सकता। Aspose.Slides प्रत्येक सेव पर इन्हें पुनः लिखता है, इसलिए सहेजी गई प्रस्तुति हमेशा "Aspose.Slides for Java" और लाइब्रेरी के संस्करण को रिपोर्ट करती है। कोई भी मान जो [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/hi/python-java/aspose.slides/documentproperties/#setNameOfApplication) को पास किया जाता है, प्रस्तुति लिखते समय त्याग दिया जाता है।
{{% /alert %}}

## **PowerPoint में दस्तावेज़ प्रॉपर्टीज़**

Microsoft PowerPoint 2007 आपको प्रस्तुति फ़ाइलों की दस्तावेज़ प्रॉपर्टीज़ को प्रबंधित करने की अनुमति देता है। नीचे दिखाए अनुसार Office आइकन पर क्लिक करें और **Prepare | Properties | Advanced Properties** चुनें:

|**Advanced Properties मेनू आइटम चुनना**|
| :- |
|![PowerPoint document properties](https://i.imgur.com/ZrmuCD6.jpg)|

**Advanced Properties** चुनने के बाद, एक डायलॉग प्रकट होता है जहाँ आप PowerPoint फ़ाइल की दस्तावेज़ प्रॉपर्टीज़ को प्रबंधित कर सकते हैं:

|**Properties Dialog**|
| :- |
|![PowerPoint document properties](https://i.imgur.com/LibmdQd.jpg)|

**Properties Dialog** में **General**, **Summary**, **Statistics**, **Contents**, और **Custom** जैसे टैब होते हैं। ये टैब PowerPoint फ़ाइलों के विभिन्न प्रकार की जानकारी को कॉन्फ़िगर करने की अनुमति देते हैं। कस्टम प्रॉपर्टीज़ को प्रबंधित करने के लिए **Custom** टैब का उपयोग करें।

## **Python via Java के लिए Aspose.Slides के साथ दस्तावेज़ प्रॉपर्टीज़ पर काम करना**

जैसा कि पहले बताया गया, Python via Java के लिए Aspose.Slides दोनों **Built-in** और **Custom** दस्तावेज़ प्रॉपर्टीज़ का समर्थन करता है। [DocumentProperties](https://reference.aspose.com/slides/hi/python-java/aspose.slides/documentproperties/) वर्ग एक प्रस्तुति फ़ाइल से जुड़े दस्तावेज़ प्रॉपर्टीज़ को दर्शाता है।

इन प्रॉपर्टीज़ को एक्सेस करने के लिए नीचे वर्णित अनुसार [Presentation.getDocumentProperties](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#getDocumentProperties) का उपयोग करें।

## **एन्क्रिप्टेड प्रस्तुति से सार्वजनिक प्रॉपर्टीज़ पढ़ना**

एक ओपनिंग पासवर्ड सामान्यतः प्रस्तुति सामग्री और दस्तावेज़ प्रॉपर्टीज़ दोनों की सुरक्षा करता है। जब किसी प्रस्तुति को `false` पास करके [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/hi/python-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) एन्क्रिप्ट किया जाता है, तो उसकी दस्तावेज़ प्रॉपर्टीज़ सार्वजनिक रहती हैं। तब कोई एप्लीकेशन `true` पास करके [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/hi/python-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) को पास कर सकता है और ओपनिंग पासवर्ड दिए बिना सार्वजनिक मेटाडेटा पढ़ सकता है।

`document-properties-only` विकल्प नियंत्रित करता है कि Aspose.Slides क्या लोड करता है; यह कुछ भी डिक्रिप्ट नहीं करता। यदि प्रॉपर्टीज़ एन्क्रिप्शन में शामिल थीं, तो पासवर्ड के बिना उन्हें लोड करना विफल होता है। यदि प्रस्तुति एन्क्रिप्ट नहीं है, तो यह विकल्प अनदेखा किया जाता है और पूरी प्रस्तुति लोड हो जाती है।

निम्न उदाहरण [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/hi/python-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) के माध्यम से लोडिंग मोड की जाँच करता है और फिर [Presentation.getDocumentProperties](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#getDocumentProperties) के माध्यम से बिल्ट‑इन प्रॉपर्टीज़ पढ़ता है:

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

इस मोड में स्लाइड सामग्री लोड नहीं होती। स्लाइड्स, मास्टर्स, लेआउट्स, शेप्स, मीडिया और अन्य प्रस्तुति ऑब्जेक्ट्स अनुपलब्ध होते हैं। एप्लीकेशन को हमेशा [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/hi/python-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) की जाँच करनी चाहिए इससे पहले कि वह कोई ऑपरेशन करे जिसके लिये पूरी प्रस्तुति ऑब्जेक्ट मॉडल की आवश्यकता हो।

{{% alert color="warning" title="चेतावनी" %}}
सार्वजनिक मेटाडेटा लेखक के नाम, शीर्षक, विषय, कीवर्ड, कंपनी जानकारी, टिप्पणी और कस्टम मानों को उजागर कर सकता है। संवेदनशील प्रॉपर्टीज़ को प्रस्तुति के साथ एन्क्रिप्ट करें। उन्हें केवल तब सार्वजनिक रखें जब इंडेक्सिंग, वर्गीकरण, खोज, या दस्तावेज़‑प्रबंधन प्रणालियों को पासवर्ड के बिना विशेष पहुंच की आवश्यकता हो।
{{% /alert %}}

## **एन्क्रिप्टेड प्रस्तुति की प्रॉपर्टीज़ अपडेट करना**

एक एन्क्रिप्टेड PPTX फ़ाइल के लिये, `document-properties-only` मोड में लोड की गई प्रस्तुति सार्वजनिक मेटाडेटा पढ़ने के लिये अभिप्रेत है। Aspose.Slides उस मेटाडेटा‑ओनली ऑब्जेक्ट से बदली गई प्रॉपर्टीज़ को सहेज नहीं सकता क्योंकि सार्वजनिक प्रॉपर्टीज़ को एन्क्रिप्टेड प्रस्तुति के भीतर संबंधित डेटा के साथ सुसंगत रहना चाहिए। इसलिए उन्हें अपडेट करने के लिये सही ओपनिंग पासवर्ड और पूर्ण लोड आवश्यक है।

निम्न उदाहरण [LoadOptions.setPassword](https://reference.aspose.com/slides/hi/python-java/aspose.slides/loadoptions/#setPassword) के साथ प्रस्तुति खोलता है, सार्वजनिक बिल्ट‑इन प्रॉपर्टीज़ को अपडेट करता है, और परिणाम सहेजता है। फिर यह [PresentationInfo.isEncrypted](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentationinfo/#isEncrypted) का उपयोग करके यह जाँचता है कि एन्क्रिप्शन बरकरार है और पासवर्ड के बिना सार्वजनिक मेटाडेटा को फिर से खोलकर नई मानों की पुष्टि करता है:

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

यदि कोई एप्लीकेशन प्रस्तुति सामग्री को डिक्रिप्ट या लोड करने की अनुमति नहीं रखता, तो उसे एन्क्रिप्टेड PPTX फ़ाइल की सार्वजनिक प्रॉपर्टीज़ को केवल‑पढ़ने योग्य मानना चाहिए।

## **Built-in प्रॉपर्टीज़ तक पहुंचना**

[DocumentProperties](https://reference.aspose.com/slides/hi/python-java/aspose.slides/documentproperties/) द्वारा एक्सपोज़ की गई बिल्ट‑इन प्रॉपर्टीज़ में शामिल हैं: **Creator** (Author), **Description**, **Created** (Creation Date), **Modified** (Modification Date), **Printed** (Last Print Date), **LastModifiedBy**, **Keywords**, **SharedDoc** (Is shared between different producers?), **PresentationFormat**, **Subject**, और **Title**।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, DocumentProperties

# प्रस्तुति को दर्शाने वाली Presentation क्लास का इंस्टेंस बनाएं
presentation = Presentation("Presentation.pptx")
try:
    # Presentation से जुड़े DocumentProperties ऑब्जेक्ट का रेफरेंस बनाएं
    properties = presentation.getDocumentProperties()

    # बिल्ट‑इन प्रॉपर्टीज़ प्रदर्शित करें
    print("Category : ", properties.getCategory())
    print("Current Status : ", properties.getContentStatus())
    print("Creation Date : ", properties.getCreatedTime())
    print("Author : ", properties.getAuthor())
    print("Description : ", properties.getComments())
    print("KeyWords : ", properties.getKeywords())
    print("Last Modified By : ", properties.getLastSavedBy())
    print("Supervisor : ", properties.getManager())
    print("Modified Date : ", properties.getLastSavedTime())
    print("Presentation Format : ", properties.getPresentationFormat())
    print("Last Print Date : ", properties.getLastPrinted())
    print("Is Shared between producers : ", properties.getSharedDoc())
    print("Subject : ", properties.getSubject())
    print("Title : ", properties.getTitle())
finally:
    presentation.dispose()
```

## **Built-in प्रॉपर्टीज़ को संशोधित करना**

बिल्ट‑इन प्रॉपर्टीज़ को संशोधित करना उतना ही आसान है जितना उन्हें एक्सेस करना। नए मान सेट करने के लिये संबंधित सेट्टर का उपयोग करें। नीचे दिया गया उदाहरण Python via Java के लिए Aspose.Slides का उपयोग करके बिल्ट‑इन दस्तावेज़ प्रॉपर्टीज़ को संशोधित करता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, DocumentProperties

presentation = Presentation("Presentation.pptx")
try:
    # Presentation से जुड़े DocumentProperties ऑब्जेक्ट का रेफरेंस बनाएं
    properties = presentation.getDocumentProperties()

    # बिल्ट‑इन प्रॉपर्टीज़ सेट करें
    properties.setAuthor("Aspose.Slides for Python via Java")
    properties.setTitle("Modifying Presentation Properties")
    properties.setSubject("Aspose Subject")
    properties.setComments("Aspose Description")
    properties.setManager("Aspose Manager")

    # अपनी प्रस्तुति को फ़ाइल में सहेजें
    presentation.save("DocProps.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

यह उदाहरण प्रस्तुति की बिल्ट‑इन प्रॉपर्टीज़ को संशोधित करता है जिसे नीचे दर्शाया गया है:

|**संशोधन के बाद बिल्ट‑इन दस्तावेज़ प्रॉपर्टीज़**|
| :- |
|![PowerPoint document properties](https://i.imgur.com/zz1N9de.jpg)|

## **कस्टम दस्तावेज़ प्रॉपर्टीज़ जोड़ना**

Python via Java के लिए Aspose.Slides डेवलपर्स को प्रस्तुति में कस्टम दस्तावेज़ प्रॉपर्टीज़ जोड़ने की भी अनुमति देता है। नीचे दिया गया उदाहरण तीन कस्टम प्रॉपर्टीज़ जोड़ता है, फिर इंडेक्स 2 पर संग्रहीत नाम को खोजता है और उस प्रॉपर्टी को हटाता है, इसलिए सहेजी गई प्रस्तुति में केवल दो प्रॉपर्टीज़ रहती हैं। कस्टम प्रॉपर्टीज़ वर्णानुक्रम में इंडेक्स की जाती हैं, न कि जोड़ी जाने के क्रम में।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    # दस्तावेज़ प्रॉपर्टीज़ प्राप्त करना
    properties = presentation.getDocumentProperties()

    # कस्टम प्रॉपर्टीज़ जोड़ना
    properties.set_Item("New Custom", jpype.JInt(12))
    properties.set_Item("My Name", "Mudassir")
    properties.set_Item("Custom", jpype.JInt(124))

    # विशेष इंडेक्स पर प्रॉपर्टी नाम प्राप्त करना
    property_name = properties.getCustomPropertyName(2)

    # चयनित प्रॉपर्टी को हटाना
    properties.removeCustomProperty(property_name)

    # प्रस्तुति सहेजना
    presentation.save("CustomDemo.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

|**जोड़ी गई कस्टम दस्तावेज़ प्रॉपर्टीज़**|
| :- |
|![PowerPoint document properties](https://i.imgur.com/HdKcxI9.png)|

## **कस्टम प्रॉपर्टीज़ तक पहुंचना और संशोधित करना**

Python via Java के लिए Aspose.Slides डेवलपर्स को कस्टम प्रॉपर्टीज़ के मानों तक पहुँचने की भी अनुमति देता है। नीचे दिया गया उदाहरण सभी कस्टम प्रॉपर्टीज़ को एक्सेस और संशोधित करने का तरीका दिखाता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, DocumentProperties

presentation = Presentation("Presentation.pptx")
try:
    # Presentation से जुड़े DocumentProperties ऑब्जेक्ट का रेफरेंस बनाएं
    properties = presentation.getDocumentProperties()

    # कस्टम प्रॉपर्टीज़ को एक्सेस और संशोधित करें
    for i in range(properties.getCountOfCustomProperties()):
        property_name = properties.getCustomPropertyName(i)
        # कस्टम प्रॉपर्टीज़ के नाम और मान प्रदर्शित करें
        print("Custom Property Name : ", property_name)
        print("Custom Property Value : ", properties.get_Item(property_name))

        # कस्टम प्रॉपर्टीज़ के मान बदलें
        properties.set_Item(property_name, f"New Value {i + 1}")

    # अपनी प्रस्तुति को फ़ाइल में सहेजें
    presentation.save("CustomDemoModified.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

यह उदाहरण [PPTX](https://docs.fileformat.com/presentation/pptx/) प्रस्तुति की कस्टम प्रॉपर्टीज़ को संशोधित करता है। नीचे दिए गए चित्र संशोधन से पहले और बाद के कस्टम प्रॉपर्टीज़ को दर्शाते हैं:

|**संशोधन से पहले कस्टम प्रॉपर्टीज़**|
| :- |
|![PowerPoint document properties](https://i.imgur.com/Ze7YHvi.jpg)|

|**संशोधन के बाद कस्टम प्रॉपर्टीज़**|
| :- |
|![PowerPoint document properties](https://i.imgur.com/Tofu0CL.jpg)|

## **उन्नत दस्तावेज़ प्रॉपर्टीज़**

{{% alert color="info" title="नोट" %}}
नए मेथड्स [readDocumentProperties](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentationinfo/#readDocumentProperties), [updateDocumentProperties](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentationinfo/#updateDocumentProperties), और [writeBindedPresentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentationinfo/#writeBindedPresentation) को [PresentationInfo](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentationinfo/) में जोड़ा गया है, और [DocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/hi/python-java/aspose.slides/documentproperties/#setLastSavedTime) मेथड के व्यवहार में बदलाव किया गया है।
{{% /alert %}}

दो नए मेथड्स [readDocumentProperties](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentationinfo/#readDocumentProperties) और [updateDocumentProperties](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentationinfo/#updateDocumentProperties) को [PresentationInfo](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentationinfo/) क्लास में जोड़ा गया है। ये दस्तावेज़ प्रॉपर्टीज़ तक तेज़ पहुंच प्रदान करते हैं और पूरी प्रस्तुति लोड किए बिना प्रॉपर्टीज़ को बदलने और अपडेट करने की अनुमति देते हैं।

प्रॉपर्टीज़ को लोड करने, उनके मान बदलने, और दस्तावेज़ को अपडेट करने की सामान्य कार्यप्रवाह इस प्रकार कार्यान्वित किया जा सकता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PresentationFactory

# प्रेजेंटेशन जानकारी पढ़ें
presentation_info = PresentationFactory.getInstance().getPresentationInfo("presentation.pptx")

# वर्तमान प्रॉपर्टीज़ प्राप्त करें
properties = presentation_info.readDocumentProperties()

# Author और Title फ़ील्ड के नए मान सेट करें
properties.setAuthor("New Author")
properties.setTitle("New Title")

# नए मानों के साथ प्रेजेंटेशन को अपडेट करें
presentation_info.updateDocumentProperties(properties)
presentation_info.writeBindedPresentation("presentation.pptx")
```

किसी विशिष्ट प्रस्तुति की प्रॉपर्टीज़ को टेम्पलेट के रूप में उपयोग करके अन्य प्रस्तुतियों की प्रॉपर्टीज़ को अपडेट करने का एक और तरीका है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PresentationFactory

presentation_info = PresentationFactory.getInstance().getPresentationInfo("template.pptx")
template = presentation_info.readDocumentProperties()

template.setAuthor("Template Author")
template.setTitle("Template Title")
template.setCategory("Template Category")
template.setKeywords("Keyword1, Keyword2, Keyword3")
template.setCompany("Our Company")
template.setComments("Created from template")
template.setContentType("Template Content")
template.setSubject("Template Subject")

for path in ["doc1.pptx", "doc2.odp", "doc3.ppt"]:
    presentation_to_update = PresentationFactory.getInstance().getPresentationInfo(path)
    presentation_to_update.updateDocumentProperties(template)
    presentation_to_update.writeBindedPresentation(path)
```

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PresentationFactory

def update_by_template(path, template):
    presentation_to_update = PresentationFactory.getInstance().getPresentationInfo(path)
    presentation_to_update.updateDocumentProperties(template)
    presentation_to_update.writeBindedPresentation(path)
```

एक नया टेम्पलेट शून्य से बनाया जा सकता है और फिर कई प्रस्तुतियों को अपडेट करने के लिये उपयोग किया जा सकता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PresentationFactory, DocumentProperties

template = DocumentProperties()

template.setAuthor("Template Author")
template.setTitle("Template Title")
template.setCategory("Template Category")
template.setKeywords("Keyword1, Keyword2, Keyword3")
template.setCompany("Our Company")
template.setComments("Created from template")
template.setContentType("Template Content")
template.setSubject("Template Subject")

for path in ["doc1.pptx", "doc2.odp", "doc3.ppt"]:
    presentation_to_update = PresentationFactory.getInstance().getPresentationInfo(path)
    presentation_to_update.updateDocumentProperties(template)
    presentation_to_update.writeBindedPresentation(path)
```

## **प्रूफ़िंग भाषा सेट करना**

Aspose.Slides [PortionFormat.setLanguageId](https://reference.aspose.com/slides/hi/python-java/aspose.slides/portionformat/#setLanguageId) मेथड प्रदान करता है जिससे आप PowerPoint दस्तावेज़ की प्रूफ़िंग भाषा सेट कर सकते हैं। प्रूफ़िंग भाषा वह भाषा होती है जिसके लिये प्रस्तुति में वर्तनी और व्याकरण जांचे जाते हैं।

यह Python कोड आपको PowerPoint के लिये प्रूफ़िंग भाषा सेट करने का तरीका दिखाता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Portion, FontData

pptx_file_name = "presentation.pptx"

presentation = Presentation(pptx_file_name)
try:
    auto_shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)

    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)
    paragraph.getPortions().clear()

    new_portion = Portion()

    font = FontData("SimSun")
    portion_format = new_portion.getPortionFormat()
    portion_format.setComplexScriptFont(font)
    portion_format.setEastAsianFont(font)
    portion_format.setLatinFont(font)

    portion_format.setLanguageId("zh-CN") # प्रमाणन भाषा का Id सेट करें

    new_portion.setText("1。")
    paragraph.getPortions().add(new_portion)
finally:
    presentation.dispose()
```

## **डिफ़ॉल्ट भाषा सेट करना**

यह Python कोड आपको पूरी PowerPoint प्रस्तुति के लिये डिफ़ॉल्ट भाषा सेट करने का तरीका दिखाता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, LoadOptions, ShapeType

load_options = LoadOptions()
load_options.setDefaultTextLanguage("en-US")

presentation = Presentation(load_options)
try:
    # टेक्स्ट के साथ एक आयताकार आकार जोड़ता है
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50)
    shape.getTextFrame().setText("New Text")

    # पहले पोर्शन की भाषा जाँचता है
    print(shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId())
finally:
    presentation.dispose()
```

## **लाइव उदाहरण**

दस्तावेज़ प्रॉपर्टीज़ के साथ Aspose.Slides API के द्वारा काम करने का तरीका देखने के लिये ऑनलाइन एप्लिकेशन **[Aspose.Slides Metadata](https://products.aspose.app/slides/hi/metadata)** आज़माएँ:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/hi/metadata)

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं प्रस्तुति से बिल्ट‑इन प्रॉपर्टी को कैसे हटाएँ?**

बिल्ट‑इन प्रॉपर्टीज़ प्रस्तुति का अभिन्न भाग होती हैं और उन्हें पूरी तरह हटाया नहीं जा सकता। हालांकि, आप उनके मान बदल सकते हैं या, यदि विशेष प्रॉपर्टी अनुमति देती है, तो उन्हें खाली सेट कर सकते हैं।

**यदि मैं कोई कस्टम प्रॉपर्टी जोड़ूँ जो पहले से मौजूद है तो क्या होता है?**

यदि आप कोई कस्टम प्रॉपर्टी जोड़ते हैं जो पहले से मौजूद है, तो उसका मौजूदा मान नए मान से ओवरराइट हो जाएगा। आपको पहले प्रॉपर्टी को हटाने या जाँचने की आवश्यकता नहीं है, क्योंकि Aspose.Slides स्वतः ही मान को अपडेट कर देता है।

**क्या मैं पूरी प्रस्तुति लोड किए बिना प्रस्तुति प्रॉपर्टीज़ तक पहुंच सकता हूँ?**

हाँ। आप [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentationfactory/#getPresentationInfo) का उपयोग करके [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentationinfo/#readDocumentProperties) को कॉल कर सकते हैं, जिससे [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) इंस्टेंस बनाए बिना संग्रहित दस्तावेज़ मेटाडेटा पढ़ा जा सकता है। पूर्ण रिपोर्ट उदाहरण और फ़ॉर्मेट‑विशिष्ट सीमाओं के लिये देखें [Build a Lightweight Presentation Inventory](/slides/hi/python-java/examine-presentation/)।

**क्या मैं एन्क्रिप्टेड प्रस्तुति की सार्वजनिक प्रॉपर्टीज़ को उसके ओपनिंग पासवर्ड के बिना पढ़ सकता हूँ?**

हाँ। दस्तावेज़‑प्रॉपर्टी एन्क्रिप्शन को प्रस्तुति एन्क्रिप्ट होने से पहले निष्क्रिय किया होना चाहिए, और प्रस्तुति को `document-properties-only` मोड में लोड किया जाना चाहिए।

**क्या मैं `document-properties-only` मोड में एन्क्रिप्टेड PPTX फ़ाइल को अपडेट कर सकता हूँ?**

नहीं। सार्वजनिक और एन्क्रिप्टेड प्रॉपर्टी डेटा को सुसंगत रहना चाहिए, इसलिए एन्क्रिप्टेड PPTX फ़ाइल को अपडेट करने के लिये सही ओपनिंग पासवर्ड के साथ पूरी प्रस्तुति लोड करना आवश्यक है।