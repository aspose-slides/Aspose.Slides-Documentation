---
title: Slayt Geçişi
type: docs
weight: 110
url: /tr/net/examples/elements/slide-transition/
keywords:
- slayt geçişi
- slayt geçişi ekle
- slayt geçişine eriş
- slayt geçişini kaldır
- geçiş süresi
- kod örneği
- PowerPoint
- OpenDocument
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET'te slayt geçişlerini ustalaştırın: PPT, PPTX ve ODP sunumları için C# örnekleriyle efektleri ve süreleri ekleyin, özelleştirin ve sıralayın."
---
Bu makale, **Aspose.Slides for .NET** ile slayt geçişi efektleri ve zamanlamalarının uygulanmasını gösterir.

## **Slayt Geçişi Ekle**

İlk slayta bir solma geçiş efekti uygulayın.

```csharp
static void AddSlideTransition()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Bir solma geçişi uygula.
    slide.SlideShowTransition.Type = TransitionType.Fade;
}
```

## **Slayt Geçişine Erişim**

Bir slayta şu anda atanmış geçiş türünü okuyun.

```csharp
static void AccessSlideTransition()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.SlideShowTransition.Type = TransitionType.Push;

    // Geçiş türüne eriş.
    var type = slide.SlideShowTransition.Type;
}
```

## **Slayt Geçişini Kaldır**

Geçiş türünü `None` olarak ayarlayarak tüm geçiş efektlerini temizleyin.

```csharp
static void RemoveSlideTransition()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.SlideShowTransition.Type = TransitionType.Fade;

    // Geçişi kaldırmak için None ayarlayın.
    slide.SlideShowTransition.Type = TransitionType.None;
}
```

## **Geçiş Süresini Ayarlama**

Slaytın otomatik olarak ilerlemeden önce ne kadar süre gösterileceğini belirleyin.

```csharp
static void SetTransitionDuration()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.SlideShowTransition.AdvanceOnClick = true;
    slide.SlideShowTransition.AdvanceAfterTime = 2000; // milisaniye cinsinden
}
```