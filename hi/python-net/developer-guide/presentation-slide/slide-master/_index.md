---
title: Python में प्रस्तुति स्लाइड मास्टर प्रबंधित करें
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
- अप्रयुक्त मास्टर स्लाइड
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET में स्लाइड मास्टर का प्रबंधन: PowerPoint और OpenDocument प्रस्तुतियों में मास्टर स्लाइडों तक पहुंच, संपादन, क्लोन, तुलना और हटाना।"
---
## **परिचय**

एक **स्लाइड मास्टर** स्लाइडों के समूह के लिए साझा डिज़ाइन सेटिंग्स को परिभाषित करता है। इसमें सामान्य आकार, लोगो, पृष्ठभूमि, टेक्स्ट शैलियाँ, थीम सेटिंग्स और फ़ुटर सेटिंग्स शामिल हो सकते हैं। PowerPoint में, स्लाइड मास्टर को संपादित करना प्रस्तुति को सुसंगत रखने का सामान्य तरीका है, जिससे हर स्लाइड पर एक ही फ़ॉर्मेटिंग दोहराने की आवश्यकता नहीं पड़ती।

Aspose.Slides for Python via .NET समान मॉडल का समर्थन करता है। एक प्रस्तुति में एक या अधिक मास्टर स्लाइड हो सकते हैं, और प्रत्येक मास्टर स्लाइड में कई लेआउट स्लाइड शामिल हो सकते हैं। सामान्य स्लाइड आमतौर पर सीधे मास्टर स्लाइड को संदर्भित नहीं करतीं। इसके बजाय, एक सामान्य स्लाइड लेआउट स्लाइड का उपयोग करती है, और वह लेआउट स्लाइड एक मास्टर स्लाइड से संबंधित होती है।

The hierarchy is:

1. **स्लाइड मास्टर** - साझा डिज़ाइन और थीम को परिभाषित करता है।
1. **लेआउट स्लाइड** - placeholders और लेआउट‑स्तर के फ़ॉर्मेटिंग की विशिष्ट व्यवस्था को परिभाषित करता है।
1. **सामान्य स्लाइड** - वास्तविक प्रस्तुति सामग्री को रखती है और एक लेआउट स्लाइड का उपयोग करती है।

![मास्टर स्लाइड, लेआउट स्लाइड और सामान्य स्लाइड की पदानुक्रम](slide-master_2.jpg)

Aspose.Slides में, स्लाइड मास्टर को [MasterSlide](https://reference.aspose.com/slides/hi/python-net/aspose.slides/masterslide/) क्लास द्वारा दर्शाया जाता है। किसी प्रस्तुति में सभी मास्टर स्लाइड `Presentation.masters` संग्रह के माध्यम से उपलब्ध हैं।

{{% alert color="info" title="Inheritance" %}}
जब एक ही प्रॉपर्टी एक से अधिक स्तरों पर परिभाषित की जाती है, तो अधिक विशिष्ट स्तर जीतता है। उदाहरण के लिए, यदि एक मास्टर स्लाइड और एक लेआउट स्लाइड दोनों पृष्ठभूमि निर्धारित करते हैं, तो उस लेआउट पर आधारित स्लाइडें लेआउट पृष्ठभूमि का उपयोग करती हैं। लेआउट स्लाइड के बारे में अधिक जानकारी के लिए देखें [स्लाइड लेआउट लागू करें या बदलें](/python-net/slide-layout/)।
{{% /alert %}}

## **स्लाइड मास्टर तक पहुंच**

PowerPoint में, आप **व्यू** > **स्लाइड मास्टर** से स्लाइड मास्टर व्यू खोल सकते हैं।

![PowerPoint व्यू टैब पर स्लाइड मास्टर कमांड](slide-master_3.jpg)

Aspose.Slides में, मास्टर स्लाइड तक पहुंचने के लिए `masters` संग्रह का उपयोग करें:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    first_master_slide = presentation.masters[0]
    master_slide_count = len(presentation.masters)
    first_master_layout_slide_count = len(first_master_slide.layout_slides)

    print("Master slides: " + str(master_slide_count))
    print("Layouts in the first master: " + str(first_master_layout_slide_count))
```

आप सामान्य स्लाइड द्वारा उपयोग की गई मास्टर स्लाइड को उसके लेआउट के माध्यम से भी प्राप्त कर सकते हैं:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]
    layout_slide = slide.layout_slide
    master_slide = layout_slide.master_slide
    master_slide_name = master_slide.name

    print(master_slide_name)
```

## **स्लाइड मास्टर में क्या होता है**

मास्टर स्लाइड एक स्लाइड जैसा ऑब्जेक्ट है। यह सामान्य स्लाइड व्यवहार को [BaseSlide](https://reference.aspose.com/slides/hi/python-net/aspose.slides/baseslide/) क्लास से विरासत में लेता है, इसलिए यह सामान्य और लेआउट स्लाइड द्वारा उपयोग किए जाने वाले कई समान स्लाइड प्रॉपर्टीज़ को उजागर करता है। मास्टर‑विशिष्ट सदस्य [MasterSlide](https://reference.aspose.com/slides/hi/python-net/aspose.slides/masterslide/) API पेज पर सूचीबद्ध हैं।

Commonly used master slide members include:

| सदस्य | उद्देश्य |
| --- | --- |
| `background` | मास्टर‑स्तर की स्लाइड पृष्ठभूमि सेट करता है। |
| `shapes` | मास्टर पर रखे गए आकार, जैसे लोगो, चित्र फ़्रेम, और साझा टेक्स्ट को संग्रहीत करता है। |
| `layout_slides` | मास्टर से जुड़े लेआउट स्लाइड को संग्रहीत करता है। |
| `theme_manager` | मास्टर थीम API तक पहुँच प्रदान करता है। |
| `header_footer_manager` | मास्टर और उसके चाइल्ड लेआउट्स के लिए हेडर, फुटर, तारीखें, और स्लाइड नंबर नियंत्रित करता है। |
| `get_depending_slides` | उन सामान्य स्लाइड्स को लौटाता है जो अपने लेआउट के माध्यम से मास्टर पर निर्भर करती हैं। |

## **स्लाइड मास्टर में छवि जोड़ें**

जब आप एक मास्टर स्लाइड में छवि जोड़ते हैं, तो वह उन स्लाइडों पर दिखाई देती है जो उस मास्टर के लेआउट का उपयोग करती हैं। यह लोगो, वॉटरमार्क, सजावटी बैंड और अन्य दोहराए जाने वाले दृश्य तत्वों के लिए उपयोगी है।

निम्नलिखित उदाहरण पहले मास्टर स्लाइड में एक लोगो जोड़ता है:
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

चित्र फ़्रेम के बारे में अधिक जानकारी के लिए देखें [Picture Frame](/python-net/picture-frame/)।

## **प्लेसहोल्डर के साथ काम करें**

प्लेसहोल्डर सामान्यतः लेआउट स्लाइड पर परिभाषित होते हैं। मास्टर स्लाइड उन लेआउट्स को साझा शैली और थीम प्रदान करता है, जबकि प्रत्येक लेआउट तय करता है कि कौन से प्लेसहोल्डर उपलब्ध हैं और उन्हें कहाँ रखा गया है।

PowerPoint में, प्लेसहोल्डर कमांड स्लाइड मास्टर व्यू में उपलब्ध हैं।

![PowerPoint स्लाइड मास्टर व्यू में प्लेसहोल्डर सम्मिलित कमांड](slide-master_5.png)

Aspose.Slides के साथ नए प्लेसहोल्डर जोड़ने के लिए, मास्टर से संबंधित लेआउट स्लाइड के साथ कार्य करें:
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

आप एक मास्टर स्लाइड पर पहले से मौजूद प्लेसहोल्डर आकार को भी फ़ॉर्मेट कर सकते हैं। निम्नलिखित उदाहरण शीर्षक प्लेसहोल्डर को खोजता है और एक रैखिक ग्रेडिएंट फ़िल लागू करता है:
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
        title_placeholder.fill_format.gradient_format.gradient_stops.add(255, purple_gradient_color)

    presentation.save("presentation-title-style.pptx", slides.export.SaveFormat.PPTX)
```

![सामान्य स्लाइड द्वारा विरासत में प्राप्त फ़ॉर्मेट किया गया शीर्षक प्लेसहोल्डर](slide-master_8.png)

प्लेसहोल्डर और टेक्स्ट फ़ॉर्मेटिंग विकल्पों के लिए अधिक जानकारी के लिए देखें [प्लेसहोल्डर में प्रॉम्प्ट टेक्स्ट सेट करें](/python-net/manage-placeholder/) और [टेक्स्ट फ़ॉर्मेटिंग](/python-net/text-formatting/)।

## **स्लाइड मास्टर पृष्ठभूमि बदलें**

मास्टर पृष्ठभूमि उन लेआउट्स और स्लाइड्स द्वारा विरासत में मिलती है जो इसे ओवरराइड नहीं करतीं। निम्नलिखित उदाहरण पहले मास्टर स्लाइड के लिए एक सॉलिड पृष्ठभूमि रंग सेट करता है:
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

संबंधित विषयों के लिए देखें [प्रेज़ेंटेशन पृष्ठभूमि](/python-net/presentation-background/) और [प्रेज़ेंटेशन थीम](/python-net/presentation-theme/)।

## **एक स्लाइड मास्टर को अन्य प्रेज़ेंटेशन में क्लोन करें**

[MasterSlideCollection](https://reference.aspose.com/slides/hi/python-net/aspose.slides/masterslidecollection/) क्लास पर `add_clone` मेथड का उपयोग करके एक मास्टर स्लाइड को किसी अन्य प्रेज़ेंटेशन में कॉपी करें। कॉपी किया गया मास्टर फिर लक्ष्य प्रेज़ेंटेशन के लेआउट्स और स्लाइड्स द्वारा उपयोग किया जा सकता है।

निम्नलिखित उदाहरण:
```python
import aspose.slides as slides

with slides.Presentation("source.pptx") as source_presentation:
    with slides.Presentation("destination.pptx") as destination_presentation:
        source_master_slide = source_presentation.masters[0]
        cloned_master_slide = destination_presentation.masters.add_clone(source_master_slide)

        destination_presentation.save("destination-with-master.pptx", slides.export.SaveFormat.PPTX)
```

यदि आपको उनके मास्टर के साथ सामान्य स्लाइड्स को क्लोन करने की आवश्यकता है, तो देखें [स्लाइड्स क्लोन करें](/python-net/clone-slides/)।

## **एकाधिक स्लाइड मास्टर जोड़ें**

एक प्रेज़ेंटेशन में कई मास्टर स्लाइड हो सकते हैं। यह तब उपयोगी होता है जब विभिन्न अनुभागों को अलग-अलग ब्रांडिंग, पेज संरचना, या थीम सेटिंग्स की आवश्यकता होती है।

![मास्टर स्लाइड्स को जोड़ने और प्रबंधित करने के लिए PowerPoint कमांड्स](slide-master_9.jpg)

निम्नलिखित उदाहरण डिफ़ॉल्ट मास्टर को क्लोन करता है, क्लोन को अलग पृष्ठभूमि देता है, उस क्लोन किए गए मास्टर के अंतर्गत एक खाली लेआउट प्राप्त करता है, और उस लेआउट पर आधारित एक नई स्लाइड जोड़ता है:
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

मास्टर स्लाइड को [BaseSlide](https://reference.aspose.com/slides/hi/python-net/aspose.slides/baseslide/) क्लास से विरासत में मिले `equals` मेथड के द्वारा तुलना की जा सकती है। तुलना संरचना और स्थैतिक सामग्री की जाँच करती है, जैसे आकार, टेक्स्ट, फ़ॉर्मेटिंग, एनीमेशन, और अन्य स्लाइड सेटिंग्स। यह विशेष पहचानकर्ताओं, जैसे स्लाइड IDs, या गतिशील प्लेसहोल्डर मानों, जैसे वर्तमान तिथि, की तुलना नहीं करती।

निम्नलिखित उदाहरण:
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

अधिक जानकारी के लिए देखें [Compare Presentation Slides](/python-net/compare-slides/)।

## **डिफ़ॉल्ट व्यू के रूप में स्लाइड मास्टर व्यू सेट करें**

प्रेज़ेंटेशन के [ViewProperties](https://reference.aspose.com/slides/hi/python-net/aspose.slides/viewproperties/) पर `last_view` प्रॉपर्टी का उपयोग करके PowerPoint द्वारा पहली बार खोले जाने वाले व्यू को नियंत्रित करें। निम्नलिखित उदाहरण स्लाइड मास्टर व्यू में प्रेज़ेंटेशन खोलता है:
```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.view_properties.last_view = slides.ViewType.SLIDE_MASTER_VIEW
    presentation.save("presentation-master-view.pptx", slides.export.SaveFormat.PPTX)
```

अधिक व्यू सेटिंग्स के लिए देखें [Save Presentation](/python-net/save-presentation/)।

## **अप्रयुक्त मास्टर स्लाइड्स हटाएँ**

कभी-कभी प्रेज़ेंटेशन में ऐसे मास्टर स्लाइड्स होते हैं जो किसी भी सामान्य स्लाइड द्वारा उपयोग नहीं किए जाते हैं। अप्रयुक्त मास्टर को हटाने से फ़ाइल आकार कम हो सकता है और टेम्पलेट रखरखाव सरल हो जाता है।

अप्रयुक्त मास्टर को `masters` संग्रह से हटाने के लिए `remove_unused` का उपयोग करें:
```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.masters.remove_unused(True)
    presentation.save("presentation-clean.pptx", slides.export.SaveFormat.PPTX)
```

आप [Compress](https://reference.aspose.com/slides/hi/python-net/aspose.slides.lowcode/compress/) क्लास की लो‑कोड `remove_unused_master_slides` मेथड का भी उपयोग कर सकते हैं:
```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_master_slides(presentation)
    presentation.save("presentation-clean.pptx", slides.export.SaveFormat.PPTX)
```

## **अक्सर पूछे जाने वाले प्रश्न**

**स्लाइड मास्टर और लेआउट स्लाइड में क्या अंतर है?**

स्लाइड मास्टर थीम, पृष्ठभूमि, सामान्य आकार, और टेक्स्ट शैलियों जैसी साझा डिज़ाइन सेटिंग्स को परिभाषित करता है। लेआउट स्लाइड एक मास्टर स्लाइड से संबंधित है और प्लेसहोल्डर की विशिष्ट व्यवस्था को परिभाषित करती है। सामान्य स्लाइड लेआउट स्लाइड का उपयोग करती है, इसलिए यह लेआउट और मास्टर दोनों से विरासत में प्राप्त करती है।

**क्या एक प्रेज़ेंटेशन में कई स्लाइड मास्टर हो सकते हैं?**

हाँ। एक प्रेज़ेंटेशन में कई स्लाइड मास्टर हो सकते हैं। विभिन्न अनुभागों को अलग-अलग विज़ुअल सिस्टम या ब्रांडिंग की आवश्यकता होने पर कई मास्टर का उपयोग करें।

**क्या मुझे प्लेसहोल्डर मास्टर स्लाइड में जोड़ना चाहिए या लेआउट स्लाइड में?**

अधिकांश मामलों में, प्लेसहोल्डर को लेआउट स्लाइड में जोड़ें। साझा दृश्य तत्व और साझा फ़ॉर्मेटिंग को मास्टर स्लाइड पर रखें, फिर सामग्री प्लेसहोल्डर को उन लेआउट्स में रखें जिन्हें सामान्य स्लाइड उपयोग करेंगे।

**क्या मैं एक मास्टर स्लाइड जिसे अभी भी उपयोग किया जा रहा है, को हटा सकता हूँ?**

नहीं। एक मास्टर स्लाइड जिसमें निर्भर स्लाइड्स हैं, उसे सीधे सुरक्षित रूप से हटाया नहीं जा सकता। पहले उन स्लाइड्स को किसी अन्य मास्टर के तहत लेआउट्स में स्थानांतरित करें, या ऐसा अनउपयोगित‑मास्टर सफ़ाई मेथड उपयोग करें जो केवल उन मास्टर को हटाता है जो उपयोग में नहीं हैं।