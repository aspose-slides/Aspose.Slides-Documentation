---
title: Administrar Tabla
type: docs
weight: 10
url: /es/cpp/manage-table/
keywords: "Tabla, crear tabla, acceder a tabla, relación de aspecto de tabla, presentación de PowerPoint, C++, Aspose.Slides para C++"
description: "Crear y gestionar tablas en presentaciones de PowerPoint en C++"
---

Una tabla en PowerPoint es una forma eficiente de mostrar y retratar información. La información en una cuadrícula de celdas (organizadas en filas y columnas) es clara y fácil de entender.

Aspose.Slides proporciona la clase [Table](https://reference.aspose.com/slides/cpp/aspose.slides/table/), la interfaz [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/), la clase [Cell](https://reference.aspose.com/slides/cpp/aspose.slides/cell/), la interfaz [ICell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/) y otros tipos para permitirte crear, actualizar y gestionar tablas en todo tipo de presentaciones.

## **Crear Tabla desde Cero**

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Obtén la referencia de una diapositiva a través de su índice.
3. Define un arreglo de `columnWidth`.
4. Define un arreglo de `rowHeight`.
5. Agrega un objeto [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) a la diapositiva a través del método [AddTable()](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addtable/).
6. Itera a través de cada [ICell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/) para aplicar formato a los bordes superior, inferior, derecho e izquierdo.
7. Combina las dos primeras celdas de la primera fila de la tabla.
8. Accede al [TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/textframe/) de un [ICell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/). 
9. Agrega algún texto al [TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/textframe/).
10. Guarda la presentación modificada.

Este código C++ te muestra cómo crear una tabla en una presentación:

```c++
// Instancia una clase Presentation que representa un archivo PPTX
auto pres = System::MakeObject<Presentation>();

// Accede a la primera diapositiva
auto sld = pres->get_Slides()->idx_get(0);

// Define columnas con anchos y filas con alturas
auto dblCols = System::MakeArray<double>({ 50, 50, 50 });
auto dblRows = System::MakeArray<double>({ 50, 30, 30, 30, 30 });

// Agrega una forma de tabla a la diapositiva
auto tbl = sld->get_Shapes()->AddTable(100.0f, 50.0f, dblCols, dblRows);

// Establece el formato de borde para cada celda
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
// Combina las celdas 1 y 2 de la fila 1
tbl->MergeCells(tbl->get_Rows()->idx_get(0)->idx_get(0), tbl->get_Rows()->idx_get(1)->idx_get(1), false);

// Agrega algo de texto a la celda combinada
tbl->get_Rows()->idx_get(0)->idx_get(0)->get_TextFrame()->set_Text(u"Celdas Combinadas");

// Guarda la presentación en disco
pres->Save(u"table.pptx", SaveFormat::Pptx);
```

## **Numeración en Tabla Estándar**

En una tabla estándar, la numeración de celdas es sencilla y comienza desde cero. La primera celda en una tabla se indexa como 0,0 (columna 0, fila 0).

Por ejemplo, las celdas en una tabla con 4 columnas y 4 filas están numeradas de esta manera:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Este código C++ te muestra cómo especificar la numeración para celdas en una tabla:

```c++
// Instancia una clase Presentation que representa un archivo PPTX
auto pres = System::MakeObject<Presentation>();

// Accede a la primera diapositiva
auto sld = pres->get_Slides()->idx_get(0);

// Define columnas con anchos y filas con alturas
auto dblCols = System::MakeArray<double>({ 70, 70, 70, 70 });
auto dblRows = System::MakeArray<double>({ 70, 70, 70, 70 });

// Agrega una forma de tabla a la diapositiva
auto tbl = sld->get_Shapes()->AddTable(100.0f, 50.0f, dblCols, dblRows);

// Establece el formato de borde para cada celda
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

// Guarda la presentación en disco
pres->Save(u"StandardTables_out.pptx", SaveFormat::Pptx);
```

## **Acceder a una Tabla Existente**

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Obtén una referencia a la diapositiva que contiene la tabla a través de su índice.
3. Crea un objeto [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) y configúralo en null.
4. Itera a través de todos los objetos [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) hasta que se encuentre la tabla.

   Si sospechas que la diapositiva con la que estás tratando contiene una sola tabla, puedes simplemente verificar todas las formas que contiene. Cuando se identifica una forma como una tabla, puedes convertirla a un objeto [Table](https://reference.aspose.com/slides/cpp/aspose.slides/table/). Pero si la diapositiva con la que estás tratando contiene varias tablas, entonces es mejor buscar la tabla que necesitas a través de su [set_AlternativeText()](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/set_alternativetext/).

5. Utiliza el objeto [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) para trabajar con la tabla. En el ejemplo a continuación, añadimos una nueva fila a la tabla.
6. Guarda la presentación modificada.

Este código C++ te muestra cómo acceder y trabajar con una tabla existente:

```c++
// Instancia una clase Presentation que representa un archivo PPTX
auto pres = System::MakeObject<Presentation>(u"UpdateExistingTable.pptx");

// Accede a la primera diapositiva
auto sld = pres->get_Slides()->idx_get(0);

// Inicializa Table en null
System::SharedPtr<ITable> tbl;

// Itera a través de las formas y establece una referencia a la tabla encontrada
for (const auto& shp : System::IterateOver(sld->get_Shapes()))
{
    if (System::ObjectExt::Is<ITable>(shp))
    {
        tbl = System::ExplicitCast<ITable>(shp);
    }
}

// Establece el texto para la primera columna de la segunda fila
tbl->idx_get(0, 1)->get_TextFrame()->set_Text(u"Nueva");

// Guarda la presentación modificada en disco
pres->Save(u"table1_out.pptx", SaveFormat::Pptx);
```


## **Alinear Texto en la Tabla**

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Obtén la referencia de una diapositiva a través de su índice.
3. Agrega un objeto [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) a la diapositiva.
4. Accede a un objeto [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) de la tabla.
5. Accede al [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) [IParagraph](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/).
6. Alinea el texto verticalmente.
7. Guarda la presentación modificada.

Este código C++ te muestra cómo alinear el texto en una tabla:

```c++
// Crea una instancia de la clase Presentation
auto presentation = System::MakeObject<Presentation>();

// Obtiene la primera diapositiva
auto slide = presentation->get_Slides()->idx_get(0);

// Define columnas con anchos y filas con alturas
auto dblCols = System::MakeArray<double>({ 120, 120, 120, 120 });
auto dblRows = System::MakeArray<double>({ 100, 100, 100, 100 });

// Agrega la forma de tabla a la diapositiva
auto tbl = slide->get_Shapes()->AddTable(100.0f, 50.0f, dblCols, dblRows);
tbl->idx_get(1, 0)->get_TextFrame()->set_Text(u"10");
tbl->idx_get(2, 0)->get_TextFrame()->set_Text(u"20");
tbl->idx_get(3, 0)->get_TextFrame()->set_Text(u"30");

// Accede al marco de texto
auto txtFrame = tbl->idx_get(0, 0)->get_TextFrame();

// Crea el objeto Paragraph para el marco de texto
auto paragraph = txtFrame->get_Paragraphs()->idx_get(0);

// Crea el objeto Portion para el párrafo
auto portion = paragraph->get_Portions()->idx_get(0);
portion->set_Text(u"Texto aquí");
portion->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
portion->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

// Alinea el texto verticalmente
auto cell = tbl->idx_get(0, 0);
cell->set_TextAnchorType(TextAnchorType::Center);
cell->set_TextVerticalType(TextVerticalType::Vertical270);

// Guarda la presentación en disco
presentation->Save(u"Vertical_Align_Text_out.pptx", SaveFormat::Pptx);
```

## **Establecer Formato de Texto a Nivel de Tabla**

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Obtén la referencia de una diapositiva a través de su índice.
3. Accede a un objeto [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) de la diapositiva.
4. Establece el [set_FontHeight()](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_fontheight/) para el texto.
5. Establece el [set_Alignment()](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_alignment/) y [set_MarginRight()](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_marginright/).
6. Establece el [set_TextVerticalType()](https://reference.aspose.com/slides/cpp/aspose.slides/textframeformat/set_textverticaltype/).
7. Guarda la presentación modificada.

Este código C++ te muestra cómo aplicar tus opciones de formato preferidas al texto en una tabla:

```c++
// Crea una instancia de la clase Presentation
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);

// Supongamos que la primera forma en la primera diapositiva es una tabla
auto someTable = System::AsCast<ITable>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));

// Establece la altura de fuente de las celdas de la tabla
auto portionFormat = System::MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25.0f);
someTable->SetTextFormat(portionFormat);

// Establece la alineación del texto de las celdas de la tabla y el margen derecho en una llamada
auto paragraphFormat = System::MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20.0f);
someTable->SetTextFormat(paragraphFormat);

// Establece el tipo de texto vertical de las celdas de la tabla
auto textFrameFormat = System::MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
someTable->SetTextFormat(textFrameFormat);

presentation->Save(u"result.pptx", SaveFormat::Pptx);
```

## **Obtener Propiedades de Estilo de Tabla**

Aspose.Slides te permite recuperar las propiedades de estilo de una tabla para que puedas usar esos detalles para otra tabla o en otro lugar. Este código C++ te muestra cómo obtener las propiedades de estilo de un estilo preestablecido de tabla:

```c++
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slide(0)->get_Shapes();
auto table = System::ExplicitCast<ITable>(shapes->AddTable(10, 10, System::MakeArray<double>({100, 150}), System::MakeArray<double>({5, 5, 5})));

table->set_StylePreset(TableStylePreset::DarkStyle1);
pres->Save(u"table.pptx", SaveFormat::Pptx);
```

## **Bloquear Relación de Aspecto de Tabla**

La relación de aspecto de una forma geométrica es la relación de sus tamaños en diferentes dimensiones. Aspose.Slides proporciona la propiedad `AspectRatioLocked()` para permitirte bloquear la configuración de relación de aspecto para tablas y otras formas.

Este código C++ te muestra cómo bloquear la relación de aspecto para una tabla:

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto table = System::ExplicitCast<ITable>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));

Console::WriteLine(u"Bloquear relación de aspecto establecido: {0}", table->get_GraphicalObjectLock()->get_AspectRatioLocked());

table->get_GraphicalObjectLock()->set_AspectRatioLocked(!table->get_GraphicalObjectLock()->get_AspectRatioLocked());

Console::WriteLine(u"Bloquear relación de aspecto establecido: {0}", table->get_GraphicalObjectLock()->get_AspectRatioLocked());

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```