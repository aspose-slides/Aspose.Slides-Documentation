---
title: "PHP में प्रस्तुतियों में डिजिटल हस्ताक्षर जोड़ें"
linktitle: "डिजिटल हस्ताक्षर"
type: docs
weight: 10
url: /hi/php-java/digital-signature-in-powerpoint/
keywords:
- "डिजिटल हस्ताक्षर"
- "डिजिटल प्रमाणपत्र"
- "प्रमाणपत्र प्राधिकरण"
- "PFX प्रमाणपत्र"
- "PowerPoint"
- "OpenDocument"
- "प्रस्तुति"
- "PHP"
- "Aspose.Slides"
description: "Aspose.Slides for PHP via Java के साथ PowerPoint और OpenDocument फ़ाइलों को डिजिटल रूप से हस्ताक्षर करने का तरीका सीखें। स्पष्ट कोड उदाहरणों के साथ सेकंडों में अपनी स्लाइड्स को सुरक्षित करें।"
---
## **परिचय**

**डिजिटल प्रमाणपत्र** का उपयोग पासवर्ड-रक्षित पावरपॉइंट प्रस्तुति बनाने के लिए किया जाता है, जिसे किसी विशेष संगठन या व्यक्ति द्वारा बनाया गया चिह्नित किया जाता है। डिजिटल प्रमाणपत्र को अधिकृत संगठन - प्रमाणपत्र प्राधिकरण से संपर्क करके प्राप्त किया जा सकता है। सिस्टम में डिजिटल प्रमाणपत्र स्थापित करने के बाद, इसे फ़ाइल -> जानकारी -> Protect Presentation के माध्यम से प्रस्तुति में डिजिटल हस्ताक्षर जोड़ने के लिए उपयोग किया जा सकता है:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

प्रस्तुति में एक से अधिक डिजिटल हस्ताक्षर हो सकते हैं। डिजिटल हस्ताक्षर को प्रस्तुति में जोड़ने के बाद, पावरपॉइंट में एक विशेष संदेश दिखाई देगा:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

प्रस्तुति को हस्ताक्षर करने या प्रस्तुति हस्ताक्षरों की प्रामाणिकता जांचने के लिए, **Aspose.Slides API** प्रदान करता है [**DigitalSignature**](https://reference.aspose.com/slides/hi/php-java/aspose.slides/DigitalSignature) वर्ग, [**DigitalSignatureCollection**](https://reference.aspose.com/slides/hi/php-java/aspose.slides/DigitalSignatureCollection) वर्ग और [**Presentation::getDigitalSignatures**](https://reference.aspose.com/slides/hi/php-java/aspose.slides/Presentation/#getDigitalSignatures) विधि। वर्तमान में, डिजिटल हस्ताक्षर केवल PPTX स्वरूप के लिए समर्थित हैं।

## **PFX प्रमाणपत्र से डिजिटल हस्ताक्षर जोड़ें**

नीचे दिया गया कोड उदाहरण दर्शाता है कि PFX प्रमाणपत्र से डिजिटल हस्ताक्षर कैसे जोड़ें:

1. PFX फ़ाइल खोलें और PFX पासवर्ड को [**DigitalSignature**](https://reference.aspose.com/slides/hi/php-java/aspose.slides/DigitalSignature) ऑब्जेक्ट को पास करें।
1. बनाए गए हस्ताक्षर को प्रस्तुति ऑब्जेक्ट में जोड़ें।

```php
  # प्रेजेंटेशन फ़ाइल खोलना
  $pres = new Presentation();
  try {
    # PFX फ़ाइल और PFX पासवर्ड के साथ DigitalSignature ऑब्जेक्ट बनाएं
    $signature = new DigitalSignature("testsignature1.pfx", "testpass1");
    # नया डिजिटल हस्ताक्षर टिप्पणी
    $signature->setComments("Aspose.Slides digital signing test.");
    # डिजिटल हस्ताक्षर को प्रेजेंटेशन में जोड़ें
    $pres->getDigitalSignatures()->add($signature);
    # प्रेजेंटेशन सहेजें
    $pres->save("SomePresentationSigned.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

अब यह जांचना संभव है कि प्रस्तुति डिजिटल रूप से हस्ताक्षरित है और इसमें कोई परिवर्तन नहीं हुआ है:

```php
  # प्रेजेंटेशन खोलें
  $pres = new Presentation("SomePresentationSigned.pptx");
  try {
    if (java_values($pres->getDigitalSignatures()->size()) > 0) {
      $allSignaturesAreValid = true;
      echo("Signatures used to sign the presentation: ");
      # सभी डिजिटल हस्ताक्षर वैध हैं या नहीं जांचें
      foreach($pres->getDigitalSignatures() as $signature) {
        echo($signature->getComments() . ", " . $signature->getSignTime()->toString() . " -- " . $signature->isValid() ? "VALID" : "INVALID");
        $allSignaturesAreValid &= $signature->isValid();
      }
      if ($allSignaturesAreValid) {
        echo("Presentation is genuine, all signatures are valid.");
      } else {
        echo("Presentation has been modified since signing.");
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं फ़ाइल से मौजूदा हस्ताक्षर हटा सकता हूँ?**

हां। डिजिटल हस्ताक्षर संग्रह [removing individual items](https://reference.aspose.com/slides/hi/php-java/aspose.slides/digitalsignaturecollection/removeat/) और [clearing it entirely](https://reference.aspose.com/slides/hi/php-java/aspose.slides/digitalsignaturecollection/clear/) दोनों का समर्थन करता है; फ़ाइल को सहेजने के बाद, प्रस्तुति में कोई हस्ताक्षर नहीं रहेगा।

**क्या हस्ताक्षर करने के बाद फ़ाइल "केवल-पढ़ने योग्य" बन जाती है?**

नहीं। हस्ताक्षर अखंडता और लेखन अधिकार को बनाए रखता है लेकिन संपादन को रोकता नहीं है। संपादन को प्रतिबंधित करने के लिए, इसे ["Read-only" or a password](/slides/hi/php-java/password-protected-presentation/) के साथ जोड़ें।

**क्या विभिन्न PowerPoint संस्करणों में हस्ताक्षर सही रूप से प्रदर्शित होगा?**

हस्ताक्षर OOXML (PPTX) कंटेनर के लिए बनाया गया है। आधुनिक PowerPoint संस्करण जो OOXML हस्ताक्षरों का समर्थन करते हैं, ऐसे हस्ताक्षरों की स्थिति को सही ढंग से प्रदर्शित करते हैं।