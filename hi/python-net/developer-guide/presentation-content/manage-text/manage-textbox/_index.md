---
title: "Python के साथ प्रस्तुति में टेक्स्ट बॉक्स प्रबंधित करें"
linktitle: "टेक्स्ट बॉक्स प्रबंधित करें"
type: docs
weight: 20
url: /hi/python-net/manage-textbox/
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
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में टेक्स्ट बॉक्स बनाएं, पहचानें, स्वरूपित करें और अपडेट करें।"
---
## **परिचय**

Aspose.Slides for Python via .NET में, स्लाइड का टेक्स्ट उन टेक्स्ट फ्रेम में संग्रहीत होता है जो आकारों (शेप्स) से संबंधित होते हैं। [AutoShape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/autoshape/) क्लास सबसे सामान्य टेक्स्ट‑धारी आकार का प्रतिनिधित्व करता है और अपना टेक्स्ट [AutoShape.text_frame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/autoshape/text_frame/) प्रॉपर्टी के माध्यम से उजागर करता है।

{{% alert color="info" title="Note" %}}
हर ऑटो शैप [Shape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/shape/) से विरासत में प्राप्त करता है, लेकिन हर शैप ऑटो शैप नहीं होता या टेक्स्ट फ्रेम का समर्थन नहीं करता। मौजूदा प्रस्तुति को प्रोसेस करते समय, टेक्स्ट तक पहुँचने से पहले शैप प्रकार की जाँच के लिए `isinstance(shape, slides.AutoShape)` का उपयोग करें।
{{% /alert %}}

## **स्लाइड पर एक टेक्स्ट बॉक्स बनाएं**

एक टेक्स्ट बॉक्स बनाने के लिए, स्लाइड पर एक ऑटो शैप जोड़ें, उसके टेक्स्ट फ्रेम में टेक्स्ट जोड़ें, और प्रस्तुति को सहेजें। निम्न उदाहरण आयताकार टेक्स्ट बॉक्स बनाता है:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    text_box = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 300, 50)
    text_box.add_text_frame("Aspose TextBox")

    presentation.save("TextBox.pptx", slides.export.SaveFormat.PPTX)
```

[ShapeCollection.add_auto_shape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/shapecollection/add_auto_shape/) को पास किए गए निर्देशांक और आकार पॉइंट में मापे जाते हैं। [AutoShape.add_text_frame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/autoshape/add_text_frame/) प्रदान किए गए टेक्स्ट से टेक्स्ट फ्रेम को प्रारंभिक करता है।

## **टेक्स्ट बॉक्स आकार की जाँच करें**

यह निर्धारित करने के लिए कि कोई ऑटो शैप टेक्स्ट बॉक्स के रूप में माना जाता है या नहीं, [AutoShape.is_text_box](https://reference.aspose.com/slides/hi/python-net/aspose.slides/autoshape/is_text_box/) प्रॉपर्टी का उपयोग करें। यह तब उपयोगी होता है जब प्रस्तुति में टेक्स्ट‑धारी और केवल ग्राफिकल ऑटो शैप दोनों हों।

![एक टेक्स्ट बॉक्स और एक आकार](istextbox.png)

निम्न उदाहरण प्रस्तुति में प्रत्येक ऑटो शैप की जांच करता है:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    text_box = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 120, 40)
    text_box.add_text_frame("Text box")
    slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 150, 10, 40, 40)

    for current_slide in presentation.slides:
        for shape in current_slide.shapes:
            if isinstance(shape, slides.AutoShape):
                print("The shape is a text box." if shape.is_text_box else "The shape is not a text box.")
```

एक नया जोड़ा गया ऑटो शैप तब तक टेक्स्ट बॉक्स नहीं माना जाता जब तक उसमें खाली नहीं‑खाली टेक्स्ट न हो। आप वह टेक्स्ट [AutoShape.add_text_frame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/autoshape/add_text_frame/) या [TextFrame.text](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframe/text/) के माध्यम से प्रदान कर सकते हैं। खाली स्ट्रिंग जोड़ने या असाइन करने से [is_text_box](https://reference.aspose.com/slides/hi/python-net/aspose.slides/autoshape/is_text_box/) `False` पर सेट रहता है:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 40)
    shape1.add_text_frame("Shape 1")
    print(shape1.is_text_box)

    shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 70, 100, 40)
    shape2.text_frame.text = "Shape 2"
    print(shape2.is_text_box)

    shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 130, 100, 40)
    shape3.add_text_frame("")
    print(shape3.is_text_box)

    shape4 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 190, 100, 40)
    shape4.text_frame.text = ""
    print(shape4.is_text_box)
```

पहली दो कॉल `True` प्रिंट करती हैं; अंतिम दो कॉल `False` प्रिंट करती हैं।

## **टेक्स्ट फ्रेम का मालिक आकार खोजें**

जनरिक टेक्स्ट‑प्रोसेसिंग कोड एक [TextFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframe/) प्राप्त कर सकता है बिना यह जाने कि वह कौनसी प्रस्तुति वस्तु में है। उसके मालिक [Shape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/shape/) तक वापस जाने के लिए रीड‑ओनली [TextFrame.parent_shape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframe/parent_shape/) प्रॉपर्टी का उपयोग करें।

ऑटो शैप या अन्य टेक्स्ट‑धारी शैप द्वारा स्वामित्व वाले टेक्स्ट फ्रेम के लिए, [parent_shape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframe/parent_shape/) में मालिक रहता है और [TextFrame.parent_cell](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframe/parent_cell/) `None` होता है। उपयोग करने से पहले लौटाए गए मान की जाँच करें। शैप और टेबल‑सेल दोनों मालिकों की पहचान करने के लिए, जिसमें SmartArt नोड्स से जुड़े शैप शामिल हैं, देखें [टेक्स्ट खोजें और बदलें](/slides/hi/python-net/search-and-replace-text/)।

## **टेक्स्ट बॉक्स में कॉलम जोड़ें**

[TextFrameFormat.column_count](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframeformat/column_count/) प्रॉपर्टी टेक्स्ट फ्रेम को कॉलम में विभाजित करती है, जबकि [TextFrameFormat.column_spacing](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframeformat/column_spacing/) कॉलम के बीच का अंतराल पॉइंट में सेट करती है। दोनों सेटिंग्स [TextFrameFormat](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframeformat/) से संबंधित हैं और मौजूदा टेक्स्ट बॉक्स के टेक्स्ट फ्रेम के माध्यम से बदली जा सकती हैं। टेक्स्ट समान शैप के भीतर कॉलम के बीच पुनः‑फ़्लो होता है; यह किसी अन्य शैप में नहीं जारी रहता।

निम्न उदाहरण तीन‑कॉलम टेक्स्ट बॉक्स बनाता है जिसमें कॉलम के बीच 10 पॉइंट का अंतराल है, प्रस्तुति को सहेजता है, और आउटपुट फ़ाइल से सहेजे गए सेटिंग्स को वापस पढ़ता है:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    text_box = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 300, 200)
    text_box.add_text_frame("This text is distributed automatically across all columns in the text box.")

    text_frame_format = text_box.text_frame.text_frame_format
    text_frame_format.column_count = 3
    text_frame_format.column_spacing = 10

    presentation.save("TextBoxColumns.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("TextBoxColumns.pptx") as saved_presentation:
    saved_text_box = saved_presentation.slides[0].shapes[0]
    if isinstance(saved_text_box, slides.AutoShape):
        saved_format = saved_text_box.text_frame.text_frame_format
        print(f"Columns: {saved_format.column_count}; spacing: {saved_format.column_spacing} points")
```

## **व्यक्तिगत कॉलम से टेक्स्ट निकालें**

[TextFrame.split_text_by_columns](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframe/split_text_by_columns/) का उपयोग करके मौजूदा टेक्स्ट फ्रेम में प्रत्येक दृश्य कॉलम को सौंपा गया टेक्स्ट प्राप्त करें। यह मेथड प्रत्येक कॉलम के लिए एक स्ट्रिंग लौटाता है, कॉलम‑आधारित पढ़ने के क्रम में। एक‑कॉलम टेक्स्ट फ्रेम एक एलिमेंट वाली सूची बनाता है, और खाली कॉलम को खाली स्ट्रिंग द्वारा दर्शाया जाता है। स्ट्रिंग्स में केवल सादा टेक्स्ट होता है; भाग‑स्तर का फ़ॉर्मेटिंग बरकरार नहीं रहता।

यह उपयोगी है जब आपको आवश्यकता हो:

- कॉलम‑आधारित पढ़ने के क्रम को बनाए रखते हुए टेक्स्ट निकालने की।
- बहु‑कॉलम स्लाइड्स की सामग्री को अनुक्रमित या तुलना करने की।
- प्रत्येक कॉलम को अलग फ़ाइल, डेटाबेस फ़ील्ड या अन्य गंतव्य में निर्यात करने की।
- फ़ॉन्ट, या टेक्स्ट‑फ़्रेम आकार, या [TextFrameFormat.column_count], [TextFrameFormat.column_spacing] बदलने के बाद टेक्स्ट कैसे पुनः वितरित होता है, इसका निरीक्षण करने की।

यह मेथड वर्तमान [TextFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframe/) के भीतर वितरित टेक्स्ट की रिपोर्ट करता है; यह अलग-अलग शैप या टेक्स्ट बॉक्स के बीच स्वचालित रूप से टेक्स्ट प्रवाहित नहीं करता। कॉलम वितरण उपलब्ध फ़ॉन्ट और अन्य टेक्स्ट‑लेआउट सेटिंग्स पर निर्भर कर सकता है, इसलिए जब सुसंगत परिणाम महत्वपूर्ण हों तो सुनिश्चित करें कि आवश्यक फ़ॉन्ट उपलब्ध हों।

निम्न उदाहरण एक प्रस्तुति लोड करता है, टेक्स्ट फ्रेम वाले पहले बहु‑कॉलम ऑटो शैप को खोजता है, उसकी कॉन्फ़िगर की गई कॉलम संख्या पढ़ता है, और प्रत्येक कॉलम का टेक्स्ट अलग फ़ाइल में लिखता है। वे शैप जो टेक्स्ट फ्रेम प्रदान नहीं करते उन्हें छोड़ दिया जाता है।

```python
import aspose.slides as slides

with slides.Presentation("MultiColumnText.pptx") as presentation:
    text_box = None
    for shape in presentation.slides[0].shapes:
        if isinstance(shape, slides.AutoShape) and shape.text_frame is not None:
            column_count = shape.text_frame.text_frame_format.column_count
            if column_count > 1:
                text_box = shape
                break

    if text_box is None:
        print("No multi-column text frame was found.")
    else:
        text_frame = text_box.text_frame
        configured_column_count = text_frame.text_frame_format.column_count
        column_texts = text_frame.split_text_by_columns()

        print(f"Configured columns: {configured_column_count}")

        for column_number, column_text in enumerate(column_texts, start=1):
            print(f"Column {column_number}: {column_text}")
            with open(f"Column-{column_number}.txt", "w", encoding="utf-8") as column_file:
                column_file.write(column_text)
```

## **टेक्स्ट अपडेट करें**

पूरी प्रस्तुति में टेक्स्ट अपडेट करने के लिए, स्लाइड और शैप पर इटररेट करें, ऑटो शैप चुनें, और फिर उनके टेक्स्ट भागों को संपादित करें। भाग‑स्तर पर काम करने से आप टेक्स्ट और कैरेक्टर फ़ॉर्मेटिंग दोनों बदल सकते हैं।

निम्न उदाहरण ऑटो‑शैप टेक्स्ट में प्रत्येक `years` को `months` से बदलता है और प्रभावित प्रत्येक भाग को बोल्ड करता है:

```python
import aspose.slides as slides

with slides.Presentation("Text.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if not isinstance(shape, slides.AutoShape) or shape.text_frame is None:
                continue

            for paragraph in shape.text_frame.paragraphs:
                for portion in paragraph.portions:
                    if "years" in portion.text:
                        portion.text = portion.text.replace("years", "months")
                        portion.portion_format.font_bold = slides.NullableBool.TRUE

    presentation.save("TextChanged.pptx", slides.export.SaveFormat.PPTX)
```

यह ट्रैवर्सल केवल ऑटो शैप में टेक्स्ट को अपडेट करता है। टेबल, चार्ट, SmartArt या ग्रुप किए गए शैप में संग्रहीत टेक्स्ट को उन ऑब्जेक्ट्स के अपने संग्रहों की ट्रैवर्सल की आवश्यकता होती है।

## **हाइपरलिंक के साथ एक टेक्स्ट बॉक्स जोड़ें**

हाइपरलिंक को किसी विशिष्ट टेक्स्ट भाग को असाइन किया जा सकता है, ताकि केवल वही टेक्स्ट क्लिक करने योग्य लिंक के रूप में कार्य करे। विशिष्ट भाग को बाहरी URL से जोड़ने के लिए [HyperlinkManager.set_external_hyperlink_click](https://reference.aspose.com/slides/hi/python-net/aspose.slides/hyperlinkmanager/set_external_hyperlink_click/) का उपयोग करें।

निम्न उदाहरण लिंक्ड टेक्स्ट बनाता है और उसे एक प्रस्तुति में सहेजता है:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    text_box = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 150, 200, 50)
    text_box.add_text_frame("Aspose.Slides")

    text_portion = text_box.text_frame.paragraphs[0].portions[0]
    text_portion.portion_format.hyperlink_manager.set_external_hyperlink_click("https://www.aspose.com/")

    presentation.save("Hyperlink.pptx", slides.export.SaveFormat.PPTX)
```

## **अक्सर पूछे जाने वाले प्रश्न**

**एक टेक्स्ट बॉक्स और मास्टर या लेआउट स्लाइड पर टेक्स्ट प्लेसहोल्डर में क्या अंतर है?**

एक [placeholder](/slides/hi/python-net/manage-placeholder/) अपनी स्थिति और फ़ॉर्मेटिंग को [master slide](https://reference.aspose.com/slides/hi/python-net/aspose.slides/masterslide/) या [layout slide](https://reference.aspose.com/slides/hi/python-net/aspose.slides/layoutslide/) से विरासत में ले सकता है। एक सामान्य टेक्स्ट बॉक्स वह स्वतंत्र शैप है जो उस स्लाइड पर बना जहाँ यह बनाया गया और लेआउट बदलने पर प्लेसहोल्डर व्यवहार नहीं प्राप्त करता।

**मैं चार्ट, टेबल या SmartArt में टेक्स्ट बदले बिना टेक्स्ट कैसे बदल सकता हूँ?**

Update Text उदाहरण में दिखाए अनुसार ट्रैवर्सल को केवल [AutoShape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/autoshape/) इंस्टेंस तक सीमित रखें। चार्ट, टेबल और SmartArt अपना टेक्स्ट अपने स्वयं के ऑब्जेक्ट मॉडल में संग्रहीत करते हैं, इसलिए वह लूप द्वारा संशोधित नहीं होते।