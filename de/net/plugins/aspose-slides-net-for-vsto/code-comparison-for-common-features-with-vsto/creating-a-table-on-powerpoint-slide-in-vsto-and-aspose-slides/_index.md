---
title: Erstellen einer Tabelle auf einer PowerPoint-Folie in VSTO und Aspose.Slides
type: docs
weight: 90
url: /de/net/creating-a-table-on-powerpoint-slide-in-vsto-and-aspose-slides/
---

Die folgenden Schritte fügen einer Microsoft PowerPoint-Folie eine Tabelle mit VSTO hinzu:

- Erstellen Sie eine Präsentation.
- Fügen Sie der Präsentation eine leere Folie hinzu.
- Fügen Sie der Folie eine 15 x 15 Tabelle hinzu.
- Fügen Sie jedem Feld der Tabelle einen Text mit einer Schriftgröße von 10 hinzu.
- Speichern Sie die Präsentation auf der Festplatte.
## **VSTO**
``` csharp

 //Erstellen Sie eine Präsentation

PowerPoint.Presentation pres = Globals.ThisAddIn.Application

			  .Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//Fügen Sie eine leere Folie hinzu

PowerPoint.Slide sld = pres.Slides.Add(1, PowerPoint.PpSlideLayout.ppLayoutBlank);

//Fügen Sie eine 15 x 15 Tabelle hinzu

PowerPoint.Shape shp = sld.Shapes.AddTable(15, 15, 10, 10, pres.PageSetup.SlideWidth - 20, 300);

PowerPoint.Table tbl = shp.Table;

int i = -1;

int j = -1;

//Durchlaufen Sie alle Zeilen

foreach (PowerPoint.Row row in tbl.Rows)

{

	i = i + 1;

	j = -1;

	//Durchlaufen Sie alle Zellen in der Zeile

	foreach (PowerPoint.Cell cell in row.Cells)

	{

		j = j + 1;

		//Holen Sie sich den Textrahmen jeder Zelle

		PowerPoint.TextFrame tf = cell.Shape.TextFrame;

		//Fügen Sie etwas Text hinzu

		tf.TextRange.Text = "T" + i.ToString() + j.ToString();

		//Setzen Sie die Schriftgröße des Textes auf 10

		tf.TextRange.Paragraphs(0, tf.TextRange.Text.Length).Font.Size = 10;

	}

}

//Speichern Sie die Präsentation auf der Festplatte

pres.SaveAs("tblVSTO.ppt",

	  PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,

	  Microsoft.Office.Core.MsoTriState.msoFalse);

``` 

Die folgenden Schritte fügen einer Microsoft PowerPoint-Folie eine Tabelle mit Aspose.Slides hinzu:

- Erstellen Sie eine Präsentation.
- Fügen Sie der ersten Folie eine 15 x 15 Tabelle hinzu.
- Fügen Sie jedem Feld der Tabelle einen Text mit einer Schriftgröße von 10 hinzu.
- Schreiben Sie die Präsentation auf die Festplatte.
## **Aspose.Slides**
``` csharp

 //Erstellen Sie eine Präsentation

Presentation pres = new Presentation();

//Zugriff auf die erste Folie

Slide sld = pres.GetSlideByPosition(1);

//Fügen Sie eine Tabelle hinzu

Aspose.Slides.Table tbl = sld.Shapes.AddTable(50, 50, pres.SlideSize.Width - 100, pres.SlideSize.Height - 100, 15, 15);

//Durchlaufen Sie die Zeilen

for (int i = 0; i < tbl.RowsNumber; i++)

	//Durchlaufen Sie die Zellen

	for (int j = 0; j < tbl.ColumnsNumber; j++)

	{

		//Holen Sie sich den Textrahmen jeder Zelle

		TextFrame tf = tbl.GetCell(j, i).TextFrame;

		//Fügen Sie etwas Text hinzu

		tf.Text = "T" + i.ToString() + j.ToString();

		//Setzen Sie die Schriftgröße auf 10

		tf.Paragraphs[0].Portions[0].FontHeight = 10;

		tf.Paragraphs[0].HasBullet = false;

	}

//Schreiben Sie die Präsentation auf die Festplatte

pres.Write("tblSLD.ppt");

``` 
## **Beispielcode herunterladen**
- [Codeplex](https://asposevsto.codeplex.com/downloads/get/772951)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Creating.a.Table.on.PowerPoint.Slide.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Creating%20a%20Table%20on%20PowerPoint%20Slide%20\(Aspose.Slides\).zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Creating%20a%20Table%20on%20PowerPoint%20Slide%20\(Aspose.Slides\).zip)