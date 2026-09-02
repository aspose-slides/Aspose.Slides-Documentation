---
title: जावास्क्रिप्ट में PowerPoint प्रस्तुतियों में संवेदनशीलता लेबल प्रबंधित करें
linktitle: संवेदनशीलता लेबल
type: docs
weight: 50
url: /hi/nodejs-java/sensitivity-labels/
keywords:
- संवेदनशीलता लेबल
- Microsoft Purview
- Microsoft Information Protection
- MIP मेटाडेटा
- सामग्री मार्किंग
- सूचना सुरक्षा
- दस्तावेज़ शासन
- PowerPoint
- PPTX
- प्रस्तुति सुरक्षा
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java के साथ PowerPoint PPTX प्रस्तुतियों में Microsoft Purview संवेदनशीलता लेबल पढ़ें, जोड़ें, अपडेट करें, हटाएँ और माइग्रेट करें।"
---
## **अवलोकन**

Microsoft Purview संवेदनशीलता लेबल संगठन को दस्तावेज़ वर्गीकृत करने और प्रबंधित करने में मदद करते हैं। स्वचालित प्रस्तुति प्रोसेसिंग के दौरान, किसी एप्लिकेशन को मौजूदा लेबल को बनाए रखने, नीति द्वारा चयनित लेबल लागू करने, उसकी स्थिति अपडेट करने, या पुराने Microsoft Information Protection (MIP) वर्कफ़्लो द्वारा लिखे गए लेबल मेटाडेटा को माइग्रेट करने की आवश्यकता हो सकती है।

Aspose.Slides for Node.js via Java आधुनिक संवेदनशीलता लेबल मेटाडेटा को [Presentation.getSensitivityLabels](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/#getSensitivityLabels) के माध्यम से उजागर करता है। यह मेथड एक [SensitivityLabelCollection](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/sensitivitylabelcollection/) लौटाता है जिसे प्रस्तुति को PPTX के रूप में सहेजने से पहले निरीक्षण और संशोधित किया जा सकता है।

{{% alert color="primary" title="Note" %}}
संवेदनशीलता लेबल पहचानकर्ता और नीति जानकारी आपके Microsoft Purview कॉन्फ़िगरेशन द्वारा निर्धारित की जाती है। अपने वातावरण में लेबल की उपलब्धता और नीति आवश्यकताओं को मेटाडेटा जोड़ने या माइग्रेट करने से पहले सत्यापित करें। [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) मान लेबल से जुड़े सामग्री मार्किंग को वर्णित करते हैं; वे स्वयं स्लाइड्स में दृश्यमान टेक्स्ट या आकृतियां नहीं जोड़ते।
{{% /alert %}}

## **संवेदनशीलता लेबल गुण**

प्रत्येक [SensitivityLabel](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/sensitivitylabel/) में निम्नलिखित मेटाडेटा होता है:

| Methods | Purpose |
| --- | --- |
| [SensitivityLabel.getId](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/sensitivitylabel/#getId) and [SensitivityLabel.setId](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/sensitivitylabel/#setId) | Purview नीति में संवेदनशीलता लेबल पहचानकर्ता को प्राप्त या सेट करें। |
| [SensitivityLabel.getSiteId](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/sensitivitylabel/#getSiteId) and [SensitivityLabel.setSiteId](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/sensitivitylabel/#setSiteId) | लेबल नीति से जुड़ी साइट को प्राप्त या सेट करें। |
| [SensitivityLabel.isEnabled](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/sensitivitylabel/#isEnabled) and [SensitivityLabel.setEnabled](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/sensitivitylabel/#setEnabled) | लेबल सक्षम है या नहीं, इसे प्राप्त या सेट करें। |
| [SensitivityLabel.isRemoved](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/sensitivitylabel/#isRemoved) and [SensitivityLabel.setRemoved](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/sensitivitylabel/#setRemoved) | लेबल हटाया गया है या नहीं, इसे प्राप्त या सेट करें। जब removal state को मेटाडेटा में बनाए रखना हो, तो मान `true` सेट करें। |
| [SensitivityLabel.getAssignmentMethodType](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/sensitivitylabel/#getAssignmentMethodType) and [SensitivityLabel.setAssignmentMethodType](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/sensitivitylabel/#setAssignmentMethodType) | लेबल स्वचालित रूप से या उपयोगकर्ता निर्णय द्वारा लागू किया गया है या नहीं, इसे प्राप्त या सेट करें। |
| [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) | लेबल से जुड़े सामग्री मार्किंग प्रकार प्राप्त करें। |

The [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/sensitivitylabelassignmenttype/) वर्ग परिभाषित करता है कि लेबल कैसे असाइन किया गया था:

- [SensitivityLabelAssignmentType.Standard](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/sensitivitylabelassignmenttype/) डिफ़ॉल्ट या स्वचालित रूप से लागू लेबल को दर्शाता है।
- [SensitivityLabelAssignmentType.Privileged](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/sensitivitylabelassignmenttype/) उपयोगकर्ता निर्णय द्वारा लागू लेबल को दर्शाता है, जिसमें मैन्युअल रूप से लागू, अनुशंसित, और अनिवार्य लेबल शामिल हैं।

The [SensitivityLabelContentType](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/sensitivitylabelcontenttype/) वर्ग लेबल से जुड़े मार्किंग को परिभाषित करता है:

| Value | Meaning |
| --- | --- |
| [SensitivityLabelContentType.None](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/sensitivitylabelcontenttype/) | लेबल डिफ़ॉल्ट या स्वचालित रूप से लागू किया गया था। |
| [SensitivityLabelContentType.Header](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/sensitivitylabelcontenttype/) | हेडर सामग्री मार्किंग लेबल से जुड़ी है। |
| [SensitivityLabelContentType.Footer](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/sensitivitylabelcontenttype/) | फ़ूटर सामग्री मार्किंग लेबल से जुड़ी है। |
| [SensitivityLabelContentType.Watermark](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/sensitivitylabelcontenttype/) | वॉटरमार्क सामग्री मार्किंग लेबल से जुड़ी है। |
| [SensitivityLabelContentType.Encryption](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/sensitivitylabelcontenttype/) | एन्क्रिप्शन सुरक्षा लेबल से जुड़ी है। |

एक लेबल के साथ कई मार्किंग प्रकार जुड़े हो सकते हैं।

## **मौजूदा संवेदनशीलता लेबल सूचीबद्ध करें**

आधुनिक लेबल संग्रह को [Presentation.getSensitivityLabels](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/#getSensitivityLabels) से पढ़ें और उसे गिनें। नीचे दिया गया उदाहरण प्रत्येक लेबल के लिए संग्रहीत हर प्रॉपर्टी और कंटेंट मार्किंग को सूचीबद्ध करता है:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const sensitivityLabels = presentation.getSensitivityLabels();
    const labelCount = sensitivityLabels.getCount();

    for (let labelIndex = 0; labelIndex < labelCount; labelIndex++) {
        const sensitivityLabel = sensitivityLabels.get_Item(labelIndex);
        const labelIdentifier = sensitivityLabel.getId();
        const siteIdentifier = sensitivityLabel.getSiteId();
        const isEnabled = sensitivityLabel.isEnabled();
        const isRemoved = sensitivityLabel.isRemoved();
        const assignmentMethod = sensitivityLabel.getAssignmentMethodType();

        console.log("Label ID: " + labelIdentifier);
        console.log("Site ID: " + siteIdentifier);
        console.log("Enabled: " + isEnabled);
        console.log("Removed: " + isRemoved);
        console.log("Assignment method: " + assignmentMethod);

        const contentMarkTypes = sensitivityLabel.getContentMarkTypes();
        const contentMarkCount = contentMarkTypes.size();

        for (let contentMarkIndex = 0; contentMarkIndex < contentMarkCount; contentMarkIndex++) {
            const contentMarkType = contentMarkTypes.get_Item(contentMarkIndex);
            console.log("Content marking: " + contentMarkType);
        }
    }
} finally {
    presentation.dispose();
}
```

## **सामग्री मार्किंग के साथ संवेदनशीलता लेबल जोड़ें**

[SensitivityLabelCollection.add](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/sensitivitylabelcollection/#add) का उपयोग लेबल पहचानकर्ता, साइट पहचानकर्ता, सक्षम स्थिति और असाइनमेंट मेथड के साथ करें। मेथड नया [SensitivityLabel](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/sensitivitylabel/) लौटाने के बाद, आवश्यक मार्किंग मानों को [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) द्वारा लौटाए गए सूची के माध्यम से जोड़ें।

निम्न उदाहरण फ़ूटर और वॉटरमार्क मार्किंग से जुड़े मैन्युअली चयनित लेबल को जोड़ता है, और फिर परिणाम को PPTX के रूप में सहेजता है:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const sensitivityLabels = presentation.getSensitivityLabels();

    const labelIdentifier = "{11111111-2222-3333-4444-555555555555}";
    const siteIdentifier = java.callStaticMethodSync(
        "java.util.UUID",
        "fromString",
        "aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee");
    const isEnabled = true;
    const assignmentMethod = aspose.slides.SensitivityLabelAssignmentType.Privileged;

    const sensitivityLabel = sensitivityLabels.add(
        labelIdentifier,
        siteIdentifier,
        isEnabled,
        assignmentMethod);

    const contentMarkTypes = sensitivityLabel.getContentMarkTypes();
    contentMarkTypes.addItem(aspose.slides.SensitivityLabelContentType.Footer);
    contentMarkTypes.addItem(aspose.slides.SensitivityLabelContentType.Watermark);

    presentation.save("presentation_with_label.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **संवेदनशीलता लेबल अपडेट करें**

[SensitivityLabel](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/sensitivitylabel/) मान पढ़ने/लिखने योग्य हैं, सिवाय इसके कि [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) द्वारा लौटाई गई सूची को उसकी सूची संचालन द्वारा संशोधित किया जाता है। आवश्यक लेबल को खोजने के बाद, आप उसके पहचानकर्ता, साइट पहचानकर्ता, सक्षम स्थिति, असाइनमेंट मेथड, हटाने की स्थिति, और कंटेंट मार्किंग प्रकार को अपडेट कर सकते हैं। बदलावों को स्थायी करने के लिए प्रस्तुति को सहेजें।

निम्न उदाहरण पहला लेबल की सक्षम स्थिति और असाइनमेंट मेथड को अपडेट करता है:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const sensitivityLabels = presentation.getSensitivityLabels();
    const labelCount = sensitivityLabels.getCount();

    if (labelCount > 0) {
        const sensitivityLabel = sensitivityLabels.get_Item(0);
        sensitivityLabel.setEnabled(true);
        sensitivityLabel.setAssignmentMethodType(
            aspose.slides.SensitivityLabelAssignmentType.Privileged);
    }

    presentation.save("presentation_with_updated_label.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **संवेदनशीलता लेबल को हटाए के रूप में चिह्नित करें**

लेबल हटाए जाने का तथ्य रखने के लिए, लेबल खोजें और [SensitivityLabel.setRemoved](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/sensitivitylabel/#setRemoved) को `true` के साथ कॉल करें। यह लेबल एंट्री को बनाए रखता है जबकि उसकी हटाने की स्थिति को रिकॉर्ड करता है। यदि आप आधुनिक संग्रह से एंट्री हटाना चाहते हैं, तो [SensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/sensitivitylabelcollection/#removeAt) का उपयोग करें; सभी एंट्री को हटाने के लिए [SensitivityLabelCollection.clear](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/sensitivitylabelcollection/#clear) इस्तेमाल करें।

निम्न उदाहरण एक विशिष्ट लेबल को हटाए के रूप में चिह्नित करता है और अपडेटेड प्रस्तुति को सहेजता है:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const sensitivityLabels = presentation.getSensitivityLabels();
    const targetLabelIdentifier = "{11111111-2222-3333-4444-555555555555}";
    const labelCount = sensitivityLabels.getCount();

    for (let labelIndex = 0; labelIndex < labelCount; labelIndex++) {
        const sensitivityLabel = sensitivityLabels.get_Item(labelIndex);
        const labelIdentifier = sensitivityLabel.getId();
        const isTargetLabel = labelIdentifier.toLowerCase() === targetLabelIdentifier.toLowerCase();

        if (isTargetLabel) {
            sensitivityLabel.setRemoved(true);
            break;
        }
    }

    presentation.save("presentation_with_removed_label.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **पुराने MIP संवेदनशीलता लेबल पढ़ें और माइग्रेट करें**

पुराने MIP-आधारित वर्कफ़्लो संवेदनशीलता लेबल मेटाडेटा को आधुनिक लेबल संग्रह के बजाय कस्टम दस्तावेज़ प्रॉपर्टीज़ में संग्रहीत कर सकते हैं। उस मेटाडेटा को [DocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/documentproperties/#getSensitivityLabels) के साथ पढ़ें। यह मेथड लिगेसी कस्टम प्रॉपर्टीज़ को पार्स करता है और [SensitivityLabel](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/sensitivitylabel/) ऑब्जेक्ट्स की एक एरे लौटाता है।

मेटाडेटा को माइग्रेट करने के लिए, प्रत्येक लौटाए गए लेबल को [SensitivityLabelCollection.add](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/sensitivitylabelcollection/#add) के माध्यम से आधुनिक [SensitivityLabelCollection](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/sensitivitylabelcollection/) में जोड़ें। डुप्लिकेट लेबल पहचानकर्ता जोड़ने से अपवाद उठता है, इसलिए उदाहरण प्रत्येक लेबल को कॉपी करने से पहले लक्ष्य संग्रह की जाँच करता है। आप अतिरिक्त मान्यकरण जोड़ सकते हैं ताकि यह सुनिश्चित हो सके कि प्रत्येक लिगेसी लेबल वर्तमान Purview नीति में अभी भी मौजूद है।

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation_with_legacy_labels.pptx");
try {
    const legacySensitivityLabels = presentation.getDocumentProperties().getSensitivityLabels();
    const modernSensitivityLabels = presentation.getSensitivityLabels();

    for (let legacyLabelIndex = 0; legacyLabelIndex < legacySensitivityLabels.length; legacyLabelIndex++) {
        const legacySensitivityLabel = legacySensitivityLabels[legacyLabelIndex];
        const legacyLabelIdentifier = legacySensitivityLabel.getId();
        const modernLabelCount = modernSensitivityLabels.getCount();
        let labelAlreadyExists = false;

        for (let modernLabelIndex = 0; modernLabelIndex < modernLabelCount; modernLabelIndex++) {
            const modernSensitivityLabel = modernSensitivityLabels.get_Item(modernLabelIndex);
            const modernLabelIdentifier = modernSensitivityLabel.getId();

            labelAlreadyExists =
                modernLabelIdentifier.toLowerCase() === legacyLabelIdentifier.toLowerCase();

            if (labelAlreadyExists) {
                break;
            }
        }

        if (!labelAlreadyExists) {
            modernSensitivityLabels.add(legacySensitivityLabel);
        }
    }

    presentation.save("presentation_with_modern_labels.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

माइग्रेशन पार्स किए गए लेबल ऑब्जेक्ट्स को आधुनिक संग्रह में कॉपी करता है। यह सभी कस्टम दस्तावेज़ प्रॉपर्टीज़ को साफ़ करने की आवश्यकता नहीं रखता, इसलिए असंबंधित दस्तावेज़ मेटाडेटा बना रहता है। आधुनिक लेबल मेटाडेटा को PPTX फ़ाइल में लिखने के लिए [Presentation.save](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/#save) को [SaveFormat.Pptx](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/saveformat/) के साथ इस्तेमाल करें।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या कंटेंट मार्किंग टाइप जोड़ने से स्लाइड्स पर दृश्यमान हेडर, फ़ूटर या वॉटरमार्क बनता है?**

नहीं। [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) द्वारा लौटाई गई सूची में जोड़े गए मान संवेदनशीलता लेबल से जुड़े मार्किंग का वर्णन करते हैं। वे प्रस्तुति में दृश्यमान टेक्स्ट या आकृतियां नहीं बनाते। यदि आपके वर्कफ़्लो को उन मार्किंग को रेंडर करना आवश्यक है, तो संबंधित स्लाइड सामग्री को अलग से जोड़ें।

**लेबल को हटाए के रूप में चिह्नित करने और संग्रह से हटाने में क्या अंतर है?**

[SensitivityLabel.setRemoved](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/sensitivitylabel/#setRemoved) को `true` के साथ कॉल करने से लेबल एंट्री बनी रहती है और उसकी हटाने की स्थिति रिकॉर्ड होती है। [SensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/sensitivitylabelcollection/#removeAt) को कॉल करने से एंट्री आधुनिक संग्रह से हट जाती है। वह ऑपरेशन चुनें जो आपके संगठन की मेटाडेटा रिटेंशन आवश्यकताओं के अनुरूप हो।

**क्या प्रस्तुति दोनों लिगेसी MIP मेटाडेटा और आधुनिक संवेदनशीलता लेबल रख सकती है?**

हां। लिगेसी लेबल कस्टम दस्तावेज़ प्रॉपर्टीज़ में बना रह सकते हैं जबकि आधुनिक लेबल [Presentation.getSensitivityLabels](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/#getSensitivityLabels) के माध्यम से उपलब्ध होते हैं। लिगेसी मेटाडेटा को पढ़ने और केवल वैध लेबल को माइग्रेट करने के लिए जो आधुनिक संग्रह में अभी तक मौजूद नहीं हैं, [DocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/documentproperties/#getSensitivityLabels) का उपयोग करें।

**जब समान पहचानकर्ता वाला लेबल एक से अधिक बार जोड़ा जाता है तो क्या होता है?**

जब संग्रह में पहले से वही पहचानकर्ता वाला लेबल मौजूद हो, तो [SensitivityLabelCollection.add](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/sensitivitylabelcollection/#add) अपवाद उठाता है। लेबल जोड़ने या माइग्रेट करने से पहले [SensitivityLabel.getId](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/sensitivitylabel/#getId) द्वारा लौटाए गए मौजूदा मानों की जांच करें।

**अपडेटेड संवेदनशीलता लेबल को संरक्षित रखने के लिए कौन सा आउटपुट फ़ॉर्मेट उपयोग किया जाना चाहिए?**

उपरोक्त उदाहरणों में दिखाए अनुसार, प्रस्तुति को PPTX के रूप में सहेजने के लिए [Presentation.save](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/#save) को [SaveFormat.Pptx](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/saveformat/) के साथ कॉल करें।