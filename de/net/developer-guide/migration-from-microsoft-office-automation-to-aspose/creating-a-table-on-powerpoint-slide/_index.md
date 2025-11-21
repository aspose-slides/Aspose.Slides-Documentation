---
title: Erstellung von Tabellen mit VSTO und Aspose.Slides für .NET
linktitle: Erstellung von Tabellen
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
description: "Von der Microsoft Office-Automatisierung zu Aspose.Slides für .NET migrieren und Tabellen in PowerPoint (PPT, PPTX)-Folien in C# mit flexibler Formatierung erstellen."
---

{{% alert color="primary" %}} 

Tabellen werden häufig verwendet, um Daten auf Präsentationsfolien darzustellen. Dieser Artikel zeigt, wie man programmgesteuert eine 15 × 15‑Tabelle mit einer Schriftgröße von 10 erstellt, zuerst mit [VSTO 2008](/slides/de/net/creating-a-table-on-powerpoint-slide/) und dann mit [Aspose.Slides for .NET](/slides/de/net/creating-a-table-on-powerpoint-slide/).

{{% /alert %}} 
## **Tabellen erstellen**
#### **VSTO 2008‑Beispiel**
Die folgenden Schritte fügen einer Microsoft PowerPoint‑Folie mithilfe von VSTO eine Tabelle hinzu:

1. Erstelle eine Präsentation.
1. Füge der Präsentation eine leere Folie hinzu.
1. Füge der Folie eine 15 × 15‑Tabelle hinzu.
1. Füge jedem Tabellenzelle Text mit einer Schriftgröße von 10 hinzu.
1. Speichere die Präsentation auf dem Datenträger.
```c#
//Erstelle eine Präsentation
PowerPoint.Presentation pres = Globals.ThisAddIn.Application
              .Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);
//Füge eine leere Folie hinzu
PowerPoint.Slide sld = pres.Slides.Add(1, PowerPoint.PpSlideLayout.ppLayoutBlank);

//Füge eine 15 x 15 Tabelle hinzu
PowerPoint.Shape shp = sld.Shapes.AddTable(15, 15, 10, 10, pres.PageSetup.SlideWidth - 20, 300);
PowerPoint.Table tbl = shp.Table;
int i = -1;
int j = -1;

//Durchlaufe alle Zeilen
foreach (PowerPoint.Row row in tbl.Rows)
{
    i = i + 1;
    j = -1;

    //Durchlaufe alle Zellen in der Zeile
    foreach (PowerPoint.Cell cell in row.Cells)
    {
        j = j + 1;
        //Hole den Textrahmen jeder Zelle
        PowerPoint.TextFrame tf = cell.Shape.TextFrame;
        //Füge Text hinzu
        tf.TextRange.Text = "T" + i.ToString() + j.ToString();
        //Setze die Schriftgröße des Textes auf 10
        tf.TextRange.Paragraphs(0, tf.TextRange.Text.Length).Font.Size = 10;
    }
}

//Speichere die Präsentation auf dem Datenträger
pres.SaveAs("d:\\tblVSTO.ppt",
      PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
      Microsoft.Office.Core.MsoTriState.msoFalse);
```




### **Aspose.Slides for .NET‑Beispiel**
Die folgenden Schritte fügen einer Microsoft PowerPoint‑Folie mithilfe von Aspose.Slides eine Tabelle hinzu:

1. Erstelle eine Präsentation.
1. Füge der ersten Folie eine 15 × 15‑Tabelle hinzu.
1. Füge jedem Tabellenzelle Text mit einer Schriftgröße von 10 hinzu.
1. Schreibe die Präsentation auf den Datenträger.
```c#
Presentation pres = new Presentation();

//Zugriff auf die erste Folie
ISlide sld = pres.Slides[0];

//Definiere Spalten mit Breiten und Zeilen mit Höhen
double[] dblCols = { 50, 50, 50 };
double[] dblRows = { 50, 30, 30, 30, 30 };

//Füge eine Tabelle hinzu
Aspose.Slides.ITable tbl = sld.Shapes.AddTable(50, 50, dblCols, dblRows);

//Setze Rahmenformat für jede Zelle
foreach (IRow row in tbl.Rows)
{
	foreach (ICell cell in row)
	{

		//Hole den Textrahmen jeder Zelle
		ITextFrame tf = cell.TextFrame;
		//Füge Text hinzu
		tf.Text = "T" + cell.FirstRowIndex.ToString() + cell.FirstColumnIndex.ToString();
		//Setze Schriftgröße auf 10
		tf.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 10;
		tf.Paragraphs[0].ParagraphFormat.Bullet.Type = BulletType.None;
	}
}

//Schreibe die Präsentation auf die Festplatte
pres.Save("C:\\data\\tblSLD.ppt", SaveFormat.Ppt);
```
