---
title: Управление строками и столбцами таблиц PowerPoint с помощью C++
linktitle: Строки и столбцы
type: docs
weight: 20
url: /ru/cpp/manage-rows-and-columns/
keywords:
- строка таблицы
- столбец таблицы
- первая строка
- заголовок таблицы
- клонировать строку
- клонировать столбец
- копировать строку
- копировать столбец
- удалить строку
- удалить столбец
- форматирование текста строки
- форматирование текста столбца
- стиль таблицы
- PowerPoint
- презентация
- C++
- Aspose.Slides
description: "Управляйте строками и столбцами таблиц в PowerPoint с помощью Aspose.Slides для C++ и ускоряйте редактирование презентаций и обновление данных."
---

Чтобы вы могли управлять строками и столбцами таблицы в презентации PowerPoint, Aspose.Slides предоставляет класс [Table](https://reference.aspose.com/slides/cpp/aspose.slides/table/) , интерфейс [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) , а также многие другие типы. 

## **Установить первую строку в качестве заголовка**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) и загрузите презентацию. 
2. Получите ссылку на слайд по его индексу. 
3. Создайте объект [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) и установите его в null. 
4. Переберите все объекты [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) , чтобы найти нужную таблицу. 
5. Установите первую строку таблицы в качестве заголовка. 

```c++
// Создает экземпляр класса Presentation 
auto pres = System::MakeObject<Presentation>(u"table.pptx");

// Получает первый слайд
auto sld = pres->get_Slides()->idx_get(0);

// Инициализирует null TableEx
SharedPtr<ITable> tbl;

// Итерирует формы и задает ссылку на таблицу
for (const auto& shp : sld->get_Shapes())
{
    if (ObjectExt::Is<ITable>(shp))
    {
        tbl = System::ExplicitCast<ITable>(shp);
    }
}

// Устанавливает первую строку таблицы как заголовок 
tbl->set_FirstRow(true);
```


## **Клонировать строку или столбец таблицы**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) и загрузите презентацию, 
2. Получите ссылку на слайд по его индексу. 
3. Определите массив `columnWidth`. 
4. Определите массив `rowHeight`. 
5. Добавьте объект [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) на слайд с помощью метода [AddTable()](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addtable/) . 
6. Клонируйте строку таблицы. 
7. Клонируйте столбец таблицы. 
8. Сохраните изменённую презентацию. 

```c++
 // Путь к каталогу документов.
const String outPath = u"../out/CloningInTable_out.pptx";

// Создает экземпляр класса Presentation
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Получает первый слайд
SharedPtr<ISlide> islide = pres->get_Slides()->idx_get(0);

// Определяет столбцы с ширинами и строки с высотами
System::ArrayPtr<double> dblCols = System::MakeObject<System::Array<double>>(4, 70);
System::ArrayPtr<double> dblRows = System::MakeObject<System::Array<double>>(4, 70);

// Добавляет форму таблицы на слайд
SharedPtr<ITable> table = islide->get_Shapes()->AddTable(100, 50, dblCols, dblRows);


// Устанавливает формат границы для каждой ячейки
for (int x = 0; x < table->get_Rows()->get_Count(); x++)
{
	SharedPtr<IRow> row = table->get_Rows()->idx_get(x);
	for (int y = 0; y < row->get_Count(); y++)
	{
		SharedPtr<ICell> cell = row->idx_get(y);

		cell->get_BorderTop()->get_FillFormat()->set_FillType(FillType::Solid);
		cell->get_BorderTop()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());
		cell->get_BorderTop()->set_Width(5);

		cell->get_BorderBottom()->get_FillFormat()->set_FillType(FillType::Solid);
		cell->get_BorderBottom()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());
		cell->get_BorderBottom()->set_Width(5);

		cell->get_BorderLeft()->get_FillFormat()->set_FillType(FillType::Solid);
		cell->get_BorderLeft()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());
		cell->get_BorderLeft()->set_Width(5);

		cell->get_BorderRight()->get_FillFormat()->set_FillType(FillType::Solid);
		cell->get_BorderRight()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());
		cell->get_BorderRight()->set_Width(5);

	}

}

table->idx_get(0, 0)->get_TextFrame()->set_Text(u"00");
table->idx_get(0, 1)->get_TextFrame()->set_Text(u"01");
table->idx_get(0, 2)->get_TextFrame()->set_Text(u"02");
table->idx_get(0, 3)->get_TextFrame()->set_Text(u"03");
table->idx_get(1, 0)->get_TextFrame()->set_Text(u"10");
table->idx_get(2, 0)->get_TextFrame()->set_Text(u"20");
table->idx_get(1, 1)->get_TextFrame()->set_Text(u"11");
table->idx_get(2, 1)->get_TextFrame()->set_Text(u"21");

//AddClone добавляет строку в конец таблицы
table->get_Rows()->AddClone(table->get_Rows()->idx_get(0), false);

//InsertClone добавляет строку в определенную позицию таблицы
table->get_Rows()->InsertClone(2, table->get_Rows()->idx_get(0), false);

//AddClone добавляет столбец в конец таблицы
table->get_Columns()->AddClone(table->get_Columns()->idx_get(0), false);

//InsertClone добавляет столбец в определенную позицию таблицы
table->get_Columns()->InsertClone(2, table->get_Columns()->idx_get(0), false);


// Сохраняет презентацию на диск
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


## **Удалить строку или столбец из таблицы**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) и загрузите презентацию, 
2. Получите ссылку на слайд по его индексу. 
3. Определите массив `columnWidth`. 
4. Определите массив `rowHeight`. 
5. Добавьте объект [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) на слайд с помощью метода [AddTable()](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addtable/) . 
6. Удалите строку таблицы. 
7. Удалите столбец таблицы. 
8. Сохраните изменённую презентацию. 

```c++
// Путь к каталогу документов.
const String outPath = u"../out/RemovingRowColumn_out.pptx";

// Создает экземпляр класса Presentation
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Получает первый слайд
SharedPtr<ISlide> islide = pres->get_Slides()->idx_get(0);

// Определяет столбцы с ширинами и строки с высотами
System::ArrayPtr<double> dblCols = System::MakeObject<System::Array<double>>(4, 70);
System::ArrayPtr<double> dblRows = System::MakeObject<System::Array<double>>(4, 70);

// Добавляет форму таблицы на слайд
SharedPtr<ITable> table = islide->get_Shapes()->AddTable(100, 50, dblCols, dblRows);

table->get_Rows()->RemoveAt(1, false);
table->get_Columns()->RemoveAt(1, false);


// Объединяет ячейки (1, 1) x (2, 1)
table->MergeCells(table->idx_get(1, 1), table->idx_get(2, 1), false);

// Объединяет ячейки (1, 2) x (2, 2)
table->MergeCells(table->idx_get(1, 2), table->idx_get(2, 2), false);


// Сохраняет презентацию на диск
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


## **Установить форматирование текста на уровне строк таблицы**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) и загрузите презентацию, 
2. Получите ссылку на слайд по его индексу. 
3. Получите доступ к нужному объекту [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) со слайда. 
4. Установите для ячеек первой строки [set_FontHeight()](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_fontheight/). 
5. Установите для ячеек первой строки [set_Alignment()](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_alignment/) и [set_MarginRight()](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_marginright/). 
6. Установите для ячеек второй строки [set_TextVerticalType()](https://reference.aspose.com/slides/cpp/aspose.slides/textframeformat/set_textverticaltype/). 
7. Сохраните изменённую презентацию. 

```c++
// Создает экземпляр класса Presentation
auto presentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slides()->idx_get(0);

auto someTable = System::AsCast<ITable>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
// Предположим, что первая фигура на первом слайде является таблицей
// Устанавливает высоту шрифта ячеек первой строки
auto portionFormat = System::MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25.0f);
someTable->get_Rows()->idx_get(0)->SetTextFormat(portionFormat);

// Устанавливает выравнивание текста ячеек первой строки и правый отступ
auto paragraphFormat = System::MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20.0f);
someTable->get_Rows()->idx_get(0)->SetTextFormat(paragraphFormat);

// Устанавливает тип вертикального текста ячеек второй строки
auto textFrameFormat = System::MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
someTable->get_Rows()->idx_get(1)->SetTextFormat(textFrameFormat);

// Сохраняет презентацию на диск
presentation->Save(u"result.pptx", SaveFormat::Pptx);
```


## **Установить форматирование текста на уровне столбцов таблицы**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) и загрузите презентацию, 
2. Получите ссылку на слайд по его индексу. 
3. Получите доступ к нужному объекту [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) со слайда. 
4. Установите для ячеек первого столбца [set_FontHeight()](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_fontheight/). 
5. Установите для ячеек первого столбца [set_Alignment()](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_alignment/) и [set_MarginRight()](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_marginright/). 
6. Установите для ячеек второго столбца [set_TextVerticalType()](https://reference.aspose.com/slides/cpp/aspose.slides/textframeformat/set_textverticaltype/). 
7. Сохраните изменённую презентацию. 

```c++
// Создает экземпляр класса Presentation
auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);

auto someTable = System::AsCast<ITable>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
// Предположим, что первая фигура на первом слайде является таблицей

// Устанавливает высоту шрифта ячеек первого столбца
auto portionFormat = System::MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25.0f);
someTable->get_Columns()->idx_get(0)->SetTextFormat(portionFormat);

// Устанавливает выравнивание текста ячеек первого столбца и правый отступ одной командой
auto paragraphFormat = System::MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20.0f);
someTable->get_Columns()->idx_get(0)->SetTextFormat(paragraphFormat);

// Устанавливает тип вертикального текста ячеек второго столбца
auto textFrameFormat = System::MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
someTable->get_Columns()->idx_get(1)->SetTextFormat(textFrameFormat);

pres->Save(u"result.pptx", SaveFormat::Pptx);
```


## **Получить свойства стиля таблицы**

Aspose.Slides позволяет получить свойства стиля таблицы, чтобы вы могли использовать эти детали для другой таблицы или в другом месте. Этот код C++ показывает, как получить свойства стиля из предустановленного стиля таблицы:
```c++
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slide(0)->get_Shapes();
auto table = System::ExplicitCast<ITable>(shapes->AddTable(10, 10, System::MakeArray<double>({100, 150}), System::MakeArray<double>({5, 5, 5})));

table->set_StylePreset(TableStylePreset::DarkStyle1);
pres->Save(u"table.pptx", SaveFormat::Pptx);
```


## **FAQ**

**Можно ли применить темы/стили PowerPoint к уже созданной таблице?**

Да. Таблица наследует тему слайда/макета/главного шаблона, и вы всё равно можете переопределять заливки, границы и цвета текста поверх этой темы.

**Можно ли сортировать строки таблицы как в Excel?**

Нет, таблицы Aspose.Slides не поддерживают встроенную сортировку или фильтры. Сначала отсортируйте данные в памяти, затем заново заполните строки таблицы в этом порядке.

**Можно ли иметь чередующиеся (полосатые) столбцы, сохраняя пользовательские цвета в отдельных ячейках?**

Да. Включите чередование столбцов, затем переопределите отдельные ячейки локальным форматированием; форматирование на уровне ячейки имеет приоритет перед стилем таблицы.