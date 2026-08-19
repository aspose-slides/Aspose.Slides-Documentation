---
title: जावास्क्रिप्ट का उपयोग करके प्रस्तुतियों में इमेज प्रबंधन को अनुकूलित करें
linktitle: इमेज प्रबंधित करें
type: docs
weight: 10
url: /hi/nodejs-java/image/
keywords:
- इमेज जोड़ें
- चित्र जोड़ें
- इमेज बदलें
- इमेज संग्रह
- चित्र फ्रेम
- लिंक्ड इमेज
- पृष्ठभूमि
- PNG जोड़ें
- JPG जोड़ें
- SVG जोड़ें
- SVG को शेप्स में बदलें
- बाहरी SVG रिसोर्सेज़
- PowerPoint
- OpenDocument
- प्रेजेंटेशन
- Node.js
- जावास्क्रिप्ट
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java के साथ PowerPoint और OpenDocument प्रस्तुतियों में रास्टर और SVG इमेजेज़ को जोड़ना, पुन: उपयोग करना, लिंक करना, बदलना और प्रबंधित करना सीखें।"
---
## **परिचय**

Aspose.Slides for Node.js via Java कई तरीकों से इमेज के साथ काम करने की सुविधा प्रदान करता है, और प्रत्येक का अलग उद्देश्य है। आप एक इमेज को प्रेजेंटेशन में संग्रहीत कर सकते हैं, उसे पिक्चर फ्रेम में प्रदर्शित कर सकते हैं, स्लाइड बैकग्राउंड के रूप में उपयोग कर सकते हैं, बाहरी इमेज से लिंक कर सकते हैं, साझा इमेज रिसोर्स को बदल सकते हैं, या SVG सामग्री को एडिटेबल शेप्स में बदल सकते हैं।

यह लेख इमेज रिसोर्सेज और उनके प्रेजेंटेशन में उपयोग पर केंद्रित है। व्यक्तिगत पिक्चर फ्रेम पर लागू होने वाले क्रॉपिंग, ट्रांसपरेंसी, इफ़ेक्ट्स, स्ट्रेचिंग और अन्य फॉर्मैटिंग के लिए, देखें [Picture Frame](/slides/hi/nodejs-java/picture-frame/)।

## **इमेज मॉडल को समझें**

निम्नलिखित API अवधारणाएँ निकटतम रूप से संबंधित हैं लेकिन बदलनीय नहीं हैं:

- प्रेजेंटेशन इमेज कलेक्शन प्रस्तुति में उपयोग किए गए इमेज रिसोर्सेज को संग्रहीत करता है। इमेज डेटा जोड़ने और एक [PPImage](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ppimage/) रिसोर्स प्राप्त करने के लिए [ImageCollection.addImage](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/imagecollection/) का उपयोग करें।
- एक [picture frame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/pictureframe/) एक आकार (shape) है जो स्लाइड, लेआउट या मास्टर पर इमेज दिखाता है। स्लाइड पर इमेज रिसोर्स रखने के लिए [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/shapecollection/) का उपयोग करें।
- स्लाइड बैकग्राउंड इमेज को स्लाइड फ़िल का भाग बनाकर उपयोग करता है, न कि एक आकार के रूप में। इसलिए यह पिक्चर फ्रेम की तरह व्यवहार नहीं करता।
- [PPImage.replaceImage](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ppimage/) एक इमेज रिसोर्स को बदलता है। यदि कई प्रेजेंटेशन तत्व उस रिसोर्स का उपयोग करते हैं, तो सभी प्रतिस्थापन का उपयोग करेंगे।
- SVG को शेप्स में बदलने से एडिटेबल स्लाइड शेप्स बनते हैं। परिवर्तन के बाद, सामग्री अब एक पिक्चर रिसोर्स के रूप में प्रबंधित नहीं रहती।

एक सामान्य कार्य प्रवाह इस प्रकार है: इमेज डेटा को इमेज कलेक्शन में जोड़ें, एक [PPImage](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ppimage/) प्राप्त करें, और फिर उस रिसोर्स को एक या अधिक पिक्चर फ्रेम या फ़िल में उपयोग करें।

## **एक एंबेडेड इमेज जोड़ें**

स्थानीय इमेज डालने के लिए, फ़ाइल लोड करें, उसे इमेज कलेक्शन में जोड़ें, और एक पिक्चर फ्रेम बनाएं जो लौटाए गए [PPImage](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ppimage/) रिसोर्स का उपयोग करता है।

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    let image;
    const sourceImage = aspose.slides.Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        if (sourceImage != null) {
            sourceImage.dispose();
        }
    }

    const slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 20, 320, 180, image);

    presentation.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

इस प्रकार जोड़ी गई इमेज प्रेजेंटेशन में एंबेडेड होती है, इसलिए अंतिम फ़ाइल मूल इमेज फ़ाइल की उपलब्धता पर निर्भर नहीं करती।

### **वेब से इमेज जोड़ें**

जब इमेज HTTP या HTTPS के माध्यम से उपलब्ध हो, तो उसके बाइट्स डाउनलोड करें, उन्हें प्रेजेंटेशन इमेज कलेक्शन में जोड़ें, और लौटाए गए इमेज रिसोर्स का स्थानीय इमेज की तरह उपयोग करें।

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const http = require("http");
const https = require("https");
const java = require("java");

function downloadBytes(url) {
    return new Promise((resolve, reject) => {
        const client = url.startsWith("https:") ? https : http;
        client.get(url, (response) => {
            if (response.statusCode < 200 || response.statusCode >= 300) {
                response.resume();
                reject(new Error(`HTTP ${response.statusCode}`));
                return;
            }

            const chunks = [];
            response.on("data", (chunk) => chunks.push(chunk));
            response.on("end", () => resolve(Buffer.concat(chunks)));
        }).on("error", reject);
    });
}

(async () => {
    const imageData = await downloadBytes("https://example.com/image.png");
    const javaBytes = java.newArray("byte", Array.from(imageData));

    const presentation = new aspose.slides.Presentation();
    try {
        const image = presentation.getImages().addImage(javaBytes);
        const slide = presentation.getSlides().get_Item(0);
        slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 20, 320, 180, image);

        presentation.save("presentation-from-web.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
})();
```

दीर्घकालिक अनुप्रयोगों में, अनुप्रयोग के अनुसार उपयुक्त HTTP क्लाइंट या कनेक्शन-प्रबंधन रणनीति को पुन: उपयोग करें, बजाय बार-बार अनावश्यक नेटवर्किंग इन्फ्रास्ट्रक्चर बनाने के। साथ ही जब स्रोत विश्वसनीय न हो, तो रिमोट URL, रिस्पॉन्स साइज और कंटेंट टाइप्स को सत्यापित करें।

## **स्लाइड्स के बीच इमेजेज़ का पुन: उपयोग**

यदि वही इमेज कई बार चाहिए, तो इसे प्रेजेंटेशन में एक बार जोड़ें और अतिरिक्त पिक्चर फ्रेम बनाते समय लौटाए गए [PPImage](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ppimage/) का पुन: उपयोग करें। इससे एक ही स्रोत डेटा को बार-बार लोड करने से बचा जा सकता है और साझा इमेज रिसोर्स और उसके उपयोग के बीच संबंध स्पष्ट हो जाता है।

कंपनी लोगो जैसे ग्राफिक्स जो कई स्लाइड्स पर स्वतः दिखने चाहिए, उनके लिए पिक्चर फ्रेम को एक [slide master](/slides/hi/nodejs-java/slide-master/) या लेआउट पर रखने पर विचार करें, बजाय प्रत्येक स्लाइड में समान आकार जोड़ने के।

## **इमेज को स्लाइड बैकग्राउंड के रूप में उपयोग करें**

बैकग्राउंड इमेज स्लाइड फ़िल को असाइन की जाती है; इसे पिक्चर-फ़्रेम आकार के रूप में नहीं जोड़ा जाता। यह तब उपयोगी है जब चित्र को स्लाइड बैकग्राउंड पर पूरा कवर करना हो और इसे सामान्य स्लाइड ऑब्जेक्ट की तरह संशोधित नहीं किया जाना चाहिए।

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("background.jpg");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        if (sourceImage != null) {
            sourceImage.dispose();
        }
    }

    const backgroundType = java.newByte(aspose.slides.BackgroundType.OwnBackground);
    slide.getBackground().setType(backgroundType);

    const fillType = java.newByte(aspose.slides.FillType.Picture);
    slide.getBackground().getFillFormat().setFillType(fillType);

    slide.getBackground().getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);
    slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().setImage(image);

    presentation.save("background-image.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

अतिरिक्त बैकग्राउंड विकल्पों के लिए, जिसमें मास्टर और लेआउट बैकग्राउंड शामिल हैं, देखें [Presentation Background](/slides/hi/nodejs-java/presentation-background/)।

## **एंबेडेड इमेजेज़ और लिंक्ड इमेजेज़**

एंबेडेड और लिंक्ड इमेजेज़ के अलग-अलग पोर्टेबिलिटी और फ़ाइल-साइज़ ट्रेडऑफ़ हैं:

- **एंबेडेड इमेज:** इमेज डेटा प्रेजेंटेशन के भीतर संग्रहीत रहता है। प्रेजेंटेशन स्व-समाहित है, लेकिन फ़ाइल आकार में इमेज डेटा भी शामिल होता है।
- **लिंक्ड इमेज:** प्रेजेंटेशन बाहरी इमेज का पाथ या URL संग्रहीत करता है। इससे प्रेजेंटेशन का आकार घट सकता है, परन्तु जब प्रेजेंटेशन खोला या रेंडर किया जाए तो बाहरी रिसोर्स उपलब्ध रहना चाहिए।

एक लिंक्ड पिक्चर को बाहरी पाथ या URL को [Picture.setLinkPathLong](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/picture/) के माध्यम से असाइन करके बनाया जा सकता है, बजाय इमेज डेटा को एंबेड करने के।

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 20, 320, 180, null);
    pictureFrame.getPictureFormat().getPicture().setLinkPathLong("https://example.com/image.png");

    presentation.save("linked-image.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

केवल तब लिंक्ड इमेजेज़ का उपयोग करें जब डिप्लॉयमेंट पर्यावरण बाहरी रिसोर्स को विश्वसनीय रूप से एक्सेस कर सके। उन प्रेजेंटेशन्स के लिए जो ऑफलाइन काम करने या सिस्टमों के बीच स्थानांतरित होने चाहिए, एंबेडेड इमेजेज़ आमतौर पर सुरक्षित होते हैं।

## **SVG इमेजेज़ के साथ काम करना**

SVG एक वेक्टर फ़ॉर्मेट है, इसलिए यह आइकॉन, डायग्राम और अन्य ग्राफिक्स के लिए उपयोगी हो सकता है जिन्हें रास्टर इमेजेज़ की तरह विवरण का नुकसान हुए बिना स्केल किया जा सके। Aspose.Slides SVG को इमेज रिसोर्स और एडिटेबल स्लाइड शेप्स के स्रोत दोनों रूप में समर्थन करता है।

### **SVG को इमेज के रूप में जोड़ें**

एक [SvgImage](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/svgimage/) बनाएं, उसे इमेज कलेक्शन में जोड़ें, और परिणामी इमेज रिसोर्स को पिक्चर फ्रेम में रखें।

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation();
try {
    const svgContent = fs.readFileSync("icon.svg", "utf8");
    const svgImage = new aspose.slides.SvgImage(svgContent);

    const image = presentation.getImages().addImage(svgImage);
    const slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 20, 200, 200, image);

    presentation.save("svg-image.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **बाहरी रिसोर्सेज़ वाले SVG फ़ाइलें**

एक SVG बाहरी इमेजेज़, स्टाइलशीट्स या फ़ॉन्ट्स को रेफ़र कर सकता है। ऐसे मामलों में, [SvgImage](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/svgimage/) ऐसे कन्स्ट्रक्टर प्रदान करता है जो एक [ExternalResourceResolver](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/externalresourceresolver/) और बेस URI को स्वीकार करता है। रिज़ॉल्वर सापेक्ष URI को अनुमति प्राप्त पूर्ण URI में मैप कर सकता है और अनुरोधित रिसोर्स के लिए एक स्ट्रीम लौटाता है।

रिज़ॉल्वर बाहरी रिसोर्सेज़ को उपलब्ध कराता है जबकि Aspose.Slides SVG को प्रोसेस करता है, लेकिन यह SVG को स्व-निहित दस्तावेज़ में पुनः लिखता नहीं है। यदि SVG को पोर्टेबल रहना है, तो आवश्यक रिसोर्सेज़ को स्वयं SVG में एंबेड करें, उदाहरण के लिए लिंक्ड इमेजेज़ के लिए `data:` URI का उपयोग करके।

जब SVG फ़ाइलें अविश्वसनीय स्रोतों से आती हैं, तो रिज़ॉल्वर द्वारा एक्सेस किए जाने वाले स्कीम, फ़ाइल लोकेशन और होस्ट को प्रतिबंधित करें। नेटवर्क रिज़ॉल्वर को टाइमआउट, रिस्पॉन्स-साइज़ लिमिट और कंटेंट वैलिडेशन भी लागू करनी चाहिए।

### **SVG को एडिटेबल शेप्स में बदलें**

Aspose.Slides एक SVG को एडिटेबल स्लाइड शेप्स के समूह में बदल सकता है, जो संबंधित PowerPoint कमांड के समान है।

![PowerPoint पॉपअप मेन्यू](img_01_01.png)

रूपांतरण करने के लिए वह [ShapeCollection.addGroupShape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/shapecollection/) ओवरलोड उपयोग करें जो SVG इमेज को स्वीकार करता है।

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation();
try {
    const svgContent = fs.readFileSync("diagram.svg", "utf8");
    const svgImage = new aspose.slides.SvgImage(svgContent);

    const slideSize = presentation.getSlideSize().getSize();
    const slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addGroupShape(svgImage, 0, 0, slideSize.getWidth(), slideSize.getHeight());

    presentation.save("editable-svg-shapes.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

जब व्यक्तिगत वेक्टर तत्वों को PowerPoint शेप्स के रूप में संपादित करने की आवश्यकता हो तो SVG-से-शेप्स रूपांतरण का उपयोग करें। यदि SVG केवल प्रदर्शित करना ही है, तो इसे इमेज के रूप में रखना सरल है और कई अलग-अलग शेप्स बनाने से बचता है।

## **मौजूदा इमेज रिसोर्स को बदलें**

जब आप मौजूदा इमेज रिसोर्स को बदलना चाहें, तो [PPImage.replaceImage](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ppimage/) का उपयोग करें। यह विशेष रूप से साझा ग्राफिक्स जैसे लोगो के लिए उपयोगी है।

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const imageToReplace = presentation.getImages().get_Item(0);

    const replacementImage = aspose.slides.Images.fromFile("new-logo.png");
    try {
        imageToReplace.replaceImage(replacementImage);
    } finally {
        if (replacementImage != null) {
            replacementImage.dispose();
        }
    }

    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

यदि कई पिक्चर फ्रेम, बैकग्राउंड, मास्टर या लेआउट एक ही इमेज रिसोर्स का उपयोग करते हैं, तो उस रिसोर्स को बदलने से सभी उपयोग अद्यतन हो जाएंगे। यदि केवल एक पिक्चर फ्रेम बदलना है, तो साझा रिसोर्स को बदलने के बजाय उस फ्रेम को अलग इमेज असाइन करें।

[PPImage.replaceImage](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ppimage/) अतिरिक्त ओवरलोड भी प्रदान करता है जो बाइट एरे या अन्य [PPImage](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ppimage/) को स्वीकार करता है।

## **व्यावहारिक इमेज प्रबंधन मार्गदर्शन**

### **प्रेजेंटेशन आकार को नियंत्रित करें**

बड़े रास्टर इमेजेज़ प्रेजेंटेशन को अनावश्यक रूप से बड़ा बना सकते हैं। इच्छित प्रदर्शित आकार के अनुरूप डाइमेंशन वाली स्रोत इमेजेज़ का उपयोग करें, जहाँ संभव हो साझा इमेज रिसोर्सेज़ को पुन: उपयोग करें, और समान फुल-रेज़ोल्यूशन ग्राफिक की दोहराई गई कॉपियों को एंबेड करने से बचें।

उन रास्टर चित्रों के लिए जो पहले ही पिक्चर फ्रेम में रखे जा चुके हैं, [PictureFillFormat.compressImage](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/picturefillformat/) चयनित रिज़ॉल्यूशन और क्रॉप सेटिंग्स के अनुसार इमेज डेटा को कम कर सकता है। यह इमेज-कलेक्शन प्रबंधन नहीं बल्कि पिक्चर-फ़्रेम प्रोसेसिंग है, इसलिए संबंधित फॉर्मेटिंग ऑपरेशंस के लिए [Picture Frame](/slides/hi/nodejs-java/picture-frame/) देखें।

### **एंबेडेड और लिंक्ड सामग्री के बीच चयन करें**

एंबेडिंग से प्रेजेंटेशन पोर्टेबल बनता है क्योंकि सभी आवश्यक इमेज डेटा फ़ाइल के साथ रहता है। लिंकिंग फ़ाइल आकार को घटा सकता है, परन्तु यह एक बाहरी निर्भरता पेश करता है। लिंक केवल तब उपयोग करें जब वह निर्भरता स्वीकार्य और स्थिर हो।

### **साझा ब्रांडिंग का पुन: उपयोग**

बार-बार उपयोग होने वाले लोगो, वॉटरमार्क या सजावटी ग्राफिक्स के लिए एक इमेज रिसोर्स का उपयोग करें और उसे पुन: उपयोग करें। यदि ग्राफिक प्रेजेंटेशन डिजाइन से संबंधित है न कि स्लाइड कंटेंट से, तो उसे मास्टर या लेआउट पर रखें ताकि वह उपयुक्त स्लाइड्स द्वारा विरासत में मिले।

### **SVG रिसोर्सेज़ को पोर्टेबल रखें**

एक स्व-निहित SVG को ले जाना और लगातार रेंडर करना आसान है बनिस्पत उस SVG के जो बाहरी फ़ाइलों या नेटवर्क रिसोर्सेज़ पर निर्भर करता है। जहाँ संभव हो, इंपोर्ट करने से पहले आवश्यक रिसोर्सेज़ को एंबेड करें। SVG को शेप्स में तभी बदलें जब व्यक्तिगत वेक्टर तत्वों को संपादित करने की आवश्यकता हो।

### **आधुनिक क्रॉस-प्लेटफ़ॉर्म इमेज API का उपयोग करें**

नए Node.js via Java कोड के लिए, लेगेसी `java.awt.image.BufferedImage` पर आधारित सार्वजनिक API के बजाय Aspose.Slides के [IImage](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/iimage/) और [Images](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/images/) API का उपयोग करें। माइग्रेशन गाइडेंस के लिए [Modern API](/slides/hi/nodejs-java/modern-api/) देखें।

WMF और EMF को विशेष विचार की आवश्यकता होती है। जब ये फ़ॉर्मेट एक [IImage](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/iimage/) के माध्यम से पास किए जाते हैं, तो [ImageCollection.addImage](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/imagecollection/) इन्सर्ट करने से पहले मेटाफाइल को रास्टर PNG प्रतिनिधित्व में बदल देता है। यदि मेटाफाइल डेटा को संरक्षित रखना महत्वपूर्ण है, तो स्ट्रीम-आधारित [ImageCollection.addImage](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/imagecollection/) ओवरलोड का उपयोग करें। स्प्रेडशीट या अन्य उत्पादों से EMF सामग्री बनाना एक अलग इंटीग्रेशन वर्कफ़्लो है और इस लेख के दायरे में नहीं है।

## **अक्सर पूछे जाने वाले प्रश्न**

**इमेज कलेक्शन और पिक्चर फ्रेम में क्या अंतर है?**

इमेज कलेक्शन पुन: उपयोग योग्य इमेज रिसोर्सेज़ को संग्रहीत करता है। पिक्चर फ्रेम एक स्लाइड शैप है जो उन रिसोर्सेज़ में से एक को दिखाता है और क्रॉपिंग और इफ़ेक्ट्स जैसे पिक्चर-विशिष्ट फॉर्मैटिंग प्रदान करता है।

**हर जगह एक ही लोगो बदलने का सबसे अच्छा तरीका क्या है?**

यदि लोगो पहले से ही एक इमेज रिसोर्स के रूप में साझा किया गया है, तो उस रिसोर्स को [PPImage.replaceImage](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ppimage/) से बदलें। प्रेजेंटेशन-व्यापी ब्रांडिंग के लिए, लोगो को मास्टर या लेआउट पर रखना भी डुप्लिकेट स्लाइड कंटेंट को कम कर सकता है।

**किसी अन्य कंप्यूटर पर लिंक्ड इमेज क्यों गायब हो जाती है?**

लिंक्ड पिक्चर अपने बाहरी फ़ाइल या URL पर निर्भर करता है। यदि अन्य कंप्यूटर से वह रिसोर्स पहुँचा नहीं जा सकता, तो लिंक्ड इमेज उपलब्ध नहीं हो सकती। जब प्रेजेंटेशन को स्व-निहित होना आवश्यक हो, तो इमेज को एंबेड करें।

**क्या डाला गया SVG PowerPoint शेप्स के रूप में संपादित किया जा सकता है?**

हाँ। SVG को [ShapeCollection.addGroupShape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/shapecollection/) से बदलें; परिणामी समूह में एक SVG पिक्चर की बजाय एडिटेबल स्लाइड शेप्स होते हैं।

**कई इमेजेज़ वाले प्रेजेंटेशन्स को छोटे कैसे रखें?**

साझा इमेज रिसोर्सेज़ को पुन: उपयोग करें, अनावश्यक रूप से बड़े रास्टर स्रोतों से बचें, उपयुक्त रास्टर चित्रों को आवश्यकतानुसार कम करें, दोहराए गए ब्रांडिंग को मास्टर या लेआउट पर रखें, और लिंक्ड इमेजेज़ केवल तभी उपयोग करें जब बाहरी निर्भरता स्वीकार्य हो।