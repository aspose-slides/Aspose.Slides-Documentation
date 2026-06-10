---
title: Táblázatok létrehozása VSTO és Aspose.Slides for .NET használatával
linktitle: Táblázatok létrehozása
type: docs
weight: 50
url: /hu/net/creating-a-table-on-powerpoint-slide/
keywords:
- táblázat létrehozás
- migráció
- VSTO
- Office automatizálás
- PowerPoint
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Migráljon a Microsoft Office automatizálásról az Aspose.Slides for .NET-re, és hozzon létre táblázatokat PowerPoint (PPT, PPTX) diákon C# nyelven rugalmas formázással."
---
{{% alert color="primary" %}} 
A táblázatokat széles körben használják adatok megjelenítésére a bemutató diákon. Ez a cikk bemutatja, hogyan hozhatunk létre programból 15 x 15 méretű táblázatot 10-es betűmérettel, először a [VSTO 2008](/slides/hu/net/creating-a-table-on-powerpoint-slide/) használatával, majd a [Aspose.Slides for .NET](/slides/hu/net/creating-a-table-on-powerpoint-slide/) segítségével.
{{% /alert %}} 
## **Táblázatok létrehozása**
#### **VSTO 2008 példa**
A következő lépések egy táblázatot adnak hozzá egy Microsoft PowerPoint diára a VSTO használatával:

1. Hozzon létre egy bemutatót.
1. Adjon hozzá egy üres diát a bemutatóhoz.
1. Adjon hozzá egy 15 x 15 méretű táblázatot a diához.
1. Adjon szöveget a táblázat minden cellájához 10-es betűmérettel.
1. Mentse a bemutatót a lemezre.

```c#
//Prezentáció létrehozása
PowerPoint.Presentation pres = Globals.ThisAddIn.Application
              .Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);
//Üres dia hozzáadása
PowerPoint.Slide sld = pres.Slides.Add(1, PowerPoint.PpSlideLayout.ppLayoutBlank);

//15 x 15-ös táblázat hozzáadása
PowerPoint.Shape shp = sld.Shapes.AddTable(15, 15, 10, 10, pres.PageSetup.SlideWidth - 20, 300);
PowerPoint.Table tbl = shp.Table;
int i = -1;
int j = -1;

//Az összes sor bejárása
foreach (PowerPoint.Row row in tbl.Rows)
{
    i = i + 1;
    j = -1;

    //Az adott sor összes cellájának bejárása
    foreach (PowerPoint.Cell cell in row.Cells)
    {
        j = j + 1;
        //Minden cella szövegkeretének lekérése
        PowerPoint.TextFrame tf = cell.Shape.TextFrame;
        //Szöveg hozzáadása
        tf.TextRange.Text = "T" + i.ToString() + j.ToString();
        //A szöveg betűméretének beállítása 10-re
        tf.TextRange.Paragraphs(0, tf.TextRange.Text.Length).Font.Size = 10;
    }
}

//A prezentáció mentése lemezre
pres.SaveAs("d:\\tblVSTO.ppt",
      PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
      Microsoft.Office.Core.MsoTriState.msoFalse);
```



### **Aspose.Slides for .NET példa**
A következő lépések egy táblázatot adnak hozzá egy Microsoft PowerPoint diára az Aspose.Slides használatával:

1. Hozzon létre egy bemutatót.
1. Adjon hozzá egy 15 x 15 méretű táblázatot az első diára.
1. Adjon szöveget a táblázat minden cellájához 10-es betűmérettel.
1. Írja a bemutatót a lemezre.

```c#
Presentation pres = new Presentation();

//Első dia elérése
ISlide sld = pres.Slides[0];

//Oszlopok definiálása szélességekkel és sorok magasságokkal
double[] dblCols = { 50, 50, 50 };
double[] dblRows = { 50, 30, 30, 30, 30 };

//Táblázat hozzáadása
Aspose.Slides.ITable tbl = sld.Shapes.AddTable(50, 50, dblCols, dblRows);

//Szegélyformátum beállítása minden cellához
foreach (IRow row in tbl.Rows)
{
	foreach (ICell cell in row)
	{

		//Minden cella szövegkeretének lekérése
		ITextFrame tf = cell.TextFrame;
		//Szöveg hozzáadása
		tf.Text = "T" + cell.FirstRowIndex.ToString() + cell.FirstColumnIndex.ToString();
		//Betűméret beállítása 10
		tf.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 10;
		tf.Paragraphs[0].ParagraphFormat.Bullet.Type = BulletType.None;
	}
}

//A prezentáció írása a lemezre
pres.Save("C:\\data\\tblSLD.ppt", SaveFormat.Ppt);
```