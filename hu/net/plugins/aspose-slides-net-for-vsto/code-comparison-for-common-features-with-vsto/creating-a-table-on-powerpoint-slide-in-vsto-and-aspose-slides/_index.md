---
title: Táblázat létrehozása PowerPoint dián VSTO és Aspose.Slides használatával
type: docs
weight: 90
url: /hu/net/creating-a-table-on-powerpoint-slide-in-vsto-and-aspose-slides/
---
A következő lépések egy táblázat hozzáadását mutatják be egy Microsoft PowerPoint diára VSTO használatával:

- Prezentáció létrehozása.
- Üres diát ad hozzá a prezentációhoz.
- 15×15-ös táblázat hozzáadása a diához.
- Szöveg hozzáadása a táblázat minden cellájához 10-es betűmérettel.
- A prezentáció mentése a lemezre.
## **VSTO**
``` csharp

 //Prezentáció létrehozása

PowerPoint.Presentation pres = Globals.ThisAddIn.Application

			  .Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//Üres diát ad hozzá

PowerPoint.Slide sld = pres.Slides.Add(1, PowerPoint.PpSlideLayout.ppLayoutBlank);

//15×15-ös táblázat hozzáadása

PowerPoint.Shape shp = sld.Shapes.AddTable(15, 15, 10, 10, pres.PageSetup.SlideWidth - 20, 300);

PowerPoint.Table tbl = shp.Table;

int i = -1;

int j = -1;

//Az összes sort bejárja

foreach (PowerPoint.Row row in tbl.Rows)

{

	i = i + 1;

	j = -1;

		//A sor összes celláját bejárja

	foreach (PowerPoint.Cell cell in row.Cells)

	{

		j = j + 1;

		//Minden cella szövegkeretének lekérése

		PowerPoint.TextFrame tf = cell.Shape.TextFrame;

		//Néhány szöveget ad hozzá

		tf.TextRange.Text = "T" + i.ToString() + j.ToString();

		//A szöveg betűméretének beállítása 10-re

		tf.TextRange.Paragraphs(0, tf.TextRange.Text.Length).Font.Size = 10;

	}

}

//A prezentáció mentése a lemezre

pres.SaveAs("tblVSTO.ppt",

	  PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,

	  Microsoft.Office.Core.MsoTriState.msoFalse);

``` 

A következő lépések egy táblázat hozzáadását mutatják be egy Microsoft PowerPoint diára Aspose.Slides használatával:

- Prezentáció létrehozása.
- 15×15-ös táblázat hozzáadása az első diára.
- Szöveg hozzáadása a táblázat minden cellájához 10-es betűmérettel.
- A prezentáció írása a lemezre.
## **Aspose.Slides**
``` csharp

 //Prezentáció létrehozása
Presentation pres = new Presentation();
 //Első dia elérése
Slide sld = pres.GetSlideByPosition(1);
 //Táblázat hozzáadása
Aspose.Slides.Table tbl = sld.Shapes.AddTable(50, 50, pres.SlideSize.Width - 100, pres.SlideSize.Height - 100, 15, 15);
 //Sorok bejárása
for (int i = 0; i < tbl.RowsNumber; i++)
	 //Cellák bejárása
	for (int j = 0; j < tbl.ColumnsNumber; j++)
	{
		//Minden cella szövegkeretének lekérése
		TextFrame tf = tbl.GetCell(j, i).TextFrame;
		//Néhány szöveg hozzáadása
		tf.Text = "T" + i.ToString() + j.ToString();
		//Betűméret beállítása 10
		tf.Paragraphs[0].Portions[0].FontHeight = 10;
		tf.Paragraphs[0].HasBullet = false;
	}
 //A prezentáció írása a lemezre
pres.Write("tblSLD.ppt");
``` 
## **Minta kód letöltése**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Creating.a.Table.on.PowerPoint.Slide.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Creating%20a%20Table%20on%20PowerPoint%20Slide%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/src/master/Aspose.Slides%20Vs%20VSTO%20Slides/Creating%20a%20Table%20on%20PowerPoint%20Slide/)