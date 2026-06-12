---
title: Export prezentací do HTML s externě odkazovanými obrázky
type: docs
weight: 50
url: /cs/cpp/exporting-presentations-to-html-with-externally-linked-images/
keywords:
- export PowerPoint
- export OpenDocument
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
- odkazovaný obrázek
- externě odkazovaný obrázek
- odkazovaný zdroj
- externí zdroj
- C++
- Aspose.Slides
description: "Exportujte prezentace PowerPoint a OpenDocument do HTML v C++ pomocí Aspose.Slides, přičemž obrázky a další zdroje jsou uloženy jako externě odkazované soubory."
---
## **Přehled**

Ve výchozím nastavení Aspose.Slides exportuje prezentaci do samostatného souboru HTML. Obrázky a další zdroje jsou zapisovány přímo do HTML, obvykle jako data Base64. To je praktické, když potřebujete jeden přenosný soubor, ale není to vždy nejlepší formát pro webové stránky, CMS nebo serverový převodní řetězec.

Používejte externě odkazované zdroje, když chcete:
- zmenšit velikost HTML dokumentu;
- cachovat obrázky, fonty, audio nebo video zvlášť v prohlížeči nebo CDN;
- kontrolovat, nahradit, komprimovat nebo následně zpracovávat vygenerované zdroje po exportu;
- udržet strukturu výstupu blíže tomu, co očekává webová aplikace.

Pro obecný postup konverze HTML viz [Převod prezentací PowerPoint do HTML](/slides/cs/cpp/convert-powerpoint-to-html/). Tento článek se zaměřuje na část exportu související s odkazováním zdrojů.

## **Jak funguje export odkazovaných zdrojů**

[ILinkEmbedController](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/ilinkembedcontroller/) umožňuje vaší aplikaci rozhodnout se, zdroj po zdroji, zda exportér vloží data do HTML nebo je uloží externě a zapíše odkaz.

Rozhraní má tři metody:
- [ILinkEmbedController::GetObjectStoringLocation](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/ilinkembedcontroller/getobjectstoringlocation/) rozhoduje, zda má být zdroj odkazován nebo vložen.
- [ILinkEmbedController::GetUrl](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/ilinkembedcontroller/geturl/) vrací URL, které bude zapsáno do vygenerovaného HTML nebo do jiného odkazovaného zdroje.
- [ILinkEmbedController::SaveExternal](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/ilinkembedcontroller/saveexternal/) zapisuje data odkazovaného zdroje na disk nebo do jiného úložného cíle.

Cesta v souborovém systému a URL v prohlížeči jsou oddělené záležitosti. Například níže uvedený vzor zapisuje soubory zdrojů do `html-output/assets` na disku, zatímco HTML obsahuje relativní URL jako `assets/resource-1.svg`. Prohlížeč tyto URL řeší relativně k souboru, který odkaz obsahuje. Proto odkaz z `presentation.html` na soubor SVG používá `assets/resource-1.svg`, zatímco odkaz z tohoto SVG souboru na obrázek uložený ve stejném adresáři `assets` používá `resource-4.jpg`.

## **Export HTML s odkazovanými zdroji**

Následující příklad v C++ vytvoří výstupní adresář, uloží tam soubor HTML a uloží odkazované zdroje do podadresáře `assets`. Kontroler odkazuje běžné obrázkové, fontové, audio, video a CSS zdroje, pokud Aspose.Slides poskytuje nebo dokáže odvodit bezpečnou příponu souboru. Zdroje, které nejsou rozpoznány, zůstávají vloženy.

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

Přesné soubory závisí na obsahu prezentace a možnostech exportu. Například rastrové obrázky se obvykle exportují jako JPEG nebo PNG. Aspose.Slides může zvolit jiný obrazový kodek než ten použitý ve zdrojové prezentaci, pokud to vede k menšímu nebo vhodnějšímu souboru. Obrázky s průhledností se exportují jako PNG.

## **Volba URL pro nasazení**

Příklad používá relativní URL prefix: `assets/`. Pokud je `presentation.html` otevřen z `html-output/presentation.html`, prohlížeč načte `html-output/assets/resource-1.svg`.

Když jeden odkazovaný zdroj odkazuje na jiný odkazovaný zdroj, příklad používá parametr `referrer` v ILinkEmbedController::GetUrl a vrací pouze název souboru. Například pokud jsou `resource-1.svg` a `resource-4.jpg` oba v adresáři `assets`, SVG soubor by měl odkazovat na `resource-4.jpg`, nikoli na `assets/resource-4.jpg`.

Použijte jiný URL prefix, pokud jsou soubory nasazeny jinde:
- Použijte `assets/`, když je adresář s prostředky vedle souboru HTML.
- Použijte `../assets/`, když je adresář s prostředky o jednu úroveň nad souborem HTML.
- Použijte `https://cdn.example.com/presentations/job-123/assets/`, když jsou soubory nahrány na CDN nebo statický souborový server.

URL vrácená metodou ILinkEmbedController::GetUrl musí odpovídat finální nasazené lokaci souboru zapsaného metodou ILinkEmbedController::SaveExternal. V serverových aplikacích použijte jedinečný výstupní adresář nebo prefix v objektovém úložišti pro každou konverzní úlohu, aby nedošlo k přepsání souborů z jiného exportu.

## **Kdy místo toho vložit**

Vložené Base64 HTML je stále užitečné, když musí být výstup jedním souborem, například jako příloha e-mailu, offline náhled nebo dokument, který bude přesunut bez doprovodné složky s prostředky. Odkazované zdroje jsou vhodnější, když bude HTML slouženo webovou aplikací, uloženo v CMS, optimalizováno build pipeline nebo cachováno prohlížeči nezávisle na HTML.

## **Často kladené otázky**

**Mohu externě uložit jen obrázky a ostatní zdroje nechat vložené?**

Ano. V ILinkEmbedController::GetObjectStoringLocation vraťte `LinkEmbedDecision::Link` pouze pro typy obsahu, které chcete uložit jako samostatné soubory, a pro vše ostatní vraťte `LinkEmbedDecision::Embed`.

**Proč se přípona exportovaného obrázku liší od zdrojové prezentace?**

Aspose.Slides může během exportu HTML překódovat rastrové obrázky, aby zlepšil velikost nebo kompatibilitu s prohlížeči. Například obrázek ze zdrojového souboru může být zapsán jako JPEG nebo PNG v závislosti na výsledku renderování.

**Fungují relativní URL po přesunu souboru HTML?**

Relativní URL fungují pouze tehdy, když je zachována stejná relativní struktura složek. pokud HTML odkazuje na `assets/resource-1.png`, složka `assets` musí zůstat vedle souboru HTML, pokud nevytvoříte jiný URL prefix.

**Měly by serverové aplikace znovu použít stejný výstupní adresář?**

Ne. Použijte jedinečný výstupní adresář nebo prefix úložiště pro každou konverzní úlohu. Tím se zabrání kolizím názvů souborů a přepsání zdrojů jedním exportem jiným exportem.