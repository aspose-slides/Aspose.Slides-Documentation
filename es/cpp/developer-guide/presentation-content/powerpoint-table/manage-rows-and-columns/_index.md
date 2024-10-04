---
title: Gestionar Filas y Columnas
type: docs
weight: 20
url: /cpp/manage-rows-and-columns/
keywords: "Tabla, filas y columnas de tabla, presentación de PowerPoint, C++, CPP, Aspose.Slides para C++"
description: "Gestionar filas y columnas de tablas en presentaciones de PowerPoint en C++"

---

Para permitirte gestionar las filas y columnas de una tabla en una presentación de PowerPoint, Aspose.Slides proporciona la clase [Table](https://reference.aspose.com/slides/cpp/aspose.slides/table/), la interfaz [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) y muchos otros tipos.

## **Establecer la Primera Fila como Encabezado**

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) y carga la presentación.
2. Obtén la referencia de una diapositiva a través de su índice.
3. Crea un objeto [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) y configúralo como nulo.
4. Itera a través de todos los objetos [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) para encontrar la tabla correspondiente.
5. Establece la primera fila de la tabla como su encabezado.

Este código C++ te muestra cómo establecer la primera fila de una tabla como su encabezado:

```c++
// Instancia la clase Presentation 
auto pres = System::MakeObject<Presentation>(u"table.pptx");

// Accede a la primera diapositiva
auto sld = pres->get_Slides()->idx_get(0);

// Inicializa el TableEx nulo
SharedPtr<ITable> tbl;

// Itera a través de las formas y establece una referencia a la tabla
for (const auto& shp : sld->get_Shapes())
{
    if (ObjectExt::Is<ITable>(shp))
    {
        tbl = System::ExplicitCast<ITable>(shp);
    }
}

// Establece la primera fila de una tabla como su encabezado 
tbl->set_FirstRow(true);
```

## **Clonar la Fila o Columna de la Tabla**

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) y carga la presentación,
2. Obtén la referencia de una diapositiva a través de su índice.
3. Define un arreglo de `columnWidth`.
4. Define un arreglo de `rowHeight`.
5. Agrega un objeto [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) a la diapositiva a través del método [AddTable()](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addtable/).
6. Clona la fila de la tabla.
7. Clona la columna de la tabla.
8. Guarda la presentación modificada.

Este código C++ te muestra cómo clonar la fila o columna de una tabla de PowerPoint:

```c++
// La ruta al directorio de documentos.
const String outPath = u"../out/CloningInTable_out.pptx";

// Instancia la clase Presentation
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Accede a la primera diapositiva
SharedPtr<ISlide> islide = pres->get_Slides()->idx_get(0);

// Define columnas con anchos y filas con alturas
System::ArrayPtr<double> dblCols = System::MakeObject<System::Array<double>>(4, 70);
System::ArrayPtr<double> dblRows = System::MakeObject<System::Array<double>>(4, 70);

// Agrega una forma de tabla a la diapositiva
SharedPtr<ITable> table = islide->get_Shapes()->AddTable(100, 50, dblCols, dblRows);

// Establece el formato del borde para cada celda
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

//AddClone agrega una fila al final de la tabla
table->get_Rows()->AddClone(table->get_Rows()->idx_get(0), false);

//InsertClone agrega una fila en una posición específica en una tabla
table->get_Rows()->InsertClone(2, table->get_Rows()->idx_get(0), false);

//AddClone agrega una columna al final de la tabla
table->get_Columns()->AddClone(table->get_Columns()->idx_get(0), false);

//InsertClone agrega una columna en una posición específica en una tabla
table->get_Columns()->InsertClone(2, table->get_Columns()->idx_get(0), false);

// Guarda la presentación en disco
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Eliminar Fila o Columna de la Tabla**

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) y carga la presentación,
2. Obtén la referencia de una diapositiva a través de su índice.
3. Define un arreglo de `columnWidth`.
4. Define un arreglo de `rowHeight`.
5. Agrega un objeto [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) a la diapositiva a través del método [AddTable()](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addtable/).
6. Elimina la fila de la tabla.
7. Elimina la columna de la tabla.
8. Guarda la presentación modificada.

Este código C++ te muestra cómo eliminar una fila o columna de una tabla:

```c++
// La ruta al directorio de documentos.
const String outPath = u"../out/RemovingRowColumn_out.pptx";

// Instancia la clase Presentation
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Accede a la primera diapositiva
SharedPtr<ISlide> islide = pres->get_Slides()->idx_get(0);

// Define las columnas con anchos y filas con alturas
System::ArrayPtr<double> dblCols = System::MakeObject<System::Array<double>>(4, 70);
System::ArrayPtr<double> dblRows = System::MakeObject<System::Array<double>>(4, 70);

// Agrega una forma de tabla a la diapositiva
SharedPtr<ITable> table = islide->get_Shapes()->AddTable(100, 50, dblCols, dblRows);

table->get_Rows()->RemoveAt(1, false);
table->get_Columns()->RemoveAt(1, false);

// Une las celdas (1, 1) x (2, 1)
table->MergeCells(table->idx_get(1, 1), table->idx_get(2, 1), false);

// Une las celdas (1, 2) x (2, 2)
table->MergeCells(table->idx_get(1, 2), table->idx_get(2, 2), false);

// Guarda la presentación en disco
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Establecer Formateo de Texto en el Nivel de Fila de Tabla**

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) y carga la presentación,
2. Obtén la referencia de una diapositiva a través de su índice.
3. Accede al objeto [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) relevante desde la diapositiva.
4. Establece la altura de fuente de las celdas de la primera fila usando [set_FontHeight()](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_fontheight/).
5. Establece la alineación y el margen derecho de las celdas de la primera fila usando [set_Alignment()](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_alignment/) y [set_MarginRight()](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_marginright/).
6. Establece el tipo de texto vertical de las celdas de la segunda fila usando [set_TextVerticalType()](https://reference.aspose.com/slides/cpp/aspose.slides/textframeformat/set_textverticaltype/).
7. Guarda la presentación modificada.

Este código C++ demuestra la operación.

```c++
// Crea una instancia de la clase Presentation
auto presentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slides()->idx_get(0);

auto someTable = System::AsCast<ITable>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
// Supongamos que la primera forma en la primera diapositiva es una tabla
// Establece la altura de fuente de las celdas de la primera fila
auto portionFormat = System::MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25.0f);
someTable->get_Rows()->idx_get(0)->SetTextFormat(portionFormat);

// Establece la alineación del texto y el margen derecho de las celdas de la primera fila
auto paragraphFormat = System::MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20.0f);
someTable->get_Rows()->idx_get(0)->SetTextFormat(paragraphFormat);

// Establece el tipo de texto vertical de las celdas de la segunda fila
auto textFrameFormat = System::MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
someTable->get_Rows()->idx_get(1)->SetTextFormat(textFrameFormat);

// Guarda la presentación en disco
presentation->Save(u"result.pptx", SaveFormat::Pptx);
```

## **Establecer Formateo de Texto en el Nivel de Columna de Tabla**

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) y carga la presentación,
2. Obtén la referencia de una diapositiva a través de su índice.
3. Accede al objeto [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) relevante desde la diapositiva.
4. Establece la altura de fuente de las celdas de la primera columna usando [set_FontHeight()](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_fontheight/).
5. Establece la alineación y el margen derecho de las celdas de la primera columna en una sola llamada usando [set_Alignment()](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_alignment/) y [set_MarginRight()](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_marginright/).
6. Establece el tipo de texto vertical de las celdas de la segunda columna usando [set_TextVerticalType()](https://reference.aspose.com/slides/cpp/aspose.slides/textframeformat/set_textverticaltype/).
7. Guarda la presentación modificada.

Este código C++ demuestra la operación:

```c++
// Crea una instancia de la clase Presentation
auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);

auto someTable = System::AsCast<ITable>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
// Supongamos que la primera forma en la primera diapositiva es una tabla

// Establece la altura de fuente de las celdas de la primera columna
auto portionFormat = System::MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25.0f);
someTable->get_Columns()->idx_get(0)->SetTextFormat(portionFormat);

// Establece la alineación del texto y el margen derecho de las celdas de la primera columna en una sola llamada
auto paragraphFormat = System::MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20.0f);
someTable->get_Columns()->idx_get(0)->SetTextFormat(paragraphFormat);

// Establece el tipo de texto vertical de las celdas de la segunda columna
auto textFrameFormat = System::MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
someTable->get_Columns()->idx_get(1)->SetTextFormat(textFrameFormat);

pres->Save(u"result.pptx", SaveFormat::Pptx);
```

## **Obtener Propiedades de Estilo de Tabla**

Aspose.Slides te permite recuperar las propiedades de estilo para una tabla para que puedas utilizar esos detalles en otra tabla o en otra parte. Este código C++ te muestra cómo obtener las propiedades de estilo de un estilo de tabla preestablecido:

```c++
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slide(0)->get_Shapes();
auto table = System::ExplicitCast<ITable>(shapes->AddTable(10, 10, System::MakeArray<double>({100, 150}), System::MakeArray<double>({5, 5, 5})));

table->set_StylePreset(TableStylePreset::DarkStyle1);
pres->Save(u"table.pptx", SaveFormat::Pptx);
```