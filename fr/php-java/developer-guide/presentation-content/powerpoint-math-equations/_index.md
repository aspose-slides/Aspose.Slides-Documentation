---
title: Ajouter des équations mathématiques aux présentations PowerPoint en PHP
linktitle: Équations mathématiques PowerPoint
type: docs
weight: 80
url: /fr/php-java/powerpoint-math-equations/
keywords:
- équation mathématique
- symbole mathématique
- formule mathématique
- texte mathématique
- ajouter une équation mathématique
- ajouter un symbole mathématique
- ajouter une formule mathématique
- ajouter un texte mathématique
- PowerPoint
- présentation
- PHP
- Aspose.Slides
description: "Insérer et modifier des équations mathématiques dans PowerPoint PPT et PPTX avec Aspose.Slides pour PHP via Java, en prenant en charge OMML, les contrôles de formatage et des exemples de code PHP clairs."
---
## **Vue d'ensemble**

PowerPoint stocke les équations au format Office Math Markup Language (OMML). Avec Aspose.Slides pour PHP via Java, vous pouvez créer le même type de contenu mathématique de façon programmatique : fractions, radicaux, fonctions, limites, opérateurs N‑aires, matrices, tableaux et blocs mathématiques formatés.

Dans PowerPoint, les utilisateurs ajoutent généralement des équations via **Insertion > Equation** :

![Onglet Insertion de PowerPoint avec la commande Equation sélectionnée](powerpoint-math-equations_1.png)

Le résultat est du texte mathématique éditable sur la diapositive :

![Une diapositive PowerPoint contenant une équation mathématique éditable](powerpoint-math-equations_2.png)

Aspose.Slides construit ce texte mathématique à travers trois objets principaux :

- Une forme mathématique, créée avec [addMathShape](https://reference.aspose.com/slides/fr/php-java/aspose.slides/shapecollection/#addMathShape), est la forme qui contient l'équation.
- [MathPortion](https://reference.aspose.com/slides/fr/php-java/aspose.slides/mathportion/) stocke le contenu mathématique à l'intérieur du cadre de texte de la forme.
- [MathParagraph](https://reference.aspose.com/slides/fr/php-java/aspose.slides/mathparagraph/) contient un ou plusieurs objets [MathBlock](https://reference.aspose.com/slides/fr/php-java/aspose.slides/mathblock/).

La plupart des exemples ci‑dessous utilisent [MathematicalText](https://reference.aspose.com/slides/fr/php-java/aspose.slides/mathematicaltext/) et les méthodes fluides de [MathElementBase](https://reference.aspose.com/slides/fr/php-java/aspose.slides/mathelementbase/) pour garder le code court et lisible.

Pour les scénarios d’exportation MathML, consultez [Export Math Equations from Presentations in PHP via Java](/slides/fr/php-java/exporting-math-equations/).

## **Créer une équation**

Cet exemple crée une forme mathématique et ajoute le théorème de Pythagore :

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

{{% alert color="primary" %}}

`addMathShape` crée une forme qui contient déjà un paragraphe mathématique. Accédez au premier `MathPortion`, récupérez son `MathParagraph` et ajoutez des blocs mathématiques ou des éléments mathématiques.

{{% /alert %}}

## **Ajouter des fractions**

Utilisez [`divide`](https://reference.aspose.com/slides/fr/php-java/aspose.slides/mathelementbase/) pour créer une fraction. Vous pouvez choisir un style de fraction avec [MathFractionTypes](https://reference.aspose.com/slides/fr/php-java/aspose.slides/mathfractiontypes/).

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

Pour une fraction empilée, utilisez `MathFractionTypes::Bar` :

```php
$stackedFraction = (new MathematicalText("x + 1"))->divide("y - 1", MathFractionTypes::Bar);
```

## **Ajouter des radicaux**

Utilisez [`radical`](https://reference.aspose.com/slides/fr/php-java/aspose.slides/mathelementbase/) pour créer une racine carrée, une racine cubique ou toute autre racine. L'élément actuel devient la base, et l'argument devient le degré.

![Une expression radicale n‑ième avec x sous le signe radical](powerpoint-math-equations_5.png)

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

Utilisez [`asArgumentOfFunction`](https://reference.aspose.com/slides/fr/php-java/aspose.slides/mathelementbase/) ou [`function`](https://reference.aspose.com/slides/fr/php-java/aspose.slides/mathelementbase/) pour des fonctions telles que `sin(x)`, `log(x)` ou des noms de fonctions personnalisés. Pour les limites, placez `lim` dans un [MathLimit](https://reference.aspose.com/slides/fr/php-java/aspose.slides/mathlimit/) ou utilisez [`setLowerLimit`](https://reference.aspose.com/slides/fr/php-java/aspose.slides/mathelementbase/).

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

Pour un nom de fonction personnalisé, faites du nom de fonction l'élément actuel :

```php
$customFunction = (new MathematicalText("f"))->function("x + 1");
```

## **Ajouter des opérateurs N‑aires et des intégrales**

Utilisez [`nary`](https://reference.aspose.com/slides/fr/php-java/aspose.slides/mathelementbase/) pour les sommes, unions, intersections et autres opérateurs larges. Utilisez [`integral`](https://reference.aspose.com/slides/fr/php-java/aspose.slides/mathelementbase/) pour les intégrales. Les deux méthodes vous permettent de définir les limites inférieure et supérieure.

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

Les opérateurs N‑aires sont destinés aux grands opérateurs avec limites optionnelles. Les opérateurs simples tels que `+`, `-` et `=` sont généralement ajoutés comme `MathematicalText` et joints à l'expression.

Pour une intégrale, utilisez `integral` :

```php
$integralBase = (new MathematicalText("x"))->join((new MathematicalText("dx"))->toBox());
$integral = $integralBase->integral(MathIntegralTypes::Simple, "0", "1");
```

## **Ajouter des matrices**

Utilisez [MathMatrix](https://reference.aspose.com/slides/fr/php-java/aspose.slides/mathmatrix/) pour les lignes et colonnes. Les matrices n’incluent pas de crochets par défaut, donc encadrez la matrice lorsque vous avez besoin de parenthèses, crochets ou accolades.

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

## **Ajouter des tableaux d’équations**

Utilisez [`toMathArray`](https://reference.aspose.com/slides/fr/php-java/aspose.slides/mathelementbase/) lorsque vous avez besoin d’équations alignées ou d’une pile verticale d’expressions.

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

Utilisez [`asArgumentOfFunction`](https://reference.aspose.com/slides/fr/php-java/aspose.slides/mathelementbase/) quand l'argument est l'élément actuel et que le nom de la fonction est connu.

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

Utilisez les assistants d’indice et d’exposant pour les index et les puissances. Lorsque les index doivent apparaître du côté gauche de la base, utilisez [`setSubSuperscriptOnTheLeft`](https://reference.aspose.com/slides/fr/php-java/aspose.slides/mathelementbase/).

![Un Y majuscule avec indice 1 à gauche et exposant n à gauche](powerpoint-math-equations_9.png)

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

Utilisez [`enclose`](https://reference.aspose.com/slides/fr/php-java/aspose.slides/mathelementbase/) pour placer une expression entre délimiteurs. Vous pouvez également définir un caractère séparateur pour les expressions délimitées contenant plusieurs éléments.

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

## **Ajouter une boîte encadrée**

Utilisez [`toBorderBox`](https://reference.aspose.com/slides/fr/php-java/aspose.slides/mathelementbase/) lorsque l’équation elle‑même doit être encadrée.

![Une équation encadrée montrant a au carré égal b au carré plus c au carré](powerpoint-math-equations_12.png)

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

Utilisez [`group`](https://reference.aspose.com/slides/fr/php-java/aspose.slides/mathelementbase/) pour placer un caractère de regroupement au-dessus ou au-dessous d’une expression. Ajoutez une limite pour libeller les termes regroupés.

![L'expression x plus y regroupée avec le libellé tout texte en dessous](powerpoint-math-equations_15.png)

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

Utilisez les assistants de formatage uniquement lorsqu’ils clarifient la formule. Par exemple, [`overbar`](https://reference.aspose.com/slides/fr/php-java/aspose.slides/mathelementbase/) place une barre au-dessus d’un élément mathématique.

![Une expression mathématique ABC avec une barre supérieure](powerpoint-math-equations_14.png)

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

## **Référence rapide**

| Tâche | API principale |
| --- | --- |
| Créer du texte mathématique | [MathematicalText](https://reference.aspose.com/slides/fr/php-java/aspose.slides/mathematicaltext/) |
| Combiner les éléments | [join](https://reference.aspose.com/slides/fr/php-java/aspose.slides/mathelementbase/) |
| Créer des fractions | [divide](https://reference.aspose.com/slides/fr/php-java/aspose.slides/mathelementbase/) |
| Ajouter un exposant ou un indice | [setSuperscript](https://reference.aspose.com/slides/fr/php-java/aspose.slides/mathelementbase/), [setSubscript](https://reference.aspose.com/slides/fr/php-java/aspose.slides/mathelementbase/) |
| Ajouter des fonctions | [function](https://reference.aspose.com/slides/fr/php-java/aspose.slides/mathelementbase/), [asArgumentOfFunction](https://reference.aspose.com/slides/fr/php-java/aspose.slides/mathelementbase/) |
| Ajouter des radicaux | [radical](https://reference.aspose.com/slides/fr/php-java/aspose.slides/mathelementbase/) |
| Ajouter des limites | [setLowerLimit](https://reference.aspose.com/slides/fr/php-java/aspose.slides/mathelementbase/), [setUpperLimit](https://reference.aspose.com/slides/fr/php-java/aspose.slides/mathelementbase/) |
| Ajouter des scripts du côté gauche | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/fr/php-java/aspose.slides/mathelementbase/) |
| Ajouter des sommes et des intégrales | [nary](https://reference.aspose.com/slides/fr/php-java/aspose.slides/mathelementbase/), [integral](https://reference.aspose.com/slides/fr/php-java/aspose.slides/mathelementbase/) |
| Ajouter des matrices | [MathMatrix](https://reference.aspose.com/slides/fr/php-java/aspose.slides/mathmatrix/) |
| Ajouter des tableaux d’équations | [toMathArray](https://reference.aspose.com/slides/fr/php-java/aspose.slides/mathelementbase/) |
| Ajouter des délimiteurs | [enclose](https://reference.aspose.com/slides/fr/php-java/aspose.slides/mathelementbase/) |
| Ajouter des barres et des bordures | [overbar](https://reference.aspose.com/slides/fr/php-java/aspose.slides/mathelementbase/), [toBorderBox](https://reference.aspose.com/slides/fr/php-java/aspose.slides/mathelementbase/) |
| Regrouper les termes | [group](https://reference.aspose.com/slides/fr/php-java/aspose.slides/mathelementbase/) |

## **FAQ**

**Puis-je modifier une équation PowerPoint existante ?**

Oui. Ouvrez la présentation, trouvez la forme qui contient un `MathPortion`, récupérez son `MathParagraph` et mettez à jour les blocs mathématiques de ce paragraphe.

**Les équations sont‑elles enregistrées comme des mathématiques PowerPoint éditables ?**

Oui. Lors de l’enregistrement au format PPTX, Aspose.Slides écrit l’équation sous forme de contenu mathématique Office éditable.

**Puis-je exporter des équations vers LaTeX ?**

Oui. Récupérez le [MathParagraph](https://reference.aspose.com/slides/fr/php-java/aspose.slides/mathparagraph/) de son [MathPortion](https://reference.aspose.com/slides/fr/php-java/aspose.slides/mathportion/) et appelez [MathParagraph::toLatex](https://reference.aspose.com/slides/fr/php-java/aspose.slides/mathparagraph/#toLatex) pour l’exporter directement. Pour un exemple complet, voir [Export Math Equations from Presentations in PHP via Java](/slides/fr/php-java/exporting-math-equations/#export-math-equations-to-latex).