---
title: Paragraphe
type: docs
weight: 60
url: /fr/net/paragraph/
keywords: "Paragraphe, portion, coordonnées de paragraphe, coordonnées de portion, présentation PowerPoint, C#, Csharp, Aspose.Slides pour .NET"
description: "Paragraphe et portion dans la présentation PowerPoint en C# ou .NET"
---

## **Obtenir les coordonnées de paragraphe et de portion dans TextFrame**
En utilisant Aspose.Slides pour .NET, les développeurs peuvent désormais obtenir les coordonnées rectangulaires pour les Paragraphes à l'intérieur de la collection de paragraphes de TextFrame. Cela vous permet également d'obtenir les coordonnées de la portion à l'intérieur de la collection de portions d'un paragraphe. Dans ce sujet, nous allons démontrer, à l'aide d'un exemple, comment obtenir les coordonnées rectangulaires pour un paragraphe ainsi que la position de la portion à l'intérieur d'un paragraphe.

## **Obtenir les coordonnées rectangulaires du paragraphe**
La nouvelle méthode **GetRect()** a été ajoutée. Elle permet d'obtenir le rectangle des limites du paragraphe.

```c#
// Instancier un objet Presentation qui représente un fichier de présentation
using (Presentation presentation = new Presentation("Shapes.pptx"))
{
    IAutoShape shape = (IAutoShape)presentation.Slides[0].Shapes[0];
        var textFrame = (ITextFrame)shape.TextFrame;
        RectangleF rect = ((Paragraph)textFrame.Paragraphs[0]).GetRect();
}
```

## **Obtenir la taille du paragraphe et de la portion dans le cadre de texte de la cellule du tableau** ##

Pour obtenir la taille et les coordonnées de la [Portion](https://reference.aspose.com/slides/net/aspose.slides/portion) ou du [Paragraphe](https://reference.aspose.com/slides/net/aspose.slides/paragraph) dans le cadre de texte d'une cellule de tableau, vous pouvez utiliser les méthodes [IPortion.GetRect](https://reference.aspose.com/slides/net/aspose.slides/iportion/methods/getrect) et [IParagraph.GetRect](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/methods/getrect).

Ce code d'exemple démontre l'opération décrite :

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