---
title: Публичный API и обратные несовместимые изменения в Aspose.Slides для Java 15.2.0
type: docs
weight: 110
url: /androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/
---

{{% alert color="primary" %}} 

На этой странице перечислены все [добавленные](/slides/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/) классы, методы, свойства и так далее, любые новые ограничения и другие [изменения](/slides/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/), введенные с API Aspose.Slides для Java 15.2.0.

{{% /alert %}} {{% alert color="primary" %}} 

Существуют известные проблемы с некоторыми изображениями маркеров и объектами WordArt, которые будут исправлены в Aspose.Slides для Java 15.2.0.

{{% /alert %}} 
## **Изменения публичного API**
### **Добавлены методы addDataPointForDoughnutSeries**
Добавлены две перегрузки метода IChartDataPointCollection.addDataPointForDoughnutSeries() для добавления точек данных в серии типа Doughnut.
### **Класс com.aspose.slides.SmartArtShape наследуется от класса com.aspose.slides.GeometryShape**
Класс com.aspose.slides.SmartArtShape был унаследован от класса com.aspose.slides.GeometryShape. Это изменение улучшает объектную модель Aspose.Slides и добавляет новые функции в класс SmartArtShape.
### **Методы IGradientStopCollection.add(...) и IGradientStopCollection.insert(...) были изменены**
Подпись метода IGradientStop add(float position, int presetColor) заменена на подпись IGradientStop addPresetColor(float position, int presetColor).

Подпись метода IGradientStopCollection IGradientStop add(float position, SchemeColor schemeColor) заменена на IGradientStop addSchemeColor(float position, int schemeColor).

Подпись метода IGradientStopCollection void insert(int index, float position, int presetColor) заменена на void insertPresetColor(int index, float position, int presetColor).

Подпись метода IGradientStopCollection void insert(int index, float position, SchemeColor schemeColor) замена на void insertSchemeColor(int index, float position, int schemeColor).
### **Метод java.awt.Color getAutomaticSeriesColor() добавлен в com.aspose.slides.IChartSeries**
Метод getAutomaticSeriesColor() возвращает автоматический цвет серии на основе индекса серии и стиля графика. Этот цвет используется по умолчанию, если FillType равно NotDefined.
﻿

``` java

 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 50, 600, 400);

for (int i = 0; i < chart.getChartData().getSeries().size(); i++)

{

    chart.getChartData().getSeries().get_Item(i).getAutomaticSeriesColor();

}

```
### **Добавлен метод для удаления точки данных графика и категории графика по индексу**
Метод IChartDataPointCollection.removeAt(int index) добавлен для удаления точки данных графика по индексу.
Метод IChartCategoryCollection.removeAt(int index) добавлен для удаления категории графика по индексу.
### **Значение PptXPptY добавлено в перечисление com.aspose.slides.PropertyType**
Значение PptXPptY добавлено в перечисление com.aspose.slides.PropertyType в рамках исправления проблемы сериализации.