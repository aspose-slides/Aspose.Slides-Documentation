---
title: Python में PowerPoint स्लाइड्स क्लोन करें
linktitle: स्लाइड्स क्लोन करें
type: docs
weight: 40
url: /hi/python-net/clone-slides/
keywords:
- स्लाइड क्लोन
- स्लाइड कॉपी
- स्लाइड सहेजें
- PowerPoint
- प्रेजेंटेशन
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET के साथ PowerPoint स्लाइड्स को तेज़ी से क्लोन या डुप्लिकेट करें। सेकंड में PPT निर्माण को स्वचालित करने, उत्पादकता बढ़ाने और मैन्युअल कार्य को समाप्त करने के लिए हमारे स्पष्ट कोड उदाहरणों और टिप्स का पालन करें।"
---
## **परिचय**

क्लोनिंग वह प्रक्रिया है जिसमें किसी वस्तु की सटीक प्रति या प्रतिरूप बनाया जाता है। Aspose.Slides आपको किसी भी स्लाइड को कॉपी (क्लोन) करने और फिर क्लोन की गई स्लाइड को वर्तमान प्रेजेंटेशन या किसी अन्य खुले प्रेजेंटेशन में सम्मिलित करने की भी अनुमति देता है। स्लाइड क्लोनिंग एक नई स्लाइड बनाती है जिसे डेवलपर्स मूल स्लाइड को प्रभावित किए बिना संशोधित कर सकते हैं। स्लाइड को क्लोन करने के कई तरीके हैं:

- प्रेजेंटेशन के अंत में क्लोन करें।
- प्रेजेंटेशन के भीतर किसी अन्य स्थान पर क्लोन करें।
- दूसरे प्रेजेंटेशन के अंत में क्लोन करें।
- दूसरे प्रेजेंटेशन में किसी अन्य स्थान पर क्लोन करें।
- दूसरे प्रेजेंटेशन में विशिष्ट स्थान पर क्लोन करें।

Aspose.Slides for Python via .NET में, [slide collection](https://reference.aspose.com/slides/hi/python-net/aspose.slides/slidecollection/) द्वारा प्रदर्शित [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) ऑब्जेक्ट `add_clone` और `insert_clone` मेथड्स प्रदान करता है जो इन प्रकार की स्लाइड क्लोनिंग को करने में सहायता करते हैं।

## **इसी प्रेजेंटेशन के भीतर अंत में क्लोन**

यदि आप उसी प्रेजेंटेशन के भीतर एक स्लाइड को क्लोन करना चाहते हैं और उसे मौजूद स्लाइडों के अंत में जोड़ना चाहते हैं, तो `add_clone` मेथड का उपयोग करें। निम्न चरणों का पालन करें:

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएं।
1. उस [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) ऑब्जेक्ट से स्लाइड संग्रह प्राप्त करें।
1. स्लाइड को क्लोन करने के लिए [SlideCollection](https://reference.aspose.com/slides/hi/python-net/aspose.slides/slidecollection/) पर `add_clone` मेथड कॉल करें और क्लोन की जाने वाली स्लाइड पास करें।
1. संशोधित प्रेजेंटेशन को सहेजें।

नीचे दिए उदाहरण में, पहली स्लाइड (इंडेक्स 0) को क्लोन करके प्रेजेंटेशन के अंत में जोड़ दिया गया है।

```py
import aspose.slides as slides

# प्रस्तुतिकरण फ़ाइल का प्रतिनिधित्व करने के लिए Presentation क्लास का उदाहरण बनाएं।
with slides.Presentation("CloneWithinSamePresentationToEnd.pptx") as presentation:
    # समान प्रस्तुतिकरण में स्लाइड संग्रह के अंत में वांछित स्लाइड को क्लोन करें।
    presentation.slides.add_clone(presentation.slides[0])
    # संशोधित प्रस्तुतिकरण को डिस्क पर सहेजें।
    presentation.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", slides.export.SaveFormat.PPTX)
```

## **इसी प्रेजेंटेशन के भीतर विशिष्ट स्थान पर क्लोन**

यदि आप उसी प्रेजेंटेशन के भीतर एक स्लाइड को क्लोन करके उसे किसी अन्य स्थान पर रखना चाहते हैं, तो `insert_clone` मेथड का उपयोग करें:

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएं।
1. उस [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) ऑब्जेक्ट से स्लाइड संग्रह प्राप्त करें।
1. स्लाइड को क्लोन करने और उसके नए स्थान के लक्ष्य इंडेक्स को पास करने के लिए [SlideCollection](https://reference.aspose.com/slides/hi/python-net/aspose.slides/slidecollection/) पर `insert_clone` मेथड कॉल करें।
1. संशोधित प्रेजेंटेशन को सहेजें।

नीचे दिए उदाहरण में, इंडेक्स 0 (स्थिति 1) की स्लाइड को इंडेक्स 1 (स्थिति 2) पर क्लोन करके उसी प्रेजेंटेशन में रखा गया है।

```py
import aspose.slides as slides

# प्रस्तुतिकरण फ़ाइल का प्रतिनिधित्व करने के लिए Presentation क्लास का उदाहरण बनाएं।
with slides.Presentation("CloneWithInSamePresentation.pptx") as presentation:
    # समान प्रस्तुतिकरण में निर्दिष्ट स्थिति (इंडेक्स) पर वांछित स्लाइड को क्लोन करें।
    presentation.slides.insert_clone(2, presentation.slides[1])
    # संशोधित प्रस्तुतिकरण को डिस्क पर सहेजें।
    presentation.save("Aspose_CloneWithInSamePresentation_out.pptx", slides.export.SaveFormat.PPTX)
```

## **दूसरे प्रेजेंटेशन के अंत में क्लोन**

यदि आपको एक प्रेजेंटेशन से स्लाइड को क्लोन करके उसे दूसरे प्रेजेंटेशन के अंत में जोड़ना है:

1. स्रोत प्रेजेंटेशन (जिसमें क्लोन करने वाली स्लाइड है) के लिए एक [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास का उदाहरण बनाएं।
1. गंतव्य प्रेजेंटेशन (जहाँ स्लाइड जोड़ी जाएगी) के लिए एक [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास का उदाहरण बनाएं।
1. गंतव्य प्रेजेंटेशन से स्लाइड संग्रह प्राप्त करें।
1. गंतव्य [SlideCollection](https://reference.aspose.com/slides/hi/python-net/aspose.slides/slidecollection/) पर `add_clone` कॉल करें और स्रोत प्रेजेंटेशन की स्लाइड पास करें।
1. संशोधित गंतव्य प्रेजेंटेशन को सहेजें।

नीचे दिए उदाहरण में, स्रोत प्रेजेंटेशन में इंडेक्स 0 पर स्थित स्लाइड को गंतव्य प्रेजेंटेशन के अंत में क्लोन किया गया है।

```py
import aspose.slides as slides

# स्रोत प्रस्तुतिकरण फ़ाइल का प्रतिनिधित्व करने के लिए Presentation क्लास का उदाहरण बनाएं।
with slides.Presentation("CloneAtEndOfAnother.pptx") as source_presentation:
    # गंतव्य PPTX (जहाँ स्लाइड क्लोन की जाएगी) के लिए Presentation क्लास का उदाहरण बनाएं।
    with slides.Presentation() as target_presentation:
        # स्रोत प्रस्तुतिकरण से वांछित स्लाइड को गंतव्य प्रस्तुतिकरण में स्लाइड संग्रह के अंत में क्लोन करें।
        target_presentation.slides.add_clone(source_presentation.slides[0])
        # गंतव्य प्रस्तुतिकरण को डिस्क पर सहेजें।
        target_presentation.save("Aspose2_out.pptx", slides.export.SaveFormat.PPTX)
```

## **दूसरे प्रेजेंटेशन में विशिष्ट स्थान पर क्लोन**

यदि आपको एक प्रेजेंटेशन से स्लाइड को क्लोन करके उसे दूसरे प्रेजेंटेशन में किसी विशिष्ट स्थान पर जोड़ना है:

1. स्रोत प्रेजें�ेशन (जिसमें क्लोन करने वाली स्लाइड है) के लिए एक [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास का उदाहरण बनाएं।
1. गंतव्य प्रेजेंटेशन (जहाँ स्लाइड जोड़ी जाएगी) के लिए एक [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास का उदाहरण बनाएं।
1. गंतव्य प्रेजेंटेशन से स्लाइड संग्रह प्राप्त करें।
1. गंतव्य [SlideCollection](https://reference.aspose.com/slides/hi/python-net/aspose.slides/slidecollection/) पर `insert_clone` मेथड कॉल करें और स्रोत स्लाइड तथा इच्छित लक्ष्य इंडेक्स पास करें।
1. संशोधित गंतव्य प्रेजेंटेशन को सहेजें।

नीचे दिए उदाहरण में, स्रोत प्रेजेंटेशन में इंडेक्स 0 पर स्थित स्लाइड को गंतव्य प्रेजेंटेशन में इंडेक्स 1 (स्थिति 2) पर क्लोन किया गया है।

```py
import aspose.slides as slides

# स्रोत प्रस्तुतिकरण फ़ाइल का प्रतिनिधित्व करने के लिए Presentation क्लास का उदाहरण बनाएं।
with slides.Presentation("CloneAtEndOfAnother.pptx") as source_presentation:
    # गंतव्य PPTX (जहाँ स्लाइड क्लोन की जाएगी) के लिए Presentation क्लास का उदाहरण बनाएं।
    with slides.Presentation("Aspose2_out.pptx") as target_presentation:
        # स्रोत से पहली स्लाइड की क्लोन को गंतव्य प्रस्तुतिकरण में इंडेक्स 2 पर सम्मिलित करें।
        target_presentation.slides.insert_clone(2, source_presentation.slides[0])
        # गंतव्य प्रस्तुतिकरण को डिस्क पर सहेजें।
        target_presentation.save("Aspose3_out.pptx", slides.export.SaveFormat.PPTX)
```

## **एक स्लाइड को उसके मास्टर स्लाइड के साथ दूसरे प्रेजेंटेशन में क्लोन करना**

यदि आपको एक स्लाइड **उसके मास्टर** के साथ एक प्रेजेंटेशन से क्लोन करके दूसरे में उपयोग करना है, तो पहले स्रोत प्रेजेंटेशन से आवश्यक मास्टर स्लाइड को गंतव्य प्रेजेंटेशन में क्लोन करें। फिर स्लाइड को क्लोन करते समय उस गंतव्य मास्टर का उपयोग करें। मेथड `add_clone(Slide, MasterSlide)` **गंतव्य प्रेजेंटेशन की मास्टर स्लाइड** की अपेक्षा करता है, स्रोत की नहीं।

स्लाइड को उसके मास्टर के साथ क्लोन करने के लिए इन चरणों का पालन करें:

1. स्रोत प्रेजेंटेशन (जिसमें क्लोन करने वाली स्लाइड है) के लिए एक [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास का उदाहरण बनाएं।
1. गंतव्य प्रेजेंटेशन के लिए एक [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास का उदाहरण बनाएं।
1. क्लोन की जाने वाली स्रोत स्लाइड और उसका मास्टर स्लाइड प्राप्त करें।
1. गंतव्य प्रेजेंटेशन के मास्टर संग्रह से [MasterSlideCollection](https://reference.aspose.com/slides/hi/python-net/aspose.slides/masterslidecollection/) प्राप्त करें।
1. गंतव्य [MasterSlideCollection](https://reference.aspose.com/slides/hi/python-net/aspose.slides/masterslidecollection/) पर `add_clone` कॉल करें और स्रोत मास्टर को पास करके उसे गंतव्य में क्लोन करें।
1. गंतव्य प्रेजेंटेशन के स्लाइड संग्रह से [SlideCollection](https://reference.aspose.com/slides/hi/python-net/aspose.slides/slidecollection/) प्राप्त करें।
1. गंतव्य [SlideCollection](https://reference.aspose.com/slides/hi/python-net/aspose.slides/slidecollection/) पर `add_clone` कॉल करें और स्रोत स्लाइड तथा क्लोन किए गए गंतव्य मास्टर को पास करें।
1. संशोधित गंतव्य प्रेजेंटेशन को सहेजें।

नीचे दिए उदाहरण में, स्रोत प्रेजेंटेशन में इंडेक्स 0 पर स्थित स्लाइड को स्रोत से क्लोन किए गए मास्टर का उपयोग करके गंतव्य प्रेजेंटेशन के अंत में क्लोन किया गया है।

```py
import aspose.slides as slides

# स्रोत प्रस्तुतिकरण फ़ाइल का प्रतिनिधित्व करने के लिए Presentation क्लास का उदाहरण बनाएं।
with slides.Presentation("CloneToAnotherPresentationWithMaster.pptx") as source_presentation:
    # स्लाइड को क्लोन किए जाने वाले गंतव्य प्रस्तुतिकरण के लिए Presentation क्लास का उदाहरण बनाएं।
    with slides.Presentation() as target_presentation:
        # स्रोत प्रस्तुतिकरण से पहली स्लाइड प्राप्त करें।
        source_slide = source_presentation.slides[0]
        # पहली स्लाइड द्वारा उपयोग की गई मास्टर स्लाइड प्राप्त करें।
        source_master = source_slide.layout_slide.master_slide
        # मास्टर स्लाइड को गंतव्य प्रस्तुतिकरण के मास्टर संग्रह में क्लोन करें।
        cloned_master = target_presentation.masters.add_clone(source_master)
        # क्लोन किए गए मास्टर का उपयोग करके स्रोत प्रस्तुतिकरण की स्लाइड को गंतव्य प्रस्तुतिकरण के अंत में क्लोन करें।
        target_presentation.slides.add_clone(source_slide, cloned_master, True)
        # गंतव्य प्रस्तुतिकरण को डिस्क पर सहेजें।
        target_presentation.save("CloneToAnotherPresentationWithMaster_out.pptx", slides.export.SaveFormat.PPTX)
```

## **निर्दिष्ट सेक्शन में अंत में क्लोन**

Aspose.Slides for Python via .NET के साथ, आप एक प्रेजेंटेशन के किसी सेक्शन से स्लाइड को क्लोन करके उसी प्रेजेंटेशन के दूसरे सेक्शन में सम्मिलित कर सकते हैं। ऐसा करने के लिए, [SlideCollection](https://reference.aspose.com/slides/hi/python-net/aspose.slides/slidecollection/) क्लास की `add_clone(Slide, Section)` मेथड का उपयोग करें।

निम्न Python उदाहरण दिखाता है कि कैसे स्लाइड को क्लोन करके क्लोन को निर्दिष्ट सेक्शन में सम्मिलित किया जाता है:

```py
import aspose.slides as slides

# एक नया खाली प्रस्तुति बनाएं।
with slides.Presentation() as presentation:
    # पहली स्लाइड के लेआउट के आधार पर एक खाली स्लाइड जोड़ें।
    slide = presentation.slides.add_empty_slide(presentation.slides[0].layout_slide)
    # नई स्लाइड में एक अंडाकार आकृति जोड़ें; इस स्लाइड को बाद में क्लोन किया जाएगा।
    slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 150, 150, 100, 100)
    # पहली स्लाइड के लेआउट के आधार पर एक और खाली स्लाइड जोड़ें।
    slide2 = presentation.slides.add_empty_slide(presentation.slides[0].layout_slide)
    # "Section2" नाम का एक सेक्शन बनाएं जो slide2 से शुरू हो।
    section = presentation.sections.add_section("Section2", slide2)
    # पहले बनाई गई स्लाइड को "Section2" सेक्शन में क्लोन करें।
    presentation.slides.add_clone(slide, section)
    # प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।
    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या स्पीकर नोट्स और रिव्यूर कमेंट्स भी क्लोन होते हैं?**

हाँ। नोट्स पेज और रिव्यू टिप्पणी क्लोन में शामिल होते हैं। यदि आप उन्हें नहीं चाहते, तो सम्मिलित करने के बाद उन्हें [हटा दें](/slides/hi/python-net/presentation-notes/)।

**चार्ट और उनके डेटा स्रोत कैसे संभाले जाते हैं?**

चार्ट ऑब्जेक्ट, फ़ॉर्मेटिंग और एम्बेडेड डेटा कॉपी होते हैं। यदि चार्ट बाहरी स्रोत (जैसे OLE-एम्बेडेड वर्कबुक) से लिंक किया गया था, तो वह लिंक एक [OLE ऑब्जेक्ट](/slides/hi/python-net/manage-ole/) के रूप में संरक्षित रहता है। फ़ाइलों के बीच स्थानांतरित करने के बाद डेटा उपलब्धता और रिफ्रेश व्यवहार की जाँच करें।

**क्या मैं क्लोन की सम्मिलन स्थिति और सेक्शन्स को नियंत्रित कर सकता हूँ?**

हाँ। आप क्लोन को विशिष्ट स्लाइड इंडेक्स पर सम्मिलित कर सकते हैं और उसे चुने हुए [section](/slides/hi/python-net/slide-section/) में रख सकते हैं। यदि लक्ष्य सेक्शन मौजूद नहीं है, तो पहले उसे बनाएं और फिर स्लाइड को उसमें ले जाएँ।