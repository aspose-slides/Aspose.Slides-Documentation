---
title: Ajouter des équations mathématiques aux présentations PowerPoint en PHP
linktitle: Équations Mathématiques PowerPoint
type: docs
weight: 80
url: /fr/php-java/powerpoint-math-equations/
keywords:
- équation mathématique
- symbole mathématique
- formule mathématique
- texte mathématique
- ajouter équation mathématique
- ajouter symbole mathématique
- ajouter formule mathématique
- ajouter texte mathématique
- PowerPoint
- présentation
- PHP
- Aspose.Slides
description: "Insérer et modifier des équations mathématiques dans PowerPoint PPT et PPTX avec Aspose.Slides pour PHP via Java, prenant en charge OMML, les contrôles de formatage et des exemples de code PHP clairs."
---
## **Vue d'ensemble**

PowerPoint stocke les équations au format Office Math Markup Language (OMML). Avec Aspose.Slides pour PHP via Java, vous pouvez créer le même type de contenu mathématique de façon programmatique : fractions, radicaux, fonctions, limites, opérateurs N‑aires, matrices, tableaux et blocs mathématiques formatés.

Dans PowerPoint, les utilisateurs ajoutent généralement des équations via **Insertion > Équation** :

![Onglet Insertion de PowerPoint avec la commande Équation sélectionnée](powerpoint-math-equations_1.png)

Le résultat est du texte mathématique modifiable sur la diapositive :

![Une diapositive PowerPoint contenant une équation mathématique modifiable](powerpoint-math-equations_2.png)

Aspose.Slides crée ce texte mathématique à l'aide de trois principaux objets :

- Une forme mathématique, créée avec [addMathShape](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addMathShape), est la forme qui contient l'équation.
- [MathPortion](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/) stocke le contenu mathématique à l'intérieur du cadre de texte de la forme.
- [MathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathparagraph/) contient un ou plusieurs objets [MathBlock](https://reference.aspose.com/slides/php-java/aspose.slides/mathblock/).

La plupart des exemples ci‑dessus utilisent [MathematicalText](https://reference.aspose.com/slides/php-java/aspose.slides/mathematicaltext/) et les méthodes en chaîne de [MathElementBase](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) pour garder le code court et lisible.

Pour les scénarios d'exportation MathML, voir [Exporter les équations mathématiques depuis des présentations en PHP via Java](/slides/fr/php-java/exporting-math-equations/).

## **Créer une équation**

Cet exemple utilise [addMathShape](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addMathShape) pour créer une forme mathématique et ajoute le théorème de Pythagore :

![L'équation c au carré égale a au carré plus b au carré](powerpoint-math-equations_3.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 120);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $equation = (new MathematicalText("c"))
        - >setSuperscript("2")
        - >join("=")
        - >join((new MathematicalText("a"))->setSuperscript("2"))
        - >join("+")
        - >join((new MathematicalText("b"))->setSuperscript("2"));

    $mathParagraph->add($equation);

    $presentation->save("pythagorean-theorem.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

{{% alert color="info" title="Note" %}}
[addMathShape](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addMathShape) crée une forme contenant déjà un paragraphe mathématique. Accédez au premier [MathPortion](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/), appelez [getMathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/#getMathParagraph), et ajoutez des blocs mathématiques ou des éléments mathématiques.
{{% /alert %}}

## **Ajouter des fractions**

Utilisez [divide](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#divide) pour créer une fraction. Vous pouvez choisir un style de fraction avec [MathFractionTypes](https://reference.aspose.com/slides/php-java/aspose.slides/mathfractiontypes/).

![Une fraction mathématique inclinée montrant un divisé par x](powerpoint-math-equations_4.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 100);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $fraction = (new MathematicalText("1"))
        - >divide("x", MathFractionTypes::Skewed);

    $mathParagraph->add(new MathBlock($fraction));

    $presentation->save("fraction.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Pour une fraction empilée, utilisez [MathFractionTypes::Bar](https://reference.aspose.com/slides/php-java/aspose.slides/mathfractiontypes/#Bar):

```php
$stackedFraction = (new MathematicalText("x + 1"))->divide("y - 1", MathFractionTypes::Bar);
```

## **Ajouter des radicaux**

Utilisez [radical](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#radical) pour créer une racine carrée, une racine cubique ou toute autre racine. L'élément courant devient la base, et l'argument devient le degré.

![Une expression radicale n‑ième racine avec x sous le signe radical](powerpoint-math-equations_5.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 100);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $radical = (new MathematicalText("x"))
        - >radical("n");

    $mathParagraph->add(new MathBlock($radical));

    $presentation->save("radical.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **Ajouter des fonctions et des limites**

Utilisez [asArgumentOfFunction](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#asArgumentOfFunction) ou [function](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#function) pour des fonctions telles que `sin(x)`, `log(x)` ou des noms de fonctions personnalisés. Pour les limites, placez `lim` dans un [MathLimit](https://reference.aspose.com/slides/php-java/aspose.slides/mathlimit/) ou utilisez [setLowerLimit](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#setLowerLimit).

![La limite de x lorsque x tend vers l'infini](powerpoint-math-equations_8.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 100);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $limit = (new MathematicalText("lim"))
        - >setLowerLimit("x\u{2192}\u{221E}")
        - >function("x");

    $mathParagraph->add(new MathBlock($limit));

    $presentation->save("functions-and-limits.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Pour un nom de fonction personnalisé, faites du nom de fonction l'élément courant et appelez [function](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#function) avec son argument :

```php
$customFunction = (new MathematicalText("f"))->function("x + 1");
```

## **Ajouter des opérateurs N‑aires et des intégrales**

Utilisez [nary](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#nary) pour les sommes, unions, intersections et autres opérateurs de grande taille. Utilisez [integral](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#integral) pour les intégrales. Les deux méthodes permettent de définir les limites inférieure et supérieure.

![Une sommation avec limites inférieure et supérieure](powerpoint-math-equations_7.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 120);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $summationBase = (new MathematicalText("x"))
        - >setSuperscript("k")
        - >join((new MathematicalText("a"))->setSuperscript("n-k"));

    $summation = $summationBase->nary(MathNaryOperatorTypes::Summation, "k=0", "n");

    $mathParagraph->add(new MathBlock($summation));

    $presentation->save("nary-operators.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Les opérateurs N‑aires sont destinés aux grands opérateurs avec limites facultatives. Les opérateurs simples tels que `+`, `-` et `=` sont généralement ajoutés comme [MathematicalText](https://reference.aspose.com/slides/php-java/aspose.slides/mathematicaltext/) et concaténés dans l'expression.

Pour une intégrale, utilisez [integral](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#integral):

```php
$integralBase = (new MathematicalText("x"))->join((new MathematicalText("dx"))->toBox());
$integral = $integralBase->integral(MathIntegralTypes::Simple, "0", "1");
```

## **Ajouter des matrices**

Utilisez [MathMatrix](https://reference.aspose.com/slides/php-java/aspose.slides/mathmatrix/) pour les lignes et colonnes. Les matrices n'incluent pas de crochets par défaut, il faut donc entourer la matrice avec des parenthèses, crochets ou accolades selon le besoin.

![Une matrice mathématique à deux lignes avec une cellule vide](powerpoint-math-equations_10.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 120);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $matrix = new MathMatrix(2, 3);
    $matrix->set_Item(0, 0, new MathematicalText("1"));
    $matrix->set_Item(0, 1, new MathematicalText("x"));
    $matrix->set_Item(1, 0, new MathematicalText("x"));
    $matrix->set_Item(1, 1, new MathematicalText("2"));
    $matrix->set_Item(1, 2, new MathematicalText("y"));

    $mathParagraph->add(new MathBlock($matrix));

    $presentation->save("matrix.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **Ajouter des tableaux d'équations**

Utilisez [toMathArray](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#toMathArray) lorsque vous avez besoin d'équations alignées ou d'une pile verticale d'expressions.

![Un tableau mathématique vertical avec x au-dessus de y](powerpoint-math-equations_11.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 140);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $equationArray = (new MathematicalText("x"))
        - >join("y")
        - >toMathArray();

    $mathParagraph->add(new MathBlock($equationArray));

    $presentation->save("equation-array.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **Ajouter des fonctions trigonométriques**

Utilisez [asArgumentOfFunction](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#asArgumentOfFunction) lorsque l'argument est l'élément courant et que le nom de la fonction est connu.

![La fonction trigonométrique cos appliquée à 2x](powerpoint-math-equations_6.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 100);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $cosine = (new MathematicalText("2x"))
        - >asArgumentOfFunction(MathFunctionsOfOneArgument::Cos);

    $mathParagraph->add(new MathBlock($cosine));

    $presentation->save("trigonometric-function.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **Ajouter des indices et exposants**

Utilisez les assistants d'indice et d'exposant pour les index et les puissances. Lorsque les index doivent apparaître du côté gauche de la base, utilisez [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#setSubSuperscriptOnTheLeft).

![Un Y majuscule avec indice gauche 1 et exposant n](powerpoint-math-equations_9.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 100);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $scripts = (new MathematicalText("Y"))
        - >setSubSuperscriptOnTheLeft("1", "n");

    $mathParagraph->add(new MathBlock($scripts));

    $presentation->save("subscript-superscript.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **Ajouter des délimiteurs**

Utilisez [enclose](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#enclose) pour placer une expression entre délimiteurs. Vous pouvez également définir un caractère séparateur pour les expressions délimitées contenant plusieurs éléments.

![Une expression délimitée contenant x, y et z séparés par des barres verticales](powerpoint-math-equations_13.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 100);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $delimiter = (new MathematicalText("x"))
        - >join("y")
        - >join("z")
        - >enclose(new Java("java.lang.Character", "<"), new Java("java.lang.Character", ">"));
    $delimiter->setSeparatorCharacter(new Java("java.lang.Character", "|"));

    $mathParagraph->add(new MathBlock($delimiter));

    $presentation->save("delimiters.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

### **Taille et alignement des délimiteurs**

Passez `true` à [setGrowToMatchOperandHeight](https://reference.aspose.com/slides/php-java/aspose.slides/mathdelimiter/#setGrowToMatchOperandHeight) pour laisser les parenthèses s'agrandir autour d'un opérande haut, ou passez `false` pour les garder à leur taille normale. Utilisez [setDelimiterShape](https://reference.aspose.com/slides/php-java/aspose.slides/mathdelimiter/#setDelimiterShape) avec l'une des deux valeurs [MathDelimiterShape](https://reference.aspose.com/slides/php-java/aspose.slides/mathdelimitershape/). `Centered` centre les parenthèses sur l'axe mathématique, qui traverse le milieu du signe égal. `Match` les aligne avec le contenu encadré. Les deux paramètres n'affectent que les délimiteurs. L'expression à l'intérieur reste la même.

L'exemple place une fraction dans l'exposant de `x` de sorte que l'expression s'étende plus haut au-dessus de la ligne de base que en dessous. Les quatre équations utilisent les mêmes parenthèses et paramètres de police.

```php
use aspose\slides\MathDelimiterShape;
use aspose\slides\MathematicalText;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $opening = new Java("java.lang.Character", "(");
    $closing = new Java("java.lang.Character", ")");
    for ($row = 0; $row < 2; $row++) {
        for ($column = 0; $column < 2; $column++) {
            $fraction = (new MathematicalText("a + b"))->divide("c + d");
            $power = (new MathematicalText("x"))->setSuperscript($fraction);
            $delimiter = $power->enclose($opening, $closing);
            $delimiter->setGrowToMatchOperandHeight($row === 0);
            $delimiter->setDelimiterShape($column === 0 ? MathDelimiterShape::Centered : MathDelimiterShape::Match);

            $mathShape = $slide->getShapes()->addMathShape(20 + 330 * $column, 20 + 120 * $row, 300, 100);
            $portion = $mathShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
            $portion->getPortionFormat()->setFontHeight(32);
            $equation = (new MathematicalText("y = "))->join($delimiter);
            $portion->getMathParagraph()->add($equation);
        }
    }
    $presentation->save("delimiter-sizing.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Dans PowerPoint, comparez les lignes pour voir l'effet de l'agrandissement. Dans la première ligne, les parenthèses croissent pour entourer l'exposant et sont identiques pour les deux formes. Dans la ligne du bas, l'agrandissement est désactivé. Les petites parenthèses à gauche (`Centered`) s'alignent avec le signe égal, tandis que celles à droite (`Match`) se placent plus haut autour de l'expression.

![Quatre équations dans PowerPoint avec l'agrandissement des délimiteurs activé en haut et désactivé en bas, et Centered à gauche et Match à droite](delimiter-sizing.png)

## **Ajouter une boîte bordée**

Utilisez [toBorderBox](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#toBorderBox) lorsque l'équation elle‑même doit être encadrée.

![Une équation encadrée montrant a au carré égale b au carré plus c au carré](powerpoint-math-equations_12.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 100);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $boxedEquation = (new MathematicalText("a"))
        - >setSuperscript("2")
        - >join("=")
        - >join((new MathematicalText("b"))->setSuperscript("2"))
        - >join("+")
        - >join((new MathematicalText("c"))->setSuperscript("2"))
        - >toBorderBox();

    $mathParagraph->add(new MathBlock($boxedEquation));

    $presentation->save("border-box.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **Regrouper les termes**

Utilisez [group](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#group) pour placer un caractère de regroupement au-dessus ou au-dessous d'une expression. Ajoutez une limite pour étiqueter les termes groupés.

![L'expression x plus y groupée avec l'étiquette texte quelconque en dessous](powerpoint-math-equations_15.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 120);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $grouped = (new MathematicalText("x + y"))
        - >group(new Java("java.lang.Character", "\u{23DF}"), MathTopBotPositions::Bottom, MathTopBotPositions::Top)
        - >setLowerLimit("any text");

    $mathParagraph->add(new MathBlock($grouped));

    $presentation->save("grouped-terms.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **Formater les éléments mathématiques**

Utilisez les assistants de mise en forme uniquement lorsque cela clarifie la formule. Par exemple, [overbar](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#overbar) place une barre au-dessus d'un élément mathématique.

![Une expression mathématique ABC avec une barre au-dessus](powerpoint-math-equations_14.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 100);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $overbar = (new MathematicalText("ABC"))->overbar();

    $mathParagraph->add(new MathBlock($overbar));

    $presentation->save("overbar.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

### **Formater le texte dans une équation existante**

Pour formater le texte dans une équation existante, parcourez l'arbre des éléments de chaque bloc mathématique. [MathElementBase::getChildren](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#getChildren) ne renvoie que les enfants immédiats, il faut donc l'appeler de façon récursive pour atteindre le texte à l'intérieur des fractions, exposants, radicaux et autres structures imbriquées. Vérifiez l'élément courant ainsi que ses enfants afin d'inclure l'élément de départ lorsqu'il s'agit d'un [MathematicalText](https://reference.aspose.com/slides/php-java/aspose.slides/mathematicaltext/).

Cet exemple suppose que `input.pptx` contient une équation telle que `z = xᵢ / ∛y`, avec une fraction contenant un indice dans son numérateur et un radical dans son dénominateur. Le traitement uniquement des éléments de niveau supérieur du bloc manquerait le texte à l'intérieur de la fraction. L'exemple trouve les portions mathématiques dans les cadres de texte des diapositives, accède à leurs blocs via [MathPortion::getMathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/#getMathParagraph), et utilise [setFontHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight) pour définir la taille de police à 28 points via la méthode [getFormat](https://reference.aspose.com/slides/php-java/aspose.slides/mathematicaltext/#getFormat) de chaque élément de texte.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

function formatMathText($element, $mathematicalTextClass) {
    if (java_instanceof($element, $mathematicalTextClass)) {
        $element->getFormat()->setFontHeight(28);
    }

    foreach ($element->getChildren() as $child) {
        formatMathText($child, $mathematicalTextClass);
    }
}

$mathematicalTextClass = new JavaClass("com.aspose.slides.MathematicalText");
$autoShapeClass = new JavaClass("com.aspose.slides.IAutoShape");
$mathPortionClass = new JavaClass("com.aspose.slides.IMathPortion");

$presentation = new Presentation("input.pptx");
try {
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
                    if (java_instanceof($portion, $mathPortionClass)) {
                        for ($blockIndex = 0; $blockIndex < java_values($portion->getMathParagraph()->getCount()); $blockIndex++) {
                            $block = $portion->getMathParagraph()->get_Item($blockIndex);
                            formatMathText($block, $mathematicalTextClass);
                        }
                    }
                }
            }
        }
    }

    $presentation->save("formatted-equations.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

La présentation enregistrée contient le formatage de texte mis à jour à chaque niveau de chaque équation traitée, tout en préservant son contenu textuel et sa structure mathématique.

## **Référence rapide**

| Tâche | API principale |
| --- | --- |
| Créer du texte mathématique | [MathematicalText](https://reference.aspose.com/slides/php-java/aspose.slides/mathematicaltext/) |
| Combiner des éléments | [join](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| Créer des fractions | [divide](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| Ajouter un exposant ou un indice | [setSuperscript](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/), [setSubscript](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| Ajouter des fonctions | [function](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/), [asArgumentOfFunction](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| Ajouter des radicaux | [radical](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| Ajouter des limites | [setLowerLimit](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/), [setUpperLimit](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| Ajouter des scripts côté gauche | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| Ajouter des sommes et des intégrales | [nary](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/), [integral](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| Ajouter des matrices | [MathMatrix](https://reference.aspose.com/slides/php-java/aspose.slides/mathmatrix/) |
| Ajouter des tableaux d'équations | [toMathArray](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| Ajouter des délimiteurs | [enclose](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| Ajouter des barres et des bordures | [overbar](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/), [toBorderBox](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| Regrouper les termes | [group](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |

## **FAQ**

**Puis-je modifier une équation PowerPoint existante ?**

Oui. Ouvrez la présentation, trouvez la forme qui contient un [MathPortion](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/), appelez [getMathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/#getMathParagraph), et mettez à jour les blocs mathématiques de ce paragraphe.

**Les équations sont‑elles enregistrées comme du mathématique PowerPoint modifiable ?**

Oui. Lors de l'enregistrement au format PPTX, Aspose.Slides écrit l'équation comme du contenu mathématique Office modifiable.

**Puis‑je exporter les équations vers LaTeX ?**

Oui. Récupérez le [MathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathparagraph/) de son [MathPortion](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/), et appelez [MathParagraph::toLatex](https://reference.aspose.com/slides/php-java/aspose.slides/mathparagraph/#toLatex) pour l'exporter directement. Pour un exemple complet, voir [Exporter les équations mathématiques depuis des présentations en PHP via Java](/slides/fr/php-java/exporting-math-equations/#export-math-equations-to-latex).