---
title: Android पर प्रस्तुतियों में डिजिटल हस्ताक्षर जोड़ें
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
- हस्ताक्षर सत्यापित करें
- PowerPoint
- PPTX
- प्रस्तुति सुरक्षा
- Android
- Java
- Aspose.Slides
description: "PFX प्रमाणपत्रों के साथ मौजूदा PPTX प्रस्तुतियों पर हस्ताक्षर करने और Android के लिए Aspose.Slides को Java के माध्यम से डिजिटल हस्ताक्षर सत्यापित या हटाने का तरीका सीखें।"
---
## **अवलोकन**

डिजिटल हस्ताक्षर प्राप्तकर्ता को यह निर्धारित करने में मदद करता है कि प्रस्तुति पर किसने हस्ताक्षर किया और क्या हस्ताक्षरित सामग्री बदल गई है। यहाँ तीन संबंधित सुरक्षा अवधारणाएँ महत्वपूर्ण हैं:

- एक **डिजिटल प्रमाणपत्र** एक इलेक्ट्रॉनिक क्रेडेंशियल है जो पहचान को सार्वजनिक कुंजी के साथ जोड़ता है। एक भरोसेमंद प्रमाणपत्र प्राधिकरण (CA) प्रमाणपत्र जारी कर सकता है, या कोई संगठन आंतरिक कार्यप्रवाह के लिए स्वयं-हस्ताक्षरित प्रमाणपत्र का उपयोग कर सकता है।
- एक **डिजिटल हस्ताक्षर** प्रस्तुति सामग्री और प्रमाणपत्र धारक की निजी कुंजी से बनाया जाता है। प्रमाणपत्र की सार्वजनिक कुंजी का उपयोग करके हस्ताक्षर को सत्यापित किया जा सकता है। हस्ताक्षर उत्पत्ति और अखंडता का प्रमाण देता है; यह प्रस्तुति को एन्क्रिप्ट नहीं करता।
- **पासवर्ड सुरक्षा** नियंत्रित करती है कि उपयोगकर्ता प्रस्तुति को खोल या संशोधित कर सकता है या नहीं। यह डिजिटल हस्ताक्षर से अलग है और इसे [Password-Protected Presentations](/androidjava/password-protected-presentation/) में वर्णित किया गया है।

PowerPoint **फ़ाइल > जानकारी > प्रस्तुति सुरक्षित करें** के तहत **डिजिटल हस्ताक्षर जोड़ें** कमांड प्रदान करता है।

![PowerPoint सुरक्षित प्रस्तुति मेनू जिसमें डिजिटल हस्ताक्षर जोड़ें हाइलाइट किया गया है](add-digital-signature-in-powerpoint.png)

हस्ताक्षरित प्रस्तुति खोलने के बाद, PowerPoint एक हस्ताक्षर-स्थिति अधिसूचना दिखा सकता है।

![PowerPoint अधिसूचना जो बताती है कि प्रस्तुति में वैध हस्ताक्षर हैं](digital-signature-status-in-powerpoint.png)

Aspose.Slides हस्ताक्षरों को [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipresentation/#getDigitalSignatures--) के माध्यम से उजागर करता है, जो एक [IDigitalSignatureCollection](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/idigitalsignaturecollection/) लौटाता है, जिसकी वस्तुएँ [IDigitalSignature](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/idigitalsignature/) को लागू करती हैं। एक प्रस्तुति में कई हस्ताक्षर हो सकते हैं।

## **PFX प्रमाणपत्र और पासवर्ड को समझें**

एक PFX फ़ाइल, जिसे PKCS#12 फ़ाइल भी कहा जाता है और सामान्यतः `.pfx` या `.p12` विस्तार दिया जाता है, एक X.509 प्रमाणपत्र, उसकी निजी कुंजी, और प्रमाणपत्र श्रृंखला रख सकती है। निजी कुंजी वही है जो धारक को हस्ताक्षर बनाने की अनुमति देती है। निजी कुंजी के बिना कोई प्रमाणपत्र प्रस्तुति पर हस्ताक्षर करने के लिए उपयोग नहीं किया जा सकता।

PFX पासवर्ड प्रमाणपत्र पैकेज और निजी कुंजी की सुरक्षा करता है। यह प्रस्तुति को खोलने या संपादित करने के लिए पासवर्ड **नहीं** है। PFX फ़ाइलें या उनके पासवर्ड को सोर्स कंट्रोल में कमिट न करें। उत्पादन में, प्रमाणपत्र फ़ाइल तक पहुंच को सीमित रखें और उसका पासवर्ड एक गुप्त स्टोर या अन्य संरक्षित कॉन्फ़िगरेशन स्रोत से प्राप्त करें। नीचे के उदाहरण केवल कोड में पासवर्ड एम्बेड करने से बचने के लिए पर्यावरण वेरिएबल का उपयोग करते हैं।

## **एक प्रस्तुति में डिजिटल हस्ताक्षर जोड़ें**

एक वास्तविक प्रस्तुति कार्यप्रवाह पर हस्ताक्षर करने के लिए, मौजूदा PPTX फ़ाइल लोड करें, एक PFX प्रमाणपत्र और उसके पासवर्ड से एक [DigitalSignature](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/digitalsignature/) बनाएं, हस्ताक्षर को प्रस्तुति के संग्रह में जोड़ें, और PPTX फ़ाइल में सहेजें।

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

परिणाम को नई फ़ाइल नाम के तहत सहेजने से अनहस्ताक्षरित स्रोत फ़ाइल संरक्षित रहती है। [IDigitalSignature.setComments](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/idigitalsignature/#setComments-java.lang.String-) द्वारा सेट किया गया मान हस्ताक्षर का उद्देश्य वर्णित करता है; यह एक सुरक्षा नियंत्रण नहीं है।

## **डिजिटल हस्ताक्षरों को सत्यापित करें**

जब आप एक हस्ताक्षरित PPTX फ़ाइल लोड करते हैं, तो [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipresentation/#getDigitalSignatures--) द्वारा लौटाए गए प्रत्येक आइटम का निरीक्षण करें। [IDigitalSignature.isValid](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/idigitalsignature/#isValid--) मेथड बताता है कि एम्बेडेड हस्ताक्षर वर्तमान प्रस्तुति सामग्री के लिए वैध है या नहीं।

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

एक अमान्य परिणाम आमतौर पर इसका मतलब होता है कि हस्ताक्षरित प्रस्तुति सामग्री या हस्ताक्षर डेटा हस्ताक्षर करने के बाद बदल गया, या फ़ाइल क्षतिग्रस्त है। सभी हस्ताक्षर हटाने से अनहस्ताक्षरित प्रस्तुति बनती है, इसलिए केवल आइटम की वैधता जांचना पर्याप्त नहीं है: एक सुरक्षा-संवेदनशील कार्यप्रवाह को यह भी सत्यापित करना चाहिए कि अपेक्षित संख्या के हस्ताक्षर और अपेक्षित हस्ताक्षरकर्ता पहचान मौजूद हैं।

इस वैधता परिणाम को पूर्ण प्रमाणपत्र‑विश्वास निर्णय के रूप में नहीं लेना चाहिए। आपके सुरक्षा नीति के आधार पर, आपका अनुप्रयोग X.509 प्रमाणपत्र श्रृंखला बनाना और सत्यापित करना, प्रमाणपत्र की वैधता तिथियों और निरस्तीकरण स्थिति की जाँच करना, अपेक्षित विषय या थम्बप्रिंट की पुष्टि करना, कुंजी उपयोग की जाँच करना, और भरोसेमंद टाइमस्टैम्प का मूल्यांकन करना भी आवश्यक हो सकता है। [IDigitalSignature.getSignTime](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/idigitalsignature/#getSignTime--) का मान स्वयं एक भरोसेमंद टाइमस्टैम्प प्राधिकरण से प्रमाण नहीं है।

## **डिजिटल हस्ताक्षर हटाएँ**

हस्ताक्षर हटाने से प्रस्तुति की सुरक्षा स्थिति बदल जाती है। निम्न उदाहरण एक हस्ताक्षरित PPTX फ़ाइल लोड करता है, सभी हस्ताक्षर को [IDigitalSignatureCollection.clear](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/idigitalsignaturecollection/#clear--) से हटाता है, और एक अनहस्ताक्षरित प्रतिलिपि सहेजता है।

```java
Presentation presentation = new Presentation("InputPresentation-signed.pptx");
try {
    presentation.getDigitalSignatures().clear();
    presentation.save("InputPresentation-unsigned.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

केवल एक हस्ताक्षर हटाने के लिए, उसकी शून्य‑आधारित सूचकांक के साथ [IDigitalSignatureCollection.removeAt](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/idigitalsignaturecollection/#removeAt-int-) को कॉल करें। जब तक आपका कार्यप्रवाह स्पष्ट रूप से हस्ताक्षरित मूल को ओवरराइट करने की आवश्यकता नहीं रखता, नई फ़ाइल में सहेजें।

## **संपादन और स्वरूप विचार**

- एक हस्ताक्षर प्रस्तुति को केवल‑पढ़ने योग्य नहीं बनाता। उपयोगकर्ता और अनुप्रयोग अभी भी फ़ाइल को संपादित कर सकते हैं, लेकिन हस्ताक्षरित सामग्री में बदलाव आमतौर पर मौजूदा हस्ताक्षर को अमान्य कर देता है।
- हस्ताक्षर करने से पहले सभी इच्छित बदलाव पूरे करें। यदि प्रस्तुति को बदलना आवश्यक है, तो संशोधित प्रस्तुति को सहेजें और फिर उस संस्करण पर पुनः हस्ताक्षर करें।
- अंतिम आउटपुट को PPTX स्वरूप में रखें। हस्ताक्षरित प्रस्तुति को किसी अन्य स्वरूप में बदलने से मूल PPTX हस्ताक्षर वैध हस्ताक्षर के रूप में परिवर्तित फ़ाइल में नहीं जाता।
- प्रमाणपत्र की निजी कुंजी को संवेदनशील मानें। जो कोई भी निजी कुंजी और उसका पासवर्ड प्राप्त करता है, वह ऐसे हस्ताक्षर बना सकता है जो उस प्रमाणपत्र धारक से आए हुए प्रतीत हों।
- जब आपके दस्तावेज़‑रिटेंशन नीति की आवश्यकता हो, तो अनहस्ताक्षरित स्रोत या कोई अन्य नियंत्रित प्रतिलिपि रख लें।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या डिजिटल हस्ताक्षर प्रस्तुति को एन्क्रिप्ट करता है?**

नहीं। डिजिटल हस्ताक्षर उत्पत्ति और अखंडता के प्रमाण प्रदान करता है, लेकिन प्रस्तुति सामग्री पढ़ने योग्य रहती है जब तक अलग से एन्क्रिप्शन लागू न किया गया हो। जब सामग्री तक पहुंच प्रतिबंधित करनी हो तो [password protection](/androidjava/password-protected-presentation/) का उपयोग करें।

**क्या PFX पासवर्ड प्रस्तुति पासवर्ड के बराबर है?**

नहीं। PFX पासवर्ड प्रमाणपत्र पैकेज में संग्रहीत निजी कुंजी को अनलॉक करता है। यह यह नियंत्रित नहीं करता कि कौन PPTX फ़ाइल खोल या संपादित कर सकता है।

**क्या मैं स्वयं‑हस्ताक्षरित प्रमाणपत्र का उपयोग कर सकता हूँ?**

तकनीकी रूप से, स्वयं‑हस्ताक्षरित प्रमाणपत्र का उपयोग तब किया जा सकता है जब उसमें पहुँच योग्य निजी कुंजी हो। प्राप्तकर्ता स्वचालित रूप से इसे भरोसा नहीं करेंगे, जब तक कि वह प्रमाणपत्र उनके भरोसेमंद वातावरण में स्पष्ट रूप से नहीं जोड़ा गया हो। सार्वजनिक या बहु‑संगठन कार्यप्रवाह सामान्यतः भरोसेमंद CA द्वारा जारी प्रमाणपत्र का उपयोग करते हैं।

**हस्ताक्षर को अमान्य क्या बनाता है?**

हस्ताक्षरित प्रस्तुति सामग्री या हस्ताक्षर डेटा को हस्ताक्षर के बाद बदलना हस्ताक्षर को अमान्य कर सकता है। फ़ाइल करप्शन भी वैधता विफलता का कारण बन सकता है। यदि सभी हस्ताक्षर हटा दिए जाएँ, तो प्रस्तुति अनहस्ताक्षरित होगी, न कि अमान्य हस्ताक्षर वाली फ़ाइल।

**क्या वैध हस्ताक्षर का मतलब है कि मुझे हस्ताक्षरकर्ता पर भरोसा करना चाहिए?**

सिर्फ इसके आधार पर नहीं। हस्ताक्षर की अखंडता और हस्ताक्षरकर्ता के भरोसे अलग‑अलग निर्णय हैं। उत्पादन सत्यापन नीति को प्रमाणपत्र श्रृंखला, वैधता अवधि, निरस्तीकरण स्थिति, अपेक्षित पहचान, कुंजी उपयोग, और भरोसेमंद टाइमस्टैम्प आवश्यकताओं की जाँच भी करनी चाहिए।

**यदि प्रमाणपत्र समाप्त हो जाए तो क्या होता है?**

प्रमाणपत्र समाप्ति प्रस्तुति बाइट्स को नहीं बदलती, लेकिन यह प्रमाणपत्र‑विश्वास मूल्यांकन को प्रभावित करती है। एक हस्ताक्षर तब भी स्वीकार्य रह सकता है यदि आपका नीति और एक वैध भरोसेमंद टाइमस्टैम्प दर्शाते हैं कि हस्ताक्षर उस समय हुआ था जब प्रमाणपत्र वैध था। केवल प्रदर्शित हस्ताक्षर समय पर भरोसा न करें।

**क्या हस्ताक्षरित प्रस्तुति को फिर भी संपादित किया जा सकता है?**

हां। हस्ताक्षर फ़ाइल को लॉक नहीं करता। हस्ताक्षरित सामग्री को संपादित करने से सामान्यतः मौजूदा हस्ताक्षर अमान्य हो जाता है, इसलिए पहले प्रस्तुति को पूरा करें और अंतिम संस्करण पर हस्ताक्षर करें।

**क्या एक प्रस्तुति में एक से अधिक हस्ताक्षर हो सकते हैं?**

हां। प्रत्येक हस्ताक्षर को [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipresentation/#getDigitalSignatures--) द्वारा लौटाए गए संग्रह में जोड़ें और फिर सहेजें। वैधता के दौरान, प्रत्येक हस्ताक्षर का निरीक्षण करें और सुनिश्चित करें कि सभी आवश्यक हस्ताक्षरकर्ता मौजूद हैं।

**कौन से प्रस्तुति स्वरूप इन कार्यों का समर्थन करते हैं?**

Aspose.Slides केवल PPTX के लिए यहाँ वर्णित डिजिटल‑हस्ताक्षर कार्यों का समर्थन करता है। PPT और OpenDocument प्रस्तुति स्वरूप इस API कार्यप्रवाह द्वारा समर्थित नहीं हैं।

**क्या मैं हस्ताक्षर हटाते समय स्लाइड्स को प्रभावित किए बिना हटा सकता हूँ?**

हां। आप एक हस्ताक्षर हटा सकते हैं या पूरे संग्रह को साफ़ कर सकते हैं और फिर प्रस्तुति को सहेज सकते हैं। स्लाइड सामग्री बनी रहती है, लेकिन सहेजी गई फ़ाइल अब हटाए गए हस्ताक्षर के प्रमाण को नहीं रखती।