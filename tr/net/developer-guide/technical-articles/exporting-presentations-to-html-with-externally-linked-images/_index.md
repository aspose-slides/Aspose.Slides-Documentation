---
title: Dış Bağlantılı Görsellerle Sunumları HTML'ye Dışa Aktarma
type: docs
weight: 100
url: /tr/net/exporting-presentations-to-html-with-externally-linked-images/
keywords:
  - "PowerPoint'i dışa aktar"
  - "OpenDocument'i dışa aktar"
  - "sunumu dışa aktar"
  - "slaytı dışa aktar"
  - "PPT'yi dışa aktar"
  - "PPTX'i dışa aktar"
  - "ODP'yi dışa aktar"
  - "PowerPoint'ten HTML'ye"
  - "OpenDocument'ten HTML'ye"
  - "sunumdan HTML'ye"
  - "slayttan HTML'ye"
  - "PPT'den HTML'ye"
  - "PPTX'ten HTML'ye"
  - "ODP'den HTML'ye"
  - "bağlanmış görsel"
  - "dış bağlantılı görsel"
  - "bağlanmış kaynak"
  - "dış kaynak"
  - ".NET"
  - "C#"
  - "Aspose.Slides"
description: ".NET'te Aspose.Slides kullanarak PowerPoint ve OpenDocument sunumlarını HTML'ye dışa aktarın; görseller ve diğer kaynaklar dış bağlantılı dosyalar olarak kaydedilir."
---
## **Genel Bakış**

Varsayılan olarak, Aspose.Slides bir sunumu tek bir HTML dosyasına dışa aktarır. Görseller ve diğer kaynaklar doğrudan HTML içine, genellikle Base64 veri olarak yazılır. Tek bir taşınabilir dosyaya ihtiyacınız olduğunda bu kullanışlıdır, ancak bir web sitesi, bir CMS ya da sunucu tarafı dönüşüm hattı için her zaman en iyi format değildir.

Harici bağlantılı kaynakları şu durumlarda kullanın:

- HTML belgesinin boyutunu azaltmak;
- görselleri, fontları, sesleri veya videoları tarayıcıda ya da CDN'de ayrı olarak önbelleğe almak;
- dışa aktarma sonrası oluşturulan kaynakları incelemek, değiştirmek, sıkıştırmak veya son işleme tabi tutmak;
- çıktı yapısını, bir web uygulamasının beklediğine daha yakın tutmak.

Genel HTML dönüşüm iş akışı için, [PowerPoint Sunumlarını HTML'ye Dönüştürme](/slides/tr/net/convert-powerpoint-to-html/) sayfasına bakın. Bu makale, dışa aktarmanın kaynak bağlama bölümüne odaklanır.

## **Bağlantılı Kaynak Dışa Aktarımı Nasıl Çalışır**

[ILinkEmbedController](https://reference.aspose.com/slides/tr/net/aspose.slides.export/ilinkembedcontroller/) uygulamanıza, kaynak bazında, dışa aktarıcının veriyi HTML içinde yerleştirip yerleştirmeyeceğine ya da dışarı kaydedip bir bağlantı yazacağına karar vermesini sağlar.

Arayüzün üç yöntemi vardır:

- [ILinkEmbedController.GetObjectStoringLocation](https://reference.aspose.com/slides/tr/net/aspose.slides.export/ilinkembedcontroller/getobjectstoringlocation/) bir kaynağın bağlantı mı yoksa gömülü mi olacağına karar verir.
- [ILinkEmbedController.GetUrl](https://reference.aspose.com/slides/tr/net/aspose.slides.export/ilinkembedcontroller/geturl/) oluşturulan HTML'e ya da başka bir bağlantılı kaynağa yazılacak URL'i döndürür.
- [ILinkEmbedController.SaveExternal](https://reference.aspose.com/slides/tr/net/aspose.slides.export/ilinkembedcontroller/saveexternal/) bağlantılı kaynak verisini diske ya da başka bir depolama hedefine yazar.

Dosya sistemi yolu ve tarayıcı URL'i ayrı konulardır. Örneğin, aşağıdaki örnek kaynak dosyalarını diskte `html-output/assets` konumuna yazar, HTML ise `assets/resource-1.svg` gibi göreli URL'ler içerir. Bir tarayıcı bu URL'leri bağlantıyı içeren dosyaya göre çözer. Bu nedenle, `presentation.html` dosyasından bir SVG dosyasına bağlantı `assets/resource-1.svg` kullanırken, aynı `assets` klasöründe kaydedilen bir görsele referans veren SVG dosyası `resource-4.jpg` adresini kullanır.

## **Bağlantılı Kaynaklarla HTML Dışa Aktarma**

Aşağıdaki C# örneği bir çıktı dizini oluşturur, HTML dosyasını oraya kaydeder ve bağlantılı kaynakları `assets` alt dizininde saklar. Kontrolcü, Aspose.Slides güvenli bir dosya uzantısı sağladığında veya çıkarabildiğinde yaygın görüntü, font, ses, video ve CSS kaynaklarını bağlar. Tanınmayan kaynaklar gömülü kalır.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using System;
using System.Collections.Generic;
using System.IO;

var inputFilePath = "presentation.pptx";
var outputDirectory = "html-output";
var assetDirectoryName = "assets";
var assetDirectory = Path.Combine(outputDirectory, assetDirectoryName);

Directory.CreateDirectory(outputDirectory);
Directory.CreateDirectory(assetDirectory);

var assetUrlPrefix = assetDirectoryName + "/";
var controller = new ExternalResourceController(assetDirectory, assetUrlPrefix);
var svgOptions = new SVGOptions(controller);
var slideImageFormat = SlideImageFormat.Svg(svgOptions);

var htmlOptions = new HtmlOptions(controller)
{
    HtmlFormatter = HtmlFormatter.CreateDocumentFormatter(string.Empty, false),
    SlideImageFormat = slideImageFormat
};

using var presentation = new Presentation(inputFilePath);

var htmlFilePath = Path.Combine(outputDirectory, "presentation.html");
presentation.Save(htmlFilePath, SaveFormat.Html, htmlOptions);

public sealed class ExternalResourceController : ILinkEmbedController
{
    private static readonly Dictionary<string, string> ExtensionsByContentType = new(StringComparer.OrdinalIgnoreCase)
    {
        ["image/jpeg"] = ".jpg",
        ["image/png"] = ".png",
        ["image/gif"] = ".gif",
        ["image/bmp"] = ".bmp",
        ["image/svg+xml"] = ".svg",
        ["image/tiff"] = ".tiff",
        ["image/x-emf"] = ".emf",
        ["image/x-wmf"] = ".wmf",
        ["font/woff"] = ".woff",
        ["font/woff2"] = ".woff2",
        ["font/ttf"] = ".ttf",
        ["application/font-woff"] = ".woff",
        ["application/vnd.ms-fontobject"] = ".eot",
        ["application/x-font-ttf"] = ".ttf",
        ["text/css"] = ".css",
        ["audio/mpeg"] = ".mp3",
        ["audio/mp4"] = ".m4a",
        ["audio/wav"] = ".wav",
        ["video/mp4"] = ".mp4",
        ["video/webm"] = ".webm"
    };

    private readonly string assetDirectory;
    private readonly string assetUrlPrefix;
    private readonly Dictionary<int, string> fileNamesByResourceId = new();

    public ExternalResourceController(string assetDirectory, string assetUrlPrefix)
    {
        if (string.IsNullOrWhiteSpace(assetDirectory))
        {
            throw new ArgumentException("The asset output directory must not be empty.", nameof(assetDirectory));
        }

        this.assetDirectory = assetDirectory;
        this.assetUrlPrefix = NormalizeUrlPrefix(assetUrlPrefix);
    }

    public LinkEmbedDecision GetObjectStoringLocation(
        int resourceId,
        byte[] entityData,
        string semanticName,
        string contentType,
        string recommendedExtension)
    {
        var extension = ResolveExtension(contentType, recommendedExtension);
        if (extension == null)
        {
            return LinkEmbedDecision.Embed;
        }

        fileNamesByResourceId[resourceId] = $"resource-{resourceId}{extension}";
        return LinkEmbedDecision.Link;
    }

    public string GetUrl(int resourceId, int referrer)
    {
        if (!fileNamesByResourceId.TryGetValue(resourceId, out var fileName))
        {
            return null;
        }

        if (fileNamesByResourceId.ContainsKey(referrer))
        {
            return fileName;
        }

        return assetUrlPrefix + fileName;
    }

    public void SaveExternal(int resourceId, byte[] entityData)
    {
        if (!fileNamesByResourceId.TryGetValue(resourceId, out var fileName))
        {
            throw new InvalidOperationException(
                $"Resource {resourceId} was not registered for external storage.");
        }

        if (entityData == null || entityData.Length == 0)
        {
            throw new InvalidOperationException(
                $"Resource {resourceId} contains no data and cannot be saved.");
        }

        Directory.CreateDirectory(assetDirectory);

        var filePath = Path.Combine(assetDirectory, fileName);
        File.WriteAllBytes(filePath, entityData);
    }

    private static string ResolveExtension(string contentType, string recommendedExtension)
    {
        if (!string.IsNullOrWhiteSpace(contentType) &&
            ExtensionsByContentType.TryGetValue(contentType, out var mappedExtension))
        {
            return mappedExtension;
        }

        if (!IsSupportedContentType(contentType))
        {
            return null;
        }

        return NormalizeExtension(recommendedExtension);
    }

    private static bool IsSupportedContentType(string contentType)
    {
        return contentType != null &&
            (contentType.StartsWith("image/", StringComparison.OrdinalIgnoreCase) ||
             contentType.StartsWith("font/", StringComparison.OrdinalIgnoreCase) ||
             contentType.StartsWith("audio/", StringComparison.OrdinalIgnoreCase) ||
             contentType.StartsWith("video/", StringComparison.OrdinalIgnoreCase));
    }

    private static string NormalizeExtension(string extension)
    {
        if (string.IsNullOrWhiteSpace(extension))
        {
            return null;
        }

        var extensionCharacters = extension.Trim().TrimStart('.');
        foreach (var character in extensionCharacters)
        {
            if (!char.IsLetterOrDigit(character))
            {
                return null;
            }
        }

        return "." + extensionCharacters.ToLowerInvariant();
    }

    private static string NormalizeUrlPrefix(string urlPrefix)
    {
        if (string.IsNullOrEmpty(urlPrefix))
        {
            return string.Empty;
        }

        var normalizedUrlPrefix = urlPrefix.Replace('\\', '/');
        return normalizedUrlPrefix.EndsWith("/")
            ? normalizedUrlPrefix
            : normalizedUrlPrefix + "/";
    }
}
```

Dışa aktarmadan sonra, çıktı klasörünün yapısı şu şekildedir:

```text
html-output/
  presentation.html
  assets/
    resource-1.svg
    resource-2.svg
    resource-3.svg
    resource-4.jpg
    resource-5.png
```

Tam dosyalar, sunum içeriğine ve dışa aktarma seçeneklerine bağlıdır. Örneğin, raster görseller genellikle JPEG veya PNG olarak dışa aktarılır. Aspose.Slides, daha küçük veya daha uygun bir dosya üretildiğinde kaynak sunumda kullanılandan farklı bir görüntü codec'i seçebilir. Şeffaflık içeren görseller PNG olarak dışa aktarılır.

## **Dağıtım İçin URL'leri Seçme**

Örnek, göreli bir URL öneki kullanır: `assets/`. `presentation.html` dosyası `html-output/presentation.html` konumundan açıldığında tarayıcı `html-output/assets/resource-1.svg` dosyasını yükler.

Bir bağlantılı kaynak başka bir bağlantılı kaynağa başvurduğunda, örnek [ILinkEmbedController.GetUrl](https://reference.aspose.com/slides/tr/net/aspose.slides.export/ilinkembedcontroller/geturl/) içinde `referrer` parametresini kullanır ve yalnızca dosya adını döndürür. Örneğin, `resource-1.svg` ve `resource-4.jpg` aynı `assets` klasöründeyse, SVG dosyası `resource-4.jpg` adresine, `assets/resource-4.jpg` yerine, başvurmalıdır.

Dosyalar farklı bir konuma dağıtıldığında farklı bir URL öneki kullanın:

- Varlık dizini HTML dosyasının yanında olduğunda `assets/` kullanın.
- Varlık dizini HTML dosyasının bir seviye üstünde olduğunda `../assets/` kullanın.
- Dosyalar bir CDN'ye veya statik dosya sunucusuna yüklendiğinde `https://cdn.example.com/presentations/job-123/assets/` kullanın.

[ILinkEmbedController.GetUrl](https://reference.aspose.com/slides/tr/net/aspose.slides.export/ilinkembedcontroller/geturl/) tarafından döndürülen URL, [ILinkEmbedController.SaveExternal](https://reference.aspose.com/slides/tr/net/aspose.slides.export/ilinkembedcontroller/saveexternal/) tarafından yazılan dosyanın nihai dağıtım konumuyla eşleşmelidir. Sunucu uygulamalarında, bir dışa aktarma diğerinin kaynaklarını üzerine yazmasını önlemek için her dönüşüm işi için benzersiz bir çıktı dizini veya nesne‑depolama öneki kullanın.

## **Ne Zaman Yerleştirilir**

Gömülü Base64 HTML, çıktının tek bir dosya olması gerektiğinde hâlâ yararlıdır; örneğin bir e‑posta eki, çevrim dışı ön izleme veya destekleyici bir varlık klasörü olmadan taşınacak bir belge. Bağlantılı kaynaklar, HTML bir web uygulaması tarafından sunulacaksa, bir CMS'de saklanacaksa, bir derleme hattı tarafından optimize edilecekse veya tarayıcılar tarafından HTML'den bağımsız olarak önbelleğe alınacaksa daha uygun bir çözümdür.

## **FAQ**

**Sadece görselleri dışa aktarabilir ve diğer kaynakları yerleştirilmiş tutabilir miyim?**

Evet. [ILinkEmbedController.GetObjectStoringLocation](https://reference.aspose.com/slides/tr/net/aspose.slides.export/ilinkembedcontroller/getobjectstoringlocation/) içinde yalnızca ayrı dosya olarak kaydetmek istediğiniz içerik türleri için `LinkEmbedDecision.Link` ve diğerleri için `LinkEmbedDecision.Embed` döndürün.

**Neden dışa aktarılan görselin uzantısı kaynak sunumdan farklı?**

Aspose.Slides, HTML dışa aktarımı sırasında raster görselleri boyutu iyileştirmek veya tarayıcı uyumluluğunu artırmak için yeniden kodlayabilir. Örneğin, kaynak dosyadaki bir görsel, render sonucuna bağlı olarak JPEG veya PNG olarak yazılabilir.

**HTML dosyasını taşıdıktan sonra göreli URL'ler çalışır mı?**

Göreli URL'ler yalnızca aynı göreli klasör yapısı korunduğunda çalışır. HTML `assets/resource-1.png` adresine başvuruyorsa, `assets` klasörü HTML dosyasının yanına kalmalıdır; aksi takdirde farklı bir URL öneki oluşturmanız gerekir.

**Sunucu uygulamaları aynı çıktı klasörünü yeniden kullanmalı mı?**

Hayır. Her dönüşüm işi için benzersiz bir çıktı dizini veya depolama öneki kullanın. Bu, dosya adı çakışmalarını önler ve bir dışa aktarmanın diğerinin ürettiği kaynakları üzerine yazmasını engeller.