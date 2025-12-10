---
title: Appliquer des effets de forme aux présentations en .NET
linktitle: Effet de forme
type: docs
weight: 30
url: /fr/net/shape-effect
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
description: "Transformez vos fichiers PPT et PPTX avec des effets de forme avancés grâce à Aspose.Slides pour .NET — créez des diapositives percutantes et professionnelles en quelques secondes."
---

## **Vue d'ensemble**

Alors que les effets dans PowerPoint peuvent être utilisés pour faire ressortir une forme, ils diffèrent des [remplissages](/slides/fr/net/shape-formatting/#gradient-fill) ou des contours. En utilisant les effets PowerPoint, vous pouvez créer des reflets convaincants sur une forme, diffuser l'éclat d'une forme, etc.

<img src="shape-effect.png" alt="effet-forme" style="zoom:50%;" />

PowerPoint propose six effets qui peuvent être appliqués aux formes. Vous pouvez appliquer un ou plusieurs effets à une forme.

Certaines combinaisons d'effets sont plus esthétiques que d'autres. Pour cette raison, PowerPoint propose des options sous **Préréglage**. Les options de Préréglage sont essentiellement une combinaison reconnue comme esthétique de deux effets ou plus. Ainsi, en sélectionnant un préréglage, vous n'aurez pas à perdre du temps à tester ou combiner différents effets pour trouver une bonne combinaison.

Aspose.Slides fournit des propriétés et des méthodes sous la classe [EffectFormat](https://reference.aspose.com/slides/net/aspose.slides/effectformat/) qui vous permettent d'appliquer les mêmes effets aux formes dans les présentations PowerPoint.

## **Appliquer un effet d'ombre**

Pour appliquer un effet d'ombre à une forme dans Aspose.Slides pour .NET, vous pouvez facilement ajuster des paramètres tels que la couleur, le rayon de flou et la direction. Cela donne à vos formes une apparence plus dynamique et professionnelle, ajoutant de la profondeur et du focus. En utilisant des extraits de code simples, vous pouvez appliquer ces effets à plusieurs formes, améliorant l'attrait visuel global de vos présentations.

Ce code C# montre comment appliquer l'[effet d'ombre externe](https://reference.aspose.com/slides/net/aspose.slides/effectformat/outershadoweffect/) à un rectangle:
```c#
using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);

shape.EffectFormat.EnableOuterShadowEffect();
shape.EffectFormat.OuterShadowEffect.ShadowColor.Color = Color.DarkGray;
shape.EffectFormat.OuterShadowEffect.Distance = 10;
shape.EffectFormat.OuterShadowEffect.Direction = 45;

presentation.Save("shadow_effect.pptx", SaveFormat.Pptx);
```


![Effet d'ombre](shadow_effect.png)

## **Appliquer un effet de réflexion**

Pour appliquer un effet de réflexion dans Aspose.Slides pour .NET, vous pouvez ajouter un reflet semblable à un miroir aux formes, en ajustant des paramètres tels que la distance, la transparence et la taille. Cet effet améliore l'esthétique de vos présentations en donnant aux formes un aspect plus poli et sophistiqué. Il est facile à mettre en œuvre avec un code simple, permettant une application rapide à plusieurs éléments pour un design cohérent.

Ce code C# montre comment appliquer l'[effet de réflexion](https://reference.aspose.com/slides/net/aspose.slides/effectformat/reflectioneffect/) à une forme:
```c#
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

Pour appliquer un effet de lueur à une forme dans Aspose.Slides pour .NET, vous pouvez ajouter une aura douce et lumineuse autour des formes, en ajustant des propriétés comme la couleur et la taille. Cet effet aide les formes à se démarquer et ajoute un élément visuel attrayant à votre présentation. Il est facile à mettre en œuvre avec un minimum de code, améliorant l'aspect général de vos diapositives.

Ce code C# montre comment appliquer l'[effet de lueur](https://reference.aspose.com/slides/net/aspose.slides/effectformat/gloweffect/) à une forme:
```c#
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

Pour appliquer un effet de bords doux dans Aspose.Slides pour .NET, vous pouvez créer une transition lisse et floue autour des bords d'une forme. Cet effet ajoute un aspect plus subtil et raffiné, parfait pour les conceptions qui nécessitent une apparence plus douce. Vous pouvez facilement ajuster des paramètres comme le rayon pour obtenir l'effet souhaité sur diverses formes de votre présentation.

Ce code C# montre comment appliquer les [bords doux](https://reference.aspose.com/slides/net/aspose.slides/effectformat/softedgeeffect/) à une forme:
```c#
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

Oui, vous pouvez combiner différents effets, tels que l'ombre, la réflexion et la lueur, sur une même forme pour créer une apparence plus dynamique.

**À quelles formes puis‑je appliquer des effets ?**

Vous pouvez appliquer des effets à diverses formes, y compris les formes automatiques, les graphiques, les tableaux, les images, les objets SmartArt, les objets OLE, etc.

**Puis‑je appliquer des effets aux formes groupées ?**

Oui, vous pouvez appliquer des effets aux formes groupées. L'effet sera appliqué à l'ensemble du groupe.