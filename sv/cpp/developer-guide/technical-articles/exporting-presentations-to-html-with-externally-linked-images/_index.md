---
title: Exportera presentationer till HTML med externt länkade bilder
type: docs
weight: 50
url: /sv/cpp/exporting-presentations-to-html-with-externally-linked-images/
keywords:
- exportera PowerPoint
- exportera OpenDocument
- exportera presentation
- exportera bild
- exportera PPT
- exportera PPTX
- exportera ODP
- PowerPoint till HTML
- OpenDocument till HTML
- presentation till HTML
- slide till HTML
- PPT till HTML
- PPTX till HTML
- ODP till HTML
- länkad bild
- externt länkad bild
- länkad resurs
- extern resurs
- C++
- Aspose.Slides
description: Exportera PowerPoint- och OpenDocument-presentationer till HTML i C++ med Aspose.Slides där bilder och andra resurser sparas som externt länkade filer.
---
## **Översikt**

Som standard exporterar Aspose.Slides en presentation till en fristående HTML-fil. Bilder och andra resurser skrivs direkt in i HTML-filen, vanligtvis som Base64-data. Detta är bekvämt när du behöver en portabel fil, men det är inte alltid det bästa formatet för en webbplats, ett CMS eller en server-sidig konverteringspipeline.

Använd externt länkade resurser när du vill:

- minska storleken på HTML-dokumentet;
- cacha bilder, typsnitt, ljud eller video separat i en webbläsare eller CDN;
- inspektera, ersätta, komprimera eller efterbehandla genererade resurser efter export;
- behålla output-strukturen närmare det en webbapplikation förväntar sig.

För den allmänna HTML-konverteringsarbetsflödet, se [Konvertera PowerPoint-presentationer till HTML](/slides/sv/cpp/convert-powerpoint-to-html/). Denna artikel fokuserar på resurslänkningsdelen av exporten.

## **Hur länkad resurs‑export fungerar**

[ILinkEmbedController](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/ilinkembedcontroller/) låter din applikation avgöra, resurs för resurs, om exportören bäddar in data i HTML eller sparar den externt och skriver en länk.

Gränssnittet har tre metoder:

- [ILinkEmbedController::GetObjectStoringLocation](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/ilinkembedcontroller/getobjectstoringlocation/) avgör om en resurs ska länkas eller bäddas in.
- [ILinkEmbedController::GetUrl](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/ilinkembedcontroller/geturl/) returnerar URL:en som kommer att skrivas till den genererade HTML:n eller till en annan länkad resurs.
- [ILinkEmbedController::SaveExternal](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/ilinkembedcontroller/saveexternal/) skriver den länkade resursens data till disk eller till ett annat lagringsmål.

Filsystemets sökväg och webbläsarens URL är separata frågor. Till exempel skriver provet nedan resursfiler till `html-output/assets` på disken, medan HTML-filen innehåller relativa URL:er såsom `assets/resource-1.svg`. En webbläsare löser dessa URL:er relativt filen som innehåller länken. Därför använder en länk från `presentation.html` till en SVG-fil `assets/resource-1.svg`, medan en länk från den SVG-filen till en bild som sparats i samma `assets`-mapp använder `resource-4.jpg`.

## **Exportera HTML med länkade resurser**

Följande C++-exempel skapar en utdata-katalog, sparar HTML-filen där och lagrar länkade resurser i en `assets`-underkatalog. Kontrollen länkar vanliga bild-, teckensnitt-, ljud-, video- och CSS-resurser när Aspose.Slides tillhandahåller eller kan härleda en säker filändelse. Resurser som inte känns igen förblir inbäddade.

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

Efter exporten har utdata-mappen följande struktur:

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

De exakta filerna beror på presentationens innehåll och exportalternativ. Till exempel exporteras rasterbilder vanligtvis som JPEG eller PNG. Aspose.Slides kan välja en annan bildkodare än den som används i källpresentationen när det ger en mindre eller mer lämplig fil. Bilder med transparens exporteras som PNG.

## **Välja URL:er för distribution**

Exemplet använder ett relativt URL-prefix: `assets/`. Om `presentation.html` öppnas från `html-output/presentation.html` laddar webbläsaren `html-output/assets/resource-1.svg`.

När en länkad resurs refererar till en annan länkad resurs använder exemplet parametern `referrer` i [ILinkEmbedController::GetUrl](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/ilinkembedcontroller/geturl/) och returnerar endast filnamnet. Till exempel, om `resource-1.svg` och `resource-4.jpg` båda finns i `assets`-mappen, ska SVG-filen referera till `resource-4.jpg`, inte till `assets/resource-4.jpg`.

Använd ett annat URL-prefix när filerna distribueras någon annanstans:

- Använd `assets/` när tillgångsmappen ligger bredvid HTML-filen.
- Använd `../assets/` när tillgångsmappen är en nivå över HTML-filen.
- Använd `https://cdn.example.com/presentations/job-123/assets/` när filerna laddas upp till ett CDN eller en statisk filserver.

URL:en som returneras av [ILinkEmbedController::GetUrl](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/ilinkembedcontroller/geturl/) måste matcha den slutgiltiga distribuerade platsen för filen som skrivs av [ILinkEmbedController::SaveExternal](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/ilinkembedcontroller/saveexternal/). I serverapplikationer, använd en unik utdata-katalog eller objekt-lagrings-prefix för varje konverteringsjobb för att undvika att skriva över filer från en annan export.

## **När man ska bädda in istället**

Inbäddad Base64-HTML är fortfarande användbar när utdata måste vara en enda fil, till exempel ett e-postbilaga, en offline-förhandsgranskning eller ett dokument som ska flyttas utan en stödjande tillgångsmapp. Länkade resurser passar bättre när HTML levereras av en webbapplikation, lagras i ett CMS, optimeras av en byggpipeline eller cachas av webbläsare oberoende av HTML.

## **FAQ**

**Kan jag externalisera endast bilder och behålla andra resurser inbäddade?**

Ja. I [ILinkEmbedController::GetObjectStoringLocation](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/ilinkembedcontroller/getobjectstoringlocation/) returnerar du `LinkEmbedDecision::Link` endast för de innehållstyper du vill spara som separata filer, och returnerar `LinkEmbedDecision::Embed` för allt annat.

**Varför skiljer sig den exporterade bildfilens filändelse från källpresentationen?**

Aspose.Slides kan omkoda rasterbilder under HTML-export för att förbättra storlek eller webbläsarkompatibilitet. Till exempel kan en bild från källfilen skrivas som JPEG eller PNG beroende på det renderade resultatet.

**Fungerar relativa URL:er efter att jag flyttar HTML-filen?**

Relativa URL:er fungerar endast när samma relativa mappstruktur bevaras. Om HTML-filen refererar till `assets/resource-1.png` måste `assets`-mappen ligga bredvid HTML-filen om du inte genererar ett annat URL-prefix.

**Ska serverapplikationer återanvända samma utdata-mapp?**

Nej. Använd en unik utdata-katalog eller lagrings-prefix för varje konverteringsjobb. Detta undviker filnamnskonflikter och förhindrar att en export skriver över resurser som genererats av en annan export.