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
description: "Von der Microsoft Office-Automatisierung zu Aspose.Slides für .NET migrieren und Tabellen in PowerPoint-Folien (PPT, PPTX) in C# mit flexibler Formatierung erstellen."
---
{{% alert color="info" %}} 

Tabellen werden häufig verwendet, um Daten auf Präsentationsfolien anzuzeigen. In diesem Artikel wird gezeigt, wie programmatisch eine 15 x 15‑Tabelle mit einer Schriftgröße von 10 erstellt wird, zunächst mit [VSTO 2008](/slides/de/net/creating-a-table-on-powerpoint-slide/) und anschließend mit [Aspose.Slides for .NET](/slides/de/net/creating-a-table-on-powerpoint-slide/).

{{% /alert %}} 
## **Tabellen erstellen**
#### **VSTO 2008 Beispiel**
Die folgenden Schritte fügen einer Microsoft PowerPoint‑Folie mit VSTO eine Tabelle hinzu:

1. Erstellen Sie eine Präsentation.  
2. Fügen Sie der Präsentation eine leere Folie hinzu.  
3. Fügen Sie der Folie eine 15 x 15‑Tabelle hinzu.  
4. Fügen Sie jeder Zelle der Tabelle Text mit einer Schriftgröße von 10 hinzu.  
5. Speichern Sie die Präsentation auf dem Datenträger.

```c#
//Erstelle eine Präsentation
PowerPoint.Presentation pres = Globals.ThisAddIn.Application
              .Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);
//Füge eine leere Folie hinzu
PowerPoint.Slide sld = pres.Slides.Add(1, PowerPoint.PpSlideLayout.ppLayoutBlank);

//Add a 15 x 15 table
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
        //Füge etwas Text hinzu
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



### **Aspose.Slides for .NET Beispiel**
Die folgenden Schritte fügen einer Microsoft PowerPoint‑Folie mit Aspose.Slides eine Tabelle hinzu:

1. Erstellen Sie eine Präsentation.  
2. Fügen Sie der ersten Folie eine 15 x 15‑Tabelle hinzu.  
3. Fügen Sie jeder Zelle der Tabelle Text mit einer Schriftgröße von 10 hinzu.  
4. Schreiben Sie die Präsentation auf den Datenträger.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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

		//Textrahmen jeder Zelle holen
		ITextFrame tf = cell.TextFrame;
		//Etwas Text hinzufügen
		tf.Text = "T" + cell.FirstRowIndex.ToString() + cell.FirstColumnIndex.ToString();
		//Schriftgröße auf 10 setzen
		tf.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 10;
		tf.Paragraphs[0].ParagraphFormat.Bullet.Type = BulletType.None;
	}
}

//Präsentation auf die Festplatte schreiben
pres.Save("tblSLD.ppt", SaveFormat.Ppt);
```