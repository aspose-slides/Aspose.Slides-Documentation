---
title: Sunumlarda Tablo Hücrelerini .NET'te Yönetme
linktitle: Hücreleri Yönet
type: docs
weight: 30
url: /tr/net/manage-cells/
keywords:
- tablo hücresi
- hücre birleştirme
- kenarlık kaldırma
- hücre bölme
- hücrede görüntü
- arka plan rengi
- PowerPoint
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET ile PowerPoint'te tablo hücrelerini zahmetsizce yönetin. Hücrelere erişim, değiştirme ve stil verme konularında ustalaşarak sorunsuz slayt otomasyonu sağlayın."
---
## **Genel Bakış**

Aspose.Slides, PowerPoint sunumlarındaki tablo hücrelerine erişmenizi ve bunları değiştirmenizi sağlar. Bu makale, birleştirilmiş tablo hücrelerini nasıl belirleyeceğinizi, hücre kenarlıklarını nasıl kaldıracağınızı, hücreleri birleştirdikten veya böldükten sonra hücre numaralandırmasıyla nasıl çalışılacağını, bir hücrenin arka plan rengini nasıl değiştireceğinizi ve bir tablo hücresine nasıl resim ekleyeceğinizi açıklar. Örneklerde bir sunumun nasıl oluşturulup açılacağı, bir slayttan tablonun nasıl alınacağı, hücre özellikleri yoluyla hücre biçimlendirmesinin nasıl güncelleneceği ve değiştirilen sunumun PPTX dosyası olarak nasıl kaydedileceği gösterilir.

## **Birleştirilmiş Tablo Hücresini Belirleme**

1. `Presentation` sınıfının bir örneğini oluşturun.  
2. İlk slayttan tabloyu alın.  
3. Birleştirilmiş hücreleri bulmak için tablonun satır ve sütunları arasında yineleme yapın.  
4. Birleştirilmiş hücreler bulunduğunda mesaj yazdırın.

Bu C# kodu, bir sunumda birleştirilmiş tablo hücrelerini nasıl belirleyeceğinizi gösterir:

```c#
using (Presentation pres = new Presentation("SomePresentationWithTable.pptx"))
{
    ITable table = pres.Slides[0].Shapes[0] as ITable; // Slide#0.Shape#0 bir tablo olduğu varsayılıyor
    for (int i = 0; i < table.Rows.Count; i++)
    {
        for (int j = 0; j < table.Columns.Count; j++)
        {
            ICell currentCell = table.Rows[i][j];
            if (currentCell.IsMergedCell)
            {
                Console.WriteLine(string.Format("Cell {0};{1} is a part of merged cell with RowSpan={2} and ColSpan={3} starting from Cell {4};{5}.",
                                  i, j, currentCell.RowSpan, currentCell.ColSpan, currentCell.FirstRowIndex, currentCell.FirstColumnIndex));


            }
        }
    }
}
```

## **Tablo Hücresi Kenarlıklarını Kaldırma**

1. `Presentation` sınıfının bir örneğini oluşturun.  
2. İndeks aracılığıyla bir slaytın referansını alın.  
3. Genişliği olan bir sütun dizisi tanımlayın.  
4. Yüksekliği olan bir satır dizisi tanımlayın.  
5. `AddTable` yöntemiyle slayta bir tablo ekleyin.  
6. Her hücreyi dolaşarak üst, alt, sağ ve sol kenarlıkları temizleyin.  
7. Değiştirilen sunumu PPTX dosyası olarak kaydedin.

Bu C# kodu, tablo hücrelerinin kenarlıklarını nasıl kaldıracağınızı gösterir:

```c#
// PPTX dosyasını temsil eden Presentation sınıfını oluşturur
using (Presentation pres = new Presentation())
{
   // İlk slaytı erişir
    Slide sld = (Slide)pres.Slides[0];

    // Genişlikleri olan sütunları ve yükseklikleri olan satırları tanımlar
    double[] dblCols = { 50, 50, 50, 50 };
    double[] dblRows = { 50, 30, 30, 30, 30 };

    // Slayta tablo şekli ekler
    ITable tbl = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

    // Her hücre için kenarlık biçimini ayarlar
    foreach (IRow row in tbl.Rows)
        foreach (ICell cell in row)
        {
            cell.CellFormat.BorderTop.FillFormat.FillType = FillType.NoFill;
            cell.CellFormat.BorderBottom.FillFormat.FillType = FillType.NoFill;
            cell.CellFormat.BorderLeft.FillFormat.FillType = FillType.NoFill;
            cell.CellFormat.BorderRight.FillFormat.FillType = FillType.NoFill;
        }

    // PPTX dosyasını diske yazar
    pres.Save("table_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Birleştirilmiş Hücrelerde Numaralandırma**

2 çift hücreyi (1, 1) x (2, 1) ve (1, 2) x (2, 2) birleştirirsek, ortaya çıkan tablo numaralandırılır. Bu C# kodu süreci gösterir:

```c#
// PPTX dosyasını temsil eden Presentation sınıfını oluşturur
using (Presentation presentation = new Presentation())
{
    // İlk slaytı erişir
    ISlide sld = presentation.Slides[0];

    // Genişlikleri olan sütunları ve yükseklikleri olan satırları tanımlar
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

    // (1, 1) x (2, 1) hücrelerini birleştirir
    tbl.MergeCells(tbl[1, 1], tbl[2, 1], false);

    // (1, 2) x (2, 2) hücrelerini birleştirir
    tbl.MergeCells(tbl[1, 2], tbl[2, 2], false);

    presentation.Save("MergeCells_out.pptx", SaveFormat.Pptx);
}
```

Daha sonra (1, 1) ve (1, 2) hücrelerini birleştirerek tabloyu daha da birleştiririz. Sonuç, ortasında büyük bir birleştirilmiş hücre bulunan bir tablo olur:

```c#
// PPTX dosyasını temsil eden Presentation sınıfını oluşturur
using (Presentation presentation = new Presentation())
{
    // İlk slayta erişir
    ISlide slide = presentation.Slides[0];

    // Genişlikleri olan sütunları ve yükseklikleri olan satırları tanımlar
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // Slayta bir tablo şekli ekler
    ITable table = slide.Shapes.AddTable(100, 50, dblCols, dblRows);

    // Her hücre için kenarlık biçimini ayarlar
    foreach (IRow row in table.Rows)
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

    // (1, 1) x (2, 1) hücrelerini birleştirir
    table.MergeCells(table[1, 1], table[2, 1], false);

    // (1, 2) x (2, 2) hücrelerini birleştirir
    table.MergeCells(table[1, 2], table[2, 2], false);

    // (1, 2) x (2, 2) hücrelerini birleştirir
    table.MergeCells(table[1, 1], table[1, 2], true);

    // PPTX dosyasını diske yazar
    presentation.Save("MergeCells1_out.pptx", SaveFormat.Pptx);
}
```

## **Bölünmüş Hücrede Numaralandırma**

Önceki örneklerde, tablo hücreleri birleştirildiğinde diğer hücrelerdeki numaralandırma değişmez.  

Bu sefer, birleştirilmiş hücre içermeyen normal bir tablo alıp (1,1) hücresini bölerek özel bir tablo elde ediyoruz. Tablonun numaralandırmasına dikkat edin; bu, Microsoft PowerPoint’in tablo hücrelerini numaralandırma şeklidir ve Aspose.Slides de aynı davranışı izler.

Bu C# kodu, bahsettiğimiz süreci gösterir:

```c#
// PPTX dosyasını temsil eden Presentation sınıfını oluşturur
using (Presentation presentation = new Presentation())
{
    // İlk slayta erişir
    ISlide slide = presentation.Slides[0];

    // Genişlikleri olan sütunları ve yükseklikleri olan satırları tanımlar
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // Slayta bir tablo şekli ekler
    ITable table = slide.Shapes.AddTable(100, 50, dblCols, dblRows);

    // Her hücre için kenarlık biçimini ayarlar
    foreach (IRow row in table.Rows)
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

    // (1, 1) x (2, 1) hücrelerini birleştirir
    table.MergeCells(table[1, 1], table[2, 1], false);

    // (1, 2) x (2, 2) hücrelerini birleştirir
    table.MergeCells(table[1, 2], table[2, 2], false);

    // (1, 1) hücresini bölüyor
    table[1, 1].SplitByWidth(table[2, 1].Width / 2);

    // PPTX dosyasını diske yazar
    presentation.Save("CellSplit_out.pptx", SaveFormat.Pptx);
}
```

## **Tablo Hücresinin Arka Plan Rengini Değiştirme**

Bu C# kodu, bir tablo hücresinin arka plan rengini nasıl değiştireceğinizi gösterir:

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    double[] dblCols = { 150, 150, 150, 150 };
    double[] dblRows = { 50, 50, 50, 50, 50 };

    // yeni bir tablo oluştur
    ITable table = slide.Shapes.AddTable(50, 50, dblCols, dblRows);

    // bir hücrenin arka plan rengini ayarla
    ICell cell = table[2, 3];
    cell.CellFormat.FillFormat.FillType = FillType.Solid;
    cell.CellFormat.FillFormat.SolidFillColor.Color = Color.Red;

    presentation.Save("cell_background_color.pptx", SaveFormat.Pptx);
}
```

## **Tablo Hücresi İçine Görüntü Ekleme**

1. `Presentation` sınıfının bir örneğini oluşturun.  
2. İndeks aracılığıyla bir slaytın referansını alın.  
3. Genişliği olan bir sütun dizisi tanımlayın.  
4. Yüksekliği olan bir satır dizisi tanımlayın.  
5. `AddTable` yöntemiyle slayta bir tablo ekleyin.  
6. Görüntü dosyasını tutacak bir `Bitmap` nesnesi oluşturun.  
7. Bitmap görüntüsünü `IPPImage` nesnesine ekleyin.  
8. Tablo hücresi için `FillFormat` özelliğini `Picture` olarak ayarlayın.  
9. Görüntüyü tablonun ilk hücresine ekleyin.  
10. Değiştirilen sunumu PPTX dosyası olarak kaydedin.

Bu C# kodu, bir tablo oluştururken bir tablo hücresine nasıl resim yerleştirileceğini gösterir:

```c#
// PPTX dosyasını temsil eden Presentation sınıfını oluşturur
using (Presentation presentation = new Presentation())
{
    // İlk slayta erişir
    ISlide slide = presentation.Slides[0];

    // Genişlikleri olan sütunları ve yükseklikleri olan satırları tanımlar
    double[] dblCols = { 150, 150, 150, 150 };
    double[] dblRows = { 100, 100, 100, 100, 90 };

    // Slayta bir tablo şekli ekler
    ITable table = slide.Shapes.AddTable(50, 50, dblCols, dblRows);

    // Bir dosyadan görüntü yükler ve sunum kaynaklarına ekler
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    // Görüntüyü ilk tablo hücresine ekler
    table[0, 0].CellFormat.FillFormat.FillType = FillType.Picture;
    table[0, 0].CellFormat.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
    table[0, 0].CellFormat.FillFormat.PictureFillFormat.Picture.Image = ppImage;

    // PPTX dosyasını diske kaydeder
    presentation.Save("Image_In_TableCell_out.pptx", SaveFormat.Pptx);
}
```

## **SSS**

**Bir hücrenin tek bir kenarı için farklı çizgi kalınlıkları ve stilleri ayarlayabilir miyim?**

Evet. [üst](https://reference.aspose.com/slides/tr/net/aspose.slides/cellformat/bordertop/)/[alt](https://reference.aspose.com/slides/tr/net/aspose.slides/cellformat/borderbottom/)/[sol](https://reference.aspose.com/slides/tr/net/aspose.slides/cellformat/borderleft/)/[sağ](https://reference.aspose.com/slides/tr/net/aspose.slides/cellformat/borderright/) kenarlıklarının ayrı özellikleri vardır; böylece her bir kenarın kalınlığı ve stili farklı olabilir. Bu durum, makalede gösterilen hücre kenarlık kontrolüne dayanmaktadır.

**Bir resmi hücrenin arka planı olarak ayarladıktan sonra sütun/satır boyutunu değiştirirsem ne olur?**

Davranış, [dolgu modu](https://reference.aspose.com/slides/tr/net/aspose.slides/picturefillmode/) (stretch/tile) değerine bağlıdır. Stretch seçilirse, resim yeni hücreye göre ayarlanır; tile seçilirse, döşemeler yeniden hesaplanır. Makalede bir hücredeki görüntü gösterim modlarından bahsedilmiştir.

**Bir hücrenin tüm içeriğine bir köprü atayabilir miyim?**

[Köprüler](/slides/tr/net/manage-hyperlinks/) hücre içindeki metin çerçevesindeki (parça) düzeyinde veya tüm tablo/şekil düzeyinde ayarlanabilir. Pratikte, köprüyü bir parçaya ya da hücredeki tüm metne atarsınız.

**Bir hücre içinde farklı yazı tipleri kullanabilir miyim?**

Evet. Hücrenin metin çerçevesi, bağımsız biçimlendirmeye sahip [parçalar](https://reference.aspose.com/slides/tr/net/aspose.slides/portion/) (run) destekler; yazı tipi ailesi, stil, boyut ve renk ayrı ayrı ayarlanabilir.