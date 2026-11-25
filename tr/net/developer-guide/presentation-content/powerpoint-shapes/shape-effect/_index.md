---
title: PowerPoint Sunumlarında Şekil Efektlerini Uygulama .NET
linktitle: Şekil Efekti
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
description: "Aspose.Slides for .NET kullanarak gelişmiş şekil efektleriyle PPT ve PPTX dosyalarınızı dönüştürün—saniyeler içinde çarpıcı, profesyonel slaytlar oluşturun."
---
## **Giriş**

PowerPoint'teki efektler bir şekli öne çıkarmak için kullanılabilirken, [dolgular](/slides/tr/net/shape-formatting/#gradient-fill) veya kenarlıklardan farklıdır. PowerPoint efektlerini kullanarak bir şekil üzerinde ikna edici yansımalar oluşturabilir, şeklin parlaklığını yayabilirsiniz, vb.

![Shape effect](shape-effect.png)

PowerPoint, şekillere uygulanabilen altı efekt sağlar. Bir şekle bir veya birden fazla efekt uygulayabilirsiniz.

Bazı efekt kombinasyonları diğerlerinden daha iyi görünür. Bu nedenle, PowerPoint **Preset** altında seçenekler sunar. Preset seçenekleri aslında iki veya daha fazla efektin güzel görünen bilinen bir kombinasyonudur. Böylece, bir preset seçerek, güzel bir kombinasyon bulmak için farklı efektleri deneme veya birleştirme konusunda zaman kaybetmezsiniz.

Aspose.Slides, PowerPoint sunumlarındaki şekillere aynı efektleri uygulamanızı sağlayan [EffectFormat](https://reference.aspose.com/slides/net/aspose.slides/effectformat/) sınıfı altında özellikler ve yöntemler sunar.

## **Gölge Efekti Uygulama**

Aspose.Slides for .NET, şekiller için dış ve iç gölgeleri destekler. Renk, yön, mesafe ve bulanıklaştırma yarıçapını sunum tasarımınıza uygun şekilde özelleştirebilirsiniz.

### **Dış Gölge Uygulama**

Dış gölgeyi, bir kartın veya panelin slayt arka planına karşı öne çıkmasını sağlamak için kullanın. Gölge, şeklin kenarlarının ötesine uzanarak şeklin slayt üzerinde yükselmiş izlenimini yaratır. Renk, yön, mesafe ve bulanıklaştırma yarıçapını şablonunuzun ışıklandırması ve stiline uyacak şekilde ayarlayın.

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

![Shadow effect](shadow_effect.png)

### **İç Gölge Uygulama**

Bir şablonun görsel stilini yeniden üretirken, bir kartın veya panelin gömülü bir görünüm alması için iç gölge kullanın. Dış gölge şeklin dışına uzanarak yükselmiş görünürken, iç gölge kenarların iç kısmını gölgelendirir.

[EnableInnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/enableinnershadoweffect/) yöntemini çağırın, ardından [InnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/innershadoweffect/) yapılandırın. Daha büyük değerler daha yumuşak kenarlar üretir.

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

![Light blue rectangle with an inner shadow](inner_shadow_effect.png)

İç gölgeyi kaldırmak için, şeklin effect formatında [DisableInnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/disableinnershadoweffect/) yöntemini çağırın.

### **Preset Gölge Uygulama, Değiştirme ve Kaldırma**

[EnablePresetShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/enablepresetshadoweffect/) yöntemini çağırın ve [Preset](https://reference.aspose.com/slides/net/aspose.slides.effects/ipresetshadow/preset/) değerini adlandırılmış bir [PresetShadowType](https://reference.aspose.com/slides/net/aspose.slides/presetshadowtype/) olarak ayarlayın. Stilleri değiştirmek için aynı şekildeki preset'i değiştirin. Gölgeyi doldurma ve kenarlığı koruyarak kaldırmak için [DisablePresetShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/disablepresetshadoweffect/) yöntemini çağırın.

Bu örnek, her aşamada dikdörtgenin bir kopyasını tutar. Her iki gölge de 10 puan kaydırılmıştır. 225° yönü ilk gölgeyi dikdörtgenin üstüne ve soluna, 45° yönü ise ikinci gölgeyi altına ve sağına yerleştirir.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(800, 120, SlideSizeScaleType.DoNotScale);
var shapes = presentation.Slides[0].Shapes;

var shape = shapes.AddAutoShape(ShapeType.Rectangle, 15, 30, 170, 60);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.SteelBlue;
shape.LineFormat.FillFormat.FillType = FillType.Solid;
shape.LineFormat.FillFormat.SolidFillColor.Color = Color.DarkBlue;
shape.TextFrame.Text = "No shadow";
shape.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight = 14;
shapes.AddClone(shape);

shape.X += 200;
shape.EffectFormat.EnablePresetShadowEffect();
var shadow = shape.EffectFormat.PresetShadowEffect;
shadow.Preset = PresetShadowType.TopLeftDropShadow;
shadow.Distance = 10;
shadow.Direction = 225;
shape.TextFrame.Text = shadow.Preset.ToString();
shapes.AddClone(shape);

shape.X += 200;
shadow.Preset = PresetShadowType.BottomRightDropShadow;
shadow.Direction = 45;
shape.TextFrame.Text = shadow.Preset.ToString();
shapes.AddClone(shape);

shape.X += 200;
shape.EffectFormat.DisablePresetShadowEffect();
shape.TextFrame.Text = "No shadow";

presentation.Save("preset_shadows.pptx", SaveFormat.Pptx);
```

| Orijinal | İlk preset | İkinci preset | Kaldırma sonrası |
| :---: | :---: | :---: | :---: |
| ![Gölge yok](preset_shadow_original.png) | ![Sol Üst Düşen Gölge](preset_shadow_top_left.png) | ![Sağ Alt Düşen Gölge](preset_shadow_bottom_right.png) | ![Kaldırma sonrası gölge yok](preset_shadow_removed.png) |

## **Yansıma Efekti Uygulama**

Aspose.Slides for .NET'de bir yansıma efekti uygulamak için, şekillere ayna benzeri bir yansıma ekleyebilir, mesafe, şeffaflık ve boyut gibi parametreleri ayarlayabilirsiniz. Bu efekt, şekillere daha cilalı ve sofistike bir görünüm kazandırarak sunumlarınızın estetiğini artırır. Basit bir kodla uygulanması kolaydır ve tutarlı bir tasarım için birden fazla öğeye hızlı uygulama sağlar.

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

## **Parıltı Efekti Uygulama**

Aspose.Slides for .NET'te bir şekle parıltı efekti uygulamak için, şekillerin etrafına yumuşak, ışıklı bir aura ekleyebilir, renk ve boyut gibi özellikleri ayarlayabilirsiniz. Bu efekt, şekilleri öne çıkarmaya yardımcı olur ve sunumunuza çekici, göz alıcı bir görsel öğe ekler. Minimum kodla uygulanması kolaydır ve slaytlarınızın genel görünümünü geliştirir.

Bu C# kodu, bir şekle [parıltı efekti](https://reference.aspose.com/slides/net/aspose.slides/effectformat/gloweffect/) nasıl uygulanacağını gösterir:

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

Aspose.Slides for .NET'te bir şekle yumuşak kenarlar efekti uygulamak için, şeklin kenarları etrafında pürüzsüz, bulanık bir geçiş oluşturabilirsiniz. Bu efekt, daha ince ve zarif bir görünüm ekler, hafif ve yumuşak bir görünüm gerektiren tasarımlar için mükemmeldir. Çeşitli şekillerde istenen etkiyi elde etmek için yarıçap gibi parametreleri kolayca ayarlayabilirsiniz.

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

## **Bulanıklaştırma Efekti Uygulama**

Şekil bulanıklığını kullanarak bir şeklin doldurma ve kenarlığını yumuşatabilir, şeklin düzenlenebilirliğini koruyabilirsiniz. Şeklin effect formatında [SetBlurEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/setblureffect/) yöntemini çağırın. Yarıçap, nokta cinsinden ölçülür (1/72 inç): negatif olmayan bir değer kullanın; daha büyük değerler daha güçlü bir bulanıklık üretir. Sıfır yarıçap görünümü değiştirmez.

[Grow](https://reference.aspose.com/slides/net/aspose.slides.effects/iblur/grow/) ayarı efektin görünür sınırlarını kontrol eder. `false` ile bulanıklık, kenarlık dahil olmak üzere orijinal boyalı sınırlara kırpılır. `true` ile bulanıklık bu sınırların dışına genişleyebilir. Hiçbir ayar şeklin konumunu veya boyutlarını değiştirmez.

Aşağıdaki karşılaştırma, aynı doldurma, kenarlık ve şekil boyutları kullanılarak yapılmıştır. Üst satır `grow = false`; alt satır `grow = true` kullanır.

![Orijinal dikdörtgen, 5 ve 15 puanlık bulanıklaştırma yarıçaplarıyla, grow devre dışı ve etkin halde karşılaştırması](shape_blur_comparison.png)

Bu C# örneği, turuncu bir dikdörtgen oluşturur, koyu mavi bir kenarlık ekler, 5 puanlık bir bulanıklık uygular ve ardından [SetBlurEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/setblureffect/) tekrar çağırarak 15 puanlık bir bulanıklığa günceller. Her iki bulanıklaştırılmış durumu kaydeder, ardından [DisableBlurEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/disableblureffect/) çağırıp şekli bulanıksız olarak kaydeder.

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

Şekil bulanıklığı, doldurma ve kenarlığı birlikte etkiler. Yumuşak kenarlar efekti şeklin kenarlarını soldururken, gölge bulanıklığı yalnızca gölgeyi yumuşatır. Görüntü dönüşüm efektleri görsel içeriğe uygulanır; bu örnek, şekli bir görüntüye dönüştürmeden doğrudan şeklin effect formatına bulanıklık uygular.

## **SSS**

**Aynı şekle birden fazla efekti uygulayabilir miyim?**

Evet, bir şekle gölge, yansıma ve parıltı gibi farklı efektleri birleştirerek daha dinamik bir görünüm oluşturabilirsiniz.

**Hangi şekillere efekt uygulayabilirim?**

Autoshape’ler, grafikler, tablolar, resimler, SmartArt nesneleri, OLE nesneleri ve daha fazlası dahil olmak üzere çeşitli şekillere efekt uygulayabilirsiniz.

**Gruplama yapılmış şekillere efekt uygulayabilir miyim?**

Evet, gruplama yapılmış şekillere efekt uygulayabilirsiniz. Efekt tüm grup üzerinde uygulanır.