---
title: Публичный API и изменения, не совместимые с ранее выпущенными версиями в Aspose.Slides для Java 14.10.0
type: docs
weight: 90
url: /java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-10-0/
---

{{% alert color="primary" %}} 

Эта страница содержит список всех [добавленных](/slides/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-10-0/) классов, методов, свойств и так далее, любых новых ограничений и других [изменений](/slides/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-10-0/), введенных в API Aspose.Slides для Java 14.10.0.

{{% /alert %}} 
## **Изменения в публичном API**
### **Метод com.aspose.slides.FieldType.getFooter() был добавлен**
Метод getFooter() возвращает тип поля нижнего колонтитула. Он был добавлен для реализации возможности создания полей этого типа и для корректной сериализации презентации.
### **Элемент com.aspose.slides.ShapeElementFillSource.Own был удален**
Элемент ShapeElementFillSource.Own был удален как дублирующий. Используйте ShapeElementFillSource.Shape вместо ShapeElementFillSource.Own.
### **Добавлены методы для удаления точек данных диаграммы и категорий**
**Добавлены следующие методы, позволяющие удалить точку данных диаграммы из коллекции точек данных диаграммы:**

IChartDataPointCollection.remove(IChartDataPoint)  
IChartDataPoint.remove()

**Добавлен следующий метод, позволяющий удалить категорию диаграммы из содержащей коллекции:**

IChartCategory.remove()

``` java

 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 400, true);

chart.getChartData().getCategories().get_Item(0).remove(); // удалить с помощью ChartCategory.remove()

chart.getChartData().getCategories().remove(chart.getChartData().getCategories().get_Item(0)); // удалить с помощью ChartCategoryCollection.remove()

for (IChartSeries ser : chart.getChartData().getSeries())

{

    ser.getDataPoints().get_Item(0).remove(); // удалить с помощью ChartDataPoint.remove()

    ser.getDataPoints().remove(ser.getDataPoints().get_Item(0)); // ChartDataPointCollection.remove()

}

pres.save("presentation.pptx", SaveFormat.Pptx);

```
### **Устаревшие методы Aspose.Slides.ParagraphFormat были удалены**
Методы getBulletChar(), getBulletColor(), getBulletColorFormat(), getBulletFont(), getBulletHeight(), getBulletType(), isBulletHardColor(), isBulletHardFont(), getNumberedBulletStartWith(), getNumberedBulletStyle() и соответствующие методы set были удалены. Они были отмечены как устаревшие давно.
### **Удалены бесполезные и устаревшие конструктора**
Следующие конструкторы были удалены:

com.aspose.slides.AlphaBiLevel(float)  
com.aspose.slides.AlphaModulateFixed(float)  
com.aspose.slides.AlphaReplace(float)  
com.aspose.slides.BiLevel(float)  
com.aspose.slides.Blur(double, boolean)  
com.aspose.slides.HSL(float, float, float)  
com.aspose.slides.ImageTransformOperation(com.aspose.slides.ImageTransformOperationCollection)  
com.aspose.slides.Luminance(float, float)  
com.aspose.slides.Tint(float, float)  
com.aspose.slides.PortionFormat(com.aspose.slides.ParagraphFormat)  
com.aspose.slides.PortionFormat(com.aspose.slides.Portion)  
com.aspose.slides.PortionFormat(com.aspose.slides.PortionFormat)  