---
title: Hyperlien
type: docs
weight: 130
url: /fr/nodejs-java/examples/elements/hyperlink/
keywords:
- exemple de code
- hyperlien
- PowerPoint
- OpenDocument
- présentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Ajoutez et gérez les hyperliens dans Aspose.Slides pour Node.js: texte du lien, formes et images, définissez les cibles et les actions pour PPT, PPTX et ODP avec des exemples."
---
Cet article montre comment ajouter, accéder, supprimer et mettre à jour les hyperliens sur des formes en utilisant **Aspose.Slides for Node.js via Java**.

## **Ajouter un hyperlien**

Créez une forme rectangulaire avec un hyperlien pointant vers un site Web externe.

```js
function addHyperlink() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 50);
        shape.getTextFrame().setText("Aspose");

        let paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
        let textPortion = paragraph.getPortions().get_Item(0);

        let hyperlink = new aspose.slides.Hyperlink("https://www.aspose.com");
        textPortion.getPortionFormat().setHyperlinkClick(hyperlink);

        presentation.save("hyperlink.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Accéder à un hyperlien**

Lisez l'hyperlien à partir de la portion de texte d'une forme.

```js
function accessHyperlink() {
    let presentation = new aspose.slides.Presentation("hyperlink.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // En supposant que la première forme contient le texte avec un hyperlien.
        let shape = slide.getShapes().get_Item(0);

        let paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
        let textPortion = paragraph.getPortions().get_Item(0);

        let hyperlink = textPortion.getPortionFormat().getHyperlinkClick();
    } finally {
        presentation.dispose();
    }
}
```

## **Supprimer un hyperlien**

Supprimez l'hyperlien du texte d'une forme.

```js
function removeHyperlink() {
    let presentation = new aspose.slides.Presentation("hyperlink.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // En supposant que la première forme contient le texte avec un hyperlien.
        let shape = slide.getShapes().get_Item(0);

        let paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
        let textPortion = paragraph.getPortions().get_Item(0);

        textPortion.getPortionFormat().setHyperlinkClick(null);

        presentation.save("hyperlink_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Mettre à jour un hyperlien**

Modifiez la cible d'un hyperlien existant. Utilisez `HyperlinkManager` pour modifier le texte qui contient déjà un hyperlien, ce qui imite la façon dont PowerPoint met à jour les hyperliens en toute sécurité.

```js
function updateHyperlink() {
    let presentation = new aspose.slides.Presentation("hyperlink.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // En supposant que la première forme contient le texte avec un hyperlien.
        let shape = slide.getShapes().get_Item(0);

        let paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
        let textPortion = paragraph.getPortions().get_Item(0);

        // Modifier un hyperlien dans du texte existant doit être fait via
        // HyperlinkManager plutôt que de définir directement la propriété.
        // Cela imite la façon dont PowerPoint met à jour les hyperliens en toute sécurité.
        textPortion.getPortionFormat().getHyperlinkManager().setExternalHyperlinkClick("https://new.example.com");

        presentation.save("hyperlink_updated.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```