---
title: Python में प्रस्तुति प्लेसहोल्डर प्रबंधन
linktitle: प्लेसहोल्डर प्रबंधन
type: docs
weight: 10
url: /hi/python-net/manage-placeholder/
keywords:
- प्लेसहोल्डर
- टेक्स्ट प्लेसहोल्डर
- छवि प्लेसहोल्डर
- चार्ट प्लेसहोल्डर
- सामग्री प्लेसहोल्डर
- प्रॉम्प्ट टेक्स्ट
- PowerPoint
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET के साथ टेक्स्ट, चित्र, चार्ट और सामग्री प्लेसहोल्डर की जाँच और संपादन करना तथा प्लेसहोल्डर विरासत को समझना सीखें।"
---
## **परिचय**

एक प्लेसहोल्डर वह आकार है जो प्रस्तुति टेम्पलेट में किसी विशिष्ट प्रकार की सामग्री के लिए एक स्थान आरक्षित करता है। सामान्य उदाहरणों में शीर्षक, बॉडी, चित्र, चार्ट, और सामान्य‑उद्देश्य सामग्री प्लेसहोल्डर शामिल हैं। एक सामान्य आकार के विपरीत, प्लेसहोल्डर अपने स्थान, आकार, फ़ॉर्मेटिंग, और अन्य सेटिंग्स को लेआउट स्लाइड या मास्टर स्लाइड से विरासत में प्राप्त कर सकता है।

Aspose.Slides प्लेसहोल्डर जानकारी को [Shape.placeholder](https://reference.aspose.com/slides/hi/python-net/aspose.slides/shape/placeholder/) प्रॉपर्टी के माध्यम से उजागर करता है। यह प्रॉपर्टी एक [Placeholder](https://reference.aspose.com/slides/hi/python-net/aspose.slides/placeholder/) ऑब्जेक्ट या सामान्य आकार के लिए `None` लौटाती है। प्लेसहोल्डर में किस प्रकार की सामग्री होनी चाहिए, यह निर्धारित करने के लिए [Placeholder.type](https://reference.aspose.com/slides/hi/python-net/aspose.slides/placeholder/type/) का उपयोग करें।

प्लेसहोल्डर प्रकार जानने के बाद आकार वर्ग अभी भी महत्वपूर्ण है:

- एक खाली टेक्स्ट, चित्र, चार्ट, या सामग्री प्लेसहोल्डर आम तौर पर एक [AutoShape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/autoshape/) द्वारा प्रदर्शित होता है।
- एक भरा हुआ चित्र प्लेसहोल्डर एक [PictureFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/pictureframe/) द्वारा प्रतिनिधित्व किया जा सकता है।
- एक भरा हुआ चार्ट प्लेसहोल्डर एक [Chart](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chart/) द्वारा प्रतिनिधित्व किया जा सकता है।
- एक सामग्री प्लेसहोल्डर कई प्रकार की सामग्री रख सकता है। प्रत्येक प्लेसहोल्डर को [AutoShape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/autoshape/) मानने के बजाय [Placeholder.type](https://reference.aspose.com/slides/hi/python-net/aspose.slides/placeholder/type/) और रनटाइम आकार वर्ग दोनों की जाँच करें।

{{% alert color="warning" title="चेतावनी" %}}
[Placeholder.type](https://reference.aspose.com/slides/hi/python-net/aspose.slides/placeholder/type/) प्लेसहोल्डर की भूमिका का वर्णन करता है; यह आकार के रनटाइम वर्ग की गारंटी नहीं देता। टेक्स्ट, चित्र, चार्ट, टेबल या मीडिया‑विशिष्ट सदस्यों तक पहुँचने से पहले हमेशा टाइप जांच करें।
{{% /alert %}}

## **प्लेसहोल्डर विरासत को समझें**

प्लेसहोल्डर एक पदानुक्रम बनाते हैं:

1. एक मास्टर स्लाइड पुन: उपयोग योग्य शैलियों और कुछ मामलों में मास्टर‑स्तर के प्लेसहोल्डर को परिभाषित करती है।
2. एक लेआउट स्लाइड वह व्यवस्था परिभाषित करती है जो एक या अधिक सामान्य स्लाइड्स द्वारा उपयोग की जाती है और मास्टर से विरासत में ले सकती है।
3. एक सामान्य स्लाइड उस स्लाइड के प्लेसहोल्डर रखती है और अपने लेआउट से विरासत में ले सकती है।

[Shape.get_base_placeholder](https://reference.aspose.com/slides/hi/python-net/aspose.slides/shape/get_base_placeholder/) को कॉल करके इस पदानुक्रम में एक स्तर ऊपर जा सकते हैं। एक स्लाइड प्लेसहोल्डर सामान्यतः अपना लेआउट प्लेसहोल्डर लौटाता है; एक लेआउट प्लेसहोल्डर अपना मास्टर प्लेसहोल्डर लौटा सकता है। जब आकार का कोई बेस प्लेसहोल्डर नहीं होता, तो यह मेथड `None` लौटाता है।

पहली स्लाइड पर प्लेसहोल्डर सूचीबद्ध करने और उनके बेस प्लेसहोल्डर रिपोर्ट करने का उदाहरण नीचे दिया गया है:

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

सामान्य स्लाइड पर प्लेसहोल्डर को संपादित करने से उस स्लाइड के लिए एक स्थानीय ओवरराइड बनता या बदलता है। संबंधित लेआउट या मास्टर को संपादित करने से उन सभी स्लाइड्स पर प्रभाव पड़ता है जो अभी भी वह सेटिंग विरासत में ले रही हैं। एक स्थानीय सामान्य आकार का कोई बेस प्लेसहोल्डर नहीं होता और केवल उसी निर्देशांक पर होने के कारण विरासत शुरू नहीं करता।

## **प्लेसहोल्डर में टेक्स्ट बदलें**

शीर्षक, केंद्रित‑शीर्षक, उपशीर्षक, बॉडी, और टेक्स्ट प्लेसहोल्डर सामान्यतः टेक्स्ट समर्थन करते हैं। इसका [text_frame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/autoshape/text_frame/) प्रॉपर्टी उपयोग करने से पहले [AutoShape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/autoshape/) की जाँच करें।

यह उदाहरण पहली स्लाइड पर पहला शीर्षक प्लेसहोल्डर अपडेट करता है और परिणाम सहेजता है:

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

यह पैटर्न चित्र, चार्ट, टेबल या मीडिया प्लेसहोल्डर को [AutoShape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/autoshape/) ऑब्जेक्ट मानने से बचाता है। यह प्लेसहोल्डर को उसके उद्देश्य द्वारा पहचानता है, न कि एक नाजुक आकार सूचकांक पर भरोसा करके।

## **लेआउट पर प्रॉम्प्ट टेक्स्ट सेट करें**

प्रॉम्प्ट टेक्स्ट वह डिजाइन‑टाइम निर्देश है जो खाली प्लेसहोल्डर में दिखाया जाता है, जैसे *Click to add title*। इसे सामान्य स्लाइड के आकार संग्रह के माध्यम से पहुँचने की कोशिश करने के बजाय लेआउट प्लेसहोल्डर पर सेट करें। लेआउट तक पहुँचने के लिए [Slide.layout_slide](https://reference.aspose.com/slides/hi/python-net/aspose.slides/slide/layout_slide/) का उपयोग करें और [LayoutSlide.shapes](https://reference.aspose.com/slides/hi/python-net/aspose.slides/baseslide/shapes/) पर इटररेट करें।

नीचे दिया गया उदाहरण पहली स्लाइड द्वारा उपयोग किए गए लेआउट पर शीर्षक और उपशीर्षक प्रॉम्प्ट बदलता है:

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

प्रॉम्प्ट टेक्स्ट सामान्य स्लाइड सामग्री नहीं है। यह PowerPoint जैसे संपादन अनुप्रयोगों में खाली प्लेसहोल्डर के लिए निर्देशित है। एक बार उपयोगकर्ता या प्रोग्राम वास्तविक सामग्री प्रदान कर देता है, तो प्रॉम्प्ट नहीं दिखता। प्रॉम्प्ट बदलना लेआउट उपयोग करने वाली स्लाइड्स पर मौजूदा टेक्स्ट को प्रतिस्थापित नहीं करता।

## **चित्र प्लेसहोल्डर अपडेट करें**

दो मामलों को संभालना है:

- यदि चित्र प्लेसहोल्डर पहले से भरा हुआ है और एक [PictureFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/pictureframe/) द्वारा प्रदर्शित है, तो छवि को [PictureFillFormat.picture](https://reference.aspose.com/slides/hi/python-net/aspose.slides/picturefillformat/picture/) और [Picture.image](https://reference.aspose.com/slides/hi/python-net/aspose.slides/picture/image/) से बदलें।
- यदि यह अभी भी एक खाली प्लेसहोल्डर है, तो [ShapeCollection.add_picture_frame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/shapecollection/add_picture_frame/) का उपयोग करके प्लेसहोल्डर के निर्देशांक पर एक चित्र फ्रेम जोड़ें और खाली प्लेसहोल्डर को हटाएँ।

अगला उदाहरण दोनों मामलों का समर्थन करता है और प्रस्तुति सहेजता है:

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

खाली प्लेसहोल्डर के लिए बनाया गया प्रतिस्थापन एक स्थानीय चित्र फ्रेम है, नया प्लेसहोल्डर नहीं, क्योंकि [Shape.placeholder](https://reference.aspose.com/slides/hi/python-net/aspose.slides/shape/placeholder/) केवल‑पढ़ने योग्य है। यह आरक्षित स्थान रखता है लेकिन अब प्लेसहोल्डर‑विशिष्ट व्यवहार नहीं विरासत में लेता। यदि प्लेसहोल्डर संबंध बनाए रखना आवश्यक है, तो पहले PowerPoint में प्लेसहोल्डर तैयार और भरें, फिर Aspose.Slides के साथ परिणामी [PictureFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/pictureframe/) को अपडेट करें।

छवि पारदर्शिता, क्रॉपिंग और अन्य चित्र‑विशिष्ट प्रभावों के लिए देखें [Manage Picture Frames](/slides/hi/python-net/picture-frame/)। ये ऑपरेशन चित्र फ्रेम या चित्र भराव से संबंधित हैं, प्लेसहोल्डर मेटाडाटा से नहीं।

## **चार्ट और सामग्री प्लेसहोल्डर के साथ कार्य करें**

एक भरा हुआ चार्ट प्लेसहोल्डर एक [Chart](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chart/) द्वारा प्रतिनिधित्व किया जा सकता है। यह उदाहरण प्लेसहोल्डर प्रकार और रनटाइम क्लास दोनों के आधार पर ऐसा चार्ट ढूँढता है, उसका शीर्षक बदलता है, और फ़ाइल सहेजता है:

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

एक सामान्य सामग्री प्लेसहोल्डर आमतौर पर [PlaceholderType.OBJECT](https://reference.aspose.com/slides/hi/python-net/aspose.slides/placeholdertype/) रखता है। PowerPoint में यह कई सामग्री प्रकारों के लिए लॉन्चर के रूप में कार्य करता है, जिसमें चार्ट, तालिका, डायग्राम, चित्र और मीडिया शामिल हैं। एक बार भरने के बाद, वास्तविक आकार वर्ग का निरीक्षण करें कि इसमें क्या है। विशिष्ट लेआउट [PlaceholderType.CHART](https://reference.aspose.com/slides/hi/python-net/aspose.slides/placeholdertype/), [PlaceholderType.TABLE](https://reference.aspose.com/slides/hi/python-net/aspose.slides/placeholdertype/), [PlaceholderType.PICTURE](https://reference.aspose.com/slides/hi/python-net/aspose.slides/placeholdertype/), [PlaceholderType.MEDIA](https://reference.aspose.com/slides/hi/python-net/aspose.slides/placeholdertype/), या [PlaceholderType.DIAGRAM](https://reference.aspose.com/slides/hi/python-net/aspose.slides/placeholdertype/) भी उजागर कर सकते हैं।

Aspose.Slides खाली [AutoShape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/autoshape/) प्लेसहोल्डर को केवल [Placeholder.type](https://reference.aspose.com/slides/hi/python-net/aspose.slides/placeholder/type/) बदलकर [Chart](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chart/) में परिवर्तित नहीं करता; प्रकार केवल‑पढ़ने योग्य है। खाली चार्ट या सामग्री क्षेत्र को प्रोग्रामेटिक रूप से भरने के लिए, प्लेसहोल्डर के निर्देशांक पर आवश्यक वस्तु जोड़ें और फिर खाली प्लेसहोल्डर हटाएँ। नीचे दिया गया उदाहरण चार्ट के लिए यही करता है:

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

जोड़ा गया चार्ट एक सामान्य स्थानीय चार्ट है। यह प्लेसहोल्डर के क्षेत्र को घेरता है लेकिन लेआउट प्लेसहोल्डर से विरासत नहीं लेता। श्रेणियों, श्रृंखलाओं या वर्कबुक डेटा को बदलने के लिए समर्पित [chart management articles](/slides/hi/python-net/powerpoint-charts/) देखें।

## **पूरा उदाहरण: टेक्स्ट या इमेज सामग्री अपडेट करें**

नीचे दिया गया समग्र उदाहरण एक टेम्पलेट खोलता है, पहली स्लाइड पर शीर्षक या चित्र प्लेसहोल्डर खोजता है, प्लेसहोल्डर और आकार प्रकार की जाँच करता है, उपयुक्त सामग्री अपडेट करता है, और आउटपुट सहेजता है। यह उदाहरण जानबूझकर आकार सूचकांक मानने या सभी प्लेसहोल्डर को समान आकार वर्ग मानने से बचता है।

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

बेस प्लेसहोल्डर वह संबंधित आकार है जो लेआउट या मास्टर पर स्थित होता है, जिससे दूसरा प्लेसहोल्डर विरासत प्राप्त करता है। इसे प्राप्त करने के लिए [Shape.get_base_placeholder](https://reference.aspose.com/slides/hi/python-net/aspose.slides/shape/get_base_placeholder/) का उपयोग करें। एक सामान्य स्थानीय आकार `None` लौटाता है क्योंकि वह प्लेसहोल्डर पदानुक्रम का हिस्सा नहीं है।

**क्या मैं लेआउट प्लेसहोल्डर को संपादित करके सभी स्लाइड शीर्षक बदल सकता हूँ?**

आप लेआउट के माध्यम से विरासत फ़ॉर्मेटिंग या प्रॉम्प्ट टेक्स्ट बदल सकते हैं, लेकिन मौजूदा शीर्षक सामग्री सामान्य स्लाइड्स में संग्रहीत होती है। पूरे प्रस्तुति में वास्तविक शीर्षक टेक्स्ट बदलने के लिए स्लाइड्स पर इटररेट करें और प्रत्येक शीर्षक प्लेसहोल्डर को अपडेट करें।

**मैं तिथि, स्लाइड‑नंबर, हेडर और फुटर प्लेसहोल्डर कैसे प्रबंधित करूँ?**

उपयुक्त स्लाइड, लेआउट, मास्टर, नोट्स या हैंडआउट स्तर पर हेडर और फुटर प्रबंधकों का उपयोग करें। पूर्ण उदाहरणों के लिए देखें [Manage Presentation Header and Footer](/slides/hi/python-net/presentation-header-and-footer/).