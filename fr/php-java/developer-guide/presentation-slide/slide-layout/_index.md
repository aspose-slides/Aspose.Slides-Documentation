---
title: Appliquer ou modifier les mises en page des diapositives en PHP
linktitle: Mise en page des diapositives
type: docs
weight: 60
url: /fr/php-java/slide-layout/
keywords:
- mise en page de diapositive
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
- uniquement le titre
- mise en page vierge
- contenu avec légende
- image avec légende
- titre et texte vertical
- titre vertical et texte
- PowerPoint
- OpenDocument
- présentation
- PHP
- Aspose.Slides
description: "Gérez et personnalisez les mises en page des diapositives dans Aspose.Slides pour PHP via Java. Explorez les types de mise en page, le contrôle des espaces réservés et la visibilité du pied de page grâce à des exemples de code."
---

## **Vue d'ensemble**

Un modèle de diapositive définit l'agencement des zones réservées et le formatage du contenu sur une diapositive. Il contrôle quelles zones réservées sont disponibles et où elles apparaissent. Les modèles de diapositive vous aident à concevoir des présentations rapidement et de manière cohérente—que vous créiez quelque chose de simple ou de plus complexe. Parmi les modèles de diapositive les plus courants dans PowerPoint, on trouve :

**Modèle de diapositive Titre** – Comprend deux zones réservées de texte : une pour le titre et une pour le sous-titre.

**Modèle Titre et Contenu** – Propose une petite zone réservée de titre en haut et une plus grande en dessous pour le contenu principal (texte, puces, graphiques, images, etc.).

**Modèle Blanc** – Ne contient aucune zone réservée, vous donnant le contrôle total pour concevoir la diapositive à partir de zéro.

Les modèles de diapositive font partie d’un masque de diapositive, qui est la diapositive de niveau supérieur définissant les styles de mise en page pour la présentation. Vous pouvez accéder aux modèles et les modifier via le masque de diapositive—par leur type, leur nom ou leur ID unique. Vous pouvez également éditer directement un modèle de diapositive spécifique dans la présentation.

Pour travailler avec les modèles de diapositive dans Aspose.Slides for PHP, vous pouvez utiliser :

- Des méthodes telles que [getLayoutSlides](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getLayoutSlides) et [getMasters](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getMasters) de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)
- Des types comme [LayoutSlide](https://reference.aspose.com/slides/php-java/aspose.slides/layoutslide/), [MasterLayoutSlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/masterlayoutslidecollection/), [LayoutPlaceholderManager](https://reference.aspose.com/slides/php-java/aspose.slides/layoutplaceholdermanager/) et [LayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/php-java/aspose.slides/layoutslideheaderfootermanager/)

{{% alert title="Info" color="info" %}}
Pour en savoir plus sur la manipulation des masques de diapositive, consultez l’article [Slide Master](/slides/fr/php-java/slide-master/).
{{% /alert %}}

## **Ajouter des modèles de diapositive aux présentations**

Pour personnaliser l’apparence et la structure de vos diapositives, il peut être nécessaire d’ajouter de nouveaux modèles de diapositive à une présentation. Aspose.Slides for PHP vous permet de vérifier si un modèle spécifique existe déjà, d’en ajouter un si besoin, puis de l’utiliser pour insérer des diapositives basées sur ce modèle.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. Accédez à la [MasterLayoutSlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/masterlayoutslidecollection/).
1. Vérifiez si le modèle de diapositive souhaité existe déjà dans la collection. Sinon, ajoutez le modèle dont vous avez besoin.
1. Ajoutez une diapositive vide basée sur le nouveau modèle.
1. Enregistrez la présentation.

Le code PHP suivant montre comment ajouter un modèle de diapositive à une présentation PowerPoint :
```php
// Instancier la classe Presentation qui représente un fichier PowerPoint.
$presentation = new Presentation("Sample.pptx");
try {
    // Parcourir les types de diapositives de mise en page pour sélectionner une diapositive de mise en page.
    $layoutSlides = $presentation->getMasters()->get_Item(0)->getLayoutSlides();
    $layoutSlide = null;
    if (!java_is_null($layoutSlides->getByType(SlideLayoutType::TitleAndObject))) {
        $layoutSlide = $layoutSlides->getByType(SlideLayoutType::TitleAndObject);
    } else {
        $layoutSlide = $layoutSlides->getByType(SlideLayoutType::Title);
    }

    if (java_is_null($layoutSlide)) {
        // Une situation où la présentation ne contient pas tous les types de mise en page.
        // Le fichier de présentation ne contient que les types de mise en page Blanc et Personnalisé.
        // Cependant, les diapositives de mise en page avec des types personnalisés peuvent avoir des noms reconnaissables,
        // comme "Title", "Title and Content", etc., qui peuvent être utilisés pour la sélection de la diapositive de mise en page.
        // Vous pouvez également vous appuyer sur un ensemble de types de formes d'espace réservé.
        // Par exemple, une diapositive Titre ne doit contenir que le type d'espace réservé Titre, etc.
        foreach($layoutSlides as $titleAndObjectLayoutSlide) {
            if (java_values($titleAndObjectLayoutSlide->getName()) == "Title and Object") {
                $layoutSlide = $titleAndObjectLayoutSlide;
                break;
            }
        }

        if (java_is_null($layoutSlide)) {
            foreach($layoutSlides as $titleLayoutSlide) {
                if (java_values($titleLayoutSlide->getName()) == "Title") {
                    $layoutSlide = $titleLayoutSlide;
                    break;
                }
            }

            if (java_is_null($layoutSlide)) {
                $layoutSlide = $layoutSlides->getByType(SlideLayoutType::Blank);
                if (java_is_null($layoutSlide)) {
                    $layoutSlide = $layoutSlides->add(SlideLayoutType::TitleAndObject, "Title and Object");
                }
            }
        }
    }

    // Ajouter une diapositive vide en utilisant la diapositive de mise en page ajoutée.
    $presentation->getSlides()->insertEmptySlide(0, $layoutSlide);

    // Enregistrer la présentation sur le disque.
    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```


## **Supprimer les modèles de diapositive inutilisés**

Aspose.Slides fournit la méthode [removeUnusedLayoutSlides](https://reference.aspose.com/slides/php-java/aspose.slides/compress/#removeUnusedLayoutSlides) de la classe [Compress](https://reference.aspose.com/slides/php-java/aspose.slides/compress/) pour supprimer les modèles de diapositive indésirables et non utilisés.

Le code PHP suivant montre comment supprimer un modèle de diapositive d’une présentation PowerPoint :
```php
$presentation = new Presentation("Presentation.pptx");
try {
    Compress::removeUnusedLayoutSlides($presentation);
    $presentation->save("Output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```


## **Ajouter des zones réservées aux modèles de diapositive**

Aspose.Slides fournit la méthode [LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/php-java/aspose.slides/layoutslide/#getPlaceholderManager), qui permet d’ajouter de nouvelles zones réservées à un modèle de diapositive.

Ce gestionnaire contient des méthodes pour les types de zones réservées suivants :

| Zone réservée PowerPoint           | Méthode [LayoutPlaceholderManager](https://reference.aspose.com/slides/php-java/aspose.slides/layoutplaceholdermanager/) |
| ---------------------------------- | -------------------------------------------------------------------------------------------------------------------------- |
| ![Content](content.png)            | addContentPlaceholder(float x, float y, float width, float height)                                                      |
| ![Content (Vertical)](contentV.png)| addVerticalContentPlaceholder(float x, float y, float width, float height)                                             |
| ![Text](text.png)                  | addTextPlaceholder(float x, float y, float width, float height)                                                         |
| ![Text (Vertical)](textV.png)      | addVerticalTextPlaceholder(float x, float y, float width, float height)                                                |
| ![Picture](picture.png)            | addPicturePlaceholder(float x, float y, float width, float height)                                                     |
| ![Chart](chart.png)                | addChartPlaceholder(float x, float y, float width, float height)                                                       |
| ![Table](table.png)                | addTablePlaceholder(float x, float y, float width, float height)                                                       |
| ![SmartArt](smartart.png)          | addSmartArtPlaceholder(float x, float y, float width, float height)                                                    |
| ![Media](media.png)                | addMediaPlaceholder(float x, float y, float width, float height)                                                       |
| ![Online Image](onlineimage.png)   | addOnlineImagePlaceholder(float x, float y, float width, float height)                                                |

Le code PHP suivant montre comment ajouter de nouvelles formes de zones réservées au modèle Blanc :
```php
$presentation = new Presentation();
try {
    // Obtenir la diapositive de mise en page vierge.
    $layout = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);

    // Obtenir le gestionnaire d'espaces réservés de la diapositive de mise en page.
    $placeholderManager = $layout->getPlaceholderManager();

    // Ajouter différents espaces réservés à la diapositive de mise en page vierge.
    $placeholderManager->addContentPlaceholder(20, 20, 310, 270);
    $placeholderManager->addVerticalTextPlaceholder(350, 20, 350, 270);
    $placeholderManager->addChartPlaceholder(20, 310, 310, 180);
    $placeholderManager->addTablePlaceholder(350, 310, 350, 180);

    // Ajouter une nouvelle diapositive avec la mise en page vierge.
    $newSlide = $presentation->getSlides()->addEmptySlide($layout);

    $presentation->save("Placeholders.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```


Le résultat :

![The placeholders on the layout slide](add_placeholders.png)

## **Définir la visibilité du pied de page pour un modèle de diapositive**

Dans les présentations PowerPoint, les éléments de pied de page comme la date, le numéro de diapositive et le texte personnalisé peuvent être affichés ou masqués selon le modèle de diapositive. Aspose.Slides for PHP vous permet de contrôler la visibilité de ces zones réservées du pied de page. Cela est utile lorsque vous souhaitez que certains modèles affichent les informations de pied de page tandis que d’autres restent épurés.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. Obtenez une référence à un modèle de diapositive par son index.
1. Définissez la zone réservée du pied de page comme visible.
1. Définissez la zone réservée du numéro de diapositive comme visible.
1. Définissez la zone réservée de la date/heure comme visible.
1. Enregistrez la présentation.

Le code PHP suivant montre comment définir la visibilité du pied de page d’une diapositive et effectuer les tâches associées :
```php
$presentation = new Presentation("Presentation.ppt");
try {
    $headerFooterManager = $presentation->getLayoutSlides()->get_Item(0)->getHeaderFooterManager();

    if (!$headerFooterManager->isFooterVisible()) {
        $headerFooterManager->setFooterVisibility(true);
    }

    if (!$headerFooterManager->isSlideNumberVisible()) {
        $headerFooterManager->setSlideNumberVisibility(true);
    }

    if (!$headerFooterManager->isDateTimeVisible()) {
        $headerFooterManager->setDateTimeVisibility(true);
    }

    $headerFooterManager->setFooterText("Footer text");
    $headerFooterManager->setDateTimeText("Date and time text");

    $presentation->save("Presentation.ppt", SaveFormat::Ppt);
} finally {
    $presentation->dispose();
}
```


## **Définir la visibilité du pied de page enfant pour une diapositive**

​Dans les présentations PowerPoint, les éléments de pied de page tels que la date, le numéro de diapositive et le texte personnalisé peuvent être contrôlés au niveau du masque de diapositive afin d’assurer la cohérence sur tous les modèles de diapositive. Aspose.Slides for PHP vous permet de régler la visibilité et le contenu de ces zones réservées du pied de page sur le masque de diapositive et de propager ces paramètres à toutes les diapositives modèles enfants. Cette approche garantit une information de pied de page uniforme tout au long de votre présentation.​

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. Obtenez une référence au masque de diapositive par son index.
1. Définissez les zones réservées du pied de page du masque et de tous les modèles enfants comme visibles.
1. Définissez les zones réservées du numéro de diapositive du masque et de tous les modèles enfants comme visibles.
1. Définissez les zones réservées de la date/heure du masque et de tous les modèles enfants comme visibles.
1. Enregistrez la présentation.

Le code PHP suivant montre cette opération :
```php
$presentation = new Presentation("presentation.ppt");
try {
    $headerFooterManager = $presentation->getMasters()->get_Item(0)->getHeaderFooterManager();

    $headerFooterManager->setFooterAndChildFootersVisibility(true);
    $headerFooterManager->setSlideNumberAndChildSlideNumbersVisibility(true);
    $headerFooterManager->setDateTimeAndChildDateTimesVisibility(true);

    $headerFooterManager->setFooterAndChildFootersText("Footer text");
    $headerFooterManager->setDateTimeAndChildDateTimesText("Date and time text");

    $presentation->save("Output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```


## **FAQ**

**Quelle est la différence entre un masque de diapositive et un modèle de diapositive ?**

Un masque de diapositive définit le thème global et le formatage par défaut, tandis que les modèles de diapositive définissent des agencements spécifiques de zones réservées pour différents types de contenu.

**Puis‑je copier un modèle de diapositive d’une présentation à une autre ?**

Oui, vous pouvez cloner un modèle de diapositive à partir de la collection de modèles d’une présentation, accessible via la méthode [getLayoutSlides](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getLayoutSlides), puis l’insérer dans une autre présentation à l’aide de la méthode `addClone`.

**Que se passe‑t‑il si je supprime un modèle de diapositive qui est encore utilisé par une diapositive ?**

Si vous essayez de supprimer un modèle de diapositive qui est encore référencé par au moins une diapositive de la présentation, Aspose.Slides lèvera une [PptxEditException](https://reference.aspose.com/slides/php-java/aspose.slides/pptxeditexception/). Pour éviter cela, utilisez [removeUnusedLayoutSlides](https://reference.aspose.com/slides/php-java/aspose.slides/compress/#removeUnusedLayoutSlides) qui supprime en toute sécurité uniquement les modèles de diapositive non utilisés.