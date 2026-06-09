---
title: ActiveX
type: docs
weight: 200
url: /tr/nodejs-java/examples/elements/activex/
keywords:
- kod örneği
- ActiveX
- PowerPoint
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js ActiveX örneklerine bakın: PPT ve PPTX sunumlarında ActiveX nesnelerini ekleme, yapılandırma ve kontrol etme, net JavaScript kodu ile."
---
Bu makale, **Aspose.Slides for Node.js via Java** kullanarak bir sunumda ActiveX denetimlerini ekleme, erişme, kaldırma ve yapılandırma işlemlerini göstermektedir.

## **ActiveX Denetimi Ekle**

Bir slayta yeni bir ActiveX denetimi ekleyin.

```js
function addActiveX() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Yeni bir ActiveX denetimi ekleyin.
        let control = slide.getControls().addControl(aspose.slides.ControlType.WindowsMediaPlayer, 50, 50, 100, 50);

        presentation.save("activex.pptm", aspose.slides.SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```

## **ActiveX Denetimine Erişme**

Slayttaki ilk ActiveX denetiminden bilgi okuyun.

```js
function accessActiveX() {
    let presentation = new aspose.slides.Presentation("activex.pptm");
    try {
        let slide = presentation.getSlides().get_Item(0);

        if (slide.getControls().size() > 0) {
            // İlk ActiveX denetimine erişin.
            let control = slide.getControls().get_Item(0);

            console.log("Control Name:", control.getName());
            console.log("Value:", control.getProperties().get_Item("Value"));
        }
    } finally {
        presentation.dispose();
    }
}
```

## **ActiveX Denetimini Kaldırma**

Slayttan mevcut bir ActiveX denetimini silin.

```js
function removeActiveX() {
    let presentation = new aspose.slides.Presentation("activex.pptm");
    try {
        let slide = presentation.getSlides().get_Item(0);

        if (slide.getControls().size() > 0) {
            // İlk ActiveX denetimini kaldır.
            slide.getControls().removeAt(0);
        }

        presentation.save("activex_removed.pptm", aspose.slides.SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```

## **ActiveX Özelliklerini Ayarlama**

Birçok ActiveX özelliğini yapılandırın.

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