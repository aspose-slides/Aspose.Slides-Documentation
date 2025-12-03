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
Aspose.Slides for Java обеспечивает поддержку изменения цвета категорий в серии.

1. Создать объект класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. Добавить диаграмму на слайд.
1. Задать таблицу диаграммы.
1. Установить высоту шрифта.
1. Сохранить изменённую презентацию.

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


## **Часто задаваемые вопросы**

**Могу ли я отображать небольшие ключи легенды рядом со значениями в таблице данных диаграммы?**

Да. Таблица данных поддерживает [ключи легенды](https://reference.aspose.com/slides/java/com.aspose.slides/datatable/#setShowLegendKey-boolean-), и вы можете включать или отключать их.

**Сохраняется ли таблица данных при экспорте презентации в PDF, HTML или изображения?**

Да. Aspose.Slides рендерит диаграмму как часть слайда, поэтому экспортированный [PDF](/slides/ru/java/convert-powerpoint-to-pdf/)/[HTML](/slides/ru/java/convert-powerpoint-to-html/)/[image](/slides/ru/java/convert-powerpoint-to-png/) включает диаграмму с её таблицей данных.

**Поддерживаются ли таблицы данных для диаграмм, полученных из шаблонного файла?**

Да. Для любой диаграммы, загруженной из существующей презентации или шаблона, вы можете проверить и изменить, отображается ли [таблица данных](https://reference.aspose.com/slides/java/com.aspose.slides/chart/#hasDataTable--) с помощью свойств диаграммы.

**Как быстро определить, в каких диаграммах файла включена таблица данных?**

Проверьте свойство каждой диаграммы, указывающее, отображается ли [таблица данных](https://reference.aspose.com/slides/java/com.aspose.slides/chart/#hasDataTable--), и пройдитесь по слайдам, чтобы определить диаграммы, где она включена.