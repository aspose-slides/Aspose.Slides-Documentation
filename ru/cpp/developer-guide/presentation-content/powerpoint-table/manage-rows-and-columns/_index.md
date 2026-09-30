---
title: Управление строками и столбцами в таблицах PowerPoint с помощью C++
linktitle: Строки и столбцы
type: docs
weight: 20
url: /ru/cpp/manage-rows-and-columns/
keywords:
- строка таблицы
- столбец таблицы
- первая строка
- заголовок таблицы
- клонирование строки
- клонирование столбца
- копировать строку
- копировать столбец
- удаление строки
- удаление столбца
- форматирование текста строки
- форматирование текста столбца
- стиль таблицы
- PowerPoint
- презентация
- C++
- Aspose.Slides
description: "Управляйте строками и столбцами таблиц в PowerPoint с помощью Aspose.Slides для C++ и ускоряйте редактирование презентаций и обновление данных."
---
## **Введение**

Aspose.Slides for C++ позволяет управлять структурой таблиц и их форматированием в презентациях PowerPoint с помощью класса [Table](https://reference.aspose.com/slides/cpp/aspose.slides/table/) и интерфейса [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/). Вы можете пометить строку заголовка, создавать копии или удалять строки и столбцы, а также применять форматирование текста к целой строке или столбцу.

Эта статья объясняет эти операции с примерами на C++. Она также показывает, как получить предустановку стиля таблицы, чтобы её можно было повторно использовать. Индексы строк и столбцов таблицы начинаются с нуля.

## **Управление высотой строки**

Используйте [IRow::set_MinimalHeight](https://reference.aspose.com/slides/cpp/aspose.slides/irow/set_minimalheight/) для установки минимальной высоты строки в пунктах. Это нижний предел, а не фиксированная высота. [IRow::get_Height](https://reference.aspose.com/slides/cpp/aspose.slides/irow/get_height/) возвращает фактическую высоту; это значение нельзя задать напрямую. Доступ к строке осуществляется через [ITable::get_Rows](https://reference.aspose.com/slides/cpp/aspose.slides/itable/get_rows/).

Пример загружает файл [row-height-input.pptx](row-height-input.pptx), в котором первая фигура на первом слайде — таблица. Первая строка начинается с 70 пунктов. Ячейки используют шрифт Arial 18 пунктов, перенос строк и отступы сверху и снизу по 6 пунктов; более длинный текст во втором столбце переносится на несколько строк. Пример увеличивает минимум до 100 пунктов, затем уменьшает его до 20 пунктов, выводит фактическую высоту после каждого изменения и сохраняет оба результата.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/IRow.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"row-height-input.pptx");
auto slide = presentation->get_Slide(0);

auto table = ExplicitCast<ITable>(slide->get_Shape(0));
auto row = table->get_Rows()->idx_get(0);

row->set_MinimalHeight(100);
Console::WriteLine(u"Increased: minimum = {0:F1}, actual = {1:F1} pt", row->get_MinimalHeight(), row->get_Height());
presentation->Save(u"row-height-increased.pptx", SaveFormat::Pptx);

row->set_MinimalHeight(20);
Console::WriteLine(u"Decreased: minimum = {0:F1}, actual = {1:F1} pt", row->get_MinimalHeight(), row->get_Height());
presentation->Save(u"row-height-decreased.pptx", SaveFormat::Pptx);
```

При работе с предоставленной презентацией увеличение минимума добавляет пространство к строке. Уменьшение убирает это дополнительное пространство, но фактическая высота остаётся больше 20 пунктов, потому что текст и отступы ячеек требуют больше места. Сократить минимум невозможно, если этого места недостаточно для содержимого строки.

Несколько факторов влияют на фактическую высоту:

- **Текст и размер шрифта:** более длинный текст, явные разрывы строк или больший шрифт требуют больше вертикального пространства.
- **Перенос и ширина столбца:** при включённом переносе уменьшение ширины столбца с помощью [IColumn::set_Width](https://reference.aspose.com/slides/cpp/aspose.slides/icolumn/set_width/) может привести к появлению новых строк. Более широкий столбец может уменьшить требуемое вертикальное пространство.
- **Отступы ячеек:** [ICell::set_MarginTop](https://reference.aspose.com/slides/cpp/aspose.slides/icell/set_margintop/) и [ICell::set_MarginBottom](https://reference.aspose.com/slides/cpp/aspose.slides/icell/set_marginbottom/) управляют отступами, которые добавляют вертикальное пространство. [ICell::set_MarginLeft](https://reference.aspose.com/slides/cpp/aspose.slides/icell/set_marginleft/) и [ICell::set_MarginRight](https://reference.aspose.com/slides/cpp/aspose.slides/icell/set_marginright/) контролируют отступы, уменьшающие доступную ширину для текста и вызывающие дополнительный перенос.

Для этой таблицы без объединённых ячеек ячейка, которая требует наибольшего вертикального пространства, определяет нижний предел для всей строки. Чтобы сделать строку короче, возможно, придётся сократить текст, уменьшить размер шрифта или отступы, либо увеличить ширину столбца.

Изображения ниже показывают одну и ту же таблицу в одинаковом масштабе. В показе .NET фактические высоты составили 70, 100 и 55,2 пункта: последняя строка осталась выше своего минимума в 20 пунктов. Точные измерения текста могут различаться в зависимости от доступных в вашей системе шрифтов. Скачайте сохранённые результаты: [increased minimum](row-height-increased.pptx) и [decreased minimum](row-height-decreased.pptx).

| Исходный: минимум 70 пт, фактическая высота 70 пт | Увеличенный: минимум 100 пт, фактическая высота 100 пт | Уменьшенный: минимум 20 пт, фактическая высота 55,2 пт |
| --- | --- | --- |
| ![Исходная таблица с первой строкой 70 пунктов.](row-height-before.png) | ![Таблица после увеличения минимума первой строки до 100 пунктов.](row-height-increased.png) | ![Таблица после уменьшения минимума первой строки до 20 пунктов; перенос текста удерживает строку выше минимума.](row-height-decreased.png) |

## **Установить первую строку как заголовок**

Используйте метод [set_FirstRow](https://reference.aspose.com/slides/cpp/aspose.slides/itable/set_firstrow/) для пометки первой строки как заголовочной. Её внешний вид зависит от стиля таблицы, применённого к таблице.

1. Загрузите презентацию с помощью класса [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Получите доступ к первому слайду.
3. Получите доступ к таблице, хранящейся как первая фигура на слайде.
4. Включите форматирование заголовка для её первой строки.
5. Сохраните изменённую презентацию.

Для примера требуется файл `table.pptx` с таблицей в первой фигуре на первом слайде. Он включает форматирование заголовка для первой строки и сохраняет файл `First_row_header.pptx`.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"table.pptx");
auto slide = presentation->get_Slide(0);

auto table = ExplicitCast<ITable>(slide->get_Shape(0));
table->set_FirstRow(true);

presentation->Save(u"First_row_header.pptx", SaveFormat::Pptx);
```

## **Клонировать строку или столбец таблицы**

Клонируйте строки или столбцы, чтобы повторно использовать их содержимое и форматирование. Вы можете добавить копию в конец таблицы или вставить её в определённую позицию.

1. Загрузите презентацию с помощью класса [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Получите доступ к первому слайду.
3. Определите ширины столбцов и высоты строк.
4. Добавьте таблицу с помощью метода [AddTable](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addtable/).
5. Клонируйте необходимые строки.
6. Клонируйте необходимые столбцы.
7. Сохраните изменённую презентацию.

Для примера требуется файл `Test.pptx` с хотя бы одним слайдом. Он создаёт таблицу из трёх столбцов и пяти строк, размеры задаются в пунктах. Затем добавляет копии первой строки и первого столбца, после чего вставляет копии второй строки и второго столбца на индекс 3 (четвёртая позиция). Итоговая таблица содержит семь строк и пять столбцов. Параметр `false` отключает клонирование в соседние объединённые строки или столбцы; в этой таблице нет объединённых ячеек.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/IColumnCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Table/ICell.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Test.pptx");
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({ 50, 50, 50 });
auto rowHeights = MakeArray<double>({ 50, 30, 30, 30, 30 });
auto table = slide->get_Shapes()->AddTable(100, 50, columnWidths, rowHeights);

table->idx_get(0, 0)->get_TextFrame()->set_Text(u"Row 1 Cell 1");
table->idx_get(1, 0)->get_TextFrame()->set_Text(u"Row 1 Cell 2");
table->get_Rows()->AddClone(table->get_Rows()->idx_get(0), false);

table->idx_get(0, 1)->get_TextFrame()->set_Text(u"Row 2 Cell 1");
table->idx_get(1, 1)->get_TextFrame()->set_Text(u"Row 2 Cell 2");
table->get_Rows()->InsertClone(3, table->get_Rows()->idx_get(1), false);

table->get_Columns()->AddClone(table->get_Columns()->idx_get(0), false);
table->get_Columns()->InsertClone(3, table->get_Columns()->idx_get(1), false);

presentation->Save(u"table_out.pptx", SaveFormat::Pptx);
```

## **Удалить строку или столбец из таблицы**

Удалите строки или столбцы, которые больше не нужны в таблице. При удалении элемент смещает индексы последующих строк или столбцов.

1. Создайте презентацию с помощью класса [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Получите доступ к первому слайду.
3. Определите ширины столбцов и высоты строк.
4. Добавьте таблицу методом [AddTable](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addtable/).
5. Удалите вторую строку и второй столбец.
6. Сохраните изменённую презентацию.

Этот пример создаёт таблицу 3×3 и удаляет строку и столбец с индексом 1, оставляя таблицу 2×2 в файле `TestTable_out.pptx`. Размеры задаются в пунктах. Параметр `false` отключает удаление соседних объединённых строк или столбцов; в этой таблице нет объединённых ячеек.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/IColumnCollection.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({ 100, 50, 30 });
auto rowHeights = MakeArray<double>({ 30, 50, 30 });
auto table = slide->get_Shapes()->AddTable(100, 100, columnWidths, rowHeights);

table->get_Rows()->RemoveAt(1, false);
table->get_Columns()->RemoveAt(1, false);

presentation->Save(u"TestTable_out.pptx", SaveFormat::Pptx);
```

## **Установить форматирование текста на уровне строк таблицы**

Примените форматирование текста ко всей строке, чтобы ячейки были согласованы. Вы можете задать свойства шрифта, параметры абзаца и направление текста без необходимости форматировать каждую ячейку отдельно.

1. Загрузите презентацию с помощью класса [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Получите доступ к таблице на первом слайде.
3. Установите высоту шрифта с помощью [set_FontHeight](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_fontheight/) для первой строки.
4. Задайте выравнивание и правый отступ абзаца с помощью [set_Alignment](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_alignment/) и [set_MarginRight](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_marginright/) для первой строки.
5. Установите направление текста с помощью [set_TextVerticalType](https://reference.aspose.com/slides/cpp/aspose.slides/textframeformat/set_textverticaltype/) для второй строки.
6. Сохраните изменённую презентацию.

Для примера требуется файл `table.pptx` с таблицей в первой фигуре на первом слайде и как минимум двумя строками. Он применяет текст размером 25 пунктов, выравнивание по правому краю и правый отступ абзаца в 20 пунктов к первой строке, затем задаёт вертикальный текст во второй строке.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/PortionFormat.h>
#include <DOM/ParagraphFormat.h>
#include <DOM/TextAlignment.h>
#include <DOM/TextFrameFormat.h>
#include <DOM/TextVerticalType.h>
#include <DOM/Table/IRow.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"table.pptx");
auto slide = presentation->get_Slide(0);

auto table = ExplicitCast<ITable>(slide->get_Shape(0));

auto portionFormat = MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25);
table->get_Rows()->idx_get(0)->SetTextFormat(portionFormat);

auto paragraphFormat = MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20);
table->get_Rows()->idx_get(0)->SetTextFormat(paragraphFormat);

auto textFrameFormat = MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
table->get_Rows()->idx_get(1)->SetTextFormat(textFrameFormat);

presentation->Save(u"row_formatting.pptx", SaveFormat::Pptx);
```

## **Установить форматирование текста на уровне столбцов таблицы**

Примените форматирование текста ко всему столбцу, чтобы ячейки были согласованы. Вы можете задать свойства шрифта, параметры абзаца и направление текста без необходимости форматировать каждую ячейку отдельно.

1. Загрузите презентацию с помощью класса [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Получите доступ к таблице на первом слайде.
3. Установите высоту шрифта с помощью [set_FontHeight](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_fontheight/) для первого столбца.
4. Задайте выравнивание и правый отступ абзаца с помощью [set_Alignment](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_alignment/) и [set_MarginRight](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_marginright/) для первого столбца.
5. Установите направление текста с помощью [set_TextVerticalType](https://reference.aspose.com/slides/cpp/aspose.slides/textframeformat/set_textverticaltype/) для второго столбца.
6. Сохраните изменённую презентацию.

Для примера требуется файл `table.pptx` с таблицей в первой фигуре на первом слайде и как минимум двумя столбцами. Он применяет текст размером 25 пунктов, выравнивание по правому краю и правый отступ абзаца в 20 пунктов к первому столбцу, затем задаёт вертикальный текст во втором столбце.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <DOM/Table/IColumnCollection.h>
#include <DOM/PortionFormat.h>
#include <DOM/ParagraphFormat.h>
#include <DOM/TextAlignment.h>
#include <DOM/TextFrameFormat.h>
#include <DOM/TextVerticalType.h>
#include <DOM/Table/IColumn.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"table.pptx");
auto slide = presentation->get_Slide(0);

auto table = ExplicitCast<ITable>(slide->get_Shape(0));

auto portionFormat = MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25);
table->get_Columns()->idx_get(0)->SetTextFormat(portionFormat);

auto paragraphFormat = MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20);
table->get_Columns()->idx_get(0)->SetTextFormat(paragraphFormat);

auto textFrameFormat = MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
table->get_Columns()->idx_get(1)->SetTextFormat(textFrameFormat);

presentation->Save(u"column_formatting.pptx", SaveFormat::Pptx);
```

## **Получить свойства стиля таблицы**

Используйте метод [get_StylePreset](https://reference.aspose.com/slides/cpp/aspose.slides/itable/get_stylepreset/) для получения предустановки, применённой к таблице, и повторного её использования в другой таблице. Это позволяет идентифицировать предустановку, а не отдельные переопределения форматирования ячеек.

Пример создаёт таблицу, применяет [TableStylePreset::DarkStyle1](https://reference.aspose.com/slides/cpp/aspose.slides/tablestylepreset/), а затем считывает предустановку обратно. Он выводит `DarkStyle1` и сохраняет таблицу в файле `table.pptx`.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/console.h>
#include <DOM/TableStylePreset.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({ 100, 150 });
auto rowHeights = MakeArray<double>({ 5, 5, 5 });
auto table = slide->get_Shapes()->AddTable(10, 10, columnWidths, rowHeights);
table->set_StylePreset(TableStylePreset::DarkStyle1);

Console::WriteLine(u"{0}", table->get_StylePreset());

presentation->Save(u"table.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Можно ли применить темы/стили PowerPoint к уже созданной таблице?**

Да. Таблица наследует тему слайда/макета/шаблона, и вы всё равно можете переопределять заливки, границы и цвета текста поверх этой темы.

**Можно ли сортировать строки таблицы, как в Excel?**

Нет, таблицы Aspose.Slides не имеют встроенной сортировки или фильтров. Сначала отсортируйте данные в памяти, а затем заполните строки таблицы в нужном порядке.

**Можно ли задать чередующиеся (полосатые) столбцы, сохранив пользовательские цвета в определённых ячейках?**

Да. Включите чередующиеся столбцы, затем переопределите отдельные ячейки локальным форматированием; форматирование уровня ячейки имеет приоритет перед стилем таблицы.