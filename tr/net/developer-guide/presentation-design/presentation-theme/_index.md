---
title: Sunum Temalarını .NET'te Yönetme
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
description: "Aspose.Slides for .NET içinde ana sunum temaları, PowerPoint dosyalarını tutarlı marka kimliğiyle oluşturmak, özelleştirmek ve dönüştürmek için."
---
## **Giriş**

Bir sunum teması, koordineli bir renk, yazı tipi, arka plan stili, dolgu, çizgi ve efekt kümesini tanımlar. Tema‑bilinçli nesneler, her görsel özelliği sabit bir değer olarak depolamak yerine bu ortak tanımlara başvurur; böylece bir tema değişikliği birçok nesneyi bir anda güncelleyebilir.

Aspose.Slides içinde, sunum‑seviyesindeki tema, [Presentation.MasterTheme](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/mastertheme/) özelliği üzerinden erişilebilir. Bir sunum ayrıca daha alt seviyelerde tema geçersiz kılmaları içerebilir. Bir master, [MasterThemeManager.OverrideTheme](https://reference.aspose.com/slides/tr/net/aspose.slides.theme/masterthememanager/overridetheme/) aracılığıyla sunum temasını geçersiz kılabilir, bir yerleşim (layout) kendi kalıtılan temasını [BaseOverrideThemeManager.OverrideTheme](https://reference.aspose.com/slides/tr/net/aspose.slides.theme/baseoverridethememanager/overridetheme/) ile geçersiz kılabilir ve bireysel bir slayt da aynı şeyi yapabilir. Pratikte, bir slayt için etkili tema, şu kalıtım zinciri üzerinden çözülür: sunum teması, master geçersiz kılma, layout geçersiz kılma ve slayt geçersiz kılma.

![Theme components: colors, fonts, background styles, and effects](theme-constituents.png)

Aşağıdaki bölümler, en yaygın tema iş akışlarını gösterir: bir temayı inceleme, renk ve yazı tiplerini değiştirme, bir temayı kopyalama veya uygulama, arka plan ve efekt stillerini güncelleme ve kalıtım ve geçersiz kılmalar çözüldükten sonra etkili değerleri okuma.

## **Bir Temayı İnceleme**

[MasterTheme](https://reference.aspose.com/slides/tr/net/aspose.slides.theme/mastertheme/) nesnesi, temanın [ColorScheme](https://reference.aspose.com/slides/tr/net/aspose.slides.theme/mastertheme/colorscheme/), [FontScheme](https://reference.aspose.com/slides/tr/net/aspose.slides.theme/mastertheme/fontscheme/) ve [FormatScheme](https://reference.aspose.com/slides/tr/net/aspose.slides.theme/mastertheme/formatscheme/) öğelerini ortaya çıkarır. Bu koleksiyonları değiştirmeden önce incelemek, özellikle bir sunum harici bir kaynaktan geldiğinde faydalıdır; çünkü stil girişlerinin sayısı ve içeriği değişkenlik gösterebilir.

Aşağıdaki örnek, ana tema özelliklerini okur ve temada kaç tane arka plan, dolgu, çizgi ve efekt stilinin depolandığını raporlar:

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

Bir dosya birden fazla master kullanıyorsa, her slaytın aynı etkili temaya sahip olduğunu varsaymayın. Slayt ile ilişkili master’ı inceleyin ve layout veya slayt geçersiz kılmaları mevcut olduğunda bu makalenin ilerleyen kısmında gösterilen etkili‑tema iş akışını kullanın.

## **Tema Renklerini Değiştirme**

Tema‑bilinçli dolgular, çizgiler ve metinler, [SchemeColor](https://reference.aspose.com/slides/tr/net/aspose.slides/schemecolor/) enum’undan mantıksal bir renge başvurabilir. Tema’nın [IColorScheme](https://reference.aspose.com/slides/tr/net/aspose.slides.theme/icolorscheme/) içinde ilgili girdiyi değiştirdiğinizde, hâlâ o tema rengini referans alan tüm nesneler yeni değere göre çözümlenir. Doğrudan bir RGB rengi kullanan nesneler, tema‑rengi güncellemesinden etkilenmez.

Aşağıdaki uçtan‑uca örnek, `Accent4` kullanan bir şekil oluşturur, temadaki `Accent4` rengini kırmızıya değiştirir, sunumu kaydeder, yeniden açar ve etkili dolgu rengini ekrana basar:

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

Dikdörtgen `Accent4`e bağlı kalmaya devam ettiğinden, tema değiştirildiğinde görünen rengi kırmızı olur. Şekildeki şema rengini doğrudan bir renkle değiştirirseniz, `Accent4`teki sonraki değişiklikler artık o dolguyu etkilemez.

### **Ek Paletten Renk Kullanma**

PowerPoint, bir tema renginden daha açık ve daha koyu varyantlar oluşturmak için renk dönüşümleri uygular. Aspose.Slides, bu dönüşümleri [ColorTransformOperation](https://reference.aspose.com/slides/tr/net/aspose.slides/colortransformoperation/) aracılığıyla sunar.

![Main theme colors and lighter and darker colors generated from the additional palette](additional-palette-colors.png)

**1** - Ana tema renkleri.

**2** - Ana tema renklerinden türetilen daha açık ve daha koyu varyantlar.

Aşağıdaki örnek, `Accent4` temel alınarak altı dikdörtgen oluşturur, beşine parlaklık dönüşümü uygular ve sonucu kaydeder:

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

[SchemeColor](https://reference.aspose.com/slides/tr/net/aspose.slides/schemecolor/) enum’u `Text1`, `Background1`, `Text2` ve `Background2` kullanırken, [IColorScheme](https://reference.aspose.com/slides/tr/net/aspose.slides.theme/icolorscheme/) aynı tema yuvalarını `Dark1`, `Light1`, `Dark2` ve `Light2` olarak sunar. Eşleme sabittir:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Bunlar aynı tema yuvalarının alternatif adlarıdır; bir formdan diğerine dinamik olarak dönüştürülen değerler değildir.

## **Tema Yazı Tiplerini Değiştirme**

Bir tema yazı tipi şeması, başlıklar için bir ana yazı tipi kümesi ve gövde metni için bir yan (minor) yazı tipi kümesi içerir. [FontScheme.Major](https://reference.aspose.com/slides/tr/net/aspose.slides.theme/fontscheme/major/) ve [FontScheme.Minor](https://reference.aspose.com/slides/tr/net/aspose.slides.theme/fontscheme/minor/) özellikleri bu kümeleri ortaya çıkarır.

PowerPoint‑uyumlu tema yazı tipi tanımlayıcıları metin biçimlendirmesinde kullanılabilir:

* `+mn-lt` - Gövde Yazı Tipi Latin (Minor Latin Font)
* `+mj-lt` - Başlık Yazı Tipi Latin (Major Latin Font)
* `+mn-ea` - Gövde Yazı Tipi Doğu Asya (Minor East Asian Font)
* `+mj-ea` - Başlık Yazı Tipi Doğu Asya (Major East Asian Font)

Aşağıdaki örnek, ana Latin tema yazı tipini kullanan bir başlık ve yan Latin tema yazı tipini kullanan bir gövde satırı oluşturur. Sonra tema yazı tiplerini değiştirir ve sonucu kaydeder:

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

Başlık ana yazı tipini, gövde metni ise yan yazı tipini izler. Açıkça bir yazı tipi adı içeren metin, tema yazı tipi şeması değiştiğinde otomatik olarak geçiş yapmaz.

Ana ve yan yazı tipi koleksiyonları ayrıca Kiril, Arapça, Japonca, Gürcü ve Thaana gibi bireysel yazı sistemleri için yazı tipi eşlemeleri içerebilir. Bu eşlemeleri incelemek, eklemek, değiştirmek veya kaldırmak için [Script‑Specific Theme Fonts](/slides/tr/net/script-specific-font-mappings/) bölümüne bakın.

{{% alert color="info" title="Tip" %}}
Daha fazla sunum yazı tipi bilgisi için [PowerPoint Fonts](/slides/tr/net/powerpoint-fonts/) sayfasına bakın.
{{% /alert %}}

## **Bir Temayı Kopyalama veya Uygulama**

Aşağıdaki iş akışları, farklı tema‑ile ilgili sorunları çözer.

### **Harici Bir Temayı Bir Master’a Bağlı Slaytlara Uygulama**

PowerPoint tema dosyanız (`.thmx`) varsa ve belirli bir master’a bağlı tüm slaytların stilini değiştirmek istiyorsanız, [IMasterSlide.ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/tr/net/aspose.slides/imasterslide/applyexternalthemetodependingslides/) kullanın. [Presentation.Masters](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/masters/) koleksiyonundan (bu koleksiyon [IMasterSlideCollection](https://reference.aspose.com/slides/tr/net/aspose.slides/imasterslidecollection/) uygular) master’ı seçin ve tema dosyası yolunu metoda iletin.

Metod şu işlemleri yapar:

1. Seçili master’a dayalı yeni bir master slayt oluşturur.
1. Harici temayı yeni master’a uygular.
1. Yeni master’ı, daha önce seçili master’a bağlı olan tüm slaytlara atar.
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

Geçersiz, bozuk veya desteklenmeyen bir tema, [PptxException](https://reference.aspose.com/slides/tr/net/aspose.slides/pptxexception/) veya onun format‑ilişkili alt sınıflarından birine yol açabilir. Kullanıcıların sağladığı yolları doğrulayın, dosya‑sistemi erişim hatalarını ele alın ve temayı başarıyla uyguladıktan sonra sunumu kaydedin.

Yalnızca seçili master’a bağlı slaytlar yeniden atanır. Diğer master’lara bağlı slaytlar mevcut master ve temalarını korur. Tema‑bilinçli renkler, yazı tipleri, dolgular, çizgiler, arka planlar ve efektler harici temaya göre çözülür. Doğrudan atanmış renkler, yazı tipleri, dolgular ve diğer açık biçimlendirmeler değişmeden kalabilir. Layout‑seviyesindeki ve slayt‑seviyesindeki geçersiz kılmalar da yeni master’dan kalıtılan değerlerin üzerinde öncelik kazanabilir.

Tema, çalışma zaman ortamında bulunmayan yazı tiplerine başvurabilir. Tutarlı görüntüleme ve dışa aktarma için gerekli yazı tiplerini kurun, [özel yazı tipi kaynakları](/slides/tr/net/custom-font/) aracılığıyla sağlayın veya [yazı tipi ikameleri](/slides/tr/net/font-substitution/) yapılandırın.

Bu, doğrudan master‑seviyesi bir iş akışıdır: metod bir `.thmx` dosyasına dosya yolu alır ve slayt‑seviyesi veya layout‑seviyesi tema geçersiz kılmaları manuel olarak oluşturmayı gerektirmez.

### **Çok‑Masterlı Bir Sunumda Farklı Harici Temalar Uygulama**

İlgili master önceden bilinmiyorsa, [ISlide.LayoutSlide](https://reference.aspose.com/slides/tr/net/aspose.slides/islide/layoutslide/) ve [ILayoutSlide.MasterSlide](https://reference.aspose.com/slides/tr/net/aspose.slides/ilayoutslide/masterslide/) aracılığıyla temsilci bir slayttan elde edin. Her temayı uygulamadan önce orijinal master referanslarını saklayın; çünkü her çağrı sunumda yeni bir master oluşturur.

Aşağıdaki örnek, iki bölümden slaytları kullanarak master’larını bulur ve her grup için farklı bir harici tema uygular:

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

İlk çağrı yalnızca `firstGroupMaster`a bağlı slaytları etkiler, ikinci çağrı yalnızca `secondGroupMaster`a bağlı slaytları etkiler. Diğer master’lara ait slaytlar yeniden stil almaz.

### **Slayt Taşıma Sırasında Kaynak Temasını Korumak**

Bir slaytı başka bir sunuma taşımak ve özgün tasarımını korumak istiyorsanız, kaynak master’ı hedef sunuma [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/tr/net/aspose.slides/imasterslidecollection/addclone/) ile klonlayın, ardından slaytı ve klonlanmış master’ı [ISlideCollection.AddClone](https://reference.aspose.com/slides/tr/net/aspose.slides/islidecollection/addclone/) ile klonlayın. Böylece master, layout’ları ve ilişkili tema birlikte taşınır.

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

Bu, kaynak slaytın hedefte aynı şekilde görünmesi gerektiğinde tercih edilen iş akışıdır. İçeriği bağımsız bir hedef master’a klonlamak, tema‑türü renkleri, yazı tiplerini, arka planları ve efektleri değiştirebilir.

### **Mevcut Bir Slayta Tema Değerlerini Uygulama**

Hedef slayt mevcut master ve layout’da kalmalıysa, kaynak temadan bir slayt‑seviyesi geçersiz kılma başlatın. [OverrideTheme.InitColorSchemeFrom](https://reference.aspose.com/slides/tr/net/aspose.slides.theme/overridetheme/initcolorschemefrom/), [OverrideTheme.InitFontSchemeFrom](https://reference.aspose.com/slides/tr/net/aspose.slides.theme/overridetheme/initfontschemefrom/) ve [OverrideTheme.InitFormatSchemeFrom](https://reference.aspose.com/slides/tr/net/aspose.slides.theme/overridetheme/initformatschemefrom/) metodları, üç ana tema bileşenini geçersiz kılamaya kopyalar.

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

Bu, diğer slaytların kalıtılan temasını değiştirmeden o slaytın temasını değiştirir. Yerel geçersiz kılmayı kaldırmak ve kalıtılan değerlere dönmek için [OverrideTheme.Clear](https://reference.aspose.com/slides/tr/net/aspose.slides.theme/overridetheme/clear/) metodunu çağırın.

### **Bir Layout’a Tema Geçersiz Kılma Uygulama**

Layout‑seviyesi bir geçersiz kılma, o layout’u kullanan slaytlara uygulanır; ancak belirli bir slaytın kendi geçersiz kılması varsa o önceliğe sahiptir. Aynı başlatma metodları, layout’un [LayoutSlideThemeManager](https://reference.aspose.com/slides/tr/net/aspose.slides.theme/layoutslidethememanager/) üzerinden de kullanılabilir:

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

Bir master ya da sunum‑seviyesi temayı, birçok layout ve slaytın aynı temel tasarımı paylaşması gerektiğinde kullanın; bir layout geçersiz kılmasını, bir layout ailesinin farklı stil alması gerektiğinde; bir slayt geçersiz kılmasını ise yalnızca gerçek istisnalar için tercih edin. Aşırı slayt‑seviyesi geçersiz kılmalar, daha sonraki küresel tema değişikliklerini tahmin etmeyi zorlaştırır.

## **Tema Arka Plan Stillerini Güncelleme**

Temanın arka plan dolguları, [FormatScheme.BackgroundFillStyles](https://reference.aspose.com/slides/tr/net/aspose.slides.theme/formatscheme/backgroundfillstyles/) içinde depolanır. PowerPoint, UI’da temaya bağlı dolguları tema renkleri ve diğer stil referanslarıyla birleştirerek, fiziksel olarak bu koleksiyonda tanımlı dolgu sayısından daha fazla arka plan seçeneği sunabilir.

![PowerPoint background style gallery for a presentation theme](presentation-design_8.png)

Bir arka plan stilini kullanmadan önce, saklanan koleksiyonu ve mevcut [Background.StyleIndex](https://reference.aspose.com/slides/tr/net/aspose.slides/background/styleindex/) değerini inceleyin. `StyleIndex` temalı dolgu olmadığında `0` kullanır; pozitif değerler tema arka plan‑stil referanslarıdır. Bu, .NET koleksiyonuna doğrudan indeksleme (`[0]` ilk öğeyi gösterir) ile aynı şey değildir. Her sunumun aynı sayıda arka plan dolgu stiline sahip olduğunu varsaymayın.

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

Görünür sonuç, master tarafından başvurulan tema girişi ve layout ya da slayt seviyesindeki herhangi bir arka plan geçersiz kılmasına bağlıdır. Bir slayt kendi arka planını kullanıyorsa, yalnızca master arka planını değiştirmek o slaytı etkilemez. Kalıtım uygulanmış nihai arka planı öğrenmek için [Background.GetEffective](https://reference.aspose.com/slides/tr/net/aspose.slides/background/geteffective/) kullanın.

{{% alert color="warning" title="Uyarı" %}}
`StyleIndex`i sıfır‑bazlı bir koleksiyon indeksi olarak değerlendirmeyin. Ayrıca bir dosyadan stil numarasını sabit kodlayıp başka bir dosyada aynı görünüm olacağını varsaymayın; tema stil tanımları sunuma özgüdür.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Doğrudan arka plan biçimlendirme ve arka plan kalıtımı için [Presentation Background](/slides/tr/net/presentation-background/) sayfasına bakın.
{{% /alert %}}

## **Tema Efektlerini Güncelleme**

Bir tema format şeması, ayrı [FillStyles](https://reference.aspose.com/slides/tr/net/aspose.slides.theme/formatscheme/fillstyles/), [LineStyles](https://reference.aspose.com/slides/tr/net/aspose.slides.theme/formatscheme/linestyles/) ve [EffectStyles](https://reference.aspose.com/slides/tr/net/aspose.slides.theme/formatscheme/effectstyles/) koleksiyonları içerir. Tipik Office temaları, görsel olarak hafif, orta ve yoğun biçimlendirmelere karşılık gelen üç temel stil girişi içerir; ancak kod, sabit bir sayıya dayanmak yerine her koleksiyonu incelemelidir.

![Subtle, moderate, and intense theme effects applied to the same shape](presentation-design_10.png)

C# içinde bu koleksiyonlara erişirken, koleksiyon indeksi sıfır‑bazlıdır: `[0]` ilk saklanan stil, `[2]` üçüncü stildir. Bir şeklin stil‑referans indeksleri ayrı bir kavramdır ve [IShapeStyle](https://reference.aspose.com/slides/tr/net/aspose.slides/ishapestyle/) aracılığıyla ortaya çıkar. Bir tema stilini değiştirmek, o tema stiline başvuran şekilleri etkiler; doğrudan biçimlendirilmiş şekiller değişmeden kalabilir.

Aşağıdaki örnek, gerekli stil girişlerinin mevcut olduğunu doğrular, ilk çizgi stilini değiştirir, üçüncü dolgu stilini değiştirir, üçüncü efekt stilinde dış gölgeyi etkinleştirir ve sonucu kaydeder:

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

Bu yuvalara başvuran şekiller için, ilk tema çizgi stili kırmızı, üçüncü tema dolgu stili katı orman yeşili ve üçüncü efekt stili 10 puan mesafede dış gölge alır. Tam görsel sonuç, her şeklin hangi yuvalara başvurduğuna ve doğrudan biçimlemenin temayı geçersiz kılıp kılmadığına bağlıdır.

![Theme effect styles after changing line, fill, and shadow settings](presentation-design_11.png)

## **Bir Etkili Katı Dolgunun Tema Rengi Kullanıp Kullandığını Belirleme**

Bir dolgu, nesne üzerinde doğrudan depolanabilir veya bir paragraftan, layout’tan, master’dan, tema stilinden veya başka bir biçimlendirme seviyesinden kalıtılabilir. Bu hiyerarşiyi değişmez bir [IFillFormatEffectiveData](https://reference.aspose.com/slides/tr/net/aspose.slides/ifillformateffectivedata/) nesnesine çözmek için [IFillFormat.GetEffective](https://reference.aspose.com/slides/tr/net/aspose.slides/ifillformat/geteffective/) çağırın. İlk olarak [IFillFormatEffectiveData.FillType](https://reference.aspose.com/slides/tr/net/aspose.slides/ifillformateffectivedata/filltype/) kontrol edin. `FillType.Solid` olduğunda katı‑dolgu özelliklerini okuyabilirsiniz.

Katı bir dolgu için, [IFillFormatEffectiveData.SolidFillColor](https://reference.aspose.com/slides/tr/net/aspose.slides/ifillformateffectivedata/solidfillcolor/) kalıtım, tema araması ve renk dönüşümleri uygulandıktan sonraki nihai RGB değerini döndürür. [IFillFormatEffectiveData.SolidFillSchemeColor](https://reference.aspose.com/slides/tr/net/aspose.slides/ifillformateffectivedata/solidfillschemecolor/) ise ilgili mantıksal [SchemeColor](https://reference.aspose.com/slides/tr/net/aspose.slides/schemecolor/) yuvasını, örneğin `Text1` veya `Accent6` gibi, verir. `SchemeColor.NotDefined` değeri, etkili katı dolgunun bir şema rengine dayanmadığını gösterir. Tema renkleri ya da doğrudan RGB renkleri kullanılan bir iş akışında, bu değer doğrudan bir RGB dolgu olduğunu belirler.

Yerel [IColorFormat.SchemeColor](https://reference.aspose.com/slides/tr/net/aspose.slides/icolorformat/schemecolor/) değerine yalnızca bakarak bir dolguyu sınıflandırmayın. Örneğin, bir metin parçasının yerel şema rengi tanımlı olmayabilir ve bu yüzden yerel değeri `NotDefined` olur; fakat etkili dolgu bir tema rengine başvurur ve `Text1` ya da `Accent6` gibi çözümlenir. Öte yandan, `SolidFillSchemeColor` hangi mantıksal tema yuvasının etkili rengi ürettiğini söyler, ancak bu yuvanın nesneden, paragraftan, layout’tan, master’dan ya da başka bir seviyeden geldiğini göstermez.

Aşağıdaki örnek bir sunumu yükler, hem şekil dolgularını hem de metin‑parça dolgularını denetler, her nihai RGB değerini ve ilişkili şema rengini yazar ve tema rengi değişikliklerini izlemeyecek katı dolguları işaretler:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");

var slideCount = presentation.Slides.Count;
for (var slideIndex = 0; slideIndex < slideCount; slideIndex++)
{
    var slide = presentation.Slides[slideIndex];

    var shapeCount = slide.Shapes.Count;
    for (var shapeIndex = 0; shapeIndex < shapeCount; shapeIndex++)
    {
        var shape = slide.Shapes[shapeIndex];
        var shapeName = $"Slide {slideIndex + 1}, shape {shapeIndex + 1}";
        AuditFill(shapeName, shape.FillFormat);

        if (shape is IAutoShape autoShape)
        {
            var paragraphCount = autoShape.TextFrame.Paragraphs.Count;
            for (var paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++)
            {
                var paragraph = autoShape.TextFrame.Paragraphs[paragraphIndex];

                var portionCount = paragraph.Portions.Count;
                for (var portionIndex = 0; portionIndex < portionCount; portionIndex++)
                {
                    var portion = paragraph.Portions[portionIndex];
                    var portionName = $"{shapeName}, paragraph {paragraphIndex + 1}, portion {portionIndex + 1}";
                    AuditFill(portionName, portion.PortionFormat.FillFormat);
                }
            }
        }
    }
}

static void AuditFill(string objectName, IFillFormat localFill)
{
    var effectiveFill = localFill.GetEffective();

    if (effectiveFill.FillType != FillType.Solid)
    {
        Console.WriteLine($"{objectName}: fill type = {effectiveFill.FillType}; not a solid fill.");
        return;
    }

    var rgb = effectiveFill.SolidFillColor;
    var effectiveSchemeColor = effectiveFill.SolidFillSchemeColor;
    var localSchemeColor = localFill.SolidFillColor.SchemeColor;

    Console.WriteLine($"{objectName}: RGB = #{rgb.R:X2}{rgb.G:X2}{rgb.B:X2}");
    Console.WriteLine($"{objectName}: local scheme = {localSchemeColor}, effective scheme = {effectiveSchemeColor}");

    if (effectiveSchemeColor == SchemeColor.NotDefined)
    {
        Console.WriteLine($"{objectName}: direct RGB or another non-scheme fill; audit as theme-independent.");
    }
    else
    {
        Console.WriteLine($"{objectName}: theme-dependent through {effectiveSchemeColor}.");
    }
}
```

`NotDefined` dalı, tema rengi slotlarındaki değişikliklere yanıt vermeyecek katı dolguların bir denetim listesini sağlar. Bu nesneleri, bir sunumun yeni bir marka paletini takip etmesi gerektiğinde gözden geçirin. Raporlanan RGB değeri hâlâ mevcut görseli gösterir, şema değeri ise bu görünümün tema ile bağlantılı olup olmadığını açıklar.

Etkili‑format nesneleri bir anlık görüntüdür. Sunum temasını, bir tema geçersiz kılmasını veya herhangi bir kalıtılmış biçimlendirmeyi değiştirdikten sonra, renkleri karşılaştırmadan veya raporlamadan önce `GetEffective`i yeniden çağırıp yeni bir `IFillFormatEffectiveData` nesnesi alın.

## **Etkili Tema Değerlerini Okuma**

Ham tema nesneleri, belirli bir seviyede neyin tanımlı olduğunu söyler. Etkili değerler ise kalıtım ve yerel geçersiz kılmalar çözülerek bir slaytın veya şeklin aslında ne kullandığını gösterir. Bir slayt için, [BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/tr/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/) çağırın. Bir arka plan için [Background.GetEffective](https://reference.aspose.com/slides/tr/net/aspose.slides/background/geteffective/), bir dolgu için ise [FillFormat.GetEffective](https://reference.aspose.com/slides/tr/net/aspose.slides/fillformat/geteffective/) kullanın.

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

Renklerin işlenmesi, doğrulama ve karşılaştırmalar için etkili verileri kullanın. Yalnızca [Presentation.MasterTheme](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/mastertheme/) incelemek, master, layout, slayt veya şekil geçersiz kılmalarını gözden kaçırmanıza sebep olabilir.

## **SSS**

**Harici bir tema uygulamak, sunumdaki her slaytı etkiler mi?**

Hayır. [IMasterSlide.ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/tr/net/aspose.slides/imasterslide/applyexternalthemetodependingslides/) yalnızca seçili master’a bağlı slaytları yeniden atar. Diğer master’ları kullanan slaytlar mevcut temalarını korur.

**Bir tema, master’ı değiştirmeden tek bir slayta uygulanabilir mi?**

Evet. Slaytın [SlideThemeManager](https://reference.aspose.com/slides/tr/net/aspose.slides.theme/slidethememanager/) kullanın ve geçersiz kılma temasını başlatın. Değişiklik yalnızca o slayta yerel olarak uygulanır; diğer slaytlar mevcut temalarını miras almaya devam eder.

**Bir temayı bir sunumdan diğerine taşımanın en güvenli yolu nedir?**

Bir slaytı taşırken ve kaynak görünümünü korurken, kaynak master’ı hedefe klonlayın ve ardından slaytı bu master ile [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/tr/net/aspose.slides/imasterslidecollection/addclone/) ve [ISlideCollection.AddClone](https://reference.aspose.com/slides/tr/net/aspose.slides/islidecollection/addclone/) kullanarak klonlayın. Böylece master, layout’lar ve tema birlikte taşınır.

**Kalıtım ve geçersiz kılmalardan sonra etkili değerleri nasıl görebilirim?**

Bir slayt veya layout teması için [BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/tr/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/) ve format nesneleri için ilgili etkili‑veri metodlarını ([Background.GetEffective](https://reference.aspose.com/slides/tr/net/aspose.slides/background/geteffective/), [FillFormat.GetEffective](https://reference.aspose.com/slides/tr/net/aspose.slides/fillformat/geteffective/)) kullanın. Bu API’ler, kalıtım ve geçersiz kılmalar uygulandıktan sonraki çözülmüş değerleri döndürür.