---
title: Présentation 3D
type: docs
weight: 232
url: /net/3d-presentation/
keywords:
- 3D
- PowerPoint 3D
- présentation 3D
- rotation 3D
- profondeur 3D
- extrusion 3D
- dégradé 3D
- texte 3D
- présentation PowerPoint
- C#
- Csharp
- Aspose.Slides pour .NET
description: "Présentation PowerPoint 3D en C# ou .NET"
---


## Aperçu
Comment créez-vous généralement une présentation PowerPoint 3D ? 
Microsoft PowerPoint permet de créer des présentations 3D en ajoutant des modèles 3D, en appliquant des effets 3D sur des formes, 
en créant du texte 3D, en téléchargeant des graphiques 3D dans une présentation, et en créant des animations 3D PowerPoint.

Créer des effets 3D a un grand impact sur l'amélioration de votre présentation en une présentation 3D, et peut être la mise en œuvre la plus simple d'une présentation 3D. 
Depuis la version 20.9 d'Aspose.Slides, un **moteur 3D multiplateforme** a été ajouté. Le nouveau moteur 3D permet 
d'exporter et de rasteriser des formes et du texte avec des effets 3D. Dans les versions précédentes, 
les formes de diapositives avec des effets 3D appliqués étaient rendues plates. Mais, il est maintenant possible de 
rendre des formes avec un **3D complet**.
De plus, il est maintenant possible de créer des formes avec des effets 3D via l'API publique des diapositives.

Dans l'API Aspose.Slides, pour faire en sorte qu'une forme devienne une forme 3D PowerPoint, utilisez la propriété [IShape.ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/properties/threedformat), 
qui hérite des fonctionnalités de l'interface [IThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat) :
- [BevelBottom](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/bevelbottom) 
et [BevelTop](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/beveltop) : définir le biseau de la forme, définir le type de biseau (par exemple, Angle, Cercle, Bord doux), définir la hauteur et la largeur du biseau.
- [Camera](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/camera) : est utilisé pour imiter les mouvements de la caméra autour de l'objet. En d'autres termes, en réglant la rotation de la caméra, le zoom et d'autres propriétés - vous pouvez divertir vos 
formes comme avec le modèle 3D dans PowerPoint.
- [ContourColor](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/contourcolor) 
et [ContourWidth](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/contourwidth) : définir les propriétés de contour pour faire en sorte que la forme ressemble à une forme 3D PowerPoint.
- [Depth](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/depth), 
[ExtrusionColor](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusioncolor) 
et [ExtrusionHeight](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusionheight) : sont utilisés pour rendre la forme tridimensionnelle, ce qui signifie convertir une forme 2D en une forme 3D, 
en réglant sa profondeur ou en l'extrudant.
- [LightRig](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/lightrig) : peut créer un effet de lumière sur une forme 3D. La logique de cette propriété est similaire à celle de la caméra, vous pouvez régler la rotation de la lumière 
par rapport à la forme 3D et choisir le type de lumière.
- [Material](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/material) : définir le type de matériau de la forme 3D peut apporter un effet plus vivant. La propriété fournit un ensemble de matériaux prédéfinis, tels que : 
Métal, Plastique, Poudre, Mat, etc.

Toutes les fonctionnalités 3D peuvent être appliquées à la fois aux formes et au texte. Voyons comment accéder aux propriétés mentionnées ci-dessus et les examiner en détail étape par étape :
``` csharp 
const float imageScale = 2;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);
    shape.TextFrame.Text = "3D";
    shape.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight = 64;

    shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
    shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
    shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Flat;
    shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
    shape.ThreeDFormat.Material = MaterialPresetType.Flat;
    shape.ThreeDFormat.ExtrusionHeight = 100;
    shape.ThreeDFormat.ExtrusionColor.Color = Color.Blue;

    using (IImage thumbnail = slide.GetImage(imageScale, imageScale))
    {
        thumbnail.Save("sample_3d.png");
    }

    presentation.Save("sandbox_3d.pptx", SaveFormat.Pptx);
}
```

La miniature rendue ressemble à ceci :

![todo:image_alt_text](img_01_01.png)

## Rotation 3D
Il est possible de faire pivoter les formes 3D PowerPoint dans un plan 3D, ce qui apporte plus d'interactivité. Pour faire pivoter une forme 3D dans PowerPoint, vous utilisez généralement le menu suivant :

![todo:image_alt_text](img_02_01.png)

Dans l'API Aspose.Slides, la rotation des formes 3D peut être gérée en utilisant la propriété [IThreeDFormat.Camera](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/camera) :

``` csharp
IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
// ... définir d'autres paramètres de scène 3D

using (IImage thumbnail = slide.GetImage(imageScale, imageScale))
{
    thumbnail.Save("sample_3d.png");
}
```

## Profondeur 3D et extrusion
Pour apporter la troisième dimension à votre forme et en faire une forme 3D, utilisez les propriétés [IThreeDFormat.ExtrusionHeight](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusionheight) 
et [IThreeDFormat.ExtrusionColor.Color](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusioncolor) :

``` csharp
IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
shape.ThreeDFormat.ExtrusionHeight = 100;
shape.ThreeDFormat.ExtrusionColor.Color = Color.Purple;
// ... définir d'autres paramètres de scène 3D

using (IImage thumbnail = slide.GetImage(imageScale, imageScale))
{
    thumbnail.Save("sample_3d.png");
}
```

En général, vous utilisez le menu Profondeur dans PowerPoint pour définir la profondeur d'une forme 3D PowerPoint :

![todo:image_alt_text](img_02_02.png)


## Dégradé 3D
Un dégradé peut être utilisé pour remplir la couleur d'une forme PowerPoint 3D. Créons une forme avec une couleur de dégradé et appliquons un effet 3D dessus :

``` csharp
const float imageScale = 2;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);
    shape.TextFrame.Text = "Dégradé 3D";
    shape.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight = 64;

    shape.FillFormat.FillType = FillType.Gradient;
    shape.FillFormat.GradientFormat.GradientStops.Add(0, Color.Blue);
    shape.FillFormat.GradientFormat.GradientStops.Add(100, Color.Orange);
    
    shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
    shape.ThreeDFormat.Camera.SetRotation(10, 20, 30);
    shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Flat;
    shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
    shape.ThreeDFormat.ExtrusionHeight = 150;
    shape.ThreeDFormat.ExtrusionColor.Color = Color.DarkOrange;

    using (IImage thumbnail = slide.GetImage(imageScale, imageScale))
    {
        thumbnail.Save("sample_3d.png");
    }
}
```

Et voici le résultat :

![todo:image_alt_text](img_02_03.png)

En plus d'une couleur de remplissage dégradée, il est possible de remplir des formes avec une image :
``` csharp
byte[] imageData = File.ReadAllBytes("image.jpg");
IPPImage image = presentation.Images.AddImage(imageData);

shape.FillFormat.FillType = FillType.Picture;
shape.FillFormat.PictureFillFormat.Picture.Image = image;
shape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
// ... configurer 3D : shape.ThreeDFormat.Camera, shape.ThreeDFormat.LightRig, shape.ThreeDFormat.Extrusion* propriétés

using (IImage thumbnail = slide.GetImage(imageScale, imageScale))
{
    thumbnail.Save("sample_3d.png");
}
```

Voici comment cela ressemble :

![todo:image_alt_text](img_02_04.png)

## Texte 3D (WordArt)
Aspose.Slides permet également d'appliquer un effet 3D au texte. Pour créer un texte 3D, vous pouvez utiliser l'effet de transformation WordArt :

``` csharp
const float imageScale = 2;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);
    shape.FillFormat.FillType = FillType.NoFill;
    shape.LineFormat.FillFormat.FillType = FillType.NoFill;
    shape.TextFrame.Text = "Texte 3D";

    Portion portion = (Portion)shape.TextFrame.Paragraphs[0].Portions[0];
    portion.PortionFormat.FillFormat.FillType = FillType.Pattern;
    portion.PortionFormat.FillFormat.PatternFormat.ForeColor.Color = Color.DarkOrange;
    portion.PortionFormat.FillFormat.PatternFormat.BackColor.Color = Color.White;
    portion.PortionFormat.FillFormat.PatternFormat.PatternStyle = PatternStyle.LargeGrid;

    shape.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight = 128;

    ITextFrameFormat textFrameFormat = shape.TextFrame.TextFrameFormat;
    // définir l'effet de transformation WordArt "Arc vers le haut"
    textFrameFormat.Transform = TextShapeType.ArchUp;

    textFrameFormat.ThreeDFormat.ExtrusionHeight = 3.5f;
    textFrameFormat.ThreeDFormat.Depth = 3;
    textFrameFormat.ThreeDFormat.Material = MaterialPresetType.Plastic;
    textFrameFormat.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
    textFrameFormat.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;
    textFrameFormat.ThreeDFormat.LightRig.SetRotation(0, 0, 40);

    textFrameFormat.ThreeDFormat.Camera.CameraType = CameraPresetType.PerspectiveContrastingRightFacing;

    using (IImage thumbnail = slide.GetImage(imageScale, imageScale))
    {
        thumbnail.Save("text3d.png");
    }

    presentation.Save("text3d.pptx", SaveFormat.Pptx);
}
```

Voici le résultat :

![todo:image_alt_text](img_02_05.png)


## Non pris en charge - À venir
Les fonctionnalités 3D PowerPoint suivantes ne sont pas encore prises en charge : 
- Biseau
- Matériau
- Contour
- Éclairage

Nous continuons d'améliorer notre moteur 3D, et ces fonctionnalités sont sujettes à une mise en œuvre ultérieure.