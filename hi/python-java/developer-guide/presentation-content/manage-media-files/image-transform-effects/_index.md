---
title: Python के साथ प्रस्तुतियों में इमेज ट्रांसफ़ॉर्म प्रभावों का प्रबंधन
linktitle: इमेज ट्रांसफ़ॉर्म प्रभाव
type: docs
weight: 11
url: /hi/python-java/image-transform-effects/
keywords:
- इमेज ट्रांसफ़ॉर्म
- चित्र प्रभाव
- उज्ज्वलता
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
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java के साथ चित्र फ्रेम के लिए इमेज ट्रांसफ़ॉर्म प्रभावों को लागू करें, श्रृंखला बनाएं, निरीक्षण करें, हटाएँ और सत्यापित करें।"
---
## **अवलोकन**

Aspose.Slides चित्र समायोजनों को इमेज ट्रांसफ़ॉर्म ऑपरेशन्स के क्रमबद्ध संग्रह के रूप में दर्शाता है। किसी चित्र फ्रेम के लिए, फ्रेम के [Picture](https://reference.aspose.com/slides/hi/python-java/aspose.slides/picture/) से शुरू करें और [Picture.getImageTransform](https://reference.aspose.com/slides/hi/python-java/aspose.slides/picture/#getImageTransform) को एक्सेस करें। लौटाया गया [ImageTransformOperationCollection](https://reference.aspose.com/slides/hi/python-java/aspose.slides/imagetransformoperationcollection/) आपको मूल इमेज बाइट्स को पुनः लिखे बिना प्रभाव जोड़ने, गिनने, निरीक्षण करने, हटाने और साफ़ करने की अनुमति देता है।

यह लेख उज्ज्वलता और कंट्रास्ट, रंग परिवर्तन, ब्लर, पारदर्शिता, क्रमबद्ध प्रभाव श्रृंखलाएँ, प्रभावी मान, हटाना, और PPTX राउंड‑ट्रिप सत्यापन के पूर्ण वर्कफ़्लो को दर्शाता है।

## **प्रभाव स्वामित्व और इमेज पुनः उपयोग को समझें**

एक इमेज रिसोर्स और वह चित्र जो उसे प्रदर्शित करता है अलग-अलग वस्तुएँ हैं:

- [PPImage](https://reference.aspose.com/slides/hi/python-java/aspose.slides/ppimage/) प्रस्तुति द्वारा स्वामित्व वाले स्रोत इमेज डेटा को संग्रहीत या संदर्भित करता है।
- [Picture](https://reference.aspose.com/slides/hi/python-java/aspose.slides/picture/) एक चित्र फ़िल में आता है और इमेज रिसोर्स को संदर्भित करता है जबकि इमेज ट्रांसफ़ॉर्म संग्रह संग्रहीत करता है।
- [PictureFrame](https://reference.aspose.com/slides/hi/python-java/aspose.slides/pictureframe/) स्लाइड आकृति है जो संबंधित चित्र फ़िल, ज्यामिति, क्रॉप सेटिंग्स, और अन्य फ्रेम‑स्तरीय फॉर्मेटिंग को रखता है।

इसलिए इमेज ट्रांसफ़ॉर्म ऑपरेशन्स [PPImage](https://reference.aspose.com/slides/hi/python-java/aspose.slides/ppimage/) के बाइट्स को संशोधित नहीं करते। जब वही `PPImage` को कई बार [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shapecollection/#addPictureFrame) में पास किया जाता है, तो प्रत्येक नया चित्र फ्रेम अपना स्वयं का `Picture` और अपना स्वयं का ट्रांसफ़ॉर्म संग्रह प्राप्त करता है। एक फ्रेम पर ग्रेस्केल लागू करने से अन्य फ्रेम ग्रेस्केल नहीं होते, भले ही सभी एक ही एम्बेडेड इमेज रिसोर्स को पुनः उपयोग करते हों।

उसी `Picture.getImageTransform` मॉडल का उपयोग अन्य चित्र फ़िल, जैसे आकृति या स्लाइड बैकग्राउंड, द्वारा भी किया जाता है। नीचे के उदाहरण केवल चित्र फ्रेम पर केंद्रित हैं।

## **वैध पैरामीटर सीमाएँ और इकाइयाँ उपयोग करें**

प्रदर्शित विधियों में निम्नलिखित अर्थपूर्ण सीमाएँ और इकाइयाँ उपयोग की गई हैं। इन सीमाओं के भीतर मान रखें भले ही कोई विशेष लाइब्रेरी संस्करण तुरंत सभी आउट‑ऑफ़‑रेंज मानों को अस्वीकार न करे; लक्ष्य प्रस्तुति फ़ॉर्मेट सहेजते समय या PowerPoint फ़ाइल खोलते समय अमान्य डेटा को सामान्यीकृत, हटाए या अस्वीकार कर सकता है।

| ऑपरेशन | पैरामीटर | वैध सीमा और इकाई |
|---|---|---|
| [addBrightnessContrastEffect](https://reference.aspose.com/slides/hi/python-java/aspose.slides/imagetransformoperationcollection/#addBrightnessContrastEffect) | `brightness`, `contrast` | `-100` से `100` तक, प्रतिशत; `0` घटक को अपरिवर्तित छोड़ता है। |
| [addGrayScaleEffect](https://reference.aspose.com/slides/hi/python-java/aspose.slides/imagetransformoperationcollection/#addGrayScaleEffect) | None | कोई संख्यात्मक पैरामीटर नहीं। अल्फा अपरिवर्तित रहता है। |
| [addDuotoneEffect](https://reference.aspose.com/slides/hi/python-java/aspose.slides/imagetransformoperationcollection/#addDuotoneEffect) | `color1`, `color2` | गहरे और हल्के पिक्सेल के लिए दो रंग। `java.awt.Color` में RGB और अल्फा चैनल `0` से `255` तक होते हैं। |
| [addTintEffect](https://reference.aspose.com/slides/hi/python-java/aspose.slides/imagetransformoperationcollection/#addTintEffect) | `hue`, `amount` | `hue` `0` (समावेशी) से `360` (बहिष्कृत) डिग्री में; `amount` `-100` से `100` तक, प्रतिशत। |
| [addHSLEffect](https://reference.aspose.com/slides/hi/python-java/aspose.slides/imagetransformoperationcollection/#addHSLEffect) | `hue`, `saturation`, `luminance` | `hue` `0` से `360` डिग्री; संतृप्ति और ल्यूमिनेंस `-100` से `100` तक, प्रतिशत। |
| [addColorReplaceEffect](https://reference.aspose.com/slides/hi/python-java/aspose.slides/imagetransformoperationcollection/#addColorReplaceEffect) | `color` | प्रतिस्थापन रंग के चैनल मान `0` से `255` तक। मौजूदा अल्फा मान अपरिवर्तित रहते हैं। |
| [addBlurEffect](https://reference.aspose.com/slides/hi/python-java/aspose.slides/imagetransformoperationcollection/#addBlurEffect) | `radius`, `grow` | त्रिज्या गैर‑नकारात्मक और पॉइंट में मापी जाती है; `grow` एक Boolean है जो नियंत्रित करता है कि ब्लर सामग्री मूल सीमा से बाहर विस्तार कर सकती है या नहीं। |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/hi/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaModulateFixedEffect) | `amount` | गैर‑नकारात्मक प्रतिशत। सामान्य अपारदर्शिता स्केलिंग के लिए `0` से `100` उपयोग करें: `0` पूर्णतः पारदर्शी और `100` मौजूदा अल्फा को बरकरार रखता है। |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/hi/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaReplaceEffect) | `alpha` | `0` से `100` तक, प्रतिशत अपारदर्शिता। |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/hi/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaBiLevelEffect) | `threshold` | `0` से `100` तक, प्रतिशत अल्फा थ्रेशहोल्ड। इससे नीचे के मान पारदर्शी हो जाते हैं; थ्रेशहोल्ड के बराबर या ऊपर के मान अपारदर्शी हो जाते हैं। |

स्थिर अल्फा मॉड्यूलेशन के लिए, पारदर्शिता और अपारदर्शिता आपस में पूरक होते हैं। उदाहरण के लिये, 35 % पारदर्शिता का अर्थ 65 % अल्फा मॉड्यूलेशन मात्रा होता है।

## **उज्ज्वलता और कंट्रास्ट लागू करें**

[ImageTransformOperationCollection.addBrightnessContrastEffect](https://reference.aspose.com/slides/hi/python-java/aspose.slides/imagetransformoperationcollection/#addBrightnessContrastEffect) एक [BrightnessContrast](https://reference.aspose.com/slides/hi/python-java/aspose.slides/brightnesscontrast/) ऑपरेशन लौटाता है। इसके स्केलर सेटिंग्स ऑपरेशन निर्माण के समय प्रदान की जाती हैं। [BrightnessContrast.getEffective](https://reference.aspose.com/slides/hi/python-java/aspose.slides/brightnesscontrast/#getEffective) गणना किए गए केवल‑पढ़ने‑योग्य मान लौटाता है जिन्हें निरीक्षण या लॉग किया जा सकता है।

निम्न उदाहरण उज्ज्वलता को 15 % और कंट्रास्ट को 20 % बढ़ाता है, फिर एम्बेडेड इमेज को बदले बिना एक पूर्वावलोकन रेंडर करता है:

```python
import jpype
import asposeslides
from pathlib import Path

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    image_data = Path("photo.png").read_bytes()
    image_bytes = jpype.JArray(jpype.JByte)(image_data)
    image = presentation.getImages().addImage(image_bytes)
    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 400, 260, image)

    image_transform = picture_frame.getPictureFormat().getPicture().getImageTransform()
    brightness_contrast = image_transform.addBrightnessContrastEffect(15.0, 20.0)

    effective_values = brightness_contrast.getEffective()
    print("Brightness: ", effective_values.getBrightness(), "%", sep="")
    print("Contrast: ", effective_values.getContrast(), "%", sep="")

    preview = slide.getImage()
    try:
        preview.save("brightness-contrast-preview.png", ImageFormat.Png)
    finally:
        preview.dispose()
finally:
    presentation.dispose()
```

[BrightnessContrast](https://reference.aspose.com/slides/hi/python-java/aspose.slides/brightnesscontrast/) Office 2010 चित्र‑प्रभाव विस्तार है और मानक DrawingML ल्यूमिनेंस प्रभाव से कम पोर्टेबल है। जब उज्ज्वलता और कंट्रास्ट को PPTX राउंड‑ट्रिप के बाद संपादन योग्य बनाए रखना हो, तो [ImageTransformOperationCollection.addLuminanceEffect](https://reference.aspose.com/slides/hi/python-java/aspose.slides/imagetransformoperationcollection/#addLuminanceEffect) का उपयोग करें और फ़ाइल को पुनः खोलने के बाद परिणाम सत्यापित करें। फ़ॉर्मेट सीमाएँ अनुभाग इस अंतर को अधिक विस्तार से समझाता है।

## **रंग परिवर्तन लागू करें**

रंग प्रभावों को स्वतंत्र रूप से विभिन्न चित्र फ्रेम पर लागू किया जा सकता है जो एक ही इमेज रिसोर्स को पुनः उपयोग करते हैं। निम्न उदाहरण पाँच फ्रेम बनाता है और क्रमशः ग्रेस्केल, डुओटोन, टिंट, HSL समायोजन, और रंग प्रतिस्थापन लागू करता है।

[Duotone](https://reference.aspose.com/slides/hi/python-java/aspose.slides/duotone/) दो स्वतंत्र रूप से संपादन योग्य रंग पैरामीटर रखता है: `color1` गहरे पिक्सेल को मैप करता है, जबकि `color2` हल्के पिक्सेल को। यह एक उपयोगी उदाहरण है जहाँ प्रभाव की सेटिंग्स केवल एक स्केलर मान से अधिक जटिल होती हैं।

```python
import jpype
import asposeslides
from pathlib import Path

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    image_data = Path("photo.png").read_bytes()
    image_bytes = jpype.JArray(jpype.JByte)(image_data)
    image = presentation.getImages().addImage(image_bytes)

    gray_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 180, 120, image)
    gray_frame.getPictureFormat().getPicture().getImageTransform().addGrayScaleEffect()

    duotone_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 220, 20, 180, 120, image)
    duotone = duotone_frame.getPictureFormat().getPicture().getImageTransform().addDuotoneEffect()
    duotone.getColor1().setColor(Color(0, 0, 128))
    duotone.getColor2().setColor(Color(255, 215, 0))

    tint_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 420, 20, 180, 120, image)
    tint_frame.getPictureFormat().getPicture().getImageTransform().addTintEffect(210.0, 35.0)

    hsl_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 120, 170, 180, 120, image)
    hsl_frame.getPictureFormat().getPicture().getImageTransform().addHSLEffect(30.0, 20.0, -10.0)

    replacement_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 320, 170, 180, 120, image)
    color_replacement = replacement_frame.getPictureFormat().getPicture().getImageTransform().addColorReplaceEffect()
    color_replacement.getColor().setColor(Color(100, 149, 237))

    presentation.save("color-transformations.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

[addColorReplaceEffect](https://reference.aspose.com/slides/hi/python-java/aspose.slides/imagetransformoperationcollection/#addColorReplaceEffect) प्रत्येक पिक्सेल के रंग को एक निश्चित रंग से प्रतिस्थापित करता है जबकि अल्फा को संरक्षित रखता है। यह [addColorChangeEffect](https://reference.aspose.com/slides/hi/python-java/aspose.slides/imagetransformoperationcollection/#addColorChangeEffect) से अलग है, जो एक स्रोत रंग को दूसरे में मैप करता है और दोनों स्रोत तथा लक्ष्य रंग फ़ॉर्मेट को उजागर करता है।

## **ब्लर, पारदर्शिता, और अल्फा प्रभाव जोड़ें**

[addBlurEffect](https://reference.aspose.com/slides/hi/python-java/aspose.slides/imagetransformoperationcollection/#addBlurEffect) सभी रंग चैनलों, सहित अल्फा, को प्रभावित करता है। जब ब्लर किया गया किनारा मूल चित्र सीमा से बाहर जा सकता है, तो `grow` को `True` सेट करें।

समान पारदर्शिता के लिये, [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/hi/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaModulateFixedEffect) उपयोग करें। यह प्रत्येक मौजूदा अल्फा मान को गुणा करता है, इसलिए अंशतः पारदर्शी पिक्सेल अनुपातिक रूप से अलग रहते हैं। [addAlphaReplaceEffect](https://reference.aspose.com/slides/hi/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaReplaceEffect) सभी पिक्सेल को एक ही अल्फा मान असाइन करता है। [addAlphaBiLevelEffect](https://reference.aspose.com/slides/hi/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaBiLevelEffect) थ्रेशहोल्ड के आधार पर अल्फा को दो स्तरों में बदल देता है।

```python
import jpype
import asposeslides
from pathlib import Path

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    image_data = Path("photo.png").read_bytes()
    image_bytes = jpype.JArray(jpype.JByte)(image_data)
    image = presentation.getImages().addImage(image_bytes)

    blurred_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 200, 140, image)
    blur = blurred_frame.getPictureFormat().getPicture().getImageTransform().addBlurEffect(4.5, True)
    blur.setRadius(5)

    transparent_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 240, 20, 200, 140, image)
    alpha_modulate = transparent_frame.getPictureFormat().getPicture().getImageTransform().addAlphaModulateFixedEffect(65.0)
    alpha_modulate.setAmount(60.0)

    uniform_alpha_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 180, 200, 140, image)
    uniform_alpha_frame.getPictureFormat().getPicture().getImageTransform().addAlphaReplaceEffect(55.0)

    binary_alpha_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 240, 180, 200, 140, image)
    alpha_bi_level = binary_alpha_frame.getPictureFormat().getPicture().getImageTransform().addAlphaBiLevelEffect(50.0)
    alpha_bi_level.setThreshold(45.0)
    binary_alpha_frame.getPictureFormat().getPicture().getImageTransform().addAlphaInverseEffect()

    presentation.save("blur-and-alpha-effects.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

अन्य पैरामीटर‑रहित अल्फा ऑपरेशन्स में [addAlphaCeilingEffect](https://reference.aspose.com/slides/hi/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaCeilingEffect) शामिल है, जो प्रत्येक शून्य‑से‑अधिक अल्फा को पूर्णतः अपारदर्शी बनाता है; [addAlphaFloorEffect](https://reference.aspose.com/slides/hi/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaFloorEffect) जो 100 % से नीचे के अल्फा को पूर्णतः पारदर्शी बनाता है; और [addAlphaInverseEffect](https://reference.aspose.com/slides/hi/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaInverseEffect), जो अल्फा को `100% - alpha` में बदल देता है।

## **क्रमबद्ध प्रभाव श्रृंखला बनाएं**

प्रत्येक `add...Effect` विधि संग्रह के अंत में एक नया ऑपरेशन जोड़ती है। रेंडरर संग्रह को क्रमबद्ध पाइपलाइन के रूप में उपयोग करता है: ऑपरेशन 0 का आउटपुट ऑपरेशन 1 का इनपुट बन जाता है, और इसी प्रकार आगे। इसलिए समान ऑपरेशन्स का क्रम बदलने से अलग चित्र प्राप्त हो सकता है।

उदाहरण के लिये, ग्रेस्केल के बाद टिंट पहले क्रोमैटिक जानकारी हटाता है और फिर ल्यूमिनेंस परिणाम को पुनः रंगता है। टिंट के बाद ग्रेस्केल टिंट को फिर से हटाता है। इसी प्रकार, अल्फा प्रतिस्थापन पहले के ऑपरेशन्स द्वारा गणना किए गए अल्फा मानों को अधिलेखित कर सकता है, जबकि अल्फा मॉड्यूलेशन उनके निरपेक्ष अंतर को बनाए रखता है।

निम्न उदाहरण चार‑ऑपरेशन श्रृंखला बनाता है, इसे PPTX के रूप में सहेजता है, प्रस्तुति को पुनः खोलता है, ऑपरेशन प्रकार और क्रम दोनों की जाँच करता है, और पुनः खुले परिणाम को रेंडर करता है:

```python
import jpype
import asposeslides
from pathlib import Path

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AlphaModulateFixed, Blur, GrayScale, ImageFormat, PictureFrame, Presentation, SaveFormat, ShapeType, Tint

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    image_data = Path("photo.png").read_bytes()
    image_bytes = jpype.JArray(jpype.JByte)(image_data)
    image = presentation.getImages().addImage(image_bytes)
    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 400, 260, image)

    image_transform = picture_frame.getPictureFormat().getPicture().getImageTransform()
    image_transform.addGrayScaleEffect()
    image_transform.addTintEffect(220.0, 25.0)
    image_transform.addBlurEffect(2.5, False)
    image_transform.addAlphaModulateFixedEffect(80.0)

    presentation.save("image-transform-chain.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()

reopened_presentation = Presentation("image-transform-chain.pptx")
try:
    reopened_shape = reopened_presentation.getSlides().get_Item(0).getShapes().get_Item(0)

    if isinstance(reopened_shape, PictureFrame):
        reopened_transform = reopened_shape.getPictureFormat().getPicture().getImageTransform()
        expected_types = (GrayScale, Tint, Blur, AlphaModulateFixed)
        order_is_preserved = reopened_transform.size() == len(expected_types)
        for index, expected_type in enumerate(expected_types):
            order_is_preserved = order_is_preserved and isinstance(reopened_transform.get_Item(index), expected_type)
        print("The effect chain was preserved." if order_is_preserved else "The effect chain changed during the round trip.")

        rendered_slide = reopened_presentation.getSlides().get_Item(0).getImage()
        try:
            rendered_slide.save("reopened-effect-chain.png", ImageFormat.Png)
        finally:
            rendered_slide.dispose()
    else:
        print("The reopened shape is not a picture frame.")
finally:
    reopened_presentation.dispose()
```

संग्रह कोई संगतता मैट्रिक्स लागू नहीं करता जो रंग, अल्फा, और ब्लर ऑपरेशन्स को अलग‑अलग श्रृंखलाओं तक सीमित करे। इन्हें मिलाया जा सकता है, लेकिन सभी संयोजन हमेशा उपयोगी नहीं होते। एक स्थिर रंग प्रतिस्थापन पहले के रंग प्रभावों द्वारा निर्मित RGB विविधता को हटा देता है; डुओटोन के बाद ग्रेस्केल दो चयनित रंगों को हटा देता है; और अल्फा सीलिंग, फ़्लोर, प्रतिस्थापन, या बि‑लेवल ऑपरेशन्स पहले निर्मित अल्फा विवरण को निरस्त कर सकते हैं। श्रृंखला को इच्छित पिक्सेल‑प्रसंस्करण क्रम के अनुसार बनाएं, न कि उसके आइटम्स को अनलॉजिकल फ़ॉर्मेटिंग फ़्लैग मानकर।

## **संपादन योग्य और प्रभावी मानों का निरीक्षण करें**

एक संपादन योग्य ऑपरेशन वह वस्तु है जो `Picture.getImageTransform` में संग्रहीत होती है। प्रभाव के आधार पर यह सीधे लिखने योग्य सदस्य उजागर कर सकता है। उदाहरण के लिये, [Blur](https://reference.aspose.com/slides/hi/python-java/aspose.slides/blur/) लिखने योग्य `radius` और `grow` मान प्रकट करता है, [AlphaModulateFixed](https://reference.aspose.com/slides/hi/python-java/aspose.slides/alphamodulatefixed/) लिखने योग्य `amount` प्रकट करता है, और [AlphaBiLevel](https://reference.aspose.com/slides/hi/python-java/aspose.slides/alphabilevel/) लिखने योग्य `threshold` प्रकट करता है। [Duotone](https://reference.aspose.com/slides/hi/python-java/aspose.slides/duotone/) जैसे रंग प्रभाव परिवर्तनशील [ColorFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/colorformat/) वस्तुएँ उजागर करते हैं।

कुछ ऑपरेशन क्लास, जैसे [BrightnessContrast](https://reference.aspose.com/slides/hi/python-java/aspose.slides/brightnesscontrast/), [HSL](https://reference.aspose.com/slides/hi/python-java/aspose.slides/hsl/), [Tint](https://reference.aspose.com/slides/hi/python-java/aspose.slides/tint/), और [AlphaReplace](https://reference.aspose.com/slides/hi/python-java/aspose.slides/alphareplace/), अपने निर्माण स्केलर को लिखने योग्य गुणों के रूप में उजागर नहीं करते। इन सेटिंग्स को बदलने के लिए ऑपरेशन को हटाएँ और आवश्यक स्थिति में एक नया जोड़ें।

`getEffective` द्वारा लौटाया गया प्रभावी डेटा गणना किया गया और केवल‑पढ़ने‑योग्य होता है। यह थीम‑निर्भर रंगों को हल करने और रेंडरर द्वारा उपयोग किए गए सामान्यीकृत मान पढ़ने में उपयोगी है, लेकिन यह कोई अतिरिक्त संपादन सतह नहीं है। निम्न उदाहरण श्रृंखला को गिनती करता है और जहाँ सम्बंधित API प्रभावी मान प्रदान करती है, उनका निरीक्षण करता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AlphaBiLevel, AlphaModulateFixed, AlphaReplace, Blur, BrightnessContrast, ColorReplace, Duotone, HSL, Luminance, PictureFrame, Presentation, Tint

presentation = Presentation("image-transform-chain.pptx")
try:
    picture_frame = None

    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        image_transform = picture_frame.getPictureFormat().getPicture().getImageTransform()

        for index in range(image_transform.size()):
            operation = image_transform.get_Item(index)
            print(index, ": ", operation.getClass().getSimpleName(), sep="")

            if isinstance(operation, BrightnessContrast):
                data = operation.getEffective()
                print("  Brightness: ", data.getBrightness(), sep="")
                print("  Contrast: ", data.getContrast(), sep="")
            elif isinstance(operation, Luminance):
                data = operation.getEffective()
                print("  Brightness: ", data.getBrightness(), sep="")
                print("  Contrast: ", data.getContrast(), sep="")
            elif isinstance(operation, Duotone):
                data = operation.getEffective()
                print("  Dark color: ", data.getColor1(), sep="")
                print("  Light color: ", data.getColor2(), sep="")
            elif isinstance(operation, ColorReplace):
                data = operation.getEffective()
                print("  Replacement color: ", data.getColor(), sep="")
            elif isinstance(operation, HSL):
                data = operation.getEffective()
                print("  HSL: ", data.getHue(), ", ", data.getSaturation(), ", ", data.getLuminance(), sep="")
            elif isinstance(operation, Tint):
                data = operation.getEffective()
                print("  Tint: ", data.getHue(), ", ", data.getAmount(), sep="")
            elif isinstance(operation, Blur):
                data = operation.getEffective()
                print("  Blur radius: ", data.getRadius(), " pt", sep="")
            elif isinstance(operation, AlphaModulateFixed):
                data = operation.getEffective()
                print("  Alpha amount: ", data.getAmount(), "%", sep="")
            elif isinstance(operation, AlphaReplace):
                data = operation.getEffective()
                print("  Replacement alpha: ", data.getAlpha(), "%", sep="")
            elif isinstance(operation, AlphaBiLevel):
                data = operation.getEffective()
                print("  Alpha threshold: ", data.getThreshold(), "%", sep="")
finally:
    presentation.dispose()
```

बिना पैरामीटर वाले प्रभाव जैसे ग्रेस्केल, अल्फा सीलिंग, और अल्फा इनवर्स भी एक प्रभावी‑डेटा वस्तु रखते हैं, लेकिन प्रिंट करने हेतु कोई स्केलर सेटिंग नहीं होती। उनका अस्तित्व और संग्रह में स्थिति ही महत्वपूर्ण जानकारी है।

## **इमेज ट्रांसफ़ॉर्म हटाएँ या साफ़ करें**

एक ऑपरेशन को इंडेक्स द्वारा हटाने के लिए [ImageTransformOperationCollection.removeAt](https://reference.aspose.com/slides/hi/python-java/aspose.slides/imagetransformoperationcollection/#removeAt) का उपयोग करें। हटाने के बाद इंडेक्स शिफ्ट होते हैं, इसलिए पहले लक्ष्य को खोजें और गिनती के बाद हटाएँ। पूरी श्रृंखला को हटाने के लिये [ImageTransformOperationCollection.clear](https://reference.aspose.com/slides/hi/python-java/aspose.slides/imagetransformoperationcollection/#clear) का उपयोग करें।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Blur, PictureFrame, Presentation, SaveFormat

presentation = Presentation("image-transform-chain.pptx")
try:
    picture_frame = None

    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        image_transform = picture_frame.getPictureFormat().getPicture().getImageTransform()
        blur_index = -1

        for index in range(image_transform.size()):
            if isinstance(image_transform.get_Item(index), Blur):
                blur_index = index
                break

        if blur_index >= 0:
            image_transform.removeAt(blur_index)
            print("The blur operation was removed.")

        image_transform.clear()
        print("Remaining operations: ", image_transform.size(), sep="")
        presentation.save("image-transforms-cleared.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

ट्रांसफ़ॉर्म हटाने या साफ़ करने से केवल चित्र फॉर्मेटिंग बदलती है। यह पुनः उपयोग किए गए [PPImage](https://reference.aspose.com/slides/hi/python-java/aspose.slides/ppimage/) रिसोर्स को हटाता, पुनः‑संकुचित या अन्यथा नहीं बदलता।

## **प्रेज़ेंटेशन फ़ॉर्मेट और निर्यात लक्ष्य पर विचार करें**

इमेज ट्रांसफ़ॉर्म DrawingML में उत्पन्न होते हैं, इसलिए PPTX प्रभाव श्रृंखलाओं के लिये वांछित संपादन योग्य फ़ॉर्मेट है। PPTX के साथ भी, सभी ऑपरेशन्स की पोर्टेबिलिटी समान नहीं है:

- मानक DrawingML ऑपरेशन्स जैसे ल्यूमिनेंस, ग्रेस्केल, डुओटोन, टिंट, HSL, ब्लर, और सामान्य अल्फा ऑपरेशन्स PPTX राउंड‑ट्रिप के दौरान जीवित रहने की सबसे अधिक संभावना रखते हैं। निरंतरता आवश्यक होने पर हमेशा निर्मित फ़ाइल को पुनः खोलें और संग्रह का निरीक्षण करें।
- [BrightnessContrast](https://reference.aspose.com/slides/hi/python-java/aspose.slides/brightnesscontrast/) Office 2010 विस्तार है, मानक DrawingML ल्यूमिनेंस ऑपरेशन नहीं। यह इन‑मेमोरी रेंडरिंग के लिये उपयोगी है, लेकिन सहेजने और PPTX को पुनः खोलने के बाद संपादन योग्य [BrightnessContrast](https://reference.aspose.com/slides/hi/python-java/aspose.slides/brightnesscontrast/) के रूप में बना रहना गारंटी नहीं है। स्थायी उज्ज्वलता‑कंट्रास्ट समायोजन के लिये [addLuminanceEffect](https://reference.aspose.com/slides/hi/python-java/aspose.slides/imagetransformoperationcollection/#addLuminanceEffect) को प्राथमिकता दें।
- बाइनरी PPT फ़ॉर्मेट पूर्ण DrawingML प्रभाव मॉडल से पूर्वी है। PPT में सहेजने से असमर्थित ऑपरेशन्स को छोड़ दिया जा सकता है, श्रृंखला को समर्थित उपसमुच्चय तक घटित किया जा सकता है, या उपस्थिति का अनुमान लगाया जा सकता है। जटिल संपादन योग्य श्रृंखला के लिये PPT को सत्यापन फ़ॉर्मेट के रूप में उपयोग न करें।
- PNG, JPEG, TIFF, PDF, SVG, HTML, या अन्य दृश्य आउटपुट में समर्थित श्रृंखला को रेंडर किया जाता है। ये आउटपुट संपादन योग्य `ImageTransformOperationCollection` नहीं रखते; रास्टर फ़ॉर्मेट परिणाम को पिक्सेल में फ़्लैटन कर देते हैं, और डॉक्यूमेंट/वेक्टर निर्यात अपने स्वयं के रेंडरिंग प्रतिनिधित्व को संग्रहीत करते हैं।
- प्रभाव किसी लिंक्ड इमेज को स्व-समाहित नहीं बनाते। लिंक्ड चित्र को रेंडर करने के लिये लिंक्ड रिसोर्स उपलब्ध होना आवश्यक रहता है जब प्रस्तुति लोड होती है।

विभिन्न प्रस्तुति उपभोक्ता किनारे के मामलों को अलग‑अलग रेंडर कर सकते हैं, विशेषकर जब कई अल्फा या रंग‑क्वांटाइज़िंग ऑपरेशन्स को संयोजित किया गया हो। महत्वपूर्ण आउटपुट के लिये, उत्पादन में उपयोग किए गए वही Aspose.Slides संस्करण के साथ संपादन योग्य राउंड‑ट्रिप और अंतिम निर्यात फ़ॉर्मेट दोनों का परीक्षण करें।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या इमेज ट्रांसफ़ॉर्म प्रभाव एम्बेडेड इमेज डेटा को बदलते हैं?**

नहीं। ऑपरेशन्स `Picture` से संबंधित होते हैं जो चित्र फ़िल द्वारा उपयोग किया जाता है। आधारभूत `PPImage` बाइट्स अपरिवर्तित रहती हैं।

**क्या दो चित्र फ्रेम जो एक ही इमेज को पुनः उपयोग करते हैं, प्रभाव साझा करेंगे?**

नहीं। एक `PPImage` को पुनः उपयोग करने से इमेज डेटा की डुप्लिकेशन नहीं होती, लेकिन प्रत्येक चित्र फ्रेम आमतौर पर अलग `Picture` और अलग इमेज ट्रांसफ़ॉर्म संग्रह रखता है।

**क्या रंग, ब्लर, और अल्फा प्रभावों को एक साथ संयोजित किया जा सकता है?**

हाँ। संग्रह उन्हें एक क्रमबद्ध श्रृंखला में स्वीकार करता है। प्रत्येक ऑपरेशन के पिछले आउटपुट पर प्रभाव को समझें, क्योंकि प्रतिस्थापन और थ्रेशहोल्ड ऑपरेशन्स पहले के रंग या अल्फा विवरण को हटा सकते हैं।

**प्रभावी मान केवल‑पढ़ने‑योग्य क्यों होते हैं?**

प्रभावी डेटा रेंडरिंग के लिये प्रयुक्त गणना किए गए मानों का प्रतिनिधित्व करता है, जिसमें हल किए गए रंग शामिल हैं। जहाँ लिखने योग्य सदस्य मौजूद हों, ट्रांसफ़ॉर्म संग्रह में संग्रहीत ऑपरेशन को संपादित करें; अन्यथा उसे हटाएँ और नई निर्माण पैरामीटर के साथ एक प्रतिस्थापन जोड़ें।

**कौन सा फ़ॉर्मेट ट्रांसफ़ॉर्म श्रृंखला को संरक्षित रखने के लिये उपयोग करना चाहिए?**

PPTX का उपयोग करें और फ़ाइल को पुनः खोलकर सत्यापित करें। लिगेसी PPT पूर्ण DrawingML प्रभाव मॉडल को प्रदर्शित नहीं कर सकता, और रेंडर किए गए निर्यात फ़ॉर्मेट केवल उपस्थिति को संरक्षित करते हैं, न कि संपादन योग्य ट्रांसफ़ॉर्म ऑपरेशन्स।