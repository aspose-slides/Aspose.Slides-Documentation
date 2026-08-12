---
title: Python में PowerPoint प्रस्तुतियों में संवेदनशीलता लेबल प्रबंधित करें
linktitle: संवेदनशीलता लेबल
type: docs
weight: 50
url: /hi/python-net/sensitivity-labels/
keywords:
- संवेदनशीलता लेबल
- Microsoft Purview
- Microsoft Information Protection
- MIP मेटाडाटा
- सामग्री चिह्नन
- सूचना सुरक्षा
- दस्तावेज़ शासन
- PowerPoint
- PPTX
- प्रस्तुति सुरक्षा
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET के साथ PowerPoint PPTX प्रस्तुतियों में Microsoft Purview संवेदनशीलता लेबल पढ़ें, जोड़ें, अपडेट करें, हटाएँ और माइग्रेट करें।"
---
## **सारांश**

Microsoft Purview संवेदनशीलता लेबल संगठनों को दस्तावेज़ों को वर्गीकृत करने और उनका शासन करने में मदद करते हैं। स्वचालित प्रस्तुति प्रोसेसिंग के दौरान, एक एप्लिकेशन को मौजूदा लेबल को बरकरार रखना, नीति द्वारा चयनित लेबल लागू करना, उसकी स्थिति अपडेट करना, या पुराने Microsoft Information Protection (MIP) वर्कफ़्लो द्वारा लिखे गए लेबल मेटाडेटा को माइग्रेट करना पड़ सकता है।

Aspose.Slides for Python via .NET आधुनिक संवेदनशीलता लेबल मेटाडेटा को [Presentation.sensitivity_labels](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/sensitivity_labels/) के माध्यम से उजागर करता है। यह प्रॉपर्टी एक [SensitivityLabelCollection](https://reference.aspose.com/slides/hi/python-net/aspose.slides/sensitivitylabelcollection/) लौटाती है जिसे प्रस्तुति को PPTX के रूप में सहेजने से पहले निरीक्षण और संशोधित किया जा सकता है।

{{% alert color="primary" title="नोट" %}}
संवेदनशीलता लेबल पहचानकर्ता और नीति जानकारी आपके Microsoft Purview कॉन्फ़िगरेशन द्वारा परिभाषित होती है। अपने वातावरण में लेबल उपलब्धता और नीति आवश्यकताओं को सत्यापित करने के बाद ही मेटाडेटा जोड़ें या माइग्रेट करें। [SensitivityLabel.content_mark_types](https://reference.aspose.com/slides/hi/python-net/aspose.slides/sensitivitylabel/content_mark_types/) मान केवल लेबल के साथ जुड़े सामग्री चिह्नों का वर्णन करते हैं; वे स्वयं स्लाइड पर दिखाई देने वाला पाठ या आकार नहीं जोड़ते हैं।
{{% /alert %}}

## **संवेदनशीलता लेबल गुण समझें**

प्रत्येक [SensitivityLabel](https://reference.aspose.com/slides/hi/python-net/aspose.slides/sensitivitylabel/) में निम्नलिखित मेटाडेटा शामिल होते हैं:

| प्रॉपर्टी | उद्देश्य |
| --- | --- |
| [SensitivityLabel.id](https://reference.aspose.com/slides/hi/python-net/aspose.slides/sensitivitylabel/id/) | Purview नीति में संवेदनशीलता लेबल को पहचानता है। |
| [SensitivityLabel.site_id](https://reference.aspose.com/slides/hi/python-net/aspose.slides/sensitivitylabel/site_id/) | लेबल नीति से जुड़ी साइट को पहचानता है। |
| [SensitivityLabel.is_enabled](https://reference.aspose.com/slides/hi/python-net/aspose.slides/sensitivitylabel/is_enabled/) | दर्शाता है कि लेबल सक्षम है या नहीं। |
| [SensitivityLabel.is_removed](https://reference.aspose.com/slides/hi/python-net/aspose.slides/sensitivitylabel/is_removed/) | दर्शाता है कि लेबल हटा दिया गया है। जब हटाने की स्थिति मेटाडेटा में बरकरार रखनी हो, तो इस प्रॉपर्टी को `True` सेट करें। |
| [SensitivityLabel.assignment_method_type](https://reference.aspose.com/slides/hi/python-net/aspose.slides/sensitivitylabel/assignment_method_type/) | यह निर्दिष्ट करता है कि लेबल स्वचालित रूप से लागू किया गया था या उपयोगकर्ता निर्णय के आधार पर। |
| [SensitivityLabel.content_mark_types](https://reference.aspose.com/slides/hi/python-net/aspose.slides/sensitivitylabel/content_mark_types/) | लेबल से जुड़े सामग्री चिह्न प्रकारों की सूची देता है। |

[SensitivityLabelAssignmentType](https://reference.aspose.com/slides/hi/python-net/aspose.slides/sensitivitylabelassignmenttype/) एन्नुमरेशन बताता है कि लेबल कैसे असाइन किया गया:

- [SensitivityLabelAssignmentType.STANDARD](https://reference.aspose.com/slides/hi/python-net/aspose.slides/sensitivitylabelassignmenttype/) डिफ़ॉल्ट या स्वचालित रूप से लागू लेबल को दर्शाता है।
- [SensitivityLabelAssignmentType.PRIVILEGED](https://reference.aspose.com/slides/hi/python-net/aspose.slides/sensitivitylabelassignmenttype/) उपयोगकर्ता निर्णय के माध्यम से लागू किए गए लेबल को दर्शाता है, जिसमें मैन्युअल, अनुशंसित और अनिवार्य लेबल शामिल हैं।

[SensitivityLabelContentType](https://reference.aspose.com/slides/hi/python-net/aspose.slides/sensitivitylabelcontenttype/) एन्नुमरेशन लेबल से जुड़े चिह्न को पहचानता है:

| मान | अर्थ |
| --- | --- |
| [SensitivityLabelContentType.NONE](https://reference.aspose.com/slides/hi/python-net/aspose.slides/sensitivitylabelcontenttype/) | लेबल डिफ़ॉल्ट रूप से या स्वचालित रूप से लागू किया गया था। |
| [SensitivityLabelContentType.HEADER](https://reference.aspose.com/slides/hi/python-net/aspose.slides/sensitivitylabelcontenttype/) | हेडर सामग्री चिह्न लेबल से जुड़ा है। |
| [SensitivityLabelContentType.FOOTER](https://reference.aspose.com/slides/hi/python-net/aspose.slides/sensitivitylabelcontenttype/) | फुटर सामग्री चिह्न लेबल से जुड़ा है। |
| [SensitivityLabelContentType.WATERMARK](https://reference.aspose.com/slides/hi/python-net/aspose.slides/sensitivitylabelcontenttype/) | वॉटरमार्क सामग्री चिह्न लेबल से जुड़ा है। |
| [SensitivityLabelContentType.ENCRYPTION](https://reference.aspose.com/slides/hi/python-net/aspose.slides/sensitivitylabelcontenttype/) | एन्क्रिप्शन सुरक्षा लेबल से जुड़ी है। |

एक लेबल के साथ कई चिह्न प्रकार जुड़े हो सकते हैं।

## **मौजूदा संवेदनशीलता लेबल सूचीबद्ध करें**

[Presentation.sensitivity_labels](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/sensitivity_labels/) से आधुनिक लेबल संग्रह पढ़ें और उसे परिक्रमा करें। निम्नलिखित उदाहरण प्रत्येक लेबल के सभी प्रॉपर्टी और सामग्री चिह्न सूचीबद्ध करता है:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    sensitivity_labels = presentation.sensitivity_labels

    for sensitivity_label in sensitivity_labels:
        print("Label ID:", sensitivity_label.id)
        print("Site ID:", sensitivity_label.site_id)
        print("Enabled:", sensitivity_label.is_enabled)
        print("Removed:", sensitivity_label.is_removed)
        print("Assignment method:", sensitivity_label.assignment_method_type)

        for content_mark_type in sensitivity_label.content_mark_types:
            print("Content marking:", content_mark_type)
```

## **सामग्री चिह्न के साथ संवेदनशीलता लेबल जोड़ें**

लेबल पहचानकर्ता, साइट पहचानकर्ता, सक्षम स्थिति और असाइनमेंट मेथड के साथ [SensitivityLabelCollection.add](https://reference.aspose.com/slides/hi/python-net/aspose.slides/sensitivitylabelcollection/add/) का उपयोग करें। साइट पहचानकर्ता को Python `uuid.UUID` ऑब्जेक्ट के रूप में पास करें। जब मेथड नया [SensitivityLabel](https://reference.aspose.com/slides/hi/python-net/aspose.slides/sensitivitylabel/) लौटाए, तो आवश्यक चिह्न मानों को [SensitivityLabel.content_mark_types](https://reference.aspose.com/slides/hi/python-net/aspose.slides/sensitivitylabel/content_mark_types/) में जोड़ें।

निम्न उदाहरण फ़ुटर और वॉटरमार्क चिह्नों के साथ मैन्युअल रूप से चयनित लेबल जोड़ता है, और फिर परिणाम को PPTX के रूप में सहेजता है:

```python
import uuid
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    sensitivity_labels = presentation.sensitivity_labels

    label_identifier = "{11111111-2222-3333-4444-555555555555}"
    site_identifier = uuid.UUID("aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee")
    is_enabled = True
    assignment_method = slides.SensitivityLabelAssignmentType.PRIVILEGED

    sensitivity_label = sensitivity_labels.add(
        label_identifier,
        site_identifier,
        is_enabled,
        assignment_method
    )

    sensitivity_label.content_mark_types.append(slides.SensitivityLabelContentType.FOOTER)
    sensitivity_label.content_mark_types.append(slides.SensitivityLabelContentType.WATERMARK)

    presentation.save("presentation_with_label.pptx", slides.export.SaveFormat.PPTX)
```

## **संवेदनशीलता लेबल अपडेट करें**

[SensitivityLabel](https://reference.aspose.com/slides/hi/python-net/aspose.slides/sensitivitylabel/) प्रॉपर्टी पढ़ी/लिखी जा सकती हैं, सिवाय इसके कि [SensitivityLabel.content_mark_types](https://reference.aspose.com/slides/hi/python-net/aspose.slides/sensitivitylabel/content_mark_types/) द्वारा लौटाई गई सूची को उसकी सूची ऑपरेशन्स के माध्यम से संशोधित किया जाता है। आवश्यक लेबल ढूँढने के बाद, आप उसकी पहचानकर्ता, साइट पहचानकर्ता, सक्षम स्थिति, असाइनमेंट मेथड, हटाने की स्थिति और सामग्री चिह्न प्रकारों को अपडेट कर सकते हैं। परिवर्तन टिकाने के लिए प्रस्तुति को सहेजें।

निम्न उदाहरण पहले लेबल की सक्षम स्थिति और असाइनमेंट मेथड को अपडेट करता है:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    sensitivity_labels = presentation.sensitivity_labels

    if sensitivity_labels.count > 0:
        sensitivity_label = sensitivity_labels[0]
        sensitivity_label.is_enabled = True
        sensitivity_label.assignment_method_type = (
            slides.SensitivityLabelAssignmentType.PRIVILEGED
        )

    presentation.save("presentation_with_updated_label.pptx", slides.export.SaveFormat.PPTX)
```

## **लेबल को हटाए रूप में चिह्नित करें**

लेबल हटाए जाने की तथ्य को बरकरार रखने के लिए, लेबल ढूँढें और [SensitivityLabel.is_removed](https://reference.aspose.com/slides/hi/python-net/aspose.slides/sensitivitylabel/is_removed/) को `True` सेट करें। इससे लेबल एंट्री बरकरार रहती है जबकि उसकी हटाने की स्थिति रिकॉर्ड होती है। यदि आपको आधुनिक संग्रह से एंट्री को पूरी तरह हटाना है, तो [SensitivityLabelCollection.remove_at](https://reference.aspose.com/slides/hi/python-net/aspose.slides/sensitivitylabelcollection/remove_at/) का उपयोग करें; सभी एंट्री को हटाने के लिए [SensitivityLabelCollection.clear](https://reference.aspose.com/slides/hi/python-net/aspose.slides/sensitivitylabelcollection/clear/) का उपयोग करें।

निम्न उदाहरण एक विशिष्ट लेबल को हटाए रूप में चिह्नित करता है और अद्यतन प्रस्तुति को सहेजता है:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    sensitivity_labels = presentation.sensitivity_labels
    target_label_identifier = "{11111111-2222-3333-4444-555555555555}"

    for sensitivity_label in sensitivity_labels:
        identifiers_match = (
            sensitivity_label.id.casefold() == target_label_identifier.casefold()
        )

        if identifiers_match:
            sensitivity_label.is_removed = True
            break

    presentation.save("presentation_with_removed_label.pptx", slides.export.SaveFormat.PPTX)
```

## **पुराने MIP संवेदनशीलता लेबल पढ़ें और माइग्रेट करें**

पुराने MIP-आधारित वर्कफ़्लो आधुनिक लेबल संग्रह के बजाय कस्टम डॉक्यूमेंट प्रॉपर्टीज़ में संवेदनशीलता लेबल मेटाडेटा संग्रहीत कर सकते हैं। इस मेटाडेटा को [DocumentProperties.get_sensitivity_labels](https://reference.aspose.com/slides/hi/python-net/aspose.slides/documentproperties/get_sensitivity_labels/) से पढ़ें। यह मेथड लेगेसी कस्टम प्रॉपर्टीज़ को पार्स करता है और [SensitivityLabel](https://reference.aspose.com/slides/hi/python-net/aspose.slides/sensitivitylabel/) ऑब्जेक्ट लौटाता है।

मेटाडेटा माइग्रेट करने के लिए, प्रत्येक प्राप्त लेबल को [SensitivityLabelCollection.add](https://reference.aspose.com/slides/hi/python-net/aspose.slides/sensitivitylabelcollection/add/) के माध्यम से आधुनिक [SensitivityLabelCollection](https://reference.aspose.com/slides/hi/python-net/aspose.slides/sensitivitylabelcollection/) में जोड़ें। चूँकि डुप्लिकेट लेबल पहचानकर्ता जोड़ने पर अपवाद उत्पन्न होता है, उदाहरण प्रत्येक लेबल को कॉपी करने से पहले लक्ष्य संग्रह की जाँच करता है। आप यह सत्यापित करने के लिए अतिरिक्त वैधता जोड़ सकते हैं कि प्रत्येक लेगेसी लेबल अभी भी वर्तमान Purview नीति में उपस्थित है।

```python
import aspose.slides as slides

with slides.Presentation("presentation_with_legacy_labels.pptx") as presentation:
    legacy_sensitivity_labels = (
        presentation.document_properties.get_sensitivity_labels()
    )
    modern_sensitivity_labels = presentation.sensitivity_labels

    for legacy_sensitivity_label in legacy_sensitivity_labels:
        label_already_exists = False

        for modern_sensitivity_label in modern_sensitivity_labels:
            label_already_exists = (
                modern_sensitivity_label.id.casefold()
                == legacy_sensitivity_label.id.casefold()
            )

            if label_already_exists:
                break

        if not label_already_exists:
            modern_sensitivity_labels.add(legacy_sensitivity_label)

    presentation.save("presentation_with_modern_labels.pptx", slides.export.SaveFormat.PPTX)
```

माइग्रेशन पार्स किए गए लेबल ऑब्जेक्ट को आधुनिक संग्रह में कॉपी करता है। इसे सभी कस्टम डॉक्यूमेंट प्रॉपर्टीज़ को साफ़ करने की आवश्यकता नहीं है, इसलिए अप्रासंगिक डॉक्यूमेंट मेटाडेटा अपरिवर्तित रहता है। आधुनिक लेबल मेटाडेटा को PPTX फ़ाइल में लिखने के लिए [Presentation.save](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/save/) को [SaveFormat.PPTX](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/saveformat/) के साथ उपयोग करें।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या सामग्री चिह्न प्रकार जोड़ने से स्लाइड में दृश्यमान हेडर, फुटर या वॉटरमार्क बनता है?**

नहीं। [SensitivityLabel.content_mark_types](https://reference.aspose.com/slides/hi/python-net/aspose.slides/sensitivitylabel/content_mark_types/) के माध्यम से जोड़े गए मान केवल लेबल से जुड़े चिह्नों का वर्णन करते हैं। वे प्रस्तुति में दृश्यमान पाठ या आकार नहीं बनाते। यदि आपके वर्कफ़्लो को इन चिह्नों को रेंडर करना आवश्यक है, तो संबंधित स्लाइड सामग्री को अलग से जोड़ें।

**लेबल को हटाए रूप में चिह्नित करने और संग्रह से इसे हटाने में क्या अंतर है?**

[SensitivityLabel.is_removed](https://reference.aspose.com/slides/hi/python-net/aspose.slides/sensitivitylabel/is_removed/) को `True` सेट करने से लेबल एंट्री बरकरार रहती है और उसकी हटाने की स्थिति रिकॉर्ड होती है। [SensitivityLabelCollection.remove_at](https://reference.aspose.com/slides/hi/python-net/aspose.slides/sensitivitylabelcollection/remove_at/) को कॉल करने से एंट्री आधुनिक संग्रह से पूरी तरह हट जाती है। अपनी संगठन की मेटाडेटा प्रतिधारण आवश्यकताओं के अनुसार उपयुक्त ऑपरेशन चुनें।

**क्या एक प्रस्तुति में लेगेसी MIP मेटाडेटा और आधुनिक संवेदनशीलता लेबल दोनों हो सकते हैं?**

हां। लेगेसी लेबल कस्टम डॉक्यूमेंट प्रॉपर्टीज़ में बने रह सकते हैं, जबकि आधुनिक लेबल [Presentation.sensitivity_labels](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/sensitivity_labels/) के माध्यम से उपलब्ध होते हैं। लेगेसी मेटाडेटा पढ़ने और केवल वैध लेबल को माइग्रेट करने के लिए [DocumentProperties.get_sensitivity_labels](https://reference.aspose.com/slides/hi/python-net/aspose.slides/documentproperties/get_sensitivity_labels/) का उपयोग करें।

**जब समान पहचानकर्ता वाले लेबल को कई बार जोड़ा जाता है तो क्या होता है?**

[SensitivityLabelCollection.add](https://reference.aspose.com/slides/hi/python-net/aspose.slides/sensitivitylabelcollection/add/) तब अपवाद फेंकता है जब संग्रह में पहले से वही पहचानकर्ता वाला लेबल मौजूद हो। लेबल जोड़ने या माइग्रेट करने से पहले मौजूदा [SensitivityLabel.id](https://reference.aspose.com/slides/hi/python-net/aspose.slides/sensitivitylabel/id/) मानों की जाँच करें।

**अपडेटेड संवेदनशीलता लेबल को बरकरार रखने के लिए कौन सा आउटपुट फ़ॉर्मेट उपयोग किया जाना चाहिए?**

उपरोक्त उदाहरणों में दिखाए अनुसार प्रस्तुति को PPTX के रूप में सहेजें, इसे करने के लिए [Presentation.save](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/save/) को [SaveFormat.PPTX](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/saveformat/) के साथ कॉल करें।