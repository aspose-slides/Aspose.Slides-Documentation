---
title: बाहरी रूप से लिंक की गई छवियों के साथ प्रस्तुतियों को HTML में निर्यात करें
type: docs
weight: 100
url: /hi/nodejs-java/exporting-presentations-to-html-with-externally-linked-images/
keywords:
- PowerPoint निर्यात
- OpenDocument निर्यात
- प्रस्तुति निर्यात
- स्लाइड निर्यात
- PPT निर्यात
- PPTX निर्यात
- ODP निर्यात
- PowerPoint को HTML में
- OpenDocument को HTML में
- प्रस्तुति को HTML में
- स्लाइड को HTML में
- PPT को HTML में
- PPTX को HTML में
- ODP को HTML में
- लिंक्ड छवि
- बाहरी रूप से लिंक की गई छवि
- लिंक्ड संसाधन
- बाहरी संसाधन
- जावास्क्रिप्ट
- Node.js
- Aspose.Slides
description: "Aspose.Slides for Node.js का उपयोग करके Java के माध्यम से जावास्क्रिप्ट में PowerPoint और OpenDocument प्रस्तुतियों को HTML में निर्यात करें, जहाँ छवियां और अन्य संसाधन बाहरी लिंक फ़ाइलों के रूप में सहेजे जाते हैं।"
---
## **अवलोकन**

डिफ़ॉल्ट रूप से, Aspose.Slides एक प्रस्तुति को एक स्वतंत्र HTML फ़ाइल में निर्यात करता है। छवियां और अन्य संसाधन आमतौर पर Base64 डेटा के रूप में सीधे HTML में लिखे जाते हैं। यह तब सुविधाजनक होता है जब आपको एक पोर्टेबल फ़ाइल चाहिए, लेकिन यह हमेशा वेबसाइट, CMS, या सर्वर‑साइड रूपांतरण पाइपलाइन के लिए सबसे अच्छा फॉर्मेट नहीं होता।

बाहरी रूप से लिंक किए गए संसाधनों का उपयोग करें जब आप चाहते हैं:

- HTML दस्तावेज़ का आकार कम करने के लिए;
- छवियों, फ़ॉन्ट्स, ऑडियो या वीडियो को ब्राउज़र या CDN में अलग से कैश करने के लिए;
- निर्यात के बाद निर्मित संसाधनों की जाँच, प्रतिस्थापन, संपीड़न या पोस्ट‑प्रोसेसिंग करने के लिए;
- आउटपुट संरचना को वेब एप्लिकेशन की अपेक्षा के अधिक करीब रखने के लिए।

सामान्य HTML रूपांतरण कार्यप्रवाह के लिए देखें [Convert PowerPoint Presentations to HTML](/slides/hi/nodejs-java/convert-powerpoint-to-html/)। यह लेख निर्यात के संसाधन‑लिंकिंग भाग पर केंद्रित है।

## **लिंक्ड संसाधन निर्यात कैसे काम करता है**

[ILinkEmbedController](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ilinkembedcontroller/) के लिए एक Java प्रॉक्सी आपके एप्लिकेशन को प्रत्येक संसाधन के लिए तय करने देता है कि निर्यातक डेटा को HTML में एम्बेड करे या बाहरी रूप से सहेज कर लिंक लिखे।

कंट्रोलर में तीन मेथड हैं:

- [ILinkEmbedController.getObjectStoringLocation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ilinkembedcontroller/) तय करता है कि कोई संसाधन लिंक होना चाहिए या एम्बेड।
- [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ilinkembedcontroller/) वह URL लौटाता है जिसे उत्पन्न HTML या किसी अन्य लिंक्ड संसाधन में लिखा जाएगा।
- [ILinkEmbedController.saveExternal](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ilinkembedcontroller/) लिंक्ड संसाधन डेटा को डिस्क या किसी अन्य स्टोरेज लक्ष्य पर लिखता है।

फ़ाइल सिस्टम पाथ और ब्राउज़र URL अलग‑अलग हैं। उदाहरण के लिए, नीचे दिया गया नमूना संसाधन फ़ाइलों को डिस्क पर `html-output/assets` में लिखता है, जबकि HTML में सापेक्ष URL जैसे `assets/resource-1.svg` होते हैं। ब्राउज़र उन URL को उस फ़ाइल के सापेक्ष हल करता है जिसमें लिंक है। इसलिए, `presentation.html` से SVG फ़ाइल का लिंक `assets/resource-1.svg` होता है, जबकि उसी `assets` फ़ोल्डर में स्थित छवि का लिंक `resource-4.jpg` होता है।

## **लिंक्ड संसाधनों के साथ HTML निर्यात**

निम्नलिखित JavaScript उदाहरण एक आउटपुट डायरेक्टरी बनाता है, HTML फ़ाइल वहाँ सहेजता है, और लिंक्ड संसाधनों को `assets` उप‑डायरेक्टरी में रखता है। कंट्रोलर सामान्य छवि, फ़ॉन्ट, ऑडियो, वीडियो और CSS संसाधनों को लिंक करता है जब Aspose.Slides कोई सुरक्षित फ़ाइल एक्सटेंशन प्रदान करता है या अनुमान लगा सकता है। जो संसाधन पहचाने नहीं जाते, वे एम्बेडेड रहेंगे।

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");
const fs = require("fs");
const path = require("path");

class ExternalResourceController {
    constructor(assetDirectory, assetUrlPrefix) {
        if (assetDirectory == null || assetDirectory.trim().length === 0) {
            throw new Error("The asset output directory must not be empty.");
        }

        this.assetDirectory = assetDirectory;
        this.assetUrlPrefix = normalizeUrlPrefix(assetUrlPrefix);
        this.fileNamesByResourceId = new Map();
    }

    createProxy() {
        const linkEmbedControllerInterfaceName = "com.aspose.slides.ILinkEmbedController";
        let controller = this;
        return java.newProxy(linkEmbedControllerInterfaceName, {
            getObjectStoringLocation: function(resourceId, entityData, semanticName, contentType, recommendedExtension) {
                return controller.getObjectStoringLocation(
                    resourceId,
                    entityData,
                    semanticName,
                    contentType,
                    recommendedExtension);
            },
            getUrl: function(resourceId, referrer) {
                return controller.getUrl(resourceId, referrer);
            },
            saveExternal: function(resourceId, entityData) {
                controller.saveExternal(resourceId, entityData);
            }
        });
    }

    getObjectStoringLocation(resourceId, entityData, semanticName, contentType, recommendedExtension) {
        let extension = resolveExtension(contentType, recommendedExtension);
        if (extension == null) {
            return aspose.slides.LinkEmbedDecision.Embed;
        }

        this.fileNamesByResourceId.set(resourceId, "resource-" + resourceId + extension);
        return aspose.slides.LinkEmbedDecision.Link;
    }

    getUrl(resourceId, referrer) {
        let fileName = this.fileNamesByResourceId.get(resourceId);
        if (fileName == null) {
            return null;
        }

        if (this.fileNamesByResourceId.has(referrer)) {
            return fileName;
        }

        return this.assetUrlPrefix + fileName;
    }

    saveExternal(resourceId, entityData) {
        let fileName = this.fileNamesByResourceId.get(resourceId);
        if (fileName == null) {
            throw new Error("Resource " + resourceId + " was not registered for external storage.");
        }

        if (entityData == null || entityData.length === 0) {
            throw new Error("Resource " + resourceId + " contains no data and cannot be saved.");
        }

        fs.mkdirSync(this.assetDirectory, { recursive: true });

        let filePath = path.join(this.assetDirectory, fileName);
        let fileData = Buffer.from(entityData);
        fs.writeFileSync(filePath, fileData);
    }
}

function createExtensionsByContentType() {
    let extensionsByContentType = new Map();
    extensionsByContentType.set("image/jpeg", ".jpg");
    extensionsByContentType.set("image/png", ".png");
    extensionsByContentType.set("image/gif", ".gif");
    extensionsByContentType.set("image/bmp", ".bmp");
    extensionsByContentType.set("image/svg+xml", ".svg");
    extensionsByContentType.set("image/tiff", ".tiff");
    extensionsByContentType.set("image/x-emf", ".emf");
    extensionsByContentType.set("image/x-wmf", ".wmf");
    extensionsByContentType.set("font/woff", ".woff");
    extensionsByContentType.set("font/woff2", ".woff2");
    extensionsByContentType.set("font/ttf", ".ttf");
    extensionsByContentType.set("application/font-woff", ".woff");
    extensionsByContentType.set("application/vnd.ms-fontobject", ".eot");
    extensionsByContentType.set("application/x-font-ttf", ".ttf");
    extensionsByContentType.set("text/css", ".css");
    extensionsByContentType.set("audio/mpeg", ".mp3");
    extensionsByContentType.set("audio/mp4", ".m4a");
    extensionsByContentType.set("audio/wav", ".wav");
    extensionsByContentType.set("video/mp4", ".mp4");
    extensionsByContentType.set("video/webm", ".webm");
    return extensionsByContentType;
}

let extensionsByContentType = createExtensionsByContentType();

function resolveExtension(contentType, recommendedExtension) {
    if (contentType != null && contentType.trim().length > 0) {
        let mappedExtension = extensionsByContentType.get(contentType);
        if (mappedExtension != null) {
            return mappedExtension;
        }
    }

    if (!isSupportedContentType(contentType)) {
        return null;
    }

    return normalizeExtension(recommendedExtension);
}

function isSupportedContentType(contentType) {
    if (contentType == null) {
        return false;
    }

    let normalizedContentType = contentType.toLowerCase();
    return normalizedContentType.startsWith("image/") ||
        normalizedContentType.startsWith("font/") ||
        normalizedContentType.startsWith("audio/") ||
        normalizedContentType.startsWith("video/");
}

function normalizeExtension(extension) {
    if (extension == null || extension.trim().length === 0) {
        return null;
    }

    let extensionCharacters = extension.trim();
    while (extensionCharacters.startsWith(".")) {
        extensionCharacters = extensionCharacters.substring(1);
    }

    if (extensionCharacters.length === 0) {
        return null;
    }

    for (let index = 0; index < extensionCharacters.length; index++) {
        let character = extensionCharacters[index];
        if (!/[A-Za-z0-9]/.test(character)) {
            return null;
        }
    }

    return "." + extensionCharacters.toLowerCase();
}

function normalizeUrlPrefix(urlPrefix) {
    if (urlPrefix == null || urlPrefix.length === 0) {
        return "";
    }

    let normalizedUrlPrefix = urlPrefix.replace(/\\/g, "/");
    return normalizedUrlPrefix.endsWith("/")
        ? normalizedUrlPrefix
        : normalizedUrlPrefix + "/";
}

let inputFilePath = "presentation.pptx";
let outputDirectory = "html-output";
let assetDirectoryName = "assets";
let assetDirectory = path.join(outputDirectory, assetDirectoryName);

fs.mkdirSync(outputDirectory, { recursive: true });
fs.mkdirSync(assetDirectory, { recursive: true });

let assetUrlPrefix = assetDirectoryName + "/";
let controllerWrapper = new ExternalResourceController(assetDirectory, assetUrlPrefix);
let controller = controllerWrapper.createProxy();
let svgOptions = new aspose.slides.SVGOptions(controller);
let slideImageFormat = aspose.slides.SlideImageFormat.svg(svgOptions);

let htmlOptions = new aspose.slides.HtmlOptions(controller);
htmlOptions.setHtmlFormatter(aspose.slides.HtmlFormatter.createDocumentFormatter("", false));
htmlOptions.setSlideImageFormat(slideImageFormat);

let presentation = new aspose.slides.Presentation(inputFilePath);
try {
    let htmlFilePath = path.join(outputDirectory, "presentation.html");
    presentation.save(htmlFilePath, aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

निर्यात के बाद आउटपुट फ़ोल्डर की संरचना कुछ इस प्रकार होगी:

```text
html-output/
  presentation.html
  assets/
    resource-1.svg
    resource-2.svg
    resource-3.svg
    resource-4.jpg
    resource-5.png
```

सटीक फ़ाइलें प्रस्तुति की सामग्री और निर्यात विकल्पों पर निर्भर करती हैं। उदाहरण के लिए, रास्टर छवियां सामान्यतः JPEG या PNG के रूप में निर्यात की जाती हैं। Aspose.Slides स्रोत प्रस्तुति से अलग इमेज कोडेक चुन सकता है यदि वह छोटा या अधिक उपयुक्त फ़ाइल बनाता है। पारदर्शिता वाली छवियां PNG के रूप में निर्यात की जाती हैं।

## **परिनियोजन के लिए URL चुनना**

नमूना एक सापेक्ष URL प्रीफ़िक्स उपयोग करता है: `assets/`। यदि `presentation.html` को `html-output/presentation.html` से खोला गया है, तो ब्राउज़र `html-output/assets/resource-1.svg` लोड करेगा।

जब एक लिंक्ड संसाधन दूसरे लिंक्ड संसाधन को संदर्भित करता है, तो नमूना [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ilinkembedcontroller/) में `referrer` पैरामीटर का उपयोग करता है और केवल फ़ाइल नाम लौटाता है। उदाहरण के लिए, यदि `resource-1.svg` और `resource-4.jpg` दोनों `assets` फ़ोल्डर में हैं, तो SVG फ़ाइल को `resource-4.jpg` को संदर्भित करना चाहिए, न कि `assets/resource-4.jpg` को।

फ़ाइलें किसी अन्य स्थान पर परिनियोजित होने पर अलग URL प्रीफ़िक्स उपयोग करें:

- जब एसेट डायरेक्टरी HTML फ़ाइल के बगल में हो तो `assets/` उपयोग करें।
- जब एसेट डायरेक्टरी HTML फ़ाइल से एक स्तर ऊपर हो तो `../assets/` उपयोग करें।
- जब फ़ाइलें CDN या स्थैतिक फ़ाइल सर्वर पर अपलोड हों तो `https://cdn.example.com/presentations/job-123/assets/` उपयोग करें।

[ILinkEmbedController.getUrl](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ilinkembedcontroller/) द्वारा लौटाया गया URL उस फ़ाइल के अंतिम परिनियोजित स्थान से मेल खाना चाहिए जिसे [ILinkEmbedController.saveExternal](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ilinkembedcontroller/) लिखता है। सर्वर एप्लिकेशनों में, प्रत्येक रूपांतरण कार्य के लिए एक अद्वितीय आउटपुट डायरेक्टरी या ऑब्जेक्ट‑स्टोरेज प्रीफ़िक्स उपयोग करें ताकि किसी अन्य निर्यात की फ़ाइलें ओवरराइट न हों।

## **इसके बजाय एम्बेड कब करें**

एम्बेडेड Base64 HTML तब भी उपयोगी रहता है जब आउटपुट को एक एकल फ़ाइल होना आवश्यक हो, जैसे ई‑मेल अटैचमेंट, ऑफ़लाइन पूर्वावलोकन, या ऐसा दस्तावेज़ जो एसेट फ़ोल्डर के बिना मूव किया जाएगा। लिंक्ड संसाधन बेहतर होते हैं जब HTML को वेब एप्लिकेशन द्वारा सर्व किया जाएगा, CMS में संग्रहीत किया जाएगा, बिल्ड पाइपलाइन द्वारा ऑप्टिमाइज़ किया जाएगा, या ब्राउज़र द्वारा HTML से स्वतंत्र रूप से कैश किया जाएगा।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं केवल छवियों को बाहरी रूप से सहेज सकता हूँ और अन्य संसाधनों को एम्बेड रख सकता हूँ?**

हाँ। [ILinkEmbedController.getObjectStoringLocation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ilinkembedcontroller/) में उन कंटेंट प्रकारों के लिए `LinkEmbedDecision.Link` लौटाएँ जिन्हें आप अलग फ़ाइलों में सहेजना चाहते हैं, और बाकी के लिए `LinkEmbedDecision.Embed` लौटाएँ।

**निर्यातित छवि एक्सटेंशन स्रोत प्रस्तुति से क्यों अलग होता है?**

HTML निर्यात के दौरान Aspose.Slides आकार या ब्राउज़र संगतता में सुधार के लिए रास्टर छवियों को पुनः‑कोडित कर सकता है। उदाहरण के लिए, स्रोत फ़ाइल की छवि को रेंडर परिणाम के आधार पर JPEG या PNG के रूप में लिखा जा सकता है।

**क्या HTML फ़ाइल को स्थानांतरित करने के बाद सापेक्ष URL काम करेंगे?**

सापेक्ष URL तभी काम करेंगे जब वही सापेक्ष फ़ोल्डर संरचना बनी रहे। यदि HTML `assets/resource-1.png` को संदर्भित करता है, तो `assets` फ़ोल्डर को HTML फ़ाइल के बगल में ही रहना चाहिए, जब तक आप अलग URL प्रीफ़िक्स न बनाएं।

**क्या सर्वर एप्लिकेशन एक ही आउटपुट फ़ोल्डर का पुनः उपयोग कर सकते हैं?**

नहीं। प्रत्येक रूपांतरण कार्य के लिए एक अद्वितीय आउटपुट डायरेक्टरी या स्टोरेज प्रीफ़िक्स उपयोग करें। यह फ़ाइलनाम टकराव से बचाता है और एक निर्यात को दूसरे निर्यात द्वारा उत्पन्न संसाधनों को ओवरराइट करने से रोकता है।