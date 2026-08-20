---
title: JavaScript का उपयोग करके प्रस्तुतियों में पिक्चर फ्रेम प्रबंधित करें
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
  - इमेज निकालें
  - रैस्टर इमेज
  - SVG इमेज
  - इमेज क्रॉप करें
  - क्रॉप्ड क्षेत्रों को हटाएं
  - इमेज संकुचित करें
  - StretchOffset
  - पिक्चर फ्रेम फ़ॉर्मेटिंग
  - रिलेटिव स्केल
  - इमेज इफ़ेक्ट
  - परिपत्र अनुपात
  - PowerPoint
  - OpenDocument
  - प्रेजेंटेशन
  - Node.js
  - JavaScript
  - Aspose.Slides
description: Aspose.Slides for Node.js के माध्यम से Java का उपयोग करके प्रस्तुतियों में पिक्चर फ्रेम बनाएं, फ़ॉर्मेट करें, लिंक करें, क्रॉप करें, निकालें और संकुचित करें।
---
## **अवलोकन**

Picture frame एक slide shape है जो image दिखाता है। Aspose.Slides में, image resource और उसे प्रदर्शित करने वाला shape अलग‑अलग objects हैं: एक [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) अपने [ImageCollection](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/imagecollection/) के माध्यम से एम्बेडेड इमेज resources को संभालता है, जबकि एक [PictureFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/pictureframe/) image की स्थिति, आकार, लाइन फ़ॉर्मेटिंग, घुमाव, क्रॉपिंग, picture effects, और अन्य फ्रेम‑स्तर सेटिंग्स को नियंत्रित करता है।

यह विभाजन तब उपयोगी होता है जब एक ही image को कई बार दिखाया जाता है। image को प्रस्तुति में एक बार जोड़ें, लौटाए गए [PPImage](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ppimage/) को रखें, और picture frames बनाते समय उसी image resource का उपयोग करें।

Picture frames raster images जैसे PNG या JPEG तथा vector SVG images दोनों को रख सकते हैं। वे linked images को भी संदर्भित कर सकते हैं, जिससे image बाइट्स प्रस्तुति में संग्रहीत नहीं होती। यह चयन पोर्टेबिलिटी, फ़ाइल आकार, एक्सट्रैक्शन, और एक्सपोर्ट व्यवहार को प्रभावित करता है, इसलिए फ़ॉर्मेटिंग या ऑप्टिमाइज़ेशन लागू करने से पहले यह तय करना उपयोगी है कि image कैसे संग्रहीत होनी चाहिए।

## **एम्बेडेड इमेज जोड़ें और फ़ॉर्मेट करें**

एक एम्बेडेड इमेज के लिए, इमेज डेटा को प्रस्तुति में जोड़ें और [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/shapecollection/#addPictureFrame-int-float-float-float-float-aspose.slides.PPImage-) का उपयोग करके picture frame बनायें। इमेज प्रस्तुति पैकेज का हिस्सा बन जाता है, इसलिए प्रस्तुति को दूसरे कंप्यूटर पर ले जाने पर भी यह स्व-निहित रहती है।

निम्न उदाहरण PNG इमेज जोड़ता है, इमेज के मूल आकार में फ्रेम बनाता है, तथा लाइन फ़ॉर्मेटिंग और घुमाव लागू करता है:

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

Picture frame प्रदर्शित ज्योमेट्री को नियंत्रित करता है; फ्रेम का आकार बदलने से एम्बेडेड इमेज संसाधन में संग्रहीत मूल पिक्सेल आकार नहीं बदलता। बाद में इमेज को क्रॉप या संकुचित करते समय यह अंतर महत्वपूर्ण हो जाता है।

## **रिलेटिव स्केल का उपयोग करें**

[PictureFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/pictureframe/) फ्रेम के लिए रिलेटिव चौड़ाई और ऊँचाई स्केल को [setRelativeScaleWidth](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/pictureframe/#setRelativeScaleWidth-float-) और [setRelativeScaleHeight](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/pictureframe/#setRelativeScaleHeight-float-) के माध्यम से उजागर करता है। `1.0` का मान मूल picture आकार का 100 % दर्शाता है। रिलेटिव स्केल तब उपयोगी होता है जब किसी workflow को अंतिम आयामों की मैन्युअल गणना करने की बजाय स्रोत इमेज आकार के साथ संबंध बनाए रखना हो।

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

रिलेटिव स्केल फ्रेम की स्केल सेटिंग्स को बदलता है; यह एम्बेडेड इमेज को री‑सैंपल या संकुचित नहीं करता।

## **एम्बेडेड और लिंक्ड इमेजेस**

एक एम्बेडेड picture इमेज डेटा को प्रस्तुति के भीतर संग्रहीत करता है और इस कारण पोर्टेबिलिटी और पूर्वनिर्धारित रेंडरिंग के लिए सबसे सुरक्षित विकल्प होता है। एक लिंक्ड picture `Picture.setLinkPathLong` मेथड के माध्यम से बाहरी स्थान को स्टोर करता है, बजाय कि इमेज डेटा को उसी तरह एम्बेड करने के।

लिंक्ड इमेजेस PPTX में संग्रहीत इमेज डेटा की मात्रा को घटा सकते हैं, लेकिन वे बाहरी निर्भरताएँ पेश करते हैं। लिंक्ड फ़ाइल को उस एप्लिकेशन को सुलभ रहना चाहिए जो प्रस्तुति को खोलता या रेंडर करता है। यदि पाथ बदलता है, फ़ाइल स्थानांतरित होती है, या संसाधन उपलब्ध नहीं रहता, तो लिंक्ड picture अपेक्षित रूप से प्रदर्शित नहीं होगा। उन प्रस्तुतियों के लिए जो ई‑मेल, आर्काइव, या अलग‑थलग वातावरण में रेंडर की जानी हों, एम्बेडेड इमेजेस आमतौर पर अधिक विश्वसनीय होती हैं।

### **लिंक्ड इमेज जोड़ें**

निम्न उदाहरण एक picture frame बनाता है और उसे स्थानीय इमेज फ़ाइल की ओर इंगित करता है। यह केवल इमेज लिंकिंग को दर्शाता है; वीडियो लिंकिंग एक अलग मीडिया workflow है और इरादतन इस उदाहरण में सम्मिलित नहीं किया गया है।

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

बाहरी फ़ाइल प्रबंधन जब जानबूझकर हो, तभी लिंक का उपयोग करें। इन्हें केवल संपीड़न के विकल्प के रूप में उपयोग न करें: टूटे हुए इमेज निर्भरताओं वाला छोटा PPTX अक्सर बड़े स्व‑निहित प्रस्तुति से कम उपयोगी होता है।

## **Picture Frames से इमेज निकालें**

किसी मौजूदा प्रस्तुति से इमेज निकालने से पहले, सुनिश्चित करें कि shape वास्तव में एक [PictureFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/pictureframe/) है और उसमें एम्बेडेड इमेज मौजूद है। लिंक्ड picture frames में वह इमेज बाइट्स नहीं हो सकते जो समान तरीके से निकाले जा सकें।

### **Raster इमेज निकालें**

आधुनिक इमेज API सीधे [IImage](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/iimage/) का उपयोग करता है। नीचे दिया गया उदाहरण पहले एम्बेडेड raster picture को खोजता है और उसे PNG के रूप में सहेजता है:

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

[IImage.save](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/iimage/#save) के माध्यम से सहेजना निकाली गई इमेज को वांछित आउटपुट फ़ॉर्मेट में बदल देता है। यदि आपको प्रस्तुति में संग्रहीत एन्कोडेड बाइट्स चाहिए, तो इमेज संसाधन के बाइनरी डेटा का उपयोग करें, न कि परिवर्तित raster फ़ाइल का।

### **SVG इमेज निकालें**

SVG picture के लिए, [PPImage](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ppimage/) एक [SvgImage](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/svgimage/) ऑब्जेक्ट उजागर करता है। इससे आप SVG डेटा को सीधे प्राप्त कर सकते हैं, बिना पहले picture को rasterize किए।

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

SVG को SVG के रूप में रखना प्रस्तुति के भीतर वेक्टर स्रोत को संरक्षित करता है। PNG या JPEG जैसी raster एक्सपोर्ट्स स्वाभाविक रूप से वेक्टर को पिक्सेल में रेंडर करती हैं। PDF या SVG slide export भी एक रेंडरिंग ऑपरेशन है, इसलिए निर्यातित ग्राफ़िक्स को मूल एम्बेडेड SVG की बाइट‑फ़ॉर‑बाइट कॉपी न मानें; जब मूल वेक्टर संसाधन की आवश्यकता हो तो एम्बेडेड [SvgImage.getSvgData](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/svgimage/#getSvgData--) डेटा का उपयोग करें।

## **इमेज को क्रॉप करें**

क्रॉपिंग फ्रेम के भीतर इमेज के दृश्य भाग को बदलती है। [PictureFillFormat](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/picturefillformat/) पर क्रॉप मान स्रोत इमेज आयामों के प्रतिशत होते हैं। क्रॉपिंग प्रारम्भ में एम्बेडेड इमेज से छिपे पिक्सेल को नहीं हटाता; यह केवल दिखाई देने वाले क्षेत्र को बदलता है।

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

क्योंकि छिपा इमेज डेटा अभी भी मौजूद है, क्रॉप को बाद में मूल पिक्सेल खोए बिना बदला जा सकता है। यदि फ़ाइल आकार अधिक महत्वपूर्ण है और पुनः सम्पादन की आवश्यकता नहीं है, तो अगली सेक्शन में बताए अनुसार क्रॉप किए गए क्षेत्रों को शारीरिक रूप से हटाया जा सकता है।

## **क्रॉप किए गए इमेज डेटा को हटाएँ**

[PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) वर्तमान क्रॉप रेक्टेंगल के बाहर के इमेज डेटा को हटाता है और परिणामी इमेज संसाधन लौटाता है। इससे फ़ाइल आकार घट सकता है, लेकिन यह एक विनाशकारी ऑप्टिमाइज़ेशन है: प्रस्तुति सहेजने के बाद हटाए गए पिक्सेल बाद की अनक्रॉप ऑपरेशन के लिये उपलब्ध नहीं रहेंगे।

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

यह मेथड प्रस्तुति में एक नया इमेज संसाधन जोड़ सकता है। यदि मूल इमेज अन्य picture frames द्वारा भी उपयोग की जा रही है, तो उन फ्रेमों को अभी भी अपने मौजूदा संसाधन की आवश्यकता होगी, इसलिए क्रॉप्ड क्षेत्रों को हटाना आवश्यक रूप से कुल इमेज की संख्या कम नहीं करता। WMF या EMF सामग्री को इस मेथड से क्रॉप करने पर परिणाम PNG में rasterize हो जाता है।

## **Raster इमेजेस को संकुचित करें**

[PictureFillFormat.compressImage](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/picturefillformat/#compressImage-boolean-int-) raster इमेज रिज़ॉल्यूशन को उस आकार के सापेक्ष घटाता है जिस पर picture प्रदर्शित होता है। यह एक ही ऑपरेशन में क्रॉप्ड क्षेत्रों को भी हटा सकता है। जब इमेज री‑साइज़ या क्रॉप हुई हो तो मेथड `true` लौटाता है, अन्यथा `false`।

जब मानक लक्ष्य रिज़ॉल्यूशन पर्याप्त हो, तो पूर्वनिर्धारित [PicturesCompression](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/picturescompression/) मान का उपयोग करें:

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

यदि विशिष्ट लक्ष्य आवश्यक हो तो पूर्वनिर्धारित मान के स्थान पर कस्टम सकारात्मक DPI मान पास किया जा सकता है।

संकुचन raster इमेजेस के लिये अभिप्रेत है। SVG और मेटा‑फ़ाइल सामग्री इस raster संपीड़न workflow द्वारा नहीं घटती। यह भी याद रखें कि कम रिज़ॉल्यूशन और हटाए गए क्रॉप्ड क्षेत्रों को ऑप्टिमाइज़्ड प्रस्तुति से पुनः प्राप्त नहीं किया जा सकता। लक्ष्य रिज़ॉल्यूशन को उस सबसे बड़े आकार के आधार पर चुनें जिस पर इमेज वास्तविक रूप से देखी या निर्यात की जाएगी, न कि पूरे दस्तावेज़ में सबसे कम DPI लागू करके।

## **इमेज इफ़ेक्ट्स की जाँच करें**

Picture effects फ्रेम द्वारा उपयोग की गई picture पर संग्रहीत होते हैं। इमेज ट्रांसफ़ॉर्म कलेक्शन में पारदर्शिता के लिये फिक्स्ड अल्फा मॉड्यूलेशन और चमक‑विरोधा के लिये ल्यूमिनेंस जैसे इफ़ेक्ट्स हो सकते हैं। नीचे दिया गया उदाहरण पहले picture frame से दोनों प्रकार के इफ़ेक्ट्स को सुरक्षित रूप से पढ़ता है:

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
        const imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
        for (let i = 0; i < imageTransform.size(); i++) {
            const effect = imageTransform.get_Item(i);
            if (java.instanceOf(effect, "com.aspose.slides.IAlphaModulateFixed")) {
                const transparency = 100 - effect.getAmount();
                console.log("Transparency: " + transparency);
            }

            if (java.instanceOf(effect, "com.aspose.slides.ILuminance")) {
                const luminance = effect.getEffective();
                console.log("Brightness: " + luminance.getBrightness());
                console.log("Contrast: " + luminance.getContrast());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

ये इफ़ेक्ट्स फ्रेम में इमेज के रेंडरिंग को बदलते हैं; वे मूल एम्बेडेड इमेज बाइट्स को नहीं लिखते।

## **Picture Frame ज्योमेट्री को लॉक करें**

[PictureFrameLock](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/pictureframelock/) सेटिंग्स यह निर्धारित करती हैं कि picture frame पर कौन‑सी संपादन क्रियाएँ निष्क्रिय की गई हैं। उदाहरण के लिये, [setAspectRatioLocked](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/pictureframelock/#setAspectRatioLocked-boolean-) आकार बदलते समय shape के अनुपात को संरक्षित रखता है।

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

यह लॉक picture frame shape पर लागू होता है। यह स्रोत इमेज को री‑सैंपल या स्थायी रूप से समान अनुपात में बदलता नहीं है।

## **StretchOffset मानों को समायोजित करें**

जब picture fill मोड stretch हो, तो [PictureFillFormat](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/picturefillformat/) पर stretch‑offset मान picture frame के बाउंडिंग बॉक्स के सापेक्ष fill रेक्टेंगल को परिभाषित करते हैं। सकारात्मक प्रतिशत किनारे से एक अंदरूनी अंतर बनाते हैं, जबकि नकारात्मक प्रतिशत एक बाहरूनी अंतर बनाते हैं।

यह क्रॉपिंग से अलग है। क्रॉप मान स्रोत इमेज के कौन‑सा भाग दृश्यमान है, इसे चुनते हैं; stretch‑offset विज़िबल picture fill को जिस रेक्टेंगल में खींचा जाता है, उसे बदलते हैं।

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

fill के स्थान निर्धारण के लिये stretch‑offset का उपयोग करें। जब लक्ष्य स्रोत‑इमेज के किनारों को छिपाना हो, तो crop गुणों का प्रयोग करें।

## **स्टोरेज, फ़ाइल आकार, और एक्सपोर्ट पर विचार**

जब image स्टोरेज और picture‑frame फ़ॉर्मेटिंग को अलग‑अलग किया जाता है, तो मुख्य ट्रेड‑ऑफ़्स को अधिक आसानी से प्रबंधित किया जा सकता है:

- **एम्बेडेड इमेजेस** प्रस्तुति को स्व‑निहित बनाती हैं और शेयरिंग एवं सर्वर‑साइड रेंडरिंग के लिये सबसे विश्वसनीय होती हैं, लेकिन बड़े raster इमेजेस PPTX आकार और मेमोरी उपयोग को बढ़ाते हैं।
- **लिंक्ड इमेजेस** पैकेज को छोटा रख सकती हैं, लेकिन प्रस्तुति को उन बाहरी फ़ाइलों पर निर्भर रहना पड़ता है जो संग्रहीत पाथ या स्थानों पर उपलब्ध हों।
- **क्रॉपिंग** शुरू में विनाश‑रहित होती है। छिपे पिक्सेल तब तक एम्बेडेड रहते हैं जब तक कि क्रॉप्ड क्षेत्रों को स्पष्ट रूप से हटाया या संकुचन के दौरान हटाया न जाए।
- **संकुचन** अत्यधिक बड़े raster इमेजेस के फ़ाइल आकार को उल्लेखनीय रूप से घटा सकता है, लेकिन इसका बदला स्रोत रिज़ॉल्यूशन है। इसे स्लाइड पर वास्तविक आकार ज्ञात होने के बाद लागू करना चाहिए।
- **SVG इमेजेस** को वेक्टर संरक्षण महत्वपूर्ण होने पर SVG ही रखना चाहिए। जब आपको स्वयं वेक्टर संसाधन चाहिए तब एम्बेडेड SVG को सीधे निकालें। Raster slide एक्सपोर्ट हमेशा रेंडर किए गए स्लाइड को पिक्सेल में बदल देता है।
- **दोहराए गए इमेजेस** को संभव हो तो मौजूदा [PPImage](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ppimage/) संसाधन का पुनः उपयोग करना चाहिए, बजाय एक ही फ़ाइल को बार‑बार लोड करने के।

बड़ी प्रस्तुतियों के लिये, इमेज ऑप्टिमाइज़ेशन सबसे प्रभावी तब होता है जब चयनात्मक रूप से किया जाए: लोगो और डायग्राम को वेक्टर सामग्री के रूप में रखें, फ़ोटोग्राफ़ को उनके वास्तविक डिस्प्ले आकार के अनुसार संकुचित करें, क्रॉप्ड पिक्सेल केवल तभी हटाएँ जब बाद में सम्पादन आवश्यक न हो, और बाहरी लिंक केवल तभी रखें जब निर्भरता प्रबंधन डिप्लॉयमेंट डिज़ाइन का हिस्सा हो।

## **अक्सर पूछे जाने वाले प्रश्न**

**Picture frame और image resource में क्या अंतर है?**

एक [PPImage](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ppimage/) प्रस्तुति से संबद्ध इमेज resource को दर्शाता है। एक [PictureFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/pictureframe/) स्लाइड पर वह shape है जो इमेज प्रदर्शित करता है और फ्रेम‑स्तर ज्योमेट्री तथा फ़ॉर्मेटिंग (जैसे आकार, घुमाव, क्रॉप मान, इफ़ेक्ट्स, लॉक) को संग्रहीत करता है।

**मुझे इमेज को एम्बेड करना चाहिए या लिंक करना?**

जब प्रस्तुति को पोर्टेबल, आर्काइव या बाहरी संसाधनों के बिना रेंडर करना आवश्यक हो, तो इमेज को एम्बेड करें। केवल तब लिंक करें जब इमेज फ़ाइलों को PPTX से बाहर रखना इरादतन हो और बाहरी स्थानों को विश्वसनीय रूप से बनाए रखा जा सके।

**क्या क्रॉपिंग PPTX फ़ाइल आकार को कम करती है?**

स्वतः नहीं। सामान्य क्रॉप सेटिंग्स स्रोत इमेज के हिस्सों को छुपाती हैं लेकिन मूल पिक्सेल रखती हैं। जब उन पिक्सेल को स्थायी रूप से हटाया जा सके, तो आप [PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) या क्रॉप्ड‑एरिया हटाने के साथ इमेज संपीड़न का उपयोग कर सकते हैं।

**क्या संपीड़न के बाद इमेज गुणवत्ता पुनः प्राप्त की जा सकती है?**

नहीं। संपीड़न संग्रहीत raster रिज़ॉल्यूशन को घटा देता है, और क्रॉप्ड क्षेत्रों को हटाने से इमेज डेटा स्थायी रूप से मिट जाता है। यदि बाद में उच्च‑रिज़ॉल्यूशन संपादन की संभावना हो, तो मूल स्रोत इमेज को प्रस्तुति से बाहर रखें।

**SVG इमेजेस को कैसे संभालें?**

जब वेक्टर फ़िडेलिटी महत्त्वपूर्ण हो, तो SVG सामग्री को SVG के रूप में रखें। एम्बेडेड [SvgImage](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/svgimage/) को सीधे निकाला जा सकता है। स्लाइड को PNG या JPEG जैसे raster फ़ॉर्मेट में निर्यात करने से SVG पिक्सेल में rasterize हो जाता है।

**मौजूदा स्लाइड्स पढ़ते समय असुरक्षित कास्ट से कैसे बचें?**

shape प्रकार की जाँच करने के बाद ही picture‑frame‑विशिष्ट सदस्य का उपयोग करें। `java.instanceOf` जांच के साथ [PictureFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/pictureframe/) को सत्यापित करने से अमान्य कास्ट से बचा जा सकता है और कोड उन स्लाइड्स को संभाल सकता है जिनमें picture frames नहीं हैं।