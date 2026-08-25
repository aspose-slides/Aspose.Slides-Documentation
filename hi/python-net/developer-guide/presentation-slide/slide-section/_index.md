---
title: Python के साथ प्रस्तुतियों में स्लाइड सेक्शन प्रबंधित करें
linktitle: स्लाइड सेक्शन
type: docs
weight: 100
url: /hi/python-net/slide-section/
keywords:
- सेक्शन बनाएं
- सेक्शन जोड़ें
- सेक्शन संपादित करें
- सेक्शन बदलें
- सेक्शन नाम
- सेक्शन स्लाइड्स प्राप्त करें
- सेक्शन स्लाइड्स प्रोसेस करें
- PowerPoint
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET के साथ स्लाइड सेक्शन प्रबंधित करें: PPTX प्रस्तुतियों में सेक्शन स्लाइड्स बनाएं, नाम बदलें, क्रम पुनः निर्धारित करें, प्राप्त करें, और प्रोसेस करें।"
---
## **परिचय**

सेक्शन क्रमबद्ध स्लाइड्स को बिना स्लाइड सामग्री बदले नामित समूहों में व्यवस्थित करते हैं। Aspose.Slides for Python via .NET के साथ, आप सेक्शन को बनाना, पुनः क्रमित करना, नाम बदलना, निरीक्षण करना और हटाना [Presentation.sections](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/sections/) प्रॉपर्टी के माध्यम से कर सकते हैं।

सेक्शन विशेष रूप से उपयोगी होते हैं जब:

- किसी बड़े प्रस्तुतिकरण को तर्कसंगत विषयों या अध्यायों में विभाजित करने की आवश्यकता हो;
- विभिन्न स्लाइड समूह विभिन्न सहयोगियों को सौंपे जाएँ;
- स्लाइड्स को समूहों के रूप में प्रोसेस, मूव या मर्ज करने की आवश्यकता हो।

संकुचित सेक्शन नाम चुनें जो समूहित स्लाइड्स के उद्देश्य का वर्णन करे। क्योंकि सेक्शन प्रस्तुतिकरण संरचना का हिस्सा होते हैं, स्लाइड स्थितियों से निकालने के बजाय सेक्शन API का उपयोग करके सदस्यता निर्धारित करें।

## **सेक्शन बनाना और प्रबंधित करना**

आप सेक्शन का नाम और प्रारंभिक स्लाइड निर्दिष्ट करके [SectionCollection.add_section](https://reference.aspose.com/slides/hi/python-net/aspose.slides/sectioncollection/add_section/) का उपयोग कर सकते हैं। Aspose.Slides वर्तमान सेक्शन संरचना के आधार पर तय करता है कि कौन सी स्लाइड्स सेक्शन में आती हैं।

एक ही [SectionCollection](https://reference.aspose.com/slides/hi/python-net/aspose.slides/sectioncollection/) आपको यह भी करने देता है:

- [SectionCollection.reorder_section_with_slides](https://reference.aspose.com/slides/hi/python-net/aspose.slides/sectioncollection/reorder_section_with_slides/) का उपयोग कर सेक्शन को उसकी स्लाइड्स के साथ मूव करें;
- केवल सेक्शन परिभाषा को हटाएँ [SectionCollection.remove_section](https://reference.aspose.com/slides/hi/python-net/aspose.slides/sectioncollection/remove_section/) से, जो उसकी स्लाइड्स को बरकरार रखता है;
- सेक्शन और उसकी स्लाइड्स को हटाएँ [SectionCollection.remove_section_with_slides](https://reference.aspose.com/slides/hi/python-net/aspose.slides/sectioncollection/remove_section_with_slides/) से;
- अंत में एक खाली सेक्शन जोड़ें [SectionCollection.append_empty_section](https://reference.aspose.com/slides/hi/python-net/aspose.slides/sectioncollection/append_empty_section/) से।

निम्न उदाहरण दो सेक्शन बनाता है, उनमें से एक को मूव करता है, उसे उसकी स्लाइड्स के साथ हटाता है, और एक खाली सेक्शन जोड़ता है:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    title_slide = presentation.slides[0]
    presentation.slides.add_empty_slide(presentation.layout_slides[0])
    results_slide = presentation.slides.add_empty_slide(presentation.layout_slides[0])
    presentation.slides.add_empty_slide(presentation.layout_slides[0])

    presentation.sections.add_section("Introduction", title_slide)
    results_section = presentation.sections.add_section("Results", results_slide)

    presentation.sections.reorder_section_with_slides(results_section, 0)
    presentation.sections.remove_section_with_slides(results_section)
    presentation.sections.append_empty_section("Appendix")
```

इन ऑपरेशनों के बाद, प्रस्तुतिकरण में `Introduction` सेक्शन उसकी स्लाइड्स के साथ और एक खाली `Appendix` सेक्शन मौजूद होते हैं। `Results` सेक्शन और उसकी स्लाइड्स हटा दी गई हैं।

## **सेक्शन का नाम बदलना**

सेक्शन का नाम बदलने के लिए, उसके [Section.name](https://reference.aspose.com/slides/hi/python-net/aspose.slides/section/name/) प्रॉपर्टी को सेट करें। सेक्शन की स्लाइड्स और स्थिति अपरिवर्तित रहती है।

निम्न उदाहरण एक सेक्शन बनाता है और उसका नाम बदलता है:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    section = presentation.sections.add_section("Overview", slide)
    section.name = "Introduction"
```

## **सेक्शन से स्लाइड्स प्राप्त करना**

[Presentation.sections](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/sections/) प्रॉपर्टी एक [SectionCollection](https://reference.aspose.com/slides/hi/python-net/aspose.slides/sectioncollection/) लौटाती है जिसे आप इटररेट कर सकते हैं। प्रत्येक [Section](https://reference.aspose.com/slides/hi/python-net/aspose.slides/section/) के लिए, वर्तमान में उससे संबंधित स्लाइड्स प्राप्त करने हेतु [Section.get_slides_list_of_section](https://reference.aspose.com/slides/hi/python-net/aspose.slides/section/get_slides_list_of_section/) को कॉल करें। यह मेथड एक [SectionSlideCollection](https://reference.aspose.com/slides/hi/python-net/aspose.slides/sectionslidecollection/) लौटाता है, जो गिनती, सूचकांकित एक्सेस और इटरेशन प्रदान करता है।

निम्न उदाहरण दो भरे हुए सेक्शन और एक खाली सेक्शन बनाता है, फिर प्रत्येक सेक्शन का [name](https://reference.aspose.com/slides/hi/python-net/aspose.slides/section/name/), [identifier](https://reference.aspose.com/slides/hi/python-net/aspose.slides/section/section_id/), [starting slide](https://reference.aspose.com/slides/hi/python-net/aspose.slides/section/started_from_slide/), स्लाइड गिनती और स्लाइड नंबर प्रिंट करता है। यह पहले स्लाइड को पढ़ने के लिए सूचकांकित एक्सेस और प्रत्येक स्लाइड को प्रोसेस करने के लिए `for` लूप का उपयोग करता है। खाली सेक्शन के लिए, लौटा संग्रह शून्य गिनती रखता है, सूचकांक तक पहुँच नहीं की जाती, और इटरेशन कोई कदम नहीं उठाता।

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    first_slide = presentation.slides[0]
    presentation.slides.add_empty_slide(presentation.layout_slides[0])
    third_slide = presentation.slides.add_empty_slide(presentation.layout_slides[0])

    presentation.sections.add_section("Introduction", first_slide)
    presentation.sections.add_section("Details", third_slide)
    presentation.sections.append_empty_section("Appendix")

    for section in presentation.sections:
        section_slides = section.get_slides_list_of_section()
        starting_slide = "none" if section.started_from_slide is None else str(section.started_from_slide.slide_number)

        print(f"Section: {section.name}")
        print(f"ID: {section.section_id}")
        print(f"Starting slide: {starting_slide}")
        print(f"Slide count: {section_slides.count}")

        if section_slides.count > 0:
            print(f"First slide via index: {section_slides[0].slide_number}")

        print("Slide numbers:", end="")
        for slide in section_slides:
            print(f" {slide.slide_number}", end="")
        print()
```

सेक्शन सदस्यता प्रस्तुतिकरण की सेक्शन संरचना द्वारा निर्धारित होती है। [Section.started_from_slide](https://reference.aspose.com/slides/hi/python-net/aspose.slides/section/started_from_slide/) से, स्लाइड इंडेक्स और अगले सेक्शन की प्रारंभिक स्लाइड से मैन्युअल रूप से सेक्शन की सीमा की गणना न करें।

स्ट्रक्चरल संपादन दोनों स्लाइड्स को बदल सकते हैं जो किसी सेक्शन के लिए लौटाई जाती हैं और उनके स्लाइड नंबर भी। इसमें स्लाइड्स का पुनः क्रमित करना, किसी स्लाइड को सेक्शन में क्लोन करना, सेक्शन को उसकी स्लाइड्स के साथ मूव करना, स्लाइड्स हटाना और सेक्शन हटाना शामिल है। अगला उदाहरण प्रत्येक ऐसी परिवर्तन के बाद [Section.get_slides_list_of_section](https://reference.aspose.com/slides/hi/python-net/aspose.slides/section/get_slides_list_of_section/) को कॉल करता है, बजाय इसके कि सेक्शन की पूर्व सीमाओं के बारे में धारणाएँ बनाए रखें।

```py
import aspose.slides as slides


def print_section_slides(label, section):
    section_slides = section.get_slides_list_of_section()
    print(f"{label} ({section_slides.count} slides):", end="")
    for slide in section_slides:
        print(f" {slide.slide_number}", end="")
    print()


with slides.Presentation() as presentation:
    first_slide = presentation.slides[0]
    presentation.slides.add_empty_slide(presentation.layout_slides[0])
    third_slide = presentation.slides.add_empty_slide(presentation.layout_slides[0])
    presentation.slides.add_empty_slide(presentation.layout_slides[0])
    first_section = presentation.sections.add_section("First", first_slide)
    second_section = presentation.sections.add_section("Second", third_slide)

    print_section_slides("Initially", first_section)

    slides_before_clone = first_section.get_slides_list_of_section()
    presentation.slides.add_clone(slides_before_clone[0], first_section)
    print_section_slides("After cloning into the section", first_section)

    slides_before_reorder = first_section.get_slides_list_of_section()
    first_section_position = slides_before_reorder[0].slide_number - 1
    presentation.slides.reorder(first_section_position, slides_before_reorder[slides_before_reorder.count - 1])
    print_section_slides("After reordering slides", first_section)

    presentation.sections.reorder_section_with_slides(first_section, 1)
    print_section_slides("After moving the section", first_section)

    slides_before_removal = first_section.get_slides_list_of_section()
    presentation.slides.remove(slides_before_removal[0])
    print_section_slides("After removing a slide", first_section)

    presentation.sections.remove_section_with_slides(second_section)
    for section in presentation.sections:
        print_section_slides("Remaining section", section)
```

जब भी स्लाइड्स या सेक्शन्स को पुनः क्रमित, क्लोन, मूव या हटाया जाए, तब फिर से [Section.get_slides_list_of_section](https://reference.aspose.com/slides/hi/python-net/aspose.slides/section/get_slides_list_of_section/) कॉल करें। यह बाद की प्रोसेसिंग को वर्तमान प्रस्तुतिकरण संरचना के साथ संरेखित रखता है।

PPT (PowerPoint 97–2003) फॉर्मेट सेक्शन मेटाडाटा को संरक्षित नहीं रखता। इस वर्कफ़्लो का उपयोग ऐसे फ़ॉर्मेट के साथ करें जो सेक्शन को समर्थन देता हो, जैसे PPTX; PPT में कन्वर्ट करने पर बाद के इटरेशन के लिए आवश्यक सेक्शन संरचना हट जाती है।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या सेक्शन PPT (PowerPoint 97–2003) फॉर्मेट में सहेजते समय संरक्षित रहते हैं?**

नहीं। PPT फॉर्मेट सेक्शन मेटाडाटा का समर्थन नहीं करता, इसलिए .ppt में सहेजने पर सेक्शन समूह खो जाता है।

**क्या पूरी सेक्शन को "छुपाया" जा सकता है?**

नहीं। सेक्शन का कोई दृश्यता स्थिति नहीं होता। इसकी सामग्री को छुपाने के लिए, सेक्शन में प्रत्येक स्लाइड के लिए [Slide.hidden](https://reference.aspose.com/slides/hi/python-net/aspose.slides/slide/hidden/) प्रॉपर्टी सेट करें।

**मैं किसी स्लाइड को शामिल करने वाले सेक्शन को कैसे खोजूं?**

[Presentation.sections](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/sections/) पर इटररेट करें, प्रत्येक सेक्शन के लिए [Section.get_slides_list_of_section](https://reference.aspose.com/slides/hi/python-net/aspose.slides/section/get_slides_list_of_section/) को कॉल करें, और लौटाई गई स्लाइड्स की तुलना लक्षित स्लाइड से करें। गैर‑खाली सेक्शन के लिए, [Section.started_from_slide](https://reference.aspose.com/slides/hi/python-net/aspose.slides/section/started_from_slide/) उसकी पहली स्लाइड लौटाता है; खाली सेक्शन के लिए, यह `None` लौटाता है।