---
title: Manage Rows and Columns
type: docs
weight: 20
url: /net/manage-rows-and-columns/
---

## **Set First Row as Header**
Aspose.Slides for .NET provides the feature to set the first row as header using the following methods of [ITable](https://apireference.aspose.com/net/slides/aspose.slides/itable) interface. Below code example shows how to set the first row as a header.

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-Tables-SetFirstRowAsHeader-SetFirstRowAsHeader.cs" >}}


## **Clone Row or Column of Table**
Aspose.Slides for .NET has provided the simplest API to work with tables in an easiest way. To clone a table row or column in a slide, please follow the steps below:

- Create an instance of [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
- Obtain the reference of a slide by using its Index.
- Define Array of Columns with Width.
- Define Array of Rows with Height.
- Add a Table to the slide using addTable method exposed by IShapes object.
- Clone table row.
- Clone table column.
- Save the presentation as a PPTX file.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Tables-CloningInTable-CloningInTable.cs" >}}

## **Remove Row or Column from Table**
Aspose.Slides for .NET has provided the simplest API to create tables in an easiest way. To create a table in a slide and perform some basic operations on the table, please follow the steps below:

- Create an instance of [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
- Obtain the reference of a slide by using its Index.
- Define Array of Columns with Width.
- Define Array of Rows with Height.
- Add a Table to the slide using AddTable method exposed by IShapes object.
- Remove table row.
- Remove table column.
- Write the modified presentation as a PPTX file.

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-Tables-RemovingRowColumn-RemovingRowColumn.cs" >}}

## **Set Text Formatting on Table Row Level**
Aspose.Slides for .NET has provided the simplest API to create tables in an easiest way. In order to remove Text Formatting from table cells on row level, please follow the steps below:

- Create an instance of [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
- Obtain the reference of a slide by using its Index.
- Access Table from Slide.
- Set first row Cells Font Height.
- Set first row Cells Text Alignment and right Margin in one Call.
- Set second row Cells text Vertical Type.
- Save the modified presentation as a PPTX file.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Tables-TextFormattingInsideTableRow-TextFormattingInsideTableRow.cs" >}}

## **Set Text Formatting on Table Column Level**
Aspose.Slides for .NET has provided the simplest API to create tables in an easiest way. In order to remove Text Formatting from table cells on Column level, please follow the steps below:

- Create an instance of [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
- Obtain the reference of a slide by using its Index.
- Access Table from Slide.
- Set first Column Cells Font Height.
- Set first Column Cells Text Alignment and right Margin in one Call.
- Set second Column Cells text Vertical Type.
- Save the modified presentation as a PPTX file.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Tables-TextFormattingInsideTableColumn-TextFormattingInsideTableColumn.cs" >}}
