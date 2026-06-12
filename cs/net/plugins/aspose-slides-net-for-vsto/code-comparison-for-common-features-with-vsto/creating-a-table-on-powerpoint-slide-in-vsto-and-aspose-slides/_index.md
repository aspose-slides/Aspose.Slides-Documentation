---
title: Vytvoření tabulky na snímku PowerPointu ve VSTO a Aspose.Slides
type: docs
weight: 90
url: /cs/net/creating-a-table-on-powerpoint-slide-in-vsto-and-aspose-slides/
---
Následující kroky přidají tabulku do snímku Microsoft PowerPoint pomocí VSTO:

- Vytvořte prezentaci.
- Přidejte prázdný snímek do prezentace.
- Přidejte na snímek tabulku 15 x 15.
- Přidejte text do každé buňky tabulky s velikostí písma 10.
- Uložte prezentaci na disk.
## **VSTO**
``` csharp

 //Vytvořte prezentaci

PowerPoint.Presentation pres = Globals.ThisAddIn.Application

			  .Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//Přidejte prázdný snímek

PowerPoint.Slide sld = pres.Slides.Add(1, PowerPoint.PpSlideLayout.ppLayoutBlank);

//Přidejte tabulku 15 x 15

PowerPoint.Shape shp = sld.Shapes.AddTable(15, 15, 10, 10, pres.PageSetup.SlideWidth - 20, 300);

PowerPoint.Table tbl = shp.Table;

int i = -1;

int j = -1;

//Projděte všechny řádky

foreach (PowerPoint.Row row in tbl.Rows)

{

	i = i + 1;

	j = -1;

	//Projděte všechny buňky v řádku

	foreach (PowerPoint.Cell cell in row.Cells)

	{

		j = j + 1;

		//Získejte textový rámec každé buňky

		PowerPoint.TextFrame tf = cell.Shape.TextFrame;

		//Přidejte nějaký text

		tf.TextRange.Text = "T" + i.ToString() + j.ToString();

		//Nastavte velikost písma textu na 10

		tf.TextRange.Paragraphs(0, tf.TextRange.Text.Length).Font.Size = 10;

	}

}

//Uložte prezentaci na disk

pres.SaveAs("tblVSTO.ppt",

	  PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,

	  Microsoft.Office.Core.MsoTriState.msoFalse);

``` 

Následující kroky přidají tabulku do snímku Microsoft PowerPoint pomocí Aspose.Slides:

- Vytvořte prezentaci.
- Přidejte tabulku 15 x 15 na první snímek.
- Přidejte text do každé buňky tabulky s velikostí písma 10.
- Zapište prezentaci na disk.
## **Aspose.Slides**
``` csharp

 //Vytvořte prezentaci
Presentation pres = new Presentation();
//Získejte první snímek
Slide sld = pres.GetSlideByPosition(1);
//Přidejte tabulku
Aspose.Slides.Table tbl = sld.Shapes.AddTable(50, 50, pres.SlideSize.Width - 100, pres.SlideSize.Height - 100, 15, 15);
//Projděte řádky
for (int i = 0; i < tbl.RowsNumber; i++)
	//Projděte buňky
	for (int j = 0; j < tbl.ColumnsNumber; j++)
	{
		//Získejte textový rámec každé buňky
		TextFrame tf = tbl.GetCell(j, i).TextFrame;
		//Přidejte nějaký text
		tf.Text = "T" + i.ToString() + j.ToString();
		//Nastavte velikost písma na 10
		tf.Paragraphs[0].Portions[0].FontHeight = 10;
		tf.Paragraphs[0].HasBullet = false;
	}
//Zapište prezentaci na disk
pres.Write("tblSLD.ppt");

``` 
## **Stáhnout ukázkový kód**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Creating.a.Table.on.PowerPoint.Slide.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Creating%20a%20Table%20on%20PowerPoint%20Slide%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/src/master/Aspose.Slides%20Vs%20VSTO%20Slides/Creating%20a%20Table%20on%20PowerPoint%20Slide/)