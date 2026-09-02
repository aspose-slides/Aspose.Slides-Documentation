---
title: PHP का उपयोग करके प्रस्तुतियों में टैग और कस्टम डेटा का प्रबंधन
linktitle: टैग और कस्टम डेटा
type: docs
weight: 300
url: /hi/php-java/managing-tags-and-custom-data/
keywords:
- दस्तावेज़ गुण
- टैग
- कस्टम डेटा
- कस्टम XML
- कस्टम XML भाग
- XML मेटाडाटा
- ItemId
- टैग जोड़ें
- जुड़े मान
- PowerPoint
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java का उपयोग करके PowerPoint प्रस्तुतियों में टैग और कस्टम XML डेटा को व्यवस्थित करना सीखें, जिसमें कस्टम XML भागों को जोड़ना, पढ़ना, अपडेट करना, ऑडिट करना और हटाना शामिल है।"
---
## **परिचय**

यह लेख बताता है कि Aspose.Slides PowerPoint प्रस्तुतियों में टैग और कस्टम डेटा के साथ कैसे काम करता है। प्रस्तुति‑विशिष्ट डेटा को टैग या कस्टम XML भागों के रूप में संग्रहीत किया जा सकता है। टैग सरल की‑वैल्यू स्ट्रिंग युग्म होते हैं, जबकि कस्टम XML भाग संरचित मेटाडेटा और एप्लिकेशन‑विशिष्ट XML पेलोड संग्रहीत कर सकते हैं।

Aspose.Slides प्रस्तुति, स्लाइड और शैप स्तर पर कस्टम XML भागों को जोड़ने, पढ़ने, अपडेट करने, ऑडिट करने और हटाने के लिए API प्रदान करता है। कस्टम XML भाग उन इंटीग्रेशन के लिए उपयोगी होते हैं जिनमें दस्तावेज‑प्रबंधन पहचानकर्ता, वर्कफ़्लो स्थिति, अनुपालन मेटाडेटा, टेम्पलेट‑बाइंडिंग डेटा या अन्य संरचित एप्लिकेशन डेटा को प्रस्तुति के भीतर संग्रहीत करना होता है।

## **प्रस्तुति फ़ाइलों में डेटा संग्रह**

`.pptx` एक्सटेंशन वाली PPTX फ़ाइलें PresentationML फॉर्मेट में संग्रहीत होती हैं, जो Office Open XML विनिर्देशन का हिस्सा है। Office Open XML पैकेज संरचना और संबंधों को परिभाषित करता है जो प्रस्तुति सामग्री और सम्बंधित डेटा को संग्रहीत करते हैं।

एक प्रस्तुति में कई भाग होते हैं जो संबंधों द्वारा जुड़े होते हैं। उदाहरण के लिए, एक स्लाइड भाग एकल स्लाइड की सामग्री रखता है और ISO/IEC 29500 द्वारा परिभाषित अन्य भागों के साथ स्पष्ट संबंध रख सकता है।

कस्टम डेटा को टैग ([TagCollection](https://reference.aspose.com/slides/hi/php-java/aspose.slides/tagcollection/)) या कस्टम XML भाग ([CustomXmlPartCollection](https://reference.aspose.com/slides/hi/php-java/aspose.slides/customxmlpartcollection/)) के रूप में संग्रहीत किया जा सकता है। दोनों ही [`CustomData`](https://reference.aspose.com/slides/hi/php-java/aspose.slides/customdata/) क्लास के माध्यम से उपलब्ध हैं।

{{% alert color="primary" %}}
टैग सरल स्ट्रिंग की‑वैल्यू युग्म संग्रहीत करते हैं। कस्टम XML भाग संरचित XML डेटा संग्रहीत करते हैं और इन्हें प्रस्तुति, स्लाइड या शैप के साथ संबद्ध किया जा सकता है।
{{% /alert %}}

## **कस्टम XML भागों के साथ कार्य करना**

[`CustomData::getCustomXmlParts()`](https://reference.aspose.com/slides/hi/php-java/aspose.slides/customdata/#getCustomXmlParts) मेथड उस विशेष प्रस्तुति ऑब्जेक्ट से जुड़े कस्टम XML भागों के संग्रह को लौटाता है। उदाहरण के लिए:

- `$presentation->getCustomData()->getCustomXmlParts()` में प्रस्तुति स्वयं से जुड़े कस्टम XML भाग होते हैं।
- `$slide->getCustomData()->getCustomXmlParts()` में किसी विशिष्ट स्लाइड से जुड़े कस्टम XML भाग होते हैं।
- `$shape->getCustomData()->getCustomXmlParts()` में किसी विशिष्ट शैप से जुड़े कस्टम XML भाग होते हैं।

जब आपको प्रस्तुति में सभी कस्टम XML भागों की जाँच करनी हो, चाहे वे किसी भी स्तर से जुड़े हों, तो [`Presentation::getAllCustomXmlParts()`](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/#getAllCustomXmlParts) का उपयोग करें।

### **प्रस्तुति में एक कस्टम XML भाग जोड़ें**

[`CustomXmlPartCollection::add`](https://reference.aspose.com/slides/hi/php-java/aspose.slides/customxmlpartcollection/#add) का उपयोग करके XML डेटा को कस्टम XML भाग संग्रह में जोड़ा जा सकता है। XML वैध और रिक्त‑ नहीं होना चाहिए।

निम्न उदाहरण संरचित मेटाडेटा को प्रस्तुति‑स्तर के कस्टम डेटा संग्रह में जोड़ता है:

```php
$customXmlContent =
    '<?xml version="1.0" encoding="UTF-8"?>' .
    '<metadata xmlns="urn:example:metadata">' .
        '<documentId>DOC-1001</documentId>' .
        '<workflowState>Draft</workflowState>' .
    '</metadata>';

$presentation = new Presentation();
try {
    $customXmlPart = $presentation->getCustomData()->getCustomXmlParts()->add($customXmlContent);

    // जोड़ स्वचालित रूप से एक पहचानकर्ता निर्धारित करता है। केवल आवश्यकता होने पर विशिष्ट UUID सेट करें।
    $UUID = new JavaClass("java.util.UUID");
    $customXmlPart->setItemId($UUID->randomUUID());

    $presentation->save("presentation_with_custom_xml.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

`add` मेथड XML को बाइट एरे या इनपुट स्ट्रीम के रूप में भी स्वीकार कर सकता है, जो तब उपयोगी होता है जब XML सामग्री पहले से बाइनरी रूप में उपलब्ध हो।

### **स्लाइड या शैप में कस्टम XML भाग जोड़ें**

कस्टम XML डेटा को पूरी प्रस्तुति के बजाय किसी विशिष्ट स्लाइड या शैप से जोड़ा जा सकता है। यह तब उपयोगी होता है जब मेटाडेटा केवल एक ऑब्जेक्ट, जैसे टेम्पलेट कुंजी, बाहरी रिकॉर्ड पहचानकर्ता या बाइंडिंग जानकारी का वर्णन करता हो।

निम्न उदाहरण एक कस्टम XML भाग को स्लाइड में और दूसरा शैप में जोड़ता है:

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $slide->getCustomData()->getCustomXmlParts()->add(
        '<slideMetadata xmlns="urn:example:slides">' .
            '<templateKey>TitleSlide</templateKey>' .
        '</slideMetadata>'
    );

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 250, 80);

    $shape->getTextFrame()->setText("Customer data");
    $shape->getCustomData()->getCustomXmlParts()->add(
        '<shapeMetadata xmlns="urn:example:shapes">' .
            '<recordId>CRM-4281</recordId>' .
        '</shapeMetadata>'
    );

    $presentation->save("object_custom_xml.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

जिस स्तर पर भाग जोड़ा जाता है, वह निर्धारित करता है कि किस ऑब्जेक्ट का `getCustomData()->getCustomXmlParts()` संग्रह उस भाग के संबंध को रखेगा। प्रस्तुति‑स्तर का डेटा दस्तावेज‑व्यापी मेटाडेटा के लिए उपयुक्त है, स्लाइड‑स्तर का डेटा किसी विशिष्ट स्लाइड से संबंधित जानकारी के लिए, तथा शैप‑स्तर का डेटा व्यक्तिगत शैप से जुड़ी मेटाडेटा के लिए।

### **सभी कस्टम XML भागों को सूचीबद्ध और ऑडिट करें**

[`Presentation::getAllCustomXmlParts()`](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/#getAllCustomXmlParts) का उपयोग करके प्रस्तुति से सभी कस्टम XML भाग प्राप्त किए जा सकते हैं। प्रत्येक [`CustomXmlPart`](https://reference.aspose.com/slides/hi/php-java/aspose.slides/customxmlpart/) अपना पहचानकर्ता, XML सामग्री और सम्बंधित नेमस्पेस स्कीमा प्रदर्शित करता है।

निम्न उदाहरण सभी कस्टम XML भागों और उनके नेमस्पेस स्कीमा को सूचीबद्ध करता है:

```php
$presentation = new Presentation("presentation.pptx");
try {
    foreach ($presentation->getAllCustomXmlParts() as $customXmlPart) {
        echo "ItemId: " . $customXmlPart->getItemId() . PHP_EOL;
        echo "XML:" . PHP_EOL;
        echo $customXmlPart->getXmlAsString() . PHP_EOL;

        foreach ($customXmlPart->getNamespaceSchemas() as $namespaceSchema) {
            echo "Namespace schema: " . $namespaceSchema . PHP_EOL;
        }

        echo PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

[`CustomXmlPart::getNamespaceSchemas()`](https://reference.aspose.com/slides/hi/php-java/aspose.slides/customxmlpart/#getNamespaceSchemas) कस्टम XML भाग से जुड़े XML स्कीमा लौटाता है। यह जानकारी उन प्रस्तुतियों के ऑडिट में सहायक हो सकती है जिनमें बाहरी सिस्टम द्वारा निर्मित XML शामिल है।

### **XML सामग्री और ItemId को पढ़ें और अपडेट करें**

XML को UTF‑8 स्ट्रिंग के रूप में काम करने के लिए [`CustomXmlPart::getXmlAsString()`](https://reference.aspose.com/slides/hi/php-java/aspose.slides/customxmlpart/#getXmlAsString) और [`setXmlAsString()`](https://reference.aspose.com/slides/hi/php-java/aspose.slides/customxmlpart/#setXmlAsString) का उपयोग करें, या कच्चे XML बाइट्स के लिए [`getXmlData()`](https://reference.aspose.com/slides/hi/php-java/aspose.slides/customxmlpart/#getXmlData) और [`setXmlData()`](https://reference.aspose.com/slides/hi/php-java/aspose.slides/customxmlpart/#setXmlData) का उपयोग करें।

[`CustomXmlPart::getItemId()`](https://reference.aspose.com/slides/hi/php-java/aspose.slides/customxmlpart/#getItemId) मेथड वह UUID लौटाता है जो Office Open XML दस्तावेज़ में कस्टम XML भाग की पहचान करता है। जब किसी इंटीग्रेशन को नया पहचानकर्ता चाहिए तो [`setItemId()`](https://reference.aspose.com/slides/hi/php-java/aspose.slides/customxmlpart/#setItemId) का उपयोग करें।

निम्न उदाहरण XML सामग्री और पहचानकर्ता को अपडेट करता है:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $customXmlPart = $presentation->getAllCustomXmlParts()[0];

    // वर्तमान XML को पाठ के रूप में पढ़ें।
    $currentXmlContent = $customXmlPart->getXmlAsString();
    echo $currentXmlContent . PHP_EOL;

    // XML को UTF-8 स्ट्रिंग के रूप में अपडेट करें।
    $customXmlPart->setXmlAsString(
        '<metadata xmlns="urn:example:metadata">' .
            '<documentId>DOC-1001</documentId>' .
            '<workflowState>Approved</workflowState>' .
        '</metadata>'
    );

    // getXmlData समान XML सामग्री को कच्चे बाइट्स के रूप में प्रदान करता है।
    $customXmlData = $customXmlPart->getXmlData();

    // इंटीग्रेशन द्वारा आवश्यक होने पर पहचानकर्ता को बदलें।
    $UUID = new JavaClass("java.util.UUID");
    $customXmlPart->setItemId($UUID->randomUUID());

    $presentation->save("updated_custom_xml.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

`setXmlAsString` या `setXmlData` को कॉल करते समय वैध, गैर‑रिक्त XML प्रदान करें। एप्लिकेशन के कार्य शैली के अनुसार स्ट्रिंग या बाइट प्रतिनिधित्व में से एक चुनें।

### **कस्टम XML भाग को हटाएँ**

Aspose.Slides कस्टम XML डेटा को हटाने के कई तरीके प्रदान करता है:

- [`CustomXmlPart::remove`](https://reference.aspose.com/slides/hi/php-java/aspose.slides/customxmlpart/#remove) कस्टम XML भाग को प्रस्तुति से हटाता है।
- [`CustomXmlPartCollection::remove`](https://reference.aspose.com/slides/hi/php-java/aspose.slides/customxmlpartcollection/#remove) एक विशिष्ट भाग को कस्टम XML भाग संग्रह से हटाता है।
- [`CustomXmlPartCollection::removeAt`](https://reference.aspose.com/slides/hi/php-java/aspose.slides/customxmlpartcollection/#removeAt) निर्दिष्ट संग्रह इंडेक्स पर स्थित भाग को हटाता है।
- [`CustomXmlPartCollection::clear`](https://reference.aspose.com/slides/hi/php-java/aspose.slides/customxmlpartcollection/#clear) किसी विशिष्ट संग्रह से सभी भाग हटाता है।

निम्न उदाहरण एक प्रस्तुति‑स्तर के कस्टम XML भाग को संदर्भ द्वारा हटाता है:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $customXmlParts = $presentation->getCustomData()->getCustomXmlParts();

    if (java_values($customXmlParts->size()) > 0) {
        $customXmlPart = $customXmlParts->get_Item(0);
        $customXmlParts->remove($customXmlPart);
    }

    $presentation->save("custom_xml_removed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

यदि आपके पास पहले से एक `CustomXmlPart` है और आप उसे प्रस्तुति से हटाना चाहते हैं, न कि किसी संग्रह से, तो `$customXmlPart->remove()` को कॉल करें।

इंडेक्स द्वारा भी किसी आइटम को हटाया जा सकता है:

```php
$presentation->getCustomData()->getCustomXmlParts()->removeAt(0);
```

### **किसी संग्रह से सभी कस्टम XML भागों को साफ़ करें**

जब किसी विशेष प्रस्तुति ऑब्जेक्ट से जुड़े सभी कस्टम XML भाग हटाने हों, तो `clear` का उपयोग करें।

```php
$presentation = new Presentation("presentation.pptx");
try {
    $presentation->getSlides()->get_Item(0)->getCustomData()->getCustomXmlParts()->clear();

    $presentation->save("slide_custom_xml_cleared.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

`clear` केवल चयनित संग्रह को प्रभावित करता है। उदाहरण के लिए, एक स्लाइड के संग्रह को साफ़ करने से प्रस्तुति‑स्तर या शैप‑स्तर के संग्रह नहीं हटते।

प्रस्तुति में मौजूद प्रत्येक कस्टम XML भाग को हटाने के लिए `getAllCustomXmlParts()` पर iterate करें और प्रत्येक भाग को हटाएँ:

```php
$presentation = new Presentation("presentation.pptx");
try {
    foreach ($presentation->getAllCustomXmlParts() as $customXmlPart) {
        $customXmlPart->remove();
    }

    $presentation->save("all_custom_xml_removed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **लिंक्ड या साझा कस्टम XML भागों को संभालें**

Office Open XML प्रस्तुति में वही कस्टम XML भाग कई प्रस्तुति ऑब्जेक्ट्स द्वारा संदर्भित किया जा सकता है। उदाहरण के लिए, एक मौजूदा फ़ाइल में कई स्लाइड या शैप एक ही अंतर्निहित कस्टम XML भाग से जुड़े हो सकते हैं।

एक साझा भाग को कई संदर्भों वाला एक डेटा ऑब्जेक्ट माना जाना चाहिए:

- `setXmlAsString`, `setXmlData` या `setItemId` से उसे अपडेट करने से अंतर्निहित कस्टम XML भाग बदलता है, इसलिए परिवर्तन सभी संदर्भों में दिखता है।
- `getItemId()` का उपयोग ऑब्जेक्ट‑लेवल संग्रहों को ऑडिट करते समय समान कस्टम XML भाग को पहचानने के लिए किया जा सकता है।
- किसी विशिष्ट `getCustomXmlParts()` संग्रह से भाग हटाने से वह केवल उस संग्रह से हटता है। यदि भाग स्वयं को प्रस्तुति से हटाना हो, तो `CustomXmlPart::remove()` का उपयोग करें।
- साझा भाग को हटाने या बदलने से पहले ऑब्जेक्ट‑लेवल संग्रहों की जाँच करके पता करें कि क्या अन्य स्लाइड या शैप अभी भी उसे संदर्भित कर रहे हैं।

`add` ओवरलोड केवल XML सामग्री से नया कस्टम XML भाग बनाते हैं; वे मौजूदा `CustomXmlPart` को स्वीकार नहीं करते। इसलिए, साझा संबंध मुख्य रूप से उन प्रस्तुतियों में देखे जाते हैं जो पहले से इन भागों को सम्मिलित करती हैं।

निम्न उदाहरण `ItemId` द्वारा प्रस्तुति, स्लाइड और शैप‑स्तर के संग्रहों को ऑडिट करता है और उन भागों को रिपोर्ट करता है जो एक से अधिक स्थान से संदर्भित हैं:

```php
function registerCustomXmlParts($ownerName, $customXmlParts, &$referencesByItemId) {
    $partCount = java_values($customXmlParts->size());

    for ($i = 0; $i < $partCount; $i++) {
        $customXmlPart = $customXmlParts->get_Item($i);
        $itemId = java_values($customXmlPart->getItemId()->toString());

        if (!isset($referencesByItemId[$itemId])) {
            $referencesByItemId[$itemId] = [];
        }

        $referencesByItemId[$itemId][] = $ownerName;
    }
}

$presentation = new Presentation("presentation.pptx");
try {
    $referencesByItemId = [];

    registerCustomXmlParts(
        "Presentation",
        $presentation->getCustomData()->getCustomXmlParts(),
        $referencesByItemId
    );

    $slideCount = java_values($presentation->getSlides()->size());
    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        registerCustomXmlParts(
            "Slide " . ($slideIndex + 1),
            $slide->getCustomData()->getCustomXmlParts(),
            $referencesByItemId
        );

        $shapeCount = java_values($slide->getShapes()->size());
        for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            registerCustomXmlParts(
                "Slide " . ($slideIndex + 1) . ", shape " . $shapeIndex,
                $shape->getCustomData()->getCustomXmlParts(),
                $referencesByItemId
            );
        }
    }

    foreach ($referencesByItemId as $itemId => $owners) {
        if (count($owners) > 1) {
            echo "Shared custom XML part: " . $itemId . PHP_EOL;

            foreach ($owners as $ownerName) {
                echo "  Referenced by: " . $ownerName . PHP_EOL;
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

यह प्रकार का ऑडिट उन प्रस्तुतियों में कस्टम XML डेटा को संशोधित या हटाने से पहले उपयोगी होता है, जो बाहरी सिस्टम द्वारा निर्मित होते हैं, क्योंकि समान मेटाडेटा भाग कई संबंधों में भाग ले सकता है।

## **टैग के मान प्राप्त करें**

स्लाइड में, टैग `DocumentProperties::getKeywords()` मेथड के समतुल्य है। यह नमूना कोड दिखाता है कि Aspose.Slides for PHP via Java का उपयोग करके [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) से टैग मान कैसे प्राप्त किया जाए:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $keywords = $presentation->getDocumentProperties()->getKeywords();
} finally {
    $presentation->dispose();
}
```

## **प्रस्तुति में टैग जोड़ें**

Aspose.Slides आपको प्रस्तुतियों में टैग जोड़ने की सुविधा देता है। एक टैग आमतौर पर दो आइटम से बना होता है:

- कस्टम प्रॉपर्टी का नाम, उदाहरण: `MyTag`;
- कस्टम प्रॉपर्टी का मान, उदाहरण: `My Tag Value`.

यदि आपको प्रस्तुतियों को किसी विशेष नियम या प्रॉपर्टी के आधार पर वर्गीकृत करना है, तो आप इसके लिए टैग जोड़ सकते हैं। उदाहरण के लिए, यदि आप उत्तर अमेरिकी देशों की प्रस्तुतियों को वर्गीकृत करना चाहते हैं, तो आप एक “NorthAmerican” टैग बनाकर संबंधित देश को उसके मान के रूप में असाइन कर सकते हैं।

यह नमूना कोड Aspose.Slides for PHP via Java का उपयोग करके एक [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) में टैग जोड़ना दर्शाता है:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $tags = $presentation->getCustomData()->getTags();
    $tags->set_Item("MyTag", "My Tag Value");
} finally {
    $presentation->dispose();
}
```

टैग को एक [Slide](https://reference.aspose.com/slides/hi/php-java/aspose.slides/slide/) के लिए भी सेट किया जा सकता है:

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $slide->getCustomData()->getTags()->set_Item("tag", "value");
} finally {
    $presentation->dispose();
}
```

या व्यक्तिगत [Shape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/autoshape/) के लिए:

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 50);
    $shape->getTextFrame()->setText("My text");
    $shape->getCustomData()->getTags()->set_Item("tag", "value");
} finally {
    $presentation->dispose();
}
```

### **सीमाएँ**

`getCustomData()->getTags()` संग्रह के माध्यम से जोड़े गए टैग केवल PowerPoint फ़ाइल में संग्रहीत होते हैं। उन्हें PDF निर्यात करने पर PDF टैग संरचना में **स्थानांतरित नहीं** किया जाता। इसलिए, टैग के रूप में असाइन किया गया कस्टम पहचानकर्ता टैग्ड PDF से प्राप्त नहीं किया जा सकता।

**वर्कअराउंड**: आप कस्टम पहचानकर्ता को ऑब्जेक्ट के **Alt Text** में संग्रहीत कर सकते हैं (उदाहरण: `$shape->setAlternativeText("MyId")`)। PDF में निर्यात करने के बाद Alt Text PDF टैग संरचना में दिखाई दे सकता है।

## **FAQ**

**क्या मैं एक ही ऑपरेशन में सभी टैग को प्रस्तुति, स्लाइड या शैप से हटा सकता हूँ?**  
हाँ। [tag collection](https://reference.aspose.com/slides/hi/php-java/aspose.slides/tagcollection/) में [clear](https://reference.aspose.com/slides/hi/php-java/aspose.slides/tagcollection/#clear) ऑपरेशन सभी की‑वैल्यू युग्मों को एक बार में हटा देता है।

**मैं संग्रह पर इटररेट किए बिना नाम से एकल टैग कैसे हटाऊँ?**  
[tag collection](https://reference.aspose.com/slides/hi/php-java/aspose.slides/tagcollection/) पर `remove(name)` का प्रयोग करके टैग को उसकी कुंजी से हटाएँ।

**एनालिटिक्स या फ़िल्टरिंग के लिए टैग नामों की पूरी सूची कैसे प्राप्त करूँ?**  
[tag collection](https://reference.aspose.com/slides/hi/php-java/aspose.slides/tagcollection/) पर `getNamesOfTags` का उपयोग करें; यह सभी टैग नामों का एरे लौटाता है।

**सभी कस्टम XML भागों को, चाहे वे जहाँ भी संग्रहीत हों, कैसे खोजूँ?**  
[`Presentation::getAllCustomXmlParts()`](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/#getAllCustomXmlParts) का उपयोग करके प्रस्तुति के सभी कस्टम XML भाग प्राप्त करें।

**कस्टम XML भाग को अपडेट करने के लिए मुझे `getXmlAsString`/`setXmlAsString` या `getXmlData`/`setXmlData` में से कौन सा उपयोग करना चाहिए?**  
जब एप्लिकेशन UTF‑8 XML टेक्स्ट के साथ काम करता है, तो `getXmlAsString` और `setXmlAsString` उपयोग करें। जब XML पहले से बाइट एरे के रूप में उपलब्ध है या बाइनरी‑उन्मुख प्रोसेसिंग अधिक सुविधाजनक है, तो `getXmlData` और `setXmlData` उपयोग करें। दोनों प्रतिनिधित्व एक ही कस्टम XML भाग की सामग्री को दर्शाते हैं।