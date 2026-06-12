---
title: Panoramica del prodotto
type: docs
weight: 10
url: /it/jasperreports/product-overview/
---
![Aspose.Slides for JasperReports](product-overview_1.png)

## **Benvenuti in Aspose.Slides per JasperReports!**

Aspose.Slides per JasperReports è una libreria appositamente progettata e sviluppata per gli sviluppatori che hanno bisogno di esportare facilmente i report da JasperReports a Microsoft PowerPoint Presentation (PPT) e Microsoft PowerPoint Show (PPS) nelle loro applicazioni Java. Tutte le funzionalità del report vengono convertite con il più alto grado di precisione in presentazioni Microsoft PowerPoint. Aspose.Slides per JasperReports include il supporto per JasperReports 5+.

## **Descrizione del prodotto**
JasperReports e JasperServer non hanno funzionalità incorporate per esportare i report come presentazioni Microsoft PowerPoint, ma Aspose.Slides per JasperReports ti offre due formati di esportazione aggiuntivi: 

- PPT – Presentazione PowerPoint tramite Aspose.Slides
- PPS - Presentazione PowerPoint Show tramite Aspose.Slides
- PPTX – Presentazione PowerPoint tramite Aspose.Slides
- PPSX - Presentazione PowerPoint Show tramite Aspose.Slides

Aspose.Slides per JasperReports utilizza internamente le nostre librerie Java al 100% puro Aspose.Slides for Java e Aspose.Metafiles for Java, librerie di livello mondiale per la gestione di presentazioni server‑side e metafili.

Aspose.Slides per JasperReports rende possibile esportare qualsiasi report nei formati PPT o PPS.

### **Esempio di output**
La classe ASPptExporter estende la classe ASAbstractExporter in modo da poterla utilizzare allo stesso modo di qualsiasi altro esportatore standard. Questo breve esempio mostra il codice tipico e uno screenshot di un report visualizzato in MS PowerPoint. Esempi dettagliati sono disponibili nei report demo forniti. 

``` java
File sourceFile = new File(fileName); 
JasperPrint jasperPrint = (JasperPrint)JRLoader.loadObject(sourceFile);
File destFile = new File(sourceFile.getParent(), jasperPrint.getName() + ".ppt");
ASPptExporter exporter = new ASPptExporter();
exporter.setParameter(JRExporterParameter.JASPER_PRINT, jasperPrint);
exporter.setParameter(JRExporterParameter.OUTPUT_FILE_NAME, destFile.toString());
exporter.exportReport();
```

**Presentazione generata con la demo JasperReports xmldatasource** 

![Presentazione generata con JasperReports](product-overview_2.png)