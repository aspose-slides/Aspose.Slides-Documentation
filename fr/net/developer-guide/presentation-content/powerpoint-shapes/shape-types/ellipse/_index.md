---
title: Ellipse
type: docs
weight: 30
url: /fr/net/ellipse/
keywords: "Ellipse, forme PowerPoint, présentation PowerPoint, C#, Csharp, Aspose.Slides pour .NET"
description: "Créer une ellipse dans une présentation PowerPoint en C# ou .NET"
---


## **Créer une ellipse**
Dans ce sujet, nous allons présenter aux développeurs comment ajouter des formes d'ellipse à leurs diapositives en utilisant Aspose.Slides pour .NET. Aspose.Slides pour .NET fournit un ensemble d'API plus facile pour dessiner différents types de formes avec juste quelques lignes de code. Pour ajouter une simple ellipse à une diapositive sélectionnée de la présentation, veuillez suivre les étapes ci-dessous :

1. Créez une instance de la classe [Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation)
1. Obtenez la référence d'une diapositive en utilisant son index
1. Ajoutez une AutoShape de type Ellipse en utilisant la méthode AddAutoShape exposée par l'objet IShapes
1. Écrivez la présentation modifiée en tant que fichier PPTX

Dans l'exemple ci-dessous, nous avons ajouté une ellipse à la première diapositive.

```c#
// Instancier la classe Prseetation qui représente le PPTX
using (Presentation pres = new Presentation())
{

    // Obtenez la première diapositive
    ISlide sld = pres.Slides[0];

    // Ajouter une autoshape de type ellipse
    sld.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);

    // Écrire le fichier PPTX sur le disque
    pres.Save("EllipseShp1_out.pptx", SaveFormat.Pptx);
}
```



## **Créer une ellipse formatée**
Pour ajouter une ellipse mieux formatée à une diapositive, veuillez suivre les étapes ci-dessous :

1. Créez une instance de la classe [Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Obtenez la référence d'une diapositive en utilisant son index.
1. Ajoutez une AutoShape de type Ellipse en utilisant la méthode AddAutoShape exposée par l'objet IShapes.
1. Définissez le type de remplissage de l'ellipse sur Solide.
1. Définissez la couleur de l'ellipse en utilisant la propriété SolidFillColor.Color exposée par l'objet FillFormat associé à l'objet IShape.
1. Définissez la couleur des lignes de l'ellipse.
1. Définissez la largeur des lignes de l'ellipse.
1. Écrivez la présentation modifiée en tant que fichier PPTX.

Dans l'exemple ci-dessous, nous avons ajouté une ellipse formatée à la première diapositive de la présentation.

```c#
// Instancier la classe Prseetation qui représente le PPTX
using (Presentation pres = new Presentation())
{

    // Obtenez la première diapositive
    ISlide sld = pres.Slides[0];

    // Ajouter une autoshape de type ellipse
    IShape shp = sld.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);

    // Appliquer un certain formatage à la forme d'ellipse
    shp.FillFormat.FillType = FillType.Solid;
    shp.FillFormat.SolidFillColor.Color = Color.Chocolate;

    // Appliquer un certain formatage à la ligne de l'ellipse
    shp.LineFormat.FillFormat.FillType = FillType.Solid;
    shp.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
    shp.LineFormat.Width = 5;

    // Écrire le fichier PPTX sur le disque
    pres.Save("EllipseShp2_out.pptx", SaveFormat.Pptx);
}
```