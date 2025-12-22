---
title: Appliquer ou modifier les dispositions de diapositive sur Android
linktitle: Disposition de diapositive
type: docs
weight: 60
url: /fr/androidjava/slide-layout/
keywords:
- disposition de diapositive
- disposition de contenu
- espace réservé
- conception de présentation
- conception de diapositive
- disposition inutilisée
- visibilité du pied de page
- diapositive titre
- titre et contenu
- en-tête de section
- deux contenus
- comparaison
- titre seul
- disposition vierge
- contenu avec légende
- image avec légende
- titre et texte vertical
- titre vertical et texte
- PowerPoint
- OpenDocument
- présentation
- Android
- Java
- Aspose.Slides
description: "Gérez et personnalisez les dispositions de diapositives dans Aspose.Slides pour Android. Explorez les types de disposition, le contrôle des espaces réservés et la visibilité du pied de page à l’aide d’exemples de code Java."
---

## **Vue d'ensemble**

Une disposition de diapositive définit l'agencement des zones réservées et la mise en forme du contenu d'une diapositive. Elle contrôle quelles zones réservées sont disponibles et où elles apparaissent. Les dispositions de diapositives vous aident à créer des présentations rapidement et de façon cohérente—que vous réalisiez quelque chose de simple ou de plus complexe. Certaines des dispositions de diapositives les plus courantes dans PowerPoint incluent :

**Disposition Titre** – Comprend deux zones de texte : une pour le titre et une pour le sous-titre.

**Disposition Titre et Contenu** – Présente une zone de titre plus petite en haut et une plus grande en dessous pour le contenu principal (comme du texte, des puces, des graphiques, des images, etc.).

**Disposition Vide** – Ne contient aucune zone réservée, vous donnant un contrôle total pour concevoir la diapositive à partir de zéro.

Les dispositions de diapositives font partie d'un masque de diapositive, qui est la diapositive de niveau supérieur définissant les styles de disposition pour la présentation. Vous pouvez accéder aux diapositives de disposition et les modifier via le masque de diapositive—soit par leur type, leur nom ou leur ID unique. Alternativement, vous pouvez éditer directement une diapositive de disposition spécifique dans la présentation.

Pour travailler avec les dispositions de diapositives dans Aspose.Slides for Android, vous pouvez utiliser :

- Des méthodes telles que [getLayoutSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getLayoutSlides--) et [getMasters](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getMasters--) sous la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) 
- Des types comme [ILayoutSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilayoutslide/), [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterlayoutslidecollection/), [ILayoutPlaceholderManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilayoutplaceholdermanager/), et [ILayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilayoutslideheaderfootermanager/)

{{% alert title="Info" color="info" %}}
Pour en savoir plus sur l’utilisation des masques de diapositives, consultez l’article [Masque de diapositive](/slides/fr/androidjava/slide-master/).
{{% /alert %}}

## **Ajouter des dispositions de diapositives aux présentations**

Pour personnaliser l’apparence et la structure de vos diapositives, il peut être nécessaire d’ajouter de nouvelles diapositives de disposition à une présentation. Aspose.Slides pour Android vous permet de vérifier si une disposition spécifique existe déjà, d’en ajouter une nouvelle si besoin, et de l’utiliser pour insérer des diapositives basées sur cette disposition.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
1. Accédez à la [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterlayoutslidecollection/).
1. Vérifiez si la diapositive de disposition souhaitée existe déjà dans la collection. Sinon, ajoutez la diapositive de disposition dont vous avez besoin.
1. Ajoutez une diapositive vierge basée sur la nouvelle diapositive de disposition.
1. Enregistrez la présentation.
1. Enregistrez la présentation.

Le code Java suivant montre comment ajouter une disposition de diapositive à une présentation PowerPoint :
```java
// Instancie la classe Presentation qui représente un fichier PowerPoint.
Presentation presentation = new Presentation("Sample.pptx");
try {
    // Parcourir les types de diapositives de disposition pour sélectionner une diapositive de disposition.
    IMasterLayoutSlideCollection layoutSlides = presentation.getMasters().get_Item(0).getLayoutSlides();
    ILayoutSlide layoutSlide = null;
    if (layoutSlides.getByType(SlideLayoutType.TitleAndObject) != null)
        layoutSlide = layoutSlides.getByType(SlideLayoutType.TitleAndObject);
    else
        layoutSlide = layoutSlides.getByType(SlideLayoutType.Title);

    if (layoutSlide == null) {
        // Une situation où la présentation ne contient pas tous les types de disposition.
        // Le fichier de présentation ne contient que les types de disposition Blank et Custom.
        // Cependant, les diapositives de disposition avec des types personnalisés peuvent avoir des noms reconnaissables,
        // comme "Title", "Title and Content", etc., qui peuvent être utilisés pour la sélection de la diapositive de disposition.
        // Vous pouvez également vous appuyer sur un ensemble de types de formes d'espace réservé.
        // Par exemple, une diapositive Titre ne doit contenir que le type d'espace réservé Title, etc.
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

    // Ajouter une diapositive vide en utilisant la diapositive de disposition ajoutée.
    presentation.getSlides().insertEmptySlide(0, layoutSlide);

    // Enregistrer la présentation sur le disque.
    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **Supprimer les dispositions de diapositives inutilisées**

Aspose.Slides fournit la méthode [removeUnusedLayoutSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) de la classe [Compress](https://reference.aspose.com/slides/androidjava/com.aspose.slides/compress/) pour vous permettre de supprimer les dispositions de diapositives indésirables et inutilisées.

Le code Java suivant montre comment supprimer une diapositive de disposition d’une présentation PowerPoint :
```java
Presentation presentation = new Presentation("Presentation.pptx");
try {
    Compress.removeUnusedLayoutSlides(presentation);

    presentation.save("Output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **Ajouter des zones réservées aux dispositions de diapositives**

Aspose.Slides fournit la méthode [ILayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilayoutslide/#getPlaceholderManager--) qui vous permet d’ajouter de nouvelles zones réservées à une diapositive de disposition.

Ce gestionnaire contient des méthodes pour les types de zones réservées suivants :

| Zone réservée PowerPoint | Méthode [ILayoutPlaceholderManager] |
| ------------------------ | ----------------------------------- |
| ![Contenu](content.png) | addContentPlaceholder(float x, float y, float width, float height) |
| ![Contenu (Vertical)](contentV.png) | addVerticalContentPlaceholder(float x, float y, float width, float height) |
| ![Texte](text.png) | addTextPlaceholder(float x, float y, float width, float height) |
| ![Texte (Vertical)](textV.png) | addVerticalTextPlaceholder(float x, float y, float width, float height) |
| ![Image](picture.png) | addPicturePlaceholder(float x, float y, float width, float height) |
| ![Graphique](chart.png) | addChartPlaceholder(float x, float y, float width, float height) |
| ![Tableau](table.png) | addTablePlaceholder(float x, float y, float width, float height) |
| ![SmartArt](smartart.png) | addSmartArtPlaceholder(float x, float y, float width, float height) |
| ![Média](media.png) | addMediaPlaceholder(float x, float y, float width, float height) |
| ![Image en ligne](onlineimage.png) | addOnlineImagePlaceholder(float x, float y, float width, float height) |

Le code Java suivant montre comment ajouter de nouvelles formes de zone réservée à la disposition Vide :
```java
Presentation presentation = new Presentation();
try {
    // Obtenir la diapositive de disposition vierge.
    ILayoutSlide layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);

    // Obtenir le gestionnaire de zones réservées de la diapositive de disposition.
    ILayoutPlaceholderManager placeholderManager = layout.getPlaceholderManager();

    // Ajouter différentes zones réservées à la diapositive de disposition vierge.
    placeholderManager.addContentPlaceholder(20, 20, 310, 270);
    placeholderManager.addVerticalTextPlaceholder(350, 20, 350, 270);
    placeholderManager.addChartPlaceholder(20, 310, 310, 180);
    placeholderManager.addTablePlaceholder(350, 310, 350, 180);

    // Ajouter une nouvelle diapositive avec la disposition vierge.
    ISlide newSlide = presentation.getSlides().addEmptySlide(layout);

    presentation.save("Placeholders.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


Le résultat :
![Les zones réservées sur la diapositive de disposition](add_placeholders.png)

## **Définir la visibilité du pied de page pour une diapositive de disposition**

Dans les présentations PowerPoint, les éléments de pied de page tels que la date, le numéro de diapositive et le texte personnalisé peuvent être affichés ou masqués selon la disposition de la diapositive. Aspose.Slides pour Android vous permet de contrôler la visibilité de ces zones réservées de pied de page. Cela est utile lorsque vous souhaitez que certaines dispositions affichent les informations de pied de page tandis que d’autres restent épurées et minimalistes.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
1. Obtenez une référence à une diapositive de disposition par son indice.
1. Définissez la zone réservée du pied de page de la diapositive comme visible.
1. Définissez la zone réservée du numéro de diapositive comme visible.
1. Définissez la zone réservée de date/heure comme visible.
1. Enregistrez la présentation.

Le code Java suivant montre comment définir la visibilité d’un pied de page de diapositive et exécuter les tâches associées :
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


## **Définir la visibilité du pied de page des diapositives enfants**

Dans les présentations PowerPoint, les éléments de pied de page tels que la date, le numéro de diapositive et le texte personnalisé peuvent être contrôlés au niveau du masque de diapositive afin d’assurer la cohérence sur toutes les dispositions. Aspose.Slides pour Android vous permet de définir la visibilité et le contenu de ces zones réservées de pied de page sur le masque de diapositive et de propager ces paramètres à toutes les dispositions enfants. Cette approche garantit une uniformité des informations de pied de page dans toute votre présentation.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
1. Obtenez une référence au masque de diapositive par son indice.
1. Définissez les zones réservées du pied de page du masque et de toutes les dispositions enfants comme visibles.
1. Définissez les zones réservées du numéro de diapositive du masque et de toutes les dispositions enfants comme visibles.
1. Définissez les zones réservées de date/heure du masque et de toutes les dispositions enfants comme visibles.
1. Enregistrez la présentation.

Le code Java suivant montre cette opération :
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

**Quelle est la différence entre un masque de diapositive et une diapositive de disposition ?**

Un masque de diapositive définit le thème global et la mise en forme par défaut, tandis que les diapositives de disposition définissent des agencements spécifiques de zones réservées pour différents types de contenu.

**Puis-je copier une diapositive de disposition d’une présentation à une autre ?**

Oui, vous pouvez cloner une diapositive de disposition à partir de la collection de diapositives de disposition d’une présentation, accessible via la méthode [getLayoutSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getLayoutSlides--) , et l’insérer dans une autre présentation en utilisant la méthode `addClone`.

**Que se passe-t-il si je supprime une diapositive de disposition qui est encore utilisée par une diapositive ?**

Si vous essayez de supprimer une diapositive de disposition qui est encore référencée par au moins une diapositive de la présentation, Aspose.Slides lèvera une [PptxEditException](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pptxeditexception/). Pour éviter cela, utilisez [removeUnusedLayoutSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) , qui supprime en toute sécurité uniquement les diapositives de disposition qui ne sont pas utilisées.