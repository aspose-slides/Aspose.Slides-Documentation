---
title: Python का उपयोग करके प्रस्तुतियों में रूपों का प्रबंधन
linktitle: रूप परिवर्तन
type: docs
weight: 40
url: /hi/python-net/shape-manipulations/
keywords:
- PowerPoint रूप
- प्रस्तुति रूप
- स्लाइड पर रूप
- रूप खोजें
- रूप क्लोन करें
- रूप हटाएँ
- रूप छिपाएँ
- रूप क्रम बदलें
- इंटरऑप रूप ID प्राप्त करें
- रूप वैकल्पिक पाठ
- रूप लेआउट फ़ॉर्मेट
- रूप SVG के रूप में
- रूप को SVG में
- रूप संरेखित करें
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET में रूप बनाना, संपादित करना और अनुकूलित करना सीखें तथा उच्च-प्रदर्शन PowerPoint और OpenDocument प्रस्तुतियाँ प्रदान करें।"
---
## **परिचय**

यह मार्गदर्शिका Aspose.Slides for Python via .NET में रूप (shape) परिवर्तन को प्रस्तुत करती है। वैकल्पिक पाठ द्वारा सहित रूपों को खोजने, डुप्लिकेट करने, हटाने या छिपाने, पुनः क्रमित करने, संरेखित करने और फ्लिप करने, IDs पढ़ने और लेआउट‑आधारित फॉर्मेटिंग, तथा व्यक्तिगत रूपों को SVG में निर्यात करने के व्यावहारिक पैटर्न सीखें, जो [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) और [Shape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/shape/) API का उपयोग करके किया जाता है।

## **स्लाइड पर रूप खोजें**

PowerPoint केवल आंतरिक IDs के द्वारा रूपों की पहचान करता है। PowerPoint में लक्षित रूप को एक अनोखा Alt Text असाइन करें, फिर Aspose.Slides for Python के साथ प्रस्तुति खोलें, स्लाइड के रूपों पर इटररेट करें, और उस रूप को चुनें जिसका Alt Text मेल खाता हो। `find_shape` मेथड इस दृष्टिकोण को लागू करता है और मिलते‑जुलते रूप को लौटाता है।

```py
import aspose.slides as slides

# स्लाइड पर वैकल्पिक पाठ के द्वारा रूप खोजता है।
def find_shape(slide, alt_text):
    for slide_shape in slide.shapes:
        if slide_shape.alternative_text == alt_text:
            return slide_shape
    return None


# प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का उदाहरण बनाएं।
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    # Alt Text "Shape1" वाले रूप को खोजें।
    shape = find_shape(slide, "Shape1")
    if shape is not None:
        print("Shape name:", shape.name)
```

## **रूप क्लोन करें**

Aspose.Slides में स्रोत स्लाइड से नई स्लाइड में रूपों को क्लोन करने के लिए निम्न चरणों का पालन करें:

1. स्रोत फाइल से एक [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) बनाएं।  
1. इंडेक्स द्वारा स्रोत स्लाइड और उसकी शैप्स कलेक्शन प्राप्त करें।  
1. मास्टर स्लाइड से एक खाली लेआउट प्राप्त करें।  
1. उस लेआउट का उपयोग करके खाली स्लाइड जोड़ें और उसकी शैप्स प्राप्त करें।  
1. लक्ष्य स्लाइड में शैप्स को क्लोन करें।  
1. प्रस्तुति को PPTX के रूप में सहेजें।  

नीचे दिया गया कोड उदाहरण एक स्लाइड से दूसरी स्लाइड में शैप्स को क्लोन करता है।

```py
import aspose.slides as slides

# Presentation क्लास का उदाहरण बनाएं।
with slides.Presentation("sample.pptx") as presentation:
    source_shapes = presentation.slides[0].shapes
    blank_layout = presentation.masters[0].layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    target_slide = presentation.slides.add_empty_slide(blank_layout)
    target_shapes = target_slide.shapes
	
    target_shapes.add_clone(source_shapes[1], 50, 150 + source_shapes[0].height)
    target_shapes.add_clone(source_shapes[2])
    target_shapes.insert_clone(0, source_shapes[0], 50, 150)

    # प्रस्तुति को डिस्क पर सहेजें।
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **रूप हटाएँ**

Aspose.Slides आपको स्लाइड से कोई भी रूप हटाने की अनुमति देता है। उदाहरण के लिए, पहले स्लाइड से उसके वैकल्पिक पाठ के द्वारा रूप को हटाने के लिए निम्न चरणों का पालन करें:

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) इंस्टेंस बनाएं और फाइल लोड करें।  
1. स्लाइड्स कलेक्शन से पहली स्लाइड तक पहुँचें।  
1. वैकल्पिक पाठ के मान द्वारा रूप खोजें।  
1. स्लाइड के शैप्स कलेक्शन से रूप को हटाएँ।  
1. प्रस्तुति को डिस्क पर PPTX फॉर्मेट में सहेजें।  

```py
import aspose.slides as slides

# वैकल्पिक पाठ के द्वारा स्लाइड पर एक रूप खोजता है।
def find_shape(slide, alt_text):
    for slide_shape in slide.shapes:
        if slide_shape.alternative_text == alt_text:
            return slide_shape
    return None


# प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का उदाहरण बनाएं।
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    # Alt Text "User Defined" वाला रूप खोजें।
    shape = find_shape(slide, "User Defined")
    # रूप को हटाएँ।
    slide.shapes.remove(shape)
    # प्रस्तुति को डिस्क पर सहेजें।
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **रूप छिपाएँ**

Aspose.Slides आपको स्लाइड पर कोई भी रूप छिपाने की सुविधा देता है। उदाहरण के लिए, पहले स्लाइड पर उसके वैकल्पिक पाठ के द्वारा रूप को छिपाने के लिए निम्न चरणों का पालन करें:

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) इंस्टेंस बनाएं और फाइल लोड करें।  
1. स्लाइड्स कलेक्शन से पहली स्लाइड तक पहुँचें।  
1. वैकल्पिक पाठ के मान द्वारा रूप खोजें।  
1. रूप को छिपाएँ।  
1. प्रस्तुति को डिस्क पर PPTX फॉर्मेट में सहेजें।  

```py
# वैकल्पिक पाठ के द्वारा स्लाइड पर एक रूप खोजता है।
def find_shape(slide, alt_text):
    for slide_shape in slide.shapes:
        if slide_shape.alternative_text == alt_text:
            return slide_shape
    return None


# प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का उदाहरण बनाएं।
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    # Alt Text "User Defined" वाला रूप खोजें।
    shape = find_shape(slide, "User Defined")
    # रूप को छिपाएँ।
    shape.hidden = True
    # प्रस्तुति को डिस्क पर सहेजें।
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **रूपों का क्रम बदलें**

Aspose.Slides डेवलपर्स को रूपों के z‑order को बदलने (पुनः क्रमित करने) की अनुमति देता है। पुनः क्रमित करने से तय होता है कि कौन‑सा रूप आगे या पीछे दिखेगा। उदाहरण के लिए, पहली स्लाइड पर दो रूपों को पुनः क्रमित करने के लिए नीचे दिए गए चरणों का पालन करें:

1. [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।  
1. पहली स्लाइड तक पहुँचें।  
1. पहला रूप जोड़ें (उदाहरण के लिए, एक आयत)।  
1. दूसरा रूप जोड़ें (उदाहरण के लिए, एक त्रिकोण)।  
1. शैप्स कलेक्शन में दूसरे रूप को पहले स्थान पर ले जाकर क्रम बदलें।  
1. प्रस्तुति को डिस्क पर सहेजें।  

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    # स्लाइड पर दो रूप जोड़ें।
    shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 200, 150)
    shape2 = slide.shapes.add_auto_shape(slides.ShapeType.TRIANGLE, 20, 200, 200, 150)
    # दूसरे रूप को पहले स्थान पर ले जाएँ।
    slide.shapes.reorder(0, shape2)
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **इंटरऑप Shape ID प्राप्त करें**

Aspose.Slides आपको स्लाइड स्तर पर किसी रूप का विशिष्ट पहचानकर्ता प्राप्त करने देता है, जो `unique_id` प्रॉपर्टी से अलग है, जो पूरी प्रस्तुति में अद्वितीय होता है। `office_interop_shape_id` प्रॉपर्टी [Shape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/shape/) क्लास पर उपलब्ध है। इसका मान `Microsoft.Office.Interop.PowerPoint.Shape` ऑब्जेक्ट के `Id` के बराबर होता है। नीचे एक नमूना कोड स्निपेट दिया गया है।

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    # स्लाइड के भीतर रूप का अद्वितीय पहचानकर्ता प्राप्त करें।
    officeInteropShapeId = presentation.slides[0].shapes[0].office_interop_shape_id
```

## **रूपों के लिए वैकल्पिक पाठ सेट करें**

Aspose.Slides डेवलपर्स को कोई भी रूप वैकल्पिक पाठ (Alternative Text) सेट करने की अनुमति देता है। वैकल्पिक पाठ का उपयोग करके आप प्रस्तुति में रूपों की पहचान और लोकेशन कर सकते हैं। वैकल्पिक पाठ प्रॉपर्टी को Aspose.Slides और Microsoft PowerPoint दोनों के माध्यम से पढ़ा और लिखा जा सकता है। इस प्रॉपर्टी से रूप टैग करके आप बाद में उन्हें हटाना, छिपाना या पुनः क्रमित करना आसान बना सकते हैं।

विकल्‍पिक पाठ सेट करने के लिए नीचे दिए गए चरणों का पालन करें:

1. [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।  
1. पहली स्लाइड तक पहुँचें।  
1. स्लाइड पर एक रूप जोड़ें।  
1. वैकल्पिक पाठ सेट करें।  
1. प्रस्तुति को डिस्क पर सहेजें।  

```py
import aspose.slides as slides

# PPTX फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का उदाहरण बनाएं।
with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    # एक रूप जोड़ें।
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 40, 150, 50)
    # रूप के लिए वैकल्पिक पाठ सेट करें।
    shape.alternative_text = "User Defined"
    # प्रस्तुति को डिस्क पर सहेजें।
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **रूपों के लिए लेआउट फॉर्मेट तक पहुँचें**

Aspose.Slides रूपों के लेआउट फॉर्मेट तक पहुँचने के लिए एक सरल API प्रदान करता है। यह भाग लेआउट फॉर्मेट कैसे प्राप्त करें, यह दर्शाता है।

```py
import aspose.slides as slides

with slides.Presentation(folder_path + "sample.pptx") as presentation:
    for layout_slide in presentation.layout_slides:
        fill_formats = list(map(lambda shape: shape.fill_format, layout_slide.shapes))
        line_formats = list(map(lambda shape: shape.line_format, layout_slide.shapes))
```

## **रूपों को SVG के रूप में रेंडर करें**

Aspose.Slides रूपों को SVG के रूप में रेंडर करने का समर्थन करता है। [Shape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/shape/) क्लास पर `write_as_svg` मेथड (और उसके ओवरलोड) आपको रूप की सामग्री को SVG इमेज के रूप में सहेजने देता है। नीचे दिया गया कोड स्निपेट दिखाता है कि कैसे एक रूप को SVG फ़ाइल में निर्यात किया जाए।

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    with open("output.svg", "wb") as image_stream:
        # पहले स्लाइड पर पहला रूप प्राप्त करें।
        shape = presentation.slides[0].shapes[0]
        shape.write_as_svg(image_stream)
```

## **रूप संरेखित करें**

[SlidesUtil](https://reference.aspose.com/slides/hi/python-net/aspose.slides.util/slideutil/) क्लास में `align_shape` मेथड का उपयोग करके आप:

* स्लाइड की मार्जिन के सापेक्ष रूपों को संरेखित कर सकते हैं (उदाहरण 1 देखें)।  
* रूपों को आपस में संरेखित कर सकते हैं (उदाहरण 2 देखें)।  

[ShapesAlignmentType](https://reference.aspose.com/slides/hi/python-net/aspose.slides/shapesalignmenttype/) एन्यूमरेशन उपलब्ध संरेखण विकल्पों को परिभाषित करता है।

**उदाहरण 1**

यह Python कोड दिखाता है कि कैसे सूचकांक 1, 2 और 4 वाले रूपों को स्लाइड के शीर्ष किनारे के सापेक्ष संरेखित किया जाए:

```py
import aspose.slides as slides

align_type = slides.ShapesAlignmentType.ALIGN_TOP
slide_indices = [1, 2, 4]

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    slides.util.SlideUtil.align_shapes(align_type, True, slide, slide_indices)
```

**उदाहरण 2**

यह Python उदाहरण दिखाता है कि कैसे किसी संग्रह में सभी रूपों को उस संग्रह में सबसे नीचे स्थित रूप के सापेक्ष संरेखित किया जाए:

```py
import aspose.slides as slides

align_type = slides.ShapesAlignmentType.ALIGN_BOTTOM

with slides.Presentation("sample.pptx") as presentation:
    slides.util.SlideUtil.align_shapes(align_type, False, presentation.slides[0])
```

## **फ़्लिप प्रॉपर्टीज़**

Aspose.Slides में, [ShapeFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/shapeframe/) क्लास अपने `flip_h` और `flip_v` प्रॉपर्टीज़ के माध्यम से रूपों के क्षैतिज और लम्बवत मिररिंग को नियंत्रित करता है। दोनों प्रॉपर्टीज़ [NullableBool](https://reference.aspose.com/slides/hi/python-net/aspose.slides/nullablebool/) प्रकार की हैं, जहाँ `TRUE` फ़्लिप को दर्शाता है, `FALSE` बिना फ़्लिप के, और `NOT_DEFINED` डिफ़ॉल्ट व्यवहार को लागू करता है। ये मान रूप के [Frame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/shape/frame/) से उपलब्ध हैं।

फ़्लिप सेटिंग्स को बदलने के लिए, एक नया [ShapeFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/shapeframe/) इंस्टेंस बनाते समय रूप की वर्तमान स्थिति, आकार, इच्छित `flip_h` और `flip_v` मान तथा रोटेशन एंगल को पास करें। इस इंस्टेंस को रूप के [Frame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/shape/frame/) में असाइन करने और प्रस्तुति सहेजने पर मिरर परिवर्तन लागू हो जाता है और आउटपुट फ़ाइल में प्रतिबिंबित होता है।

मान लीजिए हमारे पास sample.pptx फ़ाइल है जिसमें पहली स्लाइड पर डिफ़ॉल्ट फ़्लिप सेटिंग के साथ एकल रूप है, जैसा कि नीचे दिखाया गया है।

![फ़्लिप किया जाने वाला रूप](shape_to_be_flipped.png)

निम्न कोड उदाहरण रूप की वर्तमान फ़्लिप प्रॉपर्टीज़ को प्राप्त करता है और उसे क्षैतिज तथा लम्बवत दोनों दिशा में फ़्लिप करता है।

```py
with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    # रूप की क्षैतिज फ़्लिप प्रॉपर्टी प्राप्त करें।
    horizontal_flip = shape.frame.flip_h
    print("Horizontal flip:", horizontal_flip)

    # रूप की लंबवत फ़्लिप प्रॉपर्टी प्राप्त करें।
    vertical_flip = shape.frame.flip_v
    print("Vertical flip:", vertical_flip)

    x, y = shape.frame.x, shape.frame.y
    width, height = shape.frame.width, shape.frame.height
    flip_h, flip_v = slides.NullableBool.TRUE, slides.NullableBool.TRUE  # क्षैतिज तथा लंबवत रूप से फ़्लिप करें।
    rotation = shape.frame.rotation

    shape.frame = slides.ShapeFrame(x, y, width, height, flip_h, flip_v, rotation)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

परिणाम:

![फ़्लिप किया गया रूप](flipped_shape.png)

## **बार‑बार पूछे जाने वाले प्रश्न**

**क्या मैं स्लाइड पर रूपों (union/intersect/subtract) को डेस्कटॉप एडिटर की तरह संयोजित कर सकता हूँ?**

निर्मित बूलियन ऑपरेशन API नहीं है। आप इच्छित रूपरेखा स्वयं बनाकर इसे अपनाने की कोशिश कर सकते हैं—उदाहरण के लिए, परिणामस्वरूप ज्योमेट्री ( [GeometryPath](https://reference.aspose.com/slides/hi/python-net/aspose.slides/geometrypath/) के द्वारा) की गणना करके उस कंटूर के साथ नया रूप बनायें, तथा मूल रूपों को वैकल्पिक रूप से हटा दें।

**मैं स्टैकिंग ऑर्डर (z‑order) को कैसे नियंत्रित करूँ जिससे कोई रूप हमेशा “ऊपर” रहे?**

स्लाइड के [shapes](https://reference.aspose.com/slides/hi/python-net/aspose.slides/slide/shapes/) संग्रह में सम्मिलन/हिलाने का क्रम बदलें। पूर्वानुमेय परिणामों के लिए सभी अन्य स्लाइड संशोधनों के बाद z‑order को अंतिम रूप दें।

**क्या मैं PowerPoint में उपयोगकर्ताओं को रूप संपादित करने से रोकने के लिए उसे “लॉक” कर सकता हूँ?**

हां। [shape-level protection flags](/slides/hi/python-net/applying-protection-to-presentation/) सेट करें (जैसे चयन, मूवमेंट, रिसाइज़, टेक्स्ट एडिट को लॉक करना)। आवश्यक होने पर मास्टर या लेआउट पर प्रतिबंध प्रतिबिंबित करें। इसे UI‑स्तर का संरक्षण माना जाता है, न कि सुरक्षा फीचर; अधिक मजबूत सुरक्षा के लिए इसे फ़ाइल‑स्तर के प्रतिबंधों जैसे [read‑only सुझाव या पासवर्ड](/slides/hi/python-net/password-protected-presentation/) के साथ संयोजन में उपयोग करें।