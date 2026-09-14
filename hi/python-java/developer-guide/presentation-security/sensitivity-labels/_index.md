---
title: Python में PowerPoint प्रस्तुतियों में संवेदनशीलता लेबल प्रबंधित करें
linktitle: संवेदनशीलता लेबल
type: docs
weight: 50
url: /hi/python-java/sensitivity-labels/
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
- प्रेजेंटेशन सुरक्षा
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via Java के माध्यम से PowerPoint PPTX प्रस्तुतियों में Microsoft Purview संवेदनशीलता लेबल को पढ़ें, जोड़ें, अपडेट करें, हटाएँ और माइग्रेट करें।"
---
## **अवलोकन**

Microsoft Purview sensitivity labels संगठनों को दस्तावेज़ों को वर्गीकृत और नियंत्रित करने में मदद करते हैं। स्वचालित प्रस्तुति प्रसंस्करण के दौरान, किसी एप्लिकेशन को मौजूदा लेबल को बनाए रखना, नीति द्वारा चयनित लेबल लागू करना, उसकी स्थिति अपडेट करना, या पुराने Microsoft Information Protection (MIP) वर्कफ़्लो द्वारा लिखे गए लेबल मेटाडेटा को माइग्रेट करना पड़ सकता है।

Aspose.Slides आधुनिक संवेदनशीलता लेबल मेटाडेटा को [Presentation.getSensitivityLabels](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#getSensitivityLabels) के माध्यम से उजागर करता है। यह मेथड एक [SensitivityLabelCollection](https://reference.aspose.com/slides/hi/python-java/aspose.slides/sensitivitylabelcollection/) लौटाता है जिसे प्रस्तुति को PPTX के रूप में सहेजने से पहले निरीक्षण और संशोधित किया जा सकता है।

{{% alert color="info" title="Note" %}}

सेंसिटिविटी लेबल पहचानकर्ता और नीति जानकारी आपके Microsoft Purview कॉन्फ़िगरेशन द्वारा परिभाषित किए जाते हैं। मेटाडेटा जोड़ने या माइग्रेट करने से पहले अपने पर्यावरण में लेबल की उपलब्धता और नीति आवश्यकताओं को मान्य करें। [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/hi/python-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) मान उन सामग्री चिह्नों का विवरण देते हैं जो लेबल से जुड़े होते हैं; वे स्वयं स्लाइड्स में कोई दृश्यमान टेक्स्ट या आकार नहीं जोड़ते।

{{% /alert %}}

## **सेंसिटिविटी लेबल गुणों को समझें**

प्रत्येक [SensitivityLabel](https://reference.aspose.com/slides/hi/python-java/aspose.slides/sensitivitylabel/) में निम्नलिखित मेटाडेटा होता है:

| विधियाँ | उद्देश्य |
| --- | --- |
| [getId](https://reference.aspose.com/slides/hi/python-java/aspose.slides/sensitivitylabel/#getId) और [setId](https://reference.aspose.com/slides/hi/python-java/aspose.slides/sensitivitylabel/#setId) | Purview नीति में संवेदनशीलता लेबल पहचानकर्ता को प्राप्त या सेट करें। |
| [getSiteId](https://reference.aspose.com/slides/hi/python-java/aspose.slides/sensitivitylabel/#getSiteId) और [setSiteId](https://reference.aspose.com/slides/hi/python-java/aspose.slides/sensitivitylabel/#setSiteId) | लेबल नीति से जुड़े साइट को प्राप्त या सेट करें। |
| [isEnabled](https://reference.aspose.com/slides/hi/python-java/aspose.slides/sensitivitylabel/#isEnabled) और [setEnabled](https://reference.aspose.com/slides/hi/python-java/aspose.slides/sensitivitylabel/#setEnabled) | लेबल सक्षम है या नहीं, इसे प्राप्त या सेट करें। |
| [isRemoved](https://reference.aspose.com/slides/hi/python-java/aspose.slides/sensitivitylabel/#isRemoved) और [setRemoved](https://reference.aspose.com/slides/hi/python-java/aspose.slides/sensitivitylabel/#setRemoved) | लेबल हटाया गया है या नहीं, इसे प्राप्त या सेट करें। हटाने की स्थिति को मेटाडेटा में बनाए रखने के लिए मान को `True` सेट करें। |
| [getAssignmentMethodType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/sensitivitylabel/#getAssignmentMethodType) और [setAssignmentMethodType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/sensitivitylabel/#setAssignmentMethodType) | लेबल स्वचालित रूप से लागू किया गया या उपयोगकर्ता निर्णय के माध्यम से, इसे प्राप्त या सेट करें। |
| [getContentMarkTypes](https://reference.aspose.com/slides/hi/python-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) | लेबल से जुड़े सामग्री चिह्न प्रकारों को प्राप्त करें। |

[SensitivityLabelAssignmentType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/sensitivitylabelassignmenttype/) क्लास निर्धारित करता है कि लेबल किस प्रकार असाइन किया गया था:

- [Standard](https://reference.aspose.com/slides/hi/python-java/aspose.slides/sensitivitylabelassignmenttype/) डिफ़ॉल्ट या स्वचालित रूप से लागू किए गए लेबल को दर्शाता है।
- [Privileged](https://reference.aspose.com/slides/hi/python-java/aspose.slides/sensitivitylabelassignmenttype/) उपयोगकर्ता निर्णय के माध्यम से लागू किए गए लेबल को दर्शाता है, जिसमें मैन्युअल, अनुशंसित और अनिवार्य लेबल शामिल हैं।

[SensitivityLabelContentType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/sensitivitylabelcontenttype/) क्लास लेबल से जुड़े चिह्न को परिभाषित करता है:

| मान | अर्थ |
| --- | --- |
| [None](https://reference.aspose.com/slides/hi/python-java/aspose.slides/sensitivitylabelcontenttype/) | लेबल डिफ़ॉल्ट रूप से या स्वचालित रूप से लागू किया गया। |
| [Header](https://reference.aspose.com/slides/hi/python-java/aspose.slides/sensitivitylabelcontenttype/) | हेडर सामग्री चिह्न लेबल से जुड़ा है। |
| [Footer](https://reference.aspose.com/slides/hi/python-java/aspose.slides/sensitivitylabelcontenttype/) | फुटर सामग्री चिह्न लेबल से जुड़ा है। |
| [Watermark](https://reference.aspose.com/slides/hi/python-java/aspose.slides/sensitivitylabelcontenttype/) | वॉटरमार्क सामग्री चिह्न लेबल से जुड़ा है। |
| [Encryption](https://reference.aspose.com/slides/hi/python-java/aspose.slides/sensitivitylabelcontenttype/) | एन्क्रिप्शन सुरक्षा लेबल से जुड़ी है। |

कई चिह्न प्रकार एक ही लेबल से जुड़े हो सकते हैं।

## **मौजूदा संवेदनशीलता लेबलों की सूची बनाएं**

[Presentation.getSensitivityLabels](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#getSensitivityLabels) से आधुनिक लेबल संग्रह को पढ़ें और उसे व्यवस्थित करें। निम्नलिखित उदाहरण प्रत्येक लेबल के लिए सभी गुण और सामग्री चिह्नों को सूचीबद्ध करता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    sensitivity_labels = presentation.getSensitivityLabels()

    for sensitivity_label in sensitivity_labels:
        print("Label ID:", sensitivity_label.getId())
        print("Site ID:", sensitivity_label.getSiteId())
        print("Enabled:", sensitivity_label.isEnabled())
        print("Removed:", sensitivity_label.isRemoved())
        print("Assignment method:", sensitivity_label.getAssignmentMethodType())

        for content_mark_type in sensitivity_label.getContentMarkTypes():
            print("Content marking:", content_mark_type)
finally:
    presentation.dispose()
```

## **सामग्री चिह्न के साथ संवेदनशीलता लेबल जोड़ें**

लेबल पहचानकर्ता, साइट पहचानकर्ता, सक्षम स्थिति और असाइनमेंट मेथड के साथ [SensitivityLabelCollection.add](https://reference.aspose.com/slides/hi/python-java/aspose.slides/sensitivitylabelcollection/#add) का उपयोग करें। मेथड नया [SensitivityLabel](https://reference.aspose.com/slides/hi/python-java/aspose.slides/sensitivitylabel/) लौटाता है, फिर [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/hi/python-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) द्वारा लौटाए गए सूची के माध्यम से आवश्यक चिह्न मान जोड़ें।

निम्नलिखित उदाहरण फ़ुटर और वॉटरमार्क चिह्नों के साथ मैन्युअली चयनित लेबल जोड़ता है, और फिर परिणाम को PPTX के रूप में सहेजता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SensitivityLabelAssignmentType, SensitivityLabelContentType
from java.util import UUID

presentation = Presentation("presentation.pptx")
try:
    sensitivity_labels = presentation.getSensitivityLabels()

    label_identifier = "{11111111-2222-3333-4444-555555555555}"
    site_identifier = UUID.fromString("aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee")
    is_enabled = True
    assignment_method = SensitivityLabelAssignmentType.Privileged

    sensitivity_label = sensitivity_labels.add(label_identifier, site_identifier, is_enabled, assignment_method)

    sensitivity_label.getContentMarkTypes().addItem(jpype.JInt(SensitivityLabelContentType.Footer))
    sensitivity_label.getContentMarkTypes().addItem(jpype.JInt(SensitivityLabelContentType.Watermark))

    presentation.save("presentation_with_label.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **संवेदनशीलता लेबल को अपडेट करें**

[SensitivityLabel](https://reference.aspose.com/slides/hi/python-java/aspose.slides/sensitivitylabel/) मान पढ़ने/लिखने योग्य होते हैं, सिवाय इसके कि [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/hi/python-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) द्वारा लौटाई गई सूची को उसकी सूची संचालन के माध्यम से संशोधित किया जाता है। आवश्यक लेबल को खोजने के बाद, आप उसका पहचानकर्ता, साइट पहचानकर्ता, सक्षम स्थिति, असाइनमेंट मेथड, हटाने की स्थिति और सामग्री चिह्न प्रकार अपडेट कर सकते हैं। परिवर्तन को बनाए रखने के लिए प्रस्तुति को सहेजें।

निम्न उदाहरण पहले लेबल की सक्षम स्थिति और असाइनमेंट मेथड को अपडेट करता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SensitivityLabelAssignmentType

presentation = Presentation("presentation.pptx")
try:
    sensitivity_labels = presentation.getSensitivityLabels()

    if sensitivity_labels.getCount() > 0:
        sensitivity_label = sensitivity_labels.get_Item(0)
        sensitivity_label.setEnabled(True)
        sensitivity_label.setAssignmentMethodType(SensitivityLabelAssignmentType.Privileged)

    presentation.save("presentation_with_updated_label.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **संवेदनशीलता लेबल को हटाए के रूप में चिह्नित करें**

लेबल के हटाए जाने का तथ्य बनाए रखने के लिए, लेबल खोजें और [SensitivityLabel.setRemoved](https://reference.aspose.com/slides/hi/python-java/aspose.slides/sensitivitylabel/#setRemoved) को `True` के साथ कॉल करें। इससे लेबल प्रविष्टि बरकरार रहती है जबकि उसकी हटाने की स्थिति रिकॉर्ड हो जाती है। यदि आप आधुनिक संग्रह से प्रविष्टि को वास्तव में हटाना चाहते हैं, तो [SensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/hi/python-java/aspose.slides/sensitivitylabelcollection/#removeAt) का उपयोग करें; सभी प्रविष्टियों को हटाने के लिए [SensitivityLabelCollection.clear](https://reference.aspose.com/slides/hi/python-java/aspose.slides/sensitivitylabelcollection/#clear) प्रयोग करें।

निम्न उदाहरण एक विशिष्ट लेबल को हटाए के रूप में चिह्नित करता है और अपडेटेड प्रस्तुति को सहेजता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    sensitivity_labels = presentation.getSensitivityLabels()
    target_label_identifier = "{11111111-2222-3333-4444-555555555555}"

    for sensitivity_label in sensitivity_labels:
        is_target_label = str(sensitivity_label.getId()).casefold() == target_label_identifier.casefold()

        if is_target_label:
            sensitivity_label.setRemoved(True)
            break

    presentation.save("presentation_with_removed_label.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **पुराने MIP संवेदनशीलता लेबल पढ़ें और माइग्रेट करें**

पुराने MIP‑आधारित वर्कफ़्लो आधुनिक लेबल संग्रह के बजाय कस्टम दस्तावेज़ गुणों में संवेदनशीलता लेबल मेटाडेटा संग्रहीत कर सकते हैं। उस मेटाडेटा को [DocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/hi/python-java/aspose.slides/documentproperties/#getSensitivityLabels) के साथ पढ़ें। यह मेथड पुराने कस्टम गुणों को पार्स करता है और [SensitivityLabel](https://reference.aspose.com/slides/hi/python-java/aspose.slides/sensitivitylabel/) वस्तुओं की एक ऐरे लौटाता है।

मेटाडेटा को माइग्रेट करने के लिए, प्रत्येक लौटाए गए लेबल को [SensitivityLabelCollection.add](https://reference.aspose.com/slides/hi/python-java/aspose.slides/sensitivitylabelcollection/#add) के माध्यम से आधुनिक [SensitivityLabelCollection](https://reference.aspose.com/slides/hi/python-java/aspose.slides/sensitivitylabelcollection/) में जोड़ें। चूंकि समान लेबल पहचानकर्ता जोड़ने से अपवाद उत्पन्न होता है, उदाहरण प्रत्येक लेबल को कॉपी करने से पहले गंतव्य संग्रह की जाँच करता है। आप अतिरिक्त सत्यापन जोड़ सकते हैं ताकि प्रत्येक पुराना लेबल वर्तमान Purview नीति में अभी भी मौजूद हो यह पुष्टि हो सके।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation_with_legacy_labels.pptx")
try:
    legacy_sensitivity_labels = presentation.getDocumentProperties().getSensitivityLabels()
    modern_sensitivity_labels = presentation.getSensitivityLabels()

    for legacy_sensitivity_label in legacy_sensitivity_labels:
        label_already_exists = False

        for modern_sensitivity_label in modern_sensitivity_labels:
            label_already_exists = str(modern_sensitivity_label.getId()).casefold() == str(legacy_sensitivity_label.getId()).casefold()

            if label_already_exists:
                break

        if not label_already_exists:
            modern_sensitivity_labels.add(legacy_sensitivity_label)

    presentation.save("presentation_with_modern_labels.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

माइग्रेशन पार्स किए गए लेबल ऑब्जेक्ट को आधुनिक संग्रह में कॉपी करता है। यह सभी कस्टम दस्तावेज़ गुणों को साफ़ करने की आवश्यकता नहीं रखता, इसलिए अप्रासंगिक दस्तावेज़ मेटाडेटा अपरिवर्तित रहता है। आधुनिक लेबल मेटाडेटा को PPTX फ़ाइल में लिखने के लिए [Presentation.save](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#save) को [SaveFormat.Pptx](https://reference.aspose.com/slides/hi/python-java/aspose.slides/saveformat/) के साथ उपयोग करें।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या सामग्री चिह्न प्रकार जोड़ने से स्लाइड्स में हेडर, फुटर या वॉटरमार्क दिखाई देता है?**

नहीं। [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/hi/python-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) द्वारा लौटाई गई सूची में जोड़े गए मान केवल संवेदनशीलता लेबल से जुड़े चिह्नों का वर्णन करते हैं। वे प्रस्तुति में कोई दृश्य टेक्स्ट या आकार नहीं बनाते। यदि आपके वर्कफ़्लो को इन चिह्नों को रेंडर करना आवश्यक है, तो संबंधित स्लाइड सामग्री को अलग से जोड़ें।

**लेबल को हटाए के रूप में चिह्नित करने और संग्रह से हटाने में क्या अंतर है?**

[SensitivityLabel.setRemoved](https://reference.aspose.com/slides/hi/python-java/aspose.slides/sensitivitylabel/#setRemoved) को `True` के साथ कॉल करने से लेबल प्रविष्टि बनी रहती है और उसकी हटाने की स्थिति दर्ज होती है। [SensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/hi/python-java/aspose.slides/sensitivitylabelcollection/#removeAt) को कॉल करने से प्रविष्टि आधुनिक संग्रह से पूरी तरह हट जाती है। अपनी संस्था की मेटाडेटा रखरखाव आवश्यकताओं के अनुरूप ऑपरेशन चुनें।

**क्या एक प्रस्तुति में पुराना MIP मेटाडेटा और आधुनिक संवेदनशीलता लेबल दोनों हो सकते हैं?**

हां। पुराना लेबल कस्टम दस्तावेज़ गुणों में रह सकता है जबकि आधुनिक लेबल [Presentation.getSensitivityLabels](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#getSensitivityLabels) के माध्यम से उपलब्ध होते हैं। पुराना मेटाडेटा पढ़ने और केवल वैध लेबल को माइग्रेट करने के लिए [DocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/hi/python-java/aspose.slides/documentproperties/#getSensitivityLabels) का उपयोग करें।

**जब समान पहचानकर्ता वाला लेबल कई बार जोड़ा जाता है तो क्या होता है?**

[SensitivityLabelCollection.add](https://reference.aspose.com/slides/hi/python-java/aspose.slides/sensitivitylabelcollection/#add) संग्रह में समान पहचानकर्ता वाला लेबल मौजूद होने पर अपवाद उत्पन्न करता है। लेबल जोड़ने या माइग्रेट करने से पहले [SensitivityLabel.getId](https://reference.aspose.com/slides/hi/python-java/aspose.slides/sensitivitylabel/#getId) द्वारा लौटाए गए मौजूदा मानों की जाँच करें।

**अपडेट किए गए संवेदनशीलता लेबल को संरक्षित रखने के लिए कौन सा आउटपुट फॉर्मेट उपयोग करना चाहिए?**

उपरोक्त उदाहरणों में दिखाए अनुसार प्रस्तुति को [Presentation.save](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#save) के साथ [SaveFormat.Pptx](https://reference.aspose.com/slides/hi/python-java/aspose.slides/saveformat/) कॉल करके PPTX के रूप में सहेजें।