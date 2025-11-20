---
title: Präsentationen in Python speichern
linktitle: Präsentationen speichern
type: docs
weight: 80
url: /de/python-net/save-presentation/
keywords:
- PowerPoint speichern
- OpenDocument speichern
- Präsentation speichern
- Folie speichern
- PPT speichern
- PPTX speichern
- ODP speichern
- Präsentation in Datei
- Präsentation in Stream
- vordefinierter Ansichtstyp
- Strict Office Open XML-Format
- Zip64-Modus
- Miniaturansicht aktualisieren
- Speichervorgang
- Python
- Aspose.Slides
description: "Erfahren Sie, wie Sie Präsentationen in Python mit Aspose.Slides—Export zu PowerPoint oder OpenDocument bei Beibehaltung von Layouts, Schriftarten und Effekten."
---

## **Übersicht**

[Öffnen einer Präsentation in Python](/slides/de/python-net/open-presentation/) beschreibt, wie die Klasse [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) verwendet wird, um eine Präsentation zu öffnen. Dieser Artikel erklärt, wie man Präsentationen erstellt und speichert. Die Klasse [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) enthält den Inhalt einer Präsentation. Egal, ob Sie eine Präsentation von Grund auf neu erstellen oder eine vorhandene ändern, Sie möchten sie am Ende speichern. Mit Aspose.Slides für Python können Sie in einer **Datei** oder **Stream** speichern. Dieser Artikel erklärt die verschiedenen Möglichkeiten, eine Präsentation zu speichern.

## **Präsentationen in Dateien speichern**

Speichern Sie eine Präsentation in einer Datei, indem Sie die `save`‑Methode der Klasse [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) aufrufen. Übergeben Sie den Dateinamen und das Speicherformat an die Methode. Das folgende Beispiel zeigt, wie Sie eine Präsentation mit Aspose.Slides für Python speichern.
```py
import aspose.slides as slides

# Instanziiere die Presentation-Klasse, die eine Präsentationsdatei darstellt.
with slides.Presentation() as presentation:
    
    # Führe hier einige Arbeiten aus...

    # Speichere die Präsentation in einer Datei.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **Präsentationen in Streams speichern**

Sie können eine Präsentation in einen Stream speichern, indem Sie einen Ausgabestream an die `save`‑Methode der Klasse [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) übergeben. Eine Präsentation kann in viele Stream‑Typen geschrieben werden. Im folgenden Beispiel erstellen wir eine neue Präsentation, fügen einer Form Text hinzu und speichern sie in einen Stream.
```py
import aspose.slides as slides

# Instanziiere die Presentation-Klasse, die eine Präsentationsdatei darstellt.
with slides.Presentation() as presentation:
    with open("output.pptx", "bw") as file_stream:
        # Speichere die Präsentation in den Stream.
        presentation.save(file_stream, slides.export.SaveFormat.PPTX)
```


## **Präsentationen mit vordefiniertem Ansichtstyp speichern**

Aspose.Slides für Python ermöglicht es Ihnen, die anfängliche Ansicht festzulegen, die PowerPoint verwendet, wenn die erzeugte Präsentation über die Klasse [ViewProperties](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/) geöffnet wird. Setzen Sie die Eigenschaft `last_view` auf einen Wert aus der Aufzählung [ViewType](https://reference.aspose.com/slides/python-net/aspose.slides/viewtype/).
```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.view_properties.last_view = slides.ViewType.SLIDE_MASTER_VIEW
    presentation.save("slide_master_view.pptx", slides.export.SaveFormat.PPTX)
```


## **Präsentationen im Strict Office Open XML‑Format speichern**

Aspose.Slides ermöglicht das Speichern einer Präsentation im Strict Office Open XML‑Format. Verwenden Sie die Klasse [PptxOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pptxoptions/) und setzen Sie deren Conformance‑Eigenschaft beim Speichern. Wenn Sie `Conformance.ISO_29500_2008_STRICT` festlegen, wird die Ausgabedatei im Strict Office Open XML‑Format gespeichert.

Das folgende Beispiel erstellt eine Präsentation und speichert sie im Strict Office Open XML‑Format.
```py
import aspose.slides as slides

options = slides.export.PptxOptions()
options.conformance = slides.export.Conformance.ISO_29500_2008_STRICT

# Instanziiere die Presentation-Klasse, die eine Präsentationsdatei darstellt.
with slides.Presentation() as presentation:
    # Speichere die Präsentation im Strict Office Open XML-Format.
    presentation.save("strict_office_open_xml.pptx", slides.export.SaveFormat.PPTX, options)
```


## **Präsentationen im Office Open XML‑Format im Zip64‑Modus speichern**

Eine Office Open XML‑Datei ist ein ZIP‑Archiv, das 4 GB (2^32 Bytes) Grenzen für die unkomprimierte Größe jeder Datei, die komprimierte Größe jeder Datei und die Gesamtgröße des Archivs festlegt und das Archiv zudem auf 65 535 (2^16‑1) Dateien begrenzt. ZIP64‑Formaterweiterungen erhöhen diese Grenzen auf 2^64.

Die Eigenschaft [PptxOptions.zip_64_mode](https://reference.aspose.com/slides/python-net/aspose.slides.export/pptxoptions/zip_64_mode/) ermöglicht Ihnen zu wählen, wann ZIP64‑Formaterweiterungen beim Speichern einer Office Open XML‑Datei verwendet werden.

Diese Eigenschaft bietet die folgenden Modi:

- `IF_NECESSARY` verwendet ZIP64‑Formaterweiterungen nur, wenn die Präsentation die oben genannten Beschränkungen überschreitet. Dies ist der Standardmodus.
- `NEVER` verwendet niemals ZIP64‑Formaterweiterungen.
- `ALWAYS` verwendet immer ZIP64‑Formaterweiterungen.

Der folgende Code demonstriert, wie man eine Präsentation als PPTX mit aktivierten ZIP64‑Formaterweiterungen speichert:
```py
pptx_options = slides.export.PptxOptions()
pptx_options.zip_64_mode = slides.export.Zip64Mode.ALWAYS

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("output_zip64.pptx", slides.export.SaveFormat.PPTX, pptx_options)
```


{{% alert title="HINWEIS" color="warning" %}}
Wenn Sie mit `Zip64Mode.NEVER` speichern, wird eine [PptxException](https://reference.aspose.com/slides/python-net/aspose.slides/pptxexception/) ausgelöst, falls die Präsentation nicht im ZIP32‑Format gespeichert werden kann.
{{% /alert %}}

## **Präsentationen speichern, ohne das Miniaturbild zu aktualisieren**

Die Eigenschaft [PptxOptions.refresh_thumbnail](https://reference.aspose.com/slides/python-net/aspose.slides.export/pptxoptions/refresh_thumbnail/) steuert die Miniaturbild‑Erstellung beim Speichern einer Präsentation als PPTX:

- Wenn sie auf `True` gesetzt ist, wird das Miniaturbild während des Speichervorgangs aktualisiert. Dies ist die Vorgabe.
- Wenn sie auf `False` gesetzt ist, bleibt das aktuelle Miniaturbild erhalten. Hat die Präsentation kein Miniaturbild, wird keines erzeugt.

Im folgenden Code wird die Präsentation als PPTX gespeichert, ohne ihr Miniaturbild zu aktualisieren.
```py
import aspose.slides as slides

pptx_options = slides.export.PptxOptions()
pptx_options.refresh_thumbnail = False

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX, pptx_options)
```


{{% alert title="Info" color="info" %}}
Diese Option hilft, die für das Speichern einer Präsentation im PPTX‑Format benötigte Zeit zu reduzieren.
{{% /alert %}}

{{% alert title="Info" color="info" %}}
Aspose hat eine [kostenlose PowerPoint Splitter‑App](https://products.aspose.app/slides/splitter) entwickelt, die seine eigene API verwendet. Die App ermöglicht das Aufteilen einer Präsentation in mehrere Dateien, indem ausgewählte Folien als neue PPTX‑ oder PPT‑Dateien gespeichert werden.
{{% /alert %}}

## **FAQ**

**Wird „schnelles Speichern“ (inkrementelles Speichern) unterstützt, sodass nur Änderungen geschrieben werden?**

Nein. Beim Speichern wird jedes Mal die vollständige Zieldatei erstellt; inkrementelles „schnelles Speichern“ wird nicht unterstützt.

**Ist das gleichzeitige Speichern derselben Presentation‑Instanz aus mehreren Threads thread‑sicher?**

Nein. Eine [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Instanz ist nicht thread‑sicher; speichern Sie sie nur aus einem einzelnen Thread.

**Was passiert beim Speichern mit Hyperlinks und extern verlinkten Dateien?**

[Hyperlinks](/slides/de/python-net/manage-hyperlinks/) bleiben erhalten. Extern verlinkte Dateien (z. B. Videos über relative Pfade) werden nicht automatisch kopiert – stellen Sie sicher, dass die referenzierten Pfade weiterhin zugänglich sind.

**Kann ich Dokument‑Metadaten (Autor, Titel, Unternehmen, Datum) setzen/​speichern?**

Ja. Standard‑[document properties](/slides/de/python-net/presentation-properties/) werden unterstützt und beim Speichern in die Datei geschrieben.