---
title: जावा का उपयोग करके प्रस्तुतियों में टैग और कस्टम डेटा का प्रबंधन
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
- आइटम Id
- टैग जोड़ें
- जोड़ी मान
- PowerPoint
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java के साथ PowerPoint प्रस्तुतियों में टैग और कस्टम XML डेटा का प्रबंधन कैसे करें, जिसमें टैग जोड़ना, पढ़ना, अपडेट करना, ऑडिट करना और कस्टम XML भागों को हटाना शामिल है।"
---
## **परिचय**

यह लेख समझाता है कि Aspose.Slides टैग्स और कस्टम डेटा के साथ PowerPoint प्रस्तुतियों में कैसे काम करता है। प्रस्तुति-विशिष्ट डेटा को टैग्स या कस्टम XML भागों के रूप में संग्रहीत किया जा सकता है। टैग्स सरल कुंजी-मूल्य स्ट्रिंग जोड़े होते हैं, जबकि कस्टम XML भाग संरचित मेटाडेटा और एप्लिकेशन-विशिष्ट XML पेलोड्स संग्रहीत कर सकते हैं।

Aspose.Slides APIs प्रदान करता है टैग जोड़ने, पढ़ने, अपडेट करने, ऑडिट करने और कस्टम XML भागों को प्रस्तुति, स्लाइड, और आकार स्तर पर हटाने के लिए। कस्टम XML भाग उन इंटीग्रेशन के लिए उपयोगी हैं जो दस्तावेज़-प्रबंधन पहचानकर्ताओं, कार्यप्रवाह स्थिति, अनुपालन मेटाडेटा, टेम्प्लेट-बाइंडिंग डेटा, या प्रस्तुति के भीतर अन्य संरचित एप्लिकेशन डेटा जैसी जानकारी संग्रहीत करते हैं।

## **प्रस्तुति फ़ाइलों में डेटा संग्रह**

PPTX फ़ाइलें—जिनका एक्सटेंशन `.pptx` है—PresentationML फ़ॉर्मेट में संग्रहीत होती हैं, जो Office Open XML विशिष्टता का हिस्सा है। Office Open XML पैकेज संरचना और संबंधों को परिभाषित करता है जो प्रस्तुति सामग्री और संबंधित डेटा को संग्रहीत करने के लिए उपयोग होते हैं।

एक प्रस्तुति कई भागों को संबंधों द्वारा जोड़ती है। उदाहरण के लिए, एक स्लाइड भाग में एकल स्लाइड की सामग्री होती है और इसमें ISO/IEC 29500 द्वारा परिभाषित अन्य भागों के साथ स्पष्ट संबंध हो सकते हैं।

कस्टम डेटा को टैग्स के रूप में ([ITagCollection](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ITagCollection)) या कस्टम XML भागों के रूप में ([ICustomXmlPartCollection](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ICustomXmlPartCollection)) संग्रहीत किया जा सकता है। दोनों [`ICustomData`](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ICustomData/) इंटरफ़ेस के माध्यम से उपलब्ध हैं।

{{% alert color="primary" %}}
टैग्स सरल स्ट्रिंग कुंजी-मूल्य जोड़े संग्रहीत करते हैं। कस्टम XML भाग संरचित XML डेटा संग्रहीत करते हैं और उन्हें प्रस्तुति, स्लाइड, या आकार से जोड़ा जा सकता है।
{{% /alert %}}

## **कस्टम XML भागों के साथ कार्य करना**

`[`ICustomData.getCustomXmlParts()`](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ICustomData#getCustomXmlParts--)` मेथड किसी विशिष्ट प्रस्तुति वस्तु से जुड़े कस्टम XML भागों का संग्रह लौटाता है। उदाहरण के लिए:

- `presentation.getCustomData().getCustomXmlParts()` प्रस्तुति स्वयं से जुड़े कस्टम XML भागों को शामिल करता है।
- `slide.getCustomData().getCustomXmlParts()` एक विशिष्ट स्लाइड से जुड़े कस्टम XML भागों को शामिल करता है।
- `shape.getCustomData().getCustomXmlParts()` एक विशिष्ट आकार से जुड़े कस्टम XML भागों को शामिल करता है।

जब आपको प्रस्तुति में सभी कस्टम XML भागों को देखना हो, चाहे वे कहीं भी जुड़े हों, तब [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation#getAllCustomXmlParts--) का उपयोग करें।

### **प्रस्तुति में एक कस्टम XML भाग जोड़ें**

`[`ICustomXmlPartCollection.add`](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ICustomXmlPartCollection#add-java.lang.String-)` का उपयोग करके XML डेटा को कस्टम XML भाग संग्रह में जोड़ें। XML मान्य और खाली नहीं होना चाहिए।

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

    // add स्वचालित रूप से एक पहचानकर्ता निर्धारित करता है। केवल आवश्यकता होने पर विशिष्ट UUID सेट करें।
    customXmlPart.setItemId(UUID.randomUUID());

    presentation.save("presentation_with_custom_xml.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`add` मेथड XML को बाइट एरे या इनपुट स्ट्रीम के रूप में भी स्वीकार कर सकता है, जो तब उपयोगी होता है जब XML सामग्री बाइनरी रूप में पहले से उपलब्ध हो।

### **स्लाइड या आकार में एक कस्टम XML भाग जोड़ें**

कस्टम XML डेटा को पूरी प्रस्तुति के बजाय एक विशिष्ट स्लाइड या आकार से जोड़ा जा सकता है। यह तब उपयोगी होता है जब मेटाडेटा केवल एक वस्तु के बारे में वर्णन करता है, जैसे टेम्प्लेट कुंजी, बाहरी रिकॉर्ड पहचानकर्ता, या बाइंडिंग जानकारी।

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

जिस स्तर पर भाग जोड़ा जाता है, वह निर्धारित करता है कि किस वस्तु के `getCustomData().getCustomXmlParts()` संग्रह में उस भाग का संबंध होता है। प्रस्तुति-स्तर का डेटा दस्तावेज़-व्यापी मेटाडेटा के लिए उपयुक्त है, स्लाइड-स्तर का डेटा किसी विशेष स्लाइड से जुड़ी जानकारी के लिए, और आकार-स्तर का डेटा व्यक्तिगत आकार से जुड़े मेटाडेटा के लिए।

### **सभी कस्टम XML भागों को सूचीबद्ध करें और ऑडिट करें**

[`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation#getAllCustomXmlParts--) का उपयोग करके प्रस्तुति से सभी कस्टम XML भाग प्राप्त करें। प्रत्येक [`ICustomXmlPart`](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ICustomXmlPart/) अपना पहचानकर्ता, XML सामग्री, और जुड़े नेमस्पेस स्कीमा उजागर करता है।

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

`[`ICustomXmlPart.getNamespaceSchemas()`](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ICustomXmlPart#getNamespaceSchemas--)` कस्टम XML भाग से जुड़े XML स्कीमा लौटाता है। यह जानकारी तब उपयोगी हो सकती है जब आप उन प्रस्तुतियों का ऑडिट कर रहे हों जिनमें बाहरी सिस्टम द्वारा निर्मित XML शामिल है।

### **XML सामग्री और ItemId पढ़ें और अपडेट करें**

[`ICustomXmlPart.getXmlAsString()`](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ICustomXmlPart#getXmlAsString--) और [`setXmlAsString()`](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ICustomXmlPart#setXmlAsString-java.lang.String-) का उपयोग करके XML को UTF-8 स्ट्रिंग के रूप में काम करें, या [`getXmlData()`](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ICustomXmlPart#getXmlData--) और [`setXmlData()`](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ICustomXmlPart#setXmlData-byte:A-) का उपयोग करके कच्चे XML बाइट्स के साथ काम करें।

[`ICustomXmlPart.getItemId()`](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ICustomXmlPart#getItemId--) मेथड Office Open XML दस्तावेज़ में कस्टम XML भाग की पहचान करने वाला UUID लौटाता है। जब इंटीग्रेशन को नया पहचानकर्ता चाहिए, तब [`setItemId()`](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ICustomXmlPart#setItemId-java.util.UUID-) का उपयोग करें।

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

    // इंटीग्रेशन द्वारा आवश्यक होने पर पहचानकर्ता को बदलें।
    customXmlPart.setItemId(UUID.randomUUID());

    presentation.save("updated_custom_xml.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`setXmlAsString` या `setXmlData` को कॉल करते समय वैध, गैर-खाली XML प्रदान करें। स्ट्रिंग या बाइट डेटा के साथ मुख्यतः काम करने वाले एप्लिकेशन के आधार पर एक प्रतिनिधित्व का उपयोग करें।

### **कस्टम XML भाग हटाएँ**

Aspose.Slides कस्टम XML डेटा को हटाने के कई तरीके प्रदान करता है:

- [`ICustomXmlPart.remove`](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ICustomXmlPart#remove--) प्रस्तुति से कस्टम XML भाग को हटाता है।
- [`ICustomXmlPartCollection.remove`](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ICustomXmlPartCollection#remove-com.aspose.slides.ICustomXmlPart-) एक विशिष्ट भाग को कस्टम XML भाग संग्रह से हटाता है।
- [`ICustomXmlPartCollection.removeAt`](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ICustomXmlPartCollection#removeAt-int--) निर्दिष्ट संग्रह सूचकांक पर स्थित भाग को हटाता है।
- [`ICustomXmlPartCollection.clear`](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ICustomXmlPartCollection#clear--) एक विशिष्ट संग्रह से सभी भागों को हटा देता है।

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

यदि आपके पास पहले से ही `ICustomXmlPart` है और आप उस भाग को प्रस्तुति से हटाना चाहते हैं, न कि किसी विशिष्ट संग्रह को संबोधित करना चाहते हैं, तो `customXmlPart.remove()` कॉल करें।

आप इंडेक्स द्वारा भी कोई आइटम हटा सकते हैं:

```java
presentation.getCustomData().getCustomXmlParts().removeAt(0);
```

### **संग्रह से सभी कस्टम XML भाग साफ़ करें**

जब किसी विशिष्ट प्रस्तुति वस्तु से जुड़े सभी कस्टम XML भाग हटाने हों, तब `clear` का उपयोग करें।

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

`clear` केवल चयनित संग्रह को प्रभावित करता है। उदाहरण के लिए, स्लाइड के संग्रह को साफ़ करना प्रस्तुति-स्तर या आकार-स्तर के संग्रह को साफ़ नहीं करता।

प्रस्तुति में प्रत्येक कस्टम XML भाग को हटाने के लिए `getAllCustomXmlParts()` के माध्यम से इटरिटेट करें और प्रत्येक भाग को हटाएँ:

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

Office Open XML प्रस्तुति में, वही कस्टम XML भाग एक से अधिक प्रस्तुति वस्तु से संदर्भित किया जा सकता है। उदाहरण के तौर पर, किसी मौजूदा फ़ाइल में कई स्लाइड या आकारों से एक ही अंतर्निहित कस्टम XML भाग के संबंध हो सकते हैं।

एक साझा भाग को कई संदर्भों वाले एक डेटा वस्तु के रूप में माना जाना चाहिए:

- `setXmlAsString`, `setXmlData` या `setItemId` के साथ इसे अपडेट करने से अंतर्निहित कस्टम XML भाग बदलता है, इसलिए परिवर्तन सभी संदर्भों में लागू होता है।
- ऑडिट के दौरान समान कस्टम XML भाग की पहचान करने के लिए `getItemId()` का उपयोग किया जा सकता है।
- किसी विशेष `getCustomXmlParts()` संग्रह से भाग हटाने से वह संग्रह से हट जाता है। जब स्वयं भाग को पूरी प्रस्तुति से हटाना हो, तब `ICustomXmlPart.remove()` का उपयोग करें।
- साझा भाग को हटाने या बदलने से पहले, वस्तु-स्तर के संग्रहों की जांच करें कि क्या अन्य स्लाइड या आकार अभी भी उसका संदर्भ रखते हैं।

`add` ओवरलोड नए XML सामग्री से नया कस्टम XML भाग बनाते हैं; वे मौजूदा `ICustomXmlPart` को स्वीकार नहीं करते। इसलिए, साझा संबंध अक्सर उन प्रस्तुतियों को लोड करने पर मिलते हैं जिनमें पहले से ये मौजूद होते हैं।

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

इस प्रकार का ऑडिट बाहरी सिस्टम द्वारा निर्मित प्रस्तुतियों में कस्टम XML डेटा को संशोधित या हटाने से पहले उपयोगी होता है, क्योंकि समान मेटाडेटा भाग एक से अधिक संबंध में भाग ले सकता है।

## **टैग्स के मान प्राप्त करें**

स्लाइड्स में, एक टैग `IDocumentProperties.getKeywords()` मेथड के अनुरूप होता है। यह नमूना कोड दिखाता है कि Aspose.Slides for Java के साथ [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation) में टैग का मान कैसे प्राप्त किया जाए:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    String keywords = presentation.getDocumentProperties().getKeywords();
} finally {
    presentation.dispose();
}
```

## **प्रस्तुतियों में टैग्स जोड़ें**

Aspose.Slides आपको प्रस्तुतियों में टैग्स जोड़ने की सुविधा देता है। एक टैग आमतौर पर दो तत्वों से बना होता है:

- कस्टम प्रॉपर्टी का नाम, उदाहरण के लिए `MyTag`;
- कस्टम प्रॉपर्टी का मान, उदाहरण के लिए `My Tag Value`।

यदि आपको किसी विशिष्ट नियम या प्रॉपर्टी के आधार पर प्रस्तुतियों को वर्गीकृत करना है, तो आप इसके लिये टैग्स जोड़ सकते हैं। उदाहरण के तौर पर, यदि आप उत्तरी अमेरिकी देशों की प्रस्तुतियों को वर्गीकृत करना चाहते हैं, तो आप एक "North American" टैग बना सकते हैं और संबंधित देश को उसके मान के रूप में असाइन कर सकते हैं।

यह नमूना कोड दिखाता है कि Aspose.Slides for Java का उपयोग करके एक [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation) में टैग कैसे जोड़ा जाए:

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

टैग्स को एक [Slide](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ISlide) के लिए भी सेट किया जा सकता है:

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

या एक व्यक्तिगत [Shape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IAutoShape) के लिए:

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

`getCustomData().getTags()` संग्रह के माध्यम से जोड़े गए टैग्स केवल PowerPoint फ़ाइल में संग्रहीत होते हैं। जब प्रस्तुति को PDF में निर्यात किया जाता है, तो वे PDF टैग संरचना में **स्थानांतरित नहीं** होते। इसलिए, टैग के रूप में असाइन किया गया कस्टम पहचानकर्ता टैग्ड PDF से प्राप्त नहीं किया जा सकता।

**वैकल्पिक समाधान**: आप वस्तु के **Alt Text** में कस्टम पहचानकर्ता संग्रहीत कर सकते हैं (उदाहरण के लिये `shape.setAlternativeText("MyId")`)। PDF में निर्यात करने के बाद, Alt Text PDF टैग संरचना में दिखाई दे सकता है।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं एक ही ऑपरेशन में प्रस्तुति, स्लाइड, या आकार से सभी टैग हटा सकता हूँ?**

हाँ। टैग संग्रह ([tag collection](https://reference.aspose.com/slides/hi/java/com.aspose.slides/tagcollection/)) एक [clear](https://reference.aspose.com/slides/hi/java/com.aspose.slides/tagcollection/#clear--) ऑपरेशन का समर्थन करता है जो सभी कुंजी-मूल्य जोड़ों को एक बार में हटा देता है।

**मैं पूरे संग्रह पर इटरेट किए बिना किसी टैग को उसके नाम से कैसे हटा सकता हूँ?**

टैग संग्रह ([tag collection](https://reference.aspose.com/slides/hi/java/com.aspose.slides/tagcollection/)) पर `[remove(name)](https://reference.aspose.com/slides/hi/java/com.aspose.slides/tagcollection/#remove-java.lang.String-)` का उपयोग करके टैग को उसके कुंजी द्वारा हटाएँ।

**विश्लेषण या फ़िल्टरिंग के लिये टैग नामों की पूरी सूची कैसे प्राप्त करूँ?**

टैग संग्रह पर `[getNamesOfTags](https://reference.aspose.com/slides/hi/java/com.aspose.slides/tagcollection/#getNamesOfTags--)` का उपयोग करें; यह सभी टैग नामों का ऐरे लौटाता है।

**मैं सभी कस्टम XML भागों को, चाहे वे जहाँ भी संग्रहीत हों, कैसे खोजूँ?**

सभी कस्टम XML भागों को प्राप्त करने के लिये [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation#getAllCustomXmlParts--) का उपयोग करें।

**कस्टम XML भाग को अपडेट करने के लिये `getXmlAsString`/`setXmlAsString` या `getXmlData`/`setXmlData` में से कौन सा उपयोग करूँ?**

जब एप्लिकेशन UTF-8 XML टेक्स्ट के साथ काम करता है, तो `getXmlAsString` और `setXmlAsString` उपयोग करें। जब XML पहले से बाइट एरे के रूप में उपलब्ध है या बाइनरी‑उन्मुख प्रोसेसिंग अधिक सुविधाजनक है, तो `getXmlData` और `setXmlData` उपयोग करें। दोनों प्रतिनिधित्व उसी कस्टम XML भाग की XML सामग्री को दर्शाते हैं।