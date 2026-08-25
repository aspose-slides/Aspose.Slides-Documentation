---
title: जावास्क्रिप्ट में प्रस्तुतियों में डिजिटल हस्ताक्षर जोड़ें
linktitle: डिजिटल हस्ताक्षर
type: docs
weight: 10
url: /hi/nodejs-java/digital-signature-in-powerpoint/
keywords:
- डिजिटल हस्ताक्षर
- डिजिटल प्रमाणपत्र
- प्रमाणपत्र प्राधिकारी
- PFX प्रमाणपत्र
- PKCS#12
- हस्ताक्षर सत्यापित करें
- PowerPoint
- PPTX
- प्रस्तुति सुरक्षा
- Node.js
- JavaScript
- Aspose.Slides
description: "PFX प्रमाणपत्रों के साथ मौजूदा PPTX प्रस्तुतियों पर हस्ताक्षर करना और Aspose.Slides for Node.js को जावा के माध्यम से उपयोग करके डिजिटल हस्ताक्षर सत्यापित या हटाना सीखें।"
---
## **अवलोकन**

डिजिटल हस्ताक्षर प्राप्तकर्ता को यह निर्धारित करने में मदद करता है कि किसने प्रस्तुति पर हस्ताक्षर किया है और क्या हस्ताक्षर किया गया सामग्री बदली है। यहाँ तीन संबंधित सुरक्षा अवधारणाएँ महत्वपूर्ण हैं:

- एक **डिजिटल प्रमाणपत्र** एक इलेक्ट्रॉनिक प्रमाण है जो पहचान को सार्वजनिक कुंजी के साथ जोड़ता है। एक विश्वसनीय प्रमाणपत्र प्राधिकारी (CA) प्रमाणपत्र जारी कर सकता है, या कोई संगठन आंतरिक कार्यप्रवाह के लिए स्व-हस्ताक्षरित प्रमाणपत्र का उपयोग कर सकता है।
- एक **डिजिटल हस्ताक्षर** प्रस्तुति सामग्री और प्रमाणपत्र धारक की निजी कुंजी से बनाया जाता है। फिर प्रमाणपत्र की सार्वजनिक कुंजी का उपयोग करके हस्ताक्षर को सत्यापित किया जा सकता है। एक हस्ताक्षर मूल और अखंडता का प्रमाण प्रदान करता है; यह प्रस्तुति को एन्क्रिप्ट नहीं करता।
- **पासवर्ड सुरक्षा** यह नियंत्रित करती है कि उपयोगकर्ता प्रस्तुति को खोल या संशोधित कर सकता है या नहीं। यह डिजिटल हस्ताक्षर से अलग है और इसे [Password-Protected Presentations](/slides/hi/nodejs-java/password-protected-presentation/) में वर्णित किया गया है।

PowerPoint **File > Info > Protect Presentation** के तहत **Add a Digital Signature** कमांड प्रदान करता है।

![PowerPoint Protect Presentation मेनू जिसमें Add a Digital Signature हाइलाइट किया गया है](add-digital-signature-in-powerpoint.png)

हस्ताक्षरित प्रस्तुति खोलने के बाद, PowerPoint एक हस्ताक्षर-स्थिति सूचना प्रदर्शित कर सकता है।

![PowerPoint सूचना जो बताती है कि प्रस्तुति में मान्य हस्ताक्षर हैं](digital-signature-status-in-powerpoint.png)

Aspose.Slides हस्ताक्षर को [Presentation.getDigitalSignatures](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/#getDigitalSignatures--) के माध्यम से उजागर करता है, जो एक [DigitalSignatureCollection](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/digitalsignaturecollection/) लौटाता है जिसमें [DigitalSignature](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/digitalsignature/) वस्तुएँ होती हैं। एक प्रस्तुति में कई हस्ताक्षर हो सकते हैं।

## **PFX प्रमाणपत्र और पासवर्ड को समझना**

एक PFX फ़ाइल, जिसे PKCS#12 फ़ाइल भी कहा जाता है और आमतौर पर `.pfx` या `.p12` एक्सटेंशन दिया जाता है, इसमें एक X.509 प्रमाणपत्र, उसकी निजी कुंजी और प्रमाणपत्र श्रृंखला हो सकती है। निजी कुंजी वह है जो धारक को हस्ताक्षर बनाने की अनुमति देती है। बिना सुलभ निजी कुंजी वाला प्रमाणपत्र प्रस्तुति पर हस्ताक्षर करने के लिए इस्तेमाल नहीं किया जा सकता।

PFX पासवर्ड प्रमाणपत्र पैकेज और निजी कुंजी की सुरक्षा करता है। यह प्रस्तुति खोलने या संपादित करने के लिए पासवर्ड **नहीं** है। PFX फ़ाइलें या उनके पासवर्ड को स्रोत नियंत्रण में कमिट न करें। उत्पादन में, प्रमाणपत्र फ़ाइल तक पहुंच को सीमित करें और उसका पासवर्ड एक गुप्त स्टोर या किसी अन्य संरक्षित कॉन्फ़िगरेशन स्रोत से प्राप्त करें। नीचे के उदाहरण केवल पासवर्ड को कोड में एम्बेड करने से बचने के लिए पर्यावरण चर (environment variable) का उपयोग करते हैं।

## **प्रस्तुति में डिजिटल हस्ताक्षर जोड़ना**

वास्तविक प्रस्तुति कार्यप्रवाह पर हस्ताक्षर करने के लिए, मौजूदा PPTX फ़ाइल लोड करें, PFX प्रमाणपत्र और उसके पासवर्ड से एक [DigitalSignature](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/digitalsignature/) बनाएं, हस्ताक्षर को प्रस्तुति की संग्रह में जोड़ें, और PPTX फ़ाइल में सहेजें।

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

परिणाम को नए नाम से सहेजने से असहस्ताक्षरित स्रोत फ़ाइल संरक्षित रहती है। [DigitalSignature.setComments](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/digitalsignature/) द्वारा निर्धारित मान हस्ताक्षर के उद्देश्य को वर्णित करता है; यह सुरक्षा नियंत्रण नहीं है।

## **डिजिटल हस्ताक्षर सत्यापित करना**

जब आप एक हस्ताक्षरित PPTX फ़ाइल लोड करते हैं, तो [Presentation.getDigitalSignatures](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/#getDigitalSignatures--) द्वारा लौटाए गए प्रत्येक आइटम की जाँच करें। [DigitalSignature.isValid](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/digitalsignature/) मेथड यह बताता है कि एम्बेडेड हस्ताक्षर वर्तमान प्रस्तुति सामग्री के लिए वैध है या नहीं।

निम्न उदाहरण भी Node.js `X509Certificate` क्लास का उपयोग करके प्रत्येक एम्बेडेड प्रमाणपत्र से विषय नाम पढ़ता है।

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

एक अमान्य परिणाम आमतौर पर यह दर्शाता है कि हस्ताक्षरित प्रस्तुति सामग्री या हस्ताक्षर डेटा हस्ताक्षर के बाद बदल गया है, या फ़ाइल क्षतिग्रस्त है। सभी हस्ताक्षर हटाने से एक असहस्ताक्षरित प्रस्तुति बनती है, इसलिए केवल आइटम की वैधता जाँचना पर्याप्त नहीं है: एक सुरक्षा-संवेदनशील कार्यप्रवाह को यह भी सत्यापित करना चाहिए कि अपेक्षित संख्या में हस्ताक्षर और अपेक्षित हस्ताक्षरकर्ता पहचान मौजूद हैं।

इस वैधता परिणाम को पूर्ण प्रमाणपत्र‑विश्वास निर्णय के रूप में नहीं लेना चाहिए। आपके सुरक्षा नीति के अनुसार, आपके एप्लिकेशन को X.509 प्रमाणपत्र श्रृंखला बनाना और सत्यापित करना, प्रमाणपत्र की वैधता तिथियाँ और निरसन स्थिति जांचना, अपेक्षित विषय या फ़िंगरप्रिंट की पुष्टि करना, कुंजी उपयोग की जाँच करना, और विश्वसनीय टाइमस्टैंप का मूल्यांकन करना भी आवश्यक हो सकता है। [DigitalSignature.getSignTime](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/digitalsignature/) मान केवल स्वयं एक विश्वसनीय टाइमस्टैम्प प्राधिकारी से प्रमाण नहीं है।

## **डिजिटल हस्ताक्षर हटाना**

हस्ताक्षर हटाने से प्रस्तुति की सुरक्षा अवस्था बदलती है। निम्न उदाहरण एक हस्ताक्षरित PPTX फ़ाइल लोड करता है, सभी हस्ताक्षर को [DigitalSignatureCollection.clear](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/digitalsignaturecollection/clear/) से हटाता है, और एक असहस्ताक्षरित कॉपी सहेजता है।

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

केवल एक हस्ताक्षर हटाने के लिए, उसके शून्य‑आधारित इंडेक्स के साथ [DigitalSignatureCollection.removeAt](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/digitalsignaturecollection/removeat/) को कॉल करें। यदि आपके कार्यप्रवाह में हस्ताक्षरित मूल को ओवरराइट करना स्पष्ट नहीं है तो नई फ़ाइल में सहेजें।

## **संपादन और स्वरूप विचार**

- एक हस्ताक्षर प्रस्तुति को केवल‑पढ़ने योग्य नहीं बनाता। उपयोगकर्ता और एप्लिकेशन अभी भी फ़ाइल को संपादित कर सकते हैं, लेकिन हस्ताक्षरित सामग्री में बदलाव आमतौर पर मौजूदा हस्ताक्षर को अमान्य कर देते हैं।
- हस्ताक्षर से पहले सभी इच्छित संशोधन पूर्ण करें। यदि प्रस्तुति को बदलना आवश्यक है, तो संशोधित प्रस्तुति सहेजें और उसी संशोधन पर फिर से हस्ताक्षर करें।
- अंतिम आउटपुट को PPTX स्वरूप में रखें। एक हस्ताक्षरित प्रस्तुति को अन्य स्वरूप में परिवर्तित करने से मूल PPTX हस्ताक्षर को परिवर्तित फ़ाइल के लिए वैध हस्ताक्षर के रूप में स्थानांतरित नहीं किया जाता।
- प्रमाणपत्र की निजी कुंजी को संवेदनशील मानें। जो भी निजी कुंजी और उसका पासवर्ड प्राप्त करता है, वह ऐसे हस्ताक्षर बना सकता है जो उस प्रमाणपत्र धारक से आएँ जैसे दिखें।
- जब आपके दस्तावेज़‑रखरखाव नीति के अनुसार आवश्यक हो, तो असहस्ताक्षरित स्रोत या कोई अन्य नियंत्रित कॉपी रखें।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या डिजिटल हस्ताक्षर प्रस्तुति को एन्क्रिप्ट करता है?**

नहीं। डिजिटल हस्ताक्षर मूल और अखंडता का प्रमाण प्रदान करता है, लेकिन प्रस्तुति सामग्री पढ़ने योग्य रहती है जब तक अलग एन्क्रिप्शन लागू न किया गया हो। जब सामग्री तक पहुंच को प्रतिबंधित करना हो तो [password protection](/slides/hi/nodejs-java/password-protected-presentation/) का उपयोग करें।

**क्या PFX पासवर्ड प्रस्तुति पासवर्ड के समान है?**

नहीं। PFX पासवर्ड प्रमाणपत्र पैकेज में संग्रहीत निजी कुंजी को अनलॉक करता है। यह यह नियंत्रित नहीं करता कि कौन PPTX फ़ाइल को खोल या संपादित कर सकता है।

**क्या मैं स्व-हस्ताक्षरित प्रमाणपत्र उपयोग कर सकता हूँ?**

तकनीकी रूप से, यदि स्व-हस्ताक्षरित प्रमाणपत्र में सुलभ निजी कुंजी शामिल है तो उसे उपयोग किया जा सकता है। प्राप्तकर्ता इसे स्वचालित रूप से भरोसा नहीं करेंगे, जब तक कि उस प्रमाणपत्र को उनके विश्वसनीय वातावरण में स्पष्ट रूप से न जोड़ा गया हो। सार्वजनिक या क्रॉस‑संगठन कार्यप्रवाह आम तौर पर एक विश्वसनीय CA द्वारा जारी प्रमाणपत्र का उपयोग करते हैं।

**हस्ताक्षर को अमान्य क्या बनाता है?**

हस्ताक्षरित प्रस्तुति सामग्री या हस्ताक्षर डेटा को हस्ताक्षर के बाद बदलना हस्ताक्षर को अमान्य कर सकता है। फ़ाइल भ्रष्टाचार भी सत्यापन को विफल कर सकता है। यदि सभी हस्ताक्षर हटा दिए जाते हैं, तो प्रस्तुति असहस्ताक्षरित होती है न कि एक अमान्य हस्ताक्षर वाली फ़ाइल।

**क्या वैध हस्ताक्षर का मतलब है कि मुझे हस्ताक्षरकर्ता पर भरोसा करना चाहिए?**

स्वयं में नहीं। हस्ताक्षर की अखंडता और हस्ताक्षरकर्ता के विश्वास अलग निर्णय हैं। उत्पादन सत्यापन नीति को प्रमाणपत्र श्रृंखला, वैधता अवधि, निरसन स्थिति, अपेक्षित पहचान, कुंजी उपयोग, और किसी भी विश्वसनीय टाइमस्टैम्प आवश्यकताओं की भी जाँच करनी चाहिए।

**प्रमाणपत्र के समाप्त होने पर क्या होता है?**

प्रमाणपत्र का समाप्त होना प्रस्तुति बाइट्स को नहीं बदलता, लेकिन यह प्रमाणपत्र‑विश्वास मूल्यांकन को प्रभावित करता है। यह कि हस्ताक्षर स्वीकार्य बना रहे, यह आपकी नीति और इस बात पर निर्भर करता है कि क्या एक वैध विश्वसनीय टाइमस्टैम्प यह सिद्ध करता है कि हस्ताक्षर तब हुआ जब प्रमाणपत्र वैध था। केवल प्रदर्शित हस्ताक्षर समय पर भरोसा न करें इसे विश्वसनीय टाइमस्टैम्प मानने के लिए।

**क्या एक हस्ताक्षरित प्रस्तुति अभी भी संपादित की जा सकती है?**

हां। हस्ताक्षर फ़ाइल को लॉक नहीं करता। हस्ताक्षरित सामग्री को संपादित करने से आमतौर पर मौजूदा हस्ताक्षर अमान्य हो जाता है, इसलिए पहले प्रस्तुति समाप्त करें और अंतिम संशोधन पर हस्ताक्षर करें।

**क्या एक प्रस्तुति में एक से अधिक हस्ताक्षर हो सकते हैं?**

हां। सहेजने से पहले प्रत्येक हस्ताक्षर को [Presentation.getDigitalSignatures](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/#getDigitalSignatures--) द्वारा लौटाए गए संग्रह में जोड़ें। सत्यापन के दौरान, प्रत्येक हस्ताक्षर की जांच करें और पुष्टि करें कि सभी आवश्यक हस्ताक्षरकर्ता मौजूद हैं।

**कौन से प्रस्तुति स्वरूप इन कार्यों का समर्थन करते हैं?**

Aspose.Slides यहाँ वर्णित डिजिटल‑हस्ताक्षर कार्यों को केवल PPTX के लिए समर्थन करता है। PPT और OpenDocument प्रस्तुति स्वरूप इस API कार्यप्रवाह द्वारा समर्थित नहीं हैं।

**क्या मैं एक हस्ताक्षर को स्लाइड्स को प्रभावित किए बिना हटा सकता हूँ?**

हां। आप एक हस्ताक्षर हटा सकते हैं या पूरी संग्रह को साफ़ कर सकते हैं और फिर प्रस्तुति सहेज सकते हैं। स्लाइड सामग्री उपलब्ध रहती है, लेकिन सहेजी गई फ़ाइल अब हटाए गए हस्ताक्षर के प्रमाण को नहीं रखती।