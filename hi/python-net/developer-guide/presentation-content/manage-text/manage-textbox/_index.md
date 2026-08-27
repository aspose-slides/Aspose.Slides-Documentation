---
title: "Python के साथ प्रस्तुतियों में टेक्स्ट बॉक्स प्रबंधित करें"
linktitle: "टेक्स्ट बॉक्स प्रबंधित करें"
type: docs
weight: 20
url: /hi/python-net/manage-textbox/
keywords:
- "टेक्स्ट बॉक्स"
- "टेक्स्ट फ्रेम"
- "टेक्स्ट जोड़ें"
- "टेक्स्ट अपडेट करें"
- "टेक्स्ट बॉक्स बनाएं"
- "टेक्स्ट बॉक्स जांचें"
- "टेक्स्ट कॉलम जोड़ें"
- "हाइपरलिंक जोड़ें"
- "PowerPoint"
- "प्रेजेंटेशन"
- "Python"
- "Aspose.Slides"
description: "Aspose.Slides for Python via .NET PowerPoint और OpenDocument फ़ाइलों में टेक्स्ट बॉक्स बनाने, संपादित करने और क्लोन करने को आसान बनाता है, जिससे आपके प्रेजेंटेशन ऑटोमेशन में सुधार होता है।"
---
## **परिचय**

स्लाइड में टेक्स्ट आमतौर पर टेक्स्ट बॉक्स या शैप में मौजूद होते हैं। इसलिए, स्लाइड में टेक्स्ट जोड़ने के लिए आपको पहले एक टेक्स्ट बॉक्स बनाना होगा और फिर उस बॉक्स में टेक्स्ट डालना होगा। Aspose.Slides for Python [AutoShape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/autoshape/) क्लास प्रदान करता है जो आपको टेक्स्ट वाला शैप जोड़ने की अनुमति देता है।

{{% alert title="Info" color="info" %}}
Aspose.Slides additionally [Shape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/shape/) क्लास भी प्रदान करता है। हालांकि, सभी शैप्स टेक्स्ट रख नहीं सकते।
{{% /alert %}}

{{% alert title="Note" color="warning" %}}
इसलिए, जब आप किसी शैप के साथ काम कर रहे हों जिसमें आप टेक्स्ट जोड़ना चाहते हैं, तो आपको यह सत्यापित करना चाहिए कि वह शैप [AutoShape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/autoshape/) क्लास के माध्यम से कास्ट किया गया है। तभी आप [TextFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframe/) के साथ काम कर पाएँगे, जो कि [AutoShape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/autoshape/) की एक प्रॉपर्टी है। इस पेज के [Update Text](/slides/hi/python-net/manage-textbox/#update-text) सेक्शन को देखें।
{{% /alert %}}

## **स्लाइड पर टेक्स्ट बॉक्स बनाना**

स्लाइड पर टेक्स्ट बॉक्स बनाने के चरण:

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास की इंस्टेंस बनाएँ।
2. पहली स्लाइड का रेफरेंस प्राप्त करें।
3. इच्छित位置 पर `ShapeType.RECTANGLE` के साथ एक [AutoShape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/autoshape/) जोड़ें।
4. शैप के [TextFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframe/) में टेक्स्ट सेट करें।
5. प्रेजेंटेशन को PPTX फ़ाइल के रूप में सहेजें।

निम्नलिखित Python उदाहरण इन चरणों को लागू करता है:

```py
import aspose.slides as slides

# Presentation class का इंस्टेंस बनाएं।
with slides.Presentation() as presentation:

    # प्रेजेंटेशन में पहली स्लाइड प्राप्त करें।
    slide = presentation.slides[0]

    # RECTANGLE प्रकार का AutoShape जोड़ें।
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 150, 50)

    shape.text_frame.text = "Aspose TextBox"

    # प्रेजेंटेशन को डिस्क पर सहेजें।
    presentation.save("TextBox.pptx", slides.export.SaveFormat.PPTX)
```

## **जांचें कि शैप टेक्स्ट बॉक्स है या नहीं**

Aspose.Slides [AutoShape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/autoshape/) क्लास पर [is_text_box](https://reference.aspose.com/slides/hi/python-net/aspose.slides/autoshape/is_text_box/) प्रॉपर्टी प्रदान करता है, जिससे आप यह निर्धारित कर सकते हैं कि शैप टेक्स्ट बॉक्स है या नहीं।

![Text box and shape](istextbox.png)

यह Python उदाहरण दिखाता है कि शैप को टेक्स्ट बॉक्स के रूप में कैसे जाँचें:

```python
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if isinstance(shape, slides.AutoShape):
                print("shape is a text box" if shape.is_text_box else "shape is not a text box")
```

ध्यान दें कि यदि आप [ShapeCollection](https://reference.aspose.com/slides/hi/python-net/aspose.slides/shapecollection/) क्लास का उपयोग करके एक [AutoShape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/autoshape/) जोड़ते हैं, तो शैप की `is_text_box` प्रॉपर्टी `False` लौटाती है। लेकिन जब आप टेक्स्ट जोड़ते हैं—या तो `add_text_frame` मेथड से या `text` प्रॉपर्टी सेट करके—`is_text_box` `True` लौटाता है।

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

## **उस शैप को खोजें जो टेक्स्ट फ्रेम का मालिक है**

सामान्य टेक्स्ट‑प्रॉसेसिंग कोड में आपको एक [TextFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframe/) मिल सकता है, लेकिन यह नहीं पता होता कि कौन सा प्रेजेंटेशन ऑब्जेक्ट इसे धारण करता है। मालिक शैप पर जाने के लिए आप [TextFrame.parent_shape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframe/parent_shape/) प्रॉपर्टी का उपयोग करें।

यदि टेक्स्ट फ्रेम कोई [AutoShape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/autoshape/) या अन्य टेक्स्ट‑धारक शैप से संबंधित है, तो [TextFrame.parent_shape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframe/parent_shape/) सेट होता है और [TextFrame.parent_cell](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframe/parent_cell/) `None` रहता है। दोनों प्रॉपर्टी केवल‑पढ़ने योग्य नेविगेशन प्रॉपर्टी हैं, इसलिए उनका उपयोग करने से स्वामित्व नहीं बदलता। हमेशा शैप एक्सेस करने से पहले `None` के लिए जाँचें।

शैप और टेबल‑सेल मालिकों की पहचान करने वाले पूर्ण उदाहरण, जिसमें SmartArt नोड्स से जुड़े शैप्स भी शामिल हैं, के लिए देखें [Search and Replace Text](/slides/hi/python-net/search-and-replace-text/)।

## **टेक्स्ट बॉक्स में कॉलम जोड़ना**

Aspose.Slides [TextFrameFormat](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframeformat/) क्लास पर [column_count](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframeformat/column_count/) और [column_spacing](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframeformat/column_spacing/) प्रॉपर्टी प्रदान करता है, जिससे आप टेक्स्ट बॉक्स में कॉलम जोड़ सकते हैं। आप कॉलमों की संख्या और कॉलमों के बीच की दूरी (पॉइंट्स में) निर्धारित कर सकते हैं।

निम्नलिखित Python कोड इस ऑपरेशन को दर्शाता है:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:

	# प्रेजेंटेशन में पहली स्लाइड प्राप्त करें।
	slide = presentation.slides[0]

	# RECTANGLE प्रकार का AutoShape जोड़ें।
	shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 300, 300)

	# आयत में एक TextFrame जोड़ें।
	shape.add_text_frame("All of these columns are confined to a single text container—" +
	"you can add or delete text, and any new or remaining text automatically reflows " +
	"within the container. You cannot have text flow from one container to another, " +
	"though—PowerPoint’s column options for text are limited!")

	# TextFrame का टेक्स्ट फ़ॉर्मेट प्राप्त करें।
	format = shape.text_frame.text_frame_format

	# TextFrame में कॉलमों की संख्या निर्धारित करें।
	format.column_count = 3

	# कॉलमों के बीच की दूरी निर्धारित करें।
	format.column_spacing = 10

	# प्रेजेंटेशन को सहेजें।
	presentation.save("ColumnCount.pptx", slides.export.SaveFormat.PPTX)
```

## **टेक्स्ट अपडेट करना**

Aspose.Slides आपको एकल टेक्स्ट बॉक्स या पूरी प्रेजेंटेशन में टेक्स्ट अपडेट करने की अनुमति देता है।

निम्नलिखित Python उदाहरण दिखाता है कि प्रेजेंटेशन में सभी टेक्स्ट को कैसे अपडेट करें:

```py
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if type(shape) is slides.AutoShape:
                for paragraph in shape.text_frame.paragraphs:
                    for portion in paragraph.portions:
                        portion.text = portion.text.replace("years", "months")
                        portion.portion_format.font_bold = slides.NullableBool.TRUE
  
    # संशोधित प्रेजेंटेशन को सहेजें।
    presentation.save("TextChanged.pptx", slides.export.SaveFormat.PPTX)
```

## **हाइपरलिंक के साथ टेक्स्ट बॉक्स जोड़ना**

आप टेक्स्ट बॉक्स में लिंक सम्मिलित कर सकते हैं। जब टेक्स्ट बॉक्स पर क्लिक किया जाता है, तो लिंक खुल जाता है।

हाइपरलिंक वाला टेक्स्ट बॉक्स जोड़ने के चरण:

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास की इंस्टेंस बनाएँ।
2. पहली स्लाइड का रेफरेंस प्राप्त करें।
3. इच्छित位置 पर `ShapeType.RECTANGLE` के साथ एक [AutoShape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/autoshape/) जोड़ें।
4. शैप के [TextFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframe/) में टेक्स्ट सेट करें।
5. [HyperlinkManager](https://reference.aspose.com/slides/hi/python-net/aspose.slides/hyperlinkmanager/) का रेफरेंस प्राप्त करें।
6. `hyperlink_manager` प्रॉपर्टी का उपयोग करके बाह्य क्लिक हाइपरलिंक सेट करें।
7. प्रेजेंटेशन को PPTX फ़ाइल के रूप में सहेजें।

यह Python उदाहरण दिखाता है कि स्लाइड में हाइपरलिंक के साथ टेक्स्ट बॉक्स कैसे जोड़ें:

```py
import aspose.slides as slides

# Presentation क्लास का इंस्टेंस बनाएं।
with slides.Presentation() as presentation:

    # प्रेजेंटेशन में पहली स्लाइड प्राप्त करें।
    slide = presentation.slides[0]

    # RECTANGLE प्रकार का AutoShape जोड़ें।
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 150, 150, 50)

    text_portion = shape.text_frame.paragraphs[0].portions[0]

    # फ़्रेम में टेक्स्ट जोड़ें।
    text_portion.text = "Aspose.Slides"

    # भाग टेक्स्ट के लिए हाइपरलिंक सेट करें।
    hyperlink_manager = text_portion.portion_format.hyperlink_manager
    hyperlink_manager.set_external_hyperlink_click("http://www.aspose.com")

    # प्रेजेंटेशन को PPTX फ़ाइल के रूप में सहेजें।
    presentation.save("Hyperlink.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**मास्टर स्लाइड्स के साथ काम करते समय टेक्स्ट बॉक्स और टेक्स्ट प्लेसहोल्डर में क्या अंतर है?**

एक [placeholder](/slides/hi/python-net/manage-placeholder/) अपनी शैली/स्थिति को [master](https://reference.aspose.com/slides/hi/python-net/aspose.slides/masterslide/) से विरासत में लेता है और इसे [layouts](https://reference.aspose.com/slides/hi/python-net/aspose.slides/layoutslide/) पर ओवरराइड किया जा सकता है, जबकि सामान्य टेक्स्ट बॉक्स एक स्वतंत्र ऑब्जेक्ट है जो किसी विशिष्ट स्लाइड पर रहता है और लेआउट बदलने पर नहीं बदलता।

**मैं प्रेजेंटेशन में टेक्स्ट को बड़े पैमाने पर बदलना चाहता हूँ, लेकिन चार्ट, टेबल और SmartArt के अंदर के टेक्स्ट को नहीं छूना चाहता, तो कैसे करूँ?**

ऑटो‑शैप्स को फ़िल्टर करें जिनमें टेक्स्ट फ्रेम हों और एम्बेडेड ऑब्जेक्ट्स ([charts](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chart/), [tables](https://reference.aspose.com/slides/hi/python-net/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/hi/python-net/aspose.slides.smartart/smartart/)) को उनके कलेक्शन्स को अलग‑अलग ट्रैवर्स करके या उन प्रकारों को स्किप करके छोड़ दें।