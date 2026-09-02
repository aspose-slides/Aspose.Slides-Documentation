---
title: जावास्क्रिप्ट में लो-कोड प्रेजेंटेशन ऑपरेशन्स
linktitle: लो-कोड API
type: docs
weight: 50
url: /hi/nodejs-java/low-code-presentation-operations/
keywords:
- लो-कोड प्रेजेंटेशन API
- प्रेजेंटेशन रूपांतरण
- प्रेजेंटेशन मर्ज
- स्लाइड्स पर इटररेट
- शेप्स पर इटररेट
- टेक्स्ट पर इटररेट
- शेप्स एकत्र करें
- प्रेजेंटेशन संपीड़ित करें
- अनुपयोगी मास्टर स्लाइड्स हटाएँ
- अनुपयोगी लेआउट स्लाइड्स हटाएँ
- एम्बेडेड फ़ॉन्ट्स संपीड़ित करें
- PowerPoint
- OpenDocument
- प्रेजेंटेशन
- Node.js
- जावास्क्रिप्ट
- Aspose.Slides
description: "जावास्क्रिप्ट में Aspose.Slides लो-कोड API का उपयोग करके प्रेजेंटेशन को रूपांतरित और मर्ज करें, सामग्री पर इटररेट करें, शेप्स एकत्र करें, और प्रेजेंटेशन का आकार घटाएँ।"
---
## **अवलोकन**

`aspose.slides` नेमस्पेस आम प्रेजेंटेशन ऑपरेशनों के लिए स्थैतिक हेल्पर क्लासेज़ प्रदान करता है। ये हेल्पर अक्सर उपयोग किए जाने वाले ऑब्जेक्ट‑मॉडल वर्कफ़्लोज़ को केंद्रित मेथड्स में लपेटते हैं, जिससे आप फ़ाइलें बदल/मर्ज कर सकते हैं, प्रेजेंटेशन तत्वों को प्रोसेस कर सकते हैं, शैप संग्रहित कर सकते हैं, और कम कोड के साथ न इस्तेमाल की गई कंटेंट हटाना संभव है।

कम कोड वाले हेल्पर सबसे उपयोगी तब होते हैं जब ऑपरेशन पूरे फ़ाइल या प्रेजेंटेशन पर लागू होता है और डिफ़ॉल्ट वर्कफ़्लो आपकी आवश्यकताओं से मेल खाता है। जब आपको व्यक्तिगत स्लाइड्स, मास्टर्स, लेआउट्स, शैप्स, निर्यात सेटिंग्स, या प्रेजेंटेशन तत्वों के बीच संबंधों पर सूक्ष्म नियंत्रण चाहिए तो पूर्ण [Aspose.Slides object model](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/) का उपयोग करें।

निम्न तालिका उपलब्ध हेल्पर्स का सारांश देती है:

| हेल्पर | उपयोग |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/convert/) | सीधे फ़ाइल‑से‑फ़ाइल कॉल के साथ प्रेजेंटेशन को दूसरे फ़ॉर्मेट में परिवर्तित करना। |
| [Merger](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/merger/) | एक ही फ़ॉर्मेट की पूर्ण प्रेजेंटेशन फ़ाइलों को मिलाना। |
| [ForEach](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/foreach/) | प्रत्येक स्लाइड, शैप, पैराग्राफ, या टेक्स्ट भाग के लिए एक्शन चलाना। |
| [Collect](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/collect/) | दोहराए जाने वाले प्रसंस्करण या विश्लेषण के लिए पूरे प्रेजेंटेशन से शैप्स प्राप्त करना। |
| [Compress](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/compress/) | अनुपयोगी मास्टर्स और लेआउट्स को हटाना और एम्बेडेड फ़ॉन्ट डेटा को कम करना। |

## **प्रेजेंटेशन को कनवर्ट करें**

जब आउटपुट फ़ाइल एक्सटेंशन निर्यात फ़ॉर्मेट चुनने के लिए पर्याप्त हो, तब [Convert.autoByExtension](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/convert/#autoByExtension) का उपयोग करें। यह मेथड स्रोत प्रेजेंटेशन खोलता है, आउटपुट पाथ से आवश्यक फ़ॉर्मेट निर्धारित करता है, और परिणाम लिखता है।

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

aspose.slides.Convert.autoByExtension("input.pptx", "output.pdf");
```

[Convert](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/convert/) क्लास PDF, SVG, JPEG, PNG, और TIFF आउटपुट के लिए समर्पित मेथड्स भी प्रदान करती है। जब आपको निर्यात से पहले प्रेजेंटेशन की जाँच या संशोधन करना हो या किसी ऐसे निर्यात विकल्प को कॉन्फ़िगर करना हो जो चयनित हेल्पर द्वारा उजागर नहीं किया गया हो, तो पूर्ण ऑब्जेक्ट मॉडल का उपयोग करें। फ़ॉर्मेट‑विशिष्ट वर्कफ़्लोज़ और विकल्पों के लिए [Convert Presentation](/slides/hi/nodejs-java/convert-presentation/) देखें।

## **प्रेजेंटेशन मर्ज करें**

[Merger.process](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/merger/#process) का उपयोग एक कॉल में पूर्ण प्रेजेंटेशन फ़ाइलों को मिलाने के लिए करें। इनपुट प्रेजेंटेशन्स का फ़ाइल फ़ॉर्मेट समान होना चाहिए।

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const inputFiles = ["first.pptx", "second.pptx"];
aspose.slides.Merger.process(inputFiles, "merged.pptx");
```

यह हेल्पर तब उपयुक्त है जब सभी स्लाइड्स को व्यक्तिगत चयन या पुनःमैपिंग के बिना एक परिणाम में जोड़ना हो। जब आपको चयनित स्लाइड्स को मर्ज करना हो, लक्ष्य मास्टर या लेआउट लागू करना हो, सेक्शन स्पष्ट रूप से संरक्षित करने हों, या अलग‑अलग स्लाइड आकारों को सामंजस्य करना हो, तो पूर्ण ऑब्जेक्ट मॉडल का उपयोग करें। ऐसे परिदृश्यों के लिए [Merge Presentations](/slides/hi/nodejs-java/merge-presentation/) देखें।

## **प्रेजेंटेशन तत्वों पर इटररेट करें**

[ForEach](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/foreach/) क्लास प्रत्येक अनुरोधित प्रेजेंटेशन तत्व प्रकार के लिए एक कॉलबैक को कॉल करती है। यह नेस्टेड कलेक्शन लूप्स से बचाती है और प्रेजेंटेशन‑व्यापी निरीक्षण या फॉर्मेटिंग बदलावों के लिए सुविधाजनक है। Node.js में, `java.newProxy` के साथ कॉलबैक इंटरफ़ेसेस के इम्प्लीमेंटेशन बनाएं।

निम्न उदाहरण [ForEach.slide](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/foreach/#slide), [ForEach.shape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/foreach/#shape), [ForEach.paragraph](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/foreach/#paragraph), और [ForEach.portion](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/foreach/#portion) का उपयोग करके संबंधित तत्वों का निरीक्षण करता है:

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

डिफ़ॉल्ट रूप से, प्रेजेंटेशन‑व्यापी शैप और टेक्स्ट ट्रैवर्सल सामान्य, मास्टर और लेआउट स्लाइड्स को शामिल करता है। `includeNotes` पैरामीटर वाले ओवरलोड्स नोट्स स्लाइड्स को भी प्रोसेस कर सकते हैं। जब ट्रैवर्सल क्रम, शीघ्र निकास, कॉलबैक कॉल से पहले फ़िल्टरिंग, या विस्तृत पैरेंट‑चाइल्ड कंट्रोल महत्वपूर्ण हो, तो प्रत्यक्ष कलेक्शन लूप्स का उपयोग करें।

## **शेप्स एकत्र करें**

जब आपको प्रत्येक शैप के लिए कॉलबैक के बजाय प्रेजेंटेशन में सभी शैप्स का संग्रह चाहिए, तो [Collect.shapes](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/collect/#shapes) का उपयोग करें। यह तब उपयोगी है जब वही सेट कई बार फ़िल्टर, गिनती या प्रोसेस किया जाएगा।

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

जब प्रत्येक शैप को तुरंत प्रोसेस किया जा सकता है और आपको संग्रहित परिणाम को बनाए रखने की जरूरत नहीं है, तो इसके बजाय [ForEach.shape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/foreach/#shape) का उपयोग करें।

## **प्रेजेंटेशन सामग्री को संकुचित करें**

[Compress](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/compress/) क्लास अनुपयोगी संरचनात्मक तत्वों को हटाने और एम्बेडेड फ़ॉन्ट डेटा को कम करने में सक्षम है:

- [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides) उन लेआउट स्लाइड्स को हटाता है जिनका कोई सामान्य स्लाइड संदर्भ नहीं देता।
- [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/compress/#removeUnusedMasterSlides) उन मास्टर स्लाइड्स को हटाता है जो अब उपयोग में नहीं हैं।
- [Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/compress/#compressEmbeddedFonts) एम्बेडेड फ़ॉन्ट्स से अनुपयोगी अक्षरों को हटाता है।

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

पहले अनुपयोगी लेआउट्स हटाएँ, फिर अनुपयोगी मास्टर्स, ताकि लेआउट सफ़ाई के बाद जो मास्टर अनरेफ़रेंस हो जाए वह भी हटाया जा सके। यदि आपको बाद में मूल मास्टर, लेआउट, या पूर्ण एम्बेडेड फ़ॉन्ट डेटा की आवश्यकता हो सकती है, तो अनुकूलित प्रेजेंटेशन को नई फ़ाइल में सेव करें। अधिक विवरण के लिए देखें [Slide Master](/slides/hi/nodejs-java/slide-master/) और [Embedded Font](/slides/hi/nodejs-java/embedded-font/)।

## **अक्सर पूछे जाने वाले प्रश्न**

**मुझे कब लो‑कोड API का उपयोग पूर्ण ऑब्जेक्ट मॉडल के बजाय करना चाहिए?**  
जब कोई मानक ऑपरेशन पूरी फ़ाइल या प्रेजेंटेशन पर लागू हो और व्यक्तिगत तत्वों पर विस्तृत नियंत्रण की आवश्यकता न हो, तब लो‑कोड हेल्पर्स का उपयोग करें। जब आपको विशिष्ट स्लाइड्स चुनने, मास्टर और लेआउट संबंधों को नियंत्रित करने, मध्यवर्ती स्थिति का निरीक्षण करने, या ऐसे व्यवहार को कॉन्फ़िगर करने की आवश्यकता हो जो हेल्पर उजागर नहीं करता, तब पूर्ण ऑब्जेक्ट मॉडल का उपयोग करें।

**क्या Merger विभिन्न फ़ाइल फ़ॉर्मेट वाले प्रेजेंटेशन्स को संयोजित कर सकता है?**  
नहीं। [Merger.process](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/merger/#process) को इनपुट प्रेजेंटेशन्स को एक ही फ़ॉर्मेट में होना आवश्यक है। पहले इनपुट फ़ाइलों को एक सामान्य फ़ॉर्मेट में परिवर्तित करें, उदाहरण के लिए [Convert.autoByExtension](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/convert/#autoByExtension) का उपयोग करके, और फिर परिवर्तित फ़ाइलों को मर्ज करें।

**क्या ForEach मास्टर, लेआउट, और नोट्स स्लाइड्स को प्रोसेस करता है?**  
[ForEach.slide](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/foreach/#slide) सामान्य प्रेजेंटेशन स्लाइड्स को इटररेट करता है। प्रेजेंटेशन‑व्यापी [ForEach.shape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/foreach/#shape), [ForEach.paragraph](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/foreach/#paragraph), और [ForEach.portion](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/foreach/#portion) ऑपरेशन्स डिफ़ॉल्ट रूप से सामान्य, मास्टर, और लेआउट स्लाइड्स को शामिल करते हैं। `includeNotes` को `true` सेट करके आप नोट्स स्लाइड्स को भी शामिल कर सकते हैं।

**ForEach.shape और Collect.shapes में क्या अंतर है?**  
जब आप प्रत्येक शैप को तुरंत कॉलबैक के माध्यम से प्रोसेस करना चाहते हैं, तब [ForEach.shape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/foreach/#shape) का उपयोग करें। जब आपको एक iterable परिणाम चाहिए जिसे रखा, फ़िल्टर, गिना, या कई बार ट्रैवर्स किया जा सके, तब [Collect.shapes](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/collect/#shapes) का उपयोग करें।

**क्या Compress हमेशा प्रेजेंटेशन फ़ाइल को छोटा बनाता है?**  
ज़रूरी नहीं। परिणाम इस बात पर निर्भर करता है कि प्रेजेंटेशन में अनुपयोगी लेआउट्स, अनुपयोगी मास्टर्स, या अप्रयुक्त अक्षरों के साथ एम्बेडेड फ़ॉन्ट्स हैं या नहीं। यदि इनमें से कोई भी उपस्थित नहीं है, तो संबंधित [Compress](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/compress/) ऑपरेशन्स फ़ाइल आकार को घटा नहीं सकते।

**क्या ForEach या Compress द्वारा किए गए परिवर्तन स्वतः सहेजे जाते हैं?**  
नहीं। ये हेल्पर्स मेमोरी में लोड किए गए [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) ऑब्जेक्ट पर काम करते हैं। एक [ForEach](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/foreach/) कॉलबैक में तत्व बदलने या [Compress](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/compress/) चलाने के बाद, परिणाम को लिखने के लिये [Presentation.save](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/#save) को कॉल करें।

## **संबंधित लेख**

- [प्रेजेंटेशन रूपांतरित करें](/slides/hi/nodejs-java/convert-presentation/)
- [प्रेजेंटेशन मर्ज करें](/slides/hi/nodejs-java/merge-presentation/)
- [स्लाइड मास्टर](/slides/hi/nodejs-java/slide-master/)
- [टेक्स्ट बॉक्स प्रबंधन](/slides/hi/nodejs-java/manage-textbox/)
- [एम्बेडेड फ़ॉन्ट](/slides/hi/nodejs-java/embedded-font/)