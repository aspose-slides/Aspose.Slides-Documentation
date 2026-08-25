---
title: जावा में प्रस्तुतियों में डिजिटल हस्ताक्षर जोड़ें
linktitle: डिजिटल हस्ताक्षर
type: docs
weight: 10
url: /hi/java/digital-signature-in-powerpoint/
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
- Java
- Aspose.Slides
description: "PFX प्रमाणपत्रों के साथ मौजूदा PPTX प्रस्तुतियों पर हस्ताक्षर करना और जावा के लिए Aspose.Slides का उपयोग करके डिजिटल हस्ताक्षरों को सत्यापित या हटाना सीखें।"
---
## **अवलोकन**

डिजिटल हस्ताक्षर प्राप्तकर्ता को यह निर्धारित करने में मदद करता है कि किसी प्रस्तुति पर किसने हस्ताक्षर किया और क्या हस्ताक्षरित सामग्री में परिवर्तन हुआ है। यहाँ तीन संबंधित सुरक्षा अवधारणाएँ महत्वपूर्ण हैं:

- एक **digital certificate** एक इलेक्ट्रॉनिक पहचान पत्र है जो एक पहचान को सार्वजनिक कुंजी से जोड़ता है। एक विश्वसनीय प्रमाणपत्र प्राधिकार (CA) प्रमाणपत्र जारी कर सकता है, या कोई संगठन आंतरिक कार्यप्रवाहों के लिए स्व-हस्ताक्षरित प्रमाणपत्र का उपयोग कर सकता है।
- एक **digital signature** प्रस्तुति सामग्री और प्रमाणपत्र धारक की निजी कुंजी से बनाया जाता है। प्रमाणपत्र की सार्वजनिक कुंजी का उपयोग करके हस्ताक्षर को सत्यापित किया जा सकता है। हस्ताक्षर मूल और अखंडता का प्रमाण देता है; यह प्रस्तुति को एन्क्रिप्ट नहीं करता।
- **Password protection** यह नियंत्रित करता है कि उपयोगकर्ता प्रस्तुति को खोल सके या संशोधित कर सके। यह डिजिटल हस्ताक्षर से अलग है और इसे [पासवर्ड-सुरक्षित प्रस्तुतियाँ](/slides/hi/java/password-protected-presentation/) में वर्णित किया गया है।

PowerPoint **Add a Digital Signature** कमांड **File > Info > Protect Presentation** के तहत प्रदान करता है।

![PowerPoint Protect Presentation मेन्यू जिसमें Add a Digital Signature हाइलाइट किया गया है](add-digital-signature-in-powerpoint.png)

हस्ताक्षरित प्रस्तुति खोलने के बाद, PowerPoint एक हस्ताक्षर-स्थिति अधिसूचना प्रदर्शित कर सकता है।

![PowerPoint अधिसूचना दर्शाती है कि प्रस्तुति में वैध हस्ताक्षर मौजूद हैं](digital-signature-status-in-powerpoint.png)

Aspose.Slides हस्ताक्षरों को [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipresentation/#getDigitalSignatures--) के माध्यम से उपलब्ध कराता है, जो एक [IDigitalSignatureCollection](https://reference.aspose.com/slides/hi/java/com.aspose.slides/idigitalsignaturecollection/) लौटाता है, जिसके आइटम [IDigitalSignature](https://reference.aspose.com/slides/hi/java/com.aspose.slides/idigitalsignature/) को लागू करते हैं। एक प्रस्तुति में कई हस्ताक्षर हो सकते हैं।

## **PFX प्रमाणपत्र और पासवर्ड को समझें**

एक PFX फ़ाइल, जिसे PKCS#12 फ़ाइल भी कहा जाता है और आमतौर पर `.pfx` या `.p12` एक्सटेंशन दिया जाता है, में X.509 प्रमाणपत्र, उसकी निजी कुंजी, और प्रमाणपत्र श्रृंखला हो सकती है। निजी कुंजी वह होती है जो धारक को हस्ताक्षर बनाने की अनुमति देती है। एक प्रमाणपत्र बिना पहुँच योग्य निजी कुंजी के हस्ताक्षर के लिए उपयोग नहीं किया जा सकता।

PFX पासवर्ड प्रमाणपत्र पैकेज और निजी कुंजी की सुरक्षा करता है। यह प्रस्तुति को खोलने या संशोधित करने के लिए पासवर्ड नहीं है। PFX फ़ाइलों या उनके पासवर्ड को स्रोत नियंत्रण में कमिट न करें। उत्पादन में, प्रमाणपत्र फ़ाइल तक पहुँच को सीमित करें और उसका पासवर्ड एक गुप्त स्टोर या अन्य सुरक्षित कॉन्फ़िगरेशन स्रोत से प्राप्त करें। नीचे के उदाहरण केवल कोड में पासवर्ड एम्बेड करने से बचने के लिए एक पर्यावरण चर का उपयोग करते हैं।

## **प्रस्तुति में डिजिटल हस्ताक्षर जोड़ें**

एक वास्तविक प्रस्तुति कार्यप्रवाह को हस्ताक्षर करने के लिए, मौजूदा PPTX फ़ाइल को लोड करें, PFX प्रमाणपत्र और उसके पासवर्ड से एक [DigitalSignature](https://reference.aspose.com/slides/hi/java/com.aspose.slides/digitalsignature/) बनाएं, हस्ताक्षर को प्रस्तुति की संग्रह में जोड़ें, और PPTX फ़ाइल के रूप में सहेजें।

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

परिणाम को नए नाम से सहेजने से बिना हस्ताक्षर की स्रोत फ़ाइल संरक्षित रहती है। [IDigitalSignature.setComments](https://reference.aspose.com/slides/hi/java/com.aspose.slides/idigitalsignature/#setComments-java.lang.String-) द्वारा सेट किया गया मान हस्ताक्षर के उद्देश्य का वर्णन करता है; यह कोई सुरक्षा नियंत्रण नहीं है।

## **डिजिटल हस्ताक्षर को मान्य करें**

जब आप एक हस्ताक्षरित PPTX फ़ाइल लोड करते हैं, तो [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipresentation/#getDigitalSignatures--) द्वारा लौटाए गये प्रत्येक आइटम का निरीक्षण करें। [IDigitalSignature.isValid](https://reference.aspose.com/slides/hi/java/com.aspose.slides/idigitalsignature/#isValid--) मेथड यह संकेत देता है कि एम्बेडेड हस्ताक्षर वर्तमान प्रस्तुति सामग्री के लिए वैध है या नहीं।

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

एक अमान्य परिणाम आमतौर पर इसका अर्थ है कि हस्ताक्षरित सामग्री या हस्ताक्षर डेटा हस्ताक्षर करने के बाद बदल गया, या फ़ाइल भ्रष्ट हो गई। सभी हस्ताक्षर हटाने से एक बिना हस्ताक्षर वाली प्रस्तुति बनती है, इसलिए केवल आइटम की वैधता जांचना पर्याप्त नहीं है: एक सुरक्षा-संवेदनशील कार्यप्रवाह को अपेक्षित हस्ताक्षर संख्या और अपेक्षित हस्ताक्षरकर्ता पहचान की उपस्थिति भी सत्यापित करनी चाहिए।

यह वैधता परिणाम पूर्ण प्रमाणपत्र-विश्वास निर्णय के रूप में नहीं माना जाना चाहिए। आपके सुरक्षा नीति के आधार पर, आपका अनुप्रयोग X.509 प्रमाणपत्र श्रृंखला का निर्माण और सत्यापन, प्रमाणपत्र वैधता तिथियों और निरस्तीकरण स्थिति की जाँच, अपेक्षित विषय या थंबप्रिंट की पुष्टि, कुंजी उपयोग की पुष्टि, और विश्वसनीय टाइमस्टैंप का मूल्यांकन भी कर सकता है। केवल [IDigitalSignature.getSignTime](https://reference.aspose.com/slides/hi/java/com.aspose.slides/idigitalsignature/#getSignTime--) मान स्वयं विश्वसनीय टाइमस्टैंप प्राधिकार से प्रमाण नहीं है।

## **डिजिटल हस्ताक्षर हटाएँ**

हस्ताक्षर हटाने से प्रस्तुति की सुरक्षा स्थिति बदलती है। निम्न उदाहरण एक हस्ताक्षरित PPTX फ़ाइल लोड करता है, सभी हस्ताक्षर को [IDigitalSignatureCollection.clear](https://reference.aspose.com/slides/hi/java/com.aspose.slides/idigitalsignaturecollection/#clear--) द्वारा हटाता है, और एक बिना हस्ताक्षर की प्रतिलिपि सहेजता है।

```java
Presentation presentation = new Presentation("InputPresentation-signed.pptx");
try {
    presentation.getDigitalSignatures().clear();
    presentation.save("InputPresentation-unsigned.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

केवल एक हस्ताक्षर हटाने के लिए, उसके शून्य-आधारित इंडेक्स के साथ [IDigitalSignatureCollection.removeAt](https://reference.aspose.com/slides/hi/java/com.aspose.slides/idigitalsignaturecollection/#removeAt-int-) को कॉल करें। यदि आप मूल हस्ताक्षरित फ़ाइल को ओवरराइट नहीं करना चाहते तो नई फ़ाइल में सहेजें।

## **संपादन और स्वरूप विचार**

- एक हस्ताक्षर प्रस्तुति को केवल‑पठन योग्य नहीं बनाता। उपयोगकर्ता और अनुप्रयोग फ़ाइल को अभी भी संपादित कर सकते हैं, लेकिन हस्ताक्षरित सामग्री में परिवर्तन सामान्यतः मौजूदा हस्ताक्षर को अमान्य कर देता है।
- हस्ताक्षर करने से पहले सभी इच्छित संपादन पूर्ण करें। यदि प्रस्तुति को बदलना आवश्यक है, तो संशोधित प्रस्तुति को सहेजें और उस संशोधन को फिर से हस्ताक्षरित करें।
- अंतिम आउटपुट को PPTX प्रारूप में रखें। एक हस्ताक्षरित प्रस्तुति को किसी अन्य प्रारूप में बदलने से मूल PPTX हस्ताक्षर को वैध हस्ताक्षर के रूप में स्थानांतरित नहीं किया जाता।
- प्रमाणपत्र की निजी कुंजी को संवेदनशील मानें। कोई भी व्यक्ति जो निजी कुंजी और उसका पासवर्ड प्राप्त कर लेता है, वह ऐसे हस्ताक्षर बना सकता है जो उस प्रमाणपत्र धारक से आ रहे हों।
- यदि आपके दस्तावेज़‑रिटेन्शन नीति में आवश्यक हो तो बिना हस्ताक्षर वाले स्रोत या किसी अन्य नियंत्रित प्रतिलिपि को रखें।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या डिजिटल हस्ताक्षर प्रस्तुति को एन्क्रिप्ट करता है?**

नहीं। डिजिटल हस्ताक्षर मूल और अखंडता का प्रमाण देता है, लेकिन प्रस्तुति सामग्री पढ़ी जा सकती है जब तक कि अलग एन्क्रिप्शन न लागू किया गया हो। सामग्री तक पहुँच को प्रतिबंधित करने की आवश्यकता होने पर [पासवर्ड सुरक्षा](/slides/hi/java/password-protected-presentation/) का उपयोग करें।

**क्या PFX पासवर्ड प्रस्तुति पासवर्ड के समान है?**

नहीं। PFX पासवर्ड प्रमाणपत्र पैकेज में संग्रहीत निजी कुंजी को अनलॉक करता है। यह यह नियंत्रित नहीं करता कि कौन PPTX फ़ाइल को खोल या संपादित कर सकता है।

**क्या मैं स्व-हस्ताक्षरित प्रमाणपत्र का उपयोग कर सकता हूँ?**

तकनीकी रूप से, स्व-हस्ताक्षरित प्रमाणपत्र का उपयोग तब किया जा सकता है जब उसमें एक पहुँच योग्य निजी कुंजी शामिल हो। प्राप्तकर्ता स्वचालित रूप से इसे भरोसेमंद नहीं मानेंगे, जब तक कि वह प्रमाणपत्र स्पष्ट रूप से उनके भरोसेमंद पर्यावरण में जोड़ न दिया गया हो। सार्वजनिक या अंतर-संगठन कार्यप्रवाह आमतौर पर एक भरोसेमंद CA द्वारा जारी प्रमाणपत्र का उपयोग करते हैं।

**हस्ताक्षर को अमान्य क्या बनाता है?**

हस्ताक्षरित प्रस्तुति सामग्री या हस्ताक्षर डेटा को हस्ताक्षर के बाद बदलने से हस्ताक्षर अमान्य हो सकता है। फ़ाइल भ्रष्टाचार भी सत्यापन विफल कर सकता है। यदि सभी हस्ताक्षर हटाए जाते हैं, तो प्रस्तुति बिना हस्ताक्षर की होती है, न कि एक अमान्य हस्ताक्षर वाली फ़ाइल।

**क्या वैध हस्ताक्षर का मतलब है कि मुझे हस्ताक्षरकर्ता पर भरोसा करना चाहिए?**

सिर्फ इसके आधार पर नहीं। हस्ताक्षर की अखंडता और हस्ताक्षरकर्ता का भरोसा अलग निर्णय हैं। उत्पादन सत्यापन नीति को प्रमाणपत्र श्रृंखला, वैधता अवधि, निरस्तीकरण स्थिति, अपेक्षित पहचान, कुंजी उपयोग, और विश्वसनीय टाइमस्टैंप आवश्यकताओं की भी जाँच करनी चाहिए।

**जब प्रमाणपत्र समाप्त हो जाता है तो क्या होता है?**

प्रमाणपत्र समाप्ति प्रस्तुति बाइट्स को नहीं बदलती, लेकिन यह प्रमाणपत्र‑विश्वास मूल्यांकन को प्रभावित करती है। यह कि हस्ताक्षर स्वीकार्य रहे या नहीं, यह आपके नीति और इस बात पर निर्भर करता है कि क्या एक वैध भरोसेमंद टाइमस्टैंप यह सिद्ध करता है कि हस्ताक्षर प्रमाणपत्र के वैध रहने के दौरान हुआ था। केवल प्रदर्शित हस्ताक्षर समय पर भरोसा न करें।

**क्या हस्ताक्षरित प्रस्तुति अभी भी संपादित की जा सकती है?**

हाँ। हस्ताक्षर फ़ाइल को लॉक नहीं करता। हस्ताक्षरित सामग्री में परिवर्तन आमतौर पर मौजूदा हस्ताक्षर को अमान्य कर देता है, इसलिए पहले प्रस्तुति को अंतिम रूप दें और फिर अंतिम संशोधन को हस्ताक्षरित करें।

**क्या एक प्रस्तुति में एक से अधिक हस्ताक्षर हो सकते हैं?**

हाँ। प्रत्येक हस्ताक्षर को संग्रह में जोड़ें जो [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipresentation/#getDigitalSignatures--) द्वारा लौटाया गया है, फिर सहेजें। सत्यापन के दौरान, प्रत्येक हस्ताक्षर का निरीक्षण करें और सुनिश्चित करें कि सभी आवश्यक हस्ताक्षरकर्ता उपस्थित हों।

**इन कार्यों का समर्थन करने वाले कौन से प्रस्तुति प्रारूप हैं?**

Aspose.Slides यहाँ वर्णित डिजिटल‑हस्ताक्षर कार्यों को केवल PPTX के लिए समर्थन करता है। PPT और OpenDocument प्रस्तुति प्रारूप इस API कार्यप्रवाह द्वारा समर्थित नहीं हैं।

**क्या मैं एक हस्ताक्षर को स्लाइड्स को प्रभावित किए बिना हटा सकता हूँ?**

हाँ। आप एक हस्ताक्षर हटा सकते हैं या पूरी संग्रह को साफ़ कर सकते हैं और फिर प्रस्तुति को सहेज सकते हैं। स्लाइड सामग्री उपलब्ध रहती है, लेकिन सहेजी गई फ़ाइल में हटाए गए हस्ताक्षर का प्रमाण नहीं रहेगा।