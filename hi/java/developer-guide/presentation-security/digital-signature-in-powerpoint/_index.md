---
title: जावा में प्रस्तुतियों में डिजिटल सिग्नेचर जोड़ें
linktitle: डिजिटल सिग्नेचर
type: docs
weight: 10
url: /hi/java/digital-signature-in-powerpoint/
keywords:
- डिजिटल सिग्नेचर
- डिजिटल प्रमाणपत्र
- प्रमाणपत्र प्राधिकरण
- PFX प्रमाणपत्र
- PKCS#12
- सिग्नेचर सत्यापित करें
- PowerPoint
- PPTX
- प्रस्तुति सुरक्षा
- Java
- Aspose.Slides
description: "जानें कैसे PFX प्रमाणपत्रों के साथ मौजूदा PPTX प्रस्तुतियों पर हस्ताक्षर करें और जावा के लिए Aspose.Slides का उपयोग करके डिजिटल सिग्नेचर को सत्यापित या हटाएँ।"
---
## **अवलोकन**

एक डिजिटल सिग्नेचर प्राप्तकर्ता को यह निर्धारित करने में मदद करता है कि किसने प्रस्तुति पर हस्ताक्षर किए हैं और क्या हस्ताक्षरित सामग्री बदल गई है। यहाँ तीन संबंधित सुरक्षा अवधारणाएँ महत्वपूर्ण हैं:

- एक **डिजिटल प्रमाणपत्र** एक इलेक्ट्रॉनिक प्रमाणपत्र है जो पहचान को सार्वजनिक कुंजी के साथ जोड़ता है। एक विश्वसनीय प्रमाणपत्र प्राधिकरण (CA) प्रमाणपत्र जारी कर सकता है, या कोई संगठन आंतरिक कार्यप्रवाहों के लिए स्वयं-हस्ताक्षरित प्रमाणपत्र का उपयोग कर सकता है।
- एक **डिजिटल सिग्नेचर** प्रस्तुति सामग्री और प्रमाणपत्र धारक की निजी कुंजी से बनाया जाता है। फिर प्रमाणपत्र की सार्वजनिक कुंजी का उपयोग करके सिग्नेचर को सत्यापित किया जा सकता है। एक सिग्नेचर मूल और अखंडता का प्रमाण प्रदान करता है; यह प्रस्तुति को एन्क्रिप्ट नहीं करता।
- **पासवर्ड सुरक्षा** नियंत्रित करती है कि उपयोगकर्ता प्रस्तुति को खोल सकता है या संशोधित कर सकता है। यह डिजिटल हस्ताक्षर से अलग है और इसे [Password-Protected Presentations](/java/password-protected-presentation/) में वर्णित किया गया है।

PowerPoint **Add a Digital Signature** कमांड **File > Info > Protect Presentation** के अंतर्गत प्रदान करता है।

![PowerPoint Protect Presentation मेन्यू जिसमें Add a Digital Signature हाइलाइट किया गया है](add-digital-signature-in-powerpoint.png)

हस्ताक्षरित प्रस्तुति खोलने के बाद, PowerPoint एक सिग्नेचर-स्थिति सूचना प्रदर्शित कर सकता है।

![PowerPoint सूचना बताती है कि प्रस्तुति में वैध सिग्नेचर हैं](digital-signature-status-in-powerpoint.png)

Aspose.Slides सिग्नेचर को [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipresentation/#getDigitalSignatures--) के माध्यम से उजागर करता है, जो एक [IDigitalSignatureCollection](https://reference.aspose.com/slides/hi/java/com.aspose.slides/idigitalsignaturecollection/) लौटाता है जिसकी वस्तुएँ [IDigitalSignature](https://reference.aspose.com/slides/hi/java/com.aspose.slides/idigitalsignature/) को लागू करती हैं। एक प्रस्तुति में कई सिग्नेचर हो सकते हैं।

## **PFX प्रमाणपत्रों और पासवर्ड को समझें**

A PFX फाइल, जिसे PKCS#12 फाइल भी कहा जाता है और आमतौर पर `.pfx` या `.p12` विस्तार दिया जाता है, एक X.509 प्रमाणपत्र, उसकी निजी कुंजी, और प्रमाणपत्र श्रृंखला含 कर सकती है। निजी कुंजी वही है जो धारक को सिग्नेचर बनाने की अनुमति देती है। एक प्रमाणपत्र जिसमें पहुँच योग्य निजी कुंजी नहीं है, का उपयोग प्रस्तुति पर हस्ताक्षर करने के लिए नहीं किया जा सकता।

PFX पासवर्ड प्रमाणपत्र पैकेज और निजी कुंजी की सुरक्षा करता है। यह प्रस्तुति खोलने या संपादित करने के लिए पासवर्ड **नहीं** है। PFX फ़ाइलों या उनके पासवर्ड को स्रोत नियंत्रण में कमिट न करें। उत्पादन में, प्रमाणपत्र फ़ाइल तक पहुंच को सीमित रखें और पासवर्ड को एक सीक्रेट स्टोर या किसी अन्य संरक्षित कॉन्फ़िगरेशन स्रोत से प्राप्त करें। नीचे के उदाहरण केवल कोड में पासवर्ड को एम्बेड करने से बचने के लिए पर्यावरण चर का उपयोग करते हैं।

## **प्रस्तुति में एक डिजिटल सिग्नेचर जोड़ें**

एक वास्तविक प्रस्तुति कार्यप्रवाह पर हस्ताक्षर करने के लिए, मौज़ूद PPTX फ़ाइल लोड करें, एक PFX प्रमाणपत्र और उसके पासवर्ड से एक [DigitalSignature](https://reference.aspose.com/slides/hi/java/com.aspose.slides/digitalsignature/) बनाएं, सिग्नेचर को प्रस्तुति के संग्रह में जोड़ें, और PPTX फ़ाइल में सहेजें।

```java
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

परिणाम को नए नाम से सहेजने से बिना हस्ताक्षर वाली स्रोत फ़ाइल सुरक्षित रहती है। [IDigitalSignature.setComments](https://reference.aspose.com/slides/hi/java/com.aspose.slides/idigitalsignature/#setComments-java.lang.String-) द्वारा सेट की गई मूल्य सिग्नेचर के उद्देश्य को वर्णित करती है; यह कोई सुरक्षा नियंत्रण नहीं है।

## **डिजिटल सिग्नेचर सत्यापित करें**

जब आप एक हस्ताक्षरित PPTX फ़ाइल लोड करते हैं, तो [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipresentation/#getDigitalSignatures--) द्वारा लौटाए गए प्रत्येक आइटम की जांच करें। [IDigitalSignature.isValid](https://reference.aspose.com/slides/hi/java/com.aspose.slides/idigitalsignature/#isValid--) विधि यह दर्शाती है कि एम्बेडेड सिग्नेचर वर्तमान प्रस्तुति सामग्री के लिए वैध है या नहीं।

```java
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

एक असमान्य परिणाम आमतौर पर यह दर्शाता है कि हस्ताक्षरित प्रस्तुति सामग्री या सिग्नेचर डेटा हस्ताक्षर के बाद बदल गया है, या फ़ाइल क्षतिग्रस्त है। सभी सिग्नेचर को हटाने से बिना हस्ताक्षर वाली प्रस्तुति बनती है, इसलिए केवल आइटमों की वैधता जाँचना पर्याप्त नहीं है: एक सुरक्षा-संवेदनशील कार्यप्रवाह को अपेक्षित सिग्नेचर संख्या और अपेक्षित हस्ताक्षरकर्ता पहचानों की भी जाँच करनी चाहिए।

इस वैधता परिणाम को पूर्ण प्रमाणपत्र-विश्वास निर्णय नहीं माना जाना चाहिए। आपके सुरक्षा नीति के आधार पर, आपके अनुप्रयोग को X.509 प्रमाणपत्र श्रृंखला बनाना और सत्यापित करना, प्रमाणपत्र वैधता तिथियों और निरस्तीकरण स्थिति की जांच करना, अपेक्षित विषय या थंबप्रिंट की पुष्टि करना, कुंजी उपयोग की जाँच करना, और विश्वसनीय टाइमस्टैम्प का मूल्यांकन करना पड़ सकता है। [IDigitalSignature.getSignTime](https://reference.aspose.com/slides/hi/java/com.aspose.slides/idigitalsignature/#getSignTime--) का मान स्वयं विश्वसनीय टाइमस्टैम्प प्राधिकरण से प्रमाण नहीं है।

## **डिजिटल सिग्नेचर हटाएं**

सिग्नेचर हटाने से प्रस्तुति की सुरक्षा स्थिति बदलती है। निम्न उदाहरण एक हस्ताक्षरित PPTX फ़ाइल लोड करता है, सभी सिग्नेचर को [IDigitalSignatureCollection.clear](https://reference.aspose.com/slides/hi/java/com.aspose.slides/idigitalsignaturecollection/#clear--) से हटाता है, और एक बिना हस्ताक्षर की कॉपी सहेजता है।

```java
Presentation presentation = new Presentation("InputPresentation-signed.pptx");
try {
    presentation.getDigitalSignatures().clear();
    presentation.save("InputPresentation-unsigned.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

केवल एक सिग्नेचर हटाने के लिए, उसकी शून्य-आधारित इंडेक्स के साथ [IDigitalSignatureCollection.removeAt](https://reference.aspose.com/slides/hi/java/com.aspose.slides/idigitalsignaturecollection/#removeAt-int-) को कॉल करें। नई फ़ाइल में सहेजें जब तक कि हस्ताक्षरित मूल को ओवरराइट करना आपके कार्यप्रवाह का स्पष्ट भाग न हो।

## **संपादन और फ़ॉर्मेट विचार**

- एक सिग्नेचर प्रस्तुति को केवल-पढ़ने योग्य नहीं बनाता। उपयोगकर्ता और अनुप्रयोग अभी भी फ़ाइल को संपादित कर सकते हैं, लेकिन हस्ताक्षरित सामग्री में बदलाव आमतौर पर मौजूदा सिग्नेचर को अमान्य कर देता है।
- हस्ताक्षर करने से पहले सभी इच्छित संपादनों को पूरा करें। यदि प्रस्तुति को बदलना आवश्यक हो, तो संशोधित प्रस्तुति को सहेजें और फिर उस संशोधन पर फिर से हस्ताक्षर करें।
- अंतिम आउटपुट को PPTX फ़ॉर्मेट में रखें। हस्ताक्षरित प्रस्तुति को अन्य फ़ॉर्मेट में बदलने से मूल PPTX सिग्नेचर को परिवर्तित फ़ाइल के लिए वैध सिग्नेचर के रूप में नहीं ले जाया जाता।
- प्रमाणपत्र की निजी कुंजी को संवेदनशील मानें। जो कोई भी निजी कुंजी और उसका पासवर्ड प्राप्त करता है, वह ऐसा सिग्नेचर बना सकता है जो उस प्रमाणपत्र धारक से आया प्रतीत हो।
- जब आपके दस्तावेज़-राख नीति में यह आवश्यक हो, तो बिना हस्ताक्षर स्रोत या कोई अन्य नियंत्रित प्रति रखें।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या एक डिजिटल सिग्नेचर प्रस्तुति को एन्क्रिप्ट करता है?**  
नहीं। एक डिजिटल सिग्नेचर मूल और अखंडता का प्रमाण प्रदान करता है, लेकिन प्रस्तुति सामग्री पढ़ने योग्य रहती है जब तक अलग से एन्क्रिप्शन लागू न किया जाए। जब सामग्री तक पहुंच सीमित करनी हो तो [password protection](/java/password-protected-presentation/) का उपयोग करें।

**क्या PFX पासवर्ड प्रस्तुति पासवर्ड के समान है?**  
नहीं। PFX पासवर्ड प्रमाणपत्र पैकेज में संग्रहीत निजी कुंजी को अनलॉक करता है। यह यह नियंत्रित नहीं करता कि कौन PPTX फ़ाइल खोल या संपादित कर सकता है।

**क्या मैं स्वयं-हस्ताक्षरित प्रमाणपत्र का उपयोग कर सकता हूँ?**  
तकनीकी रूप से, जब इसमें पहुँच योग्य निजी कुंजी शामिल हो तो स्वयं-हस्ताक्षरित प्रमाणपत्र का उपयोग किया जा सकता है। हालांकि प्राप्तकर्ता इसे स्वचालित रूप से भरोसा नहीं करेंगे, जब तक कि वह प्रमाणपत्र स्पष्ट रूप से उनके विश्वसनीय वातावरण में नहीं जोड़ा गया हो। सार्वजनिक या क्रॉस-ऑर्गेनाइज़ेशन कार्यप्रवाह सामान्यतः भरोसेमंद CA द्वारा जारी प्रमाणपत्र का उपयोग करते हैं।

**एक सिग्नेचर को अमान्य क्या बनाता है?**  
हस्ताक्षरित प्रस्तुति सामग्री या सिग्नेचर डेटा को हस्ताक्षर के बाद बदलना सिग्नेचर को अमान्य कर सकता है। फ़ाइल भ्रष्टाचार भी वैधता विफलता का कारण बन सकता है। यदि सभी सिग्नेचर हटा दिए जाएँ, तो प्रस्तुति बिना हस्ताक्षर की होती है न कि अमान्य सिग्नेचर वाली फ़ाइल।

**क्या एक वैध सिग्नेचर का अर्थ है कि मुझे हस्ताक्षरकर्ता पर भरोसा करना चाहिए?**  
केवल इससे नहीं। सिग्नेचर की अखंडता और हस्ताक्षरकर्ता का भरोसा दो अलग निर्णय हैं। एक उत्पादन वैधता नीति को प्रमाणपत्र श्रृंखला, वैधता अवधि, निरस्तीकरण स्थिति, अपेक्षित पहचान, कुंजी उपयोग, और किसी भी विश्वसनीय टाइमस्टैम्प आवश्यकताओं की भी जाँच करनी चाहिए।

**जब प्रमाणपत्र समाप्त हो जाता है तो क्या होता है?**  
प्रमाणपत्र समाप्ति प्रस्तुति बाइट्स को नहीं बदलती, लेकिन यह प्रमाणपत्र-विश्वास मूल्यांकन को प्रभावित करती है। क्या सिग्नेचर स्वीकार्य रहता है यह आपके नीति और इस बात पर निर्भर करता है कि क्या एक वैध भरोसेमंद टाइमस्टैम्प यह सिद्ध करता है कि हस्ताक्षर उस समय हुआ जब प्रमाणपत्र वैध था। केवल प्रदर्शित हस्ताक्षर समय पर भरोसा न करें जिसे विश्वसनीय टाइमस्टैम्प माना जाए।

**क्या एक हस्ताक्षरित प्रस्तुति को अभी भी संपादित किया जा सकता है?**  
हां। हस्ताक्षर फ़ाइल को लॉक नहीं करता। हस्ताक्षरित सामग्री को संपादित करने से आमतौर पर मौजूदा सिग्नेचर अमान्य हो जाता है, इसलिए पहली बार प्रस्तुति को पूरा करें और अंतिम संशोधन पर हस्ताक्षर करें।

**क्या एक प्रस्तुति में एक से अधिक सिग्नेचर हो सकते हैं?**  
हां। प्रत्येक सिग्नेचर को [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipresentation/#getDigitalSignatures--) द्वारा लौटाए गए संग्रह में जोड़ें और फिर सहेजें। वैधता के दौरान, प्रत्येक सिग्नेचर की जाँच करें और पुष्टि करें कि सभी आवश्यक हस्ताक्षरकर्ता मौजूद हैं।

**कौन से प्रस्तुति फ़ॉर्मेट इन संचालन को समर्थन देते हैं?**  
Aspose.Slides केवल PPTX के लिए यहाँ वर्णित डिजिटल-सिग्नेचर संचालन का समर्थन करता है। PPT और OpenDocument प्रस्तुति फ़ॉर्मेट इस API कार्यप्रवाह द्वारा समर्थित नहीं हैं।

**क्या मैं सिग्नेचर को हटाते हुए स्लाइड्स को प्रभावित किए बिना रख सकता हूँ?**  
हां। आप एक सिग्नेचर हटा सकते हैं या पूरी संग्रह को साफ़ कर सकते हैं और फिर प्रस्तुति सहेज सकते हैं। स्लाइड सामग्री बनी रहती है, लेकिन सहेजी गई फ़ाइल में हटाए गए सिग्नेचर का प्रमाण नहीं रहेगा।