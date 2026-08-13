---
title: Публичный API и несовместимые изменения в Aspose.Slides for Java 15.2.0
linktitle: Aspose.Slides for Java 15.2.0
type: docs
weight: 110
url: /ru/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/
keywords:
- миграция
- унаследованный код
- современный код
- унаследованный подход
- современный подход
- PowerPoint
- OpenDocument
- презентация
- Java
- Aspose.Slides
description: "Обзор обновлений публичного API и несовместимых изменений в Aspose.Slides for Java, позволяющий плавно мигрировать ваши решения для презентаций PowerPoint PPT, PPTX и ODP."
---
{{% alert color="info" %}} 

Эта страница перечисляет все [added](/slides/ru/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/) классы, методы, свойства и т.д., а также новые ограничения и другие [changes](/slides/ru/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/) введённые в API Aspose.Slides for Java 15.2.0.

{{% /alert %}} {{% alert color="info" %}} 

Известны проблемы с некоторыми графическими маркерами и объектами WordArt, которые будут исправлены в Aspose.Slides for Java 15.2.0.

{{% /alert %}} 
## **Изменения публичного API**
### **Методы addDataPointForDoughnutSeries были добавлены**
Были добавлены два перегруженных метода IChartDataPointCollection.addDataPointForDoughnutSeries() для добавления точек данных в серии типа Doughnut.
### **Класс com.aspose.slides.SmartArtShape теперь наследуется от класса com.aspose.slides.GeometryShape**
Класс com.aspose.slides.SmartArtShape теперь наследуется от класса com.aspose.slides.GeometryShape. ... Это изменение улучшает объектную модель Aspose.Slides и добавляет новые возможности классу SmartArtShape.
### **Методы IGradientStopCollection.add(...) и IGradientStopCollection.insert(...) были изменены**
Подпись IGradientStop add(float position, int presetColor) заменена на подпись IGradientStop addPresetColor(float position, int presetColor).

Подпись метода IGradientStopCollection IGradientStop add(float position, SchemeColor schemeColor) заменена на подпись IGradientStop addSchemeColor(float position, int schemeColor).

Подпись метода IGradientStopCollection void insert(int index, float position, int presetColor) заменена на подпись void insertPresetColor(int index, float position, int presetColor).

Подпись метода IGradientStopCollection void insert(int index, float position, SchemeColor schemeColor) заменена на подпись void insertSchemeColor(int index, float position, int schemeColor).
### **Метод java.awt.Color getAutomaticSeriesColor() был добавлен в com.aspose.slides.IChartSeries**
Метод getAutomaticSeriesColor() возвращает автоматический цвет серии на основе индекса серии и стиля диаграммы. Этот цвет используется по умолчанию, если FillType равно NotDefined.

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 50, 600, 400);

for (int i = 0; i < chart.getChartData().getSeries().size(); i++)

{

    chart.getChartData().getSeries().get_Item(i).getAutomaticSeriesColor();

}

```
### **Добавлен метод для удаления точки данных диаграммы и категории диаграммы по их индексу**
Метод IChartDataPointCollection.removeAt(int index) был добавлен для удаления точки данных диаграммы по её индексу.
Метод IChartCategoryCollection.removeAt(int index) был добавлен для удаления категории диаграммы по её индексу.
### **Значение PptXPptY было добавлено в перечисление com.aspose.slides.PropertyType**
Значение PptXPptY было добавлено в перечисление com.aspose.slides.PropertyType в рамках исправления проблемы сериализации.