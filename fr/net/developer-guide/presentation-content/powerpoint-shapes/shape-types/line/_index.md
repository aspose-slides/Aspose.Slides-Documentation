---
title: Ajouter des formes de ligne aux présentations en .NET
linktitle: Ligne
type: docs
weight: 50
url: /fr/net/line/
keywords:
- ligne
- créer une ligne
- ajouter une ligne
- ligne simple
- configurer la ligne
- personnaliser la ligne
- style de tiret
- tête de flèche
- PowerPoint
- présentation
- .NET
- C#
- Aspose.Slides
description: "Apprenez à manipuler la mise en forme des lignes dans les présentations PowerPoint avec Aspose.Slides pour .NET. Découvrez les propriétés, les méthodes et des exemples."
---
## **Aperçu**

Aspose.Slides vous permet d’ajouter des formes de ligne aux diapositives PowerPoint de façon programmatique. Cet article montre comment créer une ligne simple et comment personnaliser une ligne pour qu’elle apparaisse sous forme de flèche.

Vous apprendrez comment ajouter une forme de ligne à une diapositive, ajuster son apparence visuelle et enregistrer la présentation mise à jour. Les exemples se concentrent sur des paramètres pratiques de mise en forme de ligne tels que le style, la largeur, le motif de tirets, les options de tête de flèche et la couleur de remplissage.

## **Créer une ligne simple**
Pour ajouter une ligne simple à la diapositive sélectionnée de la présentation, suivez les étapes ci‑dessous :

- Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation).
- Obtenir la référence d’une diapositive en utilisant son index.
- Ajouter une AutoShape de type Ligne en utilisant la méthode AddAutoShape exposée par l’objet Shapes.
- Enregistrer la présentation modifiée sous forme de fichier PPTX.

Dans l’exemple ci‑dessous, nous avons ajouté une ligne à la première diapositive de la présentation.

```c#
// Instancier la classe PresentationEx qui représente le fichier PPTX
using (Presentation pres = new Presentation())
{
    // Obtenir la première diapositive
    ISlide sld = pres.Slides[0];

    // Ajouter une autoshape de type ligne
    sld.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

    //Enregistrer le PPTX sur le disque
    pres.Save("LineShape1_out.pptx", SaveFormat.Pptx);
}
```

## **Créer une ligne en forme de flèche**
Aspose.Slides pour .NET permet également aux développeurs de configurer certaines propriétés de la ligne afin de la rendre plus attrayante. Essayons de configurer quelques propriétés de la ligne pour qu’elle ressemble à une flèche. Suivez les étapes ci‑dessous :

- Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation).
- Obtenir la référence d’une diapositive en utilisant son index.
- Ajouter une AutoShape de type Ligne en utilisant la méthode AddAutoShape exposée par l’objet Shapes.
- Définir le **Line Style** à l’un des styles proposés par Aspose.Slides pour .NET.
- Définir la **Width** de la ligne.
- Définir le **[Dash Style](https://reference.aspose.com/slides/fr/net/aspose.slides/linedashstyle)** de la ligne à l’un des styles proposés par Aspose.Slides pour .NET.
- Définir le **[Arrow Head Style](https://reference.aspose.com/slides/fr/net/aspose.slides/linearrowheadstyle)** et la longueur du point de départ de la ligne.
- Définir le **Arrow Head Style** et la longueur du point d’arrivée de la ligne.
- Enregistrer la présentation modifiée sous forme de fichier PPTX.

```c#
// Instancier la classe PresentationEx qui représente le fichier PPTX
using (Presentation pres = new Presentation())
{

    // Obtenir la première diapositive
    ISlide sld = pres.Slides[0];

    // Ajouter une autoshape de type ligne
    IAutoShape shp = sld.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

    // Appliquer un certain formatage à la ligne
    shp.LineFormat.Style = LineStyle.ThickBetweenThin;
    shp.LineFormat.Width = 10;

    shp.LineFormat.DashStyle = LineDashStyle.DashDot;

    shp.LineFormat.BeginArrowheadLength = LineArrowheadLength.Short;
    shp.LineFormat.BeginArrowheadStyle = LineArrowheadStyle.Oval;

    shp.LineFormat.EndArrowheadLength = LineArrowheadLength.Long;
    shp.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;

    shp.LineFormat.FillFormat.FillType = FillType.Solid;
    shp.LineFormat.FillFormat.SolidFillColor.Color = Color.Maroon;

    //Enregistrer le PPTX sur le disque
    pres.Save("LineShape2_out.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Puis‑je convertir une ligne normale en connecteur afin qu’elle « snap » aux formes ?**

Non. Une ligne normale (une [AutoShape](https://reference.aspose.com/slides/fr/net/aspose.slides/autoshape/) de type [Line](https://reference.aspose.com/slides/fr/net/aspose.slides/shapetype/)) ne devient pas automatiquement un connecteur. Pour la faire s’enclencher aux formes, utilisez le type dédié [Connector](https://reference.aspose.com/slides/fr/net/aspose.slides/connector/) et les [API correspondantes](/slides/fr/net/connector/) pour les connexions.

**Que faire si les propriétés d’une ligne sont héritées du thème et qu’il est difficile de déterminer les valeurs finales ?**

[Lire les propriétés effectives](/slides/fr/net/shape-effective-properties/) via les interfaces [ILineFormatEffectiveData](https://reference.aspose.com/slides/fr/net/aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/fr/net/aspose.slides/ilinefillformateffectivedata/) — celles‑ci tiennent déjà compte de l’héritage et des styles du thème.

**Puis‑je verrouiller une ligne contre toute modification (déplacement, redimensionnement) ?**

Oui. Les formes offrent des [objets de verrouillage](https://reference.aspose.com/slides/fr/net/aspose.slides/autoshape/autoshapelock/) qui permettent de [interdire les opérations de modification](/slides/fr/net/applying-protection-to-presentation/).