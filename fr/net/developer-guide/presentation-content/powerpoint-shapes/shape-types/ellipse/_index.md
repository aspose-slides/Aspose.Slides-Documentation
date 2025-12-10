---
title: Ajouter des ellipses aux présentations en .NET
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
description: "Apprenez comment créer, formater et manipuler des formes d'ellipse dans Aspose.Slides pour .NET dans les présentations PPT et PPTX—exemples de code C# inclus."
---

## **Créer une ellipse**
Dans ce sujet, nous allons présenter aux développeurs comment ajouter des formes d’ellipse à leurs diapositives en utilisant Aspose.Slides for .NET. Aspose.Slides for .NET fournit un ensemble d’API simplifiées pour dessiner différents types de formes en seulement quelques lignes de code. Pour ajouter une ellipse simple à une diapositive sélectionnée de la présentation, suivez les étapes ci‑dessous :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)
2. Obtenez la référence d’une diapositive en utilisant son Index
3. Ajoutez une AutoShape de type Ellipse en utilisant la méthode AddAutoShape exposée par l’objet IShapes
4. Enregistrez la présentation modifiée au format PPTX

Dans l’exemple ci‑dessous, nous avons ajouté une ellipse à la première diapositive.
```c#
// Instancier la classe Presentation qui représente le PPTX
using (Presentation pres = new Presentation())
{

    // Obtenir la première diapositive
    ISlide sld = pres.Slides[0];

    // Ajouter une autoshape de type ellipse
    sld.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);

    //Write le fichier PPTX sur le disque
    pres.Save("EllipseShp1_out.pptx", SaveFormat.Pptx);
}
```


## **Créer une ellipse formatée**
Pour ajouter une ellipse mieux formatée à une diapositive, suivez les étapes ci‑dessous :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Obtenez la référence d’une diapositive en utilisant son Index.
3. Ajoutez une AutoShape de type Ellipse en utilisant la méthode AddAutoShape exposée par l’objet IShapes.
4. Définissez le type de remplissage de l’ellipse sur Solid.
5. Définissez la couleur de l’ellipse en utilisant la propriété SolidFillColor.Color exposée par l’objet FillFormat associé à l’objet IShape.
6. Définissez la couleur des lignes de l’ellipse.
7. Définissez la largeur des lignes de l’ellipse.
8. Enregistrez la présentation modifiée au format PPTX.

Dans l’exemple ci‑dessous, nous avons ajouté une ellipse formatée à la première diapositive de la présentation.
```c#
// Instancier la classe Presentation qui représente le PPTX
using (Presentation pres = new Presentation())
{

    // Obtenir la première diapositive
    ISlide sld = pres.Slides[0];

    // Ajouter une autoshape de type ellipse
    IShape shp = sld.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);

    // Appliquer un formatage à la forme ellipse
    shp.FillFormat.FillType = FillType.Solid;
    shp.FillFormat.SolidFillColor.Color = Color.Chocolate;

    // Appliquer un formatage à la ligne de l'ellipse
    shp.LineFormat.FillFormat.FillType = FillType.Solid;
    shp.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
    shp.LineFormat.Width = 5;

    // Enregistrer le fichier PPTX sur le disque
    pres.Save("EllipseShp2_out.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**Comment définir la position exacte et la taille d’une ellipse par rapport aux unités de la diapositive ?**

Les coordonnées et les dimensions sont généralement spécifiées **en points**. Pour obtenir des résultats prévisibles, basez vos calculs sur la taille de la diapositive et convertissez les millimètres ou pouces requis en points avant d’attribuer les valeurs.

**Comment placer une ellipse au‑dessus ou en dessous d’autres objets (contrôler l’ordre d’empilement) ?**

Modifiez l’ordre de dessin de l’objet en le ramenant à l’avant ou en l’envoyant à l’arrière. Cela permet à l’ellipse de recouvrir d’autres objets ou de révéler ceux qui se trouvent en dessous.

**Comment animer l’apparition ou l’accentuation d’une ellipse ?**

[Appliquer](/slides/fr/net/shape-animation/) des effets d’entrée, d’accentuation ou de sortie à la forme, et configurer les déclencheurs et le chronométrage pour orchestrer quand et comment l’animation se déroule.