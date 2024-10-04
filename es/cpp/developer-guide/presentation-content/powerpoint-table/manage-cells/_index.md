---
title: Administrar Celdas
type: docs
weight: 30
url: /cpp/manage-cells/
keywords: "Tabla, celdas combinadas, celdas divididas, imagen en celda de tabla, C++, CPP, Aspose.Slides para C++"
description: "Celdas de tabla en presentaciones de PowerPoint en C++"
---

## **Identificar Celda Combinada**
1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Obtén la tabla de la primera diapositiva. 
3. Itera a través de las filas y columnas de la tabla para encontrar celdas combinadas.
4. Imprime un mensaje cuando se encuentran celdas combinadas.

Este código en C++ te muestra cómo identificar celdas de tabla combinadas en una presentación:

```cpp
auto pres = System::MakeObject<Presentation>(u"SomePresentationWithTable.pptx");
auto table = System::AsCast<ITable>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));

// asumiendo que Slide#0.Shape#0 es una tabla
for (int32_t i = 0; i < table->get_Rows()->get_Count(); i++)
{
    for (int32_t j = 0; j < table->get_Columns()->get_Count(); j++)
    {
        auto currentCell = table->get_Rows()->idx_get(i)->idx_get(j);
        if (currentCell->get_IsMergedCell())
        {
            Console::WriteLine(String::Format(u"Celda {0};{1} es parte de la celda combinada con RowSpan={2} y ColSpan={3} comenzando desde la Celda {4};{5}.", 
                i, j, currentCell->get_RowSpan(), currentCell->get_ColSpan(), currentCell->get_FirstRowIndex(), currentCell->get_FirstColumnIndex()));
        }
    }
}
```

## **Eliminar el Borde de las Celdas de la Tabla**
1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Obtén la referencia de una diapositiva a través de su índice. 
3. Define un arreglo de columnas con ancho.
4. Define un arreglo de filas con altura.
5. Agrega una tabla a la diapositiva a través del método `AddTable`.
6. Itera por cada celda para limpiar los bordes superior, inferior, derecho e izquierdo.
7. Guarda la presentación modificada como un archivo PPTX.

Este código en C++ te muestra cómo eliminar los bordes de las celdas de una tabla:

```cpp
// Instancia la clase Presentation que representa un archivo PPTX
auto pres = MakeObject<Presentation>();
// Accede a la primera diapositiva
auto sld = pres->get_Slides()->idx_get(0);

// Define columnas con anchos y filas con alturas
auto dblCols = MakeArray<double>({ 50, 50, 50, 50 });
auto dblRows = MakeArray<double>({ 50, 30, 30, 30, 30 });

// Agrega una forma de tabla a la diapositiva
auto tbl = sld->get_Shapes()->AddTable(100.0f, 50.0f, dblCols, dblRows);

// Establece el formato de borde para cada celda
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

// Escribe el archivo PPTX en el disco
pres->Save(u"table_out.pptx", SaveFormat::Pptx);
```

## **Numeración en Celdas Combinadas**
Si combinamos 2 pares de celdas (1, 1) x (2, 1) y (1, 2) x (2, 2), la tabla resultante será numerada. Este código en C# demuestra el proceso:

```c++
const String outPath = u"../out/MergeCells_out.pptx";

// Carga la presentación deseada
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Accede a la primera diapositiva
SharedPtr<ISlide> islide = pres->get_Slides()->idx_get(0);

// Define columnas con anchos y filas con alturas
System::ArrayPtr<double> dblCols = System::MakeObject<System::Array<double>>(4, 70);
System::ArrayPtr<double> dblRows = System::MakeObject<System::Array<double>>(4, 70);

// Agrega una forma de tabla a la diapositiva
SharedPtr<ITable> table = islide->get_Shapes()->AddTable(100, 50, dblCols, dblRows);


// Establece el formato de borde para cada celda
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
// Combina celdas (1, 1) x (2, 1)
table->MergeCells(table->idx_get(1, 1), table->idx_get(2, 1), false);

// Combina celdas (1, 2) x (2, 2)
table->MergeCells(table->idx_get(1, 2), table->idx_get(2, 2), false);


// Guarda el archivo PPTX en el disco
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

Luego combinamos las celdas aún más combinando (1, 1) y (1, 2). El resultado es una tabla que contiene una gran celda combinada en su centro: 

```c++
// La ruta al directorio de documentos.
const String outPath = u"../out/MergeCells_out.pptx";

// Carga la presentación deseada
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Accede a la primera diapositiva
SharedPtr<ISlide> islide = pres->get_Slides()->idx_get(0);

// Define columnas con anchos y filas con alturas
System::ArrayPtr<double> dblCols = System::MakeObject<System::Array<double>>(4, 70);
System::ArrayPtr<double> dblRows = System::MakeObject<System::Array<double>>(4, 70);

// Agrega una forma de tabla a la diapositiva
SharedPtr<ITable> table = islide->get_Shapes()->AddTable(100, 50, dblCols, dblRows);


// Establece el formato de borde para cada celda
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

// Combina celdas (1, 1) x (2, 1)
table->MergeCells(table->idx_get(1, 1), table->idx_get(2, 1), false);

// Combina celdas (1, 2) x (2, 2)
table->MergeCells(table->idx_get(1, 2), table->idx_get(2, 2), false);


// Guarda el archivo PPTX en el disco
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Numeración en Celda Dividida**
En ejemplos anteriores, cuando las celdas de la tabla se combinaban, la numeración o el sistema de números en otras celdas no cambiaba. 

Esta vez, tomamos una tabla normal (una tabla sin celdas combinadas) y luego intentamos dividir la celda (1,1) para obtener una tabla especial. Puede que desee prestar atención a la numeración de esta tabla, que puede considerarse extraña. Sin embargo, así es como Microsoft PowerPoint numera las celdas de la tabla y Aspose.Slides hace lo mismo. 

Este código en C++ demuestra el proceso que describimos:

```c++
// La ruta al directorio de documentos.
const String outPath = u"../out/CellSplit_out.pptx";

// Carga la presentación deseada
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Accede a la primera diapositiva
SharedPtr<ISlide> islide = pres->get_Slides()->idx_get(0);

// Define columnas con anchos y filas con alturas
System::ArrayPtr<double> dblCols = System::MakeObject<System::Array<double>>(4, 70);
System::ArrayPtr<double> dblRows = System::MakeObject<System::Array<double>>(4, 70);

// Agrega una forma de tabla a la diapositiva
SharedPtr<ITable> table = islide->get_Shapes()->AddTable(100, 50, dblCols, dblRows);


// Establece el formato de borde para cada celda
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

// Combina celdas (1, 1) x (2, 1)
table->MergeCells(table->idx_get(1, 1), table->idx_get(2, 1), false);

// Combina celdas (1, 2) x (2, 2)
table->MergeCells(table->idx_get(1, 2), table->idx_get(2, 2), false);

// divide la celda (1, 1). 
table->idx_get(1, 1)->SplitByWidth(table->idx_get(2, 1)->get_Width() / 2);

// Guarda el archivo PPTX en el disco
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Cambiar el Color de Fondo de una Celda de Tabla**

Este código en C++ te muestra cómo cambiar el color de fondo de una celda de tabla:

```cpp

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);
        
auto dblCols = System::MakeArray<double>({150, 150, 150, 150});
auto dblRows = System::MakeArray<double>({50, 50, 50, 50, 50});
        
// crea una nueva tabla
auto table = slide->get_Shapes()->AddTable(50.0f, 50.0f, dblCols, dblRows);
        
// establece el color de fondo para una celda 
System::SharedPtr<ICell> cell = table->idx_get(2, 3);
cell->get_CellFormat()->get_FillFormat()->set_FillType(Aspose::Slides::FillType::Solid);
cell->get_CellFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());
        
presentation->Save(u"cell_background_color.pptx", Aspose::Slides::Export::SaveFormat::Pptx);

```

## **Agregar Imagen dentro de la Celda de la Tabla**
1. Crea una instancia de la clase `Presentation`.
2. Obtén la referencia de una diapositiva a través de su índice.
3. Define un arreglo de columnas con ancho.
4. Define un arreglo de filas con altura.
5. Agrega una tabla a la diapositiva a través del método `AddTable`. 
6. Crea un objeto `Bitmap` para contener el archivo de imagen.
7. Agrega la imagen bitmap al objeto `IPPImage`.
8. Establece el `FillFormat` para la Celda de la Tabla a `Picture`.
9. Agrega la imagen a la primera celda de la tabla.
10. Guarda la presentación modificada como un archivo PPTX.

Este código en C# te muestra cómo colocar una imagen dentro de una celda de tabla al crear una tabla:

```cpp
// La ruta al directorio de documentos.
const String outPath = u"../out/Image_In_TableCell_out.pptx";
const String ImagePath = u"../templates/Tulips.jpg";

// Carga la presentación deseada
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Accede a la primera diapositiva
SharedPtr<ISlide> islide = pres->get_Slides()->idx_get(0);

// Define columnas con anchos y filas con alturas
System::ArrayPtr<double> dblCols = System::MakeObject<System::Array<double>>(4, 150);
System::ArrayPtr<double> dblRows = System::MakeObject<System::Array<double>>(4, 100);
System::ArrayPtr<double> total_for_Cat = System::MakeObject<System::Array<double>>(5, 0);

// Agrega una forma de tabla a la diapositiva
auto tbl = islide->get_Shapes()->AddTable(50, 50, dblCols, dblRows);

// Obtiene la imagen
auto img = Images::FromFile(ImagePath);

// Agrega la imagen a la colección de imágenes de la presentación
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(img);


// Agrega la imagen a la primera celda de la tabla
tbl->idx_get(0, 0)->get_FillFormat()->set_FillType(FillType::Picture);
tbl->idx_get(0, 0)->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);
tbl->idx_get(0, 0)->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(imgx);

// Guarda el archivo PPTX en el disco
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```