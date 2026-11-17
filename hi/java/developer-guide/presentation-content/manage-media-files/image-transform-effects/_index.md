---
title: जावा के साथ प्रस्तुतियों में छवि रूपांतरण प्रभावों का प्रबंधन
linktitle: छवि रूपांतरण प्रभाव
type: docs
weight: 11
url: /hi/java/image-transform-effects/
keywords:
- छवि रूपांतरण
- चित्र प्रभाव
- उज्जवलता
- कंट्रास्ट
- ग्रेस्केल
- ड्युटोन
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
description: "Aspose.Slides for Java के साथ चित्र फ्रेम के लिए छवि रूपांतरण प्रभावों को लागू करें, श्रृंखलाबद्ध करें, निरीक्षण करें, हटाएँ, और सत्यापित करें।"
---
## **समीक्षा**

Aspose.Slides चित्र समायोजन को छवि रूपांतरण संचालन के एक क्रमबद्ध संग्रह के रूप में दर्शाता है। एक चित्र फ्रेम के लिए, फ्रेम के [ISlidesPicture](https://reference.aspose.com/slides/java/com.aspose.slides/islidespicture/) से शुरू करें और [ISlidesPicture.getImageTransform](https://reference.aspose.com/slides/java/com.aspose.slides/islidespicture/#getImageTransform--) तक पहुँचें। लौटाया गया [IImageTransformOperationCollection](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/) आपको प्रभावों को जोड़ने, क्रमबद्ध करने, निरीक्षण करने, हटाने और स्पष्ट करने की अनुमति देता है बिना मूल छवि बाइट्स को पुन: लिखे।

यह लेख उज्जवलता और कंट्रास्ट, रंग रूपांतरण, धुंध, पारदर्शिता, क्रमबद्ध प्रभाव श्रृंखलाओं, प्रभावी मान, हटाना और PPTX राउंड-ट्रिप सत्यापन के लिए एक पूर्ण कार्यप्रवाह दर्शाता है।

## **प्रभाव स्वामित्व और छवि पुन: उपयोग को समझें**

एक छवि संसाधन और उसे प्रदर्शित करने वाला चित्र दो अलग-अलग वस्तुएँ हैं:

- [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/ippimage/) प्रस्तुति द्वारा स्वामित्व में स्रोत छवि डेटा को संग्रहीत या संदर्भित करता है।
- [ISlidesPicture](https://reference.aspose.com/slides/java/com.aspose.slides/islidespicture/) एक चित्र भराव का हिस्सा है और एक छवि संसाधन को संदर्भित करता है जबकि छवि रूपांतरण संग्रह को संग्रहीत करता है.
- [IPictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframe/) वह स्लाइड आकार है जो संबंधित चित्र भराव, ज्यामिति, क्रॉप सेटिंग्स और अन्य फ्रेम-स्तर फॉर्मेटिंग को स्वामित्व में रखता है.

इसलिए, छवि रूपांतरण संचालन [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/ippimage/) में बाइट्स को संशोधित नहीं करते। जब एक ही `IPPImage` को [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) को एक से अधिक बार पास किया जाता है, तब प्रत्येक नया चित्र फ्रेम अपना स्वयं का `ISlidesPicture` और अपनी रूपांतरण संग्रह प्राप्त करता है। एक फ्रेम पर ग्रेस्केल लागू करने से अन्य फ्रेम ग्रेस्केल नहीं होते, चाहे सभी एक ही एम्बेडेड छवि संसाधन को पुन: उपयोग कर रहे हों।

इसी `ISlidesPicture.getImageTransform` मॉडल का उपयोग अन्य चित्र भराव, जैसे आकार या स्लाइड पृष्ठभूमि, द्वारा भी किया जाता है। नीचे के उदाहरण चित्र फ्रेम पर केंद्रित हैं।

## **वैध पैरामीटर रेंज और इकाइयों का उपयोग करें**

दर्शाए गए मेथड्स निम्नलिखित अर्थपूर्ण रेंज और इकाइयों का उपयोग करते हैं। इन रेंजों में मान रखें चाहे कोई विशेष लाइब्रेरी संस्करण तुरंत सभी आउट-ऑफ-रेंज मानों को अस्वीकार न करे; लक्षित प्रस्तुति प्रारूप सहेजते समय या PowerPoint फ़ाइल खोलते समय डेटा को सामान्यीकरण, वर्जन या अस्वीकार कर सकता है।

| ऑपरेशन | पैरामीटर | वैध रेंज और इकाई |
|---|---|---|
| [addBrightnessContrastEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addBrightnessContrastEffect-float-float-) | `brightness`, `contrast` | `-100` से `100` तक, प्रतिशत; `0` घटक को अपरिवर्तित छोड़ता है। |
| [addGrayScaleEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addGrayScaleEffect--) | None | कोई संख्यात्मक पैरामीटर नहीं। अल्फा अपरिवर्तित रहता है। |
| [addDuotoneEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addDuotoneEffect--) | `color1`, `color2` | गहरे और हल्के पिक्सेल के लिए दो रंग। `java.awt.Color` में RGB और अल्फा चैनल `0` से `255` तक होते हैं। |
| [addTintEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addTintEffect-float-float-) | `hue`, `amount` | ह्यू `0` सहित से `360` विशिष्ट, डिग्री में; मात्रा `-100` से `100` तक, प्रतिशत। |
| [addHSLEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addHSLEffect-float-float-float-) | `hue`, `saturation`, `luminance` | ह्यू `0` सहित से `360` विशिष्ट, डिग्री में; सैचुरेशन और ल्यूमिनेंस `-100` से `100` तक, प्रतिशत। |
| [addColorReplaceEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addColorReplaceEffect--) | `color` | प्रतिस्थापन रंग चैनल मूल्यों को `0` से `255` तक उपयोग करता है। मौजूदा अल्फा मान अपरिवर्तित रहते हैं। |
| [addBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addBlurEffect-double-boolean-) | `radius`, `grow` | `radius` गैर-नकारात्मक है और पॉइंट्स में मापा जाता है; `grow` एक Boolean है जो नियंत्रित करता है कि धुंधला सामग्री मूल सीमा के बाहर विस्तारित हो सकती है या नहीं। |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaModulateFixedEffect-float-) | `amount` | गैर-नकारात्मक प्रतिशत। सामान्य अपारदर्शिता स्केलिंग के लिए `0` से `100` उपयोग करें: `0` पूरी तरह पारदर्शी और `100` मौजूदा अल्फा को बरकरार रखता है। |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaReplaceEffect-float-) | `alpha` | `0` से `100` तक, प्रतिशत अपारदर्शिता। |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) | `threshold` | `0` से `100` तक, प्रतिशत अल्फा थ्रेशोल्ड। इस मान से नीचे के मान पारदर्शी हो जाते हैं; इस मान के बराबर या उससे अधिक के मान अपैरेंट हो जाते हैं। |

स्थिर अल्फा मॉड्यूलेशन के लिए, पारदर्शिता और अपारदर्शिता परस्पर पूरक होते हैं। उदाहरण के लिए, 35% पारदर्शिता के लिए अल्फा मॉड्यूलेशन मात्रा 65% होती है।

## **उज्जवलता और कंट्रास्ट लागू करें**

[IImageTransformOperationCollection.addBrightnessContrastEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addBrightnessContrastEffect-float-float-) एक [IBrightnessContrast](https://reference.aspose.com/slides/java/com.aspose.slides/ibrightnesscontrast/) ऑपरेशन लौटाता है। इसके स्केलर सेटिंग्स ऑपरेशन निर्माण के समय प्रदान की जाती हैं। [BrightnessContrast.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/brightnesscontrast/#getEffective--) गणना किए गए केवल-पढ़ने योग्य मान लौटाता है जिन्हें निरीक्षण या लॉग किया जा सकता है।

निम्न उदाहरण उज्जवलता को 15% और कंट्रास्ट को 20% बढ़ाता है, फिर एंबेडेड छवि को संशोधित किए बिना एक पूर्वावलोकन रेंडर करता है:

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

[BrightnessContrast](https://reference.aspose.com/slides/java/com.aspose.slides/brightnesscontrast/) एक Office 2010 चित्र-प्रभाव विस्तार है और मानक DrawingML ल्यूमिनेंस प्रभाव की तुलना में कम पोर्टेबल है। जब उज्जवलता और कंट्रास्ट को PPTX राउंड-ट्रिप के बाद भी संपादन योग्य रहना हो, तो [IImageTransformOperationCollection.addLuminanceEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addLuminanceEffect-float-float-) का उपयोग करें और फ़ाइल को पुनः खोलने के बाद परिणाम सत्यापित करें। फ़ॉर्मेट सीमाओं अनुभाग इस अंतर को अधिक विस्तार से समझाता है।

## **रंग रूपांतरण लागू करें**

रंग प्रभाव को विभिन्न चित्र फ्रेम पर स्वतंत्र रूप से लागू किया जा सकता है जो एक ही छवि संसाधन को पुन: उपयोग करते हैं। निम्न उदाहरण पाँच फ्रेम बनाता है और ग्रेस्केल, ड्युटोन, टिंट, HSL समायोजन, तथा रंग प्रतिस्थापन लागू करता है।

[IDuotone](https://reference.aspose.com/slides/java/com.aspose.slides/iduotone/) में दो स्वतंत्र रूप से संपादन योग्य रंग पैरामीटर होते हैं: `color1` गहरे पिक्सेल को मैप करता है, जबकि `color2` हल्के पिक्सेल को मैप करता है। यह एक उपयोगी उदाहरण बनाता है जहाँ प्रभाव के सेटिंग्स एकल स्केलर मान से अधिक जटिल होते हैं।

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

[addColorReplaceEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addColorReplaceEffect--) हर पिक्सेल का रंग एक निश्चित रंग से बदल देता है जबकि अल्फा को बरकरार रखता है। यह [addColorChangeEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addColorChangeEffect--) से अलग है, जो एक स्रोत रंग को दूसरे में मैप करता है और दोनों स्रोत और लक्ष्य रंग स्वरूपों को उजागर करता है।

### **ल्यूमिनेंस थ्रेशोल्ड लागू करें**

ल्यूमिनेंस थ्रेशोल्ड स्कैन की गई पृष्ठ पर धुंधले चिह्नों को पृष्ठभूमि से अलग पहचानना आसान बना सकता है। [addGrayScaleEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addGrayScaleEffect--) मध्यवर्ती ग्रे शेड्स को बरकरार रखता है। [addBiLevelEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addBiLevelEffect-float-) ल्यूमिनेंस को काले या सफेद में मैप करता है, जबकि [addAlphaBiLevelEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) अपारदर्शिता पर एक थ्रेशोल्ड लागू करता है।

ल्यूमिनेंस थ्रेशोल्ड 0% से 100% तक, दोनों सम्मिलित, रहता है। थ्रेशोल्ड से नीचे के पिक्सेल काले हो जाते हैं। थ्रेशोल्ड के बराबर या उससे ऊपर के पिक्सेल सफेद हो जाते हैं। थ्रेशोल्ड बढ़ाने से अधिक शेड्स काले हो जाते हैं क्योंकि अधिक पिक्सेल कटऑफ से नीचे आ जाते हैं।

[grayscale-swatches.png](grayscale-swatches.png) को कार्य निर्देशिका में डाउनलोड करें। प्रत्येक लेबल 0 से 255 के पैमाने पर मूल ग्रे स्तर देता है। उदाहरण मूल को दो प्रतियों के बगल में रखता है और प्रत्येक प्रतिलिपि का थ्रेशोल्ड प्रस्तुति में सहेजता है।

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(720, 150, SlideSizeScaleType.DoNotScale);
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    byte[] imageData = Files.readAllBytes(Paths.get("grayscale-swatches.png"));
    IPPImage image = presentation.getImages().addImage(imageData);

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

आउटपुट प्रस्तुति को PowerPoint में खोलें ताकि तीन फ्रेमों की तुलना की जा सके। 96 लेबल वाला स्वैच लगभग 38% ल्यूमिनेंस (255 में से 96) रखता है। यह 20% थ्रेशोल्ड पर सफेद और 60% थ्रेशोल्ड पर काला हो जाता है।

![ल्यूमिनेंस थ्रेशोल्ड 20% और 60% पर काले-और-सफेद परिणामों के बगल में मूल ग्रेस्केल स्वैच](luminance-threshold.png)

## **ब्लर, पारदर्शिता और अल्फा प्रभाव जोड़ें**

[addBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addBlurEffect-double-boolean-) सभी रंग चैनलों को प्रभावित करता है, जिसमें अल्फा भी शामिल है। जब धुंधला किनारा मूल चित्र की सीमाओं से बाहर जा सकता है, तो `grow` को `true` सेट करें।

समान पारदर्शिता के लिए, [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaModulateFixedEffect-float-) का उपयोग करें। यह प्रत्येक मौजूदा अल्फा मान को गुणा करता है, इसलिए आंशिक रूप से पारदर्शी पिक्सेल अनुपातिक रूप से अलग रहते हैं। [addAlphaReplaceEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaReplaceEffect-float-) सभी पिक्सेल को एक ही अल्फा मान सौंपता है। [addAlphaBiLevelEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) एक थ्रेशोल्ड के आधार पर अल्फा को दो स्तरों में बदलता है।

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

अन्य पैरामीटर-रहित अल्फा संचालन में [addAlphaCeilingEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaCeilingEffect--) शामिल है, जो प्रत्येक गैर-शून्य अल्फा को पूरी तरह अपैरेंट बनाता है; [addAlphaFloorEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaFloorEffect--) जो 100% से नीचे के प्रत्येक अल्फा को पूरी तरह पारदर्शी बनाता है; और [addAlphaInverseEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaInverseEffect--) जो अल्फा को `100% - alpha` में बदलता है।

## **एक क्रमबद्ध प्रभाव श्रृंखला बनाएं**

प्रत्येक `add...Effect` मेथड संग्रह के अंत में एक नया ऑपरेशन जोड़ता है। रेंडरर संग्रह को एक क्रमबद्ध पाइपलाइन के रूप में उपयोग करता है: ऑपरेशन 0 का आउटपुट ऑपरेशन 1 का इनपुट बन जाता है, आदि। परिणामस्वरूप, समान ऑपरेशनों का विभिन्न क्रम में होना अलग चित्र उत्पन्न कर सकता है।

उदाहरण के लिए, ग्रेस्केल के बाद टिंट पहले रंगीय जानकारी हटाता है और फिर ल्यूमिनेंस परिणाम को पुनः रंगित करता है। टिंट के बाद ग्रेस्केल टिंट को पुनः हटाता है। इसी प्रकार, अल्फा प्रतिस्थापन पहले के ऑपरेशनों द्वारा गणना किए गए अल्फा मानों को ओवरराइड कर सकता है, जबकि अल्फा मॉड्यूलेशन उनके सापेक्ष अंतर को बरकरार रखता है।

निम्न उदाहरण चार-ऑपरेशन श्रृंखला बनाता है, इसे PPTX के रूप में सहेजता है, प्रस्तुति को फिर से खोलता है, दोनों ऑपरेशन प्रकार और उनका क्रम जांचता है, और पुनः खोला गया परिणाम रेंडर करता है:

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

संग्रह कोई संगतता मैट्रिक्स नहीं लागू करता जो रंग, अल्फा और ब्लर ऑपरेशन्स को अलग-अलग श्रृंखलाओं तक सीमित करता हो। इन्हें संयोजित किया जा सकता है, लेकिन संयोजन हमेशा उपयोगी नहीं होते। एक स्थिर रंग प्रतिस्थापन पहले के रंग प्रभावों द्वारा उत्पन्न RGB विविधता को हटा देता है; ड्युटोन के बाद ग्रेस्केल दो चयनित रंगों को हटा देता है; और अल्फा सीलिंग, फ्लोर, प्रतिस्थापन, या बि-लेवल ऑपरेशन्स पहले बनाई गई अल्फा विवरण को हटा सकते हैं। इच्छित पिक्सेल-प्रोसेसिंग क्रम के अनुसार श्रृंखला बनाएं न कि उसके आइटम को अनऑर्डर्ड फ़ॉर्मेटिंग फ्लैग्स के रूप में देखें।

<!-- visual-explanation:image-transform-effects:start -->
[![The same image passes through grayscale then tint, and tint then grayscale. The two final grayscale images have different tones.](visual-image-transform-effects-49aa72211f3a.svg)](visual-image-transform-effects-49aa72211f3a.svg)

*In this illustrative Aspose.Slides for .NET 26.11 render, a 220° tint at 25% leaves the grayscale image unchanged. Applying the same tint before grayscale produces different tones.*
<!-- visual-explanation:image-transform-effects:end -->

## **संपादन योग्य और प्रभावी मानों की जाँच करें**

एक संपादन योग्य ऑपरेशन वह वस्तु है जो `ISlidesPicture.getImageTransform` में संग्रहीत होती है। प्रभाव के आधार पर, यह सीधे लिखने योग्य सदस्य दिखा सकता है। उदाहरण के लिए, [IBlur](https://reference.aspose.com/slides/java/com.aspose.slides/iblur/) लिखने योग्य `radius` और `grow` मान दिखाता है, [IAlphaModulateFixed](https://reference.aspose.com/slides/java/com.aspose.slides/ialphamodulatefixed/) लिखने योग्य `amount` दिखाता है, और [IAlphaBiLevel](https://reference.aspose.com/slides/java/com.aspose.slides/ialphabilevel/) लिखने योग्य `threshold` दिखाता है। रंग प्रभाव जैसे [IDuotone](https://reference.aspose.com/slides/java/com.aspose.slides/iduotone/) परिवर्तनशील [IColorFormat](https://reference.aspose.com/slides/java/com.aspose.slides/icolorformat/) वस्तुओं को उजागर करता है।

कुछ ऑपरेशन इंटरफेस, जिसमें [IBrightnessContrast](https://reference.aspose.com/slides/java/com.aspose.slides/ibrightnesscontrast/), [IHSL](https://reference.aspose.com/slides/java/com.aspose.slides/ihsl/), [ITint](https://reference.aspose.com/slides/java/com.aspose.slides/itint/), और [IAlphaReplace](https://reference.aspose.com/slides/java/com.aspose.slides/ialphareplace/) शामिल हैं, उनके निर्माण स्केलर को लिखने योग्य गुणों के रूप में नहीं दिखाते। इन सेटिंग्स को बदलने के लिए, ऑपरेशन को हटाएँ और आवश्यक स्थिति में एक प्रतिस्थापन जोड़ें।

`getEffective()` द्वारा लौटाया गया प्रभावी डेटा गणना किया गया और केवल-पढ़ने योग्य है। यह थीम-निर्भर रंगों को हल करने और रेंडरर द्वारा उपयोग किए गए सामान्यीकृत मान पढ़ने में उपयोगी है, लेकिन यह एक अतिरिक्त संपादन सतह नहीं है। निम्न उदाहरण श्रृंखला को क्रमबद्ध करता है और जहाँ संबंधित API प्रदान करती है, प्रभावी मानों की जाँच करता है:

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

ग्रेस्केल, अल्फा सीलिंग, और अल्फा इनवर्स जैसे पैरामीटर-रहित प्रभावों के पास अभी भी प्रभावी-डेटा वस्तु रहती है, लेकिन प्रिंट करने के लिए कोई स्केलर सेटिंग नहीं होती। संग्रह में उनका अस्तित्व और स्थिति ही महत्वपूर्ण जानकारी है।

## **छवि रूपांतरण हटाएँ या साफ़ करें**

[IImageTransformOperationCollection.removeAt](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#removeAt-int-) का उपयोग करके एक ऑपरेशन को इंडेक्स द्वारा हटाएँ। हटाने के बाद इंडेक्स शिफ्ट होते हैं, इसलिए पहले लक्ष्य खोजें और क्रमबद्ध करने के बाद इसे हटाएँ। पूरी श्रृंखला को हटाने के लिए [ImageTransformOperationCollection.clear](https://reference.aspose.com/slides/java/com.aspose.slides/imagetransformoperationcollection/#clear--) का उपयोग करें।

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

रूपांतरणों को हटाने या साफ़ करने से केवल चित्र फ़ॉर्मेटिंग बदलती है। यह पुन: उपयोग किए गए [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/ippimage/) संसाधन को हटाता, पुन: संपीड़ित नहीं करता, या अन्यथा बदलता नहीं है।

## **प्रस्तुति फ़ॉर्मेट और निर्यात लक्ष्यों पर विचार करें**

छवि रूपांतरण DrawingML में उत्पन्न होते हैं, इसलिए प्रभाव श्रृंखलाओं के लिए PPTX पसंदीदा संपादन योग्य फ़ॉर्मेट है। PPTX के साथ भी, सभी ऑपरेशनों की समान पोर्टेबिलिटी नहीं होती:

- मानक DrawingML ऑपरेशन्स जैसे ल्यूमिनेंस, ग्रेस्केल, ड्युटोन, टिंट, HSL, ब्लर, और सामान्य अल्फा ऑपरेशन्स PPTX राउंड-ट्रिप में जीवित रहने की सबसे अधिक संभावना रखते हैं। जब संरक्षण आवश्यक हो, तो हमेशा उत्पन्न फ़ाइल को फिर से खोलें और संग्रह की जाँच करें।
- [BrightnessContrast](https://reference.aspose.com/slides/java/com.aspose.slides/brightnesscontrast/) एक Office 2010 विस्तार है, न कि मानक DrawingML ल्यूमिनेंस ऑपरेशन। इसे मेमोरी में रेंडरिंग के लिए उपयोग किया जा सकता है, लेकिन यह सुनिश्चित नहीं है कि इसे सहेजने और PPTX को फिर से खोलने के बाद संपादन योग्य [IBrightnessContrast](https://reference.aspose.com/slides/java/com.aspose.slides/ibrightnesscontrast/) के रूप में बरकरार रखा जाएगा। स्थायी उज्जवलता और कंट्रास्ट समायोजन के लिए [addLuminanceEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addLuminanceEffect-float-float-) को प्राथमिकता दें।
- बाइनरी PPT फ़ॉर्मेट पूर्ण DrawingML प्रभाव मॉडल से पहले का है। PPT में सहेजने से असमर्थित ऑपरेशन्स छोड़े जा सकते हैं, श्रृंखला को समर्थित उपसमुच्चय तक घटाया जा सकता है, या स्वरूप का अनुमान लगाया जा सकता है। जटिल संपादन योग्य श्रृंखला के सत्यापन फ़ॉर्मेट के रूप में PPT का उपयोग न करें।
- PNG, JPEG, TIFF, PDF, SVG, HTML, या अन्य विज़ुअल आउटपुट में रेंडर करने से समर्थित श्रृंखला को रेंडर की गई उपस्थिति पर लागू किया जाता है। इन आउटपुट में संपादन योग्य `IImageTransformOperationCollection` नहीं होता; रास्टर फ़ॉर्मेट्स परिणाम को पिक्सेल में फ्लैट कर देते हैं, और दस्तावेज़/वेक्टर निर्यात अपने स्वयं के रेंडरिंग प्रतिनिधित्व को संग्रहीत करते हैं।
- प्रभाव किसी लिंक्ड छवि को स्व-समाहित नहीं बनाते। लिंक्ड चित्र को रेंडर करने के लिए प्रस्तुति लोड होने पर लिंक्ड संसाधन की उपलब्धता आवश्यक रहती है।

विभिन्न प्रस्तुति उपभोक्ता किनारे के मामलों को अलग-अलग रेंडर कर सकते हैं, विशेष रूप से जब कई अल्फा या रंग-कोटिंग ऑपरेशन्स को संयोजित किया जाता है। महत्वपूर्ण आउटपुट के लिए, उत्पादन में उपयोग किए गए समान Aspose.Slides संस्करण के साथ संपादन योग्य राउंड-ट्रिप और अंतिम निर्यात फ़ॉर्मेट दोनों की जाँच करें।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या छवि रूपांतरण प्रभाव एम्बेडेड छवि डेटा को संशोधित करते हैं?**

नहीं। ये ऑपरेशन्स चित्र भराव द्वारा उपयोग किए गए `ISlidesPicture` से संबंधित हैं। अंतर्निहित `IPPImage` बाइट्स अपरिवर्तित रहते हैं।

**क्या दो चित्र फ्रेम जो एक ही छवि को पुन: उपयोग करते हैं, अपने प्रभाव साझा करेंगे?**

नहीं। `IPPImage` को पुन: उपयोग करने से डुप्लिकेट छवि डेटा बचता है, लेकिन प्रत्येक चित्र फ्रेम आम तौर पर एक अलग `ISlidesPicture` और छवि रूपांतरण संग्रह रखता है।

**क्या रंग, ब्लर, और अल्फा प्रभावों को संयोजित किया जा सकता है?**

हां। संग्रह इन्हें एक क्रमबद्ध श्रृंखला में स्वीकार करता है। प्रत्येक ऑपरेशन पिछले के आउटपुट को क्या करता है, इस पर विचार करें क्योंकि प्रतिस्थापन और थ्रेशोल्ड ऑपरेशन्स पहले के रंग या अल्फा विवरण को हटा सकते हैं।

**प्रभावी मान क्यों केवल-पढ़ने योग्य हैं?**

प्रभावी डेटा वह गणना किए गए मान दर्शाता है जो रेंडरिंग के लिए उपयोग होते हैं, जिसमें समाधान किए गए रंग शामिल हैं। जहाँ लिखने योग्य सदस्य मौजूद हों, रूपांतरण संग्रह में संग्रहीत ऑपरेशन को संपादित करें; अन्यथा उसे हटाएँ और नए निर्माण पैरामीटर के साथ एक प्रतिस्थापन जोड़ें।

**किस फ़ॉर्मेट का उपयोग करना चाहिए ताकि एक रूपांतरण श्रृंखला बरकरार रहे?**

PPTX का उपयोग करें और फ़ाइल को पुनः खोलकर सत्यापित करें। लेगेसी PPT पूर्ण DrawingML प्रभाव मॉडल को नहीं दर्शा सकता, और रेंडर किए गए निर्यात फ़ॉर्मेट केवल उपस्थिति को बरकरार रखते हैं न कि संपादन योग्य रूपांतरण ऑपरेशन्स।