---
title: Gérer les espaces réservés de présentation en PHP
linktitle: Gérer les espaces réservés
type: docs
weight: 10
url: /fr/php-java/manage-placeholder/
keywords:
- espace réservé
- espace réservé de texte
- espace réservé d'image
- espace réservé de graphique
- espace réservé de contenu
- texte d’invite
- PowerPoint
- présentation
- PHP
- Aspose.Slides
description: "Apprenez à inspecter et modifier les espaces réservés de texte, d’image, de graphique et de contenu et à comprendre l’héritage des espaces réservés avec Aspose.Slides pour PHP via Java."
---
## **Vue d'ensemble**

Un espace réservé est une forme qui réserve une position pour un type particulier de contenu dans un modèle de présentation. Les exemples courants sont les espaces réservés de titre, de corps, d’image, de graphique et de contenu à usage général. Contrairement à une forme ordinaire, un espace réservé peut hériter de sa position, de sa taille, de son formatage et d’autres paramètres d’une diapositive de mise en page ou d’une diapositive maître.

Aspose.Slides expose les informations d’espace réservé via la méthode [Shape::getPlaceholder](https://reference.aspose.com/slides/fr/php-java/aspose.slides/shape/getplaceholder/). La méthode renvoie un objet [Placeholder](https://reference.aspose.com/slides/fr/php-java/aspose.slides/placeholder/) ou `null` pour une forme normale. Utilisez [Placeholder::getType](https://reference.aspose.com/slides/fr/php-java/aspose.slides/placeholder/gettype/) pour déterminer ce que l’espace réservé est censé contenir.

La classe de forme reste importante après avoir connu le type d’espace réservé :

- Un espace réservé de texte, d’image, de graphique ou de contenu vide est généralement représenté par un [AutoShape](https://reference.aspose.com/slides/fr/php-java/aspose.slides/autoshape/).
- Un espace réservé d’image rempli peut être représenté par un [PictureFrame](https://reference.aspose.com/slides/fr/php-java/aspose.slides/pictureframe/).
- Un espace réservé de graphique rempli peut être représenté par un [Chart](https://reference.aspose.com/slides/fr/php-java/aspose.slides/chart/).
- Un espace réservé de contenu peut contenir plusieurs types de contenu. Vérifiez à la fois [Placeholder::getType](https://reference.aspose.com/slides/fr/php-java/aspose.slides/placeholder/gettype/) et la classe de forme d’exécution au lieu de supposer que chaque espace réservé est un [AutoShape](https://reference.aspose.com/slides/fr/php-java/aspose.slides/autoshape/).

{{% alert color="warning" title="Warning" %}}
[Placeholder::getType](https://reference.aspose.com/slides/fr/php-java/aspose.slides/placeholder/gettype/) décrit le rôle d’un espace réservé ; il ne garantit pas la classe d’exécution de la forme. Utilisez toujours une vérification de type avant d’accéder aux membres spécifiques au texte, à l’image, au graphique, au tableau ou aux médias.
{{% /alert %}}

## **Comprendre l’héritage des espaces réservés**

Les espaces réservés forment une hiérarchie :

1. Une diapositive maître définit des styles réutilisables et, dans certains cas, des espaces réservés au niveau du maître.
2. Une diapositive de mise en page définit la disposition utilisée par une ou plusieurs diapositives normales et peut hériter du maître.
3. Une diapositive normale contient les espaces réservés pour cette diapositive et peut hériter de sa mise en page.

Appelez [Shape::getBasePlaceholder](https://reference.aspose.com/slides/fr/php-java/aspose.slides/shape/getbaseplaceholder/) pour remonter d’un niveau dans cette hiérarchie. Un espace réservé de diapositive renvoie normalement son espace réservé de mise en page ; un espace réservé de mise en page peut renvoyer son espace réservé maître. La méthode renvoie `null` lorsque la forme n’a pas d’espace réservé de base.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $shapeCountValue = $shapes->size();
    $shapeCount = java_values($shapeCountValue);

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $placeholder = $shape->getPlaceholder();
        if (java_is_null($placeholder)) {
            continue;
        }

        $placeholderTypeValue = $placeholder->getType();
        $placeholderType = java_values($placeholderTypeValue);
        $shapeClass = $shape->getClass();
        $shapeClassNameValue = $shapeClass->getSimpleName();
        $shapeClassName = java_values($shapeClassNameValue);
        echo "Slide placeholder: " . $placeholderType . "; shape class: " . $shapeClassName . PHP_EOL;

        $layoutPlaceholder = $shape->getBasePlaceholder();
        if (!java_is_null($layoutPlaceholder)) {
            $layoutPlaceholderInfo = $layoutPlaceholder->getPlaceholder();
            if (!java_is_null($layoutPlaceholderInfo)) {
                $layoutPlaceholderTypeValue = $layoutPlaceholderInfo->getType();
                $layoutPlaceholderType = java_values($layoutPlaceholderTypeValue);
                echo "  Layout placeholder: " . $layoutPlaceholderType . PHP_EOL;
            }

            $masterPlaceholder = $layoutPlaceholder->getBasePlaceholder();
            if (!java_is_null($masterPlaceholder)) {
                $masterPlaceholderInfo = $masterPlaceholder->getPlaceholder();
                if (!java_is_null($masterPlaceholderInfo)) {
                    $masterPlaceholderTypeValue = $masterPlaceholderInfo->getType();
                    $masterPlaceholderType = java_values($masterPlaceholderTypeValue);
                    echo "  Master placeholder: " . $masterPlaceholderType . PHP_EOL;
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

Modifier un espace réservé sur une diapositive normale crée ou modifie une substitution locale pour cette diapositive. Modifier la mise en page ou le maître associé peut affecter toutes les diapositives qui héritent encore de ce paramètre. Une forme locale ordinaire n’a pas d’espace réservé de base et ne commence pas à hériter simplement parce qu’elle occupe les mêmes coordonnées.

## **Modifier le texte d’un espace réservé**

Les espaces réservés de titre, de titre centré, de sous‑titre, de corps et de texte prennent généralement en charge le texte. Vérifiez la présence d’un [AutoShape](https://reference.aspose.com/slides/fr/php-java/aspose.slides/autoshape/) avant d’utiliser sa méthode [getTextFrame](https://reference.aspose.com/slides/fr/php-java/aspose.slides/autoshape/gettextframe/).

```php
use aspose\slides\PlaceholderType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $shapeCountValue = $shapes->size();
    $shapeCount = java_values($shapeCountValue);
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    $titleShape = null;

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        if (!java_instanceof($shape, $autoShapeClass)) {
            continue;
        }

        $placeholder = $shape->getPlaceholder();
        if (java_is_null($placeholder)) {
            continue;
        }

        $placeholderTypeValue = $placeholder->getType();
        $placeholderType = java_values($placeholderTypeValue);
        if ($placeholderType === PlaceholderType::Title || $placeholderType === PlaceholderType::CenteredTitle) {
            $titleShape = $shape;
            break;
        }
    }

    if ($titleShape === null) {
        throw new RuntimeException("The first slide does not contain a title placeholder.");
    }

    $titleShape->getTextFrame()->setText("Quarterly Business Review");
    $presentation->save("title-placeholder-updated.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Ce modèle évite de traiter les espaces réservés d’image, de graphique, de tableau ou de médias comme des objets [AutoShape](https://reference.aspose.com/slides/fr/php-java/aspose.slides/autoshape/). Il identifie également l’espace réservé par son objectif au lieu de se fier à un indice de forme fragile.

## **Définir le texte d’invite sur une mise en page**

Le texte d’invite est l’instruction affichée en mode conception dans un espace réservé vide, comme *Cliquez pour ajouter un titre*. Définissez un texte d’invite personnalisé sur l’espace réservé de mise en page plutôt que d’essayer d’y accéder via la collection de formes d’une diapositive normale. Accédez à la mise en page via [Slide::getLayoutSlide](https://reference.aspose.com/slides/fr/php-java/aspose.slides/slide/#getLayoutSlide) et parcourez la collection renvoyée par [BaseSlide::getShapes](https://reference.aspose.com/slides/fr/php-java/aspose.slides/baseslide/#getShapes).

```php
use aspose\slides\PlaceholderType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $layoutSlide = $slide->getLayoutSlide();
    $shapes = $layoutSlide->getShapes();
    $shapeCountValue = $shapes->size();
    $shapeCount = java_values($shapeCountValue);
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        if (!java_instanceof($shape, $autoShapeClass)) {
            continue;
        }

        $placeholder = $shape->getPlaceholder();
        if (java_is_null($placeholder)) {
            continue;
        }

        $placeholderTypeValue = $placeholder->getType();
        $placeholderType = java_values($placeholderTypeValue);
        if ($placeholderType === PlaceholderType::Title || $placeholderType === PlaceholderType::CenteredTitle) {
            $shape->getTextFrame()->setText("Enter a concise slide title");
        } elseif ($placeholderType === PlaceholderType::Subtitle) {
            $shape->getTextFrame()->setText("Enter a subtitle or reporting period");
        }
    }

    $presentation->save("custom-placeholder-prompts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Le texte d’invite n’est pas un contenu de diapositive normal. Il est destiné aux espaces réservés vides dans les applications d’édition telles que PowerPoint. Une fois qu’un utilisateur ou un programme fournit du contenu réel, l’invite n’est plus affichée. Modifier une invite ne remplace pas non plus le texte existant sur les diapositives qui utilisent la mise en page.

## **Mettre à jour un espace réservé d’image**

Il y a deux cas à gérer :

- Si l’espace réservé d’image est déjà rempli et représenté par un [PictureFrame](https://reference.aspose.com/slides/fr/php-java/aspose.slides/pictureframe/), remplacez l’image via [PictureFillFormat::getPicture](https://reference.aspose.com/slides/fr/php-java/aspose.slides/picturefillformat/getpicture/) et [SlidesPicture::setImage](https://reference.aspose.com/slides/fr/php-java/aspose.slides/slidespicture/setimage/).
- S’il s’agit encore d’un espace réservé vide, ajoutez un cadre image aux coordonnées de l’espace réservé avec [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/fr/php-java/aspose.slides/shapecollection/addpictureframe/) et supprimez l’espace réservé vide.

```php
use aspose\slides\PlaceholderType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation("picture-template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $shapeCountValue = $shapes->size();
    $shapeCount = java_values($shapeCountValue);
    $pictureFrameClass = new JavaClass("com.aspose.slides.PictureFrame");
    $picturePlaceholder = null;

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $placeholder = $shape->getPlaceholder();
        if (java_is_null($placeholder)) {
            continue;
        }

        $placeholderTypeValue = $placeholder->getType();
        $placeholderType = java_values($placeholderTypeValue);
        if ($placeholderType === PlaceholderType::Picture) {
            $picturePlaceholder = $shape;
            break;
        }
    }

    if ($picturePlaceholder === null) {
        throw new RuntimeException("The first slide does not contain a picture placeholder.");
    }

    $imageData = file_get_contents("replacement.png");
    $image = $presentation->getImages()->addImage($imageData);

    if (java_instanceof($picturePlaceholder, $pictureFrameClass)) {
        $picture = $picturePlaceholder->getPictureFormat()->getPicture();
        $picture->setImage($image);
    } else {
        $x = $picturePlaceholder->getX();
        $y = $picturePlaceholder->getY();
        $width = $picturePlaceholder->getWidth();
        $height = $picturePlaceholder->getHeight();
        $shapes->addPictureFrame(ShapeType::Rectangle, $x, $y, $width, $height, $image);
        $shapes->remove($picturePlaceholder);
    }

    $presentation->save("picture-placeholder-updated.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Le remplacement créé pour un espace réservé vide est un cadre image local, pas un nouvel espace réservé, car [Shape::getPlaceholder](https://reference.aspose.com/slides/fr/php-java/aspose.slides/shape/getplaceholder/) ne propose pas de mutateur. Il conserve la position réservée mais n’hérite plus du comportement propre aux espaces réservés. Si la conservation de la relation d’espace réservé est essentielle, préparez et remplissez l’espace réservé dans PowerPoint d’abord, puis mettez à jour le [PictureFrame](https://reference.aspose.com/slides/fr/php-java/aspose.slides/pictureframe/) résultant avec Aspose.Slides.

Pour la transparence d’image, le recadrage et d’autres effets spécifiques aux images, consultez [Manage Picture Frames](/slides/fr/php-java/picture-frame/). Ces opérations concernent le cadre image ou le remplissage d’image, pas les métadonnées d’espace réservé.

## **Travailler avec des espaces réservés de graphique et de contenu**

Un espace réservé de graphique rempli peut être représenté par un [Chart](https://reference.aspose.com/slides/fr/php-java/aspose.slides/chart/). Cet exemple trouve un tel graphique en fonction du type d’espace réservé et de la classe d’exécution, modifie son titre et enregistre le fichier :

```php
use aspose\slides\PlaceholderType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("chart-template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $shapeCountValue = $shapes->size();
    $shapeCount = java_values($shapeCountValue);
    $chartClass = new JavaClass("com.aspose.slides.Chart");
    $placeholderChart = null;

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        if (!java_instanceof($shape, $chartClass)) {
            continue;
        }

        $placeholder = $shape->getPlaceholder();
        if (java_is_null($placeholder)) {
            continue;
        }

        $placeholderTypeValue = $placeholder->getType();
        $placeholderType = java_values($placeholderTypeValue);
        if ($placeholderType === PlaceholderType::Chart) {
            $placeholderChart = $shape;
            break;
        }
    }

    if ($placeholderChart === null) {
        throw new RuntimeException("The first slide does not contain a populated chart placeholder.");
    }

    $placeholderChart->setTitle(true);
    $placeholderChart->getChartTitle()->addTextFrameForOverriding("Quarterly Revenue");
    $presentation->save("chart-placeholder-updated.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Un espace réservé de contenu général possède généralement [PlaceholderType::Object](https://reference.aspose.com/slides/fr/php-java/aspose.slides/placeholdertype/). Dans PowerPoint, il agit comme un lanceur pour plusieurs types de contenu, notamment les graphiques, les tableaux, les diagrammes, les images et les médias. Après qu’il a été rempli, inspectez la classe de forme réelle pour savoir ce qu’il contient. Des mises en page spécialisées peuvent également exposer [PlaceholderType::Chart](https://reference.aspose.com/slides/fr/php-java/aspose.slides/placeholdertype/), [PlaceholderType::Table](https://reference.aspose.com/slides/fr/php-java/aspose.slides/placeholdertype/), [PlaceholderType::Picture](https://reference.aspose.com/slides/fr/php-java/aspose.slides/placeholdertype/), [PlaceholderType::Media](https://reference.aspose.com/slides/fr/php-java/aspose.slides/placeholdertype/), ou [PlaceholderType::Diagram](https://reference.aspose.com/slides/fr/php-java/aspose.slides/placeholdertype/).

Aspose.Slides ne convertit pas un espace réservé [AutoShape](https://reference.aspose.com/slides/fr/php-java/aspose.slides/autoshape/) vide en [Chart](https://reference.aspose.com/slides/fr/php-java/aspose.slides/chart/) simplement en modifiant [Placeholder::getType](https://reference.aspose.com/slides/fr/php-java/aspose.slides/placeholder/gettype/) ; le type ne peut pas être changé via la classe. Pour remplir programmatically une zone de graphique ou de contenu vide, ajoutez l’objet requis aux coordonnées de l’espace réservé puis supprimez l’espace réservé vide. L’exemple suivant réalise cela pour un graphique :

```php
use aspose\slides\ChartType;
use aspose\slides\PlaceholderType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("content-template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $shapeCountValue = $shapes->size();
    $shapeCount = java_values($shapeCountValue);
    $targetPlaceholder = null;

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $placeholder = $shape->getPlaceholder();
        if (java_is_null($placeholder)) {
            continue;
        }

        $placeholderTypeValue = $placeholder->getType();
        $placeholderType = java_values($placeholderTypeValue);
        if ($placeholderType === PlaceholderType::Chart || $placeholderType === PlaceholderType::Object) {
            $targetPlaceholder = $shape;
            break;
        }
    }

    if ($targetPlaceholder === null) {
        throw new RuntimeException("The first slide does not contain a chart or content placeholder.");
    }

    $x = $targetPlaceholder->getX();
    $y = $targetPlaceholder->getY();
    $width = $targetPlaceholder->getWidth();
    $height = $targetPlaceholder->getHeight();
    $chart = $shapes->addChart(ChartType::ClusteredColumn, $x, $y, $width, $height);
    $chart->setTitle(true);
    $chart->getChartTitle()->addTextFrameForOverriding("Quarterly Revenue");
    $shapes->remove($targetPlaceholder);
    $presentation->save("content-placeholder-replaced-with-chart.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Le graphique ajouté est un graphique local ordinaire. Il occupe la zone de l’espace réservé mais n’hérite pas de l’espace réservé de mise en page. Utilisez les [chart management articles](/slides/fr/php-java/powerpoint-charts/) lorsque vous devez remplacer ses catégories, ses séries ou les données du classeur.

## **Exemple complet : mettre à jour le texte ou le contenu image**

L’exemple de bout en bout suivant ouvre un modèle, recherche la première diapositive pour un espace réservé de titre ou d’image, vérifie les types d’espace réservé et de forme, met à jour le contenu approprié et enregistre le résultat. L’exemple évite délibérément de supposer un indice de forme ou de traiter chaque espace réservé comme la même classe.

```php
use aspose\slides\PlaceholderType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation("template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $shapeCountValue = $shapes->size();
    $shapeCount = java_values($shapeCountValue);
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    $pictureFrameClass = new JavaClass("com.aspose.slides.PictureFrame");
    $updated = false;

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $placeholder = $shape->getPlaceholder();
        if (java_is_null($placeholder)) {
            continue;
        }

        $placeholderTypeValue = $placeholder->getType();
        $placeholderType = java_values($placeholderTypeValue);

        if (($placeholderType === PlaceholderType::Title || $placeholderType === PlaceholderType::CenteredTitle) && java_instanceof($shape, $autoShapeClass)) {
            $shape->getTextFrame()->setText("Quarterly Business Review");
            $updated = true;
            break;
        }

        if ($placeholderType === PlaceholderType::Picture) {
            $imageData = file_get_contents("replacement.png");
            $image = $presentation->getImages()->addImage($imageData);

            if (java_instanceof($shape, $pictureFrameClass)) {
                $picture = $shape->getPictureFormat()->getPicture();
                $picture->setImage($image);
            } else {
                $x = $shape->getX();
                $y = $shape->getY();
                $width = $shape->getWidth();
                $height = $shape->getHeight();
                $shapes->addPictureFrame(ShapeType::Rectangle, $x, $y, $width, $height, $image);
                $shapes->remove($shape);
            }

            $updated = true;
            break;
        }
    }

    if (!$updated) {
        throw new RuntimeException("No supported title or picture placeholder was found on the first slide.");
    }

    $presentation->save("placeholder-content-updated.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Qu’est‑ce qu’un espace réservé de base ?**

Un espace réservé de base est la forme correspondante sur la mise en page ou le maître dont hérite un autre espace réservé. Utilisez [Shape::getBasePlaceholder](https://reference.aspose.com/slides/fr/php-java/aspose.slides/shape/getbaseplaceholder/) pour le récupérer. Une forme locale ordinaire renvoie `null` car elle ne fait pas partie de la hiérarchie des espaces réservés.

**Puis‑je changer tous les titres de diapositives en modifiant un espace réservé de mise en page ?**

Vous pouvez modifier le formatage hérité ou le texte d’invite via une mise en page, mais le contenu réel des titres est stocké sur les diapositives normales. Pour remplacer le texte du titre dans toute la présentation, parcourez les diapositives et mettez à jour chaque espace réservé de titre.

**Comment gérer les espaces réservés de date, numéro de diapositive, en‑tête et pied de page ?**

Utilisez les gestionnaires d’en‑tête et de pied de page au niveau de la diapositive, de la mise en page, du maître, des notes ou du livret appropriés. Voir [Manage Presentation Header and Footer](/slides/fr/php-java/presentation-header-and-footer/) pour des exemples complets.