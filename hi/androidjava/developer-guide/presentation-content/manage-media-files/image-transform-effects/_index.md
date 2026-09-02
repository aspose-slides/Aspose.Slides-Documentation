---
title: Android पर प्रस्तुतियों में छवि रूपांतरण प्रभावों का प्रबंधन
linktitle: छवि रूपांतरण प्रभाव
type: docs
weight: 11
url: /hi/androidjava/image-transform-effects/
keywords:
- छवि रूपांतरण
- चित्र प्रभाव
- प्रकाशता
- कंट्रास्ट
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
description: "Aspose.Slides for Android के साथ Java द्वारा चित्र फ्रेम के लिए छवि रूपांतरण प्रभावों को लागू करें, श्रृंखलाबद्ध करें, निरीक्षण करें, हटाएँ और सत्यापित करें।"
---
## **अवलोकन**

Aspose.Slides चित्र समायोजन को चित्र रूपांतरण कार्यों के क्रमबद्ध संग्रह के रूप में दर्शाता है। एक चित्र फ्रेम के लिए, फ्रेम के [ISlidesPicture](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/islidespicture/) से शुरू करें और [ISlidesPicture.getImageTransform](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/islidespicture/#getImageTransform--) तक पहुंचें। लौटाया गया [IImageTransformOperationCollection](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iimagetransformoperationcollection/) आपको प्रभावों को जोड़ने, क्रमबद्ध करने, निरीक्षण करने, हटाने और साफ़ करने की अनुमति देता है, बिना मूल छवि बाइट्स को फिर से लिखे।

यह लेख प्रकाशता और कंट्रास्ट, रंग रूपांतरण, ब्लर, पारदर्शिता, क्रमबद्ध प्रभाव श्रृंखलाओं, प्रभावी मान, हटाने, और PPTX राउंड‑ट्रिप सत्यापन के लिए पूर्ण कार्यप्रवाह दर्शाता है।

## **प्रभाव स्वामित्व और चित्र पुन: उपयोग को समझें**

एक चित्र संसाधन और उसे प्रदर्शित करने वाला चित्र अलग-अलग वस्तुएँ हैं:

- [IPPImage](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ippimage/) प्रस्तुति द्वारा स्वामित स्रोत चित्र डेटा को संग्रहीत या संदर्भित करता है।
- [ISlidesPicture](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/islidespicture/) एक चित्र फ़िल का हिस्सा है और चित्र संसाधन को संदर्भित करते हुए चित्र रूपांतरण संग्रह को संग्रहीत करता है।
- [IPictureFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipictureframe/) वह स्लाइड आकार है जो संबंधित चित्र फ़िल, ज्यामिति, क्रॉप सेटिंग्स, और अन्य फ्रेम‑स्तरीय स्वरूपण का स्वामित्व रखता है।

इसलिए, चित्र रूपांतरण कार्य मूल [IPPImage](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ippimage/) की बाइट्स को संशोधित नहीं करते। जब एक ही `IPPImage` को [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) को एक से अधिक बार पास किया जाता है, तब प्रत्येक नई चित्र फ्रेम को अपना अलग `ISlidesPicture` और अपनी अलग रूपांतरण संग्रह मिलती है। एक फ्रेम पर ग्रेस्केल लागू करने से अन्य फ्रेम ग्रेस्केल नहीं होते, भले ही सभी समान एम्बेडेड चित्र संसाधन का पुन: उपयोग करें।

एक ही `ISlidesPicture.getImageTransform` मॉडल का उपयोग अन्य चित्र फ़िल्स, जैसे आकार या स्लाइड पृष्ठभूमि, द्वारा भी किया जाता है। नीचे दिए गए उदाहरण मुख्यतः चित्र फ्रेम पर केंद्रित हैं।

## **वैध पैरामीटर रेंज और इकाइयों का उपयोग करें**

प्रदर्शित विधियों में निम्नलिखित अर्थपूर्ण रेंज और इकाइयाँ उपयोग की गई हैं। इन रेंजों में मान रखें, भले ही किसी विशेष लाइब्रेरी संस्करण में तुरंत सभी आउट‑ऑफ़‑रेन्ज मानों को अस्वीकार न किया जाए; लक्ष्य प्रस्तुति स्वरूप सहेजने या PowerPoint फ़ाइल खोलने पर डेटा को सामान्यीकृत, छोड़ या अस्वीकार कर सकता है।

| ऑपरेशन | पैरामीटर | वैध रेंज और इकाई |
|---|---|---|
| [addBrightnessContrastEffect](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBrightnessContrastEffect-float-float-) | `brightness`, `contrast` | `-100` से `100` तक, प्रतिशत; `0` घटक को अपरिवर्तित छोड़ता है। |
| [addGrayScaleEffect](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addGrayScaleEffect--) | कोई नहीं | कोई संख्यात्मक पैरामीटर नहीं। अल्फा अपरिवर्तित रहता है। |
| [addDuotoneEffect](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addDuotoneEffect--) | `color1`, `color2` | गहरे और हलके पिक्सेल के लिए दो रंग। `android.graphics.Color` द्वारा प्रयुक्त RGB और अल्फा चैनल मान `0` से `255` तक होते हैं। |
| [addTintEffect](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addTintEffect-float-float-) | `hue`, `amount` | hue `0` (समावेशी) से `360` (अपवर्जन) डिग्री तक; amount `-100` से `100` प्रतिशत। |
| [addHSLEffect](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addHSLEffect-float-float-float-) | `hue`, `saturation`, `luminance` | hue `0` (समावेशी) से `360` (अपवर्जन) डिग्री तक; saturation और luminance `-100` से `100` प्रतिशत। |
| [addColorReplaceEffect](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addColorReplaceEffect--) | `color` | प्रतिस्थापन रंग के चैनल मान `0` से `255` तक। मौजूदा अल्फा मान अपरिवर्तित रहता है। |
| [addBlurEffect](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBlurEffect-double-boolean-) | `radius`, `grow` | radius अपरन्यात्मक है और पॉइंट्स में मापा जाता है; `grow` एक Boolean है जो नियंत्रित करता है कि धुंधला सामग्री मूल सीमा से बाहर जा सकती है या नहीं। |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaModulateFixedEffect-float-) | `amount` | अपरन्यात्मक प्रतिशत। सामान्य अपारदर्शिता स्केलिंग के लिए `0` से `100` उपयोग करें: `0` पूरी तरह पारदर्शी और `100` मौजूदा अल्फा को बरकरार रखता है। |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaReplaceEffect-float-) | `alpha` | `0` से `100` प्रतिशत अपारदर्शिता। |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) | `threshold` | `0` से `100` प्रतिशत अल्फा थ्रेशोल्ड। इस मान से कम को पारदर्शी, बराबर या अधिक को अपारदर्शी माना जाता है। |

स्थिर अल्फा मॉडुलेशन के लिए, पारदर्शिता और अपारदर्शिता परस्परपूरक हैं। उदाहरण के लिए, 35 % पारदर्शिता अल्फा मॉडुलेशन मान 65 % के बराबर है।

## **प्रकाशता और कंट्रास्ट लागू करें**

[IImageTransformOperationCollection.addBrightnessContrastEffect](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBrightnessContrastEffect-float-float-) एक [IBrightnessContrast](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ibrightnesscontrast/) ऑपरेशन लौटाता है। इसके स्केलर सेटिंग्स ऑपरेशन बनाते समय प्रदान की जाती हैं। [IBrightnessContrast.getEffective](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ibrightnesscontrast/#getEffective--) गणना किए गए केवल‑पढ़ने‑योग्य मान लौटाता है जिन्हें निरीक्षण या लॉग किया जा सकता है।

निम्न उदाहरण प्रकाशता को 15 % और कंट्रास्ट को 20 % बढ़ाता है, फिर एम्बेडेड छवि को बदले बिना एक पूर्वावलोकन रेंडर करता है:

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

[BrightnessContrast](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/brightnesscontrast/) Office 2010 चित्र‑प्रभाव विस्तार है और मानक DrawingML ल्यूमिनेंस प्रभाव की तुलना में कम पोर्टेबल है। जब प्रकाशता और कंट्रास्ट को PPTX राउंड‑ट्रिप के बाद भी संपादन‑योग्य रखना हो, तो [IImageTransformOperationCollection.addLuminanceEffect](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addLuminanceEffect-float-float-) का उपयोग करें और फ़ाइल फिर से खोलने के बाद परिणाम सत्यापित करें। स्वरूप प्रतिबंध भाग इस अंतर को अधिक विस्तार से बताता है।

## **रंग रूपांतरण लागू करें**

रंग प्रभावों को स्वतंत्र रूप से विभिन्न चित्र फ्रेम पर लागू किया जा सकता है जो एक ही चित्र संसाधन का पुन: उपयोग करते हैं। निम्न उदाहरण पाँच फ्रेम बनाता है और क्रमशः ग्रेस्केल, डुओटोन्स, टिंट, HSL समायोजन, और रंग प्रतिस्थापन लागू करता है।

[IDuotone](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iduotone/) दो स्वतंत्र रूप से संपादन‑योग्य रंग पैरामीटर रखता है: `color1` गहरे पिक्सेल को मानचित्रित करता है, जबकि `color2` हलके पिक्सेल को। इससे यह एक ऐसा प्रभाव बनता है जिसकी सेटिंग एकल स्केलर मान से अधिक जटिल होती है।

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

[addColorReplaceEffect](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addColorReplaceEffect--) हर पिक्सेल का रंग एक स्थिर रंग से बदलता है जबकि अल्फा बरकरार रखता है। यह [addColorChangeEffect](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addColorChangeEffect--) से अलग है, जो एक स्रोत रंग को दूसरे में मैप करता है और स्रोत तथा लक्ष्य दोनों रंग स्वरूपों को उजागर करता है।

## **ब्लर, पारदर्शिता और अल्फा प्रभाव जोड़ें**

[addBlurEffect](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBlurEffect-double-boolean-) सभी रंग चैनलों, अल्फा सहित, को प्रभावित करता है। जब धुंधले किनारे मूल चित्र सीमा से बाहर तक विस्तारित हो सकते हैं, तो `grow` को `true` सेट करें।

समरूप पारदर्शिता के लिए, [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaModulateFixedEffect-float-) का उपयोग करें। यह प्रत्येक मौजूदा अल्फा मान को गुणा करता है, इसलिए भागीय‑पारदर्शी पिक्सेल अनुपातिक रूप से भिन्न रहते हैं। [addAlphaReplaceEffect](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaReplaceEffect-float-) सभी पिक्सेल को एक ही अल्फा मान असाइन करता है। [addAlphaBiLevelEffect](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) थ्रेशोल्ड के आधार पर अल्फा को दो स्तरों में बदलता है।

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

अन्य पैरामीटर‑मुक्त अल्फा ऑपरेशन्स में [addAlphaCeilingEffect](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaCeilingEffect--) शामिल है, जो प्रत्येक शून्य‑नहीं अल्फा को पूरी तरह अपारदर्शी बनाता है; [addAlphaFloorEffect](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaFloorEffect--) जो 100 % से कम प्रत्येक अल्फा को पूरी तरह पारदर्शी बनाता है; तथा [addAlphaInverseEffect](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaInverseEffect--) जो अल्फा को `100% - alpha` में बदलता है।

## **क्रमबद्ध प्रभाव श्रृंखला बनाएं**

प्रत्येक `add...Effect` विधि संग्रह के अंत में एक नया ऑपरेशन जोड़ती है। रेंडरर संग्रह को एक क्रमबद्ध पाइपलाइन के रूप में उपयोग करता है: ऑपरेशन 0 का आउटपुट ऑपरेशन 1 का इनपुट बन जाता है, आदि। इसलिए, समान ऑपरेशन्स को अलग क्रम में रखने पर अलग छवि प्राप्त हो सकती है।

उदाहरण के लिए, ग्रेस्केल के बाद टिंट लागू करने से पहले रंगीय जानकारी हट जाती है और फिर ल्यूमिनेंस पर फिर से रंग लगाया जाता है। टिंट के बाद ग्रेस्केल लागू करने से टिंट फिर से हट जाता है। इसी प्रकार, अल्फा प्रतिस्थापन पहले के ऑपरेशन्स द्वारा गणना किए गए अल्फा मानों को अधिलेखित कर सकता है, जबकि अल्फा मॉडुलेशन उनके सापेक्ष अंतर को बरकरार रखता है।

निम्न उदाहरण चार‑ऑपरेशन की श्रृंखला बनाता है, इसे PPTX के रूप में सहेजता है, प्रस्तुति को पुनः खोलता है, दोनों ऑपरेशन प्रकार और उनका क्रम जाँचता है, तथा पुनः खुले परिणाम को रेंडर करता है:

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

संग्रह कोई ऐसी संगतता मैट्रिक्स नहीं थोपता जो रंग, अल्फा और ब्लर ऑपरेशन्स को अलग‑अलग श्रृंखलाओं में बाँधे। इन्हें मिलाया जा सकता है, लेकिन संयोजन हमेशा उपयोगी नहीं होते। एक स्थिर रंग प्रतिस्थापन पूर्ववर्ती रंग प्रभावों द्वारा उत्पन्न RGB विविधता को हटा देता है; डुओतोन्स के बाद ग्रेस्केल दो चयनित रंगों को हटा देता है; और अल्फा सीलिंग, फ़्लोर, प्रतिस्थापन या बाइ‑लेवल ऑपरेशन्स पूर्ववर्ती अल्फा विवरण को हटा सकते हैं। श्रृंखला को इच्छित पिक्सेल‑प्रसंस्करण क्रम के अनुसार बनाएं, न कि इसे असूत्रित स्वरूपण फ्लैग मानें।

## **संपादन‑योग्य और प्रभावी मान निरीक्षण करें**

एक संपादन‑योग्य ऑपरेशन वह वस्तु है जो `ISlidesPicture.getImageTransform` में संग्रहीत होती है। प्रभाव के अनुसार, यह सीधे लिखने‑योग्य सदस्यों को उजागर कर सकता है। उदाहरण के लिए, [IBlur](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iblur/) लिखने‑योग्य `radius` और `grow` मान दिखाता है, [IAlphaModulateFixed](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ialphamodulatefixed/) लिखने‑योग्य `amount` दिखाता है, और [IAlphaBiLevel](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ialphabilevel/) लिखने‑योग्य `threshold` दिखाता है। [IDuotone](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iduotone/) जैसे रंग प्रभाव लिखने‑योग्य [IColorFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/icolorformat/) वस्तुएँ उजागर करते हैं।

कुछ ऑपरेशन इंटरफ़ेस, जैसे [IBrightnessContrast](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ibrightnesscontrast/), [IHSL](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ihsl/), [ITint](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itint/), और [IAlphaReplace](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ialphareplace/), अपने निर्माण स्केलर को लिखने‑योग्य प्रॉपर्टी के रूप में नहीं उजागर करते। इन सेटिंग्स को बदलने के लिए, ऑपरेशन को हटाएँ और आवश्यक स्थिति पर नया जोड़ें।

`getEffective()` द्वारा लौटाया गया प्रभावी डेटा गणना किया गया और केवल‑पढ़ने‑योग्य है। यह थीम‑निर्भर रंगों को हल करने और रेंडरर द्वारा उपयोग किए जाने वाले सामान्यीकृत मान पढ़ने में उपयोगी है, लेकिन यह किसी अन्य संपादन सतह नहीं है। निम्न उदाहरण श्रृंखला को क्रमबद्ध करता है और जहाँ उपलब्ध हो प्रभावी मानों को निरीक्षण करता है:

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

ग्रेस्केल, अल्फा सीलिंग, और अल्फा इनवर्स जैसे पैरामीटर‑मुक्त प्रभावों का अभी भी एक प्रभावी‑डेटा ऑब्जेक्ट होता है, लेकिन प्रिंट करने के लिए कोई स्केलर सेटिंग नहीं होती। उनका संग्रह में उपस्थित होना और स्थिति महत्वपूर्ण जानकारी है।

## **चित्र रूपांतरण हटाएँ या साफ़ करें**

एक ऑपरेशन को इंडेक्स द्वारा हटाने के लिए [IImageTransformOperationCollection.removeAt](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iimagetransformoperationcollection/#removeAt-int-) का उपयोग करें। क्योंकि हटाने के बाद इंडेक्स बदलते हैं, पहले लक्ष्य को खोजें और क्रमबद्ध करने के बाद उसे हटाएँ। पूरी श्रृंखला को हटाने हेतु [ImageTransformOperationCollection.clear](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/imagetransformoperationcollection/#clear--) का उपयोग करें।

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

रूपांतरण हटाने या साफ़ करने से केवल चित्र स्वरूपण बदलता है। यह पुनः उपयोग किए गए [IPPImage](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ippimage/) संसाधन को नहीं हटाता, संपीड़ित करता या अन्य रूप से परिवर्तित करता।

## **प्रेज़ेंटेशन स्वरूपों और निर्यात लक्ष्यों पर विचार करें**

चित्र रूपांतरण DrawingML में उत्पन्न होते हैं, इसलिए PPTX प्रभाव श्रृंखलाओं के लिए पसंदीदा संपादन‑योग्य स्वरूप है। PPTX होने पर भी सभी ऑपरेशन की पोर्टेबिलिटी समान नहीं होती:

- मानक DrawingML ऑपरेशन जैसे ल्यूमिनेंस, ग्रेस्केल, डुओटोन, टिंट, HSL, ब्लर, और सामान्य अल्फा ऑपरेशन PPTX राउंड‑ट्रिप में सबसे अधिक जीवित रहने की संभावना रखते हैं। जब संरक्षण आवश्यक हो, हमेशा उत्पन्न फ़ाइल को फिर से खोलें और संग्रह की जाँच करें।
- [BrightnessContrast](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/brightnesscontrast/) Office 2010 का विस्तार है, न कि मानक DrawingML ल्यूमिनेंस ऑपरेशन। इसे इन‑मेमोरी रेंडरिंग के लिये उपयोग किया जा सकता है, परंतु सहेजने और PPTX को दोबारा खोलने के बाद यह एक संपादन‑योग्य [IBrightnessContrast](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ibrightnesscontrast/) के रूप में बरकरार नहीं रह सकता। स्थायी प्रकाशता और कंट्रास्ट के लिये [addLuminanceEffect](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addLuminanceEffect-float-float-) को प्राथमिकता दें।
- बाइनरी PPT स्वरूप पूरी DrawingML प्रभाव मॉडल से पहले आया है। PPT में सहेजने से असमर्थित ऑपरेशन छोड़े जा सकते हैं, श्रृंखला को समर्थित उपसमुच्चय तक घटाया जा सकता है, या लगभग समान दृश्य प्रदान किया जा सकता है। जटिल संपादन‑योग्य श्रृंखला के लिये PPT को सत्यापन स्वरूप के रूप में उपयोग न करें।
- PNG, JPEG, TIFF, PDF, SVG, HTML या अन्य दृश्य आउटपुट केवल समर्थित श्रृंखला को रेंडर करने का काम करते हैं। इन आउटपुट में संपादन‑योग्य `IImageTransformOperationCollection` नहीं होता; रास्टर स्वरूप पिक्सेल में परिणाम को फ्लैट कर देते हैं, तथा दस्तावेज़/वेक्टर निर्यात अपना स्वयं का रेंडरिंग प्रतिनिधित्व संग्रहीत करते हैं।
- प्रभाव लिंक्ड इमेज को स्व-समाहित नहीं बनाते। लिंक्ड चित्र को रेंडर करने के लिये प्रस्तुति लोड होने पर लिंक्ड संसाधन उपलब्ध होना आवश्यक है।

विभिन्न प्रस्तुति उपभोक्ता किनारे के मामलों को अलग‑अलगा रेंडर कर सकते हैं, विशेषकर जब कई अल्फा या रंग‑क्वांटाइजिंग ऑपरेशन संयोजित हों। महत्वपूर्ण आउटपुट के लिये, उत्पादन में उपयोग किए गए समान Aspose.Slides संस्करण के साथ संपादन‑योग्य राउंड‑ट्रिप और अंतिम निर्यात स्वरूप दोनों का परीक्षण करें।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या छवि रूपांतरण प्रभाव एम्बेडेड चित्र डेटा को संशोधित करते हैं?**

नहीं। ये ऑपरेशन उस `ISlidesPicture` से जुड़े होते हैं जो चित्र फ़िल द्वारा उपयोग किया जाता है। अंतर्निहित `IPPImage` बाइट्स अपरिवर्तित रहती हैं।

**क्या दो चित्र फ्रेम जो समान चित्र पुन: उपयोग करते हैं अपने प्रभाव साझा करते हैं?**

नहीं। `IPPImage` को पुन: उपयोग करने से duplicate चित्र डेटा बचता है, परंतु प्रत्येक चित्र फ्रेम आम तौर पर अपना अलग `ISlidesPicture` और अपना चित्र रूपांतरण संग्रह रखता है।

**क्या रंग, ब्लर और अल्फा प्रभावों को मिलाया जा सकता है?**

हां। संग्रह उन्हें एक क्रमबद्ध श्रृंखला में स्वीकार करता है। प्रत्येक ऑपरेशन पिछले के आउटपुट को कैसे बदलता है, इस पर विचार करें क्योंकि प्रतिस्थापन और थ्रेशोल्ड ऑपरेशन पहले के रंग या अल्फा विवरण को हटा सकते हैं।

**प्रभावी मान केवल‑पढ़ने‑योग्य क्यों होते हैं?**

प्रभावी डेटा रेंडरिंग के लिये उपयोग किए गए गणना किए गए मानों का प्रतिनिधित्व करता है, जिसमें हल किए गए रंग शामिल हैं। जहाँ लिखने‑योग्य सदस्य उपलब्ध हों, संग्रह में संग्रहीत ऑपरेशन को संपादित करें; अन्यथा उसे हटाएँ और नई निर्माण पैरामीटर के साथ प्रतिस्थापित करें।

**कौन सा स्वरूप रूपांतरण श्रृंखला को संरक्षित रखने के लिये उपयोग करना चाहिए?**

PPTX का उपयोग करें और फ़ाइल को पुनः खोल कर सत्यापित करें। लेगेसी PPT पूर्ण DrawingML प्रभाव मॉडल को दर्शा नहीं सकता, और निर्यात स्वरूप केवल रूप‑रेखा को संरक्षित रखते हैं, न कि संपादन‑योग्य रूपांतरण ऑपरेशन।