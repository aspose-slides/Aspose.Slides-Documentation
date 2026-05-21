---
title: Präsentationen in mehrere Formate in JavaScript konvertieren
linktitle: Präsentation konvertieren
type: docs
weight: 70
url: /de/nodejs-java/convert-presentation/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Konvertieren Sie PowerPoint- und OpenDocument‑Präsentationen in PPTX, PDF, HTML, Bilder, XPS, TIFF und mehr mit Aspose.Slides für Node.js via Java."
---
## **Übersicht**

Aspose.Slides für Node.js via Java kann PowerPoint- und OpenDocument‑Präsentationen laden und in viele andere Formate speichern oder rendern, ohne Microsoft PowerPoint, OpenOffice oder LibreOffice zu benötigen. Sie können Legacy‑PPT‑Dateien in moderne PPTX konvertieren, Präsentationen in fest‑layout‑Dokumente wie PDF und XPS exportieren, Folien als HTML veröffentlichen oder Folien als Bilddateien für Vorschauen, Miniaturen und Archive rendern.

Die meisten Dokumentkonvertierungen verwenden denselben allgemeinen Arbeitsablauf: Laden Sie die Quelldatei, wählen Sie das gewünschte Ausgabeformat und wenden Sie bei Bedarf format‑spezifische Optionen an. Bei Bildformaten wird jede Folie einzeln gerendert und anschließend als Raster‑ oder Vektor­bild gespeichert. Die nachfolgenden Artikel bieten die Implementierungsdetails für jeden Fall.

## **Wählen Sie ein Konvertierungsszenario**

Verwenden Sie die nachstehenden Artikel für vollständige JavaScript‑Beispiele und format‑spezifische Optionen.

| Szenario | Verwenden Sie es, wenn Sie | Artikel |
| --- | --- | --- |
| PPT/PPTX/ODP nach PPTX | Legacy‑PPT‑Dateien modernisieren, vorhandene PPTX‑Dateien normalisieren oder OpenDocument‑Präsentationen in PowerPoint‑PPTX konvertieren. | [Convert PPT to PPTX](/slides/de/nodejs-java/convert-ppt-to-pptx/),[Convert ODP to PPTX](/slides/de/nodejs-java/convert-odp-to-pptx/),[Save Presentations](/slides/de/nodejs-java/save-presentation/) |
| PPTX nach PPT | Eine moderne PowerPoint‑Präsentation im älteren Binär‑PPT‑Format speichern, um die Kompatibilität mit älteren Arbeitsabläufen zu gewährleisten. | [Convert PPTX to PPT](/slides/de/nodejs-java/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP nach PDF | Tragbare, durchsuchbare Fest‑Layout‑Dokumente zum Teilen, Drucken oder Archivieren erstellen. | [Convert PowerPoint to PDF](/slides/de/nodejs-java/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP nach PDF mit Notizen | Redner‑Notizen zusammen mit dem Folieninhalt exportieren. | [Convert PowerPoint to PDF with Notes](/slides/de/nodejs-java/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP nach HTML | Präsentationen als HTML‑Seiten veröffentlichen und Bilder, Schriften, Notizen sowie Optionen für responsives Layout steuern. | [Convert PowerPoint to HTML](/slides/de/nodejs-java/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP nach HTML5 | Folien nach HTML5 exportieren für die Anzeige im Browser mit erhaltenem Layout und Interaktivität. | [Convert Presentations to HTML5](/slides/de/nodejs-java/export-to-html5/) |
| PPT/PPTX/ODP nach PNG | Jede Folie in ein PNG‑Bild rendern für Vorschauen, Miniaturen oder Web‑Ausgabe. | [Convert PowerPoint to PNG](/slides/de/nodejs-java/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP nach JPG | Folien in JPG‑Bilder rendern und Bildabmessungen sowie Qualität steuern. | [Convert PowerPoint to JPG](/slides/de/nodejs-java/convert-powerpoint-to-jpg/) |
| Folie nach SVG | Einzelne Folien als skalierbare Vektorgrafiken exportieren. | [Render Slide as SVG](/slides/de/nodejs-java/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP nach XPS | Fest‑Layout‑XPS‑Dokumente erzeugen. | [Convert PowerPoint to XPS](/slides/de/nodejs-java/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP nach TIFF | Eine Präsentation als mehrseitige TIFF‑Datei für Druck, Scannen, Fax oder Archivierungs‑Workflows speichern. | [Convert PowerPoint to TIFF](/slides/de/nodejs-java/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP nach TIFF mit Notizen | Folien mit Redner‑Notizen als TIFF speichern. | [Convert PowerPoint to TIFF with Notes](/slides/de/nodejs-java/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX nach Markdown | Präsentationsinhalt in Markdown extrahieren für Dokumentation und textbasierte Workflows. | [Convert PowerPoint to Markdown](/slides/de/nodejs-java/convert-powerpoint-to-markdown/) |
| PPT/PPTX nach animiertem GIF | Ein animiertes GIF aus Folien erstellen. | [Convert PowerPoint to Animated GIF](/slides/de/nodejs-java/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX nach Video | Einen Video‑Export‑Workflow aus Präsentationsfolien erstellen. | [Convert PowerPoint to Video](/slides/de/nodejs-java/convert-powerpoint-to-video/) |
| Präsentation nach XAML | Folien nach XAML exportieren für JavaScript‑ oder Java‑UI‑Szenarien. | [Export Presentations to XAML](/slides/de/nodejs-java/export-to-xaml/) |

Für eine umfassendere Liste von Eingabe‑ und Ausgabeformaten siehe [Unterstützte Dateiformate](/slides/de/nodejs-java/supported-file-formats/).

## **PowerPoint‑ und OpenDocument‑Konvertierung**

Aspose.Slides für Node.js via Java unterstützt die Konvertierung aus gängigen Präsentationsformaten wie PPT, PPTX, PPS, PPSX, POT, POTX und ODP. Die gleiche Konvertierungs‑API wird für PowerPoint‑ und OpenDocument‑Dateien verwendet, sodass ein Arbeitsablauf, der eine PPTX‑Datei nach PDF speichert, normalerweise auch auf eine ODP‑Datei anwendbar ist, indem nur die Eingabedatei geändert wird.

Beim Konvertieren von ODP‑Dateien beachten Sie, dass PowerPoint‑ und OpenDocument‑Anwendungen nicht jede Layout‑ und Formatierungsfunktion exakt gleich unterstützen. Wenn eine ODP‑Datei in LibreOffice oder OpenOffice Impress erstellt wurde, prüfen Sie die Ausgabe und verwenden Sie die in [Convert OpenDocument Presentations](/slides/de/nodejs-java/convert-openoffice-odp/) beschriebenen Optionen, wenn Sie format‑spezifische Anleitungen benötigen.

## **PPT‑zu‑PPTX‑Konvertierung**

PPT ist das ältere binäre PowerPoint‑Format, während PPTX das moderne Office‑Open‑XML‑Format ist. Aspose.Slides für Node.js via Java unterstützt eine hochpräzise PPT‑zu‑PPTX‑Konvertierung und bewahrt dabei komplexe Präsentationsstrukturen wie Master, Layouts, Folien, Diagramme, gruppierte Formen, Platzhalter, Textfelder, Texturen und Bildfüllungen.

Details finden Sie unter [Convert PPT to PPTX](/slides/de/nodejs-java/convert-ppt-to-pptx/) und [PPT vs PPTX](/slides/de/nodejs-java/ppt-vs-pptx/).

## **Export mit festem Layout**

PDF, XPS und TIFF sind nützlich, wenn die Ausgabe auf allen Geräten gleich aussehen und nicht als Präsentation bearbeitet werden soll. Die speziellen PDF‑, XPS‑ und TIFF‑Artikel erklären, wie man Konformität, versteckte Folien, Notizen, Bildqualität, Kompression, Pixelformat und Ausgabegröße steuert.

## **HTML‑ und Bild‑Export**

Export nach HTML und HTML5 ist nützlich für die Anzeige im Browser, Web‑Veröffentlichungen und leichtes Teilen. Bildexport ist sinnvoll, wenn jede Folie zu einer separaten Vorschau, Miniatur oder Raster‑Asset werden muss. Verwenden Sie die PNG‑, JPG‑ und SVG‑Artikel für format‑spezifische Rendering‑Hinweise.

## **FAQ**

**Benötige ich Microsoft PowerPoint, um Präsentationen zu konvertieren?**

Nein. Aspose.Slides für Node.js via Java ist eine eigenständige Bibliothek und erfordert weder Microsoft PowerPoint noch Office‑Automatisierung.

**Kann ich viele Präsentationen stapelweise konvertieren?**

Ja. Laden Sie jede Präsentation, speichern Sie sie im gewünschten Format und geben Sie das Präsentationsobjekt nach der Verarbeitung wieder frei. Für parallele Verarbeitung verwenden Sie separate Präsentationsinstanzen und befolgen Sie die Anweisungen zur [multithreading](/slides/de/nodejs-java/multithreading/).

**Kann ich nur ausgewählte Folien exportieren?**

Ja. Mehrere Exportmethoden ermöglichen es, Folienindizes zu übergeben oder einzelne Folien zu rendern, je nach Ausgabeformat. Siehe den entsprechenden Artikel für das Ziel‑format.

**Kann ich versteckte Folien beim Export nach PDF oder XPS einbeziehen?**

Ja. Verwenden Sie die Export‑Einstellungen für versteckte Folien, die in den [PDF](/slides/de/nodejs-java/convert-powerpoint-to-pdf/)‑ und [XPS](/slides/de/nodejs-java/convert-powerpoint-to-xps/)‑Konvertierungsartikeln beschrieben sind.

**Kann ich PDF/A‑Ausgabe erzeugen?**

Ja. PDF‑Konformitätseinstellungen stehen für den PDF‑Export zur Verfügung. Details finden Sie unter [Convert PowerPoint to PDF](/slides/de/nodejs-java/convert-powerpoint-to-pdf/).

**Wie werden Schriften bei der Konvertierung behandelt?**

Aspose.Slides kann eingebettete Schriften, Schrift‑Fallback und Schrift‑Substitutions‑Einstellungen verwenden. Siehe [Embedded Font](/slides/de/nodejs-java/embedded-font/), [Fallback Font](/slides/de/nodejs-java/fallback-font/), und [Font Substitution](/slides/de/nodejs-java/font-substitution/).