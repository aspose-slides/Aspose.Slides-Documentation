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
- effet d'affichage
- effet de lueur
- transformation WordArt
- effet 3D
- effet d'ombre extérieure
- effet d'ombre interne
- .NET
- C#
- Aspose.Slides
description: "Créer et personnaliser des effets WordArt avec Aspose.Slides pour .NET. Ce guide étape par étape aide les développeurs à améliorer les présentations avec du texte professionnel en C#."
---

## **Aperçu**

Les effets WordArt vous permettent d’ajouter du texte visuellement attrayant et stylisé à vos présentations PowerPoint. Avec Aspose.Slides pour .NET, les développeurs peuvent créer, personnaliser et gérer le WordArt de manière programmatique, tout comme dans Microsoft PowerPoint—sans avoir besoin d’Office installé. Cet article donne un aperçu du travail avec le WordArt en .NET, y compris comment appliquer des transformations de texte, des styles de remplissage, des contours, des ombres et d’autres options de mise en forme pour rendre le contenu de votre présentation plus expressif et engageant. Le WordArt vous permet de traiter le texte comme un objet graphique. Il se compose d’effets ou de modifications spéciales appliquées au texte pour le rendre plus attractif ou visible.

## **Créer un modèle WordArt simple et l’appliquer au texte**

Dans cette section, nous explorerons comment créer un modèle WordArt simple et l’appliquer au texte à l’aide d’Aspose.Slides pour .NET. WordArt offre un moyen facile d’améliorer l’apparence du texte avec des effets visuels frappants et des styles. En apprenant les étapes de base pour créer et utiliser le WordArt, vous pourrez facilement adapter ces techniques à tout projet, rendant vos présentations plus dynamiques et mémorables.

Tout d’abord, nous créons du texte simple avec le code C# suivant :
```cs
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    ITextFrame textFrame = autoShape.TextFrame;

    IPortion portion = textFrame.Paragraphs[0].Portions[0];
    portion.Text = "Aspose.Slides";
}
```


Ensuite, nous définissons la hauteur de la police du texte à une valeur plus grande pour rendre l’effet plus visible avec le code suivant :
```cs
    portion.PortionFormat.LatinFont = new FontData("Arial Black");
    portion.PortionFormat.FontHeight = 36;
```


Ici, nous appliquons le remplissage de motif SmallGrid au texte et ajoutons un contour de texte noir d’une largeur de 1 avec le code suivant :
```cs
    portion.PortionFormat.FillFormat.FillType = FillType.Pattern;
    portion.PortionFormat.FillFormat.PatternFormat.ForeColor.Color = Color.DarkOrange;
    portion.PortionFormat.FillFormat.PatternFormat.BackColor.Color = Color.White;
    portion.PortionFormat.FillFormat.PatternFormat.PatternStyle = PatternStyle.SmallGrid;
                
    portion.PortionFormat.LineFormat.FillFormat.FillType = FillType.Solid;
    portion.PortionFormat.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
```


Le texte résultant :

![Le modèle WordArt simple](WordArt_template.png)

## **Appliquer d’autres effets WordArt**

En plus des transformations de base, Aspose.Slides pour .NET vous permet d’appliquer une variété d’effets WordArt avancés pour améliorer l’apparence de votre texte. Il s’agit notamment des contours, remplissages, ombres, reflets et effets de lueur. En combinant ces fonctionnalités, vous pouvez créer des styles de texte accrocheurs qui se démarquent dans vos présentations. Cette section montre comment appliquer ces effets de manière programmatique à l’aide d’exemples de code simples et clairs.

### **Appliquer des effets d’ombre extérieure**

Les effets d’ombre extérieure aident le texte à se détacher en ajoutant une ombre derrière son contour, créant ainsi une impression de profondeur et de séparation du fond. Aspose.Slides pour .NET permet d’appliquer et de personnaliser facilement les ombres extérieures sur le texte WordArt. Dans cette section, vous apprendrez à définir la couleur de l’ombre, la direction, la distance, le rayon de flou, etc., pour obtenir l’impact visuel souhaité.

Le fragment de code C# suivant applique un effet d’ombre au texte créé précédemment.
```cs
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

![L’effet d’ombre extérieure](outer_shadow_effect.png)

{{% alert color="primary" %}} 

- Lorsque OuterShadow et PresetShadow sont utilisés ensemble, seul l’effet OuterShadow est appliqué.
- Si OuterShadow et InnerShadow sont utilisés simultanément, l’effet résultant dépend de la version de PowerPoint. Par exemple, dans PowerPoint 2013, l’effet est doublé, tandis que dans PowerPoint 2007, seul l’effet OuterShadow est appliqué.

{{% /alert %}}

### **Appliquer des effets de réflexion**

Dans cette section, nous verrons comment appliquer des effets de réflexion dans vos diapositives à l’aide d’Aspose.Slides pour .NET. Les effets de réflexion peuvent être un moyen efficace de donner à votre texte ou à vos formes un look élégant et moderne, aidant les éléments clés à se démarquer et ajoutant de la profondeur à votre présentation. En comprenant le processus d’application et de personnalisation de ces effets, vous pourrez facilement les adapter à vos besoins de conception et à votre identité visuelle.

Ajoutez un effet de réflexion au texte avec cet exemple de code C# :
```cs
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


Le texte résultant :

![L’effet de réflexion](reflection_effect.png)

### **Appliquer des effets de lueur**

Dans cette section, nous explorerons comment appliquer un effet de lueur au texte à l’aide d’Aspose.Slides pour .NET. L’effet de lueur peut faire ressortir votre texte grâce à un contour lumineux, améliorant l’attrait visuel de vos diapositives. En ajustant des paramètres tels que la couleur et l’intensité, vous pouvez facilement adapter la lueur à votre conception et à votre identité de marque, assurant que les points clés de votre présentation captent l’attention du public.

Appliquez un effet de lueur au texte pour le faire briller ou se démarquer avec le code suivant :
```cs
    portion.PortionFormat.EffectFormat.EnableGlowEffect();
    portion.PortionFormat.EffectFormat.GlowEffect.Color.R = 255;
    portion.PortionFormat.EffectFormat.GlowEffect.Color.ColorTransform.Add(ColorTransformOperation.SetAlpha, 0.54f);
    portion.PortionFormat.EffectFormat.GlowEffect.Radius = 7;
```


Le texte résultant :

![L’effet de lueur](glow_effect.png)

### **Appliquer des transformations WordArt**

Dans cette section, nous explorerons comment utiliser des transformations dans le WordArt avec Aspose.Slides pour .NET. Les transformations vous permettent de plier, étirer ou déformer le texte, créant des effets uniques et visuellement frappants. En maîtrisant ces techniques, vous pourrez facilement adapter les formes et les styles de texte à votre identité ou à votre vision créative, garantissant une présentation percutante et soignée.

Utilisez la propriété `Transform` (qui s’applique à l’ensemble du bloc de texte) avec le code suivant :
```cs
    textFrame.TextFrameFormat.Transform = TextShapeType.ArchUpPour;
```


Le texte résultant :

![La transformation WordArt](transform_effect.png)

{{% alert color="primary" %}} 

Aspose.Slides pour .NET fournit un ensemble de [types de transformation](https://reference.aspose.com/slides/net/aspose.slides/textshapetype/) prédéfinis.

{{% /alert %}} 

### **Appliquer des effets 3D aux formes et au texte**

Créer des visuels réalistes et accrocheurs peut considérablement améliorer l’impact de vos présentations. Dans cette section, nous explorerons comment appliquer des effets tridimensionnels (3D) aux formes à l’aide d’Aspose.Slides pour .NET. En manipulant des paramètres tels que la profondeur, l’angle et l’éclairage, vous pouvez produire des transformations 3D impressionnantes qui captent immédiatement l’attention de votre auditoire. Que vous visiez des subtils reflets ou des illustrations dramatiques, ces fonctionnalités offrent des moyens flexibles d’élever votre design et de transmettre vos idées de façon plus captivante.

Utilisez le code d’exemple suivant pour appliquer un effet 3D à la forme :
```cs
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


La forme résultante :

![L’effet 3D de la forme](shape_3D_effect.png)

Utilisez le code d’exemple suivant pour appliquer un effet 3D au texte :
```cs
    textFrame.TextFrameFormat.ThreeDFormat.BevelBottom.BevelType = BevelPresetType.Circle;
    textFrame.TextFrameFormat.ThreeDFormat.BevelBottom.Height = 3.5;
    textFrame.TextFrameFormat.ThreeDFormat.BevelBottom.Width = 3.5;

    textFrame.TextFrameFormat.ThreeDFormat.BevelTop.BevelType = BevelPresetType.Circle;
    textFrame.TextFrameFormat.ThreeDFormat.BevelTop.Height = 4;
    textFrame.TextFrameFormat.ThreeDFormat.BevelTop.Width = 4;

    textFrame.TextFrameFormat.ThreeDFormat.ExtrusionColor.Color = Color.Orange;
    textFrame.TextFrameFormat.ThreeDFormat.ExtrusionHeight= 6;

    textFrame.TextFrameFormat.ThreeDFormat.ContourColor.Color = Color.DarkRed;
    textFrame.TextFrameFormat.ThreeDFormat.ContourWidth = 1.5;

    textFrame.TextFrameFormat.ThreeDFormat.Depth= 3;

    textFrame.TextFrameFormat.ThreeDFormat.Material = MaterialPresetType.Plastic;

    textFrame.TextFrameFormat.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
    textFrame.TextFrameFormat.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;
    textFrame.TextFrameFormat.ThreeDFormat.LightRig.SetRotation(0, 0, 40);

    textFrame.TextFrameFormat.ThreeDFormat.Camera.CameraType = CameraPresetType.PerspectiveContrastingRightFacing;
```


Le texte résultant :

![L’effet 3D du texte](text_3D_effect.png)

{{% alert color="primary" %}} 

L’application des effets 3D au texte ou à leurs formes—et l’interaction entre ces effets—est régie par des règles spécifiques. Considérez une scène comportant à la fois un texte et la forme qui le contient. Un effet 3D comprend la représentation 3D de l’objet et la scène sur laquelle il est placé.

- Si une scène est définie à la fois pour la forme et pour le texte, la scène de la forme prime et celle du texte est ignorée.
- Si la forme n’a pas sa propre scène mais possède une représentation 3D, la scène du texte est utilisée.
- Si la forme n’a aucun effet 3D, elle est traitée comme plate, et l’effet 3D n’est appliqué qu’au texte.

Ces comportements concernent les propriétés [ThreeDFormat.LightRig](https://reference.aspose.com/slides/net/aspose.slides/threedformat/lightrig/) et [ThreeDFormat.Camera](https://reference.aspose.com/slides/net/aspose.slides/threedformat/camera/).

{{% /alert %}} 

## **FAQ**

**Puis-je utiliser les effets WordArt avec différentes polices ou scripts (par exemple, arabe, chinois) ?**

Oui, Aspose.Slides pour .NET prend en charge Unicode et fonctionne avec toutes les polices et scripts majeurs. Les effets WordArt tels que l’ombre, le remplissage et le contour peuvent être appliqués quelle que soit la langue, bien que la disponibilité des polices et le rendu puissent dépendre des polices système.

**Puis-je appliquer les effets WordArt aux éléments du masque des diapositives ?**

Oui, vous pouvez appliquer des effets WordArt aux formes du masque des diapositives, y compris les espaces réservés de titre, les pieds de page ou le texte d’arrière‑plan. Les modifications apportées à la disposition du masque se répercuteront sur toutes les diapositives associées.

**Les effets WordArt affectent-ils la taille du fichier de présentation ?**

Légèrement. Les effets WordArt comme les ombres, les lueurs et les remplissages dégradés peuvent augmenter légèrement la taille du fichier en raison des métadonnées de mise en forme ajoutées, mais la différence est généralement négligeable.

**Puis-je prévisualiser le résultat des effets WordArt sans enregistrer la présentation ?**

Oui, vous pouvez rendre les diapositives contenant du WordArt en images (par exemple PNG, JPEG) à l’aide de la méthode `GetImage` des interfaces [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) ou [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide/). Cela vous permet de prévisualiser le résultat en mémoire ou à l’écran avant d’enregistrer ou d’exporter la présentation complète.