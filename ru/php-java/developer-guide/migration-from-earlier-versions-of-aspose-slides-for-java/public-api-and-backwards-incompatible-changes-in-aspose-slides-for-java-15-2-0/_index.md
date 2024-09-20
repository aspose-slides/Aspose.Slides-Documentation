---
title: Публичное API и несовместимые изменения в Aspose.Slides для PHP через Java 15.2.0
type: docs
weight: 110
url: /php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/
---

{{% alert color="primary" %}} 

Эта страница содержит список всех [добавленных](/slides/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/) классов, методов, свойств и т.д., любых новых ограничений и других [изменений](/slides/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/), введенных в API Aspose.Slides для PHP через Java 15.2.0.

{{% /alert %}} {{% alert color="primary" %}} 

Существует известная проблема с некоторыми маркерами изображений и объектами WordArt, которые будут исправлены в Aspose.Slides для PHP через Java 15.2.0.

{{% /alert %}} 
## **Изменения в публичном API**
### **Добавлены методы addDataPointForDoughnutSeries**
Добавлены два перегруженных метода IChartDataPointCollection.addDataPointForDoughnutSeries() для добавления данных в серию типа "Пончик".
### **Класс com.aspose.slides.SmartArtShape наследован от класса com.aspose.slides.GeometryShape**
Класс com.aspose.slides.SmartArtShape был унаследован от класса com.aspose.slides.GeometryShape. Это изменение улучшает объектную модель Aspose.Slides и добавляет новые функции в класс SmartArtShape.
### **Изменены методы IGradientStopCollection.add(...) и IGradientStopCollection.insert(...)**
Подпись метода IGradientStop add(float position, int presetColor) заменена на IGradientStop addPresetColor(float position, int presetColor).

Подпись метода IGradientStopCollection IGradientStop add(float position, SchemeColor schemeColor) заменена на IGradientStop addSchemeColor(float position, int schemeColor).

Подпись метода IGradientStopCollection void insert(int index, float position, int presetColor) заменена на void insertPresetColor(int index, float position, int presetColor).

Подпись метода IGradientStopCollection void insert(int index, float position, SchemeColor schemeColor) заменена на void insertSchemeColor(int index, float position, int schemeColor).
### **Метод java.awt.Color getAutomaticSeriesColor() добавлен в com.aspose.slides.IChartSeries**
Метод getAutomaticSeriesColor() возвращает автоматический цвет серии на основе индекса серии и стиля графика. Этот цвет используется по умолчанию, если FillType равен NotDefined.
﻿

```php
  $pres = new Presentation();
  $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 50, 600, 400);
  for($i = 0; $i < java_values($chart->getChartData()->getSeries()->size()) ; $i++) {
    $chart->getChartData()->getSeries()->get_Item($i)->getAutomaticSeriesColor();
  }
```
### **Добавлен метод для удаления точки данных графика и категории графика по индексу**
Добавлен метод IChartDataPointCollection.removeAt(int index) для удаления точки данных графика по индексу.
Добавлен метод IChartCategoryCollection.removeAt(int index) для удаления категории графика по индексу.
### **Значение PptXPptY добавлено в перечисление com.aspose.slides.PropertyType**
Значение PptXPptY добавлено в перечисление com.aspose.slides.PropertyType в рамках исправления проблемы сериализации.