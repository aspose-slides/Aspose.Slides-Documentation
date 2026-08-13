---
title: Skapa tabeller med VSTO och Aspose.Slides för .NET
linktitle: Skapa tabeller
type: docs
weight: 50
url: /sv/net/creating-a-table-on-powerpoint-slide/
keywords:
- skapa tabell
- migration
- VSTO
- Office-automatisering
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Migrera från Microsoft Office-automatisering till Aspose.Slides för .NET och skapa tabeller i PowerPoint-bilder (PPT, PPTX) i C# med flexibel formatering."
---
{{% alert color="info" %}} 

Tabeller används ofta för att visa data på presentationsbilder. Den här artikeln visar hur man programatiskt skapar en 15 x 15‑tabell med teckenstorlek 10 först med [VSTO 2008](/slides/sv/net/creating-a-table-on-powerpoint-slide/) och sedan med [Aspose.Slides for .NET](/slides/sv/net/creating-a-table-on-powerpoint-slide/).

{{% /alert %}} 
## **Skapa tabeller**
#### **VSTO 2008‑exempel**
Följande steg lägger till en tabell i en Microsoft PowerPoint‑bild med VSTO:

1. Skapa en presentation.  
2. Lägg till en tom bild till presentationen.  
3. Lägg till en 15 x 15‑tabell på bilden.  
4. Lägg till text i varje cell i tabellen med teckenstorlek 10.  
5. Spara presentationen till disk.

```c#
 //Skapa en presentation
 PowerPoint.Presentation pres = Globals.ThisAddIn.Application
               .Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);
 //Lägg till en tom bild
 PowerPoint.Slide sld = pres.Slides.Add(1, PowerPoint.PpSlideLayout.ppLayoutBlank);
 
 //Lägg till en 15 x 15-tabell
 PowerPoint.Shape shp = sld.Shapes.AddTable(15, 15, 10, 10, pres.PageSetup.SlideWidth - 20, 300);
 PowerPoint.Table tbl = shp.Table;
 int i = -1;
 int j = -1;
 
 //Loopa igenom alla rader
 foreach (PowerPoint.Row row in tbl.Rows)
 {
     i = i + 1;
     j = -1;
 
     //Loopa igenom alla celler i raden
     foreach (PowerPoint.Cell cell in row.Cells)
     {
         j = j + 1;
         //Hämta textramen för varje cell
         PowerPoint.TextFrame tf = cell.Shape.TextFrame;
         //Lägg till lite text
         tf.TextRange.Text = "T" + i.ToString() + j.ToString();
         //Ställ in teckenstorlek för texten till 10
         tf.TextRange.Paragraphs(0, tf.TextRange.Text.Length).Font.Size = 10;
     }
 }
 
 //Spara presentationen till disk
 pres.SaveAs("d:\\tblVSTO.ppt",
       PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
       Microsoft.Office.Core.MsoTriState.msoFalse);
```



### **Aspose.Slides for .NET‑exempel**
Följande steg lägger till en tabell i en Microsoft PowerPoint‑bild med Aspose.Slides:

1. Skapa en presentation.  
2. Lägg till en 15 x 15‑tabell på den första bilden.  
3. Lägg till text i varje cell i tabellen med teckenstorlek 10.  
4. Skriv presentationen till disk.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

Presentation pres = new Presentation();

//Åtkomst till första bilden
ISlide sld = pres.Slides[0];

//Definiera kolumner med bredder och rader med höjder
double[] dblCols = { 50, 50, 50 };
double[] dblRows = { 50, 30, 30, 30, 30 };

//Lägg till en tabell
Aspose.Slides.ITable tbl = sld.Shapes.AddTable(50, 50, dblCols, dblRows);

//Ställ in kantformat för varje cell
foreach (IRow row in tbl.Rows)
{
	foreach (ICell cell in row)
	{

		//Hämta textram för varje cell
		ITextFrame tf = cell.TextFrame;
		//Lägg till lite text
		tf.Text = "T" + cell.FirstRowIndex.ToString() + cell.FirstColumnIndex.ToString();
		//Ställ in teckenstorlek till 10
		tf.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 10;
		tf.Paragraphs[0].ParagraphFormat.Bullet.Type = BulletType.None;
	}
}

//Skriv presentationen till disk
pres.Save("tblSLD.ppt", SaveFormat.Ppt);
```