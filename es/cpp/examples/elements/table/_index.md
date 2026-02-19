---
title: Tabla
type: docs
weight: 120
url: /es/cpp/examples/elements/table/
keywords:
- ejemplo de código
- tabla
- PowerPoint
- OpenDocument
- presentación
- C++
- Aspose.Slides
description: "Trabaje con tablas en Aspose.Slides for C++: cree, formatee, combine celdas, aplique estilos, importe datos y exporte con ejemplos en C++ para PPT, PPTX y ODP."
---
Ejemplos de cómo agregar tablas, acceder a ellas, eliminarlas y combinar celdas usando **Aspose.Slides for C++**.

## **Agregar una tabla**

Cree una tabla sencilla con dos filas y dos columnas.

```cpp
static void AddTable()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto widths = MakeArray<double>({ 80, 80 });
    auto heights = MakeArray<double>({ 30, 30 });
    auto table = slide->get_Shapes()->AddTable(50, 50, widths, heights);

    presentation->Dispose();
}
```

## **Acceder a una tabla**

Recupere la primera forma de tabla en la diapositiva.

```cpp
static void AccessTable()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto widths = MakeArray<double>({ 80, 80 });
    auto heights = MakeArray<double>({ 30, 30 });
    auto table = slide->get_Shapes()->AddTable(50, 50, widths, heights);

    // Accede a la primera tabla en la diapositiva.
    auto firstTable = SharedPtr<ITable>();
    for (auto&& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<ITable>(shape))
        {
            firstTable = ExplicitCast<ITable>(shape);
            break;
        }
    }

    presentation->Dispose();
}
```

## **Eliminar una tabla**

Elimine una tabla de una diapositiva.

```cpp
static void RemoveTable()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto widths = MakeArray<double>({ 80, 80 });
    auto heights = MakeArray<double>({ 30, 30 });
    auto table = slide->get_Shapes()->AddTable(50, 50, widths, heights);

    slide->get_Shapes()->Remove(table);

    presentation->Dispose();
}
```

## **Combinar celdas de tabla**

Combine celdas adyacentes de una tabla en una sola celda.

```cpp
static void MergeTableCells()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto widths = MakeArray<double>({ 80, 80 });
    auto heights = MakeArray<double>({ 30, 30 });
    auto table = slide->get_Shapes()->AddTable(50, 50, widths, heights);

    // Combinar celdas.
    table->MergeCells(table->idx_get(0, 0), table->idx_get(1, 1), false);

    presentation->Dispose();
}
```