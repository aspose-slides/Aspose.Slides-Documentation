---
title: Sunumlarda .NET için Yazı Tiplerini Gömme
linktitle: Gömülü Yazı Tipleri
type: docs
weight: 40
url: /tr/net/embedded-font/
keywords:
- yazı tipi ekle
- yazı tipi gömme
- yazı tipi gömme
- gömülü yazı tipi al
- gömülü yazı tipi ekle
- gömülü yazı tipi kaldır
- gömülü yazı tipini sıkıştır
- PowerPoint
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET ile PowerPoint’te gömülü yazı tiplerini yönetin. Metin görünümünü korumak ve dosya boyutunu azaltmak için C# kullanarak yazı tiplerini ekleyin, alın, kaldırın ve sıkıştırın."
---
## **Giriş**

Gömülü yazı tipleri, yazı tipi verilerini bir PowerPoint sunumu içinde depolar. Bir görüntüleyici gömülü yazı tiplerini destekliyorsa, bu tipler hedef sistemde yüklü olmasa bile metni o yazı tipleriyle gösterebilir. Bu, satır sonları, metin aralığı ve slayt düzeninin korunmasına yardımcı olur.

Aspose.Slides for .NET, bir [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) nesnesinin [FontsManager](https://reference.aspose.com/slides/net/aspose.slides/presentation/fontsmanager/) özelliği aracılığıyla gömülü yazı tiplerini almanıza, eklemenize ve kaldırmanıza olanak tanır. Ayrıca, sunumun kullanmadığı karakterleri kaldırarak gömülü yazı tipi verisinin boyutunu azaltabilirsiniz.

Aşağıdaki örnekler PPTX dosyalarıyla çalışır. Bir yazı tipini gömmeden önce, yazı tipi verisinin Aspose.Slides tarafından erişilebilir olduğundan ve lisansınızın gömmeyi izin verdiğinden emin olun.

## **Gömülü Yazı Tiplerini Al ve Kaldır**

Bir sunumda depolanmış yazı tiplerini listelemek için [GetEmbeddedFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getembeddedfonts/) yöntemini kullanın. Birini kaldırmak için, listeden bir yazı tipini [RemoveEmbeddedFont](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/removeembeddedfont/) metoduna gönderin ve ardından sunumu kaydedin.

Aşağıdaki örnek, `EmbeddedFonts.pptx` içindeki gömülü yazı tiplerini listeler ve Calibri mevcutsa kaldırır:

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

Gömülü bir yazı tipini kaldırmak, saklanan yazı tipi verisini siler; metne atanan yazı tipini değiştirmez. Yazı tipi hedef sistemde yüklüyse, metin hâlâ o yazı tipini kullanabilir. Aksi takdirde, render işlemi [font substitution](/slides/tr/net/font-substitution/) gerektirebilir ve bu da düzeni etkileyebilir.

## **Yazı Tipi Verilerini ve Gömme İzinlerini İncele**

Gömmeden önce yazı tiplerini incelemek için [IFontsManager](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/) arayüzünü kullanın. Sunumda kullanılan yazı tiplerini almak için [IFontsManager.GetFonts](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getfonts/) metodunu çağırın. Her bir yazı tipi için bir [IFontData](https://reference.aspose.com/slides/net/aspose.slides/ifontdata/) nesnesi ve gerekli [FontStyleType](https://reference.aspose.com/slides/net/aspose.slides/fontstyletype/) değerini [IFontsManager.GetFontBytes](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getfontbytes/) metoduna gönderin. Metod, ilgili yazı tipi stilinin ikili verisini döndürür; istenen yazı tipi veya stil mevcut değilse `null` döner. `null` sonucu [IFontsManager.GetFontEmbeddingLevel](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getfontembeddinglevel/) metoduna göndermeyin, çünkü bu metod bir byte dizisi bekler.

[EmbeddingLevel](https://reference.aspose.com/slides/net/aspose.slides/embeddinglevel/) yazı tipinde depolanan gömme kısıtlamalarını raporlayan bir bayrak (flags) enum’ıdır:

- `Installable` gömmeye ve başka bir sisteme kalıcı kurulum izni verir; bu, yazı tipi lisansına bağlıdır.
- `Restricted` yalnızca tek kullanım‑izin bayrağı olduğu zaman, yazı tipinin yasal sahibinden izin alınmadıkça gömme yasaktır.
- `PreviewPrint` geçici olarak görüntüleme ve yazdırma izin verir; yazıyı içeren belge salt okunur olmalıdır.
- `Editable` geçici kullanım izni verir ve belgenin düzenlenip kaydedilmesine olanak tanır.
- `NoSubsetting` ek bir kısıtlamadır; sadece bir alt küme karakterin gömülmesini yasaklar. Bu bayrak mevcutsa tüm karakterler gömülmelidir.
- `BitmapOnly` ek bir kısıtlamadır; yalnızca bitmap vuruşlarının gömülmesine izin verir, kontur (outline) verisi gömülmez. Yazı tipinin bitmap vuruşu yoksa gömülemez.

İlk dört değer kullanım iznini tanımlar, `NoSubsetting` ve `BitmapOnly` ise bunlarla birlikte kullanılabilir. Modifikatörleri bit düzeyinde işlemlerle kontrol edin. `Installable` değeri sıfır olduğundan, onu tespit etmek için `HasFlag` kullanmayın; kullanım‑izin bitlerini maskeleyip sonucu `Installable` ile karşılaştırın. Geçerli yazı tipleri en fazla bir kullanım‑izin bitine sahiptir. Daha eski yazı tiplerinde birden fazla izin biti bulunabilir; aşağıdaki yardımcı kod en az kısıtlayıcı izni seçer: önce `Editable`, ardından `PreviewPrint`, sonra `Restricted`.

Aşağıdaki örnek, `GetFonts` tarafından döndürülen her yazı tipi için normal, kalın, italik ve kalın‑italik verilerini inceler. Kullanılamayan stilleri, kısıtlı yazı tiplerini, yalnızca bitmap olanları, yalnızca ön izleme‑yazdırma izinli olanları (çıktı hâlâ düzenlenebilir olduğundan) ve zaten gömülü olanları atlar. Herhangi bir kullanılabilir stilde `NoSubsetting` bulunursa, o yazı tipi ailesi için tüm karakterler gömülür.

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

Bu inceleme, her yazı tipi dosyasında kodlanmış kısıtlamaları raporlar. Lisans vermek, yazı tipini yasal olarak temin ettiğinizi kanıtlamak ya da gömülü bir kopyayı dağıtmadan önce lisans sözleşmesini kontrol etmenizi yerine geçmez.

## **Gömülü Yazı Tiplerini Ekle**

Bir yazı tipini gömmek için [AddEmbeddedFont](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/addembeddedfont/) metodunu kullanın. Aşırı yüklemeleri, bir [IFontData](https://reference.aspose.com/slides/net/aspose.slides/ifontdata/) nesnesi ya da yazı tipi verisini içeren bir byte dizisi kabul eder. [EmbedFontCharacters](https://reference.aspose.com/slides/net/aspose.slides.export/embedfontcharacters/) enum’ı hangi karakterlerin dahil edileceğini kontrol eder:

- [All](https://reference.aspose.com/slides/net/aspose.slides.export/embedfontcharacters/) yazı tipindeki tüm karakterleri gömer. Alıcıların sunumu düzenlemesi ve yeni metin girmesi gerektiğinde bu seçeneği kullanın.
- [OnlyUsed](https://reference.aspose.com/slides/net/aspose.slides.export/embedfontcharacters/) yalnızca sunumda kullanılan karakterleri gömer, dosya boyutunu küçültür. Bu seçeneği, yalnızca görüntülenmesi amaçlanan tamamlanmış bir sunum için tercih edin.

Aşağıdaki örnek, `Fonts.pptx` içinde kullanılan yazı tiplerini [GetFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getfonts/) ile alır ve hâlen gömülmemiş olanları gömer. Eklenmek istenen yazı tiplerinin kod çalıştırılan makinede bulunması gerekir. Mevcut gömülü yazı tipleri karakter setlerini korur.

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

## **Gömülü Yazı Tiplerini Sıkıştır**

[CompressEmbeddedFonts](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compressembeddedfonts/) kullanılmayan karakterleri kaldırarak gömülü yazı tipi verisini küçültür. Bu işlem hâlihazırda gömmüş olduğunuz yazı tipleri üzerinde çalışır; bu nedenle boyut azalması, sunumda ne kadar kullanılmayan font verisi olduğuna bağlıdır.

Aşağıdaki örnek, `EmbeddedFonts.pptx` içindeki yazı tiplerini sıkıştırır ve sonucu ayrı bir dosya olarak kaydeder:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("EmbeddedFonts.pptx");
Compress.CompressEmbeddedFonts(presentation);
presentation.Save("CompressedEmbeddedFonts.pptx", SaveFormat.Pptx);
```

Alıcıların daha sonra metin eklemesi gerekebileceği durumlarda orijinal dosyayı saklayın. Sıkıştırma sırasında kaldırılan karakterler, gömülü fonttan artık kullanılamaz, hatta başlangıçta tüm karakterleri gömmüş olsanız bile.

Kayıtlı bir yazı tipinin dışa aktarım sırasında gömülü yazı tipini kaldırmadan öncelik kazanmasını istiyorsanız, [Prefer Registered Fonts over Embedded Fonts](/slides/tr/net/font-selection-sequence/#prefer-registered-fonts-over-embedded-fonts) bölümüne bakın (.NET 26.11 veya daha yeni sürümler).

## **FAQ**

**Bir gömülü yazı tipinin render sırasında hâlâ ikame (substitution) edilip edilmeyeceğini nasıl kontrol edebilirim?**

Sunumu render ettiğiniz ortamda [GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getsubstitutions/) metodunu çağırarak Aspose.Slides’in hangi yazı tiplerini değiştireceğini görebilirsiniz. Ayrıca [font substitution](/slides/tr/net/font-substitution/) ayarlarını ve [font fallback](/slides/tr/net/fallback-font/) kurallarını kontrol edin. Fallback eksik karakterleri ele alır; bu nedenle bir yazı tipini gömmek, fontun kendisinde bulunmayan karakterleri çözmez.

**Arial ve Calibri gibi yaygın yazı tiplerini gömmeliyim mi?**

Karar, hedef ortamınıza bağlıdır. Gerekli yazı tipleri sunumu açan veya render eden her makinede mevcutsa, gömmek gereksiz dosya büyüklüğüne neden olur. Alıcıların veya sunucuların bu yazı tiplerine erişimi olmayabilir; bu durumda, lisansları izin veriyorsa, gömmek istenen görünümü korumaya yardımcı olur.