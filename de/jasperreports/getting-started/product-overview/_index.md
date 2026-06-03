---
title: Produktübersicht
type: docs
weight: 10
url: /de/jasperreports/product-overview/
---
![Aspose.Slides für JasperReports](product-overview_1.png)

## **Willkommen bei Aspose.Slides für JasperReports!**

Aspose.Slides for JasperReports ist eine Bibliothek, die speziell für Entwickler entwickelt wurde, die Berichte aus JasperReports einfach in Microsoft PowerPoint Presentation (PPT) und Microsoft PowerPoint Show (PPS)-Formate in ihren Java‑Anwendungen exportieren müssen. Alle Berichtsfunktionen werden mit höchster Präzision in Microsoft PowerPoint‑Präsentationen konvertiert. Aspose.Slides for JasperReports unterstützt JasperReports 5+.

## **Produktbeschreibung**
JasperReports und JasperServer verfügen nicht über eingebaute Funktionen zum Exportieren von Berichten als Microsoft PowerPoint‑Präsentationen, aber Aspose.Slides for JasperReports bietet Ihnen Zugriff auf zwei zusätzliche Exportformate: 

- PPT – PowerPoint‑Präsentation über Aspose.Slides
- PPS – PowerPoint‑Show über Aspose.Slides
- PPTX – PowerPoint‑Präsentation über Aspose.Slides
- PPSX – PowerPoint‑Show über Aspose.Slides

Aspose.Slides for JasperReports verwendet intern unsere 100 % reinen Java‑Bibliotheken Aspose.Slides for Java und Aspose.Metafiles for Java, erstklassige Bibliotheken für serverseitige Präsentationen und die Verarbeitung von Metadateien.

Aspose.Slides for JasperReports ermöglicht den Export jedes Berichts im PPT‑ oder PPS‑Format.

### **Ausgabebeispiel**
Die Klasse ASPptExporter erweitert die Klasse ASAbstractExporter, sodass sie auf dieselbe Weise wie andere Standardexporter verwendet werden kann. Dieses kurze Beispiel zeigt typischen Code und einen Screenshot eines Berichts, der in MS PowerPoint angezeigt wird. Detaillierte Beispiele finden Sie in den bereitgestellten Demo‑Berichten. 

``` java
File sourceFile = new File(fileName); 
JasperPrint jasperPrint = (JasperPrint)JRLoader.loadObject(sourceFile);
File destFile = new File(sourceFile.getParent(), jasperPrint.getName() + ".ppt");
ASPptExporter exporter = new ASPptExporter();
exporter.setParameter(JRExporterParameter.JASPER_PRINT, jasperPrint);
exporter.setParameter(JRExporterParameter.OUTPUT_FILE_NAME, destFile.toString());
exporter.exportReport();
```

**Präsentation erstellt mit dem JasperReports‑xmldatasource‑Demo** 

![Präsentation erstellt mit JasperReports](product-overview_2.png)