---
title: En-tête et pied de page
type: docs
weight: 220
url: /fr/nodejs-java/examples/elements/header-footer/
keywords:
- exemple de code
- en-tête
- pied de page
- PowerPoint
- OpenDocument
- présentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Contrôlez les en-têtes et pieds de page des diapositives avec Aspose.Slides pour Node.js : ajoutez des dates, des numéros de diapositive et du texte personnalisé dans PPT, PPTX et ODP avec des exemples JavaScript."
---
Cet article montre comment ajouter des pieds de page et mettre à jour les espaces réservés de date et d'heure en utilisant **Aspose.Slides for Node.js via Java**.

## **Ajouter un pied de page**
Ajoutez du texte à la zone de pied de page d'une diapositive et rendez-le visible.

```js
function addHeaderFooter() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        slide.getHeaderFooterManager().setFooterText("My footer");
        slide.getHeaderFooterManager().setFooterVisibility(true);

        presentation.save("header_footer.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Mettre à jour la date et l'heure**
Modifiez l'espace réservé de date et d'heure sur une diapositive.

```js
function updateDateTime() {
    let presentation = new aspose.slides.Presentation("header_footer.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        slide.getHeaderFooterManager().setDateTimeText("01/01/2024");
        slide.getHeaderFooterManager().setDateTimeVisibility(true);

        presentation.save("header_footer_updated.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```