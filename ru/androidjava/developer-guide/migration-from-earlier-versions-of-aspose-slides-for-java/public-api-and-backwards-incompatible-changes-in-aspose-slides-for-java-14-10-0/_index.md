---
title: Публичный API и несовместимые изменения в Aspose.Slides для Java 14.10.0
type: docs
weight: 90
url: /androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-10-0/
---

{{% alert color="primary" %}} 

На этой странице перечислены все [добавленные](/slides/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-10-0/) классы, методы, свойства и так далее, любые новые ограничения и другие [изменения](/slides/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-10-0/), введенные в API Aspose.Slides для Java 14.10.0.

{{% /alert %}} 
## **Изменения в публичном API**
### **Метод com.aspose.slides.FieldType.getFooter() был добавлен**
Метод getFooter() возвращает тип поля подвала. Он был добавлен для реализации возможности создания полей этого типа и для корректной сериализации презентаций.
### **Элемент com.aspose.slides.ShapeElementFillSource.Own был удалён**
Элемент ShapeElementFillSource.Own был удалён как дублирующий. Используйте ShapeElementFillSource.Shape вместо ShapeElementFillSource.Own.
### **Добавлены методы для удаления точек данных графика и категорий**
**Добавлены следующие методы, которые позволяют удалять точку данных графика из коллекции точек данных графика:**

IChartDataPointCollection.remove(IChartDataPoint)
IChartDataPoint.remove()

**Добавлен следующий метод, который позволяет удалять категорию графика из содержащей коллекции:**

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
Методы getBulletChar(), getBulletColor(), getBulletColorFormat(), getBulletFont(), getBulletHeight(), getBulletType(), isBulletHardColor(), isBulletHardFont(), getNumberedBulletStartWith(), getNumberedBulletStyle() и соответствующие методы установки были удалены. Они были помечены как устаревшие давно.
### **Удалены ненужные и устаревшие конструкторы**
Удалены следующие конструкторы:

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
