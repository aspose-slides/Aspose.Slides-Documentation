---
title: Python में प्रस्तुति placeholders प्रबंधित करें
linktitle: Placeholders को प्रबंधित करें
type: docs
weight: 10
url: /hi/python-java/manage-placeholder/
keywords:
- स्थानीधारक
- पाठ स्थानीधारक
- छवि स्थानीधारक
- चार्ट स्थानीधारक
- सामग्री स्थानीधारक
- प्रॉम्प्ट पाठ
- PowerPoint
- प्रस्तुति
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java के साथ पाठ, चित्र, चार्ट और सामग्री placeholders की जाँच और संपादन करना सीखें और placeholders की विरासत को समझें।"
---
## **सारांश**

एक placeholder वह shape है जो प्रस्तुति टेम्पलेट में किसी विशिष्ट प्रकार की सामग्री के लिए एक स्थान आरक्षित करता है। सामान्य उदाहरणों में शीर्षक, बॉडी, चित्र, चार्ट और सामान्य‑उपयोग सामग्री placeholders शामिल हैं। एक सामान्य shape के विपरीत, placeholder अपनी स्थिति, आकार, फॉर्मेटिंग और अन्य सेटिंग्स को लेआउट स्लाइड या मास्टर स्लाइड से विरासत में ले सकता है।

Aspose.Slides [Shape.getPlaceholder](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getPlaceholder) मेथड के माध्यम से placeholder जानकारी प्रदान करता है। यह मेथड एक [Placeholder](https://reference.aspose.com/slides/python-java/aspose.slides/placeholder/) ऑब्जेक्ट या सामान्य shape के लिये `None` लौटाता है। placeholder किस प्रकार की सामग्री रखने के लिए अभिप्रेत है, यह निर्धारित करने के लिये [Placeholder.getType](https://reference.aspose.com/slides/python-java/aspose.slides/placeholder/#getType) का उपयोग करें।

shape प्रकार अभी भी महत्वपूर्ण रहता है जब आप placeholder प्रकार जान लेते हैं:

- एक खाली टेक्स्ट, चित्र, चार्ट, या कंटेंट placeholder सामान्यतः एक [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) द्वारा दर्शाया जाता है।
- एक भरा हुआ चित्र placeholder एक [PictureFrame](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframe/) द्वारा दर्शाया जा सकता है।
- एक भरा हुआ चार्ट placeholder एक [Chart](https://reference.aspose.com/slides/python-java/aspose.slides/chart/) द्वारा दर्शाया जा सकता है।
- एक कंटेंट placeholder कई प्रकार की सामग्री रख सकता है। हर placeholder को [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) मानने के बजाय [Placeholder.getType](https://reference.aspose.com/slides/python-java/aspose.slides/placeholder/#getType) और रन‑टाइम shape प्रकार दोनों की जाँच करें।

{{% alert color="warning" title="Warning" %}}
[Placeholder.getType](https://reference.aspose.com/slides/python-java/aspose.slides/placeholder/#getType) placeholder की भूमिका का विवरण देता है; यह shape के रन‑टाइम प्रकार की गारंटी नहीं देता। टेक्स्ट, चित्र, चार्ट, टेबल या मीडिया‑विशिष्ट सदस्य तक पहुँचने से पहले हमेशा प्रकार जाँचें।
{{% /alert %}}

## **Placeholder विरासत को समझें**

Placeholders एक पदानुक्रम बनाते हैं:

1. एक मास्टर स्लाइड पुन: उपयोग योग्य शैलियों को परिभाषित करती है और कुछ मामलों में मास्टर‑लेवल placeholders रखती है।
2. एक लेआउट स्लाइड एक या अधिक सामान्य स्लाइडों द्वारा उपयोग की जाने वाली व्यवस्था को परिभाषित करती है और मास्टर से विरासत ले सकती है।
3. एक सामान्य स्लाइड उस स्लाइड के placeholders रखती है और अपनी लेआउट से विरासत ले सकती है।

इस पदानुक्रम में एक स्तर ऊपर जाने के लिये [Shape.getBasePlaceholder](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getBasePlaceholder) को कॉल करें। एक स्लाइड placeholder सामान्यतः अपनी लेआउट placeholder लौटाता है; एक लेआउट placeholder अपना मास्टर placeholder लौटा सकता है। जब shape के पास कोई बेस placeholder नहीं होता तो मेथड `None` लौटाता है।

निम्न उदाहरण पहले स्लाइड पर placeholders की सूची बनाता है और उनके बेस placeholders की रिपोर्ट करता है:

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

सामान्य स्लाइड पर एक placeholder को संपादित करने से उस स्लाइड के लिये एक स्थानीय अधिलेखित (override) बनता या बदलता है। संबंधित लेआउट या मास्टर को संपादित करने से सभी स्लाइडों पर प्रभाव पड़ेगा जो अभी भी वह सेटिंग विरासत में लेती हैं। एक स्थानीय सामान्य shape का कोई बेस placeholder नहीं होता और केवल इसी कोऑर्डिनेट्स में होने के कारण वह विरासत नहीं शुरू करता।

## **Placeholder स्थिति हटाएँ**

टेम्पलेट को अनुकूलित करते समय, किसी मौजूदा वस्तु को सामान्य shape बनाए रखने के लिये [Shape.removePlaceholder](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#removePlaceholder) का प्रयोग करें। उसकी [getPlaceholder](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getPlaceholder) मेथड `None` लौटाती है, लेकिन shape स्लाइड के संग्रह में बनी रहती है। इसके विपरीत, [ShapeCollection.remove](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#remove) shape को उस संग्रह से हटा देता है।

निम्न उदाहरण के लिये `template.pptx` में कम से कम एक स्लाइड और पहले स्लाइड पर एक गैर‑रिक्त टेक्स्ट placeholder होना आवश्यक है। लेआउट या मास्टर से विरासत वाली फॉर्मेटिंग वाले placeholder का प्रयोग करके देखें कि संबंध हटाने से क्या प्रभाव पड़ता है। उदाहरण यह जाँचता है कि वही shape बनी रहती है, फिर उसी सामान्य shape पर फिर से मेथड को कॉल करता है, और परिणाम को सहेजता है।

{{% alert color="warning" title="Warning" %}}
Placeholder स्थिति हटाने से विरासत में मिलीAppearance सेटिंग्स अपने आप संरक्षित नहीं रहतीं। नीचे दिया गया उदाहरण जानबूझकर उन सेटिंग्स को अपरिवर्तित छोड़ता है, इसलिए आउटपुट अलग दिख सकता है। एक shape जिसकी स्थिति और आकार पूरी तरह से विरासत में मिले हों, कॉल के बाद शून्य कोऑर्डिनेट्स और आयाम रख सकती है और संग्रह में बनी रहने के बावजूद अदृश्य हो सकती है।
{{% /alert %}}

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, AutoShape, SaveFormat

presentation = Presentation("template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    found = False

    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if not isinstance(shape, AutoShape):
            continue

        text_frame = shape.getTextFrame()
        if shape.getPlaceholder() is None or text_frame is None:
            continue
        text = text_frame.getText()
        if text is None or len(text) == 0:
            continue

        shape_count = slide.getShapes().size()
        shape.removePlaceholder()

        print(f"Placeholder removed: {shape.getPlaceholder() is None}")
        print(f"Same shape retained: {slide.getShapes().get_Item(index) == shape}")
        print(f"Shape count unchanged: {slide.getShapes().size() == shape_count}")

        # सामान्य shape पर मेथड को कॉल करने से कोई प्रभाव नहीं पड़ता।
        shape.removePlaceholder()
        found = True
        break

    if found:
        presentation.save("placeholder-status-removed.pptx", SaveFormat.Pptx)
    else:
        print("No nonempty text placeholder was found on the first slide.")
finally:
    presentation.dispose()
```

एक मेल खाने वाले placeholder के लिये, सभी तीन जाँचें `True` प्रिंट करती हैं। टेक्स्ट बना रहता है, लेकिन विरासत में मिली स्थिति, आकार, घूर्णन, फ़ॉन्ट, पैराग्राफ संरेखण, टेक्स्ट‑फ़्रेम मार्जिन, वर्टिकल एंकरिंग, भराव और लाइन सेटिंग्स placeholder संबंध हटाए जाने पर बदल सकती हैं। उदाहरण के लिये, विरासत में मिली शीर्षक फ़ॉर्मेटिंग सामान्य टेक्स्ट फ़ॉर्मेटिंग पर वापस गिर सकती है। लेआउट के बारे में अधिक जानकारी के लिये [Slide Layout](/slides/hi/python-java/slide-layout/) देखें।

इच्छित स्वरूप बनाए रखने के लिये कॉल से पहले हल की गई स्थिति, आकार और घूर्णन को कैप्चर करें, और आवश्यक प्रभावी फ़ॉर्मेटिंग मानों को अलग वैरिएबल्स में कॉपी करें। ये मान आप [PortionFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/#getEffective), [ParagraphFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getEffective), [TextFrameFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#getEffective), [FillFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getEffective) और [LineFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#getEffective) के माध्यम से प्राप्त कर सकते हैं। केवल प्रभावी‑फ़ॉर्मेट ऑब्जेक्ट्स पर निर्भर न रहें, क्योंकि संबंध हटाने के बाद उनके टेक्स्ट‑फ़ॉर्मेटिंग मान बदल सकते हैं। कैप्चर किए गए मानों को बाद में सामान्य shape पर स्पष्ट रूप से लागू करें, जिसमें फ़ॉन्ट परिवार, आकार, शैली, रंग, पैराग्राफ सेटिंग्स, टेक्स्ट‑फ़्रेम सेटिंग्स, भराव और लाइन शामिल हों जो आपके टेम्पलेट द्वारा उपयोग होते हैं।

विरासत में मिली shape ज्यामिति को भी स्पष्ट रूप से [GeometryShape.setShapeType](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setShapeType) के माध्यम से निर्धारित करना पड़ सकता है। आयताकार टेक्स्ट placeholder के लिये इसका अर्थ है [ShapeType.Rectangle](https://reference.aspose.com/slides/python-java/aspose.slides/shapetype/#Rectangle) को असाइन करना; केवल भराव और लाइन को पुनर्स्थापित करने से दिखाई देने वाला आयत नहीं बन सकता। अतिरिक्त इफ़ेक्ट्स या अधिक जटिल फ़ॉर्मेटिंग वाले टेम्पलेट को भी इन सेटिंग्स को संभालना आवश्यक है।

## **Placeholder में टेक्स्ट बदलें**

शीर्षक, केंद्रित‑शीर्षक, उपशीर्षक, बॉडी और टेक्स्ट placeholders सामान्यतः टेक्स्ट का समर्थन करते हैं। उपयोग करने से पहले [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) के लिये जांचें और फिर उसकी [getTextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/#getTextFrame) मेथड का उपयोग करें।

यह उदाहरण पहले स्लाइड पर पहला शीर्षक placeholder अपडेट करता है और परिणाम सहेजता है:

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

यह पैटर्न चित्र, चार्ट, टेबल या मीडिया placeholders को [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) के रूप में मानने से बचाता है। यह placeholder को उसके उद्देश्य से पहचानता है, न कि अस्थिर shape इंडेक्स पर निर्भर होकर।

## **लेआउट पर प्रॉम्प्ट टेक्स्ट सेट करें**

प्रॉम्प्ट टेक्स्ट वह डिजाइन‑समय निर्देश है जो खाली placeholder में दिखता है, जैसे *Click to add title*। प्रॉम्प्ट टेक्स्ट को सामान्य स्लाइड की shape संग्रह के माध्यम से नहीं, बल्कि लेआउट placeholder पर सेट करें। लेआउट तक पहुँचने के लिये [Slide.getLayoutSlide](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getLayoutSlide) का उपयोग करें और फिर [BaseSlide.getShapes](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getShapes) द्वारा लौटाए गए संग्रह पर इटरिट करें।

निम्न उदाहरण पहले स्लाइड द्वारा उपयोग किए गए लेआउट पर शीर्षक और उपशीर्षक प्रॉम्प्ट को बदलता है:

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

प्रॉम्प्ट टेक्स्ट सामान्य स्लाइड सामग्री नहीं है। यह PowerPoint जैसे संपादन अनुप्रयोगों में खाली placeholders के लिये है। जब उपयोगकर्ता या प्रोग्राम वास्तविक सामग्री प्रदान करता है, तो प्रॉम्प्ट अब नहीं दिखता। प्रॉम्प्ट बदलने से लेआउट का उपयोग करने वाली स्लाइडों पर मौजूदा टेक्स्ट प्रतिस्थापित नहीं होता।

## **चित्र Placeholder अपडेट करें**

दो मामलों को संभालना है:

- यदि चित्र placeholder पहले से भरा हुआ है और एक [PictureFrame](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframe/) द्वारा दर्शाया गया है, तो छवि को [PictureFillFormat.getPicture](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#getPicture) और [Picture.setImage](https://reference.aspose.com/slides/python-java/aspose.slides/picture/#setImage) द्वारा बदलें।
- यदि यह अभी भी एक खाली placeholder है, तो placeholder के कोऑर्डिनेट्स पर एक picture frame जोड़ें [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addPictureFrame) से और खाली placeholder को हटा दें।

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

खाली placeholder के लिये बनाया गया प्रतिस्थापन एक स्थानीय picture frame है, न कि नया placeholder, क्योंकि [Shape.getPlaceholder](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getPlaceholder) में setter नहीं है। यह आरक्षित स्थिति को रखता है लेकिन अब placeholder‑विशिष्ट व्यवहार विरासत में नहीं लेता। यदि placeholder संबंध को बनाए रखना आवश्यक है, तो पहले PowerPoint में placeholder तैयार कर भरें, फिर Aspose.Slides के साथ परिणामी [PictureFrame](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframe/) को अपडेट करें।

छवि पारदर्शिता, क्रॉपिंग और अन्य चित्र‑विशिष्ट इफ़ेक्ट्स के लिये देखें [Manage Picture Frames](/slides/hi/python-java/picture-frame/)। ये ऑपरेशन picture frame या picture fill से सम्बंधित होते हैं, न कि placeholder मेटाडेटा से।

## **Chart और Content Placeholders के साथ काम करें**

भरे हुए chart placeholder को एक [Chart](https://reference.aspose.com/slides/python-java/aspose.slides/chart/) द्वारा दर्शाया जा सकता है। यह उदाहरण placeholder प्रकार और रन‑टाइम प्रकार दोनों से ऐसा chart ढूँढता है, उसका शीर्षक बदलता है, और फ़ाइल को सहेजता है:

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

एक सामान्य कंटेंट placeholder आमतौर पर [PlaceholderType.Object](https://reference.aspose.com/slides/python-java/aspose.slides/placeholdertype/#Object) रखता है। PowerPoint में यह कई कंटेंट प्रकारों (चार्ट, टेबल, डायग्राम, चित्र, मीडिया) के लिये लॉन्चर की तरह कार्य करता है। एक बार भर जाने के बाद, वास्तविक shape प्रकार की जाँच करें यह जानने के लिये कि इसमें क्या है। विशिष्ट लेआउट में आप [PlaceholderType.Chart](https://reference.aspose.com/slides/python-java/aspose.slides/placeholdertype/#Chart), [PlaceholderType.Table](https://reference.aspose.com/slides/python-java/aspose.slides/placeholdertype/#Table), [PlaceholderType.Picture](https://reference.aspose.com/slides/python-java/aspose.slides/placeholdertype/#Picture), [PlaceholderType.Media](https://reference.aspose.com/slides/python-java/aspose.slides/placeholdertype/#Media) या [PlaceholderType.Diagram](https://reference.aspose.com/slides/python-java/aspose.slides/placeholdertype/#Diagram) देख सकते हैं।

Aspose.Slides खाली [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) placeholder को केवल [Placeholder.getType](https://reference.aspose.com/slides/python-java/aspose.slides/placeholder/#getType) बदलने से [Chart](https://reference.aspose.com/slides/python-java/aspose.slides/chart/) में नहीं बदलता; प्रकार API के माध्यम से बदल नहीं सकता। खाली chart या कंटेंट क्षेत्र को प्रोग्रामmatically भरने के लिये, आवश्यक ऑब्जेक्ट को placeholder के कोऑर्डिनेट्स पर जोड़ें और फिर खाली placeholder को हटाएँ। नीचे दिया गया उदाहरण chart के लिये यही करता है:

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

जोड़ा गया chart एक सामान्य स्थानीय chart है। यह placeholder के क्षेत्र को घेरता है लेकिन लेआउट placeholder से विरासत नहीं लेता। जब आपको इसके श्रेणियों, श्रृंखलाओं या वर्कबुक डेटा को बदलने की आवश्यकता हो, तो समर्पित [chart management articles](/slides/hi/python-java/powerpoint-charts/) देखें।

## **पूरा उदाहरण: टेक्स्ट या इमेज सामग्री अपडेट करें**

निम्न end‑to‑end उदाहरण एक टेम्पलेट खोलता है, पहले स्लाइड पर शीर्षक या चित्र placeholder खोजता है, placeholder और shape प्रकार जाँचता है, उचित सामग्री को अपडेट करता है, और परिणाम को सहेजता है। यह उदाहरण जानबूझकर shape इंडेक्स मानने या हर placeholder को एक ही प्रकार मानने से बचता है।

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

## **FAQ**

**एक बेस placeholder क्या है?**

बेस placeholder वह संबंधित shape है जो लेआउट या मास्टर पर स्थित है और जिससे दूसरा placeholder विरासत लेता है। इसे प्राप्त करने के लिये [Shape.getBasePlaceholder](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getBasePlaceholder) का उपयोग करें। एक सामान्य स्थानीय shape `None` लौटाता है क्योंकि वह placeholder पदानुक्रम का हिस्सा नहीं है।

**क्या मैं सभी स्लाइड शीर्षकों को लेआउट placeholder संपादित करके बदल सकता हूँ?**

आप लेआउट के माध्यम से विरासत में मिली फ़ॉर्मेटिंग या प्रॉम्प्ट टेक्स्ट बदल सकते हैं, लेकिन मौजूदा शीर्षक सामग्री सामान्य स्लाइडों पर संग्रहीत रहती है। संपूर्ण प्रस्तुति में वास्तविक शीर्षक टेक्स्ट बदलने के लिये, स्लाइडों पर इटरिट करें और प्रत्येक शीर्षक placeholder को अपडेट करें।

**मैं तिथि, स्लाइड‑नंबर, हेडर और फ़ुटर placeholders को कैसे प्रबंधित करूँ?**

उचित स्लाइड, लेआउट, मास्टर, नोट्स या हैंडआउट स्कोप पर हेडर और फ़ुटर मैनेजर्स का उपयोग करें। पूर्ण उदाहरणों के लिये देखें [Manage Presentation Header and Footer](/slides/hi/python-java/presentation-header-and-footer/).