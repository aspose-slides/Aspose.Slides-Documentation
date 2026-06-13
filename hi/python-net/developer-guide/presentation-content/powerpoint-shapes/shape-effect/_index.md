---
title: Python के साथ प्रस्तुतियों में आकार प्रभाव लागू करें
linktitle: आकार प्रभाव
type: docs
weight: 30
url: /hi/python-net/shape-effect
keywords:
- आकार प्रभाव
- छाया प्रभाव
- परावर्तन प्रभाव
- ग्लो प्रभाव
- नरम किनारा प्रभाव
- प्रभाव प्रारूप
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides for Python का उपयोग करके उन्नत आकार प्रभावों से अपने PPT, PPTX और ODP फाइलों को बदलें—सेकंड में प्रभावशाली, पेशेवर स्लाइड बनाएं।"
---
## **परिचय**

जबकि PowerPoint में इफ़ेक्ट्स का उपयोग किसी आकार को प्रमुख बनाने के लिए किया जा सकता है, ये [भरण](/slides/hi/python-net/shape-formatting/#gradient-fill) या आउटलाइन से अलग होते हैं। PowerPoint इफ़ेक्ट्स का उपयोग करके आप किसी आकार पर विश्वसनीय प्रतिबिंब बना सकते हैं, आकार की चमक फैल सकती है, आदि।

<img src="shape-effect.png" alt="shape-effect" style="zoom:50%;" />

* PowerPoint आकारों पर लागू होने वाले छह इफ़ेक्ट्स प्रदान करता है। आप एक आकार पर एक या अधिक इफ़ेक्ट्स लागू कर सकते हैं।  
* कुछ इफ़ेक्ट संयोजन अन्य की तुलना में बेहतर दिखते हैं। इसलिए, PowerPoint विकल्प **Preset** के तहत होते हैं। प्रीसेट विकल्प मूलतः दो या अधिक इफ़ेक्ट्स के एक ज्ञात सुंदर संयोजन होते हैं। इस प्रकार, कोई प्रीसेट चुनने से आपको विभिन्न इफ़ेक्ट्स का परीक्षण या संयोजन करने में समय बर्बाद नहीं करना पड़ेगा।

Aspose.Slides [EffectFormat](https://reference.aspose.com/slides/hi/python-net/aspose.slides/effectformat/) वर्ग के तहत प्रॉपर्टी और मेथड प्रदान करता है जो आपको PowerPoint प्रस्तुतियों में आकारों पर वही इफ़ेक्ट्स लागू करने की अनुमति देते हैं।

## **छाया इफ़ेक्ट लागू करें**

यह Python कोड दिखाता है कि कैसे आयत पर बाहरी छाया इफ़ेक्ट (`outer_shadow_effect`) लागू किया जाए:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 150)

    shape.effect_format.enable_outer_shadow_effect()
    shape.effect_format.outer_shadow_effect.shadow_color.color = draw.Color.dark_gray
    shape.effect_format.outer_shadow_effect.distance = 10
    shape.effect_format.outer_shadow_effect.direction = 45

    pres.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **परावर्तन इफ़ेक्ट लागू करें**

यह Python कोड दिखाता है कि कैसे किसी आकार पर परावर्तन इफ़ेक्ट लागू किया जाए:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 150)

    shape.effect_format.enable_reflection_effect()
    shape.effect_format.reflection_effect.rectangle_align = slides.RectangleAlignment.BOTTOM
    shape.effect_format.reflection_effect.direction = 90
    shape.effect_format.reflection_effect.distance = 55
    shape.effect_format.reflection_effect.blur_radius = 4

    pres.save("reflection.pptx", slides.export.SaveFormat.PPTX)
```

## **ग्लो इफ़ेक्ट लागू करें**

यह Python कोड दिखाता है कि कैसे किसी आकार पर ग्लो इफ़ेक्ट लागू किया जाए:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 150)

    shape.effect_format.enable_glow_effect()
    shape.effect_format.glow_effect.color.color = draw.Color.magenta
    shape.effect_format.glow_effect.radius = 15

    pres.save("glow.pptx", slides.export.SaveFormat.PPTX)
```

## **सॉफ्ट एजेज़ इफ़ेक्ट लागू करें**

यह Python कोड दिखाता है कि कैसे किसी आकार पर सॉफ्ट एजेज़ इफ़ेक्ट लागू किया जाए:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 150)

    shape.effect_format.enable_soft_edge_effect()
    shape.effect_format.soft_edge_effect.radius = 15

    pres.save("softEdges.pptx", slides.export.SaveFormat.PPTX)
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं एक ही आकार पर कई इफ़ेक्ट्स लागू कर सकता हूँ?**

हाँ, आप किसी एक आकार पर विभिन्न इफ़ेक्ट्स, जैसे छाया, परावर्तन और ग्लो, को संयोजित करके अधिक गतिशील रूप बना सकते हैं।

**मैं किन आकारों पर इफ़ेक्ट्स लागू कर सकता हूँ?**

आप विभिन्न आकारों पर इफ़ेक्ट्स लागू कर सकते हैं, जिसमें ऑटॉशेप, चार्ट, टेबल, चित्र, SmartArt ऑब्जेक्ट, OLE ऑब्जेक्ट आदि शामिल हैं।

**क्या मैं समूहित आकारों पर इफ़ेक्ट्स लागू कर सकता हूँ?**

हाँ, आप समूहित आकारों पर इफ़ेक्ट्स लागू कर सकते हैं। इफ़ेक्ट पूरी समूह पर लागू होगा।