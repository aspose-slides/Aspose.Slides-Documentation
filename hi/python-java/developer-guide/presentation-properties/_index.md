---
title: Python में प्रस्तुति गुणों का प्रबंधन
linktitle: प्रस्तुति गुण
type: docs
weight: 70
url: /hi/python-java/presentation-properties/
keywords:
- PowerPoint गुण
- प्रस्तुति गुण
- दस्तावेज़ गुण
- बिल्ट‑इन गुण
- कस्टम गुण
- उन्नत गुण
- गुणों का प्रबंधन
- गुणों में संशोधन
- दस्तावेज़ मेटाडेटा
- मेटाडेटा संपादन
- प्रूफ़िंग भाषा
- डिफ़ॉल्ट भाषा
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via Java में प्रस्तुति गुणों का पूर्ण नियंत्रण प्राप्त करें और अपने PowerPoint और OpenDocument फ़ाइलों में खोज, ब्रांडिंग और कार्यप्रवाह को सरल बनाएं।"
---
## **परिचय**

Aspose.Slides for Python via Java **बिल्ट‑इन** और **कस्टम** दस्तावेज़ गुणों का समर्थन करता है। इन गुणों का उपयोग प्रस्तुति मेटाडेटा पढ़ने और अपडेट करने के लिए करें, जैसे लेखक, शीर्षक, और उपयोगकर्ता‑परिभाषित मान।

Aspose.Slides आपको प्रस्तुति दस्तावेज़ गुणों के साथ काम करने की सुविधा देता है [DocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/) क्लास के माध्यम से। इस क्लास का एक उदाहरण [Presentation.getDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getDocumentProperties) द्वारा लौटाया जाता है। नीचे के उदाहरण दिखाते हैं कि इन गुणों को कैसे पढ़ें, संशोधित करें और प्रबंधित करें।

{{% alert color="info" title="Note" %}}

Aspose.Slides प्रस्तुति सहेजते समय एप्लिकेशन और निर्माता मेटाडेटा को प्रबंधित करता है; ये फ़ील्ड उस सॉफ़्टवेयर की पहचान करते हैं जिसने आउटपुट बनाया।

{{% /alert %}}

## **प्रस्तुति गुणों का प्रबंधन**

दस्तावेज़ गुण प्रस्तुति सामग्री के साथ वर्णनात्मक जानकारी संग्रहीत करते हैं। ये दो श्रेणियों में वर्गीकृत होते हैं:

- **बिल्ट‑इन गुण** मानक मेटाडेटा रखते हैं, जैसे शीर्षक, लेखक, और दस्तावेज़ आँकड़े।
- **कस्टम गुण** उपयोगकर्ता‑परिभाषित नाम/मान जोड़े संग्रहीत करते हैं।

Aspose.Slides for Python via Java दोनों श्रेणियों तक पहुँच प्रदान करता है। PowerPoint में, **फ़ाइल → जानकारी → गुण → उन्नत गुण** चुनें ताकि दस्तावेज़ मेटाडेटा की जाँच की जा सके। डायलॉग जानकारी को **सारांश**, **सांख्यिकी**, **सामग्री**, और **कस्टम** जैसे टैब में समूहित करता है। उपयोगकर्ता‑परिभाषित गुणों को प्रबंधित करने के लिए **कस्टम** टैब का उपयोग करें।

## **एन्क्रिप्टेड प्रस्तुति से सार्वजनिक गुण पढ़ें**

एक खोलने वाला पासवर्ड सामान्यतः प्रस्तुति सामग्री और दस्तावेज़ गुणों दोनों की रक्षा करता है। जब कोई प्रस्तुति [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) को `False` के साथ कॉल करने के बाद एन्क्रिप्ट की जाती है, तो उसके दस्तावेज़ गुण सार्वजनिक रहते हैं। फिर एक एप्लिकेशन [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) को `True` के साथ कॉल कर सकता है और खोलने वाला पासवर्ड दिए बिना सार्वजनिक मेटाडेटा पढ़ सकता है।

[LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) यह नियंत्रित करता है कि Aspose.Slides क्या लोड करता है; यह कुछ भी डिक्रिप्ट नहीं करता। यदि गुण एन्क्रिप्शन में सम्मिलित थे, तो पासवर्ड के बिना उन्हें लोड करना विफल हो जाता है। यदि प्रस्तुति एन्क्रिप्ट नहीं है, तो यह विकल्प अनदेखा किया जाता है और पूरी प्रस्तुति लोड हो जाती है।

उदाहरण को एक एन्क्रिप्टेड प्रस्तुति की आवश्यकता है जिसकी दस्तावेज़ गुण सार्वजनिक रखे गए हों। यह लोडिंग मोड को [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/python-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) के माध्यम से जांचता है और फिर [Presentation.getDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getDocumentProperties) के माध्यम से बिल्ट‑इन गुण पढ़ता है:

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

इस मोड में स्लाइड सामग्री लोड नहीं की जाती। स्लाइड्स, मास्टर्स, लेआउट्स, शेप्स, मीडिया, और अन्य प्रस्तुति वस्तुएँ उपलब्ध नहीं होतीं। एप्लिकेशन को हमेशा [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/python-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) की जाँच करनी चाहिए इससे पहले कि वह ऐसा ऑपरेशन करे जिसके लिए पूर्ण प्रस्तुति ऑब्जेक्ट मॉडल की आवश्यकता हो।

{{% alert color="warning" title="Warning" %}}
सार्वजनिक मेटाडेटा में लेखक नाम, शीर्षक, विषय, कीवर्ड, कंपनी जानकारी, टिप्पणी, और कस्टम मान दिखाई दे सकते हैं। संवेदनशील गुणों को प्रस्तुति के साथ ही एन्क्रिप्ट करें। उन्हें तभी सार्वजनिक रखें जब इंडेक्सिंग, वर्गीकरण, खोज, या दस्तावेज़‑प्रबंधन प्रणाली को पासवर्ड के बिना एक्सेस करने की विशिष्ट आवश्यकता हो।
{{% /alert %}}

## **एन्क्रिप्टेड प्रस्तुति की गुणों को अपडेट करें**

एक एन्क्रिप्टेड PPTX फ़ाइल के लिए, वह प्रस्तुति जो [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) को `True` के साथ कॉल करने के बाद लोड की गई हो, सार्वजनिक मेटाडेटा पढ़ने के लिए अभिप्रेत है। Aspose.Slides उस मेटाडेटा‑केवल ऑब्जेक्ट से बदलते गुणों को सहेज नहीं सकता, क्योंकि सार्वजनिक गुणों को एन्क्रिप्टेड प्रस्तुति के भीतर संबंधित डेटा के साथ सुसंगत रहना चाहिए। इसलिए अपडेट करने के लिये सही खोलने वाला पासवर्ड और पूर्ण लोड आवश्यक है।

उदाहरण को एक एन्क्रिप्टेड PPTX प्रस्तुति की आवश्यकता है जिसमें सार्वजनिक दस्तावेज़ गुण और ज्ञात खोलने वाला पासवर्ड हो। यह पूर्ण प्रस्तुति को [LoadOptions.setPassword](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setPassword) के साथ खोलता है, सार्वजनिक बिल्ट‑इन गुणों को अपडेट करता है, और परिणाम सहेजता है। फिर यह [PresentationInfo.isEncrypted](https://reference.aspose.com/slides/python-java/aspose.slides/presentationinfo/#isEncrypted) का उपयोग करके एन्क्रिप्शन की पुष्टि करता है और पासवर्ड बिना सार्वजनिक मेटाडेटा को दोबारा खोलकर नए मानों की जाँच करता है:

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

## **बिल्ट‑इन गुणों तक पहुँचें**

[DocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/) क्लास getter मेथड्स के माध्यम से बिल्ट‑इन मेटाडेटा उजागर करती है, जिसमें [getAuthor](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getAuthor), [getTitle](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getTitle), और [getCreatedTime](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getCreatedTime) शामिल हैं। यह उदाहरण एक मौजूदा प्रस्तुति खोलता है और उसकी संग्रहीत मेटाडेटा को कंसोल में प्रिंट करता है। मान इनपुट प्रस्तुति पर निर्भर करते हैं; कुछ फ़ील्ड खाली हो सकते हैं।

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

## **बिल्ट‑इन गुणों में संशोधन करें**

बिल्ट‑इन मेटाडेटा को अपडेट करने के लिये आप [Presentation.getDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getDocumentProperties) द्वारा लौटाए गए ऑब्जेक्ट पर setter मेथड्स का उपयोग कर सकते हैं। यह उदाहरण एक मौजूदा प्रस्तुति खोलता है, [setAuthor](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setAuthor), [setTitle](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setTitle), [setSubject](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setSubject), [setComments](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setComments), और [setManager](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setManager) को कॉल करता है, फिर अपडेटेड प्रस्तुति को [Presentation.save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) के साथ सहेजता है। सहेजा गया PPTX नई मेटाडेटा रखेगा।

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

## **हाइपरलिंक बेस प्रबंधित करें**

[DocumentProperties.getHyperlinkBase](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getHyperlinkBase) दस्तावेज़‑स्तर का बेस लौटाता है जो सापेक्ष हाइपरलिंक्स के लिये उपयोग होता है। इसे बदलने या साफ़ करने के लिये [DocumentProperties.setHyperlinkBase](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setHyperlinkBase) का प्रयोग करें। यह उपयोगी है जब आप प्रस्तुति और उसकी लिंक की गई फ़ाइलों को किसी अन्य स्थान पर ले जाते हैं। यह व्यक्तिगत हाइपरलिंक के [Hyperlink.getExternalUrl](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#getExternalUrl) से अलग है: बेस बदलने से संग्रहीत लिंक पतों को पुनः लिखी नहीं जाती और न ही निरपेक्ष गंतव्य बदलते हैं।

उदाहरण को एक ऐसी प्रस्तुति चाहिए जिसमें सापेक्ष लिंक `target.html` और निरपेक्ष लिंक `https://example.org/absolute.html` दोनों हों। यह मौजूदा बेस पढ़ता है, नया बेस पता सेट करता है, और मूल्य की जाँच के लिये प्रस्तुति को सहेज कर पुनः खोलता है। फिर यह बेस को खाली स्ट्रिंग से साफ़ करता है और एक अलग सहेजी गई फ़ाइल में खाली मान की पुष्टि करता है। उदाहरण बेस पते को अपने लिंक फ़ाइलों के स्थान से बदलें।

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

दोनों सत्यापन संदेश `True` प्रदर्शित करेंगे। बेस को साफ़ करने से व्यक्तिगत हाइपरलिंक पतों पर कोई असर नहीं पड़ता।

सापेक्ष लिंक `target.pptx` ने `old/target.pptx` खोला जब बेस `old` फ़ोल्डर की ओर इशारा कर रहा था। बेस को `new` फ़ोल्डर में बदलने, सहेजने और प्रस्तुति को पुनः खोलने के बाद वही लिंक `new/target.pptx` खोलेगा। निरपेक्ष लिंक वही फ़ाइल खोलता ही रहेगा। प्रस्तुति को स्थानांतरित करने या उसका बेस बदलने से पहले और बाद में PowerPoint में अपने सापेक्ष लिंक का परीक्षण करें।

## **कस्टम प्रस्तुति गुण जोड़ें**

कस्टम गुण उन मेटाडेटा को संग्रहीत करते हैं जिनका कोई बिल्ट‑इन फ़ील्ड नहीं होता। [DocumentProperties.set_Item](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#set_Item) मेथड आपको गुण名稱 के द्वारा मान असाइन करने देता है। यह उदाहरण एक प्रस्तुति बनाता है, दो टेक्स्ट मान और एक पूर्णांक संस्करण मान (`jpype.JInt` का उपयोग करके जावा पूर्णांक पास किया गया) जोड़ता है, और प्रस्तुति को [Presentation.save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) के साथ सहेजता है। मौजूदा नाम को मान असाइन करने से वो गुण का मान बदल जाता है।

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

## **कस्टम गुणों तक पहुँचें और संशोधित करें**

यह उदाहरण कस्टम गुणों वाले एक प्रस्तुति को खोलता है और [getCountOfCustomProperties](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getCountOfCustomProperties) का उपयोग करके उन पर इटरेट करता है। [getCustomPropertyName](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getCustomPropertyName) शून्य‑आधारित इंडेक्स लेता है और वह नाम लौटाता है जो [DocumentProperties.set_Item](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#set_Item) द्वारा使用 किया गया था। उदाहरण प्रत्येक मूल नाम और मान को प्रिंट करता है, हर मान को क्रमांकित स्ट्रिंग में बदल देता है चाहे उसका मूल प्रकार कुछ भी हो, और बदलावों को सहेजता है। यदि कोई कस्टम गुण नहीं है, तो लूप कोई परिवर्तन नहीं करता।

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

## **लाइवल उदाहरण**

ऑनलाइन ऐप [**PowerPoint मेटाडेटा देखें और संपादित करें**](https://products.aspose.app/slides/metadata) आज़माएँ ताकि Aspose.Slides API के साथ दस्तावेज़ गुणों पर काम करना देख सकें:

[![PowerPoint मेटाडेटा देखें और संपादित करें](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं प्रस्तुति से बिल्ट‑इन गुण कैसे हटाऊँ?**

बिल्ट‑इन गुण प्रस्तुति का अभिन्न हिस्सा होते हैं और उन्हें पूरी तरह हटाया नहीं जा सकता। हालांकि, आप उनकी मान बदल सकते हैं या यदि वह गुण अनुमति देता है तो उसे खाली सेट कर सकते हैं।

**यदि मैं मौज़ूद कस्टम गुण को दोबारा जोड़ूँ तो क्या होगा?**

यदि आप मौज़ूद कस्टम गुण को दोबारा जोड़ते हैं, तो उसका मौज़ूद मान नए मान से ओवरराइट हो जाएगा। आपको पहले से इसे हटाने या जाँचने की आवश्यकता नहीं है, क्योंकि Aspose.Slides स्वतः गुण के मान को अपडेट कर देता है।

**क्या मैं पूर्ण प्रस्तुति लोड किए बिना प्रस्तुति गुणों तक पहुँच सकता हूँ?**

हाँ। आप [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/python-java/aspose.slides/presentationfactory/#getPresentationInfo) का उपयोग करके फिर [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentationinfo/#readDocumentProperties) को कॉल कर सकते हैं ताकि [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) ऑब्जेक्ट बनाए बिना संग्रहीत दस्तावेज़ मेटाडेटा पढ़ा जा सके। पूर्ण रिपोर्ट उदाहरण और फ़ॉर्मेट‑विशिष्ट सीमाओं के लिये देखें [हल्की प्रस्तुति इन्वेंट्री बनाएं](/slides/hi/python-java/examine-presentation/)।

**क्या मैं एन्क्रिप्टेड प्रस्तुति के सार्वजनिक गुण पासवर्ड के बिना पढ़ सकता हूँ?**

हाँ। प्रस्तुति को तब एन्क्रिप्ट किया गया होना चाहिए जब [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) को `False` के साथ कॉल किया गया हो, और इसे तब लोड किया गया हो जब [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) को `True` के साथ कॉल किया गया हो।

**क्या मैं दस्तावेज़‑गुण‑केवल मोड में एन्क्रिप्टेड PPTX फ़ाइल को अपडेट कर सकता हूँ?**

नहीं। सार्वजनिक और एन्क्रिप्टेड गुण डेटा को सुसंगत रहना चाहिए, इसलिए एन्क्रिप्टेड PPTX फ़ाइल को अपडेट करने के लिये सही खोलने वाला पासवर्ड के साथ पूरी प्रस्तुति को लोड करना आवश्यक है।