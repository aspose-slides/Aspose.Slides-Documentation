---
title: Obtenir les limites des paragraphes à partir de présentations en .NET
linktitle: Limites de paragraphe
type: docs
weight: 43
url: /fr/net/paragraph-bounds/
keywords:
- limites de paragraphe
- coordonnée de paragraphe
- taille de paragraphe
- cadre de texte
- PowerPoint
- présentation
- .NET
- C#
- Aspose.Slides
description: "Apprenez comment récupérer les limites des paragraphes dans Aspose.Slides pour .NET afin d'optimiser le positionnement du texte dans les présentations PowerPoint."
---
## **Vue d'ensemble**

Cet article explique comment obtenir les limites, la taille et les coordonnées des paragraphes dans Aspose.Slides. Il montre comment récupérer un rectangle de paragraphe à partir d'un [ITextFrame](https://reference.aspose.com/slides/fr/net/aspose.slides/itextframe/) en utilisant [IParagraph.GetRect](https://reference.aspose.com/slides/fr/net/aspose.slides/iparagraph/getrect/), comment obtenir les coordonnées d'un paragraphe à l'intérieur d'un cadre de texte d'une cellule de tableau, et met en évidence des détails importants tels que les unités de mesure, l'effet du retour à la ligne sur les limites, la conversion en pixels et les valeurs de formatage effectif du paragraphe.

## **Obtenir les coordonnées rectangulaires d'un paragraphe**

Utilisez [IParagraph.GetRect](https://reference.aspose.com/slides/fr/net/aspose.slides/iparagraph/getrect/) pour obtenir le rectangle englobant d'un paragraphe.

```csharp
using var presentation = new Presentation("Shapes.pptx");
var slide = presentation.Slides[0];
var shape = (IAutoShape)slide.Shapes[0];
var paragraph = shape.TextFrame.Paragraphs[0];
var rectangle = paragraph.GetRect();
```

## **Obtenir la taille d'un paragraphe à l'intérieur d'un cadre de texte d'une cellule de tableau**

Pour obtenir la taille et les coordonnées d'un [IParagraph](https://reference.aspose.com/slides/fr/net/aspose.slides/iparagraph/) dans un cadre de texte d'une cellule de tableau, utilisez [IParagraph.GetRect](https://reference.aspose.com/slides/fr/net/aspose.slides/iparagraph/getrect/). Le rectangle retourné est relatif au cadre de texte de la cellule de tableau, il faut donc ajouter la position du tableau et le décalage de la cellule lorsque vous avez besoin des coordonnées au niveau de la diapositive.

L'exemple suivant récupère les limites du paragraphe à l'intérieur d'une cellule de tableau et dessine des rectangles sur la diapositive pour visualiser ces limites :

```csharp
using var presentation = new Presentation("source.pptx");
var slide = presentation.Slides[0];
var table = (ITable)slide.Shapes[0];
var cell = table.Rows[1][1];

var cellX = table.X + cell.OffsetX;
var cellY = table.Y + cell.OffsetY;

foreach (var paragraph in cell.TextFrame.Paragraphs)
{
    if (string.IsNullOrEmpty(paragraph.Text))
        continue;

    var paragraphRectangle = paragraph.GetRect();
    var paragraphRectangleX = paragraphRectangle.X + (float)cellX;
    var paragraphRectangleY = paragraphRectangle.Y + (float)cellY;

    var paragraphBoundsShape = presentation.Slides[0].Shapes.AddAutoShape(
        ShapeType.Rectangle,
        paragraphRectangleX,
        paragraphRectangleY,
        paragraphRectangle.Width,
        paragraphRectangle.Height);

    paragraphBoundsShape.FillFormat.FillType = FillType.NoFill;
    paragraphBoundsShape.LineFormat.FillFormat.SolidFillColor.Color = Color.Yellow;
    paragraphBoundsShape.LineFormat.FillFormat.FillType = FillType.Solid;
}

presentation.Save("output.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Dans quelles unités les coordonnées du paragraphe sont‑elles mesurées ?**  
Elles sont mesurées en points, où 1 pouce équivaut à 72 points. Cela s'applique à toutes les coordonnées et dimensions sur la diapositive.

**Le retour à la ligne affecte‑t‑il les limites d'un paragraphe ?**  
Oui. Si [TextFrameFormat.WrapText](https://reference.aspose.com/slides/fr/net/aspose.slides/textframeformat/wraptext/) est activé pour le [ITextFrame](https://reference.aspose.com/slides/fr/net/aspose.slides/itextframe/), le texte se coupe pour s'adapter à la largeur de la zone, ce qui modifie les limites réelles du paragraphe.

**Les coordonnées du paragraphe peuvent‑elles être mappées de façon fiable en pixels dans l'image exportée ?**  
Oui. Convertissez les points en pixels en utilisant cette formule : pixels = points × (DPI / 72). Le résultat dépend du DPI choisi pour le rendu ou l'exportation.

**Comment obtenir les paramètres de formatage « effectif » du paragraphe, en tenant compte de l'héritage du style ?**  
Utilisez la [structure de données de formatage effectif du paragraphe](/slides/fr/net/shape-effective-properties/) ; elle renvoie les valeurs consolidées finales pour les retraits, l'espacement, le retour à la ligne, le sens RTL, etc.