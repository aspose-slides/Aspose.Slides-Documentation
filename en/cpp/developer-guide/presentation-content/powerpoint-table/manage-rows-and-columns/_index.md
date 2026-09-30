---
title: Manage Rows and Columns in PowerPoint Tables Using C++
linktitle: Rows and Columns
type: docs
weight: 20
url: /cpp/manage-rows-and-columns/
keywords:
- table row
- table column
- first row
- table header
- clone row
- clone column
- copy row
- copy column
- remove row
- remove column
- row text formatting
- column text formatting
- table style
- PowerPoint
- presentation
- C++
- Aspose.Slides
description: "Manage table rows and columns in PowerPoint with Aspose.Slides for C++ and speed up presentation editing and data updates."
---

## **Introduction**

Aspose.Slides for C++ lets you manage table structure and formatting in PowerPoint presentations through the [Table](https://reference.aspose.com/slides/cpp/aspose.slides/table/) class and [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) interface. You can designate a header row, clone or remove rows and columns, and apply text formatting to an entire row or column.

This article explains these operations with C++ examples. It also shows how to retrieve a table's style preset so you can reuse it. Table row and column indices are zero-based.

## **Control Row Height**

Use [IRow::set_MinimalHeight](https://reference.aspose.com/slides/cpp/aspose.slides/irow/set_minimalheight/) to set a row's minimum height in points. It is a lower bound, not a fixed height. [IRow::get_Height](https://reference.aspose.com/slides/cpp/aspose.slides/irow/get_height/) returns the actual height; this value cannot be set directly. Access the row through [ITable::get_Rows](https://reference.aspose.com/slides/cpp/aspose.slides/itable/get_rows/).

The example loads [row-height-input.pptx](row-height-input.pptx), which has a table as the first shape on the first slide. Its first row starts at 70 points. The cells use 18-point Arial text, wrapping, and 6-point top and bottom margins; the longer text in the second column wraps onto multiple lines. The example increases the minimum to 100 points, then decreases it to 20 points, prints the actual height after each change, and saves both results.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/IRow.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"row-height-input.pptx");
auto slide = presentation->get_Slide(0);

auto table = ExplicitCast<ITable>(slide->get_Shape(0));
auto row = table->get_Rows()->idx_get(0);

row->set_MinimalHeight(100);
Console::WriteLine(u"Increased: minimum = {0:F1}, actual = {1:F1} pt", row->get_MinimalHeight(), row->get_Height());
presentation->Save(u"row-height-increased.pptx", SaveFormat::Pptx);

row->set_MinimalHeight(20);
Console::WriteLine(u"Decreased: minimum = {0:F1}, actual = {1:F1} pt", row->get_MinimalHeight(), row->get_Height());
presentation->Save(u"row-height-decreased.pptx", SaveFormat::Pptx);
```

With the supplied presentation, increasing the minimum adds space to the row. Decreasing it removes that extra space, but the actual height remains greater than 20 points because the text and cell margins need more room. Reducing the minimum alone cannot force the row below the space required by its content.

Several factors affect the actual height:

- **Text and font size:** longer text, explicit line breaks, or a larger font can require more vertical space.
- **Wrapping and column width:** with wrapping enabled, reducing the column width with [IColumn::set_Width](https://reference.aspose.com/slides/cpp/aspose.slides/icolumn/set_width/) can produce more lines. A wider column can reduce the space required vertically.
- **Cell margins:** [ICell::set_MarginTop](https://reference.aspose.com/slides/cpp/aspose.slides/icell/set_margintop/) and [ICell::set_MarginBottom](https://reference.aspose.com/slides/cpp/aspose.slides/icell/set_marginbottom/) control the margins that add vertical space. [ICell::set_MarginLeft](https://reference.aspose.com/slides/cpp/aspose.slides/icell/set_marginleft/) and [ICell::set_MarginRight](https://reference.aspose.com/slides/cpp/aspose.slides/icell/set_marginright/) control the margins that reduce the width available for text and can cause additional wrapping.

For this table without merged cells, the cell that needs the most vertical space determines the content-driven lower limit for the entire row. To make the row shorter, you may also need to shorten the text, reduce the font size or margins, or widen a column.

The images below show the same table at the same scale. In the reference .NET run shown here, the actual heights were 70, 100, and 55.2 points: the final row remained taller than its 20-point minimum. Exact text measurements can vary with the fonts available in your environment. Download the saved results: [increased minimum](row-height-increased.pptx) and [decreased minimum](row-height-decreased.pptx).

| Original: minimum 70 pt, actual 70 pt | Increased: minimum 100 pt, actual 100 pt | Decreased: minimum 20 pt, actual 55.2 pt |
| --- | --- | --- |
| ![Original table with a 70-point first row.](row-height-before.png) | ![Table after increasing the first row minimum to 100 points.](row-height-increased.png) | ![Table after decreasing the first row minimum to 20 points; wrapped text keeps the row taller than the minimum.](row-height-decreased.png) |

## **Set the First Row as a Header**

Use the [set_FirstRow](https://reference.aspose.com/slides/cpp/aspose.slides/itable/set_firstrow/) method to mark the first row for header formatting. Its appearance depends on the table style applied to the table.

1. Load the presentation with the [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) class.
2. Access the first slide.
3. Access the table stored as the first shape on the slide.
4. Enable header formatting for its first row.
5. Save the modified presentation.

The example requires `table.pptx` with a table as the first shape on the first slide. It enables header formatting for the first row and saves `First_row_header.pptx`.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"table.pptx");
auto slide = presentation->get_Slide(0);

auto table = ExplicitCast<ITable>(slide->get_Shape(0));
table->set_FirstRow(true);

presentation->Save(u"First_row_header.pptx", SaveFormat::Pptx);
```

## **Clone a Table Row or Column**

Clone rows or columns to reuse their content and formatting. You can append a copy to the end of the table or insert it at a specific position.

1. Load the presentation with the [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) class.
2. Access the first slide.
3. Define the column widths and row heights.
4. Add a table with the [AddTable](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addtable/) method.
5. Clone the required rows.
6. Clone the required columns.
7. Save the modified presentation.

The example requires `Test.pptx` with at least one slide. It creates a table with three columns and five rows, with dimensions specified in points. It appends copies of the first row and column, then inserts copies of the second row and column at index 3 (the fourth position). The resulting table has seven rows and five columns. The `false` argument disables cloning into adjacent merged rows or columns; this table has no merged cells.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/IColumnCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Table/ICell.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Test.pptx");
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({ 50, 50, 50 });
auto rowHeights = MakeArray<double>({ 50, 30, 30, 30, 30 });
auto table = slide->get_Shapes()->AddTable(100, 50, columnWidths, rowHeights);

table->idx_get(0, 0)->get_TextFrame()->set_Text(u"Row 1 Cell 1");
table->idx_get(1, 0)->get_TextFrame()->set_Text(u"Row 1 Cell 2");
table->get_Rows()->AddClone(table->get_Rows()->idx_get(0), false);

table->idx_get(0, 1)->get_TextFrame()->set_Text(u"Row 2 Cell 1");
table->idx_get(1, 1)->get_TextFrame()->set_Text(u"Row 2 Cell 2");
table->get_Rows()->InsertClone(3, table->get_Rows()->idx_get(1), false);

table->get_Columns()->AddClone(table->get_Columns()->idx_get(0), false);
table->get_Columns()->InsertClone(3, table->get_Columns()->idx_get(1), false);

presentation->Save(u"table_out.pptx", SaveFormat::Pptx);
```

## **Remove a Row or Column from a Table**

Remove rows or columns that are no longer needed in a table. Removing an item shifts the indices of the rows or columns that follow it.

1. Create a presentation with the [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) class.
2. Access the first slide.
3. Define the column widths and row heights.
4. Add a table with the [AddTable](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addtable/) method.
5. Remove the second row and second column.
6. Save the modified presentation.

This example creates a three-by-three table and removes the row and column at index 1, leaving a two-by-two table in `TestTable_out.pptx`. The dimensions are in points. The `false` argument disables removal of adjacent merged rows or columns; this table has no merged cells.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/IColumnCollection.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({ 100, 50, 30 });
auto rowHeights = MakeArray<double>({ 30, 50, 30 });
auto table = slide->get_Shapes()->AddTable(100, 100, columnWidths, rowHeights);

table->get_Rows()->RemoveAt(1, false);
table->get_Columns()->RemoveAt(1, false);

presentation->Save(u"TestTable_out.pptx", SaveFormat::Pptx);
```

## **Set Text Formatting on the Table Row Level**

Apply text formatting to an entire row to keep its cells consistent. You can set font properties, paragraph formatting, and text direction without formatting each cell individually.

1. Load the presentation with the [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) class.
2. Access the table on the first slide.
3. Set the font height with [set_FontHeight](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_fontheight/) for the first row.
4. Set the alignment and right paragraph margin with [set_Alignment](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_alignment/) and [set_MarginRight](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_marginright/) for the first row.
5. Set the text direction with [set_TextVerticalType](https://reference.aspose.com/slides/cpp/aspose.slides/textframeformat/set_textverticaltype/) for the second row.
6. Save the modified presentation.

The example requires `table.pptx` with a table as the first shape on the first slide and at least two rows. It applies 25-point text, right alignment, and a 20-point right paragraph margin to the first row, then sets vertical text in the second row.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/PortionFormat.h>
#include <DOM/ParagraphFormat.h>
#include <DOM/TextAlignment.h>
#include <DOM/TextFrameFormat.h>
#include <DOM/TextVerticalType.h>
#include <DOM/Table/IRow.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"table.pptx");
auto slide = presentation->get_Slide(0);

auto table = ExplicitCast<ITable>(slide->get_Shape(0));

auto portionFormat = MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25);
table->get_Rows()->idx_get(0)->SetTextFormat(portionFormat);

auto paragraphFormat = MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20);
table->get_Rows()->idx_get(0)->SetTextFormat(paragraphFormat);

auto textFrameFormat = MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
table->get_Rows()->idx_get(1)->SetTextFormat(textFrameFormat);

presentation->Save(u"row_formatting.pptx", SaveFormat::Pptx);
```

## **Set Text Formatting on the Table Column Level**

Apply text formatting to an entire column to keep its cells consistent. You can set font properties, paragraph formatting, and text direction without formatting each cell individually.

1. Load the presentation with the [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) class.
2. Access the table on the first slide.
3. Set the font height with [set_FontHeight](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_fontheight/) for the first column.
4. Set the alignment and right paragraph margin with [set_Alignment](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_alignment/) and [set_MarginRight](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_marginright/) for the first column.
5. Set the text direction with [set_TextVerticalType](https://reference.aspose.com/slides/cpp/aspose.slides/textframeformat/set_textverticaltype/) for the second column.
6. Save the modified presentation.

The example requires `table.pptx` with a table as the first shape on the first slide and at least two columns. It applies 25-point text, right alignment, and a 20-point right paragraph margin to the first column, then sets vertical text in the second column.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <DOM/Table/IColumnCollection.h>
#include <DOM/PortionFormat.h>
#include <DOM/ParagraphFormat.h>
#include <DOM/TextAlignment.h>
#include <DOM/TextFrameFormat.h>
#include <DOM/TextVerticalType.h>
#include <DOM/Table/IColumn.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"table.pptx");
auto slide = presentation->get_Slide(0);

auto table = ExplicitCast<ITable>(slide->get_Shape(0));

auto portionFormat = MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25);
table->get_Columns()->idx_get(0)->SetTextFormat(portionFormat);

auto paragraphFormat = MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20);
table->get_Columns()->idx_get(0)->SetTextFormat(paragraphFormat);

auto textFrameFormat = MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
table->get_Columns()->idx_get(1)->SetTextFormat(textFrameFormat);

presentation->Save(u"column_formatting.pptx", SaveFormat::Pptx);
```

## **Get Table Style Properties**

Use the [get_StylePreset](https://reference.aspose.com/slides/cpp/aspose.slides/itable/get_stylepreset/) method to retrieve the preset applied to a table and reuse it on another table. This identifies the preset rather than individual cell formatting overrides.

The example creates a table, applies [TableStylePreset::DarkStyle1](https://reference.aspose.com/slides/cpp/aspose.slides/tablestylepreset/), and reads the preset back. It prints `DarkStyle1` and saves the table in `table.pptx`.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/console.h>
#include <DOM/TableStylePreset.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({ 100, 150 });
auto rowHeights = MakeArray<double>({ 5, 5, 5 });
auto table = slide->get_Shapes()->AddTable(10, 10, columnWidths, rowHeights);
table->set_StylePreset(TableStylePreset::DarkStyle1);

Console::WriteLine(u"{0}", table->get_StylePreset());

presentation->Save(u"table.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Can I apply PowerPoint themes/styles to a table that's already created?**

Yes. The table inherits the slide/layout/master theme, and you can still override fills, borders, and text colors on top of that theme.

**Can I sort table rows like in Excel?**

No, Aspose.Slides tables don't have built-in sorting or filters. Sort your data in memory first, then repopulate the table rows in that order.

**Can I have banded (striped) columns while keeping custom colors on specific cells?**

Yes. Turn on banded columns, then override specific cells with local formatting; cell-level formatting takes precedence over the table style.
