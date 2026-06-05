---
title: Obtenir les propriétés effectives des formes à partir de présentations en .NET
linktitle: Propriétés effectives
type: docs
weight: 50
url: /fr/net/shape-effective-properties/
keywords:
- propriétés de forme
- propriétés de caméra
- dispositif d'éclairage
- forme biseautée
- cadre de texte
- style de texte
- hauteur de police
- format de remplissage
- PowerPoint
- présentation
- .NET
- C#
- Aspose.Slides
description: "Découvrez comment Aspose.Slides pour .NET calcule et applique les propriétés effectives des formes pour un rendu PowerPoint précis."
---
## **Vue d'ensemble**

Ce sujet explique la différence entre les propriétés **locales** et **effectives**. Les valeurs locales sont des valeurs définies directement à un niveau de mise en forme spécifique, tel que :

1. Propriétés de portion sur une diapositive.  
1. Styles de texte de forme prototype sur une diapositive de mise en page ou maître, lorsqu’une forme de cadre de texte de la portion en possède un.  
1. Paramètres de texte globaux dans une présentation.

Les valeurs locales peuvent être définies ou omises à n’importe quel niveau. Lorsque Aspose.Slides a besoin du formatage final « tel qu’affiché », il résout la chaîne d’héritage et renvoie les valeurs **effectives**. Vous pouvez les obtenir en appelant la méthode `GetEffective` sur l’objet de format local.

L’exemple suivant montre comment obtenir des valeurs effectives. Il suppose que la première forme de la première diapositive est une [IAutoShape](https://reference.aspose.com/slides/fr/net/aspose.slides/iautoshape/) avec un cadre de texte et au moins une portion.

```csharp
using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = (IAutoShape)slide.Shapes[0];

var localTextFrameFormat = shape.TextFrame.TextFrameFormat;
var effectiveTextFrameFormat = localTextFrameFormat.GetEffective();

var portion = shape.TextFrame.Paragraphs[0].Portions[0];
var localPortionFormat = portion.PortionFormat;
var effectivePortionFormat = localPortionFormat.GetEffective();
```

{{% alert color="primary" %}}
Les données de formatage effectif représentent le formatage calculé actuel après l’application de l’héritage. Dans l’implémentation actuelle, certains objets de données effectives, tels que [IPortionFormatEffectiveData](https://reference.aspose.com/slides/fr/net/aspose.slides/iportionformateffectivedata/), peuvent être mis en cache en interne. Appeler de nouveau `GetEffective` après avoir modifié le formatage parent ou hérité peut actualiser le cache, et un objet précédemment obtenu peut ne plus refléter l’état antérieur. Si vous devez conserver les valeurs effectives pour une réutilisation ultérieure, copiez les propriétés requises, comme la hauteur de police, la couleur de remplissage, le style de police ou l’alignement, dans votre propre objet de données.
{{% /alert %}}

## **Obtenir les propriétés effectives d’une caméra**

Aspose.Slides vous permet d’obtenir les propriétés effectives d’une caméra. L’interface [ICameraEffectiveData](https://reference.aspose.com/slides/fr/net/aspose.slides/icameraeffectivedata/) représente un objet immuable contenant les propriétés effectives de la caméra. Une instance de [ICameraEffectiveData](https://reference.aspose.com/slides/fr/net/aspose.slides/icameraeffectivedata/) est exposée via [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/fr/net/aspose.slides/ithreedformateffectivedata/), qui fournit les valeurs effectives pour [IThreeDFormat](https://reference.aspose.com/slides/fr/net/aspose.slides/ithreedformat/).

L’extrait de code suivant montre comment obtenir les propriétés effectives de la caméra. Il suppose que la première forme de la première diapositive possède un formatage 3D.

```csharp
using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = slide.Shapes[0];

var threeDEffectiveData = shape.ThreeDFormat.GetEffective();

Console.WriteLine("= Effective camera properties =");
Console.WriteLine("Type: " + threeDEffectiveData.Camera.CameraType);
Console.WriteLine("Field of view: " + threeDEffectiveData.Camera.FieldOfViewAngle);
Console.WriteLine("Zoom: " + threeDEffectiveData.Camera.Zoom);
```

## **Obtenir les propriétés effectives d’un dispositif d’éclairage**

Aspose.Slides vous permet d’obtenir les propriétés effectives d’un dispositif d’éclairage. L’interface [ILightRigEffectiveData](https://reference.aspose.com/slides/fr/net/aspose.slides/ilightrigeffectivedata/) représente un objet immuable contenant les propriétés effectives du dispositif d’éclairage. Une instance de [ILightRigEffectiveData](https://reference.aspose.com/slides/fr/net/aspose.slides/ilightrigeffectivedata/) est exposée via [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/fr/net/aspose.slides/ithreedformateffectivedata/), qui fournit les valeurs effectives pour [IThreeDFormat](https://reference.aspose.com/slides/fr/net/aspose.slides/ithreedformat/).

L’extrait de code suivant montre comment obtenir les propriétés effectives du dispositif d’éclairage. Il suppose que la première forme de la première diapositive possède un formatage 3D.

```csharp
using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = slide.Shapes[0];

var threeDEffectiveData = shape.ThreeDFormat.GetEffective();

Console.WriteLine("= Effective light rig properties =");
Console.WriteLine("Type: " + threeDEffectiveData.LightRig.LightType);
Console.WriteLine("Direction: " + threeDEffectiveData.LightRig.Direction);
```

## **Obtenir les propriétés effectives d’un biseau de forme**

Aspose.Slides vous permet d’obtenir les propriétés effectives d’un biseau de forme. L’interface [IShapeBevelEffectiveData](https://reference.aspose.com/slides/fr/net/aspose.slides/ishapebeveleffectivedata/) représente un objet immuable contenant les propriétés effectives de relief de surface d’une forme. Une instance de [IShapeBevelEffectiveData](https://reference.aspose.com/slides/fr/net/aspose.slides/ishapebeveleffectivedata/) est exposée via [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/fr/net/aspose.slides/ithreedformateffectivedata/), qui fournit les valeurs effectives pour [IThreeDFormat](https://reference.aspose.com/slides/fr/net/aspose.slides/ithreedformat/).

L’extrait de code suivant montre comment obtenir les propriétés effectives du biseau supérieur d’une forme. Il suppose que la première forme de la première diapositive possède un formatage 3D.

```csharp
using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = slide.Shapes[0];

var threeDEffectiveData = shape.ThreeDFormat.GetEffective();

Console.WriteLine("= Effective shape's top face relief properties =");
Console.WriteLine("Type: " + threeDEffectiveData.BevelTop.BevelType);
Console.WriteLine("Width: " + threeDEffectiveData.BevelTop.Width);
Console.WriteLine("Height: " + threeDEffectiveData.BevelTop.Height);
```

## **Obtenir les propriétés effectives d’un cadre de texte**

Avec Aspose.Slides, vous pouvez obtenir les propriétés effectives d’un cadre de texte. L’interface [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/fr/net/aspose.slides/itextframeformateffectivedata/) contient les propriétés de formatage effectif du cadre de texte.

L’extrait de code suivant montre comment obtenir les propriétés de formatage effectif du cadre de texte. Il suppose que la première forme de la première diapositive est une [IAutoShape](https://reference.aspose.com/slides/fr/net/aspose.slides/iautoshape/) avec un cadre de texte.

```csharp
using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = (IAutoShape)slide.Shapes[0];

var textFrameFormat = shape.TextFrame.TextFrameFormat;
var effectiveTextFrameFormat = textFrameFormat.GetEffective();

Console.WriteLine("Anchoring type: " + effectiveTextFrameFormat.AnchoringType);
Console.WriteLine("Autofit type: " + effectiveTextFrameFormat.AutofitType);
Console.WriteLine("Text vertical type: " + effectiveTextFrameFormat.TextVerticalType);
Console.WriteLine("Margins");
Console.WriteLine("   Left: " + effectiveTextFrameFormat.MarginLeft);
Console.WriteLine("   Top: " + effectiveTextFrameFormat.MarginTop);
Console.WriteLine("   Right: " + effectiveTextFrameFormat.MarginRight);
Console.WriteLine("   Bottom: " + effectiveTextFrameFormat.MarginBottom);
```

## **Obtenir les propriétés effectives d’un style de texte**

Avec Aspose.Slides, vous pouvez obtenir les propriétés effectives d’un style de texte. L’interface [ITextStyleEffectiveData](https://reference.aspose.com/slides/fr/net/aspose.slides/itextstyleeffectivedata/) contient les propriétés de style de texte effectives.

L’extrait de code suivant montre comment obtenir les propriétés effectives du style de texte. Il suppose que la première forme de la première diapositive est une [IAutoShape](https://reference.aspose.com/slides/fr/net/aspose.slides/iautoshape/) avec un cadre de texte.

```csharp
using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = (IAutoShape)slide.Shapes[0];

var effectiveTextStyle = shape.TextFrame.TextFrameFormat.TextStyle.GetEffective();
var levelCount = 9;

for (var levelIndex = 0; levelIndex < levelCount; levelIndex++)
{
    var effectiveStyleLevel = effectiveTextStyle.GetLevel(levelIndex);
    Console.WriteLine("= Effective paragraph formatting for style level #" + levelIndex + " =");

    Console.WriteLine("Depth: " + effectiveStyleLevel.Depth);
    Console.WriteLine("Indent: " + effectiveStyleLevel.Indent);
    Console.WriteLine("Alignment: " + effectiveStyleLevel.Alignment);
    Console.WriteLine("Font alignment: " + effectiveStyleLevel.FontAlignment);
}
```

## **Obtenir la valeur effective de la hauteur de police**

Avec Aspose.Slides, vous pouvez obtenir la hauteur de police effective. Le code suivant montre comment la hauteur de police effective d’une portion change après que des valeurs locales de hauteur de police aient été définies à différents niveaux de la structure de la présentation.

```csharp
using var presentation = new Presentation();

var slide = presentation.Slides[0];
var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 75, false);
autoShape.AddTextFrame("");

var paragraph = autoShape.TextFrame.Paragraphs[0];
paragraph.Portions.Clear();

var firstPortion = new Portion("Sample text with first portion");
var secondPortion = new Portion(" and second portion.");

paragraph.Portions.Add(firstPortion);
paragraph.Portions.Add(secondPortion);

var firstPortionFormatEffectiveData = firstPortion.PortionFormat.GetEffective();
var secondPortionFormatEffectiveData = secondPortion.PortionFormat.GetEffective();

Console.WriteLine("Effective font height just after creation:");
Console.WriteLine("Portion #0: " + firstPortionFormatEffectiveData.FontHeight);
Console.WriteLine("Portion #1: " + secondPortionFormatEffectiveData.FontHeight);

presentation.DefaultTextStyle.GetLevel(0).DefaultPortionFormat.FontHeight = 24;
firstPortionFormatEffectiveData = firstPortion.PortionFormat.GetEffective();
secondPortionFormatEffectiveData = secondPortion.PortionFormat.GetEffective();

Console.WriteLine("Effective font height after setting the presentation default font height:");
Console.WriteLine("Portion #0: " + firstPortionFormatEffectiveData.FontHeight);
Console.WriteLine("Portion #1: " + secondPortionFormatEffectiveData.FontHeight);

paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight = 40;
firstPortionFormatEffectiveData = firstPortion.PortionFormat.GetEffective();
secondPortionFormatEffectiveData = secondPortion.PortionFormat.GetEffective();

Console.WriteLine("Effective font height after setting paragraph default font height:");
Console.WriteLine("Portion #0: " + firstPortionFormatEffectiveData.FontHeight);
Console.WriteLine("Portion #1: " + secondPortionFormatEffectiveData.FontHeight);

firstPortion.PortionFormat.FontHeight = 55;
firstPortionFormatEffectiveData = firstPortion.PortionFormat.GetEffective();
secondPortionFormatEffectiveData = secondPortion.PortionFormat.GetEffective();

Console.WriteLine("Effective font height after setting portion #0 font height:");
Console.WriteLine("Portion #0: " + firstPortionFormatEffectiveData.FontHeight);
Console.WriteLine("Portion #1: " + secondPortionFormatEffectiveData.FontHeight);

secondPortion.PortionFormat.FontHeight = 18;
firstPortionFormatEffectiveData = firstPortion.PortionFormat.GetEffective();
secondPortionFormatEffectiveData = secondPortion.PortionFormat.GetEffective();

Console.WriteLine("Effective font height after setting portion #1 font height:");
Console.WriteLine("Portion #0: " + firstPortionFormatEffectiveData.FontHeight);
Console.WriteLine("Portion #1: " + secondPortionFormatEffectiveData.FontHeight);

presentation.Save("SetLocalFontHeightValues.pptx", SaveFormat.Pptx);
```

## **Obtenir le format de remplissage effectif d’un tableau**

Avec Aspose.Slides, vous pouvez obtenir le format de remplissage effectif pour différentes parties d’un tableau. L’interface [IFillFormatEffectiveData](https://reference.aspose.com/slides/fr/net/aspose.slides/ifillformateffectivedata/) contient les propriétés de format de remplissage effectif. Le formatage des cellules a une priorité supérieure à celui des lignes, le formatage des lignes est prioritaire sur celui des colonnes, et le formatage des colonnes l’emporte sur le formatage du tableau entier.

En conséquence, les propriétés de [ICellFormatEffectiveData](https://reference.aspose.com/slides/fr/net/aspose.slides/icellformateffectivedata/) sont utilisées pour dessiner la cellule du tableau. L’extrait de code suivant montre comment obtenir le format de remplissage effectif pour différentes parties du tableau. Il suppose que la première forme de la première diapositive est une [ITable](https://reference.aspose.com/slides/fr/net/aspose.slides/itable/).

```csharp
using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var table = (ITable)presentation.Slides[0].Shapes[0];

var tableFormatEffective = table.TableFormat.GetEffective();
var rowFormatEffective = table.Rows[0].RowFormat.GetEffective();
var columnFormatEffective = table.Columns[0].ColumnFormat.GetEffective();
var cellFormatEffective = table[0, 0].CellFormat.GetEffective();

var tableFillFormatEffective = tableFormatEffective.FillFormat;
var rowFillFormatEffective = rowFormatEffective.FillFormat;
var columnFillFormatEffective = columnFormatEffective.FillFormat;
var cellFillFormatEffective = cellFormatEffective.FillFormat;
```

## **FAQ**

**`GetEffective` renvoie-t‑il un instantané ?**

Pas toujours. Les données effectives représentent le formatage calculé après l’application de l’héritage, mais certains objets de données effectives peuvent être mis en cache en interne. Un appel ultérieur à `GetEffective` peut recalculer le formatage et actualiser le cache, de sorte qu’un objet précédemment obtenu ne doit pas être considéré comme un instantané durable.

**Quand devrais‑je relire les propriétés effectives ?**

Appelez à nouveau `GetEffective` après avoir modifié le formatage local, les styles parents, le formatage de mise en page, le formatage maître ou les valeurs par défaut au niveau de la présentation. L’appel suivant réévalue la hiérarchie de formatage et renvoie le résultat effectif actuel.

**La modification ou la suppression d’une diapositive de mise en page/maître affecte‑t‑elle les propriétés effectives déjà récupérées ?**

Oui, mais le changement n’est reflété qu’à l’appel suivant de `GetEffective`. Si une source de formatage parent est modifiée ou supprimée, les données effectives précédemment obtenues peuvent être obsolètes. Une fois `GetEffective` appelé de nouveau, Aspose.Slides réévalue l’arbre de formatage et les polices, couleurs, tailles ou autres valeurs peuvent changer.

**Puis‑je modifier les valeurs via les objets de données effectives ?**

Non. Les objets de données effectives exposent des valeurs calculées. Apportez les modifications aux objets de formatage locaux, puis récupérez à nouveau les valeurs effectives.

**Que se passe‑t‑il si une propriété n’est pas définie au niveau de la forme, ni dans la mise en page/maître, ni dans les paramètres globaux ?**

La valeur effective est déterminée par le mécanisme par défaut, qui comprend les valeurs par défaut de PowerPoint et d’Aspose.Slides. Cette valeur résolue fait alors partie des données effectives actuelles.

**À partir d’une valeur de police effective, puis‑je identifier le niveau qui a fourni la taille ou la police ?**

Pas directement. Les données effectives renvoient la valeur finale. Pour identifier la source, vérifiez les valeurs locales au niveau de la portion, du paragraphe, du cadre de texte et des styles de texte à la mise en page, au maître et à la présentation, afin de voir où apparaît la première définition explicite.

**Pourquoi les valeurs effectives ressemblent parfois exactement aux valeurs locales ?**

Parce que la valeur locale s’est avérée finale (aucune héritage de niveau supérieur n’a été nécessaire). Dans ces cas, la valeur effective correspond à la valeur locale.

**Quand devrais‑je utiliser les propriétés effectives et quand travailler uniquement avec les locales ?**

Utilisez les données effectives lorsque vous avez besoin du résultat « tel qu’affiché » après l’application de tout l’héritage, par exemple pour aligner les couleurs, les retraits ou les tailles. Si vous devez conserver ces valeurs indépendamment des modifications de formatage ultérieures, copiez les propriétés requises dans votre propre objet. Si vous devez modifier le formatage à un niveau spécifique, modifiez les propriétés locales puis, si nécessaire, relisez les données effectives pour vérifier le résultat.