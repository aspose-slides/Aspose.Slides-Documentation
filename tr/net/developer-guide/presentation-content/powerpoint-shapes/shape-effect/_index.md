---
title: ".NET'te Sunumlarda Şekil Efektlerini Uygulama"
linktitle: "Şekil Efekti"
type: docs
weight: 30
url: /tr/net/shape-effect/
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
description: "Aspose.Slides for .NET kullanarak gelişmiş şekil efektleriyle PPT ve PPTX dosyalarınızı dönüştürün—saniyeler içinde etkileyici, profesyonel slaytlar oluşturun."
---
## **Giriş**

PowerPoint'teki efektler bir şekli öne çıkarmak için kullanılabilirken, [dolgu](/slides/tr/net/shape-formatting/#gradient-fill) veya konturlardan farklıdır. PowerPoint efektlerini kullanarak bir şekil üzerinde ikna edici yansımalar oluşturabilir, şeklin parıltısını yayabilirsiniz, vb.

![Şekil efekti](shape-effect.png)

PowerPoint, şekillere uygulanabilen altı efekt sağlar. Bir şekle bir veya daha fazla efekt uygulayabilirsiniz.

Bazı efekt kombinasyonları diğerlerinden daha iyi görünür. Bu nedenle PowerPoint, **Preset** altında seçenekler sunar. Preset seçenekleri, temelde iki veya daha fazla efektin iyi bir kombinasyonudur. Böylece bir preset seçerek, güzel bir kombinasyon bulmak için farklı efektleri deneme veya birleştirme süresini harcamazsınız.

Aspose.Slides, PowerPoint sunumlarındaki şekillere aynı efektleri uygulamanızı sağlayan [EffectFormat](https://reference.aspose.com/slides/net/aspose.slides/effectformat/) sınıfı altında özellikler ve yöntemler sunar.

## **Gölge Efekti Uygulama**

Aspose.Slides for .NET, şekiller için dış ve iç gölgeleri destekler. Renk, yön, mesafe ve bulanıklık yarıçapını sunumunuzun tasarımına uyacak şekilde özelleştirebilirsiniz.

### **Dış Gölge Uygulama**

Dış gölge, bir kartın veya panelin slayt arka planına karşı öne çıkmasını sağlar. Gölge, şeklin kenarlarının ötesine uzanır ve şeklin slayt üzerinde yükselmiş izlenimini yaratır. Renk, yön, mesafe ve bulanıklık yarıçapını şablonunuzun aydınlatması ve stiline uyacak şekilde ayarlayın.

Bu C# kodu, bir dikdörtgene [dış gölge efekti](https://reference.aspose.com/slides/net/aspose.slides/effectformat/outershadoweffect/) uygulamayı gösterir:

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

### **İç Gölge Uygulama**

Bir şablonun görsel stilini yeniden oluştururken, bir kartın veya panelin gömülü bir görünüm kazanması için iç gölge kullanın. Dış gölge, şeklin dışına uzanarak yükselmiş görünürken, iç gölge kenarların içini karartır.

[EnableInnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/enableinnershadoweffect/) çağırın, ardından [InnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/innershadoweffect/) yapılandırın. Daha büyük değerler daha yumuşak kenarlar üretir.

Bu C# örneği, açık mavi bir kart oluşturur, koyu gri bir iç gölge ekler ve PPTX dosyası olarak kaydeder:

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

![İç gölge ile açık mavi dikdörtgen](inner_shadow_effect.png)

İç gölgeyi kaldırmak için şeklin efekt formatında [DisableInnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/disableinnershadoweffect/) çağırın.

## **Yansıma Efekti Uygulama**

Aspose.Slides for .NET'te yansıma efekti uygulamak için şekillere aynalı bir yansıma ekleyebilir, mesafe, şeffaflık ve boyut gibi parametreleri ayarlayabilirsiniz. Bu efekt, şekillere daha cilalı ve sofistike bir görünüm kazandırarak sunumunuzun estetiğini artırır. Basit kodla kolayca uygulanabilir ve tutarlı bir tasarım için birden çok öğeye hızlıca uygulanabilir.

Bu C# kodu, bir şekle [yansıma efekti](https://reference.aspose.com/slides/net/aspose.slides/effectformat/reflectioneffect/) uygulamayı gösterir:

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

## **Parıltı Efekti Uygulama**

Aspose.Slides for .NET'te bir şekle parıltı efekti uygulamak için şekillerin etrafına yumuşak, ışıklı bir aura ekleyebilir, renk ve boyut gibi özellikleri ayarlayabilirsiniz. Bu efekt, şekilleri ön plana çıkarır ve sunumunuza çekici, göz alıcı bir görsel öğe ekler. Minimum kodla uygulanabilir ve slaytlarınızın genel görünümünü iyileştirir.

Bu C# kodu, bir şekle [parıltı efekti](https://reference.aspose.com/slides/net/aspose.slides/effectformat/gloweffect/) uygulamayı gösterir:

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

![Parıltı efekti](glow_effect.png)

## **Yumuşak Kenarlar Efekti Uygulama**

Aspose.Slides for .NET'te yumuşak kenarlar efekti uygulamak için bir şeklin kenarları etrafında pürüzsüz, bulanık bir geçiş oluşturabilirsiniz. Bu efekt, daha ince ve rafine bir görünüm katar; yumuşak, daha nazik bir görünüm gereken tasarımlar için mükemmeldir. Çeşitli şekillerde istenen etkiyi elde etmek için yarıçap gibi parametreleri kolayca ayarlayabilirsiniz.

Bu C# kodu, bir şekle [yumuşak kenarlar](https://reference.aspose.com/slides/net/aspose.slides/effectformat/softedgeeffect/) uygulamayı gösterir:

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

## **Bulanıklık Efekti Uygulama**

Bir şekil bulanıklığı, şeklin dolgusunu ve konturunu yumuşatarak şeklin düzenlenebilirliğini korur. Şeklin efekt formatında [SetBlurEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/setblureffect/) çağırın. Yarıçap, puan cinsinden ölçülür (1/72 inç): negatif olmayan bir değer kullanın; daha büyük değerler daha güçlü bulanıklık üretir. Yarıçap sıfır olduğunda görünüm değişmez.

[Grow](https://reference.aspose.com/slides/net/aspose.slides.effects/iblur/grow/) ayarı, etkinin görünür sınırlarını kontrol eder. `false` olduğunda bulanıklık, konturu da içeren orijinal boyanmış sınırlara kırpılır. `true` olduğunda bulanıklık bu sınırların ötesine uzanabilir. Hiçbir ayar, şeklin konumunu veya boyutlarını değiştirmez.

Aşağıdaki karşılaştırma, aynı dolgu, kontur ve şekil boyutları kullanılarak yapılmıştır. Üst satır `grow = false`; alt satır `grow = true` kullanır.

![Orijinal dikdörtgen, 5 ve 15 puanlık bulanıklık yarıçaplarıyla, grow devre dışı ve etkin olarak karşılaştırma](shape_blur_comparison.png)

Bu C# örneği, turuncu bir dikdörtgen oluşturur, koyu mavi bir kontur ekler, 5 puanlık bir bulanıklık uygular ve ardından aynı şekle tekrar [SetBlurEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/setblureffect/) çağırarak 15 puanlık bir bulanıklık verir. Her iki bulanık durumu kaydeder, ardından [DisableBlurEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/disableblureffect/) çağırır ve şekli bulanıklık olmadan kaydeder.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 80, 160, 100);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.Orange;
shape.LineFormat.FillFormat.FillType = FillType.Solid;
shape.LineFormat.FillFormat.SolidFillColor.Color = Color.DarkBlue;
shape.LineFormat.Width = 8;

shape.EffectFormat.SetBlurEffect(5, false);
presentation.Save("shape_blur_5.pptx", SaveFormat.Pptx);

shape.EffectFormat.SetBlurEffect(15, true);
presentation.Save("shape_blur_15.pptx", SaveFormat.Pptx);

shape.EffectFormat.DisableBlurEffect();
presentation.Save("shape_blur_removed.pptx", SaveFormat.Pptx);
```

Şekil bulanıklığı, dolgu ve konturu birlikte etkiler. Yumuşak kenarlar efekti, şeklin kenarlarını solarken, gölge bulanıklığı yalnızca gölgeyi yumuşatır. Görüntü dönüşüm efektleri, görüntü içeriği üzerinde çalışır; bu örnek, şekli bir görüntüye dönüştürmeden doğrudan şeklin efekt formatına bulanıklık uygular.

## **SSS**

**Aynı şekle birden fazla efekt uygulayabilir miyim?**

Evet, gölge, yansıma ve parıltı gibi farklı efektleri tek bir şekle birleştirerek daha dinamik bir görünüm oluşturabilirsiniz.

**Hangi şekillere efekt uygulayabilirim?**

Şekil, grafik, tablo, resim, SmartArt nesnesi, OLE nesnesi ve daha fazlası dahil olmak üzere çeşitli şekillere efekt uygulayabilirsiniz.

**Gruplanmış şekillere efekt uygulayabilir miyim?**

Evet, gruplandırılmış şekillere efekt uygulayabilirsiniz. Efekt, tüm grup üzerindeki şekillere uygulanır.