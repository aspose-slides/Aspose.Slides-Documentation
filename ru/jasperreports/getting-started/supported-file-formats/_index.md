---
title: Поддерживаемые форматы файлов
type: docs
weight: 20
url: /ru/jasperreports/supported-file-formats/
description: "Посмотрите, какие входные данные принимает Aspose.Slides for JasperReports и в какие форматы файлов он экспортирует отчёты."
---
## **Ввод**

Aspose.Slides for JasperReports экспортирует отчёты; он не преобразует существующие презентации. Его экспортеры принимают заполненный JasperReports отчёт (`JasperPrint`), такой как результат `JasperFillManager` или заполненный отчёт, загруженный из файла *.jrprint*.

## **Форматы вывода**

В следующей таблице перечислены форматы, в которые Aspose.Slides for JasperReports экспортирует отчёт, и класс‑экспортер, который записывает каждый из них.

|**Формат**|**Описание**|**Экспортер**|
| :- | :- | :- |
|[PPT](https://docs.fileformat.com/presentation/ppt/)|Презентация PowerPoint 97–2003; один слайд на страницу отчёта|`ASPptExporter`|
|[PPTX](https://docs.fileformat.com/presentation/pptx/)|Презентация PowerPoint (Office Open XML); один слайд на страницу отчёта|`ASPptxExporter`|
|[PDF](https://docs.fileformat.com/pdf/)|Формат Portable Document Format; одна страница PDF на страницу отчёта|`ASPdfExporter`|
|[HTML](https://docs.fileformat.com/web/html/)|Один файл HTML с одним изображением SVG на страницу отчёта|`ASHtmlExporter`|

Экспортеров для форматов показов слайдов PPS и PPSX нет. Если задать экспортируемому PPTX имя файла *.ppsx*, будет создана презентация PPTX, а не показ слайдов. Чтобы увидеть, как используется каждый экспортер, см. [PPT, PPTX, PDF and HTML Export](/slides/ru/jasperreports/ppt-pptx-pdf-and-html-export/).