---
title: Python via Java के साथ प्रस्तुतियों में स्लाइड सेक्शन प्रबंधित करें
linktitle: स्लाइड सेक्शन
type: docs
weight: 90
url: /hi/python-java/slide-section/
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
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java के साथ स्लाइड सेक्शन प्रबंधित करें: PPTX प्रस्तुतियों में सेक्शन स्लाइड्स बनाएं, नाम बदलें, पुनः क्रमित करें, प्राप्त करें और प्रोसेस करें।"
---
## **परिचय**

सेक्शन क्रमागत स्लाइड्स को नामित समूहों में व्यवस्थित करते हैं बिना स्लाइड सामग्री बदले। Aspose.Slides for Python via Java के साथ, आप एक सेक्शन बना सकते हैं, पुनः क्रमित कर सकते हैं, नाम बदल सकते हैं, निरीक्षण कर सकते हैं और उसे हटाने के लिए [Presentation.getSections](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#getSections) मेथड का उपयोग कर सकते हैं।

सेक्शन विशेष रूप से उपयोगी होते हैं जब:

- बड़ी प्रस्तुति को तर्कसंगत विषयों या अध्यायों में विभाजित करना हो;
- विभिन्न स्लाइड समूह विभिन्न सहयोगियों को सौंपे जाएँ;
- स्लाइड्स को समूहों के रूप में प्रक्रिया, स्थानांतरित या मर्ज करना आवश्यक हो।

ऐसे समूहित स्लाइड्स के उद्देश्य को दर्शाने वाले संक्षिप्त सेक्शन नाम चुनें। चूँकि सेक्शन प्रस्तुति की संरचना का हिस्सा होते हैं, इसलिए सदस्यता निर्धारित करने के लिये स्लाइड स्थितियों से नहीं, बल्कि सेक्शन API का उपयोग करें।

## **सेक्शन बनाना और प्रबंधन**

एक सेक्शन उसके नाम और प्रारंभिक स्लाइड को निर्दिष्ट करके बनाने के लिए [SectionCollection.addSection](https://reference.aspose.com/slides/hi/python-java/aspose.slides/sectioncollection/#addSection) का उपयोग करें। Aspose.Slides वर्तमान सेक्शन संरचना के आधार पर निर्धारित करता है कि कौन सी स्लाइड्स सेक्शन में आती हैं।

उसी [SectionCollection](https://reference.aspose.com/slides/hi/python-java/aspose.slides/sectioncollection/) से आप भी कर सकते हैं:

- [reorderSectionWithSlides](https://reference.aspose.com/slides/hi/python-java/aspose.slides/sectioncollection/#reorderSectionWithSlides) का उपयोग करके सेक्शन को उसकी स्लाइड्स सहित स्थानांतरित करें;
- केवल सेक्शन परिभाषा को [removeSection](https://reference.aspose.com/slides/hi/python-java/aspose.slides/sectioncollection/#removeSection) से हटाएँ, जिससे उसकी स्लाइड्स बनी रहें;
- सेक्शन और उसकी स्लाइड्स को [removeSectionWithSlides](https://reference.aspose.com/slides/hi/python-java/aspose.slides/sectioncollection/#removeSectionwithslides) से हटाएँ;
- अंत में एक खाली सेक्शन को [appendEmptySection](https://reference.aspose.com/slides/hi/python-java/aspose.slides/sectioncollection/#appendEmptySection) से जोड़ें।

निम्न उदाहरण दो सेक्शन बनाता है, उनमें से एक को स्थानांतरित करता है, उसे उसकी स्लाइड्स सहित हटाता है, और एक खाली सेक्शन जोड़ता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    title_slide = presentation.getSlides().get_Item(0)
    layout_slide = presentation.getLayoutSlides().get_Item(0)
    presentation.getSlides().addEmptySlide(layout_slide)
    results_slide = presentation.getSlides().addEmptySlide(layout_slide)
    presentation.getSlides().addEmptySlide(layout_slide)

    presentation.getSections().addSection("Introduction", title_slide)
    results_section = presentation.getSections().addSection("Results", results_slide)

    presentation.getSections().reorderSectionWithSlides(results_section, 0)
    presentation.getSections().removeSectionWithSlides(results_section)
    presentation.getSections().appendEmptySection("Appendix")
finally:
    presentation.dispose()
```

इन कार्यों के बाद, प्रस्तुति में उसके स्लाइड्स के साथ `Introduction` सेक्शन और एक खाली `Appendix` सेक्शन रहता है। `Results` सेक्शन और उसकी स्लाइड्स हटा दी गई हैं।

## **सेक्शन का नाम बदलना**

एक सेक्शन का नाम बदलने के लिए उसकी [Section.setName](https://reference.aspose.com/slides/hi/python-java/aspose.slides/section/#setName) मेथड को कॉल करें। सेक्शन की स्लाइड्स और स्थिति अपरिवर्तित रहती है।

निम्न उदाहरण एक सेक्शन बनाता है और उसका नाम बदलता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    section = presentation.getSections().addSection("Overview", slide)
    section.setName("Introduction")
finally:
    presentation.dispose()
```

## **सेक्शन से स्लाइड्स प्राप्त करना**

[Presentation.getSections](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#getSections) मेथड एक [SectionCollection](https://reference.aspose.com/slides/hi/python-java/aspose.slides/sectioncollection/) लौटाता है, जिसे आप पुनरावृति कर सकते हैं। प्रत्येक [Section](https://reference.aspose.com/slides/hi/python-java/aspose.slides/section/) के लिये, वर्तमान में उसमें स्थित स्लाइड्स को प्राप्त करने के लिये [Section.getSlidesListOfSection](https://reference.aspose.com/slides/hi/python-java/aspose.slides/section/#getSlidesListOfSection) को कॉल करें। यह मेथड एक [SectionSlideCollection](https://reference.aspose.com/slides/hi/python-java/aspose.slides/sectionslidecollection/) लौटाता है, जो गिनती, अनुक्रमित पहुँच और पुनरावृति प्रदान करता है।

निम्न उदाहरण दो भरे हुए सेक्शन और एक खाली सेक्शन बनाता है, फिर प्रत्येक सेक्शन का [name](https://reference.aspose.com/slides/hi/python-java/aspose.slides/section/#getName), [identifier](https://reference.aspose.com/slides/hi/python-java/aspose.slides/section/#getSectionId), [starting slide](https://reference.aspose.com/slides/hi/python-java/aspose.slides/section/#getStartedFromSlide), स्लाइड गिनती और स्लाइड क्रमांक प्रिंट करता है। यह पहले स्लाइड को पढ़ने के लिये [SectionSlideCollection.get_Item](https://reference.aspose.com/slides/hi/python-java/aspose.slides/sectionslidecollection/#get_Item) का उपयोग करता है और प्रत्येक स्लाइड को प्रोसेस करने के लिये `for` स्टेटमेंट का उपयोग करता है। खाली सेक्शन के लिये, लौटाई गई संग्रह का आकार शून्य होता है, मेथड नहीं बुलाया जाता और पुनरावृति कोई ऑपरेशन नहीं करती।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)
    layout_slide = presentation.getLayoutSlides().get_Item(0)
    presentation.getSlides().addEmptySlide(layout_slide)
    third_slide = presentation.getSlides().addEmptySlide(layout_slide)

    presentation.getSections().addSection("Introduction", first_slide)
    presentation.getSections().addSection("Details", third_slide)
    presentation.getSections().appendEmptySection("Appendix")

    for section in presentation.getSections():
        section_slides = section.getSlidesListOfSection()
        starting_slide = "none" if section.getStartedFromSlide() is None else str(section.getStartedFromSlide().getSlideNumber())

        print("Section: ", section.getName(), sep="")
        print("ID: ", section.getSectionId(), sep="")
        print("Starting slide: ", starting_slide, sep="")
        print("Slide count: ", section_slides.size(), sep="")

        if section_slides.size() > 0:
            print("First slide via get_Item: ", section_slides.get_Item(0).getSlideNumber(), sep="")

        print("Slide numbers:", end="")
        for slide in section_slides:
            print(" ", slide.getSlideNumber(), sep="", end="")
        print()
finally:
    presentation.dispose()
```

सेक्शन सदस्यता प्रस्तुति की सेक्शन संरचना द्वारा निर्धारित होती है। [Section.getStartedFromSlide](https://reference.aspose.com/slides/hi/python-java/aspose.slides/section/#getStartedFromSlide), स्लाइड इंडेक्स तथा अगली सेक्शन की प्रारंभ स्लाइड से सेक्शन की रेंज मैन्युअली गणना न करें।

संरचनात्मक संपादन किसी सेक्शन के लिये लौटाई गई स्लाइड्स और उनके क्रमांक दोनों को बदल सकते हैं। इसमें स्लाइड्स का पुनः क्रमित करना, स्लाइड को सेक्शन में क्लोन करना, सेक्शन को उसकी स्लाइड्स सहित ले जाना, स्लाइड्स को हटाना और सेक्शन को हटाना शामिल है। अगला उदाहरण प्रत्येक ऐसे परिवर्तन के बाद [Section.getSlidesListOfSection](https://reference.aspose.com/slides/hi/python-java/aspose.slides/section/#getSlidesListOfSection) को कॉल करता है बजाय इसके कि पूर्व सीमाओं के बारे में धारणाएँ रखी जाएँ।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)
    layout_slide = presentation.getLayoutSlides().get_Item(0)
    presentation.getSlides().addEmptySlide(layout_slide)
    third_slide = presentation.getSlides().addEmptySlide(layout_slide)
    presentation.getSlides().addEmptySlide(layout_slide)
    first_section = presentation.getSections().addSection("First", first_slide)
    second_section = presentation.getSections().addSection("Second", third_slide)

    def print_section_slides(label, section):
        section_slides = section.getSlidesListOfSection()
        print(f"{label} ({section_slides.size()} slides):", end="")
        for slide in section_slides:
            print(" ", slide.getSlideNumber(), sep="", end="")
        print()

    print_section_slides("Initially", first_section)

    slides_before_clone = first_section.getSlidesListOfSection()
    presentation.getSlides().addClone(slides_before_clone.get_Item(0), first_section)
    print_section_slides("After cloning into the section", first_section)

    slides_before_reorder = first_section.getSlidesListOfSection()
    first_section_position = slides_before_reorder.get_Item(0).getSlideNumber() - 1
    presentation.getSlides().reorder(first_section_position, slides_before_reorder.get_Item(slides_before_reorder.size() - 1))
    print_section_slides("After reordering slides", first_section)

    presentation.getSections().reorderSectionWithSlides(first_section, 1)
    print_section_slides("After moving the section", first_section)

    slides_before_removal = first_section.getSlidesListOfSection()
    presentation.getSlides().remove(slides_before_removal.get_Item(0))
    print_section_slides("After removing a slide", first_section)

    presentation.getSections().removeSectionWithSlides(second_section)
    for section in presentation.getSections():
        print_section_slides("Remaining section", section)
finally:
    presentation.dispose()
```

जब भी स्लाइड्स या सेक्शन पुनः क्रमित, क्लोन, ले जाएँ या हटाए जाएँ, तब [Section.getSlidesListOfSection](https://reference.aspose.com/slides/hi/python-java/aspose.slides/section/#getSlidesListOfSection) को फिर से कॉल करें। इससे बाद की प्रोसेसिंग वर्तमान प्रस्तुति संरचना के साथ सामंजस्य में रहती है।

PPT (PowerPoint 97–2003) फ़ॉर्मेट सेक्शन मेटाडेटा को संरक्षित नहीं करता। इस वर्कफ़्लो को ऐसे फ़ॉर्मेट के साथ उपयोग करें जो सेक्शन का समर्थन करता हो, जैसे PPTX; PPT में रूपांतरण करने से बाद में पुनरावृति के लिये आवश्यक सेक्शन संरचना हट जाती है।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या PPT (PowerPoint 97–2003) फ़ॉर्मेट में सहेजते समय सेक्शन संरक्षित रहते हैं?**

नहीं। PPT फ़ॉर्मेट सेक्शन मेटाडेटा का समर्थन नहीं करता, इसलिए सेक्शन समूहण .ppt में सहेजते समय खो जाता है।

**क्या पूरे सेक्शन को "छिपाया" जा सकता है?**

नहीं। सेक्शन का कोई दृश्यता स्थिति नहीं होता। इसके सामग्री को छिपाने के लिये सेक्शन की प्रत्येक स्लाइड के लिये [Slide.setHidden](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slide/#setHidden) को कॉल करें।

**मैं कैसे पता करूँ कि कौन सा सेक्शन किसी स्लाइड को शामिल करता है?**

[Presentation.getSections](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#getSections) द्वारा लौटाई गई संग्रह पर पुनरावृति करें, प्रत्येक सेक्शन के लिये [Section.getSlidesListOfSection](https://reference.aspose.com/slides/hi/python-java/aspose.slides/section/#getSlidesListOfSection) को कॉल करें और लौटाई गई स्लाइड्स की तुलना लक्ष्य स्लाइड से करें। गैर‑खाली सेक्शन के लिये, [Section.getStartedFromSlide](https://reference.aspose.com/slides/hi/python-java/aspose.slides/section/#getStartedFromSlide) उसकी पहली स्लाइड लौटाता है; खाली सेक्शन के लिये यह `None` लौटाता है।