---
title: Ajouter des ellipses aux présentations dans .NET
linktitle: Ellipse
type: docs
weight: 30
url: /fr/net/ellipse/
keywords:
- ellipse
- forme
- ajouter ellipse
- créer ellipse
- dessiner ellipse
- ellipse formatée
- PowerPoint
- présentation
- .NET
- C#
- Aspose.Slides
description: "Apprenez à créer, formater et manipuler des formes d'ellipse dans Aspose.Slides pour .NET sur des présentations PPT et PPTX—exemples de code C# inclus."
---

## **Créer une ellipse**
Dans ce sujet, nous présenterons aux développeurs la façon d’ajouter des formes d’ellipse à leurs diapositives en utilisant Aspose.Slides for .NET. Aspose.Slides for .NET fournit un ensemble d’API plus simple pour dessiner différents types de formes en seulement quelques lignes de code. Pour ajouter une ellipse simple à une diapositive sélectionnée de la présentation, veuillez suivre les étapes ci-dessous :

1. Créer une instance de la classe [Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation)
1. Obtenir la référence d’une diapositive en utilisant son Index
1. Ajouter une AutoShape de type Ellipse en utilisant la méthode AddAutoShape exposée par l’objet IShapes
1. Enregistrer la présentation modifiée en fichier PPTX

Dans l’exemple ci-dessous, nous avons ajouté une ellipse à la première diapositive.
```c#
// Instancier la classe Presentation qui représente le PPTX
using (Presentation pres = new Presentation())
{
    // Obtenir la première diapositive
    ISlide sld = pres.Slides[0];
    // Ajouter une forme auto de type ellipse
    sld.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);
    // Enregistrer le fichier PPTX sur le disque
    pres.Save("EllipseShp1_out.pptx", SaveFormat.Pptx);
}
```


## **Créer une ellipse formatée**
Pour ajouter une ellipse mieux formatée à une diapositive, veuillez suivre les étapes ci-dessous :

1. Créer une instance de la classe [Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Obtenir la référence d’une diapositive en utilisant son Index.
1. Ajouter une AutoShape de type Ellipse en utilisant la méthode AddAutoShape exposée par l’objet IShapes.
1. Définir le type de remplissage de l’ellipse sur Solid.
1. Définir la couleur de l’ellipse en utilisant la propriété SolidFillColor.Color exposée par l’objet FillFormat associé à l’objet IShape.
1. Définir la couleur des contours de l’ellipse.
1. Définir la largeur des contours de l’ellipse.
1. Enregistrer la présentation modifiée en fichier PPTX.

Dans l’exemple ci-dessous, nous avons ajouté une ellipse formatée à la première diapositive de la présentation.
```c#
// Instancier la classe Presentation qui représente le PPTX
using (Presentation pres = new Presentation())
{

    // Obtenir la première diapositive
    ISlide sld = pres.Slides[0];

    // Ajouter une AutoShape de type ellipse
    IShape shp = sld.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);

    // Appliquer un formatage à la forme ellipse
    shp.FillFormat.FillType = FillType.Solid;
    shp.FillFormat.SolidFillColor.Color = Color.Chocolate;

    // Appliquer un formatage à la ligne de l'ellipse
    shp.LineFormat.FillFormat.FillType = FillType.Solid;
    shp.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
    shp.LineFormat.Width = 5;

    //Write le fichier PPTX sur le disque
    pres.Save("EllipseShp2_out.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**Comment définir la position exacte et la taille d’une ellipse par rapport aux unités de la diapositive ?**

Les coordonnées et les tailles sont généralement spécifiées **en points**. Pour obtenir des résultats prévisibles, basez vos calculs sur la taille de la diapositive et convertissez les millimètres ou pouces requis en points avant d’attribuer les valeurs.

**Comment placer une ellipse au-dessus ou en dessous d’autres objets (contrôler l’ordre d’empilement) ?**

Ajustez l’ordre de dessin de l’objet en le mettant au premier plan ou en l’envoyant à l’arrière-plan. Cela permet à l’ellipse de recouvrir d’autres objets ou de révéler ceux qui se trouvent en dessous.

**Comment animer l’apparition ou l’accentuation d’une ellipse ?**

[Appliquer](/slides/fr/net/shape-animation/) des effets d’entrée, d’accentuation ou de sortie à la forme, et configurer les déclencheurs et le timing pour orchestrer quand et comment l’animation se joue.