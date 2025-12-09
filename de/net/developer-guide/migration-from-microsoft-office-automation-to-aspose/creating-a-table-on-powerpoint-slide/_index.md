---
title: Tabellen mit VSTO und Aspose.Slides für .NET erstellen
linktitle: Tabellen erstellen
type: docs
weight: 50
url: /de/net/creating-a-table-on-powerpoint-slide/
keywords:
- Tabelle erstellen
- Migration
- VSTO
- Office-Automatisierung
- PowerPoint
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Migrieren Sie von der Microsoft Office-Automatisierung zu Aspose.Slides für .NET und erstellen Sie Tabellen in PowerPoint (PPT, PPTX)-Folien in C# mit flexibler Formatierung."
---

{{% alert color="primary" %}} 

Tabellen werden häufig verwendet, um Daten in Präsentationsfolien anzuzeigen. Dieser Artikel zeigt, wie man programmgesteuert eine 15 × 15 Tabelle mit einer Schriftgröße von 10 erstellt, zuerst mit [VSTO 2008](/slides/de/net/creating-a-table-on-powerpoint-slide/) und dann mit [Aspose.Slides for .NET](/slides/de/net/creating-a-table-on-powerpoint-slide/).

{{% /alert %}} 
## **Tabellen erstellen**
#### **VSTO 2008 Beispiel**
Die folgenden Schritte fügen einer Microsoft PowerPoint‑Folie mit VSTO eine Tabelle hinzu:

1. Eine Präsentation erstellen.
1. Eine leere Folie zur Präsentation hinzufügen.
1. Eine 15 × 15 Tabelle zur Folie hinzufügen.
1. Text zu jeder Zelle der Tabelle mit Schriftgröße 10 hinzufügen.
1. Die Präsentation auf die Festplatte speichern.
```c#
//Präsentation erstellen
PowerPoint.Presentation pres = Globals.ThisAddIn.Application
              .Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);
//Leere Folie hinzufügen
PowerPoint.Slide sld = pres.Slides.Add(1, PowerPoint.PpSlideLayout.ppLayoutBlank);

//15 x 15 Tabelle hinzufügen
PowerPoint.Shape shp = sld.Shapes.AddTable(15, 15, 10, 10, pres.PageSetup.SlideWidth - 20, 300);
PowerPoint.Table tbl = shp.Table;
int i = -1;
int j = -1;

//Durch alle Zeilen iterieren
foreach (PowerPoint.Row row in tbl.Rows)
{
    i = i + 1;
    j = -1;

    //Durch alle Zellen in der Zeile iterieren
    foreach (PowerPoint.Cell cell in row.Cells)
    {
        j = j + 1;
        //Textframe jeder Zelle holen
        PowerPoint.TextFrame tf = cell.Shape.TextFrame;
        //Text hinzufügen
        tf.TextRange.Text = "T" + i.ToString() + j.ToString();
        //Schriftgröße des Textes auf 10 setzen
        tf.TextRange.Paragraphs(0, tf.TextRange.Text.Length).Font.Size = 10;
    }
}

//Präsentation auf der Festplatte speichern
pres.SaveAs("d:\\tblVSTO.ppt",
      PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
      Microsoft.Office.Core.MsoTriState.msoFalse);
```




### **Aspose.Slides für .NET Beispiel**
Die folgenden Schritte fügen einer Microsoft PowerPoint‑Folie mit Aspose.Slides eine Tabelle hinzu:

1. Eine Präsentation erstellen.
1. Eine 15 × 15 Tabelle zur ersten Folie hinzufügen.
1. Text zu jeder Zelle der Tabelle mit Schriftgröße 10 hinzufügen.
1. Die Präsentation auf die Festplatte schreiben.
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
