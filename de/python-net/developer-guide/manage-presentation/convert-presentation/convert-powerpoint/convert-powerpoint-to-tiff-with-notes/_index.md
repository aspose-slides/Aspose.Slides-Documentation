---
title: PowerPoint-Präsentationen mit Notizen in TIFF konvertieren in Python
linktitle: PowerPoint zu TIFF mit Notizen
type: docs
weight: 100
url: /de/python-net/convert-powerpoint-to-tiff-with-notes/
keywords:
  - PowerPoint konvertieren
  - Präsentation konvertieren
  - Folie konvertieren
  - PPT konvertieren
  - PPTX konvertieren
  - PowerPoint zu TIFF
  - Präsentation zu TIFF
  - Folie zu TIFF
  - PPT zu TIFF
  - PPTX zu TIFF
  - PowerPoint mit Notizen
  - Präsentation mit Notizen
  - Folie mit Notizen
  - PPT mit Notizen
  - PPTX mit Notizen
  - TIFF mit Notizen
  - Python
  - Aspose.Slides
description: "PowerPoint-Präsentationen mit Notizen in TIFF konvertieren mit Aspose.Slides für Python via .NET. Erfahren Sie, wie Sie Folien mit Sprecher-Notizen effizient exportieren."
---

## **Übersicht**

Aspose.Slides for Python via .NET bietet eine einfache Lösung zum Konvertieren von PowerPoint- und OpenDocument‑Präsentationen (PPT, PPTX und ODP) mit Notizen in das TIFF‑Format. Dieses Format wird häufig für die hochwertige Bildspeicherung, den Druck und die Dokumentenarchivierung verwendet. Mit Aspose.Slides können Sie nicht nur ganze Präsentationen mit Sprecher‑Notizen exportieren, sondern auch Folienminiaturen in der Notizfolienansicht erzeugen. Der Konvertierungsprozess ist einfach und effizient und nutzt die `save`‑Methode der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse, um die gesamte Präsentation in eine Reihe von TIFF‑Bildern zu transformieren, wobei die Notizen und das Layout erhalten bleiben.

## **Konvertieren einer Präsentation in TIFF mit Notizen**

Das Speichern einer PowerPoint- oder OpenDocument‑Präsentation in TIFF mit Notizen mithilfe von Aspose.Slides for Python via .NET umfasst die folgenden Schritte:

1. Instanziieren Sie die [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)-Klasse: Laden Sie eine PowerPoint‑ oder OpenDocument‑Datei.
1. Konfigurieren Sie die Ausgabelayout‑Optionen: Verwenden Sie die [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/notescommentslayoutingoptions/)-Klasse, um festzulegen, wie Notizen und Kommentare angezeigt werden sollen.
1. Speichern Sie die Präsentation als TIFF: Übergeben Sie die konfigurierten Optionen an die [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/#str-asposeslidesexportsaveformat-asposeslidesexportisaveoptions)-Methode.

Angenommen, wir haben eine Datei "speaker_notes.pptx" mit der folgenden Folie:

![Die Präsentationsfolie mit Sprecher-Notizen](slide_with_notes.png)

Das untenstehende Code‑Snippet demonstriert, wie die Präsentation in ein TIFF‑Bild in der Notizfolienansicht konvertiert wird, indem die Eigenschaft [slides_layout_options](https://reference.aspose.com/slides/python-net/aspose.slides.export/tiffoptions/slides_layout_options/) verwendet wird.
```py
# Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
with slides.Presentation("speaker_notes.pptx") as presentation:
    
    notes_options = slides.export.NotesCommentsLayoutingOptions()
    notes_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL  # Anzeige der Notizen unterhalb der Folie.
    
    # Konfigurieren Sie die TIFF-Optionen mit Notiz-Layout.
    tiff_options = slides.export.TiffOptions()
    tiff_options.dpi_x = 300
    tiff_options.dpi_y = 300
    tiff_options.slides_layout_options = notes_options
    
    # Speichern Sie die Präsentation als TIFF mit den Sprecher-Notizen.
    presentation.save("TIFF_with_notes.tiff", slides.export.SaveFormat.TIFF, tiff_options)
```


Das Ergebnis:

![Das TIFF‑Bild mit Sprecher-Notizen](TIFF_with_notes.png)

{{% alert title="Tip" color="primary" %}}
Probieren Sie den Aspose [Free PowerPoint to Poster Converter](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online) aus.
{{% /alert %}}

## **FAQ**

**Kann ich die Position des Notizbereichs im resultierenden TIFF steuern?**

Ja. Verwenden Sie die [notes layout settings](https://reference.aspose.com/slides/python-net/aspose.slides.export/tiffoptions/slides_layout_options/), um zwischen Optionen wie `NONE`, `BOTTOM_TRUNCATED` oder `BOTTOM_FULL` zu wählen, die jeweils Notizen ausblenden, sie auf einer einzigen Seite anpassen oder sie auf zusätzliche Seiten fließen lassen.

**Wie kann ich die Größe einer TIFF-Datei mit Notizen reduzieren, ohne sichtbar an Qualität zu verlieren?**

Wählen Sie eine [effiziente Kompression](https://reference.aspose.com/slides/python-net/aspose.slides.export/tiffoptions/compression_type/) (z. B. `LZW` oder `RLE`), setzen Sie einen angemessenen DPI‑Wert und benutzen Sie, falls akzeptabel, ein niedrigeres [Pixel-Format](https://reference.aspose.com/slides/python-net/aspose.slides.export/tiffoptions/pixel_format/) (wie 8 bpp oder 1 bpp für monochrom). Eine leichte Verringerung der [Bildabmessungen](https://reference.aspose.com/slides/python-net/aspose.slides.export/tiffoptions/image_size/) kann ebenfalls helfen, ohne die Lesbarkeit merklich zu beeinträchtigen.

**Beeinflusst die Schriftart in den Notizen das Ergebnis, wenn die Originalschriftarten im System fehlen?**

Ja. Fehlende Schriftarten lösen eine [Substitution](/slides/de/python-net/font-selection-sequence/) aus, die Textmaße und das Aussehen ändern kann. Um dies zu vermeiden, [Stellen Sie die erforderlichen Schriftarten bereit](/slides/de/python-net/custom-font/) oder legen Sie eine Standard‑[Fallback‑Schrift](/slides/de/python-net/fallback-font/) fest, sodass die gewünschten Schriftschnitte verwendet werden.