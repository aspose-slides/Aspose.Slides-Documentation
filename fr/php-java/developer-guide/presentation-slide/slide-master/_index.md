---
title: Gérer les masters de diapositives de présentation en PHP
linktitle: Master de diapositive
type: docs
weight: 70
url: /fr/php-java/slide-master/
keywords:
- master de diapositive
- diapositive master
- diapositive master PPT
- plusieurs masters de diapositives
- comparer les masters de diapositives
- arrière-plan
- espace réservé
- cloner la diapositive master
- copier la diapositive master
- dupliquer la diapositive master
- master de diapositive inutilisé
- PowerPoint
- OpenDocument
- présentation
- PHP
- Aspose.Slides
description: "Gérez les masters de diapositives dans Aspose.Slides pour PHP via Java : accédez, modifiez, clonez, comparez et supprimez les masters de diapositives dans les présentations PowerPoint et OpenDocument."
---
## **Aperçu**

Un **slide master** définit des paramètres de conception partagés pour un groupe de diapositives. Il peut contenir des formes communes, des logos, des arrière‑plans, des styles de texte, des paramètres de thème et des paramètres de pied de page. Dans PowerPoint, la modification d’un slide master est la façon habituelle de garder une présentation cohérente sans répéter le même formatage sur chaque diapositive.

Aspose.Slides for PHP via Java prend en charge le même modèle. Une présentation peut contenir une ou plusieurs master slides, et chaque master slide peut contenir plusieurs layout slides. Les diapositives normales ne font généralement pas référence directement à un master slide. À la place, une diapositive normale utilise un layout slide, et ce layout slide appartient à un master slide.

La hiérarchie est :

1. **Slide master** – définit la conception et le thème partagés.  
1. **Layout slide** – définit une disposition spécifique de zones réservées et le formatage au niveau du layout.  
1. **Normal slide** – contient le contenu réel de la présentation et utilise un layout slide.

![The hierarchy of master slides, layout slides, and normal slides](slide-master_2.jpg)

Dans Aspose.Slides, un slide master est représenté par la classe [MasterSlide](https://reference.aspose.com/slides/fr/php-java/aspose.slides/masterslide/). Tous les master slides d’une présentation sont accessibles via la méthode [Presentation.getMasters](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/#getMasters), qui retourne un objet [MasterSlideCollection](https://reference.aspose.com/slides/fr/php-java/aspose.slides/masterslidecollection/).

{{% alert color="info" title="Inheritance" %}}
Lorsque la même propriété est définie à plusieurs niveaux, le niveau le plus spécifique l’emporte. Par exemple, si un master slide et un layout slide définissent tous deux un arrière‑plan, les diapositives basées sur ce layout utilisent l’arrière‑plan du layout. Pour plus d’informations sur les layout slides, voir [Apply or Change Slide Layouts](/slides/fr/php-java/slide-layout/).
{{% /alert %}}

## **Accéder aux Slide Masters**

Dans PowerPoint, vous pouvez ouvrir la vue Slide Master depuis **View** > **Slide Master**.

![The Slide Master command on the PowerPoint View tab](slide-master_3.jpg)

Dans Aspose.Slides, utilisez la méthode `getMasters` pour accéder aux master slides :

```php
$presentation = new Presentation("presentation.pptx");
try {
    $firstMasterSlide = $presentation->getMasters()->get_Item(0);
    $masterSlideCount = $presentation->getMasters()->size();
    $firstMasterLayoutSlideCount = $firstMasterSlide->getLayoutSlides()->size();

    echo "Master slides: " . $masterSlideCount . PHP_EOL;
    echo "Layouts in the first master: " . $firstMasterLayoutSlideCount . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

Vous pouvez également obtenir le master slide utilisé par une diapositive normale via son layout :

```php
$presentation = new Presentation("presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $layoutSlide = $slide->getLayoutSlide();
    $masterSlide = $layoutSlide->getMasterSlide();
    $masterSlideName = $masterSlide->getName();

    echo $masterSlideName . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **Ce qu’un Slide Master contient**

Un master slide est un objet similaire à une diapositive. Il hérite de [BaseSlide](https://reference.aspose.com/slides/fr/php-java/aspose.slides/baseslide/), ce qui lui donne accès à de nombreuses propriétés de diapositive utilisées par les diapositives normales et les layout slides. Les membres spécifiques aux masters sont répertoriés sur la page API de [MasterSlide](https://reference.aspose.com/slides/fr/php-java/aspose.slides/masterslide/).

Parmi les membres les plus couramment utilisés figurent :

| Membre | But |
| --- | --- |
| `getBackground` | Définit l’arrière‑plan au niveau du master. |
| `getShapes` | Stocke les formes placées sur le master, telles que logos, cadres d’image et texte partagé. |
| `getLayoutSlides` | Stocke les layout slides qui appartiennent au master. |
| `getThemeManager` | Donne accès aux API du thème du master. |
| `getHeaderFooterManager` | Contrôle les en‑têtes, pieds de page, dates et numéros de diapositive pour le master et ses layouts enfants. |
| `getDependingSlides` | Retourne les diapositives normales qui dépendent du master via leurs layouts. |

## **Ajouter une image à un Slide Master**

Lorsque vous ajoutez une image à un master slide, elle apparaît sur les diapositives qui utilisent les layouts de ce master. Ceci est utile pour les logos, filigranes, bandes décoratives et autres éléments visuels récurrents.

L’exemple suivant ajoute un logo au premier master slide :

```php
$presentation = new Presentation("presentation.pptx");
try {
    $masterSlide = $presentation->getMasters()->get_Item(0);
    $logoImage = Images::fromFile("logo.png");
    try {
        $presentationImage = $presentation->getImages()->addImage($logoImage);
    } finally {
        $logoImage->dispose();
    }

    $masterSlide->getShapes()->addPictureFrame(
        ShapeType::Rectangle,
        20,
        20,
        80,
        80,
        $presentationImage
    );

    $presentation->save("presentation-with-logo.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Pour plus d’informations sur les cadres d’image, voir [Picture Frame](/slides/fr/php-java/picture-frame/).

## **Contrôler la visibilité des graphiques du master**

Utilisez [BaseSlide::setShowMasterShapes](https://reference.aspose.com/slides/fr/php-java/aspose.slides/baseslide/#setShowMasterShapes) pour masquer les graphiques hérités du master, tels que logos ou formes décoratives, sans les supprimer du master. Passez `false` à [Slide::setShowMasterShapes](https://reference.aspose.com/slides/fr/php-java/aspose.slides/slide/#setShowMasterShapes) sur la diapositive qui doit ignorer ces graphiques et conservez `true` sur les diapositives qui doivent les afficher.

L’exemple autonome suivant crée une bande décorative bleue sur un master et deux diapositives qui utilisent le même layout vierge. La bande est visible sur la première diapositive et masquée sur la seconde. Aucun fichier de présentation ou image d’entrée n’est requis.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideLayoutType;

$presentation = new Presentation();
try {
    $masterSlide = $presentation->getMasters()->get_Item(0);
    $layoutSlide = $masterSlide->getLayoutSlides()->getByType(SlideLayoutType::Blank);
    $layoutSlide->setShowMasterShapes(true);

    $slideHeight = java_values($presentation->getSlideSize()->getSize()->getHeight());
    $band = $masterSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 0, 0, 60, $slideHeight);
    $bandColor = new Java("java.awt.Color", 70, 130, 180);
    $band->getFillFormat()->setFillType(FillType::Solid);
    $band->getFillFormat()->getSolidFillColor()->setColor($bandColor);
    $band->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);

    $visibleSlide = $presentation->getSlides()->get_Item(0);
    $visibleSlide->setLayoutSlide($layoutSlide);
    $visibleSlide->getShapes()->clear();

    $hiddenSlide = $presentation->getSlides()->addEmptySlide($layoutSlide);

    $visibleSlide->setShowMasterShapes(true);
    $hiddenSlide->setShowMasterShapes(false);

    $presentation->save("master-graphics.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

L’exemple utilise le layout **Blank** fourni avec une nouvelle présentation et supprime les zones réservées propres à la diapositive initiale.

### **Choisir la portée du paramètre**

Une diapositive normale utilise son master via [Slide::getLayoutSlide](https://reference.aspose.com/slides/fr/php-java/aspose.slides/slide/#getLayoutSlide) et [LayoutSlide::getMasterSlide](https://reference.aspose.com/slides/fr/php-java/aspose.slides/layoutslide/#getMasterSlide). Le réglage de la propriété sur une diapositive individuelle n’affecte que cette diapositive. Passer `false` à [LayoutSlide::setShowMasterShapes](https://reference.aspose.com/slides/fr/php-java/aspose.slides/layoutslide/#setShowMasterShapes) masque les graphiques du master pour les diapositives qui utilisent ce layout partagé, même si leur propre réglage est `true`. Pour masquer les graphiques sur une seule diapositive, modifiez la propriété de la diapositive et laissez le layout partagé inchangé.

Le paramètre n’est pas pris en charge comme contrôle de visibilité sur le master slide lui‑même. Sur un master, [getShowMasterShapes](https://reference.aspose.com/slides/fr/php-java/aspose.slides/masterslide/#getShowMasterShapes) renvoie toujours `false`, et passer `true` à [setShowMasterShapes](https://reference.aspose.com/slides/fr/php-java/aspose.slides/masterslide/#setShowMasterShapes) génère une exception. Appliquez‑le à une diapositive normale ou à un layout à la place.

### **Différencier les graphiques de l’arrière‑plan**

| Opération | Effet |
| --- | --- |
| Masquer les graphiques du master | Contrôle la visibilité des formes héritées du master sans les supprimer ni modifier les formes propres à la diapositive. |
| Modifier le remplissage d’arrière‑plan de la diapositive | Change la couleur, le dégradé ou l’image d’arrière‑plan. Les graphiques du master restent des formes séparées et peuvent rester visibles au‑dessus de cet arrière‑plan. Voir [Presentation Background](/slides/fr/php-java/presentation-background/). |
| Supprimer une forme du master | Supprime la forme source partagée, de sorte qu’elle ne soit plus disponible pour aucune diapositive utilisant ce master. |

## **Travailler avec les espaces réservés**

Les espaces réservés sont généralement définis sur les layout slides. Le master slide fournit le style et le thème partagés que ces layouts héritent, chaque layout décidant quels espaces réservés sont disponibles et où ils sont placés.

Dans PowerPoint, les commandes d’espace réservé sont disponibles en mode Slide Master.

![The Insert Placeholder command in PowerPoint Slide Master view](slide-master_5.png)

Pour ajouter de nouveaux espaces réservés avec Aspose.Slides, travaillez sur le layout slide qui appartient au master :

```php
$presentation = new Presentation("presentation.pptx");
try {
    $masterSlide = $presentation->getMasters()->get_Item(0);
    $blankLayoutSlideName = "Custom Blank";
    $blankLayoutSlide = $masterSlide->getLayoutSlides()->add(
        SlideLayoutType::Blank,
        $blankLayoutSlideName
    );

    $blankLayoutSlide->getPlaceholderManager()->addTextPlaceholder(
        60,
        120,
        600,
        80
    );

    $presentation->getSlides()->addEmptySlide($blankLayoutSlide);
    $presentation->save("presentation-with-placeholder.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Vous pouvez également mettre en forme les formes d’espace réservé déjà présentes sur un master slide. L’exemple suivant trouve l’espace réservé de titre et applique un remplissage dégradé linéaire :

```php
$presentation = new Presentation("presentation.pptx");
try {
    $masterSlide = $presentation->getMasters()->get_Item(0);
    $titlePlaceholder = findPlaceholder($masterSlide, PlaceholderType::Title);

    if (!java_is_null($titlePlaceholder)) {
        $redGradientColor = java("java.awt.Color")->RED;
        $purpleGradientColor = new Java("java.awt.Color", 128, 0, 128);

        $fillFormat = $titlePlaceholder->getFillFormat();
        $fillFormat->setFillType(FillType::Gradient);
        $gradientFormat = $fillFormat->getGradientFormat();
        $gradientFormat->setGradientShape(GradientShape::Linear);
        $gradientStops = $gradientFormat->getGradientStops();
        $gradientStops->add(0, $redGradientColor);
        $gradientStops->add(255, $purpleGradientColor);
    }

    $presentation->save("presentation-title-style.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

function findPlaceholder($masterSlide, $placeholderType)
{
    $shapesCount = java_values($masterSlide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapesCount; $shapeIndex++) {
        $shape = $masterSlide->getShapes()->get_Item($shapeIndex);
        $placeholder = $shape->getPlaceholder();

        if (!java_is_null($placeholder) && java_values($placeholder->getType()) == $placeholderType) {
            return $shape;
        }
    }

    return null;
}
```

![Formatted title placeholder inherited by normal slides](slide-master_8.png)

Pour plus d’options de mise en forme d’espace réservé et de texte, voir [Set Prompt Text in Placeholder](/slides/fr/php-java/manage-placeholder/) et [Text Formatting](/slides/fr/php-java/text-formatting/).

## **Modifier l’arrière‑plan d’un Slide Master**

Un arrière‑plan de master est hérité par les layouts et les diapositives qui ne le remplacent pas. L’exemple suivant définit une couleur d’arrière‑plan unie pour le premier master slide :

```php
$presentation = new Presentation("presentation.pptx");
try {
    $masterSlide = $presentation->getMasters()->get_Item(0);
    $forestGreenColor = new Java("java.awt.Color", 34, 139, 34);

    $background = $masterSlide->getBackground();
    $background->setType(BackgroundType::OwnBackground);
    $fillFormat = $background->getFillFormat();
    $fillFormat->setFillType(FillType::Solid);
    $fillFormat->getSolidFillColor()->setColor($forestGreenColor);

    $presentation->save("presentation-master-background.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Pour les sujets connexes, voir [Presentation Background](/slides/fr/php-java/presentation-background/) et [Presentation Theme](/slides/fr/php-java/presentation-theme/).

## **Cloner un Slide Master vers une autre présentation**

Utilisez `addClone` depuis [MasterSlideCollection](https://reference.aspose.com/slides/fr/php-java/aspose.slides/masterslidecollection/) pour copier un master slide dans une autre présentation. Le master copié peut alors être utilisé par les layouts et les diapositives de la présentation de destination.

```php
$sourcePresentation = new Presentation("source.pptx");
$destinationPresentation = new Presentation("destination.pptx");
try {
    $sourceMasterSlide = $sourcePresentation->getMasters()->get_Item(0);
    $clonedMasterSlide = $destinationPresentation->getMasters()->addClone($sourceMasterSlide);

    $destinationPresentation->save("destination-with-master.pptx", SaveFormat::Pptx);
} finally {
    $destinationPresentation->dispose();
    $sourcePresentation->dispose();
}
```

Si vous devez cloner des diapositives normales avec leur master, voir [Clone Slides](/slides/fr/php-java/clone-slides/).

## **Ajouter plusieurs Slide Masters**

Une présentation peut contenir plusieurs master slides. Cela est utile lorsque différentes sections nécessitent des marques, structures de page ou paramètres de thème différents.

![PowerPoint commands for inserting and managing master slides](slide-master_9.jpg)

L’exemple suivant clone le master par défaut, donne au clone un arrière‑plan différent, crée un layout sous ce master cloné et ajoute une nouvelle diapositive basée sur ce layout :

```php
$presentation = new Presentation("presentation.pptx");
try {
    $defaultMasterSlide = $presentation->getMasters()->get_Item(0);
    $sectionMasterSlide = $presentation->getMasters()->addClone($defaultMasterSlide);
    $lightSteelBlueColor = new Java("java.awt.Color", 176, 196, 222);

    $background = $sectionMasterSlide->getBackground();
    $background->setType(BackgroundType::OwnBackground);
    $fillFormat = $background->getFillFormat();
    $fillFormat->setFillType(FillType::Solid);
    $fillFormat->getSolidFillColor()->setColor($lightSteelBlueColor);

    $sourceBlankLayout = $defaultMasterSlide->getLayoutSlides()->get_Item(0);
    $sectionBlankLayout = $sectionMasterSlide->getLayoutSlides()->addClone($sourceBlankLayout);

    $presentation->getSlides()->addEmptySlide($sectionBlankLayout);
    $presentation->save("presentation-with-multiple-masters.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Comparer les Slide Masters**

Les master slides peuvent être comparés avec la méthode `equals` héritée de [BaseSlide](https://reference.aspose.com/slides/fr/php-java/aspose.slides/baseslide/). La comparaison vérifie la structure et le contenu statique, tels que les formes, le texte, le formatage, les animations et les autres paramètres de diapositive. Elle ne compare pas les identifiants uniques, comme les IDs de diapositive, ni les valeurs dynamiques d’espaces réservés, comme la date actuelle.

```php
$firstPresentation = new Presentation("first.pptx");
$secondPresentation = new Presentation("second.pptx");
try {
    $firstPresentationMasterCount = java_values($firstPresentation->getMasters()->size());
    $secondPresentationMasterCount = java_values($secondPresentation->getMasters()->size());

    for ($firstMasterIndex = 0; $firstMasterIndex < $firstPresentationMasterCount; $firstMasterIndex++) {
        for ($secondMasterIndex = 0; $secondMasterIndex < $secondPresentationMasterCount; $secondMasterIndex++) {
            $firstMasterSlide = $firstPresentation->getMasters()->get_Item($firstMasterIndex);
            $secondMasterSlide = $secondPresentation->getMasters()->get_Item($secondMasterIndex);
            $areMasterSlidesEqual = $firstMasterSlide->equals($secondMasterSlide);

            if ($areMasterSlidesEqual) {
                echo "first.pptx master #" . $firstMasterIndex .
                    " equals second.pptx master #" . $secondMasterIndex . PHP_EOL;
            }
        }
    }
} finally {
    $secondPresentation->dispose();
    $firstPresentation->dispose();
}
```

Pour plus d’informations, voir [Compare Presentation Slides](/slides/fr/php-java/compare-slides/).

## **Définir la vue Slide Master comme vue par défaut**

Utilisez la méthode `setLastView` sur [ViewProperties](https://reference.aspose.com/slides/fr/php-java/aspose.slides/viewproperties/) pour contrôler la vue que PowerPoint ouvre en premier. L’exemple suivant ouvre la présentation en vue Slide Master :

```php
$presentation = new Presentation("presentation.pptx");
try {
    $presentation->getViewProperties()->setLastView(ViewType::SlideMasterView);
    $presentation->save("presentation-master-view.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Pour d’autres paramètres de vue, voir [Save Presentation](/slides/fr/php-java/save-presentation/).

## **Supprimer les Slide Masters inutilisés**

Les présentations contiennent parfois des master slides qui ne sont plus utilisés par aucune diapositive normale. Supprimer les masters inutilisés peut réduire la taille du fichier et simplifier la maintenance du modèle.

Utilisez `removeUnused` depuis [MasterSlideCollection](https://reference.aspose.com/slides/fr/php-java/aspose.slides/masterslidecollection/) pour supprimer les masters inutilisés de la collection `getMasters` :

```php
$presentation = new Presentation("presentation.pptx");
try {
    $presentation->getMasters()->removeUnused(true);
    $presentation->save("presentation-clean.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Vous pouvez également utiliser la méthode low‑code `removeUnusedMasterSlides` de la classe [Compress](https://reference.aspose.com/slides/fr/php-java/aspose.slides/compress/) :

```php
$presentation = new Presentation("presentation.pptx");
try {
    Compress::removeUnusedMasterSlides($presentation);
    $presentation->save("presentation-clean.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Quelle est la différence entre un slide master et un layout slide ?**

Un slide master définit des paramètres de conception partagés tels que le thème, l’arrière‑plan, les formes communes et les styles de texte. Un layout slide appartient à un master slide et définit une disposition spécifique d’espaces réservés. Une diapositive normale utilise un layout slide, elle hérite donc à la fois du layout et du master.

**Une présentation peut‑elle contenir plusieurs slide masters ?**

Oui. Une présentation peut contenir plusieurs slide masters. Utilisez plusieurs masters lorsque différentes sections nécessitent des systèmes visuels ou des marques différentes.

**Dois‑je ajouter des espaces réservés à un master slide ou à un layout slide ?**

Dans la majorité des cas, ajoutez les espaces réservés aux layout slides. Placez les éléments visuels partagés et le formatage partagé sur le master slide, puis placez les espaces réservés de contenu sur les layouts que les diapositives normales utiliseront.

**Puis‑je supprimer un slide master qui est encore utilisé ?**

Non. Un slide master qui possède des diapositives dépendantes ne peut pas être supprimé en toute sécurité. Déplacez d’abord ces diapositives vers des layouts sous un autre master, ou utilisez une méthode de nettoyage des masters non utilisés qui ne supprime que les masters qui ne sont pas en usage.