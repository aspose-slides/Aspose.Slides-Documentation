---
title: Präsentationen mit extern verlinkten Bildern nach HTML exportieren
type: docs
weight: 50
url: /de/cpp/exporting-presentations-to-html-with-externally-linked-images/
keywords:
- PowerPoint exportieren
- OpenDocument exportieren
- Präsentation exportieren
- Folie exportieren
- PPT exportieren
- PPTX exportieren
- ODP exportieren
- PowerPoint nach HTML
- OpenDocument nach HTML
- Präsentation nach HTML
- Folie nach HTML
- PPT nach HTML
- PPTX nach HTML
- ODP nach HTML
- verlinktes Bild
- extern verlinktes Bild
- verlinkte Ressource
- externe Ressource
- C++
- Aspose.Slides
description: "Exportieren Sie PowerPoint- und OpenDocument-Präsentationen nach HTML in C++ mit Aspose.Slides, wobei Bilder und andere Ressourcen als extern verlinkte Dateien gespeichert werden."
---
## **Übersicht**

Standardmäßig exportiert Aspose.Slides eine Präsentation in eine eigenständige HTML-Datei. Bilder und andere Ressourcen werden direkt in das HTML geschrieben, meist als Base64-Daten. Das ist praktisch, wenn Sie eine einzige portable Datei benötigen, ist aber nicht immer das beste Format für eine Website, ein CMS oder eine serverseitige Konvertierungspipeline.

Verwenden Sie extern verlinkte Ressourcen, wenn Sie:
- die Größe des HTML-Dokuments reduzieren;
- Bilder, Schriftarten, Audio oder Video separat in einem Browser oder CDN cachen;
- generierte Ressourcen nach dem Export prüfen, ersetzen, komprimieren oder nachbearbeiten;
- die Ausgabe‑Struktur näher an das halten, was eine Webanwendung erwartet.

Für den allgemeinen HTML‑Konvertierungs‑Workflow siehe [Convert PowerPoint Presentations to HTML](/slides/de/cpp/convert-powerpoint-to-html/). Dieser Artikel konzentriert sich auf den ressourcenverknüpfenden Teil des Exports.

## **Wie der Export verknüpfter Ressourcen funktioniert**

[ILinkEmbedController](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/ilinkembedcontroller/) lässt Ihre Anwendung entscheiden, für jede Ressource, ob der Exporter die Daten im HTML einbettet oder sie extern speichert und einen Link schreibt.

Die Schnittstelle hat drei Methoden:
- [ILinkEmbedController::GetObjectStoringLocation](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/ilinkembedcontroller/getobjectstoringlocation/) entscheidet, ob eine Ressource verlinkt oder eingebettet werden soll.
- [ILinkEmbedController::GetUrl](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/ilinkembedcontroller/geturl/) gibt die URL zurück, die in das erzeugte HTML oder in eine andere verknüpfte Ressource geschrieben wird.
- [ILinkEmbedController::SaveExternal](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/ilinkembedcontroller/saveexternal/) schreibt die verknüpften Ressourcendaten auf die Festplatte oder zu einem anderen Speicherziel.

Der Dateisystempfad und die Browser‑URL sind separate Angelegenheiten. Zum Beispiel schreibt das nachfolgende Beispiel Ressourcendateien nach `html-output/assets` auf die Festplatte, während das HTML relative URLs wie `assets/resource-1.svg` enthält. Ein Browser löst diese URLs relativ zu der Datei auf, die den Link enthält. Daher verwendet ein Link von `presentation.html` zu einer SVG‑Datei `assets/resource-1.svg`, während ein Link von dieser SVG‑Datei zu einem im selben `assets`‑Ordner gespeicherten Bild `resource-4.jpg` verwendet.

## **HTML mit verknüpften Ressourcen exportieren**

Das folgende C++‑Beispiel erstellt ein Ausgabeverzeichnis, speichert die HTML‑Datei dort und legt verknüpfte Ressourcen in einem Unterverzeichnis `assets` ab. Der Controller verknüpft gängige Bild‑, Schrift‑, Audio‑, Video‑ und CSS‑Ressourcen, wenn Aspose.Slides eine sichere Dateierweiterung bereitstellt oder ableiten kann. Nicht erkannte Ressourcen bleiben eingebettet.

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

Nach dem Export hat der Ausgabordner diese Struktur:

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

Die genauen Dateien hängen vom Inhalt der Präsentation und den Exportoptionen ab. Rasterbilder werden beispielsweise häufig als JPEG oder PNG exportiert. Aspose.Slides kann einen anderen Bild‑Codec wählen als im Quellpräsentation verwendet wird, wenn dies zu einer kleineren oder besser geeigneten Datei führt. Bilder mit Transparenz werden als PNG exportiert.

## **Auswahl von URLs für die Bereitstellung**

Das Beispiel verwendet ein relatives URL‑Präfix: `assets/`. Wenn `presentation.html` von `html-output/presentation.html` geöffnet wird, lädt der Browser `html-output/assets/resource-1.svg`.

Wenn eine verknüpfte Ressource auf eine andere verknüpfte Ressource verweist, verwendet das Beispiel den Parameter `referrer` in [ILinkEmbedController::GetUrl](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/ilinkembedcontroller/geturl/) und gibt nur den Dateinamen zurück. Zum Beispiel, wenn `resource-1.svg` und `resource-4.jpg` beide im Ordner `assets` liegen, sollte die SVG‑Datei auf `resource-4.jpg` verweisen, nicht auf `assets/resource-4.jpg`.

Verwenden Sie ein anderes URL‑Präfix, wenn die Dateien woanders bereitgestellt werden:
- Verwenden Sie `assets/`, wenn das Asset‑Verzeichnis neben der HTML‑Datei liegt.
- Verwenden Sie `../assets/`, wenn das Asset‑Verzeichnis eine Ebene über der HTML‑Datei liegt.
- Verwenden Sie `https://cdn.example.com/presentations/job-123/assets/`, wenn die Dateien zu einem CDN oder statischen Dateiserver hochgeladen werden.

Die von [ILinkEmbedController::GetUrl](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/ilinkembedcontroller/geturl/) zurückgegebene URL muss mit dem endgültigen Bereitstellungsort der Datei übereinstimmen, die von [ILinkEmbedController::SaveExternal](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/ilinkembedcontroller/saveexternal/) geschrieben wird. In Server‑Anwendungen verwenden Sie für jeden Konvertierungs‑Job ein eindeutiges Ausgabeverzeichnis oder ein Objekt‑Speicher‑Präfix, um ein Überschreiben von Dateien aus einem anderen Export zu vermeiden.

## **Wann stattdessen einbetten**

Eingebettetes Base64‑HTML ist weiterhin nützlich, wenn die Ausgabe eine einzelne Datei sein muss, z. B. ein E‑Mail‑Anhang, eine Offline‑Vorschau oder ein Dokument, das ohne unterstützenden Asset‑Ordner verschoben wird. Verknüpfte Ressourcen passen besser, wenn das HTML von einer Webanwendung bereitgestellt, in einem CMS gespeichert, durch eine Build‑Pipeline optimiert oder von Browsern unabhängig vom HTML zwischengespeichert wird.

## **FAQ**

**Kann ich nur Bilder externalisieren und andere Ressourcen eingebettet belassen?**

Ja. In [ILinkEmbedController::GetObjectStoringLocation](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/ilinkembedcontroller/getobjectstoringlocation/) geben Sie `LinkEmbedDecision::Link` nur für die Inhaltstypen zurück, die Sie als separate Dateien speichern möchten, und geben `LinkEmbedDecision::Embed` für alles andere zurück.

**Warum weicht die exportierte Bild-Erweiterung von der Quellpräsentation ab?**

Aspose.Slides kann Rasterbilder beim HTML‑Export erneut kodieren, um die Größe zu reduzieren oder die Browser‑Kompatibilität zu verbessern. Beispielsweise kann ein Bild aus der Quelldatei je nach Ergebnis als JPEG oder PNG geschrieben werden.

**Funktionieren relative URLs, nachdem ich die HTML‑Datei verschoben habe?**

Relative URLs funktionieren nur, wenn die gleiche relative Ordnerstruktur erhalten bleibt. Wenn das HTML `assets/resource-1.png` referenziert, muss der Ordner `assets` neben der HTML‑Datei bleiben, es sei denn, Sie erzeugen ein anderes URL‑Präfix.

**Sollten Server‑Anwendungen denselben Ausgabordner wiederverwenden?**

Nein. Verwenden Sie für jeden Konvertierungs‑Job ein eindeutiges Ausgabeverzeichnis oder Speicher‑Präfix. Dies verhindert Dateinamen‑Kollisionen und verhindert, dass ein Export Ressourcen eines anderen Exports überschreibt.