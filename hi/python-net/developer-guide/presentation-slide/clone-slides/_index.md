---
title: पायथन में PowerPoint स्लाइड्स क्लोन करें
linktitle: स्लाइड्स क्लोन करें
type: docs
weight: 40
url: /hi/python-net/clone-slides/
keywords:
- स्लाइड क्लोन
- स्लाइड कॉपी
- स्लाइड सहेजें
- PowerPoint
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET के साथ PowerPoint स्लाइड्स को जल्दी से क्लोन या डुप्लिकेट करें। स्पष्ट कोड उदाहरणों और टिप्स का पालन करके सेकंडों में PPT निर्माण को स्वचालित करें, उत्पादकता बढ़ाएँ, और मैनुअल कार्य को समाप्त करें।"
---
## **परिचय**

क्लोनिंग वह प्रक्रिया है जिससे किसी वस्तु की सटीक प्रतिलिपि या डुप्लिकेट बनाया जाता है। Aspose.Slides आपको किसी भी स्लाइड को कॉपी (क्लोन) करने और फिर क्लोन की गई स्लाइड को वर्तमान प्रस्तुति या किसी अन्य खुली प्रस्तुति में सम्मिलित करने की अनुमति देता है। स्लाइड क्लोनिंग एक नई स्लाइड बनाती है जिसे डेवलपर्स मूल स्लाइड को प्रभावित किए बिना संशोधित कर सकते हैं। स्लाइड को क्लोन करने के कई तरीके हैं:

- प्रस्तुति के अंत में क्लोन करें।
- प्रस्तुति के भीतर किसी अन्य स्थान पर क्लोन करें।
- दूसरी प्रस्तुति के अंत में क्लोन करें।
- दूसरी प्रस्तुति में किसी अन्य स्थान पर क्लोन करें।
- दूसरी प्रस्तुति में किसी विशिष्ट स्थान पर क्लोन करें।

Aspose.Slides for Python via .NET में, [स्लाइड संग्रह](https://reference.aspose.com/slides/hi/python-net/aspose.slides/slidecollection/) जो [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) वस्तु द्वारा प्रदर्शित होता है, `add_clone` और `insert_clone` मेथड्स प्रदान करता है ताकि इन प्रकार की स्लाइड क्लोनिंग की जा सके।

## **स्थापना**

```bash
pip install aspose.slides
```

## **एक ही प्रस्तुति में अंत में क्लोन**

यदि आप एक ही प्रस्तुति के भीतर स्लाइड को क्लोन करके मौजूदा स्लाइडों के अंत में जोड़ना चाहते हैं, तो `add_clone` मेथड का उपयोग करें। नीचे दिए गए चरणों का पालन करें:

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास का उदाहरण बनाएं।
1. [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) वस्तु से स्लाइड संग्रह प्राप्त करें।
1. [SlideCollection](https://reference.aspose.com/slides/hi/python-net/aspose.slides/slidecollection/) पर `add_clone` मेथड को कॉल करें, तथा क्लोन की जाने वाली स्लाइड पास करें।
1. संशोधित प्रस्तुति को सहेजें।

नीचे के उदाहरण में, पहली स्लाइड (इंडेक्स 0) को क्लोन करके प्रस्तुति के अंत में जोड़ा गया है।

```py
import aspose.slides as slides

# प्रस्तुति फ़ाइल का प्रतिनिधित्व करने के लिए Presentation क्लास को इंस्टैंसिएट करें।
with slides.Presentation("CloneWithinSamePresentationToEnd.pptx") as presentation:
    # समान प्रस्तुति में स्लाइड संग्रह के अंत में इच्छित स्लाइड को क्लोन करें।
    presentation.slides.add_clone(presentation.slides[0])
    # संशोधित प्रस्तुति को डिस्क पर सहेजें।
    presentation.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", slides.export.SaveFormat.PPTX)
```

## **एक ही प्रस्तुति में एक विशिष्ट स्थान पर क्लोन**

यदि आप एक ही प्रस्तुति के भीतर स्लाइड को क्लोन करके उसे किसी अन्य स्थान पर रखना चाहते हैं, तो `insert_clone` मेथड का उपयोग करें:

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास का उदाहरण बनाएं।
1. [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) वस्तु से स्लाइड संग्रह प्राप्त करें।
1. [SlideCollection](https://reference.aspose.com/slides/hi/python-net/aspose.slides/slidecollection/) पर `insert_clone` मेथड को कॉल करें, तथा क्लोन की जाने वाली स्लाइड और उसके नए स्थान के लक्ष्य इंडेक्स को पास करें।
1. संशोधित प्रस्तुति को सहेजें।

नीचे के उदाहरण में, इंडेक्स 1 (स्थिति 2) की स्लाइड को इंडेक्स 2 (स्थिति 3) पर क्लोन किया गया है।

```py
import aspose.slides as slides

# प्रस्तुति फ़ाइल का प्रतिनिधित्व करने के लिए Presentation क्लास को इंस्टैंसिएट करें।
with slides.Presentation("CloneWithInSamePresentation.pptx") as presentation:
    # समान प्रस्तुति में निर्दिष्ट स्थान (इंडेक्स) पर इच्छित स्लाइड को क्लोन करें।
    presentation.slides.insert_clone(2, presentation.slides[1])
    # संशोधित प्रस्तुति को डिस्क पर सहेजें।
    presentation.save("Aspose_CloneWithInSamePresentation_out.pptx", slides.export.SaveFormat.PPTX)
```

## **दूसरी प्रस्तुति के अंत में क्लोन**

यदि आपको एक प्रस्तुति से स्लाइड को क्लोन करके उसे दूसरी प्रस्तुति के अंत में जोड़ना है:

1. स्रोत प्रस्तुति (जिसमें क्लोन करने वाली स्लाइड है) के लिए एक [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास का उदाहरण बनाएं।
1. गंतव्य प्रस्तुति (जहाँ स्लाइड जोड़ी जाएगी) के लिए एक [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास का उदाहरण बनाएं।
1. गंतव्य प्रस्तुति से स्लाइड संग्रह प्राप्त करें।
1. गंतव्य [SlideCollection](https://reference.aspose.com/slides/hi/python-net/aspose.slides/slidecollection/) पर `add_clone` को कॉल करें, तथा स्रोत प्रस्तुति से स्लाइड पास करें।
1. संशोधित गंतव्य प्रस्तुति को सहेजें।

नीचे के उदाहरण में, स्रोत प्रस्तुति में इंडेक्स 0 की स्लाइड को गंतव्य प्रस्तुति के अंत में क्लोन किया गया है।

```py
import aspose.slides as slides

# स्रोत प्रस्तुति फ़ाइल का प्रतिनिधित्व करने के लिए Presentation क्लास को इंस्टैंसिएट करें।
with slides.Presentation("CloneAtEndOfAnother.pptx") as source_presentation:
    # स्लाइड को क्लोन करने वाले लक्ष्य PPTX के लिए Presentation क्लास को इंस्टैंसिएट करें।
    with slides.Presentation() as target_presentation:
        # स्रोत प्रस्तुति से इच्छित स्लाइड को लक्ष्य प्रस्तुति के स्लाइड संग्रह के अंत में क्लोन करें।
        target_presentation.slides.add_clone(source_presentation.slides[0])
        # लक्ष्य प्रस्तुति को डिस्क पर सहेजें।
        target_presentation.save("Aspose2_out.pptx", slides.export.SaveFormat.PPTX)
```

## **दूसरी प्रस्तुति में एक विशिष्ट स्थान पर क्लोन**

यदि आपको एक प्रस्तुति से स्लाइड को क्लोन करके उसे दूसरी प्रस्तुति में किसी विशिष्ट स्थान पर डालना है:

1. स्रोत प्रस्तुति (जिसमें क्लोन करने वाली स्लाइड है) के लिए एक [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास का उदाहरण बनाएं।
1. गंतव्य प्रस्तुति (जहाँ स्लाइड जोड़ी जाएगी) के लिए एक [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास का उदाहरण बनाएं।
1. गंतव्य प्रस्तुति से स्लाइड संग्रह प्राप्त करें।
1. गंतव्य [SlideCollection](https://reference.aspose.com/slides/hi/python-net/aspose.slides/slidecollection/) पर `insert_clone` मेथड को कॉल करें, तथा स्रोत प्रस्तुति की स्लाइड और इच्छित लक्ष्य इंडेक्स पास करें।
1. संशोधित गंतव्य प्रस्तुति को सहेजें।

नीचे के उदाहरण में, स्रोत प्रस्तुति में इंडेक्स 0 की स्लाइड को गंतव्य प्रस्तुति में इंडेक्स 2 (स्थिति 3) पर क्लोन किया गया है।

```py
import aspose.slides as slides

# स्रोत प्रस्तुति फ़ाइल का प्रतिनिधित्व करने के लिए Presentation क्लास को इंस्टैंसिएट करें।
with slides.Presentation("CloneAtEndOfAnother.pptx") as source_presentation:
    # लक्ष्य PPTX (जहां स्लाइड को क्लोन किया जाना है) के लिए Presentation क्लास को इंस्टैंसिएट करें।
    with slides.Presentation("Aspose2_out.pptx") as target_presentation:
        # स्रोत से पहली स्लाइड की क्लोन को लक्ष्य प्रस्तुति में इंडेक्स 2 पर डालें।
        target_presentation.slides.insert_clone(2, source_presentation.slides[0])
        # लक्ष्य प्रस्तुति को डिस्क पर सहेजें।
        target_presentation.save("Aspose3_out.pptx", slides.export.SaveFormat.PPTX)
```

## **एक स्लाइड को उसके मास्टर स्लाइड के साथ दूसरी प्रस्तुति में क्लोन करें**

यदि आपको एक स्लाइड **उसके मास्टर के साथ** किसी एक प्रस्तुति से क्लोन करके दूसरी में उपयोग करनी है, तो पहले आवश्यक मास्टर स्लाइड को स्रोत प्रस्तुति से गंतव्य प्रस्तुति में क्लोन करें। फिर उस गंतव्य मास्टर को स्लाइड क्लोन करते समय प्रयोग करें। `add_clone(Slide, MasterSlide)` मेथड **गंतव्य प्रस्तुति के मास्टर स्लाइड** की अपेक्षा करता है, स्रोत के नहीं।

स्लाइड को उसके मास्टर के साथ क्लोन करने के लिए इन चरणों का पालन करें:

1. स्रोत प्रस्तुति (जिसमें क्लोन करने वाली स्लाइड है) के लिए एक [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास का उदाहरण बनाएं।
1. गंतव्य प्रस्तुति के लिए एक [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास का उदाहरण बनाएं।
1. क्लोन की जाने वाली स्रोत स्लाइड और उसका मास्टर स्लाइड एक्सेस करें।
1. गंतव्य प्रस्तुति के मास्टर संग्रह से [MasterSlideCollection](https://reference.aspose.com/slides/hi/python-net/aspose.slides/masterslidecollection/) प्राप्त करें।
1. गंतव्य [MasterSlideCollection](https://reference.aspose.com/slides/hi/python-net/aspose.slides/masterslidecollection/) पर `add_clone` को कॉल करें, तथा स्रोत मास्टर को पास करके उसे गंतव्य में क्लोन करें।
1. गंतव्य प्रस्तुति के स्लाइड संग्रह से [SlideCollection](https://reference.aspose.com/slides/hi/python-net/aspose.slides/slidecollection/) प्राप्त करें।
1. गंतव्य [SlideCollection](https://reference.aspose.com/slides/hi/python-net/aspose.slides/slidecollection/) पर `add_clone` को कॉल करें, तथा स्रोत स्लाइड और क्लोन किए हुए गंतव्य मास्टर को पास करें।
1. संशोधित गंतव्य प्रस्तुति को सहेजें।

नीचे के उदाहरण में, स्रोत प्रस्तुति में इंडेक्स 0 की स्लाइड को स्रोत से क्लोन किए गए मास्टर का उपयोग करके गंतव्य प्रस्तुति के अंत में क्लोन किया गया है।

```py
import aspose.slides as slides

# स्रोत प्रस्तुति फ़ाइल का प्रतिनिधित्व करने के लिए Presentation क्लास को इंस्टैंसिएट करें।
with slides.Presentation("CloneToAnotherPresentationWithMaster.pptx") as source_presentation:
    # स्लाइड को क्लोन किए जाने वाली लक्ष्य प्रस्तुति के लिए Presentation क्लास को इंस्टैंसिएट करें।
    with slides.Presentation() as target_presentation:
        # स्रोत प्रस्तुति से पहली स्लाइड प्राप्त करें।
        source_slide = source_presentation.slides[0]
        # पहली स्लाइड द्वारा उपयोग किए गए मास्टर स्लाइड को प्राप्त करें।
        source_master = source_slide.layout_slide.master_slide
        # मास्टर स्लाइड को लक्ष्य प्रस्तुति के मास्टर संग्रह में क्लोन करें।
        cloned_master = target_presentation.masters.add_clone(source_master)
        # क्लोन किए हुए मास्टर का उपयोग करके स्रोत प्रस्तुति की स्लाइड को लक्ष्य प्रस्तुति के अंत में क्लोन करें।
        target_presentation.slides.add_clone(source_slide, cloned_master, True)
        # लक्ष्य प्रस्तुति को डिस्क पर सहेजें।
        target_presentation.save("CloneToAnotherPresentationWithMaster_out.pptx", slides.export.SaveFormat.PPTX)
```

## **निर्धारित सेक्शन में अंत में क्लोन**

Aspose.Slides for Python via .NET के साथ, आप एक प्रस्तुति के किसी सेक्शन से स्लाइड को क्लोन करके उसे उसी प्रस्तुति के किसी अन्य सेक्शन में डाल सकते हैं। इसके लिए [SlideCollection](https://reference.aspose.com/slides/hi/python-net/aspose.slides/slidecollection/) क्लास के `add_clone(Slide, Section)` मेथड का उपयोग करें।

निम्नलिखित Python उदाहरण दिखाता है कि कैसे स्लाइड को क्लोन करके क्लोन को निर्दिष्ट सेक्शन में डालें:

```py
import aspose.slides as slides

# नई खाली प्रस्तुति बनाएं।
with slides.Presentation() as presentation:
    # पहले स्लाइड के लेआउट के आधार पर एक खाली स्लाइड जोड़ें।
    slide = presentation.slides.add_empty_slide(presentation.slides[0].layout_slide)
    # नई स्लाइड में एक एलिप्स आकार जोड़ें; यह स्लाइड बाद में क्लोन की जाएगी।
    slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 150, 150, 100, 100)
    # पहले स्लाइड के लेआउट के आधार पर एक और खाली स्लाइड जोड़ें।
    slide2 = presentation.slides.add_empty_slide(presentation.slides[0].layout_slide)
    # "Section2" नामक सेक्शन बनाएं जो slide2 पर शुरू होता है।
    section = presentation.sections.add_section("Section2", slide2)
    # पहले बनाई गई स्लाइड को "Section2" सेक्शन में क्लोन करें।
    presentation.slides.add_clone(slide, section)
    # प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।
    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

## **स्लाइड आकार का मिलान सुनिश्चित करें**

जब स्लाइडों को किसी अन्य प्रस्तुति में क्लोन किया जा रहा हो, तो सुनिश्चित करें कि गंतव्य प्रस्तुति का स्लाइड आकार स्रोत के समान हो। यदि स्लाइड आकार अलग हैं, तो Aspose.Slides क्लोन किए गए आकारों को स्वतः री‑स्केल नहीं करता—उनके मूल निर्देशांक और आयाम संरक्षित रहते हैं, जिससे सामग्री असंगत या स्लाइड की सीमाओं से बाहर हो सकती है।

क्लोन करने से पहले आप गंतव्य प्रस्तुति के स्लाइड आकार को स्रोत के समान सेट कर सकते हैं:

```py
source_size = source_presentation.slide_size.size

target_presentation.slide_size.set_size(
    source_size.width, source_size.height, slides.SlideSizeScaleType.DO_NOT_SCALE)
```

यह कार्य मास्टर और स्लाइड को क्लोन करने से पहले करें।

## **अक्सर पूछे जाने वाले प्रश्न**

### क्या स्पीकर नोट्स और समीक्षक टिप्पणियाँ क्लोन की जाती हैं?

हाँ। नोट्स पेज और समीक्षा टिप्पणियाँ क्लोन में शामिल होती हैं। यदि आप उन्हें नहीं चाहते, तो सम्मिलन के बाद उन्हें [उन्हें हटाएँ](/slides/hi/python-net/presentation-notes/)।

### चार्ट और उनके डेटा स्रोतों को कैसे संभाला जाता है?

चार्ट ऑब्जेक्ट, फ़ॉर्मेटिंग, और एम्बेडेड डेटा कॉपी किए जाते हैं। यदि चार्ट किसी बाहरी स्रोत (जैसे OLE‑एम्बेडेड वर्कबुक) से जुड़ा था, तो वह लिंक एक [OLE ऑब्जेक्ट](/slides/hi/python-net/manage-ole/) के रूप में संरक्षित रहता है। फाइलों के बीच स्थानांतरित करने के बाद डेटा उपलब्धता और रिफ्रेश व्यवहार को सत्यापित करें।

### क्या मैं क्लोन की सम्मिलन स्थिति और सेक्शन को नियंत्रित कर सकता हूँ?

हाँ। आप क्लोन को किसी विशिष्ट स्लाइड इंडेक्स पर सम्मिलित कर सकते हैं और उसे चुने हुए [सेक्शन](/slides/hi/python-net/slide-section/) में रख सकते हैं। यदि लक्ष्य सेक्शन मौजूद नहीं है, तो पहले उसे बनाएँ और फिर स्लाइड को उसमें ले जाएँ।