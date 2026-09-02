---
title: PHP में प्रस्तुतियों में डिजिटल हस्ताक्षर जोड़ें
linktitle: डिजिटल हस्ताक्षर
type: docs
weight: 10
url: /hi/php-java/digital-signature-in-powerpoint/
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
- PHP
- Aspose.Slides
description: "सीखें कि कैसे PFX प्रमाणपत्रों के साथ मौजूदा PPTX प्रस्तुतियों पर हस्ताक्षर करें और जावा के माध्यम से PHP के लिए Aspose.Slides का उपयोग करके डिजिटल हस्ताक्षरों को सत्यापित या हटाएँ।"
---
## **अवलोकन**

डिजिटल हस्ताक्षर प्राप्तकर्ता को यह निर्धारित करने में मदद करता है कि प्रस्तुति पर किसने हस्ताक्षर किया और क्या हस्ताक्षरित सामग्री बदल गई है। यहाँ तीन संबंधित सुरक्षा अवधारणाएँ महत्वपूर्ण हैं:

- एक **डिजिटल प्रमाणपत्र** एक इलेक्ट्रॉनिक प्रमाणपत्र है जो किसी पहचान को सार्वजनिक कुंजी से जोड़ता है। एक विश्वसनीय प्रमाणपत्र प्राधिकरण (CA) प्रमाणपत्र जारी कर सकता है, या कोई संगठन आंतरिक कार्यप्रवाहों के लिए स्वयं‑हस्ताक्षरित प्रमाणपत्र का उपयोग कर सकता है।
- एक **डिजिटल हस्ताक्षर** प्रस्तुति सामग्री और प्रमाणपत्र धारणकर्ता की निजी कुंजी से बनाया जाता है। फिर प्रमाणपत्र की सार्वजनिक कुंजी का उपयोग करके हस्ताक्षर को सत्यापित किया जा सकता है। हस्ताक्षर मूल और अखंडता का प्रमाण देता है; यह प्रस्तुति को एन्क्रिप्ट नहीं करता।
- **पासवर्ड सुरक्षा** नियंत्रित करती है कि कोई उपयोगकर्ता प्रस्तुति को खोल सकता है या संशोधित कर सकता है। यह डिजिटल हस्ताक्षर से अलग है और [Password‑Protected Presentations](/php-java/password-protected-presentation/) में वर्णित है।

PowerPoint **File > Info > Protect Presentation** के तहत **Add a Digital Signature** कमांड प्रदान करता है।

![PowerPoint Protect Presentation मेनू जिसमें Add a Digital Signature हाइलाइट किया गया है](add-digital-signature-in-powerpoint.png)

हस्ताक्षरित प्रस्तुति खोलने के बाद, PowerPoint एक हस्ताक्षर‑स्थिति सूचना प्रदर्शित कर सकता है।

![PowerPoint सूचना जो दर्शाती है कि प्रस्तुति में मान्य हस्ताक्षर हैं](digital-signature-status-in-powerpoint.png)

Aspose.Slides हस्ताक्षरों को [Presentation::getDigitalSignatures](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/#getDigitalSignatures) के माध्यम से उजागर करता है, जो एक [DigitalSignatureCollection](https://reference.aspose.com/slides/hi/php-java/aspose.slides/digitalsignaturecollection/) लौटाता है जिसके आइटम [DigitalSignature](https://reference.aspose.com/slides/hi/php-java/aspose.slides/digitalsignature/) ऑब्जेक्ट द्वारा प्रतिनिधित्व किए जाते हैं। एक प्रस्तुति में कई हस्ताक्षर हो सकते हैं।

## **PFX प्रमाणपत्र और पासवर्ड को समझें**

PFX फ़ाइल, जिसे PKCS#12 फ़ाइल के रूप में भी जाना जाता है और सामान्यतः `.pfx` या `.p12` एक्सटेंशन दिया जाता है, एक X.509 प्रमाणपत्र, उसकी निजी कुंजी और प्रमाणपत्र चेन को समाहित कर सकती है। निजी कुंजी ही धारक को हस्ताक्षर बनाने की अनुमति देती है। एक प्रमाणपत्र जिसके पास पहुँच योग्य निजी कुंजी नहीं है उसे प्रस्तुति पर हस्ताक्षर करने के लिए उपयोग नहीं किया जा सकता।

PFX पासवर्ड प्रमाणपत्र पैकेज और निजी कुंजी की सुरक्षा करता है। यह प्रस्तुति को खोलने या संपादित करने के लिए पासवर्ड नहीं है। PFX फ़ाइलों या उनके पासवर्ड को सोर्स कंट्रोल में कमिट न करें। उत्पादन में, प्रमाणपत्र फ़ाइल की पहुँच सीमित रखें और उसका पासवर्ड एक सीक्रेट स्टोर या अन्य सुरक्षित कॉन्फ़िगरेशन स्रोत से प्राप्त करें। नीचे के उदाहरण केवल पासवर्ड को कोड में एम्बेड करने से बचने के लिए पर्यावरण चर का उपयोग करते हैं।

## **प्रस्तुति में डिजिटल हस्ताक्षर जोड़ें**

एक वास्तविक प्रस्तुति कार्यप्रवाह पर हस्ताक्षर करने के लिए, मौजूदा PPTX फ़ाइल लोड करें, PFX प्रमाणपत्र और उसके पासवर्ड से एक [DigitalSignature](https://reference.aspose.com/slides/hi/php-java/aspose.slides/digitalsignature/) बनाएँ, हस्ताक्षर को प्रस्तुति के संग्रह में जोड़ें, और PPTX फ़ाइल के रूप में सहेजें।

```php
$certificatePassword = getenv("PFX_PASSWORD");
if ($certificatePassword === false || $certificatePassword === "") {
    throw new RuntimeException("Set the PFX_PASSWORD environment variable.");
}

$presentation = new Presentation("InputPresentation.pptx");
try {
    $signature = new DigitalSignature("signing-certificate.pfx", $certificatePassword);
    $signature->setComments("Approved for release.");

    $presentation->getDigitalSignatures()->add($signature);
    $presentation->save("InputPresentation-signed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

परिणाम को एक नया नाम देकर सहेजने से अनहस्ताक्षरित स्रोत फ़ाइल बनी रहती है। [DigitalSignature::setComments](https://reference.aspose.com/slides/hi/php-java/aspose.slides/digitalsignature/setcomments/) द्वारा सेट किया गया मान हस्ताक्षर के उद्देश्य का वर्णन करता है; यह कोई सुरक्षा नियंत्रण नहीं है।

## **डिजिटल हस्ताक्षरों को वैध करें**

जब आप एक हस्ताक्षरित PPTX फ़ाइल लोड करते हैं, तो [Presentation::getDigitalSignatures](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/#getDigitalSignatures) द्वारा लौटाए गए प्रत्येक आइटम का निरीक्षण करें। [DigitalSignature::isValid](https://reference.aspose.com/slides/hi/php-java/aspose.slides/digitalsignature/isvalid/) मेथड यह दर्शाता है कि एम्बेडेड हस्ताक्षर वर्तमान प्रस्तुति सामग्री के लिए वैध है या नहीं।

```php
$presentation = new Presentation("InputPresentation-signed.pptx");
try {
    $signatures = $presentation->getDigitalSignatures();
    $signatureCount = java_values($signatures->size());

    if ($signatureCount === 0) {
        echo "The presentation does not contain digital signatures." . PHP_EOL;
    } else {
        $allSignaturesAreValid = true;
        $signTimeFormat = new Java("java.text.SimpleDateFormat", "yyyy-MM-dd HH:mm:ss");
        $certificateFactoryClass = new JavaClass("java.security.cert.CertificateFactory");
        $certificateFactory = $certificateFactoryClass->getInstance("X.509");

        for ($index = 0; $index < $signatureCount; $index++) {
            $signature = $signatures->get_Item($index);
            $signatureIsValid = java_values($signature->isValid());
            $signatureStatus = $signatureIsValid ? "VALID" : "INVALID";
            $formattedSignTime = java_values($signTimeFormat->format($signature->getSignTime()));

            $certificateData = $signature->getCertificate();
            $certificateStream = new Java("java.io.ByteArrayInputStream", $certificateData);
            try {
                $certificate = $certificateFactory->generateCertificate($certificateStream);
                $signerName = java_values($certificate->getSubjectX500Principal()->getName());
            } finally {
                $certificateStream->close();
            }

            echo $signerName . ", " . $formattedSignTime . " -- " . $signatureStatus . PHP_EOL;

            $allSignaturesAreValid = $allSignaturesAreValid && $signatureIsValid;
        }

        if ($allSignaturesAreValid) {
            echo "All embedded signatures are valid for the current presentation." . PHP_EOL;
        } else {
            echo "At least one embedded signature is invalid." . PHP_EOL;
        }
    }
} finally {
    $presentation->dispose();
}
```

एक अमान्य परिणाम आमतौर पर यह दर्शाता है कि हस्ताक्षरित प्रस्तुति सामग्री या हस्ताक्षर डेटा पर हस्ताक्षर के बाद परिवर्तन हुआ है, या फ़ाइल क्षतिग्रस्त है। सभी हस्ताक्षरों को हटाने से अनहस्ताक्षरित प्रस्तुति बनती है, इसलिए केवल आइटम की वैधता की जाँच पर्याप्त नहीं है: एक सुरक्षा‑संवेदनशील कार्यप्रवाह को अपेक्षित हस्ताक्षर संख्या और अपेक्षित हस्ताक्षरकर्ता पहचानियों की उपस्थिति भी सत्यापित करनी चाहिए।

यह वैधता परिणाम पूरी प्रमाणपत्र‑विश्वास निर्णय के रूप में नहीं लिया जाना चाहिए। आपके सुरक्षा नीति के आधार पर, आपका अनुप्रयोग X.509 प्रमाणपत्र चेन का निर्माण और सत्यापन, प्रमाणपत्र वैधता तिथि और रिवोकेशन स्थिति की जाँच, अपेक्षित सब्जेक्ट या थंबप्रिंट की पुष्टि, कुंजी उपयोग की जाँच, और विश्वसनीय टाइमस्टैम्प का मूल्यांकन भी कर सकता है। केवल [DigitalSignature::getSignTime](https://reference.aspose.com/slides/hi/php-java/aspose.slides/digitalsignature/getsigntime/) मान विश्वसनीय टाइमस्टैम्प प्राधिकरण से प्रमाण नहीं है।

## **डिजिटल हस्ताक्षर हटाएँ**

हस्ताक्षर हटाने से प्रस्तुति की सुरक्षा स्थिति बदलती है। निम्न उदाहरण एक हस्ताक्षरित PPTX फ़ाइल लोड करता है, सभी हस्ताक्षरों को [DigitalSignatureCollection::clear](https://reference.aspose.com/slides/hi/php-java/aspose.slides/digitalsignaturecollection/clear/) से हटाता है, और अनहस्ताक्षरित कॉपी सहेजता है।

```php
$presentation = new Presentation("InputPresentation-signed.pptx");
try {
    $presentation->getDigitalSignatures()->clear();
    $presentation->save("InputPresentation-unsigned.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

केवल एक हस्ताक्षर हटाने के लिए, उसके शून्य‑आधारित इंडेक्स के साथ [DigitalSignatureCollection::removeAt](https://reference.aspose.com/slides/hi/php-java/aspose.slides/digitalsignaturecollection/removeat/) को कॉल करें। हस्ताक्षरित मूल को ओवरराइट करना आपके कार्यप्रवाह का स्पष्ट भाग न हो तो नई फ़ाइल में सहेजें।

## **संपादन और स्वरूप विचार**

- एक हस्ताक्षर प्रस्तुति को केवल‑पढ़ने योग्य नहीं बनाता। उपयोगकर्ता और अनुप्रयोग फ़ाइल को अभी भी संपादित कर सकते हैं, लेकिन हस्ताक्षरित सामग्री में बदलाव आमतौर पर मौजूदा हस्ताक्षर को अमान्य कर देता है।
- हस्ताक्षर करने से पहले सभी इच्छित संपादन पूर्ण करें। यदि प्रस्तुति को बदलने की आवश्यकता है, तो संशोधित प्रस्तुति को सहेजें और उस संशोधन पर फिर से हस्ताक्षर करें।
- अंतिम आउटपुट को PPTX स्वरूप में रखें। हस्ताक्षरित प्रस्तुति को किसी अन्य स्वरूप में परिवर्तित करने से मूल PPTX हस्ताक्षर वैध हस्ताक्षर के रूप में नहीं रहता।
- प्रमाणपत्र की निजी कुंजी को संवेदनशील मानें। जो कोई भी निजी कुंजी और उसका पासवर्ड प्राप्त कर लेता है, वह उस प्रमाणपत्र धारक की ओर से हस्ताक्षर बना सकता है।
- जब आपका दस्तावेज़‑रखरखाव नीति आवश्यकता रखती है, तो अनहस्ताक्षरित स्रोत या अन्य नियंत्रित प्रतिलिपि रखें।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या डिजिटल हस्ताक्षर प्रस्तुति को एन्क्रिप्ट करता है?**  
नहीं। डिजिटल हस्ताक्षर मूल और अखंडता का प्रमाण देता है, लेकिन प्रस्तुति सामग्री पढ़ने योग्य रहती है जब तक कि अलग से एन्क्रिप्शन न लागू किया गया हो। जब सामग्री तक पहुँच प्रतिबंधित हो, तो [password protection](/php-java/password-protected-presentation/) का उपयोग करें।

**क्या PFX पासवर्ड प्रस्तुति पासवर्ड के बराबर है?**  
नहीं। PFX पासवर्ड प्रमाणपत्र पैकेज में संग्रहीत निजी कुंजी को अनलॉक करता है। यह PPTX फ़ाइल को खोलने या संपादित करने को नियंत्रित नहीं करता।

**क्या मैं स्वयं‑हस्ताक्षरित प्रमाणपत्र का उपयोग कर सकता हूँ?**  
तकनीकी रूप से, यदि इसमें पहुँच योग्य निजी कुंजी शामिल है तो स्वयं‑हस्ताक्षरित प्रमाणपत्र का उपयोग किया जा सकता है। प्राप्तकर्ता स्वचालित रूप से इसे नहीं भरोसा करेंगे, जब तक कि वह प्रमाणपत्र उनके विश्वसनीय वातावरण में स्पष्ट रूप से जोड़ न दिया गया हो। सार्वजनिक या क्रॉस‑संगठन कार्यप्रवाह आमतौर पर विश्वसनीय CA द्वारा जारी प्रमाणपत्र का उपयोग करते हैं।

**एक हस्ताक्षर को अमान्य क्या बनाता है?**  
हस्ताक्षरित प्रस्तुति सामग्री या हस्ताक्षर डेटा में परिवर्तन करने से हस्ताक्षर अमान्य हो सकता है। फ़ाइल क्षति भी सत्यापन को विफल कर सकती है। यदि सभी हस्ताक्षर हटाए जाते हैं, तो प्रस्तुति अनहस्ताक्षरित रहती है, न कि अमान्य हस्ताक्षर वाली फ़ाइल।

**क्या वैध हस्ताक्षर का अर्थ है कि मुझे हस्ताक्षरकर्ता पर भरोसा होना चाहिए?**  
केवल उसी से नहीं। हस्ताक्षर की अखंडता और हस्ताक्षरकर्ता का भरोसा अलग‑अलग निर्णय हैं। उत्पादन सत्यापन नीति को प्रमाणपत्र चेन, वैधता अवधि, रिवोकेशन स्थिति, अपेक्षित पहचान, कुंजी उपयोग, और किसी भी विश्वसनीय टाइमस्टैम्प आवश्यकताओं की भी जाँच करनी चाहिए।

**प्रमाणपत्र समाप्त हो जाने पर क्या होता है?**  
प्रमाणपत्र समाप्त होना प्रस्तुति बाइट्स को नहीं बदलता, लेकिन प्रमाणपत्र‑विश्वास मूल्यांकन को प्रभावित करता है। क्या हस्ताक्षर स्वीकार्य रहता है, यह आपकी नीति और यह कि कोई वैध विश्वसनीय टाइमस्टैम्प यह साबित करता है या नहीं, इस पर निर्भर करता है। केवल प्रदर्शित हस्ताक्षर समय को विश्वसनीय टाइमस्टैम्प मानकर भरोसा न करें।

**क्या हस्ताक्षरित प्रस्तुति को अभी भी संपादित किया जा सकता है?**  
हां। हस्ताक्षर फ़ाइल को लॉक नहीं करता। हस्ताक्षरित सामग्री को संपादित करने से आमतौर पर मौजूदा हस्ताक्षर अमान्य हो जाता है, इसलिए पहले प्रस्तुति समाप्त करें और अंतिम संशोधन पर हस्ताक्षर करें।

**क्या प्रस्तुति में एक से अधिक हस्ताक्षर हो सकते हैं?**  
हां। सहेजने से पहले प्रत्येक हस्ताक्षर को [Presentation::getDigitalSignatures](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/#getDigitalSignatures) द्वारा लौटाए गए संग्रह में जोड़ें। सत्यापन के दौरान, प्रत्येक हस्ताक्षर का निरीक्षण करें और सुनिश्चित करें कि सभी आवश्यक हस्ताक्षरकर्ता मौजूद हैं।

**कौन से प्रस्तुति स्वरूप इन कार्यों का समर्थन करते हैं?**  
Aspose.Slides यहाँ वर्णित डिजिटल‑हस्ताक्षर कार्यों को केवल PPTX के लिए समर्थन करता है। PPT और OpenDocument प्रस्तुति स्वरूप इस API कार्यप्रवाह द्वारा समर्थित नहीं हैं।

**क्या मैं स्लाइड्स को प्रभावित किए बिना हस्ताक्षर हटा सकता हूँ?**  
हां। आप एक हस्ताक्षर हटा सकते हैं या सम्पूर्ण संग्रह को साफ़ करके फिर प्रस्तुति सहेज सकते हैं। स्लाइड सामग्री उपलब्ध रहती है, पर सहेजी गई फ़ाइल में अब हटाए गए हस्ताक्षर का प्रमाण नहीं होगा।