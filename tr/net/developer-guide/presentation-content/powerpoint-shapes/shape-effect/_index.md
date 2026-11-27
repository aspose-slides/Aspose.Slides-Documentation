---
title: PowerPoint Sunumlarında .NET ile Şekil Efektleri Uygulama
linktitle: Şekil Efekti
type: docs
weight: 30
url: /tr/net/shape-effect/
keywords:
- şekil efekti
- gölge efekti
- yansıtma efekti
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

PowerPoint'teki efektler bir şeklin öne çıkmasını sağlamak için kullanılabilir, ancak [doldurmalar](/slides/tr/net/shape-formatting/#gradient-fill) veya kenarlıklardan farklıdır. PowerPoint efektlerini kullanarak bir şekil üzerinde ikna edici yansımalar oluşturabilir, şeklin parlaklığını yayabilirsiniz, vb.

![Şekil efekti](shape-effect.png)

PowerPoint, şekillere uygulanabilecek altı efekt sağlar. Bir şekle bir veya daha fazla efekt uygulayabilirsiniz.

Bazı efekt kombinasyonları diğerlerinden daha iyi görünür. Bu nedenle, PowerPoint **Preset** altında seçenekler sunar. Preset seçenekleri, temelde iki veya daha fazla etkinin iyi görünen bilinen bir kombinasyonudur. Böylece, bir preset seçerek, güzel bir kombinasyon bulmak için farklı efektleri deneme veya birleştirme sürecine zaman harcamazsınız.

Aspose.Slides, PowerPoint sunumlarındaki şekillere aynı efektleri uygulamanızı sağlayan [EffectFormat](https://reference.aspose.com/slides/net/aspose.slides/effectformat/) sınıfı altında özellikler ve yöntemler sunar.

## **Gölge Efekti Uygulama**

Aspose.Slides for .NET, şekiller için dış ve iç gölgeleri destekler. Renk, yön, mesafe ve bulanıklık yarıçapını sunumunuzun tasarımıyla eşleşecek şekilde özelleştirebilirsiniz.

### **Dış Gölge Uygulama**

Bir kartı veya paneli slayt arka planına karşı öne çıkarmak için dış gölge kullanın. Gölge, şeklin kenarlarının ötesine uzanarak şeklin slayt üzerinde yükselmiş gibi görünmesini sağlar. Renk, yön, mesafe ve bulanıklık yarıçapını şablonunuzun aydınlatması ve stiline uygun şekilde ayarlayın.

Bu C# kodu, bir dikdörtgene [dış gölge efekti](https://reference.aspose.com/slides/net/aspose.slides/effectformat/outershadoweffect/) uygulamanın nasıl yapılacağını gösterir:

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

#### **Şekil Döndürüldüğünde Gölge Yönünü Kontrol Et**

Varsayılan olarak, [RotateShadowWithShape](https://reference.aspose.com/slides/net/aspose.slides.effects/ioutershadow/rotateshadowwithshape/) `true` değerindedir, bu nedenle gölge şekil ile birlikte döner. Farklı dönüşlere sahip şekillerin aynı yönden aydınlatılmış görünmesi için bu özelliği `false` olarak ayarlayın ve gölgelerine aynı [Yön](https://reference.aspose.com/slides/net/aspose.slides.effects/ioutershadow/direction/) değerini verin.

Örnek, sağa kaydırılmış gri gölgeli iki ok oluşturur (`Yön = 0`). Ardından slaytı çoğaltır ve her iki oku saat yönünde 90° döndürür.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var before = presentation.Slides[0];

var left = before.Shapes.AddAutoShape(ShapeType.RightArrow, 55, 130, 110, 60);
left.FillFormat.FillType = FillType.Solid;
left.FillFormat.SolidFillColor.Color = Color.SteelBlue;
left.LineFormat.FillFormat.FillType = FillType.NoFill;

left.EffectFormat.EnableOuterShadowEffect();
var shadow = left.EffectFormat.OuterShadowEffect;
shadow.ShadowColor.Color = Color.Gray;
shadow.Direction = 0;
shadow.Distance = 42;
shadow.BlurRadius = 0;
shadow.RotateShadowWithShape = true;

var right = before.Shapes.AddClone(left);
right.X = 395;
right.EffectFormat.OuterShadowEffect.RotateShadowWithShape = false;

var after = presentation.Slides.AddClone(before);
foreach (var arrow in after.Shapes)
    arrow.Rotation = 90;

presentation.Save("arrow_shadows.pptx", SaveFormat.Pptx);
```

İkinci slaytta, sol ok gölgesini aşağıya doğru atarken, sağ ok hâlâ gölgesini sağa atar. Ayarlanan yön her iki gölge için de 0° olarak kalır.

![PowerPoint renderi 90° dönmeden önce ve sonra. Her iki gölge de sağda başlar. Dönüşten sonra gölge sol okun altına taşar ve sağ okun sağında kalır.](arrow-shadow-rotation.png)

### **İç Gölge Uygulama**

Bir şablonun görsel stilini yeniden üretirken, kart veya panele gömülü bir görünüm kazandırmak için iç gölge kullanın. Dış gölge şeklin dışına uzanarak yükselmiş görünürken, iç gölge kenarlarının içini gölgeler.

[EnableInnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/enableinnershadoweffect/)’i çağırın, ardından [InnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/innershadoweffect/)’i yapılandırın. Daha büyük değerler daha yumuşak kenarlar üretir.

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

![İç gölgelikli açık mavi dikdörtgen](inner_shadow_effect.png)

İç gölgeyi kaldırmak için, şeklin effect formatı üzerinde [DisableInnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/disableinnershadoweffect/)’i çağırın.

### **Preset Gölge Uygulama, Değiştirme ve Kaldırma**

[EnablePresetShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/enablepresetshadoweffect/)’i çağırın ve [Preset](https://reference.aspose.com/slides/net/aspose.slides.effects/ipresetshadow/preset/) değerini adlandırılmış bir [PresetShadowType](https://reference.aspose.com/slides/net/aspose.slides/presetshadowtype/) olarak ayarlayın. Stilleri değiştirmek için aynı şekilde preset'i değiştirin. Gölgeyi doldurma ve kenarlığı koruyarak kaldırmak için [DisablePresetShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/disablepresetshadoweffect/)’i çağırın.

Bu örnek, her aşamada dikdörtgenin bir kopyasını tutar. Her iki gölge de 10 puan kaydırılmıştır. 225° yönü, ilk gölgeyi dikdörtgenin üstüne ve soluna yerleştirir, 45° yönü ise ikincisini aşağıya ve sağa yerleştirir.

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
| ![Gölge yok](preset_shadow_original.png) | ![Üst Sol Düşen Gölge](preset_shadow_top_left.png) | ![Alt Sağ Düşen Gölge](preset_shadow_bottom_right.png) | ![Gölge kaldırıldıktan sonra](preset_shadow_removed.png) |

## **Yansıtma Efekti Uygulama**

Aspose.Slides for .NET'te bir yansıtma efekti uygulamak için, şekillere ayna benzeri bir yansıma ekleyebilir, mesafe, şeffaflık ve boyut gibi parametreleri ayarlayabilirsiniz. Bu efekt, şekillere daha cilalı ve sofistike bir görünüm kazandırarak sunumlarınızın estetiğini artırır. Basit bir kodla kolayca uygulanabilir, böylece tutarlı bir tasarım için birden çok öğeye hızlıca uygulanabilir.

Bu C# kodu, bir şekle [yansıtma efekti](https://reference.aspose.com/slides/net/aspose.slides/effectformat/reflectioneffect/) uygulamanın nasıl yapılacağını gösterir:

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

![Yansıtma efekti](reflection_effect.png)

## **Parlama Efekti Uygulama**

Aspose.Slides for .NET'te bir şekle parlama efekti uygulamak için, şekillerin etrafına yumuşak, ışıklı bir aura ekleyebilir, renk ve boyut gibi özellikleri ayarlayabilirsiniz. Bu efekt, şekilleri öne çıkarmaya yardımcı olur ve sunumunuza çekici, göz alıcı bir görsel öğe ekler. Minimal kodla uygulanması kolaydır ve tutarlı bir tasarım için birden çok öğeye hızlıca uygulanabilir.

Bu C# kodu, bir şekle [parlama efekti](https://reference.aspose.com/slides/net/aspose.slides/effectformat/gloweffect/) uygulamanın nasıl yapılacağını gösterir:

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

## **Yumuşak Kenarlar Efekti Uygulama**

Aspose.Slides for .NET'te yumuşak kenarlar efekti uygulamak için, bir şeklin kenarları etrafında pürüzsüz, bulanık bir geçiş oluşturabilirsiniz. Bu efekt, daha ince ve rafine bir görünüm ekler; nazik, yumuşak bir görünüm gerektiren tasarımlar için mükemmeldir. Sunumunuzdaki çeşitli şekillerde istenen efekti elde etmek için yarıçap gibi parametreleri kolayca ayarlayabilirsiniz.

Bu C# kodu, bir şekle [yumuşak kenarlar](https://reference.aspose.com/slides/net/aspose.slides/effectformat/softedgeeffect/) uygulamanın nasıl yapılacağını gösterir:

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

Şekil bulanıklığını, şeklin doldurmasını ve kenarlığını yumuşatarak, şekli düzenlenebilir tutmak için kullanın. Şeklin effect formatı üzerinde [SetBlurEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/setblureffect/)’i çağırın. Yarıçap puan cinsindendir (1/72 inç): negatif olmayan bir değer kullanın; daha büyük değerler daha güçlü bulanıklık üretir. Yarıçap sıfır ise görünüm değişmez.

[Grow](https://reference.aspose.com/slides/net/aspose.slides.effects/iblur/grow/) ayarı, etkinin görünür sınırlarını kontrol eder. `false` olduğunda, bulanıklık orijinal çizim sınırlarına, kenarlığa dahil, kırpılır. `true` olduğunda, bulanıklık bu sınırların ötesine uzanabilir. Hiçbir ayar şeklin konumunu veya boyutlarını değiştirmez.

Aşağıdaki karşılaştırma, tüm boyunca aynı doldurma, kenarlık ve şekil boyutlarını kullanır. Üst satır `grow = false`; alt satır `grow = true` kullanır.

![Orijinal dikdörtgen, 5 ve 15 puan bulanıklaştırma yarıçaplarıyla, grow devre dışı ve etkin olarak karşılaştırma](shape_blur_comparison.png)

Bu C# örneği, turuncu bir dikdörtgen oluşturur, koyu mavi bir kenarlık ekler, 5 puanlık bir bulanıklık uygular ve ardından [SetBlurEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/setblureffect/)’i tekrar çağırarak 15 puanlık bir bulanıklığa günceller. Her iki bulanıklaştırılmış durumu kaydeder, ardından [DisableBlurEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/disableblureffect/)’i çağırır ve şekli bulanıklık olmadan kaydeder.

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

Şekil bulanıklığı doldurma ve kenarlığı birlikte etkiler. Yumuşak kenarlar efekti, şeklin kenarlarını soluklaştırırken, gölge bulanıklığı yalnızca gölgeyi yumuşatır. Görüntü dönüşüm efektleri görüntü içeriği üzerinde çalışır; bu örnek, şekli bir görüntüye dönüştürmeden doğrudan şeklin effect formatına bulanıklık uygular.

## **SSS**

**Aynı şekle birden çok efekt uygulayabilir miyim?**

Evet, gölge, yansıtma ve parlama gibi farklı efektleri tek bir şekle birleştirerek daha dinamik bir görünüm oluşturabilirsiniz.

**Hangi şekillere efekt uygulayabilirim?**

Autoshape'ler, grafikler, tablolar, resimler, SmartArt nesneleri, OLE nesneleri ve daha fazlası dahil olmak üzere çeşitli şekillere efekt uygulayabilirsiniz.

**Gruplandırılmış şekillere efekt uygulayabilir miyim?**

Evet, gruplandırılmış şekillere efekt uygulayabilirsiniz. Efekt tüm gruba uygulanır.