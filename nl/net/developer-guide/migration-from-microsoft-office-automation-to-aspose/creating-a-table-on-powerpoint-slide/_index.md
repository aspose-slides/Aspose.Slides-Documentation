---
title: Tabellen maken met VSTO en Aspose.Slides for .NET
linktitle: Tabellen maken
type: docs
weight: 50
url: /nl/net/creating-a-table-on-powerpoint-slide/
keywords:
- tabel maken
- migratie
- VSTO
- Office-automatisering
- PowerPoint
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Migreer van Microsoft Office-automatisering naar Aspose.Slides for .NET en maak tabellen in PowerPoint‑dia’s (PPT, PPTX) met C# met flexibele opmaak."
---
{{% alert color="info" %}} 
Tabellen worden veel gebruikt om gegevens weer te geven op presentatieslides. Dit artikel toont hoe u programmatic een tabel van 15 x 15 met een lettergrootte van 10 kunt maken, eerst met [VSTO 2008](/slides/nl/net/creating-a-table-on-powerpoint-slide/) en vervolgens met [Aspose.Slides for .NET](/slides/nl/net/creating-a-table-on-powerpoint-slide/).
{{% /alert %}} 
## **Tabellen maken**
#### **VSTO 2008 voorbeeld**
De volgende stappen voegen een tabel toe aan een Microsoft PowerPoint‑dia met VSTO:

1. Maak een presentatie.
1. Voeg een lege dia toe aan de presentatie.
1. Voeg een tabel van 15 x 15 toe aan de dia.
1. Voeg tekst toe aan elke cel van de tabel met een lettergrootte van 10.
1. Sla de presentatie op schijf.

```c#
//Maak een presentatie
PowerPoint.Presentation pres = Globals.ThisAddIn.Application
              .Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);
//Voeg een lege dia toe
PowerPoint.Slide sld = pres.Slides.Add(1, PowerPoint.PpSlideLayout.ppLayoutBlank);

//Voeg een tabel van 15 x 15 toe
PowerPoint.Shape shp = sld.Shapes.AddTable(15, 15, 10, 10, pres.PageSetup.SlideWidth - 20, 300);
PowerPoint.Table tbl = shp.Table;
int i = -1;
int j = -1;

//Doorloop alle rijen
foreach (PowerPoint.Row row in tbl.Rows)
{
    i = i + 1;
    j = -1;

    //Doorloop alle cellen in de rij
    foreach (PowerPoint.Cell cell in row.Cells)
    {
        j = j + 1;
        //Haal het tekstkader van elke cel op
        PowerPoint.TextFrame tf = cell.Shape.TextFrame;
        //Voeg wat tekst toe
        tf.TextRange.Text = "T" + i.ToString() + j.ToString();
        //Stel de lettergrootte van de tekst in op 10
        tf.TextRange.Paragraphs(0, tf.TextRange.Text.Length).Font.Size = 10;
    }
}

//Sla de presentatie op naar schijf
pres.SaveAs("d:\\tblVSTO.ppt",
      PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
      Microsoft.Office.Core.MsoTriState.msoFalse);
```

### **Aspose.Slides for .NET voorbeeld**
De volgende stappen voegen een tabel toe aan een Microsoft PowerPoint‑dia met Aspose.Slides:

1. Maak een presentatie.
1. Voeg een tabel van 15 x 15 toe aan de eerste dia.
1. Voeg tekst toe aan elke cel van de tabel met een lettergrootte van 10.
1. Schrijf de presentatie naar schijf.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

Presentation pres = new Presentation();

//Toegang tot eerste dia
ISlide sld = pres.Slides[0];

//Definieer kolommen met breedtes en rijen met hoogtes
double[] dblCols = { 50, 50, 50 };
double[] dblRows = { 50, 30, 30, 30, 30 };

//Voeg een tabel toe
Aspose.Slides.ITable tbl = sld.Shapes.AddTable(50, 50, dblCols, dblRows);

//Stel randformaat in voor elke cel
foreach (IRow row in tbl.Rows)
{
	foreach (ICell cell in row)
	{

		//Haal het tekstkader van elke cel op
		ITextFrame tf = cell.TextFrame;
		//Voeg wat tekst toe
		tf.Text = "T" + cell.FirstRowIndex.ToString() + cell.FirstColumnIndex.ToString();
		//Stel lettergrootte in op 10
		tf.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 10;
		tf.Paragraphs[0].ParagraphFormat.Bullet.Type = BulletType.None;
	}
}

//Schrijf de presentatie naar schijf
pres.Save("tblSLD.ppt", SaveFormat.Ppt);
```