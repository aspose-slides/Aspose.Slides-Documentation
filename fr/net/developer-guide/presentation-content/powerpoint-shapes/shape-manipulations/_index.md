---
title: Gérer les formes de présentation dans .NET
linktitle: Manipulation de formes
type: docs
weight: 40
url: /fr/net/shape-manipulations/
keywords:
- forme PowerPoint
- forme de présentation
- forme sur diapositive
- trouver forme
- dupliquer forme
- supprimer forme
- masquer forme
- changer l'ordre des formes
- obtenir ID de forme interop
- texte alternatif de forme
- formats de mise en page de forme
- forme en SVG
- forme vers SVG
- aligner forme
- retourner forme
- PowerPoint
- présentation
- .NET
- C#
- Aspose.Slides
description: "Apprenez à identifier, dupliquer, supprimer, masquer, réorganiser, exporter, aligner et retourner les formes d'une présentation avec Aspose.Slides pour .NET."
---
## **Vue d'ensemble**

Aspose.Slides pour .NET représente les formes sur une diapositive comme une collection ordonnée [IShapeCollection](https://reference.aspose.com/slides/fr/net/aspose.slides/ishapecollection/). La collection est à la fois l’endroit où vous trouvez et modifiez les formes et la source de leur ordre d’empilement : l’index `0` correspond à la forme la plus en arrière, tandis que le dernier index correspond à la forme la plus en avant.

Cet article suit ce modèle. Il explique d’abord comment identifier une forme de manière fiable, puis montre comment dupliquer, supprimer, masquer et réorganiser les formes. Les sections finales couvrent le formatage au niveau de la mise en page, l’exportation SVG, l’alignement et les paramètres de retournement. Chaque exemple est indépendant, de sorte que vous pouvez n’utiliser que les opérations requises par votre flux de travail.

## **Identifier et rechercher des formes**

Les index de collection sont pratiques lors du traitement d’un fichier connu, mais ils ne sont pas des identifiants stables. Ajouter, supprimer ou réorganiser une forme peut modifier son index. Choisissez un identifiant en fonction de la manière dont la présentation est créée et maintenue :

- [Name](https://reference.aspose.com/slides/fr/net/aspose.slides/ishape/name/) est utile pour les modèles contrôlés par les développeurs et est facile à inspecter dans le volet Sélection de PowerPoint. Les noms peuvent être modifiés et ne sont pas garantis d’être uniques, il faut donc établir une convention de nommage si le code en dépend.
- [AlternativeText](https://reference.aspose.com/slides/fr/net/aspose.slides/ishape/alternativetext/) est utile lorsqu’une description d’accessibilité ou une balise fournie par l’auteur identifie déjà la forme. Il est visible des utilisateurs, peut être localisé ou réécrit pour l’accessibilité, et n’est pas garanti d’être unique. Ne réutilisez pas silencieusement un texte d’accessibilité significatif comme clé de base de données.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/fr/net/aspose.slides/ishape/officeinteropshapeid/) est un identifiant en lecture seule qui est unique au sein d’une diapositive et correspond à l’ID de forme utilisé par l’interop PowerPoint. Utilisez‑le lors de l’intégration avec PowerPoint ou quand vous avez besoin d’une référence non ambiguë pendant la durée de vie d’une forme. Une forme dupliquée ou recréée est une forme différente et reçoit son propre ID.

La propriété [UniqueId](https://reference.aspose.com/slides/fr/net/aspose.slides/ishape/uniqueid/) associée a une portée de présentation, mais elle est destinée aux compléments et peut être réaffectée. Elle ne doit pas être considérée comme une clé externe permanente. Si une identité à long terme est essentielle, conservez la correspondance dans les données de l’application et validez que la forme attendue existe toujours.

L’exemple suivant recherche par `Name` avec une comparaison ordinale et renvoie l’ID d’interop propre à la diapositive. Lorsque le modèle ne contient pas la forme attendue, le code signale ce résultat au lieu de poursuivre avec l’objet incorrect.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");
var slide = presentation.Slides[0];

IShape? targetShape = null;
foreach (var shape in slide.Shapes)
{
    if (string.Equals(shape.Name, "RevenueChart", StringComparison.Ordinal))
    {
        targetShape = shape;
        break;
    }
}

if (targetShape is null)
{
    Console.WriteLine("The shape 'RevenueChart' was not found on slide 1.");
}
else
{
    Console.WriteLine($"Found {targetShape.Name}; interop ID: {targetShape.OfficeInteropShapeId}");
}
```

Lorsqu’une opération est spécifique à un type de forme, vérifiez l’interface avant d’utiliser les membres spécifiques au type. Cet exemple met à jour le texte et le texte alternatif uniquement si l’objet nommé est un [IAutoShape](https://reference.aspose.com/slides/fr/net/aspose.slides/iautoshape/).

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");
var slide = presentation.Slides[0];

IShape? candidate = null;
foreach (var shape in slide.Shapes)
{
    if (string.Equals(shape.Name, "StatusLabel", StringComparison.Ordinal))
    {
        candidate = shape;
        break;
    }
}

if (candidate is IAutoShape autoShape)
{
    autoShape.TextFrame.Text = "Approved";
    autoShape.AlternativeText = "Approval status: approved";
    presentation.Save("identified-shape.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("'StatusLabel' is missing or is not an AutoShape.");
}
```

## **Modifier la collection de formes**

Les méthodes d’ajout, de duplication, de suppression et de réorganisation agissent immédiatement sur la collection. Si une opération modifie le nombre ou l’ordre des formes, ne continuez pas à vous fier aux index capturés avant cette opération.

### **Dupliquer une forme**

[AddClone](https://reference.aspose.com/slides/fr/net/aspose.slides/ishapecollection/addclone/) crée une copie indépendante et l’ajoute à la fin de la collection cible. [InsertClone](https://reference.aspose.com/slides/fr/net/aspose.slides/ishapecollection/insertclone/) crée également une copie mais la place à un index de z‑order spécifié. Les surcharges qui acceptent des coordonnées déplacent le clone sans changer sa taille ; les surcharges avec largeur et hauteur peuvent également le redimensionner.

L’exemple crée une diapositive de destination, duplique un rectangle étiqueté vers l’avant, et insère un deuxième clone à l’arrière. Les modifications apportées à l’un ou l’autre clone ne modifient pas la forme source.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var sourceSlide = presentation.Slides[0];
var sourceShape = sourceSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 180, 60);
sourceShape.Name = "SourceLabel";
sourceShape.TextFrame.Text = "Source";

var blankLayout = presentation.Masters[0].LayoutSlides.GetByType(SlideLayoutType.Blank);
var destinationSlide = presentation.Slides.AddEmptySlide(blankLayout);

var frontCloneShape = destinationSlide.Shapes.AddClone(sourceShape, 80, 80);
frontCloneShape.Name = "FrontClone";
if (frontCloneShape is IAutoShape frontClone)
{
    frontClone.TextFrame.Text = "Front clone";
}
else
{
    Console.WriteLine("The front clone is not an AutoShape; its text was not changed.");
}

var backCloneShape = destinationSlide.Shapes.InsertClone(0, sourceShape, 80, 180);
backCloneShape.Name = "BackClone";
if (backCloneShape is IAutoShape backClone)
{
    backClone.TextFrame.Text = "Back clone";
}
else
{
    Console.WriteLine("The back clone is not an AutoShape; its text was not changed.");
}

presentation.Save("cloned-shapes.pptx", SaveFormat.Pptx);
```

La duplication copie le contenu et le formatage de la forme, y compris son nom et son texte alternatif. Attribuez de nouveaux identifiants logiques au clone lorsque ces valeurs doivent être uniques. Les ressources utilisées par les formes complexes sont gérées par la présentation, mais un clone reste un nouvel élément de collection avec une nouvelle identité de forme.

### **Supprimer des formes**

[Remove](https://reference.aspose.com/slides/fr/net/aspose.slides/ishapecollection/remove/) supprime un objet forme spécifique de sa collection. Lors de la suppression de plusieurs correspondances pendant une itération indexée, parcourez la collection à rebours afin que chaque index restant reste valide.

Cet exemple supprime chaque forme portant un nom désigné. Il lit `slide.Shapes[i]`, pas un élément de collection fixe, et il ne cast pas la forme inutilement.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var keepShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 140, 60);
keepShape.Name = "Keep";

var firstTemporaryShape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 220, 40, 80, 80);
firstTemporaryShape.Name = "Temporary";

var secondTemporaryShape = slide.Shapes.AddAutoShape(ShapeType.Triangle, 340, 40, 100, 80);
secondTemporaryShape.Name = "Temporary";

for (var i = slide.Shapes.Count - 1; i >= 0; i--)
{
    var shape = slide.Shapes[i];
    if (string.Equals(shape.Name, "Temporary", StringComparison.Ordinal))
    {
        slide.Shapes.Remove(shape);
    }
}

presentation.Save("removed-shapes.pptx", SaveFormat.Pptx);
```

Après la suppression, le nombre de formes et les index des formes suivantes changent. Les références aux formes non affectées restent plus fiables que des index enregistrés. Pensez également aux connecteurs, aux animations et aux autres fonctionnalités de présentation qui peuvent faire référence à l’objet supprimé ; la suppression d’une forme visible peut modifier plus que l’apparence de la diapositive.

### **Masquer une forme**

Définir [Hidden](https://reference.aspose.com/slides/fr/net/aspose.slides/ishape/hidden/) à `true` conserve la forme dans la collection mais empêche son affichage lors du diaporama normal. Son index, son formatage et son contenu restent disponibles pour le code, de sorte que le masquage convient aux éléments optionnels qui peuvent être restaurés ultérieurement.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var visibleShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 160, 60);
visibleShape.Name = "VisibleLabel";

var optionalShape = slide.Shapes.AddAutoShape(ShapeType.Moon, 240, 40, 100, 100);
optionalShape.Name = "OptionalDecoration";

foreach (var shape in slide.Shapes)
{
    if (string.Equals(shape.Name, "OptionalDecoration", StringComparison.Ordinal))
    {
        shape.Hidden = true;
    }
}

presentation.Save("hidden-shape.pptx", SaveFormat.Pptx);
```

Masquer n’est ni une suppression ni une mesure de sécurité. L’objet peut encore être découvert et affiché à nouveau par un utilisateur ou par du code, et il reste une partie du fichier de présentation.

### **Modifier l’ordre Z**

Les formes qui se chevauchent sont peintes selon l’ordre de la collection. [Reorder](https://reference.aspose.com/slides/fr/net/aspose.slides/ishapecollection/reorder/) déplace une forme existante vers un index cible sans la cloner. L’index `0` est l’arrière ; `Count - 1` est l’avant.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var blueRectangle = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 220, 120);
blueRectangle.Name = "BlueRectangle";
blueRectangle.FillFormat.FillType = FillType.Solid;
blueRectangle.FillFormat.SolidFillColor.Color = Color.SteelBlue;

var orangeEllipse = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 180, 140, 220, 120);
orangeEllipse.Name = "OrangeEllipse";
orangeEllipse.FillFormat.FillType = FillType.Solid;
orangeEllipse.FillFormat.SolidFillColor.Color = Color.Orange;

slide.Shapes.Reorder(slide.Shapes.Count - 1, blueRectangle);
presentation.Save("reordered-shapes.pptx", SaveFormat.Pptx);
```

Le rectangle est créé en premier et se trouve initialement derrière l’ellipse. Le déplacer vers l’index final le place devant. Finalisez l’ordre Z après avoir ajouté ou dupliqué toutes les formes liées, car ces opérations ajoutent ou insèrent de nouveaux éléments de collection et peuvent altérer la pile prévue.

## **Inspecter les formes sur les diapositives de mise en page**

Les diapositives normales, les diapositives de mise en page et les diapositives maîtres ont des collections de formes distinctes. Une forme dans une collection de mise en page n’est pas le même objet qu’une forme positionnée de façon similaire sur une diapositive normale. Inspectez les formes de mise en page lorsque vous devez comprendre ou modifier le formatage fourni par une mise en page.

L’exemple suivant lit le [FillFormat](https://reference.aspose.com/slides/fr/net/aspose.slides/ishape/fillformat/) et le [LineFormat](https://reference.aspose.com/slides/fr/net/aspose.slides/ishape/lineformat/) de chaque forme de mise en page sans supposer que chaque forme est une `AutoShape`.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");

foreach (var layoutSlide in presentation.LayoutSlides)
{
    foreach (var shape in layoutSlide.Shapes)
    {
        var fillType = shape.FillFormat.FillType;
        var lineWidth = shape.LineFormat.Width;
        Console.WriteLine($"{layoutSlide.Name} / {shape.Name}: fill={fillType}, line width={lineWidth}");
    }
}
```

Modifier une mise en page peut affecter plusieurs diapositives qui l’utilisent. Avant de changer une forme de mise en page, déterminez si une diapositive normale hérite de l’objet ou contient un écrasement local, et testez chaque diapositive qui utilise cette mise en page.

## **Exporter une forme au format SVG**

[WriteAsSvg](https://reference.aspose.com/slides/fr/net/aspose.slides/ishape/writeassvg/) écrit le contenu rendu d’une forme dans un flux. Le résultat contient la forme, pas l’arrière‑plan complet de la diapositive ou les formes voisines.

```csharp
using System;
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");
var slide = presentation.Slides[0];

if (slide.Shapes.Count == 0)
{
    Console.WriteLine("Slide 1 does not contain a shape to export.");
}
else
{
    var shape = slide.Shapes[0];
    using var svgStream = File.Create("shape.svg");
    shape.WriteAsSvg(svgStream);
}
```

Gardez la présentation ouverte pendant le rendu. La sortie dépend du formatage de la forme et des ressources telles que les polices et les images. Si vous avez besoin de toute la composition, exportez la diapositive plutôt qu’une forme individuelle. L’appelant possède le flux et doit le disposer.

## **Aligner les formes**

Les surcharges de [SlideUtil.AlignShapes](https://reference.aspose.com/slides/fr/net/aspose.slides.util/slideutil/alignshapes/) alignent soit toutes les formes, soit les index de collection sélectionnés. [ShapesAlignmentType](https://reference.aspose.com/slides/fr/net/aspose.slides/shapesalignmenttype/) spécifie le bord, la ligne centrale ou le mode de distribution. Définissez `alignToSlide` à `true` pour utiliser les bords de la diapositive ; définissez‑le à `false` pour aligner les formes sélectionnées les unes par rapport aux autres.

Cet exemple aligne trois formes sur le bord supérieur de la diapositive. Les références de formes renvoyées sont converties en leurs index actuels immédiatement avant l’alignement.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Util;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var firstShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 60, 80, 120, 50);
var secondShape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 240, 160, 120, 50);
var thirdShape = slide.Shapes.AddAutoShape(ShapeType.Triangle, 420, 240, 120, 50);
firstShape.Name = "FirstAlignedShape";
secondShape.Name = "SecondAlignedShape";
thirdShape.Name = "ThirdAlignedShape";

var shapeIndexes = new[]
{
    slide.Shapes.IndexOf(firstShape),
    slide.Shapes.IndexOf(secondShape),
    slide.Shapes.IndexOf(thirdShape)
};

SlideUtil.AlignShapes(ShapesAlignmentType.AlignTop, true, slide, shapeIndexes);
presentation.Save("aligned-shapes.pptx", SaveFormat.Pptx);
```

L’alignement modifie les positions, pas l’ordre Z. L’alignement relatif nécessite généralement au moins deux formes, tandis que la distribution horizontale ou verticale demande suffisamment de formes pour définir l’espacement. Recalculez les index si vous modifiez la collection avant d’appeler la méthode.

## **Retourner une forme**

La classe [ShapeFrame](https://reference.aspose.com/slides/fr/net/aspose.slides/shapeframe/) stocke la position, la taille, les paramètres de retournement horizontal et vertical, ainsi que la rotation. Ses valeurs `FlipH` et `FlipV` utilisent [NullableBool](https://reference.aspose.com/slides/fr/net/aspose.slides/nullablebool/) : `True` active le retournement, `False` le désactive, et `NotDefined` préserve l’état non spécifié/par défaut.

La présentation d’entrée ci‑dessous contient une forme non retournée.

![La forme avant retournement](shape_to_be_flipped.png)

L’exemple conserve toutes les autres valeurs du cadre et ne remplace que les deux paramètres de retournement. Ceci est important parce que l’affectation d’un nouveau [Frame](https://reference.aspose.com/slides/fr/net/aspose.slides/ishape/frame/) remplace le cadre complet.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var shape = presentation.Slides[0].Shapes[0];
var frame = shape.Frame;

Console.WriteLine($"Horizontal flip before change: {frame.FlipH}");
Console.WriteLine($"Vertical flip before change: {frame.FlipV}");

shape.Frame = new ShapeFrame(
    frame.X, frame.Y, frame.Width, frame.Height,
    NullableBool.True, NullableBool.True, frame.Rotation);

presentation.Save("flipped-shape.pptx", SaveFormat.Pptx);
```

La forme enregistrée est reflétée horizontalement et verticalement tout en conservant sa position, sa taille et sa rotation.

![La forme après retournement](flipped_shape.png)

## **FAQ**

**Dois‑je utiliser un index de collection comme identifiant de forme ?**

Seulement pour un traitement de courte durée lorsque la collection ne changera pas avant que l’index ne soit utilisé. Privilégiez une convention validée de `Name` ou `AlternativeText` pour les modèles créés, ou `OfficeInteropShapeId` pour le travail d’interopérabilité au niveau de la diapositive.

**Le fait de masquer une forme la retire‑t‑elle de l’ordre Z ?**

Non. Une forme masquée reste dans la collection au même index. Elle peut être trouvée, réordonnée, modifiée ou rendue à nouveau visible.

**Pourquoi une forme clonée est‑elle apparue devant une autre forme ?**

`AddClone` ajoute le clone à la fin de la collection, ce qui correspond à l’avant de l’ordre Z. Utilisez `InsertClone` pour choisir l’index initial ou `Reorder` après avoir ajouté toutes les formes.