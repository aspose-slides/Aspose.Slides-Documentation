---
title: Formater les formes PowerPoint en C#
linktitle: Formatage de forme
type: docs
weight: 20
url: /fr/net/shape-formatting/
keywords:
- format de forme
- format de ligne
- format du style de jointure
- remplissage dégradé
- remplissage à motif
- remplissage d'image
- remplissage de texture
- remplissage de couleur unie
- transparence de forme
- rotation de forme
- effet de biseau 3D
- effet de rotation 3D
- réinitialiser le formatage
- PowerPoint
- présentation
- C#
- Csharp
- .NET
- Aspose.Slides
description: "Apprenez à formater les formes PowerPoint en C# avec Aspose.Slides — définissez les styles de remplissage, de ligne et d’effet pour les fichiers PPT, PPTX et ODP avec précision et un contrôle total."
---

## **Aperçu**

Dans PowerPoint, vous pouvez ajouter des formes aux diapositives. Comme les formes sont composées de lignes, vous pouvez les mettre en forme en modifiant ou en appliquant des effets à leurs contours. De plus, vous pouvez mettre en forme les formes en spécifiant des paramètres qui contrôlent la façon dont leurs intérieurs sont remplis.

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides pour .NET fournit des interfaces et des propriétés qui vous permettent de mettre en forme les formes en utilisant les mêmes options disponibles dans PowerPoint.

## **Formater les lignes**

Avec Aspose.Slides, vous pouvez spécifier un style de ligne personnalisé pour une forme. Les étapes suivantes décrivent la procédure :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Obtenez une référence à une diapositive par son indice.
1. Ajoutez un [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) à la diapositive.
1. Définissez le [style de ligne](https://reference.aspose.com/slides/net/aspose.slides/linestyle/) de la forme.
1. Définissez la largeur de la ligne.
1. Définissez le [style de tirets](https://reference.aspose.com/slides/net/aspose.slides/linedashstyle/) de la ligne.
1. Définissez la couleur de la ligne pour la forme.
1. Enregistrez la présentation modifiée au format PPTX.

Le code C# suivant montre comment mettre en forme un `AutoShape` rectangle :
```c#
// Instancier la classe Presentation qui représente un fichier de présentation.
using (Presentation presentation = new Presentation())
{
    // Obtenir la première diapositive.
    ISlide slide = presentation.Slides[0];

    // Ajouter une forme auto de type Rectangle.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Définir la couleur de remplissage pour la forme rectangle.
    shape.FillFormat.FillType = FillType.NoFill;

    // Appliquer le formatage aux lignes du rectangle.
    shape.LineFormat.Style = LineStyle.ThickThin;
    shape.LineFormat.Width = 7;
    shape.LineFormat.DashStyle = LineDashStyle.Dash;

    // Définir la couleur pour la ligne du rectangle.
    shape.LineFormat.FillFormat.FillType = FillType.Solid;
    shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;

    // Enregistrer le fichier PPTX sur le disque.
    presentation.Save("formatted_lines.pptx", SaveFormat.Pptx);
}
```


Le résultat :
![Les lignes formatées dans la présentation](formatted-lines.png)

## **Formater les styles de jointure**

Voici les trois options de type de jointure :

* Arrondi
* En onglet
* Biseau

Par défaut, lorsque PowerPoint joint deux lignes à un angle (comme au coin d’une forme), il utilise le paramètre **Arrondi**. Cependant, si vous dessinez une forme avec des angles vifs, vous pouvez préférer l’option **En onglet**.

![Le style de jointure dans la présentation](join-style-powerpoint.png)

Le code C# suivant montre comment trois rectangles (comme indiqué sur l’image ci‑dessus) ont été créés en utilisant les paramètres de type de jointure En onglet, Biseau et Arrondi :
```c#
// Instancier la classe Presentation qui représente un fichier de présentation.
using (Presentation presentation = new Presentation())
{
    // Obtenir la première diapositive.
    ISlide slide = presentation.Slides[0];

    // Ajouter trois formes auto de type Rectangle.
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

    // Définir la couleur pour la ligne de chaque rectangle.
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


## **Remplissage dégradé**

Dans PowerPoint, le remplissage dégradé est une option de mise en forme qui vous permet d’appliquer un mélange continu de couleurs à une forme. Par exemple, vous pouvez appliquer deux couleurs ou plus de manière à ce que l’une se fonde progressivement dans l’autre.

Voici comment appliquer un remplissage dégradé à une forme à l’aide d’Aspose.Slides :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Obtenez une référence à une diapositive par son indice.
1. Ajoutez un [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) à la diapositive.
1. Définissez le [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) de la forme sur `Gradient`.
1. Ajoutez vos deux couleurs préférées avec des positions définies en utilisant les méthodes `Add` de la collection d’arrêts de dégradé exposée par l’interface [IGradientFormat](https://reference.aspose.com/slides/net/aspose.slides/igradientformat/).
1. Enregistrez la présentation modifiée au format PPTX.

```c#
// Instancier la classe Presentation qui représente un fichier de présentation.
using (Presentation presentation = new Presentation())
{
    // Obtenir la première diapositive.
    ISlide slide = presentation.Slides[0];

    // Ajouter une forme auto de type Ellipse.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // Appliquer le format de dégradé à l'ellipse.
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
![L’ellipse avec remplissage dégradé](gradient-fill.png)

## **Remplissage à motif**

Dans PowerPoint, le remplissage à motif est une option de mise en forme qui vous permet d’appliquer un motif bicolore — comme des points, des rayures, des hachures ou des damiers — à une forme. Vous pouvez choisir des couleurs personnalisées pour le premier plan et l’arrière‑plan du motif.

Aspose.Slides propose plus de 45 styles de motif prédéfinis que vous pouvez appliquer aux formes pour améliorer l’aspect visuel de vos présentations. Même après avoir sélectionné un motif prédéfini, vous pouvez toujours préciser les couleurs exactes à utiliser.

Voici comment appliquer un remplissage à motif à une forme à l’aide d’Aspose.Slides :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Obtenez une référence à une diapositive par son indice.
1. Ajoutez un [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) à la diapositive.
1. Définissez le [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) de la forme sur `Pattern`.
1. Choisissez un style de motif parmi les options prédéfinies.
1. Définissez la [Background Color](https://reference.aspose.com/slides/net/aspose.slides/ipatternformat/backcolor/) du motif.
1. Définissez la [Foreground Color](https://reference.aspose.com/slides/net/aspose.slides/ipatternformat/forecolor/) du motif.
1. Enregistrez la présentation modifiée au format PPTX.

```c#
// Instancier la classe Presentation qui représente un fichier de présentation.
using (Presentation presentation = new Presentation())
{
    // Obtenir la première diapositive.
    ISlide slide = presentation.Slides[0];

    // Ajouter une forme auto de type Rectangle.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Définir le type de remplissage sur Pattern.
    shape.FillFormat.FillType = FillType.Pattern;

    // Définir le style de motif.
    shape.FillFormat.PatternFormat.PatternStyle = PatternStyle.Trellis;

    // Définir les couleurs d'arrière-plan et de premier plan du motif.
    shape.FillFormat.PatternFormat.BackColor.Color = Color.LightGray;
    shape.FillFormat.PatternFormat.ForeColor.Color = Color.Yellow;

    // Enregistrer le fichier PPTX sur le disque.
    presentation.Save("pattern_fill.pptx", SaveFormat.Pptx);
}
```


Le résultat :
![Le rectangle avec remplissage à motif](pattern-fill.png)

## **Remplissage d'image**

Dans PowerPoint, le remplissage d'image est une option de mise en forme qui vous permet d’insérer une image à l’intérieur d’une forme — en utilisant efficacement l’image comme arrière‑plan de la forme.

Voici comment utiliser Aspose.Slides pour appliquer un remplissage d'image à une forme :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Obtenez une référence à une diapositive par son indice.
1. Ajoutez un [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) à la diapositive.
1. Définissez le [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) de la forme sur `Picture`.
1. Définissez le mode de remplissage d'image sur `Tile` (ou un autre mode préféré).
1. Créez un objet [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/) à partir de l’image que vous souhaitez utiliser.
1. Attribuez cette image à la propriété `Picture.Image` du `PictureFillFormat` de la forme.
1. Enregistrez la présentation modifiée au format PPTX.

Supposons que nous ayons un fichier "lotus.png" avec l’image suivante :
![L’image lotus](lotus.png)

```c#
// Instancier la classe Presentation qui représente un fichier de présentation.
using (Presentation presentation = new Presentation())
{
    // Obtenir la première diapositive.
    ISlide slide = presentation.Slides[0];

    // Ajouter une forme auto de type Rectangle.
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
![La forme avec remplissage d'image](picture-fill.png)

### **Carreler l’image comme texture**

Si vous souhaitez définir une image en mosaïque comme texture et personnaliser le comportement du carrelage, vous pouvez utiliser les propriétés suivantes de l’interface [IPictureFillFormat] et de la classe [PictureFillFormat] :

- [PictureFillMode] : Définit le mode de remplissage d'image — `Tile` ou `Stretch`.
- [TileAlignment] : Spécifie l’alignement des tuiles à l’intérieur de la forme.
- [TileFlip] : Contrôle si la tuile est retournée horizontalement, verticalement ou les deux.
- [TileOffsetX] : Définit le décalage horizontal de la tuile (en points) par rapport à l’origine de la forme.
- [TileOffsetY] : Définit le décalage vertical de la tuile (en points) par rapport à l’origine de la forme.
- [TileScaleX] : Définit l’échelle horizontale de la tuile en pourcentage.
- [TileScaleY] : Définit l’échelle verticale de la tuile en pourcentage.

L’exemple de code suivant montre comment ajouter une forme rectangle avec un remplissage d’image en mosaïque et configurer les options de tuiles :
```c#
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
![Les options de tuiles](tile-options.png)

## **Remplissage de couleur unie**

Dans PowerPoint, le remplissage de couleur unie est une option de mise en forme qui remplit une forme avec une couleur unique et uniforme. Cette couleur de fond unie est appliquée sans aucun dégradé, texture ou motif.

Pour appliquer un remplissage de couleur unie à une forme à l’aide d’Aspose.Slides, suivez ces étapes :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Obtenez une référence à une diapositive par son indice.
1. Ajoutez un [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) à la diapositive.
1. Définissez le [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) de la forme sur `Solid`.
1. Attribuez la couleur de remplissage de votre choix à la forme.
1. Enregistrez la présentation modifiée au format PPTX.

```c#
// Instancier la classe Presentation qui représente un fichier de présentation.
using (Presentation presentation = new Presentation())
{
    // Obtenir la première diapositive.
    ISlide slide = presentation.Slides[0];

    // Ajouter une forme auto de type Rectangle.
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
![La forme avec remplissage de couleur unie](solid-color-fill.png)

## **Définir la transparence**

Dans PowerPoint, lorsque vous appliquez un remplissage de couleur unie, un dégradé, une image ou une texture à des formes, vous pouvez également définir un niveau de transparence pour contrôler l’opacité du remplissage. Une valeur de transparence plus élevée rend la forme plus transparente, permettant au fond ou aux objets sous‑jacent d’être partiellement visibles.

Aspose.Slides vous permet de définir le niveau de transparence en ajustant la valeur alpha de la couleur utilisée pour le remplissage. Voici comment procéder :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Obtenez une référence à une diapositive par son indice.
1. Ajoutez un [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) à la diapositive.
1. Définissez le [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) sur `Solid`.
1. Utilisez `Color.FromArgb(alpha, baseColor)` pour définir une couleur avec transparence (le composant `alpha` contrôle la transparence).
1. Enregistrez la présentation.

```c#
const int alpha = 128;

// Instancier la classe Presentation qui représente un fichier de présentation.
using (Presentation presentation = new Presentation())
{
    // Obtenir la première diapositive.
    ISlide slide = presentation.Slides[0];

    // Ajouter une forme auto rectangle solide.
    IAutoShape solidShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Ajouter une forme auto rectangle transparente au-dessus de la forme solide.
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

Aspose.Slides vous permet de faire pivoter des formes dans les présentations PowerPoint. Cela peut être utile lors du positionnement d’éléments visuels avec des exigences d’alignement ou de conception spécifiques.

Pour faire pivoter une forme sur une diapositive, suivez ces étapes :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Obtenez une référence à une diapositive par son indice.
1. Ajoutez un [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) à la diapositive.
1. Définissez la propriété `Rotation` de la forme sur l’angle souhaité.
1. Enregistrez la présentation.

```c#
// Instancier la classe Presentation qui représente un fichier de présentation.
using (Presentation presentation = new Presentation())
{
    // Obtenir la première diapositive.
    ISlide slide = presentation.Slides[0];

    // Ajouter une forme auto de type Rectangle.
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

Aspose.Slides vous permet d’appliquer des effets de biseau 3D aux formes en configurant leurs propriétés [ThreeDFormat].

Pour ajouter des effets de biseau 3D à une forme, suivez ces étapes :

1. Instanciez la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Obtenez une référence à une diapositive par son indice.
1. Ajoutez un [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) à la diapositive.
1. Configurez le [ThreeDFormat] de la forme pour définir les paramètres de biseau.
1. Enregistrez la présentation.

```c#
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

    // Enregistrer la présentation en tant que fichier PPTX.
    presentation.Save("3D_bevel_effect.pptx", SaveFormat.Pptx);
}
```


Le résultat :
![L’effet de biseau 3D](3D-bevel-effect.png)

## **Ajouter des effets de rotation 3D**

Aspose.Slides vous permet d’appliquer des effets de rotation 3D aux formes en configurant leurs propriétés [ThreeDFormat].

Pour appliquer une rotation 3D à une forme :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Obtenez une référence à une diapositive par son indice.
1. Ajoutez un [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) à la diapositive.
1. Définissez le [CameraType] et le [LightType] de la forme pour définir la rotation 3D.
1. Enregistrez la présentation.

```c#
// Créer une instance de la classe Presentation.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    autoShape.TextFrame.Text = "Hello, Aspose!";

    autoShape.ThreeDFormat.Depth = 6;
    autoShape.ThreeDFormat.Camera.SetRotation(40, 35, 20);
    autoShape.ThreeDFormat.Camera.CameraType = CameraPresetType.IsometricLeftUp;
    autoShape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;

    // Enregistrer la présentation en tant que fichier PPTX.
    presentation.Save("3D_rotation_effect.pptx", SaveFormat.Pptx);
}
```


Le résultat :
![L’effet de rotation 3D](3D-rotation-effect.png)

## **Réinitialiser le formatage**

Le code C# suivant montre comment réinitialiser le formatage d’une diapositive et restaurer la position, la taille et le formatage de toutes les formes avec des espaces réservés sur le [LayoutSlide] à leurs paramètres par défaut :
```c#
using (Presentation presentation = new Presentation("sample.pptx"))
{
    foreach (ISlide slide in presentation.Slides)
    {
        // Réinitialiser chaque forme de la diapositive qui possède un espace réservé sur la mise en page.
        slide.Reset();
    }

    presentation.Save("reset_formatting.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**Le formatage des formes affecte-t-il la taille finale du fichier de présentation ?**  
Oui, mais très peu. Les images et médias incorporés occupent la majeure partie de l’espace du fichier, tandis que les paramètres des formes tels que les couleurs, les effets et les dégradés sont stockés comme métadonnées et n’ajoutent pratiquement aucune taille supplémentaire.

**Comment détecter les formes sur une diapositive qui partagent le même formatage afin de pouvoir les regrouper ?**  
Comparez les propriétés de formatage clés de chaque forme — remplissage, ligne et paramètres d’effet. Si toutes les valeurs correspondantes sont identiques, considérez leurs styles comme identiques et regroupez logiquement ces formes, ce qui simplifie la gestion ultérieure des styles.

**Puis‑je enregistrer un ensemble de styles de forme personnalisés dans un fichier séparé pour les réutiliser dans d’autres présentations ?**  
Oui. Enregistrez des formes d’exemple avec les styles souhaités dans un jeu de diapositives modèle ou un fichier .POTX. Lors de la création d’une nouvelle présentation, ouvrez le modèle, clonez les formes stylisées dont vous avez besoin et réappliquez leur formatage où cela est requis.