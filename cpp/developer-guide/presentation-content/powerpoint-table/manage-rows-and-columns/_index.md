---
title: Manage Rows and Columns
type: docs
weight: 20
url: /cpp/manage-rows-and-columns/
keywords: "Table, table rows and columns, PowerPoint presentation, C++, CPP, Aspose.Slides for C++"
description: "Manage table rows and columns in PowerPoint presentations in C++"

---

To allow you to manage a table's rows and columns in a PowerPoint presentation, Aspose.Slides provides the [Table](https://reference.aspose.com/slides/cpp/aspose.slides/table/) class, [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) interface, and many other types. 

## **Set First Row as Header**

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) class and load the presentation. 
2. Get a slide's reference through its index. 
3. Create an [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) object and set it to null.
4. Iterate through all [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) objects to find the relevant table. 
5. Set the table's first row as its header. 

This C++ code shows you how to set a table's first row as its header:

```c++
// Instantiates the Presentation class 
auto pres = System::MakeObject<Presentation>(u"table.pptx");

// Accesses the first slide
auto sld = pres->get_Slides()->idx_get(0);

// Initializes the null TableEx
SharedPtr<ITable> tbl;

// Iterates through the shapes and sets a reference to the table
for (const auto& shp : sld->get_Shapes())
{
    if (ObjectExt::Is<ITable>(shp))
    {
        tbl = System::ExplicitCast<ITable>(shp);
    }
}

// Sets the first row of a table its header 
tbl->set_FirstRow(true);
```


## **Clone Table's Row or Column**

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) class and load the presentation, 
2. Get a slide's reference through its index. 
3. Define an array of `columnWidth`.
4. Define an array of `rowHeight`.
5. Add an [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) object to the slide through the [AddTable()](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addtable/) method.
6. Clone the table row.
7. Clone the table column.
8. Save the modified presentation.

This C++ code shows you how to clone a PowerPoint table's row or column:

```c++
 // The path to the documents directory.
const String outPath = u"../out/CloningInTable_out.pptx";

// Instantiates the Presentation class
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Accesses the first slide
SharedPtr<ISlide> islide = pres->get_Slides()->idx_get(0);

// Defines columns with widths and rows with heights
System::ArrayPtr<double> dblCols = System::MakeObject<System::Array<double>>(4, 70);
System::ArrayPtr<double> dblRows = System::MakeObject<System::Array<double>>(4, 70);

// Adds a table shape to the slide
SharedPtr<ITable> table = islide->get_Shapes()->AddTable(100, 50, dblCols, dblRows);


// Sets the border format for each cell
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

//AddClone adds a row at the end of the table
table->get_Rows()->AddClone(table->get_Rows()->idx_get(0), false);

//InsertClone adds a row at a specific position in a table
table->get_Rows()->InsertClone(2, table->get_Rows()->idx_get(0), false);

//AddClone adds a column at the end of the table
table->get_Columns()->AddClone(table->get_Columns()->idx_get(0), false);

//InsertClone adds a column at a specific position in a table
table->get_Columns()->InsertClone(2, table->get_Columns()->idx_get(0), false);


// Saves the presentation to disk
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);


```

## **Remove Row or Column from Table**

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) class and load the presentation, 
2. Get a slide's reference through its index. 
3. Define an array of `columnWidth`.
4. Define an array of `rowHeight`.
5. Add an [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) object to the slide through the [AddTable()](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addtable/) method.
6. Remove the table row.
7. Remove the table column.
8. Save the modified presentation. 

This C++ code shows you how to remove a row or column from a table:

```c++
// The path to the documents directory.
const String outPath = u"../out/RemovingRowColumn_out.pptx";

// Instantiates the Presentation class
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Accesses the first slide
SharedPtr<ISlide> islide = pres->get_Slides()->idx_get(0);

// Defines the columns with widths and rows with heights
System::ArrayPtr<double> dblCols = System::MakeObject<System::Array<double>>(4, 70);
System::ArrayPtr<double> dblRows = System::MakeObject<System::Array<double>>(4, 70);

// Adds a table shape to the slide
SharedPtr<ITable> table = islide->get_Shapes()->AddTable(100, 50, dblCols, dblRows);

table->get_Rows()->RemoveAt(1, false);
table->get_Columns()->RemoveAt(1, false);


// Merges cells (1, 1) x (2, 1)
table->MergeCells(table->idx_get(1, 1), table->idx_get(2, 1), false);

// Merges cells (1, 2) x (2, 2)
table->MergeCells(table->idx_get(1, 2), table->idx_get(2, 2), false);


// Saves the presentation to disk
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);


```

## **Set Text Formatting on Table Row Level**

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) class and load the presentation, 
2. Get a slide's reference through its index. 
3. Access the relevant [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) object from the slide. 
4. Set the first-row cells' [set_FontHeight()](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_fontheight/). 
5. Set the first-row cells' [set_Alignment()](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_alignment/) and [set_MarginRight()](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_marginright/). 
6. Set the second-row cells' [set_TextVerticalType()](https://reference.aspose.com/slides/cpp/aspose.slides/textframeformat/set_textverticaltype/).
7. Save the modified presentation.

This C++ code demonstrates the operation.

```c++
// Creates an instance of the Presentation class
auto presentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slides()->idx_get(0);

auto someTable = System::AsCast<ITable>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
// Let's assume that the first shape on the first slide is a table
// Sets first row cells' font height
auto portionFormat = System::MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25.0f);
someTable->get_Rows()->idx_get(0)->SetTextFormat(portionFormat);

// Sets the first row cells' text alignment and right margin
auto paragraphFormat = System::MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20.0f);
someTable->get_Rows()->idx_get(0)->SetTextFormat(paragraphFormat);

// Sets the second row cells' text vertical type
auto textFrameFormat = System::MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
someTable->get_Rows()->idx_get(1)->SetTextFormat(textFrameFormat);

// Saves the presentation to disk
presentation->Save(u"result.pptx", SaveFormat::Pptx);
```

## **Set Text Formatting on Table Column Level**

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) class and load the presentation, 
2. Get a slide's reference through its index. 
3. Access the relevant [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) object from the slide. 
4. Set the first-column cells' [set_FontHeight()](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_fontheight/). 
5. Set the first-column cells' [set_Alignment()](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_alignment/) and [set_MarginRight()](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_marginright/). 
6. Set the second-column cells' [set_TextVerticalType()](https://reference.aspose.com/slides/cpp/aspose.slides/textframeformat/set_textverticaltype/).
7. Save the modified presentation. 

This C++ code demonstrates the operation: 

```c++
// Creates an instance of the Presentation class
auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);

auto someTable = System::AsCast<ITable>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
// Let's assume that the first shape on the first slide is a table

// Sets the first column cells' font height
auto portionFormat = System::MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25.0f);
someTable->get_Columns()->idx_get(0)->SetTextFormat(portionFormat);

// Sets the first column cells' text alignment and right margin in one call
auto paragraphFormat = System::MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20.0f);
someTable->get_Columns()->idx_get(0)->SetTextFormat(paragraphFormat);

// Sets the second column cells' text vertical type
auto textFrameFormat = System::MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
someTable->get_Columns()->idx_get(1)->SetTextFormat(textFrameFormat);

pres->Save(u"result.pptx", SaveFormat::Pptx);
```

## **Get Table Style Properties**

Aspose.Slides allows you to retrieve the style properties for a table so that you can use those details for another table or somewhere else. This C++ code shows you how to get the style properties from a table preset style: xxx

```c++

```
