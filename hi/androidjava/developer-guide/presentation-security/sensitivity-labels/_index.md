---
title: Android पर PowerPoint प्रस्तुतियों में संवेदनशीलता लेबल प्रबंधन
linktitle: संवेदनशीलता लेबल
type: docs
weight: 50
url: /hi/androidjava/sensitivity-labels/
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
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java का उपयोग करके PowerPoint PPTX प्रस्तुतियों में Microsoft Purview संवेदनशीलता लेबल को पढ़ें, जोड़ें, अपडेट करें, हटाएँ और माइग्रेट करें।"
---
## **सामान्य विवरण**

Microsoft Purview संवेदनशीलता लेबल संगठनों को दस्तावेज़ों को वर्गीकृत करने और उनका प्रबंधन करने में मदद करते हैं। स्वचालित प्रस्तुति प्रोसेसिंग के दौरान, किसी एप्लिकेशन को मौजूदा लेबल को बनाए रखने, नीति द्वारा चयनित लेबल लागू करने, उसकी स्थिति को अपडेट करने, या पुराने Microsoft Information Protection (MIP) वर्कफ़्लो द्वारा लिखे गए लेबल मेटाडेटा को माइग्रेट करने की आवश्यकता हो सकती है।

Aspose.Slides for Android via Java आधुनिक संवेदनशीलता लेबल मेटाडेटा को [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipresentation/#getSensitivityLabels--) के माध्यम से उजागर करता है। यह मेथड एक [ISensitivityLabelCollection](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/isensitivitylabelcollection/) लौटाता है जिसे प्रस्तुति को PPTX के रूप में सहेजने से पहले निरीक्षण और संशोधित किया जा सकता है।

{{% alert color="primary" title="ध्यान दें" %}}
संवेदनशीलता लेबल पहचानकर्ता और नीति जानकारी आपके Microsoft Purview कॉन्फ़िगरेशन द्वारा परिभाषित की जाती है। लेबल उपलब्धता और नीति आवश्यकताओं को अपने वातावरण में सत्यापित करें इससे पहले कि आप मेटाडेटा जोड़ें या माइग्रेट करें। [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) के मान लेबल से जुड़े सामग्री मार्किंग को वर्णित करते हैं; वे स्वयं स्लाइड्स में दृश्यमान टेक्स्ट या आकार नहीं जोड़ते।
{{% /alert %}}

## **संवेदनशीलता लेबल गुणों को समझें**

प्रत्येक [ISensitivityLabel](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/isensitivitylabel/) में निम्नलिखित मेटाडेटा होते हैं:

| विधियाँ | उद्देश्य |
| --- | --- |
| [ISensitivityLabel.getId](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/isensitivitylabel/#getId--) and [ISensitivityLabel.setId](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/isensitivitylabel/#setId-java.lang.String-) | Purview नीति में संवेदनशीलता लेबल पहचानकर्ता प्राप्त या सेट करें। |
| [ISensitivityLabel.getSiteId](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/isensitivitylabel/#getSiteId--) and [ISensitivityLabel.setSiteId](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/isensitivitylabel/#setSiteId-java.util.UUID-) | लेबल नीति से संबंधित साइट प्राप्त या सेट करें। |
| [ISensitivityLabel.isEnabled](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/isensitivitylabel/#isEnabled--) and [ISensitivityLabel.setEnabled](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/isensitivitylabel/#setEnabled-boolean-) | लेबल सक्षम है या नहीं, प्राप्त या सेट करें। |
| [ISensitivityLabel.isRemoved](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/isensitivitylabel/#isRemoved--) and [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) | लेबल हटाया गया है या नहीं, प्राप्त या सेट करें। जब हटाने की स्थिति मेटाडेटा में बरकरार रखनी हो तो मान को `true` सेट करें। |
| [ISensitivityLabel.getAssignmentMethodType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/isensitivitylabel/#getAssignmentMethodType--) and [ISensitivityLabel.setAssignmentMethodType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/isensitivitylabel/#setAssignmentMethodType-int-) | लेबल स्वचालित रूप से लागू किया गया था या उपयोगकर्ता निर्णय के माध्यम से, प्राप्त या सेट करें। |
| [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) | लेबल से जुड़े सामग्री मार्किंग प्रकार प्राप्त करें। |

[SensitivityLabelAssignmentType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/sensitivitylabelassignmenttype/) वर्ग यह परिभाषित करता है कि लेबल कैसे सौंपा गया था:

- [SensitivityLabelAssignmentType.Standard](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/sensitivitylabelassignmenttype/) डिफ़ॉल्ट या स्वचालित रूप से लागू किए गए लेबल को दर्शाता है।
- [SensitivityLabelAssignmentType.Privileged](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/sensitivitylabelassignmenttype/) उपयोगकर्ता निर्णय के माध्यम से लागू किए गए लेबल को दर्शाता है, जिसमें मैन्युअल रूप से लागू, अनुशंसित और अनिवार्य लेबल शामिल हैं।

[SensitivityLabelContentType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) वर्ग लेबल से संबंधित मार्किंग को परिभाषित करता है:

| मान | अर्थ |
| --- | --- |
| [SensitivityLabelContentType.None](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) | लेबल डिफ़ॉल्ट या स्वचालित रूप से लागू किया गया था। |
| [SensitivityLabelContentType.Header](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) | हेडर सामग्री मार्किंग लेबल से जुड़ी है। |
| [SensitivityLabelContentType.Footer](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) | फ़ूटर सामग्री मार्किंग लेबल से जुड़ी है। |
| [SensitivityLabelContentType.Watermark](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) | वॉटरमार्क सामग्री मार्किंग लेबल से जुड़ी है। |
| [SensitivityLabelContentType.Encryption](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) | एन्क्रिप्शन सुरक्षा लेबल से जुड़ी है। |

एक लेबल के साथ कई मार्किंग प्रकार जुड़े हो सकते हैं।

## **मौजूदा संवेदनशीलता लेबलों की सूची बनाएं**

[IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipresentation/#getSensitivityLabels--) से आधुनिक लेबल संग्रह पढ़ें और उसे क्रमबद्ध करें। निम्नलिखित उदाहरण प्रत्येक लेबल के लिए संग्रहीत प्रत्येक गुण और सामग्री मार्किंग को सूचीबद्ध करता है:

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

## **सामग्री मार्किंग के साथ संवेदनशीलता लेबल जोड़ें**

[ISensitivityLabelCollection.add](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/isensitivitylabelcollection/#add-java.lang.String-java.util.UUID-boolean-int-) को लेबल पहचानकर्ता, साइट पहचानकर्ता, सक्षम स्थिति और असाइनमेंट मेथड के साथ उपयोग करें। मेथड नया [ISensitivityLabel](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/isensitivitylabel/) लौटाने के बाद, आवश्यक मार्किंग मानों को [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) द्वारा लौटाई गई सूची के माध्यम से जोड़ें।

निम्नलिखित उदाहरण फ़ूटर और वॉटरमार्क मार्किंग से जुड़े मैन्युअल रूप से चयनित लेबल को जोड़ता है, और फिर परिणाम को PPTX के रूप में सहेजता है:

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

## **संवेदनशीलता लेबल को अपडेट करें**

[ISensitivityLabel](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/isensitivitylabel/) मानों को पढ़ा/लिखा जा सकता है, सिवाय इसके कि [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) द्वारा लौटाई गई सूची को उसकी सूची ऑपरेशन्स के माध्यम से संशोधित किया जाता है। आवश्यक लेबल को खोजने के बाद, आप उसका पहचानकर्ता, साइट पहचानकर्ता, सक्षम स्थिति, असाइनमेंट मेथड, हटाने की स्थिति और सामग्री मार्किंग प्रकार को अपडेट कर सकते हैं। परिवर्तन को लागू करने के लिए प्रस्तुति को सहेजें।

निम्नलिखित उदाहरण पहले लेबल की सक्षम स्थिति और असाइनमेंट मेथड को अपडेट करता है:

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

## **लेबल को हटाए के रूप में चिह्नित करें**

लेबल के हटाए जाने के तथ्य को संरक्षित रखने के लिए, लेबल खोजें और [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) को `true` के साथ कॉल करें। यह लेबल प्रविष्टि को बनाए रखता है जबकि उसकी हटाने की स्थिति को रिकॉर्ड करता है। यदि आप आधुनिक संग्रह से प्रविष्टि को हटाना चाहते हैं, तो [ISensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/isensitivitylabelcollection/#removeAt-int-) का उपयोग करें; सभी प्रविष्टियों को हटाने के लिए [ISensitivityLabelCollection.clear](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/isensitivitylabelcollection/#clear--) का उपयोग करें।

निम्नलिखित उदाहरण एक विशिष्ट लेबल को हटाए के रूप में चिह्नित करता है और अपडेटेड प्रस्तुति को सहेजता है:

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

पुराने MIP-आधारित वर्कफ़्लो संवेदनशीलता लेबल मेटाडेटा को आधुनिक लेबल संग्रह के बजाय कस्टम दस्तावेज़ गुणों में स्टोर कर सकते हैं। उस मेटाडेटा को [IDocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/idocumentproperties/#getSensitivityLabels--) के साथ पढ़ें। यह मेथड लेगेसी कस्टम प्रॉपर्टीज़ को पार्स करता है और [ISensitivityLabel](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/isensitivitylabel/) ऑब्जेक्ट्स की एक एरे लौटाता है।

मेटाडेटा को माइग्रेट करने के लिए, प्रत्येक लौटाए गए लेबल को [ISensitivityLabelCollection.add](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/isensitivitylabelcollection/#add-com.aspose.slides.ISensitivityLabel-) के माध्यम से आधुनिक [ISensitivityLabelCollection](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/isensitivitylabelcollection/) में जोड़ें। डुप्लिकेट लेबल पहचानकर्ता जोड़ने पर अपवाद उत्पन्न होता है, इसलिए उदाहरण प्रत्येक लेबल को कॉपी करने से पहले गंतव्य संग्रह की जाँच करता है। आप अतिरिक्त सत्यापन जोड़ सकते हैं यह पुष्टि करने के लिए कि प्रत्येक लेगेसी लेबल वर्तमान Purview नीति में अभी भी मौजूद है।

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

माइग्रेशन पार्स किए गए लेबल ऑब्जेक्ट्स को आधुनिक संग्रह में कॉपी करता है। यह सभी कस्टम दस्तावेज़ गुणों को साफ़ करने की आवश्यकता नहीं रखता, इसलिए असंबंधित दस्तावेज़ मेटाडेटा अपरिवर्तित रहता है। आधुनिक लेबल मेटाडेटा को PPTX फ़ाइल में लिखने के लिए [IPresentation.save](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipresentation/#save-java.lang.String-int-) को [SaveFormat.Pptx](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/saveformat/) के साथ उपयोग करें।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या सामग्री मार्किंग प्रकार जोड़ने से स्लाइड्स पर दृश्यमान हेडर, फ़ूटर या वॉटरमार्क बनता है?**

नहीं। [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) द्वारा लौटाई गई सूची में जोड़े गए मान लेबल से जुड़े मार्किंग को वर्णित करते हैं। वे प्रस्तुति में दृश्यमान पाठ या आकार नहीं बनाते। यदि आपके वर्कफ़्लो को इन मार्किंग को रेंडर करना आवश्यक है तो संबंधित स्लाइड सामग्री को अलग से जोड़ें।

**लेबल को हटाए के रूप में चिह्नित करने और उसे संग्रह से हटाने में क्या अंतर है?**

[ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) को `true` के साथ कॉल करने से लेबल प्रविष्टि बनी रहती है और उसकी हटाने की स्थिति रिकॉर्ड होती है। [ISensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/isensitivitylabelcollection/#removeAt-int-) को कॉल करने से आधुनिक संग्रह से प्रविष्टि हट जाती है। वह ऑपरेशन चुनें जो आपके संगठन की मेटाडेटा रखरखाव आवश्यकताओं के अनुकूल हो।

**क्या एक प्रस्तुति में लेगेसी MIP मेटाडेटा और आधुनिक संवेदनशीलता लेबल दोनों हो सकते हैं?**

हां। लेगेसी लेबल कस्टम दस्तावेज़ गुणों में रह सकते हैं जबकि आधुनिक लेबल [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipresentation/#getSensitivityLabels--) के माध्यम से उपलब्ध हैं। लेगेसी मेटाडेटा को पढ़ने के लिए [IDocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/idocumentproperties/#getSensitivityLabels--) का उपयोग करें और केवल वैध लेबलों को माइग्रेट करें जो पहले से आधुनिक संग्रह में मौजूद नहीं हैं।

**जब समान पहचानकर्ता वाला लेबल एक से अधिक बार जोड़ा जाता है तो क्या होता है?**

[ISensitivityLabelCollection.add](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/isensitivitylabelcollection/#add-java.lang.String-java.util.UUID-boolean-int-) तब अपवाद उठाता है जब संग्रह में पहले से समान पहचानकर्ता वाला लेबल मौजूद हो। लेबल जोड़ने या माइग्रेट करने से पहले [ISensitivityLabel.getId](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/isensitivitylabel/#getId--) द्वारा लौटाए गए मौजूदा मानों की जाँच करें।

**अपडेटेड संवेदनशीलता लेबलों को संरक्षित रखने के लिए कौनसा आउटपुट फ़ॉर्मेट उपयोग किया जाना चाहिए?**

उपरोक्त उदाहरणों के अनुसार प्रस्तुति को PPTX के रूप में सहेजने के लिए [IPresentation.save](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipresentation/#save-java.lang.String-int-) को [SaveFormat.Pptx](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/saveformat/) के साथ कॉल करें।