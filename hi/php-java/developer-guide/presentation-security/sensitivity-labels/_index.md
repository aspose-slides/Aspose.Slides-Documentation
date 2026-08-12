---
title: PHP में PowerPoint प्रस्तुतियों में संवेदनशीलता लेबल प्रबंधित करें
linktitle: संवेदनशीलता लेबल
type: docs
weight: 50
url: /hi/php-java/sensitivity-labels/
keywords:
- संवेदनशीलता लेबल
- Microsoft Purview
- Microsoft Information Protection
- MIP मेटाडेटा
- सामग्री चिह्नन
- सूचना सुरक्षा
- दस्तावेज़ शासन
- PowerPoint
- PPTX
- प्रस्तुति सुरक्षा
- PHP
- Aspose.Slides
description: "PHP में PowerPoint PPTX प्रस्तुतियों में Microsoft Purview संवेदनशीलता लेबल को पढ़ें, जोड़ें, अपडेट करें, हटाएँ और माइग्रेट करें।"
---
## **अवलोकन**

Microsoft Purview संवेदनशीलता लेबल संगठनों को दस्तावेज़ों को वर्गीकृत करने और उनका शासित करने में मदद करते हैं। स्वचालित प्रस्तुति प्रोसेसिंग के दौरान, कोई एप्लिकेशन मौजूदा लेबल को संरक्षित रखने, नीति द्वारा चयनित लेबल लागू करने, उसकी स्थिति को अपडेट करने, या पुराने Microsoft Information Protection (MIP) कार्यप्रवाह द्वारा लिखे गए लेबल मेटाडेटा को माइग्रेट करने की आवश्यकता रख सकता है।

Aspose.Slides for PHP via Java आधुनिक संवेदनशीलता लेबल मेटाडेटा को [Presentation::getSensitivityLabels](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/#getSensitivityLabels) के माध्यम से उजागर करता है। यह विधि एक [SensitivityLabelCollection](https://reference.aspose.com/slides/hi/php-java/aspose.slides/sensitivitylabelcollection/) लौटाता है जिसे प्रस्तुति को PPTX के रूप में सहेजने से पहले निरीक्षण और संशोधित किया जा सकता है।

{{% alert color="primary" title="नोट" %}}

संवेदनशीलता लेबल पहचानकर्ताओं और नीति जानकारी को आपके Microsoft Purview कॉन्फ़िगरेशन द्वारा परिभाषित किया जाता है। लेबल उपलब्धता और नीति आवश्यकताओं को अपने वातावरण में सत्यापित करें उससे पहले कि आप मेटाडेटा जोड़ें या माइग्रेट करें। [SensitivityLabel::getContentMarkTypes](https://reference.aspose.com/slides/hi/php-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) मान लेबल से जुड़े सामग्री चिह्नन का वर्णन करते हैं; वे स्वयं स्लाइड्स में दृश्यमान टेक्स्ट या आकार नहीं जोड़ते हैं।

{{% /alert %}}

## **संवेदनशीलता लेबल गुणों को समझें**

प्रत्येक [SensitivityLabel](https://reference.aspose.com/slides/hi/php-java/aspose.slides/sensitivitylabel/) में निम्नलिखित मेटा डेटा होता है:

| विधियाँ | उद्देश्य |
| --- | --- |
| [SensitivityLabel::getId](https://reference.aspose.com/slides/hi/php-java/aspose.slides/sensitivitylabel/#getId) और [SensitivityLabel::setId](https://reference.aspose.com/slides/hi/php-java/aspose.slides/sensitivitylabel/#setId) | Purview नीति में संवेदनशीलता लेबल पहचानकर्ता को प्राप्त करें या सेट करें। |
| [SensitivityLabel::getSiteId](https://reference.aspose.com/slides/hi/php-java/aspose.slides/sensitivitylabel/#getSiteId) और [SensitivityLabel::setSiteId](https://reference.aspose.com/slides/hi/php-java/aspose.slides/sensitivitylabel/#setSiteId) | लेबल नीति से जुड़ी साइट को प्राप्त करें या सेट करें। |
| [SensitivityLabel::isEnabled](https://reference.aspose.com/slides/hi/php-java/aspose.slides/sensitivitylabel/#isEnabled) और [SensitivityLabel::setEnabled](https://reference.aspose.com/slides/hi/php-java/aspose.slides/sensitivitylabel/#setEnabled) | लेबल सक्षम है या नहीं, इसे प्राप्त करें या सेट करें। |
| [SensitivityLabel::isRemoved](https://reference.aspose.com/slides/hi/php-java/aspose.slides/sensitivitylabel/#isRemoved) और [SensitivityLabel::setRemoved](https://reference.aspose.com/slides/hi/php-java/aspose.slides/sensitivitylabel/#setRemoved) | क्या लेबल को हटाया गया है, इसे प्राप्त करें या सेट करें। हटाने की स्थिति को मेटाडेटा में बनाए रखने के लिए मान `true` सेट करें। |
| [SensitivityLabel::getAssignmentMethodType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/sensitivitylabel/#getAssignmentMethodType) और [SensitivityLabel::setAssignmentMethodType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/sensitivitylabel/#setAssignmentMethodType) | लेबल स्वत: लागू किया गया था या उपयोगकर्ता निर्णय के माध्यम से, इसे प्राप्त करें या सेट करें। |
| [SensitivityLabel::getContentMarkTypes](https://reference.aspose.com/slides/hi/php-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) | लेबल से जुड़े सामग्री चिह्नन प्रकारों को प्राप्त करें। |

[SensitivityLabelAssignmentType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/sensitivitylabelassignmenttype/) क्लास परिभाषित करती है कि लेबल कैसे असाइन किया गया:

- [SensitivityLabelAssignmentType::Standard](https://reference.aspose.com/slides/hi/php-java/aspose.slides/sensitivitylabelassignmenttype/) डिफ़ॉल्ट या स्वत: लागू लेबल को दर्शाता है।
- [SensitivityLabelAssignmentType::Privileged](https://reference.aspose.com/slides/hi/php-java/aspose.slides/sensitivitylabelassignmenttype/) उपयोगकर्ता निर्णय के माध्यम से लागू लेबल को दर्शाता है, जिसमें मैन्युअल, अनुशंसित और अनिवार्य लेबल शामिल हैं।

[SensitivityLabelContentType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/sensitivitylabelcontenttype/) क्लास लेबल से जुड़े चिह्नन को परिभाषित करती है:

| मान | अर्थ |
| --- | --- |
| [SensitivityLabelContentType::None](https://reference.aspose.com/slides/hi/php-java/aspose.slides/sensitivitylabelcontenttype/) | लेबल डिफ़ॉल्ट रूप से या स्वत: लागू किया गया था। |
| [SensitivityLabelContentType::Header](https://reference.aspose.com/slides/hi/php-java/aspose.slides/sensitivitylabelcontenttype/) | हेडर सामग्री चिह्नन लेबल से जुड़ा है। |
| [SensitivityLabelContentType::Footer](https://reference.aspose.com/slides/hi/php-java/aspose.slides/sensitivitylabelcontenttype/) | फुटर सामग्री चिह्नन लेबल से जुड़ा है। |
| [SensitivityLabelContentType::Watermark](https://reference.aspose.com/slides/hi/php-java/aspose.slides/sensitivitylabelcontenttype/) | वॉटरमार्क सामग्री चिह्नन लेबल से जुड़ा है। |
| [SensitivityLabelContentType::Encryption](https://reference.aspose.com/slides/hi/php-java/aspose.slides/sensitivitylabelcontenttype/) | एन्क्रिप्शन सुरक्षा लेबल से जुड़ी है। |

एक लेबल के साथ कई चिह्नन प्रकार जुड़े हो सकते हैं।

## **मौजूदा संवेदनशीलता लेबलों की सूची**

[Presentation::getSensitivityLabels](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/#getSensitivityLabels) से आधुनिक लेबल संग्रह पढ़ें और उसे क्रमबद्ध करें। निम्न उदाहरण प्रत्येक लेबल के लिए सभी गुण और सामग्री चिह्नन को सूचीबद्ध करता है:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $sensitivityLabels = $presentation->getSensitivityLabels();
    $sensitivityLabelCount = java_values($sensitivityLabels->getCount());

    for ($labelIndex = 0; $labelIndex < $sensitivityLabelCount; $labelIndex++) {
        $sensitivityLabel = $sensitivityLabels->get_Item($labelIndex);

        echo "Label ID: " . java_values($sensitivityLabel->getId()) . PHP_EOL;
        echo "Site ID: " . java_values($sensitivityLabel->getSiteId()->toString()) . PHP_EOL;
        echo "Enabled: " . (java_values($sensitivityLabel->isEnabled()) ? "true" : "false") . PHP_EOL;
        echo "Removed: " . (java_values($sensitivityLabel->isRemoved()) ? "true" : "false") . PHP_EOL;
        echo "Assignment method: " . java_values($sensitivityLabel->getAssignmentMethodType()) . PHP_EOL;

        $contentMarkIterator = $sensitivityLabel->getContentMarkTypes()->iterator();
        while (java_values($contentMarkIterator->hasNext())) {
            $contentMarkType = java_values($contentMarkIterator->next());
            echo "Content marking: " . $contentMarkType . PHP_EOL;
        }
    }
} finally {
    $presentation->dispose();
}
```

## **सामग्री चिह्नन के साथ संवेदनशीलता लेबल जोड़ें**

[SensitivityLabelCollection::add](https://reference.aspose.com/slides/hi/php-java/aspose.slides/sensitivitylabelcollection/#add) को लेबल पहचानकर्ता, साइट पहचानकर्ता, सक्षम स्थिति और असाइनमेंट विधि के साथ उपयोग करें। विधि नया [SensitivityLabel](https://reference.aspose.com/slides/hi/php-java/aspose.slides/sensitivitylabel/) लौटाने के बाद, आवश्यक चिह्नन मानों को [SensitivityLabel::getContentMarkTypes](https://reference.aspose.com/slides/hi/php-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) द्वारा लौटाए गए सूची के माध्यम से जोड़ें।

निम्न उदाहरण मान्यताप्राप्त फुटर और वॉटरमार्क चिह्ननों के साथ मैन्युअल रूप से चयनित लेबल जोड़ता है, और फिर परिणाम को PPTX के रूप में सहेजता है:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $sensitivityLabels = $presentation->getSensitivityLabels();

    $labelIdentifier = "{11111111-2222-3333-4444-555555555555}";
    $UUID = new JavaClass("java.util.UUID");
    $siteIdentifier = $UUID->fromString("aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee");
    $isEnabled = true;
    $assignmentMethod = SensitivityLabelAssignmentType::Privileged;

    $sensitivityLabel = $sensitivityLabels->add(
        $labelIdentifier,
        $siteIdentifier,
        $isEnabled,
        $assignmentMethod
    );

    $contentMarkTypes = $sensitivityLabel->getContentMarkTypes();
    $contentMarkTypes->addItem(SensitivityLabelContentType::Footer);
    $contentMarkTypes->addItem(SensitivityLabelContentType::Watermark);

    $presentation->save("presentation_with_label.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **संवेदनशीलता लेबल को अपडेट करें**

[SensitivityLabel](https://reference.aspose.com/slides/hi/php-java/aspose.slides/sensitivitylabel/) मान पढ़ने/लिखने योग्य होते हैं, सिवाय इसके कि [SensitivityLabel::getContentMarkTypes](https://reference.aspose.com/slides/hi/php-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) द्वारा लौटाई गई सूची को उसकी सूची संचालन के माध्यम से संशोधित किया जाता है। आवश्यक लेबल को खोजने के बाद, आप उसकी पहचानकर्ता, साइट पहचानकर्ता, सक्षम स्थिति, असाइनमेंट विधि, हटाने की स्थिति और सामग्री चिह्नन प्रकारों को अपडेट कर सकते हैं। परिवर्तन को स्थायी करने के लिए प्रस्तुति को सहेजें।

निम्न उदाहरण पहले लेबल की सक्षम स्थिति और असाइनमेंट विधि को अपडेट करता है:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $sensitivityLabels = $presentation->getSensitivityLabels();
    $sensitivityLabelCount = java_values($sensitivityLabels->getCount());

    if ($sensitivityLabelCount > 0) {
        $sensitivityLabel = $sensitivityLabels->get_Item(0);
        $sensitivityLabel->setEnabled(true);
        $sensitivityLabel->setAssignmentMethodType(SensitivityLabelAssignmentType::Privileged);
    }

    $presentation->save("presentation_with_updated_label.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **संवेदनशीलता लेबल को हटाए गए के रूप में चिह्नित करें**

लेबल को हटाए गए के रूप में चिह्नित रखने के लिए, लेबल खोजें और [SensitivityLabel::setRemoved](https://reference.aspose.com/slides/hi/php-java/aspose.slides/sensitivitylabel/#setRemoved) को `true` के साथ कॉल करें। इससे लेबल प्रविष्टि बनी रहती है और उसकी हटाने की स्थिति दर्ज होती है। यदि आप आधुनिक संग्रह से प्रविष्टि को पूरी तरह हटाना चाहते हैं, तो [SensitivityLabelCollection::removeAt](https://reference.aspose.com/slides/hi/php-java/aspose.slides/sensitivitylabelcollection/#removeAt) का उपयोग करें; सभी प्रविष्टियों को हटाने के लिए [SensitivityLabelCollection::clear](https://reference.aspose.com/slides/hi/php-java/aspose.slides/sensitivitylabelcollection/#clear) का उपयोग करें।

निम्न उदाहरण एक विशिष्ट लेबल को हटाए गए के रूप में चिह्नित करता है और अपडेटेड प्रस्तुति को सहेजता है:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $sensitivityLabels = $presentation->getSensitivityLabels();
    $targetLabelIdentifier = "{11111111-2222-3333-4444-555555555555}";
    $sensitivityLabelCount = java_values($sensitivityLabels->getCount());

    for ($labelIndex = 0; $labelIndex < $sensitivityLabelCount; $labelIndex++) {
        $sensitivityLabel = $sensitivityLabels->get_Item($labelIndex);
        $labelIdentifier = java_values($sensitivityLabel->getId());
        $isTargetLabel = strcasecmp($labelIdentifier, $targetLabelIdentifier) === 0;

        if ($isTargetLabel) {
            $sensitivityLabel->setRemoved(true);
            break;
        }
    }

    $presentation->save("presentation_with_removed_label.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **पुराने MIP संवेदनशीलता लेबल पढ़ें और माइग्रेट करें**

पुराने MIP-आधारित कार्यप्रवाह आधुनिक लेबल संग्रह की बजाय कस्टम दस्तावेज़ गुणों में संवेदनशीलता लेबल मेटाडेटा संग्रहीत कर सकते हैं। इस मेटाडेटा को [DocumentProperties::getSensitivityLabels](https://reference.aspose.com/slides/hi/php-java/aspose.slides/documentproperties/#getSensitivityLabels) के साथ पढ़ें। यह विधि पुरानी कस्टम गुणों को पार्स करके [SensitivityLabel](https://reference.aspose.com/slides/hi/php-java/aspose.slides/sensitivitylabel/) ऑब्जेक्ट्स की एक Java ऐरे लौटाती है।

मेटाडेटा को माइग्रेट करने के लिए, प्रत्येक लौटाए गए लेबल को [SensitivityLabelCollection::add](https://reference.aspose.com/slides/hi/php-java/aspose.slides/sensitivitylabelcollection/#add) के माध्यम से आधुनिक [SensitivityLabelCollection](https://reference.aspose.com/slides/hi/php-java/aspose.slides/sensitivitylabelcollection/) में जोड़ें। डुप्लिकेट लेबल पहचानकर्ता जोड़ने पर अपवाद उत्पन्न होता है, इसलिए उदाहरण प्रत्येक लेबल को कॉपी करने से पहले लक्ष्य संग्रह को जांचता है। आप आगे वैधता जाँच जोड़ सकते हैं यह सुनिश्चित करने के लिए कि प्रत्येक पुराना लेबल अभी भी वर्तमान Purview नीति में मौजूद है।

```php
$presentation = new Presentation("presentation_with_legacy_labels.pptx");
try {
    $legacySensitivityLabels = $presentation->getDocumentProperties()->getSensitivityLabels();
    $modernSensitivityLabels = $presentation->getSensitivityLabels();

    $Array = new JavaClass("java.lang.reflect.Array");
    $legacyLabelCount = java_values($Array->getLength($legacySensitivityLabels));

    for ($legacyLabelIndex = 0; $legacyLabelIndex < $legacyLabelCount; $legacyLabelIndex++) {
        $legacySensitivityLabel = $legacySensitivityLabels[$legacyLabelIndex];
        $legacyLabelIdentifier = java_values($legacySensitivityLabel->getId());
        $labelAlreadyExists = false;
        $modernLabelCount = java_values($modernSensitivityLabels->getCount());

        for ($modernLabelIndex = 0; $modernLabelIndex < $modernLabelCount; $modernLabelIndex++) {
            $modernSensitivityLabel = $modernSensitivityLabels->get_Item($modernLabelIndex);
            $modernLabelIdentifier = java_values($modernSensitivityLabel->getId());
            $labelAlreadyExists = strcasecmp(
                $modernLabelIdentifier,
                $legacyLabelIdentifier
            ) === 0;

            if ($labelAlreadyExists) {
                break;
            }
        }

        if (!$labelAlreadyExists) {
            $modernSensitivityLabels->add($legacySensitivityLabel);
        }
    }

    $presentation->save("presentation_with_modern_labels.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

माइग्रेशन पार्स किए गए लेबल ऑब्जेक्ट्स को आधुनिक संग्रह में कॉपी करता है। इसे सभी कस्टम दस्तावेज़ गुणों को साफ़ करने की आवश्यकता नहीं होती, इसलिए असंबंधित दस्तावेज़ मेटाडेटा बना रहता है। आधुनिक लेबल मेटाडेटा को PPTX फ़ाइल में लिखने के लिए [Presentation::save](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/#save) को [SaveFormat::Pptx](https://reference.aspose.com/slides/hi/php-java/aspose.slides/saveformat/) के साथ उपयोग करें।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या सामग्री चिह्नन प्रकार जोड़ने से स्लाइड्स पर दृश्य हेडर, फुटर या वॉटरमार्क बनता है?**

नहीं। [SensitivityLabel::getContentMarkTypes](https://reference.aspose.com/slides/hi/php-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) द्वारा लौटाई गई सूची में जोड़े गए मान लेबल से जुड़े चिह्ननों का वर्णन करते हैं। वे प्रस्तुति में दृश्यमान टेक्स्ट या आकार नहीं बनाते हैं। यदि आपके कार्यप्रवाह को इन चिह्ननों को रेंडर करना आवश्यक है, तो संबंधित स्लाइड सामग्री को अलग से जोड़ें।

**लेबल को हटाए गए के रूप में चिह्नित करने और संग्रह से उसे हटाने में क्या अंतर है?**

[SensitivityLabel::setRemoved](https://reference.aspose.com/slides/hi/php-java/aspose.slides/sensitivitylabel/#setRemoved) को `true` के साथ कॉल करने से लेबल प्रविष्टि बनी रहती है और उसकी हटाने की स्थिति दर्ज होती है। [SensitivityLabelCollection::removeAt](https://reference.aspose.com/slides/hi/php-java/aspose.slides/sensitivitylabelcollection/#removeAt) को कॉल करने से प्रविष्टि आधुनिक संग्रह से पूरी तरह हट जाती है। अपनी संस्था की मेटाडेटा प्रतिधारण आवश्यकताओं के अनुसार उपयुक्त ऑपरेशन चुनें।

**क्या एक प्रस्तुति में पुरानी MIP मेटाडेटा और आधुनिक संवेदनशीलता लेबल दोनों हो सकते हैं?**

हां। पुरानी लेबलें कस्टम दस्तावेज़ गुणों में बनी रह सकती हैं, जबकि आधुनिक लेबलें [Presentation::getSensitivityLabels](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/#getSensitivityLabels) के माध्यम से उपलब्ध रहती हैं। पुरानी मेटाडेटा पढ़ने और केवल वैध लेबलों को माइग्रेट करने के लिए [DocumentProperties::getSensitivityLabels](https://reference.aspose.com/slides/hi/php-java/aspose.slides/documentproperties/#getSensitivityLabels) का उपयोग करें, जिससे वे पहले से ही आधुनिक संग्रह में मौजूद नहीं हों।

**जब एक ही पहचानकर्ता वाले लेबल को कई बार जोड़ दिया जाए तो क्या होता है?**

[SensitivityLabelCollection::add](https://reference.aspose.com/slides/hi/php-java/aspose.slides/sensitivitylabelcollection/#add) तब अपवाद उठाता है जब संग्रह में पहले से वही पहचानकर्ता वाला लेबल मौजूद हो। लेबल जोड़ने या माइग्रेट करने से पहले [SensitivityLabel::getId](https://reference.aspose.com/slides/hi/php-java/aspose.slides/sensitivitylabel/#getId) द्वारा लौटाई गई मौजूदा मानों को जांचें।

**अपडेटेड संवेदनशीलता लेबल को संरक्षित रखने के लिए कौन सा आउटपुट फॉर्मेट उपयोग करना चाहिए?**

उपर्युक्त उदाहरणों के अनुसार प्रस्तुति को PPTX के रूप में सहेजने के लिए [Presentation::save](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/#save) को [SaveFormat::Pptx](https://reference.aspose.com/slides/hi/php-java/aspose.slides/saveformat/) के साथ बुलाएँ।