---
title: Применение формул листа диаграммы в презентациях на PHP
linktitle: Формулы листа
type: docs
weight: 70
url: /ru/php-java/chart-worksheet-formulas/
keywords:
- диаграмма таблица
- лист диаграммы
- формула диаграммы
- формула листа
- формула таблицы
- рабочая книга данных диаграммы
- вычисление формулы
- предпочтительная культура
- формула, завсящая от культуры
- DBCS
- логическая константа
- числовая константа
- строковая константа
- константа ошибки
- арифметический оператор
- оператор сравнения
- стиль A1
- стиль R1C1
- предопределённая функция
- PowerPoint
- презентация
- PHP
- Aspose.Slides
description: "Применяйте формулы в стиле Excel в Aspose.Slides для PHP через Java листы диаграмм, пересчитывайте значения и используйте результаты в диаграммах PowerPoint."
---
## **Обзор**

Диаграммы PowerPoint обычно хранят исходные данные во вложенном листе. В Aspose.Slides для PHP через Java вы можете получить доступ к этому листу через рабочую книгу данных диаграммы, записать входные значения, назначить формулы ячейкам, вычислить поддерживаемые формулы и использовать вычисленные ячейки в качестве данных диаграммы.

В этой статье объясняется полный рабочий процесс формул: создание диаграммы, заполнение её листа, назначение формул в стиле A1 или R1C1, их перерасчёт, чтение вычисленных значений, привязка этих ячеек к серии диаграммы и сохранение презентации. Также описывается поддерживаемый синтаксис формул, набор встроенных функций, кэшированные значения, неподдерживаемые формулы и ошибки, характерные для таблиц.

## **Листы диаграмм и формулы**

Лист диаграммы содержит категории, имена серий и значения, используемые диаграммой. В PowerPoint вы можете просмотреть лист, открыв редактор данных диаграммы:

![Диаграмма PowerPoint с открытым вложенным листом, показывающая данные категорий и серий](chart-worksheet-formulas_1.png)

В Aspose.Slides лист доступен через класс [ChartDataWorkbook](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartdataworkbook/). Используйте [ChartDataCell::setFormula](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartdatacell/#setFormula) для формул в стиле A1 и [ChartDataCell::setR1C1Formula](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartdatacell/#setR1C1Formula) для формул в стиле R1C1. После изменения входных ячеек или формул вызовите [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartdataworkbook/#calculateFormulas), чтобы перерасчитать поддерживаемые формулы и обновить соответствующие значения ячеек.

Вычисленная ячейка всё ещё предоставляет свой результат через [ChartDataCell::getValue](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartdatacell/#getValue). Это важно, когда нужно проверить результат формулы в коде или использовать ячейку как точку данных диаграммы.

## **Создание диаграммы и вычисление формул листа**

Ниже приведён пример полного рабочего процесса. Он создаёт сгруппированную столбчатую диаграмму, очищает примерные данные, записывает квартальные значения доходов и расходов, вычисляет прибыль с помощью формул, читает результаты, использует вычисленные ячейки в качестве значений диаграммы и сохраняет презентацию.

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 350);
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $worksheetIndex = 0;

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    $workbook->clear($worksheetIndex);

    $category1 = $workbook->getCell($worksheetIndex, "A2", "Q1");
    $category2 = $workbook->getCell($worksheetIndex, "A3", "Q2");
    $category3 = $workbook->getCell($worksheetIndex, "A4", "Q3");

    $workbook->getCell($worksheetIndex, "B1", "Revenue");
    $workbook->getCell($worksheetIndex, "C1", "Expenses");
    $workbook->getCell($worksheetIndex, "D1", "Profit");

    $workbook->getCell($worksheetIndex, "B2")->setValue(120.0);
    $workbook->getCell($worksheetIndex, "C2")->setValue(80.0);
    $workbook->getCell($worksheetIndex, "B3")->setValue(150.0);
    $workbook->getCell($worksheetIndex, "C3")->setValue(95.0);
    $workbook->getCell($worksheetIndex, "B4")->setValue(135.0);
    $workbook->getCell($worksheetIndex, "C4")->setValue(110.0);

    $profit1 = $workbook->getCell($worksheetIndex, "D2");
    $profit2 = $workbook->getCell($worksheetIndex, "D3");
    $profit3 = $workbook->getCell($worksheetIndex, "D4");

    $profit1->setFormula("B2-C2");
    $profit2->setFormula("B3-C3");
    $profit3->setFormula("B4-C4");

    $workbook->calculateFormulas();

    $q1Profit = java_values($profit1->getValue()); // 40
    $q2Profit = java_values($profit2->getValue()); // 55
    $q3Profit = java_values($profit3->getValue()); // 25

    echo "Q1 profit: " . $q1Profit . PHP_EOL;
    echo "Q2 profit: " . $q2Profit . PHP_EOL;
    echo "Q3 profit: " . $q3Profit . PHP_EOL;

    $chart->getChartData()->getCategories()->add($category1);
    $chart->getChartData()->getCategories()->add($category2);
    $chart->getChartData()->getCategories()->add($category3);

    $profitSeries = $chart->getChartData()->getSeries()->add($workbook->getCell($worksheetIndex, "D1"), $chart->getType());
    $profitSeries->getDataPoints()->addDataPointForBarSeries($profit1);
    $profitSeries->getDataPoints()->addDataPointForBarSeries($profit2);
    $profitSeries->getDataPoints()->addDataPointForBarSeries($profit3);
    $profitSeries->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);

    $presentation->save("chart-formulas.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Точки данных диаграммы ссылаются на `D2:D4`, поэтому диаграмма использует вычисленные значения прибыли. В этом рабочем процессе нет отдельного вызова обновления диаграммы: сначала перерасчитывается рабочая книга, затем используется или сохраняется диаграмма, ссылающаяся на вычисленные ячейки.

## **Использование формул в стиле A1**

Нотация A1 обозначает столбцы буквами, а строки — цифрами. Присваивайте выражения в стиле A1 через [ChartDataCell::setFormula](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartdatacell/#setFormula).

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 300);
    $workbook = $chart->getChartData()->getChartDataWorkbook();

    $workbook->getCell(0, "C3")->setValue(10);
    $workbook->getCell(0, "F2")->setValue(2);
    $workbook->getCell(0, "G2")->setValue(3);
    $workbook->getCell(0, "H2")->setValue(4);

    $cell = $workbook->getCell(0, "A2");
    $cell->setFormula("C3+SUM(F2:H2)");

    $workbook->calculateFormulas();

    $value = java_values($cell->getValue()); // 19
} finally {
    $presentation->dispose();
}
```

Распространённые формы ссылок A1:

| Ссылка | Относительная | Абсолютная | Смешанная |
|---|---|---|---|
| Ячейка | `A2` | `$A$2` | `A$2`, `$A2` |
| Строка | `2:2` | `$2:$2` | — |
| Столбец | `A:A` | `$A:$A` | — |
| Диапазон | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

Относительные ссылки могут изменяться при перемещении или копировании формулы в таблице. Абсолютные ссылки фиксируют обе координаты, а смешанные фиксируют только строку или только столбец.

## **Использование формул в стиле R1C1**

Нотация R1C1 обозначает строки и столбцы численно. Относительные ссылки используют смещения в квадратных скобках. Присваивайте эту нотацию через [ChartDataCell::setR1C1Formula](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartdatacell/#setR1C1Formula).

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 300);
    $workbook = $chart->getChartData()->getChartDataWorkbook();

    $workbook->getCell(0, "B2")->setValue(12);
    $workbook->getCell(0, "C2")->setValue(5);

    $cell = $workbook->getCell(0, "D2");
    $cell->setR1C1Formula("RC[-2]-RC[-1]");

    $workbook->calculateFormulas();

    $value = java_values($cell->getValue()); // 7
} finally {
    $presentation->dispose();
}
```

Распространённые формы ссылок R1C1:

| Ссылка | Относительная | Абсолютная | Смешанная |
|---|---|---|---|
| Ячейка | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| Строка | `R[2]` | `R2` | — |
| Столбец | `C[3]` | `C3` | — |
| Диапазон | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

Например, в ячейке `D2` запись `RC[-2]` означает ячейку в той же строке, на два столбца влево (`B2`).

## **Константы формул и операторы**

Встроенный оценщик формул поддерживает логические значения, числовые литералы, строки, значения ошибок таблицы, арифметические операторы и операторы сравнения.

### **Константы и литералы**

| Тип | Примеры | Примечания |
|---|---|---|
| Логический | `TRUE`, `FALSE` | Можно использовать напрямую в логических выражениях, например `A2=TRUE`. |
| Числовой | `1`, `0.5`, `.3`, `1E-2` | Поддерживаются обычная и научная запись. |
| Строка | `"abc"`, `"2/3/2020 12:00"` | Текстовые литералы заключаются в двойные кавычки внутри формулы. |
| Результат ошибки | `#DIV/0!`, `#N/A`, `#REF!` | Валидная формула может дать значение ошибки таблицы вместо обычного результата. |

В этом примере используются несколько типов констант:

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 300);
    $workbook = $chart->getChartData()->getChartDataWorkbook();

    $workbook->getCell(0, "A2")->setValue(false);
    $workbook->getCell(0, "B2")->setFormula("A2=TRUE");
    $workbook->getCell(0, "C2")->setFormula("1+0.5");
    $workbook->getCell(0, "D2")->setFormula(".3*1E-2");
    $workbook->getCell(0, "E2")->setFormula("\"abc\"");
    $workbook->getCell(0, "F2")->setFormula("2/0");

    $workbook->calculateFormulas();

    $logicalValue = java_values($workbook->getCell(0, "B2")->getValue()); // false
    $numericValue = java_values($workbook->getCell(0, "C2")->getValue()); // 1.5
    $scientificValue = java_values($workbook->getCell(0, "D2")->getValue()); // 0.003
    $stringValue = java_values($workbook->getCell(0, "E2")->getValue()); // abc
    $errorValue = java_values($workbook->getCell(0, "F2")->getValue()); // #DIV/0!
} finally {
    $presentation->dispose();
}
```

### **Арифметические операторы**

| Оператор | Значение | Пример |
|---|---|---|
| `+` | Сложение или унарный плюс | `2+3` |
| `-` | Вычитание или отрицание | `2-3`, `-3` |
| `*` | Умножение | `2*3` |
| `/` | Деление | `2/3` |
| `%` | Процент | `30%` |
| `^` | Возведение в степень | `2^3` |

Используйте скобки, чтобы явно задать порядок вычисления, например `(A2+B2)*C2`.

### **Операторы сравнения**

Операции сравнения возвращают логические значения.

| Оператор | Значение | Пример |
|---|---|---|
| `=` | Равно | `A2=3` |
| `<>` | Не равно | `A2<>3` |
| `>` | Больше | `A2>3` |
| `>=` | Больше или равно | `A2>=3` |
| `<` | Меньше | `A2<3` |
| `<=` | Меньше или равно | `A2<=3` |

## **Поддерживаемые предопределённые функции**

Aspose.Slides включает встроенный оценщик формул для листов диаграмм, но это не полноценный движок расчётов Excel. Документированный набор функций ограничен таблицей ниже. Не предполагаете, что произвольная функция Excel может быть пересчитана методом [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartdataworkbook/#calculateFormulas).

| Функция | Назначение или поддерживаемая форма | Пример |
|---|---|---|
| `ABS` | Абсолютное значение | `ABS(A2)` |
| `AVERAGE` | Среднее арифметическое | `AVERAGE(B2:B5)` |
| `CEILING` | Округление числа вверх до кратного | `CEILING(A2,5)` |
| `CHOOSE` | Выбор значения по индексу | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | Объединение текстовых значений | `CONCAT(A2,B2)` |
| `CONCATENATE` | Объединение текстовых значений | `CONCATENATE(A2," ",B2)` |
| `DATE` | Создание даты в системе 1900‑го года | `DATE(2026,8,19)` |
| `DAYS` | Количество дней между датами | `DAYS(B2,A2)` |
| `FIND` | Поиск текста внутри другого текста | `FIND("-",A2)` |
| `FINDB` | Поиск текста по байтам | `FINDB("a",A2)` |
| `IF` | Условный результат | `IF(A2>0,A2,0)` |
| `INDEX` | Ссылка в форме таблицы | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | Векторная форма | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | Векторная форма | `MATCH(A2,B2:B5,0)` |
| `MAX` | Максимальное значение | `MAX(B2:B5)` |
| `SUM` | Сумма значений | `SUM(B2:B5)` |
| `VLOOKUP` | Вертикальный поиск | `VLOOKUP(A2,B2:D10,3,FALSE)` |

Ограничения, показанные в таблице, важны: `INDEX` документирован в форме ссылки, а `LOOKUP` и `MATCH` — в их векторных формах. `DATE` использует систему дат 1900 года. Функции, не перечисленные здесь, следует считать неподдерживаемыми встроенным оценщиком Aspose.Slides, если они не документированы отдельно.

## **Вычисление формул с предпочтительной культурой**

Некоторые функции рабочей книги используют культурно‑зависимые правила обработки текста. Это особенно важно для функций, предназначенных для языков с двойными байтовыми наборами символов (DBCS). Чтобы правильно вычислять такие формулы, создайте [LoadOptions](https://reference.aspose.com/slides/ru/php-java/aspose.slides/loadoptions/), установите предпочтительную культуру через [SpreadsheetOptions::setPreferredCulture](https://reference.aspose.com/slides/ru/php-java/aspose.slides/spreadsheetoptions/#setPreferredCulture), передайте параметры таблицы через [LoadOptions::setSpreadsheetOptions](https://reference.aspose.com/slides/ru/php-java/aspose.slides/loadoptions/#setSpreadsheetOptions) и затем загрузите презентацию.

В следующем примере выбирается японская культура, открывается презентация с указанными параметрами загрузки и вызывается [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) для каждой рабочей книги диаграммы:

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\SpreadsheetOptions;

$japaneseCulture = new Java("java.util.Locale", "ja", "JP");

$spreadsheetOptions = new SpreadsheetOptions();
$spreadsheetOptions->setPreferredCulture($japaneseCulture);

$loadOptions = new LoadOptions();
$loadOptions->setSpreadsheetOptions($spreadsheetOptions);

$chartClass = new JavaClass("com.aspose.slides.IChart");
$presentation = new Presentation("presentation.pptx", $loadOptions);
try {
    $slideCount = java_values($presentation->getSlides()->size());
    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $shapeCount = java_values($slide->getShapes()->size());
        for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            if (java_instanceof($shape, $chartClass)) {
                $shape->getChartData()->getChartDataWorkbook()->calculateFormulas();
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

Предпочтительная культура является частью конфигурации загрузки презентации, поэтому её следует задать до создания экземпляра [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/). Используйте культуру, ожидаемую формулами рабочей книги; например, `ja-JP` для формул, которые должны следовать японским правилам расчётов DBCS.

## **Перерасчёт и кэшированные значения**

Файлы таблиц обычно хранят как формулу, так и её последнее вычисленное значение. Aspose.Slides может читать кэшированное значение из [ChartDataCell::getValue](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartdatacell/#getValue), когда презентация загружена и соответствующие данные диаграммы не изменялись.

После изменения входных ячеек или формул не полагайтесь на старый кэшированный результат. Вызовите [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) перед чтением вычисленных значений или сохранением данных диаграммы, от которых они зависят.

Для формул, не входящих в поддерживаемый набор, Aspose.Slides может не суметь разобрать формулу или определить её зависимости. Если рабочая книга была изменена, предыдущее кэшированное значение уже нельзя считать надёжным. В такой ситуации чтение значения ячейки с неподдерживаемыми данными может вызвать [CellUnsupportedDataException](https://reference.aspose.com/slides/ru/php-java/aspose.slides/cellunsupporteddataexception/).

Если ваша диаграмма использует функции Excel, которые Aspose.Slides не вычисляет, вычислите эти формулы в другом движке таблиц и запишите полученные значения обратно в рабочую книгу диаграммы. Не заменяйте неподдерживаемые формулы «угаданными» значениями.

## **Обработка ошибок формул**

Существует два разных типа проблем.

Формула может быть корректной, но возвращать ошибку таблицы, например `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!` или `#VALUE!`. В этом случае токен ошибки является результатом ячейки и может быть возвращён через [ChartDataCell::getValue](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartdatacell/#getValue).

Формула может также потерпеть неудачу на этапе разбора, ссылки, зависимостей или из‑за неподдерживаемых данных. Aspose.Slides предоставляет специфические для таблиц исключения: [CellInvalidFormulaException](https://reference.aspose.com/slides/ru/php-java/aspose.slides/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/ru/php-java/aspose.slides/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/ru/php-java/aspose.slides/cellcircularreferenceexception/), и [CellUnsupportedDataException](https://reference.aspose.com/slides/ru/php-java/aspose.slides/cellunsupporteddataexception/).

В PHP через Java исключения Java отображаются через `JavaException`. Когда формулы поступают из шаблонов или ввода пользователя, обрабатывайте их вокруг перерасчёта и доступа к значениям. Исключение Java, указанное в стеке вызовов, определяет конкретный сбой таблицы:

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 300);
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $cell = $workbook->getCell(0, "A2");
    $cell->setFormula("SUM(B2:B5)");

    try {
        $workbook->calculateFormulas();
        echo java_values($cell->getValue()) . PHP_EOL;
    } catch (JavaException $ex) {
        $ex->printStackTrace();
    }
} finally {
    $presentation->dispose();
}
```

## **Практические ограничения**

Поддержка формул в листах диаграмм предназначена только для определённого подмножества расчётов таблиц, а не для полной совместимости с Excel. Учтите эти ограничения при проектировании рабочего процесса отчётности:

- Используйте только документированные константы, операторы, ссылки и функции, если требуется, чтобы Aspose.Slides пересчитывал формулы.
- Перерасчитывайте после изменения ячеек, от которых зависят результаты формул.
- Рассматривайте кэшированные значения из загруженных презентаций как снимки, а не как замену перерасчёту после правок.
- Тестируйте формулы из существующих шаблонов перед тем, как полагаться на их вычисленные значения, особенно если они используют функции, не входящие в список.
- Для формул, требующих полного движка расчётов таблиц, выполняйте вычисления внешне, а затем обновляйте рабочую книгу диаграммы полученными значениями.

## **FAQ**

**В чём разница между [ChartDataCell::setFormula](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartdatacell/#setFormula) и [ChartDataCell::setR1C1Formula](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartdatacell/#setR1C1Formula)?**

[ChartDataCell::setFormula](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartdatacell/#setFormula) сохраняет выражение в стиле A1, например `B2-C2`. [ChartDataCell::setR1C1Formula](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartdatacell/#setR1C1Formula) сохраняет выражение в стиле R1C1, например `RC[-2]-RC[-1]`. Используйте нотацию, которая лучше соответствует вашему способу генерации или копирования формул.

**Нужно ли читать саму ячейку или её значение после вычисления?**

[ChartDataWorkbook::getCell](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartdataworkbook/#getCell) возвращает объект [ChartDataCell](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartdatacell/). Чтобы получить вычисленный результат, вызовите у этой ячейки метод [ChartDataCell::getValue](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartdatacell/#getValue) после перерасчёта.

**Когда следует вызывать [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartdataworkbook/#calculateFormulas)?**

Вызывайте [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) после изменения входных значений или формул и перед тем, как использовать вычисленные результаты. Это обновит значения формул, поддерживаемых встроенным оценщиком.

**Поддерживает ли Aspose.Slides каждую функцию Excel?**

Нет. Встроенный оценщик поддерживает только документированный подмножество функций. Функции, не входящие в этот набор, не следует считать вычисляемыми корректно. Если требуется полная совместимость с формулами Excel, выполните расчёт в соответствующем движке таблиц и запишите окончательные значения в рабочую книгу диаграммы.

**Что происходит, если загруженная презентация содержит неподдерживаемую формулу?**

Если данные диаграммы не менялись, в рабочей книге может оставаться ранее вычисленное кэшированное значение. После изменения связанных данных это кэшированное значение может стать недействительным. Попытка доступа к ячейке с формулой, которую нельзя обработать, может вызвать [CellUnsupportedDataException](https://reference.aspose.com/slides/ru/php-java/aspose.slides/cellunsupporteddataexception/).

**Являются ли значения ошибок формул тем же, что и исключения PHP?**

Нет. Значение вроде `#DIV/0!` — это значение таблицы, полученное в результате корректного вычисления. Ошибки обработки таблиц, такие как [CellInvalidFormulaException](https://reference.aspose.com/slides/ru/php-java/aspose.slides/cellinvalidformulaexception/) или [CellCircularReferenceException](https://reference.aspose.com/slides/ru/php-java/aspose.slides/cellcircularreferenceexception/), являются исключениями Java, которые в PHP отображаются через `JavaException`.

**Обновляется ли диаграмма автоматически при изменении ячейки формулы?**

Серии диаграммы могут ссылаться на ячейки рабочей книги. Сначала перерасчитайте рабочую книгу, затем сохраните или отрендерите презентацию. Если точки данных диаграммы ссылаются на вычисленные ячейки, диаграмма использует обновлённые значения; отдельный метод обновления диаграммы не нужен.

**Могут ли диаграммы использовать внешний файл Excel?**

Да, данные диаграммы можно настроить на использование внешней рабочей книги через API данных диаграммы. Однако описанный в этой статье рабочий процесс расчёта формул относится к рабочей книге данных диаграммы и подмножеству формул, оцениваемому Aspose.Slides. Не предполагаете, что [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) полностью пересчитает произвольные формулы во внешнем файле XLSX.

**Можно ли использовать формулы, ссылающиеся на другой лист или рабочую книгу?**

Ссылки в стиле Excel могут присутствовать в рабочих книгах диаграмм, но их оценка ограничена поддерживаемым парсером и набором функций. Если критична кросс‑листовая или внешняя ссылка, проверьте точность такой формулы с вашей версией Aspose.Slides. Для рабочих процессов, требующих широкой совместимости ссылок Excel, расчитайте рабочую книгу внешне и запишите полученные значения обратно в данные диаграммы.

**Должны ли строки формул начинаться с `=`?**

Примеры API Aspose.Slides присваивают выражения без ведущего `=`, например `B2-C2` или `SUM(B2:B5)`. Такой способ сохраняет согласованность с документированными примерами API.