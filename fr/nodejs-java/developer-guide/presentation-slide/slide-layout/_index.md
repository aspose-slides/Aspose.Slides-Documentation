---
title: Appliquer ou modifier une mise en page de diapositive en JavaScript
linktitle: Mise en page de diapositive
type: docs
weight: 60
url: /fr/nodejs-java/slide-layout/
keywords:
- mise en page de diapositive
- mise en page de contenu
- espace réservé
- conception de présentation
- conception de diapositive
- mise en page inutilisée
- visibilité du pied de page
- diapositive titre
- titre et contenu
- en-tête de section
- deux contenus
- comparaison
- titre uniquement
- mise en page vierge
- contenu avec légende
- image avec légende
- titre et texte vertical
- titre vertical et texte
- Node.js
- JavaScript
- Aspose.Slides
description: "Apprenez à gérer et personnaliser les mises en page de diapositives dans Aspose.Slides pour Node.js. Découvrez les types de mise en page, le contrôle des espaces réservés, la visibilité du pied de page et la manipulation des mises en page à l'aide d'exemples de code en JavaScript."
---

## **Vue d’ensemble**

Une mise en page de diapositive définit l’arrangement des zones réservées et le formatage du contenu d’une diapositive. Elle contrôle quelles zones réservées sont disponibles et où elles apparaissent. Les mises en page de diapositives vous aident à créer des présentations rapidement et de façon cohérente—que vous conceviez quelque chose de simple ou de plus complexe. Parmi les mises en page les plus courantes dans PowerPoint figurent :

**Mise en page Diapositive de titre** – Comprend deux zones réservées de texte : une pour le titre et une pour le sous-titre.

**Mise en page Titre et contenu** – Propose une petite zone réservée de titre en haut et une plus grande en dessous pour le contenu principal (texte, puces, graphiques, images, etc.).

**Mise en page Vide** – Ne contient aucune zone réservée, vous donnant le contrôle total pour concevoir la diapositive à partir de zéro.

Les mises en page de diapositives font partie d’un masque de diapositive, qui est la diapositive de niveau supérieur définissant les styles de mise en page pour la présentation. Vous pouvez accéder aux diapositives de mise en page et les modifier via le masque de diapositive—soit par type, nom ou ID unique. Vous pouvez également modifier directement une mise en page spécifique au sein de la présentation.

Pour travailler avec les mises en page de diapositives dans Aspose.Slides for Node.js, vous pouvez utiliser :

- Des méthodes telles que [getLayoutSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getLayoutSlides) et [getMasters](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getMasters) de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/)
- Des types comme [LayoutSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/layoutslide/), [MasterLayoutSlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterlayoutslidecollection/), [LayoutPlaceholderManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/layoutplaceholdermanager/) et [LayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/layoutslideheaderfootermanager/)

{{% alert title="Info" color="info" %}}

Pour en savoir plus sur la gestion des masques de diapositives, consultez l’article [Slide Master](/slides/fr/nodejs-java/slide-master/).

{{% /alert %}}

## **Ajouter des mises en page de diapositives aux présentations**

Pour personnaliser l’apparence et la structure de vos diapositives, il peut être nécessaire d’ajouter de nouvelles diapositives de mise en page à une présentation. Aspose.Slides for Node.js vous permet de vérifier si une mise en page spécifique existe déjà, d’en ajouter une nouvelle si besoin, puis de l’utiliser pour insérer des diapositives basées sur cette mise en page.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
1. Accédez à la [MasterLayoutSlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterlayoutslidecollection/).
1. Vérifiez si la diapositive de mise en page souhaitée existe déjà dans la collection. Sinon, ajoutez la mise en page dont vous avez besoin.
1. Ajoutez une diapositive vide basée sur la nouvelle mise en page.
1. Enregistrez la présentation.

Le code JavaScript suivant montre comment ajouter une mise en page de diapositive à une présentation PowerPoint :
```js
// Instancier la classe Presentation qui représente un fichier PowerPoint.
let presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    // Parcourir les types de diapositives de mise en page pour sélectionner une diapositive de mise en page.
    let layoutSlides = presentation.getMasters().get_Item(0).getLayoutSlides();
    let layoutSlide = null;
    if (layoutSlides.getByType(java.newByte(aspose.slides.SlideLayoutType.TitleAndObject)) != null) {
        layoutSlide = layoutSlides.getByType(java.newByte(aspose.slides.SlideLayoutType.TitleAndObject));
    } else {
        layoutSlide = layoutSlides.getByType(java.newByte(aspose.slides.SlideLayoutType.Title));
    }

    if (layoutSlide == null) {
        // Situation où la présentation ne contient pas tous les types de mise en page.
        // Le fichier de présentation ne contient que les types de mise en page Blank et Custom.
        // Cependant, les diapositives de mise en page avec des types personnalisés peuvent avoir des noms reconnaissables,
        // comme "Title", "Title and Content", etc., qui peuvent être utilisés pour la sélection de la diapositive de mise en page.
        // Vous pouvez également vous appuyer sur un ensemble de types de formes d'espace réservé.
        // Par exemple, une diapositive Title doit contenir uniquement le type d'espace réservé Title, etc.
        for (let i = 0; i < layoutSlides.size(); i++) {
            let titleAndObjectLayoutSlide = layoutSlides.get_Item(i);
            if (titleAndObjectLayoutSlide.getName() === "Title and Object") {
                layoutSlide = titleAndObjectLayoutSlide;
                break;
            }
        }

        if (layoutSlide == null) {
            for (let i = 0; i < layoutSlides.size(); i++) {
                let titleLayoutSlide = layoutSlides.get_Item(i);
                if (titleLayoutSlide.getName() === "Title") {
                    layoutSlide = titleLayoutSlide;
                    break;
                }
            }

            if (layoutSlide == null) {
                layoutSlide = layoutSlides.getByType(java.newByte(aspose.slides.SlideLayoutType.Blank));
                if (layoutSlide == null) {
                    layoutSlide = layoutSlides.add(java.newByte(aspose.slides.SlideLayoutType.TitleAndObject), "Title and Object");
                }
            }
        }
    }

    // Ajouter une diapositive vide en utilisant la diapositive de mise en page ajoutée.
    presentation.getSlides().insertEmptySlide(0, layoutSlide);

    // Enregistrer la présentation sur le disque.
    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **Supprimer les mises en page de diapositives inutilisées**

Aspose.Slides fournit la méthode [removeUnusedLayoutSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides) de la classe [Compress](https://reference.aspose.com/slides/nodejs-java/aspose.slides/compress/) pour vous permettre de supprimer les mises en page de diapositives indésirables et non utilisées.

Le code JavaScript suivant montre comment supprimer une mise en page de diapositive d’une présentation PowerPoint :
```js
let presentation = new aspose.slides.Presentation("Presentation.pptx");
try {
    aspose.slides.Compress.removeUnusedLayoutSlides(presentation);
    presentation.save("Output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **Ajouter des zones réservées aux mises en page de diapositives**

Aspose.Slides fournit la méthode [LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/layoutslide/#getPlaceholderManager), qui vous permet d’ajouter de nouvelles zones réservées à une diapositive de mise en page.

Ce gestionnaire contient des méthodes pour les types de zones réservées suivants :

| Zone réservée PowerPoint            | Méthode [LayoutPlaceholderManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/layoutplaceholdermanager/) |
| ----------------------------------- | ------------------------------------------------------------ |
| ![Content](content.png)             | addContentPlaceholder(float x, float y, float width, float height) |
| ![Content (Vertical)](contentV.png) | addVerticalContentPlaceholder(float x, float y, float width, float height) |
| ![Text](text.png)                   | addTextPlaceholder(float x, float y, float width, float height) |
| ![Text (Vertical)](textV.png)       | addVerticalTextPlaceholder(float x, float y, float width, float height) |
| ![Picture](picture.png)             | addPicturePlaceholder(float x, float y, float width, float height) |
| ![Chart](chart.png)                 | addChartPlaceholder(float x, float y, float width, float height) |
| ![Table](table.png)                 | addTablePlaceholder(float x, float y, float width, float height) |
| ![SmartArt](smartart.png)           | addSmartArtPlaceholder(float x, float y, float width, float height) |
| ![Media](media.png)                 | addMediaPlaceholder(float x, float y, float width, float height) |
| ![Online Image](onlineimage.png)    | addOnlineImagePlaceholder(float x, float y, float width, float height) |

Le code JavaScript suivant montre comment ajouter de nouvelles formes de zones réservées à la mise en page Vide :
```js
let presentation = new aspose.slides.Presentation();
try {
    // Récupérer la diapositive de mise en page vierge.
    let layout = presentation.getLayoutSlides().getByType(java.newByte(aspose.slides.SlideLayoutType.Blank));

    // Récupérer le gestionnaire de zones réservées de la diapositive de mise en page.
    let placeholderManager = layout.getPlaceholderManager();

    // Ajouter différentes zones réservées à la diapositive de mise en page vierge.
    placeholderManager.addContentPlaceholder(20, 20, 310, 270);
    placeholderManager.addVerticalTextPlaceholder(350, 20, 350, 270);
    placeholderManager.addChartPlaceholder(20, 310, 310, 180);
    placeholderManager.addTablePlaceholder(350, 310, 350, 180);

    // Ajouter une nouvelle diapositive avec la mise en page vierge.
    let newSlide = presentation.getSlides().addEmptySlide(layout);

    presentation.save("Placeholders.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


Le résultat :

![The placeholders on the layout slide](add_placeholders.png)

## **Définir la visibilité du pied de page pour une mise en page de diapositive**

Dans les présentations PowerPoint, les éléments de pied de page comme la date, le numéro de diapositive et le texte personnalisé peuvent être affichés ou masqués selon la mise en page de la diapositive. Aspose.Slides for Node.js vous permet de contrôler la visibilité de ces zones réservées de pied de page. Cela est utile lorsque vous souhaitez que certaines mises en page affichent les informations de pied de page tandis que d’autres restent épurées.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
1. Obtenez une référence à une mise en page de diapositive par son index.
1. Définissez la zone réservée du pied de page de la diapositive comme visible.
1. Définissez la zone réservée du numéro de diapositive comme visible.
1. Définissez la zone réservée de la date‑heure comme visible.
1. Enregistrez la présentation.

Le code JavaScript suivant montre comment définir la visibilité du pied de page d’une diapositive et effectuer les tâches associées :
```js
let presentation = new aspose.slides.Presentation("Presentation.ppt");
try {
    let headerFooterManager = presentation.getLayoutSlides().get_Item(0).getHeaderFooterManager();

    if (!headerFooterManager.isFooterVisible()) {
        headerFooterManager.setFooterVisibility(true);
    }

    if (!headerFooterManager.isSlideNumberVisible()) {
        headerFooterManager.setSlideNumberVisibility(true);
    }

    if (!headerFooterManager.isDateTimeVisible()) {
        headerFooterManager.setDateTimeVisibility(true);
    }

    headerFooterManager.setFooterText("Footer text");
    headerFooterManager.setDateTimeText("Date and time text");

    presentation.save("Presentation.ppt", aspose.slides.SaveFormat.Ppt);
} finally {
    presentation.dispose();
}
```


## **Définir la visibilité du pied de page enfant pour une diapositive**

​Dans les présentations PowerPoint, les éléments de pied de page tels que la date, le numéro de diapositive et le texte personnalisé peuvent être contrôlés au niveau du masque de diapositive pour garantir la cohérence sur l’ensemble des mises en page. Aspose.Slides for Node.js vous permet de définir la visibilité et le contenu de ces zones réservées de pied de page sur le masque maître et de propager ces paramètres à toutes les mises en page enfants. Cette approche assure une information de pied de page uniforme tout au long de votre présentation.​

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
1. Obtenez une référence au masque maître par son index.
1. Définissez les zones réservées du pied de page du maître et de tous les enfants comme visibles.
1. Définissez les zones réservées du numéro de diapositive du maître et de tous les enfants comme visibles.
1. Définissez les zones réservées de la date‑heure du maître et de tous les enfants comme visibles.
1. Enregistrez la présentation.

Le code JavaScript suivant démontre cette opération :
```js
let presentation = new aspose.slides.Presentation("Presentation.ppt");
try {
    let headerFooterManager = presentation.getMasters().get_Item(0).getHeaderFooterManager();

    headerFooterManager.setFooterAndChildFootersVisibility(true);
    headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);
    headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);

    headerFooterManager.setFooterAndChildFootersText("Footer text");
    headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");

    presentation.save("Output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **FAQ**

**Quelle est la différence entre un masque de diapositive et une mise en page de diapositive ?**

Un masque de diapositive définit le thème global et le formatage par défaut, tandis que les mises en page de diapositives définissent des agencements spécifiques de zones réservées pour différents types de contenu.

**Puis‑je copier une mise en page de diapositive d’une présentation à une autre ?**

Oui, vous pouvez cloner une mise en page de diapositive depuis la collection de mises en page d’une présentation, accessible via la méthode [getLayoutSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getLayoutSlides), puis l’insérer dans une autre présentation à l’aide de la méthode `addClone`.

**Que se passe‑t‑il si je supprime une mise en page de diapositive encore utilisée par une diapositive ?**

Si vous essayez de supprimer une mise en page de diapositive qui est encore référencée par au moins une diapositive de la présentation, Aspose.Slides lèvera une [PptxEditException](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pptxeditexception/). Pour éviter cela, utilisez [removeUnusedLayoutSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides) qui supprime en toute sécurité uniquement les mises en page non utilisées.