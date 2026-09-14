---
title: "Python के माध्यम से Java में प्रस्तुति स्लाइड मास्टर्स को प्रबंधित करें"
linktitle: "स्लाइड मास्टर"
type: docs
weight: 70
url: /hi/python-java/slide-master/
keywords:
- "स्लाइड मास्टर"
- "मास्टर स्लाइड"
- "PPT मास्टर स्लाइड"
- "एकाधिक मास्टर स्लाइड्स"
- "मास्टर स्लाइड्स की तुलना"
- "पृष्ठभूमि"
- "प्लेसहोल्डर"
- "मास्टर स्लाइड क्लोन करें"
- "मास्टर स्लाइड कॉपी करें"
- "मास्टर स्लाइड डुप्लिकेट करें"
- "अप्रयुक्त मास्टर स्लाइड"
- "PowerPoint"
- "OpenDocument"
- "प्रस्तुति"
- "Python"
- "Java"
- "Aspose.Slides"
description: "Aspose.Slides for Python via Java में स्लाइड मास्टर्स को प्रबंधित करें: PowerPoint और OpenDocument प्रस्तुतियों में मास्टर स्लाइड्स तक पहुँचें, संपादित करें, क्लोन करें, तुलना करें और हटाएँ।"
---
## **परिचय**

एक **slide master** स्लाइड समूह के लिए साझा डिजाइन सेटिंग्स को परिभाषित करता है। इसमें सामान्य आकार, लोगो, पृष्ठभूमि, टेक्स्ट शैलियां, थीम सेटिंग्स, और फुटर सेटिंग्स हो सकते हैं। PowerPoint में, **slide master** को संपादित करना प्रस्तुति को सुसंगत रखने का सामान्य तरीका है, जिससे हर स्लाइड पर समान फ़ॉर्मेटिंग दोहराने की जरूरत नहीं पड़ती।

Aspose.Slides for Python via Java वही मॉडल सपोर्ट करता है। एक प्रस्तुति में एक या अधिक master slides हो सकते हैं, और प्रत्येक master slide में कई layout slides हो सकते हैं। सामान्य slides आमतौर पर सीधे master slide को संदर्भित नहीं करती। इसके बजाय, एक सामान्य slide एक layout slide का उपयोग करती है, और वह layout slide एक master slide से संबंधित होती है।

The hierarchy is:

1. **Slide master** - साझा डिजाइन और थीम को परिभाषित करता है।
1. **Layout slide** - प्लेसहोल्डर्स और लेआउट-स्तर फ़ॉर्मेटिंग की विशिष्ट व्यवस्था को परिभाषित करता है।
1. **Normal slide** - वास्तविक प्रस्तुति सामग्री रखता है और एक layout slide को उपयोग करता है।

![मास्टर स्लाइड, लेआउट स्लाइड, और सामान्य स्लाइड की पदानुक्रम](slide-master_2.jpg)

Aspose.Slides में, एक slide master को [MasterSlide](https://reference.aspose.com/slides/hi/python-java/aspose.slides/masterslide/) क्लास द्वारा दर्शाया जाता है। प्रस्तुति में सभी मास्टर स्लाइड्स [Presentation.getMasters](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#getMasters) कलेक्शन के माध्यम से उपलब्ध हैं, जो [MasterSlideCollection](https://reference.aspose.com/slides/hi/python-java/aspose.slides/masterslidecollection/) द्वारा प्रतिनिधित्व किया जाता है।

{{% alert color="info" title="Inheritance" %}}
जब एक ही प्रॉपर्टी एक से अधिक स्तर पर परिभाषित होती है, तो अधिक विशिष्ट स्तर जीतता है। उदाहरण के लिए, यदि एक master slide और एक layout slide दोनों बैकग्राउंड परिभाषित करते हैं, तो उस लेआउट पर आधारित स्लाइड्स लेआउट बैकग्राउंड का उपयोग करती हैं। लेआउट स्लाइड्स के बारे में अधिक जानकारी के लिए, देखें [Apply or Change Slide Layouts](/slides/hi/python-java/slide-layout/)।
{{% /alert %}}

## **स्लाइड मास्टर तक पहुंच**

PowerPoint में, आप **View** > **Slide Master** से स्लाइड मास्टर दृश्य खोल सकते हैं।

![PowerPoint View टैब पर स्लाइड मास्टर कमांड](slide-master_3.jpg)

Aspose.Slides में, master स्लाइड्स तक पहुंचने के लिए [Presentation.getMasters](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#getMasters) कलेक्शन का उपयोग करें:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    first_master_slide = presentation.getMasters().get_Item(0)
    master_slide_count = presentation.getMasters().size()
    first_master_layout_slide_count = first_master_slide.getLayoutSlides().size()

    print(f"Master slides: {master_slide_count}")
    print(f"Layouts in the first master: {first_master_layout_slide_count}")
finally:
    presentation.dispose()
```

आप सामान्य slide द्वारा उपयोग किए गए master slide को उसके लेआउट के माध्यम से भी प्राप्त कर सकते हैं:

```python
import jpime
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    layout_slide = slide.getLayoutSlide()
    master_slide = layout_slide.getMasterSlide()
    master_slide_name = master_slide.getName()

    print(master_slide_name)
finally:
    presentation.dispose()
```

## **स्लाइड मास्टर में क्या होता है**

एक master slide एक slide जैसी वस्तु है। यह [BaseSlide](https://reference.aspose.com/slides/hi/python-java/aspose.slides/baseslide/) से विरासत में लेता है, इसलिए यह सामान्य और layout slides द्वारा उपयोग किए जाने वाले कई समान slide प्रॉपर्टीज़ को उजागर करता है। master-विशिष्ट सदस्य [MasterSlide](https://reference.aspose.com/slides/hi/python-java/aspose.slides/masterslide/) API पेज पर सूचीबद्ध हैं।

आम तौर पर उपयोग किए जाने वाले master slide सदस्यों में शामिल हैं:

| सदस्य | उद्देश्य |
| --- | --- |
| [getBackground](https://reference.aspose.com/slides/hi/python-java/aspose.slides/baseslide/#getBackground) | मास्टर-स्तर की slide पृष्ठभूमि सेट करता है। |
| [getShapes](https://reference.aspose.com/slides/hi/python-java/aspose.slides/baseslide/#getShapes) | मास्टर पर रखे गए आकारों को संग्रहीत करता है, जैसे लोगो, चित्र फ़्रेम, और साझा टेक्स्ट। |
| [getLayoutSlides](https://reference.aspose.com/slides/hi/python-java/aspose.slides/masterslide/#getLayoutSlides) | मास्टर से संबंधित layout slides को संग्रहीत करता है। |
| [getThemeManager](https://reference.aspose.com/slides/hi/python-java/aspose.slides/masterslide/#getThemeManager) | मास्टर थीम API तक पहुंच प्रदान करता है। |
| [getHeaderFooterManager](https://reference.aspose.com/slides/hi/python-java/aspose.slides/masterslide/#getHeaderFooterManager) | मास्टर और उसकी चाइल्ड लेआउट्स के लिए हेडर, फुटर, तिथि, और slide नंबर को नियंत्रित करता है। |
| [getDependingSlides](https://reference.aspose.com/slides/hi/python-java/aspose.slides/masterslide/#getDependingSlides) | उन normal slides को लौटाता है जो लेआउट्स के माध्यम से master पर निर्भर करते हैं। |

## **स्लाइड मास्टर में छवि जोड़ें**

जब आप एक master slide में छवि जोड़ते हैं, तो यह उन स्लाइड्स में दिखाई देती है जो उस मास्टर के लेआउट का उपयोग करती हैं। यह लोगो, वॉटरमार्क, सजावटी बैंड, और अन्य दोहराए जाने वाले दृश्य तत्वों के लिए उपयोगी है।

निम्न उदाहरण पहली master slide में लोगो जोड़ता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat, ShapeType

presentation = Presentation("presentation.pptx")
try:
    master_slide = presentation.getMasters().get_Item(0)
    logo = Images.fromFile("logo.png")
    try:
        logo_image = presentation.getImages().addImage(logo)
        master_slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 80, 80, logo_image)
    finally:
        logo.dispose()

    presentation.save("presentation-with-logo.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Picture Frame के बारे में अधिक जानकारी के लिए देखें [Picture Frame](/slides/hi/python-java/picture-frame/)।

## **प्लेसहोल्डर्स के साथ काम करें**

प्लेसहोल्डर्स आमतौर पर layout slides पर परिभाषित होते हैं। master slide उन साझा शैली और थीम को प्रदान करता है जिन्हें लेआउट्स विरासत में लेते हैं, जबकि प्रत्येक लेआउट तय करता है कि कौन से प्लेसहोल्डर्स उपलब्ध हैं और उन्हें कहाँ रखा गया है।

PowerPoint में, प्लेसहोल्डर कमांड्स Slide Master दृश्य में उपलब्ध हैं।

![PowerPoint Slide Master दृश्य में Insert Placeholder कमांड](slide-master_5.png)

Aspose.Slides के साथ नए प्लेसहोल्डर्स जोड़ने के लिए, उस layout slide के साथ काम करें जो मास्टर से संबंधित है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideLayoutType

presentation = Presentation("presentation.pptx")
try:
    master_slide = presentation.getMasters().get_Item(0)
    blank_layout_slide = master_slide.getLayoutSlides().getByType(SlideLayoutType.Blank)

    if blank_layout_slide is None:
        blank_layout_slide = master_slide.getLayoutSlides().add(SlideLayoutType.Blank, "Blank")

    blank_layout_slide.getPlaceholderManager().addTextPlaceholder(60, 120, 600, 80)

    presentation.getSlides().addEmptySlide(blank_layout_slide)
    presentation.save("presentation-with-placeholder.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

आप master slide पर पहले से मौजूद प्लेसहोल्डर शैप्स को भी फॉर्मेट कर सकते हैं। निम्न उदाहरण शीर्षक प्लेसहोल्डर को ढूंढता है और एक रैखिक ग्रेडिएंट फ़िल लागू करता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, FillType, GradientShape, PlaceholderType, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

presentation = Presentation("presentation.pptx")
try:
    master_slide = presentation.getMasters().get_Item(0)
    title_placeholder = None

    for shape in master_slide.getShapes():
        if isinstance(shape, AutoShape):
            if shape.getPlaceholder() is not None and shape.getPlaceholder().getType() == PlaceholderType.Title:
                title_placeholder = shape
                break

    if title_placeholder is not None:
        red_gradient_color = Color(255, 0, 0)
        purple_gradient_color = Color(128, 0, 128)

        title_placeholder.getFillFormat().setFillType(FillType.Gradient)
        title_placeholder.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear)
        title_placeholder.getFillFormat().getGradientFormat().getGradientStops().add(jpype.JFloat(0.0), red_gradient_color)
        title_placeholder.getFillFormat().getGradientFormat().getGradientStops().add(jpype.JFloat(1.0), purple_gradient_color)

    presentation.save("presentation-title-style.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![सामान्य स्लाइड्स द्वारा विरासत में मिला फ़ॉर्मेट किया हुआ शीर्षक प्लेसहोल्डर](slide-master_8.png)

अधिक प्लेसहोल्डर और टेक्स्ट फ़ॉर्मेटिंग विकल्पों के लिए देखें [Set Prompt Text in Placeholder](/slides/hi/python-java/manage-placeholder/) और [Text Formatting](/slides/hi/python-java/text-formatting/)।

## **स्लाइड मास्टर पृष्ठभूमि बदलें**

एक मास्टर पृष्ठभूमि लेआउट्स और उन स्लाइड्स द्वारा विरासत में ली जाती है जो इसे ओवरराइड नहीं करते। निम्न उदाहरण पहली master slide के लिए एक ठोस पृष्ठभूमि रंग सेट करता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

presentation = Presentation("presentation.pptx")
try:
    master_slide = presentation.getMasters().get_Item(0)
    master_background_color = Color.GREEN

    master_slide.getBackground().setType(BackgroundType.OwnBackground)
    master_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    master_slide.getBackground().getFillFormat().getSolidFillColor().setColor(master_background_color)

    presentation.save("presentation-master-background.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

संबंधित विषयों के लिए देखें [Presentation Background](/slides/hi/python-java/presentation-background/) और [Presentation Theme](/slides/hi/python-java/presentation-theme/)।

## **एक स्लाइड मास्टर को दूसरे प्रस्तुति में क्लोन करें**

[MasterSlideCollection.addClone](https://reference.aspose.com/slides/hi/python-java/aspose.slides/masterslidecollection/#addClone) का उपयोग करके एक मास्टर स्लाइड को दूसरे प्रस्तुति में कॉपी करें। कॉपी किया गया मास्टर फिर लक्ष्य प्रस्तुति में लेआउट्स और स्लाइड्स द्वारा उपयोग किया जा सकता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

source_presentation = Presentation("source.pptx")
destination_presentation = Presentation("destination.pptx")
try:
    source_master_slide = source_presentation.getMasters().get_Item(0)
    cloned_master_slide = destination_presentation.getMasters().addClone(source_master_slide)

    destination_presentation.save("destination-with-master.pptx", SaveFormat.Pptx)
finally:
    source_presentation.dispose()
    destination_presentation.dispose()
```

यदि आपको उनके मास्टर के साथ सामान्य स्लाइड्स को भी क्लोन करने की आवश्यकता है, तो देखें [Clone Slides](/slides/hi/python-java/clone-slides/)।

## **एकसे अधिक स्लाइड मास्टर जोड़ें**

एक प्रस्तुति में कई master slides हो सकते हैं। यह तब उपयोगी होता है जब विभिन्न अनुभागों को अलग-अलग ब्रांडिंग, पृष्ठ संरचना, या थीम सेटिंग्स की आवश्यकता होती है।

![मास्टर स्लाइड्स डालने और प्रबंधित करने के लिए PowerPoint कमांड्स](slide-master_9.jpg)

निम्न उदाहरण डिफ़ॉल्ट मास्टर को क्लोन करता है, क्लोन को एक अलग पृष्ठभूमि देता है, उस क्लोन किए गए मास्टर के तहत एक लेआउट बनाता है, और उस लेआउट पर आधारित एक नई स्लाइड जोड़ता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat, SlideLayoutType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation("presentation.pptx")
try:
    default_master_slide = presentation.getMasters().get_Item(0)
    section_master_slide = presentation.getMasters().addClone(default_master_slide)
    section_master_background_color = Color.LIGHT_GRAY

    section_master_slide.getBackground().setType(BackgroundType.OwnBackground)
    section_master_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    section_master_slide.getBackground().getFillFormat().getSolidFillColor().setColor(section_master_background_color)

    source_blank_layout = default_master_slide.getLayoutSlides().getByType(SlideLayoutType.Blank)
    if source_blank_layout is None:
        source_blank_layout = default_master_slide.getLayoutSlides().get_Item(0)

    section_blank_layout = section_master_slide.getLayoutSlides().addClone(source_blank_layout)

    presentation.getSlides().addEmptySlide(section_blank_layout)
    presentation.save("presentation-with-multiple-masters.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **स्लाइड मास्टर की तुलना करें**

master slides को [equals](https://reference.aspose.com/slides/hi/python-java/aspose.slides/baseslide/#equals) मेथड से तुलना किया जा सकता है, जो [BaseSlide](https://reference.aspose.com/slides/hi/python-java/aspose.slides/baseslide/) से विरासत में मिला है। तुलना संरचना और स्थैतिक सामग्री की जाँच करती है, जैसे शैप्स, टेक्स्ट, फॉर्मेटिंग, एनीमेशन, और अन्य स्लाइड सेटिंग्स। यह अद्वितीय पहचानकर्ताओं, जैसे स्लाइड IDs, या गतिशील प्लेसहोल्डर मानों, जैसे वर्तमान तिथि, की तुलना नहीं करता।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

first_presentation = Presentation("first.pptx")
second_presentation = Presentation("second.pptx")
try:
    first_presentation_master_count = first_presentation.getMasters().size()
    second_presentation_master_count = second_presentation.getMasters().size()

    for first_master_index in range(first_presentation_master_count):
        for second_master_index in range(second_presentation_master_count):
            first_master_slide = first_presentation.getMasters().get_Item(first_master_index)
            second_master_slide = second_presentation.getMasters().get_Item(second_master_index)
            are_master_slides_equal = first_master_slide.equals(second_master_slide)

            if are_master_slides_equal:
                print(f"first.pptx master #{first_master_index} equals second.pptx master #{second_master_index}")
finally:
    first_presentation.dispose()
    second_presentation.dispose()
```

अधिक जानकारी के लिए देखें [Compare Presentation Slides](/slides/hi/python-java/compare-slides/)।

## **स्लाइड मास्टर दृश्य को डिफ़ॉल्ट दृश्य बनाएं**

[ViewProperties](https://reference.aspose.com/slides/hi/python-java/aspose.slides/viewproperties/) पर [setLastView](https://reference.aspose.com/slides/hi/python-java/aspose.slides/viewproperties/#setLastView) मेथड का उपयोग करके आप PowerPoint द्वारा पहले खोला जाने वाला दृश्य नियंत्रित कर सकते हैं। निम्न उदाहरण प्रस्तुति को Slide Master दृश्य में खोलता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ViewType

presentation = Presentation("presentation.pptx")
try:
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView)
    presentation.save("presentation-master-view.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

अधिक दृश्य सेटिंग्स के लिए देखें [Save Presentation](/slides/hi/python-java/save-presentation/)।

## **अप्रयुक्त मास्टर स्लाइड्स हटाएं**

प्रस्तुति में कभी-कभी ऐसे मास्टर स्लाइड्स होते हैं जो अब किसी सामान्य स्लाइड द्वारा उपयोग नहीं किए जाते। अप्रयुक्त मास्टर को हटाने से फ़ाइल आकार कम हो सकता है और टेम्प्लेट रखरखाव सरल हो जाता है।

अप्रयुक्त मास्टर को [Presentation.getMasters](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#getMasters) कलेक्शन से हटाने के लिए [removeUnused](https://reference.aspose.com/slides/hi/python-java/aspose.slides/masterslidecollection/#removeUnused) का उपयोग करें:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    presentation.getMasters().removeUnused(True)
    presentation.save("presentation-clean.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

आप लो-कोड [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/hi/python-java/aspose.slides/compress/#removeUnusedMasterSlides) मेथड का भी उपयोग कर सकते हैं:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Compress, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    Compress.removeUnusedMasterSlides(presentation)
    presentation.save("presentation-clean.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **बार-बार पूछे जाने वाले प्रश्न**

**स्लाइड मास्टर और लेआउट स्लाइड में क्या अंतर है?**

एक slide master थीम, पृष्ठभूमि, सामान्य आकार, और टेक्स्ट शैलियों जैसी साझा डिजाइन सेटिंग्स को परिभाषित करता है। एक layout slide एक master slide से संबंधित होती है और प्लेसहोल्डर्स की विशिष्ट व्यवस्था को परिभाषित करती है। एक normal slide एक layout slide का उपयोग करती है, इसलिए यह लेआउट और मास्टर दोनों से विरासत में प्राप्त करती है।

**क्या एक प्रस्तुति में कई slide masters हो सकते हैं?**

हां। एक प्रस्तुति में कई slide masters हो सकते हैं। जब विभिन्न अनुभागों को अलग-अलग दृश्य प्रणाली या ब्रांडिंग की आवश्यकता होती है, तो कई मास्टर का उपयोग करें।

**क्या मुझे प्लेसहोल्डर master slide में जोड़ना चाहिए या layout slide में?**

अधिकांश मामलों में, प्लेसहोल्डर को layout slides में जोड़ें। साझा दृश्य तत्व और साझा फ़ॉर्मेटिंग को master slide पर रखें, फिर सामग्री प्लेसहोल्डर को उन लेआउट्स पर रखें जिन्हें सामान्य स्लाइड्स उपयोग करेंगे।

**क्या मैं एक master slide को डिलीट कर सकता हूं जो अभी भी उपयोग में है?**

नहीं। एक master slide जो निर्भर स्लाइड्स रखता है, उसे सीधे सुरक्षित रूप से हटाया नहीं जा सकता। पहले उन स्लाइड्स को किसी अन्य master के तहत लेआउट्स में स्थानांतरित करें, या एक ऐसी अप्रयुक्त-मास्टर क्लीनअप विधि का उपयोग करें जो केवल उन मास्टर को हटाए जो उपयोग में नहीं हैं।