---
title: Präsentationen in HTML exportieren mit extern verlinkten Bildern
type: docs
weight: 100
url: /de/python-java/exporting-presentations-to-html-with-externally-linked-images/
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
- Python
- Java
- Aspose.Slides
description: "Exportieren Sie PowerPoint- und OpenDocument-Präsentationen nach HTML in Python mit Aspose.Slides, wobei Bilder und andere Ressourcen als extern verlinkte Dateien gespeichert werden."
---
## **Übersicht**

Standardmäßig exportiert Aspose.Slides eine Präsentation in eine eigenständige HTML‑Datei. Bilder und andere Ressourcen werden direkt in das HTML geschrieben, normalerweise als Base64‑Daten. Das ist praktisch, wenn Sie eine einzige portable Datei benötigen, aber es ist nicht immer das beste Format für eine Website, ein CMS oder eine serverseitige Konvertierungspipeline.

Verwenden Sie extern verlinkte Ressourcen, wenn Sie:

- die Größe des HTML‑Dokuments reduzieren;
- Bilder, Schriftarten, Audio oder Video separat in einem Browser oder CDN zwischenspeichern;
- generierte Ressourcen nach dem Export prüfen, ersetzen, komprimieren oder nachbearbeiten;
- die Ausgabestruktur näher an das halten, was eine Webanwendung erwartet.

Für den allgemeinen HTML‑Konvertierungs‑Workflow siehe [Convert PowerPoint Presentations to HTML](/slides/de/python-java/convert-powerpoint-to-html/). Dieser Artikel konzentriert sich auf den ressourcenverlinkenden Teil des Exports.

## **Wie der Export verknüpfter Ressourcen funktioniert**

`ILinkEmbedController` lässt Ihre Anwendung ressourcenweise entscheiden, ob der Exporteur die Daten in das HTML einbettet oder extern speichert und einen Link schreibt.

Die Schnittstelle hat drei Methoden:

- `ILinkEmbedController.getObjectStoringLocation` entscheidet, ob eine Ressource verlinkt oder eingebettet werden soll.
- `ILinkEmbedController.getUrl` gibt die URL zurück, die in das erzeugte HTML oder in eine andere verlinkte Ressource geschrieben wird.
- `ILinkEmbedController.saveExternal` schreibt die verlinkten Ressourcendaten auf die Festplatte oder zu einem anderen Speicherziel.

Der Dateisystempfad und die Browser‑URL sind getrennte Angelegenheiten. Zum Beispiel schreibt das untenstehende Beispiel Ressourcendateien nach `html-output/assets` auf die Festplatte, während das HTML relative URLs wie `assets/resource-1.svg` enthält. Ein Browser löst diese URLs relativ zu der Datei auf, die den Link enthält. Daher verwendet ein Link von `presentation.html` zu einer SVG‑Datei `assets/resource-1.svg`, während ein Link von dieser SVG‑Datei zu einem Bild, das im selben `assets`‑Ordner gespeichert ist, `resource-4.jpg` verwendet.

## **HTML mit verknüpften Ressourcen exportieren**

Das folgende Python‑Beispiel erstellt ein Ausgabeverzeichnis, speichert die HTML‑Datei dort und legt verknüpfte Ressourcen in einem Unterverzeichnis `assets` ab. Der Controller verlinkt gängige Bild‑, Schrift‑, Audio‑, Video‑ und CSS‑Ressourcen, wenn Aspose.Slides eine sichere Dateierweiterung bereitstellt oder ableiten kann. Nicht erkannte Ressourcen bleiben eingebettet.

```python
import jpype
import asposeslides
from pathlib import Path

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlFormatter, HtmlOptions, LinkEmbedDecision, Presentation, SVGOptions, SaveFormat, SlideImageFormat


class ExternalResourceController:
    EXTENSIONS_BY_CONTENT_TYPE = {
        "image/jpeg": ".jpg",
        "image/png": ".png",
        "image/gif": ".gif",
        "image/bmp": ".bmp",
        "image/svg+xml": ".svg",
        "image/tiff": ".tiff",
        "image/x-emf": ".emf",
        "image/x-wmf": ".wmf",
        "font/woff": ".woff",
        "font/woff2": ".woff2",
        "font/ttf": ".ttf",
        "application/font-woff": ".woff",
        "application/vnd.ms-fontobject": ".eot",
        "application/x-font-ttf": ".ttf",
        "text/css": ".css",
        "audio/mpeg": ".mp3",
        "audio/mp4": ".m4a",
        "audio/wav": ".wav",
        "video/mp4": ".mp4",
        "video/webm": ".webm",
    }

    def __init__(self, asset_directory, asset_url_prefix):
        self.asset_directory = asset_directory
        normalized_prefix = asset_url_prefix.replace("\\", "/") if asset_url_prefix else ""
        self.asset_url_prefix = normalized_prefix.rstrip("/") + "/" if normalized_prefix else ""
        self.file_names_by_resource_id = {}

    def getObjectStoringLocation(self, resource_id, entity_data, semantic_name, content_type, recommended_extension):
        extension = self.resolve_extension(content_type, recommended_extension)
        if extension is None:
            return LinkEmbedDecision.Embed

        self.file_names_by_resource_id[resource_id] = f"resource-{resource_id}{extension}"
        return LinkEmbedDecision.Link

    def getUrl(self, resource_id, referrer):
        file_name = self.file_names_by_resource_id.get(resource_id)
        if file_name is None:
            return None
        if referrer in self.file_names_by_resource_id:
            return file_name
        return self.asset_url_prefix + file_name

    def saveExternal(self, resource_id, entity_data):
        file_name = self.file_names_by_resource_id.get(resource_id)
        if file_name is None:
            print(f"Resource {resource_id} was not registered for external storage.")
            return
        if entity_data is None or len(entity_data) == 0:
            print(f"Resource {resource_id} contains no data and cannot be saved.")
            return

        try:
            self.asset_directory.mkdir(parents=True, exist_ok=True)
            file_path = self.asset_directory / file_name
            resource_data = bytes(entity_data)
            file_path.write_bytes(resource_data)
        except OSError as error:
            print(f"Failed to save external resource {resource_id}: {error}")

    @classmethod
    def resolve_extension(cls, content_type, recommended_extension):
        content_type = str(content_type) if content_type is not None else ""
        mapped_extension = cls.EXTENSIONS_BY_CONTENT_TYPE.get(content_type)
        if mapped_extension is not None:
            return mapped_extension
        if not content_type.lower().startswith(("image/", "font/", "audio/", "video/")):
            return None
        if recommended_extension is None:
            return None
        extension_characters = str(recommended_extension).strip().lstrip(".")
        if not extension_characters or not extension_characters.isalnum():
            return None
        return "." + extension_characters.lower()


input_file_path = Path("presentation.pptx")
output_directory = Path("html-output")
asset_directory_name = "assets"
asset_directory = output_directory / asset_directory_name

output_directory.mkdir(parents=True, exist_ok=True)
asset_directory.mkdir(parents=True, exist_ok=True)

asset_url_prefix = asset_directory_name + "/"
controller = ExternalResourceController(asset_directory, asset_url_prefix)
controller_proxy = jpype.JProxy("com.aspose.slides.ILinkEmbedController", inst=controller)
svg_options = SVGOptions(controller_proxy)
slide_image_format = SlideImageFormat.svg(svg_options)

html_options = HtmlOptions(controller_proxy)
html_formatter = HtmlFormatter.createDocumentFormatter("", False)
html_options.setHtmlFormatter(html_formatter)
html_options.setSlideImageFormat(slide_image_format)

presentation = Presentation(str(input_file_path))
try:
    html_file_path = output_directory / "presentation.html"
    presentation.save(str(html_file_path), SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

Nach dem Export hat der Ausgabefolder folgende Struktur:

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

Die genauen Dateien hängen vom Inhalt der Präsentation und den Exportoptionen ab. Rasterbilder werden beispielsweise häufig als JPEG oder PNG exportiert. Aspose.Slides kann ein anderes Bild‑Codec wählen als das in der Quellpräsentation verwendete, wenn dadurch eine kleinere oder besser geeignete Datei entsteht. Bilder mit Transparenz werden als PNG exportiert.

## **Auswahl von URLs für die Bereitstellung**

Das Beispiel verwendet ein relatives URL‑Präfix: `assets/`. Wird `presentation.html` aus `html-output/presentation.html` geöffnet, lädt der Browser `html-output/assets/resource-1.svg`.

Wenn eine verknüpfte Ressource auf eine andere verknüpfte Ressource verweist, nutzt das Beispiel den Parameter `referrer` in `ILinkEmbedController.getUrl` und gibt nur den Dateinamen zurück. Wenn also `resource-1.svg` und `resource-4.jpg` beide im `assets`‑Ordner liegen, sollte die SVG‑Datei auf `resource-4.jpg` verweisen, nicht auf `assets/resource-4.jpg`.

Verwenden Sie ein anderes URL‑Präfix, wenn die Dateien an anderer Stelle bereitgestellt werden:

- Verwenden Sie `assets/`, wenn das Asset‑Verzeichnis neben der HTML‑Datei liegt.
- Verwenden Sie `../assets/`, wenn das Asset‑Verzeichnis eine Ebene über der HTML‑Datei liegt.
- Verwenden Sie `https://cdn.example.com/presentations/job-123/assets/`, wenn die Dateien in ein CDN oder einen statischen Dateiserver hochgeladen werden.

Die von `ILinkEmbedController.getUrl` zurückgegebene URL muss mit dem endgültigen Bereitstellungsort der von `ILinkEmbedController.saveExternal` geschriebenen Datei übereinstimmen. In Server‑Anwendungen sollten Sie für jeden Konvertierungs‑Job ein einzigartiges Ausgabeverzeichnis oder einen eigenen Objekt‑Storage‑Präfix verwenden, um ein Überschreiben von Dateien aus einem anderen Export zu vermeiden.

## **Wann stattdessen einbetten**

Eingebettetes Base64‑HTML ist weiterhin nützlich, wenn die Ausgabe eine einzelne Datei sein muss, etwa als E‑Mail‑Anhang, Offline‑Vorschau oder Dokument, das ohne zugehörigen Asset‑Ordner verschoben wird. Verknüpfte Ressourcen passen besser, wenn das HTML von einer Webanwendung bereitgestellt, in einem CMS gespeichert, durch eine Build‑Pipeline optimiert oder von Browsern unabhängig vom HTML gecached wird.

## **FAQ**

**Kann ich nur Bilder auslagern und andere Ressourcen eingebettet lassen?**

Ja. In `ILinkEmbedController.getObjectStoringLocation` geben Sie [LinkEmbedDecision.Link](https://reference.aspose.com/slides/de/python-java/aspose.slides/linkembeddecision/#Link) nur für die Inhaltstypen zurück, die Sie als separate Dateien speichern möchten, und geben [LinkEmbedDecision.Embed](https://reference.aspose.com/slides/de/python-java/aspose.slides/linkembeddecision/#Embed) für alles andere zurück.

**Warum unterscheidet sich die exportierte Bilddateierweiterung von der der Quellpräsentation?**

Aspose.Slides kann Rasterbilder während des HTML‑Exports neu kodieren, um Größe oder Browser‑Kompatibilität zu verbessern. Beispielsweise kann ein Bild aus der Quelldatei je nach Ergebnis als JPEG oder PNG geschrieben werden.

**Funktionieren relative URLs, nachdem ich die HTML‑Datei verschoben habe?**

Relative URLs funktionieren nur, wenn die gleiche relative Ordnerstruktur erhalten bleibt. Wenn das HTML auf `assets/resource-1.png` verweist, muss der `assets`‑Ordner neben der HTML‑Datei bleiben, es sei denn, Sie erzeugen ein anderes URL‑Präfix.

**Sollten Serveranwendungen denselben Ausgabepfad wiederverwenden?**

Nein. Verwenden Sie für jeden Konvertierungs‑Job ein einzigartiges Ausgabeverzeichnis oder einen Speicher‑Präfix. Das verhindert Dateikollisionen und verhindert, dass ein Export Ressourcen eines anderen Exports überschreibt.