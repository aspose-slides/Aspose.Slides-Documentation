---
title: Tworzenie tabeli na slajdzie PowerPoint w VSTO i Aspose.Slides
type: docs
weight: 90
url: /pl/net/creating-a-table-on-powerpoint-slide-in-vsto-and-aspose-slides/
---
Poniższe kroki dodają tabelę do slajdu Microsoft PowerPoint przy użyciu VSTO:

- Utwórz prezentację.
- Dodaj pusty slajd do prezentacji.
- Dodaj tabelę 15 x 15 do slajdu.
- Dodaj tekst do każdej komórki tabeli o rozmiarze czcionki 10.
- Zapisz prezentację na dysku.
## **VSTO**
``` csharp

 //Utwórz prezentację

PowerPoint.Presentation pres = Globals.ThisAddIn.Application

			  .Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//Dodaj pusty slajd

PowerPoint.Slide sld = pres.Slides.Add(1, PowerPoint.PpSlideLayout.ppLayoutBlank);

//Dodaj tabelę 15 x 15

PowerPoint.Shape shp = sld.Shapes.AddTable(15, 15, 10, 10, pres.PageSetup.SlideWidth - 20, 300);

PowerPoint.Table tbl = shp.Table;

int i = -1;

int j = -1;

//Iteruj po wszystkich wierszach

foreach (PowerPoint.Row row in tbl.Rows)

{

	i = i + 1;

	j = -1;

		//Iteruj po wszystkich komórkach w wierszu

	foreach (PowerPoint.Cell cell in row.Cells)

	{

		j = j + 1;

			//Pobierz ramkę tekstową każdej komórki

		PowerPoint.TextFrame tf = cell.Shape.TextFrame;

			//Dodaj tekst

		tf.TextRange.Text = "T" + i.ToString() + j.ToString();

			//Ustaw rozmiar czcionki tekstu na 10

		tf.TextRange.Paragraphs(0, tf.TextRange.Text.Length).Font.Size = 10;

	}

}

//Zapisz prezentację na dysku

pres.SaveAs("tblVSTO.ppt",

	  PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,

	  Microsoft.Office.Core.MsoTriState.msoFalse);

``` 

Poniższe kroki dodają tabelę do slajdu Microsoft PowerPoint przy użyciu Aspose.Slides:

- Utwórz prezentację.
- Dodaj tabelę 15 x 15 do pierwszego slajdu.
- Dodaj tekst do każdej komórki tabeli o rozmiarze czcionki 10.
- Zapisz prezentację na dysku.
## **Aspose.Slides**
``` csharp

 //Utwórz prezentację

Presentation pres = new Presentation();

//Uzyskaj dostęp do pierwszego slajdu

Slide sld = pres.GetSlideByPosition(1);

//Dodaj tabelę

Aspose.Slides.Table tbl = sld.Shapes.AddTable(50, 50, pres.SlideSize.Width - 100, pres.SlideSize.Height - 100, 15, 15);

//Iteruj po wierszach

for (int i = 0; i < tbl.RowsNumber; i++)
	//Iteruj po komórkach

	for (int j = 0; j < tbl.ColumnsNumber; j++)
	{
		//Pobierz ramkę tekstową każdej komórki

		TextFrame tf = tbl.GetCell(j, i).TextFrame;
		//Dodaj tekst

		tf.Text = "T" + i.ToString() + j.ToString();
		//Ustaw rozmiar czcionki na 10

		tf.Paragraphs[0].Portions[0].FontHeight = 10;
		tf.Paragraphs[0].HasBullet = false;
	}

//Zapisz prezentację na dysku

pres.Write("tblSLD.ppt");

``` 
## **Pobierz przykładowy kod**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Creating.a.Table.on.PowerPoint.Slide.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Creating%20a%20Table%20on%20PowerPoint%20Slide%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/src/master/Aspose.Slides%20Vs%20VSTO%20Slides/Creating%20a%20Table%20on%20PowerPoint%20Slide/)