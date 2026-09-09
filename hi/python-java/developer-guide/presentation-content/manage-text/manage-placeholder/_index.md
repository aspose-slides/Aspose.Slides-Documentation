---
title: Python में प्रस्तुति प्लेसहोल्डर का प्रबंधन
linktitle: प्लेसहोल्डर प्रबंधन
type: docs
weight: 10
url: /hi/python-java/manage-placeholder/
keywords:
- प्लेसहोल्डर
- पाठ प्लेसहोल्डर
- छवि प्लेसहोल्डर
- चार्ट प्लेसहोल्डर
- सामग्री प्लेसहोल्डर
- प्रॉम्प्ट टेक्स्ट
- PowerPoint
- प्रस्तुति
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java के साथ प्लेसहोल्डर की जाँच, टेक्स्ट, चित्र, चार्ट और सामग्री प्लेसहोल्डर को संपादित करना तथा प्लेसहोल्डर विरासत को समझना सीखें।"
---
## **परिचय**

एक placeholder एक shape है जो प्रस्तुति टेम्पलेट में किसी विशेष प्रकार की सामग्री के लिए स्थान आरक्षित करता है। सामान्य उदाहरणों में title, body, picture, chart, और सामान्य‑उद्देश्य के सामग्री placeholders शामिल हैं। एक सामान्य shape के विपरीत, एक placeholder अपनी स्थिति, आकार, फ़ॉर्मेटिंग और अन्य सेटिंग्स को layout slide या master slide से विरासत में प्राप्त कर सकता है।

Aspose.Slides placeholder जानकारी को [Shape.getPlaceholder](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shape/#getPlaceholder) मेथड के माध्यम से उजागर करता है। यह मेथड एक [Placeholder](https://reference.aspose.com/slides/hi/python-java/aspose.slides/placeholder/) ऑब्जेक्ट लौटाता है या सामान्य shape के लिए `None`। placeholder के उद्देश्य को निर्धारित करने के लिए [Placeholder.getType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/placeholder/#getType) का उपयोग करें।

shape प्रकार का महत्व placeholder प्रकार जानने के बाद भी बना रहता है:

- एक खाली text, picture, chart, या content placeholder आमतौर पर एक [AutoShape](https://reference.aspose.com/slides/hi/python-java/aspose.slides/autoshape/) द्वारा दर्शाया जाता है।
- एक भराया गया picture placeholder एक [PictureFrame](https://reference.aspose.com/slides/hi/python-java/aspose.slides/pictureframe/) द्वारा प्रतिनिधित्व किया जा सकता है।
- एक भराया गया chart placeholder एक [Chart](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chart/) द्वारा प्रतिनिधित्व किया जा सकता है।
- एक content placeholder कई प्रकार की सामग्री रख सकता है। यह मानने के बजाय कि हर placeholder एक [AutoShape](https://reference.aspose.com/slides/hi/python-java/aspose.slides/autoshape/) है, दोनों [Placeholder.getType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/placeholder/#getType) और runtime shape type की जाँच करें।

{{% alert color="warning" title="Warning" %}}
[Placeholder.getType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/placeholder/#getType) describes a placeholder's role; it does not guarantee the shape's runtime type. Always use a type check before accessing text, picture, chart, table, or media-specific members.
{{% /alert %}}

## **Placeholder विरासत को समझें**

Placeholders एक पदानुक्रम बनाते हैं:

1. एक master slide पुन: प्रयोग योग्य शैलियों को परिभाषित करता है और कुछ मामलों में master‑level placeholders भी।
2. एक layout slide वह व्यवस्था परिभाषित करता है जिसका उपयोग एक या अधिक सामान्य slides करते हैं और यह master से विरासत प्राप्त कर सकता है।
3. एक सामान्य slide उस slide के लिए placeholders रखता है और अपना layout से विरासत ले सकता है।

[Shape.getBasePlaceholder](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shape/#getBasePlaceholder) को कॉल करके इस पदानुक्रम में एक स्तर ऊपर जा सकते हैं। एक slide placeholder आमतौर पर अपना layout placeholder लौटाता है; एक layout placeholder अपना master placeholder लौटा सकता है। जब shape के पास कोई base placeholder नहीं होता तो यह मेथड `None` लौटाता है।

निम्न उदाहरण पहले slide पर placeholders को सूचीबद्ध करता है और उनके base placeholders को रिपोर्ट करता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        placeholder = shape.getPlaceholder()
        if placeholder is None:
            continue

        placeholder_type = placeholder.getType()
        type_name = shape.getClass().getSimpleName()
        print(f"Slide placeholder: {placeholder_type}; shape type: {type_name}")

        layout_placeholder = shape.getBasePlaceholder()
        if layout_placeholder is not None:
            layout_placeholder_info = layout_placeholder.getPlaceholder()
            layout_placeholder_type = None if layout_placeholder_info is None else layout_placeholder_info.getType()
            print(f"  Layout placeholder: {layout_placeholder_type}")

            master_placeholder = layout_placeholder.getBasePlaceholder()
            if master_placeholder is not None:
                master_placeholder_info = master_placeholder.getPlaceholder()
                master_placeholder_type = None if master_placeholder_info is None else master_placeholder_info.getType()
                print(f"  Master placeholder: {master_placeholder_type}")
finally:
    presentation.dispose()
```

एक सामान्य slide पर placeholder को संपादित करने से उस slide के लिए स्थानीय ओवरराइड बनता या बदलता है। संबंधित layout या master को संपादित करने से उन सभी slides पर प्रभाव पड़ सकता है जो अभी भी वह सेटिंग विरासत में ले रही हैं। एक स्थानीय सामान्य shape का कोई base placeholder नहीं होता और केवल समान निर्देशांक होने पर वह विरासत नहीं शुरू करता।

## **Placeholder में टेक्स्ट बदलें**

title, centered-title, subtitle, body, और text placeholders सामान्यतः टेक्स्ट का समर्थन करते हैं। इसका [getTextFrame](https://reference.aspose.com/slides/hi/python-java/aspose.slides/autoshape/#getTextFrame) मेथड उपयोग करने से पहले [AutoShape](https://reference.aspose.com/slides/hi/python-java/aspose.slides/autoshape/) की जाँच करें।

यह उदाहरण पहले slide पर पहला title placeholder अपडेट करता है और परिणाम सहेजता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, AutoShape, PlaceholderType, SaveFormat

presentation = Presentation("template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    title_shape = None

    for shape in slide.getShapes():
        if not isinstance(shape, AutoShape):
            continue

        placeholder = shape.getPlaceholder()
        if placeholder is None:
            continue

        placeholder_type = placeholder.getType()
        if placeholder_type in (PlaceholderType.Title, PlaceholderType.CenteredTitle):
            title_shape = shape
            break

    if title_shape is None:
        print("The first slide does not contain a title placeholder.")
    else:
        title_shape.getTextFrame().setText("Quarterly Business Review")
        presentation.save("title-placeholder-updated.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

यह पैटर्न picture, chart, table, या media placeholders को [AutoShape](https://reference.aspose.com/slides/hi/python-java/aspose.slides/autoshape/) के रूप में मानने से बचाता है। यह placeholder को उसके उद्देश्य के आधार पर पहचानता है न कि अस्थिर shape इंडेक्स पर निर्भर रहने से।

## **Layout पर Prompt Text सेट करें**

Prompt text वह डिजाइन‑टाइम निर्देश है जो एक खाली placeholder में दिखाया जाता है, जैसे *Click to add title*। इसे सामान्य slide के shape संग्रह के माध्यम से प्राप्त करने की कोशिश करने के बजाय layout placeholder पर कस्टम prompt text सेट करें। layout को [Slide.getLayoutSlide](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slide/#getLayoutSlide) के माध्यम से पहुँचें और [BaseSlide.getShapes](https://reference.aspose.com/slides/hi/python-java/aspose.slides/baseslide/#getShapes) द्वारा लौटाए गए संग्रह पर इटररेट करें।

निम्न उदाहरण पहला slide द्वारा उपयोग किए गए layout पर title और subtitle prompts को बदलता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, AutoShape, PlaceholderType, SaveFormat

presentation = Presentation("template.pptx")
try:
    layout_slide = presentation.getSlides().get_Item(0).getLayoutSlide()

    for shape in layout_slide.getShapes():
        if not isinstance(shape, AutoShape):
            continue

        placeholder = shape.getPlaceholder()
        if placeholder is None:
            continue

        placeholder_type = placeholder.getType()
        if placeholder_type in (PlaceholderType.Title, PlaceholderType.CenteredTitle):
            shape.getTextFrame().setText("Enter a concise slide title")
        elif placeholder_type == PlaceholderType.Subtitle:
            shape.getTextFrame().setText("Enter a subtitle or reporting period")

    presentation.save("custom-placeholder-prompts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Prompt text सामान्य slide सामग्री नहीं है। यह PowerPoint जैसे संपादन अनुप्रयोगों में खाली placeholders के लिए अभिप्रेरणा के रूप में intended है। एक बार उपयोगकर्ता या प्रोग्राम वास्तविक सामग्री प्रदान कर देता है, prompt अब नहीं दिखेगा। Prompt बदलने से वह slides के मौजूदा टेक्स्ट को भी नहीं हटाता जो उस layout का उपयोग कर रहे हैं।

## **Picture Placeholder को अपडेट करें**

हैंडल करने के दो केस हैं:

- यदि picture placeholder पहले से भरा हुआ है और एक [PictureFrame](https://reference.aspose.com/slides/hi/python-java/aspose.slides/pictureframe/) द्वारा दर्शाया गया है, तो [PictureFillFormat.getPicture](https://reference.aspose.com/slides/hi/python-java/aspose.slides/picturefillformat/#getPicture) और [Picture.setImage](https://reference.aspose.com/slides/hi/python-java/aspose.slides/picture/#setImage) के माध्यम से इमेज बदलें।
- यदि यह अभी भी एक खाली placeholder है, तो [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shapecollection/#addPictureFrame) से placeholder के निर्देशांक पर एक picture frame जोड़ें और खाली placeholder को हटाएँ।

अगला उदाहरण दोनों मामलों को सपोर्ट करता है और प्रस्तुति को सहेजता है:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, PictureFrame, PlaceholderType, ShapeType, SaveFormat

presentation = Presentation("picture-template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    picture_placeholder = None

    for shape in slide.getShapes():
        placeholder = shape.getPlaceholder()
        if placeholder is not None and placeholder.getType() == PlaceholderType.Picture:
            picture_placeholder = shape
            break

    if picture_placeholder is None:
        print("The first slide does not contain a picture placeholder.")
    else:
        image_bytes = Path("replacement.png").read_bytes()
        java_image_bytes = jpype.JArray(jpype.JByte)(image_bytes)
        image = presentation.getImages().addImage(java_image_bytes)

        if isinstance(picture_placeholder, PictureFrame):
            picture_placeholder.getPictureFormat().getPicture().setImage(image)
        else:
            slide.getShapes().addPictureFrame(ShapeType.Rectangle, picture_placeholder.getX(), picture_placeholder.getY(), picture_placeholder.getWidth(), picture_placeholder.getHeight(), image)
            slide.getShapes().remove(picture_placeholder)

        presentation.save("picture-placeholder-updated.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

खाली placeholder के लिए बनाई गई प्रतिस्थापन एक स्थानीय picture frame है, नया placeholder नहीं, क्योंकि [Shape.getPlaceholder](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shape/#getPlaceholder) में setter नहीं है। यह आरक्षित स्थान को रखता है लेकिन अब placeholder‑विशिष्ट व्यवहार विरासत में नहीं लेता। यदि placeholder संबंध बनाए रखना आवश्यक है, तो पहले PowerPoint में placeholder तैयार और भरें, फिर Aspose.Slides से प्राप्त [PictureFrame](https://reference.aspose.com/slides/hi/python-java/aspose.slides/pictureframe/) को अपडेट करें।

इमेज ट्रांसपैरेंसी, क्रॉपिंग और अन्य picture‑विशिष्ट प्रभावों के लिए देखें [Manage Picture Frames](/slides/hi/python-java/picture-frame/)। ये ऑपरेशन्स picture frame या picture fill से जुड़े होते हैं, placeholder मेटाडाटा से नहीं।

## **Chart और Content Placeholders के साथ काम करें**

एक भरा हुआ chart placeholder एक [Chart](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chart/) द्वारा दर्शाया जा सकता है। यह उदाहरण placeholder प्रकार और runtime प्रकार दोनों से ऐसा chart खोजता है, उसका शीर्षक बदलता है, और फ़ाइल सहेजता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Chart, PlaceholderType, SaveFormat

presentation = Presentation("chart-template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    placeholder_chart = None

    for shape in slide.getShapes():
        if not isinstance(shape, Chart):
            continue

        placeholder = shape.getPlaceholder()
        if placeholder is not None and placeholder.getType() == PlaceholderType.Chart:
            placeholder_chart = shape
            break

    if placeholder_chart is None:
        print("The first slide does not contain a populated chart placeholder.")
    else:
        placeholder_chart.setTitle(True)
        placeholder_chart.getChartTitle().addTextFrameForOverriding("Quarterly Revenue")
        presentation.save("chart-placeholder-updated.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

एक सामान्य content placeholder आमतौर पर [PlaceholderType.Object](https://reference.aspose.com/slides/hi/python-java/aspose.slides/placeholdertype/#Object) रखता है। PowerPoint में यह कई सामग्री प्रकारों के लिए लॉन्चर के रूप में कार्य करता है, जिनमें charts, tables, diagrams, pictures, और media शामिल हैं। एक बार यह भर जाने के बाद, वास्तविक shape प्रकार की जाँच करें ताकि पता चले यह क्या रखता है। विशेष layouts भी [PlaceholderType.Chart](https://reference.aspose.com/slides/hi/python-java/aspose.slides/placeholdertype/#Chart), [PlaceholderType.Table](https://reference.aspose.com/slides/hi/python-java/aspose.slides/placeholdertype/#Table), [PlaceholderType.Picture](https://reference.aspose.com/slides/hi/python-java/aspose.slides/placeholdertype/#Picture), [PlaceholderType.Media](https://reference.aspose.com/slides/hi/python-java/aspose.slides/placeholdertype/#Media), या [PlaceholderType.Diagram](https://reference.aspose.com/slides/hi/python-java/aspose.slides/placeholdertype/#Diagram) दर्शा सकते हैं।

Aspose.Slides केवल [Placeholder.getType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/placeholder/#getType) को बदलकर एक खाली [AutoShape](https://reference.aspose.com/slides/hi/python-java/aspose.slides/autoshape/) placeholder को [Chart](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chart/) में नहीं बदलता; प्रकार API के माध्यम से बदल नहीं सकता। खाली chart या content क्षेत्र को प्रोग्रामmatically भरने के लिए, placeholder के निर्देशांक पर आवश्यक वस्तु जोड़ें और फिर खाली placeholder को हटाएँ। निम्न उदाहरण ऐसा chart के लिए करता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, PlaceholderType, ChartType, SaveFormat

presentation = Presentation("content-template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    target_placeholder = None

    for shape in slide.getShapes():
        placeholder = shape.getPlaceholder()
        if placeholder is None:
            continue

        placeholder_type = placeholder.getType()
        if placeholder_type in (PlaceholderType.Chart, PlaceholderType.Object):
            target_placeholder = shape
            break

    if target_placeholder is None:
        print("The first slide does not contain a chart or content placeholder.")
    else:
        chart = slide.getShapes().addChart(ChartType.ClusteredColumn, target_placeholder.getX(), target_placeholder.getY(), target_placeholder.getWidth(), target_placeholder.getHeight())
        chart.setTitle(True)
        chart.getChartTitle().addTextFrameForOverriding("Quarterly Revenue")
        slide.getShapes().remove(target_placeholder)
        presentation.save("content-placeholder-replaced-with-chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

जोड़ी गई chart एक सामान्य स्थानीय chart है। यह placeholder के क्षेत्र को घेरती है लेकिन layout placeholder से विरासत नहीं लेती। जब आपको उसकी श्रेणियों, series, या workbook डेटा को बदलना हो तो समर्पित [chart management articles](/slides/hi/python-java/powerpoint-charts/) का उपयोग करें।

## **पूरा उदाहरण: टेक्स्ट या इमेज सामग्री अपडेट करें**

निम्न end‑to‑end उदाहरण एक टेम्पलेट खोलता है, पहले slide में title या picture placeholder खोजता है, placeholder और shape प्रकारों की जाँच करता है, उपयुक्त सामग्री को अपडेट करता है, और आउटपुट सहेजता है। यह उदाहरण स्पष्ट रूप से shape इंडेक्स मानने या हर placeholder को एक ही प्रकार मानने से बचता है।

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, AutoShape, PictureFrame, PlaceholderType, ShapeType, SaveFormat

presentation = Presentation("template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    updated = False

    for shape in slide.getShapes():
        placeholder = shape.getPlaceholder()
        if placeholder is None:
            continue

        placeholder_type = placeholder.getType()
        if placeholder_type in (PlaceholderType.Title, PlaceholderType.CenteredTitle) and isinstance(shape, AutoShape):
            shape.getTextFrame().setText("Quarterly Business Review")
            updated = True
            break

        if placeholder_type == PlaceholderType.Picture:
            image_bytes = Path("replacement.png").read_bytes()
            java_image_bytes = jpype.JArray(jpype.JByte)(image_bytes)
            image = presentation.getImages().addImage(java_image_bytes)

            if isinstance(shape, PictureFrame):
                shape.getPictureFormat().getPicture().setImage(image)
            else:
                slide.getShapes().addPictureFrame(ShapeType.Rectangle, shape.getX(), shape.getY(), shape.getWidth(), shape.getHeight(), image)
                slide.getShapes().remove(shape)

            updated = True
            break

    if updated:
        presentation.save("placeholder-content-updated.pptx", SaveFormat.Pptx)
    else:
        print("No supported title or picture placeholder was found on the first slide.")
finally:
    presentation.dispose()
```

## **अक्सर पूछे जाने वाले प्रश्न**

**एक base placeholder क्या है?**

एक base placeholder वह संबंधित shape है जो layout या master पर स्थित होता है, जिससे दूसरा placeholder विरासत में लेता है। इसे प्राप्त करने के लिए [Shape.getBasePlaceholder](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shape/#getBasePlaceholder) का उपयोग करें। एक सामान्य स्थानीय shape `None` लौटाता है क्योंकि वह placeholder पदानुक्रम का हिस्सा नहीं है।

**क्या मैं सभी slide शीर्षकों को layout placeholder को संपादित करके बदल सकता हूँ?**

आप layout के माध्यम से विरासत में मिली फ़ॉर्मेटिंग या prompt text बदल सकते हैं, लेकिन मौजूदा शीर्षक सामग्री सामान्य slides पर संग्रहीत होती है। पूरे प्रस्तुति में वास्तविक शीर्षक टेक्स्ट को बदलने के लिए slides पर इटररेट करें और प्रत्येक title placeholder को अपडेट करें।

**मैं तिथि, slide‑number, header, और footer placeholders को कैसे प्रबंधित करूँ?**

उपयुक्त slide, layout, master, notes, या handout स्तर पर हेडर और फूटर प्रबंधकों का उपयोग करें। पूर्ण उदाहरणों के लिए देखें [Manage Presentation Header and Footer](/slides/hi/python-java/presentation-header-and-footer/).