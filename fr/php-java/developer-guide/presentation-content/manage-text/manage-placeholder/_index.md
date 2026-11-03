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
- espace réservé de diagramme
- espace réservé de contenu
- texte d'invite
- PowerPoint
- présentation
- PHP
- Aspose.Slides
description: "Apprenez à inspecter et modifier les espaces réservés de texte, d’image, de diagramme et de contenu et à comprendre l’héritage des espaces réservés avec Aspose.Slides pour PHP via Java."
---
## **Vue d'ensemble**

Un espace réservé est une forme qui réserve une position pour un type particulier de contenu dans un modèle de présentation. Les exemples courants sont les espaces réservés de titre, de corps, d'image, de diagramme et les espaces réservés de contenu à usage général. Contrairement à une forme ordinaire, un espace réservé peut hériter de sa position, de sa taille, de son formatage et d’autres paramètres d’une diapositive de mise en page ou d’une diapositive maîtresse.

Aspose.Slides expose les informations des espaces réservés via la méthode [Shape::getPlaceholder](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getplaceholder/). La méthode renvoie un objet [Placeholder](https://reference.aspose.com/slides/php-java/aspose.slides/placeholder/) ou `null` pour une forme normale. Utilisez [Placeholder::getType](https://reference.aspose.com/slides/php-java/aspose.slides/placeholder/gettype/) pour déterminer ce que l'espace réservé est censé contenir.

La classe de forme reste importante une fois que vous connaissez le type d'espace réservé :

- Un espace réservé de texte, d'image, de diagramme ou de contenu vide est généralement représenté par un [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/).
- Un espace réservé d'image peuplé peut être représenté par un [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/).
- Un espace réservé de diagramme peuplé peut être représenté par un [Chart](https://reference.aspose.com/slides/php-java/aspose.slides/chart/).
- Un espace réservé de contenu peut contenir plusieurs types de contenu. Vérifiez à la fois [Placeholder::getType](https://reference.aspose.com/slides/php-java/aspose.slides/placeholder/gettype/) et la classe de forme d'exécution au lieu de supposer que chaque espace réservé est un [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/).

{{% alert color="warning" title="Warning" %}}
[Placeholder::getType](https://reference.aspose.com/slides/php-java/aspose.slides/placeholder/gettype/) décrit le rôle d'un espace réservé ; il ne garantit pas la classe d'exécution de la forme. Effectuez toujours une vérification de type avant d'accéder aux membres spécifiques au texte, à l'image, au diagramme, au tableau ou aux médias.
{{% /alert %}}

## **Comprendre l'héritage des espaces réservés**

Les espaces réservés forment une hiérarchie :

1. Une diapositive maîtresse définit des styles réutilisables et, dans certains cas, des espaces réservés de niveau maître.
2. Une diapositive de mise en page définit la disposition utilisée par une ou plusieurs diapositives normales et peut hériter du maître.
3. Une diapositive normale contient les espaces réservés pour cette diapositive et peut hériter de sa mise en page.

Appelez [Shape::getBasePlaceholder](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getbaseplaceholder/) pour remonter d'un niveau dans cette hiérarchie. Un espace réservé de diapositive renvoie normalement son espace réservé de mise en page ; un espace réservé de mise en page peut renvoyer son espace réservé maître. La méthode renvoie `null` lorsque la forme n'a aucun espace réservé de base.

L'exemple suivant répertorie les espaces réservés de la première diapositive et indique leurs espaces réservés de base :
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

Modifier un espace réservé sur une diapositive normale crée ou modifie une surcharge locale pour cette diapositive. Modifier la mise en page ou le maître associé peut affecter toutes les diapositives qui continuent d'hériter de ce paramètre. Une forme ordinaire locale n'a pas d'espace réservé de base et ne commence pas à hériter simplement parce qu'elle occupe les mêmes coordonnées.

## **Supprimer le statut d'espace réservé**

Lors de l'adaptation d'un modèle, utilisez [Shape::removePlaceholder](https://reference.aspose.com/slides/php-java/aspose.slides/shape/removeplaceholder/) pour conserver un objet existant en tant que forme ordinaire. Sa méthode [getPlaceholder](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getplaceholder/) renvoie `null`, mais la forme reste dans la collection de la diapositive. En revanche, [ShapeCollection::remove](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/remove/) supprime la forme de cette collection.

L'exemple suivant nécessite `template.pptx` contenant au moins une diapositive et un espace réservé de texte non vide sur la première diapositive. Utilisez un espace réservé avec un formatage hérité de sa mise en page ou de son maître pour voir l'effet de la suppression de cette relation. L'exemple vérifie que la même forme reste, appelle à nouveau la méthode sur la forme désormais ordinaire, et enregistre le résultat.

{{% alert color="warning" title="Warning" %}}
Supprimer le statut d'espace réservé ne préserve pas automatiquement les paramètres d'apparence hérités. L'exemple ci-dessous laisse délibérément ces paramètres inchangés, de sorte que la sortie peut apparaître différemment. Une forme dont la position et la taille sont entièrement héritées peut avoir des coordonnées et des dimensions nulles après l'appel et devenir invisible même si elle reste dans la collection.
{{% /alert %}}

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapeCount = java_values($slide->getShapes()->size());
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    $found = false;

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (!java_instanceof($shape, $autoShapeClass)) {
            continue;
        }

        $placeholder = $shape->getPlaceholder();
        $textFrame = $shape->getTextFrame();
        if (java_is_null($placeholder) || java_is_null($textFrame)) {
            continue;
        }

        $textValue = $textFrame->getText();
        if (java_is_null($textValue)) {
            continue;
        }
        $text = java_values($textValue);
        if ($text === "") {
            continue;
        }

        $shape->removePlaceholder();

        $placeholder = $shape->getPlaceholder();
        $retainedShape = $slide->getShapes()->get_Item($shapeIndex);
        $sameShapeValue = $shape->equals($retainedShape);
        $sameShape = java_values($sameShapeValue);
        $remainingCountValue = $slide->getShapes()->size();
        $remainingCount = java_values($remainingCountValue);
        echo "Placeholder removed: " . (java_is_null($placeholder) ? "true" : "false") . PHP_EOL;
        echo "Same shape retained: " . ($sameShape ? "true" : "false") . PHP_EOL;
        echo "Shape count unchanged: " . ($remainingCount === $shapeCount ? "true" : "false") . PHP_EOL;

        // Appeler la méthode sur une forme ordinaire n'a aucun effet.
        $shape->removePlaceholder();
        $found = true;
        break;
    }

    if ($found) {
        $presentation->save("placeholder-status-removed.pptx", SaveFormat::Pptx);
    } else {
        echo "No nonempty text placeholder was found on the first slide." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

Pour un espace réservé correspondant, les trois vérifications affichent `true`. Le texte reste, mais la position, la taille, la rotation, la police, l'alignement de paragraphe, les marges du cadre de texte, l'ancrage vertical, le remplissage et les paramètres de ligne hérités peuvent changer lorsque la relation d'espace réservé est supprimée. Par exemple, le formatage hérité du titre peut revenir au formatage de texte ordinaire. Consultez [Slide Layout](/slides/fr/php-java/slide-layout/) pour plus d'informations sur les mises en page.

Pour préserver l'apparence souhaitée, capturez la position, la taille et la rotation résolues avant l'appel, et copiez les valeurs de formatage effectif requises dans des variables séparées. Récupérez ces valeurs via [PortionFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/portionformat/geteffective/), [ParagraphFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/geteffective/), [TextFrameFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/geteffective/), [FillFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/geteffective/), et [LineFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/geteffective/). Ne vous fiez pas uniquement aux objets de formatage effectif, car leurs valeurs de formatage de texte peuvent changer après la suppression de la relation. Appliquez explicitement les valeurs capturées à la forme ordinaire par la suite, y compris la famille de police, la taille, le style, la couleur, les paramètres de paragraphe, les paramètres du cadre de texte, le remplissage et la ligne utilisés par votre modèle.

La géométrie de forme héritée peut également devoir être assignée explicitement via [GeometryShape::setShapeType](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setShapeType). Pour un espace réservé de texte rectangulaire, cela signifie attribuer [ShapeType::Rectangle](https://reference.aspose.com/slides/php-java/aspose.slides/shapetype/); ne restaurer que le remplissage et la ligne peut ne pas restaurer le rectangle visible. Les modèles avec des effets supplémentaires ou un formatage plus complexe nécessitent également la prise en charge de ces paramètres.

## **Modifier le texte d'un espace réservé**

Les espaces réservés de titre, de titre centré, de sous-titre, de corps et de texte prennent normalement en charge le texte. Vérifiez la présence d'un [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) avant d'utiliser sa méthode [getTextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/gettextframe/).

Cet exemple met à jour le premier espace réservé de titre sur la première diapositive et enregistre le résultat :
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

Ce modèle évite de traiter les espaces réservés d'image, de diagramme, de tableau ou de média comme des objets [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/). Il identifie également l'espace réservé par son but plutôt qu'en s'appuyant sur un indice de forme fragile.

## **Définir le texte d'invite sur une mise en page**

Le texte d'invite est l'instruction affichée en mode conception dans un espace réservé vide, par exemple *Cliquez pour ajouter un titre*. Définissez un texte d'invite personnalisé sur l'espace réservé de la mise en page plutôt que d'essayer d'y accéder via la collection de formes d'une diapositive normale. Accédez à la mise en page via [Slide::getLayoutSlide](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getLayoutSlide) et parcourez la collection renvoyée par [BaseSlide::getShapes](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getShapes).

L'exemple suivant modifie les invites de titre et de sous-titre sur la mise en page utilisée par la première diapositive :
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

Le texte d'invite n'est pas un contenu de diapositive normal. Il est destiné aux espaces réservés vides dans les applications d'édition comme PowerPoint. Une fois qu'un utilisateur ou un programme fournit du contenu réel, l'invite n'est plus affichée. Modifier une invite ne remplace pas non plus le texte existant sur les diapositives qui utilisent la mise en page.

## **Mettre à jour un espace réservé d'image**

Il y a deux cas à gérer :

- Si l'espace réservé d'image est déjà rempli et représenté par un [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/), remplacez l'image via [PictureFillFormat::getPicture](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/getpicture/) et [Picture::setImage](https://reference.aspose.com/slides/php-java/aspose.slides/picture/#setImage).
- S'il s'agit toujours d'un espace réservé vide, ajoutez un cadre d'image aux coordonnées de l'espace réservé avec [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addpictureframe/) et supprimez l'espace réservé vide.

L'exemple suivant prend en charge les deux cas et enregistre la présentation :
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

La substitution créée pour un espace réservé vide est un cadre d'image local, pas un nouvel espace réservé, car [Shape::getPlaceholder](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getplaceholder/) ne fournit pas de setter. Elle conserve la position réservée mais n'hérite plus du comportement spécifique à l'espace réservé. Si la conservation de la relation d'espace réservé est essentielle, préparez et remplissez l'espace réservé dans PowerPoint d'abord, puis mettez à jour le [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/) résultant avec Aspose.Slides.

Pour la transparence d'image, le recadrage et d'autres effets spécifiques aux images, consultez [Manage Picture Frames](/slides/fr/php-java/picture-frame/). Ces opérations appartiennent au cadre d'image ou au remplissage d'image, pas aux métadonnées de l'espace réservé.

## **Travailler avec les espaces réservés de diagramme et de contenu**

Un espace réservé de diagramme rempli peut être représenté par un [Chart](https://reference.aspose.com/slides/php-java/aspose.slides/chart/). Cet exemple trouve un tel diagramme à la fois par le type d'espace réservé et par la classe d'exécution, modifie son titre et enregistre le fichier :
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

Un espace réservé de contenu général possède généralement [PlaceholderType::Object](https://reference.aspose.com/slides/php-java/aspose.slides/placeholdertype/). Dans PowerPoint, il sert de lanceur pour plusieurs types de contenu, notamment les diagrammes, les tableaux, les diagrammes, les images et les médias. Après qu'il ait été rempli, examinez la classe de forme réelle pour savoir ce qu'il contient. Les mises en page spécialisées peuvent également exposer [PlaceholderType::Chart](https://reference.aspose.com/slides/php-java/aspose.slides/placeholdertype/), [PlaceholderType::Table](https://reference.aspose.com/slides/php-java/aspose.slides/placeholdertype/), [PlaceholderType::Picture](https://reference.aspose.com/slides/php-java/aspose.slides/placeholdertype/), [PlaceholderType::Media](https://reference.aspose.com/slides/php-java/aspose.slides/placeholdertype/), ou [PlaceholderType::Diagram](https://reference.aspose.com/slides/php-java/aspose.slides/placeholdertype/).

Aspose.Slides ne convertit pas un espace réservé [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) vide en [Chart](https://reference.aspose.com/slides/php-java/aspose.slides/chart/) simplement en modifiant [Placeholder::getType](https://reference.aspose.com/slides/php-java/aspose.slides/placeholder/gettype/) ; le type ne peut pas être changé via la classe. Pour remplir programmétiquement un diagramme ou une zone de contenu vide, ajoutez l'objet requis aux coordonnées de l'espace réservé, puis supprimez l'espace réservé vide. L'exemple suivant fait cela pour un diagramme :
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

Le diagramme ajouté est un diagramme local ordinaire. Il occupe la zone de l'espace réservé mais n'hérite pas de l'espace réservé de la mise en page. Utilisez les articles dédiés à la [gestion des diagrammes](/slides/fr/php-java/powerpoint-charts/) lorsque vous devez remplacer ses catégories, séries ou données de classeur.

## **Exemple complet : Mettre à jour le texte ou le contenu d'image**

L'exemple complet suivant ouvre un modèle, recherche la première diapositive pour un espace réservé de titre ou d'image, vérifie les types d'espace réservé et de forme, met à jour le contenu approprié et enregistre le résultat. L'exemple évite délibérément de supposer un indice de forme ou de traiter chaque espace réservé comme la même classe.
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

**Qu'est-ce qu'un espace réservé de base ?**

Un espace réservé de base est la forme correspondante sur la mise en page ou le maître dont hérite un autre espace réservé. Utilisez [Shape::getBasePlaceholder](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getbaseplaceholder/) pour le récupérer. Une forme locale ordinaire renvoie `null` car elle ne fait pas partie de la hiérarchie des espaces réservés.

**Puis-je changer tous les titres de diapositives en modifiant un espace réservé de mise en page ?**

Vous pouvez modifier le formatage hérité ou le texte d'invite via une mise en page, mais le contenu du titre existant est stocké sur les diapositives normales. Pour remplacer le texte réel des titres dans une présentation, parcourez les diapositives et mettez à jour chaque espace réservé de titre.

**Comment gérer les espaces réservés de date, de numéro de diapositive, d'en-tête et de pied de page ?**

Utilisez les gestionnaires d'en-tête et de pied de page au niveau de la diapositive, de la mise en page, du maître, des notes ou du mode plan de distribution appropriés. Consultez [Manage Presentation Header and Footer](/slides/fr/php-java/presentation-header-and-footer/) pour des exemples complets.