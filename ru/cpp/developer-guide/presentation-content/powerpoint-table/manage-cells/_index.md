---
title: Управление Ячейками
type: docs
weight: 30
url: /ru/cpp/manage-cells/
keywords: "Таблица, объединенные ячейки, разделенные ячейки, изображение в ячейке таблицы, C++, CPP, Aspose.Slides для C++"
description: "Ячейки таблицы в презентациях PowerPoint на C++"
---

## **Идентификация Объединенной Ячейки**
1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Получите таблицу с первого слайда. 
3. Переберите строки и столбцы таблицы, чтобы найти объединенные ячейки.
4. Выведите сообщение, когда будут найдены объединенные ячейки.

Этот код на C++ показывает, как идентифицировать объединенные ячейки таблицы в презентации:

``` cpp
auto pres = System::MakeObject<Presentation>(u"SomePresentationWithTable.pptx");
auto table = System::AsCast<ITable>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));

// предполагая, что Slide#0.Shape#0 - это таблица
for (int32_t i = 0; i < table->get_Rows()->get_Count(); i++)
{
    for (int32_t j = 0; j < table->get_Columns()->get_Count(); j++)
    {
        auto currentCell = table->get_Rows()->idx_get(i)->idx_get(j);
        if (currentCell->get_IsMergedCell())
        {
            Console::WriteLine(String::Format(u"Ячейка {0};{1} является частью объединенной ячейки с RowSpan={2} и ColSpan={3}, начиная с ячейки {4};{5}.", 
                i, j, currentCell->get_RowSpan(), currentCell->get_ColSpan(), currentCell->get_FirstRowIndex(), currentCell->get_FirstColumnIndex()));
        }
    }
}
```

## **Удаление Границ Таблицы Ячеек**
1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Получите ссылку на слайд через его индекс. 
3. Определите массив столбцов с шириной.
4. Определите массив строк с высотой.
5. Добавьте таблицу на слайд с помощью метода `AddTable`.
6. Переберите каждую ячейку, чтобы очистить верхние, нижние, правые и левые границы.
7. Сохраните измененную презентацию в виде файла PPTX.

Этот код на C++ показывает, как удалить границы из ячеек таблицы:

``` cpp
// Создает экземпляр класса Presentation, представляющего файл PPTX
auto pres = MakeObject<Presentation>();
// Получает доступ к первому слайду
auto sld = pres->get_Slides()->idx_get(0);

// Определяет столбцы с шириной и строки с высотой
auto dblCols = MakeArray<double>({ 50, 50, 50, 50 });
auto dblRows = MakeArray<double>({ 50, 30, 30, 30, 30 });

// Добавляет форму таблицы на слайд
auto tbl = sld->get_Shapes()->AddTable(100.0f, 50.0f, dblCols, dblRows);

// Устанавливает формат границ для каждой ячейки
for (const auto& row : System::IterateOver(tbl->get_Rows()))
{
    for (const auto& cell : System::IterateOver(row))
    {
        cell->get_CellFormat()->get_BorderTop()->get_FillFormat()->set_FillType(FillType::NoFill);
        cell->get_CellFormat()->get_BorderBottom()->get_FillFormat()->set_FillType(FillType::NoFill);
        cell->get_CellFormat()->get_BorderLeft()->get_FillFormat()->set_FillType(FillType::NoFill);
        cell->get_CellFormat()->get_BorderRight()->get_FillFormat()->set_FillType(FillType::NoFill);
    }
}

// Записывает файл PPTX на диск
pres->Save(u"table_out.pptx", SaveFormat::Pptx);
```

## **Нумерация в Объединенных Ячейках**
Если мы объединяем 2 пары ячеек (1, 1) x (2, 1) и (1, 2) x (2, 2), результирующая таблица будет пронумерована. Этот код на C# демонстрирует процесс:

```c++
const String outPath = u"../out/MergeCells_out.pptx";

// Загружает желаемую презентацию
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Получает доступ к первому слайду
SharedPtr<ISlide> islide = pres->get_Slides()->idx_get(0);

// Определяет столбцы с шириной и строки с высотой
System::ArrayPtr<double> dblCols = System::MakeObject<System::Array<double>>(4, 70);
System::ArrayPtr<double> dblRows = System::MakeObject<System::Array<double>>(4, 70);

// Добавляет форму таблицы на слайд
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
// Объединяет ячейки (1, 1) x (2, 1)
table->MergeCells(table->idx_get(1, 1), table->idx_get(2, 1), false);

// Объединяет ячейки (1, 2) x (2, 2)
table->MergeCells(table->idx_get(1, 2), table->idx_get(2, 2), false);


// Сохраняет файл PPTX на диск
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

Затем мы объединяем ячейки дальше, объединив (1, 1) и (1, 2). Результат - таблица, содержащая большую объединенную ячейку в ее центре:

```c++
// Путь к директории документов.
const String outPath = u"../out/MergeCells_out.pptx";

// Загружает желаемую презентацию
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Получает доступ к первому слайду
SharedPtr<ISlide> islide = pres->get_Slides()->idx_get(0);

// Определяет столбцы с шириной и строки с высотой
System::ArrayPtr<double> dblCols = System::MakeObject<System::Array<double>>(4, 70);
System::ArrayPtr<double> dblRows = System::MakeObject<System::Array<double>>(4, 70);

// Добавляет форму таблицы на слайд
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

// Объединяет ячейки (1, 1) x (2, 1)
table->MergeCells(table->idx_get(1, 1), table->idx_get(2, 1), false);

// Объединяет ячейки (1, 2) x (2, 2)
table->MergeCells(table->idx_get(1, 2), table->idx_get(2, 2), false);


// Сохраняет файл PPTX на диск
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Нумерация в Разделенной Ячейке**
В предыдущих примерах, когда ячейки таблицы были объединены, нумерация или система нумерации в других ячейках не изменялась.

На этот раз мы берем обычную таблицу (таблицу без объединенных ячеек) и затем пытаемся разделить ячейку (1,1), чтобы получить специальную таблицу. Вам может быть интересно обратить внимание на нумерацию этой таблицы, которая может показаться странной. Однако именно так Microsoft PowerPoint нумерует ячейки таблицы, и Aspose.Slides делает то же самое.

Этот код на C++ демонстрирует описанный нами процесс:

```c++
// Путь к директории документов.
const String outPath = u"../out/CellSplit_out.pptx";

// Загружает желаемую презентацию
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Получает доступ к первому слайду
SharedPtr<ISlide> islide = pres->get_Slides()->idx_get(0);

// Определяет столбцы с шириной и строки с высотой
System::ArrayPtr<double> dblCols = System::MakeObject<System::Array<double>>(4, 70);
System::ArrayPtr<double> dblRows = System::MakeObject<System::Array<double>>(4, 70);

// Добавляет форму таблицы на слайд
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

// Объединяет ячейки (1, 1) x (2, 1)
table->MergeCells(table->idx_get(1, 1), table->idx_get(2, 1), false);

// Объединяет ячейки (1, 2) x (2, 2)
table->MergeCells(table->idx_get(1, 2), table->idx_get(2, 2), false);

// Разделяет ячейку (1, 1). 
table->idx_get(1, 1)->SplitByWidth(table->idx_get(2, 1)->get_Width() / 2);

// Сохраняет файл PPTX на диск
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Изменение Цвета Фона Ячейки Таблицы**

Этот код на C++ показывает, как изменить цвет фона ячейки таблицы:

``` cpp

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);
        
auto dblCols = System::MakeArray<double>({150, 150, 150, 150});
auto dblRows = System::MakeArray<double>({50, 50, 50, 50, 50});
        
// создайте новую таблицу
auto table = slide->get_Shapes()->AddTable(50.0f, 50.0f, dblCols, dblRows);
        
// установите цвет фона для ячейки 
System::SharedPtr<ICell> cell = table->idx_get(2, 3);
cell->get_CellFormat()->get_FillFormat()->set_FillType(Aspose::Slides::FillType::Solid);
cell->get_CellFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());
        
presentation->Save(u"cell_background_color.pptx", Aspose::Slides::Export::SaveFormat::Pptx);

```

## **Добавление Изображения Внутри Ячейки Таблицы**
1. Создайте экземпляр класса `Presentation`.
2. Получите ссылку на слайд через его индекс.
3. Определите массив столбцов с шириной.
4. Определите массив строк с высотой.
5. Добавьте таблицу на слайд с помощью метода `AddTable`. 
6. Создайте объект `Bitmap`, чтобы сохранить файл изображения.
7. Добавьте изображение в объект `IPPImage`.
8. Установите `FillFormat` для ячейки таблицы в `Picture`.
9. Добавьте изображение в первую ячейку таблицы.
10. Сохраните измененную презентацию в виде файла PPTX.

Этот код на C# показывает, как поместить изображение внутри ячейки таблицы при создании таблицы:

```c++
// Путь к директории документов.
const String outPath = u"../out/Image_In_TableCell_out.pptx";
const String ImagePath = u"../templates/Tulips.jpg";

// Загружает желаемую презентацию
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Получает доступ к первому слайду
SharedPtr<ISlide> islide = pres->get_Slides()->idx_get(0);

// Определяет столбцы с шириной и строки с высотой
System::ArrayPtr<double> dblCols = System::MakeObject<System::Array<double>>(4, 150);
System::ArrayPtr<double> dblRows = System::MakeObject<System::Array<double>>(4, 100);
System::ArrayPtr<double> total_for_Cat = System::MakeObject<System::Array<double>>(5, 0);

// Добавляет форму таблицы на слайд
auto tbl = islide->get_Shapes()->AddTable(50, 50, dblCols, dblRows);

// Получает изображение
auto img = Images::FromFile(ImagePath);

// Добавляет изображение в коллекцию изображений презентации
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(img);


// Добавляет изображение в первую ячейку таблицы
tbl->idx_get(0, 0)->get_FillFormat()->set_FillType(FillType::Picture);
tbl->idx_get(0, 0)->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);
tbl->idx_get(0, 0)->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(imgx);

// Сохраняет файл PPTX на диск
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```