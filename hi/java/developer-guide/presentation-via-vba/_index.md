---
title: प्रस्तुति में VBA प्रोजेक्ट्स का प्रबंधन जावा के साथ
linktitle: VBA के माध्यम से प्रस्तुति
type: docs
weight: 250
url: /hi/java/presentation-via-vba/
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
- Java
- Aspose.Slides
description: "Aspose.Slides for Java के साथ VBA के माध्यम से PowerPoint और OpenDocument प्रस्तुतियों को उत्पन्न और हेरफेर करके अपने कार्यप्रवाह को सुव्यवस्थित करें।"
---
## **परिचय**

Aspose.Slides मैक्रोज़ और VBA कोड के साथ काम करने के लिए क्लासेस और इंटरफ़ेसेस प्रदान करता है।

{{% alert title="Note" color="warning" %}} 
जब आप मैक्रोज़ युक्त प्रस्तुति को किसी अलग फ़ाइल फ़ॉर्मेट (PDF, HTML, आदि) में परिवर्तित करते हैं, तो Aspose.Slides सभी मैक्रोज़ को नजरअंदाज़ करता है (मैक्रोज़ परिणामस्वरूप फ़ाइल में नहीं ले जाए जाते)।

जब आप प्रस्तुति में मैक्रोज़ जोड़ते हैं या मैक्रोज़ युक्त प्रस्तुति को पुनः सहेजते हैं, तो Aspose.Slides केवल मैक्रोज़ के बाइट्स को लिखता है।

Aspose.Slides **कभी भी** प्रस्तुति में मैक्रोज़ नहीं चलाता है।
{{% /alert %}}

## **VBA मैक्रोज़ जोड़ें**

Aspose.Slides आपको VBA प्रोजेक्ट बनाने (और प्रोजेक्ट रेफ़रेंसेज़) की अनुमति देने के लिए [VbaProject](https://reference.aspose.com/slides/hi/java/com.aspose.slides/vbaproject/) क्लास प्रदान करता है और मौजूदा मॉड्यूल्स को एडिट कर सकता है। आप प्रस्तुति में एम्बेडेड VBA को प्रबंधित करने के लिए [IVbaProject](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ivbaproject/) इंटरफ़ेस का उपयोग कर सकते हैं।

1. एक [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation) क्लास का उदाहरण बनाएं।
1. नए VBA प्रोजेक्ट को जोड़ने के लिए [VbaProject](https://reference.aspose.com/slides/hi/java/com.aspose.slides/vbaproject/#VbaProject--) कन्स्ट्रक्टर का उपयोग करें।
1. VbaProject में एक मॉड्यूल जोड़ें।
1. मॉड्यूल स्रोत कोड सेट करें।
1. <stdole> के रेफ़रेंसेज़ जोड़ें।
1. **Microsoft Office** के रेफ़रेंसेज़ जोड़ें।
1. रेफ़रेंसेज़ को VBA प्रोजेक्ट के साथ संबद्ध करें।
1. प्रस्तुति को सहेजें।

यह Java कोड आपको दिखाता है कि कैसे शून्य से एक VBA मैक्रो प्रस्तुति में जोड़ें:

```java
// प्रस्तुति क्लास का एक उदाहरण बनाता है
Presentation pres = new Presentation();
try {
    // एक नया VBA प्रोजेक्ट बनाता है
    pres.setVbaProject(new VbaProject());
    
    // VBA प्रोजेक्ट में एक खाली मॉड्यूल जोड़ता है
    IVbaModule module = pres.getVbaProject().getModules().addEmptyModule("Module");
    
    // मॉड्यूल स्रोत कोड सेट करता है
    module.setSourceCode("Sub Test(oShape As Shape)MsgBox Test End Sub");
    
    // <stdole> के लिए एक रेफ़रेंस बनाता है
    VbaReferenceOleTypeLib stdoleReference = new VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");
    
    // Office के लिए एक रेफ़रेंस बनाता है
    VbaReferenceOleTypeLib officeReference = new VbaReferenceOleTypeLib("Office",
            "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");
    
    // VBA प्रोजेक्ट में रेफ़रेंसेज़ जोड़ता है
    pres.getVbaProject().getReferences().add(stdoleReference);
    pres.getVbaProject().getReferences().add(officeReference);
   
    // प्रस्तुति को सहेजता है
    pres.save("test.pptm", SaveFormat.Pptm);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="primary" %}} 
आप **Aspose** के [Macro Remover](https://products.aspose.app/slides/hi/remove-macros) को देख सकते हैं, जो PowerPoint, Excel और Word दस्तावेज़ों से मैक्रोज़ को हटाने के लिए एक निःशुल्क वेब ऐप है। 
{{% /alert %}} 

## **VBA मैक्रोज़ हटाएँ**

आप [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation) क्लास के तहत [VbaProject](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/#getVbaProject--) प्रॉपर्टी का उपयोग करके एक VBA मैक्रो हटा सकते हैं।

1. एक [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation) क्लास का उदाहरण बनाएं और मैक्रो युक्त प्रस्तुति लोड करें।
1. Macro मॉड्यूल तक पहुंचें और उसे हटाएँ।
1. संशोधित प्रस्तुति को सहेजें।

```java
// मैक्रो युक्त प्रस्तुति लोड करता है
Presentation pres = new Presentation("VBA.pptm");
try {
    // Vba मॉड्यूल तक पहुंचता है और उसे हटाता है 
    pres.getVbaProject().getModules().remove(pres.getVbaProject().getModules().get_Item(0));
    
    // प्रस्तुति को सहेजता है
    pres.save("test.pptm", SaveFormat.Pptm);
} finally {
    if (pres != null) pres.dispose();
}
```

## **VBA मैक्रोज़ निकालें**

1. एक [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation) क्लास का उदाहरण बनाएं और मैक्रो युक्त प्रस्तुति लोड करें।
2. जांचें कि प्रस्तुति में VBA प्रोजेक्ट है या नहीं।
3. VBA प्रोजेक्ट में शामिल सभी मॉड्यूल्स पर लूप करें ताकि मैक्रोज़ देखे जा सकें।

```java
// मैक्रो युक्त प्रस्तुति लोड करता है
Presentation pres = new Presentation("VBA.pptm");
try {
    if (pres.getVbaProject() != null) // जाँचता है कि प्रस्तुति में VBA प्रोजेक्ट है या नहीं
    {
        for (IVbaModule module : pres.getVbaProject().getModules())
        {
            System.out.println(module.getName());
            System.out.println(module.getSourceCode());
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **जाँचें कि VBA प्रोजेक्ट पासवर्ड-प्रोटेक्टेड है या नहीं**

आप [IVbaProject.isPasswordProtected](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ivbaproject/#isPasswordProtected--) मेथड का उपयोग करके यह निर्धारित कर सकते हैं कि प्रोजेक्ट की प्रॉपर्टीज़ पासवर्ड-प्रोटेक्टेड हैं या नहीं।

1. एक [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) क्लास का उदाहरण बनाएं और एक मैक्रो युक्त प्रस्तुति लोड करें।
2. जांचें कि प्रस्तुति में [VBA project](https://reference.aspose.com/slides/hi/java/com.aspose.slides/vbaproject/) है या नहीं।
3. VBA प्रोजेक्ट की प्रॉपर्टीज़ देखने के लिए जांचें कि वह पासवर्ड-प्रोटेक्टेड है या नहीं।

```java
Presentation presentation = new Presentation("VBA.pptm");
try {
    if (presentation.getVbaProject() != null) { // जाँचें कि प्रस्तुति में VBA प्रोजेक्ट है या नहीं।
        if (presentation.getVbaProject().isPasswordProtected()) {
            System.out.printf("The VBA Project '%s' is protected by password to view project properties.", 
                    presentation.getVbaProject().getName());
        }
    }
} finally {
    presentation.dispose();
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**यदि मैं प्रस्तुति को PPTX के रूप में सहेजूँ तो मैक्रोज़ के साथ क्या होता है?**  
मैक्रोज़ हटा दिए जाएंगे क्योंकि PPTX VBA का समर्थन नहीं करता। मैक्रोज़ को रख रखने के लिए PPTM, PPSM, या POTM चुनें।

**क्या Aspose.Slides प्रस्तुति के अंदर मैक्रोज़ चला सकता है, उदाहरण के लिए डेटा रिफ्रेश करने के लिए?**  
नहीं। लाइब्रेरी कभी भी VBA कोड को निष्पादित नहीं करती; निष्पादन केवल PowerPoint के भीतर उपयुक्त सुरक्षा सेटिंग्स के साथ संभव है।

**क्या VBA कोड से जुड़े ActiveX कंट्रोल्स के साथ कार्य करना समर्थित है?**  
हैं, आप मौजूदा [ActiveX controls](/slides/hi/java/activex/) तक पहुंच सकते हैं, उनकी प्रॉपर्टीज़ को संशोधित कर सकते हैं, और उन्हें हटा सकते हैं। यह तब उपयोगी होता है जब मैक्रोज़ ActiveX के साथ इंटरैक्ट करते हैं।