---
title: Обзор продукта
type: docs
weight: 10
url: /ru/jasperreports/product-overview/
---

{{% alert color="primary" %}} 

![todo:image_alt_text](product-overview_1.png)

## **Добро пожаловать в документацию Aspose.Slides для JasperReports!**
Aspose.Slides для JasperReports — это библиотека, специально разработанная для разработчиков, которым необходимо легко экспортировать отчеты из JasperReports в форматы Microsoft PowerPoint Presentation (PPT) и Microsoft PowerPoint Show (PPS) в их Java-приложениях. Все функции отчета преобразуются с высокой степенью точности в презентации Microsoft PowerPoint. Aspose.Slides для JasperReports поддерживает JasperReports 5+.

{{% /alert %}} 

## **Описание продукта**
JasperReports и JasperServer не имеют встроенных возможностей для экспорта отчетов в виде презентаций Microsoft PowerPoint, но Aspose.Slides для JasperReports предоставляет вам доступ к двум дополнительным форматам экспорта: 

- PPT – Презентация PowerPoint через Aspose.Slides
- PPS - Шоу PowerPoint через Aspose.Slides
- PPTX – Презентация PowerPoint через Aspose.Slides
- PPSX - Шоу PowerPoint через Aspose.Slides

Aspose.Slides для JasperReports внутренне использует наши 100% чистые Java-библиотеки Aspose.Slides для Java и Aspose.Metafiles для Java, библиотеки мирового класса для обработки серверных презентаций и метафайлов.

Aspose.Slides для JasperReports позволяет экспортировать любой отчет в формате PPT или PPS.

### **Пример вывода**
Класс ASPptExporter расширяет класс ASAbstractExporter, так что его можно использовать так же, как и любые другие стандартные экспортеры. Этот короткий пример показывает типичный код и скриншот отчета, просмотренного в MS PowerPoint. Подробные примеры можно найти в предоставленных демонстрационных отчетах.

``` java
File sourceFile = new File(fileName); 
JasperPrint jasperPrint = (JasperPrint)JRLoader.loadObject(sourceFile);
File destFile = new File(sourceFile.getParent(), jasperPrint.getName() + ".ppt");
ASPptExporter exporter = new ASPptExporter();
exporter.setParameter(JRExporterParameter.JASPER_PRINT, jasperPrint);
exporter.setParameter(JRExporterParameter.OUTPUT_FILE_NAME, destFile.toString());
exporter.exportReport();
```

**Презентация, созданная с помощью демонстрационного xmldatasource JasperReports** 

![todo:image_alt_text](product-overview_2.png)