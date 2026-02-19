---
title: ActiveX
type: docs
weight: 200
url: /fr/nodejs-java/examples/elements/activex/
keywords:
- exemple de code
- ActiveX
- PowerPoint
- présentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Voir les exemples ActiveX d'Aspose.Slides for Node.js : insérer, configurer et contrôler les objets ActiveX dans les présentations PPT et PPTX avec du code JavaScript clair."
---
Cet article montre comment ajouter, accéder, supprimer et configurer des contrôles ActiveX dans une présentation à l'aide de **Aspose.Slides for Node.js via Java**.

## **Ajouter un contrôle ActiveX**

Ajoutez un nouveau contrôle ActiveX à une diapositive.

```js
function addActiveX() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Ajouter un nouveau contrôle ActiveX.
        let control = slide.getControls().addControl(aspose.slides.ControlType.WindowsMediaPlayer, 50, 50, 100, 50);

        presentation.save("activex.pptm", aspose.slides.SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```

## **Accéder à un contrôle ActiveX**

Lisez les informations du premier contrôle ActiveX de la diapositive.

```js
function accessActiveX() {
    let presentation = new aspose.slides.Presentation("activex.pptm");
    try {
        let slide = presentation.getSlides().get_Item(0);

        if (slide.getControls().size() > 0) {
            // Accéder au premier contrôle ActiveX.
            let control = slide.getControls().get_Item(0);

            console.log("Control Name:", control.getName());
            console.log("Value:", control.getProperties().get_Item("Value"));
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Supprimer un contrôle ActiveX**

Supprimez un contrôle ActiveX existant de la diapositive.

```js
function removeActiveX() {
    let presentation = new aspose.slides.Presentation("activex.pptm");
    try {
        let slide = presentation.getSlides().get_Item(0);

        if (slide.getControls().size() > 0) {
            // Supprimer le premier contrôle ActiveX.
            slide.getControls().removeAt(0);
        }

        presentation.save("activex_removed.pptm", aspose.slides.SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```

## **Définir les propriétés ActiveX**

Configurez plusieurs propriétés ActiveX.

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