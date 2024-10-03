---
title: Публичный API и изменения, несовместимые с предыдущими версиями в Aspose.Slides для PHP через Java 14.10.0
type: docs
weight: 90
url: /ru/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-10-0/
---

{{% alert color="primary" %}} 

Эта страница содержит все [добавленные](/slides/ru/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-10-0/) классы, методы, свойства и так далее, а также любые новые ограничения и другие [изменения](/slides/ru/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-10-0/), введенные с API Aspose.Slides для PHP через Java 14.10.0.

{{% /alert %}} 
## **Изменения публичного API**
### **Метод com.aspose.slides.FieldType::getFooter() был добавлен**
Метод getFooter() возвращает тип поля нижнего колонтитула. Он был добавлен для реализации возможности создания полей этого типа и для корректной сериализации презентаций.
### **Элемент com.aspose.slides.ShapeElementFillSource.Own был удален**
Элемент ShapeElementFillSource.Own был удален как дублирующийся. Используйте ShapeElementFillSource.Shape вместо ShapeElementFillSource.Own.
### **Методы удаления точек данных графика и категорий были добавлены**
**Были добавлены следующие методы, позволяющие удалить точку данных графика из коллекции точек данных графика:**

IChartDataPointCollection.remove(IChartDataPoint)
IChartDataPoint.remove()

**Был добавлен следующий метод, позволяющий удалить категорию графика из содержащей коллекции:**

IChartCategory.remove()

```php
  $pres = new Presentation();
  $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 450, 400, true);
  $chart->getChartData()->getCategories()->get_Item(0)->remove(); // удалить с помощью ChartCategory.remove()

  $chart->getChartData()->getCategories()->remove($chart->getChartData()->getCategories()->get_Item(0)); // удалить с помощью ChartCategoryCollection.remove()

  foreach($chart->getChartData()->getSeries() as $ser) {
    $ser->getDataPoints()->get_Item(0)->remove(); // удалить с помощью ChartDataPoint.remove()

    $ser->getDataPoints()->remove($ser->getDataPoints()->get_Item(0)); // ChartDataPointCollection.remove()

  }
  $pres->save("presentation.pptx", SaveFormat::Pptx);
```
### **Устаревшие методы Aspose.Slides.ParagraphFormat были удалены**
Методы getBulletChar(), getBulletColor(), getBulletColorFormat(), getBulletFont(), getBulletHeight(), getBulletType(), isBulletHardColor(), isBulletHardFont(), getNumberedBulletStartWith(), getNumberedBulletStyle() и соответствующие методы set были удалены. Они были помечены как устаревшие давно.
### **Бесполезные и устаревшие конструкторы были удалены**
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