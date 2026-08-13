---
title: PowerPoint प्रस्तुतियों में Java के साथ संवेदनशीलता लेबल प्रबंधित करें
linktitle: संवेदनशीलता लेबल
type: docs
weight: 50
url: /hi/java/sensitivity-labels/
keywords:
- संवेदनशीलता लेबल
- Microsoft Purview
- Microsoft Information Protection
- MIP मेटाडाटा
- सामग्री मार्किंग
- सूचना सुरक्षा
- दस्तावेज़ शासन
- PowerPoint
- PPTX
- प्रस्तुति सुरक्षा
- Java
- Aspose.Slides
description: "Aspose.Slides for Java के साथ PowerPoint PPTX प्रस्तुतियों में Microsoft Purview संवेदनशीलता लेबल पढ़ें, जोड़ें, अपडेट करें, हटाएँ और माइग्रेट करें।"
---
## **परिचय**

Microsoft Purview संवेदनशीलता लेबल संगठनों को दस्तावेज़ों को वर्गीकृत करने और उनका प्रबंधन करने में सहायता करते हैं। स्वचालित प्रस्तुति प्रसंस्करण के दौरान, किसी अनुप्रयोग को मौजूदा लेबल को बरकरार रखना, नीति द्वारा चयनित लेबल लागू करना, उसकी स्थिति को अद्यतन करना, या पुराने Microsoft Information Protection (MIP) कार्यप्रवाह द्वारा लिखे गए लेबल मेटाडाटा को माइग्रेट करना आवश्यक हो सकता है।

Aspose.Slides आधुनिक संवेदनशीलता लेबल मेटाडाटा को [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipresentation/#getSensitivityLabels--) के माध्यम से उजागर करता है। यह विधि एक [ISensitivityLabelCollection](https://reference.aspose.com/slides/hi/java/com.aspose.slides/isensitivitylabelcollection/) लौटाती है जिसे प्रस्तुति को PPTX के रूप में सहेजने से पहले जांचा और संशोधित किया जा सकता है।

{{% alert color="info" title="Note" %}}
संवेदनशीलता लेबल पहचानकर्ता और नीति जानकारी आपके Microsoft Purview विन्यास द्वारा परिभाषित की जाती है। मेटाडाटा जोड़ने या माइग्रेट करने से पहले अपने पर्यावरण में लेबल की उपलब्धता और नीति आवश्यकताओं को सत्यापित करें। `ISensitivityLabel.getContentMarkTypes` मान लेबल से संबंधित कंटेंट मार्किंग को वर्णित करते हैं; वे स्वयं स्लाइडों में दृश्यमान पाठ या आकार नहीं जोड़ते हैं।
{{% /alert %}}

## **संवेदनशीलता लेबल गुणों को समझें**

हर [ISensitivityLabel](https://reference.aspose.com/slides/hi/java/com.aspose.slides/isensitivitylabel/) में निम्नलिखित मेटाडाटा होता है:

| विधियाँ | उद्देश्य |
| --- | --- |
| [ISensitivityLabel.getId](https://reference.aspose.com/slides/hi/java/com.aspose.slides/isensitivitylabel/#getId--) और [ISensitivityLabel.setId](https://reference.aspose.com/slides/hi/java/com.aspose.slides/isensitivitylabel/#setId-java.lang.String-) | Purview नीति में संवेदनशीलता लेबल पहचानकर्ता को प्राप्त या निर्धारित करता है। |
| [ISensitivityLabel.getSiteId](https://reference.aspose.com/slides/hi/java/com.aspose.slides/isensitivitylabel/#getSiteId--) और [ISensitivityLabel.setSiteId](https://reference.aspose.com/slides/hi/java/com.aspose.slides/isensitivitylabel/#setSiteId-java.util.UUID-) | लेबल नीति से जुड़ी साइट को प्राप्त या निर्धारित करता है। |
| [ISensitivityLabel.isEnabled](https://reference.aspose.com/slides/hi/java/com.aspose.slides/isensitivitylabel/#isEnabled--) और [ISensitivityLabel.setEnabled](https://reference.aspose.com/slides/hi/java/com.aspose.slides/isensitivitylabel/#setEnabled-boolean-) | लेबल सक्षम है या नहीं, इसे प्राप्त या निर्धारित करता है। |
| [ISensitivityLabel.isRemoved](https://reference.aspose.com/slides/hi/java/com.aspose.slides/isensitivitylabel/#isRemoved--) और [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/hi/java/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) | लेबल हटाया गया है या नहीं, इसे प्राप्त या निर्धारित करता है। जब हटाने की स्थिति मेटाडाटा में बनाए रखनी हो तो मान को `true` सेट करें। |
| [ISensitivityLabel.getAssignmentMethodType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/isensitivitylabel/#getAssignmentMethodType--) और [ISensitivityLabel.setAssignmentMethodType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/isensitivitylabel/#setAssignmentMethodType-int-) | लेबल स्वचालित रूप से या उपयोगकर्ता निर्णय द्वारा लागू किया गया था, इसे प्राप्त या निर्धारित करता है। |
| [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/hi/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) | लेबल से जुड़े कंटेंट मार्किंग प्रकारों को प्राप्त करता है। |

`SensitivityLabelAssignmentType` वर्ग यह निर्धारित करता है कि लेबल कैसे सौंपा गया:

- `SensitivityLabelAssignmentType.Standard` डिफ़ॉल्ट या स्वचालित रूप से लागू किए गए लेबल को दर्शाता है।
- `SensitivityLabelAssignmentType.Privileged` उपयोगकर्ता निर्णय द्वारा लागू किए गए लेबल को दर्शाता है, जिसमें मैन्युअल रूप से लागू, अनुशंसित और अनिवार्य लेबल शामिल हैं।

`SensitivityLabelContentType` वर्ग लेबल से जुड़ी मार्किंग को परिभाषित करता है:

| मान | अर्थ |
| --- | --- |
| [SensitivityLabelContentType.None](https://reference.aspose.com/slides/hi/java/com.aspose.slides/sensitivitylabelcontenttype/) | लेबल डिफ़ॉल्ट रूप से या स्वचालित रूप से लागू किया गया था। |
| [SensitivityLabelContentType.Header](https://reference.aspose.com/slides/hi/java/com.aspose.slides/sensitivitylabelcontenttype/) | हेडर कंटेंट मार्किंग लेबल से जुड़ी है। |
| [SensitivityLabelContentType.Footer](https://reference.aspose.com/slides/hi/java/com.aspose.slides/sensitivitylabelcontenttype/) | फूटर कंटेंट मार्किंग लेबल से जुड़ी है। |
| [SensitivityLabelContentType.Watermark](https://reference.aspose.com/slides/hi/java/com.aspose.slides/sensitivitylabelcontenttype/) | वॉटरमार्क कंटेंट मार्किंग लेबल से जुड़ी है। |
| [SensitivityLabelContentType.Encryption](https://reference.aspose.com/slides/hi/java/com.aspose.slides/sensitivitylabelcontenttype/) | एन्क्रिप्शन सुरक्षा लेबल से जुड़ी है। |

एक लेबल के साथ कई मार्किंग प्रकार जुड़े हो सकते हैं।

## **मौजूदा संवेदनशीलता लेबलों की सूची**

[IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipresentation/#getSensitivityLabels--) से आधुनिक लेबल संग्रह को पढ़ें और उसे क्रमबद्ध करें। निम्न उदाहरण प्रत्येक लेबल के लिए सभी गुण और कंटेंट मार्किंग को सूचीबद्ध करता है:

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

लेबल पहचानकर्ता, साइट पहचानकर्ता, सक्षम स्थिति और असाइनमेंट विधि के साथ `[ISensitivityLabelCollection.add](https://reference.aspose.com/slides/hi/java/com.aspose.slides/isensitivitylabelcollection/#add-java.lang.String-java.util.UUID-boolean-int-)` का उपयोग करें। विधि नया `[ISensitivityLabel](https://reference.aspose.com/slides/hi/java/com.aspose.slides/isensitivitylabel/)` लौटाने के बाद, आवश्यक मार्किंग मानों को `[ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/hi/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--)` द्वारा वापस मिली सूची में जोड़ें।

निम्न उदाहरण फूटर और वॉटरमार्क मार्किंग के साथ मैन्युअल रूप से चयनित लेबल जोड़ता है, और फिर परिणाम को PPTX के रूप में सहेजता है:

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

`[ISensitivityLabel](https://reference.aspose.com/slides/hi/java/com.aspose.slides/isensitivitylabel/)` मान पढ़ने/लिखने योग्य हैं, सिवाय इसके कि `[ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/hi/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--)` द्वारा लौटाई गई सूची को उसके सूची संचालन के माध्यम से संशोधित किया जाता है। आवश्यक लेबल मिलने पर आप उसकी पहचानकर्ता, साइट पहचानकर्ता, सक्षम स्थिति, असाइनमेंट विधि, हटाने की स्थिति और कंटेंट मार्किंग प्रकारों को अद्यतन कर सकते हैं। परिवर्तन को स्थायी बनाने के लिए प्रस्तुति को सहेजें।

निम्न उदाहरण प्रथम लेबल की सक्षम स्थिति और असाइनमेंट विधि को अद्यतन करता है:

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

## **संवेदनशीलता लेबल को हटाए गए के रूप में चिह्नित करें**

लेबल को हटाए गए के रूप में चिन्हित रखने के लिये, लेबल खोजें और `ISensitivityLabel.setRemoved` को `true` के साथ कॉल करें। यह लेबल प्रविष्टि को बनाए रखते हुए उसकी हटाई गई स्थिति को रिकॉर्ड करता है। यदि आप आधुनिक संग्रह से प्रविष्टि को पूरी तरह हटाना चाहते हैं, तो `[ISensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/hi/java/com.aspose.slides/isensitivitylabelcollection/#removeAt-int-)` का उपयोग करें; सभी प्रविष्टियों को हटाने के लिये `[ISensitivityLabelCollection.clear](https://reference.aspose.com/slides/hi/java/com.aspose.slides/isensitivitylabelcollection/#clear--)` का उपयोग करें।

निम्न उदाहरण एक विशिष्ट लेबल को हटाए गए के रूप में चिह्नित करता है और अद्यतन प्रस्तुति को सहेजता है:

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

## **पुराने MIP संवेदनशीलता लेबलों को पढ़ें और माइग्रेट करें**

पुराने MIP‑आधारित कार्यप्रवाह आधुनिक लेबल संग्रह के बजाय कस्टम दस्तावेज़ गुणों में संवेदनशीलता लेबल मेटाडाटा संग्रहीत कर सकते हैं। यह मेटाडाटा `[IDocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/hi/java/com.aspose.slides/idocumentproperties/#getSensitivityLabels--)` के माध्यम से पढ़ें। यह विधि लेगेसी कस्टम गुणों को पार्स करती है और एक `[ISensitivityLabel](https://reference.aspose.com/slides/hi/java/com.aspose.slides/isensitivitylabel/)` वस्तुओं की श्रृंखला लौटाती है।

मेटाडाटा को माइग्रेट करने के लिये, प्रत्येक प्राप्त लेबल को आधुनिक `[ISensitivityLabelCollection](https://reference.aspose.com/slides/hi/java/com.aspose.slides/isensitivitylabelcollection/)` में `[ISensitivityLabelCollection.add](https://reference.aspose.com/slides/hi/java/com.aspose.slides/isensitivitylabelcollection/#add-com.aspose.slides.ISensitivityLabel-)` के द्वारा जोड़ें। डुप्लिकेट लेबल पहचानकर्ता जोड़ने पर अपवाद उत्पन्न होता है, इसलिए उदाहरण लक्ष्य संग्रह को प्रत्येक लेबल कॉपी करने से पहले जाँचता है। आप यह सुनिश्चित करने के लिये अतिरिक्त सत्यापन जोड़ सकते हैं कि प्रत्येक लेगेसी लेबल अभी भी वर्तमान Purview नीति में मौजूद है।

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

माइग्रेशन पार्स किए गए लेबल वस्तुओं को आधुनिक संग्रह में कॉपी करता है। यह सभी कस्टम दस्तावेज़ गुणों को साफ़ करने की आवश्यकता नहीं रखता, इसलिए अप्रासंगिक दस्तावेज़ मेटाडाटा अपरिवर्तित रहता है। आधुनिक लेबल मेटाडाटा को PPTX फ़ाइल में लिखने के लिये `[IPresentation.save](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipresentation/#save-java.lang.String-int-)` को `[SaveFormat.Pptx](https://reference.aspose.com/slides/hi/java/com.aspose.slides/saveformat/)` के साथ कॉल करें।

## **FAQ**

**क्या कंटेंट मार्किंग प्रकार जोड़ने से स्लाइडों पर दृश्यमान हेडर, फूटर, या वॉटरमार्क बनता है?**

नहीं। `[ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/hi/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--)` द्वारा लौटाई गई सूची में जोड़े गए मान लेबल से जुड़े मार्किंग को वर्णित करते हैं। वे प्रस्तुति में दृश्यमान पाठ या आकार नहीं बनाते। यदि आपके कार्यप्रवाह को उन मार्किंग को रेंडर करना आवश्यक है तो संबंधित स्लाइड कंटेंट को अलग से जोड़ें।

**लेबल को हटाए गए के रूप में चिह्नित करने और संग्रह से उसे हटाने में क्या अंतर है?**

`ISensitivityLabel.setRemoved` को `true` के साथ कॉल करने से लेबल प्रविष्टि बनी रहती है और उसकी हटाने की स्थिति रिकॉर्ड होती है। `ISensitivityLabelCollection.removeAt` को कॉल करने से लेबल आधुनिक संग्रह से पूरी तरह हट जाता है। अपनी संगठन की मेटाडाटा रखरखाव आवश्यकताओं के अनुसार उचित कार्य चुनें।

**क्या एक प्रस्तुति में लेगेसी MIP मेटाडाटा और आधुनिक संवेदनशीलता लेबल दोनों हो सकते हैं?**

हां। लेगेसी लेबल कस्टम दस्तावेज़ गुणों में रह सकते हैं जबकि आधुनिक लेबल `[IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipresentation/#getSensitivityLabels--)` के द्वारा उपलब्ध होते हैं। लेगेसी मेटाडाटा पढ़ने और केवल वैध लेबल जिन्हें आधुनिक संग्रह में अभी नहीं है, उन्हें माइग्रेट करने के लिये `[IDocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/hi/java/com.aspose.slides/idocumentproperties/#getSensitivityLabels--)` का उपयोग करें।

**जब समान पहचानकर्ता वाला लेबल कई बार जोड़ा जाता है तो क्या होता है?**

`[ISensitivityLabelCollection.add](https://reference.aspose.com/slides/hi/java/com.aspose.slides/isensitivitylabelcollection/#add-java.lang.String-java.util.UUID-boolean-int-)` तब अपवाद उत्पन्न करता है जब संग्रह में पहले से वही पहचानकर्ता वाला लेबल मौजूद हो। लेबल या माइग्रेट करने से पहले `[ISensitivityLabel.getId](https://reference.aspose.com/slides/hi/java/com.aspose.slides/isensitivitylabel/#getId--)` द्वारा लौटाई गई मौजूदा मानों की जाँच करें।

**अपडेटेड संवेदनशीलता लेबलों को सुरक्षित रखने के लिये कौन सा आउटपुट फॉर्मेट इस्तेमाल करना चाहिए?**

प्रस्तुति को PPTX के रूप में सहेजें, अर्थात् `[IPresentation.save](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipresentation/#save-java.lang.String-int-)` को `[SaveFormat.Pptx](https://reference.aspose.com/slides/hi/java/com.aspose.slides/saveformat/)` के साथ कॉल करें, जैसा कि ऊपर के उदाहरणों में दिखाया गया है।