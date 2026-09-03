---
title: Gestion des zones de texte dans les présentations avec PHP
linktitle: Gestion de la zone de texte
type: docs
weight: 20
url: /fr/php-java/manage-textbox/
keywords:
- zone de texte
- cadre de texte
- ajouter du texte
- mettre à jour le texte
- créer une zone de texte
- vérifier la zone de texte
- ajouter une colonne de texte
- ajouter un hyperlien
- PowerPoint
- présentation
- PHP
- Aspose.Slides
description: "Créer, identifier, mettre en forme et mettre à jour les zones de texte dans les présentations PowerPoint et OpenDocument à l'aide d'Aspose.Slides pour PHP via Java."
---
## **Introduction**

Dans Aspose.Slides pour PHP via Java, le texte des diapositives est stocké dans des cadres de texte qui appartiennent aux formes. La classe [AutoShape](https://reference.aspose.com/slides/fr/php-java/aspose.slides/autoshape/) représente la forme la plus courante contenant du texte et expose son texte via la méthode [AutoShape::getTextFrame](https://reference.aspose.com/slides/fr/php-java/aspose.slides/autoshape/#getTextFrame).

{{% alert color="info" title="Note" %}}

Chaque forme auto dérive de [Shape](https://reference.aspose.com/slides/fr/php-java/aspose.slides/shape/), mais toutes les formes ne sont pas des formes auto ni ne prennent en charge un cadre de texte. Lors du traitement d’une présentation existante, utilisez `java_instanceof` pour vérifier qu’une forme est une [AutoShape](https://reference.aspose.com/slides/fr/php-java/aspose.slides/autoshape/) avant d’accéder à son texte.

{{% /alert %}}

## **Créer une zone de texte sur une diapositive**

Pour créer une zone de texte, ajoutez une forme auto à une diapositive, ajoutez du texte à son cadre de texte, puis enregistrez la présentation. L’exemple suivant crée une zone de texte rectangulaire :

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $textBox = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 300, 50);
    $textBox->addTextFrame("Aspose TextBox");

    $presentation->save("TextBox.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Les coordonnées et dimensions transmises à [ShapeCollection::addAutoShape](https://reference.aspose.com/slides/fr/php-java/aspose.slides/shapecollection/#addAutoShape) sont exprimées en points. [AutoShape::addTextFrame](https://reference.aspose.com/slides/fr/php-java/aspose.slides/autoshape/#addTextFrame) initialise le cadre de texte avec le texte fourni.

## **Vérifier la présence d’une forme de zone de texte**

Utilisez la méthode [AutoShape::isTextBox](https://reference.aspose.com/slides/fr/php-java/aspose.slides/autoshape/#isTextBox) pour déterminer si une forme auto est considérée comme une zone de texte. Cela est utile lorsqu’une présentation contient à la fois des formes auto porteuses de texte et des formes purement graphiques.

![A text box and a shape](istextbox.png)

L’exemple suivant examine chaque forme auto dans une présentation :

```php
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $textBox = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 120, 40);
    $textBox->addTextFrame("Text box");
    $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 150, 10, 40, 40);

    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    for ($slideIndex = 0; $slideIndex < java_values($presentation->getSlides()->size()); $slideIndex++) {
        $currentSlide = $presentation->getSlides()->get_Item($slideIndex);
        for ($shapeIndex = 0; $shapeIndex < java_values($currentSlide->getShapes()->size()); $shapeIndex++) {
            $shape = $currentSlide->getShapes()->get_Item($shapeIndex);
            if (java_instanceof($shape, $autoShapeClass)) {
                echo (java_is_true($shape->isTextBox()) ? "The shape is a text box." : "The shape is not a text box.") . PHP_EOL;
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

Une forme auto nouvellement ajoutée n’est pas considérée comme une zone de texte tant qu’elle ne contient pas de texte non vide. Vous pouvez fournir ce texte via [AutoShape::addTextFrame](https://reference.aspose.com/slides/fr/php-java/aspose.slides/autoshape/#addTextFrame) ou [TextFrame::setText](https://reference.aspose.com/slides/fr/php-java/aspose.slides/textframe/#setText). Ajouter ou assigner une chaîne vide laisse [AutoShape::isTextBox](https://reference.aspose.com/slides/fr/php-java/aspose.slides/autoshape/#isTextBox) retourner `false` :

```php
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 40);
    $shape1->addTextFrame("Shape 1");
    echo (java_is_true($shape1->isTextBox()) ? "true" : "false") . PHP_EOL;

    $shape2 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 70, 100, 40);
    $shape2->getTextFrame()->setText("Shape 2");
    echo (java_is_true($shape2->isTextBox()) ? "true" : "false") . PHP_EOL;

    $shape3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 130, 100, 40);
    $shape3->addTextFrame("");
    echo (java_is_true($shape3->isTextBox()) ? "true" : "false") . PHP_EOL;

    $shape4 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 190, 100, 40);
    $shape4->getTextFrame()->setText("");
    echo (java_is_true($shape4->isTextBox()) ? "true" : "false") . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

Les deux premiers appels affichent `true` ; les deux derniers affichent `false`.

## **Trouver la forme propriétaire d’un cadre de texte**

Un code générique de traitement du texte peut recevoir un [TextFrame](https://reference.aspose.com/slides/fr/php-java/aspose.slides/textframe/) sans connaître l’objet de présentation qui le contient. Utilisez la méthode en lecture seule [TextFrame::getParentShape](https://reference.aspose.com/slides/fr/php-java/aspose.slides/textframe/#getParentShape) pour remonter à sa forme propriétaire [Shape](https://reference.aspose.com/slides/fr/php-java/aspose.slides/shape/).

Pour un cadre de texte appartenant à une forme auto ou à une autre forme porteuse de texte, [TextFrame::getParentShape](https://reference.aspose.com/slides/fr/php-java/aspose.slides/textframe/#getParentShape) renvoie le propriétaire et [TextFrame::getParentCell](https://reference.aspose.com/slides/fr/php-java/aspose.slides/textframe/#getParentCell) renvoie `null`. Vérifiez la valeur retournée avec `java_is_null` avant d’y accéder. Pour identifier à la fois les propriétaires de forme et de cellule de tableau, y compris les formes associées aux nœuds SmartArt, consultez [Rechercher et remplacer du texte](/slides/fr/php-java/search-and-replace-text/).

## **Ajouter des colonnes à une zone de texte**

La méthode [TextFrameFormat::setColumnCount](https://reference.aspose.com/slides/fr/php-java/aspose.slides/textframeformat/#setColumnCount) divise le cadre de texte en colonnes, tandis que [TextFrameFormat::setColumnSpacing](https://reference.aspose.com/slides/fr/php-java/aspose.slides/textframeformat/#setColumnSpacing) définit l’espacement entre les colonnes en points. Les deux réglages appartiennent à [TextFrameFormat](https://reference.aspose.com/slides/fr/php-java/aspose.slides/textframeformat/) et peuvent être modifiés via le cadre de texte d’une zone de texte existante. Le texte se reconstitue entre les colonnes à l’intérieur de la même forme ; il ne continue pas dans une autre forme.

L’exemple suivant crée une zone de texte à trois colonnes avec un espacement de 10 points entre les colonnes, enregistre la présentation et lit les paramètres stockés dans le fichier de sortie :

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $textBox = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 200);
    $textBox->addTextFrame("This text is distributed automatically across all columns in the text box.");

    $textFrameFormat = $textBox->getTextFrame()->getTextFrameFormat();
    $textFrameFormat->setColumnCount(3);
    $textFrameFormat->setColumnSpacing(10);

    $presentation->save("TextBoxColumns.pptx", SaveFormat::Pptx);

    $savedPresentation = new Presentation("TextBoxColumns.pptx");
    try {
        $savedTextBox = $savedPresentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
        $savedFormat = $savedTextBox->getTextFrame()->getTextFrameFormat();
        echo "Columns: " . java_values($savedFormat->getColumnCount()) . "; spacing: " . java_values($savedFormat->getColumnSpacing()) . " points" . PHP_EOL;
    } finally {
        $savedPresentation->dispose();
    }
} finally {
    $presentation->dispose();
}
```

## **Extraire le texte des colonnes individuelles**

Utilisez [TextFrame::splitTextByColumns](https://reference.aspose.com/slides/fr/php-java/aspose.slides/textframe/#splitTextByColumns) pour récupérer le texte attribué à chaque colonne visuelle d’un cadre de texte existant. La méthode renvoie une chaîne pour chaque colonne, dans l’ordre de lecture basé sur les colonnes. Un cadre de texte à une seule colonne produit un tableau avec un seul élément, et une colonne vide est représentée par une chaîne vide. Les chaînes contiennent uniquement du texte brut ; la mise en forme au niveau des portions n’est pas conservée.

Ceci est utile lorsque vous devez :

- Extraire le texte tout en préservant l’ordre de lecture basé sur les colonnes.
- Indexer ou comparer le contenu de diapositives à colonnes multiples.
- Exporter chaque colonne vers un fichier distinct, un champ de base de données ou une autre destination.
- Examiner comment le texte est redistribué après modification du nombre de colonnes avec [TextFrameFormat::setColumnCount](https://reference.aspose.com/slides/fr/php-java/aspose.slides/textframeformat/#setColumnCount), de l’espacement avec [TextFrameFormat::setColumnSpacing](https://reference.aspose.com/slides/fr/php-java/aspose.slides/textframeformat/#setColumnSpacing), de la police ou de la taille du cadre de texte.

La méthode rend compte du texte réparti dans le [TextFrame](https://reference.aspose.com/slides/fr/php-java/aspose.slides/textframe/) actuel ; elle ne fait pas circuler automatiquement le texte entre des formes ou zones de texte séparées. La distribution des colonnes peut dépendre des polices disponibles et d’autres paramètres de mise en page du texte, assurez‑vous donc que les polices requises sont présentes lorsque des résultats cohérents sont indispensables.

L’exemple suivant charge une présentation, trouve la première forme auto à colonnes multiples avec un cadre de texte, lit le nombre de colonnes configuré et écrit le texte de chaque colonne dans un fichier distinct. Les formes qui ne fournissent pas de cadre de texte sont ignorées.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("MultiColumnText.pptx");
try {
    $textBox = null;
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    $shapes = $presentation->getSlides()->get_Item(0)->getShapes();
    for ($shapeIndex = 0; $shapeIndex < java_values($shapes->size()); $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        if (java_instanceof($shape, $autoShapeClass)) {
            $textFrame = $shape->getTextFrame();
            if (!java_is_null($textFrame)) {
                $columnCount = java_values($textFrame->getTextFrameFormat()->getColumnCount());
                if ($columnCount > 1) {
                    $textBox = $shape;
                    break;
                }
            }
        }
    }

    if ($textBox === null) {
        echo "No multi-column text frame was found." . PHP_EOL;
    } else {
        $textFrame = $textBox->getTextFrame();
        $configuredColumnCount = java_values($textFrame->getTextFrameFormat()->getColumnCount());
        $columnTexts = java_values($textFrame->splitTextByColumns());

        echo "Configured columns: " . $configuredColumnCount . PHP_EOL;

        foreach ($columnTexts as $columnIndex => $columnText) {
            $columnNumber = $columnIndex + 1;
            echo "Column " . $columnNumber . ": " . $columnText . PHP_EOL;
            $outputPath = "Column-" . $columnNumber . ".txt";
            $bytesWritten = file_put_contents($outputPath, $columnText);
            if ($bytesWritten === false) {
                echo "Could not write column " . $columnNumber . " to " . $outputPath . PHP_EOL;
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Mettre à jour le texte**

Pour mettre à jour le texte dans toute la présentation, parcourez les diapositives et les formes, sélectionnez les formes auto, puis modifiez leurs portions de texte. Travailler au niveau des portions vous permet de changer à la fois le texte et le format des caractères.

L’exemple suivant remplace chaque occurrence de `years` par `months` dans le texte des formes auto et rend chaque portion affectée en gras :

```php
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Text.pptx");
try {
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    for ($slideIndex = 0; $slideIndex < java_values($presentation->getSlides()->size()); $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        for ($shapeIndex = 0; $shapeIndex < java_values($slide->getShapes()->size()); $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            if (!java_instanceof($shape, $autoShapeClass)) {
                continue;
            }

            $textFrame = $shape->getTextFrame();
            if (java_is_null($textFrame)) {
                continue;
            }

            for ($paragraphIndex = 0; $paragraphIndex < java_values($textFrame->getParagraphs()->getCount()); $paragraphIndex++) {
                $paragraph = $textFrame->getParagraphs()->get_Item($paragraphIndex);
                for ($portionIndex = 0; $portionIndex < java_values($paragraph->getPortions()->getCount()); $portionIndex++) {
                    $portion = $paragraph->getPortions()->get_Item($portionIndex);
                    $text = java_values($portion->getText());
                    if ($text !== null && strpos($text, "years") !== false) {
                        $updatedText = str_replace("years", "months", $text);
                        $portion->setText($updatedText);
                        $portion->getPortionFormat()->setFontBold(NullableBool::True);
                    }
                }
            }
        }
    }

    $presentation->save("TextChanged.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Ce parcours ne met à jour le texte que dans les formes auto. Le texte stocké dans les tableaux, graphiques, SmartArt ou formes groupées nécessite un parcours des collections propres à ces objets.

## **Ajouter une zone de texte avec un hyperlien**

Un hyperlien peut être assigné à une portion de texte spécifique, de sorte que seul ce texte agit comme lien cliquable. Utilisez [HyperlinkManager::setExternalHyperlinkClick](https://reference.aspose.com/slides/fr/php-java/aspose.slides/hyperlinkmanager/#setExternalHyperlinkClick) pour associer la portion à une URL externe.

L’exemple suivant crée du texte lié et l’enregistre dans une présentation :

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $textBox = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 150, 200, 50);
    $textBox->addTextFrame("Aspose.Slides");

    $textPortion = $textBox->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $textPortion->getPortionFormat()->getHyperlinkManager()->setExternalHyperlinkClick("https://www.aspose.com/");

    $presentation->save("Hyperlink.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Quelle est la différence entre une zone de texte et un espace réservé de texte sur une diapositive maître ou modèle ?**

Un [placeholder](/slides/fr/php-java/manage-placeholder/) peut hériter de sa position et de son formatage depuis une [master slide](https://reference.aspose.com/slides/fr/php-java/aspose.slides/masterslide/) ou une [layout slide](https://reference.aspose.com/slides/fr/php-java/aspose.slides/layoutslide/). Une zone de texte ordinaire est une forme indépendante sur la diapositive où elle a été créée et n’acquiert pas le comportement d’espace réservé lorsque la disposition change.

**Comment remplacer du texte sans modifier le texte dans les graphiques, tableaux ou SmartArt ?**

Limitez le parcours aux objets [AutoShape](https://reference.aspose.com/slides/fr/php-java/aspose.slides/autoshape/) comme indiqué dans l’exemple Mettre à jour le texte. Les graphiques, tableaux et SmartArt stockent le texte dans leurs propres modèles d’objets, ils ne sont donc pas modifiés par cette boucle.