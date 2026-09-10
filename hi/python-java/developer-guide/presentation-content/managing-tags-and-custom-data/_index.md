---
title: Python का उपयोग करके प्रस्तुतियों में टैग और कस्टम डेटा का प्रबंधन
linktitle: टैग और कस्टम डेटा
type: docs
weight: 300
url: /hi/python-java/managing-tags-and-custom-data/
keywords:
- दस्तावेज़ गुण
- टैग
- कस्टम डेटा
- कस्टम XML
- कस्टम XML भाग
- XML मेटाडेटा
- ItemId
- टैग जोड़ें
- जोड़ी मान
- PowerPoint
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via Java का उपयोग करके PowerPoint प्रस्तुतियों में टैग और कस्टम XML डेटा को प्रबंधित करना सीखें, जिसमें कस्टम XML भागों को जोड़ना, पढ़ना, अपडेट करना, ऑडिट करना और हटाना शामिल है।"
---
## **अवलोकन**

यह लेख बताता है कि Aspose.Slides PowerPoint प्रस्तुतियों में टैग और कस्टम डेटा के साथ कैसे काम करता है। प्रस्तुतिकरण‑विशिष्ट डेटा टैग या कस्टम XML भागों के रूप में संग्रहीत किया जा सकता है। टैग सरल कुंजी‑मूल्य स्ट्रिंग जोड़े होते हैं, जबकि कस्टम XML भाग संरचित मेटाडाटा और एप्लिकेशन‑विशिष्ट XML पेलोड संग्रहीत कर सकते हैं।

Aspose.Slides APIs प्रदान करता है जो कस्टम XML भागों को जोड़ने, पढ़ने, अपडेट करने, ऑडिट करने और हटाने की अनुमति देता है, चाहे वह प्रस्तुति, स्लाइड या शेप स्तर पर हो। कस्टम XML भाग उन एकीकरणों के लिए उपयोगी हैं जो दस्तावेज‑प्रबंधन पहचानकर्ता, कार्य‑प्रवाह स्थिति, अनुपालन मेटाडाटा, टेम्पलेट‑बाइंडिंग डेटा, या कोई अन्य संरचित एप्लिकेशन डेटा प्रस्तुति के भीतर संग्रहीत करते हैं।

## **प्रस्तुति फ़ाइलों में डेटा संग्रहण**

PPTX फ़ाइलें—फ़ाइलें जिनका विस्तार `.pptx` है—PresentationML फ़ॉर्मेट में संग्रहीत होती हैं, जो Office Open XML विनिर्देश का भाग है। Office Open XML पैकेज संरचना और संबंधों को परिभाषित करता है जो प्रस्तुति सामग्री और संबंधित डेटा को संग्रहीत करने के लिए उपयोग होते हैं।

एक प्रस्तुति में कई भाग होते हैं जो संबंधों द्वारा जुड़े होते हैं। उदाहरण के लिए, एक स्लाइड भाग एकल स्लाइड की सामग्री रखता है और ISO/IEC 29500 द्वारा परिभाषित अन्य भागों के साथ स्पष्ट संबंध रख सकता है।

कस्टम डेटा को टैग ([TagCollection](https://reference.aspose.com/slides/hi/python-java/aspose.slides/tagcollection/)) या कस्टम XML भागों ([CustomXmlPartCollection](https://reference.aspose.com/slides/hi/python-java/aspose.slides/customxmlpartcollection/)) के रूप में संग्रहीत किया जा सकता है। दोनों ही [CustomData](https://reference.aspose.com/slides/hi/python-java/aspose.slides/customdata/) क्लास के माध्यम से उपलब्ध हैं।

{{% alert color="info" title="Note" %}}
टैग सरल स्ट्रिंग कुंजी‑मूल्य जोड़े संग्रहीत करते हैं। कस्टम XML भाग संरचित XML डेटा संग्रहीत करते हैं और इसे प्रस्तुति, स्लाइड या शेप से जोड़ा जा सकता है।
{{% /alert %}}

## **कस्टम XML भागों के साथ कार्य करें**

[CustomData.getCustomXmlParts](https://reference.aspose.com/slides/hi/python-java/aspose.slides/customdata/#getCustomXmlParts) मेथड उस कस्टम XML भागों के संग्रह को लौटाता है जो किसी विशिष्ट प्रस्तुति ऑब्जेक्ट से जुड़े होते हैं। उदाहरण के लिए:

- प्रस्तुति की [CustomData.getCustomXmlParts](https://reference.aspose.com/slides/hi/python-java/aspose.slides/customdata/#getCustomXmlParts) संग्रह में प्रस्तुति स्वयं से जुड़े कस्टम XML भाग होते हैं।
- स्लाइड की [CustomData.getCustomXmlParts](https://reference.aspose.com/slides/hi/python-java/aspose.slides/customdata/#getCustomXmlParts) संग्रह में विशिष्ट स्लाइड से जुड़े कस्टम XML भाग होते हैं।
- शेप की [CustomData.getCustomXmlParts](https://reference.aspose.com/slides/hi/python-java/aspose.slides/customdata/#getCustomXmlParts) संग्रह में विशिष्ट शेप से जुड़े कस्टम XML भाग होते हैं।

जब आपको प्रस्तुति में सभी कस्टम XML भागों को देखना हो, चाहे वे कहीं भी जुड़े हों, तो [Presentation.getAllCustomXmlParts](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#getAllCustomXmlParts) का उपयोग करें।

### **एक प्रस्तुति में कस्टम XML भाग जोड़ें**

[CustomXmlPartCollection.add](https://reference.aspose.com/slides/hi/python-java/aspose.slides/customxmlpartcollection/#add) का उपयोग करके XML डेटा को कस्टम XML भाग संग्रह में जोड़ा जा सकता है। XML वैध और गैर‑खाली होना चाहिए।

निम्न उदाहरण प्रस्तुति‑स्तर के कस्टम डेटा संग्रह में संरचित मेटाडाटा जोड़ता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat
from java.util import UUID

presentation = Presentation()
try:
    custom_xml_content = '<?xml version="1.0" encoding="UTF-8"?><metadata xmlns="urn:example:metadata"><documentId>DOC-1001</documentId><workflowState>Draft</workflowState></metadata>'
    custom_xml_part = presentation.getCustomData().getCustomXmlParts().add(custom_xml_content)

    # add स्वचालित रूप से एक पहचानकर्ता असाइन करता है। केवल आवश्यक होने पर एक विशिष्ट UUID सेट करें।
    item_id = UUID.randomUUID()
    custom_xml_part.setItemId(item_id)

    presentation.save("presentation_with_custom_xml.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

[add](https://reference.aspose.com/slides/hi/python-java/aspose.slides/customxmlpartcollection/#add) मेथड XML को बाइट ऐरे या इनपुट स्ट्रीम के रूप में भी स्वीकार कर सकता है, जो तब उपयोगी होता है जब XML सामग्री पहले से बाइनरी रूप में उपलब्ध हो।

### **स्लाइड या शेप में कस्टम XML भाग जोड़ें**

कस्टम XML डेटा को पूरी प्रस्तुति के बजाय किसी विशिष्ट स्लाइड या शेप से जोड़ा जा सकता है। यह उपयोगी है जब मेटाडाटा केवल एक ऑब्जेक्ट के लिए है, जैसे टेम्पलेट कुंजी, बाहरी रिकॉर्ड पहचानकर्ता, या बाइंडिंग जानकारी।

निम्न उदाहरण एक स्लाइड में एक कस्टम XML भाग और एक शेप में दूसरा जोड़ता है:

```python
import jpide
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    slide_xml_content = '<slideMetadata xmlns="urn:example:slides"><templateKey>TitleSlide</templateKey></slideMetadata>'
    slide.getCustomData().getCustomXmlParts().add(slide_xml_content)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 250, 80)
    shape.getTextFrame().setText("Customer data")
    shape_xml_content = '<shapeMetadata xmlns="urn:example:shapes"><recordId>CRM-4281</recordId></shapeMetadata>'
    shape.getCustomData().getCustomXmlParts().add(shape_xml_content)

    presentation.save("object_custom_xml.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

जिस स्तर पर भाग जोड़ा जाता है, वह निर्धारित करता है कि किस ऑब्जेक्ट की [CustomData.getCustomXmlParts](https://reference.aspose.com/slides/hi/python-java/aspose.slides/customdata/#getCustomXmlParts) संग्रह में उस भाग का संबंध है। प्रस्तुति‑स्तर डेटा पूरे दस्तावेज़‑व्यापी मेटाडाटा के लिए उपयुक्त है, स्लाइड‑स्तर डेटा विशिष्ट स्लाइड की जानकारी के लिए, और शेप‑स्तर डेटा व्यक्तिगत शेप से बंधे मेटाडाटा के लिए।

### **सभी कस्टम XML भागों की सूची और ऑडिट करें**

[Presentation.getAllCustomXmlParts](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#getAllCustomXmlParts) का उपयोग करके प्रस्तुति से सभी कस्टम XML भाग प्राप्त किए जा सकते हैं। प्रत्येक [CustomXmlPart](https://reference.aspose.com/slides/hi/python-java/aspose.slides/customxmlpart/) अपना पहचानकर्ता, XML सामग्री और संबंधित नेमस्पेस स्कीमा प्रदर्शित करता है।

निम्न उदाहरण सभी कस्टम XML भागों और उनके नेमस्पेस स्कीमा को सूचीबद्ध करता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    for custom_xml_part in presentation.getAllCustomXmlParts():
        print("ItemId:", custom_xml_part.getItemId())
        print("XML:")
        print(custom_xml_part.getXmlAsString())

        for namespace_schema in custom_xml_part.getNamespaceSchemas():
            print("Namespace schema:", namespace_schema)

        print()
finally:
    presentation.dispose()
```

[CustomXmlPart.getNamespaceSchemas](https://reference.aspose.com/slides/hi/python-java/aspose.slides/customxmlpart/#getNamespaceSchemas) कस्टम XML भाग से जुड़े XML स्कीमा लौटाता है। यह जानकारी उन प्रस्तुतियों के ऑडिट में उपयोगी हो सकती है जिनमें बाहरी प्रणाली द्वारा उत्पन्न XML शामिल हो।

### **XML सामग्री और ItemId पढ़ें और अपडेट करें**

[CustomXmlPart.getXmlAsString](https://reference.aspose.com/slides/hi/python-java/aspose.slides/customxmlpart/#getXmlAsString) और [setXmlAsString](https://reference.aspose.com/slides/hi/python-java/aspose.slides/customxmlpart/#setXmlAsString) का उपयोग करके XML को UTF‑8 स्ट्रिंग के रूप में संभाला जा सकता है, या [getXmlData](https://reference.aspose.com/slides/hi/python-java/aspose.slides/customxmlpart/#getXmlData) और [setXmlData](https://reference.aspose.com/slides/hi/python-java/aspose.slides/customxmlpart/#setXmlData) का उपयोग करके कच्चे XML बाइट्स के साथ काम किया जा सकता है।

[CustomXmlPart.getItemId](https://reference.aspose.com/slides/hi/python-java/aspose.slides/customxmlpart/#getItemId) मेथड उस कस्टम XML भाग का UUID लौटाता है जो Office Open XML दस्तावेज़ में उसे पहचानता है। नई पहचानकर्ता की आवश्यकता होने पर [setItemId](https://reference.aspose.com/slides/hi/python-java/aspose.slides/customxmlpart/#setItemId) का उपयोग करें।

निम्न उदाहरण XML सामग्री और पहचानकर्ता को अपडेट करता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat
from java.util import UUID

presentation = Presentation("presentation.pptx")
try:
    custom_xml_parts = presentation.getAllCustomXmlParts()
    if len(custom_xml_parts) > 0:
        custom_xml_part = custom_xml_parts[0]

        # वर्तमान XML को टेक्स्ट के रूप में पढ़ें।
        current_xml_content = custom_xml_part.getXmlAsString()
        print(current_xml_content)

        # XML को UTF-8 स्ट्रिंग के रूप में अपडेट करें।
        custom_xml_content = '<metadata xmlns="urn:example:metadata"><documentId>DOC-1001</documentId><workflowState>Approved</workflowState></metadata>'
        custom_xml_part.setXmlAsString(custom_xml_content)

        # getXmlData वही XML सामग्री कच्चे बाइट्स के रूप में प्रदान करता है।
        custom_xml_data = custom_xml_part.getXmlData()
        print(bytes(custom_xml_data).decode("utf-8"))

        # इंटीग्रेशन द्वारा आवश्यक होने पर पहचानकर्ता बदलें।
        item_id = UUID.randomUUID()
        custom_xml_part.setItemId(item_id)

        presentation.save("updated_custom_xml.pptx", SaveFormat.Pptx)
    else:
        print("No custom XML parts found.")
finally:
    presentation.dispose()
```

[setXmlAsString](https://reference.aspose.com/slides/hi/python-java/aspose.slides/customxmlpart/#setXmlAsString) या [setXmlData](https://reference.aspose.com/slides/hi/python-java/aspose.slides/customxmlpart/#setXmlData) को कॉल करते समय वैध, गैर‑खाली XML प्रदान करें। एप्लिकेशन के मुख्य रूप से स्ट्रिंग या बाइट डेटा पर निर्भर होने के आधार पर एक प्रतिनिधित्व चुनें।

### **कस्टम XML भाग हटाएँ**

Aspose.Slides कस्टम XML डेटा हटाने के कई तरीके प्रदान करता है:

- [CustomXmlPart.remove](https://reference.aspose.com/slides/hi/python-java/aspose.slides/customxmlpart/#remove) कस्टम XML भाग को प्रस्तुति से हटाता है।
- [CustomXmlPartCollection.remove](https://reference.aspose.com/slides/hi/python-java/aspose.slides/customxmlpartcollection/#remove) विशिष्ट भाग को कस्टम XML भाग संग्रह से हटाता है।
- [CustomXmlPartCollection.removeAt](https://reference.aspose.com/slides/hi/python-java/aspose.slides/customxmlpartcollection/#removeAt) निर्दिष्ट संग्रह सूचकांक पर स्थित भाग को हटाता है।
- [CustomXmlPartCollection.clear](https://reference.aspose.com/slides/hi/python-java/aspose.slides/customxmlpartcollection/#clear) किसी विशिष्ट संग्रह से सभी भागों को हटाता है।

निम्न उदाहरण संदर्भ द्वारा एक प्रस्तुति‑स्तर कस्टम XML भाग हटाता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    custom_xml_parts = presentation.getCustomData().getCustomXmlParts()
    if custom_xml_parts.size() > 0:
        custom_xml_part = custom_xml_parts.get_Item(0)
        custom_xml_parts.remove(custom_xml_part)

    presentation.save("custom_xml_removed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

यदि आपके पास पहले से ही एक [CustomXmlPart](https://reference.aspose.com/slides/hi/python-java/aspose.slides/customxmlpart/) है और आप उस भाग को प्रस्तुति से हटाना चाहते हैं न कि किसी विशिष्ट संग्रह को, तो [CustomXmlPart.remove](https://reference.aspose.com/slides/hi/python-java/aspose.slides/customxmlpart/#remove) को कॉल करें।

आप सूचकांक द्वारा भी कोई आइटम हटा सकते हैं:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    custom_xml_parts = presentation.getCustomData().getCustomXmlParts()
    if custom_xml_parts.size() > 0:
        custom_xml_parts.removeAt(0)
finally:
    presentation.dispose()
```

### **संग्रह से सभी कस्टम XML भाग साफ़ करें**

जब किसी विशिष्ट प्रस्तुति ऑब्जेक्ट से जुड़े सभी कस्टम XML भाग हटाए जाने चाहिए, तो [clear](https://reference.aspose.com/slides/hi/python-java/aspose.slides/customxmlpartcollection/#clear) का उपयोग करें।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    presentation.getSlides().get_Item(0).getCustomData().getCustomXmlParts().clear()

    presentation.save("slide_custom_xml_cleared.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

[clear](https://reference.aspose.com/slides/hi/python-java/aspose.slides/customxmlpartcollection/#clear) केवल चयनित संग्रह को प्रभावित करता है। उदाहरण के लिए, स्लाइड के संग्रह को साफ़ करने से प्रस्तुति‑स्तर या शेप‑स्तर के संग्रह साफ़ नहीं होते।

सभी कस्टम XML भागों को पूरी प्रस्तुति से हटाने के लिए, [getAllCustomXmlParts](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#getAllCustomXmlParts) को इटरेट करें और प्रत्येक भाग को हटाएँ:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    for custom_xml_part in presentation.getAllCustomXmlParts():
        custom_xml_part.remove()

    presentation.save("all_custom_xml_removed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **लिंक्ड या साझा कस्टम XML भागों को संभालें**

Office Open XML प्रस्तुति में समान कस्टम XML भाग को एक से अधिक प्रस्तुति ऑब्जेक्ट से रेफ़र किया जा सकता है। उदाहरण के लिए, एक मौजूदा फ़ाइल में कई स्लाइड या शेप एक ही अंतर्निहित कस्टम XML भाग के साथ संबंध रख सकते हैं।

साझा भाग को कई संदर्भों के साथ एक डेटा ऑब्जेक्ट माना जाना चाहिए:

- इसे [setXmlAsString](https://reference.aspose.com/slides/hi/python-java/aspose.slides/customxmlpart/#setXmlAsString), [setXmlData](https://reference.aspose.com/slides/hi/python-java/aspose.slides/customxmlpart/#setXmlData) या [setItemId](https://reference.aspose.com/slides/hi/python-java/aspose.slides/customxmlpart/#setItemId) से अपडेट करने से मूल कस्टम XML भाग बदलता है, इसलिए परिवर्तन सभी रेफ़रेंस में लागू हो जाता है।
- [getItemId](https://reference.aspose.com/slides/hi/python-java/aspose.slides/customxmlpart/#getItemId) का प्रयोग ऑब्जेक्ट‑स्तर संग्रहों के ऑडिट में समान कस्टम XML भाग की पहचान करने के लिए किया जा सकता है।
- किसी विशिष्ट [getCustomXmlParts](https://reference.aspose.com/slides/hi/python-java/aspose.slides/customdata/#getCustomXmlParts) संग्रह से भाग हटाने से वह केवल उस संग्रह से हटता है। भाग को पूरी प्रस्तुति से हटाने के लिए [CustomXmlPart.remove](https://reference.aspose.com/slides/hi/python-java/aspose.slides/customxmlpart/#remove) का प्रयोग करें।
- साझा भाग को हटाने या बदलने से पहले, ऑब्जेक्ट‑स्तर संग्रहों की जांच करें कि क्या अन्य स्लाइड या शेप अभी भी इसका संदर्भ ले रहे हैं।

[add](https://reference.aspose.com/slides/hi/python-java/aspose.slides/customxmlpartcollection/#add) ओवरलोड नई कस्टम XML भाग को XML सामग्री से बनाते हैं; वे मौजूदा [CustomXmlPart](https://reference.aspose.com/slides/hi/python-java/aspose.slides/customxmlpart/) को स्वीकार नहीं करते। इसलिए, साझा संबंध अक्सर उन प्रस्तुतियों को लोड करते समय मिलते हैं जिनमें पहले से ये संबंध मौजूद होते हैं।

निम्न उदाहरण `ItemId` के आधार पर प्रस्तुति‑, स्लाइड‑ और शेप‑स्तर के संग्रहों का ऑडिट करता है और उन भागों की रिपोर्ट करता है जो एक से अधिक स्थानों से रेफ़र किए गए हैं:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    references_by_item_id = {}

    def register_custom_xml_parts(owner_name, custom_xml_parts):
        for i in range(custom_xml_parts.size()):
            custom_xml_part = custom_xml_parts.get_Item(i)
            item_id = str(custom_xml_part.getItemId())
            references_by_item_id.setdefault(item_id, []).append(owner_name)

    register_custom_xml_parts("Presentation", presentation.getCustomData().getCustomXmlParts())

    for slide_index in range(presentation.getSlides().size()):
        slide = presentation.getSlides().get_Item(slide_index)
        register_custom_xml_parts(f"Slide {slide_index + 1}", slide.getCustomData().getCustomXmlParts())

        for shape_index in range(slide.getShapes().size()):
            shape = slide.getShapes().get_Item(shape_index)
            register_custom_xml_parts(f"Slide {slide_index + 1}, shape {shape_index}", shape.getCustomData().getCustomXmlParts())

    for item_id, owner_names in references_by_item_id.items():
        if len(owner_names) > 1:
            print("Shared custom XML part:", item_id)
            for owner_name in owner_names:
                print("  Referenced by:", owner_name)
finally:
    presentation.dispose()
```

यह प्रकार का ऑडिट उन मामलों में उपयोगी है जहाँ बाहरी सिस्टम द्वारा निर्मित प्रस्तुतियों में कस्टम XML डेटा को संशोधित या हटाने से पहले यह देखना आवश्यक होता है कि समान मेटाडाटा भाग एक से अधिक संबंध में भाग ले रहा है या नहीं।

## **टैग के मान प्राप्त करें**

स्लाइड्स में, टैग [DocumentProperties.getKeywords](https://reference.aspose.com/slides/hi/python-java/aspose.slides/documentproperties/#getKeywords) मेथड के अनुरूप है। यह नमूना कोड दिखाता है कि Aspose.Slides for Python via Java के साथ एक [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) से टैग मान कैसे प्राप्त किया जाए:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    keywords = presentation.getDocumentProperties().getKeywords()
finally:
    presentation.dispose()
```

## **प्रस्तुतियों में टैग जोड़ें**

Aspose.Slides आपको प्रस्तुतियों में टैग जोड़ने की अनुमति देता है। एक टैग आमतौर पर दो आइटमों से बना होता है:

- एक कस्टम प्रॉपर्टी का नाम, उदाहरण के लिए `MyTag`;
- कस्टम प्रॉपर्टी का मान, उदाहरण के लिए `My Tag Value`।

यदि आपको किसी विशिष्ट नियम या प्रॉपर्टी के आधार पर प्रस्तुतियों को वर्गीकृत करने की आवश्यकता है, तो आप उस उद्देश्य के लिए टैग जोड़ सकते हैं। उदाहरण के लिए, यदि आप उत्तरी अमेरिकी देशों की प्रस्तुतियों को वर्गीकृत करना चाहते हैं, तो आप एक North American टैग बना सकते हैं और संबंधित देश को उसका मान असाइन कर सकते हैं।

यह नमूना कोड दिखाता है कि Aspose.Slides for Python via Java का उपयोग करके एक [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) में टैग कैसे जोड़ा जाए:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    tags = presentation.getCustomData().getTags()
    tags.set_Item("MyTag", "My Tag Value")
finally:
    presentation.dispose()
```

टैग को एक [Slide](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slide/) के लिए भी सेट किया जा सकता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    slide.getCustomData().getTags().set_Item("tag", "value")
finally:
    presentation.dispose()
```

या किसी व्यक्तिगत [Shape](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shape/) के लिए:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 50)
    shape.getTextFrame().setText("My text")
    shape.getCustomData().getTags().set_Item("tag", "value")
finally:
    presentation.dispose()
```

### **सीमाएं**

[CustomData.getTags](https://reference.aspose.com/slides/hi/python-java/aspose.slides/customdata/#getTags) संग्रह के माध्यम से जोड़े गए टैग केवल PowerPoint फ़ाइल में संग्रहीत होते हैं। वे प्रस्तुति को PDF में निर्यात करने पर PDF टैग संरचना में **स्थानांतरित नहीं** होते। परिणामस्वरूप, टैग के रूप में असाइन किया गया कस्टम पहचानकर्ता टॅग किए गए PDF से पुनः प्राप्त नहीं किया जा सकता।

**वर्कअराउंड**: आप कस्टम पहचानकर्ता को ऑब्जेक्ट के **Alt Text** में संग्रहीत कर सकते हैं (उदाहरण के लिए, [Shape.setAlternativeText](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shape/#setAlternativeText) के साथ मान `"MyId"` सेट करें)। PDF में निर्यात करने के बाद, Alt Text PDF टैग संरचना में दिखाई दे सकता है।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं सभी टैग को एक ही ऑपरेशन में प्रस्तुति, स्लाइड या शेप से हटा सकता हूँ?**

हां। [tag collection](https://reference.aspose.com/slides/hi/python-java/aspose.slides/tagcollection/) एक [clear](https://reference.aspose.com/slides/hi/python-java/aspose.slides/tagcollection/#clear) ऑपरेशन का समर्थन करता है जो सभी कुंजी‑मूल्य जोड़ों को एक साथ हटा देता है।

**मैं पूरे संग्रह को इटरेट किए बिना किसी एकल टैग को उसके नाम से कैसे हटाऊँ?**

[tag collection](https://reference.aspose.com/slides/hi/python-java/aspose.slides/tagcollection/) पर [remove](https://reference.aspose.com/slides/hi/python-java/aspose.slides/tagcollection/#remove) का उपयोग करके टैग को उसके कुंजी द्वारा हटाया जा सकता है।

**विश्लेषण या फ़िल्टरिंग के लिए टैग नामों की पूरी सूची कैसे प्राप्त करूँ?**

[tag collection](https://reference.aspose.com/slides/hi/python-java/aspose.slides/tagcollection/) पर [getNamesOfTags](https://reference.aspose.com/slides/hi/python-java/aspose.slides/tagcollection/#getNamesOfTags) का प्रयोग करें; यह सभी टैग नामों की एक एरे लौटाता है।

**मैं सभी कस्टम XML भागों को कैसे पा सकता हूँ चाहे वे कहीं भी संग्रहीत हों?**

सभी कस्टम XML भागों को प्राप्त करने के लिए [Presentation.getAllCustomXmlParts](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#getAllCustomXmlParts) का उपयोग करें।

**कस्टम XML भाग को अपडेट करने के लिए मुझे [getXmlAsString](https://reference.aspose.com/slides/hi/python-java/aspose.slides/customxmlpart/#getXmlAsString)/[setXmlAsString](https://reference.aspose.com/slides/hi/python-java/aspose.slides/customxmlpart/#setXmlAsString) या [getXmlData](https://reference.aspose.com/slides/hi/python-java/aspose.slides/customxmlpart/#getXmlData)/[setXmlData](https://reference.aspose.com/slides/hi/python-java/aspose.slides/customxmlpart/#setXmlData) में से कौन सा उपयोग करना चाहिए?**

जब एप्लिकेशन UTF‑8 XML टेक्स्ट के साथ काम करता है, तो [getXmlAsString](https://reference.aspose.com/slides/hi/python-java/aspose.slides/customxmlpart/#getXmlAsString) और [setXmlAsString](https://reference.aspose.com/slides/hi/python-java/aspose.slides/customxmlpart/#setXmlAsString) उपयोग करें। जब XML पहले से बाइट ऐरे के रूप में उपलब्ध हो या बाइनरी‑उन्मुख प्रोसेसिंग अधिक सुविधाजनक हो, तो [getXmlData](https://reference.aspose.com/slides/hi/python-java/aspose.slides/customxmlpart/#getXmlData) और [setXmlData](https://reference.aspose.com/slides/hi/python-java/aspose.slides/customxmlpart/#setXmlData) उपयोग करें। दोनों प्रतिनिधित्व समान कस्टम XML भाग की XML सामग्री को संदर्भित करते हैं।