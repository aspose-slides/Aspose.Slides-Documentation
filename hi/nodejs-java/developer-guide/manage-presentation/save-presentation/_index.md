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
- पूर्वनिर्धारित दृश्य प्रकार
- स्ट्रिक्ट ऑफिस ओपन XML फ़ॉर्मेट
- Zip64 मोड
- थंबनेल रीफ़्रेश करना
- सेव प्रगति
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js का उपयोग करके जावास्क्रिप्ट में प्रस्तुतियों को कैसे सहेजें, यह खोजें—PowerPoint या OpenDocument में निर्यात करते समय लेआउट, फ़ॉन्ट और प्रभाव बनाए रखें।"
---
## **समीक्षा**

[Open Presentations in JavaScript](/slides/hi/nodejs-java/open-presentation/) ने बताया कि कैसे [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) क्लास का उपयोग करके प्रस्तुति खोली जाती है। यह लेख बताता है कि प्रस्तुतियों को कैसे बनाया और सहेजा जाता है। [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) क्लास में प्रस्तुति की सामग्री होती है। चाहे आप नई प्रस्तुति बना रहे हों या मौजूदा को संशोधित कर रहे हों, आप काम समाप्त करने पर इसे सहेजना चाहेंगे। Aspose.Slides for Node.js के साथ आप **फ़ाइल** या **स्ट्रीम** में सहेज सकते हैं। यह लेख प्रस्तुतियों को सहेजने के विभिन्न तरीकों को समझाता है।

## **फ़ाइलों में प्रस्तुतियों को सहेजें**

[Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) क्लास के `save` मेथड को कॉल करके प्रस्तुति को फ़ाइल में सहेजें। इस मेथड को फ़ाइल का नाम और सहेजने का फ़ॉर्मेट पास करें। नीचे का उदाहरण दिखाता है कि Aspose.Slides के साथ प्रस्तुति को कैसे सहेजा जाता है।

```js
// Presentation क्लास को इंस्टैंशिएट करें जो एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है।
let presentation = new aspose.slides.Presentation();
try {
    // यहाँ कुछ काम करें...
    
    // प्रस्तुति को फ़ाइल में सहेजें।
    presentation.save("Output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **स्ट्रीम में प्रस्तुतियों को सहेजें**

आप आउटपुट स्ट्रीम को पास करके [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) क्लास के `save` मेथड से प्रस्तुति को स्ट्रीम में सहेज सकते हैं। प्रस्तुति को कई प्रकार की स्ट्रीम में लिखा जा सकता है। नीचे के उदाहरण में हम नई प्रस्तुति बनाते हैं और उसे फ़ाइल स्ट्रीम में सहेजते हैं।

```js
// Presentation क्लास को इंस्टैंशिएट करें जो एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है।
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

## **पूर्वनिर्धारित दृश्य प्रकार के साथ प्रस्तुतियों को सहेजें**

Aspose.Slides आपको उस प्रारंभिक दृश्य को सेट करने देता है जिसे PowerPoint उत्पन्न प्रस्तुति खोलते समय उपयोग करता है, यह [ViewProperties](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/viewproperties/) क्लास के माध्यम से किया जाता है। [setLastView](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/viewproperties/#setLastView) मेथड को [ViewType](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/viewtype/) एन्यूमरेशन में से किसी मान के साथ उपयोग करें।

```js
let presentation = new aspose.slides.Presentation();
try {
    presentation.getViewProperties().setLastView(aspose.slides.ViewType.SlideMasterView);
    presentation.save("SlideMasterView.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Strict Office Open XML फ़ॉर्मेट में प्रस्तुतियों को सहेजें**

Aspose.Slides आपको Strict Office Open XML फ़ॉर्मेट में प्रस्तुति सहेजने की अनुमति देता है। इसे करने के लिये [PptxOptions](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/pptxoptions/) क्लास का उपयोग करें और सहेजते समय उसकी conformance प्रॉपर्टी सेट करें। यदि आप [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/conformance/#Iso29500_2008_Strict) सेट करते हैं, तो आउटपुट फ़ाइल Strict Office Open XML फ़ॉर्मेट में सहेजी जाएगी।

नीचे का उदाहरण एक प्रस्तुति बनाता है और उसे Strict Office Open XML फ़ॉर्मेट में सहेजता है।

```js
let options = new aspose.slides.PptxOptions();
options.setConformance(aspose.slides.Conformance.Iso29500_2008_Strict);

// Presentation क्लास को इंस्टैंशिएट करें जो एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है।
let presentation = new aspose.slides.Presentation();
try {
    // प्रस्तुति को स्ट्रिक्ट ऑफिस ओपन XML फ़ॉर्मेट में सहेजें।
    presentation.save("StrictOfficeOpenXml.pptx", aspose.slides.SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **Zip64 मोड में Office Open XML फ़ॉर्मेट में प्रस्तुतियों को सहेजें**

Office Open XML फ़ाइल एक ZIP संग्रह है जिसमें अनकंप्रेस्ड फ़ाइल के आकार (4 GB), संकुचित फ़ाइल के आकार, और संग्रह के कुल आकार पर 4 GB की सीमा और अधिकतम 65 535 फ़ाइलों की सीमा होती है। ZIP64 फ़ॉर्मेट विस्तार इन सीमाओं को 2^64 तक बढ़ा देता है।

[PptxOptions.setZip64Mode](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/pptxoptions/#getZip64Mode) मेथड आपको Office Open XML फ़ाइल सहेजब समय ZIP64 फ़ॉर्मेट विस्तार का प्रयोग कब करना है, यह चुनने देता है।

यह मेथड निम्नलिखित मोड्स के साथ उपयोग किया जा सकता है:

- [IfNecessary](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/zip64mode/#IfNecessary) केवल तब ZIP64 फ़ॉर्मेट विस्तार का उपयोग करता है जब प्रस्तुति ऊपर दी गई सीमाओं से अधिक हो। यह डिफ़ॉल्ट मोड है।
- [Never](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/zip64mode/#Never) कभी भी ZIP64 फ़ॉर्मेट विस्तार का उपयोग नहीं करता।
- [Always](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/zip64mode/#Always) हमेशा ZIP64 फ़ॉर्मेट विस्तार का उपयोग करता है।

नीचे का कोड दिखाता है कि ZIP64 फ़ॉर्मेट विस्तार सक्षम करके PPTX के रूप में प्रस्तुति कैसे सहेजी जाए:

```js
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
जब आप [Zip64Mode.Never](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/zip64mode/#Never) के साथ सहेजते हैं, तो यदि प्रस्तुति को ZIP32 फ़ॉर्मेट में सहेजा नहीं जा सकता है तो एक [PptxException](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/pptxexception/) फेंका जाता है।
{{% /alert %}}

## **थंबनेल को रीफ़्रेश किए बिना प्रस्तुतियों को सहेजें**

[PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/pptxoptions/#setRefreshThumbnail) मेथड PPTX में प्रस्तुति सहेजते समय थंबनेल जेनरेशन को नियंत्रित करता है:

- यदि `true` सेट किया गया है, तो सहेजने के दौरान थंबनेल रीफ़्रेश होता है। यह डिफ़ॉल्ट है।
- यदि `false` सेट किया गया है, तो वर्तमान थंबनेल बना रहता है। यदि प्रस्तुति में कोई थंबनेल नहीं है, तो कोई नया थंबनेल नहीं बनाया जाता।

नीचे के कोड में प्रस्तुति को थंबनेल को रीफ़्रेश किए बिना PPTX में सहेजा गया है।

```js
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
यह विकल्प PPTX फ़ॉर्मेट में प्रस्तुति को सहेजने के समय लगने वाले समय को घटाने में मदद करता है।
{{% /alert %}}

## **प्रगति अद्यतन को प्रतिशत में सहेजें**

सेव-प्रोग्रेस रिपोर्टिंग को [SaveOptions](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/saveoptions/) और उसके उपवर्गों पर [setProgressCallback](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/saveoptions/#setProgressCallback) मेथड के माध्यम से कॉन्फ़िगर किया जाता है। एक Java प्रॉक्सी प्रदान करें जो [IProgressCallback](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iprogresscallback/) इंटरफ़ेस को लागू करता हो; निर्यात के दौरान, कॉलबैक समय-समय पर प्रतिशत अद्यतन प्राप्त करता है।

निम्नलिखित कोड स्निपेट्स दिखाते हैं कि `IProgressCallback` कैसे उपयोग किया जाए।

```javascript
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
Aspose ने अपना स्वयं का API उपयोग करके एक [नि:शुल्क PowerPoint Splitter ऐप](https://products.aspose.app/slides/hi/splitter) विकसित किया है। यह ऐप चयनित स्लाइडों को नई PPTX या PPT फ़ाइलों के रूप में सहेजकर प्रस्तुति को कई फ़ाइलों में विभाजित करने की सुविधा देता है।
{{% /alert %}}

## **FAQ**

**क्या "फ़ास्ट सेव" (इन्क्रिमेंटल सेव) समर्थित है ताकि केवल परिवर्तन लिखे जाएँ?**

नहीं। सेव करने पर हर बार पूरी लक्ष्य फ़ाइल बनाई जाती है; इन्क्रिमेंटल "फ़ास्ट सेव" समर्थित नहीं है।

**क्या एक ही Presentation इंस्टेंस को कई थ्रेड्स से सेव करना थ्रेड‑सेफ़ है?**

नहीं। एक [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) इंस्टेंस [थ्रेड‑सेफ़ नहीं है](/slides/hi/nodejs-java/multithreading/); इसे एक ही थ्रेड से सेव करें।

**सेव करने पर हाइपरलिंक्स और बाहरी रूप से लिंक की गई फ़ाइलों का क्या होता है?**

[Hyperlinks](/slides/hi/nodejs-java/manage-hyperlinks/) संरक्षित रहते हैं। बाहरी लिंक की गई फ़ाइलें (उदा., रिलेटिव पाथ वाली वीडियो) स्वचालित रूप से कॉपी नहीं होतीं—सुनिश्चित करें कि संदर्भित पाथ्स उपलब्ध रहें।

**क्या मैं दस्तावेज़ मेटाडाटा (लेखक, शीर्षक, कंपनी, तिथि) सेट/सेव कर सकता हूँ?**

हाँ। मानक [डॉक्यूमेंट प्रॉपर्टीज़](/slides/hi/nodejs-java/presentation-properties/) समर्थित हैं और सेव करने पर फ़ाइल में लिखी जाएँगी।