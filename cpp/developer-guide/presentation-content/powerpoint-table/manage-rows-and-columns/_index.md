---
title: Manage Rows and Columns
type: docs
weight: 20
url: /cpp/manage-rows-and-columns/
---

## **Set First Row as Header**
Aspose.Slides for C++ provides the feature to set the first row as header using the following methods of [ITable](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_table) interface. Below code example shows how to set the first row as a header.

``` cpp
// Instantiate Presentation class that represents PPTX
auto pres = System::MakeObject<Presentation>(u"table.pptx");

// Access the first slide
auto sld = pres->get_Slides()->idx_get(0);

// Initialize null TableEx
SharedPtr<ITable> tbl;

// Iterate through the shapes and set a reference to the table found
for (const auto& shp : sld->get_Shapes())
{
    if (ObjectExt::Is<ITable>(shp))
    {
        tbl = System::DynamicCast<ITable>(shp);
    }
}

// Set the first row of a table as header with a special formatting.
tbl->set_FirstRow(true);
```

## **Remove Row or Column from Table**
Aspose.Slides for C++ has provided the simplest API to create tables in an easiest way. To create a table in a slide and perform some basic operations on the table, please follow the steps below:

- Create an instance of [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) class.
- Obtain the reference of a slide by using its Index.
- Define Array of Columns with Width.
- Define Array of Rows with Height.
- Add a Table to the slide using AddTable method exposed by IShapes object.
- Remove table row.
- Remove table column.
- Write the modified presentation as a PPTX file.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemovingRowColumn-RemovingRowColumn.cpp" >}}


## **Clone Row or Column of Table**
Aspose.Slides for C++ has provided the simplest API to work with tables in an easiest way. To clone a table row or column in a slide, please follow the steps below:

- Create an instance of [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) class.
- Obtain the reference of a slide by using its Index.
- Define Array of Columns with Width.
- Define Array of Rows with Height.
- Add a Table to the slide using addTable method exposed by IShapes object.
- Clone table row.
- Clone table column.
- Save the presentation as a PPTX file.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloningInTable-CloningInTable.cpp" >}}


## **Set Text Formatting on Table Row Level**
Aspose.Slides for C++ has provided the simplest API to create tables in an easiest way. In order to remove Text Formatting from table cells on row level, please follow the steps below:

- Create an instance of [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) class.
- Obtain the reference of a slide by using its Index.
- Access Table from Slide.
- Set first row Cells Font Height.
- Set first row Cells Text Alignment and right Margin in one Call.
- Set second row Cells text Vertical Type.
- Save the modified presentation as a PPTX file.

``` cpp
// Create an instance of Presentation class
auto presentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slides()->idx_get(0);

auto someTable = System::DynamicCast_noexcept<ITable>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
// let's say that the first shape on the first slide is a table

// setting first row cells' font height
auto portionFormat = System::MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25.0f);
someTable->get_Rows()->idx_get(0)->SetTextFormat(portionFormat);

// setting first row cells' text alignment and right margin in one call
auto paragraphFormat = System::MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20.0f);
someTable->get_Rows()->idx_get(0)->SetTextFormat(paragraphFormat);

// setting second row cells' text vertical type
auto textFrameFormat = System::MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
someTable->get_Rows()->idx_get(1)->SetTextFormat(textFrameFormat);

presentation->Save(u"result.pptx", SaveFormat::Pptx);
```

## **Set Text Formatting on Table Column Level**
Aspose.Slides for C++ has provided the simplest API to create tables in an easiest way. In order to remove Text Formatting from table cells on Column level, please follow the steps below:

- Create an instance of [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) class.
- Obtain the reference of a slide by using its Index.
- Access Table from Slide.
- Set first Column Cells Font Height.
- Set first Column Cells Text Alignment and right Margin in one Call.
- Set second Column Cells text Vertical Type.
- Save the modified presentation as a PPTX file.

``` cpp
// Create an instance of Presentation class
auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);

auto someTable = System::DynamicCast_noexcept<ITable>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
// let's say that the first shape on the first slide is a table

// setting first column cells' font height
auto portionFormat = System::MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25.0f);
someTable->get_Columns()->idx_get(0)->SetTextFormat(portionFormat);

// setting first column cells' text alignment and right margin in one call
auto paragraphFormat = System::MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20.0f);
someTable->get_Columns()->idx_get(0)->SetTextFormat(paragraphFormat);

// setting second column cells' text vertical type
auto textFrameFormat = System::MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
someTable->get_Columns()->idx_get(1)->SetTextFormat(textFrameFormat);

pres->Save(u"result.pptx", SaveFormat::Pptx);
```
