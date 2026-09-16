---
title: Python के जरिए Java में प्रस्तुति हाइपरलिंक का प्रबंधन
linktitle: हाइपरलिंक प्रबंधित करें
type: docs
weight: 20
url: /hi/python-java/manage-hyperlinks/
keywords:
- URL जोड़ें
- हाइपरलिंक जोड़ें
- हाइपरलिंक बनाएं
- हाइपरलिंक फ़ॉर्मेट करें
- हाइپرलिंक हटाएँ
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
- Java
- Aspose.Slides
description: "Python के लिए Aspose.Slides (Java द्वारा) के साथ PowerPoint और OpenDocument प्रस्तुतियों में हाइपरलिंक जोड़ें, फ़ॉर्मेट करें, अपडेट करें और हटाएँ, Python उदाहरणों का उपयोग करते हुए।"
---
## **परिचय**

हाइपरलिंक प्रस्तुति सामग्री को एक वेबसाइट या प्रस्तुति के भीतर किसी स्थान से जोड़ता है। PowerPoint में, हाइपरलिंक आमतौर पर दो उद्देश्यों की पूर्ति करता है:
* पाठ, आकार, या मीडिया फ्रेम से वेबसाइट खोलें।
* किसी अन्य स्लाइड पर नेविगेट करें, उदाहरण के लिए, सामग्री सूची से।

Aspose.Slides for Python via Java आपको इन लिंक को जोड़ने, उनकी उपस्थिति और ध्वनि को नियंत्रित करने, उनकी गुणों को अपडेट करने और उन्हें हटाने की अनुमति देता है। नीचे दिए गए उदाहरण दिखाते हैं कि व्यक्तिगत तत्वों पर हाइपरलिंक के साथ कैसे काम किया जाए और प्रस्तुति, स्लाइड या टेक्स्ट-फ़्रेम स्तर पर हाइपरलिंक तक कैसे पहुंचा जाए।

{{% alert color="info" title="Note" %}}
आप प्रस्तुति को [नि:शुल्क ऑनलाइन Aspose PowerPoint संपादक](https://products.aspose.app/slides/hi/editor) के साथ भी संपादित कर सकते हैं।
{{% /alert %}} 

## **URL हाइपरलिंक जोड़ें**

आप वेबसाइट URL को पाठ, आकार या मीडिया फ्रेम को असाइन कर सकते हैं। हाइपरलिंक को जिस तत्व पर असाइन किया जाता है, वह क्लिकेबल क्षेत्र निर्धारित करता है: पाठ का हिस्सा चयनित पाठ से लिंक करता है, जबकि आकार या फ्रेम स्लाइड वस्तु से लिंक करता है।

### **पाठ में URL हाइपरलिंक जोड़ें**

पाठ को वेबसाइट से लिंक करने के लिए, नीचे दिखाए अनुसार टेक्स्ट हिस्से की [setHyperlinkClick](https://reference.aspose.com/slides/hi/python-java/aspose.slides/portionformat/#setHyperlinkClick) मेथड में एक [Hyperlink](https://reference.aspose.com/slides/hi/python-java/aspose.slides/hyperlink/) पास करें। केवल वही पाठ भाग क्लिकेबल हो जाएगा।

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

### **आकार और मीडिया फ्रेम में URL हाइपरलिंक जोड़ें**

एक आकार या फ्रेम को क्लिकेबल बनाने के लिए, उसकी [setHyperlinkClick](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shape/#setHyperlinkClick) मेथड को कॉल करें। हाइपरलिंक वस्तु स्वयं से जुड़ा होता है, न कि उसके भीतर के किसी पाठ भाग से।

इसी दृष्टिकोण को चित्र, ऑडियो और वीडियो फ्रेम पर भी लागू किया जा सकता है: हाइपरलिंक को फ्रेम को असाइन करें और आवश्यकता पड़ने पर [setTooltip](https://reference.aspose.com/slides/hi/python-java/aspose.slides/hyperlink/#setTooltip) को कॉल करें।

निम्नलिखित उदाहरण एक आयत को क्लिकेबल बनाता है:

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

आंतरिक हाइपरलिंक पाठकों को सामग्री तालिका से किसी विशिष्ट स्लाइड पर कूदने की अनुमति देते हैं। निम्न उदाहरण [setInternalHyperlinkClick](https://reference.aspose.com/slides/hi/python-java/aspose.slides/hyperlinkmanager/#setInternalHyperlinkClick) का उपयोग करके पहली स्लाइड पर “Page 2” पाठ को दूसरी स्लाइड से जोड़ता है।

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

## **हाइपरलिंक स्वरूपित करें**

### **रंग**

हाइपरलिंक का [setColorSource](https://reference.aspose.com/slides/hi/python-java/aspose.slides/hyperlink/#setColorSource) मेथड यह निर्धारित करता है कि हाइपरलिंक प्रस्तुति के हाइपरलिंक रंग को उपयोग करता है या पाठ भाग के फ़ॉर्मेट को। कस्टम टेक्स्ट रंग लागू करने के लिए, [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/hyperlinkcolorsource/) चुनें और भाग की फ़िल रंग सेट करें। यह सुविधा PowerPoint 2019 में पेश की गई थी; पुराने संस्करण इस सेटिंग को लागू नहीं करते।

निम्न उदाहरण एक ही स्लाइड में दो टेक्स्ट हाइपरलिंक जोड़ता है। पहला लाल टेक्स्ट फ़िल का उपयोग करता है, जबकि दूसरा डिफ़ॉल्ट हाइपरलिंक रंग को बरकरार रखता है।

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

हाइपरलिंक सक्रिय होने पर ध्वनि बजा सकता है या पहले से चल रही ध्वनि को रोक सकता है। इन व्यवहारों को कॉन्फ़िगर करने के लिए निम्न मेथड्स का उपयोग करें:
- [Hyperlink.setSound](https://reference.aspose.com/slides/hi/python-java/aspose.slides/hyperlink/#setSound) हाइपरलिंक से जुड़ी ऑडियो निर्दिष्ट करता है।
- [Hyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/hi/python-java/aspose.slides/hyperlink/#setStopSoundOnClick) नियंत्रित करता है कि हाइपरलिंक सक्रिय करने पर पिछली ध्वनि रोकें या नहीं।

#### **हाइपरलिंक ध्वनि जोड़ें**

निम्न उदाहरण `sampleaudio.wav` को लोड करता है और इसे पहली स्लाइड पर एक बटन के साथ जोड़ता है। बटन पर क्लिक करने से ध्वनि बजती है और अगली स्लाइड पर नेविगेट किया जाता है। उसी स्लाइड पर दूसरा आकार क्लिक करने पर पिछली ध्वनि को रोकता है, बिना नेविगेशन कार्रवाई किए।

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

निम्न उदाहरण ऊपर बनाई गई प्रस्तुति को खोलता है और पहले आकार की हाइपरलिंक ऑडियो को [getSound](https://reference.aspose.com/slides/hi/python-java/aspose.slides/hyperlink/#getSound) और [getBinaryData](https://reference.aspose.com/slides/hi/python-java/aspose.slides/audio/#getBinaryData) के माध्यम से मेमोरी में पढ़ता है।

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

आप टेक्स्ट या आकार को हाइपरलिंक असाइन करने के बाद निम्न [Hyperlink](https://reference.aspose.com/slides/hi/python-java/aspose.slides/hyperlink/) मेथड्स को कॉल कर सकते हैं:
- [setTooltip](https://reference.aspose.com/slides/hi/python-java/aspose.slides/hyperlink/#setTooltip) वह टेक्स्ट सेट करता है जिसे दर्शक लिंक के संकेत के रूप में दिखा सकता है।
- [setTargetFrame](https://reference.aspose.com/slides/hi/python-java/aspose.slides/hyperlink/#setTargetFrame) लागू होने पर पैरेंट HTML फ्रेमसेट के भीतर लक्ष्य फ्रेम निर्धारित करता है।
- [setHistory](https://reference.aspose.com/slides/hi/python-java/aspose.slides/hyperlink/#setHistory) नियंत्रित करता है कि लिंक सक्रिय करने पर उसका गंतव्य देखे गए हाइपरलिंक की सूची में जोड़ा जाए या नहीं।
- [setHighlightClick](https://reference.aspose.com/slides/hi/python-java/aspose.slides/hyperlink/#setHighlightClick) निर्धारित करता है कि क्लिक करने पर हाइपरलिंक हाइलाइट हो या नहीं।

## **प्रस्तुति से हाइपरलिंक हटाएं**

परिवर्तनों से पहले हाइपरलिंक कंटेनर, जिसमें टेक्स्ट-भाग लिंक भी शामिल हैं, एकत्र करने के लिए [getAnyHyperlinks](https://reference.aspose.com/slides/hi/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks) का उपयोग करें। नीचे दिया गया उदाहरण पहली स्लाइड से दोनों सक्रियता प्रकार हटाता है। केवल एक प्रकार हटाने के लिए, केवल [removeHyperlinkClick](https://reference.aspose.com/slides/hi/python-java/aspose.slides/hyperlinkmanager/#removeHyperlinkClick) या [removeHyperlinkMouseOver](https://reference.aspose.com/slides/hi/python-java/aspose.slides/hyperlinkmanager/#removeHyperlinkMouseOver) को कॉल करें; क्लिक कार्रवाई हटाने से उसकी माउस-ओवर समकक्ष नहीं हटेगी।

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

निर्विवाद हटाने के लिए, [removeAllHyperlinks](https://reference.aspose.com/slides/hi/python-java/aspose.slides/hyperlinkqueries/#removeAllHyperlinks) चयनित स्कोप में एक कॉल में दोनों सक्रियता प्रकार हटा देता है। चयनात्मक सफ़ाई और मास्टर, लेआउट और नोट्स को कवर करने के लिए, देखें [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks)।

## **एक पूर्ण हाइपरलिंक इन्वेंटरी बनाएं**

एक प्रस्तुति वितरित करने से पहले, उसकी इंटरैक्टिव कार्रवाइयों और वेब लिंक का इन्वेंटरी बनाएं। [getAnyHyperlinks](https://reference.aspose.com/slides/hi/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks) हाइपरलिंक कंटेनर लौटाता है, जैसे कि [Shape](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shape/) और [PortionFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/portionformat/) ऑब्जेक्ट, न कि URL स्ट्रिंग की फ्लैट लिस्ट। प्रत्येक कंटेनर पर दोनों [getHyperlinkClick](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shape/#getHyperlinkClick) और [getHyperlinkMouseOver](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shape/#getHyperlinkMouseOver) को निरीक्षण करें। वे स्वतंत्र हैं: समान कंटेनर दोनों कार्रवाइयाँ दिखा सकता है, इसलिए एक पूर्ण रिपोर्ट को प्रति कंटेनर दो पंक्तियों तक की आवश्यकता हो सकती है।

केवल आकार-स्तर के हाइपरलिंक स्कैन करने से टेक्स्ट भाग से जुड़े लिंक मिस हो सकते हैं। इसके बजाय उपयुक्त स्कोप को क्वेरी करें, और लौटाए गए कंटेनरों को रखें ताकि बाद में आप उनकी कार्रवाइयों को अपडेट या हटाने के लिए उपयोग कर सकें।

### **प्रस्तुति, स्लाइड और टेक्स्ट-फ़्रेम स्कोप क्वेरी करें**

[HyperlinkQueries](https://reference.aspose.com/slides/hi/python-java/aspose.slides/hyperlinkqueries/) क्लास निम्न के माध्यम से उपलब्ध है: [Presentation.getHyperlinkQueries](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#getHyperlinkQueries), [BaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/hi/python-java/aspose.slides/baseslide/#getHyperlinkQueries), और [TextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/hi/python-java/aspose.slides/textframe/#getHyperlinkQueries)। प्रत्येक स्कोप समान क्वेरीज़ का समर्थन करता है:
- [getHyperlinkClicks](https://reference.aspose.com/slides/hi/python-java/aspose.slides/hyperlinkqueries/#getHyperlinkClicks) क्लिक कार्रवाई वाले कंटेनर लौटाता है।
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/hi/python-java/aspose.slides/hyperlinkqueries/#getHyperlinkMouseOvers) माउस-ओवर कार्रवाई वाले कंटेनर लौटाता है।
- [getAnyHyperlinks](https://reference.aspose.com/slides/hi/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks) एक या दोनों कार्रवाई वाले कंटेनर लौटाता है।

निम्न उदाहरण `hyperlink-audit-input.pptx` बनाता है जिसमें एक बाहरी क्लिक लिंक, एक फ़ाइल माउस-ओवर लिंक, आंतरिक स्लाइड नेविगेशन, एक टेक्स्ट माउस-ओवर लिंक, और एक मैक्रो कार्रवाई शामिल है। यह इन में से कोई भी कार्रवाई निष्पादित नहीं करता। वही तीन क्वेरीज़ प्रत्येक स्कोप पर काम करती हैं; गणनाएँ कंटेनरों को दर्शाती हैं, न कि कार्रवाई कुल। टेक्स्ट-फ़्रेम स्कोप में घेरने वाले आकार के अपने लिंक को बाहर रखा जाता है।

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

इस उदाहरण के लिए, प्रस्तुति और स्लाइड क्वेरीज़ क्रमशः तीन क्लिक कंटेनर, दो माउस-ओवर कंटेनर, और एक या दोनों कार्रवाई वाले तीन कंटेनर रिपोर्ट करती हैं। टेक्स्ट-फ़्रेम क्वेरी प्रत्येक श्रेणी में एक कंटेनर रिपोर्ट करती है।

### **कार्रवाई और गंतव्य वर्गीकृत करें**

[Hyperlink.getActionType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/hyperlink/#getActionType) का उपयोग करके एक कार्रवाई को उसके गंतव्य को समझने से पहले व्याख्या करें। [HyperlinkActionType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/hyperlinkactiontype/) मान वेब नेविगेशन से अधिक को कवर करते हैं:

| मान | ऑडिट के लिए अर्थ |
| --- | --- |
| `Hyperlink` | बाहरी हाइपरलिंक; URL और उसके स्कीम की जाँच करें। |
| `JumpSpecificSlide` | किसी विशेष स्लाइड पर आंतरिक नेविगेशन। |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | निर्मित स्लाइडशो नेविगेशन, स्लाइडशो संदर्भ में हल किया जाता है। |
| `JumpEndShow`, `StartCustomSlideShow` | वर्तमान शो को समाप्त करें या एक कस्टम शो शुरू करें। |
| `StartMacro` | एक मैक्रो निष्पादित करें। |
| `StartProgram` | एक प्रोग्राम लॉन्च करें। |
| `OpenFile`, `OpenPresentation` | फ़ाइल या अन्य प्रस्तुति खोलें; वेब URL से अलग समीक्षा करें। |
| `StartStopMedia` | मीडिया प्लेबैक शुरू या रोकें। |
| `NoAction`, `Unknown` | कोई नेविगेशन कार्रवाई नहीं, या अज्ञात कार्रवाई जो समीक्षा की आवश्यकता रखती है। |

बाहरी गंतव्य को [getExternalUrl](https://reference.aspose.com/slides/hi/python-java/aspose.slides/hyperlink/#getExternalUrl) से पढ़ें और विशिष्ट आंतरिक गंतव्य को [getTargetSlide](https://reference.aspose.com/slides/hi/python-java/aspose.slides/hyperlink/#getTargetSlide) से पढ़ें। आंतरिक कार्रवाइयों और निर्मित कमांड में बाहरी URL नहीं हो सकता; खाली URL यह नहीं दर्शाता कि कंटेनर में कोई कार्रवाई नहीं है। जब [getExternalUrlOriginal](https://reference.aspose.com/slides/hi/python-java/aspose.slides/hyperlink/#getExternalUrlOriginal) द्वारा लौटाई गई मान सामान्यीकृत URL से भिन्न हो, तो उसे संरक्षित रखें, और उपलब्ध होने पर [getTooltip](https://reference.aspose.com/slides/hi/python-java/aspose.slides/hyperlink/#getTooltip) द्वारा लौटाया गया टूलटिप शामिल करें।

### **हाइपरलिंक की रिपोर्ट, सफ़ाई, और सत्यापन**

निम्न Python उदाहरण एक मौजूदा प्रस्तुति पढ़ता है (ऊपर बनाई गई फ़ाइल का उपयोग करें), `hyperlink-audit.json` लिखता है, एक नीति लागू करता है, `hyperlink-sanitized.pptx` को सहेजता है, और दोनों सक्रियता प्रकारों को फिर से जांचने के लिए उसे पुनः खोलता है। यह परिवर्तनों से पहले कंटेनर एकत्र करता है और संदर्भ समानता का उपयोग करके एक ही कंटेनर को दो बार प्रोसेस होने से बचाता है। प्रस्तुति क्वेरीज़ सामान्य स्लाइडों को कवर करती हैं; पैकेज-व्यापी इन्वेंटरी के लिए, यह स्पष्ट रूप से मास्टर, लेआउट, नोट्स, तथा नोट्स और हैंडआउट मास्टर को भी क्वेरी करता है जब वे मौजूद हों।

रिपोर्ट एक-आधारित स्लाइड इंडेक्स और जहाँ उपलब्ध हो [getSlideId](https://reference.aspose.com/slides/hi/python-java/aspose.slides/baseslide/#getSlideId) को रिकॉर्ड करती है। [getSlide](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shape/#getSlide) समर्थित कंटेनरों के लिए मालिक स्लाइड प्रदान करता है। मास्टर, लेआउट और नोट्स का कोई सामान्य स्लाइड इंडेक्स नहीं होता और उन्हें उनके स्कोप से पहचाना जाता है। आकार कंटेनर और टेक्स्ट-भाग फ़ॉर्मेटिंग कंटेनर अलग से लेबल किए जाते हैं; अन्य कंटेनर प्रकार अपना रनटाइम टाइप नाम बनाए रखते हैं। प्रत्येक कंटेनर को रिपोर्ट-लोकल ID मिलती है जिससे उसकी दो कार्रवाइयों को संबंधित किया जा सके। रिपोर्ट कार्रवाई प्रकारों को जावा एन्यूमेरेशन द्वारा परिभाषित पूर्णांक स्थिरांक के रूप में संग्रहीत करती है।

यह जानबूझकर प्रतिबंधात्मक अनुप्रयोग नीति केवल पूर्ण HTTPS URL और वैध आंतरिक स्लाइड लक्ष्य की अनुमति देती है। यह मैक्रो, प्रोग्राम, फ़ाइल कार्रवाइयों, अन्य स्लाइडशो कार्रवाइयों, अज्ञात कार्रवाइयों और अन्य URL स्कीम को अस्वीकार करता है। ये अस्वीकृतियां नीति निर्णय हैं, न कि Aspose.Slides सुरक्षा निर्णय। केवल HTTPS भरोसा स्थापित नहीं करता: अपने अनुप्रयोग के लिए होस्ट अनुमति सूचियों और अन्य जांचें जोड़ें। मूल और सामान्यीकृत दोनों बाहरी URL जांचे जाते हैं। उदाहरण लिंक का अनुसरण किए बिना या कार्रवाइयों को चलाए बिना मेटाडेटा का ऑडिट करता है।

सुधार के लिए, कंटेनर का [getHyperlinkManager](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shape/#getHyperlinkManager) [setExternalHyperlinkClick](https://reference.aspose.com/slides/hi/python-java/aspose.slides/hyperlinkmanager/#setExternalHyperlinkClick), [removeHyperlinkClick](https://reference.aspose.com/slides/hi/python-java/aspose.slides/hyperlinkmanager/#removeHyperlinkClick), और [removeHyperlinkMouseOver](https://reference.aspose.com/slides/hi/python-java/aspose.slides/hyperlinkmanager/#removeHyperlinkMouseOver) को सपोर्ट करता है। यहाँ, प्रतिबंधित बाहरी क्लिक लिंक को एक निश्चित HTTPS लैंडिंग पेज से बदला जाता है; अन्य प्रतिबंधित क्लिक और माउस-ओवर कार्रवाइयों को स्वतंत्र रूप से हटाया जाता है। सभी नीति उल्लंघनों को हटाने के लिए `replace_external_clicks` को `False` सेट करें। परिनियोजन से पहले एक एप्लिकेशन-स्वामित्व वाला प्रतिस्थापन पेज चुनें।

रिपोर्ट का एक्सपोर्ट फ़्लैग एक रूढ़िवादी PDF समीक्षा नीति का उपयोग करता है: माउस-ओवर कार्रवाइयों और बाहरी लिंक या विशिष्ट स्लाइड कूद के अलावा किसी भी चीज़ को संभावित रूप से असमर्थित के रूप में चिन्हित करें। यह एक समीक्षा संकेत है, न कि क्षमता परीक्षण या यह गारंटी कि बिना चिन्हित लिंक निर्यात में टिकेंगे। समर्थित [PDF](/slides/hi/python-java/convert-powerpoint-to-pdf/) और [HTML](/slides/hi/python-java/convert-powerpoint-to-html/) निर्यात हाइपरलिंक को संरक्षित कर सकते हैं, कार्रवाई, निर्यात विकल्प और दर्शक पर निर्भर करता है। रास्टर [images](/slides/hi/python-java/convert-powerpoint-to-png/) और [video](/slides/hi/python-java/convert-powerpoint-to-video/) इंटरैक्टिव हाइपरलिंक को संरक्षित नहीं कर सकते; उन आउटपुट के लिए ऑडिट करते समय हर कार्रवाई को चिन्हित करें।

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

ऊपर बनाए गए इनपुट के साथ, रिपोर्ट में पाँच कार्रवाई पंक्तियाँ हैं। फ़ाइल माउस-ओवर लिंक और मैक्रो क्लिक हटाए गए हैं, जबकि HTTPS लिंक और आंतरिक स्लाइड नेविगेशन बना रहता है। सत्यापन शून्य प्रतिबंधित कार्रवाइयाँ प्रिंट करता है। प्रतिबंधित बाहरी क्लिक URL वाला इनपुट भी प्रतिस्थापन शाखा को सक्रिय करता है। अनुमति दिए गए क्लिक और प्रतिबंधित माउस-ओवर वाला कंटेनर अपना क्लिक कार्य रखता है।

यह चयनात्मक सफ़ाई [removeAllHyperlinks](https://reference.aspose.com/slides/hi/python-java/aspose.slides/hyperlinkqueries/#removeAllHyperlinks) से भिन्न है, जो नीति की परवाह किए बिना चयनित स्कोप में दोनों सक्रियता प्रकारों को हटाता है। यहाँ सत्यापन केवल हाइपरलिंक कार्रवाइयों की जाँच करता है; यह एम्बेडेड VBA प्रोजेक्ट, OLE ऑब्जेक्ट या अन्य सक्रिय सामग्री को नहीं हटाता, और न ही निर्यातित PDF या HTML फ़ाइल की वैधता जाँचता है।

## **अक्सर पूछे जाने वाले प्रश्न**

**सेक्शन या उसकी पहली स्लाइड से कैसे लिंक करूँ?**

PowerPoint में सेक्शन स्लाइडों को समूहित करते हैं, लेकिन एक आंतरिक हाइपरलिंक व्यक्तिगत स्लाइड को लक्षित करता है। सेक्शन में नेविगेशन बनाने के लिए, उस सेक्शन की पहली स्लाइड से लिंक करें।

**क्या मैं मास्टर स्लाइड तत्वों पर हाइपरलिंक संलग्न कर सकता हूँ ताकि यह सभी स्लाइडों पर काम करे?**

हाँ। मास्टर स्लाइड और लेआउट तत्व हाइपरलिंक को सपोर्ट करते हैं। इन तत्वों पर लिंक उस स्लाइड शो में उपलब्ध होते हैं जहाँ संबंधित मास्टर या लेआउट का उपयोग किया गया हो।

**क्या PDF, HTML, इमेज या वीडियो में निर्यात करते समय हाइपरलिंक संरक्षित रहेंगे?**

समर्थित PDF और HTML निर्यात हाइपरलिंक को रख सकते हैं; रास्टर इमेज और वीडियो नहीं रख सकते। निर्यात संबंधी विचारों के लिए देखें [हाइपरलिंक की रिपोर्ट, सफ़ाई, और सत्यापन](#report-sanitize-and-verify-hyperlinks)।