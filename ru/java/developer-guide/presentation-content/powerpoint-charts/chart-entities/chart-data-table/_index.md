---
title: Таблица данных диаграммы
type: docs
url: /java/chart-data-table/
---

## **Настройка свойств шрифта для таблицы данных диаграммы**
Aspose.Slides для Java предоставляет возможность изменять цвет категорий в серии цветов.

1. Создайте объект класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. Добавьте диаграмму на слайд.
1. Установите таблицу диаграммы.
1. Установите высоту шрифта.
1. Сохраните изменённую презентацию.

Ниже приведён пример. 

```java
// Создание пустой презентации
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    chart.setDataTable(true);

    chart.getChartDataTable().getTextFormat().getPortionFormat().setFontBold(NullableBool.True);
    chart.getChartDataTable().getTextFormat().getPortionFormat().setFontHeight(20);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```