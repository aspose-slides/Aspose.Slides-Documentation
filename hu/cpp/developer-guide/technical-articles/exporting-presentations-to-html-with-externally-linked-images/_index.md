---
title: Prezentációk exportálása HTML-re külsőleg hivatkozott képekkel
type: docs
weight: 50
url: /hu/cpp/exporting-presentations-to-html-with-externally-linked-images/
keywords:
- PowerPoint export
- OpenDocument export
- prezentáció exportálása
- dia exportálása
- PPT export
- PPTX export
- ODP export
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
- C++
- Aspose.Slides
description: "PowerPoint és OpenDocument prezentációk exportálása HTML-re C++-ban az Aspose.Slides használatával, ahol a képek és egyéb erőforrások külsőleg hivatkozott fájlként vannak mentve."
---
## **Áttekintés**

Alapértelmezés szerint az Aspose.Slides egy prezentációt önálló HTML-fájlba exportál. A képek és egyéb erőforrások közvetlenül a HTML-be kerülnek, általában Base64 adatként. Ez akkor kényelmes, ha egy hordozható fájlra van szükség, de nem mindig a legjobb formátum egy weboldal, egy CMS vagy egy szerveroldali konverziós csővezeték számára.

Használjon külsőleg hivatkozott erőforrásokat, ha:
- csökkentse a HTML dokumentum méretét;
- a képeket, betűtípusokat, hangot vagy videót külön tárolja a böngészőben vagy CDN-ben;
- a generált erőforrásokat az export után ellenőrizze, cserélje, tömörítse vagy utófeldolgozza;
- tartsa meg a kimeneti struktúrát közelebb ahhoz, ami egy webalkalmazás elvár.

Az általános HTML-konverziós munkafolyamathoz lásd a [PowerPoint-prezentációk konvertálása HTML-re](/slides/hu/cpp/convert-powerpoint-to-html/). Ez a cikk az export erőforrás-hivatkozási részére koncentrál.

## **Hogyan működik a hivatkozott erőforrások exportálása**

[ILinkEmbedController](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/ilinkembedcontroller/) lehetővé teszi az alkalmazás számára, hogy erőforrásonként eldöntse, beágyazza-e az adatot a HTML-be, vagy külsőleg menti és hivatkozást ír.

Az interfésznek három metódusa van:
- [ILinkEmbedController::GetObjectStoringLocation](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/ilinkembedcontroller/getobjectstoringlocation/) eldönti, hogy egy erőforrás hivatkozott vagy beágyazott legyen.
- [ILinkEmbedController::GetUrl](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/ilinkembedcontroller/geturl/) visszaadja azt az URL-t, amelyet a generált HTML-be vagy egy másik hivatkozott erőforrásba ír.
- [ILinkEmbedController::SaveExternal](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/ilinkembedcontroller/saveexternal/) a hivatkozott erőforrás adatát lemezen vagy egy másik tárolási célra írja.

A fájlrendszer útvonala és a böngésző URL-je külön kérdés. Például az alábbi példa a `html-output/assets` könyvtárba írja az erőforrásfájlokat, míg a HTML relatív URL-eket tartalmaz, például `assets/resource-1.svg`. A böngésző ezeket az URL-eket a hivatkozást tartalmazó fájlhoz viszonyítva oldja fel. Ennek következtében a `presentation.html` fájlból egy SVG fájlra mutató hivatkozás `assets/resource-1.svg`-t használ, míg az SVG fájlból egy ugyanabban az `assets` mappában tárolt képhez mutató hivatkozás `resource-4.jpg` lesz.

## **HTML exportálása hivatkozott erőforrásokkal**

Az alábbi C++ példa létrehoz egy kimeneti könyvtárat, oda menti a HTML-fájlt, és a hivatkozott erőforrásokat egy `assets` almappába helyezi. A vezérlő a gyakori képek, betűtípusok, hang, videó és CSS erőforrásokat hivatkozza, ha az Aspose.Slides biztosít vagy meg tud határozni egy biztonságos fájlkiterjesztést. A nem felismert erőforrások beágyazva maradnak.

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

Az exportálás után a kimeneti mappának ez a struktúrája lesz:

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

A pontos fájlok a prezentáció tartalmától és az exportálási beállításoktól függenek. Például a raszteres képeket általában JPEG vagy PNG formátumban exportálja. Az Aspose.Slides más képkódolót választhat, mint a forrásprezentációban használt, ha ez kisebb vagy megfelelőbb fájlt eredményez. A transparent réteggel rendelkező képeket PNG-ként exportálja.

## **URL-ek kiválasztása a telepítéshez**

A példa relatív URL előtagot használ: `assets/`. Ha a `presentation.html` a `html-output/presentation.html` útvonalról van megnyitva, a böngésző a `html-output/assets/resource-1.svg` fájlt tölti be.

Ha egy hivatkozott erőforrás egy másik hivatkozott erőforrásra hivatkozik, a példa a `referrer` paramétert használja az [ILinkEmbedController::GetUrl](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/ilinkembedcontroller/geturl/) metódusban, és csak a fájlnevet adja vissza. Például ha a `resource-1.svg` és a `resource-4.jpg` is az `assets` mappában van, az SVG fájlnak a `resource-4.jpg`-re kell hivatkoznia, nem az `assets/resource-4.jpg`-ra.

Használjon másik URL előtagot, ha a fájlok máshol vannak telepítve:
- `assets/` használata, ha az asset könyvtár a HTML-fájl mellett található.
- `../assets/` használata, ha az asset könyvtár egy szinttel a HTML-fájl fölött helyezkedik el.
- `https://cdn.example.com/presentations/job-123/assets/` használata, ha a fájlok CDN-re vagy statikus fájlszerverre vannak feltöltve.

Az [ILinkEmbedController::GetUrl](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/ilinkembedcontroller/geturl/) által visszaadott URL-nek meg kell egyeznie a [ILinkEmbedController::SaveExternal](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/ilinkembedcontroller/saveexternal/) által írt fájl végső telepített helyével. Szerveralkalmazásokban használjon egyedi kimeneti könyvtárat vagy objektumtároló előtagot minden konverziós feladathoz, hogy elkerülje egy másik export fájljainak felülírását.

## **Mikor érdemes inkább beágyazni**

A beágyazott Base64 HTML továbbra is hasznos, ha a kimenetnek egyetlen fájlnak kell lennie, például e‑mail mellékletként, offline előnézetként, vagy egy olyan dokumentumként, amelyet támogatás nélkül, asset mappa nélkül mozgatnak. A hivatkozott erőforrások jobban illeszkednek, ha a HTML-t egy webalkalmazás szolgálja ki, CMS-ben tárolják, egy build folyamat optimalizálja, vagy a böngészők a HTML-től függetlenül gyorsítótárazzák.

## **GYIK**

**Exportálhatok csak képeket, a többi erőforrást beágyazva hagyom?**

Igen. Az [ILinkEmbedController::GetObjectStoringLocation](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/ilinkembedcontroller/getobjectstoringlocation/) metódusban csak azokhoz a tartalomtípusokhoz térjen vissza `LinkEmbedDecision::Link` értékkel, amelyeket külön fájlként szeretne menteni, és minden más esetben `LinkEmbedDecision::Embed` értékkel térjen vissza.

**Miért tér el az exportált kép kiterjesztése a forrásprezentációétól?**

Az Aspose.Slides a HTML exportálás során újrakódolhatja a raszteres képeket, hogy csökkentse a méretet vagy javítsa a böngészőkompatibilitást. Például a forrásfájlból származó kép JPEG vagy PNG formátumban írható ki a megjelenített eredménytől függően.

**Működnek a relatív URL-ek, ha áthelyezem a HTML-fájlt?**

A relatív URL-ek csak akkor működnek, ha a ugyanaz a relatív mappaszerkezet megmarad. Ha a HTML a `assets/resource-1.png`-re hivatkozik, akkor az `assets` mappának a HTML-fájl mellett kell maradnia, hacsak nem generál másik URL előtagot.

**Kell-e a szerveralkalmazásoknak ugyanazt a kimeneti mappát újrahasznosítaniuk?**

Nem. Használjon egyedi kimeneti könyvtárat vagy tárolási előtagot minden konverziós feladathoz. Ez elkerüli a fájlnév-ütközéseket, és megakadályozza, hogy egy export felülírja egy másik export által generált erőforrásokat.