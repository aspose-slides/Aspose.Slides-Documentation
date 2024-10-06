---
title: Mise en forme des formes
type: docs
weight: 20
url: /net/shape-formatting/
keywords:
- mise en forme des formes
- mise en forme des lignes
- styles de jonction de format
- remplissage dégradé
- remplissage de motifs
- remplissage d'image
- remplissage de couleur unie
- faire pivoter les formes
- effets de biseau 3D
- effet de rotation 3D
- présentation PowerPoint
- C#
- Csharp
- Aspose.Slides pour .NET
description: "Mettez en forme une forme dans une présentation PowerPoint en C# ou .NET"
---

Dans PowerPoint, vous pouvez ajouter des formes aux diapositives. Étant donné que les formes sont composées de lignes, vous pouvez formater les formes en modifiant ou en appliquant certains effets à leurs lignes constitutives. De plus, vous pouvez formater les formes en spécifiant des paramètres qui déterminent comment elles (la zone en elles) sont remplies.

![format-shape-powerpoint](format-shape-powerpoint.png)

**Aspose.Slides pour .NET** fournit des interfaces et des propriétés qui vous permettent de formater des formes en fonction des options connues dans PowerPoint.

## **Mise en forme des lignes**

Avec Aspose.Slides, vous pouvez spécifier le style de ligne de votre choix pour une forme. Ces étapes décrivent une telle procédure :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Obtenez une référence à la diapositive par son index.
3. Ajoutez une [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape) à la diapositive.
4. Définissez une couleur pour les lignes de la forme.
5. Définissez la largeur des lignes de la forme.
6. Définissez le [style de ligne](https://reference.aspose.com/slides/net/aspose.slides/linestyle) pour la ligne de la forme.
7. Définissez le [style de tiret](http://aspose.com/api/net/slides/aspose.slides/linedashstyle) pour la ligne de la forme.
8. Écrivez la présentation modifiée sous forme de fichier PPTX.

Ce code C# démontre une opération où nous avons formaté un rectangle `AutoShape` :

```c#
// Instancie une classe de présentation qui représente un fichier de présentation
using (Presentation pres = new Presentation())
{
    // Obtient la première diapositive
    ISlide sld = pres.Slides[0];

    // Ajoute une autoshape de type rectangle
    IShape shp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 150, 75);

    // Définit la couleur de remplissage pour la forme rectangle
    shp.FillFormat.FillType = FillType.Solid;
    shp.FillFormat.SolidFillColor.Color = Color.White;

    // Applique un certain formatage sur les lignes du rectangle
    shp.LineFormat.Style = LineStyle.ThickThin;
    shp.LineFormat.Width = 7;
    shp.LineFormat.DashStyle = LineDashStyle.Dash;

    // Définit la couleur pour la ligne du rectangle
    shp.LineFormat.FillFormat.FillType = FillType.Solid;
    shp.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;

    // Écrit le fichier PPTX sur le disque
    pres.Save("RectShpLn_out.pptx", SaveFormat.Pptx);
}
```

## **Styles de jonction de format**
Voici les 3 options de type de jonction :

* Rond
* Miter
* Biseau

Par défaut, lorsque PowerPoint joint deux lignes sous un angle (ou le coin d'une forme), il utilise le paramètre **Rond**. Cependant, si vous souhaitez dessiner une forme avec des angles très aigus, vous voudrez peut-être sélectionner **Miter**.

![join-style-powerpoint](join-style-powerpoint.png)

Ce C# démontre une opération où 3 rectangles (l'image ci-dessus) ont été créés avec les paramètres de type de jonction Miter, Biseau et Rond :

```c#
// Instancie une classe de présentation qui représente un fichier de présentation
using (Presentation pres = new Presentation())
{
	// Obtient la première diapositive
	ISlide sld = pres.Slides[0];

	// Ajoute 3 autoshapes rectangulaires
	IShape shp1 = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 100, 150, 75);
	IShape shp2 = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 300, 100, 150, 75);
	IShape shp3 = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 250, 150, 75);

	// Définit la couleur de remplissage pour la forme rectangle
	shp1.FillFormat.FillType = FillType.Solid;
	shp1.FillFormat.SolidFillColor.Color = Color.Black;
	shp2.FillFormat.FillType = FillType.Solid;
	shp2.FillFormat.SolidFillColor.Color = Color.Black;
	shp3.FillFormat.FillType = FillType.Solid;
	shp3.FillFormat.SolidFillColor.Color = Color.Black;

	// Définit la largeur de la ligne
	shp1.LineFormat.Width = 15;
	shp2.LineFormat.Width = 15;
	shp3.LineFormat.Width = 15;

	// Définit la couleur pour la ligne du rectangle
	shp1.LineFormat.FillFormat.FillType = FillType.Solid;
	shp1.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
	shp2.LineFormat.FillFormat.FillType = FillType.Solid;
	shp2.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
	shp3.LineFormat.FillFormat.FillType = FillType.Solid;
	shp3.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;

	// Définit le style de jonction
	shp1.LineFormat.JoinStyle = LineJoinStyle.Miter;
	shp2.LineFormat.JoinStyle = LineJoinStyle.Bevel;
	shp3.LineFormat.JoinStyle = LineJoinStyle.Round;

	// Ajoute du texte à chaque rectangle
	((IAutoShape)shp1).TextFrame.Text = "Style de jonction Miter";
	((IAutoShape)shp2).TextFrame.Text = "Style de jonction Biseau";
	((IAutoShape)shp3).TextFrame.Text = "Style de jonction Rond";

	// Écrit le fichier PPTX sur le disque
	pres.Save("RectShpLnJoin_out.pptx", SaveFormat.Pptx);
}
```

## **Remplissage dégradé**
Dans PowerPoint, le remplissage dégradé est une option de formatage qui vous permet d'appliquer un mélange continu de couleurs à une forme. Par exemple, vous pouvez appliquer deux couleurs ou plus dans un paramètre où une couleur s'estompe progressivement et se transforme en une autre couleur.

Voici comment utiliser Aspose.Slides pour appliquer un remplissage dégradé à une forme :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Obtenez une référence à la diapositive par son index.
3. Ajoutez une [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape) à la diapositive.
4. Définissez le [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype) de la forme sur `Gradient`.
5. Ajoutez vos 2 couleurs préférées avec des positions définies à l'aide des méthodes `Add` exposées par la collection `GradientStops` associée à la classe `GradientFormat`.
6. Écrivez la présentation modifiée sous forme de fichier PPTX.

Ce code C# démontre une opération où l'effet de remplissage dégradé a été utilisé sur une ellipse :

```c#
// Instancie une classe de présentation qui représente un fichier de présentation
using (Presentation pres = new Presentation())
{
    // Obtient la première diapositive
    ISlide sld = pres.Slides[0];

    // Ajoute une autoshape ellipse
    IShape shp = sld.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 150, 75, 150);

    // Applique le formatage dégradé à l'ellipse
    shp.FillFormat.FillType = FillType.Gradient;
    shp.FillFormat.GradientFormat.GradientShape = GradientShape.Linear;

    // Définit la direction du dégradé
    shp.FillFormat.GradientFormat.GradientDirection = GradientDirection.FromCorner2;

    // Ajoute 2 arrêts dégradés
    shp.FillFormat.GradientFormat.GradientStops.Add((float)1.0, PresetColor.Purple);
    shp.FillFormat.GradientFormat.GradientStops.Add((float)0, PresetColor.Red);

    // Écrit le fichier PPTX sur le disque
    pres.Save("EllipseShpGrad_out.pptx", SaveFormat.Pptx);
}
```

## **Remplissage de motifs**
Dans PowerPoint, le remplissage de motifs est une option de formatage qui vous permet d'appliquer un design bicolore composé de points, de rayures, de hachures croisées ou de carreaux à une forme. De plus, vous pouvez sélectionner vos couleurs préférées pour l'avant-plan et l'arrière-plan de votre motif.

Aspose.Slides propose plus de 45 styles prédéfinis qui peuvent être utilisés pour formater des formes et enrichir des présentations. Même après avoir choisi un motif prédéfini, vous pouvez toujours spécifier les couleurs que le motif doit contenir.

Voici comment utiliser Aspose.Slides pour appliquer un remplissage de motifs à une forme :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Obtenez une référence à la diapositive par son index.
3. Ajoutez une [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape) à la diapositive.
4. Définissez le [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype) de la forme sur `Pattern`.
5. Définissez votre style de motif préféré pour la forme.
6. Définissez la [Couleur d'arrière-plan](http://www.aspose.com/api/net/slides/aspose.slides/patternformat/properties/backcolor) pour le [PatternFormat](http://www.aspose.com/api/net/slides/aspose.slides/patternformat).
7. Définissez la [Couleur de premier plan](http://www.aspose.com/api/net/slides/aspose.slides/patternformat/properties/forecolor) pour le [PatternFormat](http://www.aspose.com/api/net/slides/aspose.slides/patternformat).
8. Écrivez la présentation modifiée sous forme de fichier PPTX.

Ce code C# démontre une opération où un remplissage de motifs a été utilisé pour embellir un rectangle :

```c#
// Instancie une classe de présentation qui représente un fichier de présentation
using (Presentation pres = new Presentation())
{
    // Obtient la première diapositive
    ISlide sld = pres.Slides[0];

    // Ajoute une autoshape rectangle
    IShape shp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 75, 150);

    // Définit le type de remplissage sur Motif
    shp.FillFormat.FillType = FillType.Pattern;

    // Définit le style de motif
    shp.FillFormat.PatternFormat.PatternStyle = PatternStyle.Trellis;

    // Définit les couleurs d'arrière-plan et de premier plan du motif
    shp.FillFormat.PatternFormat.BackColor.Color = Color.LightGray;
    shp.FillFormat.PatternFormat.ForeColor.Color = Color.Yellow;

    // Écrit le fichier PPTX sur le disque
    pres.Save("RectShpPatt_out.pptx", SaveFormat.Pptx);
}
```

## **Remplissage d'image**
Dans PowerPoint, le remplissage d'image est une option de formatage qui vous permet d'insérer une image à l'intérieur d'une forme. Essentiellement, vous pouvez utiliser une image comme arrière-plan d'une forme.

Voici comment utiliser Aspose.Slides pour remplir une forme avec une image :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) .
2. Obtenez une référence à la diapositive par son index.
3. Ajoutez une [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape) à la diapositive.
4. Définissez le [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype) de la forme sur `Picture`.
5. Définissez le mode de remplissage d'image sur Tiling.
6. Créez un objet `IPPImage` en utilisant l'image qui sera utilisée pour remplir la forme.
7. Définissez la propriété `Picture.Image` de l'objet `PictureFillFormat` sur le `IPPImage` récemment créé.
8. Écrivez la présentation modifiée sous forme de fichier PPTX.

Ce code C# vous montre comment remplir une forme avec une image :

```c#
// Instancie la classe Presentation qui représente un fichier de présentation
using (Presentation presentation = new Presentation())
{
    // Obtient la première diapositive
    ISlide slide = presentation.Slides[0];

    // Ajoute une autoshape rectangle
    IShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 75, 150);

    // Définit le type de remplissage sur Image
    shape.FillFormat.FillType = FillType.Picture;

    // Définit le mode de remplissage d'image
    shape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Tile;

    // Charge une image et l'ajoute aux ressources de présentation
    IImage image = Images.FromFile("Tulips.jpg");
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    // Définit l'image
    shape.FillFormat.PictureFillFormat.Picture.Image = ppImage;

    // Écrit le fichier PPTX sur le disque
    presentation.Save("RectShpPic_out.pptx", SaveFormat.Pptx);
}
```

## **Remplissage de couleur unie**
Dans PowerPoint, le remplissage de couleur unie est une option de formatage qui vous permet de remplir une forme avec une seule couleur. La couleur choisie est généralement une couleur unie. La couleur est appliquée à l'arrière-plan de la forme sans effets spéciaux ni modifications.

Voici comment utiliser Aspose.Slides pour appliquer un remplissage de couleur unie à une forme :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Obtenez une référence à la diapositive par son index.
3. Ajoutez une [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape) à la diapositive.
4. Définissez le [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype) de la forme sur `Solid`.
5. Définissez votre couleur préférée pour la forme.
6. Écrivez la présentation modifiée sous forme de fichier PPTX.

Ce code C# vous montre comment appliquer le remplissage de couleur unie à un rectangle dans PowerPoint :

```c#
// Instancie une classe de présentation qui représente un fichier de présentation
using (Presentation presentation = new Presentation())
{
    // Obtient la première diapositive
    ISlide slide = presentation.Slides[0];

    // Ajoute une autoshape rectangle
    IShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 75, 150);

    // Définit le type de remplissage sur Solide
    shape.FillFormat.FillType = FillType.Solid;

    // Définit la couleur pour le rectangle
    shape.FillFormat.SolidFillColor.Color = Color.Yellow;

    // Écrit le fichier PPTX sur le disque
    presentation.Save("RectShpSolid_out.pptx", SaveFormat.Pptx);
}
```

## **Définir la transparence**

Dans PowerPoint, lorsque vous remplissez des formes avec des couleurs unies, des dégradés, des images ou des textures, vous pouvez spécifier le niveau de transparence qui détermine l'opacité d'un remplissage. Ainsi, par exemple, si vous définissez un faible niveau de transparence, l'objet ou l'arrière-plan derrière (la forme) apparaît à travers.

Aspose.Slides vous permet de définir le niveau de transparence pour une forme de cette manière :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Obtenez une référence à la diapositive par son index.
3. Ajoutez une [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape) à la diapositive.
4. Utilisez `Color.FromArgb` avec le composant alpha défini.
5. Enregistrez l'objet sous forme de fichier PowerPoint.

Ce code C# démontre le processus :

```c#
// Instancie une classe de présentation qui représente un fichier de présentation
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Ajoute une forme solide
    IShape solidShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 75, 175, 75, 150);

    // Ajoute une forme transparente au-dessus de la forme solide
    IShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 75, 150);
    shape.FillFormat.FillType = FillType.Solid;
    shape.FillFormat.SolidFillColor.Color = Color.FromArgb(128, 204, 102, 0);
    
    // Écrit le fichier PPTX sur le disque
    presentation.Save("ShapeTransparentOverSolid_out.pptx", SaveFormat.Pptx);
}
```

## **Faire pivoter les formes**
Aspose.Slides vous permet de faire pivoter une forme ajoutée à une diapositive de cette manière :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Obtenez une référence à la diapositive par son index.
3. Ajoutez une [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape) à la diapositive.
4. Faites pivoter la forme selon le nombre de degrés nécessaires.
5. Écrivez la présentation modifiée sous forme de fichier PPTX.

Ce code C# vous montre comment faire pivoter une forme de 90 degrés :

```c#
// Instancie une classe de présentation qui représente un fichier de présentation
using (Presentation pres = new Presentation())
{
    // Obtient la première diapositive
    ISlide sld = pres.Slides[0];

    // Ajoute une autoshape rectangle
    IShape shp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 75, 150);

    // Fait pivoter la forme de 90 degrés
    shp.Rotation = 90;

    // Écrit le fichier PPTX sur le disque
    pres.Save("RectShpRot_out.pptx", SaveFormat.Pptx);
}
```

## **Ajouter des effets de biseau 3D**
Aspose.Slides vous permet d'ajouter des effets de biseau 3D à une forme en modifiant ses propriétés [ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ThreeDFormat) de cette manière :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Obtenez une référence à la diapositive par son index.
3. Ajoutez une [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape) à la diapositive.
4. Définissez vos paramètres préférés pour les propriétés [ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ThreeDFormat) de la forme.
5. Écrivez la présentation sur le disque.

Ce code C# vous montre comment ajouter des effets de biseau 3D à une forme :

```c#
// Crée une instance de la classe Presentation
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    
    // Ajoute une forme à la diapositive
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 30, 30, 100, 100);
    shape.FillFormat.FillType = FillType.Solid;
    shape.FillFormat.SolidFillColor.Color = Color.Green;
    ILineFillFormat format = shape.LineFormat.FillFormat;
    format.FillType = FillType.Solid;
    format.SolidFillColor.Color = Color.Orange;
    shape.LineFormat.Width = 2.0;
    
    // Définit les propriétés ThreeDFormat de la forme
    shape.ThreeDFormat.Depth = 4;
    shape.ThreeDFormat.BevelTop.BevelType = BevelPresetType.Circle;
    shape.ThreeDFormat.BevelTop.Height = 6;
    shape.ThreeDFormat.BevelTop.Width = 6;
    shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
    shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.ThreePt;
    shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
    
    // Écrit la présentation sous forme de fichier PPTX
    pres.Save("Bavel_out.pptx", SaveFormat.Pptx);
}
```

## **Ajouter un effet de rotation 3D**
Aspose.Slides vous permet d'appliquer des effets de rotation 3D à une forme en modifiant ses propriétés [ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ThreeDFormat) de cette manière :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Obtenez une référence à la diapositive par son index.
3. Ajoutez une [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape) à la diapositive.
4. Spécifiez vos figures préférées pour [CameraType](https://reference.aspose.com/slides/net/aspose.slides/icamera/properties/cameratype) et [LightType](https://reference.aspose.com/slides/net/aspose.slides/ilightrig/properties/lighttype).
5. Écrivez la présentation sur le disque.

Ce code C# vous montre comment appliquer des effets de rotation 3D à une forme :

```c#
// Crée une instance de la classe Presentation
using (Presentation pres = new Presentation())
{
    IShape autoShape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 30, 30, 200, 200);
    
    autoShape.ThreeDFormat.Depth = 6;
    autoShape.ThreeDFormat.Camera.SetRotation(40, 35, 20);
    autoShape.ThreeDFormat.Camera.CameraType = CameraPresetType.IsometricLeftUp;
    autoShape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;
    
    autoShape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Line, 30, 300, 200, 200);
    autoShape.ThreeDFormat.Depth = 6;
    autoShape.ThreeDFormat.Camera.SetRotation(0, 35, 20);
    autoShape.ThreeDFormat.Camera.CameraType = CameraPresetType.IsometricLeftUp;
    autoShape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;
    
    // Écrit la présentation sous forme de fichier PPTX
    pres.Save("Rotation_out.pptx", SaveFormat.Pptx);
}
```

## **Réinitialiser le formatage**

Ce code C# vous montre comment réinitialiser le formatage dans une diapositive et rétablir la position, la taille et le formatage de chaque forme ayant un espace réservé sur [LayoutSlide](https://reference.aspose.com/slides/net/aspose.slides/layoutslide/) à leurs valeurs par défaut :

```c#
using (Presentation pres = new Presentation())
{
    foreach (ISlide slide in pres.Slides)
    {
        // chaque forme sur la diapositive qui a un espace réservé sur la disposition sera rétablie
        slide.Reset();
    }
}
```