---
title: Produktöversikt
type: docs
weight: 10
url: /sv/jasperreports/product-overview/
---
![Aspose.Slides för JasperReports](product-overview_1.png)

## **Välkommen till Aspose.Slides för JasperReports!**

Aspose.Slides för JasperReports är ett bibliotek som är speciellt utformat och utvecklat för utvecklare som behöver enkelt exportera rapporter från JasperReports till Microsoft PowerPoint Presentation (PPT) och Microsoft PowerPoint Show (PPS)-format i sina Java-applikationer. Alla rapportfunktioner konverteras med högsta precision till Microsoft PowerPoint-presentationer. Aspose.Slides för JasperReports inkluderar stöd för JasperReports 5+.

## **Produktbeskrivning**
JasperReports och JasperServer har inte inbyggda möjligheter att exportera rapporter som Microsoft PowerPoint-presentationer, men Aspose.Slides för JasperReports ger dig åtkomst till två ytterligare exportformat:

- PPT – PowerPoint-presentation via Aspose.Slides
- PPS – PowerPoint-show via Aspose.Slides
- PPTX – PowerPoint-presentation via Aspose.Slides
- PPSX – PowerPoint-show via Aspose.Slides

Aspose.Slides för JasperReports använder internt våra 100 % rena Java-bibliotek Aspose.Slides for Java och Aspose.Metafiles for Java, världsledande bibliotek för server-side-presentationer och metafilshantering.

Aspose.Slides för JasperReports gör det möjligt att exportera vilken rapport som helst i PPT- eller PPS-format.

### **Exempel på utdata**
Klassen ASPptExporter ärver klassen ASAbstractExporter så att den kan användas på samma sätt som alla andra standardexportörer. Detta korta exempel visar typisk kod och en skärmdump av en rapport som visas i MS PowerPoint. Detaljerade exempel finns i de medföljande demorapporterna.

``` java
File sourceFile = new File(fileName); 
JasperPrint jasperPrint = (JasperPrint)JRLoader.loadObject(sourceFile);
File destFile = new File(sourceFile.getParent(), jasperPrint.getName() + ".ppt");
ASPptExporter exporter = new ASPptExporter();
exporter.setParameter(JRExporterParameter.JASPER_PRINT, jasperPrint);
exporter.setParameter(JRExporterParameter.OUTPUT_FILE_NAME, destFile.toString());
exporter.exportReport();
```

**Presentation genererad med JasperReports xmldatasource-demo** 

![Presentation genererad med JasperReports](product-overview_2.png)