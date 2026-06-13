---
title: Python में PowerPoint प्रस्तुतियों को HTML में बदलें
linktitle: PowerPoint से HTML
type: docs
weight: 30
url: /hi/python-net/convert-powerpoint-to-html/
keywords:
- PowerPoint बदलें
- प्रस्तुति बदलें
- स्लाइड बदलें
- PPT बदलें
- PPTX बदलें
- PowerPoint से HTML
- प्रस्तुति से HTML
- स्लाइड से HTML
- PPT से HTML
- PPTX से HTML
- PowerPoint को HTML के रूप में सहेजें
- प्रस्तुति को HTML के रूप में सहेजें
- स्लाइड को HTML के रूप में सहेजें
- PPT को HTML के रूप में सहेजें
- PPTX को HTML के रूप में सहेजें
- PPT को HTML में निर्यात करें
- PPTX को HTML में निर्यात करें
- Python
- Aspose.Slides
description: "Python में PowerPoint प्रस्तुतियों को HTML में बदलें। PPT और PPTX फ़ाइलें, चयनित स्लाइड्स, नोट्स, फ़ॉन्ट, छवियां, SVG और मीडिया निर्यात करने के लिए Aspose.Slides का उपयोग करें।"
---
## **अवलोकन**

Aspose.Slides for Python via .NET Microsoft PowerPoint के बिना PowerPoint प्रस्तुतियों को HTML के रूप में सहेज सकता है। बुनियादी रूपांतरण एक [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) लोड और एक `save` कॉल [SaveFormat](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/saveformat/) के साथ है। जब आपको निर्यातित लेआउट, फ़ॉन्ट, छवियां, नोट्स, टिप्पणियां, SVG आउटपुट, या लिंक्ड संसाधनों को नियंत्रित करने की आवश्यकता हो तो [HtmlOptions](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/htmloptions/) का उपयोग करें।

यह गाइड व्यावहारिक HTML निर्यात परिदृश्यों पर केंद्रित है:

- पूरी प्रस्तुति या चयनित स्लाइड्स निर्यात करें।
- स्थिर-लेआउट, रिस्पॉन्सिव, या SVG-आधारित HTML उत्पन्न करें।
- स्पीकर नोट्स और टिप्पणियाँ शामिल करें।
- छवि गुणवत्ता और क्रॉप्ड छवि डेटा को नियंत्रित करें।
- फ़ॉन्ट एंबेड करें या फ़ॉन्ट फ़ाइलें अलग से सहेजें।
- बाहरी संसाधनों और मीडिया फ़ाइलों को कैसे लिखा और संदर्भित किया जाए चुनें।

डिफ़ॉल्ट रूप से, HTML निर्यात अधिकांश संसाधनों को एंबेड करके एक स्वयं-समावेशी HTML दस्तावेज़ उत्पन्न करता है। यह एक फ़ाइल साझा करने के लिए सुविधाजनक है, लेकिन इससे आउटपुट आकार बढ़ सकता है। वेब प्रकाशन के लिए, बाहरी संसाधनों, कम छवि DPI, और केवल उन फ़ॉन्ट को एंबेड करने पर विचार करें जो लक्ष्य वातावरण में भरोसेमंद रूप से उपलब्ध नहीं हैं।

## **एक प्रस्तुति को HTML में बदलें**

एक प्रस्तुति को HTML में निर्यात करने के लिए, उसे [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) से लोड करें और [SaveFormat](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/saveformat/) के साथ सहेजें।

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.html", slides.export.SaveFormat.HTML)
```

यह उदाहरण एक HTML फ़ाइल लिखता है। `with` स्टेटमेंट निर्यात के बाद प्रस्तुति ऑब्जेक्ट को नष्ट करता है और फ़ाइल हैंडल तथा रेंडरिंग संसाधनों को मुक्त करता है।

## **HtmlOptions का उपयोग करें**

[HtmlOptions](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/htmloptions/) HTML निर्यात के लिए मुख्य कॉन्फ़िगरेशन क्लास है। सामान्य सेटिंग्स में शामिल हैं:

- `slides_layout_options`: नोट्स, टिप्पणियाँ, हैंडआउट या अन्य लेआउट जानकारी जोड़ता है।
- `html_formatter`: HTML दस्तावेज़ की संरचना बदलता है या फॉर्मेटिंग को एक कंट्रोलर को सौंपता है।
- `slide_image_format`: स्लाइड्स के दर्शाने का तरीका बदलता है, उदाहरण के लिए SVG के रूप में।
- `pictures_compression`: छवि DPI और आउटपुट आकार को नियंत्रित करता है।
- `delete_pictures_cropped_areas`: क्रॉप की गई छवि डेटा को रखता या हटाता है।
- `svg_responsive_layout`: निर्यातित SVG सामग्री को उसके कंटेनर के अनुसार अनुकूल बनाता है।
- `show_hidden_slides`: आवश्यक होने पर छिपी स्लाइड्स शामिल करता है।

निचले अनुभाग सबसे आम विकल्पों को अलग-अलग दिखाते हैं ताकि आप केवल वही विकल्प मिलाएं जो आपके कार्यप्रवाह को आवश्यक हों।

## **चयनित स्लाइड्स को HTML में बदलें**

स्लाइड नंबर स्वीकार करने वाला `save` ओवरलोड 1-आधारित स्लाइड स्थितियों का उपयोग करता है। नीचे दिया गया लूप प्रत्येक स्लाइड को एक अलग HTML फ़ाइल में सहेजता है।

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide_count = len(presentation.slides)

    for slide_index in range(slide_count):
        slide_number = slide_index + 1
        slide_numbers = [slide_number]
        html_file_name = "slide-{}.html".format(slide_number)

        presentation.save(html_file_name, slide_numbers, slides.export.SaveFormat.HTML)
```

इस पैटर्न का उपयोग करें जब वेबसाइट या एप्लिकेशन को प्रत्येक स्लाइड के लिए एक HTML पृष्ठ चाहिए। यदि प्रत्येक स्लाइड को समान लेआउट चाहिए, तो एक [HtmlOptions](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/htmloptions/) इंस्टेंस बनाएं और इसे प्रत्येक `save` कॉल में पास करें।

## **रिस्पॉन्सिव HTML बनाएं**

[ResponsiveHtmlController](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/responsivehtmlcontroller/) [HtmlFormatter](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/htmlformatter/) के माध्यम से रिस्पॉन्सिव HTML आउटपुट प्रदान करता है। इसका उपयोग तब करें जब निर्यातित पृष्ठ को ब्राउज़र की चौड़ाई के अनुसार बेहतर अनुकूल होना चाहिए।

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    controller = slides.export.ResponsiveHtmlController()
    formatter = slides.export.HtmlFormatter.create_custom_formatter(controller)

    html_options = slides.export.HtmlOptions()
    html_options.html_formatter = formatter

    presentation.save("presentation-responsive.html", slides.export.SaveFormat.HTML, html_options)
```

SVG-आधारित रिस्पॉन्सिव लेआउट के लिए, [HtmlOptions](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/htmloptions/) पर `svg_responsive_layout` सेट करें। यह तब उपयोगी है जब स्लाइड सामग्री को स्केलेबल SVG मार्कअप के रूप में निर्यात किया जाता है।

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    html_options = slides.export.HtmlOptions()
    html_options.svg_responsive_layout = True

    presentation.save("presentation-svg-responsive.html", slides.export.SaveFormat.HTML, html_options)
```

## **स्पीकर नोट्स और टिप्पणियाँ शामिल करें**

स्पीकर नोट्स या टिप्पणियाँ शामिल करने के लिए `html_options.slides_layout_options` के माध्यम से [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/notescommentslayoutingoptions/) का उपयोग करें। नोट्स और टिप्पणियाँ डिफ़ॉल्ट रूप से छिपी रहती हैं जब तक आप उनकी स्थिति नहीं चुनते।

मान लीजिए स्रोत प्रस्तुति में स्पीकर नोट्स हैं:

![PowerPoint में स्पीकर नोट्स वाली स्लाइड](slide_with_notes.png)

निम्न कोड स्लाइड सामग्री को स्लाइड के नीचे स्पीकर नोट्स के साथ निर्यात करता है।

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    layout_options = slides.export.NotesCommentsLayoutingOptions()
    layout_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL

    html_options = slides.export.HtmlOptions()
    html_options.slides_layout_options = layout_options

    presentation.save("presentation-with-notes.html", slides.export.SaveFormat.HTML, html_options)
```

निर्यातित HTML में नोट्स क्षेत्र शामिल होता है:

![स्लाइड और स्पीकर नोट्स के साथ HTML आउटपुट](HTML_with_notes.png)

टिप्पणियों को निर्यात करने के लिए, `comments_position` सेट करें, उदाहरण के लिए `CommentsPositions.RIGHT` या `CommentsPositions.BOTTOM`। यदि आपको केवल टिप्पणियाँ चाहिए, तो `notes_position` को छोड़ दें। यदि आपको नोट्स और टिप्पणियाँ दोनों चाहिए, तो दोनों प्रॉपर्टी सेट करें।

## **छवि गुणवत्ता और क्रॉप्ड क्षेत्रों को नियंत्रित करें**

HTML निर्यात स्लाइड छवियों को संपीड़ित करके आउटपुट आकार कम कर सकता है। जब आपको उच्च छवि गुणवत्ता चाहिए, तो [PicturesCompression](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/picturescompression/) से मान चुनकर `pictures_compression` सेट करें।

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    html_options = slides.export.HtmlOptions()
    html_options.pictures_compression = slides.export.PicturesCompression.DPI150

    presentation.save("presentation-dpi-150.html", slides.export.SaveFormat.HTML, html_options)
```

डिफ़ॉल्ट रूप से, छवियों के क्रॉप्ड क्षेत्रों को निर्यातित आउटपुट से हटाया जा सकता है। केवल तभी क्रॉप्ड डेटा रखें जब उपयोगकर्ता को उन छिपी छवि भागों को पुनर्प्राप्त या निरीक्षण करने की आवश्यकता हो। इसे रखने से HTML आकार बढ़ सकता है।

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    html_options = slides.export.HtmlOptions()
    html_options.delete_pictures_cropped_areas = False

    presentation.save("presentation-with-cropped-areas.html", slides.export.SaveFormat.HTML, html_options)
```

## **CSS जोड़ें**

सरल स्टाइलिंग के लिए, एक CSS स्ट्रिंग को [HtmlFormatter](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/htmlformatter/) को पास करें। यह आसपास के HTML दस्तावेज़ को बदलता है जबकि Aspose.Slides स्लाइड सामग्री को रेंडर करना जारी रखता है।

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    css_rules = "body { margin: 0; background: #f7f7f7; } .slide { margin: 24px auto; }"
    formatter = slides.export.HtmlFormatter.create_document_formatter(css_rules, True)

    html_options = slides.export.HtmlOptions()
    html_options.html_formatter = formatter

    presentation.save("presentation-styled.html", slides.export.SaveFormat.HTML, html_options)
```

कस्टम दस्तावेज़ हेडर, लिंक्ड CSS फ़ाइल, या स्लाइड्स और शेप्स के चारों ओर कस्टम मार्कअप के लिए, एक कस्टम फॉर्मेटिंग कंट्रोलर का प्रयोग करें और उसे `create_custom_formatter` के साथ [HtmlFormatter](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/htmlformatter/) को पास करें।

## **फ़ॉन्ट एंबेड करें**

यदि लक्ष्य वातावरण में प्रस्तुति फ़ॉन्ट स्थापित नहीं हैं, तो [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/embedallfontshtmlcontroller/) के साथ HTML में फ़ॉन्ट एंबेड करें। एंबेडिंग दृश्य सटीकता सुधारती है लेकिन आउटपुट आकार बढ़ा देती है।

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    font_names_to_exclude = ["Arial"]
    font_controller = slides.export.EmbedAllFontsHtmlController(font_names_to_exclude)
    formatter = slides.export.HtmlFormatter.create_custom_formatter(font_controller)

    html_options = slides.export.HtmlOptions()
    html_options.html_formatter = formatter

    presentation.save("presentation-embedded-fonts.html", slides.export.SaveFormat.HTML, html_options)
```

केवल तब फ़ॉन्ट को बाहर रखें जब आप सुनिश्चित हों कि लक्ष्य ब्राउज़र या सिस्टम पहले से ही इसे प्रदान करता है। ब्रांड फ़ॉन्ट या कम सामान्य फ़ॉन्ट के लिए एंबेडिंग आमतौर पर सुरक्षित रहती है।

## **फ़ॉन्ट फ़ाइलों को एंबेड करने के बजाय लिंक करें**

HTML फ़ाइल आकार कम करने के लिए, फ़ॉन्ट डेटा को अलग‑अलग WOFF फ़ाइलों में लिखें और HTML में `@font-face` नियम जोड़ें। इसके लिए एक कंट्रोलर चाहिए जो निर्यात के दौरान फ़ॉन्ट डेटा लिखने के तरीके को अनुकूलित करे। Python via .NET में, उस कंट्रोलर को एक छोटे .NET हेल्पर असेंबली में लागू करें, Python में लोड करें, और `create_custom_formatter` के साथ उसे [HtmlFormatter](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/htmlformatter/) को पास करें।

फ़ॉन्ट को बाहरी करने पर, दो पाथ स्पष्ट रूप से चुनें:

- फ़ाइल सिस्टम आउटपुट निर्देशिका जहाँ उत्पन्न WOFF फ़ाइलें लिखी जाएँगी।
- URL पाथ जो HTML दस्तावेज़ में दिखाई देगा और ब्राउज़र उन फ़ॉन्ट फ़ाइलों को लोड करने के लिए उपयोग करेगा।

परिनियोजन पाथ अंतिम होने तक HTML फ़ाइल और उत्पन्न फ़ॉन्ट फ़ाइलें साथ रखें। यदि फ़ाइलें किसी अन्य स्थान पर परिनियोजित की जाती हैं, तो URL उपसर्ग को परिनियोजित URL पाथ के अनुसार मिलाएँ।

## **संसाधनों को बाहरी रूप से सहेजें**

स्वयं‑समावेशी HTML को ले जाना आसान है, लेकिन एंबेडेड Base64 संसाधन फ़ाइल को बड़ा बना सकते हैं। यदि आपके अनुप्रयोग को बाहरी छवि, फ़ॉन्ट, ऑडियो या वीडियो फ़ाइलों की आवश्यकता है, तो एक कस्टम लिंक/एंबेड कंट्रोलर का उपयोग करें और उसे [HtmlOptions](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/htmloptions/) कंस्ट्रक्टर को पास करें।

संसाधनों को बाहरी करने पर, दो पाथ स्पष्ट रूप से चुनें:

- फ़ाइल सिस्टम आउटपुट पाथ, जहाँ आपका अनुप्रयोग उत्पन्न छवियां, फ़ॉन्ट, ऑडियो, या वीडियो लिखता है।
- URL पाथ, जो ब्राउज़र HTML दस्तावेज़ से इन फ़ाइलों को लोड करने के लिए उपयोग करता है।

पूरा इमेज‑लिंकिंग चर्चा के लिए देखें [बाहरी लिंक की गई छवियों के साथ प्रस्तुतियों को HTML में निर्यात करें](/slides/hi/python-net/exporting-presentations-to-html-with-externally-linked-images/)।

## **मीडिया फ़ाइलें निर्यात करें**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/videoplayerhtmlcontroller/) वीडियो और ऑडियो फ़ाइलों को निर्यात करता है और ऐसा HTML लिखता है जिसे ब्राउज़र में चलाया जा सकता है। इसका कंस्ट्रक्टर लेता है:

- `path`: वह निर्देशिका जहाँ उत्पन्न मीडिया फ़ाइलें लिखी जाएँगी।
- `file_name`: उत्पन्न हो रहे HTML फ़ाइल का नाम।
- `base_uri`: मीडिया फ़ाइलों के लिए HTML लिंक में उपयोग किया गया पूर्ण URI उपसर्ग।

यदि HTML फ़ाइल `html-output/presentation.html` है और मीडिया फ़ाइलें `html-output/media` में सहेजी गई हैं, तो `path` को डिस्क पर मीडिया निर्देशिका की ओर संकेत करना चाहिए, जबकि `base_uri` को ब्राउज़र के दृष्टिकोण से उसी निर्देशिका की ओर संकेत करना चाहिए। स्थानीय पूर्वावलोकन के लिए, आप मीडिया निर्देशिका से `file:///` URI बना सकते हैं। परिनियोजित अनुप्रयोग के लिए, प्रकाशित मीडिया निर्देशिका के पूर्ण URL का उपयोग करें।

```python
import os
from pathlib import Path

import aspose.slides as slides

output_directory = os.path.join(os.getcwd(), "html-output")
media_directory = os.path.join(output_directory, "media")
os.makedirs(output_directory, exist_ok=True)
os.makedirs(media_directory, exist_ok=True)

html_file_name = "presentation.html"
media_base_uri = Path(media_directory).as_uri() + "/"

with slides.Presentation() as presentation:
    with open("intro.mp4", "rb") as video_stream:
        video = presentation.videos.add_video(
            video_stream,
            slides.LoadingStreamBehavior.READ_STREAM_AND_RELEASE)

    slide = presentation.slides[0]
    slide.shapes.add_video_frame(20, 20, 480, 270, video)

    controller = slides.export.VideoPlayerHtmlController(
        media_directory,
        html_file_name,
        media_base_uri)

    formatter = slides.export.HtmlFormatter.create_custom_formatter(controller)
    svg_options = slides.export.SVGOptions(controller)
    slide_image_format = slides.export.SlideImageFormat.svg(svg_options)

    html_options = slides.export.HtmlOptions(controller)
    html_options.html_formatter = formatter
    html_options.slide_image_format = slide_image_format

    html_file_path = os.path.join(output_directory, html_file_name)
    presentation.save(html_file_path, slides.export.SaveFormat.HTML, html_options)
```

प्रत्येक निर्यात कार्य के लिए अद्वितीय आउटपुट निर्देशिकाएँ उपयोग करें, विशेष रूप से सर्वर अनुप्रयोगों में। साझा आउटपुट पाथ विभिन्न रूपांतरणों की फ़ाइलों को एक‑दूसरे के ऊपर लिखने का कारण बन सकते हैं।

## **प्रदर्शन और संसाधन प्रबंधन**

HTML रूपांतरण एक रेंडरिंग ऑपरेशन है, इसलिए प्रसंस्करण समय और मेमोरी उपयोग स्लाइड संख्या, छवि रिज़ॉल्यूशन, फ़ॉन्ट, इफ़ेक्ट, चार्ट और एंबेडेड मीडिया पर निर्भर करता है। उच्च `pictures_compression` DPI मान, एंबेडेड फ़ॉन्ट, SVG आउटपुट, और रखे गए क्रॉप्ड छवि क्षेत्र सटीकता सुधार सकते हैं लेकिन आमतौर पर आउटपुट आकार बढ़ाते हैं।

बैच रूपांतरण के लिए:

- हर [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) उदाहरण को शीघ्र ही नष्ट (Dispose) करें।
- विभिन्न कार्यों के लिए अलग-अलग आउटपुट निर्देशिकाएँ उपयोग करें।
- सटीकता की आवश्यकता न हो तो सामान्य फ़ॉन्ट को एंबेड करने से बचें।
- जब HTML पूर्वावलोकन या थंबनेल के लिए हो, तो छवि DPI को कम करें।
- परिनियोजन पाथ अंतिम होने तक स्रोत प्रस्तुति, उत्पन्न HTML, और बाहरी संसाधनों को साथ रखें।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या हाइपरलिंक HTML आउटपुट में संरक्षित रहते हैं?**

हाँ। प्रस्तुति हाइपरलिंक HTML में निर्यात हो जाते हैं और जब लक्ष्य URL मान्य हो तो क्लिक करने योग्य रहते हैं।

**क्या मैं प्रस्तुतियों को समानांतर रूप से HTML में बदल सकता हूँ?**

हाँ, लेकिन एक [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) इंस्टेंस को थ्रेड्स के बीच साझा न करें। विभिन्न फ़ाइलों को अलग‑अलग प्रस्तुति इंस्टेंस, अलग‑अलग स्ट्रीम, और अलग‑अलग आउटपुट निर्देशिकाओं के साथ प्रोसेस करें। विवरण के लिए देखें [multithreading guidance](/slides/hi/python-net/multithreading/)।

**क्या Presentation ऑब्जेक्ट थ्रेड‑सेफ है?**

नहीं। एक एकल [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) इंस्टेंस को एक ही थ्रेड पर लोड, संशोधित, सहेज और नष्ट किया जाना चाहिए। समानांतर कार्य के लिए, प्रत्येक थ्रेड या प्रक्रिया के लिए एक स्वतंत्र इंस्टेंस बनाएं।

**जेनरेट किया गया HTML फ़ाइल बड़ा क्यों है?**

डिफ़ॉल्ट निर्यात संसाधनों को सीधे HTML में एंबेड कर देता है। एंबेडेड फ़ॉन्ट, उच्च‑DPI छवियां, मीडिया, SVG सामग्री, और रखे गए क्रॉप्ड छवि क्षेत्र भी आकार बढ़ाते हैं। छोटे आउटपुट को अधिकतम सटीकता से अधिक महत्व देने पर बाहरी संसाधनों का उपयोग करें, सामान्य फ़ॉन्ट को एंबेड करने से बचें, और `pictures_compression` को कम करें।

**PowerPoint फ़ॉन्ट आकार जैसे 24 pt HTML में 17.999819 pt क्यों दिखता है?**

यह इसलिए हो सकता है क्योंकि PowerPoint और HTML विभिन्न DPI मॉडल का उपयोग करते हैं। PowerPoint 72 DPI पर आधारित टाइपोग्राफ़िक पॉइंट में टेक्स्ट आकार संग्रहीत करता है, जबकि HTML लेआउट 96 DPI मॉडल में CSS पिक्सेल पर आधारित है। जब Aspose.Slides प्रस्तुति को HTML में निर्यात करता है, तो फ़ॉन्ट आकार इन सिस्टमों के बीच अनुवादित होता है, और परिवर्तन में छोटे राउंडिंग अंतर उत्पन्न हो सकते हैं।

ये मान वास्तविक दृश्य फ़ॉन्ट‑साइज़ परिवर्तन नहीं दर्शाते। ये केवल PowerPoint और HTML के बीच टेक्स्ट मीट्रिक्स को बदलने के गणितीय परिणाम हैं।

**मीडिया निर्यात के लिए base_uri कैसे चुनें?**

`base_uri` को ब्राउज़र के दृष्टिकोण से चुनें और उसे पूर्ण URI के रूप में पास करें। स्थानीय पूर्वावलोकन के लिए, आप `Path(media_directory).as_uri() + "/"` से इसे उत्पन्न कर सकते हैं। परिनियोजन के लिए, प्रकाशित मीडिया निर्देशिका के पूर्ण URL का उपयोग करें। फ़ाइल सिस्टम `path` और ब्राउज़र `base_uri` समान स्ट्रिंग नहीं होना आवश्यक है, लेकिन उन्हें एक ही संसाधन स्थान का वर्णन करना चाहिए।

**क्या मैं छिपी स्लाइड्स शामिल कर सकता हूँ?**

हाँ। जब छिपी स्लाइड्स को निर्यात करना आवश्यक हो, तो [HtmlOptions](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/htmloptions/) पर `show_hidden_slides = True` सेट करें।