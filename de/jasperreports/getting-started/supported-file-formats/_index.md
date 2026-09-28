---
title: "Unterstützte Dateiformate"
type: docs
weight: 20
url: /de/jasperreports/supported-file-formats/
description: "Siehe, welche Eingaben Aspose.Slides for JasperReports akzeptiert und in welche Dateiformate es Berichte exportiert."
---
## **Eingabe**

Aspose.Slides for JasperReports exportiert Berichte; es konvertiert keine vorhandenen Präsentationen. Seine Exporter übernehmen einen gefüllten JasperReports‑Bericht (`JasperPrint`), wie das Ergebnis von `JasperFillManager` oder einen gefüllten Bericht, der aus einer *.jrprint*‑Datei geladen wurde.

## **Ausgabeformate**

Die folgende Tabelle listet die Formate auf, in die Aspose.Slides for JasperReports einen Bericht exportiert, sowie die Exporter‑Klasse, die jedes davon schreibt.

|**Format**|**Beschreibung**|**Exporter**|
| :- | :- | :- |
|[PPT](https://docs.fileformat.com/presentation/ppt/)|PowerPoint‑Präsentation 97–2003; eine Folie pro Berichtsseite|`ASPptExporter`|
|[PPTX](https://docs.fileformat.com/presentation/pptx/)|PowerPoint‑Präsentation (Office Open XML); eine Folie pro Berichtsseite|`ASPptxExporter`|
|[PDF](https://docs.fileformat.com/pdf/)|Portable Document Format; eine PDF‑Seite pro Berichtsseite|`ASPdfExporter`|
|[HTML](https://docs.fileformat.com/web/html/)|Eine einzelne HTML‑Datei mit einem SVG‑Bild pro Berichtsseite|`ASHtmlExporter`|

Für die PPS‑ und PPSX‑Diashow‑Formate gibt es keinen Exporter. Wenn man einer PPTX‑Exportdatei den Dateinamen *.ppsx* gibt, wird weiterhin eine PPTX‑Präsentation erstellt und keine Diashow. Um zu sehen, wie jeder Exporter verwendet wird, siehe [PPT, PPTX, PDF und HTML Export](/slides/de/jasperreports/ppt-pptx-pdf-and-html-export/).