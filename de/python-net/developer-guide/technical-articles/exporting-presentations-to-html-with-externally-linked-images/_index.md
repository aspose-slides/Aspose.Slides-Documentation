---
title: Exportieren von Präsentationen nach HTML mit extern verlinkten Bildern in Python
linktitle: Exportieren von Präsentationen nach HTML mit extern verlinkten Bildern
type: docs
weight: 100
url: /de/python-net/exporting-presentations-to-html-with-externally-linked-images/
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
- verknüpftes Bild
- extern verknüpftes Bild
- verknüpfte Ressource
- externe Ressource
- Python
- Aspose.Slides
description: "Exportieren von PowerPoint- und OpenDocument-Präsentationen nach HTML in Python mithilfe von Aspose.Slides, wobei Bilder als extern verlinkte Dateien gespeichert werden."
---
## **Übersicht**

Standardmäßig exportiert Aspose.Slides eine Präsentation in eine eigenständige HTML‑Datei. Bilder und weitere Ressourcen werden direkt in das HTML geschrieben, meist als Base64‑Daten. Das ist praktisch, wenn Sie eine einzige portable Datei benötigen, ist aber nicht immer das beste Format für eine Website, ein CMS oder eine serverseitige Konvertierungspipeline.

Verwenden Sie extern verlinkte Bilder, wenn Sie:

- die Größe des HTML‑Dokuments reduzieren;
- Bilder separat in einem Browser oder CDN zwischenspeichern;
- generierte Bilder nach dem Export prüfen, ersetzen, komprimieren oder nachbearbeiten;
- die Ausgabestruktur näher an das heranrücken, was eine Webanwendung erwartet.

Für den allgemeinen HTML‑Konvertierungs‑Workflow siehe [Convert PowerPoint Presentations to HTML](/slides/de/python-net/convert-powerpoint-to-html/). Dieser Artikel konzentriert sich auf den Bildverlinkungs‑Teil des Exports.

## **Wie der Export von verlinkten Bildern funktioniert**

In .NET und Java repräsentiert [ILinkEmbedController](https://reference.aspose.com/slides/de/python-net/aspose.slides.export/ilinkembedcontroller/) die Callback‑Schnittstelle, die vom Exporteur verwendet wird, um zu entscheiden, ob eine Ressource eingebettet oder verlinkt werden soll. In Python über .NET können Python‑Klassen diese .NET‑Callback‑Schnittstelle derzeit nicht direkt implementieren, daher ist der praktische Ablauf:

1. Exportiere die Präsentation nach HTML mit [HtmlOptions](https://reference.aspose.com/slides/de/python-net/aspose.slides.export/htmloptions/).
1. Verwende [SlideImageFormat](https://reference.aspose.com/slides/de/python-net/aspose.slides.export/slideimageformat/) mit [SVGOptions](https://reference.aspose.com/slides/de/python-net/aspose.slides.export/svgoptions/), damit die Folien im HTML als SVG dargestellt werden.
1. Verschiebe Base64‑Bilddaten aus HTML `data:`‑URLs in separate Dateien.
1. Ersetze die ursprünglichen `data:`‑URLs durch relative Links wie `assets/resource-1.jpg`.

Der Dateisystempfad und die Browser‑URL sind separate Aspekte. Zum Beispiel schreibt das unten stehende Beispiel Bilddateien auf die Festplatte nach `html-output/assets`, während das HTML relative URLs wie `assets/resource-1.jpg` enthält. Ein Browser löst diese URLs relativ zur HTML‑Datei auf, die den Link enthält.

## **HTML mit verlinkten Bildern exportieren**

Das folgende Python‑Beispiel erstellt ein Ausgabeverzeichnis, speichert die HTML‑Datei dort, legt extrahierte Bilder in einem Unterverzeichnis `assets` ab und wandelt Base64‑Bild‑URLs in relative Links um. Das Beispiel extrahiert gängige Base64‑Bildformate, wenn Aspose.Slides eine sichere Dateierweiterung bereitstellt. Nicht erkannte Data‑URLs bleiben eingebettet.

```python
import base64
import os
import re

import aspose.slides as slides
import aspose.slides.export as slides_export


EXTENSIONS_BY_CONTENT_TYPE = {
    "image/jpeg": ".jpg",
    "image/png": ".png",
    "image/gif": ".gif",
    "image/bmp": ".bmp",
    "image/svg+xml": ".svg",
    "image/tiff": ".tiff",
    "image/x-emf": ".emf",
    "image/x-wmf": ".wmf",
}

DATA_URI_PATTERN = re.compile(
    r"data:(?P<content_type>[-\w.+]+/[-\w.+]+);base64,(?P<data>[A-Za-z0-9+/=\r\n]+)"
)


def export_presentation_to_html_with_linked_images(
    input_file_path,
    output_directory,
    asset_directory_name="assets",
):
    asset_directory = os.path.join(output_directory, asset_directory_name)

    os.makedirs(output_directory, exist_ok=True)
    os.makedirs(asset_directory, exist_ok=True)

    html_options = slides_export.HtmlOptions()
    html_options.html_formatter = slides_export.HtmlFormatter.create_document_formatter("", False)
    html_options.slide_image_format = slides_export.SlideImageFormat.svg(
        slides_export.SVGOptions()
    )

    html_file_path = os.path.join(output_directory, "presentation.html")

    with slides.Presentation(input_file_path) as presentation:
        presentation.save(html_file_path, slides_export.SaveFormat.HTML, html_options)

    externalize_base64_images(html_file_path, asset_directory, asset_directory_name)


def externalize_base64_images(html_file_path, asset_directory, asset_directory_name):
    with open(html_file_path, "r", encoding="utf-8-sig") as html_file:
        html_content = html_file.read()

    saved_resource_names = {}
    resource_index = 1

    def replace_data_uri(match):
        nonlocal resource_index

        data_uri = match.group(0)
        if data_uri in saved_resource_names:
            return saved_resource_names[data_uri]

        content_type = match.group("content_type").lower()
        extension = EXTENSIONS_BY_CONTENT_TYPE.get(content_type)
        if extension is None:
            return data_uri

        encoded_data = match.group("data")
        image_data = base64.b64decode(encoded_data)
        if len(image_data) == 0:
            return data_uri

        file_name = f"resource-{resource_index}{extension}"
        resource_index += 1

        file_path = os.path.join(asset_directory, file_name)
        with open(file_path, "wb") as image_file:
            image_file.write(image_data)

        linked_url = f"{asset_directory_name}/{file_name}"
        saved_resource_names[data_uri] = linked_url
        return linked_url

    updated_html_content = DATA_URI_PATTERN.sub(replace_data_uri, html_content)

    with open(html_file_path, "w", encoding="utf-8", newline="\n") as html_file:
        html_file.write(updated_html_content)


input_file_path = "presentation.pptx"
output_directory = "html-output"

export_presentation_to_html_with_linked_images(input_file_path, output_directory)
```

Nach dem Export kann das Ausgabeverzeichnis diese Struktur haben:

```text
html-output/
  presentation.html
  assets/
    resource-1.jpg
    resource-2.png
```

Die genauen Dateien hängen vom Inhalt der Präsentation und den Exportoptionen ab. Rasterbilder werden beispielsweise häufig als JPEG oder PNG exportiert. Aspose.Slides kann einen anderen Bildcodec wählen als in der Ausgangspräsentation verwendet, wenn dadurch eine kleinere oder passendere Datei entsteht. Bilder mit Transparenz werden als PNG exportiert.

## **Auswahl von URLs für die Bereitstellung**

Das Beispiel verwendet ein relatives URL‑Präfix: `assets/`. Wenn `presentation.html` aus `html-output/presentation.html` geöffnet wird, lädt der Browser `html-output/assets/resource-1.jpg`.

Verwenden Sie einen anderen Asset‑Verzeichnisnamen oder passen Sie die generierten Links an, wenn die Dateien an anderer Stelle bereitgestellt werden:

- Verwenden Sie `assets/`, wenn das Asset‑Verzeichnis neben der HTML‑Datei liegt.
- Verwenden Sie `../assets/`, wenn das Asset‑Verzeichnis eine Ebene über der HTML‑Datei liegt.
- Verwenden Sie `https://cdn.example.com/presentations/job-123/assets/`, wenn die Dateien in ein CDN oder einen statischen Dateiserver hochgeladen werden.

In Server‑Anwendungen sollten Sie für jeden Konvertierungs‑Job ein eindeutiges Ausgabeverzeichnis oder ein Objekt‑Speicher‑Präfix verwenden, um das Überschreiben von Dateien aus einem anderen Export zu vermeiden.

## **Wann stattdessen einbetten**

Eingebettetes Base64‑HTML ist weiterhin nützlich, wenn die Ausgabe eine einzelne Datei sein muss, etwa als E‑Mail‑Anlage, Offline‑Vorschau oder Dokument, das ohne zugehörigen Asset‑Ordner verschoben wird. Verlinkte Bilder passen besser, wenn das HTML von einer Webanwendung bereitgestellt, in einem CMS gespeichert, durch eine Build‑Pipeline optimiert oder von Browsern unabhängig vom HTML zwischengespeichert wird.

## **FAQ**

**Kann ich nur Bilder externalisieren und andere Ressourcen eingebettet lassen?**

Ja. Das Beispiel extrahiert nur `image/*` Base64‑Data‑URLs, deren Content‑Types in `EXTENSIONS_BY_CONTENT_TYPE` aufgeführt sind. Andere Data‑URLs bleiben eingebettet.

**Warum unterscheidet sich die exportierte Bild-Erweiterung von der der Ausgangspräsentation?**

Aspose.Slides kann Rasterbilder beim HTML‑Export neu kodieren, um Größe oder Browser‑Kompatibilität zu verbessern. Beispielsweise kann ein Bild aus der Ausgangsdatei je nach Ergebnis als JPEG oder PNG geschrieben werden.

**Funktionieren relative URLs, nachdem ich die HTML‑Datei verschoben habe?**

Relative URLs funktionieren nur, wenn die gleiche relative Ordnerstruktur beibehalten wird. Wenn das HTML `assets/resource-1.png` referenziert, muss der `assets`‑Ordner neben der HTML‑Datei bleiben, es sei denn, Sie erzeugen ein anderes URL‑Präfix.

**Sollten Server‑Anwendungen denselben Ausgabordner wiederverwenden?**

Nein. Verwenden Sie für jeden Konvertierungs‑Job ein eindeutiges Ausgabeverzeichnis oder ein Speicher‑Präfix. Dies verhindert Dateinamen‑Kollisionen und dass ein Export Ressourcen eines anderen Exports überschreibt.