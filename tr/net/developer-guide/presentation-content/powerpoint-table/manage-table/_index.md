---
title: .NET'te Sunum Tablolarını Yönetme
linktitle: Tabloyu Yönet
type: docs
weight: 10
url: /tr/net/manage-table/
keywords:
- tablo ekle
- tablo oluştur
- tablo erişimi
- en–boy oranı
- metni hizala
- metin biçimlendirme
- tablo stili
- PowerPoint
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET ile PowerPoint slaytlarında tablo oluşturun ve düzenleyin. Tablo iş akışlarınızı kolaylaştırmak için basit C# kod örneklerini keşfedin."
---
## **Giriş**

PowerPoint'teki bir tablo, bilgiyi göstermek ve tasvir etmek için verimli bir yoldur. Hücrelerden oluşan bir ızgaradaki (satır ve sütun olarak düzenlenmiş) bilgi, doğrudan ve anlaşılması kolaydır.

Aspose.Slides, bir tablo oluşturmanıza, güncellemenize ve yönetmenize olanak tanıyan [Table](https://reference.aspose.com/slides/tr/net/aspose.slides/table/) sınıfını, [ITable](https://reference.aspose.com/slides/tr/net/aspose.slides/itable/) arayüzünü, [Cell](https://reference.aspose.com/slides/tr/net/aspose.slides/cell/) sınıfını, [ICell](https://reference.aspose.com/slides/tr/net/aspose.slides/icell/) arayüzünü ve diğer türleri sağlar. 

## **Sıfırdan Tablo Oluşturma**

1. [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation) sınıfının bir örneğini oluşturun.  
2. Slaytın referansını indeks üzerinden alın.  
3. `columnWidth` dizisini tanımlayın.  
4. `rowHeight` dizisini tanımlayın.  
5. [AddTable](https://reference.aspose.com/slides/tr/net/aspose.slides/ishapecollection/addtable/) yöntemiyle slayta bir [ITable](https://reference.aspose.com/slides/tr/net/aspose.slides/itable/) nesnesi ekleyin.  
6. Her bir [ICell](https://reference.aspose.com/slides/tr/net/aspose.slides/icell/) üzerinden yineleme yaparak üst, alt, sağ ve sol kenarlara biçimlendirme uygulayın.  
7. Tablonun ilk satırındaki ilk iki hücreyi birleştirin.  
8. Bir [ICell](https://reference.aspose.com/slides/tr/net/aspose.slides/icell/)'in [TextFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/textframe/) 'ine erişin.  
9. [TextFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/textframe/)'e bir miktar metin ekleyin.  
10. Değiştirilmiş sunumu kaydedin.

Bu C# kodu, bir sunumda tablo oluşturmayı gösterir:

```c#
// PPTX dosyasını temsil eden bir Presentation sınıfı örnekleyerek oluşturur
Presentation pres = new Presentation();

// İlk slayta erişir
ISlide sld = pres.Slides[0];

// Sütunları genişlikleri ve satırları yükseklikleriyle tanımlar
double[] dblCols = { 50, 50, 50 };
double[] dblRows = { 50, 30, 30, 30, 30 };

// Slayta bir tablo şekli ekler
ITable tbl = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

// Her hücre için kenar biçimini ayarlar
for (int row = 0; row < tbl.Rows.Count; row++)
{
	for (int cell = 0; cell < tbl.Rows[row].Count; cell++)
	{
		tbl.Rows[row][cell].CellFormat.BorderTop.FillFormat.FillType = FillType.Solid;
		tbl.Rows[row][cell].CellFormat.BorderTop.FillFormat.SolidFillColor.Color = Color.Red;
		tbl.Rows[row][cell].CellFormat.BorderTop.Width = 5;

		tbl.Rows[row][cell].CellFormat.BorderBottom.FillFormat.FillType = (FillType.Solid);
		tbl.Rows[row][cell].CellFormat.BorderBottom.FillFormat.SolidFillColor.Color= Color.Red;
		tbl.Rows[row][cell].CellFormat.BorderBottom.Width =5;

		tbl.Rows[row][cell].CellFormat.BorderLeft.FillFormat.FillType = FillType.Solid;
		tbl.Rows[row][cell].CellFormat.BorderLeft.FillFormat.SolidFillColor.Color =Color.Red;
		tbl.Rows[row][cell].CellFormat.BorderLeft.Width = 5;

		tbl.Rows[row][cell].CellFormat.BorderRight.FillFormat.FillType = FillType.Solid;
		tbl.Rows[row][cell].CellFormat.BorderRight.FillFormat.SolidFillColor.Color = Color.Red;
		tbl.Rows[row][cell].CellFormat.BorderRight.Width = 5;
	}
}
// 1. satırın 1 ve 2. hücrelerini birleştirir
tbl.MergeCells(tbl.Rows[0][0], tbl.Rows[1][1], false);

// Birleştirilen hücreye metin ekler
tbl.Rows[0][0].TextFrame.Text = "Merged Cells";

// Sunumu diske kaydeder
pres.Save("table.pptx", SaveFormat.Pptx);
```

## **Standart Tablo'da Numaralandırma**

Standart bir tabloda hücrelerin numaralandırması basit ve sıfır‑tabanlıdır. Bir tablodaki ilk hücre 0,0 (sütun 0, satır 0) olarak indekslenir. 

Örneğin, 4 sütun ve 4 satırdan oluşan bir tabloda hücreler şu şekilde numaralandırılır:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Bu C# kodu, bir tablodaki hücreler için numaralandırmayı nasıl belirteceğinizi gösterir:

```c#
// PPTX dosyasını temsil eden bir Presentation sınıfı örnekler
using (Presentation pres = new Presentation())
{

    // İlk slayta erişir
    ISlide sld = pres.Slides[0];

    // Genişlikleriyle sütunları ve yükseklikleriyle satırları tanımlar
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // Slayta bir tablo şekli ekler
    ITable tbl = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

    // Her hücre için kenar biçimini ayarlar
    foreach (IRow row in tbl.Rows)
    {
        foreach (ICell cell in row)
        {
			cell.CellFormat.BorderTop.FillFormat.FillType = FillType.Solid;
			cell.CellFormat.BorderTop.FillFormat.SolidFillColor.Color = Color.Red;
			cell.CellFormat.BorderTop.Width = 5;

			cell.CellFormat.BorderBottom.FillFormat.FillType = FillType.Solid;
			cell.CellFormat.BorderBottom.FillFormat.SolidFillColor.Color = Color.Red;
			cell.CellFormat.BorderBottom.Width = 5;

			cell.CellFormat.BorderLeft.FillFormat.FillType = FillType.Solid;
			cell.CellFormat.BorderLeft.FillFormat.SolidFillColor.Color = Color.Red;
			cell.CellFormat.BorderLeft.Width = 5;

			cell.CellFormat.BorderRight.FillFormat.FillType = FillType.Solid;
			cell.CellFormat.BorderRight.FillFormat.SolidFillColor.Color = Color.Red;
			cell.CellFormat.BorderRight.Width = 5;
        }
    }

    // Sunumu diske kaydeder
    pres.Save("StandardTables_out.pptx", SaveFormat.Pptx);
}
```

## **Mevcut Bir Tabloya Erişme**

1. [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation) sınıfının bir örneğini oluşturun.  

2. Tabloyu içeren slayta indeks üzerinden referans alın.  

3. Bir [ITable](https://reference.aspose.com/slides/tr/net/aspose.slides/itable/) nesnesi oluşturun ve null olarak ayarlayın.  

4. Tablo bulunana kadar tüm [IShape](https://reference.aspose.com/slides/tr/net/aspose.slides/ishape/) nesneleri üzerinde yineleme yapın.  

   Eğer üzerinde çalıştığınız slayt tek bir tablo içeriyorsa, içinde bulunduğu tüm şekilleri basitçe kontrol edebilirsiniz. Bir şekil tablo olarak tanımlandığında, onu bir [Table](https://reference.aspose.com/slides/tr/net/aspose.slides/table/) nesnesine tip dönüştürebilirsiniz. Ancak slayt birden fazla tablo içeriyorsa, ihtiyacınız olan tabloyu [AlternativeText](https://reference.aspose.com/slides/tr/net/aspose.slides/ishape/alternativetext/) özelliğiyle aramanız daha iyidir.  

5. [ITable](https://reference.aspose.com/slides/tr/net/aspose.slides/itable/) nesnesini tablo ile çalışmak için kullanın. Aşağıdaki örnekte tabloya yeni bir satır ekledik.  

6. Değiştirilmiş sunumu kaydedin.  

Bu C# kodu, mevcut bir tabloya nasıl erişileceğini ve üzerinde nasıl çalışılacağını gösterir:

```c#
// PPTX dosyasını temsil eden bir Presentation sınıfı örnekler
using (Presentation pres = new Presentation("UpdateExistingTable.pptx"))
{
    // İlk slayta erişir
    ISlide sld = pres.Slides[0];

    // null TableEx'i başlatır
    ITable tbl = null;

    // Şekilleri dolaşır ve bulunan tabloya bir referans atar
    foreach (IShape shp in sld.Shapes)
        if (shp is ITable)
            tbl = (ITable)shp;

    // İkinci satırın birinci sütununa metin ayarlar
    tbl[0, 1].TextFrame.Text = "New";

    // Değiştirilmiş sunumu diske kaydeder
    pres.Save("table1_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Tabloda Metni Hizalama**

1. [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation) sınıfının bir örneğini oluşturun.  
2. Slaytın referansını indeks üzerinden alın.  
3. Slayta bir [ITable](https://reference.aspose.com/slides/tr/net/aspose.slides/itable/) nesnesi ekleyin.  
4. Tablodan bir [ITextFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/itextframe/) nesnesine erişin.  
5. [ITextFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/itextframe/) içinde bir [IParagraph](https://reference.aspose.com/slides/tr/net/aspose.slides/iparagraph/)’a erişin.  
6. Metni dikey olarak hizalayın.  
7. Değiştirilmiş sunumu kaydedin.  

Bu C# kodu, bir tabloda metni nasıl hizalayacağınızı gösterir:

```c#
// Creates an instance of the Presentation class
Presentation presentation = new Presentation();

// Gets the first slide 
ISlide slide = presentation.Slides[0];

// Defines columns with widths and rows with heights
double[] dblCols = { 120, 120, 120, 120 };
double[] dblRows = { 100, 100, 100, 100 };

// Adds the table shape to the slide
ITable tbl = slide.Shapes.AddTable(100, 50, dblCols, dblRows);
tbl[1, 0].TextFrame.Text = "10";
tbl[2, 0].TextFrame.Text = "20";
tbl[3, 0].TextFrame.Text = "30";

// Accesses the text frame
ITextFrame txtFrame = tbl[0, 0].TextFrame;

// Creates the Paragraph object for the text frame
IParagraph paragraph = txtFrame.Paragraphs[0];

// Creates the Portion object for paragraph
IPortion portion = paragraph.Portions[0];
portion.Text = "Text here";
portion.PortionFormat.FillFormat.FillType = FillType.Solid;
portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

// Aligns the text vertically
ICell cell = tbl[0, 0];
cell.TextAnchorType = TextAnchorType.Center;
cell.TextVerticalType = TextVerticalType.Vertical270;

// Saves the presentation to disk
presentation.Save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx);
```

## **Tablo Düzeyinde Metin Biçimlendirmesini Ayarlama**

1. [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
2. Slaytın referansını indeks üzerinden alın.  
3. Slayttan bir [ITable](https://reference.aspose.com/slides/tr/net/aspose.slides/itable/) nesnesine erişin.  
4. Metin için [FontHeight](https://reference.aspose.com/slides/tr/net/aspose.slides/baseportionformat/fontheight/) değerini ayarlayın.  
5. [Alignment](https://reference.aspose.com/slides/tr/net/aspose.slides/iparagraphformat/alignment/) ve [MarginRight](https://reference.aspose.com/slides/tr/net/aspose.slides/iparagraphformat/marginright/) özelliklerini ayarlayın.  
6. [TextVerticalType](https://reference.aspose.com/slides/tr/net/aspose.slides/textframeformat/textverticaltype/) değerini belirleyin.  
7. Değiştirilmiş sunumu kaydedin.  

Bu C# kodu, bir tablo içindeki metne tercih ettiğiniz biçimlendirme seçeneklerini nasıl uygulayacağınızı gösterir:

```c#
// Presentation sınıfının bir örneğini oluşturur
Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

ITable someTable = presentation.Slides[0].Shapes[0] as ITable; // İlk slayttaki ilk şeklin bir tablo olduğunu varsayalım

// Sets the table cells' font height
PortionFormat portionFormat = new PortionFormat();
portionFormat.FontHeight = 25;
someTable.SetTextFormat(portionFormat);

// Sets the table cells' text alignment and right margin in one call
ParagraphFormat paragraphFormat = new ParagraphFormat();
paragraphFormat.Alignment = TextAlignment.Right;
paragraphFormat.MarginRight = 20;
someTable.SetTextFormat(paragraphFormat);

// Sets the table cells' text vertical type
TextFrameFormat textFrameFormat = new TextFrameFormat();
textFrameFormat.TextVerticalType = TextVerticalType.Vertical;
someTable.SetTextFormat(textFrameFormat);


presentation.Save("result.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **Tablo Stil Özelliklerini Almak**

Aspose.Slides, bir tablonun stil özelliklerini almanıza olanak tanır; bu ayrıntıları başka bir tabloya ya da başka bir yere uygulayabilirsiniz. Bu C# kodu, bir tablo ön tanımlı stilinden stil özelliklerini nasıl alacağınızı gösterir: 

```c#
using (Presentation pres = new Presentation())
{
    ITable table = pres.Slides[0].Shapes.AddTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.StylePreset = TableStylePreset.DarkStyle1; // varsayılan stil ön ayar temasını değiştir
    pres.Save("table.pptx", SaveFormat.Pptx);
}
```

## **Tablonun En–Boy Oranını Kilitleme**

Geometrik bir şeklin en–boy oranı, farklı boyutlardaki ölçülerinin oranıdır. Aspose.Slides, tablolar ve diğer şekiller için en–boy oranı kilitleme ayarını sağlayan `AspectRatioLocked` özelliğini sunar. 

Bu C# kodu, bir tablo için en–boy oranını nasıl kilitleyeceğinizi gösterir:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    ITable table = (ITable)pres.Slides[0].Shapes[0];
    Console.WriteLine($"Lock aspect ratio set: {table.ShapeLock.AspectRatioLocked}");

    table.ShapeLock.AspectRatioLocked = !table.ShapeLock.AspectRatioLocked; // tersine çevir

    Console.WriteLine($"Lock aspect ratio set: {table.ShapeLock.AspectRatioLocked}");

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

## **SSS**

**Bir tablonun ve hücrelerindeki metnin tümü için sağdan sola (RTL) okuma yönünü etkinleştirebilir miyim?**

Evet. Tablo, bir [RightToLeft](https://reference.aspose.com/slides/tr/net/aspose.slides/table/righttoleft/) özelliği sunar ve paragraflar da [ParagraphFormat.RightToLeft](https://reference.aspose.com/slides/tr/net/aspose.slides/paragraphformat/righttoleft/) özelliğine sahiptir. İkisini birlikte kullanmak, hücre içindeki doğru RTL sırasını ve renderlamasını sağlar.

**Kullanıcıların son dosyada bir tabloyu taşımasını veya yeniden boyutlandırmasını nasıl engelleyebilirim?**

[shape locks](/slides/tr/net/applying-protection-to-presentation/) özelliğini kullanarak taşıma, yeniden boyutlandırma, seçim vb. işlemleri devre dışı bırakın. Bu kilitlemeler tablolara da uygulanır.

**Bir hücrenin içinde bir resmi arka plan olarak eklemek destekleniyor mu?**

Evet. Bir hücre için bir [picture fill](https://reference.aspose.com/slides/tr/net/aspose.slides/picturefillformat/) ayarlayabilirsiniz; görüntü, seçilen moda (esneme veya döşeme) göre hücre alanını kaplar.