---
title: Python via Java का उपयोग करके प्रस्तुतियों में टेक्स्ट बॉक्स प्रबंधित करें
linktitle: टेक्स्ट बॉक्स प्रबंधित करें
type: docs
weight: 20
url: /hi/python-java/manage-textbox/
keywords:
- टेक्स्ट बॉक्स
- टेक्स्ट फ्रेम
- टेक्स्ट जोड़ें
- टेक्स्ट अपडेट करें
- टेक्स्ट बॉक्स बनाएं
- टेक्स्ट बॉक्स जांचें
- टेक्स्ट कॉलम जोड़ें
- हाइपरलिंक जोड़ें
- PowerPoint
- प्रेजेंटेशन
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में टेक्स्ट बॉक्स बनाएं, पहचानें, स्वरूपित करें और अपडेट करें।"
---
## **परिचय**

Aspose.Slides for Python via Java में, स्लाइड टेक्स्ट को टेक्स्ट फ्रेम में संग्रहीत किया जाता है जो शैप्स से संबंधित होते हैं। AutoShape क्लास सबसे सामान्य टेक्स्ट‑धारक शैप का प्रतिनिधित्व करती है और अपने टेक्स्ट को AutoShape.getTextFrame मेथड के माध्यम से उजागर करती है।

{{% alert color="info" title="नोट" %}}
हर ऑटो शैप Shape से विरासत में प्राप्त करता है, लेकिन हर शैप ऑटो शैप नहीं होता या टेक्स्ट फ्रेम को सपोर्ट नहीं करता। मौजूदा प्रस्तुति को प्रोसेस करते समय, टेक्स्ट तक पहुंचने से पहले यह जांचें कि शैप AutoShape का इंस्टेंस है या नहीं।
{{% /alert %}}

## **स्लाइड पर टेक्स्ट बॉक्स बनाना**

एक टेक्स्ट बॉक्स बनाने के लिए, स्लाइड में एक ऑटो शैप जोड़ें, उसके टेक्स्ट फ्रेम में टेक्स्ट जोड़ें, और प्रस्तुति को सहेजें। निम्नलिखित उदाहरण एक आयताकार टेक्स्ट बॉक्स बनाता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 300, 50)
    text_box.addTextFrame("Aspose TextBox")

    presentation.save("TextBox.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

ShapeCollection.addAutoShape को पास किए गए कोऑर्डिनेट और आयाम पॉइंट में मापे जाते हैं। AutoShape.addTextFrame प्रदान किए गए टेक्स्ट के साथ टेक्स्ट फ्रेम को प्रारंभ करता है।

## **टेक्स्ट बॉक्स शैप की जाँच**

AutoShape.isTextBox मेथड का उपयोग करके निर्धारित करें कि क्या कोई ऑटो शैप टेक्स्ट बॉक्स के रूप में माना जाता है। यह तब उपयोगी है जब प्रस्तुति में टेक्स्ट‑धारक और केवल ग्राफ़िकल ऑटो शैप दोनों होते हैं।

![एक टेक्स्ट बॉक्स और एक शैप](istextbox.png)

निम्नलिखित उदाहरण प्रस्तुति में प्रत्येक ऑटो शैप की जांच करता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 120, 40)
    text_box.addTextFrame("Text box")
    slide.getShapes().addAutoShape(ShapeType.Ellipse, 150, 10, 40, 40)

    for current_slide in presentation.getSlides():
        for shape in current_slide.getShapes():
            if isinstance(shape, AutoShape):
                print("The shape is a text box." if shape.isTextBox() else "The shape is not a text box.")
finally:
    presentation.dispose()
```

नई जोड़ी गई ऑटो शैप को तब तक टेक्स्ट बॉक्स नहीं माना जाता जब तक उसमें खाली न हो ऐसा टेक्स्ट न हो। आप वह टेक्स्ट AutoShape.addTextFrame या TextFrame.setText के माध्यम से प्रदान कर सकते हैं। खाली स्ट्रिंग जोड़ने या असाइन करने से AutoShape.isTextBox `False` लौटाता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    added_text_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 40)
    added_text_shape.addTextFrame("Shape 1")
    print(added_text_shape.isTextBox())

    assigned_text_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 70, 100, 40)
    assigned_text_shape.getTextFrame().setText("Shape 2")
    print(assigned_text_shape.isTextBox())

    added_empty_text_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 130, 100, 40)
    added_empty_text_shape.addTextFrame("")
    print(added_empty_text_shape.isTextBox())

    assigned_empty_text_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 190, 100, 40)
    assigned_empty_text_shape.getTextFrame().setText("")
    print(assigned_empty_text_shape.isTextBox())
finally:
    presentation.dispose()
```

पहली दो कॉल्स `True` प्रिंट करती हैं; अंतिम दो `False` प्रिंट करती हैं।

## **टेक्स्ट फ्रेम के मालिक शैप को खोजें**

जनरल टेक्स्ट‑प्रोसेसिंग कोड को एक TextFrame मिल सकता है बिना यह जाने कि कौन सा प्रस्तुति ऑब्जेक्ट इसे रखता है। पढ़ने‑के‑लिए‑केवल TextFrame.getParentShape मेथड का उपयोग करके उसके मालिक Shape पर वापस नेविगेट करें।

यदि टेक्स्ट फ्रेम ऑटो शैप या किसी अन्य टेक्स्ट‑धारक शैप का मालिक है, तो TextFrame.getParentShape मालिक को लौटाता है और TextFrame.getParentCell `None` लौटाता है। इसे एक्सेस करने से पहले लौटाई गई वैल्यू की जाँच करें। शैप और टेबल‑सेल दोनों मालिकों की पहचान करने के लिए, जिसमें SmartArt नोड्स से जुड़े शैप्स भी शामिल हैं, Search and Replace Text देखें।

## **टेक्स्ट बॉक्स में कॉलम जोड़ें**

TextFrameFormat.setColumnCount मेथड टेक्स्ट फ्रेम को कॉलम में विभाजित करता है, जबकि TextFrameFormat.setColumnSpacing कॉलम के बीच का गैप पॉइंट में सेट करता है। दोनों सेटिंग्स TextFrameFormat की हैं और मौजूदा टेक्स्ट बॉक्स के टेक्स्ट फ्रेम के माध्यम से बदली जा सकती हैं। टेक्स्ट उसी शैप के भीतर कॉलम के बीच रीफ़्लो करता है; यह किसी अन्य शैप में जारी नहीं रहता।

निम्नलिखित उदाहरण 10 पॉइंट कॉलम अंतर के साथ तीन‑कॉलम टेक्स्ट बॉक्स बनाता है, प्रस्तुति को सहेजता है, और आउटपुट फ़ाइल से सहेजी गई सेटिंग्स को वापस पढ़ता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 200)
    text_box.addTextFrame("This text is distributed automatically across all columns in the text box.")

    text_frame_format = text_box.getTextFrame().getTextFrameFormat()
    text_frame_format.setColumnCount(3)
    text_frame_format.setColumnSpacing(10)

    presentation.save("TextBoxColumns.pptx", SaveFormat.Pptx)

    saved_presentation = Presentation("TextBoxColumns.pptx")
    try:
        saved_text_box = saved_presentation.getSlides().get_Item(0).getShapes().get_Item(0)
        saved_format = saved_text_box.getTextFrame().getTextFrameFormat()
        print(f"Columns: {saved_format.getColumnCount()}; spacing: {saved_format.getColumnSpacing()} points")
    finally:
        saved_presentation.dispose()
finally:
    presentation.dispose()
```

## **व्यक्तिगत कॉलम से टेक्स्ट निकालें**

मौजूदा टेक्स्ट फ्रेम में प्रत्येक विज़ुअल कॉलम को सौंपा गया टेक्स्ट प्राप्त करने के लिए TextFrame.splitTextByColumns का उपयोग करें। यह मेथड प्रत्येक कॉलम के लिए एक स्ट्रिंग लौटाता है, कॉलम‑आधारित रीडिंग ऑर्डर में। एक‑कॉलम टेक्स्ट फ्रेम एक तत्व वाला ऐरे बनाता है, और खाली कॉलम को खाली स्ट्रिंग से दर्शाया जाता है। स्ट्रिंग्स में केवल सादा टेक्स्ट होता है; भाग‑स्तर स्वरूपण संरक्षित नहीं रहता।

यह उपयोगी है जब आपको आवश्यक हो:
- टेक्स्ट को उसकी कॉलम‑आधारित रीडिंग ऑर्डर को बनाए रखते हुए निकालना।
- मल्टी‑कॉलम स्लाइड्स की सामग्री को इंडेक्स या तुलना करना।
- प्रत्येक कॉलम को अलग फ़ाइल, डेटाबेस फ़ील्ड या अन्य गंतव्य पर निर्यात करना।
- कॉलम गिनती को TextFrameFormat.setColumnCount, स्पेसिंग को TextFrameFormat.setColumnSpacing, फ़ॉन्ट या टेक्स्ट‑फ़्रेम आकार बदलने के बाद टेक्स्ट कैसे पुनः वितरित हुआ, इसका निरीक्षण करना।

यह मेथड वर्तमान TextFrame के भीतर वितरित टेक्स्ट को रिपोर्ट करता है; यह अलग शैप्स या टेक्स्ट बॉक्सेस के बीच स्वचालित रूप से टेक्स्ट नहीं प्रवाहित करता। कॉलम वितरण उपलब्ध फ़ॉन्ट्स और अन्य टेक्स्ट‑लेआउट सेटिंग्स पर निर्भर हो सकता है, इसलिए निरंतर परिणामों के लिए आवश्यक फ़ॉन्ट्स उपलब्ध हों यह सुनिश्चित करें।

निम्नलिखित उदाहरण एक प्रस्तुति लोड करता है, पहला मल्टी‑कॉलम ऑटो शैप जिसमें टेक्स्ट फ्रेम है, खोजता है, उसकी कॉन्फ़िगर्ड कॉलम काउंट पढ़ता है, और हर कॉलम से टेक्स्ट को अलग फ़ाइल में लिखता है। जो शैप्स टेक्स्ट फ्रेम नहीं प्रदान करते, उन्हें छोड़ दिया जाता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import AutoShape, Presentation

presentation = Presentation("MultiColumnText.pptx")
try:
    text_box = None
    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, AutoShape):
            if shape.getTextFrame() is not None:
                column_count = shape.getTextFrame().getTextFrameFormat().getColumnCount()
                if column_count > 1:
                    text_box = shape
                    break

    if text_box is None:
        print("No multi-column text frame was found.")
    else:
        text_frame = text_box.getTextFrame()
        configured_column_count = text_frame.getTextFrameFormat().getColumnCount()
        column_texts = text_frame.splitTextByColumns()

        print(f"Configured columns: {configured_column_count}")

        for column_number, column_text in enumerate(column_texts, start=1):
            print(f"Column {column_number}: {column_text}")
            output_path = Path(f"Column-{column_number}.txt")
            try:
                output_path.write_text(str(column_text), encoding="utf-8")
            except OSError as exception:
                print(f"Could not write column {column_number}: {exception}")
finally:
    presentation.dispose()
```

## **टेक्स्ट अपडेट करें**

किसी प्रस्तुति में पूरे टेक्स्ट को अपडेट करने के लिए, स्लाइड्स और शैप्स पर इटरेट करें, ऑटो शैप्स चुनें, और फिर उनके टेक्स्ट भागों को संपादित करें। भाग‑स्तर पर काम करने से आप टेक्स्ट और कैरेक्टर फ़ॉर्मेट दोनों बदल सकते हैं।

निम्नलिखित उदाहरण ऑटो‑शैप टेक्स्ट में प्रत्येक `years` को `months` से बदलता है और प्रभावित प्रत्येक भाग को बोल्ड बनाता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, NullableBool, Presentation, SaveFormat

presentation = Presentation("Text.pptx")
try:
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if not isinstance(shape, AutoShape):
                continue

            text_frame = shape.getTextFrame()
            if text_frame is None:
                continue

            for paragraph in text_frame.getParagraphs():
                for portion in paragraph.getPortions():
                    text = portion.getText()
                    if text is not None and "years" in str(text):
                        portion.setText(str(text).replace("years", "months"))
                        portion.getPortionFormat().setFontBold(NullableBool.True_)

    presentation.save("TextChanged.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

यह ट्रैवर्सल केवल ऑटो शैप्स में टेक्स्ट अपडेट करता है। टेबल्स, चार्ट्स, SmartArt, या ग्रुपेड शैप्स में संग्रहीत टेक्स्ट को अपडेट करने के लिए उन ऑब्जेक्ट्स के अपने कलेक्शन्स का ट्रैवर्सल आवश्यक है।

## **हाइपरलिंक के साथ टेक्स्ट बॉक्स जोड़ें**

एक हाइपरलिंक को किसी विशिष्ट टेक्स्ट भाग को असाइन किया जा सकता है, जिससे केवल वही टेक्स्ट क्लिक करने योग्य लिंक बनता है। HyperlinkManager.setExternalHyperlinkClick का उपयोग करके उस भाग को बाहरी URL से जोड़ें।

निम्नलिखित उदाहरण लिंक्ड टेक्स्ट बनाता है और उसे प्रस्तुति में सहेजता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 200, 50)
    text_box.addTextFrame("Aspose.Slides")

    text_portion = text_box.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    text_portion.getPortionFormat().getHyperlinkManager().setExternalHyperlinkClick("https://www.aspose.com/")

    presentation.save("Hyperlink.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **अक्सर पूछे जाने वाले प्रश्न**

**मास्टर या लेआउट स्लाइड पर टेक्स्ट बॉक्स और टेक्स्ट प्लेसहोल्डर में क्या अंतर है?**

एक placeholder अपनी स्थिति और फ़ॉर्मेटिंग को मास्टर स्लाइड या लेआउट स्लाइड से वारिस़ प्राप्त कर सकता है। एक सामान्य टेक्स्ट बॉक्स वह स्लाइड पर एक स्वतंत्र शैप है जहाँ इसे बनाया गया था और लेआउट बदलने पर उसे placeholder व्यवहार नहीं मिलता।

**मैं टेक्स्ट को कैसे बदल सकता हूँ बिना चार्ट्स, टेबल्स, या SmartArt में टेक्स्ट बदले?**

ट्रैवर्सल को केवल उन शैप्स तक सीमित रखें जो AutoShape के इंस्टेंस हैं, जैसा कि Update Text उदाहरण में दिखाया गया है। चार्ट्स, टेबल्स, और SmartArt अपने स्वयं के ऑब्जेक्ट मॉडल में टेक्स्ट संग्रहीत करते हैं, इसलिए वह लूप इन्हें नहीं बदलता।