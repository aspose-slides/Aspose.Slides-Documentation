---
title: Produktübersicht
type: docs
weight: 10
url: /jasperreports/product-overview/
---

{{% alert color="primary" %}} 

![todo:image_alt_text](product-overview_1.png)

## **Willkommen zur Aspose.Slides für JasperReports-Dokumentation!**
Aspose.Slides für JasperReports ist eine Bibliothek, die speziell für Entwickler entwickelt wurde, die Berichte aus JasperReports einfach in Microsoft PowerPoint Präsentationen (PPT) und Microsoft PowerPoint Shows (PPS) in ihren Java-Anwendungen exportieren müssen. Alle Berichtsfunktionen werden mit dem höchsten Präzisionsgrad in Microsoft PowerPoint-Präsentationen konvertiert. Aspose.Slides für JasperReports unterstützt JasperReports 5+.

{{% /alert %}} 

## **Produktbeschreibung**
JasperReports und JasperServer haben keine integrierten Möglichkeiten, Berichte als Microsoft PowerPoint-Präsentationen zu exportieren, aber Aspose.Slides für JasperReports bietet Ihnen Zugang zu zwei zusätzlichen Exportformaten:

- PPT – PowerPoint-Präsentation über Aspose.Slides
- PPS – PowerPoint-Show über Aspose.Slides
- PPTX – PowerPoint-Präsentation über Aspose.Slides
- PPSX – PowerPoint-Show über Aspose.Slides

Aspose.Slides für JasperReports verwendet intern unsere 100% reinen Java-Bibliotheken Aspose.Slides für Java und Aspose.Metafiles für Java, weltweit führende Bibliotheken für serverseitige Präsentationen und Metafile-Verarbeitung.

Aspose.Slides für JasperReports macht es möglich, jeden Bericht im PPT- oder PPS-Format zu exportieren.

### **Ausgabe Beispiel**
Die ASPptExporter-Klasse erweitert die ASAbstractExporter-Klasse, sodass sie auf die gleiche Weise wie andere Standardexporter verwendet werden kann. Dieses kurze Beispiel zeigt typischen Code und einen Screenshot eines Berichts, der in MS PowerPoint angezeigt wird. Detaillierte Beispiele sind in den bereitgestellten Demoberichten zu finden.

``` java
File sourceFile = new File(fileName); 
JasperPrint jasperPrint = (JasperPrint)JRLoader.loadObject(sourceFile);
File destFile = new File(sourceFile.getParent(), jasperPrint.getName() + ".ppt");
ASPptExporter exporter = new ASPptExporter();
exporter.setParameter(JRExporterParameter.JASPER_PRINT, jasperPrint);
exporter.setParameter(JRExporterParameter.OUTPUT_FILE_NAME, destFile.toString());
exporter.exportReport();
```

**Präsentation erstellt mit JasperReports xmldatasource-Demo** 

![todo:image_alt_text](product-overview_2.png)