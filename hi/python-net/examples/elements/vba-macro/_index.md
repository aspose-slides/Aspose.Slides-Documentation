---
title: Vbaमैक्रो
type: docs
weight: 150
url: /hi/python-net/examples/elements/vba-macro/
keywords:
- VBA मैक्रो
- VBA मैक्रो जोड़ें
- VBA मैक्रो तक पहुँचें
- VBA मैक्रो हटाएँ
- कोड उदाहरण
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Aspose.Slides
description: "Python में Aspose.Slides का उपयोग करके VBA मैक्रो के साथ काम करें: परियोजनाएँ और मॉड्यूल जोड़ें या संपादित करें, मैक्रो पर हस्ताक्षर करें या हटाएँ, और PPT, PPTX और ODP में प्रस्तुतियों को सहेजें।"
---
VBA मैक्रोज़ को जोड़ने, एक्सेस करने और हटाने को **Aspose.Slides for Python via .NET** का उपयोग करके दिखाता है।

## **VBA मैक्रो जोड़ें**
VBA प्रोजेक्ट और एक सरल मैक्रो मॉड्यूल के साथ एक प्रस्तुति बनाएँ।

```py
def add_vba_macro():
    with slides.Presentation() as presentation:
        # एक VBA प्रोजेक्ट प्रारंभ करें।
        presentation.vba_project = slides.vba.VbaProject()

        # नाम "Module" वाला एक खाली मॉड्यूल जोड़ें।
        module = presentation.vba_project.modules.add_empty_module("Module")
        module.source_code = "Sub Test()\n MsgBox \"Hi\" \nEnd Sub"

        presentation.save("vba_macro.pptm", slides.export.SaveFormat.PPTM)
```

## **VBA मैक्रो तक पहुँचें**
VBA प्रोजेक्ट से पहला मॉड्यूल प्राप्त करें।

```py
def access_vba_macro():
    with slides.Presentation("vba_macro.pptm") as presentation:
        first_module = presentation.vba_project.modules[0]
```

## **VBA मैक्रो हटाएँ**
VBA प्रोजेक्ट से एक मॉड्यूल हटाएँ।

```py
def remove_vba_macro():
    with slides.Presentation("vba_macro.pptm") as presentation:

        # मान लेते हैं कि प्रस्तुति में एक VBA प्रोजेक्ट है और कम से कम एक मॉड्यूल है।
        module = presentation.vba_project.modules[0]

        # प्रोजेक्ट से मॉड्यूल हटाएँ।
        presentation.vba_project.modules.remove(module)

        presentation.save("vba_macro_removed.pptx", slides.export.SaveFormat.PPTX)
```