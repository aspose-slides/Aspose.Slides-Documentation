---
title: जावास्क्रिप्ट में प्रस्तुतियों में डिजिटल हस्ताक्षर जोड़ें
linktitle: डिजिटल हस्ताक्षर
type: docs
weight: 10
url: /hi/nodejs-java/digital-signature-in-powerpoint/
keywords:
- डिजिटल हस्ताक्षर
- डिजिटल प्रमाणपत्र
- प्रमाणपत्र प्राधिकरण
- PFX प्रमाणपत्र
- PKCS#12
- हस्ताक्षर सत्यापित करें
- PowerPoint
- PPTX
- प्रस्तुति सुरक्षा
- Node.js
- जावास्क्रिप्ट
- Aspose.Slides
description: "जानें कि कैसे PFX प्रमाणपत्रों के साथ मौजूदा PPTX प्रस्तुतियों पर हस्ताक्षर करें और जावा के माध्यम से Node.js के लिए Aspose.Slides का उपयोग करके डिजिटल हस्ताक्षर को सत्यापित या हटाएँ।"
---
## **अवलोकन**

डिजिटल हस्ताक्षर प्राप्तकर्ता को यह निर्धारित करने में मदद करता है कि प्रस्तुतिकरण पर किसने हस्ताक्षर किया और क्या हस्ताक्षरित सामग्री में परिवर्तन हुआ है। यहाँ तीन संबंधित सुरक्षा अवधारणाएँ महत्वपूर्ण हैं:

- एक **डिजिटल प्रमाणपत्र** एक इलेक्ट्रॉनिक प्रमाणपत्र है जो पहचान को सार्वजनिक कुंजी से जोड़ता है। एक विश्वसनीय प्रमाणपत्र प्राधिकरण (CA) प्रमाणपत्र जारी कर सकता है, या कोई संगठन आंतरिक कार्य प्रवाह के लिए स्वयं‑हस्ताक्षरित प्रमाणपत्र का उपयोग कर सकता है।
- एक **डिजिटल हस्ताक्षर** प्रस्तुति सामग्री और प्रमाणपत्र धारक की निजी कुंजी से निर्मित होता है। प्रमाणपत्र की सार्वजनिक कुंजी का उपयोग तब हस्ताक्षर को सत्यापित करने के लिए किया जा सकता है। एक हस्ताक्षर मूल और अखंडता का प्रमाण प्रदान करता है; यह प्रस्तुति को एन्क्रिप्ट नहीं करता।
- **पासवर्ड संरक्षण** निर्धारित करता है कि उपयोगकर्ता प्रस्तुति को खोल सकता है या संशोधित कर सकता है। यह डिजिटल हस्ताक्षर से अलग है और इसे [पासवर्ड‑सुरक्षित प्रस्तुतियाँ](/nodejs-java/password-protected-presentation/) में वर्णित किया गया है।

PowerPoint **फ़ाइल > जानकारी > प्रस्तुति की सुरक्षा** मेनू के अंतर्गत **Add a Digital Signature** कमांड प्रदान करता है।

![PowerPoint Protect Presentation मेन्यू जिसमें Add a Digital Signature हाइलाइट किया गया है](add-digital-signature-in-powerpoint.png)

हस्ताक्षरित प्रस्तुति खोलने के बाद, PowerPoint एक हस्ताक्षर‑स्थिति सूचना प्रदर्शित कर सकता है।

![PowerPoint सूचना जो बताती है कि प्रस्तुति में वैध हस्ताक्षर मौजूद हैं](digital-signature-status-in-powerpoint.png)

Aspose.Slides [Presentation.getDigitalSignatures](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/#getDigitalSignatures--) के माध्यम से हस्ताक्षर प्रदान करता है, जो एक [DigitalSignatureCollection](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/digitalsignaturecollection/) लौटाता है जिसमें [DigitalSignature](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/digitalsignature/) ऑब्जेक्ट्स होते हैं। एक प्रस्तुति में कई हस्ताक्षर हो सकते हैं।

## **PFX प्रमाणपत्रों और पासवर्ड को समझें**

एक PFX फ़ाइल, जिसे PKCS#12 फ़ाइल भी कहा जाता है और आमतौर पर `.pfx` या `.p12` एक्सटेंशन दिया जाता है, में एक X.509 प्रमाणपत्र, उसकी निजी कुंजी, और प्रमाणपत्र श्रृंखला हो सकती है। निजी कुंजी ही वह है जो धारक को हस्ताक्षर बनाने की अनुमति देती है। एक प्रमाणपत्र जिसके पास उपलब्ध निजी कुंजी नहीं है, उसे प्रस्तुति पर हस्ताक्षर करने के लिए उपयोग नहीं किया जा सकता।

PFX पासवर्ड प्रमाणपत्र पैकेज और निजी कुंजी की रक्षा करता है। यह प्रस्तुति को खोलने या संपादित करने के लिए पासवर्ड **नहीं** है। PFX फ़ाइलें या उनके पासवर्ड को स्रोत नियंत्रण में कमिट न करें। उत्पादन में, प्रमाणपत्र फ़ाइल तक पहुंच को सीमित करें और पासवर्ड को एक सीक्रेट स्टोर या अन्य सुरक्षित कॉन्फ़िगरेशन स्रोत से प्राप्त करें। नीचे के उदाहरण केवल पासवर्ड को कोड में एम्बेड करने से बचने के लिए पर्यावरण चर का उपयोग करते हैं।

## **प्रस्तुति में डिजिटल हस्ताक्षर जोड़ें**

एक वास्तविक प्रस्तुति कार्यप्रवाह पर हस्ताक्षर करने के लिए, मौजूदा PPTX फ़ाइल लोड करें, PFX प्रमाणपत्र और उसके पासवर्ड से एक [DigitalSignature](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/digitalsignature/) बनाएं, हस्ताक्षर को प्रस्तुति के संग्रह में जोड़ें, और PPTX फ़ाइल में सहेजें।

```javascript
const slides = require("aspose.slides.via.java");

const certificatePassword = process.env.PFX_PASSWORD;
if (!certificatePassword) {
    throw new Error("Set the PFX_PASSWORD environment variable.");
}

const presentation = new slides.Presentation("InputPresentation.pptx");
try {
    const signature = new slides.DigitalSignature("signing-certificate.pfx", certificatePassword);
    signature.setComments("Approved for release.");

    presentation.getDigitalSignatures().add(signature);
    presentation.save("InputPresentation-signed.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम को नया नाम देकर सहेजना असाइन्ड स्रोत फ़ाइल को संरक्षित करता है। [DigitalSignature.setComments](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/digitalsignature/) द्वारा सेट किया गया मान हस्ताक्षर के उद्देश्‍य का वर्णन करता है; यह कोई सुरक्षा नियंत्रण नहीं है।

## **डिजिटल हस्ताक्षर सत्यापित करें**

जब आप एक हस्ताक्षरित PPTX फ़ाइल लोड करते हैं, तो [Presentation.getDigitalSignatures](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/#getDigitalSignatures--) द्वारा वापस किए गए प्रत्येक आइटम की जाँच करें। [DigitalSignature.isValid](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/digitalsignature/) मेथड यह दर्शाता है कि एम्बेडेड हस्ताक्षर वर्तमान प्रस्तुति सामग्री के लिए वैध है या नहीं।

निम्न उदाहरण भी प्रत्येक एम्बेडेड प्रमाणपत्र से विषय नाम पढ़ने के लिए Node.js `X509Certificate` क्लास का उपयोग करता है।

```javascript
const { X509Certificate } = require("node:crypto");
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("InputPresentation-signed.pptx");
try {
    const signatures = presentation.getDigitalSignatures();
    const signatureCount = signatures.size();

    if (signatureCount === 0) {
        console.log("The presentation does not contain digital signatures.");
    } else {
        let allSignaturesAreValid = true;

        for (let index = 0; index < signatureCount; index++) {
            const signature = signatures.get_Item(index);
            const signatureIsValid = signature.isValid();
            const signatureStatus = signatureIsValid ? "VALID" : "INVALID";
            const signTime = signature.getSignTime().toString();

            const certificateData = signature.getCertificate();
            const certificate = new X509Certificate(Buffer.from(certificateData));
            const signerName = certificate.subject;

            console.log(`${signerName}, ${signTime} -- ${signatureStatus}`);

            allSignaturesAreValid = allSignaturesAreValid && signatureIsValid;
        }

        if (allSignaturesAreValid) {
            console.log("All embedded signatures are valid for the current presentation.");
        } else {
            console.log("At least one embedded signature is invalid.");
        }
    }
} finally {
    presentation.dispose();
}
```

एक अवैध परिणाम आमतौर पर अर्थ रखता है कि हस्ताक्षरित प्रस्तुति सामग्री या हस्ताक्षर डेटा हस्ताक्षर के बाद बदल गया है, या फ़ाइल क्षतिग्रस्त है। सभी हस्ताक्षर हटाने से एक अनहस्ताक्षरित प्रस्तुति बनती है, इसलिए केवल आइटम की वैधता की जाँच पर्याप्त नहीं है: एक सुरक्षा‑संवेदनशील कार्यप्रवाह को यह भी सत्यापित करना चाहिए कि अपेक्षित संख्या में हस्ताक्षर और अपेक्षित हस्ताक्षरकर्ता पहचानें मौजूद हैं।

इस वैधता परिणाम को पूर्ण प्रमाणपत्र‑विश्वास निर्णय के रूप में नहीं माना जाना चाहिए। आपके सुरक्षा नीति के आधार पर, आपका अनुप्रयोग X.509 प्रमाणपत्र श्रृंखला बनाना और सत्यापित करना, प्रमाणपत्र वैधता तिथियों और निरसन स्थिति की जाँच करना, अपेक्षित विषय या फ़िंगरप्रिंट की पुष्टि करना, कुंजी उपयोग सत्यापित करना, और विश्वसनीय टाइमस्टैम्प का मूल्यांकन करना आवश्यक हो सकता है। [DigitalSignature.getSignTime](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/digitalsignature/) मूल्य स्वयं किसी विश्वसनीय टाइमस्टैम्प प्राधिकरण से प्रमाण नहीं है।

## **डिजिटल हस्ताक्षर हटाएँ**

हस्ताक्षर हटाने से प्रस्तुति की सुरक्षा स्थिति बदलती है। निम्न उदाहरण एक हस्ताक्षरित PPTX फ़ाइल लोड करता है, सभी हस्ताक्षर को [DigitalSignatureCollection.clear](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/digitalsignaturecollection/clear/) से हटाता है, और एक अनहस्ताक्षरित प्रति सहेजता है।

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("InputPresentation-signed.pptx");
try {
    presentation.getDigitalSignatures().clear();
    presentation.save("InputPresentation-unsigned.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

केवल एक हस्ताक्षर हटाने के लिए, उसके शून्य‑आधारित सूचकांक के साथ [DigitalSignatureCollection.removeAt](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/digitalsignaturecollection/removeat/) को कॉल करें। यदि आपके कार्यप्रवाह में हस्ताक्षरित मूल फ़ाइल को ओवरराइट करना स्पष्ट भाग नहीं है, तो नई फ़ाइल में सहेजें।

## **संपादन और स्वरूप विचार**

- हस्ताक्षर प्रस्तुति को केवल‑पढ़ने योग्य नहीं बनाता। उपयोगकर्ता और अनुप्रयोग अभी भी फ़ाइल को संपादित कर सकते हैं, लेकिन हस्ताक्षरित सामग्री में परिवर्तन आमतौर पर मौजूदा हस्ताक्षर को अमान्य कर देता है।
- हस्ताक्षर करने से पहले सभी इच्छित संपादनों को पूरा करें। यदि प्रस्तुति को बदलना आवश्यक है, तो संशोधित प्रस्तुति सहेजें और उस संशोधन पर फिर से हस्ताक्षर करें।
- अंतिम आउटपुट को PPTX स्वरूप में रखें। एक हस्ताक्षरित प्रस्तुति को किसी अन्य स्वरूप में परिवर्तित करने से मूल PPTX हस्ताक्षर को परिवर्तित फ़ाइल के लिए वैध हस्ताक्षर के रूप में नहीं ले जाया जाता।
- प्रमाणपत्र की निजी कुंजी को संवेदनशील मानें। जो कोई भी निजी कुंजी और उसका पासवर्ड प्राप्त करता है, वह ऐसे हस्ताक्षर बना सकता है जो प्रमाणपत्र धारक से आए हुए प्रतीत हों।
- जब आपके दस्तावेज़‑रखरखाव नीति के अनुसार आवश्यक हो, तो अनहस्ताक्षरित स्रोत या कोई अन्य नियंत्रित प्रतिलिपि रखें।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या डिजिटल हस्ताक्षर प्रस्तुति को एन्क्रिप्ट करता है?**

नहीं। डिजिटल हस्ताक्षर मूल और अखंडता का प्रमाण प्रदान करता है, लेकिन प्रस्तुति सामग्री पढ़ने योग्य रहती है जब तक कि अलग से एन्क्रिप्शन नहीं लगाया गया हो। जब सामग्री तक पहुंच को सीमित करना आवश्यक हो, तो [पासवर्ड संरक्षण](/nodejs-java/password-protected-presentation/) का उपयोग करें।

**क्या PFX पासवर्ड प्रस्तुति पासवर्ड के समान है?**

नहीं। PFX पासवर्ड प्रमाणपत्र पैकेज में संग्रहीत निजी कुंजी को अनलॉक करता है। यह यह नियंत्रित नहीं करता कि कौन PPTX फ़ाइल को खोल सकता है या संपादित कर सकता है।

**क्या मैं स्वयं‑हस्ताक्षरित प्रमाणपत्र उपयोग कर सकता हूँ?**

तकनीकी रूप से, स्वयं‑हस्ताक्षरित प्रमाणपत्र का उपयोग किया जा सकता है जब उसमें उपलब्ध निजी कुंजी हो। हालांकि, प्राप्तकर्ता स्वचालित रूप से इसे भरोसा नहीं करेंगे, जब तक कि वह प्रमाणपत्र स्पष्ट रूप से उनके विश्वसनीय वातावरण में नहीं जोड़ा गया हो। सार्वजनिक या क्रॉस‑ऑर्गनाइज़ेशन कार्यप्रवाह सामान्यतः विश्वसनीय CA द्वारा जारी प्रमाणपत्र का उपयोग करते हैं।

**हस्ताक्षर को अमान्य क्या बनाता है?**

हस्ताक्षरित प्रस्तुति सामग्री या हस्ताक्षर डेटा को हस्ताक्षर के बाद बदलना हस्ताक्षर को अमान्य कर सकता है। फ़ाइल क्षति भी सत्यापन को विफल कर सकती है। यदि सभी हस्ताक्षर हटा दिए जाएँ, तो प्रस्तुति अनहस्ताक्षरित हो जाती है, न कि एक अमान्य हस्ताक्षर वाले फ़ाइल की तरह।

**क्या वैध हस्ताक्षर का अर्थ है कि मुझे हस्ताक्षरकर्ता पर भरोसा करना चाहिए?**

केवल अपने आप नहीं। हस्ताक्षर की अखंडता और हस्ताक्षरकर्ता पर भरोसा दो अलग निर्णय हैं। एक उत्पादन सत्यापन नीति को प्रमाणपत्र श्रृंखला, वैधता अवधि, निरसन स्थिति, अपेक्षित पहचान, कुंजी उपयोग, और किसी भी विश्वसनीय टाइमस्टैम्प आवश्यकताओं की भी जाँच करनी चाहिए।

**जब प्रमाणपत्र समाप्त हो जाता है तो क्या होता है?**

प्रमाणपत्र समाप्ति प्रस्तुति बाइट्स को नहीं बदलती, लेकिन यह प्रमाणपत्र‑विश्वास मूल्यांकन को प्रभावित करती है। यह कि हस्ताक्षर स्वीकार्य बना रहता है या नहीं, यह आपके नीति और इस बात पर निर्भर करता है कि क्या एक वैध विश्वसनीय टाइमस्टैम्प प्रमाणित करता है कि हस्ताक्षर तब हुआ था जब प्रमाणपत्र वैध था। केवल प्रदर्शित हस्ताक्षर समय को विश्वसनीय टाइमस्टैम्प के रूप में निर्भर न रहें।

**क्या हस्ताक्षरित प्रस्तुति फिर भी संपादित की जा सकती है?**

हाँ। हस्ताक्षर फाइल को लॉक नहीं करता। हस्ताक्षरित सामग्री को संपादित करने से सामान्यतः मौजूदा हस्ताक्षर अमान्य हो जाता है, इसलिए पहले प्रस्तुति समाप्त करें और अंतिम संशोधन पर हस्ताक्षर करें।

**क्या एक प्रस्तुति में एक से अधिक हस्ताक्षर हो सकते हैं?**

हां। सहेजने से पहले प्रत्येक हस्ताक्षर को [Presentation.getDigitalSignatures](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/#getDigitalSignatures--) द्वारा लौटाए गए संग्रह में जोड़ें। सत्यापन के दौरान, प्रत्येक हस्ताक्षर की जाँच करें और सुनिश्चित करें कि सभी आवश्यक हस्ताक्षरकर्ता मौजूद हैं।

**कौनसे प्रस्तुति स्वरूप इन कार्यों का समर्थन करते हैं?**

Aspose.Slides केवल PPTX के लिए यहाँ वर्णित डिजिटल‑हस्ताक्षर ऑपरेशनों का समर्थन करता है। PPT और OpenDocument प्रस्तुति स्वरूप इस API कार्यप्रवाह द्वारा समर्थित नहीं हैं।

**क्या मैं स्लाइड्स को प्रभावित किए बिना हस्ताक्षर हटा सकता हूँ?**

हां। आप एक हस्ताक्षर हटा सकते हैं या सम्पूर्ण संग्रह को साफ़ करके फिर प्रस्तुति सहेज सकते हैं। स्लाइड सामग्री उपलब्ध रहती है, लेकिन सहेजी गई फ़ाइल अब हटाए गए हस्ताक्षर का प्रमाण नहीं रखती।