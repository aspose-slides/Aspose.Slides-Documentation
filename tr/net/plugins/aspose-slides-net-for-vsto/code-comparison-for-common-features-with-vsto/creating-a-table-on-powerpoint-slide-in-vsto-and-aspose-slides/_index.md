---
title: PowerPoint Slaytında VSTO ve Aspose.Slides ile Tablo Oluşturma
type: docs
weight: 90
url: /tr/net/creating-a-table-on-powerpoint-slide-in-vsto-and-aspose-slides/
---
Aşağıdaki adımlar, VSTO kullanarak bir Microsoft PowerPoint slaytına tablo ekler:

- Bir sunum oluşturun.
- Sunuma boş bir slayt ekleyin.
- Slayta 15 x 15 boyutunda bir tablo ekleyin.
- Tablodaki her hücreye 10 punto yazı tipi boyutunda metin ekleyin.
- Sunumu diske kaydedin.
## **VSTO**
``` csharp

 //Bir sunum oluştur

PowerPoint.Presentation pres = Globals.ThisAddIn.Application

			  .Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//Boş bir slayt ekle

PowerPoint.Slide sld = pres.Slides.Add(1, PowerPoint.PpSlideLayout.ppLayoutBlank);

//15 x 15 tablo ekle

PowerPoint.Shape shp = sld.Shapes.AddTable(15, 15, 10, 10, pres.PageSetup.SlideWidth - 20, 300);

PowerPoint.Table tbl = shp.Table;

int i = -1;

int j = -1;

//Tüm satırlarda döngü

foreach (PowerPoint.Row row in tbl.Rows)

{

	i = i + 1;

	j = -1;

	//Satırdaki tüm hücrelerde döngü

	foreach (PowerPoint.Cell cell in row.Cells)

	{

		j = j + 1;

		//Her hücrenin metin çerçevesini al

		PowerPoint.TextFrame tf = cell.Shape.TextFrame;

		//Metin ekle

		tf.TextRange.Text = "T" + i.ToString() + j.ToString();

		//Metnin punto boyutunu 10 olarak ayarla

		tf.TextRange.Paragraphs(0, tf.TextRange.Text.Length).Font.Size = 10;

	}

}

//Sunumu diske kaydet

pres.SaveAs("tblVSTO.ppt",

	  PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,

	  Microsoft.Office.Core.MsoTriState.msoFalse);
``` 

Aşağıdaki adımlar, Aspose.Slides kullanarak bir Microsoft PowerPoint slaytına tablo ekler:

- Bir sunum oluşturun.
- İlk slayta 15 x 15 boyutunda bir tablo ekleyin.
- Tablodaki her hücreye 10 punto yazı tipi boyutunda metin ekleyin.
- Sunumu diske yazın.
## **Aspose.Slides**
``` csharp

 //Bir sunum oluştur
Presentation pres = new Presentation();
//İlk slayta eriş
Slide sld = pres.GetSlideByPosition(1);
//Bir tablo ekle
Aspose.Slides.Table tbl = sld.Shapes.AddTable(50, 50, pres.SlideSize.Width - 100, pres.SlideSize.Height - 100, 15, 15);
//Satırlar arasında döngü
for (int i = 0; i < tbl.RowsNumber; i++)
	//Hücreler arasında döngü
	for (int j = 0; j < tbl.ColumnsNumber; j++)
	{
		//Her hücrenin metin çerçevesini al
		TextFrame tf = tbl.GetCell(j, i).TextFrame;
		//Metin ekle
		tf.Text = "T" + i.ToString() + j.ToString();
		//Yazı tipi boyutunu 10 olarak ayarla
		tf.Paragraphs[0].Portions[0].FontHeight = 10;
		tf.Paragraphs[0].HasBullet = false;
	}
//Sunumu diske yaz
pres.Write("tblSLD.ppt");
``` 
## **Örnek Kodu İndir**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Creating.a.Table.on.PowerPoint.Slide.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Creating%20a%20Table%20on%20PowerPoint%20Slide%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/src/master/Aspose.Slides%20Vs%20VSTO%20Slides/Creating%20a%20Table%20on%20PowerPoint%20Slide/)