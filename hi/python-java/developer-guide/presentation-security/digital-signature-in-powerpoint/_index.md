---
title: Python में प्रस्तुतियों में डिजिटल हस्ताक्षर जोड़ें
linktitle: डिजिटल हस्ताक्षर
type: docs
weight: 10
url: /hi/python-java/digital-signature-in-powerpoint/
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
- Python
- Aspose.Slides
description: "जानें कि कैसे मौजूदा PPTX प्रस्तुतियों को PFX प्रमाणपत्रों के साथ हस्ताक्षर किया जाए और Aspose.Slides for Python via Java का उपयोग करके डिजिटल हस्ताक्षरों को सत्यापित या हटाया जाए।"
---
## **अवलोकन**

डिजिटल हस्ताक्षर प्राप्तकर्ता को यह निर्धारित करने में मदद करता है कि किसने प्रस्तुति पर हस्ताक्षर किया और क्या हस्ताक्षरित सामग्री बदल गई है। यहाँ तीन संबंधित सुरक्षा अवधारणाएँ महत्वपूर्ण हैं:

- एक **डिजिटल प्रमाणपत्र** एक इलेक्ट्रॉनिक क्रेडेंशियल है जो एक पहचान को सार्वजनिक कुंजी से जोड़ता है। एक विश्वसनीय प्रमाणपत्र प्राधिकार (CA) प्रमाणपत्र जारी कर सकता है, या कोई संस्था आंतरिक कार्यप्रवाह के लिए स्व-हस्ताक्षरित प्रमाणपत्र उपयोग कर सकती है।
- एक **डिजिटल हस्ताक्षर** प्रस्तुति सामग्री और प्रमाणपत्र धारक की निजी कुंजी से बनाया जाता है। प्रमाणपत्र की सार्वजनिक कुंजी का उपयोग फिर हस्ताक्षर को सत्यापित करने के लिए किया जा सकता है। हस्ताक्षर उत्पत्ति और अखंडता का प्रमाण देता है; यह प्रस्तुति को एन्क्रिप्ट नहीं करता।
- **पासवर्ड संरक्षण** नियंत्रित करता है कि कोई उपयोगकर्ता प्रस्तुति को खोल या संशोधित कर सकता है या नहीं। यह डिजिटल हस्ताक्षर से अलग है और इसे [Password-Protected Presentations](/slides/hi/python-java/password-protected-presentation/) में वर्णित किया गया है।

PowerPoint **Add a Digital Signature** कमांड **File > Info > Protect Presentation** के तहत प्रदान करता है।

![PowerPoint Protect Presentation मेनू जिसमें Add a Digital Signature हाइलाइट किया गया है](add-digital-signature-in-powerpoint.png)

हस्ताक्षरित प्रस्तुति खोलने के बाद, PowerPoint एक हस्ताक्षर-स्थिति सूचना प्रदर्शित कर सकता है।

![PowerPoint सूचना जो बताती है कि प्रस्तुति में वैध हस्ताक्षर हैं](digital-signature-status-in-powerpoint.png)

Aspose.Slides हस्ताक्षरों को [Presentation.getDigitalSignatures](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#getDigitalSignatures) के माध्यम से उजागर करता है, जो एक [DigitalSignatureCollection](https://reference.aspose.com/slides/hi/python-java/aspose.slides/digitalsignaturecollection/) लौटाता है जिसका प्रत्येक आइटम एक [DigitalSignature](https://reference.aspose.com/slides/hi/python-java/aspose.slides/digitalsignature/) का उदाहरण है। एक प्रस्तुति में कई हस्ताक्षर हो सकते हैं।

## **PFX प्रमाणपत्र और पासवर्ड को समझें**

PFX फ़ाइल, जिसे PKCS#12 फ़ाइल भी कहा जाता है और आमतौर पर `.pfx` या `.p12` एक्सटेंशन देती है, एक X.509 प्रमाणपत्र, उसकी निजी कुंजी, और प्रमाणपत्र श्रृंखला रख सकती है। निजी कुंजी वह है जो धारक को हस्ताक्षर बनाने की अनुमति देती है। बिना पहुँच योग्य निजी कुंजी वाला प्रमाणपत्र प्रस्तुति पर हस्ताक्षर करने के लिए उपयोग नहीं किया जा सकता।

PFX पासवर्ड प्रमाणपत्र पैकेज और निजी कुंजी की रक्षा करता है। यह प्रस्तुति को खोलने या संपादित करने के लिए पासवर्ड नहीं है। PFX फ़ाइलों या उनके पासवर्ड को स्रोत नियंत्रण में कमिट न करें। उत्पादन में, प्रमाणपत्र फ़ाइल तक पहुँच को सीमित रखें और उसका पासवर्ड किसी सीक्रेट स्टोर या अन्य सुरक्षित कॉन्फ़िगरेशन स्रोत से प्राप्त करें। नीचे के उदाहरण केवल पासवर्ड को कोड में एम्बेड करने से बचने के लिए एक पर्यावरण चर का उपयोग करते हैं।

## **प्रस्तुति में डिजिटल हस्ताक्षर जोड़ें**

एक वास्तविक प्रस्तुति कार्यप्रवाह को हस्ताक्षर करने के लिए, मौजूदा PPTX फ़ाइल लोड करें, एक PFX प्रमाणपत्र और उसके पासवर्ड से एक [DigitalSignature](https://reference.aspose.com/slides/hi/python-java/aspose.slides/digitalsignature/) बनाएं, हस्ताक्षर को प्रस्तुति के संग्रह में जोड़ें, और PPTX फ़ाइल में सहेजें।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

import os
from asposeslides.api import Presentation, DigitalSignature, SaveFormat

certificate_password = os.environ.get("PFX_PASSWORD")
if not certificate_password:
    print("Set the PFX_PASSWORD environment variable.")
else:
    presentation = Presentation("InputPresentation.pptx")
    try:
        signature = DigitalSignature("signing-certificate.pfx", certificate_password)
        signature.setComments("Approved for release.")

        presentation.getDigitalSignatures().add(signature)
        presentation.save("InputPresentation-signed.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()
```

परिणाम को नए नाम से सहेजने से अनहस्ताक्षरित स्रोत फ़ाइल सुरक्षित रहती है। [DigitalSignature.setComments](https://reference.aspose.com/slides/hi/python-java/aspose.slides/digitalsignature/#setComments) द्वारा सेट किया गया मान हस्ताक्षर का उद्देश्य वर्णित करता है; यह कोई सुरक्षा नियंत्रण नहीं है।

## **डिजिटल हस्ताक्षरों को सत्यापित करें**

जब आप एक हस्ताक्षरित PPTX फ़ाइल लोड करते हैं, तो [Presentation.getDigitalSignatures](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#getDigitalSignatures) द्वारा लौटाए गए प्रत्येक आइटम की जाँच करें। [DigitalSignature.isValid](https://reference.aspose.com/slides/hi/python-java/aspose.slides/digitalsignature/#isValid) मेथड यह दर्शाता है कि एम्बेड किया गया हस्ताक्षर वर्तमान प्रस्तुति सामग्री के लिए वैध है या नहीं।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

ByteArrayInputStream = jpype.JClass("java.io.ByteArrayInputStream")
CertificateFactory = jpype.JClass("java.security.cert.CertificateFactory")
SimpleDateFormat = jpype.JClass("java.text.SimpleDateFormat")

presentation = Presentation("InputPresentation-signed.pptx")
try:
    signatures = presentation.getDigitalSignatures()
    signature_count = signatures.size()

    if signature_count == 0:
        print("The presentation does not contain digital signatures.")
    else:
        all_signatures_are_valid = True
        sign_time_format = SimpleDateFormat("yyyy-MM-dd HH:mm:ss")
        certificate_factory = CertificateFactory.getInstance("X.509")

        for signature in signatures:
            signature_is_valid = signature.isValid()
            signature_status = "VALID" if signature_is_valid else "INVALID"
            sign_time = signature.getSignTime()
            formatted_sign_time = sign_time_format.format(sign_time)

            certificate_data = signature.getCertificate()
            certificate_stream = ByteArrayInputStream(certificate_data)
            certificate = certificate_factory.generateCertificate(certificate_stream)
            signer_principal = certificate.getSubjectX500Principal()
            signer_name = signer_principal.getName()

            print(f"{signer_name}, {formatted_sign_time} -- {signature_status}")

            all_signatures_are_valid = all_signatures_are_valid and signature_is_valid

        if all_signatures_are_valid:
            print("All embedded signatures are valid for the current presentation.")
        else:
            print("At least one embedded signature is invalid.")
finally:
    presentation.dispose()
```

एक अमान्य परिणाम आमतौर पर यह दर्शाता है कि हस्ताक्षरित प्रस्तुति सामग्री या हस्ताक्षर डेटा हस्ताक्षर के बाद बदल गया है, या फ़ाइल क्षतिग्रस्त है। सभी हस्ताक्षर हटाने से प्रस्तुति अनहस्ताक्षरित बन जाती है, इसलिए केवल आइटम की वैधता जाँचना पर्याप्त नहीं है: एक सुरक्षा-संकल्पित कार्यप्रवाह को यह भी सत्यापित करना चाहिए कि अपेक्षित संख्या में हस्ताक्षर और अपेक्षित हस्ताक्षरकर्ता पहचान मौजूद हैं।

यह वैधता परिणाम पूरी प्रमाणपत्र-विश्वास निर्णय के रूप में नहीं माना जाना चाहिए। आपके सुरक्षा नीति के आधार पर, आपका अनुप्रयोग X.509 प्रमाणपत्र श्रृंखला का निर्माण और सत्यापन, प्रमाणपत्र की वैधता तिथियों और रद्दीकरण स्थिति की जाँच, अपेक्षित विषय या थंबप्रिंट की पुष्टि, कुंजी उपयोग की जाँच, और एक विश्वसनीय टाइमस्टैंप का मूल्यांकन भी कर सकता है। केवल [DigitalSignature.getSignTime](https://reference.aspose.com/slides/hi/python-java/aspose.slides/digitalsignature/#getSignTime) मान स्वयं विश्वसनीय टाइमस्टैंप प्राधिकारी से प्रमाण नहीं है।

## **डिजिटल हस्ताक्षर हटाएँ**

हस्ताक्षर हटाने से प्रस्तुति की सुरक्षा स्थिति बदल जाती है। निम्न उदाहरण एक हस्ताक्षरित PPTX फ़ाइल लोड करता है, सभी हस्ताक्षरों को [DigitalSignatureCollection.clear](https://reference.aspose.com/slides/hi/python-java/aspose.slides/digitalsignaturecollection/#clear) से हटाता है, और एक अनहस्ताक्षरित कॉपी सहेजता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("InputPresentation-signed.pptx")
try:
    presentation.getDigitalSignatures().clear()
    presentation.save("InputPresentation-unsigned.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

केवल एक हस्ताक्षर हटाने के लिए, उसके शून्य-आधारित सूचकांक के साथ [DigitalSignatureCollection.removeAt](https://reference.aspose.com/slides/hi/python-java/aspose.slides/digitalsignaturecollection/#removeAt) को कॉल करें। सहेजने के लिए नया फ़ाइल बनाएँ, जब तक कि हस्ताक्षरित मूल फ़ाइल को ओवरराइट करना आपका स्पष्ट कार्यप्रवाह न हो।

## **संपादन और फ़ॉर्मेट विचार**

- एक हस्ताक्षर प्रस्तुति को केवल-पढ़ने योग्य नहीं बनाता। उपयोगकर्ता और अनुप्रयोग अभी भी फ़ाइल को संपादित कर सकते हैं, लेकिन हस्ताक्षरित सामग्री में परिवर्तन सामान्यतः मौजूदा हस्ताक्षर को अमान्य कर देता है।
- हस्ताक्षर करने से पहले सभी इच्छित संपादन समाप्त कर लें। यदि प्रस्तुति को बदलना आवश्यक है, तो संशोधित प्रस्तुति सहेजें और उस संशोधन पर दोबारा हस्ताक्षर करें।
- अंतिम आउटपुट को PPTX फ़ॉर्मेट में रखें। एक हस्ताक्षरित प्रस्तुति को किसी अन्य फ़ॉर्मेट में परिवर्तित करने से मूल PPTX हस्ताक्षर वैध हस्ताक्षर के रूप में परिवर्तित फ़ाइल में नहीं रहता।
- प्रमाणपत्र की निजी कुंजी को संवेदनशील मानें। जो कोई भी निजी कुंजी और उसका पासवर्ड प्राप्त कर लेता है, वह ऐसा हस्ताक्षर बना सकता है जो उस प्रमाणपत्र धारक से आया हुआ दिखे।
- जब आपके दस्तावेज़-रखरखाव नीति के अनुसार आवश्यक हो, तो अनहस्ताक्षरित स्रोत या कोई अन्य नियंत्रित प्रतिलिपि बनाए रखें।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या डिजिटल हस्ताक्षर प्रस्तुति को एन्क्रिप्ट करता है?**

नहीं। डिजिटल हस्ताक्षर उत्पत्ति और अखंडता का प्रमाण देता है, लेकिन प्रस्तुति सामग्री पढ़ने योग्य रहती है जब तक कि अलग एन्क्रिप्शन लागू न किया गया हो। जब सामग्री तक पहुँच प्रतिबंधित हो, तो [password protection](/slides/hi/python-java/password-protected-presentation/) का उपयोग करें।

**क्या PFX पासवर्ड प्रस्तुति के पासवर्ड के समान है?**

नहीं। PFX पासवर्ड प्रमाणपत्र पैकेज में संग्रहीत निजी कुंजी को अनलॉक करता है। यह यह नियंत्रित नहीं करता कि कौन PPTX फ़ाइल को खोल या संपादित कर सकता है।

**क्या मैं स्व-हस्ताक्षरित प्रमाणपत्र उपयोग कर सकता हूँ?**

तकनीकी रूप से, यदि इसमें पहुँच योग्य निजी कुंजी हो तो स्व-हस्ताक्षरित प्रमाणपत्र उपयोग किया जा सकता है। प्राप्तकर्ता इसे स्वचालित रूप से भरोसेमंद नहीं मानेंगे, जब तक कि वह प्रमाणपत्र स्पष्ट रूप से उनके भरोसेमंद वातावरण में न जोड़ा गया हो। सार्वजनिक या पार-संस्थागत कार्यप्रवाह सामान्यतः भरोसेमंद CA द्वारा जारी प्रमाणपत्र का उपयोग करते हैं।

**हस्ताक्षर को अमान्य क्या बनाता है?**

हस्ताक्षरित प्रस्तुति सामग्री या हस्ताक्षर डेटा को हस्ताक्षर के बाद बदलना हस्ताक्षर को अमान्य कर सकता है। फ़ाइल क्षति भी सत्यापन को विफल कर सकती है। यदि सभी हस्ताक्षर हटा दिए जाते हैं, तो प्रस्तुति अनहस्ताक्षरित बन जाती है, न कि एक अमान्य हस्ताक्षर वाला फ़ाइल।

**क्या वैध हस्ताक्षर का अर्थ है कि मुझे हस्ताक्षरकर्ता पर भरोसा होना चाहिए?**

केवल इसके आधार पर नहीं। हस्ताक्षर की अखंडता और हस्ताक्षरकर्ता का भरोसा अलग निर्णय होते हैं। उत्पादन सत्यापन नीति को प्रमाणपत्र श्रृंखला, वैधता अवधि, रद्दीकरण स्थिति, अपेक्षित पहचान, कुंजी उपयोग, और किसी भी भरोसेमंद टाइमस्टैंप आवश्यकताओं की भी जाँच करनी चाहिए।

**जब प्रमाणपत्र समाप्त हो जाता है तो क्या होता है?**

प्रमाणपत्र समाप्ति प्रस्तुति बाइट्स को नहीं बदलती, लेकिन यह प्रमाणपत्र-विश्वास मूल्यांकन को प्रभावित करती है। एक हस्ताक्षर स्वीकार्य रहता है या नहीं, यह आपकी नीति और यह कि क्या एक विश्वसनीय टाइमस्टैंप यह साबित करता है कि हस्ताक्षर तब हुआ था जब प्रमाणपत्र वैध था, पर निर्भर करता है। केवल प्रदर्शित हस्ताक्षर समय को भरोसेमंद टाइमस्टैंप मानकर निर्भर न रहें।

**क्या एक हस्ताक्षरित प्रस्तुति फिर भी संपादित की जा सकती है?**

हां। हस्ताक्षर फ़ाइल को लॉक नहीं करता। हस्ताक्षरित सामग्री को संपादित करने से सामान्यतः मौजूदा हस्ताक्षर अमान्य हो जाता है, इसलिए पहले प्रस्तुति को अंतिम रूप दें और फिर अंतिम संशोधन पर हस्ताक्षर करें।

**क्या प्रस्तुति में एक से अधिक हस्ताक्षर हो सकते हैं?**

हां। सहेजने से पहले प्रत्येक हस्ताक्षर को [Presentation.getDigitalSignatures](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#getDigitalSignatures) द्वारा लौटाए गए संग्रह में जोड़ें। सत्यापन के दौरान, प्रत्येक हस्ताक्षर की जाँच करें और यह पुष्टि करें कि सभी आवश्यक हस्ताक्षरकर्ता उपस्थित हैं।

**कौन‑से प्रस्तुति फ़ॉर्मेट इन ऑपरेशनों का समर्थन करते हैं?**

Aspose.Slides यहाँ वर्णित डिजिटल‑हस्ताक्षर कार्यों को केवल PPTX के लिए समर्थन देता है। PPT और OpenDocument प्रस्तुति फ़ॉर्मेट इस API कार्यप्रवाह द्वारा समर्थित नहीं हैं।

**क्या मैं किसी हस्ताक्षर को स्लाइड्स को प्रभावित किए बिना हटा सकता हूँ?**

हां। आप एक हस्ताक्षर हटा सकते हैं या संपूर्ण संग्रह को साफ कर सकते हैं और फिर प्रस्तुति सहेज सकते हैं। स्लाइड सामग्री उपलब्ध रहती है, लेकिन सहेजी गई फ़ाइल में हटाया गया हस्ताक्षर प्रमाण नहीं रहेगा।