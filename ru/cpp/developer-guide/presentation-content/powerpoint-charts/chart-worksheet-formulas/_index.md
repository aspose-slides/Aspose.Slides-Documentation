---
title: Применение формул листов диаграмм в презентациях с использованием C++
linktitle: Формулы листа
type: docs
weight: 70
url: /ru/cpp/chart-worksheet-formulas/
keywords:
- таблица диаграммы
- лист диаграммы
- формула диаграммы
- формула листа
- формула таблицы
- рабочая книга данных диаграммы
- вычисление формулы
- предпочтительная культура
- культура-специфическая формула
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
- C++
- Aspose.Slides
description: "Применяйте формулы в стиле Excel в листах диаграмм Aspose.Slides для C++, пересчитывайте значения и используйте результаты в диаграммах PowerPoint."
---
## **Обзор**

Диаграммы PowerPoint обычно хранят исходные данные во встраиваемой таблице. В Aspose.Slides для C++ вы можете получить доступ к этой таблице через рабочую книгу данных диаграммы, записывать входные значения, назначать формулы ячейкам, вычислять поддерживаемые формулы и использовать вычисленные ячейки в качестве данных диаграммы.

В этой статье объясняется полный рабочий процесс формул: создание диаграммы, заполнение её таблицы, назначение формул в стиле A1 или R1C1, их перевычисление, чтение вычисленных значений, привязка этих ячеек к серии диаграммы и сохранение презентации. Также описываются поддерживаемый синтаксис формул, встроенный набор функций, кэшированные значения, неподдерживаемые формулы и ошибки, специфичные для таблиц.

## **Листы данных диаграммы и формулы**

Лист данных диаграммы содержит категории, имена серий и значения, используемые в диаграмме. В PowerPoint можно просмотреть лист, открыв редактор данных диаграммы:

![Диаграмма PowerPoint с открытой встраиваемой таблицей, показывающая данные категорий и серий](chart-worksheet-formulas_1.png)

В Aspose.Slides лист данных раскрывается через интерфейс [IChartDataWorkbook](https://reference.aspose.com/slides/ru/cpp/aspose.slides.charts/ichartdataworkbook/). Используйте [IChartDataCell::set_Formula](https://reference.aspose.com/slides/ru/cpp/aspose.slides.charts/ichartdatacell/set_formula/) для формул в стиле A1 и [IChartDataCell::set_R1C1Formula](https://reference.aspose.com/slides/ru/cpp/aspose.slides.charts/ichartdatacell/set_r1c1formula/) для формул в стиле R1C1. После изменения входных ячеек или формул вызовите [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/ru/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/), чтобы перевычислить поддерживаемые формулы и обновить соответствующие значения ячеек.

Вычисленная ячейка всё ещё предоставляет свой результат через [IChartDataCell::get_Value](https://reference.aspose.com/slides/ru/cpp/aspose.slides.charts/ichartdatacell/get_value/). Это важно, когда нужно проверить результат формулы в коде или использовать ячейку как точку данных диаграммы.

## **Создание диаграммы и вычисление формул листа**

Следующий пример демонстрирует сквозной рабочий процесс. Он создаёт сгруппированную столбчатую диаграмму, очищает образцы данных, записывает квартальные значения доходов и расходов, вычисляет прибыль с помощью формул, читает результаты, использует вычисленные ячейки как значения диаграммы и сохраняет презентацию.

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

Точки данных диаграммы ссылаются на `D2:D4`, поэтому диаграмма использует вычисленные значения прибыли. В этом рабочем процессе нет отдельного вызова обновления диаграммы: сначала перевычислите рабочую книгу, затем используйте или сохраните данные диаграммы, указывающие на вычисленные ячейки.

## **Использование формул в стиле A1**

A1‑нотация идентифицирует столбцы буквами, а строки цифрами. Назначайте выражения в стиле A1 через [IChartDataCell::set_Formula](https://reference.aspose.com/slides/ru/cpp/aspose.slides.charts/ichartdatacell/set_formula/).

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

Относительные ссылки могут изменяться при перемещении или копировании формулы в приложении таблиц. Абсолютные ссылки фиксируют обе координаты, а смешанные фиксируют только строку или только столбец.

## **Использование формул в стиле R1C1**

R1C1‑нотация идентифицирует как строки, так и столбцы численно. Относительные ссылки используют смещения в квадратных скобках. Назначайте эту нотацию через [IChartDataCell::set_R1C1Formula](https://reference.aspose.com/slides/ru/cpp/aspose.slides.charts/ichartdatacell/set_r1c1formula/).

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

Например, в ячейке `D2` выражение `RC[-2]` означает ячейку в той же строке на две колонки влево (`B2`).

## **Константы и операторы формул**

Встроенный Evaluator формул поддерживает логические значения, числовые литералы, строки, значения ошибок таблиц, арифметические операторы и операторы сравнения.

### **Константы и литералы**

| Тип | Примеры | Примечания |
|---|---|---|
| Логический | `TRUE`, `FALSE` | Может использоваться непосредственно в логических выражениях, например `A2=TRUE`. |
| Числовой | `1`, `0.5`, `.3`, `1E-2` | Поддерживаются обычная и научная запись. |
| Строковый | `"abc"`, `"2/3/2020 12:00"` | Текстовые литералы заключаются в двойные кавычки внутри формулы. |
| Результат ошибки | `#DIV/0!`, `#N/A`, `#REF!` | Валидная формула может возвращать значение ошибки таблицы вместо обычного результата. |

Этот пример использует несколько типов констант:

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

auto logicalValue = workbook->GetCell(0, u"B2")->get_Value(); // Ложно
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

Aspose.Slides включает встроенный Evaluator формул для листов диаграмм, но это не полноценный движок вычислений Excel. Документированный набор функций ограничен нижеуказанными. Не следует предполагать, что произвольная функция Excel может быть перевычислена методом [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/ru/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/).

| Функция | Назначение или поддерживаемая форма | Пример |
|---|---|---|
| `ABS` | Абсолютное значение | `ABS(A2)` |
| `AVERAGE` | Среднее арифметическое | `AVERAGE(B2:B5)` |
| `CEILING` | Округление числа вверх до кратного | `CEILING(A2,5)` |
| `CHOOSE` | Выбор значения по индексу | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | Объединение текстовых значений | `CONCAT(A2,B2)` |
| `CONCATENATE` | Объединение текстовых значений | `CONCATENATE(A2," ",B2)` |
| `DATE` | Создание значения даты с использованием системы 1900 года | `DATE(2026,8,19)` |
| `DAYS` | Возвращает число дней между датами | `DAYS(B2,A2)` |
| `FIND` | Поиск одной текстовой строки внутри другой | `FIND("-",A2)` |
| `FINDB` | Поиск текста по байтам | `FINDB("a",A2)` |
| `IF` | Условный результат | `IF(A2>0,A2,0)` |
| `INDEX` | Ссылка в виде формы | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | Векторная форма | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | Векторная форма | `MATCH(A2,B2:B5,0)` |
| `MAX` | Максимальное значение | `MAX(B2:B5)` |
| `SUM` | Сумма значений | `SUM(B2:B5)` |
| `VLOOKUP` | Вертикальный поиск | `VLOOKUP(A2,B2:D10,3,FALSE)` |

Ограничения, указанные в таблице, существенны: `INDEX` документируется в виде ссылки, тогда как `LOOKUP` и `MATCH` — в их векторных формах. `DATE` использует систему 1900 года. Функции и возможности, не перечисленные здесь, следует считать неподдерживаемыми Evaluator формул Aspose.Slides, если они не задокументированы отдельно.

## **Вычисление формул с предпочтительной культурой**

Некоторые функции рабочей книги диаграмм интерпретируют текст согласно правилам конкретной культуры. Это особенно важно для функций, предназначенных для языков, использующих двойные байтовые наборы символов (DBCS). Чтобы вычислить такие формулы корректно, создайте [LoadOptions](https://reference.aspose.com/slides/ru/cpp/aspose.slides/loadoptions/), настройте [ISpreadsheetOptions::set_PreferredCulture](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ispreadsheetoptions/set_preferredculture/) через [LoadOptions::set_SpreadsheetOptions](https://reference.aspose.com/slides/ru/cpp/aspose.slides/loadoptions/set_spreadsheetoptions/), а затем загрузите презентацию.

Следующий пример выбирает японскую культуру, открывает презентацию с указанными параметрами загрузки и вызывает [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/ru/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/) для каждой рабочей книги диаграммы:

```cpp
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/IChart.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <DOM/SpreadsheetOptions.h>
#include <system/globalization/culture_info.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;
using namespace System::Globalization;

auto japaneseCulture = CultureInfo::GetCultureInfo(u"ja-JP");

auto spreadsheetOptions = MakeObject<SpreadsheetOptions>();
spreadsheetOptions->set_PreferredCulture(japaneseCulture);

auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_SpreadsheetOptions(spreadsheetOptions);

auto presentation = MakeObject<Presentation>(u"presentation.pptx", loadOptions);

for (int32_t slideIndex = 0; slideIndex < presentation->get_Slides()->get_Count(); slideIndex++)
{
    auto slide = presentation->get_Slide(slideIndex);

    for (int32_t shapeIndex = 0; shapeIndex < slide->get_Shapes()->get_Count(); shapeIndex++)
    {
        auto shape = slide->get_Shape(shapeIndex);
        if (ObjectExt::Is<IChart>(shape))
        {
            auto chart = ExplicitCast<IChart>(shape);
            chart->get_ChartData()->get_ChartDataWorkbook()->CalculateFormulas();
        }
    }
}
```

Предпочтительная культура задаётся в конфигурации загрузки презентации, поэтому укажите её до создания экземпляра [Presentation](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/). Используйте культуру, ожидаемую формулами рабочей книги; например, `ja-JP` для формул, которые должны соблюсти японские правила расчётов DBCS.

## **Перерасчёт и кэшированные значения**

Файлы таблиц обычно хранят как формулу, так и её последнюю вычисленную величину. Aspose.Slides может поэтому считывать кэшированное значение из [IChartDataCell::get_Value](https://reference.aspose.com/slides/ru/cpp/aspose.slides.charts/ichartdatacell/get_value/) при загрузке презентации, если соответствующие данные диаграммы не изменялись.

После изменения входных ячеек или формул не полагайтесь на старый кэшированный результат. Вызовите [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/ru/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/) перед чтением вычисленных значений или перед сохранением данных диаграммы, от которых они зависят.

Для формул за пределами поддерживаемого подмножества Aspose.Slides может не суметь разобрать формулу или определить её зависимости. Если рабочая книга была изменена, прежнее кэшированное значение уже нельзя считать надёжным. В такой ситуации чтение значения ячейки с неподдерживаемыми данными может вызвать [CellUnsupportedDataException](https://reference.aspose.com/slides/ru/cpp/aspose.slides.spreadsheet/cellunsupporteddataexception/).

Если ваша диаграмма опирается на функции Excel, которые Aspose.Slides не умеет вычислять, выполните вычисления внешним движком таблиц и запишите полученные значения обратно в рабочую книгу диаграммы. Не заменяйте неподдерживаемые формулы догадками.

## **Обработка ошибок формул**

Существует два разных типа проблем.

Формула может быть корректной, но вернуть результат ошибки таблицы, например `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!` или `#VALUE!`. В этом случае токен ошибки является результатом ячейки и может быть возвращён через [IChartDataCell::get_Value](https://reference.aspose.com/slides/ru/cpp/aspose.slides.charts/ichartdatacell/get_value/).

Формула также может не пройти разбор, проверку ссылок, зависимостей или поддерживаемых данных. Aspose.Slides предоставляет специфические для таблиц исключения для этих случаев: [CellInvalidFormulaException](https://reference.aspose.com/slides/ru/cpp/aspose.slides.spreadsheet/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/ru/cpp/aspose.slides.spreadsheet/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/ru/cpp/aspose.slides.spreadsheet/cellcircularreferenceexception/), и [CellUnsupportedDataException](https://reference.aspose.com/slides/ru/cpp/aspose.slides.spreadsheet/cellunsupporteddataexception/).

Когда формулы поступают из шаблонов или ввода пользователя, обрабатывайте эти исключения вокруг перевычисления и доступа к значениям:

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
    // Обработать неподдерживаемые данные таблицы.
}
```

## **Практические ограничения**

Поддержка формул в листах диаграмм предназначена для ограниченного подмножества вычислений таблиц, а не для полной совместимости с Excel. Учитывайте эти ограничения при проектировании рабочего процесса отчётности:

- Используйте только документированные константы, операторы, ссылки и функции, когда требуется, чтобы Aspose.Slides перевычислял формулы.
- Перевычисляйте после изменения ячеек, от которых зависят результаты формул.
- Рассматривайте кэшированные значения из загруженных презентаций как моментальные снимки, а не как замену перевычисления после правок.
- Тестируйте формулы из существующих шаблонов перед тем, как полагаться на их вычисленные значения, особенно если они используют функции, не входящие в документированный список.
- Для формул, требующих полного движка расчётов таблиц, вычисляйте их внешне, а затем обновляйте лист данных диаграммы полученными значениями.

## **Вопросы и ответы**

**В чём разница между `set_Formula` и `set_R1C1Formula`?**

[IChartDataCell::set_Formula](https://reference.aspose.com/slides/ru/cpp/aspose.slides.charts/ichartdatacell/set_formula/) сохраняет выражение в стиле A1, например `B2-C2`. [IChartDataCell::set_R1C1Formula](https://reference.aspose.com/slides/ru/cpp/aspose.slides.charts/ichartdatacell/set_r1c1formula/) сохраняет выражение в стиле R1C1, например `RC[-2]-RC[-1]`. Используйте нотацию, которая лучше соответствует способу генерации или копирования формул.

**Нужно ли читать саму ячейку или её значение после вычисления?**

[IChartDataWorkbook::GetCell](https://reference.aspose.com/slides/ru/cpp/aspose.slides.charts/ichartdataworkbook/getcell/) возвращает `IChartDataCell`. Чтобы получить вычисленный результат, прочитайте значение этой ячейки через [IChartDataCell::get_Value](https://reference.aspose.com/slides/ru/cpp/aspose.slides.charts/ichartdatacell/get_value/) после перевычисления.

**Когда следует вызывать `CalculateFormulas`?**

Вызывайте [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/ru/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/) после изменения входных значений или формул и перед тем, как зависеть от вычисленных результатов. Это обновит значения формул, которые поддерживает встроенный Evaluator.

**Поддерживает ли Aspose.Slides каждую функцию Excel?**

Нет. Встроенный Evaluator поддерживает только документированное подмножество функций. Функции вне этого набора не следует считать перевычисляемыми корректно. Если требуется полная совместимость с формулами Excel, выполните расчёт с соответствующим движком таблиц и запишите финальные значения в рабочую книгу диаграммы.

**Что происходит, если загруженная презентация содержит неподдерживаемую формулу?**

Если данные диаграммы не менялись, в рабочей книге может всё ещё находиться ранее вычисленное кэшированное значение. После изменения связанных данных это кэшированное значение может стать недействительным. Доступ к ячейке, чью формулу нельзя обработать, может вызвать [CellUnsupportedDataException](https://reference.aspose.com/slides/ru/cpp/aspose.slides.spreadsheet/cellunsupporteddataexception/).

**Являются ли значения ошибок формул тем же, что и исключения C++?**

Нет. Значение вроде `#DIV/0!` — это значение ячейки, полученное в результате валидного вычисления. Исключения, такие как [CellInvalidFormulaException](https://reference.aspose.com/slides/ru/cpp/aspose.slides.spreadsheet/cellinvalidformulaexception/) или [CellCircularReferenceException](https://reference.aspose.com/slides/ru/cpp/aspose.slides.spreadsheet/cellcircularreferenceexception/), указывают, что формулу нельзя обработать обычным способом.

**Обновляется ли диаграмма автоматически, когда меняется ячейка с формулой?**

Серии диаграммы могут ссылаться на ячейки рабочей книги. Сначала перевычислите рабочую книгу, затем сохраните или отрендерите презентацию. Если точки данных диаграммы ссылаются на вычисленные ячейки, диаграмма использует обновленные значения; отдельный метод обновления диаграммы не требуется.

**Можно ли использовать внешнюю книгу Excel для данных диаграммы?**

Да, данные диаграммы можно настроить на использование внешней книги через API данных диаграммы. Однако описанный в этой статье рабочий процесс вычисления формул относится к рабочей книге данных диаграммы и подмножеству формул, поддерживаемому Aspose.Slides. Не следует предполагать, что [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/ru/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/) полностью перевычислит произвольные формулы во внешнем файле XLSX.

**Могу ли я использовать формулы, которые ссылаются на другой лист или книгу?**

Ссылки в стиле Excel могут присутствовать в рабочих книгах диаграмм, но их оценка ограничена поддерживаемым парсером и набором функций. Если кросс‑листовая или внешняя ссылка критична, проверьте её работу с конкретной версией Aspose.Slides. Для сценариев, требующих широкой совместимости ссылок Excel, вычисляйте рабочую книгу внешне и запишите разрешённые значения обратно в данные диаграммы.

**Должны ли строковые представления формул начинаться с `=`?**

Примеры API Aspose.Slides задают выражения без ведущего `=`, например `B2-C2` или `SUM(B2:B5)`. Такой формат сохраняет согласованность с документированными примерами API.