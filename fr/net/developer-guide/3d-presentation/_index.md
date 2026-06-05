---
title: Créer des effets 3D dans les présentations avec .NET
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
- présentation
- .NET
- C#
- Aspose.Slides
description: "Appliquer et rendre des effets 3D pour les formes et le texte PowerPoint dans .NET avec Aspose.Slides. Configurer la caméra, l’éclairage, le matériau, l’extrusion, les remplissages et le texte 3D."
---
## **Vue d'ensemble**

Aspose.Slides pour .NET peut créer, modifier, préserver et rendre le formatage 3D de style PowerPoint pour les formes et le texte. Cet article couvre les effets 3D tels que la rotation, l'extrusion, les chanfreins, l'éclairage, le matériau, les remplissages en dégradé ou image, et le texte 3D.

{{% alert color="primary" %}}
Cet article porte sur les effets de formatage 3D sur les formes et le texte PowerPoint. Il ne s'agit pas d'insérer ou de modifier des fichiers de modèle 3D autonomes. Lorsque vous exportez une diapositive vers une image, un PDF ou du HTML, Aspose.Slides rend ces effets 3D dans la sortie 2D exportée.
{{% /alert %}}

## **Concepts de formatage 3D**

Utilisez la propriété [IShape.ThreeDFormat](https://reference.aspose.com/slides/fr/net/aspose.slides/ishape/properties/threedformat) pour appliquer un formatage 3D à une forme. La propriété expose [IThreeDFormat](https://reference.aspose.com/slides/fr/net/aspose.slides/ithreedformat), qui contrôle la scène 3D pour cette forme.

Pour le texte, utilisez la propriété [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/fr/net/aspose.slides/itextframeformat/properties/threedformat). Cela applique le formatage 3D au cadre de texte plutôt qu'au corps de la forme.

Les propriétés les plus importantes sont :

| Propriété | Ce qu'elle contrôle | Quand l'utiliser |
|---|---|---|
| [Camera](https://reference.aspose.com/slides/fr/net/aspose.slides/ithreedformat/properties/camera) | Point de vue, type de caméra prédéfini, rotation, zoom et perspective. | Faire pivoter l'objet dans l'espace 3D ou correspondre à un préréglage de rotation 3D de PowerPoint. |
| [LightRig](https://reference.aspose.com/slides/fr/net/aspose.slides/ithreedformat/properties/lightrig) | Préréglage de lumière, direction et rotation de la lumière. | Modifier la façon dont les reflets et les ombres apparaissent sur la surface 3D. |
| [Material](https://reference.aspose.com/slides/fr/net/aspose.slides/ithreedformat/properties/material) | Matériau de surface, tel que plat, mat, plastique ou métal. | Faire paraître la même géométrie plus plate, plus douce, brillante ou métallique. |
| [ExtrusionHeight](https://reference.aspose.com/slides/fr/net/aspose.slides/ithreedformat/properties/extrusionheight) | Distance à laquelle la forme s'étend vers l'arrière depuis sa face avant. | Transformer une forme plate en un objet 3D visiblement épais. |
| [ExtrusionColor](https://reference.aspose.com/slides/fr/net/aspose.slides/ithreedformat/properties/extrusioncolor) | Couleur des côtés extrudés. | Rendre la profondeur visible ou coordonner la couleur du côté avec le remplissage avant. |
| [Depth](https://reference.aspose.com/slides/fr/net/aspose.slides/ithreedformat/properties/depth) | Profondeur 3D supplémentaire utilisée par le formatage 3D de PowerPoint. | Ajuster finement la profondeur pour les formes ou le texte, surtout avec les réglages de chanfrein et de matériau. |
| [BevelTop](https://reference.aspose.com/slides/fr/net/aspose.slides/ithreedformat/properties/beveltop) et [BevelBottom](https://reference.aspose.com/slides/fr/net/aspose.slides/ithreedformat/properties/bevelbottom) | Arêtes surélevées ou arrondies sur les faces avant et arrière. | Ajouter un bord adouci ou moulé au lieu d’une face plane et tranchante. |
| [ContourColor](https://reference.aspose.com/slides/fr/net/aspose.slides/ithreedformat/properties/contourcolor) et [ContourWidth](https://reference.aspose.com/slides/fr/net/aspose.slides/ithreedformat/properties/contourwidth) | Contour autour de l'objet 3D. | Mettre en évidence la frontière de l'objet dans la sortie rendue. |

## **Créer une forme 3D**

Une forme nécessite généralement quatre types de paramètres avant d'apparaître de façon convaincante en 3D :

- Paramètres de la caméra, car la vue frontale par défaut peut masquer l'extrusion.  
- Paramètres de lumière, car l'éclairage rend les faces et les côtés lisibles.  
- Paramètres de matériau, car la surface affecte la façon dont la lumière est rendue.  
- Paramètres d'extrusion ou de profondeur, car une forme plate a besoin d'épaisseur.

L'exemple suivant crée un rectangle, ajoute du texte à sa face avant, applique un formatage 3D, enregistre la présentation au format PPTX et rend la diapositive en image PNG.

```csharp
const float imageScale = 2;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);
shape.TextFrame.Text = "3D";
shape.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight = 64;

shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.CornflowerBlue;

shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Flat;
shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
shape.ThreeDFormat.Material = MaterialPresetType.Flat;
shape.ThreeDFormat.ExtrusionHeight = 100;
shape.ThreeDFormat.ExtrusionColor.Color = Color.Blue;

using var thumbnail = slide.GetImage(imageScale, imageScale);
thumbnail.Save("shape_3d.png");

presentation.Save("shape_3d.pptx", SaveFormat.Pptx);
```

L'image de la diapositive rendue montre le rectangle comme un bloc 3D épais :

![Rectangle 3D bleu rendu avec texte 3D blanc sur la face avant](img_01_01.png)

## **Faire pivoter une forme avec la caméra**

Dans PowerPoint, la rotation 3D est configurée depuis le panneau Rotation 3-D. Les valeurs de rotation X, Y et Z correspondent à la rotation que vous définissez via l'API de la caméra.

![Panneau Rotation 3-D de PowerPoint avec les valeurs de rotation X, Y et Z mises en évidence](img_02_01.png)

Dans Aspose.Slides, définissez le type de caméra et la rotation via [IThreeDFormat.Camera](https://reference.aspose.com/slides/fr/net/aspose.slides/ithreedformat/properties/camera) :

```csharp
shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
```

Utilisez la caméra lorsque vous devez modifier la façon dont le spectateur voit l'objet. Elle ne modifie pas la géométrie 2D de la forme sur la diapositive. Elle change le point de vue 3D utilisé par PowerPoint et Aspose.Slides lors du rendu.

## **Ajouter extrusion et profondeur**

L'extrusion rend une forme épaisse en l'étendant derrière la face avant. Dans PowerPoint, le contrôle de profondeur définit cette épaisseur visible, et le contrôle de couleur définit la couleur des faces latérales.

![Contrôles de profondeur de PowerPoint associés aux propriétés couleur d'extrusion et hauteur d'extrusion](img_02_02.png)

Définissez [IThreeDFormat.ExtrusionHeight](https://reference.aspose.com/slides/fr/net/aspose.slides/ithreedformat/properties/extrusionheight) pour l'épaisseur et [IThreeDFormat.ExtrusionColor](https://reference.aspose.com/slides/fr/net/aspose.slides/ithreedformat/properties/extrusioncolor) pour la couleur des côtés :

```csharp
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
shape.ThreeDFormat.ExtrusionHeight = 100;
shape.ThreeDFormat.ExtrusionColor.Color = Color.Purple;
```

Utilisez [IThreeDFormat.Depth](https://reference.aspose.com/slides/fr/net/aspose.slides/ithreedformat/properties/depth) lorsque vous devez travailler directement avec la valeur de profondeur de PowerPoint ou combiner la profondeur avec le chanfrein, le matériau et les effets de texte. Dans de nombreux scénarios de forme, `ExtrusionHeight` est le réglage le plus clair car il exprime directement l'extrusion visible.

## **Utiliser des remplissages en dégradé ou image avec des effets 3D**

Le formatage 3D est indépendant du remplissage de la forme. Vous pouvez appliquer une couleur unie, un dégradé, un motif ou un remplissage image à la face avant tout en conservant les mêmes paramètres de caméra, lumière, matériau et extrusion.

Cet exemple applique un remplissage en dégradé à la forme et une couleur d'extrusion plus sombre aux côtés :

```csharp
const float imageScale = 2;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);
shape.TextFrame.Text = "3D Gradient";
shape.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight = 64;

shape.FillFormat.FillType = FillType.Gradient;
shape.FillFormat.GradientFormat.GradientStops.Add(0, Color.Blue);
shape.FillFormat.GradientFormat.GradientStops.Add(100, Color.Orange);

shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(10, 20, 30);
shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Flat;
shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
shape.ThreeDFormat.Material = MaterialPresetType.Flat;
shape.ThreeDFormat.ExtrusionHeight = 150;
shape.ThreeDFormat.ExtrusionColor.Color = Color.DarkOrange;

using var thumbnail = slide.GetImage(imageScale, imageScale);
thumbnail.Save("gradient_3d.png");
```

La sortie rendue conserve le dégradé sur la face avant et rend l'extrusion séparément :

![Rectangle 3D rendu avec un remplissage dégradé du bleu à l'orange et une extrusion orange](img_02_03.png)

Pour utiliser un remplissage image à la place, ajoutez l'image à la présentation et attribuez‑la au remplissage de la forme :

```csharp
var imageData = File.ReadAllBytes("image.jpg");
var image = presentation.Images.AddImage(imageData);

shape.FillFormat.FillType = FillType.Picture;
shape.FillFormat.PictureFillFormat.Picture.Image = image;
shape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;

shape.ThreeDFormat.Camera.SetRotation(10, 20, 30);
shape.ThreeDFormat.ExtrusionHeight = 150;
shape.ThreeDFormat.ExtrusionColor.Color = Color.DarkOrange;
```

L'image est rendue sur la face avant, tandis que l'extrusion est rendue comme la surface latérale 3D :

![Rectangle 3D rendu avec un remplissage photo sur la face avant et une extrusion orange](img_02_04.png)

## **Appliquer le formatage 3D au texte**

Le formatage 3D d'une forme affecte le corps de la forme. Le formatage 3D du texte affecte le cadre de texte. Ceci est utile pour des effets de type WordArt où les lettres elles‑mêmes nécessitent extrusion, matériau, éclairage et paramètres de caméra.

L'exemple suivant crée du texte avec un remplissage motif, applique une transformation WordArt et configure les paramètres 3D sur [ITextFrameFormat](https://reference.aspose.com/slides/fr/net/aspose.slides/itextframeformat):

```csharp
const float imageScale = 2;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);
shape.FillFormat.FillType = FillType.NoFill;
shape.LineFormat.FillFormat.FillType = FillType.NoFill;
shape.TextFrame.Text = "3D Text";

var portion = shape.TextFrame.Paragraphs[0].Portions[0];
portion.PortionFormat.FillFormat.FillType = FillType.Pattern;
portion.PortionFormat.FillFormat.PatternFormat.ForeColor.Color = Color.DarkOrange;
portion.PortionFormat.FillFormat.PatternFormat.BackColor.Color = Color.White;
portion.PortionFormat.FillFormat.PatternFormat.PatternStyle = PatternStyle.LargeGrid;

shape.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight = 128;

var textFrameFormat = shape.TextFrame.TextFrameFormat;
textFrameFormat.Transform = TextShapeType.ArchUp;
textFrameFormat.ThreeDFormat.ExtrusionHeight = 3.5f;
textFrameFormat.ThreeDFormat.Depth = 3;
textFrameFormat.ThreeDFormat.Material = MaterialPresetType.Plastic;
textFrameFormat.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
textFrameFormat.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;
textFrameFormat.ThreeDFormat.LightRig.SetRotation(0, 0, 40);
textFrameFormat.ThreeDFormat.Camera.CameraType = CameraPresetType.PerspectiveContrastingRightFacing;

using var thumbnail = slide.GetImage(imageScale, imageScale);
thumbnail.Save("text_3d.png");

presentation.Save("text_3d.pptx", SaveFormat.Pptx);
```

Le texte est rendu sous forme de lettres 3D courbées et extrudées :

![Texte 3D rendu avec une transformation WordArt arquée, remplissage motif orange et extrusion sombre](img_02_05.png)

## **Comportement d'exportation et de rendu**

Aspose.Slides préserve le formatage 3D lors de l'enregistrement aux formats PowerPoint tels que PPTX. Lors du rendu ou de l'exportation vers des formats à mise en page fixe, la scène 3D est rasterisée ou dessinée dans la sortie sous forme d'un résultat 2D. Ceci s'applique lorsque vous rendez des diapositives en [PNG](/slides/fr/net/convert-powerpoint-to-png/), exportez en [PDF](/slides/fr/net/convert-powerpoint-to-pdf/), exportez en [HTML](/slides/fr/net/convert-powerpoint-to-html/), ou générez des images pour la [video conversion](/slides/fr/net/convert-powerpoint-to-video/).

Gardez ces points à l'esprit :

- Les images et PDF exportés ne sont pas interactifs. L'objet ne peut pas être tourné par le spectateur après l'exportation.  
- L'apparence finale dépend de la combinaison de la caméra, du dispositif d'éclairage, du matériau, de l'extrusion, du remplissage et du redimensionnement de la diapositive.  
- Si vous devez inspecter les valeurs de formatage héritées ou basées sur le thème, lisez les [effective shape properties](/slides/fr/net/shape-effective-properties/).  
- Certains formats de sortie ne peuvent pas stocker le formatage 3D éditable de PowerPoint. Dans ces formats, le résultat visuel est rendu plutôt que conservé comme paramètres 3D éditables.

## **FAQ**

**Aspose.Slides peut‑il créer des présentations 3D interactives ?**

Aspose.Slides crée et rend les effets 3D de PowerPoint pour les formes et le texte. Il ne rend pas les images, PDF ou pages HTML exportés interactifs sous forme de scènes 3D que le spectateur peut faire pivoter. Dans les fichiers PPTX, le formatage 3D demeure modifiable dans PowerPoint lorsque le format le permet.

**Quelle est la différence entre un modèle 3D et un effet 3D ?**

Un modèle 3D est un objet 3D distinct inséré dans une présentation. Un effet 3D est un formatage appliqué à une forme ou un texte PowerPoint ordinaire, tel que rotation, extrusion, chanfrein, éclairage et matériau. Cet article couvre les effets 3D.

**Quels paramètres sont requis pour une forme 3D visible ?**

Au minimum, définissez une rotation de la caméra et soit l'extrusion soit la profondeur. En pratique, définissez également un dispositif d'éclairage et un matériau afin que les faces rendues possèdent des reflets et ombres clairs.

**Puis‑je appliquer des effets 3D aux formes et au texte ?**

Oui. Utilisez [IShape.ThreeDFormat](https://reference.aspose.com/slides/fr/net/aspose.slides/ishape/properties/threedformat) pour le corps de la forme et [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/fr/net/aspose.slides/itextframeformat/properties/threedformat) pour le texte.

**Les effets 3D apparaîtront‑ils lors de l'exportation vers des images, PDF, HTML ou des images pour vidéo ?**

Oui. Aspose.Slides rend les effets 3D lors de la production d'images de diapositives, de sorties PDF, HTML et des images utilisées pour la conversion vidéo. La sortie exportée contient l'apparence rendue, pas un objet 3D éditable.

**Puis‑je lire les valeurs 3D finales après application de l'héritage et des paramètres de thème ?**

Oui. Utilisez les API de formatage effectif décrites dans [Shape Effective Properties](/slides/fr/net/shape-effective-properties/) pour lire les valeurs finales de caméra, dispositif d'éclairage, chanfrein et des paramètres 3D associés.