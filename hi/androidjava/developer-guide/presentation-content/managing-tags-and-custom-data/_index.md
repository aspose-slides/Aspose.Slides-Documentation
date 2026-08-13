---
title: "एंड्रॉइड पर प्रस्तुतियों में टैग और कस्टम डेटा का प्रबंधन"
linktitle: "टैग और कस्टम डेटा"
type: docs
weight: 300
url: /hi/androidjava/managing-tags-and-custom-data
keywords:
  - "दस्तावेज़ गुण"
  - "टैग"
  - "कस्टम डेटा"
  - "कस्टम XML"
  - "कस्टम XML भाग"
  - "XML मेटाडेटा"
  - "ItemId"
  - "टैग जोड़ें"
  - "युग्म मान"
  - "PowerPoint"
  - "प्रेज़ेंटेशन"
  - "Android"
  - "Java"
  - "Aspose.Slides"
description: "Aspose.Slides for Android via Java का उपयोग करके PowerPoint प्रस्तुतियों में टैग और कस्टम XML डेटा को प्रबंधित करना सीखें, जिसमें टैग जोड़ना, पढ़ना, अपडेट करना, ऑडिट करना और कस्टम XML भाग हटाना शामिल है।"
---
## **अवलोकन**

यह लेख बताता है कि Aspose.Slides PowerPoint प्रस्तुतियों में टैग और कस्टम डेटा के साथ कैसे काम करता है। प्रस्तुति‑विशिष्ट डेटा को टैग या कस्टम XML भागों के रूप में संग्रहीत किया जा सकता है। टैग सरल कुंजी‑मान स्ट्रिंग युग्म होते हैं, जबकि कस्टम XML भाग संरचित मेटाडेटा और एप्लिकेशन‑विशिष्ट XML पेलोड संग्रहीत कर सकते हैं।

Aspose.Slides प्रस्तुति, स्लाइड और आकार स्तर पर कस्टम XML भागों को जोड़ने, पढ़ने, अपडेट करने, ऑडिट करने और हटाने के लिए API प्रदान करता है। कस्टम XML भाग उन एकीकरणों के लिए उपयोगी होते हैं जो दस्तावेज‑प्रबंधन पहचानकर्ता, वर्कफ़्लो स्थिति, अनुपालन मेटाडेटा, टेम्पलेट‑बाइंडिंग डेटा, या प्रस्तुति के भीतर अन्य संरचित एप्लिकेशन डेटा संग्रहीत करना चाहते हैं।

## **प्रेज़ेंटेशन फ़ाइलों में डेटा संग्रहण**

PPTX फ़ाइलें — `.pptx` एक्सटेंशन वाली फ़ाइलें — PresentationML प्रारूप में संग्रहीत होती हैं, जो Office Open XML विशिष्टता का हिस्सा है। Office Open XML पैकेज संरचना और संबंधों को परिभाषित करता है जो प्रस्तुति सामग्री और संबंधित डेटा को संग्रहीत करने के लिए उपयोग होते हैं।

एक प्रेज़ेंटेशन में कई भाग होते हैं जो संबंधों द्वारा जुड़े होते हैं। उदाहरण के लिए, एक स्लाइड भाग एकल स्लाइड की सामग्री रखता है और ISO/IEC 29500 द्वारा परिभाषित अन्य भागों के साथ स्पष्ट संबंध रख सकता है।

कस्टम डेटा को टैग ([ITagCollection](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ITagCollection)) या कस्टम XML भाग ([ICustomXmlPartCollection](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ICustomXmlPartCollection)) के रूप में संग्रहीत किया जा सकता है। दोनों ही [`ICustomData`](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ICustomData/) इंटरफ़ेस के माध्यम से उपलब्ध हैं।

{{% alert color="info" %}}
टैग सरल स्ट्रिंग कुंजी‑मान युग्म संग्रहीत करते हैं। कस्टम XML भाग संरचित XML डेटा संग्रहीत करते हैं और उन्हें प्रेज़ेंटेशन, स्लाइड या आकार से जोड़ा जा सकता है।
{{% /alert %}}

## **कस्टम XML भागों के साथ काम करना**

[`ICustomData.getCustomXmlParts()`](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ICustomData#getCustomXmlParts--) मेथड एक विशिष्ट प्रेज़ेंटेशन ऑब्जेक्ट से जुड़े कस्टम XML भागों का संग्रह लौटाता है। उदाहरण के लिए:

- `presentation.getCustomData().getCustomXmlParts()` में प्रस्तुति के स्वयं से जुड़े कस्टम XML भाग होते हैं।
- `slide.getCustomData().getCustomXmlParts()` में किसी विशिष्ट स्लाइड से जुड़े कस्टम XML भाग होते हैं।
- `shape.getCustomData().getCustomXmlParts()` में किसी विशिष्ट आकार से जुड़े कस्टम XML भाग होते हैं।

जब आप प्रस्तुति में सभी कस्टम XML भागों को देखना चाहते हैं, चाहे वे कहीं भी जुड़े हों, तो [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation#getAllCustomXmlParts--) का उपयोग करें।

### **प्रेज़ेंटेशन में कस्टम XML भाग जोड़ना**

[`ICustomXmlPartCollection.add`](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ICustomXmlPartCollection#add-java.lang.String-) का उपयोग करके XML डेटा को कस्टम XML भाग संग्रह में जोड़ा जा सकता है। XML मान्य और गैर‑खाली होना चाहिए।

निम्न उदाहरण प्रेज़ेंटेशन‑स्तर के कस्टम डेटा संग्रह में संरचित मेटाडेटा जोड़ता है:

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

    // add स्वतः एक पहचानकर्ता असाइन करता है। केवल आवश्यकता होने पर एक विशिष्ट UUID सेट करें।
    customXmlPart.setItemId(UUID.randomUUID());

    presentation.save("presentation_with_custom_xml.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`add` मेथड XML को बाइट ऐरे या इनपुट स्ट्रीम के रूप में भी स्वीकार कर सकता है, जो तब उपयोगी होता है जब XML सामग्री पहले से बायनरी रूप में उपलब्ध हो।

### **स्लाइड या आकार में कस्टम XML भाग जोड़ना**

कस्टम XML डेटा को पूरे प्रेज़ेंटेशन की बजाय किसी विशिष्ट स्लाइड या आकार से जोड़ा जा सकता है। यह तब उपयोगी होता है जब मेटाडेटा केवल एक ऑब्जेक्ट का वर्णन करता है, जैसे टेम्पलेट कुंजी, बाहरी रिकॉर्ड पहचानकर्ता, या बाइंडिंग जानकारी।

निम्न उदाहरण एक कस्टम XML भाग को स्लाइड में और दूसरे को आकार में जोड़ता है:

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

जिस स्तर पर भाग जोड़ा जाता है, वह निर्धारित करता है कि किस ऑब्जेक्ट के `getCustomData().getCustomXmlParts()` संग्रह में उस भाग का संबंध रहता है। प्रेज़ेंटेशन‑स्तर का डेटा दस्तावेज‑व्यापी मेटाडेटा के लिए उपयुक्त है, स्लाइड‑स्तर का डेटा विशेष स्लाइड की जानकारी के लिए, और आकार‑स्तर का डेटा व्यक्तिगत आकार से जुड़े मेटाडेटा के लिए।

### **सभी कस्टम XML भागों की सूची बनाना और ऑडिट करना**

[`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation#getAllCustomXmlParts--) का उपयोग करके प्रेज़ेंटेशन से सभी कस्टम XML भाग प्राप्त किए जा सकते हैं। प्रत्येक [`ICustomXmlPart`](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ICustomXmlPart/) अपना पहचानकर्ता, XML सामग्री और संबंधित namespace स्कीमा प्रदान करता है।

निम्न उदाहरण सभी कस्टम XML भागों और उनके namespace स्कीमा की सूची बनाता है:

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

[`ICustomXmlPart.getNamespaceSchemas()`](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ICustomXmlPart#getNamespaceSchemas--) कस्टम XML भाग से जुड़े XML स्कीमा लौटाता है। यह जानकारी उन प्रस्तुतियों के ऑडिट करने में उपयोगी हो सकती है जिनमें बाहरी सिस्टम द्वारा उत्पन्न XML शामिल है।

### **XML सामग्री और ItemId पढ़ना एवं अपडेट करना**

XML को UTF‑8 स्ट्रिंग के रूप में संभालने के लिए [`ICustomXmlPart.getXmlAsString()`](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ICustomXmlPart#getXmlAsString--) और [`setXmlAsString()`](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ICustomXmlPart#setXmlAsString-java.lang.String-) का उपयोग करें, या कच्चे XML बाइट्स के लिए [`getXmlData()`](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ICustomXmlPart#getXmlData--) और [`setXmlData()`](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ICustomXmlPart#setXmlData-byte:A-) का उपयोग करें।

[`ICustomXmlPart.getItemId()`](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ICustomXmlPart#getItemId--) मेथड वह UUID लौटाता है जो Office Open XML दस्तावेज़ में कस्टम XML भाग की पहचान करता है। जब एकीकरण को नया पहचानकर्ता चाहिए तो [`setItemId()`](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ICustomXmlPart#setItemId-java.util.UUID-) का प्रयोग करें।

निम्न उदाहरण XML सामग्री और पहचानकर्ता को अपडेट करता है:

```java
import com.aspose.slides.*;
import java.nio.charset.StandardCharsets;
import java.util.UUID;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ICustomXmlPart customXmlPart = presentation.getAllCustomXmlParts()[0];

    // वर्तमान XML को पाठ के रूप में पढ़ें।
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

    // इंटीग्रेशन द्वारा आवश्यक होने पर पहचानकर्ता को बदलें।
    customXmlPart.setItemId(UUID.randomUUID());

    presentation.save("updated_custom_xml.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`setXmlAsString` या `setXmlData` कॉल करते समय मान्य, गैर‑खाली XML प्रदान करें। उपयोग के आधार पर स्ट्रिंग या बाइट प्रतिनिधित्व में से एक का चयन करें।

### **कस्टम XML भाग हटाना**

Aspose.Slides कस्टम XML डेटा हटाने के कई तरीके प्रदान करता है:

- [`ICustomXmlPart.remove`](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ICustomXmlPart#remove--) कस्टम XML भाग को प्रेज़ेंटेशन से हटाता है।
- [`ICustomXmlPartCollection.remove`](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ICustomXmlPartCollection#remove-com.aspose.slides.ICustomXmlPart-) संग्रह से एक विशिष्ट भाग हटाता है।
- [`ICustomXmlPartCollection.removeAt`](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ICustomXmlPartCollection#removeAt-int--) निर्दिष्ट संग्रह इंडेक्स पर स्थित भाग हटाता है।
- [`ICustomXmlPartCollection.clear`](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ICustomXmlPartCollection#clear--) किसी विशिष्ट संग्रह के सभी भागों को हटा देता है।

निम्न उदाहरण संदर्भ द्वारा एक प्रेज़ेंटेशन‑स्तर का कस्टम XML भाग हटाता है:

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

यदि आपके पास पहले से एक `ICustomXmlPart` है और आप उसे प्रेज़ेंटेशन से हटाना चाहते हैं न कि किसी विशेष संग्रह से, तो `customXmlPart.remove()` कॉल करें।

आप इंडेक्स द्वारा भी कोई आइटम हटाए सकते हैं:

```java
presentation.getCustomData().getCustomXmlParts().removeAt(0);
```

### **संग्रह से सभी कस्टम XML भाग साफ़ करना**

जब किसी विशेष प्रेज़ेंटेशन ऑब्जेक्ट से जुड़े सभी कस्टम XML भाग हटाने हों, तो `clear` का उपयोग करें।

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

`clear` केवल चयनित संग्रह को प्रभावित करता है। उदाहरण के लिए, स्लाइड के संग्रह को साफ़ करना प्रेज़ेंटेशन‑स्तर या आकार‑स्तर के संग्रह को नहीं साफ़ करता।

प्रेज़ेंटेशन में सभी कस्टम XML भाग हटाने के लिए `getAllCustomXmlParts()` पर इटररेट करें और प्रत्येक भाग को हटाएँ:

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

### **लिंक्ड या साझा कस्टम XML भागों को संभालना**

Office Open XML प्रस्तुति में एक ही कस्टम XML भाग कई प्रेज़ेंटेशन ऑब्जेक्ट्स से संदर्भित हो सकता है। उदाहरण के लिए, एक मौजूदा फ़ाइल में कई स्लाइड या आकारों के बीच एक ही मूल कस्टम XML भाग के संबंध हो सकते हैं।

एक साझा भाग को कई संदर्भ वाले एक डेटा ऑब्जेक्ट के रूप में माना जाना चाहिए:

- `setXmlAsString`, `setXmlData` या `setItemId` से उसे अपडेट करने पर मूल कस्टम XML भाग बदलता है, इसलिए परिवर्तन सभी स्थानों पर लागू हो जाता है जहाँ वह भाग उपयोग हो रहा है।
- `getItemId()` का उपयोग कर के आप ऑडिट के दौरान समान कस्टम XML भाग की पहचान कर सकते हैं।
- किसी विशिष्ट `getCustomXmlParts()` संग्रह से भाग हटाने पर वह केवल उस संग्रह से हटता है। यदि भाग स्वयं को पूरी प्रस्तुति से हटाना हो तो `ICustomXmlPart.remove()` प्रयोग करें।
- साझा भाग को हटाने या बदलने से पहले ऑब्जेक्ट‑स्तर के संग्रहों की जाँच करें ताकि पता चल सके कि अन्य स्लाइड या आकार अभी भी उसका संदर्भ दे रहे हैं।

`add` ओवरलोड्स XML सामग्री से नया कस्टम XML भाग बनाते हैं; वे मौजूदा `ICustomXmlPart` को स्वीकार नहीं करते। इसलिए साझा संबंध मुख्यतः उन प्रस्तुतियों में मिलते हैं जो पहले से इन्हें शामिल करती हैं।

निम्न उदाहरण `ItemId` द्वारा प्रेज़ेंटेशन‑, स्लाइड‑ और आकार‑स्तर के संग्रहों को ऑडिट करता है और उन भागों को रिपोर्ट करता है जो एक से अधिक स्थानों से संदर्भित हैं:

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

ऐसी ऑडिट उन प्रस्तुतियों में कस्टम XML डेटा को संशोधित या हटाने से पहले उपयोगी होती है, जो बाहरी सिस्टम द्वारा निर्मित हैं, क्योंकि समान मेटाडेटा भाग कई संबंधों में भाग ले सकता है।

## **टैग के मान प्राप्त करना**

स्लाइड्स में टैग `IDocumentProperties.getKeywords()` मेथड के समान होता है। यह उदाहरण कोड दिखाता है कि कैसे Aspose.Slides for Android via Java का उपयोग करके [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation) से टैग मान प्राप्त किया जाए:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    String keywords = presentation.getDocumentProperties().getKeywords();
} finally {
    presentation.dispose();
}
```

## **प्रेज़ेंटेशन में टैग जोड़ना**

Aspose.Slides आपको प्रस्तुतियों में टैग जोड़ने की अनुमति देता है। एक टैग सामान्यतः दो वस्तुओं से बना होता है:

- कस्टम प्रॉपर्टी का नाम, उदाहरण के लिए `MyTag`;
- कस्टम प्रॉपर्टी का मान, उदाहरण के लिए `My Tag Value`।

यदि आप किसी विशिष्ट नियम या प्रॉपर्टी के आधार पर प्रस्तुतियों को वर्गीकृत करना चाहते हैं, तो आप उसके लिये टैग जोड़ सकते हैं। उदाहरण के लिए, यदि आप उत्तर अमेरिकी देशों की प्रस्तुतियों को वर्गीकृत करना चाहते हैं, तो आप एक "North American" टैग बना सकते हैं और संबंधित देश को उसके मान के रूप में असाइन कर सकते हैं।

यह उदाहरण कोड दिखाता है कि कैसे Aspose.Slides for Android via Java का उपयोग करके एक [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation) में टैग जोड़ा जाए:

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

टैग को एक [Slide](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ISlide) के लिए भी सेट किया जा सकता है:

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

या एक व्यक्तिगत [Shape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IAutoShape) के लिए:

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

`getCustomData().getTags()` संग्रह के माध्यम से जोड़े गए टैग केवल PowerPoint फ़ाइल में संग्रहीत होते हैं। वे प्रस्तुति को PDF में निर्यात करने पर PDF टैग संरचना में **स्थानांतरित नहीं** होते। इसलिए, टैग के रूप में असाइन किया गया कस्टम पहचानकर्ता टैग्ड PDF से प्राप्त नहीं किया जा सकता।

**वर्कअराउंड**: आप कस्टम पहचानकर्ता को ऑब्जेक्ट के **Alt Text** (उदाहरण के लिए, `shape.setAlternativeText("MyId")`) में संग्रहीत कर सकते हैं। PDF में निर्यात करने के बाद Alt Text PDF टैग संरचना में दिखाई दे सकता है।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं एक ही ऑपरेशन में प्रेज़ेंटेशन, स्लाइड या आकार से सभी टैग हटा सकता हूँ?**

हाँ। [tag collection](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/tagcollection/) में एक [clear](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/tagcollection/#clear--) ऑपरेशन समर्थन शामिल है जो सभी कुंजी‑मान युग्मों को एक साथ हटा देता है।

**मैं सम्पूर्ण संग्रह को इटररेट किए बिना नाम द्वारा एकल टैग कैसे हटाऊँ?**

[tag collection](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/tagcollection/) पर `remove(name)` (उदाहरण: `remove("MyTag")`) का उपयोग करके टैग को उसकी कुंजी द्वारा हटाएँ।

**ऐनालिटिक्स या फ़िल्टरिंग के लिए टैग नामों की पूरी सूची मैं कैसे प्राप्त करूँ?**

[tag collection](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/tagcollection/) पर `getNamesOfTags` का उपयोग करें; यह सभी टैग नामों का एक ऐरे लौटाता है।

**मैं सभी कस्टम XML भागों को कैसे खोजूँ चाहे वे कहीं भी संग्रहीत हों?**

[`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation#getAllCustomXmlParts--) का उपयोग करके प्रस्तुति में सभी कस्टम XML भाग प्राप्त करें।

**कस्टम XML भाग को अपडेट करने के लिए मुझे `getXmlAsString`/`setXmlAsString` या `getXmlData`/`setXmlData` में से कौन सा उपयोग करना चाहिए?**

जब एप्लिकेशन UTF‑8 XML टेक्स्ट के साथ काम करता है तो `getXmlAsString` और `setXmlAsString` उपयोग करें। जब XML पहले से बाइट ऐरे के रूप में उपलब्ध है या बाइनरी‑उन्मुख प्रोसेसिंग अधिक सुविधाजनक है तो `getXmlData` और `setXmlData` उपयोग करें। दोनों प्रतिनिधित्व समान कस्टम XML भाग की XML सामग्री को दर्शाते हैं।