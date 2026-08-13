---
title: Obtenir les propriétés effectives des formes à partir des présentations en .NET
linktitle: Propriétés effectives
type: docs
weight: 50
url: /fr/net/shape-effective-properties/
keywords:
- propriétés de forme
- propriétés de la caméra
- système d’éclairage
- forme chanfreinée
- cadre de texte
- style de texte
- hauteur de police
- format de remplissage
- PowerPoint
- présentation
- .NET
- C#
- Aspose.Slides
description: "Apprenez à utiliser Aspose.Slides pour .NET afin de distinguer le formatage local, hérité et effectif des formes dans les présentations PowerPoint."
---
## **Comprendre les propriétés locales, héritées et effectives**

Le formatage PowerPoint peut provenir de plusieurs sources. La valeur stockée directement sur un objet est sa **valeur locale**. Si cette valeur n’est pas définie, PowerPoint examine les sources de formatage parentes, comme la valeur par défaut d’un paragraphe, un style de texte, une diapositive de mise en page ou maître, un thème ou les valeurs par défaut au niveau de la présentation. Ces valeurs sont les **valeurs héritées**. La valeur qui subsiste après la résolution de toute la hiérarchie est la **valeur effective** — la valeur utilisée pour rendre l’objet.

Par exemple, une portion de texte peut ne pas définir sa propre hauteur de police. Sa [HauteurPolice](https://reference.aspose.com/slides/fr/net/aspose.slides/ibaseportionformat/fontheight/) locale est alors `float.NaN`, ce qui signifie « non définie ici ». La portion peut hériter d’une hauteur depuis son paragraphe, le style de texte par défaut de la présentation ou une autre source applicable. Appeler [GetEffective](https://reference.aspose.com/slides/fr/net/aspose.slides/iportionformat/geteffective/) sur le format de la portion renvoie la hauteur résolue finale.

Utilisez les deux types de données de formatage à des fins différentes :

- Lisez ou modifiez un objet de format local, tel que [IPortionFormat](https://reference.aspose.com/slides/fr/net/aspose.slides/iportionformat/), lorsque vous devez contrôler où une valeur est définie.
- Lisez un objet de données effectives, tel que [IPortionFormatEffectiveData](https://reference.aspose.com/slides/fr/net/aspose.slides/iportionformateffectivedata/), lorsque vous avez besoin du résultat final rendu. Les données effectives sont en lecture seule.

## **Comparer les valeurs locales, héritées et effectives**

L’exemple complet suivant crée une forme et applique des hauteurs de police au niveau de la présentation, du paragraphe et de la portion. Chaque étape affiche les valeurs définies à ces niveaux ainsi que la valeur effective résultante pour la même portion de texte. Il montre également pourquoi les données effectives doivent être relues après des modifications de formatage.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 500, 80, false);
var textFrame = shape.AddTextFrame("Effective formatting");
var paragraph = textFrame.Paragraphs[0];
var portion = paragraph.Portions[0];

// Définir des valeurs héritées à deux niveaux différents.
presentation.DefaultTextStyle.GetLevel(0).DefaultPortionFormat.FontHeight = 20;
paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight = 28;

PrintFontHeights("The portion inherits from the paragraph", presentation, paragraph, portion);

// Une valeur locale sur la portion écrase les deux valeurs héritées.
portion.PortionFormat.FontHeight = 36;
PrintFontHeights("A local value overrides inherited values", presentation, paragraph, portion);

// Modifier une valeur héritée n'écrase pas une valeur locale existante.
paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight = 30;
PrintFontHeights("The local value still has priority", presentation, paragraph, portion);

// Effacer la valeur locale. La portion hérite à nouveau du paragraphe.
portion.PortionFormat.FontHeight = float.NaN;
PrintFontHeights("The local value is cleared", presentation, paragraph, portion);

// Effacer la valeur du paragraphe. La valeur par défaut de la présentation fournit maintenant le résultat.
paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight = float.NaN;
PrintFontHeights("The paragraph value is cleared", presentation, paragraph, portion);

presentation.Save("effective-properties.pptx", SaveFormat.Pptx);

static void PrintFontHeights(string caption, Presentation presentation, IParagraph paragraph, IPortion portion)
{
    var presentationValue = presentation.DefaultTextStyle.GetLevel(0).DefaultPortionFormat.FontHeight;
    var paragraphValue = paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight;
    var localValue = portion.PortionFormat.FontHeight;

    // Lire les données effectives après les changements précédents.
    var effectiveValue = portion.PortionFormat.GetEffective().FontHeight;

    Console.WriteLine(caption);
    Console.WriteLine($"  Presentation default: {FormatLocalValue(presentationValue)}");
    Console.WriteLine($"  Paragraph default:    {FormatLocalValue(paragraphValue)}");
    Console.WriteLine($"  Portion local:        {FormatLocalValue(localValue)}");
    Console.WriteLine($"  Portion effective:    {effectiveValue}");
}

static string FormatLocalValue(float value) => float.IsNaN(value) ? "<not set>" : value.ToString();
```

La priorité dans cet exemple est le formatage local de la portion, puis le formatage du paragraphe, puis la valeur par défaut de la présentation. D’autres objets peuvent avoir des chaînes d’héritage différentes, mais le principe est le même : une valeur explicite plus spécifique l’emporte, et [GetEffective](https://reference.aspose.com/slides/fr/net/aspose.slides/iportionformat/geteffective/) renvoie le résultat final.

## **Obtenir les propriétés de texte effectives**

Le formatage du texte est réparti sur plusieurs objets :

- [ITextFrameFormat.GetEffective()](https://reference.aspose.com/slides/fr/net/aspose.slides/itextframeformat/geteffective/) résout les propriétés du cadre de texte telles que les marges, l’ancrage, l’ajustement automatique et la direction verticale du texte.
- [ITextStyle.GetEffective()](https://reference.aspose.com/slides/fr/net/aspose.slides/itextstyle/geteffective/) résout le formatage des paragraphes pour chaque niveau de style de texte.
- [IParagraphFormat.GetEffective()](https://reference.aspose.com/slides/fr/net/aspose.slides/iparagraphformat/geteffective/) résout les propriétés du paragraphe telles que l’alignement, l’indentation et les puces.
- [IPortionFormat.GetEffective()](https://reference.aspose.com/slides/fr/net/aspose.slides/iportionformat/geteffective/) résout les propriétés de caractère telles que la hauteur de police, le nom de la police, la couleur, le gras et l’italique.

Pour l’exemple suivant, `text-formatting.pptx` doit contenir au moins une diapositive et une [AutoShape](https://reference.aspose.com/slides/fr/net/aspose.slides/autoshape/) avec un cadre de texte non vide. L’AutoShape peut se trouver à n’importe quelle position de la collection de formes ; le code recherche un objet approprié et le valide avant utilisation.

```csharp
using System;
using System.Linq;
using Aspose.Slides;

using var presentation = new Presentation("text-formatting.pptx");

if (presentation.Slides.Count == 0)
    throw new InvalidOperationException("The presentation contains no slides.");

var autoShapes = presentation.Slides[0].Shapes.OfType<IAutoShape>();
var shape = autoShapes.FirstOrDefault(candidate => HasNonEmptyText(candidate));

if (shape == null)
{
    throw new InvalidOperationException("The first slide must contain an AutoShape with non-empty text.");
}

var textFrame = shape.TextFrame;
var paragraph = textFrame.Paragraphs[0];
var portion = paragraph.Portions[0];

var textFrameEffective = textFrame.TextFrameFormat.GetEffective();
var paragraphEffective = paragraph.ParagraphFormat.GetEffective();
var portionEffective = portion.PortionFormat.GetEffective();

Console.WriteLine("Text frame margins:");
Console.WriteLine($"  Left: {textFrameEffective.MarginLeft}");
Console.WriteLine($"  Top: {textFrameEffective.MarginTop}");
Console.WriteLine($"  Right: {textFrameEffective.MarginRight}");
Console.WriteLine($"  Bottom: {textFrameEffective.MarginBottom}");
Console.WriteLine($"Paragraph alignment: {paragraphEffective.Alignment}");
Console.WriteLine($"Font height: {portionEffective.FontHeight}");
Console.WriteLine($"Bold: {portionEffective.FontBold}");

var effectiveTextStyle = textFrame.TextFrameFormat.TextStyle.GetEffective();
for (var level = 0; level < 9; level++)
{
    var levelEffective = effectiveTextStyle.GetLevel(level);
    Console.WriteLine($"Level {level} indent: {levelEffective.Indent}");
}

static bool HasNonEmptyText(IAutoShape shape)
{
    if (shape.TextFrame == null)
        return false;

    if (shape.TextFrame.Paragraphs.Count == 0)
        return false;

    return shape.TextFrame.Paragraphs[0].Portions.Count > 0;
}
```

## **Obtenir les propriétés 3D effectives**

[IThreeDFormat.GetEffective()](https://reference.aspose.com/slides/fr/net/aspose.slides/ithreedformat/geteffective/) renvoie un objet [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/fr/net/aspose.slides/ithreedformateffectivedata/) qui regroupe tous les paramètres 3D résolus. Ses propriétés [Camera](https://reference.aspose.com/slides/fr/net/aspose.slides/ithreedformateffectivedata/camera/), [LightRig](https://reference.aspose.com/slides/fr/net/aspose.slides/ithreedformateffectivedata/lightrig/), [BevelTop](https://reference.aspose.com/slides/fr/net/aspose.slides/ithreedformateffectivedata/beveltop/) et [BevelBottom](https://reference.aspose.com/slides/fr/net/aspose.slides/ithreedformateffectivedata/bevelbottom/) exposent les données effectives correspondantes. Lire ces paramètres liés ensemble facilite la compréhension de l’apparence 3D finale d’une forme.

Pour cet exemple, `shape-3d.pptx` doit contenir au moins une forme sur sa première diapositive. Appliquez un réglage de caméra 3D, d’éclairage ou de chanfrein à cette forme si vous souhaitez que la sortie contienne des valeurs autres que les valeurs par défaut.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("shape-3d.pptx");

if (presentation.Slides.Count == 0 || presentation.Slides[0].Shapes.Count == 0)
{
    throw new InvalidOperationException("The first slide must contain a shape.");
}

var shape = presentation.Slides[0].Shapes[0];
var threeDEffective = shape.ThreeDFormat.GetEffective();

Console.WriteLine("Camera:");
Console.WriteLine($"  Type: {threeDEffective.Camera.CameraType}");
Console.WriteLine($"  Field of view: {threeDEffective.Camera.FieldOfViewAngle}");
Console.WriteLine($"  Zoom: {threeDEffective.Camera.Zoom}");

Console.WriteLine("Light rig:");
Console.WriteLine($"  Type: {threeDEffective.LightRig.LightType}");
Console.WriteLine($"  Direction: {threeDEffective.LightRig.Direction}");

Console.WriteLine("Top bevel:");
Console.WriteLine($"  Type: {threeDEffective.BevelTop.BevelType}");
Console.WriteLine($"  Width: {threeDEffective.BevelTop.Width}");
Console.WriteLine($"  Height: {threeDEffective.BevelTop.Height}");
```

## **Obtenir le formatage de tableau effectif**

Le formatage d’un tableau peut provenir du style de tableau et des formats appliqués à tout le tableau, à une colonne, à une ligne ou à une cellule individuelle. En cas de conflit entre des remplissages explicitement définis, la priorité est : cellule, ligne, colonne, puis tableau complet. Le format effectif d’une cellule est le format final utilisé pour dessiner cette cellule.

Pour cet exemple, `table-formatting.pptx` doit contenir au moins un tableau sur sa première diapositive. Le tableau doit comporter au moins une ligne et une colonne. Le code recherche un [ITable](https://reference.aspose.com/slides/fr/net/aspose.slides/itable/) au lieu de supposer que `Shapes[0]` est un tableau.

```csharp
using System;
using System.Linq;
using Aspose.Slides;

using var presentation = new Presentation("table-formatting.pptx");

if (presentation.Slides.Count == 0)
    throw new InvalidOperationException("The presentation contains no slides.");

var table = presentation.Slides[0].Shapes.OfType<ITable>().FirstOrDefault();

if (table == null)
    throw new InvalidOperationException("The first slide must contain a table.");

if (table.Rows.Count == 0 || table.Columns.Count == 0)
    throw new InvalidOperationException("The table must contain at least one cell.");

var tableEffective = table.TableFormat.GetEffective();
var rowEffective = table.Rows[0].RowFormat.GetEffective();
var columnEffective = table.Columns[0].ColumnFormat.GetEffective();
var cellEffective = table[0, 0].CellFormat.GetEffective();

Console.WriteLine($"Table fill: {tableEffective.FillFormat.FillType}");
Console.WriteLine($"Row fill: {rowEffective.FillFormat.FillType}");
Console.WriteLine($"Column fill: {columnEffective.FillFormat.FillType}");
Console.WriteLine($"Final cell fill: {cellEffective.FillFormat.FillType}");
```

Si vous avez besoin de la couleur plutôt que du seul type de remplissage, vérifiez d’abord le [FillType](https://reference.aspose.com/slides/fr/net/aspose.slides/ifillformateffectivedata/filltype/) effectif, puis lisez la propriété applicable à ce type — par exemple, [SolidFillColor](https://reference.aspose.com/slides/fr/net/aspose.slides/ifillformateffectivedata/solidfillcolor/) pour un remplissage plein.

## **Relire les données effectives après des modifications**

Les données effectives décrivent la hiérarchie de formatage au moment où elles sont résolues. Appelez `GetEffective` de nouveau après avoir modifié quoi que ce soit pouvant participer à cette hiérarchie, y compris :

- le format local de l’objet ;
- les valeurs par défaut du paragraphe ou du cadre de texte ;
- un style de tableau, le tableau, une colonne, une ligne ou le format d’une cellule ;
- le formatage de la mise en page ou de la diapositive maître ;
- les données de thème ou les valeurs par défaut au niveau de la présentation ;
- la mise en page ou le maître assigné à une diapositive.

Ne conservez pas un objet de données effectives comme une capture permanente. Aspose.Slides peut mettre en cache certaines données effectives en interne, et un appel ultérieur à `GetEffective` peut actualiser ces données. Si vous devez comparer des valeurs avant et après une modification, copiez les valeurs scalaires dont vous avez besoin — comme une hauteur de police, une couleur, un alignement ou une largeur de chanfrein—dans vos propres variables avant d’effectuer le changement.

Pour modifier une valeur, mettez à jour l’objet de format local approprié, puis appelez `GetEffective` pour vérifier le résultat. Les objets de données effectives eux‑mêmes sont en lecture seule.

## **FAQ**

**Comment savoir quel niveau a fourni une valeur effective ?**

Les données effectives contiennent la valeur finale, pas sa source. Examinez les objets locaux applicables du niveau le plus spécifique vers l’extérieur. Pour le texte, cela peut inclure la portion, le paragraphe, le cadre de texte, la mise en page, le maître, le thème et les valeurs par défaut de la présentation. Les valeurs non définies telles que `float.NaN` ou `null` indiquent que la recherche se poursuit à un niveau supérieur.

**Que se passe‑t‑il lorsqu’aucun niveau ne définit une propriété ?**

Aspose.Slides résout la valeur par défaut appropriée de PowerPoint ou de la bibliothèque. Cette valeur résolue apparaît dans les données effectives même si aucun objet local ne la définit explicitement.

**Pourquoi une valeur effective est‑elle parfois égale à la valeur locale ?**

La valeur locale a gagné le calcul d’héritage. Cela est attendu lorsque la propriété est explicitement définie sur l’objet et qu’aucune règle plus précise ne la remplace.

**Quand faut‑il utiliser les données locales plutôt que les données effectives ?**

Utilisez les données locales pour inspecter ou modifier un niveau de formatage spécifique. Utilisez les données effectives lorsque vous avez besoin de l’apparence finale après l’héritage, les règles de thème et les styles applicables. L’[exemple complet de comparaison](#compare-local-inherited-and-effective-values) montre les deux approches dans le même flux de travail.