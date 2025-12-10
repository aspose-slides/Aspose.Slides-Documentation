---
title: Настройка таблиц данных диаграмм в презентациях с использованием Java
linktitle: Таблица данных
type: docs
url: /ru/java/chart-data-table/
keywords:
- данные диаграммы
- таблица данных
- свойства шрифта
- PowerPoint
- презентация
- Java
- Aspose.Slides
description: "Настройте таблицы данных диаграмм в Java для PPT и PPTX с помощью Aspose.Slides, чтобы повысить эффективность и привлекательность презентаций."
---

## **Установить свойства шрифта для таблицы данных диаграммы**
Aspose.Slides for Java предоставляет поддержку изменения цвета категорий в серии.

1. Создайте объект класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
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


## **FAQ**

**Могу ли я отображать небольшие ключи легенды рядом со значениями в таблице данных диаграммы?**

Да. Таблица данных поддерживает [legend keys](https://reference.aspose.com/slides/java/com.aspose.slides/datatable/#setShowLegendKey-boolean-), и вы можете включать или отключать их.

**Будет ли таблица данных сохранена при экспорте презентации в PDF, HTML или изображения?**

Да. Aspose.Slides рендерит диаграмму как часть слайда, поэтому экспортированный [PDF](/slides/ru/java/convert-powerpoint-to-pdf/)/[HTML](/slides/ru/java/convert-powerpoint-to-html/)/[image](/slides/ru/java/convert-powerpoint-to-png/) содержит диаграмму с её таблицей данных.

**Поддерживаются ли таблицы данных для диаграмм, полученных из файла шаблона?**

Да. Для любой диаграммы, загруженной из существующей презентации или шаблона, вы можете проверить и изменить, отображается ли таблица данных, используя свойства диаграммы, через [отображается](https://reference.aspose.com/slides/java/com.aspose.slides/chart/#hasDataTable--).

**Как быстро определить, какие диаграммы в файле имеют включённую таблицу данных?**

Проверьте свойство каждой диаграммы, которое указывает, отображается ли таблица данных [отображается](https://reference.aspose.com/slides/java/com.aspose.slides/chart/#hasDataTable--), и пройдитесь по слайдам, чтобы определить, какие диаграммы имеют её включённой.