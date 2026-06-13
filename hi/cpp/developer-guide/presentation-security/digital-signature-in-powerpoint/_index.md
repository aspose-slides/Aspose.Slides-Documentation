---
title: C++ में प्रस्तुतियों पर डिजिटल हस्ताक्षर जोड़ें
linktitle: डिजिटल हस्ताक्षर
type: docs
weight: 10
url: /hi/cpp/digital-signature-in-powerpoint/
keywords:
- डिजिटल हस्ताक्षर
- डिजिटल प्रमाणपत्र
- प्रमाणपत्र प्राधिकारी
- PFX प्रमाणपत्र
- PowerPoint
- OpenDocument
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ के साथ PowerPoint और OpenDocument फ़ाइलों को डिजिटल रूप से साइन करने का तरीका सीखें। स्पष्ट कोड उदाहरणों के साथ कुछ ही सेकंड में अपनी स्लाइड्स सुरक्षित करें।"
---
## **परिचय**

**डिजिटल प्रमाणपत्र** का उपयोग पासवर्ड‑सुरक्षित पावरपॉइंट प्रस्तुति बनाने के लिए किया जाता है, जिसे किसी विशेष संगठन या व्यक्ति द्वारा निर्मित चिह्नित किया जाता है। डिजिटल प्रमाणपत्र **एक अधिकृत संगठन — प्रमाणपत्र प्राधिकारी** से संपर्क करके प्राप्त किया जा सकता है। सिस्टम में डिजिटल प्रमाणपत्र स्थापित करने के बाद, इसे फ़ाइल → सूचना → प्रस्तुति की सुरक्षा के माध्यम से प्रस्तुति में डिजिटल हस्ताक्षर जोड़ने के लिए इस्तेमाल किया जा सकता है:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

प्रस्तुति में एक से अधिक डिजिटल हस्ताक्षर हो सकते हैं। डिजिटल हस्ताक्षर प्रस्तुति में जोड़ने के बाद, पावरपॉइंट में एक विशेष संदेश प्रदर्शित होगा:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

प्रस्तुति पर हस्ताक्षर करने या हस्ताक्षरों की प्रामाणिकता जाँचने के लिए, **Aspose.Slides API** प्रदान करता है [**IDigitalSignature**](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.i_digital_signature) इंटरफ़ेस, [**IDigitalSignatureCollection**](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.i_digital_signature_collection) इंटरफ़ेस और [**IPresentation.DigitalSignatures**](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.i_presentation#a6f78aff0f8ffa07ff67368fa003722b1) विधि। वर्तमान में, डिजिटल हस्ताक्षर केवल PPTX फ़ॉर्मेट के लिए समर्थित हैं।
## **PFX प्रमाणपत्र से डिजिटल हस्ताक्षर जोड़ना**
नीचे दिया गया कोड नमूना दिखाता है कि PFX प्रमाणपत्र से डिजिटल हस्ताक्षर कैसे जोड़ा जाए:

1. PFX फ़ाइल खोलें और PFX पासवर्ड को [**DigitalSignature**](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.digital_signature) ऑब्जेक्ट में पास करें।
2. बनाए गए हस्ताक्षर को प्रस्तुति ऑब्जेक्ट में जोड़ें।

``` cpp
auto pres = System::MakeObject<Presentation>();

// PFX फ़ाइल और PFX पासवर्ड के साथ DigitalSignature ऑब्जेक्ट बनाएं
auto signature = System::MakeObject<DigitalSignature>(u"testsignature1.pfx", u"testpass1");

// नए डिजिटल हस्ताक्षर पर टिप्पणी करें
signature->set_Comments(u"Aspose.Slides digital signing test.");

// प्रस्तुति में डिजिटल हस्ताक्षर जोड़ें
pres->get_DigitalSignatures()->Add(signature);

// प्रस्तुति सहेजें
pres->Save(u"SomePresentationSigned.pptx", SaveFormat::Pptx);
```

अब यह जांचना संभव है कि प्रस्तुति पर डिजिटल हस्ताक्षर है या नहीं और क्या उसे बदला गया है:

``` cpp
// प्रस्तुति खोलें
auto pres = System::MakeObject<Presentation>(u"SomePresentationSigned.pptx");

if (pres->get_DigitalSignatures()->get_Count() > 0)
{
    bool allSignaturesAreValid = true;

    Console::WriteLine(u"Signatures used to sign the presentation: ");

    // जाँचें कि सभी डिजिटल हस्ताक्षर मान्य हैं या नहीं
    for (auto signature : pres->get_DigitalSignatures())
    {
        Console::WriteLine(signature->get_Certificate()->get_SubjectName()->get_Name() 
            + u", " 
            + signature->get_SignTime().ToString(u"yyyy-MM-dd HH:mm") 
            + u" -- " 
            + (signature->get_IsValid() ? System::String(u"VALID") : System::String(u"INVALID")));
        allSignaturesAreValid &= signature->get_IsValid();
    }

    if (allSignaturesAreValid)
    {
        Console::WriteLine(u"Presentation is genuine, all signatures are valid.");
    }
    else
    {
        Console::WriteLine(u"Presentation has been modified since signing.");
    }
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं फ़ाइल से मौजूदा हस्ताक्षर हटा सकता हूँ?**

हाँ। डिजिटल हस्ताक्षर संग्रह [व्यक्तिगत आइटम हटाने](https://reference.aspose.com/slides/hi/cpp/aspose.slides/digitalsignaturecollection/removeat/) और [पूरी तरह से साफ़ करने](https://reference.aspose.com/slides/hi/cpp/aspose.slides/digitalsignaturecollection/clear/) का समर्थन करता है; फ़ाइल सहेजने के बाद, प्रस्तुति में कोई हस्ताक्षर नहीं रहेगा।

**क्या हस्ताक्षर के बाद फ़ाइल “केवल‑पढ़ने योग्य” बन जाती है?**

नहीं। हस्ताक्षर अखंडता और लेखनता सुरक्षित रखता है, लेकिन संपादन को रोकता नहीं है। संपादन प्रतिबंधित करने के लिए इसे ["केवल‑पढ़ने योग्य" या पासवर्ड](/slides/hi/cpp/password-protected-presentation/) के साथ संयोजित करें।

**क्या विभिन्न PowerPoint संस्करणों में हस्ताक्षर सही ढंग से प्रदर्शित होगा?**

हस्ताक्षर OOXML (PPTX) कंटेनर के लिए निर्मित है। आधुनिक PowerPoint संस्करण जो OOXML हस्ताक्षर поддерживают, ऐसा हस्ताक्षर की स्थिति को सही रूप से दर्शाते हैं।