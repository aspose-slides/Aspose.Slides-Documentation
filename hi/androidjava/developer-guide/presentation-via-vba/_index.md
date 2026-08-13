---
title: एंड्रॉइड पर प्रस्तुतियों में VBA प्रोजेक्ट प्रबंधित करें
linktitle: VBA के माध्यम से प्रस्तुति
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
description: "Aspose.Slides for Android को Java के माध्यम से उपयोग करके VBA के द्वारा PowerPoint और OpenDocument प्रस्तुतियों को उत्पन्न और संशोधित करना सीखें, जिससे आपका कार्यप्रवाह सुगम हो जाएगा."
---
## **परिचय**

Aspose.Slides मैक्रो और VBA कोड के साथ काम करने के लिए क्लासेस और इंटरफ़ेस प्रदान करता है।

{{% alert title="Note" color="warning" %}} 

जब आप मैक्रो शामिल करने वाली प्रस्तुति को विभिन्न फ़ाइल फ़ॉर्मेट (PDF, HTML, आदि) में परिवर्तित करते हैं, तो Aspose.Slides सभी मैक्रो को नज़रअंदाज़ करता है (मैक्रो परिणामस्वरूप फ़ाइल में नहीं ले जाए जाते)।

जब आप प्रस्तुति में मैक्रो जोड़ते हैं या मैक्रो वाली प्रस्तुति को फिर से सहेजते हैं, तो Aspose.Slides केवल मैक्रो के बाइट्स को लिखता है।

Aspose.Slides **कभी भी** प्रस्तुति में मैक्रो नहीं चलाता है।

{{% /alert %}}

## **VBA मैक्रो जोड़ें**

Aspose.Slides आपको VBA प्रोजेक्ट (और प्रोजेक्ट रेफ़रेंसेज़) बनाने और मौजूदा मॉड्यूल संपादित करने के लिए [VbaProject](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/vbaproject/) क्लास प्रदान करता है। आप प्रस्तुति में एम्बेडेड VBA को प्रबंधित करने के लिए [IVbaProject](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ivbaproject/) इंटरफ़ेस का उपयोग कर सकते हैं।

1. एक [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation) क्लास का उदाहरण बनाएं।
1. नए VBA प्रोजेक्ट को जोड़ने के लिए [VbaProject](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/vbaproject/#VbaProject--) कंस्ट्रक्टर का उपयोग करें।
1. VbaProject में एक मॉड्यूल जोड़ें।
1. मॉड्यूल का स्रोत कोड सेट करें।
1. <stdole> के रेफ़रेंसेज़ जोड़ें।
1. **Microsoft Office** के रेफ़रेंसेज़ जोड़ें।
1. रेफ़रेंसेज़ को VBA प्रोजेक्ट के साथ जोड़ें।
1. प्रस्तुति को सहेजें।

```java
import com.aspose.slides.*;

// प्रस्तुति क्लास का एक उदाहरण बनाता है
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

{{% alert color="info" %}} 

आप **Aspose** [Macro Remover](https://products.aspose.app/slides/hi/remove-macros) को देख सकते हैं, जो PowerPoint, Excel, और Word दस्तावेजों से मैक्रो हटाने के लिए एक मुफ्त वेब एप है। 

{{% /alert %}} 

## **VBA मैक्रो हटाएँ**

[Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation) क्लास के नीचे [VbaProject](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/#getVbaProject--) प्रॉपर्टी का उपयोग करके, आप एक VBA मैक्रो हटा सकते हैं।

1. [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation) क्लास का एक उदाहरण बनाएं और मैक्रो शामिल करने वाली प्रस्तुति लोड करें।
1. Macro मॉड्यूल तक पहुंचें और उसे हटाएँ।
1. परिवर्तित प्रस्तुति को सहेजें।

```java
import com.aspose.slides.*;

// मैक्रो वाले प्रस्तुति को लोड करता है
Presentation pres = new Presentation("VBA.pptm");
try {
    // Vba मॉड्यूल तक पहुँचता है और उसे हटाता है 
    pres.getVbaProject().getModules().remove(pres.getVbaProject().getModules().get_Item(0));
    
    // प्रस्तुति को सहेजता है
    pres.save("test.pptm", SaveFormat.Pptm);
} finally {
    if (pres != null) pres.dispose();
}
```

## **VBA मैक्रो निकालें**

1. [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation) क्लास का एक उदाहरण बनाएं और मैक्रो शामिल करने वाली प्रस्तुति लोड करें।
2. जांचें कि प्रस्तुति में VBA प्रोजेक्ट है या नहीं।
3. VBA प्रोजेक्ट में मौजूद सभी मॉड्यूल पर लूप चलाएँ ताकि मैक्रो देख सकें।

```java
import com.aspose.slides.*;

// मैक्रो वाले प्रस्तुति को लोड करता है
Presentation pres = new Presentation("VBA.pptm");
try {
    if (pres.getVbaProject() != null) // जांचता है कि प्रस्तुति में VBA प्रोजेक्ट है या नहीं
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

## **जाँचें कि VBA प्रोजेक्ट पासवर्ड‑प्रोटेक्टेड है या नहीं**

[IVbaProject.isPasswordProtected](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ivbaproject/#isPasswordProtected--) मेथड का उपयोग करके, आप पता लगा सकते हैं कि प्रोजेक्ट की प्रॉपर्टीज़ पासवर्ड‑प्रोटेक्टेड हैं या नहीं।

1. [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) क्लास का एक उदाहरण बनाएं और एक ऐसी प्रस्तुति लोड करें जिसमें मैक्रो हो।
2. जांचें कि प्रस्तुति में [VBA project](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/vbaproject/) है या नहीं।
3. VBA प्रोजेक्ट के पासवर्ड‑प्रोटेक्टेड होने की जाँच करें ताकि उसकी प्रॉपर्टीज़ देख सकें।

```java
import com.aspose.slides.*;

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

## **FAQ**

### यदि मैं प्रस्तुति को PPTX के रूप में सहेजूँ तो मैक्रो के साथ क्या होता है?

मैक्रो हटाए जाएंगे क्योंकि PPTX VBA को सपोर्ट नहीं करता। मैक्रो को रखना है तो PPTM, PPSM, या POTM चुनें।

### क्या Aspose.Slides प्रस्तुति के अंदर मैक्रो चला सकता है, उदाहरण के लिए डेटा रिफ्रेश करने के लिए?

नहीं। लाइब्रेरी कभी भी VBA कोड नहीं चलाती; निष्पादन केवल PowerPoint के भीतर उचित सुरक्षा सेटिंग्स के साथ ही संभव है।

### क्या VBA कोड से जुड़े ActiveX कंट्रोल्स के साथ काम करना समर्थित है?

हाँ, आप मौजूदा [ActiveX controls](/slides/hi/androidjava/activex/) तक पहुँच सकते हैं, उनकी प्रॉपर्टीज़ बदल सकते हैं, और उन्हें हटा सकते हैं। यह तब उपयोगी होता है जब मैक्रो ActiveX के साथ इंटरेक्ट करते हैं।