---
title: प्रस्तुतियों में जावास्क्रिप्ट के साथ इमेज ट्रांसफ़ॉर्म इफ़ेक्ट्स को प्रबंधित करें
linktitle: इमेज ट्रांसफ़ॉर्म इफ़ेक्ट्स
type: docs
weight: 11
url: /hi/nodejs-java/image-transform-effects/
keywords:
- इमेज ट्रांसफ़ॉर्म
- पिक्चर इफ़ेक्ट
- उज्ज्वलता
- कंट्रास्ट
- ग्रेस्केल
- डुओटोन
- टिंट
- HSL
- रंग प्रतिस्थापन
- ब्लर
- पारदर्शिता
- अल्फा इफ़ेक्ट
- इफ़ेक्ट चेन
- पावरपॉइंट
- प्रस्तुति
- Node.js
- जावास्क्रिप्ट
- Aspose.Slides
description: "Aspose.Slides for Node.js के माध्यम से Java में चित्र फ्रेम के लिए इमेज ट्रांसफ़ॉर्म इफ़ेक्ट्स को लागू करें, चेन बनाएं, निरीक्षण करें, हटाएँ और सत्यापित करें।"
---
## **अवलोकन**

Aspose.Slides चित्र समायोजनों को छवि रूपांतरण कार्यों के क्रमबद्ध संग्रह के रूप में दर्शाता है। किसी picture frame के लिए, फ्रेम की [Picture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/) से शुरू करें और [Picture.getImageTransform](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/) तक पहुँचें। लौटाया गया [ImageTransformOperationCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) आपको प्रभावों को जोड़ने, क्रमबद्ध करने, निरीक्षण करने, हटाने और साफ़ करने की अनुमति देता है बिना मूल छवि बाइट्स को पुनः लिखे।

यह लेख उज्ज्वलता और कंट्रास्ट, रंग रूपांतरण, धुंधलापन, पारदर्शिता, क्रमबद्ध इफ़ेक्ट चेन, प्रभावी मान, हटाना, और PPTX राउंड‑ट्रिप प्रमाणीकरण के लिए सम्पूर्ण कार्यप्रवाह दर्शाता है।

## **इफ़ेक्ट स्वामित्व और छवि पुन: उपयोग को समझें**

एक छवि संसाधन और उसे प्रदर्शित करने वाला picture अलग‑अलग वस्तुएँ हैं:

- [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/) प्रस्तुति द्वारा स्वामित्व वाले स्रोत छवि डेटा को संग्रहित या संदर्भित करता है।
- [Picture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/) एक picture fill से संबंधित है और एक छवि संसाधन को संदर्भित करता है जबकि छवि रूपांतरण संग्रह को संग्रहीत करता है।
- [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/) वह स्लाइड आकार है जो संबंधित picture fill, ज्यामिति, क्रॉप सेटिंग्स, और अन्य फ्रेम‑स्तर स्वरूपण को रखता है।

इसलिए, छवि रूपांतरण कार्य [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/) के बाइट्स को संशोधित नहीं करते। जब वही [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/) को [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/) को कई बार पास किया जाता है, तो प्रत्येक नया picture frame अपना स्वयं का [Picture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/) और अपना स्वयं का रूपांतरण संग्रह प्राप्त करता है। एक फ्रेम पर ग्रेस्केल लागू करने से अन्य फ्रेम ग्रेस्केल नहीं बनते, भले ही सभी एक ही एम्बेडेड छवि संसाधन को पुनः उपयोग करते हों।

वही [Picture.getImageTransform](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/) मॉडल अन्य picture fill, जैसे shape या स्लाइड बैकग्राउंड, द्वारा भी उपयोग किया जाता है। नीचे के उदाहरण picture frames पर केंद्रित हैं।

## **वैध पैरामीटर रेंज और इकाइयाँ उपयोग करें**

प्रदर्शित विधियाँ निम्नलिखित अर्थपूर्ण रेंज और इकाइयों का उपयोग करती हैं। इन रेंजों के भीतर मान रखें भले ही कोई विशेष लाइब्रेरी संस्करण हर आउट‑ऑफ़‑रेंज मान को तुरंत न अस्वीकार करे; लक्ष्य प्रस्तुति स्वरूप सहेजने के समय या PowerPoint फ़ाइल खोलते समय डेटा को सामान्यीकृत, छोड़, या अस्वीकार कर सकता है।

| ऑपरिशन | पैरामीटर | मान्य सीमा और इकाई |
|---|---|---|
| [addBrightnessContrastEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `brightness`, `contrast` | `-100` से `100` तक, प्रतिशत; `0` घटक को अपरिवर्तित रखता है। |
| [addGrayScaleEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | None | कोई संख्यात्मक पैरामीटर नहीं। अल्फा अपरिवर्तित रहता है। |
| [addDuotoneEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `color1`, `color2` | गहरे और हल्के पिक्सेल के लिए दो रंग। `java.awt.Color` में RGB और अल्फा चैनल `0` से `255` तक उपयोग करते हैं। |
| [addTintEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `hue`, `amount` | ह्यू `0` (समावेशी) से `360` (बहिष्कृत) डिग्री; मात्रा `-100` से `100` तक, प्रतिशत। |
| [addHSLEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `hue`, `saturation`, `luminance` | ह्यू `0` (समावेशी) से `360` (बहिष्कृत) डिग्री; सैचुरेशन और ल्यूमिनेंस `-100` से `100` तक, प्रतिशत। |
| [addColorReplaceEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `color` | प्रतिस्थापन रंग चैनल मान `0` से `255` तक होते हैं। मौजूदा अल्फा मान अपरिवर्तित रहता है। |
| [addBlurEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `radius`, `grow` | रेडियस नॉन‑नेगेटिव है और पॉइंट में मापा जाता है; `grow` एक Boolean है जो निर्धारित करता है कि धुंधला कंटेंट मूल सीमा से बाहर विस्तारित हो सकता है या नहीं। |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `amount` | नॉन‑नेगेटिव प्रतिशत। सामान्य अपारदर्शिता स्केलिंग के लिए `0` से `100` का उपयोग करें: `0` पूरी तरह पारदर्शी और `100` मौजूदा अल्फा को संरक्षित करता है। |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `alpha` | `0` से `100` तक, प्रतिशत अपारदर्शिता। |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `threshold` | `0` से `100` तक, प्रतिशत अल्फा थ्रेशोल्ड। इस मान से नीचे के मान पारदर्शी हो जाते हैं; इस मान के बराबर या ऊपर के मान अपारदर्शी हो जाते हैं। |

स्थिर अल्फा मॉड्यूलेशन के लिए, ट्रांसपेरेंसी और अपारदर्शिता परस्पर पूरक हैं। उदाहरण के तौर पर, 35 % ट्रांसपेरेंसी का अर्थ है अल्फा मॉड्यूलेशन मात्रा 65 %।

## **उज्ज्वलता और कंट्रास्ट लागू करें**

[ImageTransformOperationCollection.addBrightnessContrastEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) एक [BrightnessContrast](https://reference.aspose.com/slides/nodejs-java/aspose.slides/brightnesscontrast/) कार्य लौटाता है। इसके स्केलर सेटिंग्स ऑपरेशन बनाते समय प्रदान की जाती हैं। [BrightnessContrast.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/brightnesscontrast/) गणना किए गए रीड‑ओनली मान लौटाता है जिन्हें निरीक्षण या लॉग किया जा सकता है।

निम्न उदाहरण उज्ज्वलता को 15 % और कंट्रास्ट को 20 % बढ़ाता है, फिर एम्बेडेड छवि को संशोधित किए बिना एक पूर्वावलोकन रेंडर करता है:

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

[BrightnessContrast](https://reference.aspose.com/slides/nodejs-java/aspose.slides/brightnesscontrast/) एक Office 2010 picture‑effect विस्तार है और मानक DrawingML ल्यूमिनेंस इफ़ेक्ट की तुलना में कम पोर्टेबल है। जब उज्ज्वलता और कंट्रास्ट को PPTX राउंड‑ट्रिप के बाद भी संपादनीय रखना हो, तो [ImageTransformOperationCollection.addLuminanceEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) का उपयोग करें और फ़ाइल को पुनः खोलने के बाद परिणाम जाँचें। फ़ॉर्मेट सीमाएँ भाग इस अंतर को और विस्तार से समझाती हैं।

## **रंग रूपांतरण लागू करें**

रंग प्रभावों को विभिन्न picture frames पर स्वतंत्र रूप से लागू किया जा सकता है जो एक ही छवि संसाधन को पुनः उपयोग करते हैं। नीचे का उदाहरण पाँच फ्रेम बनाता है और क्रमशः ग्रेस्केल, डुओटोन, टिंट, HSL समायोजन, और रंग प्रतिस्थापन लागू करता है।

[Duotone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/duotone/) दो स्वतंत्र रूप से संपादन योग्य रंग पैरामीटर रखता है: `color1` गहरे पिक्सेल को मैप करता है, जबकि `color2` हल्के पिक्सेल को। यह एक उपयोगी उदाहरण है जहाँ सेटिंग्स एकल स्केलर मान से अधिक जटिल होती हैं।

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

[addColorReplaceEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) प्रत्येक पिक्सेल के रंग को एक निश्चित रंग से बदलता है जबकि अल्फा को संरक्षित रखता है। यह [addColorChangeEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) से अलग है, जो एक स्रोत रंग को दूसरे में मैप करता है और दोनों स्रोत तथा लक्ष्य रंग स्वरूप को उजागर करता है।

### **ल्यूमिनेंस थ्रेशोल्ड लागू करें**

एक ल्यूमिनेंस थ्रेशोल्ड स्कैन की गई पृष्ठ की धुंधली निशानों को पृष्ठभूमि से अधिक स्पष्ट बना सकता है। [addGrayScaleEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) मध्यवर्ती ग्रे शेड्स को रखता है। [addBiLevelEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) ल्यूमिनेंस को काला या सफ़ेद में मैप करता है, जबकि [addAlphaBiLevelEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) अपारदर्शिता पर थ्रेशोल्ड लागू करता है।

ल्यूमिनेंस थ्रेशोल्ड 0 % से 100 % (समावेशी) तक होता है। थ्रेशोल्ड से नीचे के पिक्सेल काले हो जाते हैं। थ्रेशोल्ड के बराबर या उससे ऊपर के पिक्सेल सफ़ेद हो जाते हैं। थ्रेशोल्ड बढ़ाने से अधिक शेड्स काले हो जाते हैं क्योंकि अधिक पिक्सेल कट‑ऑफ़ से नीचे गिरते हैं।

[grayscale-swatches.png](grayscale-swatches.png) को कार्य निर्देशिका में डाउनलोड करें। प्रत्येक लेबल मूल ग्रे स्तर को 0‑255 स्केल पर दर्शाता है। यह उदाहरण मूल को दो प्रतियों के साथ रखता है और प्रत्येक प्रतिलिपि का थ्रेशोल्ड प्रस्तुति में सहेजता है।

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    presentation.getSlideSize().setSize(720, 150, slides.SlideSizeScaleType.DoNotScale);
    const shapes = presentation.getSlides().get_Item(0).getShapes();

    const sourceImage = slides.Images.fromFile("grayscale-swatches.png");
    let image;
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const captions = ["Original", "Threshold 20%", "Threshold 60%"];
    const frames = [];
    for (let i = 0; i < captions.length; i++) {
        const x = 12 + 240 * i;
        const label = shapes.addAutoShape(slides.ShapeType.Rectangle, x, 12, 216, 36);
        label.getTextFrame().setText(captions[i]);
        const frame = shapes.addPictureFrame(slides.ShapeType.Rectangle, x, 60, 216, 72, image);
        frames.push(frame);
    }

    frames[1].getPictureFormat().getPicture().getImageTransform().addBiLevelEffect(20);
    frames[2].getPictureFormat().getPicture().getImageTransform().addBiLevelEffect(60);
    
    presentation.save("luminance-threshold.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

आउटपुट प्रस्तुति को PowerPoint में खोलें और तीन फ्रेम की तुलना करें। लेबल 96 वाली स्वॉच लगभग 38 % ल्यूमिनेंस (96 / 255) दर्शाती है। यह 20 % थ्रेशोल्ड पर सफ़ेद और 60 % थ्रेशोल्ड पर काली हो जाती है।

![Original grayscale swatches beside the black-and-white results at luminance thresholds of 20% and 60%](luminance-threshold.png)

## **धुंधलापन, पारदर्शिता, और अल्फा इफ़ेक्ट जोड़ें**

[addBlurEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) सभी रंग चैनलों, अल्फा सहित, को प्रभावित करता है। जब धुंधली किनारी मूल चित्र सीमा से बाहर जा सकती है, तो `grow` को `true` सेट करें।

समानांतर पारदर्शिता के लिए, [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) का उपयोग करें। यह प्रत्येक मौजूदा अल्फा मान को गुणा करता है, इसलिए आंशिक रूप से पारदर्शी पिक्सेल अनुपातिक रूप से अलग रहते हैं। [addAlphaReplaceEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) सभी पिक्सेल को एक ही अल्फा मान आवंटित करता है। [addAlphaBiLevelEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) अल्फा को थ्रेशोल्ड के आधार पर दो स्तरों में परिवर्तित करता है।

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

अन्य पैरामीटर‑रहित अल्फा कार्यों में शामिल हैं [addAlphaCeilingEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/), जो प्रत्येक नॉन‑ज़ीरो अल्फा को पूरी तरह अपारदर्शी कर देता है; [addAlphaFloorEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/), जो 100 % से कम अल्फा को पूरी तरह पारदर्शी बना देता है; और [addAlphaInverseEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/), जो अल्फा को `100% - alpha` में बदलता है।

## **क्रमबद्ध इफ़ेक्ट चेन बनाएं**

प्रत्येक `add...Effect` विधि संग्रह के अंत में एक नया ऑपरेशन जोड़ती है। रेंडरर संग्रह को क्रमबद्ध पाइपलाइन के रूप में उपयोग करता है: ऑपरेशन 0 का आउटपुट ऑपरेशन 1 का इनपुट बन जाता है, और इसी प्रकार आगे। इसलिए समान ऑपरेशन को अलग क्रम में रखने से अलग छवि बन सकती है।

उदाहरण के लिए, ग्रेस्केल के बाद टिंट पहले रंगीय जानकारी को हटा देता है और फिर ल्यूमिनेंस परिणाम को पुनः रंग देता है। टिंट के बाद ग्रेस्केल टिंट को फिर से हटाता है। इसी तरह, अल्फा प्रतिस्थापन पहले के ऑपरेशनों द्वारा गणित अल्फा मानों को अधिलेखित कर सकता है, जबकि अल्फा मॉड्यूलेशन उनके सापेक्ष अंतर को संरक्षित रखता है।

निम्न उदाहरण चार‑ऑपरेशन चेन बनाता है, इसे PPTX के रूप में सहेजता है, प्रस्तुति को पुनः खोलता है, दोनों ऑपरेशन प्रकार और क्रम की जाँच करता है, और पुनः खोली गई परिणाम को रेंडर करता है:

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

संग्रह कोई अनुकूलता मैट्रिक्स लागू नहीं करता जो रंग, अल्फा, और धुंधलापन ऑपरेशनों को अलग‑अलग चेन तक सीमित करता हो। इन्हें संयोजित किया जा सकता है, लेकिन सभी संयोजन हमेशा उपयोगी नहीं होते। एक स्थिर रंग प्रतिस्थापन पहले के रंग प्रभावों द्वारा उत्पन्न RGB विविधता को हटा देता है; डुओटोन के बाद ग्रेस्केल दो चयनित रंगों को हटाता है; और अल्फा सीलिंग, फ़्लोर, प्रतिस्थापन, या बाइलवल ऑपरेशन पहले निर्मित अल्फा विवरण को नष्ट कर सकते हैं। चेन को इच्छित पिक्सेल‑प्रोसेसिंग अनुक्रम के अनुसार बनायें, न कि इसे अनक्रमित स्वरूपण फ़्लैग मानें।

<!-- visual-explanation:image-transform-effects:start -->
[![The same image passes through grayscale then tint, and tint then grayscale. The two final grayscale images have different tones.](visual-image-transform-effects-49aa72211f3a.svg)](visual-image-transform-effects-49aa72211f3a.svg)

*In this illustrative Aspose.Slides for .NET 26.11 render, a 220° tint at 25% leaves the grayscale image unchanged. Applying the same tint before grayscale produces different tones.*
<!-- visual-explanation:image-transform-effects:end -->

## **संपादन योग्य और प्रभावी मान निरीक्षण करें**

एक संपादन योग्य ऑपरेशन वह ऑब्जेक्ट है जो [Picture.getImageTransform](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/) में संग्रहीत होता है। प्रभाव के अनुसार, यह सीधे लिखने योग्य सदस्य उजागर कर सकता है। उदाहरण के लिए, [Blur](https://reference.aspose.com/slides/nodejs-java/aspose.slides/blur/) लिखने योग्य `radius` और `grow` मान उजागर करता है, [AlphaModulateFixed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/alphamodulatefixed/) लिखने योग्य `amount` उजागर करता है, और [AlphaBiLevel](https://reference.aspose.com/slides/nodejs-java/aspose.slides/alphabilevel/) लिखने योग्य `threshold` उजागर करता है। [Duotone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/duotone/) जैसी रंग प्रभाव [ColorFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/colorformat/) ऑब्जेक्ट को बदले जाने योग्य बनाती हैं।

कुछ ऑपरेशन, जैसे [BrightnessContrast](https://reference.aspose.com/slides/nodejs-java/aspose.slides/brightnesscontrast/), [HSL](https://reference.aspose.com/slides/nodejs-java/aspose.slides/hsl/), [Tint](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tint/), और [AlphaReplace](https://reference.aspose.com/slides/nodejs-java/aspose.slides/alphareplace/), अपने निर्माण स्केलर को लिखने योग्य गुणों के रूप में उजागर नहीं करते। इन सेटिंग्स को बदलने के लिए, ऑपरेशन को हटाएँ और आवश्यक स्थान पर एक नया ऑपरेशन जोड़ें।

`getEffective()` द्वारा लौटाया गया प्रभावी डेटा गणना किया गया और रीड‑ओनली है। यह थीम‑निर्भर रंगों को हल करने और रेंडरर द्वारा उपयोग किए जाने वाले सामान्यीकृत मान पढ़ने के लिए उपयोगी है, लेकिन यह कोई अतिरिक्त संपादन सतह नहीं है। नीचे का उदाहरण चेन को क्रमबद्ध करता है और जहाँ संबंधित API प्रभावी मान प्रदान करती है, वहाँ उनका निरीक्षण करता है:

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

पैरामीटर‑रहित प्रभाव जैसे ग्रेस्केल, अल्फा सीलिंग, और अल्फा इनवर्स भी एक प्रभावी‑डेटा ऑब्जेक्ट रखते हैं, लेकिन प्रिंट करने के लिए कोई स्केलर सेटिंग नहीं होती। उनका संग्रह में उपस्थित होना और स्थिति ही महत्वपूर्ण जानकारी होती है।

## **छवि रूपांतरण हटाएँ या साफ़ करें**

एक ऑपरेशन को इंडेक्स द्वारा हटाने के लिए [ImageTransformOperationCollection.removeAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) का उपयोग करें। चूँकि हटाने के बाद इंडेक्स बदलते हैं, पहले लक्ष्य की खोज करें और क्रमबद्ध करने के बाद उसे हटाएँ। पूरी चेन हटाने के लिए [ImageTransformOperationCollection.clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) का उपयोग करें।

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

रूपांतरण हटाने या साफ़ करने से केवल picture फ़ॉर्मेटिंग बदलती है। यह पुनः उपयोग किए गए [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/) संसाधन को हटाता, पुनः‑संकुचित करता या अन्यथा संशोधित नहीं करता।

## **प्रेजेंटेशन फ़ॉर्मेट और निर्यात लक्ष्य पर विचार करें**

छवि रूपांतरण DrawingML में उत्पन्न होते हैं, इसलिए PPTX इफ़ेक्ट चेन के लिए प्राथमिक संपादन योग्य फ़ॉर्मेट है। PPTX के साथ भी, हर ऑपरेशन की पोर्टेबिलिटी समान नहीं होती:

- मानक DrawingML ऑपरेशन जैसे ल्यूमिनेंस, ग्रेस्केल, डुओटोन, टिंट, HSL, ब्लर, और सामान्य अल्फा ऑपरेशन PPTX राउंड‑ट्रिप के बाद बने रहने की सबसे अधिक संभावना रखते हैं। जब संरक्षण आवश्यक हो, हमेशा उत्पन्न फ़ाइल को पुनः खोलें और संग्रह का निरीक्षण करें।
- [BrightnessContrast](https://reference.aspose.com/slides/nodejs-java/aspose.slides/brightnesscontrast/) Office 2010 विस्तार है, मानक DrawingML ल्यूमिनेंस ऑपरेशन नहीं। इसे इन‑मेरी रेंडरिंग के लिए उपयोग किया जा सकता है, लेकिन इसे सहेजने और PPTX पुनः खोलने के बाद संपादन योग्य [BrightnessContrast](https://reference.aspose.com/slides/nodejs-java/aspose.slides/brightnesscontrast/) ऑपरेशन के रूप में रहने की गारंटी नहीं है। सतत उज्ज्वलता और कंट्रास्ट के लिए [addLuminanceEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) को प्राथमिकता दें।
- बाइनरी PPT फ़ॉर्मेट पूर्ण DrawingML इफ़ेक्ट मॉडल से पहले आया है। PPT में सहेजने से असमर्थित ऑपरेशन छोड़े जा सकते हैं, चेन को समर्थित उपसमुच्चय तक घटाया जा सकता है, या रूप दिखाया जा सकता है। जटिल संपादन योग्य चेन के लिए PPT को सत्यापन फ़ॉर्मेट के रूप में उपयोग न करें।
- PNG, JPEG, TIFF, PDF, SVG, HTML, या अन्य दृश्य आउटपुट पर रेंडर करने से समर्थित चेन लागू होती है, लेकिन ये आउटपुट संपादन योग्य [ImageTransformOperationCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) नहीं रखते; रास्टर फ़ॉर्मेट परिणाम को पिक्सल में फ़्लैट कर देते हैं, और दस्तावेज़/वेक्टर निर्यात अपने स्वयं के रेंडरिंग प्रतिनिधित्व को संग्रहीत करते हैं।
- इफ़ेक्ट लिंक्ड छवि को स्वावलंबी नहीं बनाते। लिंक्ड picture का रेंडरिंग तब भी लिंक्ड संसाधन उपस्थित होने पर निर्भर करता है जब प्रस्तुति लोड होती है।

विभिन्न प्रस्तुति उपभोक्ता किनारे के मामलों को अलग‑अलग रेंडर कर सकते हैं, विशेष रूप से जब कई अल्फा या रंग‑क्वांटाइज़िंग ऑपरेशन संयोजित हों। महत्वपूर्ण आउटपुट के लिए, वही Aspose.Slides संस्करण उपयोग करते हुए संपादन योग्य राउंड‑ट्रिप और अंतिम निर्यात फ़ॉर्मेट दोनों का परीक्षण करें।

## **FAQ**

**क्या छवि रूपांतरण इफ़ेक्ट एम्बेडेड छवि डेटा को संशोधित करते हैं?**

नहीं। ये ऑपरेशन उस [Picture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/) से संबंधित हैं जिसका उपयोग picture fill द्वारा किया जाता है। अंतर्निहित [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/) बाइट्स अपरिवर्तित रहती हैं।

**क्या दो picture frames जो एक ही छवि को पुनः उपयोग करते हैं, उनके इफ़ेक्ट साझा करते हैं?**

नहीं। एक [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/) को पुनः उपयोग करना डुप्लिकेट छवि डेटा से बचाता है, लेकिन प्रत्येक picture frame आमतौर पर अपना अलग [Picture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/) और छवि रूपांतरण संग्रह रखता है।

**क्या रंग, धुंधलापन, और अल्फा इफ़ेक्ट संयोजित किए जा सकते हैं?**

हाँ। संग्रह उन्हें एक क्रमबद्ध चेन में स्वीकार करता है। प्रत्येक ऑपरेशन के पिछले आउटपुट पर प्रभाव को समझें क्योंकि प्रतिस्थापन और थ्रेशोल्ड ऑपरेशन पहले के रंग या अल्फा विवरण को हटा सकते हैं।

**प्रभावी मान रीड‑ओनली क्यों होते हैं?**

प्रभावी डेटा वह गणना किए गए मान दर्शाता है जो रेंडरिंग के लिए उपयोग होते हैं, जिसमें समाधान किए गए रंग शामिल हैं। जहाँ लिखने योग्य सदस्य मौजूद हों, उस ऑपरेशन को संग्रह में संपादित करें; अन्यथा उसे हटाएँ और नई निर्माण पैरामीटर के साथ एक प्रतिस्थापन जोड़ें।

**कौन सा फ़ॉर्मेट उपयोग करूँ ताकि रूपांतरण चेन संरक्षित रहे?**

PPTX का उपयोग करें और फ़ाइल को पुनः खोलकर सत्यापित करें। लेगेसी PPT पूरी DrawingML इफ़ेक्ट मॉडल को प्रदर्शित नहीं कर सकता, और रेंडर किए गए निर्यात फ़ॉर्मेट केवल दृश्य रूप को संरक्षित करते हैं, न कि संपादन योग्य रूपांतरण ऑपरेशन।