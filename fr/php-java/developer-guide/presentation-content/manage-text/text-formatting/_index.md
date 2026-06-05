---
title: Formater le texte d'une présentation en PHP
linktitle: Mise en forme du texte
type: docs
weight: 50
url: /fr/php-java/text-formatting/
keywords:
- mise en surbrillance du texte
- expression régulière
- aligner le paragraphe
- style du texte
- arrière-plan du texte
- transparence du texte
- espacement des caractères
- propriétés de police
- famille de police
- rotation du texte
- angle de rotation
- cadre de texte
- interligne
- propriété d'ajustement automatique
- ancrage du cadre de texte
- tabulation du texte
- langue par défaut
- PowerPoint
- OpenDocument
- présentation
- PHP
- Aspose.Slides
description: "Formatez et stylisez le texte dans des présentations PowerPoint et OpenDocument à l'aide d'Aspose.Slides pour PHP via Java. Personnalisez les polices, les couleurs, l'alignement, et plus encore."
---
## **Vue d'ensemble**

Cet article montre comment formater du texte dans des présentations PowerPoint et OpenDocument en utilisant Aspose.Slides pour PHP via Java. Il couvre la mise en évidence, les couleurs d'arrière‑plan, la transparence, l’espacement des caractères, les propriétés de police, la rotation, l’espacement des paragraphes, le comportement d’ajustement automatique, l’ancrage du texte, les tabulations et les paramètres de langue.

Dans les exemples ci‑dessous, nous utiliserons un fichier nommé **sample.pptx**, qui contient une seule zone de texte sur la première diapositive avec le texte suivant :

![Sample text](sample_text.png)

## **Mettre en surbrillance le texte**

Utilisez la méthode [TextFrame](https://reference.aspose.com/slides/fr/php-java/aspose.slides/textframe/)`::highlightText` lorsque vous devez mettre en surbrillance du texte correspondant à un échantillon spécifique dans un cadre de texte. La méthode applique une couleur de surbrillance aux fragments de texte correspondants et peut être utilisée avec [TextHighlightingOptions](https://reference.aspose.com/slides/fr/php-java/aspose.slides/texthighlightingoptions/) pour contrôler la façon dont la recherche est effectuée, par exemple pour ne correspondre qu’aux mots entiers.

Le code ci‑dessous met en surbrillance toutes les occurrences des caractères **"try"** puis ne met en surbrillance que le mot complet **"to"**.

```php
$presentation = new Presentation("sample.pptx");
try {
    // Obtenir la première forme de la première diapositive.
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $lightBlue = new Java("java.awt.Color", 173, 216, 230);
    $violet = new Java("java.awt.Color", 238, 130, 238);

    // Mettre en surbrillance le mot "try" dans la forme.
    $shape->getTextFrame()->highlightText("try", $lightBlue);

    $searchOptions = new TextHighlightingOptions();
    $searchOptions->setWholeWordsOnly(true);

    // Mettre en surbrillance le mot "to" dans la forme.
    $shape->getTextFrame()->highlightText("to", $violet, $searchOptions);

    $presentation->save("highlighted_text.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Le résultat :

![The highlighted text](highlighted_text.png)

## **Mettre en surbrillance le texte à l'aide d'expressions régulières**

La méthode [TextFrame](https://reference.aspose.com/slides/fr/php-java/aspose.slides/textframe/)`::highlightRegex` met en surbrillance les correspondances trouvées par une expression régulière.

Le code ci‑dessus met en surbrillance tous les mots contenant **sept caractères ou plus** :

```php
$presentation = new Presentation("sample.pptx");
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    // Mettre en surbrillance tous les mots de sept caractères ou plus.
    $shape->getTextFrame()->highlightRegex("\\b[^\\s]{7,}\\b", java("java.awt.Color")->YELLOW, null);

    $presentation->save("highlighted_text_using_regex.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Le résultat :

![The highlighted text using the regular expression](highlighted_text_using_regex.png)

## **Définir la couleur d'arrière‑plan du texte**

Utilisez le format de portion par défaut de [ParagraphFormat](https://reference.aspose.com/slides/fr/php-java/aspose.slides/paragraphformat/) pour définir la couleur de surbrillance par défaut d’un paragraphe, ou utilisez [PortionFormat](https://reference.aspose.com/slides/fr/php-java/aspose.slides/portionformat/) pour des portions de texte individuelles.

L’exemple de code suivant montre comment définir la couleur d’arrière‑plan pour le **paragraphe entier** :

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    // Définir la couleur de surbrillance pour le paragraphe entier.
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getHighlightColor()->setColor(java("java.awt.Color")->LIGHT_GRAY);

    $presentation->save("gray_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Le résultat :

![The gray paragraph](gray_paragraph.png)

L’exemple de code ci‑dessous montre comment définir la couleur d’arrière‑plan pour les **portions de texte en gras** :

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold()) === NullableBool::True) {
            // Définir la couleur de surbrillance pour la portion de texte.
            $portion->getPortionFormat()->getHighlightColor()->setColor(java("java.awt.Color")->LIGHT_GRAY);
        }
    }

    $presentation->save("gray_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Le résultat :

![The gray text portions](gray_text_portions.png)

## **Aligner les paragraphes de texte**

Utilisez la méthode [ParagraphFormat](https://reference.aspose.com/slides/fr/php-java/aspose.slides/paragraphformat/)`::setAlignment` pour définir l’alignement du paragraphe à l’intérieur d’un cadre de texte. La valeur peut être centrée, alignée à gauche, à droite, justifiée, etc.

L’exemple de code suivant montre comment aligner le paragraphe **au centre** :

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    // Définir l'alignement du paragraphe au centre.
    $paragraph->getParagraphFormat()->setAlignment(TextAlignment::Center);

    $presentation->save("aligned_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Le résultat :

![The aligned paragraph](aligned_paragraph.png)

## **Définir la transparence du texte**

La transparence du texte est contrôlée via le composant alpha de la couleur affectée au format de remplissage de [PortionFormat](https://reference.aspose.com/slides/fr/php-java/aspose.slides/portionformat/). Dans les exemples ci‑dessus, `alpha = 50` est une valeur du canal alpha ARGB sur une échelle de 0 à 255, et non un pourcentage de transparence.

Le code ci‑dessus montre comment appliquer la transparence au **paragraphe entier** :

```php
$alpha = 50;

$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $fillFormat = $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat();

    // Définir la couleur de remplissage du texte à une couleur transparente.
    $fillFormat->setFillType(FillType::Solid);
    $fillFormat->getSolidFillColor()->setColor(new Java("java.awt.Color", 0, 0, 0, $alpha));

    $presentation->save("transparent_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Le résultat :

![The transparent paragraph](transparent_paragraph.png)

L’exemple suivant montre comment appliquer la transparence aux **portions de texte en gras** :

```php
$alpha = 50;

$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold()) === NullableBool::True) {
            // Définir la transparence de la portion de texte.
            $fillFormat = $portion->getPortionFormat()->getFillFormat();
            $fillFormat->setFillType(FillType::Solid);
            $fillFormat->getSolidFillColor()->setColor(new Java("java.awt.Color", 0, 0, 0, $alpha));
        }
    }

    $presentation->save("transparent_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Le résultat :

![The transparent text portions](transparent_text_portions.png)

## **Définir l’espacement des caractères du texte**

Utilisez la méthode [BasePortionFormat](https://reference.aspose.com/slides/fr/php-java/aspose.slides/baseportionformat/)`::setSpacing` pour augmenter ou réduire l’espacement entre les caractères dans une zone de texte.

Le code PHP suivant montre comment augmenter l’espacement des caractères dans le **paragraphe entier** :

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    // Remarque: utilisez des valeurs négatives pour compresser l'espacement des caractères.
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setSpacing(3); // Étendre l'espacement des caractères.

    $presentation->save("character_spacing_in_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Le résultat :

![The character spacing in the paragraph](character_spacing_in_paragraph.png)

L’exemple ci‑dessous montre comment augmenter l’espacement des caractères dans les **portions de texte en gras** :

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold()) === NullableBool::True) {
            // Remarque : utilisez des valeurs négatives pour compresser l'espacement des caractères.
            $portion->getPortionFormat()->setSpacing(3); // Étendre l'espacement des caractères.
        }
    }

    $presentation->save("character_spacing_in_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Le résultat :

![The character spacing in the text portions](character_spacing_in_text_portions.png)

### **Désactiver le crénage pour des polices spécifiques**

Dans certains cas, le texte rendu par Aspose.Slides peut sembler légèrement plus serré que le même texte affiché dans PowerPoint. Cela peut se produire parce que PowerPoint ignore les données de crénage pour certaines polices, même lorsque la police contient des informations de crénage valides et que le crénage est activé dans les paramètres de PowerPoint.

Pour rapprocher le rendu de celui de PowerPoint dans de tels cas, vous pouvez désactiver le crénage pour les portions de texte utilisant la police concernée. Réglez la méthode [BasePortionFormat](https://reference.aspose.com/slides/fr/php-java/aspose.slides/baseportionformat/)`::setKerningMinimalSize` à une valeur nettement supérieure à la taille réelle de la police :

```php
$presentation = new Presentation("presentation.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $targetFont = "Roboto";

    $paragraphCount = java_values($autoShape->getTextFrame()->getParagraphs()->getCount());
    for ($paragraphIndex = 0; $paragraphIndex < $paragraphCount; $paragraphIndex++) {
        $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item($paragraphIndex);
        $portionCount = java_values($paragraph->getPortions()->getCount());
        for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
            $portion = $paragraph->getPortions()->get_Item($portionIndex);
            $portionFormat = $portion->getPortionFormat();
            $latinFont = $portionFormat->getLatinFont();
            $eastAsianFont = $portionFormat->getEastAsianFont();
            $complexScriptFont = $portionFormat->getComplexScriptFont();

            if ((!java_is_null($latinFont) && $latinFont->getFontName() == $targetFont) ||
                (!java_is_null($eastAsianFont) && $eastAsianFont->getFontName() == $targetFont) ||
                (!java_is_null($complexScriptFont) && $complexScriptFont->getFontName() == $targetFont)) {
                $portionFormat->setKerningMinimalSize(100);
            }
        }
    }

    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Ce réglage empêche l’application du crénage aux portions de texte correspondantes et peut aider à aligner le rendu d’Aspose.Slides avec la sortie visuelle de PowerPoint pour les polices affectées par ce comportement propre à PowerPoint.

## **Gérer les propriétés de police du texte**

Les propriétés de police peuvent être définies au niveau du paragraphe via le format de portion par défaut de [ParagraphFormat](https://reference.aspose.com/slides/fr/php-java/aspose.slides/paragraphformat/) ou sur des portions individuelles via [PortionFormat](https://reference.aspose.com/slides/fr/php-java/aspose.slides/portionformat/).

Le code suivant définit la police et le style du texte pour le **paragraphe entier** : il applique la taille de police, le gras, l’italique, le soulignement pointillé et la police Times New Roman à toutes les portions du paragraphe.

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $defaultPortionFormat = $paragraph->getParagraphFormat()->getDefaultPortionFormat();

    // Définir les propriétés de police pour le paragraphe.
    $defaultPortionFormat->setFontHeight(12);
    $defaultPortionFormat->setFontBold(NullableBool::True);
    $defaultPortionFormat->setFontItalic(NullableBool::True);
    $defaultPortionFormat->setFontUnderline(TextUnderlineType::Dotted);
    $defaultPortionFormat->setLatinFont(new FontData("Times New Roman"));

    $presentation->save("font_properties_for_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Le résultat :

![The font properties for the paragraph](font_properties_for_paragraph.png)

L’exemple ci‑dessous applique des propriétés similaires aux **portions de texte en gras** :

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold()) === NullableBool::True) {
            // Définir les propriétés de police pour la portion de texte.
            $portionFormat = $portion->getPortionFormat();
            $portionFormat->setFontHeight(13);
            $portionFormat->setFontItalic(NullableBool::True);
            $portionFormat->setFontUnderline(TextUnderlineType::Dotted);
            $portionFormat->setLatinFont(new FontData("Times New Roman"));
        }
    }

    $presentation->save("font_properties_for_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Le résultat :

![The font properties for text portions](font_properties_for_text_portions.png)

## **Définir la rotation du texte**

Utilisez la méthode [TextFrameFormat](https://reference.aspose.com/slides/fr/php-java/aspose.slides/textframeformat/)`::setTextVerticalType` pour définir une orientation de texte prédéfinie à l’intérieur d’une forme.

L’exemple de code suivant définit l’orientation du texte dans la forme sur `Vertical270`, ce qui fait pivoter le texte de **90 degrés dans le sens inverse des aiguilles d’une montre** :

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    $autoShape->getTextFrame()->getTextFrameFormat()->setTextVerticalType(TextVerticalType::Vertical270);

    $presentation->save("text_rotation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Le résultat :

![The text rotation](text_rotation.png)

## **Définir une rotation personnalisée pour les cadres de texte**

Utilisez la méthode [TextFrameFormat](https://reference.aspose.com/slides/fr/php-java/aspose.slides/textframeformat/)`::setRotationAngle` pour définir un angle de rotation personnalisé pour un [TextFrame](https://reference.aspose.com/slides/fr/php-java/aspose.slides/textframe/).

Le code ci‑dessus fait pivoter le cadre de texte de 3 degrés dans le sens des aiguilles d’une montre à l’intérieur de la forme :

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    $autoShape->getTextFrame()->getTextFrameFormat()->setRotationAngle(3);

    $presentation->save("custom_text_rotation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Le résultat :

![The custom text rotation](custom_text_rotation.png)

## **Définir l’espacement des lignes des paragraphes**

Aspose.Slides propose les méthodes [ParagraphFormat](https://reference.aspose.com/slides/fr/php-java/aspose.slides/paragraphformat/)`::setSpaceAfter`, `ParagraphFormat::setSpaceBefore` et `ParagraphFormat::setSpaceWithin` pour contrôler l’espacement des paragraphes. Ces méthodes s’utilisent ainsi :

* Utilisez une valeur positive pour spécifier l’interligne en pourcentage de la hauteur de ligne.
* Utilisez une valeur négative pour spécifier l’interligne en points.

L’exemple de code suivant montre comment spécifier l’interligne à l’intérieur du paragraphe :

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $paragraph->getParagraphFormat()->setSpaceWithin(200);

    $presentation->save("line_spacing.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Le résultat :

![The line spacing within the paragraph](line_spacing.png)

## **Définir le type d’ajustement automatique pour les cadres de texte**

La méthode [TextFrameFormat](https://reference.aspose.com/slides/fr/php-java/aspose.slides/textframeformat/)`::setAutofitType` détermine comment le texte se comporte lorsqu’il dépasse les limites de son conteneur. Utilisez‑la pour contrôler si le texte rétrécit, dépasse ou redimensionne automatiquement la forme.

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    $autoShape->getTextFrame()->getTextFrameFormat()->setAutofitType(TextAutofitType::Shape);

    $presentation->save("autofit_type.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Définir l’ancrage des cadres de texte**

La méthode [TextFrameFormat](https://reference.aspose.com/slides/fr/php-java/aspose.slides/textframeformat/)`::setAnchoringType` définit comment le texte est positionné verticalement à l’intérieur d’une forme, par exemple en haut, au milieu ou en bas.

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    $autoShape->getTextFrame()->getTextFrameFormat()->setAnchoringType(TextAnchorType::Bottom);

    $presentation->save("text_anchor.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Définir la tabulation du texte**

Utilisez la méthode [ParagraphFormat](https://reference.aspose.com/slides/fr/php-java/aspose.slides/paragraphformat/)`::setDefaultTabSize` et sa collection d’onglets pour configurer les tabulations dans un paragraphe.

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $paragraph->getParagraphFormat()->setDefaultTabSize(100);
    $paragraph->getParagraphFormat()->getTabs()->add(30, TabAlignment::Left);

    $presentation->save("paragraph_tabs.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Le résultat :

![The paragraph tabs](paragraph_tabs.png)

## **Définir la langue de vérification**

Aspose.Slides propose la méthode [BasePortionFormat](https://reference.aspose.com/slides/fr/php-java/aspose.slides/baseportionformat/)`::setLanguageId`, qui permet de définir la langue de vérification pour une portion de texte. La langue de vérification détermine la langue utilisée pour l’orthographe et la grammaire dans PowerPoint.

L’exemple de code suivant montre comment définir la langue de vérification pour une portion de texte :

```php
$presentation = new Presentation("presentation.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getPortions()->clear();

    $font = new FontData("SimSun");

    $textPortion = new Portion();
    $textPortion->getPortionFormat()->setComplexScriptFont($font);
    $textPortion->getPortionFormat()->setEastAsianFont($font);
    $textPortion->getPortionFormat()->setLatinFont($font);

    // Définir l'ID d'une langue de vérification.
    $textPortion->getPortionFormat()->setLanguageId("zh-CN");

    $textPortion->setText("1.");
    $paragraph->getPortions()->add($textPortion);

    $presentation->save("proofing_language.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Définir la langue par défaut**

Utilisez la méthode [LoadOptions](https://reference.aspose.com/slides/fr/php-java/aspose.slides/loadoptions/)`::setDefaultTextLanguage` pour définir la langue par défaut du texte créé lors du chargement ou de la création d’une présentation.

```php
$loadOptions = new LoadOptions();
$loadOptions->setDefaultTextLanguage("en-US");

$presentation = new Presentation($loadOptions);
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // Ajouter une nouvelle forme rectangulaire avec du texte.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 150, 50);
    $shape->getTextFrame()->setText("Sample text");

    // Vérifier la langue de la première portion.
    $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    echo $portion->getPortionFormat()->getLanguageId();
} finally {
    $presentation->dispose();
}
```

## **Définir le style de texte par défaut**

Pour appliquer un formatage de texte par défaut au niveau de la présentation, utilisez le style de texte par défaut de [Presentation](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/).

L’exemple de code suivant montre comment définir une police en gras de 14 pt par défaut pour tout le texte des diapositives dans une nouvelle présentation.

```php
$presentation = new Presentation();
try {
    // Obtenir le format de paragraphe de niveau supérieur.
    $paragraphFormat = $presentation->getDefaultTextStyle()->getLevel(0);

    if (!java_is_null($paragraphFormat)) {
        $paragraphFormat->getDefaultPortionFormat()->setFontHeight(14);
        $paragraphFormat->getDefaultPortionFormat()->setFontBold(NullableBool::True);
    }

    $presentation->save("default_text_style.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Extraire le texte avec l’effet Tout en majuscules**

Dans PowerPoint, l’application de l’effet de police **Tout en majuscules** fait apparaître le texte en majuscules sur la diapositive même s’il a été saisi en minuscules. Lorsque vous récupérez une telle portion de texte avec Aspose.Slides, la bibliothèque renvoie le texte exactement tel qu’il a été saisi. Pour obtenir le texte affiché, vérifiez [TextCapType](https://reference.aspose.com/slides/fr/php-java/aspose.slides/textcaptype/) et convertissez la chaîne renvoyée en majuscules lorsque la valeur est `All`.

Supposons que nous ayons la zone de texte suivante sur la première diapositive du fichier **sample2.pptx**.

![The All Caps effect](all_caps_effect.png)

L’exemple de code ci‑dessus montre comment extraire le texte avec l’effet **Tout en majuscules** appliqué :

```php
$presentation = new Presentation("sample2.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $textPortion = $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);

    echo "Original text: ", $textPortion->getText(), "\n";

    $textFormat = $textPortion->getPortionFormat()->getEffective();
    if (java_values($textFormat->getTextCapType()) === TextCapType::All) {
        $text = strtoupper($textPortion->getText());
        echo "All-Caps effect: ", $text, "\n";
    }
} finally {
    $presentation->dispose();
}
```

Sortie :

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **FAQ**

**Comment modifier le texte dans un tableau sur une diapositive ?**

Pour modifier le texte dans un tableau sur une diapositive, utilisez [Table](https://reference.aspose.com/slides/fr/php-java/aspose.slides/table/). Parcourez les cellules et mettez à jour chaque cellule via le cadre de texte de [Cell](https://reference.aspose.com/slides/fr/php-java/aspose.slides/cell/) et le format de paragraphe via le format de paragraphe de [Paragraph](https://reference.aspose.com/slides/fr/php-java/aspose.slides/paragraph/).

**Comment appliquer une couleur de dégradé au texte dans une diapositive PowerPoint ?**

Pour appliquer une couleur de dégradé au texte, utilisez le format de remplissage de [PortionFormat](https://reference.aspose.com/slides/fr/php-java/aspose.slides/portionformat/). Réglez le type de remplissage de [FillFormat](https://reference.aspose.com/slides/fr/php-java/aspose.slides/fillformat/) sur [FillType](https://reference.aspose.com/slides/fr/php-java/aspose.slides/filltype/) `Gradient` et configurez les arrêts du dégradé, la direction et la transparence.