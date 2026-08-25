---
title: Python में प्रस्तुति स्लाइड मास्टर को प्रबंधित करें
linktitle: स्लाइड मास्टर
type: docs
weight: 80
url: /hi/python-net/slide-master/
keywords:
- स्लाइड मास्टर
- मास्टर स्लाइड
- PPT मास्टर स्लाइड
- एकाधिक मास्टर स्लाइड्स
- मास्टर स्लाइड्स की तुलना करें
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
- Aspose.Slides
description: "Aspose.Slides for Python via .NET में स्लाइड मास्टर को प्रबंधित करें: PowerPoint और OpenDocument प्रस्तुतियों में मास्टर स्लाइडों तक पहुँच, संपादन, क्लोन, तुलना और हटाना।"
---
## **सारांश**

एक **slide master** कई स्लाइडों के समूह के लिए साझा डिज़ाइन सेटिंग्स को परिभाषित करता है। इसमें सामान्य आकार, लोगो, पृष्ठभूमि, टेक्स्ट शैलियां, थीम सेटिंग्स और फुटर सेटिंग्स शामिल हो सकते हैं। PowerPoint में, slide master को संपादित करना वह सामान्य तरीका है जिससे प्रस्तुति को लगातार समान स्वरूप में रखा जा सकता है, बिना हर स्लाइड पर समान फ़ॉर्मेटिंग दोहराए।

Aspose.Slides for Python via .NET भी वही मॉडल समर्थन करता है। एक प्रस्तुति में एक या अधिक master स्लाइडें हो सकती हैं, और प्रत्येक master स्लाइड में कई layout स्लाइडें हो सकती हैं। सामान्य स्लाइडें सीधे master स्लाइड को संदर्भित नहीं करतीं। इसके बजाय, एक सामान्य स्लाइड एक layout स्लाइड का उपयोग करती है, और वह layout स्लाइड किसी master स्लाइड से संबंधित होती है।

क्रमविन्यास इस प्रकार है:

1. **Slide master** – साझा डिज़ाइन और थीम को परिभाषित करता है।  
2. **Layout slide** – प्लेसहोल्डर और लेआउट-स्तर फ़ॉर्मेटिंग की विशिष्ट व्यवस्था को परिभाषित करता है।  
3. **Normal slide** – वास्तविक प्रस्तुति सामग्री को रखता है और एक layout स्लाइड का उपयोग करता है।

![master slides, layout slides, और normal slides का क्रमविन्यास](slide-master_2.jpg)

Aspose.Slides में, एक slide master को [MasterSlide](https://reference.aspose.com/slides/hi/python-net/aspose.slides/masterslide/) क्लास द्वारा प्रतिनिधित्व किया जाता है। प्रस्तुति में सभी master स्लाइडें `Presentation.masters` कलेक्शन के माध्यम से उपलब्ध हैं।

{{% alert color="info" title="Inheritance" %}}
जब एक ही प्रॉपर्टी एक से अधिक स्तर पर परिभाषित होती है, तो अधिक विशिष्ट स्तर को प्राथमिकता मिलती है। उदाहरण के लिए, यदि एक master slide और एक layout slide दोनों एक पृष्ठभूमि परिभाषित करते हैं, तो उस लेआउट पर आधारित स्लाइडें लेआउट की पृष्ठभूमि का उपयोग करती हैं। लेआउट स्लाइडों के बारे में अधिक जानकारी के लिए देखें [Apply or Change Slide Layouts](/slides/hi/python-net/slide-layout/)।
{{% /alert %}}

## **Slide Masters तक पहुँच**

PowerPoint में, आप **View** > **Slide Master** से Slide Master व्यू खोल सकते हैं।

![PowerPoint View टैब पर Slide Master कमांड](slide-master_3.jpg)

Aspose.Slides में, master स्लाइडों तक पहुँचने के लिए `masters` कलेक्शन का उपयोग करें:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    first_master_slide = presentation.masters[0]
    master_slide_count = len(presentation.masters)
    first_master_layout_slide_count = len(first_master_slide.layout_slides)

    print("Master slides: " + str(master_slide_count))
    print("Layouts in the first master: " + str(first_master_layout_slide_count))
```

आप सामान्य स्लाइड के लेआउट के माध्यम से उपयोग की गई master slide को भी प्राप्त कर सकते हैं:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]
    layout_slide = slide.layout_slide
    master_slide = layout_slide.master_slide
    master_slide_name = master_slide.name

    print(master_slide_name)
```

## **Slide Master में क्या होता है**

एक master slide एक स्लाइड‑समान वस्तु है। यह [BaseSlide](https://reference.aspose.com/slides/hi/python-net/aspose.slides/baseslide/) क्लास से सामान्य स्लाइड व्यवहार को विरासत में लेता है, इसलिए यह सामान्य और layout स्लाइडों द्वारा उपयोग किए जाने वाले कई समान स्लाइड प्रॉपर्टीज़ को उजागर करता है। master‑विशिष्ट सदस्य [MasterSlide](https://reference.aspose.com/slides/hi/python-net/aspose.slides/masterslide/) API पृष्ठ पर सूचीबद्ध हैं।

सामान्यतः उपयोग किए जाने वाले master slide सदस्यों में शामिल हैं:

| सदस्य | उद्देश्य |
| --- | --- |
| `background` | master‑स्तर की स्लाइड पृष्ठभूमि सेट करता है। |
| `shapes` | master पर रखे गए आकारों को संग्रहीत करता है, जैसे लोगो, चित्र फ्रेम, और साझा टेक्स्ट। |
| `layout_slides` | उन layout स्लाइडों को संग्रहीत करता है जो master से संबंधित हैं। |
| `theme_manager` | master थीम API तक पहुँच प्रदान करता है। |
| `header_footer_manager` | master और उसकी चाइल्ड लेआउट्स के लिए हेडर, फुटर, तिथियां, और स्लाइड नंबर नियंत्रित करता है। |
| `get_depending_slides` | उन normal स्लाइडों को लौटाता है जो अपने लेआउट के माध्यम से master पर निर्भर हैं। |

## **Slide Master में छवि जोड़ना**

जब आप एक master slide में छवि जोड़ते हैं, तो वह उस master से लेआउट प्रयोग करने वाली सभी स्लाइडों में दिखती है। यह लोगो, वॉटरमार्क, सजावटी बैंड, और अन्य दोहराए जाने वाले दृश्य तत्वों के लिए उपयोगी है।

निम्न उदाहरण पहले master slide में एक लोगो जोड़ता है:

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

चित्र फ्रेम के बारे में अधिक जानकारी के लिए देखें [Picture Frame](/slides/hi/python-net/picture-frame/)।

## **Placeholders के साथ कार्य करना**

Placeholders आम तौर पर layout स्लाइडों पर परिभाषित होते हैं। master slide साझा शैली और थीम प्रदान करता है जिसे लेआउट विरासत में लेते हैं, जबकि प्रत्येक लेआउट तय करता है कि कौन से placeholders उपलब्ध हैं और वे कहाँ रखे गए हैं।

PowerPoint में, placeholder कमांड Slide Master व्यू में उपलब्ध हैं।

![PowerPoint Slide Master व्यू में Insert Placeholder कमांड](slide-master_5.png)

Aspose.Slides के साथ नए placeholders जोड़ने के लिए, master से संबंधित layout स्लाइड पर कार्य करें:

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

आप master slide पर पहले से मौजूद placeholder आकारों को भी फ़ॉर्मेट कर सकते हैं। निम्न उदाहरण शीर्षक placeholder को खोजता है और एक रैखिक ग्रेडिएंट भराव लागू करता है:

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

![समान रूप से फ़ॉर्मेट किया गया शीर्षक placeholder जिसे normal स्लाइडों ने विरासत में प्राप्त किया है](slide-master_8.png)

अधिक placeholder और टेक्स्ट फ़ॉर्मेटिंग विकल्पों के लिए देखें [Set Prompt Text in Placeholder](/slides/hi/python-net/manage-placeholder/) और [Text Formatting](/slides/hi/python-net/text-formatting/)।

## **Slide Master पृष्ठभूमि बदलना**

एक master पृष्ठभूमि को लेआउट और उन स्लाइडों द्वारा विरासत में लिया जाता है जो इसे ओवरराइड नहीं करतीं। निम्न उदाहरण पहले master slide के लिए एक ठोस पृष्ठभूमि रंग सेट करता है:

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

संबंधित विषयों के लिए देखें [Presentation Background](/slides/hi/python-net/presentation-background/) और [Presentation Theme](/slides/hi/python-net/presentation-theme/)।

## **Slide Master को किसी अन्य प्रस्तुति में क्लोन करना**

[MasterSlideCollection](https://reference.aspose.com/slides/hi/python-net/aspose.slides/masterslidecollection/) क्लास पर `add_clone` मेथड का उपयोग करके एक master slide को दूसरी प्रस्तुति में कॉपी करें। कॉपी किया गया master फिर लक्ष्य प्रस्तुति में लेआउट और स्लाइडों द्वारा उपयोग किया जा सकता है।

```python
import aspose.slides as slides

with slides.Presentation("source.pptx") as source_presentation:
    with slides.Presentation("destination.pptx") as destination_presentation:
        source_master_slide = source_presentation.masters[0]
        cloned_master_slide = destination_presentation.masters.add_clone(source_master_slide)

        destination_presentation.save("destination-with-master.pptx", slides.export.SaveFormat.PPTX)
```

यदि आपको master के साथ normal स्लाइडों को भी क्लोन करना है, तो देखें [Clone Slides](/slides/hi/python-net/clone-slides/)।

## **एक से अधिक Slide Masters जोड़ना**

एक प्रस्तुति में कई master स्लाइडें हो सकती हैं। यह तब उपयोगी होता है जब विभिन्न अनुभागों को अलग‑अलग ब्रांडिंग, पृष्ठ संरचना, या थीम सेटिंग्स की आवश्यकता होती है।

![master स्लाइडों को सम्मिलित और प्रबंधित करने के लिए PowerPoint कमांड](slide-master_9.jpg)

निम्न उदाहरण डिफ़ॉल्ट master को क्लोन करता है, क्लोन को अलग पृष्ठभूमि देता है, उस क्लोन किए गए master के तहत एक खाली लेआउट प्राप्त करता है, और उस लेआउट के आधार पर एक नई स्लाइड जोड़ता है:

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

## **Slide Masters की तुलना करना**

Master स्लाइडों की तुलना `equals` मेथड से की जा सकती है, जो [BaseSlide](https://reference.aspose.com/slides/hi/python-net/aspose.slides/baseslide/) क्लास से विरासत में मिली है। तुलना संरचना और स्थैतिक सामग्री की जाँच करती है, जैसे आकार, टेक्स्ट, फ़ॉर्मेटिंग, एनीमेशन, और अन्य स्लाइड सेटिंग्स। यह अनन्य पहचानकर्ताओं जैसे slide IDs या गतिशील placeholder मानों (जैसे वर्तमान तिथि) की तुलना नहीं करती।

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

अधिक जानकारी के लिए देखें [Compare Presentation Slides](/slides/hi/python-net/compare-slides/)।

## **डिफ़ॉल्ट व्यू के रूप में Slide Master व्यू सेट करना**

प्रेज़ेंटेशन के [ViewProperties](https://reference.aspose.com/slides/hi/python-net/aspose.slides/viewproperties/) पर `last_view` प्रॉपर्टी का उपयोग करके PowerPoint द्वारा पहली बार खोले जाने वाले व्यू को नियंत्रित करें। निम्न उदाहरण प्रस्तुति को Slide Master व्यू में खोलता है:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.view_properties.last_view = slides.ViewType.SLIDE_MASTER_VIEW
    presentation.save("presentation-master-view.pptx", slides.export.SaveFormat.PPTX)
```

अधिक व्यू सेटिंग्स के लिए देखें [Save Presentation](/slides/hi/python-net/save-presentation/)।

## **अप्रयोगी Master Slides को हटाना**

कभी‑कभी प्रस्तुतियों में ऐसे master स्लाइडें रहती हैं जो अब किसी normal स्लाइड द्वारा उपयोग नहीं की जा रही होतीं। अप्रयोगी masters को हटाने से फ़ाइल आकार छोटा हो सकता है और टेम्पलेट रखरखाव सरल हो जाता है।

`masters` कलेक्शन से अप्रयोगी masters को हटाने के लिए `remove_unused` का उपयोग करें:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.masters.remove_unused(True)
    presentation.save("presentation-clean.pptx", slides.export.SaveFormat.PPTX)
```

आप नीचे‑कोड वाले `remove_unused_master_slides` मेथड को भी उपयोग कर सकते हैं, जो [Compress](https://reference.aspose.com/slides/hi/python-net/aspose.slides.lowcode/compress/) क्लास का हिस्सा है:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_master_slides(presentation)
    presentation.save("presentation-clean.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

### Slide master और layout slide में क्या अंतर है?

एक slide master थीम, पृष्ठभूमि, सामान्य आकार, और टेक्स्ट शैलियों जैसी साझा डिज़ाइन सेटिंग्स को परिभाषित करता है। एक layout slide एक master slide का हिस्सा होती है और placeholders की विशिष्ट व्यवस्था को परिभाषित करती है। एक normal slide एक layout slide का उपयोग करती है, इसलिए वह लेआउट और master दोनों से विरासत में प्राप्त होती है।

### क्या एक प्रस्तुति में कई slide masters हो सकते हैं?

हाँ। एक प्रस्तुति में कई slide masters हो सकते हैं। विभिन्न अनुभागों को अलग‑अलग दृश्य सिस्टम या ब्रांडिंग की आवश्यकता होने पर कई masters का उपयोग करें।

### मुझे placeholders master slide में जोड़ने चाहिए या layout slide में?

अधिकांश मामलों में, placeholders को layout स्लाइडों में जोड़ें। साझा दृश्य तत्व और साझा फ़ॉर्मेटिंग master slide पर रखें, और सामग्री placeholders को उन लेआउट्स पर रखें जो normal स्लाइडें उपयोग करेंगी।

### क्या मैं किसी master slide को हटा सकता हूँ जो अभी भी उपयोग में है?

नहीं। जिस master slide के नीचे निर्भरताएँ मौजूद हैं, उसे सीधे हटाना सुरक्षित नहीं है। पहले उन स्लाइडों को किसी अन्य master के लेआउट में स्थानांतरित करें, या केवल अप्रयुक्त masters को हटाने वाली सफ़ाई विधि का उपयोग करें।