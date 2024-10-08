---
title: Erstellung einer Tabelle auf einer PowerPoint-Folie
type: docs
weight: 50
url: /de/net/creating-a-table-on-powerpoint-slide/
---

{{% alert color="primary" %}} 

Tabellen werden häufig verwendet, um Daten auf Präsentationsfolien anzuzeigen. Dieser Artikel zeigt, wie man programmgesteuert eine 15 x 15 Tabelle mit einer Schriftgröße von 10 erstellt, zunächst mit [VSTO 2008](/slides/de/net/creating-a-table-on-powerpoint-slide/) und dann mit [Aspose.Slides für .NET](/slides/de/net/creating-a-table-on-powerpoint-slide/).

{{% /alert %}} 
## **Tabellen erstellen**
#### **VSTO 2008 Beispiel**
Die folgenden Schritte fügen eine Tabelle zu einer Microsoft PowerPoint-Folie mit VSTO hinzu:

1. Erstellen Sie eine Präsentation.
1. Fügen Sie eine leere Folie zur Präsentation hinzu.
1. Fügen Sie eine 15 x 15 Tabelle zur Folie hinzu.
1. Fügen Sie jedem Feld der Tabelle Text mit einer Schriftgröße von 10 hinzu.
1. Speichern Sie die Präsentation auf der Festplatte.

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
        //Erhalte den Textrahmen jeder Zelle
        PowerPoint.TextFrame tf = cell.Shape.TextFrame;
        //Füge etwas Text hinzu
        tf.TextRange.Text = "T" + i.ToString() + j.ToString();
        //Setze die Schriftgröße des Textes auf 10
        tf.TextRange.Paragraphs(0, tf.TextRange.Text.Length).Font.Size = 10;
    }
}

//Speichern Sie die Präsentation auf der Festplatte
pres.SaveAs("d:\\tblVSTO.ppt",
      PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
      Microsoft.Office.Core.MsoTriState.msoFalse);
```



### **Aspose.Slides für .NET Beispiel**
Die folgenden Schritte fügen eine Tabelle zu einer Microsoft PowerPoint-Folie mit Aspose.Slides hinzu:

1. Erstellen Sie eine Präsentation.
1. Fügen Sie eine 15 x 15 Tabelle zur ersten Folie hinzu.
1. Fügen Sie jedem Feld der Tabelle Text mit einer Schriftgröße von 10 hinzu.
1. Schreiben Sie die Präsentation auf der Festplatte.

```c#
Presentation pres = new Presentation();

//Zugriff auf die erste Folie
ISlide sld = pres.Slides[0];

//Definieren Sie Spalten mit Breiten und Zeilen mit Höhen
double[] dblCols = { 50, 50, 50 };
double[] dblRows = { 50, 30, 30, 30, 30 };

//Fügen Sie eine Tabelle hinzu
Aspose.Slides.ITable tbl = sld.Shapes.AddTable(50, 50, dblCols, dblRows);

//Setzen Sie das Rahmenformat für jede Zelle
foreach (IRow row in tbl.Rows)
{
	foreach (ICell cell in row)
	{

		//Erhalte den Textrahmen jeder Zelle
		ITextFrame tf = cell.TextFrame;
		//Füge etwas Text hinzu
		tf.Text = "T" + cell.FirstRowIndex.ToString() + cell.FirstColumnIndex.ToString();
		//Setze die Schriftgröße auf 10
		tf.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 10;
		tf.Paragraphs[0].ParagraphFormat.Bullet.Type = BulletType.None;
	}
}

//Schreiben Sie die Präsentation auf die Festplatte
pres.Save("C:\\data\\tblSLD.ppt", SaveFormat.Ppt);
```