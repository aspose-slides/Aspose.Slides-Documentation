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
- टेक्स्ट हाइपरलिंक
- स्लाइड हाइपरलिंक
- आकार हाइपरलिंक
- छवि हाइपरलिंक
- वीडियो हाइपरलिंक
- परिवर्तनशील हाइपरलिंक
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET का उपयोग करके, Python उदाहरणों के साथ PowerPoint और OpenDocument प्रस्तुतियों में हाइपरलिंक जोड़ें, स्वरूपित करें, अपडेट करें और हटाएं।"
---
## **परिचय**

एक हाइपरलिंक प्रस्तुति सामग्री को वेबसाइट या प्रस्तुति के भीतर किसी स्थान से जोड़ता है। PowerPoint में, हाइपरलिंक्स आमतौर पर दो उद्देश्यों के लिए उपयोग होते हैं:

* पाठ, आकार या मीडिया फ्रेम से वेबसाइट खोलें।
* उदाहरण के लिए, अनुक्रमणिका से किसी अन्य स्लाइड पर जाएँ।

Aspose.Slides for Python via .NET आपको ये लिंक जोड़ने, उनकी उपस्थिति और ध्वनि को नियंत्रित करने, उनकी गुणों को अपडेट करने और उन्हें हटाने की सुविधा देता है। नीचे दिए गए उदाहरण दिखाते हैं कि व्यक्तिगत तत्वों पर हाइपरलिंक्स के साथ कैसे कार्य करें और प्रस्तुति, स्लाइड या टेक्स्ट-फ़्रेम स्तर पर हाइपरलिंक्स को कैसे एक्सेस करें।

{{% alert color="info" title="Note" %}}
आप प्रस्तुतियों को [नि:शुल्क ऑनलाइन Aspose PowerPoint संपादक](https://products.aspose.app/slides/editor) से भी संपादित कर सकते हैं।
{{% /alert %}}

## **URL हाइपरलिंक्स जोड़ें**

आप एक वेबसाइट URL को पाठ, आकार या मीडिया फ़्रेम को असाइन कर सकते हैं। जिस तत्व पर आप हाइपरलिंक असाइन करते हैं, वह क्लिक करने योग्य क्षेत्र निर्धारित करता है: पाठ का भाग चयनित पाठ को लिंक करता है, जबकि आकार या फ़्रेम स्लाइड ऑब्जेक्ट को लिंक करता है।

परिच Relative हाइपरलिंक्स वाली प्रस्तुतियों के लिए, [हाइपरलिंक बेस प्रबंधित करें](/slides/hi/python-net/presentation-properties/#manage-the-hyperlink-base) देखें ताकि दस्तावेज़-स्तर बेस को पढ़ा, बदला या साफ़ किया जा सके।

### **टेक्स्ट में URL हाइपरलिंक्स जोड़ें**

टेक्स्ट को वेबसाइट से लिंक करने के लिए, नीचे दिखाए अनुसार टेक्स्ट भाग की [hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/hyperlink_click/) प्रॉपर्टी को एक [Hyperlink](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/) असाइन करें। केवल वह टेक्स्ट भाग क्लिक करने योग्य बन जाता है।

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

### **आकार और मीडिया फ्रेम में URL हाइपरलिंक्स जोड़ें**

एक आकार या फ्रेम को क्लिक करने योग्य बनाने के लिए, उसकी [hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/shape/hyperlink_click/) प्रॉपर्टी सेट करें। हाइपरलिंक ऑब्जेक्ट स्वयं से जुड़ा होता है, न कि उसके भीतर किसी पाठ भाग से।

इसी दृष्टिकोण को चित्र, ऑडियो और वीडियो फ्रेम पर भी लागू किया जा सकता है: फ्रेम को हाइपरलिंक असाइन करें और यदि आवश्यक हो तो लिंक के [tooltip](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/tooltip/) को सेट करें।

निम्न उदाहरण एक आयत को क्लिक करने योग्य बनाता है:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50)
    shape.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    shape.hyperlink_click.tooltip = "Explore Aspose file format APIs"
    presentation.save("presentation-out.pptx", slides.export.SaveFormat.PPTX)
```

## **हाइपरलिंक्स का उपयोग करके अनुक्रमणिका बनाएं**

आंतरिक हाइपरलिंक्स पाठकों को अनुक्रमणिका से एक विशिष्ट स्लाइड पर कूदने की अनुमति देते हैं। निम्न उदाहरण [set_internal_hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkmanager/set_internal_hyperlink_click/) का उपयोग करके पहले स्लाइड पर “Page 2” टेक्स्ट को दूसरी स्लाइड से लिंक करता है।

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

## **हाइपरलिंक्स को फ़ॉर्मेट करें**

### **रंग**

[Hyperlink](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/) का [color_source](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/color_source/) निर्धारित करता है कि हाइपरलिंक प्रस्तुति के हाइपरलिंक रंग का उपयोग करता है या पाठ भाग के फ़ॉर्मेट का। एक कस्टम टेक्स्ट रंग लागू करने के लिए, [HyperlinkColorSource.PORTION_FORMAT](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkcolorsource/) चुनें और भाग की भराव रंग सेट करें। यह सुविधा PowerPoint 2019 में पेश की गई थी; पुराने संस्करण इस सेटिंग को लागू नहीं करते।

निम्न उदाहरण एक ही स्लाइड पर दो टेक्स्ट हाइपरलिंक्स जोड़ता है। पहला लाल टेक्स्ट भराव का उपयोग करता है, जबकि दूसरा डिफ़ॉल्ट हाइपरलिंक रंग बनाए रखता है।

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

एक हाइपरलिंक सक्रिय होने पर ध्वनि चलाई जा सकती है या पहले से चल रही ध्वनि को रोक सकती है। इन व्यवहारों को कॉन्फ़िगर करने के लिए नीचे दी गई प्रॉपर्टीज़ का उपयोग करें:

- [Hyperlink.sound](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/sound/) हाइपरलिंक से जुड़ी ऑडियो को निर्दिष्ट करता है।
- [Hyperlink.stop_sound_on_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/stop_sound_on_click/) सक्रिय करने पर पिछली ध्वनि को रोकना नियंत्रित करता है।

#### **हाइपरलिंक ध्वनि जोड़ें**

निम्न उदाहरण `sampleaudio.wav` लोड करता है और इसे पहले स्लाइड पर एक बटन से जोड़ता है। बटन पर क्लिक करने से ध्वनि चलती है और अगली स्लाइड पर नेविगेट होता है। उसी स्लाइड पर दूसरा आकार क्लिक करने पर पिछली ध्वनि को रोकता है, बिना किसी नेविगेशन कार्रवाई के।

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

निम्न उदाहरण ऊपर बनाई गई प्रस्तुति को खोलता है और पहले आकार की हाइपरलिंक ऑडियो को [sound](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/sound/) और [binary_data](https://reference.aspose.com/slides/python-net/aspose.slides/audio/binary_data/) के माध्यम से मेमोरी में पढ़ता है।

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

पाठ या आकार पर हाइपरलिंक असाइन करने के बाद आप नीचे दी गई [Hyperlink](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/) प्रॉपर्टीज़ को अपडेट कर सकते हैं:

- [tooltip](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/tooltip/) दर्शक को लिंक के लिए संकेत के रूप में दिखाने योग्य टेक्स्ट सेट करता है।
- [target_frame](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/target_frame/) यदि लागू हो, तो पैरेंट HTML फ्रेमसेट के भीतर लक्ष्य फ्रेम को निर्दिष्ट करता है।
- [history](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/history/) सक्रिय करने पर लिंक को देखे गए हाइपरलिंक्स की सूची में जोड़ता है या नहीं, नियंत्रित करता है।
- [highlight_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/highlight_click/) क्लिक करने पर हाइपरलिंक को हाइलाइट किया जाए या नहीं, नियंत्रित करता है।

## **प्रस्तुतियों से हाइपरलिंक्स हटाएं**

परिवर्तन करने से पहले सभी हाइपरलिंक कंटेनरों को एकत्र करने के लिए [get_any_hyperlinks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/) का उपयोग करें, जिसमें टेक्स्ट-भाग लिंक भी शामिल हैं। नीचे दिया गया उदाहरण पहले स्लाइड से दोनों सक्रियता प्रकार हटाता है। केवल एक प्रकार हटाने के लिए, केवल [remove_hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_click/) या [remove_hyperlink_mouse_over](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_mouse_over/) को कॉल करें; क्लिक कार्रवाई हटाने से उसकी माउस‑ओवर समकक्ष नहीं हटती।

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

निर्बंधन रहित हटाने के लिए, [remove_all_hyperlinks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/remove_all_hyperlinks/) चयनित स्कोप में दोनों सक्रियता प्रकारों को एक ही कॉल में हटाता है। चयनात्मक सफाई और मास्टर, लेआउट, नोट्स के कवरेज के लिए देखें [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks)।

## **हाइपरलिंक इन्वेंट्री बनाएं**

प्रेजेंटेशन वितरित करने से पहले, उसकी इंटरैक्टिव कार्रवाइयों और वेब लिंक दोनों की इन्वेंट्री बनाएं। [get_any_hyperlinks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/) [IHyperlinkContainer](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlinkcontainer/) ऑब्जेक्ट्स लौटाता है, न कि URL स्ट्रिंग की फ्लैट सूची। प्रत्येक कंटेनर पर [hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlinkcontainer/hyperlink_click/) और [hyperlink_mouse_over](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlinkcontainer/hyperlink_mouse_over/) दोनों को जाँचें। वे स्वतंत्र होते हैं: एक ही कंटेनर दोनों कार्रवाइयों को उजागर कर सकता है, इसलिए पूर्ण रिपोर्ट के लिए प्रत्येक कंटेनर के लिए दो पंक्तियाँ आवश्यक हो सकती हैं।

केवल आकार‑स्तर के हाइपरलिंक्स को स्कैन करने से टेक्स्ट भागों से जुड़े लिंक छूट सकते हैं। उचित स्कोप को क्वेरी करें, और लौटाए गए कंटेनरों को रख‑रखाव के लिए रखें ताकि बाद में उनकी कार्रवाइयों को अपडेट या हटाया जा सके।

### **प्रेजेंटेशन, स्लाइड और टेक्स्ट-फ़्रेम स्कोप्स क्वेरी करें**

[HyperlinkQueries](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/) क्लास [Presentation.hyperlink_queries](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/hyperlink_queries/), [BaseSlide.hyperlink_queries](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/hyperlink_queries/) और [TextFrame.hyperlink_queries](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/hyperlink_queries/) के माध्यम से उपलब्ध है। प्रत्येक स्कोप समान क्वेरीज़ को सपोर्ट करता है:

- [get_hyperlink_clicks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_hyperlink_clicks/) क्लिक कार्रवाई वाले कंटेनर लौटाता है।
- [get_hyperlink_mouse_overs](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_hyperlink_mouse_overs/) माउस‑ओवर कार्रवाई वाले कंटेनर लौटाता है।
- [get_any_hyperlinks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/) किसी भी या दोनों कार्रवाइयों वाले कंटेनर लौटाता है।

निम्न उदाहरण `hyperlink-audit-input.pptx` बनाता है जिसमें एक बाहरी क्लिक लिंक, एक फ़ाइल माउस‑ओवर लिंक, आंतरिक स्लाइड नेविगेशन, एक टेक्स्ट माउस‑ओवर लिंक और एक मैक्रो कार्रवाई शामिल है। यह इन कार्रवाइयों को निष्पादित नहीं करता। वही तीन क्वेरीज़ हर स्कोप पर काम करती हैं; गिनती कंटेनरों को दर्शाती है, कुल कार्रवाइयों को नहीं। टेक्स्ट‑फ़्रेम स्कोप enclosing आकार के स्वयं के लिंक को बाहर रखता है।

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

इस उदाहरण में, प्रेजेंटेशन और स्लाइड क्वेरीज़ प्रत्येक तीन क्लिक कंटेनर, दो माउस‑ओवर कंटेनर और तीन कंटेनर (जो या तो या दोनों कार्रवाइयाँ रखते हैं) रिपोर्ट करती हैं। टेक्स्ट‑फ़्रेम क्वेरी प्रत्येक श्रेणी में एक कंटेनर रिपोर्ट करती है।

### **क्रियाएँ और गंतव्य वर्गीकृत करें**

क्रिया को उसके गंतव्य की व्याख्या करने से पहले समझने के लिए [Hyperlink.action_type](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/action_type/) का उपयोग करें। [HyperlinkActionType](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkactiontype/) मान वेब नेविगेशन से परे कई चीज़ें कवर करते हैं:

| मान | ऑडिट के अर्थ |
| --- | --- |
| `HYPERLINK` | बाहरी हाइपरलिंक; URL और उसके स्कीम की जांच करें। |
| `JUMP_SPECIFIC_SLIDE` | एक विशिष्ट स्लाइड पर आंतरिक नेविगेशन। |
| `JUMP_FIRST_SLIDE`, `JUMP_PREVIOUS_SLIDE`, `JUMP_NEXT_SLIDE`, `JUMP_LAST_SLIDE`, `JUMP_LAST_VIEWED_SLIDE` | बिल्ट‑इन स्लाइडशो नेविगेशन, स्लाइडशो संदर्भ में हल किया जाता है। |
| `JUMP_END_SHOW`, `START_CUSTOM_SLIDE_SHOW` | वर्तमान शो को समाप्त करे या कस्टम शो शुरू करे। |
| `START_MACRO` | मैक्रो चलाएँ। |
| `START_PROGRAM` | प्रोग्राम प्रारंभ करें। |
| `OPEN_FILE`, `OPEN_PRESENTATION` | फ़ाइल या दूसरा प्रेज़ेंटेशन खोलें; वेब URL से अलग समीक्षा करें। |
| `START_STOP_MEDIA` | मीडिया प्लेबैक शुरू या रोकें। |
| `NO_ACTION`, `UNKNOWN` | कोई नेविगेशन कार्रवाई नहीं, या अप्रचलित कार्रवाई जो समीक्षा आवश्यक है। |

बाहरी गंतव्य को [external_url](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/external_url/) से और विशिष्ट आंतरिक गंतव्य को [target_slide](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/target_slide/) से पढ़ें। आंतरिक कार्रवाइयों और बिल्ट‑इन कमांड्स में बाहरी URL नहीं हो सकता; खाली URL का मतलब यह नहीं कि कंटेनर में कोई कार्रवाई नहीं है। जब normalized URL से अलग हो तो [external_url_original](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/external_url_original/) को संरक्षित रखें, और उपलब्ध होने पर [tooltip](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/tooltip/) को शामिल करें।

### **हाइपरलिंक्स की रिपोर्ट, सैनिटाइज़ और वेरिफाई करें**

निम्न Python उदाहरण मौजूदा प्रस्तुति को पढ़ता है (ऊपर बनाई गई फ़ाइल का उपयोग करें), `hyperlink-audit.json` लिखता है, एक नीति लागू करता है, `hyperlink-sanitized.pptx` सहेजता है, और फिर से खोलकर दोनों सक्रियता प्रकारों को दोबारा जाँचता है। परिवर्तन करने से पहले कंटेनरों को एकत्र करता है और डुप्लिकेट प्रोसेसिंग से बचने के लिए प्रत्येक स्लाइड स्कोप को एक बार क्वेरी करता है। प्रेजेंटेशन क्वेरीज़ सामान्य स्लाइड्स को कवर करती हैं; पैकेज‑व्यापी इन्वेंट्री के लिए, उदाहरण सामान्य स्लाइड्स, मास्टर, लेआउट, नोट्स और उपस्थित होने पर नोट्स व हैंडआउट मास्टर को क्वेरी करता है।

रिपोर्ट में उपलब्ध होने पर एक‑आधारित स्लाइड इंडेक्स और [slide_id](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/slide_id/) रिकॉर्ड किया जाता है। कलेक्टर प्रत्येक लौटाए गए कंटेनर के साथ स्वामित्व वाली स्लाइड और स्कोप को बरकरार रखता है। मास्टर, लेआउट और नोट्स में सामान्य स्लाइड इंडेक्स नहीं होता और उन्हें उनके स्कोप से पहचाना जाता है। शैप कंटेनर और टेक्स्ट‑भाग फ़ॉर्मेटिंग कंटेनर अलग‑अलग लेबल किये जाते हैं; अन्य कंटेनर प्रकार अपने रन‑टाइम टाइप नाम को बरकरार रखते हैं। प्रत्येक कंटेनर को एक रिपोर्ट‑लोकल ID दी जाती है ताकि उसकी दो कार्रवाइयों को आपस में जोड़ा जा सके।

यह जानबूझकर प्रतिबंधात्मक एप्लिकेशन नीति केवल absolute HTTPS URL और वैध आंतरिक स्लाइड टार्गेट को ही अनुमति देती है। यह मैक्रो, प्रोग्राम, फ़ाइल कार्रवाई, अन्य स्लाइडशो कार्रवाइयाँ, अज्ञात कार्रवाइयाँ और अन्य URL स्कीम को अस्वीकार करता है। ये अस्वीकरण नीति के निर्णय हैं, न कि Aspose.Slides सुरक्षा निर्णय। केवल HTTPS भरोसा स्थापित नहीं करता: अपने एप्लिकेशन के लिए होस्ट एलॉ​​लिस्ट और अन्य जांचें जोड़ें। मूल और normalized दोनों बाहरी URL की जाँच की जाती है। उदाहरण मेटा‑डेटा का ऑडिट करता है बिना लिंक को फ़ॉलो किए या कार्रवाई को चलाए।

सुधार के लिए, कंटेनर का [hyperlink_manager](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlinkcontainer/hyperlink_manager/) [set_external_hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkmanager/set_external_hyperlink_click/), [remove_hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_click/) और [remove_hyperlink_mouse_over](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_mouse_over/) का समर्थन करता है। यहाँ, प्रतिबंधित बाहरी क्लिक लिंक को एक निश्चित HTTPS लैंडिंग पेज से बदल दिया जाता है; अन्य प्रतिबंधित क्लिक और प्रतिबंधित माउस‑ओवर कार्रवाइयाँ स्वतंत्र रूप से हटाई जाती हैं। सभी नीति उल्लंघनों को हटाने के लिए `replace_external_clicks` को `False` सेट करें। तैनाती से पहले एक एप्लिकेशन‑स्वामित्व वाला प्रतिस्थापन पेज चुनें।

रिपोर्ट का एक्सपोर्ट फ्लैग एक रूढ़िवादी PDF समीक्षा नीति का उपयोग करता है: माउस‑ओवर कार्रवाइयों और बाहरी लिंक या विशिष्ट स्लाइड जंप के अलावा अन्य सभी को संभावित रूप से असमर्थित के रूप में चिन्हित करता है। यह एक समीक्षा संकेत है, न कि क्षमता परीक्षण या यह गारंटी कि अनफ़्लैग्ड लिंक निर्यात में जीवित रहेंगे। समर्थित [PDF](/slides/hi/python-net/convert-powerpoint-to-pdf/) और [HTML](/slides/hi/python-net/convert-powerpoint-to-html/) निर्यात हाइपरलिंक्स को संरक्षित कर सकते हैं, कार्रवाई, निर्यात विकल्प और व्यूअर पर निर्भर करता है। रास्टर [images](/slides/hi/python-net/convert-powerpoint-to-png/) और [video](/slides/hi/python-net/convert-powerpoint-to-video/) इंटरैक्टिव हाइपरलिंक्स को नहीं रख सकते; उन आउटपुट के लिए ऑडिट करते समय हर कार्रवाई को फ्लैग करें।

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
    # प्रत्येक स्लाइड स्कोप को एक बार क्वेरी करें, प्रत्येक कंटेनर के साथ उसके मालिक को रखकर।
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

ऊपर बनाई गई इनपुट के साथ, रिपोर्ट में पाँच कार्रवाई पंक्तियाँ होती हैं। फ़ाइल माउस‑ओवर लिंक और मैक्रो क्लिक हटाए गए हैं, जबकि HTTPS लिंक और आंतरिक स्लाइड नेविगेशन बना रहता है। सत्यापन शून्य प्रतिबंधित कार्रवाइयाँ प्रिंट करता है। प्रतिबंधित बाहरी क्लिक URL वाली इनपुट भी प्रतिस्थापन शाखा को चलाती है। अनुमत क्लिक और प्रतिबंधित माउस‑ओवर वाले कंटेनर में क्लिक कार्रवाई बनी रहती है।

यह चयनात्मक सफाई [remove_all_hyperlinks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/remove_all_hyperlinks/) से अलग है, जो नीति की परवाह किए बिना चयनित स्कोप में दोनों सक्रियता प्रकारों को हटाता है। यहाँ की सत्यापन केवल हाइपरलिंक कार्रवाइयों को जाँचती है; यह एम्बेडेड VBA प्रोजेक्ट्स, OLE ऑब्जेक्ट्स या अन्य सक्रिय सामग्री को नहीं हटाती, तथा निर्यातित PDF या HTML फ़ाइल की वैधता की पुष्टि नहीं करती।

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं किसी अनुभाग या उसकी पहली स्लाइड से कैसे लिंक करूँ?**

PowerPoint में अनुभाग स्लाइड्स को समूहित करते हैं, लेकिन एक आंतरिक हाइपरलिंक व्यक्तिगत स्लाइड को लक्षित करता है। किसी अनुभाग पर नेविगेशन बनाने के लिए, उस अनुभाग की पहली स्लाइड से लिंक करें।

**क्या मैं मास्टर स्लाइड तत्वों पर हाइपरलिंक जोड़ सकता हूँ ताकि यह सभी स्लाइड्स पर काम करे?**

हां। मास्टर स्लाइड और लेआउट तत्व हाइपरलिंक का समर्थन करते हैं। इन तत्वों पर लिंक स्लाइड शो के दौरान उन स्लाइड्स पर उपलब्ध होते हैं जो संबंधित मास्टर या लेआउट का प्रयोग करती हैं।

**क्या हाइपरलिंक्स को PDF, HTML, छवियों या वीडियो में निर्यात करने पर संरक्षित रखा जाता है?**

समर्थित PDF और HTML निर्यात हाइपरलिंक्स को संरक्षित कर सकते हैं; रास्टर छवियां और वीडियो नहीं कर सकते। देखें [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks) में निर्यात विचार।