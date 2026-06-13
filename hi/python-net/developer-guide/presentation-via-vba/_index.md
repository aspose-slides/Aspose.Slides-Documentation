---
title: Python के माध्यम से प्रस्तुतियों में VBA प्रोजेक्ट्स प्रबंधित करें
linktitle: VBA के माध्यम से प्रस्तुति
type: docs
weight: 250
url: /hi/python-net/presentation-via-vba/
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
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET के साथ VBA के माध्यम से PowerPoint और OpenDocument प्रस्तुतियों को उत्पन्न और संशोधित करने के तरीके जानें, जिससे आपका कार्यप्रवाह सुव्यवस्थित हो सके।"
---
## **अवलोकन**

यह लेख Aspose.Slides for Python via .NET की प्रमुख क्षमताओं की जांच करता है जो PowerPoint प्रस्तुति में मैक्रोज़ के साथ काम करने के लिए है। लाइब्रेरी मैक्रोज़ को जोड़ने, हटाने और निकालने के लिए सुविधाजनक उपकरण प्रदान करती है, जिससे आप प्रस्तुति के निर्माण और संशोधन को स्वचालित कर सकते हैं।

Aspose.Slides के साथ, आप:

- प्रस्तुति विकास को तेज़ कर सकते हैं—रूटीन कार्यों का स्वचालन सामग्री तैयार करने में लगने वाले समय को कम करता है।
- लचीलापन सुनिश्चित कर सकते हैं—मैक्रोज़ को प्रबंधित करने की क्षमता आपको विशिष्ट कार्यों और परिदृश्यों के अनुसार प्रस्तुतियों को अनुकूलित करने देती है।
- डेटा एकीकृत कर सकते हैं—बाहरी डेटा स्रोतों के साथ सरल एकीकरण स्लाइड सामग्री को अद्यतन रखता है।
- रखरखाव को सरल बना सकते हैं—केंद्रीकृत मैक्रो प्रबंधन परिवर्तन लागू करने और प्रस्तुतियों को अपडेट करने को आसान बनाता है।

यह लेख व्यावहारिक उदाहरण प्रस्तुत करता है कि कैसे Aspose.Slides का उपयोग करके PowerPoint में मैक्रोज़ को प्रभावी रूप से काम किया जाए।

[aspose.slides.vba](https://reference.aspose.com/slides/hi/python-net/aspose.slides.vba/) नेमस्पेस मैक्रोज़ और VBA कोड के साथ काम करने के लिए क्लासेज़ प्रदान करता है।

{{% alert title="Note" color="warning" %}}
जब आप कोई प्रस्तुति जिसमें मैक्रोज़ हों, को किसी अन्य फ़ॉर्मेट (PDF, HTML, आदि) में परिवर्तित करते हैं, तो Aspose.Slides मैक्रोज़ को नजरअंदाज़ करता है—वे आउटपुट फ़ाइल में हस्तांतरित नहीं होते हैं।

जब आप प्रस्तुति में मैक्रोज़ जोड़ते हैं या मैक्रोज़ वाली प्रस्तुति को फिर से सहेजते हैं, तो Aspose.Slides मैक्रो बाइट्स को जैसा है वैसा लिख देता है।

Aspose.Slides **कभी नहीं** प्रस्तुति में मैक्रोज़ निष्पादित करता है।
{{% /alert %}}

## **VBA मैक्रो जोड़ें**

Aspose.Slides [VbaProject](https://reference.aspose.com/slides/hi/python-net/aspose.slides.vba/vbaproject/) क्लास प्रदान करता है जिससे आप VBA प्रोजेक्ट (और प्रोजेक्ट रेफ़रेंस) बना सकते हैं और मौजूदा मॉड्यूल को संपादित कर सकते हैं।

1. [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।  
2. नया VBA प्रोजेक्ट जोड़ने के लिए [VbaProject](https://reference.aspose.com/slides/hi/python-net/aspose.slides.vba/vbaproject/#constructors) कंस्ट्रक्टर का उपयोग करें।  
3. VBA प्रोजेक्ट में एक मॉड्यूल जोड़ें।  
4. मॉड्यूल का स्रोत कोड सेट करें।  
5. `<stdole>` के लिए एक रेफ़रेंस जोड़ें।  
6. **Microsoft Office** के लिए एक रेफ़रेंस जोड़ें।  
7. रेफ़रेंसेज़ को VBA प्रोजेक्ट के साथ सम्बद्ध करें।  
8. प्रस्तुति को सहेजें।

निम्न Python कोड दिखाता है कि कैसे शुरू से एक VBA मैक्रो को प्रस्तुति में जोड़ा जाए:

```python
import aspose.slides as slides

# Presentation क्लास का एक इंस्टेंस बनाएँ।
with slides.Presentation() as presentation:

    # एक नया VBA प्रोजेक्ट बनाएँ।
    presentation.vba_project = slides.vba.VbaProject()

    # VBA प्रोजेक्ट में एक खाली मॉड्यूल जोड़ें।
    module = presentation.vba_project.modules.add_empty_module("Module")

    # मॉड्यूल का स्रोत कोड सेट करें।
    module.source_code = """
        Sub Test(oShape As Shape)
            MsgBox "Hello, world!"
        End Sub
    """

    # <stdole> के लिए एक रेफ़रेंस बनाएँ।
    stdole_reference = slides.vba.VbaReferenceOleTypeLib("stdole",
        "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation")

    # Microsoft Office के लिए एक रेफ़रेंस बनाएँ।
    office_reference = slides.vba.VbaReferenceOleTypeLib("Office",
        "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library")

    # रेफ़रेंसेज़ को VBA प्रोजेक्ट में जोड़ें।
    presentation.vba_project.references.add(stdole_reference)
    presentation.vba_project.references.add(office_reference)

    # प्रस्तुति को सहेजें।
    presentation.save("macros.pptm", slides.export.SaveFormat.PPTM)
```

{{% alert color="primary" %}}
आप **Aspose** [Macro Remover](https://products.aspose.app/slides/hi/remove-macros) आज़मा सकते हैं, जो PowerPoint, Excel और Word दस्तावेज़ों से मैक्रोज़ हटाने के लिए एक मुफ्त वेब ऐप है।
{{% /alert %}}

## **VBA मैक्रो हटाएँ**

[Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास की [vba_project](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/vba_project/) प्रॉपर्टी का उपयोग करके आप VBA मैक्रो को हटाने की सुविधा प्राप्त कर सकते हैं।

1. [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं और वह प्रस्तुति लोड करें जिसमें मैक्रो हो।  
2. मैक्रो मॉड्यूल तक पहुँचें और उसे हटाएँ।  
3. संशोधित प्रस्तुति को सहेजें।

निम्न Python कोड दिखाता है कि कैसे VBA मैक्रो को हटाया जाए:

```python
import aspose.slides as slides

# मैक्रो शामिल करने वाली प्रस्तुति को लोड करें।
with slides.Presentation("VBA.pptm") as presentation:
    
    # VBA मॉड्यूल तक पहुँचें।
    vba_module = presentation.vba_project.modules[0]

    # VBA मॉड्यूल हटाएँ।
    presentation.vba_project.modules.remove(vba_module)

    # प्रस्तुति को सहेजें।
    presentation.save("removed_macro.pptm", slides.export.SaveFormat.PPTM)
```

## **VBA मैक्रो निकालें**

[VbaProject](https://reference.aspose.com/slides/hi/python-net/aspose.slides.vba/vbaproject/) क्लास की `modules` प्रॉपर्टी का उपयोग करके आप VBA प्रोजेक्ट के सभी मॉड्यूल तक पहुँच सकते हैं। [VbaModule](https://reference.aspose.com/slides/hi/python-net/aspose.slides.vba/vbamodule/) क्लास का उपयोग करके आप मॉड्यूल की प्रॉपर्टीज़ जैसे नाम और कोड निकाल सकते हैं।

1. [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं और वह प्रस्तुति लोड करें जिसमें मैक्रो हो।  
2. जांचें कि प्रस्तुति में VBA प्रोजेक्ट मौजूद है या नहीं।  
3. VBA प्रोजेक्ट के सभी मॉड्यूल पर लूप चलाकर मैक्रो देखें।

निम्न Python कोड दिखाता है कि कैसे प्रस्तुति से VBA मैक्रो निकाले जाएँ:

```python
import aspose.slides as slides

with slides.Presentation("VBA.pptm") as presentation:
    # जाँचें कि प्रस्तुति में VBA प्रोजेक्ट मौजूद है या नहीं।
    if presentation.vba_project is not None:
        for module in presentation.vba_project.modules:
            print(module.name)
            print(module.source_code)
```

## **जाँचें कि VBA प्रोजेक्ट पासवर्ड-सुरक्षित है या नहीं**

[VbaProject.is_password_protected](https://reference.aspose.com/slides/hi/python-net/aspose.slides.vba/vbaproject/is_password_protected/) प्रॉपर्टी का उपयोग करके आप निर्धारित कर सकते हैं कि प्रोजेक्ट की प्रॉपर्टीज़ पासवर्ड‑सुरक्षित हैं या नहीं।

1. [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं और वह प्रस्तुति लोड करें जिसमें मैक्रो हो।  
2. जाँचें कि प्रस्तुति में एक [VBA project](https://reference.aspose.com/slides/hi/python-net/aspose.slides.vba/vbaproject/) मौजूद है या नहीं।  
3. यह निर्धारित करने के लिए कि VBA प्रोजेक्ट पासवर्ड‑सुरक्षित है या नहीं, उसकी प्रॉपर्टीज़ देखें।

```py
import aspose.slides as slides

with slides.Presentation("VBA.pptm") as presentation:
    # जाँचें कि प्रस्तुति में VBA प्रोजेक्ट मौजूद है या नहीं।
    if presentation.vba_project is not None:
        if presentation.vba_project.is_password_protected:
            print(f"The VBA Project '{presentation.vba_project.name}' is protected by password to view project properties.")
```

## **अक्सर पूछे जाने वाले प्रश्न**

**यदि मैं प्रस्तुति को PPTX के रूप में सहेजूँ तो मैक्रोज़ के साथ क्या होता है?**

मैक्रोज़ हटा दिए जाएंगे क्योंकि PPTX VBA का समर्थन नहीं करता। मैक्रोज़ रखने के लिए PPTM, PPSM, या POTM चुनें।

**क्या Aspose.Slides प्रस्तुति में मैक्रो चलाकर उदाहरण के तौर पर डेटा रीफ़्रेश कर सकता है?**

नहीं। लाइब्रेरी कभी भी VBA कोड निष्पादित नहीं करती; निष्पादन केवल PowerPoint में उचित सुरक्षा सेटिंग्स के साथ संभव है।

**क्या VBA कोड से जुड़ी ActiveX नियंत्रणों के साथ काम करना समर्थित है?**

हाँ, आप मौजूदा [ActiveX controls](/slides/hi/python-net/activex/) तक पहुँच सकते हैं, उनकी प्रॉपर्टीज़ को संशोधित कर सकते हैं, और उन्हें हटा सकते हैं। यह तब उपयोगी होता है जब मैक्रो ActiveX के साथ इंटरैक्ट करते हैं।