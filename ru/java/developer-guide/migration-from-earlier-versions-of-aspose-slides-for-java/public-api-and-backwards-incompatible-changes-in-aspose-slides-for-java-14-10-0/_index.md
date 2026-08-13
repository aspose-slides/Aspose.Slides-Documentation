---
title: Публичный API и несовместимые изменения в Aspose.Slides для Java 14.10.0
linktitle: Aspose.Slides для Java 14.10.0
type: docs
weight: 90
url: /ru/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-10-0/
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
description: "Обзор обновлений публичного API и разрушающих изменений в Aspose.Slides for Java для плавной миграции ваших решений по работе с презентациями PowerPoint PPT, PPTX и ODP."
---
{{% alert color="info" %}} 
Эта страница перечисляет все [добавленные](/slides/ru/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-10-0/) классы, методы, свойства и т.д., любые новые ограничения и другие [изменения](/slides/ru/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-10-0/) , введённые в API Aspose.Slides for Java 14.10.0. 
{{% /alert %}} 
## **Изменения публичного API**
### **Метод com.aspose.slides.FieldType.getFooter() добавлен**
Метод getFooter() возвращает тип поля нижнего колонтитула. Он добавлен для реализации возможности создания полей этого типа и для корректной сериализации презентаций.
### **Элемент com.aspose.slides.ShapeElementFillSource.Own удалён**
Элемент ShapeElementFillSource.Own удалён как дублирующий. Используйте ShapeElementFillSource.Shape вместо ShapeElementFillSource.Own.
### **Добавлены методы для удаления точек данных и категорий диаграммы**
**Добавлены следующие методы, позволяющие удалять точку данных диаграммы из коллекции точек данных:**

IChartDataPointCollection.remove(IChartDataPoint)  
IChartDataPoint.remove()  

**Добавлен метод, позволяющий удалять категорию диаграммы из содержащей её коллекции:**

IChartCategory.remove()  

``` java
import com.aspose.slides.*;


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
### **Устаревшие методы Aspose.Slides.ParagraphFormat удалены**
Методы getBulletChar(), getBulletColor(), getBulletColorFormat(), getBulletFont(), getBulletHeight(), getBulletType(), isBulletHardColor(), isBulletHardFont(), getNumberedBulletStartWith(), getNumberedBulletStyle() и соответствующие методы set удалены. Они были помечены как устаревшие давно.
### **Неиспользуемые и устаревшие конструкторы удалены**
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