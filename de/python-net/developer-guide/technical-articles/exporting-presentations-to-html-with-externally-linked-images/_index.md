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
- PowerPoint zu HTML
- OpenDocument zu HTML
- Präsentation zu HTML
- Folie zu HTML
- PPT zu HTML
- PPTX zu HTML
- ODP zu HTML
- verknüpftes Bild
- extern verknüpftes Bild
- Python
- Aspose.Slides
description: "Erfahren Sie, wie Sie Präsentationen in Aspose.Slides für Python via .NET mit extern verlinkten Bildern nach HTML exportieren, inklusive PowerPoint- und OpenDocument-Formaten."
---

{{% alert color="primary" %}} 

Der Export von Präsentation zu HTML ermöglicht es Ihnen, Folgendes anzugeben:

1. welche Ressourcen in die resultierende HTML-Datei eingebettet werden und
1. welche Ressourcen extern gespeichert und aus der HTML-Datei referenziert werden.

{{% /alert %}} 

## **Hintergrund**

Standardmäßig bettet der HTML-Export alle Ressourcen direkt in das HTML ein, wobei Base64-Kodierung verwendet wird. Dadurch entsteht eine einzige, eigenständige HTML-Datei, die für Ansicht und Verteilung praktisch ist. Dieser Ansatz hat jedoch Nachteile:

* Die resultierende Datei ist aufgrund des Base64-Overheads deutlich größer als die ursprünglichen Ressourcen.
* Eingebettete Bilder und andere Assets sind schwer zu aktualisieren oder zu ersetzen.

## **Alternativer Ansatz**

Einen alternativen Ansatz, der [ILinkEmbedController](https://reference.aspose.com/slides/python-net/aspose.slides.export/ilinkembedcontroller/) verwendet, vermeidet diese Einschränkungen.

Die untenstehende `LinkController`-Klasse implementiert [ILinkEmbedController](https://reference.aspose.com/slides/python-net/aspose.slides.export/ilinkembedcontroller/) und wird dem Konstruktor von [HtmlOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/htmloptions/__init__/#ilinkembedcontroller) übergeben. Die Klasse stellt drei Methoden bereit, die steuern, wie Ressourcen während des HTML-Exports eingebettet oder verlinkt werden:

[get_object_storing_location(id, entity_data, semantic_name, content_type, recommended_extension)](https://reference.aspose.com/slides/python-net/aspose.slides.export/ilinkembedcontroller/get_object_storing_location/#int-bytes-str-str-str): Aufgerufen, wenn der Exporter auf eine Ressource stößt und entscheiden muss, wo sie gespeichert wird. Die wichtigsten Parameter sind `id` (die eindeutige Kennung der Ressource für diesen Exportlauf) und `content_type` (der MIME‑Typ der Ressource). Gibt [LinkEmbedDecision.LINK](https://reference.aspose.com/slides/python-net/aspose.slides.export/linkembeddecision/) zurück, um die Ressource zu verlinken, oder [LinkEmbedDecision.EMBED](https://reference.aspose.com/slides/python-net/aspose.slides.export/linkembeddecision/) zurück, um sie einzubetten.

[get_url(id, referrer)](https://reference.aspose.com/slides/python-net/aspose.slides.export/ilinkembedcontroller/get_url/#int-int): Gibt die URL zurück, die im resultierenden HTML für die Ressource mit der Kennung `id` erscheint (optional unter Berücksichtigung des Referrer‑Objekts).

[save_external(id, entity_data)](https://reference.aspose.com/slides/python-net/aspose.slides.export/ilinkembedcontroller/save_external/#int-bytes): Aufgerufen, wenn eine für die Verlinkung ausgewählte Ressource extern geschrieben werden muss. Da Kennung und Inhalt (als Byte‑Array) bereitgestellt werden, können Sie die Ressource nach Belieben persistieren.

Die Python-`LinkController`-Implementierung von [ILinkEmbedController](https://reference.aspose.com/slides/python-net/aspose.slides.export/ilinkembedcontroller/) folgt unten.
```py
# [TODO[not_supported_yet]: python-Implementierung von .NET-Schnittstellen]
```


Nach der Implementierung der `LinkController`-Klasse können Sie sie zusammen mit der [HtmlOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/htmloptions/)‑Klasse verwenden, um die Präsentation nach HTML zu exportieren, wobei Bilder extern verlinkt werden, wie unten gezeigt:
```py
# [TODO[not_supported_yet]: Python-Implementierung von .NET-Schnittstellen]
```


Wir haben `SlideImageFormat.SVG` der Eigenschaft `slide_image_format` zugewiesen, damit die resultierende HTML-Datei SVG-Daten enthält, um den Inhalt der Präsentation darzustellen.

Inhaltstypen: Wenn die Präsentation Raster‑Bitmaps enthält, muss der Klassen‑Code darauf vorbereitet sein, sowohl `image/jpeg`‑ als auch `image/png`‑Inhaltstypen zu verarbeiten. Der Inhalt der exportierten Bitmap‑Bilder kann von dem im Präsentations‑File gespeicherten abweichen. Die internen Algorithmen von Aspose.Slides führen eine Größenoptimierung durch und verwenden je nach Ergebnis entweder den JPEG‑ oder den PNG‑Codec (abhängig davon, welcher eine kleinere Dateigröße erzeugt). Bilder mit einem Alphakanal (Transparenz) werden stets als PNG kodiert.