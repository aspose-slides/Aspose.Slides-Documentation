---
title: Formater les formes PowerPoint en .NET
linktitle: Formatage des formes
type: docs
weight: 20
url: /fr/net/shape-formatting/
keywords:
- format de forme
- format de ligne
- style de jointure
- remplissage dégradé
- remplissage de motif
- remplissage d’image
- remplissage de texture
- remplissage couleur unie
- transparence de forme
- rotation de forme
- effet de biseau 3d
- effet de rotation 3d
- réinitialiser le formatage
- PowerPoint
- présentation
- .NET
- C#
- Aspose.Slides
description: "Apprenez à formater les formes PowerPoint en C# avec Aspose.Slides — définissez les styles de remplissage, de ligne et d’effet pour les fichiers PPT et PPTX avec précision et plein contrôle."
---

## **Aperçu**

Dans PowerPoint, vous pouvez ajouter des formes aux diapositives. Puisque les formes sont composées de lignes, vous pouvez les mettre en forme en modifiant ou en appliquant des effets à leurs contours. De plus, vous pouvez formater les formes en définissant des paramètres qui contrôlent le remplissage de leurs intérieurs.

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for .NET fournit des interfaces et des propriétés qui vous permettent de formater les formes en utilisant les mêmes options que celles disponibles dans PowerPoint.

## **Formater les lignes**

Avec Aspose.Slides, vous pouvez spécifier un style de ligne personnalisé pour une forme. Les étapes suivantes décrivent la procédure :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Obtenez une référence à une diapositive par son indice.
1. Ajoutez une [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) à la diapositive.
1. Définissez le [line style](https://reference.aspose.com/slides/net/aspose.slides/linestyle/) de la forme.
1. Définissez la largeur de la ligne.
1. Définissez le [dash style](https://reference.aspose.com/slides/net/aspose.slides/linedashstyle/) de la ligne.
1. Définissez la couleur de la ligne pour la forme.
1. Enregistrez la présentation modifiée sous forme de fichier PPTX.

Le code C# suivant montre comment formater un rectangle `AutoShape` :
```c#
// Instancier la classe Presentation qui représente un fichier de présentation.
using (Presentation presentation = new Presentation())
{
    // Obtenir la première diapositive.
    ISlide slide = presentation.Slides[0];

    // Ajouter une forme auto du type Rectangle.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Définir la couleur de remplissage pour la forme rectangle.
    shape.FillFormat.FillType = FillType.NoFill;

    // Appliquer le formatage aux lignes du rectangle.
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

![The formatted lines in the presentation](formatted-lines.png)

## **Formater les styles de jointure**

Voici les trois options de type de jointure :

* Round
* Miter
* Bevel

Par défaut, lorsque PowerPoint joint deux lignes sous un angle (par exemple au coin d’une forme), il utilise le paramètre **Round**. Cependant, si vous dessinez une forme avec des angles aigus, vous pouvez préférer l’option **Miter**.

![The join style in the presentation](join-style-powerpoint.png)

Le code C# suivant montre comment trois rectangles (comme indiqué sur l’image ci‑dessus) ont été créés en utilisant les paramètres de jointure Miter, Bevel et Round :
```c#
// Instancier la classe Presentation qui représente un fichier de présentation.
using (Presentation presentation = new Presentation())
{
    // Obtenir la première diapositive.
    ISlide slide = presentation.Slides[0];

    // Ajouter trois formes automatiques du type Rectangle.
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


## **Remplissage dégradé**

Dans PowerPoint, le remplissage dégradé est une option de formatage qui vous permet d’appliquer un fondu continu de couleurs à une forme. Par exemple, vous pouvez appliquer deux couleurs ou plus de manière à ce qu’une couleur s’estompe progressivement dans une autre.

Voici comment appliquer un remplissage dégradé à une forme avec Aspose.Slides :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Obtenez une référence à une diapositive par son indice.
1. Ajoutez une [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) à la diapositive.
1. Définissez le [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) de la forme sur `Gradient`.
1. Ajoutez vos deux couleurs préférées avec des positions définies en utilisant les méthodes `Add` de la collection de points d’arrêt du dégradé exposée par l’interface [IGradientFormat](https://reference.aspose.com/slides/net/aspose.slides/igradientformat/).
1. Enregistrez la présentation modifiée sous forme de fichier PPTX.

Le code C# suivant montre comment appliquer un effet de remplissage dégradé à une ellipse :
```c#
// Instancier la classe Presentation qui représente un fichier de présentation.
using (Presentation presentation = new Presentation())
{
    // Obtenir la première diapositive.
    ISlide slide = presentation.Slides[0];

    // Ajouter une forme auto de type Ellipse.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // Appliquer le formatage dégradé à l'ellipse.
    shape.FillFormat.FillType = FillType.Gradient;
    shape.FillFormat.GradientFormat.GradientShape = GradientShape.Linear;

    // Définir la direction du dégradé.
    shape.FillFormat.GradientFormat.GradientDirection = GradientDirection.FromCorner2;

    // Ajouter deux points d'arrêt du dégradé.
    shape.FillFormat.GradientFormat.GradientStops.Add(1.0f, PresetColor.Purple);
    shape.FillFormat.GradientFormat.GradientStops.Add(0.0f, PresetColor.Red);

    // Enregistrer le fichier PPTX sur le disque.
    presentation.Save("gradient_fill.pptx", SaveFormat.Pptx);
}
```


Le résultat :

![The ellipse with gradient fill](gradient-fill.png)

## **Remplissage de motif**

Dans PowerPoint, le remplissage de motif est une option de formatage qui vous permet d’appliquer un motif à deux couleurs—tel que des points, des rayures, des hachures croisées ou des damiers—à une forme. Vous pouvez choisir des couleurs personnalisées pour le premier plan et l’arrière‑plan du motif.

Aspose.Slides propose plus de 45 styles de motif prédéfinis que vous pouvez appliquer aux formes pour améliorer l’attrait visuel de vos présentations. Même après avoir sélectionné un motif prédéfini, vous pouvez toujours spécifier les couleurs exactes à utiliser.

Voici comment appliquer un remplissage de motif à une forme avec Aspose.Slides :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Obtenez une référence à une diapositive par son indice.
1. Ajoutez une [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) à la diapositive.
1. Définissez le [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) de la forme sur `Pattern`.
1. Choisissez un style de motif parmi les options prédéfinies.
1. Définissez la [Background Color](https://reference.aspose.com/slides/net/aspose.slides/ipatternformat/backcolor/) du motif.
1. Définissez la [Foreground Color](https://reference.aspose.com/slides/net/aspose.slides/ipatternformat/forecolor/) du motif.
1. Enregistrez la présentation modifiée sous forme de fichier PPTX.

Le code C# suivant montre comment appliquer un remplissage de motif à un rectangle :
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

    // Définir le style du motif.
    shape.FillFormat.PatternFormat.PatternStyle = PatternStyle.Trellis;

    // Définir les couleurs d'arrière plan et de premier plan du motif.
    shape.FillFormat.PatternFormat.BackColor.Color = Color.LightGray;
    shape.FillFormat.PatternFormat.ForeColor.Color = Color.Yellow;

    // Enregistrer le fichier PPTX sur le disque.
    presentation.Save("pattern_fill.pptx", SaveFormat.Pptx);
}
```


Le résultat :

![The rectangle with pattern fill](pattern-fill.png)

## **Remplissage d’image**

Dans PowerPoint, le remplissage d’image est une option de formatage qui vous permet d’insérer une image à l’intérieur d’une forme—utilisant ainsi l’image comme arrière‑plan de la forme.

Voici comment utiliser Aspose.Slides pour appliquer un remplissage d’image à une forme :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Obtenez une référence à une diapositive par son indice.
1. Ajoutez une [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) à la diapositive.
1. Définissez le [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) de la forme sur `Picture`.
1. Définissez le mode de remplissage d’image sur `Tile` (ou un autre mode préféré).
1. Créez un objet [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/) à partir de l’image que vous souhaitez utiliser.
1. Assignez cette image à la propriété `Picture.Image` du `PictureFillFormat` de la forme.
1. Enregistrez la présentation modifiée sous forme de fichier PPTX.

Supposons que nous disposions d’un fichier « lotus.png » avec l’image suivante :

![The lotus picture](lotus.png)

Le code C# suivant montre comment remplir une forme avec l’image :
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

![The shape with picture fill](picture-fill.png)

### **Utiliser une image en mosaïque comme texture**

Si vous souhaitez définir une image en mosaïque comme texture et personnaliser le comportement de la mosaïque, vous pouvez utiliser les propriétés suivantes de l’interface [IPictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/) et de la classe [PictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/) :

- [PictureFillMode](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/picturefillmode/): Définit le mode de remplissage d’image—`Tile` ou `Stretch`.
- [TileAlignment](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tilealignment/): Précise l’alignement des tuiles dans la forme.
- [TileFlip](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tileflip/): Contrôle le retournement horizontal, vertical ou les deux de la tuile.
- [TileOffsetX](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tileoffsetx/): Définit le déplacement horizontal de la tuile (en points) depuis l’origine de la forme.
- [TileOffsetY](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tileoffsety/): Définit le déplacement vertical de la tuile (en points) depuis l’origine de la forme.
- [TileScaleX](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tilescalex/): Définit l’échelle horizontale de la tuile en pourcentage.
- [TileScaleY](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tilescaley/): Définit l’échelle verticale de la tuile en pourcentage.

Le fragment de code suivant montre comment ajouter une forme rectangulaire avec un remplissage d’image en mosaïque et configurer les options de mosaïque :
```c#
// Instancier la classe Presentation qui représente un fichier de présentation.
using (Presentation presentation = new Presentation())
{
    // Obtenir la première diapositive.
    ISlide firstSlide = presentation.Slides[0];

    // Ajouter une forme auto rectangle.
    IAutoShape shape = firstSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

    // Définir le type de remplissage de la forme sur Picture.
    shape.FillFormat.FillType = FillType.Picture;

    // Charger l'image et l'ajouter aux ressources de la présentation.
    IPPImage presentationImage;
    using (IImage sourceImage = Images.FromFile("lotus.png"))
        presentationImage = presentation.Images.AddImage(sourceImage);

    // Assigner l'image à la forme.
    IPictureFillFormat pictureFillFormat = shape.FillFormat.PictureFillFormat;
    pictureFillFormat.Picture.Image = presentationImage;

    // Configurer le mode de remplissage d'image et les propriétés de mosaïque.
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

![The tile options](tile-options.png)

## **Remplissage de couleur unie**

Dans PowerPoint, le remplissage de couleur unie est une option de formatage qui remplit une forme avec une couleur unique et uniforme. Cette couleur d’arrière‑plan simple est appliquée sans dégradés, textures ou motifs.

Pour appliquer un remplissage de couleur unie à une forme avec Aspose.Slides, suivez ces étapes :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Obtenez une référence à une diapositive par son indice.
1. Ajoutez une [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) à la diapositive.
1. Définissez le [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) de la forme sur `Solid`.
1. Assignez la couleur de remplissage souhaitée à la forme.
1. Enregistrez la présentation modifiée sous forme de fichier PPTX.

Le code C# suivant montre comment appliquer un remplissage de couleur unie à un rectangle dans une diapositive PowerPoint :
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

![The shape with solid color fill](solid-color-fill.png)

## **Définir la transparence**

Dans PowerPoint, lorsque vous appliquez un remplissage de couleur unie, dégradé, image ou texture à des formes, vous pouvez également définir un niveau de transparence pour contrôler l’opacité du remplissage. Une valeur de transparence plus élevée rend la forme plus translucide, permettant à l’arrière‑plan ou aux objets sous‑jacent d’être partiellement visibles.

Aspose.Slides vous permet de définir le niveau de transparence en ajustant la valeur alpha de la couleur utilisée pour le remplissage. Voici comment procéder :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Obtenez une référence à une diapositive par son indice.
1. Ajoutez une [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) à la diapositive.
1. Définissez le [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) sur `Solid`.
1. Utilisez `Color.FromArgb(alpha, baseColor)` pour définir une couleur avec transparence (le composant `alpha` contrôle la transparence).
1. Enregistrez la présentation.

Le code C# suivant montre comment appliquer une couleur de remplissage transparente à un rectangle :
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

![The transparent shape](shape-transparency.png)

## **Faire pivoter les formes**

Aspose.Slides vous permet de faire pivoter les formes dans les présentations PowerPoint. Cela peut être utile pour positionner des éléments visuels avec des exigences d’alignement ou de conception spécifiques.

Pour faire pivoter une forme sur une diapositive, suivez ces étapes :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Obtenez une référence à une diapositive par son indice.
1. Ajoutez une [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) à la diapositive.
1. Définissez la propriété `Rotation` de la forme sur l’angle souhaité.
1. Enregistrez la présentation.

Le code C# suivant montre comment faire pivoter une forme de 5 degrés :
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

![The shape rotation](shape-rotation.png)

## **Ajouter des effets de biseau 3D**

Aspose.Slides vous permet d’appliquer des effets de biseau 3D aux formes en configurant leurs propriétés [ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/threedformat/).

Pour ajouter des effets de biseau 3D à une forme, suivez ces étapes :

1. Instanciez la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Obtenez une référence à une diapositive par son indice.
1. Ajoutez une [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) à la diapositive.
1. Configurez le [ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/threedformat/) de la forme pour définir les paramètres de biseau.
1. Enregistrez la présentation.

Le code C# suivant montre comment appliquer des effets de biseau 3D à une forme :
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

    // Enregistrer la présentation au format PPTX.
    presentation.Save("3D_bevel_effect.pptx", SaveFormat.Pptx);
}
```


Le résultat :

![The 3D bevel effect](3D-bevel-effect.png)

## **Ajouter des effets de rotation 3D**

Aspose.Slides vous permet d’appliquer des effets de rotation 3D aux formes en configurant leurs propriétés [ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/threedformat/).

Pour appliquer une rotation 3D à une forme :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Obtenez une référence à une diapositive par son indice.
1. Ajoutez une [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) à la diapositive.
1. Définissez le [CameraType](https://reference.aspose.com/slides/net/aspose.slides/icamera/cameratype/) et le [LightType](https://reference.aspose.com/slides/net/aspose.slides/ilightrig/lighttype/) de la forme pour définir la rotation 3D.
1. Enregistrez la présentation.

Le code C# suivant montre comment appliquer des effets de rotation 3D à une forme :
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

    // Enregistrer la présentation au format PPTX.
    presentation.Save("3D_rotation_effect.pptx", SaveFormat.Pptx);
}
```


Le résultat :

![The 3D rotation effect](3D-rotation-effect.png)

## **Réinitialiser le formatage**

Le code C# suivant montre comment réinitialiser le formatage d’une diapositive et restaurer la position, la taille et le formatage de toutes les formes avec espaces réservés sur le [LayoutSlide](https://reference.aspose.com/slides/net/aspose.slides/layoutslide/) à leurs paramètres par défaut :
```c#
using (Presentation presentation = new Presentation("sample.pptx"))
{
    foreach (ISlide slide in presentation.Slides)
    {
        // Réinitialiser chaque forme sur la diapositive qui possède un espace réservé sur la disposition.
        slide.Reset();
    }

    presentation.Save("reset_formatting.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**Le formatage des formes affecte‑t‑il la taille finale du fichier de présentation ?**

Seulement de façon minimale. Les images et les médias intégrés occupent la majeure partie de l’espace du fichier, tandis que les paramètres de forme tels que les couleurs, les effets et les dégradés sont stockés comme métadonnées et n’ajoutent pratiquement aucune taille supplémentaire.

**Comment détecter les formes d’une diapositive qui partagent un formatage identique afin de les regrouper ?**

Comparez les principales propriétés de formatage de chaque forme — remplissage, ligne et paramètres d’effet. Si toutes les valeurs correspondantes sont identiques, considérez leurs styles comme identiques et regroupez logiquement ces formes, ce qui simplifie la gestion ultérieure des styles.

**Puis‑je enregistrer un ensemble de styles de forme personnalisés dans un fichier séparé pour les réutiliser dans d’autres présentations ?**

Oui. Enregistrez des formes d’exemple avec les styles souhaités dans un jeu de diapositives modèle ou un fichier modèle .POTX. Lors de la création d’une nouvelle présentation, ouvrez le modèle, clonez les formes stylisées dont vous avez besoin et réappliquez leur formatage où cela est requis.