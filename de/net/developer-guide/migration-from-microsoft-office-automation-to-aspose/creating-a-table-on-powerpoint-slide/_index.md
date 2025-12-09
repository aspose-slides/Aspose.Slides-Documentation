---
title: Erstellen von Tabellen mit VSTO und Aspose.Slides für .NET
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
description: "Von Microsoft Office-Automatisierung zu Aspose.Slides für .NET migrieren und Tabellen in PowerPoint (PPT, PPTX)-Folien in C# mit flexibler Formatierung erstellen."
---

{{% alert color="primary" %}} 

Tabellen werden häufig verwendet, um Daten auf Präsentationsfolien anzuzeigen. Dieser Artikel zeigt, wie man programmgesteuert eine 15 x 15 Tabelle mit einer Schriftgröße von 10 erstellt, zunächst mit [VSTO 2008](/slides/de/net/creating-a-table-on-powerpoint-slide/) und dann mit [Aspose.Slides for .NET](/slides/de/net/creating-a-table-on-powerpoint-slide/).

{{% /alert %}} 
## **Tabellen erstellen**
#### **VSTO 2008 Beispiel**
Die folgenden Schritte fügen einer Microsoft PowerPoint‑Folie mithilfe von VSTO eine Tabelle hinzu:

1. Eine Präsentation erstellen.
1. Eine leere Folie zur Präsentation hinzufügen.
1. Eine 15 x 15 Tabelle zur Folie hinzufügen.
1. Text zu jeder Zelle der Tabelle mit einer Schriftgröße von 10 hinzufügen.
1. Die Präsentation auf dem Datenträger speichern.
```c#
//Präsentation erstellen
PowerPoint.Presentation pres = Globals.ThisAddIn.Application
              .Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);
//Leere Folie hinzufügen
PowerPoint.Slide sld = pres.Slides.Add(1, PowerPoint.PpSlideLayout.ppLayoutBlank);

//Eine 15 x 15 Tabelle hinzufügen
PowerPoint.Shape shp = sld.Shapes.AddTable(15, 15, 10, 10, pres.PageSetup.SlideWidth - 20, 300);
PowerPoint.Table tbl = shp.Table;
int i = -1;
int j = -1;

//Alle Zeilen durchlaufen
foreach (PowerPoint.Row row in tbl.Rows)
{
    i = i + 1;
    j = -1;

    //Alle Zellen in der Zeile durchlaufen
    foreach (PowerPoint.Cell cell in row.Cells)
    {
        j = j + 1;
        //Textframe jeder Zelle abrufen
        PowerPoint.TextFrame tf = cell.Shape.TextFrame;
        //Text hinzufügen
        tf.TextRange.Text = "T" + i.ToString() + j.ToString();
        //Schriftgröße des Textes auf 10 setzen
        tf.TextRange.Paragraphs(0, tf.TextRange.Text.Length).Font.Size = 10;
    }
}

//Präsentation auf dem Datenträger speichern
pres.SaveAs("d:\\tblVSTO.ppt",
      PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
      Microsoft.Office.Core.MsoTriState.msoFalse);
```




### **Aspose.Slides für .NET Beispiel**
Die folgenden Schritte fügen einer Microsoft PowerPoint‑Folie mithilfe von Aspose.Slides eine Tabelle hinzu:

1. Eine Präsentation erstellen.
1. Eine 15 x 15 Tabelle zur ersten Folie hinzufügen.
1. Text zu jeder Zelle der Tabelle mit einer Schriftgröße von 10 hinzufügen.
1. Die Präsentation auf dem Datenträger schreiben.
```c#
Presentation pres = new Presentation();

//Zugriff auf die erste Folie
ISlide sld = pres.Slides[0];

//Spalten mit Breiten und Zeilen mit Höhen definieren
double[] dblCols = { 50, 50, 50 };
double[] dblRows = { 50, 30, 30, 30, 30 };

//Eine Tabelle hinzufügen
Aspose.Slides.ITable tbl = sld.Shapes.AddTable(50, 50, dblCols, dblRows);

//Rahmenformat für jede Zelle festlegen
foreach (IRow row in tbl.Rows)
{
	foreach (ICell cell in row)
	{

		//Textfeld jeder Zelle abrufen
		ITextFrame tf = cell.TextFrame;
		//Text hinzufügen
		tf.Text = "T" + cell.FirstRowIndex.ToString() + cell.FirstColumnIndex.ToString();
		//Schriftgröße auf 10 setzen
		tf.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 10;
		tf.Paragraphs[0].ParagraphFormat.Bullet.Type = BulletType.None;
	}
}

//Präsentation auf dem Datenträger speichern
pres.Save("C:\\data\\tblSLD.ppt", SaveFormat.Ppt);
```
