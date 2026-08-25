---
title: जावास्क्रिप्ट के साथ प्रस्तुतियों में छवि परिवर्तन प्रभावों का प्रबंधन
linktitle: छवि परिवर्तन प्रभाव
type: docs
weight: 11
url: /hi/nodejs-java/image-transform-effects/
keywords:
- छवि परिवर्तन
- चित्र प्रभाव
- चमक
- कंट्रास्ट
- ग्रेस्केल
- डुओटोन
- टिंट
- एचएसएल
- रंग प्रतिस्थापन
- धुंध
- पारदर्शिता
- अल्फा प्रभाव
- प्रभाव श्रृंखला
- पावरपॉइंट
- प्रस्तुति
- Node.js
- जावास्क्रिप्ट
- Aspose.Slides
description: "Aspose.Slides for Node.js के माध्यम से जावास्क्रिप्ट में चित्र फ्रेम के लिए छवि परिवर्तन प्रभावों को लागू करें, श्रृंखलाबद्ध करें, निरीक्षण करें, हटाएं और सत्यापित करें।"
---
## **परिचय**

Aspose.Slides चित्र समायोजन को छवि परिवर्तन क्रियाओं के क्रमबद्ध संग्रह के रूप में प्रस्तुत करता है। किसी चित्र फ़्रेम के लिए, फ़्रेम की [चित्र](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/picture/) से शुरू करें और [Picture.getImageTransform](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/picture/) तक पहुँचें। लौटाए गए [ImageTransformOperationCollection](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/imagetransformoperationcollection/) आपको मूल छवि बाइट्स को पुनः लिखे बिना प्रभाव जोड़ने, सूचीबद्ध करने, निरीक्षण करने, हटाने और साफ़ करने की अनुमति देता है।

यह लेख चमक और कंट्रास्ट, रंग रूपांतरण, धुंध, पारदर्शिता, क्रमबद्ध प्रभाव श्रृंखलाएँ, प्रभावी मान, हटाना, और PPTX राउंड‑ट्रिप सत्यापन के लिए एक संपूर्ण कार्यप्रवाह दर्शाता है।

## **इफ़ेक्ट स्वामित्व और छवि पुन: उपयोग को समझें**

एक छवि संसाधन और जिस चित्र में वह प्रदर्शित होता है, दो अलग-अलग वस्तुएँ हैं:

- [PPImage](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ppimage/) प्रस्तुति द्वारा मालिकाना स्रोत छवि डेटा को संग्रहीत या संदर्भित करता है।
- [Picture](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/picture/) चित्र भराव से संबंधित है और एक छवि संसाधन को संदर्भित करता है तथा छवि परिवर्तन संग्रह को संग्रहीत करता है।
- [PictureFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/pictureframe/) वह स्लाइड आकार है जो संबंधित चित्र भराव, ज्योमेट्री, क्रॉप सेटिंग्स, और अन्य फ़्रेम‑स्तरीय स्वरूपण का स्वामी है।

इसलिए, छवि परिवर्तन क्रियाएँ [PPImage](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ppimage/) में बाइट्स को संशोधित नहीं करतीं। जब वही [PPImage](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ppimage/) को [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/shapecollection/) में अधिक बार पास किया जाता है, तो प्रत्येक नया चित्र फ़्रेम अपना स्वयं का [Picture](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/picture/) और अपनी परिवर्तन संग्रह प्राप्त करता है। एक फ़्रेम पर ग्रेस्केल लागू करने से अन्य फ़्रेम ग्रेस्केल नहीं होते, भले ही सभी एक ही एम्बेडेड छवि संसाधन को पुनः उपयोग करें।

उसी [Picture.getImageTransform](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/picture/) मॉडल का उपयोग अन्य चित्र भरावों, जैसे आकार या स्लाइड पृष्ठभूमि, द्वारा भी किया जाता है। नीचे के उदाहरण केवल चित्र फ़्रेमों पर केंद्रित हैं।

## **वैध पैरामीटर सीमा और इकाइयों का उपयोग करें**

प्रदर्शित विधियों में निम्नलिखित अर्थपूर्ण सीमाएँ और इकाइयाँ उपयोग की जाती हैं। इन सीमाओं के भीतर मान रखें, भले ही कोई विशेष लाइब्रेरी संस्करण हर बाहर‑रेंज मान को तुरंत अस्वीकार न करे; लक्ष्य प्रस्तुति प्रारूप सहेजते समय या PowerPoint फ़ाइल खोलते समय असमान्य डेटा को सामान्यीकृत, हटाए या अस्वीकार कर सकता है।

| ऑपरेशन | परामीटर | वैध सीमा और इकाई |
|---|---|---|
| [addBrightnessContrastEffect](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `brightness`, `contrast` | `-100` से `100` तक, प्रतिशत; `0` घटक को अपरिवर्तित छोड़ता है। |
| [addGrayScaleEffect](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/imagetransformoperationcollection/) | None | कोई संख्यात्मक परामितियाँ नहीं। अल्फा अपरिवर्तित रहता है। |
| [addDuotoneEffect](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `color1`, `color2` | गहरे और हल्के पिक्सेल के लिए दो रंग। `java.awt.Color` में RGB और अल्फा चैनल `0` से `255` तक होते हैं। |
| [addTintEffect](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `hue`, `amount` | ह्यू `0` (समावेशी) से `360` (बहिष्कृत) डिग्री; मात्रा `-100` से `100` प्रतिशत। |
| [addHSLEffect](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `hue`, `saturation`, `luminance` | ह्यू `0` से `360` डिग्री; संतृप्ति और प्रकाशता `-100` से `100` प्रतिशत। |
| [addColorReplaceEffect](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `color` | प्रतिस्थापन रंग के चैनल मान `0` से `255` तक होते हैं। मौजूदा अल्फा मान अपरिवर्तित रहता है। |
| [addBlurEffect](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `radius`, `grow` | त्रिज्या नकारात्मक नहीं और पॉइंट में मापी जाती है; `grow` एक बूलियन है जो निर्धारित करता है कि धुंधला सामग्री मूल सीमा से बाहर विस्तारित हो सकती है या नहीं। |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `amount` | नकारात्मक नहीं प्रतिशत। सामान्य अपारदर्शिता स्केलिंग के लिए `0` से `100` उपयोग करें: `0` पूरी तरह पारदर्शी और `100` मौजूदा अल्फा को बरकरार रखता है। |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `alpha` | `0` से `100` प्रतिशत अपारदर्शिता। |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `threshold` | `0` से `100` प्रतिशत अल्फा थ्रेशोल्ड। इस से नीचे के मान पारदर्शी हो जाते हैं; इस या इससे ऊपर के मान अपारदर्शी हो जाते हैं। |

स्थिर अल्फा मॉड्यूलेशन के लिए, पारदर्शिता और अपारदर्शिता परस्पर पूरक हैं। उदाहरण के लिए, 35 % पारदर्शिता का अर्थ 65 % अल्फा मॉड्यूलेशन मात्रा है।

## **चमक और कंट्रास्ट लागू करें**

[ImageTransformOperationCollection.addBrightnessContrastEffect](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/imagetransformoperationcollection/) एक [BrightnessContrast](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/brightnesscontrast/) ऑपरेशन वापस करता है। इसके स्केलर सेटिंग्स ऑपरेशन निर्माण के समय प्रदान की जाती हैं। [BrightnessContrast.getEffective](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/brightnesscontrast/) गणना किए गए केवल‑पढ़ने‑योग्य मान लौटाता है जिन्हें निरीक्षण या लॉग किया जा सकता है।

नीचे दिया गया उदाहरण चमक को 15 % और कंट्रास्ट को 20 % बढ़ाता है, फिर एम्बेडेड छवि को संशोधित किए बिना एक पूर्वावलोकन रेंडर करता है:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 50, 400, 260, image);
    const imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
    const brightnessContrast = imageTransform.addBrightnessContrastEffect(15, 20);

    const effectiveValues = brightnessContrast.getEffective();
    console.log("Brightness: " + effectiveValues.getBrightness() + "%");
    console.log("Contrast: " + effectiveValues.getContrast() + "%");

    const preview = slide.getImage();
    try {
        preview.save("brightness-contrast-preview.png", aspose.slides.ImageFormat.Png);
    } finally {
        preview.dispose();
    }
} finally {
    presentation.dispose();
}
```

[BrightnessContrast](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/brightnesscontrast/) Office 2010 चित्र‑इफ़ेक्ट विस्तार है और मानक DrawingML प्रकाशता इफ़ेक्ट की तुलना में कम पोर्टेबल है। जब चमक और कंट्रास्ट को PPTX राउंड‑ट्रिप के बाद भी संपादन योग्य रखना हो, तो [ImageTransformOperationCollection.addLuminanceEffect](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/imagetransformoperationcollection/) उपयोग करें और फ़ाइल को पुनः खोलने के बाद परिणाम सत्यापित करें। स्वरूप सीमाएँ अनुभाग इस अंतर को अधिक विस्तार से समझाता है।

## **रंग रूपांतरण लागू करें**

रंग इफ़ेक्ट विभिन्न चित्र फ़्रेमों पर स्वतंत्र रूप से लागू किए जा सकते हैं जो एक ही छवि संसाधन को पुनः उपयोग करते हैं। नीचे दिया गया उदाहरण पाँच फ़्रेम बनाता है और क्रमशः ग्रेस्केल, डुओटोन, टिंट, HSL समायोजन, और रंग प्रतिस्थापन लागू करता है।

[Duotone](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/duotone/) दो स्वतंत्र रूप से संपादन योग्य रंग परामितियों को रखता है: `color1` अंधेरे पिक्सेल को मैप करता है, जबकि `color2` हल्के पिक्सेल को। यह एक ऐसा इफ़ेक्ट उदाहरण बनाता है जिसकी सेटिंग्स एकल स्केलर मान से अधिक जटिल होती हैं।

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const grayFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 20, 180, 120, image);
    grayFrame.getPictureFormat().getPicture().getImageTransform().addGrayScaleEffect();

    const duotoneFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 220, 20, 180, 120, image);
    const duotone = duotoneFrame.getPictureFormat().getPicture().getImageTransform().addDuotoneEffect();
    duotone.getColor1().setColor(java.newInstanceSync("java.awt.Color", 0, 0, 128));
    duotone.getColor2().setColor(java.newInstanceSync("java.awt.Color", 255, 215, 0));

    const tintFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 420, 20, 180, 120, image);
    tintFrame.getPictureFormat().getPicture().getImageTransform().addTintEffect(210, 35);

    const hslFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 120, 170, 180, 120, image);
    hslFrame.getPictureFormat().getPicture().getImageTransform().addHSLEffect(30, 20, -10);

    const replacementFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 320, 170, 180, 120, image);
    const colorReplacement = replacementFrame.getPictureFormat().getPicture().getImageTransform().addColorReplaceEffect();
    colorReplacement.getColor().setColor(java.newInstanceSync("java.awt.Color", 100, 149, 237));

    presentation.save("color-transformations.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[addColorReplaceEffect](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/imagetransformoperationcollection/) प्रत्येक पिक्सेल के रंग को एक निश्चित रंग से बदलता है जबकि अल्फा को संरक्षित रखता है। यह [addColorChangeEffect](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/imagetransformoperationcollection/) से अलग है, जो एक स्रोत रंग को दूसरे में मैप करता है और स्रोत तथा लक्ष्य दोनों रंग स्वरूप दिखाता है।

## **धुंध, पारदर्शिता, और अल्फा इफ़ेक्ट जोड़ें**

[addBlurEffect](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/imagetransformoperationcollection/) सभी रंग चैनलों को प्रभावित करता है, जिसमें अल्फा भी शामिल है। जब धुंधली किनारी मूल चित्र की सीमा से बाहर तक विस्तारित हो सकती है तो `grow` को `true` करें।

समान पारदर्शिता के लिए, [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/imagetransformoperationcollection/) उपयोग करें। यह प्रत्येक मौजूदा अल्फा मान को गुणा करता है, इसलिए आंशिक रूप से पारदर्शी पिक्सेल अनुपातिक रूप से अलग रहते हैं। [addAlphaReplaceEffect](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/imagetransformoperationcollection/) सभी पिक्सेल को एक ही अल्फा मान देता है। [addAlphaBiLevelEffect](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/imagetransformoperationcollection/) थ्रेशोल्ड के आधार पर अल्फा को दो स्तरों में परिवर्तित करता है।

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const blurredFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 20, 200, 140, image);
    const blur = blurredFrame.getPictureFormat().getPicture().getImageTransform().addBlurEffect(4.5, true);
    blur.setRadius(5);

    const transparentFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 240, 20, 200, 140, image);
    const alphaModulate = transparentFrame.getPictureFormat().getPicture().getImageTransform().addAlphaModulateFixedEffect(65);
    alphaModulate.setAmount(60);

    const uniformAlphaFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 180, 200, 140, image);
    uniformAlphaFrame.getPictureFormat().getPicture().getImageTransform().addAlphaReplaceEffect(55);

    const binaryAlphaFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 240, 180, 200, 140, image);
    const alphaBiLevel = binaryAlphaFrame.getPictureFormat().getPicture().getImageTransform().addAlphaBiLevelEffect(50);
    alphaBiLevel.setThreshold(45);
    binaryAlphaFrame.getPictureFormat().getPicture().getImageTransform().addAlphaInverseEffect();

    presentation.save("blur-and-alpha-effects.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

अन्य पैरामीटर‑रहित अल्फा क्रियाएँ शामिल हैं [addAlphaCeilingEffect](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/imagetransformoperationcollection/), जो हर गैर‑शून्य अल्फा को पूरी तरह अपारदर्शी बनाता है; [addAlphaFloorEffect](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/imagetransformoperationcollection/), जो 100 % से कम सभी अल्फा को पूरी तरह पारदर्शी बनाता है; और [addAlphaInverseEffect](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/imagetransformoperationcollection/), जो अल्फा को `100% - alpha` में बदलता है।

## **क्रमबद्ध इफ़ेक्ट श्रृंखला बनाएं**

हर `add...Effect` विधि संग्रह के अंत में एक नया ऑपरेशन जोड़ती है। रेंडरर संग्रह को क्रमबद्ध पाइपलाइन के रूप में उपयोग करता है: ऑपरेशन 0 का आउटपुट ऑपरेशन 1 का इनपुट बनता है, आदि। इसलिए एक ही ऑपरेशनों को अलग क्रम में रखने से अलग छवि प्राप्त हो सकती है।

उदाहरण के लिए, ग्रेस्केल के बाद टिंट लगाने से पहले क्रोमैटिक जानकारी हटाई जाती है और फिर ल्यूमिनेंस परिणाम पर पुनः रंग लगाया जाता है। टिंट के बाद ग्रेस्केल लगाने से टिंट हट जाता है। इसी प्रकार, अल्फा प्रतिस्थापन पहले के ऑपरेशनों द्वारा गणना किए गए अल्फा मानों को अधिलेखित कर सकता है, जबकि अल्फा मॉड्यूलेशन उनके सापेक्ष अंतर को संरक्षित रखता है।

नीचे दिया गया उदाहरण चार‑ऑपरेशन श्रृंखला बनाता है, उसे PPTX के रूप में सहेजता है, प्रस्तुति को पुनः खोलता है, दोनों ऑपरेशन प्रकारों और उनके क्रम को जांचता है, और पुनः खोले हुए परिणाम को रेंडर करता है:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 50, 400, 260, image);
    const imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
    imageTransform.addGrayScaleEffect();
    imageTransform.addTintEffect(220, 25);
    imageTransform.addBlurEffect(2.5, false);
    imageTransform.addAlphaModulateFixedEffect(80);

    presentation.save("image-transform-chain.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

const reopenedPresentation = new aspose.slides.Presentation("image-transform-chain.pptx");
try {
    const reopenedShape = reopenedPresentation.getSlides().get_Item(0).getShapes().get_Item(0);

    if (java.instanceOf(reopenedShape, "com.aspose.slides.IPictureFrame")) {
        const reopenedTransform = reopenedShape.getPictureFormat().getPicture().getImageTransform();
        const orderIsPreserved = reopenedTransform.size() === 4 &&
            java.instanceOf(reopenedTransform.get_Item(0), "com.aspose.slides.IGrayScale") &&
            java.instanceOf(reopenedTransform.get_Item(1), "com.aspose.slides.ITint") &&
            java.instanceOf(reopenedTransform.get_Item(2), "com.aspose.slides.IBlur") &&
            java.instanceOf(reopenedTransform.get_Item(3), "com.aspose.slides.IAlphaModulateFixed");
        console.log(orderIsPreserved ? "The effect chain was preserved." : "The effect chain changed during the round trip.");

        const renderedSlide = reopenedPresentation.getSlides().get_Item(0).getImage();
        try {
            renderedSlide.save("reopened-effect-chain.png", aspose.slides.ImageFormat.Png);
        } finally {
            renderedSlide.dispose();
        }
    } else {
        console.log("The reopened shape is not a picture frame.");
    }
} finally {
    reopenedPresentation.dispose();
}
```

संग्रह किसी ऐसा संगतता मैट्रिक्स लागू नहीं करता जो रंग, अल्फा, और धुंध ऑपरेशनों को अलग‑अलग श्रृंखलाओं में सीमित करता हो। इन्हें सम्मिलित किया जा सकता है, लेकिन संयोजन हमेशा उपयोगी नहीं होते। एक स्थिर रंग प्रतिस्थापन पहले के रंग इफ़ेक्टों द्वारा उत्पन्न RGB विविधता को हटा देता है; डुओटोन के बाद ग्रेस्केल दो चयनित रंगों को हटा देता है; और अल्फा सीलिंग, फ़्लोर, प्रतिस्थापन, या बाइ‑लेवल ऑपरेशन पूर्व में निर्मित अल्फा विवरण को खारिज कर सकते हैं। श्रृंखला को वांछित पिक्सेल‑प्रसंस्करण क्रम के अनुसार बनाएँ, न कि इसके आइटमों को अव्यवस्थित स्वरूप Flags मानकर।

## **संपादन योग्य और प्रभावी मानों का निरीक्षण करें**

एक संपादन योग्य ऑपरेशन वह वस्तु है जो [Picture.getImageTransform](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/picture/) में संग्रहीत होती है। प्रभाव के अनुसार, यह सीधे लिखने योग्य सदस्य प्रकट कर सकता है। उदाहरण के लिए, [Blur](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/blur/) लिखने योग्य `radius` और `grow` मान प्रदर्शित करता है, [AlphaModulateFixed](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/alphamodulatefixed/) लिखने योग्य `amount` दिखाता है, और [AlphaBiLevel](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/alphabilevel/) लिखने योग्य `threshold` दिखाता है। जैसे [Duotone](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/duotone/) रंग प्रभाव mutable [ColorFormat](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/colorformat/) ऑब्जेक्ट्स को उजागर करता है।

कुछ ऑपरेशनों, जैसे [BrightnessContrast](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/brightnesscontrast/), [HSL](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/hsl/), [Tint](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/tint/), और [AlphaReplace](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/alphareplace/), अपनी निर्माण स्केलर को लिखने योग्य प्रॉपर्टी के रूप में उजागर नहीं करते। इन सेटिंग्स को बदलने के लिए, ऑपरेशन को हटाएँ और आवश्यक स्थान पर एक नया प्रतिस्थापन जोड़ें।

`getEffective()` द्वारा लौटाया गया प्रभावी डेटा गणना किया हुआ और केवल‑पढ़ने‑योग्य है। यह थीम‑निर्भर रंगों को हल करने और रेंडरर द्वारा उपयोग किए गए सामान्यीकृत मानों को पढ़ने में उपयोगी है, परन्तु यह कोई अन्य संपादन सतह नहीं है। नीचे का उदाहरण श्रृंखला को सूचीबद्ध करता है और जहाँ संबंधित API प्रदान करती है, प्रभावी मानों का निरीक्षण करता है:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("image-transform-chain.pptx");
try {
    const shapes = presentation.getSlides().get_Item(0).getShapes();
    let pictureFrame = null;

    for (let index = 0; index < shapes.size(); index++) {
        const shape = shapes.get_Item(index);
        if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            pictureFrame = shape;
            break;
        }
    }

    if (pictureFrame != null) {
        const imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();

        for (let index = 0; index < imageTransform.size(); index++) {
            const operation = imageTransform.get_Item(index);
            console.log(index + ": " + operation.getClass().getSimpleName());

            if (java.instanceOf(operation, "com.aspose.slides.IBrightnessContrast")) {
                const data = operation.getEffective();
                console.log("  Brightness: " + data.getBrightness());
                console.log("  Contrast: " + data.getContrast());
            } else if (java.instanceOf(operation, "com.aspose.slides.ILuminance")) {
                const data = operation.getEffective();
                console.log("  Brightness: " + data.getBrightness());
                console.log("  Contrast: " + data.getContrast());
            } else if (java.instanceOf(operation, "com.aspose.slides.IDuotone")) {
                const data = operation.getEffective();
                console.log("  Dark color: " + data.getColor1());
                console.log("  Light color: " + data.getColor2());
            } else if (java.instanceOf(operation, "com.aspose.slides.IColorReplace")) {
                const data = operation.getEffective();
                console.log("  Replacement color: " + data.getColor());
            } else if (java.instanceOf(operation, "com.aspose.slides.IHSL")) {
                const data = operation.getEffective();
                console.log("  HSL: " + data.getHue() + ", " + data.getSaturation() + ", " + data.getLuminance());
            } else if (java.instanceOf(operation, "com.aspose.slides.ITint")) {
                const data = operation.getEffective();
                console.log("  Tint: " + data.getHue() + ", " + data.getAmount());
            } else if (java.instanceOf(operation, "com.aspose.slides.IBlur")) {
                const data = operation.getEffective();
                console.log("  Blur radius: " + data.getRadius() + " pt");
            } else if (java.instanceOf(operation, "com.aspose.slides.IAlphaModulateFixed")) {
                const data = operation.getEffective();
                console.log("  Alpha amount: " + data.getAmount() + "%");
            } else if (java.instanceOf(operation, "com.aspose.slides.IAlphaReplace")) {
                const data = operation.getEffective();
                console.log("  Replacement alpha: " + data.getAlpha() + "%");
            } else if (java.instanceOf(operation, "com.aspose.slides.IAlphaBiLevel")) {
                const data = operation.getEffective();
                console.log("  Alpha threshold: " + data.getThreshold() + "%");
            }
        }
    }
} finally {
    presentation.dispose();
}
```

ग्रेस्केल, अल्फा सीलिंग, और अल्फा इनवर्स जैसे पैरामीटर‑रहित प्रभावों के पास भी एक प्रभावी‑डेटा ऑब्जेक्ट होता है, लेकिन प्रिंट करने के लिए कोई स्केलर सेटिंग नहीं होती। उनका संग्रह में उपस्थित होना और स्थान ही महत्वपूर्ण जानकारी है।

## **छवि परिवर्तन हटाएं या साफ़ करें**

एक ऑपरेशन को इंडेक्स द्वारा हटाने के लिए [ImageTransformOperationCollection.removeAt](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/imagetransformoperationcollection/) उपयोग करें। चूँकि हटाने के बाद इंडेक्स शिफ्ट हो जाते हैं, पहले लक्ष्य को खोजें और सूचीबद्ध करने के बाद उसे हटाएँ। पूरी श्रृंखला को हटाने के लिए [ImageTransformOperationCollection.clear](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/imagetransformoperationcollection/) उपयोग करें।

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("image-transform-chain.pptx");
try {
    const shapes = presentation.getSlides().get_Item(0).getShapes();
    let pictureFrame = null;

    for (let index = 0; index < shapes.size(); index++) {
        const shape = shapes.get_Item(index);
        if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            pictureFrame = shape;
            break;
        }
    }

    if (pictureFrame != null) {
        const imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
        let blurIndex = -1;

        for (let index = 0; index < imageTransform.size(); index++) {
            if (java.instanceOf(imageTransform.get_Item(index), "com.aspose.slides.IBlur")) {
                blurIndex = index;
                break;
            }
        }

        if (blurIndex >= 0) {
            imageTransform.removeAt(blurIndex);
            console.log("The blur operation was removed.");
        }

        imageTransform.clear();
        console.log("Remaining operations: " + imageTransform.size());
        presentation.save("image-transforms-cleared.pptx", aspose.slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

परिवर्तनों को हटाना या साफ़ करना केवल चित्र स्वरूपण को बदलता है। यह पुनः उपयोग किए गए [PPImage](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ppimage/) संसाधन को न तो हटाता है, न ही पुनः संपीड़ित करता है, न ही अन्यथा बदलता है।

## **प्रेजेंटेशन फ़ॉर्मेट और निर्यात लक्ष्यों पर विचार करें**

छवि परिवर्तन DrawingML से उत्पन्न होते हैं, इसलिए इफ़ेक्ट श्रृंखलाओं के लिए PPTX पसंदीदा संपादन योग्य फ़ॉर्मेट है। यहाँ तक कि PPTX के साथ भी हर ऑपरेशन की पोर्टेबिलिटी समान नहीं है:

- मानक DrawingML ऑपरेशन जैसे ल्यूमिनेंस, ग्रेस्केल, डुओटोन, टिंट, HSL, धुंध, और सामान्य अल्फा ऑपरेशन PPTX राउंड‑ट्रिप में जीवित रहने की सबसे अधिक संभावना रखते हैं। जब संरक्षण आवश्यक हो, हमेशा उत्पन्न फ़ाइल को पुनः खोलें और संग्रह की जाँच करें।
- [BrightnessContrast](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/brightnesscontrast/) Office 2010 विस्तार है न कि मानक DrawingML ल्यूमिनेंस ऑपरेशन। इसे मेमोरी में रेंडरिंग के लिए उपयोग किया जा सकता है, लेकिन सहेजने और PPTX पुनः खोलने के बाद यह संपादन योग्य [BrightnessContrast](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/brightnesscontrast/) ऑपरेशन के रूप में बना रहेगा, इसकी कोई गारंटी नहीं है। स्थायी चमक‑कंट्रास्ट समायोजन के लिए [addLuminanceEffect](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/imagetransformoperationcollection/) को प्राथमिकता दें।
- बाइनरी PPT फ़ॉर्मेट पूर्ण DrawingML इफ़ेक्ट मॉडल से पूर्व है। PPT में सहेजने से असमर्थित ऑपरेशन छोड़े जा सकते हैं, श्रृंखला को समर्थित उपसमुच्चय में घटाया जा सकता है, या रूप में अनुमानित किया जा सकता है। जटिल संपादन योग्य श्रृंखला के सत्यापन फ़ॉर्मेट के रूप में PPT का उपयोग न करें।
- PNG, JPEG, TIFF, PDF, SVG, HTML या अन्य दृश्य आउटपुट पर रेंडरिंग समर्थनीय श्रृंखला को रेंडर किए गए स्वरूप में लागू करती है। इन आउटपुट में संपादन योग्य [ImageTransformOperationCollection](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/imagetransformoperationcollection/) नहीं होता; रास्टर फ़ॉर्मेट परिणाम को पिक्सेल में फ्लैट कर देते हैं, और दस्तावेज़/वेक्टर निर्यात अपना स्वयं का रेंडरिंग प्रतिनिधित्व संग्रहीत करते हैं।
- इफ़ेक्ट लिंक्ड छवि को आत्म‑समाहित नहीं बनाते। लिंक्ड चित्र का रेंडरिंग तब भी लिंक्ड संसाधन की उपलब्धता पर निर्भर करता है जब प्रस्तुति लोड की जाती है।

विभिन्न प्रस्तुति उपभोक्ता किनारी मामलों को अलग‑अलग रेंडर कर सकते हैं, विशेष रूप से जब कई अल्फा या रंग‑क्वांटाइज़िंग ऑपरेशनों को संयोजित किया जाता है। महत्वपूर्ण आउटपुट के लिए, उत्पादन में उपयोग किए जा रहे उसी Aspose.Slides संस्करण के साथ संपादन योग्य राउंड‑ट्रिप और अंतिम निर्यात फ़ॉर्मेट दोनों का परीक्षण करें।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या छवि परिवर्तन इफ़ेक्ट एम्बेडेड छवि डेटा को संशोधित करते हैं?**

नहीं। ये ऑपरेशन उन [Picture](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/picture/) से संबंधित हैं जो चित्र भराव द्वारा उपयोग किए जाते हैं। अंतर्निहित [PPImage](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ppimage/) बाइट्स अपरिवर्तित रहती हैं।

**क्या दो चित्र फ़्रेम जो एक ही छवि को पुनः उपयोग करते हैं, अपने इफ़ेक्ट साझा करेंगे?**

नहीं। एक ही [PPImage](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ppimage/) को पुनः उपयोग करने से डुप्लिकेट छवि डेटा से बचा जाता है, लेकिन प्रत्येक चित्र फ़्रेम आमतौर पर अपना अलग [Picture](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/picture/) और छवि परिवर्तन संग्रह रखता है।

**क्या रंग, धुंध, और अल्फा इफ़ेक्ट को संयोजित किया जा सकता है?**

हां। संग्रह उन्हें एक क्रमबद्ध श्रृंखला में स्वीकार करता है। प्रत्येक ऑपरेशन पहले वाले आउटपुट को कैसे बदलता है, इस पर विचार करें, क्योंकि प्रतिस्थापन और थ्रेशोल्ड ऑपरेशन पहले के रंग या अल्फा विवरण को हटा सकते हैं।

**प्रभावी मान केवल‑पढ़ने‑योग्य क्यों होते हैं?**

प्रभावी डेटा वह गणना किए गए मान होते हैं जो रेंडरिंग के लिए उपयोग होते हैं, जिसमें हल किए गए रंग शामिल हैं। जहाँ लिखने योग्य सदस्य मौजूद हों, ट्रांसफ़ॉर्म संग्रह में संग्रहीत ऑपरेशन को संपादित करें; अन्यथा उसे हटाकर नई निर्माण परामितियों के साथ प्रतिस्थापन जोड़ें।

**किस फ़ॉर्मेट का उपयोग करना चाहिए ताकि एक ट्रांसफ़ॉर्म श्रृंखला सुरक्षित रहे?**

PPTX का उपयोग करें और फ़ाइल को पुनः खोलकर सत्यापित करें। लेगेसी PPT पूर्ण DrawingML इफ़ेक्ट मॉडल को प्रदर्शित नहीं कर सकता, और रेंडर किए गए निर्यात फ़ॉर्मेट स्वरूप केवल दृश्य उपस्थिति को संरक्षित रखते हैं, न कि संपादन योग्य ट्रांसफ़ॉर्म ऑपरेशन।