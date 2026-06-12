---
title: Esporta presentazioni in HTML con immagini collegate esternamente
type: docs
weight: 50
url: /it/cpp/exporting-presentations-to-html-with-externally-linked-images/
keywords:
- esporta PowerPoint
- esporta OpenDocument
- esporta presentazione
- esporta diapositiva
- esporta PPT
- esporta PPTX
- esporta ODP
- PowerPoint in HTML
- OpenDocument in HTML
- presentazione in HTML
- diapositiva in HTML
- PPT in HTML
- PPTX in HTML
- ODP in HTML
- immagine collegata
- immagine collegata esternamente
- risorsa collegata
- risorsa esterna
- C++
- Aspose.Slides
description: "Esporta presentazioni PowerPoint e OpenDocument in HTML in C++ utilizzando Aspose.Slides con immagini e altre risorse salvate come file collegati esternamente."
---
## **Panoramica**

Per impostazione predefinita, Aspose.Slides esporta una presentazione in un file HTML autonomo. Immagini e altre risorse vengono scritte direttamente nell'HTML, solitamente come dati Base64. Questo è comodo quando serve un unico file portatile, ma non è sempre il formato migliore per un sito web, un CMS o una pipeline di conversione lato server.

Usa risorse collegate esternamente quando desideri:

- ridurre le dimensioni del documento HTML;
- memorizzare nella cache immagini, font, audio o video separatamente in un browser o CDN;
- ispezionare, sostituire, comprimere o post‑elaborare le risorse generate dopo l'esportazione;
- mantenere la struttura di output più vicina a quella che un'applicazione web si aspetta.

Per il flusso di lavoro generale di conversione HTML, vedi [Converti presentazioni PowerPoint in HTML](/slides/it/cpp/convert-powerpoint-to-html/). Questo articolo si concentra sulla parte di collegamento delle risorse dell'esportazione.

## **Come funziona l'esportazione con risorse collegate**

[ILinkEmbedController](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/ilinkembedcontroller/) consente alla tua applicazione di decidere, risorsa per risorsa, se l'esportatore incorpora i dati nell'HTML o li salva esternamente scrivendo un collegamento.

L'interfaccia dispone di tre metodi:

- [ILinkEmbedController::GetObjectStoringLocation](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/ilinkembedcontroller/getobjectstoringlocation/) decide se una risorsa deve essere collegata o incorporata.
- [ILinkEmbedController::GetUrl](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/ilinkembedcontroller/geturl/) restituisce l'URL che verrà scritto nell'HTML generato o in un'altra risorsa collegata.
- [ILinkEmbedController::SaveExternal](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/ilinkembedcontroller/saveexternal/) scrive i dati della risorsa collegata su disco o su un altro target di archiviazione.

Il percorso del file system e l'URL del browser sono preoccupazioni separate. Ad esempio, il campione sotto scrive i file di risorsa in `html-output/assets` su disco, mentre l'HTML contiene URL relativi come `assets/resource-1.svg`. Un browser risolve quegli URL in base al file che contiene il collegamento. Pertanto, un collegamento da `presentation.html` a un file SVG usa `assets/resource-1.svg`, mentre un collegamento da quel file SVG a un'immagine salvata nella stessa cartella `assets` usa `resource-4.jpg`.

## **Esporta HTML con risorse collegate**

Il seguente esempio C++ crea una cartella di output, salva il file HTML lì e memorizza le risorse collegate in una sottocartella `assets`. Il controller collega le risorse comuni di immagine, font, audio, video e CSS quando Aspose.Slides fornisce o può dedurre un'estensione di file sicura. Le risorse non riconosciute rimangono incorporate.

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

Dopo l'esportazione, la cartella di output ha questa struttura:

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

I file esatti dipendono dal contenuto della presentazione e dalle opzioni di esportazione. Ad esempio, le immagini raster sono comunemente esportate come JPEG o PNG. Aspose.Slides può scegliere un codec immagine diverso da quello usato nella presentazione di origine quando ciò produce un file più piccolo o più adatto. Le immagini con trasparenza sono esportate come PNG.

## **Scelta degli URL per il deployment**

Il campione utilizza un prefisso URL relativo: `assets/`. Se `presentation.html` viene aperto da `html-output/presentation.html`, il browser carica `html-output/assets/resource-1.svg`.

Quando una risorsa collegata fa riferimento a un'altra risorsa collegata, il campione utilizza il parametro `referrer` in [ILinkEmbedController::GetUrl](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/ilinkembedcontroller/geturl/) e restituisce solo il nome del file. Ad esempio, se `resource-1.svg` e `resource-4.jpg` sono entrambi nella cartella `assets`, il file SVG dovrebbe riferirsi a `resource-4.jpg`, non a `assets/resource-4.jpg`.

Usa un prefisso URL diverso quando i file vengono distribuiti altrove:

- Usa `assets/` quando la directory delle risorse è accanto al file HTML.
- Usa `../assets/` quando la directory delle risorse è un livello sopra il file HTML.
- Usa `https://cdn.example.com/presentations/job-123/assets/` quando i file vengono caricati su un CDN o server di file statici.

L'URL restituito da [ILinkEmbedController::GetUrl](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/ilinkembedcontroller/geturl/) deve corrispondere alla posizione finale di distribuzione del file scritto da [ILinkEmbedController::SaveExternal](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/ilinkembedcontroller/saveexternal/). Nelle applicazioni server, utilizza una directory di output o un prefisso di storage unici per ogni lavoro di conversione per evitare di sovrascrivere file da un'altra esportazione.

## **Quando incorporare invece**

HTML con Base64 incorporato è ancora utile quando l'output deve essere un unico file, ad esempio un allegato email, un'anteprima offline o un documento che verrà spostato senza una cartella di risorse di supporto. Le risorse collegate sono più adatte quando l'HTML sarà servito da un'applicazione web, archiviato in un CMS, ottimizzato da una pipeline di build o memorizzato nella cache dei browser in modo indipendente dall'HTML.

## **FAQ**

**Posso esternalizzare solo le immagini e mantenere le altre risorse incorporate?**

Sì. In [ILinkEmbedController::GetObjectStoringLocation](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/ilinkembedcontroller/getobjectstoringlocation/), restituisci `LinkEmbedDecision::Link` solo per i tipi di contenuto che desideri salvare come file separati, e restituisci `LinkEmbedDecision::Embed` per tutto il resto.

**Perché l'estensione dell'immagine esportata differisce da quella della presentazione di origine?**

Aspose.Slides può ricodificare le immagini raster durante l'esportazione HTML per migliorare dimensione o compatibilità con il browser. Ad esempio, un'immagine dal file di origine può essere scritta come JPEG o PNG a seconda del risultato renderizzato.

**Gli URL relativi funzionano dopo aver spostato il file HTML?**

Gli URL relativi funzionano solo quando la stessa struttura di cartelle relativa è preservata. Se l'HTML fa riferimento a `assets/resource-1.png`, la cartella `assets` deve rimanere accanto al file HTML a meno che non si generi un prefisso URL diverso.

**Le applicazioni server dovrebbero riutilizzare la stessa cartella di output?**

No. Usa una directory di output o un prefisso di storage unici per ogni lavoro di conversione. Questo evita collisioni di nomi file e impedisce a un'esportazione di sovrascrivere le risorse generate da un'altra esportazione.