---
title: Python ile Sunumlarda Şekil Efektlerini Uygula
linktitle: Şekil Efekti
type: docs
weight: 30
url: /tr/python-net/shape-effect
keywords:
- şekil efekti
- gölge efekti
- yansıtma efekti
- parlama efekti
- yumuşak kenarlar efekti
- efekt formatı
- PowerPoint
- OpenDocument
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python kullanarak gelişmiş şekil efektleri ile PPT, PPTX ve ODP dosyalarınızı dönüştürün—saniyeler içinde çarpıcı, profesyonel slaytlar oluşturun."
---
## **Giriş**

PowerPoint'teki efektler bir şekli öne çıkarmak için kullanılabilir, ancak [doldurmalar](/slides/tr/python-net/shape-formatting/#gradient-fill) veya konturlardan farklıdır. PowerPoint efektlerini kullanarak bir şeklin yansımasını oluşturabilir, şeklin parıltısını yayabilir vb. şeyler yapabilirsiniz.

<img src="shape-effect.png" alt="shape-effect" style="zoom:50%;" />

* PowerPoint, şekillere uygulanabilen altı efekt sağlar. Bir şekle bir veya daha fazla efekt uygulayabilirsiniz.  

* Bazı efekt kombinasyonları diğerlerinden daha iyi görünür. Bu nedenle PowerPoint **Preset** altında seçenekler sunar. Preset seçenekleri, iki veya daha fazla etkinin bilinen güzel bir kombinasyonudur. Böylece bir preset seçerek farklı efektleri deneme veya birleştirme zahmetine girmeden hoş bir kombinasyon elde edersiniz.

Aspose.Slides, PowerPoint sunumlarındaki şekillere aynı efektleri uygulamanızı sağlayan [EffectFormat](https://reference.aspose.com/slides/tr/python-net/aspose.slides/effectformat/) sınıfı altında özellikler ve yöntemler sunar.

## **Gölge Efekti Uygulama**

Bu Python kodu, dış gölge efekti (`outer_shadow_effect`) bir dikdörtgene nasıl uygulanacağını gösterir:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 150)

    shape.effect_format.enable_outer_shadow_effect()
    shape.effect_format.outer_shadow_effect.shadow_color.color = draw.Color.dark_gray
    shape.effect_format.outer_shadow_effect.distance = 10
    shape.effect_format.outer_shadow_effect.direction = 45

    pres.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Yansıtma Efekti Uygulama**

Bu Python kodu, bir şekle yansıtma efektinin nasıl uygulanacağını gösterir:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 150)

    shape.effect_format.enable_reflection_effect()
    shape.effect_format.reflection_effect.rectangle_align = slides.RectangleAlignment.BOTTOM
    shape.effect_format.reflection_effect.direction = 90
    shape.effect_format.reflection_effect.distance = 55
    shape.effect_format.reflection_effect.blur_radius = 4

    pres.save("reflection.pptx", slides.export.SaveFormat.PPTX)
```

## **Parlama Efekti Uygulama**

Bu Python kodu, bir şekle parlama efektinin nasıl uygulanacağını gösterir:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 150)

    shape.effect_format.enable_glow_effect()
    shape.effect_format.glow_effect.color.color = draw.Color.magenta
    shape.effect_format.glow_effect.radius = 15

    pres.save("glow.pptx", slides.export.SaveFormat.PPTX)
```

## **Yumuşak Kenarlar Efekti Uygulama**

Bu Python kodu, bir şekle yumuşak kenarlar efektinin nasıl uygulanacağını gösterir:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 150)

    shape.effect_format.enable_soft_edge_effect()
    shape.effect_format.soft_edge_effect.radius = 15

    pres.save("softEdges.pptx", slides.export.SaveFormat.PPTX)
```

## **SSS**

**Aynı şekle birden fazla efekt uygulayabilir miyim?**

Evet, bir şekle gölge, yansıtma ve parlama gibi farklı efektleri birleştirerek daha dinamik bir görünüm elde edebilirsiniz.

**Hangi şekillere efekt uygulayabilirim?**

Otomatik şekiller, grafikler, tablolar, resimler, SmartArt nesneleri, OLE nesneleri ve daha fazlası dahil olmak üzere çeşitli şekillere efekt uygulayabilirsiniz.

**Gruplandırılmış şekillere efekt uygulayabilir miyim?**

Evet, grup içindeki tüm şekillere aynı anda efekt uygulanır.