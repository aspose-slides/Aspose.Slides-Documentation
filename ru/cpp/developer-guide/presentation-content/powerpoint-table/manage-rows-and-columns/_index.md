---
title: Управление строками и столбцами
type: docs
weight: 20
url: /cpp/manage-rows-and-columns/
keywords: "Таблица, строки и столбцы таблицы, презентация PowerPoint, C++, CPP, Aspose.Slides для C++"
description: "Управление строками и столбцами таблицы в презентациях PowerPoint на C++"

---

Чтобы управлять строками и столбцами таблицы в презентации PowerPoint, Aspose.Slides предоставляет класс [Table](https://reference.aspose.com/slides/cpp/aspose.slides/table/), интерфейс [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) и многие другие типы. 

## **Установить первую строку в качестве заголовка**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) и загрузите презентацию. 
2. Получите ссылку на слайд через его индекс. 
3. Создайте объект [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) и установите его в null.
4. Переберите все объекты [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/), чтобы найти соответствующую таблицу. 
5. Установите первую строку таблицы в качестве заголовка. 

Этот код C++ показывает, как установить первую строку таблицы в качестве заголовка:

```c++
// Создаёт экземпляр класса Presentation 
auto pres = System::MakeObject<Presentation>(u"table.pptx");

// Получает первый слайд
auto sld = pres->get_Slides()->idx_get(0);

// Инициализирует null TableEx
SharedPtr<ITable> tbl;

// Перебирает фигуры и устанавливает ссылку на таблицу
for (const auto& shp : sld->get_Shapes())
{
    if (ObjectExt::Is<ITable>(shp))
    {
        tbl = System::ExplicitCast<ITable>(shp);
    }
}

// Устанавливает первую строку таблицы в качестве заголовка 
tbl->set_FirstRow(true);
```


## **Клонировать строку или столбец таблицы**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) и загрузите презентацию. 
2. Получите ссылку на слайд через его индекс. 
3. Определите массив `columnWidth`.
4. Определите массив `rowHeight`.
5. Добавьте объект [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) на слайд через метод [AddTable()](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addtable/).
6. Клонируйте строку таблицы.
7. Клонируйте столбец таблицы.
8. Сохраните изменённую презентацию.

Этот код C++ показывает, как клонировать строку или столбец таблицы PowerPoint:

```c++
// Путь к директории документов.
const String outPath = u"../out/CloningInTable_out.pptx";

// Создаёт экземпляр класса Presentation
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Получает первый слайд
SharedPtr<ISlide> islide = pres->get_Slides()->idx_get(0);

// Определяет столбцы с ширинами и строки с высотами
System::ArrayPtr<double> dblCols = System::MakeObject<System::Array<double>>(4, 70);
System::ArrayPtr<double> dblRows = System::MakeObject<System::Array<double>>(4, 70);

// Добавляет таблицу на слайд
SharedPtr<ITable> table = islide->get_Shapes()->AddTable(100, 50, dblCols, dblRows);


// Устанавливает формат границ для каждой ячейки
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

//AddClone добавляет строку в конце таблицы
table->get_Rows()->AddClone(table->get_Rows()->idx_get(0), false);

//InsertClone добавляет строку в конкретном положении в таблице
table->get_Rows()->InsertClone(2, table->get_Rows()->idx_get(0), false);

//AddClone добавляет столбец в конце таблицы
table->get_Columns()->AddClone(table->get_Columns()->idx_get(0), false);

//InsertClone добавляет столбец в конкретном положении в таблице
table->get_Columns()->InsertClone(2, table->get_Columns()->idx_get(0), false);


// Сохраняет презентацию на диске
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Удалить строку или столбец из таблицы**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) и загрузите презентацию. 
2. Получите ссылку на слайд через его индекс. 
3. Определите массив `columnWidth`.
4. Определите массив `rowHeight`.
5. Добавьте объект [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) на слайд через метод [AddTable()](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addtable/).
6. Удалите строку таблицы.
7. Удалите столбец таблицы.
8. Сохраните изменённую презентацию. 

Этот код C++ показывает, как удалить строку или столбец из таблицы:

```c++
// Путь к директории документов.
const String outPath = u"../out/RemovingRowColumn_out.pptx";

// Создаёт экземпляр класса Presentation
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Получает первый слайд
SharedPtr<ISlide> islide = pres->get_Slides()->idx_get(0);

// Определяет столбцы с ширинами и строки с высотами
System::ArrayPtr<double> dblCols = System::MakeObject<System::Array<double>>(4, 70);
System::ArrayPtr<double> dblRows = System::MakeObject<System::Array<double>>(4, 70);

// Добавляет таблицу на слайд
SharedPtr<ITable> table = islide->get_Shapes()->AddTable(100, 50, dblCols, dblRows);

table->get_Rows()->RemoveAt(1, false);
table->get_Columns()->RemoveAt(1, false);


// Объединяет ячейки (1, 1) x (2, 1)
table->MergeCells(table->idx_get(1, 1), table->idx_get(2, 1), false);

// Объединяет ячейки (1, 2) x (2, 2)
table->MergeCells(table->idx_get(1, 2), table->idx_get(2, 2), false);


// Сохраняет презентацию на диске
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Установить форматирование текста на уровне строки таблицы**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) и загрузите презентацию. 
2. Получите ссылку на слайд через его индекс. 
3. Получите соответствующий объект [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) с слайда. 
4. Установите высоту шрифта для ячеек первой строки [set_FontHeight()](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_fontheight/). 
5. Установите выравнивание текста и правый отступ для ячеек первой строки [set_Alignment()](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_alignment/) и [set_MarginRight()](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_marginright/). 
6. Установите вертикальный тип текста для ячеек второй строки [set_TextVerticalType()](https://reference.aspose.com/slides/cpp/aspose.slides/textframeformat/set_textverticaltype/).
7. Сохраните изменённую презентацию.

Этот код C++ демонстрирует операцию.

```c++
// Создаёт экземпляр класса Presentation
auto presentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slides()->idx_get(0);

auto someTable = System::AsCast<ITable>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
// Предположим, что первая фигура на первом слайде - это таблица
// Устанавливает высоту шрифта ячеек первой строки
auto portionFormat = System::MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25.0f);
someTable->get_Rows()->idx_get(0)->SetTextFormat(portionFormat);

// Устанавливает выравнивание текста и правый отступ для ячеек первой строки
auto paragraphFormat = System::MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20.0f);
someTable->get_Rows()->idx_get(0)->SetTextFormat(paragraphFormat);

// Устанавливает вертикальный тип текста для ячеек второй строки
auto textFrameFormat = System::MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
someTable->get_Rows()->idx_get(1)->SetTextFormat(textFrameFormat);

// Сохраняет презентацию на диске
presentation->Save(u"result.pptx", SaveFormat::Pptx);
```

## **Установить форматирование текста на уровне столбца таблицы**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) и загрузите презентацию. 
2. Получите ссылку на слайд через его индекс. 
3. Получите соответствующий объект [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) с слайда. 
4. Установите высоту шрифта для ячеек первого столбца [set_FontHeight()](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_fontheight/). 
5. Установите выравнивание текста и правый отступ для ячеек первого столбца [set_Alignment()](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_alignment/) и [set_MarginRight()](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_marginright/). 
6. Установите вертикальный тип текста для ячеек второго столбца [set_TextVerticalType()](https://reference.aspose.com/slides/cpp/aspose.slides/textframeformat/set_textverticaltype/).
7. Сохраните изменённую презентацию. 

Этот код C++ демонстрирует операцию: 

```c++
// Создаёт экземпляр класса Presentation
auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);

auto someTable = System::AsCast<ITable>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
// Предположим, что первая фигура на первом слайде - это таблица

// Устанавливает высоту шрифта ячеек первого столбца
auto portionFormat = System::MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25.0f);
someTable->get_Columns()->idx_get(0)->SetTextFormat(portionFormat);

// Устанавливает выравнивание текста и правый отступ для ячеек первого столбца за один вызов
auto paragraphFormat = System::MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20.0f);
someTable->get_Columns()->idx_get(0)->SetTextFormat(paragraphFormat);

// Устанавливает вертикальный тип текста для ячеек второго столбца
auto textFrameFormat = System::MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
someTable->get_Columns()->idx_get(1)->SetTextFormat(textFrameFormat);

pres->Save(u"result.pptx", SaveFormat::Pptx);
```

## **Получить свойства стиля таблицы**

Aspose.Slides позволяет вам получить свойства стиля для таблицы, чтобы вы могли использовать эти детали для другой таблицы или в другом месте. Этот код C++ показывает, как получить свойства стиля из предустановленного стиля таблицы:

```c++
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slide(0)->get_Shapes();
auto table = System::ExplicitCast<ITable>(shapes->AddTable(10, 10, System::MakeArray<double>({100, 150}), System::MakeArray<double>({5, 5, 5})));

table->set_StylePreset(TableStylePreset::DarkStyle1);
pres->Save(u"table.pptx", SaveFormat::Pptx);
```