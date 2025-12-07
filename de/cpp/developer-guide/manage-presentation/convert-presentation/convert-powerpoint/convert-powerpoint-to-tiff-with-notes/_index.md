---
title: PowerPoint-Präsentationen mit Notizen in TIFF konvertieren (C++)
linktitle: PowerPoint nach TIFF mit Notizen
type: docs
weight: 100
url: /de/cpp/convert-powerpoint-to-tiff-with-notes/
keywords:
- PowerPoint konvertieren
- Präsentation konvertieren
- Folie konvertieren
- PPT konvertieren
- PPTX konvertieren
- PowerPoint nach TIFF
- Präsentation nach TIFF
- Folie nach TIFF
- PPT nach TIFF
- PPTX nach TIFF
- PPT als TIFF speichern
- PPTX als TIFF speichern
- PPT nach TIFF exportieren
- PPTX nach TIFF exportieren
- PowerPoint mit Notizen
- Präsentation mit Notizen
- Folie mit Notizen
- PPT mit Notizen
- PPTX mit Notizen
- TIFF mit Notizen
- C++
- Aspose.Slides
description: "Konvertieren Sie PowerPoint-Präsentationen mit Notizen in das TIFF-Format mit Aspose.Slides für C++. Erfahren Sie, wie Sie Folien mit Sprecher-Notizen effizient exportieren."
---

## **Übersicht**

Aspose.Slides für C++ bietet eine einfache Lösung zum Konvertieren von PowerPoint- und OpenDocument-Präsentationen (PPT, PPTX und ODP) mit Notizen in das TIFF-Format. Dieses Format wird häufig für die hochwertige Bildspeicherung, den Druck und die Archivierung von Dokumenten verwendet. Mit Aspose.Slides können Sie nicht nur komplette Präsentationen mit Sprecher-Notizen exportieren, sondern auch Folienminiaturansichten in der Notizfolien-Ansicht erzeugen. Der Konvertierungsprozess ist einfach und effizient und nutzt die `Save`-Methode der [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)‑Klasse, um die gesamte Präsentation in eine Reihe von TIFF-Bildern zu transformieren, wobei die Notizen und das Layout erhalten bleiben.

## **Präsentation mit Notizen in TIFF konvertieren**

Das Speichern einer PowerPoint- oder OpenDocument-Präsentation als TIFF mit Notizen mithilfe von Aspose.Slides für C++ umfasst die folgenden Schritte:

1. Instanziieren Sie die [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)‑Klasse: Laden Sie eine PowerPoint- oder OpenDocument-Datei.
2. Konfigurieren Sie die Ausgabe-Layout-Optionen: Verwenden Sie die [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/notescommentslayoutingoptions/)‑Klasse, um festzulegen, wie Notizen und Kommentare angezeigt werden sollen.
3. Speichern Sie die Präsentation als TIFF: Übergeben Sie die konfigurierten Optionen an die [Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/)‑Methode.

Angenommen, wir haben eine Datei "speaker_notes.pptx" mit der folgenden Folie:

![Die Präsentationsfolie mit Sprecher-Notizen](slide_with_notes.png)

Der nachstehende Code-Abschnitt zeigt, wie die Präsentation in ein TIFF-Bild in der Notizfolien-Ansicht konvertiert wird, indem die Methode [set_SlidesLayoutOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_slideslayoutoptions/) verwendet wird.
```cpp
// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
auto presentation = MakeObject<Presentation>(u"speaker_notes.pptx");

auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull); // Zeigt die Notizen unterhalb der Folie an.

// Konfigurieren Sie die TIFF-Optionen mit Notizen-Layout.
auto tiffOptions = MakeObject<TiffOptions>();
tiffOptions->set_DpiX(300);
tiffOptions->set_DpiY(300);
tiffOptions->set_SlidesLayoutOptions(notesOptions);

// Speichern Sie die Präsentation als TIFF mit den Sprecher-Notizen.
presentation->Save(u"TIFF_with_notes.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```


Das Ergebnis:

![Das TIFF-Bild mit Sprecher-Notizen](TIFF_with_notes.png)

{{% alert title="Tip" color="primary" %}}
Schauen Sie sich den kostenlosen Aspose [PowerPoint-zu-Poster-Konverter](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online) an.
{{% /alert %}}

## **FAQ**

**Kann ich die Position des Notizbereichs im resultierenden TIFF steuern?**

Ja. Verwenden Sie die [notes layout settings](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_slideslayoutoptions/), um zwischen Optionen wie `None`, `BottomTruncated` oder `BottomFull` zu wählen, die jeweils Notizen ausblenden, sie auf eine einzelne Seite passen oder zulassen, dass sie auf weitere Seiten übergehen.

**Wie kann ich die Größe einer TIFF-Datei mit Notizen reduzieren, ohne sichtbaren Qualitätsverlust?**

Wählen Sie eine [effiziente Kompression](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_compressiontype/) (z. B. `LZW` oder `RLE`), setzen Sie eine angemessene DPI und verwenden Sie, falls akzeptabel, ein niedrigeres [pixel format](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_pixelformat/) (z. B. 8 bpp oder 1 bpp für Monochrom). Das leichte Reduzieren der [image dimensions](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_imagesize/) kann ebenfalls helfen, ohne die Lesbarkeit merklich zu beeinträchtigen.

**Beeinflusst die Schriftart in den Notizen das Ergebnis, wenn die Originalschriftarten im System fehlen?**

Ja. Fehlende Schriftarten lösen eine [substitution](/slides/de/cpp/font-selection-sequence/) aus, die Messwerte und das Aussehen des Textes ändern kann. Um dies zu vermeiden, [stellen Sie die erforderlichen Schriftarten](/slides/de/cpp/custom-font/) bereit oder setzen Sie eine Standard-[fallback font](/slides/de/cpp/fallback-font/), sodass die beabsichtigten Schriftarten verwendet werden.