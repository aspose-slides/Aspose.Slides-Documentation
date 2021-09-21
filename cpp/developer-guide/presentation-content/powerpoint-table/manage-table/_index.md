---
title: Manage Table
type: docs
weight: 10
url: /cpp/manage-table/
---


{{% alert color="primary" %}} 

This page is no longer maintained. For an updated page, please [visit](/slides/cpp/adding-updating-and-manipulating-tables/)

{{% /alert %}} 

{{% alert color="primary" %}} 

Aspose.Slides for C++ allows developers to not only add custom tables in their slides but also access or manage the existing ones. In this topic, we will discuss about accessing a table that already exists in a slide.

{{% /alert %}} 


## **Create Table from Scratch**
Aspose.Slides for C++ has provided the simplest API to create tables in an easiest way. To create a table in a slide and perform some basic operations on the table, please follow the steps below:

- Create an instance of [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
- Obtain the reference of a slide by using its Index.
- Define Array of Columns with Width.
- Define Array of Rows with Height.
- Add a Table to the slide using AddTable method exposed by IShapes object.
- Iterate through each Cell to apply formatting to the Top, Bottom, Right, Left Borders.
- Merge first two cells of the first row of the table.
- Access the Text Frame of a Cell.
- Add some text to the Text Frame.
- Save the modified presentation as a PPTX file.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-TableFromScratch-TableFromScratch.cpp" >}}


## **Access Existing Table**
To access a table that already exists in a slide, please follow the steps below:

- Create an instance of Presentation class
- Obtain the reference of a slide (that contains the table) by using its Position
- Create an ITable object and set it to null
- Iterate through all Shapes until you find the Table. If a slide contains only one table then you can simply check a shape and if it is found to be a Table then just typecast it as a Table object. But, if the slide contains more than one tables then it's better to find your desired table using its Alternative Text
- After the Table is found, you can use ITable object to control the table. For example, in our case, we have added a new row in the desired table
- Save the modified presentation as a PPT file


``` cpp

 //Instantiate Presentation class that represents PPTX//Instantiate Presentation class that represents PPTX

using (Presentation pres = new Presentation("table.pptx"))

{

    //Access the first slide

    ISlide sld = pres.Slides[0];

    //Initialize null TableEx

    ITable tbl = null;

    //Iterate through the shapes and set a reference to the table found

    foreach (IShape shp in sld.Shapes)

        if (shp is ITable)

            tbl = (ITable)shp;

    //Set the text of the first column of second row

    tbl[0, 1].TextFrame.Text = "New";

    //Write the PPTX to Disk

    pres.Save("table1.pptx", SaveFormat.Pptx);

}



```


``` cpp

 'Instantiate Presentation class that represents PPTX

Using pres As New Presentation("table.pptx")

	'Access the first slide

	Dim sld As ISlide = pres.Slides(0)

	'Initialize null TableEx

	Dim tbl As ITable = Nothing

	'Iterate through the shapes and set a reference to the table found

	For Each shp As IShape In sld.Shapes

		If TypeOf shp Is ITable Then

			tbl = CType(shp, ITable)

		End If

	Next shp

	'Set the text of the first column of second row

	tbl(0, 1).TextFrame.Text = "New"

	'Write the PPTX to Disk

	pres.Save("table1.pptx", SaveFormat.Pptx)

End Using


```

![todo:image_alt_text](Accessing%20an%20Existing%20Table%20in%20SlideEx-00.png)

**Figure**: Original table before modification

The above code snippet locates an existing table in the slide and then adds some text in the first column of the second row in the table as shown below:

![todo:image_alt_text](Accessing%20an%20Existing%20Table%20in%20SlideEx-002.png)

**Figure**: Table with modified text

## **Set Text Formatting on Table Level**
Aspose.Slides for C++ has provided the simplest API to create tables in an easiest way. In order to remove Text Formatting from table cells, please follow the steps below:

- Create an instance of [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
- Obtain the reference of a slide by using its Index.
- Access Table from Slide.
- Set Table Cells Font Height.
- Set Table Cells Text Alignment and right Margin in one Call.
- Set Table Cells Vertical Type.
- Save the modified presentation as a PPTX file.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-CSharp-Tables-SetTextFormattingInsideTable-SetTextFormattingInsideTable.cs" >}}


## **Numbering in Standard Table**
In a standard table numeration of cells is straightforward and zero-based. The first cell in a table is indexed as 0,0 (column 0, row 0). For example, the cells in a table with 4 columns and 4 rows will be numbered accordingly:

|**(0, 0)**|**(1, 0)**|**(2, 0)**|**(3, 0)**|
| :- | :- | :- | :- |
|(0, 1)|(1, 1)|(2, 1)|(3, 1)|
|(0, 2)|(1, 2)|(2, 2)|(3, 2)|
|(0, 3)|(1, 3)|(2, 3)|(3, 3)|
{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-StandardTables-StandardTables.cpp" >}}


## **Vertically Align Text in Table**
Aspose.Slides for C++ has provided the simplest API to work with tables in an easiest way. To clone a table row or column in a slide, please follow the steps below:

- Create an instance of [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
- Obtain the reference of a slide by using its Index.
- Insert table in the slide.
- Access text frame.
- Access paragraph.
- Align text vertically.
- Save the presentation as a PPTX file.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-VerticallyAlignText-VerticallyAlignText.cpp" >}}


## **Lock Aspect Ratio of Table**
The aspect ratio of a geometric shape is the ratio of its sizes in different dimensions. You can lock aspect ratio of table using **set_AspectRatioLocked** property. Below code example shows how to use this property.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-LockAspectRatio-LockAspectRatio.cpp" >}}
