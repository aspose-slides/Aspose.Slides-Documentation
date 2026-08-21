---
title: Formater les formes PowerPoint en .NET
linktitle: Format de forme
type: docs
weight: 20
url: /fr/net/shape-formatting/
keywords:
- format de forme
- format de ligne
- effet de croquis
- ligne de forme en croquis
- format du style de jointure
- remplissage dégradé
- remplissage de motif
- remplissage d’image
- remplissage de texture
- remplissage de couleur unie
- transparence de forme
- rendu noir et blanc de la forme
- rendu en niveaux de gris de la forme
- rotation de forme
- effet de biseau 3D
- effet de rotation 3D
- réinitialiser le formatage
- PowerPoint
- présentation
- .NET
- C#
- Aspose.Slides
description: "Apprenez à formater les formes PowerPoint en C# avec Aspose.Slides—définissez les styles de remplissage, de ligne et d’effet pour les fichiers PPT et PPTX avec précision et contrôle total."
---
## **Introduction**

Dans PowerPoint, vous pouvez ajouter des formes aux diapositives. Les formes étant composées de lignes, vous pouvez les formater en modifiant ou en appliquant des effets à leurs contours. De plus, vous pouvez formater les formes en définissant des paramètres qui contrôlent le remplissage de leurs intérieurs.

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for .NET fournit des interfaces et des propriétés qui vous permettent de formater les formes avec les mêmes options disponibles dans PowerPoint.

## **Format Lines**

Avec Aspose.Slides, vous pouvez spécifier un style de ligne personnalisé pour une forme. Les étapes suivantes décrivent la procédure :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/).
1. Obtenez une référence à une diapositive par son index.
1. Ajoutez un [IAutoShape](https://reference.aspose.com/slides/fr/net/aspose.slides/iautoshape/) à la diapositive.
1. Définissez le [line style](https://reference.aspose.com/slides/fr/net/aspose.slides/linestyle/) de la forme.
1. Définissez la largeur de la ligne.
1. Définissez le [dash style](https://reference.aspose.com/slides/fr/net/aspose.slides/linedashstyle/) de la ligne.
1. Définissez la couleur de la ligne pour la forme.
1. Enregistrez la présentation modifiée au format PPTX.

Le code C# suivant montre comment formater un `AutoShape` rectangle :

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Instancie la classe Presentation qui représente un fichier de présentation.
using (Presentation presentation = new Presentation())
{
    // Obtient la première diapositive.
    ISlide slide = presentation.Slides[0];

    // Ajoute une forme auto de type Rectangle.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Définit la couleur de remplissage pour la forme rectangle.
    shape.FillFormat.FillType = FillType.NoFill;

    // Applique le formatage aux lignes du rectangle.
    shape.LineFormat.Style = LineStyle.ThickThin;
    shape.LineFormat.Width = 7;
    shape.LineFormat.DashStyle = LineDashStyle.Dash;

    // Définit la couleur de la ligne du rectangle.
    shape.LineFormat.FillFormat.FillType = FillType.Solid;
    shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;

    // Enregistre le fichier PPTX sur le disque.
    presentation.Save("formatted_lines.pptx", SaveFormat.Pptx);
}
```

Résultat :

![The formatted lines in the presentation](formatted-lines.png)

## **Apply Sketch Effects to Shape Lines**

Un effet de croquis rend la ligne d’une forme semblable à un tracé à main levée. Utilisez [IShape.LineFormat](https://reference.aspose.com/slides/fr/net/aspose.slides/ishape/lineformat/) pour accéder aux paramètres de ligne, [ILineFormat.SketchFormat](https://reference.aspose.com/slides/fr/net/aspose.slides/ilineformat/sketchformat/) pour accéder aux paramètres de croquis, et [ISketchFormat.SketchType](https://reference.aspose.com/slides/fr/net/aspose.slides/isketchformat/sketchtype/) pour choisir une valeur dans l’énumération [LineSketchType](https://reference.aspose.com/slides/fr/net/aspose.slides/linesketchtype/).

Le code C# suivant montre comment appliquer l’effet [LineSketchType.Curved](https://reference.aspose.com/slides/fr/net/aspose.slides/linesketchtype/), lire la valeur attribuée explicitement, et supprimer l’effet avec [LineSketchType.None](https://reference.aspose.com/slides/fr/net/aspose.slides/linesketchtype/) :

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

La valeur renvoyée par `ISketchFormat.SketchType` représente le paramètre attribué directement à la forme. Si le formatage de ligne peut être hérité d’un thème, d’une diapositive maîtresse ou d’une diapositive de mise en page, utilisez [ILineFormat.GetEffective](https://reference.aspose.com/slides/fr/net/aspose.slides/ilineformat/geteffective/), accédez à [ILineFormatEffectiveData.SketchFormat](https://reference.aspose.com/slides/fr/net/aspose.slides/ilineformateffectivedata/sketchformat/), et lisez [ISketchFormatEffectiveData.SketchType](https://reference.aspose.com/slides/fr/net/aspose.slides/isketchformateffectivedata/sketchtype/). La valeur effective reflète le formatage réellement appliqué après résolution de l’héritage :

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

## **Format Join Styles**

Voici les trois options de type de jointure :

* Round
* Miter
* Bevel

Par défaut, lorsque PowerPoint joint deux lignes à un angle (par exemple au coin d’une forme), il utilise le paramètre **Round**. Cependant, si vous dessinez une forme avec des angles aigus, vous pouvez préférer l’option **Miter**.

![The join style in the presentation](join-style-powerpoint.png)

Le code C# suivant montre comment trois rectangles (illustrés sur l’image ci‑dessus) ont été créés en utilisant les paramètres de jointure Miter, Bevel et Round :

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Instancie la classe Presentation qui représente un fichier de présentation.
using (Presentation presentation = new Presentation())
{
    // Obtient la première diapositive.
    ISlide slide = presentation.Slides[0];

    // Ajoute trois formes automatiques de type Rectangle.
    IAutoShape shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 75);
    IAutoShape shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 210, 20, 150, 75);
    IAutoShape shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 135, 150, 75);

    // Définit la couleur de remplissage pour chaque forme rectangle.
    shape1.FillFormat.FillType = FillType.Solid;
    shape1.FillFormat.SolidFillColor.Color = Color.Black;
    shape2.FillFormat.FillType = FillType.Solid;
    shape2.FillFormat.SolidFillColor.Color = Color.Black;
    shape3.FillFormat.FillType = FillType.Solid;
    shape3.FillFormat.SolidFillColor.Color = Color.Black;

    // Définit la largeur de la ligne.
    shape1.LineFormat.Width = 15;
    shape2.LineFormat.Width = 15;
    shape3.LineFormat.Width = 15;

    // Définit la couleur de la ligne de chaque rectangle.
    shape1.LineFormat.FillFormat.FillType = FillType.Solid;
    shape1.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    shape2.LineFormat.FillFormat.FillType = FillType.Solid;
    shape2.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    shape3.LineFormat.FillFormat.FillType = FillType.Solid;
    shape3.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;

    // Définit le style de jointure.
    shape1.LineFormat.JoinStyle = LineJoinStyle.Miter;
    shape2.LineFormat.JoinStyle = LineJoinStyle.Bevel;
    shape3.LineFormat.JoinStyle = LineJoinStyle.Round;

    // Ajoute du texte à chaque rectangle.
    shape1.TextFrame.Text = "Miter Join Style";
    shape2.TextFrame.Text = "Bevel Join Style";
    shape3.TextFrame.Text = "Round Join Style";

    // Enregistre le fichier PPTX sur le disque.
    presentation.Save("join_styles.pptx", SaveFormat.Pptx);
}
```

## **Gradient Fill**

Dans PowerPoint, le remplissage dégradé est une option de formatage qui vous permet d’appliquer un mélange continu de couleurs à une forme. Par exemple, vous pouvez appliquer deux couleurs ou plus de façon à ce qu’une couleur s’estompe progressivement dans l’autre.

Voici comment appliquer un remplissage dégradé à une forme avec Aspose.Slides :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/).
1. Obtenez une référence à une diapositive par son index.
1. Ajoutez un [IAutoShape](https://reference.aspose.com/slides/fr/net/aspose.slides/iautoshape/) à la diapositive.
1. Définissez le [FillType](https://reference.aspose.com/slides/fr/net/aspose.slides/filltype/) de la forme sur `Gradient`.
1. Ajoutez vos deux couleurs préférées avec les positions définies en utilisant les méthodes `Add` de la collection de points d’arrêt du dégradé exposée par l’interface [IGradientFormat](https://reference.aspose.com/slides/fr/net/aspose.slides/igradientformat/).
1. Enregistrez la présentation modifiée au format PPTX.

Le code C# suivant montre comment appliquer un effet de remplissage dégradé à une ellipse :

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Instancie la classe Presentation qui représente un fichier de présentation.
using (Presentation presentation = new Presentation())
{
    // Obtient la première diapositive.
    ISlide slide = presentation.Slides[0];

    // Ajoute une forme auto de type Ellipse.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // Applique le formatage en dégradé à l'ellipse.
    shape.FillFormat.FillType = FillType.Gradient;
    shape.FillFormat.GradientFormat.GradientShape = GradientShape.Linear;

    // Définit la direction du dégradé.
    shape.FillFormat.GradientFormat.GradientDirection = GradientDirection.FromCorner2;

    // Ajoute deux points d'arrêt du dégradé.
    shape.FillFormat.GradientFormat.GradientStops.Add(1.0f, PresetColor.Purple);
    shape.FillFormat.GradientFormat.GradientStops.Add(0.0f, PresetColor.Red);

    // Enregistre le fichier PPTX sur le disque.
    presentation.Save("gradient_fill.pptx", SaveFormat.Pptx);
}
```

Résultat :

![The ellipse with gradient fill](gradient-fill.png)

## **Pattern Fill**

Dans PowerPoint, le remplissage de motif est une option de formatage qui vous permet d’appliquer un motif bicolore — par exemple des points, des rayures, des hachures ou des carreaux—à une forme. Vous pouvez choisir des couleurs personnalisées pour le premier plan et l’arrière‑plan du motif.

Aspose.Slides propose plus de 45 styles de motifs prédéfinis que vous pouvez appliquer aux formes pour enrichir l’aspect de vos présentations. Même après avoir sélectionné un motif prédéfini, vous pouvez toujours spécifier les couleurs exactes à utiliser.

Voici comment appliquer un remplissage de motif à une forme avec Aspose.Slides :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/).
1. Obtenez une référence à une diapositive par son index.
1. Ajoutez un [IAutoShape](https://reference.aspose.com/slides/fr/net/aspose.slides/iautoshape/) à la diapositive.
1. Définissez le [FillType](https://reference.aspose.com/slides/fr/net/aspose.slides/filltype/) de la forme sur `Pattern`.
1. Choisissez un style de motif parmi les options prédéfinies.
1. Définissez la [Background Color](https://reference.aspose.com/slides/fr/net/aspose.slides/ipatternformat/backcolor/) du motif.
1. Définissez la [Foreground Color](https://reference.aspose.com/slides/fr/net/aspose.slides/ipatternformat/forecolor/) du motif.
1. Enregistrez la présentation modifiée au format PPTX.

Le code C# suivant montre comment appliquer un remplissage de motif à un rectangle :

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Instancie la classe Presentation qui représente un fichier de présentation.
using (Presentation presentation = new Presentation())
{
    // Obtient la première diapositive.
    ISlide slide = presentation.Slides[0];

    // Ajoute une forme auto de type Rectangle.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Définit le type de remplissage sur Pattern.
    shape.FillFormat.FillType = FillType.Pattern;

    // Définit le style du motif.
    shape.FillFormat.PatternFormat.PatternStyle = PatternStyle.Trellis;

    // Définit les couleurs d'arrière-plan et de premier plan du motif.
    shape.FillFormat.PatternFormat.BackColor.Color = Color.LightGray;
    shape.FillFormat.PatternFormat.ForeColor.Color = Color.Yellow;

    // Enregistre le fichier PPTX sur le disque.
    presentation.Save("pattern_fill.pptx", SaveFormat.Pptx);
}
```

Résultat :

![The rectangle with pattern fill](pattern-fill.png)

## **Picture Fill**

Dans PowerPoint, le remplissage d’image vous permet d’insérer une image à l’intérieur d’une forme — utilisant ainsi l’image comme arrière‑plan de la forme.

Voici comment utiliser Aspose.Slides pour appliquer un remplissage d’image à une forme :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/).
1. Obtenez une référence à une diapositive par son index.
1. Ajoutez un [IAutoShape](https://reference.aspose.com/slides/fr/net/aspose.slides/iautoshape/) à la diapositive.
1. Définissez le [FillType](https://reference.aspose.com/slides/fr/net/aspose.slides/filltype/) de la forme sur `Picture`.
1. Définissez le mode de remplissage d’image sur `Tile` (ou un autre mode de votre choix).
1. Créez un objet [IPPImage](https://reference.aspose.com/slides/fr/net/aspose.slides/ippimage/) à partir de l’image que vous souhaitez utiliser.
1. Assignez cette image à la propriété `Picture.Image` du `PictureFillFormat` de la forme.
1. Enregistrez la présentation modifiée au format PPTX.

Supposons que nous disposions du fichier **lotus.png** avec l’image suivante :

![The lotus picture](lotus.png)

Le code C# suivant montre comment remplir une forme avec l’image :

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Instancie la classe Presentation qui représente un fichier de présentation.
using (Presentation presentation = new Presentation())
{
    // Obtient la première diapositive.
    ISlide slide = presentation.Slides[0];

    // Ajoute une forme auto de type Rectangle.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);

    // Définit le type de remplissage sur Picture.
    shape.FillFormat.FillType = FillType.Picture;

    // Définit le mode de remplissage d'image.
    shape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Tile;

    // Charge une image et l'ajoute aux ressources de la présentation.
    IImage image = Images.FromFile("lotus.png");
    IPPImage presentationImage = presentation.Images.AddImage(image);
    image.Dispose();

    // Définit l'image.
    shape.FillFormat.PictureFillFormat.Picture.Image = presentationImage;

    // Enregistre le fichier PPTX sur le disque.
    presentation.Save("picture_fill.pptx", SaveFormat.Pptx);
}
```

Résultat :

![The shape with picture fill](picture-fill.png)

### **Tile Picture As Texture**

Si vous souhaitez définir une image en mosaïque comme texture et personnaliser le comportement du carrelage, vous pouvez utiliser les propriétés suivantes de l’interface [IPictureFillFormat](https://reference.aspose.com/slides/fr/net/aspose.slides/ipicturefillformat/) et de la classe [PictureFillFormat](https://reference.aspose.com/slides/fr/net/aspose.slides/picturefillformat/) :

- [PictureFillMode](https://reference.aspose.com/slides/fr/net/aspose.slides/ipicturefillformat/picturefillmode/): définit le mode de remplissage d’image — `Tile` ou `Stretch`.
- [TileAlignment](https://reference.aspose.com/slides/fr/net/aspose.slides/ipicturefillformat/tilealignment/): spécifie l’alignement des tuiles à l’intérieur de la forme.
- [TileFlip](https://reference.aspose.com/slides/fr/net/aspose.slides/ipicturefillformat/tileflip/): contrôle si la tuile est retournée horizontalement, verticalement ou les deux.
- [TileOffsetX](https://reference.aspose.com/slides/fr/net/aspose.slides/ipicturefillformat/tileoffsetx/): définit le déplacement horizontal de la tuile (en points) par rapport à l’origine de la forme.
- [TileOffsetY](https://reference.aspose.com/slides/fr/net/aspose.slides/ipicturefillformat/tileoffsety/): définit le déplacement vertical de la tuile (en points) par rapport à l’origine de la forme.
- [TileScaleX](https://reference.aspose.com/slides/fr/net/aspose.slides/ipicturefillformat/tilescalex/): définit l’échelle horizontale de la tuile en pourcentage.
- [TileScaleY](https://reference.aspose.com/slides/fr/net/aspose.slides/ipicturefillformat/tilescaley/): définit l’échelle verticale de la tuile en pourcentage.

Le fragment de code suivant montre comment ajouter une forme rectangle avec un remplissage d’image en mosaïque et configurer les options de carrelage :

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Instancie la classe Presentation qui représente un fichier de présentation.
using (Presentation presentation = new Presentation())
{
    // Obtient la première diapositive.
    ISlide firstSlide = presentation.Slides[0];

    // Ajoute une forme auto rectangle.
    IAutoShape shape = firstSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

    // Définit le type de remplissage de la forme sur Picture.
    shape.FillFormat.FillType = FillType.Picture;

    // Charge l'image et l'ajoute aux ressources de la présentation.
    IPPImage presentationImage;
    using (IImage sourceImage = Images.FromFile("lotus.png"))
        presentationImage = presentation.Images.AddImage(sourceImage);

    // Assigne l'image à la forme.
    IPictureFillFormat pictureFillFormat = shape.FillFormat.PictureFillFormat;
    pictureFillFormat.Picture.Image = presentationImage;

    // Configure le mode de remplissage d'image et les propriétés de carrelage.
    pictureFillFormat.PictureFillMode = PictureFillMode.Tile;
    pictureFillFormat.TileOffsetX = -32;
    pictureFillFormat.TileOffsetY = -32;
    pictureFillFormat.TileScaleX = 50;
    pictureFillFormat.TileScaleY = 50;
    pictureFillFormat.TileAlignment = RectangleAlignment.BottomRight;
    pictureFillFormat.TileFlip = TileFlip.FlipBoth;

    // Enregistre le fichier PPTX sur le disque.
    presentation.Save("tile.pptx", SaveFormat.Pptx);
}
```

Résultat :

![The tile options](tile-options.png)

## **Solid Color Fill**

Dans PowerPoint, le remplissage de couleur unie est une option de formatage qui remplit une forme avec une couleur unique et uniforme. Cette couleur d’arrière‑plan simple est appliquée sans dégradés, textures ou motifs.

Pour appliquer un remplissage de couleur unie à une forme avec Aspose.Slides, suivez les étapes :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/).
1. Obtenez une référence à une diapositive par son index.
1. Ajoutez un [IAutoShape](https://reference.aspose.com/slides/fr/net/aspose.slides/iautoshape/) à la diapositive.
1. Définissez le [FillType](https://reference.aspose.com/slides/fr/net/aspose.slides/filltype/) de la forme sur `Solid`.
1. Attribuez la couleur de remplissage souhaitée à la forme.
1. Enregistrez la présentation modifiée au format PPTX.

Le code C# suivant montre comment appliquer un remplissage de couleur unie à un rectangle dans une diapositive PowerPoint :

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Instancie la classe Presentation qui représente un fichier de présentation.
using (Presentation presentation = new Presentation())
{
    // Obtient la première diapositive.
    ISlide slide = presentation.Slides[0];

    // Ajoute une forme auto de type Rectangle.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Définit le type de remplissage sur Solid.
    shape.FillFormat.FillType = FillType.Solid;

    // Définit la couleur de remplissage.
    shape.FillFormat.SolidFillColor.Color = Color.Yellow;

    // Enregistre le fichier PPTX sur le disque.
    presentation.Save("solid_color_fill.pptx", SaveFormat.Pptx);
}
```

Résultat :

![The shape with solid color fill](solid-color-fill.png)

## **Set Transparency**

Dans PowerPoint, lorsque vous appliquez un remplissage de couleur unie, de dégradé, d’image ou de texture à des formes, vous pouvez également définir un niveau de transparence pour contrôler l’opacité du remplissage. Une valeur de transparence plus élevée rend la forme plus translucide, permettant au fond ou aux objets sous‑jacent d’être partiellement visibles.

Aspose.Slides vous permet de définir le niveau de transparence en ajustant la valeur alpha de la couleur utilisée pour le remplissage. Voici comment faire :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/).
1. Obtenez une référence à une diapositive par son index.
1. Ajoutez un [IAutoShape](https://reference.aspose.com/slides/fr/net/aspose.slides/iautoshape/) à la diapositive.
1. Définissez le [FillType](https://reference.aspose.com/slides/fr/net/aspose.slides/filltype/) sur `Solid`.
1. Utilisez `Color.FromArgb(alpha, baseColor)` pour définir une couleur avec transparence (le composant `alpha` contrôle la transparence).
1. Enregistrez la présentation.

Le code C# suivant montre comment appliquer une couleur de remplissage transparente à un rectangle :

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

const int alpha = 128;

// Instancie la classe Presentation qui représente un fichier de présentation.
using (Presentation presentation = new Presentation())
{
    // Obtient la première diapositive.
    ISlide slide = presentation.Slides[0];

    // Ajoute une forme auto rectangle solide.
    IAutoShape solidShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Ajoute une forme auto rectangle transparente au-dessus de la forme solide.
    IAutoShape transparentShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.FillFormat.FillType = FillType.Solid;
    transparentShape.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Yellow);

    // Enregistre le fichier PPTX sur le disque.
    presentation.Save("shape_transparency.pptx", SaveFormat.Pptx);
}
```

Résultat :

![The transparent shape](shape-transparency.png)

## **Rotate Shapes**

Aspose.Slides vous permet de faire pivoter des formes dans les présentations PowerPoint. Cela peut être utile pour positionner des éléments visuels avec des exigences d’alignement ou de conception spécifiques.

Pour faire pivoter une forme sur une diapositive, suivez ces étapes :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/).
1. Obtenez une référence à une diapositive par son index.
1. Ajoutez un [IAutoShape](https://reference.aspose.com/slides/fr/net/aspose.slides/iautoshape/) à la diapositive.
1. Définissez la propriété `Rotation` de la forme sur l’angle désiré.
1. Enregistrez la présentation.

Le code C# suivant montre comment faire pivoter une forme de 5 degrés :

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Instancie la classe Presentation qui représente un fichier de présentation.
using (Presentation presentation = new Presentation())
{
    // Obtient la première diapositive.
    ISlide slide = presentation.Slides[0];

    // Ajoute une forme auto de type Rectangle.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Fais pivoter la forme de 5 degrés.
    shape.Rotation = 5;

    // Enregistre le fichier PPTX sur le disque.
    presentation.Save("shape_rotation.pptx", SaveFormat.Pptx);
}
```

Résultat :

![The shape rotation](shape-rotation.png)

## **Add 3D Bevel Effects**

Aspose.Slides vous permet d’appliquer des effets de biseau 3D aux formes en configurant leurs propriétés [ThreeDFormat](https://reference.aspose.com/slides/fr/net/aspose.slides/threedformat/).

Pour ajouter des effets de biseau 3D à une forme, suivez ces étapes :

1. Instanciez la classe [Presentation](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/).
1. Obtenez une référence à une diapositive par son index.
1. Ajoutez un [IAutoShape](https://reference.aspose.com/slides/fr/net/aspose.slides/iautoshape/) à la diapositive.
1. Configurez le [ThreeDFormat](https://reference.aspose.com/slides/fr/net/aspose.slides/threedformat/) de la forme pour définir les paramètres de biseau.
1. Enregistrez la présentation.

Le code C# suivant montre comment appliquer des effets de biseau 3D à une forme :

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Crée une instance de la classe Presentation.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Ajoute une forme à la diapositive.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 50, 100, 100);
    shape.FillFormat.FillType = FillType.Solid;
    shape.FillFormat.SolidFillColor.Color = Color.Green;
    shape.LineFormat.FillFormat.FillType = FillType.Solid;
    shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Orange;
    shape.LineFormat.Width = 2.0;

    // Définit les propriétés ThreeDFormat de la forme.
    shape.ThreeDFormat.Depth = 4;
    shape.ThreeDFormat.BevelTop.BevelType = BevelPresetType.Circle;
    shape.ThreeDFormat.BevelTop.Height = 6;
    shape.ThreeDFormat.BevelTop.Width = 6;
    shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
    shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.ThreePt;
    shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;

    // Enregistre la présentation au format PPTX.
    presentation.Save("3D_bevel_effect.pptx", SaveFormat.Pptx);
}
```

Résultat :

![The 3D bevel effect](3D-bevel-effect.png)

## **Add 3D Rotation Effects**

Aspose.Slides vous permet d’appliquer des effets de rotation 3D aux formes en configurant leurs propriétés [ThreeDFormat](https://reference.aspose.com/slides/fr/net/aspose.slides/threedformat/).

Pour appliquer une rotation 3D à une forme :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/).
1. Obtenez une référence à une diapositive par son index.
1. Ajoutez un [IAutoShape](https://reference.aspose.com/slides/fr/net/aspose.slides/iautoshape/) à la diapositive.
1. Définissez le [CameraType](https://reference.aspose.com/slides/fr/net/aspose.slides/icamera/cameratype/) et le [LightType](https://reference.aspose.com/slides/fr/net/aspose.slides/ilightrig/lighttype/) de la forme pour spécifier la rotation 3D.
1. Enregistrez la présentation.

Le code C# suivant montre comment appliquer des effets de rotation 3D à une forme :

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Crée une instance de la classe Presentation.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    autoShape.TextFrame.Text = "Hello, Aspose!";

    autoShape.ThreeDFormat.Camera.SetRotation(40, 35, 20);
    autoShape.ThreeDFormat.Camera.CameraType = CameraPresetType.IsometricLeftUp;
    autoShape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;

    // Enregistre la présentation au format PPTX.
    presentation.Save("3D_rotation_effect.pptx", SaveFormat.Pptx);
}
```

Résultat :

![The 3D rotation effect](3D-rotation-effect.png)

## **Control Black-and-White Rendering for Shapes**

La propriété [IShape.BlackWhiteMode](https://reference.aspose.com/slides/fr/net/aspose.slides/ishape/blackwhitemode/) indique comment une forme individuelle est rendue lorsqu’une présentation est affichée ou traitée en mode noir et blanc. Elle n’active pas l’affichage en noir et blanc et ne modifie pas le remplissage, le contour ou tout autre formatage de la forme en mode couleur normal.

Utilisez une valeur de l’énumération [BlackWhiteMode](https://reference.aspose.com/slides/fr/net/aspose.slides/blackwhitemode/) pour choisir le comportement souhaité. Par exemple, `Automatic` laisse l’application de rendu choisir la conversion, `Gray` et `LightGray` utilisent le gris, `BlackWhite` n’emploie que le noir et le blanc, `Black` et `White` forcent une couleur unique, `Color` conserve les couleurs normales, et `Hidden` masque la forme en mode noir et blanc. `NotDefined` signifie qu’aucun mode au niveau de la forme n’est attribué.

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

// Conservez le remplissage orange en mode couleur, mais affichez la forme avec une coloration grise en mode noir et blanc.
shape.BlackWhiteMode = BlackWhiteMode.Gray;

presentation.Save("shape_black_white_mode.pptx", SaveFormat.Pptx);
```

En mode couleur normal, le rectangle conserve son remplissage orange. En mode d’affichage noir et blanc, il utilise le gris parce que son mode est réglé sur `Gray`. Cela vous permet de conserver une diapositive en couleur complète tout en définissant une apparence distincte pour l’impression, l’aperçu ou d’autres flux de travail qui respectent les paramètres d’affichage noir et blanc de la présentation.

## **Reset Formatting**

Le code C# suivant montre comment réinitialiser le formatage d’une diapositive et restaurer la position, la taille et le formatage de toutes les formes avec des espaces réservés sur le [LayoutSlide](https://reference.aspose.com/slides/fr/net/aspose.slides/layoutslide/) à leurs paramètres par défaut :

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    foreach (ISlide slide in presentation.Slides)
    {
        // Réinitialise chaque forme sur la diapositive qui possède un espace réservé sur la mise en page.
        slide.Reset();
    }

    presentation.Save("reset_formatting.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Le formatage des formes affecte-t-il la taille finale du fichier de présentation ?**

Seulement de façon minimale. Les images et les médias incorporés occupent la majeure partie de l’espace du fichier, tandis que les paramètres de forme tels que les couleurs, les effets et les dégradés sont stockés comme métadonnées et n’ajoutent pratiquement aucune taille supplémentaire.

**Comment détecter les formes sur une diapositive qui partagent un même formatage afin de les regrouper ?**

Comparez les propriétés clés de formatage de chaque forme — remplissage, contour et paramètres d’effet. Si toutes les valeurs correspondantes sont identiques, considérez leurs styles comme identiques et regroupez logiquement ces formes, ce qui simplifie la gestion des styles par la suite.

**Puis‑je enregistrer un ensemble de styles de forme personnalisés dans un fichier séparé pour les réutiliser dans d’autres présentations ?**

Oui. Conservez des formes d’exemple avec les styles souhaités dans un jeu de diapositives modèle ou un fichier modèle *.POTX*. Lors de la création d’une nouvelle présentation, ouvrez le modèle, clonez les formes stylisées dont vous avez besoin et réappliquez leur formatage où cela est requis.