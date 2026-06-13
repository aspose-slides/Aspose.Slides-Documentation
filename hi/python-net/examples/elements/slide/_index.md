---
title: स्लाइड
type: docs
weight: 10
url: /hi/python-net/examples/elements/slide/
keywords:
- स्लाइड
- स्लाइड जोड़ें
- स्लाइड एक्सेस करें
- स्लाइड इंडेक्स
- स्लाइड क्लोन करें
- स्लाइड्स का क्रम बदलें
- स्लाइड हटाएँ
- कोड उदाहरण
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides के साथ Python में स्लाइड्स को प्रबंधित करें: बनाएं, क्लोन करें, क्रम बदलें, छुपाएँ, पृष्ठभूमि और आकार सेट करें, ट्रांज़िशन लागू करें, और PowerPoint तथा OpenDocument के लिए निर्यात करें।"
---
यह लेख कई उदाहरण प्रदान करता है जो **Aspose.Slides for Python via .NET** का उपयोग करके स्लाइड्स के साथ काम करने का तरीका दर्शाते हैं। आप `Presentation` क्लास का उपयोग करके स्लाइड्स को जोड़ना, एक्सेस करना, क्लोन करना, क्रम बदलना और हटाना सीखेंगे।

नीचे प्रत्येक उदाहरण में संक्षिप्त व्याख्या के बाद Python में कोड स्निपेट शामिल है।

## **स्लाइड जोड़ें**

नई स्लाइड जोड़ने के लिए, आपको पहले एक लेआउट चुनना होगा। इस उदाहरण में, हम `Blank` लेआउट का उपयोग करते हैं और प्रस्तुति में एक खाली स्लाइड जोड़ते हैं।

```py
def add_slide():
    with slides.Presentation() as presentation:
        # प्रत्येक स्लाइड एक लेआउट पर आधारित होती है, जो स्वयं एक मास्टर स्लाइड पर आधारित होता है।
        # नई स्लाइड बनाने के लिए Blank लेआउट का उपयोग करें।
        blank_layout = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

        # चयनित लेआउट का उपयोग करके एक नई खाली स्लाइड जोड़ें।
        presentation.slides.add_empty_slide(blank_layout)

        presentation.save("slide.pptx", slides.export.SaveFormat.PPTX)
```

> 💡 **सलाह:** प्रत्येक स्लाइड लेआउट एक मास्टर स्लाइड से व्युत्पन्न होता है, जो समग्र डिज़ाइन और प्लेसहोल्डर संरचना को परिभाषित करता है। नीचे की छवि दिखाती है कि PowerPoint में मास्टर स्लाइड्स और उनके संबंधित लेआउट कैसे व्यवस्थित होते हैं।

![मास्टर और लेआउट संबंध](master-layout-slide.png)

## **इंडेक्स द्वारा स्लाइड्स तक पहुँचें**

आप स्लाइड्स को उनके इंडेक्स का उपयोग करके एक्सेस कर सकते हैं। यह विशिष्ट स्लाइड्स को इटरिटेट करने या संशोधित करने के लिए उपयोगी है।

```py
def access_slide():
    with slides.Presentation("slide.pptx") as presentation:
        # स्लाइड को इंडेक्स द्वारा एक्सेस करें।
        first_slide = presentation.slides[0]
```

## **स्लाइड क्लोन करें**

यह उदाहरण दिखाता है कि मौजूदा स्लाइड को कैसे क्लोन किया जाए। क्लोन की गई स्लाइड स्वचालित रूप से स्लाइड संग्रह के अंत में जोड़ दी जाती है।

```py
def clone_slide():
    with slides.Presentation("slide.pptx") as presentation:
        slide = presentation.slides[0]

        # स्लाइड को क्लोन करें; यह प्रस्तुति के अंत में जोड़ी जाएगी।
        cloned_slide = presentation.slides.add_clone(slide)

        presentation.save("slide_cloned.pptx", slides.export.SaveFormat.PPTX)
```

## **स्लाइड्स को पुनः क्रमित करें**

आप स्लाइड्स का क्रम बदल सकते हैं एक स्लाइड को नए इंडेक्स पर ले जाकर। इस मामले में, हम एक स्लाइड को पहले स्थान पर ले जाते हैं।

```py
def reorder_slide():
    with slides.Presentation("slide.pptx") as presentation:
        slide = presentation.slides[1]

        # स्लाइड को पहली स्थिति में ले जाएँ (बाकी नीचे शिफ्ट होते हैं)।
        presentation.slides.reorder(0, slide)

        presentation.save("slide_reordered.pptx", slides.export.SaveFormat.PPTX)
```

## **स्लाइड हटाएँ**

स्लाइड हटाने के लिए, बस उसका संदर्भ दें और `remove` को कॉल करें। यह उदाहरण पहली स्लाइड को हटाता है।

```py
def remove_slide():
    with slides.Presentation("slide.pptx") as presentation:
        slide = presentation.slides[0]

        # स्लाइड को हटाएँ।
        presentation.slides.remove(slide)

        presentation.save("slide_removed.pptx", slides.export.SaveFormat.PPTX)
```