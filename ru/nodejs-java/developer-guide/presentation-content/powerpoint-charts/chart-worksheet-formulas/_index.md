---
title: Применение формул листа диаграммы в презентациях с использованием JavaScript
linktitle: Формулы листа
type: docs
weight: 70
url: /ru/nodejs-java/chart-worksheet-formulas/
keywords:
- таблица диаграммы
- лист диаграммы
- формула диаграммы
- формула листа
- формула таблицы
- рабочая книга данных диаграммы
- вычисление формулы
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Применяйте формулы в стиле Excel в листах диаграмм Aspose.Slides для Node.js via Java, пересчитывайте значения и используйте результаты в диаграммах PowerPoint."
---
## **Обзор**

Диаграммы PowerPoint обычно хранят исходные данные во встроенном листе. В Aspose.Slides for Node.js via Java можно получить доступ к этому листу через workbook данных диаграммы, записать входные значения, присвоить ячейкам формулы, вычислить поддерживаемые формулы и использовать вычисленные ячейки в качестве данных диаграммы.

В этой статье описывается полный рабочий процесс с формулами: создание диаграммы, заполнение её листа, присвоение формул в стиле A1 или R1C1, их перерасчёт, чтение вычисленных значений, привязка этих ячеек к серии диаграммы и сохранение презентации. Также рассматриваются поддерживаемый синтаксис формул, набор встроенных функций, кэшированные значения, неподдерживаемые формулы и ошибки, специфичные для электронных таблиц.

## **Листы диаграмм и формулы**

Лист диаграммы содержит категории, имена рядов и значения, используемые диаграммой. В PowerPoint можно просмотреть лист, открыв редактор данных диаграммы:

![PowerPoint chart with its embedded worksheet open, showing category and series data](chart-worksheet-formulas_1.png)

В Aspose.Slides лист доступен через класс [ChartDataWorkbook](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/chartdataworkbook/). Используйте [ChartDataCell.setFormula](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/chartdatacell/#setFormula-java.lang.String-) для формул в стиле A1 и [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/chartdatacell/#setR1C1Formula-java.lang.String-) для формул в стиле R1C1. После изменения входных ячеек или формул вызывайте [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--) для перерасчёта поддерживаемых формул и обновления соответствующих значений ячеек.

Вычисленная ячейка по‑прежнему предоставляет результат через [ChartDataCell.getValue](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/chartdatacell/#getValue--). Это важно, когда нужно проверить результат формулы в коде или использовать ячейку как точку данных диаграммы.

## **Создание диаграммы и вычисление формул листа**

Ниже приведён пример полного рабочего процесса. Он создаёт сгруппированную столбчатую диаграмму, очищает образцы данных, записывает квартальные доходы и расходы, вычисляет прибыль с помощью формул, читает результаты, использует вычисленные ячейки как значения диаграммы и сохраняет презентацию.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 350);
    const workbook = chart.getChartData().getChartDataWorkbook();
    const worksheetIndex = 0;

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    workbook.clear(worksheetIndex);

    const category1 = workbook.getCell(worksheetIndex, "A2", "Q1");
    const category2 = workbook.getCell(worksheetIndex, "A3", "Q2");
    const category3 = workbook.getCell(worksheetIndex, "A4", "Q3");

    workbook.getCell(worksheetIndex, "B1", "Revenue");
    workbook.getCell(worksheetIndex, "C1", "Expenses");
    workbook.getCell(worksheetIndex, "D1", "Profit");

    workbook.getCell(worksheetIndex, "B2").setValue(120.0);
    workbook.getCell(worksheetIndex, "C2").setValue(80.0);
    workbook.getCell(worksheetIndex, "B3").setValue(150.0);
    workbook.getCell(worksheetIndex, "C3").setValue(95.0);
    workbook.getCell(worksheetIndex, "B4").setValue(135.0);
    workbook.getCell(worksheetIndex, "C4").setValue(110.0);

    const profit1 = workbook.getCell(worksheetIndex, "D2");
    const profit2 = workbook.getCell(worksheetIndex, "D3");
    const profit3 = workbook.getCell(worksheetIndex, "D4");

    profit1.setFormula("B2-C2");
    profit2.setFormula("B3-C3");
    profit3.setFormula("B4-C4");

    workbook.calculateFormulas();

    const q1Profit = profit1.getValue(); // 40
    const q2Profit = profit2.getValue(); // 55
    const q3Profit = profit3.getValue(); // 25

    console.log("Q1 profit: " + q1Profit);
    console.log("Q2 profit: " + q2Profit);
    console.log("Q3 profit: " + q3Profit);

    chart.getChartData().getCategories().add(category1);
    chart.getChartData().getCategories().add(category2);
    chart.getChartData().getCategories().add(category3);

    const profitSeries = chart.getChartData().getSeries().add(workbook.getCell(worksheetIndex, "D1"), chart.getType());
    profitSeries.getDataPoints().addDataPointForBarSeries(profit1);
    profitSeries.getDataPoints().addDataPointForBarSeries(profit2);
    profitSeries.getDataPoints().addDataPointForBarSeries(profit3);
    profitSeries.getLabels().getDefaultDataLabelFormat().setShowValue(true);

    presentation.save("chart-formulas.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Точки данных диаграммы ссылаются на `D2:D4`, поэтому диаграмма использует вычисленные значения прибыли. В этом процессе нет отдельного вызова обновления диаграммы: сначала перерасчитайте workbook, затем используйте или сохраните данные диаграммы, указывающие на вычисленные ячейки.

## **Использование формул в стиле A1**

Нотация A1 обозначает столбцы буквами, а строки числами. Присваивайте выражения в стиле A1 через [ChartDataCell.setFormula](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/chartdatacell/#setFormula-java.lang.String-).

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 500, 300);
    const workbook = chart.getChartData().getChartDataWorkbook();

    workbook.getCell(0, "C3").setValue(10);
    workbook.getCell(0, "F2").setValue(2);
    workbook.getCell(0, "G2").setValue(3);
    workbook.getCell(0, "H2").setValue(4);

    const cell = workbook.getCell(0, "A2");
    cell.setFormula("C3+SUM(F2:H2)");

    workbook.calculateFormulas();

    const value = cell.getValue(); // 19
} finally {
    presentation.dispose();
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

Нотация R1C1 обозначает как строки, так и столбцы численно. Относительные ссылки используют смещения в квадратных скобках. Присваивайте эту форму через [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/chartdatacell/#setR1C1Formula-java.lang.String-).

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 500, 300);
    const workbook = chart.getChartData().getChartDataWorkbook();

    workbook.getCell(0, "B2").setValue(12);
    workbook.getCell(0, "C2").setValue(5);

    const cell = workbook.getCell(0, "D2");
    cell.setR1C1Formula("RC[-2]-RC[-1]");

    workbook.calculateFormulas();

    const value = cell.getValue(); // 7
} finally {
    presentation.dispose();
}
```

Распространённые формы ссылок R1C1:

| Ссылка | Относительная | Абсолютная | Смешанная |
|---|---|---|---|
| Ячейка | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| Строка | `R[2]` | `R2` | — |
| Столбец | `C[3]` | `C3` | — |
| Диапазон | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

Например, в ячейке `D2` запись `RC[-2]` означает ячейку в той же строке на два столбца влево (`B2`).

## **Константы и операторы формул**

Встроенный оценщик формул поддерживает логические значения, числовые литералы, строки, ошибки электронных таблиц, арифметические и сравнительные операторы.

### **Константы и литералы**

| Тип | Примеры | Примечания |
|---|---|---|
| Логический | `TRUE`, `FALSE` | Можно использовать напрямую в логических выражениях, например `A2=TRUE`. |
| Числовой | `1`, `0.5`, `.3`, `1E-2` | Поддерживаются обычная и научная запись. |
| Строка | `"abc"`, `"2/3/2020 12:00"` | Текстовые литералы заключаются в двойные кавычки внутри формулы. |
| Ошибка | `#DIV/0!`, `#N/A`, `#REF!` | Корректная формула может вернуть значение ошибки вместо обычного результата. |

Этот пример использует несколько типов констант:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 500, 300);
    const workbook = chart.getChartData().getChartDataWorkbook();

    workbook.getCell(0, "A2").setValue(false);
    workbook.getCell(0, "B2").setFormula("A2=TRUE");
    workbook.getCell(0, "C2").setFormula("1+0.5");
    workbook.getCell(0, "D2").setFormula(".3*1E-2");
    workbook.getCell(0, "E2").setFormula("\"abc\"");
    workbook.getCell(0, "F2").setFormula("2/0");

    workbook.calculateFormulas();

    const logicalValue = workbook.getCell(0, "B2").getValue(); // ложь
    const numericValue = workbook.getCell(0, "C2").getValue(); // 1.5
    const scientificValue = workbook.getCell(0, "D2").getValue(); // 0.003
    const stringValue = workbook.getCell(0, "E2").getValue(); // abc
    const errorValue = workbook.getCell(0, "F2").getValue(); // #DIV/0!
} finally {
    presentation.dispose();
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

Выражения сравнения возвращают логические значения.

| Оператор | Значение | Пример |
|---|---|---|
| `=` | Равно | `A2=3` |
| `<>` | Не равно | `A2<>3` |
| `>` | Больше | `A2>3` |
| `>=` | Больше или равно | `A2>=3` |
| `<` | Меньше | `A2<3` |
| `<=` | Меньше или равно | `A2<=3` |

## **Поддерживаемые предопределённые функции**

Aspose.Slides включает встроенный оценщик формул для листов диаграмм, но это не полноценный движок расчётов Excel. Документированный набор функций ограничен нижеуказанными. Не следует предполагать, что произвольная функция Excel может быть перерасчитана методом [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--).

| Функция | Назначение или поддерживаемая форма | Пример |
|---|---|---|
| `ABS` | Абсолютное значение | `ABS(A2)` |
| `AVERAGE` | Арифметическое среднее | `AVERAGE(B2:B5)` |
| `CEILING` | Округление числа вверх до кратного | `CEILING(A2,5)` |
| `CHOOSE` | Выбор значения по индексу | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | Объединение текстовых значений | `CONCAT(A2,B2)` |
| `CONCATENATE` | Объединение текстовых значений | `CONCATENATE(A2," ",B2)` |
| `DATE` | Создание даты по системе 1900‑го года | `DATE(2026,8,19)` |
| `DAYS` | Количество дней между датами | `DAYS(B2,A2)` |
| `FIND` | Поиск текста внутри текста | `FIND("-",A2)` |
| `FINDB` | Поиск с учётом байтов | `FINDB("a",A2)` |
| `IF` | Условный результат | `IF(A2>0,A2,0)` |
| `INDEX` | Ссылка в виде формы | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | Векторная форма | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | Векторная форма | `MATCH(A2,B2:B5,0)` |
| `MAX` | Максимальное значение | `MAX(B2:B5)` |
| `SUM` | Суммирование | `SUM(B2:B5)` |
| `VLOOKUP` | Вертикальный поиск | `VLOOKUP(A2,B2:D10,3,FALSE)` |

Ограничения, указанные в таблице, важны: `INDEX` документирован в виде ссылки, а `LOOKUP` и `MATCH` — в их векторных формах. `DATE` использует систему 1900‑го года. Функции, не перечисленные здесь, следует считать неподдерживаемыми встроенным оценщиком Aspose.Slides, если они не документированы отдельно.

## **Перерасчёт и кэшированные значения**

Файлы электронных таблиц обычно хранят формулу и её последнее вычисленное значение. Поэтому Aspose.Slides может прочитать кэшированное значение через [ChartDataCell.getValue](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/chartdatacell/#getValue--) при загрузке презентации, если соответствующие данные диаграммы не изменялись.

После изменения входных ячеек или формул не полагайтесь на старый кэшированный результат. Вызовите [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--) перед чтением вычисленных значений или сохранением данных диаграммы, зависящих от них.

Для формул, выходящих за пределы поддерживаемого набора, Aspose.Slides может не суметь разобрать формулу или определить её зависимости. Если workbook был изменён, предыдущее кэшированное значение уже нельзя считать надёжным. В такой ситуации попытка чтения значения ячейки с неподдерживаемыми данными может вызвать [CellUnsupportedDataException](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/cellunsupporteddataexception/).

Если ваша диаграмма зависит от функций Excel, которые Aspose.Slides не вычисляет, выполните расчёт этих формул с помощью движка, поддерживающего их, и запишите полученные значения обратно в workbook диаграммы. Не заменяйте неподдерживаемые формулы «угаданными» значениями.

## **Обработка ошибок формул**

Существует два разных типа проблем.

Формула может быть корректной, но вернуть ошибку таблицы, например `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!` или `#VALUE!`. В этом случае токен ошибки является результатом ячейки и может быть возвращён через [ChartDataCell.getValue](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/chartdatacell/#getValue--).

Формула также может не пройти разбор, проверку ссылок, зависимостей или поддерживаемых данных. Aspose.Slides предоставляет специальные исключения: [CellInvalidFormulaException](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/cellcircularreferenceexception/) и [CellUnsupportedDataException](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/cellunsupporteddataexception/).

Когда формулы берутся из шаблонов или пользовательского ввода, отлавливайте ошибки при перерасчёте и доступе к значениям. Подробности ошибки указывают на конкретную проблему таблицы:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 500, 300);
    const workbook = chart.getChartData().getChartDataWorkbook();
    const cell = workbook.getCell(0, "A2");
    cell.setFormula("SUM(B2:B5)");

    try {
        workbook.calculateFormulas();
        console.log(cell.getValue());
    } catch (error) {
        console.error("Formula processing error: " + error.message);
    }
} finally {
    presentation.dispose();
}
```

## **Практические ограничения**

Поддержка формул в листах диаграмм предназначена для ограниченного набора расчётов, а не для полной совместимости с Excel. Учтите эти ограничения при проектировании рабочего процесса отчётности:

- Используйте только документированные константы, операторы, ссылки и функции, если требуется перерасчёт формул Aspose.Slides.
- Перерасчитайте после изменения ячеек, от которых зависят результаты формул.
- Рассматривайте кэшированные значения из загруженных презентаций как моментальные снимки, а не как замену перерасчёту после правок.
- Тестируйте формулы из существующих шаблонов перед тем, как полагаться на их вычисленные значения, особенно если они используют функции, не входящие в документированный список.
- Для формул, требующих полного движка расчётов, выполните их внешне и затем обновите workbook диаграммы полученными значениями.

## **FAQ**

**В чём разница между [ChartDataCell.setFormula](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/chartdatacell/#setFormula-java.lang.String-) и [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/chartdatacell/#setR1C1Formula-java.lang.String-)?**

[ChartDataCell.setFormula](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/chartdatacell/#setFormula-java.lang.String-) сохраняет выражение в стиле A1, например `B2-C2`. [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/chartdatacell/#setR1C1Formula-java.lang.String-) сохраняет выражение в стиле R1C1, например `RC[-2]-RC[-1]`. Используйте нотацию, которая лучше соответствует способу генерации или копирования формул.

**Нужно ли читать саму ячейку или её значение после расчёта?**

[ChartDataWorkbook.getCell](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/chartdataworkbook/#getCell-int-java.lang.String-) возвращает объект [ChartDataCell](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/chartdatacell/). Чтобы получить вычисленный результат, вызовите метод этой ячейки [ChartDataCell.getValue](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/chartdatacell/#getValue--) после перерасчёта.

**Когда следует вызывать [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--)?**

Вызывайте [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--) после изменения входных значений или формул и перед тем, как использовать вычисленные результаты. Это обновит значения формул, поддерживаемых встроенным оценщиком.

**Поддерживает ли Aspose.Slides все функции Excel?**

Нет. Встроенный оценщик поддерживает только документированный подмножество функций. Функции, не входящие в этот набор, нельзя считать корректно перерасчитываемыми. Если требуется полная совместимость с формулами Excel, выполните расчёт внешним движком и запишите окончательные значения в workbook диаграммы.

**Что происходит, если загруженная презентация содержит неподдерживаемую формулу?**

Если данные диаграммы не изменялись, в workbook может оставаться ранее вычисленное кэшированное значение. После изменения связанных данных этот кэш может стать недействительным. Доступ к ячейке, формула которой не может быть обработана, может вызвать [CellUnsupportedDataException](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/cellunsupporteddataexception/).

**Являются ли значения ошибок формул тем же, что и исключения?**

Нет. Значение вроде `#DIV/0!` — это значение таблицы, полученное в результате корректного расчёта. Исключения, такие как [CellInvalidFormulaException](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/cellinvalidformulaexception/) или [CellCircularReferenceException](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/cellcircularreferenceexception/), указывают на то, что формула не может быть обработана обычным способом.

**Обновляется ли диаграмма автоматически при изменении ячейки с формулой?**

Серия диаграммы может ссылаться на ячейки workbook. Сначала перерасчитайте workbook, затем сохраните или отрендерите презентацию. Если точки данных диаграммы ссылаются на вычисленные ячейки, диаграмма использует обновлённые значения; отдельный метод обновления диаграммы не требуется.

**Можно ли использовать внешнюю книгу Excel для диаграмм?**

Да, данные диаграммы можно настроить для использования внешней книги через API данных диаграммы. Однако описанный в статье рабочий процесс расчёта формул относится к workbook данных диаграммы и поддерживаемому подмножеству формул Aspose.Slides. Не следует полагать, что [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--) обеспечивает полное перерасчёт произвольных формул во внешнем файле XLSX.

**Могу ли я использовать формулы, ссылающиеся на другой лист или книгу?**

Ссылки в стиле Excel могут присутствовать в workbook диаграмм, но оценка формул ограничена поддерживаемым парсером и набором функций. Если требуется кросс‑листовая или внешняя ссылка, проверьте точность такой формулы с выбранной версией Aspose.Slides. Для рабочих процессов, требующих широкой совместимости ссылок Excel, выполните расчёт workbook внешне и запишите полученные значения обратно в данные диаграммы.

**Должны ли строки формул начинаться с `=`?**

Примеры API Aspose.Slides передают выражения такие как `B2-C2` или `SUM(B2:B5)` без начального `=`. Использование такой формы сохраняет согласованность с документированными примерами API.