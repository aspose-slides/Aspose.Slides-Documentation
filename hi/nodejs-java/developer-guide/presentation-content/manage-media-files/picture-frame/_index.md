---
title: "प्रेजेंटेशन में जावास्क्रिप्ट का उपयोग कर पिक्चर फ्रेम्स प्रबंधित करें"
linktitle: "पिक्चर फ्रेम"
type: docs
weight: 10
url: /hi/nodejs-java/picture-frame/
keywords:
- "चित्र फ्रेम"
- "चित्र फ्रेम जोड़ें"
- "चित्र फ़्रेम बनाएं"
- "संलग्न छवि"
- "संबद्ध छवि"
- "छवि निकालें"
- "रेस्टर छवि"
- "SVG छवि"
- "छवि क्रॉप करें"
- "क्रॉप किए क्षेत्रों को हटाएँ"
- "छवि संपीड़ित करें"
- "StretchOffset"
- "चित्र फ्रेम फ़ॉर्मेटिंग"
- "सापेक्ष स्केल"
- "छवि प्रभाव"
- "आस्पेक्ट अनुपात"
- "PowerPoint"
- "OpenDocument"
- "प्रेजेंटेशन"
- "Node.js"
- "JavaScript"
- "Aspose.Slides"
description: "Aspose.Slides for Node.js via Java के साथ प्रेजेंटेशन में चित्र फ्रेम बनाएं, फ़ॉर्मेट करें, लिंक करें, क्रॉप करें, निकालें, और संपीड़ित करें।"
---
## **अवलोकन**

एक picture frame एक slide shape है जो एक image प्रदर्शित करता है। Aspose.Slides में, image resource और shape जो इसे प्रदर्शित करता है अलग-अलग objects हैं: एक [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) अपने [ImageCollection](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/imagecollection/) के माध्यम से embedded image resources को own करता है, जबकि एक [PictureFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/pictureframe/) image की position, size, line formatting, rotation, cropping, picture effects, और अन्य frame‑level सेटिंग्स को नियंत्रित करता है।

जब एक ही image को कई बार दिखाया जाता है तो यह विभाजन उपयोगी होता है। image को presentation में एक बार जोड़ें, लौटाए गए [PPImage](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ppimage/) को रखें, और picture frames बनाते समय उस image resource का उपयोग करें।

Picture frames raster images जैसे PNG या JPEG और vector SVG images दोनों को रख सकते हैं। वे linked images को भी संदर्भित कर सकते हैं, जिससे image बाइट्स को presentation में संग्रहीत न करना पड़े। यह चयन portability, फ़ाइल आकार, extraction, और export व्यवहार को प्रभावित करता है, इसलिए formatting या optimization लागू करने से पहले तय करना उपयोगी है कि image को कैसे संग्रहीत किया जाए।

## **Embedded Image को जोड़ें और स्वरूपित करें**

एक embedded image के लिए, image डेटा को presentation में जोड़ें और [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/shapecollection/#addPictureFrame-int-float-float-float-float-aspose.slides.PPImage-) के साथ picture frame बनाएं। image presentation पैकेज का हिस्सा बन जाता है, इसलिए presentation को दूसरे कंप्यूटर पर ले जाने पर वह स्वयं‑समावेशी रहता है।

निम्न उदाहरण एक PNG image जोड़ता है, image के मूल आकार पर एक frame बनाता है, और line formatting तथा rotation लागू करता है:

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

picture frame प्रदर्शित geometry को नियंत्रित करता है; frame का आकार बदलना मूल pixel dimensions को नहीं बदलता जो embedded image resource में संग्रहीत हैं। यह अंतर बाद में image को crop या compress करते समय महत्वपूर्ण हो जाता है।

## **Relative Scale का उपयोग करें**

[PictureFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/pictureframe/) फ्रेम के लिए relative width और height scaling को [setRelativeScaleWidth](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/pictureframe/#setRelativeScaleWidth-float-) और [setRelativeScaleHeight](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/pictureframe/#setRelativeScaleHeight-float-) के माध्यम से उजागर करता है। `1.0` का मान मूल picture आकार के 100 % के बराबर है। Relative scale उपयोगी है जब workflow को source image आकार के साथ अनुपात बनाए रखना हो, न कि अंतिम dimensions को मैन्युअल रूप से गणना करना।

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

Relative scale फ्रेम के scale सेटिंग्स को बदलता है; यह embedded image को पुनः‑सैंपल या compress नहीं करता।

## **Embedded और Linked Images**

एक embedded picture image डेटा को presentation के अंदर संग्रहीत करता है और इसलिए portability और पूर्वनिर्धारित rendering के लिए सबसे सुरक्षित विकल्प है। एक linked picture image डेटा को embedding करने के बजाय [Picture.setLinkPathLong](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/picture/#setLinkPathLong-java.lang.String-) विधि के माध्यम से बाहरी स्थान को स्टोर करता है।

Linked images PPTX में संग्रहीत image डेटा की मात्रा को घटा सकते हैं, लेकिन वे एक बाहरी निर्भरता लाते हैं। लिंक्ड फ़ाइल को उस application के लिए उपलब्ध रहना चाहिए जो presentation को खोलता या रेंडर करता है। यदि path बदल जाता है, फ़ाइल स्थानांतरित हो जाती है, या resource अनुपलब्ध हो जाता है, तो linked picture अपेक्षित रूप से दिख नहीं सकता। उन presentations के लिए जो ई‑मेल, आर्काइव या अलग‑थलग वातावरण में रेंडर किए जाने चाहिए, embedded images आमतौर पर अधिक विश्वसनीय होते हैं।

### **Linked Image जोड़ें**

निम्न उदाहरण एक picture frame बनाता है और उसे स्थानीय image फ़ाइल की ओर इंगित करता है। यह केवल image linking से निपटता है; video linking एक अलग media workflow है और इरादतन इस उदाहरण में नहीं मिलाया गया है।

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

जब बाहरी फ़ाइल प्रबंधन इरादा‑पूर्ण हो तो लिंक का उपयोग करें। उन्हें केवल compression का विकल्प बनाकर उपयोग न करें: टूटे हुए image dependencies वाले छोटे PPTX अक्सर बड़े self‑contained presentation से कम उपयोगी होते हैं।

## **Picture Frames से Images निकालें**

किसी मौजूदा presentation से image निकालने से पहले, यह जाँचें कि shape वास्तव में एक [PictureFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/pictureframe/) है और उसमें embedded image है। Linked picture frames में ऐसे image बाइट्स नहीं हो सकते जिन्हें समान तरीके से निकाला जा सके।

### **Raster Image निकालें**

आधुनिक image API सीधे [IImage](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/iimage/) का उपयोग करती है। निम्न उदाहरण first embedded raster picture को slide पर खोजता है और उसे PNG के रूप में सहेजता है:

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

[IImage.save](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/iimage/#save) के माध्यम से सहेजना निकाली गई image को अनुरोधित output format में बदल देता है। यदि आपको presentation में संग्रहीत encoded बाइट्स चाहिए, न कि परिवर्तित raster फ़ाइल, तो image resource के binary डेटा का उपयोग करें।

### **SVG Image निकालें**

SVG picture के लिए, [PPImage](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ppimage/) एक [SvgImage](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/svgimage/) ऑब्जेक्ट उजागर करता है। यह आपको SVG डेटा को सीधे प्राप्त करने की अनुमति देता है, बिना पहले picture को rasterize किए।

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

SVG सामग्री को SVG के रूप में रखना presentation के भीतर vector स्रोत को संरक्षित करता है। PNG या JPEG जैसे raster निर्यात अनिवार्य रूप से उस vector सामग्री को pixel में बदलते हैं। PDF या SVG slide export भी एक rendering ऑपरेशन है, इसलिए निर्यातित graphics को मूल embedded SVG की बाइट‑फ़ॉर‑बाइट कॉपी के रूप में नहीं माना जाना चाहिए; जब मूल vector resource की आवश्यकता हो तो embedded [SvgImage.getSvgData](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/svgimage/#getSvgData--) डेटा का उपयोग करें।

## **Image Crop करें**

Cropping फ्रेम के भीतर image के कौन से भाग दिखेंगे इसे बदलता है। [PictureFillFormat](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/picturefillformat/) पर crop मान source image dimensions के प्रतिशत होते हैं। Cropping मूल रूप से embedded image के छिपे हुए pixel को हटाता नहीं है; यह केवल दृश्यमान क्षेत्र बदलता है।

निम्न उदाहरण एक picture frame को सुरक्षित रूप से ढूँढता है और crop मान लागू करता है:

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

क्योंकि छिपा हुआ image डेटा अभी भी मौजूद है, crop को बाद में बदला जा सकता है बिना मूल pixel खोए। यदि फ़ाइल आकार अधिक महत्वपूर्ण है और पुनः‑स्वरूपण की आवश्यकता नहीं है, तो अगले अनुभाग में वर्णित अनुसार cropped क्षेत्रों को शारीरिक रूप से हटाया जा सकता है।

## **Cropped Image Data हटाएँ**

[PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) वर्तमान crop rectangle के बाहर की image डेटा को हटाता है और परिणामी image resource लौटाता है। यह फ़ाइल आकार को घटा सकता है, लेकिन यह एक विनाशकारी ऑप्टिमाइज़ेशन है: presentation सहेजे जाने के बाद हटाए गए pixel आगे के uncrop संचालन के लिए उपलब्ध नहीं होते।

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

यह विधि presentation में एक नया image resource जोड़ सकती है। यदि मूल image को अन्य picture frames भी उपयोग कर रहे हैं, तो उन frames को अभी भी अपने मौजूदा resource की आवश्यकता होगी, इसलिए cropped क्षेत्रों को हटाने से कुल image की संख्या आवश्यक रूप से नहीं घटेगी। इस विधि से WMF या EMF सामग्री को crop करने से परिणाम PNG में rasterized हो जाता है।

## **Raster Images को Compress करें**

[PictureFillFormat.compressImage](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/picturefillformat/#compressImage-boolean-int-) raster image की resolution को उस आकार के सापेक्ष घटाता है जिस पर picture प्रदर्शित होती है। यह एक ही ऑपरेशन में cropped क्षेत्रों को भी हटा सकता है। विधि `true` लौटाती है जब image को resized या cropped किया गया हो और `false` जब कोई परिवर्तन आवश्यक न हो।

जब एक मानक target resolution पर्याप्त हो तो एक पूर्वनिर्धारित [PicturesCompression](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/picturescompression/) मान का उपयोग करें:

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

यदि कोई विशिष्ट target चाहिए तो पूर्वनिर्धारित मान के बजाय एक कस्टम सकारात्मक DPI मान पास किया जा सकता है।

Compression raster images के लिए अभिप्रेत है। SVG और metafile सामग्री इस raster compression workflow द्वारा नहीं घटती है। साथ ही याद रखें कि कम resolution और हटाए गए cropped क्षेत्र अनुकूलित presentation से पुनः प्राप्त नहीं किए जा सकते। लक्ष्य resolution को उस सबसे बड़े आकार के आधार पर चुनें, जिस पर image वास्तव में देखी या निर्यात की जाएगी, न कि पूरे दस्तावेज़ में सबसे कम DPI लागू करके।

## **Image Transform Effects को Manage करें**

पूर्ण workflow के लिए जो brightness, contrast, color transformations, blur, alpha effects, ordered chains, inspection, removal, और round‑trip verification को कवर करता है, देखें [Image Transform Effects](/nodejs-java/image-transform-effects/)।

## **Picture Frame Geometry को Lock करें**

[PictureFrameLock](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/pictureframelock/) सेटिंग्स यह नियंत्रित करती हैं कि picture frame पर कौन‑से editing operations निष्क्रिय हैं। उदाहरण के लिए, [setAspectRatioLocked](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/pictureframelock/#setAspectRatioLocked-boolean-) आकार बदलते समय shape के अनुपात को संरक्षित रखता है।

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

Lock picture frame shape पर लागू होता है। यह source image को पुनः‑सैंपल या स्थायी रूप से समान aspect ratio में बदलता नहीं है।

## **StretchOffset मानों को समायोजित करें**

जब picture fill mode stretch हो, तो [PictureFillFormat](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/picturefillformat/) पर stretch‑offset मान picture frame के bounding box के सापेक्ष fill rectangle को परिभाषित करते हैं। सकारात्मक प्रतिशत किनारे से एक inset बनाते हैं, जबकि नकारात्मक प्रतिशत एक outset बनाते हैं।

यह cropping से अलग है। Crop मान निर्धारित करता है कि source image का कौन‑सा भाग दृश्यमान है; stretch offsets उस rectangle को बदलते हैं जिसमें दृश्यमान picture fill को stretch किया जाता है।

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

fill placement के लिए stretch offsets का उपयोग करें। जब लक्ष्य source‑image किनारों को छिपाना हो तो crop properties का उपयोग करें।

## **Storage, File Size, और Export पर विचार**

मुख्य trade‑offs तब आसान होते हैं जब image storage और picture‑frame formatting को अलग‑अलग माना जाए:

- **Embedded images** presentation को self‑contained बनाते हैं और शेयरिंग और server‑side rendering के लिए सबसे विश्वसनीय होते हैं, लेकिन बड़े raster images PPTX आकार और मेमोरी उपयोग को बढ़ाते हैं।
- **Linked images** पैकेज को छोटा रख सकते हैं, लेकिन presentation को बाहरी फ़ाइलों के उपलब्ध रहने पर निर्भर बनाते हैं।
- **Cropping** प्रारंभ में non‑destructive है। छिपे हुए pixel तब तक embedded रहते हैं जब तक cropped क्षेत्रों को स्पष्ट रूप से हटाया न जाए या compression के दौरान हटाया न जाए।
- **Compression** oversized raster images के फ़ाइल आकार को काफी घटा सकता है, लेकिन यह source resolution को त्यागता है। इसे slide पर वास्तविक आकार ज्ञात होने के बाद लागू करना चाहिए।
- **SVG images** को तब तक SVG के रूप में रखें जब तक vector preservation महत्वपूर्ण हो। जब आपको स्वयं vector resource चाहिए तो embedded SVG को सीधे निकालें। Raster slide निर्यात हमेशा rendered slide को pixel में बदल देता है।
- **Repeated images** को संभव हो तो मौजूदा [PPImage](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ppimage/) resource को पुनः प्रयोग करें, न कि एक ही फ़ाइल को बार‑बार लोड करें।

बड़ी presentations के लिए, image optimization आमतौर पर तब सबसे प्रभावी होता है जब चयनात्मक रूप से किया जाए: लोगो और डायग्राम को vector सामग्री के रूप में रखें, photographs को उनके वास्तविक display size के अनुसार compress करें, cropped pixel को तभी हटाएँ जब बाद में editing की आवश्यकता न हो, और जब तक dependency management deployment डिजाइन का हिस्सा न हो तब तक external links से बचें।

## **FAQ**

**picture frame और image resource में क्या अंतर है?**

एक [PPImage](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ppimage/) presentation से जुड़ा एक image resource दर्शाता है। एक [PictureFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/pictureframe/) slide पर वह shape है जो image प्रदर्शित करता है और frame‑level geometry और formatting जैसे size, rotation, crop values, effects, और locks को संग्रहीत करता है।

**मुझे images को embed करना चाहिए या link?**

जब presentation को portable, archived, या बाहरी resources के बिना rendered होना हो तो images को embed करें। केवल तभी images को link करें जब image फ़ाइलों को PPTX के बाहर रखने का उद्देश्य हो और बाहरी स्थानों को विश्वसनीय रूप से बनाए रखा जा सके।

**क्या cropping से PPTX फ़ाइल आकार कम होता है?**

स्वयं नहीं। सामान्य crop सेटिंग्स source image के हिस्सों को छुपाती हैं लेकिन नीचे के pixel को रखती हैं। उन pixel को स्थायी रूप से निकालने के लिए [PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) या cropped‑area removal के साथ image compression का उपयोग करें।

**क्या compression के बाद image गुणवत्ता को पुनः प्राप्त किया जा सकता है?**

नहीं। Compression संग्रहीत raster resolution को घटा सकता है, और cropped क्षेत्रों को हटाने से image डेटा समाप्त हो जाता है। यदि बाद में high‑resolution editing की आवश्यकता हो तो मूल source image को presentation के बाहर रखें।

**SVG images को कैसे संभालना चाहिए?**

जब vector fidelity महत्वपूर्ण हो तो SVG सामग्री को SVG के रूप में रखें। embedded [SvgImage](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/svgimage/) को सीधे निकाला जा सकता है। slide को PNG या JPEG जैसे raster format में निर्यात करने से SVG slide image का हिस्सा बन जाता है।

**मौजूदा slides पढ़ते समय unsafe casts से कैसे बचें?**

shape type को picture‑frame‑specific members उपयोग करने से पहले जाँचें। [PictureFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/pictureframe/) के विरुद्ध `java.instanceOf` जांच के माध्यम से invalid casts से बचें और कोड को उन slides को संभालने दें जिनमें picture frames नहीं हैं।