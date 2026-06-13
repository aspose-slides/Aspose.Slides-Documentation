---
title: Python के साथ प्रस्तुतियों में स्लाइड्स का एक्सेस
linktitle: स्लाइड का एक्सेस
type: docs
weight: 20
url: /hi/python-net/access-slide-in-presentation/
keywords:
- स्लाइड एक्सेस
- स्लाइड इंडेक्स
- स्लाइड आईडी
- स्लाइड स्थिति
- स्थिति बदलें
- स्लाइड गुण
- स्लाइड नंबर
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides for Python को .NET के माध्यम से उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में स्लाइड्स तक पहुँचने और उन्हें प्रबंधित करने के तरीके सीखें। कोड उदाहरणों के साथ उत्पादकता बढ़ाएँ।"
---
## **परिचय**

यह लेख Aspose.Slides for Python का उपयोग करके PowerPoint प्रस्तुति में विशिष्ट स्लाइड्स तक कैसे पहुंचा जाए, यह समझाता है। यह दिखाता है कि प्रस्तुति को कैसे खोला जाए, स्लाइड्स को इंडेक्स या अद्वितीय आईडी द्वारा कैसे संदर्भित किया जाए, तथा फ़ाइल के भीतर नेविगेशन के लिए आवश्यक मूलभूत स्लाइड जानकारी को कैसे पढ़ा जाए। इन तकनीकों के साथ, आप उस सटीक स्लाइड को भरोसेमंद तरीके से खोज सकते हैं जिसे आप निरीक्षण या प्रोसेस करना चाहते हैं।

## **इंडेक्स द्वारा स्लाइड प्राप्त करना**

प्रस्तुति में स्लाइड्स को स्थिति के आधार पर 0 से शुरू होने वाले इंडेक्स द्वारा क्रमित किया जाता है। पहली स्लाइड का इंडेक्स 0 होता है, दूसरी स्लाइड का इंडेक्स 1, और इसी प्रकार आगे।

The [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) class (which represents a presentation file) exposes slides through a [SlideCollection](https://reference.aspose.com/slides/hi/python-net/aspose.slides/slidecollection/) of [Slide](https://reference.aspose.com/slides/hi/python-net/aspose.slides/slide/) objects.

निम्नलिखित Python कोड दिखाता है कि कैसे इंडेक्स द्वारा स्लाइड तक पहुंचा जाए:

```python
import aspose.slides as slides

# एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation बनाएं।
with slides.Presentation("sample.pptx") as presentation:
    # उसके इंडेक्स द्वारा एक स्लाइड प्राप्त करें।
    slide = presentation.slides[0]
```

## **आईडी द्वारा स्लाइड प्राप्त करना**

प्रस्तुति की प्रत्येक स्लाइड का एक अद्वितीय आईडी होता है। आप इस आईडी को लक्षित करने के लिए [get_slide_by_id](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/get_slide_by_id/) मेथड (जो [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास द्वारा उपलब्ध कराया जाता है) का उपयोग कर सकते हैं।

निम्नलिखित Python कोड एक वैध स्लाइड आईडी प्रदान करके उस स्लाइड तक पहुंचने का तरीका दर्शाता है:

```python
import aspose.slides as slides

# एक Presentation बनाएं जो एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है।
with slides.Presentation("sample.pptx") as presentation:
    # एक स्लाइड आईडी प्राप्त करें।
    id = presentation.slides[0].slide_id
    # उसकी आईडी द्वारा स्लाइड तक पहुँचें।
    slide = presentation.get_slide_by_id(id)
```

## **स्लाइड की स्थिति बदलें**

Aspose.Slides आपको स्लाइड की स्थिति बदलने की अनुमति देता है। उदाहरण के तौर पर, आप पहली स्लाइड को दूसरी बना सकते हैं।

1. [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएं।  
2. उस स्लाइड का संदर्भ प्राप्त करें जिसकी स्थिति आप इंडेक्स द्वारा बदलना चाहते हैं।  
3. [slide_number](https://reference.aspose.com/slides/hi/python-net/aspose.slides/slide/slide_number/) प्रॉपर्टी के माध्यम से स्लाइड की नई स्थिति सेट करें।  
4. संशोधित प्रस्तुति को सहेजें।

निम्नलिखित Python कोड स्थिति 1 में रहने वाली स्लाइड को स्थिति 2 में ले जाता है:

```python
import aspose.slides as slides

# एक Presentation ऑब्जेक्ट बनाएं जो एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है।
with slides.Presentation("sample.pptx") as presentation:
    # वह स्लाइड प्राप्त करें जिसकी स्थिति बदलने वाली है।
    slide = presentation.slides[0]
    # स्लाइड के लिए नई स्थिति सेट करें।
    slide.slide_number = 2
    # संशोधित प्रस्तुति को सहेजें।
    presentation.save("slide_number.pptx", slides.export.SaveFormat.PPTX)
```

पहली स्लाइड दूसरी बन जाती है; दूसरी स्लाइड पहली बन जाती है। जब आप स्लाइड की स्थिति बदलते हैं, तो अन्य स्लाइड्स अपने आप समायोजित हो जाती हैं।

## **स्लाइड नंबर सेट करें**

[Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास द्वारा उपलब्ध [first_slide_number](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/first_slide_number/) प्रॉपर्टी का उपयोग करके आप प्रस्तुति में पहली स्लाइड के लिए नया नंबर निर्धारित कर सकते हैं। यह ऑपरेशन अन्य स्लाइड नंबरों को पुनः गणना करता है।

1. [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएं।  
2. स्लाइड नंबर सेट करें।  
3. संशोधित प्रस्तुति को सहेजें।

निम्नलिखित Python कोड दर्शाता है कि कैसे पहली स्लाइड नंबर को 10 पर सेट किया जाए:

```python
import aspose.slides as slides

# एक Presentation ऑब्जेक्ट बनाएं जो एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है।
with slides.Presentation("sample.pptx") as presentation:
    # स्लाइड नंबर सेट करें।
    presentation.first_slide_number = 10
    # संशोधित प्रस्तुति को सहेजें।
    presentation.save("first_slide_number.pptx", slides.export.SaveFormat.PPTX)
```

यदि आप पहली स्लाइड को छोड़ना चाहते हैं, तो आप नंबरिंग को दूसरे स्लाइड से शुरू कर सकते हैं (और पहली स्लाइड पर नंबर को छिपा सकते हैं) इस प्रकार:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)
    presentation.slides.add_empty_slide(layout_slide)
    presentation.slides.add_empty_slide(layout_slide)
    presentation.slides.add_empty_slide(layout_slide)

    # प्रस्तुति में पहली स्लाइड का नंबर सेट करें।
    presentation.first_slide_number = 0

    # सभी स्लाइड्स के लिए स्लाइड नंबर दिखाएँ।
    presentation.header_footer_manager.set_all_slide_numbers_visibility(True)

    # पहली स्लाइड पर स्लाइड नंबर छिपाएँ।
    presentation.slides[0].header_footer_manager.set_slide_number_visibility(False)

    # संशोधित प्रस्तुति को सहेजें।
    presentation.save("first_slide_number.pptx", slides.export.SaveFormat.PPTX)
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या उपयोगकर्ता द्वारा देखा गया स्लाइड नंबर संग्रह के शून्य-आधारित इंडेक्स से मेल खाता है?**

स्लाइड पर दिखाया गया नंबर मनमाने मान (उदाहरण के लिए, 10) से शुरू हो सकता है और उसे इंडेक्स से मिलाना आवश्यक नहीं है; इसका संबंध प्रस्तुति की [first slide number](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/first_slide_number/) सेटिंग द्वारा नियंत्रित होता है।

**क्या छुपी हुई स्लाइड्स इंडेक्सिंग को प्रभावित करती हैं?**

हां। एक छुपी हुई स्लाइड संग्रह में बनी रहती है और इंडेक्सिंग में गिनी जाती है; “छुपी हुई” का अर्थ केवल प्रदर्शन से है, न कि संग्रह में उसकी स्थिति से।

**क्या अन्य स्लाइड्स जोड़ी या हटाई जाने पर स्लाइड का इंडेक्स बदलता है?**

हां। इंडेक्स हमेशा वर्तमान स्लाइड क्रम को दर्शाते हैं और सम्मिलन, हटाने और स्थानांतरित करने के ऑपरेशन पर पुनः गणना होते हैं।