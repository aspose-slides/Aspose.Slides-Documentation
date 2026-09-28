---
title: Python के माध्यम से Java में प्रस्तुति स्लाइड मास्टर प्रबंधित करें
linktitle: स्लाइड मास्टर
type: docs
weight: 70
url: /hi/python-java/slide-master/
keywords:
- स्लाइड मास्टर
- मास्टर स्लाइड
- PPT मास्टर स्लाइड
- कई मास्टर स्लाइड्स
- मास्टर स्लाइड्स की तुलना
- पृष्ठभूमि
- प्लेसहोल्डर
- मास्टर स्लाइड क्लोन करें
- मास्टर स्लाइड कॉपी करें
- मास्टर स्लाइड डुप्लिकेट करें
- अप्रयुक्त मास्टर स्लाइड
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java में स्लाइड मास्टर प्रबंधित करें: PowerPoint और OpenDocument प्रस्तुतियों में मास्टर स्लाइडों तक पहुंच, संपादन, क्लोन, तुलना और हटाना।"
---
## **परिचय**

एक **स्लाइड मास्टर** स्लाइड समूह के लिए साझा डिजाइन सेटिंग्स को परिभाषित करता है। इसमें सामान्य आकृतियाँ, लोगो, पृष्ठभूमि, पाठ शैलियाँ, थीम सेटिंग्स और फुटर सेटिंग्स हो सकते हैं। PowerPoint में, स्लाइड मास्टर को संपादित करना एक ही स्वरूपण को हर स्लाइड पर दोहराए बिना प्रस्तुति को सुसंगत रखने का सामान्य तरीका है।

Aspose.Slides for Python via Java भी यही मॉडल समर्थन करता है। एक प्रस्तुति में एक या अधिक मास्टर स्लाइडें हो सकती हैं, और प्रत्येक मास्टर स्लाइड में कई लेआउट स्लाइडें हो सकती हैं। सामान्य स्लाइडें आमतौर पर सीधे मास्टर स्लाइड को संदर्भित नहीं करतीं। बल्कि, एक सामान्य स्लाइड एक लेआउट स्लाइड का उपयोग करती है, और वह लेआउट स्लाइड एक मास्टर स्लाइड से संबंधित होती है।

क्रमानुसार:

1. **स्लाइड मास्टर** – साझा डिजाइन और थीम को परिभाषित करता है।  
2. **लेआउट स्लाइड** – प्लेसहोल्डर और लेआउट‑स्तरीय स्वरूपण की विशिष्ट व्यवस्था को परिभाषित करती है।  
3. **सामान्य स्लाइड** – वास्तविक प्रस्तुति सामग्री रखती है और एक लेआउट स्लाइड का उपयोग करती है।

![मास्टर स्लाइड, लेआउट स्लाइड और सामान्य स्लाइड की क्रमबद्धता](slide-master_2.jpg)

Aspose.Slides में, एक स्लाइड मास्टर को [MasterSlide](https://reference.aspose.com/slides/hi/python-java/aspose.slides/masterslide/) क्लास द्वारा प्रतिनिधित्व किया जाता है। प्रस्तुति में सभी मास्टर स्लाइडें [Presentation.getMasters](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#getMasters) संग्रह से उपलब्ध होती हैं, जिसे [MasterSlideCollection](https://reference.aspose.com/slides/hi/python-java/aspose.slides/masterslidecollection/) द्वारा दर्शाया गया है।

{{% alert color="info" title="Inheritance" %}}
जब aynı özellik birden fazla seviyede tanımlanırsa, daha spesifik seviye geçerli olur. Örneğin, bir master slide ve bir layout slide aynı arka planı tanımlıyorsa, o layout’a dayalı slaytlar layout arka planını kullanır. Layout slaytları hakkında daha fazla bilgi için [Apply or Change Slide Layouts](/slides/hi/python-java/slide-layout/) bölümüne bakın.
{{% /alert %}}

## **स्लाइड मास्टर तक पहुंच**

PowerPoint में, आप **View** > **Slide Master** से स्लाइड मास्टर दृश्य खोल सकते हैं।

![PowerPoint के View टैब पर स्लाइड मास्टर कमांड](slide-master_3.jpg)

Aspose.Slides में, मास्टर स्लाइडों तक पहुंचने के लिए [Presentation.getMasters](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#getMasters) संग्रह का उपयोग करें:

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

आप सामान्य स्लाइड के लेआउट के माध्यम से उपयोग किए जाने वाले मास्टर स्लाइड को भी प्राप्त कर सकते हैं:

```python
import jpype
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

एक मास्टर स्लाइड एक स्लाइड‑समान वस्तु है। यह [BaseSlide](https://reference.aspose.com/slides/hi/python-java/aspose.slides/baseslide/) से विरासत में मिलती है, इसलिए यह सामान्य और लेआउट स्लाइडों के समान कई स्लाइड गुणों को उजागर करती है। मास्टर‑विशिष्ट सदस्य [MasterSlide](https://reference.aspose.com/slides/hi/python-java/aspose.slides/masterslide/) API पृष्ठ पर सूचीबद्ध हैं।

सामान्यतः उपयोग किए जाने वाले मास्टर स्लाइड सदस्यों में शामिल हैं:

| सदस्य | उद्देश्य |
| --- | --- |
| [getBackground](https://reference.aspose.com/slides/hi/python-java/aspose.slides/baseslide/#getBackground) | मास्टर‑स्तर की स्लाइड पृष्ठभूमि सेट करता है। |
| [getShapes](https://reference.aspose.com/slides/hi/python-java/aspose.slides/baseslide/#getShapes) | मास्टर पर रखी गई आकृतियों को संग्रहीत करता है, जैसे लोगो, चित्र फ्रेम, और साझा पाठ। |
| [getLayoutSlides](https://reference.aspose.com/slides/hi/python-java/aspose.slides/masterslide/#getLayoutSlides) | मास्टर से संबंधित लेआउट स्लाइडों को संग्रहीत करता है। |
| [getThemeManager](https://reference.aspose.com/slides/hi/python-java/aspose.slides/masterslide/#getThemeManager) | मास्टर थीम API तक पहुंच प्रदान करता है। |
| [getHeaderFooterManager](https://reference.aspose.com/slides/hi/python-java/aspose.slides/masterslide/#getHeaderFooterManager) | मास्टर और उसकी उप‑लेआउटों के लिए हेडर, फुटर, तिथि और स्लाइड नंबर को नियंत्रित करता है। |
| [getDependingSlides](https://reference.aspose.com/slides/hi/python-java/aspose.slides/masterslide/#getDependingSlides) | लेआउट के माध्यम से मास्टर पर निर्भर सामान्य स्लाइडों को लौटाता है। |

## **स्लाइड मास्टर में छवि जोड़ना**

जब आप किसी मास्टर स्लाइड में छवि जोड़ते हैं, तो वह उन सभी स्लाइडों पर दिखाई देती है जो उस मास्टर के लेआउट का उपयोग करती हैं। यह लोगो, वॉटरमार्क, सजावटी बैंड और अन्य दोहराव वाले दृश्य तत्वों के लिए उपयोगी है।

निम्न उदाहरण पहले मास्टर स्लाइड में एक लोगो जोड़ता है:

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

चित्र फ़्रेम के बारे में अधिक जानकारी के लिए देखें: [Picture Frame](/slides/hi/python-java/picture-frame/)।

## **मास्टर ग्राफ़िक्स की दृश्यमानता नियंत्रित करना**

विरासत में मिली मास्टर ग्राफ़िक्स (जैसे लोगो या सजावटी आकृतियों) को हटाए बिना छुपाने के लिए [BaseSlide.setShowMasterShapes](https://reference.aspose.com/slides/hi/python-java/aspose.slides/baseslide/#setShowMasterShapes) का उपयोग करें। उस स्लाइड पर `False` पास करें जिसे इन ग्राफ़िक्स को नहीं दिखाना है, और जहाँ दिखाना चाहते हैं वहाँ `True` रखें:

slide.setShowMasterShapes(False)

निम्न स्व-समाहित उदाहरण एक मास्टर पर नीला सजावटी बैंड बनाता है और दो स्लाइडें बनाता है जो उसी खाली लेआउट का उपयोग करती हैं। पहला बैंड दिखता है, दूसरा छिपा होता है। कोई इनपुट प्रस्तुति या छवि आवश्यक नहीं है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType, SlideLayoutType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    master_slide = presentation.getMasters().get_Item(0)
    layout_slide = master_slide.getLayoutSlides().getByType(SlideLayoutType.Blank)
    layout_slide.setShowMasterShapes(True)

    slide_height = jpype.JFloat(presentation.getSlideSize().getSize().getHeight())
    band = master_slide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 60, slide_height)
    band_color = Color(70, 130, 180)
    band.getFillFormat().setFillType(FillType.Solid)
    band.getFillFormat().getSolidFillColor().setColor(band_color)
    band.getLineFormat().getFillFormat().setFillType(FillType.NoFill)

    visible_slide = presentation.getSlides().get_Item(0)
    visible_slide.setLayoutSlide(layout_slide)
    visible_slide.getShapes().clear()

    hidden_slide = presentation.getSlides().addEmptySlide(layout_slide)

    visible_slide.setShowMasterShapes(True)
    hidden_slide.setShowMasterShapes(False)

    presentation.save("master-graphics.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

उदाहरण एक नई प्रस्तुति के साथ प्रदान किए गए **Blank** लेआउट का उपयोग करता है और प्रारंभिक स्लाइड के अपने प्लेसहोल्डर को हटा देता है।

### **सेटिंग का दायरा चुनें**

एक सामान्य स्लाइड अपने मास्टर को [Slide.getLayoutSlide](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slide/#getLayoutSlide) और [LayoutSlide.getMasterSlide](https://reference.aspose.com/slides/hi/python-java/aspose.slides/layoutslide/#getMasterSlide) के माध्यम से उपयोग करती है। व्यक्तिगत स्लाइड पर प्रॉपर्टी सेट करने से केवल वही स्लाइड प्रभावित होती है। उस साझा लेआउट का उपयोग करने वाली सभी स्लाइडों के लिए ग्राफ़िक्स छिपाने के लिए `False` को [LayoutSlide.setShowMasterShapes](https://reference.aspose.com/slides/hi/python-java/aspose.slides/layoutslide/#setShowMasterShapes) में पास करें, भले ही उनकी अपनी सेटिंग `True` हो। केवल एक स्लाइड पर ग्राफ़िक्स छिपाने के लिए स्लाइड प्रॉपर्टी बदलें और साझा लेआउट को जैसा है वैसा ही रखें।

मास्टर स्लाइड स्वयं पर यह सेटिंग दृश्यमानता नियंत्रण के रूप में समर्थित नहीं है। मास्टर पर [getShowMasterShapes](https://reference.aspose.com/slides/hi/python-java/aspose.slides/masterslide/#getShowMasterShapes) हमेशा `False` लौटाता है, और [setShowMasterShapes](https://reference.aspose.com/slides/hi/python-java/aspose.slides/masterslide/#setShowMasterShapes) में `True` पास करने से अपवाद उत्पन्न होता है। इसे सामान्य स्लाइड या लेआउट पर लागू करें।

### **ग्राफ़िक्स को पृष्ठभूमि से अलग करना**

| ऑपरेशन | प्रभाव |
| --- | --- |
| मास्टर ग्राफ़िक्स छिपाएँ | विरासत में मिली मास्टर आकृतियों की दृश्यमानता को हटाए बिना नियंत्रित करता है, स्लाइड की अपनी आकृतियों पर कोई प्रभाव नहीं डालता। |
| स्लाइड पृष्ठभूमि भराव बदलें | पृष्ठभूमि का रंग, ग्रेडिएंट या छवि बदलता है। मास्टर ग्राफ़िक्स अलग आकृतियां होती हैं और पृष्ठभूमि के ऊपर दृश्यमान रह सकती हैं। देखें: [Presentation Background](/slides/hi/python-java/presentation-background/)। |
| मास्टर से आकृति हटाएँ | साझा स्रोत आकृति को हटाता है, जिससे वह किसी भी स्लाइड के लिये उपलब्ध नहीं रहती जो उस मास्टर को उपयोग करती है। |

## **प्लेसहोल्डर के साथ काम करना**

प्लेसहोल्डर सामान्यतः लेआउट स्लाइड पर परिभाषित होते हैं। मास्टर स्लाइड साझा शैली और थीम प्रदान करता है जिसे लेआउट विरासत में लेते हैं, जबकि प्रत्येक लेआउट तय करता है कि कौन‑से प्लेसहोल्डर उपलब्ध हैं और कहाँ रखे गए हैं।

PowerPoint में, प्लेसहोल्डर कमांड स्लाइड मास्टर दृश्य में उपलब्ध होते हैं।

![PowerPoint स्लाइड मास्टर दृश्य में Insert Placeholder कमांड](slide-master_5.png)

Aspose.Slides में नए प्लेसहोल्डर जोड़ने के लिए उस लेआउट स्लाइड के साथ काम करें जो मास्टर से संबंधित है:

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

आप मास्टर स्लाइड पर पहले से मौजूद प्लेसहोल्डर आकृतियों को भी स्वरूपित कर सकते हैं। निम्न उदाहरण शीर्षक प्लेसहोल्डर को खोजता है और रैखिक ग्रेडिएंट भराव लागू करता है:

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

![सामान्य स्लाइड द्वारा विरासत में मिला स्वरूपित शीर्षक प्लेसहोल्डर](slide-master_8.png)

अधिक प्लेसहोल्डर और पाठ स्वरूपण विकल्पों के लिए देखें: [Set Prompt Text in Placeholder](/slides/hi/python-java/manage-placeholder/) और [Text Formatting](/slides/hi/python-java/text-formatting/)।

## **स्लाइड मास्टर पृष्ठभूमि बदलना**

मास्टर पृष्ठभूमि लेआउट और उन स्लाइडों द्वारा विरासत में ली जाती है जो इसे ओवरराइड नहीं करतीं। निम्न उदाहरण पहले मास्टर स्लाइड के लिए ठोस पृष्ठभूमि रंग सेट करता है:

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

संबंधित विषयों के लिए देखें: [Presentation Background](/slides/hi/python-java/presentation-background/) और [Presentation Theme](/slides/hi/python-java/presentation-theme/)।

## **मास्टर स्लाइड को दूसरे प्रस्तुति में क्लोन करना**

[MasterSlideCollection.addClone](https://reference.aspose.com/slides/hi/python-java/aspose.slides/masterslidecollection/#addClone) का उपयोग करके मास्टर स्लाइड को दूसरी प्रस्तुति में कॉपी करें। कॉपी किया हुआ मास्टर तब गंतव्य प्रस्तुति के लेआउट और स्लाइडों द्वारा उपयोग किया जा सकता है।

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

यदि आपको सामान्य स्लाइडों को उनके मास्टर के साथ क्लोन करना है, तो देखें: [Clone Slides](/slides/hi/python-java/clone-slides/)।

## **एकाधिक स्लाइड मास्टर जोड़ना**

एक प्रस्तुति में कई मास्टर स्लाइडें हो सकती हैं। यह तब उपयोगी होता है जब विभिन्न अनुभागों को अलग‑अलग ब्रांडिंग, पृष्ठ संरचना या थीम सेटिंग्स की आवश्यकता होती है।

![मास्टर स्लाइड डालने और प्रबंधित करने के लिए PowerPoint कमांड](slide-master_9.jpg)

निम्न उदाहरण डिफ़ॉल्ट मास्टर को क्लोन करता है, क्लोन को अलग पृष्ठभूमि देता है, उस क्लोन किए गए मास्टर के तहत एक लेआउट बनाता है, और उस लेआउट पर आधारित नई स्लाइड जोड़ता है:

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

## **स्लाइड मास्टर की तुलना करना**

मास्टर स्लाइडों की तुलना [equals](https://reference.aspose.com/slides/hi/python-java/aspose.slides/baseslide/#equals) मेथड से की जा सकती है, जो [BaseSlide](https://reference.aspose.com/slides/hi/python-java/aspose.slides/baseslide/) से विरासत में मिला है। तुलना संरचना और स्थैतिक सामग्री (जैसे आकृतियां, पाठ, स्वरूपण, एनीमेशन और अन्य स्लाइड सेटिंग्स) को जांचती है। यह अनूठे पहचानकर्ता (जैसे स्लाइड ID) या गतिशील प्लेसहोल्डर मान (जैसे वर्तमान तिथि) की तुलना नहीं करती।

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

अधिक जानकारी के लिए देखें: [Compare Presentation Slides](/slides/hi/python-java/compare-slides/)।

## **डिफ़ॉल्ट रूप में स्लाइड मास्टर व्यू सेट करना**

[ViewProperties](https://reference.aspose.com/slides/hi/python-java/aspose.slides/viewproperties/) पर [setLastView](https://reference.aspose.com/slides/hi/python-java/aspose.slides/viewproperties/#setLastView) मेथड का उपयोग करके वह दृश्य नियंत्रित किया जा सकता है जिसे PowerPoint प्रथम बार खोलता है। निम्न उदाहरण प्रस्तुति को स्लाइड मास्टर व्यू में खोलता है:

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

अधिक व्यू सेटिंग्स के लिए देखें: [Save Presentation](/slides/hi/python-java/save-presentation/)।

## **अप्रयुक्त मास्टर स्लाइड हटाना**

कभी‑कभी प्रस्तुतियों में ऐसे मास्टर स्लाइड होते हैं जो अब किसी सामान्य स्लाइड द्वारा प्रयोग नहीं होते। अप्रयुक्त मास्टर को हटाने से फ़ाइल आकार कम हो सकता है और टेम्पलेट रखरखाव सरल हो जाता है।

[Presentation.getMasters](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#getMasters) संग्रह से अप्रयुक्त मास्टर को हटाने के लिए [removeUnused](https://reference.aspose.com/slides/hi/python-java/aspose.slides/masterslidecollection/#removeUnused) का उपयोग करें:

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

आप कम‑कोड विधि [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/hi/python-java/aspose.slides/compress/#removeUnusedMasterSlides) का भी उपयोग कर सकते हैं:

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

## **अक्सर पूछे जाने वाले प्रश्न**

**स्लाइड मास्टर और लेआउट स्लाइड में क्या अंतर है?**

स्लाइड मास्टर थीम, पृष्ठभूमि, सामान्य आकृतियों और पाठ शैलियों जैसी साझा डिजाइन सेटिंग्स को परिभाषित करता है। लेआउट स्लाइड एक मास्टर स्लाइड के अंतर्गत आता है और प्लेसहोल्डर की विशिष्ट व्यवस्था को परिभाषित करता है। सामान्य स्लाइड लेआउट स्लाइड का उपयोग करती है, इसलिए वह लेआउट और मास्टर दोनों से विरासत में मिलती है।

**क्या एक प्रस्तुति में कई स्लाइड मास्टर हो सकते हैं?**

हाँ। एक प्रस्तुति में कई स्लाइड मास्टर हो सकते हैं। जब विभिन्न अनुभागों को अलग‑अलग दृश्य प्रणाली या ब्रांडिंग की आवश्यकता हो, तो कई मास्टर का उपयोग करें।

**प्लेसहोल्डर मास्टर स्लाइड में जोड़ें या लेआउट स्लाइड में?**

अधिकांश मामलों में प्लेसहोल्डर को लेआउट स्लाइड में जोड़ें। साझा दृश्य तत्व और साझा स्वरूपण मास्टर स्लाइड पर रखें, फिर सामग्री प्लेसहोल्डर लेआउट पर रखें जिन्हें सामान्य स्लाइड उपयोग करेगी।

**क्या मैं उपयोग में रहने वाले मास्टर स्लाइड को हटा सकता हूँ?**

नहीं। यदि किसी मास्टर स्लाइड पर निर्भर स्लाइडें हैं तो उसे सीधे हटाना सुरक्षित नहीं है। पहले उन स्लाइडों को किसी अन्य मास्टर के लेआउट में ले जाएँ, या केवल अप्रयुक्त मास्टर को हटाने वाली सफाई विधि का उपयोग करें।