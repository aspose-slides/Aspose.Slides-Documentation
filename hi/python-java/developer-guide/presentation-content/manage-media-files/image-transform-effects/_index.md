---
title: Presentations में Python के साथ Image Transform Effects प्रबंधित करें
linktitle: इमेज ट्रांसफ़ॉर्म इफ़ेक्ट्स
type: docs
weight: 11
url: /hi/python-java/image-transform-effects/
keywords:
- इमेज ट्रांसफ़ॉर्म
- पिक्चर इफ़ेक्ट
- चमक
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
- PowerPoint
- प्रस्तुति
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java के साथ चित्र फ्रेम के लिए इमेज ट्रांसफ़ॉर्म इफ़ेक्ट्स को लागू करें, क्रमबद्ध करें, निरीक्षण करें, हटाएँ, और सत्यापित करें।"
---
## **परिचय**

Aspose.Slides चित्र समायोजन को इमेज ट्रांसफ़ॉर्म ऑपरेशनों के क्रमबद्ध संग्रह के रूप में दर्शाता है। एक चित्र फ्रेम के लिए, फ्रेम के [Picture](https://reference.aspose.com/slides/python-java/aspose.slides/picture/) से शुरू करें और [Picture.getImageTransform](https://reference.aspose.com/slides/python-java/aspose.slides/picture/#getImageTransform) तक पहुँचें। लौटाया गया [ImageTransformOperationCollection](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/) आपको प्रभावों को जोड़ने, गिनने, निरीक्षण करने, हटाने और साफ़ करने की अनुमति देता है बिना मूल छवि बाइट्स को फिर से लिखे।

यह लेख चमक और कंट्रास्ट, रंग रूपांतरण, ब्लर, पारदर्शिता, क्रमबद्ध प्रभाव शृंखलाएँ, प्रभावी मान, हटाना, और PPTX राउंड-ट्रिप सत्यापन के लिए एक पूर्ण कार्यप्रवाह दर्शाता है।

## **इफ़ेक्ट स्वामित्व और छवि पुन: उपयोग को समझें**

एक छवि संसाधन और वह चित्र जो इसे प्रदर्शित करता है अलग-अलग वस्तुएँ हैं:

- [PPImage](https://reference.aspose.com/slides/python-java/aspose.slides/ppimage/) प्रस्तुति द्वारा स्वामित्व वाले स्रोत छवि डेटा को संग्रहीत या संदर्भित करता है।
- [Picture](https://reference.aspose.com/slides/python-java/aspose.slides/picture/) एक चित्र फ़िल में आता है और एक छवि संसाधन को संदर्भित करता है जबकि इमेज ट्रांसफ़ॉर्म संग्रह को संग्रहीत करता है।
- [PictureFrame](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframe/) वह स्लाइड आकार है जो संबंधित चित्र फ़िल, ज्यामिति, क्रॉप सेटिंग्स और अन्य फ्रेम-स्तरीय स्वरूपण को धारण करता है।

इसलिए, इमेज ट्रांसफ़ॉर्म ऑपरेशन्स [PPImage](https://reference.aspose.com/slides/python-java/aspose.slides/ppimage/) में बाइट्स को संशोधित नहीं करते हैं। जब वही `PPImage` को [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addPictureFrame) को एक से अधिक बार पास किया जाता है, तो प्रत्येक नया चित्र फ्रेम अपना स्वयं का `Picture` और अपना स्वयं का ट्रांसफ़ॉर्म संग्रह प्राप्त करता है। एक फ्रेम पर ग्रेस्केल लागू करने से अन्य फ्रेम ग्रेस्केल नहीं होते, भले ही सभी एक ही एम्बेडेड छवि संसाधन को पुन: उपयोग करें।

एक ही `Picture.getImageTransform` मॉडल का उपयोग अन्य चित्र फ़िल, जैसे आकार या स्लाइड पृष्ठभूमि, द्वारा भी किया जाता है। नीचे के उदाहरण चित्र फ्रेम पर केंद्रित हैं।

## **मान्य पैरामीटर रेंज और इकाइयों का उपयोग करें**

प्रदर्शित विधियों में निम्नलिखित सेमांटिक रेंज और इकाइयों का उपयोग किया जाता है। इन रेंज में मान रखें भले ही कोई विशिष्ट लाइब्रेरी संस्करण तुरंत सभी असंगत मानों को नकारे; लक्ष्य प्रस्तुति स्वरूप सहेजे जाने या PowerPoint द्वारा फ़ाइल खोलते समय डेटा को सामान्यीकृत, छोड़ या अस्वीकृत कर सकता है।

| ऑपरेशन | पैरामीटर | वैध रेंज और इकाई |
|---|---|---|
| [addBrightnessContrastEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addBrightnessContrastEffect) | `brightness`, `contrast` | `-100` से `100` तक, प्रतिशत; `0` घटक को अपरिवर्तित छोड़ता है। |
| [addGrayScaleEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addGrayScaleEffect) | None | कोई संख्यात्मक पैरामीटर नहीं। अल्फा अपरिवर्तित रहता है। |
| [addDuotoneEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addDuotoneEffect) | `color1`, `color2` | डार्क और लाइट पिक्सेल के लिए दो रंग। `java.awt.Color` में RGB और अल्फा चैनल `0` से `255` तक उपयोग होते हैं। |
| [addTintEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addTintEffect) | `hue`, `amount` | ह्यू `0` (समावेशी) से `360` (अपवर्जित) तक, डिग्री में; मात्रा `-100` से `100` तक, प्रतिशत। |
| [addHSLEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addHSLEffect) | `hue`, `saturation`, `luminance` | ह्यू `0` (समावेशी) से `360` (अपवर्जित) तक, डिग्री में; संतृप्ति और ल्यूमिनेंस `-100` से `100` तक, प्रतिशत। |
| [addColorReplaceEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addColorReplaceEffect) | `color` | परिवर्तन रंग `0` से `255` तक चैनल मानों का उपयोग करता है। मौजूदा अल्फा मान अपरिवर्तित रहते हैं। |
| [addBlurEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addBlurEffect) | `radius`, `grow` | रेडियस गैर-नकारात्मक है और पॉइंट में मापा जाता है; `grow` एक बूलियन है जो नियंत्रित करता है कि ब्लर किया गया कंटेंट मूल सीमा से बाहर विस्तारित हो सकता है या नहीं। |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaModulateFixedEffect) | `amount` | गैर-नकारात्मक प्रतिशत। सामान्य अपारदर्शिता स्केलिंग के लिए `0` से `100` का प्रयोग करें: `0` पूर्णतः पारदर्शी है और `100` मौजूदा अल्फा को बरकरार रखता है। |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaReplaceEffect) | `alpha` | `0` से `100` तक, प्रतिशत अपारदर्शिता। |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaBiLevelEffect) | `threshold` | `0` से `100` तक, प्रतिशत अल्फा थ्रेसहोल्ड। इसके नीचे के मान पारदर्शी हो जाते हैं; इस या इससे ऊपर के मान अपारदर्शी हो जाते हैं। |

निश्चित अल्फा मॉड्यूलेशन के लिए, पारदर्शिता और अपारदर्शिता प्रतिपूरक होते हैं। उदाहरण के लिए, 35% पारदर्शिता अल्फा मॉड्यूलेशन मात्रा 65% के बराबर है।

## **चमक और कंट्रास्ट लागू करें**

[ImageTransformOperationCollection.addBrightnessContrastEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addBrightnessContrastEffect) एक [BrightnessContrast](https://reference.aspose.com/slides/python-java/aspose.slides/brightnesscontrast/) ऑपरेशन लौटाता है। इसके स्केलर सेटिंग्स ऑपरेशन बनते समय प्रदान किए जाते हैं। [BrightnessContrast.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/brightnesscontrast/#getEffective) गणना किए गए केवल-पढ़ने योग्य मूल्यों को लौटाता है जिन्हें निरीक्षण या लॉग किया जा सकता है।

निम्न उदाहरण चमक को 15% और कंट्रास्ट को 20% बढ़ाता है, फिर एम्बेडेड छवि को संशोधित किए बिना एक पूर्वावलोकन रेंडर करता है:

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

[BrightnessContrast](https://reference.aspose.com/slides/python-java/aspose.slides/brightnesscontrast/) Office 2010 का चित्र‑इफ़ेक्ट विस्तार है और मानक DrawingML ल्यूमिनेंस इफ़ेक्ट से कम पोर्टेबल है। जब चमक और कंट्रास्ट को PPTX राउंड‑ट्रिप के बाद भी संपादन योग्य रहना हो, तो [ImageTransformOperationCollection.addLuminanceEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addLuminanceEffect) का उपयोग करें और फ़ाइल को पुनः खोलने के बाद परिणाम सत्यापित करें। फ़ॉर्मेट प्रतिबंध अनुभाग इस अंतर को अधिक विस्तार से समझाता है।

## **रंग रूपांतरण लागू करें**

रंग प्रभाव एक ही छवि संसाधन को पुन: उपयोग करने वाले विभिन्न चित्र फ्रेम पर स्वतंत्र रूप से लागू किए जा सकते हैं। निम्न उदाहरण पाँच फ्रेम बनाता है और ग्रेस्केल, डुओटोन, टिंट, HSL समायोजन, और रंग प्रतिस्थापन लागू करता है।

[Duotone](https://reference.aspose.com/slides/python-java/aspose.slides/duotone/) दो स्वतंत्र रूप से संपादन योग्य रंग पैरामीटर रखता है: `color1` डार्क पिक्सेल को मैप करता है, जबकि `color2` लाइट पिक्सेल को मैप करता है। यह एक ऐसा प्रभाव का उपयोगी उदाहरण बनाता है जिसकी सेटिंग्स एकल स्केलर मान से अधिक जटिल होती हैं।

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

[addColorReplaceEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addColorReplaceEffect) प्रत्येक पिक्सेल के रंग को एक स्थिर रंग से बदल देता है जबकि अल्फा को बरकरार रखता है। यह [addColorChangeEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addColorChangeEffect) से अलग है, जो एक स्रोत रंग को दूसरे में मैप करता है और दोनों स्रोत और लक्ष्य रंग स्वरूप दिखाता है।

### **ल्यूमिनेंस थ्रेसहोल्ड लागू करें**

एक ल्यूमिनेंस थ्रेसहोल्ड स्कैन किए गए पृष्ठ पर हल्की निशानों को पृष्ठभूमि से अलग करने में मदद कर सकता है। [addGrayScaleEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addGrayScaleEffect) मध्यवर्ती ग्रे शेड्स को बरकरार रखता है। [addBiLevelEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addBiLevelEffect) ल्यूमिनेंस को काले या सफेद में मैप करता है, जबकि [addAlphaBiLevelEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaBiLevelEffect) अपारदर्शिता पर थ्रेसहोल्ड लागू करता है।

ल्यूमिनेंस थ्रेसहोल्ड 0% से 100% तक, समावेशी, रहता है। थ्रेसहोल्ड से नीचे के पिक्सेल काले हो जाते हैं। थ्रेसहोल्ड पर या उससे ऊपर के पिक्सेल सफेद हो जाते हैं। थ्रेसहोल्ड बढ़ाने से अधिक शेड्स काले हो जाते हैं क्योंकि अधिक पिक्सेल कटऑफ़ से नीचे गिरते हैं।

[grayscale-swatches.png](grayscale-swatches.png) को कार्य निर्देशिका में डाउनलोड करें। प्रत्येक लेबल 0 से 255 की स्केल पर मूल ग्रे स्तर दर्शाता है। उदाहरण मूल को दो प्रतियों के बगल में रखता है और प्रत्येक प्रतिलिपि का थ्रेसहोल्ड प्रस्तुति में सहेजता है।

```python
import jpype
import asposeslides
from pathlib import Path

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType, SlideSizeScaleType

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(720.0, 150.0, SlideSizeScaleType.DoNotScale)
    shapes = presentation.getSlides().get_Item(0).getShapes()

    image_data = Path("grayscale-swatches.png").read_bytes()
    image_bytes = jpype.JArray(jpype.JByte)(image_data)
    image = presentation.getImages().addImage(image_bytes)

    frames = []
    for index, caption in enumerate(("Original", "Threshold 20%", "Threshold 60%")):
        x = 12 + 240 * index
        label = shapes.addAutoShape(ShapeType.Rectangle, x, 12, 216, 36)
        label.getTextFrame().setText(caption)
        frame = shapes.addPictureFrame(ShapeType.Rectangle, x, 60, 216, 72, image)
        frames.append(frame)

    frames[1].getPictureFormat().getPicture().getImageTransform().addBiLevelEffect(20.0)
    frames[2].getPictureFormat().getPicture().getImageTransform().addBiLevelEffect(60.0)

    presentation.save("luminance-threshold.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

आउटपुट प्रस्तुति को PowerPoint में खोलें ताकि तीन फ्रेम की तुलना की जा सके। 96 लेबल वाला स्वैच लगभग 38% ल्यूमिनेंस (255 में से 96) है। यह 20% थ्रेसहोल्ड पर सफेद और 60% थ्रेसहोल्ड पर काला हो जाता है।

![असली ग्रेस्केल स्वैचेज़ ल्यूमिनेंस थ्रेसहोल्ड 20% और 60% पर काले-सफेद परिणामों के बगल में](luminance-threshold.png)

## **ब्लर, पारदर्शिता, और अल्फा इफ़ेक्ट जोड़ें**

[addBlurEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addBlurEffect) सभी रंग चैनलों को प्रभावित करता है, जिसमें अल्फा भी शामिल है। जब ब्लर किया गया किनारा मूल चित्र सीमाओं से बाहर विस्तार कर सकता है, तो `grow` को `True` सेट करें।

समान पारदर्शिता के लिए, [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaModulateFixedEffect) का उपयोग करें। यह प्रत्येक मौजूदा अल्फा मान को गुणा करता है, इसलिए आंशिक रूप से पारदर्शी पिक्सेल अनुपातिक रूप से अलग रहते हैं। [addAlphaReplaceEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaReplaceEffect) सभी पिक्सेल को एक अल्फा मान सौंपता है। [addAlphaBiLevelEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaBiLevelEffect) थ्रेसहोल्ड के आधार पर अल्फा को दो स्तरों में बदलता है।

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

अन्य पैरामीटर‑रहित अल्फा ऑपरेशन्स में [addAlphaCeilingEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaCeilingEffect) शामिल है, जो प्रत्येक गैर‑शून्य अल्फा को पूर्णतः अपारदर्शी बनाता है; [addAlphaFloorEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaFloorEffect), जो 100% से नीचे के सभी अल्फा को पूर्णतः पारदर्शी बनाता है; और [addAlphaInverseEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaInverseEffect), जो अल्फा को `100% - alpha` में बदलता है।

## **एक क्रमबद्ध इफ़ेक्ट चेन बनाएं**

हर `add...Effect` मेथड संग्रह के अंत में एक नया ऑपरेशन जोड़ता है। रेंडरर संग्रह को क्रमबद्ध पाइपलाइन के रूप में उपयोग करता है: ऑपरेशन 0 का आउटपुट ऑपरेशन 1 का इनपुट बन जाता है, और इसी प्रकार। परिणामस्वरूप, समान ऑपरेशन्स को अलग क्रम में रखने से अलग छवि बन सकती है।

उदाहरण के लिए, ग्रेस्केल के बाद टिंट पहले क्रोमैटिक जानकारी हटाता है और फिर ल्यूमिनेंस परिणाम को पुनः रंगित करता है। टिंट के बाद ग्रेस्केल टिंट को फिर से हटा देता है। इसी प्रकार, अल्फा प्रतिस्थापन पहले के ऑपरेशन्स द्वारा गणना किए गए अल्फा मानों को ओवरराइड कर सकता है, जबकि अल्फा मॉड्यूलेशन उनके सापेक्ष अंतर को बरकरार रखता है।

निम्न उदाहरण चार‑ऑपरेशन चेन बनाता है, इसे PPTX के रूप में सहेजता है, प्रस्तुति को पुनः खोलता है, ऑपरेशन प्रकार और क्रम दोनों की जाँच करता है, और पुनः खुले परिणाम को रेंडर करता है:

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

संग्रह कोई संगतता मैट्रिक्स नहीं लागू करता जो रंग, अल्फा और ब्लर ऑपरेशन्स को अलग-अलग चेन तक सीमित करता हो। इन्हें संयोजित किया जा सकता है, लेकिन संयोजन हमेशा उपयोगी नहीं होते। एक स्थिर रंग प्रतिस्थापन पहले के रंग प्रभावों द्वारा उत्पन्न RGB विविधता को हटा देता है; डुओटोन के बाद ग्रेस्केल दो चयनित रंगों को हटा देता है; और अल्फा सीलिंग, फ़्लोर, प्रतिस्थापन, या बाय‑लेवल ऑपरेशन्स पहले निर्मित अल्फा विवरण को हटा सकते हैं। चेन को इच्छित पिक्सेल‑प्रसंस्करण क्रम के अनुसार बनाएं, न कि इसके आइटम को अनऑर्डर्ड फ़ॉर्मेटिंग फ्लैग मानकर।

<!-- visual-explanation:image-transform-effects:start -->
[![एक ही छवि पहले ग्रेस्केल फिर टिंट, और टिंट फिर ग्रेस्केल से गुजरती है। दो अंतिम ग्रेस्केल छवियों में अलग टोन हैं।](visual-image-transform-effects-49aa72211f3a.svg)](visual-image-transform-effects-49aa72211f3a.svg)
<!-- visual-explanation:image-transform-effects:end -->

## **संपादन योग्य और प्रभावी मानों की जाँच करें**

एक संपादन योग्य ऑपरेशन वह ऑब्जेक्ट है जो `Picture.getImageTransform` में संग्रहीत होता है। प्रभाव के अनुसार, यह सीधे लिखने योग्य सदस्य उजागर कर सकता है। उदाहरण के लिए, [Blur](https://reference.aspose.com/slides/python-java/aspose.slides/blur/) लिखने योग्य `radius` और `grow` मान दिखाता है, [AlphaModulateFixed](https://reference.aspose.com/slides/python-java/aspose.slides/alphamodulatefixed/) लिखने योग्य `amount` दिखाता है, और [AlphaBiLevel](https://reference.aspose.com/slides/python-java/aspose.slides/alphabilevel/) लिखने योग्य `threshold` दिखाता है। रंग प्रभाव जैसे [Duotone](https://reference.aspose.com/slides/python-java/aspose.slides/duotone/) परिवर्तनशील [ColorFormat](https://reference.aspose.com/slides/python-java/aspose.slides/colorformat/) ऑब्जेक्ट्स को उजागर करते हैं।

कुछ ऑपरेशन क्लासेज़, जैसे [BrightnessContrast](https://reference.aspose.com/slides/python-java/aspose.slides/brightnesscontrast/), [HSL](https://reference.aspose.com/slides/python-java/aspose.slides/hsl/), [Tint](https://reference.aspose.com/slides/python-java/aspose.slides/tint/), और [AlphaReplace](https://reference.aspose.com/slides/python-java/aspose.slides/alphareplace/), अपने निर्माण स्केलर को लिखने योग्य प्रॉपर्टीज़ के रूप में नहीं दिखाते। इन सेटिंग्स को बदलने के लिए, ऑपरेशन को हटाएँ और आवश्यक स्थिति में प्रतिस्थापन जोड़ें।

`getEffective` द्वारा लौटाया गया प्रभावी डेटा गणना किया गया और केवल‑पढ़ने योग्य है। यह थीम‑निर्भर रंगों को हल करने और रेंडरर द्वारा उपयोग किए गए सामान्यीकृत मानों को पढ़ने में उपयोगी है, लेकिन यह कोई अन्य संपादन सतह नहीं है। निम्न उदाहरण चेन को गिनता है और जहाँ संबंधित API प्रभावी मान प्रदान करती है, उन मानों की जाँच करता है:

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

ग्रेस्केल, अल्फा सीलिंग, और अल्फा इनवर्स जैसे पैरामीटर‑रहित प्रभावों के पास अभी भी एक प्रभावी‑डेटा ऑब्जेक्ट होता है, लेकिन प्रिंट करने के लिए कोई स्केलर सेटिंग नहीं होती। संग्रह में उनकी उपस्थिति और स्थिति ही महत्वपूर्ण जानकारी होते हैं।

## **छवि ट्रांसफ़ॉर्म हटाएँ या साफ़ करें**

एक ऑपरेशन को सूचकांक द्वारा हटाने के लिए [ImageTransformOperationCollection.removeAt](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#removeAt) का उपयोग करें। क्योंकि हटाने के बाद सूचकांक बदलते हैं, पहले लक्ष्य को खोजें और गिनती के बाद इसे हटाएँ। संपूर्ण चेन को हटाने के लिए [ImageTransformOperationCollection.clear](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#clear) का उपयोग करें।

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

ट्रांसफ़ॉर्म को हटाने या साफ़ करने से केवल चित्र स्वरूपण बदलता है। यह पुनः उपयोग किए गए [PPImage](https://reference.aspose.com/slides/python-java/aspose.slides/ppimage/) संसाधन को हटाता, पुनः संपीड़ित नहीं करता, या अन्यथा नहीं बदलता।

## **प्रस्तुति स्वरूप और निर्यात लक्ष्यों पर विचार करें**

इमेज ट्रांसफ़ॉर्म DrawingML में उत्पन्न होते हैं, इसलिए PPTX प्रभाव चेन के लिए पसंदीदा संपादन योग्य स्वरूप है। PPTX के साथ भी, हर ऑपरेशन की पोर्टेबिलिटी समान नहीं होती:

- ल्यूमिनेंस, ग्रेस्केल, डुओटोन, टिंट, HSL, ब्लर, और सामान्य अल्फा ऑपरेशन्स जैसे मानक DrawingML ऑपरेशन्स के PPTX राउंड‑ट्रिप में जीवित रहने की सबसे अधिक संभावना होती है। जब संरक्षण आवश्यक हो, हमेशा उत्पन्न फ़ाइल को पुनः खोलें और संग्रह की जाँच करें।
- [BrightnessContrast](https://reference.aspose.com/slides/python-java/aspose.slides/brightnesscontrast/) एक Office 2010 विस्तार है न कि मानक DrawingML ल्यूमिनेंस ऑपरेशन। इसे मेमोरी‑में रेंडरिंग के लिए उपयोग किया जा सकता है, लेकिन सहेजने और PPTX को पुनः खोलने के बाद यह संपादन योग्य [BrightnessContrast](https://reference.aspose.com/slides/python-java/aspose.slides/brightnesscontrast/) के रूप में रहने की गारंटी नहीं है। निरंतर चमक और कंट्रास्ट समायोजन के लिए [addLuminanceEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addLuminanceEffect) को प्राथमिकता दें।
- बाइनरी PPT स्वरूप पूर्ण DrawingML इफ़ेक्ट मॉडल से पहले का है। PPT में सहेजने से असमर्थित ऑपरेशन्स छोड़ सकते हैं, चेन को समर्थित उपसमुच्चय तक घटा सकते हैं, या दिखावट को अनुमानित कर सकते हैं। जटिल संपादन योग्य चेन के सत्यापन स्वरूप के रूप में PPT का उपयोग न करें।
- PNG, JPEG, TIFF, PDF, SVG, HTML, या अन्य विज़ुअल आउटपुट में रेंडरिंग समर्थित चेन को रेंडर किए गए रूप में लागू करता है। उन आउटपुट में कोई संपादन योग्य `ImageTransformOperationCollection` नहीं होता; रास्टर स्वरूप परिणाम को पिक्सेल में फ्लैट कर देते हैं, तथा दस्तावेज़/वेक्टर निर्यात अपना स्वयं का रेंडरिंग प्रतिनिधित्व संग्रहीत करते हैं।
- इफ़ेक्ट्स किसी लिंक्ड इमेज को स्वनिहित नहीं बनाते। लिंक्ड चित्र को रेंडर करने के लिए प्रस्तुति लोड होने पर लिंक्ड संसाधन उपलब्ध होना आवश्यक है।

विभिन्न प्रस्तुति उपभोक्ता किनारे मामलों को अलग ढंग से रेंडर कर सकते हैं, विशेषकर जब कई अल्फा या रंग‑क्वांटाइज़िंग ऑपरेशन्स संयोजित हों। महत्वपूर्ण आउटपुट के लिए, उत्पादन में उपयोग किए गए समान Aspose.Slides संस्करण के साथ दोनों संपादन योग्य राउंड‑ट्रिप और अंतिम निर्यात स्वरूप का परीक्षण करें।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या इमेज ट्रांसफ़ॉर्म इफ़ेक्ट्स एम्बेडेड इमेज डेटा को संशोधित करते हैं?**

नहीं। ऑपरेशन्स उस `Picture` से संबंधित होते हैं जो चित्र फ़िल द्वारा उपयोग किया जाता है। अंतर्निहित `PPImage` बाइट्स अपरिवर्तित रहते हैं।

**क्या दो चित्र फ्रेम जो एक ही इमेज को पुनः उपयोग करते हैं, उनके इफ़ेक्ट्स साझा करेंगे?**

नहीं। एक `PPImage` को पुनः उपयोग करने से डुप्लिकेट इमेज डेटा बचता है, लेकिन प्रत्येक चित्र फ्रेम आमतौर पर अलग `Picture` और इमेज ट्रांसफ़ॉर्म संग्रह रखता है।

**क्या रंग, ब्लर, और अल्फा इफ़ेक्ट्स को संयोजित किया जा सकता है?**

हां। संग्रह उन्हें एक क्रमबद्ध चेन में स्वीकार करता है। प्रत्येक ऑपरेशन के पिछले आउटपुट पर प्रभाव पर विचार करें क्योंकि प्रतिस्थापन और थ्रेसहोल्ड ऑपरेशन्स पहले के रंग या अल्फा विवरण को हटा सकते हैं।

**क्यों प्रभावी मान केवल-पढ़ने योग्य होते हैं?**

प्रभावी डेटा रेंडरिंग के लिए उपयोग किए गए गणना किए गए मानों को दर्शाता है, जिसमें हल किए गए रंग शामिल हैं। यदि लिखने योग्य सदस्य मौजूद हों तो ट्रांसफ़ॉर्म संग्रह में संग्रहीत ऑपरेशन को संपादित करें; अन्यथा इसे हटाएँ और नई निर्माण पैरामीटर के साथ एक प्रतिस्थापन जोड़ें।

**एक ट्रांसफ़ॉर्म चेन को संरक्षित करने के लिए मुझे कौन सा स्वरूप उपयोग करना चाहिए?**

PPTX का उपयोग करें और फ़ाइल को पुनः खोलकर सत्यापित करें। लेगेसी PPT पूर्ण DrawingML इफ़ेक्ट मॉडल को दर्शा नहीं सकता, और रेंडर किए गए निर्यात स्वरूप केवल दिखावट को संरक्षित करते हैं न कि संपादन योग्य ट्रांसफ़ॉर्म ऑपरेशन्स।