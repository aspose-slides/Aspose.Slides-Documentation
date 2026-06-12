---
title: Membuat Tabel pada Slide PowerPoint dengan VSTO dan Aspose.Slides
type: docs
weight: 90
url: /id/net/creating-a-table-on-powerpoint-slide-in-vsto-and-aspose-slides/
---
Langkah-langkah berikut menambahkan tabel ke slide Microsoft PowerPoint menggunakan VSTO:

- Buat presentasi.
- Tambahkan slide kosong ke presentasi.
- Tambahkan tabel 15 x 15 ke slide.
- Tambahkan teks ke setiap sel tabel dengan ukuran font 10.
- Simpan presentasi ke disk.
## **VSTO**
``` csharp

 //Buat presentasi

PowerPoint.Presentation pres = Globals.ThisAddIn.Application

			  .Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//Tambahkan slide kosong

PowerPoint.Slide sld = pres.Slides.Add(1, PowerPoint.PpSlideLayout.ppLayoutBlank);

//Tambahkan tabel 15 x 15

PowerPoint.Shape shp = sld.Shapes.AddTable(15, 15, 10, 10, pres.PageSetup.SlideWidth - 20, 300);

PowerPoint.Table tbl = shp.Table;

int i = -1;

int j = -1;

//Iterasi semua baris

foreach (PowerPoint.Row row in tbl.Rows)

{

	i = i + 1;

	j = -1;

	//Iterasi semua sel dalam baris

	foreach (PowerPoint.Cell cell in row.Cells)

	{

		j = j + 1;

		//Dapatkan frame teks setiap sel

		PowerPoint.TextFrame tf = cell.Shape.TextFrame;

		//Tambahkan teks

		tf.TextRange.Text = "T" + i.ToString() + j.ToString();

		//Setel ukuran font teks menjadi 10

		tf.TextRange.Paragraphs(0, tf.TextRange.Text.Length).Font.Size = 10;

	}

}

//Simpan presentasi ke disk

pres.SaveAs("tblVSTO.ppt",

	  PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,

	  Microsoft.Office.Core.MsoTriState.msoFalse);

``` 

Langkah-langkah berikut menambahkan tabel ke slide Microsoft PowerPoint menggunakan Aspose.Slides:

- Buat presentasi.
- Tambahkan tabel 15 x 15 ke slide pertama.
- Tambahkan teks ke setiap sel tabel dengan ukuran font 10.
- Tuliskan presentasi ke disk.
## **Aspose.Slides**
``` csharp

 //Buat presentasi

Presentation pres = new Presentation();

 //Akses slide pertama

Slide sld = pres.GetSlideByPosition(1);

 //Tambahkan tabel

Aspose.Slides.Table tbl = sld.Shapes.AddTable(50, 50, pres.SlideSize.Width - 100, pres.SlideSize.Height - 100, 15, 15);

 //Iterasi melalui baris

for (int i = 0; i < tbl.RowsNumber; i++)

	//Iterasi melalui sel

	for (int j = 0; j < tbl.ColumnsNumber; j++)

	{

		//Dapatkan frame teks setiap sel

		TextFrame tf = tbl.GetCell(j, i).TextFrame;

		//Tambahkan teks

		tf.Text = "T" + i.ToString() + j.ToString();

		//Setel ukuran font menjadi 10

		tf.Paragraphs[0].Portions[0].FontHeight = 10;

		tf.Paragraphs[0].HasBullet = false;

	}

//Tuliskan presentasi ke disk

pres.Write("tblSLD.ppt");

``` 
## **Unduh Kode Contoh**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Creating.a.Table.on.PowerPoint.Slide.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Creating%20a%20Table%20on%20PowerPoint%20Slide%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/src/master/Aspose.Slides%20Vs%20VSTO%20Slides/Creating%20a%20Table%20on%20PowerPoint%20Slide/)