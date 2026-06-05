---
title: Präsentationen nach HTML exportieren mit extern verknüpften Bildern
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
- PowerPoint zu HTML
- OpenDocument zu HTML
- Präsentation zu HTML
- Folie zu HTML
- PPT zu HTML
- PPTX zu HTML
- ODP zu HTML
- verknüpftes Bild
- extern verknüpftes Bild
- verknüpfte Ressource
- externe Ressource
- C++
- Aspose.Slides
description: "Exportieren Sie PowerPoint- und OpenDocument-Präsentationen nach HTML in C++ mit Aspose.Slides, wobei Bilder und andere Ressourcen als extern verknüpfte Dateien gespeichert werden."
---
## **Übersicht**

Standardmäßig exportiert Aspose.Slides eine Präsentation in eine eigenständige HTML‑Datei. Bilder und andere Ressourcen werden direkt in das HTML geschrieben, meist als Base64‑Daten. Das ist praktisch, wenn Sie eine portable Datei benötigen, ist jedoch nicht immer das beste Format für eine Website, ein CMS oder eine serverseitige Konvertierungspipeline.

Verwenden Sie extern verknüpfte Ressourcen, wenn Sie:

- die Größe des HTML‑Dokuments reduzieren möchten;
- Bilder, Schriften, Audio oder Video getrennt im Browser oder CDN zwischenspeichern;
- generierte Ressourcen nach dem Export inspizieren, ersetzen, komprimieren oder nachbearbeiten wollen;
- die Ausgabestruktur näher an dem halten möchten, was eine Webanwendung erwartet.

Für den allgemeinen HTML‑Konvertierungs‑Workflow siehe [PowerPoint-Präsentationen in HTML konvertieren](/slides/de/cpp/convert-powerpoint-to-html/). Dieser Artikel konzentriert sich auf den Teil des Exports, bei dem Ressourcen verlinkt werden.

## **Wie der Export verknüpfter Ressourcen funktioniert**

[ILinkEmbedController](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/ilinkembedcontroller/) lässt Ihre Anwendung für jede Ressource entscheiden, ob der Exporteur die Daten in das HTML einbettet oder extern speichert und einen Link schreibt.

Das Interface besitzt drei Methoden:

- [ILinkEmbedController::GetObjectStoringLocation](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/ilinkembedcontroller/getobjectstoringlocation/) entscheidet, ob eine Ressource verlinkt oder eingebettet werden soll.
- [ILinkEmbedController::GetUrl](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/ilinkembedcontroller/geturl/) liefert die URL, die in das erzeugte HTML oder in eine andere verknüpfte Ressource geschrieben wird.
- [ILinkEmbedController::SaveExternal](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/ilinkembedcontroller/saveexternal/) schreibt die verknüpfte Ressourcendaten auf die Festplatte oder in ein anderes Speicherziel.

Der Dateisystempfad und die Browser‑URL sind getrennte Aspekte. Zum Beispiel schreibt das nachfolgende Beispiel Ressourcendateien auf die Festplatte nach `html-output/assets`, während das HTML relative URLs wie `assets/resource-1.svg` enthält. Ein Browser löst diese URLs relativ zur Datei auf, die den Link enthält. Daher verwendet ein Link von `presentation.html` zu einer SVG‑Datei `assets/resource-1.svg`, während ein Link von dieser SVG‑Datei zu einem Bild im selben `assets`‑Ordner `resource-4.jpg` verwendet.

## **HTML mit verknüpften Ressourcen exportieren**

Das folgende C++‑Beispiel erstellt ein Ausgabeverzeichnis, speichert die HTML‑Datei dort und legt verknüpfte Ressourcen in einem Unterverzeichnis `assets` ab. Der Controller verlinkt gängige Bild‑, Schrift‑, Audio‑, Video‑ und CSS‑Ressourcen, wenn Aspose.Slides eine sichere Dateierweiterung bereitstellt oder ableiten kann. Nicht erkannte Ressourcen bleiben eingebettet.

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

Nach dem Export hat der Ausgabordner folgende Struktur:

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

Die genauen Dateien hängen vom Inhalt der Präsentation und den Exporteinstellungen ab. Rasterbilder werden beispielsweise häufig als JPEG oder PNG exportiert. Aspose.Slides kann einen anderen Bild‑Codec wählen als im Quell‑Presentation verwendet, wenn das zu einer kleineren oder besser geeigneten Datei führt. Bilder mit Transparenz werden als PNG exportiert.

## **Auswahl von URLs für die Bereitstellung**

Das Beispiel verwendet ein relatives URL‑Präfix: `assets/`. Wenn `presentation.html` aus `html-output/presentation.html` geöffnet wird, lädt der Browser `html-output/assets/resource-1.svg`.

Wenn eine verknüpfte Ressource auf eine andere verknüpfte Ressource verweist, nutzt das Beispiel den Parameter `referrer` in [ILinkEmbedController::GetUrl](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/ilinkembedcontroller/geturl/) und gibt nur den Dateinamen zurück. Beispiel: Befinden sich `resource-1.svg` und `resource-4.jpg` beide im Ordner `assets`, sollte die SVG‑Datei auf `resource-4.jpg` verweisen, nicht auf `assets/resource-4.jpg`.

Verwenden Sie ein anderes URL‑Präfix, wenn die Dateien an anderer Stelle bereitgestellt werden:

- Verwenden Sie `assets/`, wenn das Asset‑Verzeichnis neben der HTML‑Datei liegt.
- Verwenden Sie `../assets/`, wenn das Asset‑Verzeichnis eine Ebene über der HTML‑Datei liegt.
- Verwenden Sie `https://cdn.example.com/presentations/job-123/assets/`, wenn die Dateien in ein CDN oder einen statischen Dateiserver hochgeladen werden.

Die von [ILinkEmbedController::GetUrl](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/ilinkembedcontroller/geturl/) zurückgegebene URL muss mit dem endgültigen Bereitstellungsort der Datei übereinstimmen, die von [ILinkEmbedController::SaveExternal](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/ilinkembedcontroller/saveexternal/) geschrieben wird. In Server‑Anwendungen sollte für jeden Konvertierungsauftrag ein eindeutiges Ausgabeverzeichnis oder ein eindeutiges Präfix im Objektspeicher verwendet werden, um das Überschreiben von Dateien aus anderen Exporten zu vermeiden.

## **Wann stattdessen einbetten**

Eingebettetes Base64‑HTML ist weiterhin nützlich, wenn die Ausgabe eine einzelne Datei sein muss, etwa als E‑Mail‑Anhang, Offline‑Vorschau oder Dokument, das ohne unterstützenden Asset‑Ordner verschoben wird. Verknüpfte Ressourcen eignen sich besser, wenn das HTML von einer Webanwendung bereitgestellt, in einem CMS gespeichert, von einer Build‑Pipeline optimiert oder von Browsern unabhängig vom HTML gecacht wird.

## **FAQ**

**Kann ich nur Bilder externalisieren und andere Ressourcen eingebettet lassen?**

Ja. In [ILinkEmbedController::GetObjectStoringLocation](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/ilinkembedcontroller/getobjectstoringlocation/) geben Sie `LinkEmbedDecision::Link` nur für die Inhaltstypen zurück, die Sie als separate Dateien speichern möchten, und `LinkEmbedDecision::Embed` für alles andere.

**Warum unterscheidet sich die exportierte Bilddateierweiterung von der der Quelldatei?**

Aspose.Slides kann Rasterbilder während des HTML‑Exports neu kodieren, um die Dateigröße zu reduzieren oder die Browser‑Kompatibilität zu verbessern. Beispielsweise kann ein Bild aus der Quelldatei je nach Ergebnis als JPEG oder PNG geschrieben werden.

**Funktionieren relative URLs, wenn ich die HTML‑Datei verschiebe?**

Relative URLs funktionieren nur, wenn die gleiche relative Ordnerstruktur erhalten bleibt. Verweist das HTML auf `assets/resource-1.png`, muss der `assets`‑Ordner neben der HTML‑Datei bleiben, es sei denn, Sie erzeugen ein anderes URL‑Präfix.

**Sollten Server‑Anwendungen denselben Ausgabordner wiederverwenden?**

Nein. Verwenden Sie für jeden Konvertierungsauftrag ein eindeutiges Ausgabeverzeichnis oder ein eindeutiges Speicher‑Präfix. Das verhindert Dateinamen‑Kollisionen und das Überschreiben von Ressourcen durch andere Exporte.