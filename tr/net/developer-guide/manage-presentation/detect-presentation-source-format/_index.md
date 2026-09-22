---
title: Orijinal Sunum Formatını .NET'te Belirleme
linktitle: Kaynak Format
type: docs
weight: 35
url: /tr/net/detect-presentation-source-format/
keywords:
- kaynak format
- sunum formatını algıla
- PowerPoint
- OpenDocument
- sunum
- PPT
- PPTX
- C#
- .NET
- Aspose.Slides
description: "Aspose.Slides for .NET ile C#'ta yüklü bir sunumun orijinal formatını okuyun, algılama API'larını karşılaştırın ve dosyaları, akışları ve eski formatları yönetin."
---
## **Genel Bakış**

Bir sunumu yükledikten sonra, orijinal formatını belirlemek için yalnızca okunabilir [Presentation.SourceFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/sourceformat/) özelliğini okuyun. Bu özellik [IPresentation.SourceFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/ipresentation/sourceformat/) üzerinden de kullanılabilir. Mevcut örneğin yüklendiği format, sonraki işlemlerin buna bağlı olduğu durumlarda bunu kullanın.

Kaynak format, bir çıktı dosyası için seçilen [SaveFormat](https://reference.aspose.com/slides/tr/net/aspose.slides.export/saveformat/) formatından farklıdır. Başka bir formata kaydetmek, mevcut örneğin kaynak formatını değiştirmez.

## **Bir Dosyanın Kaynak Formatını Okuma**

Bu örnek mevcut bir `sample.pptx` dosyası gerektirir. Dosyayı yükler ve dosya adından ziyade [Presentation.SourceFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/sourceformat/) kullanarak bir uygulama işleme politikasını seçer. Diğer formatları denemek için giriş yolunu değiştirin. Örnek seçilen politikayı yazdırır; mesajları uygulama mantığınızla değiştirin.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

switch (presentation.SourceFormat)
{
    case SourceFormat.Ppt:
    case SourceFormat.Pps:
    case SourceFormat.Pot:
        Console.WriteLine("Use the legacy PowerPoint processing policy.");
        break;
    case SourceFormat.Pptx:
        Console.WriteLine("Use the standard PPTX processing policy.");
        break;
    default:
        Console.WriteLine($"Use the general policy for {presentation.SourceFormat}.");
        break;
}
```

## **Desteklenen Değerleri Tanıma**

[SourceFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/sourceformat/) enumarasyonu aşağıdaki sunum formatlarını ayırır. Aşağıdaki uzantılar geleneksel uzantılardır, orijinal dosya adının yeniden oluşturulması değildir.

| SourceFormat değeri | Uzantı | Format |
| --- | --- | --- |
| `Ppt` | `.ppt` | PowerPoint 97–2003 sunumu |
| `Pptx` | `.pptx` | Office Open XML sunumu |
| `Pptm` | `.pptm` | Makro‑destekli Office Open XML sunumu |
| `Pps` | `.pps` | PowerPoint 97–2003 slayt gösterisi |
| `Ppsx` | `.ppsx` | Office Open XML slayt gösterisi |
| `Ppsm` | `.ppsm` | Makro‑destekli Office Open XML slayt gösterisi |
| `Pot` | `.pot` | PowerPoint 97–2003 şablonu |
| `Potx` | `.potx` | Office Open XML şablonu |
| `Potm` | `.potm` | Makro‑destekli Office Open XML şablonu |
| `Odp` | `.odp` | OpenDocument sunumu |
| `Otp` | `.otp` | OpenDocument sunum şablonu |
| `Fodp` | `.fodp` | Düz XML ODF sunumu |
| `Xml` | `.xml` | PowerPoint XML sunumu |

## **Bir Akışın Kaynak Formatını Okuma**

Bu örnek mevcut bir `sample.pps` dosyası gerektirir. Baytlarını bir bellek akışına okumak, veritabanı değeri ya da yüklenen bir bayt dizisi gibi dosya adı olmadan gelen girdiyi modeller. [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) yapıcı yalnızca akışı alır.

```csharp
using System;
using System.IO;
using Aspose.Slides;

var bytes = File.ReadAllBytes("sample.pps");
using var stream = new MemoryStream(bytes);
using var presentation = new Presentation(stream);

Console.WriteLine($"Source format: {presentation.SourceFormat}");
```

PPT, PPS ve POT aynı temel ikili formata sahiptir. Dosya yolu ile yükleme yapıldığında uzantı, bir slayt gösterisi ya da şablonu ayırmaya yardımcı olabilir. Dosya adı olmadan eski PPS ve POT içeriği `SourceFormat.Ppt` olarak raporlanabilir; yukarıdaki PPS örneği `Ppt` rapor eder.

Uygulamanız ayrımı korumak zorundaysa, orijinal dosya adını veya alt tür meta verisini ayrı olarak saklayın. Bir uzantı bu eski alt türler için faydalı bir ipucu olsa da, rastgele bir sunum içeriğini tanımlamanın tek temeli olmamalıdır.

## **Yüklemeden Önce ve Sonra Algılamayı Karşılaştırma**

Bir dosyanın tam sunum nesne modelini yüklemeden önce incelemeniz gerektiğinde [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/tr/net/aspose.slides/presentationfactory/getpresentationinfo/) ve [IPresentationInfo.LoadFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/ipresentationinfo/loadformat/) kullanın. Örnek zaten var olan bir örnek olduğunda [Presentation.SourceFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/sourceformat/) kullanın.

Bu örnek `sample.pptx` gerektirir ve her iki kontrol için de `Pptx` yazdırır. Üretim ortamında işleme aşamanıza uygun API’yı seçin; zaten yüklü bir sunumun kaynak formatını elde etmek için ikinci bir inceleme gerekmez.

```csharp
using System;
using Aspose.Slides;

var path = "sample.pptx";
var information = PresentationFactory.Instance.GetPresentationInfo(path);
Console.WriteLine($"Before loading: {information.LoadFormat}");

using var presentation = new Presentation(path);
Console.WriteLine($"After loading: {presentation.SourceFormat}");
```

Sonuçlar farklı enum tiplerine sahiptir: [LoadFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/loadformat/) ve [SourceFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/sourceformat/). Sayısal değerlerini dönüştürerek karşılaştırmayın ve her formatın aynı algılama sonucuna sahip olduğunu varsaymayın. Aşağıda açıklanan kaydet‑ve‑yeniden‑aç kontrolünde PowerPoint XML, yüklemeden önce `LoadFormat.Unknown` ve yükleme sonrası `SourceFormat.Xml` olarak raporlanmıştır.

## **Kaynak ve Çıktı Formatlarını Ayrı Tutma**

Bu örnek `sample.pptx` gerektirir ve `converted.odp` yazar. Hem kaydetmeden önce hem de sonra `Pptx` yazdırır. Yalnızca ODP çıktısından yüklenen yeni örnek `Odp` rapor eder.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
Console.WriteLine($"Before saving: {presentation.SourceFormat}");

presentation.Save("converted.odp", SaveFormat.Odp);
Console.WriteLine($"After saving: {presentation.SourceFormat}");

using var reopened = new Presentation("converted.odp");
Console.WriteLine($"Reopened output: {reopened.SourceFormat}");
```

`new Presentation()` ile sıfırdan oluşturulan bir sunum `SourceFormat.Pptx` rapor eder. Giriş dosyası yoktur: bu, yeni oluşturulan bir örnek için varsayılan değerdir, bir PPTX dosyasının yüklendiğinin kanıtı değildir. Bu ayrımın önemli olduğu durumlarda uygulamanızın örneği oluşturup oluşturmadığını ayrı olarak izleyin.

## **Bir Kaynak Formatını Uzantıya Eşleme**

Aşağıdaki örnek `sample.pptx` gerektirir. Şu anda desteklenen tüm [SourceFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/sourceformat/) değerlerini, giriş dosya adını çözümlemeden geleneksel bir uzantıya eşler. Geri dönüş, tanınmayan bir değere sessizce uzantı atamaktan kaçınır.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");
var extension = presentation.SourceFormat switch
{
    SourceFormat.Ppt => ".ppt",
    SourceFormat.Pptx => ".pptx",
    SourceFormat.Pptm => ".pptm",
    SourceFormat.Pps => ".pps",
    SourceFormat.Ppsx => ".ppsx",
    SourceFormat.Ppsm => ".ppsm",
    SourceFormat.Pot => ".pot",
    SourceFormat.Potx => ".potx",
    SourceFormat.Potm => ".potm",
    SourceFormat.Odp => ".odp",
    SourceFormat.Otp => ".otp",
    SourceFormat.Fodp => ".fodp",
    SourceFormat.Xml => ".xml",
    _ => null
};

Console.WriteLine(extension ?? "No extension mapping is available.");
```

Bu eşleme bir dosyayı dönüştürmez ya da akış yüklemesi sırasında kaybolan bir eski PPS/POT alt türünü geri getirmez. Gerçek kaydetme için bir [SaveFormat](https://reference.aspose.com/slides/tr/net/aspose.slides.export/saveformat/) açıkça seçin veya [Orijinal Formatlarında Sunumları Kaydet](/slides/tr/net/save-presentation/#save-presentations-in-their-original-format) bölümünde gösterilen dönüşümü kullanın.

## **Kaydedip Yeniden Açarak Formatları Doğrulama**

Bu bağımsız örnek bir sunum oluşturur ve çalışma dizininde üç dosya yazar; aynı adlara sahip dosyalar üzerine yazar. Her çıktıyı hem yol üzerinden hem de bir bellek akışı aracılığıyla yeniden açar. PPTX ve ODP için her iki yol da kaydedilen formatı raporlar. PPS için yol üzerinden yükleme `Pps`, aynı baytlar dosya adı olmadan yüklendiğinde `Ppt` rapor eder.

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var formats = new[] { SaveFormat.Pptx, SaveFormat.Odp, SaveFormat.Pps };

foreach (var format in formats)
{
    var path = $"roundtrip.{format.ToString().ToLowerInvariant()}";
    presentation.Save(path, format);

    using var fromFile = new Presentation(path);
    var bytes = File.ReadAllBytes(path);
    using var stream = new MemoryStream(bytes);
    using var fromStream = new Presentation(stream);

    Console.WriteLine($"{format}: file={fromFile.SourceFormat}, stream={fromStream.SourceFormat}");
}
```

Yukarıda listelenen tüm formatlarla yapılan aynı kontrol, eşleşen uzantılara sahip oluşturulan sunumlar için şu sonuçları verdi:

| Kaydedilen format | Dosya yolundan SourceFormat | İsimsiz akıştan SourceFormat |
| --- | --- | --- |
| PPT | `Ppt` | `Ppt` |
| PPTX, PPTM | `Pptx`, `Pptm` sırasıyla | Dosya yoluyla aynı |
| PPS | `Pps` | `Ppt` |
| PPSX, PPSM | `Ppsx`, `Ppsm` sırasıyla | Dosya yoluyla aynı |
| POT | `Pot` | `Ppt` |
| POTX, POTM | `Potx`, `Potm` sırasıyla | Dosya yoluyla aynı |
| ODP, OTP | `Odp`, `Otp` sırasıyla | Dosya yoluyla aynı |
| FODP | `Fodp` | `Fodp` |
| PowerPoint XML | `Xml` | `Xml` |

Bu kontrolllerde tek kaynak‑format normalizasyonu, isimsiz akışlar için PPS/POT’un `Ppt` olarak raporlanmasıdır. Tablo, format tanımlamayı, dönüşüm sırasında her bir sunum özelliğinin korunmasını açıklamaz.

## **SSS**

**ODP’ye kaydetmek, PPTX’den yüklenen bir sunumun kaynak formatını değiştirir mi?**

Hayır. Mevcut örnek hâlâ `Pptx` rapor eder. Kaydedilen ODP dosyasından yüklenen örnek `Odp` rapor eder.

**Bir akış her zaman eski bir sunumu, slayt gösterisini ve şablonu ayırt edebilir mi?**

Hayır. PPT, PPS ve POT aynı ikili formatı paylaşır. Bu ayrım gerektiğinde dosya adını veya alt tür meta verisini ayrı olarak saklayın.

**Sunum zaten yüklüyse hangi API’yı kullanmalıyım?**

[Presentation.SourceFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/sourceformat/) okuyun. Yüklemeden önce inceleme için [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/tr/net/aspose.slides/presentationfactory/getpresentationinfo/) kullanın.