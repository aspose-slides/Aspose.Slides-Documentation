---
title: Python में प्रेज़ेंटेशन स्लाइड मास्टर्स प्रबंधित करें
linktitle: स्लाइड मास्टर
type: docs
weight: 80
url: /hi/python-net/slide-master/
keywords:
- स्लाइड मास्टर
- मास्टर स्लाइड
- PPT मास्टर स्लाइड
- एकाधिक मास्टर स्लाइड्स
- मास्टर स्लाइड्स की तुलना
- पृष्ठभूमि
- प्लेसहोल्डर
- मास्टर स्लाइड क्लोन करें
- मास्टर स्लाइड कॉपी करें
- मास्टर स्लाइड डुप्लिकेट करें
- अनुपयोगी मास्टर स्लाइड
- PowerPoint
- OpenDocument
- प्रेज़ेंटेशन
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET में स्लाइड मास्टर्स प्रबंधित करें: PowerPoint और OpenDocument प्रस्तुतियों में मास्टर स्लाइड्स तक पहुँच, संपादन, क्लोन, तुलना और हटाना।"
---
## **अवलोकन**

एक **slide master** समूह की स्लाइड्स के लिए साझा डिज़ाइन सेटिंग्स को परिभाषित करता है। इसमें सामान्य आकार, लोगो, पृष्ठभूमि, टेक्स्ट शैलियाँ, थीम सेटिंग्स और फ़ूटर सेटिंग्स शामिल हो सकते हैं। PowerPoint में, स्लाइड मास्टर को संपादित करना वह सामान्य तरीका है जिससे प्रस्तुति को लगातार रखा जा सके बिना प्रत्येक स्लाइड पर समान फ़ॉर्मेटिंग दोहराए।

Aspose.Slides for Python via .NET भी वही मॉडल समर्थन करता है। एक प्रस्तुति में एक या अधिक मास्टर स्लाइड्स हो सकती हैं, और प्रत्येक मास्टर स्लाइड में कई लेआउट स्लाइड्स हो सकती हैं। सामान्य स्लाइड्स आम तौर पर सीधे किसी मास्टर स्लाइड को संदर्भित नहीं करतीं। इसके बजाय, एक सामान्य स्लाइड एक लेआउट स्लाइड का उपयोग करती है, और वह लेआउट स्लाइड किसी मास्टर स्लाइड से जुड़ी होती है।

क्रमागत संरचना इस प्रकार है:

1. **Slide master** – साझा डिज़ाइन और थीम को परिभाषित करता है।  
1. **Layout slide** – प्लेसहोल्डर्स और लेआउट‑स्तर फ़ॉर्मेटिंग की विशिष्ट व्यवस्था को परिभाषित करता है।  
1. **Normal slide** – वास्तविक प्रस्तुति सामग्री को सम्मिलित करता है और एक लेआउट स्लाइड का उपयोग करता है।

![मास्टर स्लाइड्स, लेआउट स्लाइड्स, और सामान्य स्लाइड्स की पदानुक्रम](slide-master_2.jpg)

Aspose.Slides में, एक स्लाइड मास्टर को [MasterSlide](https://reference.aspose.com/slides/hi/python-net/aspose.slides/masterslide/) क्लास द्वारा दर्शाया जाता है। प्रस्तुति में सभी मास्टर स्लाइड्स `Presentation.masters` संग्रह के माध्यम से उपलब्ध होती हैं।

{{% alert color="info" title="Inheritance" %}}
जब एक ही गुण एक से अधिक स्तर पर परिभाषित होता है, तो अधिक विशिष्ट स्तर विजयी होता है। उदाहरण के लिए, यदि एक मास्टर स्लाइड और एक लेआउट स्लाइड दोनों पृष्ठभूमि निर्धारित करते हैं, तो उस लेआउट पर आधारित स्लाइड्स लेआउट पृष्ठभूमि का उपयोग करेंगी। लेआउट स्लाइड्स के बारे में अधिक जानकारी के लिए देखें: [स्लाइड लेआउट लागू करें या बदलें](/slides/hi/python-net/slide-layout/)।
{{% /alert %}}

## **स्लाइड मास्टर तक पहुँच**

PowerPoint में, आप **View** > **Slide Master** से स्लाइड मास्टर दृश्य खोल सकते हैं।

![PowerPoint View टैब में स्लाइड मास्टर कमांड](slide-master_3.jpg)

Aspose.Slides में, मास्टर स्लाइड्स तक पहुँचने के लिए `masters` संग्रह का उपयोग करें:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    first_master_slide = presentation.masters[0]
    master_slide_count = len(presentation.masters)
    first_master_layout_slide_count = len(first_master_slide.layout_slides)

    print("Master slides: " + str(master_slide_count))
    print("Layouts in the first master: " + str(first_master_layout_slide_count))
```

आप एक सामान्य स्लाइड के लेआउट के माध्यम से उपयोग किए गए मास्टर स्लाइड को भी प्राप्त कर सकते हैं:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]
    layout_slide = slide.layout_slide
    master_slide = layout_slide.master_slide
    master_slide_name = master_slide.name

    print(master_slide_name)
```

## **एक स्लाइड मास्टर में क्या शामिल होता है**

मास्टर स्लाइड एक स्लाइड‑समान वस्तु है। यह [BaseSlide](https://reference.aspose.com/slides/hi/python-net/aspose.slides/baseslide/) क्लास से सामान्य स्लाइड व्यवहार को विरासत में लेती है, इसलिए यह सामान्य और लेआउट स्लाइड्स द्वारा उपयोग किए जाने वाले कई समान स्लाइड गुण प्रदान करती है। मास्टर‑विशिष्ट सदस्य [MasterSlide](https://reference.aspose.com/slides/hi/python-net/aspose.slides/masterslide/) API पृष्ठ पर सूचीबद्ध हैं।

सामान्यतः उपयोग किए जाने वाले मास्टर स्लाइड सदस्यों में शामिल हैं:

| सदस्य | उद्देश्य |
| --- | --- |
| `background` | मास्टर‑स्तर स्लाइड पृष्ठभूमि सेट करता है। |
| `shapes` | मास्टर पर रखी गई आकृतियों को संग्रहीत करता है, जैसे लोगो, चित्र फ्रेम, और साझा टेक्स्ट। |
| `layout_slides` | उस मास्टर से संबंधित लेआउट स्लाइड्स को संग्रहीत करता है। |
| `theme_manager` | मास्टर थीम API तक पहुँच प्रदान करता है। |
| `header_footer_manager` | मास्टर और उसके चाइल्ड लेआउट्स के हेडर, फ़ूटर, तिथियों और स्लाइड नंबरों को नियंत्रित करता है। |
| `get_depending_slides` | उन सामान्य स्लाइड्स को लौटाता है जो लेआउट्स के माध्यम से मास्टर पर निर्भर हैं। |

## **स्लाइड मास्टर में एक छवि जोड़ें**

जब आप मास्टर स्लाइड में एक छवि जोड़ते हैं, तो वह उस मास्टर से जुड़े लेआउट्स का उपयोग करने वाली स्लाइड्स पर दिखाई देती है। यह लोगो, वॉटरमार्क, सजावटी बैंड और अन्य दोहराए जाने वाले दृश्य तत्वों के लिए उपयोगी है।

निम्न उदाहरण पहले मास्टर स्लाइड में एक लोगो जोड़ता है:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    master_slide = presentation.masters[0]

    with open("logo.png", "rb") as logo_stream:
        logo_bytes = logo_stream.read()

    logo_image = presentation.images.add_image(logo_bytes)

    master_slide.shapes.add_picture_frame(
        slides.ShapeType.RECTANGLE,
        20,
        20,
        80,
        80,
        logo_image)

    presentation.save("presentation-with-logo.pptx", slides.export.SaveFormat.PPTX)
```

चित्र फ्रेम के बारे में अधिक जानकारी के लिए देखें: [Picture Frame](/slides/hi/python-net/picture-frame/)।

## **मास्टर ग्राफ़िक्स की दृश्यता नियंत्रित करें**

वारिसित मास्टर ग्राफ़िक्स, जैसे लोगो या सजावटी आकार, को हटाए बिना छुपाने के लिए [BaseSlide.show_master_shapes](https://reference.aspose.com/slides/hi/python-net/aspose.slides/baseslide/show_master_shapes/) का उपयोग करें। जिस स्लाइड पर इन ग्राफ़िक्स को हटाना है, उस पर `Slide.show_master_shapes` को `False` सेट करें और उन स्लाइड्स पर `True` रखें जहाँ उन्हें दिखाना है।

निम्न स्व-निर्भर उदाहरण एक नीले सजावटी बैंड को मास्टर पर बनाता है और दो स्लाइड्स को समान खाली लेआउट का उपयोग करके बनाता है। बैंड पहली स्लाइड पर दिखाई देता है और दूसरी स्लाइड पर छिपा रहता है। कोई इनपुट प्रस्तुति या छवि आवश्यक नहीं है।

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    master_slide = presentation.masters[0]
    layout_slide = master_slide.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)
    layout_slide.show_master_shapes = True

    slide_height = presentation.slide_size.size.height
    band = master_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 0, 0, 60, slide_height)
    band.fill_format.fill_type = slides.FillType.SOLID
    band.fill_format.solid_fill_color.color = draw.Color.steel_blue
    band.line_format.fill_format.fill_type = slides.FillType.NO_FILL

    visible_slide = presentation.slides[0]
    visible_slide.layout_slide = layout_slide
    visible_slide.shapes.clear()

    hidden_slide = presentation.slides.add_empty_slide(layout_slide)

    visible_slide.show_master_shapes = True
    hidden_slide.show_master_shapes = False

    presentation.save("master-graphics.pptx", slides.export.SaveFormat.PPTX)
```

यह उदाहरण नई प्रस्तुति के साथ प्रदान किए गए **Blank** लेआउट का उपयोग करता है और प्रारंभिक स्लाइड के अपने प्लेसहोल्डर्स को हटाता है।

### **सेटिंग की सीमा चुनें**

एक सामान्य स्लाइड अपने मास्टर को [Slide.layout_slide](https://reference.aspose.com/slides/hi/python-net/aspose.slides/slide/layout_slide/) और [LayoutSlide.master_slide](https://reference.aspose.com/slides/hi/python-net/aspose.slides/layoutslide/master_slide/) के माध्यम से उपयोग करती है। एक व्यक्तिगत स्लाइड पर गुण सेट करने से केवल वही स्लाइड प्रभावित होती है। जब आप [LayoutSlide.show_master_shapes](https://reference.aspose.com/slides/hi/python-net/aspose.slides/layoutslide/show_master_shapes/) को `False` सेट करते हैं, तो वह साझा लेआउट का उपयोग करने वाली सभी स्लाइड्स पर मास्टर ग्राफ़िक्स को छुपा देता है, भले ही उनकी अपनी सेटिंग `True` हो। केवल एक स्लाइड पर ग्राफ़िक्स छुपाने के लिए, स्लाइड गुण को बदलें और साझा लेआउट को अपरिवर्तित रखें।

यह सेटिंग मास्टर स्लाइड स्वयं पर दृश्य नियंत्रण के रूप में समर्थित नहीं है। मास्टर पर यह हमेशा `False` लौटाता है, और `True` असाइन करने पर अपवाद उत्पन्न होता है। इसे एक सामान्य स्लाइड या लेआउट पर लागू करें।

### **ग्राफ़िक्स को पृष्ठभूमि से अलग करें**

| ऑपरेशन | प्रभाव |
| --- | --- |
| मास्टर ग्राफ़िक्स छुपाएँ | वारिसित मास्टर आकारों की दृश्यता को हटाए बिना या स्लाइड की अपनी आकृतियों को बदले बिना नियंत्रित करता है। |
| स्लाइड पृष्ठभूमि भर बदलें | पृष्ठभूमि का रंग, ग्रेडिएंट या छवि बदलता है। मास्टर ग्राफ़िक्स अलग आकार होते हैं और उस पृष्ठभूमि के ऊपर दिखाई दे सकते हैं। देखें: [Presentation Background](/slides/hi/python-net/presentation-background/)। |
| मास्टर से आकार हटाएँ | साझा स्रोत आकार को हटा देता है, इसलिए वह किसी भी स्लाइड द्वारा अब उपलब्ध नहीं रहता जो उस मास्टर को उपयोग करती है। |

## **प्लेसहोल्डर्स के साथ कार्य करें**

प्लेसहोल्डर्स आमतौर पर लेआउट स्लाइड्स पर परिभाषित होते हैं। मास्टर स्लाइड साझा शैली और थीम प्रदान करती है जिसे लेआउट्स विरासत में लेते हैं, जबकि प्रत्येक लेआउट तय करता है कि कौन से प्लेसहोल्डर्स उपलब्ध हैं और उन्हें कहाँ रखा गया है।

PowerPoint में, प्लेसहोल्डर कमांड्स स्लाइड मास्टर दृश्य में उपलब्ध हैं।

![PowerPoint स्लाइड मास्टर दृश्य में Insert Placeholder कमांड](slide-master_5.png)

Aspose.Slides के साथ नए प्लेसहोल्डर्स जोड़ने के लिए, उस लेआउट स्लाइड के साथ काम करें जो मास्टर से संबद्ध है:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    master_slide = presentation.masters[0]
    blank_layout_slide = master_slide.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    if blank_layout_slide is None:
        blank_layout_slide = presentation.layout_slides.add(
            master_slide,
            slides.SlideLayoutType.BLANK,
            "Blank")

    blank_layout_slide.placeholder_manager.add_text_placeholder(60, 120, 600, 80)

    presentation.slides.add_empty_slide(blank_layout_slide)
    presentation.save("presentation-with-placeholder.pptx", slides.export.SaveFormat.PPTX)
```

आप मास्टर स्लाइड पर पहले से मौजूद प्लेसहोल्डर आकारों को भी फ़ॉर्मेट कर सकते हैं। निम्न उदाहरण शीर्षक प्लेसहोल्डर को खोजता है और एक रैखिक ग्रेडिएंट भर लागू करता है:

```python
import aspose.pydrawing as draw
import aspose.slides as slides


def find_placeholder(master_slide, placeholder_type):
    for shape in master_slide.shapes:
        if isinstance(shape, slides.AutoShape) and shape.placeholder is not None:
            if shape.placeholder.type == placeholder_type:
                return shape

    return None


with slides.Presentation("presentation.pptx") as presentation:
    master_slide = presentation.masters[0]
    title_placeholder = find_placeholder(master_slide, slides.PlaceholderType.TITLE)

    if title_placeholder is not None:
        red_gradient_color = draw.Color.from_argb(255, 0, 0)
        purple_gradient_color = draw.Color.from_argb(128, 0, 128)

        title_placeholder.fill_format.fill_type = slides.FillType.GRADIENT
        title_placeholder.fill_format.gradient_format.gradient_shape = slides.GradientShape.LINEAR
        title_placeholder.fill_format.gradient_format.gradient_stops.add(0, red_gradient_color)
        title_placeholder.fill_format.gradient_format.gradient_stops.add(1, purple_gradient_color)

    presentation.save("presentation-title-style.pptx", slides.export.SaveFormat.PPTX)
```

![सामान्य स्लाइड्स द्वारा विरासत में प्राप्त फ़ॉर्मेटेड शीर्षक प्लेसहोल्डर](slide-master_8.png)

अधिक प्लेसहोल्डर और टेक्स्ट फ़ॉर्मेटिंग विकल्पों के लिए देखें: [Set Prompt Text in Placeholder](/slides/hi/python-net/manage-placeholder/) और [Text Formatting](/slides/hi/python-net/text-formatting/)।

## **स्लाइड मास्टर पृष्ठभूमि बदलें**

मास्टर पृष्ठभूमि उन लेआउट्स और स्लाइड्स द्वारा विरासत में मिलती है जो इसे ओवरराइड नहीं करतीं। निम्न उदाहरण पहले मास्टर स्लाइड के लिए ठोस पृष्ठभूमि रंग सेट करता है:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    master_slide = presentation.masters[0]

    master_slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    master_slide.background.fill_format.fill_type = slides.FillType.SOLID
    master_slide.background.fill_format.solid_fill_color.color = draw.Color.forest_green

    presentation.save("presentation-master-background.pptx", slides.export.SaveFormat.PPTX)
```

संबंधित विषयों के लिए देखें: [Presentation Background](/slides/hi/python-net/presentation-background/) और [Presentation Theme](/slides/hi/python-net/presentation-theme/)।

## **एक स्लाइड मास्टर को दूसरी प्रस्तुति में क्लोन करें**

[MasterSlideCollection](https://reference.aspose.com/slides/hi/python-net/aspose.slides/masterslidecollection/) क्लास पर `add_clone` मेथड का उपयोग करके किसी मास्टर स्लाइड को दूसरी प्रस्तुति में कॉपी करें। कॉपी किया गया मास्टर तब गंतव्य प्रस्तुति में लेआउट्स और स्लाइड्स द्वारा उपयोग किया जा सकता है।

```python
import aspose.slides as slides

with slides.Presentation("source.pptx") as source_presentation:
    with slides.Presentation("destination.pptx") as destination_presentation:
        source_master_slide = source_presentation.masters[0]
        cloned_master_slide = destination_presentation.masters.add_clone(source_master_slide)

        destination_presentation.save("destination-with-master.pptx", slides.export.SaveFormat.PPTX)
```

यदि आपको सामान्य स्लाइड्स को उनके मास्टर के साथ क्लोन करने की आवश्यकता है, तो देखें: [Clone Slides](/slides/hi/python-net/clone-slides/)।

## **कई स्लाइड मास्टर जोड़ें**

एक प्रस्तुति में कई मास्टर स्लाइड्स हो सकती हैं। यह तब उपयोगी होता है जब विभिन्न सेक्शन को अलग‑अलग ब्रांडिंग, पृष्ठ संरचना, या थीम सेटिंग्स की आवश्यकता हो।

![मास्टर स्लाइड्स को सम्मिलित और प्रबंधित करने के लिए PowerPoint कमांड्स](slide-master_9.jpg)

निम्न उदाहरण डिफ़ॉल्ट मास्टर को क्लोन करता है, क्लोन को अलग पृष्ठभूमि देता है, क्लोन किए गए मास्टर के तहत एक खाली लेआउट प्राप्त करता है, और उस लेआउट के आधार पर एक नई स्लाइड जोड़ता है:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    default_master_slide = presentation.masters[0]
    section_master_slide = presentation.masters.add_clone(default_master_slide)

    section_master_slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    section_master_slide.background.fill_format.fill_type = slides.FillType.SOLID
    section_master_slide.background.fill_format.solid_fill_color.color = draw.Color.light_steel_blue

    section_blank_layout = section_master_slide.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    if section_blank_layout is None:
        section_blank_layout = presentation.layout_slides.add(
            section_master_slide,
            slides.SlideLayoutType.BLANK,
            "Section Blank")

    presentation.slides.add_empty_slide(section_blank_layout)
    presentation.save("presentation-with-multiple-masters.pptx", slides.export.SaveFormat.PPTX)
```

## **स्लाइड मास्टर की तुलना करें**

मास्टर स्लाइड्स को [BaseSlide](https://reference.aspose.com/slides/hi/python-net/aspose.slides/baseslide/) क्लास से विरासत में मिले `equals` मेथड के साथ तुलना किया जा सकता है। तुलना संरचना और स्थैतिक सामग्री, जैसे आकार, टेक्स्ट, फ़ॉर्मेटिंग, एनीमेशन और अन्य स्लाइड सेटिंग्स की जाँच करती है। यह अद्वितीय पहचानकर्ता, जैसे स्लाइड IDs, या गतिशील प्लेसहोल्डर मान, जैसे वर्तमान तिथि, की तुलना नहीं करती।

```python
import aspose.slides as slides

with slides.Presentation("first.pptx") as first_presentation:
    with slides.Presentation("second.pptx") as second_presentation:
        first_presentation_master_count = len(first_presentation.masters)
        second_presentation_master_count = len(second_presentation.masters)

        for first_master_index in range(first_presentation_master_count):
            for second_master_index in range(second_presentation_master_count):
                first_master_slide = first_presentation.masters[first_master_index]
                second_master_slide = second_presentation.masters[second_master_index]
                are_master_slides_equal = first_master_slide.equals(second_master_slide)

                if are_master_slides_equal:
                    print(
                        "first.pptx master #{} equals second.pptx master #{}".format(
                            first_master_index,
                            second_master_index))
```

अधिक जानकारी के लिए देखें: [Compare Presentation Slides](/slides/hi/python-net/compare-slides/)।

## **डिफ़ॉल्ट दृश्य के रूप में स्लाइड मास्टर दृश्य सेट करें**

प्रस्तुति के [ViewProperties](https://reference.aspose.com/slides/hi/python-net/aspose.slides/viewproperties/) पर `last_view` गुण का उपयोग करके वह दृश्य नियंत्रित किया जा सकता है जो PowerPoint पहले खोलता है। निम्न उदाहरण प्रस्तुति को स्लाइड मास्टर दृश्य में खोलता है:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.view_properties.last_view = slides.ViewType.SLIDE_MASTER_VIEW
    presentation.save("presentation-master-view.pptx", slides.export.SaveFormat.PPTX)
```

अधिक दृश्य सेटिंग्स के लिए देखें: [Save Presentation](/slides/hi/python-net/save-presentation/)।

## **अनुपयोगी मास्टर स्लाइड्स हटाएँ**

कभी‑कभी प्रस्तुतियों में ऐसी मास्टर स्लाइड्स होती हैं जो किसी भी सामान्य स्लाइड द्वारा उपयोग नहीं की जा रही होतीं। अनुपयोगी मास्टर को हटाने से फ़ाइल आकार घट सकता है और टेम्पलेट रखरखाव सरल हो सकता है।

`masters` संग्रह से अनुपयोगी मास्टर को हटाने के लिए `remove_unused` का उपयोग करें:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.masters.remove_unused(True)
    presentation.save("presentation-clean.pptx", slides.export.SaveFormat.PPTX)
```

आप कम‑कोड `remove_unused_master_slides` मेथड को [Compress](https://reference.aspose.com/slides/hi/python-net/aspose.slides.lowcode/compress/) क्लास से भी उपयोग कर सकते हैं:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_master_slides(presentation)
    presentation.save("presentation-clean.pptx", slides.export.SaveFormat.PPTX)
```

## **अक्सर पूछे जाने वाले प्रश्न**

**स्लाइड मास्टर और लेआउट स्लाइड में क्या अंतर है?**

एक स्लाइड मास्टर थीम, पृष्ठभूमि, सामान्य आकार और टेक्स्ट शैलियों जैसी साझा डिज़ाइन सेटिंग्स को परिभाषित करता है। एक लेआउट स्लाइड मास्टर स्लाइड से जुड़ी होती है और प्लेसहोल्डर्स की विशिष्ट व्यवस्था को परिभाषित करती है। एक सामान्य स्लाइड लेआउट स्लाइड का उपयोग करती है, इसलिए वह दोनों लेआउट और मास्टर से विरासत में लेती है।

**क्या एक प्रस्तुति में कई स्लाइड मास्टर हो सकते हैं?**

हाँ। एक प्रस्तुति में कई स्लाइड मास्टर हो सकते हैं। अलग‑अलग सेक्शन को अलग‑अलग दृश्य प्रणाली या ब्रांडिंग की आवश्यकता होने पर कई मास्टर का उपयोग करें।

**मास्टर स्लाइड में या लेआउट स्लाइड में प्लेसहोल्डर्स जोड़ने चाहिए?**

अधिकांश मामलों में, प्लेसहोल्डर्स को लेआउट स्लाइड्स में जोड़ें। साझा दृश्य तत्व और साझा फ़ॉर्मेटिंग को मास्टर स्लाइड पर रखें, और सामग्री प्लेसहोल्डर्स को उन लेआउट्स पर रखें जिन्हें सामान्य स्लाइड्स उपयोग करेंगी।

**क्या मैं अभी भी उपयोग में होने वाली मास्टर स्लाइड को हटा सकता हूँ?**

नहीं। एक मास्टर स्लाइड जिसे निर्भर स्लाइड्स हैं, उसे सीधे सुरक्षित रूप से नहीं हटाया जा सकता। पहले उन स्लाइड्स को किसी अन्य मास्टर के लेआउट्स में स्थानांतरित करें, या अनउपयोगी‑मास्टर साफ़‑सफ़ाई मेथड का उपयोग करें जो केवल अप्रयुक्त मास्टर को हटाता है।