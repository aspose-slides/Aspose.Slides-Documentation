---
title: Java का उपयोग करके प्रस्तुतियों में टैग और कस्टम डेटा का प्रबंधन
linktitle: टैग और कस्टम डेटा
type: docs
weight: 300
url: /hi/java/managing-tags-and-custom-data/
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
- Java
- Aspose.Slides
description: "Aspose.Slides for Java के साथ PowerPoint प्रस्तुतियों में टैग और कस्टम XML डेटा का प्रबंधन सीखें, जिसमें टैग जोड़ना, पढ़ना, अपडेट करना, ऑडिट करना और कस्टम XML भाग हटाना शामिल है।"
---
## **अवलोकन**

यह लेख समझाता है कि Aspose.Slides PowerPoint प्रस्तुतियों में टैग और कस्टम डेटा के साथ कैसे काम करता है। प्रस्तुति‑विशिष्ट डेटा को टैग या कस्टम XML भाग के रूप में संग्रहीत किया जा सकता है। टैग साधारण कुंजी‑मूल्य स्ट्रिंग जोड़े होते हैं, जबकि कस्टम XML भाग संरचित मेटाडेटा और एप्लिकेशन‑विशिष्ट XML पेलोड संग्रहीत कर सकते हैं।

Aspose.Slides प्रस्तुति, स्लाइड और आकार स्तरों पर कस्टम XML भाग को जोड़ने, पढ़ने, अपडेट करने, ऑडिट करने और हटाने के लिए API प्रदान करता है। कस्टम XML भाग उन एकीकरणों के लिए उपयोगी हैं जो दस्तावेज़‑प्रबंधन पहचानकर्ता, कार्यप्रवाह स्थिति, अनुपालन मेटाडेटा, टेम्प्लेट‑बाइंडिंग डेटा, या प्रस्तुतियों के भीतर अन्य संरचित एप्लिकेशन डेटा जैसी जानकारी संग्रहीत करते हैं।

## **प्रस्तुति फ़ाइलों में डेटा संग्रहण**

PPTX फ़ाइलें—`.pptx` एक्सटेंशन वाली फ़ाइलें—PresentationML फ़ॉर्मेट में संग्रहीत होती हैं, जो Office Open XML विनिर्देशन का हिस्सा है। Office Open XML पैकेज संरचना और रिश्तों को परिभाषित करता है जो प्रस्तुति सामग्री और संबंधित डेटा को संग्रहीत करने के लिए उपयोग होते हैं।

एक प्रस्तुति में कई भाग होते हैं जो रिश्तों द्वारा जुड़े होते हैं। उदाहरण के लिए, एक स्लाइड भाग एकल स्लाइड की सामग्री रखता है और ISO/IEC 29500 द्वारा परिभाषित अन्य भागों से स्पष्ट रिश्ते रख सकता है।

कस्टम डेटा को टैग ([ITagCollection](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ITagCollection)) या कस्टम XML भाग ([ICustomXmlPartCollection](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ICustomXmlPartCollection)) के रूप में संग्रहीत किया जा सकता है। दोनों `[`ICustomData`](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ICustomData/)` इंटरफ़ेस के माध्यम से उपलब्ध हैं।

{{% alert color="info" %}}
टैग साधारण स्ट्रिंग कुंजी‑मूल्य जोड़े संग्रहीत करते हैं। कस्टम XML भाग संरचित XML डेटा संग्रहीत करते हैं और प्रस्तुति, स्लाइड या आकार से जुड़ सकते हैं।
{{% /alert %}}

## **कस्टम XML भागों के साथ कार्य करें**

`[`ICustomData.getCustomXmlParts()`](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ICustomData#getCustomXmlParts--)` मेथड किसी विशेष प्रस्तुति ऑब्जेक्ट से जुड़े कस्टम XML भागों का संग्रह लौटाता है। उदाहरण के लिए:

- `presentation.getCustomData().getCustomXmlParts()` प्रस्तुति स्वयं से जुड़े कस्टम XML भागों को समाहित करता है।
- `slide.getCustomData().getCustomXmlParts()` एक विशिष्ट स्लाइड से जुड़े कस्टम XML भागों को समाहित करता है।
- `shape.getCustomData().getCustomXmlParts()` एक विशिष्ट आकार से जुड़े कस्टम XML भागों को समाहित करता है।

जब आपको प्रस्तुति में सभी कस्टम XML भागों का निरीक्षण करना हो, चाहे वे कहीं भी जुड़े हों, तो `[`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation#getAllCustomXmlParts--)` का उपयोग करें।

### **प्रस्तुति में एक कस्टम XML भाग जोड़ें**

`[`ICustomXmlPartCollection.add`](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ICustomXmlPartCollection#add-java.lang.String-)` का उपयोग करके XML डेटा को कस्टम XML भाग संग्रह में जोड़ा जा सकता है। XML मान्य और खाली नहीं होना चाहिए।

निम्न उदाहरण प्रस्तुति‑स्तर के कस्टम डेटा संग्रह में संरचित मेटाडेटा जोड़ता है:

```java
import com.aspose.slides.*;
import java.util.UUID;

String customXmlContent =
    "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
    "<metadata xmlns=\"urn:example:metadata\">" +
        "<documentId>DOC-1001</documentId>" +
        "<workflowState>Draft</workflowState>" +
    "</metadata>";

Presentation presentation = new Presentation();
try {
    ICustomXmlPart customXmlPart = presentation.getCustomData().getCustomXmlParts().add(customXmlContent);

    // add स्वचालित रूप से एक पहचानकर्ता असाइन करता है। केवल आवश्यकता पड़ने पर विशिष्ट UUID सेट करें।
    customXmlPart.setItemId(UUID.randomUUID());

    presentation.save("presentation_with_custom_xml.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`add` मेथड XML को बाइट ऐरे या इनपुट स्ट्रीम के रूप में भी स्वीकार कर सकता है, जो तब उपयोगी होता है जब XML सामग्री पहले से बाइनरी रूप में उपलब्ध हो।

### **स्लाइड या आकार में एक कस्टम XML भाग जोड़ें**

कस्टम XML डेटा को पूरी प्रस्तुति के बजाय विशिष्ट स्लाइड या आकार से जोड़ा जा सकता है। यह तब उपयोगी होता है जब मेटाडेटा केवल एक ऑब्जेक्ट का वर्णन करता है, जैसे टेम्प्लेट कुंजी, बाहरी रिकॉर्ड पहचानकर्ता, या बाइंडिंग जानकारी।

निम्न उदाहरण एक कस्टम XML भाग स्लाइड में और另一 को आकार में जोड़ता है:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    slide.getCustomData().getCustomXmlParts().add(
        "<slideMetadata xmlns=\"urn:example:slides\">" +
            "<templateKey>TitleSlide</templateKey>" +
        "</slideMetadata>");

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 250, 80);

    shape.getTextFrame().setText("Customer data");
    shape.getCustomData().getCustomXmlParts().add(
        "<shapeMetadata xmlns=\"urn:example:shapes\">" +
            "<recordId>CRM-4281</recordId>" +
        "</shapeMetadata>");

    presentation.save("object_custom_xml.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

जिस स्तर पर भाग जोड़ा जाता है, वह निर्धारित करता है कि किस ऑब्जेक्ट की `getCustomData().getCustomXmlParts()` संग्रह में उस भाग का संबंध रहता है। प्रस्तुति‑स्तर का डेटा दस्तावेज़‑व्यापी मेटाडेटा के लिए उपयुक्त है, स्लाइड‑स्तर का डेटा विशिष्ट स्लाइड के लिए, और आकार‑स्तर का डेटा व्यक्तिगत आकार के लिए।

### **सभी कस्टम XML भागों की सूची और ऑडिट करें**

`[`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation#getAllCustomXmlParts--)` का उपयोग करके प्रस्तुति से सभी कस्टम XML भाग प्राप्त करें। प्रत्येक `[`ICustomXmlPart`](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ICustomXmlPart/)` अपना पहचानकर्ता, XML सामग्री और संबंधित नेमस्पेस स्कीमा उजागर करता है।

निम्न उदाहरण सभी कस्टम XML भागों और उनके नेमस्पेस स्कीमा को सूचीबद्ध करता है:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    for (ICustomXmlPart customXmlPart : presentation.getAllCustomXmlParts()) {
        System.out.println("ItemId: " + customXmlPart.getItemId());
        System.out.println("XML:");
        System.out.println(customXmlPart.getXmlAsString());

        for (String namespaceSchema : customXmlPart.getNamespaceSchemas()) {
            System.out.println("Namespace schema: " + namespaceSchema);
        }

        System.out.println();
    }
} finally {
    presentation.dispose();
}
```

`[`ICustomXmlPart.getNamespaceSchemas()`](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ICustomXmlPart#getNamespaceSchemas--)` कस्टम XML भाग से जुड़े XML स्कीमा लौटाता है। यह जानकारी उन प्रस्तुतियों के ऑडिट करने में उपयोगी हो सकती है जिनमें बाहरी सिस्टम द्वारा उत्पन्न XML शामिल है।

### **XML सामग्री और ItemId पढ़ें और अपडेट करें**

XML को UTF‑8 स्ट्रिंग के रूप में संभालने के लिए `[`ICustomXmlPart.getXmlAsString()`](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ICustomXmlPart#getXmlAsString--)` और `setXmlAsString()` का उपयोग करें, या कच्चे XML बाइट्स के लिए `getXmlData()` और `setXmlData()` का उपयोग करें।

`[`ICustomXmlPart.getItemId()`](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ICustomXmlPart#getItemId--)` मेथड वह UUID लौटाता है जो Office Open XML दस्तावेज़ में कस्टम XML भाग की पहचान करता है। जब एकीकृत प्रणाली को नया पहचानकर्ता चाहिए, तो `setItemId()` का उपयोग करें।

निम्न उदाहरण XML सामग्री और पहचानकर्ता को अपडेट करता है:

```java
import com.aspose.slides.*;
import java.nio.charset.StandardCharsets;
import java.util.UUID;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ICustomXmlPart customXmlPart = presentation.getAllCustomXmlParts()[0];

    // वर्तमान XML को टेक्स्ट के रूप में पढ़ें।
    String currentXmlContent = customXmlPart.getXmlAsString();
    System.out.println(currentXmlContent);

    // XML को UTF-8 स्ट्रिंग के रूप में अपडेट करें।
    customXmlPart.setXmlAsString(
        "<metadata xmlns=\"urn:example:metadata\">" +
            "<documentId>DOC-1001</documentId>" +
            "<workflowState>Approved</workflowState>" +
        "</metadata>");

    // getXmlData वही XML सामग्री को कच्चे बाइट्स के रूप में प्रदान करता है।
    byte[] customXmlData = customXmlPart.getXmlData();
    System.out.println(new String(customXmlData, StandardCharsets.UTF_8));

    // एकीकरण द्वारा आवश्यक होने पर पहचानकर्ता को बदलें।
    customXmlPart.setItemId(UUID.randomUUID());

    presentation.save("updated_custom_xml.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`setXmlAsString` या `setXmlData` को कॉल करते समय मान्य, खाली नहीं होने वाला XML प्रदान करें। एप्लिकेशन के मुख्य डेटा स्वरूप के अनुसार स्ट्रिंग या बाइट प्रतिनिधित्व में से एक का उपयोग करें।

### **कस्टम XML भाग हटाएँ**

Aspose.Slides कस्टम XML डेटा को हटाने के कई तरीके प्रदान करता है:

- `[`ICustomXmlPart.remove`](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ICustomXmlPart#remove--)` कस्टम XML भाग को प्रस्तुति से हटाता है।
- `[`ICustomXmlPartCollection.remove`](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ICustomXmlPartCollection#remove-com.aspose.slides.ICustomXmlPart-)` एक विशिष्ट भाग को कस्टम XML भाग संग्रह से हटाता है।
- `[`ICustomXmlPartCollection.removeAt`](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ICustomXmlPartCollection#removeAt-int--)` निर्दिष्ट संग्रह सूचकांक पर स्थित भाग को हटाता है।
- `[`ICustomXmlPartCollection.clear`](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ICustomXmlPartCollection#clear--)` किसी विशिष्ट संग्रह के सभी भागों को हटाता है।

निम्न उदाहरण संदर्भ द्वारा एक प्रस्तुति‑स्तर कस्टम XML भाग को हटाता है:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ICustomXmlPartCollection customXmlParts = presentation.getCustomData().getCustomXmlParts();

    if (customXmlParts.size() > 0) {
        ICustomXmlPart customXmlPart = customXmlParts.get_Item(0);
        customXmlParts.remove(customXmlPart);
    }

    presentation.save("custom_xml_removed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

यदि आपके पास पहले से `ICustomXmlPart` है और आप उसे प्रस्तुति से हटाना चाहते हैं, तो `customXmlPart.remove()` कॉल करें।

आप सूचकांक द्वारा भी एक आइटम हटा सकते हैं:

```java
presentation.getCustomData().getCustomXmlParts().removeAt(0);
```

### **कलेक्शन से सभी कस्टम XML भाग साफ़ करें**

जब किसी विशेष प्रस्तुति ऑब्जेक्ट से जुड़े सभी कस्टम XML भाग हटाने हों, तो `clear` का उपयोग करें।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getSlides().get_Item(0).getCustomData().getCustomXmlParts().clear();

    presentation.save("slide_custom_xml_cleared.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`clear` केवल चयनित संग्रह को प्रभावित करता है। उदाहरण के लिए, स्लाइड की संग्रह को साफ़ करने से प्रस्तुति‑स्तर या आकार‑स्तर की संग्रह नहीं हटती।

प्रस्तुति में प्रत्येक कस्टम XML भाग को हटाने के लिए `getAllCustomXmlParts()` के माध्यम से iterate करें और प्रत्येक भाग को हटाएँ:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    for (ICustomXmlPart customXmlPart : presentation.getAllCustomXmlParts()) {
        customXmlPart.remove();
    }

    presentation.save("all_custom_xml_removed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **लिंक्ड या साझा कस्टम XML भागों को संभालें**

Office Open XML प्रस्तुति में एक ही कस्टम XML भाग कई प्रस्तुति ऑब्जेक्ट्स द्वारा संदर्भित किया जा सकता है। उदाहरण के तौर पर, एक मौजूदा फ़ाइल में कई स्लाइड या आकार एक ही अंतर्निहित कस्टम XML भाग से रिश्ते रख सकते हैं।

एक साझा भाग को कई संदर्भों वाला एक डेटा ऑब्जेक्ट माना जाना चाहिए:

- `setXmlAsString`, `setXmlData` या `setItemId` से अपडेट करने से अंतर्निहित कस्टम XML भाग बदलता है, इसलिए परिवर्तन सभी संदर्भों पर लागू होता है।
- `getItemId()` का उपयोग ऑब्जेक्ट‑स्तर संग्रहों को ऑडिट करते समय समान कस्टम XML भाग की पहचान करने में किया जा सकता है।
- किसी विशेष `getCustomXmlParts()` संग्रह से भाग हटाने से वह केवल उस संग्रह से हटता है। पूरी प्रस्तुति से भाग हटाने के लिए `ICustomXmlPart.remove()` उपयोग करें।
- साझा भाग को हटाने या बदलने से पहले ऑब्जेक्ट‑स्तर संग्रहों की जाँच करें कि क्या अन्य स्लाइड या आकार अभी भी उसका संदर्भ रख रहे हैं।

`add` ओवरलोड नए XML सामग्री से नया कस्टम XML भाग बनाते हैं; वे मौजूदा `ICustomXmlPart` को स्वीकार नहीं करते। इसलिए, साझा रिश्ते अक्सर उन प्रस्तुतियों को लोड करते समय मिलते हैं जिनमें ये पहले से मौजूद होते हैं।

निम्न उदाहरण `ItemId` द्वारा प्रस्तुति‑, स्लाइड‑ और आकार‑स्तर संग्रहों को ऑडिट करता है और उन भागों को दर्शाता है जो एक से अधिक स्थानों से संदर्भित हैं:

```java
import com.aspose.slides.*;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.UUID;
import java.util.function.BiConsumer;

Presentation presentation = new Presentation("presentation.pptx");
try {
    Map<UUID, List<String>> referencesByItemId = new HashMap<>();

    BiConsumer<String, ICustomXmlPartCollection> registerCustomXmlParts =
        (ownerName, customXmlParts) -> {
            for (int i = 0; i < customXmlParts.size(); i++) {
                ICustomXmlPart customXmlPart = customXmlParts.get_Item(i);
                UUID itemId = customXmlPart.getItemId();

                if (!referencesByItemId.containsKey(itemId)) {
                    referencesByItemId.put(itemId, new ArrayList<>());
                }

                referencesByItemId.get(itemId).add(ownerName);
            }
        };

    registerCustomXmlParts.accept("Presentation", presentation.getCustomData().getCustomXmlParts());

    for (int slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        ISlide slide = presentation.getSlides().get_Item(slideIndex);
        registerCustomXmlParts.accept("Slide " + (slideIndex + 1), slide.getCustomData().getCustomXmlParts());

        for (int shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            IShape shape = slide.getShapes().get_Item(shapeIndex);
            registerCustomXmlParts.accept("Slide " + (slideIndex + 1) + ", shape " + shapeIndex, shape.getCustomData().getCustomXmlParts());
        }
    }

    for (Map.Entry<UUID, List<String>> referenceEntry : referencesByItemId.entrySet()) {
        if (referenceEntry.getValue().size() > 1) {
            System.out.println("Shared custom XML part: " + referenceEntry.getKey());

            for (String ownerName : referenceEntry.getValue()) {
                System.out.println("  Referenced by: " + ownerName);
            }
        }
    }
} finally {
    presentation.dispose();
}
```

ऐसा ऑडिट उन प्रस्तुतियों में कस्टम XML डेटा को संशोधित या हटाने से पहले उपयोगी होता है, जो बाहरी सिस्टम द्वारा बनाई गई हैं, क्योंकि वही मेटाडेटा भाग कई रिश्तों में भाग ले सकता है।

## **टैग के मान प्राप्त करें**

स्लाइड्स में, एक टैग `IDocumentProperties.getKeywords()` मेथड के समान है। यह नमूना कोड दिखाता है कि Aspose.Slides for Java के साथ किसी [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation) से टैग मान कैसे प्राप्त करें:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    String keywords = presentation.getDocumentProperties().getKeywords();
} finally {
    presentation.dispose();
}
```

## **प्रस्तुतियों में टैग जोड़ें**

Aspose.Slides आपको प्रस्तुतियों में टैग जोड़ने देता है। एक टैग आमतौर पर दो आइटम से बनता है:

- एक कस्टम प्रॉपर्टी का नाम, उदाहरण के लिए `MyTag`;
- कस्टम प्रॉपर्टी का मान, उदाहरण के लिए `My Tag Value`।

यदि आपको प्रस्तुति को किसी विशिष्ट नियम या प्रॉपर्टी के आधार पर वर्गीकृत करना है, तो आप उसके लिए टैग जोड़ सकते हैं। उदाहरण के तौर पर, यदि आप उत्तर अमेरिकी देशों की प्रस्तुतियों को वर्गीकृत करना चाहते हैं, तो आप एक "North American" टैग बना सकते हैं और संबंधित देश को उसका मान असाइन कर सकते हैं।

यह नमूना कोड दिखाता है कि Aspose.Slides for Java का उपयोग करके किसी [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation) में टैग कैसे जोड़ें:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ITagCollection tags = presentation.getCustomData().getTags();
    tags.set_Item("MyTag", "My Tag Value");
} finally {
    presentation.dispose();
}
```

टैग को एक [Slide](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ISlide) के लिए भी सेट किया जा सकता है:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    slide.getCustomData().getTags().set_Item("tag", "value");
} finally {
    presentation.dispose();
}
```

या किसी व्यक्तिगत [Shape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IAutoShape) के लिए:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 50);
    shape.getTextFrame().setText("My text");
    shape.getCustomData().getTags().set_Item("tag", "value");
} finally {
    presentation.dispose();
}
```

### **सीमाएँ**

`getCustomData().getTags()` संग्रह के माध्यम से जोड़े गए टैग केवल PowerPoint फ़ाइल में संग्रहीत होते हैं। वे प्रस्तुति को PDF में निर्यात करने पर PDF टैग संरचना में **स्थानांतरित नहीं** होते। इसलिए, टैग के रूप में सौंपा गया कस्टम पहचानकर्ता टैग्ड PDF से पुनः प्राप्त नहीं किया जा सकता।

**वैकल्पिक समाधान**: आप कस्टम पहचानकर्ता को ऑब्जेक्ट के **Alt Text** में सहेज सकते हैं (उदाहरण के लिए, `shape.setAlternativeText("MyId")`)। PDF में निर्यात करने के बाद Alt Text PDF टैग संरचना में दिखाई दे सकता है।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं सभी टैग को एक ही ऑपरेशन में किसी प्रस्तुति, स्लाइड या आकार से हटा सकता हूँ?**

हां। `[`tagcollection`](https://reference.aspose.com/slides/hi/java/com.aspose.slides/tagcollection/)` एक `[`clear`](https://reference.aspose.com/slides/hi/java/com.aspose.slides/tagcollection/#clear--)` ऑपरेशन समर्थन करता है जो सभी कुंजी‑मूल्य जोड़े को एक साथ हटाता है।

**मैं संग्रह को पूरी तरह से इटरेट किए बिना किसी टैग को उसके नाम से कैसे हटाऊँ?**

`[`remove(name)`](https://reference.aspose.com/slides/hi/java/com.aspose.slides/tagcollection/#remove-java.lang.String-)` का उपयोग करके `[`tag collection`](https://reference.aspose.com/slides/hi/java/com.aspose.slides/tagcollection/)` से टैग को उसकी कुंजी द्वारा हटाएँ।

**विश्लेषण या फ़िल्टरिंग के लिए टैग नामों की पूरी सूची कैसे प्राप्त करूँ?**

`[`getNamesOfTags`](https://reference.aspose.com/slides/hi/java/com.aspose.slides/tagcollection/#getNamesOfTags--)` को `[`tag collection`](https://reference.aspose.com/slides/hi/java/com.aspose.slides/tagcollection/)` पर कॉल करें; यह सभी टैग नामों की एक एरे लौटाता है।

**मैं सभी कस्टम XML भागों को कैसे प्राप्त करूँ, चाहे वे कहीं भी संग्रहीत हों?**

`[`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation#getAllCustomXmlParts--)` का उपयोग करके प्रस्तुति में सभी कस्टम XML भाग प्राप्त करें।

**कस्टम XML भाग को अपडेट करने के लिए मुझे `getXmlAsString`/`setXmlAsString` या `getXmlData`/`setXmlData` में से कौन सा उपयोग करना चाहिए?**

जब एप्लिकेशन UTF‑8 XML टेक्स्ट के साथ काम करता है, तो `getXmlAsString` और `setXmlAsString` उपयोग करें। जब XML पहले से बाइट ऐरे के रूप में उपलब्ध हो या बाइनरी‑उन्मुख प्रोसेसिंग अधिक सुविधाजनक हो, तो `getXmlData` और `setXmlData` उपयोग करें। दोनों प्रतिनिधित्व एक ही कस्टम XML भाग की XML सामग्री को संदर्भित करते हैं।