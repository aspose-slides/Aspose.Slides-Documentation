---
title: जावास्क्रिप्ट का उपयोग करके प्रस्तुतियों में VBA प्रोजेक्ट्स प्रबंधित करें
linktitle: VBA द्वारा प्रस्तुति
type: docs
weight: 250
url: /hi/nodejs-java/presentation-via-vba/
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
- पावरपॉइंट
- ओपनडॉक्यूमेंट
- प्रस्तुति
- Node.js
- जावास्क्रिप्ट
- Aspose.Slides
description: "Aspose.Slides for Node.js द्वारा Java के माध्यम से जावास्क्रिप्ट में VBA के जरिए PowerPoint और OpenDocument प्रस्तुतियों को जनरेट और संशोधित करें ताकि आपका कार्यप्रवाह आसान हो जाए।"
---
## **परिचय**

Aspose.Slides मैक्रो और VBA कोड के साथ काम करने के लिए कक्षाएं प्रदान करता है।

{{% alert title="Note" color="warning" %}} 
जब आप मैक्रो वाली प्रस्तुति को किसी अलग फ़ाइल फ़ॉर्मेट (PDF, HTML, आदि) में परिवर्तित करते हैं, तो Aspose.Slides सभी मैक्रो को अनदेखा कर देता है (मैक्रो परिणामस्वरूप फ़ाइल में नहीं रखे जाते)।

जब आप प्रस्तुति में मैक्रो जोड़ते हैं या मैक्रो वाली प्रस्तुति को पुनः सहेजते हैं, तो Aspose.Slides केवल मैक्रो के बाइट्स लिखता है।

Aspose.Slides **कभी भी** प्रस्तुति में मैक्रो नहीं चलाता है।
{{% /alert %}}

## **VBA मैक्रो जोड़ें**

Aspose.Slides [VbaProject](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/vbaproject/) क्लास प्रदान करता है ताकि आप VBA प्रोजेक्ट (और प्रोजेक्ट रेफ़रेंसेस) बना सकें और मौजूदा मॉड्यूल को संपादित कर सकें। आप प्रस्तुति में एम्बेडेड VBA को प्रबंधित करने के लिए [VbaProject](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/vbaproject/) क्लास का उपयोग कर सकते हैं।

1. [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation) क्लास का एक इंस्टेंस बनाएँ।
1. नई VBA प्रोजेक्ट जोड़ने के लिए [VbaProject](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/vbaproject/#VbaProject--) कंस्ट्रक्टर का उपयोग करें।
1. VbaProject में एक मॉड्यूल जोड़ें।
1. मॉड्यूल का स्रोत कोड सेट करें।
1. <stdole> के रेफ़रेंसेस जोड़ें।
1. **Microsoft Office** के रेफ़रेंसेस जोड़ें।
1. रेफ़रेंसेस को VBA प्रोजेक्ट से जोड़ें।
1. प्रस्तुति को सहेजें।

यह JavaScript कोड दिखाता है कि कैसे स्क्रैच से प्रस्तुति में VBA मैक्रो जोड़ा जाए:

```javascript
// प्रस्तुति क्लास का एक इंस्टेंस बनाता है
let pres = new aspose.slides.Presentation();
try {
    // एक नया VBA प्रोजेक्ट बनाता है
    pres.setVbaProject(new aspose.slides.VbaProject());
    // VBA प्रोजेक्ट में एक खाली मॉड्यूल जोड़ता है
    let module = pres.getVbaProject().getModules().addEmptyModule("Module");
    // मॉड्यूल का स्रोत कोड सेट करता है
    module.setSourceCode("Sub Test(oShape As Shape)MsgBox Test End Sub");
    // <stdole> का रेफ़रेंस बनाता है
    let stdoleReference = new aspose.slides.VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");
    // Office का रेफ़रेंस बनाता है
    let officeReference = new aspose.slides.VbaReferenceOleTypeLib("Office", "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");
    // VBA प्रोजेक्ट में रेफ़रेंस जोड़ता है
    pres.getVbaProject().getReferences().add(stdoleReference);
    pres.getVbaProject().getReferences().add(officeReference);
    // प्रस्तुति को सहेजता है
    pres.save("test.pptm", aspose.slides.SaveFormat.Pptm);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert color="primary" %}} 
आप **Aspose** [Macro Remover](https://products.aspose.app/slides/hi/remove-macros) को आज़मा सकते हैं, जो PowerPoint, Excel और Word दस्तावेज़ों से मैक्रो हटाने के लिए एक मुफ़्त वेब एप्लिकेशन है। 
{{% /alert %}} 

## **VBA मैक्रो हटाएँ**

[Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation) क्लास के तहत [VbaProject](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/#getVbaProject--) प्रॉपर्टी का उपयोग करके आप VBA मैक्रो को हटा सकते हैं।

1. [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation) क्लास का एक इंस्टेंस बनाकर वह प्रस्तुति लोड करें जिसमें मैक्रो है।
1. मैक्रो मॉड्यूल तक पहुँचें और उसे हटाएँ।
1. संशोधित प्रस्तुति को सहेजें।

यह JavaScript कोड दिखाता है कि कैसे VBA मैक्रो हटाया जाए:

```javascript
// मैक्रो युक्त प्रस्तुति को लोड करता है
let pres = new aspose.slides.Presentation("VBA.pptm");
try {
    // Vba मॉड्यूल तक पहुंचता है और उसे हटाता है
    pres.getVbaProject().getModules().remove(pres.getVbaProject().getModules().get_Item(0));
    // प्रस्तुति को सहेजता है
    pres.save("test.pptm", aspose.slides.SaveFormat.Pptm);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **VBA मैक्रो निकालें**

1. [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation) क्लास का एक इंस्टेंस बनाकर वह प्रस्तुति लोड करें जिसमें मैक्रो है।
2. जांचें कि क्या प्रस्तुति में VBA प्रोजेक्ट मौजूद है।
3. VBA प्रोजेक्ट में मौजूद सभी मॉड्यूलों पर लूप करें ताकि मैक्रो देखे जा सकें।

यह JavaScript कोड दिखाता है कि कैसे मैक्रो वाली प्रस्तुति से VBA मैक्रो निकाला जाए:

```javascript
// मैक्रो युक्त प्रस्तुति को लोड करता है
let pres = new aspose.slides.Presentation("VBA.pptm");
try {
    // जाँचता है कि प्रस्तुति में VBA प्रोजेक्ट है या नहीं
    if (pres.getVbaProject() != null) {
        for (let i = 0; i < pres.getVbaProject().getModules().size(); i++) {
            let module = pres.getVbaProject().getModules().get_Item(i);
            console.log(module.getName());
            console.log(module.getSourceCode());
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **जाँचें कि क्या VBA प्रोजेक्ट पासवर्ड‑सुरक्षित है**

[VbaProject.isPasswordProtected](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/vbaproject/#isPasswordProtected) मेथड का उपयोग करके आप यह निर्धारित कर सकते हैं कि प्रोजेक्ट की प्रॉपर्टीज़ पासवर्ड‑सुरक्षित हैं या नहीं।

1. [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाकर वह प्रस्तुति लोड करें जिसमें मैक्रो है।
2. जांचें कि क्या प्रस्तुति में [VBA project](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/vbaproject/) मौजूद है।
3. देखें कि VBA प्रोजेक्ट पासवर्ड‑सुरक्षित है या नहीं ताकि उसकी प्रॉपर्टीज़ देखी जा सकें।

```js
let presentation = new aspose.slides.Presentation("VBA.pptm");
try {
    if (presentation.getVbaProject() != null) { // जाँचें कि प्रस्तुति में VBA प्रोजेक्ट है या नहीं।
        if (presentation.getVbaProject().isPasswordProtected()) {
            console.log("The VBA Project '%s' is protected by password to view project properties.", 
                    presentation.getVbaProject().getName());
        }
    }
} finally {
    presentation.dispose();
}
```

## **FAQ**

**यदि मैं प्रस्तुति को PPTX के रूप में सहेजूँ तो मैक्रो का क्या होता है?**

PPTX VBA का समर्थन नहीं करता, इसलिए मैक्रो हटा दिए जाएंगे। मैक्रो रखना चाहते हैं तो PPTM, PPSM या POTM चुनें।

**क्या Aspose.Slides प्रस्तुति के भीतर मैक्रो चलाकर, उदाहरण के लिए डेटा रीफ़्रेश कर सकता है?**

नहीं। लाइब्रेरी कभी भी VBA कोड नहीं चलाती; निष्पादन केवल PowerPoint में उचित सुरक्षा सेटिंग्स के साथ संभव है।

**क्या VBA कोड से जुड़े ActiveX नियंत्रणों के साथ काम करना समर्थित है?**

हाँ, आप मौजूदा [ActiveX controls](/slides/hi/nodejs-java/activex/) तक पहुँच सकते हैं, उनकी प्रॉपर्टीज़ बदल सकते हैं, और उन्हें हटा सकते हैं। यह तब उपयोगी होता है जब मैक्रो ActiveX के साथ इंटरैक्ट करते हैं।