---
title: Creazione di una tabella su diapositiva PowerPoint in VSTO e Aspose.Slides
type: docs
weight: 90
url: /it/net/creating-a-table-on-powerpoint-slide-in-vsto-and-aspose-slides/
---
I seguenti passaggi aggiungono una tabella a una diapositiva Microsoft PowerPoint utilizzando VSTO:

- Crea una presentazione.
- Aggiungi una diapositiva vuota alla presentazione.
- Aggiungi una tabella 15 x 15 alla diapositiva.
- Aggiungi testo a ciascuna cella della tabella con una dimensione del carattere di 10.
- Salva la presentazione su disco.
## **VSTO**
``` csharp

 //Crea una presentazione

PowerPoint.Presentation pres = Globals.ThisAddIn.Application

			  .Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//Aggiungi una diapositiva vuota

PowerPoint.Slide sld = pres.Slides.Add(1, PowerPoint.PpSlideLayout.ppLayoutBlank);

//Aggiungi una tabella 15 x 15

PowerPoint.Shape shp = sld.Shapes.AddTable(15, 15, 10, 10, pres.PageSetup.SlideWidth - 20, 300);

PowerPoint.Table tbl = shp.Table;

int i = -1;

int j = -1;

//Itera su tutte le righe

foreach (PowerPoint.Row row in tbl.Rows)

{

	i = i + 1;

	j = -1;

	//Itera su tutte le celle della riga

	foreach (PowerPoint.Cell cell in row.Cells)

	{

		j = j + 1;

		//Ottieni il frame di testo di ciascuna cella

		PowerPoint.TextFrame tf = cell.Shape.TextFrame;

		//Aggiungi del testo

		tf.TextRange.Text = "T" + i.ToString() + j.ToString();

		//Imposta la dimensione del carattere del testo a 10

		tf.TextRange.Paragraphs(0, tf.TextRange.Text.Length).Font.Size = 10;

	}

}

//Salva la presentazione su disco

pres.SaveAs("tblVSTO.ppt",

	  PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,

	  Microsoft.Office.Core.MsoTriState.msoFalse);

``` 

I seguenti passaggi aggiungono una tabella a una diapositiva Microsoft PowerPoint utilizzando Aspose.Slides:

- Crea una presentazione.
- Aggiungi una tabella 15 x 15 alla prima diapositiva.
- Aggiungi testo a ciascuna cella della tabella con una dimensione del carattere di 10.
- Scrivi la presentazione su disco.
## **Aspose.Slides**
``` csharp

 //Crea una presentazione

Presentation pres = new Presentation();

//Accedi alla prima diapositiva

Slide sld = pres.GetSlideByPosition(1);

//Aggiungi una tabella

Aspose.Slides.Table tbl = sld.Shapes.AddTable(50, 50, pres.SlideSize.Width - 100, pres.SlideSize.Height - 100, 15, 15);

//Itera sulle righe

for (int i = 0; i < tbl.RowsNumber; i++)

	//Itera sulle celle

	for (int j = 0; j < tbl.ColumnsNumber; j++)

	{

		//Ottieni il frame di testo di ogni cella

		TextFrame tf = tbl.GetCell(j, i).TextFrame;

		//Aggiungi del testo

		tf.Text = "T" + i.ToString() + j.ToString();

		//Imposta la dimensione del carattere a 10

		tf.Paragraphs[0].Portions[0].FontHeight = 10;

		tf.Paragraphs[0].HasBullet = false;

	}

//Scrivi la presentazione su disco

pres.Write("tblSLD.ppt");

``` 
## **Scarica il codice di esempio**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Creating.a.Table.on.PowerPoint.Slide.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Creating%20a%20Table%20on%20PowerPoint%20Slide%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/src/master/Aspose.Slides%20Vs%20VSTO%20Slides/Creating%20a%20Table%20on%20PowerPoint%20Slide/)