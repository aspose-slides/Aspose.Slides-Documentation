---
title: Mise en forme des formes PowerPoint en .NET
linktitle: Mise en forme des formes
type: docs
weight: 20
url: /fr/net/shape-formatting/
keywords:
- mise en forme de forme
- mise en forme de ligne
- effet de croquis
- ligne de forme esquissée
- mise en forme du style de jointure
- remplissage en dégradé
- remplissage motif
- remplissage image
- remplissage texture
- remplissage couleur unie
- transparence de forme
- rendu forme noir et blanc
- rendu forme en niveaux de gris
- rotation de forme
- effet biseau 3D
- effet rotation 3D
- réinitialiser la mise en forme
- PowerPoint
- présentation
- .NET
- C#
- Aspose.Slides
description: "Apprenez à mettre en forme les formes PowerPoint en C# avec Aspose.Slides — définissez les styles de remplissage, de ligne et d’effet pour les fichiers PPT et PPTX avec précision et un contrôle total."
---
## **Introduction**

Dans PowerPoint, vous pouvez ajouter des formes aux diapositives. Étant donné que les formes sont composées de lignes, vous pouvez les mettre en forme en modifiant ou en appliquant des effets à leurs contours. De plus, vous pouvez formater les formes en spécifiant des paramètres qui contrôlent la façon dont leurs intérieurs sont remplis.

![format-forme-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for .NET fournit des interfaces et des propriétés qui vous permettent de mettre en forme les formes en utilisant les mêmes options disponibles dans PowerPoint.

## **Format des lignes**

En utilisant Aspose.Slides, vous pouvez spécifier un style de ligne personnalisé pour une forme. Les étapes suivantes décrivent la procédure :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Obtenez une référence à une diapositive par son index.
1. Ajoutez un [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) à la diapositive.
1. Définissez le [style de ligne](https://reference.aspose.com/slides/net/aspose.slides/linestyle/) de la forme.
1. Définissez la largeur de la ligne.
1. Définissez le [style de tirets](https://reference.aspose.com/slides/net/aspose.slides/linedashstyle/) de la ligne.
1. Définissez la couleur de la ligne pour la forme.
1. Enregistrez la présentation modifiée en tant que fichier PPTX.

Le code C# suivant montre comment formater un rectangle `AutoShape` :

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Instancier la classe Presentation qui représente un fichier de présentation.
using (Presentation presentation = new Presentation())
{
    // Obtenir la première diapositive.
    ISlide slide = presentation.Slides[0];

    // Ajouter une forme auto de type Rectangle.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Définir la couleur de remplissage pour la forme rectangle.
    shape.FillFormat.FillType = FillType.NoFill;

    // Appliquer la mise en forme aux lignes du rectangle.
    shape.LineFormat.Style = LineStyle.ThickThin;
    shape.LineFormat.Width = 7;
    shape.LineFormat.DashStyle = LineDashStyle.Dash;

    // Définir la couleur de la ligne du rectangle.
    shape.LineFormat.FillFormat.FillType = FillType.Solid;
    shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;

    // Enregistrer le fichier PPTX sur le disque.
    presentation.Save("formatted_lines.pptx", SaveFormat.Pptx);
}
```

Le résultat :

![Les lignes formatées dans la présentation](formatted-lines.png)

## **Appliquer des effets de croquis aux lignes de forme**

Un effet de croquis rend la ligne d’une forme semblable à un dessin à la main. Utilisez [IShape.LineFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/lineformat/) pour accéder aux paramètres de ligne, [ILineFormat.SketchFormat](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/sketchformat/) pour accéder aux paramètres de croquis, et [ISketchFormat.SketchType](https://reference.aspose.com/slides/net/aspose.slides/isketchformat/sketchtype/) pour sélectionner une valeur dans l’énumération [LineSketchType](https://reference.aspose.com/slides/net/aspose.slides/linesketchtype/).

Le code C# suivant montre comment appliquer un effet [LineSketchType.Curved](https://reference.aspose.com/slides/net/aspose.slides/linesketchtype/) , lire la valeur explicitement assignée, et supprimer l’effet avec [LineSketchType.None](https://reference.aspose.com/slides/net/aspose.slides/linesketchtype/) :

```csharp
using Aspose.Slides;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);

// Access the shape's line format and its sketch format.
var sketchFormat = shape.LineFormat.SketchFormat;

// Apply a sketch effect.
sketchFormat.SketchType = LineSketchType.Curved;

// Read the sketch effect assigned directly to the shape.
var explicitSketchType = sketchFormat.SketchType;
Console.WriteLine($"Explicit sketch type: {explicitSketchType}");

// Remove the sketch effect.
sketchFormat.SketchType = LineSketchType.None;
```

La valeur renvoyée par `ISketchFormat.SketchType` représente le paramètre affecté directement à la forme. Si la mise en forme de la ligne peut être héritée d’un thème, d’une diapositive maîtresse ou d’une diapositive de mise en page, utilisez [ILineFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/geteffective/), accédez à [ILineFormatEffectiveData.SketchFormat](https://reference.aspose.com/slides/net/aspose.slides/ilineformateffectivedata/sketchformat/), et lisez [ISketchFormatEffectiveData.SketchType](https://reference.aspose.com/slides/net/aspose.slides/isketchformateffectivedata/sketchtype/). La valeur effective reflète la mise en forme réellement appliquée après résolution de l’héritage :

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

var shape = presentation.Slides[0].Shapes[0];
var lineFormat = shape.LineFormat;

var explicitSketchType = lineFormat.SketchFormat.SketchType;
var effectiveLineFormat = lineFormat.GetEffective();
var effectiveSketchType = effectiveLineFormat.SketchFormat.SketchType;

Console.WriteLine($"Explicit sketch type: {explicitSketchType}");
Console.WriteLine($"Effective sketch type: {effectiveSketchType}");
```

## **Format des styles de jointure**

Voici les trois options de type de jointure :

* Arrondi
* Mitre
* Biseau

Par défaut, lorsque PowerPoint joint deux lignes à un angle (comme au coin d’une forme), il utilise le paramètre **Arrondi**. Cependant, si vous dessinez une forme avec des angles vifs, vous pouvez préférer l’option **Mitre**.

![Le style de jointure dans la présentation](join-style-powerpoint.png)

Le code C# suivant montre comment trois rectangles (comme dans l’image ci‑dessus) ont été créés en utilisant les paramètres de type de jointure Mitre, Biseau et Arrondi :

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Instancier la classe Presentation qui représente un fichier de présentation.
using (Presentation presentation = new Presentation())
{
    // Obtenir la première diapositive.
    ISlide slide = presentation.Slides[0];

    // Ajouter trois formes automatiques de type Rectangle.
    IAutoShape shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 75);
    IAutoShape shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 210, 20, 150, 75);
    IAutoShape shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 135, 150, 75);

    // Définir la couleur de remplissage pour chaque forme rectangle.
    shape1.FillFormat.FillType = FillType.Solid;
    shape1.FillFormat.SolidFillColor.Color = Color.Black;
    shape2.FillFormat.FillType = FillType.Solid;
    shape2.FillFormat.SolidFillColor.Color = Color.Black;
    shape3.FillFormat.FillType = FillType.Solid;
    shape3.FillFormat.SolidFillColor.Color = Color.Black;

    // Définir la largeur de la ligne.
    shape1.LineFormat.Width = 15;
    shape2.LineFormat.Width = 15;
    shape3.LineFormat.Width = 15;

    // Définir la couleur de la ligne de chaque rectangle.
    shape1.LineFormat.FillFormat.FillType = FillType.Solid;
    shape1.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    shape2.LineFormat.FillFormat.FillType = FillType.Solid;
    shape2.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    shape3.LineFormat.FillFormat.FillType = FillType.Solid;
    shape3.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;

    // Définir le style de jointure.
    shape1.LineFormat.JoinStyle = LineJoinStyle.Miter;
    shape2.LineFormat.JoinStyle = LineJoinStyle.Bevel;
    shape3.LineFormat.JoinStyle = LineJoinStyle.Round;

    // Ajouter du texte à chaque rectangle.
    shape1.TextFrame.Text = "Miter Join Style";
    shape2.TextFrame.Text = "Bevel Join Style";
    shape3.TextFrame.Text = "Round Join Style";

    // Enregistrer le fichier PPTX sur le disque.
    presentation.Save("join_styles.pptx", SaveFormat.Pptx);
}
```

## **Remplissage en dégradé**

Dans PowerPoint, le remplissage en dégradé est une option de mise en forme qui vous permet d’appliquer un mélange continu de couleurs à une forme. Par exemple, vous pouvez appliquer deux couleurs ou plus de manière à ce que l’une se fonde progressivement dans l’autre.

Voici comment appliquer un remplissage en dégradé à une forme avec Aspose.Slides :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Obtenez une référence à une diapositive par son index.
1. Ajoutez un [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) à la diapositive.
1. Définissez le [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) de la forme sur `Gradient`.
1. Ajoutez vos deux couleurs préférées avec des positions définies en utilisant les méthodes `Add` de la collection d’arrêts de dégradé exposée par l’interface [IGradientFormat](https://reference.aspose.com/slides/net/aspose.slides/igradientformat/).
1. Enregistrez la présentation modifiée en tant que fichier PPTX.

Le code C# suivant montre comment appliquer un effet de remplissage en dégradé à une ellipse :

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Instancier la classe Presentation qui représente un fichier de présentation.
using (Presentation presentation = new Presentation())
{
    // Obtenir la première diapositive.
    ISlide slide = presentation.Slides[0];

    // Ajouter une forme automatique de type Ellipse.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // Appliquer le formatage en dégradé à l'ellipse.
    shape.FillFormat.FillType = FillType.Gradient;
    shape.FillFormat.GradientFormat.GradientShape = GradientShape.Linear;

    // Définir la direction du dégradé.
    shape.FillFormat.GradientFormat.GradientDirection = GradientDirection.FromCorner2;

    // Ajouter deux arrêts de dégradé.
    shape.FillFormat.GradientFormat.GradientStops.Add(1.0f, PresetColor.Purple);
    shape.FillFormat.GradientFormat.GradientStops.Add(0.0f, PresetColor.Red);

    // Enregistrer le fichier PPTX sur le disque.
    presentation.Save("gradient_fill.pptx", SaveFormat.Pptx);
}
```

Le résultat :

![L’ellipse avec remplissage en dégradé](gradient-fill.png)

Si un dégradé apparaît différemment dans une image exportée que dans PowerPoint, consultez [Choose a Gradient Rendering Style](/slides/fr/net/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). Vous pouvez sélectionner un style de rendu sans modifier le remplissage en dégradé stocké dans la présentation.

## **Remplissage de motif**

Dans PowerPoint, le remplissage de motif est une option de mise en forme qui vous permet d’appliquer un motif à deux couleurs—tel que des points, des bandes, des hachures ou des damiers—a une forme. Vous pouvez choisir des couleurs personnalisées pour le premier plan et l’arrière‑plan du motif.

Aspose.Slides propose plus de 45 styles de motif prédéfinis que vous pouvez appliquer aux formes pour améliorer l’apparence visuelle de vos présentations. Même après avoir sélectionné un motif prédéfini, vous pouvez toujours spécifier les couleurs exactes à utiliser.

Voici comment appliquer un remplissage de motif à une forme avec Aspose.Slides :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Obtenez une référence à une diapositive par son index.
1. Ajoutez un [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) à la diapositive.
1. Définissez le [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) de la forme sur `Pattern`.
1. Choisissez un style de motif parmi les options prédéfinies.
1. Définissez la [Couleur d'arrière-plan](https://reference.aspose.com/slides/net/aspose.slides/ipatternformat/backcolor/) du motif.
1. Définissez la [Couleur d'avant-plan](https://reference.aspose.com/slides/net/aspose.slides/ipatternformat/forecolor/) du motif.
1. Enregistrez la présentation modifiée en tant que fichier PPTX.

Le code C# suivant montre comment appliquer un remplissage de motif à un rectangle :

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Instancier la classe Presentation qui représente un fichier de présentation.
using (Presentation presentation = new Presentation())
{
    // Obtenir la première diapositive.
    ISlide slide = presentation.Slides[0];

    // Ajouter une forme automatique de type Rectangle.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Définir le type de remplissage sur Pattern.
    shape.FillFormat.FillType = FillType.Pattern;

    // Définir le style du motif.
    shape.FillFormat.PatternFormat.PatternStyle = PatternStyle.Trellis;

    // Définir les couleurs d'arrière-plan et d'avant-plan du motif.
    shape.FillFormat.PatternFormat.BackColor.Color = Color.LightGray;
    shape.FillFormat.PatternFormat.ForeColor.Color = Color.Yellow;

    // Enregistrer le fichier PPTX sur le disque.
    presentation.Save("pattern_fill.pptx", SaveFormat.Pptx);
}
```

Le résultat :

![Le rectangle avec remplissage de motif](pattern-fill.png)

## **Remplissage d’image**

Dans PowerPoint, le remplissage d’image est une option de mise en forme qui vous permet d’insérer une image à l’intérieur d’une forme—utilisant effectivement l’image comme arrière‑plan de la forme.

Voici comment appliquer un remplissage d’image à une forme avec Aspose.Slides :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Obtenez une référence à une diapositive par son index.
1. Ajoutez un [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) à la diapositive.
1. Définissez le [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) de la forme sur `Picture`.
1. Définissez le mode de remplissage d’image sur `Tile` (ou un autre mode préféré).
1. Créez un objet [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/) à partir de l’image que vous souhaitez utiliser.
1. Assignez cette image à la propriété `Picture.Image` du `PictureFillFormat` de la forme.
1. Enregistrez la présentation modifiée en tant que fichier PPTX.

Supposons que nous ayons un fichier « lotus.png » avec l’image suivante :

![The lotus picture](lotus.png)

Le code C# suivant montre comment remplir une forme avec l’image :

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Instancier la classe Presentation qui représente un fichier de présentation.
using (Presentation presentation = new Presentation())
{
    // Obtenir la première diapositive.
    ISlide slide = presentation.Slides[0];

    // Ajouter une forme automatique de type Rectangle.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);

    // Définir le type de remplissage sur Picture.
    shape.FillFormat.FillType = FillType.Picture;

    // Définir le mode de remplissage d'image.
    shape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Tile;

    // Charger une image et l'ajouter aux ressources de la présentation.
    IImage image = Images.FromFile("lotus.png");
    IPPImage presentationImage = presentation.Images.AddImage(image);
    image.Dispose();

    // Définir l'image.
    shape.FillFormat.PictureFillFormat.Picture.Image = presentationImage;

    // Enregistrer le fichier PPTX sur le disque.
    presentation.Save("picture_fill.pptx", SaveFormat.Pptx);
}
```

Le résultat :

![La forme avec remplissage d’image](picture-fill.png)

### **Image en mosaïque comme texture**

Si vous souhaitez définir une image en mosaïque comme texture et personnaliser le comportement du carrelage, vous pouvez utiliser les propriétés suivantes de l’interface [IPictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/) et de la classe [PictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/) :

- [PictureFillMode](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/picturefillmode/): Définissez le mode de remplissage d’image—soit `Tile` soit `Stretch`.
- [TileAlignment](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tilealignment/): Spécifie l’alignement des carreaux à l’intérieur de la forme.
- [TileFlip](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tileflip/): Contrôle si le carreau est retourné horizontalement, verticalement ou les deux.
- [TileOffsetX](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tileoffsetx/): Définissez le décalage horizontal du carreau (en points) depuis l’origine de la forme.
- [TileOffsetY](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tileoffsety/): Définissez le décalage vertical du carreau (en points) depuis l’origine de la forme.
- [TileScaleX](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tilescalex/): Définissez l’échelle horizontale du carreau en pourcentage.
- [TileScaleY](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tilescaley/): Définissez l’échelle verticale du carreau en pourcentage.

Le code d’exemple suivant montre comment ajouter une forme rectangle avec un remplissage d’image en mosaïque et configurer les options de carrelage :

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Instancier la classe Presentation qui représente un fichier de présentation.
using (Presentation presentation = new Presentation())
{
    // Obtenir la première diapositive.
    ISlide firstSlide = presentation.Slides[0];

    // Ajouter une forme auto de type Rectangle.
    IAutoShape shape = firstSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

    // Définir le type de remplissage de la forme sur Picture.
    shape.FillFormat.FillType = FillType.Picture;

    // Charger l'image et l'ajouter aux ressources de la présentation.
    IPPImage presentationImage;
    using (IImage sourceImage = Images.FromFile("lotus.png"))
        presentationImage = presentation.Images.AddImage(sourceImage);

    // Attribuer l'image à la forme.
    IPictureFillFormat pictureFillFormat = shape.FillFormat.PictureFillFormat;
    pictureFillFormat.Picture.Image = presentationImage;

    // Configurer le mode de remplissage d'image et les propriétés de carrelage.
    pictureFillFormat.PictureFillMode = PictureFillMode.Tile;
    pictureFillFormat.TileOffsetX = -32;
    pictureFillFormat.TileOffsetY = -32;
    pictureFillFormat.TileScaleX = 50;
    pictureFillFormat.TileScaleY = 50;
    pictureFillFormat.TileAlignment = RectangleAlignment.BottomRight;
    pictureFillFormat.TileFlip = TileFlip.FlipBoth;

    // Enregistrer le fichier PPTX sur le disque.
    presentation.Save("tile.pptx", SaveFormat.Pptx);
}
```

Le résultat :

![Les options de carrelage](tile-options.png)

## **Remplissage couleur unie**

Dans PowerPoint, le remplissage couleur unie est une option de mise en forme qui remplit une forme d’une couleur unique et uniforme. Cette couleur d’arrière‑plan simple est appliquée sans aucun dégradé, texture ou motif.

Pour appliquer un remplissage couleur unie à une forme avec Aspose.Slides, suivez ces étapes :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Obtenez une référence à une diapositive par son index.
1. Ajoutez un [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) à la diapositive.
1. Définissez le [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) de la forme sur `Solid`.
1. Assignez votre couleur de remplissage préférée à la forme.
1. Enregistrez la présentation modifiée en tant que fichier PPTX.

Le code C# suivant montre comment appliquer un remplissage couleur unie à un rectangle dans une diapositive PowerPoint :

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Instancier la classe Presentation qui représente un fichier de présentation.
using (Presentation presentation = new Presentation())
{
    // Obtenir la première diapositive.
    ISlide slide = presentation.Slides[0];

    // Ajouter une forme automatique de type Rectangle.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Définir le type de remplissage sur Solid.
    shape.FillFormat.FillType = FillType.Solid;

    // Définir la couleur de remplissage.
    shape.FillFormat.SolidFillColor.Color = Color.Yellow;

    // Enregistrer le fichier PPTX sur le disque.
    presentation.Save("solid_color_fill.pptx", SaveFormat.Pptx);
}
```

Le résultat :

![La forme avec remplissage couleur unie](solid-color-fill.png)

## **Définir la transparence**

Dans PowerPoint, lorsque vous appliquez un remplissage couleur unie, en dégradé, image ou texture à des formes, vous pouvez également définir un niveau de transparence pour contrôler l’opacité du remplissage. Une valeur de transparence plus élevée rend la forme plus translucide, permettant au fond ou aux objets sous‑jacent d’être partiellement visibles.

Aspose.Slides vous permet de définir le niveau de transparence en ajustant la composante alpha de la couleur utilisée pour le remplissage. Voici comment procéder :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Obtenez une référence à une diapositive par son index.
1. Ajoutez un [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) à la diapositive.
1. Définissez le [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) sur `Solid`.
1. Utilisez `Color.FromArgb(alpha, baseColor)` pour définir une couleur avec transparence (la composante `alpha` contrôle la transparence).
1. Enregistrez la présentation.

Le code C# suivant montre comment appliquer une couleur de remplissage transparente à un rectangle :

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

const int alpha = 128;

// Instancier la classe Presentation qui représente un fichier de présentation.
using (Presentation presentation = new Presentation())
{
    // Obtenir la première diapositive.
    ISlide slide = presentation.Slides[0];

    // Ajouter une forme auto solide de type Rectangle.
    IAutoShape solidShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Ajouter une forme auto transparente de type Rectangle au-dessus de la forme solide.
    IAutoShape transparentShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.FillFormat.FillType = FillType.Solid;
    transparentShape.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Yellow);

    // Enregistrer le fichier PPTX sur le disque.
    presentation.Save("shape_transparency.pptx", SaveFormat.Pptx);
}
```

Le résultat :

![La forme transparente](shape-transparency.png)

## **Faire pivoter les formes**

Aspose.Slides vous permet de faire pivoter les formes dans les présentations PowerPoint. Cela peut être utile lors du positionnement d’éléments visuels avec des exigences d’alignement ou de conception spécifiques.

Pour faire pivoter une forme sur une diapositive, suivez ces étapes :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Obtenez une référence à une diapositive par son index.
1. Ajoutez un [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) à la diapositive.
1. Définissez la propriété `Rotation` de la forme sur l’angle souhaité.
1. Enregistrez la présentation.

Le code C# suivant montre comment faire pivoter une forme de 5 degrés :

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Instancier la classe Presentation qui représente un fichier de présentation.
using (Presentation presentation = new Presentation())
{
    // Obtenir la première diapositive.
    ISlide slide = presentation.Slides[0];

    // Ajouter une forme automatique de type Rectangle.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Faire pivoter la forme de 5 degrés.
    shape.Rotation = 5;

    // Enregistrer le fichier PPTX sur le disque.
    presentation.Save("shape_rotation.pptx", SaveFormat.Pptx);
}
```

Le résultat :

![La rotation de la forme](shape-rotation.png)

## **Ajouter des effets de biseau 3D**

Aspose.Slides permet d’appliquer des effets de biseau 3D aux formes en configurant leurs propriétés [ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/threedformat/).

Pour ajouter des effets de biseau 3D à une forme, suivez ces étapes :

1. Instanciez la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Obtenez une référence à une diapositive par son index.
1. Ajoutez un [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) à la diapositive.
1. Configurez le [ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/threedformat/) de la forme pour définir les paramètres de biseau.
1. Enregistrez la présentation.

Le code C# suivant montre comment appliquer des effets de biseau 3D à une forme :

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Créer une instance de la classe Presentation.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Ajouter une forme à la diapositive.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 50, 100, 100);
    shape.FillFormat.FillType = FillType.Solid;
    shape.FillFormat.SolidFillColor.Color = Color.Green;
    shape.LineFormat.FillFormat.FillType = FillType.Solid;
    shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Orange;
    shape.LineFormat.Width = 2.0;

    // Définir les propriétés ThreeDFormat de la forme.
    shape.ThreeDFormat.Depth = 4;
    shape.ThreeDFormat.BevelTop.BevelType = BevelPresetType.Circle;
    shape.ThreeDFormat.BevelTop.Height = 6;
    shape.ThreeDFormat.BevelTop.Width = 6;
    shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
    shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.ThreePt;
    shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;

    // Enregistrer la présentation au format PPTX.
    presentation.Save("3D_bevel_effect.pptx", SaveFormat.Pptx);
}
```

Le résultat :

![L’effet de biseau 3D](3D-bevel-effect.png)

## **Ajouter des effets de rotation 3D**

Aspose.Slides permet d’appliquer des effets de rotation 3D aux formes en configurant leurs propriétés [ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/threedformat/).

Pour appliquer une rotation 3D à une forme :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Obtenez une référence à une diapositive par son index.
1. Ajoutez un [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) à la diapositive.
1. Définissez le [CameraType](https://reference.aspose.com/slides/net/aspose.slides/icamera/cameratype/) et le [LightType](https://reference.aspose.com/slides/net/aspose.slides/ilightrig/lighttype/) de la forme pour définir la rotation 3D.
1. Enregistrez la présentation.

Le code C# suivant montre comment appliquer des effets de rotation 3D à une forme :

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Créer une instance de la classe Presentation.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    autoShape.TextFrame.Text = "Hello, Aspose!";

    autoShape.ThreeDFormat.Camera.SetRotation(40, 35, 20);
    autoShape.ThreeDFormat.Camera.CameraType = CameraPresetType.IsometricLeftUp;
    autoShape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;

    // Enregistrer la présentation au format PPTX.
    presentation.Save("3D_rotation_effect.pptx", SaveFormat.Pptx);
}
```

Le résultat :

![L’effet de rotation 3D](3D-rotation-effect.png)

## **Contrôler le rendu noir et blanc pour les formes**

La propriété [IShape.BlackWhiteMode](https://reference.aspose.com/slides/net/aspose.slides/ishape/blackwhitemode/) indique comment une forme individuelle est rendue lorsqu’une présentation est affichée ou traitée en mode noir et blanc. Elle ne déclenche pas l’affichage en noir et blanc en soi, et elle ne modifie pas le remplissage, la ligne ou tout autre formatage de la forme en mode couleur normal.

Utilisez une valeur de l’énumération [BlackWhiteMode](https://reference.aspose.com/slides/net/aspose.slides/blackwhitemode/) pour sélectionner le comportement souhaité. Par exemple, `Automatic` laisse l’application de rendu choisir la conversion, `Gray` et `LightGray` utilisent le gris, `BlackWhite` utilise uniquement le noir et blanc, `Black` et `White` forcent une couleur unique, `Color` préserve la couleur normale, et `Hidden` omet la forme en mode noir et blanc. `NotDefined` signifie qu’aucun mode au niveau de la forme n’est assigné.

Le code C# suivant crée une forme colorée et la fait apparaître en gris en mode d’affichage noir et blanc :

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.Orange;

// Conserver le remplissage orange en mode couleur, mais afficher la forme en gris en mode noir et blanc.
shape.BlackWhiteMode = BlackWhiteMode.Gray;

presentation.Save("shape_black_white_mode.pptx", SaveFormat.Pptx);
```

En mode couleur normal, le rectangle conserve son remplissage orange. En flux de travail d’affichage noir et blanc, il utilise le gris parce que son mode est réglé sur `Gray`. Cela vous permet de préserver une diapositive en couleur complète tout en définissant un aspect distinct pour l’impression, la prévisualisation ou d’autres flux de travail qui respectent les paramètres d’affichage noir et blanc de la présentation.

## **Réinitialiser la mise en forme**

Le code C# suivant montre comment réinitialiser le formatage d’une diapositive et restaurer la position, la taille et le formatage de toutes les formes avec espaces réservés sur le [LayoutSlide](https://reference.aspose.com/slides/net/aspose.slides/layoutslide/) à leurs paramètres par défaut :

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    foreach (ISlide slide in presentation.Slides)
    {
        // Réinitialiser chaque forme sur la diapositive qui possède un espace réservé sur la mise en page.
        slide.Reset();
    }

    presentation.Save("reset_formatting.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Le formatage des formes affecte-t-il la taille finale du fichier de la présentation ?**

Seulement de façon minime. Les images et médias incorporés occupent la majeure partie de l’espace du fichier, tandis que les paramètres de forme tels que les couleurs, effets et dégradés sont stockés comme métadonnées et n’ajoutent pratiquement aucune taille supplémentaire.

**Comment détecter les formes sur une diapositive qui partagent le même formatage afin de les regrouper ?**

Comparez les propriétés de format clés de chaque forme — remplissage, ligne et paramètres d’effet. Si toutes les valeurs correspondantes sont identiques, considérez leurs styles comme identiques et regroupez logiquement ces formes, ce qui simplifie la gestion des styles ultérieure.

**Puis-je enregistrer un ensemble de styles de forme personnalisés dans un fichier séparé pour les réutiliser dans d’autres présentations ?**

Oui. Stockez des formes d’exemple avec les styles souhaités dans un jeu de diapositives modèle ou un fichier modèle .POTX. Lors de la création d’une nouvelle présentation, ouvrez le modèle, clonez les formes stylisées dont vous avez besoin, et réappliquez leur formatage où nécessaire.