---
title: Экспорт PPT, PPTX, PDF и HTML
type: docs
weight: 20
url: /ru/jasperreports/ppt-pptx-pdf-and-html-export/
description: "Выберите экспортёр Aspose.Slides for JasperReports для вывода в PPT, PPTX, PDF или HTML, экспортируйте заполненный отчёт с его помощью и сопоставьте шрифты отчёта с шрифтами презентации."
---
## **Экспортёры**

Aspose.Slides for JasperReports добавляет в JasperReports четыре экспортёра. Каждый из них принимает заполненный отчёт (`JasperPrint`) и экспортирует каждую страницу отчёта: как слайд в PPT и PPTX, как страницу в PDF и как изображение SVG в едином HTML‑файле.

| Формат вывода | Класс экспортёра |
| :- | :- |
| PPT (PowerPoint 97–2003) | `ASPptExporter` |
| PPTX | `ASPptxExporter` |
| PDF | `ASPdfExporter` |
| HTML | `ASHtmlExporter` |

Классы находятся в пакете `com.aspose.slides.jasperreports` библиотеки jar и не используют Microsoft PowerPoint. Передайте отчёт и выходной файл экспортёру с помощью `setParameter` и `JRExporterParameter`, которые JasperReports отмечает как устаревшие: экспортёры не принимают более новые настройки `setExporterInput` и `setExporterOutput`.

## **Экспорт отчёта во все четыре формата**

Программа ниже построена на проекте из [Ваш первый экспорт](/slides/ru/jasperreports/#your-first-export). Она компилирует и заполняет *hello.jrxml* один раз, а затем поочерёдно передаёт заполненный отчёт каждому экспортёру. Сохраните её как *src/main/java/ExportAllFormats.java* в этом проекте:

```java
import java.util.HashMap;

import com.aspose.slides.jasperreports.ASAbstractExporter;
import com.aspose.slides.jasperreports.ASHtmlExporter;
import com.aspose.slides.jasperreports.ASPdfExporter;
import com.aspose.slides.jasperreports.ASPptExporter;
import com.aspose.slides.jasperreports.ASPptxExporter;
import net.sf.jasperreports.engine.JREmptyDataSource;
import net.sf.jasperreports.engine.JRException;
import net.sf.jasperreports.engine.JRExporterParameter;
import net.sf.jasperreports.engine.JasperCompileManager;
import net.sf.jasperreports.engine.JasperFillManager;
import net.sf.jasperreports.engine.JasperPrint;
import net.sf.jasperreports.engine.JasperReport;

public class ExportAllFormats {
    public static void main(String[] args) throws Exception {
        // Скомпилировать и заполнить отчёт один раз.
        JasperReport report = JasperCompileManager.compileReport("hello.jrxml");
        JasperPrint jasperPrint = JasperFillManager.fillReport(report, new HashMap<String, Object>(), new JREmptyDataSource());

        // Экспортировать один и тот же заполненный отчёт с каждым экспортёром.
        export(new ASPptExporter(), jasperPrint, "hello.ppt");
        export(new ASPptxExporter(), jasperPrint, "hello.pptx");
        export(new ASPdfExporter(), jasperPrint, "hello.pdf");
        export(new ASHtmlExporter(), jasperPrint, "hello.html");
    }

    private static void export(ASAbstractExporter exporter, JasperPrint jasperPrint, String outputFileName) throws JRException {
        exporter.setParameter(JRExporterParameter.JASPER_PRINT, jasperPrint);
        exporter.setParameter(JRExporterParameter.OUTPUT_FILE_NAME, outputFileName);
        exporter.exportReport();
    }
}
```

Запустите её из папки проекта:

```bash
mvn compile exec:java "-Dexec.mainClass=ExportAllFormats"
```

Программа сохраняет *hello.ppt*, *hello.pptx*, *hello.pdf* и *hello.html* в папке проекта. Вспомогательный метод принимает `ASAbstractExporter`, базовый класс всех четырёх экспортёров. Без лицензии каждый выходной файл содержит водяной знак оценки — см. [Оценка Aspose.Slides](/slides/ru/jasperreports/evaluate-aspose-slides/).

![Отчёт, экспортированный в презентацию без лицензии](ppt-pptx-pdf-and-html-export_1.png)

## **Сопоставление шрифтов**

Экспортёры PPT и PPTX записывают имена шрифтов дизайна отчёта в презентацию без изменений. Когда текстовый элемент не указывает шрифт, JasperReports использует шрифт по умолчанию — `SansSerif`, который является логическим именем шрифта Java, а не установленным шрифтом. Чтобы заменить такие имена, передайте карту из имён шрифтов отчёта в имена шрифтов, которые вы хотите видеть в презентации, через параметр `ASExporterParameters.PPT_FONT_MAP`. Ключи должны точно соответствовать именам шрифтов в отчёте, включая регистр. Каждое значение должно быть шрифтом, который Java найдёт на машине, где выполняется экспорт; экспортёры игнорируют запись, если шрифт не найден.

Сохраните эту программу как *src/main/java/MapFonts.java* в том же проекте. Она экспортирует *hello.jrxml* в PPTX, заменяя `SansSerif` на Arial:

```java
import java.util.HashMap;
import java.util Map;

import com.aspose.slides.jasperreports.ASExporterParameters;
import com.aspose.slides.jasperreports.ASPptxExporter;
import net.sf.jasperreports.engine.JREmptyDataSource;
import net.sf.jasperreports.engine.JRExporterParameter;
import net.sf.jasperreports.engine.JasperCompileManager;
import net.sf.jasperreports.engine.JasperFillManager;
import net.sf.jasperreports.engine.JasperPrint;
import net.sf.jasperreports.engine.JasperReport;

public class MapFonts {
    public static void main(String[] args) throws Exception {
        JasperReport report = JasperCompileManager.compileReport("hello.jrxml");
        JasperPrint jasperPrint = JasperFillManager.fillReport(report, new HashMap<String, Object>(), new JREmptyDataSource());

        // Сопоставьте имя шрифта отчёта с именем шрифта, которое будет записано в презентацию.
        Map<String, String> fontMap = new HashMap<String, String>();
        fontMap.put("SansSerif", "Arial");

        ASPptxExporter exporter = new ASPptxExporter();
        exporter.setParameter(JRExporterParameter.JASPER_PRINT, jasperPrint);
        exporter.setParameter(JRExporterParameter.OUTPUT_FILE_NAME, "hello-arial.pptx");
        exporter.setParameter(ASExporterParameters.PPT_FONT_MAP, fontMap);
        exporter.exportReport();
    }
}
```

Запустите её из папки проекта:

```bash
mvn compile exec:java "-Dexec.mainClass=MapFonts"
```

В сохранённом *hello-arial.pptx* текст отчёта использует Arial вместо `SansSerif`. На машине, где Java не находит Arial, например в Linux‑системе без этого шрифта, текст остаётся `SansSerif`. На JasperReports Server задайте ту же карту через свойство `fontMap` bean‑а параметров экспорта — см. [Интеграция с JasperServer](/slides/ru/jasperreports/integration-with-jasperserver/#set-font-mapping-and-the-license).