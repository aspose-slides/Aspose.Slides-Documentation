---
title: एंड्रॉइड पर मूल प्रेजेंटेशन स्वरूप निर्धारित करें
linktitle: स्रोत स्वरूप
type: docs
weight: 35
url: /hi/androidjava/detect-presentation-source-format/
keywords:
- स्रोत स्वरूप
- प्रेजेंटेशन स्वरूप का पता लगाएँ
- PowerPoint
- OpenDocument
- प्रेजेंटेशन
- PPT
- PPTX
- Android
- Java
- Aspose.Slides
description: "एंड्रॉइड पर Aspose.Slides for Android via Java का उपयोग करके लोडेड प्रेजेंटेशन का मूल स्वरूप पढ़ें, पहचान API की तुलना करें, और फ़ाइलें, स्ट्रीम, तथा पुरानी स्वरूपों को संभालें।"
---
## **सारांश**

प्रेजेंटेशन लोड करने के बाद, उसके मूल स्वरूप को निर्धारित करने के लिए [Presentation.getSourceFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/#getSourceFormat--) मेथड को कॉल करें। यह मेथड [IPresentation.getSourceFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipresentation/#getSourceFormat--) द्वारा भी उपलब्ध है। इसका उपयोग तब करें जब बाद की प्रोसेसिंग वर्तमान इंस्टेंस के लोड किए जाने वाले स्वरूप पर निर्भर करती हो।

स्रोत स्वरूप वह नहीं है जो [SaveFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/saveformat/) में आउटपुट फ़ाइल के लिए चुना जाता है। किसी अन्य स्वरूप में सहेजने से मौजूदा इंस्टेंस के स्रोत स्वरूप में परिवर्तन नहीं होता।

उदाहरणों में जावा और फ़ाइल पाथ का उपयोग किया गया है। एंड्रॉइड पर, नमूना पाथ को ऐप‑एक्सेसिबल स्टोरेज में स्थित पाथ से बदलें, जैसे आपके ऐप की आंतरिक फ़ाइल निर्देशिका।

## **फ़ाइल का स्रोत स्वरूप पढ़ें**

यह उदाहरण एक मौजूदा `sample.pptx` फ़ाइल की आवश्यकता रखता है। यह फ़ाइल लोड करता है और फ़ाइलनाम के बजाय [Presentation.getSourceFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/#getSourceFormat--) का उपयोग करके एप्लिकेशन प्रोसेसिंग पॉलिसी चुनता है। अन्य स्वरूपों को आज़माने के लिए इनपुट पाथ बदलें। उदाहरण चयनित पॉलिसी को प्रिंट करता है; संदेशों को अपनी एप्लिकेशन लॉजिक से बदलें।

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SourceFormat;

Presentation presentation = new Presentation("sample.pptx");
try {
    switch (presentation.getSourceFormat()) {
        case SourceFormat.Ppt:
        case SourceFormat.Pps:
        case SourceFormat.Pot:
            System.out.println("Use the legacy PowerPoint processing policy.");
            break;
        case SourceFormat.Pptx:
            System.out.println("Use the standard PPTX processing policy.");
            break;
        default:
            System.out.println("Use the general policy for source format " + presentation.getSourceFormat() + ".");
            break;
    }
} finally {
    presentation.dispose();
}
```

## **समर्थित मानों को पहचानें**

[SourceFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/sourceformat/) क्लास पूर्णांक कॉन्स्टैंट्स को परिभाषित करती है जो निम्नलिखित प्रेजेंटेशन स्वरूपों को अलग करती हैं। नीचे दिए गए एक्सटेंशन पारंपरिक एक्सटेंशन हैं, मूल फ़ाइलनाम के पुनर्निर्माण नहीं।

| SourceFormat मान | एक्सटेंशन | फ़ॉर्मेट |
| --- | --- | --- |
| `Ppt` | `.ppt` | PowerPoint 97–2003 प्रेजेंटेशन |
| `Pptx` | `.pptx` | Office Open XML प्रेजेंटेशन |
| `Pptm` | `.pptm` | मैक्रो‑सक्षम Office Open XML प्रेजेंटेशन |
| `Pps` | `.pps` | PowerPoint 97–2003 स्लाइड शो |
| `Ppsx` | `.ppsx` | Office Open XML स्लाइड शो |
| `Ppsm` | `.ppsm` | मैक्रो‑सक्षम Office Open XML स्लाइड शो |
| `Pot` | `.pot` | PowerPoint 97–2003 टेम्पलेट |
| `Potx` | `.potx` | Office Open XML टेम्पलेट |
| `Potm` | `.potm` | मैक्रो‑सक्षम Office Open XML टेम्पलेट |
| `Odp` | `.odp` | OpenDocument प्रेजेंटेशन |
| `Otp` | `.otp` | OpenDocument प्रेजेंटेशन टेम्पलेट |
| `Fodp` | `.fodp` | फ्लैट XML ODF प्रेजेंटेशन |
| `Xml` | `.xml` | PowerPoint XML प्रेजेंटेशन |

## **स्ट्रीम का स्रोत स्वरूप पढ़ें**

यह उदाहरण एक मौजूदा `sample.pps` फ़ाइल की आवश्यकता रखता है। इसके बाइट्स को मेमोरी स्ट्रीम में पढ़ना ऐसे इनपुट को मॉडल करता है जिसमें फ़ाइलनाम नहीं होता, जैसे डेटाबेस वैल्यू या अपलोड किया गया बाइट एरे। [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) कंस्ट्रक्टर केवल स्ट्रीम प्राप्त करता है।

```java
import com.aspose.slides.Presentation;
import java.io.ByteArrayInputStream;
import java.io.IOException;
import java.io.ByteArrayOutputStream;
import java.io.FileInputStream;

try {
    byte[] bytes;
    try (FileInputStream input = new FileInputStream("sample.pps");
         ByteArrayOutputStream output = new ByteArrayOutputStream()) {
        byte[] buffer = new byte[8192];
        int bytesRead;
        while ((bytesRead = input.read(buffer)) != -1) {
            output.write(buffer, 0, bytesRead);
        }
        bytes = output.toByteArray();
    }
    try (ByteArrayInputStream stream = new ByteArrayInputStream(bytes)) {
        Presentation presentation = new Presentation(stream);
        try {
            System.out.println("Source format: " + presentation.getSourceFormat());
        } finally {
            presentation.dispose();
        }
    }
} catch (IOException exception) {
    System.err.println("Cannot read the presentation: " + exception.getMessage());
}
```

PPT, PPS, और POT समान बाइनरी स्वरूप साझा करते हैं। फ़ाइल पाथ से लोड करने पर एक्सटेंशन स्लाइड शो या टेम्पलेट को पहचानने में मदद करता है। फ़ाइलनाम के बिना, पुराना PPS और POT कंटेंट `SourceFormat.Ppt` के रूप में रिपोर्ट हो सकता है; ऊपर का PPS उदाहरण `SourceFormat.Ppt` का पूर्णांक मान प्रिंट करता है।

यदि आपके एप्लिकेशन को यह अंतर बनाए रखना आवश्यक है, तो मूल फ़ाइलनाम या उप‑प्रकार मेटाडेटा को अलग से रखें। एक्सटेंशन इन पुरानी उप‑प्रकारों के लिए उपयोगी संकेत है, लेकिन यह मनमाने प्रेजेंटेशन कंटेंट की पहचान के लिए एकमात्र आधार नहीं होना चाहिए।

## **लोड करने से पहले और बाद में पहचान की तुलना करें**

जब आपको फ़ाइल की पूरी प्रेजेंटेशन ऑब्जेक्ट मॉडल लोड किए बिना निरीक्षण करना हो, तो [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) और [IPresentationInfo.getLoadFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipresentationinfo/#getLoadFormat--) का उपयोग करें। जब इंस्टेंस पहले से मौजूद हो, तो [Presentation.getSourceFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/#getSourceFormat--) का उपयोग करें।

यह उदाहरण `sample.pptx` की आवश्यकता रखता है और क्रमशः `LoadFormat.Pptx` और `SourceFormat.Pptx` के पूर्णांक मान प्रिंट करता है। प्रोडक्शन में, अपने प्रोसेसिंग चरण के अनुसार उपयुक्त API चुनें; पहले से लोडेड प्रेजेंटेशन को केवल स्रोत स्वरूप प्राप्त करने के लिए फिर से निरीक्षण करने की आवश्यकता नहीं है।

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.PresentationFactory;

String path = "sample.pptx";
IPresentationInfo information = PresentationFactory.getInstance().getPresentationInfo(path);
System.out.println("Before loading: " + information.getLoadFormat());

Presentation presentation = new Presentation(path);
try {
    System.out.println("After loading: " + presentation.getSourceFormat());
} finally {
    presentation.dispose();
}
```

परिणाम विभिन्न क्लासों के कॉन्स्टैंट्स से आते हैं: [LoadFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/loadformat/) और [SourceFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/sourceformat/)। उनके संख्यात्मक मानों की तुलना न करें और न ही मानें कि प्रत्येक स्वरूप के लिए पहचान परिणाम समान हैं। PowerPoint XML लोड करने से पहले `LoadFormat.Unknown` और लोड करने के बाद `SourceFormat.Xml` के रूप में रिपोर्ट हो सकता है।

## **स्रोत और आउटपुट स्वरूपों को अलग रखें**

यह उदाहरण `sample.pptx` की आवश्यकता रखता है और `converted.odp` लिखता है। यह `SourceFormat.Pptx` का पूर्णांक मान दोनों बार, सहेजने से पहले और बाद में, प्रिंट करता है। केवल नया इंस्टेंस जो ODP आउटपुट से लोड किया गया है, `Odp` रिपोर्ट करता है।

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("sample.pptx");
try {
    System.out.println("Before saving: " + presentation.getSourceFormat());

    presentation.save("converted.odp", SaveFormat.Odp);
    System.out.println("After saving: " + presentation.getSourceFormat());

    Presentation reopened = new Presentation("converted.odp");
    try {
        System.out.println("Reopened output: " + reopened.getSourceFormat());
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

`new Presentation()` से शून्य से बनाया गया प्रेजेंटेशन `SourceFormat.Pptx` रिपोर्ट करता है। उसके पास कोई इनपुट फ़ाइल नहीं होती: यह नई बनाई गई इंस्टेंस का डिफ़ॉल्ट मान है, यह प्रमाण नहीं कि PPTX फ़ाइल लोड हुई है। यदि यह अंतर आपके लिए मायने रखता है, तो ट्रैक रखें कि आपके एप्लिकेशन ने इंस्टेंस बनाया या लोड किया।

## **स्रोत स्वरूप को एक्सटेंशन से मैप करें**

यह उदाहरण `sample.pptx` की आवश्यकता रखता है। यह प्रत्येक वर्तमान में समर्थित [SourceFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/sourceformat/) मान को पारंपरिक एक्सटेंशन में मैप करता है, बिना इनपुट फ़ाइलनाम को पार्स किए। फॉलबैक अनपहचाने मान को एक्सटेंशन असाइन करने से बचाता है।

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SourceFormat;

Presentation presentation = new Presentation("sample.pptx");
try {
    String extension;
    switch (presentation.getSourceFormat()) {
        case SourceFormat.Ppt:
            extension = ".ppt";
            break;
        case SourceFormat.Pptx:
            extension = ".pptx";
            break;
        case SourceFormat.Pptm:
            extension = ".pptm";
            break;
        case SourceFormat.Pps:
            extension = ".pps";
            break;
        case SourceFormat.Ppsx:
            extension = ".ppsx";
            break;
        case SourceFormat.Ppsm:
            extension = ".ppsm";
            break;
        case SourceFormat.Pot:
            extension = ".pot";
            break;
        case SourceFormat.Potx:
            extension = ".potx";
            break;
        case SourceFormat.Potm:
            extension = ".potm";
            break;
        case SourceFormat.Odp:
            extension = ".odp";
            break;
        case SourceFormat.Otp:
            extension = ".otp";
            break;
        case SourceFormat.Fodp:
            extension = ".fodp";
            break;
        case SourceFormat.Xml:
            extension = ".xml";
            break;
        default:
            extension = null;
            break;
    }

    System.out.println(extension != null ? extension : "No extension mapping is available.");
} finally {
    presentation.dispose();
}
```

यह मैपिंग फ़ाइल को बदलती नहीं है और स्ट्रीम लोडिंग के दौरान खोए हुए पुराने PPS/POT उप‑प्रकार को पुनः प्राप्त नहीं करती। वास्तविक सहेजने के लिए, स्पष्ट रूप से एक [SaveFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/saveformat/) चुनें, या [Save Presentations in Their Original Format](/slides/hi/androidjava/save-presentation/#save-presentations-in-their-original-format) में दिखाए गए रूपांतरण का उपयोग करें।

## **सहेजने और पुनः खोलने से स्वरूपों को सत्यापित करें**

यह स्व-निहित उदाहरण एक प्रेजेंटेशन बनाता है और कार्य निर्देशिका में तीन फ़ाइलें लिखता है, समान नाम वाली फ़ाइलों को ओवरराइट करता है। यह प्रत्येक आउटपुट को पाथ और मेमोरी स्ट्रीम दोनों से पुनः खोलता है। PPTX और ODP के लिए, दोनों मार्ग सहेजे गए स्वरूप को रिपोर्ट करते हैं। PPS के लिए, पाथ से लोड करने पर `Pps` रिपोर्ट होता है, जबकि फ़ाइलनाम के बिना वही बाइट्स लोड करने पर `Ppt` रिपोर्ट होता है।

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.ByteArrayInputStream;
import java.io.IOException;
import java.io.ByteArrayOutputStream;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
try {
    int[] formats = { SaveFormat.Pptx, SaveFormat.Odp, SaveFormat.Pps };
    String[] extensions = { "pptx", "odp", "pps" };

    for (int i = 0; i < formats.length; i++) {
        String path = "roundtrip." + extensions[i];
        presentation.save(path, formats[i]);

        Presentation fromFile = new Presentation(path);
        try {
            byte[] bytes;
            try (FileInputStream input = new FileInputStream(path);
                 ByteArrayOutputStream output = new ByteArrayOutputStream()) {
                byte[] buffer = new byte[8192];
                int bytesRead;
                while ((bytesRead = input.read(buffer)) != -1) {
                    output.write(buffer, 0, bytesRead);
                }
                bytes = output.toByteArray();
            }
            try (ByteArrayInputStream stream = new ByteArrayInputStream(bytes)) {
                Presentation fromStream = new Presentation(stream);
                try {
                    System.out.println(extensions[i] + ": file=" + fromFile.getSourceFormat() + ", stream=" + fromStream.getSourceFormat());
                } finally {
                    fromStream.dispose();
                }
            }
        } finally {
            fromFile.dispose();
        }
    }
} catch (IOException exception) {
    System.err.println("Cannot read a saved presentation: " + exception.getMessage());
} finally {
    presentation.dispose();
}
```

निम्न तालिका मिलते‑जुलते एक्सटेंशन वाले प्रेजेंटेशन के स्रोत‑स्वरूप पहचान का सारांश देती है। नाम कॉन्स्टैंट्स को दर्शाते हैं; जावा उदाहरण उनके पूर्णांक मान प्रिंट करते हैं:

| सहेजा गया स्वरूप | फ़ाइल पाथ से SourceFormat | नाम‑रहित स्ट्रीम से SourceFormat |
| --- | --- | --- |
| PPT | `Ppt` | `Ppt` |
| PPTX, PPTM | क्रमशः `Pptx`, `Pptm` | फ़ाइल पाथ जैसा ही |
| PPS | `Pps` | `Ppt` |
| PPSX, PPSM | क्रमशः `Ppsx`, `Ppsm` | फ़ाइल पाथ जैसा ही |
| POT | `Pot` | `Ppt` |
| POTX, POTM | क्रमशः `Potx`, `Potm` | फ़ाइल पाथ जैसा ही |
| ODP, OTP | क्रमशः `Odp`, `Otp` | फ़ाइल पाथ जैसा ही |
| FODP | `Fodp` | `Fodp` |
| PowerPoint XML | `Xml` | `Xml` |

PPS/POT कंटेंट को नाम‑रहित स्ट्रीम के लिए `Ppt` के रूप में पहचाना जाता है। यह तालिका स्वरूप पहचान को दर्शाती है, न कि रूपांतरण के दौरान हर प्रेजेंटेशन विशेषता के संरक्षण को।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या PPTX से लोड किए गए प्रेजेंटेशन को ODP में सहेजने से स्रोत स्वरूप बदल जाता है?**

नहीं। मौजूदा इंस्टेंस अभी भी `Pptx` रिपोर्ट करता है। सहेजे गए ODP फ़ाइल से लोड किया गया इंस्टेंस `Odp` रिपोर्ट करता है।

**क्या स्ट्रीम हमेशा एक पुरानी प्रेजेंटेशन, स्लाइड शो और टेम्पलेट को अलग कर सकती है?**

नहीं। PPT, PPS, और POT बाइनरी स्वरूप साझा करते हैं। यदि इस अंतर की आवश्यकता है, तो फ़ाइलनाम या उप‑प्रकार मेटाडेटा को अलग से रखें।

**यदि प्रेजेंटेशन पहले से लोडेड है, तो कौन सा API उपयोग करना चाहिए?**

[Presentation.getSourceFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/#getSourceFormat--) पढ़ें। लोड करने से पहले निरीक्षण के लिए [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) का उपयोग करें।