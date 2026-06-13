---
title: .NET में प्रस्तुतियों पर डिजिटल हस्ताक्षर जोड़ें
linktitle: डिजिटल हस्ताक्षर
type: docs
weight: 10
url: /hi/net/digital-signature-in-powerpoint/
keywords:
- डिजिटल हस्ताक्षर
- डिजिटल प्रमाणपत्र
- प्रमाणपत्र प्राधिकारी
- PFX प्रमाणपत्र
- PowerPoint
- OpenDocument
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET का उपयोग करके PowerPoint और OpenDocument फ़ाइलों पर डिजिटल हस्ताक्षर करना सीखें। स्पष्ट कोड उदाहरणों के साथ कुछ ही सेकंड में अपनी स्लाइड्स को सुरक्षित करें।"
---
## **परिचय**

**डिजिटल प्रमाणपत्र** का उपयोग पासवर्ड सुरक्षा वाली PowerPoint प्रस्तुति बनाने के लिए किया जाता है, जिसे किसी विशेष संगठन या व्यक्ति द्वारा बनाया गया चिह्नित किया जाता है। डिजिटल प्रमाणपत्र को किसी अधिकृत संगठन — प्रमाणपत्र प्राधिकारी से संपर्क करके प्राप्त किया जा सकता है। सिस्टम में डिजिटल प्रमाणपत्र स्थापित करने के बाद, इसे फ़ाइल → जानकारी → प्रेज़ेंटेशन को सुरक्षित करें के माध्यम से प्रस्तुति में डिजिटल हस्ताक्षर जोड़ने के लिए उपयोग किया जा सकता है:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

एक प्रस्तुति में एक से अधिक डिजिटल हस्ताक्षर हो सकते हैं। प्रस्तुति में डिजिटल हस्ताक्षर जोड़ने के बाद, PowerPoint में एक विशेष संदेश दिखाई देगा:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

प्रेज़ेंटेशन पर हस्ताक्षर करने या प्रस्तुति हस्ताक्षरों की प्रामाणिकता जांचने के लिए, **Aspose.Slides API** [**IDigitalSignature**](https://reference.aspose.com/slides/hi/net/aspose.slides/idigitalsignature)interface, [**IDigitalSignatureCollection**](https://reference.aspose.com/slides/hi/net/aspose.slides/IDigitalSignatureCollection)interface और [**IPresentation.DigitalSignatures**](https://reference.aspose.com/slides/hi/net/aspose.slides/ipresentation/properties/digitalsignatures) property प्रदान करता है। वर्तमान में, डिजिटल हस्ताक्षर केवल PPTX फ़ॉर्मेट के लिए समर्थित हैं।

## **PFX प्रमाणपत्र से डिजिटल हस्ताक्षर जोड़ना**

नीचे दिया गया कोड नमूना दिखाता है कि कैसे PFX प्रमाणपत्र से डिजिटल हस्ताक्षर जोड़ा जाए:

1. PFX फ़ाइल खोलें और PFX पासवर्ड को [**DigitalSignature**](https://reference.aspose.com/slides/hi/net/aspose.slides/digitalsignature)object को पास करें।
2. निर्मित हस्ताक्षर को प्रस्तुति ऑब्जेक्ट में जोड़ें।

```c#
using (Presentation pres = new Presentation())
{
    // PFX फ़ाइल और PFX पासवर्ड के साथ DigitalSignature ऑब्जेक्ट बनाएं 
    DigitalSignature signature = new DigitalSignature("testsignature1.pfx", @"testpass1");

    // नई डिजिटल हस्ताक्षर की टिप्पणी करें
    signature.Comments = "Aspose.Slides digital signing test.";

    // डिजिटल हस्ताक्षर को प्रस्तुति में जोड़ें
    pres.DigitalSignatures.Add(signature);

    // प्रस्तुति सहेजें
    pres.Save("SomePresentationSigned.pptx", SaveFormat.Pptx);
}
```

अब आप जांच सकते हैं कि प्रस्तुति पर डिजिटल हस्ताक्षर किया गया था और उसे संशोधित नहीं किया गया है:

```c#
// प्रस्तुति खोलें
using (Presentation pres = new Presentation("SomePresentationSigned.pptx"))
{
    if (pres.DigitalSignatures.Count > 0)
    {
        bool allSignaturesAreValid = true;

        Console.WriteLine("Signatures used to sign the presentation: ");

        // जाँचें कि सभी डिजिटल हस्ताक्षर मान्य हैं या नहीं
        foreach (DigitalSignature signature in pres.DigitalSignatures)
        {
            Console.WriteLine(signature.Certificate.SubjectName.Name + ", "
                    + signature.SignTime.ToString("yyyy-MM-dd HH:mm") + " -- " + (signature.IsValid ? "VALID" : "INVALID"));
            allSignaturesAreValid &= signature.IsValid;
        }

        if (allSignaturesAreValid)
            Console.WriteLine("Presentation is genuine, all signatures are valid.");
        else
            Console.WriteLine("Presentation has been modified since signing.");
    }
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं फ़ाइल से मौजूदा हस्ताक्षर हटा सकता हूँ?**

हाँ। डिजिटल हस्ताक्षर संग्रह [व्यक्तिगत आइटम हटाने](https://reference.aspose.com/slides/hi/net/aspose.slides/digitalsignaturecollection/removeat/) और [पूरी तरह से साफ़ करने](https://reference.aspose.com/slides/hi/net/aspose.slides/digitalsignaturecollection/clear/) का समर्थन करता है; फ़ाइल सहेजने के बाद, प्रस्तुति में कोई हस्ताक्षर नहीं रहेगा।

**क्या हस्ताक्षर करने के बाद फ़ाइल "केवल-पढ़ने योग्य" बन जाती है?**

नहीं। हस्ताक्षर अखंडता और लेखन अधिकार को संरक्षित करता है लेकिन संपादन को रोकता नहीं है। संपादन को सीमित करने के लिए, इसे ["केवल पढ़ने योग्य" या पासवर्ड](/slides/hi/net/password-protected-presentation/) के साथ मिलाएँ।

**क्या विभिन्न PowerPoint संस्करणों में हस्ताक्षर सही ढंग से प्रदर्शित होगा?**

हस्ताक्षर OOXML (PPTX) कंटेनर के लिए बनाया गया है। उन आधुनिक PowerPoint संस्करणों में जो OOXML हस्ताक्षरों को समर्थन देते हैं, यह हस्ताक्षरों की स्थिति को सही ढंग से दर्शाता है।