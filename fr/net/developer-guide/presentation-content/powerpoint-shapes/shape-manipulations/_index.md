---
title: Gérer les formes de présentation dans .NET
linktitle: Manipulation des formes
type: docs
weight: 40
url: /fr/net/shape-manipulations/
keywords:
- forme PowerPoint
- forme de présentation
- forme sur diapositive
- rechercher une forme
- cloner une forme
- supprimer forme
- masquer forme
- modifier l'ordre des formes
- obtenir l'ID de forme interop
- texte alternatif de forme
- point d'ajustement de forme
- ajustement de forme prédéfini
- géométrie de forme
- formats de mise en page de forme
- forme au format SVG
- forme vers SVG
- aligner forme
- retourner forme
- PowerPoint
- présentation
- .NET
- C#
- Aspose.Slides
description: Apprenez à identifier, ajuster, cloner, supprimer, masquer, réorganiser, exporter, aligner et retourner les formes de présentation avec Aspose.Slides pour .NET.
---
## **Aperçu**

Aspose.Slides for .NET représente les formes d’une diapositive sous forme d’une [IShapeCollection](https://reference.aspose.com/slides/fr/net/aspose.slides/ishapecollection/) ordonnée. La collection est à la fois l’endroit où vous trouvez et modifiez les formes et la source de leur ordre d’empilement : l’index `0` correspond à la forme la plus en arrière, tandis que le dernier index correspond à la forme la plus en avant.

Cet article suit ce modèle. Il explique d’abord comment identifier de façon fiable une forme et modifier les points d’ajustement prédéfinis, puis montre comment cloner, supprimer, masquer et ré‑ordonner des formes. Les dernières sections portent sur le formatage au niveau de la disposition, l’export SVG, l’alignement et les paramètres de retournement. Chaque exemple est indépendant, vous pouvez donc n’utiliser que les opérations requises par votre flux de travail.

## **Identifier et trouver des formes**

Les index de collection sont pratiques lors du traitement d’un fichier connu, mais ils ne sont pas des identifiants stables. Ajouter, supprimer ou ré‑ordonner une forme peut modifier son index. Choisissez un identifiant en fonction de la façon dont la présentation est créée et maintenue :

- [Name](https://reference.aspose.com/slides/fr/net/aspose.slides/ishape/name/) est utile pour les modèles contrôlés par les développeurs et il est facile à inspecter dans le volet de sélection de PowerPoint. Les noms peuvent être modifiés et ne sont pas garantis uniques, il faut donc établir une convention de nommage si le code en dépend.
- [AlternativeText](https://reference.aspose.com/slides/fr/net/aspose.slides/ishape/alternativetext/) est utile lorsqu’une description d’accessibilité ou une étiquette fournie par l’auteur identifie déjà la forme. Il est visible des utilisateurs, peut être localisé ou réécrit pour l’accessibilité, et n’est pas garanti unique. Ne réutilisez pas silencieusement un texte d’accessibilité significatif comme clé de base de données.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/fr/net/aspose.slides/ishape/officeinteropshapeid/) est un identifiant en lecture seule qui est unique à l’intérieur d’une diapositive et correspond à l’ID de forme utilisé par l’interopérabilité PowerPoint. Utilisez‑le lors de l’intégration avec PowerPoint ou quand vous avez besoin d’une référence sans ambiguïté pendant la durée de vie d’une forme. Une forme clonée ou recréée est une forme différente et reçoit son propre ID.

La propriété [UniqueId](https://reference.aspose.com/slides/fr/net/aspose.slides/ishape/uniqueid/) associée a une portée présentation, mais elle est destinée aux compléments et peut être réaffectée. Elle ne doit pas être traitée comme une clé externe permanente. Si une identité à long terme est essentielle, conservez la correspondance dans les données d’application et validez que la forme attendue existe toujours.

L’exemple suivant recherche par `Name` avec une comparaison ordinale et indique l’ID d’interopérabilité au niveau de la diapositive. Lorsque le modèle ne contient pas la forme attendue, le code signale ce résultat au lieu de poursuivre avec le mauvais objet.

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

Lorsqu’une opération est spécifique à un type de forme, vérifiez l’interface avant d’utiliser des membres spécifiques au type. Cet exemple met à jour le texte et le texte alternatif uniquement si l’objet nommé est un [IAutoShape](https://reference.aspose.com/slides/fr/net/aspose.slides/iautoshape/).

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

## **Identifier et modifier les ajustements de forme prédéfinis**

Les formes de géométrie prédéfinie peuvent exposer des points d’ajustement qui contrôlent des caractéristiques telles que la taille des coins, les proportions des flèches ou les angles d’arcs. Accédez‑y via la collection en lecture seule [IGeometryShape.Adjustments](https://reference.aspose.com/slides/fr/net/aspose.slides/igeometryshape/adjustments/). La collection elle‑même est fournie par la forme, mais chaque [IAdjustValue](https://reference.aspose.com/slides/fr/net/aspose.slides/iadjustvalue/) contient une valeur pouvant être modifiée.

Ne vous fiez pas uniquement à un index de collection fixe. Parcourez les ajustements et inspectez la propriété en lecture seule [Type](https://reference.aspose.com/slides/fr/net/aspose.slides/adjustvalue/type/), dont la valeur [ShapeAdjustmentType](https://reference.aspose.com/slides/fr/net/aspose.slides/shapeadjustmenttype/) décrit ce que l’ajustement contrôle. La propriété en lecture seule [Name](https://reference.aspose.com/slides/fr/net/aspose.slides/adjustvalue/name/) fournit des informations d’identification supplémentaires et est particulièrement utile lorsqu’un préréglage contient plusieurs ajustements du même type sémantique.

Utilisez la propriété de valeur qui correspond à la signification de l’ajustement :

| Type d'ajustement | Objectif | Valeur à modifier |
|---|---|---|
| `CornerSize` | Taille des coins arrondis | [RawValue](https://reference.aspose.com/slides/fr/net/aspose.slides/adjustvalue/rawvalue/) |
| `ArrowTailThickness` | Épaisseur de la queue d’une flèche | `RawValue` |
| `ArrowheadLength` | Longueur de la pointe de flèche | `RawValue` |
| `ArrowheadWidth` | Largeur de la pointe de flèche | `RawValue` |
| `StartAngle` | Angle de départ d’une part ou d’un arc | [AngleValue](https://reference.aspose.com/slides/fr/net/aspose.slides/adjustvalue/anglevalue/) |
| `EndAngle` | Angle final d’une part ou d’un arc | `AngleValue` |

`Type` et `Name` ne peuvent pas être assignés. `RawValue` est un entier en lecture/écriture dans les unités de géométrie natives du préréglage, tandis que `AngleValue` est un angle en lecture/écriture exprimé en degrés. Le nombre, l’ordre, la signification et la plage valide des ajustements dépendent du préréglage [ShapeType](https://reference.aspose.com/slides/fr/net/aspose.slides/igeometryshape/shapetype/). Une valeur valide pour un préréglage peut être invalide ou avoir un effet différent pour un autre.

Lorsque `Type` est `ShapeAdjustmentType.Custom`, l’API ne reconnaît pas de signification sémantique standard. Inspectez `Name`, le type de préréglage et la valeur existante, et laissez l’ajustement inchangé sauf si la signification et la plage attendues sont connues. Même pour les types reconnus, vérifiez si le même type apparaît plusieurs fois avant de sélectionner une valeur. L’article [Connector](/slides/fr/net/connector/) montre cette situation avec les ajustements de courbure des connecteurs.

L’exemple complet suivant crée des versions par défaut et modifiées de trois formes prédéfinies. Il parcourt chaque ajustement, rapporte son `Name` et son `Type`, modifie les valeurs liées à la taille via `RawValue`, modifie les angles via `AngleValue`, puis enregistre le résultat. La colonne de gauche conserve la géométrie par défaut ; la colonne de droite montre le rectangle arrondi, la flèche à quatre pointes et la part ajustés.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

// Ajoute des en-têtes pour les colonnes de forme par défaut et ajustée.
var defaultColumnLabel = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 20, 250, 30);
defaultColumnLabel.TextFrame.Text = "Default preset geometry";
var adjustedColumnLabel = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 390, 20, 250, 30);
adjustedColumnLabel.TextFrame.Text = "Modified adjustment values";

slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 80, 70, 160, 70);
var modifiedRoundedRectangle = slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 430, 70, 160, 70);
modifiedRoundedRectangle.Name = "ModifiedRoundedRectangle";

slide.Shapes.AddAutoShape(ShapeType.QuadArrow, 80, 180, 160, 110);
var modifiedArrow = slide.Shapes.AddAutoShape(ShapeType.QuadArrow, 430, 180, 160, 110);
modifiedArrow.Name = "ModifiedQuadArrow";

slide.Shapes.AddAutoShape(ShapeType.Pie, 95, 330, 130, 130);
var modifiedPie = slide.Shapes.AddAutoShape(ShapeType.Pie, 445, 330, 130, 130);
modifiedPie.Name = "ModifiedPie";

var shapesToAdjust = new IGeometryShape[]
{
    modifiedRoundedRectangle,
    modifiedArrow,
    modifiedPie
};

foreach (var shape in shapesToAdjust)
{
    for (var adjustmentIndex = 0; adjustmentIndex < shape.Adjustments.Count; adjustmentIndex++)
    {
        var adjustment = shape.Adjustments[adjustmentIndex];
        Console.WriteLine($"{shape.Name} / {adjustment.Name}: {adjustment.Type}");

        switch (adjustment.Type)
        {
            case ShapeAdjustmentType.CornerSize:
                adjustment.RawValue = 5000;
                break;
            case ShapeAdjustmentType.ArrowTailThickness:
                adjustment.RawValue = 25000;
                break;
            case ShapeAdjustmentType.ArrowheadLength:
                adjustment.RawValue = 30000;
                break;
            case ShapeAdjustmentType.ArrowheadWidth:
                adjustment.RawValue = 40000;
                break;
            case ShapeAdjustmentType.StartAngle:
                adjustment.AngleValue = 30;
                break;
            case ShapeAdjustmentType.EndAngle:
                adjustment.AngleValue = 300;
                break;
            case ShapeAdjustmentType.Custom:
                Console.WriteLine($"Custom adjustment '{adjustment.Name}' was not changed.");
                break;
        }
    }
}

presentation.Save("preset-shape-adjustments.pptx", SaveFormat.Pptx);
```

Vérifier le type sémantique avant de modifier une valeur rend le code explicite quant à son intention et évite de supposer qu’un index de collection particulier a la même signification à travers différents préréglages de forme.

## **Modifier la collection de formes**

Les méthodes d’ajout, de clonage, de suppression et de ré‑ordonnancement agissent immédiatement sur la collection. Si une opération change le nombre ou l’ordre des formes, ne continuez pas à vous fier aux index capturés avant cette opération.

### **Cloner une forme**

[AddClone](https://reference.aspose.com/slides/fr/net/aspose.slides/ishapecollection/addclone/) crée une copie indépendante et l’ajoute à la collection cible. [InsertClone](https://reference.aspose.com/slides/fr/net/aspose.slides/ishapecollection/insertclone/) crée également une copie mais la place à un index d’ordre z spécifié. Les surcharges qui acceptent des coordonnées déplacent le clone sans en changer la taille ; les surcharges avec largeur et hauteur peuvent le redimensionner également.

L’exemple crée une diapositive de destination, clone un rectangle nommé vers l’avant, et insère un deuxième clone à l’arrière. Les modifications apportées à l’un ou l’autre clone n’altèrent pas la forme source.

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

Le clonage copie le contenu et le formatage de la forme, y compris son nom et son texte alternatif. Attribuez de nouveaux identifiants logiques au clone lorsque ces valeurs doivent être uniques. Les ressources utilisées par les formes complexes sont gérées par la présentation, mais un clone reste un nouvel élément de collection avec une nouvelle identité de forme.

### **Supprimer des formes**

[Remove](https://reference.aspose.com/slides/fr/net/aspose.slides/ishapecollection/remove/) supprime un objet forme spécifique de sa collection. Lors de la suppression de plusieurs correspondances pendant une itération indexée, parcourez la collection à l’envers afin que chaque index restant reste valide.

Cet exemple supprime chaque forme portant un nom désigné. Il lit `slide.Shapes[i]`, pas un élément de collection fixe, et il ne convertit pas la forme de manière superflue.

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

Après la suppression, le nombre de formes et les index des formes suivantes changent. Les références aux formes non affectées restent plus fiables que des index enregistrés. Pensez également aux connecteurs, aux animations et aux autres fonctionnalités de la présentation qui peuvent référencer l’objet supprimé ; supprimer une forme visible peut affecter plus que l’apparence de la diapositive.

### **Masquer une forme**

Définir [Hidden](https://reference.aspose.com/slides/fr/net/aspose.slides/ishape/hidden/) à `true` conserve la forme dans la collection mais l’empêche d’apparaître lors du diaporama normal. Son index, son formatage et son contenu restent accessibles au code, ainsi masquer est approprié pour des éléments optionnels qui peuvent être restaurés plus tard.

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

Masquer n’est ni une suppression ni une mesure de sécurité. L’objet peut toujours être découvert et rendu visible à nouveau par un utilisateur ou par du code, et il reste partie du fichier de présentation.

### **Modifier l’ordre Z**

Les formes qui se chevauchent sont peintes suivant l’ordre de la collection. [Reorder](https://reference.aspose.com/slides/fr/net/aspose.slides/ishapecollection/reorder/) déplace une forme existante vers un index cible sans la cloner. L’index `0` est l’arrière ; `Count - 1` est l’avant.

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

Le rectangle est créé en premier et se situe initialement derrière l’ellipse. Le déplacer vers l’index final le place à l’avant. Finalisez l’ordre Z après avoir ajouté ou cloné toutes les formes liées, car ces opérations ajoutent ou insèrent de nouveaux éléments de collection et peuvent modifier la pile prévue.

## **Inspecter les formes des diapositives de mise en page**

Les diapositives normales, les diapositives de mise en page et les diapositives maîtres possèdent des collections de formes séparées. Une forme dans une collection de mise en page n’est pas le même objet qu’une forme positionnée de façon similaire sur une diapositive normale. Inspectez les formes de mise en page lorsque vous devez comprendre ou modifier le formatage fourni par une mise en page.

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

Modifier une mise en page peut affecter plusieurs diapositives qui l’utilisent. Avant de changer une forme de mise en page, déterminez si une diapositive normale hérite de l’objet ou contient une surcharge locale, et testez chaque diapositive qui utilise cette mise en page.

## **Exporter une forme au format SVG**

[WriteAsSvg](https://reference.aspose.com/slides/fr/net/aspose.slides/ishape/writeassvg/) écrit le contenu rendu d’une forme dans un flux. Le résultat contient uniquement la forme, pas l’arrière‑plan complet de la diapositive ni les formes voisines.

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

Gardez la présentation ouverte pendant le rendu. Le rendu dépend du formatage de la forme ainsi que des ressources telles que les polices et les images. Si vous avez besoin de toute la composition, exportez la diapositive plutôt qu’une forme individuelle. L’appelant possède le flux et doit le libérer.

## **Aligner les formes**

Les surcharge de [SlideUtil.AlignShapes](https://reference.aspose.com/slides/fr/net/aspose.slides.util/slideutil/alignshapes/) alignent soit toutes les formes, soit les index de collection sélectionnés. [ShapesAlignmentType](https://reference.aspose.com/slides/fr/net/aspose.slides/shapesalignmenttype/) spécifie le bord, la ligne centrale ou le mode de distribution. Définissez `alignToSlide` à `true` pour utiliser les bords de la diapositive ; définissez‑le à `false` pour aligner les formes sélectionnées les unes par rapport aux autres.

Cet exemple aligne trois formes sur le bord supérieur de la diapositive. Les références de forme renvoyées sont converties en leurs index actuels immédiatement avant l’alignement.

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

L’alignement modifie les positions, pas l’ordre Z. Un alignement relatif nécessite généralement au moins deux formes, tandis qu’une distribution horizontale ou verticale requiert suffisamment de formes pour définir l’espacement. Recalculez les index si vous modifiez la collection avant d’appeler la méthode.

## **Retournement d’une forme**

La classe [ShapeFrame](https://reference.aspose.com/slides/fr/net/aspose.slides/shapeframe/) stocke la position, la taille, les paramètres de retournement horizontal et vertical, et la rotation. Ses valeurs `FlipH` et `FlipV` utilisent [NullableBool](https://reference.aspose.com/slides/fr/net/aspose.slides/nullablebool/) : `True` active le retournement, `False` le désactive, et `NotDefined` préserve l’état non spécifié/par défaut.

La présentation d’entrée ci‑dessous contient une forme non retournée.

![La forme avant le retournement](shape_to_be_flipped.png)

L’exemple conserve toutes les autres valeurs du cadre et ne remplace que les deux paramètres de retournement. C’est important car l’attribution d’un nouveau [Frame](https://reference.aspose.com/slides/fr/net/aspose.slides/ishape/frame/) remplace le cadre complet.

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

![La forme après le retournement](flipped_shape.png)

## **FAQ**

**Dois‑je utiliser un index de collection comme identifiant de forme ?**

Uniquement pour un traitement de courte durée lorsque la collection ne changera pas avant l’utilisation de l’index. Privilégiez une convention validée `Name` ou `AlternativeText` pour les modèles créés, ou `OfficeInteropShapeId` pour le travail d’interopérabilité au niveau de la diapositive.

**Masquer une forme la retire‑t‑elle de l’ordre Z ?**

Non. Une forme masquée reste dans la collection au même index. Elle peut être trouvée, ré‑ordonnée, modifiée ou rendue à nouveau visible.

**Pourquoi une forme clonée apparaît‑elle devant une autre forme ?**

`AddClone` ajoute le clone à la fin de la collection, ce qui correspond à l’avant de l’ordre Z. Utilisez `InsertClone` pour choisir l’index initial ou `Reorder` après avoir ajouté toutes les formes.

**Puis‑je utiliser un index fixe pour identifier un ajustement de forme prédéfini ?**

Seulement après avoir validé le préréglage exact et la disposition de la collection. Privilégiez l’itération sur `IGeometryShape.Adjustments` et la vérification de `IAdjustValue.Type` ; utilisez `IAdjustValue.Name` comme information supplémentaire lorsque le même type sémantique apparaît plusieurs fois.