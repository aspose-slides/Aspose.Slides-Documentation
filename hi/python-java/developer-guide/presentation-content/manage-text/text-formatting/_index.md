---
title: Python के माध्यम से Java में प्रस्तुति टेक्स्ट को फ़ॉर्मेट करें
linktitle: टेक्स्ट फ़ॉर्मेटिंग
type: docs
weight: 50
url: /hi/python-java/text-formatting/
keywords:
- पैराग्राफ संरेखित करें
- टेक्स्ट शैली
- टेक्स्ट पृष्ठभूमि
- टेक्स्ट पारदर्शिता
- अक्षर अंतराल
- फ़ॉन्ट गुण
- फ़ॉन्ट परिवार
- टेक्स्ट घूर्णन
- घूर्णन कोण
- टेक्स्ट फ्रेम
- लाइन स्पेसिंग
- ऑटोफ़िट गुण
- टेक्स्ट फ्रेम एंकर
- टेक्स्ट टैब्यूलेशन
- डिफ़ॉल्ट भाषा
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Java
- Aspose.Slides
description: "PowerPoint और OpenDocument प्रस्तुतियों में Aspose.Slides for Python via Java का उपयोग करके टेक्स्ट को फ़ॉर्मेट और स्टाइल करें। फ़ॉन्ट, रंग, संरेखण और अधिक को कस्टमाइज़ करें।"
---
## **अवलोकन**

यह लेख Aspose.Slides for Python via Java का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में टेक्स्ट को फ़ॉर्मेट करने की विधि दिखाता है। इसमें बैकग्राउंड रंग, ट्रांसपेरेंसी, अक्षर अंतराल, फ़ॉन्ट गुण, घूर्णन, पैराग्राफ अंतराल, ऑटोफ़िट व्यवहार, टेक्स्ट एंकरिंग, टैब स्टॉप और भाषा सेटिंग्स शामिल हैं।

नीचे के उदाहरणों में, हम “sample.pptx” नामक फ़ाइल का उपयोग करेंगे, जिसमें पहली स्लाइड पर एकल टेक्स्ट बॉक्स है और उसमें निम्नलिखित टेक्स्ट है:

![Sample text](sample_text.png)

सटीक टेक्स्ट या रेगुलर एक्सप्रेशन मिलानों को खोजने और हाइलाइट करने के लिए, देखें [Search and Replace Text](/slides/hi/python-java/search-and-replace-text/)।

## **टेक्स्ट बैकग्राउंड रंग सेट करें**

डिफ़ॉल्ट पैराग्राफ हाइलाइट रंग सेट करने के लिए [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) का उपयोग करें, या व्यक्तिगत टेक्स्ट भागों के लिए [PortionFormat.getHighlightColor](https://reference.aspose.com/slides/hi/python-java/aspose.slides/portionformat/) का उपयोग करें।

निम्न कोड उदाहरण दिखाता है कि **पूरे पैराग्राफ** का बैकग्राउंड रंग कैसे सेट किया जाए:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat
from java.awt import Color

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    #   पूरे पैराग्राफ के लिए हाइलाइट रंग सेट करें।
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY)

    presentation.save("gray_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

परिणाम:

![The gray paragraph](gray_paragraph.png)

नीचे का कोड उदाहरण दिखाता है कि **बोल्ड फ़ॉन्ट वाले टेक्स्ट भागों** का बैकग्राउंड रंग कैसे सेट किया जाए:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat
from java.awt import Color

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    for portion in paragraph.getPortions():
        if portion.getPortionFormat().getEffective().getFontBold():
            # टेक्स्ट भाग के लिए हाइलाइट रंग सेट करें।
            portion.getPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY)

    presentation.save("gray_text_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

परिणाम:

![The gray text portions](gray_text_portions.png)

## **पैराग्राफ टेक्स्ट को संरेखित करें**

टेक्स्ट फ्रेम के भीतर पैराग्राफ संरेखण सेट करने के लिए [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/hi/python-java/aspose.slides/paragraphformat/#setAlignment) का उपयोग करें। मान केंद्रित, बायाँ-संरेखित, दायाँ-संरेखित, जस्टिफाइड आदि हो सकते हैं।

निम्न कोड उदाहरण दिखाता है कि पैराग्राफ को **केंद्र** में कैसे संरेखित किया जाए:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TextAlignment

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    #    पैराग्राफ का संरेखण केंद्र में सेट करें।
    paragraph.getParagraphFormat().setAlignment(TextAlignment.Center)

    presentation.save("aligned_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

परिणाम:

![The aligned paragraph](aligned_paragraph.png)

## **टेक्स्ट की ट्रांसपेरेंसी सेट करें**

टेक्स्ट की ट्रांसपेरेंसी [PortionFormat.getFillFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/portionformat/) को असाइन किए गए रंग के अल्फा घटक द्वारा नियंत्रित होती है। नीचे के उदाहरणों में, `alpha = 50` 0–255 स्केल पर एक ARGB अल्फा‑चैनल मान है, प्रतिशत नहीं।

निम्न कोड उदाहरण दिखाता है कि **पूरे पैराग्राफ** की ट्रांसपेरेंसी कैसे लागू की जाए:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

alpha = 50
text_color = Color(0, 0, 0, alpha)

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    #    टेक्स्ट का फिल रंग पारदर्शी रंग में सेट करें।
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(text_color)

    presentation.save("transparent_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

परिणाम:

![The transparent paragraph](transparent_paragraph.png)

निम्न कोड उदाहरण दिखाता है कि **बोल्ड फ़ॉन्ट वाले टेक्स्ट भागों** की ट्रांसपेरेंसी कैसे लागू की जाए:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

alpha = 50
text_color = Color(0, 0, 0, alpha)

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    for portion in paragraph.getPortions():
        if portion.getPortionFormat().getEffective().getFontBold():
            # टेक्स्ट भाग की पारदर्शिता सेट करें।
            portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
            portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(text_color)

    presentation.save("transparent_text_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

परिणाम:

![The transparent text portions](transparent_text_portions.png)

## **टेक्स्ट के अक्षर अंतराल को सेट करें**

टेक्स्ट बॉक्स में अक्षरों के बीच अंतराल बढ़ाने या घटाने के लिए [PortionFormat.setSpacing](https://reference.aspose.com/slides/hi/python-java/aspose.slides/portionformat/) का उपयोग करें।

निम्न Python कोड दिखाता है कि **पूरे पैराग्राफ** में अक्षर अंतराल कैसे बढ़ाया जाए:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # ध्यान दें: अक्षर अंतराल को संकुचित करने के लिए नकारात्मक मानों का उपयोग करें।
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3) # अक्षर अंतराल बढ़ाएँ।

    presentation.save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

परिणाम:

![The character spacing in the paragraph](character_spacing_in_paragraph.png)

निम्न कोड उदाहरण दिखाता है कि **बोल्ड फ़ॉन्ट वाले टेक्स्ट भागों** में अक्षर अंतराल कैसे बढ़ाया जाए:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    for portion in paragraph.getPortions():
        if portion.getPortionFormat().getEffective().getFontBold():
            # नोट: अक्षर अंतराल को संकुचित करने के लिए नकारात्मक मानों का उपयोग करें।
            portion.getPortionFormat().setSpacing(3) # अक्षर अंतराल बढ़ाएँ।

    presentation.save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

परिणाम:

![The character spacing in the text portions](character_spacing_in_text_portions.png)

### **विशिष्ट फ़ॉन्ट्स के लिए करनिंग निष्क्रिय करें**

कुछ मामलों में Aspose.Slides द्वारा रेंडर किया गया टेक्स्ट PowerPoint में दिखाए गए टेक्स्ट से थोड़ा अधिक तंग लग सकता है। यह इसलिए हो सकता है क्योंकि PowerPoint कुछ फ़ॉन्ट्स के लिए करनिंग डेटा को अनदेखा कर देता है, भले ही फ़ॉन्ट में वैध करनिंग जानकारी हो और PowerPoint सेटिंग्स में करनिंग सक्षम हो।

ऐसे मामलों में रेंडर आउटपुट को PowerPoint जैसा बनाने के लिए आप प्रभावित फ़ॉन्ट वाले टेक्स्ट भागों के लिए करनिंग निष्क्रिय कर सकते हैं। [PortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/hi/python-java/aspose.slides/portionformat/) को वास्तविक फ़ॉन्ट आकार से कई गुना बड़े मान पर सेट करें:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().get_Item(0)
    target_font = "Roboto"

    for paragraph in auto_shape.getTextFrame().getParagraphs():
        for portion in paragraph.getPortions():
            portion_format = portion.getPortionFormat()
            fonts = (portion_format.getLatinFont(), portion_format.getEastAsianFont(), portion_format.getComplexScriptFont())
            if any(font is not None and font.getFontName() == target_font for font in fonts):
                portion_format.setKerningMinimalSize(100)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

यह सेटिंग मेल खाने वाले टेक्स्ट भागों पर करनिंग को लागू होने से रोकती है और इस PowerPoint‑विशिष्ट व्यवहार से प्रभावित फ़ॉन्ट्स के लिए Aspose.Slides रेंडरिंग को PowerPoint के दृश्य आउटपुट के करीब लाने में मदद करती है।

## **टेक्स्ट फ़ॉन्ट गुण प्रबंधित करें**

फ़ॉन्ट गुण पैराग्राफ स्तर पर [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) के माध्यम से या व्यक्तिगत भागों पर [PortionFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/portionformat/) के माध्यम से सेट किए जा सकते हैं।

निम्न कोड पूरे पैराग्राफ के लिए फ़ॉन्ट और टेक्स्ट शैली सेट करता है: यह फ़ॉन्ट आकार, बोल्ड, इटैलिक, डॉटेड अंडरलाइन और Times New Roman फ़ॉन्ट को सभी भागों पर लागू करता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, NullableBool, Presentation, SaveFormat, TextUnderlineType

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # पैराग्राफ के लिए फ़ॉन्ट गुण सेट करें।
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(12)
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontBold(NullableBool.True_)
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontItalic(NullableBool.True_)
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontUnderline(TextUnderlineType.Dotted)
    font = FontData("Times New Roman")
    paragraph.getParagraphFormat().getDefaultPortionFormat().setLatinFont(font)

    presentation.save("font_properties_for_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

परिणाम:

![The font properties for the paragraph](font_properties_for_paragraph.png)

निम्न कोड उदाहरण **बोल्ड फ़ॉन्ट वाले टेक्स्ट भागों** पर समान गुण लागू करता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, NullableBool, Presentation, SaveFormat, TextUnderlineType

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    for portion in paragraph.getPortions():
        if portion.getPortionFormat().getEffective().getFontBold():
            # टेक्स्ट भाग के लिए फ़ॉन्ट गुण सेट करें।
            portion.getPortionFormat().setFontHeight(13)
            portion.getPortionFormat().setFontItalic(NullableBool.True_)
            portion.getPortionFormat().setFontUnderline(TextUnderlineType.Dotted)
            font = FontData("Times New Roman")
            portion.getPortionFormat().setLatinFont(font)

    presentation.save("font_properties_for_text_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

परिणाम:

![The font properties for text portions](font_properties_for_text_portions.png)

## **टेक्स्ट का घूर्णन सेट करें**

शेप के भीतर पूर्वनिर्धारित टेक्स्ट अभिविन्यास सेट करने के लिए [TextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/textframeformat/#setTextVerticalType) का उपयोग करें।

निम्न कोड उदाहरण टेक्स्ट अभिविन्यास को `Vertical270` पर सेट करता है, जिससे टेक्स्ट **90 डिग्री घड़ी की सूइयों के विपरीत दिशा में** घुम जाता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TextVerticalType

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().get_Item(0)

    auto_shape.getTextFrame().getTextFrameFormat().setTextVerticalType(TextVerticalType.Vertical270)

    presentation.save("text_rotation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

परिणाम:

![The text rotation](text_rotation.png)

## **टेक्स्ट फ्रेम के लिए कस्टम घूर्णन सेट करें**

[TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/hi/python-java/aspose.slides/textframeformat/#setRotationAngle) का उपयोग करके किसी [TextFrame](https://reference.aspose.com/slides/hi/python-java/aspose.slides/textframe/) के लिए कस्टम घूर्णन कोण सेट किया जा सकता है।

निम्न कोड उदाहरण टेक्स्ट फ्रेम को शेप के भीतर 3 डिग्री घड़ी की दिशा में घुमाता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().get_Item(0)

    auto_shape.getTextFrame().getTextFrameFormat().setRotationAngle(3)

    presentation.save("custom_text_rotation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

परिणाम:

![The custom text rotation](custom_text_rotation.png)

## **पैराग्राफ की लाइन स्पेसिंग सेट करें**

Aspose.Slides [ParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/hi/python-java/aspose.slides/paragraphformat/#setSpaceAfter), [ParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/hi/python-java/aspose.slides/paragraphformat/#setSpaceBefore) और [ParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/hi/python-java/aspose.slides/paragraphformat/#setSpaceWithin) प्रदान करता है ताकि पैराग्राफ स्पेसिंग को नियंत्रित किया जा सके। इन गुणों का उपयोग इस प्रकार किया जाता है:

* लाइन स्पेसिंग को लाइन की ऊँचाई के प्रतिशत के रूप में निर्दिष्ट करने के लिए सकारात्मक मान उपयोग करें।
* लाइन स्पेसिंग को पॉइंट्स में निर्दिष्ट करने के लिए नकारात्मक मान उपयोग करें।

निम्न कोड उदाहरण पैराग्राफ के भीतर लाइन स्पेसिंग निर्दिष्ट करता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    paragraph.getParagraphFormat().setSpaceWithin(200)

    presentation.save("line_spacing.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

परिणाम:

![The line spacing within the paragraph](line_spacing.png)

## **टेक्स्ट फ्रेम के लिए ऑटोफ़िट प्रकार सेट करें**

[TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/textframeformat/#setAutofitType) निर्धारित करता है कि टेक्स्ट कंटेनर की सीमाओं से अधिक होने पर कैसे व्यवहार करेगा। इसका उपयोग करके आप तय कर सकते हैं कि टेक्स्ट छोटा हो, ओवरफ़्लो हो या आकार बदलकर शेप को स्वतः समायोजित करे।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TextAutofitType

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().get_Item(0)

    auto_shape.getTextFrame().getTextFrameFormat().setAutofitType(TextAutofitType.Shape)

    presentation.save("autofit_type.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **टेक्स्ट फ्रेम का एंकर सेट करें**

[TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/textframeformat/#setAnchoringType) परिभाषित करता है कि टेक्स्ट शेप के भीतर ऊर्ध्वाधर रूप से कहाँ स्थित होगा, जैसे शीर्ष, मध्य या नीचे।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TextAnchorType

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().get_Item(0)

    auto_shape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Bottom)

    presentation.save("text_anchor.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **टेक्स्ट टैब्यूलेशन सेट करें**

पैराग्राफ में टैब स्टॉप कॉन्फ़िगर करने के लिए [ParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/hi/python-java/aspose.slides/paragraphformat/#setDefaultTabSize) और [ParagraphFormat.getTabs](https://reference.aspose.com/slides/hi/python-java/aspose.slides/paragraphformat/#getTabs) का उपयोग करें।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TabAlignment

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    paragraph.getParagraphFormat().setDefaultTabSize(100)
    paragraph.getParagraphFormat().getTabs().add(30, TabAlignment.Left)

    presentation.save("paragraph_tabs.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

परिणाम:

![The paragraph tabs](paragraph_tabs.png)

## **प्रूफिंग भाषा सेट करें**

Aspose.Slides [PortionFormat.setLanguageId](https://reference.aspose.com/slides/hi/python-java/aspose.slides/portionformat/) प्रदान करता है, जिससे आप किसी टेक्स्ट भाग के लिए प्रूफिंग भाषा सेट कर सकते हैं। प्रूफिंग भाषा PowerPoint में वर्तनी और व्याकरण जाँच के लिए उपयोग की जाने वाली भाषा निर्धारित करती है।

निम्न कोड उदाहरण दिखाता है कि टेक्स्ट भाग की प्रूफिंग भाषा कैसे सेट की जाए:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, Portion, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().get_Item(0)

    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)
    paragraph.getPortions().clear()

    font = FontData("SimSun")

    text_portion = Portion()
    text_portion.getPortionFormat().setComplexScriptFont(font)
    text_portion.getPortionFormat().setEastAsianFont(font)
    text_portion.getPortionFormat().setLatinFont(font)

    # प्रूफिंग भाषा का Id सेट करें।
    text_portion.getPortionFormat().setLanguageId("zh-CN")

    text_portion.setText("1。")
    paragraph.getPortions().add(text_portion)

    presentation.save("proofing_language.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **डिफ़ॉल्ट भाषा सेट करें**

लोडिंग या नई प्रस्तुति बनाते समय बनाए जाने वाले टेक्स्ट की डिफ़ॉल्ट भाषा निर्धारित करने के लिए [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/hi/python-java/aspose.slides/loadoptions/#setDefaultTextLanguage) का उपयोग करें।

```python
import jpide
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, ShapeType

load_options = LoadOptions()
load_options.setDefaultTextLanguage("en-US")

presentation = Presentation(load_options)
try:
    slide = presentation.getSlides().get_Item(0)

    #    टेक्स्ट के साथ एक आयताकार आकार जोड़ें।
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 50)
    shape.getTextFrame().setText("Sample text")

    #    पहले भाग की भाषा जाँचें।
    portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    print(portion.getPortionFormat().getLanguageId())
finally:
    presentation.dispose()
```

## **डिफ़ॉल्ट टेक्स्ट स्टाइल सेट करें**

प्रस्तुति स्तर पर डिफ़ॉल्ट टेक्स्ट फ़ॉर्मेटिंग लागू करने के लिए [Presentation.getDefaultTextStyle](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#getDefaultTextStyle) का उपयोग करें।

निम्न कोड उदाहरण दिखाता है कि सभी स्लाइड्स में नई प्रस्तुति के लिए 14 pt आकार का बोल्ड फ़ॉन्ट डिफ़ॉल्ट रूप से कैसे सेट किया जाए।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, Presentation, SaveFormat

presentation = Presentation()
try:
    # शीर्ष स्तर का पैराग्राफ फ़ॉर्मेट प्राप्त करें।
    paragraph_format = presentation.getDefaultTextStyle().getLevel(0)

    if paragraph_format is not None:
        paragraph_format.getDefaultPortionFormat().setFontHeight(14)
        paragraph_format.getDefaultPortionFormat().setFontBold(NullableBool.True_)

    presentation.save("default_text_style.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **ऑल‑कैप्स प्रभाव के साथ टेक्स्ट निकालें**

PowerPoint में **All Caps** फ़ॉन्ट प्रभाव लागू करने से टेक्स्ट स्लाइड पर बड़े अक्षरों में दिखाई देता है, भले ही वह मूल रूप से छोटे अक्षरों में टाइप किया गया हो। जब आप Aspose.Slides के साथ ऐसा टेक्स्ट भाग प्राप्त करते हैं, तो लाइब्रेरी वही टेक्स्ट लौटाती है जैसा वह दर्ज किया गया था। प्रदर्शित टेक्स्ट से मेल खाने के लिए, [TextCapType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/textcaptype/) की जाँच करें और जब मान `All` हो तो लौटाए गए स्ट्रिंग को बड़े अक्षरों में बदलें।

मान लीजिए हमारे पास sample2.pptx फ़ाइल की पहली स्लाइड पर निम्नलिखित टेक्स्ट बॉक्स है।

![The All Caps effect](all_caps_effect.png)

निम्न कोड उदाहरण दिखाता है कि **All Caps** प्रभाव लागू किए हुए टेक्स्ट को कैसे निकाला जाए:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, TextCapType

presentation = Presentation("sample2.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().get_Item(0)
    text_portion = auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)

    print("Original text: " + str(text_portion.getText()))

    text_format = text_portion.getPortionFormat().getEffective()
    if text_format.getTextCapType() == TextCapType.All:
        text = str(text_portion.getText()).upper()
        print("All-Caps effect: " + text)
finally:
    presentation.dispose()
```

आउटपुट:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **FAQ**

**मैं स्लाइड पर तालिका के टेक्स्ट को कैसे संशोधित करूँ?**

स्लाइड पर तालिका के टेक्स्ट को संशोधित करने के लिए [Table](https://reference.aspose.com/slides/hi/python-java/aspose.slides/table/) का उपयोग करें। सेल्स के माध्यम से इटरेट करें और प्रत्येक सेल को [Cell.getTextFrame](https://reference.aspose.com/slides/hi/python-java/aspose.slides/cell/#getTextFrame) और पैराग्राफ फ़ॉर्मेटिंग को [Paragraph.getParagraphFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/paragraph/#getParagraphFormat) के माध्यम से अपडेट करें।

**PowerPoint स्लाइड पर टेक्स्ट पर ग्रेडिएंट रंग कैसे लागू करूँ?**

टेक्स्ट पर ग्रेडिएंट रंग लागू करने के लिए [PortionFormat.getFillFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/portionformat/) का उपयोग करें। [FillFormat.setFillType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/fillformat/#setFillType) को [FillType.Gradient](https://reference.aspose.com/slides/hi/python-java/aspose.slides/filltype/#Gradient) पर सेट करें और ग्रेडिएंट स्टॉप, दिशा तथा ट्रांसपेरेंसी कॉन्फ़िगर करें।