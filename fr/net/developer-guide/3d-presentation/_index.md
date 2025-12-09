---
title: Créer des présentations 3D en .NET
linktitle: Présentation 3D
type: docs
weight: 232
url: /fr/net/3d-presentation/
keywords:
- PowerPoint 3D
- présentation 3D
- rotation 3D
- profondeur 3D
- extrusion 3D
- dégradé 3D
- texte 3D
- PowerPoint
- OpenDocument
- présentation
- .NET
- C#
- Aspose.Slides
description: "Générez facilement des présentations 3D interactives en .NET avec Aspose.Slides. Exportez rapidement aux formats PowerPoint et OpenDocument pour une utilisation polyvalente."
---

## **Vue d’ensemble**
Comment créez‑vous habituellement une présentation PowerPoint 3D ?
Microsoft PowerPoint permet de créer des présentations 3D en ajoutant des modèles 3D, en appliquant des effets 3D aux formes, en créant du texte 3D, en téléchargeant des graphiques 3D dans la présentation, et en créant des animations 3D PowerPoint.

Créer des effets 3D a un impact considérable sur l’amélioration de votre présentation en la transformant en présentation 3D, et peut être la mise en œuvre la plus simple d’une présentation 3D.
Depuis la version 20.9 d’Aspose.Slides, un nouveau **moteur 3D multiplateforme** a été ajouté. Le nouveau moteur 3D permet d’exporter et de rasteriser les formes et le texte avec des effets 3D. Dans les versions précédentes, les formes Slides avec des effets 3D appliqués étaient rendues à plat. Mais maintenant, il est possible de rendre les formes avec un **3D complet**.
De plus, il est maintenant possible de créer des formes avec des effets 3D via l’API publique Slides.

Dans l’API Aspose.Slides, pour qu’une forme devienne une forme PowerPoint 3D, utilisez la propriété [IShape.ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/properties/threedformat), qui hérite des fonctionnalités de l’interface [IThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat) :
- [BevelBottom](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/bevelbottom) et [BevelTop](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/beveltop) : définissez le biseau de la forme, choisissez le type de biseau (par ex. Angle, Circle, SoftRound), définissez la hauteur et la largeur du biseau.
- [Camera](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/camera) : sert à imiter les mouvements de la caméra autour de l’objet. En d’autres termes, en réglant la rotation, le zoom et d’autres propriétés, vous pouvez animer vos formes comme un modèle 3D dans PowerPoint.
- [ContourColor](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/contourcolor) et [ContourWidth](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/contourwidth) : définissez les propriétés de contour pour que la forme ressemble à une forme PowerPoint 3D.
- [Depth](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/depth), [ExtrusionColor](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusioncolor) et [ExtrusionHeight](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusionheight) : permettent de donner une troisième dimension à la forme, c’est‑à‑dire de convertir une forme 2D en forme 3D en définissant sa profondeur ou en l’extrudant.
- [LightRig](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/lightrig) : crée un effet de lumière sur une forme 3D. La logique de cette propriété est proche de Camera, vous pouvez régler la rotation de la lumière par rapport à la forme #D et choisir le type de lumière.
- [Material](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/material) : définir le type de matériau de la forme 3D peut la rendre plus réaliste. La propriété fournit un ensemble de matériaux prédéfinis, tels que : Metal, Plastic, Powder, Matte, etc.

Toutes les fonctionnalités 3D peuvent être appliquées aux formes et au texte. Voyons comment accéder aux propriétés mentionnées ci‑dessus, puis examinons‑les en détail, étape par étape :
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


La vignette rendue ressemble à ceci :

![todo:image_alt_text](img_01_01.png)

## **Rotation 3D**
Il est possible de faire pivoter les formes PowerPoint 3D dans le plan 3D, ce qui apporte plus d’interactivité. Pour faire pivoter une forme 3D dans PowerPoint, utilisez généralement le menu suivant :

![todo:image_alt_text](img_02_01.png)

Dans l’API Aspose.Slides, la rotation d’une forme 3D peut être gérée à l’aide de la propriété [IThreeDFormat.Camera](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/camera) :
``` csharp
IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
// ... définir les autres paramètres de la scène 3D

using (IImage thumbnail = slide.GetImage(imageScale, imageScale))
{
    thumbnail.Save("sample_3d.png");
}
```


## **Profondeur 3D et Extrusion**
Pour ajouter la troisième dimension à votre forme et en faire une forme 3D, utilisez les propriétés [IThreeDFormat.ExtrusionHeight](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusionheight) et [IThreeDFormat.ExtrusionColor.Color](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusioncolor) :
``` csharp
IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
shape.ThreeDFormat.ExtrusionHeight = 100;
shape.ThreeDFormat.ExtrusionColor.Color = Color.Purple;
// ... définir les autres paramètres de la scène 3D

using (IImage thumbnail = slide.GetImage(imageScale, imageScale))
{
    thumbnail.Save("sample_3d.png");
}
```


Habituellement, vous utilisez le menu Depth dans PowerPoint pour définir la profondeur d’une forme PowerPoint 3D :

![todo:image_alt_text](img_02_02.png)

## **Dégradé 3D**
Le dégradé peut être utilisé pour remplir la couleur d’une forme PowerPoint 3D. Créons une forme avec un remplissage en dégradé et appliquons‑y un effet 3D :
``` csharp
const float imageScale = 2;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);
    shape.TextFrame.Text = "3D Gradient";
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

En plus d’un remplissage en dégradé, il est possible de remplir les formes avec une image :
``` csharp
byte[] imageData = File.ReadAllBytes("image.jpg");
IPPImage image = presentation.Images.AddImage(imageData);

shape.FillFormat.FillType = FillType.Picture;
shape.FillFormat.PictureFillFormat.Picture.Image = image;
shape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
// ... configuration 3D : shape.ThreeDFormat.Camera, shape.ThreeDFormat.LightRig, shape.ThreeDFormat.Extrusion* properties

using (IImage thumbnail = slide.GetImage(imageScale, imageScale))
{
    thumbnail.Save("sample_3d.png");
}
```


Voici à quoi cela ressemble :

![todo:image_alt_text](img_02_04.png)

## **Texte 3D (WordArt)**
Aspose.Slides permet également d’appliquer le 3D au texte. Pour créer un texte 3D, vous pouvez utiliser l’effet de transformation WordArt :
``` csharp
const float imageScale = 2;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);
    shape.FillFormat.FillType = FillType.NoFill;
    shape.LineFormat.FillFormat.FillType = FillType.NoFill;
    shape.TextFrame.Text = "3D Text";

    Portion portion = (Portion)shape.TextFrame.Paragraphs[0].Portions[0];
    portion.PortionFormat.FillFormat.FillType = FillType.Pattern;
    portion.PortionFormat.FillFormat.PatternFormat.ForeColor.Color = Color.DarkOrange;
    portion.PortionFormat.FillFormat.PatternFormat.BackColor.Color = Color.White;
    portion.PortionFormat.FillFormat.PatternFormat.PatternStyle = PatternStyle.LargeGrid;

    shape.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight = 128;

    ITextFrameFormat textFrameFormat = shape.TextFrame.TextFrameFormat;
    // définir l'effet de transformation WordArt "Arch Up"
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

## **FAQ**

**Les effets 3D seront‑ils conservés lors de l’exportation d’une présentation vers des images/PDF/HTML ?**

Oui. Le moteur 3D de Slides rend les effets 3D lors de l’exportation vers les formats pris en charge ([images](/slides/fr/net/convert-powerpoint-to-png/), [PDF](/slides/fr/net/convert-powerpoint-to-pdf/), [HTML](/slides/fr/net/convert-powerpoint-to-html/), etc.).

**Puis‑je récupérer les valeurs “effectives” (finales) des paramètres 3D qui tiennent compte des thèmes, de l’héritage, etc. ?**

Oui. Slides propose des API pour [lire les valeurs effectives](/slides/fr/net/shape-effective-properties/) (y compris pour le 3D — éclairage, biseaux, etc.) afin que vous puissiez voir les paramètres finaux appliqués.

**Les effets 3D fonctionnent‑ils lors de la conversion d’une présentation en vidéo ?**

Oui. Lors de la [génération des images pour la vidéo](/slides/fr/net/convert-powerpoint-to-video/), les effets 3D sont rendus exactement comme ils le sont pour les [images exportées](/slides/fr/net/convert-powerpoint-to-png/).