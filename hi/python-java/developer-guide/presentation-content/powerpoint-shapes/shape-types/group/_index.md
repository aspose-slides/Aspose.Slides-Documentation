---
title: Python के माध्यम से Java में समूह प्रस्तुति आकृतियाँ
linktitle: आकृति समूह
type: docs
weight: 40
url: /hi/python-java/group/
keywords:
- समूह आकृति
- आकृति समूह
- समूह जोड़ें
- वैकल्पिक पाठ
- PowerPoint
- प्रस्तुतीकरण
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via Java का उपयोग करके PowerPoint डेक में आकृतियों को समूहित और अनसमूहित करना सीखें—एक चरण-दर-चरण मार्गदर्शिका जिसमें मुफ्त Python कोड शामिल है।"
---
## **सारांश**

यह लेख Aspose.Slides में समूह आकृतियों के साथ काम करने के तरीकों को समझाता है। यह दिखाता है कि एक स्लाइड में समूह आकृति कैसे जोड़ी जाए, उसके भीतर आकृतियाँ कैसे रखी जाएँ, और अपडेटेड प्रस्तुतिकरण को कैसे सहेजा जाए। यह समूह के भीतर संग्रहीत आकृतियों तक पहुंचने और उनके वैकल्पिक पाठ को [getAlternativeText](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shape/#getAlternativeText) के माध्यम से पढ़ने का भी प्रदर्शन करता है। अतिरिक्त रूप से, यह लेख नेस्टेड समूह, Z‑order और लॉकिंग विकल्प जैसी संबंधित समूह‑आकृति क्षमताओं को संक्षेप में कवर करता है।

## **समूह आकृति जोड़ें**

Aspose.Slides स्लाइडों पर समूह आकृतियों के साथ काम करने का समर्थन करता है। यह सुविधा डेवलपर्स को अधिक समृद्ध प्रस्तुतिकरण बनाने में मदद करती है। Aspose.Slides for Python via Java समूह आकृतियों को जोड़ने और पहुँचने का समर्थन करता है। आप समूह आकृति में आकृतियों को जोड़ सकते हैं या उसकी गुणधर्मों तक पहुँच सकते हैं। Aspose.Slides for Python via Java का उपयोग करके स्लाइड में समूह आकृति जोड़ने के लिए:

1. [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएँ।
1. उसके इंडेक्स द्वारा स्लाइड का संदर्भ प्राप्त करें।
1. स्लाइड में एक समूह आकृति जोड़ें।
1. समूह आकृति में आकृतियाँ जोड़ें।
1. संशोधित प्रस्तुतिकरण को PPTX फाइल के रूप में सहेजें।

नीचे दिया गया उदाहरण स्लाइड में समूह आकृति जोड़ता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, Presentation, SaveFormat, ShapeFrame, ShapeType

# Presentation क्लास को इंस्टैंसिएट करें.
presentation = Presentation()
try:
    # पहली स्लाइड प्राप्त करें.
    slide = presentation.getSlides().get_Item(0)

    # स्लाइड के शेप कलेक्शन तक पहुंचें.
    slide_shapes = slide.getShapes()

    # स्लाइड में एक समूह आकृति जोड़ें.
    group_shape = slide_shapes.addGroupShape()

    # समूह आकृति के भीतर आकृतियाँ जोड़ें.
    group_shape.getShapes().addAutoShape(ShapeType.Rectangle, 300, 100, 100, 100)
    group_shape.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 100, 100)
    group_shape.getShapes().addAutoShape(ShapeType.Rectangle, 300, 300, 100, 100)
    group_shape.getShapes().addAutoShape(ShapeType.Rectangle, 500, 300, 100, 100)

    # समूह आकृति का फ्रेम सेट करें.
    group_frame = ShapeFrame(100, 300, 500, 40, NullableBool.False_, NullableBool.False_, 0)
    group_shape.setFrame(group_frame)

    # PPTX फाइल को डिस्क पर लिखें.
    presentation.save("GroupShape.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **वैकल्पिक पाठ तक पहुंचें**

यह अनुभाग समूह के भीतर स्थित आकृतियों के वैकल्पिक पाठ तक कैसे पहुंचा जाए, यह दर्शाता है। Aspose.Slides for Python via Java का उपयोग करके इस पाठ को प्राप्त करने के लिए:

1. PPTX फाइल का प्रतिनिधित्व करने वाली [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास को इंस्टैंसिएट करें।
1. उसके इंडेक्स द्वारा स्लाइड का संदर्भ प्राप्त करें।
1. स्लाइड के शेप कलेक्शन तक पहुंचें।
1. समूह आकृति तक पहुंचें।
1. उसके आकृतियों का वैकल्पिक पाठ [getAlternativeText](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shape/#getAlternativeText) के माध्यम से पढ़ें।

नीचे दिया गया उदाहरण समूह के भीतर की आकृतियों के वैकल्पिक पाठ तक पहुंचता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import GroupShape, Presentation

# PPTX फ़ाइल को दर्शाने वाली Presentation क्लास को इंस्टैंसिएट करें.
presentation = Presentation("AltText.pptx")
try:
    # पहली स्लाइड प्राप्त करें.
    slide = presentation.getSlides().get_Item(0)

    for i in range(slide.getShapes().size()):
        # स्लाइड के आकार संग्रह में एक आकार तक पहुंचें.
        shape = slide.getShapes().get_Item(i)

        if isinstance(shape, GroupShape):
            # समूह के भीतर की आकृतियों तक पहुंचें.
            for j in range(shape.getShapes().size()):
                child_shape = shape.getShapes().get_Item(j)

                # वैकल्पिक पाठ पढ़ें.
                print(child_shape.getAlternativeText())
finally:
    presentation.dispose()
```

## **FAQ**

**क्या नेस्टेड ग्रुपिंग (एक समूह के भीतर दूसरा समूह) समर्थित है?**

हां। [GroupShape](https://reference.aspose.com/slides/hi/python-java/aspose.slides/groupshape/) में एक [getParentGroup](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shape/#getParentGroup) मेथड है, जो पदानुक्रम समर्थन को दर्शाता है: एक समूह दूसरे समूह का चाइल्ड हो सकता है।

**मैं स्लाइड पर अन्य वस्तुओं की तुलना में समूह के Z‑order को कैसे नियंत्रित करूं?**

[GroupShape](https://reference.aspose.com/slides/hi/python-java/aspose.slides/groupshape/) ऑब्जेक्ट की [getZOrderPosition](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shape/#getZOrderPosition) मेथड का उपयोग करके उसकी डिस्प्ले स्टैक में स्थिति का निरीक्षण करें।

**क्या मैं समूह को स्थानांतरित, संपादित या अनग्रुप करने से रोक सकता हूँ?**

हां। समूह के लॉक को [getGroupShapeLock](https://reference.aspose.com/slides/hi/python-java/aspose.slides/groupshape/#getGroupShapeLock) के माध्यम से एक्सपोज़ किया गया है, जिससे आप ऑब्जेक्ट पर संचालन को प्रतिबंधित कर सकते हैं।