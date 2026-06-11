---
title: ActiveX
type: docs
weight: 200
url: /pl/nodejs-java/examples/elements/activex/
keywords:
- przykład kodu
- ActiveX
- PowerPoint
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Zobacz przykłady ActiveX w Aspose.Slides for Node.js: wstawianie, konfigurowanie i kontrolowanie obiektów ActiveX w prezentacjach PPT i PPTX przy użyciu przejrzystego kodu JavaScript."
---
Ten artykuł demonstruje, jak dodać, uzyskać dostęp, usunąć i skonfigurować kontrolki ActiveX w prezentacji przy użyciu **Aspose.Slides for Node.js via Java**.

## **Dodaj kontrolkę ActiveX**

Dodaj nową kontrolkę ActiveX do slajdu.

```js
function addActiveX() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Dodaj nową kontrolkę ActiveX.
        let control = slide.getControls().addControl(aspose.slides.ControlType.WindowsMediaPlayer, 50, 50, 100, 50);

        presentation.save("activex.pptm", aspose.slides.SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```

## **Uzyskaj dostęp do kontrolki ActiveX**

Odczytaj informacje z pierwszej kontrolki ActiveX na slajdzie.

```js
function accessActiveX() {
    let presentation = new aspose.slides.Presentation("activex.pptm");
    try {
        let slide = presentation.getSlides().get_Item(0);

        if (slide.getControls().size() > 0) {
            // Uzyskaj dostęp do pierwszej kontrolki ActiveX.
            let control = slide.getControls().get_Item(0);

            console.log("Control Name:", control.getName());
            console.log("Value:", control.getProperties().get_Item("Value"));
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Usuń kontrolkę ActiveX**

Usuń istniejącą kontrolkę ActiveX ze slajdu.

```js
function removeActiveX() {
    let presentation = new aspose.slides.Presentation("activex.pptm");
    try {
        let slide = presentation.getSlides().get_Item(0);

        if (slide.getControls().size() > 0) {
            // Usuń pierwszą kontrolkę ActiveX.
            slide.getControls().removeAt(0);
        }

        presentation.save("activex_removed.pptm", aspose.slides.SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```

## **Ustaw właściwości ActiveX**

Skonfiguruj kilka właściwości ActiveX.

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