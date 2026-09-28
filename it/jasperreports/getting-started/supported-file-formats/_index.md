---
title: Formati di file supportati
type: docs
weight: 20
url: /it/jasperreports/supported-file-formats/
description: "Scopri quali input accetta Aspose.Slides for JasperReports e in quali formati di file esporta i report."
---
## **Input**

Aspose.Slides for JasperReports esporta i report; non converte le presentazioni esistenti. I suoi esportatori accettano un report JasperReports compilato (`JasperPrint`), come il risultato di `JasperFillManager` o un report compilato caricato da un file *.jrprint*.

## **Formati di output**

La tabella seguente elenca i formati in cui Aspose.Slides per JasperReports esporta un report e la classe esportatrice che scrive ciascuno.

|**Formato**|**Descrizione**|**Esportatore**|
| :- | :- | :- |
|[PPT](https://docs.fileformat.com/presentation/ppt/)|Presentazione PowerPoint 97–2003; una diapositiva per pagina di report|`ASPptExporter`|
|[PPTX](https://docs.fileformat.com/presentation/pptx/)|Presentazione PowerPoint (Office Open XML); una diapositiva per pagina di report|`ASPptxExporter`|
|[PDF](https://docs.fileformat.com/pdf/)|Formato documento portatile; una pagina PDF per pagina di report|`ASPdfExporter`|
|[HTML](https://docs.fileformat.com/web/html/)|Un unico file HTML con un'immagine SVG per pagina di report|`ASHtmlExporter`|

Non esiste un esportatore per i formati di presentazione PPS e PPSX. Assegnare a un'esportazione PPTX un nome file *.ppsx* produce comunque una presentazione PPTX, non una presentazione a scorrimento. Per vedere come viene utilizzato ciascun esportatore, vedere [Esportazione PPT, PPTX, PDF e HTML](/slides/it/jasperreports/ppt-pptx-pdf-and-html-export/).