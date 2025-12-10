---
title: Appliquer ou modifier les mises en page des diapositives en Java
linktitle: Mise en page des diapositives
type: docs
weight: 60
url: /fr/java/slide-layout/
keywords:
- mise en page des diapositives
- mise en page du contenu
- espace réservé
- conception de présentation
- conception de diapositive
- mise en page inutilisée
- visibilité du pied de page
- diapositive de titre
- titre et contenu
- en-tête de section
- deux contenus
- comparaison
- titre seul
- mise en page vierge
- contenu avec légende
- image avec légende
- titre et texte vertical
- titre vertical et texte
- PowerPoint
- OpenDocument
- présentation
- Java
- Aspose.Slides
description: "Gérez et personnalisez les mises en page des diapositives dans Aspose.Slides pour Java. Explorez les types de mise en page, le contrôle des espaces réservés et la visibilité du pied de page à l'aide d'exemples de code Java."
---

## **Vue d’ensemble**

Un modèle de diapositive définit la disposition des zones réservées et le formatage du contenu d’une diapositive. Il contrôle quelles zones réservées sont disponibles et où elles apparaissent. Les modèles de diapositives vous aident à créer des présentations rapidement et de manière cohérente, que vous réalisiez quelque chose de simple ou de plus complexe. Parmi les modèles de diapositives les plus courants dans PowerPoint, on trouve :

**Modèle de diapositive Titre** – comprend deux zones réservées de texte : une pour le titre et une pour le sous‑titre.

**Modèle Titre et Contenu** – possède une petite zone réservée de titre en haut et une plus grande en dessous pour le contenu principal (texte, puces, graphiques, images, etc.).

**Modèle Vide** – ne contient aucune zone réservée, vous donnant le plein contrôle pour concevoir la diapositive à partir de zéro.

Les modèles de diapositives font partie d’un masque de diapositive, qui est la diapositive de niveau supérieur définissant les styles de disposition pour la présentation. Vous pouvez accéder aux modèles et les modifier via le masque de diapositive—soit par type, nom ou ID unique. Vous pouvez également modifier directement un modèle de diapositive spécifique dans la présentation.

Pour travailler avec les modèles de diapositives dans Aspose.Slides for Java, vous pouvez utiliser :

- Des méthodes telles que [getLayoutSlides](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getLayoutSlides--) et [getMasters](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getMasters--) de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/)
- Des types comme [ILayoutSlide](https://reference.aspose.com/slides/java/com.aspose.slides/ilayoutslide/), [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/imasterlayoutslidecollection/), [ILayoutPlaceholderManager](https://reference.aspose.com/slides/java/com.aspose.slides/ilayoutplaceholdermanager/) et [ILayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/java/com.aspose.slides/ilayoutslideheaderfootermanager/)

{{% alert title="Info" color="info" %}}
Pour en savoir plus sur la gestion des masques de diapositives, consultez l’article [Slide Master](/slides/fr/java/slide-master/).
{{% /alert %}}

## **Ajouter des modèles de diapositives aux présentations**

Pour personnaliser l’apparence et la structure de vos diapositives, il peut être nécessaire d’ajouter de nouveaux modèles de diapositives à une présentation. Aspose.Slides for Java vous permet de vérifier si un modèle spécifique existe déjà, d’en ajouter un nouveau si besoin, puis de l’utiliser pour insérer des diapositives basées sur ce modèle.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
1. Accédez à la collection [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/imasterlayoutslidecollection/).
1. Vérifiez si le modèle de diapositive souhaité existe déjà dans la collection. S’il n’existe pas, ajoutez le modèle nécessaire.
1. Ajoutez une diapositive vide basée sur le nouveau modèle.
1. Enregistrez la présentation.

Le code Java suivant montre comment ajouter un modèle de diapositive à une présentation PowerPoint :
```java
// Instancier la classe Presentation qui représente un fichier PowerPoint.
Presentation presentation = new Presentation("Sample.pptx");
try {
    // Parcourir les types de diapositives de mise en page pour sélectionner une diapositive de mise en page.
    IMasterLayoutSlideCollection layoutSlides = presentation.getMasters().get_Item(0).getLayoutSlides();
    ILayoutSlide layoutSlide = null;
    if (layoutSlides.getByType(SlideLayoutType.TitleAndObject) != null)
        layoutSlide = layoutSlides.getByType(SlideLayoutType.TitleAndObject);
    else
        layoutSlide = layoutSlides.getByType(SlideLayoutType.Title);

    if (layoutSlide == null) {
        // Situation où la présentation ne contient pas tous les types de mise en page.
        // Le fichier de présentation ne contient que les types de mise en page Blank et Custom.
        // Cependant, les diapositives de mise en page avec des types personnalisés peuvent avoir des noms reconnaissables,
        // comme "Title", "Title and Content", etc., qui peuvent être utilisés pour sélectionner une diapositive de mise en page.
        // Vous pouvez également vous baser sur un ensemble de types de formes réservées.
        // Par exemple, une diapositive Titre ne doit contenir que le type de zone réservée Title, etc.
        for (ILayoutSlide titleAndObjectLayoutSlide : layoutSlides) {
            if (titleAndObjectLayoutSlide.getName().equals("Title and Object")) {
                layoutSlide = titleAndObjectLayoutSlide;
                break;
            }
        }

        if (layoutSlide == null) {
            for (ILayoutSlide titleLayoutSlide : layoutSlides) {
                if (titleLayoutSlide.getName().equals("Title")) {
                    layoutSlide = titleLayoutSlide;
                    break;
                }
            }

            if (layoutSlide == null) {
                layoutSlide = layoutSlides.getByType(SlideLayoutType.Blank);
                if (layoutSlide == null) {
                    layoutSlide = layoutSlides.add(SlideLayoutType.TitleAndObject, "Title and Object");
                }
            }
        }
    }

    // Ajouter une diapositive vide en utilisant la diapositive de mise en page ajoutée.
    presentation.getSlides().insertEmptySlide(0, layoutSlide);

    // Enregistrer la présentation sur le disque.
    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **Supprimer les modèles de diapositives inutilisés**

Aspose.Slides propose la méthode [removeUnusedLayoutSlides](https://reference.aspose.com/slides/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) de la classe [Compress](https://reference.aspose.com/slides/java/com.aspose.slides/compress/) pour supprimer les modèles de diapositives indésirables et non utilisés.

Le code Java suivant montre comment supprimer un modèle de diapositive d’une présentation PowerPoint :
```java
Presentation presentation = new Presentation("Presentation.pptx");
try {
    Compress.removeUnusedLayoutSlides(presentation);

    presentation.save("Output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **Ajouter des zones réservées aux modèles de diapositives**

Aspose.Slides fournit la méthode [ILayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/java/com.aspose.slides/ilayoutslide/#getPlaceholderManager--) qui permet d’ajouter de nouvelles zones réservées à un modèle de diapositive.

Ce gestionnaire propose des méthodes pour les types de zones réservées suivants :

| Espace réservé PowerPoint            | Méthode de [ILayoutPlaceholderManager](https://reference.aspose.com/slides/java/com.aspose.slides/ilayoutplaceholdermanager/) |
| ------------------------------------ | ------------------------------------------------------------------------------------------------------------ |
| ![Content](content.png)              | addContentPlaceholder(float x, float y, float width, float height)                                        |
| ![Content (Vertical)](contentV.png) | addVerticalContentPlaceholder(float x, float y, float width, float height)                               |
| ![Text](text.png)                    | addTextPlaceholder(float x, float y, float width, float height)                                           |
| ![Text (Vertical)](textV.png)        | addVerticalTextPlaceholder(float x, float y, float width, float height)                                  |
| ![Picture](picture.png)              | addPicturePlaceholder(float x, float y, float width, float height)                                        |
| ![Chart](chart.png)                  | addChartPlaceholder(float x, float y, float width, float height)                                          |
| ![Table](table.png)                  | addTablePlaceholder(float x, float y, float width, float height)                                          |
| ![SmartArt](smartart.png)            | addSmartArtPlaceholder(float x, float y, float width, float height)                                       |
| ![Media](media.png)                  | addMediaPlaceholder(float x, float y, float width, float height)                                          |
| ![Online Image](onlineimage.png)     | addOnlineImagePlaceholder(float x, float y, float width, float height)                                   |

Le code Java suivant montre comment ajouter de nouvelles formes de zones réservées au modèle de diapositive Vide :
```java
Presentation presentation = new Presentation();
try {
    // Obtenir la diapositive de mise en page vierge.
    ILayoutSlide layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);

    // Obtenir le gestionnaire de zones réservées de la diapositive de mise en page.
    ILayoutPlaceholderManager placeholderManager = layout.getPlaceholderManager();

    // Ajouter différentes zones réservées à la diapositive de mise en page vierge.
    placeholderManager.addContentPlaceholder(20, 20, 310, 270);
    placeholderManager.addVerticalTextPlaceholder(350, 20, 350, 270);
    placeholderManager.addChartPlaceholder(20, 310, 310, 180);
    placeholderManager.addTablePlaceholder(350, 310, 350, 180);

    // Ajouter une nouvelle diapositive avec la mise en page vierge.
    ISlide newSlide = presentation.getSlides().addEmptySlide(layout);

    presentation.save("Placeholders.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


Résultat :

![The placeholders on the layout slide](add_placeholders.png)

## **Définir la visibilité du pied de page pour un modèle de diapositive**

Dans les présentations PowerPoint, les éléments de pied de page tels que la date, le numéro de diapositive et le texte personnalisé peuvent être affichés ou masqués selon le modèle de diapositive. Aspose.Slides for Java vous permet de contrôler la visibilité de ces zones réservées de pied de page. Cela est utile lorsque vous souhaitez que certains modèles affichent les informations de pied de page tandis que d’autres restent épurés.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
1. Obtenez une référence au modèle de diapositive par son index.
1. Définissez la zone réservée du pied de page de la diapositive comme visible.
1. Définissez la zone réservée du numéro de diapositive comme visible.
1. Définissez la zone réservée de la date‑heure comme visible.
1. Enregistrez la présentation.

Le code Java suivant montre comment définir la visibilité du pied de page d’une diapositive et réaliser les opérations associées :
```java
Presentation presentation = new Presentation("Presentation.ppt");
try {
    ILayoutSlideHeaderFooterManager headerFooterManager = presentation.getLayoutSlides().get_Item(0).getHeaderFooterManager();

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

    presentation.save("Presentation.ppt", SaveFormat.Ppt);
} finally {
    presentation.dispose();
}
```


## **Définir la visibilité du pied de page enfant pour une diapositive**

Dans les présentations PowerPoint, les éléments de pied de page tels que la date, le numéro de diapositive et le texte personnalisé peuvent être contrôlés au niveau du masque de diapositive afin d’assurer la cohérence sur tous les modèles de diapositives. Aspose.Slides for Java vous permet de définir la visibilité et le contenu de ces zones réservées de pied de page sur le masque et de propager ces paramètres à tous les modèles enfants. Cette approche garantit des informations de pied de page uniformes partout dans votre présentation.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
1. Obtenez une référence au masque de diapositive par son index.
1. Définissez les zones réservées du pied de page du masque et de tous les modèles enfants comme visibles.
1. Définissez les zones réservées du numéro de diapositive du masque et de tous les modèles enfants comme visibles.
1. Définissez les zones réservées de la date‑heure du masque et de tous les modèles enfants comme visibles.
1. Enregistrez la présentation.

Le code Java suivant illustre cette opération :
```java
Presentation presentation = new Presentation("Presentation.ppt");
try {
    IMasterSlideHeaderFooterManager headerFooterManager = presentation.getMasters().get_Item(0).getHeaderFooterManager();

    headerFooterManager.setFooterAndChildFootersVisibility(true);
    headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);
    headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);

    headerFooterManager.setFooterAndChildFootersText("Footer text");
    headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");

    presentation.save("Output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **FAQ**

**Quelle est la différence entre un masque de diapositive et un modèle de diapositive ?**

Un masque de diapositive définit le thème global et le formatage par défaut, tandis que les modèles de diapositives définissent des agencements spécifiques de zones réservées pour différents types de contenu.

**Puis‑je copier un modèle de diapositive d’une présentation à une autre ?**

Oui, vous pouvez cloner un modèle de diapositive depuis la collection de modèles d’une présentation, accessible via la méthode [getLayoutSlides](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getLayoutSlides--), puis l’insérer dans une autre présentation à l’aide de la méthode `addClone`.

**Que se passe‑t‑il si je supprime un modèle de diapositive encore utilisé par une diapositive ?**

Si vous tentez de supprimer un modèle de diapositive qui est toujours référencé par au moins une diapositive de la présentation, Aspose.Slides lèvera une [PptxEditException](https://reference.aspose.com/slides/java/com.aspose.slides/pptxeditexception/). Pour éviter cela, utilisez [removeUnusedLayoutSlides](https://reference.aspose.com/slides/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) qui supprime en toute sécurité uniquement les modèles de diapositives non utilisés.