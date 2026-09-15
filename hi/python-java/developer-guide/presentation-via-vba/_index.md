---
title: प्रस्तुतीकरण में VBA प्रोजेक्ट्स का प्रबंधन Python द्वारा
linktitle: VBA के माध्यम से प्रस्तुतीकरण
type: docs
weight: 250
url: /hi/python-java/presentation-via-vba/
keywords:
- मैक्रो
- VBA
- VBA मैक्रो
- मैक्रो जोड़ें
- मैक्रो हटाएँ
- मैक्रो निकालें
- VBA जोड़ें
- VBA हटाएँ
- VBA निकालें
- PowerPoint
- OpenDocument
- प्रस्तुतीकरण
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java के साथ VBA के माध्यम से PowerPoint और OpenDocument प्रस्तुतीकरण बनाना और संशोधित करना सीखें और अपने कार्यप्रवाह को सुगम बनाएँ।"
---
## **परिचय**

Aspose.Slides मैक्रो और VBA कोड के साथ काम करने के लिए क्लासेज़ और इंटरफेसेज़ प्रदान करता है।

{{% alert title="Warning" color="warning" %}} 

जब आप मैक्रो वाले प्रस्तुति को दूसरे फ़ाइल फ़ॉर्मेट (PDF, HTML, आदि) में परिवर्तित करते हैं, तो Aspose.Slides सभी मैक्रो को नजरअंदाज कर देता है (मैक्रो resulting फ़ाइल में नहीं ले जाए जाते)।

जब आप प्रस्तुति में मैक्रो जोड़ते हैं या मैक्रो वाले प्रस्तुति को पुनः सहेजते हैं, तो Aspose.Slides केवल मैक्रो के बाइट्स लिखता है।

Aspose.Slides **कभी भी** प्रस्तुति में मैक्रो को चलाता नहीं है।

{{% /alert %}}

## **VBA मैक्रो जोड़ें**

Aspose.Slides [VbaProject](https://reference.aspose.com/slides/hi/python-java/aspose.slides/vbaproject/) क्लास प्रदान करता है जिससे आप VBA प्रोजेक्ट (और प्रोजेक्ट रेफ़रेंसेज़) बना सकते हैं और मौजूदा मॉड्यूल संपादित कर सकते हैं। आप [VbaProject](https://reference.aspose.com/slides/hi/python-java/aspose.slides/vbaproject/) क्लास का उपयोग करके प्रस्तुति में एम्बेडेड VBA को प्रबंधित कर सकते हैं।

1. [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएं।
2. नया VBA प्रोजेक्ट जोड़ने के लिए [VbaProject](https://reference.aspose.com/slides/hi/python-java/aspose.slides/vbaproject/#vbaproject) कन्स्ट्रक्टर का उपयोग करें।
3. VBA प्रोजेक्ट में एक मॉड्यूल जोड़ें।
4. मॉड्यूल का स्रोत कोड सेट करें।
5. `stdole` के रेफ़रेंसेज़ जोड़ें।
6. **Microsoft Office** के रेफ़रेंसेज़ जोड़ें।
7. रेफ़रेंसेज़ को VBA प्रोजेक्ट से जोड़ें।
8. प्रस्तुति को सहेजें।

यह Python कोड दर्शाता है कि कैसे शून्य से प्रस्तुति में VBA मैक्रो जोड़ा जाए:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, VbaProject, VbaReferenceOleTypeLib

presentation = Presentation()
try:
    # एक नया VBA प्रोजेक्ट बनाएं।
    vba_project = VbaProject()
    presentation.setVbaProject(vba_project)

    # एक खाली मॉड्यूल जोड़ें और उसका स्रोत कोड सेट करें।
    module = vba_project.getModules().addEmptyModule("Module")
    module.setSourceCode('Sub Test(oShape As Shape)\n    MsgBox "Test"\nEnd Sub')

    # stdole और Microsoft Office के रेफ़रेंसेज़ बनाएं।
    stdole_reference = VbaReferenceOleTypeLib("stdole", r"*\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\Windows\system32\stdole2.tlb#OLE Automation")
    office_reference = VbaReferenceOleTypeLib("Office", r"*\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\Program Files\Common Files\Microsoft Shared\OFFICE14\MSO.DLL#Microsoft Office 14.0 Object Library")

    # VBA प्रोजेक्ट में रेफ़रेंसेज़ जोड़ें।
    vba_project.getReferences().add(stdole_reference)
    vba_project.getReferences().add(office_reference)

    # प्रेजेंटेशन सहेजें।
    presentation.save("test.pptm", SaveFormat.Pptm)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}} 

आप **Aspose** [Macro Remover](https://products.aspose.app/slides/hi/remove-macros) को देखना चाह सकते हैं, जो PowerPoint, Excel और Word दस्तावेज़ों से मैक्रो हटाने के लिए एक मुफ्त वेब ऐप है। 

{{% /alert %}} 

## **VBA मैक्रो हटाएँ**

आप [getVbaProject](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#getvbaproject) मेथड का उपयोग करके VBA मैक्रो हटा सकते हैं।

1. [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएं और वह प्रस्तुति लोड करें जिसमें मैक्रो हो।
2. मैक्रो मॉड्यूल तक पहुँचें और उसे हटाएँ।
3. संशोधित प्रस्तुति को सहेजें।

यह Python कोड दर्शाता है कि VBA मैक्रो कैसे हटाया जाए:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# मैक्रो वाले प्रस्तुतीकरण को लोड करें।
presentation = Presentation("VBA.pptm")
try:
    # VBA मॉड्यूल तक पहुंचें और उसे हटाएँ।
    vba_project = presentation.getVbaProject()
    if vba_project is not None and len(list(vba_project.getModules())) > 0:
        module = vba_project.getModules().get_Item(0)
        vba_project.getModules().remove(module)

    # प्रस्तुतीकरण सहेजें।
    presentation.save("test.pptm", SaveFormat.Pptm)
finally:
    presentation.dispose()
```

## **VBA मैक्रो निकालें**

1. [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएं और वह प्रस्तुति लोड करें जिसमें मैक्रो हो।
2. जांचें कि क्या प्रस्तुति में VBA प्रोजेक्ट मौजूद है।
3. VBA प्रोजेक्ट में मौजूद सभी मॉड्यूल को लूप करके मैक्रो देखें।

यह Python कोड दर्शाता है कि मैक्रो वाले प्रस्तुति से VBA मैक्रो कैसे निकाले जाएँ:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

# मैक्रो वाले प्रस्तुतीकरण को लोड करें।
presentation = Presentation("VBA.pptm")
try:
    # जांचें कि क्या प्रस्तुतीकरण में VBA प्रोजेक्ट है।
    vba_project = presentation.getVbaProject()
    if vba_project is not None:
        for module in vba_project.getModules():
            print(module.getName())
            print(module.getSourceCode())
finally:
    presentation.dispose()
```

## **जाँचें कि VBA प्रोजेक्ट पासवर्ड-सुरक्षित है या नहीं**

[VbaProject.isPasswordProtected](https://reference.aspose.com/slides/hi/python-java/aspose.slides/vbaproject/#ispasswordprotected) मेथड का प्रयोग करके आप निर्धारित कर सकते हैं कि प्रोजेक्ट की प्रॉपर्टी पासवर्ड-सुरक्षित हैं या नहीं।

1. [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएं और वह प्रस्तुति लोड करें जिसमें मैक्रो हो।
2. जांचें कि प्रस्तुति में [VBA project](https://reference.aspose.com/slides/hi/python-java/aspose.slides/vbaproject/) है या नहीं।
3. देखें कि VBA प्रोजेक्ट पासवर्ड-सुरक्षित है या नहीं ताकि उसकी प्रॉपर्टीज़ देखी जा सकें।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("VBA.pptm")
try:
    # जाँचें कि क्या प्रस्तुतीकरण में VBA प्रोजेक्ट है।
    vba_project = presentation.getVbaProject()
    if vba_project is not None:
        if vba_project.isPasswordProtected():
            print(f"The VBA project '{vba_project.getName()}' is password-protected for viewing its properties.")
finally:
    presentation.dispose()
```

## **अक्सर पूछे जाने वाले प्रश्न**

**यदि मैं प्रस्तुति को PPTX के रूप में सहेजूँ तो मैक्रो के साथ क्या होता है?**

मैक्रो हटा दिए जाएंगे क्योंकि PPTX VBA को समर्थन नहीं देता। मैक्रो रखें के लिए PPTM, PPSM, या POTM चुनें।

**क्या Aspose.Slides प्रस्तुति के भीतर मैक्रो चला सकता है, उदाहरण के लिए डेटा रिफ्रेश करने के लिए?**

नहीं। लाइब्रेरी कभी भी VBA कोड को नहीं चलाती; निष्पादन केवल PowerPoint में उचित सुरक्षा सेटिंग्स के साथ ही संभव है।

**क्या VBA कोड से जुड़े ActiveX कंट्रोल के साथ काम करना समर्थित है?**

हां, आप मौजूदा [ActiveX controls](/slides/hi/python-java/activex/) तक पहुंच सकते हैं, उनके गुण बदल सकते हैं, और उन्हें हटा सकते हैं। यह तब उपयोगी है जब मैक्रो ActiveX के साथ काम करते हैं।