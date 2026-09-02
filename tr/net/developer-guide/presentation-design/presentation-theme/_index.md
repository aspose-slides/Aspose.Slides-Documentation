---
title: .NET'te Sunum Temalarını Yönetin
linktitle: Sunum Teması
type: docs
weight: 10
url: /tr/net/presentation-theme/
keywords:
- PowerPoint teması
- sunum teması
- slayt teması
- tema ayarla
- temayı değiştir
- temayı yönet
- tema rengi
- ek palet
- tema yazı tipi
- tema stili
- tema efekti
- PowerPoint
- OpenDocument
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET içinde ana sunum temaları, PowerPoint dosyalarını tutarlı bir marka kimliğiyle oluşturmak, özelleştirmek ve dönüştürmek için."
---
## **Giriş**

Bir sunum teması, renkler, yazı tipleri, arka plan stilleri, dolgu, çizgi ve efektlerin koordineli bir setini tanımlar. Tema‑bilinçli nesneler, her görsel özelliği sabit bir değer olarak depolamak yerine bu paylaşılan tanımlara başvurur, böylece bir tema değişikliği bir anda birçok nesneyi güncelleyebilir.

Aspose.Slides içinde sunum‑seviyesi tema, [Presentation.MasterTheme](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/mastertheme/) özelliği aracılığıyla elde edilir. Bir sunum ayrıca daha düşük seviyelerde tema geçersiz kılmaları içerebilir. Bir master, temayı [MasterThemeManager.OverrideTheme](https://reference.aspose.com/slides/tr/net/aspose.slides.theme/masterthememanager/overridetheme/) ile geçersiz kılabilir, bir düzen kalıtılan temayı [BaseOverrideThemeManager.OverrideTheme](https://reference.aspose.com/slides/tr/net/aspose.slides.theme/baseoverridethememanager/overridetheme/) ile geçersiz kılabilir ve bireysel bir slayt da aynı şeyi yapabilir. Pratikte, bir slayt için etkili tema, şu kalıtım zinciri üzerinden çözülür: sunum teması, master geçersiz kılma, düzen geçersiz kılma ve slayt geçersiz kılma.

![Tema bileşenleri: renkler, yazı tipleri, arka plan stilleri ve efektler](theme-constituents.png)

Aşağıdaki bölümler en yaygın tema iş akışlarını gösterir: bir temayı inceleme, renk ve yazı tiplerini değiştirme, temayı kopyalama veya uygulama, arka plan ve efekt stillerini güncelleme ve kalıtım ve geçersiz kılmalar çözüldükten sonra etkili değerleri okuma.

## **Temayı İncele**

[MasterTheme](https://reference.aspose.com/slides/tr/net/aspose.slides.theme/mastertheme/) nesnesi temanın [ColorScheme](https://reference.aspose.com/slides/tr/net/aspose.slides.theme/mastertheme/colorscheme/), [FontScheme](https://reference.aspose.com/slides/tr/net/aspose.slides.theme/mastertheme/fontscheme/) ve [FormatScheme](https://reference.aspose.com/slides/tr/net/aspose.slides.theme/mastertheme/formatscheme/) öğelerini dışa aktarır. Bu koleksiyonları değiştirmeden önce incelemek, bir sunum harici bir kaynaktan geldiğinde stil girişlerinin sayısı ve içeriği değişebileceği için özellikle kullanışlıdır.

Aşağıdaki örnek ana tema özelliklerini okur ve temada kaç tane arka plan, dolgu, çizgi ve efekt stilinin saklandığını raporlar:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");
var theme = presentation.MasterTheme;

Console.WriteLine($"Theme name: {theme.Name}");
Console.WriteLine($"Accent 1: {theme.ColorScheme.Accent1.Color}");
Console.WriteLine($"Major Latin font: {theme.FontScheme.Major.LatinFont.FontName}");
Console.WriteLine($"Minor Latin font: {theme.FontScheme.Minor.LatinFont.FontName}");
Console.WriteLine($"Background fill styles: {theme.FormatScheme.BackgroundFillStyles.Count}");
Console.WriteLine($"Fill styles: {theme.FormatScheme.FillStyles.Count}");
Console.WriteLine($"Line styles: {theme.FormatScheme.LineStyles.Count}");
Console.WriteLine($"Effect styles: {theme.FormatScheme.EffectStyles.Count}");
```

Bir dosya birden fazla master kullanıyorsa, her slaytın aynı etkili temaya sahip olduğunu varsaymayın. Slayt ile ilişkili master’ı inceleyin ve düzen ya da slayt geçersiz kılmaları mevcut olduğunda bu makalenin ilerleyen kısmında gösterilen etkili‑tema iş akışını kullanın.

## **Tema Renklerini Değiştir**

Tema‑bilinçli dolgu, çizgi ve metin, [SchemeColor](https://reference.aspose.com/slides/tr/net/aspose.slides/schemecolor/) enum’undan mantıksal bir renge başvurabilir. Tema’nın [IColorScheme](https://reference.aspose.com/slides/tr/net/aspose.slides.theme/icolorscheme/) içindeki ilgili girişi değiştirdiğinizde, hâlâ o tema rengini referans gösteren tüm nesneler yeni değere göre çözülür. Doğrudan RGB rengi kullanan nesneler tema‑rengi güncellemesinden etkilenmez.

Aşağıdaki uçtan uca örnek `Accent4` kullanan bir şekil oluşturur, temanın `Accent4` rengini kırmızıya değiştirir, sunumu kaydeder, yeniden açar ve etkili dolgu rengini yazdırır:

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
presentation.MasterTheme.ColorScheme.Accent4.Color = Color.Red;
presentation.Save("theme-color.pptx", SaveFormat.Pptx);

using var savedPresentation = new Presentation("theme-color.pptx");
var savedSlide = savedPresentation.Slides[0];
var savedShape = savedSlide.Shapes[0];
var effectiveFill = savedShape.FillFormat.GetEffective();
Console.WriteLine($"Effective fill color: {effectiveFill.SolidFillColor}");
```

Dikdörtgen `Accent4`e bağlı kaldığı için, tema değiştirildiğinde görünen rengi kırmızı olur. Şekildeki şema rengini doğrudan bir renkle değiştirirseniz, daha sonraki `Accent4` değişiklikleri o dolguyu etkilemez.

### **Ek Paletten Renk Kullan**

PowerPoint, bir tema renginden daha açık ve daha koyu varyantları renk dönüşümleri uygulayarak türetir. Aspose.Slides bu dönüşümleri [ColorTransformOperation](https://reference.aspose.com/slides/tr/net/aspose.slides/colortransformoperation/) aracılığıyla sunar.

![Ana tema renkleri ve ek paletten üretilen daha açık ve daha koyu renkler](additional-palette-colors.png)

**1** - Ana tema renkleri.

**2** - Ana tema renklerinden üretilen daha açık ve daha koyu varyantlar.

Aşağıdaki örnek `Accent4` temelli altı dikdörtgen oluşturur, beşine parlaklık dönüşümleri uygular ve sonucu kaydeder:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 50, 50);
shape1.FillFormat.FillType = FillType.Solid;
shape1.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;

var shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 70, 50, 50);
shape2.FillFormat.FillType = FillType.Solid;
shape2.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
shape2.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.2f);
shape2.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.8f);

var shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 130, 50, 50);
shape3.FillFormat.FillType = FillType.Solid;
shape3.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
shape3.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.4f);
shape3.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.6f);

var shape4 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 190, 50, 50);
shape4.FillFormat.FillType = FillType.Solid;
shape4.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
shape4.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.6f);
shape4.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.4f);

var shape5 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 250, 50, 50);
shape5.FillFormat.FillType = FillType.Solid;
shape5.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
shape5.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.75f);

var shape6 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 310, 50, 50);
shape6.FillFormat.FillType = FillType.Solid;
shape6.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
shape6.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.5f);

presentation.Save("theme-color-palette.pptx", SaveFormat.Pptx);
```

Bu varyantlar tema rengine dayalıdır. `Accent4` daha sonra değişirse, dönüştürülmüş renkler yeni `Accent4` değerinden yeniden hesaplanır.

### **`SchemeColor` Değerlerini `IColorScheme` Slotlarına Eşleştir**

[SchemeColor](https://reference.aspose.com/slides/tr/net/aspose.slides/schemecolor/) enum’u `Text1`, `Background1`, `Text2` ve `Background2` kullanırken, [IColorScheme](https://reference.aspose.com/slides/tr/net/aspose.slides.theme/icolorscheme/) aynı tema slotlarını `Dark1`, `Light1`, `Dark2` ve `Light2` olarak dışa aktarır. Eşleme sabittir:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Bunlar aynı tema slotları için alternatif adlardır; bir formdan diğerine dinamik olarak dönüştürülen değerler değildir.

## **Tema Yazı Tiplerini Değiştir**

Bir tema yazı tipi şeması, başlıklar için büyük bir yazı tipi kümesi ve gövde metni için küçük bir yazı tipi kümesi içerir. [FontScheme.Major](https://reference.aspose.com/slides/tr/net/aspose.slides.theme/fontscheme/major/) ve [FontScheme.Minor](https://reference.aspose.com/slides/tr/net/aspose.slides.theme/fontscheme/minor/) özellikleri bu kümeleri açığa çıkarır.

PowerPoint‑uyumlu tema yazı tipi tanımlayıcıları metin biçimlendirmede kullanılabilir:

* `+mn-lt` - Gövde Yazı Tipi Latin (Küçük Latin Yazı Tipi)
* `+mj-lt` - Başlık Yazı Tipi Latin (Büyük Latin Yazı Tipi)
* `+mn-ea` - Gövde Yazı Tipi Doğu Asya (Küçük Doğu Asya Yazı Tipi)
* `+mj-ea` - Başlık Yazı Tipi Doğu Asya (Büyük Doğu Asya Yazı Tipi)

Aşağıdaki örnek büyük Latin tema yazı tipini kullanan bir başlık ve küçük Latin tema yazı tipini kullanan bir gövde satırı oluşturur. Ardından tema yazı tiplerini değiştirir ve sonucu kaydeder:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var heading = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 500, 60);
heading.TextFrame.Text = "Theme heading";
heading.TextFrame.Paragraphs[0].Portions[0].PortionFormat.LatinFont = new FontData("+mj-lt");

var body = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 120, 500, 60);
body.TextFrame.Text = "Theme body text";
body.TextFrame.Paragraphs[0].Portions[0].PortionFormat.LatinFont = new FontData("+mn-lt");

presentation.MasterTheme.FontScheme.Major.LatinFont = new FontData("Aptos Display");
presentation.MasterTheme.FontScheme.Minor.LatinFont = new FontData("Arial");

presentation.Save("theme-fonts.pptx", SaveFormat.Pptx);
```

Başlık büyük yazı tipini, gövde metni ise küçük yazı tipini izler. Açık bir yazı tipi adı içeren metin, tema yazı tipi şeması değiştiğinde otomatik olarak değişmez.

{{% alert color="info" title="Tip" %}}
Sunum yazı tipleri hakkında daha fazla bilgi için [PowerPoint Fonts](/slides/tr/net/powerpoint-fonts/) sayfasına bakın.
{{% /alert %}}

## **Temayı Kopyala veya Uygula**

İki yaygın iş akışı vardır ve bunlar farklı sorunları çözer.

### **Kaynak Temayı Slaytları Taşırken Koru**

Bir slaytı başka bir sunuma taşımak ve orijinal tasarımını korumak istiyorsanız, kaynak master’ı hedef sunuma [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/tr/net/aspose.slides/imasterslidecollection/addclone/) ile kopyalayın, ardından slaytı ve kopyalanan master’ı [ISlideCollection.AddClone](https://reference.aspose.com/slides/tr/net/aspose.slides/islidecollection/addclone/) ile kopyalayın. Bu, master, düzenleri ve ilişkili temayı birlikte taşır.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var source = new Presentation("source-theme.pptx");
using var target = new Presentation("target.pptx");

var sourceSlide = source.Slides[0];
var sourceMaster = sourceSlide.LayoutSlide.MasterSlide;
var clonedMaster = target.Masters.AddClone(sourceMaster);
target.Slides.AddClone(sourceSlide, clonedMaster, true);

target.Save("theme-preserved.pptx", SaveFormat.Pptx);
```

Bu, kaynak slaytın hedefte aynı görünmesi gerektiğinde tercih edilen iş akışıdır. Bağlantısız bir hedef master üzerine içerik kopyalamak, tema tarafından yönlendirilen renkleri, yazı tiplerini, arka planları ve efektleri değiştirebilir.

### **Mevcut Bir Slayta Tema Değerlerini Uygula**

Hedef slayt mevcut master ve düzeninde kalmalıysa, kaynak temadan bir slayt‑seviyesi geçersiz kılma başlatın. [OverrideTheme.InitColorSchemeFrom](https://reference.aspose.com/slides/tr/net/aspose.slides.theme/overridetheme/initcolorschemefrom/), [OverrideTheme.InitFontSchemeFrom](https://reference.aspose.com/slides/tr/net/aspose.slides.theme/overridetheme/initfontschemefrom/) ve [OverrideTheme.InitFormatSchemeFrom](https://reference.aspose.com/slides/tr/net/aspose.slides.theme/overridetheme/initformatschemefrom/) yöntemleri üç ana tema bileşenini geçersiz kılmaya kopyalar.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var source = new Presentation("source-theme.pptx");
using var target = new Presentation("target.pptx");

var targetSlide = target.Slides[0];
var overrideTheme = targetSlide.ThemeManager.OverrideTheme;
overrideTheme.InitColorSchemeFrom(source.MasterTheme.ColorScheme);
overrideTheme.InitFontSchemeFrom(source.MasterTheme.FontScheme);
overrideTheme.InitFormatSchemeFrom(source.MasterTheme.FormatScheme);

target.Save("theme-applied-to-slide.pptx", SaveFormat.Pptx);
```

Bu, diğer slaytların kalıtım aldığı temayı değiştirmeden sadece o slaytın kullandığı temayı değiştirir. Yerel geçersiz kılmayı kaldırmak ve kalıtılan değerlere dönmek için [OverrideTheme.Clear](https://reference.aspose.com/slides/tr/net/aspose.slides.theme/overridetheme/clear/) çağırın.

### **Bir Düzen İçin Tema Geçersiz Kılmasını Uygula**

Düzen‑seviyesi geçersiz kılma, o düzeni kullanan slaytlara uygulanır; istisnai bir slayt kendi geçersiz kılmasına sahipse onu geçersiz kılar. Aynı başlatma yöntemleri düzenin [LayoutSlideThemeManager](https://reference.aspose.com/slides/tr/net/aspose.slides.theme/layoutslidethememanager/) üzerinden kullanılabilir:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var source = new Presentation("source-theme.pptx");
using var target = new Presentation("target.pptx");

var targetLayout = target.Slides[0].LayoutSlide;
var overrideTheme = targetLayout.ThemeManager.OverrideTheme;
overrideTheme.InitColorSchemeFrom(source.MasterTheme.ColorScheme);
overrideTheme.InitFontSchemeFrom(source.MasterTheme.FontScheme);
overrideTheme.InitFormatSchemeFrom(source.MasterTheme.FormatScheme);

target.Save("theme-applied-to-layout.pptx", SaveFormat.Pptx);
```

Birden çok düzen ve slayt aynı temel tasarımı paylaşmalıysa master veya sunum‑seviyesi tema kullanın, tek bir düzen ailesi farklı stil gerektiriyorsa düzen geçersiz kılmasını, yalnızca gerçek istisnalar için slayt geçersiz kılmasını tercih edin. Aşırı slayt‑seviyesi geçersiz kılmalar, sonraki küresel tema değişikliklerini tahmin etmeyi zorlaştırır.

## **Tema Arka Plan Stillerini Güncelle**

Tema arka plan dolgu stilleri, [FormatScheme.BackgroundFillStyles](https://reference.aspose.com/slides/tr/net/aspose.slides.theme/formatscheme/backgroundfillstyles/) içinde depolanır. PowerPoint, UI’da temalı dolgu ile tema renklerini ve diğer stil referanslarını birleştirerek bu koleksiyonda fiziken tanımlı dolgu sayısından daha fazla arka plan seçeneği sunabilir.

![PowerPoint arka plan stil galerisinin bir sunum teması için](presentation-design_8.png)

Bir arka plan stilini kullanmadan önce, depolanmış koleksiyonu ve geçerli [Background.StyleIndex](https://reference.aspose.com/slides/tr/net/aspose.slides/background/styleindex/) değerini inceleyin. `StyleIndex` temalı dolgu yoksa `0` kullanır; pozitif değerler tema arka plan‑stil referanslarını gösterir. Bu, .NET koleksiyonuna doğrudan dizinleme yaparken `[0]` ilk saklanan öğe anlamına gelen şeyden farklıdır. Her sunumun aynı sayıda arka plan dolgu stiline sahip olduğunu varsaymayın.

Aşağıdaki örnek mevcut arka plan dolgu sayısını raporlar, ilk master’a temalı bir arka plan referansı atar ve sunumu kaydeder:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");
var backgroundStyles = presentation.MasterTheme.FormatScheme.BackgroundFillStyles;
Console.WriteLine($"Background fill styles: {backgroundStyles.Count}");

if (backgroundStyles.Count == 0)
{
    throw new InvalidOperationException("The presentation theme does not contain background fill styles.");
}

presentation.Masters[0].Background.Type = BackgroundType.Themed;
presentation.Masters[0].Background.StyleIndex = 1;

presentation.Save("theme-background.pptx", SaveFormat.Pptx);
```

Görünür sonuç, master’ın referans verdiği tema girdisine ve düzen ya da slayt seviyesindeki olası arka plan geçersiz kılmalarına bağlıdır. Kalıtım uygulandıktan sonra nihai arka planı öğrenmek için [Background.GetEffective](https://reference.aspose.com/slides/tr/net/aspose.slides/background/geteffective/) kullanın.

{{% alert color="warning" title="Uyarı" %}}
`StyleIndex`i sıfır‑tabanlı bir koleksiyon indeksi gibi işlemeyin. Ayrıca bir dosyadan stil numarasını sabit kodlayıp başka bir dosyada aynı görünümü beklemeyin; tema stil tanımları sunuma özeldir.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Doğrudan arka plan biçimlendirme ve arka plan kalıtımı için [Presentation Background](/slides/tr/net/presentation-background/) bölümüne bakın.
{{% /alert %}}

## **Tema Efektlerini Güncelle**

Tema format şeması, ayrı [FillStyles](https://reference.aspose.com/slides/tr/net/aspose.slides.theme/formatscheme/fillstyles/), [LineStyles](https://reference.aspose.com/slides/tr/net/aspose.slides.theme/formatscheme/linestyles/) ve [EffectStyles](https://reference.aspose.com/slides/tr/net/aspose.slides.theme/formatscheme/effectstyles/) koleksiyonları içerir. Tipik Office temaları görsel olarak hafif, orta ve yoğun biçimlendirmeye karşılık gelen üç ana stil girişi içerir, ancak kod sabit bir sayıyı varsaymak yerine her koleksiyonu incelemelidir.

![Aynı şekle uygulanan hafif, orta ve yoğun tema efektleri](presentation-design_10.png)

Bu koleksiyonlara C#’ta eriştiğinizde koleksiyon indeksi sıfır‑tabanlıdır: `[0]` ilk saklanan stil, `[2]` üçüncüdür. Bir şeklin stil‑referans dizinleri ayrı bir kavramdır ve [IShapeStyle](https://reference.aspose.com/slides/tr/net/aspose.slides/ishapestyle/) üzerinden dışa aktarılır. Bir tema stilini değiştirmek, o temayı referans gösteren şekilleri etkiler; doğrudan biçimlendirilmiş şekiller değişmeden kalabilir.

Aşağıdaki örnek gerekli stil girişlerinin mevcut olduğunu kontrol eder, ilk çizgi stilini değiştirir, üçüncü dolgu stilini değiştirir, üçüncü efekt stilinde dış gölgeyi etkinleştirir ve sonucu kaydeder:

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Subtle_Moderate_Intense.pptx");
var formatScheme = presentation.MasterTheme.FormatScheme;

if (formatScheme.LineStyles.Count < 1 || formatScheme.FillStyles.Count < 3 || formatScheme.EffectStyles.Count < 3)
{
    throw new InvalidOperationException("The theme does not contain the style entries required by this example.");
}

formatScheme.LineStyles[0].FillFormat.FillType = FillType.Solid;
formatScheme.LineStyles[0].FillFormat.SolidFillColor.Color = Color.Red;
formatScheme.FillStyles[2].FillType = FillType.Solid;
formatScheme.FillStyles[2].SolidFillColor.Color = Color.ForestGreen;
formatScheme.EffectStyles[2].EffectFormat.EnableOuterShadowEffect();
formatScheme.EffectStyles[2].EffectFormat.OuterShadowEffect.Distance = 10f;

presentation.Save("theme-effects.pptx", SaveFormat.Pptx);
```

Bu slotları referans gösteren şekiller için, ilk tema çizgi stili kırmızı, üçüncü tema dolgu stili katı orman yeşili ve üçüncü efekt stili 10 puan uzaklıkta dış gölge kazanır. Tam görsel sonuç, her şeklin hangi stil slotlarını referans gösterdiğine ve doğrudan biçimlendirme temayı geçersiz kılıyor mu olduğuna bağlıdır.

![Tema efekt stilleri satır, dolgu ve gölge ayarları değiştirildikten sonra](presentation-design_11.png)

## **Etkili Tema Değerlerini Oku**

Ham tema nesneleri belirli bir seviyede tanımlananları gösterir. Etkili değerler, kalıtım ve yerel geçersiz kılmalar çözüldükten sonra bir slayt ya da şeklin gerçekte ne kullandığını gösterir. Bir slayt için [BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/tr/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/) çağırın. Bir arka plan için [Background.GetEffective](https://reference.aspose.com/slides/tr/net/aspose.slides/background/geteffective/), bir dolgu için ise [FillFormat.GetEffective](https://reference.aspose.com/slides/tr/net/aspose.slides/fillformat/geteffective/) kullanın.

Aşağıdaki örnek bir slayttan etkili temayı, arka planı ve ilk şekil dolgusunu okur:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");
var slide = presentation.Slides[0];
var effectiveTheme = slide.ThemeManager.CreateThemeEffective();
var effectiveBackground = slide.Background.GetEffective();

Console.WriteLine($"Effective major Latin font: {effectiveTheme.FontScheme.Major.LatinFont.FontName}");
Console.WriteLine($"Effective minor Latin font: {effectiveTheme.FontScheme.Minor.LatinFont.FontName}");
Console.WriteLine($"Effective background fill type: {effectiveBackground.FillFormat.FillType}");

if (slide.Shapes.Count > 0)
{
    var effectiveFill = slide.Shapes[0].FillFormat.GetEffective();
    Console.WriteLine($"First shape effective fill type: {effectiveFill.FillType}");
    if (effectiveFill.FillType == FillType.Solid)
    {
        Console.WriteLine($"First shape effective fill color: {effectiveFill.SolidFillColor}");
    }
}
```

Etkili verileri, render teşhisleri, doğrulama ve karşılaştırmalar için kullanın. Yalnızca [Presentation.MasterTheme](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/mastertheme/) inceleyerek, final görünümü değiştiren bir master, düzen, slayt veya şekil geçersiz kılmasını kaçırabilirsiniz.

## **SSS**

**Bir tek slayta master'ı değiştirmeden tema uygulayabilir miyim?**

Evet. Slaytın [SlideThemeManager](https://reference.aspose.com/slides/tr/net/aspose.slides.theme/slidethememanager/) kullanın ve geçersiz kılma temasını başlatın. Değişiklik yalnızca o slayta yerel kalır; diğer slaytlar mevcut temalarını kalıtım yoluyla almaya devam eder.

**Bir temayı bir sunumdan diğerine taşımanın en güvenli yolu nedir?**

Slaytı taşırken ve kaynak görünümünü korurken, kaynak master’ı hedefe kopyalayın ve ardından slaytı bu master ile [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/tr/net/aspose.slides/imasterslidecollection/addclone/) ve [ISlideCollection.AddClone](https://reference.aspose.com/slides/tr/net/aspose.slides/islidecollection/addclone/) kullanarak kopyalayın. Böylece master, düzenler ve tema birlikte korunur.

**Kalıtım ve geçersiz kılmalardan sonra etkili değerleri nasıl görebilirim?**

Bir slayt veya düzen teması için [BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/tr/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/) ve [Background.GetEffective](https://reference.aspose.com/slides/tr/net/aspose.slides/background/geteffective/) ve [FillFormat.GetEffective](https://reference.aspose.com/slides/tr/net/aspose.slides/fillformat/geteffective/) gibi ilgili etkili‑veri yöntemlerini kullanın. Bu API’ler, kalıtım ve geçersiz kılmalar uygulandıktan sonra çözülmüş değerleri döndürür.