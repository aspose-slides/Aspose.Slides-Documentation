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
- ajouter une équation mathématique
- ajouter un symbole mathématique
- ajouter une formule mathématique
- ajouter du texte mathématique
- PowerPoint
- présentation
- .NET
- C#
- Aspose.Slides
description: "Insérer et modifier des équations mathématiques dans PowerPoint PPT et PPTX avec Aspose.Slides pour .NET, prenant en charge OMML, les contrôles de formatage et des exemples de code C# clairs."
---
## **Vue d'ensemble**

PowerPoint stocke les équations au format Office Math Markup Language (OMML). Avec Aspose.Slides pour .NET, vous pouvez créer le même type de contenu mathématique de façon programmatique : fractions, radicaux, fonctions, limites, opérateurs N‑aires, matrices, tableaux et blocs mathématiques formatés.

Dans PowerPoint, les utilisateurs ajoutent généralement des équations depuis **Insert > Equation**:

![Onglet Insertion de PowerPoint avec la commande Equation sélectionnée](powerpoint-math-equations_1.png)

Le résultat est du texte mathématique modifiable sur la diapositive:

![Diapositive PowerPoint contenant une équation mathématique modifiable](powerpoint-math-equations_2.png)

Aspose.Slides construit ce texte mathématique à l'aide de trois objets principaux :

- Une forme mathématique, créée avec [AddMathShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addmathshape/), est la forme qui contient l'équation.
- [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/) stocke le contenu mathématique à l'intérieur du cadre de texte de la forme.
- [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathparagraph/) contient un ou plusieurs objets [MathBlock](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathblock/).

La plupart des exemples ci‑dessus utilisent [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/) et les méthodes fluides de [IMathElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/) pour garder le code court et lisible.

Pour les scénarios d'exportation MathML, voir [Exporter les équations mathématiques depuis des présentations en .NET](/slides/fr/net/exporting-math-equations/).

## **Créer une équation**

Cet exemple utilise [AddMathShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addmathshape/) pour créer une forme mathématique et ajoute le théorème de Pythagore :

![L'équation c carré = a carré + b carré](powerpoint-math-equations_3.png)

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
[AddMathShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addmathshape/) crée une forme qui contient déjà un paragraphe mathématique. Accédez au premier [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/), récupérez son [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/mathparagraph/), et ajoutez des blocs mathématiques ou des éléments mathématiques.
{{% /alert %}}

## **Ajouter des fractions**

Utilisez [Divide](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/divide/) pour créer une fraction. Vous pouvez choisir un style de fraction avec [MathFractionTypes](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfractiontypes/).

![Une fraction mathématique inclinée affichant 1 divisé par x](powerpoint-math-equations_4.png)

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

Pour une fraction empilée, utilisez [MathFractionTypes.Bar](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfractiontypes/):

```csharp
using Aspose.Slides.MathText;

var stackedFraction = new MathematicalText("x + 1").Divide("y - 1", MathFractionTypes.Bar);
```

## **Ajouter des radicaux**

Utilisez [Radical](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/radical/) pour créer une racine carrée, une racine cubique ou toute autre racine. L'élément actuel devient la base, et l'argument devient le degré.

![Une expression radicielle de n‑ième racine avec x sous le signe radical](powerpoint-math-equations_5.png)

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

### **Afficher ou masquer le degré d’une racine carrée**

Une racine carrée peut afficher explicitement le 2 ou utiliser la notation conventionnelle √x. La propriété [HideDegree](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathradical/hidedegree/) de [IMathRadical](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathradical/) contrôle la forme affichée. Les deux formes conservent le degré 2 et le radicand x dans l'équation modifiable.

![La même racine carrée avec HideDegree réglé sur false à gauche et true à droite](square-root-degree.png)

L'exemple enregistre la même racine carrée deux fois. Dans `visible-degree.pptx` le 2 est visible. Dans `hidden-degree.pptx` il est masqué.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var radical = new MathematicalText("x").Radical("2");

var shape = slide.Shapes.AddMathShape(20, 20, 200, 100);
var portion = (IMathPortion)shape.TextFrame.Paragraphs[0].Portions[0];
portion.MathParagraph.Add(new MathBlock(radical));

radical.HideDegree = false;
presentation.Save("visible-degree.pptx", SaveFormat.Pptx);

radical.HideDegree = true;
presentation.Save("hidden-degree.pptx", SaveFormat.Pptx);
```

## **Ajouter des fonctions et limites**

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

Utilisez [Nary](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/nary/) pour les sommes, les unions, les intersections et autres grands opérateurs. Utilisez [Integral](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/integral/) pour les intégrales. Les deux méthodes permettent de définir les limites inférieure et supérieure.

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

Les opérateurs N‑aires sont destinés aux grands opérateurs avec limites optionnelles. Les opérateurs simples tels que `+`, `-` et `=` sont généralement ajoutés en tant que [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/) et intégrés dans l'expression.

Pour une intégrale, utilisez [Integral](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/integral/):

```csharp
using Aspose.Slides.MathText;

var integralBase = new MathematicalText("x").Join(new MathematicalText("dx").ToBox());
var integral = integralBase.Integral(MathIntegralTypes.Simple, "0", "1");
```

## **Ajouter des matrices**

Utilisez [MathMatrix](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathmatrix/) pour les lignes et les colonnes. Les matrices n'incluent pas de crochets par défaut, donc encadrez la matrice lorsque vous avez besoin de parenthèses, crochets ou accolades.

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

## **Ajouter des tableaux d’équations**

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

### **Aligner un tableau avec les éléments environnants**

[IMathArray.BaseJustification](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imatharray/basejustification/) contrôle l'alignement vertical d'un tableau par rapport aux éléments mathématiques qui l'entourent. L'exemple ci‑dessous compare l'alignement avec la première ligne, le centre du tableau et la dernière ligne.

L'exemple suivant crée trois tableaux identiques, chacun avec trois lignes et les éléments voisins `A=` et `=B`. Tout le texte mathématique utilise Cambria Math en 24 points. Seul l'alignement du tableau change.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(780, 200, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

var alignments = new[] { MathVerticalAlignment.Top, MathVerticalAlignment.Center, MathVerticalAlignment.Bottom };

for (int i = 0; i < alignments.Length; i++)
{
    var label = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20 + i * 260, 10, 240, 30);
    label.FillFormat.FillType = FillType.NoFill;
    label.LineFormat.FillFormat.FillType = FillType.NoFill;
    label.TextFrame.Text = alignments[i].ToString();
    var labelFormat = label.TextFrame.Paragraphs[0].Portions[0].PortionFormat;
    labelFormat.FontHeight = 16;
    labelFormat.FillFormat.FillType = FillType.Solid;
    labelFormat.FillFormat.SolidFillColor.Color = System.Drawing.Color.Black;

    var mathShape = slide.Shapes.AddMathShape(20 + i * 260, 60, 240, 130);
    mathShape.TextFrame.TextFrameFormat.AnchoringType = TextAnchorType.Top;
    var mathParagraph = ((IMathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;
    mathParagraph.Justification = MathJustification.LeftJustified;

    var rows = new IMathElement[] { CreateText("x+y=3"), CreateText("x-y=1"), CreateText("x=2") };
    var equationArray = new MathArray(rows);
    equationArray.BaseJustification = alignments[i];
    var equation = new MathBlock(CreateText("A=")).Join(equationArray).Join(CreateText("=B"));
    mathParagraph.Add(equation);
}

presentation.Save("equation-array-alignment.pptx", SaveFormat.Pptx);

MathematicalText CreateText(string value)
{
    var text = new MathematicalText(value);
    text.Format.FontHeight = 24;
    text.Format.LatinFont = new FontData("Cambria Math");
    return text;
}
```

La comparaison suivante montre la présentation enregistrée dans PowerPoint. Notez la position de `A=` et `=B` à côté de chaque tableau.

![Tableaux d'équations dans PowerPoint avec alignement Haut, Centre et Bas et éléments voisins identiques](equation-array-alignment.png)

### **Configurer l’espacement des lignes**

[RowSpacingRule](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imatharray/rowspacingrule/) sélectionne la règle d'espacement pour les lignes du tableau. [RowSpacing](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imatharray/rowspacing/) fournit une valeur numérique pour une règle d'espacement explicite et est ignorée par les règles prédéfinies.

Pour un espacement précis, la valeur est mesurée en points. Pour un espacement proportionnel, elle est mesurée en demi‑lignes : la valeur `3` dans l'exemple correspond à 1,5 ligne. Définissez les deux propriétés lorsque vous spécifiez une valeur explicite ; changer uniquement la valeur numérique ne sélectionne pas de règle d'espacement.

L'exemple ci‑dessous enregistre cinq présentations avec les mêmes équations, alignement et paramètres de police. Les trois premières utilisent des préréglages ; les deux dernières montrent des valeurs explicites.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

var settings = new (MathRowSpacingRule Rule, uint Spacing)[]
{
    (MathRowSpacingRule.SingleLineGap, 0),
    (MathRowSpacingRule.OneAndAHalfLineGap, 0),
    (MathRowSpacingRule.TwoLineGap, 0),
    (MathRowSpacingRule.Exactly, 20),
    (MathRowSpacingRule.Multiple, 3)
};

foreach (var setting in settings)
{
    var fileName = $"equation-array-{setting.Rule}.pptx";
    using (var presentation = new Presentation())
    {
        var mathShape = presentation.Slides[0].Shapes.AddMathShape(20, 20, 600, 300);
        var paragraph = mathShape.TextFrame.Paragraphs[0];
        paragraph.ParagraphFormat.SpaceBefore = 0;
        paragraph.ParagraphFormat.SpaceAfter = 0;
        var mathParagraph = ((IMathPortion)paragraph.Portions[0]).MathParagraph;
        mathParagraph.Justification = MathJustification.LeftJustified;

        var rows = new IMathElement[] { CreateText("x+y=3"), CreateText("x-y=1"), CreateText("x=2") };
        var equationArray = new MathArray(rows);
        equationArray.BaseJustification = MathVerticalAlignment.Center;
        equationArray.RowSpacingRule = setting.Rule;
        equationArray.RowSpacing = setting.Spacing;
        var equation = new MathBlock(CreateText("A=")).Join(equationArray).Join(CreateText("=B"));
        mathParagraph.Add(equation);

        presentation.Save(fileName, SaveFormat.Pptx);
    }

}

MathematicalText CreateText(string value)
{
    var text = new MathematicalText(value);
    text.Format.FontHeight = 24;
    text.Format.LatinFont = new FontData("Cambria Math");
    return text;
}
```

L'espacement des lignes du tableau est distinct de l'espacement des paragraphes. [SpaceBefore](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spacebefore/) et [SpaceAfter](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spaceafter/) ajoutent de l'espace autour du paragraphe contenant, pas entre les lignes du tableau. De même, [IMathParagraph.Justification](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathparagraph/justification/) positionne le paragraphe mathématique complet horizontalement ; il ne remplace pas le réglage d'alignement vertical du tableau.

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

## **Ajouter des indices et exposants**

Utilisez les assistants d’indice et d’exposant pour les index et les puissances. Lorsque les index doivent apparaître du côté gauche de la base, utilisez [SetSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsubsuperscriptontheleft/).

![Un Y majuscule avec l’indice gauche 1 et l’exposant n](powerpoint-math-equations_9.png)

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

Utilisez [Enclose](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/enclose/) pour placer une expression entre délimiteurs. Vous pouvez également définir un caractère séparateur pour les expressions délimitées contenant plusieurs éléments.

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

Réglez [GrowToMatchOperandHeight](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathdelimiter/growtomatchoperandheight/) à `true` pour laisser les parenthèses s'agrandir autour d'un opérande haut, ou à `false` pour les garder à leur taille normale. [DelimiterShape](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathdelimiter/delimitershape/) accepte l'une des deux valeurs [MathDelimiterShape](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathdelimitershape/). `Centered` centre les parenthèses sur l'axe mathématique, qui passe par le centre du signe égal. `Match` les aligne avec le contenu encadré. Ces deux réglages n'affectent que les délimiteurs. L'expression à l'intérieur reste identique.

L'exemple place une fraction dans l'exposant de `x` de sorte que l'expression s'étende plus loin au‑dessus de la ligne de base qu'en dessous. Les quatre équations utilisent les mêmes parenthèses et paramètres de police.

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

Dans PowerPoint, comparez les lignes pour voir l'effet de la croissance. Dans la ligne supérieure, les parenthèses s'agrandissent pour entourer l'exposant et sont identiques pour les deux formes. Dans la ligne inférieure, la croissance est désactivée. Les petites parenthèses à gauche (`Centered`) s'alignent avec le signe égal, tandis que celles à droite (`Match`) sont plus hautes autour de l'expression.

![Quatre équations dans PowerPoint avec la croissance des délimiteurs activée en haut et désactivée en bas, et Centered à gauche et Match à droite](delimiter-sizing.png)

## **Ajouter une boîte à bordure**

Appelez [ToBorderBox](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/toborderbox/) sur une fraction pour encadrer l'expression entière. Le [IMathBorderBox](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/) retourné affiche les quatre côtés par défaut. Utilisez [HideTop](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/hidetop/), [HideBottom](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/hidebottom/), [HideLeft](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/hideleft/), et [HideRight](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/hideright/) pour supprimer des côtés individuels.

L'exemple place six copies de la même fraction sur une diapositive. Pour montrer l'annulation, masquez les quatre côtés et définissez [StrikethroughBottomLeftToTopRight](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/strikethroughbottomlefttotopright/) pour une diagonale ascendante (↗) ou [StrikethroughTopLeftToBottomRight](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/strikethroughtoplefttobottomright/) pour une diagonale descendante (↘). Vous pouvez également utiliser [StrikethroughHorizontal](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/strikethroughhorizontal/) ou [StrikethroughVertical](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/strikethroughvertical/) avec n'importe quelle combinaison de côtés visibles.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(540, 220, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

IMathBorderBox AddFraction(float x, float y, bool hideBorder = false)
{
    var fraction = new MathematicalText("x+1").Divide("y+2");
    var box = fraction.ToBorderBox();
    box.HideTop = box.HideBottom = box.HideLeft = box.HideRight = hideBorder;

    var shape = slide.Shapes.AddMathShape(x, y, 160, 90);
    var portion = (MathPortion)shape.TextFrame.Paragraphs[0].Portions[0];
    portion.PortionFormat.FontHeight = 28;
    portion.MathParagraph.Add(new MathBlock(box));
    return box;
}

AddFraction(10, 10);

var partial = AddFraction(190, 10);
partial.HideTop = true;
partial.HideRight = true;

AddFraction(370, 10, hideBorder: true).StrikethroughBottomLeftToTopRight = true;
AddFraction(10, 120, hideBorder: true).StrikethroughTopLeftToBottomRight = true;
AddFraction(190, 120, hideBorder: true).StrikethroughHorizontal = true;
AddFraction(370, 120).StrikethroughVertical = true;

presentation.Save("border-box.pptx", SaveFormat.Pptx);
```

![Six fractions modifiables dans PowerPoint. Ligne supérieure : bordure complète, côtés inférieur et gauche, diagonale ascendante. Ligne inférieure : diagonale descendante, rayure horizontale, rayure verticale avec une bordure complète.](border-box-fractions.png)

Sur cette fraction, la rayure horizontale chevauche la barre de fraction. La rayure verticale traverse à la fois le numérateur et le dénominateur tandis que la bordure environnante reste visible. Ces lignes décorent l'ensemble de l'expression. Le texte barré ordinaire s'applique aux caractères d'une portion de texte. Après avoir rouvert la présentation dans PowerPoint, vous pouvez toujours modifier le numérateur et le dénominateur séparément.

## **Contrôler la visibilité et la mise en page avec les éléments fantômes**

Enveloppez une expression dans [MathPhantom](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathphantom/) pour contrôler séparément sa visibilité et l'espace qu'elle apporte à une équation. Les propriétés de [IMathPhantom](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/) contrôlent ce qui suit :

| Propriété | Effet |
| --- | --- |
| [Show](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/show/) | Définir à `false` pour masquer l'expression. Ses dimensions contribuent toujours à la mise en page sauf si les propriétés correspondantes ci‑dessous sont `true`. |
| [ZeroWidth](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/zerowidth/) | Traiter la largeur horizontale de l'expression comme zéro, permettant aux éléments voisins de se rapprocher. |
| [ZeroAsc](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/zeroasc/) | Traiter son ascendant, la hauteur au‑dessus de la ligne de base, comme zéro. Cela peut réduire l'espace réservé au‑dessus des éléments voisins. |
| [ZeroDesc](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/zerodesc/) | Traiter sa descente, la profondeur sous la ligne de base, comme zéro. Cela peut rapprocher une barre de fraction ou un autre contenu sous l'expression de ses voisins. |

La ligne de base est la ligne de référence sur laquelle reposent les caractères mathématiques ordinaires. Masquer le contenu ne supprime pas ses dimensions, et traiter une dimension comme zéro ne supprime pas l'expression. L'expression sous‑jacente reste accessible via [Base](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/base/). Réglez [Show](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/show/) à `true` pour l'afficher à nouveau ; les paramètres de dimension restent inchangés.

L'exemple ci‑dessous crée cinq variantes côte à côte : une fraction visible, une fraction masquée qui réserve de l'espace, et trois fractions masquées avec une dimension traitée comme zéro. Chaque variante utilise la même expression environnante et Cambria Math en 24 points. Toutes les formes d'équation ont la même position supérieure, indiquée par le guide gris. Placer le fantôme dans le numérateur d'une fraction extérieure rend les changements de mise en page verticale plus visibles.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(1000, 180, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

var labels = new[] { "Visible", "Hidden: reserves space", "Hidden: ZeroWidth", "Hidden: ZeroAsc", "Hidden: ZeroDesc" };

var guide = slide.Shapes.AddAutoShape(ShapeType.Line, 10, 60, 980, 0);
guide.LineFormat.FillFormat.FillType = FillType.Solid;
guide.LineFormat.FillFormat.SolidFillColor.Color = System.Drawing.Color.LightGray;

for (var i = 0; i < labels.Length; i++)
{
    var left = 10 + i * 200;
    
    var label = slide.Shapes.AddAutoShape(ShapeType.Rectangle, left, 10, 190, 30);
    label.FillFormat.FillType = FillType.NoFill;
    label.LineFormat.FillFormat.FillType = FillType.NoFill;
    label.TextFrame.Text = labels[i];

    var labelFormat = label.TextFrame.Paragraphs[0].Portions[0].PortionFormat;
    labelFormat.FontHeight = 14;
    labelFormat.FillFormat.FillType = FillType.Solid;
    labelFormat.FillFormat.SolidFillColor.Color = System.Drawing.Color.Black;

    var fraction = new MathFraction(CreateText("a+b"), CreateText("c+d"));
    var phantom = new MathPhantom(fraction);
    phantom.Show = i == 0;
    phantom.ZeroWidth = i == 2;
    phantom.ZeroAsc = i == 3;
    phantom.ZeroDesc = i == 4;

    var numerator = new MathBlock(CreateText("x+")).Join(phantom).Join(CreateText("+y"));
    var equation = new MathFraction(numerator, CreateText("z"));

    var shape = slide.Shapes.AddMathShape(left, 60, 190, 100);
    shape.TextFrame.TextFrameFormat.AnchoringType = TextAnchorType.Top;

    var mathParagraph = ((IMathPortion)shape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;
    mathParagraph.Add(new MathBlock(equation));
}

presentation.Save("math-phantom.pptx", SaveFormat.Pptx);

MathematicalText CreateText(string value)
{
    var text = new MathematicalText(value);
    text.Format.FontHeight = 24;
    text.Format.LatinFont = new FontData("Cambria Math");
    return text;
}
```

![Cinq équations dans PowerPoint comparant une fraction visible, une fraction masquée qui réserve de l'espace, et des fractions masquées avec ZeroWidth, ZeroAsc ou ZeroDesc activés](math-phantom.png)

## **Grouper des termes**

Utilisez [Group](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/group/) pour placer un caractère de groupement au-dessus ou en dessous d'une expression. Ajoutez une limite pour étiqueter les termes groupés.

![L'expression x plus y groupée avec l'étiquette texte quelconque en dessous](powerpoint-math-equations_15.png)

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

![Une expression mathématique ABC avec une barre supérieure](powerpoint-math-equations_14.png)

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

Pour formater le texte dans toute une équation existante, parcourez l'arbre des éléments de chaque bloc mathématique. [IMathElement.GetChildren](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/getchildren/) ne renvoie que les enfants immédiats, il faut donc l'appeler récursivement pour atteindre le texte à l'intérieur des fractions, scripts, radicaux et autres structures imbriquées. Vérifiez l'élément actuel ainsi que ses enfants afin d'inclure l'élément de départ lorsqu'il s'agit de [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/).

Cet exemple suppose qu'une présentation contient une équation telle que `z = xᵢ / ∛y`, avec une fraction contenant un indice dans son numérateur et un radical dans son dénominateur. Ne traiter que les éléments de niveau supérieur du bloc manquerait le texte à l'intérieur de la fraction. L'exemple trouve les portions mathématiques dans les cadres de texte des diapositives, accède à leurs blocs via [IMathPortion.MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathportion/mathparagraph/), et définit [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) à 28 points pour chaque élément de texte via sa propriété [Format](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/format/).

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

La présentation enregistrée contient le formatage du texte mis à jour à chaque niveau de chaque équation traitée, tout en préservant son contenu texte et sa structure mathématique.

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
| Ajouter des tableaux d’équations | [ToMathArray](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/tomatharray/) |
| Ajouter des délimiteurs | [Enclose](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/enclose/) |
| Ajouter des barres et des bordures | [Overbar](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/overbar/), [ToBorderBox](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/toborderbox/) |
| Grouper des termes | [Group](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/group/) |

## **FAQ**

**Puis-je modifier une équation PowerPoint existante ?**

Oui. Ouvrez la présentation, trouvez la forme qui contient un [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/), récupérez son [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/mathparagraph/), et mettez à jour les blocs mathématiques de ce paragraphe.

**Les équations sont‑elles enregistrées en tant que mathématiques PowerPoint modifiables ?**

Oui. Lorsque vous enregistrez au format PPTX, Aspose.Slides écrit l'équation comme contenu Office mathématique modifiable.

**Puis‑je exporter des équations vers LaTeX ?**

Oui. Obtenez le [IMathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathparagraph/) de l'équation à partir de son [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/), et appelez [IMathParagraph.ToLatex](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathparagraph/tolatex/) pour l'exporter directement. Pour un exemple complet, voir [Exporter les équations mathématiques depuis des présentations en .NET](/slides/fr/net/exporting-math-equations/#export-math-equations-to-latex).