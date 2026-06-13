---
title: ActiveX
type: docs
weight: 200
url: /hi/python-net/examples/elements/activex/
keywords:
- ActiveX
- ActiveX नियंत्रण
- ActiveX जोड़ें
- ActiveX पहुँचें
- ActiveX हटाएँ
- ActiveX गुण
- कोड उदाहरण
- PowerPoint
- प्रस्तुति
- Python
- Aspose.Slides
description: "Python के साथ Aspose.Slides में ActiveX नियंत्रण को खोजने, संपादित करने और हटाने के तरीके सीखें, जिसमें PowerPoint प्रस्तुतियों के लिए गुण अद्यतन शामिल हैं।"
---
एक प्रस्तुति में ActiveX नियंत्रणों को जोड़ने, पहुँचने, हटाने और कॉन्फ़िगर करने का प्रदर्शन करता है, **Aspose.Slides for Python via .NET** का उपयोग करके.

## **ActiveX नियंत्रण जोड़ें**
एक नया ActiveX नियंत्रण डालें.

```py
def add_activex():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # एक नया ActiveX नियंत्रण (TextBox) जोड़ें।
        control = slide.controls.add_control(slides.ControlType.WINDOWS_MEDIA_PLAYER, 50, 50, 100, 50)

        presentation.save("activex.pptm", slides.export.SaveFormat.PPTM)
```

## **एक ActiveX नियंत्रण तक पहुँचें**
स्लाइड पर पहले ActiveX नियंत्रण से जानकारी पढ़ें.

```py
def access_activex():
    with slides.Presentation("activex.pptm") as presentation:
        slide = presentation.slides[0]

        # पहले ActiveX नियंत्रण तक पहुँचें।
        control = slide.controls[0] if slide.controls else None
        if control is not None:
            # नियंत्रण का नाम प्रिंट करें।
            print(f"Control Name: {control.name}")
```

## **ActiveX नियंत्रण हटाएँ**
स्लाइड से मौजूदा ActiveX नियंत्रण हटाएँ.

```py
def remove_activex():
    with slides.Presentation("activex.pptm") as presentation:
        slide = presentation.slides[0]

        if len(slide.controls) > 0:
            # पहला ActiveX नियंत्रण हटाएँ।
            slide.controls.remove_at(0)

        presentation.save("activex_removed.pptm", slides.export.SaveFormat.PPTM)
```

## **ActiveX गुण सेट करें**
कई ActiveX गुणों को कॉन्फ़िगर करें.

```py
def set_activex_properties():
    with slides.Presentation("activex.pptm") as presentation:
        slide = presentation.slides[0]

        # मान लीजिए कि Control संग्रह में कम से कम एक Control है।
        control = slide.controls[0]

        control.properties.add("Caption", "Click Me")
        control.properties.add("Enabled", "true")

        presentation.save("activex_properties.pptm", slides.export.SaveFormat.PPTM)
```