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
- PowerPoint
- OpenDocument
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android के साथ PowerPoint और OpenDocument फ़ाइलों को डिजिटल रूप से साइन करना सीखें। स्पष्ट Java कोड उदाहरणों के साथ सेकंडों में अपनी स्लाइड्स को सुरक्षित बनाएं।"
---
## **परिचय**

**डिजिटल प्रमाणपत्र** का उपयोग पासवर्ड‑सुरक्षित पॉवरपॉइंट प्रस्तुति बनाने के लिए किया जाता है, जिसे किसी विशेष संगठन या व्यक्ति द्वारा निर्मित के रूप में चिह्नित किया जाता है। डिजिटल प्रमाणपत्र को अधिकृत संगठन—एक प्रमाणपत्र प्राधिकरण—से संपर्क करके प्राप्त किया जा सकता है। सिस्टम में डिजिटल प्रमाणपत्र स्थापित करने के बाद, इसे फ़ाइल → जानकारी → प्रस्तुति की सुरक्षा के माध्यम से प्रस्तुति में डिजिटल हस्ताक्षर जोड़ने के लिए उपयोग किया जा सकता है:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

प्रस्तुति में एक से अधिक डिजिटल हस्ताक्षर हो सकते हैं। डिजिटल हस्ताक्षर को प्रस्तुति में जोड़ने के बाद, पॉवरपॉइंट में एक विशेष संदेश दिखाई देगा:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

प्रस्तुति को साइन करने या प्रस्तुति हस्ताक्षरों की प्रामाणिकता जांचने के लिए, **Aspose.Slides API** [**IDigitalSignature**](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IDigitalSignature) इंटरफ़ेस, [**IDigitalSignatureCollection**](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IDigitalSignatureCollection) इंटरफ़ेस और [**IPresentation.getDigitalSignatures**](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IPresentation#getDigitalSignatures--) विधि प्रदान करता है। वर्तमान में, डिजिटल हस्ताक्षर केवल PPTX प्रारूप के लिए समर्थित हैं।

## **PFX प्रमाणपत्र से डिजिटल हस्ताक्षर जोड़ें**

नीचे दिया गया कोड उदाहरण दर्शाता है कि कैसे PFX प्रमाणपत्र से डिजिटल हस्ताक्षर जोड़ा जाए:

1. PFX फ़ाइल खोलें और PFX पासवर्ड को [**DigitalSignature**](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/DigitalSignature) ऑब्जेक्ट में पास करें।
2. बनाए गए हस्ताक्षर को प्रस्तुति ऑब्जेक्ट में जोड़ें।

```java
// प्रस्तुति फ़ाइल खोल रहा है
Presentation pres = new Presentation();
try {
    // PFX फ़ाइल और PFX पासवर्ड के साथ DigitalSignature ऑब्जेक्ट बनाएं 
    DigitalSignature signature = new DigitalSignature("testsignature1.pfx", "testpass1");

    // नई डिजिटल हस्ताक्षर टिप्पणी
    signature.setComments("Aspose.Slides digital signing test.");

    // प्रस्तुति में डिजिटल हस्ताक्षर जोड़ें
    pres.getDigitalSignatures().add(signature);

    // प्रस्तुति सहेजें
    pres.save("SomePresentationSigned.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

अब यह जांचना संभव है कि प्रस्तुति डिजिटल रूप से हस्ताक्षरित थी और उसमें कोई संशोधन नहीं किया गया है:

```java
// प्रस्तुति खोलें
Presentation pres = new Presentation("SomePresentationSigned.pptx");
try {
    if (pres.getDigitalSignatures().size() > 0)
    {
        boolean allSignaturesAreValid = true;

        System.out.println("Signatures used to sign the presentation: ");

        // सभी डिजिटल हस्ताक्षर वैध हैं या नहीं जांचें
        for (IDigitalSignature signature : pres.getDigitalSignatures())
        {
            System.out.println(signature.getComments() + ", "
                    + signature.getSignTime().toString() + " -- " + (signature.isValid() ? "VALID" : "INVALID"));
            allSignaturesAreValid &= signature.isValid();
        }

        if (allSignaturesAreValid)
            System.out.println("Presentation is genuine, all signatures are valid.");
        else
            System.out.println("Presentation has been modified since signing.");
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं फ़ाइल से मौजूदा हस्ताक्षर हटाकर सकता हूँ?**

हां। डिजिटल हस्ताक्षर संग्रह [व्यक्तिगत आइटम को हटाने](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/digitalsignaturecollection/#removeAt-int-) और इसे पूरी तरह से [साफ़ करने](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/digitalsignaturecollection/#clear--) का समर्थन करता है; फ़ाइल को सहेजने के बाद, प्रस्तुति में कोई हस्ताक्षर नहीं रहेगा।

**हस्ताक्षर के बाद फ़ाइल 'पढ़ने-के-लिए-केवल' बन जाती है क्या?**

नहीं। एक हस्ताक्षर अखंडता और लेखकत्व को बनाए रखता है लेकिन संपादन को रोकता नहीं है। संपादन को प्रतिबंधित करने के लिए, इसे ["पढ़ने-के-लिए-केवल" या पासवर्ड](/slides/hi/androidjava/password-protected-presentation/) के साथ मिलाएँ।

**क्या विभिन्न संस्करणों के PowerPoint में हस्ताक्षर सही ढंग से प्रदर्शित होगा?**

हस्ताक्षर OOXML (PPTX) कंटेनर के लिए बनाया गया है। आधुनिक PowerPoint संस्करण जो OOXML हस्ताक्षरों को समर्थन देते हैं, ऐसे हस्ताक्षरों की स्थिति को सही ढंग से प्रदर्शित करते हैं।