---
title: Animasyon
type: docs
weight: 100
url: /tr/net/examples/elements/animation/
keywords:
- animasyon
- animasyon ekle
- animasyona eriş
- animasyon kaldır
- animasyon sırası
- kod örneği
- PowerPoint
- OpenDocument
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET animasyon örneklerini keşfedin: C# ile PPT, PPTX ve ODP sunumları için efektleri ve geçişleri ekleyin, sıralayın ve özelleştirin."
---
Bu makale, **Aspose.Slides for .NET** kullanarak basit animasyonlar oluşturmayı ve bunların sırasını yönetmeyi gösterir.

## **Animasyon Ekle**

Bir dikdörtgen şekli oluşturun ve tıklamayla tetiklenen bir solma efekti uygulayın.

```csharp
static void AddAnimation()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);

    // Solma efekti.
    slide.Timeline.MainSequence.AddEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
}
```

## **Animasyona Eriş**

Slayt zaman çizelgesinden ilk animasyon efektini alın.

```csharp
static void AccessAnimation()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);
    slide.Timeline.MainSequence.AddEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // İlk animasyon efektine eriş.
    var effect = slide.Timeline.MainSequence[0];
}
```

## **Animasyonu Kaldır**

Bir animasyon efektini sıralamadan kaldırın.

```csharp
static void RemoveAnimation()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);
    var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // Etkiyi kaldır.
    slide.Timeline.MainSequence.Remove(effect);
}
```

## **Animasyonları Sıralama**

Birden fazla efekt ekleyin ve animasyonların gerçekleşme sırasını gösterin.

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