---
title: Gérer les guides de dessin dans les présentations en PHP
linktitle: Guides de dessin
type: docs
weight: 85
url: /fr/php-java/drawing-guides/
keywords:
- guide de dessin
- guide horizontal
- guide vertical
- guide d'alignement
- vue de diapositive
- diapositive maître
- diapositive de mise en page
- maître des notes
- maître du prospectus
- PowerPoint
- présentation
- PHP
- Aspose.Slides
description: "Ajouter, accéder et supprimer les guides de dessin horizontaux et verticaux dans les présentations PowerPoint à l'aide d'Aspose.Slides pour PHP via Java."
---
## **Vue d'ensemble**

Les guides de dessin sont des lignes horizontales et verticales réglables qui aident les utilisateurs à aligner les formes de manière cohérente lors de la modification d'une présentation dans PowerPoint. Ils sont particulièrement utiles lorsqu'une application génère une présentation qui sera ensuite affinee manuellement : l'application peut enregistrer les mêmes aides a l'alignement que les auteurs doivent suivre lors de l'ajout ou du deplacement de contenu.

Les guides de dessin sont des aides a l'edition, pas du contenu de diapositive. Ils n'apparaissent pas dans un diaporama ou une sortie rendue. Aspose.Slides for PHP via Java les expose via la classe [DrawingGuidesCollection](https://reference.aspose.com/slides/fr/php-java/aspose.slides/drawingguidescollection/). Un guide est represente par [DrawingGuide](https://reference.aspose.com/slides/fr/php-java/aspose.slides/drawingguide/) et possède une orientation, une position et une couleur.

La position est mesurée en points depuis le coin superieur gauche de la diapositive ou du maitre concerne. Un guide vertical utilise une coordonnée horizontale, généralement comprise entre zero et la largeur de la diapositive. Un guide horizontal utilise une coordonnée verticale, généralement comprise entre zero et la hauteur de la diapositive.

## **Ajouter des guides à la vue de diapositive**

Utilisez [CommonSlideViewProperties::getDrawingGuides](https://reference.aspose.com/slides/fr/php-java/aspose.slides/commonslideviewproperties/#getDrawingGuides) pour gérer les guides affichés lors de la modification des diapositives normales. Appelez [DrawingGuidesCollection::add](https://reference.aspose.com/slides/fr/php-java/aspose.slides/drawingguidescollection/#add) avec une valeur [Orientation](https://reference.aspose.com/slides/fr/php-java/aspose.slides/orientation/) et une position en points.

L'exemple suivant ajoute un guide vertical a droite du centre de la diapositive et un guide horizontal en dessous :

```php
use aspose\slides\Orientation;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slideSize = $presentation->getSlideSize()->getSize();
    $slideWidth = java_values($slideSize->getWidth());
    $slideHeight = java_values($slideSize->getHeight());
    $guides = $presentation->getViewProperties()->getSlideViewProperties()->getDrawingGuides();

    $guides->add(Orientation::Vertical, $slideWidth / 2 + 12.5);
    $guides->add(Orientation::Horizontal, $slideHeight / 2 + 12.5);

    $presentation->save("drawing-guides.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Acceder aux guides de dessin**

Les methodes [DrawingGuidesCollection::getCount](https://reference.aspose.com/slides/fr/php-java/aspose.slides/drawingguidescollection/#getCount) et [DrawingGuidesCollection::get_Item](https://reference.aspose.com/slides/fr/php-java/aspose.slides/drawingguidescollection/#get_Item) offrent un acces aux guides existants. Les methodes [DrawingGuide::getOrientation](https://reference.aspose.com/slides/fr/php-java/aspose.slides/drawingguide/#getOrientation), [DrawingGuide::getPosition](https://reference.aspose.com/slides/fr/php-java/aspose.slides/drawingguide/#getPosition) et [DrawingGuide::getColor](https://reference.aspose.com/slides/fr/php-java/aspose.slides/drawingguide/#getColor) renvoient des valeurs qui peuvent egalement être modifiees via les methodes setter correspondantes.

L'exemple suivant lit les guides de la vue diapositive a partir de la presentation creee ci-dessus :

```php
use aspose\slides\Presentation;

$presentation = new Presentation("drawing-guides.pptx");
try {
    $guides = $presentation->getViewProperties()->getSlideViewProperties()->getDrawingGuides();
    $guideCount = java_values($guides->getCount());

    for ($index = 0; $index < $guideCount; $index++) {
        $guide = $guides->get_Item($index);
        $orientation = java_values($guide->getOrientation());
        $position = java_values($guide->getPosition());
        $color = java_values($guide->getColor()->toString());
        echo sprintf("Guide %d: orientation = %d, position = %.2f, color = %s", $index, $orientation, $position, $color) . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **Ajouter des guides aux diapositives maitre et de mise en page**

Un maitre de diapositive et chacune de ses diapositives de mise en page peuvent posseder leurs propres collections de guides de dessin. Utilisez [MasterSlide::getDrawingGuides](https://reference.aspose.com/slides/fr/php-java/aspose.slides/masterslide/#getDrawingGuides) pour une diapositive maitre et [LayoutSlide::getDrawingGuides](https://reference.aspose.com/slides/fr/php-java/aspose.slides/layoutslide/#getDrawingGuides) pour une diapositive de mise en page.

L'exemple suivant ajoute un guide vertical a la premiere diapositive maitre et un guide horizontal a la premiere diapositive de mise en page :

```php
use aspose\slides\Orientation;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slideSize = $presentation->getSlideSize()->getSize();
    $slideWidth = java_values($slideSize->getWidth());
    $slideHeight = java_values($slideSize->getHeight());
    $masterGuides = $presentation->getMasters()->get_Item(0)->getDrawingGuides();
    $layoutGuides = $presentation->getLayoutSlides()->get_Item(0)->getDrawingGuides();

    $masterGuides->add(Orientation::Vertical, $slideWidth / 2 - 20);
    $layoutGuides->add(Orientation::Horizontal, $slideHeight / 2 + 20);

    $presentation->save("master-layout-drawing-guides.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Ajouter des guides aux maitres de notes et de prospectus**

Les maitres de notes et les maitres de prospectus prennent egalement en charge les guides de dessin. Utilisez [MasterNotesSlide::getDrawingGuides](https://reference.aspose.com/slides/fr/php-java/aspose.slides/masternotesslide/#getDrawingGuides) et [MasterHandoutSlide::getDrawingGuides](https://reference.aspose.com/slides/fr/php-java/aspose.slides/masterhandoutslide/#getDrawingGuides) pour acceder a leurs collections. Si une presentation ne contient pas l'un de ces maitres, recupererez le gestionnaire approprie avec [Presentation::getMasterNotesSlideManager](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/#getMasterNotesSlideManager) ou [Presentation::getMasterHandoutSlideManager](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/#getMasterHandoutSlideManager), puis creerez le maitre par defaut avec `setDefaultMasterNotesSlide` ou `setDefaultMasterHandoutSlide`.

L'exemple suivant ajoute un guide horizontal a un maitre de notes et un guide vertical a un maitre de prospectus :

```php
use aspose\slides\Orientation;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $notesSize = $presentation->getNotesSize()->getSize();
    $notesWidth = java_values($notesSize->getWidth());
    $notesHeight = java_values($notesSize->getHeight());
    $notesMaster = $presentation->getMasterNotesSlideManager()->setDefaultMasterNotesSlide();
    $handoutMaster = $presentation->getMasterHandoutSlideManager()->setDefaultMasterHandoutSlide();

    $notesMaster->getDrawingGuides()->add(Orientation::Horizontal, $notesHeight / 2 + 50);
    $handoutMaster->getDrawingGuides()->add(Orientation::Vertical, $notesWidth / 2 - 50);

    $presentation->save("notes-handout-drawing-guides.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Effacer les guides de dessin**

Appelez [DrawingGuidesCollection::clear](https://reference.aspose.com/slides/fr/php-java/aspose.slides/drawingguidescollection/#clear) pour supprimer chaque guide d'une collection donnee. Le vidage d'une collection n'affecte pas les guides stockes dans un autre perimetre.

L'exemple suivant efface les guides de la vue diapositive et tous les guides sur les maitres de diapositive, les diapositives de mise en page, le maitre de notes et le maitre de prospectus sans creer les maitres manquants :

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation-with-guides.pptx");
try {
    $presentation->getViewProperties()->getSlideViewProperties()->getDrawingGuides()->clear();

    $masterCount = java_values($presentation->getMasters()->size());
    for ($index = 0; $index < $masterCount; $index++) {
        $presentation->getMasters()->get_Item($index)->getDrawingGuides()->clear();
    }

    $layoutCount = java_values($presentation->getLayoutSlides()->size());
    for ($index = 0; $index < $layoutCount; $index++) {
        $presentation->getLayoutSlides()->get_Item($index)->getDrawingGuides()->clear();
    }

    $notesMaster = $presentation->getMasterNotesSlideManager()->getMasterNotesSlide();
    if (!java_is_null($notesMaster)) {
        $notesMaster->getDrawingGuides()->clear();
    }

    $handoutMaster = $presentation->getMasterHandoutSlideManager()->getMasterHandoutSlide();
    if (!java_is_null($handoutMaster)) {
        $handoutMaster->getDrawingGuides()->clear();
    }

    $presentation->save("presentation-without-guides.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Les guides de dessin apparaissent-ils dans un diaporama ou des images exportees ?**

Non. Les guides de dessin sont des aides a l'alignement pour l'edition et ne sont pas rendus comme contenu de la presentation.

**Un guide de dessin peut-il etre ajoute directement a une diapositive normale individuelle ?**

Les guides d'edition pour les diapositives normales sont stockes dans les proprietes de vue de diapositive de la presentation. Des collections de guides separees sont disponibles pour les maitres de diapositive, les diapositives de mise en page, les maitres de notes et les maitres de prospectus.

**Quelles unites sont utilisees pour les positions des guides ?**

Les positions sont specifiees en points, ou 72 points correspondent a un pouce. Les positions verticales sont mesurees depuis le bord gauche, et les positions horizontales depuis le bord superieur.

**Effacer les guides de dessin supprime-t-il des formes ou modifie le contenu de la diapositive ?**

Non. La methode [DrawingGuidesCollection::clear](https://reference.aspose.com/slides/fr/php-java/aspose.slides/drawingguidescollection/#clear) supprime uniquement les guides de la collection selectionnee. Les formes et les autres contenus de la diapositive restent inchanges.