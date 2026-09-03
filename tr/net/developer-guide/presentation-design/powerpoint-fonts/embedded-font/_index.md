---
title: .NET'te Sunumlarda Yazı Tiplerini Gömme
linktitle: Gömülü Yazı Tipleri
type: docs
weight: 40
url: /tr/net/embedded-font/
keywords:
- yazı tipi ekle
- yazı tipi gömme
- yazı tipi gömme
- gömülü yazı tipini al
- gömülü yazı tipi ekle
- gömülü yazı tipini kaldır
- gömülü yazı tipini sıkıştır
- PowerPoint
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET ile PowerPoint'te gömülü yazı tiplerini yönetin. Metin görünümünü korumak ve dosya boyutunu azaltmak için C# kullanarak fontları ekleyin, alın, kaldırın ve sıkıştırın."
---
## **Giriş**

Yazı tiplerini gömmek, font verilerini bir PowerPoint sunumu içinde depolar. Görüntüleyici gömülü fontları desteklediğinde, bu fontlar hedef sistemde yüklü olmasa bile metni o fontlarla gösterebilir. Bu, satır sonları, metin aralığı ve slayt düzeninin korunmasına yardımcı olur.

Aspose.Slides for .NET, bir [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) nesnesinin [FontsManager](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/fontsmanager/) özelliği aracılığıyla gömülü fontları almanıza, eklemenize ve kaldırmanıza olanak tanır. Ayrıca, sunumun kullanmadığı karakterleri kaldırarak gömülü font verisinin boyutunu azaltabilirsiniz.

Aşağıdaki örnekler PPTX dosyalarıyla çalışır. Bir fontu gömmeden önce, font verisinin Aspose.Slides tarafından erişilebilir olduğundan ve lisansının gömme izni verdiğinden emin olun.

## **Gömülü Yazı Tiplerini Al ve Kaldır**

Sunumda depolanan fontları listelemek için [GetEmbeddedFonts](https://reference.aspose.com/slides/tr/net/aspose.slides/fontsmanager/getembeddedfonts/) kullanın. Birini kaldırmak için o listeden bir fontu [RemoveEmbeddedFont](https://reference.aspose.com/slides/tr/net/aspose.slides/fontsmanager/removeembeddedfont/) metoduna gönderin ve ardından sunumu kaydedin.

Aşağıdaki örnek `EmbeddedFonts.pptx` dosyasındaki gömülü fontları listeler ve Calibri mevcutsa kaldırır:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("EmbeddedFonts.pptx");
var fontsManager = presentation.FontsManager;
var embeddedFonts = fontsManager.GetEmbeddedFonts();

foreach (var font in embeddedFonts)
{
    Console.WriteLine(font.FontName);
}

var fontToRemove = Array.Find(embeddedFonts, font => string.Equals(font.FontName, "Calibri", StringComparison.OrdinalIgnoreCase));
if (fontToRemove != null)
{
    fontsManager.RemoveEmbeddedFont(fontToRemove);
    presentation.Save("WithoutEmbeddedCalibri.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("Calibri is not embedded. No output file was created.");
}
```

Bir gömülü fontu kaldırmak, depolanmış font verisini siler; metne atanmış fontu değiştirmez. Font hedef sistemde yüklüyse, metin hâlâ bu fontu kullanabilir. Aksi takdirde, render sırasında [yazı tipi ikamesi](/slides/tr/net/font-substitution/) gerekebilir ve bu da düzeni etkileyebilir.

## **Yazı Tipi Verilerini ve Gömme İzinlerini İnceleme**

Fontları gömmeden önce incelemek için [IFontsManager](https://reference.aspose.com/slides/tr/net/aspose.slides/ifontsmanager/) arayüzünü kullanın. Sunumda kullanılan fontları almak için [IFontsManager.GetFonts](https://reference.aspose.com/slides/tr/net/aspose.slides/ifontsmanager/getfonts/) metodunu çağırın. Her font için bir [IFontData](https://reference.aspose.com/slides/tr/net/aspose.slides/ifontdata/) nesnesi ve gerekli [FontStyleType](https://reference.aspose.com/slides/tr/net/aspose.slides/fontstyletype/) değeri ile [IFontsManager.GetFontBytes](https://reference.aspose.com/slides/tr/net/aspose.slides/ifontsmanager/getfontbytes/) metodunu çağırın. Metod, o font stilinin ikili verisini döndürür; istenen font veya stil mevcut değilse `null` döner. `null` sonucu [IFontsManager.GetFontEmbeddingLevel](https://reference.aspose.com/slides/tr/net/aspose.slides/ifontsmanager/getfontembeddinglevel/) metoduna göndermeyin, çünkü bu metod bir bayt dizisi bekler.

[EmbeddingLevel](https://reference.aspose.com/slides/tr/net/aspose.slides/embeddinglevel/) fontta saklanan gömme kısıtlamalarını raporlayan bir bayrak (flags) enumerasyonudur:

- `Installable` gömme ve başka bir sisteme kalıcı kurulum izni verir; font lisansına tabidir.
- `Restricted` yalnızca tek kullanım izni bayrağı olduğunda, fontun yasal sahibinden izin alınmadıkça gömülmesini yasaklar.
- `PreviewPrint` geçici olarak görüntüleme ve yazdırma izni verir; belge yalnızca okunabilir olmalıdır.
- `Editable` geçici kullanım izni verir ve belgenin düzenlenip kaydedilmesine izin tanır.
- `NoSubsetting` yalnızca bir alt küme karakterin gömülmesini yasaklayan ek bir kısıtlamadır. Bu bayrak mevcutsa tüm karakterler gömülmelidir.
- `BitmapOnly` yalnızca bitmap vuruşlarının gömülmesine izin veren ek bir kısıtlamadır; hat taslak verileri gömülemez. Font bitmap vuruşu içermiyorsa gömülemez.

İlk dört değer kullanım iznini tanımlarken, `NoSubsetting` ve `BitmapOnly` bunlarla birleştirilebilir. Bayrakları bitwise işlemlerle kontrol edin. `Installable` sıfır olduğundan, onu tespit etmek için `HasFlag` kullanmayın; kullanım‑izin bitlerini maskeleyip sonucu `Installable` ile karşılaştırın. Mevcut fontlar en fazla bir kullanım‑izin biti ayarlamalıdır. Daha eski fontların birden çok izin biti ayarladığı durumlar için aşağıdaki yardımcı, en az kısıtlayıcı izni seçer: `Editable`, ardından `PreviewPrint`, ardından `Restricted`.

Aşağıdaki örnek, `GetFonts` tarafından döndürülen her font için normal, kalın, italik ve kalın‑italik verilerini denetler. Kullanılamayan stilleri, kısıtlı fontları, yalnızca bitmap olan fontları, ön izleme ve yazdırma ile sınırlı olan (çünkü çıktı hâlâ düzenlenebilir) fontları ve zaten gömülü olan fontları atlar. Herhangi bir mevcut stil `NoSubsetting` içeriyorsa, o font ailesi için tüm karakterler gömülür.

```csharp
using System;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Export;

static EmbeddingLevel GetUsagePermission(EmbeddingLevel level)
{
    const EmbeddingLevel permissionMask = EmbeddingLevel.Restricted | EmbeddingLevel.PreviewPrint | EmbeddingLevel.Editable;
    var permissions = level & permissionMask;

    if ((permissions & EmbeddingLevel.Editable) != 0)
    {
        return EmbeddingLevel.Editable;
    }

    if ((permissions & EmbeddingLevel.PreviewPrint) != 0)
    {
        return EmbeddingLevel.PreviewPrint;
    }

    if ((permissions & EmbeddingLevel.Restricted) != 0)
    {
        return EmbeddingLevel.Restricted;
    }

    return EmbeddingLevel.Installable;
}

using var presentation = new Presentation("Fonts.pptx");
var fontsManager = presentation.FontsManager;
var fontStyles = new[]
{
    FontStyleType.Regular,
    FontStyleType.Bold,
    FontStyleType.Italic,
    FontStyleType.Bold | FontStyleType.Italic
};

var embeddedFontNames = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
foreach (var embeddedFont in fontsManager.GetEmbeddedFonts())
{
    embeddedFontNames.Add(embeddedFont.FontName);
}

var embeddingPlan = new List<(IFontData Font, EmbedFontCharacters Rule)>();
foreach (var font in fontsManager.GetFonts())
{
    if (embeddedFontNames.Contains(font.FontName))
    {
        Console.WriteLine($"{font.FontName}: already embedded.");
        continue;
    }

    var hasAvailableData = false;
    var allAvailableStylesCanBeEmbedded = true;
    var previewPrintOnly = false;
    var requiresFullFont = false;

    foreach (var fontStyle in fontStyles)
    {
        var fontBytes = fontsManager.GetFontBytes(font, fontStyle);
        if (fontBytes == null)
        {
            Console.WriteLine($"{font.FontName} ({fontStyle}): font data is unavailable.");
            continue;
        }

        hasAvailableData = true;
        var embeddingLevel = fontsManager.GetFontEmbeddingLevel(fontBytes, font.FontName);
        var usagePermission = GetUsagePermission(embeddingLevel);
        var noSubsetting = (embeddingLevel & EmbeddingLevel.NoSubsetting) != 0;
        var bitmapOnly = (embeddingLevel & EmbeddingLevel.BitmapOnly) != 0;

        requiresFullFont |= noSubsetting;
        previewPrintOnly |= usagePermission == EmbeddingLevel.PreviewPrint;
        allAvailableStylesCanBeEmbedded &= usagePermission != EmbeddingLevel.Restricted && !bitmapOnly;

        Console.WriteLine($"{font.FontName} ({fontStyle}): {embeddingLevel}.");
    }

    if (!hasAvailableData)
    {
        Console.WriteLine($"{font.FontName}: skipped because no requested style is available.");
    }
    else if (!allAvailableStylesCanBeEmbedded)
    {
        Console.WriteLine($"{font.FontName}: skipped because at least one available style does not permit outline embedding.");
    }
    else if (previewPrintOnly)
    {
        Console.WriteLine($"{font.FontName}: skipped because this example produces an editable presentation.");
    }
    else
    {
        var rule = requiresFullFont ? EmbedFontCharacters.All : EmbedFontCharacters.OnlyUsed;
        embeddingPlan.Add((font, rule));
    }
}

foreach (var item in embeddingPlan)
{
    fontsManager.AddEmbeddedFont(item.Font, item.Rule);
}

presentation.Save("WithAuditedFonts.pptx", SaveFormat.Pptx);
```

Bu denetim, her font dosyasında kodlanmış kısıtlamaları raporlar. Lisans vermez, fontu yasal olarak edindiğinizi kanıtlamaz ve gömülü bir kopya dağıtmadan önce fontun lisans anlaşmasını kontrol etmenizi gereksiz kılmaz.

## **Gömülü Yazı Tipleri Ekleme**

Bir fontu gömmek için [AddEmbeddedFont](https://reference.aspose.com/slides/tr/net/aspose.slides/fontsmanager/addembeddedfont/) metodunu kullanın. Aşırı yüklemeleri, bir [IFontData](https://reference.aspose.com/slides/tr/net/aspose.slides/ifontdata/) nesnesi ya da font verisini içeren bir bayt dizisi kabul eder. [EmbedFontCharacters](https://reference.aspose.com/slides/tr/net/aspose.slides.export/embedfontcharacters/) enumerasyonu, hangi karakterlerin dahil edileceğini kontrol eder:

- [All](https://reference.aspose.com/slides/tr/net/aspose.slides.export/embedfontcharacters/) fonttaki tüm karakterleri gömer. Alıcıların sunumu düzenlemesi ve yeni metin eklemesi gerektiğinde bu seçeneği kullanın.
- [OnlyUsed](https://reference.aspose.com/slides/tr/net/aspose.slides.export/embedfontcharacters/) sadece sunumda kullanılan karakterleri gömer; dosya boyutunu azaltır. Öncelikle sadece görüntülenmesi amaçlanan tamamlanmış bir sunum için bu seçeneği tercih edin.

Aşağıdaki örnek, `Fonts.pptx` içinde kullanılan fontları almak için [GetFonts](https://reference.aspose.com/slides/tr/net/aspose.slides/fontsmanager/getfonts/) metodunu kullanır ve hâlâ gömülmemiş olanları gömer. Eklenecek fontların kod çalıştıran makinede mevcut olması gerekir. Mevcut gömülü fontlar mevcut karakter kümelerini korur.

```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Fonts.pptx");
var fontsManager = presentation.FontsManager;
var allFonts = fontsManager.GetFonts();
var embeddedFonts = fontsManager.GetEmbeddedFonts();
var embeddedFontNames = embeddedFonts.Select(font => font.FontName);
var embeddedNames = new HashSet<string>(embeddedFontNames, StringComparer.OrdinalIgnoreCase);

foreach (var font in allFonts)
{
    if (!embeddedNames.Contains(font.FontName))
    {
        fontsManager.AddEmbeddedFont(font, EmbedFontCharacters.All);
        embeddedNames.Add(font.FontName);
    }
}

presentation.Save("WithEmbeddedFonts.pptx", SaveFormat.Pptx);
```

## **Gömülü Yazı Tiplerini Sıkıştırma**

[CompressEmbeddedFonts](https://reference.aspose.com/slides/tr/net/aspose.slides.lowcode/compress/compressembeddedfonts/) gömülü font verisini kullanılmayan karakterleri kaldırarak küçültür. Zaten gömülü fontlar üzerinde çalışır; bu nedenle boyut azalması, sunumun ne kadar kullanılmayan font verisi içerdiğine bağlıdır.

Aşağıdaki örnek `EmbeddedFonts.pptx` içindeki fontları sıkıştırır ve sonucu ayrı bir dosya olarak kaydeder:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("EmbeddedFonts.pptx");
Compress.CompressEmbeddedFonts(presentation);
presentation.Save("CompressedEmbeddedFonts.pptx", SaveFormat.Pptx);
```

Alıcıların daha sonra metin eklemesi gerekebileceği durumlarda orijinal dosyayı saklayın. Sıkıştırma sırasında kaldırılan karakterler, gömülü fonttan artık erişilemez; başlangıçta tüm karakterleri gömmüşseniz bile bu durum geçerlidir.

## **SSS**

**Gömülü bir yazı tipinin render sırasında hâlâ değiştirileceğini nasıl kontrol edebilirim?**

Render yaptığınız ortamda [GetSubstitutions](https://reference.aspose.com/slides/tr/net/aspose.slides/fontsmanager/getsubstitutions/) metodunu çağırarak Aspose.Slides'ın hangi fontları değiştireceğini görebilirsiniz. Ayrıca [yazı tipi ikamesi](/slides/tr/net/font-substitution/) ayarlarını ve [yazı tipi geri dönüşü](/slides/tr/net/fallback-font/) kurallarını kontrol edin. Geri dönüş, eksik karakterleri ele alır; bu nedenle bir fontu gömmek, fontun kendi içinde bulunmadığı karakterleri çözmez.  

**Arial ve Calibri gibi yaygın yazı tiplerini gömmeliyim mi?**

Karar, hedef ortamına dayanmalıdır. Gerekli fontlar, sunumu açan veya render eden her makinede mevcutsa, gömmek gereksiz dosya boyutu ekleyebilir. Alıcıların veya sunucuların bu fontları bulundurma ihtimali düşükse, lisansları izin veriyorsa gömmek istenen görünümü korumaya yardımcı olur.