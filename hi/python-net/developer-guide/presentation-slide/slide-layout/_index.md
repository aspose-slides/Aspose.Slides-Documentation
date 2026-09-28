---
title: Python में स्लाइड लेआउट लागू करें या बदलें
linktitle: स्लाइड लेआउट
type: docs
weight: 60
url: /hi/python-net/slide-layout/
keywords:
- स्लाइड लेआउट
- सामग्री लेआउट
- प्लेसहोल्डर
- प्रेज़ेंटेशन डिज़ाइन
- स्लाइड डिज़ाइन
- अप्रयुक्त लेआउट
- फुटर दृश्यता
- शीर्षक स्लाइड
- शीर्षक और सामग्री
- सेक्शन हेडर
- दो सामग्री
- तुलना
- केवल शीर्षक
- ब्लैंक लेआउट
- कैप्शन के साथ सामग्री
- कैप्शन के साथ चित्र
- शीर्षक और लंबवत पाठ
- लंबवत शीर्षक और पाठ
- PowerPoint
- OpenDocument
- प्रेज़ेंटेशन
- Python
- Aspose.Slides
description: "Aspose.Slides for Python के माध्यम से .NET में स्लाइड लेआउट लागू करें, बनाएं और संशोधित करें, प्लेसहोल्डर जोड़ें, अप्रयुक्त लेआउट हटाएँ, और फुटर दृश्यता नियंत्रित करें।"
---
## **अवलोकन**

एक स्लाइड लेआउट शीर्षक, पाठ, चित्र, चार्ट और तालिका जैसे प्लेसहोल्डर की स्थान और स्वरूपण को परिभाषित करता है। लेआउट लागू करने से स्लाइड्स को एकसमान संरचना मिलती है और प्रत्येक स्लाइड को अपना स्वयं का कंटेंट रखने की अनुमति मिलती है।

सबसे सामान्य लेआउट्स में शामिल हैं:

- **Title Slide**: शीर्षक और उपशीर्षक प्लेसहोल्डर शामिल हैं।
- **Title and Content**: एक शीर्षक प्लेसहोल्डर और सामान्य प्रयोजन कंटेंट प्लेसहोल्डर शामिल है।
- **Blank**: कोई कंटेंट प्लेसहोल्डर नहीं होता और यह तब उपयोगी होता है जब प्रत्येक आकार को मैन्युअल रूप से स्थित किया जाता है।

## **लेआउट विरासत को समझें**

एक प्रस्तुति के तीन संबंधित स्तर होते हैं:

1. A [मास्टर स्लाइड](https://reference.aspose.com/slides/hi/python-net/aspose.slides/masterslide/) थीम, साझा स्वरूपण, पृष्ठभूमि और सामान्य वस्तुओं को परिभाषित करता है।
2. A [लेआउट स्लाइड](https://reference.aspose.com/slides/hi/python-net/aspose.slides/layoutslide/) एक मास्टर से जुड़ी होती है और प्लेसहोल्डर की विशिष्ट व्यवस्था को निर्धारित करती है।
3. A [सामान्य स्लाइड](https://reference.aspose.com/slides/hi/python-net/aspose.slides/slide/) एक लेआउट का उपयोग करती है और उस स्लाइड के लिए दर्ज किया गया कंटेंट संग्रहीत करती है।

एक सामान्य स्लाइड अपना थीम और स्वरूपण लेआउट से विरासत में प्राप्त करती है, और लेआउट अपना मास्टर से विरासत में प्राप्त करता है। सामान्य स्लाइड पर सीधे सेट किया गया मान उस स्तर पर विरासत में मिले मान को ओवरराइड करता है। जब एक सामान्य स्लाइड बनाई जाती है, तो उसके प्लेसहोल्डर शेपे चुने गए लेआउट से उत्पन्न होते हैं, जबकि उन प्लेसहोल्डर में दर्ज किया गया कंटेंट सामान्य स्लाइड से संबंधित रहता है।

लेआउट से स्लाइड्स बनाने से पहले आवश्यक प्लेसहोल्डर जोड़ें। बाद में लेआउट में एक और प्लेसहोल्डर जोड़ने से मौजूदा सामान्य स्लाइड्स में स्वचालित रूप से संबंधित प्लेसहोल्डर शेप नहीं जुड़ता।

इस संबंध के दो महत्वपूर्ण परिणाम हैं:

- लेआउट पर विरासत में मिले स्वरूपण या मौजूदा प्लेसहोल्डर ज्यामिति को बदलने से उन सभी स्लाइड्स को अपडेट किया जा सकता है जो इस पर निर्भर हैं। पहले से उपयोग में हो रहे लेआउट को संपादित करने से पहले, उसकी निर्भर स्लाइड्स की जाँच करें और परिणामी प्रस्तुति की समीक्षा करें।
- वह लेआउट जिसे अभी भी कोई स्लाइड उपयोग कर रही है, उसे हटाया नहीं जा सकता। पहले उसकी निर्भर स्लाइड्स को किसी अन्य लेआउट में पुनः असाइन करें, या केवल अप्रयुक्त लेआउट्स ही हटाएँ।

इस पदानुक्रम के शीर्ष स्तर के बारे में अधिक जानकारी के लिए देखें [Slide Master](/slides/hi/python-net/slide-master/)।

एक स्लाइड पर या साझा लेआउट के माध्यम से विरासत में मिले लोगो या सजावटी मास्टर शेप को छिपाने के लिए देखें [Control the Visibility of Master Graphics](/slides/hi/python-net/slide-master/)। उदाहरण समान मास्टर का उपयोग करने वाली दो स्लाइड्स की तुलना करता है।

## **स्लाइड लेआउट का चयन और लागू करना**

जब प्रस्तुति मानक PowerPoint लेआउट परिभाषाओं का अनुसरण करती है, तो एक लेआउट प्रकार का उपयोग करें। लेआउट नाम उपयोगकर्ता‑संपादन योग्य होते हैं और स्थानीयकृत किए जा सकते हैं, इसलिए स्रोत टेम्प्लेट को नियंत्रित न करने पर नाम‑आधारित चयन कम विश्वसनीय है।

निम्न उदाहरण पहले मास्टर पर **Title and Content** खोजता है। यदि वह लेआउट उपलब्ध नहीं है, तो यह जानबूझकर **Blank** पर फॉल बैक करता है। दूसरा null चेक आवश्यक है क्योंकि एक प्रस्तुति में केवल कस्टम लेआउट्स हो सकते हैं। चयनित लेआउट फिर [Slide.layout_slide](https://reference.aspose.com/slides/hi/python-net/aspose.slides/slide/layout_slide/) प्रॉपर्टी के माध्यम से पहले सामान्य स्लाइड पर लागू किया जाता है।

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    layout_slides = presentation.masters[0].layout_slides
    target_layout = layout_slides.get_by_type(slides.SlideLayoutType.TITLE_AND_OBJECT)

    if target_layout is None:
        target_layout = layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    if target_layout is None:
        raise RuntimeError("The first master does not contain a suitable layout slide.")

    presentation.slides[0].layout_slide = target_layout
    presentation.save("output-with-new-layout.pptx", slides.export.SaveFormat.PPTX)
```

एक स्लाइड का लेआउट बदलने से सीधे स्लाइड में जोड़े गए सामान्य शेप नहीं हटते। हालांकि, प्लेसहोल्डर की स्थितियाँ, विरासत में मिला स्वरूपण, और मौजूदा प्लेसहोल्डर और नए लेआउट के बीच की संगति बदल सकती है, इसलिए विभिन्न लेआउट्स के बीच स्विच करते समय आउटपुट की जाँच करें।

## **लेआउट स्लाइड जोड़ें**

चयन और निर्माण अलग‑अलग संचालन हैं। पिछला उदाहरण मौजूदा लेआउट को चुनता है; यह नया नहीं बनाता। लेआउट बनाने के लिए लक्ष्य मास्टर के लेआउट कलेक्शन पर [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/hi/python-net/aspose.slides/masterlayoutslidecollection/add/) मेथड को कॉल करें।

निम्न उदाहरण हमेशा `Report Title and Content` नामक नया **Title and Content** लेआउट जोड़ता है, फिर उस पर आधारित एक सामान्य स्लाइड जोड़ता है। लेआउट नाम कलेक्शन के भीतर अद्वितीय होना चाहिए।

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    master_slide = presentation.masters[0]
    report_layout = master_slide.layout_slides.add(slides.SlideLayoutType.TITLE_AND_OBJECT, "Report Title and Content")
    presentation.slides.add_empty_slide(report_layout)

    presentation.save("output-with-report-layout.pptx", slides.export.SaveFormat.PPTX)
```

टेम्प्लेट को वास्तव में किसी अतिरिक्त पुनः प्रयोज्य संरचना की आवश्यकता होने पर ही लेआउट जोड़ें। यदि उपयुक्त लेआउट पहले से मौजूद है, तो इसे बनाकर दोहराने के बजाय चुनें और पुनः उपयोग करें।

## **लेआउट स्लाइड में प्लेसहोल्डर जोड़ें**

[LayoutSlide.placeholder_manager](https://reference.aspose.com/slides/hi/python-net/aspose.slides/layoutslide/placeholder_manager/) प्रॉपर्टी एक [LayoutPlaceholderManager](https://reference.aspose.com/slides/hi/python-net/aspose.slides/layoutplaceholdermanager/) प्रदान करती है जिससे लेआउट में प्लेसहोल्डर शेप जोड़े जा सकते हैं।

| PowerPoint प्लेसहोल्डर | `LayoutPlaceholderManager` Method |
| ----------------------- | --------------------------------- |
| ![सामग्री](content.png) | [`add_content_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/hi/python-net/aspose.slides/layoutplaceholdermanager/add_content_placeholder/) |
| ![सामग्री (लंबवत)](contentV.png) | [`add_vertical_content_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/hi/python-net/aspose.slides/layoutplaceholdermanager/add_vertical_content_placeholder/) |
| ![पाठ](text.png) | [`add_text_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/hi/python-net/aspose.slides/layoutplaceholdermanager/add_text_placeholder/) |
| ![पाठ (लंबवत)](textV.png) | [`add_vertical_text_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/hi/python-net/aspose.slides/layoutplaceholdermanager/add_vertical_text_placeholder/) |
| ![चित्र](picture.png) | [`add_picture_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/hi/python-net/aspose.slides/layoutplaceholdermanager/add_picture_placeholder/) |
| ![चार्ट](chart.png) | [`add_chart_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/hi/python-net/aspose.slides/layoutplaceholdermanager/add_chart_placeholder/) |
| ![तालिका](table.png) | [`add_table_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/hi/python-net/aspose.slides/layoutplaceholdermanager/add_table_placeholder/) |
| ![स्मार्टआर्ट](smartart.png) | [`add_smart_art_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/hi/python-net/aspose.slides/layoutplaceholdermanager/add_smart_art_placeholder/) |
| ![मीडिया](media.png) | [`add_media_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/hi/python-net/aspose.slides/layoutplaceholdermanager/add_media_placeholder/) |
| ![ऑनलाइन छवि](onlineImage.png) | [`add_online_image_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/hi/python-net/aspose.slides/layoutplaceholdermanager/add_online_image_placeholder/) |

निम्न उदाहरण जाँचता है कि **Blank** लेआउट मौजूद है, उसमें चार प्लेसहोल्डर जोड़ता है, और फिर संशोधित लेआउट का उपयोग करने वाली एक सामान्य स्लाइड बनाता है। क्रम जानबूझकर रखा गया है: प्लेसहोल्डर पहले जोड़े जाते हैं, फिर सामान्य स्लाइड बनाई जाती है, ताकि Aspose.Slides उस स्लाइड पर संबंधित प्लेसहोल्डर शेप उत्पन्न कर सके।

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    blank_layout = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    if blank_layout is None:
        raise RuntimeError("The presentation does not contain a Blank layout slide.")

    placeholder_manager = blank_layout.placeholder_manager
    placeholder_manager.add_content_placeholder(20, 20, 310, 270)
    placeholder_manager.add_vertical_text_placeholder(350, 20, 350, 270)
    placeholder_manager.add_chart_placeholder(20, 310, 310, 180)
    placeholder_manager.add_table_placeholder(350, 310, 350, 180)

    presentation.slides.add_empty_slide(blank_layout)
    presentation.save("output-with-placeholders.pptx", slides.export.SaveFormat.PPTX)
```

परिणाम:

![लेआउट स्लाइड पर प्लेसहोल्डर](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
विरासत में मिले स्वरूपण या मौजूदा लेआउट प्लेसहोल्डर की ज्यामिति को बदलने से निर्भर स्लाइड्स प्रभावित हो सकती हैं। नया जोड़ा गया लेआउट प्लेसहोल्डर मौजूदा सामान्य स्लाइड्स में बैकफ़िल नहीं होता। लेआउट परिवर्तन को प्रस्तुति की एक कॉपी पर परीक्षण करें और प्रत्येक निर्भर स्लाइड की जाँच करें।
{{% /alert %}}

## **बिना प्रयोग के लेआउट स्लाइड्स हटाएँ**

लेआउट हटाने के लिए उन लेआउट्स को हटाने हेतु [Compress.remove_unused_layout_slides](https://reference.aspose.com/slides/hi/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/) मेथड का उपयोग करें जो कोई सामान्य स्लाइड संदर्भित नहीं करती। यह मेथड अभी भी उपयोग में रहे लेआउट्स को बरकरार रखता है।

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_layout_slides(presentation)
    presentation.save("output-without-unused-layouts.pptx", slides.export.SaveFormat.PPTX)
```

एक विशिष्ट लेआउट हटाने के लिए पहले उसका [has_depending_slides](https://reference.aspose.com/slides/hi/python-net/aspose.slides/layoutslide/has_depending_slides/) प्रॉपर्टी या [get_depending_slides](https://reference.aspose.com/slides/hi/python-net/aspose.slides/layoutslide/get_depending_slides/) मेथड उपयोग करें। [LayoutSlide.remove](https://reference.aspose.com/slides/hi/python-net/aspose.slides/layoutslide/remove/) कॉल करने से पहले किसी भी निर्भर स्लाइड को पुनः असाइन करें। उपयोग में होने वाले लेआउट को हटाने का प्रयास करने पर एक [PptxEditException](https://reference.aspose.com/slides/hi/python-net/aspose.slides/pptxeditexception/) उत्पन्न होता है।

## **लेआउट स्लाइड पर फुटर दृश्यता नियंत्रित करें**

एक लेआउट के अपने स्वयं के फुटर, स्लाइड‑नंबर और दिनांक‑समय प्लेसहोल्डर होते हैं। एक लेआउट के लिए उन प्लेसहोल्डर को नियंत्रित करने हेतु [LayoutSlide.header_footer_manager](https://reference.aspose.com/slides/hi/python-net/aspose.slides/layoutslide/header_footer_manager/) प्रॉपर्टी का उपयोग करें। यह उपयोगी है जब उदाहरण के तौर पर कंटेंट लेआउट्स को फुटर दिखाना चाहिए लेकिन टाइटल लेआउट्स को नहीं।

निम्न उदाहरण सुरक्षित रूप से एक लेआउट चुनता है और उसके फुटर तत्वों को दृश्य बनाता है:

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.TITLE_AND_OBJECT)

    if layout_slide is None:
        layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    if layout_slide is None:
        raise RuntimeError("The presentation does not contain a suitable layout slide.")

    header_footer_manager = layout_slide.header_footer_manager
    header_footer_manager.set_footer_visibility(True)
    header_footer_manager.set_slide_number_visibility(True)
    header_footer_manager.set_date_time_visibility(True)
    header_footer_manager.set_footer_text("Footer text")
    header_footer_manager.set_date_time_text("Date and time text")

    presentation.save("output-with-layout-footers.pptx", slides.export.SaveFormat.PPTX)
```

## **मास्टर और उसके चाइल्ड लेआउट्स पर फुटर दृश्यता नियंत्रित करें**

मास्टर पदानुक्रम में सुसंगत फुटर सेटिंग्स लागू करने के लिए [MasterSlide.header_footer_manager](https://reference.aspose.com/slides/hi/python-net/aspose.slides/masterslide/header_footer_manager/) प्रॉपर्टी का उपयोग करें। [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/hi/python-net/aspose.slides/masterslideheaderfootermanager/) की प्रसार विधियाँ मास्टर और उसके निर्भर लेआउट स्लाइड्स तथा सामान्य स्लाइड्स पर लागू होती हैं; वे केवल एक सामान्य स्लाइड को लक्षित नहीं करतीं।

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    header_footer_manager = presentation.masters[0].header_footer_manager
    header_footer_manager.set_footer_and_child_footers_visibility(True)
    header_footer_manager.set_slide_number_and_child_slide_numbers_visibility(True)
    header_footer_manager.set_date_time_and_child_date_times_visibility(True)
    header_footer_manager.set_footer_and_child_footers_text("Footer text")
    header_footer_manager.set_date_time_and_child_date_times_text("Date and time text")

    presentation.save("output-with-master-footers.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**मास्टर स्लाइड और लेआउट स्लाइड में क्या अंतर है?**

मास्टर स्लाइड प्रस्तुति के थीम और साझा स्वरूपण को परिभाषित करती है। लेआउट स्लाइड एक मास्टर से जुड़ी होती है और प्लेसहोल्डर की पुनः प्रयोग योग्य व्यवस्था को निर्धारित करती है। सामान्य स्लाइड्स उन लेआउट्स का उपयोग करती हैं और स्लाइड‑विशिष्ट कंटेंट संग्रहीत करती हैं।

**क्या मैं एक लेआउट स्लाइड को एक प्रस्तुति से दूसरी प्रस्तुति में कॉपी कर सकता हूँ?**

हाँ। लक्ष्य कलेक्शन में कॉपी जोड़ने के लिए [add_clone](https://reference.aspose.com/slides/hi/python-net/aspose.slides/globallayoutslidecollection/add_clone/) मेथड का उपयोग करें। विभिन्न प्रस्तुतियों के बीच कॉपी करते समय फ़ॉन्ट, थीम, चित्र और स्रोत लेआउट द्वारा उपयोग किए गए अन्य संसाधनों की भी जाँच करें।

**जब मैं पहले से उपयोग में हो रहे लेआउट को संशोधित करता हूँ तो क्या होता है?**

निर्भर स्लाइड्स लेआउट परिवर्तनों को विरासत में प्राप्त करती हैं जब तक कि वे प्रभावित स्वरूपण या वस्तुओं को स्थानीय रूप से ओवरराइड न करें। प्लेसहोल्डर की ज्यामिति और विरासत में मिला स्टाइल कई स्लाइड्स पर एक साथ बदल सकता है। संपादन से पहले प्रभावित स्लाइड्स की पहचान के लिए [get_depending_slides](https://reference.aspose.com/slides/hi/python-net/aspose.slides/layoutslide/get_depending_slides/) उपयोग करें।

**यदि मैं अभी भी उपयोग में रहे लेआउट को हटाता हूँ तो क्या होता है?**

Aspose.Slides एक [PptxEditException](https://reference.aspose.com/slides/hi/python-net/aspose.slides/pptxeditexception/) उत्पन्न करता है। पहले निर्भर स्लाइड्स को पुनः असाइन करें, या केवल बिना संदर्भ वाले लेआउट्स को हटाने के लिए [remove_unused_layout_slides](https://reference.aspose.com/slides/hi/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/) इस्तेमाल करें।