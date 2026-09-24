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
description: "Настройте шрифты, границы и ключи легенды таблицы данных диаграмм в презентациях PowerPoint с помощью Aspose.Slides for Android via Java."
---
## **Обзор**

Aspose.Slides for Android via Java позволяет отображать таблицу данных диаграммы и настраивать форматирование текста, границы и ключи легенды. В этой статье объясняется, как включить таблицу, отформатировать её текст, управлять каждым типом границы и показывать или скрывать ключи легенды. Примеры сохраняют настроенные диаграммы в файлы PPTX.

## **Установить свойства шрифта**

Чтобы отобразить таблицу данных диаграммы, передайте `true` методу [setDataTable](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/chart/#setDataTable-boolean-). Используйте [getChartDataTable](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/chart/#getChartDataTable--) для доступа к таблице и настройки её форматирования текста.

1. Загрузите презентацию, используя класс [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/).
1. Добавьте сгруппированную столбчатую диаграмму на первый слайд.
1. Включите таблицу данных диаграммы.
1. Включите полужирный текст с помощью [setFontBold](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/baseportionformat/#setFontBold-byte-) и передайте `20` в [setFontHeight](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-) для текста размером 20 пунктов.
1. Сохраните изменённую презентацию.

Следующий пример требует наличие файла `test.pptx` в текущем каталоге с хотя бы одним слайдом. Он добавляет диаграмму с данными по умолчанию в позицию (50, 50) с шириной 600 пунктов и высотой 400 пунктов. Сохранённый `output.pptx` содержит диаграмму с включённой таблицей данных и применёнными указанными настройками шрифта.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("test.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);

    IChartPortionFormat portionFormat = chart.getChartDataTable().getTextFormat().getPortionFormat();
    portionFormat.setFontBold(NullableBool.True);
    portionFormat.setFontHeight(20);

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Настроить границы таблицы данных**

Включите таблицу с помощью [IChart.setDataTable](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ichart/#setDataTable-boolean-) и получите к ней доступ через [IChart.getChartDataTable](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ichart/#getChartDataTable--). Вы можете независимо управлять тремя типами границ:

- [setBorderHorizontal](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/idatatable/#setBorderHorizontal-boolean-) управляет горизонтальными границами ячеек.
- [setBorderVertical](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/idatatable/#setBorderVertical-boolean-) управляет вертикальными границами ячеек.
- [setBorderOutline](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/idatatable/#setBorderOutline-boolean-) управляет внешней границей таблицы.

Передайте `true` каждому методу, чтобы отобразить соответствующие границы, либо `false`, чтобы скрыть их. Следующий пример создаёт сгруппированную столбчатую диаграмму с данными по умолчанию, отображает горизонтальные границы и внешнюю границу, скрывая вертикальные границы. Входной файл не требуется. Позиция и размеры диаграммы задаются в пунктах.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);

    IDataTable dataTable = chart.getChartDataTable();
    dataTable.setBorderHorizontal(true);
    dataTable.setBorderVertical(false);
    dataTable.setBorderOutline(true);

    presentation.save("data-table-borders.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Сравнение ниже использует одни и те же данные диаграммы и настройки ключей легенды во всех четырёх случаях. Начиная с включёнными всеми границами, каждый последующий вариант отключает только одну из границ. Вариант в нижнем левом углу соответствует настройкам границ в примере.

![Таблицы данных диаграмм со всеми включёнными границами, без горизонтальных границ, без вертикальных границ и без внешней границы](data-table-borders.png)

## **Показать или скрыть ключи легенды**

Ключи легенды — это небольшие цветные маркеры рядом с названиями рядов в таблице данных. Они помогают читателю сопоставить каждую строку таблицы с рядом диаграммы. Передайте `true` методу [setShowLegendKey](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/idatatable/#setShowLegendKey-boolean-), чтобы показать эти маркеры, либо `false`, чтобы скрыть их.

Отдельная легенда диаграммы управляется методом [IChart.setLegend](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ichart/#setLegend-boolean-). Эти настройки независимы: скрытие отдельной легенды не скрывает ключи в таблице данных, и скрытие ключей в таблице не скрывает отдельную легенду.

Следующий пример создаёт диаграмму с данными по умолчанию, включает её таблицу данных и показывает ключи легенды внутри неё, одновременно скрывая отдельную легенду. Все границы таблицы явно включены. Входная презентация не требуется. Чтобы скрыть только ключи таблицы, передайте `false` методу [setShowLegendKey](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/idatatable/#setShowLegendKey-boolean-).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);
    chart.setLegend(false);

    IDataTable dataTable = chart.getChartDataTable();
    dataTable.setBorderHorizontal(true);
    dataTable.setBorderVertical(true);
    dataTable.setBorderOutline(true);
    dataTable.setShowLegendKey(true);

    presentation.save("data-table-legend-keys.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Сравнение ниже демонстрирует одну и ту же таблицу с включёнными и отключёнными ключами легенды. Все границы остаются включёнными, а отдельная легенда диаграммы скрыта в обоих случаях.

![Таблицы данных диаграмм с отображёнными слева ключами легенды и скрытыми справа](data-table-legend-keys.png)

## **Часто задаваемые вопросы**

**Могу ли я показывать ключи легенды в таблице данных диаграммы?**  
Да. Передайте `true` в [setShowLegendKey](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/datatable/#setShowLegendKey-boolean-), чтобы отобразить ключи легенды, или `false`, чтобы скрыть их.

**Сохранится ли таблица данных при экспорте презентации в PDF, HTML или изображения?**  
Да. Aspose.Slides рендерит диаграмму и её отображаемую таблицу данных как часть слайда при экспорте в [PDF](/slides/ru/androidjava/convert-powerpoint-to-pdf/), [HTML](/slides/ru/androidjava/convert-powerpoint-to-html/), или [images](/slides/ru/androidjava/convert-powerpoint-to-png/).

**Могу ли я работать с таблицами данных в диаграммах, загруженных из шаблона?**  
Да. Для диаграммы, загруженной из существующей презентации или шаблона, используйте [hasDataTable](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/chart/#hasDataTable--) и [setDataTable](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/chart/#setDataTable-boolean-), чтобы проверить или изменить, отображается ли её таблица данных.

**Как найти диаграммы с включённой таблицей данных?**  
Пройдитесь по всем фигурам на каждом слайде, определите диаграммы и вызовите их метод [hasDataTable](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/chart/#hasDataTable--). Значение `true` указывает, что таблица данных включена.