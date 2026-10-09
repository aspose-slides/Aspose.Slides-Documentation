---
title: Appliquer des effets de forme aux présentations en .NET
linktitle: Effet de forme
type: docs
weight: 30
url: /fr/net/shape-effect/
keywords:
- effet de forme
- effet d'ombre
- effet de réflexion
- effet de lueur
- effet de bords doux
- format d'effet
- PowerPoint
- présentation
- .NET
- C#
- Aspose.Slides
description: "Transformez vos fichiers PPT et PPTX avec des effets de forme avancés à l'aide d'Aspose.Slides pour .NET—créez des diapositives percutantes et professionnelles en quelques secondes."
---
## **Introduction**

Alors que les effets dans PowerPoint peuvent être utilisés pour mettre en évidence une forme, ils diffèrent des [remplissages](/slides/fr/net/shape-formatting/#gradient-fill) ou des contours. En utilisant les effets de PowerPoint, vous pouvez créer des reflets convaincants sur une forme, diffuser la lueur d’une forme, etc.

![Effet de forme](shape-effect.png)

PowerPoint propose six effets qui peuvent être appliqués aux formes. Vous pouvez appliquer un ou plusieurs effets à une forme.

Certaines combinaisons d’effets sont plus esthétiques que d’autres. Pour cette raison, PowerPoint propose des options sous **Préréglage**. Les options de Préréglage sont essentiellement une combinaison reconnue d’un bon rendu de deux effets ou plus. Ainsi, en sélectionnant un préréglage, vous n’aurez pas à perdre du temps à tester ou à combiner différents effets pour trouver une belle combinaison.

Aspose.Slides fournit des propriétés et des méthodes dans la classe [EffectFormat](https://reference.aspose.com/slides/net/aspose.slides/effectformat/) qui vous permettent d’appliquer les mêmes effets aux formes dans les présentations PowerPoint.

## **Appliquer un effet d'ombre**

Aspose.Slides pour .NET prend en charge les ombres externes et internes pour les formes. Vous pouvez personnaliser leur couleur, direction, distance et rayon de flou afin de correspondre au design de votre présentation.

### **Appliquer une ombre externe**

Utilisez une ombre externe pour faire ressortir une carte ou un panneau par rapport à l’arrière‑plan de la diapositive. L’ombre dépasse les bords de la forme, créant l’impression que la forme est surélevée au-dessus de la diapositive. Ajustez sa couleur, direction, distance et rayon de flou pour correspondre à l’éclairage et au style de votre modèle.

Ce code C# montre comment appliquer l’[effet d’ombre externe](https://reference.aspose.com/slides/net/aspose.slides/effectformat/outershadoweffect/) à un rectangle :

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
shape.EffectFormat.EnableOuterShadowEffect();
shape.EffectFormat.OuterShadowEffect.ShadowColor.Color = Color.DarkGray;
shape.EffectFormat.OuterShadowEffect.Distance = 10;
shape.EffectFormat.OuterShadowEffect.Direction = 45;

presentation.Save("shadow_effect.pptx", SaveFormat.Pptx);
```

![Effet d’ombre](shadow_effect.png)

### **Appliquer une ombre interne**

Lors de la reproduction du style visuel d’un modèle, utilisez une ombre interne pour donner à une carte ou un panneau un aspect en retrait. Une ombre externe s’étend à l’extérieur de la forme et la fait paraître surélevée, tandis qu’une ombre interne ombre l’intérieur de ses bords.

Appelez [EnableInnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/enableinnershadoweffect/), puis configurez [InnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/innershadoweffect/). Des valeurs plus élevées produisent des bords plus doux.

Cet exemple C# crée une carte bleu clair avec une ombre interne gris foncé et l’enregistre au format PPTX :

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 200, 100);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.LightBlue;
shape.LineFormat.FillFormat.FillType = FillType.NoFill;

shape.EffectFormat.EnableInnerShadowEffect();
var shadow = shape.EffectFormat.InnerShadowEffect;
shadow.ShadowColor.Color = Color.DimGray;
shadow.Direction = 225;
shadow.Distance = 7;
shadow.BlurRadius = 6;

presentation.Save("inner_shadow_effect.pptx", SaveFormat.Pptx);
```

![Rectangle bleu clair avec une ombre interne](inner_shadow_effect.png)

Pour supprimer l’ombre interne, appelez [DisableInnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/disableinnershadoweffect/) sur le format d’effet de la forme.

## **Appliquer un effet de réflexion**

Pour appliquer un effet de réflexion dans Aspose.Slides pour .NET, vous pouvez ajouter une réflexion semblable à un miroir aux formes, en ajustant des paramètres tels que la distance, la transparence et la taille. Cet effet améliore l’esthétique de vos présentations en donnant aux formes un aspect plus soigné et sophistiqué. Il est facile à implémenter avec un code simple, permettant une application rapide sur plusieurs éléments pour un design cohérent.

Ce code C# montre comment appliquer l’[effet de réflexion](https://reference.aspose.com/slides/net/aspose.slides/effectformat/reflectioneffect/) à une forme :

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
shape.EffectFormat.EnableReflectionEffect();
shape.EffectFormat.ReflectionEffect.RectangleAlign = RectangleAlignment.Bottom;
shape.EffectFormat.ReflectionEffect.Direction = 90;
shape.EffectFormat.ReflectionEffect.Distance = 40;
shape.EffectFormat.ReflectionEffect.BlurRadius = 2;

presentation.Save("reflection_effect.pptx", SaveFormat.Pptx);
```

![Effet de réflexion](reflection_effect.png)

## **Appliquer un effet de lueur**

Pour appliquer un effet de lueur à une forme dans Aspose.Slides pour .NET, vous pouvez ajouter une aura douce et lumineuse autour des formes, en ajustant des propriétés telles que la couleur et la taille. Cet effet aide à mettre les formes en évidence et ajoute un élément visuel attractif et accrocheur à votre présentation. Il est facile à implémenter avec un minimum de code, améliorant l’aspect global de vos diapositives.

Ce code C# montre comment appliquer l’[effet de lueur](https://reference.aspose.com/slides/net/aspose.slides/effectformat/gloweffect/) à une forme :

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
shape.EffectFormat.EnableGlowEffect();
shape.EffectFormat.GlowEffect.Color.Color = Color.Magenta;
shape.EffectFormat.GlowEffect.Radius = 15;

presentation.Save("glow_effect.pptx", SaveFormat.Pptx);
```

![Effet de lueur](glow_effect.png)

## **Appliquer un effet de bords doux**

Pour appliquer un effet de bords doux dans Aspose.Slides pour .NET, vous pouvez créer une transition lisse et floue autour des bords d’une forme. Cet effet ajoute un aspect plus subtil et raffiné, parfait pour les conceptions nécessitant une apparence douce et plus légère. Vous pouvez facilement ajuster des paramètres tels que le rayon pour obtenir l’effet souhaité sur différentes formes de votre présentation.

Ce code C# montre comment appliquer les [bords doux](https://reference.aspose.com/slides/net/aspose.slides/effectformat/softedgeeffect/) à une forme :

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150);
shape.EffectFormat.EnableSoftEdgeEffect();
shape.EffectFormat.SoftEdgeEffect.Radius = 8;

presentation.Save("soft_edges_effect.pptx", SaveFormat.Pptx);
```

![Effet de bords doux](soft_edges_effect.png)

## **FAQ**

**Puis-je appliquer plusieurs effets à la même forme ?**  
Oui, vous pouvez combiner différents effets, tels que l’ombre, la réflexion et la lueur, sur une même forme afin de créer un aspect plus dynamique.

**À quelles formes puis‑je appliquer des effets ?**  
Vous pouvez appliquer des effets à diverses formes, y compris les formes automatiques, les graphiques, les tableaux, les images, les objets SmartArt, les objets OLE, et plus encore.

**Puis‑je appliquer des effets à des formes groupées ?**  
Oui, vous pouvez appliquer des effets à des formes groupées. L’effet sera appliqué à l’ensemble du groupe.