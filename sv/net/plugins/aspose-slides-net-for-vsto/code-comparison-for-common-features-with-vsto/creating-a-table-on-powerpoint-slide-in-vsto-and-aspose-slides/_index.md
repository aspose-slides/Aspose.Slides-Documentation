---
title: Skapa en tabell på PowerPoint-bild i VSTO och Aspose.Slides
type: docs
weight: 90
url: /sv/net/creating-a-table-on-powerpoint-slide-in-vsto-and-aspose-slides/
---
Följande steg lägger till en tabell på en Microsoft PowerPoint‑bild med VSTO:

- Skapa en presentation.
- Lägg till en tom bild i presentationen.
- Lägg till en 15 x 15‑tabell på bilden.
- Lägg till text i varje cell i tabellen med teckenstorlek 10.
- Spara presentationen till disk.
## **VSTO**
``` csharp

 //Skapa en presentation

PowerPoint.Presentation pres = Globals.ThisAddIn.Application

			  .Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//Lägg till en tom bild

PowerPoint.Slide sld = pres.Slides.Add(1, PowerPoint.PpSlideLayout.ppLayoutBlank);

//Lägg till en 15 x 15‑tabell

PowerPoint.Shape shp = sld.Shapes.AddTable(15, 15, 10, 10, pres.PageSetup.SlideWidth - 20, 300);

PowerPoint.Table tbl = shp.Table;

int i = -1;

int j = -1;

//Iterera genom alla rader

foreach (PowerPoint.Row row in tbl.Rows)

{

	i = i + 1;

	j = -1;

	//Iterera genom alla celler i raden

	foreach (PowerPoint.Cell cell in row.Cells)

	{

		j = j + 1;

		//Hämta textramen för varje cell

		PowerPoint.TextFrame tf = cell.Shape.TextFrame;

		//Lägg till lite text

		tf.TextRange.Text = "T" + i.ToString() + j.ToString();

		//Ställ in teckenstorleken för texten till 10

		tf.TextRange.Paragraphs(0, tf.TextRange.Text.Length).Font.Size = 10;

	}

}

//Spara presentationen till disk

pres.SaveAs("tblVSTO.ppt",

	  PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,

	  Microsoft.Office.Core.MsoTriState.msoFalse);

``` 

Följande steg lägger till en tabell på en Microsoft PowerPoint‑bild med Aspose.Slides:

- Skapa en presentation.
- Lägg till en 15 x 15‑tabell på den första bilden.
- Lägg till text i varje cell i tabellen med teckenstorlek 10.
- Skriv presentationen till disk.
## **Aspose.Slides**
``` csharp

 //Skapa en presentation
Presentation pres = new Presentation();

 //Hämta första bilden
Slide sld = pres.GetSlideByPosition(1);

 //Lägg till en tabell
Aspose.Slides.Table tbl = sld.Shapes.AddTable(50, 50, pres.SlideSize.Width - 100, pres.SlideSize.Height - 100, 15, 15);

 //Loopa igenom rader
for (int i = 0; i < tbl.RowsNumber; i++)
	//Loopa igenom celler
	for (int j = 0; j < tbl.ColumnsNumber; j++)
	{
		//Hämta textramen för varje cell
		TextFrame tf = tbl.GetCell(j, i).TextFrame;
		//Lägg till lite text
		tf.Text = "T" + i.ToString() + j.ToString();
		//Ställ in teckenstorlek till 10
		tf.Paragraphs[0].Portions[0].FontHeight = 10;
		tf.Paragraphs[0].HasBullet = false;
	}

//Skriv presentationen till disk
pres.Write("tblSLD.ppt");
``` 
## **Ladda ner exempel kod**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Creating.a.Table.on.PowerPoint.Slide.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Creating%20a%20Table%20on%20PowerPoint%20Slide%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/src/master/Aspose.Slides%20Vs%20VSTO%20Slides/Creating%20a%20Table%20on%20PowerPoint%20Slide/)