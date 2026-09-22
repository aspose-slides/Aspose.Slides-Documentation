---
title: Node.js में मूल प्रेजेंटेशन फ़ॉर्मेट निर्धारित करें
linktitle: स्रोत फ़ॉर्मेट
type: docs
weight: 35
url: /hi/nodejs-java/detect-presentation-source-format/
keywords:
- स्रोत फ़ॉर्मेट
- प्रेजेंटेशन फ़ॉर्मेट का पता लगाएँ
- PowerPoint
- OpenDocument
- प्रस्तुति
- PPT
- PPTX
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java का उपयोग करके Node.js में लोड किए गए प्रेजेंटेशन के मूल फ़ॉर्मेट को पढ़ें, डिटेक्शन APIs की तुलना करें, और फ़ाइलों, स्ट्रीम, और लेगेसी फ़ॉर्मेट को संभालें।"
---
## **अवलोकन**

प्रेजेंटेशन को लोड करने के बाद, उसके मूल फ़ॉर्मेट निर्धारित करने के लिए [Presentation.getSourceFormat](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/#getSourceFormat) मेथड को कॉल करें। इसका उपयोग तब करें जब आगे की प्रोसेसिंग इस बात पर निर्भर करती हो कि वर्तमान इंस्टेंस किस फ़ॉर्मेट से लोड किया गया था।

स्रोत फ़ॉर्मेट आउटपुट फ़ाइल के लिए चुने गए [SaveFormat](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/saveformat/) से अलग है। किसी अन्य फ़ॉर्मेट में सेव करने से मौजूदा इंस्टेंस के स्रोत फ़ॉर्मेट में कोई बदलाव नहीं होता।

## **फ़ाइल का स्रोत फ़ॉर्मेट पढ़ें**

यह उदाहरण एक मौजूदा `sample.pptx` फ़ाइल की आवश्यकता रखता है। यह फ़ाइल को लोड करता है और फ़ाइलनाम के बजाय [Presentation.getSourceFormat](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/#getSourceFormat) का उपयोग करके एप्लिकेशन प्रोसेसिंग पॉलिसी चुनता है। अन्य फ़ॉर्मेट आज़माने के लिए इनपुट पाथ बदलें। उदाहरण चयनित पॉलिसी को प्रिंट करता है; संदेशों को अपनी एप्लिकेशन लॉजिक से बदलें।

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.Presentation("sample.pptx");
try {
    switch (presentation.getSourceFormat()) {
        case aspose.SourceFormat.Ppt:
        case aspose.SourceFormat.Pps:
        case aspose.SourceFormat.Pot:
            console.log("Use the legacy PowerPoint processing policy.");
            break;
        case aspose.SourceFormat.Pptx:
            console.log("Use the standard PPTX processing policy.");
            break;
        default:
            console.log("Use the general policy for source format " + presentation.getSourceFormat() + ".");
            break;
    }
} finally {
    presentation.dispose();
}
```

## **समर्थित मानों को पहचानें**

[SourceFormat](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/sourceformat/) क्लास में पूर्णांक कॉन्स्टेंट होते हैं जो निम्नलिखित प्रेजेंटेशन फ़ॉर्मेट को अलग पहचानते हैं। नीचे दिए गए एक्सटेंशन सामान्य एक्सटेंशन हैं, मूल फ़ाइलनाम के पुनर्सृजन नहीं हैं।

| SourceFormat मान | एक्सटेंशन | फ़ॉर्मेट |
| --- | --- | --- |
| `Ppt` | `.ppt` | PowerPoint 97–2003 presentation |
| `Pptx` | `.pptx` | Office Open XML presentation |
| `Pptm` | `.pptm` | Macro-enabled Office Open XML presentation |
| `Pps` | `.pps` | PowerPoint 97–2003 slide show |
| `Ppsx` | `.ppsx` | Office Open XML slide show |
| `Ppsm` | `.ppsm` | Macro-enabled Office Open XML slide show |
| `Pot` | `.pot` | PowerPoint 97–2003 template |
| `Potx` | `.potx` | Office Open XML template |
| `Potm` | `.potm` | Macro-enabled Office Open XML template |
| `Odp` | `.odp` | OpenDocument presentation |
| `Otp` | `.otp` | OpenDocument presentation template |
| `Fodp` | `.fodp` | Flat XML ODF presentation |
| `Xml` | `.xml` | PowerPoint XML presentation |

## **स्ट्रीम का स्रोत फ़ॉर्मेट पढ़ें**

यह उदाहरण एक मौजूदा `sample.pps` फ़ाइल की आवश्यकता रखता है। उसके बाइट्स को मेमॉरी स्ट्रीम में पढ़ना उन स्थितियों का मॉडल है जहाँ फ़ाइलनाम नहीं मिलता, जैसे डेटाबेस वैल्यू या अपलोड किया गया बाइट एरे। [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) कंस्ट्रक्टर केवल स्ट्रीम प्राप्त करता है।

```javascript
const aspose = require("aspose.slides.via.java");
const java = require("java");
const fs = require("fs");

const buffer = fs.readFileSync("sample.pps");
const bytes = java.newArray("byte", Array.from(buffer));
const stream = java.newInstanceSync("java.io.ByteArrayInputStream", bytes);
try {
    const presentation = new aspose.Presentation(stream);
    try {
        console.log("Source format: " + presentation.getSourceFormat());
    } finally {
        presentation.dispose();
    }
} finally {
    stream.close();
}
```

PPT, PPS, और POT एक ही बाइनरी फ़ॉर्मेट साझा करते हैं। फ़ाइल पाथ से लोड करने पर एक्सटेंशन स्लाइड शो या टेम्पलेट को अलग पहचानने में मदद कर सकता है। फ़ाइलनाम न होने पर लेगेसी PPS और POT कंटेंट को `SourceFormat.Ppt` के रूप में रिपोर्ट किया जा सकता है; ऊपर दिया गया PPS उदाहरण `SourceFormat.Ppt` का पूर्णांक मूल्य प्रिंट करता है।

यदि आपके एप्लिकेशन को इस अंतर को बनाए रखना आवश्यक है, तो मूल फ़ाइलनाम या सबटाइप मेटाडाटा को अलग से रखें। एक्सटेंशन इन लेगेसी सबटाइप के लिए उपयोगी संकेत हो सकता है, लेकिन इसे अस्पष्ट प्रेजेंटेशन कंटेंट की पहचान का अकेला आधार नहीं बनाना चाहिए।

## **लोड करने से पहले और बाद में डिटेक्शन की तुलना करें**

फ़ाइल को पूरी प्रेजेंटेशन ऑब्जेक्ट मॉडल में लोड करने से पहले निरीक्षण करने की आवश्यकता होने पर [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfo) और [PresentationInfo.getLoadFormat](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentationinfo/#getLoadFormat) का उपयोग करें। जब इंस्टेंस पहले से मौजूद हो, तो [Presentation.getSourceFormat](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/#getSourceFormat) प्रयोग करें।

यह उदाहरण `sample.pptx` की आवश्यकता रखता है और क्रमशः `LoadFormat.Pptx` तथा `SourceFormat.Pptx` के पूर्णांक मूल्य प्रिंट करता है। प्रोडक्शन में अपने प्रोसेसिंग चरण के अनुसार उपयुक्त API चुनें; एक बार लोड की गई प्रेजेंटेशन को उसके स्रोत फ़ॉर्मेट को प्राप्त करने के लिए फिर से जांचने की आवश्यकता नहीं है।

```javascript
const aspose = require("aspose.slides.via.java");

const path = "sample.pptx";
const information = aspose.PresentationFactory.getInstance().getPresentationInfo(path);
console.log("Before loading: " + information.getLoadFormat());

const presentation = new aspose.Presentation(path);
try {
    console.log("After loading: " + presentation.getSourceFormat());
} finally {
    presentation.dispose();
}
```

परिणाम विभिन्न क्लासों के कॉन्स्टेंट का उपयोग करते हैं: [LoadFormat](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/loadformat/) और [SourceFormat](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/sourceformat/)। इनके न्यूमेरिक वैल्यू की तुलना न करें और न ही मानें कि हर फ़ॉर्मेट के डिटेक्शन परिणाम समान होते हैं। PowerPoint XML लोड करने से पहले `LoadFormat.Unknown` और लोड करने के बाद `SourceFormat.Xml` के रूप में रिपोर्ट किया जा सकता है।

## **स्रोत और आउटपुट फ़ॉर्मेट को अलग रखें**

यह उदाहरण `sample.pptx` की आवश्यकता रखता है और `converted.odp` लिखता है। यह मूल इंस्टेंस को सेव करने से पहले और बाद दोनों में `SourceFormat.Pptx` का पूर्णांक मूल्य प्रिंट करता है। केवल नया इंस्टेंस जो ODP आउटपुट से लोड होता है `Odp` रिपोर्ट करता है।

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.Presentation("sample.pptx");
try {
    console.log("Before saving: " + presentation.getSourceFormat());

    presentation.save("converted.odp", aspose.SaveFormat.Odp);
    console.log("After saving: " + presentation.getSourceFormat());

    const reopened = new aspose.Presentation("converted.odp");
    try {
        console.log("Reopened output: " + reopened.getSourceFormat());
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

`new Presentation()` से शुरू से बनाई गई प्रेजेंटेशन `SourceFormat.Pptx` रिपोर्ट करती है। इसका कोई इनपुट फ़ाइल नहीं है: यह नए बनाए गए इंस्टेंस के लिए डिफ़ॉल्ट मान है, यह प्रमाण नहीं है कि PPTX फ़ाइल लोड हुई थी। यदि यह अंतर आपके लिए मायने रखता है, तो एप्लिकेशन ने इंस्टेंस को बनाया या लोड किया, यह अलग से ट्रैक करें।

## **स्रोत फ़ॉर्मेट को एक्सटेंशन से मैप करें**

यह उदाहरण `sample.pptx` की आवश्यकता रखता है। यह प्रत्येक वर्तमान समर्थित [SourceFormat](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/sourceformat/) मान को पारंपरिक एक्सटेंशन से मैप करता है, बिना इनपुट फ़ाइलनाम को पार्स किए। फॉलबैक अनपेक्षित मान के लिए चुपचाप एक्सटेंशन असाइन करने से बचता है।

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.Presentation("sample.pptx");
try {
    let extension;
    switch (presentation.getSourceFormat()) {
        case aspose.SourceFormat.Ppt:
            extension = ".ppt";
            break;
        case aspose.SourceFormat.Pptx:
            extension = ".pptx";
            break;
        case aspose.SourceFormat.Pptm:
            extension = ".pptm";
            break;
        case aspose.SourceFormat.Pps:
            extension = ".pps";
            break;
        case aspose.SourceFormat.Ppsx:
            extension = ".ppsx";
            break;
        case aspose.SourceFormat.Ppsm:
            extension = ".ppsm";
            break;
        case aspose.SourceFormat.Pot:
            extension = ".pot";
            break;
        case aspose.SourceFormat.Potx:
            extension = ".potx";
            break;
        case aspose.SourceFormat.Potm:
            extension = ".potm";
            break;
        case aspose.SourceFormat.Odp:
            extension = ".odp";
            break;
        case aspose.SourceFormat.Otp:
            extension = ".otp";
            break;
        case aspose.SourceFormat.Fodp:
            extension = ".fodp";
            break;
        case aspose.SourceFormat.Xml:
            extension = ".xml";
            break;
        default:
            extension = null;
            break;
    }

    console.log(extension != null ? extension : "No extension mapping is available.");
} finally {
    presentation.dispose();
}
```

यह मैपिंग फ़ाइल को बदलती नहीं है और स्ट्रीम लोडिंग के दौरान खोए लेगेसी PPS/POT सबटाइप को पुनर्प्राप्त नहीं करती। वास्तविक सेविंग के लिए स्पष्ट रूप से एक [SaveFormat](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/saveformat/) चुनें, या [Save Presentations in Their Original Format](/slides/hi/nodejs-java/save-presentation/#save-presentations-in-their-original-format) में दिखाए गए रूपांतरण का उपयोग करें।

## **सेव करके फिर खोलकर फ़ॉर्मेट सत्यापित करें**

यह स्व-समावेशी उदाहरण एक प्रेजेंटेशन बनाता है और वर्किंग डायरेक्टरी में तीन फ़ाइलें लिखता है, समान नाम वाली फ़ाइलों को ओवरराइट करता है। यह प्रत्येक आउटपुट को पाथ और मेमॉरी स्ट्रीम दोनों से फिर से खोलता है। PPTX और ODP के लिए दोनों रास्ते सेव किए गए फ़ॉर्मेट को रिपोर्ट करते हैं। PPS के लिए पाथ से लोड करने पर `Pps` रिपोर्ट होता है, जबकि वही बाइट्स बिना फ़ाइलनाम के लोड करने पर `Ppt` रिपोर्ट होता है।

```javascript
const aspose = require("aspose.slides.via.java");
const java = require("java");
const fs = require("fs");

const presentation = new aspose.Presentation();
try {
    const formats = [aspose.SaveFormat.Pptx, aspose.SaveFormat.Odp, aspose.SaveFormat.Pps];
    const extensions = ["pptx", "odp", "pps"];

    for (let i = 0; i < formats.length; i++) {
        const path = "roundtrip." + extensions[i];
        presentation.save(path, formats[i]);

        const fromFile = new aspose.Presentation(path);
        try {
            const buffer = fs.readFileSync(path);
            const bytes = java.newArray("byte", Array.from(buffer));
            const stream = java.newInstanceSync("java.io.ByteArrayInputStream", bytes);
            try {
                const fromStream = new aspose.Presentation(stream);
                try {
                    console.log(extensions[i] + ": file=" + fromFile.getSourceFormat() + ", stream=" + fromStream.getSourceFormat());
                } finally {
                    fromStream.dispose();
                }
            } finally {
                stream.close();
            }
        } finally {
            fromFile.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

निम्न तालिका मिलते-जुलते एक्सटेंशन वाले प्रेजेंटेशन के लिए स्रोत‑फ़ॉर्मेट पहचान को संक्षेपित करती है। नाम कॉन्स्टेंट दर्शाते हैं; जावास्क्रिप्ट उदाहरण उनके पूर्णांक मान प्रिंट करते हैं:

| सेव किया गया फ़ॉर्मेट | फ़ाइल पाथ से SourceFormat | नाम रहित स्ट्रीम से SourceFormat |
| --- | --- | --- |
| PPT | `Ppt` | `Ppt` |
| PPTX, PPTM | `Pptx`, `Pptm` क्रमशः | फ़ाइल पाथ जैसा ही |
| PPS | `Pps` | `Ppt` |
| PPSX, PPSM | `Ppsx`, `Ppsm` क्रमशः | फ़ाइल पाथ जैसा ही |
| POT | `Pot` | `Ppt` |
| POTX, POTM | `Potx`, `Potm` क्रमशः | फ़ाइल पाथ जैसा ही |
| ODP, OTP | `Odp`, `Otp` क्रमशः | फ़ाइल पाथ जैसा ही |
| FODP | `Fodp` | `Fodp` |
| PowerPoint XML | `Xml` | `Xml` |

PPS/POT कंटेंट को नाम रहित स्ट्रीम के लिए `Ppt` के रूप में पहचान किया जाता है। यह तालिका फ़ॉर्मेट पहचान को दर्शाती है, न कि रूपांतरण के दौरान प्रत्येक प्रेजेंटेशन फ़ीचर के संरक्षण को।

## **FAQ**

**क्या PPTX से लोड किए गए प्रेजेंटेशन को ODP में सेव करने से उसका स्रोत फ़ॉर्मेट बदल जाता है?**

नहीं। मौजूदा इंस्टेंस अभी भी `Pptx` रिपोर्ट करता है। जो इंस्टेंस सेव किए गए ODP फ़ाइल से लोड किया जाता है वह `Odp` रिपोर्ट करता है।

**क्या एक स्ट्रीम हमेशा लेगेसी प्रेजेंटेशन, स्लाइड शो, और टेम्पलेट को अलग पहचान सकती है?**

नहीं। PPT, PPS, और POT एक ही बाइनरी फ़ॉर्मेट साझा करते हैं। जब यह अंतर आवश्यक हो, तो फ़ाइलनाम या सबटाइप मेटाडाटा को अलग से रखें।

**यदि प्रेजेंटेशन पहले से लोड है, तो मुझे कौन सा API उपयोग करना चाहिए?**

[Presentation.getSourceFormat](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/#getSourceFormat) पढ़ें। लोड करने से पहले निरीक्षण के लिए [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfo) उपयोग करें।