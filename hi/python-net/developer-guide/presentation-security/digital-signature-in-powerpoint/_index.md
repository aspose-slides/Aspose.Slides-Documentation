---
title: Python के साथ प्रस्तुतियों में डिजिटल हस्ताक्षर जोड़ें
linktitle: डिजिटल हस्ताक्षर
type: docs
weight: 10
url: /hi/python-net/digital-signature-in-powerpoint/
keywords:
- डिजिटल हस्ताक्षर
- डिजिटल प्रमाणपत्र
- प्रमाणपत्र प्राधिकरण
- PFX प्रमाणपत्र
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET के साथ PowerPoint और OpenDocument फाइलों को डिजिटल रूप से साइन करना सीखें। स्पष्ट कोड उदाहरणों के साथ सेकंडों में अपनी स्लाइड्स को सुरक्षित बनाएं।"
---
## **परिचय**

**डिजिटल प्रमाणपत्र** का उपयोग पासवर्ड‑सुरक्षित PowerPoint प्रस्तुति बनाने के लिए किया जाता है, जिसे किसी विशिष्ट संगठन या व्यक्ति द्वारा निर्मित के रूप में चिह्नित किया जाता है। डिजिटल प्रमाणपत्र को अधिकृत संगठन - एक प्रमाणपत्र प्राधिकारी - से संपर्क करके प्राप्त किया जा सकता है। सिस्टम में डिजिटल प्रमाणपत्र स्थापित करने के बाद, इसे फ़ाइल -> जानकारी -> प्रेज़ेंटेशन सुरक्षा के माध्यम से प्रस्तुति में डिजिटल हस्ताक्षर जोड़ने के लिए उपयोग किया जा सकता है:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

प्रस्तुति में एक से अधिक डिजिटल हस्ताक्षर हो सकते हैं। डिजिटल हस्ताक्षर को प्रस्तुति में जोड़ने के बाद, PowerPoint में एक विशेष संदेश प्रदर्शित होगा:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

प्रस्तुति पर हस्ताक्षर करने या प्रस्तुति हस्ताक्षरों की प्रामाणिकता जाँचने के लिए, **Aspose.Slides API** प्रदान करता है [**DigitalSignature**](https://reference.aspose.com/slides/hi/python-net/aspose.slides/digitalsignature/) क्लास, [**DigitalSignatureCollection**](https://reference.aspose.com/slides/hi/python-net/aspose.slides/DigitalSignatureCollection/) क्लास और [**Presentation.digital_signatures**](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/digital_signatures/) प्रॉपर्टी। वर्तमान में, डिजिटल हस्ताक्षर केवल PPTX प्रारूप के लिए समर्थित हैं।

## **PFX प्रमाणपत्र से डिजिटल हस्ताक्षर जोड़ें**

नीचे दिया गया कोड उदाहरण दिखाता है कि PFX प्रमाणपत्र से डिजिटल हस्ताक्षर कैसे जोड़ें:

1. PFX फ़ाइल खोलें और PFX पासवर्ड को [**DigitalSignature**](https://reference.aspose.com/slides/hi/python-net/aspose.slides/digitalsignature/) ऑब्जेक्ट को पास करें।
2. निर्मित हस्ताक्षर को प्रस्तुति ऑब्जेक्ट में जोड़ें।

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    # PFX फ़ाइल और PFX पासवर्ड के साथ DigitalSignature ऑब्जेक्ट बनाएँ
    signature = slides.DigitalSignature(path + "testsignature1.pfx", "testpass1")

    # नए डिजिटल हस्ताक्षर पर टिप्पणी करें
    signature.comments = "Aspose.Slides digital signing test."

    # डिजिटल हस्ताक्षर को प्रस्तुति में जोड़ें
    pres.digital_signatures.add(signature)

    # प्रस्तुति को सहेजें
    pres.save("SomePresentationSigned.pptx", slides.export.SaveFormat.PPTX)
```

अब यह जांचना संभव है कि प्रस्तुति डिजिटल रूप से हस्ताक्षरित है और संशोधित नहीं हुई है:

```py
# प्रस्तुति खोलें
with slides.Presentation("SomePresentationSigned.pptx") as pres:
    if len(pres.digital_signatures) > 0:
        allSignaturesAreValid = True

        print("Signatures used to sign the presentation: ")
        # सभी डिजिटल हस्ताक्षर वैध हैं या नहीं जाँचें
        for signature in pres.digital_signatures :
            print(signature.certificate.subject_name.name + ", "
                    + signature.sign_time.strftime("yyyy-MM-dd HH:mm") + " -- " + "VALID" if signature.is_valid else "INVALID")
            allSignaturesAreValid = allSignaturesAreValid and signature.is_valid
        

        if allSignaturesAreValid:
            print("Presentation is genuine, all signatures are valid.")
        else:
            print("Presentation has been modified since signing.")
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं फ़ाइल से मौजूदा हस्ताक्षर हटा सकता/सकती हूँ?**

हाँ। डिजिटल हस्ताक्षर संग्रह व्यक्तिगत आइटम हटाने और पूरी तरह से साफ़ करने का समर्थन करता है; फ़ाइल सहेजने के बाद, प्रस्तुति में कोई हस्ताक्षर नहीं रहेगा।

**क्या फ़ाइल पर हस्ताक्षर करने के बाद वह "रीड‑ऑनली" बन जाती है?**

नहीं। हस्ताक्षर समग्रता और लेखकत्व को बनाए रखता है लेकिन संपादन को ब्लॉक नहीं करता। संपादन को प्रतिबंधित करने के लिए, इसे ["Read-only" या पासवर्ड](/slides/hi/python-net/password-protected-presentation/) के साथ संयोजित करें।

**क्या विभिन्न PowerPoint संस्करणों में हस्ताक्षर सही ढंग से प्रदर्शित होगा?**

हस्ताक्षर OOXML (PPTX) कंटेनर के लिए बनाया गया है। OOXML हस्ताक्षरों को समर्थन देने वाले आधुनिक PowerPoint संस्करण इन हस्ताक्षरों की स्थिति को सही ढंग से प्रदर्शित करते हैं।