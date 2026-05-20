---
title: Präsentationen in .NET in mehrere Formate konvertieren
linktitle: Präsentation konvertieren
type: docs
weight: 70
url: /de/net/convert-presentation/
keywords:
- Präsentation konvertieren
- Präsentation exportieren
- PPT nach PPTX
- PPTX nach PPT
- ODP nach PPTX
- PPT nach PDF
- PPTX nach PDF
- ODP nach PDF
- PPT nach HTML
- PPTX nach HTML
- ODP nach HTML
- PPT nach PNG
- PPTX nach PNG
- ODP nach PNG
- PPTX nach JPG
- ODP nach JPG
- PPT nach XPS
- PPTX nach XPS
- ODP nach XPS
- PPT nach TIFF
- PPTX nach TIFF
- ODP nach TIFF
- PowerPoint
- OpenDocument
- .NET
- C#
- Aspose.Slides
description: "Konvertieren Sie PowerPoint- und OpenDocument-Präsentationen in PPTX, PDF, HTML, Bilder, XPS, TIFF und mehr mit Aspose.Slides für .NET."
---
## **Übersicht**

Aspose.Slides für .NET kann PowerPoint- und OpenDocument‑Präsentationen laden und in viele andere Formate speichern oder rendern, ohne Microsoft PowerPoint, OpenOffice oder LibreOffice zu benötigen. Sie können alte PPT‑Dateien in moderne PPTX konvertieren, Präsentationen in feste Layout‑Dokumente wie PDF und XPS exportieren, Folien als HTML veröffentlichen oder Folien als Bilddateien für Vorschaubilder, Thumbnails und Archive rendern.

Die meisten Dokumentkonvertierungen folgen demselben allgemeinen Workflow: Laden der Quelldatei, Auswahl des gewünschten Ausgabeformats und bei Bedarf Anwendung format­spezifischer Optionen. Für Bildformate wird jede Folie einzeln gerendert und dann als Raster‑ oder Vektorbild gespeichert. Die unten verlinkten Artikel enthalten die Implementierungsdetails für jeden Fall.

## **Wählen Sie ein Konvertierungsszenario**

Verwenden Sie die nachstehenden Artikel für vollständige C#‑Beispiele und format­spezifische Optionen.

| Szenario | Verwenden Sie es, wenn Sie | Artikel |
| --- | --- | --- |
| PPT/PPTX/ODP zu PPTX | Legacy‑PPT‑Dateien modernisieren, vorhandene PPTX‑Dateien normalisieren oder OpenDocument‑Präsentationen in PowerPoint‑PPTX konvertieren. | [Convert PPT to PPTX](/slides/de/net/convert-ppt-to-pptx/),[Convert ODP to PPTX](/slides/de/net/convert-odp-to-pptx/),[Save Presentations](/slides/de/net/save-presentation/) |
| PPTX zu PPT | Eine moderne PowerPoint‑Präsentation im alten binären PPT‑Format speichern, um die Kompatibilität mit älteren Arbeitsabläufen zu gewährleisten. | [Convert PPTX to PPT](/slides/de/net/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP zu PDF | Portierbare, durchsuchbare Dokumente mit festem Layout für die Weitergabe, den Druck oder die Archivierung erstellen. | [Convert PowerPoint to PDF](/slides/de/net/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP zu PDF mit Notizen | Sprecher‑Notizen zusammen mit dem Folieninhalt exportieren. | [Convert PowerPoint to PDF with Notes](/slides/de/net/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP zu HTML | Präsentationen als HTML‑Seiten veröffentlichen und Bilder, Schriften, Notizen sowie Optionen für responsives Layout steuern. | [Convert PowerPoint to HTML](/slides/de/net/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP zu HTML5 | Folien nach HTML5 exportieren für browserbasiertes Anzeigen mit erhaltenem Format und Interaktivität. | [Convert Presentations to HTML5](/slides/de/net/export-to-html5/) |
| PPT/PPTX/ODP zu PNG | Jede Folie als PNG‑Bild rendern für Vorschaubilder, Thumbnails oder Web‑Ausgabe. | [Convert PowerPoint to PNG](/slides/de/net/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP zu JPG | Folien als JPG‑Bilder rendern und Bildgröße sowie Qualität steuern. | [Convert PowerPoint to JPG](/slides/de/net/convert-powerpoint-to-jpg/) |
| Folie zu SVG | Einzelne Folien als skalierbare Vektorgrafiken exportieren. | [Render Slide as SVG](/slides/de/net/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP zu XPS | XPS‑Dokumente mit festem Layout erzeugen. | [Convert PowerPoint to XPS](/slides/de/net/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP zu TIFF | Eine Präsentation als mehrseitige TIFF‑Datei für Druck, Scannen, Fax oder Archivierungs‑Workflows speichern. | [Convert PowerPoint to TIFF](/slides/de/net/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP zu TIFF mit Notizen | Folien mit Sprecher‑Notizen als TIFF speichern. | [Convert PowerPoint to TIFF with Notes](/slides/de/net/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX zu Word | Folien in ein Word‑Dokument konvertieren, wenn eine dokumentenähnliche Ausgabe benötigt wird. | [Convert PowerPoint to Word](/slides/de/net/convert-powerpoint-to-word/) |
| PPT/PPTX zu Markdown | Präsentationsinhalt nach Markdown extrahieren für Dokumentation und textbasierte Workflows. | [Convert PowerPoint to Markdown](/slides/de/net/convert-powerpoint-to-markdown/) |
| PPT/PPTX zu animiertem GIF | Ein animiertes GIF aus den Folien erstellen. | [Convert PowerPoint to Animated GIF](/slides/de/net/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX zu Video | Einen Video‑Export‑Workflow aus den Präsentationsfolien erstellen. | [Convert PowerPoint to Video](/slides/de/net/convert-powerpoint-to-video/) |
| Präsentation zu XAML | Folien nach XAML für .NET‑UI‑Szenarien exportieren. | [Export Presentations to XAML](/slides/de/net/export-to-xaml/) |

Für eine umfassendere Liste von Ein‑ und Ausgabeformaten siehe [Supported File Formats](/slides/de/net/supported-file-formats/).

## **PowerPoint- und OpenDocument‑Konvertierung**

Aspose.Slides für .NET unterstützt die Konvertierung aus gängigen Präsentationsformaten wie PPT, PPTX, PPS, PPSX, POT, POTX und ODP. Die gleiche Konvertierungs‑API wird für PowerPoint‑ und OpenDocument‑Dateien verwendet, sodass ein Workflow, der eine PPTX‑Datei nach PDF speichert, in der Regel auch auf eine ODP‑Datei angewendet werden kann, indem nur die Eingabedatei geändert wird.

Beim Konvertieren von ODP‑Dateien beachten Sie, dass PowerPoint‑ und OpenDocument‑Anwendungen nicht jedes Layout‑ und Formatierungsfeature exakt gleich unterstützen. Wenn eine ODP‑Datei in LibreOffice oder OpenOffice Impress erstellt wurde, überprüfen Sie das Ergebnis und verwenden Sie die in [Convert OpenDocument Presentations](/slides/de/net/convert-openoffice-odp/) beschriebenen Optionen, wenn Sie format­spezifische Anleitungen benötigen.

## **PPT‑zu‑PPTX‑Konvertierung**

PPT ist das ältere binäre PowerPoint‑Format, während PPTX das moderne Office‑Open‑XML‑Format ist. Aspose.Slides für .NET unterstützt die hochpräzise PPT‑zu‑PPTX‑Konvertierung und bewahrt dabei komplexe Präsentationsstrukturen wie Master, Layouts, Folien, Diagramme, gruppierte Formen, Platzhalter, Textfelder, Texturen und Bildfüllungen.

Weitere Details finden Sie unter [Convert PPT to PPTX](/slides/de/net/convert-ppt-to-pptx/) und [PPT vs PPTX](/slides/de/net/ppt-vs-pptx/).

## **Export mit festem Layout**

PDF, XPS und TIFF sind nützlich, wenn die Ausgabe auf allen Geräten identisch aussehen und nicht als Präsentation bearbeitet werden soll. Verwenden Sie [PdfOptions](https://reference.aspose.com/slides/de/net/aspose.slides.export/pdfoptions/), [XpsOptions](https://reference.aspose.com/slides/de/net/aspose.slides.export/xpsoptions/) und [TiffOptions](https://reference.aspose.com/slides/de/net/aspose.slides.export/tiffoptions/), um Konformität, versteckte Folien, Notizen, Bildqualität, Kompression, Pixelformat und Ausgabegröße zu steuern.

## **HTML‑ und Bild‑Export**

HTML‑ und HTML5‑Export sind nützlich für die Anzeige im Browser, das Web‑Publishing und leichtes Teilen. Bild‑Export ist sinnvoll, wenn jede Folie zu einer separaten Vorschau, einem Thumbnail oder einer Raster‑Ressource werden soll. Nutzen Sie die Artikel zu PNG, JPG und SVG für format­spezifische Render‑Anleitungen.

## **FAQ**

**Benötige ich Microsoft PowerPoint, um Präsentationen zu konvertieren?**

Nein. Aspose.Slides für .NET ist eine eigenständige Bibliothek und erfordert weder Microsoft PowerPoint noch Office‑Automatisierung.

**Kann ich viele Präsentationen stapelweise konvertieren?**

Ja. Laden Sie jede Präsentation, speichern Sie sie im gewünschten Format und entsorgen Sie das `Presentation`‑Objekt nach der Verarbeitung. Für parallele Verarbeitung verwenden Sie separate Präsentationsinstanzen und folgen Sie den Anweisungen unter [multithreading](/slides/de/net/multithreading/).

**Kann ich nur ausgewählte Folien exportieren?**

Ja. Mehrere Exportmethoden ermöglichen das Übergeben von Folienindizes oder das Rendern einzelner Folien, je nach Ausgabeformat. Siehe den entsprechenden Artikel für das Ziel­format.

**Kann ich versteckte Folien beim Export nach PDF oder XPS einbeziehen?**

Ja. Verwenden Sie die Eigenschaft `ShowHiddenSlides` in [PdfOptions](https://reference.aspose.com/slides/de/net/aspose.slides.export/pdfoptions/) oder [XpsOptions](https://reference.aspose.com/slides/de/net/aspose.slides.export/xpsoptions/).

**Kann ich PDF/A‑Ausgabe erzeugen?**

Ja. PDF‑Konformitätseinstellungen stehen über [PdfOptions.Compliance](https://reference.aspose.com/slides/de/net/aspose.slides.export/pdfoptions/compliance/) und [PdfCompliance](https://reference.aspose.com/slides/de/net/aspose.slides.export/pdfcompliance/) zur Verfügung.

**Wie werden Schriften bei der Konvertierung behandelt?**

Aspose.Slides kann eingebettete Schriften, Schrift‑Fallback und Schrift‑Substitutions‑Einstellungen verwenden. Siehe [Embedded Font](/slides/de/net/embedded-font/), [Fallback Font](/slides/de/net/fallback-font/) und [Font Substitution](/slides/de/net/font-substitution/).