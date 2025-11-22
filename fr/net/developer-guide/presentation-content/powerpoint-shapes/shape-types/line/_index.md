---
title: Ligne
type: docs
weight: 50
url: /fr/net/Line/
keywords: "Ligne, forme PowerPoint, présentation PowerPoint, C#, Csharp, Aspose.Slides for .NET"
description: "Ajouter une ligne dans une présentation PowerPoint en C# ou .NET"
---

Aspose.Slides for .NET prend en charge l'ajout de différents types de formes aux diapositives. Dans ce sujet, nous commencerons à travailler avec les formes en ajoutant des lignes aux diapositives. Avec Aspose.Slides for .NET, les développeurs peuvent non seulement créer des lignes simples, mais aussi dessiner des lignes décoratives sur les diapositives.
## **Créer une ligne simple**
Pour ajouter une ligne simple à une diapositive sélectionnée de la présentation, suivez les étapes ci‑dessous :

- Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
- Obtenez la référence d’une diapositive en utilisant son index.
- Ajoutez une AutoShape de type Line en utilisant la méthode [AddAutoShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/methods/addautoshape/index) exposée par l’objet Shapes.
- Enregistrez la présentation modifiée sous forme de fichier PPTX.

Dans l’exemple ci‑dessous, nous avons ajouté une ligne à la première diapositive de la présentation.
```c#
// Instancier la classe PresentationEx qui représente le fichier PPTX
using (Presentation pres = new Presentation())
{
    // Obtenir la première diapositive
    ISlide sld = pres.Slides[0];

    // Ajouter une autoshape de type ligne
    sld.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

    // Enregistrer le PPTX sur le disque
    pres.Save("LineShape1_out.pptx", SaveFormat.Pptx);
}
```


## **Créer une ligne en forme de flèche**
Aspose.Slides for .NET permet également aux développeurs de configurer certaines propriétés de la ligne pour la rendre plus attrayante. Essayons de configurer quelques propriétés d’une ligne pour qu’elle ressemble à une flèche. Suivez les étapes ci‑dessus pour le faire :

- Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
- Obtenez la référence d’une diapositive en utilisant son index.
- Ajoutez une AutoShape de type Line en utilisant la méthode AddAutoShape exposée par l’objet Shapes.
- Définissez le Style de ligne sur l’un des styles proposés par Aspose.Slides for .NET.
- Définissez la largeur de la ligne.
- Définissez le [Dash Style](https://reference.aspose.com/slides/net/aspose.slides/linedashstyle) de la ligne sur l’un des styles proposés par Aspose.Slides for .NET.
- Définissez le [Arrow Head Style](https://reference.aspose.com/slides/net/aspose.slides/linearrowheadstyle) et la longueur du point de départ de la ligne.
- Définissez le Arrow Head Style et la longueur du point d’arrivée de la ligne.
- Enregistrez la présentation modifiée sous forme de fichier PPTX.
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

    // Enregistrer le PPTX sur le disque
    pres.Save("LineShape2_out.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**Puis-je convertir une ligne ordinaire en connecteur afin qu’elle « s’ajuste » aux formes ?**

Non. Une ligne ordinaire (une [AutoShape](https://reference.aspose.com/slides/net/aspose.slides/autoshape/) de type [Line](https://reference.aspose.com/slides/net/aspose.slides/shapetype/)) ne devient pas automatiquement un connecteur. Pour la faire s’ajuster aux formes, utilisez le type [Connector](https://reference.aspose.com/slides/net/aspose.slides/connector/) dédié et les [APIs correspondantes](/slides/fr/net/connector/) pour les connexions.

**Que faire si les propriétés d’une ligne sont héritées du thème et qu’il est difficile de déterminer les valeurs finales ?**

[Lisez les propriétés effectives](/slides/fr/net/shape-effective-properties/) via les interfaces [ILineFormatEffectiveData](https://reference.aspose.com/slides/net/aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/net/aspose.slides/ilinefillformateffectivedata/) — elles tiennent déjà compte de l’héritage et des styles du thème.

**Puis-je verrouiller une ligne contre la modification (déplacement, redimensionnement) ?**

Oui. Les formes offrent des [objets de verrouillage](https://reference.aspose.com/slides/net/aspose.slides/autoshape/autoshapelock/) qui vous permettent de [interdire les opérations de modification](/slides/fr/net/applying-protection-to-presentation/).