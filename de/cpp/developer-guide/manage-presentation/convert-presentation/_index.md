---
title: Convert Präsentationen in mehrere Formate in C++
linktitle: Präsentation konvertieren
type: docs
weight: 70
url: /de/cpp/convert-presentation/
keywords:
- Präsentation konvertieren
- Präsentation exportieren
- PPT zu PPTX
- PPTX zu PPT
- ODP zu PPTX
- PPT zu PDF
- PPTX zu PDF
- ODP zu PDF
- PPT zu HTML
- PPTX zu HTML
- ODP zu HTML
- PPT zu PNG
- PPTX zu PNG
- ODP zu PNG
- PPTX zu JPG
- ODP zu JPG
- PPT zu XPS
- PPTX zu XPS
- ODP zu XPS
- PPT zu TIFF
- PPTX zu TIFF
- ODP zu TIFF
- PowerPoint
- OpenDocument
- C++
- Aspose.Slides
description: "Konvertieren Sie PowerPoint- und OpenDocument-Präsentationen in PPTX, PDF, HTML, Bilder, XPS, TIFF und mehr mit Aspose.Slides für C++."
---
## **Übersicht**

Aspose.Slides für C++ kann PowerPoint- und OpenDocument-Präsentationen laden und sie in viele andere Formate speichern oder rendern, ohne Microsoft PowerPoint, OpenOffice oder LibreOffice zu benötigen. Sie können alte PPT-Dateien in das moderne PPTX‑Format konvertieren, Präsentationen in fest‑layout‑Dokumente wie PDF und XPS exportieren, Folien als HTML veröffentlichen oder Folien als Bilddateien für Vorschaubilder, Miniaturansichten und Archive rendern.

Die meisten Dokumentkonvertierungen folgen demselben allgemeinen Arbeitsablauf: Die Quelldatei laden, das gewünschte Ausgabeformat auswählen und bei Bedarf formatbezogene Optionen anwenden. Bei Bildformaten wird jede Folie einzeln gerendert und dann als Raster‑ oder Vektorbilder gespeichert. Die nachfolgend verlinkten Artikel enthalten die Implementierungsdetails für jeden Fall.

## **Wählen Sie ein Konvertierungsszenario**

Verwenden Sie die untenstehenden Artikel für vollständige C++‑Beispiele und formatbezogene Optionen.

| Szenario | Verwenden Sie es, wenn Sie | Artikel |
| --- | --- | --- |
| PPT/PPTX/ODP to PPTX | Legacy‑PPT-Dateien modernisieren, vorhandene PPTX‑Dateien normalisieren oder OpenDocument‑Präsentationen in PowerPoint‑PPTX konvertieren. | [PPT in PPTX konvertieren](/slides/de/cpp/convert-ppt-to-pptx/), [ODP in PPTX konvertieren](/slides/de/cpp/convert-odp-to-pptx/), [Präsentationen speichern](/slides/de/cpp/save-presentation/) |
| PPTX to PPT | Eine moderne PowerPoint‑Präsentation im älteren binären PPT‑Format speichern, um die Kompatibilität mit älteren Workflows zu gewährleisten. | [PPTX in PPT konvertieren](/slides/de/cpp/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP to PDF | Portable, durchsuchbare Dokumente mit festem Layout zum Teilen, Drucken oder Archivieren erstellen. | [PowerPoint in PDF konvertieren](/slides/de/cpp/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP to PDF with notes | Sprecher‑Notizen zusammen mit dem Folieninhalt exportieren. | [PowerPoint in PDF mit Notizen konvertieren](/slides/de/cpp/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP to HTML | Präsentationen als HTML‑Seiten veröffentlichen und Bilder, Schriftarten, Notizen sowie responsive Layout‑Optionen steuern. | [PowerPoint in HTML konvertieren](/slides/de/cpp/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP to HTML5 | Folien nach HTML5 exportieren für die browserbasierte Ansicht mit erhaltenem Layout und Interaktivität. | [Präsentationen nach HTML5 exportieren](/slides/de/cpp/export-to-html5/) |
| PPT/PPTX/ODP to PNG | Jede Folie in ein PNG‑Bild rendern für Vorschaubilder, Miniaturansichten oder Webausgabe. | [PowerPoint in PNG konvertieren](/slides/de/cpp/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP to JPG | Folien in JPG‑Bilder rendern und Bildabmessungen sowie Qualität steuern. | [PowerPoint in JPG konvertieren](/slides/de/cpp/convert-powerpoint-to-jpg/) |
| Slide to SVG | Einzelne Folien als skalierbare Vektorgrafiken exportieren. | [Folie als SVG rendern](/slides/de/cpp/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP to XPS | XPS‑Dokumente mit festem Layout erzeugen. | [PowerPoint in XPS konvertieren](/slides/de/cpp/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP to TIFF | Eine Präsentation als mehrseitige TIFF‑Datei für Druck, Scan, Fax oder Archivierungs‑Workflows speichern. | [PowerPoint in TIFF konvertieren](/slides/de/cpp/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP to TIFF with notes | Folien mit Sprecher‑Notizen als TIFF speichern. | [PowerPoint in TIFF mit Notizen konvertieren](/slides/de/cpp/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX to Word | Folien in ein Word‑Dokument konvertieren, wenn ein dokumentenähnlicher Ausgabestil benötigt wird. | [PowerPoint in Word konvertieren](/slides/de/cpp/convert-powerpoint-to-word/) |
| PPT/PPTX to Markdown | Präsentationsinhalte in Markdown extrahieren für Dokumentation und textbasierte Workflows. | [PowerPoint in Markdown konvertieren](/slides/de/cpp/convert-powerpoint-to-markdown/) |
| PPT/PPTX to animated GIF | Ein animiertes GIF aus Folien erstellen. | [PowerPoint in animiertes GIF konvertieren](/slides/de/cpp/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX to video | Einen Video‑Export‑Workflow aus Präsentationsfolien erstellen. | [PowerPoint in Video konvertieren](/slides/de/cpp/convert-powerpoint-to-video/) |
| Presentation to XAML | Folien nach XAML exportieren für C++‑UI‑Szenarien. | [Präsentationen nach XAML exportieren](/slides/de/cpp/export-to-xaml/) |

Für eine umfassendere Liste von Eingabe‑ und Ausgabeformaten siehe [Unterstützte Dateiformate](/slides/de/cpp/supported-file-formats/).

## **PowerPoint‑ und OpenDocument‑Konvertierung**

Aspose.Slides für C++ unterstützt die Konvertierung von gängigen Präsentationsformaten wie PPT, PPTX, PPS, PPSX, POT, POTX und ODP. Dieselbe Konvertierungs‑API wird für PowerPoint‑ und OpenDocument‑Dateien verwendet, sodass ein Workflow, der eine PPTX‑Datei nach PDF speichert, in der Regel auch auf eine ODP‑Datei angewendet werden kann, indem nur die Eingabedatei geändert wird.

Beim Konvertieren von ODP‑Dateien sollten Sie beachten, dass PowerPoint‑ und OpenDocument‑Anwendungen nicht jedes Layout‑ und Formatierungs‑Feature exakt gleich unterstützen. Wurde eine ODP‑Datei in LibreOffice oder OpenOffice Impress erstellt, prüfen Sie die Ausgabe und verwenden Sie die Optionen, die in [OpenDocument‑Präsentationen konvertieren](/slides/de/cpp/convert-openoffice-odp/) beschrieben sind, wenn Sie formatbezogene Anleitungen benötigen.

## **PPT‑zu‑PPTX‑Konvertierung**

PPT ist das ältere binäre PowerPoint‑Format, während PPTX das moderne Office‑Open‑XML‑Format ist. Aspose.Slides für C++ unterstützt eine hochpräzise PPT‑zu‑PPTX‑Konvertierung und bewahrt dabei komplexe Präsentationsstrukturen wie Master, Layouts, Folien, Diagramme, gruppierte Formen, Platzhalter, Textfelder, Texturen und Bildfüllungen.

Weitere Details finden Sie unter [PPT in PPTX konvertieren](/slides/de/cpp/convert-ppt-to-pptx/).

## **Export mit festem Layout**

PDF, XPS und TIFF sind nützlich, wenn die Ausgabe auf allen Geräten gleich aussehen und nicht als Präsentation bearbeitet werden soll. Die jeweiligen PDF‑, XPS‑ und TIFF‑Artikel erläutern, wie Compliance, versteckte Folien, Notizen, Bildqualität, Kompression, Pixelformat und Ausgabengröße gesteuert werden können.

## **HTML‑ und Bild‑Export**

Export nach HTML und HTML5 ist nützlich für die Browseranzeige, Web‑Publishing und leichtes Teilen. Bildexport ist sinnvoll, wenn jede Folie ein separates Vorschau‑, Miniatur‑ oder Raster‑Asset werden soll. Verwenden Sie die PNG‑, JPG‑ und SVG‑Artikel für formatbezogene Rendering‑Hinweise.

## **FAQ**

**Benötige ich Microsoft PowerPoint zum Konvertieren von Präsentationen?**

Nein. Aspose.Slides für C++ ist eine eigenständige Bibliothek und erfordert weder Microsoft PowerPoint noch Office‑Automatisierung.

**Kann ich viele Präsentationen stapelweise konvertieren?**

Ja. Laden Sie jede Präsentation, speichern Sie sie im gewünschten Format und geben Sie das Präsentationsobjekt nach der Verarbeitung frei. Für parallele Verarbeitung verwenden Sie separate Präsentationsinstanzen und beachten Sie die Anleitung zum [Multithreading](/slides/de/cpp/multithreading/).

**Kann ich nur ausgewählte Folien exportieren?**

Ja. Mehrere Exportmethoden ermöglichen das Übergeben von Folienindizes oder das Rendern einzelner Folien, je nach Ausgabeformat. Siehe den entsprechenden Artikel für das jeweilige Zielformat.

**Kann ich versteckte Folien beim Export nach PDF oder XPS einbeziehen?**

Ja. Verwenden Sie die Export‑Einstellungen für versteckte Folien, die in den [PDF](/slides/de/cpp/convert-powerpoint-to-pdf/)‑ und [XPS](/slides/de/cpp/convert-powerpoint-to-xps/)‑Konvertierungsartikeln beschrieben sind.

**Kann ich PDF/A-Ausgabe erstellen?**

Ja. PDF‑Compliance‑Einstellungen stehen für den PDF‑Export zur Verfügung. Weitere Details finden Sie unter [PowerPoint in PDF konvertieren](/slides/de/cpp/convert-powerpoint-to-pdf/).

**Wie werden Schriftarten während der Konvertierung behandelt?**

Aspose.Slides kann eingebettete Schriftarten, Schriftart‑Fallback und Schriftart‑Ersatz‑Einstellungen verwenden. Siehe [Eingebettete Schriftarten](/slides/de/cpp/embedded-font/), [Fallback‑Schriftarten](/slides/de/cpp/fallback-font/), und [Schriftart‑Substitution](/slides/de/cpp/font-substitution/).