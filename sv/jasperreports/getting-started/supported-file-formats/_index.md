---
title: Filformat som stöds
type: docs
weight: 20
url: /sv/jasperreports/supported-file-formats/
description: "Se vad Aspose.Slides for JasperReports tar som indata och vilka filformat den exporterar rapporter till."
---
## **Inmatning**

Aspose.Slides for JasperReports exporterar rapporter; den konverterar inte befintliga presentationer. Dess exportörer tar en ifylld JasperReports‑rapport (`JasperPrint`), till exempel resultatet av `JasperFillManager` eller en ifylld rapport som laddats från en *.jrprint*-fil.

## **Exportformat**

Den följande tabellen listar de format som Aspose.Slides for JasperReports exporterar en rapport till, samt exportörsklassen som skriver varje format.

|**Format**|**Beskrivning**|**Exportör**|
| :- | :- | :- |
|[PPT](https://docs.fileformat.com/presentation/ppt/)|PowerPoint‑presentation 97–2003; en bild per rapportsida|`ASPptExporter`|
|[PPTX](https://docs.fileformat.com/presentation/pptx/)|PowerPoint‑presentation (Office Open XML); en bild per rapportsida|`ASPptxExporter`|
|[PDF](https://docs.fileformat.com/pdf/)|Portable Document Format; en PDF‑sida per rapportsida|`ASPdfExporter`|
|[HTML](https://docs.fileformat.com/web/html/)|En enda HTML‑fil med en SVG‑bild per rapportssida|`ASHtmlExporter`|

Det finns ingen exportör för PPS‑ och PPSX‑bildspelsformaten. Om du ger en PPTX‑export ett *.ppsx*-filnamn skapas fortfarande en PPTX‑presentation, inte ett bildspel. För att se hur varje exportör används, se [PPT, PPTX, PDF och HTML Export](/slides/sv/jasperreports/ppt-pptx-pdf-and-html-export/).