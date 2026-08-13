---
title: Táblázatok létrehozása VSTO és Aspose.Slides for .NET használatával
linktitle: Táblázatok létrehozása
type: docs
weight: 50
url: /hu/net/creating-a-table-on-powerpoint-slide/
keywords:
- táblázat létrehozása
- migráció
- VSTO
- Office automatizálás
- PowerPoint
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Migráljon a Microsoft Office automatizálásról az Aspose.Slides for .NET-re, és hozza létre a táblázatokat PowerPoint (PPT, PPTX) diákon C#-ban rugalmas formázással."
---
{{% alert color="info" %}} 

A táblázatokat széles körben használják adatok megjelenítésére a prezentációs diákon. Ez a cikk bemutatja, hogyan hozhatunk létre programozottan egy 15 x 15-ös táblázatot 10-es betűmérettel, először a [VSTO 2008](/slides/hu/net/creating-a-table-on-powerpoint-slide/) segítségével, majd az [Aspose.Slides for .NET](/slides/hu/net/creating-a-table-on-powerpoint-slide/) használatával.

{{% /alert %}} 
## **Táblázatok létrehozása**
#### **VSTO 2008 példa**
A következő lépések egy táblázatot adnak hozzá egy Microsoft PowerPoint diára VSTO használatával:

1. Készítsen egy prezentációt.
1. Adjon egy üres diát a prezentációhoz.
1. Adjon egy 15 x 15-ös táblázatot a diához.
1. Adjon szöveget a táblázat minden cellájába 10-es betűmérettel.
1. Mentse a prezentációt a lemezre.

```c#
//Készítsen egy prezentációt
PowerPoint.Presentation pres = Globals.ThisAddIn.Application
              .Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);
//Adjon hozzá egy üres diát
PowerPoint.Slide sld = pres.Slides.Add(1, PowerPoint.PpSlideLayout.ppLayoutBlank);

//Adjon hozzá egy 15 x 15-es táblázatot
PowerPoint.Shape shp = sld.Shapes.AddTable(15, 15, 10, 10, pres.PageSetup.SlideWidth - 20, 300);
PowerPoint.Table tbl = shp.Table;
int i = -1;
int j = -1;

//Iteráljon az összes soron
foreach (PowerPoint.Row row in tbl.Rows)
{
    i = i + 1;
    j = -1;

    //Iteráljon az adott sor összes celláján
    foreach (PowerPoint.Cell cell in row.Cells)
    {
        j = j + 1;
        //Szerezze be az egyes cellák szövegkeretét
        PowerPoint.TextFrame tf = cell.Shape.TextFrame;
        //Adjon hozzá egy kis szöveget
        tf.TextRange.Text = "T" + i.ToString() + j.ToString();
        //Állítsa be a szöveg betűméretét 10-re
        tf.TextRange.Paragraphs(0, tf.TextRange.Text.Length).Font.Size = 10;
    }
}

//Mentse a prezentációt lemezre
pres.SaveAs("d:\\tblVSTO.ppt",
      PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
      Microsoft.Office.Core.MsoTriState.msoFalse);
```



### **Aspose.Slides for .NET példa**
A következő lépések egy táblázatot adnak hozzá egy Microsoft PowerPoint diára Aspose.Slides használatával:

1. Készítsen egy prezentációt.
1. Adjon egy 15 x 15-ös táblázatot az első diára.
1. Adjon szöveget a táblázat minden cellájába 10-es betűmérettel.
1. Írja a prezentációt a lemezre.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

Presentation pres = new Presentation();

//Az első diát elérjük
ISlide sld = pres.Slides[0];

//Oszlopok szélességének és sorok magasságának definiálása
double[] dblCols = { 50, 50, 50 };
double[] dblRows = { 50, 30, 30, 30, 30 };

//Táblázat hozzáadása
Aspose.Slides.ITable tbl = sld.Shapes.AddTable(50, 50, dblCols, dblRows);

//Minden cellához szegélyformátum beállítása
foreach (IRow row in tbl.Rows)
{
	foreach (ICell cell in row)
	{

		//Az egyes cellák szövegkeretének lekérése
		ITextFrame tf = cell.TextFrame;
		//Szöveg hozzáadása
		tf.Text = "T" + cell.FirstRowIndex.ToString() + cell.FirstColumnIndex.ToString();
		//Betűméret beállítása 10-re
		tf.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 10;
		tf.Paragraphs[0].ParagraphFormat.Bullet.Type = BulletType.None;
	}
}

//A prezentáció mentése a lemezre
pres.Save("tblSLD.ppt", SaveFormat.Ppt);
```