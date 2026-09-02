---
title: Python के साथ प्रस्तुतियों में टैग और कस्टम डेटा प्रबंधित करें
linktitle: टैग और कस्टम डेटा
type: docs
weight: 300
url: /hi/python-net/managing-tags-and-custom-data/
keywords:
- दस्तावेज़ गुण
- टैग
- कस्टम डेटा
- कस्टम XML
- कस्टम XML भाग
- XML मेटाडेटा
- आइटम आईडी
- टैग जोड़ें
- जोड़ मान
- PowerPoint
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET का उपयोग करके PowerPoint प्रस्तुतियों में टैग और कस्टम XML डेटा को प्रबंधित करना सीखें, जिसमें टैग जोड़ना, पढ़ना, अपडेट करना, ऑडिट करना और कस्टम XML भागों को हटाना शामिल है।"
---
## **अवलोकन**

यह लेख बताता है कि Aspose.Slides PowerPoint प्रस्तुतियों में टैग और कस्टम डेटा के साथ कैसे काम करता है। प्रस्तुति‑विशिष्ट डेटा को टैग या कस्टम XML भागों के रूप में संग्रहीत किया जा सकता है। टैग साधारण कुंजी‑मान (key‑value) स्ट्रिंग जोड़े होते हैं, जबकि कस्टम XML भाग संरचित मेटाडेटा और एप्लिकेशन‑विशिष्ट XML पेलोड संग्रहीत कर सकते हैं।

Aspose.Slides API प्रदान करता है कस्टम XML भागों को जोड़ने, पढ़ने, अद्यतन करने, ऑडिट करने और हटाने के लिए, और ये कार्य प्रस्तुति, स्लाइड और आकार स्तर पर किए जा सकते हैं। कस्टम XML भाग उन एकीकरणों के लिए उपयोगी होते हैं जो दस्तावेज‑प्रबंधन पहचानकर्ता, वर्कफ़्लो स्थिति, अनुपालन मेटाडेटा, टेम्पलेट‑बाइंडिंग डेटा या अन्य संरचित एप्लिकेशन डेटा को प्रस्तुति के भीतर संग्रहीत करना चाहते हैं।

## **प्रेजेंटेशन फ़ाइलों में डेटा संग्रहण**

PPTX फ़ाइलें — फ़ाइलें जिनका एक्सटेंशन `.pptx` है — PresentationML प्रारूप में संग्रहीत की जाती हैं, जो Office Open XML विनिर्देश का हिस्सा है। Office Open XML पैकेज संरचना और संबंधों (relationships) को परिभाषित करता है जो प्रस्तुति सामग्री और सम्बद्ध डेटा को संग्रहित करने के लिये उपयोग होते हैं।

एक प्रस्तुति कई भागों (parts) से मिलकर बनती है जो संबंधों (relationships) द्वारा जुड़ी होती हैं। उदाहरण के लिए, एक स्लाइड भाग (slide part) एकल स्लाइड की सामग्री रखता है और ISO/IEC 29500 द्वारा परिभाषित अन्य भागों के साथ स्पष्ट संबंध रख सकता है।

कस्टम डेटा को टैग ([TagCollection](https://reference.aspose.com/slides/hi/python-net/aspose.slides/tagcollection/)) या कस्टम XML भाग ([CustomXmlPartCollection](https://reference.aspose.com/slides/hi/python-net/aspose.slides/customxmlpartcollection/)) के रूप में संग्रहीत किया जा सकता है। दोनों को [`CustomData`](https://reference.aspose.com/slides/hi/python-net/aspose.slides/customdata/) वर्ग के माध्यम से पहुँचा जा सकता है।

{{% alert color="primary" %}}
टैग साधारण स्ट्रिंग कुंजी‑मान जोड़े संग्रहीत करते हैं। कस्टम XML भाग संरचित XML डेटा संग्रहीत करते हैं और इन्हें प्रस्तुति, स्लाइड या आकार के साथ जोड़ा जा सकता है।
{{% /alert %}}

## **कस्टम XML भागों के साथ कार्य करना**

[`CustomData.custom_xml_parts`](https://reference.aspose.com/slides/hi/python-net/aspose.slides/customdata/custom_xml_parts/) प्रॉपर्टी उस विशिष्ट प्रस्तुति ऑब्जेक्ट से जुड़े कस्टम XML भागों का संग्रह देती है। उदाहरण के लिए:

- `presentation.custom_data.custom_xml_parts` प्रस्तुति स्वयं से जुड़े कस्टम XML भागों को रखता है।
- `slide.custom_data.custom_xml_parts` किसी विशिष्ट स्लाइड से जुड़े कस्टम XML भागों को रखता है।
- `shape.custom_data.custom_xml_parts` किसी विशिष्ट आकार से जुड़े कस्टम XML भागों को रखता है।

जब आपको प्रस्तुति में सभी कस्टम XML भागों को उनकी संबद्धता की परवाह किए बिना जांचना हो, तो [`Presentation.all_custom_xml_parts`](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/all_custom_xml_parts/) प्रयोग करें।

### **प्रेजेंटेशन में कस्टम XML भाग जोड़ना**

[`CustomXmlPartCollection.add`](https://reference.aspose.com/slides/hi/python-net/aspose.slides/customxmlpartcollection/add/) का उपयोग करके XML डेटा को कस्टम XML भाग संग्रह में जोड़ा जाता है। XML वैध और गैर‑खाली होना चाहिए।

निम्न उदाहरण प्रस्तुति‑स्तरीय कस्टम डेटा संग्रह में संरचित मेटाडेटा जोड़ता है:

```py
import uuid
import aspose.slides as slides

custom_xml_content = (
    '<?xml version="1.0" encoding="UTF-8"?>'
    '<metadata xmlns="urn:example:metadata">'
    '<documentId>DOC-1001</documentId>'
    '<workflowState>Draft</workflowState>'
    '</metadata>'
)

with slides.Presentation() as presentation:
    custom_xml_part = presentation.custom_data.custom_xml_parts.add(custom_xml_content)

    # add स्वचालित रूप से एक पहचानकर्ता निर्धारित करता है। केवल आवश्यक होने पर विशिष्ट GUID सेट करें।
    custom_xml_part.item_id = uuid.uuid4()

    presentation.save("presentation_with_custom_xml.pptx", slides.export.SaveFormat.PPTX)
```

`add` मेथड XML को बाइट एरे या स्ट्रीम के रूप में भी स्वीकार कर सकता है, जो तब उपयोगी होता है जब XML सामग्री पहले से बाइनरी रूप में उपलब्ध हो।

### **स्लाइड या आकार में कस्टम XML भाग जोड़ना**

कस्टम XML डेटा को पूरी प्रस्तुति के बजाय किसी विशिष्ट स्लाइड या आकार से जोड़ा जा सकता है। यह तब उपयोगी होता है जब मेटाडेटा केवल एक ऑब्जेक्ट का वर्णन करता है, जैसे टेम्पलेट कुंजी, बाह्य रिकॉर्ड पहचानकर्ता, या बाइंडिंग जानकारी।

निम्न उदाहरण एक स्लाइड में एक कस्टम XML भाग और एक आकार में दूसरा कस्टम XML भाग जोड़ता है:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    slide.custom_data.custom_xml_parts.add(
        '<slideMetadata xmlns="urn:example:slides">'
        '<templateKey>TitleSlide</templateKey>'
        '</slideMetadata>'
    )

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 250, 80)

    shape.text_frame.text = "Customer data"
    shape.custom_data.custom_xml_parts.add(
        '<shapeMetadata xmlns="urn:example:shapes">'
        '<recordId>CRM-4281</recordId>'
        '</shapeMetadata>'
    )

    presentation.save("object_custom_xml.pptx", slides.export.SaveFormat.PPTX)
```

जिस स्तर पर भाग जोड़ा जाता है, वह तय करता है कि किस ऑब्जेक्ट की `custom_data.custom_xml_parts` संग्रह में उस भाग का संबंध आता है। प्रस्तुति‑स्तरीय डेटा पूरे दस्तावेज़‑व्यापी मेटाडेटा के लिए उपयुक्त है, स्लाइड‑स्तरीय डेटा विशिष्ट स्लाइड की जानकारी के लिए, तथा आकार‑स्तरीय डेटा व्यक्तिगत आकार से जुड़ा मेटाडेटा के लिए।

### **सभी कस्टम XML भागों की सूची और ऑडिट**

[`Presentation.all_custom_xml_parts`](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/all_custom_xml_parts/) को प्रयोग करके प्रस्तुति से सभी कस्टम XML भाग प्राप्त किए जा सकते हैं। प्रत्येक [`CustomXmlPart`](https://reference.aspose.com/slides/hi/python-net/aspose.slides/customxmlpart/) अपने पहचानकर्ता, XML सामग्री और संबद्ध नेमस्पेस स्कीमा को उजागर करता है।

निम्न उदाहरण सभी कस्टम XML भागों और उनके नेमस्पेस स्कीमा को सूचीबद्ध करता है:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for custom_xml_part in presentation.all_custom_xml_parts:
        print("ItemId: " + str(custom_xml_part.item_id))
        print("XML:")
        print(custom_xml_part.xml_as_string)

        for namespace_schema in custom_xml_part.namespace_schemas:
            print("Namespace schema: " + namespace_schema)

        print()
```

[`CustomXmlPart.namespace_schemas`](https://reference.aspose.com/slides/hi/python-net/aspose.slides/customxmlpart/namespace_schemas/) कस्टम XML भाग से जुड़े XML स्कीमा लौटाता है। यह जानकारी उन प्रस्तुतियों को ऑडिट करने में उपयोगी हो सकती है जिनमें बाहरी सिस्टम द्वारा उत्पन्न XML शामिल है।

### **XML सामग्री और ItemId पढ़ना तथा अद्यतन करना**

[`CustomXmlPart.xml_as_string`](https://reference.aspose.com/slides/hi/python-net/aspose.slides/customxmlpart/xml_as_string/) का उपयोग करके XML को UTF‑8 स्ट्रिंग के रूप में संभाला जा सकता है, या [`CustomXmlPart.xml_data`](https://reference.aspose.com/slides/hi/python-net/aspose.slides/customxmlpart/xml_data/) से कच्चे XML बाइट्स को। दोनों प्रॉपर्टी पढ़ी और अद्यतन की जा सकती हैं।

[`CustomXmlPart.item_id`](https://reference.aspose.com/slides/hi/python-net/aspose.slides/customxmlpart/item_id/) प्रॉपर्टी उस GUID को रखती है जो Office Open XML दस्तावेज़ में कस्टम XML भाग की पहचान करता है। इसे तब भी बदला जा सकता है जब एकीकरण को नया पहचानकर्ता चाहिए हो।

निम्न उदाहरण XML सामग्री और पहचानकर्ता को अपडेट करता है:

```py
import uuid
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    custom_xml_part = presentation.all_custom_xml_parts[0]

    # वर्तमान XML को टेक्स्ट के रूप में पढ़ें।
    current_xml_content = custom_xml_part.xml_as_string
    print(current_xml_content)

    # XML को UTF-8 स्ट्रिंग के रूप में अपडेट करें।
    custom_xml_part.xml_as_string = (
        '<metadata xmlns="urn:example:metadata">'
        '<documentId>DOC-1001</documentId>'
        '<workflowState>Approved</workflowState>'
        '</metadata>'
    )

    # xml_data समान XML सामग्री को कच्चे बाइट्स के रूप में प्रदान करता है।
    custom_xml_data = custom_xml_part.xml_data
    print(custom_xml_data.decode("utf-8"))

    # एकीकरण द्वारा आवश्यक होने पर पहचानकर्ता को बदलें।
    custom_xml_part.item_id = uuid.uuid4()

    presentation.save("updated_custom_xml.pptx", slides.export.SaveFormat.PPTX)
```

`xml_as_string` या `xml_data` असाइन करते समय वैध, गैर‑खाली XML प्रदान करें। स्ट्रिंग या बाइट डेटा के प्राथमिक उपयोग के आधार पर किसका उपयोग करना है, वह चुनें।

### **कस्टम XML भाग हटाना**

Aspose.Slides कस्टम XML डेटा हटाने के कई तरीके देता है:

- [`CustomXmlPart.remove`](https://reference.aspose.com/slides/hi/python-net/aspose.slides/customxmlpart/remove/) कस्टम XML भाग को प्रस्तुति से हटाता है।
- [`CustomXmlPartCollection.remove`](https://reference.aspose.com/slides/hi/python-net/aspose.slides/customxmlpartcollection/remove/) कस्टम XML भाग संग्रह से एक विशिष्ट भाग हटाता है।
- [`CustomXmlPartCollection.remove_at`](https://reference.aspose.com/slides/hi/python-net/aspose.slides/customxmlpartcollection/remove_at/) निर्दिष्ट संग्रह इंडेक्स पर मौजूद भाग को हटाता है।
- [`CustomXmlPartCollection.clear`](https://reference.aspose.com/slides/hi/python-net/aspose.slides/customxmlpartcollection/clear/) किसी विशिष्ट संग्रह से सभी भाग हटाता है।

निम्न उदाहरण रेफ़रेंस द्वारा एक प्रस्तुति‑स्तरीय कस्टम XML भाग हटाता है:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    custom_xml_parts = presentation.custom_data.custom_xml_parts

    if len(custom_xml_parts) > 0:
        custom_xml_part = custom_xml_parts[0]
        custom_xml_parts.remove(custom_xml_part)

    presentation.save("custom_xml_removed.pptx", slides.export.SaveFormat.PPTX)
```

यदि आपके पास पहले से `CustomXmlPart` है और आप उसे प्रस्तुति से हटाना चाहते हैं न कि किसी विशेष संग्रह से, तो `custom_xml_part.remove()` कॉल करें।

आप इंडेक्स द्वारा भी आइटम हटा सकते हैं:

```py
presentation.custom_data.custom_xml_parts.remove_at(0)
```

### **कलेक्शन से सभी कस्टम XML भाग साफ़ करना**

जब किसी विशेष प्रस्तुति ऑब्जेक्ट से जुड़े सभी कस्टम XML भाग हटाने हों, तो `clear` का उपयोग करें।

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.slides[0].custom_data.custom_xml_parts.clear()

    presentation.save("slide_custom_xml_cleared.pptx", slides.export.SaveFormat.PPTX)
```

`clear` केवल चयनित संग्रह को प्रभावित करता है। उदाहरण के लिये, स्लाइड की संग्रह को साफ़ करने से प्रस्तुति‑स्तरीय या आकार‑स्तरीय संग्रह नहीं हटते।

सभी कस्टम XML भाग हटाने के लिये, `all_custom_xml_parts` पर इटेरेट करें और प्रत्येक भाग को हटाएँ:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for custom_xml_part in presentation.all_custom_xml_parts:
        custom_xml_part.remove()

    presentation.save("all_custom_xml_removed.pptx", slides.export.SaveFormat.PPTX)
```

### **लिंक्ड या साझा कस्टम XML भाग संभालना**

Office Open XML प्रस्तुति में वही कस्टम XML भाग एक से अधिक प्रस्तुति ऑब्जेक्ट से संदर्भित हो सकता है। उदाहरण के लिये, किसी फ़ाइल में कई स्लाइड या आकार एक ही बुनियादी कस्टम XML भाग की ओर इशारा कर सकते हैं।

एक साझा भाग को कई रेफ़रेंसेज़ के साथ एक डेटा ऑब्जेक्ट माना जाना चाहिए:

- उसकी `xml_as_string`, `xml_data` या `item_id` को अपडेट करने से बुनियादी कस्टम XML भाग बदलता है, इसलिए परिवर्तन सभी रेफ़रेंस में परिलक्षित होते हैं।
- `item_id` का उपयोग समान कस्टम XML भाग को पहचानने के लिये किया जा सकता है जबकि ऑब्जेक्ट‑स्तरीय संग्रहों को ऑडिट किया जाता है।
- किसी विशिष्ट `custom_xml_parts` संग्रह से भाग को हटाने से वह केवल उस संग्रह से हटता है। यदि भाग स्वयं को पूरी प्रस्तुति से हटाना हो, तो `CustomXmlPart.remove()` उपयोग करें।
- साझा भाग को हटाने या बदलने से पहले, ऑब्जेक्ट‑स्तरीय संग्रहों की जाँच करें कि अन्य स्लाइड या आकार अभी भी उसे संदर्भित तो नहीं कर रहे।

`add` ओवरलोड केवल XML सामग्री से नया कस्टम XML भाग बनाते हैं; वे मौजूदा `CustomXmlPart` को स्वीकार नहीं करते। इसलिए, साझा संबंध आमतौर पर उन प्रस्तुतियों को लोड करते समय मिलते हैं जिनमें पहले से ये मौजूद होते हैं।

निम्न उदाहरण `item_id` के आधार पर प्रस्तुति‑, स्लाइड‑ और आकार‑स्तरीय संग्रहों को ऑडिट करता है और उन भागों की रिपोर्ट देता है जो एक से अधिक स्थान से संदर्भित हैं:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    references_by_item_id = {}

    def register_custom_xml_parts(owner_name, custom_xml_parts):
        for custom_xml_part in custom_xml_parts:
            references_by_item_id.setdefault(custom_xml_part.item_id, []).append(owner_name)

    register_custom_xml_parts("Presentation", presentation.custom_data.custom_xml_parts)

    for slide_index, slide in enumerate(presentation.slides):
        register_custom_xml_parts(
            "Slide " + str(slide_index + 1),
            slide.custom_data.custom_xml_parts
        )

        for shape_index, shape in enumerate(slide.shapes):
            register_custom_xml_parts(
                "Slide " + str(slide_index + 1) + ", shape " + str(shape_index),
                shape.custom_data.custom_xml_parts
            )

    for item_id, owner_names in references_by_item_id.items():
        if len(owner_names) > 1:
            print("Shared custom XML part: " + str(item_id))

            for owner_name in owner_names:
                print("  Referenced by: " + owner_name)
```

यह प्रकार का ऑडिट बाहरी सिस्टमों द्वारा बनाई गई प्रस्तुतियों में कस्टम XML डेटा को संशोधित या हटाने से पहले उपयोगी होता है, क्योंकि समान मेटाडेटा भाग कई संबंधों में भाग ले सकता है।

## **टैग के मान प्राप्त करना**

स्लाइड्स में टैग `DocumentProperties.keywords` प्रॉपर्टी के अनुरूप होता है। यह नमूना कोड दिखाता है कि Aspose.Slides for Python via .NET के साथ [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) पर टैग मान कैसे प्राप्त किया जाए:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    keywords = presentation.document_properties.keywords
```

## **प्रेजेंटेशन में टैग जोड़ना**

Aspose.Slides आपको प्रस्तुतियों में टैग जोड़ने की अनुमति देता है। एक टैग सामान्यतः दो तत्वों से बना होता है:

- कस्टम प्रॉपर्टी का नाम, उदाहरण के लिये `MyTag`;
- कस्टम प्रॉपर्टी का मान, उदाहरण के लिये `My Tag Value`।

यदि आपको किसी विशिष्ट नियम या प्रॉपर्टी के आधार पर प्रस्तुतियों का वर्गीकरण करना है, तो आप इसके लिये टैग जोड़ सकते हैं। उदाहरण के लिये, यदि आप उत्तरी अमेरिकी देशों की प्रस्तुतियों को वर्गीकृत करना चाहते हैं, तो आप “North American” टैग बना सकते हैं और संबंधित देश को उसका मान असाइन कर सकते हैं।

यह नमूना कोड दिखाता है कि Aspose.Slides for Python via .NET का उपयोग करके [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) में टैग कैसे जोड़ें:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    tags = presentation.custom_data.tags
    tags.add("MyTag", "My Tag Value")
```

टैग को एक [Slide](https://reference.aspose.com/slides/hi/python-net/aspose.slides/slide/) के लिये भी सेट किया जा सकता है:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    slide.custom_data.tags.add("tag", "value")
```

या व्यक्तिगत [Shape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/shape/) के लिये:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 50)
    shape.text_frame.text = "My text"
    shape.custom_data.tags.add("tag", "value")
```

### **सीमाएँ**

`custom_data.tags` संग्रह के माध्यम से जोड़े गये टैग केवल PowerPoint फ़ाइल में संग्रहीत होते हैं। वे प्रस्तुति को PDF में निर्यात करने पर PDF टैग संरचना में **स्थानांतरित नहीं होते**। अतः, टैग के रूप में असाइन किया गया कस्टम पहचानकर्ता टैग वाले PDF से प्राप्त नहीं किया जा सकता।

**वर्कअराउंड**: आप ऑब्जेक्ट के **Alt Text** (उदाहरण : `shape.alternative_text = "MyId"`) में कस्टम पहचानकर्ता संग्रहीत कर सकते हैं। PDF में निर्यात करने पर Alt Text PDF टैग संरचना में दिखाई दे सकता है।

## **FAQ**

**क्या मैं एक ऑपरेशन में प्रस्तुति, स्लाइड या आकार से सभी टैग हटा सकता हूँ?**

हाँ। [tag collection](https://reference.aspose.com/slides/hi/python-net/aspose.slides/tagcollection/) में [clear](https://reference.aspose.com/slides/hi/python-net/aspose.slides/tagcollection/clear/) ऑपरेशन उपलब्ध है जो सभी कुंजी‑मान जोड़ों को एक बार में हटा देता है।

**मैं संग्रह को इटेरेट किए बिना नाम द्वारा एकल टैग कैसे हटा सकता हूँ?**

[TagCollection](https://reference.aspose.com/slides/hi/python-net/aspose.slides/tagcollection/) पर `remove(name)` का उपयोग करके कुंजी द्वारा टैग हटाएँ।

**एनालिटिक्स या फ़िल्टरिंग के लिये टैग नामों की पूरी सूची कैसे प्राप्त करूँ?**

[tag collection](https://reference.aspose.com/slides/hi/python-net/aspose.slides/tagcollection/) पर `get_names_of_tags` का उपयोग करें; यह सभी टैग नामों का ऐरे लौटाता है।

**मैं सभी कस्टम XML भागों को उनके संग्रह के स्थान की परवाह किए बिना कैसे खोजूँ?**

[`Presentation.all_custom_xml_parts`](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/all_custom_xml_parts/) का उपयोग करके प्रस्तुति में सभी कस्टम XML भाग प्राप्त करें।

**कस्टम XML भाग को अपडेट करने के लिये `xml_as_string` या `xml_data` में से कौनसा प्रयोग करूँ?**

जब एप्लिकेशन UTF‑8 XML टेक्स्ट के साथ काम करता है तो `xml_as_string` प्रयोग करें। जब XML पहले से बाइट एरे के रूप में उपलब्ध हो या बाइनरी‑उन्मुख प्रोसेसिंग अधिक सुविधाजनक हो तो `xml_data` प्रयोग करें। दोनों प्रॉपर्टी एक ही कस्टम XML भाग की XML सामग्री का प्रतिनिधित्व करती हैं।