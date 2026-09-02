---
title: प्रस्तुतियों में जावास्क्रिप्ट का उपयोग करके पिक्चर फ्रेम प्रबंधित करें
linktitle: पिक्चर फ्रेम
type: docs
weight: 10
url: /hi/nodejs-java/picture-frame/
keywords:
- पिक्चर फ्रेम
- पिक्चर फ्रेम जोड़ें
- पिक्चर फ्रेम बनाएं
- एम्बेडेड इमेज
- लिंक्ड इमेज
- इमेज एक्सट्रैक्ट करें
- रास्टर इमेज
- SVG इमेज
- इमेज क्रॉप करें
- क्रॉप किए गए क्षेत्रों को हटाएँ
- इमेज संपीड़न
- StretchOffset
- पिक्चर फ्रेम फॉर्मेटिंग
- रिलेटिव स्केल
- इमेज इफ़ेक्ट
- अनुपात
- PowerPoint
- OpenDocument
- प्रस्तुति
- Node.js
- जावास्क्रिप्ट
- Aspose.Slides
description: "Aspose.Slides for Node.js के माध्यम से जावास्क्रिप्ट में प्रस्तुतियों में पिक्चर फ्रेम बनाएं, फॉर्मेट करें, लिंक करें, क्रॉप करें, एक्सट्रैक्ट करें और संपीड़ित करें।"
---
## **अवलोकन**

Picture frame एक slide shape है जो छवि को प्रदर्शित करता है। Aspose.Slides में, छवि संसाधन और उसे प्रदर्शित करने वाला आकार अलग-अलग वस्तुएँ हैं: एक [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) अपने [ImageCollection](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/imagecollection/) के माध्यम से एम्बेडेड छवि संसाधनों का स्वामित्व रखता है, जबकि एक [PictureFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/pictureframe/) छवि की स्थिति, आकार, लाइन फ़ॉर्मेटिंग, घुमाव, क्रॉपिंग, चित्र प्रभाव और अन्य फ्रेम‑स्तर सेटिंग्स को नियंत्रित करता है।

यह अलगाव उपयोगी होता है जब वही छवि एक से अधिक बार दिखाई देती है। छवि को प्रस्तुति में एक बार जोड़ें, लौटाए गए [PPImage](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ppimage/) को रखें, और picture frames बनाते समय उसी छवि संसाधन का उपयोग करें।

Picture frames में PNG या JPEG जैसी रास्टर छवियाँ तथा SVG जैसी वेक्टर छवियाँ दोनों हो सकती हैं। वे प्रस्तुति में छवि बाइट्स संग्रहीत करने के बजाय लिंक की गई छवियों को भी संदर्भित कर सकते हैं। यह चयन पोर्टेबिलिटी, फ़ाइल आकार, एक्सट्रैक्शन और एक्सपोर्ट व्यवहार को प्रभावित करता है, इसलिए फ़ॉर्मेटिंग या ऑप्टिमाइज़ेशन लागू करने से पहले यह तय करना उपयोगी है कि छवि को कैसे संग्रहीत किया जाए।

## **एम्बेडेड छवि जोड़ें और फ़ॉर्मेट करें**

एंबेडेड छवि के लिए, छवि डेटा को प्रस्तुति में जोड़ें और [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/shapecollection/#addPictureFrame-int-float-float-float-float-aspose.slides.PPImage-) के साथ एक picture frame बनाएं। छवि प्रस्तुति पैकेज का हिस्सा बन जाती है, इसलिए प्रस्तुति को दूसरे कंप्यूटर पर ले जाने पर वह स्वनिहित रहती है।

निम्न उदाहरण PNG छवि जोड़ता है, छवि के मूल आयामों पर एक फ्रेम बनाता है, और लाइन फ़ॉर्मेटिंग व घुमाव लागू करता है:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("image.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 100, image.getWidth(), image.getHeight(), image);
    pictureFrame.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    pictureFrame.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    pictureFrame.getLineFormat().setWidth(3);
    pictureFrame.setRotation(15);

    presentation.save("picture-frame.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

picture frame प्रदर्शित ज्यामिति को नियंत्रित करता है; फ्रेम के आकार को बदलने से एम्बेडेड छवि संसाधन में संग्रहीत मूल पिक्सल आयाम नहीं बदलते। यह अंतर बाद में छवि को क्रॉप या संपीड़ित करने पर महत्वपूर्ण हो जाता है।

## **रिलेटिव स्केल का उपयोग करें**

[PictureFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/pictureframe/) फ्रेम के लिए रिलेटिव चौड़ाई और ऊँचाई स्केल को [setRelativeScaleWidth](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/pictureframe/#setRelativeScaleWidth-float-) और [setRelativeScaleHeight](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/pictureframe/#setRelativeScaleHeight-float-) के माध्यम से उजागर करता है। `1.0` का मान मूल चित्र आकार के 100 % के बराबर होता है। रिलेटिव स्केल उपयोगी है जब वर्कफ़्लो को स्रोत छवि आकार के साथ संबंध बनाए रखना हो, बजाय अंतिम आयामों की मैन्युअल गणना के।

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("image.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 50, 100, 100, image);
    pictureFrame.setRelativeScaleWidth(java.newFloat(1.35));
    pictureFrame.setRelativeScaleHeight(java.newFloat(0.8));

    presentation.save("relative-scale.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

रिलेटिव स्केल फ्रेम की स्केल सेटिंग्स को बदलता है; यह एम्बेडेड छवि को री‑सैम्पल या संपीड़ित नहीं करता।

## **एम्बेडेड और लिंक्ड इमेजेज़**

एक एम्बेडेड picture छवि डेटा को प्रस्तुति के भीतर संग्रहीत करती है और इसलिए पोर्टेबिलिटी और पूर्वानुमेय रेंडरिंग के लिए सबसे सुरक्षित विकल्प है। एक लिंक्ड picture बाहरी स्थान को [Picture.setLinkPathLong](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/picture/#setLinkPathLong-java.lang.String-) विधि के माध्यम से संग्रहीत करता है, न कि उसी तरह छवि डेटा को एम्बेड करता है।

लिंक्ड इमेजेज़ PPTX में संग्रहीत छवि डेटा की मात्रा को कम कर सकती हैं, लेकिन वे एक बाहरी निर्भरता पेश करती हैं। लिंक्ड फ़ाइल को उस एप्लिकेशन के लिए उपलब्ध रहना चाहिए जो प्रस्तुति को खोलता या रेंडर करता है। यदि पथ बदल जाता है, फ़ाइल स्थानांतरित हो जाती है, या संसाधन अनुपलब्ध हो जाता है, तो लिंक्ड picture अपेक्षित रूप से प्रदर्शित नहीं हो सकता। उन प्रस्तुतियों के लिए जिन्हें ईमेल करना, संग्रहित करना या पृथक वातावरण में रेंडर करना आवश्यक है, एम्बेडेड इमेजेज़ आमतौर पर अधिक भरोसेमंद होती हैं।

### **लिंक्ड इमेज जोड़ें**

निम्न उदाहरण एक picture frame बनाता है और इसे एक स्थानीय छवि फ़ाइल की ओर इंगित करता है। यह केवल इमेज लिंकिंग को संभालता है; वीडियो लिंकिंग एक अलग मीडिया वर्कफ़्लो है और इरादतन इस उदाहरण में मिश्रित नहीं किया गया है।

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const path = require("path");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 50, 320, 180, null);
    const linkPath = path.resolve("image.png");
    pictureFrame.getPictureFormat().getPicture().setLinkPathLong(linkPath);

    presentation.save("linked-image.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

जब बाहरी फ़ाइल प्रबंधन जानबूझकर हो, तभी लिंक का उपयोग करें। उन्हें केवल संपीड़न के विकल्प के रूप में न प्रयोग करें: टूटे हुए इमेज निर्भरताओं वाली छोटी PPTX अक्सर बड़ी स्वनिहित प्रस्तुति से कम उपयोगी होती हैं।

## **Picture Frames से इमेज एक्सट्रैक्ट करें**

मौजूदा प्रस्तुति से इमेज निकालने से पहले, यह जाँचें कि आकार वास्तव में एक [PictureFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/pictureframe/) है और उसमें एम्बेडेड इमेज मौजूद है। लिंक्ड picture frames में ऐसे इमेज बाइट्स नहीं हो सकते जो समान तरीके से निकाले जा सकें।

### **रास्टर इमेज एक्सट्रैक्ट करें**

आधुनिक इमेज API सीधे [IImage](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/iimage/) का उपयोग करता है। निम्न उदाहरण पहले एम्बेडेड रास्टर चित्र को खोजता है और उसे PNG के रूप में सेव करता है:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    for (let i = 0; i < slide.getShapes().size(); i++) {
        const shape = slide.getShapes().get_Item(i);
        if (!java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            continue;
        }

        const embeddedImage = shape.getPictureFormat().getPicture().getImage();
        if (embeddedImage == null || embeddedImage.getSvgImage() != null) {
            continue;
        }

        const rasterImage = embeddedImage.getImage();
        try {
            rasterImage.save("extracted-image.png", aspose.slides.ImageFormat.Png);
        } finally {
            rasterImage.dispose();
        }
        break;
    }
} finally {
    presentation.dispose();
}
```

[IImage.save](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/iimage/#save) के माध्यम से सेव करने से निकाली गई इमेज को वांछित आउटपुट फ़ॉर्मेट में बदल दिया जाता है। यदि आपको प्रस्तुति में संग्रहीत एन्कोडेड बाइट्स चाहिए, न कि परिवर्तित रास्टर फ़ाइल, तो इमेज संसाधन के बाइनरी डेटा का उपयोग करें।

### **SVG इमेज एक्सट्रैक्ट करें**

SVG picture के लिए, [PPImage](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ppimage/) एक [SvgImage](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/svgimage/) ऑब्जेक्ट उजागर करता है। यह आपको SVG डेटा को सीधे प्राप्त करने देता है, बिना पहले चित्र को रास्टराइज़ किए।

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    for (let i = 0; i < slide.getShapes().size(); i++) {
        const shape = slide.getShapes().get_Item(i);
        if (!java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            continue;
        }

        const embeddedImage = shape.getPictureFormat().getPicture().getImage();
        const svgImage = embeddedImage != null ? embeddedImage.getSvgImage() : null;
        if (svgImage == null) {
            continue;
        }

        fs.writeFileSync("extracted-image.svg", svgImage.getSvgData());
        break;
    }
} finally {
    presentation.dispose();
}
```

SVG सामग्री को SVG के रूप में रखना प्रस्तुति के भीतर वेक्टर स्रोत को संरक्षित करता है। PNG या JPEG जैसी रास्टर एक्सपोर्ट्स आवश्यक रूप से उस वेक्टर सामग्री को पिक्सेल में रेंडर करते हैं। PDF या SVG स्लाइड एक्सपोर्ट भी एक रेंडरिंग ऑपरेशन है, इसलिए एक्सपोर्टेड ग्राफ़िक्स को मूल एम्बेडेड SVG की बाइट‑फ़ॉर‑बाइट कॉपी नहीं माना जाना चाहिए; जब मूल वेक्टर संसाधन आवश्यक हो, तब एम्बेडेड [SvgImage.getSvgData](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/svgimage/#getSvgData--) डेटा उपयोग करें।

## **इमेज को क्रॉप करें**

क्रॉपिंग फ्रेम के भीतर छवि के किस भाग को दिखाया जाए, यह बदलती है। [PictureFillFormat](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/picturefillformat/) पर क्रॉप मान स्रोत छवि आयामों के प्रतिशत होते हैं। क्रॉपिंग प्रारंभ में एम्बेडेड छवि से छिपे पिक्सल को नहीं हटाती; यह केवल दिखे क्षेत्र को बदलती है।

निम्न उदाहरण सुरक्षित रूप से एक picture frame खोजता है और क्रॉप मान लागू करता है:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    let pictureFrame = null;

    for (let i = 0; i < slide.getShapes().size(); i++) {
        const shape = slide.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            pictureFrame = shape;
            break;
        }
    }

    if (pictureFrame != null) {
        pictureFrame.getPictureFormat().setCropLeft(java.newFloat(23.6));
        pictureFrame.getPictureFormat().setCropRight(java.newFloat(21.5));
        pictureFrame.getPictureFormat().setCropTop(java.newFloat(3));
        pictureFrame.getPictureFormat().setCropBottom(java.newFloat(31));
        presentation.save("cropped-image.pptx", aspose.slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

क्योंकि छिपा हुआ इमेज डेटा अभी भी मौजूद है, क्रॉप को बाद में मूल पिक्सल खोए बिना बदला जा सकता है। यदि फ़ाइल आकार अधिक महत्व रखता है और उलटने की आवश्यकता नहीं है, तो अगले अनुभाग में वर्णित तरीके से क्रॉप किए गए क्षेत्र को शारीरिक रूप से हटाया जा सकता है।

## **क्रॉप किए गए इमेज डेटा को हटाएँ**

[PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) वर्तमान क्रॉप आयत के बाहर की इमेज डेटा को हटाता है और resulting image resource लौटाता है। यह फ़ाइल आकार को घटा सकता है, लेकिन यह एक विनाशकारी ऑप्टिमाइज़ेशन है: प्रस्तुति सेव होने के बाद हटाए गए पिक्सल बाद में अनक्रॉप ऑपरेशन के लिए उपलब्ध नहीं रहते।

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    let pictureFrame = null;

    for (let i = 0; i < slide.getShapes().size(); i++) {
        const shape = slide.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            pictureFrame = shape;
            break;
        }
    }

    if (pictureFrame != null) {
        const croppedImage = pictureFrame.getPictureFormat().deletePictureCroppedAreas();
        if (croppedImage != null) {
            presentation.save("cropped-data-removed.pptx", aspose.slides.SaveFormat.Pptx);
        }
    }
} finally {
    presentation.dispose();
}
```

यह विधि प्रस्तुति में एक नया इमेज संसाधन जोड़ सकती है। यदि मूल इमेज अन्य picture frames द्वारा भी उपयोग की जा रही है, तो उन फ्रेमों को अभी भी अपने मौजूदा संसाधन की आवश्यकता रहती है, इसलिए क्रॉप किए गए क्षेत्रों को हटाना आवश्यक रूप से कुल इमेज संख्या को नहीं घटाएगा। WMF या EMF सामग्री को इस विधि से क्रॉप करने से परिणाम PNG में रास्टराइज़ हो जाता है।

## **रास्टर इमेजेस को संपीड़ित करें**

[PictureFillFormat.compressImage](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/picturefillformat/#compressImage-boolean-int-) रास्टर इमेज रिज़ॉल्यूशन को उस आकार के सापेक्ष कम करता है जिस पर चित्र प्रदर्शित किया जाता है। यह एक ही ऑपरेशन में क्रॉप किए गए क्षेत्रों को भी हटा सकता है। यह विधि `true` लौटाती है जब इमेज को रिसाइज़ या क्रॉप किया गया हो और `false` जब कोई बदलाव आवश्यक न हो।

जब मानक लक्ष्य रिज़ॉल्यूशन पर्याप्त हो, तो एक पूर्वनिर्धारित [PicturesCompression](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/picturescompression/) मान का उपयोग करें:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    let pictureFrame = null;

    for (let i = 0; i < slide.getShapes().size(); i++) {
        const shape = slide.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            pictureFrame = shape;
            break;
        }
    }

    if (pictureFrame != null) {
        const compressed = pictureFrame.getPictureFormat().compressImage(true, aspose.slides.PicturesCompression.Dpi150);
        console.log(compressed ? "The image was compressed." : "No compression was necessary.");
        presentation.save("compressed-image.pptx", aspose.slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

विशिष्ट लक्ष्य की आवश्यकता होने पर पूर्वनिर्धारित मान के बजाय एक कस्टम सकारात्मक DPI मान पास किया जा सकता है।

संकुचन रास्टर इमेजेस के लिए अभिप्रेत है। SVG और मेटाफाइल सामग्री इस रास्टर संपीड़न वर्कफ़्लो द्वारा नहीं घटती। यह भी याद रखें कि कम रिज़ॉल्यूशन और हटाए गए क्रॉप क्षेत्रों को अनुकूलित प्रस्तुति से पुनः प्राप्त नहीं किया जा सकता। लक्ष्य रिज़ॉल्यूशन को उस अधिकतम आकार के आधार पर चुनें जिस पर इमेज वास्तव में देखी या एक्सपोर्ट की जाएगी, न कि पूरे प्रोजेक्ट में सबसे कम DPI लागू करके।

## **इमेज ट्रांसफ़ॉर्म इफ़ेक्ट्स को प्रबंधित करें**

ब्राइटनेस, कॉन्ट्रास्ट, कलर ट्रांसफ़ॉर्मेशन, ब्लर, अल्फा इफ़ेक्ट्स, क्रमबद्ध चेन, निरीक्षण, हटाना और राउंड‑ट्रिप वेरिफ़िकेशन को कवर करने वाले पूर्ण वर्कफ़्लो के लिये, देखें [Image Transform Effects](/slides/hi/nodejs-java/image-transform-effects/)।

## **Picture Frame ज्यामिति को लॉक करें**

[PictureFrameLock](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/pictureframelock/) सेटिंग्स यह नियंत्रित करती हैं कि picture frame पर कौन‑सी संपादन क्रियाएँ निष्क्रिय हैं। उदाहरण के तौर पर, [setAspectRatioLocked](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/pictureframelock/#setAspectRatioLocked-boolean-) आकार बदलते समय आकार अनुपात को संरक्षित रखता है।

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("image.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 100, image.getWidth(), image.getHeight(), image);
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);

    presentation.save("locked-picture-frame.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

लॉक picture frame आकार पर लागू होता है। यह स्रोत इमेज को री‑सैम्पल या स्थायी रूप से समान अनुपात में बदलता नहीं है।

## **StretchOffset मान को समायोजित करें**

जब picture fill मोड stretch हो, तो [PictureFillFormat](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/picturefillformat/) पर stretch‑offset मान picture frame की बाउंडिंग बॉक्स के सापेक्ष fill आयत को परिभाषित करते हैं। सकारात्मक प्रतिशत किनारे से एक इनसेट बनाते हैं, जबकि नकारात्मक प्रतिशत एक आउटसेट बनाते हैं।

यह क्रॉपिंग से अलग है। क्रॉप मान स्रोत छवि के किस भाग को दिखाया जाए, यह चुनते हैं; stretch offsets वह आयत बदलते हैं जिसमें दृश्य picture fill खिंचा जाता है।

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("image.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 10, 10, 400, 300, image);
    pictureFrame.getPictureFormat().setPictureFillMode(java.newByte(aspose.slides.PictureFillMode.Stretch));
    pictureFrame.getPictureFormat().setStretchOffsetLeft(java.newFloat(12));
    pictureFrame.getPictureFormat().setStretchOffsetRight(java.newFloat(12));
    pictureFrame.getPictureFormat().setStretchOffsetTop(java.newFloat(8));
    pictureFrame.getPictureFormat().setStretchOffsetBottom(java.newFloat(8));

    presentation.save("stretch-offsets.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

फ़ाइल प्लेसमेंट के लिये stretch offsets उपयोग करें। जब लक्ष्य स्रोत‑इमेज किनारों को छुपाना हो, तो क्रॉप प्रॉपर्टीज़ का उपयोग करें।

## **स्टोरेज, फ़ाइल आकार, और एक्सपोर्ट विचार**

छवि स्टोरेज और picture‑frame फ़ॉर्मेटिंग को अलग‑अलग मानने पर मुख्य ट्रेड‑ऑफ़ आसानी से प्रबंधित होते हैं:

- **Embedded images** प्रस्तुति को स्वनिहित बनाते हैं और साझा करने एवं सर्वर‑साइड रेंडरिंग के लिये सबसे भरोसेमंद हैं, लेकिन बड़े रास्टर इमेजेज़ PPTX आकार और मेमोरी उपयोग को बढ़ाते हैं।
- **Linked images** पैकेज को छोटा रख सकते हैं, लेकिन प्रस्तुति को बाहरी फ़ाइलों की उपलब्धता पर निर्भर होना पड़ता है।
- **Cropping** प्रारंभ में गैर‑विनाशकारी है। छिपे पिक्सल तब तक एम्बेडेड रहते हैं जब तक क्रॉप किए गए क्षेत्रों को स्पष्ट रूप से डिलीट या संपीड़न के दौरान हटाया न जाए।
- **Compression** अत्यधिक बड़े रास्टर इमेजेज़ के फ़ाइल आकार को काफी कम कर सकता है, लेकिन स्रोत रिज़ॉल्यूशन का बलिदान होता है। इसे स्लाइड पर इच्छित आकार ज्ञात होने के बाद लागू करना चाहिए।
- **SVG images** को वेक्टर संरक्षण महत्वपूर्ण होने पर SVG के रूप में रखें। जब आपको वेक्टर संसाधन स्वयं चाहिए, तो एम्बेडेड SVG को सीधे एक्सट्रैक्ट करें। रास्टर स्लाइड एक्सपोर्ट हमेशा रेंडर की गई स्लाइड को पिक्सेल में बदलते हैं।
- **Repeated images** संभव हो तो मौजूदा [PPImage](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ppimage/) संसाधन को दोबारा उपयोग करें, बजाय एक ही फ़ाइल को बार‑बार लोड करने के।

बड़ी प्रस्तुतियों के लिये, छवि अनुकूलन अक्सर चयनात्मक रूप से सबसे प्रभावी होता है: लोगो और डायग्राम को वेक्टर सामग्री के रूप में रखें, फोटोग्राफ़ को उनके वास्तविक डिस्प्ले आकार के अनुसार संपीड़ित करें, क्रॉप किए गए पिक्सल केवल तभी हटाएँ जब बाद में संपादन की आवश्यकता न हो, और बाहरी लिंक तभी उपयोग करें जब निर्भरता प्रबंधन डिप्लॉयमेंट डिज़ाइन का हिस्सा हो।

## **FAQ**

**Picture frame और image resource में क्या अंतर है?**

एक [PPImage](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ppimage/) प्रस्तुति से जुड़ा इमेज रिसोर्स दर्शाता है। एक [PictureFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/pictureframe/) एक स्लाइड पर वह आकार है जो इमेज को प्रदर्शित करता है और फ्रेम‑स्तर ज्यामिति व फ़ॉर्मेटिंग जैसे आकार, घुमाव, क्रॉप मान, इफ़ेक्ट्स और लॉक संग्रहीत करता है।

**क्या एम्बेड करना चाहिए या लिंक करना?**

जब प्रस्तुति को पोर्टेबल, संग्रहित या बाहरी संसाधनों की पहुंच के बिना रेंडर करना आवश्यक हो, तब इमेजेज़ को एम्बेड करें। केवल तब लिंक इमेजेज़ का उपयोग करें जब PPTX के बाहर इमेज फ़ाइलें रखना इरादा हो और बाहरी स्थान को विश्वसनीय रूप से बनाए रखा जा सके।

**क्या क्रॉप करने से PPTX फ़ाइल आकार घटता है?**

खुद से नहीं। सामान्य क्रॉप सेटिंग्स स्रोत इमेज के भाग को छिपाती हैं लेकिन अंतर्निहित पिक्सल को रखती हैं। जब इन पिक्सल को स्थायी रूप से हटाया जा सके, तो [PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) या क्रॉप‑एरिया हटाने के साथ इमेज संपीड़न का उपयोग करें।

**क्या संपीड़न के बाद इमेज क्वालिटी पुनर्स्थापित की जा सकती है?**

नहीं। संपीड़न संग्रहीत रास्टर रिज़ॉल्यूशन को कम कर सकता है, और क्रॉप किए गए क्षेत्रों को हटाने से इमेज डेटा हट जाता है। यदि बाद में हाई‑रिज़ॉल्यूशन संपादन की आवश्यकता हो, तो मूल स्रोत इमेज को प्रस्तुति के बाहर रखें।

**SVG इमेजेज़ को कैसे संभालें?**

जब वेक्टर फ़िडेलिटी महत्त्वपूर्ण हो, तो SVG सामग्री को SVG के रूप में रखें। एम्बेडेड [SvgImage](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/svgimage/) को सीधे एक्सट्रैक्ट किया जा सकता है। स्लाइड को PNG या JPEG जैसे रास्टर फ़ॉर्मेट में एक्सपोर्ट करने से SVG पिक्सेल में रेंडर हो जाता है।

**मौजूदा स्लाइड्स पढ़ते समय असुरक्षित कास्ट से कैसे बचें?**

shape प्रकार की जाँच करने के बाद ही picture‑frame‑विशिष्ट मेम्बर्स का उपयोग करें। `[java.instanceOf]` जांच को [PictureFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/pictureframe/) के विरुद्ध करने से अमान्य कास्ट से बचा जा सकता है और कोड को उन स्लाइड्स को संभालने की अनुमति मिलती है जिनमें picture frames नहीं होते।