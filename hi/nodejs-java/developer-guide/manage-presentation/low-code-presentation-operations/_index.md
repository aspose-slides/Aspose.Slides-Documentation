---
title: जावास्क्रिप्ट में लो-कोड प्रस्तुति संचालन
linktitle: लो-कोड API
type: docs
weight: 50
url: /hi/nodejs-java/low-code-presentation-operations/
keywords:
- लो-कोड प्रस्तुति API
- प्रस्तुति परिवर्तित करें
- प्रस्तुतियों को मिलाएँ
- स्लाइड्स पर दोहराएँ
- शेप्स पर दोहराएँ
- टेक्स्ट पर दोहराएँ
- शेप्स एकत्र करें
- प्रस्तुति संपीड़ित करें
- अनउपयोगी मास्टर स्लाइड्स हटाएँ
- अनउपयोगी लेआउट स्लाइड्स हटाएँ
- एम्बेडेड फ़ॉन्ट्स संपीड़ित करें
- PowerPoint
- OpenDocument
- प्रस्तुति
- Node.js
- जावास्क्रिप्ट
- Aspose.Slides
description: "जावास्क्रिप्ट में Aspose.Slides लो-कोड API का उपयोग करके प्रस्तुतियों को परिवर्तित और मिलाएँ, सामग्री में दोहराएँ, शेप्स एकत्र करें, और प्रस्तुति का आकार घटाएँ।"
---
## **अवलोकन**

`aspose.slides` नेमस्पेस सामान्य प्रस्तुति कार्यों के लिए स्थैतिक हेल्पर क्लासेस प्रदान करता है। ये हेल्पर अक्सर उपयोग किए जाने वाले ऑब्जेक्ट-मॉडल वर्कफ़्लो को केंद्रित मेथड्स में लपेटते हैं, जिससे आप फ़ाइलों को परिवर्तित या मिश्रित कर सकते हैं, प्रस्तुति तत्वों को प्रोसेस कर सकते हैं, शेप्स एकत्र कर सकते हैं, और कम कोड के साथ उपयोग न किए गए कंटेंट को हटाकर सकते हैं।

लो-कोड हेल्पर तब सबसे उपयोगी होते हैं जब ऑपरेशन पूरे फ़ाइल या प्रस्तुति पर लागू होता है और डिफ़ॉल्ट वर्कफ़्लो आपकी आवश्यकताओं से मेल खाता है। जब आपको व्यक्तिगत स्लाइड्स, मास्टर्स, लेआउट्स, शेप्स, एक्सपोर्ट सेटिंग्स, या प्रस्तुति तत्वों के बीच संबंधों पर सूक्ष्म नियंत्रण चाहिए तो पूरे [Aspose.Slides object model](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/) का उपयोग करें।

निम्न तालिका उपलब्ध हेल्पर्स का सारांश देती है:

| Helper | Use it for |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/convert/) | एक प्रस्तुति को सीधे फ़ाइल-से-फ़ाइल कॉल के साथ अन्य फ़ॉर्मेट में कनवर्ट करना। |
| [Merger](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/merger/) | उसी फ़ॉर्मेट की पूरी प्रस्तुति फ़ाइलों को मिलाना। |
| [ForEach](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/foreach/) | हर स्लाइड, शेप, पैराग्राफ, या टेक्स्ट पोर्शन के लिए एक्शन चलाना। |
| [Collect](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/collect/) | पूरी प्रस्तुति से शेप्स को पुनः-प्रसंस्करण या विश्लेषण के लिए प्राप्त करना। |
| [Compress](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/compress/) | अनुपयोगी मास्टर और लेआउट को हटाना और एम्बेडेड फ़ॉन्ट डेटा को घटाना। |

## **एक प्रस्तुति को कनवर्ट करें**

[Convert.autoByExtension](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/convert/#autoByExtension) का उपयोग तब करें जब आउटपुट फ़ाइल एक्सटेंशन निर्यात फ़ॉर्मेट चुनने के लिए पर्याप्त हो। यह मेथड स्रोत प्रस्तुति को खोलता है, आउटपुट पथ से आवश्यक फ़ॉर्मेट निर्धारित करता है, और परिणाम लिखता है।

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

aspose.slides.Convert.autoByExtension("input.pptx", "output.pdf");
```

[Convert](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/convert/) क्लास PDF, SVG, JPEG, PNG, और TIFF आउटपुट के लिए भी समर्पित मेथड्स प्रदान करती है। जब आपको निर्यात से पहले प्रस्तुति को निरीक्षण या संशोधित करना हो या ऐसी निर्यात विकल्प कॉन्फ़िगर करना हो जो चयनित हेल्पर द्वारा उपलब्ध नहीं है, तब पूरे ऑब्जेक्ट मॉडल का उपयोग करें। स्वरूप-विशिष्ट वर्कफ़्लो और विकल्पों के लिए देखें [Convert Presentation](/nodejs-java/convert-presentation/)।

## **प्रेजेंटेशन को मिलाएँ**

[Merger.process](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/merger/#process) का उपयोग करके एक कॉल में पूरी प्रस्तुति फ़ाइलों को मिलाया जा सकता है। इनपुट प्रस्तुतियों का फ़ाइल फ़ॉर्मेट समान होना चाहिए।

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const inputFiles = ["first.pptx", "second.pptx"];
aspose.slides.Merger.process(inputFiles, "merged.pptx");
```

यह हेल्पर तब उपयुक्त होता है जब सभी स्लाइड्स को व्यक्तिगत रूप से चयन या रीमैप किए बिना एक परिणाम में जोड़ना हो। जब आपको चयनित स्लाइड्स को मिलाना हो, लक्ष्य मास्टर या लेआउट लागू करना हो, सेक्शन को स्पष्ट रूप से संरक्षित करना हो, या विभिन्न स्लाइड आकारों को संरेखित करना हो, तो पूरे ऑब्जेक्ट मॉडल का उपयोग करें। उन परिस्थितियों के लिए देखें [Merge Presentations](/nodejs-java/merge-presentation/)।

## **प्रेजेंटेशन तत्वों पर पुनरावृत्ति करें**

[ForEach](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/foreach/) क्लास प्रत्येक अनुरोधित प्रेजेंटेशन तत्व प्रकार के लिए कॉलबैक को बुलाती है। यह नेस्टेड कलेक्शन लूप्स से बचती है और पूरी प्रस्तुति में निरीक्षण या फॉर्मेटिंग परिवर्तन के लिए सुविधाजनक है। Node.js में, `java.newProxy` के साथ कॉलबैक इंटरफ़ेस के इम्प्लीमेंटेशन बनाएं।

निम्न उदाहरण में संबंधित तत्वों का निरीक्षण करने के लिए [ForEach.slide](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/foreach/#slide), [ForEach.shape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/foreach/#shape), [ForEach.paragraph](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/foreach/#paragraph), और [ForEach.portion](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/foreach/#portion) का उपयोग किया गया है:

```javascript
const java = require("java");
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slideCallback = java.newProxy("com.aspose.slides.ForEach$ForEachSlideCallback", {
        invoke: function (slide, index) {
            console.log(`Slide ${index}: ${slide.getShapes().size()} shapes`);
        }
    });
    aspose.slides.ForEach.slide(presentation, slideCallback);

    const shapeCallback = java.newProxy("com.aspose.slides.ForEach$ForEachShapeCallback", {
        invoke: function (shape, slide, index) {
            console.log(`Shape ${index} on ${slide.getClass().getSimpleName()}: ${shape.getName()}`);
        }
    });
    aspose.slides.ForEach.shape(presentation, shapeCallback);

    const paragraphCallback = java.newProxy("com.aspose.slides.ForEach$ForEachParagraphCallback", {
        invoke: function (paragraph, slide, index) {
            console.log(`Paragraph ${index} on ${slide.getClass().getSimpleName()}: ${paragraph.getText()}`);
        }
    });
    aspose.slides.ForEach.paragraph(presentation, paragraphCallback);

    const portionCallback = java.newProxy("com.aspose.slides.ForEach$ForEachPortionCallback", {
        invoke: function (portion, paragraph, slide, index) {
            console.log(`Portion ${index} on ${slide.getClass().getSimpleName()}: ${portion.getText()}`);
        }
    });
    aspose.slides.ForEach.portion(presentation, portionCallback);
} finally {
    presentation.dispose();
}
```

डिफ़ॉल्ट रूप से, पूरी प्रस्तुति में शेप और टेक्स्ट ट्रैवर्सल सामान्य, मास्टर और लेआउट स्लाइड्स को शामिल करता है। `includeNotes` पैरामीटर वाले ओवरलोड नोट्स स्लाइड्स को भी प्रोसेस कर सकते हैं। जब ट्रैवर्सल क्रम, शीघ्र निकास, कॉलबैक बुलाने से पहले फ़िल्टरिंग, या विस्तृत पैरेंट‑चाइल्ड नियंत्रण महत्वपूर्ण हो, तो सीधे कलेक्शन लूप्स का उपयोग करें।

## **शेप्स एकत्र करें**

जब आपको प्रत्येक शेप के लिए कॉलबैक के बजाय प्रस्तुति में सभी शेप्स का संग्रह चाहिए, तो [Collect.shapes](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/collect/#shapes) का उपयोग करें। यह तब उपयोगी है जब उसी सेट को कई बार फ़िल्टर, गिना या प्रोसेस किया जाना हो।

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const shapes = aspose.slides.Collect.shapes(presentation);
    const iterator = shapes.iterator();

    while (iterator.hasNext()) {
        const shape = iterator.next();
        console.log(`${shape.getName()}: ${shape.getClass().getSimpleName()}`);
    }
} finally {
    presentation.dispose();
}
```

जब प्रत्येक शेप को तुरंत संभाल सकते हैं और आपको एकत्रित परिणाम रखने की आवश्यकता नहीं है, तब इसके बजाय [ForEach.shape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/foreach/#shape) का उपयोग करें।

## **प्रेजेंटेशन सामग्री को संपीड़ित करें**

[Compress](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/compress/) क्लास उपयोग न किए गए संरचनात्मक तत्वों को हटाकर और एम्बेडेड फ़ॉन्ट डेटा को घटाकर काम कर सकती है:

- [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides) सामान्य स्लाइड द्वारा संदर्भित नहीं किए गए लेआउट स्लाइड्स को हटाता है।
- [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/compress/#removeUnusedMasterSlides) उन मास्टर स्लाइड्स को हटाता है जो अब उपयोग में नहीं हैं।
- [Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/compress/#compressEmbeddedFonts) एम्बेडेड फ़ॉन्ट्स से उपयोग न किए गए अक्षरों को हटाता है।

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    aspose.slides.Compress.removeUnusedLayoutSlides(presentation);
    aspose.slides.Compress.removeUnusedMasterSlides(presentation);
    aspose.slides.Compress.compressEmbeddedFonts(presentation);

    presentation.save("compressed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

पहले उपयोग न किए गए लेआउट्स को हटाएँ, फिर उपयोग न किए गए मास्टर को, ताकि लेआउट साफ़ करने के बाद जो मास्टर अप्रचलित हो गया है, वह भी हटाया जा सके। यदि आपको बाद में मूल मास्टर, लेआउट या पूर्ण एम्बेडेड फ़ॉन्ट डेटा की आवश्यकता हो सकती है, तो अनुकूलित प्रेजेंटेशन को नई फ़ाइल में सहेजें। अधिक विवरण के लिए देखें [Slide Master](/nodejs-java/slide-master/) और [Embedded Font](/nodejs-java/embedded-font/)।

## **FAQ**

**जब मुझे पूरी ऑब्जेक्ट मॉडल के बजाय लो-कोड API का उपयोग करना चाहिए?**

जब एक मानक ऑपरेशन पूरी फ़ाइल या प्रस्तुति पर लागू हो और व्यक्तिगत तत्वों पर विस्तृत नियंत्रण की आवश्यकता न हो, तब लो-कोड हेल्पर का उपयोग करें। जब आपको विशिष्ट स्लाइड्स का चयन करना हो, मास्टर और लेआउट संबंधों को नियंत्रित करना हो, मध्यवर्ती स्थिति को निरीक्षण करना हो, या ऐसे व्यवहार को कॉन्फ़िगर करना हो जो हेल्पर नहीं दिखाता, तब पूरी ऑब्जेक्ट मॉडल का उपयोग करें।

**क्या Merger विभिन्न फ़ाइल फ़ॉर्मेट में प्रस्तुतियों को संयोजित कर सकता है?**

नहीं। [Merger.process](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/merger/#process) को इनपुट प्रस्तुतियों का फ़ॉर्मेट समान चाहिए। पहले इनपुट फ़ाइलों को सामान्य फ़ॉर्मेट में परिवर्तित करें, उदाहरण के लिए [Convert.autoByExtension](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/convert/#autoByExtension) से, और फिर परिवर्तित फ़ाइलों को मिलाएँ।

**क्या ForEach मास्टर, लेआउट और नोट्स स्लाइड्स को प्रोसेस करता है?**

[ForEach.slide](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/foreach/#slide) सामान्य प्रेजेंटेशन स्लाइड्स पर इटरेट करता है। पूरी प्रस्तुति में [ForEach.shape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/foreach/#shape), [ForEach.paragraph](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/foreach/#paragraph), और [ForEach.portion](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/foreach/#portion) ऑपरेशन डिफ़ॉल्ट रूप से सामान्य, मास्टर और लेआउट स्लाइड्स को शामिल करते हैं। नोट्स स्लाइड्स को शामिल करने के लिए `includeNotes` को `true` सेट करने वाले ओवरलोड का उपयोग करें।

**ForEach.shape और Collect.shapes में क्या अंतर है?**

प्रत्येक शेप को तुरंत कॉलबैक के माध्यम से प्रोसेस करने के लिए [ForEach.shape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/foreach/#shape) का उपयोग करें। जब आपको एक इटेरेबल परिणाम चाहिए जो रखा, फ़िल्टर किया, गिना या कई बार ट्रैवर्स किया सके, तब [Collect.shapes](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/collect/#shapes) का उपयोग करें।

**क्या Compress हमेशा प्रेजेंटेशन फ़ाइल को छोटा बनाता है?**

ज़रूरी नहीं। परिणाम इस बात पर निर्भर करता है कि प्रस्तुति में अनउपयोगित लेआउट्स, अनउपयोगित मास्टर या अनउपयोगित अक्षरों वाले एम्बेडेड फ़ॉन्ट्स हैं या नहीं। यदि इनमें से कोई भी नहीं है, तो संबंधित [Compress](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/compress/) ऑपरेशन फ़ाइल आकार को घटा नहीं सकते।

**क्या ForEach या Compress द्वारा किए गए परिवर्तन स्वतः सहेजे जाते हैं?**

नहीं। ये हेल्पर मेमोरी में लोड किए गए [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) ऑब्जेक्ट पर काम करते हैं। एक [ForEach](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/foreach/) कॉलबैक में तत्व बदलने या [Compress](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/compress/) चलाने के बाद, परिणाम को लिखने के लिए [Presentation.save](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/#save) को कॉल करें।

## **संबंधित लेख**

- [प्रेजेंटेशन परिवर्तित करें](/nodejs-java/convert-presentation/)
- [प्रेजेंटेशन मिलाएँ](/nodejs-java/merge-presentation/)
- [स्लाइड मास्टर](/nodejs-java/slide-master/)
- [टेक्स्ट बॉक्स प्रबंधित करें](/nodejs-java/manage-textbox/)
- [एम्बेडेड फ़ॉन्ट](/nodejs-java/embedded-font/)