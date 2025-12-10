---
title: Gestionar celdas de tabla en presentaciones usando C++
linktitle: Gestionar celdas
type: docs
weight: 30
url: /es/cpp/manage-cells/
keywords:
- celda de tabla
- combinar celdas
- eliminar borde
- dividir celda
- imagen en celda
- color de fondo
- PowerPoint
- presentación
- C++
- Aspose.Slides
description: "Administre sin esfuerzo las celdas de tabla en PowerPoint con Aspose.Slides para C++. Domine el acceso, la modificación y el estilo de las celdas de forma rápida para una automatización de diapositivas perfecta."
---

## **Identificar una celda combinada**
1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Obtener la tabla de la primera diapositiva.
3. Recorrer las filas y columnas de la tabla para encontrar celdas combinadas.
4. Imprimir un mensaje cuando se encuentren celdas combinadas.

``` cpp
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
            Console::WriteLine(String::Format(u"Cell {0};{1} is a part of merged cell with RowSpan={2} and ColSpan={3} starting from Cell {4};{5}.", 
                i, j, currentCell->get_RowSpan(), currentCell->get_ColSpan(), currentCell->get_FirstRowIndex(), currentCell->get_FirstColumnIndex()));
        }
    }
}
```


## **Eliminar bordes de celdas de tabla**
1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Obtener la referencia de una diapositiva mediante su índice.
3. Definir una matriz de columnas con ancho.
4. Definir una matriz de filas con altura.
5. Agregar una tabla a la diapositiva mediante el método `AddTable`.
6. Recorrer cada celda para limpiar los bordes superior, inferior, derecho e izquierdo.
7. Guardar la presentación modificada como archivo PPTX.

``` cpp
// Instancia la clase Presentation que representa un archivo PPTX
auto pres = MakeObject<Presentation>();
// Accede a la primera diapositiva
auto sld = pres->get_Slides()->idx_get(0);

// Define columnas con anchuras y filas con alturas
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

// Escribe el archivo PPTX en disco
pres->Save(u"table_out.pptx", SaveFormat::Pptx);
```


## **Numeración en celdas combinadas**
Si combinamos 2 pares de celdas (1, 1) x (2, 1) y (1, 2) x (2, 2), la tabla resultante tendrá numeración. Este código C# demuestra el proceso:
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
// Fusiona las celdas (1, 1) x (2, 1)
table->MergeCells(table->idx_get(1, 1), table->idx_get(2, 1), false);

// Fusiona las celdas (1, 2) x (2, 2)
table->MergeCells(table->idx_get(1, 2), table->idx_get(2, 2), false);


// Guarda el archivo PPTX en disco
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


Luego combinamos más celdas fusionando (1, 1) y (1, 2). El resultado es una tabla que contiene una gran celda combinada en su centro:
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

// Fusiona celdas (1, 1) x (2, 1)
table->MergeCells(table->idx_get(1, 1), table->idx_get(2, 1), false);

// Fusiona celdas (1, 2) x (2, 2)
table->MergeCells(table->idx_get(1, 2), table->idx_get(2, 2), false);


// Guarda el archivo PPTX en disco
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


## **Numeración en una celda dividida**
En los ejemplos anteriores, cuando las celdas de la tabla se combinaban, la numeración o el sistema de numeración en las demás celdas no cambiaba.  

Esta vez, tomamos una tabla normal (una tabla sin celdas combinadas) y luego intentamos dividir la celda (1,1) para obtener una tabla especial. Puede que desee prestar atención a la numeración de esta tabla, que puede parecer extraña. Sin embargo, así es como Microsoft PowerPoint numera las celdas de tabla y Aspose.Slides hace lo mismo.  

Este código C++ demuestra el proceso que describimos:
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

// Fusiona celdas (1, 1) x (2, 1)
table->MergeCells(table->idx_get(1, 1), table->idx_get(2, 1), false);

// Fusiona celdas (1, 2) x (2, 2)
table->MergeCells(table->idx_get(1, 2), table->idx_get(2, 2), false);

// Divide la celda (1, 1). 
table->idx_get(1, 1)->SplitByWidth(table->idx_get(2, 1)->get_Width() / 2);

// Guarda el archivo PPTX en disco
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


## **Cambiar el color de fondo de la celda de tabla**
Este código C++ muestra cómo cambiar el color de fondo de una celda de tabla:
``` cpp

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


## **Agregar una imagen dentro de una celda de tabla**
1. Crear una instancia de la clase `Presentation`.
2. Obtener la referencia de una diapositiva mediante su índice.
3. Definir una matriz de columnas con ancho.
4. Definir una matriz de filas con altura.
5. Agregar una tabla a la diapositiva mediante el método `AddTable`.
6. Crear un objeto `Bitmap` para contener el archivo de imagen.
7. Agregar la imagen bitmap al objeto `IPPImage`.
8. Establecer el `FillFormat` de la celda de tabla a `Picture`.
9. Agregar la imagen a la primera celda de la tabla.
10. Guardar la presentación modificada como archivo PPTX

```c++
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

// Guarda el archivo PPTX en disco
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


## **FAQ**

**¿Puedo establecer diferentes grosores y estilos de línea para los distintos lados de una sola celda?**

Sí. Los bordes [superior](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_bordertop/)/[inferior](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_borderbottom/)/[izquierdo](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_borderleft/)/[derecho](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_borderright/) tienen propiedades independientes, por lo que el grosor y el estilo de cada lado pueden variar. Esto se deduce lógicamente del control de bordes por lado para una celda demostrado en el artículo.

**¿Qué ocurre con la imagen si cambio el tamaño de la columna/fila después de establecer una imagen como fondo de la celda?**

El comportamiento depende del [modo de relleno](https://reference.aspose.com/slides/cpp/aspose.slides/picturefillmode/) (estiramiento/azulejo). Con estiramiento, la imagen se ajusta a la nueva celda; con azulejo, los mosaicos se recalculan. El artículo menciona los modos de visualización de la imagen en una celda.

**¿Puedo asignar un hipervínculo a todo el contenido de una celda?**

[Hyperlinks](/slides/es/cpp/manage-hyperlinks/) se establecen a nivel de texto (porción) dentro del marco de texto de la celda o a nivel de toda la tabla/forma. En la práctica, asignas el enlace a una porción o a todo el texto de la celda.

**¿Puedo establecer diferentes fuentes dentro de una sola celda?**

Sí. El marco de texto de una celda admite [porciones](https://reference.aspose.com/slides/cpp/aspose.slides/portion/) (runs) con formato independiente: familia de fuente, estilo, tamaño y color.