---
title: Python के माध्यम से Java में प्रस्तुति टेक्स्ट फ़ॉर्मेट करें
linktitle: पाठ स्वरूपण
type: docs
weight: 50
url: /hi/python-java/text-formatting/
keywords:
- पैराग्राफ संरेखित करें
- पाठ शैली
- टेक्स्ट पृष्ठभूमि
- टेक्स्ट पारदर्शिता
- अक्षर अंतराल
- फ़ॉन्ट गुण
- फ़ॉन्ट परिवार
- टेक्स्ट घूर्णन
- घूर्णन कोण
- टेक्स्ट फ्रेम
- लाइन अंतराल
- ऑटॉफ़िट गुण
- टेक्स्ट फ्रेम एंकर
- टेक्स्ट टैबुलेशन
- डिफ़ॉल्ट भाषा
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में टेक्स्ट को फ़ॉर्मेट और शैली दें। फ़ॉन्ट, रंग, संरेखण आदि को कस्टमाइज़ करें।"
---
## **सारांश**

यह लेख Aspose.Slides for Python via Java का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में टेक्स्ट को फ़ॉर्मेट करने का तरीका दिखाता है। यह बैकग्राउंड रंग, पारदर्शिता, अक्षर अंतराल, फ़ॉन्ट गुण, रोटेशन, पैराग्राफ अंतराल, ऑटॉफ़िट व्यवहार, टेक्स्ट एंकरिंग, टैब स्टॉप और भाषा सेटिंग्स को कवर करता है।

जब तक अन्यथा उल्लेख नहीं किया गया हो, उदाहरण में [sample.pptx](sample.pptx) का उपयोग किया गया है। उसकी पहली स्लाइड पर पहला शेप एक टेक्स्ट बॉक्स है, और उसका पहला पैराग्राफ नीचे दिखाए गए टेक्स्ट को शामिल करता है। स्लाइड और शेप दोनों के इंडेक्स शून्य-आधारित होते हैं। जो उदाहरण बोल्ड भागों को चुनते हैं, वे प्रभावी फ़ॉर्मेटिंग का उपयोग करते हैं, जिसमें विरासत में मिली बोल्ड फ़ॉर्मेटिंग भी शामिल है:

![उदाहरण टेक्स्ट](sample_text.png)

शाब्दिक टेक्स्ट या रेगुलर एक्सप्रेशन मैच को खोजने और हाइलाइट करने के लिए, देखें [टेक्स्ट खोजें और बदलें](/slides/hi/python-java/search-and-replace-text/)।

## **टेक्स्ट बैकग्राउंड रंग सेट करें**

डिफ़ॉल्ट हाईलाइट रंग सेट करने के लिए पैराग्राफ के लिए [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) का उपयोग करें, या व्यक्तिगत टेक्स्ट भागों के लिए [BasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#getHighlightColor) का उपयोग करें।

निम्नलिखित उदाहरण पहले पैराग्राफ के लिए हल्के ग्रे हाईलाइट को डिफ़ॉल्ट के रूप में सेट करता है। व्यक्तिगत भागों पर स्पष्ट हाईलाइट रंग इस डिफ़ॉल्ट पर प्राथमिकता लेता है:

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

    # पूरे पैराग्राफ के लिए हाइलाइट रंग सेट करें।
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY)

    presentation.save("gray_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

परिणाम:

![ग्रे पैराग्राफ](gray_paragraph.png)

नीचे का कोड उदाहरण **बोल्ड फ़ॉन्ट** वाले **टेक्स्ट भागों** के लिए बैकग्राउंड रंग सेट करने का प्रदर्शन करता है:

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

![ग्रे टेक्स्ट भाग](gray_text_portions.png)

## **टेक्स्ट पैराग्राफ संरेखित करें**

टेक्स्ट फ्रेम के भीतर पैराग्राफ संरेखण सेट करने के लिए [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setAlignment) का उपयोग करें। मान केंद्रित, बाएँ‑संरेखित, दाएँ‑संरेखित, सिद्ध आदि हो सकते हैं।

निम्नलिखित कोड उदाहरण पैराग्राफ को **केंद्र** में संरेखित करने का तरीका दर्शाता है:

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

    # पैराग्राफ की संरेखण को केंद्र में सेट करें।
    paragraph.getParagraphFormat().setAlignment(TextAlignment.Center)

    presentation.save("aligned_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

परिणाम:

![संरेखित पैराग्राफ](aligned_paragraph.png)

## **पंक्ति के भीतर फ़ॉन्ट को संरेखित करें**

विभिन्न फ़ॉन्ट आकारों के टेक्स्ट भागों को ऊर्ध्वाधर रूप से संरेखित करने के लिए [ParagraphFormat.setFontAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setFontAlignment) का उपयोग करें। यह सेटिंग पूरे पैराग्राफ पर लागू होती है और उसकी प्रत्येक पंक्तियों के भीतर संरेखण को नियंत्रित करती है।

निम्नलिखित स्वनिर्धारित उदाहरण एक स्लाइड पर चार लेबल वाले टेक्स्ट बॉक्स बनाता है। प्रत्येक पैराग्राफ में 18, 36 और 54 पॉइंट के समान टेक्स्ट होते हैं, लेकिन अलग-अलग फ़ॉन्ट संरेखण होते हैं। यह Arial का उपयोग करता है, ऑटॉफ़िट और रैपिंग को निष्क्रिय करता है, तथा टेक्स्ट फ्रेम को एक पंक्तियों के लिए पर्याप्त बड़ा रखता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontAlignment, FontData, NullableBool, Paragraph, Portion, Presentation, SaveFormat, ShapeType, TextAlignment, TextAnchorType, TextAutofitType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    alignments = [FontAlignment.Baseline, FontAlignment.Top, FontAlignment.Center, FontAlignment.Bottom]
    alignment_names = ["Baseline", "Top", "Center", "Bottom"]
    font_sizes = [18.0, 36.0, 54.0]
    font = FontData("Arial")

    for i, alignment in enumerate(alignments):
        shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 20 + i * 130, 660, 120)
        shape.getFillFormat().setFillType(FillType.NoFill)
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)

        text_frame = shape.getTextFrame()
        text_frame.getTextFrameFormat().setAnchoringType(TextAnchorType.Top)
        text_frame.getTextFrameFormat().setAutofitType(TextAutofitType.None_)
        text_frame.getTextFrameFormat().setWrapText(NullableBool.False_)

        label = text_frame.getParagraphs().get_Item(0)
        label.setText(alignment_names[i])
        label.getParagraphFormat().setAlignment(TextAlignment.Left)
        label.getParagraphFormat().getDefaultPortionFormat().setFontHeight(14)
        label.getParagraphFormat().getDefaultPortionFormat().setLatinFont(font)
        label.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
        label.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)

        paragraph = Paragraph()
        paragraph.getParagraphFormat().setFontAlignment(alignment)
        paragraph.getParagraphFormat().setAlignment(TextAlignment.Left)
        paragraph.getParagraphFormat().getDefaultPortionFormat().setLatinFont(font)
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)

        for font_size in font_sizes:
            portion = Portion("Ag ")
            portion.getPortionFormat().setFontHeight(font_size)
            paragraph.getPortions().add(portion)

        text_frame.getParagraphs().add(paragraph)

    presentation.save("font_alignment.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

परिणाम:

![Baseline, Top, Center, और Bottom फ़ॉन्ट संरेखण की तुलना (मिश्रित फ़ॉन्ट आकार)](font_alignment.png)

फ़ॉन्ट संरेखण फ़ॉन्ट मीट्रिक का उपयोग करता है, इसलिए व्यक्तिगत अक्षरों के दृश्य किनारे आवश्यकतः बिल्कुल संरेखित नहीं होते। उदाहरण में एक बड़े अक्षर और एक डिसेंडर दोनों शामिल हैं ताकि बेसलाइन और बॉटम संरेखण के अंतर को दिखाया जा सके। फ़ॉन्ट उपलब्धता और प्रतिस्थापन, उपयोग किए गए अक्षर, और फ़ॉन्ट आकारों में अंतर परिणाम को प्रभावित करते हैं। फ्रेम आयाम, मार्जिन, लाइन स्पेसिंग, रैपिंग और ऑटॉफ़िट भी लेआउट को प्रभावित करते हैं; मोड की तुलना करते समय समान फ़ॉन्ट और लेआउट सेटिंग्स का उपयोग करें।

यह सेटिंग [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setAlignment) से भिन्न है, जो क्षैतिज पैराग्राफ संरेखण को नियंत्रित करता है, और [TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setAnchoringType) से भी, जो टेक्स्ट ब्लॉक को उसके शेप के भीतर ऊर्ध्वाधर रूप से स्थित करता है। [BasePortionFormat.setEscapement](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setEscapement) के माध्यम से सुपरस्क्रिप्ट और सबस्क्रिप्ट फ़ॉर्मेटिंग व्यक्तिगत भागों को बेसलाइन के सापेक्ष शिफ्ट करता है, न कि पैराग्राफ की लाइनों के लिए फ़ॉन्ट संरेखण सेट करता है।

## **टेक्स्ट की पारदर्शिता सेट करें**

टेक्स्ट की पारदर्शिता को [BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#getFillFormat) को असाइन किए गए रंग के अल्फा घटक के माध्यम से नियंत्रित किया जाता है। नीचे के उदाहरणों में, `alpha = 50` 0–255 स्केल पर एक ARGB अल्फा‑चैनल मान है, न कि पारदर्शिता प्रतिशत।

नीचे का कोड उदाहरण **पूरे पैराग्राफ** पर पारदर्शिता लागू करने का तरीका दिखाता है:

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

    # टेक्स्ट का फिल रंग पारदर्शी रंग पर सेट करें।
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(text_color)

    presentation.save("transparent_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

परिणाम:

![पारदर्शी पैराग्राफ](transparent_paragraph.png)

निम्न कोड उदाहरण **बोल्ड फ़ॉन्ट** वाले टेक्स्ट भागों पर पारदर्शिता लागू करने का तरीका दिखाता है:

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

![पारदर्शी टेक्स्ट भाग](transparent_text_portions.png)

## **टेक्स्ट के लिए अक्षर अंतराल सेट करें**

टेक्स्ट बॉक्स में अक्षरों के बीच अंतराल को विस्तारित या संकुचित करने के लिए [BasePortionFormat.setSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setSpacing) का उपयोग करें। उदाहरण 3 पॉइंट का अंतराल जोड़ते हैं; नकारात्मक मान टेक्स्ट को संकुचित करते हैं।

निम्न Python कोड **पूरे पैराग्राफ** में अक्षर अंतराल को विस्तारित करने का तरीका दर्शाता है:

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

    # ध्यान दें: अक्षर अंतराल को संकोचन करने के लिए नकारात्मक मान उपयोग करें।
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3) # अक्षर अंतराल बढ़ाएँ.

    presentation.save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

परिणाम:

![पैराग्राफ में अक्षर अंतराल](character_spacing_in_paragraph.png)

नीचे का कोड उदाहरण **बोल्ड फ़ॉन्ट** वाले टेक्स्ट भागों में अक्षर अंतराल को विस्तारित करने का तरीका दर्शाता है:

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
            # नोट: अक्षर अंतराल को संकुचित करने के लिए नकारात्मक मान उपयोग करें।
            portion.getPortionFormat().setSpacing(3) # अक्षर अंतराल बढ़ाएँ।

    presentation.save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

परिणाम:

![टेक्स्ट भागों में अक्षर अंतराल](character_spacing_in_text_portions.png)

### **विशिष्ट फ़ॉन्ट्स के लिए केर्निंग निष्क्रिय करें**

कभी‑कभी Aspose.Slides द्वारा रेंडर किया गया टेक्स्ट PowerPoint में दिखाए गए टेक्स्ट से थोड़ा टाइट लग सकता है। यह इसलिए हो सकता है कि PowerPoint कुछ फ़ॉन्ट्स के लिए केर्निंग डेटा को नजरअंदाज कर देता है, भले ही फ़ॉन्ट में वैध केर्निंग जानकारी हो और PowerPoint सेटिंग्स में केर्निंग सक्षम हो।

ऐसे मामलों में PowerPoint के समान रेंडरिंग प्राप्त करने के लिए, आप उन टेक्स्ट भागों के लिए केर्निंग निष्क्रिय कर सकते हैं जो प्रभावित फ़ॉन्ट का उपयोग करते हैं। [BasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setKerningMinimalSize) को वास्तविक फ़ॉन्ट आकार से बड़े मान पर सेट करें। यह उदाहरण पहले स्लाइड के पहले शेप पर एक टेक्स्ट बॉक्स वाले "presentation.pptx" की आवश्यकता रखता है। यह प्रभावी फ़ॉन्ट नामों की जाँच करता है, जिसमें विरासत में मिले फ़ॉन्ट शामिल हैं, और Roboto का उपयोग करने वाले भागों के लिए 100 पॉइंट थ्रेशहोल्ड सेट करता है। इससे 100 पॉइंट से नीचे के फ़ॉन्ट आकार वाले मिलते हुए भागों के लिए केर्निंग निष्क्रिय हो जाता है:

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
            portion_format = portion.getPortionFormat().getEffective()
            fonts = (portion_format.getLatinFont(), portion_format.getEastAsianFont(), portion_format.getComplexScriptFont())
            if any(font is not None and font.getFontName() == target_font for font in fonts):
                portion.getPortionFormat().setKerningMinimalSize(100)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

थ्रेशहोल्ड से नीचे के मिलते टेक्स्ट के लिए, यह सेटिंग केर्निंग को रोकती है और PowerPoint के इस विशेष व्यवहार से प्रभावित फ़ॉन्ट्स के लिए Aspose.Slides रेंडरिंग को PowerPoint के दृश्य आउटपुट के करीब लाने में मदद कर सकती है।

## **टेक्स्ट फ़ॉन्ट गुण प्रबंधित करें**

फ़ॉन्ट गुण पैराग्राफ स्तर पर [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) या व्यक्तिगत भागों पर [PortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/) के माध्यम से सेट किए जा सकते हैं।

निम्न उदाहरण पहले पैराग्राफ की डिफ़ॉल्ट फ़ॉन्ट को 12‑पॉइंट Times New Roman, बोल्ड, इटालिक और डॉटेड अंडरलाइन फ़ॉर्मेटिंग के साथ सेट करता है। व्यक्तिगत भागों पर स्पष्ट फ़ॉर्मेटिंग इन डिफ़ॉल्ट्स पर प्राथमिकता लेती है।

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

    # पैराग्राफ के लिए फ़ॉन्ट गुण सेट करें.
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

![पैराग्राफ के फ़ॉन्ट गुण](font_properties_for_paragraph.png)

निम्न उदाहरण उन भागों पर 13‑पॉइंट Times New Roman, इटालिक फ़ॉर्मेटिंग और डॉटेड अंडरलाइन लागू करता है जिनकी प्रभावी फ़ॉर्मेटिंग बोल्ड है:

```python
import jpase
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

![टेक्स्ट भागों के फ़ॉन्ट गुण](font_properties_for_text_portions.png)

## **टेक्स्ट ऊँचाई सामान्यीकरण नियंत्रित करें**

टेम्पलेट टाइपोग्राफी को पुनः उत्पन्न करने या अक्षर ऊँचाई में अंतर की जाँच करते समय [BasePortionFormat.setNormaliseHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setNormaliseHeight) का उपयोग करें। PowerPoint में, सामान्यीकरण सक्षम करने से व्यक्तिगत अक्षर ऊर्ध्वाधर रूप से खिंचे या संकुचित होते हैं ताकि वे टेक्स्ट भाग में समान दृश्य ऊँचाई रख सकें। यह विभिन्न फ़ॉन्ट्स में समान टेक्स्ट ऊँचाइयों की गारंटी नहीं देता।

गुणधर्म को स्पष्ट रूप से सक्षम या निष्क्रिय करने के लिए [NullableBool.True_ or False_](https://reference.aspose.com/slides/python-java/aspose.slides/nullablebool/) सेट करें। `NullableBool.NotDefined` स्थानीय सेटिंग को अनसेट छोड़ देता है ताकि भाग पैराग्राफ के [getDefaultPortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) से मान विरासत में ले सके। यह `False` होने का अर्थ नहीं है। रिजॉल्व्ड बूलियन मान प्राप्त करने के लिए [PortionFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/#getEffective) का उपयोग करें और लौटाए गए प्रभावी फ़ॉर्मेटिंग पर `getNormaliseHeight` पढ़ें।

निम्न स्वनिर्धारित उदाहरण को **Arial** इंस्टॉल होने की आवश्यकता है। यह दो टेक्स्ट ब्लॉक्स बनाता है जिनमें समान अपरकेस अक्षर, लोअरकेस अक्षर, डिसेंडर और 54 पॉइंट पर एक्सेंटेड कैरेक्टर होते हैं। दोनों पैराग्राफ डिफ़ॉल्ट रूप से सामान्यीकरण सक्षम करते हैं। शीर्ष भाग स्पष्ट रूप से इसे निष्क्रिय करता है; निचला भाग इसे विरासत में लेता है। फ्रेम आकार, मार्जिन और पैराग्राफ स्पेसिंग समान हैं, रैपिंग और ऑटॉफ़िट निष्क्रिय हैं ताकि तुलना सुसंगत रहे। उदाहरण `False: False` और `NotDefined: True` प्रिंट करता है, फिर "text_height_normalization.pptx" सहेजता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, NullableBool, Presentation, SaveFormat, ShapeType, TextAlignment, TextAnchorType, TextAutofitType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    settings = [NullableBool.False_, NullableBool.NotDefined]
    setting_names = ["False", "NotDefined"]

    for i, setting in enumerate(settings):
        shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 60 + i * 200, 660, 150)
        shape.getFillFormat().setFillType(FillType.NoFill)
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)

        text_frame = shape.getTextFrame()
        text_frame.setText("Hxgjpq ÅÉ 0123")
        text_frame.getTextFrameFormat().setAutofitType(TextAutofitType.None_)
        text_frame.getTextFrameFormat().setWrapText(NullableBool.False_)
        text_frame.getTextFrameFormat().setAnchoringType(TextAnchorType.Top)
        text_frame.getTextFrameFormat().setMarginTop(0)
        text_frame.getTextFrameFormat().setMarginLeft(0)

        paragraph = text_frame.getParagraphs().get_Item(0)
        paragraph.getParagraphFormat().setAlignment(TextAlignment.Left)
        paragraph.getParagraphFormat().setSpaceBefore(0)
        paragraph.getParagraphFormat().setSpaceAfter(0)
        paragraph.getParagraphFormat().setSpaceWithin(100)
        paragraph.getParagraphFormat().getDefaultPortionFormat().setNormaliseHeight(NullableBool.True_)

        portion = paragraph.getPortions().get_Item(0)
        font = FontData("Arial")
        portion.getPortionFormat().setLatinFont(font)
        portion.getPortionFormat().setFontHeight(54)
        portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
        portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
        portion.getPortionFormat().setNormaliseHeight(setting)

        print(f"{setting_names[i]}: {bool(portion.getPortionFormat().getEffective().getNormaliseHeight())}")

    presentation.save("text_height_normalization.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

नीचे की तुलना सहेजे गए प्रस्तुतीकरण से निर्यात की गई है। शीर्ष पंक्ति में सामान्यीकरण निष्क्रिय (`False`) है; निचली पंत्ति ने सक्षम सेटिंग को विरासत में लिया (`NotDefined` → `True`)। इस दिखावट को पुनः उत्पन्न करने के लिए Arial इंस्टॉल रखें।

![Arial 54‑पॉइंट टेक्स्ट जिसमें ऊपर सामान्यीकरण निष्क्रिय और नीचे सामान्यीकरण सक्षम है](text_height_normalization.png)

सामान्यीकरण अक्षर की ऊँचाई को बदलता है बिना असाइन किए गए [getFontHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#getFontHeight) मान को बदले, जो फ़ॉन्ट आकार को पॉइंट में निर्दिष्ट करता है। पैराग्राफ [setSpaceWithin](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setSpaceWithin) लाइन स्पेसिंग नियंत्रित करता है, जबकि टेक्स्ट‑फ़्रेम [setAutofitType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setAutofitType) टेक्स्ट या उसके कंटेनर को फिट करने के तरीके को नियंत्रित करता है। ये सेटिंग्स अलग‑अलग उद्देश्यों की सेवा करती हैं और लेआउट को स्वतंत्र रूप से प्रभावित कर सकती हैं। पैराग्राफ फ़ॉर्मेटिंग और विरासत के बारे में अधिक जानने के लिए देखें [Manage Paragraph](/slides/hi/python-java/manage-paragraph/)।

## **स्ट्राइकथ्रू लागू और हटाएँ**

टेक्स्ट भाग पर [BasePortionFormat.setStrikethroughType](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setStrikethroughType) का उपयोग करके संशोधन, रद्द शब्द, या पूर्व कीमतें बिना मूल टेक्स्ट हटाए दिखा सकते हैं। स्ट्राइकथ्रू को एक या दो लाइनों के लिए क्रमशः [TextStrikethroughType.Single or Double](https://reference.aspose.com/slides/python-java/aspose.slides/textstrikethroughtype/) पर सेट करें।

स्ट्राइकथ्रू हटाने के लिए, [TextStrikethroughType.None_](https://reference.aspose.com/slides/python-java/aspose.slides/textstrikethroughtype/#None) पास करें। यह स्पष्ट रूप से प्रभाव को निष्क्रिय करता है, भले ही आसपास का फ़ॉर्मेटिंग स्ट्राइकथ्रू निर्दिष्ट करता हो। विपरीत रूप से, [TextStrikethroughType.NotDefined](https://reference.aspose.com/slides/python-java/aspose.slides/textstrikethroughtype/#NotDefined) स्थानीय सेटिंग को अपरिभाषित छोड़ देता है, जिससे भाग पैराग्राफ से फ़ॉर्मेटिंग विरासत में ले सकता है। यह गारंटी नहीं देता कि स्ट्राइकथ्रू हट गया है। परिणामी फ़ॉर्मेटिंग, जिसमें विरासतित मान शामिल हैं, पढ़ने के लिए [PortionFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/#getEffective) का उपयोग करें।

निम्न स्वनिर्धारित उदाहरण तीन मूल्य तुलना बनाता है। प्रत्येक पैराग्राफ में लेबल, पूर्व कीमत, और वर्तमान कीमत के लिए अलग‑अलग भाग होते हैं, इसलिए केवल पूर्व कीमत प्रभावित होती है। पहली पंक्ति स्ट्राइकथ्रू लागू करती है और फिर हटाती है; अन्य पंक्तियों में क्रमशः एकल और डबल स्ट्राइकथ्रू बना रहता है। इस सेटिंग को बदलने से टेक्स्ट और उसके अन्य फ़ॉर्मेटिंग, जिसमें बोल्ड पूर्व कीमत शामिल है, सुरक्षित रहता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, NullableBool, Paragraph, Portion, Presentation, SaveFormat, ShapeType, TextAlignment, TextStrikethroughType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 620, 220)
    shape.getFillFormat().setFillType(FillType.NoFill)
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
    shape.getTextFrame().getParagraphs().clear()

    labels = ["None: ", "Single: ", "Double: "]

    for label in labels:
        paragraph = Paragraph()
        paragraph.getParagraphFormat().setAlignment(TextAlignment.Left)
        paragraph.getParagraphFormat().setSpaceAfter(20)

        portion_format = paragraph.getParagraphFormat().getDefaultPortionFormat()
        portion_format.setFontHeight(28)
        font = FontData("Arial")
        portion_format.setLatinFont(font)
        portion_format.getFillFormat().setFillType(FillType.Solid)
        portion_format.getFillFormat().getSolidFillColor().setColor(Color.BLACK)

        label_portion = Portion(label)
        paragraph.getPortions().add(label_portion)

        previous_price = Portion("$100")
        previous_price.getPortionFormat().setFontBold(NullableBool.True_)
        paragraph.getPortions().add(previous_price)
        current_price = Portion(" → $80")
        paragraph.getPortions().add(current_price)

        shape.getTextFrame().getParagraphs().add(paragraph)

    paragraphs = shape.getTextFrame().getParagraphs()

    # स्ट्राइकथ्रू लागू करें, फिर पहले पिछले मूल्य से इसे स्पष्ट रूप से हटाएँ.
    paragraphs.get_Item(0).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.Single)
    paragraphs.get_Item(0).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.None_)

    paragraphs.get_Item(1).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.Single)
    paragraphs.get_Item(2).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.Double)

    presentation.save("strikethrough.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

परिणाम, शीर्ष से नीचे: कोई स्ट्राइकथ्रू नहीं, एकल स्ट्राइकथ्रू, और डबल स्ट्राइकथ्रू।

![स्ट्राइकथ्रू बिना, एकल स्ट्राइकथ्रू और डबल स्ट्राइकथ्रू वाले पूर्व कीमतें](strikethrough.png)

## **टेक्स्ट रोटेशन सेट करें**

[TextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setTextVerticalType) का उपयोग करके शेप के भीतर पूर्वनिर्धारित टेक्स्ट अभिविन्यास सेट करें।

निम्न कोड उदाहरण टेक्स्ट अभिविन्यास को [TextVerticalType.Vertical270](https://reference.aspose.com/slides/python-java/aspose.slides/textverticaltype/) पर सेट करता है, जो टेक्स्ट को **90 डिग्री प्रतिक्लॉकवाइज** घुमाता है:

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

![टेक्स्ट रोटेशन](text_rotation.png)

## **ऊर्ध्वाधर टेक्स्ट में अंकों को साइड बाय साइड दिखाएँ**

दो‑अंकीय संख्या के अंक को एक ऊर्ध्वाधर जापानी लेबल में साइड बाय साइड रखने के लिए, दोनों अंकों को एक ही टेक्स्ट भाग में रखें और उस भाग पर [BasePortionFormat.setKumimoji](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setKumimoji) कॉल करें। इस उदाहरण में दोनों लेबल [TextVerticalType.EastAsianVertical](https://reference.aspose.com/slides/python-java/aspose.slides/textverticaltype/#EastAsianVertical) और 40‑पॉइंट MS Gothic का उपयोग करते हैं। अंकों के लिए [NullableBool](https://reference.aspose.com/slides/python-java/aspose.slides/nullablebool/) सेटिंग अलग है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, NullableBool, Portion, Presentation, SaveFormat, ShapeType, TextVerticalType

Color = jpype.JClass("java.awt.Color")
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    font = FontData("MS Gothic")

    for x, kumimoji in [(120, NullableBool.True_), (360, NullableBool.False_)]:
        label = slide.getShapes().addAutoShape(ShapeType.Rectangle, x, 48, 120, 420)
        label.getFillFormat().setFillType(FillType.NoFill)
        label.getLineFormat().getFillFormat().setFillType(FillType.NoFill)

        frame = label.addTextFrame("")
        frame.getTextFrameFormat().setTextVerticalType(TextVerticalType.EastAsianVertical)

        paragraph = frame.getParagraphs().get_Item(0)
        default_format = paragraph.getParagraphFormat().getDefaultPortionFormat()
        default_format.setLatinFont(font)
        default_format.setEastAsianFont(font)
        default_format.setFontHeight(40)
        default_format.getFillFormat().setFillType(FillType.Solid)
        default_format.getFillFormat().getSolidFillColor().setColor(Color.BLACK)

        digits = Portion("12")
        digits.getPortionFormat().setKumimoji(kumimoji)
        
        portions = paragraph.getPortions()
        portions.clear()
        portions.add(Portion("令和"))
        portions.add(digits)
        portions.add(Portion("年"))

    presentation.save("vertical_date.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

PowerPoint में, बायें लेबल (`True`) में अंक ऊर्ध्वाधर और साइड बाय साइड दिखते हैं, जबकि दायें लेबल (`False`) में अंक 90 डिग्री क्लॉकवाइज घुमा हुआ है। दोनों लेबल में चारों ओर के जापानी अक्षर स्थिर रहते हैं।

![ऊर्ध्वाधर तिथि लेबल में बायें पर अंक सीधा और दायें पर घुमा हुआ प्रतिक्लॉकवाइज दिखते हैं।](vertical_date.png)

## **टेक्स्ट फ्रेम्स के लिए कस्टम रोटेशन सेट करें**

[TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setRotationAngle) का उपयोग करके किसी [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/) के लिए कस्टम रोटेशन एंगल सेट करें।

नीचे का कोड उदाहरण शेप के भीतर टेक्स्ट फ्रेम को 3 डिग्री क्लॉकवाइज घुमाता है:

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

![कस्टम टेक्स्ट रोटेशन](custom_text_rotation.png)

## **पैराग्राफ की लाइन स्पेसिंग सेट करें**

Aspose.Slides प्रदान करता है [ParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setSpaceAfter), [ParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setSpaceBefore), और [ParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setSpaceWithin) पैराग्राफ अंतराल को नियंत्रित करने के लिए। ये गुण इस प्रकार उपयोग होते हैं:

* लाइन स्पेसिंग को लाइन की ऊँचाई के प्रतिशत के रूप में निर्दिष्ट करने के लिए सकारात्मक मान उपयोग करें।
* लाइन स्पेसिंग को पॉइंट में निर्दिष्ट करने के लिए नकारात्मक मान उपयोग करें।

निम्न उदाहरण पहली पैराग्राफ की भीतर की स्पेसिंग को लाइन की ऊँचाई के 200 % (डबल स्पेसिंग) पर सेट करता है:

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

![पैराग्राफ के भीतर लाइन स्पेसिंग](line_spacing.png)

## **लाइन ब्रेकिंग नियंत्रित करें**

पैराग्राफ लाइन‑ब्रेकिंग नियम संकीर्ण टेक्स्ट ब्लॉक्स और लैटिन तथा ईस्ट एशियन टेक्स्ट के मिश्रण वाले प्रस्तुतियों में उपयोगी होते हैं। नीचे दिए गए मेथड्स [ParagraphFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/) से संबंधित हैं, इसलिए वे पूरे पैराग्राफ पर लागू होते हैं:

- [setLatinLineBreak](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setLatinLineBreak) लैटिन लाइन‑ब्रेकिंग नियम नियंत्रित करता है। मिश्रित टेक्स्ट में इसे बदलने से ईस्ट एशियन टेक्स्ट एवं विराम चिह्नों की रैपिंग भी बदल सकती है।
- [setEastAsianLineBreak](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setEastAsianLineBreak) ईस्ट एशियन लाइन‑ब्रेकिंग नियम नियंत्रित करता है, जिसमें लाइन की शुरुआत और अंत में अक्षरों पर प्रतिबंध शामिल हैं।

ये नियम [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setWrapText) को प्रतिस्थापित नहीं करते, जो टेक्स्ट फ्रेम के भीतर स्वचालित रैपिंग सक्षम करता है। वे रैपिंग होने पर लेआउट को प्रभावित करते हैं; वे लाइन‑ब्रेक कैरेक्टर सम्मिलित नहीं करते। एक स्पष्ट लाइन ब्रेक पैराग्राफ में नई पंक्ति बनाता है, उपलब्ध चौड़ाई से स्वतंत्र।

निम्न स्वनिर्धारित उदाहरण एक संकीर्ण टेक्स्ट ब्लॉक बनाता है जिसमें चाइनीज़ और लैटिन टेक्स्ट सम्मिलित होते हैं। यह दोनों लाइन‑ब्रेकिंग विकल्प स्पष्ट रूप से सेट करता है और "line_breaking.pptx" सहेजता है। किसी भी नियम को आज़माने के लिए, संबंधित मान बदलें जबकि अन्य सेटिंग्स को अपरिवर्तित रखें। उदाहरण 24‑पॉइंट Arial और SimSun का उपयोग करता है, 160‑पॉइंट फ्रेम चौड़ाई और शून्य क्षैतिज टेक्स्ट‑फ़्रेम मार्जिन के साथ। [TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setAutofitType) को [TextAutofitType.None_](https://reference.aspose.com/slides/python-java/aspose.slides/textautofittype/) के साथ बुलाया जाता है ताकि टेक्स्ट आकार और फ्रेम आयाम स्थिर रहें।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, NullableBool, Presentation, SaveFormat, ShapeType, TextAlignment, TextAutofitType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 160, 300)
    shape.getFillFormat().setFillType(FillType.NoFill)

    text_frame = shape.getTextFrame()
    text_frame.getTextFrameFormat().setWrapText(NullableBool.True_)
    text_frame.getTextFrameFormat().setAutofitType(TextAutofitType.None_)
    text_frame.getTextFrameFormat().setMarginLeft(0)
    text_frame.getTextFrameFormat().setMarginRight(0)

    paragraph = text_frame.getParagraphs().get_Item(0)
    paragraph.setText("中文排版测试，PowerPoint 中文演示。")

    paragraph_format = paragraph.getParagraphFormat()
    paragraph_format.setAlignment(TextAlignment.Left)
    paragraph_format.getDefaultPortionFormat().setFontHeight(24)
    latin_font = FontData("Arial")
    paragraph_format.getDefaultPortionFormat().setLatinFont(latin_font)
    east_asian_font = FontData("SimSun")
    paragraph_format.getDefaultPortionFormat().setEastAsianFont(east_asian_font)
    paragraph_format.getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph_format.getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    paragraph_format.setLatinLineBreak(NullableBool.False_)
    paragraph_format.setEastAsianLineBreak(NullableBool.True_)

    presentation.save("line_breaking.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **हैंगिंग पंक्चुएशन नियंत्रित करें**

[ParagraphFormat.setHangingPunctuation](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setHangingPunctuation) पात्रियों को टेक्स्ट लाइन के दायें किनारे से बाहर निकालने की अनुमति देता है, बजाय अगले लाइन में जाने के। यह पूरे पैराग्राफ पर लागू होता है और हैंगिंग इंडेंट से अलग है।

निम्न स्वनिर्धारित उदाहरण 100‑पॉइंट‑व्यापी टेक्स्ट फ्रेम में हैंगिंग पंक्चुएशन सक्षम करता है और "hanging_punctuation.pptx" सहेजता है। 24‑पॉइंट Arial और शून्य क्षैतिज टेक्स्ट‑फ़्रेम मार्जिन के साथ, अंतिम बिंदु "sentence" के बाद रहता है और दायें टेक्स्ट किनारे से बाहर निकलता है। तुलना के लिए गुण को [NullableBool.False_](https://reference.aspose.com/slides/python-java/aspose.slides/nullablebool/) पर सेट करें: इन सेटिंग्स के साथ, बिंदु अलग लाइन में आता है। रैपिंग सक्षम है और ऑटॉफ़िट निष्क्रिय है ताकि उपलब्ध चौड़ाई स्थिर रहे।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, NullableBool, Presentation, SaveFormat, ShapeType, TextAlignment, TextAutofitType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 100, 200)
    shape.getFillFormat().setFillType(FillType.NoFill)

    text_frame = shape.getTextFrame()
    text_frame.getTextFrameFormat().setWrapText(NullableBool.True_)
    text_frame.getTextFrameFormat().setAutofitType(TextAutofitType.None_)
    text_frame.getTextFrameFormat().setMarginLeft(0)
    text_frame.getTextFrameFormat().setMarginRight(0)

    paragraph = text_frame.getParagraphs().get_Item(0)
    paragraph.setText("Simple text, next sentence.")

    paragraph_format = paragraph.getParagraphFormat()
    paragraph_format.setAlignment(TextAlignment.Left)
    paragraph_format.getDefaultPortionFormat().setFontHeight(24)
    latin_font = FontData("Arial")
    paragraph_format.getDefaultPortionFormat().setLatinFont(latin_font)
    paragraph_format.getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph_format.getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    paragraph_format.setHangingPunctuation(NullableBool.True_)

    presentation.save("hanging_punctuation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

हर पंक्चुएशन मार्क हैंग नहीं कर सकता। ऊपर वर्णित [फ़ॉन्ट और लेआउट स्थितियाँ](#control-line-breaking) भी इस तुलना में लागू होती हैं: फ़ॉन्ट, उपलब्ध चौड़ाई, मार्जिन, या ऑटॉफ़िट सेटिंग बदलने से दृश्य अंतर हट सकता है।

## **टेक्स्ट फ्रेम्स के लिए ऑटॉफ़िट प्रकार सेट करें**

[TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setAutofitType) निर्धारित करता है कि टेक्स्ट कंटेनर की सीमाओं से अधिक होने पर कैसे व्यवहार करता है। इसका उपयोग करके तय करें कि टेक्स्ट सिकुड़ना चाहिए, ओवरफ़्लो होना चाहिए, या शेप को स्वचालित रूप से रिसाइज़ करना चाहिए। निम्न उदाहरण शेप को उसके टेक्स्ट के अनुसार रिसाइज़ करने के लिए कॉन्फ़िगर करता है और परिणाम "autofit_type.pptx" में सहेजता है।

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

ऑटो रैपिंग के बाद लाइनों की गिनती करने और यह देखने के लिए कि टेक्स्ट या शेप की चौड़ाई परिणाम को कैसे बदलती है, देखें [Count Rendered Lines](/slides/hi/python-java/manage-paragraph/). केवल लाइनों की गिनती यह संकेत नहीं देती कि टेक्स्ट कंटेनर से ओवरफ़्लो हो रहा है या नहीं।

## **टेक्स्ट फ्रेम्स का एंकर सेट करें**

[TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setAnchoringType) निर्धारित करता है कि टेक्स्ट को शेप के अंदर ऊर्ध्वाधर रूप से कैसे स्थित किया जाए, उदाहरण के लिए शीर्ष, मध्य या नीचे। निम्न उदाहरण टेक्स्ट को पहले शेप के नीचे एंकर करता है और परिणाम "text_anchor.pptx" में सहेजता है।

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

## **टेक्स्ट टैबुलेशन सेट करें**

पैराग्राफ में टैब स्टॉप कॉन्फ़िगर करने के लिए [ParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setDefaultTabSize) और [ParagraphFormat.getTabs](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getTabs) का उपयोग करें। निम्न उदाहरण डिफ़ॉल्ट टैब अंतराल को 100 पॉइंट पर सेट करता है और 30 पॉइंट पर एक बाएँ‑संरेखित टैब स्टॉप जोड़ता है। ये सेटिंग्स टैब कैरेक्टर वाले टेक्स्ट को प्रभावित करती हैं।

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

![पैराग्राफ टैब्स](paragraph_tabs.png)

## **प्रूफिंग भाषा सेट करें**

Aspose.Slides प्रदान करता है [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setLanguageId), जिससे आप टेक्स्ट भाग के लिए प्रूफिंग भाषा सेट कर सकते हैं। प्रूफिंग भाषा PowerPoint में वर्तनी और व्याकरण जाँच के लिए उपयोग की जाने वाली भाषा निर्धारित करती है।

निम्न उदाहरण को "presentation.pptx" चाहिए जिसमें पहली स्लाइड के पहले शेप पर एक टेक्स्ट बॉक्स हो और कम से कम एक पैराग्राफ हो। यह पहले पैराग्राफ की सामग्री को "1。" से बदलता है, फ़ॉन्ट को SimSun सेट करता है, और प्रूफिंग भाषा Simplified Chinese (`zh-CN`) असाइन करता है। परिणाम "proofing_language.pptx" में सहेजा जाता है:

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

    # प्रूफ़िंग भाषा का Id सेट करें।
    text_portion.getPortionFormat().setLanguageId("zh-CN")

    text_portion.setText("1。")
    paragraph.getPortions().add(text_portion)

    presentation.save("proofing_language.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **भाषा मेटाडाटा कॉपी करें**

जब टेम्पलेट से बहुभाषी टेक्स्ट कॉपी किया जाता है, तो दोनों [BasePortionFormat.getLanguageId](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#getLanguageId) और [BasePortionFormat.getAlternativeLanguageId](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#getAlternativeLanguageId) को संरक्षित रखें। निम्न स्वनिर्धारित उदाहरण एक स्रोत भाग बनाता है जिसमें US English उसकी भाषा है और French उसकी वैकल्पिक भाषा है, और टेक्स्ट व पहचानकर्ता को नई प्रस्तुति में एक भाग में कॉपी करता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Portion, Presentation, SaveFormat, ShapeType

source = Portion("Hello! Bonjour!")
source.getPortionFormat().setLanguageId("en-US")
source.getPortionFormat().setAlternativeLanguageId("fr-FR")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 80)
    paragraph = shape.getTextFrame().getParagraphs().get_Item(0)
    paragraph.getPortions().clear()

    destination = Portion()
    destination.setText(source.getText())
    destination.getPortionFormat().setLanguageId(source.getPortionFormat().getLanguageId())
    # यदि स्रोत के पास वैकल्पिक भाषा नहीं है, तो None गंतव्य मान को साफ़ कर देता है।
    destination.getPortionFormat().setAlternativeLanguageId(source.getPortionFormat().getAlternativeLanguageId())
    paragraph.getPortions().add(destination)

    presentation.save("copied_language_metadata.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

वैकल्पिक भाषा के बिना स्रोत आज़माने के लिए, `"fr-FR"` असाइनमेंट को छोड़ें। तब वैकल्पिक पहचानकर्ता `None` रहेगा, और वही कॉपी स्टेटमेंट इसकी अनुपस्थिति को डिफ़ॉल्ट मान जोड़े बिना संरक्षित रखेगा, चाहे लक्ष्य में पहले वैकल्पिक भाषा सेट हो।

ये पहचानकर्ता भाषा मेटाडाटा संग्रहीत करते हैं। इन्हें संरक्षित करने से यह निर्धारित नहीं होता कि PowerPoint किस शब्दकोश को वर्तनी या व्याकरण जाँच के लिए चुनता है।

## **डिफ़ॉल्ट भाषा सेट करें**

[LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setDefaultTextLanguage) का उपयोग करके प्रस्तुति लोड या बनाते समय बनाए गए टेक्स्ट की डिफ़ॉल्ट भाषा परिभाषित करें। निम्न उदाहरण US English को डिफ़ॉल्ट टेक्स्ट भाषा के रूप में सेट करता है, एक टेक्स्ट बॉक्स जोड़ता है, और उसके पहले टेक्स्ट भाग पर `en-US` प्रिंट करता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, ShapeType

load_options = LoadOptions()
load_options.setDefaultTextLanguage("en-US")

presentation = Presentation(load_options)
try:
    slide = presentation.getSlides().get_Item(0)

    # टेक्स्ट के साथ एक आयताकार आकार जोड़ें.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 50)
    shape.getTextFrame().setText("Sample text")

    # पहले भाग की भाषा जाँचें.
    portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    print(portion.getPortionFormat().getLanguageId())
finally:
    presentation.dispose()
```

## **डिफ़ॉल्ट टेक्स्ट शैली सेट करें**

प्रस्तुति स्तर पर डिफ़ॉल्ट टेक्स्ट फ़ॉर्मेटिंग लागू करने के लिए [Presentation.getDefaultTextStyle](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getDefaultTextStyle) का उपयोग करें।

निम्न उदाहरण नई प्रस्तुति में शीर्ष‑स्तर पैराग्राफ के लिए 14‑पॉइंट बोल्ड फ़ॉन्ट को डिफ़ॉल्ट के रूप में सेट करता है और इसे "default_text_style.pptx" में सहेजता है। टेक्स्ट इन डिफ़ॉल्ट्स को विरासत में ले सकता है जब तक कि अधिक विशिष्ट फ़ॉर्मेटिंग उन्हें ओवरराइड न करे।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpade.startJVM()

from asposeslides.api import NullableBool, Presentation, SaveFormat

presentation = Presentation()
try:
    # शीर्ष स्तर के पैराग्राफ फ़ॉर्मेट को प्राप्त करें।
    paragraph_format = presentation.getDefaultTextStyle().getLevel(0)

    if paragraph_format is not None:
        paragraph_format.getDefaultPortionFormat().setFontHeight(14)
        paragraph_format.getDefaultPortionFormat().setFontBold(NullableBool.True_)

    presentation.save("default_text_style.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **ऑल‑कैप्स प्रभाव के साथ टेक्स्ट निकालें**

PowerPoint में **All Caps** फ़ॉन्ट प्रभाव लागू करने से टेक्स्ट स्लाइड पर अप्परकेस में दिखाई देता है, जबकि असल में वह लोअरकेस में टाइप किया गया था। Aspose.Slides के साथ ऐसा टेक्स्ट भाग प्राप्त करने पर, लाइब्रेरी वही टेक्स्ट लौटाती है जैसा दर्ज किया गया था। प्रदर्शित टेक्स्ट से मेल खाने के लिए, [TextCapType](https://reference.aspose.com/slides/python-java/aspose.slides/textcaptype/) जांचें और जब मान `All` हो तो लौटाए गए स्ट्रिंग को अप्परकेस में परिवर्तित करें।

यह उदाहरण "sample2.pptx" की आवश्यकता रखता है जिसमें पहली स्लाइड के पहले शेप पर एक टेक्स्ट बॉक्स हो। उसके पहले पैराग्राफ का पहला भाग "Hello, Aspose!" को All Caps प्रभाव के साथ प्रदर्शित करता है, जैसा नीचे दिखाया गया है।

![All Caps प्रभाव](all_caps_effect.png)

नीचे का कोड उदाहरण **All Caps** प्रभाव के साथ टेक्स्ट निकालने का तरीका दर्शाता है:

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

**स्लाइड पर टेबल में टेक्स्ट कैसे बदलें?**

स्लाइड पर टेबल में टेक्स्ट बदलने के लिए, [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/). का उपयोग करें। सेल्स के माध्यम से इटररेट करें और प्रत्येक सेल को [Cell.getTextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getTextFrame) और पैराग्राफ फ़ॉर्मेटिंग को [Paragraph.getParagraphFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/#getParagraphFormat) के माध्यम से अपडेट करें।

**PowerPoint स्लाइड पर टेक्स्ट को ग्रेडिएंट रंग कैसे लागू करें?**

टेक्स्ट पर ग्रेडिएंट रंग लागू करने के लिए, [BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#getFillFormat) का उपयोग करें। [FillFormat.setFillType](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#setFillType) को [FillType.Gradient](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/) पर सेट करें और ग्रेडिएंट स्टॉप, दिशा और पारदर्शिता को कॉन्फ़िगर करें।