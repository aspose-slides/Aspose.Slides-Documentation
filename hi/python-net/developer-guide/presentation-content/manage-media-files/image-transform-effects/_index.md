---
title: Python के साथ प्रस्तुतियों में इमेज ट्रांसफ़ॉर्म इफ़ेक्ट्स का प्रबंधन
linktitle: इमेज ट्रांसफ़ॉर्म इफ़ेक्ट्स
type: docs
weight: 11
url: /hi/python-net/image-transform-effects/
keywords:
- इमेज ट्रांसफ़ॉर्म
- पिक्चर इफ़ेक्ट
- चमक
- कंट्रास्ट
- ग्रेस्केल
- ड्यूटोन
- टिंट
- HSL
- रंग प्रतिस्थापन
- ब्लर
- ट्रांसपेरेंसी
- अल्फा इफ़ेक्ट
- इफ़ेक्ट श्रृंखला
- PowerPoint
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides for Python के माध्यम से .NET पर चित्र फ़्रेम के लिए इमेज ट्रांसफ़ॉर्म इफ़ेक्ट्स को लागू करें, श्रृंखला बनाएं, निरीक्षण करें, हटाएँ और सत्यापित करें।"
---
## **अवलोकन**

Aspose.Slides चित्र समायोजन को इमेज ट्रांसफ़ॉर्म ऑपरेशनों के क्रमबद्ध संग्रह के रूप में दर्शाता है। किसी चित्र फ़्रेम के लिए, फ्रेम की [Picture](https://reference.aspose.com/slides/python-net/aspose.slides/picture/) से शुरू करें और उसकी [image_transform](https://reference.aspose.com/slides/python-net/aspose.slides/picture/image_transform/) प्रॉपर्टी तक पहुँचें। लौटाया गया [ImageTransformOperationCollection](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/) आपको प्रभावों को जोड़ने, क्रमबद्ध करने, निरीक्षण करने, हटाने और साफ़ करने की सुविधा देता है बिना मूल छवि बाइट्स को पुनर्लेखन किए।

यह लेख चमक और कंट्रास्ट, रंग परिवर्तन, ब्लूर, ट्रांसपेरेंसी, क्रमबद्ध प्रभाव श्रृंखलाएँ, प्रभावी मान, हटाना, और PPTX राउंड‑ट्रिप सत्यापन के लिए पूर्ण कार्य‑प्रवाह को दर्शाता है।

## **इफ़ेक्ट स्वामित्व और छवि पुनः उपयोग को समझें**

- [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) प्रस्तुति द्वारा स्वामित्व वाले स्रोत छवि डेटा को संग्रहीत या संदर्भित करता है।
- [Picture](https://reference.aspose.com/slides/python-net/aspose.slides/picture/) एक चित्र फ़िल में आता है और एक इमेज रिसोर्स को संदर्भित करता है जबकि इमेज ट्रांसफ़ॉर्म संग्रह को संग्रहीत करता है।
- [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) स्लाइड आकार है जो संबंधित चित्र फ़िल, ज्यामिति, क्रॉप सेटिंग्स, और अन्य फ़्रेम‑स्तर फ़ॉर्मेटिंग का स्वामित्व रखता है।

इसलिए, इमेज ट्रांसफ़ॉर्म ऑपरेशंस [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) में बाइट्स को संशोधित नहीं करते। जब वही `PPImage` को [ShapeCollection.add_picture_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_picture_frame/) में एक से अधिक बार पास किया जाता है, तो प्रत्येक नया चित्र फ़्रेम अपना स्वयं का `Picture` और अपना स्वयं का ट्रांसफ़ॉर्म संग्रह प्राप्त करता है। एक फ़्रेम पर ग्रेस्केल लागू करने से अन्य फ़्रेम ग्रेस्केल नहीं होते, भले ही सभी एक ही एंबेडेड इमेज रिसोर्स को पुनः उपयोग करें।

एक ही `Picture.image_transform` मॉडल का उपयोग अन्य चित्र फ़िल, जैसे आकार या स्लाइड पृष्ठभूमि, में भी होता है। नीचे के उदाहरण चित्र फ़्रेम पर केंद्रित हैं।

## **वैध पैरामीटर रेंज और इकाइयाँ उपयोग करें**

प्रदर्शित विधियां निम्नलिखित अर्थपूर्ण रेंज और इकाइयों का उपयोग करती हैं। इन रेंजों में मान रखें चाहे कोई लाइब्रेरी संस्करण तुरंत हर आउट‑ऑफ़‑रेंज मान को अस्वीकार न करे; लक्ष्य प्रस्तुति फ़ॉर्मेट सहेजते समय या PowerPoint फ़ाइल खोलते समय अमान्य डेटा को सामान्यीकृत, छोड़ या अस्वीकार कर सकता है।

| ऑपरेशन | पैरामीटर | वैध रेंज और इकाई |
|---|---|---|
| [add_brightness_contrast_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_brightness_contrast_effect/) | `brightness`, `contrast` | `-100` से `100` तक, प्रतिशत; `0` घटक को अपरिवर्तित रखता है। |
| [add_gray_scale_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_gray_scale_effect/) | None | कोई संख्यात्मक पैरामीटर नहीं। अल्फा अपरिवर्तित रहता है। |
| [add_duotone_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_duotone_effect/) | `color1`, `color2` | दो रंग गहरे और हल्के पिक्सेल के लिए। RGB और अल्फा चैनल `0` से `255` तक उपयोग करते हैं। |
| [add_tint_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_tint_effect/) | `hue`, `amount` | Hue `0` (समावेशी) से `360` (अपवर्जन) डिग्री में; amount `-100` से `100` प्रतिशत। |
| [add_hsl_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_hsl_effect/) | `hue`, `saturation`, `luminance` | Hue `0` (समावेशी) से `360` (अपवर्जन) डिग्री में; saturation और luminance `-100` से `100` प्रतिशत। |
| [add_color_replace_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_color_replace_effect/) | `color` | बदलाव रंग चैनल मान `0` से `255` तक। मौजूदा अल्फा मान अपरिवर्तित। |
| [add_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_blur_effect/) | `radius`, `grow` | Radius असंख्या है और पॉइंट्स में मापा जाता है; `grow` एक Boolean है जो निर्धारित करता है कि धुंधला सामग्री मूल सीमा से बाहर जा सकती है या नहीं। |
| [add_alpha_modulate_fixed_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_modulate_fixed_effect/) | `amount` | असंख्यात्मक प्रतिशत। सामान्य अपारदर्शिता स्केलिंग के लिए `0` से `100` उपयोग करें: `0` पूरी तरह पारदर्शी और `100` मौजूदा अल्फा को बरकरार रखता है। |
| [add_alpha_replace_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_replace_effect/) | `alpha` | `0` से `100` प्रतिशत अपारदर्शिता। |
| [add_alpha_bi_level_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_bi_level_effect/) | `threshold` | `0` से `100` प्रतिशत अल्फा थ्रेशोल्ड। इसके नीचे के मान पारदर्शी हो जाते हैं; इसके बराबर या ऊपर के मान अपारदर्शी होते हैं। |

स्थिर अल्फा मॉड्यूलेशन के लिए, ट्रांसपेरेंसी और अपारदर्शिता परस्पर पूरक हैं। उदाहरण के लिए, 35% ट्रांसपेरेंसी का अर्थ 65% अल्फा मॉड्यूलेशन मात्रा है।

## **चमक और कंट्रास्ट लागू करें**

[ImageTransformOperationCollection.add_brightness_contrast_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_brightness_contrast_effect/) एक [BrightnessContrast](https://reference.aspose.com/slides/python-net/aspose.slides.effects/brightnesscontrast/) ऑपरेशन लौटाता है। इसके स्केलर सेटिंग्स ऑपरेशन बनाते समय आपूर्ति की जाती हैं। [BrightnessContrast.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides.effects/brightnesscontrast/get_effective/) गणना किए गए केवल‑पढ़ने योग्य मान लौटाता है जिन्हें निरीक्षण या लॉग किया जा सकता है।

निम्न उदाहरण चमक को 15% और कंट्रास्ट को 20% बढ़ाता है, फिर एंबेडेड इमेज को बदले बिना एक पूर्वावलोकन रेंडर करता है:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.png") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 400, 260, image)
    image_transform = picture_frame.picture_format.picture.image_transform
    brightness_contrast = image_transform.add_brightness_contrast_effect(15, 20)

    effective_values = brightness_contrast.get_effective()
    print("Brightness: " + str(effective_values.brightness) + "%")
    print("Contrast: " + str(effective_values.contrast) + "%")

    with slide.get_image() as preview:
        preview.save("brightness-contrast-preview.png")
```

[BrightnessContrast](https://reference.aspose.com/slides/python-net/aspose.slides.effects/brightnesscontrast/) Office 2010 चित्र‑इफ़ेक्ट एक्सटेंशन है और मानक DrawingML ल्यूमिनेंस इफ़ेक्ट की तुलना में कम पोर्टेबल है। जब चमक और कंट्रास्ट को PPTX राउंड‑ट्रिप के बाद भी संपादन योग्य रखना हो, तो [ImageTransformOperationCollection.add_luminance_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_luminance_effect/) का उपयोग करें और फ़ाइल को पुनः खोलने के बाद परिणाम की पुष्टि करें। फ़ॉर्मेट सीमाओं वाले अनुभाग में इस भेद को अधिक विस्तार से समझाया गया है।

## **रंग परिवर्तन लागू करें**

रंग प्रभावों को स्वतंत्र रूप से विभिन्न चित्र फ़्रेम पर लागू किया जा सकता है जो एक ही इमेज रिसोर्स को पुनः उपयोग करते हैं। निम्न उदाहरण पाँच फ़्रेम बनाता है और क्रमशः ग्रेस्केल, ड्यूटोन, टिंट, HSL समायोजन, और रंग प्रतिस्थापन लागू करता है।

[Duotone](https://reference.aspose.com/slides/python-net/aspose.slides.effects/duotone/) दो स्वतंत्र रूप से संपादन योग्य रंग पैरामीटर रखता है: `color1` गहरे पिक्सेल को मैप करता है, जबकि `color2` हल्के पिक्सेल को। यह एक उपयोगी उदाहरण है जहाँ सेटिंग्स एकल स्केलर मान से अधिक जटिल होती हैं।

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.png") as source_image:
        image = presentation.images.add_image(source_image)

    gray_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 20, 180, 120, image)
    gray_frame.picture_format.picture.image_transform.add_gray_scale_effect()

    duotone_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 220, 20, 180, 120, image)
    duotone = duotone_frame.picture_format.picture.image_transform.add_duotone_effect()
    duotone.color1.color = draw.Color.navy
    duotone.color2.color = draw.Color.gold

    tint_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 420, 20, 180, 120, image)
    tint_frame.picture_format.picture.image_transform.add_tint_effect(210, 35)

    hsl_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 120, 170, 180, 120, image)
    hsl_frame.picture_format.picture.image_transform.add_hsl_effect(30, 20, -10)

    replacement_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 320, 170, 180, 120, image)
    color_replacement = replacement_frame.picture_format.picture.image_transform.add_color_replace_effect()
    color_replacement.color.color = draw.Color.cornflower_blue

    presentation.save("color-transformations.pptx", slides.export.SaveFormat.PPTX)
```

[add_color_replace_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_color_replace_effect/) प्रत्येक पिक्सेल के रंग को एक निश्चित रंग से बदल देता है जबकि अल्फा को बरकरार रखता है। यह [add_color_change_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_color_change_effect/) से अलग है, जहाँ एक स्रोत रंग को दूसरे में मैप किया जाता है और दोनों स्रोत व लक्ष्य रंग स्वरूप उजागर होते हैं।

### **एक ल्यूमिनेंस थ्रेशोल्ड लागू करें**

एक ल्यूमिनेंस थ्रेशोल्ड स्कैन किए गए पृष्ठ पर धुंधले निशानों को पृष्ठभूमि से अलग करना आसान बनाता है। [add_gray_scale_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_gray_scale_effect/) मध्यवर्ती ग्रे शेड्स को संरक्षित रखता है। [add_bi_level_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_bi_level_effect/) ल्यूमिनेंस को काले या सफेद में मैप करता है, जबकि [add_alpha_bi_level_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_bi_level_effect/) अपारदर्शिता पर थ्रेशोल्ड लागू करता है।

ल्यूमिनेंस थ्रेशोल्ड 0% से 100% (समावेशी) तक रहता है। थ्रेशोल्ड से नीचे के पिक्सेल काले हो जाते हैं। थ्रेशोल्ड के बराबर या उससे ऊपर के पिक्सेल सफेद हो जाते हैं। थ्रेशोल्ड बढ़ाने से अधिक शेड्स काले बनते हैं क्योंकि अधिक पिक्सेल कट‑ऑफ़ से नीचे गिरते हैं।

[grayscale-swatches.png](grayscale-swatches.png) को कार्य निर्देशिका में डाउनलोड करें। प्रत्येक लेबल 0‑255 के पैमाने पर मूल ग्रे स्तर दर्शाता है। उदाहरण मूल को दो प्रतियों के साथ रखता है और प्रत्येक प्रतिलिपि का थ्रेशोल्ड प्रस्तुति में सहेजता है।

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(720, 150, slides.SlideSizeScaleType.DO_NOT_SCALE)
    shapes = presentation.slides[0].shapes

    with slides.Images.from_file("grayscale-swatches.png") as source_image:
        image = presentation.images.add_image(source_image)

    def add_frame(x, caption):
        label = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, x, 12, 216, 36)
        label.text_frame.text = caption
        return shapes.add_picture_frame(slides.ShapeType.RECTANGLE, x, 60, 216, 72, image)

    add_frame(12, "Original")

    low_threshold = add_frame(252, "Threshold 20%")
    low_threshold.picture_format.picture.image_transform.add_bi_level_effect(20)
    
    high_threshold = add_frame(492, "Threshold 60%")
    high_threshold.picture_format.picture.image_transform.add_bi_level_effect(60)

    presentation.save("luminance-threshold.pptx", slides.export.SaveFormat.PPTX)
```

आउटपुट प्रस्तुति को PowerPoint में खोलें और तीन फ़्रेम की तुलना करें। लेबल 96 वाला स्वैच लगभग 38% ल्यूमिनेंस (96/255) रखता है। यह 20% थ्रेशोल्ड पर सफेद और 60% थ्रेशोल्ड पर काला हो जाता है।

![मूल ग्रेस्केल स्वैचेज़ को ल्यूमिनेंस थ्रेशोल्ड 20% और 60% पर काले‑सफ़ेद परिणामों के साथ](luminance-threshold.png)

## **ब्लर, ट्रांसपेरेंसी, और अल्फा इफ़ेक्ट जोड़ें**

[add_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_blur_effect/) सभी रंग चैनलों को प्रभावित करता है, जिसमें अल्फा भी शामिल है। जब धुंधली किनारा मूल चित्र की सीमाओं से बाहर जा सकता है, तो `grow` को `True` सेट करें।

समान ट्रांसपेरेंसी के लिए, [add_alpha_modulate_fixed_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_modulate_fixed_effect/) का उपयोग करें। यह प्रत्येक मौजूदा अल्फा मान को गुणा करता है, इसलिए भाग‑पारदर्शी पिक्सेल अनुपातिक रूप से अलग बने रहते हैं। [add_alpha_replace_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_replace_effect/) सभी पिक्सेल को एक ही अल्फा मान सौंपता है। [add_alpha_bi_level_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_bi_level_effect/) थ्रेशोल्ड के आधार पर अल्फा को दो स्तरों में बदलता है।

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.png") as source_image:
        image = presentation.images.add_image(source_image)

    blurred_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 20, 200, 140, image)
    blur = blurred_frame.picture_format.picture.image_transform.add_blur_effect(4.5, True)
    blur.radius = 5

    transparent_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 240, 20, 200, 140, image)
    alpha_modulate = transparent_frame.picture_format.picture.image_transform.add_alpha_modulate_fixed_effect(65)
    alpha_modulate.amount = 60

    uniform_alpha_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 180, 200, 140, image)
    uniform_alpha_frame.picture_format.picture.image_transform.add_alpha_replace_effect(55)

    binary_alpha_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 240, 180, 200, 140, image)
    alpha_bi_level = binary_alpha_frame.picture_format.picture.image_transform.add_alpha_bi_level_effect(50)
    alpha_bi_level.threshold = 45
    binary_alpha_frame.picture_format.picture.image_transform.add_alpha_inverse_effect()

    presentation.save("blur-and-alpha-effects.pptx", slides.export.SaveFormat.PPTX)
```

अन्य पैरामीटर‑रहित अल्फा ऑपरेशन्स में शामिल हैं [add_alpha_ceiling_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_ceiling_effect/), जो प्रत्येक शून्य‑से‑गैर‑शून्य अल्फा को पूर्णतः अपारदर्शी बनाता है; [add_alpha_floor_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_floor_effect/), जो 100% से नीचे के प्रत्येक अल्फा को पूर्णतः पारदर्शी बनाता है; और [add_alpha_inverse_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_inverse_effect/), जो अल्फा को `100% - alpha` में बदलता है।

## **क्रमबद्ध इफ़ेक्ट श्रृंखला बनाएं**

प्रत्येक `add_..._effect` मेथड संग्रह के अंत में एक नया ऑपरेशन जोड़ता है। रेंडरर इस संग्रह को क्रमबद्ध पाइपलाइन के रूप में उपयोग करता है: ऑपरेशन 0 का आउटपुट ऑपरेशन 1 की इनपुट बन जाता है, आदि। इस कारण, समान ऑपरेशन्स अलग क्रम में होने पर अलग छवि बन सकती है।

उदाहरण के लिए, ग्रेस्केल के बाद टिंट पहले रंगीय जानकारी को हटा देता है और फिर ल्यूमिनेंस परिणाम को पुनः‑रंग देता है। टिंट के बाद ग्रेस्केल टिंट को फिर से हटा देता है। इसी प्रकार, अल्फा प्रतिस्थापन पहले ऑपरेशन्स द्वारा गणित अल्फा मानों को ओवरराइड कर सकता है, जबकि अल्फा मॉड्यूलेशन उनके सापेक्ष अंतर को बरकरार रखता है।

निम्न उदाहरण चार‑ऑपरेशन की श्रृंखला बनाता है, इसे PPTX के रूप में सहेजता है, प्रस्तुति को पुनः खोलता है, दोनों ऑपरेशन प्रकार और उनका क्रम जांचता है, और फिर पुनः‑खोलने वाले परिणाम को रेंडर करता है:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.png") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 400, 260, image)
    image_transform = picture_frame.picture_format.picture.image_transform
    image_transform.add_gray_scale_effect()
    image_transform.add_tint_effect(220, 25)
    image_transform.add_blur_effect(2.5, False)
    image_transform.add_alpha_modulate_fixed_effect(80)

    presentation.save("image-transform-chain.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("image-transform-chain.pptx") as reopened_presentation:
    reopened_shape = reopened_presentation.slides[0].shapes[0]

    if isinstance(reopened_shape, slides.PictureFrame):
        reopened_transform = reopened_shape.picture_format.picture.image_transform
        order_is_preserved = (
            len(reopened_transform) == 4 and
            isinstance(reopened_transform[0], slides.effects.GrayScale) and
            isinstance(reopened_transform[1], slides.effects.Tint) and
            isinstance(reopened_transform[2], slides.effects.Blur) and
            isinstance(reopened_transform[3], slides.effects.AlphaModulateFixed)
        )
        print("The effect chain was preserved." if order_is_preserved else "The effect chain changed during the round trip.")

        with reopened_presentation.slides[0].get_image() as rendered_slide:
            rendered_slide.save("reopened-effect-chain.png")
    else:
        print("The reopened shape is not a picture frame.")
```

संग्रह कोई संगतता मैट्रिक्स नहीं लगाता जो रंग, अल्फा, और ब्लर ऑपरेशन्स को अलग‑अलग श्रृंखलाओं तक सीमित करता हो। इन्हें संयोजित किया जा सकता है, पर संयोजन हमेशा उपयोगी नहीं होते। एक स्थिर रंग प्रतिस्थापन पहले के रंग प्रभावों द्वारा उत्पन्न RGB परिवर्तन को हटा देता है; ड्यूटोन के बाद ग्रेस्केल दो चयनित रंगों को हटा देता है; और अल्फा सीलिंग, फ़्लोर, प्रतिस्थापन या बाइ‑लेवल ऑपरेशन्स पहले बनाये गए अल्फा विवरण को हटाने का काम कर सकते हैं। इच्छित पिक्सल‑प्रोसेसिंग क्रम के अनुसार श्रृंखला बनाएँ, न कि आइटम को अनऑर्डर फ़ॉर्मेटिंग फ़्लैग के रूप में देखें।

<!-- visual-explanation:image-transform-effects:start -->
[![The same image passes through grayscale then tint, and tint then grayscale. The two final grayscale images have different tones.](visual-image-transform-effects-49aa72211f3a.svg)](visual-image-transform-effects-49aa72211f3a.svg)

*In this illustrative Aspose.Slides for .NET 26.11 render, a 220° tint at 25% leaves the grayscale image unchanged. Applying the same tint before grayscale produces different tones.*
<!-- visual-explanation:image-transform-effects:end -->

## **संपादन योग्य और प्रभावी मानों की जांच करें**

एक संपादन योग्य ऑपरेशन वह ऑब्जेक्ट है जो `Picture.image_transform` में संग्रहीत होता है। प्रभाव के आधार पर, यह सीधे लिखने योग्य सदस्य उजागर कर सकता है। उदाहरण के लिए, [Blur](https://reference.aspose.com/slides/python-net/aspose.slides.effects/blur/) लिखने योग्य `radius` और `grow` प्रॉपर्टी उजागर करता है, [AlphaModulateFixed](https://reference.aspose.com/slides/python-net/aspose.slides.effects/alphamodulatefixed/) लिखने योग्य `amount` प्रॉपर्टी उजागर करता है, और [AlphaBiLevel](https://reference.aspose.com/slides/python-net/aspose.slides.effects/alphabilevel/) लिखने योग्य `threshold` प्रॉपर्टी उजागर करता है। रंग प्रभाव जैसे [Duotone](https://reference.aspose.com/slides/python-net/aspose.slides.effects/duotone/) परिवर्तनशील [ColorFormat](https://reference.aspose.com/slides/python-net/aspose.slides/colorformat/) ऑब्जेक्ट उजागर करते हैं।

कुछ ऑपरेशन्स, जिनमें [BrightnessContrast](https://reference.aspose.com/slides/python-net/aspose.slides.effects/brightnesscontrast/), [HSL](https://reference.aspose.com/slides/python-net/aspose.slides.effects/hsl/), [Tint](https://reference.aspose.com/slides/python-net/aspose.slides.effects/tint/), और [AlphaReplace](https://reference.aspose.com/slides/python-net/aspose.slides.effects/alphareplace/) शामिल हैं, उनके निर्माण स्केलर को लिखने योग्य प्रॉपर्टी के रूप में उजागर नहीं करते। इन सेटिंग्स को बदलने के लिए, ऑपरेशन को हटाएँ और आवश्यक स्थान पर एक नया जोड़ें।

`get_effective()` द्वारा लौटाए गए प्रभावी डेटा की गणना की जाती है और वह केवल‑पढ़ने योग्य होता है। यह थीम‑निर्भर रंगों को हल करने और रेंडरर द्वारा उपयोग किए गए सामान्यीकृत मान पढ़ने में उपयोगी है, पर यह एक अतिरिक्त संपादन सतह नहीं है। निम्न उदाहरण श्रृंखला को क्रमबद्ध करता है और जहाँ संबंधित API प्रदान करता है, प्रभावी मानों का निरीक्षण करता है:

```python
import aspose.slides as slides

with slides.Presentation("image-transform-chain.pptx") as presentation:
    picture_frame = None

    for shape in presentation.slides[0].shapes:
        if isinstance(shape, slides.PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        image_transform = picture_frame.picture_format.picture.image_transform

        for index, operation in enumerate(image_transform):
            print(str(index) + ": " + type(operation).__name__)

            if isinstance(operation, slides.effects.BrightnessContrast):
                effect_data = operation.get_effective()
                print("  Brightness: " + str(effect_data.brightness))
                print("  Contrast: " + str(effect_data.contrast))
            elif isinstance(operation, slides.effects.Luminance):
                effect_data = operation.get_effective()
                print("  Brightness: " + str(effect_data.brightness))
                print("  Contrast: " + str(effect_data.contrast))
            elif isinstance(operation, slides.effects.Duotone):
                effect_data = operation.get_effective()
                print("  Dark color: " + str(effect_data.color1))
                print("  Light color: " + str(effect_data.color2))
            elif isinstance(operation, slides.effects.ColorReplace):
                effect_data = operation.get_effective()
                print("  Replacement color: " + str(effect_data.color))
            elif isinstance(operation, slides.effects.HSL):
                effect_data = operation.get_effective()
                print("  HSL: " + str(effect_data.hue) + ", " + str(effect_data.saturation) + ", " + str(effect_data.luminance))
            elif isinstance(operation, slides.effects.Tint):
                effect_data = operation.get_effective()
                print("  Tint: " + str(effect_data.hue) + ", " + str(effect_data.amount))
            elif isinstance(operation, slides.effects.Blur):
                effect_data = operation.get_effective()
                print("  Blur radius: " + str(effect_data.radius) + " pt")
            elif isinstance(operation, slides.effects.AlphaModulateFixed):
                effect_data = operation.get_effective()
                print("  Alpha amount: " + str(effect_data.amount) + "%")
            elif isinstance(operation, slides.effects.AlphaReplace):
                effect_data = operation.get_effective()
                print("  Replacement alpha: " + str(effect_data.alpha) + "%")
            elif isinstance(operation, slides.effects.AlphaBiLevel):
                effect_data = operation.get_effective()
                print("  Alpha threshold: " + str(effect_data.threshold) + "%")
```

ग्रेस्केल, अल्फा सीलिंग, अल्फा इनवर्स जैसी पैरामीटर‑रहित प्रभावों के भी प्रभावी‑डेटा ऑब्जेक्ट होते हैं, पर उन्हें प्रिंट करने के लिए कोई स्केलर सेटिंग नहीं होती। उनका संग्रह में उपस्थित होना और स्थान ही महत्वपूर्ण जानकारी है।

## **छवि ट्रांसफ़ॉर्म हटाएँ या साफ़ करें**

[ImageTransformOperationCollection.remove_at](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/remove_at/) का उपयोग करके आप इंडेक्स द्वारा एक ऑपरेशन हटा सकते हैं। क्योंकि हटाने के बाद इंडेक्स बदलते हैं, पहले लक्ष्य को खोजें और क्रमबद्ध करने के बाद उसे हटाएँ। पूरी श्रृंखला को हटाने के लिए `clear()` का उपयोग करें।

```python
import aspose.slides as slides

with slides.Presentation("image-transform-chain.pptx") as presentation:
    picture_frame = None

    for shape in presentation.slides[0].shapes:
        if isinstance(shape, slides.PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        image_transform = picture_frame.picture_format.picture.image_transform
        blur_index = None

        for index, operation in enumerate(image_transform):
            if isinstance(operation, slides.effects.Blur):
                blur_index = index
                break

        if blur_index is not None:
            image_transform.remove_at(blur_index)
            print("The blur operation was removed.")

        image_transform.clear()
        print("Remaining operations: " + str(len(image_transform)))
        presentation.save("image-transforms-cleared.pptx", slides.export.SaveFormat.PPTX)
```

ट्रांसफ़ॉर्म हटाने या साफ़ करने से केवल चित्र फ़ॉर्मेटिंग बदलती है। यह पुनः‑उपयोग किए गए [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) रिसोर्स को नहीं हटाता, संकुचित नहीं करता, या अन्यथा नहीं बदलता।

## **प्रेजेंटेशन फ़ॉर्मेट और एक्सपोर्ट टार्गेट पर विचार करें**

इमेज ट्रांसफ़ॉर्म DrawingML में उत्पन्न होते हैं, इसलिए PPTX प्रभाव श्रृंखलाओं के लिए पसंदीदा संपादन योग्य फ़ॉर्मेट है। PPTX के साथ भी, हर ऑपरेशन की पोर्टेबिलिटी समान नहीं होती:

- मानक DrawingML ऑपरेशन्स जैसे ल्यूमिनेंस, ग्रेस्केल, ड्यूटोन, टिंट, HSL, ब्लर, और सामान्य अल्फा ऑपरेशन्स का PPTX राउंड‑ट्रिप पर जीवित रहने का सबसे बड़ा шанс होता है। जब संरक्षण आवश्यक हो, हमेशा उत्पन्न फ़ाइल को पुनः खोलें और संग्रह का निरीक्षण करें।
- [BrightnessContrast](https://reference.aspose.com/slides/python-net/aspose.slides.effects/brightnesscontrast/) Office 2010 एक्सटेंशन है, मानक DrawingML ल्यूमिनेंस ऑपरेशन नहीं। इसे इन‑मेमोरी रेंडरिंग के लिए उपयोग किया जा सकता है, पर यह सहेजने और PPTX पुनः खोलने के बाद संपादन योग्य `BrightnessContrast` ऑपरेशन के रूप में रहने की गारंटी नहीं देता। स्थायी चमक‑और‑कंट्रास्ट समायोजन के लिए [add_luminance_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_luminance_effect/) को प्राथमिकता दें।
- बाइनरी PPT फ़ॉर्मेट पूर्ण DrawingML इफ़ेक्ट मॉडल से पहले आया है। PPT में सहेजने से असमर्थित ऑपरेशन्स छोड़े जा सकते हैं, श्रृंखला को समर्थित उपसमुच्चय में घटाया जा सकता है, या रूप‑रेखा का अनुमान लगाया जा सकता है। जटिल संपादन योग्य श्रृंखला के लिए PPT को सत्यापन फ़ॉर्मेट के रूप में उपयोग न करें।
- PNG, JPEG, TIFF, PDF, SVG, HTML, या अन्य दृश्य आउटपुट पर रेंडर करने से समर्थित श्रृंखला का उपयोग करके रेंडर किया गया रूप प्राप्त होता है। इन आउटपुट में संपादन योग्य `ImageTransformOperationCollection` नहीं होता; रास्टर फ़ॉर्मेट परिणाम को पिक्सल में फ़्लैट कर देते हैं, और दस्तावेज़ या वेक्टर निर्यात अपने स्वयं के रेंडरिंग प्रतिनिधित्व को संग्रहीत करते हैं।
- इफ़ेक्ट लिंक्ड इमेज को स्वनिर्भर नहीं बनाते। लिंक्ड चित्र को रेंडर करने के लिए लिंक्ड रिसोर्स को प्रस्तुतिकरण लोड होने पर उपलब्ध होना ज़रूरी है।

विभिन्न प्रेजेंटेशन उपभोक्ता किनारे के मामलों को अलग‑अलग रेंडर कर सकते हैं, विशेषकर जब कई अल्फा या रंग‑क्वांटाइज़िंग ऑपरेशन्स एक साथ जुड़े हों। महत्वपूर्ण आउटपुट के लिए, वही Aspose.Slides संस्करण उपयोग करके संपादन योग्य राउंड‑ट्रिप और अंतिम निर्यात फ़ॉर्मेट दोनों का परीक्षण करें।

## **FAQ**

**क्या इमेज ट्रांसफ़ॉर्म प्रभाव एंबेडेड इमेज डेटा को संशोधित करते हैं?**

नहीं। ऑपरेशन्स उस `Picture` से जुड़े होते हैं जो चित्र फ़िल द्वारा उपयोग किया जाता है। अंतर्निहित `PPImage` बाइट्स अपरिवर्तित रहती हैं।

**क्या दो चित्र फ़्रेम जो एक ही इमेज को पुनः उपयोग करते हैं, अपनी प्रभावों को साझा करेंगे?**

नहीं। `PPImage` को पुनः उपयोग करने से डुप्लिकेट इमेज डेटा बचता है, पर प्रत्येक चित्र फ़्रेम आम तौर पर अपना अलग `Picture` और इमेज ट्रांसफ़ॉर्म संग्रह रखता है।

**क्या रंग, ब्लर, और अल्फा इफ़ेक्ट को एक साथ जोड़ा जा सकता है?**

हां। संग्रह उन्हें एक क्रमबद्ध श्रृंखला में स्वीकार करता है। प्रत्येक ऑपरेशन पूर्व के आउटपुट को कैसे बदलता है, इस पर विचार करें क्योंकि प्रतिस्थापन और थ्रेशोल्ड ऑपरेशन्स पहले के रंग या अल्फा विवरण को हटा सकते हैं।

**प्रभावी मान पढ़ने‑के‑लिए केवल‑पढ़ने योग्य क्यों होते हैं?**

प्रभावी डेटा रेंडरिंग के लिए उपयोग किए गए गणना किए गए मानों को दर्शाता है, जिसमें हल किए गए रंग शामिल होते हैं। लिखने योग्य सदस्य वाले ऑपरेशन को `Picture.image_transform` में जहाँ संभव हो, संपादित करें; अन्यथा उसे हटाएँ और नई निर्माण पैरामीटर के साथ प्रतिस्थापन जोड़ें।

**मैं कौन सा फ़ॉर्मेट उपयोग करूँ ताकि ट्रांसफ़ॉर्म श्रृंखला सुरक्षित रहे?**

PPTX का उपयोग करें और फ़ाइल को पुनः खोलकर जांचें। लेगेसी PPT पूर्ण DrawingML इफ़ेक्ट मॉडल को दर्शाने में असमर्थ है, और रेंडर किए गए निर्यात फ़ॉर्मेट केवल रूप‑रेखा को संरक्षित करते हैं, न कि संपादन योग्य ट्रांसफ़ॉर्म ऑपरेशन्स।