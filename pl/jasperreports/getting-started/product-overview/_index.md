---
title: Przegląd produktu
type: docs
weight: 10
url: /pl/jasperreports/product-overview/
---
![Aspose.Slides for JasperReports](product-overview_1.png)

## **Witamy w Aspose.Slides for JasperReports!**

Aspose.Slides for JasperReports to biblioteka specjalnie zaprojektowana i opracowana dla programistów, którzy potrzebują łatwo eksportować raporty z JasperReports do formatów Microsoft PowerPoint Presentation (PPT) i Microsoft PowerPoint Show (PPS) w swoich aplikacjach Java. Wszystkie funkcje raportu są konwertowane z najwyższą precyzją na prezentacje Microsoft PowerPoint. Aspose.Slides for JasperReports zawiera wsparcie dla JasperReports 5+.

## **Opis produktu**
JasperReports i JasperServer nie posiadają wbudowanych możliwości eksportu raportów jako prezentacji Microsoft PowerPoint, ale Aspose.Slides for JasperReports daje dostęp do dwóch dodatkowych formatów eksportu: 

- PPT – prezentacja PowerPoint za pośrednictwem Aspose.Slides
- PPS - pokaz PowerPoint za pośrednictwem Aspose.Slides
- PPTX – prezentacja PowerPoint za pośrednictwem Aspose.Slides
- PPSX - pokaz PowerPoint za pośrednictwem Aspose.Slides

Aspose.Slides for JasperReports wewnętrznie używa naszych w 100% czystych bibliotek Java: Aspose.Slides for Java oraz Aspose.Metafiles for Java, światowej klasy bibliotek do przetwarzania prezentacji po stronie serwera i metaplików.

Aspose.Slides for JasperReports umożliwia eksport dowolnego raportu w formacie PPT lub PPS.

### **Przykład wyjścia**
Klasa ASPptExporter dziedziczy po klasie ASAbstractExporter, dzięki czemu może być używana w taki sam sposób jak inne standardowe eksportery. Ten krótki przykład pokazuje typowy kod oraz zrzut ekranu raportu wyświetlanego w MS PowerPoint. Szczegółowe przykłady można znaleźć w dostarczonych raportach demonstracyjnych. 

``` java
File sourceFile = new File(fileName); 
JasperPrint jasperPrint = (JasperPrint)JRLoader.loadObject(sourceFile);
File destFile = new File(sourceFile.getParent(), jasperPrint.getName() + ".ppt");
ASPptExporter exporter = new ASPptExporter();
exporter.setParameter(JRExporterParameter.JASPER_PRINT, jasperPrint);
exporter.setParameter(JRExporterParameter.OUTPUT_FILE_NAME, destFile.toString());
exporter.exportReport();
```

**Prezentacja wygenerowana przy użyciu demonstracji JasperReports xmldatasource** 

![Prezentacja wygenerowana przy użyciu JasperReports](product-overview_2.png)