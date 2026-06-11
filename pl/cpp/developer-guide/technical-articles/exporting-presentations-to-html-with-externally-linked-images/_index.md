---
title: Eksportowanie prezentacji do HTML z zewnętrznie linkowanymi obrazami
type: docs
weight: 50
url: /pl/cpp/exporting-presentations-to-html-with-externally-linked-images/
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
- C++
- Aspose.Slides
description: "Eksportuj prezentacje PowerPoint i OpenDocument do HTML w C++ przy użyciu Aspose.Slides, zapisując obrazy i inne zasoby jako zewnętrznie linkowane pliki."
---
## **Przegląd**

Domyślnie Aspose.Slides eksportuje prezentację do samodzielnego pliku HTML. Obrazy i inne zasoby są zapisywane bezpośrednio w HTML, najczęściej jako dane Base64. Jest to wygodne, gdy potrzebny jest jeden przenośny plik, ale nie zawsze jest to najlepszy format dla witryny internetowej, systemu CMS ani potoku konwersji po stronie serwera.

Używaj zasobów linkowanych zewnętrznie, gdy chcesz:
- zmniejszyć rozmiar dokumentu HTML;
- oddzielnie buforować obrazy, czcionki, dźwięk lub wideo w przeglądarce lub CDN;
- przeglądać, zastępować, kompresować lub przetwarzać po wyeksportowaniu wygenerowane zasoby;
- zachować strukturę wyjściową bliższą temu, czego oczekuje aplikacja internetowa.

Ogólny przepływ konwersji HTML znajdziesz w [Konwertowanie prezentacji PowerPoint do HTML](/slides/pl/cpp/convert-powerpoint-to-html/). Ten artykuł koncentruje się na części eksportu dotyczącej linkowania zasobów.

## **Jak działa eksport zasobów linkowanych**

[ILinkEmbedController](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/ilinkembedcontroller/) pozwala aplikacji decydować, zasób po zasobie, czy eksporter osadza dane w HTML, czy zapisuje je zewnętrznie i zapisuje link.

Interfejs posiada trzy metody:
- [ILinkEmbedController::GetObjectStoringLocation](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/ilinkembedcontroller/getobjectstoringlocation/) decyduje, czy zasób powinien być linkowany czy osadzony.
- [ILinkEmbedController::GetUrl](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/ilinkembedcontroller/geturl/) zwraca URL, który zostanie zapisany w wygenerowanym HTML lub w innym powiązanym zasobie.
- [ILinkEmbedController::SaveExternal](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/ilinkembedcontroller/saveexternal/) zapisuje dane powiązanego zasobu na dysk lub do innego miejsca przechowywania.

Ścieżka systemu plików i URL w przeglądarce to odrębne zagadnienia. Na przykład poniższy przykład zapisuje pliki zasobów w katalogu `html-output/assets` na dysku, podczas gdy HTML zawiera względne URL‑e, takie jak `assets/resource-1.svg`. Przeglądarka rozwiązuje te URL‑e względem pliku zawierającego link. Dlatego link z `presentation.html` do pliku SVG używa `assets/resource-1.svg`, a link z tego pliku SVG do obrazu zapisanego w tym samym katalogu `assets` używa `resource-4.jpg`.

## **Eksport HTML z zasobami linkowanymi**

Następujący przykład w C++ tworzy katalog wyjściowy, zapisuje w nim plik HTML i przechowuje zasoby linkowane w podkatalogu `assets`. Kontroler linkuje typowe zasoby obrazów, czcionek, dźwięków, wideo i CSS, gdy Aspose.Slides dostarcza lub może wywnioskować bezpieczne rozszerzenie pliku. Zasoby nie rozpoznane pozostają osadzone.

```cpp
class ExternalResourceController : public ILinkEmbedController
{
public:
    ExternalResourceController(String assetDirectory, String assetUrlPrefix)
    {
        if (IsNullOrWhiteSpace(assetDirectory))
        {
            throw Exception(u"The asset output directory must not be empty.");
        }

        m_assetDirectory = assetDirectory;
        m_assetUrlPrefix = NormalizeUrlPrefix(assetUrlPrefix);
        m_fileNamesByResourceId = MakeObject<Dictionary<int, String>>();
    }

    LinkEmbedDecision GetObjectStoringLocation(
        int resourceId,
        ArrayPtr<uint8_t> entityData,
        String semanticName,
        String contentType,
        String recommendedExtension) override
    {
        auto extension = ResolveExtension(contentType, recommendedExtension);
        if (String::IsNullOrEmpty(extension))
        {
            return LinkEmbedDecision::Embed;
        }

        auto fileName = String::Format(u"resource-{0}{1}", resourceId, extension);
        m_fileNamesByResourceId->Add(resourceId, fileName);
        return LinkEmbedDecision::Link;
    }

    String GetUrl(int resourceId, int referrer) override
    {
        String fileName;
        if (!m_fileNamesByResourceId->TryGetValue(resourceId, fileName))
        {
            return nullptr;
        }

        if (m_fileNamesByResourceId->ContainsKey(referrer))
        {
            return fileName;
        }

        return m_assetUrlPrefix + fileName;
    }

    void SaveExternal(int resourceId, ArrayPtr<uint8_t> entityData) override
    {
        String fileName;
        if (!m_fileNamesByResourceId->TryGetValue(resourceId, fileName))
        {
            auto message = String::Format(u"Resource {0} was not registered for external storage.", resourceId);
            throw Exception(message);
        }

        if (entityData == nullptr || entityData->get_Length() == 0)
        {
            auto message = String::Format(u"Resource {0} contains no data and cannot be saved.", resourceId);
            throw Exception(message);
        }

        Directory::CreateDirectory_(m_assetDirectory);

        auto filePath = Path::Combine(m_assetDirectory, fileName);
        auto fileStream = MakeObject<FileStream>(filePath, FileMode::Create, FileAccess::Write);
        fileStream->Write(entityData, 0, entityData->get_Length());
        fileStream->Close();
    }

private:
    String m_assetDirectory;
    String m_assetUrlPrefix;
    SharedPtr<Dictionary<int, String>> m_fileNamesByResourceId;

    static SharedPtr<Dictionary<String, String>> GetExtensionsByContentType()
    {
        auto extensionsByContentType = MakeObject<Dictionary<String, String>>();
        extensionsByContentType->Add(u"image/jpeg", u".jpg");
        extensionsByContentType->Add(u"image/png", u".png");
        extensionsByContentType->Add(u"image/gif", u".gif");
        extensionsByContentType->Add(u"image/bmp", u".bmp");
        extensionsByContentType->Add(u"image/svg+xml", u".svg");
        extensionsByContentType->Add(u"image/tiff", u".tiff");
        extensionsByContentType->Add(u"image/x-emf", u".emf");
        extensionsByContentType->Add(u"image/x-wmf", u".wmf");
        extensionsByContentType->Add(u"font/woff", u".woff");
        extensionsByContentType->Add(u"font/woff2", u".woff2");
        extensionsByContentType->Add(u"font/ttf", u".ttf");
        extensionsByContentType->Add(u"application/font-woff", u".woff");
        extensionsByContentType->Add(u"application/vnd.ms-fontobject", u".eot");
        extensionsByContentType->Add(u"application/x-font-ttf", u".ttf");
        extensionsByContentType->Add(u"text/css", u".css");
        extensionsByContentType->Add(u"audio/mpeg", u".mp3");
        extensionsByContentType->Add(u"audio/mp4", u".m4a");
        extensionsByContentType->Add(u"audio/wav", u".wav");
        extensionsByContentType->Add(u"video/mp4", u".mp4");
        extensionsByContentType->Add(u"video/webm", u".webm");
        return extensionsByContentType;
    }

    static String ResolveExtension(String contentType, String recommendedExtension)
    {
        auto normalizedContentType = NormalizeContentType(contentType);
        auto extensionsByContentType = GetExtensionsByContentType();

        String mappedExtension;
        if (!String::IsNullOrEmpty(normalizedContentType) &&
            extensionsByContentType->TryGetValue(normalizedContentType, mappedExtension))
        {
            return mappedExtension;
        }

        if (!IsSupportedContentType(normalizedContentType))
        {
            return nullptr;
        }

        return NormalizeExtension(recommendedExtension);
    }

    static bool IsSupportedContentType(String contentType)
    {
        return !String::IsNullOrEmpty(contentType) &&
            (contentType.StartsWith(u"image/") ||
                contentType.StartsWith(u"font/") ||
                contentType.StartsWith(u"audio/") ||
                contentType.StartsWith(u"video/"));
    }

    static String NormalizeContentType(String contentType)
    {
        if (IsNullOrWhiteSpace(contentType))
        {
            return nullptr;
        }

        return contentType.Trim().ToLowerInvariant();
    }

    static String NormalizeExtension(String extension)
    {
        if (IsNullOrWhiteSpace(extension))
        {
            return nullptr;
        }

        auto extensionCharacters = extension.Trim();
        if (extensionCharacters.StartsWith(u"."))
        {
            extensionCharacters = extensionCharacters.Substring(1);
        }

        if (String::IsNullOrEmpty(extensionCharacters))
        {
            return nullptr;
        }

        auto extensionLength = extensionCharacters.get_Length();
        for (int index = 0; index < extensionLength; index++)
        {
            auto character = extensionCharacters[index];
            if (!Char::IsLetterOrDigit(character))
            {
                return nullptr;
            }
        }

        return u"." + extensionCharacters.ToLowerInvariant();
    }

    static String NormalizeUrlPrefix(String urlPrefix)
    {
        if (String::IsNullOrEmpty(urlPrefix))
        {
            return String::Empty;
        }

        auto normalizedUrlPrefix = urlPrefix.Replace(u"\\", u"/");
        if (normalizedUrlPrefix.EndsWith(u"/"))
        {
            return normalizedUrlPrefix;
        }

        return normalizedUrlPrefix + u"/";
    }

    static bool IsNullOrWhiteSpace(String value)
    {
        return String::IsNullOrEmpty(value) || String::IsNullOrEmpty(value.Trim());
    }
};
```
```cpp
auto inputFilePath = String(u"presentation.pptx");
auto outputDirectory = String(u"html-output");
auto assetDirectoryName = String(u"assets");
auto assetDirectory = Path::Combine(outputDirectory, assetDirectoryName);

Directory::CreateDirectory_(outputDirectory);
Directory::CreateDirectory_(assetDirectory);

auto assetUrlPrefix = assetDirectoryName + u"/";
auto controller = MakeObject<ExternalResourceController>(assetDirectory, assetUrlPrefix);
auto svgOptions = MakeObject<SVGOptions>(controller);
auto slideImageFormat = SlideImageFormat::Svg(svgOptions);

auto htmlOptions = MakeObject<HtmlOptions>(controller);
htmlOptions->set_HtmlFormatter(HtmlFormatter::CreateDocumentFormatter(String::Empty, false));
htmlOptions->set_SlideImageFormat(slideImageFormat);

auto presentation = MakeObject<Presentation>(inputFilePath);

auto htmlFilePath = Path::Combine(outputDirectory, u"presentation.html");
presentation->Save(htmlFilePath, SaveFormat::Html, htmlOptions);
presentation->Dispose();
```

Po wyeksportowaniu folder wyjściowy ma taką strukturę:

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

Dokładne pliki zależą od zawartości prezentacji i opcji eksportu. Na przykład obrazy rastrowe są zazwyczaj eksportowane jako JPEG lub PNG. Aspose.Slides może wybrać inny kodek obrazu niż użyty w prezentacji źródłowej, jeśli to daje mniejszy lub bardziej odpowiedni plik. Obrazy z przezroczystością są eksportowane jako PNG.

## **Wybór URL‑ów do wdrożenia**

Przykład używa względnego prefiksu URL: `assets/`. Jeśli `presentation.html` zostanie otwarty z `html-output/presentation.html`, przeglądarka załaduje `html-output/assets/resource-1.svg`.

Gdy jeden zasób linkowany odwołuje się do innego zasobu linkowanego, przykład używa parametru `referrer` w [ILinkEmbedController::GetUrl](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/ilinkembedcontroller/geturl/) i zwraca tylko nazwę pliku. Na przykład, jeśli `resource-1.svg` i `resource-4.jpg` znajdują się w folderze `assets`, plik SVG powinien odwoływać się do `resource-4.jpg`, a nie do `assets/resource-4.jpg`.

Użyj innego prefiksu URL, gdy pliki są wdrażane w innym miejscu:
- Użyj `assets/`, gdy katalog zasobów znajduje się obok pliku HTML.
- Użyj `../assets/`, gdy katalog zasobów jest o jeden poziom wyżej niż plik HTML.
- Użyj `https://cdn.example.com/presentations/job-123/assets/`, gdy pliki są przesyłane do CDN lub serwera plików statycznych.

URL zwrócony przez [ILinkEmbedController::GetUrl](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/ilinkembedcontroller/geturl/) musi odpowiadać ostatecznej lokalizacji wdrożonego pliku zapisanego przez [ILinkEmbedController::SaveExternal](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/ilinkembedcontroller/saveexternal/). W aplikacjach serwerowych używaj unikalnego katalogu wyjściowego lub prefiksu w magazynie obiektowym dla każdego zadania konwersji, aby uniknąć nadpisywania plików z innego eksportu.

## **Kiedy zamiast tego osadzać**

HTML z osadzonymi danymi Base64 nadal jest przydatny, gdy wynik musi być jednym plikiem, np. załącznikiem e‑mail, podglądem offline lub dokumentem, który będzie przenoszony bez folderu zasobów. Zasoby linkowane są lepszym rozwiązaniem, gdy HTML będzie serwowany przez aplikację internetową, przechowywany w CMS, optymalizowany w potoku budowania lub buforowany przez przeglądarki niezależnie od HTML.

## **FAQ**

**Czy mogę zewnętrznie umieścić tylko obrazy i pozostawić inne zasoby osadzone?**

Tak. W [ILinkEmbedController::GetObjectStoringLocation](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/ilinkembedcontroller/getobjectstoringlocation/) zwróć `LinkEmbedDecision::Link` tylko dla typów treści, które chcesz zapisać jako osobne pliki, oraz zwróć `LinkEmbedDecision::Embed` dla wszystkiego innego.

**Dlaczego rozszerzenie wyeksportowanego obrazu różni się od prezentacji źródłowej?**

Aspose.Slides może ponownie kodować obrazy rastrowe podczas eksportu HTML, aby poprawić rozmiar lub zgodność z przeglądarką. Na przykład obraz z pliku źródłowego może zostać zapisany jako JPEG lub PNG w zależności od wyniku renderowania.

**Czy względne URL‑e działają po przeniesieniu pliku HTML?**

Względne URL‑e działają tylko wtedy, gdy zachowana jest ta sama względna struktura folderów. Jeśli HTML odwołuje się do `assets/resource-1.png`, folder `assets` musi pozostać obok pliku HTML, chyba że wygenerujesz inny prefiks URL.

**Czy aplikacje serwerowe powinny ponownie używać tego samego folderu wyjściowego?**

Nie. Używaj unikalnego katalogu wyjściowego lub prefiksu przechowywania dla każdego zadania konwersji. Zapobiega to kolizjom nazw plików i uniemożliwia jednemu eksportowi nadpisywanie zasobów generowanych przez inny export.