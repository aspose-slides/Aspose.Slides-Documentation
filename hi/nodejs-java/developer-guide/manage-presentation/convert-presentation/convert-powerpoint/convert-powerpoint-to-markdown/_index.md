---
title: JavaScript में PowerPoint प्रस्तुतियों को Markdown में बदलें
linktitle: PowerPoint से Markdown
type: docs
weight: 140
url: /hi/nodejs-java/convert-powerpoint-to-markdown/
keywords:
- PowerPoint परिवर्तित करें
- प्रस्तुति परिवर्तित करें
- स्लाइड परिवर्तित करें
- PPT परिवर्तित करें
- PPTX परिवर्तित करें
- PowerPoint से MD
- प्रस्तुति से MD
- स्लाइड से MD
- PPT से MD
- PPTX से MD
- PowerPoint को Markdown के रूप में सहेजें
- प्रस्तुति को Markdown के रूप में सहेजें
- स्लाइड को Markdown के रूप में सहेजें
- PPT को MD के रूप में सहेजें
- PPTX को MD के रूप में सहेजें
- PPT को MD में निर्यात करें
- PPTX को MD में निर्यात करें
- Markdown छवि निर्यात
- CDN छवि लिंक्स
- PowerPoint
- प्रस्तुति
- Markdown
- Node.js
- JavaScript
- Aspose.Slides
description: "JavaScript में PPT और PPTX प्रस्तुतियों को Markdown में बदलें और नियंत्रित करें कि निर्यातित bitmap, metafile और SVG छवियों को कहाँ सहेजा और संदर्भित किया जाए।"
---
## **सारांश**

Aspose.Slides for Node.js via Java PPT और PPTX प्रस्तुतियों को दस्तावेज़ीकरण, स्थिर‑साइट, सामग्री‑प्रवासन और संस्करण‑नियंत्रण वर्कफ़्लो के लिए Markdown में परिवर्तित कर सकता है। आप एक Markdown फ्लेवर चुन सकते हैं, स्लाइड सामग्री के रेंडरिंग को नियंत्रित कर सकते हैं, और यह तय कर सकते हैं कि निर्यातित छवियों को कहाँ संग्रहीत किया जाए और उत्पन्न Markdown उनके संदर्भ को कैसे देता है।

डिफ़ॉल्ट रूप से, Markdown निर्यात केवल पाठ‑आधारित आउटपुट का उपयोग करता है। दृश्य सामग्री निर्यात करने के लिए, निर्यात प्रकार को [MarkdownSaveOptions.setExportType](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/markdownsaveoptions/) मेथड के माध्यम से `Sequential` या `Visual` मान पर सेट करें, जो [MarkdownExportType](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/markdownexporttype/) एन्यूमरेशन से लिया गया है। `Sequential` स्लाइड आइटम को अलग‑अलग और क्रम में रेंडर करता है, जबकि `Visual` समूहित आइटम को एक साथ रखता है ताकि उनका दृश्य संबंध बना रहे। `TextOnly` मान छवि संसाधनों को उत्पन्न नहीं करता, इसलिए इस मोड में इमेज‑सेविंग कॉलबैक नहीं चलाए जाते।

## **प्रस्तुति को Markdown में परिवर्तित करें**

[Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) क्लास के साथ स्रोत फ़ाइल लोड करें, और फिर `Md` मान को [SaveFormat](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/saveformat/) एन्यूमरेशन से उपयोग करके [Presentation.save](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) मेथड को कॉल करें।

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.save("presentation.md", aspose.slides.SaveFormat.Md);
} finally {
    presentation.dispose();
}
```

## **Markdown फ्लेवर चुनें**

[MarkdownSaveOptions.setFlavor](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/markdownsaveoptions/) मेथड आउटपुट के लिए उपयोग किए जाने वाले Markdown विनिर्देशन को नियंत्रित करता है। [Flavor](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/flavor/) एन्यूमरेशन में CommonMark, GitHub Flavored Markdown और अन्य समर्थित वैरिएंट शामिल हैं।

निम्न उदाहरण CommonMark के रूप में प्रस्तुति को निर्यात करता है:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    var options = new aspose.slides.MarkdownSaveOptions();
    options.setFlavor(aspose.slides.Flavor.CommonMark);

    presentation.save("presentation.md", aspose.slides.SaveFormat.Md, options);
} finally {
    presentation.dispose();
}
```

## **डिफ़ॉल्ट स्थानीय‑सहेजने के व्यवहार का उपयोग करके छवियों को निर्यात करें**

[MarkdownSaveOptions](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/markdownsaveoptions/) क्लास दो मेथड प्रदान करता है जो स्थानीय रूप से सहेजी गई छवियों को कॉन्फ़िगर करते हैं:

- [setBasePath](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/markdownsaveoptions/) Markdown दस्तावेज़ और उसकी संसाधनों के लिए आधार निर्देशिका निर्दिष्ट करता है।
- [setImagesSaveFolderName](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/markdownsaveoptions/) छवि उप‑निर्देशिका निर्दिष्ट करता है। इसका डिफ़ॉल्ट मान `Images` है।

निम्न उदाहरण दृश्य सामग्री रेंडर करता है, छवियों को `output/assets` में लिखता है, और Markdown दस्तावेज़ में सापेक्ष छवि संदर्भ बनाता है:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");
const path = require("path");

const outputDirectory = "output";
fs.mkdirSync(outputDirectory, { recursive: true });

var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    var options = new aspose.slides.MarkdownSaveOptions();
    options.setExportType(aspose.slides.MarkdownExportType.Visual);
    options.setBasePath(outputDirectory);
    options.setImagesSaveFolderName("assets");

    const markdownPath = path.join(outputDirectory, "presentation.md");
    presentation.save(markdownPath, aspose.slides.SaveFormat.Md, options);
} finally {
    presentation.dispose();
}
```

यह व्यवहार तब फ़ॉलबैक के रूप में भी काम करता है जब कोई कस्टम इमेज‑सेविंग हैंडलर `false` लौटाता है।

## **छवि सहेजना और Markdown लिंक को अनुकूलित करें**

[MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/markdownsaveoptions/) मेथड का उपयोग करके आप एक कॉलबैक पंजीकृत कर सकते हैं जो Markdown निर्यात के दौरान उत्पन्न होने वाले गैर‑SVG बिटमैप और मेटाफाइल संसाधनों को संभालता है। इसका `MarkdownImageSavingHandler` कॉलबैक [IImage](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/iimage/) ऑब्जेक्ट, उसका [ImageFormat](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/imageformat/) मान, और उत्पन्न Markdown लिंक को एक‑तत्वीय स्ट्रिंग एरे के रूप में प्राप्त करता है। आप दिए गए फ़ॉर्मेट के साथ छवि सहेज या अपलोड कर सकते हैं, और `link[0]` को उस संदर्भ से बदल सकते हैं जो Markdown आउटपुट में दिखना चाहिए।

SVG फ़ॉर्मेट में उत्पन्न संसाधनों को अलग से संभाला जाता है। आप [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/markdownsaveoptions/) मेथड के साथ एक कॉलबैक पंजीकृत करें। इसका `MarkdownSvgImageSavingHandler` कॉलबैक एक `ISvgImage` ऑब्जेक्ट और एक‑तत्वीय `link` एरे प्राप्त करता है। SVG में कोई `ImageFormat` तर्क नहीं होता; `ISvgImage.getSvgData` मेथड से उसका XML डेटा लिखें या अपलोड करें। निर्यात मोड और दृश्य समूहबद्धता के आधार पर, स्रोत प्रस्तुति में मौजूद SVG को रास्टराइज़ किया जा सकता है या अन्य सामग्री के साथ मिलाया जा सकता है; परिणामस्वरूप गैर‑SVG संसाधन फिर इमेज‑सेविंग कॉलबैक को दिया जाता है। जब प्रत्येक निर्यातित दृश्य संसाधन को कस्टम प्रोसेसिंग की आवश्यकता हो तो दोनों कॉलबैक पंजीकृत करें।

Node.js में इन कॉलबैक इंटरफ़ेसों के कार्यान्वयन `java.newProxy` के साथ बनाएँ।

हैंडलर का रिटर्न मान निर्धारित करता है कि छवि को कौन प्रोसेस करेगा:

- यदि हैंडलर ने छवि को सहेज, अपलोड, रूपांतरित या किसी तरह प्रोसेस किया और `link[0]` को वैध मान दिया, तो `true` लौटाएँ। Aspose.Slides इस मान को Markdown दस्तावेज़ में लिखता है और डिफ़ॉल्ट स्थानीय सहेजना नहीं करता।
- यदि `false` लौटाएँ तो Aspose.Slides छवि को स्थानीय रूप से सहेजता है और लिंक को उन मानों के अनुसार जनरेट करता है जो आपने [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/markdownsaveoptions/) और [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/markdownsaveoptions/) से सेट किए हैं।

{{% alert color="warning" title="Important" %}}
`true` लौटाने वाला हैंडलर छवि की जिम्मेदारी लेता है। यदि वह `true` लौटाता है लेकिन वैध, गैर‑खाली लिंक असाइन नहीं करता, तो निर्यात `InvalidOperationException` के साथ विफल हो जाता है।
{{% /alert %}}

### **छवियों को CDN मूल डायरेक्टरी में सहेजें और बाहरी URLs का उपयोग करें**

निम्न उदाहरण `cdn-origin/presentations/quarterly-report` को एक माउंटेड या सिंक्रोनाइज़्ड CDN मूल डायरेक्टरी मानता है। प्रत्येक हैंडलर उत्पन्न फ़ाइल नाम निकालता है, छवि को उस कस्टम डायरेक्टरी में सहेजता है, और उत्पन्न स्थानीय संदर्भ को सार्वजनिक CDN URL से बदल देता है। स्वयं सैंपल कोई नेटवर्क अपलोड नहीं करता: URL केवल तब वैध होता है जब डायरेक्टरी को CDN मूल के रूप में माउंट किया गया हो या उसकी फ़ाइलें CDN पर प्रकाशित हो गई हों। ऑब्जेक्ट स्टोरेज के लिए, फ़ाइल‑सिस्टम लिखने को स्टोरेज SDK के अपलोड ऑपरेशन से बदलें और अपलोड सफल होने पर ही `link[0]` असाइन करें।

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");
const fs = require("fs");
const path = require("path");

const outputDirectory = "output";
const publicBaseUrl = "https://cdn.example.com/presentations/quarterly-report";
const storageDirectory = path.join("cdn-origin", "presentations", "quarterly-report");
fs.mkdirSync(outputDirectory, { recursive: true });
fs.mkdirSync(storageDirectory, { recursive: true });

const getFileNameFromLink = generatedLink => {
    const urlCompatibleLink = String(generatedLink).replace(/\\/g, "/");
    return path.posix.basename(urlCompatibleLink);
};
const buildPublicUrl = fileName => publicBaseUrl + "/" + encodeURIComponent(fileName);

const imageSavingHandler = java.newProxy("com.aspose.slides.MarkdownSaveOptions$MarkdownImageSavingHandler", {
    invoke: function(image, format, link) {
        if (image.getWidth() < 128 || image.getHeight() < 128) {
            return false;
        }

        const fileName = getFileNameFromLink(link[0]);
        const storagePath = path.join(storageDirectory, fileName);
        image.save(storagePath, format);
        link[0] = buildPublicUrl(fileName);
        return true;
    }
});

const svgImageSavingHandler = java.newProxy("com.aspose.slides.MarkdownSaveOptions$MarkdownSvgImageSavingHandler", {
    invoke: function(svgImage, link) {
        const fileName = getFileNameFromLink(link[0]);
        const storagePath = path.join(storageDirectory, fileName);
        fs.writeFileSync(storagePath, svgImage.getSvgData());
        link[0] = buildPublicUrl(fileName);
        return true;
    }
});

var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    var options = new aspose.slides.MarkdownSaveOptions();
    options.setExportType(aspose.slides.MarkdownExportType.Visual);
    options.setBasePath(outputDirectory);
    options.setImagesSaveFolderName("fallback-images");
    options.setImageSaving(imageSavingHandler);
    options.setSvgImageSaving(svgImageSavingHandler);

    const markdownPath = path.join(outputDirectory, "presentation.md");
    presentation.save(markdownPath, aspose.slides.SaveFormat.Md, options);
} finally {
    presentation.dispose();
}
```

बिटमैप हैंडलर जानबूझकर 128 × 128 पिक्सेल से छोटी छवियों के लिए `false` लौटाता है, इसलिए Aspose.Slides उन छवियों को `output/fallback-images` में डिफ़ॉल्ट व्यवहार का उपयोग करके सहेजता है। बड़े बिटमैप और मेटाफाइल संसाधन, साथ ही SVG संसाधन, कस्टम कोड द्वारा संभाले जाते हैं। उदाहरण के लिए, उत्पन्न स्थानीय संदर्भ `fallback-images/image1.png` बन जाता है `https://cdn.example.com/presentations/quarterly-report/image1.png`। हैंडलर फ़ाइल‑सिस्टम पाथ लिखते समय केवल ऑपरेटिंग‑सिस्टम पाथ का उपयोग करते हैं; Markdown में लिखे गए लिंक फ़ॉरवर्ड स्लैश और URL‑एस्केप्ड फ़ाइल नामों का उपयोग करते हैं। सापेक्ष लिंक बनाते समय भी वही नियम लागू करें: `/` का उपयोग करें, प्लेटफ़ॉर्म‑विशिष्ट डायरेक्टरी सेपरेटर नहीं।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या कोई हैंडलर दोनों रास्टर छवियों और SVG छवियों को प्रोसेस कर सकता है?**

नहीं। निर्यातित बिटमैप और मेटाफाइल संसाधनों के लिए [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/markdownsaveoptions/) का उपयोग करें और SVG के रूप में निकले संसाधनों के लिए [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/markdownsaveoptions/) का उपयोग करें। पहला [IImage](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/iimage/) ऑब्जेक्ट और एक [ImageFormat](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/imageformat/) मान प्रदान करता है; दूसरा `ISvgImage` ऑब्जेक्ट प्रदान करता है जिसका SVG डेटा `ISvgImage.getSvgData` से पढ़ा जा सकता है। निर्यात के दौरान रास्टराइज़ किया गया स्रोत SVG इमेज‑सेविंग कॉलबैक द्वारा प्रोसेस किया जाता है।

**जब इमेज‑सेविंग हैंडलर `false` लौटाता है तो क्या होता है?**

Aspose.Slides अपनी डिफ़ॉल्ट स्थानीय‑सहेजने की व्यवहार का उपयोग करता है। छवि का स्थान और उत्पन्न संदर्भ उन मानों द्वारा नियंत्रित होते हैं जो आपने [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/markdownsaveoptions/) और [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/markdownsaveoptions/) से सेट किए हैं।

**क्या हैंडलर बिना स्थानीय रूप से छवि सहेजे URL प्रदान कर सकता है?**

हाँ। हैंडलर छवि को ऑब्जेक्ट स्टोरेज में अपलोड कर सकता है या किसी अन्य सेवा को दे सकता है, परिणामी URL को `link[0]` में असाइन कर सकता है, और `true` लौटाए। हैंडलर को स्वयं प्रोसेसिंग पूरी करनी होती है; `true` लौटाने से डिफ़ॉल्ट स्थानीय सहेजना रुक जाता है।

**Markdown निर्यात में हैंडलर से `InvalidOperationException` क्यों फेंका जाता है?**

यह तब होता है जब हैंडलर `true` लौटाता है लेकिन वैध लिंक प्रदान नहीं करता। `true` लौटाने से पहले वह सापेक्ष पाथ या बाहरी URL असाइन करें जो Markdown में लिखा जाना चाहिए।

**छवि लिंक को कौन सा पाथ सेपरेटर उपयोग करना चाहिए?**

Markdown लिंक और URLs में फ़ॉरवर्ड स्लैश (`/`) उपयोग करें। फ़ाइल‑सिस्टम पाथ के लिए केवल `path.join` का उपयोग करें, फिर Markdown संदर्भ को अलग से बनाएँ या सामान्यीकृत करें।

**क्या Markdown निर्यात के दौरान हाइपरलिंक बरकरार रहते हैं?**

हाँ। टेक्स्ट [hyperlinks](/slides/hi/nodejs-java/manage-hyperlinks/) को मानक Markdown लिंक के रूप में संरक्षित रखा जाता है। स्लाइड [transitions](/slides/hi/nodejs-java/slide-transition/) और [animations](/slides/hi/nodejs-java/powerpoint-animation/) को परिवर्तित नहीं किया जाता।

**क्या प्रस्तुतियों को समानांतर में Markdown में परिवर्तित किया जा सकता है?**

आप विभिन्न प्रस्तुति फ़ाइलों को समानांतर में प्रोसेस कर सकते हैं, लेकिन एक ही [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) इंस्टेंस को थ्रेड्स के बीच साझा न करें। [multithreading guidelines](/slides/hi/nodejs-java/multithreading/) का पालन करें और प्रत्येक फ़ाइल के लिए एक अलग इंस्टेंस उपयोग करें।