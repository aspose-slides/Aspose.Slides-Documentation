---
title: जावा में मूल प्रस्तुति स्वरूप निर्धारित करें
linktitle: स्रोत स्वरूप
type: docs
weight: 35
url: /hi/java/detect-presentation-source-format/
keywords:
- स्रोत स्वरूप
- प्रस्तुति स्वरूप का पता लगाएँ
- PowerPoint
- OpenDocument
- प्रस्तुति
- PPT
- PPTX
- Java
- Aspose.Slides
description: "Aspose.Slides for Java का उपयोग करके जावा में लोड की गई प्रस्तुति के मूल स्वरूप को पढ़ें, पहचान API की तुलना करें, और फ़ाइलों, स्ट्रीम और लेगेसी स्वरूपों को संभालें।"
---
## **समीक्षा**

एक प्रस्तुति लोड करने के बाद, उसके मूल स्वरूप का पता लगाने के लिए [Presentation.getSourceFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/#getSourceFormat--) मेथड को कॉल करें। यह मेथड [IPresentation.getSourceFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipresentation/#getSourceFormat--) द्वारा भी उपलब्ध है। इसका उपयोग तब करें जब बाद की प्रोसेसिंग वर्तमान इंस्टैंस के लोड किए गए स्वरूप पर निर्भर करती है।

स्रोत स्वरूप वह [SaveFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/saveformat/) से अलग होता है जो आउटपुट फ़ाइल के लिए चुना जाता है। किसी अन्य स्वरूप में सहेजने से मौजूदा इंस्टैंस का स्रोत स्वरूप नहीं बदलता।

## **फ़ाइल का स्रोत स्वरूप पढ़ें**

इस उदाहरण के लिए एक मौजूदा `sample.pptx` फ़ाइल आवश्यक है। यह फ़ाइल को लोड करता है और फ़ाइल नाम के बजाय [Presentation.getSourceFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/#getSourceFormat--) का उपयोग करके एप्लिकेशन प्रोसेसिंग नीति चुनता है। अन्य स्वरूपों को आज़माने के लिए इनपुट पथ बदलें। उदाहरण चुनी गई नीति को प्रिंट करता है; संदेशों को अपने एप्लिकेशन लॉजिक से बदलें।

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

[SourceFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/sourceformat/) क्लास पूर्णांक स्थिरांक परिभाषित करती है जो निम्नलिखित प्रस्तुति स्वरूपों को अलग करती है। नीचे दिए गए एक्सटेंशन सामान्य एक्सटेंशन हैं, मूल फ़ाइलनाम का पुनर्निर्माण नहीं।

| SourceFormat मान | एक्सटेंशन | प्रारूप |
| --- | --- | --- |
| `Ppt` | `.ppt` | PowerPoint 97–2003 प्रस्तुति |
| `Pptx` | `.pptx` | Office Open XML प्रस्तुति |
| `Pptm` | `.pptm` | मैक्रो‑सक्षम Office Open XML प्रस्तुति |
| `Pps` | `.pps` | PowerPoint 97–2003 स्लाइड शो |
| `Ppsx` | `.ppsx` | Office Open XML स्लाइड शो |
| `Ppsm` | `.ppsm` | मैक्रो‑सक्षम Office Open XML स्लाइड शो |
| `Pot` | `.pot` | PowerPoint 97–2003 टेम्प्लेट |
| `Potx` | `.potx` | Office Open XML टेम्प्लेट |
| `Potm` | `.potm` | मैक्रो‑सक्षम Office Open XML टेम्प्लेट |
| `Odp` | `.odp` | OpenDocument प्रस्तुति |
| `Otp` | `.otp` | OpenDocument प्रस्तुति टेम्प्लेट |
| `Fodp` | `.fodp` | Flat XML ODF प्रस्तुति |
| `Xml` | `.xml` | PowerPoint XML प्रस्तुति |

## **स्ट्रीम का स्रोत स्वरूप पढ़ें**

इस उदाहरण के लिए एक मौजूदा `sample.pps` फ़ाइल आवश्यक है। उसके बाइट्स को मेमोरी स्ट्रीम में पढ़ना उन इनपुट को मॉडल करता है जो फ़ाइल नाम के बिना प्राप्त होते हैं, जैसे डेटाबेस मान या अपलोड किया गया बाइट एरे। [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) कंस्ट्रक्टर केवल स्ट्रीम प्राप्त करता है।

```java
import com.aspose.slides.Presentation;
import java.io.ByteArrayInputStream;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;

try {
    byte[] bytes = Files.readAllBytes(Paths.get("sample.pps"));
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

PPT, PPS और POT समान बाइनरी स्वरूप साझा करते हैं। फ़ाइल पथ से लोड करने पर एक्सटेंशन स्लाइड शो या टेम्प्लेट को अलग करने में मदद कर सकता है। फ़ाइल नाम के बिना, लेगेसी PPS और POT सामग्री को `SourceFormat.Ppt` के रूप में रिपोर्ट किया जा सकता है; ऊपर का PPS उदाहरण `SourceFormat.Ppt` का पूर्णांक मान प्रिंट करता है।

यदि आपके एप्लिकेशन को यह अंतर बनाए रखना आवश्यक है, तो मूल फ़ाइलनाम या उपप्रकार मेटाडेटा को अलग से रखें। एक्सटेंशन इन लेगेसी उपप्रकारों के लिए उपयोगी संकेत है, लेकिन यादृच्छिक प्रस्तुति सामग्री की पहचान का एकमात्र आधार नहीं होना चाहिए।

## **लोड करने से पहले और बाद में पहचान की तुलना करें**

फ़ाइल को पूरी प्रस्तुति ऑब्जेक्ट मॉडल में लोड करने से पहले निरीक्षण करने के लिए [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) और [IPresentationInfo.getLoadFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipresentationinfo/#getLoadFormat--) का उपयोग करें। जब इंस्टैंस पहले से मौजूद हो, तो [Presentation.getSourceFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/#getSourceFormat--) का उपयोग करें।

यह उदाहरण `sample.pptx` की आवश्यकता रखता है और क्रमशः `LoadFormat.Pptx` तथा `SourceFormat.Pptx` के पूर्णांक मान प्रिंट करता है। प्रोडक्शन में अपने प्रोसेसिंग चरण के अनुसार उपयुक्त API चुनें; पहले से लोड की गई प्रस्तुति को केवल स्रोत स्वरूप पाने के लिए दोबारा निरीक्षण की जरूरत नहीं है।

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

परिणाम विभिन्न क्लासों के स्थिरांक से आते हैं: [LoadFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/loadformat/) और [SourceFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/sourceformat/)। उनके संख्यात्मक मानों की तुलना न करें या यह न मानें कि प्रत्येक स्वरूप के लिए पहचान परिणाम समान होंगे। PowerPoint XML को लोड करने से पहले `LoadFormat.Unknown` और लोड करने के बाद `SourceFormat.Xml` के रूप में रिपोर्ट किया जा सकता है।

## **स्रोत और आउटपुट स्वरूपों को अलग रखें**

यह उदाहरण `sample.pptx` की आवश्यकता रखता है और `converted.odp` लिखता है। यह `SourceFormat.Pptx` के पूर्णांक मान को मूल इंस्टैंस को सहेजने से पहले और बाद दोनों बार प्रिंट करता है। ODP आउटपुट से लोड की गई नई इंस्टैंस केवल `Odp` रिपोर्ट करती है।

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

`new Presentation()` से शून्य से बनाई गई प्रस्तुति `SourceFormat.Pptx` रिपोर्ट करती है। इसका कोई इनपुट फ़ाइल नहीं होती: यह नई बनाई गई इंस्टैंस के लिए डिफ़ॉल्ट मान है, न कि यह संकेत कि PPTX फ़ाइल लोड हुई थी। यदि यह अंतर आपके लिए महत्वपूर्ण है, तो अपने एप्लिकेशन में यह ट्रैक रखें कि इंस्टैंस बनाई गई थी या लोड की गई।

## **स्रोत स्वरूप को एक्सटेंशन में मैप करें**

निम्न उदाहरण के लिए `sample.pptx` आवश्यक है। यह प्रत्येक वर्तमान समर्थित [SourceFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/sourceformat/) मान को सामान्य एक्सटेंशन में मैप करता है, बिना इनपुट फ़ाइलनाम को पार्स किए। fallback अनपहचाने मान के लिए मौन रूप से एक्सटेंशन असाइन होने से बचाता है।

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

यह मैपिंग फ़ाइल को नहीं बदलती या स्ट्रीम लोडिंग के दौरान खोए गए लेगेसी PPS/POT उपप्रकार को पुनर्प्राप्त नहीं करती। वास्तविक सहेजने के लिए, स्पष्ट रूप से एक [SaveFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/saveformat/) चुनें, या [Save Presentations in Their Original Format](/slides/hi/java/save-presentation/#save-presentations-in-their-original-format) में दिखाए गए रूपांतरण का उपयोग करें।

## **सहेजने और पुनः खोलने से स्वरूपों की जाँच करें**

यह स्वतंत्र उदाहरण एक प्रस्तुति बनाता है और कार्य निर्देशिका में तीन फ़ाइलें लिखता है, समान नाम वाली फ़ाइलों को प्रतिस्थापित करता है। यह प्रत्येक आउटपुट को पथ और मेमोरी स्ट्रीम दोनों के माध्यम से पुनः खोलता है। PPTX और ODP के लिए, दोनों मार्ग सहेजे गए स्वरूप को रिपोर्ट करते हैं। PPS के लिए, पथ से लोड करने पर `Pps` मिलता है, जबकि फ़ाइल नाम के बिना वही बाइट्स लोड करने पर `Ppt` मिलता है।

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.ByteArrayInputStream;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    int[] formats = { SaveFormat.Pptx, SaveFormat.Odp, SaveFormat.Pps };
    String[] extensions = { "pptx", "odp", "pps" };

    for (int i = 0; i < formats.length; i++) {
        String path = "roundtrip." + extensions[i];
        presentation.save(path, formats[i]);

        Presentation fromFile = new Presentation(path);
        try {
            byte[] bytes = Files.readAllBytes(Paths.get(path));
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

निम्न तालिका समान एक्सटेंशन वाली प्रस्तुतियों के लिए स्रोत‑स्वरूप पहचान का सारांश देती है। नाम स्थिरांक दर्शाते हैं; Java उदाहरण उनके पूर्णांक मान प्रिंट करते हैं:

| सहेजा गया स्वरूप | फ़ाइल पथ से SourceFormat | नामरहित स्ट्रीम से SourceFormat |
| --- | --- | --- |
| PPT | `Ppt` | `Ppt` |
| PPTX, PPTM | क्रमशः `Pptx`, `Pptm` | फ़ाइल पथ जैसा ही |
| PPS | `Pps` | `Ppt` |
| PPSX, PPSM | क्रमशः `Ppsx`, `Ppsm` | फ़ाइल पथ जैसा ही |
| POT | `Pot` | `Ppt` |
| POTX, POTM | क्रमशः `Potx`, `Potm` | फ़ाइल पथ जैसा ही |
| ODP, OTP | क्रमशः `Odp`, `Otp` | फ़ाइल पथ जैसा ही |
| FODP | `Fodp` | `Fodp` |
| PowerPoint XML | `Xml` | `Xml` |

PPS/POT सामग्री को नामरहित स्ट्रीम के लिए `Ppt` के रूप में पहचाना जाता है। तालिका स्वरूप पहचान को दर्शाती है, न कि रूपांतरण के दौरान प्रत्येक प्रस्तुति विशेषता के संरक्षण को।

## **FAQ**

**क्या PPTX से लोड की गई प्रस्तुति को ODP में सहेजने से स्रोत स्वरूप बदल जाता है?**

नहीं। मौजूदा इंस्टैंस अभी भी `Pptx` रिपोर्ट करती है। सहेजे गए ODP फ़ाइल से लोड की गई इंस्टैंस `Odp` रिपोर्ट करती है।

**क्या स्ट्रीम हमेशा लेगेसी प्रस्तुति, स्लाइड शो और टेम्प्लेट को अलग कर सकती है?**

नहीं। PPT, PPS और POT बाइनरी स्वरूप साझा करते हैं। जब यह अंतर आवश्यक हो, तो फ़ाइलनाम या उपप्रकार मेटाडेटा को अलग से रखें।

**यदि प्रस्तुति पहले से लोड है तो मुझे कौन सा API उपयोग करना चाहिए?**

[Presentation.getSourceFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/#getSourceFormat--) पढ़ें। लोड करने से पहले निरीक्षण के लिए [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) का उपयोग करें।