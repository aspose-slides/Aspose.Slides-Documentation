---
title: Creating Tables Using VSTO and Aspose.Slides for .NET
linktitle: Creating Tables
type: docs
weight: 50
url: /net/creating-a-table-on-powerpoint-slide/
keywords:
- create table
- migration
- VSTO
- Office automation
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Migrate from Microsoft Office automation to Aspose.Slides for .NET and create tables in PowerPoint (PPT, PPTX) slides in C# with flexible formatting."
---

{{% alert color="primary" %}} 

Tables are widely used to display data on presentation slides. This article shows how to create a 15 x 15 table with a font size of 10 programmatically using first [VSTO 2008](/slides/net/creating-a-table-on-powerpoint-slide/) and then [Aspose.Slides for .NET](/slides/net/creating-a-table-on-powerpoint-slide/).

{{% /alert %}} 
## **Creating Tables**
#### **VSTO 2008 Example**
The following steps add a table to a Microsoft PowerPoint slide using VSTO:

1. Create a presentation.
1. Add an empty slide is added to the presentation.
1. Add a 15 x 15 table to the slide.
1. Add text to each cell of the table with a font size of 10.
1. Save the presentation to disk.

```c#
//Create a presentation
PowerPoint.Presentation pres = Globals.ThisAddIn.Application
              .Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);
//Add a blank slide
PowerPoint.Slide sld = pres.Slides.Add(1, PowerPoint.PpSlideLayout.ppLayoutBlank);

//Add a 15 x 15 table
PowerPoint.Shape shp = sld.Shapes.AddTable(15, 15, 10, 10, pres.PageSetup.SlideWidth - 20, 300);
PowerPoint.Table tbl = shp.Table;
int i = -1;
int j = -1;

//Loop through all the rows
foreach (PowerPoint.Row row in tbl.Rows)
{
    i = i + 1;
    j = -1;

    //Loop through all the cells in the row
    foreach (PowerPoint.Cell cell in row.Cells)
    {
        j = j + 1;
        //Get text frame of each cell
        PowerPoint.TextFrame tf = cell.Shape.TextFrame;
        //Add some text
        tf.TextRange.Text = "T" + i.ToString() + j.ToString();
        //Set font size of the text as 10
        tf.TextRange.Paragraphs(0, tf.TextRange.Text.Length).Font.Size = 10;
    }
}

//Save the presentation to disk
pres.SaveAs("d:\\tblVSTO.ppt",
      PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
      Microsoft.Office.Core.MsoTriState.msoFalse);
```



### **Aspose.Slides for .NET Example**
The following steps add a table to a Microsoft PowerPoint slide using Aspose.Slides:

1. Create a presentation.
1. Add a 15 x 15 table to the first slide.
1. Add text to each cell of the table with a font size of 10.
1. Write the presentation to disk.

```c#
Presentation pres = new Presentation();

//Access first slide
ISlide sld = pres.Slides[0];

//Define columns with widths and rows with heights
double[] dblCols = { 50, 50, 50 };
double[] dblRows = { 50, 30, 30, 30, 30 };

//Add a table
Aspose.Slides.ITable tbl = sld.Shapes.AddTable(50, 50, dblCols, dblRows);

//Set border format for each cell
foreach (IRow row in tbl.Rows)
{
	foreach (ICell cell in row)
	{

		//Get text frame of each cell
		ITextFrame tf = cell.TextFrame;
		//Add some text
		tf.Text = "T" + cell.FirstRowIndex.ToString() + cell.FirstColumnIndex.ToString();
		//Set font size of 10
		tf.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 10;
		tf.Paragraphs[0].ParagraphFormat.Bullet.Type = BulletType.None;
	}
}

//Write the presentation to the disk
pres.Save("C:\\data\\tblSLD.ppt", SaveFormat.Ppt);
```

