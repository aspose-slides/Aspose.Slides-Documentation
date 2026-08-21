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
- вычисление формул
- предпочтительная культура
- формула, зависящая от культуры
- DBCS
- логическая константа
- числовая константа
- строковая константа
- константа ошибки
- арифметический оператор
- оператор сравнения
- стиль A1
- стиль R1C1
- предопределенная функция
- PowerPoint
- презентация
- Node.js
- JavaScript
- Aspose.Slides
description: "Применяйте формулы в стиле Excel в листах диаграмм Aspose.Slides для Node.js через Java, пересчитывайте значения и используйте результаты в диаграммах PowerPoint."
---
## **Обзор**

Диаграммы PowerPoint обычно хранят исходные данные во встроенном листе. В Aspose.Slides for Node.js via Java вы можете получить доступ к этому листу через рабочую книгу данных диаграммы, записывать входные значения, присваивать ячейкам формулы, вычислять поддерживаемые формулы и использовать вычисленные ячейки как данные диаграммы.

Эта статья объясняет полный рабочий процесс с формулами: создание диаграммы, заполнение её листа, присвоение формул в стиле A1 или R1C1, перерасчёт, чтение вычисленных значений, привязку этих ячеек к рядам диаграммы и сохранение презентации. Также описываются поддерживаемый синтаксис формул, набор встроенных функций, кэшированные значения, неподдерживаемые формулы и ошибки, специфичные для таблиц.

## **Листы диаграмм и формулы**

Лист диаграммы содержит категории, имена рядов и значения, используемые диаграммой. В PowerPoint вы можете просмотреть лист, открыв редактор данных диаграммы:

![Диаграмма PowerPoint с открытым встроенным листом, показывающая данные категорий и рядов](chart-worksheet-formulas_1.png)

В Aspose.Slides лист раскрывается через класс [ChartDataWorkbook](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/chartdataworkbook/). Используйте [ChartDataCell.setFormula](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/chartdatacell/#setFormula-java.lang.String-) для формул в стиле A1 и [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/chartdatacell/#setR1C1Formula-java.lang.String-) для формул в стиле R1C1. После изменения входных ячеек или формул вызовите [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--) для перерасчёта поддерживаемых формул и обновления соответствующих значений ячеек.

Вычисленная ячейка по‑прежнему предоставляет свой результат через [ChartDataCell.getValue](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/chartdatacell/#getValue--). Это важно, когда нужно проверить результат формулы в коде или использовать ячейку как точку данных диаграммы.

## **Создание диаграммы и вычисление формул листа**

Следующий пример демонстрирует сквозной рабочий процесс. Он создаёт сгруппированную столбчатую диаграмму, очищает примерные данные, записывает квартальные значения доходов и расходов, вычисляет прибыль с помощью формул, читает результаты, использует вычисленные ячейки как значения диаграммы и сохраняет презентацию.

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

Точки данных диаграммы ссылаются на `D2:D4`, поэтому диаграмма использует вычисленные значения прибыли. В этом рабочем процессе нет отдельного вызова обновления диаграммы: сначала перерасчитайте рабочую книгу, затем используйте или сохраните данные диаграммы, указывающие на вычисленные ячейки.

## **Использование формул в стиле A1**

Запись A1 использует буквы для обозначения столбцов и цифры для строк. Присваивайте выражения в стиле A1 через [ChartDataCell.setFormula](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/chartdatacell/#setFormula-java.lang.String-).

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

Обычные формы ссылок A1:

| Ссылка | Относительная | Абсолютная | Смешанная |
|---|---|---|---|
| Ячейка | `A2` | `$A$2` | `A$2`, `$A2` |
| Строка | `2:2` | `$2:$2` | — |
| Столбец | `A:A` | `$A:$A` | — |
| Диапазон | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

Относительные ссылки могут изменяться, когда формула перемещается или копируется в табличном приложении. Абсолютные ссылки фиксируют обе координаты, а смешанные фиксируют только строку или только столбец.

## **Использование формул в стиле R1C1**

Запись R1C1 идентифицирует как строки, так и столбцы числовыми значениями. Относительные ссылки используют смещения в квадратных скобках. Присваивайте эту запись через [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/chartdatacell/#setR1C1Formula-java.lang.String-).

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

Обычные формы ссылок R1C1:

| Ссылка | Относительная | Абсолютная | Смешанная |
|---|---|---|---|
| Ячейка | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| Строка | `R[2]` | `R2` | — |
| Столбец | `C[3]` | `C3` | — |
| Диапазон | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

Например, в ячейке `D2` запись `RC[-2]` означает ячейку в той же строке на две колонки влево (`B2`).

## **Константы и операторы формул**

Встроенный вычислитель формул поддерживает логические значения, числовые литералы, строки, значения ошибок листа, арифметические операторы и операторы сравнения.

### **Константы и литералы**

| Тип | Примеры | Примечания |
|---|---|---|
| Логический | `TRUE`, `FALSE` | Можно использовать напрямую в логических выражениях, например `A2=TRUE`. |
| Числовой | `1`, `0.5`, `.3`, `1E-2` | Поддерживаются обычная и научная запись. |
| Строка | `"abc"`, `"2/3/2020 12:00"` | Текстовые литералы заключаются в двойные кавычки внутри формулы. |
| Результат ошибки | `#DIV/0!`, `#N/A`, `#REF!` | Валидная формула может дать результат ошибки листа вместо обычного значения. |

В этом примере используются несколько типов констант:

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

    const logicalValue = workbook.getCell(0, "B2").getValue(); // false
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

Aspose.Slides включает встроенный вычислитель формул для листов диаграмм, но это не полноценный движок расчётов Excel. Документированный набор функций ограничен функциями, перечисленными ниже. Не стоит предполагать, что произвольную функцию Excel можно пересчитать с помощью [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--).

| Функция | Назначение или поддерживаемая форма | Пример |
|---|---|---|
| `ABS` | Абсолютное значение | `ABS(A2)` |
| `AVERAGE` | Среднее арифметическое | `AVERAGE(B2:B5)` |
| `CEILING` | Округление числа вверх до кратного | `CEILING(A2,5)` |
| `CHOOSE` | Выбор значения по индексу | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | Объединение текстовых значений | `CONCAT(A2,B2)` |
| `CONCATENATE` | Объединение текстовых значений | `CONCATENATE(A2," ",B2)` |
| `DATE` | Создание значения даты с использованием системы дат 1900 | `DATE(2026,8,19)` |
| `DAYS` | Возврат количества дней между датами | `DAYS(B2,A2)` |
| `FIND` | Поиск одного текстового значения внутри другого | `FIND("-",A2)` |
| `FINDB` | Поиск текста по байтам | `FINDB("a",A2)` |
| `IF` | Условный результат | `IF(A2>0,A2,0)` |
| `INDEX` | Форма ссылки | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | Векторная форма | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | Векторная форма | `MATCH(A2,B2:B5,0)` |
| `MAX` | Максимальное значение | `MAX(B2:B5)` |
| `SUM` | Сумма значений | `SUM(B2:B5)` |
| `VLOOKUP` | Вертикальный поиск | `VLOOKUP(A2,B2:D10,3,FALSE)` |

Ограничения, указанные в таблице, существенны: `INDEX` документирована в виде ссылки, тогда как `LOOKUP` и `MATCH` – в их векторных формах. `DATE` использует систему дат 1900. Функции и возможности, не перечисленные здесь, следует считать неподдерживаемыми встроенным вычислителем Aspose.Slides, если они не задокументированы отдельно.

## **Вычисление формул с предпочтительной культурой**

Некоторые функции листа диаграмм интерпретируют текст в соответствии с правилами конкретной культуры. Это особенно важно для функций, предназначенных для языков, использующих двойные байтовые наборы символов (DBCS). Чтобы корректно вычислять такие формулы, создайте [LoadOptions](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/loadoptions/), задайте предпочтительную культуру с помощью [SpreadsheetOptions.setPreferredCulture](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/spreadsheetoptions/#setPreferredCulture), передайте параметры листа через [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/loadoptions/#setSpreadsheetOptions), а затем загрузите презентацию.

Следующий пример выбирает японскую культуру, открывает презентацию с настроенными параметрами загрузки и вызывает [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--) для каждой рабочей книги диаграммы:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const japaneseCulture = java.newInstanceSync("java.util.Locale", "ja", "JP");

const spreadsheetOptions = new aspose.slides.SpreadsheetOptions();
spreadsheetOptions.setPreferredCulture(japaneseCulture);

const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

const presentation = new aspose.slides.Presentation("presentation.pptx", loadOptions);
try {
    const slides = presentation.getSlides();
    for (let slideIndex = 0; slideIndex < slides.size(); slideIndex++) {
        const shapes = slides.get_Item(slideIndex).getShapes();
        for (let shapeIndex = 0; shapeIndex < shapes.size(); shapeIndex++) {
            const shape = shapes.get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.IChart")) {
                shape.getChartData().getChartDataWorkbook().calculateFormulas();
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Предпочтительная культура является частью конфигурации загрузки презентации, поэтому указывайте её до создания экземпляра [Presentation](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/). Используйте культуру, ожидаемую формулами листа; например, `ja-JP` для формул, которые должны следовать правилам расчёта японского DBCS.

## **Перерасчёт и кэшированные значения**

Файлы таблиц обычно хранят как формулу, так и её последнее вычисленное значение. Поэтому Aspose.Slides может считать кэшированное значение из [ChartDataCell.getValue](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/chartdatacell/#getValue--) при загрузке презентации, если соответствующие данные диаграммы не изменялись.

После изменения входных ячеек или формул не полагайтесь на старый кэшированный результат. Вызовите [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--) перед чтением вычисленных значений или сохранением данных диаграммы, от которых они зависят.

Для формул, не входящих в поддерживаемый набор, Aspose.Slides может быть не в состоянии разобрать формулу или определить её зависимости. Если лист был изменён, прежнее кэшированное значение уже нельзя считать надёжным. В такой ситуации чтение значения ячейки с неподдерживаемыми данными может вызвать [CellUnsupportedDataException](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/cellunsupporteddataexception/).

Если ваша диаграмма зависит от функций Excel, которые Aspose.Slides не вычисляет, выполните расчёт этих формул в табличном движке, который их поддерживает, и запишите полученные значения обратно в лист диаграммы. Не заменяйте неподдерживаемые формулы «угаданными» значениями.

## **Обработка ошибок формул**

Существует два разных вида проблем.

Формула может быть корректной, но возвращать результат ошибки листа, например `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!` или `#VALUE!`. В этом случае токен ошибки является результатом ячейки и может быть получен через [ChartDataCell.getValue](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/chartdatacell/#getValue--).

Формула также может потерпеть неудачу на этапе синтаксического анализа, ссылки, зависимости или из‑за неподдерживаемых данных. Aspose.Slides предоставляет специфические для таблиц исключения: [CellInvalidFormulaException](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/cellcircularreferenceexception/) и [CellUnsupportedDataException](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/cellunsupporteddataexception/).

Когда формулы поступают из шаблонов или вводятся пользователем, оберните их обработкой ошибок при перерасчёте и доступе к значениям. Подробности ошибки указывают на конкретную проблему листа:

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

Поддержка формул в листах диаграмм предназначена для ограниченного подмножества расчётов таблиц, а не для полной совместимости с Excel. Учтите эти ограничения при проектировании отчётных процессов:

- Используйте только задокументированные константы, операторы, ссылки и функции, когда требуется, чтобы Aspose.Slides пересчитывал формулы.
- Перерасчитывайте после изменения ячеек, от которых зависят результаты формул.
- Рассматривайте кэшированные значения из загруженных презентаций как «снимки», а не как замену перерасчёту после правок.
- Тестируйте формулы из существующих шаблонов перед тем, как полагаться на их вычисленные значения, особенно если они используют функции, не указанные в списке.
- Для формул, требующих полноценного табличного движка, выполните расчёт внешне, а затем обновите лист диаграммы полученными значениями.

## **FAQ**

**В чём разница между [ChartDataCell.setFormula](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/chartdatacell/#setFormula-java.lang.String-) и [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/chartdatacell/#setR1C1Formula-java.lang.String-)?**

[ChartDataCell.setFormula] сохраняет выражение в стиле A1, например `B2-C2`. [ChartDataCell.setR1C1Formula] сохраняет выражение в стиле R1C1, например `RC[-2]-RC[-1]`. Используйте тот стиль, который лучше соответствует способу генерации или копирования формул.

**Нужно ли читать саму ячейку или её значение после расчёта?**

[ChartDataWorkbook.getCell] возвращает объект [ChartDataCell]. Чтобы получить вычисленный результат, вызовите у этой ячейки метод [ChartDataCell.getValue] после перерасчёта.

**Когда следует вызывать [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--)?**

Вызывайте [ChartDataWorkbook.calculateFormulas] после изменения входных значений или формул и перед тем, как использовать вычисленные результаты. Это обновит значения формул, поддерживаемых встроенным вычислителем.

**Поддерживает ли Aspose.Slides каждую функцию Excel?**

Нет. Встроенный вычислитель поддерживает лишь документированный подмножество функций. Функции, не входящие в этот набор, не следует считать корректно пересчитываемыми. Если требуется полная совместимость с формулами Excel, выполните расчёт внешним табличным движком и запишите финальные значения в лист диаграммы.

**Что происходит, если загруженная презентация содержит неподдерживаемую формулу?**

Если данные диаграммы не изменялись, лист может всё ещё содержать ранее вычисленное кэшированное значение. После изменения связанных данных это кэшированное значение может стать недействительным. Попытка доступа к ячейке, формула которой не может быть обработана, может вызвать [CellUnsupportedDataException].

**Являются ли значения ошибок формул теми же, что и исключения?**

Нет. Результат вроде `#DIV/0!` — это значение листа, полученное в результате корректного вычисления. Исключения, такие как [CellInvalidFormulaException] или [CellCircularReferenceException], указывают на то, что формулу невозможно обработать обычным способом.

**Обновляется ли диаграмма автоматически при изменении ячейки формулы?**

Ряд диаграммы может ссылаться на ячейки листа. Перерасчитайте лист сначала, затем сохраните или отобразите презентацию. Если точки данных диаграммы ссылаются на вычисленные ячейки, диаграмма использует обновлённые значения; отдельный метод обновления диаграммы не требуется.

**Могут ли диаграммы использовать внешний рабочий лист Excel?**

Да, данные диаграммы можно настроить для использования внешнего листа через API данных диаграммы. Однако описанный в этой статье рабочий процесс расчёта формул относится к листу данных диаграммы и подмножеству формул, поддерживаемому Aspose.Slides. Не следует предполагать, что [ChartDataWorkbook.calculateFormulas] обеспечит полное пересчёты произвольных формул во внешнем файле XLSX.

**Можно ли использовать формулы, ссылающиеся на другой лист или книгу?**

Ссылки в стиле Excel могут присутствовать в листах диаграмм, но вычисление ограничено поддерживаемым парсером и набором функций. Если необходима ссылка между листами или внешняя ссылка, проверьте точную формулу с вашей целевой версией Aspose.Slides. Для сценариев, требующих широкой совместимости с ссылками Excel, выполните расчёт листа внешне и запишите разрешённые значения обратно в данные диаграммы.

**Должны ли строки формул начинаться с `=`?**

Примеры API Aspose.Slides задают выражения без начального `=`, например `B2-C2` или `SUM(B2:B5)`. Использование такой формы сохраняет согласованность с документированными примерами API.