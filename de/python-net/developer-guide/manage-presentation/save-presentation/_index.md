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
- vordefinierter Ansichtsmodus
- Strict Office Open XML-Format
- Zip64-Modus
- Vorschaubild aktualisieren
- Speicherfortschritt
- Python
- Aspose.Slides
description: "Entdecken Sie, wie Sie Präsentationen in Python mit Aspose.Slides speichern—Export nach PowerPoint oder OpenDocument bei gleichzeitiger Beibehaltung von Layouts, Schriftarten und Effekten."
---
## **Übersicht**

[Präsentation in Python öffnen](/slides/de/python-net/open-presentation/) beschreibt, wie die [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/) Klasse verwendet wird, um eine Präsentation zu öffnen. Dieser Artikel erklärt, wie Präsentationen erstellt und gespeichert werden. Die [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/) Klasse enthält den Inhalt einer Präsentation. Egal, ob Sie eine neue Präsentation von Grund auf erstellen oder eine bestehende ändern, Sie sollten sie nach Abschluss speichern. Mit Aspose.Slides für Python können Sie in eine **Datei** oder **Stream** speichern. Dieser Artikel erläutert die verschiedenen Möglichkeiten, eine Präsentation zu speichern.

## **Präsentationen in Dateien speichern**

Speichern Sie eine Präsentation in einer Datei, indem Sie die `save`‑Methode der [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/) Klasse aufrufen. Übergeben Sie dem Aufruf den Dateinamen und das Speicherformat. Das folgende Beispiel zeigt, wie Sie eine Präsentation mit Aspose.Slides für Python speichern.

```py
import aspose.slides as slides

# Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
with slides.Presentation() as presentation:
    
    # Führen Sie hier einige Arbeiten aus...

    # Speichern Sie die Präsentation in einer Datei.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Präsentationen in Streams speichern**

Sie können eine Präsentation in einen Stream speichern, indem Sie einen Ausgabestream an die `save`‑Methode der [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/) Klasse übergeben. Eine Präsentation kann in verschiedene Stream‑Typen geschrieben werden. Im nachstehenden Beispiel erstellen wir eine neue Präsentation und speichern sie in einen Dateistream.

```py
import aspose.slides as slides

# Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
with slides.Presentation() as presentation:
    with open("output.pptx", "bw") as file_stream:
        # Speichern Sie die Präsentation in den Stream.
        presentation.save(file_stream, slides.export.SaveFormat.PPTX)
```

## **Präsentationen mit vordefiniertem Ansichtsmodus speichern**

Aspose.Slides für Python ermöglicht es, die anfängliche Ansicht festzulegen, die PowerPoint beim Öffnen der erzeugten Präsentation verwendet, über die Klasse [ViewProperties](https://reference.aspose.com/slides/de/python-net/aspose.slides/viewproperties/). Setzen Sie die Eigenschaft `last_view` auf einen Wert aus der Aufzählung [ViewType](https://reference.aspose.com/slides/de/python-net/aspose.slides/viewtype/).

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.view_properties.last_view = slides.ViewType.SLIDE_MASTER_VIEW
    presentation.save("slide_master_view.pptx", slides.export.SaveFormat.PPTX)
```

## **Präsentationen im Strict Office Open XML-Format speichern**

Aspose.Slides ermöglicht das Speichern einer Präsentation im Strict Office Open XML‑Format. Verwenden Sie die Klasse [PptxOptions](https://reference.aspose.com/slides/de/python-net/aspose.slides.export/pptxoptions/) und setzen Sie beim Speichern deren `conformance`‑Eigenschaft. Wenn Sie `Conformance.ISO_29500_2008_STRICT` festlegen, wird die Ausgabedatei im Strict Office Open XML‑Format gespeichert.

Das nachstehende Beispiel erstellt eine Präsentation und speichert sie im Strict Office Open XML‑Format.

```py
import aspose.slides as slides

options = slides.export.PptxOptions()
options.conformance = slides.export.Conformance.ISO_29500_2008_STRICT

# Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
with slides.Presentation() as presentation:
    # Speichern Sie die Präsentation im Strict Office Open XML-Format.
    presentation.save("strict_office_open_xml.pptx", slides.export.SaveFormat.PPTX, options)
```

## **Präsentationen im Office Open XML-Format im Zip64‑Modus speichern**

Eine Office Open XML‑Datei ist ein ZIP‑Archiv, das Grenzen von 4 GB (2^32 Byte) für die unkomprimierte Größe jeder Datei, die komprimierte Größe jeder Datei und die Gesamtgröße des Archivs sowie eine Grenze von 65 535 (2^16‑1) Dateien auferlegt. ZIP64‑Formatserweiterungen erhöhen diese Grenzen auf 2^64.

Die Eigenschaft [PptxOptions.zip_64_mode](https://reference.aspose.com/slides/de/python-net/aspose.slides.export/pptxoptions/zip_64_mode/) ermöglicht die Auswahl, wann ZIP64‑Formatserweiterungen beim Speichern einer Office Open XML‑Datei verwendet werden.

Diese Eigenschaft bietet die folgenden Modi:

- `IF_NECESSARY` verwendet ZIP64‑Formatserweiterungen nur, wenn die Präsentation die oben genannten Beschränkungen überschreitet. Dies ist der Standardmodus.
- `NEVER` verwendet niemals ZIP64‑Formatserweiterungen.
- `ALWAYS` verwendet stets ZIP64‑Formatserweiterungen.

Der folgende Code demonstriert, wie eine Präsentation als PPTX‑Datei mit aktivierten ZIP64‑Formatserweiterungen gespeichert wird:

```py
import aspose.slides as slides

pptx_options = slides.export.PptxOptions()
pptx_options.zip_64_mode = slides.export.Zip64Mode.ALWAYS

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("output_zip64.pptx", slides.export.SaveFormat.PPTX, pptx_options)
```

{{% alert title="HINWEIS" color="warning" %}}
Wenn Sie mit `Zip64Mode.NEVER` speichern, wird ein [PptxException](https://reference.aspose.com/slides/de/python-net/aspose.slides/pptxexception/) ausgelöst, falls die Präsentation nicht im ZIP32‑Format gespeichert werden kann.
{{% /alert %}}

## **Präsentationen im Office Open XML-Format mit Komprimierungsstufen speichern**

Bei großen Präsentationen können Sie die Komprimierungsstufe anpassen, um Dateigröße und Verarbeitungszeit auszubalancieren. Je nach Anforderung können Sie schnellere Verarbeitung oder kleinere Ausgabedateien bevorzugen.

Aspose.Slides stellt die Eigenschaft [PptxOptions.compression_level](https://reference.aspose.com/slides/de/python-net/aspose.slides.export/pptxoptions/compression_level/) bereit, mit der Sie die beim Speichern einer Präsentation im Office Open XML‑Format verwendete Komprimierungsstufe festlegen können.

Folgende Komprimierungsstufen stehen zur Verfügung:

- [**NONE**](https://reference.aspose.com/slides/de/python-net/aspose.slides.export/compressionlevel/): Keine Komprimierung. Dateien werden unverändert gespeichert.
- [**LEVEL1**](https://reference.aspose.com/slides/de/python-net/aspose.slides.export/compressionlevel/): Schnellste Komprimierung mit dem niedrigsten Kompressionsverhältnis.
- [**LEVEL2**](https://reference.aspose.com/slides/de/python-net/aspose.slides.export/compressionlevel/): Schnellere Komprimierung mit leicht besserem Verhältnis als **LEVEL1**.
- [**LEVEL3**](https://reference.aspose.com/slides/de/python-net/aspose.slides.export/compressionlevel/): Besseres Kompressionsverhältnis als **LEVEL2** bei moderatem Einfluss auf die Verarbeitungszeit.
- [**LEVEL4**](https://reference.aspose.com/slides/de/python-net/aspose.slides.export/compressionlevel/): Besseres Kompressionsverhältnis als **LEVEL3**.
- [**LEVEL5**](https://reference.aspose.com/slides/de/python-net/aspose.slides.export/compressionlevel/): Verbesserte Kompression gegenüber **LEVEL4** mit zusätzlicher Verarbeitungszeit.
- [**LEVEL6**](https://reference.aspose.com/slides/de/python-net/aspose.slides.export/compressionlevel/): Standardkompression, die ein gutes Gleichgewicht zwischen Verarbeitungsgeschwindigkeit und Dateigröße bietet. Dies ist die *Standard‑Komprimierungsstufe*.
- [**LEVEL7**](https://reference.aspose.com/slides/de/python-net/aspose.slides.export/compressionlevel/): Besseres Kompressionsverhältnis als **LEVEL6** bei langsamerer Verarbeitung.
- [**LEVEL8**](https://reference.aspose.com/slides/de/python-net/aspose.slides.export/compressionlevel/): Besseres Kompressionsverhältnis als **LEVEL7**.
- [**LEVEL9**](https://reference.aspose.com/slides/de/python-net/aspose.slides.export/compressionlevel/): Maximale Kompression. Produziert die kleinste Dateigröße auf Kosten der längsten Verarbeitungszeit.

Das folgende Beispiel zeigt, wie eine Präsentation als PPTX‑Datei *ohne Kompression* gespeichert wird:

```py
import aspose.slides as slides

pptx_options = slides.export.PptxOptions()
pptx_options.compression_level = slides.export.CompressionLevel.NONE

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("sample_out.pptx", slides.export.SaveFormat.PPTX, pptx_options)
```

Dieses Beispiel zeigt, wie eine Präsentation als PPTX‑Datei mit *maximaler Kompression* gespeichert wird:

```py
import aspose.slides as slides

pptx_options = slides.export.PptxOptions()
pptx_options.compression_level = slides.export.CompressionLevel.LEVEL9

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("sample_level9.pptx", slides.export.SaveFormat.PPTX, pptx_options)
```

## **Präsentationen ohne Aktualisierung des Vorschaubildes speichern**

Die Eigenschaft [PptxOptions.refresh_thumbnail](https://reference.aspose.com/slides/de/python-net/aspose.slides.export/pptxoptions/refresh_thumbnail/) steuert die Vorschaubildgenerierung beim Speichern einer Präsentation als PPTX:

- Bei `True` wird das Vorschaubild beim Speichern aktualisiert. Dies ist die Standardeinstellung.
- Bei `False` bleibt das aktuelle Vorschaubild erhalten. Existiert kein Vorschaubild, wird keines erzeugt.

Im nachstehenden Code wird die Präsentation als PPTX gespeichert, ohne ihr Vorschaubild zu aktualisieren.

```py
import aspose.slides as slides

pptx_options = slides.export.PptxOptions()
pptx_options.refresh_thumbnail = False

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX, pptx_options)
```

{{% alert title="Info" color="info" %}}
Diese Option reduziert die zum Speichern einer Präsentation im PPTX‑Format benötigte Zeit.
{{% /alert %}}

{{% alert title="Info" color="info" %}}
Aspose hat eine [kostenlose PowerPoint Splitter‑App](https://products.aspose.app/slides/de/splitter) entwickelt, die die eigene API nutzt. Die App ermöglicht das Aufteilen einer Präsentation in mehrere Dateien, indem ausgewählte Folien als neue PPTX‑ oder PPT‑Dateien gespeichert werden.
{{% /alert %}}

## **FAQ**

**Wird „schnelles Speichern“ (inkrementelles Speichern) unterstützt, sodass nur Änderungen geschrieben werden?**

Nein. Beim Speichern wird jedes Mal die vollständige Zieldatei erstellt; inkrementelles „schnelles Speichern“ wird nicht unterstützt.

**Ist das gleichzeitige Speichern derselben Presentation‑Instanz aus mehreren Threads thread‑sicher?**

Nein. Eine [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/) Instanz ist **nicht thread‑sicher**; speichern Sie sie aus einem einzigen Thread.

**Was passiert beim Speichern mit Hyperlinks und extern verlinkten Dateien?**

[Hyperlinks](/slides/de/python-net/manage-hyperlinks/) bleiben erhalten. Extern verlinkte Dateien (z. B. Videos über relative Pfade) werden nicht automatisch kopiert – stellen Sie sicher, dass die referenzierten Pfade weiterhin zugänglich sind.

**Kann ich Dokument‑Metadaten (Autor, Titel, Firma, Datum) setzen/speichern?**

Ja. Standard‑[Dokumenteneigenschaften](/slides/de/python-net/presentation-properties/) werden unterstützt und beim Speichern in die Datei geschrieben.