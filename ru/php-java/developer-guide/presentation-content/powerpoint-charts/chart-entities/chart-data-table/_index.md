---
title: Настройка таблиц данных диаграмм в презентациях с использованием PHP
linktitle: Таблица данных
type: docs
url: /ru/php-java/chart-data-table/
keywords:
- данные диаграммы
- таблица данных
- свойства шрифта
- PowerPoint
- презентация
- PHP
- Aspose.Slides
description: "Настройте шрифты, границы и ключи легенды таблицы данных диаграммы в презентациях PowerPoint с помощью Aspose.Slides for PHP via Java."
---
## **Обзор**

Aspose.Slides for PHP via Java позволяет отображать таблицу данных диаграммы и настраивать её форматирование текста, границы и ключи легенды. В этой статье объясняется, как включить таблицу, отформатировать её текст, управлять каждым типом границы и показывать или скрывать ключи легенды. Примеры сохраняют настроенные диаграммы в файлы PPTX.

## **Установка свойств шрифта**

Чтобы отобразить таблицу данных диаграммы, передайте `true` в [setDataTable](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chart/setdatatable/). Используйте [getChartDataTable](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chart/getchartdatatable/) для доступа к таблице и настройки её форматирования текста.

1. Загрузите презентацию, используя класс [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/).
1. Добавьте сгруппированную столбчатую диаграмму на первый слайд.
1. Включите таблицу данных диаграммы.
1. Включите полужирный текст с помощью [setFontBold](https://reference.aspose.com/slides/ru/php-java/aspose.slides/baseportionformat/#setFontBold) и передайте `20` в [setFontHeight](https://reference.aspose.com/slides/ru/php-java/aspose.slides/baseportionformat/#setFontHeight) для текста размером 20 пунктов.
1. Сохраните изменённую презентацию.

Следующий пример требует файл `test.pptx` в рабочем каталоге, содержащий хотя бы один слайд. Он добавляет диаграмму с данными по умолчанию в позицию (50, 50) шириной 600 пунктов и высотой 400 пунктов. Сохранённый `output.pptx` содержит диаграмму с включённой таблицей данных и применёнными настройками шрифта.

```php
use aspose\slides\ChartType;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("test.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $chart->setDataTable(true);

    $portionFormat = $chart->getChartDataTable()->getTextFormat()->getPortionFormat();
    $portionFormat->setFontBold(NullableBool::True);
    $portionFormat->setFontHeight(20);

    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Настройка границ таблицы данных**

Включите таблицу с помощью [Chart::setDataTable](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chart/setdatatable/) и получите её через [Chart::getChartDataTable](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chart/getchartdatatable/). Вы можете независимо управлять тремя типами границ:

- [setBorderHorizontal](https://reference.aspose.com/slides/ru/php-java/aspose.slides/datatable/setborderhorizontal/) контролирует горизонтальные границы ячеек.
- [setBorderVertical](https://reference.aspose.com/slides/ru/php-java/aspose.slides/datatable/setbordervertical/) контролирует вертикальные границы ячеек.
- [setBorderOutline](https://reference.aspose.com/slides/ru/php-java/aspose.slides/datatable/setborderoutline/) контролирует внешнюю границу таблицы.

Передайте `true` каждому методу, чтобы отобразить его границы, или `false` — чтобы скрыть их. Следующий пример создаёт сгруппированную столбчатую диаграмму с данными по умолчанию, отображает горизонтальные границы и внешнюю границу, скрывая вертикальные границы. Входной файл не требуется. Позиция и размер диаграммы задаются в пунктах.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $chart->setDataTable(true);

    $dataTable = $chart->getChartDataTable();
    $dataTable->setBorderHorizontal(true);
    $dataTable->setBorderVertical(false);
    $dataTable->setBorderOutline(true);

    $presentation->save("data-table-borders.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Сравнение ниже использует одинаковые данные диаграммы и настройку ключей легенды во всех четырёх случаях. Начиная со всеми включёнными границами, каждый последующий вариант отключает только одну настройку границы. Вариант в левом нижнем углу соответствует настройкам границ из примера.

![Таблицы данных диаграмм с включёнными всеми границами, без горизонтальных границ, без вертикальных границ и без внешней границы](data-table-borders.png)

## **Показ и скрытие ключей легенды**

Ключи легенды — это небольшие цветные маркеры рядом с названиями рядов в таблице данных. Они помогают читателям сопоставлять каждую строку таблицы с рядом диаграммы. Передайте `true` в [setShowLegendKey](https://reference.aspose.com/slides/ru/php-java/aspose.slides/datatable/setshowlegendkey/) чтобы показать эти маркеры, или `false` — чтобы скрыть их.

Отдельная легенда диаграммы управляется методом [Chart::setLegend](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chart/setlegend/). Эти настройки независимы: скрытие отдельной легенды не скрывает ключи внутри таблицы данных, и скрытие ключей таблицы не скрывает отдельную легенду.

Следующий пример создаёт диаграмму с данными по умолчанию, включает её таблицу данных и показывает ключи легенды внутри неё, одновременно скрывая отдельную легенду. Все границы таблицы явно включены. Входная презентация не требуется. Чтобы скрыть только ключи таблицы, передайте `false` в [setShowLegendKey](https://reference.aspose.com/slides/ru/php-java/aspose.slides/datatable/setshowlegendkey/).

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $chart->setDataTable(true);
    $chart->setLegend(false);

    $dataTable = $chart->getChartDataTable();
    $dataTable->setBorderHorizontal(true);
    $dataTable->setBorderVertical(true);
    $dataTable->setBorderOutline(true);
    $dataTable->setShowLegendKey(true);

    $presentation->save("data-table-legend-keys.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Сравнение ниже показывает одну и ту же таблицу с включёнными и отключёнными ключами легенды. Все границы остаются включёнными, а отдельная легенда диаграммы скрыта в обоих случаях.

![Таблицы данных диаграмм с показанными ключами легенды слева и скрытыми справа](data-table-legend-keys.png)

## **FAQ**

**Могу ли я показать ключи легенды в таблице данных диаграммы?**

Да. Передайте `true` в [setShowLegendKey](https://reference.aspose.com/slides/ru/php-java/aspose.slides/datatable/setshowlegendkey/) чтобы отобразить ключи легенды или `false` — чтобы скрыть их.

**Сохранится ли таблица данных при экспорте презентации в PDF, HTML или изображения?**

Да. Aspose.Slides рендерит диаграмму и её отображённую таблицу данных как часть слайда при экспорте в [PDF](/slides/ru/php-java/convert-powerpoint-to-pdf/), [HTML](/slides/ru/php-java/convert-powerpoint-to-html/), или [images](/slides/ru/php-java/convert-powerpoint-to-png/).

**Могу ли я работать с таблицами данных в диаграммах, загруженными из шаблона?**

Да. Для диаграммы, загруженной из существующей презентации или шаблона, используйте [hasDataTable](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chart/hasdatatable/) и [setDataTable](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chart/setdatatable/) для проверки или изменения того, отображается ли её таблица данных.

**Как найти диаграммы, у которых включена таблица данных?**

Итерируйте формы на каждом слайде, определяйте диаграммы и вызывайте их метод [hasDataTable](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chart/hasdatatable/). Значение `true` указывает, что таблица данных включена.