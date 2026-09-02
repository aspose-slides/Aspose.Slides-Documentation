---
title: .NET'te Sunum Temalarını Yönetme
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
- harici tema
- THMX
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
description: "Aspose.Slides for .NET içinde ana sunum temaları, PowerPoint dosyalarını tutarlı bir markayla oluşturmak, özelleştirmek ve dönüştürmek için."
---
## **Giriş**

Bir sunum teması, renkler, yazı tipleri, arka plan stilleri, doldurmalar, çizgiler ve efektlerden oluşan koordineli bir küme tanımlar. Tema‑bilinçli nesneler, her görsel özelliği sabit bir değer olarak depolamak yerine bu ortak tanımlara başvurur; bu sayede bir tema değişikliği, birçok nesneyi aynı anda güncelleyebilir.

Aspose.Slides'te, sunum‑seviyesi tema, [Presentation.MasterTheme](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/mastertheme/) özelliği aracılığıyla kullanılabilir. Bir sunum ayrıca daha düşük seviyelerde tema geçersiz kılmalarına da sahip olabilir. Bir ana tema, [MasterThemeManager.OverrideTheme](https://reference.aspose.com/slides/tr/net/aspose.slides.theme/masterthememanager/overridetheme/) aracılığıyla sunum temasını geçersiz kılabilir, bir düzen kendi kalıtılan temasını [BaseOverrideThemeManager.OverrideTheme](https://reference.aspose.com/slides/tr/net/aspose.slides.theme/baseoverridethememanager/overridetheme/) ile geçersiz kılabilir ve bireysel bir slayt da aynı şeyi yapabilir. Pratikte, bir slayt için etkili tema, şu kalıtım zinciri üzerinden çözülür: sunum teması, ana tema geçersiz kılma, düzen geçersiz kılma ve slayt geçersiz kılma.

![Tema bileşenleri: renkler, yazı tipleri, arka plan stilleri ve efektler](theme-constituents.png)

Aşağıdaki bölümler en yaygın tema iş akışlarını gösterir: bir temayı inceleme, renk ve yazı tiplerini değiştirme, bir temayı kopyalama veya uygulama, arka plan ve efekt stillerini güncelleme ve kalıtım ve geçersiz kılmalar çözülerek elde edilen etkili değerleri okuma.

## **Bir Temayı İnceleme**

[MasterTheme](https://reference.aspose.com/slides/tr/net/aspose.slides.theme/mastertheme/) nesnesi, temanın [ColorScheme](https://reference.aspose.com/slides/tr/net/aspose.slides.theme/mastertheme/colorscheme/), [FontScheme](https://reference.aspose.com/slides/tr/net/aspose.slides.theme/mastertheme/fontscheme/) ve [FormatScheme](https://reference.aspose.com/slides/tr/net/aspose.slides.theme/mastertheme/formatscheme/) öğelerini ortaya çıkarır. Değiştirmeden önce bu koleksiyonları incelemek, özellikle sunum dış bir kaynaktan geldiğinde stil girişlerinin sayısı ve içeriği değişebileceği için faydalıdır.

Aşağıdaki örnek, ana tema özelliklerini okur ve temada kaç adet arka plan, doldurma, çizgi ve efekt stilinin depolandığını raporlar:

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

Bir dosya birden fazla ana tema kullanıyorsa, her slaytın aynı etkili temaya sahip olduğunu varsaymayın. Slayt ile ilişkili ana temayı inceleyin ve düzen veya slayt geçersiz kılmaları mevcut olduğunda bu makalenin ilerleyen kısmında gösterilen etkili‑tema iş akışını kullanın.

## **Tema Renklerini Değiştirme**

Tema‑bilinçli doldurmalar, çizgiler ve metin, [SchemeColor](https://reference.aspose.com/slides/tr/net/aspose.slides/schemecolor/) enum'undan mantıksal bir renge başvurabilir. Tema’nın [IColorScheme](https://reference.aspose.com/slides/tr/net/aspose.slides.theme/icolorscheme/) içindeki ilgili giriş değiştirilirse, hâlâ bu tema rengini başvuran tüm nesneler yeni değere göre çözülür. Doğrudan RGB rengi kullanan nesneler tema‑renk güncellemesinden etkilenmez.

Aşağıdaki uçtan‑uca örnek, `Accent4` kullanan bir şekil oluşturur, temanın `Accent4` rengini kırmızıya değiştirir, sunumu kaydeder, yeniden açar ve etkili doldurma rengini yazdırır:

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

Dikdörtgen `Accent4`e bağlı kaldığı için tema değiştirildiğinde görünen rengi kırmızı olur. Şekilde şema rengini doğrudan bir renkle değiştirirseniz, sonraki `Accent4` değişiklikleri o doldurmayı etkilemez.

### **Ek Paletten Renk Kullanma**

PowerPoint, bir tema renginden daha açık ve daha koyu varyantlar üretmek için renk dönüşümleri uygular. Aspose.Slides, bu dönüşümleri [ColorTransformOperation](https://reference.aspose.com/slides/tr/net/aspose.slides/colortransformoperation/) aracılığıyla ortaya koyar.

![Ana tema renkleri ve ek paletten oluşturulan daha açık ve daha koyu renkler](additional-palette-colors.png)

**1** - Ana tema renkleri.

**2** - Ana tema renklerinden üretilen daha açık ve daha koyu varyantlar.

Aşağıdaki örnek, `Accent4` temelinde altı dikdörtgen oluşturur, beşine parlaklık dönüşümleri uygular ve sonucu kaydeder:

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

### **`SchemeColor` Değerlerini `IColorScheme` Yuvalarına Eşleme**

[SchemeColor](https://reference.aspose.com/slides/tr/net/aspose.slides/schemecolor/) enum'u `Text1`, `Background1`, `Text2` ve `Background2` kullanırken, [IColorScheme](https://reference.aspose.com/slides/tr/net/aspose.slides.theme/icolorscheme/) aynı tema yuvalarını `Dark1`, `Light1`, `Dark2` ve `Light2` olarak ortaya koyar. Eşleme sabittir:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Bunlar aynı tema yuvalarının alternatif adlarıdır; bir formdan diğerine dinamik olarak dönüştürülen değerler değildir.

## **Tema Yazı Tiplerini Değiştirme**

Bir tema yazı tipi şeması, başlıklar için ana bir yazı tipi kümesi ve gövde metni için ikincil bir yazı tipi kümesi içerir. [FontScheme.Major](https://reference.aspose.com/slides/tr/net/aspose.slides.theme/fontscheme/major/) ve [FontScheme.Minor](https://reference.aspose.com/slides/tr/net/aspose.slides.theme/fontscheme/minor/) özellikleri bu kümeleri ortaya koyar.

PowerPoint‑uyumlu tema yazı tipi tanımlayıcıları metin biçimlendirmesinde kullanılabilir:

* `+mn-lt` - Gövde Yazı Tipi Latin (Minor Latin Font)
* `+mj-lt` - Başlık Yazı Tipi Latin (Major Latin Font)
* `+mn-ea` - Gövde Yazı Tipi Doğu Asya (Minor East Asian Font)
* `+mj-ea` - Başlık Yazı Tipi Doğu Asya (Major East Asian Font)

Aşağıdaki örnek, ana Latin tema yazı tipini kullanan bir başlık ve ikincil Latin tema yazı tipini kullanan bir gövde satırı oluşturur. Ardından tema yazı tiplerini değiştirir ve sonucu kaydeder:

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

Başlık ana yazı tipini, gövde metni ise ikincil yazı tipini izler. Açık bir yazı tipi adı kullanılan metin, tema yazı tipi şeması değiştiğinde otomatik olarak geçiş yapmaz.

Ana ve ikincil yazı tipi koleksiyonları ayrıca Kiril, Arapça, Japonca, Gürcüce ve Thaana gibi bireysel yazı sistemleri için haritalar içerebilir. Bu haritaları incelemek, eklemek, değiştirmek veya kaldırmak için [Script‑Specific Theme Fonts](/slides/tr/net/script-specific-font-mappings/) bölümüne bakın.

{{% alert color="info" title="Tip" %}}
Sunum yazı tipleri hakkında daha fazla bilgi için [PowerPoint Fonts](/slides/tr/net/powerpoint-fonts/) sayfasına bakın.
{{% /alert %}}

## **Bir Temayı Kopyalama veya Uygulama**

Aşağıdaki iş akışları farklı tema‑ilişkili problemleri çözer.

### **Harici Bir Temayı Bağlı Slaytlara Uygulama**

Bir PowerPoint tema dosyanız (`.thmx`) varsa ve belirli bir ana temaya bağlı tüm slaytların stilini yeniden uygulamak istiyorsanız [IMasterSlide.ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/tr/net/aspose.slides/imasterslide/applyexternalthemetodependingslides/) metodunu kullanın. [Presentation.Masters](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/masters/) koleksiyonundan (bu koleksiyon [IMasterSlideCollection](https://reference.aspose.com/slides/tr/net/aspose.slides/imasterslidecollection/) uygular) ana temayı seçin ve tema dosya yolunu metoda iletin.

Metot aşağıdaki işlemleri gerçekleştirir:

1. Seçilen ana temaya dayalı yeni bir master slayt oluşturur.
1. Harici temayı yeni master’a uygular.
1. Yeni master’ı daha önce seçilen master’a bağlı olan tüm slaytlara atar.
1. Yeni oluşturulan [IMasterSlide](https://reference.aspose.com/slides/tr/net/aspose.slides/imasterslide/) nesnesini döndürür.

Aşağıdaki örnek, ilk master’a bağlı slaytlara harici bir tema uygular, sunumu kaydeder ve sonucu yeniden açar:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var selectedMaster = presentation.Masters[0];
var themedMaster = selectedMaster.ApplyExternalThemeToDependingSlides("corporate-theme.thmx");

Console.WriteLine($"Created master: {themedMaster.Name}");
presentation.Save("presentation-with-external-theme.pptx", SaveFormat.Pptx);
```

Geçersiz, bozuk veya desteklenmeyen bir tema, [PptxException](https://reference.aspose.com/slides/tr/net/aspose.slides/pptxexception/) veya biçimle ilgili alt sınıflarından birine yol açabilir. Kullanıcı tarafından sağlanan yolları doğrulayın, dosya sistemi erişim hatalarını ele alın ve temayı başarıyla uyguladıktan sonra sunumu kaydedin.

Yalnızca seçilen master’a bağlı slaytlar yeniden atanır. Diğer masterlarla ilişkili slaytlar mevcut masterlarını ve temalarını korur. Tema‑bilinçli renkler, yazı tipleri, doldurmalar, çizgiler, arka planlar ve efektler harici temaya göre çözülür. Doğrudan atanmış renkler, yazı tipleri, doldurmalar ve diğer açık biçimlendirmeler değişmeden kalabilir. Düzen‑seviyesi ve slayt‑seviyesi geçersiz kılmalar da yeni master’dan kalıtılan değerlerden üstte önceliklendirilebilir.

Tema, çalışma zaman ortamında bulunmayan yazı tiplerine başvurabilir. Tutarlı görüntüleme ve dışa aktarma için gerekli yazı tiplerini yükleyin, [özel yazı tipi kaynakları](/slides/tr/net/custom-font/) aracılığıyla sağlayın veya [yazı tipi ikamesi](/slides/tr/net/font-substitution/) yapılandırın.

Bu doğrudan ana‑seviye bir iş akışıdır: metot bir `.thmx` dosya yolunu alır ve slayt‑seviyesi veya düzen‑seviyesi tema geçersiz kılmaları manuel olarak oluşturmayı gerektirmez.

### **Çok‑Ana Temalı Sunumda Farklı Harici Temalar Uygulama**

İlgili ana tema önceden bilinmiyorsa, onu temsilci bir slayttan [ISlide.LayoutSlide](https://reference.aspose.com/slides/tr/net/aspose.slides/islide/layoutslide/) ve [ILayoutSlide.MasterSlide](https://reference.aspose.com/slides/tr/net/aspose.slides/ilayoutslide/masterslide/) aracılığıyla alın. Her tema uygulamasının sunum içinde yeni bir ana oluşturduğunu unutmayın; bu yüzden temaları uygulamadan önce orijinal ana referanslarını saklayın.

Aşağıdaki örnek, iki bölümden slaytları kullanarak ana temalarını bulur ve her grup için farklı bir harici tema uygular:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("multi-master-presentation.pptx");

if (presentation.Slides.Count < 5)
{
    Console.WriteLine("The presentation does not contain the expected representative slides.");
}
else
{
    var firstGroupMaster = presentation.Slides[0].LayoutSlide.MasterSlide;
    var secondGroupMaster = presentation.Slides[4].LayoutSlide.MasterSlide;

    if (ReferenceEquals(firstGroupMaster, secondGroupMaster))
    {
        Console.WriteLine("The representative slides use the same master.");
    }
    else
    {
        var firstThemedMaster = firstGroupMaster.ApplyExternalThemeToDependingSlides("blue-theme.thmx");
        var secondThemedMaster = secondGroupMaster.ApplyExternalThemeToDependingSlides("green-theme.thmx");

        Console.WriteLine($"First themed master: {firstThemedMaster.Name}");
        Console.WriteLine($"Second themed master: {secondThemedMaster.Name}");
        presentation.Save("multi-master-with-external-themes.pptx", SaveFormat.Pptx);
    }
}
```

İlk çağrı yalnızca `firstGroupMaster`a bağlı slaytları etkiler, ikinci çağrı yalnızca `secondGroupMaster`a bağlı slaytları etkiler. Diğer ana temalara bağlı slaytlar yeniden stil verilmez.

### **Slayt Taşırken Kaynak Temasını Korumak**

Bir slaytı başka bir sunuma taşıyıp özgün tasarımını korumak istiyorsanız, kaynak masterʼı hedef sunuma **IMasterSlideCollection.AddClone** ile klonlayın, ardından slaytı ve klonlanmış masterʼı **ISlideCollection.AddClone** ile klonlayın. Bu, masterʼı, düzenlerini ve ilişkili temayı birlikte taşır.

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

Bu, kaynak slaytın hedefte aynı görünmesini istediğinizde tercih edilen iş akışıdır. İçeriği bağlamı olmayan bir hedef master’a klonlamak, tema‑tabanlı renk, yazı tipi, arka plan ve efektleri değiştirebilir.

### **Mevcut Bir Slayda Tema Değerleri Uygulama**

Hedef slayt mevcut master ve düzeninde kalmalıysa, kaynak temadan bir slayt‑seviyesi geçersiz kılma başlatın. [OverrideTheme.InitColorSchemeFrom](https://reference.aspose.com/slides/tr/net/aspose.slides.theme/overridetheme/initcolorschemefrom/), [OverrideTheme.InitFontSchemeFrom](https://reference.aspose.com/slides/tr/net/aspose.slides.theme/overridetheme/initfontschemefrom/) ve [OverrideTheme.InitFormatSchemeFrom](https://reference.aspose.com/slides/tr/net/aspose.slides.theme/overridetheme/initformatschemefrom/) metodları üç ana tema bileşenini geçersiz kılmaya kopyalar.

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

Bu, diğer slaytların kalıttığı temayı değiştirmeden yalnızca bu slaytın temasını değiştirir. Yerel geçersiz kılmayı kaldırıp kalıtılan değerlere dönmek için [OverrideTheme.Clear](https://reference.aspose.com/slides/tr/net/aspose.slides.theme/overridetheme/clear/) çağırın.

### **Bir Düzen'e Tema Geçersiz Kılma Uygulama**

Düzen‑seviyesi geçersiz kılma, o düzeni kullanan slaytlara uygulanır; yalnızca belirli bir slaytın kendi geçersiz kılması yoksa. Aynı başlatma metodları, düzenin [LayoutSlideThemeManager](https://reference.aspose.com/slides/tr/net/aspose.slides.theme/layoutslidethememanager/) üzerinden kullanılabilir:

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

Birçok düzen ve slayt aynı temel tasarımı paylaşmalıysa ana veya sunum‑seviyesi temayı, bir düzen ailesi farklı stil gerektiriyorsa düzen geçersiz kılmasını ve yalnızca gerçek istisnalar için slayt geçersiz kılmasını kullanın. Aşırı slayt‑seviyesi geçersiz kılmalar, sonraki küresel tema değişikliklerini tahmin etmeyi zorlaştırır.

## **Tema Arka Plan Stillerini Güncelleme**

Temanın arka plan doldurmaları, [FormatScheme.BackgroundFillStyles](https://reference.aspose.com/slides/tr/net/aspose.slides.theme/formatscheme/backgroundfillstyles/) içinde depolanır. PowerPoint, UI’da temaya özgü doldurmaları renklerle ve diğer stil referanslarıyla birleştirerek, koleksiyonda fiziksel olarak tanımlı doldurma sayısından daha fazla arka plan seçeneği sunabilir.

![Sunum temasına ait PowerPoint arka plan stil galerisini gösterir](presentation-design_8.png)

Bir arka plan stilini kullanmadan önce, depolanmış koleksiyonu ve geçerli [Background.StyleIndex](https://reference.aspose.com/slides/tr/net/aspose.slides/background/styleindex/) değerini inceleyin. `StyleIndex` hiçbir temalı doldurma olmadığında `0` kullanır; pozitif değerler tema arka plan‑stil referanslarıdır. Bu, .NET koleksiyonundaki doğrudan indeksle (`[0]` ilk öğe) aynı değildir. Her sunumun aynı sayıda arka plan doldurma stiline sahip olduğunu varsaymayın.

Aşağıdaki örnek, mevcut arka plan doldurma sayısını raporlar, ilk master’a temalı bir arka plan referansı atar ve sunumu kaydeder:

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

Görünür sonuç, master tarafından başvurulan tema girişine ve düzen veya slayt seviyesindeki olası arka plan geçersiz kılmalarına bağlıdır. Bir slayt kendi arka planını kullanıyorsa, yalnızca master arka planını değiştirmek o slaytı etkilemez. Kalıtım uygulanmış nihai arka planı öğrenmek için [Background.GetEffective](https://reference.aspose.com/slides/tr/net/aspose.slides/background/geteffective/) kullanın.

{{% alert color="warning" title="Uyarı" %}}
`StyleIndex`i sıfır‑tabanlı bir koleksiyon indeksi gibi değerlendirmeyin. Ayrıca bir dosyadan stil numarasını sabit kodlayıp başka bir dosyada aynı görünüme sahip olacağını varsımaktan kaçının; tema stil tanımları sunuma özgüdür.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Doğrudan arka plan biçimlendirmesi ve arka plan kalıtımı için [Presentation Background](/slides/tr/net/presentation-background/) bölümüne bakın.
{{% /alert %}}

## **Tema Efektlerini Güncelleme**

Bir tema format şeması, ayrı ayrı [FillStyles](https://reference.aspose.com/slides/tr/net/aspose.slides.theme/formatscheme/fillstyles/), [LineStyles](https://reference.aspose.com/slides/tr/net/aspose.slides.theme/formatscheme/linestyles/) ve [EffectStyles](https://reference.aspose.com/slides/tr/net/aspose.slides.theme/formatscheme/effectstyles/) koleksiyonları içerir. Tipik Office temaları görsel olarak hafif, orta ve yoğun biçimlendirmelere karşılık gelen üç ana stil girişine sahiptir, ancak kod her koleksiyonu sayıyı varsaymak yerine incelemelidir.

![Aynı şekle uygulanmış hafif, orta ve yoğun tema efektleri](presentation-design_10.png)

C# içinde bu koleksiyonlara eriştiğinizde indeksleme sıfır‑tabanlıdır: `[0]` ilk depolanmış stil, `[2]` üçüncüdür. Bir şeklin stil‑referans indeksleri ayrı bir kavramdır ve [IShapeStyle](https://reference.aspose.com/slides/tr/net/aspose.slides/ishapestyle/) aracılığıyla ortaya konur. Bir tema stilini değiştirmek, o stil referansını kullanan şekilleri etkiler; doğrudan biçimlendirilmiş şekiller değişmeden kalabilir.

Aşağıdaki örnek, gerekli stil girişlerinin varlığını kontrol eder, ilk çizgi stilini, üçüncü doldurma stilini değiştirir, üçüncü efekt stiline dış gölge ekler ve sonucu kaydeder:

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

Bu yuvalara başvuran şekiller için, ilk tema çizgi stili kırmızı, üçüncü tema doldurma stili katı orman yeşili ve üçüncü efekt stili 10 puan uzaklıkta bir dış gölge kazanır. Tam görsel sonuç, her şeklin hangi stil yuvalarına başvurduğuna ve doğrudan biçimlendirmenin temayı geçersiz kılıp kılmadığına bağlıdır.

![Çizgi, doldurma ve gölge ayarları değiştirildikten sonra tema efekt stilleri](presentation-design_11.png)

## **Etkili Tema Değerlerini Okuma**

Ham tema nesneleri, belirli bir seviyede tanımlı olanı gösterir. Etkili değerler, kalıtım ve yerel geçersiz kılmalar çözüldükten sonra bir slayt veya şeklin gerçekte ne kullandığını gösterir. Bir slayt için [BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/tr/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/) çağırın. Bir arka plan için [Background.GetEffective](https://reference.aspose.com/slides/tr/net/aspose.slides/background/geteffective/), bir doldurma için ise [FillFormat.GetEffective](https://reference.aspose.com/slides/tr/net/aspose.slides/fillformat/geteffective/) kullanın.

Aşağıdaki örnek, bir slayttan etkili temayı, arka planı ve ilk şekil doldurmasını okur:

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

Etkili verileri, görselleştirme tanılaması, doğrulama ve karşılaştırmalar için kullanın. Yalnızca [Presentation.MasterTheme](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/mastertheme/) incelemeniz, bir ana, düzen, slayt veya şekil geçersiz kılmasının nihai görünümü değiştirdiğini gözden kaçırmanıza neden olabilir.

## **SSS**

**Harici bir tema uygulamak, sunumdaki her slaytı etkiler mi?**

Hayır. [IMasterSlide.ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/tr/net/aspose.slides/imasterslide/applyexternalthemetodependingslides/) yalnızca seçilen master’a bağımlı slaytları yeniden atar. Diğer masterları kullanan slaytlar mevcut temalarını korur.

**Bir temayı tek bir slayta, master değiştirmeden uygulayabilir miyim?**

Evet. Slaytın [SlideThemeManager](https://reference.aspose.com/slides/tr/net/aspose.slides.theme/slidethememanager/) kullanın ve geçersiz kılma temasını başlatın. Değişiklik yalnızca o slayta lokal kalır; diğer slaytlar mevcut temalarını miras almaya devam eder.

**Bir temayı bir sunumdan diğerine taşımanın en güvenli yolu nedir?**

Slaytı taşırken özgün görünümünü korumak istiyorsanız, kaynak masterʼı hedefe **IMasterSlideCollection.AddClone** ile klonlayın ve ardından slaytı ve klonlanmış masterʼı **ISlideCollection.AddClone** ile klonlayın. Bu, master, düzenler ve temayı birlikte tutar.

**Kalıtım ve geçersiz kılmalardan sonra etkili değerleri nasıl görebilirim?**

Bir slayt veya düzen teması için [BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/tr/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/) ve [Background.GetEffective](https://reference.aspose.com/slides/tr/net/aspose.slides/background/geteffective/), [FillFormat.GetEffective](https://reference.aspose.com/slides/tr/net/aspose.slides/fillformat/geteffective/) gibi format nesneleri için ilgili etkili‑veri metotlarını kullanın. Bu API’ler, kalıtım ve geçersiz kılmalar uygulandıktan sonra çözülmüş değerleri döndürür.