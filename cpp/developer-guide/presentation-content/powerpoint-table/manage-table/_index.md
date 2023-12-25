---
title: Manage Table
type: docs
weight: 10
url: /cpp/manage-table/
keywords: "Table, create table, access table, table aspect ratio, PowerPoint presentation, C++, Aspose.Slides for C++"
description: "Create and manage table in PowerPoint presentations in C++"
---

A table in PowerPoint is an efficient way of displaying and portraying information. The information in a grid of cells (arranged in rows and columns) is straightforward and easy to understand.

Aspose.Slides provides the [Table](https://reference.aspose.com/slides/cpp/aspose.slides/table/) class, [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) interface, [Cell](https://reference.aspose.com/slides/cpp/aspose.slides/cell/) class, [ICell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/) interface, and other types to allow you to create, update, and manage tables in all kinds of presentations. 

## **Create Table from Scratch**

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) class.
2. Get a slide's reference through its index. 
3. Define an array of `columnWidth`.
4. Define an array of `rowHeight`.
5. Add an [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) object to the slide through the [AddTable()](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addtable/) method.
6. Iterate through each [ICell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/) to apply formatting to the top, bottom, right, and left borders.
7. Merge the first two cells of the table's first row. 
8. Access an [ICell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/)'s [TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/textframe/). 
9. Add some text to the [TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/textframe/).
10. Save the modified presentation.

This C++ code shows you how to create a table in a presentation:

```c++
// Instantiates a Presentation class that represents a PPTX file
auto pres = System::MakeObject<Presentation>();

// Accesses first slide
auto sld = pres->get_Slides()->idx_get(0);

// Defines columns with widths and rows with heights
auto dblCols = System::MakeArray<double>({ 50, 50, 50 });
auto dblRows = System::MakeArray<double>({ 50, 30, 30, 30, 30 });

// Adds a table shape to the slide
auto tbl = sld->get_Shapes()->AddTable(100.0f, 50.0f, dblCols, dblRows);

// Sets the border format for each cell
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
// Merges cells 1 & 2 of row 1
tbl->MergeCells(tbl->get_Rows()->idx_get(0)->idx_get(0), tbl->get_Rows()->idx_get(1)->idx_get(1), false);

// Adds some text to the merged cell
tbl->get_Rows()->idx_get(0)->idx_get(0)->get_TextFrame()->set_Text(u"Merged Cells");

// Saves the presentation to Disk
pres->Save(u"table.pptx", SaveFormat::Pptx);
```

## **Numbering in Standard Table**

In a standard table, the numeration of cells is straightforward and zero-based. The first cell in a table is indexed as 0,0 (column 0, row 0). 

For example, the cells in a table with 4 columns and 4 rows are numbered this way:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

This C++ code shows you how to specify the numbering for cells in a table:

```c++
// Instantiates a Presentation class that represents a PPTX file
auto pres = System::MakeObject<Presentation>();

// Accesses the first slide
auto sld = pres->get_Slides()->idx_get(0);

// Defines columns with widths and rows with heights
auto dblCols = System::MakeArray<double>({ 70, 70, 70, 70 });
auto dblRows = System::MakeArray<double>({ 70, 70, 70, 70 });

// Adds a table shape to slide
auto tbl = sld->get_Shapes()->AddTable(100.0f, 50.0f, dblCols, dblRows);

// Sets the border format for each cell
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

// Saves presentation to disk
pres->Save(u"StandardTables_out.pptx", SaveFormat::Pptx);
```

## **Access Existing Table**

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) class.

2. Get a reference to the slide containing the table through its index. 

3. Create an [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) object and set it to null.

4. Iterate through all [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) objects till the table is found.

   If you suspect the slide you are dealing with contains a single table, you can simply check all the shapes it contains. When a shape is identified as a table, you can typecast it as a [Table](https://reference.aspose.com/slides/cpp/aspose.slides/table/) object. But if the slide you are dealing with contains several tables, then you are better off searching for the table you need through its [set_AlternativeText()](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/set_alternativetext/).

5. Use the [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) object to work with the table. In the example below, we added a new row to the table.

6. Save the modified presentation.

This C++ code shows you how to access and work with an existing table:

```c++
// Instantiates a Presentation class that represents a PPTX file
auto pres = System::MakeObject<Presentation>(u"UpdateExistingTable.pptx");

// Accesses the first slide
auto sld = pres->get_Slides()->idx_get(0);

// Initializes null Table
System::SharedPtr<ITable> tbl;

// Iterates through the shapes and sets a reference to the table found
for (const auto& shp : System::IterateOver(sld->get_Shapes()))
{
    if (System::ObjectExt::Is<ITable>(shp))
    {
        tbl = System::ExplicitCast<ITable>(shp);
    }
}

// Sets the text for the first column of the second row
tbl->idx_get(0, 1)->get_TextFrame()->set_Text(u"New");

// Saves the modified presentation to disk
pres->Save(u"table1_out.pptx", SaveFormat::Pptx);
```


## **Align Text in Table**

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) class.
2. Get a slide's reference through its index. 
3. Add an [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) object to the slide. 
4. Access an [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) object from the table. 
5. Access the [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) [IParagraph](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/).
6. Align the text vertically.
7. Save the modified presentation.

This C++ code shows you how to align the text in a table:

```c++
// Creates an instance of the Presentation class
auto presentation = System::MakeObject<Presentation>();

// Gets the first slide 
auto slide = presentation->get_Slides()->idx_get(0);

// Defines columns with widths and rows with heights
auto dblCols = System::MakeArray<double>({ 120, 120, 120, 120 });
auto dblRows = System::MakeArray<double>({ 100, 100, 100, 100 });

// Adds the table shape to the slide
auto tbl = slide->get_Shapes()->AddTable(100.0f, 50.0f, dblCols, dblRows);
tbl->idx_get(1, 0)->get_TextFrame()->set_Text(u"10");
tbl->idx_get(2, 0)->get_TextFrame()->set_Text(u"20");
tbl->idx_get(3, 0)->get_TextFrame()->set_Text(u"30");

// Accesses the text frame
auto txtFrame = tbl->idx_get(0, 0)->get_TextFrame();

// Creates the Paragraph object for the text frame
auto paragraph = txtFrame->get_Paragraphs()->idx_get(0);

// Creates the Portion object for paragraph
auto portion = paragraph->get_Portions()->idx_get(0);
portion->set_Text(u"Text here");
portion->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
portion->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

// Aligns the text vertically
auto cell = tbl->idx_get(0, 0);
cell->set_TextAnchorType(TextAnchorType::Center);
cell->set_TextVerticalType(TextVerticalType::Vertical270);

// Saves the Presentation to disk
presentation->Save(u"Vertical_Align_Text_out.pptx", SaveFormat::Pptx);
```

## **Set Text Formatting on Table Level**

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) class.
2. Get a slide's reference through its index. 
3. Access an [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) object from the Slide.
4. Set the [set_FontHeight()](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_fontheight/) for the text. 
5. Set the [set_Alignment()](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_alignment/) and [set_MarginRight()](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_marginright/). 
6. Set the [set_TextVerticalType()](https://reference.aspose.com/slides/cpp/aspose.slides/textframeformat/set_textverticaltype/).
7. Save the modified presentation. 

This C++ code shows you how to apply your preferred formatting options to the text in a table:

```c++
// Creates an instance of the Presentation class
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);

// Let's assume that the first shape on the first slide is a table
auto someTable = System::AsCast<ITable>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));

// Sets the table cells' font height
auto portionFormat = System::MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25.0f);
someTable->SetTextFormat(portionFormat);

// Sets the table cells' text alignment and right margin in one call
auto paragraphFormat = System::MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20.0f);
someTable->SetTextFormat(paragraphFormat);

// Sets the table cells' text vertical type
auto textFrameFormat = System::MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
someTable->SetTextFormat(textFrameFormat);

presentation->Save(u"result.pptx", SaveFormat::Pptx);
```

## **Get Table Style Properties**

Aspose.Slides allows you to retrieve the style properties for a table so that you can use those details for another table or somewhere else. This C++ code shows you how to get the style properties from a table preset style: xxx

```c#

```

## **Lock Aspect Ratio of Table**

The aspect ratio of a geometric shape is the ratio of its sizes in different dimensions. Aspose.Slides provided the `AspectRatioLocked()` property to allow you to lock the aspect ratio setting for tables and other shapes. 

This C++ code shows you how to lock the aspect ratio for a table:

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto table = System::ExplicitCast<ITable>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));

Console::WriteLine(u"Lock aspect ratio set: {0}", table->get_GraphicalObjectLock()->get_AspectRatioLocked());


table->get_GraphicalObjectLock()->set_AspectRatioLocked(!table->get_GraphicalObjectLock()->get_AspectRatioLocked());

Console::WriteLine(u"Lock aspect ratio set: {0}", table->get_GraphicalObjectLock()->get_AspectRatioLocked());

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```

