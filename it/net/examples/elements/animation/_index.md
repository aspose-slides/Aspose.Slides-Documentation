---
title: Animazione
type: docs
weight: 100
url: /it/net/examples/elements/animation/
keywords:
- animazione
- aggiungi animazione
- accedi animazione
- rimuovi animazione
- sequenza animazione
- esempio di codice
- PowerPoint
- OpenDocument
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Esplora esempi di animazione di Aspose.Slides per .NET: aggiungi, sequenza e personalizza effetti e transizioni con C# per presentazioni PPT, PPTX e ODP."
---
Questo articolo dimostra come creare animazioni semplici e gestire la loro sequenza usando **Aspose.Slides for .NET**.

## **Aggiungere un'animazione**

Crea una forma rettangolare e applica un effetto di dissolvenza attivato al clic.

```csharp
static void AddAnimation()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);

    // Effetto di dissolvenza.
    slide.Timeline.MainSequence.AddEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
}
```

## **Accedere a un'animazione**

Recupera il primo effetto di animazione dalla timeline della diapositiva.

```csharp
static void AccessAnimation()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);
    slide.Timeline.MainSequence.AddEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // Accedi al primo effetto di animazione.
    var effect = slide.Timeline.MainSequence[0];
}
```

## **Rimuovere un'animazione**

Rimuovi un effetto di animazione dalla sequenza.

```csharp
static void RemoveAnimation()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);
    var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // Rimuovi l'effetto.
    slide.Timeline.MainSequence.Remove(effect);
}
```

## **Sequenziare le animazioni**

Aggiungi più effetti e dimostra l'ordine in cui si verificano le animazioni.

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