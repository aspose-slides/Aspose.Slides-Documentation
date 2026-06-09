---
title: Animasyon
type: docs
weight: 100
url: /tr/python-net/examples/elements/animation/
keywords:
- animasyon
- animasyon ekle
- animasyona eriş
- animasyonu kaldır
- animasyon sırası
- kod örnekleri
- PowerPoint
- OpenDocument
- sunum
- Python
- Aspose.Slides
description: "Python ile Aspose.Slides üzerinde slayt animasyonlarını ustalaşın: dinamik sunumlar oluşturmak için efektleri, zamanlamaları ve tetikleyicileri ekleyin, düzenleyin ve kaldırın; PPT, PPTX ve ODP formatlarında."
---
Basit animasyonlar oluşturmayı ve sırasını **Aspose.Slides for Python via .NET** kullanarak yönetmeyi gösterir.

## **Animasyon Ekle**

Bir dikdörtgen şekil oluşturun ve tıklamayla tetiklenen bir solma efekti uygulayın.

```py
def add_animation():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]
        shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 100, 100)

        # Bir solma efekti ekle.
        slide.timeline.main_sequence.add_effect(
            shape,
            slides.animation.EffectType.FADE,
            slides.animation.EffectSubtype.NONE,
            slides.animation.EffectTriggerType.ON_CLICK)

        presentation.save("animation.pptx", slides.export.SaveFormat.PPTX)
```

## **Animasyona Eriş**

Slayt zaman çizelgesinden ilk animasyon efektini alın.

```py
def access_animation():
    with slides.Presentation("animation.pptx") as presentation:
        slide = presentation.slides[0]

        # İlk animasyon etkisine eriş.
        effect = slide.timeline.main_sequence[0]
```

## **Animasyonu Kaldır**

Sıradan bir animasyon efektini kaldırın.

```py
def remove_animation():
    with slides.Presentation("animation.pptx") as presentation:
        slide = presentation.slides[0]

        # Ana sıranın en az bir etki içerdiğini varsayarak.
        effect = slide.timeline.main_sequence[0]

        # Etkiyi kaldır.
        slide.timeline.main_sequence.remove(effect)

        presentation.save("animation_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Animasyonları Sıralama**

Birden fazla efekt ekleyin ve animasyonların gerçekleşme sırasını gösterin.

```py
def sequence_animations():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]
        shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 100, 100)
        shape2 = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 200, 50, 100, 100)

        sequence = slide.timeline.main_sequence
        sequence.add_effect(
            shape1,
            slides.animation.EffectType.FLY,
            slides.animation.EffectSubtype.BOTTOM,
            slides.animation.EffectTriggerType.ON_CLICK)
        sequence.add_effect(
            shape2,
            slides.animation.EffectType.FLY,
            slides.animation.EffectSubtype.BOTTOM,
            slides.animation.EffectTriggerType.ON_CLICK)

        presentation.save("animation_sequence.pptx", slides.export.SaveFormat.PPTX)
```