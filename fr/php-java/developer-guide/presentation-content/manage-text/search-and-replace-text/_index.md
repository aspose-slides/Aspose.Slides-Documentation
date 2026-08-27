---
title: Rechercher et remplacer du texte dans les présentations PowerPoint en PHP
linktitle: Rechercher et remplacer du texte
type: docs
weight: 55
url: /fr/php-java/search-and-replace-text/
keywords:
- recherche de texte
- surligner le texte
- remplacer le texte
- expression régulière
- rappel de résultat
- cadre de texte
- rapport d'audit
- PowerPoint
- OpenDocument
- présentation
- PHP
- Aspose.Slides
description: "Recherchez, surlignez et remplacez du texte dans les présentations PowerPoint tout en collectant chaque correspondance avec Aspose.Slides for PHP via Java."
---
## **Vue d'ensemble**

Aspose.Slides for PHP via Java peut rechercher, mettre en surbrillance et remplacer du texte dans un cadre de texte individuel ou dans l’ensemble d’une présentation. Chaque opération peut également notifier une application de chaque correspondance via un rappel de résultat. Cela permet de mettre à jour une présentation et, simultanément, de créer une piste d’audit contenant le texte correspondant, son contexte, sa position, le cadre de texte et le numéro de diapositive.

Ces capacités sont utiles pour la révision, la rédaction, la vérification de terminologie, le nettoyage de modèles et les flux de travail de rapports automatisés.

Dans les premiers exemples ci‑dessous, nous utilisons un fichier nommé **sample.pptx**, qui contient une seule zone de texte sur la première diapositive avec le texte suivant :

![Texte d'exemple](sample_text.png)

## **Choisir la portée de la recherche**

Utilisez les méthodes de [TextFrame](https://reference.aspose.com/slides/fr/php-java/aspose.slides/textframe/) pour limiter une opération à un seul cadre de texte. Utilisez les méthodes de [Presentation](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/) pour traiter tout le texte applicable de la présentation.

| Opération | Un cadre de texte | Présentation entière |
|---|---|---|
| Mettre en surbrillance le texte littéral | [TextFrame::highlightText](https://reference.aspose.com/slides/fr/php-java/aspose.slides/textframe/#highlightText) | [Presentation::highlightText](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/#highlightText) |
| Mettre en surbrillance les correspondances d'expression régulière | [TextFrame::highlightRegex](https://reference.aspose.com/slides/fr/php-java/aspose.slides/textframe/#highlightRegex) | [Presentation::highlightRegex](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/#highlightRegex) |
| Remplacer le texte littéral | [TextFrame::replaceText](https://reference.aspose.com/slides/fr/php-java/aspose.slides/textframe/#replaceText) | [Presentation::replaceText](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/#replaceText) |
| Remplacer les correspondances d'expression régulière | [TextFrame::replaceRegex](https://reference.aspose.com/slides/fr/php-java/aspose.slides/textframe/#replaceRegex) | [Presentation::replaceRegex](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/#replaceRegex) |

## **Configurer la correspondance de texte**

Pour les opérations de texte littéral, utilisez [TextSearchOptions](https://reference.aspose.com/slides/fr/php-java/aspose.slides/textsearchoptions/) pour contrôler la correspondance :

- [TextSearchOptions::setWholeWordsOnly](https://reference.aspose.com/slides/fr/php-java/aspose.slides/textsearchoptions/#setWholeWordsOnly) limite les correspondances aux mots complets.  
- [TextSearchOptions::setCaseSensitive](https://reference.aspose.com/slides/fr/php-java/aspose.slides/textsearchoptions/#setCaseSensitive) contrôle si la casse des caractères doit correspondre.  
- [TextSearchOptions::setIncludeNotes](https://reference.aspose.com/slides/fr/php-java/aspose.slides/textsearchoptions/#setIncludeNotes) inclut les notes de diapositive dans les opérations de recherche, de remplacement et de mise en surbrillance au niveau de la présentation.

Les opérations d’expressions régulières utilisent un `Pattern` Java, de sorte que les règles de correspondance telles que la sensibilité à la casse et les limites de mots sont définies par l’expression et ses indicateurs.

## **Identifier le propriétaire d'un cadre de texte**

Les flux de travail génériques de traitement de texte reçoivent souvent un [TextFrame](https://reference.aspose.com/slides/fr/php-java/aspose.slides/textframe/) lors de la recherche, du remplacement, de la validation ou de l’exportation du texte. Utilisez [TextFrame::getParentShape](https://reference.aspose.com/slides/fr/php-java/aspose.slides/textframe/#getParentShape) et [TextFrame::getParentCell](https://reference.aspose.com/slides/fr/php-java/aspose.slides/textframe/#getParentCell) pour déterminer quel objet de la présentation possède le cadre de texte.

Les valeurs attendues dépendent du propriétaire :

| Propriétaire du cadre de texte | `getParentShape` | `getParentCell` |
|---|---|---|
| Un AutoShape ou une autre forme contenant du texte | Le propriétaire [Shape](https://reference.aspose.com/slides/fr/php-java/aspose.slides/shape/) | `null` |
| Une cellule de tableau | `null` | Le propriétaire [Cell](https://reference.aspose.com/slides/fr/php-java/aspose.slides/cell/) |

Les deux méthodes offrent une navigation en lecture seule. Les appeler ne déplace pas le cadre de texte et ne change pas son propriétaire. Le code générique doit vérifier les deux valeurs avec `java_is_null` et gérer la possibilité qu’aucun propriétaire ne soit disponible.

L’exemple suivant utilise [SlideUtil::getAllTextFrames](https://reference.aspose.com/slides/fr/php-java/aspose.slides/slideutil/#getAllTextFrames) pour parcourir les cadres de texte d’une présentation. Pour les formes, il indique le nom de la forme, le type d’exécution Java et la diapositive contenant la forme. Pour les cellules de tableau, il indique les coordonnées de colonne et de ligne (indexées à zéro) ainsi que la diapositive contenant la cellule.

```php
use aspose\slides\Presentation;
use aspose\slides\SlideUtil;

$presentation = new Presentation("presentation.pptx");
$arrayClass = new java_class("java.lang.reflect.Array");

try {
    $textFrames = SlideUtil::getAllTextFrames($presentation, false);
    $textFrameCount = java_values($arrayClass->getLength($textFrames));

    for ($textFrameIndex = 0; $textFrameIndex < $textFrameCount; $textFrameIndex++) {
        $textFrame = $textFrames[$textFrameIndex];
        $ownerShape = $textFrame->getParentShape();
        if (!java_is_null($ownerShape)) {
            $shapeName = java_values($ownerShape->getName());
            $shapeName = $shapeName === "" ? "(unnamed)" : $shapeName;
            $shapeType = java_values($ownerShape->getClass()->getSimpleName());
            $baseSlide = $ownerShape->getSlide();
            $slideClassName = java_values($baseSlide->getClass()->getName());

            if ($slideClassName === "com.aspose.slides.Slide") {
                $slideLabel = "slide " . java_values($baseSlide->getSlideNumber());
            } elseif ($slideClassName === "com.aspose.slides.NotesSlide") {
                $slideLabel = "notes for slide " . java_values($baseSlide->getParentSlide()->getSlideNumber());
            } else {
                $slideLabel = java_values($baseSlide->getClass()->getSimpleName());
            }

            echo("Shape: " . $shapeName . "; type: " . $shapeType . "; " . $slideLabel . "\n");
            continue;
        }

        $ownerCell = $textFrame->getParentCell();
        if (!java_is_null($ownerCell)) {
            $baseSlide = $ownerCell->getSlide();
            $slideClassName = java_values($baseSlide->getClass()->getName());

            if ($slideClassName === "com.aspose.slides.Slide") {
                $slideLabel = "slide " . java_values($baseSlide->getSlideNumber());
            } elseif ($slideClassName === "com.aspose.slides.NotesSlide") {
                $slideLabel = "notes for slide " . java_values($baseSlide->getParentSlide()->getSlideNumber());
            } else {
                $slideLabel = java_values($baseSlide->getClass()->getSimpleName());
            }

            echo("Table cell: column " . java_values($ownerCell->getFirstColumnIndex()) . ", row " . java_values($ownerCell->getFirstRowIndex()) . "; " . $slideLabel . "\n");
            continue;
        }

        echo("The text frame owner is not available as a shape or table cell.\n");
    }
} finally {
    $presentation->dispose();
}
```

Pour le contenu SmartArt, parcourez les formes de [SmartArtNode::getShapes](https://reference.aspose.com/slides/fr/php-java/aspose.slides/smartartnode/#getShapes) et accédez à chaque [SmartArtShape::getTextFrame](https://reference.aspose.com/slides/fr/php-java/aspose.slides/smartartshape/#getTextFrame). Le cadre de texte peut être relié à sa forme associée via [TextFrame::getParentShape](https://reference.aspose.com/slides/fr/php-java/aspose.slides/textframe/#getParentShape), tandis que [TextFrame::getParentCell](https://reference.aspose.com/slides/fr/php-java/aspose.slides/textframe/#getParentCell) renvoie `null`. Ainsi, la branche de forme de l’exemple gère également le texte provenant des nœuds SmartArt.

## **Collecter les informations de correspondance avec un rappel**

Passez un rappel proxy Java à une méthode de mise en surbrillance ou de remplacement pour recevoir une notification pour chaque correspondance. Le rappel reçoit le cadre de texte concerné, le texte source, le texte correspondant et la position de la correspondance.

Le rappel ne reçoit pas directement le numéro de diapositive. L’implémentation ci‑dessous le dérive de la diapositive parente et gère également le texte trouvé dans les notes de diapositive. Le tableau de résultats utilise `null` lorsque le texte est associé à un autre type de diapositive.

```php
class TextSearchCallback {
    private $results = [];

    public function getResults() {
        return $this->results;
    }

    public function foundResult($textFrame, $sourceText, $foundText, $textPosition) {
        $slideNumber = $this->getSlideNumber($textFrame);
        $this->results[] = [
            "textFrame" => $textFrame,
            "sourceText" => java_values($sourceText),
            "foundText" => java_values($foundText),
            "textPosition" => java_values($textPosition),
            "slideNumber" => $slideNumber
        ];
    }

    private function getSlideNumber($textFrame) {
        $parentShape = $textFrame->getParentShape();
        $parentCell = $textFrame->getParentCell();

        if (!java_is_null($parentShape)) {
            $parentSlide = $parentShape->getSlide();
        } elseif (!java_is_null($parentCell)) {
            $parentSlide = $parentCell->getSlide();
        } else {
            $parentSlide = $textFrame->getSlide();
        }

        if (java_is_null($parentSlide)) {
            return null;
        }

        $parentSlideClass = $parentSlide->getClass();
        $classNameValue = $parentSlideClass->getName();
        $className = java_values($classNameValue);

        if ($className === "com.aspose.slides.Slide") {
            $slideNumber = $parentSlide->getSlideNumber();
            return java_values($slideNumber);
        }

        if ($className === "com.aspose.slides.NotesSlide") {
            $slide = $parentSlide->getParentSlide();
            $slideNumber = $slide->getSlideNumber();
            return java_values($slideNumber);
        }

        return null;
    }
}
```

Créez un proxy pour cet objet PHP avant de le transmettre à une opération :

```php
$callbackHandler = new TextSearchCallback();
$callbackInterface = java("com.aspose.slides.IFindResultCallback");
$callback = java_closure(
    $callbackHandler,
    null,
    $callbackInterface
);
```

Pour les opérations de remplacement, `foundText` contient le texte correspondant d’origine, de sorte que le rappel puisse enregistrer exactement quels termes ont été remplacés.

## **Mettre en surbrillance le texte**

Utilisez la méthode [TextFrame::highlightText](https://reference.aspose.com/slides/fr/php-java/aspose.slides/textframe/#highlightText) pour mettre en surbrillance les correspondances de texte littéral dans un cadre de texte. Passez [TextSearchOptions](https://reference.aspose.com/slides/fr/php-java/aspose.slides/textsearchoptions/) pour contrôler la recherche.

L’exemple de code ci‑désert met en surbrillance toutes les occurrences des caractères **"try"** puis ne met en surbrillance que le mot complet **"to"**.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);
    $callbackHandler = new TextSearchCallback();
    $callbackInterface = java("com.aspose.slides.IFindResultCallback");
    $callback = java_closure(
        $callbackHandler,
        null,
        $callbackInterface
    );

    $substringSearchOptions = new TextSearchOptions();
    $substringSearchOptions->setCaseSensitive(false);
    $substringHighlightColor = new Java("java.awt.Color", 173, 216, 230);

    // Mettre en surbrillance chaque occurrence de "try" dans le cadre de texte.
    $shape->getTextFrame()->highlightText(
        "try",
        $substringHighlightColor,
        $substringSearchOptions,
        $callback
    );

    $wholeWordSearchOptions = new TextSearchOptions();
    $wholeWordSearchOptions->setWholeWordsOnly(true);
    $wholeWordSearchOptions->setCaseSensitive(false);
    $wholeWordHighlightColor = new Java("java.awt.Color", 238, 130, 238);

    // Mettre en surbrillance uniquement le mot complet "to".
    $shape->getTextFrame()->highlightText(
        "to",
        $wholeWordHighlightColor,
        $wholeWordSearchOptions,
        $callback
    );

    foreach ($callbackHandler->getResults() as $result) {
        echo(
            "Found '" . $result["foundText"] . "' at position " .
            $result["textPosition"] . " on slide " .
            $result["slideNumber"] . ".\n"
        );
    }

    $presentation->save("highlighted_text.pptx", SaveFormat::Pptx);
}
finally {
    $presentation->dispose();
}
```

Le résultat :

![Le texte mis en surbrillance](highlighted_text.png)

## **Mettre en surbrillance le texte à l'aide d'expressions régulières**

La méthode [TextFrame::highlightRegex](https://reference.aspose.com/slides/fr/php-java/aspose.slides/textframe/#highlightRegex) met en surbrillance les correspondances trouvées par une expression régulière dans un cadre de texte.

Le code suivant met en surbrillance tous les mots contenant sept caractères ou plus :

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);
    $regex = java("java.util.regex.Pattern")->compile("\\b[^\\s]{7,}\\b");
    $highlightColor = java("java.awt.Color")->YELLOW;

    $shape->getTextFrame()->highlightRegex($regex, $highlightColor, null);

    $presentation->save("highlighted_text_using_regex.pptx", SaveFormat::Pptx);
}
finally {
    $presentation->dispose();
}
```

Le résultat :

![Le texte mis en surbrillance à l'aide de l'expression régulière](highlighted_text_using_regex.png)

## **Mettre en surbrillance le texte sur l'ensemble d'une présentation**

Utilisez [Presentation::highlightText](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/#highlightText) et [Presentation::highlightRegex](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/#highlightRegex) pour rechercher tous les cadres de texte applicables d’une présentation. L’exemple suivant met en surbrillance un terme littéral et toutes les adresses e‑mail :

```php
$presentation = new Presentation("presentation.pptx");
try {
    $searchOptions = new TextSearchOptions();
    $searchOptions->setWholeWordsOnly(true);
    $searchOptions->setCaseSensitive(false);
    $termHighlightColor = java("java.awt.Color")->ORANGE;

    $presentation->highlightText(
        "confidential",
        $termHighlightColor,
        $searchOptions,
        null
    );

    $patternClass = java("java.util.regex.Pattern");
    $emailPattern = "\\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\\.[A-Z]{2,}\\b";
    $emailRegex = $patternClass->compile(
        $emailPattern,
        $patternClass->CASE_INSENSITIVE
    );
    $emailHighlightColor = java("java.awt.Color")->YELLOW;

    $presentation->highlightRegex($emailRegex, $emailHighlightColor, null);
    $presentation->save("highlighted_presentation.pptx", SaveFormat::Pptx);
}
finally {
    $presentation->dispose();
}
```

## **Remplacer le texte dans un cadre de texte**

Utilisez [TextFrame::replaceText](https://reference.aspose.com/slides/fr/php-java/aspose.slides/textframe/#replaceText) pour le texte littéral et [TextFrame::replaceRegex](https://reference.aspose.com/slides/fr/php-java/aspose.slides/textframe/#replaceRegex) pour le remplacement basé sur un modèle. Ces méthodes mettent à jour le texte correspondant à l’intérieur du cadre de texte existant, qui conserve le formatage de la portion environnante au lieu de reconstruire le cadre de texte à partir d’une chaîne brute.

L’exemple suivant uniformise une variante orthographique puis remplace les libellés de version :

```php
$presentation = new Presentation("presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    $searchOptions = new TextSearchOptions();
    $searchOptions->setWholeWordsOnly(true);
    $searchOptions->setCaseSensitive(false);

    $shape->getTextFrame()->replaceText(
        "colour",
        "color",
        $searchOptions,
        null
    );

    $patternClass = java("java.util.regex.Pattern");
    $versionPattern = "\\bv\\d+(?:\\.\\d+)*\\b";
    $versionRegex = $patternClass->compile(
        $versionPattern,
        $patternClass->CASE_INSENSITIVE
    );
    $shape->getTextFrame()->replaceRegex(
        $versionRegex,
        "current version",
        null
    );

    $presentation->save("updated_text_frame.pptx", SaveFormat::Pptx);
}
finally {
    $presentation->dispose();
}
```

Si une correspondance s’étend sur des portions au formatage différent, examinez la sortie pour confirmer quel format doit être appliqué au texte de remplacement.

## **Remplacer le texte sur l'ensemble d'une présentation**

Utilisez [Presentation::replaceText](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/#replaceText) et [Presentation::replaceRegex](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/#replaceRegex) pour appliquer les mêmes opérations à l’ensemble de la présentation. Ceci est utile pour le nettoyage de modèles, les mises à jour de terminologie et la rédaction.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $searchOptions = new TextSearchOptions();
    $searchOptions->setWholeWordsOnly(true);
    $searchOptions->setCaseSensitive(true);

    $presentation->replaceText(
        "Contoso",
        "Example Corp",
        $searchOptions,
        null
    );

    $accountNumberRegex = java("java.util.regex.Pattern")->compile(
        "\\bACCT-\\d{6}\\b"
    );
    $presentation->replaceRegex(
        $accountNumberRegex,
        "ACCT-REDACTED",
        null
    );

    $presentation->save("updated_presentation.pptx", SaveFormat::Pptx);
}
finally {
    $presentation->dispose();
}
```

## **Regrouper les correspondances pour les rapports**

Comme chaque résultat stocke son numéro de diapositive et son cadre de texte, les applications peuvent regrouper les correspondances pour les audits, les rapports ou les flux de révision. L’exemple suivant regroupe les résultats collectés d’abord par diapositive, puis par cadre de texte :

```php
$matchesBySlide = [];
$systemClass = java("java.lang.System");

foreach ($callbackHandler->getResults() as $result) {
    $slideNumber = $result["slideNumber"];
    $slideLabel = $slideNumber === null ? "Other" : (string) $slideNumber;
    $textFrame = $result["textFrame"];
    $textFrameHash = $systemClass->identityHashCode($textFrame);
    $textFrameKey = (string) java_values($textFrameHash);

    if (!isset($matchesBySlide[$slideLabel])) {
        $matchesBySlide[$slideLabel] = [];
    }

    if (!isset($matchesBySlide[$slideLabel][$textFrameKey])) {
        $matchesBySlide[$slideLabel][$textFrameKey] = [
            "textFrame" => $textFrame,
            "matches" => []
        ];
    }

    $matchesBySlide[$slideLabel][$textFrameKey]["matches"][] = $result;
}

foreach ($matchesBySlide as $slideLabel => $textFrameGroups) {
    echo("Slide: " . $slideLabel . "\n");

    foreach ($textFrameGroups as $textFrameGroup) {
        $textFrame = $textFrameGroup["textFrame"];
        echo("  Text frame: " . $textFrame->getText() . "\n");

        foreach ($textFrameGroup["matches"] as $result) {
            echo(
                "    '" . $result["foundText"] . "' at position " .
                $result["textPosition"] . "; context: '" .
                $result["sourceText"] . "'\n"
            );
        }
    }
}
```

## **FAQ**

**Comment puis‑je rechercher uniquement une zone de texte au lieu de l'ensemble de la présentation ?**

Récupérez le cadre de texte de la forme et appelez [TextFrame::highlightText](https://reference.aspose.com/slides/fr/php-java/aspose.slides/textframe/#highlightText), [TextFrame::highlightRegex](https://reference.aspose.com/slides/fr/php-java/aspose.slides/textframe/#highlightRegex), [TextFrame::replaceText](https://reference.aspose.com/slides/fr/php-java/aspose.slides/textframe/#replaceText) ou [TextFrame::replaceRegex](https://reference.aspose.com/slides/fr/php-java/aspose.slides/textframe/#replaceRegex) sur ce cadre de texte. Les méthodes au niveau de la présentation traitent tous les cadres de texte applicables.

**Comment puis‑je faire correspondre des mots complets avec la bonne capitalisation ?**

Définissez [TextSearchOptions::setWholeWordsOnly](https://reference.aspose.com/slides/fr/php-java/aspose.slides/textsearchoptions/#setWholeWordsOnly) et [TextSearchOptions::setCaseSensitive](https://reference.aspose.com/slides/fr/php-java/aspose.slides/textsearchoptions/#setCaseSensitive) sur `true` et transmettez les options à une méthode de mise en surbrillance ou de remplacement de texte littéral. Pour les expressions régulières, définissez les limites de mots et la sensibilité à la casse directement dans le `Pattern` Java.

**La recherche et le remplacement peuvent‑ils inclure le texte des notes de diapositive ?**

Oui. Définissez [TextSearchOptions::setIncludeNotes](https://reference.aspose.com/slides/fr/php-java/aspose.slides/textsearchoptions/#setIncludeNotes) sur `true` lors de l’utilisation d’une opération de texte littéral au niveau de la présentation.

**Comment créer un rapport sans analyser à nouveau la présentation ?**

Passez un rappel proxy Java à l’opération de mise en surbrillance ou de remplacement. Il reçoit chaque correspondance pendant l’exécution de l’opération, de sorte que l’application puisse stocker le texte source, le texte correspondant, la position, le cadre de texte et le numéro de diapositive dérivé pour un regroupement ou une exportation ultérieure.

**Le remplacement du texte préserve‑t‑il son formatage ?**

[TextFrame::replaceText](https://reference.aspose.com/slides/fr/php-java/aspose.slides/textframe/#replaceText) et [TextFrame::replaceRegex](https://reference.aspose.com/slides/fr/php-java/aspose.slides/textframe/#replaceRegex) modifient le texte correspondant à l’intérieur du cadre de texte existant et conservent le formatage des portions environnantes. Si une correspondance s’étend sur des portions dont le formatage diffère, inspectez le résultat pour vous assurer que le remplacement utilise le style souhaité.