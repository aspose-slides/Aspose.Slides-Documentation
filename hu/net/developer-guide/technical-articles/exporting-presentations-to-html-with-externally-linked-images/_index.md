---
title: Prezentációk exportálása HTML-be külsőleg hivatkozott képekkel
type: docs
weight: 100
url: /hu/net/exporting-presentations-to-html-with-externally-linked-images/
keywords:
- PowerPoint exportálása
- OpenDocument exportálása
- prezentáció exportálása
- dia exportálása
- PPT exportálása
- PPTX exportálása
- ODP exportálása
- PowerPoint HTML-re
- OpenDocument HTML-re
- prezentáció HTML-re
- dia HTML-re
- PPT HTML-re
- PPTX HTML-re
- ODP HTML-re
- hivatkozott kép
- külsőleg hivatkozott kép
- hivatkozott erőforrás
- külső erőforrás
- .NET
- C#
- Aspose.Slides
description: "PowerPoint és OpenDocument prezentációk exportálása HTML-be .NET környezetben az Aspose.Slides segítségével, a képek és egyéb erőforrások külsőleg hivatkozott fájlokként mentésével."
---
## **Áttekintés**

Alapértelmezés szerint az Aspose.Slides egy prezentációt önálló HTML fájlba exportál. A képek és egyéb erőforrások közvetlenül a HTML-be íródnak, általában Base64 adatokként. Ez akkor kényelmes, amikor egy hordozható fájlra van szükség, de nem mindig a legjobb formátum weboldal, CMS vagy kiszolgálóoldali konverziós folyamat esetén.

Külsőleg hivatkozott erőforrásokat akkor használjon, ha:

- csökkenteni szeretné a HTML dokumentum méretét;
- a képeket, betűtípusokat, hangot vagy videót külön szeretné cache‑elni a böngészőben vagy CDN‑ben;
- az export után ellenőrizni, cserélni, tömöríteni vagy utófeldolgozni szeretné a generált erőforrásokat;
- a kimeneti struktúrát közelebb szeretné hozni ahhoz, amit egy webalkalmazás elvár.

Az általános HTML konverziós munkafolyamatért lásd a [Convert PowerPoint Presentations to HTML](/slides/hu/net/convert-powerpoint-to-html/) cikket. Ez a cikk az export erőforrás‑hivatkozási részére fókuszál.

## **Hogyan működik a hivatkozott erőforrás exportálása**

[ILinkEmbedController](https://reference.aspose.com/slides/hu/net/aspose.slides.export/ilinkembedcontroller/) lehetővé teszi az alkalmazás számára, hogy erőforrásonként eldöntse, a exportáló beágyazza‑e az adatot a HTML‑be, vagy külsőleg menti és hivatkozást ír.

Az interfésznek három metódusa van:

- [ILinkEmbedController.GetObjectStoringLocation](https://reference.aspose.com/slides/hu/net/aspose.slides.export/ilinkembedcontroller/getobjectstoringlocation/) határozza meg, hogy egy erőforrást hivatkozni vagy beágyazni kell‑e.
- [ILinkEmbedController.GetUrl](https://reference.aspose.com/slides/hu/net/aspose.slides.export/ilinkembedcontroller/geturl/) adja vissza az URL‑t, amelyet a generált HTML‑be vagy egy másik hivatkozott erőforrásba ír.
- [ILinkEmbedController.SaveExternal](https://reference.aspose.com/slides/hu/net/aspose.slides.export/ilinkembedcontroller/saveexternal/) írja a hivatkozott erőforrás adatát lemezre vagy más tárolóhelyre.

A fájlrendszer‑útvonal és a böngésző URL‑je külön kérdés. Például az alábbi minta a `html-output/assets` könyvtárba írja az erőforrás‑fájlokat, míg a HTML relatív URL‑ket tartalmaz, mint például `assets/resource-1.svg`. A böngésző ezeket az URL‑ket a hivatkozást tartalmazó fájlhoz képest oldja fel. Így a `presentation.html` fájlból egy SVG fájlra mutató hivatkozás `assets/resource-1.svg`, míg az SVG‑ből egy ugyanabban az `assets` mappában lévő képhez mutató hivatkozás `resource-4.jpg`.

## **HTML exportálása hivatkozott erőforrásokkal**

Az alábbi C# példa létrehoz egy kimeneti könyvtárat, elmenti a HTML‑t oda, és a hivatkozott erőforrásokat egy `assets` alkönyvtárba helyezi. A vezérlő a gyakori kép, betűtípus, hang, videó és CSS erőforrásokra hivatkozást hoz létre, ha az Aspose.Slides biztosít vagy képes biztonságos fájlkiterjesztést kikövetkeztetni. Az ismeretlen erőforrások beágyazottak maradnak.

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

Az export után a kimeneti mappa a következő struktúrával rendelkezik:

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

A pontos fájlok a prezentáció tartalmától és az export beállításaitól függnek. Például a raszteres képek gyakran JPEG‑ként vagy PNG‑ként kerülnek exportálásra. Az Aspose.Slides egy másik kép‑kodeket választhat a forrás‑prezentációban használt helyett, ha ez kisebb vagy alkalmasabb fájlt eredményez. Az átlátszóságot tartalmazó képek PNG‑ként kerülnek exportálásra.

## **URL‑k kiválasztása a telepítéshez**

A minta egy relatív URL előtagot használ: `assets/`. Ha a `presentation.html` a `html-output/presentation.html` helyről nyílik meg, a böngésző a `html-output/assets/resource-1.svg`‑t tölti be.

Amikor egy hivatkozott erőforrás egy másikra mutat, a minta a `referrer` paramétert használja a [ILinkEmbedController.GetUrl](https://reference.aspose.com/slides/hu/net/aspose.slides.export/ilinkembedcontroller/geturl/) metódusban, és csak a fájlnevet adja vissza. Például, ha a `resource-1.svg` és a `resource-4.jpg` is az `assets` mappában van, az SVG‑nek `resource-4.jpg`‑ra kell hivatkoznia, nem pedig `assets/resource-4.jpg`‑ra.

Használjon más URL előtagot, ha a fájlok máshol vannak telepítve:

- `assets/` használata, ha az eszközkönyvtár a HTML fájl mellett található.
- `../assets/` használata, ha az eszközkönyvtár egy szinttel a HTML fájl felett helyezkedik el.
- `https://cdn.example.com/presentations/job-123/assets/` használata, ha a fájlok CDN‑re vagy statikus fájlszerverre vannak feltöltve.

Az [ILinkEmbedController.GetUrl](https://reference.aspose.com/slides/hu/net/aspose.slides.export/ilinkembedcontroller/geturl/) által visszaadott URL‑nek meg kell egyeznie a [ILinkEmbedController.SaveExternal](https://reference.aspose.com/slides/hu/net/aspose.slides.export/ilinkembedcontroller/saveexternal/) által lemezre írt fájl végleges telepítési helyével. Szerveralkalmazásoknál használjon egyedi kimeneti könyvtárat vagy objektumtároló előtagot minden konverziós feladathoz, hogy elkerülje a fájlök egymás felülírását.

## **Mikor érdemes beágyazni helyette**

A beágyazott Base64 HTML még mindig hasznos, ha a kimenetnek egyetlen fájlnak kell lennie, például e‑mail melléklet, offline előnézet vagy olyan dokumentum esetén, amelyet egy támogatott eszközkönyvtár nélkül mozgatnak. A hivatkozott erőforrások jobban illeszkednek, ha a HTML‑t webalkalmazás szolgálja ki, egy CMS‑ben tárolják, egy build csővezeték optimalizálja, vagy a böngészők önállóan cache‑elik a HTML‑től.

## **GYIK**

**Kizárólag a képeket szeretném külsőleg tárolni, a többi erőforrást beágyazottan?**

Igen. A [ILinkEmbedController.GetObjectStoringLocation](https://reference.aspose.com/slides/hu/net/aspose.slides.export/ilinkembedcontroller/getobjectstoringlocation/) metódusban csak a kívánt tartalomtípusoknál adjon vissza `LinkEmbedDecision.Link`‑et, minden máshoz pedig `LinkEmbedDecision.Embed`‑et.

**Miért tér el az exportált kép kiterjesztése a forrás‑prezentációétól?**

Az Aspose.Slides a HTML export során újrakódolhatja a raszteres képeket a méret vagy a böngésző‑kompatibilitás javítása érdekében. Például a forrásfájl egy képe JPEG‑ként vagy PNG‑ként íródhat, a megjelenített eredménytől függően.

**Működnek a relatív URL‑k, ha áthelyezem a HTML fájlt?**

A relatív URL‑k csak akkor működnek, ha a relatív mappastruktúra megmarad. Ha a HTML a `assets/resource-1.png`‑re hivatkozik, az `assets` mappának a HTML fájl mellett kell maradnia, hacsak nem generál más URL előtagot.

**A szerveralkalmazások újrahasználhatják ugyanazt a kimeneti mappát?**

Nem. Használjon egyedi kimeneti könyvtárat vagy tároló előtagot minden konverziós feladathoz. Így elkerülhető a fájlnevek ütközése és az egyik export általa generált erőforrások felülírása.