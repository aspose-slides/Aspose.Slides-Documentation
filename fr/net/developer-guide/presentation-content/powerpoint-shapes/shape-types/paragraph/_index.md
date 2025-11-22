---
title: Paragraphe
type: docs
weight: 60
url: /fr/net/paragraph/
keywords: "Paragraphe, portion, coordonnée de paragraphe, coordonnée de portion, présentation PowerPoint, C#, Csharp, Aspose.Slides for .NET"
description: "Paragraphe et portion dans une présentation PowerPoint en C# ou .NET"
---

## **Obtenir les coordonnées du paragraphe et de la portion dans TextFrame**
En utilisant Aspose.Slides for .NET, les développeurs peuvent désormais obtenir les coordonnées rectangulaires du Paragraph à l’intérieur de la collection de paragraphes d’un TextFrame. Cela permet également d’obtenir les coordonnées d’une portion à l’intérieur de la collection de portions d’un paragraphe. Dans cet article, nous allons montrer, à l’aide d’un exemple, comment obtenir les coordonnées rectangulaires d’un paragraphe ainsi que la position d’une portion à l’intérieur d’un paragraphe.

## **Obtenir les coordonnées rectangulaires du Paragraph**
La nouvelle méthode **GetRect()** a été ajoutée. Elle permet d’obtenir le rectangle des limites du paragraphe.
```c#
// Instanciez un objet Presentation qui représente un fichier de présentation
using (Presentation presentation = new Presentation("Shapes.pptx"))
{
    IAutoShape shape = (IAutoShape)presentation.Slides[0].Shapes[0];
        var textFrame = (ITextFrame)shape.TextFrame;
        RectangleF rect = ((Paragraph)textFrame.Paragraphs[0]).GetRect();
}
```


## **Obtenir la taille du paragraphe et de la portion dans le TextFrame d’une cellule de tableau**
Pour obtenir la taille et les coordonnées de la [Portion](https://reference.aspose.com/slides/net/aspose.slides/portion) ou du [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph) dans un TextFrame de cellule de tableau, vous pouvez utiliser les méthodes [IPortion.GetRect](https://reference.aspose.com/slides/net/aspose.slides/iportion/methods/getrect) et [IParagraph.GetRect](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/methods/getrect).

Ce code d’exemple démontre l’opération décrite :
```csharp
using (Presentation pres = new Presentation("source.pptx"))
{
    Table tbl = pres.Slides[0].Shapes[0] as Table;

    ICell cell = tbl.Rows[1][1];


    double x = tbl.X + tbl.Rows[1][1].OffsetX;
    double y = tbl.Y + tbl.Rows[1][1].OffsetY;

    foreach (IParagraph para in cell.TextFrame.Paragraphs)
    {
        if (para.Text == "")
            continue;

        RectangleF rect = para.GetRect();
        IAutoShape shape =
            pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle,
                rect.X + (float)x, rect.Y + (float)y, rect.Width, rect.Height);

        shape.FillFormat.FillType = FillType.NoFill;
        shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Yellow;
        shape.LineFormat.FillFormat.FillType = FillType.Solid;


        foreach (IPortion portion in para.Portions)
        {
            if (portion.Text.Contains("0"))
            {
                rect = portion.GetRect();
                shape =
                    pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle,
                        rect.X + (float)x, rect.Y + (float)y, rect.Width, rect.Height);

                shape.FillFormat.FillType = FillType.NoFill;
            }
        }
    }
}
```


## **FAQ**

**Dans quelles unités les coordonnées d’un paragraphe et des portions de texte sont‑elles renvoyées ?**  
En points, où 1 pouce = 72 points. Cela s’applique à toutes les coordonnées et dimensions de la diapositive.

**Le retour à la ligne affecte‑t‑il les limites du paragraphe ?**  
Oui. Si le [wrapping](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/wraptext/) est activé dans le [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/), le texte se coupe pour s’adapter à la largeur de la zone, ce qui modifie les limites réelles du paragraphe.

**Les coordonnées du paragraphe peuvent‑elles être converties de façon fiable en pixels dans l’image exportée ?**  
Oui. Convertissez les points en pixels avec : pixels = points × (DPI / 72). Le résultat dépend du DPI choisi pour le rendu/l’exportation.

**Comment obtenir les paramètres de mise en forme « effectifs » du paragraphe, en tenant compte de l’héritage du style ?**  
Utilisez la [structure de données de mise en forme effective du paragraphe](/slides/fr/net/shape-effective-properties/) ; elle renvoie les valeurs finales consolidées pour les retraits, l’espacement, le wrapping, le RTL et bien plus encore.