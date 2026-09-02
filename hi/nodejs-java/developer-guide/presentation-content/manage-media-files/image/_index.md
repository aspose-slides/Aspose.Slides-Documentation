---
title: जावास्क्रिप्ट का उपयोग कर प्रस्तुतियों में छवि प्रबंधन को अनुकूलित करें
linktitle: छवियों का प्रबंधन
type: docs
weight: 10
url: /hi/nodejs-java/image/
keywords:
- छवि जोड़ें
- चित्र जोड़ें
- बिटमैप जोड़ें
- छवि बदलें
- चित्र बदलें
- वेब से
- पृष्ठभूमि
- PNG जोड़ें
- JPG जोड़ें
- SVG जोड़ें
- बाहरी SVG संसाधन
- SVG रिजॉल्वर
- लिंक्ड SVG छवियां
- SVG फ़ॉन्ट
- EMF जोड़ें
- WMF जोड़ें
- TIFF जोड़ें
- PowerPoint
- OpenDocument
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java के साथ PowerPoint और OpenDocument में छवि प्रबंधन को सरल बनाएं, प्रदर्शन को अनुकूलित करें और अपने कार्यप्रवाह को स्वचालित करें।"
---
## **परिचय**

इमेज़ प्रस्तुतियों को अधिक आकर्षक और दृश्यात्मक रूप से आकर्षक बनाते हैं। Microsoft PowerPoint में, आप फ़ाइलों, इंटरनेट, या अन्य स्रोतों से स्लाइड पर चित्र सम्मिलित कर सकते हैं। इसी तरह, Aspose.Slides आपको कई तरीकों से प्रस्तुति स्लाइड में छवियों को जोड़ने की अनुमति देता है।

{{% alert  title="Tip" color="primary" %}} 
Aspose मुफ्त रूपांतरण उपकरण प्रदान करता है—[JPEG से PowerPoint](https://products.aspose.app/slides/hi/import/jpg-to-ppt) और [PNG से PowerPoint](https://products.aspose.app/slides/hi/import/png-to-ppt)—जो आपको छवियों से शीघ्रता से प्रस्तुतियां बनाने की अनुमति देते हैं। 
{{% /alert %}} 

{{% alert title="Info" color="info" %}}
यदि आप किसी छवि को चित्र फ्रेम के रूप में जोड़ना चाहते हैं—विशेषकर यदि आप उसका आकार बदलने, प्रभाव लागू करने, या अन्य मानक फॉर्मेटिंग विकल्पों की योजना बनाते हैं—तो देखें [Picture Frame](/slides/hi/nodejs-java/picture-frame/). 
{{% /alert %}} 

{{% alert title="Note" color="warning" %}}
आप एक फ़ॉर्मेट से दूसरे फ़ॉर्मेट में छवियों को रूपांतरित कर सकते हैं। निम्नलिखित पृष्ठ देखें: रूपांतरण [छवि को JPG में बदलें](https://products.aspose.com/slides/hi/nodejs-java/conversion/image-to-jpg/), [JPG को छवि में बदलें](https://products.aspose.com/slides/hi/nodejs-java/conversion/jpg-to-image/), [JPG को PNG में बदलें](https://products.aspose.com/slides/hi/nodejs-java/conversion/jpg-to-png/), [PNG को JPG में बदलें](https://products.aspose.com/slides/hi/nodejs-java/conversion/png-to-jpg/), [PNG को SVG में बदलें](https://products.aspose.com/slides/hi/nodejs-java/conversion/png-to-svg/), और [SVG को PNG में बदलें](https://products.aspose.com/slides/hi/nodejs-java/conversion/svg-to-png/). 
{{% /alert %}}

Aspose.Slides JPEG, PNG, BMP, GIF आदि जैसे लोकप्रिय फ़ॉर्मेट में छवियों को समर्थन देता है। 

## **स्लाइड्स में स्थानीय रूप से संग्रहीत छवियाँ जोड़ें**

आप अपने कंप्यूटर में संग्रहीत एक या अधिक छवियों को प्रस्तुति स्लाइड में जोड़ सकते हैं। निम्नलिखित JavaScript नमूना कोड दिखाता है कि स्लाइड में छवि कैसे जोड़ें:
```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const pres = new aspose.slides.Presentation();
try {
    const slide = pres.getSlides().get_Item(0);

    let picture;
    const image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }

    slide.getShapes().addPictureFrame(
        aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, picture);

    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **स्लाइड्स में वेब से छवियाँ जोड़ें**

यदि आप जिस छवि को स्लाइड में जोड़ना चाहते हैं वह आपके कंप्यूटर में संग्रहीत नहीं है, तो आप उसे सीधे वेब से जोड़ सकते हैं। 
निम्नलिखित JavaScript नमूना कोड दिखाता है कि वेब से छवि को स्लाइड में कैसे जोड़ें:
```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const pres = new aspose.slides.Presentation();
try {
    const slide = pres.getSlides().get_Item(0);

    const imageUrl = java.newInstanceSync("java.net.URL", "[REPLACE WITH URL]");
    const inputStream = imageUrl.openStream();
    try {
        let picture;
        const image = aspose.slides.Images.fromStream(inputStream);
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) {
                image.dispose();
            }
        }

        slide.getShapes().addPictureFrame(
            aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, picture);
    } finally {
        if (inputStream != null) {
            inputStream.close();
        }
    }

    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **स्लाइड मास्टर में छवियाँ जोड़ें**

स्लाइड मास्टर थीम और लेआउट जैसी जानकारी संग्रहीत और नियंत्रित करता है जो इसके उपयोग वाली स्लाइड्स के लिए होती है। जब आप एक स्लाइड मास्टर में छवि जोड़ते हैं, तो वह छवि उस मास्टर पर आधारित सभी स्लाइड्स में दिखाई देती है। 
निम्नलिखित JavaScript नमूना कोड दिखाता है कि स्लाइड मास्टर में छवि कैसे जोड़ें:
```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const pres = new aspose.slides.Presentation();
try {
    const slide = pres.getSlides().get_Item(0);
    const masterSlide = slide.getLayoutSlide().getMasterSlide();

    let picture;
    const image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }

    masterSlide.getShapes().addPictureFrame(
        aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, picture);

    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **स्लाइड बैकग्राउंड के रूप में छवियाँ जोड़ें**

आप एक या अधिक स्लाइड्स के लिए पृष्ठभूमि के रूप में चित्र का उपयोग कर सकते हैं। विवरण के लिए देखें *[Setting Images as Backgrounds for Slides](/slides/hi/nodejs-java/presentation-background/#setting-images-as-background-for-slides)*। 

## **प्रस्तुतियों में SVG जोड़ें**

SVG सामग्री को प्रस्तुति में [SvgImage](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/svgimage/) क्लास का उपयोग करके जोड़ा जा सकता है। परिणामी SVG छवि वस्तु को फिर प्रस्तुति की इमेज कलेक्शन में जोड़ा जा सकता है और चित्र फ्रेम बनाने के लिए इस्तेमाल किया जा सकता है। 
निम्नलिखित JavaScript उदाहरण एक स्व-समाहित SVG स्ट्रिंग को आयात करता है। इस SVG द्वारा उपयोग की गई सभी छवियां, शैली और अन्य संसाधन सीधे SVG सामग्री में एम्बेड किए गए हैं।
```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const svgContent =
    "<svg xmlns='http://www.w3.org/2000/svg' width='320' height='180'>" +
    "    <rect width='320' height='180' fill='#4F81BD'/>" +
    "    <circle cx='160' cy='90' r='55' fill='#F2F2F2'/>" +
    "</svg>";

const presentation = new aspose.slides.Presentation();
try {
    const svgImage = new aspose.slides.SvgImage(svgContent);
    const image = presentation.getImages().addImage(svgImage);

    presentation.getSlides().get_Item(0).getShapes().addPictureFrame(
        aspose.slides.ShapeType.Rectangle,
        20, 20, image.getWidth(), image.getHeight(), image);

    presentation.save("self-contained-svg.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **बाहरी संसाधनों के साथ SVG सामग्री आयात करें**

डिज़ाइन टूल्स, डायग्राम एडिटर्स, आइकन सिस्टम और वेब पाइपलाइन से निर्यातित SVG फ़ाइलें ऐसे संसाधनों का संदर्भ दे सकती हैं जो SVG दस्तावेज़ के बाहर संग्रहीत होते हैं। उदाहरण के लिए, एक SVG में `images/photo.png` जैसी छवि लिंक, CSS `url(...)` मान, या फ़ॉन्ट URL हो सकता है। 
ऐसी SVG सामग्री आयात करने के लिए, एक बाहरी संसाधन रिजॉल्वर प्रदान करें और इसे बेस URI के साथ उपयुक्त [SvgImage](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/svgimage/) कंस्ट्रक्टर को पास करें। बेस URI SVG दस्तावेज़ के स्थान की पहचान करता है और सापेक्ष लिंक को हल करने के लिए उपयोग होता है। 
`SvgImage` क्लास आयातित SVG के बारे में जानकारी तक पहुँच प्रदान करता है:
- `getSvgContent()` SVG मार्कअप को स्ट्रिंग के रूप में लौटाता है।
- `getSvgData()` SVG सामग्री को बाइट एरे के रूप में लौटाता है।
- `getBaseUri()` सापेक्ष लिंक के लिए उपयोग किए गए बेस URI को लौटाता है।
- `getExternalResourceResolver()` SVG छवि को असाइन किए गए रिजॉल्वर को लौटाता है।

### **बाहरी संसाधन रिजॉल्वर को लागू करना**

रिजॉल्वर में दो विधियाँ हैं:
- `resolveUri` बेस URI और सापेक्ष संसाधन लिंक को मिलाता है और एक पूर्ण URI लौटाता है। जब लिंक को हल नहीं किया जा सकता या अनुमति नहीं है तो `null` लौटाएँ।
- `getEntity` पूर्ण संसाधन URI के लिए पढ़ने योग्य Java स्ट्रीम लौटाता है। जब संसाधन अनुपलब्ध, अवरुद्ध या मौजूद नहीं हो तो `null` लौटाएँ। उपयुक्त होने पर फॉलबैक स्ट्रीम भी लौटाया जा सकता है।

निम्नलिखित हेल्पर एक रिजॉल्वर बनाता है जो लिंक किए गए संसाधनों को केवल अनुमत स्थानीय निर्देशिका से लोड करता है। नेटवर्क संसाधन और अनुमत निर्देशिका के बाहर के पथ अवरुद्ध होते हैं। अनसुलझी छवि लिंक के लिए वैकल्पिक फॉलबैक छवि लौटाई जाती है।
```javascript
const fs = require("fs");
const path = require("path");
const java = require("java");
const { fileURLToPath, pathToFileURL } = require("url");

function isInsideAllowedRoot(resourcePath, allowedRoot) {
    const relativePath = path.relative(allowedRoot, resourcePath);

    return relativePath === "" ||
        (relativePath !== ".." &&
         !relativePath.startsWith(".." + path.sep) &&
         !path.isAbsolute(relativePath));
}

function isImageFile(filePath) {
    const extension = path.extname(filePath).toLowerCase();
    return [".png", ".jpg", ".jpeg", ".gif", ".bmp"].includes(extension);
}

function createLocalSvgResourceResolver(allowedRoot, fallbackImageData) {
    const normalizedRoot = path.resolve(allowedRoot);

    return java.newProxy("com.aspose.slides.IExternalResourceResolver", {
        resolveUri: function(baseUri, relativeUri) {
            if (baseUri == null || baseUri.trim() === "" ||
                    relativeUri == null || relativeUri.trim() === "") {
                return null;
            }

            try {
                const absoluteAddress = new URL(relativeUri, baseUri);

                // यह रेज़ॉल्वर केवल स्थानीय फ़ाइलों की अनुमति देने के लिए जानबूझकर बनाया गया है।
                if (absoluteAddress.protocol !== "file:") {
                    return null;
                }

                const resourcePath = path.resolve(fileURLToPath(absoluteAddress));
                if (!isInsideAllowedRoot(resourcePath, normalizedRoot)) {
                    return null;
                }

                return pathToFileURL(resourcePath).href;
            } catch (e) {
                return null;
            }
        },

        getEntity: function(absoluteUri) {
            try {
                const resourceUrl = new URL(absoluteUri);
                if (resourceUrl.protocol !== "file:") {
                    return null;
                }

                const resourcePath = path.resolve(fileURLToPath(resourceUrl));
                if (!isInsideAllowedRoot(resourcePath, normalizedRoot)) {
                    return null;
                }

                if (fs.existsSync(resourcePath)) {
                    return java.newInstanceSync("java.io.FileInputStream", resourcePath);
                }

                // केवल छवि संसाधनों के लिए फॉलबैक का उपयोग करें। इमेज स्ट्रीम लौटाना
                // गुम फ़ॉन्ट या स्टाइलशीट के लिए मान्य नहीं होगा।
                if (fallbackImageData != null && isImageFile(resourcePath)) {
                    const javaBytes = java.newArray("byte", Array.from(fallbackImageData));
                    return java.newInstanceSync("java.io.ByteArrayInputStream", javaBytes);
                }
            } catch (e) {
                return null;
            }

            return null;
        }
    });
}
```

### **SVG आयात के दौरान लिंक किए गए संसाधनों को हल करना**

मान लीजिए कि `assets/diagram.svg` में निम्नलिखित सापेक्ष संदर्भ है:
```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

निम्नलिखित JavaScript उदाहरण SVG फ़ाइल URI को बेस URI के रूप में पास करता है और एक कस्टम रिजॉल्वर प्रदान करता है। रिजॉल्वर सापेक्ष छवि लिंक को पूर्ण URI में परिवर्तित करता है और SVG को प्रोसेस करते समय लिंक्ड संसाधन वाली स्ट्रीम लौटाता है।
```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");
const path = require("path");
const { pathToFileURL } = require("url");

const svgFilePath = path.resolve("assets", "diagram.svg");
const assetDirectory = path.dirname(svgFilePath);
const svgContent = fs.readFileSync(svgFilePath, "utf8");

// बेस URI SVG दस्तावेज़ के स्थान को दर्शाता है।
const baseUri = pathToFileURL(svgFilePath).href;

let fallbackImageData = null;
const fallbackImagePath = path.join(assetDirectory, "fallback.png");
if (fs.existsSync(fallbackImagePath)) {
    fallbackImageData = fs.readFileSync(fallbackImagePath);
}

const resolver = createLocalSvgResourceResolver(assetDirectory, fallbackImageData);
const svgImage = new aspose.slides.SvgImage(svgContent, resolver, baseUri);

// SvgImage स्रोत सामग्री, बाइनरी डेटा, बेस URI, और रिजॉल्वर को उजागर करता है।
const importedContent = svgImage.getSvgContent();
const importedData = svgImage.getSvgData();
const importedBaseUri = svgImage.getBaseUri();
const importedResolver = svgImage.getExternalResourceResolver();

const presentation = new aspose.slides.Presentation();
try {
    const image = presentation.getImages().addImage(svgImage);

    presentation.getSlides().get_Item(0).getShapes().addPictureFrame(
        aspose.slides.ShapeType.Rectangle,
        20, 20, image.getWidth(), image.getHeight(), image);

    presentation.save("svg-with-linked-resources.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`SvgImage` क्लास ओवरलोड भी प्रदान करता है जो SVG डेटा को बाइट एरे के रूप में स्वीकार करता है, साथ ही स्ट्रीम-आधारित फ़ैक्टरी विधियाँ, एक बाहरी संसाधन रिजॉल्वर और एक बेस URI के साथ।

{{% alert title="Important" color="warning" %}}
संसाधन रिजॉल्वर Aspose.Slides द्वारा SVG प्रोसेस और रेंडर किए जाने के दौरान बाहरी संसाधनों को उपलब्ध कराता है। यह मूल SVG मार्कअप को संशोधित नहीं करता या स्वचालित रूप से हल किए गए संसाधनों को उसमें एम्बेड नहीं करता।

जब एक SVG छवि को प्रस्तुति इमेज कलेक्शन में जोड़ा जाता है, तो PPTX फ़ाइल में मूल SVG प्रतिनिधित्व और एक रास्टर फॉलबैक छवि दोनों हो सकते हैं। एक लिंक्ड रिसोर्स उत्पन्न फॉलबैक छवि में दिखाई दे सकता है जबकि `images/photo.png` जैसी सापेक्ष लिंक संग्रहीत SVG में अपरिवर्तित रहती है। वह एप्लिकेशन जो मूल SVG प्रतिनिधित्व को रेंडर करता है, मूल बाहरी संसाधन उपलब्ध न होने पर लिंक्ड सामग्री को छोड़ सकता है।
{{% /alert %}}

### **एक पोर्टेबल SVG चित्र बनाएं**

एक ऐसा SVG चित्र बनाने के लिए जो बाहरी फ़ाइलों पर निर्भर नहीं करता, `SvgImage` बनाने से पहले SVG को स्व-समाहित बना दें। उदाहरण के लिए, लिंक्ड इमेज URLs को `data:` URI से बदलें जो इमेज डेटा शामिल करता है:
```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

सभी आवश्यक संसाधनों को SVG सामग्री में एम्बेड करने के बाद, `SvgImage` बनाएं, इसे प्रस्तुति इमेज कलेक्शन में जोड़ें, और पिछले उदाहरण में दिखाए अनुसार इसे एक चित्र फ्रेम में सम्मिलित करें।

### **गुम या अवरुद्ध संसाधनों को संभालें**

`resolveUri` से `null` लौटाएँ जब कोई संसाधन URI अमान्य, प्रतिबंधित या हल नहीं किया जा सकता। `getEntity` से `null` लौटाएँ जब संसाधन पढ़ा नहीं जा सकता। संभावित होने पर Aspose.Slides उस संसाधन के बिना SVG प्रोसेसिंग जारी रखता है।

गुम संसाधन के लिए फॉलबैक स्ट्रीम लौटाई जा सकती है, लेकिन उसकी सामग्री अनुरोधित संसाधन प्रकार के साथ संगत होनी चाहिए। उदाहरण के लिए, केवल मैसिंग इमेज के लिए इमेज स्ट्रीम लौटाएँ, फ़ॉन्ट या स्टाइलशीट के लिए नहीं।

{{% alert title="Security" color="warning" %}}
अविश्वसनीय SVG फ़ाइलों से मनमाने फ़ाइल पाथ या अनियंत्रित नेटवर्क URL को हल न करें। अनुमत स्कीम, डायरेक्टरी और होस्ट को सीमित करें। नेटवर्क संसाधनों के लिए, कनेक्शन टाइमआउट, प्रतिक्रिया आकार सीमा और सामग्री सत्यापन भी लागू करें।
{{% /alert %}}

## **SVG को आकारों के सेट में परिवर्तित करें**

Aspose.Slides एक SVG को आकारों के सेट में परिवर्तित कर सकता है, जो PowerPoint में समान कार्यक्षमता के समान है:
![PowerPoint Popup Menu](img_01_01.png)

यह कार्यक्षमता [addGroupShape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ShapeCollection#addGroupShape-aspose.slides.ISvgImage-float-float-float-float-) मेथड के एक ओवरलोड द्वारा प्रदान की जाती है, जो [ShapeCollection](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ShapeCollection) क्लास का है और यह SVG छवि वस्तु को अपने पहले तर्क के रूप में लेता है।

निम्नलिखित JavaScript नमूना कोड दिखाता है कि इस मेथड का उपयोग करके SVG फ़ाइल को आकारों के सेट में कैसे बदलें:
```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");
const java = require("java");

// स्रोत SVG फ़ाइल नाम।
const svgFileName = "sample.svg";

// आउटपुट प्रस्तुति फ़ाइल नाम।
const outPptxPath = "presentation.pptx";

// एक नई प्रस्तुति बनाएं।
const presentation = new aspose.slides.Presentation();
try {
    // SVG फ़ाइल की सामग्री पढ़ें।
    const svgContent = java.newArray("byte", Array.from(fs.readFileSync(svgFileName)));

    // एक SvgImage ऑब्जेक्ट बनाएं।
    const svgImage = new aspose.slides.SvgImage(svgContent);

    // स्लाइड आकार प्राप्त करें।
    const slideSize = presentation.getSlideSize().getSize();

    // SVG छवि को आकारों के समूह में बदलें और उसे स्लाइड आकार के अनुसार स्केल करें।
    presentation.getSlides().get_Item(0).getShapes().addGroupShape(
        svgImage, 0.0, 0.0, slideSize.getWidth(), slideSize.getHeight());

    // प्रस्तुति को PPTX प्रारूप में सहेजें।
    presentation.save(outPptxPath, aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **स्लाइड्स में EMF के रूप में छवियाँ जोड़ें**

Aspose.Slides for Node.js via Java आपको Aspose.Cells के साथ Excel वर्कशीट से EMF छवियों को जनरेट करने और उन्हें प्रस्तुति स्लाइड्स में जोड़ने की अनुमति देता है। 
निम्नलिखित JavaScript नमूना कोड दिखाता है कि यह कैसे किया जाए:
```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const book = java.newInstanceSync("aspose.cells.Workbook", "chart.xlsx");
const sheet = book.getWorksheets().get(0);

const options = java.newInstanceSync("aspose.cells.ImageOrPrintOptions");
options.setHorizontalResolution(200);
options.setVerticalResolution(200);
options.setImageType(java.getStaticFieldValue("ImageType", "EMF"));

// वर्कबुक को स्ट्रीम में सहेजें।
const sr = java.newInstanceSync("SheetRender", sheet, options);
const pres = new aspose.slides.Presentation();
try {
    pres.getSlides().removeAt(0);

    for (let j = 0; j < sr.getPageCount(); j++) {
        const emfSheetName = "test" + sheet.getName() + " Page" + (j + 1) + ".out.emf";
        sr.toImage(j, emfSheetName);

        // फ़ाइल को जैसा है वैसा जोड़ें ताकि चित्र रास्टराइज़ किए बिना एक वेक्टर EMF बना रहे।
        let picture;
        const imageStream = java.newInstanceSync("java.io.FileInputStream", emfSheetName);
        try {
            picture = pres.getImages().addImage(imageStream);
        } finally {
            imageStream.close();
        }

        const slide = pres.getSlides().addEmptySlide(
            pres.getLayoutSlides().getByType(aspose.slides.SlideLayoutType.Blank));
        slide.getShapes().addPictureFrame(
            aspose.slides.ShapeType.Rectangle,
            0,
            0,
            pres.getSlideSize().getSize().getWidth(),
            pres.getSlideSize().getSize().getHeight(),
            picture);
    }

    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **इमेज कलेक्शन में छवियों को बदलें**

Aspose.Slides आपको प्रस्तुति की इमेज कलेक्शन में संग्रहीत छवियों को बदलने की अनुमति देता है, जिसमें स्लाइड आकृतियों द्वारा उपयोग की गई छवियां भी शामिल हैं। यह अनुभाग कलेक्शन में छवियों को अपडेट करने के कई तरीकों का विवरण देता है। आप कच्चे बाइट डेटा, एक [IImage](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/iimage/) इंस्टेंस, या कलेक्शन में पहले से मौजूद किसी अन्य छवि का उपयोग करके छवि बदल सकते हैं।

निम्नलिखित चरणों का पालन करें:
1. छवियों वाली प्रस्तुति फ़ाइल को [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) क्लास का उपयोग करके लोड करें।
1. फ़ाइल से नई छवि को बाइट एरे में लोड करें।
1. बाइट एरे का उपयोग करके लक्ष्य छवि को नई छवि से बदलें।
1. दूसरे तरीके में, छवि को [IImage](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/iimage/) ऑब्जेक्ट में लोड करें और लक्ष्य छवि को उस ऑब्जेक्ट से बदलें।
1. तीसरे तरीके में, लक्ष्य छवि को प्रस्तुति की इमेज कलेक्शन में पहले से मौजूद छवि से बदलें।
1. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");
const java = require("java");

// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का इंस्टांस बनाएं।
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    // पहला तरीका।
    const imageData = java.newArray("byte", Array.from(fs.readFileSync("image0.jpeg")));
    let oldImage = presentation.getImages().get_Item(0);
    oldImage.replaceImage(imageData);

    // दूसरा तरीका।
    const newImage = aspose.slides.Images.fromFile("image1.png");
    try {
        oldImage = presentation.getImages().get_Item(1);
        oldImage.replaceImage(newImage);
    } finally {
        if (newImage != null) {
            newImage.dispose();
        }
    }

    // तीसरा तरीका।
    oldImage = presentation.getImages().get_Item(2);
    oldImage.replaceImage(presentation.getImages().get_Item(3));

    // प्रस्तुति को फ़ाइल में सहेजें।
    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="Info" color="info" %}}
Aspose के मुफ्त [Text to GIF](https://products.aspose.app/slides/hi/text-to-gif) रूपांतरणक का उपयोग करके आप आसानी से टेक्स्ट को एनीमेट कर सकते हैं और टेक्स्ट से GIF बना सकते हैं। 
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या सम्मिलित करने के बाद मूल छवि रिज़ॉल्यूशन अपरिवर्तित रहता है?**  
हां। स्रोत पिक्सेल संरक्षित रहते हैं, लेकिन अंतिम दिखावट इस पर निर्भर करती है कि स्लाइड पर [picture](/slides/hi/nodejs-java/picture-frame/) कैसे स्केल किया गया है और सेव पर लागू कोई भी संपीड़न।

**एक साथ दर्जनों स्लाइड्स में वही लोगो बदलने का सबसे अच्छा तरीका क्या है?**  
लोगो को मास्टर स्लाइड या लेआउट पर रखें और इसे प्रस्तुति की इमेज कलेक्शन में बदलें—अपडेट्स उन सभी तत्वों तक फैलेंगे जो उस संसाधन का उपयोग करते हैं।

**क्या सम्मिलित SVG को संपादन योग्य आकृतियों में बदला जा सकता है?**  
हां। आप SVG को आकारों के समूह में परिवर्तित कर सकते हैं, जिससे व्यक्तिगत भाग मानक आकार गुणों के साथ संपादन योग्य बन जाते हैं।

**मैं एक साथ कई स्लाइड्स के पृष्ठभूमि के रूप में चित्र कैसे सेट कर सकता हूँ?**  
[छवि को पृष्ठभूमि के रूप में असाइन करें](/slides/hi/nodejs-java/presentation-background/) मास्टर स्लाइड या संबंधित लेआउट पर—उस मास्टर/लेआउट का उपयोग करने वाली सभी स्लाइड्स पृष्ठभूमि को विरासत में लेगी।

**बहुत अधिक चित्रों के कारण प्रस्तुति बहुत बड़ी होने से कैसे रोकें?**  
डुप्लिकेट के बजाय एक ही छवि संसाधन को पुन: उपयोग करें, उचित रिज़ॉल्यूशन चुनें, सेव पर संपीड़न लागू करें, और जहाँ उपयुक्त हो दोहराव वाले ग्राफिक्स को मास्टर पर रखें।