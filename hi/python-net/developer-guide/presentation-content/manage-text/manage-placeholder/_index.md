---
title: Python में प्रस्तुति प्लेसहोल्डर को प्रबंधित करें
linktitle: प्लेसहोल्डर प्रबंधित करें
type: docs
weight: 10
url: /hi/python-net/manage-placeholder/
keywords:
- प्लेसहोल्डर
- टेक्स्ट प्लेसहोल्डर
- चित्र प्लेसहोल्डर
- चार्ट प्लेसहोल्डर
- सामग्री प्लेसहोल्डर
- प्रॉम्प्ट टेक्स्ट
- PowerPoint
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET के साथ टेक्स्ट, चित्र, चार्ट और सामग्री प्लेसहोल्डर की जाँच और संपादन करना सीखें और प्लेसहोल्डर विरासत को समझें।"
---
## **सारांश**

एक प्लेसहोल्डर वह आकार है जो प्रस्तुति टेम्पलेट में विशेष प्रकार की सामग्री के लिए एक स्थान आरक्षित करता है। सामान्य उदाहरण हैं शीर्षक, बॉडी, चित्र, चार्ट, और सामान्य‑उद्देश्य सामग्री प्लेसहोल्डर। एक सामान्य आकार से अलग, प्लेसहोल्डर अपनी स्थिति, आकार, फ़ॉर्मेटिंग और अन्य सेटिंग्स को लेआउट स्लाइड या मास्टर स्लाइड से विरासत में प्राप्त कर सकता है।

Aspose.Slides प्लेसहोल्डर जानकारी को [Shape.placeholder](https://reference.aspose.com/slides/python-net/aspose.slides/shape/placeholder/) गुण के माध्यम से उजागर करता है। यह गुण एक [Placeholder](https://reference.aspose.com/slides/python-net/aspose.slides/placeholder/) ऑब्जेक्ट या सामान्य आकार के लिए `None` लौटाता है। प्लेसहोल्डर में क्या होना चाहिए, यह निर्धारित करने के लिए [Placeholder.type](https://reference.aspose.com/slides/python-net/aspose.slides/placeholder/type/) का उपयोग करें।

प्लेसहोल्डर प्रकार जान लेने के बाद भी आकार वर्ग महत्वपूर्ण रहता है:

- एक खाली टेक्स्ट, चित्र, चार्ट, या सामग्री प्लेसहोल्डर आम तौर पर एक [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) द्वारा दर्शाया जाता है।
- एक भरे हुए चित्र प्लेसहोल्डर को एक [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) द्वारा प्रस्तुत किया जा सकता है।
- एक भरे हुए चार्ट प्लेसहोल्डर को एक [Chart](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/) द्वारा प्रस्तुत किया जा सकता है।
- एक सामग्री प्लेसहोल्डर कई प्रकार की सामग्री रख सकता है। सभी प्लेसहोल्डर को एक [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) मानने के बजाय दोनों [Placeholder.type](https://reference.aspose.com/slides/python-net/aspose.slides/placeholder/type/) और रन‑टाइम आकार वर्ग की जाँच करें।

{{% alert color="warning" title="Warning" %}}
[Placeholder.type](https://reference.aspose.com/slides/python-net/aspose.slides/placeholder/type/) प्लेसहोल्डर की भूमिका का वर्णन करता है; यह आकार के रन‑टाइम वर्ग की गारंटी नहीं देता। टेक्स्ट, चित्र, चार्ट, टेबल या मीडिया‑विशिष्ट सदस्यों को एक्सेस करने से पहले हमेशा प्रकार जाँच का उपयोग करें।
{{% /alert %}}

## **प्लेसहोल्डर विरासत को समझें**

प्लेसहोल्डर एक पदानुक्रम बनाते हैं:

1. एक मास्टर स्लाइड पुन: उपयोग योग्य शैलियों को परिभाषित करती है और कुछ मामलों में मास्टर‑स्तर के प्लेसहोल्डर भी रखती है।
2. एक लेआउट स्लाइड एक या अधिक सामान्य स्लाइडों द्वारा उपयोग किए जाने वाले क्रम को परिभाषित करती है और मास्टर से विरासत में ले सकती है।
3. एक सामान्य स्लाइड उस स्लाइड के प्लेसहोल्डर रखती है और अपने लेआउट से विरासत में ले सकती है।

इस पदानुक्रम में एक स्तर ऊपर जाने के लिए [Shape.get_base_placeholder](https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_base_placeholder/) को कॉल करें। एक स्लाइड प्लेसहोल्डर सामान्यतः अपना लेआउट प्लेसहोल्डर लौटाता है; एक लेआउट प्लेसहोल्डर अपना मास्टर प्लेसहोल्डर लौटा सकता है। जब आकार का कोई बेस प्लेसहोल्डर नहीं होता तो यह विधि `None` लौटाती है।

निम्न उदाहरण पहले स्लाइड पर प्लेसहोल्डर की सूची बनाता है और उनके बेस प्लेसहोल्डर की रिपोर्ट देता है:

```python
import aspose.slides as slides

with slides.Presentation("template.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if shape.placeholder is None:
            continue

        placeholder_type = shape.placeholder.type
        type_name = type(shape).__name__
        print(f"Slide placeholder: {placeholder_type}; shape class: {type_name}")

        layout_placeholder = shape.get_base_placeholder()
        if layout_placeholder is not None:
            layout_placeholder_type = layout_placeholder.placeholder.type if layout_placeholder.placeholder is not None else None
            print(f"  Layout placeholder: {layout_placeholder_type}")

            master_placeholder = layout_placeholder.get_base_placeholder()
            if master_placeholder is not None:
                master_placeholder_type = master_placeholder.placeholder.type if master_placeholder.placeholder is not None else None
                print(f"  Master placeholder: {master_placeholder_type}")
```

सामान्य स्लाइड पर प्लेसहोल्डर को संपादित करने से उस स्लाइड के लिए स्थानीय ओवरराइड बनता या बदलता है। संबंधित लेआउट या मास्टर को संपादित करने से उन सभी स्लाइडों पर असर पड़ सकता है जो अभी भी वह सेटिंग विरासत में ले रही हैं। एक स्थानीय सामान्य आकार का कोई बेस प्लेसहोल्डर नहीं होता और केवल वही कोऑर्डिनेट्स लेने से विरासत शुरू नहीं होती।

## **प्लेसहोल्डर स्थिति हटाएँ**

टेम्पलेट को अनुकूलित करते समय, मौजूदा ऑब्जेक्ट को एक सामान्य आकार के रूप में रखने के लिए [Shape.remove_placeholder](https://reference.aspose.com/slides/python-net/aspose.slides/shape/remove_placeholder/) का प्रयोग करें। इसका [placeholder](https://reference.aspose.com/slides/python-net/aspose.slides/shape/placeholder/) गुण `None` हो जाता है, लेकिन आकार स्लाइड के संग्रह में बना रहता है। इसके विपरीत, [ShapeCollection.remove](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/remove/) आकार को उस संग्रह से हटा देता है।

निम्न उदाहरण के लिए `template.pptx` आवश्यक है जिसमें कम से कम एक स्लाइड और पहले स्लाइड पर एक गैर‑खाली टेक्स्ट प्लेसहोल्डर हो। लेआउट या मास्टर से विरासत में मिली फ़ॉर्मेटिंग वाले प्लेसहोल्डर का उपयोग करके संबंध हटाने के प्रभाव को देखें। उदाहरण जाँचता है कि वही आकार बना रहता है, अब सामान्य आकार पर फिर से विधि को कॉल करता है, और परिणाम को सहेजता है।

{{% alert color="warning" title="Warning" %}}
प्लेसहोल्डर स्थिति हटाने से विरासत में मिली दृश्य सेटिंग्स स्वचालित रूप से संरक्षित नहीं रहतीं। नीचे दिया गया उदाहरण जानबूझकर इन सेटिंग्स को अपरिवर्तित छोड़ता है, इसलिए आउटपुट अलग दिख सकता है। पूरी तरह से विरासत में मिला हुआ स्थिति और आकार वाले आकार कॉल के बाद शून्य कोऑर्डिनेट और आयाम प्राप्त कर सकते हैं और संग्रह में मौजूद रहने के बावजूद अदृश्य हो सकते हैं।
{{% /alert %}}

```python
import aspose.slides as slides

with slides.Presentation("template.pptx") as presentation:
    slide = presentation.slides[0]
    found = False

    for index in range(len(slide.shapes)):
        shape = slide.shapes[index]
        if not isinstance(shape, slides.AutoShape) or shape.placeholder is None:
            continue
        if shape.text_frame is None or not shape.text_frame.text:
            continue

        shape_count = len(slide.shapes)
        shape.remove_placeholder()

        print(f"Placeholder removed: {shape.placeholder is None}")
        print(f"Same shape retained: {slide.shapes[index] == shape}")
        print(f"Shape count unchanged: {len(slide.shapes) == shape_count}")

        # एक सामान्य आकार पर विधि को कॉल करने से कोई प्रभाव नहीं पड़ता।
        shape.remove_placeholder()
        found = True
        break

    if found:
        presentation.save("placeholder-status-removed.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("No nonempty text placeholder was found on the first slide.")
```

सही प्लेसहोल्डर के लिए, सभी तीन जाँचें `True` प्रिंट करती हैं। टेक्स्ट बना रहता है, लेकिन विरासत में मिली स्थिति, आकार, घुमाव, फ़ॉन्ट, पैराग्राफ संरेखण, टेक्स्ट‑फ्रेम मार्जिन, ऊर्ध्वाधर एंकरिंग, फ़िल, और लाइन सेटिंग्स प्लेसहोल्डर संबंध हटाए जाने पर बदल सकती हैं। उदाहरण के तौर पर, विरासत में मिला शीर्षक फ़ॉर्मेटिंग सामान्य टेक्स्ट फ़ॉर्मेटिंग में वापस आ सकता है। लेआउट के बारे में अधिक जानकारी के लिए देखें [स्लाइड लेआउट](/slides/hi/python-net/slide-layout/)।

इच्छित स्वरूप को बनाए रखने के लिए, कॉल से पहले हल किया गया स्थिति, आकार, और घुमाव कैप्चर करें, और आवश्यक प्रभावी फ़ॉर्मेटिंग मानों को अलग वेरिएबल में कॉपी करें। उन मानों को [PortionFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/get_effective/), [ParagraphFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/get_effective/), [TextFrameFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/get_effective/), [FillFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/get_effective/), और [LineFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/get_effective/) के माध्यम से प्राप्त करें। केवल प्रभावी‑फ़ॉर्मेट ऑब्जेक्ट्स को रखने पर भरोसा न करें, क्योंकि संबंध हटाने के बाद उनके टेक्स्ट‑फ़ॉर्मेटिंग मान बदल सकते हैं। बाद में कैप्चर किए हुए मानों को सामान्य आकार पर स्पष्ट रूप से लागू करें, जिसमें फ़ॉन्ट परिवार, आकार, शैली, रंग, पैराग्राफ सेटिंग्स, टेक्स्ट‑फ़्रेम सेटिंग्स, फ़िल, और आपके टेम्पलेट द्वारा उपयोग की गई लाइन शामिल हों।

विरासत में मिली आकार ज्यामिति को भी स्पष्ट रूप से [GeometryShape.shape_type](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/shape_type/) के माध्यम से असाइन करना पड़ सकता है। आयताकार टेक्स्ट प्लेसहोल्डर के लिए, इसका अर्थ है [ShapeType.RECTANGLE](https://reference.aspose.com/slides/python-net/aspose.slides/shapetype/) को असाइन करना; केवल फ़िल और लाइन को पुनर्स्थापित करने से दिखाई देने वाला आयत नहीं बन सकता। अतिरिक्त प्रभाव या अधिक जटिल फ़ॉर्मेटिंग वाले टेम्प्लेट को इन सेटिंग्स को भी संभालना पड़ता है।

## **प्लेसहोल्डर में टेक्स्ट बदलें**

शीर्षक, केंद्रित‑शीर्षक, उपशीर्षक, बॉडी, और टेक्स्ट प्लेसहोल्डर सामान्यतः टेक्स्ट का समर्थन करते हैं। इसका [text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/text_frame/) गुण उपयोग करने से पहले [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) की जाँच करें।

निम्न उदाहरण पहले स्लाइड पर पहला शीर्षक प्लेसहोल्डर अपडेट करता है और परिणाम को सहेजता है:

```python
import aspose.slides as slides

with slides.Presentation("template.pptx") as presentation:
    slide = presentation.slides[0]
    title_shape = None

    for shape in slide.shapes:
        if not isinstance(shape, slides.AutoShape) or shape.placeholder is None:
            continue

        placeholder_type = shape.placeholder.type
        if placeholder_type in (slides.PlaceholderType.TITLE, slides.PlaceholderType.CENTERED_TITLE):
            title_shape = shape
            break

    if title_shape is None:
        raise RuntimeError("The first slide does not contain a title placeholder.")

    title_shape.text_frame.text = "Quarterly Business Review"
    presentation.save("title-placeholder-updated.pptx", slides.export.SaveFormat.PPTX)
```

यह पैटर्न चित्र, चार्ट, टेबल या मीडिया प्लेसहोल्डर को [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) ऑब्जेक्ट के रूप में मानने से बचता है। यह प्लेसहोल्डर को उसके उद्देश्य से पहचानता है न कि एक अस्थिर आकार अनुक्रमणिका पर निर्भर रहने से।

## **लेआउट पर प्रॉम्प्ट टेक्स्ट सेट करें**

प्रॉम्प्ट टेक्स्ट एक खाली प्लेसहोल्डर में दिखाया गया डिज़ाइन‑टाइम निर्देश है, जैसे *शीर्षक जोड़ने के लिए क्लिक करें*। प्रॉम्प्ट टेक्स्ट को सामान्य स्लाइड के आकार संग्रह के माध्यम से प्राप्त करने की कोशिश करने की बजाय लेआउट प्लेसहोल्डर पर सेट करें। लेआउट को [Slide.layout_slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/layout_slide/) द्वारा एक्सेस करें और [LayoutSlide.shapes](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/shapes/) पर इटररेट करें।

निम्न उदाहरण पहले स्लाइड द्वारा उपयोग किए जाने वाले लेआउट पर शीर्षक और उपशीर्षक प्रॉम्प्ट को बदलता है:

```python
import aspose.slides as slides

with slides.Presentation("template.pptx") as presentation:
    layout_slide = presentation.slides[0].layout_slide

    for shape in layout_slide.shapes:
        if not isinstance(shape, slides.AutoShape) or shape.placeholder is None:
            continue

        placeholder_type = shape.placeholder.type

        if placeholder_type in (slides.PlaceholderType.TITLE, slides.PlaceholderType.CENTERED_TITLE):
            shape.text_frame.text = "Enter a concise slide title"
        elif placeholder_type == slides.PlaceholderType.SUBTITLE:
            shape.text_frame.text = "Enter a subtitle or reporting period"

    presentation.save("custom-placeholder-prompts.pptx", slides.export.SaveFormat.PPTX)
```

प्रॉम्प्ट टेक्स्ट सामान्य स्लाइड सामग्री नहीं है। यह PowerPoint जैसे संपादन अनुप्रयोगों में खाली प्लेसहोल्डर के लिए अभिप्रेत है। एक बार उपयोगकर्ता या प्रोग्राम वास्तविक सामग्री प्रदान कर देता है, प्रॉम्प्ट अब प्रदर्शित नहीं होता। प्रॉम्प्ट बदलने से उस लेआउट का उपयोग करने वाली स्लाइडों पर मौजूद टेक्स्ट बदलता भी नहीं है।

## **चित्र प्लेसहोल्डर को अपडेट करें**

संबोधित करने के दो मामले हैं:

- यदि चित्र प्लेसहोल्डर पहले से भरा हुआ है और एक [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) द्वारा दर्शाया गया है, तो छवि को [PictureFillFormat.picture](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/picture/) और [Picture.image](https://reference.aspose.com/slides/python-net/aspose.slides/picture/image/) के माध्यम से प्रतिस्थापित करें।
- यदि यह अभी भी एक खाली प्लेसहोल्डर है, तो [ShapeCollection.add_picture_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_picture_frame/) से प्लेसहोल्डर के कोऑर्डिनेट्स पर एक चित्र फ्रेम जोड़ें और खाली प्लेसहोल्डर को हटाएँ।

अगला उदाहरण दोनों मामलों को समर्थन देता है और प्रस्तुति को सहेजता है:

```python
import aspose.slides as slides

with slides.Presentation("picture-template.pptx") as presentation:
    slide = presentation.slides[0]
    picture_placeholder = None

    for shape in slide.shapes:
        if shape.placeholder is not None and shape.placeholder.type == slides.PlaceholderType.PICTURE:
            picture_placeholder = shape
            break

    if picture_placeholder is None:
        raise RuntimeError("The first slide does not contain a picture placeholder.")

    with open("replacement.png", "rb") as image_stream:
        image_bytes = image_stream.read()

    image = presentation.images.add_image(image_bytes)

    if isinstance(picture_placeholder, slides.PictureFrame):
        picture_placeholder.picture_format.picture.image = image
    else:
        slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, picture_placeholder.x, picture_placeholder.y, picture_placeholder.width, picture_placeholder.height, image)
        slide.shapes.remove(picture_placeholder)

    presentation.save("picture-placeholder-updated.pptx", slides.export.SaveFormat.PPTX)
```

एक खाली प्लेसहोल्डर के लिए बनाई गई प्रतिस्थापन एक स्थानीय चित्र फ्रेम है, नया प्लेसहोल्डर नहीं, क्योंकि [Shape.placeholder](https://reference.aspose.com/slides/python-net/aspose.slides/shape/placeholder/) केवल‑पढ़ने योग्य है। यह आरक्षित स्थिति को रखता है लेकिन अब प्लेसहोल्डर‑विशिष्ट व्यवहार को नहीं विरासत में लेता। यदि प्लेसहोल्डर संबंध को बनाए रखना आवश्यक है, तो पहले PowerPoint में प्लेसहोल्डर को तैयार और भरें, फिर Aspose.Slides के साथ परिणामी [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) को अपडेट करें।

छवि पारदर्शिता, क्रॉपिंग और अन्य चित्र‑विशिष्ट प्रभावों के लिए देखें [Manage Picture Frames](/slides/hi/python-net/picture-frame/)। ये ऑपरेशन चित्र फ्रेम या चित्र फ़िल से संबंधित हैं, न कि प्लेसहोल्डर मेटाडेटा से।

## **चार्ट और सामग्री प्लेसहोल्डर के साथ काम करें**

भरे हुए चार्ट प्लेसहोल्डर को एक [Chart](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/) द्वारा दर्शाया जा सकता है। यह उदाहरण ऐसा चार्ट दोनों प्लेसहोल्डर प्रकार और रन‑टाइम वर्ग से खोजता है, उसका शीर्षक बदलता है, और फ़ाइल को सहेजता है:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart-template.pptx") as presentation:
    slide = presentation.slides[0]
    placeholder_chart = None

    for shape in slide.shapes:
        if isinstance(shape, charts.Chart) and shape.placeholder is not None and shape.placeholder.type == slides.PlaceholderType.CHART:
            placeholder_chart = shape
            break

    if placeholder_chart is None:
        raise RuntimeError("The first slide does not contain a populated chart placeholder.")

    placeholder_chart.has_title = True
    placeholder_chart.chart_title.add_text_frame_for_overriding("Quarterly Revenue")
    presentation.save("chart-placeholder-updated.pptx", slides.export.SaveFormat.PPTX)
```

एक सामान्य सामग्री प्लेसहोल्डर आम तौर पर [PlaceholderType.OBJECT](https://reference.aspose.com/slides/python-net/aspose.slides/placeholdertype/) रखता है। PowerPoint में यह कई सामग्री प्रकारों जैसे चार्ट, टेबल, डायग्राम, चित्र, और मीडिया के लॉन्चर के रूप में कार्य करता है। भरने के बाद, वास्तविक आकार वर्ग की जाँच करके पता करें कि इसमें क्या है। विशिष्ट लेआउट भी [PlaceholderType.CHART](https://reference.aspose.com/slides/python-net/aspose.slides/placeholdertype/), [PlaceholderType.TABLE](https://reference.aspose.com/slides/python-net/aspose.slides/placeholdertype/), [PlaceholderType.PICTURE](https://reference.aspose.com/slides/python-net/aspose.slides/placeholdertype/), [PlaceholderType.MEDIA](https://reference.aspose.com/slides/python-net/aspose.slides/placeholdertype/), या [PlaceholderType.DIAGRAM](https://reference.aspose.com/slides/python-net/aspose.slides/placeholdertype/) को उजागर कर सकते हैं।

Aspose.Slides केवल [Placeholder.type](https://reference.aspose.com/slides/python-net/aspose.slides/placeholder/type/) बदलने से खाली [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) प्लेसहोल्डर को [Chart](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/) में नहीं बदलता; प्रकार केवल‑पढ़ने योग्य है। प्रोग्रामैटिक रूप से एक खाली चार्ट या सामग्री क्षेत्र भरने के लिए, आवश्यक ऑब्जेक्ट को प्लेसहोल्डर के कोऑर्डिनेट्स पर जोड़ें और फिर खाली प्लेसहोल्डर को हटाएँ। निम्न उदाहरण चार्ट के लिए यही करता है:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("content-template.pptx") as presentation:
    slide = presentation.slides[0]
    target_placeholder = None

    for shape in slide.shapes:
        if shape.placeholder is None:
            continue

        if shape.placeholder.type in (slides.PlaceholderType.CHART, slides.PlaceholderType.OBJECT):
            target_placeholder = shape
            break

    if target_placeholder is None:
        raise RuntimeError("The first slide does not contain a chart or content placeholder.")

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, target_placeholder.x, target_placeholder.y, target_placeholder.width, target_placeholder.height)
    chart.has_title = True
    chart.chart_title.add_text_frame_for_overriding("Quarterly Revenue")
    slide.shapes.remove(target_placeholder)
    presentation.save("content-placeholder-replaced-with-chart.pptx", slides.export.SaveFormat.PPTX)
```

जोड़ा गया चार्ट एक सामान्य स्थानीय चार्ट है। यह प्लेसहोल्डर के क्षेत्र को घेरता है लेकिन लेआउट प्लेसहोल्डर से विरासत नहीं लेता। जब आपको इसके श्रेणियों, अनुक्रमों या वर्कबुक डेटा को बदलने की आवश्यकता हो, तो समर्पित [चार्ट प्रबंधन लेख](/slides/hi/python-net/powerpoint-charts/) का उपयोग करें।

## **पूर्ण उदाहरण: टेक्स्ट या चित्र सामग्री अपडेट करें**

निम्न अंत‑से‑अंत उदाहरण एक टेम्पलेट खोलता है, पहले स्लाइड पर शीर्षक या चित्र प्लेसहोल्डर खोजता है, प्लेसहोल्डर और आकार प्रकार की जाँच करता है, उपयुक्त सामग्री अपडेट करता है, और आउटपुट सहेजता है। उदाहरण जानबूझकर आकार अनुक्रमणिका मानने या सभी प्लेसहोल्डर को समान आकार वर्ग मानने से बचता है।

```python
import aspose.slides as slides

with slides.Presentation("template.pptx") as presentation:
    slide = presentation.slides[0]
    updated = False

    for shape in slide.shapes:
        if shape.placeholder is None:
            continue

        placeholder_type = shape.placeholder.type

        if placeholder_type in (slides.PlaceholderType.TITLE, slides.PlaceholderType.CENTERED_TITLE) and isinstance(shape, slides.AutoShape):
            shape.text_frame.text = "Quarterly Business Review"
            updated = True
            break

        if placeholder_type == slides.PlaceholderType.PICTURE:
            with open("replacement.png", "rb") as image_stream:
                image_bytes = image_stream.read()

            image = presentation.images.add_image(image_bytes)

            if isinstance(shape, slides.PictureFrame):
                shape.picture_format.picture.image = image
            else:
                slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, shape.x, shape.y, shape.width, shape.height, image)
                slide.shapes.remove(shape)

            updated = True
            break

    if not updated:
        raise RuntimeError("No supported title or picture placeholder was found on the first slide.")

    presentation.save("placeholder-content-updated.pptx", slides.export.SaveFormat.PPTX)
```

## **अक्सर पूछे जाने वाले प्रश्न**

**बेस प्लेसहोल्डर क्या है?**

बेस प्लेसहोल्डर वह संबंधित आकार है जो लेआउट या मास्टर पर स्थित होता है जिससे अन्य प्लेसहोल्डर विरासत में लेते हैं। इसे प्राप्त करने के लिए [Shape.get_base_placeholder](https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_base_placeholder/) का उपयोग करें। एक सामान्य स्थानीय आकार `None` लौटाता है क्योंकि वह प्लेसहोल्डर पदानुक्रम का भाग नहीं है।

**क्या मैं लेआउट प्लेसहोल्डर को संपादित करके सभी स्लाइड शीर्षक बदल सकता हूँ?**

आप लेआउट के माध्यम से विरासत में मिली फ़ॉर्मेटिंग या प्रॉम्प्ट टेक्स्ट बदल सकते हैं, लेकिन वास्तविक शीर्षक सामग्री सामान्य स्लाइडों पर संग्रहीत होती है। प्रस्तुति में सभी शीर्षक टेक्स्ट को बदलने के लिए स्लाइडों पर इटररेट करें और प्रत्येक शीर्षक प्लेसहोल्डर को अपडेट करें।

**मैं तिथि, स्लाइड‑नंबर, हेडर और फुटर प्लेसहोल्डर को कैसे प्रबंधित करूँ?**

स्लाइड, लेआउट, मास्टर, नोट्स या हैंडआउट स्तर पर उपयुक्त हेडर और फुटर मैनेजर्स का उपयोग करें। पूर्ण उदाहरणों के लिए देखें [प्रेजेंटेशन हेडर और फुटर प्रबंधन](/slides/hi/python-net/presentation-header-and-footer/)।