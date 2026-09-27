---
title: Node.js के माध्यम से .NET में प्रस्तुतियों को खोलें
linktitle: प्रस्तुति खोलें
type: docs
weight: 20
url: /hi/nodejs-net/open-presentation/
keywords:
- प्रस्तुति खोलें
- PowerPoint खोलें
- PPTX खोलें
- PPT खोलें
- ODP खोलें
- प्रस्तुति लोड करें
- बफ़र से प्रस्तुति
- स्लाइड गिनती
- प्रस्तुति रूपांतरित करें
- PowerPoint
- OpenDocument
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via .NET के साथ JavaScript में PPTX, PPT और ODP प्रस्तुतियों को खोलें: फ़ाइल पथ या बफ़र से लोड करें, स्लाइड गिनती पढ़ें, और किसी अन्य फ़ॉर्मेट में सहेजें।"
---
## **अवलोकन**

Aspose.Slides for Node.js via .NET PowerPoint और OpenDocument प्रस्तुतियों को खोलता है, जैसे PPTX, PPT, और ODP फ़ाइलें, फ़ाइल पथ से या Node.js `Buffer` से। यह लेख दोनों तरीकों को दिखाता है, स्लाइडों की संख्या पढ़ता है, और खोली गई प्रस्तुति को किसी अन्य फ़ॉर्मेट में सहेजता है।

उदाहरणों को एक प्रस्तुति की आवश्यकता है जिसका नाम `sample.pptx` हो, जो आपके प्रोजेक्ट फ़ोल्डर में हो जिसे आपने [स्थापना](/slides/hi/nodejs-net/installation/) में सेट किया है। कोई भी PowerPoint प्रस्तुति चलेगी। प्रत्येक उदाहरण को प्रोजेक्ट फ़ोल्डर में `.js` फ़ाइल के रूप में सहेजें और `node` के साथ उसी फ़ोल्डर से चलाएँ।

{{% alert color="info" title="Note" %}}
Aspose.Slides for Node.js via .NET की अपनी कोई API संदर्भ नहीं है। यह Aspose.Slides for .NET API को camelCase नामों के साथ प्रतिबिंबित करता है, इसलिए इस लेख में API लिंक संबंधित वर्गों और सदस्यों की ओर ले जाते हैं जो [Aspose.Slides for .NET API reference](https://reference.aspose.com/slides/net/) में हैं।
{{% /alert %}}

## **फ़ाइल से प्रस्तुति खोलें**

प्रस्तुति खोलने के लिए, उसके पथ को [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/presentation/) कंस्ट्रक्टर को पास करें। Aspose.Slides फ़ाइल सामग्री से फ़ॉर्मेट निर्धारित करता है, न कि एक्सटेंशन से, इसलिए वही कोड PPTX, PPT, और ODP फ़ाइलें खोलता है। एक सापेक्ष पथ वर्तमान कार्य निर्देशिका के मुकाबले हल किया जाता है, जो स्क्रिप्ट चलाने पर प्रोजेक्ट फ़ोल्डर होता है।

```javascript
const { Presentation } = require("aspose.slides.via.net");

const presentation = new Presentation("sample.pptx");
try {
    console.log("Slide count: " + presentation.slides.count);
} finally {
    presentation.dispose();
}
```

स्क्रिप्ट `sample.pptx` में स्लाइडों की संख्या प्रदर्शित करती है, उदाहरण के लिए `Slide count: 9`। [slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/slides/) संग्रह की `count` प्रॉपर्टी में छिपी स्लाइडें भी शामिल होती हैं। जैसा कि दिखाया गया है, `dispose` को `finally` ब्लॉक में कॉल करें, ताकि प्रस्तुति के पीछे के .NET संसाधन आपके कोड के असफल होने पर भी मुक्त हो जाएँ।

## **बफ़र से प्रस्तुति खोलें**

जब प्रस्तुति डेटाबेस, HTTP अपलोड, या किसी अन्य स्रोत से आती है जो फ़ाइल पथ के बजाय बाइट्स देती है, तो दूसरे कंस्ट्रक्टर तर्क के रूप में Node.js `Buffer` पास करें और पहला तर्क `null` रखें। नीचे दिया गया उदाहरण `sample.pptx` को बफ़र में पढ़ता है ताकि ऐसे स्रोत का अनुकरण किया जा सके:

```javascript
const fs = require("fs");
const { Presentation } = require("aspose.slides.via.net");

const presentationData = fs.readFileSync("sample.pptx");

const presentation = new Presentation(null, presentationData);
try {
    console.log("Slide count: " + presentation.slides.count);
} finally {
    presentation.dispose();
}
```

स्क्रिप्ट पिछले उदाहरण के समान स्लाइड गिनती प्रदर्शित करती है। दूसरा तर्क एक `Buffer` होना चाहिए। किसी अन्य प्रकार, जैसे `Uint8Array`, के लिए कंस्ट्रक्टर त्रुटि नहीं देता; बल्कि यह एक खाली स्लाइड के साथ नई प्रस्तुति बनाता है। अन्य बाइनरी प्रकारों को पहले `Buffer.from` से बदलें।

## **प्रस्तुति को किसी अन्य फ़ॉर्मेट में सहेजें**

प्रस्तुति को किसी अन्य फ़ॉर्मेट में बदलने के लिए, उसे खोलें और अलग [SaveFormat](https://reference.aspose.com/slides/net/aspose.slides.export/saveformat/) मान के साथ सहेजें। नीचे दिया गया उदाहरण वह फ़ॉर्मेट प्रिंट करता है जिसे Aspose.Slides ने पहचाना, जो [sourceFormat](https://reference.aspose.com/slides/net/aspose.slides/presentation/sourceformat/) प्रॉपर्टी लौटाती है, और प्रस्तुति को OpenDocument प्रस्तुति के रूप में सहेजता है:

```javascript
const { Presentation, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation("sample.pptx");
try {
    console.log("Source format: " + presentation.sourceFormat);
    presentation.save("sample.odp", SaveFormat.Odp);
} finally {
    presentation.dispose();
}
```

स्क्रिप्ट `Source format: Pptx` प्रदर्शित करती है और `sample.odp` लिखती है, जिसमें वही स्लाइडें होती हैं। `sourceFormat` `Ppt`, `Pptx`, या `Odp` लौटाता है। PDF या छवियों के रूप में सहेजने के लिए, देखें [Convert PowerPoint to PDF](/slides/hi/nodejs-net/convert-powerpoint-to-pdf/) और [Convert Slides to Images](/slides/hi/nodejs-net/convert-slide/)।

## **FAQ**

**पासवर्ड‑संरक्षित प्रस्तुति को कैसे खोलूँ?**

एक [LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/) ऑब्जेक्ट बनाएँ, उसकी [password](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/password/) प्रॉपर्टी सेट करें, और उस ऑब्जेक्ट को तीसरे कंस्ट्रक्टर तर्क के रूप में पास करें: `new Presentation("protected.pptx", null, loadOptions)`। सही पासवर्ड के बिना, कंस्ट्रक्टर त्रुटि फेंकेगा।

**कंस्ट्रक्टर खाली संदेश के साथ `Error` क्यों फेंकता है?**

जब .NET में `Presentation` कंस्ट्रक्टर विफल होता है, उदाहरण के लिए फ़ाइल गायब होने, प्रस्तुति न होने, या अलग पासवर्ड की आवश्यकता होने के कारण, JavaScript को एक `Error` मिलता है जिसका संदेश खाली होता है। फ़ाइल खोलने से पहले, `fs.existsSync` जैसी विधि से जांचें कि वह कार्य निर्देशिका के सापेक्ष मौजूद है या नहीं।

**मैं कौन‑से फ़ॉर्मेट खोल सकता हूँ?**

PowerPoint और OpenDocument प्रस्तुति फ़ॉर्मेट, जिसमें PPT, PPTX, PPS, POT, POTX, PPTM, ODP, OTP, और FODP शामिल हैं।