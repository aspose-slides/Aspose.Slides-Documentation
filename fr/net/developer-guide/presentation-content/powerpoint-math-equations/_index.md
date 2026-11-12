---
title: Ajouter des équations mathématiques aux présentations PowerPoint en .NET
linktitle: Équations Mathématiques PowerPoint
type: docs
weight: 80
url: /fr/net/powerpoint-math-equations/
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
- .NET
- C#
- Aspose.Slides
description: "Insérer et modifier des équations mathématiques dans PowerPoint PPT et PPTX avec Aspose.Slides pour .NET, prenant en charge OMML, les contrôles de mise en forme et des exemples de code C# clairs."
---
## **Aperçu**

PowerPoint stocke les équations au format Office Math Markup Language (OMML). Avec Aspose.Slides pour .NET, vous pouvez créer le même type de contenu mathématique de manière programmatique : fractions, radicaux, fonctions, limites, opérateurs N‑aires, matrices, tableaux et blocs mathématiques formatés.

Dans PowerPoint, les utilisateurs ajoutent généralement des équations via **Insertion > Équation** :

![Onglet Insertion de PowerPoint avec la commande Équation sélectionnée](powerpoint-math-equations_1.png)

Le résultat est du texte mathématique éditable sur la diapositive :

![Une diapositive PowerPoint contenant une équation mathématique éditable](powerpoint-math-equations_2.png)

Aspose.Slides crée ce texte mathématique à l'aide de trois objets principaux :

- Une forme mathématique, créée avec [AddMathShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addmathshape/), est la forme qui contient l'équation.
- [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/) stocke le contenu mathématique à l'intérieur du cadre de texte de la forme.
- [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathparagraph/) contient un ou plusieurs objets [MathBlock](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathblock/).

La plupart des exemples ci‑dessous utilisent [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/) et les méthodes fluides de [IMathElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/) pour garder le code court et lisible.

Pour les scénarios d'exportation MathML, consultez [Exporter des équations mathématiques depuis des présentations en .NET](/slides/fr/net/exporting-math-equations/).

## **Créer une équation**

Cet exemple utilise [AddMathShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addmathshape/) pour créer une forme mathématique et ajoute le théorème de Pythagore :

![L'équation c carré égal a carré plus b carré](powerpoint-math-equations_3.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 120);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var equation = new MathematicalText("c")
    .SetSuperscript("2")
    .Join("=")
    .Join(new MathematicalText("a").SetSuperscript("2"))
    .Join("+")
    .Join(new MathematicalText("b").SetSuperscript("2"));

mathParagraph.Add(equation);

presentation.Save("pythagorean-theorem.pptx", SaveFormat.Pptx);
```

{{% alert color="info" title="Note" %}}
[AddMathShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addmathshape/) crée une forme qui contient déjà un paragraphe mathématique. Accédez au premier [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/), obtenez son [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/mathparagraph/), et ajoutez des blocs mathématiques ou des éléments mathématiques.
{{% /alert %}}

## **Ajouter des fractions**

Utilisez [Divide](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/divide/) pour créer une fraction. Vous pouvez choisir un style de fraction avec [MathFractionTypes](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfractiontypes/).

![Une fraction mathématique inclinée montrant 1 divisé par x](powerpoint-math-equations_4.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 100);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var fraction = new MathematicalText("1")
    .Divide("x", MathFractionTypes.Skewed);

mathParagraph.Add(new MathBlock(fraction));

presentation.Save("fraction.pptx", SaveFormat.Pptx);
```

Pour une fraction empilée, utilisez [MathFractionTypes.Bar](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfractiontypes/) :

```csharp
using Aspose.Slides.MathText;

var stackedFraction = new MathematicalText("x + 1").Divide("y - 1", MathFractionTypes.Bar);
```

## **Ajouter des radicaux**

Utilisez [Radical](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/radical/) pour créer une racine carrée, une racine cubique ou toute autre racine. L'élément actuel devient la base, et l'argument devient le degré.

![Une expression radicande de n‑ième racine avec x sous le symbole radical](powerpoint-math-equations_5.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 100);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var radical = new MathematicalText("x")
    .Radical("n");

mathParagraph.Add(new MathBlock(radical));

presentation.Save("radical.pptx", SaveFormat.Pptx);
```

## **Ajouter des fonctions et des limites**

Utilisez [AsArgumentOfFunction](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/asargumentoffunction/) ou [Function](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/function/) pour des fonctions telles que `sin(x)`, `log(x)`, ou des noms de fonctions personnalisés. Pour les limites, placez `lim` dans un [MathLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathlimit/) ou utilisez [SetLowerLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setlowerlimit/).

![La limite de x lorsque x tend vers l'infini](powerpoint-math-equations_8.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 100);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var limit = new MathematicalText("lim")
    .SetLowerLimit("x→∞")
    .Function("x");

mathParagraph.Add(new MathBlock(limit));

presentation.Save("functions-and-limits.pptx", SaveFormat.Pptx);
```

Pour un nom de fonction personnalisé, faites du nom de fonction l'élément actuel et appelez [Function](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/function/) avec son argument :

```csharp
using Aspose.Slides.MathText;

var customFunction = new MathematicalText("f").Function("x + 1");
```

## **Ajouter des opérateurs N‑aires et des intégrales**

Utilisez [Nary](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/nary/) pour les sommes, les unions, les intersections et d'autres grands opérateurs. Utilisez [Integral](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/integral/) pour les intégrales. Les deux méthodes vous permettent de définir les limites inférieure et supérieure.

![Une sommation avec limites inférieure et supérieure](powerpoint-math-equations_7.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 120);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var summationBase = new MathematicalText("x")
    .SetSuperscript("k")
    .Join(new MathematicalText("a").SetSuperscript("n-k"));

var summation = summationBase.Nary(MathNaryOperatorTypes.Summation, "k=0", "n");

mathParagraph.Add(new MathBlock(summation));

presentation.Save("nary-operators.pptx", SaveFormat.Pptx);
```

Les opérateurs N‑aires sont destinés aux grands opérateurs avec limites optionnelles. Les opérateurs simples tels que `+`, `-` et `=` sont généralement ajoutés comme [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/) et joints à l'expression.

Pour une intégrale, utilisez [Integral](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/integral/) :

```csharp
using Aspose.Slides.MathText;

var integralBase = new MathematicalText("x").Join(new MathematicalText("dx").ToBox());
var integral = integralBase.Integral(MathIntegralTypes.Simple, "0", "1");
```

## **Ajouter des matrices**

Utilisez [MathMatrix](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathmatrix/) pour les lignes et les colonnes. Les matrices n'incluent pas de crochets par défaut, il faut donc encadrer la matrice lorsque vous avez besoin de parenthèses, de crochets ou d'accolades.

![Une matrice mathématique à deux lignes avec une cellule vide](powerpoint-math-equations_10.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 120);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var matrix = new MathMatrix(2, 3);
matrix[0, 0] = new MathematicalText("1");
matrix[0, 1] = new MathematicalText("x");
matrix[1, 0] = new MathematicalText("x");
matrix[1, 1] = new MathematicalText("2");
matrix[1, 2] = new MathematicalText("y");

mathParagraph.Add(new MathBlock(matrix));

presentation.Save("matrix.pptx", SaveFormat.Pptx);
```

## **Ajouter des tableaux d'équations**

Utilisez [ToMathArray](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/tomatharray/) lorsque vous avez besoin d'équations alignées ou d'une pile verticale d'expressions.

![Un tableau mathématique vertical avec x au-dessus de y](powerpoint-math-equations_11.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 140);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var equationArray = new MathematicalText("x")
    .Join("y")
    .ToMathArray();

mathParagraph.Add(new MathBlock(equationArray));

presentation.Save("equation-array.pptx", SaveFormat.Pptx);
```

## **Ajouter des fonctions trigonométriques**

Utilisez [AsArgumentOfFunction](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/asargumentoffunction/) lorsque l'argument est l'élément actuel et que le nom de la fonction est connu.

![La fonction trigonométrique cos appliquée à 2x](powerpoint-math-equations_6.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 100);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var cosine = new MathematicalText("2x")
    .AsArgumentOfFunction(MathFunctionsOfOneArgument.Cos);

mathParagraph.Add(new MathBlock(cosine));

presentation.Save("trigonometric-function.pptx", SaveFormat.Pptx);
```

## **Ajouter des indices et des exposants**

Utilisez les aides d'indice et d'exposant pour les index et les puissances. Lorsque les index doivent apparaître du côté gauche de la base, utilisez [SetSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsubsuperscriptontheleft/) .

![Un Y majuscule avec indice 1 à gauche et exposant n](powerpoint-math-equations_9.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 100);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var scripts = new MathematicalText("Y")
    .SetSubSuperscriptOnTheLeft("1", "n");

mathParagraph.Add(new MathBlock(scripts));

presentation.Save("subscript-superscript.pptx", SaveFormat.Pptx);
```

## **Ajouter des délimiteurs**

Utilisez [Enclose](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/enclose/) pour placer une expression à l'intérieur de délimiteurs. Vous pouvez également définir un caractère séparateur pour les expressions délimitées contenant plusieurs éléments.

![Une expression délimitée contenant x, y et z séparés par des barres verticales](powerpoint-math-equations_13.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 100);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var delimiter = new MathematicalText("x")
    .Join("y")
    .Join("z")
    .Enclose('<', '>');
delimiter.SeparatorCharacter = '|';

mathParagraph.Add(new MathBlock(delimiter));

presentation.Save("delimiters.pptx", SaveFormat.Pptx);
```

### **Taille et alignement des délimiteurs**

Définissez [GrowToMatchOperandHeight](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathdelimiter/growtomatchoperandheight/) à `true` pour laisser les parenthèses s'agrandir autour d'un opérande haut, ou à `false` pour les garder à leur taille normale. [DelimiterShape](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathdelimiter/delimitershape/) accepte l'une des deux valeurs [MathDelimiterShape](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathdelimitershape/). `Centered` centre les parenthèses sur l'axe mathématique, qui passe par le milieu du signe égal. `Match` les aligne avec le contenu encadré. Les deux réglages n'affectent que les délimiteurs. L'expression à l'intérieur reste la même.

La démonstration place une fraction dans l'exposant de `x` de sorte que l'expression s'étende davantage au-dessus de la ligne de base qu'en dessous. Les quatre équations utilisent les mêmes parenthèses et paramètres de police.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

void AddExpression(float left, float top, bool grow, MathDelimiterShape shape)
{
    var fraction = new MathematicalText("a + b").Divide("c + d");
    var power = new MathematicalText("x").SetSuperscript(fraction);
    var delimiter = power.Enclose('(', ')');
    delimiter.GrowToMatchOperandHeight = grow;
    delimiter.DelimiterShape = shape;

    var mathShape = slide.Shapes.AddMathShape(left, top, 300, 100);
    var portion = (MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0];
    portion.PortionFormat.FontHeight = 32;
    var equation = new MathematicalText("y = ").Join(delimiter);
    portion.MathParagraph.Add(equation);
}

AddExpression(20, 20, true, MathDelimiterShape.Centered);
AddExpression(350, 20, true, MathDelimiterShape.Match);
AddExpression(20, 140, false, MathDelimiterShape.Centered);
AddExpression(350, 140, false, MathDelimiterShape.Match);

presentation.Save("delimiter-sizing.pptx", SaveFormat.Pptx);
```

Dans PowerPoint, comparez les lignes pour voir l'effet de l'agrandissement. Dans la ligne supérieure, les parenthèses s'agrandissent pour entourer l'exposant et sont identiques pour les deux formes. Dans la ligne inférieure, l'agrandissement est désactivé. Les parenthèses plus petites à gauche (`Centered`) s'alignent avec le signe égal, tandis que celles à droite (`Match`) se placent plus haut autour de l'expression.

![Quatre équations dans PowerPoint avec l'agrandissement des délimiteurs activé en haut et désactivé en bas, et Centered à gauche et Match à droite](delimiter-sizing.png)

## **Ajouter une boîte bordée**

Utilisez [ToBorderBox](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/toborderbox/) lorsque l'équation elle‑même doit être encadrée.

![Une équation encadrée montrant a au carré égal b au carré plus c au carré](powerpoint-math-equations_12.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 100);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var boxedEquation = new MathematicalText("a")
    .SetSuperscript("2")
    .Join("=")
    .Join(new MathematicalText("b").SetSuperscript("2"))
    .Join("+")
    .Join(new MathematicalText("c").SetSuperscript("2"))
    .ToBorderBox();

mathParagraph.Add(new MathBlock(boxedEquation));

presentation.Save("border-box.pptx", SaveFormat.Pptx);
```

## **Grouper les termes**

Utilisez [Group](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/group/) pour placer un caractère de groupement au-dessus ou au-dessous d'une expression. Ajoutez une limite pour étiqueter les termes groupés.

![L'expression x + y groupée avec le libellé n'importe quel texte en dessous](powerpoint-math-equations_15.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 120);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var grouped = new MathematicalText("x + y")
    .Group('\u23DF', MathTopBotPositions.Bottom, MathTopBotPositions.Top)
    .SetLowerLimit("any text");

mathParagraph.Add(new MathBlock(grouped));

presentation.Save("grouped-terms.pptx", SaveFormat.Pptx);
```

## **Formater les éléments mathématiques**

Utilisez les aides de formatage uniquement lorsqu'elles clarifient la formule. Par exemple, [Overbar](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/overbar/) place une barre au-dessus d'un élément mathématique.

![Une expression mathématique ABC avec une barre au-dessus](powerpoint-math-equations_14.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 100);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var overbar = new MathematicalText("ABC").Overbar();

mathParagraph.Add(new MathBlock(overbar));

presentation.Save("overbar.pptx", SaveFormat.Pptx);
```

### **Formater le texte dans une équation existante**

Pour formater le texte dans l'ensemble d'une équation existante, parcourez l'arbre d'éléments de chaque bloc mathématique. [IMathElement.GetChildren](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/getchildren/) renvoie uniquement les enfants immédiats, il faut donc l'appeler récursivement pour atteindre le texte à l'intérieur des fractions, scripts, radicaux et autres structures imbriquées. Vérifiez l'élément actuel ainsi que ses enfants afin d'inclure l'élément de départ lorsqu'il s'agit de [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/).

Cet exemple suppose qu'une présentation contient une équation telle que `z = xᵢ / ∛y`, avec une fraction contenant un indice dans son numérateur et un radical dans son dénominateur. Ne traiter que les éléments de niveau supérieur du bloc manquerait le texte à l'intérieur de la fraction. L'exemple trouve les portions mathématiques dans les cadres de texte des diapositives, accède à leurs blocs via [IMathPortion.MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathportion/mathparagraph/), et définit [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) à 28 points pour chaque élément de texte grâce à la propriété [Format](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/format/) .

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation("input.pptx");

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape is not IAutoShape autoShape || autoShape.TextFrame == null)
            continue;

        foreach (var paragraph in autoShape.TextFrame.Paragraphs)
        {
            foreach (var portion in paragraph.Portions)
            {
                if (portion is IMathPortion mathPortion)
                {
                    foreach (var block in mathPortion.MathParagraph)
                        FormatMathText(block);
                }
            }
        }
    }
}

presentation.Save("formatted-equations.pptx", SaveFormat.Pptx);

void FormatMathText(IMathElement element)
{
    if (element is MathematicalText text)
        text.Format.FontHeight = 28;

    foreach (var child in element.GetChildren())
        FormatMathText(child);
}
```

La présentation enregistrée contient le formatage de texte mis à jour à chaque niveau de chaque équation traitée, tout en préservant son contenu textuel et sa structure mathématique.

## **Référence rapide**

| Tâche | API principale |
| --- | --- |
| Créer du texte mathématique | [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/) |
| Combiner des éléments | [IMathElement.Join](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/join/) |
| Créer des fractions | [IMathElement.Divide](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/divide/) |
| Ajouter un exposant ou un indice | [SetSuperscript](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsuperscript/), [SetSubscript](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsubscript/) |
| Ajouter des fonctions | [Function](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/function/), [AsArgumentOfFunction](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/asargumentoffunction/) |
| Ajouter des radicaux | [IMathElement.Radical](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/radical/) |
| Ajouter des limites | [SetLowerLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setlowerlimit/), [SetUpperLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setupperlimit/) |
| Ajouter des scripts côté gauche | [SetSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsubsuperscriptontheleft/) |
| Ajouter des sommes et des intégrales | [Nary](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/nary/), [Integral](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/integral/) |
| Ajouter des matrices | [MathMatrix](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathmatrix/) |
| Ajouter des tableaux d'équations | [ToMathArray](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/tomatharray/) |
| Ajouter des délimiteurs | [Enclose](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/enclose/) |
| Ajouter des barres et des bordures | [Overbar](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/overbar/), [ToBorderBox](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/toborderbox/) |
| Grouper les termes | [Group](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/group/) |

## **FAQ**

**Puis-je modifier une équation PowerPoint existante ?**

Oui. Ouvrez la présentation, trouvez la forme qui contient une [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/), obtenez son [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/mathparagraph/), et mettez à jour les blocs mathématiques dans ce paragraphe.

**Les équations sont‑elles enregistrées comme du math PowerPoint éditable ?**

Oui. Lors de l'enregistrement au format PPTX, Aspose.Slides écrit l'équation comme du contenu Office mathématique éditable.

**Puis‑je exporter des équations vers LaTeX ?**

Oui. Obtenez le [IMathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathparagraph/) de l'équation à partir de sa [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/), puis appelez [IMathParagraph.ToLatex](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathparagraph/tolatex/) pour l'exporter directement. Pour un exemple complet, consultez [Exporter des équations mathématiques depuis des présentations en .NET](/slides/fr/net/exporting-math-equations/#export-math-equations-to-latex).