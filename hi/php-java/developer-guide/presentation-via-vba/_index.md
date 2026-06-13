---
title: PHP का उपयोग करके प्रस्तुतियों में VBA प्रोजेक्ट्स प्रबंधित करें
linktitle: VBA के माध्यम से प्रस्तुति
type: docs
weight: 250
url: /hi/php-java/presentation-via-vba/
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
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java के साथ VBA के माध्यम से PowerPoint और OpenDocument प्रस्तुतियों को जनरेट और मैनीपुलेट करने के बारे में जानें, जिससे आपका कार्यप्रवाह सुगम हो सके।"
---
## **परिचय**

Aspose.Slides API में मैक्रोज़ और VBA कोड के साथ काम करने के लिए क्लासेस शामिल हैं।

{{% alert title="Note" color="warning" %}} 

जब आप मैक्रो वाले प्रेजेंटेशन को किसी अलग फ़ाइल फ़ॉर्मेट (PDF, HTML, आदि) में परिवर्तित करते हैं, तो Aspose.Slides सभी मैक्रो को नज़रअंदाज़ करता है (मैक्रो परिणामस्वरूप फ़ाइल में नहीं जाते)।

जब आप प्रेजेंटेशन में मैक्रो जोड़ते हैं या मैक्रो वाले प्रेजेंटेशन को फिर से सेव करते हैं, तो Aspose.Slides केवल मैक्रो के बाइट्स को लिखता है।

Aspose.Slides **कभी नहीं** प्रेजेंटेशन में मैक्रो चलाता है।

{{% /alert %}}

## **VBA मैक्रोज़ जोड़ें**

Aspose.Slides [VbaProject](https://reference.aspose.com/slides/hi/php-java/aspose.slides/vbaproject/) क्लास प्रदान करता है जिससे आप VBA प्रोजेक्ट्स (और प्रोजेक्ट रेफ़रेंसेज़) बना सकते हैं और मौजूदा मॉड्यूल संपादित कर सकते हैं। आप `VbaProject` क्लास का उपयोग करके प्रेजेंटेशन में एम्बेडेड VBA को प्रबंधित कर सकते हैं।

1. एक [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation) क्लास की इंस्टेंस बनाएँ।
2. एक नया VBA प्रोजेक्ट जोड़ने के लिए [VbaProject](https://reference.aspose.com/slides/hi/php-java/aspose.slides/vbaproject/#VbaProject) कंस्ट्रक्टर का उपयोग करें।
3. VbaProject में एक मॉड्यूल जोड़ें।
4. मॉड्यूल का सोर्स कोड सेट करें।
5. <stdole> के रेफ़रेंसेज़ जोड़ें।
6. **Microsoft Office** के रेफ़रेंसेज़ जोड़ें।
7. रेफ़रेंसेज़ को VBA प्रोजेक्ट के साथ एसोसिएट करें।
8. प्रेजेंटेशन को सेव करें।

यह PHP कोड दिखाता है कि कैसे शून्य से प्रेजेंटेशन में VBA मैक्रो जोड़ा जाए:

```php
  # प्रस्तुति क्लास का एक इंस्टेंस बनाता है
  $pres = new Presentation();
  try {
    # एक नया VBA प्रोजेक्ट बनाता है
    $pres->setVbaProject(new VbaProject());
    # VBA प्रोजेक्ट में एक खाली मॉड्यूल जोड़ता है
    $module = $pres->getVbaProject()->getModules()->addEmptyModule("Module");
    # मॉड्यूल का स्रोत कोड सेट करता है
    $module->setSourceCode("Sub Test(oShape As Shape)MsgBox Test End Sub");
    # <stdole> के लिए एक रेफ़रेंस बनाता है
    $stdoleReference = new VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");
    # Office के लिए एक रेफ़रेंस बनाता है
    $officeReference = new VbaReferenceOleTypeLib("Office", "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");
    # VBA प्रोजेक्ट में रेफ़रेंसेज़ जोड़ता है
    $pres->getVbaProject()->getReferences()->add($stdoleReference);
    $pres->getVbaProject()->getReferences()->add($officeReference);
    # प्रस्तुति को सेव करता है
    $pres->save("test.pptm", SaveFormat::Pptm);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="primary" %}} 

आप **Aspose** के [Macro Remover](https://products.aspose.app/slides/hi/remove-macros) को देखना चाह सकते हैं, जो PowerPoint, Excel और Word दस्तावेज़ों से मैक्रो हटाने के लिए एक मुफ्त वेब ऐप है। 

{{% /alert %}} 

## **VBA मैक्रोज़ हटाएँ**

आप [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation) क्लास के अंतर्गत [VbaProject](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/#getVbaProject) प्रॉपर्टी का उपयोग करके VBA मैक्रो को हटा सकते हैं।

1. एक [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation) क्लास की इंस्टेंस बनाएँ और मैक्रो वाले प्रेजेंटेशन को लोड करें।
2. मैक्रो मॉड्यूल तक पहुँचें और उसे हटाएँ।
3. संशोधित प्रेजेंटेशन को सेव करें।

```php
  # मैक्रो वाले प्रस्तुति को लोड करता है
  $pres = new Presentation("VBA.pptm");
  try {
    # Vba मॉड्यूल तक पहुँचता है और उसे हटाता है
    $pres->getVbaProject()->getModules()->remove($pres->getVbaProject()->getModules()->get_Item(0));
    # प्रस्तुति को सेव करता है
    $pres->save("test.pptm", SaveFormat::Pptm);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **VBA मैक्रोज़ निकालें**

1. एक [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation) क्लास की इंस्टेंस बनाएँ और मैक्रो वाले प्रेजेंटेशन को लोड करें।
2. जाँचें कि प्रेजेंटेशन में VBA प्रोजेक्ट है या नहीं।
3. VBA प्रोजेक्ट में शामिल सभी मॉड्यूल को लूप करके मैक्रो देखें।

```php
  # मैक्रो वाले प्रस्तुति को लोड करता है
  $pres = new Presentation("VBA.pptm");
  try {
    # जाँचता है कि प्रस्तुति में VBA प्रोजेक्ट है या नहीं
    if (!java_is_null($pres->getVbaProject())) {
      foreach($pres->getVbaProject()->getModules() as $module) {
        echo($module->getName());
        echo($module->getSourceCode());
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **जाँचें कि VBA प्रोजेक्ट पासवर्ड-प्रोटेक्टेड है या नहीं**

आप [VbaProject::isPasswordProtected](https://reference.aspose.com/slides/hi/php-java/aspose.slides/vbaproject/#isPasswordProtected) मेथड का उपयोग करके यह निर्धारित कर सकते हैं कि प्रोजेक्ट की प्रॉपर्टीज़ पासवर्ड-प्रोटेक्टेड हैं या नहीं।

1. एक [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) क्लास की इंस्टेंस बनाएँ और मैक्रो वाला प्रेजेंटेशन लोड करें।
2. जाँचें कि प्रेजेंटेशन में एक [VBA project](https://reference.aspose.com/slides/hi/php-java/aspose.slides/vbaproject/) है या नहीं।
3. प्रॉपर्टीज़ देखने के लिए यह जांचें कि VBA प्रोजेक्ट पासवर्ड-प्रोटेक्टेड है या नहीं।

```php
$presentation = new Presentation("VBA.pptm");
try {
    if ($presentation->getVbaProject() != null) { // जाँचें कि प्रस्तुति में VBA प्रोजेक्ट मौजूद है या नहीं।
        if ($presentation->getVbaProject()->isPasswordProtected()) {
            printf("The VBA Project '%s' is protected by password to view project properties.", 
                    $presentation->getVbaProject()->getName());
        }
    }
} finally {
    $presentation->dispose();
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**यदि मैं प्रेजेंटेशन को PPTX के रूप में सेव करता हूँ तो मैक्रो का क्या होता है?**

मैक्रो हटाए जाएंगे क्योंकि PPTX VBA को सपोर्ट नहीं करता। मैक्रो रखने के लिए PPTM, PPSM, या POTM चुनें।

**क्या Aspose.Slides प्रेजेंटेशन के अंदर मैक्रो चला सकता है, उदाहरण के लिए डेटा रीफ़्रेश करने के लिए?**

नहीं। लाइब्रेरी कभी भी VBA कोड नहीं चलाती; निष्पादन केवल PowerPoint के भीतर उपयुक्त सुरक्षा सेटिंग्स के साथ संभव है।

**क्या VBA कोड से जुड़े ActiveX नियंत्रणों के साथ काम करना समर्थित है?**

हाँ, आप मौजूदा [ActiveX controls](/slides/hi/php-java/activex/) तक पहुँच सकते हैं, उनके प्रॉपर्टीज़ को संशोधित कर सकते हैं, और उन्हें हटा सकते हैं। यह तब उपयोगी है जब मैक्रो ActiveX के साथ इंटरेक्ट करते हैं।