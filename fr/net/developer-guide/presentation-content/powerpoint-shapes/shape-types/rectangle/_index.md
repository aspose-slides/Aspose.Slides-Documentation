---
title: Rectangle
type: docs
weight: 80
url: /net/rectangle/
keywords: "Créer rectangle, forme PowerPoint, présentation PowerPoint, C#, Csharp, Aspose.Slides pour .NET"
description: "Créer un rectangle dans une présentation PowerPoint en C# ou .NET"
---


## **Créer un rectangle simple**
Comme les sujets précédents, celui-ci porte également sur l'ajout d'une forme et cette fois la forme dont nous allons parler est le rectangle. Dans ce sujet, nous avons décrit comment les développeurs peuvent ajouter des rectangles simples ou formatés à leurs diapositives en utilisant Aspose.Slides pour .NET. Pour ajouter un rectangle simple à une diapositive sélectionnée de la présentation, veuillez suivre les étapes ci-dessous :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Obtenez la référence d'une diapositive en utilisant son index.
1. Ajoutez une IAutoShape de type Rectangle en utilisant la méthode AddAutoShape exposée par l'objet IShapes.
1. Écrivez la présentation modifiée en tant que fichier PPTX.

Dans l'exemple donné ci-dessous, nous avons ajouté un rectangle simple à la première diapositive de la présentation.

```c#
// Instancier la classe Prseetation qui représente le PPTX
using (Presentation pres = new Presentation())
{

    // Obtenez la première diapositive
    ISlide sld = pres.Slides[0];

    // Ajoutez une autoshape de type rectangle
    sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    //Écrire le fichier PPTX sur le disque
    pres.Save("RectShp1_out.pptx", SaveFormat.Pptx);
}
```


## **Créer un rectangle formaté**
Pour ajouter un rectangle formaté à une diapositive, veuillez suivre les étapes ci-dessous :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Obtenez la référence d'une diapositive en utilisant son index.
1. Ajoutez une IAutoShape de type Rectangle en utilisant la méthode AddAutoShape exposée par l'objet IShapes.
1. Définissez le type de remplissage du rectangle sur solide.
1. Définissez la couleur du rectangle en utilisant la propriété SolidFillColor.Color exposée par l'objet FillFormat associé à l'objet IShape.
1. Définissez la couleur des lignes du rectangle.
1. Définissez la largeur des lignes du rectangle.
1. Écrivez la présentation modifiée en tant que fichier PPTX.
   Les étapes ci-dessus sont mises en œuvre dans l'exemple donné ci-dessous.

```c#
// Instancier la classe Prseetation qui représente le PPTX
using (Presentation pres = new Presentation())
{

    // Obtenez la première diapositive
    ISlide sld = pres.Slides[0];

    // Ajoutez une autoshape de type rectangle
    IShape shp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    // Appliquez un peu de formatage à la forme rectangle
    shp.FillFormat.FillType = FillType.Solid;
    shp.FillFormat.SolidFillColor.Color = Color.Chocolate;

    // Appliquez un peu de formatage à la ligne du rectangle
    shp.LineFormat.FillFormat.FillType = FillType.Solid;
    shp.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
    shp.LineFormat.Width = 5;

    //Écrire le fichier PPTX sur le disque
    pres.Save("RectShp2_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```