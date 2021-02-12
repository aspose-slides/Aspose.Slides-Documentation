---
title: Manage Rows and Columns
type: docs
weight: 20
url: /java/manage-rows-and-columns/
---


## **Enable/Disable First Row as Header**
Aspose.Slides for Java provides the feature to enable/disable the first row as header using the following methods of [ITable](http://www.aspose.com/api/java/slides/com.aspose.slides/interfaces/ITable) interface:

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Table-EnableDisableFirstRowAsHeader-EnableDisableFirstRowAsHeader.java" >}}

## **Remove Row/Column in Table**
{{% alert color="primary" %}} 

In this section, we will explain how developers can remove a row or column from a table using Aspose.Slides for Java.

{{% /alert %}} 

Aspose.Slides for Java has provided the simplest API to create tables in an easiest way. To create a table in a slide and perform some basic operations on the table, please follow the steps below:

- Create an instance of a [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class.
- Obtain the reference of a slide by using its Index.
- Create an Array of Columns' Width.
- Create an Array of Rows' Height.
- Add a Table to the slide using **addTable** method exposed by [IShapeCollection](http://www.aspose.com/api/java/slides/com.aspose.slides/interfaces/IShapeCollection) object.
- Remove a table row.
- Remove a table column.
- Save the modified presentation as a PPTX file.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Table-RemoveARowOrColumnInATable-RemoveARowOrColumnInATable.java" >}}

## **Clone Row/Column in Table**
{{% alert color="primary" %}} 

Using Aspose.Slides for Java you can clone a table row and column.

{{% /alert %}} 

To clone a table row or column in a slide, please follow the steps below:

- Create an instance of [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class.
- Obtain the reference of a slide by using its index.
- Create an array of columns' width.
- Create an array of rows' height.
- Add a table to the slide.
- Clone a table row.
- Clone a table column.
- Save the presentation as a PPTX file.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Table-RemoveARowOrColumnInATable-RemoveARowOrColumnInATable.java" >}}


## **Set Text Formatting on Table Row Level**
{{% alert color="primary" %}} 

Using Aspose.Slides for Java you can Set Text Format on Table row level.

{{% /alert %}} 

To clone a table row or column in a slide, please follow the steps below:

- Create an instance of [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class.
- Obtain the reference of a slide by using its index.
- Access Table from Slide.
- Set first row Cells Font Height.
- Set first row Cells Text Alignment and right Margin in one Call.
- Set second row Cells text Vertical Type.
- Save the modified presentation as a PPTX file.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Table-SettingTextFormattingInsideTableRow-SettingTextFormattingInsideTableRow.java" >}}

## **Set Text Formatting on Table Column Level**
{{% alert color="primary" %}} 

Using Aspose.Slides for Java you can Set Text Format on Table Column level.

{{% /alert %}} 

To clone a table row or column in a slide, please follow the steps below:

- Create an instance of [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class.
- Obtain the reference of a slide by using its index.
- Access Table from Slide.
- Set first Column Cells Font Height.
- Set first Column Cells Text Alignment and right Margin in one Call.
- Set second Column Cells text Vertical Type.
- Save the modified presentation as a PPTX file.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Table-SettingTextFormattingInsideTableColumn-SettingTextFormattingInsideTableColumn.java" >}}
