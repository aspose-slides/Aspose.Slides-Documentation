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
description: "Appliquer et rendre les effets 3D pour les formes et le texte PowerPoint dans .NET avec Aspose.Slides. Configurer la caméra, l'éclairage, le matériau, l'extrusion, les remplissages et le texte 3D."
---
## **Vue d'ensemble**

Aspose.Slides for .NET peut créer, modifier, conserver et rendre le formatage 3D de type PowerPoint pour les formes et le texte. Cet article couvre les effets 3D tels que la rotation, l'extrusion, les chanfreins, l'éclairage, le matériau, les remplissages en dégradé ou image, et le texte 3D.

{{% alert color="info" title="Note" %}}
Cet article porte sur les effets de formatage 3D appliqués aux formes et au texte PowerPoint. Il ne s'agit pas d'insérer ou de modifier des fichiers de modèle 3D autonomes. Lorsque vous exportez une diapositive vers une image, un PDF ou un HTML, Aspose.Slides rend ces effets 3D dans la sortie 2D exportée.
{{% /alert %}}

## **Concepts de formatage 3D**

Utilisez la propriété [IShape.ThreeDFormat](https://reference.aspose.com/slides/fr/net/aspose.slides/ishape/properties/threedformat) pour appliquer un formatage 3D à une forme. Cette propriété expose [IThreeDFormat](https://reference.aspose.com/slides/fr/net/aspose.slides/ithreedformat), qui contrôle la scène 3D de cette forme.

Pour le texte, utilisez la propriété [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/fr/net/aspose.slides/itextframeformat/properties/threedformat). Cela applique le formatage 3D au cadre de texte plutôt qu’au corps de la forme.

Les propriétés les plus importantes sont :

| Propriété | Ce qu’elle contrôle | Quand l’utiliser |
|---|---|---|
| [Camera](https://reference.aspose.com/slides/fr/net/aspose.slides/ithreedformat/properties/camera) | Point de vue, type de caméra prédéfini, rotation, zoom et perspective. | Faire pivoter l’objet dans l’espace 3D ou correspondre à un préréglage de rotation 3D de PowerPoint. |
| [LightRig](https://reference.aspose.com/slides/fr/net/aspose.slides/ithreedformat/properties/lightrig) | Préréglage d’éclairage, direction et rotation de la lumière. | Modifier la façon dont les reflets et les ombres apparaissent sur la surface 3D. |
| [Material](https://reference.aspose.com/slides/fr/net/aspose.slides/ithreedformat/properties/material) | Matériau de surface, tel que plat, mat, plastique ou métal. | Faire paraître la même géométrie plus plate, plus douce, brillante ou métallique. |
| [ExtrusionHeight](https://reference.aspose.com/slides/fr/net/aspose.slides/ithreedformat/properties/extrusionheight) | Distance à laquelle la forme s’étend vers l’arrière depuis sa face avant. | Transformez une forme plate en un objet 3D visiblement épais. |
| [ExtrusionColor](https://reference.aspose.com/slides/fr/net/aspose.slides/ithreedformat/properties/extrusioncolor) | Couleur des faces extrudées. | Rendre la profondeur visible ou coordonner la couleur des côtés avec le remplissage frontal. |
| [Depth](https://reference.aspose.com/slides/fr/net/aspose.slides/ithreedformat/properties/depth) | Profondeur 3D supplémentaire utilisée par le formatage 3D de PowerPoint. | Ajuster finement la profondeur pour les formes ou le texte, notamment en combinaison avec les paramètres de chanfrein et de matériau. |
| [BevelTop](https://reference.aspose.com/slides/fr/net/aspose.slides/ithreedformat/properties/beveltop) et [BevelBottom](https://reference.aspose.com/slides/fr/net/aspose.slides/ithreedformat/properties/bevelbottom) | Bords relevés ou arrondis sur les faces avant et arrière. | Ajouter un bord adouci ou moulé au lieu d’une face plane et tranchante. |
| [ContourColor](https://reference.aspose.com/slides/fr/net/aspose.slides/ithreedformat/properties/contourcolor) et [ContourWidth](https://reference.aspose.com/slides/fr/net/aspose.slides/ithreedformat/properties/contourwidth) | Contour autour de l’objet 3D. | Mettre en évidence la limite de l’objet dans la sortie rendue. |

## **Créer une forme 3D**

Une forme nécessite généralement quatre types de paramètres avant d’apparaître de façon convaincante en 3D :

- Paramètres de caméra, car la vue frontale par défaut peut masquer l’extrusion.
- Paramètres d’éclairage, car l’éclairage rend les faces et les côtés lisibles.
- Paramètres de matériau, car la surface influence la façon dont la lumière est rendue.
- Paramètres d’extrusion ou de profondeur, car une forme plate a besoin d’épaisseur.

L’exemple suivant crée un rectangle, ajoute du texte à sa face avant et applique un formatage 3D. Les valeurs de rotation de la caméra sont exprimées en degrés, et la hauteur d’extrusion est de 100 points. L’exemple rend la diapositive en image PNG à deux fois ses dimensions par défaut et enregistre la présentation au format PPTX.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

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

L’image rendue montre le rectangle comme un bloc 3D épais :

![Rectangle bleu 3D rendu avec texte 3D blanc sur la face avant](img_01_01.png)

## **Faire pivoter une forme avec la caméra**

Dans PowerPoint, la rotation 3D est configurée à partir du volet Rotation 3‑D. Les valeurs de rotation X, Y et Z correspondent à la rotation que vous définissez via l’API caméra.

![Volet Rotation 3‑D de PowerPoint avec les valeurs de rotation X, Y et Z mises en évidence](img_02_01.png)

Dans Aspose.Slides, accédez à la caméra via [IThreeDFormat.Camera](https://reference.aspose.com/slides/fr/net/aspose.slides/ithreedformat/properties/camera). Cet exemple crée un rectangle, sélectionne une vue frontale orthographique et définit ses rotations X, Y et Z à 20, 30 et 40 degrés respectivement. Il configure la forme en mémoire sans enregistrer de fichier :

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
```

Utilisez la caméra lorsque vous devez modifier la façon dont le spectateur voit l’objet. Elle ne modifie pas la géométrie 2D de la forme sur la diapositive. Elle change le point de vue 3D utilisé par PowerPoint et par Aspose.Slides lors du rendu.

## **Ajouter une extrusion et de la profondeur**

L’extrusion rend une forme épaisse en l’étendant derrière la face avant. Dans PowerPoint, le contrôle de profondeur définit cette épaisseur visible, et le contrôle de couleur définit la couleur des faces latérales.

![Contrôles de profondeur de PowerPoint associés aux propriétés couleur d’extrusion et hauteur d’extrusion](img_02_02.png)

Définissez [IThreeDFormat.ExtrusionHeight](https://reference.aspose.com/slides/fr/net/aspose.slides/ithreedformat/properties/extrusionheight) pour l’épaisseur et [IThreeDFormat.ExtrusionColor](https://reference.aspose.com/slides/fr/net/aspose.slides/ithreedformat/properties/extrusioncolor) pour la couleur des côtés. Cet exemple attribue au rectangle une extrusion de 100 points avec des côtés violets et fait pivoter la caméra pour révéler son épaisseur. Il configure la forme en mémoire sans enregistrer de fichier :

```csharp
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Flat;
shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
shape.ThreeDFormat.Material = MaterialPresetType.Flat;
shape.ThreeDFormat.ExtrusionHeight = 100;
shape.ThreeDFormat.ExtrusionColor.Color = Color.Purple;
```

La propriété [IThreeDFormat.Depth](https://reference.aspose.com/slides/fr/net/aspose.slides/ithreedformat/properties/depth) définit la profondeur d’une forme 3D. La propriété [ExtrusionHeight](https://reference.aspose.com/slides/fr/net/aspose.slides/ithreedformat/properties/extrusionheight) contrôle la hauteur de l’effet d’extrusion, comme le montre cet exemple.

## **Utiliser des remplissages en dégradé ou image avec des effets 3D**

Le formatage 3D est indépendant du remplissage de la forme. Vous pouvez appliquer une couleur unie, un dégradé, un motif ou un remplissage d’image à la face avant tout en conservant les mêmes paramètres de caméra, d’éclairage, de matériau et d’extrusion.

Cet exemple applique un dégradé du bleu à l’orange à la face avant et une couleur orange foncé à l’extrusion de 150 points. Les arrêts du dégradé à 0 et 100 indiquent le début et la fin du dégradé. Les valeurs de rotation de la caméra sont en degrés. La diapositive est rendue en image PNG à deux fois ses dimensions par défaut :

```csharp
using System.Drawing;
using Aspose.Slides;

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

Le rendu conserve le dégradé sur la face avant et rend séparément l’extrusion :

![Rectangle 3D rendu avec un remplissage en dégradé du bleu à l’orange et une extrusion orange](img_02_03.png)

Pour utiliser un remplissage d’image à la place, ajoutez l’image à la présentation et affectez‑la au remplissage de la forme. Cet exemple suppose l’existence d’un fichier nommé “image.jpg” dans le répertoire de travail. Il étire l’image pour remplir le rectangle, applique une extrusion de 150 points et définit la rotation de la caméra en degrés. Il configure la forme en mémoire sans enregistrer ni rendre de fichier :

```csharp
using System.Drawing;
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);

var imageData = File.ReadAllBytes("image.jpg");
var image = presentation.Images.AddImage(imageData);

shape.FillFormat.FillType = FillType.Picture;
shape.FillFormat.PictureFillFormat.Picture.Image = image;
shape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;

shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(10, 20, 30);
shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Flat;
shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
shape.ThreeDFormat.Material = MaterialPresetType.Flat;
shape.ThreeDFormat.ExtrusionHeight = 150;
shape.ThreeDFormat.ExtrusionColor.Color = Color.DarkOrange;
```

L’image est rendue sur la face avant, tandis que l’extrusion est rendue comme la surface latérale 3D :

![Rectangle 3D rendu avec un remplissage photo sur la face avant et une extrusion orange](img_02_04.png)

## **Appliquer le formatage 3D au texte**

Le formatage 3D d’une forme affecte le corps de la forme. Le formatage 3D du texte affecte le cadre de texte. Cela est utile pour des effets de type WordArt où les lettres elles‑mêmes nécessitent extrusion, matériau, éclairage et paramètres de caméra.

L’exemple suivant crée du texte avec un motif en grille orange et blanc, applique une arche ascendante et configure les paramètres 3D via [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/fr/net/aspose.slides/itextframeformat/properties/threedformat). La hauteur d’extrusion et la profondeur sont en points, et la rotation de la lumière en degrés. Le remplissage et le contour de la forme sont masqués afin que seul le texte soit visible. L’exemple rend une image PNG à deux fois les dimensions par défaut de la diapositive et enregistre la présentation au format PPTX :

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

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

Le texte est rendu comme des caractères 3D courbés et extrudés :

![Texte 3D rendu avec une transformation WordArt en arche, remplissage motif orange et extrusion sombre](img_02_05.png)

## **Conserver le texte à plat sur une forme 3D**

Pour que le texte reste lisible tout en conservant l’aspect 3D d’une forme, définissez [ITextFrameFormat.KeepTextFlat](https://reference.aspose.com/slides/fr/net/aspose.slides/itextframeformat/keeptextflat/) via [ITextFrame.TextFrameFormat](https://reference.aspose.com/slides/fr/net/aspose.slides/itextframe/textframeformat/). Lorsque la valeur est `true`, le texte reste en dehors de la scène 3D. Lorsque la valeur est `false`, le texte participe à la scène et suit son orientation 3D.

Ce paramètre ne supprime pas le formatage 3D de la forme : sa caméra, son éclairage, son matériau et son extrusion restent configurés via [IShape.ThreeDFormat](https://reference.aspose.com/slides/fr/net/aspose.slides/ishape/threedformat/). Il diffère également de la rotation ordinaire. [IShape.Rotation](https://reference.aspose.com/slides/fr/net/aspose.slides/ishape/rotation/) fait pivoter la forme dans le plan de la diapositive, tandis que [ITextFrameFormat.RotationAngle](https://reference.aspose.com/slides/fr/net/aspose.slides/itextframeformat/rotationangle/) contrôle la rotation personnalisée du texte dans son cadre. Conserver le texte hors de la scène 3D ne réinitialise aucun de ces angles.

L’exemple autonome suivant crée un rectangle bleu avec texte et le duplique à côté de l’original. Les deux formes ont le même formatage 3D ; seul le paramètre texte diffère : `false` à gauche et `true` à droite. Les angles de la caméra sont en degrés, et la hauteur d’extrusion est de 40 points. L’exemple enregistre la présentation au format PPTX et rend la diapositive de comparaison en PNG à deux fois ses dimensions par défaut.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 70, 160, 240, 140);

shape.TextFrame.Text = "Readable text";
shape.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight = 28;
shape.TextFrame.Paragraphs[0].ParagraphFormat.Alignment = TextAlignment.Center;
shape.TextFrame.TextFrameFormat.AnchoringType = TextAnchorType.Center;
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.CornflowerBlue;

shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(30, 30, 0);
shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Flat;
shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
shape.ThreeDFormat.Material = MaterialPresetType.Flat;
shape.ThreeDFormat.ExtrusionHeight = 40;
shape.ThreeDFormat.ExtrusionColor.Color = Color.RoyalBlue;
shape.TextFrame.TextFrameFormat.KeepTextFlat = false;

var flatTextShape = (IAutoShape)slide.Shapes.AddClone(shape, 400, 160);
flatTextShape.TextFrame.TextFrameFormat.KeepTextFlat = true;

presentation.Save("keep_text_flat.pptx", SaveFormat.Pptx);
using var image = slide.GetImage(2, 2);
image.Save("keep_text_flat.png");
```

À gauche, le texte suit l’orientation 3D. À droite, il reste à plat et plus facile à lire. Les deux rectangles conservent la même extrusion visible et la même orientation 3D.

![Rectangles 3D côte à côte : KeepTextFlat est false à gauche et true à droite](keep_text_flat.png)

## **Comportement d’exportation et de rendu**

Aspose.Slides préserve le formatage 3D lors de l’enregistrement aux formats PowerPoint tels que PPTX. Lors du rendu ou de l’exportation vers des formats à mise en page fixe, la scène 3D est rasterisée ou dessinée dans la sortie en résultat 2D. Cela s’applique lorsque vous rendez des diapositives en [PNG](/slides/fr/net/convert-powerpoint-to-png/), exportez en [PDF](/slides/fr/net/convert-powerpoint-to-pdf/), exportez en [HTML](/slides/fr/net/convert-powerpoint-to-html/), ou générez des images pour la [conversion vidéo](/slides/fr/net/convert-powerpoint-to-video/).

Gardez ces points à l’esprit :

- Les images et les PDF exportés ne sont pas interactifs. L’objet ne peut pas être pivoté par le spectateur après l’exportation.
- L’apparence finale dépend de la combinaison de la caméra, du groupe d’éclairage, du matériau, de l’extrusion, du remplissage et du redimensionnement de la diapositive.
- Si vous devez inspecter les valeurs de formatage héritées ou basées sur le thème, lisez les [propriétés effectives de forme](/slides/fr/net/shape-effective-properties/).
- Certains formats de sortie ne peuvent pas stocker le formatage 3D éditable de PowerPoint. Dans ces formats, le résultat visuel est rendu plutôt que préservé comme paramètres 3D éditables.

## **FAQ**

**Aspose.Slides peut‑il créer des présentations 3D interactives ?**

Aspose.Slides crée et rend les effets 3D de PowerPoint pour les formes et le texte. Il ne rend pas les images, PDF ou pages HTML exportés interactifs comme des scènes 3D que le spectateur peut faire pivoter. Dans PPTX, le formatage 3D reste modifiable dans PowerPoint lorsque le format le prend en charge.

**Quelle est la différence entre un modèle 3D et un effet 3D ?**

Un modèle 3D est un objet 3D distinct inséré dans une présentation. Un effet 3D est un formatage appliqué à une forme ou à du texte PowerPoint ordinaire, tel que rotation, extrusion, chanfrein, éclairage et matériau. Cet article traite des effets 3D.

**Quels paramètres sont nécessaires pour qu’une forme 3D soit visible ?**

Au minimum, définissez une rotation de caméra et soit une extrusion soit une profondeur. En pratique, définissez également un groupe d’éclairage et un matériau afin que les faces rendues présentent des reflets et des ombres clairs.

**Puis‑je appliquer des effets 3D aux formes et au texte ?**

Oui. Utilisez [IShape.ThreeDFormat](https://reference.aspose.com/slides/fr/net/aspose.slides/ishape/properties/threedformat) pour le corps de la forme et [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/fr/net/aspose.slides/itextframeformat/properties/threedformat) pour le texte.

**Les effets 3D apparaissent‑ils lors de l’exportation vers des images, PDF, HTML ou des images vidéo ?**

Oui. Aspose.Slides rend les effets 3D lors de la génération d’images de diapositive, de la sortie PDF, de la sortie HTML et des images utilisées pour la conversion vidéo. La sortie exportée contient l’apparence rendue, pas un objet 3D éditable.

**Puis‑je lire les valeurs 3D finales après l’application de l’héritage et des paramètres du thème ?**

Oui. Utilisez les API de formatage effectif décrites dans [Propriétés effectives de forme](/slides/fr/net/shape-effective-properties/) pour lire les valeurs finales de caméra, de groupe d’éclairage, de chanfrein et les valeurs 3D associées.