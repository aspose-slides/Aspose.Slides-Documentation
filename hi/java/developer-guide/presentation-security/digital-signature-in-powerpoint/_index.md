---
title: Java में प्रस्तुतियों में डिजिटल हस्ताक्षर जोड़ें
linktitle: डिजिटल हस्ताक्षर
type: docs
weight: 10
url: /hi/java/digital-signature-in-powerpoint/
keywords:
- डिजिटल हस्ताक्षर
- डिजिटल प्रमाणपत्र
- प्रमाणपत्र प्राधिकारी
- PFX प्रमाणपत्र
- PowerPoint
- OpenDocument
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java के साथ PowerPoint और OpenDocument फ़ाइलों को डिजिटल रूप से साइन करने का तरीका सीखें। स्पष्ट कोड उदाहरणों के साथ कुछ ही सेकंड में अपनी स्लाइड्स को सुरक्षित करें।"
---
## **परिचय**

**डिजिटल प्रमाणपत्र** का उपयोग पासवर्ड‑सुरक्षित PowerPoint प्रस्तुति बनाने के लिए किया जाता है, जिसे किसी विशेष संगठन या व्यक्ति द्वारा निर्मित के रूप में चिह्नित किया गया हो। डिजिटल प्रमाणपत्र को किसी अधिकृत संगठन‑प्रमाणपत्र प्राधिकरण से संपर्क करके प्राप्त किया जा सकता है। सिस्टम में डिजिटल प्रमाणपत्र स्थापित करने के बाद, इसका उपयोग फ़ाइल -> जानकारी -> Protect Presentation के माध्यम से प्रस्तुति में डिजिटल हस्ताक्षर जोड़ने के लिए किया जा सकता है:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

प्रस्तुति में एक से अधिक डिजिटल हस्ताक्षर हो सकते हैं। डिजिटल हस्ताक्षर को प्रस्तुति में जोड़ने के बाद, PowerPoint में एक विशेष संदेश प्रदर्शित होगा:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

प्रस्तुति पर हस्ताक्षर करने या प्रस्तुति हस्ताक्षरों की प्रामाणिकता जांचने के लिए, **Aspose.Slides API** [**IDigitalSignature**](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IDigitalSignature) इंटरफ़ेस, [**IDigitalSignatureCollection**](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IDigitalSignatureCollection) इंटरफ़ेस और [**IPresentation.getDigitalSignatures**](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IPresentation#getDigitalSignatures--) मेथड प्रदान करता है। वर्तमान में, डिजिटल हस्ताक्षर केवल PPTX फ़ॉर्मेट के लिए समर्थित हैं।
## **PFX प्रमाणपत्र से डिजिटल हस्ताक्षर जोड़ें**
नीचे दिया गया कोड नमूना दिखाता है कि PFX प्रमाणपत्र से डिजिटल हस्ताक्षर कैसे जोड़ें:

1. PFX फ़ाइल खोलें और PFX पासवर्ड को [**DigitalSignature**](https://reference.aspose.com/slides/hi/java/com.aspose.slides/DigitalSignature) ऑब्जेक्ट में पास करें।
1. बनाए गए हस्ताक्षर को प्रस्तुति ऑब्जेक्ट में जोड़ें।

```java
// प्रस्तुति फ़ाइल खोलना
Presentation pres = new Presentation();
try {
    // PFX फ़ाइल और PFX पासवर्ड के साथ DigitalSignature ऑब्जेक्ट बनाएं 
    DigitalSignature signature = new DigitalSignature("testsignature1.pfx", "testpass1");

    // नया डिजिटल हस्ताक्षर टिप्पणी करें
    signature.setComments("Aspose.Slides digital signing test.");

    // प्रस्तुति में डिजिटल हस्ताक्षर जोड़ें
    pres.getDigitalSignatures().add(signature);

    // प्रस्तुति सहेजें
    pres.save("SomePresentationSigned.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

अब यह जाँचना संभव है कि प्रस्तुति डिजिटल रूप से हस्ताक्षरित है और उसमें कोई परिवर्तन नहीं किया गया है:

```java
// प्रस्तुति खोलें
Presentation pres = new Presentation("SomePresentationSigned.pptx");
try {
    if (pres.getDigitalSignatures().size() > 0)
    {
        boolean allSignaturesAreValid = true;

        System.out.println("Signatures used to sign the presentation: ");

        // सभी डिजिटल हस्ताक्षर मान्य हैं या नहीं जांचें
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

**क्या मैं फ़ाइल से मौजूदा हस्ताक्षर हटा सकता हूँ?**

हाँ। डिजिटल हस्ताक्षर संग्रह [व्यक्तिगत आइटम हटाने](https://reference.aspose.com/slides/hi/java/com.aspose.slides/digitalsignaturecollection/#removeAt-int-) और इसे पूरी तरह से [साफ करने](https://reference.aspose.com/slides/hi/java/com.aspose.slides/digitalsignaturecollection/#clear--) का समर्थन करता है; फ़ाइल सहेजने के बाद, प्रस्तुति में कोई हस्ताक्षर नहीं रहेगा।

**क्या साइन करने के बाद फ़ाइल "रीड-ओनली" बन जाती है?**

नहीं। एक हस्ताक्षर अखंडता और लेखन अधिकार को बनाए रखता है लेकिन संपादन को रोकता नहीं है। संपादन को प्रतिबंधित करने के लिए, इसे ["Read-only" or a password](/slides/hi/java/password-protected-presentation/) के साथ संयोजित करें।

**क्या विभिन्न PowerPoint संस्करणों में हस्ताक्षर सही ढंग से प्रदर्शित होगा?**

हस्ताक्षर OOXML (PPTX) कंटेनर के लिए बनाया गया है। OOXML हस्ताक्षरों का समर्थन करने वाले आधुनिक PowerPoint संस्करण ऐसे हस्ताक्षरों की स्थिति को सही रूप से प्रदर्शित करते हैं।