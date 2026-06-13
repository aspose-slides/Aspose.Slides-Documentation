---
title: Android पर प्रस्तुतियों में VBA प्रोजेक्ट प्रबंधन
linktitle: VBA द्वारा प्रस्तुति
type: docs
weight: 250
url: /hi/androidjava/presentation-via-vba/
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
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java के साथ VBA के माध्यम से PowerPoint और OpenDocument प्रस्तुतियों को उत्पन्न और परिवर्तित करने के तरीके को जानें, ताकि आपका कार्यप्रवाह सुव्यवस्थित हो सके।"
---
## **Introduction**

Aspose.Slides मैक्रो और VBA कोड के साथ काम करने के लिए क्लास और इंटरफ़ेस प्रदान करता है।

{{% alert title="Note" color="warning" %}} 

जब आप मैक्रो वाले प्रस्तुतीकरण को किसी अलग फ़ाइल फ़ॉर्मेट (PDF, HTML, आदि) में परिवर्तित करते हैं, तो Aspose.Slides सभी मैक्रो को अनदेखा करता है (मैक्रो परिणामस्वरूप फ़ाइल में नहीं रखे जाते)।

जब आप प्रस्तुतीकरण में मैक्रो जोड़ते हैं या मैक्रो वाले प्रस्तुतीकरण को फिर से सहेजते हैं, तो Aspose.Slides केवल मैक्रो के बाइट्स को लिखता है।

Aspose.Slides **कभी नहीं** प्रस्तुतीकरण में मैक्रो चलाता है।

{{% /alert %}}

## **Add VBA Macros**

Aspose.Slides आपको VBA प्रोजेक्ट (और प्रोजेक्ट रेफ़रेंसेज़) बनाने और मौजूदा मॉड्यूल संपादित करने के लिए [VbaProject](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/vbaproject/) क्लास प्रदान करता है। आप प्रस्तुतीकरण में एम्बेडेड VBA को प्रबंधित करने के लिए [IVbaProject](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ivbaproject/) इंटरफ़ेस का उपयोग कर सकते हैं।

1. [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation) क्लास का एक इंस्टेंस बनाएं।
2. [VbaProject](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/vbaproject/#VbaProject--) कन्स्ट्रक्टर का उपयोग करके नया VBA प्रोजेक्ट जोड़ें।
3. VbaProject में एक मॉड्यूल जोड़ें।
4. मॉड्यूल स्रोत कोड सेट करें।
5. <stdole> के लिए रेफ़रेंसेज़ जोड़ें।
6. **Microsoft Office** के लिए रेफ़रेंसेज़ जोड़ें।
7. रेफ़रेंसेज़ को VBA प्रोजेक्ट से जोड़ें।
8. प्रस्तुतीकरण सहेजें।

यह Java कोड दिखाता है कि कैसे शून्य से प्रस्तुतीकरण में VBA मैक्रो जोड़ा जाए:

```java
// प्रस्तुति क्लास का एक इंस्टेंस बनाता है
Presentation pres = new Presentation();
try {
    // एक नया VBA प्रोजेक्ट बनाता है
    pres.setVbaProject(new VbaProject());
    
    // VBA प्रोजेक्ट में एक खाली मॉड्यूल जोड़ता है
    IVbaModule module = pres.getVbaProject().getModules().addEmptyModule("Module");
    
    // मॉड्यूल का स्रोत कोड सेट करता है
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

आप चाहेंगे कि **Aspose** का [Macro Remover](https://products.aspose.app/slides/hi/remove-macros) देखें, जो PowerPoint, Excel और Word दस्तावेज़ों से मैक्रो हटाने के लिए एक मुफ्त वेब ऐप है। 

{{% /alert %}} 

## **Remove VBA Macros**

[Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation) क्लास के अंतर्गत [VbaProject](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/#getVbaProject--) प्रॉपर्टी का उपयोग करके आप VBA मैक्रो हटा सकते हैं।

1. [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation) क्लास का एक इंस्टेंस बनाएं और मैक्रो वाले प्रस्तुतीकरण को लोड करें।
2. Macro मॉड्यूल तक पहुंचें और उसे हटाएं।
3. संशोधित प्रस्तुतीकरण सहेजें।

यह Java कोड दिखाता है कि कैसे VBA मैक्रो हटाया जाए:

```java
// मैक्रो वाले प्रस्तुतीकरण को लोड करता है
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

## **Extract VBA Macros**

1. [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation) क्लास का एक इंस्टेंस बनाएं और मैक्रो वाले प्रस्तुतीकरण को लोड करें।
2. जाँचें कि प्रस्तुतीकरण में VBA प्रोजेक्ट है या नहीं।
3. मैक्रो देखने के लिए VBA प्रोजेक्ट में मौजूद सभी मॉड्यूल पर लूप करें।

यह Java कोड दिखाता है कि कैसे मैक्रो वाले प्रस्तुतीकरण से VBA मैक्रो निकाले जाएँ:

```java
// मैक्रो वाले प्रस्तुतीकरण को लोड करता है
Presentation pres = new Presentation("VBA.pptm");
try {
    if (pres.getVbaProject() != null) // जाँचता है कि प्रस्तुतीकरण में VBA प्रोजेक्ट है या नहीं
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

## **Check Whether a VBA Project Is Password-Protected**

[IVbaProject.isPasswordProtected](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ivbaproject/#isPasswordProtected--) मेथड का उपयोग करके आप निर्धारित कर सकते हैं कि प्रोजेक्ट की प्रॉपर्टीज़ पासवर्ड-प्रोटेक्टेड हैं या नहीं।

1. [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं और मैक्रो वाला प्रस्तुतीकरण लोड करें।
2. जाँचें कि प्रस्तुतीकरण में [VBA project](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/vbaproject/) है या नहीं।
3. VBA प्रोजेक्ट पासवर्ड-प्रोटेक्टेड है या नहीं, यह जाँचें ताकि उसकी प्रॉपर्टीज़ देखी जा सकें।

```java
Presentation presentation = new Presentation("VBA.pptm");
try {
    if (presentation.getVbaProject() != null) { // जाँचें कि प्रस्तुतीकरण में VBA प्रोजेक्ट है या नहीं।
        if (presentation.getVbaProject().isPasswordProtected()) {
            System.out.printf("The VBA Project '%s' is protected by password to view project properties.", 
                    presentation.getVbaProject().getName());
        }
    }
} finally {
    presentation.dispose();
}
```

## **FAQ**

**यदि मैं प्रस्तुतीकरण को PPTX के रूप में सहेजूँ तो मैक्रो क्या होते हैं?**

मैक्रो हटा दिए जाएंगे क्योंकि PPTX VBA को सपोर्ट नहीं करता। मैक्रो रखने के लिए PPTM, PPSM, या POTM चुनें।

**क्या Aspose.Slides प्रस्तुतीकरण के भीतर मैक्रो चला सकता है, जैसे डेटा रीफ़्रेश करना?**

नहीं। लाइब्रेरी कभी भी VBA कोड निष्पादित नहीं करती; निष्पादन केवल उपयुक्त सुरक्षा सेटिंग्स के साथ PowerPoint के अंदर संभव है।

**क्या VBA कोड से जुड़ी ActiveX कंट्रोल्स के साथ काम करना समर्थित है?**

हाँ, आप मौजूदा [ActiveX controls](/slides/hi/androidjava/activex/) तक पहुँचा सकते हैं, उनकी प्रॉपर्टीज़ संशोधित कर सकते हैं, और उन्हें हटा सकते हैं। यह तब उपयोगी है जब मैक्रो ActiveX के साथ इंटरैक्ट करते हैं।