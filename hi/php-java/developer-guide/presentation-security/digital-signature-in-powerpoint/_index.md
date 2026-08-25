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
description: "कैसे मौजूदा PPTX प्रस्तुतियों को PFX प्रमाणपत्रों के साथ हस्ताक्षर करें और Java के माध्यम से PHP के लिए Aspose.Slides का उपयोग करके डिजिटल हस्ताक्षर सत्यापित या हटाएँ, यह सीखें।"
---
## **अवलोकन**

डिजिटल हस्ताक्षर प्राप्तकर्ता को यह निर्धारित करने में मदद करता है कि किसने प्रस्तुति पर हस्ताक्षर किया और क्या हस्ताक्षरित सामग्री बदल गई है। यहाँ तीन संबंधित सुरक्षा अवधारणाएँ महत्वपूर्ण हैं:

- एक **डिजिटल प्रमाणपत्र** एक इलेक्ट्रॉनिक क्रेडेंशियल है जो एक पहचान को सार्वजनिक कुंजी से जोड़ता है। एक भरोसेमंद प्रमाणपत्र प्राधिकरण (CA) प्रमाणपत्र जारी कर सकता है, या कोई संगठन आंतरिक कार्यप्रवाह के लिए स्वयं‑हस्ताक्षरित प्रमाणपत्र का उपयोग कर सकता है।
- एक **डिजिटल हस्ताक्षर** प्रस्तुति सामग्री और प्रमाणपत्र धारक की निजी कुंजी से बनाया जाता है। इसके बाद प्रमाणपत्र की सार्वजनिक कुंजी का उपयोग करके हस्ताक्षर को सत्यापित किया जा सकता है। हस्ताक्षर मूल और अखंडता का प्रमाण प्रदान करता है; यह प्रस्तुति को एन्क्रिप्ट नहीं करता।
- **पासवर्ड सुरक्षा** यह नियंत्रित करती है कि उपयोगकर्ता प्रस्तुति को खोल या संशोधित कर सकता है या नहीं। यह डिजिटल हस्ताक्षर से अलग है और इसे [Password-Protected Presentations](/slides/hi/php-java/password-protected-presentation/) में वर्णित किया गया है।

PowerPoint **File > Info > Protect Presentation** के तहत **Add a Digital Signature** कमांड प्रदान करता है।

![PowerPoint Protect Presentation मेन्यू जिसमें Add a Digital Signature हाईलाइट किया गया है](add-digital-signature-in-powerpoint.png)

एक हस्ताक्षरित प्रस्तुति खुलने पर, PowerPoint हस्ताक्षर-स्थिति नोटिफिकेशन दिखा सकता है।

![PowerPoint नोटिफिकेशन जो दर्शाता है कि प्रस्तुति में वैध हस्ताक्षर हैं](digital-signature-status-in-powerpoint.png)

Aspose.Slides हस्ताक्षरों को [Presentation::getDigitalSignatures](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/#getDigitalSignatures) के माध्यम से उजागर करता है, जो एक [DigitalSignatureCollection](https://reference.aspose.com/slides/hi/php-java/aspose.slides/digitalsignaturecollection/) लौटाता है, जिसके आइटम [DigitalSignature](https://reference.aspose.com/slides/hi/php-java/aspose.slides/digitalsignature/) ऑब्जेक्ट्स द्वारा प्रतिनिधित्व किए जाते हैं। एक प्रस्तुति में कई हस्ताक्षर हो सकते हैं।

## **PFX प्रमाणपत्र और पासवर्ड को समझें**

एक PFX फ़ाइल, जिसे PKCS#12 फ़ाइल भी कहा जाता है और सामान्यतः `.pfx` या `.p12` एक्सटेंशन दिया जाता है, में एक X.509 प्रमाणपत्र, उसकी निजी कुंजी, और प्रमाणपत्र चेन सम्मिलित हो सकते हैं। निजी कुंजी वह है जो धारक को हस्ताक्षर बनाने की अनुमति देती है। एक प्रमाणपत्र जिसमें पहुँच योग्य निजी कुंजी नहीं है, उसे प्रस्तुति पर हस्ताक्षर करने के लिए उपयोग नहीं किया जा सकता।

PFX पासवर्ड प्रमाणपत्र पैकेज और निजी कुंजी की सुरक्षा करता है। यह प्रस्तुति खोलने या संपादित करने के लिए पासवर्ड नहीं है। PFX फ़ाइलों या उनके पासवर्ड को स्रोत नियंत्रण में कमिट न करें। उत्पादन में, प्रमाणपत्र फ़ाइल तक पहुँच को सीमित करें और पासवर्ड को एक सीक्रेट स्टोर या किसी अन्य संरक्षित कॉन्फ़िगरेशन स्रोत से प्राप्त करें। नीचे के उदाहरण केवल कोड में पासवर्ड एम्बेड करने से बचने के लिए एक परिवेशीय चर का उपयोग करते हैं।

## **प्रस्तुति में डिजिटल हस्ताक्षर जोड़ें**

एक वास्तविक प्रस्तुति कार्यप्रवाह को हस्ताक्षर करने के लिए, मौजूदा PPTX फ़ाइल को लोड करें, PFX प्रमाणपत्र और उसके पासवर्ड से एक [DigitalSignature](https://reference.aspose.com/slides/hi/php-java/aspose.slides/digitalsignature/) बनाएं, हस्ताक्षर को प्रस्तुति के संग्रह में जोड़ें, और PPTX फ़ाइल में सहेजें।

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

परिणाम को नए नाम से सहेजने से बिना हस्ताक्षर वाले स्रोत फ़ाइल संरक्षित रहती है। [DigitalSignature::setComments](https://reference.aspose.com/slides/hi/php-java/aspose.slides/digitalsignature/setcomments/) द्वारा सेट किया गया मान हस्ताक्षर के उद्देश्य का वर्णन करता है; यह कोई सुरक्षा नियंत्रण नहीं है।

## **डिजिटल हस्ताक्षरों को मान्य करें**

जब आप एक हस्ताक्षरित PPTX फ़ाइल लोड करते हैं, तो [Presentation::getDigitalSignatures](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/#getDigitalSignatures) द्वारा लौटाए गए प्रत्येक आइटम की जांच करें। [DigitalSignature::isValid](https://reference.aspose.com/slides/hi/php-java/aspose.slides/digitalsignature/isvalid/) विधि दर्शाती है कि एम्बेडेड हस्ताक्षर वर्तमान प्रस्तुति सामग्री के लिए वैध है या नहीं।

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

एक अमान्य परिणाम सामान्यतः इसका मतलब है कि हस्ताक्षरित प्रस्तुति सामग्री या हस्ताक्षर डेटा में हस्ताक्षर के बाद परिवर्तन हुआ है, या फ़ाइल क्षतिग्रस्त है। सभी हस्ताक्षर हटाने से एक बिना हस्ताक्षर वाली प्रस्तुति बनती है, इसलिए केवल आइटम की वैधता जांचना पर्याप्त नहीं है: एक सुरक्षा‑संवेदनशील कार्यप्रवाह को यह भी सुनिश्चित करना चाहिए कि अपेक्षित हस्ताक्षरों की संख्या और अपेक्षित हस्ताक्षरकर्ता पहचान मौजूद हों।

यह वैधता परिणाम संपूर्ण प्रमाणपत्र‑विश्वास निर्णय नहीं माना जाना चाहिए। आपके सुरक्षा नीति के आधार पर, आपके अनुप्रयोग को X.509 प्रमाणपत्र चेन बनाना और सत्यापित करना, प्रमाणपत्र की वैधता तिथियों और निरस्तीकरण स्थिति की जांच करना, अपेक्षित विषय या थंबप्रिंट की पुष्टि करना, कुंजी उपयोग सत्यापित करना, और एक भरोसेमंद टाइमस्टैंप का मूल्यांकन करना पड़ सकता है। केवल [DigitalSignature::getSignTime](https://reference.aspose.com/slides/hi/php-java/aspose.slides/digitalsignature/getsigntime/) का मान भरोसेमंद टाइमस्टैंप प्राधिकरण से प्रमाण नहीं है।

## **डिजिटल हस्ताक्षर हटाएँ**

हस्ताक्षर हटाने से प्रस्तुति की सुरक्षा स्थिति बदल जाती है। नीचे का उदाहरण एक हस्ताक्षरित PPTX फ़ाइल लोड करता है, सभी हस्ताक्षरों को [DigitalSignatureCollection::clear](https://reference.aspose.com/slides/hi/php-java/aspose.slides/digitalsignaturecollection/clear/) से हटाता है, और एक बिना हस्ताक्षर की प्रतिलिपि सहेजता है।

```php
$presentation = new Presentation("InputPresentation-signed.pptx");
try {
    $presentation->getDigitalSignatures()->clear();
    $presentation->save("InputPresentation-unsigned.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

केवल एक हस्ताक्षर हटाने के लिए, उसके शून्य‑आधारित सूचकांक के साथ [DigitalSignatureCollection::removeAt](https://reference.aspose.com/slides/hi/php-java/aspose.slides/digitalsignaturecollection/removeat/) को कॉल करें। सहेजते समय नई फ़ाइल बनाएं, जब तक कि मौजूदा हस्ताक्षरित फ़ाइल को ओवरराइट करना आपका स्पष्ट कार्यप्रवाह न हो।

## **संपादन और स्वरूप विचार**

- हस्ताक्षर प्रस्तुति को केवल‑पढ़ने योग्य नहीं बनाता। उपयोगकर्ता और अनुप्रयोग अभी भी फ़ाइल को संपादित कर सकते हैं, लेकिन हस्ताक्षरित सामग्री में परिवर्तन आमतौर पर मौजूदा हस्ताक्षर को अमान्य कर देता है।
- हस्ताक्षर करने से पहले सभी इच्छित संपादन पूर्ण करें। यदि प्रस्तुति को बदलना आवश्यक है, तो संशोधित प्रस्तुति को सहेजें और फिर उस संशोधन पर पुनः हस्ताक्षर करें।
- अंतिम आउटपुट को PPTX स्वरूप में रखें। एक हस्ताक्षरित प्रस्तुति को किसी अन्य स्वरूप में बदलने से मूल PPTX हस्ताक्षर वैध रूप में परिवर्तित फ़ाइल में नहीं रहता।
- प्रमाणपत्र की निजी कुंजी को संवेदनशील मानें। जो भी निजी कुंजी और उसका पासवर्ड प्राप्त करता है, वह उस प्रमाणपत्र धारक की ओर से हस्ताक्षर बना सकता है।
- जब आपके दस्तावेज़‑रखरखाव नीति में आवश्यकता हो तो बिना हस्ताक्षर वाले स्रोत या अन्य नियंत्रित प्रतिलिपि को रखें।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या डिजिटल हस्ताक्षर प्रस्तुति को एन्क्रिप्ट करता है?**

नहीं। डिजिटल हस्ताक्षर मूल और अखंडता का प्रमाण प्रदान करता है, लेकिन प्रस्तुति सामग्री पढ़ने योग्य बनी रहती है जब तक अलग से एन्क्रिप्शन लागू न किया गया हो। सामग्री तक पहुँच को प्रतिबंधित करने के लिए [password protection](/slides/hi/php-java/password-protected-presentation/) का उपयोग करें।

**क्या PFX पासवर्ड प्रस्तुति पासवर्ड के समान है?**

नहीं। PFX पासवर्ड प्रमाणपत्र पैकेज में संग्रहीत निजी कुंजी को अनलॉक करता है। यह नियंत्रित नहीं करता कि कौन PPTX फ़ाइल खोल या संपादित कर सकता है।

**क्या मैं स्वयं‑हस्ताक्षरित प्रमाणपत्र उपयोग कर सकता हूँ?**

तकनीकी रूप से, स्वयं‑हस्ताक्षरित प्रमाणपत्र का उपयोग किया जा सकता है जब उसमें पहुँच योग्य निजी कुंजी हो। प्राप्तकर्ता स्वचालित रूप से इसे विश्वसनीय नहीं मानेंगे, जब तक कि वह प्रमाणपत्र उनके भरोसेमंद वातावरण में स्पष्ट रूप से जोड़ा न गया हो। सार्वजनिक या क्रॉस‑संगठन कार्यप्रवाह सामान्यतः भरोसेमंद CA द्वारा जारी प्रमाणपत्र का उपयोग करता है।

**हस्ताक्षर को अमान्य क्या बनाता है?**

हस्ताक्षरित प्रस्तुति सामग्री या हस्ताक्षर डेटा में हस्ताक्षर के बाद परिवर्तन करने से हस्ताक्षर अमान्य हो सकता है। फ़ाइल भ्रष्टाचार भी सत्यापन में विफलता का कारण बन सकता है। यदि सभी हस्ताक्षर हटा दिए जाएँ, तो प्रस्तुति बिना हस्ताक्षर वाली बन जाती है, न कि अमान्य हस्ताक्षर वाली फ़ाइल।

**क्या वैध हस्ताक्षर का मतलब है कि मुझे हस्ताक्षरकर्ता पर भरोसा करना चाहिए?**

स्वयं में नहीं। हस्ताक्षर की अखंडता और हस्ताक्षरकर्ता का विश्वास अलग‑अलग निर्णय हैं। उत्पादन सत्यापन नीति को प्रमाणपत्र चेन, वैधता अवधि, निरस्तीकरण स्थिति, अपेक्षित पहचान, कुंजी उपयोग, और किसी भी भरोसेमंद टाइमस्टैंप आवश्यकताओं की भी जांच करनी चाहिए।

**प्रमाणपत्र समाप्त होने पर क्या होता है?**

प्रमाणपत्र समाप्त होने से प्रस्तुति बाइट्स नहीं बदलते, लेकिन यह प्रमाणपत्र‑विश्वास मूल्यांकन को प्रभावित करता है। हस्ताक्षर अभी भी स्वीकार्य रहेगा या नहीं, यह आपकी नीति और यह कि क्या वैध भरोसेमंद टाइमस्टैंप यह सिद्ध करता है कि हस्ताक्षर प्रमाणपत्र वैध होने के दौरान हुआ था, पर निर्भर करता है। केवल प्रदर्शित हस्ताक्षर समय पर भरोसा न करें।

**क्या हस्ताक्षरित प्रस्तुति को फिर भी संपादित किया जा सकता है?**

हां। हस्ताक्षर फ़ाइल को लॉक नहीं करता। हस्ताक्षरित सामग्री को संपादित करने से आमतौर पर मौजूदा हस्ताक्षर अमान्य हो जाता है, इसलिए पहले प्रस्तुति को अंतिम रूप दें और फिर अंतिम संशोधन पर हस्ताक्षर करें।

**क्या एक प्रस्तुति में एक से अधिक हस्ताक्षर हो सकते हैं?**

हां। सहेजने से पहले प्रत्येक हस्ताक्षर को [Presentation::getDigitalSignatures](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/#getDigitalSignatures) द्वारा लौटाए गए संग्रह में जोड़ें। सत्यापन के दौरान प्रत्येक हस्ताक्षर की जाँच करें और सुनिश्चित करें कि सभी आवश्यक हस्ताक्षरकर्ता मौजूद हैं।

**कौन‑से प्रस्तुति स्वरूप इन कार्यों को समर्थन देते हैं?**

Aspose.Slides यहाँ वर्णित डिजिटल‑हस्ताक्षर कार्यों को केवल PPTX के लिए समर्थन करता है। PPT और OpenDocument प्रस्तुति स्वरूप इस API कार्यप्रवाह द्वारा समर्थित नहीं हैं।

**क्या मैं हस्ताक्षर हटाकर स्लाइड्स को प्रभावित किए बिना रख सकता हूँ?**

हां। आप एक हस्ताक्षर हटाकर या पूरे संग्रह को साफ़ करके फिर प्रस्तुति सहेज सकते हैं। स्लाइड सामग्री उपलब्ध रहती है, लेकिन सहेजी गई फ़ाइल में हटाया गया हस्ताक्षर प्रमाण नहीं रहता।