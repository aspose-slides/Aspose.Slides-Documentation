---
title: प्रेज़ेंटेशन में टैग और कस्टम डेटा को JavaScript का उपयोग करके प्रबंधित करें
linktitle: टैग और कस्टम डेटा
type: docs
weight: 300
url: /hi/nodejs-java/managing-tags-and-custom-data/
keywords:
- दस्तावेज़ गुण
- टैग
- कस्टम डेटा
- कस्टम XML
- कस्टम XML भाग
- XML मेटाडेटा
- ItemId
- टैग जोड़ें
- जुड़ी मान
- PowerPoint
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java के साथ PowerPoint प्रस्तुतियों में टैग और कस्टम XML डेटा को प्रबंधित करना सीखें, जिसमें कस्टम XML भागों को जोड़ना, पढ़ना, अपडेट करना, ऑडिट करना और हटाना शामिल है।"
---
## **अवलोकन**

यह लेख बताता है कि Aspose.Slides PowerPoint प्रस्तुतियों में टैग और कस्टम डेटा के साथ कैसे कार्य करता है। प्रस्तुति‑विशिष्ट डेटा को टैग या कस्टम XML भागों के रूप में संग्रहीत किया जा सकता है। टैग साधारण कुंजी‑मान स्ट्रिंग जोड़े होते हैं, जबकि कस्टम XML भाग संरचित मेटाडेटा और एप्लिकेशन‑विशिष्ट XML पेलोड संग्रहीत कर सकते हैं।

Aspose.Slides प्रस्तुति, स्लाइड और आकार स्तरों पर कस्टम XML भागों को जोड़ने, पढ़ने, अपडेट करने, ऑडिट करने और हटाने के लिए API प्रदान करता है। कस्टम XML भाग उन एकीकरणों के लिए उपयोगी होते हैं जो दस्तावेज़‑प्रबंधन पहचानकर्ता, वर्कफ़्लो स्थिति, अनुपालन मेटाडेटा, टेम्पलेट‑बाइंडिंग डेटा या अन्य संरचित एप्लिकेशन डेटा जैसे जानकारी को प्रस्तुति के भीतर संग्रहीत करते हैं।

## **प्रस्तुति फ़ाइलों में डेटा संग्रहण**

PPTX फ़ाइलें — जिनका एक्सटेंशन `.pptx` है — PresentationML फ़ॉर्मेट में संग्रहीत होती हैं, जो Office Open XML विशिष्टता का हिस्सा है। Office Open XML पैकेज संरचना और संबंधों को परिभाषित करता है जो प्रस्तुति सामग्री और संबंधित डेटा को संग्रहीत करने के लिए उपयोग होते हैं।

एक प्रस्तुति में कई भाग होते हैं जो संबंधों द्वारा जुड़े होते हैं। उदाहरण के लिए, एक स्लाइड भाग में एकल स्लाइड की सामग्री होती है और इसमें ISO/IEC 29500 द्वारा परिभाषित अन्य भागों के स्पष्ट संबंध हो सकते हैं।

कस्टम डेटा को टैग ([TagCollection](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/tagcollection/)) या कस्टम XML भागों ([CustomXmlPartCollection](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/customxmlpartcollection/)) के रूप में संग्रहीत किया जा सकता है। दोनों ही [`CustomData`](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/customdata/) क्लास के माध्यम से उपलब्ध हैं।

{{% alert color="primary" %}}

टैग सरल स्ट्रिंग कुंजी‑मान जोड़े संग्रहीत करते हैं। कस्टम XML भाग संरचित XML डेटा संग्रहीत करते हैं और प्रस्तुति, स्लाइड या आकार के साथ जुड़ सकते हैं।

{{% /alert %}}

## **कस्टम XML भागों के साथ कार्य करना**

[`CustomData`](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/customdata/) की `getCustomXmlParts()` मेथड एक विशिष्ट प्रस्तुति वस्तु से जुड़े कस्टम XML भागों का संग्रह लौटाती है। उदाहरण के लिए:

- `presentation.getCustomData().getCustomXmlParts()` में स्वयं प्रस्तुति से जुड़े कस्टम XML भाग शामिल होते हैं।
- `slide.getCustomData().getCustomXmlParts()` में किसी विशिष्ट स्लाइड से जुड़े कस्टम XML भाग शामिल होते हैं।
- `shape.getCustomData().getCustomXmlParts()` में किसी विशिष्ट आकार से जुड़े कस्टम XML भाग शामिल होते हैं।

जब आपको प्रस्तुति में सभी कस्टम XML भागों की जाँच करनी हो, चाहे वे कहीं भी जुड़े हों, तो [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) का उपयोग करें।

### **प्रस्तुति में कस्टम XML भाग जोड़ना**

[`CustomXmlPartCollection`](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/customxmlpartcollection/) की `add` मेथड का उपयोग करके XML डेटा को कस्टम XML भाग संग्रह में जोड़ा जाता है। XML वैध और गैर‑खाली होना चाहिए।

नीचे दिया गया उदाहरण प्रस्तुति‑स्तर के कस्टम डेटा संग्रह में संरचित मेटाडेटा जोड़ता है:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const customXmlContent =
    '<?xml version="1.0" encoding="UTF-8"?>' +
    '<metadata xmlns="urn:example:metadata">' +
        '<documentId>DOC-1001</documentId>' +
        '<workflowState>Draft</workflowState>' +
    '</metadata>';

const presentation = new aspose.slides.Presentation();
try {
    const customXmlPart = presentation.getCustomData().getCustomXmlParts().add(customXmlContent);

    // add स्वचालित रूप से एक पहचानकर्ता निर्धारित करता है। केवल आवश्यकता होने पर ही एक विशिष्ट UUID सेट करें।
    const itemId = java.callStaticMethodSync("java.util.UUID", "randomUUID");
    customXmlPart.setItemId(itemId);

    presentation.save("presentation_with_custom_xml.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`add` मेथड बाइट ऐरे के रूप में भी XML स्वीकार कर सकती है, जो तब उपयोगी होता है जब XML सामग्री पहले से बाइनरी रूप में उपलब्ध हो।

### **स्लाइड या आकार में कस्टम XML भाग जोड़ना**

कस्टम XML डेटा को पूरी प्रस्तुति के बजाय किसी विशिष्ट स्लाइड या आकार से जोड़ा जा सकता है। यह तब उपयोगी होता है जब मेटाडेटा केवल एक वस्तु का वर्णन करता है, जैसे टेम्पलेट कुंजी, बाहरी रिकॉर्ड पहचानकर्ता, या बाइंडिंग जानकारी।

नीचे दिया गया उदाहरण एक कस्टम XML भाग को स्लाइड में और另 एक को आकार में जोड़ता है:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    slide.getCustomData().getCustomXmlParts().add(
        '<slideMetadata xmlns="urn:example:slides">' +
            '<templateKey>TitleSlide</templateKey>' +
        '</slideMetadata>');

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 250, 80);

    shape.getTextFrame().setText("Customer data");
    shape.getCustomData().getCustomXmlParts().add(
        '<shapeMetadata xmlns="urn:example:shapes">' +
            '<recordId>CRM-4281</recordId>' +
        '</shapeMetadata>');

    presentation.save("object_custom_xml.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

जिस स्तर पर भाग जोड़ा जाता है, उसके आधार पर किस वस्तु की `getCustomData().getCustomXmlParts()` संग्रह में उस भाग का संबंध होता है। प्रस्तुति‑स्तर का डेटा दस्तावेज़‑व्यापी मेटाडेटा के लिए उपयुक्त है, स्लाइड‑स्तर का डेटा विशिष्ट स्लाइड की जानकारी के लिए, और आकार‑स्तर का डेटा व्यक्तिगत आकार से जुड़े मेटाडेटा के लिए।

### **सभी कस्टम XML भागों की सूची और ऑडिट करना**

[`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) का उपयोग करके प्रस्तुति से सभी कस्टम XML भाग प्राप्त किए जा सकते हैं। प्रत्येक [`CustomXmlPart`](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/customxmlpart/) अपना पहचानकर्ता, XML सामग्री और संबंधित नेमस्पेस स्कीमा प्रदर्शित करता है।

नीचे दिया गया उदाहरण सभी कस्टम XML भागों और उनके नेमस्पेस स्कीमा को सूचीबद्ध करता है:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const customXmlParts = presentation.getAllCustomXmlParts();

    for (let partIndex = 0; partIndex < customXmlParts.length; partIndex++) {
        const customXmlPart = customXmlParts[partIndex];

        console.log("ItemId: " + customXmlPart.getItemId());
        console.log("XML:");
        console.log(customXmlPart.getXmlAsString());

        const namespaceSchemas = customXmlPart.getNamespaceSchemas();
        for (let schemaIndex = 0; schemaIndex < namespaceSchemas.length; schemaIndex++) {
            console.log("Namespace schema: " + namespaceSchemas[schemaIndex]);
        }

        console.log();
    }
} finally {
    presentation.dispose();
}
```

[`CustomXmlPart.getNamespaceSchemas()`](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/customxmlpart/) कस्टम XML भाग से जुड़े XML स्कीमा लौटाता है। यह जानकारी उन प्रस्तुतियों को ऑडिट करते समय उपयोगी हो सकती है जिनमें बाहरी सिस्टम द्वारा निर्मित XML शामिल है।

### **XML सामग्री और ItemId पढ़ना और अपडेट करना**

[`CustomXmlPart`](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/customxmlpart/) से `getXmlAsString()` और `setXmlAsString()` का उपयोग करके XML को UTF-8 स्ट्रिंग के रूप में कार्य किया जा सकता है, या `getXmlData()` और `setXmlData()` से कच्चे XML बाइट्स के साथ।

`getItemId()` मेथड वह UUID लौटाता है जो Office Open XML दस्तावेज़ में कस्टम XML भाग की पहचान करता है। जब एकीकरण को नया पहचानकर्ता चाहिए तो `setItemId()` का उपयोग करें।

नीचे दिया गया उदाहरण XML सामग्री और पहचानकर्ता को अपडेट करता है:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const customXmlPart = presentation.getAllCustomXmlParts()[0];

    // वर्तमान XML को टेक्स्ट के रूप में पढ़ें।
    const currentXmlContent = customXmlPart.getXmlAsString();
    console.log(currentXmlContent);

    // XML को UTF-8 स्ट्रिंग के रूप में अपडेट करें।
    customXmlPart.setXmlAsString(
        '<metadata xmlns="urn:example:metadata">' +
            '<documentId>DOC-1001</documentId>' +
            '<workflowState>Approved</workflowState>' +
        '</metadata>');

    // getXmlData समान XML सामग्री को कच्चे बाइट्स के रूप में प्रदान करता है।
    const customXmlData = customXmlPart.getXmlData();
    console.log(Buffer.from(customXmlData).toString("utf8"));

    // एकीकरण द्वारा आवश्यक होने पर पहचानकर्ता को बदलें।
    const itemId = java.callStaticMethodSync("java.util.UUID", "randomUUID");
    customXmlPart.setItemId(itemId);

    presentation.save("updated_custom_xml.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`setXmlAsString` या `setXmlData` को कॉल करते समय वैध, गैर‑खाली XML प्रदान करें। स्ट्रिंग या बाइट डेटा में से एक प्रतिनिधित्व का चयन एप्लिकेशन की प्राथमिकता पर निर्भर करता है।

### **कस्टम XML भाग हटाना**

Aspose.Slides कस्टम XML डेटा को हटाने के कई तरीके प्रदान करता है:

- [`CustomXmlPart.remove`](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/customxmlpart/) कस्टम XML भाग को प्रस्तुति से हटाता है।
- [`CustomXmlPartCollection.remove`](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/customxmlpartcollection/) कस्टम XML भाग संग्रह से निर्दिष्ट भाग को हटाता है।
- [`CustomXmlPartCollection.removeAt`](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/customxmlpartcollection/) संग्रह के निर्दिष्ट सूचकांक पर मौजूद भाग को हटाता है।
- [`CustomXmlPartCollection.clear`](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/customxmlpartcollection/) किसी विशेष संग्रह से सभी भागों को हटाता है।

नीचे दिया गया उदाहरण संदर्भ द्वारा एक प्रस्तुति‑स्तर कस्टम XML भाग को हटाता है:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const customXmlParts = presentation.getCustomData().getCustomXmlParts();

    if (customXmlParts.size() > 0) {
        const customXmlPart = customXmlParts.get_Item(0);
        customXmlParts.remove(customXmlPart);
    }

    presentation.save("custom_xml_removed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

यदि आपके पास पहले से `CustomXmlPart` है और आप उसे संग्रह को निर्दिष्ट किए बिना प्रस्तुति से हटाना चाहते हैं, तो `customXmlPart.remove()` को कॉल करें।

आप सूचकांक द्वारा भी कोई आइटम हटा सकते हैं:

```javascript
presentation.getCustomData().getCustomXmlParts().removeAt(0);
```

### **एक संग्रह से सभी कस्टम XML भाग साफ़ करना**

जब किसी विशेष प्रस्तुति वस्तु से जुड़े सभी कस्टम XML भाग हटाने हों, तो `clear` का उपयोग करें।

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.getSlides().get_Item(0).getCustomData().getCustomXmlParts().clear();

    presentation.save("slide_custom_xml_cleared.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`clear` केवल चयनित संग्रह को प्रभावित करता है। उदाहरण के लिए, स्लाइड की संग्रह को साफ़ करने से प्रस्तुति‑स्तर या आकार‑स्तर के संग्रह साफ़ नहीं होते।

सभी कस्टम XML भागों को हटाने के लिए `getAllCustomXmlParts()` पर इटररेट करें और प्रत्येक भाग को हटाएँ:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const customXmlParts = presentation.getAllCustomXmlParts();

    for (let partIndex = 0; partIndex < customXmlParts.length; partIndex++) {
        customXmlParts[partIndex].remove();
    }

    presentation.save("all_custom_xml_removed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **लिंक्ड या साझा कस्टम XML भागों को संभालना**

Office Open XML प्रस्तुति में वही कस्टम XML भाग कई प्रस्तुति वस्तुओं से संदर्भित किया जा सकता है। उदाहरण के लिए, किसी मौजूदा फ़ाइल में कई स्लाइड या आकार एक ही अंतर्निहित कस्टम XML भाग के संबंध रख सकते हैं।

एक साझा भाग को कई संदर्भों वाला एक डेटा ऑब्जेक्ट माना जाना चाहिए:

- `setXmlAsString`, `setXmlData` या `setItemId` से अपडेट करने से अंतर्निहित कस्टम XML भाग बदलता है, इसलिए परिवर्तन जहाँ‑जहाँ भाग का संदर्भ है, वहाँ लागू होता है।
- `getItemId()` का उपयोग ऑब्जेक्ट‑स्तर संग्रहों को ऑडिट करते समय वही कस्टम XML भाग पहचानने के लिए किया जा सकता है।
- किसी विशिष्ट `getCustomXmlParts()` संग्रह से भाग हटाने से वह केवल उस संग्रह से हटता है। यदि भाग स्वयं को पूरी प्रस्तुति से हटाना हो, तो `CustomXmlPart.remove()` उपयोग करें।
- किसी साझा भाग को हटाने या प्रतिस्थापित करने से पहले, ऑब्जेक्ट‑स्तर संग्रहों की जाँच करें कि क्या अन्य स्लाइड या आकार अभी भी उसका संदर्भ रख रहे हैं।

`add` ओवरलोड नई XML सामग्री से एक नया कस्टम XML भाग बनाते हैं; वे मौजूदा `CustomXmlPart` को स्वीकृत नहीं करते। इसलिए, साझा संबंध सबसे अधिक उन प्रस्तुतियों में देखे जाते हैं जो पहले से उन्हें शामिल करती हैं।

नीचे दिया गया उदाहरण `ItemId` द्वारा प्रस्तुति‑, स्लाइड‑ और आकार‑स्तर संग्रहों को ऑडिट करता है और उन भागों की रिपोर्ट करता है जो अधिकतम एक स्थान से अधिक संदर्भित हैं:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const referencesByItemId = new Map();

    const registerCustomXmlParts = (ownerName, customXmlParts) => {
        for (let partIndex = 0; partIndex < customXmlParts.size(); partIndex++) {
            const customXmlPart = customXmlParts.get_Item(partIndex);
            const itemId = customXmlPart.getItemId().toString();

            if (!referencesByItemId.has(itemId)) {
                referencesByItemId.set(itemId, []);
            }

            referencesByItemId.get(itemId).push(ownerName);
        }
    };

    registerCustomXmlParts("Presentation", presentation.getCustomData().getCustomXmlParts());

    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);

        registerCustomXmlParts("Slide " + (slideIndex + 1), slide.getCustomData().getCustomXmlParts());

        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);

            registerCustomXmlParts("Slide " + (slideIndex + 1) + ", shape " + shapeIndex, shape.getCustomData().getCustomXmlParts());
        }
    }

    for (const [itemId, owners] of referencesByItemId) {
        if (owners.length > 1) {
            console.log("Shared custom XML part: " + itemId);

            for (const ownerName of owners) {
                console.log("  Referenced by: " + ownerName);
            }
        }
    }
} finally {
    presentation.dispose();
}
```

यह प्रकार का ऑडिट बाहरी सिस्टम द्वारा निर्मित प्रस्तुतियों में कस्टम XML डेटा को संशोधित या हटाने से पहले उपयोगी है, क्योंकि वही मेटाडेटा भाग कई संबंधों में भाग ले सकता है।

## **टैग के मान प्राप्त करना**

स्लाइड में, टैग `DocumentProperties.getKeywords()` मेथड के अनुरूप होता है। यह नमूना कोड दिखाता है कि Aspose.Slides for Node.js via Java के साथ [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) में टैग मान कैसे प्राप्त किया जाए:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const keywords = presentation.getDocumentProperties().getKeywords();
} finally {
    presentation.dispose();
}
```

## **प्रस्तुति में टैग जोड़ना**

Aspose.Slides आपको प्रस्तुतियों में टैग जोड़ने की सुविधा देता है। एक टैग आमतौर पर दो आइटमों से बना होता है:

- एक कस्टम प्रॉपर्टी का नाम, उदाहरण के लिए `MyTag`;
- कस्टम प्रॉपर्टी का मान, उदाहरण के लिए `My Tag Value`.

यदि आपको किसी विशिष्ट नियम या प्रॉपर्टी के आधार पर प्रस्तुतियों को वर्गीकृत करने की आवश्यकता है, तो आप उसके लिए टैग जोड़ सकते हैं। उदाहरण के लिए, यदि आप उत्तरी अमेरिकी देशों की प्रस्तुतियों को वर्गीकृत करना चाहते हैं, तो आप एक North American टैग बना सकते हैं और संबंधित देश को उसका मान असाइन कर सकते हैं।

यह नमूना कोड दिखाता है कि Aspose.Slides for Node.js via Java का उपयोग करके [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) में टैग कैसे जोड़ा जाए:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const tags = presentation.getCustomData().getTags();
    tags.set_Item("MyTag", "My Tag Value");
} finally {
    presentation.dispose();
}
```

टैग को एक [Slide](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/slide/) के लिए भी सेट किया जा सकता है:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    slide.getCustomData().getTags().set_Item("tag", "value");
} finally {
    presentation.dispose();
}
```

या व्यक्तिगत [Shape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/autoshape/) के लिए:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 50);

    shape.getTextFrame().setText("My text");
    shape.getCustomData().getTags().set_Item("tag", "value");
} finally {
    presentation.dispose();
}
```

### **सीमाएँ**

`getCustomData().getTags()` संग्रह के माध्यम से जोड़े गए टैग केवल PowerPoint फ़ाइल में संग्रहीत होते हैं। वे प्रस्तुति को PDF में निर्यात करने पर PDF टैग संरचना में स्थानांतरित **नहीं** होते। परिणामस्वरूप, टैग के रूप में असाइन किया गया कस्टम पहचानकर्ता टैग्ड PDF से प्राप्त नहीं किया जा सकता।

**कार्यवाही**: आप कस्टम पहचानकर्ता को वस्तु के **Alt Text** (उदाहरण के लिए `shape.setAlternativeText("MyId")`) में संग्रहीत कर सकते हैं। PDF में निर्यात करने के बाद, Alt Text PDF टैग संरचना में दिखाई दे सकता है।

## **FAQ**

**क्या मैं एक ही ऑपरेशन में प्रस्तुति, स्लाइड या आकार से सभी टैग हटा सकता हूँ?**

हाँ। [tag collection](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/tagcollection/) में `clear` ऑपरेशन समर्थित है जो सभी कुंजी‑मान जोड़े एक साथ हटा देता है।

**मैं पूरे संग्रह को इटररेट किए बिना टैग के नाम से एकल टैग कैसे हटाऊँ?**

[tag collection](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/tagcollection/) पर `remove(name)` का उपयोग करके टैग को उसकी कुंजी से हटाएँ।

**मैं विश्लेषण या फ़िल्टरिंग के लिए टैग के नामों की पूरी सूची कैसे प्राप्त कर सकता हूँ?**

[tag collection](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/tagcollection/) पर `getNamesOfTags()` का उपयोग करें; यह सभी टैग नामों की एरे लौटाता है।

**मैं सभी कस्टम XML भाग कहाँ‑कहाँ संग्रहीत हों, यह कैसे पता करूँ?**

[`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) का उपयोग करके प्रस्तुति में सभी कस्टम XML भाग प्राप्त करें।

**कस्टम XML भाग को अपडेट करने के लिए मुझे `getXmlAsString`/`setXmlAsString` या `getXmlData`/`setXmlData` में से कौन सा उपयोग करना चाहिए?**

जब एप्लिकेशन UTF‑8 XML टेक्स्ट के साथ काम करता है, तब `getXmlAsString` और `setXmlAsString` उपयोग करें। जब XML पहले से बाइट ऐरे के रूप में उपलब्ध हो या बाइनरी‑उन्मुख प्रोसेसिंग अधिक सुविधाजनक हो, तो `getXmlData` और `setXmlData` उपयोग करें। दोनों प्रतिनिधित्व एक ही कस्टम XML भाग की XML सामग्री को दर्शाते हैं।