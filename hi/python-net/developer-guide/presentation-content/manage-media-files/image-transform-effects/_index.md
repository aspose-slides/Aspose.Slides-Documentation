---
title: Python के साथ प्रस्तुतियों में इमेज ट्रांसफ़ॉर्म इफ़ेक्ट्स को प्रबंधित करें
linktitle: इमेज ट्रांसफ़ॉर्म इफ़ेक्ट्स
type: docs
weight: 11
url: /hi/python-net/image-transform-effects/
keywords:
- इमेज ट्रांसफ़ॉर्म
- पिक्चर इफ़ेक्ट
- उज्ज्वलता
- कॉन्ट्रास्ट
- ग्रेस्केल
- डुओटोन
- टिंट
- HSL
- रंग प्रतिस्थापन
- ब्लर
- पारदर्शिता
- अल्फ़ा इफ़ेक्ट
- इफ़ेक्ट श्रृंखला
- PowerPoint
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET के साथ पिक्चर फ्रेम्स के लिए इमेज ट्रांसफ़ॉर्म इफ़ेक्ट्स को लागू करें, श्रृंखलाबद्ध करें, निरीक्षण करें, हटाएँ और सत्यापित करें।"
---
## **सारांश**

Aspose.Slides चित्र समायोजन को छवि रूपांतरण कार्यों के क्रमबद्ध संग्रह के रूप में दर्शाता है। किसी चित्र फ़्रेम के लिए, फ़्रेम की [Picture](https://reference.aspose.com/slides/hi/python-net/aspose.slides/picture/) से शुरू करें और उसकी [image_transform](https://reference.aspose.com/slides/hi/python-net/aspose.slides/picture/image_transform/) गुण तक पहुँचें। लौटाया गया [ImageTransformOperationCollection](https://reference.aspose.com/slides/hi/python-net/aspose.slides.effects/imagetransformoperationcollection/) आपको प्रभाव जोड़ने, सूचीबद्ध करने, निरीक्षण करने, हटाने और साफ़ करने की अनुमति देता है, बिना मूल छवि बाइट्स को पुनः लिखे।

यह लेख उज्ज्वलता और कंट्रास्ट, रंग रूपांतरण, ब्लर, पारदर्शिता, क्रमबद्ध प्रभाव श्रृंखलाएँ, प्रभावी मान, हटाना, और PPTX राउंड‑ट्रिप सत्यापन के लिए पूर्ण कार्यप्रवाह दर्शाता है।

## **प्रभाव स्वामित्व और छवि पुन: उपयोग को समझें**

एक छवि संसाधन और वह चित्र जो इसे प्रदर्शित करता है अलग‑अलग वस्तुएँ हैं:

- [PPImage](https://reference.aspose.com/slides/hi/python-net/aspose.slides/ppimage/) प्रस्तुति द्वारा मालिकाना या संदर्भित मूल छवि डेटा को संग्रहीत करता है।
- [Picture](https://reference.aspose.com/slides/hi/python-net/aspose.slides/picture/) चित्र फ़िल का हिस्सा है और एक छवि संसाधन को संदर्भित करता है तथा छवि रूपांतरण संग्रह को संग्रहीत करता है।
- [PictureFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/pictureframe/) वह स्लाइड आकार है जो संबंधित चित्र फ़िल, ज्यामिति, क्रॉप सेटिंग्स और अन्य फ़्रेम‑स्तर फ़ॉर्मेटिंग को धारण करता है।

इसलिए, छवि रूपांतरण कार्य [PPImage](https://reference.aspose.com/slides/hi/python-net/aspose.slides/ppimage/) में बाइट्स को संशोधित नहीं करते। जब समान `PPImage` को [ShapeCollection.add_picture_frame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/shapecollection/add_picture_frame/) को एक से अधिक बार पास किया जाता है, तो प्रत्येक नया चित्र फ़्रेम अपना स्वयं का `Picture` और अपनी रूपांतरण संग्रह प्राप्त करता है। एक फ़्रेम पर ग्रेस्केल लागू करने से अन्य फ़्रेम ग्रेस्केल नहीं हो जाते, भले ही सभी एक ही एम्बेडेड छवि संसाधन को पुनः उपयोग करें।

उपरोक्त `Picture.image_transform` मॉडल का उपयोग अन्य चित्र फ़िल, जैसे आकार या स्लाइड पृष्ठभूमि, द्वारा भी किया जाता है। नीचे के उदाहरण चित्र फ़्रेम पर केंद्रित हैं।

## **वैध पैरामीटर रेंज और इकाइयाँ उपयोग करें**

प्रदर्शित विधियाँ निम्नलिखित अर्थपूर्ण रेंज और इकाइयों का उपयोग करती हैं। इन रेंज में मान रखें, भले ही किसी विशेष लाइब्रेरी संस्करण में हर out‑of‑range मान तुरंत अस्वीकार न हो; लक्ष्य प्रस्तुति स्वरूप संग्रहीत करते समय या PowerPoint फ़ाइल खोलते समय अमान्य डेटा को सामान्यीकृत, हटाए या अस्वीकार कर सकता है।

| Operation | Parameters | Valid range and unit |
|---|---|---|
| [add_brightness_contrast_effect](https://reference.aspose.com/slides/hi/python-net/aspose.slides.effects/imagetransformoperationcollection/add_brightness_contrast_effect/) | `brightness`, `contrast` | `-100` से `100` तक, प्रतिशत; `0` घटक को अपरिवर्तित रखता है। |
| [add_gray_scale_effect](https://reference.aspose.com/slides/hi/python-net/aspose.slides.effects/imagetransformoperationcollection/add_gray_scale_effect/) | None | कोई संख्यात्मक पैरामीटर नहीं। अल्फ़ा अपरिवर्तित रहता है। |
| [add_duotone_effect](https://reference.aspose.com/slides/hi/python-net/aspose.slides.effects/imagetransformoperationcollection/add_duotone_effect/) | `color1`, `color2` | गहरे और हल्के पिक्सल के लिए दो रंग। RGB और अल्फ़ा चैनल `0` से `255` तक। |
| [add_tint_effect](https://reference.aspose.com/slides/hi/python-net/aspose.slides.effects/imagetransformoperationcollection/add_tint_effect/) | `hue`, `amount` | ह्यू `0` शामिल से `360` निरंकित तक डिग्री में; मात्रा `-100` से `100` तक, प्रतिशत। |
| [add_hsl_effect](https://reference.aspose.com/slides/hi/python-net/aspose.slides.effects/imagetransformoperationcollection/add_hsl_effect/) | `hue`, `saturation`, `luminance` | ह्यू `0` शामिल से `360` निरंकित तक डिग्री में; सैचुरेशन और ल्यूमिनेंस `-100` से `100` तक, प्रतिशत। |
| [add_color_replace_effect](https://reference.aspose.com/slides/hi/python-net/aspose.slides.effects/imagetransformoperationcollection/add_color_replace_effect/) | `color` | प्रतिस्थापन रंग के चैनल मान `0` से `255` तक। मौजूदा अल्फ़ा मान अपरिवर्तित रहता है। |
| [add_blur_effect](https://reference.aspose.com/slides/hi/python-net/aspose.slides.effects/imagetransformoperationcollection/add_blur_effect/) | `radius`, `grow` | त्रिज्या गैर‑नकारात्मक है और पॉइंट में मापी जाती है; `grow` एक Boolean है जो नियंत्रित करता है कि धुंधली सामग्री मूल सीमा से बाहर विस्तृत हो सकती है या नहीं। |
| [add_alpha_modulate_fixed_effect](https://reference.aspose.com/slides/hi/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_modulate_fixed_effect/) | `amount` | गैर‑नकारात्मक प्रतिशत। सामान्य अपारदर्शिता स्केलिंग के लिए `0` से `100` उपयोग करें: `0` पूरी तरह पारदर्शी और `100` मौजूदा अल्फ़ा को बनाए रखता है। |
| [add_alpha_replace_effect](https://reference.aspose.com/slides/hi/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_replace_effect/) | `alpha` | `0` से `100` तक, प्रतिशत अपारदर्शिता। |
| [add_alpha_bi_level_effect](https://reference.aspose.com/slides/hi/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_bi_level_effect/) | `threshold` | `0` से `100` तक, प्रतिशत अल्फ़ा थ्रेशहोल्ड। इससे कम मान पारदर्शी होते हैं; बराबर या अधिक मान अपारदर्शी होते हैं। |

स्थिर अल्फ़ा मॉड्यूलेशन के लिए, पारदर्शिता और अपारदर्शिता परस्परपूरक हैं। उदाहरण के लिए, 35 % पारदर्शिता अल्फ़ा मॉड्यूलेशन मात्रा 65 % के बराबर है।

## **उज्ज्वलता और कंट्रास्ट लागू करें**

[ImageTransformOperationCollection.add_brightness_contrast_effect](https://reference.aspose.com/slides/hi/python-net/aspose.slides.effects/imagetransformoperationcollection/add_brightness_contrast_effect/) एक [BrightnessContrast](https://reference.aspose.com/slides/hi/python-net/aspose.slides.effects/brightnesscontrast/) ऑपरेशन लौटाता है। इसके स्केलर सेटिंग्स ऑपरेशन निर्माण के समय प्रदान की जाती हैं। [BrightnessContrast.get_effective](https://reference.aspose.com/slides/hi/python-net/aspose.slides.effects/brightnesscontrast/get_effective/) गणना किए गए केवल‑पढ़ने‑योग्य मान लौटाता है जिन्हें निरीक्षण या लॉग किया जा सकता है।

निम्न उदाहरण उज्ज्वलता को 15 % और कंट्रास्ट को 20 % बढ़ाता है, फिर एम्बेडेड छवि को बदले बिना एक पूर्वावलोकन रेंडर करता है:

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

[BrightnessContrast](https://reference.aspose.com/slides/hi/python-net/aspose.slides.effects/brightnesscontrast/) Office 2010 चित्र‑प्रभाव विस्तार है और मानक DrawingML ल्यूमिनेंस प्रभाव की तुलना में कम पोर्टेबल है। जब उज्ज्वलता और कंट्रास्ट को PPTX राउंड‑ट्रिप के बाद भी संपादन‑योग्य रखना हो, तब [ImageTransformOperationCollection.add_luminance_effect](https://reference.aspose.com/slides/hi/python-net/aspose.slides.effects/imagetransformoperationcollection/add_luminance_effect/) उपयोग करें और फ़ाइल पुनः खोलने के बाद परिणाम सत्यापित करें। स्वरूप सीमाएँ अनुभाग इस अंतर को विस्तार से समझाती है।

## **रंग रूपांतरण लागू करें**

रंग प्रभाव विभिन्न चित्र फ़्रेम पर स्वतंत्र रूप से लागू किए जा सकते हैं जो एक ही छवि संसाधन को पुनः उपयोग करते हैं। नीचे का उदाहरण पाँच फ़्रेम बनाता है और क्रमशः ग्रेस्केल, डुओटोन, टिंट, HSL समायोजन, और रंग प्रतिस्थापन लागू करता है।

[Duotone](https://reference.aspose.com/slides/hi/python-net/aspose.slides.effects/duotone/) दो स्वतंत्र रूप से संपादन‑योग्य रंग पैरामीटर रखता है: `color1` गहरे पिक्सेल को मैप करता है, जबकि `color2` हल्के पिक्सेल को। यह एक ऐसा प्रभाव है जिसका सेटिंग एकल स्केलर मान से अधिक जटिल है।

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

[add_color_replace_effect](https://reference.aspose.com/slides/hi/python-net/aspose.slides.effects/imagetransformoperationcollection/add_color_replace_effect/) प्रत्येक पिक्सेल के रंग को एक नियत रंग से प्रतिस्थापित करता है जबकि अल्फ़ा को सुरक्षित रखता है। यह [add_color_change_effect](https://reference.aspose.com/slides/hi/python-net/aspose.slides.effects/imagetransformoperationcollection/add_color_change_effect/) से अलग है, जो एक स्रोत रंग को दूसरे में मैप करता है और दोनों स्रोत व लक्ष्य रंग स्वरूप दिखाता है।

## **ब्लर, पारदर्शिता और अल्फ़ा प्रभाव जोड़ें**

[add_blur_effect](https://reference.aspose.com/slides/hi/python-net/aspose.slides.effects/imagetransformoperationcollection/add_blur_effect/) सभी रंग चैनलों, अल्फ़ा सहित, को प्रभावित करता है। जब धुंधला किनारा मूल चित्र सीमा से बाहर निकल सकता है, तब `grow` को `True` सेट करें।

समान पारदर्शिता के लिए, [add_alpha_modulate_fixed_effect](https://reference.aspose.com/slides/hi/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_modulate_fixed_effect/) उपयोग करें। यह प्रत्येक मौजूदा अल्फ़ा मान को गुणा करता है, इसलिए आंशिक‑पारदर्शी पिक्सेल अनुपातिक रूप से अलग रहते हैं। [add_alpha_replace_effect](https://reference.aspose.com/slides/hi/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_replace_effect/) सभी पिक्सेल को एक ही अल्फ़ा मान देता है। [add_alpha_bi_level_effect](https://reference.aspose.com/slides/hi/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_bi_level_effect/) थ्रेशहोल्ड के आधार पर अल्फ़ा को दो स्तरों में बदलता है।

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

अन्य पैरामीटर‑रहित अल्फ़ा ऑपरेशन में [add_alpha_ceiling_effect](https://reference.aspose.com/slides/hi/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_ceiling_effect/) शामिल है, जो प्रत्येक शून्य‑से‑भिन्न अल्फ़ा को पूरी तरह अपारदर्शी बनाता है; [add_alpha_floor_effect](https://reference.aspose.com/slides/hi/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_floor_effect/) जो 100 % से नीचे के सभी अल्फ़ा को पूरी तरह पारदर्शी बनाता है; और [add_alpha_inverse_effect](https://reference.aspose.com/slides/hi/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_inverse_effect/) जो अल्फ़ा को `100% - alpha` में बदलता है।

## **क्रमबद्ध प्रभाव श्रृंखला बनाएं**

हर `add_..._effect` विधि संग्रह के अंत में एक नया ऑपरेशन जोड़ती है। रेंडरर संग्रह को क्रमबद्ध पाइपलाइन के रूप में उपयोग करता है: ऑपरेशन 0 का आउटपुट ऑपरेशन 1 का इनपुट बन जाता है, आदि। इस कारण समान ऑपरेशनों का क्रम बदलने से अलग‑अलग छवि बन सकती है।

उदाहरण के तौर पर, ग्रेस्केल के बाद टिंट लागू करने से पहले क्रोमैटिक जानकारी हटती है और बाद में ल्यूमिनेंस परिणाम को पुनः रंगित किया जाता है। टिंट के बाद ग्रेस्केल करने से टिंट फिर से हट जाता है। इसी प्रकार, अल्फ़ा प्रतिस्थापन पहले के ऑपरेशनों द्वारा गणना किए गए अल्फ़ा मानों को ओवरराइड कर सकता है, जबकि अल्फ़ा मॉड्यूलेशन उनके सापेक्ष अंतर को बनाए रखता है।

निम्न उदाहरण चार‑ऑपरेशन श्रृंखला बनाता है, उसे PPTX के रूप में सहेजता है, प्रस्तुति को पुनः खोलता है, दोनों ऑपरेशन प्रकार और उनका क्रम जाँचता है, तथा पुनः खोलने के बाद परिणाम रेंडर करता है:

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

संग्रह कोई ऐसी संगतता मैट्रिक्स लागू नहीं करता जो रंग, अल्फ़ा और ब्लर ऑपरेशनों को अलग‑अलग श्रृंखलाओं में सीमित करे। इन्हें मिलाया जा सकता है, परंतु सभी संयोजन उपयोगी नहीं होते। स्थिर रंग प्रतिस्थापन पहले के रंग प्रभावों द्वारा उत्पन्न RGB विविधता को हटा देता है; डुओटोन के बाद ग्रेस्केल दो चयनित रंगों को हटा देता है; और अल्फ़ा ceiling, floor, replacement या bi‑level ऑपरेशन पहले निर्मित अल्फ़ा विवरण को हटा सकते हैं। श्रृंखला को इच्छित पिक्सेल‑प्रसंस्करण क्रम के अनुसार बनाएँ, न कि आइटम को अनक्रमित फ़ॉर्मेटिंग फ्लैग मानकर।

## **संपादन‑योग्य और प्रभावी मान निरीक्षण करें**

एक संपादन‑योग्य ऑपरेशन वह वस्तु है जो `Picture.image_transform` में संग्रहीत होती है। प्रभाव के आधार पर यह सीधे लिखने‑योग्य सदस्य उजागर कर सकता है। उदाहरण के लिए, [Blur](https://reference.aspose.com/slides/hi/python-net/aspose.slides.effects/blur/) लिखने‑योग्य `radius` और `grow` गुण उजागर करता है, [AlphaModulateFixed](https://reference.aspose.com/slides/hi/python-net/aspose.slides.effects/alphamodulatefixed/) लिखने‑योग्य `amount` गुण उजागर करता है, और [AlphaBiLevel](https://reference.aspose.com/slides/hi/python-net/aspose.slides.effects/alphabilevel/) लिखने‑योग्य `threshold` गुण उजागर करता है। [Duotone](https://reference.aspose.com/slides/hi/python-net/aspose.slides.effects/duotone/) जैसे रंग प्रभाव परिवर्तनशील [ColorFormat](https://reference.aspose.com/slides/hi/python-net/aspose.slides/colorformat/) वस्तुएँ उजागर करते हैं।

कुछ ऑपरेशन, जिसमें [BrightnessContrast](https://reference.aspose.com/slides/hi/python-net/aspose.slides.effects/brightnesscontrast/), [HSL](https://reference.aspose.com/slides/hi/python-net/aspose.slides.effects/hsl/), [Tint](https://reference.aspose.com/slides/hi/python-net/aspose.slides.effects/tint/), और [AlphaReplace](https://reference.aspose.com/slides/hi/python-net/aspose.slides.effects/alphareplace/) शामिल हैं, अपनी रचना स्केलर्स को लिखने‑योग्य गुण के रूप में उजागर नहीं करते। इन सेटिंग्स को बदलने के लिए उस ऑपरेशन को हटाएँ और आवश्यक स्थिति में एक नया जोड़ें।

`get_effective()` द्वारा लौटाया गया प्रभावी डेटा गणना किया गया और केवल‑पढ़ने‑योग्य होता है। यह थीम‑निर्भर रंगों को हल करने तथा रेंडरर द्वारा उपयोग किए गए सामान्यीकृत मान पढ़ने में उपयोगी है, परंतु यह एक अतिरिक्त संपादन सतह नहीं है। निम्न उदाहरण श्रृंखला को क्रमबद्ध करता है और जहाँ संबंधित API उपलब्ध है, वहाँ प्रभावी मानों का निरीक्षण करता है:

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

पैरामीटर‑रहित प्रभाव जैसे ग्रेस्केल, अल्फ़ा ceiling, और अल्फ़ा inverse भी एक प्रभावी‑डेटा वस्तु रखते हैं, परन्तु प्रिंट करने के लिये कोई स्केलर सेटिंग नहीं होती। उनका संग्रह में उपस्थित होना और स्थिति ही महत्वपूर्ण जानकारी है।

## **छवि रूपांतरण हटाएँ या साफ़ करें**

एक ऑपरेशन को इंडेक्स द्वारा हटाने के लिए [ImageTransformOperationCollection.remove_at](https://reference.aspose.com/slides/hi/python-net/aspose.slides.effects/imagetransformoperationcollection/remove_at/) उपयोग करें। क्योंकि हटाने के बाद इंडेक्स बदलते हैं, पहले लक्ष्य को खोजें और क्रमबद्ध करने के बाद उसे हटाएँ। संपूर्ण श्रृंखला को हटाने के लिये `clear()` उपयोग रखें।

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

रूपांतरण हटाने या साफ़ करने से केवल चित्र फ़ॉर्मेटिंग बदलती है। यह पुनः उपयोग किए गए [PPImage](https://reference.aspose.com/slides/hi/python-net/aspose.slides/ppimage/) संसाधन को नहीं हटाता, संपीड़ित नहीं करता, या अन्यथा बदलता नहीं है।

## **प्रस्तुति स्वरूप और निर्यात लक्ष्यों पर विचार करें**

छवि रूपांतरण DrawingML में उत्पन्न होते हैं, इसलिए PPTX प्रभाव श्रृंखलाओं के लिये प्राथमिक संपादन‑योग्य स्वरूप है। PPTX के साथ भी सभी ऑपरेशन समान पोर्टेबिलिटी नहीं रखते:

- मानक DrawingML ऑपरेशन जैसे ल्यूमिनेंस, ग्रेस्केल, डुओटोन, टिंट, HSL, ब्लर, और सामान्य अल्फ़ा ऑपरेशन PPTX राउंड‑ट्रिप में बने रहने की सबसे अच्छी संभावना रखते हैं। जब संरक्षण आवश्यक हो तो हमेशा उत्पन्न फ़ाइल को पुनः खोलें और संग्रह की जाँच करें।
- [BrightnessContrast](https://reference.aspose.com/slides/hi/python-net/aspose.slides.effects/brightnesscontrast/) Office 2010 विस्तार है, न कि मानक DrawingML ल्यूमिनेंस ऑपरेशन। इसे मेमोरी‑में रेंडरिंग के लिये उपयोग किया जा सकता है, परंतु PPTX सहेजने और पुनः खोलने के बाद यह `BrightnessContrast` ऑपरेशन के रूप में संपादन‑योग्य नहीं रह सकता। स्थायी उज्ज्वलता और कंट्रास्ट समायोजन के लिये [add_luminance_effect](https://reference.aspose.com/slides/hi/python-net/aspose.slides.effects/imagetransformoperationcollection/add_luminance_effect/) को प्राथमिकता दें।
- बाइनरी PPT स्वरूप पूर्ण DrawingML प्रभाव मॉडल से पूर्व है। PPT में सहेजने से असमर्थित ऑपरेशन छोड़ दिए जा सकते हैं, श्रृंखला को समर्थित उपसमुच्चय में घटाया जा सकता है, या स्वरूपण का अनुमान लगाया जा सकता है। जटिल संपादन‑योग्य श्रृंखला के लिये PPT को सत्यापन स्वरूप के रूप में उपयोग न करें।
- PNG, JPEG, TIFF, PDF, SVG, HTML या अन्य दृश्य आउटपुट स्वरूपों में रेंडरिंग समर्थित श्रृंखला को रेंडर किए गए दृश्य पर लागू करता है। इन आउटपुट में संपादन‑योग्य `ImageTransformOperationCollection` नहीं होता; रास्टर स्वरूप परिणाम को पिक्सेल में समेटते हैं, और दस्तावेज़ या वेक्टर निर्यात अपनी स्वयं की रेंडरिंग प्रतिनिधित्व संग्रहीत करते हैं।
- प्रभाव लिंक्ड छवि को स्व-समावेशी नहीं बनाते। लिंक्ड चित्र को रेंडर करने के लिये प्रस्तुति लोड होने पर लिंक्ड संसाधन उपलब्ध होना आवश्यक है।

विभिन्न प्रस्तुति उपभोक्ता किनारे के मामलों को अलग‑अलग रेंडर कर सकते हैं, विशेषकर जब कई अल्फ़ा या रंग‑क्वॉन्टाइज़िंग ऑपरेशन संयोजित हों। महत्वपूर्ण आउटपुट के लिये, समान Aspose.Slides संस्करण के साथ संपादन‑योग्य राउंड‑ट्रिप और अंतिम निर्यात स्वरूप दोनों का परीक्षण करें।

## **बार‑बार पूछे जाने वाले प्रश्न**

**क्या छवि रूपांतरण प्रभाव एम्बेडेड छवि डेटा को संशोधित करते हैं?**

नहीं। ऑपरेशन `Picture` से संबंधित होते हैं जो चित्र फ़िल का उपयोग करता है। अंतर्निहित `PPImage` बाइट्स अपरिवर्तित रहती हैं।

**क्या दो चित्र फ़्रेम जो एक ही छवि को पुनः उपयोग करते हैं, अपने प्रभाव साझा करेंगे?**

नहीं। `PPImage` को पुनः उपयोग करने से duplicated छवि डेटा बचता है, परंतु प्रत्येक चित्र फ़्रेम आमतौर पर एक अलग `Picture` और अलग छवि रूपांतरण संग्रह रखता है।

**क्या रंग, ब्लर और अल्फ़ा प्रभावों को संयोजित किया जा सकता है?**

हाँ। संग्रह उन्हें एक क्रमबद्ध श्रृंखला में स्वीकार करता है। प्रत्येक ऑपरेशन के पिछले आउटपुट पर प्रभाव को ध्यान में रखें, क्योंकि प्रतिस्थापन और थ्रेशहोल्ड ऑपरेशन पहले के रंग या अल्फ़ा विवरण को हटा सकते हैं।

**प्रभावी मान केवल‑पढ़ने‑योग्य क्यों होते हैं?**

प्रभावी डेटा रेंडरिंग के लिये उपयोग किए गए गणना किए गए मानों को दर्शाता है, जिसमें समाधान‑शुदा रंग शामिल हैं। लिखने‑योग्य गुण मौजूद होने पर संग्रह में संग्रहीत ऑपरेशन को संपादित करें; अन्यथा उसे हटाएँ और नई निर्माण पैरामीटर के साथ प्रतिस्थापन जोड़ें।

**कौन‑सा स्वरूप रूपांतरण श्रृंखला को संरक्षित रखने के लिये उपयोग करना चाहिए?**

PPTX उपयोग करें और फ़ाइल को पुनः खोलकर सत्यापित करें। पुराना PPT पूर्ण DrawingML प्रभाव मॉडल को नहीं दर्शा सकता, और निर्यात स्वरूप केवल उपस्थिति को संरक्षित करते हैं, न कि संपादन‑योग्य रूपांतरण ऑपरेशन को।