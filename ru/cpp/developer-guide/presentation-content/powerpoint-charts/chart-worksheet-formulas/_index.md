---
title: Применение формул листа диаграммы в презентациях с использованием C++
linktitle: Формулы листа
type: docs
weight: 70
url: /ru/cpp/chart-worksheet-formulas/
keywords:
- диаграмма электронная таблица
- лист диаграммы
- формула диаграммы
- формула листа
- формула электронных таблиц
- рабочая книга данных диаграммы
- расчёт формулы
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
- C++
- Aspose.Slides
description: "Применяйте формулы в стиле Excel в листах диаграмм Aspose.Slides для C++, пересчитывайте значения и используйте результаты в диаграммах PowerPoint."
---
## **Обзор**

Диаграммы PowerPoint обычно хранят исходные данные во встроенном листе. В Aspose.Slides for C++ вы можете получить доступ к этому листу через рабочую книгу данных диаграммы, записывать значения, присваивать формулы ячейкам, вычислять поддерживаемые формулы и использовать вычисленные ячейки как данные диаграммы.

В этой статье объясняется полный рабочий процесс с формулами: создание диаграммы, заполнение её листа, назначение формул в стиле A1 или R1C1, их повторный расчёт, чтение вычисленных значений, привязка этих ячеек к серии диаграммы и сохранение презентации. Также описывается синтаксис поддерживаемых формул, набор встроенных функций, кэшированные значения, неподдерживаемые формулы и ошибки, специфичные для электронных таблиц.

## **Листы диаграмм и формулы**

Лист диаграммы содержит категории, имена серий и значения, используемые диаграммой. В PowerPoint вы можете просмотреть лист, открыв редактор данных диаграммы:

![Диаграмма PowerPoint с открытым встроенным листом, показывающая данные категорий и серий](chart-worksheet-formulas_1.png)

В Aspose.Slides лист доступен через интерфейс [IChartDataWorkbook](https://reference.aspose.com/slides/ru/cpp/aspose.slides.charts/ichartdataworkbook/). Используйте [IChartDataCell::set_Formula](https://reference.aspose.com/slides/ru/cpp/aspose.slides.charts/ichartdatacell/set_formula/) для формул в стиле A1 и [IChartDataCell::set_R1C1Formula](https://reference.aspose.com/slides/ru/cpp/aspose.slides.charts/ichartdatacell/set_r1c1formula/) для формул в стиле R1C1. После изменения входных ячеек или формул вызовите [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/ru/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/) для пересчёта поддерживаемых формул и обновления соответствующих значений ячеек.

Вычисленная ячейка всё ещё предоставляет свой результат через [IChartDataCell::get_Value](https://reference.aspose.com/slides/ru/cpp/aspose.slides.charts/ichartdatacell/get_value/). Это важно, когда необходимо проверить результат формулы в коде или использовать ячейку как точку данных диаграммы.

## **Создание диаграммы и вычисление формул листа**

Следующий пример демонстрирует сквозной рабочий процесс. Он создаёт сгруппированную столбцовую диаграмму, очищает примерные данные, записывает квартальные значения доходов и расходов, вычисляет прибыль с помощью формул, читает результаты, использует вычисленные ячейки как значения диаграммы и сохраняет презентацию.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IDataLabelCollection.h>
#include <DOM/Chart/IDataLabelFormat.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 350.0f);
auto chartData = chart->get_ChartData();
auto workbook = chartData->get_ChartDataWorkbook();
const int32_t worksheetIndex = 0;

chartData->get_Series()->Clear();
chartData->get_Categories()->Clear();
workbook->Clear(worksheetIndex);

auto category1 = workbook->GetCell(worksheetIndex, u"A2", ObjectExt::Box<String>(u"Q1"));
auto category2 = workbook->GetCell(worksheetIndex, u"A3", ObjectExt::Box<String>(u"Q2"));
auto category3 = workbook->GetCell(worksheetIndex, u"A4", ObjectExt::Box<String>(u"Q3"));

workbook->GetCell(worksheetIndex, u"B1", ObjectExt::Box<String>(u"Revenue"));
workbook->GetCell(worksheetIndex, u"C1", ObjectExt::Box<String>(u"Expenses"));
workbook->GetCell(worksheetIndex, u"D1", ObjectExt::Box<String>(u"Profit"));

workbook->GetCell(worksheetIndex, u"B2")->set_Value(ObjectExt::Box<double>(120.0));
workbook->GetCell(worksheetIndex, u"C2")->set_Value(ObjectExt::Box<double>(80.0));
workbook->GetCell(worksheetIndex, u"B3")->set_Value(ObjectExt::Box<double>(150.0));
workbook->GetCell(worksheetIndex, u"C3")->set_Value(ObjectExt::Box<double>(95.0));
workbook->GetCell(worksheetIndex, u"B4")->set_Value(ObjectExt::Box<double>(135.0));
workbook->GetCell(worksheetIndex, u"C4")->set_Value(ObjectExt::Box<double>(110.0));

auto profit1 = workbook->GetCell(worksheetIndex, u"D2");
auto profit2 = workbook->GetCell(worksheetIndex, u"D3");
auto profit3 = workbook->GetCell(worksheetIndex, u"D4");

profit1->set_Formula(u"B2-C2");
profit2->set_Formula(u"B3-C3");
profit3->set_Formula(u"B4-C4");

workbook->CalculateFormulas();

auto q1Profit = profit1->get_Value(); // 40
auto q2Profit = profit2->get_Value(); // 55
auto q3Profit = profit3->get_Value(); // 25

chartData->get_Categories()->Add(category1);
chartData->get_Categories()->Add(category2);
chartData->get_Categories()->Add(category3);

auto profitSeries = chartData->get_Series()->Add(workbook->GetCell(worksheetIndex, u"D1"), chart->get_Type());
profitSeries->get_DataPoints()->AddDataPointForBarSeries(profit1);
profitSeries->get_DataPoints()->AddDataPointForBarSeries(profit2);
profitSeries->get_DataPoints()->AddDataPointForBarSeries(profit3);
profitSeries->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);

presentation->Save(u"chart-formulas.pptx", SaveFormat::Pptx);
```

Точки данных диаграммы ссылаются на `D2:D4`, поэтому диаграмма использует вычисленные значения прибыли. В этом рабочем процессе нет отдельного вызова обновления диаграммы: сначала пересчитывается рабочая книга, затем используется или сохраняется диаграмма, ссылающаяся на вычисленные ячейки.

## **Использование формул A1‑Style**

Нотация A1 идентифицирует столбцы буквами, а строки – числами. Присваивайте выражения A1‑style через [IChartDataCell::set_Formula](https://reference.aspose.com/slides/ru/cpp/aspose.slides.charts/ichartdatacell/set_formula/).

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 500.0f, 300.0f);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

workbook->GetCell(0, u"C3")->set_Value(ObjectExt::Box<int32_t>(10));
workbook->GetCell(0, u"F2")->set_Value(ObjectExt::Box<int32_t>(2));
workbook->GetCell(0, u"G2")->set_Value(ObjectExt::Box<int32_t>(3));
workbook->GetCell(0, u"H2")->set_Value(ObjectExt::Box<int32_t>(4));

auto cell = workbook->GetCell(0, u"A2");
cell->set_Formula(u"C3+SUM(F2:H2)");

workbook->CalculateFormulas();

auto value = cell->get_Value(); // 19
```

Распространённые формы ссылок A1:

| Ссылка | Относительная | Абсолютная | Смешанная |
|---|---|---|---|
| Ячейка | `A2` | `$A$2` | `A$2`, `$A2` |
| Строка | `2:2` | `$2:$2` | — |
| Столбец | `A:A` | `$A:$A` | — |
| Диапазон | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

Относительные ссылки могут изменяться при перемещении или копировании формулы в электронных таблицах. Абсолютные ссылки фиксируют обе координаты, а смешанные фиксируют только строку или только столбец.

## **Использование формул R1C1‑Style**

Нотация R1C1 численно идентифицирует как строки, так и столбцы. Относительные ссылки используют смещения в квадратных скобках. Присваивайте эту синтаксис через [IChartDataCell::set_R1C1Formula](https://reference.aspose.com/slides/ru/cpp/aspose.slides.charts/ichartdatacell/set_r1c1formula/).

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 500.0f, 300.0f);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

workbook->GetCell(0, u"B2")->set_Value(ObjectExt::Box<int32_t>(12));
workbook->GetCell(0, u"C2")->set_Value(ObjectExt::Box<int32_t>(5));

auto cell = workbook->GetCell(0, u"D2");
cell->set_R1C1Formula(u"RC[-2]-RC[-1]");

workbook->CalculateFormulas();

auto value = cell->get_Value(); // 7
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

Встроенный оценщик формул поддерживает логические значения, числовые литералы, строки, значения ошибок электронных таблиц, арифметические и сравнительные операторы.

### **Константы и литералы**

| Тип | Примеры | Примечания |
|---|---|---|
| Логический | `TRUE`, `FALSE` | Можно использовать напрямую в логических выражениях, например `A2=TRUE`. |
| Числовой | `1`, `0.5`, `.3`, `1E-2` | Поддерживаются обычная и научная запись. |
| Строка | `"abc"`, `"2/3/2020 12:00"` | Текстовые литералы заключаются в двойные кавычки внутри формулы. |
| Ошибка | `#DIV/0!`, `#N/A`, `#REF!` | Корректная формула может вернуть значение ошибки вместо обычного результата. |

В этом примере используются несколько типов констант:

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 500.0f, 300.0f);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

workbook->GetCell(0, u"A2")->set_Value(ObjectExt::Box<bool>(false));
workbook->GetCell(0, u"B2")->set_Formula(u"A2=TRUE");
workbook->GetCell(0, u"C2")->set_Formula(u"1+0.5");
workbook->GetCell(0, u"D2")->set_Formula(u".3*1E-2");
workbook->GetCell(0, u"E2")->set_Formula(u"\"abc\"");
workbook->GetCell(0, u"F2")->set_Formula(u"2/0");

workbook->CalculateFormulas();

auto logicalValue = workbook->GetCell(0, u"B2")->get_Value(); // Ложь
auto numericValue = workbook->GetCell(0, u"C2")->get_Value(); // 1.5
auto scientificValue = workbook->GetCell(0, u"D2")->get_Value(); // 0.003
auto stringValue = workbook->GetCell(0, u"E2")->get_Value(); // abc
auto errorValue = workbook->GetCell(0, u"F2")->get_Value(); // #DIV/0!
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

Используйте скобки для явного указания порядка вычисления, например `(A2+B2)*C2`.

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

Aspose.Slides включает встроенный оценщик формул для листов диаграмм, но это не полноценный движок расчётов Excel. Документированный набор функций ограничен перечнем ниже. Не следует предполагать, что произвольная функция Excel может быть пересчитана методом [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/ru/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/).

| Функция | Назначение или поддерживаемая форма | Пример |
|---|---|---|
| `ABS` | Абсолютное значение | `ABS(A2)` |
| `AVERAGE` | Среднее арифметическое | `AVERAGE(B2:B5)` |
| `CEILING` | Округление числа вверх до кратного | `CEILING(A2,5)` |
| `CHOOSE` | Выбор значения по индексу | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | Объединение текстовых значений | `CONCAT(A2,B2)` |
| `CONCATENATE` | Объединение текстовых значений | `CONCATENATE(A2," ",B2)` |
| `DATE` | Создание значения даты по системе 1900‑го года | `DATE(2026,8,19)` |
| `DAYS` | Количество дней между датами | `DAYS(B2,A2)` |
| `FIND` | Поиск текста внутри другого текста | `FIND("-",A2)` |
| `FINDB` | Поиск текстовых байтов | `FINDB("a",A2)` |
| `IF` | Условный результат | `IF(A2>0,A2,0)` |
| `INDEX` | Ссылка в виде формы | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | Векторная форма | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | Векторная форма | `MATCH(A2,B2:B5,0)` |
| `MAX` | Максимальное значение | `MAX(B2:B5)` |
| `SUM` | Сумма значений | `SUM(B2:B5)` |
| `VLOOKUP` | Вертикальный поиск | `VLOOKUP(A2,B2:D10,3,FALSE)` |

Ограничения, указанные в таблице, существенны: `INDEX` документирована в виде ссылки, тогда как `LOOKUP` и `MATCH` — в векторных формах. `DATE` использует систему дат 1900‑го года. Функции и возможности, не перечисленные здесь, следует считать неподдерживаемыми встроенным оценщиком формул Aspose.Slides, если они не документированы отдельно.

## **Пересчёт и кэшированные значения**

Файлы электронных таблиц обычно хранят как формулу, так и её последнее вычисленное значение. Aspose.Slides может прочитать кэшированное значение из [IChartDataCell::get_Value](https://reference.aspose.com/slides/ru/cpp/aspose.slides.charts/ichartdatacell/get_value/) при загрузке презентации, если соответствующие данные диаграммы не были изменены.

После изменения входных ячеек или формул не полагайтесь на старый кэшированный результат. Вызовите [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/ru/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/) перед чтением вычисленных значений или сохранением данных диаграммы, от которых они зависят.

Для формул, не входящих в поддерживаемый набор, Aspose.Slides может не суметь разобрать формулу или установить её зависимости. Если рабочая книга была изменена, предыдущий кэшированный результат уже нельзя считать надёжным. В такой ситуации чтение значения ячейки с неподдерживаемыми данными может вызвать [CellUnsupportedDataException](https://reference.aspose.com/slides/ru/cpp/aspose.slides.spreadsheet/cellunsupporteddataexception/).

Если ваша диаграмма использует функции Excel, которые Aspose.Slides не вычисляет, выполните расчёт этих формул с помощью движка электронных таблиц, поддерживающего их, и запишите полученные значения обратно в рабочую книгу диаграммы. Не заменяйте неподдерживаемые формулы «угаданными» значениями.

## **Обработка ошибок формул**

Существует два разных типа проблем.

Формула может быть корректной, но возвращать ошибочный результат электронных таблиц, например `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!` или `#VALUE!`. В этом случае токен ошибки является результатом ячейки и может быть возвращён через [IChartDataCell::get_Value](https://reference.aspose.com/slides/ru/cpp/aspose.slides.charts/ichartdatacell/get_value/).

Формула также может потерпеть неудачу на этапе разбора, ссылки, зависимости или из‑за неподдерживаемых данных. Aspose.Slides предоставляет специфические для электронных таблиц исключения: [CellInvalidFormulaException](https://reference.aspose.com/slides/ru/cpp/aspose.slides.spreadsheet/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/ru/cpp/aspose.slides.spreadsheet/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/ru/cpp/aspose.slides.spreadsheet/cellcircularreferenceexception/) и [CellUnsupportedDataException](https://reference.aspose.com/slides/ru/cpp/aspose.slides.spreadsheet/cellunsupporteddataexception/).

Когда формулы поступают из шаблонов или пользовательского ввода, обрабатывайте эти исключения вокруг пересчёта и доступа к значениям:

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Spreadsheet/CellCircularReferenceException.h>
#include <Spreadsheet/CellInvalidFormulaException.h>
#include <Spreadsheet/CellInvalidReferenceException.h>
#include <Spreadsheet/CellUnsupportedDataException.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Spreadsheet;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 500.0f, 300.0f);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
auto cell = workbook->GetCell(0, u"A2");
cell->set_Formula(u"SUM(B2:B5)");

try
{
    workbook->CalculateFormulas();
    auto value = cell->get_Value();
}
catch (CellInvalidFormulaException&)
{
    // Обработать недопустимую формулу.
}
catch (CellInvalidReferenceException&)
{
    // Обработать недопустимую ссылку на ячейку.
}
catch (CellCircularReferenceException&)
{
    // Обработать циклическую ссылку.
}
catch (CellUnsupportedDataException&)
{
    // Обработать неподдерживаемые данные электронных таблиц.
}
```

## **Практические ограничения**

Поддержка формул в листах диаграмм предназначена для ограниченного подмножества вычислений электронных таблиц, а не для полной совместимости с Excel. Учтите эти ограничения при проектировании рабочего процесса отчётности:

- Используйте только документированные константы, операторы, ссылки и функции, если требуется, чтобы Aspose.Slides пересчитывал формулы.
- Пересчитывайте после изменения ячеек, от которых зависят результаты формул.
- Рассматривайте кэшированные значения из загруженных презентаций как «снимки», а не как замену пересчёту после правок.
- Тестируйте формулы из существующих шаблонов перед тем, как полагаться на их вычисленные значения, особенно если они используют функции, не входящие в список.
- Для формул, требующих полного движка расчётов электронных таблиц, выполните расчёт внешне, а затем обновите рабочую книгу диаграммы полученными значениями.

## **FAQ**

**В чём разница между `set_Formula` и `set_R1C1Formula`?**

[IChartDataCell::set_Formula](https://reference.aspose.com/slides/ru/cpp/aspose.slides.charts/ichartdatacell/set_formula/) сохраняет выражение в стиле A1, например `B2-C2`. [IChartDataCell::set_R1C1Formula](https://reference.aspose.com/slides/ru/cpp/aspose.slides.charts/ichartdatacell/set_r1c1formula/) сохраняет выражение в стиле R1C1, например `RC[-2]-RC[-1]`. Используйте нотацию, которая лучше соответствует тому, как вы генерируете или копируете формулы.

**Нужно ли читать саму ячейку или её значение после расчёта?**

[IChartDataWorkbook::GetCell](https://reference.aspose.com/slides/ru/cpp/aspose.slides.charts/ichartdataworkbook/getcell/) возвращает `IChartDataCell`. Чтобы получить вычисленный результат, читайте значение этой ячейки через [IChartDataCell::get_Value](https://reference.aspose.com/slides/ru/cpp/aspose.slides.charts/ichartdatacell/get_value/) после пересчёта.

**Когда следует вызывать `CalculateFormulas`?**

Вызовите [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/ru/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/) после изменения входных значений или формул и перед тем, как полагаться на вычисленные результаты. Это обновит значения формул, поддерживаемых встроенным оценщиком.

**Поддерживает ли Aspose.Slides каждую функцию Excel?**

Нет. Встроенный оценщик поддерживает только документированный подмножество функций. Функции вне этого набора не следует считать правильно пересчитываемыми. Если требуется полная совместимость с формулами Excel, выполните расчёт с помощью соответствующего движка электронных таблиц и запишите окончательные значения в рабочую книгу диаграммы.

**Что происходит, если загруженная презентация содержит неподдерживаемую формулу?**

Если данные диаграммы не изменялись, в рабочей книге может оставаться ранее вычисленное кэшированное значение. После изменения связанных данных это кэшированное значение может стать недействительным. Доступ к ячейке, формула которой не может быть обработана, может вызвать [CellUnsupportedDataException](https://reference.aspose.com/slides/ru/cpp/aspose.slides.spreadsheet/cellunsupporteddataexception/).

**Являются ли значения ошибок формул теми же, что и исключения C++?**

Нет. Значение вроде `#DIV/0!` — это значение электронных таблиц, полученное в результате корректного вычисления. Исключения, такие как [CellInvalidFormulaException](https://reference.aspose.com/slides/ru/cpp/aspose.slides.spreadsheet/cellinvalidformulaexception/) или [CellCircularReferenceException](https://reference.aspose.com/slides/ru/cpp/aspose.slides.spreadsheet/cellcircularreferenceexception/), указывают, что формула не может быть обработана обычным способом.

**Обновляется ли диаграмма автоматически при изменении ячейки‑формулы?**

Серия диаграммы может ссылаться на ячейки рабочей книги. Сначала пересчитайте рабочую книгу, затем сохраните или отобразите презентацию. Если точки данных диаграммы ссылаются на вычисленные ячейки, диаграмма использует обновлённые значения; отдельный метод обновления диаграммы не требуется.

**Могут ли диаграммы использовать внешний файл Excel?**

Да, данные диаграммы можно настроить на использование внешней рабочей книги через API данных диаграммы. Однако описанный в этой статье рабочий процесс расчёта формул относится к рабочей книге данных диаграммы и подмножеству формул, оцениваемому Aspose.Slides. Не следует предполагать, что [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/ru/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/) полностью пересчитывает произвольные формулы во внешнем файле XLSX.

**Можно ли использовать формулы, ссылающиеся на другой лист или рабочую книгу?**

Ссылки в стиле Excel могут присутствовать в рабочих книгах диаграмм, но оценка формул ограничена поддерживаемым парсером и набором функций. Если необходима кросс‑листовая или внешняя ссылка, проверьте точную формулу с вашей версией Aspose.Slides. Для рабочих процессов, требующих широкой совместимости ссылок Excel, выполните расчёт внешне и запишите разрешённые значения обратно в данные диаграммы.

**Должны ли строки формул начинаться с `=`?**

Примеры API Aspose.Slides передают выражения без начального `=`, например `B2-C2` или `SUM(B2:B5)`. Использование такой формы сохраняет согласованность с документированными примерами API.