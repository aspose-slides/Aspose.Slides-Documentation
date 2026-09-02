---
title: C++ में प्रस्तुतियों में डिजिटल हस्ताक्षर जोड़ें
linktitle: डिजिटल हस्ताक्षर
type: docs
weight: 10
url: /hi/cpp/digital-signature-in-powerpoint/
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
- C++
- Aspose.Slides
description: "सीखें कि कैसे PFX प्रमाणपत्रों के साथ मौजूदा PPTX प्रस्तुतियों पर हस्ताक्षर किया जाए और C++ के लिए Aspose.Slides का उपयोग करके डिजिटल हस्ताक्षरों को सत्यापित या हटाया जा सके।"
---
## **अवलोकन**

एक डिजिटल हस्ताक्षर प्राप्तकर्ता को यह निर्धारित करने में मदद करता है कि किसने प्रस्तुति पर हस्ताक्षर किया और हस्ताक्षरित सामग्री में कोई परिवर्तन हुआ है या नहीं। यहाँ तीन संबंधित सुरक्षा अवधारणाएँ महत्वपूर्ण हैं:

- एक **digital certificate** एक इलेक्ट्रॉनिक प्रमाणपत्र है जो एक पहचान को सार्वजनिक कुंजी से जोड़ता है। एक विश्वसनीय प्रमाणपत्र प्राधिकरण (CA) प्रमाणपत्र जारी कर सकता है, या कोई संगठन आंतरिक कार्यप्रवाह के लिए स्वयं‑हस्ताक्षरित प्रमाणपत्र का उपयोग कर सकता है।
- एक **digital signature** प्रस्तुति सामग्री और प्रमाणपत्र धारक की निजी कुंजी से बनाया जाता है। प्रमाणपत्र की सार्वजनिक कुंजी का उपयोग करके हस्ताक्षर को सत्यापित किया जा सकता है। हस्ताक्षर मूल और अखंडता का प्रमाण प्रदान करता है; यह प्रस्तुति को एन्क्रिप्ट नहीं करता।
- **Password protection** नियंत्रित करता है कि उपयोगकर्ता प्रस्तुति को खोल या संशोधित कर सकता है या नहीं। यह डिजिटल हस्ताक्षर के अलग है और इसे [Password-Protected Presentations](/cpp/password-protected-presentation/) में वर्णित किया गया है।

PowerPoint **Add a Digital Signature** कमांड को **File > Info > Protect Presentation** के अंतर्गत उपलब्ध कराता है।

![PowerPoint Protect Presentation मेनू जिसमें Add a Digital Signature हाइलाइट किया गया है](add-digital-signature-in-powerpoint.png)

हस्ताक्षरित प्रस्तुति खुलने के बाद, PowerPoint एक हस्ताक्षर-स्थिति नोटिफिकेशन प्रदर्शित कर सकता है।

![PowerPoint नोटिफिकेशन जिसमें कहा गया है कि प्रस्तुति में वैध हस्ताक्षर मौजूद हैं](digital-signature-status-in-powerpoint.png)

Aspose.Slides हस्ताक्षर को [IPresentation::get_DigitalSignatures](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipresentation/get_digitalsignatures/) के माध्यम से उजागर करता है, जो एक [IDigitalSignatureCollection](https://reference.aspose.com/slides/hi/cpp/aspose.slides/idigitalsignaturecollection/) लौटाता है, जिसके आइटम [IDigitalSignature](https://reference.aspose.com/slides/hi/cpp/aspose.slides/idigitalsignature/) को लागू करते हैं। एक प्रस्तुति में कई हस्ताक्षर हो सकते हैं।

## **PFX प्रमाणपत्र और पासवर्ड को समझें**

एक PFX फ़ाइल, जिसे PKCS#12 फ़ाइल भी कहा जाता है और आमतौर पर `.pfx` या `.p12` एक्सटेंशन दिया जाता है, एक X.509 प्रमाणपत्र, उसकी निजी कुंजी और प्रमाणपत्र चेन को रख सकती है। निजी कुंजी वह है जो धारक को हस्ताक्षर बनाने की अनुमति देती है। एक प्रमाणपत्र जिसके पास पहुंच योग्य निजी कुंजी नहीं है, प्रस्तुति पर हस्ताक्षर करने के लिए उपयोग नहीं किया जा सकता।

PFX पासवर्ड प्रमाणपत्र पैकेज और निजी कुंजी को सुरक्षित रखता है। यह प्रस्तुति को खोलने या संपादित करने के लिए पासवर्ड **नहीं** है। PFX फ़ाइलों या उनके पासवर्ड को स्रोत नियंत्रण में कमिट न करें। उत्पादन में, प्रमाणपत्र फ़ाइल तक पहुंच को सीमित रखें और उसका पासवर्ड एक सीक्रेट स्टोर या किसी अन्य सुरक्षित कॉन्फ़िगरेशन स्रोत से प्राप्त करें। नीचे के उदाहरण केवल कोड में पासवर्ड एम्बेड करने से बचने के लिए पर्यावरण चर का उपयोग करते हैं।

## **प्रस्तुति में डिजिटल हस्ताक्षर जोड़ें**

वास्तविक प्रस्तुति कार्यप्रवाह पर हस्ताक्षर करने के लिए, मौजूदा PPTX फ़ाइल लोड करें, एक PFX प्रमाणपत्र और उसका पासवर्ड से एक [DigitalSignature](https://reference.aspose.com/slides/hi/cpp/aspose.slides/digitalsignature/) बनाएं, हस्ताक्षर को प्रस्तुति के संग्रह में जोड़ें, और PPTX फ़ाइल में सहेजें।

```cpp
auto certificatePassword = Environment::GetEnvironmentVariable(u"PFX_PASSWORD");
if (certificatePassword.IsNullOrEmpty())
{
    throw InvalidOperationException(u"Set the PFX_PASSWORD environment variable.");
}

auto presentation = MakeObject<Presentation>(u"InputPresentation.pptx");

auto signature = MakeObject<DigitalSignature>(u"signing-certificate.pfx", certificatePassword);
signature->set_Comments(u"Approved for release.");

presentation->get_DigitalSignatures()->Add(signature);
presentation->Save(u"InputPresentation-signed.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

परिणाम को नई फ़ाइल नाम से सहेजने से अनहस्ताक्षरित स्रोत फ़ाइल संरक्षित रहती है। [IDigitalSignature::set_Comments](https://reference.aspose.com/slides/hi/cpp/aspose.slides/idigitalsignature/set_comments/) मान हस्ताक्षर के उद्देश्य का वर्णन करता है; यह कोई सुरक्षा नियंत्रण नहीं है।

## **डिजिटल हस्ताक्षरों की वैधता जांचें**

जब आप एक हस्ताक्षरित PPTX फ़ाइल लोड करते हैं, तो [IPresentation::get_DigitalSignatures](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipresentation/get_digitalsignatures/) द्वारा लौटाए गए प्रत्येक आइटम की जांच करें। [IDigitalSignature::get_IsValid](https://reference.aspose.com/slides/hi/cpp/aspose.slides/idigitalsignature/get_isvalid/) मेथड बताता है कि एम्बेडेड हस्ताक्षर वर्तमान प्रस्तुति सामग्री के लिए वैध है या नहीं।

```cpp
auto presentation = MakeObject<Presentation>(u"InputPresentation-signed.pptx");

auto signatureCount = presentation->get_DigitalSignatures()->get_Count();

if (signatureCount == 0)
{
    Console::WriteLine(u"The presentation does not contain digital signatures.");
}
else
{
    bool allSignaturesAreValid = true;

    for (int signatureIndex = 0; signatureIndex < signatureCount; ++signatureIndex)
    {
        auto signature = presentation->get_DigitalSignature(signatureIndex);
        auto signatureIsValid = signature->get_IsValid();
        auto signatureStatus = signatureIsValid ? u"VALID" : u"INVALID";
        auto signerName = signature->get_Certificate()->get_SubjectName()->get_Name();
        auto signingTime = signature->get_SignTime().ToString(u"yyyy-MM-dd HH:mm:ss");

        Console::WriteLine(u"{0}, {1} -- {2}", signerName, signingTime, signatureStatus);

        allSignaturesAreValid = allSignaturesAreValid && signatureIsValid;
    }

    if (allSignaturesAreValid)
    {
        Console::WriteLine(u"All embedded signatures are valid for the current presentation.");
    }
    else
    {
        Console::WriteLine(u"At least one embedded signature is invalid.");
    }
}

presentation->Dispose();
```

एक अमान्य परिणाम आमतौर पर इसका मतलब है कि हस्ताक्षरित प्रस्तुति सामग्री या हस्ताक्षर डेटा हस्ताक्षर के बाद बदल गया, या फ़ाइल क्षतिग्रस्त है। सभी हस्ताक्षर हटाने से प्रस्तुति अनहस्ताक्षरित बन जाती है, इसलिए केवल आइटम की वैधता जांचना पर्याप्त नहीं है: एक सुरक्षा‑संवेदनशील कार्यप्रवाह को अपेक्षित हस्ताक्षरों की संख्या और अपेक्षित हस्ताक्षरकर्ता पहचानियों की भी पुष्टि करनी चाहिए।

इस वैधता परिणाम को पूर्ण प्रमाणपत्र‑विश्वास निर्णय के रूप में नहीं माना जाना चाहिए। आपके सुरक्षा नीति के आधार पर, आपका अनुप्रयोग X.509 प्रमाणपत्र श्रृंखला निर्मित करने और वैधता जाँचने, प्रमाणपत्र की वैधता तिथियां और रिवोक्शन स्थिति को जांचने, अपेक्षित विषय या थंबप्रिंट की पुष्टि करने, कुंजी उपयोग को सत्यापित करने, और विश्वसनीय टाइमस्टैम्प का मूल्यांकन करने की भी आवश्यकता रख सकता है। [IDigitalSignature::get_SignTime](https://reference.aspose.com/slides/hi/cpp/aspose.slides/idigitalsignature/get_signtime/) मान स्वयं विश्वसनीय टाइमस्टैम्प प्राधिकरण से प्रमाण नहीं है।

## **डिजिटल हस्ताक्षर हटाएँ**

हस्ताक्षर हटाने से प्रस्तुति की सुरक्षा स्थिति बदल जाती है। निम्नलिखित उदाहरण एक हस्ताक्षरित PPTX फ़ाइल लोड करता है, सभी हस्ताक्षर को [IDigitalSignatureCollection::Clear](https://reference.aspose.com/slides/hi/cpp/aspose.slides/idigitalsignaturecollection/clear/) से हटाता है, और एक अनहस्ताक्षरित कॉपी सहेजता है।

```cpp
auto presentation = MakeObject<Presentation>(u"InputPresentation-signed.pptx");

presentation->get_DigitalSignatures()->Clear();
presentation->Save(u"InputPresentation-unsigned.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

केवल एक हस्ताक्षर हटाने के लिए, उसके शून्य‑आधारित इंडेक्स के साथ [IDigitalSignatureCollection::RemoveAt](https://reference.aspose.com/slides/hi/cpp/aspose.slides/idigitalsignaturecollection/removeat/) को कॉल करें। तब तक नई फ़ाइल में सहेजें जब तक कि हस्ताक्षरित मूल को ओवरराइट करना आपके कार्यप्रवाह का स्पष्ट हिस्सा न हो।

## **संपादन और स्वरूप विचार**

- एक हस्ताक्षर प्रस्तुति को केवल‑पढ़ने योग्य नहीं बनाता। उपयोगकर्ता और अनुप्रयोग फ़ाइल को अभी भी संपादित कर सकते हैं, लेकिन हस्ताक्षरित सामग्री में परिवर्तन आमतौर पर मौजूदा हस्ताक्षर को अमान्य कर देता है।
- हस्ताक्षर करने से पहले सभी इच्छित संपादनों को पूरा करें। यदि प्रस्तुति को बदलना आवश्यक है, तो संशोधित प्रस्तुति को सहेजें और उस संशोधन पर फिर से हस्ताक्षर करें।
- अंतिम आउटपुट को PPTX स्वरूप में रखें। हस्ताक्षरित प्रस्तुति को किसी अन्य स्वरूप में परिवर्तित करने से मूल PPTX हस्ताक्षर वैध हस्ताक्षर के रूप में परिवर्तित फ़ाइल में नहीं रहता।
- प्रमाणपत्र की निजी कुंजी को संवेदनशील मानें। जो कोई भी निजी कुंजी और उसका पासवर्ड प्राप्त कर लेता है, वह ऐसा हस्ताक्षर बना सकता है जो उस प्रमाणपत्र धारक से आया हुआ दिखे।
- जब आपका दस्तावेज़‑रिटेंशन नीति इसे आवश्यक करे, तो अनहस्ताक्षरित स्रोत या कोई अन्य नियंत्रित प्रतिलिपि रखें।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या एक डिजिटल हस्ताक्षर प्रस्तुति को एन्क्रिप्ट करता है?**

नहीं। एक डिजिटल हस्ताक्षर मूल और अखंडता का प्रमाण देता है, लेकिन प्रस्तुति सामग्री पढ़ने योग्य रहती है जब तक कि अलग से एन्क्रिप्शन लागू न किया गया हो। जब सामग्री की पहुंच प्रतिबंधित करनी हो, तो [password protection](/cpp/password-protected-presentation/) का उपयोग करें।

**क्या PFX पासवर्ड प्रस्तुति पासवर्ड के समान है?**

नहीं। PFX पासवर्ड प्रमाणपत्र पैकेज में संग्रहीत निजी कुंजी को अनलॉक करता है। यह PPTX फ़ाइल को खोलने या संपादित करने को नियंत्रित नहीं करता।

**क्या मैं स्वयं‑हस्ताक्षरित प्रमाणपत्र उपयोग कर सकता हूँ?**

तकनीकी रूप से, यदि स्वयं‑हस्ताक्षरित प्रमाणपत्र में पहुँच योग्य निजी कुंजी शामिल है, तो इसे उपयोग किया जा सकता है। प्राप्तकर्ता स्वचालित रूप से इसे भरोसा नहीं करेंगे, जब तक कि वह प्रमाणपत्र उनके विश्वसनीय वातावरण में स्पष्ट रूप से न जोड़ा गया हो। सार्वजनिक या क्रॉस‑ऑर्गनाइजेशन कार्यप्रवाह सामान्यतः भरोसेमंद CA द्वारा जारी प्रमाणपत्र का उपयोग करते हैं।

**हस्ताक्षर को अमान्य क्या बनाता है?**

हस्ताक्षरित प्रस्तुति सामग्री या हस्ताक्षर डेटा को हस्ताक्षर के बाद बदलना हस्ताक्षर को अमान्य कर सकता है। फ़ाइल क्षति भी सत्यापन को विफल कर सकती है। यदि सभी हस्ताक्षर हटाए जाएँ, तो प्रस्तुति अनहस्ताक्षरित होगी, न कि किसी अमान्य हस्ताक्षर वाली फ़ाइल।

**क्या एक वैध हस्ताक्षर का मतलब है कि मुझे हस्ताक्षरकर्ता पर भरोसा करना चाहिए?**

केवल स्वयं से नहीं। हस्ताक्षर की अखंडता और हस्ताक्षरकर्ता का भरोसा अलग निर्णय हैं। उत्पादन वैधता नीति को प्रमाणपत्र श्रृंखला, वैधता अवधि, रिवोक्शन स्थिति, अपेक्षित पहचान, कुंजी उपयोग, और किसी भी विश्वसनीय टाइमस्टैम्प आवश्यकता की भी जाँच करनी चाहिए।

**प्रमाणपत्र समाप्त होने पर क्या होता है?**

प्रमाणपत्र समाप्त होने से प्रस्तुति बाइट्स नहीं बदलते, लेकिन यह प्रमाणपत्र‑विश्वास मूल्यांकन को प्रभावित करता है। यह कि हस्ताक्षर स्वीकार्य रहेगा या नहीं, आपका नीति और यह कि क्या कोई वैध विश्वसनीय टाइमस्टैम्प सिद्ध करता है कि हस्ताक्षर प्रमाणपत्र के वैध रहने के दौरान हुआ था, पर निर्भर करता है। केवल दर्शाए गए हस्ताक्षर समय पर भरोसा न करें।

**क्या एक हस्ताक्षरित प्रस्तुति अभी भी संपादित की जा सकती है?**

हां। हस्ताक्षर फ़ाइल को लॉक नहीं करता। हस्ताक्षरित सामग्री में परिवर्तन आमतौर पर मौजूदा हस्ताक्षर को अमान्य कर देता है, इसलिए पहले प्रस्तुति समाप्त करें और फिर अंतिम संशोधन पर हस्ताक्षर करें।

**क्या एक प्रस्तुति में एक से अधिक हस्ताक्षर हो सकते हैं?**

हां। प्रत्येक हस्ताक्षर को [IPresentation::get_DigitalSignatures](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipresentation/get_digitalsignatures/) द्वारा लौटाए गए संग्रह में जोड़ें, फिर सहेजें। सत्यापन के दौरान, प्रत्येक हस्ताक्षर की जांच करें और सुनिश्चित करें कि सभी आवश्यक हस्ताक्षरकर्ता उपस्थित हैं।

**कौन‑से प्रस्तुति स्वरूप इन कार्यों का समर्थन करते हैं?**

Aspose.Slides यहाँ वर्णित डिजिटल‑हस्ताक्षर कार्यों को केवल PPTX के लिए समर्थन देता है। PPT और OpenDocument प्रस्तुति स्वरूप इस API कार्यप्रवाह द्वारा समर्थित नहीं हैं।

**क्या मैं एक हस्ताक्षर को स्लाइड्स को प्रभावित किए बिना हटा सकता हूँ?**

हां। आप एक हस्ताक्षर हटा सकते हैं या पूरी संग्रह को साफ़ कर सकते हैं और फिर प्रस्तुति सहेज सकते हैं। स्लाइड सामग्री उपलब्ध रहती है, लेकिन सहेजी गई फ़ाइल में हटाए गए हस्ताक्षर का प्रमाण नहीं रहता।