---
title: जावा का उपयोग करके प्रस्तुतियों में VBA प्रोजेक्ट प्रबंधित करें
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
description: "Aspose.Slides for Java के साथ VBA के माध्यम से PowerPoint और OpenDocument प्रस्तुतियों को बनाना और बदलना सीखें ताकि आपका कार्यप्रवाह सुगम हो सके।"
---
## **परिचय**

Aspose.Slides मैक्रो और VBA कोड के साथ काम करने के लिए क्लास और इंटरफ़ेस प्रदान करता है।

{{% alert title="Note" color="warning" %}} 

जब आप मैक्रो वाले प्रेज़ेंटेशन को किसी अन्य फ़ाइल फॉर्मेट (PDF, HTML, आदि) में बदलते हैं, तो Aspose.Slides सभी मैक्रो को अनदेखा कर देता है (मैक्रो परिणामी फ़ाइल में नहीं ले जाए जाते)।

जब आप प्रेज़ेंटेशन में मैक्रो जोड़ते हैं या मैक्रो वाले प्रेज़ेंटेशन को पुनः सहेजते हैं, तो Aspose.Slides केवल मैक्रो के बाइट्स लिखता है।

Aspose.Slides **कभी भी** प्रेज़ेंटेशन में मैक्रो नहीं चलाता है।

{{% /alert %}}

## **VBA मैक्रो जोड़ें**

Aspose.Slides आपको VBA प्रोजेक्ट (और प्रोजेक्ट रेफ़रेंसेज़) बनाने और मौजूदा मॉड्यूल को संपादित करने के लिए [VbaProject](https://reference.aspose.com/slides/hi/java/com.aspose.slides/vbaproject/) क्लास प्रदान करता है। आप प्रेज़ेंटेशन में एम्बेडेड VBA को प्रबंधित करने के लिए [IVbaProject](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ivbaproject/) इंटरफ़ेस का उपयोग कर सकते हैं।

1. [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation) क्लास का एक उदाहरण बनाएं।
1. नया VBA प्रोजेक्ट जोड़ने के लिए [VbaProject](https://reference.aspose.com/slides/hi/java/com.aspose.slides/vbaproject/#VbaProject--) कंस्ट्रक्टर का उपयोग करें।
1. VbaProject में एक मॉड्यूल जोड़ें।
1. मॉड्यूल का स्रोत कोड सेट करें।
1. <stdole> के लिए रेफ़रेंसेज़ जोड़ें।
1. **Microsoft Office** के लिए रेफ़रेंसेज़ जोड़ें।
1. रेफ़रेंसेज़ को VBA प्रोजेक्ट से जोड़ें।
1. प्रेज़ेंटेशन को सहेजें।

यह Java कोड दिखाता है कि कैसे शून्य से एक VBA मैक्रो को प्रेज़ेंटेशन में जोड़ा जाता है:

```java
import com.aspose.slides.*;

// प्रेज़ेंटेशन क्लास का एक उदाहरण बनाता है
Presentation pres = new Presentation();
try {
    // एक नया VBA प्रोजेक्ट बनाता है
    pres.setVbaProject(new VbaProject());
    
    // VBA प्रोजेक्ट में एक खाली मॉड्यूल जोड़ता है
    IVbaModule module = pres.getVbaProject().getModules().addEmptyModule("Module");
    
    // मॉड्यूल का स्रोत कोड सेट करता है
    module.setSourceCode("Sub Test(oShape As Shape)MsgBox Test End Sub");
    
    // <stdole> के लिए रेफ़रेंस बनाता है
    VbaReferenceOleTypeLib stdoleReference = new VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");
    
    // Office के लिए रेफ़रेंस बनाता है
    VbaReferenceOleTypeLib officeReference = new VbaReferenceOleTypeLib("Office",
            "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");
    
    // VBA प्रोजेक्ट में रेफ़रेंस जोड़ता है
    pres.getVbaProject().getReferences().add(stdoleReference);
    pres.getVbaProject().getReferences().add(officeReference);
   
    // प्रेज़ेंटेशन सहेजता है
    pres.save("test.pptm", SaveFormat.Pptm);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="info" %}} 

आप **Aspose** [Macro Remover](https://products.aspose.app/slides/hi/remove-macros) देख सकते हैं, जो PowerPoint, Excel, और Word दस्तावेज़ों से मैक्रो हटाने के लिए एक मुफ्त वेब ऐप है। 

{{% /alert %}} 

## **VBA मैक्रो हटाएँ**

[Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation) क्लास के तहत [VbaProject](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/#getVbaProject--) प्रॉपर्टी का उपयोग करके आप VBA मैक्रो को हटा सकते हैं।

1. उस प्रेज़ेंटेशन को लोड करने के लिए [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation) क्लास का एक उदाहरण बनाएं जिसमें मैक्रो हो।
1. मैक्रो मॉड्यूल तक पहुंचें और उसे हटाएँ।
1. संशोधित प्रेज़ेंटेशन को सहेजें।

यह Java कोड दिखाता है कि कैसे एक VBA मैक्रो को हटाया जाता है:

```java
import com.aspose.slides.*;

// मैक्रो वाले प्रेज़ेंटेशन को लोड करता है
Presentation pres = new Presentation("VBA.pptm");
try {
    // Vba मॉड्यूल तक पहुंचता है और उसे हटाता है 
    pres.getVbaProject().getModules().remove(pres.getVbaProject().getModules().get_Item(0));
    
    // प्रेज़ेंटेशन सहेजता है
    pres.save("test.pptm", SaveFormat.Pptm);
} finally {
    if (pres != null) pres.dispose();
}
```

## **VBA मैक्रो निकालें**

1. [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation) क्लास का एक उदाहरण बनाएं और मैक्रो वाले प्रेज़ेंटेशन को लोड करें।
2. जांचें कि प्रेज़ेंटेशन में VBA प्रोजेक्ट है या नहीं।
3. VBA प्रोजेक्ट में मौजूद सभी मॉड्यूल पर लूप करके मैक्रो देखें।

यह Java कोड दिखाता है कि कैसे मैक्रो वाले प्रेज़ेंटेशन से VBA मैक्रो निकाले जाते हैं:

```java
import com.aspose.slides.*;

// मैक्रो वाले प्रेज़ेंटेशन को लोड करता है
Presentation pres = new Presentation("VBA.pptm");
try {
    if (pres.getVbaProject() != null) // जांचता है कि प्रेज़ेंटेशन में VBA प्रोजेक्ट है या नहीं
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

## **जांचें कि VBA प्रोजेक्ट पासवर्ड-संरक्षित है या नहीं**

[IVbaProject.isPasswordProtected](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ivbaproject/#isPasswordProtected--) मेथड का उपयोग करके आप निर्धारित कर सकते हैं कि प्रोजेक्ट के गुण पासवर्ड से संरक्षित हैं या नहीं।

1. [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) क्लास का एक उदाहरण बनाएं और मैक्रो वाला प्रेज़ेंटेशन लोड करें।
2. जांचें कि प्रेज़ेंटेशन में [VBA project](https://reference.aspose.com/slides/hi/java/com.aspose.slides/vbaproject/) है या नहीं।
3. देखें कि VBA प्रोजेक्ट पासवर्ड-संरक्षित है या नहीं ताकि उसके गुण देख सकें।

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

### यदि मैं प्रेज़ेंटेशन को PPTX के रूप में सहेजूँ तो मैक्रो क्या होते हैं?

मैक्रो हटा दिए जाएंगे क्योंकि PPTX VBA का समर्थन नहीं करता। मैक्रो बनाए रखने के लिए PPTM, PPSM, या POTM चुनें।

### क्या Aspose.Slides प्रेज़ेंटेशन के अंदर मैक्रो चलाकर, उदाहरण के लिए, डेटा रीफ़्रेश कर सकता है?

नहीं। लाइब्रेरी कभी भी VBA कोड नहीं चलाती; निष्पादन केवल PowerPoint में उचित सुरक्षा सेटिंग्स के साथ संभव है।

### क्या VBA कोड से जुड़े ActiveX नियंत्रणों के साथ काम करना समर्थित है?

हाँ, आप मौजूदा [ActiveX controls](/slides/hi/java/activex/) तक पहुंच सकते हैं, उनके गुण संशोधित कर सकते हैं, और उन्हें हटा सकते हैं। यह तब उपयोगी है जब मैक्रो ActiveX के साथ इंटरैक्ट करते हैं।