---
title: Python में PowerPoint स्लाइड्स क्लोन करें
linktitle: स्लाइड क्लोन
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
description: "Aspose.Slides for Python via .NET के साथ PowerPoint स्लाइड्स को तेज़ी से क्लोन या डुप्लिकेट करें। सेकंडों में PPT निर्माण को स्वचालित करने, उत्पादकता बढ़ाने और मैनुअल कार्य को समाप्त करने के लिए हमारे स्पष्ट कोड उदाहरण और टिप्स का पालन करें।"
---
## **परिचय**

क्लोनिंग वह प्रक्रिया है जिसमें किसी चीज़ की सटीक प्रति या प्रतिकृति बनाई जाती है। Aspose.Slides आपको किसी भी स्लाइड को कॉपी (क्लोन) करने और फिर क्लोन की गई स्लाइड को वर्तमान प्रेजेंटेशन या किसी अन्य खुले प्रेजेंटेशन में डालने की अनुमति भी देता है। स्लाइड क्लोनिंग एक नई स्लाइड बनाता है जिसे डेवलपर मूल स्लाइड को प्रभावित किए बिना संशोधित कर सकते हैं। स्लाइड को क्लोन करने के कई तरीके हैं:

- प्रेजेंटेशन के अंत में क्लोन करें।
- प्रेजेंटेशन के भीतर किसी अन्य स्थिति में क्लोन करें।
- दूसरे प्रेजेंटेशन के अंत में क्लोन करें।
- दूसरे प्रेजेंटेशन में किसी अन्य स्थिति में क्लोन करें।
- दूसरे प्रेजेंटेशन में विशिष्ट स्थिति में क्लोन करें।

Aspose.Slides for Python via .NET में, [slide collection](https://reference.aspose.com/slides/hi/python-net/aspose.slides/slidecollection/) द्वारा प्रकट किया गया [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) ऑब्जेक्ट `add_clone` और `insert_clone` मेथड्स प्रदान करता है ताकि इन प्रकार की स्लाइड क्लोनिंग की जा सके।

## **स्थापना**

```bash
pip install aspose.slides
```

## **एक ही प्रेजेंटेशन में अंत में क्लोन**

यदि आप एक ही प्रेजेंटेशन में स्लाइड को क्लोन करके मौजूदा स्लाइडों के अंत में जोड़ना चाहते हैं, तो `add_clone` मेथड का उपयोग करें। निम्न चरणों का पालन करें:

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास का इंस्टेंस बनाएं।
1. [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) ऑब्जेक्ट से स्लाइड कलेक्शन प्राप्त करें।
1. [SlideCollection](https://reference.aspose.com/slides/hi/python-net/aspose.slides/slidecollection/) पर `add_clone` मेथड कॉल करें, जिसमें क्लोन की जाने वाली स्लाइड पास करें।
1. संशोधित प्रेजेंटेशन को सहेजें।

नीचे दिए गए उदाहरण में, पहली स्लाइड (इंडेक्स 0) को क्लोन कर प्रेजेंटेशन के अंत में जोड़ा गया है।

```py
import aspose.slides as slides

# प्रस्तुति फ़ाइल को दर्शाने के लिए Presentation क्लास का इंस्टेंस बनाएं।
with slides.Presentation("CloneWithinSamePresentationToEnd.pptx") as presentation:
    # इच्छित स्लाइड को उसी प्रस्तुति में स्लाइड संग्रह के अंत में क्लोन करें।
    presentation.slides.add_clone(presentation.slides[0])
    # संशोधित प्रस्तुति को डिस्क पर सहेजें।
    presentation.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", slides.export.SaveFormat.PPTX)
```

## **एक ही प्रेजेंटेशन में विशिष्ट स्थिति में क्लोन**

यदि आप एक ही प्रेजेंटेशन में स्लाइड को क्लोन करके उसे किसी अन्य स्थिति में रखना चाहते हैं, तो `insert_clone` मेथड का उपयोग करें:

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास का इंस्टेंस बनाएं।
1. [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) ऑब्जेक्ट से स्लाइड कलेक्शन प्राप्त करें।
1. [SlideCollection](https://reference.aspose.com/slides/hi/python-net/aspose.slides/slidecollection/) पर `insert_clone` मेथड कॉल करें, जिसमें क्लोन की जाने वाली स्लाइड और उसकी नई स्थिति के लिए लक्षित इंडेक्स पास करें।
1. संशोधित प्रेजेंटेशन को सहेजें।

नीचे दिए गए उदाहरण में, इंडेक्स 1 (स्थिति 2) वाली स्लाइड को एक ही प्रेजेंटेशन में इंडेक्स 2 (स्थिति 3) पर क्लोन किया गया है।

```py
import aspose.slides as slides

# प्रस्तुति फ़ाइल को दर्शाने के लिए Presentation क्लास का इंस्टेंस बनाएं।
with slides.Presentation("CloneWithInSamePresentation.pptx") as presentation:
    # इच्छित स्लाइड को उसी प्रस्तुति में निर्दिष्ट स्थिति (इंडेक्स) पर क्लोन करें।
    presentation.slides.insert_clone(2, presentation.slides[1])
    # संशोधित प्रस्तुति को डिस्क पर सहेजें।
    presentation.save("Aspose_CloneWithInSamePresentation_out.pptx", slides.export.SaveFormat.PPTX)
```

## **दूसरे प्रेजेंटेशन के अंत में क्लोन**

यदि आपको एक प्रेजेंटेशन से स्लाइड को क्लोन करके दूसरे प्रेजेंटेशन के अंत में जोड़ने की आवश्यकता है:

1. स्लाइड को क्लोन करने वाले स्रोत प्रेजेंटेशन के लिए एक [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास का इंस्टेंस बनाएं।
1. गंतव्य प्रेजेंटेशन (जहां स्लाइड जोड़ी जाएगी) के लिए एक [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास का इंस्टेंस बनाएं।
1. गंतव्य प्रेजेंटेशन से स्लाइड कलेक्शन प्राप्त करें।
1. गंतव्य [SlideCollection](https://reference.aspose.com/slides/hi/python-net/aspose.slides/slidecollection/) पर `add_clone` कॉल करें, जिसमें स्रोत प्रेजेंटेशन से स्लाइड पास करें।
1. संशोधित गंतव्य प्रेजेंटेशन को सहेजें।

नीचे दिए गए उदाहरण में, स्रोत प्रेजेंटेशन में इंडेक्स 0 वाली स्लाइड को गंतव्य प्रेजेंटेशन के अंत में क्लोन किया गया है।

```py
import aspose.slides as slides

# सोर्स प्रस्तुति फ़ाइल को दर्शाने के लिए Presentation क्लास का इंस्टेंस बनाएं।
with slides.Presentation("CloneAtEndOfAnother.pptx") as source_presentation:
    # डेस्टिनेशन PPTX (जहाँ स्लाइड क्लोन की जाएगी) के लिए Presentation क्लास का इंस्टेंस बनाएं।
    with slides.Presentation() as target_presentation:
        # सोर्स प्रस्तुति से इच्छित स्लाइड को डेस्टिनेशन प्रस्तुति के स्लाइड कलेक्शन के अंत में क्लोन करें।
        target_presentation.slides.add_clone(source_presentation.slides[0])
        # डेस्टिनेशन प्रस्तुति को डिस्क पर सहेजें।
        target_presentation.save("Aspose2_out.pptx", slides.export.SaveFormat.PPTX)
```

## **दूसरे प्रेजेंटेशन में विशिष्ट स्थिति में क्लोन**

यदि आपको एक प्रेजेंटेशन से स्लाइड को क्लोन करके उसे दूसरे प्रेजेंटेशन में विशिष्ट स्थिति में डालने की आवश्यकता है:

1. स्लाइड को क्लोन करने वाले स्रोत प्रेजेंटेशन के लिए एक [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास का इंस्टेंस बनाएं।
1. गंतव्य प्रेजेंटेशन (जहां स्लाइड जोड़ी जाएगी) के लिए एक [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास का इंस्टेंस बनाएं।
1. गंतव्य प्रेजेंटेशन से स्लाइड कलेक्शन प्राप्त करें।
1. गंतव्य [SlideCollection](https://reference.aspose.com/slides/hi/python-net/aspose.slides/slidecollection/) पर `insert_clone` मेथड कॉल करें, जिसमें स्रोत प्रेजेंटेशन से स्लाइड और वांछित लक्षित इंडेक्स पास करें।
1. संशोधित गंतव्य प्रेजेंटेशन को सहेजें।

नीचे दिए गए उदाहरण में, स्रोत प्रेजेंटेशन में इंडेक्स 0 वाली स्लाइड को गंतव्य प्रेजेंटेशन में इंडेक्स 2 (स्थिति 3) पर क्लोन किया गया है।

```py
import aspose.slides as slides

# सोर्स प्रस्तुति फ़ाइल को दर्शाने के लिए Presentation क्लास का इंस्टेंस बनाएं।
with slides.Presentation("CloneAtEndOfAnother.pptx") as source_presentation:
    # डेस्टिनेशन PPTX (जहाँ स्लाइड को क्लोन किया जाना है) के लिए Presentation क्लास का इंस्टेंस बनाएं।
    with slides.Presentation("Aspose2_out.pptx") as target_presentation:
        # सोर्स से पहली स्लाइड की क्लोन को डेस्टिनेशन प्रस्तुति में इंडेक्स 2 पर डालें।
        target_presentation.slides.insert_clone(2, source_presentation.slides[0])
        # डेस्टिनेशन प्रस्तुति को डिस्क पर सहेजें।
        target_presentation.save("Aspose3_out.pptx", slides.export.SaveFormat.PPTX)
```

## **मास्टर स्लाइड के साथ स्लाइड को दूसरे प्रेजेंटेशन में क्लोन**

यदि आपको एक प्रेजेंटेशन से **अपने मास्टर के साथ** स्लाइड को क्लोन करके दूसरे में उपयोग करने की आवश्यकता है, तो पहले स्रोत प्रेजेंटेशन से आवश्यक मास्टर स्लाइड को गंतव्य प्रेजेंटेशन में क्लोन करें। फिर स्लाइड को क्लोन करते समय उस गंतव्य मास्टर का उपयोग करें। मेथड `add_clone(Slide, MasterSlide)` **गंतव्य प्रेजेंटेशन की मास्टर स्लाइड** की अपेक्षा करता है, न कि स्रोत की।

मास्टर स्लाइड के साथ स्लाइड को क्लोन करने के लिए, निम्न चरणों का पालन करें:

1. स्रोत प्रेजेंटेशन (जिसमें क्लोन की जाने वाली स्लाइड है) के लिए एक [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास का इंस्टेंस बनाएं।
1. गंतव्य प्रेजेंटेशन के लिए एक [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास का इंस्टेंस बनाएं।
1. स्रोत स्लाइड जिसे क्लोन करना है और उसकी मास्टर स्लाइड तक पहुँचें।
1. गंतव्य प्रेजेंटेशन के मास्टर कलेक्शन से [MasterSlideCollection](https://reference.aspose.com/slides/hi/python-net/aspose.slides/masterslidecollection/) प्राप्त करें।
1. गंतव्य [MasterSlideCollection](https://reference.aspose.com/slides/hi/python-net/aspose.slides/masterslidecollection/) पर `add_clone` कॉल करें, जिसमें स्रोत मास्टर पास करके उसे गंतव्य में क्लोन करें।
1. गंतव्य प्रेजेंटेशन के स्लाइड कलेक्शन से [SlideCollection](https://reference.aspose.com/slides/hi/python-net/aspose.slides/slidecollection/) प्राप्त करें।
1. गंतव्य [SlideCollection](https://reference.aspose.com/slides/hi/python-net/aspose.slides/slidecollection/) पर `add_clone` कॉल करें, जिसमें स्रोत स्लाइड और क्लोन किया गया गंतव्य मास्टर पास करें।
1. संशोधित गंतव्य प्रेजेंटेशन को सहेजें।

नीचे दिए गए उदाहरण में, स्रोत प्रेजेंटेशन में इंडेक्स 0 वाली स्लाइड को स्रोत से क्लोन किए गए मास्टर का उपयोग करके गंतव्य प्रेजेंटेशन के अंत में क्लोन किया गया है।

```py
import aspose.slides as slides

# स्रोत प्रस्तुति फ़ाइल को दर्शाने के लिए Presentation क्लास का इंस्टेंस बनाएं।
with slides.Presentation("CloneToAnotherPresentationWithMaster.pptx") as source_presentation:
    # स्लाइड को क्लोन करने वाली डेस्टिनेशन प्रस्तुति के लिए Presentation क्लास का इंस्टेंस बनाएं।
    with slides.Presentation() as target_presentation:
        # स्रोत प्रस्तुति से पहली स्लाइड प्राप्त करें।
        source_slide = source_presentation.slides[0]
        # पहली स्लाइड द्वारा उपयोग की गई मास्टर स्लाइड प्राप्त करें।
        source_master = source_slide.layout_slide.master_slide
        # मास्टर स्लाइड को डेस्टिनेशन प्रस्तुति के मास्टर संग्रह में क्लोन करें।
        cloned_master = target_presentation.masters.add_clone(source_master)
        # क्लोन की गई मास्टर का उपयोग करके स्रोत प्रस्तुति से स्लाइड को डेस्टिनेशन प्रस्तुति के अंत में क्लोन करें।
        target_presentation.slides.add_clone(source_slide, cloned_master, True)
        # डेस्टिनेशन प्रस्तुति को डिस्क पर सहेजें।
        target_presentation.save("CloneToAnotherPresentationWithMaster_out.pptx", slides.export.SaveFormat.PPTX)
```

## **निर्दिष्ट सेक्शन में अंत में क्लोन**

Aspose.Slides for Python via .NET के साथ, आप प्रेजेंटेशन के एक सेक्शन से स्लाइड को क्लोन करके उसी प्रेजेंटेशन के दूसरे सेक्शन में डाल सकते हैं। इसके लिए, [SlideCollection](https://reference.aspose.com/slides/hi/python-net/aspose.slides/slidecollection/) क्लास की `add_clone(Slide, Section)` मेथड का उपयोग करें।

निम्नलिखित Python उदाहरण दर्शाता है कि कैसे स्लाइड को क्लोन कर क्लोन को निर्दिष्ट सेक्शन में डाला जाए:

```py
import aspose.slides as slides

# एक नई खाली प्रस्तुति बनाएं।
with slides.Presentation() as presentation:
    # पहली स्लाइड के लेआउट के आधार पर एक खाली स्लाइड जोड़ें।
    slide = presentation.slides.add_empty_slide(presentation.slides[0].layout_slide)
    # नई स्लाइड में एक अंडाकार आकार जोड़ें; इस स्लाइड को बाद में क्लोन किया जाएगा।
    slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 150, 150, 100, 100)
    # पहली स्लाइड के लेआउट के आधार पर एक और खाली स्लाइड जोड़ें।
    slide2 = presentation.slides.add_empty_slide(presentation.slides[0].layout_slide)
    # "Section2" नाम का सेक्शन बनाएं जो slide2 से शुरू होता है।
    section = presentation.sections.add_section("Section2", slide2)
    # पहले बनाई गई स्लाइड को "Section2" सेक्शन में क्लोन करें।
    presentation.slides.add_clone(slide, section)
    # प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।
    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

### क्या स्पीकर नोट्स और रिव्यूअर कमेंट्स क्लोन हो जाते हैं?

हाँ। नोट्स पेज और रिव्यू टिप्पणी क्लोन में शामिल होते हैं। यदि आप इन्हें नहीं चाहते हैं, तो इंसर्शन के बाद उन्हें [हटा दें](/slides/hi/python-net/presentation-notes/)।

### चार्ट्स और उनके डेटा स्रोतों को कैसे संभाला जाता है?

चार्ट ऑब्जेक्ट, फ़ॉर्मेटिंग और एम्बेडेड डेटा कॉपी हो जाते हैं। यदि चार्ट किसी बाहरी स्रोत (जैसे OLE-एम्बेडेड वर्कबुक) से लिंक था, तो वह लिंक एक [OLE ऑब्जेक्ट](/slides/hi/python-net/manage-ole/) के रूप में संरक्षित रहता है। फाइलों के बीच स्थानांतरित करने के बाद डेटा उपलब्धता और रीफ़्रेश व्यवहार की जाँच करें।

### क्या मैं क्लोन की इंसर्शन पोजिशन और सेक्शन को नियंत्रित कर सकता हूँ?

हाँ। आप क्लोन को किसी विशिष्ट स्लाइड इंडेक्स पर डाल सकते हैं और इसे चुने हुए [सेक्शन](/slides/hi/python-net/slide-section/) में रख सकते हैं। यदि लक्षित सेक्शन मौजूद नहीं है, तो पहले उसे बनाएं और फिर स्लाइड को उसमें ले जाएँ।