---
title: पैथन के साथ प्रस्तुतियों में टेक्स्ट बॉक्स को प्रबंधित करें
linktitle: टेक्स्ट बॉक्स प्रबंधित करें
type: docs
weight: 20
url: /hi/python-net/manage-textbox/
keywords:
- टेक्स्ट बॉक्स
- टेक्स्ट फ्रेम
- टेक्स्ट जोड़ें
- टेक्स्ट अपडेट करें
- टेक्स्ट बॉक्स बनाएं
- टेक्स्ट बॉक्स जाँचें
- टेक्स्ट कॉलम जोड़ें
- हाइपरलिंक जोड़ें
- पावरपॉइंट
- प्रस्तुतिकरण
- पैथन
- Aspose.Slides
description: "Aspose.Slides for Python via .NET PowerPoint और OpenDocument फ़ाइलों में टेक्स्ट बॉक्स बनाना, संपादित करना और क्लोन करना आसान बनाता है, जिससे आपकी प्रस्तुतिकरण स्वचालन में सुधार होता है।"
---
## **परिचय**

स्लाइड्स पर टेक्स्ट आमतौर पर टेक्स्ट बॉक्स या शेप्स में होते हैं। इसलिए, स्लाइड में टेक्स्ट जोड़ने के लिए, आपको एक टेक्स्ट बॉक्स जोड़ना होता है और फिर उस टेक्स्ट बॉक्स के अंदर कुछ टेक्स्ट रखना होता है। Aspose.Slides for Python [AutoShape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/autoshape/) क्लास प्रदान करता है जो कुछ टेक्स्ट वाले शैप को जोड़ने की अनुमति देता है।

{{% alert title="जानकारी" color="info" %}}

Aspose.Slides additionally [Shape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/shape/) क्लास प्रदान करता है। हालांकि, सभी शैप्स टेक्स्ट रख नहीं सकते।

{{% /alert %}}

{{% alert title="ध्यान" color="warning" %}}

इसलिए, जब आप किसी शैप के साथ काम कर रहे हैं जिससे आप टेक्स्ट जोड़ना चाहते हैं, तो आपको यह जाँचना चाहिए कि वह शैप [AutoShape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/autoshape/) क्लास के माध्यम से कास्ट किया गया है या नहीं। तभी आप [TextFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframe/) के साथ काम कर पाएँगे, जो कि [AutoShape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/autoshape/) की एक प्रॉपर्टी है। इस पेज के [Update Text](/slides/hi/python-net/manage-textbox/#update-text) सेक्शन को देखें।

{{% /alert %}}

## **स्लाइड्स पर टेक्स्ट बॉक्स बनाना**

एक स्लाइड पर टेक्स्ट बॉक्स बनाने के लिये:

1. [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएँ।
2. पहले स्लाइड का रेफ़रेंस प्राप्त करें।
3. स्लाइड पर इच्छित स्थान पर `ShapeType.RECTANGLE` के साथ एक [AutoShape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/autoshape/) जोड़ें।
4. शैप के [TextFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframe/) में टेक्स्ट सेट करें।
5. प्रेजेंटेशन को PPTX फ़ाइल के रूप में सेव करें।

निम्नलिखित Python उदाहरण इन चरणों को लागू करता है:

```py
import aspose.slides as slides

# Presentation क्लास को इंस्टैंसिएट करें।
with slides.Presentation() as presentation:

    # प्रस्तुति में पहली स्लाइड प्राप्त करें।
    slide = presentation.slides[0]

    # RECTANGLE प्रकार का AutoShape जोड़ें।
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 150, 50)

    shape.text_frame.text = "Aspose TextBox"

    # प्रस्तुति को डिस्क पर सहेजें।
    presentation.save("TextBox.pptx", slides.export.SaveFormat.PPTX)
```

## **जाँचें कि क्या शैप टेक्स्ट बॉक्स है**

Aspose.Slides [AutoShape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/autoshape/) क्लास पर [is_text_box](https://reference.aspose.com/slides/hi/python-net/aspose.slides/autoshape/is_text_box/) प्रॉपर्टी प्रदान करता है, जिससे आप निर्धारित कर सकते हैं कि शैप टेक्स्ट बॉक्स है या नहीं।

![Text box and shape](istextbox.png)

यह Python उदाहरण दिखाता है कि कैसे जाँचें कि शैप को टेक्स्ट बॉक्स के रूप में बनाया गया था:

```python
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if isinstance(shape, slides.AutoShape):
                print("shape is a text box" if shape.is_text_box else "shape is not a text box")
```

ध्यान दें कि यदि आप [ShapeCollection](https://reference.aspose.com/slides/hi/python-net/aspose.slides/shapecollection/) क्लास का उपयोग करके एक [AutoShape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/autoshape/) जोड़ते हैं, तो शैप की `is_text_box` प्रॉपर्टी `False` लौटाती है। हालांकि, टेक्स्ट जोड़ने के बाद—चाहे `add_text_frame` मेथड से या `text` प्रॉपर्टी सेट करके—`is_text_box` `True` लौटाती है।

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 40)
    # shape1.is_text_box false है
    shape1.add_text_frame("shape 1")
    # shape1.is_text_box true है

    shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 110, 100, 40)
    # shape2.is_text_box false है
    shape2.text_frame.text = "shape 2"
    # shape2.is_text_box true है

    shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 210, 100, 40)
    # shape3.is_text_box false है
    shape3.add_text_frame("")
    # shape3.is_text_box false है

    shape4 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 310, 100, 40)
    # shape4.is_text_box false है
    shape4.text_frame.text = ""
    # shape4.is_text_box false है
```

## **टेक्स्ट बॉक्स में कॉलम जोड़ें**

Aspose.Slides [TextFrameFormat](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframeformat/) क्लास पर [column_count](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframeformat/column_count/) और [column_spacing](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframeformat/column_spacing/) प्रॉपर्टी प्रदान करता है, जिससे आप टेक्स्ट बॉक्स में कॉलम जोड़ सकते हैं। आप कॉलमों की संख्या निर्दिष्ट कर सकते हैं और कॉलमों के बीच की दूरी (पॉइंट में) सेट कर सकते हैं।

निम्नलिखित Python कोड इस ऑपरेशन को दर्शाता है:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:

	# प्रस्तुति में पहली स्लाइड प्राप्त करें।
	slide = presentation.slides[0]

	# RECTANGLE प्रकार का AutoShape जोड़ें।
	shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 300, 300)

	# आयत में एक TextFrame जोड़ें।
	shape.add_text_frame("All of these columns are confined to a single text container—" +
	"you can add or delete text, and any new or remaining text automatically reflows " +
	"within the container. You cannot have text flow from one container to another, " +
	"though—PowerPoint’s column options for text are limited!")

	# TextFrame का टेक्स्ट फॉर्मेट प्राप्त करें।
	format = shape.text_frame.text_frame_format

	# TextFrame में कॉलमों की संख्या निर्दिष्ट करें।
	format.column_count = 3

	# कॉलमों के बीच की दूरी निर्दिष्ट करें।
	format.column_spacing = 10

	# प्रस्तुति को सहेजें।
	presentation.save("ColumnCount.pptx", slides.export.SaveFormat.PPTX)
```

## **टेक्स्ट अपडेट करें**

Aspose.Slides आपको एकल टेक्स्ट बॉक्स या पूरी प्रेजेंटेशन में टेक्स्ट अपडेट करने की सुविधा देता है।

निम्नलिखित Python उदाहरण पूरी प्रेजेंटेशन में सभी टेक्स्ट को अपडेट करने का तरीका दर्शाता है:

```py
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if type(shape) is slides.AutoShape:
                for paragraph in shape.text_frame.paragraphs:
                    for portion in paragraph.portions:
                        portion.text = portion.text.replace("years", "months")
                        portion.portion_format.font_bold = 1
  
    # संशोधित प्रस्तुति को सहेजें।
    presentation.save("TextChanged.pptx", slides.export.SaveFormat.PPTX)
```

## **हाइपरलिंक वाले टेक्स्ट बॉक्स जोड़ें**

आप टेक्स्ट बॉक्स में एक लिंक सम्मिलित कर सकते हैं। जब टेक्स्ट बॉक्स पर क्लिक किया जाता है, लिंक खुल जाता है।

हाइपरलिंक वाला टेक्स्ट बॉक्स जोड़ने के लिए इन चरणों का पालन करें:

1. [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएँ।
2. पहले स्लाइड का रेफ़रेंस प्राप्त करें।
3. स्लाइड पर इच्छित स्थान पर `ShapeType.RECTANGLE` के साथ एक [AutoShape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/autoshape/) जोड़ें।
4. शैप के [TextFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframe/) में टेक्स्ट सेट करें।
5. [HyperlinkManager](https://reference.aspose.com/slides/hi/python-net/aspose.slides/hyperlinkmanager/) का रेफ़रेंस प्राप्त करें।
6. बाहरी क्लिक हाइपरलिंक सेट करने के लिए `hyperlink_manager` प्रॉपर्टी का उपयोग करें।
7. प्रेजेंटेशन को PPTX फ़ाइल के रूप में सेव करें।

यह Python उदाहरण दिखाता है कि कैसे एक स्लाइड में हाइपरलिंक के साथ टेक्स्ट बॉक्स जोड़ें:

```py
import aspose.slides as slides

# Presentation क्लास को इंस्टैंसिएट करें।
with slides.Presentation() as presentation:

    # प्रस्तुति में पहली स्लाइड प्राप्त करें।
    slide = presentation.slides[0]

    # RECTANGLE प्रकार का AutoShape जोड़ें।
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 150, 150, 50)

    text_portion = shape.text_frame.paragraphs[0].portions[0]

    # फ्रेम में टेक्स्ट जोड़ें।
    text_portion.text = "Aspose.Slides"

    # पोर्शन टेक्स्ट के लिए हाइपरलिंक सेट करें।
    hyperlink_manager = text_portion.portion_format.hyperlink_manager
    hyperlink_manager.set_external_hyperlink_click("http://www.aspose.com")

    # प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।
    presentation.save("Hyperlink.pptx", slides.export.SaveFormat.PPTX)
```

## **अक्सर पूछे जाने वाले प्रश्न**

**मास्टर स्लाइड्स के साथ काम करते समय टेक्स्ट बॉक्स और टेक्स्ट प्लेसहोल्डर में क्या अंतर है?**

एक [placeholder](/slides/hi/python-net/manage-placeholder/) [master](https://reference.aspose.com/slides/hi/python-net/aspose.slides/masterslide/) से स्टाइल/पोजिशन विरासत में लेता है और इसे [layouts](https://reference.aspose.com/slides/hi/python-net/aspose.slides/layoutslide/) पर ओवरराइड किया जा सकता है, जबकि एक सामान्य टेक्स्ट बॉक्स एक विशिष्ट स्लाइड पर स्वतंत्र ऑब्जेक्ट होता है और लेआउट बदलने पर नहीं बदलता।

**मैं कैसे प्रस्तुति में चार्ट, टेबल और SmartArt के भीतर के टेक्स्ट को प्रभावित किए बिना सभी टेक्स्ट का बड़े पैमाने पर प्रतिस्थापन कर सकता हूँ?**

ऑटो-शेप्स जिनके पास टेक्स्ट फ्रेम है, उन तक ही इटरेशन सीमित रखें और एम्बेडेड ऑब्जेक्ट्स ([charts](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chart/), [tables](https://reference.aspose.com/slides/hi/python-net/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/hi/python-net/aspose.slides.smartart/smartart/)) को अलग-अलग उनकी कलेक्शन ट्रैवर्स करके या उन ऑब्जेक्ट टाइप्स को स्किप करके बाहर रखें।