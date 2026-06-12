---
title: ActiveX
type: docs
weight: 200
url: /cs/nodejs-java/examples/elements/activex/
keywords:
- příklad kódu
- ActiveX
- PowerPoint
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Viz příklady ActiveX pro Aspose.Slides for Node.js: vkládání, konfiguraci a řízení objektů ActiveX v prezentacích PPT a PPTX pomocí přehledného JavaScript kódu."
---
Tento článek ukazuje, jak přidávat, přistupovat, odstraňovat a konfigurovat ActiveX ovládací prvky v prezentaci pomocí **Aspose.Slides for Node.js via Java**.

## **Přidat ActiveX ovládací prvek**

Přidejte nový ActiveX ovládací prvek na snímek.

```js
function addActiveX() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Přidejte nový ActiveX ovládací prvek.
        let control = slide.getControls().addControl(aspose.slides.ControlType.WindowsMediaPlayer, 50, 50, 100, 50);

        presentation.save("activex.pptm", aspose.slides.SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```

## **Přístup k ActiveX ovládacímu prvku**

Přečtěte si informace z prvního ActiveX ovládacího prvku na snímku.

```js
function accessActiveX() {
    let presentation = new aspose.slides.Presentation("activex.pptm");
    try {
        let slide = presentation.getSlides().get_Item(0);

        if (slide.getControls().size() > 0) {
            // Přístup k prvnímu ActiveX ovládacímu prvku.
            let control = slide.getControls().get_Item(0);

            console.log("Control Name:", control.getName());
            console.log("Value:", control.getProperties().get_Item("Value"));
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Odstranit ActiveX ovládací prvek**

Odstraňte existující ActiveX ovládací prvek ze snímku.

```js
function removeActiveX() {
    let presentation = new aspose.slides.Presentation("activex.pptm");
    try {
        let slide = presentation.getSlides().get_Item(0);

        if (slide.getControls().size() > 0) {
            // Odstraňte první ActiveX ovládací prvek.
            slide.getControls().removeAt(0);
        }

        presentation.save("activex_removed.pptm", aspose.slides.SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```

## **Nastavit vlastnosti ActiveX**

Nakonfigurujte několik vlastností ActiveX.

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