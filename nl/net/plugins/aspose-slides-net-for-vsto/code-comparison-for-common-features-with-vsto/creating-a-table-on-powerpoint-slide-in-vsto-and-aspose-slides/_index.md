---
title: Een tabel maken op een PowerPoint-dia in VSTO en Aspose.Slides
type: docs
weight: 90
url: /nl/net/creating-a-table-on-powerpoint-slide-in-vsto-and-aspose-slides/
---
De volgende stappen voegen een tabel toe aan een Microsoft PowerPoint-dia met VSTO:

- Maak een presentatie.
- Voeg een lege dia toe aan de presentatie.
- Voeg een 15 x 15 tabel toe aan de dia.
- Voeg tekst toe aan elke cel van de tabel met een lettergrootte van 10.
- Sla de presentatie op naar schijf.
## **VSTO**
``` csharp

 //Maak een presentatie

PowerPoint.Presentation pres = Globals.ThisAddIn.Application

			  .Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//Voeg een lege dia toe

PowerPoint.Slide sld = pres.Slides.Add(1, PowerPoint.PpSlideLayout.ppLayoutBlank);

//Voeg een 15 x 15 tabel toe

PowerPoint.Shape shp = sld.Shapes.AddTable(15, 15, 10, 10, pres.PageSetup.SlideWidth - 20, 300);

PowerPoint.Table tbl = shp.Table;

int i = -1;

int j = -1;

//Loop door alle rijen

foreach (PowerPoint.Row row in tbl.Rows)

{

	i = i + 1;

	j = -1;

	//Loop door alle cellen in de rij

	foreach (PowerPoint.Cell cell in row.Cells)

	{

		j = j + 1;

		//Haal tekstkader van elke cel op

		PowerPoint.TextFrame tf = cell.Shape.TextFrame;

		//Voeg wat tekst toe

		tf.TextRange.Text = "T" + i.ToString() + j.ToString();

		//Stel de tekengrootte in op 10

		tf.TextRange.Paragraphs(0, tf.TextRange.Text.Length).Font.Size = 10;

	}

}

//Sla de presentatie op naar schijf

pres.SaveAs("tblVSTO.ppt",

	  PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,

	  Microsoft.Office.Core.MsoTriState.msoFalse);

``` 

De volgende stappen voegen een tabel toe aan een Microsoft PowerPoint-dia met Aspose.Slides:

- Maak een presentatie.
- Voeg een 15 x 15 tabel toe aan de eerste dia.
- Voeg tekst toe aan elke cel van de tabel met een lettergrootte van 10.
- Schrijf de presentatie naar schijf.
## **Aspose.Slides**
``` csharp

 //Maak een presentatie
Presentation pres = new Presentation();

 //Open de eerste dia
Slide sld = pres.GetSlideByPosition(1);

 //Voeg een tabel toe
Aspose.Slides.Table tbl = sld.Shapes.AddTable(50, 50, pres.SlideSize.Width - 100, pres.SlideSize.Height - 100, 15, 15);

 //Loop door de rijen
for (int i = 0; i < tbl.RowsNumber; i++)
	 //Loop door de cellen
	for (int j = 0; j < tbl.ColumnsNumber; j++)
	{
		//Haal tekstkader van elke cel op
		TextFrame tf = tbl.GetCell(j, i).TextFrame;
		//Voeg wat tekst toe
		tf.Text = "T" + i.ToString() + j.ToString();
		//Stel de tekengrootte in op 10
		tf.Paragraphs[0].Portions[0].FontHeight = 10;
		tf.Paragraphs[0].HasBullet = false;
	}

//Schrijf de presentatie naar de schijf
pres.Write("tblSLD.ppt");
``` 
## **Voorbeeldcode downloaden**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Creating.a.Table.on.PowerPoint.Slide.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Creating%20a%20Table%20on%20PowerPoint%20Slide%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/src/master/Aspose.Slides%20Vs%20VSTO%20Slides/Creating%20a%20Table%20on%20PowerPoint%20Slide/)