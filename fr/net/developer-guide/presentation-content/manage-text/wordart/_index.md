---
title: WordArt
type: docs
weight: 110
url: /net/wordart/
keywords: "WordArt, Art de texte, Créer WordArt, Modèle WordArt, Effets WordArt, Effets d'ombre, Effets d'affichage, Effets de lueur, Transformations WordArt, Effets 3D, Effets d'ombre externe, Effets d'ombre interne, C#, Csharp, Aspose.Slides pour .NET"
description: "Ajouter, manipuler et gérer le WordArt et les effets dans des présentations PowerPoint en C# ou Aspose.Slides pour .NET"
---

## **À propos de WordArt ?**
WordArt ou Art de texte est une fonctionnalité qui vous permet d'appliquer des effets aux textes pour les faire ressortir. Avec WordArt, par exemple, vous pouvez contourner un texte ou le remplir avec une couleur (ou un dégradé), lui ajouter des effets 3D, etc. Vous pouvez également déformer, plier et étirer la forme d'un texte. 

{{% alert color="primary" %}} 

WordArt vous permet de traiter un texte comme vous le feriez avec un objet graphique. WordArt consiste en des effets ou des modifications spéciales appliquées aux textes pour les rendre plus attrayants ou remarquables. 

{{% /alert %}} 

**WordArt dans Microsoft PowerPoint**

Pour utiliser WordArt dans Microsoft PowerPoint, vous devez sélectionner un des modèles WordArt prédéfinis. Un modèle WordArt est un ensemble d'effets qui est appliqué à un texte ou à sa forme. 

**WordArt dans Aspose.Slides**

Dans Aspose.Slides pour .NET 20.10, nous avons implémenté la prise en charge de WordArt et apporté des améliorations à la fonctionnalité dans les versions ultérieures d'Aspose.Slides pour .NET. 

Avec Aspose.Slides pour .NET, vous pouvez facilement créer votre propre modèle WordArt (un effet ou une combinaison d'effets) en C# et l'appliquer à des textes. 

## Création d'un modèle WordArt simple et application à un texte

**Utilisation d'Aspose.Slides** 

Tout d'abord, nous créons un texte simple en utilisant ce code C# : 

``` csharp 
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = autoShape.TextFrame;

    Portion portion = (Portion)textFrame.Paragraphs[0].Portions[0];
    portion.Text = "Aspose.Slides";
}
```
Maintenant, nous définissons la hauteur de police du texte à une valeur plus élevée pour rendre l'effet plus visible à l'aide de ce code :

``` csharp 
FontData fontData = new FontData("Arial Black");
portion.PortionFormat.LatinFont = fontData;
portion.PortionFormat.FontHeight = 36;
```

**Utilisation de Microsoft PowerPoint**

Allez dans le menu des effets WordArt dans Microsoft PowerPoint :

![todo:image_alt_text](image-20200930113926-1.png)

Dans le menu à droite, vous pouvez choisir un effet WordArt prédéfini. Dans le menu à gauche, vous pouvez spécifier les paramètres d'un nouveau WordArt. 

Voici quelques-uns des paramètres ou options disponibles :

![todo:image_alt_text](image-20200930114015-3.png)

**Utilisation d'Aspose.Slides**

Ici, nous appliquons la couleur du motif SmallGrid au texte et ajoutons une bordure de texte noire d'une largeur de 1 avec ce code :

``` csharp 
portion.PortionFormat.FillFormat.FillType = FillType.Pattern;
portion.PortionFormat.FillFormat.PatternFormat.ForeColor.Color = Color.DarkOrange;
portion.PortionFormat.FillFormat.PatternFormat.BackColor.Color = Color.White;
portion.PortionFormat.FillFormat.PatternFormat.PatternStyle = PatternStyle.SmallGrid;
            
portion.PortionFormat.LineFormat.FillFormat.FillType = FillType.Solid;
portion.PortionFormat.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
```

Le texte résultant :

![todo:image_alt_text](image-20200930114108-4.png)

## Application d'autres effets WordArt

**Utilisation de Microsoft PowerPoint**

Depuis l'interface du programme, vous pouvez appliquer ces effets à un texte, bloc de texte, forme ou élément similaire :

![todo:image_alt_text](image-20200930114129-5.png)

Par exemple, les effets d'ombre, de reflet et de lueur peuvent être appliqués à un texte ; les effets de format 3D et de rotation 3D peuvent être appliqués à un bloc de texte ; la propriété des bords doux peut être appliquée à un objet de forme (elle a toujours un effet même lorsqu'aucune propriété de format 3D n'est définie). 

### Application des effets d'ombre

Ici, nous avons l'intention de définir les propriétés relatives à un texte uniquement. Nous appliquons l'effet d'ombre à un texte en utilisant ce code en C# :

``` csharp 
portion.PortionFormat.EffectFormat.EnableOuterShadowEffect();
portion.PortionFormat.EffectFormat.OuterShadowEffect.ShadowColor.Color = Color.Black;
portion.PortionFormat.EffectFormat.OuterShadowEffect.ScaleHorizontal = 100;
portion.PortionFormat.EffectFormat.OuterShadowEffect.ScaleVertical = 65;
portion.PortionFormat.EffectFormat.OuterShadowEffect.BlurRadius = 4.73;
portion.PortionFormat.EffectFormat.OuterShadowEffect.Direction = 230;
portion.PortionFormat.EffectFormat.OuterShadowEffect.Distance = 2;
portion.PortionFormat.EffectFormat.OuterShadowEffect.SkewHorizontal = 30;
portion.PortionFormat.EffectFormat.OuterShadowEffect.SkewVertical = 0;
portion.PortionFormat.EffectFormat.OuterShadowEffect.ShadowColor.ColorTransform.Add(ColorTransformOperation.SetAlpha, 0.32f);
```

L'API Aspose.Slides prend en charge trois types d'ombres : OuterShadow, InnerShadow et PresetShadow. 

 Avec PresetShadow, vous pouvez appliquer une ombre à un texte (en utilisant des valeurs prédéfinies). 

**Utilisation de Microsoft PowerPoint**

Dans PowerPoint, vous pouvez utiliser un type d'ombre. Voici un exemple :

![todo:image_alt_text](image-20200930114225-6.png)

**Utilisation d'Aspose.Slides**

Aspose.Slides permet en fait d'appliquer deux types d'ombres en même temps : InnerShadow et PresetShadow.

**Notes :**

- Lorsque OuterShadow et PresetShadow sont utilisés ensemble, seul l'effet OuterShadow est appliqué. 
- Si OuterShadow et InnerShadow sont utilisés simultanément, l'effet résultant ou appliqué dépend de la version de PowerPoint. Par exemple, dans PowerPoint 2013, l'effet est doublé. Mais dans PowerPoint 2007, l'effet OuterShadow est appliqué. 

### Application de l'affichage aux textes

Nous ajoutons l'affichage au texte grâce à cet exemple de code en C# :

``` csharp 
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

### Application de l'effet de lueur aux textes

Nous appliquons l'effet de lueur au texte pour le faire briller ou ressortir en utilisant ce code :

``` csharp 
portion.PortionFormat.EffectFormat.EnableGlowEffect();
portion.PortionFormat.EffectFormat.GlowEffect.Color.R = 255;
portion.PortionFormat.EffectFormat.GlowEffect.Color.ColorTransform.Add(ColorTransformOperation.SetAlpha, 0.54f);
portion.PortionFormat.EffectFormat.GlowEffect.Radius = 7;
```

Le résultat de l'opération :

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 

Vous pouvez changer les paramètres pour l'ombre, l'affichage et la lueur. Les propriétés des effets sont définies sur chaque portion du texte séparément. 

{{% /alert %}} 

### Utilisation des transformations dans WordArt

Nous utilisons la propriété Transform (inhérente à l'ensemble du bloc de texte) via ce code :
``` csharp 
textFrame.TextFrameFormat.Transform = TextShapeType.ArchUpPour;
```

Le résultat :

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 

À la fois Microsoft PowerPoint et Aspose.Slides pour .NET fournissent un certain nombre de types de transformation prédéfinis. 

{{% /alert %}} 

**Utilisation de PowerPoint**

Pour accéder aux types de transformation prédéfinis, allez à : **Format** -> **TextEffect** -> **Transform**

**Utilisation d'Aspose.Slides**

Pour sélectionner un type de transformation, utilisez l'énumération TextShapeType. 

### Application d'effets 3D aux textes et formes

Nous définissons un effet 3D à une forme de texte en utilisant ce code d'exemple :

``` csharp 
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

Le texte résultant et sa forme :

![todo:image_alt_text](image-20200930114816-9.png)

Nous appliquons un effet 3D au texte avec ce code C# :

``` csharp 
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

Le résultat de l'opération :

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="primary" %}} 

L'application d'effets 3D aux textes ou à leurs formes et les interactions entre les effets sont basées sur certaines règles. 

Considérez une scène pour un texte et la forme contenant ce texte. L'effet 3D contient une représentation 3D de l'objet et la scène sur laquelle l'objet a été placé. 

- Lorsque la scène est définie pour la figure et le texte, la scène de la figure a une priorité plus élevée - la scène du texte est ignorée. 
- Lorsque la figure n'a pas sa propre scène mais a une représentation 3D, la scène du texte est utilisée. 
- Sinon - lorsque la forme n'a d'abord aucun effet 3D - la forme est plate et l'effet 3D n'est appliqué qu'au texte. 

Les descriptions sont liées aux propriétés [ThreeDFormat.LightRig](https://reference.aspose.com/slides/net/aspose.slides/threedformat/properties/lightrig) et [ThreeDFormat.Camera](https://reference.aspose.com/slides/net/aspose.slides/threedformat/properties/camera).

{{% /alert %}} 

## **Appliquer des effets d'ombre externe aux textes**
Aspose.Slides pour .NET fournit les classes [**IOuterShadow**](https://reference.aspose.com/slides/net/aspose.slides.effects/ioutershadow) et [**IInnerShadow**](https://reference.aspose.com/slides/net/aspose.slides.effects/iinnershadow) qui vous permettent d'appliquer des effets d'ombre à un texte porté par TextFrame. Suivez ces étapes :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Obtenez la référence d'une diapositive en utilisant son index.
3. Ajoutez une forme automatique de type Rectangle à la diapositive.
4. Accédez à la TextFrame associée à la forme automatique.
5. Définissez le FillType de la forme automatique sur NoFill.
6. Instanciez la classe OuterShadow.
7. Définissez le BlurRadius de l'ombre.
8. Définissez la Direction de l'ombre.
9. Définissez la Distance de l'ombre.
10. Définissez le RectangleAlign sur TopLeft.
11. Définissez la couleur prédéfinie de l'ombre sur Noir.
12. Enregistrez la présentation sous un fichier PPTX.

Ce code d'exemple en C#—une implémentation des étapes ci-dessus—vous montre comment appliquer l'effet d'ombre externe à un texte :

```c#
using (Presentation pres = new Presentation())
{

    // Obtenez la référence de la diapositive
    ISlide sld = pres.Slides[0];

    // Ajoutez une forme automatique de type Rectangle
    IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // Ajoutez TextFrame au Rectangle
    ashp.AddTextFrame("Aspose TextBox");

    // Désactivez le remplissage de la forme au cas où nous voudrions obtenir l'ombre du texte
    ashp.FillFormat.FillType = FillType.NoFill;

    // Ajoutez une ombre extérieure et définissez tous les paramètres nécessaires
    ashp.EffectFormat.EnableOuterShadowEffect();
    IOuterShadow shadow = ashp.EffectFormat.OuterShadowEffect;
    shadow.BlurRadius = 4.0;
    shadow.Direction = 45;
    shadow.Distance = 3;
    shadow.RectangleAlign = RectangleAlignment.TopLeft;
    shadow.ShadowColor.PresetColor = PresetColor.Black;

    //Écrivez la présentation sur le disque
    pres.Save("pres_out.pptx", SaveFormat.Pptx);
}
```


## **Appliquer l'effet d'ombre interne aux formes**
Suivez ces étapes :

1. Créez une instance de la [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) classe.
2. Obtenez une référence de la diapositive.
3. Ajoutez une forme automatique de type Rectangle.
4. Activez l'InnerShadowEffect.
5. Définissez tous les paramètres nécessaires.
6. Définissez le ColorType sur Scheme.
7. Définissez la couleur du schéma.
8. Enregistrez la présentation sous un fichier [PPTX](https://docs.fileformat.com/presentation/pptx/) .

Ce code d'exemple (basé sur les étapes ci-dessus) vous montre comment ajouter un connecteur entre deux formes en C# :

```c#
using(Presentation presentation = new Presentation())
{
    // Obtenez la référence d'une diapositive
    ISlide slide = presentation.Slides[0];

    // Ajoutez une forme automatique de type Rectangle
    IAutoShape ashp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 400, 300);
    ashp.FillFormat.FillType = FillType.NoFill;

    // Ajoutez TextFrame au Rectangle
    ashp.AddTextFrame("Aspose TextBox");
    IPortion port = ashp.TextFrame.Paragraphs[0].Portions[0];
    IPortionFormat pf = port.PortionFormat;
    pf.FontHeight = 50;

    // Activez l'InnerShadowEffect    
    IEffectFormat ef = pf.EffectFormat;
    ef.EnableInnerShadowEffect();

    // Définissez tous les paramètres nécessaires
    ef.InnerShadowEffect.BlurRadius = 8.0;
    ef.InnerShadowEffect.Direction = 90.0F;
    ef.InnerShadowEffect.Distance = 6.0;
    ef.InnerShadowEffect.ShadowColor.B = 189;

    // Définissez le ColorType sur Scheme
    ef.InnerShadowEffect.ShadowColor.ColorType = ColorType.Scheme;

    // Définissez la couleur du schéma
    ef.InnerShadowEffect.ShadowColor.SchemeColor = SchemeColor.Accent1;

    // Enregistrez la présentation
    presentation.Save("WordArt_out.pptx", SaveFormat.Pptx);
}
```