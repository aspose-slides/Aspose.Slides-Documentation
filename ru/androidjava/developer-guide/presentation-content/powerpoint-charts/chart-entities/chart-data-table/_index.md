---
title: Настройка таблиц данных диаграмм в презентациях на Android
linktitle: Таблица данных
type: docs
url: /ru/androidjava/chart-data-table/
keywords:
- данные диаграммы
- таблица данных
- свойства шрифта
- PowerPoint
- презентация
- Android
- Java
- Aspose.Slides
description: "Настройте таблицы данных диаграмм в Java для PPT и PPTX с Aspose.Slides для Android, чтобы повысить эффективность и привлекательность презентаций."
---

## **Установка свойств шрифта для таблицы данных диаграммы**
Aspose.Slides for Android via Java предоставляет возможность изменять цвет категорий в серии.

1. Создайте объект класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
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

**Могу ли я показывать небольшие ключи легенды рядом со значениями в таблице данных диаграммы?**

Да. Таблица данных поддерживает [ключи легенды](https://reference.aspose.com/slides/androidjava/com.aspose.slides/datatable/#setShowLegendKey-boolean-), и их можно включать и отключать.

**Будет ли таблица данных сохранена при экспортировании презентации в PDF, HTML или изображения?**

Да. Aspose.Slides отображает диаграмму как часть слайда, поэтому экспортированный [PDF](/slides/ru/androidjava/convert-powerpoint-to-pdf/)/[HTML](/slides/ru/androidjava/convert-powerpoint-to-html/)/[image](/slides/ru/androidjava/convert-powerpoint-to-png/) включает диаграмму с её таблицей данных.

**Поддерживаются ли таблицы данных для диаграмм, полученных из файла шаблона?**

Да. Для любой диаграммы, загруженной из существующей презентации или шаблона, вы можете проверить и изменить, отображается ли таблица данных, используя свойства диаграммы: [отображается](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chart/#hasDataTable--).

**Как быстро найти, какие диаграммы в файле имеют включённую таблицу данных?**

Проверьте свойство каждой диаграммы, указывающее, отображается ли таблица данных [отображается](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chart/#hasDataTable--), и пройдите по слайдам, чтобы определить диаграммы, у которых она включена.