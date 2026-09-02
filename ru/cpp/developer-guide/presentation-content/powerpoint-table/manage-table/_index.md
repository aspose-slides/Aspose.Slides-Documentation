---
title: Управление таблицами презентаций на C++
linktitle: Управление таблицей
type: docs
weight: 10
url: /ru/cpp/manage-table/
keywords:
- добавить таблицу
- создать таблицу
- доступ к таблице
- соотношение сторон
- выравнивание текста
- форматирование текста
- стиль таблицы
- PowerPoint
- презентация
- C++
- Aspose.Slides
description: "Создавайте и редактируйте таблицы в слайдах PowerPoint с помощью Aspose.Slides для C++. Откройте простые примеры кода для оптимизации работы с таблицами."
---
## **Введение**

Таблица в PowerPoint – эффективный способ отображения и представления информации. Информация в сетке ячеек (расположенных в строках и столбцах) проста и легко воспринимается.

Aspose.Slides предоставляет класс [Table](https://reference.aspose.com/slides/ru/cpp/aspose.slides/table/) , интерфейс [ITable](https://reference.aspose.com/slides/ru/cpp/aspose.slides/itable/) , класс [Cell](https://reference.aspose.com/slides/ru/cpp/aspose.slides/cell/) , интерфейс [ICell](https://reference.aspose.com/slides/ru/cpp/aspose.slides/icell/) и другие типы, позволяющие создавать, обновлять и управлять таблицами во всех типах презентаций. 

## **Создать таблицу с нуля**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/) .
2. Получите ссылку на слайд по его индексу. 
3. Определите массив `columnWidth`.
4. Определите массив `rowHeight`.
5. Добавьте объект [ITable](https://reference.aspose.com/slides/ru/cpp/aspose.slides/itable/) на слайд с помощью метода [AddTable()](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ishapecollection/addtable/) .
6. Пройдитесь по каждому [ICell](https://reference.aspose.com/slides/ru/cpp/aspose.slides/icell/) , чтобы применить форматирование к верхней, нижней, правой и левой границам.
7. Объедините первые две ячейки первой строки таблицы. 
8. Получите доступ к [TextFrame](https://reference.aspose.com/slides/ru/cpp/aspose.slides/textframe/) ячейки [ICell](https://reference.aspose.com/slides/ru/cpp/aspose.slides/icell/) .
9. Добавьте некоторый текст в [TextFrame](https://reference.aspose.com/slides/ru/cpp/aspose.slides/textframe/) .
10. Сохраните изменённую презентацию.

Этот код на C++ показывает, как создать таблицу в презентации:

```c++
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ICell.h>
#include <DOM/Table/ICellFormat.h>
#include <DOM/Table/IRow.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

// Создаёт объект класса Presentation, представляющий файл PPTX
auto pres = System::MakeObject<Presentation>();

// Получает первый слайд
auto sld = pres->get_Slides()->idx_get(0);

// Определяет столбцы с ширинами и строки с высотами
auto dblCols = System::MakeArray<double>({ 50, 50, 50 });
auto dblRows = System::MakeArray<double>({ 50, 30, 30, 30, 30 });

// Добавляет форму таблицы на слайд
auto tbl = sld->get_Shapes()->AddTable(100.0f, 50.0f, dblCols, dblRows);

// Устанавливает формат границы для каждой ячейки
for (int32_t row = 0; row < tbl->get_Rows()->get_Count(); row++)
{
    for (int32_t cell = 0; cell < tbl->get_Rows()->idx_get(row)->get_Count(); cell++)
    {
        auto cellFormat = tbl->get_Rows()->idx_get(row)->idx_get(cell)->get_CellFormat();

        cellFormat->get_BorderTop()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderTop()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderTop()->set_Width(5);

        cellFormat->get_BorderBottom()->get_FillFormat()->set_FillType((FillType::Solid));
        cellFormat->get_BorderBottom()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderBottom()->set_Width(5);

        cellFormat->get_BorderLeft()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderLeft()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderLeft()->set_Width(5);

        cellFormat->get_BorderRight()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderRight()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderRight()->set_Width(5);
    }
}
// Объединяет ячейки 1 и 2 первой строки
tbl->MergeCells(tbl->get_Rows()->idx_get(0)->idx_get(0), tbl->get_Rows()->idx_get(1)->idx_get(1), false);

// Добавляет текст в объединённую ячейку
tbl->get_Rows()->idx_get(0)->idx_get(0)->get_TextFrame()->set_Text(u"Merged Cells");

// Сохраняет презентацию на диск
pres->Save(u"table.pptx", SaveFormat::Pptx);
```

## **Нумерация в стандартной таблице**

В стандартной таблице нумерация ячеек проста и начинается с нуля. Первая ячейка в таблице имеет индекс 0,0 (столбец 0, строка 0). 

Например, ячейки таблицы с 4 столбцами и 4 строками нумеруются следующим образом:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Этот код на C++ показывает, как указать нумерацию ячеек в таблице:

```c++
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ICell.h>
#include <DOM/Table/ICellFormat.h>
#include <DOM/Table/IRow.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

// Создаёт объект класса Presentation, представляющий файл PPTX
auto pres = System::MakeObject<Presentation>();

// Получает первый слайд
auto sld = pres->get_Slides()->idx_get(0);

// Определяет столбцы с ширинами и строки с высотами
auto dblCols = System::MakeArray<double>({ 70, 70, 70, 70 });
auto dblRows = System::MakeArray<double>({ 70, 70, 70, 70 });

// Добавляет форму таблицы на слайд
auto tbl = sld->get_Shapes()->AddTable(100.0f, 50.0f, dblCols, dblRows);

// Устанавливает формат границы для каждой ячейки
for (const auto& row : tbl->get_Rows())
{
    for (const auto& cell : row)
    {
        auto cellFormat = cell->get_CellFormat();
        cellFormat->get_BorderTop()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderTop()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderTop()->set_Width(5);

        cellFormat->get_BorderBottom()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderBottom()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderBottom()->set_Width(5);

        cellFormat->get_BorderLeft()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderLeft()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderLeft()->set_Width(5);

        cellFormat->get_BorderRight()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderRight()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderRight()->set_Width(5);
    }
}

// Сохраняет презентацию на диск
pres->Save(u"StandardTables_out.pptx", SaveFormat::Pptx);
```

## **Доступ к существующей таблице**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/) .
2. Получите ссылку на слайд, содержащий таблицу, по его индексу. 
3. Создайте объект [ITable](https://reference.aspose.com/slides/ru/cpp/aspose.slides/itable/) и установите его в null.
4. Пройдитесь по всем объектам [IShape](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ishape/) до тех пор, пока не найдёте таблицу. 

Если вы подозреваете, что рассматриваемый слайд содержит единственную таблицу, можно просто проверить все содержащиеся в нём фигуры. Когда фигура идентифицируется как таблица, её можно привести к объекту [Table](https://reference.aspose.com/slides/ru/cpp/aspose.slides/table/) . Однако если слайд содержит несколько таблиц, лучше искать нужную таблицу по её методу [set_AlternativeText()](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ishape/set_alternativetext/) .

5. Используйте объект [ITable] для работы с таблицей. В приведённом ниже примере мы добавили новую строку в таблицу.
6. Сохраните изменённую презентацию.

Этот код на C++ показывает, как получить доступ к существующей таблице и работать с ней:

```c++
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ICell.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

// Создаёт объект класса Presentation, представляющий файл PPTX
auto pres = System::MakeObject<Presentation>(u"UpdateExistingTable.pptx");

// Получает первый слайд
auto sld = pres->get_Slides()->idx_get(0);

// Инициализирует пустую таблицу
System::SharedPtr<ITable> tbl;

// Перебирает фигуры и сохраняет ссылку на найденную таблицу
for (const auto& shp : System::IterateOver(sld->get_Shapes()))
{
    if (System::ObjectExt::Is<ITable>(shp))
    {
        tbl = System::ExplicitCast<ITable>(shp);
    }
}

// Устанавливает текст для первого столбца второй строки
tbl->idx_get(0, 1)->get_TextFrame()->set_Text(u"New");

// Сохраняет изменённую презентацию на диск
pres->Save(u"table1_out.pptx", SaveFormat::Pptx);
```

## **Найти ячейку, владеющую текстовым фреймом**

Когда общий код обработки текста получает объект [ITextFrame](https://reference.aspose.com/slides/ru/cpp/aspose.slides/itextframe/) из таблицы, используйте [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/ru/cpp/aspose.slides/itextframe/get_parentcell/) для получения владеющей [ICell](https://reference.aspose.com/slides/ru/cpp/aspose.slides/icell/) . Для текстового фрейма ячейки таблицы [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/ru/cpp/aspose.slides/itextframe/get_parentcell/) возвращает владельца, а [ITextFrame::get_ParentShape](https://reference.aspose.com/slides/ru/cpp/aspose.slides/itextframe/get_parentshape/) возвращает `nullptr`, хотя сама таблица является фигурой.

Координаты ячейки доступны через методы только для чтения [ICell::get_FirstColumnIndex](https://reference.aspose.com/slides/ru/cpp/aspose.slides/icell/get_firstcolumnindex/) и [ICell::get_FirstRowIndex](https://reference.aspose.com/slides/ru/cpp/aspose.slides/icell/get_firstrowindex/) . [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/ru/cpp/aspose.slides/itextframe/get_parentcell/) также предоставляет навигацию только для чтения: он возвращает владельца, но не меняет владения. Всегда проверяйте полученную ячейку на `nullptr` перед её использованием.

Полный пример, который определяет владельцев ячеек таблицы и фигур, включая фигуры, связанные с узлами SmartArt, смотрите в разделе [Search and Replace Text](/slides/ru/cpp/search-and-replace-text/) .

## **Выравнивание текста в таблице**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/) .
2. Получите ссылку на слайд по его индексу. 
3. Добавьте объект [ITable](https://reference.aspose.com/slides/ru/cpp/aspose.slides/itable/) на слайд. 
4. Получите объект [ITextFrame](https://reference.aspose.com/slides/ru/cpp/aspose.slides/itextframe/) из таблицы. 
5. Получите [IParagraph](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iparagraph/) из [ITextFrame](https://reference.aspose.com/slides/ru/cpp/aspose.slides/itextframe/) .
6. Выравняйте текст по вертикали.
7. Сохраните изменённую презентацию.

Этот код на C++ показывает, как выровнять текст в таблице:

```c++
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ICell.h>
#include <DOM/Table/ITable.h>
#include <DOM/TextAnchorType.h>
#include <DOM/TextVerticalType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

// Создаёт экземпляр класса Presentation
auto presentation = System::MakeObject<Presentation>();

// Получает первый слайд
auto slide = presentation->get_Slides()->idx_get(0);

// Определяет столбцы с ширинами и строки с высотами
auto dblCols = System::MakeArray<double>({ 120, 120, 120, 120 });
auto dblRows = System::MakeArray<double>({ 100, 100, 100, 100 });

// Добавляет форму таблицы на слайд
auto tbl = slide->get_Shapes()->AddTable(100.0f, 50.0f, dblCols, dblRows);
tbl->idx_get(1, 0)->get_TextFrame()->set_Text(u"10");
tbl->idx_get(2, 0)->get_TextFrame()->set_Text(u"20");
tbl->idx_get(3, 0)->get_TextFrame()->set_Text(u"30");

// Получает доступ к текстовому фрейму
auto txtFrame = tbl->idx_get(0, 0)->get_TextFrame();

// Создаёт объект Paragraph для текстового фрейма
auto paragraph = txtFrame->get_Paragraphs()->idx_get(0);

// Создаёт объект Portion для абзаца
auto portion = paragraph->get_Portions()->idx_get(0);
portion->set_Text(u"Text here");
portion->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
portion->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

// Выровняет текст по вертикали
auto cell = tbl->idx_get(0, 0);
cell->set_TextAnchorType(TextAnchorType::Center);
cell->set_TextVerticalType(TextVerticalType::Vertical270);

// Сохраняет презентацию на диск
presentation->Save(u"Vertical_Align_Text_out.pptx", SaveFormat::Pptx);
```

## **Установить форматирование текста на уровне таблицы**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/) .
2. Получите ссылку на слайд по его индексу. 
3. Получите объект [ITable](https://reference.aspose.com/slides/ru/cpp/aspose.slides/itable/) со слайда.
4. Установите [set_FontHeight()](https://reference.aspose.com/slides/ru/cpp/aspose.slides/baseportionformat/set_fontheight/) для текста. 
5. Установите [set_Alignment()](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iparagraphformat/set_alignment/) и [set_MarginRight()](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iparagraphformat/set_marginright/) .
6. Установите [set_TextVerticalType()](https://reference.aspose.com/slides/ru/cpp/aspose.slides/textframeformat/set_textverticaltype/) .
7. Сохраните изменённую презентацию. 

Этот код на C++ показывает, как применить предпочтительные параметры форматирования к тексту в таблице:

```c++
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ParagraphFormat.h>
#include <DOM/PortionFormat.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ITable.h>
#include <DOM/TextAlignment.h>
#include <DOM/TextFrameFormat.h>
#include <DOM/TextVerticalType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

// Создаёт экземпляр класса Presentation
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);

// Предположим, что первая фигура на первом слайде — таблица
auto someTable = System::AsCast<ITable>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));

// Устанавливает высоту шрифта ячеек таблицы
auto portionFormat = System::MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25.0f);
someTable->SetTextFormat(portionFormat);

// Устанавливает выравнивание текста ячеек таблицы и правый отступ одним вызовом
auto paragraphFormat = System::MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20.0f);
someTable->SetTextFormat(paragraphFormat);

// Устанавливает вертикальный тип текста ячеек таблицы
auto textFrameFormat = System::MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
someTable->SetTextFormat(textFrameFormat);

presentation->Save(u"result.pptx", SaveFormat::Pptx);
```

## **Получить свойства стиля таблицы**

Aspose.Slides позволяет получать свойства стиля таблицы, чтобы вы могли использовать эти детали для другой таблицы или в другом месте. Этот код на C++ показывает, как получить свойства стиля из предустановленного стиля таблицы:

```c++
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ITable.h>
#include <DOM/TableStylePreset.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slide(0)->get_Shapes();
auto table = System::ExplicitCast<ITable>(shapes->AddTable(10, 10, System::MakeArray<double>({100, 150}), System::MakeArray<double>({5, 5, 5})));

table->set_StylePreset(TableStylePreset::DarkStyle1);
pres->Save(u"table.pptx", SaveFormat::Pptx);
```

## **Блокировка соотношения сторон таблицы**

Соотношение сторон геометрической фигуры — это отношение её размеров в разных измерениях. Aspose.Slides предоставляет свойство `AspectRatioLocked()` , позволяющее блокировать настройку соотношения сторон для таблиц и других фигур. 

Этот код на C++ показывает, как заблокировать соотношение сторон для таблицы:

```c++
#include <DOM/IGraphicalObjectLock.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto table = System::ExplicitCast<ITable>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));

Console::WriteLine(u"Lock aspect ratio set: {0}", table->get_GraphicalObjectLock()->get_AspectRatioLocked());


table->get_GraphicalObjectLock()->set_AspectRatioLocked(!table->get_GraphicalObjectLock()->get_AspectRatioLocked());

Console::WriteLine(u"Lock aspect ratio set: {0}", table->get_GraphicalObjectLock()->get_AspectRatioLocked());

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Могу ли я включить направление чтения справа налево (RTL) для всей таблицы и текста в её ячейках?**

Да. Таблица предоставляет метод [set_RightToLeft](https://reference.aspose.com/slides/ru/cpp/aspose.slides/table/set_righttoleft/) , а абзацы имеют [ParagraphFormat::set_RightToLeft](https://reference.aspose.com/slides/ru/cpp/aspose.slides/paragraphformat/set_righttoleft/) . Использование обоих обеспечивает правильный порядок RTL и рендеринг внутри ячеек.

**Как я могу предотвратить перемещение или изменение размеров таблицы пользователями в окончательном файле?**

Используйте [shape locks](/slides/ru/cpp/applying-protection-to-presentation/) для отключения перемещения, изменения размеров, выбора и т.д. Эти блокировки применимы и к таблицам.

**Поддерживается ли вставка изображения в ячейку в качестве фона?**

Да. Вы можете задать [picture fill](https://reference.aspose.com/slides/ru/cpp/aspose.slides/picturefillformat/) для ячейки; изображение будет покрывать область ячейки в соответствии с выбранным режимом (растягивание или тайл).