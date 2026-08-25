---
title: C++ में प्रस्तुतियों में डिजिटल हस्ताक्षर जोड़ें
linktitle: डिजिटल हस्ताक्षर
type: docs
weight: 10
url: /hi/cpp/digital-signature-in-powerpoint/
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
- C++
- Aspose.Slides
description: "PFX प्रमाणपत्रों के साथ मौजूदा PPTX प्रस्तुतियों पर हस्ताक्षर कैसे करें और डिजिटल हस्ताक्षरों को सत्यापित या हटाने के लिए C++ के लिए Aspose.Slides का उपयोग कैसे करें, सीखें।"
---
## **अवलोकन**

डिजिटल हस्ताक्षर प्राप्तकर्ता को यह निर्धारित करने में मदद करता है कि किसने प्रस्तुति पर हस्ताक्षर किया और क्या हस्ताक्षरित सामग्री में परिवर्तन हुआ है। यहाँ तीन संबंधित सुरक्षा अवधारणाएँ महत्वपूर्ण हैं:

- **डिजिटल प्रमाणपत्र** एक इलेक्ट्रॉनिक प्रमाण है जो पहचान को सार्वजनिक कुंजी से जोड़ता है। एक विश्वसनीय प्रमाणपत्र प्राधिकरण (CA) प्रमाणपत्र जारी कर सकता है, या किसी संगठन के पास आंतरिक कार्यप्रवाहों के लिए स्व-हस्ताक्षरित प्रमाणपत्र हो सकता है।
- **डिजिटल हस्ताक्षर** प्रस्तुति सामग्री और प्रमाणपत्र धारक की निजी कुंजी से बनाया जाता है। प्रमाणपत्र की सार्वजनिक कुंजी का उपयोग हस्ताक्षर को सत्यापित करने के लिए किया जा सकता है। हस्ताक्षर मूल और अखंडता का प्रमाण देता है; यह प्रस्तुति को एन्क्रिप्ट नहीं करता।
- **पासवर्ड सुरक्षा** नियंत्रित करती है कि उपयोगकर्ता प्रस्तुति को खोल या संशोधित कर सकता है या नहीं। यह डिजिटल साइनिंग से अलग है और इसे [Password-Protected Presentations](/slides/hi/cpp/password-protected-presentation/) में वर्णित किया गया है।

PowerPoint **File > Info > Protect Presentation** के तहत **Add a Digital Signature** कमांड प्रदान करता है।

![PowerPoint Protect Presentation मेनू जिसमें Add a Digital Signature हाइलाइट किया गया है](add-digital-signature-in-powerpoint.png)

हस्ताक्षरित प्रस्तुति खोलने के बाद, PowerPoint हस्ताक्षर-स्थिति अधिसूचना दिखा सकता है।

![PowerPoint अधिसूचना जो बताती है कि प्रस्तुति में वैध हस्ताक्षर मौजूद हैं](digital-signature-status-in-powerpoint.png)

Aspose.Slides हस्ताक्षरों को [IPresentation::get_DigitalSignatures](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipresentation/get_digitalsignatures/) द्वारा उजागर करता है, जो एक [IDigitalSignatureCollection](https://reference.aspose.com/slides/hi/cpp/aspose.slides/idigitalsignaturecollection/) लौटाता है, जिसके आइटम [IDigitalSignature](https://reference.aspose.com/slides/hi/cpp/aspose.slides/idigitalsignature/) को लागू करते हैं। एक प्रस्तुति में कई हस्ताक्षर हो सकते हैं।

## **PFX प्रमाणपत्र और पासवर्ड को समझना**

PFX फ़ाइल, जिसे PKCS#12 फ़ाइल के रूप में भी जाना जाता है और सामान्यतः `.pfx` या `.p12` एक्सटेंशन दिया जाता है, में X.509 प्रमाणपत्र, उसकी निजी कुंजी और प्रमाणपत्र श्रृंखला हो सकती है। निजी कुंजी वही है जो धारक को हस्ताक्षर बनाने की अनुमति देती है। निजी कुंजी तक पहुँच न होने वाला प्रमाणपत्र प्रस्तुति पर हस्ताक्षर करने के लिए उपयोग नहीं किया जा सकता।

PFX पासवर्ड प्रमाणपत्र पैकेज और निजी कुंजी की रक्षा करता है। यह प्रस्तुति खोलने या संपादित करने के लिए पासवर्ड नहीं है। PFX फ़ाइलों या उनके पासवर्ड को स्रोत नियंत्रण में कमिट न करें। उत्पादन में, प्रमाणपत्र फ़ाइल तक पहुँच को सीमित रखें और उसका पासवर्ड किसी गुप्त स्टोर या अन्य सुरक्षित कॉन्फ़िगरेशन स्रोत से प्राप्त करें। नीचे के उदाहरण केवल कोड में पासवर्ड एम्बेड करने से बचने के लिए पर्यावरण वेरिएबल का उपयोग करते हैं।

## **प्रस्तुति में डिजिटल हस्ताक्षर जोड़ना**

वास्तविक प्रस्तुति कार्यप्रवाह को हस्ताक्षरित करने के लिए, मौजूदा PPTX फ़ाइल लोड करें, PFX प्रमाणपत्र और उसके पासवर्ड से एक [DigitalSignature](https://reference.aspose.com/slides/hi/cpp/aspose.slides/digitalsignature/) बनाएं, हस्ताक्षर को प्रस्तुति के संग्रह में जोड़ें, और PPTX फ़ाइल में सहेजें।

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

परिणाम को नए नाम से सहेजने से बिना हस्ताक्षर वाली स्रोत फ़ाइल संरक्षित रहती है। [IDigitalSignature::set_Comments](https://reference.aspose.com/slides/hi/cpp/aspose.slides/idigitalsignature/set_comments/) मान हस्ताक्षर के उद्देश्य का वर्णन करता है; यह सुरक्षा नियंत्रण नहीं है।

## **डिजिटल हस्ताक्षरों को सत्यापित करना**

जब आप एक हस्ताक्षरित PPTX फ़ाइल लोड करते हैं, तो [IPresentation::get_DigitalSignatures](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipresentation/get_digitalsignatures/) द्वारा लौटाए गए प्रत्येक आइटम की जांच करें। [IDigitalSignature::get_IsValid](https://reference.aspose.com/slides/hi/cpp/aspose.slides/idigitalsignature/get_isvalid/) विधि बताती है कि एम्बेडेड हस्ताक्षर वर्तमान प्रस्तुति सामग्री के लिए वैध है या नहीं।

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

एक अवैध परिणाम आमतौर पर दर्शाता है कि हस्ताक्षरित प्रस्तुति सामग्री या हस्ताक्षर डेटा signing के बाद बदल गया है, या फ़ाइल क्षतिग्रस्त है। सभी हस्ताक्षर हटाने से एक बिना हस्ताक्षर वाली प्रस्तुति बनती है, इसलिए केवल आइटम की वैधता जाँचना पर्याप्त नहीं है: एक सुरक्षा-संवेदनशील कार्यप्रवाह को अपेक्षित हस्ताक्षरों की संख्या और अपेक्षित हस्ताक्षरकर्ता पहचान की भी पुष्टि करनी चाहिए।

यह वैधता परिणाम पूर्ण प्रमाणपत्र-विश्वास निर्णय नहीं माना जाना चाहिए। आपके सुरक्षा नीति के आधार पर, आपका अनुप्रयोग X.509 प्रमाणपत्र श्रृंखला बनाना और सत्यापित करना, प्रमाणपत्र की वैधता तिथियों एवं निरस्तीकरण स्थिति की जाँच करना, अपेक्षित सब्जेक्ट या थंबप्रिंट की पुष्टि करना, कुंजी उपयोग की जाँच करना, और विश्वसनीय टाइमस्टैम्प का मूल्यांकन करना भी आवश्यक हो सकता है। [IDigitalSignature::get_SignTime](https://reference.aspose.com/slides/hi/cpp/aspose.slides/idigitalsignature/get_signtime/) मान स्वयं विश्वसनीय टाइमस्टैम्प प्राधिकरण से प्रमाण नहीं है।

## **डिजिटल हस्ताक्षर हटाना**

हस्ताक्षर हटाने से प्रस्तुति की सुरक्षा स्थिति बदल जाती है। निम्न उदाहरण एक हस्ताक्षरित PPTX फ़ाइल लोड करता है, सभी हस्ताक्षर को [IDigitalSignatureCollection::Clear](https://reference.aspose.com/slides/hi/cpp/aspose.slides/idigitalsignaturecollection/clear/) द्वारा हटाता है, और एक बिना हस्ताक्षर की कॉपी सहेजता है।

```cpp
auto presentation = MakeObject<Presentation>(u"InputPresentation-signed.pptx");

presentation->get_DigitalSignatures()->Clear();
presentation->Save(u"InputPresentation-unsigned.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

केवल एक हस्ताक्षर हटाने के लिए, उसके शून्य-आधारित इंडेक्स के साथ [IDigitalSignatureCollection::RemoveAt](https://reference.aspose.com/slides/hi/cpp/aspose.slides/idigitalsignaturecollection/removeat/) को कॉल करें। सहेजते समय नया फ़ाइल नाम उपयोग करें, जब तक कि हस्ताक्षरित मूल को अधिलेखित करना आपका स्पष्ट कार्यप्रवाह न हो।

## **संपादन और फ़ॉर्मेट विचार**

- हस्ताक्षर प्रस्तुति को केवल‑पढ़ने योग्य नहीं बनाता। उपयोगकर्ता और अनुप्रयोग अभी भी फ़ाइल को संपादित कर सकते हैं, लेकिन हस्ताक्षरित सामग्री में परिवर्तन आमतौर पर मौजूदा हस्ताक्षर को अवैध बना देता है।
- हस्ताक्षर करने से पहले सभी इच्छित संपादन पूरा कर लें। यदि प्रस्तुति को बदला जाना है, तो संशोधित प्रस्तुति को सहेजें और उस संशोधन पर फिर से हस्ताक्षर करें।
- अंतिम आउटपुट को PPTX फ़ॉर्मेट में रखें। हस्ताक्षरित प्रस्तुति को किसी अन्य फ़ॉर्मेट में बदलने से मूल PPTX हस्ताक्षर वैध हस्ताक्षर के रूप में नहीं रह जाता।
- प्रमाणपत्र की निजी कुंजी को संवेदनशील मानें। जो कोई भी निजी कुंजी और उसका पासवर्ड प्राप्त करता है, वह उस प्रमाणपत्र धारी की ओर से हस्ताक्षर बना सकता है।
- जब आपके दस्तावेज़‑रखी नीति इसे आवश्यक करती है, तो बिना हस्ताक्षर वाला स्रोत या कोई अन्य नियंत्रित प्रतिलिपि रखें।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या डिजिटल हस्ताक्षर प्रस्तुति को एन्क्रिप्ट करता है?**

नहीं। डिजिटल हस्ताक्षर मूल और अखंडता का प्रमाण देता है, लेकिन प्रस्तुति सामग्री तब तक पढ़ी जा सकती है जब तक अलग एन्क्रिप्शन लागू न किया गया हो। जब सामग्री तक पहुंच प्रतिबंधित होनी चाहिए, तो [password protection](/slides/hi/cpp/password-protected-presentation/) का उपयोग करें।

**क्या PFX पासवर्ड प्रस्तुति पासवर्ड के समान है?**

नहीं। PFX पासवर्ड प्रमाणपत्र पैकेज में संग्रहीत निजी कुंजी को अनलॉक करता है। यह PPTX फ़ाइल को खोलने या संपादित करने को नियंत्रित नहीं करता।

**क्या मैं स्व-हस्ताक्षरित प्रमाणपत्र उपयोग कर सकता हूँ?**

तकनीकी रूप से, यदि इसमें पहुँच योग्य निजी कुंजी शामिल है तो स्व-हस्ताक्षरित प्रमाणपत्र उपयोग किया जा सकता है। हालांकि, प्राप्तकर्ता स्वचालित रूप से इसे भरोसेमंद नहीं मानेंगे, जब तक कि वह प्रमाणपत्र स्पष्ट रूप से उनके भरोसेमंद वातावरण में न जोड़ा गया हो। सार्वजनिक या क्रॉस‑संगठन कार्यप्रवाह सामान्यतः भरोसेमंद CA द्वारा जारी प्रमाणपत्र उपयोग करते हैं।

**हस्ताक्षर को अमान्य क्या बनाता है?**

हस्ताक्षरित प्रस्तुति सामग्री या हस्ताक्षर डेटा को हस्ताक्षर के बाद बदलना हस्ताक्षर को अमान्य बना सकता है। फ़ाइल क्षति भी सत्यापन में विफलता का कारण बन सकती है। यदि सभी हस्ताक्षर हटा दिए जाएँ, तो प्रस्तुति बिना हस्ताक्षर वाली होती है, न कि अमान्य हस्ताक्षर वाली फ़ाइल।

**क्या वैध हस्ताक्षर का अर्थ है कि मुझे हस्ताक्षरकर्ता पर भरोसा करना चाहिए?**

केवल इस आधार पर नहीं। हस्ताक्षर की अखंडता और हस्ताक्षरकर्ता के भरोसे अलग‑अलग निर्णय हैं। उत्पादन सत्यापन नीति को प्रमाणपत्र श्रृंखला, वैधता अवधि, निरस्तीकरण स्थिति, अपेक्षित पहचान, कुंजी उपयोग, और किसी भी भरोसेमंद टाइमस्टैम्प आवश्यकताओं की भी जाँच करनी चाहिए।

**यदि प्रमाणपत्र समाप्त हो जाता है तो क्या होता है?**

प्रमाणपत्र समाप्ति प्रस्तुति बाइट्स को नहीं बदलती, लेकिन प्रमाणपत्र‑विश्वास मूल्यांकन को प्रभावित करती है। क्या हस्ताक्षर स्वीकार्य रहता है, यह आपके नीति और यह कि क्या वैध भरोसेमंद टाइमस्टैम्प यह सिद्ध करता है कि हस्ताक्षर तब हुआ जब प्रमाणपत्र वैध था, पर निर्भर करता है। केवल दर्शाए गए हस्ताक्षर समय पर भरोसा न करें।

**क्या हस्ताक्षरित प्रस्तुति अभी भी संपादित की जा सकती है?**

हां। हस्ताक्षर फ़ाइल को लॉक नहीं करता। हस्ताक्षरित सामग्री को संपादित करने से सामान्यतः मौजूदा हस्ताक्षर अमान्य हो जाता है, इसलिए पहले प्रस्तुति समाप्त करें और अंतिम संस्करण पर हस्ताक्षर करें।

**क्या एक प्रस्तुति में एक से अधिक हस्ताक्षर हो सकते हैं?**

हां। सेव करने से पहले प्रत्येक हस्ताक्षर को [IPresentation::get_DigitalSignatures](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipresentation/get_digitalsignatures/) द्वारा लौटाए गए संग्रह में जोड़ें। सत्यापन के दौरान प्रत्येक हस्ताक्षर की जाँच करें और सुनिश्चित करें कि सभी आवश्यक हस्ताक्षरकर्ता उपस्थित हैं।

**कौन से प्रस्तुति फ़ॉर्मेट इन ऑपरेशनों का समर्थन करते हैं?**

Aspose.Slides यहाँ वर्णित डिजिटल‑हस्ताक्षर ऑपरेशनों को केवल PPTX के लिए समर्थन देता है। PPT और OpenDocument प्रस्तुति फ़ॉर्मेट इस API कार्यप्रवाह द्वारा समर्थित नहीं हैं।

**क्या मैं बिना स्लाइड्स को प्रभावित किए हस्ताक्षर हटा सकता हूँ?**

हां। आप एक हस्ताक्षर हटा सकते हैं या पूरी संग्रह को साफ़ कर सकते हैं और फिर प्रस्तुति सहेज सकते हैं। स्लाइड सामग्री उपलब्ध रहती है, लेकिन सहेजी गई फ़ाइल अब हटाए गए हस्ताक्षर का प्रमाण नहीं रखती।