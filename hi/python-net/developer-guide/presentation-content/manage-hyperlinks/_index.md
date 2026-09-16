---
title: Python में प्रस्तुति हाइपरलिंक प्रबंधित करें
linktitle: हाइपरलिंक प्रबंधित करें
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
- आकृति हाइपरलिंक
- छवि हाइपरलिंक
- वीडियो हाइपरलिंक
- परिवर्तनीय हाइपरलिंक
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Aspose.Slides
description: "PowerPoint और OpenDocument प्रस्तुतियों में Aspose.Slides for Python via .NET का उपयोग कर Python उदाहरणों के साथ हाइपरलिंक जोड़ें, स्वरूपित करें, अपडेट करें और हटाएं।"
---
## **परिचय**

एक हाइपरलिंक प्रस्तुति सामग्री को वेबसाइट या प्रस्तुति के भीतर किसी स्थान से जोड़ता है। PowerPoint में, हाइपरलिंक आमतौर पर दो उद्देश्यों के लिए उपयोग होते हैं:

* पाठ, आकृति, या मीडिया फ्रेम से वेबसाइट खोलना।
* सामग्री तालिका जैसी किसी अन्य स्लाइड पर नेविगेट करना।

Aspose.Slides for Python via .NET आपको ये लिंक जोड़ने, उनके स्वरूप और ध्वनि को नियंत्रित करने, उनके गुणों को अपडेट करने और हटाने की सुविधा देता है। नीचे दिए गए उदाहरण दिखाते हैं कैसे व्यक्तिगत तत्वों पर हाइपरलिंक के साथ काम करें और प्रस्तुति, स्लाइड या टेक्स्ट‑फ़्रेम स्तर पर हाइपरलिंक तक पहुँचें।

{{% alert color="info" title="नोट" %}}
आप प्रस्तुति को [मुक्त ऑनलाइन Aspose PowerPoint संपादक](https://products.aspose.app/slides/hi/editor) के साथ भी संपादित कर सकते हैं।
{{% /alert %}}

## **URL हाइपरलिंक जोड़ें**

आप पाठ, आकृति या मीडिया फ्रेम को वेबसाइट URL असाइन कर सकते हैं। जिस तत्व को आप हाइपरलिंक असाइन करते हैं, वह क्लिक करने योग्य क्षेत्र तय करता है: पाठ का हिस्सा चुने हुए पाठ को लिंक करता है, जबकि आकृति या फ्रेम स्लाइड ऑब्जेक्ट को लिंक करता है।

### **पाठ में URL हाइपरलिंक जोड़ें**

पाठ को वेबसाइट से लिंक करने के लिए, नीचे दिखाए अनुसार पाठ भाग की [hyperlink_click](https://reference.aspose.com/slides/hi/python-net/aspose.slides/portionformat/hyperlink_click/) प्रॉपर्टी में एक [Hyperlink](https://reference.aspose.com/slides/hi/python-net/aspose.slides/hyperlink/) असाइन करें। केवल वही पाठ भाग क्लिक करने योग्य बन जाएगा।

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

### **आकृतियों और मीडिया फ्रेम में URL हाइपरलिंक जोड़ें**

आकृति या फ्रेम को क्लिक करने योग्य बनाने के लिए, उसकी [hyperlink_click](https://reference.aspose.com/slides/hi/python-net/aspose.slides/shape/hyperlink_click/) प्रॉपर्टी सेट करें। हाइपरलिंक ऑब्जेक्ट स्वयं से जुड़ा होता है, न कि उसके भीतर के किसी पाठ भाग से।

इसी विधि को चित्र, ऑडियो और वीडियो फ्रेम पर भी लागू किया जा सकता है: फ्रेम को हाइपरलिंक असाइन करें और आवश्यक होने पर लिंक की [tooltip](https://reference.aspose.com/slides/hi/python-net/aspose.slides/hyperlink/tooltip/) सेट करें।

निम्न उदाहरण एक आयत को क्लिक करने योग्य बनाता है:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50)
    shape.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    shape.hyperlink_click.tooltip = "Explore Aspose file format APIs"
    presentation.save("presentation-out.pptx", slides.export.SaveFormat.PPTX)
```

## **सामग्री तालिका बनाने के लिए हाइपरलिंक का उपयोग करें**

आंतरिक हाइपरलिंक पाठकों को सामग्री तालिका से किसी विशिष्ट स्लाइड पर कूदने की अनुमति देते हैं। नीचे दिया गया उदाहरण [set_internal_hyperlink_click](https://reference.aspose.com/slides/hi/python-net/aspose.slides/hyperlinkmanager/set_internal_hyperlink_click/) का उपयोग करके पहली स्लाइड पर “Page 2” पाठ को दूसरी स्लाइड से जोड़ता है।

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

## **हाइपरलिंक स्वरूपित करें**

### **रंग**

[Hyperlink](https://reference.aspose.com/slides/hi/python-net/aspose.slides/hyperlink/) की [color_source](https://reference.aspose.com/slides/hi/python-net/aspose.slides/hyperlink/color_source/) प्रॉपर्टी निर्धारित करती है कि हाइपरलिंक प्रस्तुति के हाइपरलिंक रंग का उपयोग करे या पाठ भाग के स्वरूपित रंग का। कस्टम पाठ रंग लागू करने के लिए, [HyperlinkColorSource.PORTION_FORMAT](https://reference.aspose.com/slides/hi/python-net/aspose.slides/hyperlinkcolorsource/) चुनें और भाग का भराव रंग सेट करें। यह सुविधा PowerPoint 2019 में प्रस्तुत की गई थी; पुराने संस्करण इस सेटिंग को लागू नहीं करते।

निम्न उदाहरण दो पाठ हाइपरलिंक को एक ही स्लाइड में जोड़ता है। पहला लाल पाठ भराव के साथ है, जबकि दूसरा डिफ़ॉल्ट हाइपरलिंक रंग रखता है।

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

हाइपरलिंक सक्रिय होने पर ध्वनि बजा सकता है या पहले से चल रही ध्वनि को रोक सकता है। इन व्यवहारों को कॉन्फ़िगर करने के लिए निम्न प्रॉपर्टी का उपयोग करें:

- [Hyperlink.sound](https://reference.aspose.com/slides/hi/python-net/aspose.slides/hyperlink/sound/) हाइपरलिंक से जुड़ी ऑडियो को निर्दिष्ट करती है।
- [Hyperlink.stop_sound_on_click](https://reference.aspose.com/slides/hi/python-net/aspose.slides/hyperlink/stop_sound_on_click/) नियंत्रित करती है कि हाइपरलिंक सक्रिय होने पर पूर्व ध्वनि रुक जाए या नहीं।

#### **हाइपरलिंक ध्वनि जोड़ें**

निम्न उदाहरण `sampleaudio.wav` लोड करता है और पहली स्लाइड पर एक बटन से जोड़ता है। बटन पर क्लिक करने से ध्वनि बजती है और अगली स्लाइड पर जाता है। उसी स्लाइड पर एक दूसरा आकार क्लिक होने पर पूर्व ध्वनि को रोकता है, बिना नेविगेशन किए।

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

निम्न उदाहरण ऊपर बनाए गए प्रस्तुति को खोलता है और पहले आकार की हाइपरलिंक ऑडियो को [sound](https://reference.aspose.com/slides/hi/python-net/aspose.slides/hyperlink/sound/) तथा [binary_data](https://reference.aspose.com/slides/hi/python-net/aspose.slides/audio/binary_data/) के माध्यम से मेमोरी में पढ़ता है।

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

### **टूलटिप और इंटरैक्शन सेटिंग्स**

आप पाठ या आकृति को हाइपरलिंक असाइन करने के बाद निम्न [Hyperlink](https://reference.aspose.com/slides/hi/python-net/aspose.slides/hyperlink/) प्रॉपर्टी को अपडेट कर सकते हैं:

- [tooltip](https://reference.aspose.com/slides/hi/python-net/aspose.slides/hyperlink/tooltip/) लिंक के लिए संकेत के रूप में दर्शक को दिखाने वाला पाठ सेट करता है।
- [target_frame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/hyperlink/target_frame/) लागू होने पर पैरेंट HTML फ्रेमसेट के भीतर लक्ष्य फ्रेम निर्दिष्ट करता है।
- [history](https://reference.aspose.com/slides/hi/python-net/aspose.slides/hyperlink/history/) नियंत्रित करता है कि लिंक सक्रिय होने पर उसका गंतव्य देखे गए हाइपरलिंक सूची में जोड़ा जाए या नहीं।
- [highlight_click](https://reference.aspose.com/slides/hi/python-net/aspose.slides/hyperlink/highlight_click/) नियंत्रित करता है कि क्लिक करने पर हाइपरलिंक हाइलाइट हो या नहीं।

## **हाइपरलिंक हटाएँ**

हाइपरलिंक कंटेनर (जिसमें पाठ‑भाग लिंक भी शामिल हैं) को बदलने से पहले इकट्ठा करने के लिए [get_any_hyperlinks](https://reference.aspose.com/slides/hi/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/) का उपयोग करें। नीचे दिया गया उदाहरण पहली स्लाइड से दोनों सक्रियता प्रकारों को हटाता है। केवल एक प्रकार हटाने के लिए, केवल [remove_hyperlink_click](https://reference.aspose.com/slides/hi/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_click/) या केवल [remove_hyperlink_mouse_over](https://reference.aspose.com/slides/hi/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_mouse_over/) कॉल करें; क्लिक कार्रवाई हटाने से उसका माउस‑ओवर विरुद्ध नहीं हटता।

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

अशर्त हटाने के लिए, [remove_all_hyperlinks](https://reference.aspose.com/slides/hi/python-net/aspose.slides/hyperlinkqueries/remove_all_hyperlinks/) चयनित स्कोप में दोनों सक्रियता प्रकारों को एक ही कॉल में हटाता है। चयनात्मक सफाई और मास्टर, लेआउट, तथा नोट्स तक कवरेज के लिए देखें [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks)।

## **हाइपरलिंक इन्वेंट्री बनाना**

प्रस्तुति वितरित करने से पहले, उसकी इंटरैक्टिव क्रियाएँ और वेब लिंक सूचीबद्ध करें। [get_any_hyperlinks](https://reference.aspose.com/slides/hi/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/) [IHyperlinkContainer](https://reference.aspose.com/slides/hi/python-net/aspose.slides/ihyperlinkcontainer/) ऑब्जेक्ट लौटाता है, न कि URL स्ट्रिंग की सरल सूची। प्रत्येक कंटेनर पर दोनों [hyperlink_click](https://reference.aspose.com/slides/hi/python-net/aspose.slides/ihyperlinkcontainer/hyperlink_click/) और [hyperlink_mouse_over](https://reference.aspose.com/slides/hi/python-net/aspose.slides/ihyperlinkcontainer/hyperlink_mouse_over/) जाँचें। ये स्वतंत्र होते हैं: एक ही कंटेनर दोनों कार्यों को प्रकट कर सकता है, इसलिए पूर्ण रिपोर्ट में प्रत्येक कंटेनर के लिए दो पंक्तियाँ हो सकती हैं।

केवल आकृति‑स्तर के हाइपरलिंक स्कैन करने से पाठ‑भाग में लगे लिंक छूट सकते हैं। उचित स्कोप को क्वेरी करें और लौटाए गए कंटेनर को रखें ताकि बाद में उनके कार्यों को अपडेट या हटाया जा सके।

### **प्रेजेंटेशन, स्लाइड, और टेक्स्ट‑फ़्रेम स्कोप क्वेरी करें**

[HyperlinkQueries](https://reference.aspose.com/slides/hi/python-net/aspose.slides/hyperlinkqueries/) क्लास उपलब्ध है [Presentation.hyperlink_queries](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/hyperlink_queries/), [BaseSlide.hyperlink_queries](https://reference.aspose.com/slides/hi/python-net/aspose.slides/baseslide/hyperlink_queries/), और [TextFrame.hyperlink_queries](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframe/hyperlink_queries/) के माध्यम से। प्रत्येक स्कोप समान क्वेरी का समर्थन करता है:

- [get_hyperlink_clicks](https://reference.aspose.com/slides/hi/python-net/aspose.slides/hyperlinkqueries/get_hyperlink_clicks/) क्लिक कार्य वाले कंटेनर लौटाता है।
- [get_hyperlink_mouse_overs](https://reference.aspose.com/slides/hi/python-net/aspose.slides/hyperlinkqueries/get_hyperlink_mouse_overs/) माउस‑ओवर कार्य वाले कंटेनर लौटाता है।
- [get_any_hyperlinks](https://reference.aspose.com/slides/hi/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/) किसी भी या दोनों कार्य वाले कंटेनर लौटाता है।

निम्न उदाहरण `hyperlink-audit-input.pptx` बनाता है जिसमें एक बाहरी क्लिक लिंक, एक फ़ाइल माउस‑ओवर लिंक, आंतरिक स्लाइड नेविगेशन, एक पाठ माउस‑ओवर लिंक और एक मैक्रो क्रिया शामिल है। यह इन कार्यों को निष्पादित नहीं करता। तीनों क्वेरी हर स्कोप पर समान रूप से काम करती हैं; काउंट कंटेनर की संख्या दर्शाते हैं, न कि कार्यों की कुल संख्या। टेक्स्ट‑फ़्रेम स्कोप अपने संलग्न आकृति के लिंक को बाहर रखता है।

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

इस उदाहरण में, प्रस्तुति और स्लाइड क्वेरी प्रत्येक तीन क्लिक कंटेनर, दो माउस‑ओवर कंटेनर, और तीन मिश्रित कंटेनर रिपोर्ट करती हैं। टेक्स्ट‑फ़्रेम क्वेरी प्रत्येक श्रेणी में एक कंटेनर दिखाती है।

### **कार्य और गंतव्य वर्गीकृत करें**

[Hyperlink.action_type](https://reference.aspose.com/slides/hi/python-net/aspose.slides/hyperlink/action_type/) का उपयोग करके कार्रवाई को उसकी गंतव्य को समझने से पहले व्याख्या करें। [HyperlinkActionType](https://reference.aspose.com/slides/hi/python-net/aspose.slides/hyperlinkactiontype/) के मान वेब नेविगेशन से अधिक कवर करते हैं:

| मान | ऑडिट के लिए अर्थ |
| --- | --- |
| `HYPERLINK` | बाहरी हाइपरलिंक; URL और उसका प्रोटोकॉल देखें। |
| `JUMP_SPECIFIC_SLIDE` | विशिष्ट स्लाइड पर आंतरिक नेविगेशन। |
| `JUMP_FIRST_SLIDE`, `JUMP_PREVIOUS_SLIDE`, `JUMP_NEXT_SLIDE`, `JUMP_LAST_SLIDE`, `JUMP_LAST_VIEWED_SLIDE` | स्लाइडशो में निर्मित नेविगेशन, स्लाइडशो संदर्भ में हल होता है। |
| `JUMP_END_SHOW`, `START_CUSTOM_SLIDE_SHOW` | वर्तमान शो को समाप्त या कस्टम शो शुरू करें। |
| `START_MACRO` | मैक्रो निष्पादित करें। |
| `START_PROGRAM` | प्रोग्राम लॉन्च करें। |
| `OPEN_FILE`, `OPEN_PRESENTATION` | फ़ाइल या अन्य प्रस्तुति खोलें; वेब URL से अलग जाँचें। |
| `START_STOP_MEDIA` | मीडिया प्लेबैक शुरू या रोकें। |
| `NO_ACTION`, `UNKNOWN` | कोई नेविगेशन नहीं, या अनपहचाना कार्य जिसके लिए पुनः जाँच आवश्यक है। |

बाहरी गंतव्य [external_url](https://reference.aspose.com/slides/hi/python-net/aspose.slides/hyperlink/external_url/) से पढ़ें और विशिष्ट आंतरिक गंतव्य [target_slide](https://reference.aspose.com/slides/hi/python-net/aspose.slides/hyperlink/target_slide/) से। आंतरिक कार्य और निर्मित कमांड में बाहरी URL नहीं हो सकता; खाली URL का अर्थ कंटेनर के पास कोई कार्य नहीं है नहीं। जब [external_url_original](https://reference.aspose.com/slides/hi/python-net/aspose.slides/hyperlink/external_url_original/) सामान्यीकृत URL से अलग हो तो उसे संरक्षित रखें, और उपलब्ध होने पर [tooltip](https://reference.aspose.com/slides/hi/python-net/aspose.slides/hyperlink/tooltip/) शामिल करें।

### **हाइपरलिंक रिपोर्ट, सैनिटाइज़ और सत्यापित करें**

निम्न Python उदाहरण मौजूदा प्रस्तुति (ऊपर निर्मित फ़ाइल) पढ़ता है, `hyperlink-audit.json` लिखता है, एक नीति लागू करता है, `hyperlink-sanitized.pptx` सहेजता है, और फिर दोनों सक्रियता प्रकारों को फिर से जाँचता है। यह बदलने से पहले कंटेनर एकत्र करता है और प्रत्येक स्लाइड स्कोप को एक बार क्वेरी करता है ताकि दोहराव से बचा जा सके। प्रस्तुति क्वेरी सामान्य स्लाइड को कवर करती है; पैकेज‑व्यापी इन्वेंट्री के लिए, उदाहरण सामान्य स्लाइड, मास्टर, लेआउट, नोट्स और मौजूद होने पर नोट्स एवं हैंडआउट मास्टर को भी क्वेरी करता है।

रिपोर्ट में एक‑आधारित स्लाइड इंडेक्स और उपलब्ध होने पर [slide_id](https://reference.aspose.com/slides/hi/python-net/aspose.slides/baseslide/slide_id/) रिकॉर्ड होता है। कलेक्टर प्रत्येक लौटाए गए कंटेनर के साथ उसे धारण करने वाली स्लाइड और स्कोप रखता है। मास्टर, लेआउट और नोट्स में सामान्य स्लाइड इंडेक्स नहीं होते और उनका पहचान स्कोप से होती है। आकार कंटेनर और पाठ‑भाग स्वरूप कंटेनर अलग‑अलग लेबल किए जाते हैं; अन्य कंटेनर प्रकार अपना रन‑टाइम टाइप नाम रखते हैं। प्रत्येक कंटेनर को रिपोर्ट‑स्थानीय ID दी जाती है ताकि उसके दो कार्यों को आपस में जोड़ा जा सके।

यह सख्त अनुप्रयोग नीति केवल पूर्ण HTTPS URL और मान्य आंतरिक स्लाइड लक्ष्य की अनुमति देती है। यह मैक्रो, प्रोग्राम, फ़ाइल कार्रवाई, अन्य स्लाइडशो कार्रवाई, अज्ञात कार्रवाई, तथा अन्य URL स्कीम को अस्वीकार करती है। ये अस्वीकृतियाँ नीति निर्णय हैं, न कि Aspose.Slides की सुरक्षा राय। केवल HTTPS भरोसेमंद नहीं है: अपने अनुप्रयोग के लिए होस्ट एॅलो‑लिस्ट और अन्य जाँच जोड़ें। मूल और सामान्यीकृत दोनों बाहरी URL जाँचे जाते हैं। उदाहरण लिंक फ़ॉलो किए बिना या कार्य चलाए बिना मेटाडेटा का ऑडिट करता है।

सुधार के लिए, कंटेनर का [hyperlink_manager](https://reference.aspose.com/slides/hi/python-net/aspose.slides/ihyperlinkcontainer/hyperlink_manager/) [set_external_hyperlink_click](https://reference.aspose.com/slides/hi/python-net/aspose.slides/hyperlinkmanager/set_external_hyperlink_click/), [remove_hyperlink_click](https://reference.aspose.com/slides/hi/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_click/), और [remove_hyperlink_mouse_over](https://reference.aspose.com/slides/hi/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_mouse_over/) को सपोर्ट करता है। यहाँ प्रतिबंधित बाहरी क्लिक लिंक को एक निश्चित HTTPS लैंडिंग पेज से बदल दिया गया है; अन्य प्रतिबंधित क्लिक और प्रतिबंधित माउस‑ओवर कार्य स्वतंत्र रूप से हटाए जाते हैं। सभी नीति उल्लंघन हटाने के लिए `replace_external_clicks` को `False` रखें। तैनाती से पहले अनुप्रयोग‑स्वामित्व वाला प्रतिस्थापन पेज चुनें।

रिपोर्ट के एक्सपोर्ट फ़्लैग में एक रूढ़िवादी PDF रिव्यू नीति उपयोग की गई है: माउस‑ओवर कार्य और बाहरी लिंक या विशिष्ट स्लाइड जंप के अलावा अन्य सभी को संभावित असमर्थित के रूप में चिह्नित किया गया है। यह समीक्षा संकेत है, न कि क्षमता परीक्षण या यह गारंटी कि बिना चिह्नित लिंक एक्सपोर्ट में सुरक्षित रहेंगे। समर्थित [PDF](/slides/hi/python-net/convert-powerpoint-to-pdf/) और [HTML](/slides/hi/python-net/convert-powerpoint-to-html/) निर्यात कुछ कार्यों, एक्सपोर्ट विकल्प और व्यूअर पर निर्भर करके हाइपरलिंक बनाए रख सकते हैं। रास्टर [छवियाँ](/slides/hi/python-net/convert-powerpoint-to-png/) और [वीडियो](/slides/hi/python-net/convert-powerpoint-to-video/) इंटरैक्टिव हाइपरलिंक नहीं रख सकते; उन आउटपुट की ऑडिट के दौरान प्रत्येक कार्य को चिह्नित करें।

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
    # प्रत्येक स्लाइड स्कोप को एक बार क्वेरी करें, प्रत्येक कंटेनर के साथ उसका मालिक रखकर।
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

ऊपर निर्मित इनपुट से, रिपोर्ट में पाँच कार्य पंक्तियाँ होती हैं। फ़ाइल माउस‑ओवर लिंक और मैक्रो क्लिक हटाए गए, जबकि HTTPS लिंक और आंतरिक स्लाइड नेविगेशन बना रहा। सत्यापन शून्य प्रतिबंधित कार्य प्रदर्शित करता है। एक प्रतिबंधित बाहरी क्लिक URL वाली इनपुट भी प्रतिस्थापन शाखा को सक्रिय करती है। एक अनुमत क्लिक और प्रतिबंधित माउस‑ओवर वाला कंटेनर अपनी क्लिक कार्रवाई बरकरार रखता है।

यह चयनात्मक सफाई [remove_all_hyperlinks](https://reference.aspose.com/slides/hi/python-net/aspose.slides/hyperlinkqueries/remove_all_hyperlinks/) से अलग है, जो नीति की परवाह किए बिना चयनित स्कोप में दोनों सक्रियता प्रकारों को हटाता है। यहाँ सत्यापन केवल हाइपरलिंक कार्यों को जांचता है; यह एंबेडेड VBA प्रोजेक्ट, OLE ऑब्जेक्ट या अन्य सक्रिय सामग्री को नहीं हटाता, न ही निर्यातित PDF या HTML फ़ाइल की वैधता जाँचता है।

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं सेक्शन या उसकी पहली स्लाइड से कैसे लिंक करूँ?**

PowerPoint में सेक्शन स्लाइडों को समूहित करते हैं, परन्तु आंतरिक हाइपरलिंक व्यक्तिगत स्लाइड को लक्षित करता है। सेक्शन पर नेविगेशन बनाने के लिए उस सेक्शन की पहली स्लाइड से लिंक करें।

**क्या मैं मास्टर स्लाइड तत्वों पर हाइपरलिंक लगा सकता हूँ ताकि यह सभी स्लाइडों पर काम करे?**

हां। मास्टर स्लाइड और लेआउट तत्व हाइपरलिंक का समर्थन करते हैं। इन तत्वों पर लगे लिंक स्लाइड शो के दौरान उन स्लाइडों पर उपलब्ध होते हैं जो संबंधित मास्टर या लेआउट का उपयोग करती हैं।

**क्या हाइपरलिंक PDF, HTML, छवियों या वीडियो में निर्यात करने पर बने रहेंगे?**

समर्थित PDF और HTML निर्यात कुछ परिस्थितियों में हाइपरलिंक को संरक्षित कर सकते हैं; रास्टर छवियां और वीडियो इंटरैक्टिव हाइपरलिंक नहीं रख सकते। विवरण के लिए देखें [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks)।