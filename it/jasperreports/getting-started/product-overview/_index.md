---
title: Panoramica del prodotto
type: docs
weight: 10
url: /it/jasperreports/product-overview/
description: "Scopri cosa fa Aspose.Slides for JasperReports, quali versioni di JasperReports e formati di output supporta, e a cosa servono i suoi due jar."
---
![Aspose.Slides for JasperReports](product-overview_1.png)

## **Descrizione del prodotto**

Aspose.Slides for JasperReports esporta i report da JasperReports a presentazioni PowerPoint, nelle applicazioni Java e in JasperReports Server, senza Microsoft PowerPoint. Supporta JasperReports dalla versione 3.7.2 alla 6.16.0, con un jar separato per ogni intervallo di versioni — vedi [Installazione di Aspose.Slides per JasperReports](/slides/it/jasperreports/installing-aspose-slides-for-jasperreports/).

Esporta un report compilato in quattro formati, una slide o pagina per pagina del report:

- PPT – presentazione PowerPoint 97–2003
- PPTX – presentazione PowerPoint (Office Open XML)
- PDF – PDF
- HTML – HTML

Il prodotto è composto da due parti:

- Il jar della libreria aggiunge gli esportatori `ASPptExporter`, `ASPptxExporter`, `ASPdfExporter` e `ASHtmlExporter` a JasperReports Library.
- Il jar del server fornisce azioni di esportazione per gli stessi quattro formati, che si registrano in JasperReports Server — vedi [Integrazione con JasperServer](/slides/it/jasperreports/integration-with-jasperserver/).

### **Esempio di output**

Gli esportatori estendono le classi di esportazione proprie di JasperReports e sono usati allo stesso modo: passar loro il report compilato e il file di output, quindi chiamare `exportReport`. Per un programma completo che compila un report e lo esporta in PPTX, vedi [Il tuo primo export](/slides/it/jasperreports/#your-first-export); per tutti e quattro i formati, vedi [Esportazione PPT, PPTX, PDF e HTML](/slides/it/jasperreports/ppt-pptx-pdf-and-html-export/).

![Un report esportato in una presentazione senza licenza, con la filigrana di valutazione al centro della slide](product-overview_2.png)