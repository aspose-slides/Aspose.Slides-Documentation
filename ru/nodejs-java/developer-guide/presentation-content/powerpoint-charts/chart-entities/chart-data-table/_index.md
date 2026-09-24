---
title: Настройка таблиц данных диаграмм в презентациях с использованием JavaScript
linktitle: Таблица данных
type: docs
url: /ru/nodejs-java/chart-data-table/
keywords:
- данные диаграммы
- таблица данных
- свойства шрифта
- PowerPoint
- презентация
- Node.js
- JavaScript
- Aspose.Slides
description: Настройте шрифты, границы и маркеры легенды таблицы данных диаграмм в презентациях PowerPoint с помощью Aspose.Slides для Node.js через Java.
---
## **Обзор**

Aspose.Slides for Node.js via Java позволяет отображать таблицу данных диаграммы и настраивать её форматирование текста, границы и маркеры легенды. В этой статье объясняется, как включить таблицу, отформатировать её текст, управлять каждым типом границы и показывать или скрывать маркеры легенды. Примеры сохраняют настроенные диаграммы в файлы PPTX.

## **Задать свойства шрифта**

Чтобы отобразить таблицу данных диаграммы, передайте `true` в [setDataTable](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/chart/setdatatable/). Используйте [getChartDataTable](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/chart/getchartdatatable/), чтобы получить доступ к таблице и настроить её форматирование текста.

1. Загрузите презентацию, используя класс [Presentation](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/).
2. Добавьте группированную столбчатую диаграмму на первый слайд.
3. Включите таблицу данных диаграммы.
4. Включите полужирный текст с помощью [setFontBold](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/baseportionformat/#setfontbold) и передайте `20` в [setFontHeight](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/baseportionformat/#setfontheight), чтобы задать размер шрифта 20 пунктов.
5. Сохраните изменённую презентацию.

Следующий пример требует файл `input.pptx` в рабочем каталоге, содержащий хотя бы один слайд. Он добавляет диаграмму с данными по умолчанию в позицию (50, 50) с шириной 600 пунктов и высотой 400 пунктов. Сохранённый `output.pptx` содержит диаграмму с включённой таблицей данных и применёнными указанными настройками шрифта.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);

    const portionFormat = chart.getChartDataTable().getTextFormat().getPortionFormat();
    portionFormat.setFontBold(java.newByte(aspose.slides.NullableBool.True));
    portionFormat.setFontHeight(20);

    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Настроить границы таблицы данных**

Включите таблицу с помощью [Chart.setDataTable](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/chart/setdatatable/) и получите к ней доступ через [Chart.getChartDataTable](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/chart/getchartdatatable/). Вы можете управлять тремя типами границ независимо:

- [setBorderHorizontal](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/datatable/setborderhorizontal/) управляет горизонтальными границами ячеек.
- [setBorderVertical](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/datatable/setbordervertical/) управляет вертикальными границами ячеек.
- [setBorderOutline](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/datatable/setborderoutline/) управляет внешней границей таблицы.

Передайте `true` каждому методу, чтобы отобразить соответствующие границы, или `false`, чтобы скрыть их. Следующий пример создаёт группированную столбчатую диаграмму с данными по умолчанию, отображает горизонтальные границы и внешнюю границу, а вертикальные границы скрывает. Входной файл не требуется. Позиция и размер диаграммы указаны в пунктах.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);

    const dataTable = chart.getChartDataTable();
    dataTable.setBorderHorizontal(true);
    dataTable.setBorderVertical(false);
    dataTable.setBorderOutline(true);

    presentation.save("data-table-borders.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Сравнение ниже использует одинаковые данные диаграммы и настройки маркеров легенды во всех четырёх случаях. Начиная с включёнными всеми границами, каждый последующий вариант отключает только одну настройку границы. Вариант в нижнем‑левом углу соответствует настройкам границ в примере.

![Таблицы данных диаграммы со всеми включенными границами, без горизонтальных границ, без вертикальных границ и без внешней границы](data-table-borders.png)

## **Показать или скрыть маркеры легенды**

Маркеры легенды — это небольшие цветные индикаторы рядом с названиями рядов в таблице данных. Они помогают читателям сопоставлять каждую строку таблицы с соответствующим рядом диаграммы. Передайте `true` в [setShowLegendKey](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/datatable/setshowlegendkey/), чтобы отобразить эти индикаторы, или `false`, чтобы скрыть их.

Отдельную легенду диаграммы контролирует [Chart.setLegend](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/chart/setlegend/). Эти настройки независимы: скрытие отдельной легенды не скрывает маркеры внутри таблицы данных, и скрытие маркеров таблицы не скрывает отдельную легенду.

Следующий пример создаёт диаграмму с данными по умолчанию, включает её таблицу данных и отображает маркеры легенды внутри неё, скрывая отдельную легенду. Все границы таблицы явно включены. Входная презентация не требуется. Чтобы скрыть только маркеры таблицы, передайте `false` в [setShowLegendKey](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/datatable/setshowlegendkey/).

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);
    chart.setLegend(false);

    const dataTable = chart.getChartDataTable();
    dataTable.setBorderHorizontal(true);
    dataTable.setBorderVertical(true);
    dataTable.setBorderOutline(true);
    dataTable.setShowLegendKey(true);

    presentation.save("data-table-legend-keys.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Сравнение ниже показывает одну и ту же таблицу с включёнными и отключёнными маркерами легенды. Все границы остаются включёнными, а отдельная легенда диаграммы скрыта в обоих случаях.

![Таблицы данных диаграммы с отображёнными маркерами легенды слева и скрытыми справа](data-table-legend-keys.png)

## **Вопросы и ответы**

**Могу ли я отобразить маркеры легенды в таблице данных диаграммы?**

Да. Передайте `true` в [setShowLegendKey](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/datatable/setshowlegendkey/), чтобы отобразить маркеры легенды, или `false`, чтобы скрыть их.

**Сохранится ли таблица данных при экспорте презентации в PDF, HTML или изображения?**

Да. Aspose.Slides рендерит диаграмму и её отображаемую таблицу данных как часть слайда при экспорте в [PDF](/slides/ru/nodejs-java/convert-powerpoint-to-pdf/), [HTML](/slides/ru/nodejs-java/convert-powerpoint-to-html/) или [изображения](/slides/ru/nodejs-java/convert-powerpoint-to-png/).

**Можно ли работать с таблицами данных в диаграммах, загруженных из шаблона?**

Да. Для диаграммы, загруженной из существующей презентации или шаблона, используйте [hasDataTable](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/chart/hasdatatable/) и [setDataTable](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/chart/setdatatable/) для проверки или изменения того, отображается ли её таблица данных.

**Как найти диаграммы, у которых включена таблица данных?**

Пройдите по всем фигурам на каждом слайде, определите диаграммы и вызовите их метод [hasDataTable](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/chart/hasdatatable/). Значение `true` указывает, что таблица данных включена.