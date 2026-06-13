---
title: जावास्क्रिप्ट में प्रस्तुतियों में डिजिटल हस्ताक्षर जोड़ें
linktitle: डिजिटल हस्ताक्षर
type: docs
weight: 10
url: /hi/nodejs-java/digital-signature-in-powerpoint/
keywords:
- डिजिटल हस्ताक्षर
- डिजिटल प्रमाणपत्र
- प्रमाणपत्र प्राधिकरण
- PFX प्रमाणपत्र
- पॉवरपॉइंट
- ओपनडॉक्यूमेंट
- प्रस्तुति
- Node.js
- जावास्क्रिप्ट
- Aspose.Slides
description: "जावास्क्रिप्ट के माध्यम से Node.js के लिए Aspose.Slides का उपयोग करके PowerPoint और OpenDocument फ़ाइलों को डिजिटल रूप से कैसे साइन करें सीखें। स्पष्ट कोड उदाहरणों के साथ सेकंडों में अपनी स्लाइड्स को सुरक्षित बनाएं।"
---
## **परिचय**

**डिजिटल प्रमाणपत्र** का उपयोग पासवर्ड संरक्षित पावरपॉइंट प्रस्तुति बनाने के लिए किया जाता है, जिसे किसी विशेष संगठन या व्यक्ति द्वारा बनाया गया चिह्नित किया जाता है। डिजिटल प्रमाणपत्र को अधिकृत संगठन - प्रमाणपत्र प्राधिकरण से संपर्क करके प्राप्त किया जा सकता है। सिस्टम में डिजिटल प्रमाणपत्र स्थापित करने के बाद, इसे File -> Info -> Protect Presentation के माध्यम से प्रस्तुति में डिजिटल हस्ताक्षर जोड़ने के लिए उपयोग किया जा सकता है:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

प्रस्तुति में एक से अधिक डिजिटल हस्ताक्षर हो सकते हैं। जब डिजिटल हस्ताक्षर प्रस्तुति में जोड़ा जाता है, तो पावरपॉइंट में एक विशेष संदेश प्रदर्शित होगा:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

प्रस्तुति पर हस्ताक्षर करने या प्रस्तुति हस्ताक्षरों की प्रामाणिकता जांचने के लिए, **Aspose.Slides API** [**DigitalSignature**](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/DigitalSignature) क्लास, [**DigitalSignatureCollection**](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/DigitalSignatureCollection) क्लास और [**Presentation.getDigitalSignatures**](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation#getDigitalSignatures--) मेथड प्रदान करता है। वर्तमान में, डिजिटल हस्ताक्षर केवल PPTX फ़ॉर्मेट के लिए समर्थित हैं।

## **PFX प्रमाणपत्र से डिजिटल हस्ताक्षर जोड़ें**

नीचे दिया गया कोड उदाहरण दिखाता है कि PFX प्रमाणपत्र से डिजिटल हस्ताक्षर कैसे जोड़ा जाए:

1. PFX फ़ाइल खोलें और PFX पासवर्ड को [**DigitalSignature**](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/DigitalSignature) ऑब्जेक्ट में पास करें।
1. निर्मित हस्ताक्षर को प्रस्तुति ऑब्जेक्ट में जोड़ें।

```javascript
// प्रेजेंटेशन फ़ाइल खोल रहा है
var pres = new aspose.slides.Presentation();
try {
    // PFX फ़ाइल और PFX पासवर्ड के साथ DigitalSignature ऑब्जेक्ट बनाएं
    var signature = new aspose.slides.DigitalSignature("testsignature1.pfx", "testpass1");
    // नए डिजिटल हस्ताक्षर के लिए टिप्पणी सेट करें
    signature.setComments("Aspose.Slides digital signing test.");
    // प्रेजेंटेशन में डिजिटल हस्ताक्षर जोड़ें
    pres.getDigitalSignatures().add(signature);
    // प्रेजेंटेशन सहेजें
    pres.save("SomePresentationSigned.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

अब यह जाँचना संभव है कि प्रस्तुति डिजिटल रूप से हस्ताक्षरित है और संशोधित नहीं हुई है:

```javascript
// प्रस्तुति खोलें
var pres = new aspose.slides.Presentation("SomePresentationSigned.pptx");
try {
    if (pres.getDigitalSignatures().size() > 0) {
        var allSignaturesAreValid = true;
        console.log("Signatures used to sign the presentation: ");
        // सभी डिजिटल हस्ताक्षर वैध हैं या नहीं जांचें
        for (let i = 0; i < pres.getDigitalSignatures().size(); i++) {
        let signature = pres.getDigitalSignatures().get_Item(i);
            console.log((((signature.getComments() + ", ") + signature.getSignTime().toString()) + " -- ") + (signature.isValid() ? "VALID" : "INVALID"));
            allSignaturesAreValid &= signature.isValid();
        }
        if (allSignaturesAreValid) {
            console.log("Presentation is genuine, all signatures are valid.");
        } else {
            console.log("Presentation has been modified since signing.");
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं फ़ाइल से मौजूदा हस्ताक्षर हटा सकता हूँ?**

Yes. The digital signatures collection supports [व्यक्तिगत आइटम हटाना](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/digitalsignaturecollection/removeat/) और [पूरी तरह से साफ़ करना](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/digitalsignaturecollection/clear/); after you save the file, the presentation will have no signatures.

**फ़ाइल साइन करने के बाद "रीड-ऑनली" हो जाती है क्या?**

No. A signature preserves integrity and authorship but does not block edits. To restrict editing, combine it with ["Read-only" or a password](/slides/hi/nodejs-java/password-protected-presentation/).

**क्या विभिन्न PowerPoint संस्करणों में हस्ताक्षर सही रूप से दिखेगा?**

The signature is created for the OOXML (PPTX) container. Modern versions of PowerPoint that support OOXML signatures display the status of such signatures correctly.