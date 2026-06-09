---
title: VSTO ve Aspose.Slides for .NET Kullanarak Tablolar Oluşturma
linktitle: Tablolar Oluşturma
type: docs
weight: 50
url: /tr/net/creating-a-table-on-powerpoint-slide/
keywords:
- tablo oluşturma
- göç
- VSTO
- Office otomasyonu
- PowerPoint
- sunum
- .NET
- C#
- Aspose.Slides
description: "Microsoft Office otomasyonundan Aspose.Slides for .NET'e geçiş yapın ve C# ile esnek biçimlendirme seçenekleriyle PowerPoint (PPT, PPTX) slaytlarında tablolar oluşturun."
---
{{% alert color="primary" %}}
Tablolar, sunum slaytlarında verileri görüntülemek için yaygın olarak kullanılır. Bu makale, önce [VSTO 2008](/slides/tr/net/creating-a-table-on-powerpoint-slide/) ve ardından [Aspose.Slides for .NET](/slides/tr/net/creating-a-table-on-powerpoint-slide/) kullanarak programlı olarak 10 punto boyutunda 15 x 15 bir tablo nasıl oluşturulacağını gösterir.
{{% /alert %}}
## **Tablo Oluşturma**
#### **VSTO 2008 Örneği**
Aşağıdaki adımlar VSTO kullanarak bir Microsoft PowerPoint slaytına tablo ekler:

1. Bir sunum oluşturun.
1. Sunuma boş bir slayt ekleyin.
1. Slayta 15 x 15 bir tablo ekleyin.
1. Tablonun her hücresine 10 punto boyutunda metin ekleyin.
1. Sunumu diske kaydedin.

```c#
 //Sunum oluştur
PowerPoint.Presentation pres = Globals.ThisAddIn.Application
              .Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);
//Boş bir slayt ekle
PowerPoint.Slide sld = pres.Slides.Add(1, PowerPoint.PpSlideLayout.ppLayoutBlank);

//15 x 15 bir tablo ekle
PowerPoint.Shape shp = sld.Shapes.AddTable(15, 15, 10, 10, pres.PageSetup.SlideWidth - 20, 300);
PowerPoint.Table tbl = shp.Table;
int i = -1;
int j = -1;

//Tüm satırları dolaş
foreach (PowerPoint.Row row in tbl.Rows)
{
    i = i + 1;
    j = -1;

    //Satırdaki tüm hücreleri dolaş
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
pres.SaveAs("d:\\tblVSTO.ppt",
      PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
      Microsoft.Office.Core.MsoTriState.msoFalse);
```

### **Aspose.Slides for .NET Örneği**
Aşağıdaki adımlar Aspose.Slides kullanarak bir Microsoft PowerPoint slaytına tablo ekler:

1. Bir sunum oluşturun.
1. İlk slayta 15 x 15 bir tablo ekleyin.
1. Tablonun her hücresine 10 punto boyutunda metin ekleyin.
1. Sunumu diske yazın.

```c#
Presentation pres = new Presentation();

//İlk slayta eriş
ISlide sld = pres.Slides[0];

//Genişliklerle sütunları ve yüksekliklerle satırları tanımla
double[] dblCols = { 50, 50, 50 };
double[] dblRows = { 50, 30, 30, 30, 30 };

//Bir tablo ekle
Aspose.Slides.ITable tbl = sld.Shapes.AddTable(50, 50, dblCols, dblRows);

//Her hücre için kenarlık biçimini ayarla
foreach (IRow row in tbl.Rows)
{
		foreach (ICell cell in row)
		{

			//Her hücrenin metin çerçevesini al
			ITextFrame tf = cell.TextFrame;
			//Biraz metin ekle
			tf.Text = "T" + cell.FirstRowIndex.ToString() + cell.FirstColumnIndex.ToString();
			//Yazı tipinin punto boyutunu 10 olarak ayarla
			tf.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 10;
			tf.Paragraphs[0].ParagraphFormat.Bullet.Type = BulletType.None;
		}
}

//Sunumu diske yaz
pres.Save("C:\\data\\tblSLD.ppt", SaveFormat.Ppt);
```