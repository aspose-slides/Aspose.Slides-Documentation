---
title: Применение формул листов диаграмм в презентациях на Java
linktitle: Формулы листа
type: docs
weight: 70
url: /ru/java/chart-worksheet-formulas/
keywords:
- таблица диаграммы
- лист диаграммы
- формула диаграммы
- формула листа
- формула электронных таблиц
- рабочая книга данных диаграммы
- вычисление формулы
- предпочтительная культура
- культурно-специфическая формула
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
- Java
- Aspose.Slides
description: "Применяйте формулы в стиле Excel в листах диаграмм Aspose.Slides для Java, пересчитывайте значения и используйте результаты в диаграммах PowerPoint."
---
## **Обзор**

Диаграммы PowerPoint обычно хранят исходные данные во встраиваемой таблице. В Aspose.Slides для Java вы можете получить доступ к этой таблице через рабочую книгу данных диаграммы, записывать входные значения, назначать формулы ячейкам, вычислять поддерживаемые формулы и использовать вычисленные ячейки как данные диаграммы.

Эта статья объясняет полный рабочий процесс с формулами: создание диаграммы, заполнение её таблицы, назначение формул в стиле A1 или R1C1, их пересчёт, чтение вычисленных значений, привязка этих ячеек к серии диаграммы и сохранение презентации. Она также описывает поддерживаемый синтаксис формул, набор встроенных функций, кэшированные значения, неподдерживаемые формулы и ошибки, специфичные для электронных таблиц.

## **Таблицы данных диаграмм и формулы**

Таблица данных диаграммы содержит категории, имена рядов и значения, используемые диаграммой. В PowerPoint вы можете просмотреть таблицу, открыв редактор данных диаграммы:

![Диаграмма PowerPoint с открытой встроенной таблицей, показывающая данные категорий и рядов](chart-worksheet-formulas_1.png)

В Aspose.Slides таблица доступна через интерфейс[IChartDataWorkbook](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ichartdataworkbook/). Используйте[IChartDataCell.setFormula](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) для формул в стиле A1 и[IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-) для формул в стиле R1C1. После изменения входных ячеек или формул вызовите[IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) для пересчёта поддерживаемых формул и обновления соответствующих значений ячеек.

Вычисленная ячейка всё ещё предоставляет свой результат через[IChartDataCell.getValue](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ichartdatacell/#getValue--). Это важно, когда нужно проверить результат формулы в коде или использовать ячейку как точку данных диаграммы.

## **Создание диаграммы и вычисление формул таблицы**

Следующий пример демонстрирует сквозной рабочий процесс. Он создаёт сгруппированную столбчатую диаграмму, очищает примерные данные, записывает квартальные значения доходов и расходов, вычисляет прибыль с помощью формул, читает результаты, использует вычисленные ячейки как значения диаграммы и сохраняет презентацию.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 350);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    int worksheetIndex = 0;

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    workbook.clear(worksheetIndex);

    IChartDataCell category1 = workbook.getCell(worksheetIndex, "A2", "Q1");
    IChartDataCell category2 = workbook.getCell(worksheetIndex, "A3", "Q2");
    IChartDataCell category3 = workbook.getCell(worksheetIndex, "A4", "Q3");

    workbook.getCell(worksheetIndex, "B1", "Revenue");
    workbook.getCell(worksheetIndex, "C1", "Expenses");
    workbook.getCell(worksheetIndex, "D1", "Profit");

    workbook.getCell(worksheetIndex, "B2").setValue(120.0);
    workbook.getCell(worksheetIndex, "C2").setValue(80.0);
    workbook.getCell(worksheetIndex, "B3").setValue(150.0);
    workbook.getCell(worksheetIndex, "C3").setValue(95.0);
    workbook.getCell(worksheetIndex, "B4").setValue(135.0);
    workbook.getCell(worksheetIndex, "C4").setValue(110.0);

    IChartDataCell profit1 = workbook.getCell(worksheetIndex, "D2");
    IChartDataCell profit2 = workbook.getCell(worksheetIndex, "D3");
    IChartDataCell profit3 = workbook.getCell(worksheetIndex, "D4");

    profit1.setFormula("B2-C2");
    profit2.setFormula("B3-C3");
    profit3.setFormula("B4-C4");

    workbook.calculateFormulas();

    double q1Profit = ((Number) profit1.getValue()).doubleValue(); // 40
    double q2Profit = ((Number) profit2.getValue()).doubleValue(); // 55
    double q3Profit = ((Number) profit3.getValue()).doubleValue(); // 25

    System.out.println("Q1 profit: " + q1Profit);
    System.out.println("Q2 profit: " + q2Profit);
    System.out.println("Q3 profit: " + q3Profit);

    chart.getChartData().getCategories().add(category1);
    chart.getChartData().getCategories().add(category2);
    chart.getChartData().getCategories().add(category3);

    IChartSeries profitSeries = chart.getChartData().getSeries().add(workbook.getCell(worksheetIndex, "D1"), chart.getType());
    profitSeries.getDataPoints().addDataPointForBarSeries(profit1);
    profitSeries.getDataPoints().addDataPointForBarSeries(profit2);
    profitSeries.getDataPoints().addDataPointForBarSeries(profit3);
    profitSeries.getLabels().getDefaultDataLabelFormat().setShowValue(true);

    presentation.save("chart-formulas.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Точки данных диаграммы ссылаются на`D2:D4`, поэтому диаграмма использует вычисленные значения прибыли. В этом процессе нет отдельного вызова обновления диаграммы: сначала пересчитайте рабочую книгу, затем используйте или сохраните данные диаграммы, указывающие на вычисленные ячейки.

## **Использование формул в стиле A1**

Запись в стиле A1 определяет столбцы буквами, а строки — цифрами. Назначайте выражения в стиле A1 через[IChartDataCell.setFormula](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    workbook.getCell(0, "C3").setValue(10);
    workbook.getCell(0, "F2").setValue(2);
    workbook.getCell(0, "G2").setValue(3);
    workbook.getCell(0, "H2").setValue(4);

    IChartDataCell cell = workbook.getCell(0, "A2");
    cell.setFormula("C3+SUM(F2:H2)");

    workbook.calculateFormulas();

    Object value = cell.getValue(); // 19
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

Относительные ссылки могут изменяться при перемещении или копировании формулы в приложении таблиц. Абсолютные ссылки фиксируют обе координаты, а смешанные фиксируют только строку или только столбец.

## **Использование формул в стиле R1C1**

Запись в стиле R1C1 определяет и строки, и столбцы численно. Относительные ссылки используют смещения в квадратных скобках. Назначайте такой синтаксис через[IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    workbook.getCell(0, "B2").setValue(12);
    workbook.getCell(0, "C2").setValue(5);

    IChartDataCell cell = workbook.getCell(0, "D2");
    cell.setR1C1Formula("RC[-2]-RC[-1]");

    workbook.calculateFormulas();

    Object value = cell.getValue(); // 7
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

Например, в ячейке`D2` `RC[-2]` означает ячейку в той же строке на два столбца левее (`B2`).

## **Константы формул и операторы**

Встроенный вычислитель формул поддерживает логические значения, числовые литералы, строки, значения ошибок таблиц, арифметические и сравнительные операторы.

### **Константы и литералы**

| Тип | Примеры | Примечания |
|---|---|---|
| Логическое | `TRUE`, `FALSE` | Можно использовать напрямую в логических выражениях, например `A2=TRUE`. |
| Числовое | `1`, `0.5`, `.3`, `1E-2` | Поддерживаются обычные и научные записи. |
| Строка | `"abc"`, `"2/3/2020 12:00"` | Текстовые литералы заключаются в двойные кавычки внутри формулы. |
| Результат ошибки | `#DIV/0!`, `#N/A`, `#REF!` | Валидная формула может давать значение ошибки вместо обычного результата. |

Этот пример использует несколько типов констант:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    workbook.getCell(0, "A2").setValue(false);
    workbook.getCell(0, "B2").setFormula("A2=TRUE");
    workbook.getCell(0, "C2").setFormula("1+0.5");
    workbook.getCell(0, "D2").setFormula(".3*1E-2");
    workbook.getCell(0, "E2").setFormula("\"abc\"");
    workbook.getCell(0, "F2").setFormula("2/0");

    workbook.calculateFormulas();

    Object logicalValue = workbook.getCell(0, "B2").getValue(); // false
    Object numericValue = workbook.getCell(0, "C2").getValue(); // 1.5
    Object scientificValue = workbook.getCell(0, "D2").getValue(); // 0.003
    Object stringValue = workbook.getCell(0, "E2").getValue(); // abc
    Object errorValue = workbook.getCell(0, "F2").getValue(); // #DIV/0!
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

Сравнительные выражения возвращают логические значения.

| Оператор | Значение | Пример |
|---|---|---|
| `=` | Равно | `A2=3` |
| `<>` | Не равно | `A2<>3` |
| `>` | Больше | `A2>3` |
| `>=` | Больше или равно | `A2>=3` |
| `<` | Меньше | `A2<3` |
| `<=` | Меньше или равно | `A2<=3` |

## **Поддерживаемые предопределённые функции**

Aspose.Slides включает встроенный вычислитель формул для таблиц диаграмм, но это не полноценный движок расчёта Excel. Документированный набор функций ограничен перечисленными ниже. Не предполагавайте, что произвольная функция Excel может быть пересчитана с помощью[IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--).

| Функция | Назначение или поддерживаемая форма | Пример |
|---|---|---|
| `ABS` | Абсолютное значение | `ABS(A2)` |
| `AVERAGE` | Арифметическое среднее | `AVERAGE(B2:B5)` |
| `CEILING` | Округление числа вверх до кратного | `CEILING(A2,5)` |
| `CHOOSE` | Выбор значения по индексу | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | Объединение текстовых значений | `CONCAT(A2,B2)` |
| `CONCATENATE` | Объединение текстовых значений | `CONCATENATE(A2," ",B2)` |
| `DATE` | Создание даты в системе 1900‑го года | `DATE(2026,8,19)` |
| `DAYS` | Количество дней между датами | `DAYS(B2,A2)` |
| `FIND` | Поиск текста внутри другого текста | `FIND("-",A2)` |
| `FINDB` | Поиск текста в байтовом представлении | `FINDB("a",A2)` |
| `IF` | Условный результат | `IF(A2>0,A2,0)` |
| `INDEX` | Ссылка в виде формы | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | Векторная форма | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | Векторная форма | `MATCH(A2,B2:B5,0)` |
| `MAX` | Максимальное значение | `MAX(B2:B5)` |
| `SUM` | Сумма значений | `SUM(B2:B5)` |
| `VLOOKUP` | Вертикальный поиск | `VLOOKUP(A2,B2:D10,3,FALSE)` |

Ограничения, показанные в таблице, существенны: `INDEX` документируется в виде ссылки, тогда как `LOOKUP` и `MATCH` — в векторных формах. `DATE` использует систему дат 1900‑го года. Функции, не перечисленные здесь, следует считать неподдерживаемыми встроенным вычислителем Aspose.Slides, если они не документированы отдельно.

## **Вычисление формул с предпочтительной культурой**

Некоторые функции рабочей книги интерпретируют текст согласно правилам конкретной культуры. Это особенно важно для функций, предназначенных для языков с двойным байтовым набором символов (DBCS). Чтобы правильно вычислить такие формулы, создайте[LoadOptions](https://reference.aspose.com/slides/ru/java/com.aspose.slides/loadoptions/), задайте предпочтительную культуру с помощью[SpreadsheetOptions.setPreferredCulture](https://reference.aspose.com/slides/ru/java/com.aspose.slides/spreadsheetoptions/#setPreferredCulture-java.util.Locale-), передайте параметры таблицы через[LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/ru/java/com.aspose.slides/loadoptions/#setSpreadsheetOptions-com.aspose.slides.ISpreadsheetOptions-), затем загрузите презентацию.

В следующем примере выбирается японская культура, открывается презентация с настроенными параметрами загрузки и вызывается[IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) для каждой рабочей книги диаграммы:

```java
import com.aspose.slides.*;
import java.util.Locale;

Locale japaneseCulture = Locale.forLanguageTag("ja-JP");

ISpreadsheetOptions spreadsheetOptions = new SpreadsheetOptions();
spreadsheetOptions.setPreferredCulture(japaneseCulture);

LoadOptions loadOptions = new LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

Presentation presentation = new Presentation("presentation.pptx", loadOptions);
try {
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IChart) {
                IChart chart = (IChart) shape;
                chart.getChartData().getChartDataWorkbook().calculateFormulas();
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Предпочтительная культура является частью конфигурации загрузки презентации, поэтому указывайте её до создания экземпляра[Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/). Используйте культуру, ожидаемую формулами рабочей книги; например, `ja-JP` для формул, которые должны следовать правилам расчёта DBCS в Японии.

## **Пересчёт и кэшированные значения**

Файлы электронных таблиц обычно хранят одновременно формулу и её последний вычисленный результат. Aspose.Slides может поэтому читать кэшированное значение через[IChartDataCell.getValue](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ichartdatacell/#getValue--) при загрузке презентации, если соответствующие данные диаграммы не были изменены.

После изменения входных ячеек или формул не полагайтесь на старый кэшированный результат. Вызовите[IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) перед чтением вычисленных значений или сохранением данных диаграммы, от которых они зависят.

Для формул, не входящих в поддерживаемый набор, Aspose.Slides может не суметь разобрать формулу или установить её зависимости. Если рабочая книга была изменена, предыдущее кэшированное значение уже нельзя считать надёжным. В такой ситуации чтение значения ячейки с неподдерживаемыми данными может вызвать[CellUnsupportedDataException](https://reference.aspose.com/slides/ru/java/com.aspose.slides/cellunsupporteddataexception/).

Если ваша диаграмма зависит от функций Excel, которые Aspose.Slides не оценивает, вычислите эти формулы с помощью движка таблиц, поддерживающего их, и запишите полученные значения обратно в рабочую книгу диаграммы. Не заменяйте неподдерживаемые формулы догадками.

## **Обработка ошибок формул**

Существует два разных типа проблем.

Формула может быть корректной, но возвращать результат ошибки таблицы, например `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!` или `#VALUE!`. В этом случае токен ошибки является результатом ячейки и может быть возвращён через[IChartDataCell.getValue](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ichartdatacell/#getValue--).

Формула также может потерпеть неудачу на этапе разбора, ссылки, зависимостей или поддержки данных. Aspose.Slides предоставляет специфичные для таблиц исключения:[CellInvalidFormulaException](https://reference.aspose.com/slides/ru/java/com.aspose.slides/cellinvalidformulaexception/),[CellInvalidReferenceException](https://reference.aspose.com/slides/ru/java/com.aspose.slides/cellinvalidreferenceexception/),[CellCircularReferenceException](https://reference.aspose.com/slides/ru/java/com.aspose.slides/cellcircularreferenceexception/),[CellUnsupportedDataException](https://reference.aspose.com/slides/ru/java/com.aspose.slides/cellunsupporteddataexception/).

Когда формулы поступают из шаблонов или пользовательского ввода, обрабатывайте эти исключения вокруг пересчёта и доступа к значениям:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    IChartDataCell cell = workbook.getCell(0, "A2");
    cell.setFormula("SUM(B2:B5)");

    try {
        workbook.calculateFormulas();
        System.out.println(cell.getValue());
    } catch (CellInvalidFormulaException ex) {
        System.err.println("Invalid formula: " + ex.getMessage());
    } catch (CellInvalidReferenceException ex) {
        System.err.println("Invalid cell reference: " + ex.getMessage());
    } catch (CellCircularReferenceException ex) {
        System.err.println("Circular reference: " + ex.getMessage());
    } catch (CellUnsupportedDataException ex) {
        System.err.println("Unsupported spreadsheet data: " + ex.getMessage());
    }
} finally {
    presentation.dispose();
}
```

## **Практические ограничения**

Поддержка формул в таблицах диаграмм предназначена для определённого подмножества расчётов, а не для полной совместимости с Excel. Учитывайте эти ограничения при проектировании рабочего процесса отчётности:

- Используйте только документированные константы, операторы, ссылки и функции, когда требуется, чтобы Aspose.Slides пересчитывал формулы.
- Пересчитывайте после изменения ячеек, от которых зависят результаты формул.
- Рассматривайте кэшированные значения из загруженных презентаций как «снимки», а не как замену пересчёту после правок.
- Тестируйте формулы из существующих шаблонов перед тем, как полагаться на их вычисленные значения, особенно если они используют функции, не входящие в документированный список.
- Для формул, требующих полноценного движка расчётов, вычислите их внешне, а затем обновите рабочую книгу диаграммы полученными значениями.

## **FAQ**

**В чём разница между[IChartDataCell.setFormula](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) и[IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-)?**

[IChartDataCell.setFormula](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) сохраняет выражение в стиле A1, например `B2-C2`. [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-) сохраняет выражение в стиле R1C1, например `RC[-2]-RC[-1]`. Используйте нотацию, которая лучше соответствует тому, как вы генерируете или копируете формулы.

**Нужно ли читать саму ячейку или её значение после вычисления?**

[IChartDataWorkbook.getCell](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ichartdataworkbook/#getCell-int-java.lang.String-) возвращает[IChartDataCell](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ichartdatacell/). Чтобы получить вычисленный результат, вызовите у этой ячейки метод[IChartDataCell.getValue](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ichartdatacell/#getValue--) после пересчёта.

**Когда следует вызывать[IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--)?**

Вызывайте[IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) после изменения входных значений или формул и перед тем, как полагаться на вычисленные результаты. Это обновит значения формул, поддерживаемых встроенным вычислителем.

**Поддерживает ли Aspose.Slides каждую функцию Excel?**

Нет. Встроенный вычислитель поддерживает документированный поднабор функций. Функции, не входящие в этот поднабор, не следует считать корректно пересчитываемыми. Если требуется полная совместимость с формулами Excel, выполните расчёт с помощью подходящего движка таблиц и запишите окончательные значения в рабочую книгу диаграммы.

**Что происходит, если загруженная презентация содержит неподдерживаемую формулу?**

Если данные диаграммы не изменялись, в рабочей книге может присутствовать ранее вычисленное кэшированное значение. После изменения связанных данных это кэшированное значение может стать недействительным. Обращение к ячейке, формула которой не может быть обработана, может вызвать[CellUnsupportedDataException](https://reference.aspose.com/slides/ru/java/com.aspose.slides/cellunsupporteddataexception/).

**Являются ли значения ошибок формул теми же, что и исключения Java?**

Нет. Результат типа `#DIV/0!` — это значение таблицы, полученное в результате корректного вычисления. Исключения, такие как[CellInvalidFormulaException](https://reference.aspose.com/slides/ru/java/com.aspose.slides/cellinvalidformulaexception/) или[CellCircularReferenceException](https://reference.aspose.com/slides/ru/java/com.aspose.slides/cellcircularreferenceexception/), указывают на то, что формула не может быть обработана нормально.

**Обновляется ли диаграмма автоматически при изменении ячейки формулы?**

Серия диаграммы может ссылаться на ячейки рабочей книги. Сначала пересчитайте рабочую книгу, затем сохраните или отобразите презентацию. Если точки данных диаграммы ссылаются на вычисленные ячейки, диаграмма использует обновлённые значения; отдельный метод обновления диаграммы не требуется в этом рабочем процессе.

**Могут ли диаграммы использовать внешний файл Excel?**

Да, данные диаграммы можно настроить для использования внешней рабочей книги через API данных диаграммы. Однако описанный в этой статье процесс вычисления формул касается только рабочей книги данных диаграммы и подмножества формул, оцениваемых Aspose.Slides. Не предполагайте, что[IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) обеспечивает полное пересчёт произвольных формул во внешнем файле XLSX.

**Могу ли я использовать формулы, ссылающиеся на другой лист или рабочую книгу?**

Ссылки в стиле Excel могут присутствовать в рабочих книгах диаграмм, но оценка формул ограничена поддерживаемым парсером и набором функций. Если необходима кросс‑листовая или внешняя ссылка, проверьте её корректность для конкретной версии Aspose.Slides. Для сценариев, требующих широкой совместимости ссылок Excel, вычислите рабочую книгу внешне и запишите разрешённые значения обратно в данные диаграммы.

**Должны ли строковые представления формул начинаться с `=`?**

Примеры API Aspose.Slides задают выражения вроде `B2-C2` или `SUM(B2:B5)` без начального знака `=`. Использование такой формы сохраняет согласованность с документированными примерами API.