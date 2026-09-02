---
title: "Ajouter des équations mathématiques aux présentations PowerPoint en JavaScript"
linktitle: "Équations mathématiques PowerPoint"
type: docs
weight: 80
url: /fr/nodejs-java/powerpoint-math-equations/
keywords:
- "équation mathématique"
- "symbole mathématique"
- "formule mathématique"
- "texte mathématique"
- "ajouter une équation mathématique"
- "ajouter un symbole mathématique"
- "ajouter une formule mathématique"
- "ajouter un texte mathématique"
- "PowerPoint"
- "présentation"
- "Node.js"
- "JavaScript"
- "Aspose.Slides"
description: "Insérer et modifier des équations mathématiques dans les présentations PowerPoint PPT et PPTX avec Aspose.Slides pour Node.js via Java, en prenant en charge OMML, les contrôles de mise en forme et des exemples de code JavaScript clairs."
---
## **Vue d'ensemble**

PowerPoint stocke les équations au format Office Math Markup Language (OMML). Avec Aspose.Slides for Node.js via Java, vous pouvez créer le même type de contenu mathématique de façon programmatique : fractions, radicaux, fonctions, limites, opérateurs N‑aires, matrices, tableaux et blocs mathématiques formatés.

Dans PowerPoint, les utilisateurs ajoutent généralement des équations via **Insert > Equation** :

![PowerPoint Insert tab with the Equation command selected](powerpoint-math-equations_1.png)

Le résultat est du texte mathématique éditable sur la diapositive :

![A PowerPoint slide containing an editable math equation](powerpoint-math-equations_2.png)

Aspose.Slides construit ce texte mathématique à l'aide de trois objets principaux :

- Un shape mathématique, créé avec [addMathShape](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/shapecollection/#addMathShape), est la forme qui contient l'équation.
- [MathPortion](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/mathportion/) stocke le contenu mathématique à l'intérieur du cadre de texte de la forme.
- [MathParagraph](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/mathparagraph/) contient un ou plusieurs objets [MathBlock](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/mathblock/).

La plupart des exemples ci‑dessous utilisent [MathematicalText](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/mathematicaltext/) et les méthodes fluides de [MathElementBase](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/mathelementbase/) pour garder le code court et lisible.

Pour les scénarios d'exportation MathML, voir [Export Math Equations from Presentations in Node.js via Java](/slides/fr/nodejs-java/exporting-math-equations/).

## **Créer une équation**

Cet exemple crée un shape mathématique et ajoute le théorème de Pythagore :

![The equation c squared equals a squared plus b squared](powerpoint-math-equations_3.png)

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 120);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let equation = new aspose.slides.MathematicalText("c")
            .setSuperscript("2")
            .join("=")
            .join(new aspose.slides.MathematicalText("a").setSuperscript("2"))
            .join("+")
            .join(new aspose.slides.MathematicalText("b").setSuperscript("2"));

    mathParagraph.add(equation);

    presentation.save("pythagorean-theorem.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="primary" %}}
`addMathShape` crée une forme qui contient déjà un paragraphe mathématique. Accédez au premier `MathPortion`, récupérez son `MathParagraph` et ajoutez‑y des blocs mathématiques ou des éléments mathématiques.
{{% /alert %}}

## **Ajouter des fractions**

Utilisez [`divide`](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/mathelementbase/) pour créer une fraction. Vous pouvez choisir un style de fraction avec [MathFractionTypes](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/mathfractiontypes/).

![A skewed math fraction showing one divided by x](powerpoint-math-equations_4.png)

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let fraction = new aspose.slides.MathematicalText("1")
            .divide("x", aspose.slides.MathFractionTypes.Skewed);

    mathParagraph.add(new aspose.slides.MathBlock(fraction));

    presentation.save("fraction.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Pour une fraction empilée, utilisez `MathFractionTypes.Bar` :

```javascript
let stackedFraction = new aspose.slides.MathematicalText("x + 1").divide("y - 1", aspose.slides.MathFractionTypes.Bar);
```

## **Ajouter des radicaux**

Utilisez [`radical`](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/mathelementbase/) pour créer une racine carrée, une racine cubique ou toute autre racine. L'élément courant devient la base, et l'argument devient le degré.

![An n-th root radical expression with x under the radical sign](powerpoint-math-equations_5.png)

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let radical = new aspose.slides.MathematicalText("x")
            .radical("n");

    mathParagraph.add(new aspose.slides.MathBlock(radical));

    presentation.save("radical.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ajouter des fonctions et des limites**

Utilisez [`asArgumentOfFunction`](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/mathelementbase/) ou [`function`](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/mathelementbase/) pour des fonctions telles que `sin(x)`, `log(x)` ou des noms de fonction personnalisés. Pour les limites, placez `lim` dans un [MathLimit](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/mathlimit/) ou utilisez [`setLowerLimit`](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/mathelementbase/).

![The limit of x as x approaches infinity](powerpoint-math-equations_8.png)

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let limit = new aspose.slides.MathematicalText("lim")
            .setLowerLimit("x\u2192\u221E")
            .function("x");

    mathParagraph.add(new aspose.slides.MathBlock(limit));

    presentation.save("functions-and-limits.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Pour un nom de fonction personnalisé, faites du nom de la fonction l'élément courant :

```javascript
let customFunction = new aspose.slides.MathematicalText("f").function("x + 1");
```

## **Ajouter des opérateurs N‑aires et des intégrales**

Utilisez [`nary`](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/mathelementbase/) pour les sommations, unions, intersections et autres grands opérateurs. Utilisez [`integral`](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/mathelementbase/) pour les intégrales. Les deux méthodes vous permettent de définir les limites inférieure et supérieure.

![A summation with lower and upper limits](powerpoint-math-equations_7.png)

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 120);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let summationBase = new aspose.slides.MathematicalText("x")
            .setSuperscript("k")
            .join(new aspose.slides.MathematicalText("a").setSuperscript("n-k"));

    let summation = summationBase.nary(aspose.slides.MathNaryOperatorTypes.Summation, "k=0", "n");

    mathParagraph.add(new aspose.slides.MathBlock(summation));

    presentation.save("nary-operators.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Les opérateurs N‑aires sont destinés aux grands opérateurs avec limites optionnelles. Les opérateurs simples comme `+`, `-` et `=` sont généralement ajoutés en tant que `MathematicalText` et combinés dans l'expression.

Pour une intégrale, utilisez `integral` :

```javascript
let integralBase = new aspose.slides.MathematicalText("x").join(new aspose.slides.MathematicalText("dx").toBox());
let integral = integralBase.integral(aspose.slides.MathIntegralTypes.Simple, "0", "1");
```

## **Ajouter des matrices**

Utilisez [MathMatrix](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/mathmatrix/) pour les lignes et colonnes. Les matrices n'incluent pas de parenthèses par défaut, donc encadrez la matrice lorsque vous avez besoin de parenthèses, crochets ou accolades.

![A two-row math matrix with one empty cell](powerpoint-math-equations_10.png)

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 120);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let matrix = new aspose.slides.MathMatrix(2, 3);
    matrix.set_Item(0, 0, new aspose.slides.MathematicalText("1"));
    matrix.set_Item(0, 1, new aspose.slides.MathematicalText("x"));
    matrix.set_Item(1, 0, new aspose.slides.MathematicalText("x"));
    matrix.set_Item(1, 1, new aspose.slides.MathematicalText("2"));
    matrix.set_Item(1, 2, new aspose.slides.MathematicalText("y"));

    mathParagraph.add(new aspose.slides.MathBlock(matrix));

    presentation.save("matrix.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ajouter des tableaux d'équations**

Utilisez [`toMathArray`](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/mathelementbase/) lorsque vous avez besoin d'équations alignées ou d'une pile verticale d'expressions.

![A vertical math array with x above y](powerpoint-math-equations_11.png)

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 140);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let equationArray = new aspose.slides.MathematicalText("x")
            .join("y")
            .toMathArray();

    mathParagraph.add(new aspose.slides.MathBlock(equationArray));

    presentation.save("equation-array.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ajouter des fonctions trigonométriques**

Utilisez [`asArgumentOfFunction`](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/mathelementbase/) lorsque l'argument est l'élément courant et que le nom de la fonction est connu.

![The trigonometric function cos applied to 2x](powerpoint-math-equations_6.png)

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let cosine = new aspose.slides.MathematicalText("2x")
            .asArgumentOfFunction(aspose.slides.MathFunctionsOfOneArgument.Cos);

    mathParagraph.add(new aspose.slides.MathBlock(cosine));

    presentation.save("trigonometric-function.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ajouter des indices et exposants**

Utilisez les assistants d'indice et d'exposant pour les index et les puissances. Lorsque les index doivent apparaître du côté gauche de la base, utilisez [`setSubSuperscriptOnTheLeft`](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/mathelementbase/).

![A capital Y with left-side subscript 1 and superscript n](powerpoint-math-equations_9.png)

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let scripts = new aspose.slides.MathematicalText("Y")
            .setSubSuperscriptOnTheLeft("1", "n");

    mathParagraph.add(new aspose.slides.MathBlock(scripts));

    presentation.save("subscript-superscript.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ajouter des délimiteurs**

Utilisez [`enclose`](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/mathelementbase/) pour placer une expression entre délimiteurs. Vous pouvez également définir un caractère séparateur pour les expressions délimitées contenant plusieurs éléments.

![A delimiter expression containing x, y, and z separated by vertical bars](powerpoint-math-equations_13.png)

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let delimiter = new aspose.slides.MathematicalText("x")
            .join("y")
            .join("z")
            .enclose(java.newChar('<'), java.newChar('>'));
    delimiter.setSeparatorCharacter(java.newChar('|'));

    mathParagraph.add(new aspose.slides.MathBlock(delimiter));

    presentation.save("delimiters.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ajouter une boîte bordée**

Utilisez [`toBorderBox`](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/mathelementbase/) lorsque l'équation elle‑même doit être encadrée.

![A boxed equation showing a squared equals b squared plus c squared](powerpoint-math-equations_12.png)

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let boxedEquation = new aspose.slides.MathematicalText("a")
            .setSuperscript("2")
            .join("=")
            .join(new aspose.slides.MathematicalText("b").setSuperscript("2"))
            .join("+")
            .join(new aspose.slides.MathematicalText("c").setSuperscript("2"))
            .toBorderBox();

    mathParagraph.add(new aspose.slides.MathBlock(boxedEquation));

    presentation.save("border-box.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Regrouper des termes**

Utilisez [`group`](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/mathelementbase/) pour placer un caractère de groupement au-dessus ou en dessous d'une expression. Ajoutez une limite pour libeller les termes groupés.

![The expression x plus y grouped with the label any text below it](powerpoint-math-equations_15.png)

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 120);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let grouped = new aspose.slides.MathematicalText("x + y")
            .group(java.newChar('\u23DF'), aspose.slides.MathTopBotPositions.Bottom, aspose.slides.MathTopBotPositions.Top)
            .setLowerLimit("any text");

    mathParagraph.add(new aspose.slides.MathBlock(grouped));

    presentation.save("grouped-terms.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Formater les éléments mathématiques**

Utilisez les assistants de formatage uniquement lorsqu'ils clarifient la formule. Par exemple, [`overbar`](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/mathelementbase/) place une barre au-dessus d'un élément mathématique.

![A math expression ABC with an overbar](powerpoint-math-equations_14.png)

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let overbar = new aspose.slides.MathematicalText("ABC").overbar();

    mathParagraph.add(new aspose.slides.MathBlock(overbar));

    presentation.save("overbar.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Référence rapide**

| Tâche | API principale |
| --- | --- |
| Créer du texte mathématique | [MathematicalText](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/mathematicaltext/) |
| Combiner des éléments | [join](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/mathelementbase/) |
| Créer des fractions | [divide](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/mathelementbase/) |
| Ajouter un exposant ou un indice | [setSuperscript](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/mathelementbase/), [setSubscript](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/mathelementbase/) |
| Ajouter des fonctions | [function](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/mathelementbase/), [asArgumentOfFunction](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/mathelementbase/) |
| Ajouter des radicaux | [radical](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/mathelementbase/) |
| Ajouter des limites | [setLowerLimit](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/mathelementbase/), [setUpperLimit](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/mathelementbase/) |
| Ajouter des scripts du côté gauche | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/mathelementbase/) |
| Ajouter des sommations et des intégrales | [nary](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/mathelementbase/), [integral](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/mathelementbase/) |
| Ajouter des matrices | [MathMatrix](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/mathmatrix/) |
| Ajouter des tableaux d'équations | [toMathArray](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/mathelementbase/) |
| Ajouter des délimiteurs | [enclose](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/mathelementbase/) |
| Ajouter des barres et des bordures | [overbar](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/mathelementbase/), [toBorderBox](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/mathelementbase/) |
| Regrouper des termes | [group](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/mathelementbase/) |

## **FAQ**

**Puis‑je modifier une équation PowerPoint existante ?**

Oui. Ouvrez la présentation, trouvez la forme qui contient un `MathPortion`, récupérez son `MathParagraph` et mettez à jour les blocs mathématiques de ce paragraphe.

**Les équations sont‑elles enregistrées comme mathématiques PowerPoint éditables ?**

Oui. Lors de l'enregistrement au format PPTX, Aspose.Slides écrit l'équation sous forme de contenu mathématique Office éditable.

**Puis‑je exporter des équations vers LaTeX ?**

Oui. Récupérez le [MathParagraph](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/mathparagraph/) de son [MathPortion](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/mathportion/), puis appelez [MathParagraph.toLatex](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/mathparagraph/#toLatex--) pour l'exporter directement. Pour un exemple complet, voir [Export Math Equations from Presentations in Node.js via Java](/slides/fr/nodejs-java/exporting-math-equations/#export-math-equations-to-latex).