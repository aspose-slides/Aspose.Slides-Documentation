---
title: Управление таблицами презентаций в C++
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
description: "Создавайте и редактируйте таблицы в слайдах PowerPoint с помощью Aspose.Slides для C++. Откройте простые примеры кода, упрощающие работу с таблицами."
---

Таблица в PowerPoint — эффективный способ отображения и представления информации. Информация в сетке ячеек (расположенных в строках и столбцах) проста и легко воспринимается.

Aspose.Slides предоставляет [Таблица](https://reference.aspose.com/slides/cpp/aspose.slides/table/) класс, [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) интерфейс, [Cell](https://reference.aspose.com/slides/cpp/aspose.slides/cell/) класс, [ICell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/) интерфейс и другие типы, позволяющие создавать, обновлять и управлять таблицами в любых презентациях. 

## **Создать таблицу с нуля**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).  
2. Получите ссылку на слайд по его индексу.  
3. Определите массив `columnWidth`.  
4. Определите массив `rowHeight`.  
5. Добавьте объект [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) на слайд с помощью метода [AddTable()](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addtable/).  
6. Пройдитесь по каждому [ICell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/) и примените форматирование к верхней, нижней, правой и левой границам.  
7. Объедините первые две ячейки первой строки таблицы.  
8. Доступ к [ICell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/)'s [TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/textframe/).  
9. Добавьте текст в [TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/textframe/).  
10. Сохраните изменённую презентацию.  

Этот C++ код показывает, как создать таблицу в презентации:
```c++
// Создает объект класса Presentation, представляющий файл PPTX
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

Например, ячейки в таблице с 4 столбцами и 4 строками нумеруются так:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Этот C++ код показывает, как задать нумерацию ячеек в таблице:
```c++
// Создает экземпляр класса Presentation, представляющий файл PPTX
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

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).  

2. Получите ссылку на слайд, содержащий таблицу, по его индексу.  

3. Создайте объект [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) и установите его в null.  

4. Пройдитесь по всем объектам [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) до тех пор, пока не найдёте таблицу.  

   Если вы предполагаете, что слайд содержит единственную таблицу, можно просто проверить все формы, которые он содержит. Когда форма определена как таблица, её можно привести к объекту [Table](https://reference.aspose.com/slides/cpp/aspose.slides/table/). Но если слайд содержит несколько таблиц, лучше искать нужную таблицу через её [set_AlternativeText()](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/set_alternativetext/).  

5. Используйте объект [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) для работы с таблицей. В примере ниже мы добавили новую строку в таблицу.  

6. Сохраните изменённую презентацию.  

Этот C++ код показывает, как получить доступ и работать с существующей таблицей:
```c++
// Создаёт экземпляр класса Presentation, представляющий файл PPTX
auto pres = System::MakeObject<Presentation>(u"UpdateExistingTable.pptx");

// Получает первый слайд
auto sld = pres->get_Slides()->idx_get(0);

// Инициализирует Table как null
System::SharedPtr<ITable> tbl;

// Итерируется по фигурам и устанавливает ссылку на найденную таблицу
for (const auto& shp : System::IterateOver(sld->get_Shapes()))
{
    if (System::ObjectExt::Is<ITable>(shp))
    {
        tbl = System::ExplicitCast<ITable>(shp);
    }
}

// Устанавливает текст для первой колонки второй строки
tbl->idx_get(0, 1)->get_TextFrame()->set_Text(u"New");

// Сохраняет изменённую презентацию на диск
pres->Save(u"table1_out.pptx", SaveFormat::Pptx);
```


## **Выравнивание текста в таблице**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).  
2. Получите ссылку на слайд по его индексу.  
3. Добавьте объект [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) на слайд.  
4. Получите объект [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) из таблицы.  
5. Получите [IParagraph](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/) из [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/).  
6. Выравняйте текст по вертикали.  
7. Сохраните изменённую презентацию.  

Этот C++ код показывает, как выровнять текст в таблице:
```c++
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

// Получает объект текстового фрейма
auto txtFrame = tbl->idx_get(0, 0)->get_TextFrame();

// Создаёт объект Paragraph для текстового фрейма
auto paragraph = txtFrame->get_Paragraphs()->idx_get(0);

// Создаёт объект Portion для абзаца
auto portion = paragraph->get_Portions()->idx_get(0);
portion->set_Text(u"Text here");
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
2. Получите ссылку на слайд по его индексу.  
3. Получите объект [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) со слайда.  
4. Установите [set_FontHeight()](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_fontheight/) для текста.  
5. Установите [set_Alignment()](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_alignment/) и [set_MarginRight()](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_marginright/).  
6. Установите [set_TextVerticalType()](https://reference.aspose.com/slides/cpp/aspose.slides/textframeformat/set_textverticaltype/).  
7. Сохраните изменённую презентацию.  

Этот C++ код показывает, как применить предпочтительные параметры форматирования к тексту в таблице:
```c++
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


## **Получение свойств стиля таблицы**

Aspose.Slides позволяет получать свойства стиля таблицы, чтобы использовать эти детали в другой таблице или где‑угодно ещё. Этот C++ код показывает, как получить свойства стиля из предустановленного стиля таблицы:
```c++
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slide(0)->get_Shapes();
auto table = System::ExplicitCast<ITable>(shapes->AddTable(10, 10, System::MakeArray<double>({100, 150}), System::MakeArray<double>({5, 5, 5})));

table->set_StylePreset(TableStylePreset::DarkStyle1);
pres->Save(u"table.pptx", SaveFormat::Pptx);
```


## **Блокировка соотношения сторон таблицы**

Соотношение сторон геометрической формы — это отношение её размеров в разных измерениях. Aspose.Slides предоставляет свойство `AspectRatioLocked()`, позволяющее заблокировать настройку соотношения сторон для таблиц и других форм. 

Этот C++ код показывает, как заблокировать соотношение сторон для таблицы:
```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto table = System::ExplicitCast<ITable>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));

Console::WriteLine(u"Lock aspect ratio set: {0}", table->get_GraphicalObjectLock()->get_AspectRatioLocked());


table->get_GraphicalObjectLock()->set_AspectRatioLocked(!table->get_GraphicalObjectLock()->get_AspectRatioLocked());

Console::WriteLine(u"Lock aspect ratio set: {0}", table->get_GraphicalObjectLock()->get_AspectRatioLocked());

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```


## **FAQ**

**Могу ли я включить направление чтения справа налево (RTL) для всей таблицы и текста в её ячейках?**

Да. Таблица раскрывает метод [set_RightToLeft](https://reference.aspose.com/slides/cpp/aspose.slides/table/set_righttoleft/), а абзацы имеют [ParagraphFormat::set_RightToLeft](https://reference.aspose.com/slides/cpp/aspose.slides/paragraphformat/set_righttoleft/). Использование обоих обеспечивает правильный порядок RTL и корректный рендеринг внутри ячеек.

**Как можно не дать пользователям перемещать или изменять размер таблицы в конечном файле?**

Используйте [блокировки форм](/slides/ru/cpp/applying-protection-to-presentation/) для отключения перемещения, изменения размера, выбора и т.д. Эти блокировки применимы и к таблицам.

**Поддерживается ли вставка изображения в ячейку в качестве фона?**

Да. Вы можете задать [заполнение рисунком](https://reference.aspose.com/slides/cpp/aspose.slides/picturefillformat/) для ячейки; изображение заполнит область ячейки согласно выбранному режиму (растягивание или мозаика).