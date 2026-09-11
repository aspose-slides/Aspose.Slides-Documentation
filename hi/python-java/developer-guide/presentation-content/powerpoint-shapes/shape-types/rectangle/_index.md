---
title: Python के माध्यम से Java में प्रस्तुतियों में आयतें जोड़ें
linktitle: आयत
type: docs
weight: 80
url: /hi/python-java/rectangle/
keywords:
- आयत जोड़ें
- आयत बनाएं
- आयत आकार
- साधारण आयत
- स्वरूपित आयत
- PowerPoint
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via Java का उपयोग करके आयतें जोड़कर अपने PowerPoint प्रस्तुतियों को सुदृढ़ करें—आकृतियों को आसानी से प्रोग्रामेटिक रूप से डिज़ाइन और संशोधित करें।"
---
## **अवलोकन**

यह लेख Aspose.Slides का उपयोग करके PowerPoint स्लाइड्स में आयत आकार जोड़ने का तरीका दिखाता है। इसमें एक साधारण आयत बनाना, स्वरूपित आयत बनाना, और अद्यतन प्रस्तुति को PPTX फ़ाइल के रूप में सहेजना शामिल है।

आप तालिका में मूल आयत फ़ॉर्मेटिंग जैसे ठोस भराव रंग, रेखा रंग और रेखा चौड़ाई को लागू करना भी देखेंगे। अतिरिक्त रूप से, लेख के FAQ में गोल किनारे, चित्र भराव, दृश्य प्रभाव, हाइपरलिंक, आकार लॉक, निर्यात विकल्प और प्रभावी गुणों जैसे संबंधित आयत कार्यों की ओर संकेत किया गया है।

## **स्लाइड में आयत जोड़ें**

प्रस्तुति की किसी चयनित स्लाइड में साधारण आयत जोड़ने के लिए, नीचे दिए गए चरणों का पालन करें:

- [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएं।
- स्लाइड को उसके अनुक्रमणिका द्वारा प्राप्त करने का संदर्भ प्राप्त करें।
- [AutoShape](https://reference.aspose.com/slides/hi/python-java/aspose.slides/autoshape/) को आयत प्रकार के रूप में जोड़ें, [ShapeCollection](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shapecollection/) ऑब्जेक्ट द्वारा प्रदान किए गए [addAutoShape](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shapecollection/#addAutoShape) मेथड का उपयोग करके।
- संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।

नीचे दिए गए उदाहरण में हमने प्रस्तुति की पहली स्लाइड में एक साधारण आयत जोड़ी है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

# PPTX फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का उदाहरण बनाएं।
presentation = Presentation()
try:
    # पहली स्लाइड प्राप्त करें।
    slide = presentation.getSlides().get_Item(0)

    # एक आयत आकार जोड़ें।
    slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 50)

    # PPTX फ़ाइल को डिस्क पर लिखें।
    presentation.save("RecShp1.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **स्लाइड में स्वरूपित आयत जोड़ें**

स्लाइड में स्वरूपित आयत जोड़ने के लिए, नीचे दिए गए चरणों का पालन करें:

- [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएं।
- स्लाइड को उसके अनुक्रमणिका द्वारा प्राप्त करने का संदर्भ प्राप्त करें।
- [AutoShape](https://reference.aspose.com/slides/hi/python-java/aspose.slides/autoshape/) को आयत प्रकार के रूप में जोड़ें, [ShapeCollection](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shapecollection/) ऑब्जेक्ट द्वारा प्रदान किए गए [addAutoShape](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shapecollection/#addAutoShape) मेथड का उपयोग करके।
- आयत की [fill type](https://reference.aspose.com/slides/hi/python-java/aspose.slides/filltype/) को solid सेट करें।
- आयत के रंग को [setColor](https://reference.aspose.com/slides/hi/python-java/aspose.slides/colorformat/#setColor) मेथड का उपयोग करके सेट करें, जो [Shape](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shape/) ऑब्जेक्ट से जुड़े [FillFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/fillformat/) ऑब्जेक्ट के सॉलिड फ़िल रंग पर लागू होता है।
- आयत की बाहरी रेखा का रंग सेट करें।
- आयत की बाहरी रेखा की चौड़ाई सेट करें।
- संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।

ऊपर के चरण नीचे दिए गए उदाहरण में लागू किए गए हैं।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

# PPTX फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का उदाहरण बनाएं।
presentation = Presentation()
try:
    # पहली स्लाइड प्राप्त करें।
    slide = presentation.getSlides().get_Item(0)

    # एक आयत आकार जोड़ें।
    rectangle = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 50)

    # आयत के भराव को स्वरूपित करें।
    rectangle.getFillFormat().setFillType(FillType.Solid)
    rectangle.getFillFormat().getSolidFillColor().setColor(Color.GRAY)

    # आयत की रूपरेखा को स्वरूपित करें।
    rectangle.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    rectangle.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    rectangle.getLineFormat().setWidth(5)

    # PPTX फ़ाइल को डिस्क पर लिखें।
    presentation.save("RecShp2.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं गोल किनारों वाली आयत कैसे जोड़ूँ?**  
गोल‑कोनों वाले [shape type](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shapetype/) का उपयोग करें और shape की प्रॉपर्टीज़ में कोने की त्रिज्या समायोजित करें; राउंडिंग को प्रत्येक कोने पर ज्यामिति समायोजन के माध्यम से भी लागू किया जा सकता है।

**मैं आयत को छवि (टेक्सचर) से कैसे भरूँ?**  
चित्र के [fill type](https://reference.aspose.com/slides/hi/python-java/aspose.slides/filltype/) का चयन करें, छवि स्रोत प्रदान करें, और [stretching/tiling modes](https://reference.aspose.com/slides/hi/python-java/aspose.slides/picturefillmode/) को कॉन्फ़िगर करें।

**क्या आयत में शैडो और चमक हो सकती है?**  
हां। [Outer/inner shadow, glow, and soft edges](/slides/hi/python-java/shape-effect/) उपलब्ध हैं और उनके पैरामीटर समायोज्य हैं।

**क्या मैं आयत को एक बटन के रूप में हाइपरलिंक के साथ बना सकता हूँ?**  
हां। shape पर क्लिक करने पर [Assign a hyperlink](/slides/hi/python-java/manage-hyperlinks/) जोड़ें (स्लाइड, फ़ाइल, वेब पता, या ई‑मेल पर जाएँ)।

**मैं आयत को गतिशीलता और बदलावों से कैसे सुरक्षित रखूँ?**  
[Use shape locks](/slides/hi/python-java/applying-protection-to-presentation/): आप प्रवास, आकार बदलने, चयन या टेक्स्ट संपादन को प्रतिबंधित करके लेआउट को सुरक्षित रख सकते हैं।

**क्या मैं आयत को रास्टर इमेज या SVG में बदल सकता हूँ?**  
हां। आप shape को निर्दिष्ट आकार/स्केल के साथ इमेज में [render the shape](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shape/#getImage) कर सकते हैं, या वेक्टर उपयोग के लिए [export it as SVG](/slides/hi/python-java/create-shape-thumbnails/) कर सकते हैं।

**मैं थीम और इनहेरिटेंस को ध्यान में रखते हुए आयत की वास्तविक (प्रभावी) प्रॉपर्टीज़ जल्दी से कैसे प्राप्त करूँ?**  
[Use the shape’s effective properties](/slides/hi/python-java/shape-effective-properties/): API ऐसे मान वापस करता है जो थीम शैलियों, लेआउट और स्थानीय सेटिंग्स को ध्यान में रखते हैं, जिससे फ़ॉर्मेटिंग विश्लेषण सरल हो जाता है।