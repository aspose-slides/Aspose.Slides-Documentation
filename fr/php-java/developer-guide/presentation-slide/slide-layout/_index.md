---
title: Appliquer ou modifier les agencements de diapositives en PHP
linktitle: Agencement de diapositive
type: docs
weight: 60
url: /fr/php-java/slide-layout/
keywords:
- agencement de diapositive
- agencement de contenu
- espace réservé
- conception de présentation
- conception de diapositive
- agencement inutilisé
- visibilité du pied de page
- diapositive de titre
- titre et contenu
- en-tête de section
- deux contenus
- comparaison
- titre uniquement
- agencement vierge
- contenu avec légende
- image avec légende
- titre et texte vertical
- titre vertical et texte
- PowerPoint
- OpenDocument
- présentation
- PHP
- Aspose.Slides
description: "Appliquer, créer et modifier les agencements de diapositives dans Aspose.Slides pour PHP via Java, ajouter des espaces réservés, supprimer les agencements inutilisés et contrôler la visibilité du pied de page."
---
## **Vue d’ensemble**

Un agencement de diapositive définit les positions et le formatage des espaces réservés tels que les titres, le texte, les images, les graphiques et les tableaux. Appliquer un agencement donne aux diapositives une structure cohérente tout en permettant à chaque diapositive de contenir son propre contenu.

Les agencements les plus courants comprennent :

- **Diapositive de titre** : contient les espaces réservés au titre et au sous‑titre.
- **Titre et contenu** : contient un espace réservé au titre et un espace réservé de contenu à usage général.
- **Vide** : ne contient aucun espace réservé et est utile lorsque chaque forme sera positionnée manuellement.

## **Comprendre l’héritage des agencements**

Une présentation possède trois niveaux associés :

1. Une [diapositive maître](https://reference.aspose.com/slides/fr/php-java/aspose.slides/masterslide/) définit le thème, le formatage partagé, les arrière‑plans et les objets communs.
1. Une [diapositive de mise en page](https://reference.aspose.com/slides/fr/php-java/aspose.slides/layoutslide/) appartient à un maître et définit une disposition particulière d’espaces réservés.
1. Une [diapositive normale](https://reference.aspose.com/slides/fr/php-java/aspose.slides/slide/) utilise un agencement et stocke le contenu saisi pour cette diapositive.

Une diapositive normale hérite du thème et du formatage de son agencement, et l’agencement hérite de son maître. Une valeur définie directement sur une diapositive normale remplace la valeur héritée à ce niveau. Lorsqu’une diapositive normale est créée, ses formes d’espace réservé sont générées à partir de l’agencement sélectionné, tandis que le contenu saisi dans ces espaces réservés appartient à la diapositive normale.

Ajoutez les espaces réservés requis à un agencement avant de créer des diapositives à partir de celui‑ci. L’ajout ultérieur d’un autre espace réservé à un agencement n’ajoute pas automatiquement une forme d’espace réservé correspondante aux diapositives normales existantes.

Cette relation a deux conséquences importantes :

- Modifier le formatage hérité ou la géométrie des espaces réservés existants d’un agencement peut mettre à jour chaque diapositive qui en dépend. Avant de modifier un agencement déjà utilisé, inspectez ses diapositives dépendantes et examinez la présentation résultante.
- Un agencement encore utilisé par une diapositive ne peut pas être supprimé. Réaffectez d’abord ses diapositives dépendantes à un autre agencement, ou supprimez uniquement les agencements inutilisés.

Pour plus d’informations sur le niveau supérieur de cette hiérarchie, consultez [Slide Master](/slides/fr/php-java/slide-master/).

## **Sélectionner et appliquer un agencement de diapositive**

Utilisez un type d’agencement lorsque la présentation suit les définitions d’agencements standard de PowerPoint. Les noms d’agencements sont modifiables par l’utilisateur et peuvent être localisés, ainsi la sélection basée sur le nom est moins fiable à moins que vous ne contrôliez le modèle source.

L’exemple suivant recherche **Titre et contenu** sur le premier maître. Si cet agencement n’est pas disponible, il revient intentionnellement à **Vide**. La seconde vérification de nullité est nécessaire car une présentation ne peut contenir que des agencements personnalisés. L’agencement sélectionné est ensuite appliqué à la première diapositive normale via la méthode [Slide.setLayoutSlide](https://reference.aspose.com/slides/fr/php-java/aspose.slides/slide/#setLayoutSlide).

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideLayoutType;

$presentation = new Presentation("input.pptx");
try {
    $layoutSlides = $presentation->getMasters()->get_Item(0)->getLayoutSlides();
    $targetLayout = $layoutSlides->getByType(SlideLayoutType::TitleAndObject);

    if (java_is_null($targetLayout)) {
        $targetLayout = $layoutSlides->getByType(SlideLayoutType::Blank);
    }

    if (java_is_null($targetLayout)) {
        throw new \RuntimeException("The first master does not contain a suitable layout slide.");
    }

    $presentation->getSlides()->get_Item(0)->setLayoutSlide($targetLayout);
    $presentation->save("output-with-new-layout.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Modifier l’agencement d’une diapositive ne supprime pas les formes ordinaires ajoutées directement à la diapositive. Cependant, les positions des espaces réservés, le formatage hérité et la correspondance entre les espaces réservés existants et le nouvel agencement peuvent changer, il faut donc inspecter le résultat lors du passage entre des agencements sensiblement différents.

## **Ajouter une diapositive d’agencement**

La sélection et la création sont des opérations distinctes. L’exemple précédent sélectionne un agencement existant ; il n’en crée pas. Pour créer un agencement, appelez la méthode [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/fr/php-java/aspose.slides/masterlayoutslidecollection/#add) sur la collection d’agencements du maître cible.

L’exemple suivant ajoute toujours un nouvel agencement **Titre et contenu** nommé `Report Title and Content`, puis ajoute une diapositive normale basée sur celui‑ci. Les noms d’agencements doivent être uniques au sein de la collection.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideLayoutType;

$presentation = new Presentation("input.pptx");
try {
    $masterSlide = $presentation->getMasters()->get_Item(0);
    $reportLayout = $masterSlide->getLayoutSlides()->add(SlideLayoutType::TitleAndObject, "Report Title and Content");
    $presentation->getSlides()->addEmptySlide($reportLayout);

    $presentation->save("output-with-report-layout.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Ajoutez un agencement uniquement lorsque le modèle nécessite réellement une autre structure réutilisable. Si un agencement approprié existe déjà, sélectionnez‑le et réutilisez‑le au lieu de créer un doublon.

## **Ajouter des espaces réservés à une diapositive d’agencement**

La méthode [LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/fr/php-java/aspose.slides/layoutslide/#getPlaceholderManager) fournit un [LayoutPlaceholderManager](https://reference.aspose.com/slides/fr/php-java/aspose.slides/layoutplaceholdermanager/) pour ajouter des formes d’espace réservé à un agencement.

| Espace réservé PowerPoint          | Méthode `LayoutPlaceholderManager` |
| ----------------------------------- | ----------------------------------- |
| ![Content](content.png)             | [`addContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/fr/php-java/aspose.slides/layoutplaceholdermanager/#addContentPlaceholder) |
| ![Content (Vertical)](contentV.png) | [`addVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/fr/php-java/aspose.slides/layoutplaceholdermanager/#addVerticalContentPlaceholder) |
| ![Text](text.png)                   | [`addTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/fr/php-java/aspose.slides/layoutplaceholdermanager/#addTextPlaceholder) |
| ![Text (Vertical)](textV.png)       | [`addVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/fr/php-java/aspose.slides/layoutplaceholdermanager/#addVerticalTextPlaceholder) |
| ![Picture](picture.png)             | [`addPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/fr/php-java/aspose.slides/layoutplaceholdermanager/#addPicturePlaceholder) |
| ![Chart](chart.png)                 | [`addChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/fr/php-java/aspose.slides/layoutplaceholdermanager/#addChartPlaceholder) |
| ![Table](table.png)                 | [`addTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/fr/php-java/aspose.slides/layoutplaceholdermanager/#addTablePlaceholder) |
| ![SmartArt](smartart.png)           | [`addSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/fr/php-java/aspose.slides/layoutplaceholdermanager/#addSmartArtPlaceholder) |
| ![Media](media.png)                 | [`addMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/fr/php-java/aspose.slides/layoutplaceholdermanager/#addMediaPlaceholder) |
| ![Online Image](onlineImage.png)    | [`addOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/fr/php-java/aspose.slides/layoutplaceholdermanager/#addOnlineImagePlaceholder) |

L’exemple suivant vérifie que l’agencement **Vide** existe, ajoute quatre espaces réservés, puis crée une diapositive normale qui utilise l’agencement modifié. L’ordre est intentionnel : les espaces réservés sont ajoutés avant la création de la diapositive normale, de sorte qu’Aspose.Slides puisse générer les formes d’espace réservé correspondantes sur cette diapositive.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideLayoutType;

$presentation = new Presentation();
try {
    $blankLayout = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);

    if (java_is_null($blankLayout)) {
        throw new \RuntimeException("The presentation does not contain a Blank layout slide.");
    }

    $placeholderManager = $blankLayout->getPlaceholderManager();
    $placeholderManager->addContentPlaceholder(20, 20, 310, 270);
    $placeholderManager->addVerticalTextPlaceholder(350, 20, 350, 270);
    $placeholderManager->addChartPlaceholder(20, 310, 310, 180);
    $placeholderManager->addTablePlaceholder(350, 310, 350, 180);

    $presentation->getSlides()->addEmptySlide($blankLayout);
    $presentation->save("output-with-placeholders.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Le résultat :

![The placeholders on the layout slide](add_placeholders.png)

{{% alert color="warning" title="Avertissement" %}}
Modifier le formatage hérité ou la géométrie des espaces réservés existants d’un agencement peut affecter les diapositives dépendantes. Un espace réservé ajouté récemment n’est pas rétro‑alimenté dans les diapositives normales existantes. Testez les changements d’agencement sur une copie de la présentation et inspectez chaque diapositive dépendante.
{{% /alert %}}

## **Supprimer les diapositives d’agencement inutilisées**

Utilisez la méthode [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/fr/php-java/aspose.slides/compress/#removeUnusedLayoutSlides) pour supprimer les agencements qui ne sont référencés par aucune diapositive normale. La méthode laisse intacts les agencements encore utilisés.

```php
use aspose\slides\Compress;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("input.pptx");
try {
    Compress::removeUnusedLayoutSlides($presentation);
    $presentation->save("output-without-unused-layouts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Pour supprimer un agencement spécifique, utilisez d’abord sa méthode [hasDependingSlides](https://reference.aspose.com/slides/fr/php-java/aspose.slides/layoutslide/#hasDependingSlides) ou [getDependingSlides](https://reference.aspose.com/slides/fr/php-java/aspose.slides/layoutslide/#getDependingSlides). Réaffectez les diapositives dépendantes avant d’appeler [LayoutSlide.remove](https://reference.aspose.com/slides/fr/php-java/aspose.slides/layoutslide/#remove). Tenter de supprimer un agencement utilisé déclenche une [PptxEditException](https://reference.aspose.com/slides/fr/php-java/aspose.slides/pptxeditexception/).

## **Contrôler la visibilité du pied de page sur une diapositive d’agencement**

Un agencement possède ses propres espaces réservés pour le pied de page, le numéro de diapositive et la date‑heure. Utilisez la méthode [LayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/fr/php-java/aspose.slides/layoutslide/#getHeaderFooterManager) pour contrôler ces espaces réservés pour un agencement. Cela est utile, par exemple, lorsqu’un agencement de contenu doit afficher les pieds de page mais pas les agencements de titre.

L’exemple suivant sélectionne un agencement en toute sécurité et rend ses éléments de pied de page visibles :

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideLayoutType;

$presentation = new Presentation("input.pptx");
try {
    $layoutSlide = $presentation->getLayoutSlides()->getByType(SlideLayoutType::TitleAndObject);

    if (java_is_null($layoutSlide)) {
        $layoutSlide = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);
    }

    if (java_is_null($layoutSlide)) {
        throw new \RuntimeException("The presentation does not contain a suitable layout slide.");
    }

    $headerFooterManager = $layoutSlide->getHeaderFooterManager();
    $headerFooterManager->setFooterVisibility(true);
    $headerFooterManager->setSlideNumberVisibility(true);
    $headerFooterManager->setDateTimeVisibility(true);
    $headerFooterManager->setFooterText("Footer text");
    $headerFooterManager->setDateTimeText("Date and time text");

    $presentation->save("output-with-layout-footers.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Contrôler la visibilité du pied de page sur un maître et ses agencements enfants**

Pour appliquer des paramètres de pied de page cohérents à travers une hiérarchie de maîtres, utilisez la méthode [MasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/fr/php-java/aspose.slides/masterslide/#getHeaderFooterManager). Les méthodes de propagation de [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/fr/php-java/aspose.slides/masterslideheaderfootermanager/) agissent sur le maître ainsi que sur ses diapositives d’agencement dépendantes et les diapositives normales ; elles ne ciblent pas une seule diapositive normale.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("input.pptx");
try {
    $headerFooterManager = $presentation->getMasters()->get_Item(0)->getHeaderFooterManager();
    $headerFooterManager->setFooterAndChildFootersVisibility(true);
    $headerFooterManager->setSlideNumberAndChildSlideNumbersVisibility(true);
    $headerFooterManager->setDateTimeAndChildDateTimesVisibility(true);
    $headerFooterManager->setFooterAndChildFootersText("Footer text");
    $headerFooterManager->setDateTimeAndChildDateTimesText("Date and time text");

    $presentation->save("output-with-master-footers.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Quelle est la différence entre une diapositive maître et une diapositive d’agencement ?**

Une diapositive maître définit le thème de la présentation et le formatage partagé. Une diapositive d’agencement appartient à un maître et définit une disposition réutilisable d’espaces réservés. Les diapositives normales utilisent ces agencements et stockent le contenu propre à chaque diapositive.

**Puis‑je copier une diapositive d’agencement d’une présentation à une autre ?**

Oui. Ajoutez une copie à la collection de destination avec la méthode [addClone](https://reference.aspose.com/slides/fr/php-java/aspose.slides/globallayoutslidecollection/#addClone). Lors de la copie entre présentations, vérifiez également les polices, les thèmes, les images et les autres ressources utilisées par l’agencement source.

**Que se passe‑t‑il si je modifie un agencement déjà utilisé ?**

Les diapositives dépendantes héritent des modifications d’agencement sauf si elles remplacent localement le formatage ou les objets affectés. La géométrie des espaces réservés et le style hérité peuvent donc changer simultanément sur de nombreuses diapositives. Utilisez [getDependingSlides](https://reference.aspose.com/slides/fr/php-java/aspose.slides/layoutslide/#getDependingSlides) pour identifier les diapositives affectées avant de modifier l’agencement.

**Que se passe‑t‑il si je supprime un agencement encore utilisé ?**

Aspose.Slides déclenche une [PptxEditException](https://reference.aspose.com/slides/fr/php-java/aspose.slides/pptxeditexception/). Réaffectez d’abord les diapositives dépendantes, ou utilisez [removeUnusedLayoutSlides](https://reference.aspose.com/slides/fr/php-java/aspose.slides/compress/#removeUnusedLayoutSlides) pour supprimer uniquement les agencements non référencés.