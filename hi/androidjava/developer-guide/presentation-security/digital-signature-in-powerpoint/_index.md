---
title: एंड्रॉइड पर प्रस्तुतियों में डिजिटल हस्ताक्षर जोड़ें
linktitle: डिजिटल हस्ताक्षर
type: docs
weight: 10
url: /hi/androidjava/digital-signature-in-powerpoint/
keywords:
- डिजिटल हस्ताक्षर
- डिजिटल प्रमाणपत्र
- प्रमाणपत्र प्राधिकरण
- PFX प्रमाणपत्र
- PKCS#12
- हस्ताक्षर सत्यापन
- PowerPoint
- PPTX
- प्रस्तुति सुरक्षा
- Android
- Java
- Aspose.Slides
description: "ऐसे जानें कि कैसे PFX प्रमाणपत्रों के साथ मौजूदा PPTX प्रस्तुतियों पर हस्ताक्षर करें और जावा के माध्यम से Android के लिए Aspose.Slides का उपयोग करके डिजिटल हस्ताक्षरों को सत्यापित या हटाएँ।"
---
## **Overview**

डिजिटल हस्ताक्षर प्राप्तकर्ता को यह निर्धारित करने में मदद करता है कि किसने प्रस्तुति पर हस्ताक्षर किया है और क्या हस्ताक्षरित सामग्री बदल गई है। यहाँ तीन संबंधित सुरक्षा अवधारणाएँ महत्वपूर्ण हैं:

- एक **डिजिटल प्रमाणपत्र** एक इलेक्ट्रॉनिक क्रेडेंशियल है जो एक पहचान को सार्वजनिक कुंजी से जोड़ती है। एक विश्वसनीय प्रमाणपत्र प्राधिकरण (CA) प्रमाणपत्र जारी कर सकता है, या कोई संस्था आंतरिक कार्यप्रवाहों के लिए स्वयं‑हस्ताक्षरित प्रमाणपत्र का उपयोग कर सकती है।
- एक **डिजिटल हस्ताक्षर** प्रस्तुति सामग्री और प्रमाणपत्र धारक की निजी कुंजी से बनाया जाता है। फिर प्रमाणपत्र की सार्वजनिक कुंजी का उपयोग करके हस्ताक्षर को सत्यापित किया जा सकता है। हस्ताक्षर मूल और अखंडता का प्रमाण प्रदान करता है; यह प्रस्तुति को एन्क्रिप्ट नहीं करता।
- **पासवर्ड संरक्षण** नियंत्रित करता है कि उपयोगकर्ता प्रस्तुति को खोल या संशोधित कर सकता है या नहीं। यह डिजिटल हस्ताक्षर से अलग है और इसे [Password‑Protected Presentations](/slides/hi/androidjava/password-protected-presentation/) में वर्णित किया गया है।

PowerPoint **File > Info > Protect Presentation** के तहत **Add a Digital Signature** कमांड प्रदान करता है।

![PowerPoint Protect Presentation मेन्यू जिसमें Add a Digital Signature हाइलाइट किया गया है](add-digital-signature-in-powerpoint.png)

हस्ताक्षरित प्रस्तुति खोलने के बाद, PowerPoint एक हस्ताक्षर‑स्थिति सूचना प्रदर्शित कर सकता है।

![PowerPoint सूचना जो दर्शाती है कि प्रस्तुति में वैध हस्ताक्षर हैं](digital-signature-status-in-powerpoint.png)

Aspose.Slides हस्ताक्षर को [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipresentation/#getDigitalSignatures--) के माध्यम से उजागर करता है, जो एक [IDigitalSignatureCollection](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/idigitalsignaturecollection/) लौटाता है, जिसके आइटम [IDigitalSignature](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/idigitalsignature/) को लागू करते हैं। एक प्रस्तुति में कई हस्ताक्षर हो सकते हैं।

## **Understand PFX Certificates and Passwords**

एक PFX फ़ाइल, जिसे PKCS#12 फ़ाइल भी कहा जाता है और आमतौर पर `.pfx` या `.p12` एक्सटेंशन के साथ दी जाती है, एक X.509 प्रमाणपत्र, उसकी निजी कुंजी, और प्रमाणपत्र श्रृंखला रख सकती है। निजी कुंजी वह है जो धारक को हस्ताक्षर बनाने की अनुमति देती है। बिना पहुँच योग्य निजी कुंजी वाला प्रमाणपत्र प्रस्तुति पर हस्ताक्षर करने के लिए प्रयोग नहीं किया जा सकता।

PFX पासवर्ड प्रमाणपत्र पैकेज और निजी कुंजी की रक्षा करता है। यह प्रस्तुति को खोलने या संपादित करने के लिए पासवर्ड **नहीं** है। PFX फ़ाइलों या उनके पासवर्ड को सोर्स कंट्रोल में कमिट न करें। उत्पादन में, प्रमाणपत्र फ़ाइल तक पहुँच को सीमित रखें और उसका पासवर्ड सीक्रेट स्टोर या किसी अन्य संरक्षित कॉन्फ़िगरेशन स्रोत से प्राप्त करें। नीचे दिए गए उदाहरण केवल पासवर्ड को कोड में एम्बेड करने से बचने के लिए पर्यावरण चर का उपयोग करते हैं।

## **Add a Digital Signature to a Presentation**

वास्तविक प्रस्तुति कार्यप्रवाह पर हस्ताक्षर करने के लिए, मौजूदा PPTX फ़ाइल लोड करें, PFX प्रमाणपत्र और उसके पासवर्ड से एक [DigitalSignature](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/digitalsignature/) बनाएं, हस्ताक्षर को प्रस्तुति के संग्रह में जोड़ें, और PPTX फ़ाइल के रूप में सहेजें।

```java
import com.aspose.slides.*;

String certificatePassword = System.getenv("PFX_PASSWORD");
if (certificatePassword == null || certificatePassword.isEmpty()) {
    throw new IllegalStateException("Set the PFX_PASSWORD environment variable.");
}

Presentation presentation = new Presentation("InputPresentation.pptx");
try {
    DigitalSignature signature = new DigitalSignature("signing-certificate.pfx", certificatePassword);
    signature.setComments("Approved for release.");

    presentation.getDigitalSignatures().add(signature);
    presentation.save("InputPresentation-signed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम को नई फ़ाइल नाम के तहत सहेजने से अनहस्ताक्षरित स्रोत फ़ाइल सुरक्षित रहती है। [IDigitalSignature.setComments](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/idigitalsignature/#setComments-java.lang.String-) द्वारा सेट किया गया मान हस्ताक्षर का उद्देश्य बताता है; यह कोई सुरक्षा नियंत्रण नहीं है।

## **Validate Digital Signatures**

जब आप एक हस्ताक्षरित PPTX फ़ाइल लोड करते हैं, तो [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipresentation/#getDigitalSignatures--) द्वारा लौटाए गए प्रत्येक आइटम की जाँच करें। [IDigitalSignature.isValid](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/idigitalsignature/#isValid--) मेथड दर्शाता है कि एम्बेडेड हस्ताक्षर वर्तमान प्रस्तुति सामग्री के लिए वैध है या नहीं।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("InputPresentation-signed.pptx");
try {
    IDigitalSignatureCollection signatures = presentation.getDigitalSignatures();
    int signatureCount = signatures.size();

    if (signatureCount == 0) {
        System.out.println("The presentation does not contain digital signatures.");
    } else {
        boolean allSignaturesAreValid = true;
        java.text.SimpleDateFormat signTimeFormat = new java.text.SimpleDateFormat("yyyy-MM-dd HH:mm:ss");
        java.security.cert.CertificateFactory certificateFactory = java.security.cert.CertificateFactory.getInstance("X.509");

        for (IDigitalSignature signature : signatures) {
            boolean signatureIsValid = signature.isValid();
            String signatureStatus = signatureIsValid ? "VALID" : "INVALID";
            java.util.Date signTime = signature.getSignTime();
            String formattedSignTime = signTimeFormat.format(signTime);

            byte[] certificateData = signature.getCertificate();
            java.io.ByteArrayInputStream certificateStream = new java.io.ByteArrayInputStream(certificateData);
            java.security.cert.X509Certificate certificate = (java.security.cert.X509Certificate) certificateFactory.generateCertificate(certificateStream);
            javax.security.auth.x500.X500Principal signerPrincipal = certificate.getSubjectX500Principal();
            String signerName = signerPrincipal.getName();

            System.out.println(signerName + ", " + formattedSignTime + " -- " + signatureStatus);

            allSignaturesAreValid &= signatureIsValid;
        }

        if (allSignaturesAreValid) {
            System.out.println("All embedded signatures are valid for the current presentation.");
        } else {
            System.out.println("At least one embedded signature is invalid.");
        }
    }
} finally {
    presentation.dispose();
}
```

एक अमान्य परिणाम आम तौर पर इस बात का संकेत देता है कि हस्ताक्षरित प्रस्तुति सामग्री या हस्ताक्षर डेटा हस्ताक्षर के बाद बदल गया है, या फ़ाइल क्षतिग्रस्त है। सभी हस्ताक्षर हटाने से प्रस्तुति अनहस्ताक्षरित हो जाती है, इसलिए केवल आइटम की वैधता की जाँच पर्याप्त नहीं है: एक सुरक्षा‑संवेदनशील कार्यप्रवाह को अपेक्षित हस्ताक्षर संख्या और अपेक्षित हस्ताक्षरकर्ता पहचान की भी पुष्टि करनी चाहिए।

यह वैधता परिणाम पूर्ण प्रमाणपत्र‑विश्वास निर्णय के रूप में नहीं माना जाना चाहिए। आपके सुरक्षा नीति के आधार पर, आपके अनुप्रयोग को X.509 प्रमाणपत्र श्रृंखला बनाना और सत्यापित करना, प्रमाणपत्र की वैधता तिथियों और रद्दीकरण स्थिति की जाँच करना, अपेक्षित विषय या थंबप्रिंट की पुष्टि करना, कुंजी उपयोग सत्यापित करना, और विश्वसनीय टाइम‑स्टैंप का मूल्यांकन करना भी आवश्यक हो सकता है। केवल [IDigitalSignature.getSignTime](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/idigitalsignature/#getSignTime--) का मूल्य स्वयं विश्वसनीय टाइम‑स्टैंप प्राधिकरण का प्रमाण नहीं है।

## **Remove Digital Signatures**

हस्ताक्षर हटाने से प्रस्तुति की सुरक्षा स्थिति बदलती है। निम्न उदाहरण एक हस्ताक्षरित PPTX फ़ाइल लोड करता है, सभी हस्ताक्षरों को [IDigitalSignatureCollection.clear](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/idigitalsignaturecollection/#clear--) से हटाता है, और अनहस्ताक्षरित प्रति सहेजता है।

```java
Presentation presentation = new Presentation("InputPresentation-signed.pptx");
try {
    presentation.getDigitalSignatures().clear();
    presentation.save("InputPresentation-unsigned.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

सिर्फ एक हस्ताक्षर हटाने के लिए, उसके शून्य‑आधारित इंडेक्स के साथ [IDigitalSignatureCollection.removeAt](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/idigitalsignaturecollection/#removeAt-int-) को कॉल करें। नई फ़ाइल में सहेजें, जब तक कि हस्ताक्षरित मूल को अधिलेखित करना आपके कार्यप्रवाह का स्पष्ट हिस्सा न हो।

## **Editing and Format Considerations**

- हस्ताक्षर प्रस्तुति को केवल‑पढ़ने योग्य नहीं बनाता। उपयोगकर्ता और अनुप्रयोग अभी भी फ़ाइल को संपादित कर सकते हैं, लेकिन हस्ताक्षरित सामग्री में परिवर्तन आम तौर पर मौजूदा हस्ताक्षर को अमान्य कर देता है।
- हस्ताक्षर करने से पहले सभी इच्छित संपादन समाप्त कर लें। यदि प्रस्तुति को बदलना आवश्यक है, तो संशोधित प्रस्तुति सहेजें और उस संशोधन पर फिर से हस्ताक्षर करें।
- अंतिम आउटपुट को PPTX फ़ॉर्मेट में रखें। हस्ताक्षरित प्रस्तुति को किसी अन्य फ़ॉर्मेट में परिवर्तित करने से मूल PPTX हस्ताक्षर वैध हस्ताक्षर के रूप में परिवर्तित फ़ाइल में नहीं रहता।
- प्रमाणपत्र की निजी कुंजी को संवेदनशील मानें। जो भी निजी कुंजी और उसका पासवर्ड प्राप्त कर लेता है, वह उस प्रमाणपत्र धारक की ओर से हस्ताक्षर बना सकता है।
- जब आपके दस्तावेज़‑रिटेंशन नीति में यह आवश्यक हो, तो अनहस्ताक्षरित स्रोत या कोई अन्य नियंत्रित प्रतिलिपि सुरक्षित रखें।

## **FAQ**

**क्या डिजिटल हस्ताक्षर प्रस्तुति को एन्क्रिप्ट करता है?**

नहीं। डिजिटल हस्ताक्षर मूल और अखंडता का प्रमाण देता है, लेकिन प्रस्तुति सामग्री तब तक पढ़ी जा सकती है जब तक अलग से एन्क्रिप्शन न किया गया हो। जब सामग्री तक पहुँच प्रतिबंधित करनी हो, तो [password protection](/slides/hi/androidjava/password-protected-presentation/) का प्रयोग करें।

**क्या PFX पासवर्ड प्रस्तुति पासवर्ड के समान है?**

नहीं। PFX पासवर्ड प्रमाणपत्र पैकेज में संग्रहीत निजी कुंजी को अनलॉक करता है। यह यह नियंत्रित नहीं करता कि कौन PPTX फ़ाइल को खोल या संपादित कर सकता है।

**क्या मैं स्वयं‑हस्ताक्षरित प्रमाणपत्र का उपयोग कर सकता हूँ?**

तकनीकी रूप से, यदि उसमे पहुँच योग्य निजी कुंजी है तो स्वयं‑हस्ताक्षरित प्रमाणपत्र का उपयोग किया जा सकता है। प्राप्तकर्ता स्वचालित रूप से इसे विश्वास नहीं करेंगे, जब तक कि वह प्रमाणपत्र उनके विश्वसनीय वातावरण में स्पष्ट रूप से जोड़ा न गया हो। सार्वजनिक या क्रॉस‑ऑर्गनाइज़ेशन कार्यप्रवाह आमतौर पर विश्वसनीय CA द्वारा जारी प्रमाणपत्र का उपयोग करते हैं।

**हस्ताक्षर को अमान्य क्या बनाता है?**

हस्ताक्षरित प्रस्तुति सामग्री या हस्ताक्षर डेटा को हस्ताक्षर के बाद बदलना हस्ताक्षर को अमान्य कर देता है। फ़ाइल क्षति भी सत्यापन को विफल कर सकती है। यदि सभी हस्ताक्षर हटाए जाएँ, तो प्रस्तुति अनहस्ताक्षरित रहती है, न कि अमान्य हस्ताक्षर वाली फ़ाइल।

**क्या वैध हस्ताक्षर का अर्थ है कि मुझे हस्ताक्षरकर्ता पर भरोसा होना चाहिए?**

केवल इसके आधार पर नहीं। हस्ताक्षर की अखंडता और हस्ताक्षरकर्ता का विश्वास अलग‑अलग निर्णय हैं। उत्पादन सत्यापन नीति को प्रमाणपत्र श्रृंखला, वैधता अवधि, रद्दीकरण स्थिति, अपेक्षित पहचान, कुंजी उपयोग, और किसी भी विश्वसनीय टाइम‑स्टैंप आवश्यकताओं की भी जाँच करनी चाहिए।

**जब प्रमाणपत्र समाप्त हो जाता है तो क्या होता है?**

प्रमाणपत्र की समाप्ति प्रस्तुति बाइट्स को नहीं बदलती, लेकिन प्रमाणपत्र‑विश्वास मूल्यांकन को प्रभावित करती है। एक हस्ताक्षर स्वीकार्य बना रहता है या नहीं, यह आपकी नीति और यह कि क्या एक वैध विश्वसनीय टाइम‑स्टैंप यह साबित करता है कि हस्ताक्षर करते समय प्रमाणपत्र वैध था, इस पर निर्भर करता है। केवल प्रदर्शित हस्ताक्षर समय को विश्वसनीय टाइम‑स्टैंप के रूप में न मानें।

**क्या एक हस्ताक्षरित प्रस्तुति अभी भी संपादित की जा सकती है?**

हां। हस्ताक्षर फ़ाइल को लॉक नहीं करता। हस्ताक्षरित सामग्री को संपादित करने से आम तौर पर मौजूदा हस्ताक्षर अमान्य हो जाता है, इसलिए पहले प्रस्तुति को समाप्त कर लें और अंतिम संशोधन पर हस्ताक्षर करें।

**क्या एक प्रस्तुति में एक से अधिक हस्ताक्षर हो सकते हैं?**

हां। सहेजने से पहले प्रत्येक हस्ताक्षर को [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipresentation/#getDigitalSignatures--) द्वारा लौटाए गए संग्रह में जोड़ें। सत्यापन के दौरान प्रत्येक हस्ताक्षर की जाँच करें और सुनिश्चित करें कि सभी आवश्यक हस्ताक्षरकर्ता उपस्थित हों।

**कौन‑से प्रस्तुति फ़ॉर्मेट इन कार्यों का समर्थन करते हैं?**

Aspose.Slides यहाँ वर्णित डिजिटल‑हस्ताक्षर कार्यों को केवल PPTX के लिए समर्थन करता है। PPT और OpenDocument प्रस्तुति फ़ॉर्मेट इस API कार्यप्रवाह द्वारा समर्थित नहीं हैं।

**क्या मैं स्लाइड्स को प्रभावित किए बिना हस्ताक्षर हटाएँ?**

हां। आप एक हस्ताक्षर हटा सकते हैं या पूरी संग्रह को साफ़ कर सकते हैं और फिर प्रस्तुति सहेज सकते हैं। स्लाइड सामग्री बनी रहती है, लेकिन सहेजी गई फ़ाइल में अब हटाए गए हस्ताक्षर का प्रमाण नहीं रहता।