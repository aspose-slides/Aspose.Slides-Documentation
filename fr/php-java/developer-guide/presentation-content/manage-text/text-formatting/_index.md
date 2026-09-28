---
title: Mise en forme du texte de présentation en PHP
linktitle: Mise en forme du texte
type: docs
weight: 50
url: /fr/php-java/text-formatting/
keywords:
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
description: "Formatez et stylisez le texte dans les présentations PowerPoint et OpenDocument à l'aide d'Aspose.Slides pour PHP via Java. Personnalisez les polices, les couleurs, l'alignement et plus encore."
---
## **Vue d'ensemble**

Cet article montre comment mettre en forme du texte dans des présentations PowerPoint et OpenDocument à l’aide d’Aspose.Slides pour PHP via Java. Il couvre les couleurs d’arrière‑plan, la transparence, l’espacement des caractères, les propriétés de police, la rotation, l’espacement des paragraphes, le comportement d’ajustement automatique, l’ancrage du texte, les tabulations et les paramètres de langue.

Sauf indication contraire, les exemples utilisent [sample.pptx](sample.pptx). La première forme sur la première diapositive est une zone de texte, et son premier paragraphe contient le texte montré ci‑dessous. Les index de diapositive et de forme sont basés sur zéro. Les exemples qui sélectionnent des portions en gras utilisent la mise en forme effective, y compris la mise en forme en gras héritée :

![Texte d'exemple](sample_text.png)

Pour rechercher et mettre en évidence du texte littéral ou des correspondances d’expression régulière, voir [Search and Replace Text](/slides/fr/php-java/search-and-replace-text/).

## **Définir la couleur d'arrière-plan du texte**

Utilisez [ParagraphFormat::getDefaultPortionFormat](https://reference.aspose.com/slides/fr/php-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) pour définir la couleur de surbrillance par défaut d’un paragraphe, ou utilisez [BasePortionFormat::getHighlightColor](https://reference.aspose.com/slides/fr/php-java/aspose.slides/baseportionformat/#getHighlightColor) pour des portions de texte individuelles.

L’exemple suivant définit une surbrillance gris clair comme valeur par défaut pour le premier paragraphe. Les couleurs de surbrillance explicites sur les portions individuelles prévalent sur cette valeur par défaut :

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

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

L’exemple de code ci‑dessous montre comment définir la couleur d’arrière‑plan pour **les portions de texte avec une police en gras** :

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $highlightColor = java("java.awt.Color")->LIGHT_GRAY;

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold())) {
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

![Les portions de texte gris](gray_text_portions.png)

## **Aligner les paragraphes de texte**

Utilisez [ParagraphFormat::setAlignment](https://reference.aspose.com/slides/fr/php-java/aspose.slides/paragraphformat/#setAlignment) pour définir l’alignement du paragraphe dans un cadre de texte. La valeur peut être centrée, alignée à gauche, alignée à droite, justifiée, etc.

L’exemple de code suivant montre comment aligner le paragraphe au **centre** :

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextAlignment;

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

La transparence du texte est contrôlée via le composant alpha de la couleur assignée à [BasePortionFormat::getFillFormat](https://reference.aspose.com/slides/fr/php-java/aspose.slides/baseportionformat/#getFillFormat). Dans les exemples ci‑dessous, `alpha = 50` est une valeur alpha ARGB sur l’échelle 0‑255, et non un pourcentage de transparence.

L’exemple de code suivant montre comment appliquer la transparence au **paragraphe entier** :

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

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

L’exemple suivant montre comment appliquer la transparence aux **portions de texte avec une police en gras** :

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

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
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold())) {
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

## **Définir l’espacement des caractères du texte**

Utilisez [BasePortionFormat::setSpacing](https://reference.aspose.com/slides/fr/php-java/aspose.slides/baseportionformat/#setSpacing) pour augmenter ou réduire l’espacement entre les caractères d’une zone de texte. Les exemples ajoutent 3 points d’espacement ; des valeurs négatives condensent le texte.

Le code PHP suivant montre comment augmenter l’espacement des caractères dans le **paragraphe entier** :

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    // Remarque : utilisez des valeurs négatives pour compresser l'espacement des caractères.
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setSpacing(3); // Étendre l'espacement des caractères.

    $presentation->save("character_spacing_in_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Le résultat :

![L’espacement des caractères dans le paragraphe](character_spacing_in_paragraph.png)

L’exemple de code ci‑dessous montre comment augmenter l’espacement des caractères dans les **portions de texte avec une police en gras** :

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold())) {
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

![L’espacement des caractères dans les portions de texte](character_spacing_in_text_portions.png)

### **Désactiver le crénage pour des polices spécifiques**

Dans certains cas, le texte rendu par Aspose.Slides peut sembler légèrement plus serré que le même texte affiché dans PowerPoint. Cela peut se produire parce que PowerPoint ignore les données de crénage pour certaines polices, même lorsque la police contient des informations de crénage valides et que le crénage est activé dans les paramètres de PowerPoint.

Pour que le rendu se rapproche de celui de PowerPoint dans ces cas, vous pouvez désactiver le crénage pour les portions de texte qui utilisent la police concernée. Définissez [BasePortionFormat::setKerningMinimalSize](https://reference.aspose.com/slides/fr/php-java/aspose.slides/baseportionformat/#setKerningMinimalSize) à une valeur supérieure à la taille réelle de la police. Cet exemple nécessite «presentation.pptx» contenant une zone de texte comme première forme sur la première diapositive. Il vérifie les noms de police effectifs, y compris les polices héritées, et fixe un seuil de 100 points pour les portions qui utilisent Roboto. Cela désactive le crénage pour les portions correspondantes dont la taille de police est inférieure à 100 points :

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

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
            $portionFormat = $portion->getPortionFormat()->getEffective();
            $latinFont = $portionFormat->getLatinFont();
            $eastAsianFont = $portionFormat->getEastAsianFont();
            $complexScriptFont = $portionFormat->getComplexScriptFont();

            if ((!java_is_null($latinFont) && $latinFont->getFontName() == $targetFont) ||
                (!java_is_null($eastAsianFont) && $eastAsianFont->getFontName() == $targetFont) ||
                (!java_is_null($complexScriptFont) && $complexScriptFont->getFontName() == $targetFont)) {
                $portion->getPortionFormat()->setKerningMinimalSize(100);
            }
        }
    }

    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Pour le texte correspondant en dessous du seuil, ce paramètre empêche le crénage et peut aider à aligner le rendu d’Aspose.Slides avec la sortie visuelle de PowerPoint pour les polices affectées par ce comportement propre à PowerPoint.

## **Gérer les propriétés de police du texte**

Les propriétés de police peuvent être définies au niveau du paragraphe via [ParagraphFormat::getDefaultPortionFormat](https://reference.aspose.com/slides/fr/php-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) ou sur des portions individuelles via [PortionFormat](https://reference.aspose.com/slides/fr/php-java/aspose.slides/portionformat/).

L’exemple suivant définit la police par défaut du premier paragraphe à Times New Roman 12 points avec du gras, de l’italique et un soulignement pointillé. La mise en forme explicite sur les portions individuelles prévaudra sur ces valeurs par défaut :

```php
use aspose\slides\FontData;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextUnderlineType;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $defaultPortionFormat = $paragraph->getParagraphFormat()->getDefaultPortionFormat();
    $font = new FontData("Times New Roman");

    // Définir les propriétés de police du paragraphe.
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

L’exemple suivant applique Times New Roman 13 points, une mise en forme italique et un soulignement pointillé aux portions dont la mise en forme effective est en gras :

```php
use aspose\slides\FontData;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextUnderlineType;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $font = new FontData("Times New Roman");

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold())) {
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

Utilisez [TextFrameFormat::setTextVerticalType](https://reference.aspose.com/slides/fr/php-java/aspose.slides/textframeformat/#setTextVerticalType) pour définir une orientation de texte prédéfinie dans une forme.

Le code suivant définit l’orientation du texte dans la forme sur [TextVerticalType::Vertical270](https://reference.aspose.com/slides/fr/php-java/aspose.slides/textverticaltype/), qui fait pivoter le texte de **90 degrés dans le sens inverse des aiguilles d’une montre** :

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextVerticalType;

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

Le code ci‑dessous fait pivoter le cadre de texte de 3 degrés dans le sens des aiguilles d’une montre au sein de la forme :

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

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

## **Définir l’interligne des paragraphes**

Aspose.Slides fournit [ParagraphFormat::setSpaceAfter](https://reference.aspose.com/slides/fr/php-java/aspose.slides/paragraphformat/#setSpaceAfter), [ParagraphFormat::setSpaceBefore](https://reference.aspose.com/slides/fr/php-java/aspose.slides/paragraphformat/#setSpaceBefore) et [ParagraphFormat::setSpaceWithin](https://reference.aspose.com/slides/fr/php-java/aspose.slides/paragraphformat/#setSpaceWithin) pour contrôler l’espacement des paragraphes. Ces propriétés sont utilisées comme suit :

* Utilisez une valeur positive pour spécifier l’interligne en pourcentage de la hauteur de ligne.
* Utilisez une valeur négative pour spécifier l’interligne en points.

L’exemple suivant fixe l’espacement à l’intérieur du premier paragraphe à 200 % de la hauteur de ligne (interligne double) :

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

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

![L’interligne au sein du paragraphe](line_spacing.png)

## **Contrôler le retour à la ligne**

Les règles de retour à la ligne d’un paragraphe sont utiles dans des blocs de texte étroits et des présentations qui mélangent du texte latin et asiatique de l’Est. Les méthodes suivantes appartiennent à [ParagraphFormat](https://reference.aspose.com/slides/fr/php-java/aspose.slides/paragraphformat/), elles s’appliquent donc à un paragraphe complet :

- [setLatinLineBreak](https://reference.aspose.com/slides/fr/php-java/aspose.slides/paragraphformat/#setLatinLineBreak) contrôle les règles de retour à la ligne latin. Dans un texte mixte, la modifier peut également changer la façon dont le texte asiatique et la ponctuation adjacents se replient.
- [setEastAsianLineBreak](https://reference.aspose.com/slides/fr/php-java/aspose.slides/paragraphformat/#setEastAsianLineBreak) contrôle les règles de retour à la ligne d’Asie de l’Est, y compris les restrictions sur les caractères en début ou fin de ligne.

Ces règles ne remplacent pas [TextFrameFormat::setWrapText](https://reference.aspose.com/slides/fr/php-java/aspose.slides/textframeformat/#setWrapText), qui active le passage à la ligne automatique dans un cadre de texte. Elles influencent la mise en page lorsqu’un passage à la ligne se produit ; elles n’insèrent pas de caractères de saut de ligne. Un saut de ligne explicite force une nouvelle ligne au sein du paragraphe indépendamment de la largeur disponible.

L’exemple autonome suivant crée un bloc de texte étroit contenant du chinois et du latin. Il définit explicitement les deux options de retour à la ligne et enregistre «line_breaking.pptx». Pour expérimenter chaque règle, modifiez la valeur correspondante tout en maintenant l’autre paramètre fixe. L’exemple utilise Arial 24 pts et SimSun avec une largeur de cadre de 160 pts et des marges horizontales du cadre à zéro. [TextFrameFormat::setAutofitType](https://reference.aspose.com/slides/fr/php-java/aspose.slides/textframeformat/#setAutofitType) est appelé avec [TextAutofitType::None](https://reference.aspose.com/slides/fr/php-java/aspose.slides/textautofittype/) afin que la taille du texte et les dimensions du cadre restent fixes :

```php
use aspose\slides\FillType;
use aspose\slides\FontData;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextAlignment;
use aspose\slides\TextAutofitType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 160, 300);
    $shape->getFillFormat()->setFillType(FillType::NoFill);

    $textFrame = $shape->getTextFrame();
    $textFrame->getTextFrameFormat()->setWrapText(NullableBool::True);
    $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::None);
    $textFrame->getTextFrameFormat()->setMarginLeft(0);
    $textFrame->getTextFrameFormat()->setMarginRight(0);

    $paragraph = $textFrame->getParagraphs()->get_Item(0);
    $paragraph->setText("中文排版测试，PowerPoint 中文演示。");

    $format = $paragraph->getParagraphFormat();
    $format->setAlignment(TextAlignment::Left);
    $format->getDefaultPortionFormat()->setFontHeight(24);
    $latinFont = new FontData("Arial");
    $format->getDefaultPortionFormat()->setLatinFont($latinFont);
    $eastAsianFont = new FontData("SimSun");
    $format->getDefaultPortionFormat()->setEastAsianFont($eastAsianFont);
    $format->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $blackColor = java("java.awt.Color")->BLACK;
    $format->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor($blackColor);
    $format->setLatinLineBreak(NullableBool::False);
    $format->setEastAsianLineBreak(NullableBool::True);

    $presentation->save("line_breaking.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Contrôler la ponctuation suspendue**

[ParagraphFormat::setHangingPunctuation](https://reference.aspose.com/slides/fr/php-java/aspose.slides/paragraphformat/#setHangingPunctuation) permet à la ponctuation admissible de dépasser le bord droit de la ligne de texte au lieu d’occuper la ligne suivante. Elle s’applique à tout le paragraphe et diffère d’un retrait suspendu.

L’exemple autonome suivant active la ponctuation suspendue dans un cadre de texte de 100 pts de large et enregistre «hanging_punctuation.pptx». Avec Arial 24 pts et des marges horizontales du cadre à zéro, le point final reste après le mot «sentence» et dépasse le bord droit du texte. Réglez la propriété sur [NullableBool::False](https://reference.aspose.com/slides/fr/php-java/aspose.slides/nullablebool/) pour comparer : avec ces réglages, le point occupe une ligne séparée. Le passage à la ligne est activé et l’ajustement automatique désactivé afin de garder la largeur disponible fixe :

```php
use aspose\slides\FillType;
use aspose\slides\FontData;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextAlignment;
use aspose\slides\TextAutofitType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 100, 200);
    $shape->getFillFormat()->setFillType(FillType::NoFill);

    $textFrame = $shape->getTextFrame();
    $textFrame->getTextFrameFormat()->setWrapText(NullableBool::True);
    $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::None);
    $textFrame->getTextFrameFormat()->setMarginLeft(0);
    $textFrame->getTextFrameFormat()->setMarginRight(0);

    $paragraph = $textFrame->getParagraphs()->get_Item(0);
    $paragraph->setText("Simple text, next sentence.");

    $format = $paragraph->getParagraphFormat();
    $format->setAlignment(TextAlignment::Left);
    $format->getDefaultPortionFormat()->setFontHeight(24);
    $latinFont = new FontData("Arial");
    $format->getDefaultPortionFormat()->setLatinFont($latinFont);
    $format->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $blackColor = java("java.awt.Color")->BLACK;
    $format->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor($blackColor);
    $format->setHangingPunctuation(NullableBool::True);

    $presentation->save("hanging_punctuation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Toutes les marques de ponctuation ne peuvent pas être suspendues. Le résultat visible dépend de la disponibilité des polices et de la mise en page : changer la police, la largeur disponible, les marges ou les paramètres d’ajustement automatique peut supprimer la différence visible.

## **Définir le type d’ajustement automatique pour les cadres de texte**

[TextFrameFormat::setAutofitType](https://reference.aspose.com/slides/fr/php-java/aspose.slides/textframeformat/#setAutofitType) détermine comment le texte se comporte lorsqu’il dépasse les limites de son conteneur. Utilisez‑le pour contrôler si le texte se rétrécit, déborde ou redimensionne automatiquement la forme. L’exemple suivant configure la forme pour qu’elle redimensionne afin de contenir son texte et enregistre le résultat sous «autofit_type.pptx» :

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextAutofitType;

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

Pour compter les lignes après le passage à la ligne automatique et voir comment la largeur du texte ou de la forme modifie le résultat, consultez [Count Rendered Lines](/slides/fr/php-java/manage-paragraph/). Le nombre de lignes seul ne indique pas si le texte déborde de son conteneur.

## **Définir l’ancrage des cadres de texte**

[TextFrameFormat::setAnchoringType](https://reference.aspose.com/slides/fr/php-java/aspose.slides/textframeformat/#setAnchoringType) définit la façon dont le texte est positionné verticalement à l’intérieur d’une forme, par exemple en haut, au centre ou en bas. L’exemple suivant ancre le texte en bas de la première forme et enregistre le résultat sous «text_anchor.pptx».

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextAnchorType;

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

Utilisez [ParagraphFormat::setDefaultTabSize](https://reference.aspose.com/slides/fr/php-java/aspose.slides/paragraphformat/#setDefaultTabSize) et [ParagraphFormat::getTabs](https://reference.aspose.com/slides/fr/php-java/aspose.slides/paragraphformat/#getTabs) pour configurer les tabulations dans un paragraphe. L’exemple suivant fixe l’intervalle de tabulation par défaut à 100 points et ajoute une tabulation alignée à gauche à 30 points. Ces réglages affectent le texte contenant des caractères de tabulation :

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TabAlignment;

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

## **Définir la langue de vérification**

Aspose.Slides fournit [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/fr/php-java/aspose.slides/baseportionformat/#setLanguageId), qui permet de définir la langue de vérification pour une portion de texte. La langue de vérification détermine la langue utilisée pour les contrôles d’orthographe et de grammaire dans PowerPoint.

L’exemple suivant nécessite «presentation.pptx» avec une zone de texte comme première forme sur la première diapositive et au moins un paragraphe. Il remplace le contenu du premier paragraphe par «1。», définit SimSun comme police et assigne la langue de vérification chinois simplifié (`zh-CN`). Il enregistre le résultat sous «proofing_language.pptx» :

```php
use aspose\slides\FontData;
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

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

    // Définir l'Id d'une langue de vérification.
    $textPortion->getPortionFormat()->setLanguageId("zh-CN");

    $textPortion->setText("1。");
    $paragraph->getPortions()->add($textPortion);

    $presentation->save("proofing_language.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Définir la langue par défaut**

Utilisez [LoadOptions::setDefaultTextLanguage](https://reference.aspose.com/slides/fr/php-java/aspose.slides/loadoptions/#setDefaultTextLanguage) pour définir la langue par défaut du texte créé lors du chargement ou de la création d’une présentation. L’exemple suivant crée une présentation avec l’anglais américain comme langue de texte par défaut, ajoute une zone de texte et affiche `en-US` pour sa première portion de texte :

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

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

Pour appliquer une mise en forme de texte par défaut au niveau de la présentation, utilisez [Presentation::getDefaultTextStyle](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/#getDefaultTextStyle).

L’exemple suivant définit une police en gras de 14 pts comme valeur par défaut pour les paragraphes de niveau supérieur dans une nouvelle présentation et l’enregistre sous «default_text_style.pptx». Le texte peut hériter de ces valeurs par défaut, à moins qu’une mise en forme plus spécifique ne les surcharge.

```php
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

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

## **Extraire le texte avec l’effet Tout en Majuscules**

Dans PowerPoint, appliquer l’effet de police **Tout en majuscules** fait apparaître le texte en majuscules sur la diapositive même s’il a été saisi en minuscules. Lorsque vous récupérez une telle portion de texte avec Aspose.Slides, la bibliothèque renvoie le texte exactement tel qu’il a été saisi. Pour correspondre au texte affiché, vérifiez [TextCapType](https://reference.aspose.com/slides/fr/php-java/aspose.slides/textcaptype/) et convertissez la chaîne renvoyée en majuscules lorsque la valeur est `All`.

Cet exemple nécessite «sample2.pptx» avec une zone de texte comme première forme sur la première diapositive. La première portion du premier paragraphe contient «Hello, Aspose! » avec l’effet Tout en majuscules appliqué, comme indiqué ci‑dessous.

![L’effet Tout en majuscules](all_caps_effect.png)

Le code suivant montre comment extraire le texte avec l’effet **Tout en majuscules** appliqué :

```php
use aspose\slides\Presentation;
use aspose\slides\TextCapType;

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

Pour modifier le texte dans un tableau sur une diapositive, utilisez [Table](https://reference.aspose.com/slides/fr/php-java/aspose.slides/table/). Parcourez les cellules et mettez à jour chaque cellule via [Cell::getTextFrame](https://reference.aspose.com/slides/fr/php-java/aspose.slides/cell/#getTextFrame) et la mise en forme des paragraphes via [Paragraph::getParagraphFormat](https://reference.aspose.com/slides/fr/php-java/aspose.slides/paragraph/#getParagraphFormat).

**Comment appliquer une couleur dégradée au texte sur une diapositive PowerPoint ?**

Pour appliquer une couleur dégradée au texte, utilisez [BasePortionFormat::getFillFormat](https://reference.aspose.com/slides/fr/php-java/aspose.slides/baseportionformat/#getFillFormat). Définissez [FillFormat::setFillType](https://reference.aspose.com/slides/fr/php-java/aspose.slides/fillformat/#setFillType) sur [FillType::Gradient](https://reference.aspose.com/slides/fr/php-java/aspose.slides/filltype/) et configurez les points d’arrêt du dégradé, la direction et la transparence.