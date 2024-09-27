---
title: Публичный API и несовместимые изменения в Aspose.Slides для Java 14.8.0
type: docs
weight: 70
url: /ru/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-8-0/
---

{{% alert color="primary" %}} 

Эта страница перечисляет все [добавленные](/slides/ru/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-8-0/) классы, методы, свойства и так далее, любые новые ограничения и другие [изменения](/slides/ru/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-8-0/), введенные с API Aspose.Slides для Java 14.8.0.

{{% /alert %}} 
## **Изменения публичного API**
### **Добавлены методы Aspose.Slides.Charts.IChartSeries.getOverlap(), IChartSeriesGroup.getOverlap() и setOverlap(byte)**
Метод Aspose.Slides.Charts.IChartSeries.getOverlap() возвращает, насколько должны перекрываться бары и колонки на 2D графиках (в диапазоне от -100 до 100).
Этот метод предназначен не только для конкретных серий, но и для всех серий родительской группы серий - это проекция соответствующего свойства группы.

- Используйте метод IChartSeries.getParentSeriesGroup() для доступа к родительской группе серий.
- Используйте методы IChartSeriesGroup.getOverlap() и setOverlap(byte) для управления значением.

``` java

 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);

IChartSeriesCollection series = chart.getChartData().getSeries();

if (series.get_Item(0).getOverlap() == 0) {

  series.get_Item(0).getParentSeriesGroup().setOverlap(-30);

}

```
### **Добавлено значение перечисления ShapeThumbnailBounds.Appearance**
Этот метод создания миниатюр фигур позволяет разработчикам генерировать миниатюру фигуры в пределах её внешнего вида. Он учитывает все эффекты фигуры. Сгенерированная миниатюра фигуры ограничена границами слайда.

``` java

 Presentation pres = new Presentation();

BufferedImage st = pres.getSlides().get_Item(0).getShapes().get_Item(0).getThumbnail(ShapeThumbnailBounds.Appearance, 1, 1);

```
### **Добавлены классы VbaProject и интерфейс IVbaProject, изменены методы Presentation.getVbaProject() и setVbaProject(VbaProject)**
Новая функция позволяет разработчикам создавать и редактировать VBA проекты в презентации.

``` java

 Presentation pres = new Presentation();

// Создание нового VBA проекта

pres.setVbaProject(new VbaProject());

// Добавление пустого модуля в VBA проект

IVbaModule module = pres.getVbaProject().getModules().addEmptyModule("Module");

// Установка исходного кода модуля

module.setSourceCode("Sub Test(oShape As Shape)\r\n    MsgBox \"Test\"\r\nEnd Sub");

// Создание ссылки на <stdole>

VbaReferenceOleTypeLib stdoleReference =

  new VbaReferenceOleTypeLib("stdole",

    "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");

// Создание ссылки на Office

VbaReferenceOleTypeLib officeReference =

  new VbaReferenceOleTypeLib("Office",

    "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Библиотека объектов Microsoft Office 14.0");

// Добавление ссылок в VBA проект

pres.getVbaProject().getReferences().add(stdoleReference);

pres.getVbaProject().getReferences().add(officeReference);

pres.save("data\\test.pptm", SaveFormat.Pptm);

```