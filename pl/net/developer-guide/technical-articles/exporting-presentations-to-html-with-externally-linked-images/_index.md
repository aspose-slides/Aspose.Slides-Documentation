---
title: Eksportowanie prezentacji do HTML z zewnętrznie linkowanymi obrazami
type: docs
weight: 100
url: /pl/net/exporting-presentations-to-html-with-externally-linked-images/
keywords:
- eksport PowerPoint
- eksport OpenDocument
- eksport prezentacji
- eksport slajdu
- eksport PPT
- eksport PPTX
- eksport ODP
- PowerPoint do HTML
- OpenDocument do HTML
- prezentacja do HTML
- slajd do HTML
- PPT do HTML
- PPTX do HTML
- ODP do HTML
- linkowany obraz
- zewnętrznie linkowany obraz
- linkowany zasób
- zewnętrzny zasób
- .NET
- C#
- Aspose.Slides
description: "Eksportuj prezentacje PowerPoint i OpenDocument do HTML w .NET przy użyciu Aspose.Slides, zapisując obrazy i inne zasoby jako zewnętrznie linkowane pliki."
---
## **Przegląd**

Domyślnie Aspose.Slides eksportuje prezentację do samodzielnego pliku HTML. Obrazy i inne zasoby są zapisywane bezpośrednio w HTML, zwykle jako dane Base64. Jest to wygodne, gdy potrzebny jest jeden przenośny plik, ale nie zawsze jest to najlepszy format dla witryny internetowej, systemu CMS lub serwerowego potoku konwersji.

Używaj zasobów linkowanych zewnętrznie, gdy chcesz:
- zmniejszyć rozmiar dokumentu HTML;
- pamiętać obrazy, czcionki, dźwięki lub wideo osobno w przeglądarce lub CDN;
- przeglądać, zamieniać, kompresować lub przetwarzać po wyeksportowaniu generowane zasoby;
- utrzymać strukturę wyjściową bliższą temu, czego oczekuje aplikacja internetowa.

Aby zobaczyć ogólny przepływ konwersji HTML, zobacz [Konwertuj prezentacje PowerPoint do HTML](/slides/pl/net/convert-powerpoint-to-html/). Ten artykuł koncentruje się na części eksportu związanej z linkowaniem zasobów.

## **Jak działa eksport zasobów linkowanych**

[ILinkEmbedController](https://reference.aspose.com/slides/pl/net/aspose.slides.export/ilinkembedcontroller/) pozwala aplikacji decydować, zasób po zasobie, czy eksporter osadza dane w HTML, czy zapisuje je zewnętrznie i tworzy link.

Interfejs posiada trzy metody:
- [ILinkEmbedController.GetObjectStoringLocation](https://reference.aspose.com/slides/pl/net/aspose.slides.export/ilinkembedcontroller/getobjectstoringlocation/) decyduje, czy zasób powinien być linkowany czy osadzony.
- [ILinkEmbedController.GetUrl](https://reference.aspose.com/slides/pl/net/aspose.slides.export/ilinkembedcontroller/geturl/) zwraca URL, który zostanie zapisany w wygenerowanym HTML lub w innym powiązanym zasobie.
- [ILinkEmbedController.SaveExternal](https://reference.aspose.com/slides/pl/net/aspose.slides.export/ilinkembedcontroller/saveexternal/) zapisuje dane linkowanego zasobu na dysk lub w inne miejsce przechowywania.

Ścieżka systemu plików i URL przeglądarki są odrębnymi zagadnieniami. Na przykład poniższy przykład zapisuje pliki zasobów w katalogu `html-output/assets` na dysku, podczas gdy HTML zawiera względne adresy URL, takie jak `assets/resource-1.svg`. Przeglądarka rozwiązuje te adresy URL względem pliku zawierającego link. W związku z tym link z `presentation.html` do pliku SVG używa `assets/resource-1.svg`, natomiast link z tego pliku SVG do obrazu zapisanego w tym samym folderze `assets` używa `resource-4.jpg`.

## **Eksport HTML z zasobami linkowanymi**

Poniższy przykład w C# tworzy katalog wyjściowy, zapisuje w nim plik HTML i przechowuje linkowane zasoby w podkatalogu `assets`. Kontroler linkuje typowe zasoby obrazów, czcionek, dźwięków, wideo i CSS, gdy Aspose.Slides dostarcza lub może wywnioskować bezpieczne rozszerzenie pliku. Zasoby, które nie są rozpoznane, pozostają osadzone.

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

Po eksporcie katalog wyjściowy ma następującą strukturę:

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

Dokładne pliki zależą od zawartości prezentacji i opcji eksportu. Na przykład obrazy rastrowe są zwykle eksportowane jako JPEG lub PNG. Aspose.Slides może wybrać inny codec obrazu niż użyty w oryginalnej prezentacji, jeśli daje to mniejszy lub lepszy plik. Obrazy z przezroczystością są eksportowane jako PNG.

## **Wybór URL-i do wdrożenia**

Przykład używa względnego prefiksu URL: `assets/`. Jeśli `presentation.html` zostanie otwarty z `html-output/presentation.html`, przeglądarka załaduje `html-output/assets/resource-1.svg`.

Gdy jeden linkowany zasób odwołuje się do innego linkowanego zasobu, przykład używa parametru `referrer` w [ILinkEmbedController.GetUrl](https://reference.aspose.com/slides/pl/net/aspose.slides.export/ilinkembedcontroller/geturl/) i zwraca tylko nazwę pliku. Na przykład, jeśli `resource-1.svg` i `resource-4.jpg` znajdują się w folderze `assets`, plik SVG powinien odwoływać się do `resource-4.jpg`, a nie do `assets/resource-4.jpg`.

Użyj innego prefiksu URL, gdy pliki są wdrożone w innym miejscu:
- Użyj `assets/`, gdy katalog zasobów znajduje się obok pliku HTML.
- Użyj `../assets/`, gdy katalog zasobów jest o jeden poziom wyżej niż plik HTML.
- Użyj `https://cdn.example.com/presentations/job-123/assets/`, gdy pliki są przesyłane do CDN lub statycznego serwera plików.

URL zwrócony przez [ILinkEmbedController.GetUrl](https://reference.aspose.com/slides/pl/net/aspose.slides.export/ilinkembedcontroller/geturl/) musi odpowiadać ostatecznemu miejscu wdrożenia pliku zapisanego przez [ILinkEmbedController.SaveExternal](https://reference.aspose.com/slides/pl/net/aspose.slides.export/ilinkembedcontroller/saveexternal/). W aplikacjach serwerowych używaj unikalnego katalogu wyjściowego lub prefiksu w magazynie obiektów dla każdego zadania konwersji, aby uniknąć nadpisywania plików z innego eksportu.

## **Kiedy zamiast tego osadzać**

Osadzony HTML w formacie Base64 jest nadal przydatny, gdy wyjście musi być pojedynczym plikiem, takim jak załącznik e‑mail, podgląd offline lub dokument, który będzie przenoszony bez folderu zasobów. Zasoby linkowane lepiej sprawdzają się, gdy HTML będzie serwowany przez aplikację internetową, przechowywany w CMS, optymalizowany w potoku budowania lub buforowany przez przeglądarki niezależnie od HTML.

## **FAQ**

**Czy mogę zewnętrznie udostępnić tylko obrazy i pozostawić pozostałe zasoby osadzone?**

Tak. W metodzie [ILinkEmbedController.GetObjectStoringLocation](https://reference.aspose.com/slides/pl/net/aspose.slides.export/ilinkembedcontroller/getobjectstoringlocation/) zwróć `LinkEmbedDecision.Link` tylko dla typów treści, które chcesz zapisać jako osobne pliki, a `LinkEmbedDecision.Embed` dla pozostałych.

**Dlaczego rozszerzenie wyeksportowanego obrazu różni się od prezentacji źródłowej?**

Aspose.Slides może ponownie kodować obrazy rastrowe podczas eksportu HTML, aby zmniejszyć rozmiar lub zwiększyć zgodność z przeglądarkami. Na przykład obraz z pliku źródłowego może zostać zapisany jako JPEG lub PNG w zależności od wyniku renderowania.

**Czy względne adresy URL działają po przeniesieniu pliku HTML?**

Względne adresy URL działają tylko wtedy, gdy zachowana jest ta sama względna struktura folderów. Jeśli HTML odwołuje się do `assets/resource-1.png`, folder `assets` musi pozostać obok pliku HTML, chyba że wygenerujesz inny prefiks URL.

**Czy aplikacje serwerowe powinny ponownie używać tego samego katalogu wyjściowego?**

Nie. Używaj unikalnego katalogu wyjściowego lub prefiksu przechowywania dla każdego zadania konwersji. Zapobiega to kolizjom nazw plików i uniemożliwia jednemu eksportowi nadpisywanie zasobów wygenerowanych przez inny eksport.