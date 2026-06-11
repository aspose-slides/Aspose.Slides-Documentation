---
title: Tworzenie tabel przy użyciu VSTO i Aspose.Slides dla .NET
linktitle: Tworzenie tabel
type: docs
weight: 50
url: /pl/net/creating-a-table-on-powerpoint-slide/
keywords:
- tworzenie tabeli
- migracja
- VSTO
- automatyzacja Office
- PowerPoint
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Migruj z automatyzacji Microsoft Office do Aspose.Slides dla .NET i twórz tabele w slajdach PowerPoint (PPT, PPTX) w C# z elastycznym formatowaniem."
---
{{% alert color="primary" %}} 

Tabele są powszechnie używane do wyświetlania danych na slajdach prezentacji. Ten artykuł pokazuje, jak programowo utworzyć tabelę 15 x 15 o rozmiarze czcionki 10, najpierw przy użyciu [VSTO 2008](/slides/pl/net/creating-a-table-on-powerpoint-slide/) i potem [Aspose.Slides for .NET](/slides/pl/net/creating-a-table-on-powerpoint-slide/).

{{% /alert %}} 
## **Tworzenie tabel**
#### **Przykład VSTO 2008**
Poniższe kroki dodają tabelę do slajdu Microsoft PowerPoint przy użyciu VSTO:

1. Utwórz prezentację.
1. Dodaj pusty slajd do prezentacji.
1. Dodaj tabelę 15 x 15 do slajdu.
1. Dodaj tekst do każdej komórki tabeli o rozmiarze czcionki 10.
1. Zapisz prezentację na dysku.

```c#
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

    //Iteruj po wszystkich komórkach wiersza
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
pres.SaveAs("d:\\tblVSTO.ppt",
      PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
      Microsoft.Office.Core.MsoTriState.msoFalse);
```



### **Przykład Aspose.Slides for .NET**
Poniższe kroki dodają tabelę do slajdu Microsoft PowerPoint przy użyciu Aspose.Slides:

1. Utwórz prezentację.
1. Dodaj tabelę 15 x 15 do pierwszego slajdu.
1. Dodaj tekst do każdej komórki tabeli o rozmiarze czcionki 10.
1. Zapisz prezentację na dysku.

```c#
Presentation pres = new Presentation();

//Uzyskaj dostęp do pierwszego slajdu
ISlide sld = pres.Slides[0];

//Zdefiniuj kolumny o szerokościach i wiersze o wysokościach
double[] dblCols = { 50, 50, 50 };
double[] dblRows = { 50, 30, 30, 30, 30 };

//Dodaj tabelę
Aspose.Slides.ITable tbl = sld.Shapes.AddTable(50, 50, dblCols, dblRows);

//Ustaw format obramowania dla każdej komórki
foreach (IRow row in tbl.Rows)
{
	foreach (ICell cell in row)
	{

		//Pobierz ramkę tekstową każdej komórki
		ITextFrame tf = cell.TextFrame;
		//Dodaj tekst
		tf.Text = "T" + cell.FirstRowIndex.ToString() + cell.FirstColumnIndex.ToString();
		//Ustaw rozmiar czcionki na 10
		tf.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 10;
		tf.Paragraphs[0].ParagraphFormat.Bullet.Type = BulletType.None;
	}
}

//Zapisz prezentację na dysku
pres.Save("C:\\data\\tblSLD.ppt", SaveFormat.Ppt);
```