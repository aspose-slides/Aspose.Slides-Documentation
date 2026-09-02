---
title: PowerPoint प्रस्तुतियों में संवेदनशीलता लेबल प्रबंधन Java में
linktitle: संवेदनशीलता लेबल
type: docs
weight: 50
url: /hi/java/sensitivity-labels/
keywords:
- संवेदनशीलता लेबल
- Microsoft Purview
- Microsoft सूचना सुरक्षा
- MIP मेटाडाटा
- सामग्री चिह्नन
- सूचना सुरक्षा
- दस्तावेज़ शासन
- PowerPoint
- PPTX
- प्रस्तुति सुरक्षा
- Java
- Aspose.Slides
description: "Aspose.Slides for Java के साथ PowerPoint PPTX प्रस्तुतियों में Microsoft Purview संवेदनशीलता लेबल को पढ़ें, जोड़ें, अद्यतन करें, हटाएँ और माइग्रेट करें।"
---
## **अवलोकन**

Microsoft Purview संवेदनशीलता लेबल संगठनों को दस्तावेज़ों को वर्गीकृत करने और उनका शासन करने में मदद करते हैं। स्वचालित प्रस्तुति प्रसंस्करण के दौरान, किसी एप्लिकेशन को मौजूदा लेबल को संरक्षित करने, नीति द्वारा चयनित लेबल लागू करने, उसकी स्थिति को अद्यतन करने, या पुराने Microsoft Information Protection (MIP) वर्कफ़्लो द्वारा लिखे गए लेबल मेटाडेटा को माइग्रेट करने की आवश्यकता हो सकती है।

Aspose.Slides आधुनिक संवेदनशीलता लेबल मेटाडेटा को [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipresentation/#getSensitivityLabels--) के माध्यम से उजागर करता है। यह विधि एक [ISensitivityLabelCollection](https://reference.aspose.com/slides/hi/java/com.aspose.slides/isensitivitylabelcollection/) लौटाती है जिसे प्रस्तुति को PPTX के रूप में सहेजने से पहले निरीक्षण और संशोधित किया जा सकता है।

{{% alert color="primary" title="नोट" %}}
संवेदनशीलता लेबल पहचानकर्ता और नीति सूचना आपके Microsoft Purview कॉन्फ़िगरेशन द्वारा निर्धारित किए जाते हैं। मेटाडेटा जोड़ने या माइग्रेट करने से पहले अपने पर्यावरण में लेबल उपलब्धता और नीति आवश्यकताओं को सत्यापित करें। [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/hi/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) मान एक लेबल से जुड़े सामग्री चिह्नों का वर्णन करते हैं; वे स्वयं स्लाइड्स में कोई दृश्यमान टेक्स्ट या आकार नहीं जोड़ते।
{{% /alert %}}

## **संवेदनशीलता लेबल गुणों को समझें**

प्रत्येक [ISensitivityLabel](https://reference.aspose.com/slides/hi/java/com.aspose.slides/isensitivitylabel/) में निम्न मेटाडेटा शामिल है:

| विधियां | उद्देश्य |
| --- | --- |
| [ISensitivityLabel.getId](https://reference.aspose.com/slides/hi/java/com.aspose.slides/isensitivitylabel/#getId--) and [ISensitivityLabel.setId](https://reference.aspose.com/slides/hi/java/com.aspose.slides/isensitivitylabel/#setId-java.lang.String-) | Purview नीति में संवेदनशीलता लेबल पहचानकर्ता को प्राप्त या सेट करता है। |
| [ISensitivityLabel.getSiteId](https://reference.aspose.com/slides/hi/java/com.aspose.slides/isensitivitylabel/#getSiteId--) and [ISensitivityLabel.setSiteId](https://reference.aspose.com/slides/hi/java/com.aspose.slides/isensitivitylabel/#setSiteId-java.util.UUID-) | लेबल नीति से जुड़ी साइट को प्राप्त या सेट करता है। |
| [ISensitivityLabel.isEnabled](https://reference.aspose.com/slides/hi/java/com.aspose.slides/isensitivitylabel/#isEnabled--) and [ISensitivityLabel.setEnabled](https://reference.aspose.com/slides/hi/java/com.aspose.slides/isensitivitylabel/#setEnabled-boolean-) | लेबल सक्षम है या नहीं, इसे प्राप्त या सेट करता है। |
| [ISensitivityLabel.isRemoved](https://reference.aspose.com/slides/hi/java/com.aspose.slides/isensitivitylabel/#isRemoved--) and [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/hi/java/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) | लेबल हटाया गया है या नहीं, इसे प्राप्त या सेट करता है। जब हटाने की स्थिति मेटाडेटा में संरक्षित रहनी हो, तो मान `true` सेट करें। |
| [ISensitivityLabel.getAssignmentMethodType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/isensitivitylabel/#getAssignmentMethodType--) and [ISensitivityLabel.setAssignmentMethodType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/isensitivitylabel/#setAssignmentMethodType-int-) | लेबल स्वचालित रूप से लागू किया गया था या उपयोगकर्ता के निर्णय से, इसे प्राप्त या सेट करता है। |
| [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/hi/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) | लेबल से जुड़े सामग्री चिह्न प्रकारों को प्राप्त करता है। |

[SensitivityLabelAssignmentType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/sensitivitylabelassignmenttype/) वर्ग यह परिभाषित करता है कि लेबल कैसे असाइन किया गया था:

- [SensitivityLabelAssignmentType.Standard](https://reference.aspose.com/slides/hi/java/com.aspose.slides/sensitivitylabelassignmenttype/) एक डिफ़ॉल्ट या स्वचालित रूप से लागू लेबल को दर्शाता है।
- [SensitivityLabelAssignmentType.Privileged](https://reference.aspose.com/slides/hi/java/com.aspose.slides/sensitivitylabelassignmenttype/) एक लेबल को दर्शाता है जो उपयोगकर्ता के निर्णय से लागू किया गया है, जिसमें मैन्युअल, सिफ़ारिशी और अनिवार्य लेबल शामिल हैं।

[SensitivityLabelContentType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/sensitivitylabelcontenttype/) वर्ग यह परिभाषित करता है कि लेबल से कौन सा चिह्न जुड़ा है:

| मान | अर्थ |
| --- | --- |
| [SensitivityLabelContentType.None](https://reference.aspose.com/slides/hi/java/com.aspose.slides/sensitivitylabelcontenttype/) | लेबल डिफ़ॉल्ट या स्वचालित रूप से लागू किया गया था। |
| [SensitivityLabelContentType.Header](https://reference.aspose.com/slides/hi/java/com.aspose.slides/sensitivitylabelcontenttype/) | हेडर सामग्री चिह्न लेबल से जुड़ा है। |
| [SensitivityLabelContentType.Footer](https://reference.aspose.com/slides/hi/java/com.aspose.slides/sensitivitylabelcontenttype/) | फ़ूटर सामग्री चिह्न लेबल से जुड़ा है। |
| [SensitivityLabelContentType.Watermark](https://reference.aspose.com/slides/hi/java/com.aspose.slides/sensitivitylabelcontenttype/) | वॉटरमार्क सामग्री चिह्न लेबल से जुड़ा है। |
| [SensitivityLabelContentType.Encryption](https://reference.aspose.com/slides/hi/java/com.aspose.slides/sensitivitylabelcontenttype/) | एन्क्रिप्शन संरक्षण लेबल से जुड़ा है। |

एक लेबल के साथ कई चिह्न प्रकार जुड़े हो सकते हैं।

## **मौजूदा संवेदनशीलता लेबल सूचीबद्ध करें**

[IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipresentation/#getSensitivityLabels--) से आधुनिक लेबल संग्रह को पढ़ें और उसे क्रमबद्ध करें। नीचे दिया गया उदाहरण प्रत्येक लेबल के लिए संग्रहीत प्रत्येक गुण और सामग्री चिह्न को सूचीबद्ध करता है:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISensitivityLabelCollection sensitivityLabels = presentation.getSensitivityLabels();

    for (ISensitivityLabel sensitivityLabel : sensitivityLabels) {
        System.out.println("Label ID: " + sensitivityLabel.getId());
        System.out.println("Site ID: " + sensitivityLabel.getSiteId());
        System.out.println("Enabled: " + sensitivityLabel.isEnabled());
        System.out.println("Removed: " + sensitivityLabel.isRemoved());
        System.out.println("Assignment method: " + sensitivityLabel.getAssignmentMethodType());

        for (Integer contentMarkType : sensitivityLabel.getContentMarkTypes()) {
            System.out.println("Content marking: " + contentMarkType);
        }
    }
} finally {
    presentation.dispose();
}
```

## **सामग्री चिह्न के साथ संवेदनशीलता लेबल जोड़ें**

लेबल पहचानकर्ता, साइट पहचानकर्ता, सक्षम स्थिति और असाइनमेंट विधि के साथ [ISensitivityLabelCollection.add](https://reference.aspose.com/slides/hi/java/com.aspose.slides/isensitivitylabelcollection/#add-java.lang.String-java.util.UUID-boolean-int-) का उपयोग करें। विधि नई [ISensitivityLabel](https://reference.aspose.com/slides/hi/java/com.aspose.slides/isensitivitylabel/) लौटाने के बाद, आवश्यक चिह्न मानों को [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/hi/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) द्वारा लौटाए गए सूची के माध्यम से जोड़ें।

निचे दिया गया उदाहरण फ़ूटर और वॉटरमार्क चिह्नों के साथ मैन्युअल रूप से चयनित लेबल जोड़ता है और फिर परिणाम को PPTX के रूप में सहेजता है:

```java
import com.aspose.slides.*;
import java.util.UUID;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISensitivityLabelCollection sensitivityLabels = presentation.getSensitivityLabels();

    String labelIdentifier = "{11111111-2222-3333-4444-555555555555}";
    UUID siteIdentifier = UUID.fromString("aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee");
    boolean isEnabled = true;
    int assignmentMethod = SensitivityLabelAssignmentType.Privileged;

    ISensitivityLabel sensitivityLabel = sensitivityLabels.add(
            labelIdentifier,
            siteIdentifier,
            isEnabled,
            assignmentMethod);

    sensitivityLabel.getContentMarkTypes().addItem(SensitivityLabelContentType.Footer);
    sensitivityLabel.getContentMarkTypes().addItem(SensitivityLabelContentType.Watermark);

    presentation.save("presentation_with_label.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **संवेदनशीलता लेबल को अद्यतन करें**

[ISensitivityLabel](https://reference.aspose.com/slides/hi/java/com.aspose.slides/isensitivitylabel/) के मान पढ़ने/लिखने योग्य हैं, सिवाय इसके कि [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/hi/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) द्वारा लौटाई गई सूची को उसकी सूची संचालन के द्वारा बदला जाता है। आवश्यक लेबल को खोजने के बाद, आप उसकी पहचानकर्ता, साइट पहचानकर्ता, सक्षम स्थिति, असाइनमेंट विधि, हटाने की स्थिति और सामग्री चिह्न प्रकारों को अद्यतन कर सकते हैं। परिवर्तन को स्थायी बनाने के लिए प्रस्तुति को सहेजें।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISensitivityLabelCollection sensitivityLabels = presentation.getSensitivityLabels();

    if (sensitivityLabels.getCount() > 0) {
        ISensitivityLabel sensitivityLabel = sensitivityLabels.get_Item(0);
        sensitivityLabel.setEnabled(true);
        sensitivityLabel.setAssignmentMethodType(SensitivityLabelAssignmentType.Privileged);
    }

    presentation.save("presentation_with_updated_label.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **संवेदनशीलता लेबल को हटाया हुआ चिह्नित करें**

लेबल हटाए जाने की तथ्य को संरक्षित करने के लिये, लेबल को खोजें और [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/hi/java/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) को `true` के साथ कॉल करें। यह लेबल प्रविष्टि को बनाए रखता है जबकि उसकी हटाने की स्थिति को रिकॉर्ड करता है। यदि आप आधुनिक संग्रह से प्रविष्टि हटाना चाहते हैं, तो [ISensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/hi/java/com.aspose.slides/isensitivitylabelcollection/#removeAt-int-) का उपयोग करें; सभी प्रविष्टियों को हटाने के लिए [ISensitivityLabelCollection.clear](https://reference.aspose.com/slides/hi/java/com.aspose.slides/isensitivitylabelcollection/#clear--) का उपयोग करें।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISensitivityLabelCollection sensitivityLabels = presentation.getSensitivityLabels();
    String targetLabelIdentifier = "{11111111-2222-3333-4444-555555555555}";

    for (ISensitivityLabel sensitivityLabel : sensitivityLabels) {
        boolean isTargetLabel = sensitivityLabel.getId().equalsIgnoreCase(targetLabelIdentifier);

        if (isTargetLabel) {
            sensitivityLabel.setRemoved(true);
            break;
        }
    }

    presentation.save("presentation_with_removed_label.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **पुराने MIP संवेदनशीलता लेबल पढ़ें और माइग्रेट करें**

पुराने MIP‑आधारित वर्कफ़्लो आधुनिक लेबल संग्रह के बजाय कस्टम दस्तावेज़ गुणों में संवेदनशीलता लेबल मेटाडेटा संग्रहीत कर सकते हैं। उस मेटाडेटा को [IDocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/hi/java/com.aspose.slides/idocumentproperties/#getSensitivityLabels--) से पढ़ें। यह विधि पुराने कस्टम गुणों को पार्स करती है और [ISensitivityLabel](https://reference.aspose.com/slides/hi/java/com.aspose.slides/isensitivitylabel/) वस्तुओं की एक सरणी लौटाती है।

मेटाडेटा को माइग्रेट करने के लिये, प्रत्येक लौटाए गए लेबल को [ISensitivityLabelCollection.add](https://reference.aspose.com/slides/hi/java/com.aspose.slides/isensitivitylabelcollection/#add-com.aspose.slides.ISensitivityLabel-) के माध्यम से आधुनिक [ISensitivityLabelCollection](https://reference.aspose.com/slides/hi/java/com.aspose.slides/isensitivitylabelcollection/) में जोड़ें। दोहराव वाले लेबल पहचानकर्ता जोड़ने पर अपवाद उत्पन्न होता है, इसलिए उदाहरण प्रत्येक लेबल को कॉपी करने से पहले लक्ष्य संग्रह की जाँच करता है। आप अतिरिक्त सत्यापन जोड़ सकते हैं जिससे यह पुष्टि हो सके कि प्रत्येक पुराना लेबल वर्तमान Purview नीति में अभी भी मौजूद है।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation_with_legacy_labels.pptx");
try {
    ISensitivityLabel[] legacySensitivityLabels = presentation.getDocumentProperties().getSensitivityLabels();
    ISensitivityLabelCollection modernSensitivityLabels = presentation.getSensitivityLabels();

    for (ISensitivityLabel legacySensitivityLabel : legacySensitivityLabels) {
        boolean labelAlreadyExists = false;

        for (ISensitivityLabel modernSensitivityLabel : modernSensitivityLabels) {
            labelAlreadyExists = modernSensitivityLabel.getId().equalsIgnoreCase(
                    legacySensitivityLabel.getId());

            if (labelAlreadyExists) {
                break;
            }
        }

        if (!labelAlreadyExists) {
            modernSensitivityLabels.add(legacySensitivityLabel);
        }
    }

    presentation.save("presentation_with_modern_labels.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

माइग्रेशन पार्स किए गए लेबल वस्तुओं को आधुनिक संग्रह में कॉपी करता है। सभी कस्टम दस्तावेज़ गुणों को साफ़ करने की आवश्यकता नहीं होती, इसलिए अप्रासंगिक दस्तावेज़ मेटाडेटा वैसा ही रहता है। आधुनिक लेबल मेटाडेटा को PPTX फ़ाइल में लिखने के लिये [IPresentation.save](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipresentation/#save-java.lang.String-int-) को [SaveFormat.Pptx](https://reference.aspose.com/slides/hi/java/com.aspose.slides/saveformat/) के साथ उपयोग करें।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या सामग्री चिह्न प्रकार जोड़ने से स्लाइड्स पर दृश्यमान हेडर, फ़ूटर या वॉटरमार्क बनता है?**

नहीं। [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/hi/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) द्वारा सूची में जोड़े गए मान लेबल से जुड़े चिह्नों का वर्णन करते हैं। वे प्रस्तुति में कोई दृश्यमान टेक्स्ट या आकृति नहीं बनाते। यदि आपके वर्कफ़्लो को इन चिह्नों को रेंडर करना है, तो स्लाइड सामग्री को अलग से जोड़ें।

**लेबल को हटाया हुआ चिह्नित करने और संग्रह से उसे हटाने में क्या अंतर है?**

[ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/hi/java/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) को `true` के साथ कॉल करने से लेबल प्रविष्टि बनी रहती है और उसकी हटाने की स्थिति रिकॉर्ड होती है। [ISensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/hi/java/com.aspose.slides/isensitivitylabelcollection/#removeAt-int-) को कॉल करने से लेबल आधुनिक संग्रह से पूरी तरह हट जाता है। अपनी संगठन की मेटाडेटा प्रतिधारण आवश्यकताओं के अनुसार उपयुक्त कार्य चुनें।

**क्या एक प्रस्तुति में पुराने MIP मेटाडेटा और आधुनिक संवेदनशीलता लेबल दोनों हो सकते हैं?**

हां। पुराने लेबल कस्टम दस्तावेज़ गुणों में रह सकते हैं जबकि आधुनिक लेबल [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipresentation/#getSensitivityLabels--) के माध्यम से उपलब्ध होते हैं। पुराने मेटाडेटा को पढ़ने और केवल वैध लेबलों को माइग्रेट करने के लिये [IDocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/hi/java/com.aspose.slides/idocumentproperties/#getSensitivityLabels--) का उपयोग करें, जिससे दोहराव वाले लेबल नहीं जोड़े जाएँ।

**एक ही पहचानकर्ता वाले लेबल को कई बार जोड़ने पर क्या होता है?**

[ISensitivityLabelCollection.add](https://reference.aspose.com/slides/hi/java/com.aspose.slides/isensitivitylabelcollection/#add-java.lang.String-java.util.UUID-boolean-int-) संग्रह में पहले से मौजूद समान पहचानकर्ता वाले लेबल की स्थिति में अपवाद उठाता है। लेबल जोड़ने या माइग्रेट करने से पहले [ISensitivityLabel.getId](https://reference.aspose.com/slides/hi/java/com.aspose.slides/isensitivitylabel/#getId--) द्वारा लौटाए गए मौजूदा मानों की जाँच करें।

**अपडेट किए गए संवेदनशीलता लेबल को संरक्षित रखने के लिये किस आउटपुट फ़ॉर्मेट का प्रयोग करना चाहिए?**

प्रस्तुति को PPTX के रूप में सहेजें, अर्थात् [IPresentation.save](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipresentation/#save-java.lang.String-int-) को [SaveFormat.Pptx](https://reference.aspose.com/slides/hi/java/com.aspose.slides/saveformat/) के साथ कॉल करें, जैसा कि ऊपर के उदाहरणों में दिखाया गया है।