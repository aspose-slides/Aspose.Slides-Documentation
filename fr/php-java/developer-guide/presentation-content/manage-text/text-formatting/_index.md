---
title: Formater le texte de la présentation en PHP
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
- propriété d’ajustement automatique
- ancre du cadre de texte
- tabulation du texte
- langue par défaut
- PowerPoint
- OpenDocument
- présentation
- PHP
- Aspose.Slides
description: "Formatez et stylisez le texte dans les présentations PowerPoint et OpenDocument à l’aide d’Aspose.Slides pour PHP via Java. Personnalisez les polices, les couleurs, l’alignement et plus encore."
---
## **Vue d'ensemble**

Cet article montre comment mettre en forme du texte dans les présentations PowerPoint et OpenDocument à l’aide d’Aspose.Slides pour PHP via Java. Il couvre les couleurs d’arrière‑plan, la transparence, l’espacement des caractères, les propriétés de police, la rotation, l’espacement des paragraphes, le comportement d’ajustement automatique, l’ancrage du texte, les tabulations et les paramètres de langue.

Sauf indication contraire, les exemples utilisent [sample.pptx](sample.pptx). La première forme de la première diapositive est une zone de texte, et son premier paragraphe contient le texte affiché ci‑dessous. Les indices de diapositive et de forme sont basés à zéro. Les exemples qui sélectionnent des parties en gras utilisent le formatage effectif, y compris le formatage gras hérité :

![Texte d'exemple](sample_text.png)

Pour rechercher et mettre en surbrillance du texte littéral ou des correspondances d’expression régulière, voir [Rechercher et remplacer du texte](/slides/fr/php-java/search-and-replace-text/).

## **Définir la couleur d'arrière-plan du texte**

Utilisez [ParagraphFormat::getDefaultPortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) pour définir la couleur de surbrillance par défaut d’un paragraphe, ou utilisez [BasePortionFormat::getHighlightColor](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#getHighlightColor) pour des portions de texte individuelles.

L’exemple suivant définit une surbrillance gris clair comme valeur par défaut du premier paragraphe. Les couleurs de surbrillance explicites sur les portions individuelles prévalent sur cette valeur par défaut :

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

Résultat :

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

Résultat :

![Les portions de texte gris](gray_text_portions.png)

## **Aligner les paragraphes de texte**

Utilisez [ParagraphFormat::setAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setAlignment) pour définir l’alignement du paragraphe dans un cadre de texte. La valeur peut être centrée, alignée à gauche, à droite, justifiée, etc.

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

Résultat :

![Le paragraphe aligné](aligned_paragraph.png)

## **Aligner les polices dans une ligne**

Utilisez [ParagraphFormat::setFontAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setFontAlignment) pour aligner verticalement les portions de texte de tailles de police différentes dans une ligne. Ce paramètre s’applique à l’ensemble du paragraphe et contrôle l’alignement dans chacune de ses lignes.

L’exemple autonome suivant crée quatre zones de texte étiquetées sur une même diapositive. Chaque paragraphe contient le même texte en 18, 36 et 54 points, avec un alignement de police différent. Il utilise Arial, désactive l’ajustement automatique et le renvoi à la ligne, et garde les cadres de texte suffisamment grands pour une seule ligne.

```php
use aspose\slides\FillType;
use aspose\slides\FontAlignment;
use aspose\slides\FontData;
use aspose\slides\NullableBool;
use aspose\slides\Paragraph;
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextAlignment;
use aspose\slides\TextAnchorType;
use aspose\slides\TextAutofitType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $alignments = [FontAlignment::Baseline, FontAlignment::Top, FontAlignment::Center, FontAlignment::Bottom];
    $alignmentNames = ["Baseline", "Top", "Center", "Bottom"];
    $fontSizes = [18, 36, 54];
    $font = new FontData("Arial");
    $gray = java("java.awt.Color")->GRAY;
    $black = java("java.awt.Color")->BLACK;

    for ($i = 0; $i < count($alignments); $i++) {
        $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 30, 20 + $i * 130, 660, 120);
        $shape->getFillFormat()->setFillType(FillType::NoFill);
        $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);

        $textFrame = $shape->getTextFrame();
        $textFrame->getTextFrameFormat()->setAnchoringType(TextAnchorType::Top);
        $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::None);
        $textFrame->getTextFrameFormat()->setWrapText(NullableBool::False);

        $label = $textFrame->getParagraphs()->get_Item(0);
        $label->setText($alignmentNames[$i]);
        $label->getParagraphFormat()->setAlignment(TextAlignment::Left);
        $label->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(14);
        $label->getParagraphFormat()->getDefaultPortionFormat()->setLatinFont($font);
        $label->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
        $label->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor($gray);

        $paragraph = new Paragraph();
        $paragraph->getParagraphFormat()->setFontAlignment($alignments[$i]);
        $paragraph->getParagraphFormat()->setAlignment(TextAlignment::Left);
        $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setLatinFont($font);
        $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
        $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor($black);

        foreach ($fontSizes as $fontSize) {
            $portion = new Portion("Ag ");
            $portion->getPortionFormat()->setFontHeight($fontSize);
            $paragraph->getPortions()->add($portion);
        }

        $textFrame->getParagraphs()->add($paragraph);
    }

    $presentation->save("font_alignment.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Résultat :

![Comparaison des alignements de police Baseline, Top, Center et Bottom avec des tailles de police mixtes](font_alignment.png)

L’alignement de police utilise les métriques des polices, de sorte que les bords visibles des lettres individuelles ne sont pas forcément alignés exactement. L’exemple comprend à la fois une lettre majuscule et une descender pour illustrer la différence entre l’alignement de base et celui du bas. La disponibilité et le remplacement des polices, les caractères utilisés et la différence de tailles influencent le résultat. Les dimensions du cadre, les marges, l’interligne, le renvoi à la ligne et l’ajustement automatique affectent également la mise en page ; utilisez les mêmes polices et paramètres de mise en page lors de la comparaison des modes.

Ce paramètre diffère de [ParagraphFormat::setAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setAlignment), qui contrôle l’alignement horizontal du paragraphe, et de [TextFrameFormat::setAnchoringType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setAnchoringType), qui positionne le bloc de texte verticalement à l’intérieur de sa forme. Le format de texte en exposant ou indice via [BasePortionFormat::setEscapement](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setEscapement) décale les portions individuelles par rapport à la ligne de base plutôt que de définir l’alignement de police pour les lignes du paragraphe.

## **Définir la transparence du texte**

La transparence du texte est contrôlée par le composant alpha de la couleur attribuée à [BasePortionFormat::getFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#getFillFormat). Dans les exemples ci‑dessous, `alpha = 50` est une valeur de canal alpha ARGB sur l’échelle 0–255, et non un pourcentage de transparence.

L’exemple de code suivant montre comment appliquer la transparence à **l’ensemble du paragraphe** :

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

Résultat :

![Le paragraphe transparent](transparent_paragraph.png)

L’exemple de code suivant montre comment appliquer la transparence à **les portions de texte avec une police en gras** :

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

Résultat :

![Les portions de texte transparentes](transparent_text_portions.png)

## **Définir l’espacement des caractères du texte**

Utilisez [BasePortionFormat::setSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setSpacing) pour élargir ou condenser l’espacement entre les caractères d’une zone de texte. Les exemples ajoutent 3 points d’espacement ; des valeurs négatives condensent le texte.

Le code PHP suivant montre comment élargir l’espacement des caractères dans **l’ensemble du paragraphe** :

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

Résultat :

![L’espacement des caractères dans le paragraphe](character_spacing_in_paragraph.png)

L’exemple de code ci‑dessous montre comment élargir l’espacement des caractères dans **les portions de texte avec une police en gras** :

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

Résultat :

![L’espacement des caractères dans les portions de texte](character_spacing_in_text_portions.png)

### **Désactiver le crénage pour des polices spécifiques**

Dans certains cas, le texte rendu par Aspose.Slides peut sembler légèrement plus serré que le même texte affiché dans PowerPoint. Cela peut se produire parce que PowerPoint ignore les données de crénage pour certaines polices, même lorsque la police contient des informations de crénage valides et que le crénage est activé dans les paramètres de PowerPoint.

Pour rendre la sortie plus proche de PowerPoint dans ces situations, vous pouvez désactiver le crénage pour les portions de texte qui utilisent la police concernée. Fixez [BasePortionFormat::setKerningMinimalSize](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setKerningMinimalSize) à une valeur supérieure à la taille réelle de la police. Cet exemple nécessite « presentation.pptx » avec une zone de texte comme première forme de la première diapositive. Il vérifie les noms de police effectifs, y compris les polices héritées, et définit un seuil de 100 points pour les portions qui utilisent Roboto. Cela désactive le crénage pour les portions correspondantes dont la taille est inférieure à 100 points :

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

Les propriétés de police peuvent être définies au niveau du paragraphe via [ParagraphFormat::getDefaultPortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) ou sur des portions individuelles via [PortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/portionformat/).

L’exemple suivant définit la police par défaut du premier paragraphe à 12 points Times New Roman avec gras, italique et soulignement pointillé. Le formatage explicite sur les portions individuelles prévaudra sur ces valeurs par défaut.

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

Résultat :

![Les propriétés de police du paragraphe](font_properties_for_paragraph.png)

L’exemple suivant applique une police Times New Roman de 13 points, un format italique et un soulignement pointillé aux portions dont le format effectif est gras :

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

Résultat :

![Les propriétés de police des portions de texte](font_properties_for_text_portions.png)

## **Contrôler la normalisation de la hauteur du texte**

Utilisez [BasePortionFormat::setNormaliseHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setNormaliseHeight) lors de la reproduction de la typographie d’un modèle ou pour investiguer les différences de hauteur de caractères. Dans PowerPoint, l’activation de la normalisation étire ou compresse verticalement les caractères individuels afin de leur donner une hauteur visible uniforme au sein de la portion de texte. Cela ne garantit pas des hauteurs de texte égales entre différentes polices.

Définissez la propriété sur [NullableBool::True ou False](https://reference.aspose.com/slides/php-java/aspose.slides/nullablebool/) pour activer ou désactiver explicitement la normalisation. `NullableBool::NotDefined` laisse le paramètre local non défini afin que la portion hérite de la valeur, par exemple depuis le [getDefaultPortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) du paragraphe. Cela ne signifie pas `False`. Utilisez [PortionFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/portionformat/#getEffective) et lisez `getNormaliseHeight` sur les données de formatage effectif retournées pour obtenir la valeur booléenne résolue.

L’exemple autonome suivant nécessite **Arial** installé. Il crée deux blocs de texte contenant les mêmes lettres majuscules, minuscules, descendeurs et caractères accentués en 54 points. Les deux paragraphes ont la normalisation activée par défaut. La portion supérieure la désactive explicitement ; la portion inférieure l’hérite. Les tailles de cadre, les marges et l’interligne sont identiques, le renvoi à la ligne et l’ajustement automatique sont désactivés pour garder la comparaison cohérente. L’exemple affiche `False: false` et `NotDefined: true`, puis enregistre « text_height_normalization.pptx ».

```php
use aspose\slides\FillType;
use aspose\slides\FontData;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextAlignment;
use aspose\slides\TextAnchorType;
use aspose\slides\TextAutofitType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $settings = [NullableBool::False, NullableBool::NotDefined];
    $settingNames = ["False", "NotDefined"];

    for ($i = 0; $i < count($settings); $i++) {
        $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 30, 60 + $i * 200, 660, 150);
        $shape->getFillFormat()->setFillType(FillType::NoFill);
        $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);

        $textFrame = $shape->getTextFrame();
        $textFrame->setText("Hxgjpq ÅÉ 0123");
        $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::None);
        $textFrame->getTextFrameFormat()->setWrapText(NullableBool::False);
        $textFrame->getTextFrameFormat()->setAnchoringType(TextAnchorType::Top);
        $textFrame->getTextFrameFormat()->setMarginTop(0);
        $textFrame->getTextFrameFormat()->setMarginLeft(0);

        $paragraph = $textFrame->getParagraphs()->get_Item(0);
        $paragraph->getParagraphFormat()->setAlignment(TextAlignment::Left);
        $paragraph->getParagraphFormat()->setSpaceBefore(0);
        $paragraph->getParagraphFormat()->setSpaceAfter(0);
        $paragraph->getParagraphFormat()->setSpaceWithin(100);
        $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setNormaliseHeight(NullableBool::True);

        $portion = $paragraph->getPortions()->get_Item(0);
        $font = new FontData("Arial");
        $portion->getPortionFormat()->setLatinFont($font);
        $portion->getPortionFormat()->setFontHeight(54);
        $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
        $black = java("java.awt.Color")->BLACK;
        $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor($black);
        $portion->getPortionFormat()->setNormaliseHeight($settings[$i]);

        $normaliseHeight = java_values($portion->getPortionFormat()->getEffective()->getNormaliseHeight());
        echo $settingNames[$i], ": ", $normaliseHeight ? "true" : "false", PHP_EOL;
    }

    $presentation->save("text_height_normalization.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

La comparaison ci‑dessous a été exportée depuis la présentation enregistrée. La rangée supérieure a la normalisation désactivée (`False`) ; la rangée inférieure l’hérite activée (`NotDefined` → `True`). Conservez Arial installé pour reproduire cet aspect.

![Texte Arial 54 points avec normalisation désactivée en haut et normalisation héritée activée en bas](text_height_normalization.png)

La normalisation modifie la hauteur des caractères sans changer la valeur assignée à [getFontHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#getFontHeight), qui spécifie la taille de police en points. Le paragraphe [setSpaceWithin](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setSpaceWithin) contrôle l’interligne, tandis que le [setAutofitType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setAutofitType) du cadre de texte contrôle comment le texte ou son conteneur s’ajuste. Ces paramètres ont des objectifs différents et peuvent influencer la mise en page globale de manière indépendante. Pour plus d’informations sur le formatage des paragraphes et l’héritage, voir [Gérer les paragraphes](/slides/fr/php-java/manage-paragraph/).

## **Appliquer et supprimer le texte barré**

Utilisez [BasePortionFormat::setStrikethroughType](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setStrikethroughType) sur une portion de texte pour afficher des corrections, des termes annulés ou d’anciens prix sans supprimer le texte d’origine. Réglez‑le sur [TextStrikethroughType::Single ou Double](https://reference.aspose.com/slides/php-java/aspose.slides/textstrikethroughtype/) pour obtenir une ou deux lignes traversant le texte.

Pour supprimer le texte barré, utilisez [TextStrikethroughType::None](https://reference.aspose.com/slides/php-java/aspose.slides/textstrikethroughtype/#None). Cela désactive explicitement l’effet, même si le formatage environnant spécifie un texte barré. En revanche, [TextStrikethroughType::NotDefined](https://reference.aspose.com/slides/php-java/aspose.slides/textstrikethroughtype/#NotDefined) laisse le paramètre local non défini, permettant à la portion d’hériter du formatage, par exemple du paragraphe. Cela ne garantit pas la suppression du texte barré. Utilisez [PortionFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/portionformat/#getEffective) pour lire le formatage résultant, y compris les valeurs héritées.

L’exemple autonome suivant crée trois comparaisons de prix. Chaque paragraphe possède des portions distinctes pour le libellé, l’ancien prix et le prix actuel, de sorte que seul l’ancien prix soit affecté. La première rangée applique puis supprime le texte barré ; les autres rangées conservent le texte barré simple et double. Modifier ce paramètre préserve le texte et ses autres formats, y compris le gras de l’ancien prix.

```php
use aspose\slides\FillType;
use aspose\slides\FontData;
use aspose\slides\NullableBool;
use aspose\slides\Paragraph;
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextAlignment;
use aspose\slides\TextStrikethroughType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 620, 220);
    $shape->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getTextFrame()->getParagraphs()->clear();

    $labels = [ "None: ", "Single: ", "Double: " ];

    foreach ($labels as $label) {
        $paragraph = new Paragraph();
        $paragraph->getParagraphFormat()->setAlignment(TextAlignment::Left);
        $paragraph->getParagraphFormat()->setSpaceAfter(20);

        $format = $paragraph->getParagraphFormat()->getDefaultPortionFormat();
        $format->setFontHeight(28);
        $font = new FontData("Arial");
        $format->setLatinFont($font);
        $format->getFillFormat()->setFillType(FillType::Solid);
        $blackColor = java("java.awt.Color")->BLACK;
        $format->getFillFormat()->getSolidFillColor()->setColor($blackColor);

        $labelPortion = new Portion($label);
        $paragraph->getPortions()->add($labelPortion);

        $previousPrice = new Portion("$100");
        $previousPrice->getPortionFormat()->setFontBold(NullableBool::True);
        $paragraph->getPortions()->add($previousPrice);
        $currentPrice = new Portion(" → $80");
        $paragraph->getPortions()->add($currentPrice);

        $shape->getTextFrame()->getParagraphs()->add($paragraph);
    }

    $paragraphs = $shape->getTextFrame()->getParagraphs();

    // Appliquer le texte barré, puis le supprimer explicitement du premier prix précédent.
    $paragraphs->get_Item(0)->getPortions()->get_Item(1)->getPortionFormat()->setStrikethroughType(TextStrikethroughType::Single);
    $paragraphs->get_Item(0)->getPortions()->get_Item(1)->getPortionFormat()->setStrikethroughType(TextStrikethroughType::None);

    $paragraphs->get_Item(1)->getPortions()->get_Item(1)->getPortionFormat()->setStrikethroughType(TextStrikethroughType::Single);
    $paragraphs->get_Item(2)->getPortions()->get_Item(1)->getPortionFormat()->setStrikethroughType(TextStrikethroughType::Double);

    $presentation->save("strikethrough.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Résultat, de haut en bas : pas de texte barré, texte barré simple, texte barré double.

![Prix précédents sans texte barré, avec texte barré simple et avec texte barré double](strikethrough.png)

## **Définir la rotation du texte**

Utilisez [TextFrameFormat::setTextVerticalType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setTextVerticalType) pour définir une orientation de texte prédéfinie à l’intérieur d’une forme.

L’exemple de code suivant définit l’orientation du texte dans la forme sur [TextVerticalType::Vertical270](https://reference.aspose.com/slides/php-java/aspose.slides/textverticaltype/), qui fait pivoter le texte **de 90 degrés dans le sens inverse des aiguilles d’une montre** :

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

Résultat :

![La rotation du texte](text_rotation.png)

## **Afficher les chiffres côte à côte dans du texte vertical**

Pour garder un nombre à deux chiffres ensemble dans une étiquette japonaise verticale, placez les deux chiffres dans une même portion de texte et appelez [BasePortionFormat::setKumimoji](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setKumimoji) sur cette portion. L’exemple utilise [TextVerticalType::EastAsianVertical](https://reference.aspose.com/slides/php-java/aspose.slides/textverticaltype/#EastAsianVertical) et la police MS Gothic 40 points pour les deux étiquettes. Seule la valeur [NullableBool](https://reference.aspose.com/slides/php-java/aspose.slides/nullablebool/) transmise à la portion numérique diffère.

```php
use aspose\slides\FillType;
use aspose\slides\FontData;
use aspose\slides\NullableBool;
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextVerticalType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $x = 120;

    foreach ([NullableBool::True, NullableBool::False] as $kumimoji) {
        $label = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, $x, 48, 120, 420);
        $label->getFillFormat()->setFillType(FillType::NoFill);
        $label->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);

        $frame = $label->addTextFrame("");
        $frame->getTextFrameFormat()->setTextVerticalType(TextVerticalType::EastAsianVertical);

        $paragraph = $frame->getParagraphs()->get_Item(0);
        $format = $paragraph->getParagraphFormat()->getDefaultPortionFormat();
        $font = new FontData("MS Gothic");
        $format->setLatinFont($font);
        $format->setEastAsianFont($font);
        $format->setFontHeight(40);
        $format->getFillFormat()->setFillType(FillType::Solid);
        $black = java("java.awt.Color")->BLACK;
        $format->getFillFormat()->getSolidFillColor()->setColor($black);

        $digits = new Portion("12");
        $digits->getPortionFormat()->setKumimoji($kumimoji);

        $portions = $paragraph->getPortions();
        $portions->clear();
        $portions->add(new Portion("令和"));
        $portions->add($digits);
        $portions->add(new Portion("年"));

        $x += 240;
    }
    $presentation->save("vertical_date.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Dans PowerPoint, l’étiquette de gauche (`True`) montre les chiffres droits et côte à côte entre 和 et 年. L’étiquette de droite (`False`) fait pivoter la paire de 90 degrés dans le sens des aiguilles d’une montre. Les caractères japonais environnants restent droits dans les deux étiquettes.

![Comparaison PowerPoint d’étiquettes de date verticales avec chiffres droits à gauche et chiffres pivotés à droite.](vertical_date.png)

## **Définir une rotation personnalisée pour les cadres de texte**

Utilisez [TextFrameFormat::setRotationAngle](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setRotationAngle) pour définir un angle de rotation personnalisé pour un [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/).

L’exemple de code suivant fait pivoter le cadre de texte de 3 degrés dans le sens des aiguilles d’une montre à l’intérieur de la forme :

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

Résultat :

![La rotation personnalisée du texte](custom_text_rotation.png)

## **Définir l’interligne des paragraphes**

Aspose.Slides propose [ParagraphFormat::setSpaceAfter](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setSpaceAfter), [ParagraphFormat::setSpaceBefore](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setSpaceBefore) et [ParagraphFormat::setSpaceWithin](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setSpaceWithin) pour contrôler l’espacement des paragraphes. Ces propriétés s’utilisent comme suit :

* Utilisez une valeur positive pour spécifier l’interligne en pourcentage de la hauteur de ligne.
* Utilisez une valeur négative pour spécifier l’interligne en points.

L’exemple suivant définit l’espacement à l’intérieur du premier paragraphe à 200 % de la hauteur de ligne (double interligne) :

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

Résultat :

![L’interligne à l’intérieur du paragraphe](line_spacing.png)

## **Contrôler le retour à la ligne**

Les règles de retour à la ligne des paragraphes sont utiles dans des blocs de texte étroits et des présentations qui mélangent du texte latin et est‑asiatique. Les méthodes suivantes appartiennent à [ParagraphFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/), elles s’appliquent donc à un paragraphe complet :

- [setLatinLineBreak](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setLatinLineBreak) contrôle les règles de retour à la ligne latin. Dans un texte mixte, la modifier peut aussi changer l’endroit où le texte et la ponctuation est‑asiatiques adjacents sont renvoyés.
- [setEastAsianLineBreak](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setEastAsianLineBreak) contrôle les règles de retour à la ligne est‑asiatiques, y compris les restrictions sur les caractères au début et à la fin d’une ligne.

Ces règles ne remplacent pas [TextFrameFormat::setWrapText](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setWrapText), qui active le renvoi à la ligne automatique dans un cadre de texte. Elles influencent la mise en page lorsque le renvoi à la ligne se produit ; elles n’insèrent pas de caractères de saut de ligne. Un saut de ligne explicite force une nouvelle ligne dans le paragraphe indépendamment de la largeur disponible.

L’exemple autonome suivant crée un bloc de texte étroit contenant du chinois et du latin. Il définit explicitement les deux options de retour à la ligne et enregistre « line_breaking.pptx ». Pour expérimenter avec l’une ou l’autre règle, modifiez la valeur correspondante tout en maintenant les autres paramètres fixes. L’exemple utilise Arial 24 points et SimSun avec une largeur de cadre de 160 points et des marges horizontales de cadre égales à zéro. [TextFrameFormat::setAutofitType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setAutofitType) est appelé avec [TextAutofitType::None](https://reference.aspose.com/slides/php-java/aspose.slides/textautofittype/) afin que la taille du texte et les dimensions du cadre restent fixes.

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

[ParagraphFormat::setHangingPunctuation](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setHangingPunctuation) permet à la ponctuation admissible de dépasser le bord droit de la ligne de texte au lieu d’occuper la ligne suivante. Elle s’applique à l’ensemble du paragraphe et diffère d’un retrait suspendu.

L’exemple autonome suivant active la ponctuation suspendue dans un cadre de texte de 100 points de large et enregistre « hanging_punctuation.pptx ». Avec Arial 24 points et des marges horizontales de cadre à zéro, le point final reste après « sentence » et dépasse le bord droit du texte. Réglez la propriété sur [NullableBool::False](https://reference.aspose.com/slides/php-java/aspose.slides/nullablebool/) pour comparer : avec ces paramètres, le point occupe une ligne séparée. Le renvoi à la ligne est activé et l’ajustement automatique est désactivé afin de garder la largeur disponible fixe.

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

Toutes les marques de ponctuation ne peuvent pas être suspendues. Les [conditions de police et de mise en page décrites ci‑dessus](#control-line-breaking) s’appliquent également à cette comparaison : modifier la police, la largeur disponible, les marges ou les paramètres d’ajustement automatique peut supprimer la différence visible.

## **Définir le type d’ajustement automatique pour les cadres de texte**

[TextFrameFormat::setAutofitType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setAutofitType) détermine comment le texte se comporte lorsqu’il dépasse les limites de son conteneur. Utilisez‑le pour contrôler si le texte se rétrécit, déborde ou redimensionne automatiquement la forme. L’exemple suivant configure la forme pour qu’elle se redimensionne afin de s’ajuster à son texte et enregistre le résultat sous « autofit_type.pptx ».

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

Pour compter les lignes après le renvoi à la ligne automatique et voir comment la largeur du texte ou de la forme modifie le résultat, voir [Count Rendered Lines](/slides/fr/php-java/manage-paragraph/). Le simple nombre de lignes n’indique pas si le texte déborde de son conteneur.

## **Définir l’ancre des cadres de texte**

[TextFrameFormat::setAnchoringType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setAnchoringType) définit comment le texte est positionné verticalement à l’intérieur d’une forme, par exemple en haut, au milieu ou en bas. L’exemple suivant ancre le texte au bas de la première forme et enregistre le résultat sous « text_anchor.pptx ».

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

Utilisez [ParagraphFormat::setDefaultTabSize](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setDefaultTabSize) et [ParagraphFormat::getTabs](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#getTabs) pour configurer les tabulations dans un paragraphe. L’exemple suivant définit l’intervalle de tabulation par défaut à 100 points et ajoute une tabulation alignée à gauche à 30 points. Ces paramètres affectent le texte contenant des caractères de tabulation.

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

Résultat :

![Les tabulations du paragraphe](paragraph_tabs.png)

## **Définir la langue de vérification**

Aspose.Slides fournit [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setLanguageId), qui permet de définir la langue de vérification pour une portion de texte. La langue de vérification détermine la langue utilisée pour les vérifications orthographiques et grammaticales dans PowerPoint.

L’exemple suivant nécessite « presentation.pptx » avec une zone de texte comme première forme de la première diapositive et au moins un paragraphe. Il remplace le contenu du premier paragraphe par « 1。 », définit SimSun comme police et attribue la langue de vérification chinois simplifié (`zh‑CN`). Il enregistre le résultat sous « proofing_language.pptx ».

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

### **Copier les métadonnées de langue**

Lors de la copie de texte multilingue depuis un modèle, conservez à la fois [BasePortionFormat::getLanguageId](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#getLanguageId) et [BasePortionFormat::getAlternativeLanguageId](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#getAlternativeLanguageId). L’exemple autonome suivant crée une portion source avec l’anglais US comme langue et le français comme langue alternative, puis copie le texte et les identifiants vers une portion d’une nouvelle présentation.

```php
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$source = new Portion("Hello! Bonjour!");
$source->getPortionFormat()->setLanguageId("en-US");
$source->getPortionFormat()->setAlternativeLanguageId("fr-FR");

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 80);
    $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getPortions()->clear();

    $destination = new Portion();
    $destination->setText($source->getText());
    $destination->getPortionFormat()->setLanguageId($source->getPortionFormat()->getLanguageId());
    // Si la source n'a pas de langue alternative, null réinitialise la valeur de destination.
    $destination->getPortionFormat()->setAlternativeLanguageId($source->getPortionFormat()->getAlternativeLanguageId());
    $paragraph->getPortions()->add($destination);

    $presentation->save("copied_language_metadata.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Pour tester une source sans langue alternative, omettez l’attribution de `"fr-FR"`. L’identifiant alternatif sera alors `null`, et la même instruction de copie préserve son absence sans introduire de valeur par défaut, même si la destination possédait auparavant une langue alternative assignée.

Ces identifiants sont des métadonnées de langue. Les conserver ne détermine pas quel dictionnaire PowerPoint sélectionnera pour les vérifications orthographiques ou grammaticales.

## **Définir la langue par défaut**

Utilisez [LoadOptions::setDefaultTextLanguage](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/#setDefaultTextLanguage) pour définir la langue par défaut du texte créé lors du chargement ou de la création d’une présentation. L’exemple suivant crée une présentation avec l’anglais US comme langue de texte par défaut, ajoute une zone de texte et affiche `en‑US` pour sa première portion de texte.

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$loadOptions = new LoadOptions();
$loadOptions->setDefaultTextLanguage("en-US");

$presentation = new Presentation($loadOptions);
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // Ajouter une nouvelle forme rectangle avec du texte.
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

Pour appliquer un formatage de texte par défaut au niveau de la présentation, utilisez [Presentation::getDefaultTextStyle](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getDefaultTextStyle).

L’exemple suivant définit une police en gras de 14 points comme style par défaut pour les paragraphes de niveau supérieur d’une nouvelle présentation et l’enregistre sous « default_text_style.pptx ». Le texte peut hériter de ces valeurs par défaut sauf si un formatage plus précis les surcharge.

```php
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

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

## **Extraire du texte avec l’effet Tout en majuscules**

Dans PowerPoint, appliquer l’effet de police **Tout en majuscules** fait apparaître le texte en majuscules sur la diapositive même s’il a été saisi en minuscules. Lorsque vous récupérez une telle portion de texte avec Aspose.Slides, la bibliothèque renvoie le texte exactement tel qu’il a été saisi. Pour correspondre au texte affiché, vérifiez [TextCapType](https://reference.aspose.com/slides/php-java/aspose.slides/textcaptype/) et convertissez la chaîne renvoyée en majuscules lorsque la valeur est `All`.

Cet exemple nécessite « sample2.pptx » avec une zone de texte comme première forme de la première diapositive. Son premier paragraphe contient la première portion « Hello, Aspose! » avec l’effet Tout en majuscules appliqué, comme indiqué ci‑dessous.

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

**Comment modifier le texte d’un tableau sur une diapositive ?**

Pour modifier le texte d’un tableau sur une diapositive, utilisez [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/). Parcourez les cellules et mettez à jour chaque cellule via [Cell::getTextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/cell/#getTextFrame) et le formatage des paragraphes via [Paragraph::getParagraphFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getParagraphFormat).

**Comment appliquer une couleur dégradée au texte d’une diapositive PowerPoint ?**

Pour appliquer une couleur dégradée au texte, utilisez [BasePortionFormat::getFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#getFillFormat). Réglez [FillFormat::setFillType](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#setFillType) sur [FillType::Gradient](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) et configurez les points d’arrêt du dégradé, la direction et la transparence.