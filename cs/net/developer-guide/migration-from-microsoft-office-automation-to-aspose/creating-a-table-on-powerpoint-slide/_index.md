---
title: Vytváření tabulek pomocí VSTO a Aspose.Slides pro .NET
linktitle: Vytváření tabulek
type: docs
weight: 50
url: /cs/net/creating-a-table-on-powerpoint-slide/
keywords:
- vytvořit tabulku
- migrace
- VSTO
- automatizace Office
- PowerPoint
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Přechod z automatizace Microsoft Office na Aspose.Slides pro .NET a vytváření tabulek v PowerPoint (PPT, PPTX) snímcích v C# s flexibilním formátováním."
---
{{% alert color="primary" %}} 

Tabulky jsou široce používány k zobrazování dat na prezentačních slidích. Tento článek ukazuje, jak programově vytvořit tabulku 15 x 15 s velikostí písma 10, nejprve pomocí [VSTO 2008](/slides/cs/net/creating-a-table-on-powerpoint-slide/) a poté pomocí [Aspose.Slides for .NET](/slides/cs/net/creating-a-table-on-powerpoint-slide/).

{{% /alert %}} 
## **Vytváření tabulek**
#### **Příklad VSTO 2008**
Následující kroky přidají tabulku do snímku Microsoft PowerPoint pomocí VSTO:

1. Vytvořte prezentaci.
1. Přidejte prázdný snímek do prezentace.
1. Přidejte na snímek tabulku 15 x 15.
1. Přidejte do každé buňky tabulky text s velikostí písma 10.
1. Uložte prezentaci na disk.

```c#
//Vytvořit prezentaci
PowerPoint.Presentation pres = Globals.ThisAddIn.Application
              .Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);
//Přidat prázdný snímek
PowerPoint.Slide sld = pres.Slides.Add(1, PowerPoint.PpSlideLayout.ppLayoutBlank);

//Přidat tabulku 15 x 15
PowerPoint.Shape shp = sld.Shapes.AddTable(15, 15, 10, 10, pres.PageSetup.SlideWidth - 20, 300);
PowerPoint.Table tbl = shp.Table;
int i = -1;
int j = -1;

//Procházet všechny řádky
foreach (PowerPoint.Row row in tbl.Rows)
{
    i = i + 1;
    j = -1;

    //Procházet všechny buňky v řádku
    foreach (PowerPoint.Cell cell in row.Cells)
    {
        j = j + 1;
        //Získat textový rámec každé buňky
        PowerPoint.TextFrame tf = cell.Shape.TextFrame;
        //Přidat nějaký text
        tf.TextRange.Text = "T" + i.ToString() + j.ToString();
        //Nastavit velikost písma textu na 10
        tf.TextRange.Paragraphs(0, tf.TextRange.Text.Length).Font.Size = 10;
    }
}

//Uložit prezentaci na disk
pres.SaveAs("d:\\tblVSTO.ppt",
      PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
      Microsoft.Office.Core.MsoTriState.msoFalse);
```



### **Příklad Aspose.Slides pro .NET**
Následující kroky přidají tabulku do snímku Microsoft PowerPoint pomocí Aspose.Slides:

1. Vytvořte prezentaci.
1. Přidejte na první snímek tabulku 15 x 15.
1. Přidejte do každé buňky tabulky text s velikostí písma 10.
1. Zapište prezentaci na disk.

```c#
Presentation pres = new Presentation();

//Přístup k prvnímu snímku
ISlide sld = pres.Slides[0];

//Definovat sloupce s šířkami a řádky s výškami
double[] dblCols = { 50, 50, 50 };
double[] dblRows = { 50, 30, 30, 30, 30 };

//Přidat tabulku
Aspose.Slides.ITable tbl = sld.Shapes.AddTable(50, 50, dblCols, dblRows);

//Nastavit formát okraje pro každou buňku
foreach (IRow row in tbl.Rows)
{
	foreach (ICell cell in row)
	{

		//Získat textový rámec každé buňky
		ITextFrame tf = cell.TextFrame;
		//Přidat nějaký text
		tf.Text = "T" + cell.FirstRowIndex.ToString() + cell.FirstColumnIndex.ToString();
		//Nastavit velikost písma na 10
		tf.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 10;
		tf.Paragraphs[0].ParagraphFormat.Bullet.Type = BulletType.None;
	}
}

//Zapsat prezentaci na disk
pres.Save("C:\\data\\tblSLD.ppt", SaveFormat.Ppt);
```