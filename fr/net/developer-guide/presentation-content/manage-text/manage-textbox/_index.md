---
title: Gérer les zones de texte dans les présentations en .NET
linktitle: Gérer la zone de texte
type: docs
weight: 20
url: /fr/net/manage-textbox/
keywords:
- zone de texte
- cadre de texte
- ajouter du texte
- mettre à jour le texte
- créer une zone de texte
- vérifier la zone de texte
- ajouter une colonne de texte
- ajouter un hyperlien
- PowerPoint
- présentation
- .NET
- C#
- Aspose.Slides
description: "Créer, identifier, formater et mettre à jour les zones de texte dans les présentations PowerPoint et OpenDocument à l'aide d'Aspose.Slides pour .NET."
---
## **Introduction**

Dans Aspose.Slides pour .NET, le texte des diapositives est stocké dans des cadres de texte qui appartiennent à des formes. L'interface [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) représente la forme la plus courante contenant du texte et expose son texte via la propriété [IAutoShape.TextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/textframe/).

{{% alert color="info" title="Note" %}}

Chaque forme auto implémente [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/), mais toutes les formes ne sont pas des formes auto ou ne supportent pas un cadre de texte. Lors du traitement d'une présentation existante, vérifiez qu'une forme implémente `IAutoShape` avant d'accéder à son texte.

{{% /alert %}}

## **Créer une zone de texte sur une diapositive**

Pour créer une zone de texte, ajoutez une forme auto à une diapositive, ajoutez du texte à son cadre de texte, puis enregistrez la présentation. L'exemple suivant crée une zone de texte rectangulaire :

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var textBox = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 300, 50);
textBox.AddTextFrame("Aspose TextBox");

presentation.Save("TextBox.pptx", SaveFormat.Pptx);
```

Les coordonnées et les dimensions passées à [IShapeCollection.AddAutoShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addautoshape/) sont mesurées en points. [IAutoShape.AddTextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/addtextframe/) initialise le cadre de texte avec le texte fourni.

## **Vérifier si une forme est une zone de texte**

Utilisez la propriété [AutoShape.IsTextBox](https://reference.aspose.com/slides/net/aspose.slides/autoshape/istextbox/) pour déterminer si une forme auto est considérée comme une zone de texte. Cela est utile lorsqu'une présentation contient à la fois des formes auto contenant du texte et des formes purement graphiques.

![Une zone de texte et une forme](istextbox.png)

L'exemple suivant examine chaque forme auto dans une présentation :

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var textBox = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 120, 40);
textBox.AddTextFrame("Text box");
slide.Shapes.AddAutoShape(ShapeType.Ellipse, 150, 10, 40, 40);

foreach (var currentSlide in presentation.Slides)
{
    foreach (var shape in currentSlide.Shapes)
    {
        if (shape is IAutoShape autoShape)
        {
            Console.WriteLine(autoShape.IsTextBox ? "The shape is a text box." : "The shape is not a text box.");
        }
    }
}
```

Une forme auto nouvellement ajoutée n'est pas considérée comme une zone de texte tant qu'elle ne contient pas de texte non‑vide. Vous pouvez fournir ce texte via [IAutoShape.AddTextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/addtextframe/) ou [ITextFrame.Text](https://reference.aspose.com/slides/net/aspose.slides/itextframe/text/). Ajouter ou affecter une chaîne vide laisse `IsTextBox` à `false` :

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 40);
shape1.AddTextFrame("Shape 1");
Console.WriteLine(shape1.IsTextBox);

var shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 70, 100, 40);
shape2.TextFrame.Text = "Shape 2";
Console.WriteLine(shape2.IsTextBox);

var shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 130, 100, 40);
shape3.AddTextFrame("");
Console.WriteLine(shape3.IsTextBox);

var shape4 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 190, 100, 40);
shape4.TextFrame.Text = "";
Console.WriteLine(shape4.IsTextBox);
```

Les deux premiers appels affichent `True` ; les deux derniers affichent `False`.

## **Trouver la forme qui possède un cadre de texte**

Le code générique de traitement de texte peut recevoir un [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) sans savoir quel objet de présentation le contient. Utilisez la propriété en lecture seule [ITextFrame.ParentShape](https://reference.aspose.com/slides/net/aspose.slides/itextframe/parentshape/) pour revenir à sa [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) propriétaire.

Pour un cadre de texte appartenant à une forme auto ou à une autre forme contenant du texte, `ParentShape` contient le propriétaire et [ITextFrame.ParentCell](https://reference.aspose.com/slides/net/aspose.slides/itextframe/parentcell/) est `null`. Vérifiez la valeur retournée avant de l'utiliser. Pour identifier à la fois les propriétaires de forme et de cellule de tableau, y compris les formes associées aux nœuds SmartArt, consultez [Search and Replace Text](/slides/fr/net/search-and-replace-text/).

## **Obtenir le rectangle de texte de la forme**

À partir d'Aspose.Slides pour .NET 26.11, [ITextFrame.GetTextRect](https://reference.aspose.com/slides/net/aspose.slides/itextframe/gettextrect/) renvoie la zone de texte définie par la géométrie de la forme parent. Ses coordonnées et dimensions sont exprimées en points, relatives au coin supérieur gauche de cette forme. Par exemple, une ellipse possède un rectangle de texte plus petit que ses limites extérieures.

Ce rectangle décrit la forme, pas les caractères rendus. Modifier le texte ou les marges du cadre de texte ne le transforme pas en mesure du texte occupé. Utilisez [paragraph bounds](/slides/fr/net/paragraph-bounds/) ou [portion bounds](/slides/fr/net/portion-bounds/) pour des mesures du texte rendu.

Après [installing Aspose.Slides for .NET](/slides/fr/net/installation/) 26.11 ou ultérieur, exécutez cet exemple pour dessiner le rectangle de texte géométrique en rouge. Les formes ne sont ni tournées ni groupées, ainsi ajouter leur position X/Y suffit à placer la superposition sur la diapositive.

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

foreach (var shapeType in new[] { ShapeType.Rectangle, ShapeType.Ellipse })
{
    var x = shapeType == ShapeType.Rectangle ? 50 : 300;
    var shape = slide.Shapes.AddAutoShape(shapeType, x, 200, 200, 100);
    shape.AddTextFrame("Text area");
    var rectangle = shape.TextFrame.GetTextRect();
    Console.WriteLine($"{shapeType}: {rectangle}");

    var overlayX = shape.X + rectangle.X;
    var overlayY = shape.Y + rectangle.Y;
    var outline = slide.Shapes.AddAutoShape(ShapeType.Rectangle, overlayX, overlayY, rectangle.Width, rectangle.Height);
    outline.FillFormat.FillType = FillType.NoFill;
    outline.LineFormat.FillFormat.FillType = FillType.Solid;
    outline.LineFormat.FillFormat.SolidFillColor.Color = Color.Red;
}

presentation.Save("text-rectangles.pptx", SaveFormat.Pptx);
```

Pour les formes de 200 × 100 points ci‑dessus, le rectangle renvoie `(0, 0, 200, 100)` ; l'ellipse renvoie approximativement `(29.289, 14.645, 141.421, 70.711)`. La méthode lit également le rectangle de texte déclaré d'une géométrie personnalisée. Elle n'applique pas la rotation de l'espace de diapositive ni les transformations de groupe ; il faut en tenir compte séparément lors du positionnement d’une superposition. Un cadre de texte sans forme géométrique, comme un cadre de texte de cellule de tableau, peut lever une `InvalidOperationException`.

## **Ajouter des colonnes à une zone de texte**

La propriété [ITextFrameFormat.ColumnCount](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/columncount/) divise le cadre de texte en colonnes, tandis que [ITextFrameFormat.ColumnSpacing](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/columnspacing/) définit l'espacement entre les colonnes en points. Les deux paramètres appartiennent à [ITextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/) et peuvent être modifiés via le cadre de texte d'une zone de texte existante. Le texte se réajuste entre les colonnes à l'intérieur de la même forme ; il ne continue pas dans une autre forme.

L'exemple suivant crée une zone de texte à trois colonnes avec 10 points d'espacement, enregistre la présentation et lit les paramètres enregistrés depuis le fichier de sortie :

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var textBox = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 200);
textBox.AddTextFrame("This text is distributed automatically across all columns in the text box.");

var textFrameFormat = textBox.TextFrame.TextFrameFormat;
textFrameFormat.ColumnCount = 3;
textFrameFormat.ColumnSpacing = 10;

presentation.Save("TextBoxColumns.pptx", SaveFormat.Pptx);

using var savedPresentation = new Presentation("TextBoxColumns.pptx");
var savedTextBox = (IAutoShape)savedPresentation.Slides[0].Shapes[0];
var savedFormat = savedTextBox.TextFrame.TextFrameFormat;
Console.WriteLine($"Columns: {savedFormat.ColumnCount}; spacing: {savedFormat.ColumnSpacing} points");
```

## **Extraire le texte de chaque colonne**

Utilisez [TextFrame.SplitTextByColumns](https://reference.aspose.com/slides/net/aspose.slides/textframe/splittextbycolumns/) pour récupérer le texte attribué à chaque colonne visuelle d'un cadre de texte existant. La méthode renvoie une chaîne pour chaque colonne, dans l'ordre de lecture basé sur les colonnes. Un cadre de texte à une seule colonne produit un tableau d'un élément, et une colonne vide est représentée par une chaîne vide. Les chaînes contiennent uniquement du texte brut ; le formatage au niveau des portions n'est pas conservé.

Ceci est utile lorsque vous devez :

- Extraire le texte tout en conservant son ordre de lecture basé sur les colonnes.
- Indexer ou comparer le contenu des diapositives à colonnes multiples.
- Exporter chaque colonne vers un fichier séparé, un champ de base de données ou une autre destination.
- Inspecter comment le texte est redistribué après avoir modifié [ITextFrameFormat.ColumnCount](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/columncount/), [ITextFrameFormat.ColumnSpacing](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/columnspacing/), la police ou la taille du cadre de texte.

La méthode rend compte du texte distribué dans le [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) actuel ; elle ne fait pas couler automatiquement le texte entre des formes ou zones de texte séparées. La répartition des colonnes peut dépendre des polices disponibles et d'autres paramètres de mise en page, assurez‑vous donc que les polices requises sont présentes lorsque des résultats cohérents sont importants.

L'exemple suivant charge une présentation, trouve la première forme auto à colonnes multiples avec un cadre de texte, lit le nombre de colonnes configuré, puis écrit le texte de chaque colonne dans un fichier séparé. Les formes ne fournissant pas de cadre de texte sont ignorées.

```csharp
using System;
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation("MultiColumnText.pptx");

IAutoShape? textBox = null;
foreach (var shape in presentation.Slides[0].Shapes)
{
    if (shape is IAutoShape autoShape && autoShape.TextFrame is not null)
    {
        var columnCount = autoShape.TextFrame.TextFrameFormat.ColumnCount;
        if (columnCount > 1)
        {
            textBox = autoShape;
            break;
        }
    }
}

if (textBox is null)
{
    Console.WriteLine("No multi-column text frame was found.");
}
else
{
    var textFrame = textBox.TextFrame;
    var configuredColumnCount = textFrame.TextFrameFormat.ColumnCount;
    var columnTexts = textFrame.SplitTextByColumns();

    Console.WriteLine($"Configured columns: {configuredColumnCount}");

    for (var columnIndex = 0; columnIndex < columnTexts.Length; columnIndex++)
    {
        var columnNumber = columnIndex + 1;
        var columnText = columnTexts[columnIndex];
        Console.WriteLine($"Column {columnNumber}: {columnText}");
        File.WriteAllText($"Column-{columnNumber}.txt", columnText);
    }
}
```

## **Mettre à jour le texte**

Pour mettre à jour le texte dans l'ensemble d'une présentation, parcourez les diapositives et les formes, sélectionnez les formes auto, puis modifiez leurs portions de texte. Travailler au niveau de la portion vous permet de modifier à la fois le texte et le formatage des caractères.

L'exemple suivant remplace chaque occurrence de `years` par `months` dans le texte des formes auto et rend chaque portion affectée en gras :

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Text.pptx");

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape is not IAutoShape autoShape)
        {
            continue;
        }

        foreach (var paragraph in autoShape.TextFrame.Paragraphs)
        {
            foreach (var portion in paragraph.Portions)
            {
                portion.Text = portion.Text.Replace("years", "months");
                portion.PortionFormat.FontBold = NullableBool.True;
            }
        }
    }
}

presentation.Save("TextChanged.pptx", SaveFormat.Pptx);
```

Cette traversée met à jour le texte uniquement dans les formes auto. Le texte stocké dans les tableaux, graphiques, SmartArt ou formes groupées nécessite de parcourir les collections propres à ces objets.

## **Ajouter une zone de texte avec un hyperlien**

Un hyperlien peut être attribué à une portion de texte spécifique, de sorte que seul ce texte agit comme lien cliquable. Utilisez [IHyperlinkManager.SetExternalHyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/setexternalhyperlinkclick/) pour associer la portion à une URL externe.

L'exemple suivant crée du texte lié et l'enregistre dans une présentation :

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var textBox = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 150, 200, 50);
textBox.AddTextFrame("Aspose.Slides");

var textPortion = textBox.TextFrame.Paragraphs[0].Portions[0];
textPortion.PortionFormat.HyperlinkManager.SetExternalHyperlinkClick("https://www.aspose.com/");

presentation.Save("Hyperlink.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Quelle est la différence entre une zone de texte et un espace réservé de texte sur une diapositive maîtresse ou modèle ?**

Un [placeholder](/slides/fr/net/manage-placeholder/) peut hériter de sa position et de son formatage d'une [master slide](https://reference.aspose.com/slides/net/aspose.slides/masterslide/) ou d'une [layout slide](https://reference.aspose.com/slides/net/aspose.slides/layoutslide/). Une zone de texte ordinaire est une forme indépendante sur la diapositive où elle a été créée et n’acquiert pas le comportement de placeholder lorsque la mise en page change.

**Comment remplacer du texte sans modifier le texte dans les graphiques, tableaux ou SmartArt ?**

Limitez le parcours aux formes qui implémentent [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/), comme illustré dans l'exemple Mettre à jour le texte. Les graphiques, tableaux et SmartArt stockent le texte dans leurs propres modèles d'objets, ils ne sont donc pas modifiés par cette boucle.