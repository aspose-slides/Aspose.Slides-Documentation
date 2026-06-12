---
title: Přehled produktu
type: docs
weight: 10
url: /cs/jasperreports/product-overview/
---
![Aspose.Slides for JasperReports](product-overview_1.png)

## **Vítejte v Aspose.Slides for JasperReports!**

Aspose.Slides for JasperReports je knihovna speciálně navržená a vyvinutá pro vývojáře, kteří potřebují snadno exportovat zprávy z JasperReports do formátů Microsoft PowerPoint Presentation (PPT) a Microsoft PowerPoint Show (PPS) ve svých Java aplikacích. Všechny funkce zpráv jsou převáděny s nejvyšší přesností do prezentací Microsoft PowerPoint. Aspose.Slides for JasperReports podporuje JasperReports 5+.

## **Popis produktu**
JasperReports a JasperServer nemají vestavěnou funkci pro export zpráv jako prezentace Microsoft PowerPoint, ale Aspose.Slides for JasperReports vám poskytuje přístup ke dvěma dalším exportním formátům:

- PPT – PowerPoint prezentace přes Aspose.Slides
- PPS – PowerPoint ukázka přes Aspose.Slides
- PPTX – PowerPoint prezentace přes Aspose.Slides
- PPSX – PowerPoint ukázka přes Aspose.Slides

Aspose.Slides for JasperReports interně používá naše 100 % čisté Java knihovny Aspose.Slides for Java a Aspose.Metafiles for Java, špičkové knihovny pro serverové zpracování prezentací a metafiles.

Aspose.Slides for JasperReports umožňuje exportovat jakoukoli zprávu do formátu PPT nebo PPS.

### **Příklad výstupu**
Třída ASPptExporter rozšiřuje třídu ASAbstractExporter, takže ji lze použít stejným způsobem jako ostatní standardní exportéry. Tento krátký příklad ukazuje typický kód a snímek obrazovky zprávy zobrazené v MS PowerPoint. Podrobné příklady lze nalézt v dodaných demo zprávách.

``` java
File sourceFile = new File(fileName); 
JasperPrint jasperPrint = (JasperPrint)JRLoader.loadObject(sourceFile);
File destFile = new File(sourceFile.getParent(), jasperPrint.getName() + ".ppt");
ASPptExporter exporter = new ASPptExporter();
exporter.setParameter(JRExporterParameter.JASPER_PRINT, jasperPrint);
exporter.setParameter(JRExporterParameter.OUTPUT_FILE_NAME, destFile.toString());
exporter.exportReport();
```

**Prezentace vygenerovaná pomocí JasperReports xmldatasource demo** 

![Prezentace vygenerovaná pomocí JasperReports](product-overview_2.png)