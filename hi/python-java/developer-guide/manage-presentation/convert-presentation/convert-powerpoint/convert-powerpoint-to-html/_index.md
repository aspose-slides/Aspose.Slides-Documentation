---
title: Python के माध्यम से Java में PowerPoint प्रस्तुतियों को HTML में परिवर्तित करें
linktitle: PowerPoint से HTML
type: docs
weight: 30
url: /hi/python-java/convert-powerpoint-to-html/
keywords:
- PowerPoint को बदलें
- प्रेज़ेंटेशन को बदलें
- स्लाइड को बदलें
- PPT को बदलें
- PPTX को बदलें
- PowerPoint से HTML
- प्रेज़ेंटेशन से HTML
- स्लाइड से HTML
- PPT से HTML
- PPTX से HTML
- PowerPoint को HTML के रूप में सहेजें
- प्रेज़ेंटेशन को HTML के रूप में सहेजें
- स्लाइड को HTML के रूप में सहेजें
- PPT को HTML के रूप में सहेजें
- PPTX को HTML के रूप में सहेजें
- PPT को HTML में निर्यात करें
- PPTX को HTML में निर्यात करें
- Python
- Java
- Aspose.Slides
description: "Python के माध्यम से Java में PowerPoint प्रस्तुतियों को HTML में परिवर्तित करें। PPT और PPTX फाइलों, चयनित स्लाइडों, नोट्स, फ़ॉन्ट्स, छवियों, SVG और मीडिया को निर्यात करने के लिए Aspose.Slides का उपयोग करें।"
---
## **सारांश**

Aspose.Slides for Python via Java Microsoft PowerPoint के बिना PowerPoint प्रस्तुतियों को HTML के रूप में सहेज सकता है। बुनियादी रूपान्तरण एकल [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) लोड और एक [save](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#save) कॉल के साथ [SaveFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/saveformat/) उपयोग करता है। जब आपको निर्यातित लेआउट, फ़ॉन्ट, छवियों, नोट्स, टिप्पणियों, SVG आउटपुट, या लिंक्ड रिसोर्सेज को नियंत्रित करना हो तो [HtmlOptions](https://reference.aspose.com/slides/hi/python-java/aspose.slides/htmloptions/) का उपयोग करें।

यह गाइड व्यावहारिक HTML निर्यात परिदृश्यों पर केंद्रित है:

- पूरी प्रस्तुति या चयनित स्लाइड्स को निर्यात करें।
- स्थिर‑लेआउट, रिस्पॉन्सिव, या SVG‑आधारित HTML उत्पन्न करें।
- वक्ता नोट्स और टिप्पणियाँ शामिल करें।
- छवि गुणवत्ता और क्रॉप की गई छवि डेटा को नियंत्रित करें।
- फ़ॉन्ट एम्बेड करें या फ़ॉन्ट फ़ाइलों को अलग से सहेजें।
- बाहरी रिसोर्सेज और मीडिया फ़ाइलों को लिखने और संदर्भित करने का तरीका चुनें।

डिफ़ॉल्ट रूप से, HTML निर्यात एक आत्म‑निहित HTML दस्तावेज़ बनाता है जहाँ अधिकांश रिसोर्सेज एम्बेडेड होते हैं। यह एक फ़ाइल साझा करने के लिए सुविधाजनक है, लेकिन आउटपुट आकार बढ़ा सकता है। वेब प्रकाशन के लिए, बाहरी रिसोर्सेज, कम छवि DPI, और केवल उन फ़ॉन्ट्स को एम्बेड करने पर विचार करें जो लक्ष्य वातावरण में भरोसेमंद रूप से उपलब्ध नहीं हैं।

## **एक प्रस्तुति को HTML में बदलें**

एक प्रस्तुति को HTML में निर्यात करने के लिए, उसे [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) से लोड करें और उसे [SaveFormat.Html](https://reference.aspose.com/slides/hi/python-java/aspose.slides/saveformat/#Html) के साथ सहेजें।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation.html", SaveFormat.Html)
finally:
    presentation.dispose()
```

प्रत्येक उदाहरण वर्तमान कार्यकारी निर्देशिका से `presentation.pptx` लोड करता है। इसे चलाने से पहले Aspose.Slides for Python via Java और एक संगत Java रनटाइम स्थापित करें। JVM को प्रत्येक Python प्रक्रिया में केवल एक बार प्रारम्भ किया जाता है।

यह उदाहरण एक HTML फ़ाइल लिखता है। प्रस्तुति ऑब्जेक्ट को `finally` ब्लॉक में नष्ट किया जाता है, जिससे निर्यात के बाद फ़ाइल हैंडल्स और रेंडरिंग रिसोर्सेज मुक्त हो जाते हैं।

## **HTML निर्यात को कॉन्फ़िगर करें**

[HtmlOptions](https://reference.aspose.com/slides/hi/python-java/aspose.slides/htmloptions/) HTML निर्यात की मुख्य कॉन्फ़िगरेशन क्लास है। सामान्य सेटिंग्स में शामिल हैं:

- [setSlidesLayoutOptions](https://reference.aspose.com/slides/hi/python-java/aspose.slides/htmloptions/#setSlidesLayoutOptions): नोट्स, टिप्पणियाँ, हैंडआउट्स, या अन्य लेआउट जानकारी जोड़ता है।
- [setHtmlFormatter](https://reference.aspose.com/slides/hi/python-java/aspose.slides/htmloptions/#setHtmlFormatter): HTML दस्तावेज़ संरचना बदलता है या फ़ॉर्मेटिंग को एक कंट्रोलर को सौंपता है।
- [setSlideImageFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/htmloptions/#setSlideImageFormat): स्लाइड्स के प्रतिनिधित्व को बदलता है, उदाहरण के लिए SVG के रूप में।
- [setPicturesCompression](https://reference.aspose.com/slides/hi/python-java/aspose.slides/htmloptions/#setPicturesCompression): छवि DPI और आउटपुट आकार को नियंत्रित करता है।
- [setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/hi/python-java/aspose.slides/htmloptions/#setDeletePicturesCroppedAreas): क्रॉप की गई छवि डेटा को रखता या हटाता है।
- [setSvgResponsiveLayout](https://reference.aspose.com/slides/hi/python-java/aspose.slides/htmloptions/#setSvgResponsiveLayout): निर्यातित SVG सामग्री को उसके कंटेनर के अनुसार अनुकूल बनाता है।
- [setShowHiddenSlides](https://reference.aspose.com/slides/hi/python-java/aspose.slides/htmloptions/#setShowHiddenSlides): आवश्यक होने पर छुपी स्लाइड्स को शामिल करता है।

निम्नलिखित अनुभाग सबसे आम विकल्पों को अलग‑अलग दिखाते हैं ताकि आप केवल अपनी कार्यप्रवाह की जरूरत वाले विकल्पों को मिलाकर उपयोग कर सकें।

## **चयनित स्लाइड्स को HTML में बदलें**

[Presentation.save](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#save) का वह ओवरलोड जो स्लाइड नंबर स्वीकार करता है 1‑आधारित स्लाइड स्थितियों का प्रयोग करता है। नीचे दिया गया लूप प्रत्येक स्लाइड को अलग HTML फ़ाइल में सहेजता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide_count = presentation.getSlides().size()
    for slide_index in range(slide_count):
        slide_number = slide_index + 1
        slide_numbers = jpype.JArray(jpype.JInt)([slide_number])
        html_file_name = f"slide-{slide_number}.html"
        presentation.save(html_file_name, slide_numbers, SaveFormat.Html)
finally:
    presentation.dispose()
```

जब एक वेबसाइट या एप्लिकेशन को प्रत्येक स्लाइड के लिए एक HTML पेज चाहिए हो, तो इस पैटर्न का प्रयोग करें। यदि प्रत्येक स्लाइड का लेआउट समान होना चाहिए, तो एक ही [HtmlOptions](https://reference.aspose.com/slides/hi/python-java/aspose.slides/htmloptions/) इंस्टेंस बनाएं और उसे प्रत्येक [Presentation.save](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#save) कॉल में पास करें।

## **रिस्पॉन्सिव HTML बनाएं**

[ResponsiveHtmlController](https://reference.aspose.com/slides/hi/python-java/aspose.slides/responsivehtmlcontroller/) [HtmlFormatter](https://reference.aspose.com/slides/hi/python-java/aspose.slides/htmlformatter/) के माध्यम से रिस्पॉन्सिव HTML आउटपुट प्रदान करता है। जब निर्यातित पेज को ब्राउज़र की चौड़ाई के अनुसार बेहतर अनुकूल होना चाहिए, तो इसका उपयोग करें।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlFormatter, HtmlOptions, Presentation, ResponsiveHtmlController, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    controller = ResponsiveHtmlController()
    formatter = HtmlFormatter.createCustomFormatter(controller)

    html_options = HtmlOptions()
    html_options.setHtmlFormatter(formatter)

    presentation.save("presentation-responsive.html", SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

SVG‑आधारित रिस्पॉन्सिव लेआउट के लिए, `True` के साथ [HtmlOptions.setSvgResponsiveLayout](https://reference.aspose.com/slides/hi/python-java/aspose.slides/htmloptions/#setSvgResponsiveLayout) को कॉल करें। यह तब उपयोगी है जब स्लाइड सामग्री को स्केलेबल SVG मार्कअप के रूप में निर्यात किया जाता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    html_options = HtmlOptions()
    html_options.setSvgResponsiveLayout(True)

    presentation.save("presentation-svg-responsive.html", SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

## **वक्ता नोट्स और टिप्पणियों को शामिल करें**

वक्ता नोट्स या टिप्पणियों को शामिल करने के लिए [HtmlOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/hi/python-java/aspose.slides/htmloptions/#setSlidesLayoutOptions) के माध्यम से [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/hi/python-java/aspose.slides/notescommentslayoutingoptions/) इस्तेमाल करें। नोट्स और टिप्पणियाँ डिफ़ॉल्ट रूप से छिपी रहती हैं जब तक आप उनकी स्थितियों को नहीं चुनते।

मान लीजिए स्रोत प्रस्तुति में वक्ता नोट्स हैं:

![PowerPoint में वक्ता नोट्स के साथ स्लाइड](slide_with_notes.png)

नीचे दिया गया कोड स्लाइड सामग्री को स्लाइड के नीचे वक्ता नोट्स के साथ निर्यात करता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlOptions, NotesCommentsLayoutingOptions, NotesPositions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    layout_options = NotesCommentsLayoutingOptions()
    layout_options.setNotesPosition(NotesPositions.BottomFull)

    html_options = HtmlOptions()
    html_options.setSlidesLayoutOptions(layout_options)

    presentation.save("presentation-with-notes.html", SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

निर्यातित HTML में नोट्स क्षेत्र शामिल होगा:

![स्लाइड और वक्ता नोट्स के साथ HTML आउटपुट](HTML_with_notes.png)

टिप्पणियाँ निर्यात करने के लिए, [NotesCommentsLayoutingOptions.setCommentsPosition](https://reference.aspose.com/slides/hi/python-java/aspose.slides/notescommentslayoutingoptions/#setCommentsPosition) को कॉल करें, उदाहरण के लिए [CommentsPositions.Right](https://reference.aspose.com/slides/hi/python-java/aspose.slides/commentspositions/#Right) या [CommentsPositions.Bottom](https://reference.aspose.com/slides/hi/python-java/aspose.slides/commentspositions/#Bottom) के साथ। यदि आपको केवल टिप्पणियाँ चाहिए, तो [NotesCommentsLayoutingOptions.setNotesPosition](https://reference.aspose.com/slides/hi/python-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition) को छोड़ दें। यदि आपको दोनों नोट्स और टिप्पणियाँ चाहिए, तो दोनों मेथड को कॉल करें।

## **छवि गुणवत्ता और क्रॉप किए गए क्षेत्रों को नियंत्रित करें**

HTML निर्यात स्लाइड छवियों को संपीड़ित करके आउटपुट आकार कम कर सकता है। जब आपको उच्च छवि गुणवत्ता चाहिए, तो [PicturesCompression](https://reference.aspose.com/slides/hi/python-java/aspose.slides/picturescompression/) से एक मान को [HtmlOptions.setPicturesCompression](https://reference.aspose.com/slides/hi/python-java/aspose.slides/htmloptions/#setPicturesCompression) में पास करें।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlOptions, PicturesCompression, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    html_options = HtmlOptions()
    html_options.setPicturesCompression(PicturesCompression.Dpi150)

    presentation.save("presentation-dpi-150.html", SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

डिफ़ॉल्ट रूप से, निर्यातित आउटपुट से छवियों के क्रॉप किए गए क्षेत्रों को हटाया जा सकता है। केवल तब क्रॉप डेटा रखें जब उपयोगकर्ताओं को उन छिपे हुए भागों को पुनः प्राप्त या निरीक्षण करना आवश्यक हो। इसे रखनें से HTML आकार बढ़ सकता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    html_options = HtmlOptions()
    html_options.setDeletePicturesCroppedAreas(False)

    presentation.save("presentation-with-cropped-areas.html", SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

## **CSS जोड़ें**

सरल स्टाइलिंग के लिए, [HtmlFormatter.createDocumentFormatter](https://reference.aspose.com/slides/hi/python-java/aspose.slides/htmlformatter/#createDocumentFormatter) को एक CSS स्ट्रिंग पास करें। यह स्लाइड सामग्री को रेंडर करते हुए आसपास के HTML दस्तावेज़ को बदलता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlFormatter, HtmlOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    css_rules = "body { margin: 0; background: #f7f7f7; } .slide { margin: 24px auto; }"
    formatter = HtmlFormatter.createDocumentFormatter(css_rules, True)

    html_options = HtmlOptions()
    html_options.setHtmlFormatter(formatter)

    presentation.save("presentation-styled.html", SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

कस्टम दस्तावेज़ हेडर, लिंक्ड CSS फ़ाइल, या स्लाइड और शेप्स के आसपास कस्टम मार्कअप के लिए, JPype इंटरफ़ेस प्रॉक्सी के माध्यम से एक कस्टम फ़ॉर्मेटिंग कंट्रोलर बनाएं और उसे [HtmlFormatter](https://reference.aspose.com/slides/hi/python-java/aspose.slides/htmlformatter/) में [HtmlFormatter.createCustomFormatter](https://reference.aspose.com/slides/hi/python-java/aspose.slides/htmlformatter/#createCustomFormatter) के साथ पास करें।

## **फ़ॉन्ट एम्बेड करें**

यदि लक्ष्य वातावरण में प्रस्तुति फ़ॉन्ट स्थापित नहीं हो सकते, तो [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/hi/python-java/aspose.slides/embedallfontshtmlcontroller/) के साथ फ़ॉन्ट्स को HTML में एम्बेड करें। एम्बेडिंग से दृश्य सटीकता बढ़ती है लेकिन फ़ाइल आकार बढ़ता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EmbedAllFontsHtmlController, HtmlFormatter, HtmlOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    font_names_to_exclude = jpype.JArray(jpype.JString)(["Arial"])
    font_controller = EmbedAllFontsHtmlController(font_names_to_exclude)
    formatter = HtmlFormatter.createCustomFormatter(font_controller)

    html_options = HtmlOptions()
    html_options.setHtmlFormatter(formatter)

    presentation.save("presentation-embedded-fonts.html", SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

केवल तब फ़ॉन्ट्स को बाहर रखें जब आप सुनिश्चित हों कि लक्ष्य ब्राउज़र या सिस्टम पहले से ही उन्हें प्रदान करता है। ब्रांड फ़ॉन्ट्स या कम सामान्य फ़ॉन्ट्स के लिए एम्बेडिंग आमतौर पर सुरक्षित रहती है।

## **रिसोर्सेज को बाहरी रूप से सहेजें**

आत्म‑निहित HTML ले जाना आसान है, लेकिन एम्बेडेड Base64 रिसोर्सेज फ़ाइल को बड़ा बना सकते हैं। यदि आपके एप्लिकेशन को बाहरी छवि फ़ाइलों की आवश्यकता है, तो JPype इंटरफ़ेस प्रॉक्सी के माध्यम से एक रिसोर्स‑लिंकिंग कंट्रोलर लागू करें और उसे [HtmlOptions](https://reference.aspose.com/slides/hi/python-java/aspose.slides/htmloptions/) कंस्ट्रक्टर में पास करें।

जब आप रिसोर्सेज को बाहरी बनाते हैं, तो दो पाथ को जान‑बूझकर चुनें:

- फ़ाइल सिस्टम आउटपुट पाथ, जहाँ आपका एप्लिकेशन जनरेट की गई छवियां, फ़ॉन्ट, ऑडियो या वीडियो लिखता है।
- URL पाथ, जो ब्राउज़र HTML दस्तावेज़ से उन फ़ाइलों को लोड करने के लिए उपयोग करता है।

## **मीडिया फ़ाइलें निर्यात करें**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/hi/python-java/aspose.slides/videoplayerhtmlcontroller/) वीडियो और ऑडियो फ़ाइलों को निर्यात करता है और ऐसा HTML लिखता है जो ब्राउज़र में उन्हें चलाने में सक्षम हो। इसका कंस्ट्रक्टर लेता है:

- `path`: वह डायरेक्टरी जहाँ जनरेट किए गए मीडिया फ़ाइलें लिखी जाएँगी।
- `fileName`: जनरेट किया जा रहा HTML फ़ाइल नाम।
- `baseUri`: HTML लिंक में मीडिया फ़ाइलों के लिए उपयोग किया जाने वाला पूर्ण URI प्रीफ़िक्स।

नीचे दिया गया उदाहरण `presentation.pptx` में पहले से एम्बेडेड मीडिया को निर्यात करता है। जनरेट किया गया HTML केवल फ़ाइल नाम से मीडिया फ़ाइलों को संदर्भित करता है, जो HTML दस्तावेज़ के सापेक्ष है, इसलिए `path` वही डायरेक्टरी होनी चाहिए जहाँ HTML फ़ाइल भी लिखी जाती है। `baseUri` को पूर्ण URI होना चाहिए: स्थानीय प्रीव्यू के लिए, आउटपुट डायरेक्टरी से `file:///` URI बनाएं; डिप्लॉयड एप्लिकेशन के लिए, प्रकाशित डायरेक्टरी के पूर्ण URL का उपयोग करें।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlFormatter, HtmlOptions, Presentation, SVGOptions, SaveFormat, SlideImageFormat, VideoPlayerHtmlController

from pathlib import Path

output_directory = Path("html-output").resolve()
output_directory.mkdir(parents=True, exist_ok=True)
html_file_name = "presentation.html"
media_base_uri = output_directory.as_uri() + "/"

presentation = Presentation("presentation.pptx")
try:
    controller = VideoPlayerHtmlController(str(output_directory), html_file_name, media_base_uri)
    formatter = HtmlFormatter.createCustomFormatter(controller)
    svg_options = SVGOptions(controller)
    slide_image_format = SlideImageFormat.svg(svg_options)

    html_options = HtmlOptions(controller)
    html_options.setHtmlFormatter(formatter)
    html_options.setSlideImageFormat(slide_image_format)

    html_file_path = output_directory / html_file_name
    presentation.save(str(html_file_path), SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

ऐसी आउटपुट डायरेक्टरी चुनें जो प्रत्येक निर्यात कार्य के लिए विशिष्ट हो, विशेषकर सर्वर एप्लिकेशन में। साझा आउटपुट पाथ्स विभिन्न रूपांतरणों की फ़ाइलों को ओवरराइट कर सकते हैं।

## **प्रदर्शन और रिसोर्स प्रबंधन**

HTML रूपान्तरण एक रेंडरिंग ऑपरेशन है, इसलिए प्रोसेसिंग समय और मेमोरी उपयोग स्लाइड गिनती, छवि रेज़ोल्यूशन, फ़ॉन्ट, इफ़ेक्ट, चार्ट और एम्बेडेड मीडिया पर निर्भर करता है। उच्च छवि DPI मान, एम्बेडेड फ़ॉन्ट्स, SVG आउटपुट, और रखे गए क्रॉप किए हुए छवि क्षेत्रों को पास करने से सटीकता बढ़ सकती है, लेकिन सामान्यतः आउटपुट आकार भी बढ़ता है।

बैच रूपान्तरण के लिए:

- प्रत्येक [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) इंस्टेंस को जल्दी नष्ट करें।
- अलग‑अलग कार्यों के लिए अलग आउटपुट डायरेक्टरी उपयोग करें।
- सामान्य फ़ॉन्ट्स को तब तक एम्बेड न करें जब तक सटीकता की आवश्यकता न हो।
- जब HTML प्रीव्यू या थंबनेल के लिए हो, तो छवि DPI घटाएँ।
- अंत तक स्रोत प्रस्तुति, जनरेट किया गया HTML, और बाहरी रिसोर्सेज को साथ‑साथ रखें जब तक डिप्लॉयमेंट पाथ अंतिम न हों।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या हाइपरलिंक्स HTML आउटपुट में संरक्षित रहते हैं?**

हाँ। प्रस्तुति के हाइपरलिंक्स HTML में निर्यात होते हैं और लक्ष्य URL वैध होने पर क्लिक करने योग्य रहते हैं।

**क्या मैं प्रस्तुति को समानांतर में HTML में बदल सकता हूँ?**

हाँ, लेकिन एक [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) इंस्टेंस को थ्रेड्स के बीच साझा न करें। विभिन्न फ़ाइलों को अलग‑अलग प्रस्तुति इंस्टेंस, अलग‑अलग स्ट्रीम, और अलग आउटपुट डायरेक्टरी के साथ प्रोसेस करें। विवरण के लिए [multithreading guidance](/slides/hi/python-java/multithreading/) देखें।

**क्या प्रस्तुति ऑब्जेक्ट थ्रेड‑सेफ़ है?**

नहीं। एक ही [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) इंस्टेंस को केवल एक थ्रेड पर लोड, संशोधित, सहेजा और नष्ट किया जाना चाहिए। समानांतर कार्य के लिए प्रत्येक थ्रेड या प्रक्रिया में एक स्वतंत्र इंस्टेंस बनाएं।

**जनरेट किया गया HTML फ़ाइल बड़ा क्यों है?**

डिफ़ॉल्ट निर्यात रिसोर्सेज को सीधे HTML में एम्बेड करता है। एम्बेडेड फ़ॉन्ट्स, उच्च‑DPI छवियां, मीडिया, SVG सामग्री, और रखे गए क्रॉप किए गए छवि क्षेत्र आकार बढ़ाते हैं। बाहरी रिसोर्सेज का उपयोग करें, सामान्य फ़ॉन्ट्स को एम्बेड न करें, और जब छोटे आउटपुट आकार अधिक महत्वपूर्ण हो तो [HtmlOptions.setPicturesCompression](https://reference.aspose.com/slides/hi/python-java/aspose.slides/htmloptions/#setPicturesCompression) को कम DPI मान के साथ पास करें।

**HTML में फ़ॉन्ट‑साइज़ मान PowerPoint मानों से अलग क्यों होते हैं?**

निर्यातित पेज SVG कॉऑर्डिनेट सिस्टम और स्केलिंग ट्रांसफ़ॉर्म का उपयोग कर सकता है। केवल एक रॉ CSS या SVG फ़ॉन्ट‑साइज़ मान अंतिम प्रदर्शित आकार का पूर्ण वर्णन नहीं करता। इच्छित ज़ूम लेवल पर रेंडर की गई स्लाइड की तुलना करें, और यदि टेक्स्ट अलग दिखता है तो फ़ॉन्ट उपलब्धता जाँचें।

**मीडिया निर्यात के लिए baseUri कैसे चुनें?**

`baseUri` को ब्राउज़र के दृष्टिकोण से चुनें और उसे पूर्ण URI के रूप में पास करें। स्थानीय प्रीव्यू के लिए, इसे आउटपुट डायरेक्टरी से `output_directory.as_uri() + "/"` के रूप में प्राप्त किया जा सकता है। डिप्लॉयमेंट के लिए, प्रकाशित डायरेक्टरी के पूर्ण URL का उपयोग करें। फ़ाइल सिस्टम `path` और ब्राउज़र `baseUri` समान स्ट्रिंग नहीं होने चाहिए, परंतु दोनों को वही स्थान वर्णित करना चाहिए, और वह स्थान वह डायरेक्टरी होनी चाहिए जिसमें जनरेट किया गया HTML फ़ाइल रखी गई हो, क्योंकि मीडिया लिंक उसी के सापेक्ष लिखे जाते हैं।

**क्या मैं छुपी स्लाइड्स को शामिल कर सकता हूँ?**

हाँ। जब छुपी स्लाइड्स को निर्यात करना आवश्यक हो, तो [HtmlOptions.setShowHiddenSlides](https://reference.aspose.com/slides/hi/python-java/aspose.slides/htmloptions/#setShowHiddenSlides) को `True` के साथ कॉल करें।