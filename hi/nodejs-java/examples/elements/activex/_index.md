---
title: ActiveX
type: docs
weight: 200
url: /hi/nodejs-java/examples/elements/activex/
keywords:
- कोड उदाहरण
- ActiveX
- PowerPoint
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js ActiveX उदाहरण देखें: PPT और PPTX प्रस्तुतियों में ActiveX ऑब्जेक्ट्स को सम्मिलित करने, कॉन्फ़िगर करने और नियंत्रित करने के लिए स्पष्ट JavaScript कोड।"
---
यह लेख प्रस्तुति में **Aspose.Slides for Node.js via Java** का उपयोग करके ActiveX नियंत्रणों को जोड़ने, एक्सेस करने, हटाने और कॉन्फ़िगर करने का प्रदर्शन करता है।

## **एक ActiveX नियंत्रण जोड़ें**

स्लाइड में एक नया ActiveX नियंत्रण जोड़ें।

```js
function addActiveX() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        // एक नया ActiveX नियंत्रण जोड़ें।
        let control = slide.getControls().addControl(aspose.slides.ControlType.WindowsMediaPlayer, 50, 50, 100, 50);

        presentation.save("activex.pptm", aspose.slides.SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```

## **एक ActiveX नियंत्रण तक पहुँचें**

स्लाइड पर पहली ActiveX नियंत्रण से जानकारी पढ़ें।

```js
function accessActiveX() {
    let presentation = new aspose.slides.Presentation("activex.pptm");
    try {
        let slide = presentation.getSlides().get_Item(0);

        if (slide.getControls().size() > 0) {
            // पहले ActiveX नियंत्रण तक पहुँचें।
            let control = slide.getControls().get_Item(0);

            console.log("Control Name:", control.getName());
            console.log("Value:", control.getProperties().get_Item("Value"));
        }
    } finally {
        presentation.dispose();
    }
}
```

## **एक ActiveX नियंत्रण हटाएँ**

स्लाइड से मौजूदा ActiveX नियंत्रण को हटाएँ।

```js
function removeActiveX() {
    let presentation = new aspose.slides.Presentation("activex.pptm");
    try {
        let slide = presentation.getSlides().get_Item(0);

        if (slide.getControls().size() > 0) {
            // पहला ActiveX नियंत्रण हटाएँ।
            slide.getControls().removeAt(0);
        }

        presentation.save("activex_removed.pptm", aspose.slides.SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```

## **ActiveX गुण सेट करें**

कई ActiveX गुणों को कॉन्फ़िगर करें।

```js
function setActiveXProperties() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        if (slide.getControls().size() > 0) {
            let control = slide.getControls().get_Item(0);

            control.getProperties().set_Item("Caption", "Click Me");
            control.getProperties().set_Item("Enabled", "true");
        }

        presentation.save("activex_properties.pptm", aspose.slides.SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```