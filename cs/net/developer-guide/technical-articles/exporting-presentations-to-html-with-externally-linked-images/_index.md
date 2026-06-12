---
title: Export prezentací do HTML s externě propojenými obrázky
type: docs
weight: 100
url: /cs/net/exporting-presentations-to-html-with-externally-linked-images/
keywords:
- export PowerPointu
- export OpenDocumentu
- export prezentace
- export snímku
- export PPT
- export PPTX
- export ODP
- PowerPoint do HTML
- OpenDocument do HTML
- prezentace do HTML
- snímek do HTML
- PPT do HTML
- PPTX do HTML
- ODP do HTML
- propojený obrázek
- externě propojený obrázek
- propojený prostředek
- externí prostředek
- .NET
- C#
- Aspose.Slides
description: "Exportujte prezentace PowerPoint a OpenDocument do HTML v .NET pomocí Aspose.Slides s obrázky a dalšími prostředky uloženými jako externě propojené soubory."
---
## **Přehled**

Ve výchozím nastavení Aspose.Slides exportuje prezentaci do samostatného HTML souboru. Obrázky a další prostředky jsou zapisovány přímo do HTML, obvykle jako data Base64. To je vhodné, když potřebujete jeden přenosný soubor, ale není to vždy nejlepší formát pro webové stránky, CMS nebo serverový konverzní pipeline.

Použijte externě propojené prostředky, když chcete:

- zmenšit velikost HTML dokumentu;
- kešovat obrázky, fonty, audio nebo video samostatně v prohlížeči nebo CDN;
- zkontrolovat, nahradit, komprimovat nebo následně zpracovat vygenerované prostředky po exportu;
- udržet strukturu výstupu blíže tomu, co očekává webová aplikace.

Pro obecný postup konverze HTML si prohlédněte [Převod prezentací PowerPoint do HTML](/slides/cs/net/convert-powerpoint-to-html/). Tento článek se zaměřuje na část exportu týkající se propojení prostředků.

## **Jak funguje export s propojenými prostředky**

[ILinkEmbedController](https://reference.aspose.com/slides/cs/net/aspose.slides.export/ilinkembedcontroller/) umožňuje vaší aplikaci rozhodovat, prostředek po prostředku, zda exportér vloží data do HTML nebo je uloží externě a zapíše odkaz.

Rozhraní má tři metody:

- [ILinkEmbedController.GetObjectStoringLocation](https://reference.aspose.com/slides/cs/net/aspose.slides.export/ilinkembedcontroller/getobjectstoringlocation/) rozhoduje, zda by měl být prostředek propojen nebo vložen.
- [ILinkEmbedController.GetUrl](https://reference.aspose.com/slides/cs/net/aspose.slides.export/ilinkembedcontroller/geturl/) vrací URL, která bude zapsána do vygenerovaného HTML nebo do dalšího propojeného prostředku.
- [ILinkEmbedController.SaveExternal](https://reference.aspose.com/slides/cs/net/aspose.slides.export/ilinkembedcontroller/saveexternal/) zapisuje data propojeného prostředku na disk nebo do jiného úložného cíle.

Cesta v souborovém systému a URL v prohlížeči jsou oddělené záležitosti. Například níže uvedený příklad zapisuje soubory prostředků na disk do `html-output/assets`, zatímco HTML obsahuje relativní URL jako `assets/resource-1.svg`. Prohlížeč rozřeší tyto URL relativně k souboru, který odkaz obsahuje. Proto odkaz z `presentation.html` na SVG soubor používá `assets/resource-1.svg`, zatímco odkaz z tohoto SVG souboru na obrázek uložený ve stejné složce `assets` používá `resource-4.jpg`.

## **Export HTML s propojenými prostředky**

Následující příklad v C# vytvoří výstupní adresář, uloží tam HTML soubor a uloží propojené prostředky do podadresáře `assets`. Kontroler propojí běžné obrázkové, fontové, audio, video a CSS prostředky, pokud Aspose.Slides poskytne nebo může odvodit bezpečnou příponu souboru. Prostředky, které nejsou rozpoznány, zůstávají vložené.

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

Po exportu má výstupní složka tuto strukturu:

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

Přesné soubory závisí na obsahu prezentace a volbách exportu. Například rastrové obrázky jsou běžně exportovány jako JPEG nebo PNG. Aspose.Slides může zvolit jiný obrázkový kodek než je použitý ve zdrojové prezentaci, pokud to vede k menšímu nebo vhodnějšímu souboru. Obrázky s průhledností jsou exportovány jako PNG.

## **Volba URL pro nasazení**

Ukázka používá relativní předponu URL: `assets/`. Pokud je `presentation.html` otevřeno z `html-output/presentation.html`, prohlížeč načte `html-output/assets/resource-1.svg`.

Když jeden propojený prostředek odkazuje na jiný propojený prostředek, ukázka používá parametr `referrer` v [ILinkEmbedController.GetUrl](https://reference.aspose.com/slides/cs/net/aspose.slides.export/ilinkembedcontroller/geturl/) a vrací pouze název souboru. Například pokud jsou `resource-1.svg` a `resource-4.jpg` oba ve složce `assets`, SVG soubor by měl odkazovat na `resource-4.jpg`, nikoli na `assets/resource-4.jpg`.

Použijte jinou předponu URL, když jsou soubory nasazeny jinde:

- Použijte `assets/`, když je adresář s prostředky vedle HTML souboru.
- Použijte `../assets/`, když je adresář s prostředky o úroveň výše než HTML soubor.
- Použijte `https://cdn.example.com/presentations/job-123/assets/`, když jsou soubory nahrány na CDN nebo statický souborový server.

URL vrácená metodou [ILinkEmbedController.GetUrl](https://reference.aspose.com/slides/cs/net/aspose.slides.export/ilinkembedcontroller/geturl/) musí odpovídat konečnému nasazenému umístění souboru, který je zapsán metodou [ILinkEmbedController.SaveExternal](https://reference.aspose.com/slides/cs/net/aspose.slides.export/ilinkembedcontroller/saveexternal/). V serverových aplikacích použijte jedinečný výstupní adresář nebo předponu objektového úložiště pro každou konverzní úlohu, aby nedocházelo k přepisování souborů z jiného exportu.

## **Kdy místo toho vložit**

Vložené Base64 HTML je stále užitečné, když výstup musí být jeden soubor, například příloha e‑mailu, offline náhled nebo dokument, který bude přesunut bez doprovodné složky s prostředky. Propojené prostředky jsou vhodnější, když bude HTML poskytováno webovou aplikací, uloženo v CMS, optimalizováno buildovacím pipeline nebo kešováno prohlížeči samostatně od HTML.

## **FAQ**

**Mohu externalizovat jen obrázky a ostatní prostředky nechat vložené?**

Ano. V [ILinkEmbedController.GetObjectStoringLocation](https://reference.aspose.com/slides/cs/net/aspose.slides.export/ilinkembedcontroller/getobjectstoringlocation/) vraťte `LinkEmbedDecision.Link` pouze pro typy obsahu, které chcete uložit jako samostatné soubory, a vraťte `LinkEmbedDecision.Embed` pro vše ostatní.

**Proč se přípona exportovaného obrázku liší od původní prezentace?**

Aspose.Slides může během HTML exportu znovu kódovat rastrové obrázky, aby zlepšil velikost nebo kompatibilitu s prohlížeči. Například obrázek ze zdrojového souboru může být zapsán jako JPEG nebo PNG podle výsledku vykreslení.

**Fungují relativní URL po přesunutí HTML souboru?**

Relativní URL fungují pouze tehdy, když je zachována stejná relativní struktura složek. Pokud HTML odkazuje na `assets/resource-1.png`, složka `assets` musí zůstat vedle HTML souboru, pokud nevytvoříte jinou předponu URL.

**Mají serverové aplikace používat stejnou výstupní složku?**

Ne. Používejte jedinečný výstupní adresář nebo předponu úložiště pro každou konverzní úlohu. To zabraňuje kolizím názvů souborů a zabraňuje, aby jeden export přepsal prostředky vygenerované jiným exportem.