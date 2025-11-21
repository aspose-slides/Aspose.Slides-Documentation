---
title: Gérer l'espace réservé
type: docs
weight: 10
url: /fr/nodejs-java/manage-placeholder/
description: Modifier le texte dans un espace réservé dans les diapositives PowerPoint en utilisant JavaScript. Définir le texte d'invite dans un espace réservé dans les diapositives PowerPoint en utilisant JavaScript.
---

## **Modifier le texte dans un espace réservé**

En utilisant [Aspose.Slides for Node.js via Java](/slides/fr/nodejs-java/), vous pouvez rechercher et modifier les espaces réservés sur les diapositives des présentations. Aspose.Slides vous permet de modifier le texte d’un espace réservé.

**Pré-requis**: Vous avez besoin d’une présentation contenant un espace réservé. Vous pouvez créer une telle présentation avec l'application Microsoft PowerPoint standard.

Voici comment utiliser Aspose.Slides pour remplacer le texte dans l’espace réservé de cette présentation :

1. Instanciez la classe [`Presentation`](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) et transmettez la présentation en argument.
2. Obtenez une référence de diapositive via son index.
3. Parcourez les formes pour trouver l’espace réservé.
4. Convertissez le type de la forme d’espace réservé en [`AutoShape`](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape) et modifiez le texte à l'aide du [`TextFrame`](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame) associé à l'[`AutoShape`](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape).
5. Enregistrez la présentation modifiée.

Ce code JavaScript montre comment modifier le texte dans un espace réservé :
```javascript
// Instancie une classe Presentation
var pres = new aspose.slides.Presentation("ReplacingText.pptx");
try {
    // Accède à la première diapositive
    var sld = pres.getSlides().get_Item(0);
    // Itère sur les formes pour trouver l'espace réservé
    for (let i = 0; i < sld.getShapes().size(); i++) {
        let shp = sld.getShapes().get_Item(i);
        if (shp.getPlaceholder() != null) {
            // Modifie le texte de chaque espace réservé
            shp.getTextFrame().setText("This is Placeholder");
        }
    }
    // Enregistre la présentation sur le disque
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Définir le texte d’invite dans un espace réservé**

Les mises en page standard et prêtes à l’emploi contiennent des textes d’invite d’espace réservé tels que ***Cliquez pour ajouter un titre*** ou ***Cliquez pour ajouter un sous-titre***. En utilisant Aspose.Slides, vous pouvez insérer vos propres textes d’invite dans les mises en page d'espace réservé.

Ce code JavaScript vous montre comment définir le texte d’invite dans un espace réservé :
```javascript
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    // Parcourt la diapositive
    for (let i = 0; i < slide.getSlide().getShapes().size(); i++) {
        let shape = slide.getSlide().getShapes().get_Item(i);
        if ((shape.getPlaceholder() != null) && (java.instanceOf(shape, "com.aspose.slides.AutoShape"))) {
            var text = "";
            // PowerPoint affiche "Click to add title"
            if (shape.getPlaceholder().getType() == aspose.slides.PlaceholderType.CenteredTitle) {
                text = "Add Title";
            } else // Ajoute le sous-titre
            if (shape.getPlaceholder().getType() == aspose.slides.PlaceholderType.Subtitle) {
                text = "Add Subtitle";
            }
            shape.getTextFrame().setText(text);
            console.log("Placeholder with text: " + text);
        }
    }
    pres.save("Placeholders_PromptText.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Définir la transparence de l’image d’espace réservé**

Aspose.Slides vous permet de définir la transparence de l’image d’arrière-plan dans un espace réservé de texte. En ajustant la transparence de l’image dans ce cadre, vous pouvez faire ressortir le texte ou l’image (selon les couleurs du texte et de l’image).

Ce code JavaScript vous montre comment définir la transparence d’un arrière-plan d’image (à l’intérieur d’une forme) :
```javascript
var presentation = new aspose.slides.Presentation("example.pptx");
var shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
var operationCollection = shape.getFillFormat().getPictureFillFormat().getPicture().getImageTransform();
for (var i = 0; i < operationCollection.size(); i++) {
    if (java.instanceOf(operationCollection.get_Item(i), "com.aspose.slides.AlphaModulateFixed")) {
        var alphaModulate = operationCollection.get_Item(i);
        var currentValue = 100 - alphaModulate.getAmount();
        console.log("Current transparency value: " + currentValue);
        var alphaValue = 40;
        alphaModulate.setAmount(100 - alphaValue);
    }
}
presentation.save("example_out.pptx", aspose.slides.SaveFormat.Pptx);
```


## **FAQ**

**Qu’est‑ce qu’un espace réservé de base, et en quoi diffère‑t‑il d’une forme locale sur une diapositive ?**

Un espace réservé de base est la forme originale sur une mise en page ou un maître dont la forme de la diapositive hérite -- le type, la position et certains formats en proviennent. Une forme locale est indépendante ; s'il n'existe pas d'espace réservé de base, l'héritage ne s'applique pas.

**Comment puis‑je mettre à jour tous les titres ou légendes d’une présentation sans parcourir chaque diapositive ?**

Modifiez l'espace réservé correspondant sur la mise en page ou le maître. Les diapositives basées sur ces mises en page ou ce maître hériteront automatiquement du changement.

**Comment contrôler les espaces réservés d'en‑tête/pied de page standard -- date & heure, numéro de diapositive et texte du pied de page ?**

Utilisez les gestionnaires HeaderFooter au niveau approprié (diapositives normales, mises en page, maître, notes / supports) pour activer ou désactiver ces espaces réservés et définir leur contenu.