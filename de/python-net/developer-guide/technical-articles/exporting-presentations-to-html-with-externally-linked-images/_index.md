---
title: Präsentationen mit extern verlinkten Bildern in Python nach HTML exportieren
linktitle: Präsentationen mit extern verlinkten Bildern nach HTML exportieren
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
- verlinktes Bild
- extern verlinktes Bild
- Python
- Aspose.Slides
description: "Erfahren Sie, wie Sie Präsentationen mit extern verlinkten Bildern in Aspose.Slides für Python via .NET nach HTML exportieren, wobei PowerPoint- und OpenDocument-Formate unterstützt werden."
---

{{% alert color="primary" %}} 

Der Präsentations‑zu‑HTML‑Exportprozess ermöglicht es Ihnen, anzugeben:

1. welche Ressourcen in die resultierende HTML‑Datei eingebettet werden, und
1. welche Ressourcen extern gespeichert und von der HTML‑Datei referenziert werden.

{{% /alert %}} 

## **Hintergrund**

Standardmäßig bettet der HTML‑Export alle Ressourcen direkt in das HTML ein, indem er Base64‑Kodierung verwendet. Dadurch entsteht eine einzige, eigenständige HTML‑Datei, die zum Anzeigen und Verteilen praktisch ist. Dieser Ansatz hat jedoch Nachteile:

* Die resultierende Datei ist aufgrund des Base64‑Overheads deutlich größer als die Original‑Ressourcen.
* Eingebettete Bilder und andere Assets sind schwer zu aktualisieren oder zu ersetzen.

## **Alternativer Ansatz**

Ein alternativer Ansatz, der [ILinkEmbedController](https://reference.aspose.com/slides/python-net/aspose.slides.export/ilinkembedcontroller/) verwendet, umgeht diese Einschränkungen.

Die untenstehende `LinkController`‑Klasse implementiert [ILinkEmbedController](https://reference.aspose.com/slides/python-net/aspose.slides.export/ilinkembedcontroller/) und wird dem Konstruktor von [HtmlOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/htmloptions/__init__/#ilinkembedcontroller) übergeben. Die Klasse stellt drei Methoden bereit, die steuern, wie Ressourcen während des HTML‑Exports eingebettet oder verlinkt werden:

[get_object_storing_location(id, entity_data, semantic_name, content_type, recommended_extension)](https://reference.aspose.com/slides/python-net/aspose.slides.export/ilinkembedcontroller/get_object_storing_location/#int-bytes-str-str-str): Aufgerufen, wenn der Exporter auf eine Ressource stößt und entscheiden muss, wo sie gespeichert werden soll. Die wichtigsten Parameter sind `id` (die eindeutige Kennung der Ressource für diesen Exportlauf) und `content_type` (der MIME‑Typ der Ressource). Gibt [LinkEmbedDecision.LINK](https://reference.aspose.com/slides/python-net/aspose.slides.export/linkembeddecision/) zurück, um die Ressource zu verlinken, oder [LinkEmbedDecision.EMBED](https://reference.aspose.com/slides/python-net/aspose.slides.export/linkembeddecision/) um sie einzubetten.

[get_url(id, referrer)](https://reference.aspose.com/slides/python-net/aspose.slides.export/ilinkembedcontroller/get_url/#int-int): Gibt die URL zurück, die im resultierenden HTML für die Ressource mit der Kennung `id` erscheint (optional unter Berücksichtigung des Referrer‑Objekts).

[save_external(id, entity_data)](https://reference.aspose.com/slides/python-net/aspose.slides.export/ilinkembedcontroller/save_external/#int-bytes): Aufgerufen, wenn eine für die Verlinkung ausgewählte Ressource extern geschrieben werden muss. Da die Kennung und der Inhalt (als Byte‑Array) bereitgestellt werden, können Sie die Ressource beliebig speichern.

Die Python `LinkController`-Implementierung von [ILinkEmbedController](https://reference.aspose.com/slides/python-net/aspose.slides.export/ilinkembedcontroller/) folgt unten.
```py
# [TODO[not_supported_yet]: Python-Implementierung von .NET-Schnittstellen]
```


Nachdem Sie die `LinkController`‑Klasse implementiert haben, können Sie sie zusammen mit der [HtmlOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/htmloptions/htmloptions/)‑Klasse verwenden, um die Präsentation nach HTML zu exportieren, wobei Bilder extern verlinkt werden, wie unten dargestellt:
```py
# [TODO[not_supported_yet]: Python-Implementierung von .NET-Schnittstellen]
```


Wir haben `SlideImageFormat.SVG` der Eigenschaft `slide_image_format` zugewiesen, damit die resultierende HTML‑Datei SVG‑Daten enthält, um den Inhalt der Präsentation darzustellen.

Inhaltstypen: Enthält die Präsentation Raster‑Bitmaps, muss der Klassen‑Code in der Lage sein, sowohl die Inhaltstypen `image/jpeg` als auch `image/png` zu verarbeiten. Der Inhalt der exportierten Bitmap‑Bilder muss nicht mit dem im Dokument gespeicherten übereinstimmen. Die internen Algorithmen von Aspose.Slides führen eine Größenoptimierung durch und verwenden entweder den JPEG‑ oder den PNG‑Codec (je nachdem, welcher eine kleinere Dateigröße ergibt). Bilder mit einem Alpha‑Kanal (Transparenz) werden stets als PNG kodiert.