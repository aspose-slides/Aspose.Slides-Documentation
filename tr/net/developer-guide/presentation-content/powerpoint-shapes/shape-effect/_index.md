---
title: .NET'te Sunumlarda Şekil Efektlerini Uygula
linktitle: Şekil Efekti
type: docs
weight: 30
url: /tr/net/shape-effect/
keywords:
- şekil efekti
- gölge efekti
- yansıma efekti
- parlama efekti
- yumuşak kenarlar efekti
- efekt formatı
- PowerPoint
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET kullanarak gelişmiş şekil efektleriyle PPT ve PPTX dosyalarınızı dönüştürün—saniyeler içinde çarpıcı, profesyonel slaytlar oluşturun."
---
## **Giriş**

PowerPoint'taki efektler bir şeklin öne çıkmasını sağlamak için kullanılabilirken, [dolgu](/slides/tr/net/shape-formatting/#gradient-fill) veya konturlardan farklıdır. PowerPoint efektlerini kullanarak bir şekil üzerinde ikna edici yansımalar oluşturabilir, şeklin parlaklığını yayabilirsiniz, vb.

![Shape effect](shape-effect.png)

PowerPoint, şekillere uygulanabilen altı efekt sunar. Bir şekle bir veya daha fazla efekt uygulayabilirsiniz.

Bazı efekt kombinasyonları diğerlerinden daha iyi görünür. Bu nedenle, PowerPoint **Preset** altında seçenekler sunar. Preset seçenekleri, iki veya daha fazla efekti içeren, iyi görünümlü bilinen bir kombinasyondur. Böylece bir preset seçerek, farklı efektleri denemek ya da birleştirmek için zaman harcamadan güzel bir kombinasyon bulabilirsiniz.

Aspose.Slides, PowerPoint sunumlarındaki şekillere aynı efektleri uygulamanızı sağlayan [EffectFormat](https://reference.aspose.com/slides/net/aspose.slides/effectformat/) sınıfı altında özellikler ve metodlar sunar.

## **Gölge Efekti Uygula**

Aspose.Slides for .NET, şekiller için dış ve iç gölgeleri destekler. Renklerini, yönlerini, mesafesini ve bulanıklaştırma yarıçapını sunumunuzun tasarımıyla eşleşecek şekilde özelleştirebilirsiniz.

### **Dış Gölge Uygula**

Bir kartın veya panelin slayt arka planına karşı öne çıkmasını sağlamak için dış gölge kullanın. Gölge, şeklin kenarlarının ötesine uzanarak şeklin slayt üzerinde yükselmiş izlenimini verir. Renk, yön, mesafe ve bulanıklaştırma yarıçapını şablonunuzun aydınlatması ve stiline göre ayarlayın.

Bu C# kodu, bir dikdörtgene [dış gölge efekti](https://reference.aspose.com/slides/net/aspose.slides/effectformat/outershadoweffect/) nasıl uygulanacağını gösterir:

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

![Gölge efekti](shadow_effect.png)

### **İç Gölge Uygula**

Bir şablonun görsel stilini yeniden üretirken, kart veya panelin geri çekilmiş bir görünüm kazanması için iç gölge kullanın. Dış gölge şeklin dışına uzanarak yükselmiş görünürken, iç gölge kenarların iç kısmını gölgelendirir.

İlk olarak [EnableInnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/enableinnershadoweffect/) çağırın, ardından [InnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/innershadoweffect/) yapılandırın. Daha büyük değerler daha yumuşak kenarlar üretir.

Bu C# örneği, açık mavi bir kartı koyu gri bir iç gölge ile oluşturur ve PPTX dosyası olarak kaydeder:

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

![İç gölgeli açık mavi dikdörtgen](inner_shadow_effect.png)

İç gölgeyi kaldırmak için şeklin effect formatı üzerinde [DisableInnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/disableinnershadoweffect/) metodunu çağırın.

## **Yansıma Efekti Uygula**

Aspose.Slides for .NET'te bir yansıma efekti uygulamak için şekillere ayna benzeri bir yansıma ekleyebilir, mesafe, şeffaflık ve boyut gibi parametreleri ayarlayabilirsiniz. Bu efekt, şekillere daha cilalı ve karmaşık bir görünüm kazandırarak sunumlarınızın estetiğini artırır. Basit kodla kolayca uygulanabilir ve tutarlı bir tasarım için birden çok öğeye hızlıca uygulanabilir.

Bu C# kodu, bir şekle [yansıma efekti](https://reference.aspose.com/slides/net/aspose.slides/effectformat/reflectioneffect/) nasıl uygulanacağını gösterir:

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

![Yansıma efekti](reflection_effect.png)

## **Parlama Efekti Uygula**

Aspose.Slides for .NET'te bir şekle parlama efekti uygulamak için şekillerin etrafına yumuşak, ışıklı bir aura ekleyebilir, renk ve boyut gibi özellikleri ayarlayabilirsiniz. Bu efekt, şekilleri öne çıkarmaya yardımcı olur ve sunumunuza çekici, göz alıcı bir görsel öğe katar. Minimum kodla kolayca uygulanabilir ve slaytlarınızın genel görünümünü iyileştirir.

Bu C# kodu, bir şekle [parlama efekti](https://reference.aspose.com/slides/net/aspose.slides/effectformat/gloweffect/) nasıl uygulanacağını gösterir:

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

![Parlama efekti](glow_effect.png)

## **Yumuşak Kenarlar Efekti Uygula**

Aspose.Slides for .NET'te yumuşak kenarlar efekti uygulamak için bir şeklin kenarlarında sorunsuz, bulanık bir geçiş oluşturabilirsiniz. Bu efekt, nazik, daha yumuşak bir görünüm gerektiren tasarımlar için mükemmel, daha ince ve zarif bir görünüm kazandırır. Sunumunuzdaki çeşitli şekillerde istenen etkiyi elde etmek için yarıçap gibi parametreleri kolayca ayarlayabilirsiniz.

Bu C# kodu, bir şekle [yumuşak kenarlar](https://reference.aspose.com/slides/net/aspose.slides/effectformat/softedgeeffect/) nasıl uygulanacağını gösterir:

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

![Yumuşak kenarlar efekti](soft_edges_effect.png)

## **SSS**

**Aynı şekle birden fazla efekt uygulayabilir miyim?**

Evet, gölge, yansıma ve parlama gibi farklı efektleri tek bir şekle uygulayarak daha dinamik bir görünüm elde edebilirsiniz.

**Hangi şekillere efekt uygulayabilirim?**

Otomatik şekiller, grafikler, tablolar, resimler, SmartArt nesneleri, OLE nesneleri ve daha fazlası dahil olmak üzere çeşitli şekillere efekt uygulayabilirsiniz.

**Gruplanmış şekillere efekt uygulayabilir miyim?**

Evet, gruplandırılmış şekillere efekt uygulayabilirsiniz. Efekt tüm gruba uygulanır.