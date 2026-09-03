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

Dans Aspose.Slides for .NET, le texte des diapositives est stocké dans des cadres de texte qui appartiennent aux formes. L'interface [IAutoShape](https://reference.aspose.com/slides/fr/net/aspose.slides/iautoshape/) représente la forme la plus courante contenant du texte et expose son texte via la propriété [IAutoShape.TextFrame](https://reference.aspose.com/slides/fr/net/aspose.slides/iautoshape/textframe/).

{{% alert color="info" title="Note" %}}
Chaque forme auto implémente [IShape](https://reference.aspose.com/slides/fr/net/aspose.slides/ishape/), mais toutes les formes ne sont pas des formes auto ou ne prennent pas en charge un cadre de texte. Lors du traitement d'une présentation existante, vérifiez qu'une forme implémente `IAutoShape` avant d'accéder à son texte.
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

Les coordonnées et les dimensions passées à [IShapeCollection.AddAutoShape](https://reference.aspose.com/slides/fr/net/aspose.slides/ishapecollection/addautoshape/) sont exprimées en points. [IAutoShape.AddTextFrame](https://reference.aspose.com/slides/fr/net/aspose.slides/iautoshape/addtextframe/) initialise le cadre de texte avec le texte fourni.

## **Vérifier la forme d'une zone de texte**

Utilisez la propriété [AutoShape.IsTextBox](https://reference.aspose.com/slides/fr/net/aspose.slides/autoshape/istextbox/) pour déterminer si une forme auto est traitée comme une zone de texte. Cela est utile lorsqu'une présentation contient à la fois des formes auto contenant du texte et des formes purement graphiques.

![Une zone de texte et une forme](istextbox.png)

L'exemple suivant inspecte chaque forme auto d'une présentation :

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

Une forme auto nouvellement ajoutée n'est pas considérée comme une zone de texte tant qu'elle ne contient pas de texte non vide. Vous pouvez fournir ce texte via [IAutoShape.AddTextFrame](https://reference.aspose.com/slides/fr/net/aspose.slides/iautoshape/addtextframe/) ou [ITextFrame.Text](https://reference.aspose.com/slides/fr/net/aspose.slides/itextframe/text/). Ajouter ou affecter une chaîne vide laisse `IsTextBox` à `false` :

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

Le code générique de traitement de texte peut recevoir un [ITextFrame](https://reference.aspose.com/slides/fr/net/aspose.slides/itextframe/) sans connaître l'objet de présentation qui le contient. Utilisez la propriété en lecture seule [ITextFrame.ParentShape](https://reference.aspose.com/slides/fr/net/aspose.slides/itextframe/parentshape/) pour revenir à son [IShape](https://reference.aspose.com/slides/fr/net/aspose.slides/ishape/) propriétaire.

Pour un cadre de texte appartenant à une forme auto ou à une autre forme contenant du texte, `ParentShape` contient le propriétaire et [ITextFrame.ParentCell](https://reference.aspose.com/slides/fr/net/aspose.slides/itextframe/parentcell/) est `null`. Vérifiez la valeur retournée avant de l'utiliser. Pour identifier à la fois les propriétaires de forme et de cellule de tableau, y compris les formes associées aux nœuds SmartArt, consultez [Search and Replace Text](/slides/fr/net/search-and-replace-text/).

## **Ajouter des colonnes à une zone de texte**

La propriété [ITextFrameFormat.ColumnCount](https://reference.aspose.com/slides/fr/net/aspose.slides/itextframeformat/columncount/) divise le cadre de texte en colonnes, tandis que [ITextFrameFormat.ColumnSpacing](https://reference.aspose.com/slides/fr/net/aspose.slides/itextframeformat/columnspacing/) définit l'écart entre les colonnes en points. Les deux paramètres appartiennent à [ITextFrameFormat](https://reference.aspose.com/slides/fr/net/aspose.slides/itextframeformat/) et peuvent être modifiés via le cadre de texte d'une zone de texte existante. Le texte se répartit entre les colonnes à l'intérieur de la même forme ; il ne continue pas dans une autre forme.

L'exemple suivant crée une zone de texte à trois colonnes avec 10 points entre les colonnes, enregistre la présentation et lit les paramètres stockés à partir du fichier de sortie :

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

## **Extraire le texte des colonnes individuelles**

Utilisez [TextFrame.SplitTextByColumns](https://reference.aspose.com/slides/fr/net/aspose.slides/textframe/splittextbycolumns/) pour récupérer le texte attribué à chaque colonne visuelle d'un cadre de texte existant. La méthode renvoie une chaîne pour chaque colonne, dans l'ordre de lecture basé sur les colonnes. Un cadre de texte à une seule colonne produit un tableau contenant un seul élément, et une colonne vide est représentée par une chaîne vide. Les chaînes contiennent uniquement du texte brut ; le formatage au niveau des portions n’est pas conservé.

Cela est utile lorsque vous devez :

- Extraire le texte tout en préservant son ordre de lecture par colonne.  
- Indexer ou comparer le contenu des diapositives multi‑colonnes.  
- Exporter chaque colonne vers un fichier distinct, un champ de base de données ou une autre destination.  
- Inspecter comment le texte est redistribué après modification de [ITextFrameFormat.ColumnCount](https://reference.aspose.com/slides/fr/net/aspose.slides/itextframeformat/columncount/), [ITextFrameFormat.ColumnSpacing](https://reference.aspose.com/slides/fr/net/aspose.slides/itextframeformat/columnspacing/), de la police ou de la taille du cadre de texte.

La méthode indique le texte distribué au sein du [ITextFrame] actuel ; elle ne fait pas couler automatiquement le texte entre des formes ou zones de texte distinctes. La distribution en colonnes peut dépendre des polices disponibles et d’autres paramètres de mise en page du texte, assurez‑vous donc que les polices requises sont présentes lorsque des résultats cohérents sont importants.

L'exemple suivant charge une présentation, trouve la première forme auto à colonnes multiples avec un cadre de texte, lit son nombre de colonnes configuré et écrit le texte de chaque colonne dans un fichier séparé. Les formes ne fournissant pas de cadre de texte sont ignorées.

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

Pour mettre à jour le texte dans l’ensemble d’une présentation, parcourez les diapositives et les formes, sélectionnez les formes auto, puis modifiez leurs portions de texte. Travailler au niveau des portions vous permet de changer à la fois le texte et le formatage des caractères.

L'exemple suivant remplace chaque occurrence de `years` par `months` dans le texte des formes auto et met chaque portion affectée en gras :

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

Ce parcours ne met à jour le texte que dans les formes auto. Le texte stocké dans les tableaux, graphiques, SmartArt ou formes groupées nécessite un parcours des collections propres à ces objets.

## **Ajouter une zone de texte avec un hyperlien**

Un hyperlien peut être attribué à une portion de texte précise, de sorte que seul ce texte agit comme lien cliquable. Utilisez [IHyperlinkManager.SetExternalHyperlinkClick](https://reference.aspose.com/slides/fr/net/aspose.slides/ihyperlinkmanager/setexternalhyperlinkclick/) pour associer la portion à une URL externe.

L'exemple suivant crée du texte lié et l’enregistre dans une présentation :

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

**Quelle est la différence entre une zone de texte et un espace réservé de texte sur une diapositive maître ou de mise en page ?**

Un [placeholder](/slides/fr/net/manage-placeholder/) peut hériter de sa position et de son formatage d’une [master slide](https://reference.aspose.com/slides/fr/net/aspose.slides/masterslide/) ou d’une [layout slide](https://reference.aspose.com/slides/fr/net/aspose.slides/layoutslide/). Une zone de texte ordinaire est une forme indépendante sur la diapositive où elle a été créée et n’acquiert pas le comportement d’espace réservé lorsque la mise en page change.

**Comment remplacer du texte sans modifier le texte dans les graphiques, les tableaux ou le SmartArt ?**

Limitez le parcours aux formes qui implémentent [IAutoShape](https://reference.aspose.com/slides/fr/net/aspose.slides/iautoshape/), comme illustré dans l’exemple Mettre à jour le texte. Les graphiques, tableaux et SmartArt stockent le texte dans leurs propres modèles d’objets, ils ne sont donc pas modifiés par cette boucle.