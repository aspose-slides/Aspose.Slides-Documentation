---
title: Ajouter des équations mathématiques aux présentations PowerPoint en Python
linktitle: Équations mathématiques PowerPoint
type: docs
weight: 80
url: /fr/python-net/powerpoint-math-equations/
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
- Python
- Aspose.Slides
description: "Insérer et modifier des équations mathématiques dans PowerPoint PPT et PPTX avec Aspose.Slides pour Python via .NET, en prenant en charge OMML, les contrôles de formatage et des exemples de code Python clairs."
---
## **Vue d’ensemble**

PowerPoint stocke les équations au format Office Math Markup Language (OMML). Avec Aspose.Slides for Python via .NET, vous pouvez créer le même type de contenu mathématique de façon programmatique : fractions, radicaux, fonctions, limites, opérateurs n‑aires, matrices, tableaux et blocs mathématiques formatés.

Dans PowerPoint, les utilisateurs ajoutent généralement des équations via **Insertion > Équation** :

![Onglet Insertion de PowerPoint avec la commande Équation sélectionnée](powerpoint-math-equations_1.png)

Le résultat est du texte mathématique éditable sur la diapositive :

![Une diapositive PowerPoint contenant une équation mathématique éditable](powerpoint-math-equations_2.png)

Aspose.Slides construit ce texte mathématique à l’aide de trois objets principaux :

- Une forme mathématique, créée avec [add_math_shape](https://reference.aspose.com/slides/fr/python-net/aspose.slides/shapecollection/add_math_shape/), est la forme qui contient l’équation.
- [MathPortion](https://reference.aspose.com/slides/fr/python-net/aspose.slides.mathtext/mathportion/) stocke le contenu mathématique à l’intérieur du cadre de texte de la forme.
- [MathParagraph](https://reference.aspose.com/slides/fr/python-net/aspose.slides.mathtext/mathparagraph/) contient un ou plusieurs objets [MathBlock](https://reference.aspose.com/slides/fr/python-net/aspose.slides.mathtext/mathblock/).

La plupart des exemples ci‑dessous utilisent [MathematicalText](https://reference.aspose.com/slides/fr/python-net/aspose.slides.mathtext/mathematicaltext/) et les méthodes fluides de [IMathElement](https://reference.aspose.com/slides/fr/python-net/aspose.slides.mathtext/imathelement/) pour garder le code court et lisible.

Pour les scénarios d’exportation MathML, voir [Export Math Equations from Presentations in Python via .NET](/slides/fr/python-net/exporting-math-equations/).

## **Créer une équation**

Cet exemple crée une forme mathématique et ajoute le théorème de Pythagore :

![L’équation c² = a² + b²](powerpoint-math-equations_3.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 120)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    equation = (
        math.MathematicalText("c")
        .set_superscript("2")
        .join("=")
        .join(math.MathematicalText("a").set_superscript("2"))
        .join("+")
        .join(math.MathematicalText("b").set_superscript("2"))
    )

    math_paragraph.add(equation)

    presentation.save("pythagorean-theorem.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="primary" %}}
`add_math_shape` crée une forme qui contient déjà un paragraphe mathématique. Accédez au premier `MathPortion`, obtenez son `MathParagraph`, puis ajoutez des blocs mathématiques ou des éléments mathématiques.
{{% /alert %}}

## **Ajouter des fractions**

Utilisez [`divide`](https://reference.aspose.com/slides/fr/python-net/aspose.slides.mathtext/imathelement/divide/) pour créer une fraction. Vous pouvez choisir un style de fraction avec [MathFractionTypes](https://reference.aspose.com/slides/fr/python-net/aspose.slides.mathtext/mathfractiontypes/).

![Une fraction inclinée montrant 1 divisé par x](powerpoint-math-equations_4.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 100)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    fraction = math.MathematicalText("1").divide("x", math.MathFractionTypes.SKEWED)

    math_paragraph.add(math.MathBlock(fraction))

    presentation.save("fraction.pptx", slides.export.SaveFormat.PPTX)
```

Pour une fraction empilée, utilisez `MathFractionTypes.BAR` :

```py
stacked_fraction = math.MathematicalText("x + 1").divide("y - 1", math.MathFractionTypes.BAR)
```

## **Ajouter des radicaux**

Utilisez [`radical`](https://reference.aspose.com/slides/fr/python-net/aspose.slides.mathtext/imathelement/radical/) pour créer une racine carrée, cubique ou autre. L’élément actuel devient la base, et l’argument devient le degré.

![Une expression radicale n‑ième racine avec x sous le signe radical](powerpoint-math-equations_5.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 100)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    radical = math.MathematicalText("x").radical("n")

    math_paragraph.add(math.MathBlock(radical))

    presentation.save("radical.pptx", slides.export.SaveFormat.PPTX)
```

## **Ajouter des fonctions et des limites**

Utilisez [`as_argument_of_function`](https://reference.aspose.com/slides/fr/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/) ou [`function`](https://reference.aspose.com/slides/fr/python-net/aspose.slides.mathtext/imathelement/function/) pour des fonctions telles que `sin(x)`, `log(x)` ou des noms de fonctions personnalisés. Pour les limites, placez `lim` dans un [MathLimit](https://reference.aspose.com/slides/fr/python-net/aspose.slides.mathtext/mathlimit/) ou utilisez [`set_lower_limit`](https://reference.aspose.com/slides/fr/python-net/aspose.slides.mathtext/imathelement/set_lower_limit/).

![La limite de x lorsque x tend vers l’infini](powerpoint-math-equations_8.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 100)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    limit = (
        math.MathematicalText("lim")
        .set_lower_limit("x\u2192\u221E")
        .function("x")
    )

    math_paragraph.add(math.MathBlock(limit))

    presentation.save("functions-and-limits.pptx", slides.export.SaveFormat.PPTX)
```

Pour un nom de fonction personnalisé, faites du nom de la fonction l’élément actuel :

```py
custom_function = math.MathematicalText("f").function("x + 1")
```

## **Ajouter des opérateurs n‑aires et des intégrales**

Utilisez [`nary`](https://reference.aspose.com/slides/fr/python-net/aspose.slides.mathtext/imathelement/nary/) pour les sommes, unions, intersections et autres gros opérateurs. Utilisez [`integral`](https://reference.aspose.com/slides/fr/python-net/aspose.slides.mathtext/imathelement/integral/) pour les intégrales. Les deux méthodes permettent de définir les limites inférieure et supérieure.

![Une sommation avec limites inférieure et supérieure](powerpoint-math-equations_7.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 120)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    summation_base = (
        math.MathematicalText("x")
        .set_superscript("k")
        .join(math.MathematicalText("a").set_superscript("n-k"))
    )

    summation = summation_base.nary(math.MathNaryOperatorTypes.SUMMATION, "k=0", "n")

    math_paragraph.add(math.MathBlock(summation))

    presentation.save("nary-operators.pptx", slides.export.SaveFormat.PPTX)
```

Les opérateurs n‑aires sont destinés aux gros opérateurs avec limites optionnelles. Les opérateurs simples tels que `+`, `-` et `=` sont généralement ajoutés comme `MathematicalText` et concaténés dans l’expression.

Pour une intégrale, utilisez `integral` :

```py
integral_base = math.MathematicalText("x").join(math.MathematicalText("dx").to_box())
integral = integral_base.integral(math.MathIntegralTypes.SIMPLE, "0", "1")
```

## **Ajouter des matrices**

Utilisez [MathMatrix](https://reference.aspose.com/slides/fr/python-net/aspose.slides.mathtext/mathmatrix/) pour les lignes et les colonnes. Les matrices n’incluent pas de crochets par défaut, il faut donc les entourer lorsque vous avez besoin de parenthèses, crochets ou accolades.

![Une matrice mathématique à deux lignes avec une cellule vide](powerpoint-math-equations_10.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 120)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    matrix = math.MathMatrix(2, 3)
    matrix[0, 0] = math.MathematicalText("1")
    matrix[0, 1] = math.MathematicalText("x")
    matrix[1, 0] = math.MathematicalText("x")
    matrix[1, 1] = math.MathematicalText("2")
    matrix[1, 2] = math.MathematicalText("y")

    math_paragraph.add(math.MathBlock(matrix))

    presentation.save("matrix.pptx", slides.export.SaveFormat.PPTX)
```

## **Ajouter des tableaux d’équations**

Utilisez [`to_math_array`](https://reference.aspose.com/slides/fr/python-net/aspose.slides.mathtext/imathelement/to_math_array/) lorsque vous avez besoin d’équations **alignées** ou d’une pile **verticale** d’expressions.

![Un tableau mathématique vertical avec x au-dessus de y](powerpoint-math-equations_11.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 140)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    equation_array = (
        math.MathematicalText("x")
        .join("y")
        .to_math_array()
    )

    math_paragraph.add(math.MathBlock(equation_array))

    presentation.save("equation-array.pptx", slides.export.SaveFormat.PPTX)
```

## **Ajouter des fonctions trigonométriques**

Utilisez [`as_argument_of_function`](https://reference.aspose.com/slides/fr/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/) lorsque l’argument est l’élément actuel et que le nom de la fonction est connu.

![La fonction trigonométrique cos appliquée à 2x](powerpoint-math-equations_6.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 100)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    cosine = math.MathematicalText("2x").as_argument_of_function(
        math.MathFunctionsOfOneArgument.COS
    )

    math_paragraph.add(math.MathBlock(cosine))

    presentation.save("trigonometric-function.pptx", slides.export.SaveFormat.PPTX)
```

## **Ajouter des indices et des exposants**

Utilisez les assistants d’indice et d’exposant pour les indices et les puissances. Lorsque les indices doivent apparaître du côté gauche de la base, utilisez [`set_sub_superscript_on_the_left`](https://reference.aspose.com/slides/fr/python-net/aspose.slides.mathtext/imathelement/set_sub_superscript_on_the_left/).

![Une lettre Y majuscule avec l’indice gauche 1 et l’exposant n](powerpoint-math-equations_9.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 100)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    scripts = math.MathematicalText("Y").set_sub_superscript_on_the_left("1", "n")

    math_paragraph.add(math.MathBlock(scripts))

    presentation.save("subscript-superscript.pptx", slides.export.SaveFormat.PPTX)
```

## **Ajouter des délimiteurs**

Utilisez [`enclose`](https://reference.aspose.com/slides/fr/python-net/aspose.slides.mathtext/imathelement/enclose/) pour placer une expression entre des délimiteurs. Vous pouvez également définir un caractère séparateur pour les expressions délimitées contenant plusieurs éléments.

![Une expression délimitée contenant x, y et z séparés par des barres verticales](powerpoint-math-equations_13.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 100)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    delimiter = (
        math.MathematicalText("x")
        .join("y")
        .join("z")
        .enclose("<", ">")
    )
    delimiter.separator_character = "|"

    math_paragraph.add(math.MathBlock(delimiter))

    presentation.save("delimiters.pptx", slides.export.SaveFormat.PPTX)
```

## **Ajouter une boîte encadrée**

Utilisez [`to_border_box`](https://reference.aspose.com/slides/fr/python-net/aspose.slides.mathtext/imathelement/to_border_box/) lorsque l’équation elle‑même doit être encadrée.

![Une équation encadrée montrant c² = a² + b²](powerpoint-math-equations_12.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 100)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    boxed_equation = (
        math.MathematicalText("a")
        .set_superscript("2")
        .join("=")
        .join(math.MathematicalText("b").set_superscript("2"))
        .join("+")
        .join(math.MathematicalText("c").set_superscript("2"))
        .to_border_box()
    )

    math_paragraph.add(math.MathBlock(boxed_equation))

    presentation.save("border-box.pptx", slides.export.SaveFormat.PPTX)
```

## **Regrouper des termes**

Utilisez [`group`](https://reference.aspose.com/slides/fr/python-net/aspose.slides.mathtext/imathelement/group/) pour placer un caractère de groupe au-dessus ou en dessous d’une expression. Ajoutez une limite pour libeller les termes regroupés.

![L’expression x + y regroupée avec le libellé texte quelconque en dessous](powerpoint-math-equations_15.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 120)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    grouped = (
        math.MathematicalText("x + y")
        .group(chr(0x23DF), math.MathTopBotPositions.BOTTOM, math.MathTopBotPositions.TOP)
        .set_lower_limit("any text")
    )

    math_paragraph.add(math.MathBlock(grouped))

    presentation.save("grouped-terms.pptx", slides.export.SaveFormat.PPTX)
```

## **Formater les éléments mathématiques**

Utilisez les assistants de formatage uniquement lorsqu’ils clarifient la formule. Par exemple, [`overbar`](https://reference.aspose.com/slides/fr/python-net/aspose.slides.mathtext/imathelement/overbar/) place une barre au-dessus d’un élément mathématique.

![Une expression mathématique ABC avec une barre supérieure](powerpoint-math-equations_14.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 100)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    overbar = math.MathematicalText("ABC").overbar()

    math_paragraph.add(math.MathBlock(overbar))

    presentation.save("overbar.pptx", slides.export.SaveFormat.PPTX)
```

## **Référence rapide**

| Tâche | API principale |
| --- | --- |
| Créer du texte mathématique | [MathematicalText](https://reference.aspose.com/slides/fr/python-net/aspose.slides.mathtext/mathematicaltext/) |
| Combiner des éléments | [IMathElement.join](https://reference.aspose.com/slides/fr/python-net/aspose.slides.mathtext/imathelement/join/) |
| Créer des fractions | [IMathElement.divide](https://reference.aspose.com/slides/fr/python-net/aspose.slides.mathtext/imathelement/divide/) |
| Ajouter un exposant ou un indice | [set_superscript](https://reference.aspose.com/slides/fr/python-net/aspose.slides.mathtext/imathelement/set_superscript/), [set_subscript](https://reference.aspose.com/slides/fr/python-net/aspose.slides.mathtext/imathelement/set_subscript/) |
| Ajouter des fonctions | [function](https://reference.aspose.com/slides/fr/python-net/aspose.slides.mathtext/imathelement/function/), [as_argument_of_function](https://reference.aspose.com/slides/fr/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/) |
| Ajouter des radicaux | [radical](https://reference.aspose.com/slides/fr/python-net/aspose.slides.mathtext/imathelement/radical/) |
| Ajouter des limites | [set_lower_limit](https://reference.aspose.com/slides/fr/python-net/aspose.slides.mathtext/imathelement/set_lower_limit/), [set_upper_limit](https://reference.aspose.com/slides/fr/python-net/aspose.slides.mathtext/imathelement/set_upper_limit/) |
| Ajouter des scripts côté gauche | [set_sub_superscript_on_the_left](https://reference.aspose.com/slides/fr/python-net/aspose.slides.mathtext/imathelement/set_sub_superscript_on_the_left/) |
| Ajouter des sommes et des intégrales | [nary](https://reference.aspose.com/slides/fr/python-net/aspose.slides.mathtext/imathelement/nary/), [integral](https://reference.aspose.com/slides/fr/python-net/aspose.slides.mathtext/imathelement/integral/) |
| Ajouter des matrices | [MathMatrix](https://reference.aspose.com/slides/fr/python-net/aspose.slides.mathtext/mathmatrix/) |
| Ajouter des tableaux d’équations | [to_math_array](https://reference.aspose.com/slides/fr/python-net/aspose.slides.mathtext/imathelement/to_math_array/) |
| Ajouter des délimiteurs | [enclose](https://reference.aspose.com/slides/fr/python-net/aspose.slides.mathtext/imathelement/enclose/) |
| Ajouter des barres et des bordures | [overbar](https://reference.aspose.com/slides/fr/python-net/aspose.slides.mathtext/imathelement/overbar/), [to_border_box](https://reference.aspose.com/slides/fr/python-net/aspose.slides.mathtext/imathelement/to_border_box/) |
| Regrouper des termes | [group](https://reference.aspose.com/slides/fr/python-net/aspose.slides.mathtext/imathelement/group/) |

## **FAQ**

**Puis‑je modifier une équation PowerPoint existante ?**

Oui. Ouvrez la présentation, trouvez la forme qui contient un `MathPortion`, récupérez son `MathParagraph`, puis mettez à jour les blocs mathématiques dans ce paragraphe.

**Les équations sont‑elles enregistrées comme du mathématique PowerPoint éditable ?**

Oui. Lors de l’enregistrement en PPTX, Aspose.Slides écrit l’équation comme du contenu mathématique Office éditable.

**Puis‑je exporter les équations vers LaTeX ?**

Aspose.Slides exporte les équations mathématiques vers MathML. Si vous avez besoin de LaTeX, exportez d’abord vers MathML puis convertissez le MathML avec un outil qui prend en charge le dialecte LaTeX cible.