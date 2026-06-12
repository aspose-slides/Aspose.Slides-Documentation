---
title: Presentaties exporteren naar HTML met extern gelinkte afbeeldingen
type: docs
weight: 50
url: /nl/cpp/exporting-presentations-to-html-with-externally-linked-images/
keywords:
- PowerPoint exporteren
- OpenDocument exporteren
- presentatie exporteren
- dia exporteren
- PPT exporteren
- PPTX exporteren
- ODP exporteren
- PowerPoint naar HTML
- OpenDocument naar HTML
- presentatie naar HTML
- dia naar HTML
- PPT naar HTML
- PPTX naar HTML
- ODP naar HTML
- gelinkte afbeelding
- extern gelinkte afbeelding
- gelinkte bron
- externe bron
- C++
- Aspose.Slides
description: "Exporteer PowerPoint- en OpenDocument-presentaties naar HTML in C++ met Aspose.Slides, waarbij afbeeldingen en andere bronnen worden opgeslagen als extern gelinkte bestanden."
---
## **Overzicht**

Standaard exporteert Aspose.Slides een presentatie naar een zelfstandige HTML‑bestand. Afbeeldingen en andere bronnen worden direct in de HTML geschreven, meestal als Base64‑gegevens. Dat is handig wanneer je één draagbaar bestand nodig hebt, maar het is niet altijd het beste formaat voor een website, een CMS of een server‑side conversiepijplijn.

Gebruik extern gelinkte bronnen wanneer je wilt:

- de grootte van het HTML‑document verkleinen;
- afbeeldingen, lettertypen, audio of video apart cachen in een browser of CDN;
- gegenereerde bronnen na export inspecteren, vervangen, comprimeren of post‑processen;
- de uitvoerstructuur dichter bij wat een webapplicatie verwacht houden.

Voor de algemene HTML‑conversieworkflow, zie [Convert PowerPoint Presentations to HTML](/slides/nl/cpp/convert-powerpoint-to-html/). Dit artikel richt zich op het deel van de export waarbij bronnen worden gelinkt.

## **Hoe gelinkte bron‑export werkt**

[ILinkEmbedController](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/ilinkembedcontroller/) laat je applicatie per bron bepalen of de exporter de gegevens in de HTML embedden of extern opslaat en een link schrijft.

De interface bevat drie methoden:

- [ILinkEmbedController::GetObjectStoringLocation](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/ilinkembedcontroller/getobjectstoringlocation/) bepaalt of een bron gelinkt of ingebed moet worden.
- [ILinkEmbedController::GetUrl](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/ilinkembedcontroller/geturl/) geeft de URL terug die in de gegenereerde HTML of in een andere gelinkte bron wordt geschreven.
- [ILinkEmbedController::SaveExternal](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/ilinkembedcontroller/saveexternal/) schrijft de gelinkte brongegevens naar schijf of naar een andere opslaglocatie.

Het bestandssysteem‑pad en de browser‑URL zijn aparte zaken. Bijvoorbeeld, de onderstaande voorbeeldcode schrijft bronbestanden naar `html-output/assets` op schijf, terwijl de HTML relatieve URL’s bevat zoals `assets/resource-1.svg`. Een browser lost die URL’s op relatief ten opzichte van het bestand dat de link bevat. Daardoor gebruikt een link van `presentation.html` naar een SVG‑bestand `assets/resource-1.svg`, terwijl een link vanuit dat SVG‑bestand naar een afbeelding in dezelfde `assets`‑map `resource-4.jpg` gebruikt.

## **HTML exporteren met gelinkte bronnen**

Het volgende C++‑voorbeeld maakt een uitvoermap, slaat het HTML‑bestand daar op, en bewaart gelinkte bronnen in een `assets`‑submap. De controller linkt veelvoorkomende afbeelding‑, lettertype‑, audio‑, video‑ en CSS‑bronnen wanneer Aspose.Slides een veilige bestandsextensie kan leveren of afleiden. Bronnen die niet herkend worden, blijven ingebed.

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

Na de export heeft de uitvoermap deze structuur:

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

De exacte bestanden hangen af van de inhoud van de presentatie en de exportopties. Bijvoorbeeld, raster‑afbeeldingen worden meestal geëxporteerd als JPEG of PNG. Aspose.Slides kan een andere beeld‑codec kiezen dan die in de bronpresentatie werd gebruikt wanneer dat een kleiner of geschikter bestand oplevert. Afbeeldingen met transparantie worden geëxporteerd als PNG.

## **URL’s kiezen voor implementatie**

Het voorbeeld gebruikt een relatieve URL‑prefix: `assets/`. Als `presentation.html` wordt geopend vanuit `html-output/presentation.html`, laadt de browser `html-output/assets/resource-1.svg`.

Wanneer een gelinkte bron naar een andere gelinkte bron verwijst, gebruikt het voorbeeld de `referrer`‑parameter in [ILinkEmbedController::GetUrl](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/ilinkembedcontroller/geturl/) en retourneert alleen de bestandsnaam. Bijvoorbeeld, als `resource-1.svg` en `resource-4.jpg` beide in de `assets`‑map staan, moet het SVG‑bestand naar `resource-4.jpg` verwijzen, niet naar `assets/resource-4.jpg`.

Gebruik een andere URL‑prefix wanneer de bestanden elders worden geïmplementeerd:

- Gebruik `assets/` wanneer de asset‑map naast het HTML‑bestand staat.
- Gebruik `../assets/` wanneer de asset‑map één niveau hoger staat dan het HTML‑bestand.
- Gebruik `https://cdn.example.com/presentations/job-123/assets/` wanneer de bestanden worden geüpload naar een CDN of statische bestandsserver.

De URL die wordt geretourneerd door [ILinkEmbedController::GetUrl](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/ilinkembedcontroller/geturl/) moet overeenkomen met de uiteindelijke locatie van het bestand dat wordt geschreven door [ILinkEmbedController::SaveExternal](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/ilinkembedcontroller/saveexternal/). In server‑applicaties, gebruik een unieke uitvoermap of object‑storage‑prefix per conversietaak om overschrijving van bestanden van een andere export te voorkomen.

## **Wanneer in plaats daarvan embedden**

Ingebedde Base64‑HTML is nog steeds nuttig wanneer de uitvoer één enkel bestand moet zijn, bijvoorbeeld als e‑mailbijlage, offline preview of een document dat zonder bijbehorende asset‑map wordt verplaatst. Gelinkte bronnen passen beter wanneer de HTML wordt bediend door een webapplicatie, opgeslagen in een CMS, geoptimaliseerd door een build‑pipeline, of onafhankelijk van de HTML door browsers wordt gecached.

## **FAQ**

**Kan ik alleen afbeeldingen externaliseren en de andere bronnen ingebed laten?**

Ja. In [ILinkEmbedController::GetObjectStoringLocation](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/ilinkembedcontroller/getobjectstoringlocation/) retourneer je `LinkEmbedDecision::Link` uitsluitend voor de content‑types die je als afzonderlijke bestanden wilt opslaan, en `LinkEmbedDecision::Embed` voor alles andere.

**Waarom verschilt de geëxporteerde afbeeldingsextensie van die in de bronpresentatie?**

Aspose.Slides kan raster‑afbeeldingen opnieuw coderen tijdens HTML‑export om de bestandsgrootte of browser‑compatibiliteit te verbeteren. Bijvoorbeeld, een afbeelding uit het bronbestand kan worden geschreven als JPEG of PNG afhankelijk van het gerenderde resultaat.

**Werken relatieve URL’s als ik het HTML‑bestand verplaats?**

Relatieve URL’s werken alleen wanneer dezelfde relatieve mapstructuur behouden blijft. Als de HTML verwijst naar `assets/resource-1.png`, moet de `assets`‑map naast het HTML‑bestand blijven tenzij je een andere URL‑prefix genereert.

**Moeten server‑applicaties dezelfde uitvoermap hergebruiken?**

Nee. Gebruik een unieke uitvoermap of opslag‑prefix per conversietaak. Dit vermijdt bestandsnamenconflicten en voorkomt dat één export bronnen van een andere export overschrijft.