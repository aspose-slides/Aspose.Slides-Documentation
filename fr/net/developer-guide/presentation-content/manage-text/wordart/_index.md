---
title: Créer et appliquer des effets WordArt dans .NET
linktitle: WordArt
type: docs
weight: 110
url: /fr/net/wordart/
keywords:
- WordArt
- créer WordArt
- modèle WordArt
- effet WordArt
- effet d'ombre
- effet de réflexion
- effet de lueur
- transformation WordArt
- effet 3D
- effet d'ombre extérieure
- effet d'ombre intérieure
- .NET
- C#
- Aspose.Slides
description: "Créer et personnaliser des effets WordArt dans Aspose.Slides pour .NET. Ce guide étape par étape aide les développeurs à améliorer les présentations avec du texte professionnel en C#."
---
## **Vue d'ensemble**

Les effets WordArt vous permettent de styliser du texte avec des remplissages, des contours, des ombres, des reflets, une lueur, des transformations et un formatage 3D. Cet article explique comment créer et personnaliser ces effets dans les présentations PowerPoint en utilisant Aspose.Slides pour .NET, sans Microsoft Office installé.

## **Créer un modèle WordArt simple et l'appliquer au texte**

Les exemples suivants créent un style WordArt simple en définissant le texte, la police, le remplissage de motif et le contour.

Chaque exemple crée une nouvelle présentation et ajoute un rectangle à la première diapositive ; aucun fichier d'entrée n'est requis. Le premier exemple définit le texte sur "Aspose.Slides". La position et les dimensions de la forme sont mesurées en points :
```cs
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
var textFrame = autoShape.TextFrame;

var portion = textFrame.Paragraphs[0].Portions[0];
portion.Text = "Aspose.Slides";
```

Définissez la police à Arial Black à 36 points pour rendre le formatage plus visible :
```cs
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

var portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
portion.Text = "Aspose.Slides";
portion.PortionFormat.LatinFont = new FontData("Arial Black");
portion.PortionFormat.FontHeight = 36;
```

Appliquez un motif [SmallGrid](https://reference.aspose.com/slides/fr/net/aspose.slides/patternstyle/) avec un premier plan orange foncé et un arrière-plan blanc, puis ajoutez un contour de texte noir d'une épaisseur de 1 point :
```cs
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

var portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
portion.Text = "Aspose.Slides";
portion.PortionFormat.LatinFont = new FontData("Arial Black");
portion.PortionFormat.FontHeight = 36;

portion.PortionFormat.FillFormat.FillType = FillType.Pattern;
portion.PortionFormat.FillFormat.PatternFormat.ForeColor.Color = Color.DarkOrange;
portion.PortionFormat.FillFormat.PatternFormat.BackColor.Color = Color.White;
portion.PortionFormat.FillFormat.PatternFormat.PatternStyle = PatternStyle.SmallGrid;

portion.PortionFormat.LineFormat.Width = 1;
portion.PortionFormat.LineFormat.FillFormat.FillType = FillType.Solid;
portion.PortionFormat.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
```

Le texte résultant :
![Le modèle WordArt simple](WordArt_template.png)

## **Appliquer d'autres effets WordArt**

Les exemples suivants démontrent comment appliquer des ombres, des reflets, une lueur, des transformations et des effets 3D au texte.

### **Appliquer des effets d'ombre extérieure**

Une ombre extérieure ajoute de la profondeur en plaçant une ombre derrière le texte. Vous pouvez personnaliser sa couleur, sa direction, sa distance, son rayon de flou, son échelle et son inclinaison.

Cet exemple appelle [EnableOuterShadowEffect](https://reference.aspose.com/slides/fr/net/aspose.slides/effectformat/enableoutershadoweffect/) et définit une ombre noire avec un rayon de flou de 4 points, une direction de 230 degrés et une distance de 30 points. Les valeurs d'échelle de 100 conservent la taille de l'ombre, tandis que l'inclinaison horizontale l'incline de 20 degrés. La transformation alpha règle son opacité à 32 % :
```cs
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

var portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
portion.Text = "Aspose.Slides";
portion.PortionFormat.LatinFont = new FontData("Arial Black");
portion.PortionFormat.FontHeight = 36;

portion.PortionFormat.EffectFormat.EnableOuterShadowEffect();
portion.PortionFormat.EffectFormat.OuterShadowEffect.ShadowColor.Color = Color.Black;
portion.PortionFormat.EffectFormat.OuterShadowEffect.ScaleHorizontal = 100;
portion.PortionFormat.EffectFormat.OuterShadowEffect.ScaleVertical = 100;
portion.PortionFormat.EffectFormat.OuterShadowEffect.BlurRadius = 4;
portion.PortionFormat.EffectFormat.OuterShadowEffect.Direction = 230;
portion.PortionFormat.EffectFormat.OuterShadowEffect.Distance = 30;
portion.PortionFormat.EffectFormat.OuterShadowEffect.SkewHorizontal = 20;
portion.PortionFormat.EffectFormat.OuterShadowEffect.SkewVertical = 0;
portion.PortionFormat.EffectFormat.OuterShadowEffect.ShadowColor.ColorTransform.Add(ColorTransformOperation.SetAlpha, 0.32f);
```

Le texte résultant :
![L'effet d'ombre extérieure](outer_shadow_effect.png)

{{% alert color="info" title="Note" %}}
- Lorsque les ombres extérieures et les ombres prédéfinies sont utilisées ensemble, seule l'ombre extérieure est appliquée.
- Si les ombres extérieures et intérieures sont utilisées simultanément, l'effet résultant dépend de la version de PowerPoint. Par exemple, dans PowerPoint 2013, l'effet est doublé, alors que dans PowerPoint 2007, seule l'ombre extérieure est appliquée.
{{% /alert %}}

### **Appliquer des effets de réflexion**

Une réflexion crée une copie miroir du texte. Ajustez sa position, son échelle, son flou et son opacité pour contrôler son apparence.

Cet exemple appelle [EnableReflectionEffect](https://reference.aspose.com/slides/fr/net/aspose.slides/effectformat/enablereflectioneffect/) et retourne la réflexion verticalement avec une échelle de -100 %. Il utilise un rayon de flou de 0,5 point et une distance de 4,72 points. L'opacité diminue de 60 % à 0,9 % entre les positions 0 % et 60 % le long de la réflexion :
```cs
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

var portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
portion.Text = "Aspose.Slides";
portion.PortionFormat.LatinFont = new FontData("Arial Black");
portion.PortionFormat.FontHeight = 36;

portion.PortionFormat.EffectFormat.EnableReflectionEffect();
portion.PortionFormat.EffectFormat.ReflectionEffect.BlurRadius = 0.5;
portion.PortionFormat.EffectFormat.ReflectionEffect.Distance = 4.72;
portion.PortionFormat.EffectFormat.ReflectionEffect.StartPosAlpha = 0f;
portion.PortionFormat.EffectFormat.ReflectionEffect.EndPosAlpha = 60f;
portion.PortionFormat.EffectFormat.ReflectionEffect.Direction = 90;
portion.PortionFormat.EffectFormat.ReflectionEffect.ScaleHorizontal = 100;
portion.PortionFormat.EffectFormat.ReflectionEffect.ScaleVertical = -100;
portion.PortionFormat.EffectFormat.ReflectionEffect.StartReflectionOpacity = 60f;
portion.PortionFormat.EffectFormat.ReflectionEffect.EndReflectionOpacity = 0.9f;
portion.PortionFormat.EffectFormat.ReflectionEffect.RectangleAlign = RectangleAlignment.BottomLeft;
```

L'effet de réflexion:
![L'effet de réflexion](reflection_effect.png)

### **Appliquer des effets de lueur**

Une lueur ajoute un contour doux coloré autour du texte. Ajustez sa couleur, son opacité et son rayon pour contrôler l'effet.

Cet exemple appelle [EnableGlowEffect](https://reference.aspose.com/slides/fr/net/aspose.slides/effectformat/enablegloweffect/) et applique une lueur rouge avec une opacité de 54 % et un rayon de 7 points :
```cs
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

var portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
portion.Text = "Aspose.Slides";
portion.PortionFormat.LatinFont = new FontData("Arial Black");
portion.PortionFormat.FontHeight = 36;

portion.PortionFormat.EffectFormat.EnableGlowEffect();
portion.PortionFormat.EffectFormat.GlowEffect.Color.Color = System.Drawing.Color.Red;
portion.PortionFormat.EffectFormat.GlowEffect.Color.ColorTransform.Add(ColorTransformOperation.SetAlpha, 0.54f);
portion.PortionFormat.EffectFormat.GlowEffect.Radius = 7;
```

L'effet de lueur:
![L'effet de lueur](glow_effect.png)

### **Appliquer des transformations WordArt**

Les transformations WordArt plient, étirent ou déforment un bloc de texte.

Définissez [Transform](https://reference.aspose.com/slides/fr/net/aspose.slides/textframeformat/transform/) sur [ArchUpPour](https://reference.aspose.com/slides/fr/net/aspose.slides/textshapetype/) pour courber le cadre de texte complet vers le haut :
```cs
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

var textFrame = autoShape.TextFrame;
textFrame.Text = "Aspose.Slides";
textFrame.TextFrameFormat.Transform = TextShapeType.ArchUpPour;
```

La transformation WordArt:
![La transformation WordArt](transform_effect.png)

{{% alert color="info" title="Note" %}}
Aspose.Slides pour .NET fournit un ensemble de [types de transformation](https://reference.aspose.com/slides/fr/net/aspose.slides/textshapetype/) prédéfinis.
{{% /alert %}}

### **Appliquer des effets 3D aux formes et au texte**

Vous pouvez appliquer des effets 3D à une forme ou à son texte. Les biseaux, l'extrusion, l'éclairage et les paramètres de la caméra contrôlent l'apparence résultante.

Le exemple suivant utilise [ThreeDFormat](https://reference.aspose.com/slides/fr/net/aspose.slides/threedformat/) pour ajouter des biseaux circulaires, une extrusion orange et un contour rouge foncé au rectangle. Les dimensions du biseau, la hauteur de l'extrusion, la largeur du contour et la profondeur sont mesurées en points. Un matériau plastique, un éclairage équilibré tourné de 40 degrés autour de l'axe Z, et une caméra en perspective définissent son apparence :
```cs
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
autoShape.TextFrame.Text = "Aspose.Slides";

autoShape.ThreeDFormat.BevelBottom.BevelType = BevelPresetType.Circle;
autoShape.ThreeDFormat.BevelBottom.Height = 10.5;
autoShape.ThreeDFormat.BevelBottom.Width = 10.5;

autoShape.ThreeDFormat.BevelTop.BevelType = BevelPresetType.Circle;
autoShape.ThreeDFormat.BevelTop.Height = 12.5;
autoShape.ThreeDFormat.BevelTop.Width = 11;

autoShape.ThreeDFormat.ExtrusionColor.Color = Color.Orange;
autoShape.ThreeDFormat.ExtrusionHeight = 6;

autoShape.ThreeDFormat.ContourColor.Color = Color.DarkRed;
autoShape.ThreeDFormat.ContourWidth = 1.5;

autoShape.ThreeDFormat.Depth = 3;

autoShape.ThreeDFormat.Material = MaterialPresetType.Plastic;

autoShape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
autoShape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;
autoShape.ThreeDFormat.LightRig.SetRotation(0, 0, 40);

autoShape.ThreeDFormat.Camera.CameraType = CameraPresetType.PerspectiveContrastingRightFacing;
```

L'effet 3D de la forme:
![L'effet 3D de la forme](shape_3D_effect.png)

Cet exemple applique un formatage 3D similaire au texte via [TextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/fr/net/aspose.slides/textframeformat/threedformat/). De plus petits biseaux façonnent les bords des lettres, tandis que l'extrusion et l'éclairage donnent de la profondeur au texte :
```cs
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
var textFrame = autoShape.TextFrame;
textFrame.Text = "Aspose.Slides";

textFrame.TextFrameFormat.ThreeDFormat.BevelBottom.BevelType = BevelPresetType.Circle;
textFrame.TextFrameFormat.ThreeDFormat.BevelBottom.Height = 3.5;
textFrame.TextFrameFormat.ThreeDFormat.BevelBottom.Width = 3.5;

textFrame.TextFrameFormat.ThreeDFormat.BevelTop.BevelType = BevelPresetType.Circle;
textFrame.TextFrameFormat.ThreeDFormat.BevelTop.Height = 4;
textFrame.TextFrameFormat.ThreeDFormat.BevelTop.Width = 4;

textFrame.TextFrameFormat.ThreeDFormat.ExtrusionColor.Color = Color.Orange;
textFrame.TextFrameFormat.ThreeDFormat.ExtrusionHeight = 6;

textFrame.TextFrameFormat.ThreeDFormat.ContourColor.Color = Color.DarkRed;
textFrame.TextFrameFormat.ThreeDFormat.ContourWidth = 1.5;

textFrame.TextFrameFormat.ThreeDFormat.Depth = 3;

textFrame.TextFrameFormat.ThreeDFormat.Material = MaterialPresetType.Plastic;

textFrame.TextFrameFormat.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
textFrame.TextFrameFormat.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;
textFrame.TextFrameFormat.ThreeDFormat.LightRig.SetRotation(0, 0, 40);

textFrame.TextFrameFormat.ThreeDFormat.Camera.CameraType = CameraPresetType.PerspectiveContrastingRightFacing;
```

L'effet 3D du texte:
![L'effet 3D du texte](text_3D_effect.png)

{{% alert color="info" title="Note" %}}
L'application des effets 3D au texte ou à leurs formes — et l'interaction entre ces effets — est régie par des règles spécifiques. Considérez une scène impliquant à la fois le texte et la forme qui le contient. Un effet 3D comprend la représentation 3D de l'objet et la scène dans laquelle il est placé.

- Si une scène est définie à la fois pour la forme et pour le texte, la scène de la forme prend le dessus et la scène du texte est ignorée.
- Si la forme n'a pas sa propre scène mais possède une représentation 3D, la scène du texte est utilisée.
- Si la forme n'a aucun effet 3D, elle est traitée comme plate, et l'effet 3D n'est appliqué qu'au texte.

Ces comportements sont liés aux propriétés [ThreeDFormat.LightRig](https://reference.aspose.com/slides/fr/net/aspose.slides/threedformat/lightrig/) et [ThreeDFormat.Camera](https://reference.aspose.com/slides/fr/net/aspose.slides/threedformat/camera/).
{{% /alert %}}

Consultez [Conserver le texte plat sur une forme 3D](/slides/fr/net/3d-presentation/) pour une comparaison des deux réglages et un exemple complet en C#.

## **FAQ**

**Puis-je utiliser les effets WordArt avec différentes polices ou systèmes d'écriture (p.ex. arabe, chinois) ?**  
Oui, Aspose.Slides pour .NET prend en charge Unicode et fonctionne avec toutes les principales polices et systèmes d'écriture. Les effets WordArt tels que l'ombre, le remplissage et le contour peuvent être appliqués quelle que soit la langue, bien que la disponibilité des polices et le rendu puissent dépendre des polices du système.

**Puis-je appliquer des effets WordArt aux éléments du masque des diapositives ?**  
Oui, vous pouvez appliquer des effets WordArt aux formes du masque des diapositives, y compris les espaces réservés au titre, les pieds de page ou le texte d'arrière-plan. Les modifications apportées à la mise en page du masque se répercuteront sur toutes les diapositives associées.

**Les effets WordArt influent-ils sur la taille du fichier de présentation ?**  
Légèrement. Les effets WordArt tels que les ombres, les lueurs et les remplissages en dégradé peuvent augmenter légèrement la taille du fichier en raison des métadonnées de formatage ajoutées, mais la différence est généralement négligeable.

**Puis-je prévisualiser le résultat des effets WordArt sans enregistrer la présentation ?**  
Oui, vous pouvez rendre les diapositives contenant du WordArt en images (p. ex. PNG, JPEG) à l'aide de [ISlide.GetImage](https://reference.aspose.com/slides/fr/net/aspose.slides/islide/getimage/), ou rendre des formes individuelles avec [IShape.GetImage](https://reference.aspose.com/slides/fr/net/aspose.slides/ishape/getimage/). Cela vous permet de prévisualiser le résultat en mémoire ou à l'écran avant d'enregistrer ou d'exporter la présentation complète.