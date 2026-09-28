---
title: Appliquer ou modifier les dispositions de diapositive en PHP
linktitle: Disposition de diapositive
type: docs
weight: 60
url: /fr/php-java/slide-layout/
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
- titre uniquement
- disposition vierge
- contenu avec légende
- image avec légende
- titre et texte vertical
- titre vertical et texte
- PowerPoint
- OpenDocument
- présentation
- PHP
- Aspose.Slides
description: "Appliquer, créer et modifier les dispositions de diapositive dans Aspose.Slides pour PHP via Java, ajouter des espaces réservés, supprimer les dispositions inutilisées et contrôler la visibilité du pied de page."
---
## **Vue d'ensemble**

Une disposition de diapositive définit les positions et le formatage des espaces réservés tels que les titres, le texte, les images, les graphiques et les tableaux. Appliquer une disposition donne aux diapositives une structure cohérente tout en permettant à chaque diapositive de contenir son propre contenu.

Les dispositions les plus courantes incluent :

- **Title Slide** : Contient des espaces réservés de titre et de sous‑titre.
- **Title and Content** : Contient un espace réservé de titre et un espace réservé de contenu à usage général.
- **Blank** : Ne contient aucun espace réservé de contenu et est utile lorsque chaque forme sera positionnée manuellement.

## **Comprendre l'héritage des dispositions**

Une présentation possède trois niveaux liés :

1. Un [master slide](https://reference.aspose.com/slides/fr/php-java/aspose.slides/masterslide/) définit le thème, le formatage partagé, les arrière‑plans et les objets communs.
1. Un [layout slide](https://reference.aspose.com/slides/fr/php-java/aspose.slides/layoutslide/) appartient à un master et définit une disposition particulière d'espaces réservés.
1. Une [normal slide](https://reference.aspose.com/slides/fr/php-java/aspose.slides/slide/) utilise une disposition et stocke le contenu saisi pour cette diapositive.

Une diapositive normale hérite du thème et du formatage de sa disposition, et la disposition hérite de son master. Une valeur définie directement sur une diapositive normale remplace la valeur héritée à ce niveau. Lorsqu'une diapositive normale est créée, ses formes d'espaces réservés sont générées à partir de la disposition sélectionnée, tandis que le contenu saisi dans ces espaces réservés appartient à la diapositive normale.

Ajoutez les espaces réservés requis à une disposition avant de créer des diapositives à partir de celle‑ci. Ajouter ultérieurement un autre espace réservé à une disposition n'ajoute pas automatiquement la forme d'espace réservé correspondante aux diapositives normales existantes.

Cette relation a deux conséquences importantes :

- Modifier le formatage hérité ou la géométrie des espaces réservés existants d’une disposition peut mettre à jour chaque diapositive qui en dépend. Avant de modifier une disposition déjà utilisée, inspectez ses diapositives dépendantes et examinez la présentation résultante.
- Une disposition encore utilisée par une diapositive ne peut pas être supprimée. Réaffectez d’abord ses diapositives dépendantes à une autre disposition, ou ne supprimez que les dispositions inutilisées.

Pour plus d'informations sur le niveau supérieur de cette hiérarchie, consultez [Slide Master](/slides/fr/php-java/slide-master/).

Pour masquer les logos hérités ou les formes décoratives du master sur une diapositive ou via une disposition partagée, voyez [Control the Visibility of Master Graphics](/slides/fr/php-java/slide-master/). L'exemple compare deux diapositives utilisant le même master.

## **Sélectionner et appliquer une disposition de diapositive**

Utilisez un type de disposition lorsque la présentation suit les définitions de disposition standard de PowerPoint. Les noms de disposition sont modifiables par l'utilisateur et peuvent être localisés, de sorte qu'une sélection basée sur le nom est moins fiable à moins que vous ne contrôliez le modèle source.

L'exemple suivant recherche **Title and Content** sur le premier master. Si cette disposition n'est pas disponible, il revient délibérément à **Blank**. La deuxième vérification de nullité est nécessaire parce qu'une présentation ne peut contenir que des dispositions personnalisées. La disposition sélectionnée est ensuite appliquée à la première diapositive normale via la méthode [Slide.setLayoutSlide](https://reference.aspose.com/slides/fr/php-java/aspose.slides/slide/#setLayoutSlide).

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

Modifier la disposition d’une diapositive ne supprime pas les formes ordinaires ajoutées directement à la diapositive. Cependant, les positions des espaces réservés, le formatage hérité et la correspondance entre les espaces réservés existants et la nouvelle disposition peuvent changer, il faut donc inspecter le résultat lors du passage entre des dispositions substantiellement différentes.

## **Ajouter une disposition de diapositive**

La sélection et la création sont des opérations distinctes. L'exemple précédent sélectionne une disposition existante ; il ne la crée pas. Pour créer une disposition, appelez la méthode [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/fr/php-java/aspose.slides/masterlayoutslidecollection/#add) sur la collection de dispositions du master cible.

L'exemple suivant ajoute toujours une nouvelle disposition **Title and Content** nommée `Report Title and Content`, puis ajoute une diapositive normale basée dessus. Les noms de disposition doivent être uniques au sein de la collection.

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

Ajoutez une disposition uniquement lorsque le modèle a réellement besoin d’une autre structure réutilisable. Si une disposition appropriée existe déjà, sélectionnez‑la et réutilisez‑la au lieu de créer un doublon.

## **Ajouter des espaces réservés à une disposition de diapositive**

La méthode [LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/fr/php-java/aspose.slides/layoutslide/#getPlaceholderManager) fournit un [LayoutPlaceholderManager](https://reference.aspose.com/slides/fr/php-java/aspose.slides/layoutplaceholdermanager/) pour ajouter des formes d'espaces réservés à une disposition.

| Espace réservé PowerPoint          | Méthode LayoutPlaceholderManager |
| ---------------------------------- | --------------------------------- |
| ![Contenu](content.png)            | [`addContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/fr/php-java/aspose.slides/layoutplaceholdermanager/#addContentPlaceholder) |
| ![Contenu (Vertical)](contentV.png) | [`addVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/fr/php-java/aspose.slides/layoutplaceholdermanager/#addVerticalContentPlaceholder) |
| ![Texte](text.png)                 | [`addTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/fr/php-java/aspose.slides/layoutplaceholdermanager/#addTextPlaceholder) |
| ![Texte (Vertical)](textV.png)     | [`addVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/fr/php-java/aspose.slides/layoutplaceholdermanager/#addVerticalTextPlaceholder) |
| ![Image](picture.png)              | [`addPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/fr/php-java/aspose.slides/layoutplaceholdermanager/#addPicturePlaceholder) |
| ![Graphique](chart.png)            | [`addChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/fr/php-java/aspose.slides/layoutplaceholdermanager/#addChartPlaceholder) |
| ![Tableau](table.png)              | [`addTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/fr/php-java/aspose.slides/layoutplaceholdermanager/#addTablePlaceholder) |
| ![SmartArt](smartart.png)          | [`addSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/fr/php-java/aspose.slides/layoutplaceholdermanager/#addSmartArtPlaceholder) |
| ![Média](media.png)                | [`addMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/fr/php-java/aspose.slides/layoutplaceholdermanager/#addMediaPlaceholder) |
| ![Image en ligne](onlineImage.png) | [`addOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/fr/php-java/aspose.slides/layoutplaceholdermanager/#addOnlineImagePlaceholder) |

L'exemple suivant vérifie que la disposition **Blank** existe, y ajoute quatre espaces réservés, puis crée une diapositive normale qui utilise la disposition modifiée. L'ordre est intentionnel : les espaces réservés sont ajoutés avant la création de la diapositive normale, afin qu’Aspose.Slides puisse générer les formes d'espaces réservés correspondantes sur cette diapositive.

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

{{% alert color="warning" title="Warning" %}}
Modifier le formatage hérité ou la géométrie des espaces réservés existants d’une disposition peut affecter les diapositives dépendantes. Un espace réservé de disposition ajouté récemment n’est pas répercuté dans les diapositives normales existantes. Testez les changements de disposition sur une copie de la présentation et inspectez chaque diapositive dépendante.
{{% /alert %}}

## **Supprimer les dispositions de diapositive inutilisées**

Utilisez la méthode [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/fr/php-java/aspose.slides/compress/#removeUnusedLayoutSlides) pour supprimer les dispositions qui ne sont référencées par aucune diapositive normale. La méthode laisse intactes les dispositions qui sont encore utilisées.

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

Pour supprimer une disposition spécifique, utilisez d’abord sa méthode [hasDependingSlides](https://reference.aspose.com/slides/fr/php-java/aspose.slides/layoutslide/#hasDependingSlides) ou [getDependingSlides](https://reference.aspose.com/slides/fr/php-java/aspose.slides/layoutslide/#getDependingSlides). Réaffectez les diapositives dépendantes avant d’appeler [LayoutSlide.remove](https://reference.aspose.com/slides/fr/php-java/aspose.slides/layoutslide/#remove). Tenter de supprimer une disposition utilisée déclenche une [PptxEditException](https://reference.aspose.com/slides/fr/php-java/aspose.slides/pptxeditexception/).

## **Contrôler la visibilité du pied de page sur une disposition de diapositive**

Une disposition possède ses propres espaces réservés de pied de page, de numéro de diapositive et de date‑heure. Utilisez la méthode [LayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/fr/php-java/aspose.slides/layoutslide/#getHeaderFooterManager) pour contrôler ces espaces réservés pour une disposition. Cela est utile lorsque, par exemple, les dispositions de contenu doivent afficher les pieds de page alors que les dispositions de titre ne le doivent pas.

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

## **Contrôler la visibilité du pied de page sur un master et ses dispositions enfants**

Pour appliquer des paramètres de pied de page cohérents à travers une hiérarchie de masters, utilisez la méthode [MasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/fr/php-java/aspose.slides/masterslide/#getHeaderFooterManager). Les méthodes de propagation de [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/fr/php-java/aspose.slides/masterslideheaderfootermanager/) opèrent sur le master ainsi que sur ses dispositions dépendantes et les diapositives normales ; elles ne ciblent pas une seule diapositive normale.

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

**Quelle est la différence entre une master slide et une layout slide ?**

Une master slide définit le thème et le formatage partagé de la présentation. Une layout slide appartient à un master et définit une disposition réutilisable d'espaces réservés. Les diapositives normales utilisent ces dispositions et stockent le contenu propre à chaque diapositive.

**Puis-je copier une layout slide d'une présentation à une autre ?**

Oui. Ajoutez une copie à la collection de destination avec la méthode [addClone](https://reference.aspose.com/slides/fr/php-java/aspose.slides/globallayoutslidecollection/#addClone). Lors de la copie entre présentations, vérifiez également les polices, thèmes, images et autres ressources utilisées par la disposition source.

**Que se passe-t-il lorsque je modifie une disposition déjà utilisée ?**

Les diapositives dépendantes héritent des modifications de la disposition sauf si elles remplacent localement le formatage ou les objets affectés. La géométrie des espaces réservés et le style hérité peuvent donc changer sur de nombreuses diapositives simultanément. Utilisez [getDependingSlides](https://reference.aspose.com/slides/fr/php-java/aspose.slides/layoutslide/#getDependingSlides) pour identifier les diapositives concernées avant de modifier la disposition.

**Que se passe-t-il si je supprime une disposition qui est encore utilisée ?**

Aspose.Slides lève une [PptxEditException](https://reference.aspose.com/slides/fr/php-java/aspose.slides/pptxeditexception/). Réaffectez d’abord les diapositives dépendantes, ou utilisez [removeUnusedLayoutSlides](https://reference.aspose.com/slides/fr/php-java/aspose.slides/compress/#removeUnusedLayoutSlides) pour ne supprimer que les dispositions non référencées.