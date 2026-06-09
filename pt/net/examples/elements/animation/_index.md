---
title: Animação
type: docs
weight: 100
url: /pt/net/examples/elements/animation/
keywords:
- animação
- adicionar animação
- acessar animação
- remover animação
- sequência de animação
- exemplo de código
- PowerPoint
- OpenDocument
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Explore exemplos de animação do Aspose.Slides for .NET: adicionar, sequenciar e personalizar efeitos e transições com C# para apresentações PPT, PPTX e ODP."
---
Este artigo demonstra como criar animações simples e gerenciar sua sequência usando **Aspose.Slides for .NET**.

## **Adicionar uma Animação**

Crie uma forma retangular e aplique um efeito de desvanecimento acionado ao clicar.

```csharp
static void AddAnimation()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);

    // Efeito de desvanecimento.
    slide.Timeline.MainSequence.AddEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
}
```

## **Acessar uma Animação**

Recupere o primeiro efeito de animação da linha do tempo do slide.

```csharp
static void AccessAnimation()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);
    slide.Timeline.MainSequence.AddEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // Acessar o primeiro efeito de animação.
    var effect = slide.Timeline.MainSequence[0];
}
```

## **Remover uma Animação**

Remova um efeito de animação da sequência.

```csharp
static void RemoveAnimation()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);
    var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // Remover o efeito.
    slide.Timeline.MainSequence.Remove(effect);
}
```

## **Sequenciar Animações**

Adicione múltiplos efeitos e demonstre a ordem em que as animações ocorrem.

```csharp
static void SequenceAnimations()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);
    var shape2 = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 200, 50, 100, 100);

    var sequence = slide.Timeline.MainSequence;
    sequence.AddEffect(shape1, EffectType.Fly, EffectSubtype.Bottom, EffectTriggerType.OnClick);
    sequence.AddEffect(shape2, EffectType.Fly, EffectSubtype.Bottom, EffectTriggerType.OnClick);
}
```