---
title: जावास्क्रिप्ट में प्रस्तुतियों को सहेजें
linktitle: प्रस्तुति सहेजें
type: docs
weight: 80
url: /hi/nodejs-java/save-presentation/
keywords:
- PowerPoint सहेजें
- OpenDocument सहेजें
- प्रस्तुति सहेजें
- स्लाइड सहेजें
- PPT सहेजें
- PPTX सहेजें
- ODP सहेजें
- फ़ाइल में प्रस्तुति
- स्ट्रीम में प्रस्तुति
- पूर्वनिर्धारित व्यू टाइप
- स्ट्रिक्ट Office Open XML फ़ॉर्मेट
- Zip64 मोड
- थंबनेल रिफ्रेश कर रहा है
- सहेजने की प्रगति
- Node.js
- जावास्क्रिप्ट
- Aspose.Slides
description: "Aspose.Slides for Node.js का उपयोग करके जावास्क्रिप्ट में प्रस्तुतियों को सहेजने के तरीके की खोज करें—PowerPoint या OpenDocument में निर्यात करते समय लेआउट, फ़ॉन्ट और इफ़ेक्ट्स को बनाए रखें।"
---
## **अवलोकन**

[जावास्क्रिप्ट में प्रस्तुतियों को खोलें](/slides/hi/nodejs-java/open-presentation/) में बताया गया है कि प्रस्तुति खोलने के लिए [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) क्लास का उपयोग कैसे किया जाता है। यह लेख बताता है कि प्रस्तुतियों को कैसे बनाया और सहेजा जाए। [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) क्लास में प्रस्तुति की सामग्री होती है। चाहे आप नई प्रस्तुति बना रहे हों या मौजूदा को संशोधित कर रहे हों, समाप्त होने पर उसे सहेजना आवश्यक है। Aspose.Slides for Node.js के साथ आप **फ़ाइल** या **स्ट्रीम** में सहेज सकते हैं। यह लेख प्रस्तुति को सहेजने के विभिन्न तरीकों को समझाता है।

## **फ़ाइलों में प्रस्तुतियों को सहेजें**

`save` मेथड को कॉल करके प्रस्तुति को फ़ाइल में सहेजा जा सकता है। इस मेथड में फ़ाइल नाम और सहेजने का फ़ॉर्मेट पास करें। नीचे दिया गया उदाहरण Aspose.Slides के साथ प्रस्तुति को सहेजने का तरीका दिखाता है।

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation वर्ग को instantiate करें।
let presentation = new aspose.slides.Presentation();
try {
    // यहाँ कुछ कार्य करें...

    // प्रस्तुति को फ़ाइल में सहेजें।
    presentation.save("Output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **स्ट्रीम में प्रस्तुतियों को सहेजें**

`save` मेथड में आउटपुट स्ट्रीम पास करके प्रस्तुति को स्ट्रीम में सहेजा जा सकता है। प्रस्तुति को कई प्रकार की स्ट्रीम में लिखा जा सकता है। नीचे के उदाहरण में हम नई प्रस्तुति बनाते हैं और उसे फ़ाइल स्ट्रीम में सहेजते हैं।

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Presentation फ़ाइल का प्रतिनिधित्व करने वाला वर्ग instantiate करें।
let presentation = new aspose.slides.Presentation();
try {
    let fileStream = java.newInstanceSync("java.io.FileOutputStream", "Output.pptx");
    try {
        // प्रस्तुति को स्ट्रीम में सहेजें।
        presentation.save(fileStream, aspose.slides.SaveFormat.Pptx);
    } finally {
        fileStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **पूर्वनिर्धारित व्यू टाइप के साथ प्रस्तुतियों को सहेजें**

Aspose.Slides आपको `ViewProperties` क्लास के माध्यम से उस प्रारम्भिक व्यू को सेट करने देता है जो PowerPoint उत्पन्न की गई प्रस्तुति खोलते समय उपयोग करता है। `ViewType` एनेमरेशन से मान के साथ `setLastView` मेथड का उपयोग करें।

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    presentation.getViewProperties().setLastView(aspose.slides.ViewType.SlideMasterView);
    presentation.save("SlideMasterView.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **स्ट्रिक्ट Office Open XML फ़ॉर्मेट में प्रस्तुतियों को सहेजें**

Aspose.Slides आपको प्रस्तुति को स्ट्रिक्ट Office Open XML फ़ॉर्मेट में सहेजने देता है। `PptxOptions` क्लास का उपयोग करके सहेजते समय उसकी `conformance` प्रॉपर्टी सेट करें। यदि आप `Conformance.Iso29500_2008_Strict` सेट करते हैं, तो आउटपुट फ़ाइल स्ट्रिक्ट Office Open XML फ़ॉर्मेट में सहेजी जाती है।

नीचे का उदाहरण प्रस्तुति बनाता है और उसे स्ट्रिक्ट Office Open XML फ़ॉर्मेट में सहेजता है।

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let options = new aspose.slides.PptxOptions();
options.setConformance(aspose.slides.Conformance.Iso29500_2008_Strict);

// Presentation फ़ाइल का प्रतिनिधित्व करने वाले वर्ग को instantiate करें।
let presentation = new aspose.slides.Presentation();
try {
    // प्रस्तुति को स्ट्रिक्ट Office Open XML फ़ॉर्मेट में सहेजें।
    presentation.save("StrictOfficeOpenXml.pptx", aspose.slides.SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **ZIP64 मोड में Office Open XML फ़ॉर्मेट में प्रस्तुतियों को सहेजें**

Office Open XML फ़ाइल एक ZIP अभिलेख है जो किसी भी फ़ाइल के अनकम्प्रेस्ड आकार, कम्प्रेस्ड आकार और कुल आकार पर 4 GB (2^32 बाइट) की सीमा लगाता है, तथा अभिलेख में अधिकतम 65 535 (2^16‑1) फ़ाइलों तक सीमित करता है। ZIP64 फ़ॉर्मेट एक्सटेंशन इन सीमाओं को 2^64 तक बढ़ाते हैं।

`PptxOptions.setZip64Mode` मेथड आपको Office Open XML फ़ाइल सहेजते समय ZIP64 एक्सटेंशन का प्रयोग कब करना है, चुनने देता है।

यह मेथड निम्नलिखित मोड में उपयोग किया जा सकता है:

- `IfNecessary` केवल तभी ZIP64 फ़ॉर्मेट एक्सटेंशन का उपयोग करता है जब प्रस्तुति ऊपर दी गई सीमाओं से अधिक हो। यह डिफ़ॉल्ट मोड है।
- `Never` कभी भी ZIP64 फ़ॉर्मेट एक्सटेंशन का प्रयोग नहीं करता।
- `Always` हमेशा ZIP64 फ़ॉर्मेट एक्सटेंशन का प्रयोग करता है।

नीचे दिया गया कोड ZIP64 फ़ॉर्मेट एक्सटेंशन सक्षम करके PPTX फ़ाइल के रूप में प्रस्तुति सहेजने का तरीका दर्शाता है:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let pptxOptions = new aspose.slides.PptxOptions();
pptxOptions.setZip64Mode(aspose.slides.Zip64Mode.Always);

let presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    presentation.save("OutputZip64.pptx", aspose.slides.SaveFormat.Pptx, pptxOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="NOTE" color="warning" %}}
जब आप `Zip64Mode.Never` के साथ सहेजते हैं, तो यदि प्रस्तुति को ZIP32 फ़ॉर्मेट में नहीं सहेजा जा सकता, तो एक `PptxException` फेंका जाता है।
{{% /alert %}}

## **कम्प्रेशन लेवल के साथ Office Open XML फ़ॉर्मेट में प्रस्तुतियों को सहेजें**

बड़ी प्रस्तुतियों के साथ काम करते समय आप फ़ाइल आकार और प्रोसेसिंग समय के संतुलन के लिए कम्प्रेशन लेवल समायोजित कर सकते हैं। आपकी आवश्यकताओं के आधार पर आप तेज प्रोसेसिंग या छोटी आउटपुट फ़ाइलों को प्राथमिकता दे सकते हैं।

Aspose.Slides `PptxOptions.setCompressionLevel` मेथड प्रदान करता है, जिससे आप Office Open XML फ़ॉर्मेट में प्रस्तुति सहेजते समय उपयोग होने वाला कम्प्रेशन लेवल निर्दिष्ट कर सकते हैं।

उपलब्ध कम्प्रेशन लेवल निम्नलिखित हैं:

- **None**: कोई कम्प्रेशन लागू नहीं होता। फ़ाइलें जैसा है वैसा संग्रहीत होती हैं।
- **Level1**: सबसे तेज़ कम्प्रेशन, सबसे कम कम्प्रेशन अनुपात के साथ।
- **Level2**: **Level1** की तुलना में थोड़ा बेहतर कम्प्रेशन अनुपात, तेज़ प्रोसेसिंग।
- **Level3**: **Level2** से बेहतर कम्प्रेशन, मध्यम प्रोसेसिंग समय पर प्रभाव।
- **Level4**: **Level3** से बेहतर कम्प्रेशन।
- **Level5**: **Level4** से बेहतर कम्प्रेशन, अतिरिक्त प्रोसेसिंग समय के साथ।
- **Level6**: मानक कम्प्रेशन जो प्रोसेसिंग गति और फ़ाइल आकार के बीच अच्छा संतुलन प्रदान करता है। यह *डिफ़ॉल्ट कम्प्रेशन लेवल* है।
- **Level7**: **Level6** से बेहतर कम्प्रेशन, धीमी प्रोसेसिंग।
- **Level8**: **Level7** से बेहतर कम्प्रेशन।
- **Level9**: अधिकतम कम्प्रेशन। सबसे छोटी फ़ाइल आकार देता है, पर सबसे लंबा प्रोसेसिंग समय लगता है।

नीचे दिया गया उदाहरण PPTX फ़ाइल को *बिना कम्प्रेशन* के सहेजने का तरीका दिखाता है:

```js
const aspose = { slides: require("aspose.slides.via.java") };

const pptxOptions = new aspose.slides.PptxOptions();
pptxOptions.setCompressionLevel(aspose.slides.CompressionLevel.None);

const presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    presentation.save("Sample-out.pptx", aspose.slides.SaveFormat.Pptx, pptxOptions);
} finally {
    presentation.dispose();
}
```

यह उदाहरण *अधिकतम कम्प्रेशन* के साथ PPTX फ़ाइल सहेजने का तरीका दर्शाता है:

```js
const aspose = { slides: require("aspose.slides.via.java") };

const pptxOptions = new aspose.slides.PptxOptions();
pptxOptions.setCompressionLevel(aspose.slides.CompressionLevel.Level9);

const presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    presentation.save("Sample-level9.pptx", aspose.slides.SaveFormat.Pptx, pptxOptions);
} finally {
    presentation.dispose();
}
```

## **थंबनेल को रिफ्रेश किए बिना प्रस्तुतियों को सहेजें**

`PptxOptions.setRefreshThumbnail` मेथड PPTX में प्रस्तुति सहेजते समय थंबनेल जेनरेशन को नियंत्रित करता है:

- यदि `true` सेट किया जाये, तो सहेजते समय थंबनेल रिफ्रेश होता है। यह डिफ़ॉल्ट है।
- यदि `false` सेट किया जाये, तो मौजूदा थंबनेल बरकरार रहता है। यदि प्रस्तुति में कोई थंबनेल नहीं है, तो कोई भी जेनरेट नहीं होता।

नीचे के कोड में प्रस्तुति को थंबनेल रिफ्रेश किए बिना PPTX में सहेजा गया है।

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let pptxOptions = new aspose.slides.PptxOptions();
pptxOptions.setRefreshThumbnail(false);

let presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    presentation.save("Output.pptx", aspose.slides.SaveFormat.Pptx, pptxOptions);
}
finally {
    presentation.dispose();
}
```

{{% alert title="Info" color="info" %}}
यह विकल्प PPTX फ़ॉर्मेट में प्रस्तुति सहेजने में लगने वाले समय को कम करने में मदद करता है।
{{% /alert %}}

## **प्रगति अपडेट को प्रतिशत में सहेजें**

`SaveOptions` और उसकी सबक्लासेज़ पर `setProgressCallback` मेथड के माध्यम से सहेजने की प्रगति रिपोर्टिंग को कॉन्फ़िगर किया जाता है। एक Java प्रॉक्सी प्रदान करें जो `IProgressCallback` इंटरफ़ेस को इम्प्लीमेंट करे; निर्यात के दौरान, कॉलबैक को आवधिक प्रतिशत अपडेट मिलते हैं।

नीचे `IProgressCallback` का उपयोग करने का कोड स्निपेट दिया गया है:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const ExportProgressHandler = java.newProxy("com.aspose.slides.IProgressCallback", {
    reporting: function(progressValue) {
        // यहाँ प्रगति प्रतिशत मान का उपयोग करें।
        const progress = Math.floor(progressValue);
        console.log(`${progress}% of the file has been converted.`);
    }
});

let saveOptions = new aspose.slides.PdfOptions();
saveOptions.setProgressCallback(ExportProgressHandler);

let presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    presentation.save("Output.pdf", aspose.slides.SaveFormat.Pdf, saveOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="Info" color="info" %}}
Aspose ने अपने API का उपयोग करके एक **नि:शुल्क PowerPoint Splitter** ऐप विकसित किया है। यह ऐप चयनित स्लाइड्स को नई PPTX या PPT फ़ाइलों के रूप में सहेजकर प्रस्तुति को कई फ़ाइलों में विभाजित करता है।
{{% /alert %}}

## **FAQ**

**क्या "फास्ट सेव" (इंक्रीमेंटल सेव) समर्थित है जिससे केवल परिवर्तन ही लिखे जाएँ?**

नहीं। सहेजना हर बार पूर्ण लक्षित फ़ाइल बनाता है; इंक्रीमेंटल "फास्ट सेव" समर्थित नहीं है।

**क्या कई थ्रेड्स से एक ही Presentation इंस्टेंस को सहेजना थ्रेड‑सेफ़ है?**

नहीं। एक `Presentation` इंस्टेंस थ्रेड‑सेफ़ नहीं है; इसे एक ही थ्रेड से सहेजें।

**सहेजते समय हाइपरलिंक और बाहरी लिंक वाली फ़ाइलें क्या होती हैं?**

`Hyperlinks` संरक्षित रहती हैं। बाहरी लिंक वाली फ़ाइलें (जैसे सापेक्ष पथ के साथ वीडियो) स्वचालित रूप से कॉपी नहीं होतीं—सुनिश्चित करें कि संदर्भित पथ उपलब्ध रहें।

**क्या मैं दस्तावेज़ मेटाडेटा (लेखक, शीर्षक, कंपनी, तिथि) सेट/सहेज सकता हूँ?**

हाँ। मानक `document properties` समर्थित हैं और सहेजते समय फ़ाइल में लिखे जाते हैं।