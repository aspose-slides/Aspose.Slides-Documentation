---
title: Python के माध्यम से Java में प्रस्तुति हाइपरलिंक प्रबंधित करें
linktitle: हाइपरलिंक प्रबंधित करें
type: docs
weight: 20
url: /hi/python-java/manage-hyperlinks/
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
- 변이 가능한 हाइपरलिंक
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Java
- Aspose.Slides
description: "Python के माध्यम से Java के लिए Aspose.Slides का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में हाइपरलिंक जोड़ें, स्वरूपित करें, अपडेट करें और हटाएँ, Python उदाहरणों के साथ।"
---
## **परिचय**

एक हाइपरलिंक प्रस्तुति सामग्री को वेबसाइट या प्रस्तुति के भीतर किसी स्थान से जोड़ता है। PowerPoint में, हाइपरलिंक आमतौर पर दो उद्देश्यों की पूर्ति करते हैं:

* टेक्स्ट, आकृति, या मीडिया फ्रेम से एक वेबसाइट खोलें।
* किसी अन्य स्लाइड पर नेविगेट करें, उदाहरण के लिए, सामग्री तालिका से।

Aspose.Slides for Python via Java आपको ये लिंक जोड़ने, उनका स्वरूप और ध्वनि नियंत्रित करने, उनकी गुणधर्म अपडेट करने और उन्हें हटाने की सुविधा देता है। नीचे दिए गए उदाहरण दिखाते हैं कि व्यक्तिगत तत्वों पर हाइपरलिंक के साथ कैसे काम करें और प्रस्तुति, स्लाइड, या टेक्स्ट‑फ़्रेम स्तर पर हाइपरलिंक तक कैसे पहुंचें।

{{% alert color="info" title="Note" %}}
आप मुफ्त ऑनलाइन [Aspose PowerPoint संपादक](https://products.aspose.app/slides/editor) का उपयोग करके प्रस्तुतियों को भी संपादित कर सकते हैं।
{{% /alert %}} 

## **URL हाइपरलिंक जोड़ें**

आप टेक्स्ट, आकृति, या मीडिया फ्रेम को वेबसाइट URL असाइन कर सकते हैं। जिस तत्व को आप हाइपरलिंक असाइन करते हैं, वह क्लिक योग्य क्षेत्र निर्धारित करता है: टेक्स्ट भाग चयनित टेक्स्ट को लिंक करता है, जबकि आकृति या फ्रेम स्लाइड ऑब्जेक्ट को लिंक करता है।

सापेक्ष हाइपरलिंक वाली प्रस्तुतियों के लिए, दस्तावेज़‑स्तर के बेस को पढ़ने, बदलने या साफ़ करने हेतु [Manage the Hyperlink Base](/slides/hi/python-java/presentation-properties/#manage-the-hyperlink-base) देखें।

### **पाठ में URL हाइपरलिंक जोड़ें**

पाठ को वेबसाइट से लिंक करने के लिए, टेक्स्ट भाग की [setHyperlinkClick](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/#setHyperlinkClick) विधि को एक [Hyperlink](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/) पास करें, जैसा कि नीचे दिखाया गया है। केवल वही भाग क्लिक योग्य बन जाएगा।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, False)
    shape.addTextFrame("Aspose: File Format APIs")

    portion_format = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat()
    portion_format.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    portion_format.getHyperlinkClick().setTooltip("Explore Aspose file format APIs")
    portion_format.setFontHeight(32)

    presentation.save("presentation-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **आकृतियों और मीडिया फ्रेम में URL हाइपरलिंक जोड़ें**

एक आकृति या फ्रेम को क्लिक योग्य बनाने के लिए, उसकी [setHyperlinkClick](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setHyperlinkClick) विधि को कॉल करें। हाइपरलिंक स्वयं ऑब्जेक्ट से जुड़ा होता है, न कि उसमें मौजूद टेक्स्ट भाग से।

इसी विधि को चित्र, ऑडियो, और वीडियो फ्रेम पर भी लागू किया जाता है: फ्रेम को हाइपरलिंक असाइन करें और आवश्यक होने पर [setTooltip](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setTooltip) को कॉल करें।

निम्न उदाहरण एक आयत को क्लिक योग्य बनाता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50)

    shape.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    shape.getHyperlinkClick().setTooltip("Explore Aspose file format APIs")

    presentation.save("presentation-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **हाइपरलिंक का उपयोग करके सामग्री तालिका बनाएं**

आंतरिक हाइपरलिंक पाठकों को सामग्री तालिका से किसी विशिष्ट स्लाइड पर कूदने की अनुमति देते हैं। निम्न उदाहरण पहली स्लाइड पर “Page 2” टेक्स्ट को दूसरी स्लाइड से जोड़ने के लिए [setInternalHyperlinkClick](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkmanager/#setInternalHyperlinkClick) का उपयोग करता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Paragraph, Portion, Presentation, SaveFormat, ShapeType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)
    second_slide = presentation.getSlides().addEmptySlide(first_slide.getLayoutSlide())

    table_of_contents = first_slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 300, 100)
    table_of_contents.getFillFormat().setFillType(FillType.NoFill)
    table_of_contents.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
    table_of_contents.getTextFrame().getParagraphs().clear()

    paragraph = Paragraph()
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    paragraph.setText("Title of slide 2 .......... ")

    link_portion = Portion()
    link_portion.setText("Page 2")
    link_portion.getPortionFormat().getHyperlinkManager().setInternalHyperlinkClick(second_slide)

    paragraph.getPortions().add(link_portion)
    table_of_contents.getTextFrame().getParagraphs().add(paragraph)

    presentation.save("link_to_slide.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **हाइपरलिंक को स्वरूपित करें**

### **रंग**

[Hyperlink](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/) की [setColorSource](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setColorSource) विधि निर्धारित करती है कि हाइपरलिंक प्रस्तुति के हाइपरलिंक रंग का उपयोग करता है या टेक्स्ट भाग के फ़ॉर्मेट का। कस्टम टेक्स्ट रंग लागू करने के लिए, [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkcolorsource/) चुनें और भाग का भराव रंग सेट करें। यह सुविधा PowerPoint 2019 में पेश की गई थी; पुराने संस्करण इस सेटिंग को लागू नहीं करते।

निम्न उदाहरण समान स्लाइड पर दो टेक्स्ट हाइपरलिंक जोड़ता है। पहला लाल टेक्स्ट भराव के साथ है, जबकि दूसरा डिफ़ॉल्ट हाइपरलिंक रंग रखता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Hyperlink, HyperlinkColorSource, Presentation, SaveFormat, ShapeType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    colored_link_shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 450, 50, False)
    colored_link_shape.addTextFrame("This hyperlink uses a custom color.")
    portion_format = colored_link_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat()
    portion_format.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    portion_format.getHyperlinkClick().setColorSource(HyperlinkColorSource.PortionFormat)
    portion_format.getFillFormat().setFillType(FillType.Solid)
    portion_format.getFillFormat().getSolidFillColor().setColor(Color.RED)

    default_link_shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 450, 50, False)
    default_link_shape.addTextFrame("This hyperlink uses the default color.")
    default_link_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setHyperlinkClick(Hyperlink("https://www.aspose.com/"))

    presentation.save("presentation-out-hyperlink.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```
### **ध्वनि**

हाइपरलिंक सक्रिय होने पर ध्वनि बजा सकता है या पहले से चल रही ध्वनि को रोक सकता है। इन व्यवहारों को कॉन्फ़िगर करने के लिए निम्न विधियों का उपयोग करें:

- [Hyperlink.setSound](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setSound) हाइपरलिंक से संबंधित ऑडियो निर्दिष्ट करता है।
- [Hyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setStopSoundOnClick) नियंत्रित करता है कि हाइपरलिंक सक्रिय होने पर पिछली ध्वनि बंद हो जाए।

#### **हाइपरलिंक ध्वनि जोड़ें**

निम्न उदाहरण `sampleaudio.wav` को लोड करता है और पहले स्लाइड पर एक बटन से जोड़ता है। बटन पर क्लिक करने से ध्वनि बजती है और अगली स्लाइड पर जाता है। उसी स्लाइड पर दूसरा आकार क्लिक करने पर पूर्व ध्वनि रोकता है, बिना नेविगेशन कार्रवाई के।

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    audio_data = Path("sampleaudio.wav").read_bytes()
    java_audio_data = jpype.JArray(jpype.JByte)(audio_data)
    hyperlink_sound = presentation.getAudios().addAudio(java_audio_data)
    first_slide = presentation.getSlides().get_Item(0)
    play_button = first_slide.getShapes().addAutoShape(ShapeType.SoundButton, 100, 100, 100, 50)
    play_button.setHyperlinkClick(Hyperlink.getNextSlide())
    if not play_button.getHyperlinkClick().getStopSoundOnClick() and play_button.getHyperlinkClick().getSound() is None:
        play_button.getHyperlinkClick().setSound(hyperlink_sound)
    second_slide = presentation.getSlides().addEmptySlide(first_slide.getLayoutSlide())
    stop_button = second_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 100, 50)
    stop_button.setHyperlinkClick(Hyperlink.getNoAction())
    stop_button.getHyperlinkClick().setStopSoundOnClick(True)
    presentation.save("hyperlink-sound.pptx", SaveFormat.Pptx)
except OSError as exception:
    print(f"Unable to read the audio file: {exception}")
finally:
    presentation.dispose()
```

#### **हाइपरलिंक ध्वनि निकालें**

निम्न उदाहरण ऊपर बनाए गए प्रस्तुति को खोलता है और पहले आकार के हाइपरलिंक ऑडियो को [getSound](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#getSound) और [getBinaryData](https://reference.aspose.com/slides/python-java/aspose.slides/audio/#getBinaryData) के माध्यम से मेमोरी में पढ़ता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("hyperlink-sound.pptx")
try:
    if presentation.getSlides().size() > 0 and presentation.getSlides().get_Item(0).getShapes().size() > 0:
        hyperlink = presentation.getSlides().get_Item(0).getShapes().get_Item(0).getHyperlinkClick()
        sound = hyperlink.getSound() if hyperlink is not None else None
        if sound is not None:
            audio_data = bytes(sound.getBinaryData())
            print(f"Extracted {len(audio_data)} bytes of hyperlink audio.")
        else:
            print("The first shape has no hyperlink sound.")
    else:
        print("The presentation has no first slide or shape to inspect.")
finally:
    presentation.dispose()
```

### **टूलटिप और इंटरैक्शन सेटिंग्स**

टेक्स्ट या आकृति को हाइपरलिंक असाइन करने के बाद आप निम्न [Hyperlink](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/) विधियों को कॉल कर सकते हैं:

- [setTooltip](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setTooltip) लिंक के लिए दर्शक को संकेत के रूप में दिखाने वाला टेक्स्ट सेट करता है।
- [setTargetFrame](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setTargetFrame) लागू होने पर पैरेंट HTML फ्रेमसेट के भीतर लक्ष्य फ्रेम निर्दिष्ट करता है।
- [setHistory](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setHistory) नियंत्रित करता है कि लिंक को सक्रिय करने पर उसका लक्ष्य देखी गई हाइपरलिंक सूची में जोड़ा जाए या नहीं।
- [setHighlightClick](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setHighlightClick) नियंत्रित करता है कि क्लिक करने पर हाइपरलिंक हाइलाइट हो या नहीं।

## **प्रेज़ेंटेशन से हाइपरलिंक हटाएँ**

हाइपरलिंक कंटेनरों, जिसमें टेक्स्ट‑पोर्टियन लिंक भी शामिल हैं, को बदलने से पहले एकत्र करने के लिए [getAnyHyperlinks](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks) का उपयोग करें। निम्न उदाहरण पहली स्लाइड से दोनों सक्रियता प्रकारों को हटाता है। केवल एक प्रकार हटाने के लिए, केवल [removeHyperlinkClick](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkmanager/#removeHyperlinkClick) या [removeHyperlinkMouseOver](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkmanager/#removeHyperlinkMouseOver) को कॉल करें; क्लिक कार्रवाई को हटाने से उसका माउस‑ओवर समकक्ष हटता नहीं है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    if presentation.getSlides().size() > 0:
        containers = list(presentation.getSlides().get_Item(0).getHyperlinkQueries().getAnyHyperlinks())
        for container in containers:
            container.getHyperlinkManager().removeHyperlinkClick()
            container.getHyperlinkManager().removeHyperlinkMouseOver()
        presentation.save("pres-removed-hyperlinks.pptx", SaveFormat.Pptx)
    else:
        print("The presentation has no slides to process.")
finally:
    presentation.dispose()
```

बिना शर्त हटाने के लिए, [removeAllHyperlinks](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#removeAllHyperlinks) चयनित सीमा में दोनों सक्रियता प्रकारों को एक कॉल में हटाता है। चयनात्मक सफ़ाई और मास्टर, लेआउट, नोट्स तथा नोट्स‑और‑हैंडआउट मास्टर की कवरेज के लिए देखें [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks)।

## **पूरी हाइपरलिंक इन्वेंट्री बनाएं**

प्रेज़ेंटेशन वितरित करने से पहले, उसकी इंटरैक्टिव कार्रवाइयों और वेब लिंक की इन्वेंट्री बनाएं। [getAnyHyperlinks](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks) हाइपरलिंक कंटेनर लौटाता है, जैसे [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) और [PortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/) ऑब्जेक्ट, न कि URL स्ट्रिंग की सपाट सूची। प्रत्येक कंटेनर पर [getHyperlinkClick](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getHyperlinkClick) और [getHyperlinkMouseOver](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getHyperlinkMouseOver) दोनों का निरीक्षण करें। वे स्वतंत्र हैं: समान कंटेनर दोनों कार्रवाइयों को उजागर कर सकता है, इसलिए पूर्ण रिपोर्ट में प्रत्येक कंटेनर के लिए दो पंक्तियों की आवश्यकता हो सकती है।

केवल आकृति‑स्तर के हाइपरलिंक स्कैन करने से टेक्स्ट पोर्शन से जुड़े लिंक छूट सकते हैं। उचित स्कोप पर क्वेरी करें, और लौटाए गए कंटेनर को रखें ताकि बाद में आप उनके कार्यों को अपडेट या हटाने सकें।

### **प्रेज़ेंटेशन, स्लाइड, और टेक्स्ट‑फ़्रेम स्कोप्स की क्वेरी**

[HyperlinkQueries](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/) क्लास निम्न माध्यमों से उपलब्ध है: [Presentation.getHyperlinkQueries](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getHyperlinkQueries), [BaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getHyperlinkQueries), और [TextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getHyperlinkQueries)। प्रत्येक स्कोप समान क्वेरी को समर्थन देता है:

- [getHyperlinkClicks](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#getHyperlinkClicks) क्लिक कार्रवाई वाले कंटेनर लौटाता है।
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#getHyperlinkMouseOvers) माउस‑ओवर कार्रवाई वाले कंटेनर लौटाता है।
- [getAnyHyperlinks](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks) किसी भी या दोनों कार्रवाई वाले कंटेनर लौटाता है।

निम्न उदाहरण `hyperlink-audit-input.pptx` को एक बाहरी क्लिक लिंक, एक फ़ाइल माउस‑ओवर लिंक, आंतरिक स्लाइड नेविगेशन, एक टेक्स्ट माउस‑ओवर लिंक, और एक मैक्रो कार्रवाई के साथ बनाता है। यह इनमें से किसी भी कार्रवाई को निष्पादित नहीं करता। तीनों क्वेरी हर स्कोप में समान रूप से कार्य करती हैं; गणना कंटेनर की संख्या दर्शाती है, कार्रवाई की कुल संख्या नहीं। टेक्स्ट‑फ़्रेम स्कोप enclosing आकृति के अपने लिंक को बाहर रखता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType


def print_counts(scope, queries):
    click_count = queries.getHyperlinkClicks().size()
    mouse_over_count = queries.getHyperlinkMouseOvers().size()
    any_count = queries.getAnyHyperlinks().size()
    print(f"{scope}: click={click_count}, mouse-over={mouse_over_count}, any={any_count}")


presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    destination = presentation.getSlides().addEmptySlide(slide.getLayoutSlide())
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 60)
    shape.getTextFrame().setText("Click the text to go to slide 2")
    shape.getHyperlinkManager().setExternalHyperlinkClick("https://example.com/")
    shape.getHyperlinkClick().setTooltip("Public website")
    shape.getHyperlinkManager().setExternalHyperlinkMouseOver("file:///C:/private/report.xlsx")
    portion_format = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat()
    portion_format.getHyperlinkManager().setInternalHyperlinkClick(destination)
    portion_format.getHyperlinkManager().setExternalHyperlinkMouseOver("https://example.com/help")
    macro_button = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 120, 200, 60)
    macro_button.getHyperlinkManager().setMacroHyperlinkClick("ReviewPresentation")
    print_counts("Presentation", presentation.getHyperlinkQueries())
    print_counts("Slide 1", slide.getHyperlinkQueries())
    print_counts("Text frame", shape.getTextFrame().getHyperlinkQueries())
    presentation.save("hyperlink-audit-input.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

इस उदाहरण में, प्रेज़ेंटेशन और स्लाइड क्वेरी क्रमशः तीन क्लिक कंटेनर, दो माउस‑ओवर कंटेनर, और तीन दोनों प्रकार की कार्रवाइयों वाले कंटेनर रिपोर्ट करती हैं। टेक्स्ट‑फ़्रेम क्वेरी प्रत्येक श्रेणी में एक कंटेनर रिपोर्ट करती है।

### **कार्रवाइयों और गंतव्यों को वर्गीकृत करें**

किसी कार्रवाई को उसकी गंतव्य से पहले समझने के लिए [Hyperlink.getActionType](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#getActionType) का उपयोग करें। [HyperlinkActionType](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkactiontype/) के मान वेब नेविगेशन से अधिक कवरेज देते हैं:

| मान | ऑडिट के लिए अर्थ |
| --- | --- |
| `Hyperlink` | बाहरी हाइपरलिंक; URL और उसके स्कीम की जांच करें। |
| `JumpSpecificSlide` | विशिष्ट स्लाइड पर आंतरिक नेविगेशन। |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | अंतर्निहित स्लाइडशो नेविगेशन, स्लाइडशो संदर्भ में हल किया जाता है। |
| `JumpEndShow`, `StartCustomSlideShow` | वर्तमान शो समाप्त करें या कस्टम शो शुरू करें। |
| `StartMacro` | मैक्रो निष्पादित करें। |
| `StartProgram` | प्रोग्राम लॉन्च करें। |
| `OpenFile`, `OpenPresentation` | फ़ाइल या अन्य प्रस्तुति खोलें; वेब URL से अलग समीक्षा करें। |
| `StartStopMedia` | मीडिया प्लेबैक शुरू या रोकें। |
| `NoAction`, `Unknown` | कोई नेविगेशन कार्रवाई नहीं, या अज्ञात कार्रवाई जिसके लिए समीक्षा की आवश्यकता है। |

बाहरी गंतव्यों को [getExternalUrl](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#getExternalUrl) से पढ़ें और विशिष्ट आंतरिक गंतव्यों को [getTargetSlide](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#getTargetSlide) से। आंतरिक कार्रवाइयों और अंतर्निहित कमांड में बाहरी URL नहीं हो सकता; खाली URL का अर्थ यह नहीं है कि कंटेनर में कोई कार्रवाई नहीं है। जब [getExternalUrlOriginal](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#getExternalUrlOriginal) सामान्यीकृत URL से अलग हो, तो उसका मान संरक्षित रखें, और उपलब्ध होने पर [getTooltip](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#getTooltip) द्वारा लौटाए गए टूलटिप को भी शामिल करें।

### **हाइपरलिंक की रिपोर्ट, सफ़ाई, और सत्यापन करें**

निम्न Python उदाहरण मौजूदा प्रस्तुति को पढ़ता है (ऊपर बनाई गई फ़ाइल का उपयोग करें), `hyperlink-audit.json` लिखता है, एक नीति लागू करता है, `hyperlink-sanitized.pptx` सहेजता है, और फिर दोनों सक्रियता प्रकारों को फिर से जाँचने के लिए इसे खोलता है। यह बदलने से पहले कंटेनर एकत्र करता है और समान कंटेनर को दो बार प्रोसेस करने से बचने के लिए रेफ़रेंस समानता का उपयोग करता है। प्रेज़ेंटेशन क्वेरी सामान्य स्लाइड को कवर करती है; पैकेज‑व्यापी इन्वेंट्री के लिए यह स्पष्ट रूप से मास्टर, लेआउट, नोट्स, तथा नोट्स और हैंडआउट मास्टर को भी क्वेरी करती है जब उपलब्ध हों।

रिपोर्ट एक‑आधारित स्लाइड इंडेक्स और उपलब्ध होने पर [getSlideId](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getSlideId) को रिकॉर्ड करती है। [getSlide](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getSlide) समर्थित कंटेनर के लिए स्वामित्व स्लाइड प्रदान करता है। मास्टर, लेआउट और नोट्स के पास सामान्य स्लाइड इंडेक्स नहीं होता और उन्हें उनके स्कोप द्वारा पहचाना जाता है। आकृति कंटेनर और टेक्स्ट‑पोर्टियन फ़ॉर्मेट कंटेनर को अलग‑अलग लेबल किया जाता है; अन्य कंटेनर प्रकार अपने रन‑टाइम टाइप नाम को बनाए रखते हैं। प्रत्येक कंटेनर को रिपोर्ट‑स्थानीय ID दी जाती है ताकि उसकी दो कार्रवाइयों को जोड़ा जा सके। रिपोर्ट कार्रवाई प्रकार को Java एन्यूमरेशन द्वारा परिभाषित पूर्णांक स्थिरांक के रूप में संग्रहीत करती है।

यह प्रतिबंधात्मक अनुप्रयोग नीति केवल पूर्ण HTTPS URL और मान्य आंतरिक स्लाइड लक्ष्य की अनुमति देती है। यह मैक्रो, प्रोग्राम, फ़ाइल कार्रवाइयों, अन्य स्लाइडशो कार्रवाइयों, अज्ञात कार्रवाइयों, और अन्य URL स्कीम को अस्वीकार करता है। ये अस्वीकृतियां नीति‑निर्णय हैं, Aspose.Slides सुरक्षा निर्णय नहीं। केवल HTTPS भरोसा स्थापित नहीं करता: अपने अनुप्रयोग के लिए होस्ट अलाउलिस्ट और अन्य जाँचें जोड़ें। मूल और सामान्यीकृत बाहरी URL दोनों जाँचे जाते हैं। उदाहरण लिंक का अनुसरण या कार्रवाई चलाए बिना मेटाडेटा का ऑडिट करता है।

सुधार के लिए, कंटेनर की [getHyperlinkManager](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getHyperlinkManager) [setExternalHyperlinkClick](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkmanager/#setExternalHyperlinkClick), [removeHyperlinkClick](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkmanager/#removeHyperlinkClick), और [removeHyperlinkMouseOver](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkmanager/#removeHyperlinkMouseOver) का समर्थन करता है। यहाँ, प्रतिबंधित बाहरी क्लिक लिंक को एक निश्चित HTTPS लैंडिंग पेज से बदल दिया जाता है; अन्य प्रतिबंधित क्लिक और प्रतिबंधित माउस‑ओवर कार्रवाइयों को स्वतंत्र रूप से हटाया जाता है। सभी नीति उल्लंघनों को हटाने के लिए `replace_external_clicks` को `False` सेट करें। तैनाती से पहले अनुप्रयोग‑स्वामित्व पेज तय करें।

रिपोर्ट का निर्यात फ़्लैग एक रूढ़िवादी PDF समीक्षा नीति उपयोग करता है: माउस‑ओवर कार्रवाई और बाहरी लिंक या विशिष्ट स्लाइड कूद के अलावा सभी को संभावित असमर्थित के रूप में चिह्नित किया जाता है। यह एक समीक्षा संकेत है, न कि क्षमता परीक्षण या यह गारंटी कि अनफ़्लैग्ड लिंक निर्यात में टिके रहेंगे। समर्थित [PDF](/slides/hi/python-java/convert-powerpoint-to-pdf/) और [HTML](/slides/hi/python-java/convert-powerpoint-to-html/) निर्यात कार्रवाई, निर्यात विकल्प, और दर्शक के आधार पर हाइपरलिंक बरकरार रख सकते हैं; रास्टर [images](/slides/hi/python-java/convert-powerpoint-to-png/) और [video](/slides/hi/python-java/convert-powerpoint-to-video/) इंटरैक्टिव हाइपरलिंक नहीं रख सकते; ऑडिट करते समय सभी कार्रवाइयों को फ्लैग करें।

```python
import json
from pathlib import Path
from urllib.parse import urlsplit

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HyperlinkActionType, PortionFormat, Presentation, SaveFormat, Shape

IdentityHashMap = jpype.JClass("java.util.IdentityHashMap")


def slide_index(presentation, slide):
    for index, candidate in enumerate(presentation.getSlides(), start=1):
        if candidate == slide:
            return index
    return None


def is_https(value):
    if not value:
        return False
    value = str(value)
    if any(character.isspace() or ord(character) < 32 for character in value):
        return False
    try:
        uri = urlsplit(value)
        return uri.scheme.lower() == "https" and bool(uri.hostname)
    except ValueError:
        return False


def policy_violation(link):
    if link is None:
        return None
    if link.getActionType() == HyperlinkActionType.JumpSpecificSlide:
        return "Missing target slide" if link.getTargetSlide() is None else None
    if link.getActionType() != HyperlinkActionType.Hyperlink:
        return "Action is not allowed"
    if not is_https(link.getExternalUrl()):
        return "Normalized URL is not absolute HTTPS"
    original = link.getExternalUrlOriginal()
    if original and not is_https(original):
        return "Original URL is not absolute HTTPS"
    return None


def collect_containers(presentation):
    found = list(presentation.getHyperlinkQueries().getAnyHyperlinks())
    scopes = list(presentation.getMasters()) + list(presentation.getLayoutSlides())
    for slide in presentation.getSlides():
        scopes.append(slide.getNotesSlideManager().getNotesSlide())
    scopes.append(presentation.getMasterNotesSlideManager().getMasterNotesSlide())
    scopes.append(presentation.getMasterHandoutSlideManager().getMasterHandoutSlide())
    for scope in scopes:
        if scope is not None:
            found.extend(scope.getHyperlinkQueries().getAnyHyperlinks())
    seen = IdentityHashMap()
    unique = []
    for container in found:
        if not seen.containsKey(container):
            seen.put(container, True)
            unique.append(container)
    return unique


def text_or_none(value):
    return str(value) if value is not None else None


def add_row(rows, presentation, link, activation, container, container_id):
    if link is None:
        return
    owner_slide = container.getSlide() if hasattr(container, "getSlide") else None
    target_slide = link.getTargetSlide()
    violation = policy_violation(link)
    if isinstance(container, Shape):
        owner_type = "Shape"
    elif isinstance(container, PortionFormat):
        owner_type = "Text portion"
    else:
        owner_type = str(container.getClass().getSimpleName())
    ordinary_action = link.getActionType() in (HyperlinkActionType.Hyperlink, HyperlinkActionType.JumpSpecificSlide)
    original = link.getExternalUrlOriginal()
    rows.append({
        "ContainerId": container_id,
        "SlideIndex": slide_index(presentation, owner_slide),
        "SlideId": int(owner_slide.getSlideId()) if owner_slide is not None else None,
        "Scope": str(owner_slide.getClass().getSimpleName()) if owner_slide is not None else None,
        "OwnerType": owner_type,
        "Activation": activation,
        "ActionType": int(link.getActionType()),
        "ExternalUrl": text_or_none(link.getExternalUrl()),
        "TargetSlideIndex": slide_index(presentation, target_slide),
        "TargetSlideId": int(target_slide.getSlideId()) if target_slide is not None else None,
        "Tooltip": text_or_none(link.getTooltip()),
        "OriginalExternalUrl": text_or_none(original) if original != link.getExternalUrl() else None,
        "PotentiallyUnsafe": violation is not None,
        "PolicyViolation": violation,
        "TargetExport": "PDF",
        "PotentiallyUnsupportedByExport": activation == "mouse-over" or not ordinary_action,
    })


replace_external_clicks = True
replacement_url = "https://example.com/blocked-link"
presentation = Presentation("hyperlink-audit-input.pptx")
try:
    containers = collect_containers(presentation)
    rows = []
    for container_id, container in enumerate(containers, start=1):
        add_row(rows, presentation, container.getHyperlinkClick(), "click", container, container_id)
        add_row(rows, presentation, container.getHyperlinkMouseOver(), "mouse-over", container, container_id)
    report = json.dumps(rows, indent=2)
    Path("hyperlink-audit.json").write_text(report, encoding="utf-8")

    for container in containers:
        click = container.getHyperlinkClick()
        if policy_violation(click) is not None:
            if replace_external_clicks and click.getActionType() == HyperlinkActionType.Hyperlink:
                container.getHyperlinkManager().setExternalHyperlinkClick(replacement_url)
            else:
                container.getHyperlinkManager().removeHyperlinkClick()
        if policy_violation(container.getHyperlinkMouseOver()) is not None:
            container.getHyperlinkManager().removeHyperlinkMouseOver()
    presentation.save("hyperlink-sanitized.pptx", SaveFormat.Pptx)

    reopened = Presentation("hyperlink-sanitized.pptx")
    try:
        remaining_containers = collect_containers(reopened)
        violations = 0
        for container in remaining_containers:
            if policy_violation(container.getHyperlinkClick()) is not None:
                violations += 1
            if policy_violation(container.getHyperlinkMouseOver()) is not None:
                violations += 1
        print(f"Audit rows: {len(rows)}; prohibited actions after reopening: {violations}")
        if violations != 0:
            print("Verification failed: do not distribute the saved presentation.")
    finally:
        reopened.dispose()
except OSError as exception:
    print(f"Unable to write the audit report: {exception}")
finally:
    presentation.dispose()
```

उपर्युक्त इनपुट के साथ, रिपोर्ट में पाँच कार्रवाई पंक्तियाँ होती हैं। फ़ाइल माउस‑ओवर लिंक और मैक्रो क्लिक हटाए जाते हैं, जबकि HTTPS लिंक और आंतरिक स्लाइड नेविगेशन बना रहता है। सत्यापन शून्य प्रतिबंधित कार्रवाई प्रिंट करता है। प्रतिबंधित बाहरी क्लिक URL वाला इनपुट प्रतिस्थापन शाखा को भी सक्रिय करता है। अनुमत क्लिक और प्रतिबंधित माउस‑ओवर वाले कंटेनर अपनी क्लिक कार्रवाई बनाये रखते हैं।

यह चयनात्मक सफ़ाई [removeAllHyperlinks](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#removeAllHyperlinks) से अलग है, जो नीति की परवाह किए बिना चयनित स्कोप में दोनों सक्रियता प्रकारों को हटाता है। यहाँ सत्यापन केवल हाइपरलिंक कार्रवाइयों की जाँच करता है; यह एम्बेडेड VBA प्रोजेक्ट, OLE ऑब्जेक्ट, या अन्य सक्रिय सामग्री को नहीं हटाता, और न ही निर्यातित PDF या HTML फ़ाइल की वैधता की जाँच करता है।

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं किसी सेक्शन या उसकी पहली स्लाइड से कैसे लिंक कर सकता हूँ?**

PowerPoint में सेक्शन स्लाइड को समूहित करते हैं, लेकिन आंतरिक हाइपरलिंक एक व्यक्तिगत स्लाइड को लक्षित करता है। सेक्शन पर नेविगेशन बनाने के लिए, उस सेक्शन की पहली स्लाइड से लिंक करें।

**क्या मैं मास्टर स्लाइड तत्वों पर हाइपरलिंक संलग्न कर सकता हूँ ताकि वह सभी स्लाइड पर काम करे?**

हाँ। मास्टर स्लाइड और लेआउट तत्व हाइपरलिंक का समर्थन करते हैं। इन तत्वों पर लिंक स्लाइड शो के दौरान उन स्लाइडों पर उपलब्ध होते हैं जो संबंधित मास्टर या लेआउट का उपयोग करती हैं।

**PDF, HTML, इमेज या वीडियो में निर्यात करते समय हाइपरलिंक बरकरार रहेंगे?**

समर्थित PDF और HTML निर्यात हाइपरलिंक को बरकरार रख सकते हैं; रास्टर इमेज और वीडियो इंटरैक्टिव हाइपरलिंक नहीं रख सकते।詳細 के लिए देखें [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks)।