---
title: Python में स्लाइड लेआउट लागू या बदलें
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
- फ़ुटर दृश्यता
- शीर्षक स्लाइड
- शीर्षक और सामग्री
- सेक्शन हेडर
- दो सामग्री
- तुलना
- केवल शीर्षक
- खाली लेआउट
- कैप्शन सहित सामग्री
- कैप्शन सहित चित्र
- शीर्षक और लंबवत टेक्स्ट
- लंबवत शीर्षक और टेक्स्ट
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET में स्लाइड लेआउट को प्रबंधित और कस्टमाइज़ करना सीखें। लेआउट प्रकार, प्लेसहोल्डर नियंत्रण, फ़ुटर दृश्यता, और कोड उदाहरणों के माध्यम से लेआउट हेरफेर को अन्वेषण करें।"
---
## **परिचय**

एक स्लाइड लेआउट स्लाइड पर सामग्री के लिए प्लेसहोल्डर बॉक्सों की व्यवस्था और फॉर्मेटिंग को परिभाषित करता है। यह नियंत्रित करता है कि कौन से प्लेसहोल्डर उपलब्ध हैं और वे कहाँ दिखाई देते हैं। स्लाइड लेआउट आपको प्रस्तुतियों को तेजी से और सुसंगत रूप से डिज़ाइन करने में मदद करता है— चाहे आप कुछ सरल या अधिक जटिल बना रहे हों। PowerPoint में सबसे आम स्लाइड लेआउट में शामिल हैं:

**Title Slide लेआउट** – दो टेक्स्ट प्लेसहोल्डर शामिल करता है: एक शीर्षक के लिए और एक उपशीर्षक के लिए।

**Title and Content लेआउट** – शीर्ष पर छोटा शीर्षक प्लेसहोल्डर और नीचे मुख्य सामग्री (जैसे टेक्स्ट, बुलेट पॉइंट, चार्ट, इमेज आदि) के लिए बड़ा प्लेसहोल्डर प्रदान करता है।

**Blank लेआउट** – कोई प्लेसहोल्डर नहीं होता, जिससे आपको स्लाइड को शून्य से डिज़ाइन करने की पूरी आज़ादी मिलती है।

स्लाइड लेआउट स्लाइड मास्टर का हिस्सा होते हैं, जो प्रस्तुति के लिए लेआउट शैलियों को परिभाषित करने वाला शीर्ष‑स्तर स्लाइड है। आप लेआउट स्लाइड्स को स्लाइड मास्टर के माध्यम से—उनके प्रकार, नाम या विशिष्ट ID द्वारा—पहुंच और संशोधित कर सकते हैं। वैकल्पिक रूप से, आप प्रस्तुति के भीतर सीधे किसी विशेष लेआउट स्लाइड को संपादित कर सकते हैं।

Aspose.Slides for Python में स्लाइड लेआउट के साथ काम करने के लिए आप उपयोग कर सकते हैं:

- Properties such as [layout_slides](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/layout_slides/) and [masters](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/masters/) under the [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) class
- Types like [LayoutSlide](https://reference.aspose.com/slides/hi/python-net/aspose.slides/layoutslide/), [MasterLayoutSlideCollection](https://reference.aspose.com/slides/hi/python-net/aspose.slides/masterlayoutslidecollection/), [LayoutPlaceholderManager](https://reference.aspose.com/slides/hi/python-net/aspose.slides/layoutplaceholdermanager/), and [LayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/hi/python-net/aspose.slides/layoutslideheaderfootermanager/)

{{% alert title="Info" color="info" %}}
मास्टर स्लाइड्स के साथ काम करने के बारे में अधिक जानने के लिए, कृपया [Manage PowerPoint Slide Masters in Python](/slides/hi/python-net/slide-master/) लेख देखें।
{{% /alert %}}

## **प्रेजेंटेशन में स्लाइड लेआउट जोड़ें**

अपने स्लाइड्स की उपस्थिति और संरचना को अनुकूलित करने के लिए आपको प्रस्तुति में नए लेआउट स्लाइड्स जोड़ने की आवश्यकता हो सकती है। Aspose.Slides for Python आपको यह जांचने की सुविधा देता है कि कोई विशिष्ट लेआउट पहले से मौजूद है या नहीं, यदि आवश्यक हो तो नया जोड़ें, और उसे उपयोग करके उस लेआउट पर आधारित स्लाइड्स डालें।

1. [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।
1. [MasterLayoutSlideCollection](https://reference.aspose.com/slides/hi/python-net/aspose.slides/masterlayoutslidecollection/) तक पहुंचें।
1. जाँचें कि वांछित लेआउट स्लाइड संग्रह में पहले से मौजूद है या नहीं। यदि नहीं, तो आवश्यक लेआउट स्लाइड जोड़ें।
1. नए लेआउट स्लाइड के आधार पर एक खाली स्लाइड जोड़ें।
1. प्रस्तुति को सहेजें।

निम्नलिखित Python कोड दिखाता है कि PowerPoint प्रस्तुति में स्लाइड लेआउट कैसे जोड़ें:

```python
import aspose.slides as slides

# प्रस्तुति फ़ाइल खोलने के लिए Presentation क्लास का उदाहरण बनाएं।
with slides.Presentation("sample.pptx") as presentation:
    # लेआउट स्लाइड प्रकारों के माध्यम से जाकर एक लेआउट स्लाइड चुनें।
    layout_slides = presentation.masters[0].layout_slides
    layout_slide = layout_slides.get_by_type(slides.SlideLayoutType.TITLE_AND_OBJECT)
    if layout_slide is None:
         layout_slide = layout_slides.get_by_type(slides.SlideLayoutType.TITLE)

    if layout_slide is None:
        # एक स्थिति जहाँ प्रस्तुति सभी लेआउट प्रकार नहीं रखती।
        # प्रस्तुति फ़ाइल में केवल Blank और Custom लेआउट प्रकार होते हैं।
        # हालाँकि, कस्टम प्रकार वाली लेआउट स्लाइड्स के पहचानने योग्य नाम हो सकते हैं,
        # "Title", "Title and Content" आदि जैसे, जिन्हें लेआउट स्लाइड चयन के लिये उपयोग किया जा सकता है।
        # आप प्लेसहोल्डर शकल प्रकारों के सेट पर भी निर्भर कर सकते हैं।
        # उदाहरण के लिए, एक Title स्लाइड में केवल Title प्लेसहोल्डर प्रकार होना चाहिए, आदि।
        for title_and_object_layout_slide in layout_slides:
            if title_and_object_layout_slide.name == "Title and Object":
                layout_slide = title_and_object_layout_slide
                break

        if layout_slide is None:
            for title_layout_slide in layout_slides:
                if title_layout_slide.name == "Title":
                    layout_slide = title_layout_slide
                    break

            if layout_slide is None:
                layout_slide = layout_slides.get_by_type(slides.SlideLayoutType.BLANK)
                if layout_slide is None:
                    layout_slide = layout_slides.Add(slides.SlideLayoutType.TITLE_AND_OBJECT, "Title and Object")

    # जोड़ी गई लेआउट स्लाइड का उपयोग करके एक खाली स्लाइड जोड़ें।
    presentation.slides.insert_empty_slide(0, layout_slide)

    # प्रस्तुति को डिस्क पर सहेजें।
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **अनुपयोगी लेआउट स्लाइड्स हटाएं**

Aspose.Slides [Compress](https://reference.aspose.com/slides/hi/python-net/aspose.slides.lowcode/compress/) क्लास से [remove_unused_layout_slides](https://reference.aspose.com/slides/hi/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/) मेथड प्रदान करता है, जिससे आप अनावश्यक और अप्रयुक्त लेआउट स्लाइड्स को हटा सकते हैं।

निम्नलिखित Python कोड दिखाता है कि PowerPoint प्रस्तुति से लेआउट स्लाइड को कैसे हटाएं:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_layout_slides(presentation)
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **स्लाइड लेआउट में प्लेसहोल्डर जोड़ें**

Aspose.Slides [LayoutSlide.placeholder_manager](https://reference.aspose.com/slides/hi/python-net/aspose.slides/layoutslide/placeholder_manager/) प्रॉपर्टी प्रदान करता है, जो आपको लेआउट स्लाइड में नए प्लेसहोल्डर जोड़ने की अनुमति देता है।

यह मैनेजर निम्नलिखित प्लेसहोल्डर प्रकारों के लिए मेथड्स शामिल करता है:

| PowerPoint प्लेसहोल्डर | [LayoutPlaceholderManager](https://reference.aspose.com/slides/hi/python-net/aspose.slides/layoutplaceholdermanager/) विधि |
| ----------------------- | ------------------------------------------------------------ |
| ![Content](content.png) | add_content_placeholder(x: float, y: float, width: float, height: float) |
| ![Content (Vertical)](contentV.png) | add_vertical_content_placeholder(x: float, y: float, width: float, height: float) |
| ![Text](text.png) | add_text_placeholder(x: float, y: float, width: float, height: float) |
| ![Text (Vertical)](textV.png) | add_vertical_text_placeholder(x: float, y: float, width: float, height: float) |
| ![Picture](picture.png) | add_picture_placeholder(x: float, y: float, width: float, height: float) |
| ![Chart](chart.png) | add_chart_placeholder(x: float, y: float, width: float, height: float) |
| ![Table](table.png) | add_table_placeholder(x: float, y: float, width: float, height: float) |
| ![SmartArt](smartart.png) | add_smart_art_placeholder(x: float, y: float, width: float, height: float) |
| ![Media](media.png) | add_media_placeholder(x: float, y: float, width: float, height: float) |
| ![Online Image](onlineimage.png) | add_online_image_placeholder(x: float, y: float, width: float, height: float) |

निम्नलिखित Python कोड दिखाता है कि Blank लेआउट स्लाइड में नए प्लेसहोल्डर शेप्स कैसे जोड़ें:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    # Blank लेआउट स्लाइड प्राप्त करें।
    layout = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    # लेआउट स्लाइड का प्लेसहोल्डर मैनेजर प्राप्त करें।
    placeholder_manager = layout.placeholder_manager

    # Blank लेआउट स्लाइड में विभिन्न प्लेसहोल्डर जोड़ें।
    placeholder_manager.add_content_placeholder(20, 20, 310, 270)
    placeholder_manager.add_vertical_text_placeholder(350, 20, 350, 270)
    placeholder_manager.add_chart_placeholder(20, 310, 310, 180)
    placeholder_manager.add_table_placeholder(350, 310, 350, 180)

    # Blank लेआउट के साथ नई स्लाइड जोड़ें।
    new_slide = presentation.slides.add_empty_slide(layout)

    presentation.save("placeholders.pptx", slides.export.SaveFormat.PPTX)
```

परिणाम:

![The placeholders on the layout slide](add_placeholders.png)

## **लेआउट स्लाइड के लिए फुटर दृश्यता सेट करें**

PowerPoint प्रस्तुतियों में, फुटर तत्व जैसे तिथि, स्लाइड नंबर, और कस्टम टेक्स्ट लेआउट के अनुसार दिखाए या छिपाए जा सकते हैं। Aspose.Slides for Python आपको इन फुटर प्लेसहोल्डर की दृश्यता को नियंत्रित करने की सुविधा देता है। यह तब उपयोगी होता है जब आप कुछ लेआउट को फुटर जानकारी दिखाना चाहते हैं जबकि अन्य को साफ़ रखना चाहते हैं।

1. [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।
1. उसके इंडेक्स द्वारा एक लेआउट स्लाइड रेफ़रेंस प्राप्त करें।
1. स्लाइड फ़ुटर प्लेसहोल्डर को दृश्यमान सेट करें।
1. स्लाइड नंबर प्लेसहोल्डर को दृश्यमान सेट करें।
1. तारीख‑समय प्लेसहोल्डर को दृश्यमान सेट करें।
1. प्रस्तुति को सहेजें।

निम्नलिखित Python कोड दिखाता है कि स्लाइड फ़ुटर की दृश्यता कैसे सेट करें और संबंधित कार्य कैसे करें:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    header_footer_manager = presentation.layout_slides[0].header_footer_manager

    if not header_footer_manager.is_footer_visible: 
        header_footer_manager.set_footer_visibility(True) 

    if not header_footer_manager.is_slide_number_visible:  
        header_footer_manager.set_slide_number_visibility(True) 

    if not header_footer_manager.is_date_time_visible: 
        header_footer_manager.set_date_time_visibility(True)

    header_footer_manager.set_footer_text("Footer text") 
    header_footer_manager.set_date_time_text("Date and time text") 

    presentation.save("output.ppt", slides.export.SaveFormat.PPT)
```

## **स्लाइड के चाइल्ड फ़ुटर दृश्यता सेट करें**

PowerPoint प्रस्तुतियों में, फुटर तत्व जैसे तिथि, स्लाइड नंबर, और कस्टम टेक्स्ट को मास्टर स्लाइड स्तर पर नियंत्रित किया जा सकता है ताकि सभी लेआउट स्लाइड्स में संगतता बनी रहे। Aspose.Slides for Python आपको मास्टर स्लाइड पर इन फुटर प्लेसहोल्डर की दृश्यता और सामग्री सेट करने और इन सेटिंग्स को सभी चाइल्ड लेआउट स्लाइड्स में प्रसारित करने की अनुमति देता है। इस तरह आपके पूरे प्रस्तुति में एकसमान फ़ुटर जानकारी सुनिश्चित होती है।

1. [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।
1. उसके इंडेक्स द्वारा मास्टर स्लाइड का रेफ़रेंस प्राप्त करें।
1. मास्टर और सभी चाइल्ड फ़ुटर प्लेसहोल्डर को दृश्यमान सेट करें।
1. मास्टर और सभी चाइल्ड स्लाइड नंबर प्लेसहोल्डर को दृश्यमान सेट करें।
1. मास्टर और सभी चाइल्ड तारीख‑समय प्लेसहोल्डर को दृश्यमान सेट करें।
1. प्रस्तुति को सहेजें।

निम्नलिखित Python कोड इस ऑपरेशन को दर्शाता है:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    header_footer_manager = presentation.masters[0].header_footer_manager

    header_footer_manager.set_footer_and_child_footers_visibility(True)
    header_footer_manager.set_slide_number_and_child_slide_numbers_visibility(True)
    header_footer_manager.set_date_time_and_child_date_times_visibility(True)

    header_footer_manager.set_footer_and_child_footers_text("Footer text")
    header_footer_manager.set_date_time_and_child_date_times_text("Date and time text")

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **अक्सर पूछे जाने वाले प्रश्न**

**मास्टर स्लाइड और लेआउट स्लाइड में क्या अंतर है?**

मास्टर स्लाइड समग्र थीम और डिफ़ॉल्ट फॉर्मेटिंग को परिभाषित करती है, जबकि लेआउट स्लाइड विभिन्न प्रकार की सामग्री के लिए प्लेसहोल्डर की विशिष्ट व्यवस्था तय करती है।

**क्या मैं एक लेआउट स्लाइड को एक प्रस्तुति से दूसरी में कॉपी कर सकता हूँ?**

हां, आप किसी प्रस्तुति के [layout_slides](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/layout_slides/) संग्रह से लेआउट स्लाइड को क्लोन करके `add_clone` मेथड का उपयोग करके इसे दूसरी प्रस्तुति में डाल सकते हैं।

**अगर मैं किसी लेआउट स्लाइड को हटाता हूँ जो अभी भी किसी स्लाइड द्वारा उपयोग में है तो क्या होगा?**

यदि आप ऐसे लेआउट स्लाइड को हटाने की कोशिश करते हैं जो प्रस्तुति में कम से कम एक स्लाइड द्वारा संदर्भित है, तो Aspose.Slides एक [PptxEditException](https://reference.aspose.com/slides/hi/python-net/aspose.slides/pptxeditexception/) फेंकेगा। इसे रोकने के लिए, आप [remove_unused_layout_slides](https://reference.aspose.com/slides/hi/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/) का उपयोग कर सकते हैं, जो केवल अनुपयोगी लेआउट स्लाइड्स को सुरक्षित रूप से हटाता है।