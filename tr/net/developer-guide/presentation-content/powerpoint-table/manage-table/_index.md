---
title: .NET ile Sunum Tablolarını Yönet
linktitle: Tabloyu Yönet
type: docs
weight: 10
url: /tr/net/manage-table/
keywords:
- tablo ekle
- tablo oluştur
- tabloya eriş
- en-boy oranı
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

PowerPoint'te bir tablo, bilgiyi göstermek ve anlatmak için verimli bir yoldur. Hücrelerden oluşan bir ızgaradaki (satırlar ve sütunlar halinde düzenlenmiş) bilgi doğrudandır ve anlaşılması kolaydır.

Aspose.Slides, tablo oluşturmanızı, güncellemenizi ve tüm sunum türlerinde tabloları yönetmenizi sağlayan [Table](https://reference.aspose.com/slides/tr/net/aspose.slides/table/) sınıfını, [ITable](https://reference.aspose.com/slides/tr/net/aspose.slides/itable/) arayüzünü, [Cell](https://reference.aspose.com/slides/tr/net/aspose.slides/cell/) sınıfını, [ICell](https://reference.aspose.com/slides/tr/net/aspose.slides/icell/) arayüzünü ve diğer türleri sağlar. 

## **Sıfırdan Tablo Oluşturma**

1. [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation) sınıfının bir örneğini oluşturun.  
2. İndeks aracılığıyla bir slayt referansı alın.  
3. `columnWidth` adlı bir dizi tanımlayın.  
4. `rowHeight` adlı bir dizi tanımlayın.  
5. [AddTable](https://reference.aspose.com/slides/tr/net/aspose.slides/ishapecollection/addtable/) yöntemiyle slayta bir [ITable](https://reference.aspose.com/slides/tr/net/aspose.slides/itable/) nesnesi ekleyin.  
6. Her bir [ICell](https://reference.aspose.com/slides/tr/net/aspose.slides/icell/) üzerinde dolaşarak üst, alt, sağ ve sol kenarlara biçimlendirme uygulayın.  
7. Tablonun ilk satırındaki ilk iki hücreyi birleştirin.  
8. Bir [ICell](https://reference.aspose.com/slides/tr/net/aspose.slides/icell/)'in [TextFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/textframe/)’ine erişin.  
9. [TextFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/textframe/)’e bazı metinler ekleyin.  
10. Değiştirilmiş sunumu kaydedin.

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// PPTX dosyasını temsil eden bir Presentation sınıfı örneği oluşturur
Presentation pres = new Presentation();

// İlk slayta erişir
ISlide sld = pres.Slides[0];

// Sütunları genişlikleri ve satırları yükseklikleriyle tanımlar
double[] dblCols = { 50, 50, 50 };
double[] dblRows = { 50, 30, 30, 30, 30 };

// Slayta bir tablo şekli ekler
ITable tbl = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

// Her hücre için kenarlık biçimini ayarlar
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
// 1. satırın 1. ve 2. hücrelerini birleştirir
tbl.MergeCells(tbl.Rows[0][0], tbl.Rows[0][1], false);

// Birleştirilmiş hücreye metin ekler
tbl.Rows[0][0].TextFrame.Text = "Merged Cells";

// Sunumu diske kaydeder
pres.Save("table.pptx", SaveFormat.Pptx);
```

## **Standart Tablo Numaralandırması**

Standart bir tabloda, hücrelerin numaralandırması basittir ve sıfır tabanlıdır. Bir tablodaki ilk hücre 0,0 (sütun 0, satır 0) olarak indekslenir. 

Örneğin, 4 sütun ve 4 satırdan oluşan bir tablodaki hücreler şu şekilde numaralandırılır:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Bu C# kodu, yukarıda numaralandırılan standart 4 × 4 tabloyu oluşturur ve her bir hücre için kenarlık biçimini ayarlar:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// PPTX dosyasını temsil eden bir Presentation sınıfı örneği oluşturur
using (Presentation pres = new Presentation())
{

    // İlk slayta erişir
    ISlide sld = pres.Slides[0];

    // Sütunları genişlikleri ve satırları yükseklikleriyle tanımlar
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // Slayta bir tablo şekli ekler
    ITable tbl = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

    // Her hücre için kenarlık biçimini ayarlar
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

## **Mevcut Bir Tabloya Erişim**

1. [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation) sınıfının bir örneğini oluşturun.  
2. İndeks aracılığıyla tabloyu içeren slayta referans alın.  
3. Bir [ITable](https://reference.aspose.com/slides/tr/net/aspose.slides/itable/) nesnesi oluşturun ve null olarak ayarlayın.  
4. Tablo bulunana kadar tüm [IShape](https://reference.aspose.com/slides/tr/net/aspose.slides/ishape/) nesneleri üzerinden döngü oluşturun.  

   Eğer üzerinde çalıştığınız slaydın tek bir tablo içerdiğini düşünüyorsanız, yalnızca içinde bulunan tüm şekilleri kontrol edebilirsiniz. Bir şekil tablo olarak tanımlandığında, onu bir [Table](https://reference.aspose.com/slides/tr/net/aspose.slides/table/) nesnesine tip dönüşümü yapabilirsiniz. Ancak slayt birden fazla tablo içeriyorsa, ihtiyacınız olan tabloyu [AlternativeText](https://reference.aspose.com/slides/tr/net/aspose.slides/ishape/alternativetext/) aracılığıyla aramanız daha iyidir.  

5. [ITable](https://reference.aspose.com/slides/tr/net/aspose.slides/itable/) nesnesini tablo ile çalışmak için kullanın. Aşağıdaki örnekte tabloya yeni bir satır ekledik.  
6. Değiştirilmiş sunumu kaydedin.

```c#
using Aspose.Slides;

// PPTX dosyasını temsil eden bir Presentation sınıfı örneği oluşturur
using (Presentation pres = new Presentation("UpdateExistingTable.pptx"))
{

    // İlk slayta erişir
    ISlide sld = pres.Slides[0];

    // null TableEx başlatır
    ITable tbl = null;

    // Şekilleri dolaşır ve bulunan tabloya referans ayarlar
    foreach (IShape shp in sld.Shapes)
        if (shp is ITable)
            tbl = (ITable)shp;

    // İkinci satırın ilk sütunu için metni ayarlar
    tbl[0, 1].TextFrame.Text = "New";

    // Değiştirilmiş sunumu diske kaydeder
    pres.Save("table1_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Bir Metin Çerçevesine Sahip Hücreyi Bulma**

Genel metin işleme kodu bir tablodan bir [ITextFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/itextframe/) aldığında, sahip olduğu [ICell](https://reference.aspose.com/slides/tr/net/aspose.slides/icell/) elde etmek için [ITextFrame.ParentCell](https://reference.aspose.com/slides/tr/net/aspose.slides/itextframe/parentcell/) özelliğini kullanın. Bir tablo hücresi metin çerçevesi için, [ITextFrame.ParentCell](https://reference.aspose.com/slides/tr/net/aspose.slides/itextframe/parentcell/) ayarlanmıştır ve [ITextFrame.ParentShape](https://reference.aspose.com/slides/tr/net/aspose.slides/itextframe/parentshape/) `null` değerindedir, tablo kendisi bir şekil olsa bile.  

Hücre koordinatları, yalnızca okunabilir [ICell.FirstColumnIndex](https://reference.aspose.com/slides/tr/net/aspose.slides/icell/firstcolumnindex/) ve [ICell.FirstRowIndex](https://reference.aspose.com/slides/tr/net/aspose.slides/icell/firstrowindex/) özellikleri aracılığıyla elde edilebilir. [ITextFrame.ParentCell](https://reference.aspose.com/slides/tr/net/aspose.slides/itextframe/parentcell/) de yalnızca okunabilir: sahibi yönlendirme sağlar fakat sahipliği değiştirmez. Kullanımdan önce dönen hücreyi her zaman `null` için kontrol edin.  

Table hücresi ve şekil sahiplerini, SmartArt düğümleriyle ilişkili şekilleri de içeren eksiksiz bir örnek için [Search and Replace Text](/slides/tr/net/search-and-replace-text/) sayfasına bakın.

## **Tabloda Metni Hizalama**

1. [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation) sınıfının bir örneğini oluşturun.  
2. İndeks aracılığıyla bir slayt referansı alın.  
3. Slayta bir [ITable](https://reference.aspose.com/slides/tr/net/aspose.slides/itable/) nesnesi ekleyin.  
4. Tablodan bir [ITextFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/itextframe/) nesnesine erişin.  
5. [ITextFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/itextframe/) nesnesinin [IParagraph](https://reference.aspose.com/slides/tr/net/aspose.slides/iparagraph/) nesnesine erişin.  
6. Metni dikey olarak hizalayın.  
7. Değiştirilmiş sunumu kaydedin.

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Presentation sınıfının bir örneğini oluşturur
Presentation presentation = new Presentation();

// İlk slaytı alır
ISlide slide = presentation.Slides[0];

// Sütunları genişlikleri ve satırları yükseklikleriyle tanımlar
double[] dblCols = { 120, 120, 120, 120 };
double[] dblRows = { 100, 100, 100, 100 };

// Tablo şekli slayta eklenir
ITable tbl = slide.Shapes.AddTable(100, 50, dblCols, dblRows);
tbl[1, 0].TextFrame.Text = "10";
tbl[2, 0].TextFrame.Text = "20";
tbl[3, 0].TextFrame.Text = "30";

// Metin çerçevesine erişir
ITextFrame txtFrame = tbl[0, 0].TextFrame;

// Metin çerçevesi için Paragraph nesnesi oluşturur
IParagraph paragraph = txtFrame.Paragraphs[0];

// Paragraf için Portion nesnesi oluşturur
IPortion portion = paragraph.Portions[0];
portion.Text = "Text here";
portion.PortionFormat.FillFormat.FillType = FillType.Solid;
portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

// Metni dikey olarak hizalar
ICell cell = tbl[0, 0];
cell.TextAnchorType = TextAnchorType.Center;
cell.TextVerticalType = TextVerticalType.Vertical270;

// Sunumu diske kaydeder
presentation.Save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx);
```

## **Tablo Düzeyinde Metin Biçimlendirmesini Ayarlama**

1. [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
2. İndeks aracılığıyla bir slayt referansı alın.  
3. Slayttan bir [ITable](https://reference.aspose.com/slides/tr/net/aspose.slides/itable/) nesnesine erişin.  
4. Metin için [FontHeight](https://reference.aspose.com/slides/tr/net/aspose.slides/baseportionformat/fontheight/) ayarlayın.  
5. [Alignment](https://reference.aspose.com/slides/tr/net/aspose.slides/iparagraphformat/alignment/) ve [MarginRight](https://reference.aspose.com/slides/tr/net/aspose.slides/iparagraphformat/marginright/) ayarlayın.  
6. [TextVerticalType](https://reference.aspose.com/slides/tr/net/aspose.slides/textframeformat/textverticaltype/) ayarlayın.  
7. Değiştirilmiş sunumu kaydedin.  

Bu C# kodu, tablo içindeki metne tercih ettiğiniz biçimlendirme seçeneklerini nasıl uygulayacağınızı gösterir:

```c#
using Aspose.Slides;

// Presentation sınıfının bir örneğini oluşturur
Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

ITable someTable = presentation.Slides[0].Shapes[0] as ITable; // İlk slaydın ilk şeklinin bir tablo olduğunu varsayalım

// Tablo hücrelerinin yazı tipi yüksekliğini ayarlar
PortionFormat portionFormat = new PortionFormat();
portionFormat.FontHeight = 25;
someTable.SetTextFormat(portionFormat);

// Tablo hücrelerinin metin hizalamasını ve sağ kenar boşluğunu tek bir çağrıda ayarlar
ParagraphFormat paragraphFormat = new ParagraphFormat();
paragraphFormat.Alignment = TextAlignment.Right;
paragraphFormat.MarginRight = 20;
someTable.SetTextFormat(paragraphFormat);

// Tablo hücrelerinin metin dikey tipini ayarlar
TextFrameFormat textFrameFormat = new TextFrameFormat();
textFrameFormat.TextVerticalType = TextVerticalType.Vertical;
someTable.SetTextFormat(textFrameFormat);


presentation.Save("result.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **Tablo Stil Özelliklerini Alın**

Aspose.Slides, bir tablonun stil özelliklerini almanızı sağlar, böylece bu detayları başka bir tabloya ya da başka bir yere uygulayabilirsiniz. Bu C# kodu, tablo ön ayar stilinden stil özelliklerini nasıl alacağınızı gösterir: 

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    ITable table = pres.Slides[0].Shapes.AddTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.StylePreset = TableStylePreset.DarkStyle1; // varsayılan stil ön ayar temasını değiştirir

    // Tablonun stil ön ayarını al.
    TableStylePreset stylePreset = table.StylePreset;
    Console.WriteLine($"Table style preset: {stylePreset}");

    // Alınan stil ön ayarını başka bir tabloya uygula.
    ITable anotherTable = pres.Slides[0].Shapes.AddTable(10, 100, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    anotherTable.StylePreset = stylePreset;

    pres.Save("table.pptx", SaveFormat.Pptx);
}
```

## **Tablonun En Boy Oranını Kilitleme**

Geometrik bir şeklin en boy oranı, farklı boyutlardaki ölçülerinin oranıdır. Aspose.Slides, tablolar ve diğer şekiller için en boy oranı ayarını kilitlemenizi sağlayan `AspectRatioLocked` özelliğini sunar. 

Bu C# kodu, tablo için en boy oranını nasıl kilitleyeceğinizi gösterir:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("pres.pptx"))
{
    ITable table = (ITable)pres.Slides[0].Shapes[0];
    Console.WriteLine($"Lock aspect ratio set: {table.ShapeLock.AspectRatioLocked}");

    table.ShapeLock.AspectRatioLocked = !table.ShapeLock.AspectRatioLocked; // ters çevir

    Console.WriteLine($"Lock aspect ratio set: {table.ShapeLock.AspectRatioLocked}");

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

## **SSS**

**Tüm tablo ve hücrelerindeki metin için sağdan sola (RTL) okuma yönünü etkinleştirebilir miyim?**

Evet. Tablo, bir [RightToLeft](https://reference.aspose.com/slides/tr/net/aspose.slides/table/righttoleft/) özelliği sunar ve paragraflar da [ParagraphFormat.RightToLeft](https://reference.aspose.com/slides/tr/net/aspose.slides/paragraphformat/righttoleft/) özelliğine sahiptir. İkisini de kullanmak, hücre içindeki doğru RTL sırasını ve renderlamayı sağlar.

**Kullanıcıların son dosyada tabloyu hareket ettirmesini veya yeniden boyutlandırmasını nasıl önleyebilirim?**

Taşıma, yeniden boyutlandırma, seçim vb. işlemleri devre dışı bırakmak için [shape locks](/slides/tr/net/applying-protection-to-presentation/) kullanın. Bu kilitler tablolara da uygulanır.

**Bir hücrenin içinde arka plan olarak bir resim eklemek destekleniyor mu?**

Evet. Bir hücre için [picture fill](https://reference.aspose.com/slides/tr/net/aspose.slides/picturefillformat/) ayarlayabilirsiniz; resim, seçilen moda (germe veya döşeme) göre hücre alanını kaplar.