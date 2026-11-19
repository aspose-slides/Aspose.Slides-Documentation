---
title: Python में प्रस्तुति हाइपरलिंक्स प्रबंधित करें
linktitle: हाइपरलिंक्स प्रबंधित करें
type: docs
weight: 20
url: /hi/python-net/manage-hyperlinks/
keywords:
- URL जोड़ें
- हाइपरलिंक जोड़ें
- हाइपरलिंक बनाएं
- हाइपरलिंक स्वरूपित करें
- हाइपरलिंक हटाएं
- हाइपरलिंक अपडेट करें
- पाठ हाइपरलिंक
- स्लाइड हाइपरलिंक
- आकार हाइपरलिंक
- छवि हाइपरलिंक
- वीडियो हाइपरलिंक
- परिवर्तनीय हाइपरलिंक
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET का उपयोग करके, Python उदाहरणों के साथ, PowerPoint और OpenDocument प्रस्तुतियों में हाइपरलिंक जोड़ें, स्वरूपित करें, अपडेट करें और हटाएँ।"
---
## **परिचय**

एक हाइपरलिंक प्रस्तुति सामग्री को वेबसाइट या प्रस्तुति के भीतर किसी स्थान से जोड़ता है। PowerPoint में, हाइपरलिंक आमतौर पर दो उद्देश्यों की पूर्ति करते हैं:

* पाठ, आकार, या मीडिया फ्रेम से वेबसाइट खोलना।
* किसी अन्य स्लाइड पर नेविगेट करना, उदाहरण के लिए, तालिका‑क्रम से।

Aspose.Slides for Python via .NET आपको ये लिंक जोड़ने, उनकी उपस्थिति और ध्वनि को नियंत्रित करने, गुणों को अपडेट करने और उन्हें हटाने की सुविधा देता है। नीचे के उदाहरण दिखाते हैं कि व्यक्तिगत तत्वों पर हाइपरलिंक के साथ कैसे काम करें और प्रस्तुति, स्लाइड या टेक्स्ट‑फ़्रेम स्तर पर हाइपरलिंक तक कैसे पहुँचें।

{{% alert color="info" title="Note" %}}
आप प्रस्तुतियों को भी [मुफ़्त ऑनलाइन Aspose PowerPoint संपादक](https://products.aspose.app/slides/editor) के साथ संपादित कर सकते हैं।
{{% /alert %}}

## **URL हाइपरलिंक जोड़ें**

आप पाठ, आकार या मीडिया फ्रेम को वेबसाइट URL असाइन कर सकते हैं। जिस तत्व को आप हाइपरलिंक असाइन करते हैं, वह क्लिक करने योग्य क्षेत्र निर्धारित करता है: पाठ का भाग चयनित पाठ को लिंक करता है, जबकि आकार या फ्रेम स्लाइड ऑब्जेक्ट को लिंक करता है।

सापेक्ष हाइपरलिंक वाली प्रस्तुतियों के लिए, देखें [Manage the Hyperlink Base](/slides/hi/python-net/presentation-properties/#manage-the-hyperlink-base) ताकि दस्तावेज‑स्तर बेस को पढ़ा, बदला या साफ़ किया जा सके।

### **पाठ में URL हाइपरलिंक जोड़ें**

पाठ को वेबसाइट से लिंक करने के लिए, नीचे दिखाए अनुसार पाठ भाग की [hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/hyperlink_click/) गुण को एक [Hyperlink](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/) असाइन करें। केवल वही पाठ भाग क्लिक करने योग्य बनता है।

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    text_shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50, False)
    text_shape.add_text_frame("Aspose: File Format APIs")
    portion_format = text_shape.text_frame.paragraphs[0].portions[0].portion_format
    portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    portion_format.hyperlink_click.tooltip = "Explore Aspose file format APIs"
    portion_format.font_height = 32
    presentation.save("presentation-out.pptx", slides.export.SaveFormat.PPTX)
```

### **आकार और मीडिया फ्रेम में URL हाइपरलिंक जोड़ें**

आयत की [hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/shape/hyperlink_click/) गुण को एक URL असाइन करें ताकि उसका पूरा क्षेत्र क्लिक करने योग्य बन जाए। [tooltip](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/tooltip/) दर्शकों को आयत पर होवर करने पर गंतव्य का संकेत देता है। वही गुण चित्र, ऑडियो और वीडियो फ्रेम पर भी लागू होते हैं।

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50)
    shape.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    shape.hyperlink_click.tooltip = "Explore Aspose file format APIs"
    presentation.save("presentation-out.pptx", slides.export.SaveFormat.PPTX)
```

## **हाइपरलिंक का उपयोग करके सामग्री तालिका बनाएं**

आंतरिक हाइपरलिंक दर्शकों को सामग्री तालिका से एक विशिष्ट स्लाइड पर कूदने की अनुमति देते हैं। निम्न उदाहरण पहले स्लाइड पर “Page 2” पाठ को दूसरे स्लाइड से लिंक करने के लिए [set_internal_hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkmanager/set_internal_hyperlink_click/) का उपयोग करता है।

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    first_slide = presentation.slides[0]
    second_slide = presentation.slides.add_empty_slide(first_slide.layout_slide)
    table_of_contents = first_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 300, 100)
    table_of_contents.fill_format.fill_type = slides.FillType.NO_FILL
    table_of_contents.line_format.fill_format.fill_type = slides.FillType.NO_FILL
    table_of_contents.text_frame.paragraphs.clear()
    paragraph = slides.Paragraph()
    paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    paragraph.text = "Title of slide 2 .......... "
    link_portion = slides.Portion()
    link_portion.text = "Page 2"
    link_portion.portion_format.hyperlink_manager.set_internal_hyperlink_click(second_slide)
    paragraph.portions.add(link_portion)
    table_of_contents.text_frame.paragraphs.add(paragraph)
    presentation.save("link_to_slide.pptx", slides.export.SaveFormat.PPTX)
```

## **हाइपरलिंक को स्वरूपित करें**

आप लिंकेड पाठ का रंग बदल सकते हैं, लिंक सक्रिय होने पर ध्वनि चला या रोक सकते हैं, तथा होवर करने पर दिखने वाला टूलटिप सेट कर सकते हैं।

### **रंग**

[Hyperlink](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/) की [color_source](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/color_source/) गुण निर्धारित करता है कि हाइपरलिंक प्रस्तुति के हाइपरलिंक रंग का उपयोग करे या पाठ भाग के फॉर्मेट का। कस्टम टेक्स्ट रंग लागू करने के लिए [HyperlinkColorSource.PORTION_FORMAT](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkcolorsource/) चुनें और भाग की फ़िल रंग सेट करें। यह सुविधा PowerPoint 2019 में जोड़ी गई थी; पुराने संस्करण इस सेटिंग को लागू नहीं करते।

इस उदाहरण में, पहला लिंक पर [color_source](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/color_source/) सेट करने से उसका टेक्स्ट लाल दिखता है। दूसरा लिंक प्रस्तुति के हाइपरलिंक रंग को बरकरार रखता है।

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    colored_shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 450, 50, False)
    colored_shape.add_text_frame("This hyperlink uses a custom color.")
    colored_portion_format = colored_shape.text_frame.paragraphs[0].portions[0].portion_format
    colored_portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    colored_portion_format.hyperlink_click.color_source = slides.HyperlinkColorSource.PORTION_FORMAT
    colored_portion_format.fill_format.fill_type = slides.FillType.SOLID
    colored_portion_format.fill_format.solid_fill_color.color = draw.Color.red
    default_shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 450, 50, False)
    default_shape.add_text_frame("This hyperlink uses the default color.")
    default_shape.text_frame.paragraphs[0].portions[0].portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    presentation.save("presentation-out-hyperlink.pptx", slides.export.SaveFormat.PPTX)
```

### **ध्वनि**

हाइपरलिंक सक्रिय होने पर ध्वनि चला सकता है या पहले से चल रही ध्वनि को रोक सकता है। इन व्यवहारों को कॉन्फ़िगर करने के लिए निम्न गुण उपयोग करें:

- [Hyperlink.sound](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/sound/) हाइपरलिंक से जुड़े ऑडियो को निर्दिष्ट करता है।
- [Hyperlink.stop_sound_on_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/stop_sound_on_click/) निर्धारित करता है कि हाइपरलिंक सक्रिय होने पर पूर्व ध्वनि रोक दी जाए।

#### **हाइपरलिंक ध्वनि जोड़ें**

पहले स्लाइड पर बटन [sound](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/sound/) का उपयोग करके WAV फ़ाइल से ऑडियो चलाता है जब दर्शक आगे बढ़ने के लिए क्लिक करता है। दूसरे स्लाइड पर अलग बटन [stop_sound_on_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/stop_sound_on_click/) का उपयोग करके playback रोकता है और दर्शक को उसी स्लाइड पर रखता है।

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    with open("sampleaudio.wav", "rb") as audio_file:
        audio_data = audio_file.read()
    hyperlink_sound = presentation.audios.add_audio(audio_data)
    first_slide = presentation.slides[0]
    play_button = first_slide.shapes.add_auto_shape(slides.ShapeType.SOUND_BUTTON, 100, 100, 100, 50)
    play_button.hyperlink_click = slides.Hyperlink.next_slide
    if not play_button.hyperlink_click.stop_sound_on_click and play_button.hyperlink_click.sound is None:
        play_button.hyperlink_click.sound = hyperlink_sound

    second_slide = presentation.slides.add_empty_slide(first_slide.layout_slide)
    stop_button = second_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 100, 50)
    stop_button.hyperlink_click = slides.Hyperlink.no_action
    stop_button.hyperlink_click.stop_sound_on_click = True
    presentation.save("hyperlink-sound.pptx", slides.export.SaveFormat.PPTX)
```

#### **हाइपरलिंक ध्वनि निकालें**

निम्न उदाहरण ऊपर बनाई गई प्रस्तुति को खोलता है और पहले आकार की हाइपरलिंक ऑडियो को मेमोरी में [sound](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/sound/) और [binary_data](https://reference.aspose.com/slides/python-net/aspose.slides/audio/binary_data/) द्वारा पढ़ता है।

```python
import aspose.slides as slides

with slides.Presentation("hyperlink-sound.pptx") as presentation:
    if len(presentation.slides) > 0 and len(presentation.slides[0].shapes) > 0:
        hyperlink = presentation.slides[0].shapes[0].hyperlink_click
        sound = hyperlink.sound if hyperlink is not None else None
        if sound is not None:
            audio_data = sound.binary_data
            print(f"Extracted {len(audio_data)} bytes of hyperlink audio.")
        else:
            print("The first shape has no hyperlink sound.")
    else:
        print("The presentation has no first slide or shape to inspect.")
```

### **टूलटिप और इंटरेक्शन सेटिंग्स**

पाठ या आकार को हाइपरलिंक असाइन करने के बाद आप नीचे दिए गए [Hyperlink](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/) गुणों को अपडेट कर सकते हैं:

- [tooltip](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/tooltip/) दर्शक को लिंक के लिए संकेतात्मक टेक्स्ट प्रदान करता है।
- [target_frame](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/target_frame/) लागू होने पर पैरेंट HTML फ्रेमसेट के भीतर लक्ष्य फ्रेम निर्दिष्ट करता है।
- [history](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/history/) नियंत्रित करता है कि लिंक सक्रिय होने पर उसका गंतव्य देखे गए हाइपरलिंक्स की सूची में जोड़ा जाए या नहीं।
- [highlight_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/highlight_click/) नियंत्रित करता है कि क्लिक पर हाइपरलिंक हाइलाइट हो या नहीं।

## **प्रस्तुति से हाइपरलिंक हटाएँ**

[ get_any_hyperlinks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/) का उपयोग करके आप हाइपरलिंक कंटेनर, जिसमें पाठ‑भाग लिंक भी शामिल हैं, को इकट्ठा कर सकते हैं, इससे पहले कि आप उन्हें बदलें। नीचे के उदाहरण में पहले स्लाइड से दोनों सक्रियता प्रकार हटाए जाते हैं। केवल एक प्रकार हटाने के लिए, केवल [remove_hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_click/) या [remove_hyperlink_mouse_over](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_mouse_over/) को कॉल करें; क्लिक कार्रवाई को हटाने से उसकी माउस‑ओवर समकक्ष नहीं हटती।

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    if len(presentation.slides) > 0:
        containers = list(presentation.slides[0].hyperlink_queries.get_any_hyperlinks())
        for container in containers:
            container.hyperlink_manager.remove_hyperlink_click()
            container.hyperlink_manager.remove_hyperlink_mouse_over()
        presentation.save("pres-removed-hyperlinks.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The presentation has no slides to process.")
```

बिना शर्त हटाने के लिए, [remove_all_hyperlinks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/remove_all_hyperlinks/) चयनित स्कोप में दोनों सक्रियता प्रकारों को एक कॉल में हटा देता है। चयनात्मक सफ़ाई और मास्टर, लेआउट, तथा नोट्स की कवरेज के लिए देखें [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks)।

### **स्मार्टआर्ट टेक्स्ट बदलने से पहले हाइपरलिंक साफ़ करें**

जब आप मौजूदा स्मार्टआर्ट नोड में पैराग्राफ बदलते हैं, तो उसके टेक्स्ट भागों को साफ़ करने से पुराना हाइपरलिंक प्रभावी रह सकता है। पैराग्राफ को [SmartArtNode.text_frame](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartnode/text_frame/) के माध्यम से प्राप्त करें। भागों को साफ़ करने से पहले, नोड आकार के टेक्स्ट‑फ़्रेम पर [hyperlink_queries](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/hyperlink_queries/) के ज़रिए [remove_all_hyperlinks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/remove_all_hyperlinks/) को कॉल करें। यह फ़्रेम में प्रत्येक लिंक को हटा देता है, जिसमें अन्य पैराग्राफ में मौजूद लिंक भी शामिल हैं।

`SmartArtHyperlink.pptx` में पहला स्लाइड का तीसरा आकार एक स्मार्टआर्ट ग्राफिक है। उदाहरण में उसके चौथे नोड के पहले पैराग्राफ को बदला गया है। इस प्रस्तुति में, नोड का पहला आकार वही पैराग्राफ प्रदर्शित करता है।

दोनों भाग जोड़ने के बाद, उदाहरण उनके प्रभावी फॉर्मेट को [get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/get_effective/) के ज़रिए पढ़ता है। प्रभावी [hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/iportionformateffectivedata/hyperlink_click/) गुण पहले भाग के लिए नया हाइपरलिंक और दूसरे के लिए `None` लौटाता है।

```python
import aspose.slides as slides

with slides.Presentation("SmartArtHyperlink.pptx") as presentation:
    slide = presentation.slides[0]

    smart_art = slide.shapes[2]
    node = smart_art.all_nodes[3]
    paragraph = node.text_frame.paragraphs[0]

    node.shapes[0].text_frame.hyperlink_queries.remove_all_hyperlinks()
    paragraph.portions.clear()

    link = slides.Portion("New reference")
    link.portion_format.hyperlink_click = slides.Hyperlink("https://example.com/new")
    paragraph.portions.add(link)
    text = slides.Portion(" (updated)")
    paragraph.portions.add(text)

    print(link.portion_format.get_effective().hyperlink_click.external_url)  # https://example.com/new
    print(text.portion_format.get_effective().hyperlink_click)  # कोई नहीं
```

## **हाइपरलिंक इन्वेंट्री बनाएं**

प्रस्तुति वितरित करने से पहले, उसकी इंटरैक्टिव क्रियाओं और वेब लिंक की इन्वेंट्री तैयार करें। [get_any_hyperlinks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/) [IHyperlinkContainer](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlinkcontainer/) ऑब्जेक्ट्स लौटाता है, न कि URL स्ट्रिंग की फ्लैट लिस्ट। प्रत्येक कंटेनर पर दोनों [hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlinkcontainer/hyperlink_click/) और [hyperlink_mouse_over](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlinkcontainer/hyperlink_mouse_over/) की जांच करें। वे स्वतंत्र होते हैं: एक ही कंटेनर दोनों क्रियाओं को उजागर कर सकता है, इसलिए पूर्ण रिपोर्ट के लिए कंटेनर‑प्रति दो पंक्तियों की आवश्यकता हो सकती है।

केवल आकार‑स्तर के हाइपरलिंक को स्कैन करने से पाठ‑भागों पर जुड़े लिंक छूट सकते हैं। उपयुक्त स्कोप पर क्वेरी करें और लौटाए गए कंटेनरों को रखें ताकि बाद में आप उनके क्रियाएँ अपडेट या हटाएँ।

### **प्रस्तुति, स्लाइड, और टेक्स्ट‑फ़्रेम स्कोप की क्वेरी करें**

[HyperlinkQueries](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/) क्लास नीचे दिए गए माध्यम से उपलब्ध है: [Presentation.hyperlink_queries](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/hyperlink_queries/), [BaseSlide.hyperlink_queries](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/hyperlink_queries/), और [TextFrame.hyperlink_queries](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/hyperlink_queries/). प्रत्येक स्कोप समान क्वेरी को सपोर्ट करता है:

- [get_hyperlink_clicks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_hyperlink_clicks/) क्लिक क्रिया वाले कंटेनर लौटाता है।
- [get_hyperlink_mouse_overs](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_hyperlink_mouse_overs/) माउस‑ओवर क्रिया वाले कंटेनर लौटाता है।
- [get_any_hyperlinks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/) किसी भी या दोनों क्रिया वाले कंटेनर लौटाता है।

यह उदाहरण आकार और उसके टेक्स्ट पर क्लिक व माउस‑ओवर क्रियाएँ, तथा अलग बटन पर मैक्रो क्रिया असाइन करता है। यह [get_any_hyperlinks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/) द्वारा लौटाए गए कंटेनरों की तुलना प्रत्येक सक्रियता प्रकार की गिनती से करता है। टेक्स्ट‑फ़्रेम क्वेरी केवल टेक्स्ट में लिंक गिनती है। सम्मिलित आकार की अपनी क्रियाएँ स्लाइड और प्रस्तुति क्वेरी में दिखाई देती हैं।

```python
import aspose.slides as slides


def print_counts(scope, queries):
    click_containers = queries.get_hyperlink_clicks()
    mouse_over_containers = queries.get_hyperlink_mouse_overs()
    all_containers = queries.get_any_hyperlinks()
    print(f"{scope}: click={len(click_containers)}, mouse-over={len(mouse_over_containers)}, any={len(all_containers)}")


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    destination = presentation.slides.add_empty_slide(slide.layout_slide)
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 60)
    shape.text_frame.text = "Click the text to go to slide 2"
    shape.hyperlink_manager.set_external_hyperlink_click("https://example.com/")
    shape.hyperlink_click.tooltip = "Public website"
    shape.hyperlink_manager.set_external_hyperlink_mouse_over("file:///C:/private/report.xlsx")

    portion_format = shape.text_frame.paragraphs[0].portions[0].portion_format
    portion_format.hyperlink_manager.set_internal_hyperlink_click(destination)
    portion_format.hyperlink_manager.set_external_hyperlink_mouse_over("https://example.com/help")
    macro_button = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 120, 200, 60)
    macro_button.hyperlink_manager.set_macro_hyperlink_click("ReviewPresentation")

    print_counts("Presentation", presentation.hyperlink_queries)
    print_counts("Slide 1", slide.hyperlink_queries)
    print_counts("Text frame", shape.text_frame.hyperlink_queries)
    presentation.save("hyperlink-audit-input.pptx", slides.export.SaveFormat.PPTX)
```

इस उदाहरण में, प्रस्तुति और स्लाइड क्वेरी क्रमशः तीन क्लिक कंटेनर, दो माउस‑ओवर कंटेनर, और तीन कंटेनर (किसी भी क्रिया) रिपोर्ट करते हैं। टेक्स्ट‑फ़्रेम क्वेरी प्रत्येक वर्ग में एक कंटेनर रिपोर्ट करता है।

### **क्रियाओं और गंतव्यों को वर्गीकृत करें**

क्रिया को समझने से पहले उसका गंतव्य समझना आवश्यक है। [Hyperlink.action_type](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/action_type/) का उपयोग करके आप क्रिया की व्याख्या कर सकते हैं। [HyperlinkActionType](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkactiontype/) मान वेब नेविगेशन से अधिक कवर करते हैं:

| मान | ऑडिट के लिए अर्थ |
| --- | --- |
| `HYPERLINK` | बाहरी हाइपरलिंक; URL और उसके स्कीम की जाँच करें। |
| `JUMP_SPECIFIC_SLIDE` | किसी विशेष स्लाइड पर आंतरिक नेविगेशन। |
| `JUMP_FIRST_SLIDE`, `JUMP_PREVIOUS_SLIDE`, `JUMP_NEXT_SLIDE`, `JUMP_LAST_SLIDE`, `JUMP_LAST_VIEWED_SLIDE` | अंतर्निहित स्लाइड‑शो नेविगेशन, स्लाइड‑शो संदर्भ में हल किया जाता है। |
| `JUMP_END_SHOW`, `START_CUSTOM_SLIDE_SHOW` | वर्तमान शो समाप्त करें या एक कस्टम शो शुरू करें। |
| `START_MACRO` | मैक्रो निष्पादित करें। |
| `START_PROGRAM` | प्रोग्राम लॉन्च करें। |
| `OPEN_FILE`, `OPEN_PRESENTATION` | फ़ाइल या अन्य प्रस्तुति खोलें; वेब URL से अलग जाँचें। |
| `START_STOP_MEDIA` | मीडिया प्लेबैक शुरू या रोकें। |
| `NO_ACTION`, `UNKNOWN` | कोई नेविगेशन क्रिया नहीं, या अज्ञात क्रिया जिसे समीक्षा की आवश्यकता है। |

बाहरी गंतव्य को [external_url](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/external_url/) से पढ़ें और विशिष्ट आंतरिक गंतव्य को [target_slide](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/target_slide/) से। आंतरिक क्रियाओं और अंतर्निहित कमांड में बाहरी URL नहीं हो सकता; खाली URL का अर्थ यह नहीं है कि कंटेनर के पास कोई क्रिया नहीं है। जब [external_url_original](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/external_url_original/) सामान्यीकृत URL से भिन्न हो तो उसे संरक्षित रखें, और उपलब्ध होने पर [tooltip](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/tooltip/) को शामिल करें।

### **हाइपरलिंक को रिपोर्ट, सफ़ाई, और सत्यापित करें**

यह उदाहरण पिछले उदाहरण की प्रस्तुति को खोलता है और प्रत्येक क्रिया के लिए एक JSON रिकॉर्ड लिखता है। यह सामान्य स्लाइड, मास्टर, लेआउट और नोट्स, साथ ही नोट्स व हैंडआउट मास्टर (यदि मौजूद हों) पर कंटेनरों को इकट्ठा करने के लिए [get_any_hyperlinks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/) का उपयोग करता है। डुप्लिकेट प्रोसेसिंग से बचने के लिए प्रत्येक स्कोप को एक बार क्वेरी किया जाता है, नीचे वर्णित नीति लागू की जाती है, और सेव की गई प्रस्तुति को पुनः खोलकर क्लिक और माउस‑ओवर दोनों क्रियाओं की जाँच की जाती है।

रिपोर्ट एक‑आधारित स्लाइड इंडेक्स और उपलब्ध होने पर [slide_id](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/slide_id/) को रिकॉर्ड करती है। कलेक्टर प्रत्येक लौटाए गए कंटेनर के साथ स्वामित्व वाली स्लाइड और स्कोप को बरकरार रखता है। मास्टर, लेआउट और नोट्स के पास सामान्य स्लाइड इंडेक्स नहीं होता और उन्हें उनके स्कोप द्वारा पहचाना जाता है। आकार कंटेनर और टेक्स्ट‑भाग फॉर्मेट कंटेनर अलग‑अलग लेबल किए जाते हैं; अन्य कंटेनर प्रकार अपने रन‑टाइम टाइप नाम को बनाए रखते हैं। प्रत्येक कंटेनर को रिपोर्ट‑स्थानीय ID मिलती है ताकि उसकी दो क्रियाओं को मिलाया जा सके।

यह सख्त एप्लिकेशन नीति केवल निरपेक्ष HTTPS URL और वैध आंतरिक स्लाइड लक्ष्य की अनुमति देती है। यह मैक्रो, प्रोग्राम, फ़ाइल‑क्रियाएँ, अन्य स्लाइड‑शो क्रियाएँ, अज्ञात क्रियाएँ और अन्य URL स्कीम को अस्वीकार करती है। ये अस्वीकृति नीति निर्णय हैं, Aspose.Slides सुरक्षा निर्णय नहीं। केवल HTTPS भरोसे की गारंटी नहीं देता: अपने एप्लिकेशन के लिए होस्ट एलाउ‑लिस्ट और अतिरिक्त जाँच जोड़ें। मूल और सामान्यीकृत दोनों बाहरी URL की जाँच की जाती है। उदाहरण बिना लिंक को फ़ॉलो किए या कार्रवाई चलाए मेटा‑डेटा का ऑडिट करता है।

सुधार के लिए, कंटेनर का [hyperlink_manager](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlinkcontainer/hyperlink_manager/) [set_external_hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkmanager/set_external_hyperlink_click/), [remove_hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_click/), और [remove_hyperlink_mouse_over](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_mouse_over/) का समर्थन करता है। यहाँ, प्रतिबंधित बाहरी क्लिक लिंक को एक नियत HTTPS लैंडिंग पेज से बदला जाता है; अन्य प्रतिबंधित क्लिक और माउस‑ओवर कार्य स्वतंत्र रूप से हटाए जाते हैं। सभी नीति उल्लंघन को हटाने के लिए `replace_external_clicks` को `False` सेट करें। तैनाती से पहले एक एप्लिकेशन‑स्वामित्व वाला प्रतिस्थापन पेज चुनें।

रिपोर्ट का एक्सपोर्ट फ़्लैग एक रूढ़िवादी PDF रिव्यू नीति का उपयोग करता है: माउस‑ओवर क्रिया और कोई भी बाहरी लिंक या विशिष्ट स्लाइड जंप से अलग क्रिया संभावित रूप से असमर्थित चिह्नित की जाती है। यह एक रिव्यू संकेत है, न कि क्षमता परीक्षण या यह गारंटी कि बिना चिह्नित लिंक निर्यात में संरक्षित रहेंगे। समर्थित [PDF](/slides/hi/python-net/convert-powerpoint-to-pdf/) और [HTML](/slides/hi/python-net/convert-powerpoint-to-html/) निर्यात कार्य क्रिया, निर्यात विकल्प, और व्यूअर पर निर्भर करके हाइपरलिंक को संरक्षित कर सकते हैं। रास्टर [images](/slides/hi/python-net/convert-powerpoint-to-png/) और [video](/slides/hi/python-net/convert-powerpoint-to-video/) इंटरैक्टिव हाइपरलिंक नहीं रख सकते; उन आउटपुट के लिए ऑडिट करते समय हर क्रिया को चिह्नित करें।

```python
import json
import sys
from urllib.parse import urlsplit
import aspose.slides as slides


def is_https(value):
    if not value or any(character.isspace() for character in value):
        return False
    try:
        uri = urlsplit(value)
        return uri.scheme.lower() == "https" and bool(uri.hostname)
    except ValueError:
        return False


def policy_violation(link):
    if link is None:
        return None
    if link.action_type == slides.HyperlinkActionType.JUMP_SPECIFIC_SLIDE:
        return "Missing target slide" if link.target_slide is None else None
    if link.action_type != slides.HyperlinkActionType.HYPERLINK:
        return "Action is not allowed"
    if not is_https(link.external_url):
        return "Normalized URL is not absolute HTTPS"
    original = link.external_url_original
    if original and not is_https(original):
        return "Original URL is not absolute HTTPS"
    return None


def slide_index(presentation, slide):
    if slide is not None:
        for index, candidate in enumerate(presentation.slides, start=1):
            if candidate.slide_id == slide.slide_id:
                return index
    return None


def collect_containers(presentation):
    # प्रत्येक स्लाइड स्कोप को एक बार क्वेरी करें, प्रत्येक कंटेनर के साथ उसके मालिक को बनाए रखें।
    scopes = [("Slide", slide) for slide in presentation.slides]
    scopes.extend(("Master", master) for master in presentation.masters)
    scopes.extend(("Layout", layout) for layout in presentation.layout_slides)
    scopes.extend(("Notes", slide.notes_slide_manager.notes_slide) for slide in presentation.slides)
    scopes.append(("Notes master", presentation.master_notes_slide_manager.master_notes_slide))
    scopes.append(("Handout master", presentation.master_handout_slide_manager.master_handout_slide))
    found = []
    for scope, owner in scopes:
        if owner is not None:
            containers = list(owner.hyperlink_queries.get_any_hyperlinks())
            found.extend((container, scope, owner) for container in containers)
    return found


def add_row(rows, presentation, link, activation, container, container_id, scope, owner):
    if link is None:
        return
    target_slide = link.target_slide
    violation = policy_violation(link)
    if isinstance(container, slides.Shape):
        owner_type = "Shape"
    elif isinstance(container, slides.PortionFormat):
        owner_type = "Text portion"
    else:
        owner_type = type(container).__name__
    ordinary_action = link.action_type in (slides.HyperlinkActionType.HYPERLINK, slides.HyperlinkActionType.JUMP_SPECIFIC_SLIDE)
    original_url = link.external_url_original if link.external_url_original != link.external_url else None
    rows.append({
        "container_id": container_id,
        "slide_index": slide_index(presentation, owner) if scope == "Slide" else None,
        "slide_id": owner.slide_id,
        "scope": scope,
        "owner_type": owner_type,
        "activation": activation,
        "action_type": link.action_type.name,
        "external_url": link.external_url,
        "target_slide_index": slide_index(presentation, target_slide),
        "target_slide_id": target_slide.slide_id if target_slide is not None else None,
        "tooltip": link.tooltip,
        "original_external_url": original_url,
        "potentially_unsafe": violation is not None,
        "policy_violation": violation,
        "target_export": "PDF",
        "potentially_unsupported_by_export": activation == "mouse-over" or not ordinary_action,
    })


replace_external_clicks = True
replacement_url = "https://example.com/blocked-link"

with slides.Presentation("hyperlink-audit-input.pptx") as presentation:
    containers = collect_containers(presentation)
    rows = []
    for container_id, (container, scope, owner) in enumerate(containers, start=1):
        add_row(rows, presentation, container.hyperlink_click, "click", container, container_id, scope, owner)
        add_row(rows, presentation, container.hyperlink_mouse_over, "mouse-over", container, container_id, scope, owner)

    with open("hyperlink-audit.json", "w", encoding="utf-8") as report_file:
        json.dump(rows, report_file, indent=2)

    for container, scope, owner in containers:
        click = container.hyperlink_click
        if policy_violation(click) is not None:
            if replace_external_clicks and click.action_type == slides.HyperlinkActionType.HYPERLINK:
                container.hyperlink_manager.set_external_hyperlink_click(replacement_url)
            else:
                container.hyperlink_manager.remove_hyperlink_click()
        if policy_violation(container.hyperlink_mouse_over) is not None:
            container.hyperlink_manager.remove_hyperlink_mouse_over()

    presentation.save("hyperlink-sanitized.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("hyperlink-sanitized.pptx") as reopened:
    remaining_containers = collect_containers(reopened)
    violations = 0
    for container, scope, owner in remaining_containers:
        if policy_violation(container.hyperlink_click) is not None:
            violations += 1
        if policy_violation(container.hyperlink_mouse_over) is not None:
            violations += 1
    print(f"Audit rows: {len(rows)}; prohibited actions after reopening: {violations}")
    if violations != 0:
        print("Verification failed: do not distribute the saved presentation.")
        sys.exit(1)
```

ऊपर बनाए गए इनपुट के साथ, रिपोर्ट में पाँच क्रिया पंक्तियाँ होती हैं। फ़ाइल माउस‑ओवर लिंक और मैक्रो क्लिक हटाए जाते हैं, जबकि HTTPS लिंक और आंतरिक स्लाइड नेविगेशन बरकरार रहते हैं। सत्यापन शून्य प्रतिबंधित क्रिया प्रिंट करता है। एक प्रतिबंधित बाहरी क्लिक URL वाली इनपुट भी प्रतिस्थापन शाखा को प्रदर्शित करती है। एक कंटेनर जिसमें अनुमति प्राप्त क्लिक और प्रतिबंधित माउस‑ओवर है, वह अपना क्लिक कार्य रखता है।

यह चयनात्मक सफ़ाई [remove_all_hyperlinks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/remove_all_hyperlinks/) से अलग है, जो नीति की परवाह किए बिना चयनित स्कोप में दोनों सक्रियता प्रकारों को हटाता है। यहाँ सत्यापन केवल हाइपरलिंक क्रिया को जांचता है; यह एम्बेडेड VBA प्रोजेक्ट, OLE ऑब्जेक्ट या अन्य सक्रिय सामग्री को नहीं हटाता, और न ही निर्यातित PDF या HTML फ़ाइल की वैधता की पुष्टि करता है।

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं सेक्शन या उसकी पहली स्लाइड से कैसे लिंक करूँ?**

PowerPoint में सेक्शन स्लाइड को समूहित करते हैं, लेकिन आंतरिक हाइपरलिंक व्यक्तिगत स्लाइड को लक्षित करता है। सेक्शन पर नेविगेशन बनाने के लिए, उस सेक्शन की पहली स्लाइड से लिंक करें।

**क्या मैं मास्टर स्लाइड के तत्वों पर हाइपरलिंक जोड़ सकता हूँ ताकि वह सभी स्लाइडों पर काम करे?**

हां। मास्टर स्लाइड और लेआउट के तत्व हाइपरलिंक को सपोर्ट करते हैं। इन तत्वों पर लिंक स्लाइड शो के दौरान उन स्लाइडों पर उपलब्ध होते हैं जो संबंधित मास्टर या लेआउट का उपयोग करती हैं।

**क्या PDF, HTML, इमेज या वीडियो में निर्यात करने पर हाइपरलिंक संरक्षित रहेंगे?**

समर्थित PDF और HTML निर्यात हाइपरलिंक को संरक्षित कर सकते हैं; रास्टर इमेज और वीडियो इंटरैक्टिव हाइपरलिंक नहीं रख सकते। विवरण के लिए देखें [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks)।