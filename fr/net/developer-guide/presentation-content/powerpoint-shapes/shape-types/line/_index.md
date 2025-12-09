---
title: Ajouter des formes de ligne aux présentations en .NET
linktitle: Ligne
type: docs
weight: 50
url: /fr/net/Line/
keywords:
- ligne
- créer une ligne
- ajouter une ligne
- ligne simple
- configurer une ligne
- personnaliser une ligne
- style tireté
- tête de flèche
- PowerPoint
- présentation
- .NET
- C#
- Aspose.Slides
description: "Apprenez à manipuler le format des lignes dans les présentations PowerPoint avec Aspose.Slides pour .NET. Découvrez les propriétés, les méthodes et des exemples."
---

Aspose.Slides for .NET prend en charge l'ajout de différents types de formes aux diapositives. Dans ce sujet, nous allons commencer à travailler avec les formes en ajoutant des lignes aux diapositives. Avec Aspose.Slides for .NET, les développeurs peuvent non seulement créer des lignes simples, mais aussi dessiner des lignes décoratives sur les diapositives.
## **Créer une ligne simple**
Pour ajouter une ligne simple à une diapositive sélectionnée de la présentation, veuillez suivre les étapes ci-dessous :

- Créer une instance de la classe [Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation).
- Obtenez la référence d’une diapositive en utilisant son indice.
- Ajoutez un AutoShape de type Ligne en utilisant la méthode [AddAutoShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/methods/addautoshape/index) exposée par l’objet Shapes.
- Enregistrez la présentation modifiée au format PPTX.

Dans l'exemple ci‑dessous, nous avons ajouté une ligne à la première diapositive de la présentation.
```c#
 // Instancie la classe PresentationEx qui représente le fichier PPTX
 using (Presentation pres = new Presentation())
 {
     // Obtient la première diapositive
     ISlide sld = pres.Slides[0];
 
     // Ajoute un autoshape de type ligne
     sld.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);
 
     //Enregistre le PPTX sur le disque
     pres.Save("LineShape1_out.pptx", SaveFormat.Pptx);
 }
```


## **Créer une ligne en forme de flèche**
Aspose.Slides for .NET permet également aux développeurs de configurer certaines propriétés de la ligne pour la rendre plus attrayante. Essayons de configurer quelques propriétés d’une ligne pour qu’elle ressemble à une flèche. Veuillez suivre les étapes ci‑dessous pour ce faire :

- Créer une instance de la classe [Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation)class[](http://www.aspose.com/api/net/slides/aspose.slides/)[](http://www.aspose.com/api/net/slides/aspose.slides/).
- Obtenez la référence d’une diapositive en utilisant son indice.
- Ajoutez un AutoShape de type Ligne en utilisant la méthode AddAutoShape exposée par l’objet Shapes.
- Définissez le style de ligne sur l’un des styles proposés par Aspose.Slides for .NET.
- Définissez la largeur de la ligne.
- Définissez le [Dash Style](https://reference.aspose.com/slides/net/aspose.slides/linedashstyle) de la ligne sur l’un des styles proposés par Aspose.Slides for .NET.
- Définissez le [Arrow Head Style](https://reference.aspose.com/slides/net/aspose.slides/linearrowheadstyle) et la longueur du point de départ de la ligne.
- Définissez le style de tête de flèche et la longueur du point d’arrivée de la ligne.
- Enregistrez la présentation modifiée au format PPTX.
```c#
// Instancie la classe PresentationEx qui représente le fichier PPTX
using (Presentation pres = new Presentation())
{

    // Obtenir la première diapositive
    ISlide sld = pres.Slides[0];

    // Ajouter un autoshape de type ligne
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

    // Enregistrer le PPTX sur le disque
    pres.Save("LineShape2_out.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**Puis-je convertir une ligne ordinaire en connecteur afin qu’elle se « aimante » aux formes ?**

Non. Une ligne ordinaire (un [AutoShape](https://reference.aspose.com/slides/net/aspose.slides/autoshape/) de type [Line](https://reference.aspose.com/slides/net/aspose.slides/shapetype/)) ne devient pas automatiquement un connecteur. Pour qu’elle s’aimante aux formes, utilisez le type dédié [Connector](https://reference.aspose.com/slides/net/aspose.slides/connector/) et les [corresponding APIs](/slides/fr/net/connector/) pour les connexions.

**Que faire si les propriétés d’une ligne sont héritées du thème et qu’il est difficile de déterminer les valeurs finales ?**

[Lisez les propriétés effectives](/slides/fr/net/shape-effective-properties/) via les interfaces [ILineFormatEffectiveData](https://reference.aspose.com/slides/net/aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/net/aspose.slides/ilinefillformateffectivedata/) — celles‑ci tiennent déjà compte de l’héritage et des styles du thème.

**Puis-je verrouiller une ligne contre la modification (déplacement, redimensionnement) ?**

Oui. Les formes offrent des [lock objects](https://reference.aspose.com/slides/net/aspose.slides/autoshape/autoshapelock/) qui vous permettent de [interdire les opérations de modification](/slides/fr/net/applying-protection-to-presentation/).