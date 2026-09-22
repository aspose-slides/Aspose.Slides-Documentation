---
title: जावास्क्रिप्ट में प्रेजेंटेशन सहेजें
linktitle: प्रेजेंटेशन सहेजें
type: docs
weight: 80
url: /hi/nodejs-java/save-presentation/
keywords:
- PowerPoint सहेजें
- OpenDocument सहेजें
- प्रेजेंटेशन सहेजें
- स्लाइड सहेजें
- PPT सहेजें
- PPTX सहेजें
- ODP सहेजें
- फ़ाइल में प्रेजेंटेशन
- स्ट्रीम में प्रेजेंटेशन
- पूर्वनिर्धारित व्यू टाइप
- स्ट्रिक्ट ऑफिस ओपन XML फ़ॉर्मेट
- Zip64 मोड
- थंबनैल रिफ्रेश करना
- सहेजने की प्रगति
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides के साथ जावास्क्रिप्ट में PowerPoint और OpenDocument प्रेजेंटेशन को फ़ाइलों या स्ट्रीम में सहेजें, और PPTX आउटपुट व प्रगति रिपोर्टिंग को कॉन्फ़िगर करें।"
---
## **सारांश**

प्रेजेंटेशन बनाने के बाद या [एक मौजूदा खोलें](/slides/hi/nodejs-java/open-presentation/), परिणाम लिखने के लिए [Presentation.save](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/#save) मेथड का उपयोग करें। Aspose.Slides for Node.js via Java प्रेजेंटेशन को PowerPoint, OpenDocument, PDF और अन्य फ़ॉर्मैट्स में फ़ाइल या स्ट्रीम में सहेज सकता है। निम्नलिखित अनुभाग मानक सहेजने के संचालन और PPTX आउटपुट के लिए उपलब्ध विकल्पों को कवर करते हैं।

## **फ़ाइलों में प्रेजेंटेशन सहेजें**

फ़ाइल में प्रेजेंटेशन सहेजने के लिए, आउटपुट पथ और एक [SaveFormat](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/saveformat/) मान को [Presentation.save](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/#save) मेथड में पास करें। फ़ॉर्मेट मान निर्धारित करता है कि Aspose.Slides किस प्रकार की फ़ाइल बनाएगा।

निम्नलिखित उदाहरण एक प्रेजेंटेशन बनाता है और उसे PPTX फ़ाइल के रूप में सहेजता है:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    // यहाँ प्रेजेंटेशन सामग्री जोड़ें या संशोधित करें।

    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **अपनी मूल फ़ॉर्मेट में प्रेजेंटेशन सहेजें**

फ़ाइल और स्ट्रीम डिटेक्शन उदाहरणों, नए बनाए गए प्रेजेंटेशन के व्यवहार, और स्रोत एवं आउटपुट फ़ॉर्मेट के बीच अंतर के लिए देखें [मूल प्रेजेंटेशन फ़ॉर्मेट निर्धारित करें](/slides/hi/nodejs-java/detect-presentation-source-format/)।

बैच-प्रोसेसिंग एप्लिकेशन में इनपुट फ़ॉर्मेट पहले से ज्ञात नहीं हो सकता। फ़ाइल लोड करने के बाद, उसके मूल फ़ॉर्मेट को [Presentation.getSourceFormat](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/#getSourceFormat) मेथड से पढ़ें। प्राप्त [SourceFormat](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/sourceformat/) मान को [SlideUtil.toSaveFormat](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/slideutil/#toSaveFormat) में पास करके संबंधित [SaveFormat](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/saveformat/) मान प्राप्त करें, और फिर संशोधित प्रेजेंटेशन लिखने के लिए [Presentation.save](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/#save) का उपयोग करें।

निम्नलिखित पूर्ण उदाहरण इनपुट डायरेक्टरी में प्रत्येक फ़ाइल को प्रोसेस करता है, उसका शीर्षक अपडेट करता है, और उसे लोड किए गए फ़ॉर्मेट में आउटपुट डायरेक्टरी में सहेजता है:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const fs = require("fs");
const path = require("path");

const inputDirectory = "Input";
const outputDirectory = "Output";

if (!fs.existsSync(inputDirectory)) {
    console.error("The input directory does not exist.");
} else {
    fs.mkdirSync(outputDirectory, { recursive: true });

    const inputFiles = fs.readdirSync(inputDirectory, { withFileTypes: true })
        .filter((entry) => entry.isFile());

    for (const inputFile of inputFiles) {
        const inputPath = path.join(inputDirectory, inputFile.name);
        try {
            const presentation = new aspose.slides.Presentation(inputPath);
            try {
                const saveFormat = aspose.slides.SlideUtil.toSaveFormat(presentation.getSourceFormat());
                presentation.getDocumentProperties().setTitle("Processed by the batch application");

                const outputPath = path.join(outputDirectory, inputFile.name);
                presentation.save(outputPath, saveFormat);
            } finally {
                presentation.dispose();
            }
        } catch (error) {
            console.error(`Cannot process '${inputPath}': ${error.message}`);
        }
    }
}
```

[SlideUtil.toSaveFormat](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/slideutil/#toSaveFormat) PPT, PPTX, ODP, PPTM, PPSX, PPSM, POTX, POTM, PPS, POT, OTP, FODP और PowerPoint XML को उनके संबंधित प्रेजेंटेशन सहेजने के फ़ॉर्मेट्स से मिलाता है। यह केवल प्रेजेंटेशन स्रोत फ़ॉर्मेट्स को मैप करता है; PDF, HTML, TIFF या इमेजेज जैसे एक्सपोर्ट फ़ॉर्मेट्स का चयन करने के लिए नहीं है। असमर्थित या अमान्य [SourceFormat](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/sourceformat/) मान पास करने पर त्रुटि उत्पन्न होती है।

लीगेसी PPT, PPS और POT फ़ाइलें समान बाइनरी कंटेनर का उपयोग करती हैं। जब ऐसी प्रेजेंटेशन को फ़ाइल एक्सटेंशन के बिना स्ट्रीम से लोड किया जाता है, तो PPS या POT फ़ाइल को PPT के रूप में पहचाना जा सकता है। यदि इन लिगेसी उपप्रकारों को संरक्षित रखना आवश्यक है, तो मूल फ़ाइलनाम या फ़ॉर्मेट मेटाडाटा को अलग से रखें और आउटपुट फ़ाइलनाम व फ़ॉर्मेट चुनते समय उसका उपयोग करें।

## **स्ट्रीम में प्रेजेंटेशन सहेजें**

फ़ाइल पथ पर निर्भर हुए बिना प्रेजेंटेशन लिखने के लिए, एक राइटेबल स्ट्रीम और एक [SaveFormat](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/saveformat/) मान को [Presentation.save](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/#save) मेथड में पास करें। यह तरीका तब उपयोगी होता है जब आउटपुट को वेब सर्विस से लौटाना, डेटाबेस में संग्रहीत करना या मेमोरी में प्रोसेस करना हो।

निम्नलिखित उदाहरण एक नई प्रेजेंटेशन को फ़ाइल स्ट्रीम में सहेजता है:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const outputStream = java.newInstanceSync("java.io.FileOutputStream", "output.pptx");
    try {
        presentation.save(outputStream, aspose.slides.SaveFormat.Pptx);
    } finally {
        outputStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **पूर्वनिर्धारित व्यू टाइप के साथ प्रेजेंटेशन सहेजें**

आप सहेजे गए प्रेजेंटेशन को PowerPoint द्वारा प्रारम्भिक रूप से खोलने वाले व्यू को निर्दिष्ट कर सकते हैं। सहेजने से पहले [ViewProperties.setLastView](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/viewproperties/#setLastView) मेथड को एक [ViewType](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/viewtype/) मान के साथ उपयोग करें।

निम्नलिखित उदाहरण स्लाइड मास्टर व्यू को प्रारम्भिक व्यू के रूप में कॉन्फ़िगर करता है:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    presentation.getViewProperties().setLastView(aspose.slides.ViewType.SlideMasterView);
    presentation.save("slide-master-view.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **स्ट्रिक्ट ऑफिस ओपन XML फ़ॉर्मेट में प्रेजेंटेशन सहेजें**

Strict प्रोफ़ाइल के Office Open XML के अनुरूप PPTX फ़ाइल बनाने के लिए, एक [PptxOptions](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/pptxoptions/) इंस्टेंस बनाएं और उसके [setConformance](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/pptxoptions/#setConformance) मेथड को [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/conformance/#Iso29500_2008_Strict) के साथ उपयोग करें। फिर विकल्प को [Presentation.save](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/#save) मेथड में पास करें।

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const options = new aspose.slides.PptxOptions();
options.setConformance(aspose.slides.Conformance.Iso29500_2008_Strict);

const presentation = new aspose.slides.Presentation();
try {
    presentation.save("strict-office-open-xml.pptx", aspose.slides.SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **Office Open XML फ़ॉर्मेट को Zip64 मोड में सहेजें**

एक मानक ZIP आर्काइव प्रत्येक एंट्री के संपीड़ित एवं अनसंकुचित आकार, कुल आर्काइव आकार और एंट्री की संख्या को सीमित करता है। चूँकि PPTX फ़ाइल एक ZIP आर्काइव है, बहुत बड़ी प्रेजेंटेशन इन सीमाओं को पार कर सकती है। ZIP64 एक्सटेंशन इन आकार और एंट्री‑काउंट सीमाओं को बढ़ाते हैं।

[PptxOptions.setZip64Mode](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/pptxoptions/#setZip64Mode) मेथड का उपयोग करके आप निर्धारित कर सकते हैं कि Aspose.Slides ZIP64 एक्सटेंशन लिखे या नहीं:

- [IfNecessary](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/zip64mode/#IfNecessary) केवल तब ZIP64 का उपयोग करता है जब प्रेजेंटेशन मानक ZIP सीमाओं से अधिक हो। यह डिफ़ॉल्ट मोड है।
- [Never](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/zip64mode/#Never) ZIP64 एक्सटेंशन को निष्क्रिय करता है।
- [Always](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/zip64mode/#Always) हमेशा ZIP64 एक्सटेंशन लिखता है।

निम्नलिखित उदाहरण आउटपुट प्रेजेंटेशन के लिए हमेशा ZIP64 एक्सटेंशन सक्षम करता है:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const options = new aspose.slides.PptxOptions();
    options.setZip64Mode(aspose.slides.Zip64Mode.Always);

    presentation.save("output-zip64.pptx", aspose.slides.SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

{{% alert color="warning" title="Warning" %}}
यदि [Zip64Mode.Never](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/zip64mode/#Never) का उपयोग किया जाता है और प्रेजेंटेशन मानक ZIP सीमाओं में नहीं फिट होता है, तो सहेजने का ऑपरेशन एक [PptxException](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/pptxexception/) फेंकेगा।
{{% /alert %}}

## **Office Open XML फ़ॉर्मेट को कॉम्प्रेशन लेवल्स के साथ सहेजें**

PPTX आउटपुट के लिए आप [PptxOptions.setCompressionLevel](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/pptxoptions/#setCompressionLevel) मेथड का उपयोग करके सहेजने की गति और फ़ाइल आकार के बीच संतुलन बना सकते हैं। [CompressionLevel](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/compressionlevel/) क्लास निम्नलिखित मान प्रदान करती है:

- [None](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/compressionlevel/#None) डेटा को बिना संपीड़न के संग्रहीत करता है।
- [Level1](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/compressionlevel/#Level1) सबसे तेज़ संपीड़न और सबसे बड़े संपीड़ित आउटपुट को देता है।
- [Level2](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/compressionlevel/#Level2) से [Level5](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/compressionlevel/#Level5) तक क्रमशः सहेजने की गति की तुलना में छोटे आउटपुट को अधिक प्राथमिकता देते हैं।
- [Level6](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/compressionlevel/#Level6) सहेजने की गति और फ़ाइल आकार के बीच संतुलन बनाता है। यह डिफ़ॉल्ट लेवल है।
- [Level7](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/compressionlevel/#Level7) और [Level8](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/compressionlevel/#Level8) छोटे आउटपुट को सहेजने की गति से अधिक प्राथमिकता देते हैं।
- [Level9](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/compressionlevel/#Level9) सबसे मजबूत संपीड़न देता है और सबसे अधिक प्रोसेसिंग समय लेता है।

निम्नलिखित उदाहरण संपीड़न के बिना प्रेजेंटेशन सहेजता है:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const options = new aspose.slides.PptxOptions();
    options.setCompressionLevel(aspose.slides.CompressionLevel.None);

    presentation.save("output-no-compression.pptx", aspose.slides.SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

निम्नलिखित उदाहरण अधिकतम संपीड़न लेवल का उपयोग करता है:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const options = new aspose.slides.PptxOptions();
    options.setCompressionLevel(aspose.slides.CompressionLevel.Level9);

    presentation.save("output-maximum-compression.pptx", aspose.slides.SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **थंबनैल को रिफ्रेश किए बिना प्रेजेंटेशन सहेजें**

जब प्रेजेंटेशन को PPTX के रूप में सहेजा जाता है, तो [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/pptxoptions/#setRefreshThumbnail) मेथड उसके डॉक्यूमेंट थंबनैल को नियंत्रित करता है:

- `true` सहेजने के दौरान थंबनैल को पुनः उत्पन्न करता है। यह डिफ़ॉल्ट मान है।
- `false` मौजूदा थंबनैल को संरक्षित रखता है। यदि प्रेजेंटेशन में थंबनैल नहीं है, तो Aspose.Slides एक नया थंबनैल नहीं बनाता।

निम्नलिखित उदाहरण थंबनैल को रिफ्रेश किए बिना प्रेजेंटेशन सहेजता है:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const options = new aspose.slides.PptxOptions();
    options.setRefreshThumbnail(false);

    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
थंबनैल रीफ़्रेश को निष्क्रिय करने से PPTX फ़ाइल को सहेजने में लगने वाला समय घट सकता है।
{{% /alert %}}

## **प्रति प्रतिशत में सहेजने की प्रगति अपडेट करें**

सहेजने के ऑपरेशन को मॉनिटर करने के लिए आप एक Java प्रॉक्सी के साथ [IProgressCallback](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iprogresscallback/) इंटरफ़ेस को इम्प्लीमेंट कर सकते हैं और इसे [SaveOptions.setProgressCallback](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/saveoptions/#setProgressCallback) मेथड को पास कर सकते हैं। Aspose.Slides तब निर्यात के दौरान प्रगति मानों के साथ [IProgressCallback.reporting](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iprogresscallback/#reporting-double-) मेथड को कॉल करता है।

निम्नलिखित उदाहरण PDF निर्यात की प्रगति को कंसोल पर रिपोर्ट करता है:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const exportProgressHandler = java.newProxy("com.aspose.slides.IProgressCallback", {
    reporting: function(progressValue) {
        const progress = Math.floor(progressValue);
        console.log(`${progress}% of the file has been converted.`);
    }
});

const options = new aspose.slides.PdfOptions();
options.setProgressCallback(exportProgressHandler);

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    presentation.save("output.pdf", aspose.slides.SaveFormat.Pdf, options);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Aspose एक मुफ्त [PowerPoint Splitter](https://products.aspose.app/slides/hi/splitter) प्रदान करता है जो Aspose.Slides API के साथ निर्मित है। यह प्रेजेंटेशन से चयनित स्लाइड्स को अलग-अलग PPT या PPTX फ़ाइलों के रूप में सहेजता है।
{{% /alert %}}

## **FAQ**

**क्या Aspose.Slides इन्क्रिमेंटल या “फास्ट सेव” का समर्थन करता है?**

नहीं। प्रत्येक सहेजने के ऑपरेशन में पूरी आउटपुट फ़ाइल लिखी जाती है, न कि केवल बदले हुए भागों को अपडेट किया जाता है।

**क्या कई थ्रेड्स एक ही Presentation इंस्टेंस को सहेज सकते हैं?**

नहीं। एक [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) इंस्टेंस **थ्रेड‑सेफ़ नहीं है** (/slides/hi/nodejs-java/multithreading/)। प्रत्येक इंस्टेंस तक केवल एक थ्रेड ही एक समय में पहुँच और सहेज सकता है।

**जब मैं प्रेजेंटेशन सहेजता हूँ तो हाइपरलिंक और बाहरी लिंक्ड फ़ाइलों के साथ क्या होता है?**

[Hyperlinks](/slides/hi/nodejs-java/manage-hyperlinks/) प्रेजेंटेशन में बने रहते हैं। Aspose.Slides बाहरी लिंक्ड फ़ाइलों को कॉपी नहीं करता, इसलिए सहेजा गया प्रेजेंटेशन फिर भी उनके स्थानों तक पहुँचने में सक्षम होना चाहिए।

**क्या मैं लेखक, शीर्षक, कंपनी और निर्माण तिथि जैसे डॉक्यूमेंट मेटाडाटा सहेज सकता हूँ?**

हां। सहेजने से पहले उपयुक्त [document properties](/slides/hi/nodejs-java/presentation-properties/) सेट करें, और Aspose.Slides उन्हें आउटपुट फ़ाइल में लिखेगा।