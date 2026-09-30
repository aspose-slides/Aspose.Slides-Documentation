---
title: Управление строками и столбцами в таблицах PowerPoint с помощью PHP
linktitle: Строки и столбцы
type: docs
weight: 20
url: /ru/php-java/manage-rows-and-columns/
keywords:
- строка таблицы
- столбец таблицы
- первая строка
- заголовок таблицы
- клонировать строку
- клонировать столбец
- копировать строку
- копировать столбец
- удалить строку
- удалить столбец
- форматирование текста строки
- форматирование текста столбца
- стиль таблицы
- PowerPoint
- презентация
- PHP
- Aspose.Slides
description: "Управляйте строками и столбцами таблиц в PowerPoint с помощью Aspose.Slides for PHP via Java и ускоряйте редактирование презентаций и обновление данных."
---
## **Введение**

Aspose.Slides for PHP via Java позволяет управлять структурой таблицы и её форматированием в презентациях PowerPoint с помощью класса [Таблица](https://reference.aspose.com/slides/php-java/aspose.slides/table/). Вы можете назначить строку‑заголовок, клонировать или удалять строки и столбцы, а также применять форматирование текста ко всей строке или столбцу.

В этой статье объясняются эти операции с примерами на PHP. Также показано, как получить предустановку стиля таблицы, чтобы её можно было переиспользовать. Индексы строк и столбцов таблицы начинаются с нуля.

## **Управление высотой строки**

Используйте [Row::setMinimalHeight](https://reference.aspose.com/slides/php-java/aspose.slides/row/setminimalheight/) чтобы задать минимальную высоту строки в пунктах. Это нижняя граница, а не фиксированная высота. [Row::getHeight](https://reference.aspose.com/slides/php-java/aspose.slides/row/getheight/) возвращает фактическую высоту. Получите доступ к строке через [Table::getRows](https://reference.aspose.com/slides/php-java/aspose.slides/table/getrows/).

В примере загружается [row-height-input.pptx](row-height-input.pptx), в котором на первом слайде первая фигура — таблица. Первая строка начинается с 70 пунктов. Ячейки используют текст Arial размером 18 пунктов, перенос строк и отступы сверху и снизу по 6 пунктов; более длинный текст во втором столбце переносится на несколько строк. Пример увеличивает минимум до 100 пунктов, затем уменьшает его до 20 пунктов, выводит фактическую высоту после каждого изменения и сохраняет оба результата.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("row-height-input.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $table = $slide->getShapes()->get_Item(0);
    $row = $table->getRows()->get_Item(0);

    $row->setMinimalHeight(100);
    printf("Increased: minimum = %.1f, actual = %.1f pt\n", java_values($row->getMinimalHeight()), java_values($row->getHeight()));
    $presentation->save("row-height-increased.pptx", SaveFormat::Pptx);

    $row->setMinimalHeight(20);
    printf("Decreased: minimum = %.1f, actual = %.1f pt\n", java_values($row->getMinimalHeight()), java_values($row->getHeight()));
    $presentation->save("row-height-decreased.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

В поставленной презентации увеличение минимума добавляет пространство к строке. Уменьшение удаляет это дополнительное пространство, но фактическая высота остаётся больше 20 пунктов, потому что текст и отступы ячеек требуют больше места. Снижение только минимума не может заставить строку стать ниже пространства, необходимого её содержимому.

На фактическую высоту влияют несколько факторов:

- **Текст и размер шрифта:** более длинный текст, явные разрывы строк или больший шрифт могут требовать больше вертикального пространства.
- **Перенос и ширина столбца:** при включённом переносе уменьшение ширины столбца с помощью [Column::setWidth](https://reference.aspose.com/slides/php-java/aspose.slides/column/setwidth/) может привести к появлению большего количества строк. Более широкий столбец может уменьшить требуемое вертикальное пространство.
- **Отступы ячеек:** [Cell::setMarginTop](https://reference.aspose.com/slides/php-java/aspose.slides/cell/setmargintop/) и [Cell::setMarginBottom](https://reference.aspose.com/slides/php-java/aspose.slides/cell/setmarginbottom/) добавляют вертикальное пространство. [Cell::setMarginLeft](https://reference.aspose.com/slides/php-java/aspose.slides/cell/setmarginleft/) и [Cell::setMarginRight](https://reference.aspose.com/slides/php-java/aspose.slides/cell/setmarginright/) уменьшают доступную ширину для текста и могут вызвать дополнительный перенос.

Для этой таблицы без объединённых ячеек ячейка, требующая наибольшего вертикального пространства, определяет нижний предел для всей строки, основанный на содержимом. Чтобы сделать строку короче, возможно, придётся сократить текст, уменьшить размер шрифта или отступы, либо расширить столбец.

Ниже показаны изображения одной и той же таблицы в одинаковом масштабе. В показанных результатах фактические высоты составили 70, 100 и 55.2 пункта: последняя строка осталась выше своего минимума в 20 пунктов. Точные измерения текста могут различаться в зависимости от доступных в вашей среде шрифтов. Скачайте сохранённые результаты: [увеличенный минимум](row-height-increased.pptx) и [уменьшенный минимум](row-height-decreased.pptx).

| Оригинал: минимум 70 pt, фактическая 70 pt | Увеличено: минимум 100 pt, фактическая 100 pt | Уменьшено: минимум 20 pt, фактическая 55.2 pt |
| --- | --- | --- |
| ![Исходная таблица с первой строкой 70 пунктов.](row-height-before.png) | ![Таблица после увеличения минимума первой строки до 100 пунктов.](row-height-increased.png) | ![Таблица после уменьшения минимума первой строки до 20 пунктов; перенос текста сохраняет строку выше минимума.](row-height-decreased.png) |

## **Установить первую строку как заголовок**

Используйте метод [setFirstRow](https://reference.aspose.com/slides/php-java/aspose.slides/table/setfirstrow/) чтобы отметить первую строку для форматирования заголовка. Её внешний вид зависит от применённого к таблице стиля.

1. Загрузите презентацию с помощью класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Получите доступ к первому слайду.
3. Получите таблицу, сохранённую как первая фигура на слайде.
4. Включите форматирование заголовка для её первой строки.
5. Сохраните изменённую презентацию.

Для примера требуется `table.pptx` с таблицей в качестве первой фигуры на первом слайде. Он включает форматирование заголовка для первой строки и сохраняет `First_row_header.pptx`.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("table.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $table = $slide->getShapes()->get_Item(0);
    $table->setFirstRow(true);

    $presentation->save("First_row_header.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Клонировать строку или столбец таблицы**

Клонируйте строки или столбцы, чтобы повторно использовать их содержимое и форматирование. Вы можете добавить копию в конец таблицы или вставить её в определённую позицию.

1. Загрузите презентацию с помощью класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Получите доступ к первому слайду.
3. Задайте ширины столбцов и высоты строк.
4. Добавьте таблицу с помощью метода [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addtable/).
5. Клонируйте необходимые строки.
6. Клонируйте необходимые столбцы.
7. Сохраните изменённую презентацию.

Для примера требуется `Test.pptx` как минимум с одним слайдом. Он создаёт таблицу из трёх столбцов и пяти строк, размеры указаны в пунктах. Он добавляет копии первой строки и столбца, затем вставляет копии второй строки и столбца на индекс 3 (четвёртая позиция). Получившаяся таблица содержит семь строк и пять столбцов. Аргумент `false` отключает клонирование в смежные объединённые строки или столбцы; в этой таблице нет объединённых ячеек.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Test.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [50, 50, 50];
    $rowHeights = [50, 30, 30, 30, 30];
    $table = $slide->getShapes()->addTable(100, 50, $columnWidths, $rowHeights);

    $table->get_Item(0, 0)->getTextFrame()->setText("Row 1 Cell 1");
    $table->get_Item(1, 0)->getTextFrame()->setText("Row 1 Cell 2");
    $table->getRows()->addClone($table->getRows()->get_Item(0), false);

    $table->get_Item(0, 1)->getTextFrame()->setText("Row 2 Cell 1");
    $table->get_Item(1, 1)->getTextFrame()->setText("Row 2 Cell 2");
    $table->getRows()->insertClone(3, $table->getRows()->get_Item(1), false);

    $table->getColumns()->addClone($table->getColumns()->get_Item(0), false);
    $table->getColumns()->insertClone(3, $table->getColumns()->get_Item(1), false);

    $presentation->save("table_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Удалить строку или столбец из таблицы**

Удалите строки или столбцы, которые более не нужны в таблице. При удалении элемента индексы последующих строк или столбцов смещаются.

1. Создайте презентацию с помощью класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Получите доступ к первому слайду.
3. Задайте ширины столбцов и высоты строк.
4. Добавьте таблицу с помощью метода [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addtable/).
5. Удалите вторую строку и второй столбец.
6. Сохраните изменённую презентацию.

В этом примере создаётся таблица 3×3 и удаляются строка и столбец с индексом 1, оставляя таблицу 2×2 в `TestTable_out.pptx`. Размеры указаны в пунктах. Аргумент `false` отключает удаление смежных объединённых строк или столбцов; в этой таблице нет объединённых ячеек.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [100, 50, 30];
    $rowHeights = [30, 50, 30];
    $table = $slide->getShapes()->addTable(100, 100, $columnWidths, $rowHeights);

    $table->getRows()->removeAt(1, false);
    $table->getColumns()->removeAt(1, false);

    $presentation->save("TestTable_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Установить форматирование текста на уровне строк таблицы**

Применяйте форматирование текста ко всей строке, чтобы клетки оставались согласованными. Можно задавать свойства шрифта, форматирование абзаца и направление текста без необходимости форматировать каждую ячейку отдельно.

1. Загрузите презентацию с помощью класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Получите таблицу на первом слайде.
3. Используйте [setFontHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight) для первой строки.
4. Используйте [setAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setalignment/) и [setMarginRight](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setmarginright/) для первой строки.
5. Используйте [setTextVerticalType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/settextverticaltype/) для второй строки.
6. Сохраните изменённую презентацию.

Для примера требуется `table.pptx` с таблицей как первой фигурой на первом слайде и минимум двумя строками. Он применяет текст размером 25 пунктов, выравнивание по правому краю и правый отступ абзаца 20 пунктов к первой строке, затем задаёт вертикальный текст во второй строке.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\PortionFormat;
use aspose\slides\ParagraphFormat;
use aspose\slides\TextFrameFormat;
use aspose\slides\TextAlignment;
use aspose\slides\TextVerticalType;

$presentation = new Presentation("table.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $table = $slide->getShapes()->get_Item(0);

    $portionFormat = new PortionFormat();
    $portionFormat->setFontHeight(25);
    $table->getRows()->get_Item(0)->setTextFormat($portionFormat);

    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat->setAlignment(TextAlignment::Right);
    $paragraphFormat->setMarginRight(20);
    $table->getRows()->get_Item(0)->setTextFormat($paragraphFormat);

    $textFrameFormat = new TextFrameFormat();
    $textFrameFormat->setTextVerticalType(TextVerticalType::Vertical);
    $table->getRows()->get_Item(1)->setTextFormat($textFrameFormat);

    $presentation->save("row_formatting.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Установить форматирование текста на уровне столбцов таблицы**

Применяйте форматирование текста ко всему столбцу, чтобы клетки оставались согласованными. Можно задавать свойства шрифта, форматирование абзаца и направление текста без необходимости форматировать каждую ячейку отдельно.

1. Загрузите презентацию с помощью класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Получите таблицу на первом слайде.
3. Используйте [setFontHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight) для первого столбца.
4. Используйте [setAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setalignment/) и [setMarginRight](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setmarginright/) для первого столбца.
5. Используйте [setTextVerticalType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/settextverticaltype/) для второго столбца.
6. Сохраните изменённую презентацию.

Для примера требуется `table.pptx` с таблицей как первой фигурой на первом слайде и минимум двумя столбцами. Он применяет текст размером 25 пунктов, выравнивание по правому краю и правый отступ абзаца 20 пунктов к первому столбцу, затем задаёт вертикальный текст во втором столбце.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\PortionFormat;
use aspose\slides\ParagraphFormat;
use aspose\slides\TextFrameFormat;
use aspose\slides\TextAlignment;
use aspose\slides\TextVerticalType;

$presentation = new Presentation("table.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $table = $slide->getShapes()->get_Item(0);

    $portionFormat = new PortionFormat();
    $portionFormat->setFontHeight(25);
    $table->getColumns()->get_Item(0)->setTextFormat($portionFormat);

    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat->setAlignment(TextAlignment::Right);
    $paragraphFormat->setMarginRight(20);
    $table->getColumns()->get_Item(0)->setTextFormat($paragraphFormat);

    $textFrameFormat = new TextFrameFormat();
    $textFrameFormat->setTextVerticalType(TextVerticalType::Vertical);
    $table->getColumns()->get_Item(1)->setTextFormat($textFrameFormat);

    $presentation->save("column_formatting.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Получить свойства стиля таблицы**

Используйте метод [getStylePreset](https://reference.aspose.com/slides/php-java/aspose.slides/table/getstylepreset/) чтобы получить предустановку, применённую к таблице, и повторно использовать её в другой таблице. Это определяет предустановку, а не отдельные переопределения форматирования ячеек.

В примере создаётся таблица, применяется [TableStylePreset::DarkStyle1](https://reference.aspose.com/slides/php-java/aspose.slides/tablestylepreset/#DarkStyle1), после чего предустановка считывается обратно. Он выводит целочисленное значение, соответствующее `DarkStyle1`, и сохраняет таблицу в `table.pptx`.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TableStylePreset;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [100, 150];
    $rowHeights = [5, 5, 5];
    $table = $slide->getShapes()->addTable(10, 10, $columnWidths, $rowHeights);
    $table->setStylePreset(TableStylePreset::DarkStyle1);

    $stylePreset = $table->getStylePreset();
    echo java_values($stylePreset) . PHP_EOL;

    $presentation->save("table.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Можно ли применить темы/стили PowerPoint к уже созданной таблице?**

Да. Таблица наследует тему слайда/макета/шаблона, и вы всё равно можете переопределять заливки, границы и цвета текста поверх этой темы.

**Можно ли сортировать строки таблицы, как в Excel?**

Нет, таблицы Aspose.Slides не имеют встроенной сортировки или фильтров. Сначала отсортируйте данные в памяти, а затем заполните строки таблицы в этом порядке.

**Можно ли использовать чередующиеся (полосатые) столбцы, сохраняя пользовательские цвета в отдельных ячейках?**

Да. Включите чередование столбцов, затем переопределите отдельные ячейки локальным форматированием; форматирование на уровне ячейки имеет приоритет над стилем таблицы.