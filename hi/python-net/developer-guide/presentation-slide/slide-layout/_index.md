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
- प्रस्तुति डिजाइन
- स्लाइड डिजाइन
- अप्रयुक्त लेआउट
- फुटर दृश्यता
- शीर्षक स्लाइड
- शीर्षक और सामग्री
- सेक्शन हेडर
- दो सामग्री
- तुलना
- केवल शीर्षक
- खाली लेआउट
- कैप्शन के साथ सामग्री
- कैप्शन के साथ चित्र
- शीर्षक और वर्टिकल टेक्स्ट
- वर्टिकल शीर्षक और टेक्स्ट
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET में स्लाइड लेआउट लागू करें, बनाएं और संशोधित करें, प्लेसहोल्डर जोड़ें, अप्रयुक्त लेआउट हटाएँ, और फुटर दृश्यता नियंत्रित करें।"
---
## **अवलोकन**

एक स्लाइड लेआउट प्लेसहोल्डर जैसे शीर्षक, टेक्स्ट, चित्र, चार्ट, और तालिकाओं की स्थिति और स्वरूपण को परिभाषित करता है। लेआउट लागू करने से स्लाइड्स को एक सुसंगत संरचना मिलती है जबकि प्रत्येक स्लाइड को अपना स्वयं का कंटेंट रखने की अनुमति मिलती है।

सबसे सामान्य लेआउट्स में शामिल हैं:

- **शीर्षक स्लाइड**: शीर्षक और उपशीर्षक प्लेसहोल्डर शामिल हैं।
- **शीर्षक और कंटेंट**: एक शीर्षक प्लेसहोल्डर और एक सामान्य-उपयोग कंटेंट प्लेसहोल्डर शामिल है।
- **खाली**: कोई कंटेंट प्लेसहोल्डर नहीं होते और यह तब उपयोगी होता है जब हर आकार को मैन्युअली स्थित किया जाएगा।

## **लेआउट उत्तराधिकार को समझें**

एक प्रस्तुति में तीन संबंधित स्तर होते हैं:

1. एक [master slide](https://reference.aspose.com/slides/hi/python-net/aspose.slides/masterslide/) थीम, साझा स्वरूपण, पृष्ठभूमि, और सामान्य वस्तुओं को परिभाषित करता है।
2. एक [layout slide](https://reference.aspose.com/slides/hi/python-net/aspose.slides/layoutslide/) मास्टर से संबंधित है और प्लेसहोल्डर की एक विशेष व्यवस्था को परिभाषित करता है।
3. एक [normal slide](https://reference.aspose.com/slides/hi/python-net/aspose.slides/slide/) एक लेआउट का उपयोग करता है और उस स्लाइड के लिये दर्ज किया गया कंटेंट संग्रहीत करता है।

एक सामान्य स्लाइड अपने लेआउट से थीम और स्वरूपण को विरासत में लेती है, और लेआउट अपने मास्टर से। सामान्य स्लाइड पर सीधे सेट किया गया मान उस स्तर पर विरासत में मिला मान को ओवरराइड करता है। जब एक सामान्य स्लाइड बनाई जाती है, तो उसके प्लेसहोल्डर शैप्स चयनित लेआउट से जेनरेट होते हैं, जबकि उन प्लेसहोल्डर में दर्ज किया गया कंटेंट सामान्य स्लाइड का होता है।

लेआउट बनाकर स्लाइड्स बनाने से पहले आवश्यक प्लेसहोल्डर जोड़ें। बाद में लेआउट में दूसरा प्लेसहोल्डर जोड़ने से मौजूदा सामान्य स्लाइड्स में स्वतः संबंधित प्लेसहोल्डर शैप नहीं जुड़ता।

इस संबंध के दो महत्वपूर्ण परिणाम हैं:

- लेआउट पर विरासत में मिला स्वरूपण या मौजूदा प्लेसहोल्डर ज्यामिति बदलने से उस पर निर्भर सभी स्लाइड्स अपडेट हो सकती हैं। उपयोग में पहले से मौजूद लेआउट को संपादित करने से पहले, उसकी निर्भर स्लाइड्स का निरीक्षण करें और परिणामस्वरूप प्रस्तुति की समीक्षा करें।
- वह लेआउट जिसे अभी भी कोई स्लाइड उपयोग कर रही है, हटाया नहीं जा सकता। पहले उसकी निर्भर स्लाइड्स को दूसरे लेआउट पर पुनः असाइन करें, या केवल अप्रयुक्त लेआउट्स ही हटाएँ।

इस पदानुक्रम के शीर्ष स्तर के बारे में अधिक जानकारी के लिये देखें [Slide Master](/slides/hi/python-net/slide-master/)।

## **एक स्लाइड लेआउट को चुनें और लागू करें**

जब प्रस्तुति मानक PowerPoint लेआउट परिभाषाओं का पालन करती है तो लेआउट प्रकार का उपयोग करें। लेआउट नाम उपयोगकर्ता‑संपादनीय होते हैं और स्थानीयकृत किए जा सकते हैं, इसलिए स्रोत टेम्प्लेट पर नियंत्रण न हो तो नाम‑आधारित चयन कम विश्वसनीय होता है।

निम्न उदाहरण पहले मास्टर पर **Title and Content** को खोजता है। यदि वह लेआउट उपलब्ध नहीं है, तो जानबूझकर **Blank** पर वापस लौटता है। दूसरा null चेक आवश्यक है क्योंकि प्रस्तुति में केवल कस्टम लेआउट्स हो सकते हैं। चयनित लेआउट फिर पहले सामान्य स्लाइड पर [Slide.layout_slide](https://reference.aspose.com/slides/hi/python-net/aspose.slides/slide/layout_slide/) प्रॉपर्टी के माध्यम से लागू किया जाता है।

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

स्लाइड का लेआउट बदलने से सीधे स्लाइड में जोड़े गए सामान्य आकार हटते नहीं हैं। हालांकि, प्लेसहोल्डर स्थितियाँ, विरासत में मिला स्वरूपण, और मौजूदा प्लेसहोल्डर तथा नए लेआउट के बीच का संबंध बदल सकता है, इसलिए अलग‑अलग लेआउट्स के बीच स्विच करते समय आउटपुट की जाँच करें।

## **एक लेआउट स्लाइड जोड़ें**

चयन और निर्माण अलग‑अलग कार्य हैं। पिछला उदाहरण मौजूदा लेआउट का चयन करता है; यह नया नहीं बनाता। लेआउट बनाने के लिये, लक्ष्य मास्टर के लेआउट कलेक्शन पर [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/hi/python-net/aspose.slides/masterlayoutslidecollection/add/) मेथड को कॉल करें।

निम्न उदाहरण हमेशा नई **Title and Content** लेआउट जिसका नाम `Report Title and Content` है, जोड़ता है, फिर उस पर आधारित एक सामान्य स्लाइड जोड़ता है। लेआउट नाम कलेक्शन के भीतर अद्वितीय होने चाहिए।

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    master_slide = presentation.masters[0]
    report_layout = master_slide.layout_slides.add(slides.SlideLayoutType.TITLE_AND_OBJECT, "Report Title and Content")
    presentation.slides.add_empty_slide(report_layout)

    presentation.save("output-with-report-layout.pptx", slides.export.SaveFormat.PPTX)
```

टेम्प्लेट को वास्तव में दूसरी पुन: उपयोग योग्य संरचना की आवश्यकता होने पर ही लेआउट जोड़ें। यदि उपयुक्त लेआउट पहले से मौजूद है, तो उसे चयनित करके पुनः उपयोग करें, न कि नया बनाकर डुप्लिकेट बनायें।

## **लेआउट स्लाइड में प्लेसहोल्डर जोड़ें**

[LayoutSlide.placeholder_manager](https://reference.aspose.com/slides/hi/python-net/aspose.slides/layoutslide/placeholder_manager/) प्रॉपर्टी लेआउट में प्लेसहोल्डर शैप्स जोड़ने के लिये एक [LayoutPlaceholderManager](https://reference.aspose.com/slides/hi/python-net/aspose.slides/layoutplaceholdermanager/) प्रदान करती है।

| PowerPoint प्लेसहोल्डर            | `LayoutPlaceholderManager` मेथड |
| ----------------------------------- | --------------------------------- |
| ![कंटेंट](content.png)             | [`add_content_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/hi/python-net/aspose.slides/layoutplaceholdermanager/add_content_placeholder/) |
| ![कंटेंट (वर्टिकल)](contentV.png) | [`add_vertical_content_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/hi/python-net/aspose.slides/layoutplaceholdermanager/add_vertical_content_placeholder/) |
| ![टेक्स्ट](text.png)               | [`add_text_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/hi/python-net/aspose.slides/layoutplaceholdermanager/add_text_placeholder/) |
| ![टेक्स्ट (वर्टिकल)](textV.png)   | [`add_vertical_text_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/hi/python-net/aspose.slides/layoutplaceholdermanager/add_vertical_text_placeholder/) |
| ![चित्र](picture.png)              | [`add_picture_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/hi/python-net/aspose.slides/layoutplaceholdermanager/add_picture_placeholder/) |
| ![चार्ट](chart.png)                | [`add_chart_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/hi/python-net/aspose.slides/layoutplaceholdermanager/add_chart_placeholder/) |
| ![तालिका](table.png)               | [`add_table_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/hi/python-net/aspose.slides/layoutplaceholdermanager/add_table_placeholder/) |
| ![SmartArt](smartart.png)           | [`add_smart_art_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/hi/python-net/aspose.slides/layoutplaceholdermanager/add_smart_art_placeholder/) |
| ![मीडिया](media.png)                | [`add_media_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/hi/python-net/aspose.slides/layoutplaceholdermanager/add_media_placeholder/) |
| ![ऑनलाइन इमेज](onlineImage.png)   | [`add_online_image_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/hi/python-net/aspose.slides/layoutplaceholdermanager/add_online_image_placeholder/) |

निम्न उदाहरण सत्यापित करता है कि **Blank** लेआउट मौजूद है, उसमें चार प्लेसहोल्डर जोड़ता है, फिर संशोधित लेआउट का उपयोग करने वाली एक सामान्य स्लाइड बनाता है। क्रम का इरादा है: प्लेसहोल्डर पहले जोड़े जाते हैं और फिर सामान्य स्लाइड बनाई जाती है, ताकि Aspose.Slides उस स्लाइड पर संबंधित प्लेसहोल्डर शैप्स जेनरेट कर सके।

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
विरासत में मिले स्वरूपण या मौजूदा लेआउट प्लेसहोल्डर की ज्यामिति बदलने से निर्भर स्लाइड्स प्रभावित हो सकती हैं। नया जोड़ा गया लेआउट प्लेसहोल्डर मौजूदा सामान्य स्लाइड्स में स्वतः नहीं भरता। प्रस्तुति की एक कॉपी पर लेआउट परिवर्तन परीक्षण करें और प्रत्येक निर्भर स्लाइड की जाँच करें।
{{% /alert %}}

## **अप्रयुक्त लेआउट स्लाइड्स हटाएँ**

[Compress.remove_unused_layout_slides](https://reference.aspose.com/slides/hi/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/) मेथड का उपयोग करके उन लेआउट्स को हटाएँ जिनका कोई सामान्य स्लाइड संदर्भित नहीं करता। यह मेथड अभी भी उपयोग में मौजूद लेआउट्स को वही रखता है।

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_layout_slides(presentation)
    presentation.save("output-without-unused-layouts.pptx", slides.export.SaveFormat.PPTX)
```

एक विशिष्ट लेआउट हटाने के लिये, पहले उसकी [has_depending_slides](https://reference.aspose.com/slides/hi/python-net/aspose.slides/layoutslide/has_depending_slides/) प्रॉपर्टी या [get_depending_slides](https://reference.aspose.com/slides/hi/python-net/aspose.slides/layoutslide/get_depending_slides/) मेथड का उपयोग करें। [LayoutSlide.remove](https://reference.aspose.com/slides/hi/python-net/aspose.slides/layoutslide/remove/) को कॉल करने से पहले किसी भी निर्भर स्लाइड को पुनः असाइन करें। उपयोग में रहे लेआउट को हटाने का प्रयास करने पर एक [PptxEditException](https://reference.aspose.com/slides/hi/python-net/aspose.slides/pptxeditexception/) उत्पन्न होता है।

## **लेआउट स्लाइड पर फुटर दृश्यता नियंत्रित करें**

लेआउट का अपना फुटर, स्लाइड‑नंबर और डेट‑टाइम प्लेसहोल्डर होता है। एक लेआउट के लिये इन प्लेसहोल्डर को नियंत्रित करने के लिये [LayoutSlide.header_footer_manager](https://reference.aspose.com/slides/hi/python-net/aspose.slides/layoutslide/header_footer_manager/) प्रॉपर्टी का उपयोग करें। यह तब उपयोगी है जब उदाहरण के लिये कंटेंट लेआउट्स को फुटर दिखाना चाहिए लेकिन शीर्षक लेआउट्स को नहीं।

निम्न उदाहरण सुरक्षित रूप से एक लेआउट का चयन करता है और उसके फुटर तत्वों को दृश्यमान बनाता है:

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

एक मास्टर पदानुक्रम में सुसंगत फुटर सेटिंग्स लागू करने के लिये, [MasterSlide.header_footer_manager](https://reference.aspose.com/slides/hi/python-net/aspose.slides/masterslide/header_footer_manager/) प्रॉपर्टी का उपयोग करें। [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/hi/python-net/aspose.slides/masterslideheaderfootermanager/) के प्रोपीगेशन मेथड्स मास्टर और उसकी निर्भर लेआउट स्लाइड्स तथा सामान्य स्लाइड्स पर कार्य करते हैं; वे केवल एक सामान्य स्लाइड को लक्षित नहीं करते।

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

## **अक्सर पूछे जाने वाले प्रश्न**

**What Is the Difference Between a Master Slide and a Layout Slide?**  
मास्टर स्लाइड प्रस्तुति की थीम और साझा स्वरूपण को परिभाषित करती है। लेआउट स्लाइड मास्टर से संबंधित होती है और प्लेसहोल्डर की एक पुन: उपयोग योग्य व्यवस्था को परिभाषित करती है। सामान्य स्लाइड्स उन लेआउट्स का उपयोग करती हैं और स्लाइड‑विशिष्ट कंटेंट संग्रहीत करती हैं।

**Can I Copy a Layout Slide from One Presentation to Another?**  
हां। आप [add_clone](https://reference.aspose.com/slides/hi/python-net/aspose.slides/globallayoutslidecollection/add_clone/) मेथड से लक्ष्य कलेक्शन में एक कॉपी जोड़ सकते हैं। प्रस्तुति के बीच कॉपी करते समय फ़ॉन्ट्स, थीम्स, इमेजेज और स्रोत लेआउट द्वारा उपयोग किए गए अन्य संसाधनों की भी जाँच करें।

**What Happens When I Modify a Layout That Is Already in Use?**  
निर्भर स्लाइड्स लेआउट परिवर्तन को विरासत में लेती हैं जब तक कि उन्होंने स्थानीय रूप से प्रभावित स्वरूपण या वस्तुओं को ओवरराइड न किया हो। प्लेसहोल्डर ज्यामिति और विरासत में मिला स्टाइल कई स्लाइड्स पर एक साथ बदल सकता है। संपादित करने से पहले प्रभावित स्लाइड्स की पहचान करने के लिये [get_depending_slides](https://reference.aspose.com/slides/hi/python-net/aspose.slides/layoutslide/get_depending_slides/) का उपयोग करें।

**What Happens If I Remove a Layout That Is Still in Use?**  
Aspose.Slides एक [PptxEditException](https://reference.aspose.com/slides/hi/python-net/aspose.slides/pptxeditexception/) उत्पन्न करता है। पहले निर्भर स्लाइड्स को पुनः असाइन करें, या केवल अनरेफरेंस्ड लेआउट्स को हटाने के लिये [remove_unused_layout_slides](https://reference.aspose.com/slides/hi/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/) का उपयोग करें।