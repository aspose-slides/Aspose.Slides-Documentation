---
title: Ligne
type: docs
weight: 50
url: /fr/net/Ligne/
keywords: "Ligne, forme PowerPoint, présentation PowerPoint, C#, Csharp, Aspose.Slides pour .NET"
description: "Ajouter une ligne dans une présentation PowerPoint en C# ou .NET"
---

Aspose.Slides pour .NET prend en charge l'ajout de différentes sortes de formes aux diapositives. Dans ce sujet, nous allons commencer à travailler avec des formes en ajoutant des lignes aux diapositives. En utilisant Aspose.Slides pour .NET, les développeurs peuvent non seulement créer des lignes simples, mais aussi dessiner des lignes plus élaborées sur les diapositives.
## **Créer une Ligne Simple**
Pour ajouter une ligne simple à une diapositive sélectionnée de la présentation, veuillez suivre les étapes ci-dessous :

- Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
- Obtenez la référence d'une diapositive en utilisant son Index.
- Ajoutez une AutoShape de type Ligne en utilisant la méthode [AddAutoShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/methods/addautoshape/index) exposée par l'objet Shapes.
- Écrivez la présentation modifiée en tant que fichier PPTX.

Dans l'exemple ci-dessous, nous avons ajouté une ligne à la première diapositive de la présentation.

```c#
// Instancier la classe PresentationEx qui représente le fichier PPTX
using (Presentation pres = new Presentation())
{
    // Obtenir la première diapositive
    ISlide sld = pres.Slides[0];

    // Ajouter une autoshape de type ligne
    sld.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

    //Écrire le PPTX sur le disque
    pres.Save("LigneForme1_sortie.pptx", SaveFormat.Pptx);
}
```


## **Créer une Ligne en Forme de Flèche**
Aspose.Slides pour .NET permet également aux développeurs de configurer certaines propriétés de la ligne pour la rendre plus attrayante. Essayons de configurer quelques propriétés d'une ligne pour lui donner l'apparence d'une flèche. Veuillez suivre les étapes ci-dessous pour ce faire :

- Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
- Obtenez la référence d'une diapositive en utilisant son Index.
- Ajoutez une AutoShape de type Ligne en utilisant la méthode AddAutoShape exposée par l'objet Shapes.
- Définissez le Style de Ligne sur l'un des styles proposés par Aspose.Slides pour .NET.
- Définissez la Largeur de la ligne.
- Définissez le [Style de Tiret](https://reference.aspose.com/slides/net/aspose.slides/linedashstyle) de la ligne sur l'un des styles proposés par Aspose.Slides pour .NET.
- Définissez le [Style de Pointe de Flèche](https://reference.aspose.com/slides/net/aspose.slides/linearrowheadstyle) et la Longueur du point de départ de la ligne.
- Définissez le Style de Pointe de Flèche et la Longueur du point d'arrivée de la ligne.
- Écrivez la présentation modifiée en tant que fichier PPTX.

```c#
// Instancier la classe PresentationEx qui représente le fichier PPTX
using (Presentation pres = new Presentation())
{

    // Obtenir la première diapositive
    ISlide sld = pres.Slides[0];

    // Ajouter une autoshape de type ligne
    IAutoShape shp = sld.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

    // Appliquer un formatage à la ligne
    shp.LineFormat.Style = LineStyle.ThickBetweenThin;
    shp.LineFormat.Width = 10;

    shp.LineFormat.DashStyle = LineDashStyle.DashDot;

    shp.LineFormat.BeginArrowheadLength = LineArrowheadLength.Short;
    shp.LineFormat.BeginArrowheadStyle = LineArrowheadStyle.Oval;

    shp.LineFormat.EndArrowheadLength = LineArrowheadLength.Long;
    shp.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;

    shp.LineFormat.FillFormat.FillType = FillType.Solid;
    shp.LineFormat.FillFormat.SolidFillColor.Color = Color.Maroon;

    //Écrire le PPTX sur le disque
    pres.Save("LigneForme2_sortie.pptx", SaveFormat.Pptx);
}
```