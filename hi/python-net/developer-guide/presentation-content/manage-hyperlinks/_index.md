---
title: Python के साथ प्रस्तुतियों में हाइपरलिंक्स प्रबंधित करें
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
description: "Aspose.Slides for Python via .NET के साथ PowerPoint और OpenDocument प्रस्तुतियों में हाइपरलिंक्स को सहजता से प्रबंधित करें—मिनटों में इंटरैक्टिविटी और कार्यप्रवाह को बढ़ाएं।"
---
## **परिचय**

हाइपरलिंक बाहरी संसाधन, ऑब्जेक्ट या डेटा आइटम, या फ़ाइल के भीतर किसी विशिष्ट स्थान का संदर्भ है। PowerPoint प्रस्तुतियों में सामान्य हाइपरलिंक प्रकार शामिल हैं:

* पाठ, आकृतियों या मीडिया में एम्बेडेड वेबसाइट के लिंक
* स्लाइड्स के लिंक

Aspose.Slides for Python via .NET प्रस्तुतियों में हाइपरलिंक‑संबंधित विभिन्न ऑपरेशन्स को सक्षम बनाता है।

## **URL हाइपरलिंक्स जोड़ें**

यह अनुभाग Aspose.Slides के साथ काम करते समय स्लाइड तत्वों में URL हाइपरलिंक्स जोड़ने का तरीका समझाता है। यह पाठ, आकृतियों और चित्रों को लिंक पते सौंपने को कवर करता है ताकि प्रस्तुतियों के दौरान सहज नेविगेशन सुनिश्चित हो सके।

### **टेक्स्ट में URL हाइपरलिंक्स जोड़ें**

निम्नलिखित कोड उदाहरण दिखाता है कि टेक्स्ट में वेबसाइट हाइपरलिंक कैसे जोड़ें:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50, False)
    shape.add_text_frame("Aspose: File Format APIs")
    
    text_portion = shape.text_frame.paragraphs[0].portions[0]

    text_portion.portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    text_portion.portion_format.hyperlink_click.tooltip = "More than 70% of Fortune 100 companies trust Aspose APIs."

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **आकृतियों या फ़्रेम्स में URL हाइपरलिंक्स जोड़ें**

निम्नलिखित कोड उदाहरण दिखाता है कि आकृति में वेबसाइट हाइपरलिंक कैसे जोड़ें:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50)

    shape.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    shape.hyperlink_click.tooltip = "More than 70% of Fortune 100 companies trust Aspose APIs."

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **मीडिया में URL हाइपरलिंक्स जोड़ें**

Aspose.Slides आपको छवियों, ऑडियो और वीडियो फ़ाइलों में हाइपरलिंक्स जोड़ने की अनुमति देता है।

निम्नलिखित कोड उदाहरण दिखाता है कि **छवि** में हाइपरलिंक कैसे जोड़ें:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # प्रस्तुति में एक छवि जोड़ें।
    with open("image.jpeg", "rb") as image_stream:
        image_data = image_stream.read()
        image = presentation.images.add_image(image_data)

    # स्लाइड 1 पर पहले जोड़ी गई छवि का उपयोग करके एक चित्र फ्रेम बनाएं।
    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)

    picture_frame.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    picture_frame.hyperlink_click.tooltip = "More than 70% of Fortune 100 companies trust Aspose APIs."

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

निम्नलिखित कोड उदाहरण दिखाता है कि **ऑडियो फ़ाइल** में हाइपरलिंक कैसे जोड़ें:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("audio.mp3", "rb") as audio_stream:
        audio_data = audio_stream.read()
        audio = presentation.audios.add_audio(audio_data)
        
    audio_frame = slide.shapes.add_audio_frame_embedded(10, 10, 100, 100, audio)

    audio_frame.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    audio_frame.hyperlink_click.tooltip = "More than 70% of Fortune 100 companies trust Aspose APIs."

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

निम्नलिखित कोड उदाहरण दिखाता है कि **वीडियो** में हाइपरलिंक कैसे जोड़ें:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("video.avi", "rb") as video_stream:
        video_data = video_stream.read()
        video = presentation.videos.add_video(video_data)
        
    video_frame = slide.shapes.add_video_frame(10, 10, 100, 100, video)

    video_frame.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    video_frame.hyperlink_click.tooltip = "More than 70% of Fortune 100 companies trust Aspose APIs."

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Tip" color="primary" %}}
आप देखना चाह सकते हैं [Manage OLE in Presentations Using Python](/slides/hi/python-net/manage-ole/).
{{% /alert %}}

## **हाइपरलिंक्स का उपयोग करके सामग्री तालिका बनाना**

क्योंकि हाइपरलिंक्स आपको ऑब्जेक्ट्स या स्थानों का संदर्भ देने की अनुमति देता है, आप उनका उपयोग करके सामग्री तालिका बना सकते हैं।

निम्नलिखित नमूना कोड दर्शाता है कि हाइपरलिंक्स के साथ सामग्री तालिका कैसे बनाएं:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    first_slide = presentation.slides[0]
    second_slide = presentation.slides.add_empty_slide(first_slide.layout_slide)

    content_table = first_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 300, 100)
    content_table.fill_format.fill_type = slides.FillType.NO_FILL
    content_table.line_format.fill_format.fill_type = slides.FillType.NO_FILL
    content_table.text_frame.paragraphs.clear()

    paragraph = slides.Paragraph()
    paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    paragraph.text = "Title of slide 2 .......... "

    link_text_portion = slides.Portion()
    link_text_portion.text = "Page 2"
    link_text_portion.portion_format.hyperlink_manager.set_internal_hyperlink_click(second_slide)

    paragraph.portions.add(link_text_portion)
    content_table.text_frame.paragraphs.add(paragraph)

    presentation.save("link_to_slide.pptx", slides.export.SaveFormat.PPTX)
```

## **हाइपरलिंक्स का स्वरूप**

यह अनुभाग Aspose.Slides में हाइपरलिंक्स की उपस्थिति को स्वरूपित करने का तरीका दिखाता है। आप रंग और अन्य शैली विकल्पों को नियंत्रित करना सीखेंगे ताकि टेक्स्ट, आकृतियों और चित्रों में हाइपरलिंक स्वरूपण सुसंगत रहे।

### **हाइपरलिंक रंग**

[color_source](https://reference.aspose.com/slides/hi/python-net/aspose.slides/hyperlink/color_source/) प्रॉपर्टी का उपयोग करके, आप हाइपरलिंक का रंग निर्धारित कर सकते हैं और उसका रंग जानकारी पढ़ सकते हैं। यह सुविधा PowerPoint 2019 में पेश की गई थी, इसलिए इस प्रॉपर्टी के माध्यम से किए गए बदलाव PowerPoint के पुराने संस्करणों पर लागू नहीं होते।

निम्नलिखित नमूना दिखाता है कि समान स्लाइड में विभिन्न रंगों के हाइपरलिंक्स कैसे जोड़ें:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50, False)
    shape1.add_text_frame("This is a sample of a colored hyperlink.")

    text_portion1 = shape1.text_frame.paragraphs[0].portions[0]
    text_portion1.portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    text_portion1.portion_format.hyperlink_click.color_source = slides.HyperlinkColorSource.PORTION_FORMAT
    text_portion1.portion_format.fill_format.fill_type = slides.FillType.SOLID
    text_portion1.portion_format.fill_format.solid_fill_color.color = draw.Color.red

    shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 450, 50, False)
    shape2.add_text_frame("This is a sample of a regular hyperlink.")

    text_portion2 = shape2.text_frame.paragraphs[0].portions[0]
    text_portion2.portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")

    presentation.save("hyperlinks.pptx", slides.export.SaveFormat.PPTX)
```

## **प्रस्तुतियों से हाइपरलिंक्स हटाएँ**

यह अनुभाग Aspose.Slides के साथ काम करते समय प्रस्तुतियों से हाइपरलिंक्स हटाने का तरीका समझाता है। आप टेक्स्ट, आकृतियों और चित्रों से लिंक टार्गेट को साफ़ करना सीखेंगे जबकि मूल सामग्री और स्वरूपण को बनाए रखेंगे।

### **टेक्स्ट से हाइपरलिंक्स हटाएँ**

निम्नलिखित नमूना कोड दिखाता है कि प्रस्तुति स्लाइड पर टेक्स्ट से हाइपरलिंक्स कैसे हटाएं:

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if type(shape) is slides.AutoShape:
            for paragraph in shape.text_frame.paragraphs:
                for text_portion in paragraph.portions:
                    text_portion.portion_format.hyperlink_manager.remove_hyperlink_click()

    presentation.save("removed_hyperlinks.pptx", slides.export.SaveFormat.PPTX)
```

### **आकृतियों या फ़्रेम्स से हाइपरलिंक्स हटाएँ**

निम्नलिखित नमूना कोड दिखाता है कि प्रस्तुति स्लाइड पर आकृतियों से हाइपरलिंक्स कैसे हटाएं:

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
   slide = presentation.slides[0]

   for shape in slide.shapes:
       shape.hyperlink_manager.remove_hyperlink_click()

   presentation.save("removed_hyperlinks.pptx", slides.export.SaveFormat.PPTX)
```

## **परिवर्तनीय हाइपरलिंक्स**

[Hyperlink](https://reference.aspose.com/slides/hi/python-net/aspose.slides/hyperlink/) क्लास परिवर्तनशील है। इस क्लास का उपयोग करके, आप इन प्रॉपर्टीज़ के मान बदल सकते हैं:

- [target_frame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/hyperlink/target_frame/)
- [tooltip](https://reference.aspose.com/slides/hi/python-net/aspose.slides/hyperlink/tooltip/)
- [history](https://reference.aspose.com/slides/hi/python-net/aspose.slides/hyperlink/history/)
- [highlight_click](https://reference.aspose.com/slides/hi/python-net/aspose.slides/hyperlink/highlight_click/)
- [stop_sound_on_click](https://reference.aspose.com/slides/hi/python-net/aspose.slides/hyperlink/stop_sound_on_click/)

निम्नलिखित कोड स्निपेट दिखाता है कि स्लाइड में हाइपरलिंक कैसे जोड़ें और फिर उसका टूलटिप कैसे संपादित करें:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50, False)
    shape.add_text_frame("Aspose: File Format APIs")

    text_portion = shape.text_frame.paragraphs[0].portions[0]
    text_portion.portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    text_portion.portion_format.hyperlink_click.tooltip = "More than 70% of Fortune 100 companies trust Aspose APIs."

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **IHyperlinkQueries में समर्थित प्रॉपर्टीज़**

आप प्रस्तुति, स्लाइड, या उस टेक्स्ट से जो हाइपरलिंक रखता है, [HyperlinkQueries](https://reference.aspose.com/slides/hi/python-net/aspose.slides/hyperlinkqueries/) तक पहुंच सकते हैं।

- [Presentation.hyperlink_queries](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/hyperlink_queries/)
- [BaseSlide.hyperlink_queries](https://reference.aspose.com/slides/hi/python-net/aspose.slides/baseslide/hyperlink_queries/)
- [TextFrame.hyperlink_queries](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframe/hyperlink_queries/)

[HyperlinkQueries](https://reference.aspose.com/slides/hi/python-net/aspose.slides/hyperlinkqueries/) क्लास इन विधियों का समर्थन करता है:

- [get_hyperlink_clicks()](https://reference.aspose.com/slides/hi/python-net/aspose.slides/hyperlinkqueries/get_hyperlink_clicks/)
- [get_hyperlink_mouse_overs()](https://reference.aspose.com/slides/hi/python-net/aspose.slides/hyperlinkqueries/get_hyperlink_mouse_overs/)
- [get_any_hyperlinks()](https://reference.aspose.com/slides/hi/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/)
- [remove_all_hyperlinks()](https://reference.aspose.com/slides/hi/python-net/aspose.slides/hyperlinkqueries/remove_all_hyperlinks/)

{{% alert color="primary" %}}
आप Aspose का सरल, मुफ्त ऑनलाइन PowerPoint संपादक देखना चाह सकते हैं [PowerPoint editor](https://products.aspose.app/slides/hi/editor).
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं एक स्लाइड के अलावा किसी "सेक्शन" या सेक्शन की पहली स्लाइड पर आंतरिक नेविगेशन कैसे बना सकता हूँ?**

PowerPoint में सेक्शन स्लाइड्स के समूह होते हैं; नेविगेशन तकनीकी रूप से किसी विशिष्ट स्लाइड को लक्षित करता है। "सेक्शन पर नेविगेट" करने के लिए, आप आमतौर पर उसकी पहली स्लाइड से लिंक करते हैं।

**क्या मैं मास्टर स्लाइड तत्वों पर हाइपरलिंक संलग्न कर सकता हूँ जिससे यह सभी स्लाइड्स पर काम करे?**

हाँ। मास्टर स्लाइड और लेआउट तत्व हाइपरलिंक को समर्थन देते हैं। ऐसे लिंक चाइल्ड स्लाइड्स पर दिखाई देते हैं और स्लाइडशो के दौरान क्लिक करने योग्य होते हैं।

**क्या PDF, HTML, इमेजेज या वीडियो में एक्सपोर्ट करते समय हाइपरलिंक्स बरकरार रहेंगे?**

हाँ—[PDF](/slides/hi/python-net/convert-powerpoint-to-pdf/) और [HTML](/slides/hi/python-net/convert-powerpoint-to-html/) में लिंक सामान्यतः बरकरार रहते हैं। जब आप [इमेजेज](/slides/hi/python-net/convert-powerpoint-to-png/) और [वीडियो](/slides/hi/python-net/convert-powerpoint-to-video/) में एक्सपोर्ट करते हैं, तो क्लिकयोग्यता नहीं रहती क्योंकि उन फ़ॉर्मेट्स की प्रकृति (रास्टर फ्रेम/वीडियो हाइपरलिंक को सपोर्ट नहीं करते) के कारण।