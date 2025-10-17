---
title: Table
type: docs
weight: 120
url: /cpp/examples/elements/table/
keywords:
- code example
- table
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Work with tables in Aspose.Slides for C++: create, format, merge cells, apply styles, import data, and export with C++ examples for PPT, PPTX, and ODP."
---

Examples for adding tables, accessing them, removing them, and merging cells using **Aspose.Slides for C++**.

## **Add a Table**

Create a simple table with two rows and two columns.

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

## **Access a Table**

Retrieve the first table shape on the slide.

```cpp
static void AccessTable()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto widths = MakeArray<double>({ 80, 80 });
    auto heights = MakeArray<double>({ 30, 30 });
    auto table = slide->get_Shapes()->AddTable(50, 50, widths, heights);

    // Access first table on slide.
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

## **Remove a Table**

Delete a table from a slide.

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

## **Merge Table Cells**

Merge adjacent cells of a table into a single cell.

```cpp
static void MergeTableCells()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto widths = MakeArray<double>({ 80, 80 });
    auto heights = MakeArray<double>({ 30, 30 });
    auto table = slide->get_Shapes()->AddTable(50, 50, widths, heights);

    // Merge cells.
    table->MergeCells(table->idx_get(0, 0), table->idx_get(1, 1), false);

    presentation->Dispose();
}
```
