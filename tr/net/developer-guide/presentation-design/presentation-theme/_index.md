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
description: "Aspose.Slides for .NET'te ana sunum temaları, tutarlı marka kimliğiyle PowerPoint dosyaları oluşturmak, özelleştirmek ve dönüştürmek için."
---
## **Giriş**

Bir sunum teması, renkler, yazı tipleri, arka plan stilleri, doldurulmalar, çizgiler ve efektlerden oluşan koordineli bir set tanımlar. Tema‑bilinci nesneler, her görsel özelliği sabit bir değer olarak depolamak yerine bu ortak tanımlara başvurur; böylece bir tema değişikliği, birden çok nesneyi aynı anda güncelleyebilir.

Aspose.Slides içinde, sunum‑seviyesindeki tema, [Presentation.MasterTheme](https://reference.aspose.com/slides/net/aspose.slides/presentation/mastertheme/) özelliği aracılığıyla erişilebilir. Bir sunum ayrıca alt seviyelerde tema geçersiz kılmaları da içerebilir. Bir master, [MasterThemeManager.OverrideTheme](https://reference.aspose.com/slides/net/aspose.slides.theme/masterthememanager/overridetheme/) ile sunum temasını geçersiz kılabilir, bir düzen kendi kalıtılan temasını [BaseOverrideThemeManager.OverrideTheme](https://reference.aspose.com/slides/net/aspose.slides.theme/baseoverridethememanager/overridetheme/) ile geçersiz kılabilir ve bireysel bir slayt da aynı işlemi yapabilir. Pratikte, bir slayt için geçerli tema, şu kalıtım zinciri ile çözülür: sunum teması → master geçersiz kılma → düzen geçersiz kılma → slayt geçersiz kılma.

![Tema bileşenleri: renkler, yazı tipleri, arka plan stilleri ve efektler](theme-constituents.png)

Aşağıdaki bölümler, en yaygın tema iş akışlarını gösterir: bir temayı inceleme, renk ve yazı tiplerini değiştirme, bir temayı kopyalama veya uygulama, arka plan ve efekt stillerini güncelleme ve kalıtım ve geçersiz kılmalar çözüldükten sonra etkili değerleri okuma.

## **Bir Temayı İnceleme**

[MasterTheme](https://reference.aspose.com/slides/net/aspose.slides.theme/mastertheme/) nesnesi, temanın [ColorScheme](https://reference.aspose.com/slides/net/aspose.slides.theme/mastertheme/colorscheme/), [FontScheme](https://reference.aspose.com/slides/net/aspose.slides.theme/mastertheme/fontscheme/) ve [FormatScheme](https://reference.aspose.com/slides/net/aspose.slides.theme/mastertheme/formatscheme/) öğelerini ortaya çıkarır. Bu koleksiyonları değiştirmeden önce incelemek, özellikle bir sunum dış bir kaynaktan geldiyse faydalıdır; çünkü stil girişlerinin sayısı ve içeriği değişkenlik gösterebilir.

Aşağıdaki örnek, ana tema özelliklerini okur ve temada kaç adet arka plan, doldurulma, çizgi ve efekt stilinin depolandığını raporlar:

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

Bir dosya birden fazla master kullanıyorsa, her slaytın aynı etkili temaya sahip olduğunu varsamamalısınız. Slayt ile ilişkili masterı inceleyin ve düzen ya da slayt geçersiz kılmaları mevcut olduğunda bu makalede daha sonra gösterilen etkili‑tema iş akışını kullanın.

## **Tema Renklerini Değiştirme**

Tema‑bilinci doldurulmalar, çizgiler ve metinler, [SchemeColor](https://reference.aspose.com/slides/net/aspose.slides/schemecolor/) enumʼundan mantıksal bir renge başvurabilir. Temanın [IColorScheme](https://reference.aspose.com/slides/net/aspose.slides.theme/icolorscheme/) içinde ilgili girişi değiştirildiğinde, hâlâ o tema rengini referans gösteren tüm nesneler yeni değere göre çözümlenir. Doğrudan bir RGB rengi kullanan nesneler, tema‑rengi güncellemesinden etkilenmez.

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

Dikdörtgen `Accent4` ile bağlantılı kaldığı için tema değiştirildiğinde görünür rengi kırmızı olur. Şekildeki şema rengini doğrudan bir renkle değiştirirseniz, sonraki `Accent4` değişiklikleri o doldurmayı etkilemez.

### **İlave Paletten Renk Kullanma**

PowerPoint, bir tema renginden daha açık ve daha koyu varyantları renk dönüşümleri uygulayarak türetir. Aspose.Slides, bu dönüşümleri [ColorTransformOperation](https://reference.aspose.com/slides/net/aspose.slides/colortransformoperation/) aracılığıyla sunar.

![Ana tema renkleri ve ilave paletten üretilen daha açık ve daha koyu renkler](additional-palette-colors.png)

**1** – Ana tema renkleri.  
**2** – Ana tema renklerinden üretilen daha açık ve daha koyu varyantlar.

Aşağıdaki örnek, `Accent4` temelli altı dikdörtgen oluşturur, beşine parlaklık dönüşümleri uygular ve sonucu kaydeder:

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

[SchemeColor](https://reference.aspose.com/slides/net/aspose.slides/schemecolor/) enumʼu `Text1`, `Background1`, `Text2` ve `Background2` kullanırken, [IColorScheme](https://reference.aspose.com/slides/net/aspose.slides.theme/icolorscheme/) aynı tema yuvalarını `Dark1`, `Light1`, `Dark2` ve `Light2` olarak ortaya çıkarır. Eşleme sabittir:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Bunlar aynı tema yuvalarının farklı adlarıdır; bir formdan diğerine dinamik olarak dönüştürülen değerler değildir.

## **Tema Yazı Tiplerini Değiştirme**

Bir tema yazı tipi şeması, başlıklar için bir ana (major) yazı tipi seti ve gövde metni için bir yan (minor) seti içerir. [FontScheme.Major](https://reference.aspose.com/slides/net/aspose.slides.theme/fontscheme/major/) ve [FontScheme.Minor](https://reference.aspose.com/slides/net/aspose.slides.theme/fontscheme/minor/) özellikleri bu setleri ortaya çıkarır.

PowerPoint‑uyumlu tema yazı tipi tanımlayıcıları, metin biçimlendirmesinde kullanılabilir:

* `+mn‑lt` – Gövde Yazı Tipi Latin (Minor Latin Font)
* `+mj‑lt` – Başlık Yazı Tipi Latin (Major Latin Font)
* `+mn‑ea` – Gövde Yazı Tipi Doğu Asya (Minor East Asian Font)
* `+mj‑ea` – Başlık Yazı Tipi Doğu Asya (Major East Asian Font)
* `+mn‑cs` – Gövde Yazı Tipi Karmaşık Betik (Minor Complex Script Font)
* `+mj‑cs` – Başlık Yazı Tipi Karmaşık Betik (Major Complex Script Font)

Aşağıdaki örnek, ana Latin tema yazı tipini kullanan bir başlık ve yan Latin tema yazı tipini kullanan bir gövde satırı oluşturur. Ardından tema yazı tiplerini değiştirir ve sonucu kaydeder:

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

Başlık ana yazı tipini, gövde metni ise yan yazı tipini izler. Tema tanımlayıcısı yerine açıkça bir yazı tipi adı belirtilmişse, tema yazı tipi şeması değiştiğinde otomatik olarak geçiş yapmaz.

Ana ve yan yazı tipi koleksiyonları ayrıca Kiril, Arapça, Japonca, Gürcüce ve Thaana gibi bireysel yazı sistemleri için yazı tipi eşlemeleri içerebilir. Bu eşlemeleri incelemek, eklemek, değiştirmek veya kaldırmak için [Script‑Specific Theme Fonts](/slides/tr/net/script-specific-font-mappings/) bölümüne bakın.

{{% alert color="info" title="İpucu" %}}

Sunum yazı tipleri hakkında daha fazla bilgi için [PowerPoint Fonts](/slides/tr/net/powerpoint-fonts/) sayfasına bakın.

{{% /alert %}}

### **Tema Yazı Tipi Referanslarını Çözümleme**

Metin incelerken, [IFontData.FontName](https://reference.aspose.com/slides/net/aspose.slides/ifontdata/fontname/) bir tema referansı (`+mn‑lt` gibi) içerebilir. Bu referansı çözümlemek için uygun bir [IThemeEffectiveData](https://reference.aspose.com/slides/net/aspose.slides.theme/ithemeeffectivedata/) ile [IFontData.GetFontName](https://reference.aspose.com/slides/net/aspose.slides/ifontdata/getfontname/) çağırın. `+mj` ve `+mn` önekleri ana ve yan font setlerini seçer; `-lt`, `-ea` ve `-cs` sonekleri ise Latin, Doğu Asya ve Karmaşık Betik fontlarını seçer.

Tema geçerli nesne üzerinden [IThemeable.CreateThemeEffective](https://reference.aspose.com/slides/net/aspose.slides.theme/ithemeable/createthemeeffective/) çağrısı ile elde edilir. Bir slayd üzerindeki normal metin için `slide.CreateThemeEffective()` kullanın; böylece bağlam, slaydın kalıtılan temasını ve yerel geçersiz kılmalarını içerir. Bir düzen ya da master incelendiğinde, kendi etkili temasını kullanın. İlk masterın teması tüm slaytlara uygulanıyormuş gibi varsaymayın.

Aşağıdaki örnek, yan Latin yazı tipine açıkça başvuran bir metin bölümü oluşturur. [IOverrideTheme.InitFontSchemeFromInherited](https://reference.aspose.com/slides/net/aspose.slides.theme/ioverridetheme/initfontschemefrominherited/) ile bir slayt yazı tipi şemasını başlatır ve ana ve yan Latin ailelerini `Arial` ve `Calibri` olarak ayarlar; böylece giriş dosyası olmadan sonuç tekrar üretilebilir.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var theme = slide.ThemeManager.OverrideTheme;
theme.InitFontSchemeFromInherited();
theme.FontScheme.Major.LatinFont = new FontData("Arial");
theme.FontScheme.Minor.LatinFont = new FontData("Calibri");

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 60);
shape.TextFrame.Text = "Text using the minor theme font";

var portion = shape.TextFrame.Paragraphs[0].Portions[0];
portion.PortionFormat.LatinFont = new FontData("+mn-lt");

var font = portion.PortionFormat.LatinFont;
var effectiveTheme = slide.CreateThemeEffective();
Console.WriteLine($"{font.FontName} -> {font.GetFontName(effectiveTheme)}");

var explicitFont = new FontData("Verdana");
Console.WriteLine($"{explicitFont.FontName} -> {explicitFont.GetFontName(effectiveTheme)}");
```

Çıktı `+mn‑lt -> Calibri` ardından `Verdana -> Verdana` şeklindedir. Saklanan referans değişmezken, açıkça belirtilen aile adı olduğu gibi döndürülür. Bölüm `+mj‑lt` kullansaydı, bu tema içinde `Arial` olarak çözülürdü.

Tema referansını çözümlemek, temanın belirttiği font ailesini verir. Fontun kullanılabilirliğini ya da render sırasında gerçekleşen font ikamesi / glif geri dönüşümünü kontrol etmez. Bu ayrı adımlar için [Font Selection Sequence](/slides/tr/net/font-selection-sequence/) ve [Font Substitution](/slides/tr/net/font-substitution/) bölümlerine bakın.

## **Bir Temayı Kopyalama veya Uygulama**

Aşağıdaki iş akışları, farklı tema‑ile ilgili sorunları çözer.

### **Harici Bir Temayı Bir Masterʼa Bağlı Slaytlara Uygulama**

Bir PowerPoint tema dosyası (`.thmx`) elinizde ve belirli bir masterʼa bağlı tüm slaytların stilini değiştirmek istiyorsanız, [IMasterSlide.ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/applyexternalthemetodependingslides/) kullanın. [Presentation.Masters](https://reference.aspose.com/slides/net/aspose.slides/presentation/masters/) koleksiyonundan masterı seçin (bu koleksiyon [IMasterSlideCollection](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection/) uygular) ve tema dosyasının yolunu metoda geçirin.

Metot aşağıdaki işlemleri yürütür:

1. Seçilen master temelinde yeni bir master slayt oluşturur.  
1. Harici temayı yeni mastera uygular.  
1. Önceden seçilen mastera bağlı tüm slaytları yeni mastera atar.  
1. Yeni oluşturulan [IMasterSlide](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/) nesnesini döndürür.

Aşağıdaki örnek, ilk mastera bağlı slaytlara harici bir tema uygular, sunumu kaydeder ve sonucu yeniden açar:

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

Geçersiz, bozuk ya da desteklenmeyen bir tema, [PptxException](https://reference.aspose.com/slides/net/aspose.slides/pptxexception/) veya onun biçim‑ilişkili alt sınıflarından birine neden olabilir. Kullanıcı tarafından sağlanan yolları doğrulayın, dosya sistemi erişim hatalarını yönetin ve temayı başarıyla uyguladıktan sonra sunumu kaydedin.

Yalnızca seçilen mastera bağlı slaytlar yeniden atanır. Diğer masterlara bağlı slaytlar mevcut master ve temalarını korur. Tema‑bilinci renkler, yazı tipleri, doldurulmalar, çizgiler, arka planlar ve efektler harici temaya göre çözülür. Doğrudan atanmış renkler, yazı tipleri, doldurulmalar ve diğer açık biçimlendirmeler değişmemiş kalabilir. Düzen‑seviyesi ve slayt‑seviyesi geçersiz kılmalar da yeni masterdan kalıtılan değerlerin üzerine gelebilir.

Tema, çalışma zamanında bulunmayan yazı tiplerine referans verebilir. Tutarlı render ve dışa aktarım için gerekli yazı tiplerini kurun, [özel yazı tipi kaynakları](/slides/tr/net/custom-font/) aracılığıyla sağlayın veya [yazı tipi ikamesi](/slides/tr/net/font-substitution/) yapılandırın.

Bu doğrudan master‑seviyesi bir iş akışıdır: metot, bir `.thmx` dosya yolunu kabul eder ve slayt‑seviyesi ya da düzen‑seviyesi tema geçersiz kılmaları manuel olarak oluşturmayı gerektirmez.

### **Çok‑Masterlı Bir Sunumda Farklı Harici Temalar Uygulama**

İlgili master önceden bilinmiyorsa, onu bir temsilci slayttan [ISlide.LayoutSlide](https://reference.aspose.com/slides/net/aspose.slides/islide/layoutslide/) ve [ILayoutSlide.MasterSlide](https://reference.aspose.com/slides/net/aspose.slides/ilayoutslide/masterslide/) aracılığıyla elde edin. Tema uygulamadan önce orijinal master referanslarını saklayın; çünkü her çağrı sunum içine yeni bir master ekler.

Aşağıdaki örnek, iki bölümden slaytları kullanarak masterlarını bulur ve her grup için farklı bir harici tema uygular:

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

İlk çağrı yalnızca `firstGroupMaster`a bağlı slaytları etkiler, ikinci çağrı yalnızca `secondGroupMaster`a bağlı slaytları etkiler. Diğer mastera bağlı slaytlar yeniden stil verilmez.

### **Slayt Taşırken Kaynak Temasını Korumak**

Bir slaytı başka bir sunuma taşımak ve orijinal tasarımını korumak istiyorsanız, kaynak masterı hedef sunuma [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection/addclone/) ile klonlayın, ardından slaytı ve klonlanmış masterı [ISlideCollection.AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/addclone/) ile klonlayın. Böylece master, düzenleri ve ilişkili tema birlikte taşınır.

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

Bu, kaynak slaytın hedefte aynı görünüme sahip olması gerektiğinde tercih edilen iş akışıdır. İçeriği bağımsız bir hedef mastera klonlamak, tema‑türevi renkleri, yazı tiplerini, arka planları ve efektleri değiştirebilir.

### **Mevcut Bir Slayda Tema Değerleri Uygulama**

Hedef slayt mevcut master ve düzeninde kalmalıysa, kaynak temadan bir slayt‑seviyesi geçersiz kılma başlatın. [OverrideTheme.InitColorSchemeFrom](https://reference.aspose.com/slides/net/aspose.slides.theme/overridetheme/initcolorschemefrom/), [OverrideTheme.InitFontSchemeFrom](https://reference.aspose.com/slides/net/aspose.slides.theme/overridetheme/initfontschemefrom/) ve [OverrideTheme.InitFormatSchemeFrom](https://reference.aspose.com/slides/net/aspose.slides.theme/overridetheme/initformatschemefrom/) yöntemleri, üç ana tema bileşenini geçersiz kılmaya kopyalar.

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

Bu, diğer slaytların kalıtılan temasını değiştirmeden yalnızca o slaytın temasını değiştirir. Yerel geçersiz kılmayı kaldırıp kalıtılan değerlere dönmek için [OverrideTheme.Clear](https://reference.aspose.com/slides/net/aspose.slides.theme/overridetheme/clear/) çağırın.

### **Bir Düzen’e Tema Geçersiz Kılma Uygulama**

Düzen‑seviyesi geçersiz kılma, o düzeni kullanan slaytlara uygulanır; bir slaytın kendi geçersiz kılması yoksa. Aynı başlatma yöntemleri, düzenin [LayoutSlideThemeManager](https://reference.aspose.com/slides/net/aspose.slides.theme/layoutslidethememanager/) üzerinden kullanılabilir:

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

Birden çok düzen ve slayt aynı temel tasarımı paylaşmalıysa master ya da sunum‑seviyesi tema kullanın; bir düzen ailesi farklı bir stil gerektiriyorsa düzen geçersiz kılmasını, yalnızca gerçek istisnalar için slayt geçersiz kılmasını tercih edin. Aşırı slayt‑seviyesi geçersiz kılmalar, sonraki küresel tema değişikliklerini tahmin etmeyi zorlaştırır.

## **Tema Arka Plan Stillerini Güncelleme**

Temanın arka plan doldurulmaları, [FormatScheme.BackgroundFillStyles](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme/backgroundfillstyles/) içinde depolanır. PowerPoint, UIʼsinde tema doldurulmalarını tema renkleri ve diğer stil referanslarıyla birleştirerek daha fazla arka plan seçeneği sunabilir; bu durum, koleksiyonda fiziksel olarak saklanan doldurma tanımlarının sayısından daha fazladır.

![Sunum temasının PowerPoint arka plan stil galerisii](presentation-design_8.png)

Bir arka plan stilini kullanmadan önce, depolanmış koleksiyonu ve geçerli [Background.StyleIndex](https://reference.aspose.com/slides/net/aspose.slides/background/styleindex/) değerini inceleyin. `StyleIndex` değeri `0` olduğunda temalı doldurma yoktur; pozitif değerler tema arka plan‑stil referanslarıdır. Bu, .NET koleksiyonundaki indeksleme (`[0]` ilk öğeyi gösterir) ile aynı değildir. Her sunumun aynı sayıda arka plan doldurma stiline sahip olduğunu varsaymayın.

Aşağıdaki örnek, kullanılabilir arka plan doldurma sayısını raporlar, ilk mastera temalı bir arka plan referansı atar ve sunumu kaydeder:

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

Görünür sonuç, master tarafından referans verilen tema girişine ve düzen ya da slayt seviyesindeki olası arka plan geçersiz kılmalarına bağlıdır. Bir slayt kendi arka planını kullanıyorsa, yalnızca master arka planını değiştirmek o slaytı etkilemez. Kalıtım uygulandıktan sonra nihai arka planı öğrenmek için [Background.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/background/geteffective/) kullanın.

{{% alert color="warning" title="Uyarı" %}}

`StyleIndex` değerini sıfır‑tabanlı koleksiyon indeksi gibi işlemeyin. Ayrıca bir dosyadan bir stil numarasını sabit kodlayıp başka bir dosyada aynı görünüme sahip olduğunu varsımayın; tema stil tanımlamaları sunuma özgüdür.

{{% /alert %}}

{{% alert color="info" title="İpucu" %}}

Doğrudan arka plan biçimlendirme ve arka plan kalıtımı için [Presentation Background](/slides/tr/net/presentation-background/) sayfasına bakın.

{{% /alert %}}

## **Tema Efektlerini Güncelleme**

Bir tema format şeması, ayrı ayrı [FillStyles](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme/fillstyles/), [LineStyles](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme/linestyles/) ve [EffectStyles](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme/effectstyles/) koleksiyonları içerir. Tipik Office temalarında görsel olarak hafif, orta ve yoğun biçimlendirmelere karşılık gelen üç temel stil girişi bulunur; ancak kod, sabit bir sayıya varsaymadan her koleksiyonu incelemelidir.

![Aynı şekle uygulanmış hafif, orta ve yoğun tema efektleri](presentation-design_10.png)

C#ʼde bu koleksiyonlara eriştiğinizde, koleksiyon indeksi sıfır‑tabanlıdır: `[0]` ilk depolanmış stil, `[2]` üçüncü stildir. Bir şeklin stil‑referans indeksleri ayrı bir kavramdır ve [IShapeStyle](https://reference.aspose.com/slides/net/aspose.slides/ishapestyle/) aracılığıyla ortaya çıkar. Bir tema stilini değiştirmek, o tema stiline başvuran şekilleri etkiler; doğrudan biçimlendirilmiş şekiller değişmeden kalabilir.

Aşağıdaki örnek, gerekli stil girişlerinin mevcut olduğunu kontrol eder, ilk çizgi stilini değiştirir, üçüncü doldurma stilini değiştirir, üçüncü efekt stilinde dış gölgeyi etkinleştirir ve sonucu kaydeder:

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

Bu yuvalara başvuran şekillerde, ilk tema çizgi stili kırmızı, üçüncü tema doldurma stili katı orman yeşili ve üçüncü efekt stili 10 puan uzaklıkta bir dış gölge alır. Tam görsel sonuç, her şeklin hangi stil yuvalarına başvurduğuna ve doğrudan biçimlendirmenin temayı geçersiz kılıp kılmadığına bağlıdır.

![Satır, doldurma ve gölge ayarları değiştirildikten sonra tema efekt stilleri](presentation-design_11.png)

## **Bir Şekil İçin Tema Doldurma ve Çizgi Stilini Seçme**

Bir şekil, doldurmasını ve konturunu bağımsız olarak [FillStyleIndex](https://reference.aspose.com/slides/net/aspose.slides/ishapestyle/fillstyleindex/) ve [LineStyleIndex](https://reference.aspose.com/slides/net/aspose.slides/ishapestyle/linestyleindex/) aracılığıyla seçebilir. Her iki özellik için indeks `1` ilgili tema koleksiyonundaki ilk girişi (`FillStyles[0]` veya `LineStyles[0]`) seçer, indeks `2` ikinci girişi seçer.

Aşağıdaki örnek, yeni bir sunumun varsayılan temasında iki doldurma stili (altın ve gökyüzü mavisi) ve iki çizgi stili (6 pt koyu mavi ve 12 pt koyu kırmızı) oluşturur. Sonucu üç aşamada kaydeder, böylece PowerPoint içinde karşılaştırabilirsiniz.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var styles = presentation.MasterTheme.FormatScheme;

var goldFill = styles.FillStyles[0];
goldFill.FillType = FillType.Solid;
goldFill.SolidFillColor.Color = Color.Gold;
var blueFill = styles.FillStyles[1];
blueFill.FillType = FillType.Solid;
blueFill.SolidFillColor.Color = Color.SkyBlue;

var thinLine = styles.LineStyles[0];
thinLine.FillFormat.FillType = FillType.Solid;
thinLine.FillFormat.SolidFillColor.Color = Color.DarkBlue;
thinLine.Width = 6;
var thickLine = styles.LineStyles[1];
thickLine.FillFormat.FillType = FillType.Solid;
thickLine.FillFormat.SolidFillColor.Color = Color.DarkRed;
thickLine.Width = 12;

var shapes = presentation.Slides[0].Shapes;
var left = shapes.AddAutoShape(ShapeType.Rectangle, 100, 205, 200, 130);
var right = shapes.AddAutoShape(ShapeType.Rectangle, 420, 205, 200, 130);
left.ShapeStyle.FillStyleIndex = 1;
right.ShapeStyle.FillStyleIndex = 2;
left.ShapeStyle.LineStyleIndex = 1;
right.ShapeStyle.LineStyleIndex = 1;
presentation.Save("01-initial.pptx", SaveFormat.Pptx);

right.ShapeStyle.LineStyleIndex = 2;
presentation.Save("02-line-changed.pptx", SaveFormat.Pptx);

goldFill.SolidFillColor.Color = Color.SeaGreen;
presentation.Save("03-theme-changed.pptx", SaveFormat.Pptx);
```

| Başlangıç stilleri | Sağ konturu değiştir | İlk tema doldurmasını düzenle |
|:---:|:---:|:---:|
| ![Altın ve gökyüzü‑mavi dikdörtgenler, eşleşen ince koyu mavi çizgiler](theme-style-initial.png) | ![Gökyüzü‑mavi dikdörtgen artık kalın koyu kırmızı bir kontura sahip](theme-style-line-changed.png) | ![Sol dikdörtgen şimdi yeşil, her iki kontur değişmedi](theme-style-fill-changed.png) |

Farklı bir çizgi stili seçmek yalnızca sağ dikdörtgenin konturunu değiştirir. İlk tema doldurmasını düzenlemek, onu kullanan her şekli günceller; bu örnekte sadece sol dikdörtgen yeşile döner.

Mevcut bir şekilde, yerel doldurma rengi, çizgi rengi veya çizgi kalınlığı tema stilinin o bölümünü geçersiz kılabilir. Stil indeksi değiştirilip bir etki gözükmezse, şeklin [doğrudan biçimlendirmesine](/slides/tr/net/shape-formatting/) bakın.

## **Etkili Katı Doldurmanın Tema Rengi Kullanıp Kullanmadığını Belirleme**

Bir doldurma, doğrudan bir nesneye kaydedilmiş ya da bir paragraftan, düzenten, masterdan, tema stilinden ya da başka bir biçimleme seviyesinden kalıtılmış olabilir. Bu hiyerarşiyi çözmek için [IFillFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/geteffective/) çağırın; bu, değiştirilemez bir [IFillFormatEffectiveData](https://reference.aspose.com/slides/net/aspose.slides/ifillformateffectivedata/) nesnesi döndürür. İlk olarak [IFillFormatEffectiveData.FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformateffectivedata/filltype/) kontrol edin. Yalnızca `FillType.Solid` olduğunda katı doldurma özelliklerini okuyun.

Katı bir doldurma için, [IFillFormatEffectiveData.SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/ifillformateffectivedata/solidfillcolor/) kalıtım, tema bakışı ve renk dönüşümleri uygulandıktan sonraki son render edilen RGB değerini döndürür. [IFillFormatEffectiveData.SolidFillSchemeColor](https://reference.aspose.com/slides/net/aspose.slides/ifillformateffectivedata/solidfillschemecolor/) ilgili mantıksal [SchemeColor](https://reference.aspose.com/slides/net/aspose.slides/schemecolor/) slotunu verir; örneğin `Text1` veya `Accent6`. `SchemeColor.NotDefined` değeri, etkili katı doldurmanın bir şema rengine dayanmadığını gösterir. Tema renkleri veya doğrudan RGB renkleri kullanan bir iş akışında bu değer, doğrudan bir RGB doldurmayı gösterir.

Yerel [IColorFormat.SchemeColor](https://reference.aspose.com/slides/net/aspose.slides/icolorformat/schemecolor/) değerine yalnızca bakarak bir doldurmayı sınıflandırmayın. Örneğin, bir metin bölümü yerel olarak şema rengi tanımlamamış olabilir ve bu yüzden yerel değeri `NotDefined` olur; ancak etkili doldurması tema rengine kalıtılmış ve `Text1` ya da `Accent6` olarak çözülür. Öte yandan, `SolidFillSchemeColor` hangi mantıksal tema slotunun etkili rengi ürettiğini söyler, ancak bu slotun nesneden, paragraftan, düzenden, masterdan ya da başka bir seviyeden geldiğini söylemez.

Aşağıdaki örnek bir sunumu yükler, şekil doldurmalarını ve metin bölümü doldurmalarını denetler, her bir son RGB değerini ve ilişkili şema rengini yazdırır ve tema rengi değişikliklerini takip etmeyecek katı doldurmaları işaretler:

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

`NotDefined` dalı, tema rengi slotlarındaki değişikliklere yanıt vermeyecek katı doldurmaların bir denetim listesini sağlar. Böyle nesneleri, bir sunumun yeni bir marka paletine uyması gerektiğinde gözden geçirin. Raporlanan RGB değeri hâlâ mevcut görünümü gösterirken, şema değeri bu görünümün tema ile bağlantılı olup olmadığını açıklar.

Etkili‑format nesneleri bir anlık görüntüdür. Sunum temasını, bir tema geçersiz kılmasını veya herhangi bir kalıtılan biçimlemeyi değiştirdikten sonra, renkleri karşılaştırmadan veya raporlamadan önce `GetEffective` tekrar çağrılmalı ve yeni bir `IFillFormatEffectiveData` nesnesi alınmalıdır.

## **Etkili Tema Değerlerini Okuma**

Ham tema nesneleri, belirli bir seviyede tanımlı olanı gösterir. Etkili değerler ise, kalıtım ve yerel geçersiz kılmalar çözüldükten sonra bir slayt ya da şeklin gerçekte ne kullandığını gösterir. Bir slayt için, [BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/) çağırın. Bir arka plan için [Background.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/background/geteffective/), bir doldurma için ise [FillFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/fillformat/geteffective/) kullanın.

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

Etkili verileri, render tanılama, doğrulama ve karşılaştırmalar için kullanın. Yalnızca [Presentation.MasterTheme](https://reference.aspose.com/slides/net/aspose.slides/presentation/mastertheme/) incelerseniz, master, düzen, slayt veya şekil geçersiz kılmalarının son görünümü değiştirdiği durumları kaçırabilirsiniz.

## **SSS**

**Harici bir temayı uygulamak sunumdaki tüm slaytları etkiler mi?**

Hayır. [IMasterSlide.ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/applyexternalthemetodependingslides/) yalnızca seçilen mastera bağlı slaytları yeniden atar. Diğer masterları kullanan slaytlar mevcut temalarını korur.

**Bir temayı, masterı değiştirmeden tek bir slayta uygulayabilir miyim?**

Evet. Slaytın [SlideThemeManager](https://reference.aspose.com/slides/net/aspose.slides.theme/slidethememanager/) kullanın ve geçersiz kılma temasını başlatın. Değişiklik yalnızca o slayta yerel kalır; diğer slaytlar mevcut temalarını miras almaya devam eder.

**Bir temayı bir sunumdan diğerine taşımanın en güvenli yolu nedir?**

Bir slaytı taşırken ve kaynak görünümünü korurken, kaynak masterı hedefe klonlayın ve slaytı o master ile birlikte [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection/addclone/) ve [ISlideCollection.AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/addclone/) kullanarak klonlayın. Bu, masterı, düzenleri ve temayı birlikte tutar.

**Kalıtım ve geçersiz kılmalardan sonra etkili değerleri nasıl görebilirim?**

Bir slayt ya da düzen teması için [BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/) ve format nesneleri için ilgili etkili‑veri yöntemlerini (ör. [Background.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/background/geteffective/) ve [FillFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/fillformat/geteffective/)) kullanın. Bu API'lar, kalıtım ve geçersiz kılmalar uygulandıktan sonraki çözülmüş değerleri döndürür.