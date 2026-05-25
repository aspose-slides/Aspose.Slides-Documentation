---
title: Gérer les masques de diapositives de présentation en PHP
linktitle: Masque de diapositive
type: docs
weight: 70
url: /fr/php-java/slide-master/
keywords:
- masque de diapositive
- diapositive maître
- diapositive maître PPT
- plusieurs masques de diapositives
- comparer les masques de diapositives
- arrière-plan
- espace réservé
- cloner la diapositive maître
- copier la diapositive maître
- dupliquer la diapositive maître
- masque de diapositive inutilisé
- PowerPoint
- OpenDocument
- présentation
- PHP
- Aspose.Slides
description: "Gérez les masques de diapositives dans Aspose.Slides pour PHP via Java : accédez, modifiez, clonez, comparez et supprimez les masques de diapositives dans les présentations PowerPoint et OpenDocument."
---
## **Aperçu**

Un **masque de diapositive** définit des paramètres de conception partagés pour un groupe de diapositives. Il peut contenir des formes communes, des logos, des arrière‑plans, des styles de texte, des paramètres de thème et des paramètres de pied de page. Dans PowerPoint, la modification d’un masque de diapositive est la façon habituelle de garder une présentation cohérente sans répéter le même formatage sur chaque diapositive.

Aspose.Slides for PHP via Java prend en charge le même modèle. Une présentation peut contenir une ou plusieurs masques de diapositives, et chaque masque de diapositive peut contenir plusieurs dispositions de diapositives. Les diapositives normales ne font généralement pas référence directement à un masque de diapositive. Au lieu de cela, une diapositive normale utilise une disposition de diapositive, et cette disposition appartient à un masque de diapositive.

La hiérarchie est :

1. **Masque de diapositive** – définit la conception et le thème partagés.  
1. **Disposition de diapositive** – définit un arrangement spécifique d’emplacements réservés et de formatage au niveau de la disposition.  
1. **Diapositive normale** – contient le contenu réel de la présentation et utilise une disposition de diapositive.

![The hierarchy of master slides, layout slides, and normal slides](slide-master_2.jpg)

Dans Aspose.Slides, un masque de diapositive est représenté par la classe [MasterSlide](https://reference.aspose.com/slides/fr/php-java/aspose.slides/masterslide/). Tous les masques de diapositives d’une présentation sont accessibles via la méthode [Presentation.getMasters](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/#getMasters), qui renvoie un objet [MasterSlideCollection](https://reference.aspose.com/slides/fr/php-java/aspose.slides/masterslidecollection/).

{{% alert color="info" title="Héritage" %}}

Lorsque la même propriété est définie à plusieurs niveaux, le niveau le plus spécifique l’emporte. Par exemple, si un masque de diapositive et une disposition de diapositive définissent tous deux un arrière‑plan, les diapositives basées sur cette disposition utilisent l’arrière‑plan de la disposition. Pour plus d’informations sur les dispositions de diapositives, voir [Apply or Change Slide Layouts](/slides/fr/php-java/slide-layout/).

{{% /alert %}}

## **Accéder aux masques de diapositives**

Dans PowerPoint, vous pouvez ouvrir la vue Masque des diapositives depuis **Affichage** > **Masque des diapositives**.

![The Slide Master command on the PowerPoint View tab](slide-master_3.jpg)

Dans Aspose.Slides, utilisez la méthode `getMasters` pour accéder aux masques de diapositives :

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

Vous pouvez également obtenir le masque de diapositive utilisé par une diapositive normale via sa disposition :

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

## **Contenu d’un masque de diapositive**

Un masque de diapositive est un objet semblable à une diapositive. Il hérite de [BaseSlide](https://reference.aspose.com/slides/fr/php-java/aspose.slides/baseslide/), ce qui lui donne accès à de nombreuses propriétés de diapositive également utilisées par les diapositives normales et les dispositions. Les membres spécifiques au masque sont répertoriés sur la page API [MasterSlide](https://reference.aspose.com/slides/fr/php-java/aspose.slides/masterslide/).

Les membres les plus couramment utilisés sont :

| Membre | Objectif |
| --- | --- |
| `getBackground` | Définit l’arrière‑plan au niveau du masque. |
| `getShapes` | Contient les formes placées sur le masque, comme les logos, les cadres d’image et le texte partagé. |
| `getLayoutSlides` | Contient les dispositions qui appartiennent au masque. |
| `getThemeManager` | Fournit l’accès aux API du thème du masque. |
| `getHeaderFooterManager` | Contrôle les en‑têtes, pieds de page, dates et numéros de diapositive pour le masque et ses dispositions enfant. |
| `getDependingSlides` | Retourne les diapositives normales qui dépendent du masque via leurs dispositions. |

## **Ajouter une image à un masque de diapositive**

Lorsque vous ajoutez une image à un masque de diapositive, elle apparaît sur les diapositives qui utilisent des dispositions de ce masque. Cela est utile pour les logos, filigranes, bandes décoratives et autres éléments visuels répétés.

L’exemple suivant ajoute un logo au premier masque de diapositive :

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

## **Travailler avec les espaces réservés**

Les espaces réservés sont généralement définis sur les dispositions de diapositives. Le masque de diapositive fournit le style et le thème partagés que ces dispositions héritent, tandis que chaque disposition décide quels espaces réservés sont disponibles et où ils sont placés.

Dans PowerPoint, les commandes d’espace réservé sont disponibles dans la vue Masque des diapositives.

![The Insert Placeholder command in PowerPoint Slide Master view](slide-master_5.png)

Pour ajouter de nouveaux espaces réservés avec Aspose.Slides, travaillez sur la disposition qui appartient au masque :

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

Vous pouvez également mettre en forme les formes d’espace réservé déjà présentes sur un masque de diapositive. L’exemple suivant trouve l’espace réservé de titre et applique un remplissage en dégradé linéaire :

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

Pour plus d’options de mise en forme des espaces réservés et du texte, voir [Set Prompt Text in Placeholder](/slides/fr/php-java/manage-placeholder/) et [Text Formatting](/slides/fr/php-java/text-formatting/).

## **Modifier l’arrière‑plan d’un masque de diapositive**

Un arrière‑plan de masque est hérité par les dispositions et les diapositives qui ne le remplacent pas. L’exemple suivant définit une couleur d’arrière‑plan unie pour le premier masque de diapositive :

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

Pour les sujets associés, voir [Presentation Background](/slides/fr/php-java/presentation-background/) et [Presentation Theme](/slides/fr/php-java/presentation-theme/).

## **Cloner un masque de diapositive vers une autre présentation**

Utilisez `addClone` depuis [MasterSlideCollection](https://reference.aspose.com/slides/fr/php-java/aspose.slides/masterslidecollection/) pour copier un masque de diapositive dans une autre présentation. Le masque copié peut alors être utilisé par les dispositions et les diapositives de la présentation de destination.

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

Si vous devez cloner des diapositives normales avec leur masque, voir [Clone Slides](/slides/fr/php-java/clone-slides/).

## **Ajouter plusieurs masques de diapositives**

Une présentation peut contenir plusieurs masques de diapositives. Cela est utile lorsque différentes sections nécessitent une identité visuelle, une structure de page ou des paramètres de thème distincts.

![PowerPoint commands for inserting and managing master slides](slide-master_9.jpg)

L’exemple suivant clone le masque par défaut, donne au clone un arrière‑plan différent, crée une disposition sous ce masque cloné et ajoute une nouvelle diapositive basée sur cette disposition :

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

## **Comparer les masques de diapositives**

Les masques de diapositives peuvent être comparés avec la méthode `equals` héritée de [BaseSlide](https://reference.aspose.com/slides/fr/php-java/aspose.slides/baseslide/). La comparaison vérifie la structure et le contenu statique, tels que les formes, le texte, le formatage, les animations et d’autres paramètres de diapositive. Elle ne compare pas les identifiants uniques, comme les IDs de diapositive, ni les valeurs dynamiques des espaces réservés, comme la date actuelle.

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

## **Définir la vue Masque de diapositives comme vue par défaut**

Utilisez la méthode `setLastView` sur [ViewProperties](https://reference.aspose.com/slides/fr/php-java/aspose.slides/viewproperties/) pour contrôler la vue que PowerPoint ouvre en premier. L’exemple suivant ouvre la présentation en vue Masque de diapositives :

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

## **Supprimer les masques de diapositives inutilisés**

Les présentations contiennent parfois des masques de diapositives qui ne sont plus utilisés par aucune diapositive normale. Supprimer les masques inutilisés peut réduire la taille du fichier et simplifier la maintenance du modèle.

Utilisez `removeUnused` depuis [MasterSlideCollection](https://reference.aspose.com/slides/fr/php-java/aspose.slides/masterslidecollection/) pour retirer les masques inutilisés de la collection `getMasters` :

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

**Quelle est la différence entre un masque de diapositive et une disposition de diapositive ?**

Un masque de diapositive définit des paramètres de conception partagés tels que le thème, l’arrière‑plan, les formes communes et les styles de texte. Une disposition de diapositive appartient à un masque et définit un arrangement spécifique d’espaces réservés. Une diapositive normale utilise une disposition, elle hérite donc à la fois de la disposition et du masque.

**Une présentation peut‑elle contenir plusieurs masques de diapositives ?**

Oui. Une présentation peut contenir plusieurs masques de diapositives. Utilisez plusieurs masques lorsque différentes sections nécessitent des systèmes visuels ou une identité de marque différents.

**Dois‑je ajouter des espaces réservés à un masque de diapositive ou à une disposition ?**

Dans la plupart des cas, ajoutez les espaces réservés aux dispositions. Placez les éléments visuels partagés et le formatage commun sur le masque, puis mettez les espaces réservés de contenu sur les dispositions que les diapositives normales utiliseront.

**Puis‑je supprimer un masque de diapositive qui est encore utilisé ?**

Non. Un masque de diapositive qui possède des diapositives dépendantes ne peut pas être supprimé directement. Déplacez d’abord ces diapositives vers des dispositions d’un autre masque, ou utilisez une méthode de nettoyage des masques inutilisés qui ne retire que les masques qui ne sont pas en usage.