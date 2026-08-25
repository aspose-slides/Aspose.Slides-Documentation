---
title: जावा के साथ प्रस्तुतियों में छवि रूपांतरण प्रभावों का प्रबंधन
linktitle: छवि रूपांतरण प्रभाव
type: docs
weight: 11
url: /hi/java/image-transform-effects/
keywords:
- छवि रूपांतरण
- चित्र प्रभाव
- चमक
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
- Java
- Aspose.Slides
description: "Aspose.Slides for Java के साथ चित्र फ़्रेमों के लिए छवि रूपांतरण प्रभावों को लागू करें, श्रृंखला बनाएँ, निरीक्षण करें, हटाएँ और सत्यापित करें।"
---
## **अवलोकन**

Aspose.Slides चित्र समायोजन को छवि रूपांतरण ऑपरेशनों के क्रमबद्ध संग्रह के रूप में दर्शाता है। एक चित्र फ़्रेम के लिए, फ़्रेम के [ISlidesPicture](https://reference.aspose.com/slides/hi/java/com.aspose.slides/islidespicture/) से शुरू करें और [ISlidesPicture.getImageTransform](https://reference.aspose.com/slides/hi/java/com.aspose.slides/islidespicture/#getImageTransform--) तक पहुँचें। लौटाया गया [IImageTransformOperationCollection](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iimagetransformoperationcollection/) आपको प्रभावों को जोड़ने, क्रमांकित करने, जांचने, हटाने और साफ़ करने की अनुमति देता है बिना मूल छवि बाइट्स को दोबारा लिखे।

यह लेख चमक और कंट्रास्ट, रंग रूपांतरण, ब्लर, पारदर्शिता, क्रमबद्ध प्रभाव श्रृंखला, प्रभावी मान, हटाना और PPTX राउंड‑ट्रिप प्रमाणीकरण के पूर्ण कार्यप्रवाह को दर्शाता है।

## **प्रभाव स्वामित्व और छवि पुन: उपयोग को समझें**

एक छवि संसाधन और उसे दर्शाने वाली चित्र अलग-अलग ऑब्जेक्ट हैं:

- [IPPImage](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ippimage/) प्रस्तुति द्वारा स्वामित्व वाली स्रोत छवि डेटा को संग्रहीत या संदर्भित करता है।
- [ISlidesPicture](https://reference.aspose.com/slides/hi/java/com.aspose.slides/islidespicture/) चित्र भराव से जुड़ा होता है और एक छवि संसाधन का संदर्भ देता है जबकि छवि रूपांतरण संग्रह संग्रहीत करता है।
- [IPictureFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipictureframe/) स्लाइड आकार है जो संबंधित चित्र भराव, ज्यामिति, क्रॉप सेटिंग्स और अन्य फ्रेम‑स्तर फ़ॉर्मेटिंग का स्वामित्व रखता है।

इसलिए, छवि रूपांतरण ऑपरेशनों से [IPPImage](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ippimage/) की बाइट्स नहीं बदलतीं। जब वही `IPPImage` को [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) में एक से अधिक बार पास किया जाता है, तो प्रत्येक नया चित्र फ़्रेम अपनी `ISlidesPicture` और अपनी रूपांतरण संग्रह प्राप्त करता है। एक फ़्रेम पर ग्रेस्केल लागू करना अन्य फ़्रेमों को ग्रेस्केल नहीं बनाता, भले ही सभी एक ही एम्बेडेड छवि संसाधन को पुन: उपयोग करते हों।

उसी `ISlidesPicture.getImageTransform` मॉडल का उपयोग अन्य चित्र भरावों, जैसे आकार या स्लाइड पृष्ठभूमि, द्वारा भी किया जाता है। नीचे दिए गए उदाहरण मुख्यतः चित्र फ़्रेमों पर केंद्रित हैं।

## **वैध पैरामीटर रेंज और इकाइयाँ उपयोग करें**

प्रदर्शित विधियाँ निम्नलिखित अर्थात्मक रेंज और इकाइयाँ प्रयोग करती हैं। इन रेंजों में मान रखें, भले ही किसी विशिष्ट लाइब्रेरी संस्करण में तुरंत सभी आउट‑ऑफ़‑रेंज मान अस्वीकृत न हों; लक्ष्य प्रस्तुति स्वरूप सहेजते समय या PowerPoint फ़ाइल खोलते समय अमान्य डेटा को सामान्यीकृत, हटाए या अस्वीकृत कर सकता है।

| ऑपरेशन | पैरामीटर | मान्य सीमा और इकाई |
|---|---|---|
| [addBrightnessContrastEffect](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iimagetransformoperationcollection/#addBrightnessContrastEffect-float-float-) | `brightness`, `contrast` | `-100` से `100` तक, प्रतिशत; `0` घटक को अपरिवर्तित रखता है। |
| [addGrayScaleEffect](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iimagetransformoperationcollection/#addGrayScaleEffect--) | None | कोई संख्यात्मक पैरामीटर नहीं। अल्फा अपरिवर्तित रहता है। |
| [addDuotoneEffect](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iimagetransformoperationcollection/#addDuotoneEffect--) | `color1`, `color2` | दो रंग – अँधेरे और हल्के पिक्सेल के लिए। `java.awt.Color` में RGB और अल्फा चैनल `0` से `255` तक उपयोग होते हैं। |
| [addTintEffect](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iimagetransformoperationcollection/#addTintEffect-float-float-) | `hue`, `amount` | ह्यू `0` (समावेश) से `360` (बहिष्करण) डिग्री; मात्रा `-100` से `100` तक, प्रतिशत। |
| [addHSLEffect](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iimagetransformoperationcollection/#addHSLEffect-float-float-float-) | `hue`, `saturation`, `luminance` | ह्यू `0` (समावेश) से `360` (बहिष्करण) डिग्री; संतृप्ति और चमक `-100` से `100` तक, प्रतिशत। |
| [addColorReplaceEffect](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iimagetransformoperationcollection/#addColorReplaceEffect--) | `color` | प्रतिस्थापन रंग के चैनल मान `0` से `255` तक होते हैं। मौजूदा अल्फा मान अपरिवर्तित रहता है। |
| [addBlurEffect](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iimagetransformoperationcollection/#addBlurEffect-double-boolean-) | `radius`, `grow` | त्रिज्या शून्य या अधिक और पॉइंट में मापी जाती है; `grow` एक Boolean है जो नियंत्रित करता है कि धुंधला सामग्री मूल सीमा से बाहर विस्तारित हो सकती है या नहीं। |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaModulateFixedEffect-float-) | `amount` | गैर‑नकारात्मक प्रतिशत। सामान्य अस्पष्टता स्केलिंग के लिए `0` से `100` उपयोग करें: `0` पूर्णतः पारदर्शी और `100` मौजूदा अल्फा को बनाए रखता है। |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaReplaceEffect-float-) | `alpha` | `0` से `100` तक, प्रतिशत अस्पष्टता। |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) | `threshold` | `0` से `100` तक, प्रतिशत अल्फा थ्रेशहोल्ड। इसके नीचे के मान पारदर्शी हो जाते हैं; थ्रेशहोल्ड या उससे ऊपर के मान अपारदर्शी हो जाते हैं। |

स्थिर अल्फा मॉड्यूलेशन के लिए, पारदर्शिता और अस्पष्टता परस्पर पूरक हैं। उदाहरण के लिए, 35 % पारदर्शिता अल्फा मॉड्यूलेशन मान 65 % के बराबर होती है।

## **चमक और कंट्रास्ट लागू करें**

[IImageTransformOperationCollection.addBrightnessContrastEffect](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iimagetransformoperationcollection/#addBrightnessContrastEffect-float-float-) एक [IBrightnessContrast](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ibrightnesscontrast/) ऑपरेशन लौटाता है। उसके स्केलर सेटिंग्स ऑपरेशन बनाते समय प्रदान किए जाते हैं। [IBrightnessContrast.getEffective](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ibrightnesscontrast/#getEffective--) गणना किए गए केवल‑पढ़े‑जाने‑योग्य मान लौटाता है जिन्हें निरीक्षण या लॉग किया जा सकता है।

निम्न उदाहरण चमक को 15 % और कंट्रास्ट को 20 % बढ़ाता है, फिर एम्बेडेड छवि को बदले बिना एक प्रीव्यू रेंडर करता है:

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    byte[] imageData = Files.readAllBytes(Paths.get("photo.png"));
    IPPImage image = presentation.getImages().addImage(imageData);
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

[BrightnessContrast](https://reference.aspose.com/slides/hi/java/com.aspose.slides/brightnesscontrast/) एक Office 2010 चित्र‑प्रभाव विस्तार है और मानक DrawingML चमक प्रभाव की तुलना में कम पोर्टेबल है। जब चमक और कंट्रास्ट को PPTX राउंड‑ट्रिप के बाद भी संपादन‑योग्य रखना हो, तो [IImageTransformOperationCollection.addLuminanceEffect](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iimagetransformoperationcollection/#addLuminanceEffect-float-float-) उपयोग करें और फ़ाइल को पुनः खोलने के बाद परिणाम सत्यापित करें। स्वरूप सीमाएँ इस अंतर को अधिक विस्तार से समझाती हैं।

## **रंग रूपांतरण लागू करें**

रंग प्रभावों को अलग‑अलग चित्र फ़्रेमों पर स्वतंत्र रूप से लागू किया जा सकता है जो एक ही छवि संसाधन को पुन: उपयोग करते हैं। नीचे का उदाहरण पाँच फ़्रेम बनाता है और क्रमशः ग्रेस्केल, डुओटोन, टिंट, HSL समायोजन और रंग प्रतिस्थापन लागू करता है।

[IDuotone](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iduotone/) दो स्वतंत्र रूप से संपादनीय रंग पैरामीटर रखता है: `color1` अँधेरे पिक्सेल को मैप करता है, जबकि `color2` हल्के पिक्सेल को। यह एक ऐसे प्रभाव का उपयोगी उदाहरण है जिसकी सेटिंग्स एकल स्केलर मान से अधिक जटिल हैं।

```java
import com.aspose.slides.*;
import java.awt.Color;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    byte[] imageData = Files.readAllBytes(Paths.get("photo.png"));
    IPPImage image = presentation.getImages().addImage(imageData);

    IPictureFrame grayFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 180, 120, image);
    grayFrame.getPictureFormat().getPicture().getImageTransform().addGrayScaleEffect();

    IPictureFrame duotoneFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 220, 20, 180, 120, image);
    IDuotone duotone = duotoneFrame.getPictureFormat().getPicture().getImageTransform().addDuotoneEffect();
    duotone.getColor1().setColor(new Color(0, 0, 128));
    duotone.getColor2().setColor(new Color(255, 215, 0));

    IPictureFrame tintFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 420, 20, 180, 120, image);
    tintFrame.getPictureFormat().getPicture().getImageTransform().addTintEffect(210f, 35f);

    IPictureFrame hslFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 120, 170, 180, 120, image);
    hslFrame.getPictureFormat().getPicture().getImageTransform().addHSLEffect(30f, 20f, -10f);

    IPictureFrame replacementFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 320, 170, 180, 120, image);
    IColorReplace colorReplacement = replacementFrame.getPictureFormat().getPicture().getImageTransform().addColorReplaceEffect();
    colorReplacement.getColor().setColor(new Color(100, 149, 237));

    presentation.save("color-transformations.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[addColorReplaceEffect](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iimagetransformoperationcollection/#addColorReplaceEffect--) प्रत्येक पिक्सेल के रंग को एक निश्चित रंग से बदल देता है जबकि अल्फा को संरक्षित रखता है। यह [addColorChangeEffect](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iimagetransformoperationcollection/#addColorChangeEffect--) से अलग है, जो एक स्रोत रंग को दूसरे में मैप करता है और दोनों स्रोत एवं लक्ष्य रंग स्वरूप को उजागर करता है।

## **ब्लर, पारदर्शिता और अल्फा प्रभाव जोड़ें**

[addBlurEffect](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iimagetransformoperationcollection/#addBlurEffect-double-boolean-) सभी रंग चैनलों, अल्फा सहित, को प्रभावित करता है। जब धुंधली किनारी मूल चित्र सीमा से बाहर जा सकती है, तो `grow` को `true` सेट करें।

समान पारदर्शिता के लिए, [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaModulateFixedEffect-float-) उपयोग करें। यह प्रत्येक मौजूदा अल्फा मान को गुणा करता है, इसलिए आंशिक रूप से पारदर्शी पिक्सेल अनुपातिक रूप से अलग रहते हैं। [addAlphaReplaceEffect](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaReplaceEffect-float-) सभी पिक्सेल को एक ही अल्फा मान असाइन करता है। [addAlphaBiLevelEffect](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) थ्रेशहोल्ड के आधार पर अल्फा को दो स्तरों में परिवर्तित करता है।

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    byte[] imageData = Files.readAllBytes(Paths.get("photo.png"));
    IPPImage image = presentation.getImages().addImage(imageData);

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

अन्य पैरामीटर‑रहित अल्फा ऑपरेशनों में [addAlphaCeilingEffect](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaCeilingEffect--) शामिल है, जो प्रत्येक शून्य‑से‑अधिक अल्फा को पूर्णतः अपारदर्शी बनाता है; [addAlphaFloorEffect](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaFloorEffect--) जो 100 % से कम प्रत्येक अल्फा को पूर्णतः पारदर्शी बनाता है; तथा [addAlphaInverseEffect](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaInverseEffect--) जो अल्फा को `100% - alpha` में बदलता है।

## **क्रमबद्ध प्रभाव श्रृंखला बनाएं**

प्रत्येक `add...Effect` विधि एक नई ऑपरेशन को संग्रह के अंत में जोड़ती है। रेंडरर संग्रह को क्रमबद्ध पाइपलाइन के रूप में प्रयोग करता है: ऑपरेशन 0 का आउटपुट ऑपरेशन 1 का इनपुट बनता है, और आगे। इसलिए समान ऑपरेशन को अलग क्रम में रखने से अलग छवि बन सकती है।

उदाहरण के लिए, ग्रेस्केल के बाद टिंट पहले क्रोमैटिक जानकारी हटा देता है और फिर ल्यूमिनेंस परिणाम को पुनः रंगता है। टिंट के बाद ग्रेस्केल टिंट को फिर से हटा देता है। इसी तरह, अल्फा प्रतिस्थापन पहले की ऑपरेशनों द्वारा गणना किए गए अल्फा मानों को अधिलेखित कर सकता है, जबकि अल्फा मॉड्यूलेशन उनके सापेक्ष अंतर को बनाए रखता है।

निम्न उदाहरण चार‑ऑपरेशन श्रृंखला बनाता है, उसे PPTX के रूप में सहेजता है, प्रस्तुति को फिर से खोलता है, ऑपरेशन प्रकार और क्रम दोनों को जाँचता है, और पुनः‑खोली गई परिणाम को रेंडर करता है:

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    byte[] imageData = Files.readAllBytes(Paths.get("photo.png"));
    IPPImage image = presentation.getImages().addImage(imageData);
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

संग्रह कोई संगतता मैट्रिक्स लागू नहीं करता जो रंग, अल्फा और ब्लर ऑपरेशनों को अलग‑अलग श्रृंखलाओं तक सीमित करता हो। उन्हें संयोजन में इस्तेमाल किया जा सकता है, परन्तु सभी संयोजन हमेशा उपयोगी नहीं होते। एक स्थिर रंग प्रतिस्थापन पूर्व के रंग प्रभावों द्वारा उत्पन्न RGB विविधता को हटा देता है; डुओटोन के बाद ग्रेस्केल दो चयनित रंगों को हटा देता है; और अल्फा सीलिंग, फ़्लोर, प्रतिस्थापन या बाय‑लेवल ऑपरेशन पूर्व बनाए गए अल्फा विवरण को नकार सकते हैं। श्रृंखला को इच्छित पिक्सेल‑प्रोसेसिंग क्रम के अनुसार बनाएँ, न कि इसे अनऑर्डर्ड फ़ॉर्मेटिंग फ़्लैग के रूप में देखें।

## **संपादन‑योग्य और प्रभावी मानों का निरीक्षण करें**

एक संपादन‑योग्य ऑपरेशन वह ऑब्जेक्ट है जो `ISlidesPicture.getImageTransform` में संग्रहीत होता है। प्रभाव के आधार पर, यह सीधे लिखने योग्य सदस्य उजागर कर सकता है। उदाहरण के लिए, [IBlur](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iblur/) लिखने योग्य `radius` और `grow` मान उजागर करता है, [IAlphaModulateFixed](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ialphamodulatefixed/) लिखने योग्य `amount` उजागर करता है, और [IAlphaBiLevel](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ialphabilevel/) लिखने योग्य `threshold` उजागर करता है। जैसे [IDuotone](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iduotone/) के रंग प्रभावों में परिवर्तनीय [IColorFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/icolorformat/) ऑब्जेक्ट होते हैं।

कुछ ऑपरेशन इंटरफ़ेस, जैसे [IBrightnessContrast](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ibrightnesscontrast/), [IHSL](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ihsl/), [ITint](https://reference.aspose.com/slides/hi/java/com.aspose.slides/itint/), तथा [IAlphaReplace](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ialphareplace/), अपने निर्माण स्केलर को लिखने योग्य गुणों के रूप में उजागर नहीं करते। उन सेटिंग्स को बदलने के लिए, ऑपरेशन को हटाएँ और आवश्यक स्थान पर एक प्रतिस्थापन जोड़ें।

`getEffective()` द्वारा लौटाए गए प्रभावी डेटा की गणना की गई होती है और केवल‑पढ़े‑जाने‑योग्य होते हैं। यह थिम‑निर्भर रंगों को हल करने और रेंडरर द्वारा उपयोग किए गए सामान्यीकृत मान पढ़ने के लिए उपयोगी है, परन्तु यह एक और संपादन सतह नहीं है। नीचे का उदाहरण श्रृंखला को क्रमबद्ध करता है और जहाँ संबंधित API उन्हें प्रदान करती है, प्रभावी मानों का निरीक्षण करता है:

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

बिना पैरामीटर वाले प्रभाव जैसे ग्रेस्केल, अल्फा सीलिंग, और अल्फा इनवर्स भी एक प्रभावी‑डेटा ऑब्जेक्ट रखते हैं, परन्तु प्रिंट करने हेतु कोई स्केलर सेटिंग नहीं होती। उनका संग्रह में उपस्थित होना और स्थिति ही महत्वपूर्ण जानकारी है।

## **छवि रूपांतरण हटाएँ या साफ़ करें**

एक ऑपरेशन को इंडेक्स द्वारा हटाने के लिए [IImageTransformOperationCollection.removeAt](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iimagetransformoperationcollection/#removeAt-int-) उपयोग करें। हटाने के बाद इंडेक्स बदलते हैं, इसलिए पहले लक्ष्य को खोजें और क्रमांकित करने के बाद हटाएँ। पूरी श्रृंखला को हटाने के लिए [ImageTransformOperationCollection.clear](https://reference.aspose.com/slides/hi/java/com.aspose.slides/imagetransformoperationcollection/#clear--) उपयोग करें।

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

रूपांतरण हटाने या साफ़ करने से केवल चित्र फ़ॉर्मेटिंग बदलती है। यह पुन: उपयोग किए गए [IPPImage](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ippimage/) संसाधन को नहीं हटाता, पुनः‑संकुचित नहीं करता या अन्यथा बदलता नहीं है।

## **प्रस्तुति स्वरूप और निर्यात लक्ष्य पर विचार करें**

छवि रूपांतरण DrawingML में उत्पन्न होते हैं, इसलिए PPTX प्रभाव श्रृंखलाओं के लिए प्राथमिक संपादन‑योग्य स्वरूप है। यहाँ तक कि PPTX पर भी, सभी ऑपरेशनों की पोर्टेबिलिटी समान नहीं होती:

- मानक DrawingML ऑपरेशनों जैसे ल्यूमिनेंस, ग्रेस्केल, डुओटोन, टिंट, HSL, ब्लर और सामान्य अल्फा ऑपरेशनों की PPTX राउंड‑ट्रिप में जीवित रहने की सबसे अधिक संभावना होती है। हमेशा उत्पन्न फ़ाइल को फिर से खोलें और संग्रह का निरीक्षण करें जब संरक्षण आवश्यक हो।
- [BrightnessContrast](https://reference.aspose.com/slides/hi/java/com.aspose.slides/brightnesscontrast/) Office 2010 का विस्तार है, मानक DrawingML ल्यूमिनेंस ऑपरेशन नहीं। इसे इन‑मेमा रेंडरिंग के लिए उपयोग किया जा सकता है, परंतु सहेजने और PPTX पुनः खोलने के बाद यह संपादन‑योग्य [IBrightnessContrast](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ibrightnesscontrast/) के रूप में बना रहेगा, इसकी कोई गारंटी नहीं है। स्थायी चमक‑कंट्रास्ट समायोजन के लिए [addLuminanceEffect](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iimagetransformoperationcollection/#addLuminanceEffect-float-float-) को प्राथमिकता दें।
- बाइनरी PPT स्वरूप पूर्ण DrawingML प्रभाव मॉडल से पूर्व है। PPT में सहेजने से असमर्थित ऑपरेशनों को छोड़ दिया जा सकता है, श्रृंखला को समर्थित उपसमुच्चय में घटाया जा सकता है, या स्वरूप का अनुमान लगाया जा सकता है। जटिल संपादन‑योग्य श्रृंखला के लिए PPT को सत्यापन स्वरूप के रूप में उपयोग न करें।
- PNG, JPEG, TIFF, PDF, SVG, HTML या अन्य दृश्य आउटपुट को रेंडर करने पर समर्थित श्रृंखला लागू होती है। ये आउटपुट संपादन‑योग्य `IImageTransformOperationCollection` नहीं रखते; रास्टर स्वरूप परिणाम को पिक्सेल में फ़्लैट कर देता है, और दस्तावेज़/वेक्टर निर्यात अपनी स्वयं की रेंडरिंग प्रतिनिधित्व संग्रहीत करते हैं।
- प्रभाव लिंक्ड चित्र को स्व-संगत नहीं बनाते। लिंक्ड चित्र को रेंडर करने के लिए लिंक्ड संसाधन को प्रस्तुति लोड होने पर उपलब्ध होना आवश्यक है।

विभिन्न प्रस्तुति उपभोक्ता किनारे के मामलों को अलग‑अलग रेंडर कर सकते हैं, विशेषकर जब कई अल्फा या रंग‑क्वांटाइज़िंग ऑपरेशनों को मिलाया जाता है। महत्वपूर्ण आउटपुट के लिए, उत्पादन में उपयोग किए जा रहे वही Aspose.Slides संस्करण के साथ संपादन‑योग्य राउंड‑ट्रिप और अंतिम निर्यात स्वरूप दोनों का परीक्षण करें।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या छवि रूपांतरण प्रभाव एम्बेडेड छवि डेटा को संशोधित करते हैं?**

नहीं। ऑपरेशन `ISlidesPicture` से संबंधित होते हैं जो चित्र भराव द्वारा उपयोग किया जाता है। अंतर्निहित `IPPImage` बाइट्स अपरिवर्तित रहती हैं।

**क्या दो चित्र फ़्रेम जो aynı छवि को पुन: उपयोग करते हैं, अपने प्रभाव साझा करते हैं?**

नहीं। `IPPImage` को पुन: उपयोग करने से डुप्लिकेट छवि डेटा से बचा जाता है, परंतु प्रत्येक चित्र फ़्रेम आमतौर पर अपना अलग `ISlidesPicture` और अपनी छवि रूपांतरण संग्रह रखता है।

**क्या रंग, ब्लर और अल्फा प्रभावों को एक साथ जोड़ा जा सकता है?**

हाँ। संग्रह उन्हें एक क्रमबद्ध श्रृंखला में स्वीकार करता है। प्रत्येक ऑपरेशन पिछले वाले के आउटपुट को कैसे बदलता है, इस पर विचार करें क्योंकि प्रतिस्थापन और थ्रेशहोल्ड ऑपरेशनों से पहले के रंग या अल्फा विवरण हटाया जा सकता है।

**प्रभावी मान केवल‑पढ़े‑जाने‑योग्य क्यों होते हैं?**

प्रभावी डेटा रेंडरिंग के लिए गणना किए गए मान दर्शाता है, जिसमें हल किए गए रंग शामिल हैं। जहाँ लिखने योग्य सदस्य मौजूद हों, रूपांतरण संग्रह में संग्रहीत ऑपरेशन को संपादित करें; अन्यथा उसे हटाएँ और नई निर्माण पैरामीटर वाले प्रतिस्थापन को जोड़ें।

**कौन‑सा स्वरूप प्रभाव श्रृंखला को संरक्षित रखने के लिए उपयोग करना चाहिए?**

PPTX उपयोग करें और फ़ाइल को फिर से खोलकर सत्यापित करें। लेगेसी PPT पूर्ण DrawingML प्रभाव मॉडल को दर्शा नहीं सकता, और रेंडरित निर्यात स्वरूप केवल दिखावट को संरक्षित करते हैं, न कि संपादन‑योग्य रूपांतरण ऑपरेशनों को।