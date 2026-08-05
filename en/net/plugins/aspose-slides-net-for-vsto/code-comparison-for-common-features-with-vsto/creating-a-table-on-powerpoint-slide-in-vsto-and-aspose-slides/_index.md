---
title: Creating a Table on PowerPoint Slide in VSTO and Aspose.Slides
type: docs
weight: 90
url: /net/creating-a-table-on-powerpoint-slide-in-vsto-and-aspose-slides/
---

The following steps add a table to a Microsoft PowerPoint slide using VSTO:

- Create a presentation.
- Add an empty slide is added to the presentation.
- Add a 15 x 15 table to the slide.
- Add text to each cell of the table with a font size of 10.
- Save the presentation to disk.
## **VSTO**
``` csharp

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

pres.SaveAs("tblVSTO.ppt",

	  PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,

	  Microsoft.Office.Core.MsoTriState.msoFalse);

``` 

The following steps add a table to a Microsoft PowerPoint slide using Aspose.Slides:

- Create a presentation.
- Add a 15 x 15 table to the first slide.
- Add text to each cell of the table with a font size of 10.
- Write the presentation to disk.
## **Aspose.Slides**
``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;

//Create a presentation
using (Presentation pres = new Presentation())
{
	//Access first slide
	ISlide sld = pres.Slides[0];

	//Define the columns and the rows of a 15 x 15 table
	double[] columnWidths = new double[15];
	double[] rowHeights = new double[15];

	for (int i = 0; i < 15; i++)
	{
		columnWidths[i] = (pres.SlideSize.Size.Width - 100) / 15;
		rowHeights[i] = (pres.SlideSize.Size.Height - 100) / 15;
	}

	//Add a table
	ITable tbl = sld.Shapes.AddTable(50, 50, columnWidths, rowHeights);

	//Loop through rows
	for (int i = 0; i < rowHeights.Length; i++)

		//Loop through cells
		for (int j = 0; j < columnWidths.Length; j++)
		{
			//Get text frame of each cell
			ITextFrame tf = tbl[j, i].TextFrame;

			//Add some text
			tf.Text = "T" + i.ToString() + j.ToString();

			//Set font size of 10
			tf.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 10;

			tf.Paragraphs[0].ParagraphFormat.Bullet.Type = BulletType.None;
		}

	//Write the presentation to the disk
	pres.Save("tblSLD.pptx", SaveFormat.Pptx);
}
``` 
## **Download Sample Code**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Creating.a.Table.on.PowerPoint.Slide.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Creating%20a%20Table%20on%20PowerPoint%20Slide%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/src/master/Aspose.Slides%20Vs%20VSTO%20Slides/Creating%20a%20Table%20on%20PowerPoint%20Slide/)
