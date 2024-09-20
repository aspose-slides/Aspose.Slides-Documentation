---
title: Публичное API и некорректные изменения в Aspose.Slides для Java 15.2.0
type: docs
weight: 110
url: /java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/
---

{{% alert color="primary" %}} 

Эта страница содержит все [добавленные](/slides/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/) классы, методы, свойства и так далее, новые ограничения и другие [изменения](/slides/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/), введенные с API Aspose.Slides для Java 15.2.0.

{{% /alert %}} {{% alert color="primary" %}} 

Существуют известные проблемы с некоторыми маркерами изображений и объектами WordArt, которые будут исправлены в Aspose.Slides для Java 15.2.0.

{{% /alert %}} 
## **Изменения в публичном API**
### **Добавлены методы addDataPointForDoughnutSeries**
Добавлены два перегруженных метода IChartDataPointCollection.addDataPointForDoughnutSeries() для добавления точек данных в серии типа Doughnut.
### **Класс com.aspose.slides.SmartArtShape унаследован от класса com.aspose.slides.GeometryShape**
Класс com.aspose.slides.SmartArtShape унаследован от класса com.aspose.slides.GeometryShape. Это изменение улучшает объектную модель Aspose.Slides и добавляет новые функции в класс SmartArtShape.
### **Изменены методы IGradientStopCollection.add(...) и IGradientStopCollection.insert(...)**
Подпись метода IGradientStop add(float position, int presetColor) заменена на подпись IGradientStop addPresetColor(float position, int presetColor).

Подпись метода коллекции IGradientStopCollection IGradientStop add(float position, SchemeColor schemeColor) заменена на подпись IGradientStop addSchemeColor(float position, int schemeColor).

Подпись метода коллекции IGradientStopCollection void insert(int index, float position, int presetColor) заменена на подпись void insertPresetColor(int index, float position, int presetColor).

Подпись метода коллекции IGradientStopCollection void insert(int index, float position, SchemeColor schemeColor) заменена на подпись void insertSchemeColor(int index, float position, int schemeColor).
### **Метод java.awt.Color getAutomaticSeriesColor() добавлен в com.aspose.slides.IChartSeries**
Метод getAutomaticSeriesColor() возвращает автоматический цвет серии на основе индекса серии и стиля диаграммы. Этот цвет используется по умолчанию, если FillType равен NotDefined.
﻿

``` java

 Презентация pres = новая Презентация();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 50, 600, 400);

для (int i = 0; i < chart.getChartData().getSeries().size(); i++)

{

    chart.getChartData().getSeries().get_Item(i).getAutomaticSeriesColor();

}

```
### **Метод для удаления точек данных диаграммы и категорий диаграммы по индексу добавлен**
Метод IChartDataPointCollection.removeAt(int index) добавлен для удаления точки данных диаграммы по индексу.
Метод IChartCategoryCollection.removeAt(int index) добавлен для удаления категории диаграммы по индексу.
### **Значение PptXPptY добавлено в перечисление com.aspose.slides.PropertyType**
Значение PptXPptY добавлено в перечисление com.aspose.slides.PropertyType в рамках исправления проблемы сериализации.