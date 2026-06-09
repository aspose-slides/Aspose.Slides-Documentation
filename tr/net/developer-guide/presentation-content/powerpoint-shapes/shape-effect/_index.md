---
title: Sunumlarda Şekil Efektlerini .NET'te Uygula
linktitle: Şekil Efekti
type: docs
weight: 30
url: /tr/net/shape-effect
keywords:
- şekil efekti
- gölge efekti
- yansıma efekti
- parıltı efekti
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

PowerPoint'teki efektler bir şekli öne çıkarmak için kullanılabilir, ancak [dolgu](/slides/tr/net/shape-formatting/#gradient-fill) veya kenarlıklardan farklıdır. PowerPoint efektlerini kullanarak bir şeklin üzerinde ikna edici yansımalar oluşturabilir, şeklin parlaklığını yayabilir vb. işlemler yapabilirsiniz.

<img src="shape-effect.png" alt="shape-effect" style="zoom:50%;" />

PowerPoint, şekillere uygulanabilen altı efekt sunar. Bir şekle bir veya daha fazla efekt uygulayabilirsiniz.

Bazı efekt kombinasyonları diğerlerinden daha iyi görünür. Bu nedenle PowerPoint, **Preset** altında seçenekler sunar. Preset seçenekleri, iki veya daha fazla efektin bilinen, iyi görünen bir kombinasyonudur. Böylece bir preset seçerek farklı efektleri denemek veya birleştirmek için zaman kaybetmezsiniz.

Aspose.Slides, PowerPoint sunumlarındaki şekillere aynı efektleri uygulamanıza olanak tanıyan [EffectFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/effectformat/) sınıfı altında özellikler ve yöntemler sağlar.

## **Gölge Efekti Uygulama**

Aspose.Slides for .NET'te bir şekle gölge efekti uygulamak için renk, bulanıklık yarıçapı ve yön gibi parametreleri kolayca ayarlayabilirsiniz. Bu, şekillerinize daha dinamik ve profesyonel bir görünüm kazandırarak derinlik ve odak ekler. Basit kod parçacıklarıyla bu efektleri birden fazla şekle uygulayarak sunumlarınızın genel görsel çekiciliğini artırabilirsiniz.

Bu C# kodu, bir dikdörtgene [dış gölge efekti](https://reference.aspose.com/slides/tr/net/aspose.slides/effectformat/outershadoweffect/) nasıl uygulanacağını gösterir:

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

![Shadow effect](shadow_effect.png)

## **Yansıma Efekti Uygulama**

Aspose.Slides for .NET'te bir şekle yansıma efekti uygulamak için şekillere ayna benzeri bir yansıma ekleyebilir, mesafe, şeffaflık ve boyut gibi parametreleri ayarlayabilirsiniz. Bu efekt, şekillere daha cilalı ve sofistike bir görünüm kazandırarak sunumlarınızın estetiğini artırır. Basit kodla kolayca uygulanabilir ve birden fazla öğeye hızlıca uygulanarak tutarlı bir tasarım sağlar.

Bu C# kodu, bir şekle [yansıma efekti](https://reference.aspose.com/slides/tr/net/aspose.slides/effectformat/reflectioneffect/) nasıl uygulanacağını gösterir:

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

![Reflection effect](reflection_effect.png)

## **Parıltı Efekti Uygulama**

Aspose.Slides for .NET'te bir şekle parıltı efekti uygulamak için şekillerin etrafına yumuşak, ışıklı bir aura ekleyebilir, renk ve boyut gibi özellikleri ayarlayabilirsiniz. Bu efekt, şekillerin öne çıkmasını sağlar ve sunumunuza çekici bir görsel öğe ekler. Minimum kodla kolayca uygulanır ve slaytlarınızın genel görünümünü iyileştirir.

Bu C# kodu, bir şekle [parıltı efekti](https://reference.aspose.com/slides/tr/net/aspose.slides/effectformat/gloweffect/) nasıl uygulanacağını gösterir:

```c#
using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);

shape.EffectFormat.EnableGlowEffect();
shape.EffectFormat.GlowEffect.Color.Color = Color.Magenta;
shape.EffectFormat.GlowEffect.Radius = 15;

presentation.Save("glow_effect.pptx", SaveFormat.Pptx);
```

![Glow effect](glow_effect.png)

## **Yumuşak Kenarlar Efekti Uygulama**

Aspose.Slides for .NET'te bir şekle yumuşak kenarlar efekti uygulamak için şeklin kenarları etrafında pürüzsüz, bulanık bir geçiş oluşturabilirsiniz. Bu efekt, daha ince ve zarif bir görünüm ekler; özellikle nazik ve yumuşak bir tasarım gerektiğinde idealdir. Yarıçap gibi parametreleri kolayca ayarlayarak sunumunuzdaki çeşitli şekillerde istediğiniz etkiyi elde edebilirsiniz.

Bu C# kodu, bir şekle [yumuşak kenarlar](https://reference.aspose.com/slides/tr/net/aspose.slides/effectformat/softedgeeffect/) nasıl uygulanacağını gösterir:

```c#
using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150);

shape.EffectFormat.EnableSoftEdgeEffect();
shape.EffectFormat.SoftEdgeEffect.Radius = 8;

presentation.Save("soft_edges_effect.pptx", SaveFormat.Pptx);
```

![Soft edges effect](soft_edges_effect.png)

## **SSS**

**Aynı şekle birden fazla efekt uygulayabilir miyim?**

Evet, bir şekle gölge, yansıma ve parıltı gibi farklı efektleri birleştirerek daha dinamik bir görünüm oluşturabilirsiniz.

**Hangi şekillere efekt uygulayabilirim?**

Otomatik şekiller, grafikler, tablolar, resimler, SmartArt nesneleri, OLE nesneleri ve daha fazlası dahil olmak üzere çeşitli şekillere efekt uygulayabilirsiniz.

**Gruplandırılmış şekillere efekt uygulayabilir miyim?**

Evet, gruplandırılmış şekillere efekt uygulayabilirsiniz. Efekt tüm grup üzerine uygulanır.