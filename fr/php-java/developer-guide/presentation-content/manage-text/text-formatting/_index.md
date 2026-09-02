---
title: Formater le texte d'une présentation en PHP
linktitle: Mise en forme du texte
type: docs
weight: 50
url: /fr/php-java/text-formatting/
keywords:
- aligner le paragraphe
- style de texte
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
description: "Formatez et stylisez le texte dans les présentations PowerPoint et OpenDocument à l'aide d'Aspose.Slides pour PHP via Java. Personnalisez les polices, les couleurs, l'alignement et plus encore."
---
## **Aperçu**

Cet article montre comment mettre en forme du texte dans les présentations PowerPoint et OpenDocument à l'aide d'Aspose.Slides pour PHP via Java. Il couvre les couleurs d'arrière-plan, la transparence, l'espacement des caractères, les propriétés de police, la rotation, l'espacement des paragraphes, le comportement d'ajustement automatique, l'ancrage du texte, les taquets de tabulation et les paramètres de langue.

Dans les exemples ci‑dessous, nous utiliserons un fichier nommé "sample.pptx", qui contient une seule zone de texte sur la première diapositive avec le texte suivant :

![Texte d'exemple](sample_text.png)

Pour rechercher et mettre en surbrillance du texte littéral ou des correspondances d'expressions régulières, voir [Recherche et remplacement de texte](/slides/fr/php-java/search-and-replace-text/).

## **Définir la couleur d'arrière-plan du texte**

Utilisez [ParagraphFormat::getDefaultPortionFormat](https://reference.aspose.com/slides/fr/php-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) pour définir la couleur de surbrillance par défaut d'un paragraphe, ou utilisez [BasePortionFormat::getHighlightColor](https://reference.aspose.com/slides/fr/php-java/aspose.slides/baseportionformat/#getHighlightColor) pour des portions de texte individuelles.

L'exemple de code suivant montre comment définir la couleur d'arrière-plan pour le **paragraphe entier** :

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $highlightColor = java("java.awt.Color")->LIGHT_GRAY;

    // Définir la couleur de surbrillance pour le paragraphe entier.
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getHighlightColor()->setColor($highlightColor);

    $presentation->save("gray_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Le résultat :

![Le paragraphe gris](gray_paragraph.png)

L'exemple de code ci‑dessous montre comment définir la couleur d'arrière-plan pour les **portions de texte en gras** :

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $highlightColor = java("java.awt.Color")->LIGHT_GRAY;

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold()) === NullableBool::True) {
            // Définir la couleur de surbrillance pour la portion de texte.
            $portion->getPortionFormat()->getHighlightColor()->setColor($highlightColor);
        }
    }

    $presentation->save("gray_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Le résultat :

![Les portions de texte grises](gray_text_portions.png)

## **Aligner les paragraphes de texte**

Utilisez [ParagraphFormat::setAlignment](https://reference.aspose.com/slides/fr/php-java/aspose.slides/paragraphformat/#setAlignment) pour définir l'alignement du paragraphe dans une zone de texte. La valeur peut être centrée, alignée à gauche, alignée à droite, justifiée, etc.

L'exemple de code suivant montre comment aligner le paragraphe au **centre** :

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    // Définir l'alignement du paragraphe au centre.
    $paragraph->getParagraphFormat()->setAlignment(TextAlignment::Center);

    $presentation->save("aligned_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Le résultat :

![Le paragraphe aligné](aligned_paragraph.png)

## **Définir la transparence du texte**

La transparence du texte est contrôlée via le composant alpha de la couleur assignée à [BasePortionFormat::getFillFormat](https://reference.aspose.com/slides/fr/php-java/aspose.slides/baseportionformat/#getFillFormat). Dans les exemples ci‑dessous, `alpha = 50` est une valeur de canal alpha ARGB sur l'échelle 0‑255, et non un pourcentage de transparence.

L'exemple de code ci‑dessous montre comment appliquer la transparence au **paragraphe entier** :

```php
$alpha = 50;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $fillFormat = $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat();

    // Définir la couleur de remplissage du texte à une couleur transparente.
    $fillFormat->setFillType(FillType::Solid);
    $transparentColor = new Java("java.awt.Color", 0, 0, 0, $alpha);
    $fillFormat->getSolidFillColor()->setColor($transparentColor);

    $presentation->save("transparent_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Le résultat :

![Le paragraphe transparent](transparent_paragraph.png)

L'exemple de code suivant montre comment appliquer la transparence aux **portions de texte en gras** :

```php
$alpha = 50;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $transparentColor = new Java("java.awt.Color", 0, 0, 0, $alpha);

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold()) === NullableBool::True) {
            // Définir la transparence de la portion de texte.
            $fillFormat = $portion->getPortionFormat()->getFillFormat();
            $fillFormat->setFillType(FillType::Solid);
            $fillFormat->getSolidFillColor()->setColor($transparentColor);
        }
    }

    $presentation->save("transparent_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Le résultat :

![Les portions de texte transparentes](transparent_text_portions.png)

## **Définir l'espacement des caractères pour le texte**

Utilisez [BasePortionFormat::setSpacing](https://reference.aspose.com/slides/fr/php-java/aspose.slides/baseportionformat/#setSpacing) pour augmenter ou réduire l'espacement entre les caractères dans une zone de texte.

Le code PHP suivant montre comment augmenter l'espacement des caractères dans le **paragraphe entier** :

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    // Remarque : utilisez des valeurs négatives pour comprimer l'espacement des caractères.
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setSpacing(3); // Agrandir l'espacement des caractères.

    $presentation->save("character_spacing_in_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Le résultat :

![L'espacement des caractères dans le paragraphe](character_spacing_in_paragraph.png)

L'exemple de code ci‑dessous montre comment augmenter l'espacement des caractères dans les **portions de texte en gras** :

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold()) === NullableBool::True) {
            // Remarque : utilisez des valeurs négatives pour comprimer l'espacement des caractères.
            $portion->getPortionFormat()->setSpacing(3); // Agrandir l'espacement des caractères.
        }
    }

    $presentation->save("character_spacing_in_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Le résultat :

![L'espacement des caractères dans les portions de texte](character_spacing_in_text_portions.png)

### **Désactiver le crénage pour des polices spécifiques**

Dans certains cas, le texte rendu par Aspose.Slides peut sembler légèrement plus serré que le même texte affiché dans PowerPoint. Cela peut se produire parce que PowerPoint peut ignorer les données de crénage pour certaines polices, même lorsque la police contient des informations de crénage valides et que le crénage est activé dans les paramètres de PowerPoint.

Pour rendre la sortie rendue plus proche de PowerPoint dans ces cas, vous pouvez désactiver le crénage pour les portions de texte qui utilisent la police concernée. Définissez [BasePortionFormat::setKerningMinimalSize](https://reference.aspose.com/slides/fr/php-java/aspose.slides/baseportionformat/#setKerningMinimalSize) à une valeur nettement supérieure à la taille réelle de la police :

```php
$presentation = new Presentation("presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
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

Ce paramètre empêche l'application du crénage aux portions de texte correspondantes et peut aider à aligner le rendu d'Aspose.Slides avec la sortie visuelle de PowerPoint pour les polices affectées par ce comportement spécifique à PowerPoint.

## **Gérer les propriétés de police du texte**

Les propriétés de police peuvent être définies au niveau du paragraphe via [ParagraphFormat::getDefaultPortionFormat](https://reference.aspose.com/slides/fr/php-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) ou sur des portions individuelles via [PortionFormat](https://reference.aspose.com/slides/fr/php-java/aspose.slides/portionformat/).

Le code suivant définit la police et le style du texte pour l'ensemble du paragraphe : il applique la taille de police, le gras, l'italique, le soulignement pointillé et la police Times New Roman à toutes les portions du paragraphe.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $defaultPortionFormat = $paragraph->getParagraphFormat()->getDefaultPortionFormat();
    $font = new FontData("Times New Roman");

    // Définir les propriétés de police pour le paragraphe.
    $defaultPortionFormat->setFontHeight(12);
    $defaultPortionFormat->setFontBold(NullableBool::True);
    $defaultPortionFormat->setFontItalic(NullableBool::True);
    $defaultPortionFormat->setFontUnderline(TextUnderlineType::Dotted);
    $defaultPortionFormat->setLatinFont($font);

    $presentation->save("font_properties_for_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Le résultat :

![Les propriétés de police du paragraphe](font_properties_for_paragraph.png)

L'exemple de code ci‑dessous applique des propriétés similaires aux **portions de texte en gras** :

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $font = new FontData("Times New Roman");

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold()) === NullableBool::True) {
            // Définir les propriétés de police pour la portion de texte.
            $portionFormat = $portion->getPortionFormat();
            $portionFormat->setFontHeight(13);
            $portionFormat->setFontItalic(NullableBool::True);
            $portionFormat->setFontUnderline(TextUnderlineType::Dotted);
            $portionFormat->setLatinFont($font);
        }
    }

    $presentation->save("font_properties_for_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Le résultat :

![Les propriétés de police des portions de texte](font_properties_for_text_portions.png)

## **Définir la rotation du texte**

Utilisez [TextFrameFormat::setTextVerticalType](https://reference.aspose.com/slides/fr/php-java/aspose.slides/textframeformat/#setTextVerticalType) pour définir une orientation de texte prédéfinie à l'intérieur d'une forme.

L'exemple de code suivant définit l'orientation du texte dans la forme à `Vertical270`, ce qui fait pivoter le texte de **90 degrés dans le sens inverse des aiguilles d'une montre** :

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);

    $autoShape->getTextFrame()->getTextFrameFormat()->setTextVerticalType(TextVerticalType::Vertical270);

    $presentation->save("text_rotation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Le résultat :

![La rotation du texte](text_rotation.png)

## **Définir une rotation personnalisée pour les cadres de texte**

Utilisez [TextFrameFormat::setRotationAngle](https://reference.aspose.com/slides/fr/php-java/aspose.slides/textframeformat/#setRotationAngle) pour définir un angle de rotation personnalisé pour un [TextFrame](https://reference.aspose.com/slides/fr/php-java/aspose.slides/textframe/).

L'exemple de code ci‑dessus fait pivoter le cadre de texte de 3 degrés dans le sens des aiguilles d'une montre à l'intérieur de la forme :

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);

    $autoShape->getTextFrame()->getTextFrameFormat()->setRotationAngle(3);

    $presentation->save("custom_text_rotation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Le résultat :

![La rotation personnalisée du texte](custom_text_rotation.png)

## **Définir l'interligne des paragraphes**

Aspose.Slides fournit [ParagraphFormat::setSpaceAfter](https://reference.aspose.com/slides/fr/php-java/aspose.slides/paragraphformat/#setSpaceAfter), [ParagraphFormat::setSpaceBefore](https://reference.aspose.com/slides/fr/php-java/aspose.slides/paragraphformat/#setSpaceBefore) et [ParagraphFormat::setSpaceWithin](https://reference.aspose.com/slides/fr/php-java/aspose.slides/paragraphformat/#setSpaceWithin) pour contrôler l'espacement des paragraphes. Ces propriétés sont utilisées comme suit :

* Utilisez une valeur positive pour spécifier l'interligne en pourcentage de la hauteur de ligne.
* Utilisez une valeur négative pour spécifier l'interligne en points.

L'exemple de code suivant montre comment spécifier l'interligne à l'intérieur du paragraphe :

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $paragraph->getParagraphFormat()->setSpaceWithin(200);

    $presentation->save("line_spacing.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Le résultat :

![L'interligne à l'intérieur du paragraphe](line_spacing.png)

## **Définir le type d'ajustement automatique pour les cadres de texte**

[TextFrameFormat::setAutofitType](https://reference.aspose.com/slides/fr/php-java/aspose.slides/textframeformat/#setAutofitType) détermine le comportement du texte lorsqu'il dépasse les limites de son conteneur. Utilisez-le pour contrôler si le texte se rétrécit, déborde ou redimensionne automatiquement la forme.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);

    $autoShape->getTextFrame()->getTextFrameFormat()->setAutofitType(TextAutofitType::Shape);

    $presentation->save("autofit_type.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Définir l'ancrage des cadres de texte**

[TextFrameFormat::setAnchoringType](https://reference.aspose.com/slides/fr/php-java/aspose.slides/textframeformat/#setAnchoringType) définit comment le texte est positionné verticalement à l'intérieur d'une forme, par exemple en haut, au centre ou en bas.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);

    $autoShape->getTextFrame()->getTextFrameFormat()->setAnchoringType(TextAnchorType::Bottom);

    $presentation->save("text_anchor.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Définir la tabulation du texte**

Utilisez [ParagraphFormat::setDefaultTabSize](https://reference.aspose.com/slides/fr/php-java/aspose.slides/paragraphformat/#setDefaultTabSize) et [ParagraphFormat::getTabs](https://reference.aspose.com/slides/fr/php-java/aspose.slides/paragraphformat/#getTabs) pour configurer les taquets de tabulation dans un paragraphe.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $paragraph->getParagraphFormat()->setDefaultTabSize(100);
    $paragraph->getParagraphFormat()->getTabs()->add(30, TabAlignment::Left);

    $presentation->save("paragraph_tabs.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Le résultat :

![Les tabulations du paragraphe](paragraph_tabs.png)

## **Définir la langue de relecture**

Aspose.Slides fournit [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/fr/php-java/aspose.slides/baseportionformat/#setLanguageId), qui vous permet de définir la langue de relecture pour une portion de texte. La langue de relecture détermine la langue utilisée pour la vérification orthographique et grammaticale dans PowerPoint.

L'exemple de code suivant montre comment définir la langue de relecture pour une portion de texte :

```php
$presentation = new Presentation("presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);

    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getPortions()->clear();

    $font = new FontData("SimSun");

    $textPortion = new Portion();
    $textPortion->getPortionFormat()->setComplexScriptFont($font);
    $textPortion->getPortionFormat()->setEastAsianFont($font);
    $textPortion->getPortionFormat()->setLatinFont($font);

    // Définir l'Id d'une langue de relecture.
    $textPortion->getPortionFormat()->setLanguageId("zh-CN");

    $textPortion->setText("1。");
    $paragraph->getPortions()->add($textPortion);

    $presentation->save("proofing_language.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Définir la langue par défaut**

Utilisez [LoadOptions::setDefaultTextLanguage](https://reference.aspose.com/slides/fr/php-java/aspose.slides/loadoptions/#setDefaultTextLanguage) pour définir la langue par défaut du texte créé lors du chargement ou de la création d'une présentation.

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

Pour appliquer le formatage de texte par défaut au niveau de la présentation, utilisez [Presentation::getDefaultTextStyle](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/#getDefaultTextStyle).

L'exemple de code suivant montre comment définir une police par défaut en gras avec une taille de 14 pt pour tout le texte de toutes les diapositives dans une nouvelle présentation.

```php
$presentation = new Presentation();
try {
    // Récupérer le format de paragraphe de niveau supérieur.
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

## **Extraire le texte avec l'effet Tout en majuscules**

Dans PowerPoint, appliquer l'effet de police **All Caps** fait apparaître le texte en majuscules sur la diapositive même s'il a été saisi initialement en minuscules. Lorsque vous récupérez une telle portion de texte avec Aspose.Slides, la bibliothèque renvoie le texte exactement tel qu'il a été entré. Pour correspondre au texte affiché, vérifiez [TextCapType](https://reference.aspose.com/slides/fr/php-java/aspose.slides/textcaptype/) et convertissez la chaîne renvoyée en majuscules lorsque la valeur est `All`.

Supposons que nous ayons la zone de texte suivante sur la première diapositive du fichier sample2.pptx.

![L'effet Tout en majuscules](all_caps_effect.png)

L'exemple de code ci‑dessus montre comment extraire le texte avec l'effet **All Caps** appliqué :

```php
$presentation = new Presentation("sample2.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $textPortion = $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);

    $originalText = $textPortion->getText();
    echo "Original text: ", $originalText, "\n";

    $textFormat = $textPortion->getPortionFormat()->getEffective();
    if (java_values($textFormat->getTextCapType()) === TextCapType::All) {
        $text = strtoupper($originalText);
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

Pour modifier le texte dans un tableau sur une diapositive, utilisez [Table](https://reference.aspose.com/slides/fr/php-java/aspose.slides/table/). Parcourez les cellules et mettez à jour chaque cellule via [Cell::getTextFrame](https://reference.aspose.com/slides/fr/php-java/aspose.slides/cell/#getTextFrame) et le formatage des paragraphes via [Paragraph::getParagraphFormat](https://reference.aspose.com/slides/fr/php-java/aspose.slides/paragraph/#getParagraphFormat).

**Comment appliquer une couleur dégradée au texte dans une diapositive PowerPoint ?**

Pour appliquer une couleur dégradée au texte, utilisez [BasePortionFormat::getFillFormat](https://reference.aspose.com/slides/fr/php-java/aspose.slides/baseportionformat/#getFillFormat). Définissez [FillFormat::setFillType](https://reference.aspose.com/slides/fr/php-java/aspose.slides/fillformat/#setFillType) sur [FillType::Gradient](https://reference.aspose.com/slides/fr/php-java/aspose.slides/filltype/) et configurez les arrêts du dégradé, la direction et la transparence.