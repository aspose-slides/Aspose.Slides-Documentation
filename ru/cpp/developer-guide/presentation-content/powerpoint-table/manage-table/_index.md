---
title: Управление таблицей
type: docs
weight: 10
url: /cpp/manage-table/
keywords: "Таблица, создать таблицу, доступ к таблице, аспектное соотношение таблицы, презентация PowerPoint, C++, Aspose.Slides для C++"
description: "Создание и управление таблицей в презентациях PowerPoint на C++"
---

Таблица в PowerPoint — это эффективный способ отображения и представления информации. Информация в сетке ячеек (расположенных в строках и столбцах) проста и легка для понимания.

Aspose.Slides предоставляет классы [Table](https://reference.aspose.com/slides/cpp/aspose.slides/table/), [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) интерфейс, [Cell](https://reference.aspose.com/slides/cpp/aspose.slides/cell/) класс, [ICell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/) интерфейс и другие типы, позволяющие создавать, обновлять и управлять таблицами во всех типах презентаций.

## **Создание таблицы с нуля**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Получите ссылку на слайд через его индекс.
3. Определите массив `columnWidth`.
4. Определите массив `rowHeight`.
5. Добавьте объект [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) на слайд с помощью метода [AddTable()](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addtable/).
6. Переберите каждую [ICell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/), чтобы применить форматирование к верхнему, нижнему, правому и левому краям.
7. Объедините первые две ячейки первой строки таблицы.
8. Получите [TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/textframe/) [ICell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/).
9. Добавьте текст в [TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/textframe/).
10. Сохраните изменённую презентацию.

Этот код на C++ показывает, как создать таблицу в презентации:

```c++
// Создает экземпляр класса Presentation, представляющий файл PPTX
auto pres = System::MakeObject<Presentation>();

// Получает первый слайд
auto sld = pres->get_Slides()->idx_get(0);

// Определяет столбцы с шириной и строки с высотой
auto dblCols = System::MakeArray<double>({ 50, 50, 50 });
auto dblRows = System::MakeArray<double>({ 50, 30, 30, 30, 30 });

// Добавляет форму таблицы на слайд
auto tbl = sld->get_Shapes()->AddTable(100.0f, 50.0f, dblCols, dblRows);

// Устанавливает формат границ для каждой ячейки
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
// Объединяет ячейки 1 и 2 строки 1
tbl->MergeCells(tbl->get_Rows()->idx_get(0)->idx_get(0), tbl->get_Rows()->idx_get(1)->idx_get(1), false);

// Добавляет текст в объединенную ячейку
tbl->get_Rows()->idx_get(0)->idx_get(0)->get_TextFrame()->set_Text(u"Объединенные ячейки");

// Сохраняет презентацию на диск
pres->Save(u"table.pptx", SaveFormat::Pptx);
```

## **Нумерация в обычной таблице**

В стандартной таблице нумерация ячеек проста и основана на нулях. Первая ячейка в таблице индексируется как 0,0 (столбец 0, строка 0).

Например, ячейки в таблице с 4 столбцами и 4 строками нумеруются следующим образом:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Этот код C++ показывает, как указать нумерацию для ячеек в таблице:

```c++
// Создает экземпляр класса Presentation, представляющий файл PPTX
auto pres = System::MakeObject<Presentation>();

// Получает первый слайд
auto sld = pres->get_Slides()->idx_get(0);

// Определяет столбцы с шириной и строки с высотой
auto dblCols = System::MakeArray<double>({ 70, 70, 70, 70 });
auto dblRows = System::MakeArray<double>({ 70, 70, 70, 70 });

// Добавляет форму таблицы на слайд
auto tbl = sld->get_Shapes()->AddTable(100.0f, 50.0f, dblCols, dblRows);

// Устанавливает формат границ для каждой ячейки
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

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).

2. Получите ссылку на слайд, содержащий таблицу, через его индекс.

3. Создайте объект [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) и установите его в null.

4. Переберите все объекты [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/), пока таблица не будет найдена.

   Если вы подозреваете, что слайд, с которым вы работаете, содержит единственную таблицу, вы можете просто проверить все формы, которые он содержит. Когда форма идентифицируется как таблица, вы можете привести ее к объекту [Table](https://reference.aspose.com/slides/cpp/aspose.slides/table/). Но если слайд, с которым вы работаете, содержит несколько таблиц, то лучше всего искать нужную таблицу через [set_AlternativeText()](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/set_alternativetext/).

5. Используйте объект [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) для работы с таблицей. В приведенном ниже примере мы добавили новую строку в таблицу.

6. Сохраните изменённую презентацию.

Этот код C++ показывает, как получить доступ и работать с существующей таблицей:

```c++
// Создает экземпляр класса Presentation, представляющий файл PPTX
auto pres = System::MakeObject<Presentation>(u"UpdateExistingTable.pptx");

// Получает первый слайд
auto sld = pres->get_Slides()->idx_get(0);

// Инициализирует null для таблицы
System::SharedPtr<ITable> tbl;

// Перебирает формы и устанавливает ссылку на найденную таблицу
for (const auto& shp : System::IterateOver(sld->get_Shapes()))
{
    if (System::ObjectExt::Is<ITable>(shp))
    {
        tbl = System::ExplicitCast<ITable>(shp);
    }
}

// Устанавливает текст для первого столбца второй строки
tbl->idx_get(0, 1)->get_TextFrame()->set_Text(u"Новый");

// Сохраняет изменённую презентацию на диск
pres->Save(u"table1_out.pptx", SaveFormat::Pptx);
```

## **Выравнивание текста в таблице**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Получите ссылку на слайд через его индекс.
3. Добавьте объект [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) на слайд.
4. Получите объект [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) из таблицы.
5. Получите [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) [IParagraph](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/).
6. Выравните текст по вертикали.
7. Сохраните изменённую презентацию.

Этот код C++ показывает, как выровнять текст в таблице:

```c++
// Создает экземпляр класса Presentation
auto presentation = System::MakeObject<Presentation>();

// Получает первый слайд 
auto slide = presentation->get_Slides()->idx_get(0);

// Определяет столбцы с шириной и строки с высотой
auto dblCols = System::MakeArray<double>({ 120, 120, 120, 120 });
auto dblRows = System::MakeArray<double>({ 100, 100, 100, 100 });

// Добавляет форму таблицы на слайд
auto tbl = slide->get_Shapes()->AddTable(100.0f, 50.0f, dblCols, dblRows);
tbl->idx_get(1, 0)->get_TextFrame()->set_Text(u"10");
tbl->idx_get(2, 0)->get_TextFrame()->set_Text(u"20");
tbl->idx_get(3, 0)->get_TextFrame()->set_Text(u"30");

// Получает текстовый фрейм
auto txtFrame = tbl->idx_get(0, 0)->get_TextFrame();

// Создает объект абзаца для текстового фрейма
auto paragraph = txtFrame->get_Paragraphs()->idx_get(0);

// Создает объект Portion для абзаца
auto portion = paragraph->get_Portions()->idx_get(0);
portion->set_Text(u"Текст здесь");
portion->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
portion->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

// Выравнивает текст по вертикали
auto cell = tbl->idx_get(0, 0);
cell->set_TextAnchorType(TextAnchorType::Center);
cell->set_TextVerticalType(TextVerticalType::Vertical270);

// Сохраняет презентацию на диск
presentation->Save(u"Vertical_Align_Text_out.pptx", SaveFormat::Pptx);
```

## **Установка форматирования текста на уровне таблицы**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Получите ссылку на слайд через его индекс.
3. Получите объект [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) из слайда.
4. Установите [set_FontHeight()](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_fontheight/) для текста.
5. Установите [set_Alignment()](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_alignment/) и [set_MarginRight()](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_marginright/).
6. Установите [set_TextVerticalType()](https://reference.aspose.com/slides/cpp/aspose.slides/textframeformat/set_textverticaltype/).
7. Сохраните изменённую презентацию.

Этот код C++ показывает, как применить ваши предпочтительные параметры форматирования к тексту в таблице:

```c++
// Создает экземпляр класса Presentation
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);

// Допустим, что первая форма на первом слайде — это таблица
auto someTable = System::AsCast<ITable>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));

// Устанавливает высоту шрифта ячеек таблицы
auto portionFormat = System::MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25.0f);
someTable->SetTextFormat(portionFormat);

// Устанавливает выравнивание текста в ячейках таблицы и правый отступ за один раз
auto paragraphFormat = System::MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20.0f);
someTable->SetTextFormat(paragraphFormat);

// Устанавливает вертикальный тип текста в ячейках таблицы
auto textFrameFormat = System::MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
someTable->SetTextFormat(textFrameFormat);

presentation->Save(u"result.pptx", SaveFormat::Pptx);
```

## **Получение свойств стиля таблицы**

Aspose.Slides позволяет извлекать свойства стиля для таблицы, чтобы вы могли использовать эти детали для другой таблицы или в другом месте. Этот код C++ показывает, как получить свойства стиля из предустановленного стиля таблицы:

```c++
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slide(0)->get_Shapes();
auto table = System::ExplicitCast<ITable>(shapes->AddTable(10, 10, System::MakeArray<double>({100, 150}), System::MakeArray<double>({5, 5, 5})));

table->set_StylePreset(TableStylePreset::DarkStyle1);
pres->Save(u"table.pptx", SaveFormat::Pptx);
```

## **Блокировка аспектного соотношения таблицы**

Аспектное соотношение геометрической формы — это отношение её размеров в разных измерениях. Aspose.Slides предоставляет свойство `AspectRatioLocked()`, чтобы вы могли заблокировать настройку аспектного со_ratio для таблиц и других форм.

Этот код C++ показывает, как заблокировать аспектное соотношение для таблицы:

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto table = System::ExplicitCast<ITable>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));

Console::WriteLine(u"Блокировка аспектного соотношения установлена: {0}", table->get_GraphicalObjectLock()->get_AspectRatioLocked());

table->get_GraphicalObjectLock()->set_AspectRatioLocked(!table->get_GraphicalObjectLock()->get_AspectRatioLocked());

Console::WriteLine(u"Блокировка аспектного соотношения установлена: {0}", table->get_GraphicalObjectLock()->get_AspectRatioLocked());

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```