---
title: Публичный API и несовместимые изменения в Aspose.Slides для Java 14.8.0
linktitle: Aspose.Slides для Java 14.8.0
type: docs
weight: 70
url: /ru/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-8-0/
keywords:
- миграция
- устаревший код
- современный код
- устаревший подход
- современный подход
- PowerPoint
- OpenDocument
- презентация
- Java
- Aspose.Slides
description: "Обзор обновлений публичного API и критических изменений в Aspose.Slides для Java для плавной миграции ваших решений по работе с презентациями PowerPoint PPT, PPTX и ODP."
---
{{% alert color="info" %}} 

Эта страница перечисляет все [добавленные](/slides/ru/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-8-0/) классы, методы, свойства и т.д., любые новые ограничения и другие [изменения](/slides/ru/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-8-0/) внедрённые в API Aspose.Slides for Java 14.8.0.

{{% /alert %}} 
## **Изменения публичного API**
### **Добавлены методы Aspose.Slides.Charts.IChartSeries.getOverlap(), IChartSeriesGroup.getOverlap() и setOverlap(byte)**
Метод Aspose.Slides.Charts.IChartSeries.getOverlap() определяет, насколько столбцы и полосы должны перекрываться на 2D‑диаграммах (в диапазоне от -100 до 100). Этот метод применяется не только к отдельной серии, но ко всем сериям родительской группы серий — это проекция соответствующего свойства группы.

- Используйте метод IChartSeries.getParentSeriesGroup() для доступа к родительской группе серий.
- Используйте методы IChartSeriesGroup.getOverlap() и setOverlap(byte) для управления значением.

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);

IChartSeriesCollection series = chart.getChartData().getSeries();

if (series.get_Item(0).getOverlap() == 0) {

  series.get_Item(0).getParentSeriesGroup().setOverlap((byte)-30);

}

```
### **Добавлено значение перечисления ShapeThumbnailBounds.Appearance**
Этот способ создания миниатюр фигур позволяет разработчикам генерировать миниатюру фигуры в границах её отображения. При этом учитываются все эффекты фигуры. Сгенерированная миниатюра ограничена границами слайда.

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation("Presentation.pptx");

IImage st = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Appearance, 1, 1);

```
### **Добавлены класс VbaProject и интерфейс IVbaProject, изменены методы Presentation.getVbaProject() и setVbaProject(VbaProject)**
Новая возможность позволяет разработчикам создавать и редактировать VBA‑проекты в презентации.

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

// Создать новый VBA проект

pres.setVbaProject(new VbaProject());

// Добавить пустой модуль в VBA проект

IVbaModule module = pres.getVbaProject().getModules().addEmptyModule("Module");

// Установить исходный код модуля

module.setSourceCode("Sub Test(oShape As Shape)\r\n    MsgBox \"Test\"\r\nEnd Sub");

// Создать ссылку на <stdole>

VbaReferenceOleTypeLib stdoleReference =

  new VbaReferenceOleTypeLib("stdole",

    "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");

// Создать ссылку на Office

VbaReferenceOleTypeLib officeReference =

  new VbaReferenceOleTypeLib("Office",

    "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");

// Добавить ссылки в VBA проект

pres.getVbaProject().getReferences().add(stdoleReference);

pres.getVbaProject().getReferences().add(officeReference);

pres.save("test.pptm", SaveFormat.Pptm);
```