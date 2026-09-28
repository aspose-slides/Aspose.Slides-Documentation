---
title: Обзор продукта
type: docs
weight: 10
url: /ru/jasperreports/product-overview/
description: "Узнайте, что делает Aspose.Slides for JasperReports, какие версии JasperReports и форматы вывода он поддерживает, и для чего предназначены его два jar‑файла."
---
![Aspose.Slides для JasperReports](product-overview_1.png)

## **Описание продукта**

Aspose.Slides for JasperReports экспортирует отчёты из JasperReports в презентации PowerPoint в Java‑приложениях и в JasperReports Server без установки Microsoft PowerPoint. Он поддерживает JasperReports 3.7.2‑6.16.0, при этом для каждого диапазона версий есть отдельный jar — см. [Installing Aspose.Slides for JasperReports](/slides/ru/jasperreports/installing-aspose-slides-for-jasperreports/).

Он экспортирует заполненный отчёт в четыре формата, один слайд или страница на каждую страницу отчёта:

- PPT – презентация PowerPoint 97–2003
- PPTX – презентация PowerPoint (Office Open XML)
- PDF
- HTML

Продукт состоит из двух компонентов:

- Библиотечный jar добавляет экспортеры `ASPptExporter`, `ASPptxExporter`, `ASPdfExporter` и `ASHtmlExporter` в JasperReports Library.
- Серверный jar предоставляет действия экспорта для тех же четырёх форматов, которые вы регистрируете в JasperReports Server — см. [Integration with JasperServer](/slides/ru/jasperreports/integration-with-jasperserver/).

### **Пример вывода**

Экспортеры наследуют собственные классы экспорта JasperReports и используются одинаково: им передаётся заполненный отчёт и файл вывода, после чего вызывается `exportReport`. Для полного примера программы, заполняющей отчёт и экспортирующей его в PPTX, см. [Your first export](/slides/ru/jasperreports/#your-first-export); для всех четырёх форматов — см. [PPT, PPTX, PDF and HTML Export](/slides/ru/jasperreports/ppt-pptx-pdf-and-html-export/).

![Отчёт, экспортированный в презентацию без лицензии, с водяным знаком оценки в центре слайда](product-overview_2.png)