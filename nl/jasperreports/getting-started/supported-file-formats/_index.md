---
title: Ondersteunde bestandsformaten
type: docs
weight: 20
url: /nl/jasperreports/supported-file-formats/
description: "Bekijk wat Aspose.Slides for JasperReports accepteert als invoer en naar welke bestandsformaten het rapporten exporteert."
---
## **Invoer**

Aspose.Slides for JasperReports exporteert rapporten; het converteert geen bestaande presentaties. De exporteurs nemen een ingevuld JasperReports-rapport (`JasperPrint`), bijvoorbeeld het resultaat van `JasperFillManager` of een ingevuld rapport dat is geladen uit een *.jrprint*-bestand.

## **Uitvoerformaten**

De onderstaande tabel toont de formaten waarnaar Aspose.Slides for JasperReports een rapport exporteert, en de exporteurklasse die elk formaat schrijft.

|**Formaat**|**Beschrijving**|**Exporteur**|
| :- | :- | :- |
|[PPT](https://docs.fileformat.com/presentation/ppt/)|PowerPoint 97-2003-presentatie; één dia per rapportpagina|`ASPptExporter`|
|[PPTX](https://docs.fileformat.com/presentation/pptx/)|PowerPoint-presentatie (Office Open XML); één dia per rapportpagina|`ASPptxExporter`|
|[PDF](https://docs.fileformat.com/pdf/)|Portable Document Format; één PDF-pagina per rapportpagina|`ASPdfExporter`|
|[HTML](https://docs.fileformat.com/web/html/)|Een enkel HTML-bestand met één SVG-afbeelding per rapportpagina|`ASHtmlExporter`|

Er is geen exporteur voor de PPS- en PPSX-diavoorstellingsformaten. Het geven van een *.ppsx*-bestandsnaam aan een PPTX-export resulteert nog steeds in een PPTX-presentatie, geen diavoorstelling. Om te zien hoe elke exporteur wordt gebruikt, zie [PPT, PPTX, PDF en HTML Export](/slides/nl/jasperreports/ppt-pptx-pdf-and-html-export/).