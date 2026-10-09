---
title: Python ile Sunumlarda Şekil Efektleri Uygulama
linktitle: Şekil Efekti
type: docs
weight: 30
url: /tr/python-net/shape-effect
keywords:
- şekil efekti
- gölge efekti
- yansıma efekti
- parıltı efekti
- yumuşak kenar efekti
- efekt formatı
- PowerPoint
- OpenDocument
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python kullanarak gelişmiş şekil efektleriyle PPT, PPTX ve ODP dosyalarınızı dönüştürün—saniyeler içinde çarpıcı, profesyonel slaytlar oluşturun."
---
## **Giriş**

PowerPoint'teki efektler bir şekli ön plana çıkarmak için kullanılabilirken, bunlar [dolgu](/slides/tr/python-net/shape-formatting/#gradient-fill) veya kenarlıklardan farklıdır. PowerPoint efektlerini kullanarak bir şekil üzerinde ikna edici yansımalar oluşturabilir, şeklin parıltısını yayabilirsiniz, vb.

![Şekil efekti](shape-effect.png)

PowerPoint, şekillere uygulanabilen altı efekt sağlar. Bir şekle bir veya daha fazla efekt uygulayabilirsiniz.

Bazı efekt kombinasyonları diğerlerinden daha iyi görünür. Bu nedenle, PowerPoint **Preset** altında seçenekler sunar. Preset seçenekleri esasen iki veya daha fazla efektin iyi gözüken bir kombinasyonudur. Böylece bir preset seçerek, farklı efektleri test etmek veya birleştirmek için zaman harcamadan güzel bir kombinasyon bulabilirsiniz.

Aspose.Slides, PowerPoint sunumlarındaki şekillere aynı efektleri uygulamanıza olanak tanıyan [EffectFormat](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/) sınıfı altında özellikler ve yöntemler sunar.

## **Gölge Efekti Uygulama**

Aspose.Slides for Python via .NET, şekiller için dış ve iç gölgeleri destekler. Renk, yön, mesafe ve bulanıklık yarıçapını sunum tasarımınıza uygun şekilde özelleştirebilirsiniz.

### **Dış Gölge Uygula**

Bir dış gölge, kartın veya panelin slayt arka planına karşı öne çıkmasını sağlar. Gölge, şeklin kenarlarının ötesine uzanarak şeklin slayt üzerinde yükselmiş izlenimini verir. Renk, yön, mesafe ve bulanıklık yarıçapını şablonunuzun ışıklandırması ve stiline uygun şekilde ayarlayın.

Bu Python kodu, bir dikdörtgene [dış gölge efekti](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/outer_shadow_effect/) uygulamayı gösterir:
```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 100)
    shape.effect_format.enable_outer_shadow_effect()
    shape.effect_format.outer_shadow_effect.shadow_color.color = draw.Color.dark_gray
    shape.effect_format.outer_shadow_effect.distance = 10
    shape.effect_format.outer_shadow_effect.direction = 45

    presentation.save("shadow_effect.pptx", slides.export.SaveFormat.PPTX)
```

![Gölge efekti](shadow_effect.png)

### **İç Gölge Uygula**

Bir şablonun görsel stilini yeniden oluştururken, kart veya panele gömülü bir görünüm vermek için iç gölge kullanın. Dış gölge, şeklin dışına uzanarak yükselmiş gibi görünmesini sağlarken, iç gölge kenarların içini gölgeler.

İlk olarak [enable_inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/enable_inner_shadow_effect/) metodunu çağırın, ardından [inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/inner_shadow_effect/) özelliğini yapılandırın. Daha büyük blur-yarıçapı değerleri daha yumuşak kenarlar üretir.

Bu Python örneği, koyu gri bir iç gölgeye sahip açık mavi bir kart oluşturur ve PPTX dosyası olarak kaydeder:
```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 200, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.light_blue
    shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL

    shape.effect_format.enable_inner_shadow_effect()
    shadow = shape.effect_format.inner_shadow_effect
    shadow.shadow_color.color = draw.Color.dim_gray
    shadow.direction = 225
    shadow.distance = 7
    shadow.blur_radius = 6

    presentation.save("inner_shadow_effect.pptx", slides.export.SaveFormat.PPTX)
```

![İç gölgelikli açık mavi dikdörtgen](inner_shadow_effect.png)

İç gölgeyi kaldırmak için, şeklin effect formatı üzerinde [disable_inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/disable_inner_shadow_effect/) metodunu çağırın.

## **Yansıma Efekti Uygulama**

Aspose.Slides for Python via .NET içinde yansıma efekti uygulamak için, şekillere ayna gibi bir yansıma ekleyebilir, mesafe, şeffaflık ve boyut gibi parametreleri ayarlayabilirsiniz. Bu efekt, şekillere daha cilalı ve sofistike bir görünüm kazandırarak sunumlarınızın estetiğini artırır. Basit kodla kolayca uygulanabilir, tutarlı bir tasarım için birden çok öğeye hızlıca uygulanmasını sağlar.

Bu Python kodu, bir şekle [yansıma efekti](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/reflection_effect/) uygulamayı gösterir:
```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 100)
    shape.effect_format.enable_reflection_effect()
    shape.effect_format.reflection_effect.rectangle_align = slides.RectangleAlignment.BOTTOM
    shape.effect_format.reflection_effect.direction = 90
    shape.effect_format.reflection_effect.distance = 40
    shape.effect_format.reflection_effect.blur_radius = 2

    presentation.save("reflection_effect.pptx", slides.export.SaveFormat.PPTX)
```

![Yansıma efekti](reflection_effect.png)

## **Parıltı Efekti Uygulama**

Aspose.Slides for Python via .NET içinde bir şekle parıltı efekti uygulamak için, şeklin etrafına yumuşak, ışıklı bir aura ekleyebilir, renk ve boyut gibi özellikleri ayarlayabilirsiniz. Bu efekt, şekilleri öne çıkarmaya yardımcı olur ve sunumunuza çekici, göz alıcı bir görsel unsur ekler. Minimum kodla kolayca uygulanabilir, slaytlarınızın genel görünümünü geliştirir.

Bu Python kodu, bir şekle [parıltı efekti](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/glow_effect/) uygulamayı gösterir:
```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 100)
    shape.effect_format.enable_glow_effect()
    shape.effect_format.glow_effect.color.color = draw.Color.magenta
    shape.effect_format.glow_effect.radius = 15

    presentation.save("glow_effect.pptx", slides.export.SaveFormat.PPTX)
```

![Parıltı efekti](glow_effect.png)

## **Yumuşak Kenar Efekti Uygulama**

Aspose.Slides for Python via .NET içinde yumuşak kenar efekti uygulamak için, bir şeklin kenarları etrafında pürüzsüz, bulanık bir geçiş oluşturabilirsiniz. Bu efekt, daha nazik ve rafine bir görünüm ekler; yumuşak ve hafif bir görünüm gerektiren tasarımlar için mükemmeldir. Sunumunuzdaki çeşitli şekillerde istenen etkiyi elde etmek için yarıçap gibi parametreleri kolayca ayarlayabilirsiniz.

Bu Python kodu, bir şekle [yumuşak kenarlar](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/soft_edge_effect/) uygulamayı gösterir:
```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 150)
    shape.effect_format.enable_soft_edge_effect()
    shape.effect_format.soft_edge_effect.radius = 8

    presentation.save("soft_edges_effect.pptx", slides.export.SaveFormat.PPTX)
```

![Yumuşak kenarlar efekti](soft_edges_effect.png)

## **SSS**

**Aynı şekle birden fazla efekt uygulayabilir miyim?**

Evet, gölge, yansıma ve parıltı gibi farklı efektleri tek bir şekle birleştirerek daha dinamik bir görünüm oluşturabilirsiniz.

**Hangi şekillere efekt uygulayabilirim?**

Çeşitli şekillere, otomatik şekillere, grafiklere, tablolara, resimlere, SmartArt nesnelerine, OLE nesnelerine ve daha fazlasına efekt uygulayabilirsiniz.

**Gruplanmış şekillere efekt uygulayabilir miyim?**

Evet, gruplandırılmış şekillere efekt uygulayabilirsiniz. Efekt tüm grubuna uygulanır.