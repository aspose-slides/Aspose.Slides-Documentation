---
title: Sunum Temalarını .NET'te Yönet
linktitle: Sunum Teması
type: docs
weight: 10
url: /tr/net/presentation-theme/
keywords:
- PowerPoint teması
- sunum teması
- slayt teması
- tema ayarla
- tema değiştir
- tema yönet
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
description: "Aspose.Slides for .NET'te ana sunum temaları, tutarlı bir marka kimliğiyle PowerPoint dosyalarını oluşturmak, özelleştirmek ve dönüştürmek için."
---
## **Giriş**

Bir sunum teması, renkler, yazı tipleri, arka plan stilleri, dolgu, çizgi ve efektlerden oluşan koordineli bir set tanımlar. Tema‑bilinçli nesneler, her görsel özelliği sabit bir değer olarak depolamak yerine bu ortak tanımlara başvurur; böylece bir tema değişikliği bir anda birçok nesneyi güncelleyebilir.

Aspose.Slides içinde, sunum seviyesindeki tema, [Presentation.MasterTheme](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/mastertheme/) özelliği üzerinden elde edilebilir. Bir sunum ayrıca daha alt seviyelerde tema geçersiz kılmalarına da sahip olabilir. Bir master, [MasterThemeManager.OverrideTheme](https://reference.aspose.com/slides/tr/net/aspose.slides.theme/masterthememanager/overridetheme/) aracılığıyla sunum temasını geçersiz kılabilir, bir layout kendi kalıtılan temasını [BaseOverrideThemeManager.OverrideTheme](https://reference.aspose.com/slides/tr/net/aspose.slides.theme/baseoverridethememanager/overridetheme/) ile geçersiz kılabilir ve bireysel bir slayt aynı şeyi yapabilir. Pratikte, bir slayt için etkili tema, şu kalıtım zinciri üzerinden çözülür: sunum teması, master geçersiz kılma, layout geçersiz kılma ve slayt geçersiz kılma.

![Tema bileşenleri: renkler, yazı tipleri, arka plan stilleri ve efektler](theme-constituents.png)

Aşağıdaki bölümler en yaygın tema iş akışlarını gösterir: bir temayı inceleme, renk ve yazı tiplerini değiştirme, bir temayı kopyalama veya uygulama, arka plan ve efekt stillerini güncelleme ve kalıtım ile geçersiz kılmalar çözüldükten sonra etkili değerleri okuma.

## **Bir Temayı İnceleme**

[MasterTheme](https://reference.aspose.com/slides/tr/net/aspose.slides.theme/mastertheme/) nesnesi, temanın [ColorScheme](https://reference.aspose.com/slides/tr/net/aspose.slides.theme/mastertheme/colorscheme/), [FontScheme](https://reference.aspose.com/slides/tr/net/aspose.slides.theme/mastertheme/fontscheme/) ve [FormatScheme](https://reference.aspose.com/slides/tr/net/aspose.slides.theme/mastertheme/formatscheme/) koleksiyonlarını ortaya çıkarır. Bu koleksiyonları değiştirmeden önce incelemek, özellikle bir sunum dış bir kaynaktan geldiğinde stil girdi sayısı ve içeriği değişebileceği için faydalıdır.

Aşağıdaki örnek, ana tema özelliklerini okur ve temada kaç tane arka plan, dolgu, çizgi ve efekt stilinin saklandığını raporlar:

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

Bir dosya birden fazla master kullanıyorsa, her slaytın aynı etkili temaya sahip olduğunu varsaymayın. Slayt ile ilişkili masterı inceleyin ve layout veya slayt geçersiz kılmaları mevcut olduğunda bu makalenin ilerleyen kısmında gösterilen etkili tema iş akışını kullanın.

## **Tema Renklerini Değiştir**

Tema‑bilinçli dolgular, çizgiler ve metinler, [SchemeColor](https://reference.aspose.com/slides/tr/net/aspose.slides/schemecolor/) enumerasyonundan mantıksal bir renge başvurabilir. Temanın [IColorScheme](https://reference.aspose.com/slides/tr/net/aspose.slides.theme/icolorscheme/) içinde ilgili girişi değiştirdiğinizde, hâlâ o tema rengini referans alan tüm nesneler yeni değere göre çözülür. Doğrudan RGB rengi kullanan nesneler tema‑renk güncellemesinden etkilenmez.

Aşağıdaki uçtan‑uca örnek, `Accent4` kullanan bir şekil oluşturur, temanın `Accent4` rengini kırmızıya değiştirir, sunumu kaydeder, yeniden açar ve etkili dolgu rengini yazdırır:

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

Dikdörtgen `Accent4` ile bağlı kaldığı için tema değiştirildiğinde görünür rengi kırmızı olur. Eğer şekildeki şema rengini doğrudan bir renkle değiştirirseniz, `Accent4`’teki sonraki değişiklikler bu dolguyu etkilemez.

### **Ek Paletten Renk Kullanma**

PowerPoint, bir tema renginden daha açık ve daha koyu varyantlar türetmek için renk dönüşümleri uygular. Aspose.Slides bu dönüşümleri [ColorTransformOperation](https://reference.aspose.com/slides/tr/net/aspose.slides/colortransformoperation/) aracılığıyla sunar.

![Ana tema renkleri ve ek palatekten oluşturulan daha açık ve daha koyu renkler](additional-palette-colors.png)

**1** - Ana tema renkleri.  
**2** - Ana tema renklerinden üretilen daha açık ve daha koyu varyantlar.

Aşağıdaki örnek, `Accent4` temelli altı dikdörtgen oluşturur, beşine aydınlık dönüşümleri uygular ve sonucu kaydeder:

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

Bu varyantlar tema rengine dayalı kalır. `Accent4` daha sonra değişirse, dönüştürülmüş renkler yeni `Accent4` değerinden yeniden hesaplanır.

### **`SchemeColor` Değerlerini `IColorScheme` Yuvalarına Eşleştir**

[SchemeColor](https://reference.aspose.com/slides/tr/net/aspose.slides/schemecolor/) enumerasyonu `Text1`, `Background1`, `Text2` ve `Background2` kullanırken, [IColorScheme](https://reference.aspose.com/slides/tr/net/aspose.slides.theme/icolorscheme/) aynı tema yuvalarını `Dark1`, `Light1`, `Dark2` ve `Light2` olarak ortaya koyar. Eşleme sabittir:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Bunlar aynı tema yuvalarının alternatif adlarıdır; bir formdan diğerine dinamik olarak dönüştürülen değerler değildir.

## **Tema Yazı Tiplerini Değiştir**

Bir tema yazı tipi şeması, başlıklar için büyük bir yazı tipi seti ve gövde metni için küçük bir yazı tipi seti içerir. [FontScheme.Major](https://reference.aspose.com/slides/tr/net/aspose.slides.theme/fontscheme/major/) ve [FontScheme.Minor](https://reference.aspose.com/slides/tr/net/aspose.slides.theme/fontscheme/minor/) özellikleri bu setleri ortaya çıkarır.

PowerPoint uyumlu tema yazı tipi tanımlayıcıları metin biçimlendirmesinde kullanılabilir:

* `+mn-lt` - Body Font Latin (Minor Latin Font)
* `+mj-lt` - Heading Font Latin (Major Latin Font)
* `+mn-ea` - Body Font East Asian (Minor East Asian Font)
* `+mj-ea` - Heading Font East Asian (Major East Asian Font)

Aşağıdaki örnek, büyük Latin tema yazı tipini kullanan bir başlık ve küçük Latin tema yazı tipini kullanan bir gövde satırı oluşturur. Ardından tema yazı tiplerini değiştirir ve sonucu kaydeder:

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

Başlık büyük yazı tipini, gövde metni ise küçük yazı tipini izler. Açık bir yazı tipi adı tema tanımlayıcısı yerine kullanılmışsa, tema yazı tipi şeması değiştiğinde otomatik olarak değiştirilmez.

Büyük ve küçük yazı tipi koleksiyonları ayrıca Kiril, Arapça, Japonca, Gürcüce ve Thaana gibi bireysel yazı sistemleri için yazı tipi eşleştirmeleri içerebilir. Bu eşleştirmeleri incelemek, eklemek, değiştirmek veya kaldırmak için [Script‑Specific Theme Fonts](/slides/tr/net/script-specific-font-mappings/) bölümüne bakın.

{{% alert color="info" title="Tip" %}}
Sunum yazı tipleri hakkında daha fazla bilgi için, [PowerPoint Fonts](/slides/tr/net/powerpoint-fonts/) sayfasına bakın.
{{% /alert %}}

## **Bir Temayı Kopyala veya Uygula**

İki yaygın iş akışı vardır ve farklı problemleri çözerler.

### **Slaytları Taşırken Kaynak Temasını Koru**

Bir slaytı başka bir sunuma taşımak ve özgün tasarımını korumak istiyorsanız, kaynak masterı [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/tr/net/aspose.slides/imasterslidecollection/addclone/) ile hedef sunuma klonlayın, ardından slaytı [ISlideCollection.AddClone](https://reference.aspose.com/slides/tr/net/aspose.slides/islidecollection/addclone/) ve klonlanmış master ile klonlayın. Bu, masterı, layoutlarını ve ilişkili temayı birlikte taşır.

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

Bu, kaynak slaytın hedefte aynı şekilde görünmesi gerektiğinde tercih edilen iş akışıdır. İlgisiz bir hedef master üzerine içerik klonlamak tema‑türetilen renkleri, yazı tiplerini, arka planları ve efektleri değiştirebilir.

### **Mevcut Bir Slayta Tema Değerlerini Uygula**

Hedef slayt mevcut master ve layout üzerinde kalmalıysa, kaynak temadan bir slayt‑seviyesi geçersiz kılma başlatın. [OverrideTheme.InitColorSchemeFrom](https://reference.aspose.com/slides/tr/net/aspose.slides.theme/overridetheme/initcolorschemefrom/), [OverrideTheme.InitFontSchemeFrom](https://reference.aspose.com/slides/tr/net/aspose.slides.theme/overridetheme/initfontschemefrom/) ve [OverrideTheme.InitFormatSchemeFrom](https://reference.aspose.com/slides/tr/net/aspose.slides.theme/overridetheme/initformatschemefrom/) yöntemleri üç ana tema bileşenini geçersiz kılamaya kopyalar.

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

Bu, diğer slaytların kalıtılan temasını değiştirmeden o slaytın temasını değiştirir. Yerel geçersiz kılmayı kaldırıp kalıtılan değerlere dönmek için [OverrideTheme.Clear](https://reference.aspose.com/slides/tr/net/aspose.slides.theme/overridetheme/clear/) çağırın.

### **Bir Layout'a Tema Geçersiz Kılma Uygula**

Layout‑seviyesi geçersiz kılma, o layout’u kullanan slaytlara uygulanır; özel bir slayt kendi geçersiz kılmasına sahip değilse. Aynı başlatma yöntemleri layout’un [LayoutSlideThemeManager](https://reference.aspose.com/slides/tr/net/aspose.slides.theme/layoutslidethememanager/) üzerinden kullanılabilir:

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

Birden çok layout ve slayt aynı temel tasarımı paylaşmalıysa master veya sunum‑seviyesi tema kullanın; bir layout ailesi farklı bir stil gerektiriyorsa layout geçersiz kılma, yalnızca gerçek istisnalar için slayt geçersiz kılma kullanın. Aşırı slayt‑seviyesi geçersiz kılmalar, sonraki global tema değişikliklerini tahmin etmeyi zorlaştırır.

## **Tema Arka Plan Stillerini Güncelle**

Tema arka plan dolgu stilleri, [FormatScheme.BackgroundFillStyles](https://reference.aspose.com/slides/tr/net/aspose.slides.theme/formatscheme/backgroundfillstyles/) içinde saklanır. PowerPoint, UI’da temalı dolgu ile tema renklerini ve diğer stil referanslarını birleştirerek fiziksel olarak bu koleksiyonda tanımlı dolgu sayısından daha fazla arka plan seçeneği sunabilir.

![Sunum teması için PowerPoint arka plan stil galerisini gösterir](presentation-design_8.png)

Bir arka plan stili kullanmadan önce saklanan koleksiyonu ve geçerli [Background.StyleIndex](https://reference.aspose.com/slides/tr/net/aspose.slides/background/styleindex/) değerini inceleyin. `StyleIndex` temalı dolgu yoksa `0` kullanır; pozitif değerler tema arka plan‑stil referanslarıdır. Bu, .NET koleksiyonunu doğrudan indekslemeden farklıdır; `[0]` ilk saklanan öğeyi gösterir. Her sunumun aynı sayıda arka plan dolgu stili içerdiğini varsaymayın.

Aşağıdaki örnek, mevcut arka plan dolgu sayısını raporlar, ilk master’a temalı bir arka plan referansı atar ve sunumu kaydeder:

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

Görünür sonuç, master tarafından referans verilen tema girişi ve layout veya slayt seviyesindeki olası arka plan geçersiz kılmalarına bağlıdır. Sadece master arka planını değiştirirseniz, kendi arka planını kullanan bir slayt etkilenmeyebilir. Kalıtım uygulanmış nihai arka planı öğrenmek için [Background.GetEffective](https://reference.aspose.com/slides/tr/net/aspose.slides/background/geteffective/) kullanın.

{{% alert color="warning" title="Uyarı" %}}
`StyleIndex`yi sıfır‑tabanlı bir koleksiyon indeksi gibi ele almayın. Ayrıca bir dosyadan bir stil numarasını sabit kodlayıp başka bir dosyada aynı görünüme sahip olduğunu varsamayın; tema stil tanımları sunuma özgüdür.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Doğrudan arka plan biçimlendirme ve arka plan kalıtımı için [Presentation Background](/slides/tr/net/presentation-background/) bölümüne bakın.
{{% /alert %}}

## **Tema Efektlerini Güncelle**

Bir tema format şeması ayrı [FillStyles](https://reference.aspose.com/slides/tr/net/aspose.slides.theme/formatscheme/fillstyles/), [LineStyles](https://reference.aspose.com/slides/tr/net/aspose.slides.theme/formatscheme/linestyles/) ve [EffectStyles](https://reference.aspose.com/slides/tr/net/aspose.slides.theme/formatscheme/effectstyles/) koleksiyonları içerir. Tipik Office temaları genellikle görsel olarak hafif, orta ve yoğun biçimlendirmelere denk gelen üç ana stil girişi barındırır, ancak kod sabit bir sayıyı varsaymak yerine her koleksiyonu incelemelidir.

![Aynı şekle uygulanan hafif, orta ve yoğun tema efektleri](presentation-design_10.png)

C# içinde bu koleksiyonlara eriştiğinizde, koleksiyon indeksi sıfır‑tabanlıdır: `[0]` ilk saklanan stili, `[2]` üçüncü stili gösterir. Bir şeklin stil‑referans indeksleri ayrı bir kavramdır ve [IShapeStyle](https://reference.aspose.com/slides/tr/net/aspose.slides/ishapestyle/) aracılığıyla ortaya çıkar. Bir tema stilini değiştirmek, o tema stiline başvuran şekilleri etkiler; doğrudan biçimlendirilmiş şekiller değişmeden kalabilir.

Aşağıdaki örnek, gerekli stil girişlerinin mevcut olduğunu kontrol eder, ilk çizgi stilini değiştirir, üçüncü dolgu stilini değiştirir, üçüncü efekt stilinde dış gölgeyi etkinleştirir ve sonucu kaydeder:

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

Bu yuvalara başvuran şekiller için, ilk tema çizgi stili kırmızı, üçüncü tema dolgu stili katı orman yeşili ve üçüncü efekt stili 10 puan uzaklıkta bir dış gölge kazanır. Tam görsel sonuç, her şeklin hangi stil yuvasına başvurduğuna ve doğrudan biçimlendirmelerin temayı geçersiz kılıp kılmadığına bağlıdır.

![Çizgi, dolgu ve gölge ayarları değiştirildikten sonra tema efekt stilleri](presentation-design_11.png)

## **Etkili Tema Değerlerini Oku**

Ham tema nesneleri belirli bir seviyede tanımlananları gösterir. Etkili değerler ise bir slayt ya da şeklin kalıtım ve yerel geçersiz kılmalar çözüldükten sonra gerçekte ne kullandığını gösterir. Bir slayt için [BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/tr/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/) çağrın. Bir arka plan için [Background.GetEffective](https://reference.aspose.com/slides/tr/net/aspose.slides/background/geteffective/), bir dolgu için ise [FillFormat.GetEffective](https://reference.aspose.com/slides/tr/net/aspose.slides/fillformat/geteffective/) kullanın.

Aşağıdaki örnek, bir slayttan etkili temayı, arka planı ve ilk şekil dolgusunu okur:

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

Render teşhisleri, doğrulama ve karşılaştırmalar için etkili verileri kullanın. Yalnızca [Presentation.MasterTheme](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/mastertheme/) incelerseniz, final görünümü değiştiren bir master, layout, slayt veya şekil geçersiz kılmasını kaçırabilirsiniz.

## **SSS**

**Bir temayı master'ı değiştirmeden tek bir slayta uygulayabilir miyim?**

Evet. Slaytın [SlideThemeManager](https://reference.aspose.com/slides/tr/net/aspose.slides.theme/slidethememanager/) kullanın ve geçersiz tema oluşturun. Değişiklik sadece o slayta yerel kalır; diğer slaytlar mevcut temalarını kalıtır.

**Bir temayı bir sunumdan diğerine taşımanın en güvenli yolu nedir?**

Slaytı taşırken ve kaynak görünümünü korurken, kaynak masterı hedefe klonlayın ve ardından slaytı [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/tr/net/aspose.slides/imasterslidecollection/addclone/) ve [ISlideCollection.AddClone](https://reference.aspose.com/slides/tr/net/aspose.slides/islidecollection/addclone/) ile klonlayın. Bu, master, layoutlar ve temayı birlikte tutar.

**Kalıtım ve geçersiz kılmalardan sonra etkili değerleri nasıl görebilirim?**

Bir slayt veya layout teması için [BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/tr/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/) ve [Background.GetEffective](https://reference.aspose.com/slides/tr/net/aspose.slides/background/geteffective/) ve [FillFormat.GetEffective](https://reference.aspose.com/slides/tr/net/aspose.slides/fillformat/geteffective/) gibi ilgili etkili‑veri metodlarını kullanın. Bu API'ler, kalıtım ve geçersiz kılmalar uygulandıktan sonra çözülen değerleri döndürür.