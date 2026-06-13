---
title: Python में प्रस्तुति पृष्ठभूमियों को प्रबंधित करें
linktitle: स्लाइड पृष्ठभूमि
type: docs
weight: 20
url: /hi/python-net/presentation-background/
keywords:
- प्रस्तुति पृष्ठभूमि
- स्लाइड पृष्ठभूमि
- सॉलिड रंग
- ग्रेडिएंट रंग
- छवि पृष्ठभूमि
- पृष्ठभूमि पारदर्शिता
- पृष्ठभूमि गुण
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET का उपयोग करके PowerPoint और OpenDocument फ़ाइलों में गतिशील पृष्ठभूमि सेट करना सीखें, कोड टिप्स के साथ अपने प्रस्तुतियों को बेहतर बनाएं।"
---
## **परिचय**

सॉलिड रंग, ग्रेडिएंट, और छवियां आमतौर पर स्लाइड पृष्ठभूमि के लिए उपयोग की जाती हैं। आप **सामान्य स्लाइड** (एक अकेली स्लाइड) या **मास्टर स्लाइड** (एक साथ कई स्लाइड पर लागू) के लिए पृष्ठभूमि सेट कर सकते हैं।

![PowerPoint background](powerpoint-background.png)

## **सामान्य स्लाइड के लिए सॉलिड रंग पृष्ठभूमि सेट करें**

Aspose.Slides आपको प्रस्तुति में किसी विशिष्ट स्लाइड के लिए पृष्ठभूमि के रूप में सॉलिड रंग सेट करने देता है—भले ही प्रस्तुति में मास्टर स्लाइड उपयोग हो। परिवर्तन केवल चयनित स्लाइड पर लागू होता है।

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास का इंस्टेंस बनाएं।
2. स्लाइड के [BackgroundType](https://reference.aspose.com/slides/hi/python-net/aspose.slides/backgroundtype/) को `OWN_BACKGROUND` सेट करें।
3. स्लाइड पृष्ठभूमि के [FillType](https://reference.aspose.com/slides/hi/python-net/aspose.slides/filltype/) को `SOLID` सेट करें।
4. [FillFormat](https://reference.aspose.com/slides/hi/python-net/aspose.slides/fillformat/) पर `solid_fill_color` प्रॉपर्टी का उपयोग करके सॉलिड पृष्ठभूमि रंग निर्दिष्ट करें।
5. परिवर्तित प्रस्तुति सहेजें।

निम्नलिखित Python उदाहरण दिखाता है कि सामान्य स्लाइड के लिए नीला सॉलिड रंग पृष्ठभूमि कैसे सेट किया जाए:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Presentation क्लास का एक उदाहरण बनाएं।
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # स्लाइड की पृष्ठभूमि का रंग नीला सेट करें।
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.blue

    # प्रस्तुति को डिस्क पर सहेजें।
    presentation.save("SolidColorBackground.pptx", slides.export.SaveFormat.PPTX)
```

## **मास्टर स्लाइड के लिए सॉलिड रंग पृष्ठभूमि सेट करें**

Aspose.Slides आपको प्रस्तुति में मास्टर स्लाइड के लिए पृष्ठभूमि के रूप में सॉलिड रंग सेट करने देता है। मास्टर स्लाइड सभी स्लाइडों के फॉर्मेट को नियंत्रित करने वाला टेम्पलेट है, इसलिए जब आप मास्टर स्लाइड की पृष्ठभूमि के लिए सॉलिड रंग चुनते हैं, तो वह हर स्लाइड पर लागू होता है।

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास का इंस्टेंस बनाएं।
2. मास्टर स्लाइड के [BackgroundType](https://reference.aspose.com/slides/hi/python-net/aspose.slides/backgroundtype/) (`masters` के माध्यम से) को `OWN_BACKGROUND` सेट करें।
3. मास्टर स्लाइड पृष्ठभूमि के [FillType](https://reference.aspose.com/slides/hi/python-net/aspose.slides/filltype/) को `SOLID` सेट करें।
4. [FillFormat](https://reference.aspose.com/slides/hi/python-net/aspose.slides/fillformat/) पर `solid_fill_color` प्रॉपर्टी का उपयोग करके सॉलिड पृष्ठभूमि रंग निर्दिष्ट करें।
5. परिवर्तित प्रस्तुति सहेजें।

निम्नलिखित Python उदाहरण दिखाता है कि मास्टर स्लाइड की पृष्ठभूमि के लिए सॉलिड रंग (फॉरेस्ट ग्रीन) कैसे सेट किया जाए:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Presentation क्लास का एक उदाहरण बनाएं।
with slides.Presentation() as presentation:
    master_slide = presentation.masters[0]

    # मास्टर स्लाइड की पृष्ठभूमि का रंग फॉरेस्ट ग्रीन सेट करें।
    master_slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    master_slide.background.fill_format.fill_type = slides.FillType.SOLID
    master_slide.background.fill_format.solid_fill_color.color = draw.Color.forest_green

    # प्रस्तुति को डिस्क पर सहेजें।
    presentation.save("MasterSlideBackground.pptx", slides.export.SaveFormat.PPTX)
```

## **स्लाइड के लिए ग्रेडिएंट पृष्ठभूमि सेट करें**

ग्रेडिएंट एक ग्राफिकल प्रभाव है जो रंग के क्रमिक परिवर्तन से बनता है। जब स्लाइड पृष्ठभूमि के रूप में उपयोग किया जाता है, तो ग्रेडिएंट प्रस्तुति को अधिक कलात्मक और पेशेवर बना सकते हैं। Aspose.Slides आपको स्लाइडों के लिए पृष्ठभूमि के रूप में ग्रेडिएंट रंग सेट करने देता है।

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास का इंस्टेंस बनाएं।
2. स्लाइड के [BackgroundType](https://reference.aspose.com/slides/hi/python-net/aspose.slides/backgroundtype/) को `OWN_BACKGROUND` सेट करें।
3. स्लाइड पृष्ठभूमि के [FillType](https://reference.aspose.com/slides/hi/python-net/aspose.slides/filltype/) को `GRADIENT` सेट करें।
4. [FillFormat](https://reference.aspose.com/slides/hi/python-net/aspose.slides/fillformat/) पर `gradient_format` प्रॉपर्टी का उपयोग करके अपनी पसंदीदा ग्रेडिएंट सेटिंग्स कॉन्फ़िगर करें।
5. परिवर्तित प्रस्तुति सहेजें।

निम्नलिखित Python उदाहरण दिखाता है कि स्लाइड की पृष्ठभूमि के लिए ग्रेडिएंट रंग कैसे सेट किया जाए:

```python
import aspose.slides as slides

# Presentation क्लास का एक उदाहरण बनाएं।
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # पृष्ठभूमि पर ग्रेडिएंट इफ़ेक्ट लागू करें।
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.GRADIENT
    slide.background.fill_format.gradient_format.tile_flip = slides.TileFlip.FLIP_BOTH

    # प्रस्तुति को डिस्क पर सहेजें।
    presentation.save("GradientBackground.pptx", slides.export.SaveFormat.PPTX)
```

## **स्लाइड पृष्ठभूमि के रूप में छवि सेट करें**

सॉलिड और ग्रेडिएंट फ़िल्स के अतिरिक्त, Aspose.Slides आपको स्लाइड पृष्ठभूमि के रूप में छवियों का उपयोग करने देता है।

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास का इंस्टेंस बनाएं।
2. स्लाइड के [BackgroundType](https://reference.aspose.com/slides/hi/python-net/aspose.slides/backgroundtype/) को `OWN_BACKGROUND` सेट करें।
3. स्लाइड पृष्ठभूमि के [FillType](https://reference.aspose.com/slides/hi/python-net/aspose.slides/filltype/) को `PICTURE` सेट करें।
4. स्लाइड पृष्ठभूमि के रूप में उपयोग करने हेतु छवि लोड करें।
5. छवि को प्रस्तुति के इमेज कलेक्शन में जोड़ें।
6. [FillFormat](https://reference.aspose.com/slides/hi/python-net/aspose.slides/fillformat/) पर `picture_fill_format` प्रॉपर्टी का उपयोग करके छवि को पृष्ठभूमि के रूप में असाइन करें।
7. परिवर्तित प्रस्तुति सहेजें।

निम्नलिखित Python उदाहरण दिखाता है कि स्लाइड की पृष्ठभूमि के रूप में छवि कैसे सेट करें:

```python
import aspose.slides as slides

# Presentation क्लास का एक उदाहरण बनाएं।
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # पृष्ठभूमि छवि गुण सेट करें।
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.PICTURE
    slide.background.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH

    # छवि लोड करें।
    with slides.Images.from_file("Tulips.jpg") as image:
        # छवि को प्रस्तुति की छवि संग्रह में जोड़ें।
        pp_image = presentation.images.add_image(image)

    slide.background.fill_format.picture_fill_format.picture.image = pp_image

    # प्रस्तुति को डिस्क पर सहेजें।
    presentation.save("ImageAsBackground.pptx", slides.export.SaveFormat.PPTX)
```

निम्नलिखित कोड नमूना दिखाता है कि पृष्ठभूमि फ़िल टाइप को टाइल्ड चित्र पर सेट कैसे करें और टाइलिंग गुणों को कैसे संशोधित करें:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:

    first_slide = presentation.slides[0]

    background = first_slide.background

    background.type = slides.BackgroundType.OWN_BACKGROUND
    background.fill_format.fill_type = slides.FillType.PICTURE

    with slides.Images.from_file("image.png") as new_image:
        pp_image = presentation.images.add_image(new_image)

    # पृष्ठभूमि फ़िल के लिए उपयोग की जाने वाली छवि सेट करें।
    back_picture_fill_format = background.fill_format.picture_fill_format
    back_picture_fill_format.picture.image = pp_image

    # चित्र फ़िल मोड को टाइल पर सेट करें और टाइल गुण समायोजित करें।
    back_picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE
    back_picture_fill_format.tile_offset_x = 15.0
    back_picture_fill_format.tile_offset_y = 15.0
    back_picture_fill_format.tile_scale_x = 46.0
    back_picture_fill_format.tile_scale_y = 87.0
    back_picture_fill_format.tile_alignment = slides.RectangleAlignment.CENTER
    back_picture_fill_format.tile_flip = slides.TileFlip.FLIP_Y

    presentation.save("TileBackground.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="primary" %}}
और पढ़ें: [**टाइल चित्र को टेक्सचर के रूप में**](/slides/hi/python-net/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **पृष्ठभूमि छवि की पारदर्शिता बदलें**

आप स्लाइड की पृष्ठभूमि छवि की पारदर्शिता को समायोजित करना चाह सकते हैं जिससे स्लाइड की सामग्री उभरे। निम्नलिखित Python कोड दिखाता है कि स्लाइड पृष्ठभूमि छवि की पारदर्शिता कैसे बदलें:

```python
transparency_value = 30  # उदाहरण के लिए।

# picture transform ऑपरेशनों का संग्रह प्राप्त करें।
image_transform = slide.background.fill_format.picture_fill_format.picture.image_transform

transparency_operation = None

# मौजूदा fixed-percentage ट्रांसपरेंसी इफ़ेक्ट खोजें।
for operation in image_transform:
    if type(operation) is slides.AlphaModulateFixed:
        transparency_operation = operation
        break

# नया ट्रांसपरेंसी मान सेट करें।
if transparency_operation is None:
    image_transform.add_alpha_modulate_fixed_effect(100 - transparency_value)
else:
    transparency_operation.amount = 100 - transparency_value
```

## **स्लाइड पृष्ठभूमि मान प्राप्त करें**

Aspose.Slides [IBackgroundEffectiveData](https://reference.aspose.com/slides/hi/python-net/aspose.slides/ibackgroundeffectivedata/) क्लास प्रदान करता है जो स्लाइड के प्रभावी पृष्ठभूमि मानों को प्राप्त करने के लिए है। यह क्लास प्रभावी [FillFormat](https://reference.aspose.com/slides/hi/python-net/aspose.slides/fillformat/) और [EffectFormat](https://reference.aspose.com/slides/hi/python-net/aspose.slides/effectformat/) को एक्सपोज़ करता है।

[BaseSlide](https://reference.aspose.com/slides/hi/python-net/aspose.slides/baseslide/) क्लास की `background` प्रॉपर्टी का उपयोग करके, आप स्लाइड के प्रभावी पृष्ठभूमि को प्राप्त कर सकते हैं।

निम्नलिखित Python उदाहरण दिखाता है कि स्लाइड का प्रभावी पृष्ठभूमि मान कैसे प्राप्त करें:

```python
import aspose.slides as slides

# Presentation क्लास का एक उदाहरण बनाएं।
with slides.Presentation("Sample.pptx") as presentation:
    slide = presentation.slides[0]

    # मास्टर, लेआउट और थीम को ध्यान में रखते हुए प्रभावी पृष्ठभूमि प्राप्त करें।
    effective_background = slide.background.get_effective()

    if effective_background.fill_format.fill_type == slides.FillType.SOLID:
        color = effective_background.fill_format.solid_fill_color
        print(f"Fill color: Color [A={color.a}, R={color.r}, G={color.g}, B={color.b}]")
    else:
        print("Fill type:", str(effective_background.fill_format.fill_type))
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं कस्टम पृष्ठभूमि रीसेट करके थीम/लेआउट पृष्ठभूमि को पुनर्स्थापित कर सकता हूँ?**

हाँ। स्लाइड की कस्टम फ़िल हटाएँ, और पृष्ठभूमि फिर से संबंधित [layout](/slides/hi/python-net/slide-layout/)/[master](/slides/hi/python-net/slide-master/) स्लाइड से विरासत में मिल जाएगी (अर्थात् [theme background](/slides/hi/python-net/presentation-theme/))।

**अगर मैं बाद में प्रस्तुति का थीम बदलूँ तो पृष्ठभूमि पर क्या प्रभाव पड़ेगा?**

यदि किसी स्लाइड की अपनी फ़िल है, तो वह अपरिवर्तित रहेगी। यदि पृष्ठभूमि [layout](/slides/hi/python-net/slide-layout/)/[master](/slides/hi/python-net/slide-master/) से विरासत में मिली है, तो वह [new theme](/slides/hi/python-net/presentation-theme/) के अनुसार अपडेट हो जाएगी।