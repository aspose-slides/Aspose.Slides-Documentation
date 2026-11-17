---
title: एंड्रॉइड पर प्रस्तुतियों में छवि रूपांतरण प्रभावों का प्रबंधन
linktitle: छवि रूपांतरण प्रभाव
type: docs
weight: 11
url: /hi/androidjava/image-transform-effects/
keywords:
- छवि रूपांतरण
- चित्र प्रभाव
- चमक
- विरोधाभास
- ग्रेस्केल
- डुओटोन
- टिंट
- HSL
- रंग प्रतिस्थापन
- ब्लर
- पारदर्शिता
- अल्फा प्रभाव
- प्रभाव श्रृंखला
- PowerPoint
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android के साथ जावा के माध्यम से चित्र फ्रेम के लिए छवि रूपांतरण प्रभावों को लागू करें, श्रृंखलाबद्ध करें, निरीक्षण करें, हटाएँ और सत्यापित करें।"
---
## **सारांश**

Aspose.Slides चित्र समायोजन को छवि रूपांतरण संचालन के क्रमबद्ध संग्रह के रूप में दर्शाता है। एक चित्र फ्रेम के लिए, फ्रेम के [ISlidesPicture](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidespicture/) से शुरू करें और [ISlidesPicture.getImageTransform](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidespicture/#getImageTransform--) तक पहुँचें। लौटाया गया [IImageTransformOperationCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/) आपको प्रभावों को जोड़ने, गिनने, निरीक्षण करने, हटाने और साफ़ करने की अनुमति देता है, बिना मूल छवि बाइट्स को फिर से लिखे।

यह लेख ब्राइटनेस और कॉन्ट्रास्ट, रंग रूपांतरण, ब्लर, ट्रांसपैरेंसी, क्रमबद्ध प्रभाव श्रृंखला, प्रभावी मान, हटाना, और PPTX राउंड‑ट्रिप सत्यापन के लिए एक पूर्ण कार्यप्रवाह प्रदर्शित करता है।

## **प्रभाव स्वामित्व और छवि पुन: उपयोग को समझें**

एक छवि संसाधन और उसे प्रदर्शित करने वाली तस्वीर अलग‑अलग वस्तुएँ हैं:

- [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ippimage/) प्रस्तुति द्वारा मालिकी वाली स्रोत छवि डेटा को संग्रहीत या संदर्भित करता है।
- [ISlidesPicture](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidespicture/) एक चित्र भराव से संबंधित है और एक छवि संसाधन को संदर्भित करता है जबकि छवि रूपांतरण संग्रह को संग्रहीत करता है।
- [IPictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframe/) वह स्लाइड आकार है जो संबंधित चित्र भराव, ज्यामिति, क्रॉप सेटिंग्स और अन्य फ्रेम‑स्तरीय स्वरूपण का स्वामी है।

इसलिए, छवि रूपांतरण संचालन [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ippimage/) में बाइट्स को संशोधित नहीं करते। जब समान `IPPImage` को [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) में एक से अधिक बार पास किया जाता है, तो प्रत्येक नया चित्र फ्रेम अपना स्वयं का `ISlidesPicture` और अपना स्वयं का रूपांतरण संग्रह प्राप्त करता है। एक फ्रेम पर ग्रेस्केल लागू करना अन्य फ्रेमों को ग्रेस्केल नहीं बनाता, भले ही सभी समान एम्बेडेड छवि संसाधन का पुनः उपयोग करें।

उसी `ISlidesPicture.getImageTransform` मॉडल का उपयोग अन्य चित्र भराव, जैसे आकार या स्लाइड पृष्ठभूमि, द्वारा भी किया जाता है। नीचे दिए गए उदाहरण चित्र फ्रेम पर केंद्रित हैं।

## **वैध पैरामीटर रेंज और इकाइयों का उपयोग करें**

प्रदर्शित विधियों के लिए निम्नलिखित अर्थपूर्ण रेंज और इकाइयाँ हैं। इन्हें इन रेंजों में रखें, भले ही कोई विशेष लाइब्रेरी संस्करण तुरंत सभी रेंज‑बाहरी मानों को अस्वीकार न करे; लक्ष्य प्रस्तुति स्वरूप सहेजते समय या PowerPoint फ़ाइल खोलते समय अमान्य डेटा को सामान्यीकृत, छोड़ या अस्वीकार कर सकता है।

| ऑपरेशन | पैरामीटर | मान्य सीमा और इकाई |
|---|---|---|
| [addBrightnessContrastEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBrightnessContrastEffect-float-float-) | `brightness`, `contrast` | `-100` से `100` तक, प्रतिशत; `0` घटक को अपरिवर्तित रखता है। |
| [addGrayScaleEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addGrayScaleEffect--) | कोई नहीं | कोई संख्यात्मक पैरामीटर नहीं। अल्फा अपरिवर्तित रहता है। |
| [addDuotoneEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addDuotoneEffect--) | `color1`, `color2` | गहरे और हल्के पिक्सेल के लिए दो रंग। `android.graphics.Color` द्वारा उपयोग किए जाने वाले RGB और अल्फा चैनल मान `0` से `255` तक होते हैं। |
| [addTintEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addTintEffect-float-float-) | `hue`, `amount` | ह्यू `0` (समावेशी) से `360` (असमावेशी) डिग्री तक; मात्रा `-100` से `100` तक, प्रतिशत। |
| [addHSLEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addHSLEffect-float-float-float-) | `hue`, `saturation`, `luminance` | ह्यू `0` से `360` तक, डिग्री; सैचुरेशन और ल्यूमिनेंस `-100` से `100` तक, प्रतिशत। |
| [addColorReplaceEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addColorReplaceEffect--) | `color` | प्रतिस्थापन रंग चैनल मान `0` से `255` तक। मौजूदा अल्फा मान अपरिवर्तित रहते हैं। |
| [addBlurEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBlurEffect-double-boolean-) | `radius`, `grow` | त्रिज्या गैर‑नकारात्मक है और पॉइंट्स में मापी जाती है; `grow` एक Boolean है जो निर्धारित करता है कि ब्लर की गई सामग्री मूल सीमा से बाहर फैल सकती है या नहीं। |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaModulateFixedEffect-float-) | `amount` | गैर‑नकारात्मक प्रतिशत। सामान्य अपारदर्शिता स्केलिंग के लिए `0` से `100` उपयोग करें: `0` पूरी तरह पारदर्शी और `100` मौजूदा अल्फा को बरकरार रखता है। |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaReplaceEffect-float-) | `alpha` | `0` से `100` तक, प्रतिशत अपारदर्शिता। |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) | `threshold` | `0` से `100` तक, प्रतिशत अल्फा थ्रेशोल्ड। इस मान से कम होने पर पारदर्शी, इस या उससे ऊपर होने पर अपारदर्शी हो जाता है। |

स्थिर अल्फा मॉड्यूलेशन के लिए, ट्रांसपैरेंसी और अपारदर्शिता परस्परपूरक हैं। उदाहरण के लिए, 35% ट्रांसपैरेंसी अल्फा मॉड्यूलेशन मात्रा 65% के बराबर है।

## **ब्राइटनेस और कॉन्ट्रास्ट लागू करें**

[IImageTransformOperationCollection.addBrightnessContrastEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBrightnessContrastEffect-float-float-) एक [IBrightnessContrast](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibrightnesscontrast/) संचालन लौटाता है। इसके स्केलर सेटिंग्स संचालन निर्मित होते समय प्रदान की जाती हैं। [BrightnessContrast.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/brightnesscontrast/#getEffective--) गणना किए गए केवल‑पढ़ने‑योग्य मान लौटाता है, जिसे निरीक्षण या लॉग किया जा सकता है।

निम्न उदाहरण ब्राइटनेस को 15% और कॉन्ट्रास्ट को 20% बढ़ाता है, फिर एम्बेडेड छवि को बदले बिना एक प्रीव्यू रेंडर करता है:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }
    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 400, 260, image);

    IImageTransformOperationCollection imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
    IBrightnessContrast brightnessContrast = imageTransform.addBrightnessContrastEffect(15f, 20f);

    IBrightnessContrastEffectiveData effectiveValues = brightnessContrast.getEffective();
    System.out.println("Brightness: " + effectiveValues.getBrightness() + "%");
    System.out.println("Contrast: " + effectiveValues.getContrast() + "%");

    IImage preview = slide.getImage();
    try {
        preview.save("brightness-contrast-preview.png", ImageFormat.Png);
    } finally {
        preview.dispose();
    }
} finally {
    presentation.dispose();
}
```

[BrightnessContrast](https://reference.aspose.com/slides/androidjava/com.aspose.slides/brightnesscontrast/) Office 2010 चित्र‑प्रभाव विस्तार है और मानक DrawingML ल्यूमिनेंस प्रभाव की तुलना में कम पोर्टेबल है। जब ब्राइटनेस और कॉन्ट्रास्ट को PPTX राउंड‑ट्रिप के बाद भी संपादन‑योग्य रखना हो, तो [IImageTransformOperationCollection.addLuminanceEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addLuminanceEffect-float-float-) का उपयोग करें और फ़ाइल को पुनः खोलने के बाद परिणाम सत्यापित करें। स्वरूप सीमाएँ इस अंतर को अधिक विवरण में समझाती हैं।

## **रंग रूपांतरण लागू करें**

रंग प्रभावों को स्वतंत्र रूप से विभिन्न चित्र फ्रेम पर लागू किया जा सकता है जो एक ही छवि संसाधन का पुनः उपयोग करते हैं। निम्न उदाहरण पाँच फ्रेम बनाता है और क्रमशः ग्रेस्केल, डुओटोन, टिंट, HSL समायोजन और रंग प्रतिस्थापन लागू करता है।

[IDuotone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iduotone/) दो स्वतंत्र रूप से संपादन‑योग्य रंग पैरामीटर रखता है: `color1` गहरे पिक्सेल को मैप करता है, जबकि `color2` हल्के पिक्सेल को। यह एक ऐसा उदाहरण है जहाँ प्रभाव का सेटिंग एकल स्केलर मान से अधिक जटिल होता है।

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    IPictureFrame grayFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 180, 120, image);
    grayFrame.getPictureFormat().getPicture().getImageTransform().addGrayScaleEffect();

    IPictureFrame duotoneFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 220, 20, 180, 120, image);
    IDuotone duotone = duotoneFrame.getPictureFormat().getPicture().getImageTransform().addDuotoneEffect();
    duotone.getColor1().setColor(Color.rgb(0, 0, 128));
    duotone.getColor2().setColor(Color.rgb(255, 215, 0));

    IPictureFrame tintFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 420, 20, 180, 120, image);
    tintFrame.getPictureFormat().getPicture().getImageTransform().addTintEffect(210f, 35f);

    IPictureFrame hslFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 120, 170, 180, 120, image);
    hslFrame.getPictureFormat().getPicture().getImageTransform().addHSLEffect(30f, 20f, -10f);

    IPictureFrame replacementFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 320, 170, 180, 120, image);
    IColorReplace colorReplacement = replacementFrame.getPictureFormat().getPicture().getImageTransform().addColorReplaceEffect();
    colorReplacement.getColor().setColor(Color.rgb(100, 149, 237));

    presentation.save("color-transformations.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[addColorReplaceEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addColorReplaceEffect--) प्रत्येक पिक्सेल के रंग को एक निश्चित रंग से बदलता है, जबकि अल्फा को संरक्षित रखता है। यह [addColorChangeEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addColorChangeEffect--) से अलग है, जो एक स्रोत रंग को दूसरे में मैप करता है और दोनों स्रोत व लक्ष्य रंग स्वरूप उजागर करता है।

### **ल्यूमिनेंस थ्रेशोल्ड लागू करें**

ल्यूमिनेंस थ्रेशोल्ड स्कैन की गई पृष्ठ पर धुंधले निशानों को पृष्ठभूमि से अलग करना आसान बनाता है। [addGrayScaleEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addGrayScaleEffect--) मध्यवर्ती ग्रे शेड को बरकरार रखता है। [addBiLevelEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBiLevelEffect-float-) ल्यूमिनेंस को काला या सफेद में परिवर्तित करता है, जबकि [addAlphaBiLevelEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) अपारदर्शिता पर थ्रेशोल्ड लगाता है।

ल्यूमिनेंस थ्रेशोल्ड 0% से 100% (समावेशी) तक रहता है। थ्रेशोल्ड से नीचे के पिक्सेल काले हो जाते हैं। थ्रेशोल्ड के बराबर या उससे ऊपर के पिक्सेल सफ़ेद हो जाते हैं। थ्रेशोल्ड बढ़ाने से अधिक शेड काले हो जाते हैं क्योंकि अधिक पिक्सेल कटऑफ़ से नीचे गिरते हैं।

[grayscale-swatches.png](grayscale-swatches.png) को कार्य निर्देशिका में डाउनलोड करें। प्रत्येक लेबल मूल ग्रे स्तर को 0‑255 के स्केल पर दर्शाता है। उदाहरण मूल को दो प्रतियों के बगल में रखता है और प्रत्येक प्रतिलिपि का थ्रेशोल्ड प्रस्तुति में सहेजता है।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(720, 150, SlideSizeScaleType.DoNotScale);
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    IPPImage image;
    IImage sourceImage = Images.fromFile("grayscale-swatches.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    String[] captions = { "Original", "Threshold 20%", "Threshold 60%" };
    IPictureFrame[] frames = new IPictureFrame[captions.length];
    for (int i = 0; i < captions.length; i++) {
        float x = 12 + 240 * i;
        IAutoShape label = shapes.addAutoShape(ShapeType.Rectangle, x, 12, 216, 36);
        label.getTextFrame().setText(captions[i]);
        frames[i] = shapes.addPictureFrame(ShapeType.Rectangle, x, 60, 216, 72, image);
    }

    frames[1].getPictureFormat().getPicture().getImageTransform().addBiLevelEffect(20f);
    frames[2].getPictureFormat().getPicture().getImageTransform().addBiLevelEffect(60f);

    presentation.save("luminance-threshold.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

आउटपुट प्रस्तुति को PowerPoint में खोलें और तीन फ्रेम की तुलना करें। लेबल 96 वाली स्वैच लगभग 38% ल्यूमिनेंस (96 में 255) रखती है। यह 20% थ्रेशोल्ड पर सफ़ेद और 60% थ्रेशोल्ड पर काली हो जाती है।

![Original grayscale swatches beside the black-and-white results at luminance thresholds of 20% and 60%](luminance-threshold.png)

## **ब्लर, ट्रांसपैरेंसी और अल्फा प्रभाव जोड़ें**

[addBlurEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBlurEffect-double-boolean-) सभी रंग चैनलों, अल्फा सहित, को प्रभावित करता है। जब ब्लर की गई सीमा मूल चित्र सीमा से बाहर जा सकती है, तो `grow` को `true` सेट करें।

समान ट्रांसपैरेंसी के लिए, [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaModulateFixedEffect-float-) का उपयोग करें। यह प्रत्येक मौजूदा अल्फा मान को गुणा करता है, इसलिए आंशिक‑पारदर्शी पिक्सेल अनुपातिक रूप से भिन्न रहते हैं। [addAlphaReplaceEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaReplaceEffect-float-) सभी पिक्सेल को एक ही अल्फा मान देता है। [addAlphaBiLevelEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) थ्रेशोल्ड के आधार पर अल्फा को दो स्तरों में बदलता है।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    IPictureFrame blurredFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 200, 140, image);
    IBlur blur = blurredFrame.getPictureFormat().getPicture().getImageTransform().addBlurEffect(4.5, true);
    blur.setRadius(5);

    IPictureFrame transparentFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 240, 20, 200, 140, image);
    IAlphaModulateFixed alphaModulate = transparentFrame.getPictureFormat().getPicture().getImageTransform().addAlphaModulateFixedEffect(65f);
    alphaModulate.setAmount(60f);

    IPictureFrame uniformAlphaFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 180, 200, 140, image);
    uniformAlphaFrame.getPictureFormat().getPicture().getImageTransform().addAlphaReplaceEffect(55f);

    IPictureFrame binaryAlphaFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 240, 180, 200, 140, image);
    IAlphaBiLevel alphaBiLevel = binaryAlphaFrame.getPictureFormat().getPicture().getImageTransform().addAlphaBiLevelEffect(50f);
    alphaBiLevel.setThreshold(45f);
    binaryAlphaFrame.getPictureFormat().getPicture().getImageTransform().addAlphaInverseEffect();

    presentation.save("blur-and-alpha-effects.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

अन्य पैरामीटर‑रहित अल्फा संचालन में [addAlphaCeilingEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaCeilingEffect--) शामिल है, जो प्रत्येक गैर‑शून्य अल्फा को पूरी तरह अपारदर्शी बनाता है; [addAlphaFloorEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaFloorEffect--) जो 100% से कम सभी अल्फा को पूरी तरह पारदर्शी बनाता है; तथा [addAlphaInverseEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaInverseEffect--) जो अल्फा को `100% - alpha` में बदलता है।

## **क्रमबद्ध प्रभाव श्रृंखला बनाएं**

प्रत्येक `add...Effect` विधि संग्रह के अंत में नया संचालन जोड़ती है। रेंडरर संग्रह को क्रमबद्ध पाइपलाइन के रूप में उपयोग करता है: संचालन 0 का आउटपुट संचालन 1 का इनपुट बन जाता है, आदि। परिणामस्वरूप समान संचालन को अलग क्रम में लागू करने से अलग छवि प्राप्त हो सकती है।

उदाहरण के लिए, ग्रेस्केल के बाद टिंट लागू करने से पहले रंगीय जानकारी हट जाती है और फिर ल्यूमिनेंस को पुनः रंगीन किया जाता है। टिंट के बाद ग्रेस्केल लागू करने से टिंट फिर से हट जाता है। इसी प्रकार, अल्फा प्रतिस्थापन पहले के संचालन द्वारा गणना किए गए अल्फा मानों को अधिलेखित कर सकता है, जबकि अल्फा मॉड्यूलेशन उनके आपसी अंतर को बरकरार रखता है।

निम्न उदाहरण चार‑संचालन श्रृंखला बनाता है, उसे PPTX के रूप में सहेजता है, प्रस्तुति को पुनः खोलता है, संचालन प्रकार और उनका क्रम जाँचता है, और पुनः खोले गए परिणाम को रेंडर करता है:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }
    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 400, 260, image);

    IImageTransformOperationCollection imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
    imageTransform.addGrayScaleEffect();
    imageTransform.addTintEffect(220f, 25f);
    imageTransform.addBlurEffect(2.5, false);
    imageTransform.addAlphaModulateFixedEffect(80f);

    presentation.save("image-transform-chain.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

Presentation reopenedPresentation = new Presentation("image-transform-chain.pptx");
try {
    IShape reopenedShape = reopenedPresentation.getSlides().get_Item(0).getShapes().get_Item(0);

    if (reopenedShape instanceof IPictureFrame) {
        IPictureFrame reopenedFrame = (IPictureFrame) reopenedShape;
        IImageTransformOperationCollection reopenedTransform = reopenedFrame.getPictureFormat().getPicture().getImageTransform();
        boolean orderIsPreserved = reopenedTransform.size() == 4 && 
                reopenedTransform.get_Item(0) instanceof IGrayScale && 
                reopenedTransform.get_Item(1) instanceof ITint && 
                reopenedTransform.get_Item(2) instanceof IBlur && 
                reopenedTransform.get_Item(3) instanceof IAlphaModulateFixed;
        System.out.println(orderIsPreserved ? "The effect chain was preserved." : "The effect chain changed during the round trip.");

        IImage renderedSlide = reopenedPresentation.getSlides().get_Item(0).getImage();
        try {
            renderedSlide.save("reopened-effect-chain.png", ImageFormat.Png);
        } finally {
            renderedSlide.dispose();
        }
    } else {
        System.out.println("The reopened shape is not a picture frame.");
    }
} finally {
    reopenedPresentation.dispose();
}
```

संग्रह कोई संगतता मैट्रिक्स निर्धारित नहीं करता जो रंग, अल्फा और ब्लर संचालन को अलग‑अलग श्रृंखलाओं तक सीमित करता हो। उन्हें मिलाया जा सकता है, लेकिन सभी संयोजन हमेशा उपयोगी नहीं होते। स्थिर रंग प्रतिस्थापन पहले के रंग प्रभावों द्वारा उत्पन्न RGB वैरिएशन को हटा देता है; डुओटोन के बाद ग्रेस्केल दो चयनित रंगों को हटा देता है; और अल्फा सीलिंग, फ़्लोर, प्रतिस्थापन या बि‑लेवल संचालन पहले बनाए गए अल्फा विवरण को हटा सकते हैं। इच्छित पिक्सेल‑प्रोसेसिंग क्रम के अनुसार श्रृंखला बनाएँ, न कि इसे अनक्रमित स्वरूप फ़्लैग मानें।

<!-- visual-explanation:image-transform-effects:start -->
[![The same image passes through grayscale then tint, and tint then grayscale. The two final grayscale images have different tones.](visual-image-transform-effects-49aa72211f3a.svg)](visual-image-transform-effects-49aa72211f3a.svg)

*In this illustrative Aspose.Slides for .NET 26.11 render, a 220° tint at 25% leaves the grayscale image unchanged. Applying the same tint before grayscale produces different tones.*
<!-- visual-explanation:image-transform-effects:end -->

## **संपादन‑योग्य और प्रभावी मान निरीक्षण करें**

एक संपादन‑योग्य संचालन वह वस्तु है जो `ISlidesPicture.getImageTransform` में संग्रहीत है। प्रभाव के अनुसार, यह सीधे लिखने‑योग्य सदस्य उजागर कर सकता है। उदाहरण के लिए, [IBlur](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iblur/) लिखने‑योग्य `radius` और `grow` मान उजागर करता है, [IAlphaModulateFixed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ialphamodulatefixed/) लिखने‑योग्य `amount` उजागर करता है, और [IAlphaBiLevel](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ialphabilevel/) लिखने‑योग्य `threshold` उजागर करता है। [IDuotone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iduotone/) जैसे रंग प्रभाव mutable [IColorFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolorformat/) वस्तुएँ उजागर करते हैं।

कुछ संचालन इंटरफ़ेस, जिनमें [IBrightnessContrast](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibrightnesscontrast/), [IHSL](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihsl/), [ITint](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itint/), और [IAlphaReplace](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ialphareplace/) शामिल हैं, अपनी निर्माण स्केलर को लिखने‑योग्य गुणों के रूप में उजागर नहीं करते। इन सेटिंग्स को बदलने के लिए, संचालन को हटाएँ और आवश्यक स्थान पर एक प्रतिस्थापन जोड़ें।

`getEffective()` द्वारा लौटाए गए प्रभावी डेटा की गणना की गई और केवल‑पढ़ने‑योग्य होती है। यह थीम‑निर्भर रंगों को हल करने और रेंडरर द्वारा उपयोग किए गए सामान्यीकृत मानों को पढ़ने में उपयोगी है, लेकिन यह कोई नया संपादन सतह नहीं है। निम्न उदाहरण श्रृंखला को गिनती करता है और जहाँ लागू हो प्रभावी मानों का निरीक्षण करता है:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("image-transform-chain.pptx");
try {
    IPictureFrame pictureFrame = null;

    for (IShape shape : presentation.getSlides().get_Item(0).getShapes()) {
        if (shape instanceof IPictureFrame) {
            pictureFrame = (IPictureFrame) shape;
            break;
        }
    }

    if (pictureFrame != null) {
        IImageTransformOperationCollection imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();

        for (int index = 0; index < imageTransform.size(); index++) {
            IImageTransformOperation operation = imageTransform.get_Item(index);
            System.out.println(index + ": " + operation.getClass().getSimpleName());

            if (operation instanceof IBrightnessContrast) {
                IBrightnessContrastEffectiveData data = ((IBrightnessContrast) operation).getEffective();
                System.out.println("  Brightness: " + data.getBrightness());
                System.out.println("  Contrast: " + data.getContrast());
            } else if (operation instanceof ILuminance) {
                ILuminanceEffectiveData data = ((ILuminance) operation).getEffective();
                System.out.println("  Brightness: " + data.getBrightness());
                System.out.println("  Contrast: " + data.getContrast());
            } else if (operation instanceof IDuotone) {
                IDuotoneEffectiveData data = ((IDuotone) operation).getEffective();
                System.out.println("  Dark color: " + data.getColor1());
                System.out.println("  Light color: " + data.getColor2());
            } else if (operation instanceof IColorReplace) {
                IColorReplaceEffectiveData data = ((IColorReplace) operation).getEffective();
                System.out.println("  Replacement color: " + data.getColor());
            } else if (operation instanceof IHSL) {
                IHSLEffectiveData data = ((IHSL) operation).getEffective();
                System.out.println("  HSL: " + data.getHue() + ", " + data.getSaturation() + ", " + data.getLuminance());
            } else if (operation instanceof ITint) {
                ITintEffectiveData data = ((ITint) operation).getEffective();
                System.out.println("  Tint: " + data.getHue() + ", " + data.getAmount());
            } else if (operation instanceof IBlur) {
                IBlurEffectiveData data = ((IBlur) operation).getEffective();
                System.out.println("  Blur radius: " + data.getRadius() + " pt");
            } else if (operation instanceof IAlphaModulateFixed) {
                IAlphaModulateFixedEffectiveData data = ((IAlphaModulateFixed) operation).getEffective();
                System.out.println("  Alpha amount: " + data.getAmount() + "%");
            } else if (operation instanceof IAlphaReplace) {
                IAlphaReplaceEffectiveData data = ((IAlphaReplace) operation).getEffective();
                System.out.println("  Replacement alpha: " + data.getAlpha() + "%");
            } else if (operation instanceof IAlphaBiLevel) {
                IAlphaBiLevelEffectiveData data = ((IAlphaBiLevel) operation).getEffective();
                System.out.println("  Alpha threshold: " + data.getThreshold() + "%");
            }
        }
    }
} finally {
    presentation.dispose();
}
```

`grayscale`, `alpha ceiling`, `alpha inverse` जैसी पैरामीटर‑रहित प्रभावों का भी एक प्रभावी‑डेटा वस्तु होती है, लेकिन प्रिंट करने के लिए कोई स्केलर सेटिंग नहीं होती। उनका संग्रह में उपस्थित होना और स्थान ही महत्वपूर्ण जानकारी है।

## **छवि रूपांतरण हटाएँ या साफ़ करें**

एक संचालन को इंडेक्स द्वारा हटाने के लिए [IImageTransformOperationCollection.removeAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#removeAt-int-) का उपयोग करें। चूँकि हटाने के बाद सूचकांक शिफ्ट होते हैं, पहले लक्ष्य को खोजें और गिनती के बाद उसे हटाएँ। पूरी श्रृंखला को हटाने के लिए [ImageTransformOperationCollection.clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imagetransformoperationcollection/#clear--) का उपयोग करें।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("image-transform-chain.pptx");
try {
    IPictureFrame pictureFrame = null;

    for (IShape shape : presentation.getSlides().get_Item(0).getShapes()) {
        if (shape instanceof IPictureFrame) {
            pictureFrame = (IPictureFrame) shape;
            break;
        }
    }

    if (pictureFrame != null) {
        IImageTransformOperationCollection imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
        int blurIndex = -1;

        for (int index = 0; index < imageTransform.size(); index++) {
            if (imageTransform.get_Item(index) instanceof IBlur) {
                blurIndex = index;
                break;
            }
        }

        if (blurIndex >= 0) {
            imageTransform.removeAt(blurIndex);
            System.out.println("The blur operation was removed.");
        }

        imageTransform.clear();
        System.out.println("Remaining operations: " + imageTransform.size());
        presentation.save("image-transforms-cleared.pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

रूपांतरणों को हटाने या साफ़ करने से केवल चित्र स्वरूपण बदलता है। यह पुनः‑प्रयोग किए गए [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ippimage/) संसाधन को हटाता, पुनः‑संपीड़ित या अन्यथा परिवर्तित नहीं करता।

## **प्रेजेंटेशन स्वरूप और निर्यात लक्ष्यों पर विचार करें**

छवि रूपांतरण DrawingML में उत्पन्न होते हैं, इसलिए PPTX प्रभाव श्रृंखलाओं के लिए प्राथमिक संपादन‑योग्य स्वरूप है। PPTX के साथ भी, प्रत्येक संचालन की पोर्टेबिलिटी समान नहीं होती:

- मानक DrawingML संचालन जैसे ल्यूमिनेंस, ग्रेस्केल, डुओटोन, टिंट, HSL, ब्लर और सामान्य अल्फा संचालन का PPTX राउंड‑ट्रिप में जीवित रहने की सबसे अधिक संभावना होती है। जब संरक्षण आवश्यक हो तो उत्पन्न फ़ाइल को हमेशा पुनः खोलें और संग्रह का निरीक्षण करें।
- [BrightnessContrast](https://reference.aspose.com/slides/androidjava/com.aspose.slides/brightnesscontrast/) Office 2010 विस्तार है, न कि मानक DrawingML ल्यूमिनेंस संचालन। इसे इन‑मेमोरी रेंडरिंग के लिए उपयोग किया जा सकता है, लेकिन PPTX को सहेजने और पुनः खोलने के बाद यह संपादन‑योग्य [IBrightnessContrast](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibrightnesscontrast/) के रूप में बना रहेगा, यह गारंटी नहीं है। स्थायी ब्राइटनेस और कॉन्ट्रास्ट समायोजन के लिए [addLuminanceEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addLuminanceEffect-float-float-) को प्राथमिकता दें।
- बाइनरी PPT स्वरूप पूर्ण DrawingML प्रभाव मॉडल से पूर्व है। PPT में सहेजने पर असमर्थित संचालन छोड़े जा सकते हैं, श्रृंखला को समर्थित उपसमुच्चय तक घटाया जा सकता है, या स्वरूप को अनुमानित किया जा सकता है। जटिल संपादन‑योग्य श्रृंखला के लिए PPT को सत्यापन स्वरूप के रूप में न उपयोग करें।
- PNG, JPEG, TIFF, PDF, SVG, HTML या अन्य दृश्य आउटपुट पर रेंडरिंग समर्थित श्रृंखला को रेंडरिंग रूप में लागू करती है। इन आउटपुट में संपादन‑योग्य `IImageTransformOperationCollection` नहीं होता; रास्टर स्वरूप परिणाम को पिक्सेल में फ्लैट कर देते हैं, और दस्तावेज़/वेक्टर निर्यात अपनी स्वयं की रेंडरिंग प्रतिनिधित्व संग्रहित करते हैं।
- प्रभाव लिंक्ड छवि को स्व-समावेशी नहीं बनाते। लिंक्ड चित्र को रेंडर करना तब भी लिंक्ड संसाधन की उपलब्धता पर निर्भर करता है जब प्रस्तुति लोड की जाती है।

विभिन्न प्रस्तुति उपभोक्ताओं के पास किनारे‑केस की रेंडरिंग में अंतर हो सकता है, विशेष रूप से जब कई अल्फा या रंग‑क्वांटाइज़िंग संचालन संयोजित हों। महत्वपूर्ण आउटपुट के लिए, संपादन‑योग्य राउंड‑ट्रिप और अंतिम निर्यात स्वरूप दोनों का परीक्षण करें, वही Aspose.Slides संस्करण उपयोग करते हुए जो उत्पादन में उपयोग हो रहा है।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या छवि रूपांतरण प्रभाव एम्बेडेड छवि डेटा को संशोधित करते हैं?**

नहीं। ये संचालन चित्र भराव द्वारा उपयोग किए जाने वाले `ISlidesPicture` से संबंधित हैं। अंतर्निहित `IPPImage` बाइट्स अपरिवर्तित रहती हैं।

**क्या दो चित्र फ्रेम जो समान छवि का पुनः उपयोग करते हैं, उनके प्रभाव साझा होते हैं?**

नहीं। `IPPImage` को पुनः उपयोग करने से दुहराव वाली छवि डेटा बचती है, लेकिन प्रत्येक चित्र फ्रेम आमतौर पर अलग‑अलग `ISlidesPicture` तथा छवि रूपांतरण संग्रह रखता है।

**क्या रंग, ब्लर और अल्फा प्रभावों को मिलाया जा सकता है?**

हां। संग्रह उन्हें एक क्रमबद्ध श्रृंखला में स्वीकार करता है। प्रत्येक संचालन का पिछले संचालन के आउटपुट पर क्या प्रभाव पड़ता है, इसे ध्यान में रखें, क्योंकि प्रतिस्थापन और थ्रेशोल्ड संचालन पहले के रंग या अल्फा विवरण को हटा सकते हैं।

**प्रभावी मान केवल‑पढ़ने‑योग्य क्यों होते हैं?**

प्रभावी डेटा वह गणना किया गया मान है जो रेंडरिंग में उपयोग होता है, जिसमें हल किए गए रंग शामिल होते हैं। जहाँ लिखने‑योग्य सदस्य मौजूद हों, वहाँ संग्रह में संग्रहीत संचालन को संपादित करें; अन्यथा उसे हटाएँ और नई निर्माण पैरामीटर के साथ प्रतिस्थापन जोड़ें।

**कौन‑सा स्वरूप मैं रूपांतरण श्रृंखला को सुरक्षित रखने के लिए उपयोग करूं?**

PPTX का उपयोग करें और फ़ाइल को पुनः खोलकर सत्यापित करें। पुराना PPT पूर्ण DrawingML प्रभाव मॉडल को नहीं दर्शा सकता, और रेंडर किए गए निर्यात स्वरूप केवल रूप दिखाते हैं, न कि संपादन‑योग्य रूपांतरण संचालन।