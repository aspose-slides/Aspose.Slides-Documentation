---
title: Android पर प्रस्तुतियों में टैग और कस्टम डेटा का प्रबंधन
linktitle: टैग और कस्टम डेटा
type: docs
weight: 300
url: /hi/androidjava/managing-tags-and-custom-data
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
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java के साथ PowerPoint प्रस्तुतियों में टैग और कस्टम XML डेटा का प्रबंधन कैसे करें, जिसमें कस्टम XML भाग जोड़ना, पढ़ना, अपडेट करना, ऑडिट करना और हटाना शामिल है।"
---
## **अवलोकन**

यह लेख बताता है कि Aspose.Slides PowerPoint प्रस्तुतियों में टैग और कस्टम डेटा के साथ कैसे कार्य करता है। प्रस्तुति-विशिष्ट डेटा को टैग या कस्टम XML भागों के रूप में संग्रहीत किया जा सकता है। टैग साधारण कुंजी-मान स्ट्रिंग जोड़े होते हैं, जबकि कस्टम XML भाग संरचित मेटाडेटा और एप्लिकेशन-विशिष्ट XML पेलोड संग्रहीत कर सकते हैं।

Aspose.Slides APIs प्रदान करता है कस्टम XML भागों को जोड़ने, पढ़ने, अपडेट करने, ऑडिट करने और हटाने के लिए प्रस्तुति, स्लाइड और आकार स्तर पर। कस्टम XML भाग एकीकरणों के लिए उपयोगी हैं जहाँ दस्तावेज़-प्रबंधन पहचानकर्ता, वर्कफ़्लो स्थिति, अनुपालन मेटाडेटा, टेम्पलेट-बाइंडिंग डेटा, या अन्य संरचित एप्लिकेशन डेटा को प्रस्तुति में संग्रहीत किया जाता है।

## **प्रेज़ेंटेशन फ़ाइलों में डेटा संग्रहण**

PPTX फ़ाइलें—`.pptx` एक्सटेंशन वाली फ़ाइलें—PresentationML प्रारूप में संग्रहीत होती हैं, जो Office Open XML विनिर्देश का हिस्सा है। Office Open XML पैकेज संरचना और संबंधों को परिभाषित करता है जिससे प्रस्तुति सामग्री और संबंधित डेटा संग्रहीत होते हैं।

एक प्रस्तुति में कई भाग होते हैं जो संबंधों द्वारा जुड़े होते हैं। उदाहरण के लिए, एक स्लाइड भाग में एकल स्लाइड की सामग्री होती है और ISO/IEC 29500 द्वारा परिभाषित अन्य भागों के साथ स्पष्ट संबंध रख सकता है।

कस्टम डेटा को टैग ([ITagCollection](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ITagCollection)) या कस्टम XML भाग ([ICustomXmlPartCollection](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ICustomXmlPartCollection)) के रूप में संग्रहीत किया जा सकता है। दोनों उपलब्ध हैं [`ICustomData`](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ICustomData/) इंटरफ़ेस के माध्यम से।

{{% alert color="primary" %}}

टैग सरल स्ट्रिंग कुंजी-मान जोड़े संग्रहीत करते हैं। कस्टम XML भाग संरचित XML डेटा संग्रहीत करते हैं और प्रस्तुति, स्लाइड, या आकार के साथ सम्बद्ध किए जा सकते हैं।

{{% /alert %}}

## **कस्टम XML भागों के साथ काम करना**

[`ICustomData.getCustomXmlParts()`](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ICustomData#getCustomXmlParts--) मेथड किसी विशिष्ट प्रस्तुति ऑब्जेक्ट से जुड़े कस्टम XML भागों का संग्रह लौटाता है। उदाहरण के लिए:

- `presentation.getCustomData().getCustomXmlParts()` में प्रस्तुति स्वयं से जुड़े कस्टम XML भाग होते हैं।
- `slide.getCustomData().getCustomXmlParts()` में किसी विशिष्ट स्लाइड से जुड़े कस्टम XML भाग होते हैं।
- `shape.getCustomData().getCustomXmlParts()` में किसी विशिष्ट आकार से जुड़े कस्टम XML भाग होते हैं।

जब आपको प्रस्तुति में सभी कस्टम XML भागों की जाँच करनी हो, तो `Presentation.getAllCustomXmlParts()` का प्रयोग करें।

### **एक प्रस्तुति में कस्टम XML भाग जोड़ना**

[`ICustomXmlPartCollection.add`](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ICustomXmlPartCollection#add-java.lang.String-) का उपयोग करके XML डेटा को कस्टम XML भाग संग्रह में जोड़ा जा सकता है। XML मान्य और खाली नहीं होना चाहिए।

निम्नलिखित उदाहरण प्रस्तुति-स्तर के कस्टम डेटा संग्रह में संरचित मेटाडेटा जोड़ता है:

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

    // add स्वचालित रूप से एक पहचानकर्ता आवंटित करता है। केवल आवश्यक होने पर विशिष्ट UUID सेट करें।
    customXmlPart.setItemId(UUID.randomUUID());

    presentation.save("presentation_with_custom_xml.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`add` मेथड XML को बाइट एरे या इनपुट स्ट्रीम के रूप में भी स्वीकार कर सकता है, जो तब उपयोगी है जब XML सामग्री पहले से बाइनरी रूप में उपलब्ध हो।

### **स्लाइड या आकार में कस्टम XML भाग जोड़ना**

कस्टम XML डेटा को संपूर्ण प्रस्तुति के बजाय किसी विशिष्ट स्लाइड या आकार से जोड़ा जा सकता है। यह उपयोगी है जब मेटाडेटा केवल एक ऑब्जेक्ट का वर्णन करता है, जैसे टेम्पलेट कुंजी, बाहरी रिकॉर्ड पहचानकर्ता, या बाइंडिंग जानकारी।

निम्नलिखित उदाहरण एक स्लाइड में एक कस्टम XML भाग और एक आकार में दूसरा जोड़ता है:

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

जिस स्तर पर भाग जोड़ा जाता है, वह निर्धारित करता है कि किस ऑब्जेक्ट के `getCustomData().getCustomXmlParts()` संग्रह में उस भाग का संबंध शामिल होगा। प्रस्तुति-स्तर का डेटा दस्तावेज़-व्यापी मेटाडेटा के लिए उपयुक्त है, स्लाइड-स्तर का डेटा विशिष्ट स्लाइड की जानकारी के लिए, और आकार-स्तर का डेटा व्यक्तिगत आकार से जुड़े मेटाडेटा के लिए।

### **सभी कस्टम XML भागों की सूची बनाना और ऑडिट करना**

`Presentation.getAllCustomXmlParts()` का उपयोग करके प्रस्तुति से सभी कस्टम XML भाग प्राप्त किए जा सकते हैं। प्रत्येक [`ICustomXmlPart`](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ICustomXmlPart/) अपना पहचानकर्ता, XML सामग्री, और जुड़े नेमस्पेस स्कीमा प्रदान करता है।

निम्नलिखित उदाहरण सभी कस्टम XML भागों और उनके नेमस्पेस स्कीमा की सूची बनाता है:

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

[`ICustomXmlPart.getNamespaceSchemas()`](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ICustomXmlPart#getNamespaceSchemas--) कस्टम XML भाग से जुड़े XML स्कीमा लौटाता है। यह जानकारी उन प्रस्तुतियों के ऑडिट में उपयोगी हो सकती है जो बाहरी सिस्टम द्वारा उत्पन्न XML रखती हैं।

### **XML सामग्री और ItemId पढ़ना व अपडेट करना**

[`ICustomXmlPart.getXmlAsString()`](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ICustomXmlPart#getXmlAsString--) और [`setXmlAsString()`](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ICustomXmlPart#setXmlAsString-java.lang.String-) का उपयोग करके XML को UTF-8 स्ट्रिंग के रूप में काम किया जा सकता है, अथवा [`getXmlData()`](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ICustomXmlPart#getXmlData--) और [`setXmlData()`](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ICustomXmlPart#setXmlData-byte:A-) का उपयोग करके कच्चे XML बाइट्स के साथ काम किया जा सकता है।

[`ICustomXmlPart.getItemId()`](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ICustomXmlPart#getItemId--) मेथड वह UUID लौटाता है जो Office Open XML दस्तावेज़ में कस्टम XML भाग को पहचानता है। जब एकीकरण को नया पहचानकर्ता चाहिए, तब [`setItemId()`](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ICustomXmlPart#setItemId-java.util.UUID-) का उपयोग करें।

निम्नलिखित उदाहरण XML सामग्री और पहचानकर्ता को अपडेट करता है:

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

    // getXmlData समान XML सामग्री को कच्चे बाइट्स के रूप में प्रदान करता है।
    byte[] customXmlData = customXmlPart.getXmlData();
    System.out.println(new String(customXmlData, StandardCharsets.UTF_8));

    // एकीकरण द्वारा आवश्यक होने पर पहचानकर्ता बदलें।
    customXmlPart.setItemId(UUID.randomUUID());

    presentation.save("updated_custom_xml.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`setXmlAsString` या `setXmlData` को कॉल करते समय मान्य, खाली न होने वाला XML प्रदान करें। एप्लीकेशन की प्राथमिकता के अनुसार स्ट्रिंग या बाइट प्रतिनिधित्व में से एक चुनें।

### **कस्टम XML भाग हटाना**

Aspose.Slides कस्टम XML डेटा को हटाने के विभिन्न तरीके प्रदान करता है:

- [`ICustomXmlPart.remove`](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ICustomXmlPart#remove--) कस्टम XML भाग को प्रस्तुति से हटाता है।
- [`ICustomXmlPartCollection.remove`](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ICustomXmlPartCollection#remove-com.aspose.slides.ICustomXmlPart-) कस्टम XML भाग संग्रह से एक विशिष्ट भाग हटाता है।
- [`ICustomXmlPartCollection.removeAt`](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ICustomXmlPartCollection#removeAt-int--) निर्दिष्ट संग्रह इंडेक्स पर भाग हटाता है।
- [`ICustomXmlPartCollection.clear`](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ICustomXmlPartCollection#clear--) किसी विशिष्ट संग्रह से सभी भाग हटाता है।

निम्नलिखित उदाहरण एक प्रस्तुति-स्तर के कस्टम XML भाग को संदर्भ द्वारा हटाता है:

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

यदि आपके पास पहले से `ICustomXmlPart` है और आप उसे प्रस्तुति से हटाना चाहते हैं, तो `customXmlPart.remove()` को कॉल करें।

आप इंडेक्स द्वारा भी आइटम हटा सकते हैं:

```java
presentation.getCustomData().getCustomXmlParts().removeAt(0);
```

### **कलेक्शन से सभी कस्टम XML भाग साफ़ करना**

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

`clear` केवल चयनित संग्रह को प्रभावित करता है। उदाहरण के लिए, स्लाइड के संग्रह को साफ़ करने से प्रस्तुति-स्तर या आकार-स्तर के संग्रह साफ़ नहीं होते।

प्रेज़ेंटेशन में सभी कस्टम XML भाग हटाने के लिए, `getAllCustomXmlParts()` पर इटररेट करें और प्रत्येक भाग को हटाएं:

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

Office Open XML प्रस्तुति में एक ही कस्टम XML भाग कई प्रस्तुति ऑब्जेक्ट्स से संदर्भित हो सकता है। उदाहरण के लिए, एक मौजूदा फ़ाइल में कई स्लाइड या आकार से समान कस्टम XML भाग के संबंध हो सकते हैं।

एक साझा भाग को कई संदर्भों वाला एक डेटा ऑब्जेक्ट माना जाना चाहिए:

- `setXmlAsString`, `setXmlData`, या `setItemId` से अपडेट करने से मूल कस्टम XML भाग बदलता है, इसलिए परिवर्तन सभी संदर्भों पर लागू होता है।
- `getItemId()` का उपयोग करके ऑडिट के दौरान समान कस्टम XML भाग को पहचाना जा सकता है।
- किसी विशिष्ट `getCustomXmlParts()` संग्रह से भाग हटाने से वह संग्रह से हटता है। यदि भाग स्वयं को प्रस्तुति से हटाना हो, तो `ICustomXmlPart.remove()` का उपयोग करें।
- साझा भाग को हटाने या बदलने से पहले ऑब्जेक्ट-स्तर के संग्रहों की जाँच करें कि क्या अन्य स्लाइड या आकार अभी भी उसका संदर्भ रख रहे हैं।

`add` ओवरलोड नई XML सामग्री से नया कस्टम XML भाग बनाते हैं; वे मौजूदा `ICustomXmlPart` को स्वीकार नहीं करते। इसलिए, साझा संबंध आमतौर पर उन प्रस्तुतियों को लोड करते समय मिलते हैं जिनमें वह पहले से मौजूद होते हैं।

निम्नलिखित उदाहरण `ItemId` द्वारा प्रस्तुति-, स्लाइड- और आकार-स्तर के संग्रहों को ऑडिट करता है और उन भागों की रिपोर्ट करता है जो एक से अधिक स्थान से संदर्भित होते हैं:

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

यह प्रकार का ऑडिट बाहरी सिस्टम द्वारा निर्मित प्रस्तुतियों में कस्टम XML डेटा को संशोधित या हटाने से पहले उपयोगी है, क्योंकि समान मेटाडेटा भाग कई संबंधों में भाग ले सकता है।

## **टैग के मान प्राप्त करना**

स्लाइड्स में, टैग `IDocumentProperties.getKeywords()` मेथड के अनुरूप होता है। यह नमूना कोड दिखाता है कि Aspose.Slides for Android via Java में [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation) के लिए टैग मान कैसे प्राप्त किया जाए:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    String keywords = presentation.getDocumentProperties().getKeywords();
} finally {
    presentation.dispose();
}
```

## **प्रेज़ेंटेशन्स में टैग जोड़ना**

Aspose.Slides आपको प्रस्तुतियों में टैग जोड़ने की अनुमति देता है। एक टैग आमतौर पर दो वस्तुओं से बना होता है:

- कस्टम प्रॉपर्टी का नाम, उदाहरण के लिए `MyTag`;
- कस्टम प्रॉपर्टी का मान, उदाहरण के लिए `My Tag Value`।

यदि आपको किसी विशेष नियम या प्रॉपर्टी के आधार पर प्रस्तुतियों को वर्गीकृत करना है, तो आप इसके लिए टैग जोड़ सकते हैं। उदाहरण के लिए, यदि आप उत्तर अमेरिकी देशों की प्रस्तुतियों को वर्गीकृत करना चाहते हैं, तो आप एक "North American" टैग बना सकते हैं और उसके मान के रूप में संबंधित देश निर्दिष्ट कर सकते हैं।

यह नमूना कोड Aspose.Slides for Android via Java का उपयोग करके एक [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation) में टैग जोड़ता है:

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

या व्यक्तिगत [Shape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IAutoShape) के लिए:

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

`getCustomData().getTags()` संग्रह के माध्यम से जोड़े गए टैग केवल PowerPoint फ़ाइल में संग्रहीत होते हैं। वे PDF टैग संरचना में नहीं पहुँचते जब प्रस्तुति को PDF में निर्यात किया जाता है। परिणामस्वरूप, टैग के रूप में असाइन किया गया कस्टम पहचानकर्ता टैग्ड PDF से प्राप्त नहीं किया जा सकता।

**वर्कअराउंड**: आप कस्टम पहचानकर्ता को ऑब्जेक्ट के **Alt Text** में संग्रहीत कर सकते हैं (उदाहरण के लिए, `shape.setAlternativeText("MyId")`)। PDF में निर्यात करने के बाद, Alt Text PDF टैग संरचना में दिखाई दे सकता है।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं एक ऑपरेशन में सभी टैग को एक प्रस्तुति, स्लाइड या आकार से हटा सकता हूँ?**

हां। टैग संग्रह ([tag collection](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/tagcollection/)) एक `clear` ऑपरेशन ([clear](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/tagcollection/#clear--)) समर्थन करता है जो सभी कुंजी-मान जोड़ों को एक साथ हटाता है।

**सभी टैग को इटेरेट किए बिना उसके नाम से कैसे हटाऊँ?**

`remove(name)` मेथड ([remove(name)](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/tagcollection/#remove-java.lang.String-)) का उपयोग करके टैग संग्रह ([tag collection](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/tagcollection/)) में कुंजी द्वारा टैग हटाएँ।

**विचाराधीन या फ़िल्टरिंग के लिए सभी टैग नामों की पूरी सूची कैसे प्राप्त करूँ?**

`getNamesOfTags` मेथड ([getNamesOfTags](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/tagcollection/#getNamesOfTags--)) का उपयोग करके टैग संग्रह से सभी टैग नामों की सरणी प्राप्त करें।

**सभी कस्टम XML भाग कैसे प्राप्त करूँ चाहे वे कहीं भी संग्रहीत हों?**

`Presentation.getAllCustomXmlParts()` मेथड का उपयोग करके प्रस्तुति में सभी कस्टम XML भाग प्राप्त करें।

**क्या मुझे `getXmlAsString`/`setXmlAsString` या `getXmlData`/`setXmlData` का उपयोग करके कस्टम XML भाग को अपडेट करना चाहिए?**

जब एप्लिकेशन UTF-8 XML टेक्स्ट के साथ काम करता है तो `getXmlAsString` और `setXmlAsString` का उपयोग करें। जब XML पहले से बाइट एरे के रूप में उपलब्ध हो या बाइनरी-उन्मुख प्रोसेसिंग अधिक सुविधाजनक हो, तो `getXmlData` और `setXmlData` का उपयोग करें। दोनों प्रतिनिधित्व एक ही कस्टम XML भाग की XML सामग्री को दर्शाते हैं।