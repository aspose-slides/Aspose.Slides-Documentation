---
title: Sunumlarda Tablo Hücrelerini Yönetme (.NET)
linktitle: Hücreleri Yönet
type: docs
weight: 30
url: /tr/net/manage-cells/
keywords:
- tablo hücresi
- hücre birleştirme
- kenar kaldırma
- hücre bölme
- hücrede resim
- arka plan rengi
- PowerPoint
- sunum
- .NET
- C#
- Aspose.Slides
description: "C# ile PowerPoint tablo hücrelerini yönetin: birleştirilmiş hücreleri tanımlayın, kenarları kaldırın, hücreleri bölün ve .NET için Aspose.Slides ile arka plan renklerini ve resimleri ayarlayın."
---
## **Genel Bakış**

Aspose.Slides, PowerPoint sunumlarındaki tablo hücrelerine erişmenizi ve bu hücreleri değiştirmenizi sağlar. Bu makale, birleştirilmiş tablo hücrelerini nasıl tanımlayacağınızı, hücre kenarlıklarını nasıl kaldıracağınızı, hücreleri birleştirdikten veya ayırdıktan sonra hücre numaralandırmasıyla nasıl çalışacağınızı, bir hücrenin arka plan rengini nasıl değiştireceğinizi ve bir tablo hücresine nasıl resim ekleyeceğinizi açıklar. Örnekler, bir sunumu nasıl oluşturup açacağınızı, bir slayttan tablo almayı, hücre özellikleri aracılığıyla hücre biçimlendirmesini güncellemeyi ve değiştirilen sunumu PPTX dosyası olarak kaydetmeyi gösterir.

Aspose.Slides, tablo hücrelerine `(sütun, satır)` sırasıyla sıfır tabanlı indeksler kullanarak erişir.

## **Birleştirilmiş Tablo Hücresini Tanımlama**

Bu örnek, mevcut bir sunumu açar ve ilk slayttaki ilk şekle tablo olarak erişir. Slayt ve şeklin mevcut olduğunu ve şeklin bir tablo olduğunu varsayar. Ardından tüm satır ve sütunlar arasında döner ve birleştirilmiş bölgelerdeki hücreleri tanımlamak için [IsMergedCell](https://reference.aspose.com/slides/net/aspose.slides/icell/ismergedcell/) yöntemini kullanır. Eşleşen her hücre için, hücre koordinatlarını `satır;sütun` sırasıyla, [RowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/rowspan/), [ColSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/colspan/), ve bölgenin başlangıç koordinatlarını [FirstRowIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstrowindex/) ve [FirstColumnIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstcolumnindex/) olarak yazdırır.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("presentation_with_table.pptx");
var slide = presentation.Slides[0];
var table = (ITable) slide.Shapes[0];

var rowCount = table.Rows.Count;
for (var rowIndex = 0; rowIndex < rowCount; rowIndex++)
{
    var columnCount = table.Columns.Count;
    for (var columnIndex = 0; columnIndex < columnCount; columnIndex++)
    {
        var cell = table[columnIndex, rowIndex];
        if (cell.IsMergedCell)
        {
            Console.WriteLine($"Cell {rowIndex};{columnIndex} belongs to a merged region with RowSpan={cell.RowSpan} and ColSpan={cell.ColSpan} starting at {cell.FirstRowIndex};{cell.FirstColumnIndex}.");
        }
    }
}
```

## **Tablo Hücre Kenarlıklarını Kaldırma**

Bir [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) oluşturun ve ilk slaydına [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/) kullanarak bir tablo ekleyin. Sütun genişlikleri, satır yükseklikleri ve tablo konumu puan cinsinden belirtilir. Örnek, dört hücre kenarlığının tümünü [FillType.NoFill](https://reference.aspose.com/slides/net/aspose.slides/filltype/) olarak ayarlayarak görünmez hâle getirir.

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 50, 50, 50, 50 };
double[] rowHeights = { 50, 30, 30, 30, 30 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);

foreach (var row in table.Rows)
    foreach (var cell in row)
    {
        cell.CellFormat.BorderTop.FillFormat.FillType = FillType.NoFill;
        cell.CellFormat.BorderBottom.FillFormat.FillType = FillType.NoFill;
        cell.CellFormat.BorderLeft.FillFormat.FillType = FillType.NoFill;
        cell.CellFormat.BorderRight.FillFormat.FillType = FillType.NoFill;
    }

presentation.Save("table.pptx", SaveFormat.Pptx);
```

## **Tablo Hücrelerini Birleştirme**

[MergeCells](https://reference.aspose.com/slides/net/aspose.slides/itable/mergecells/) kullanarak bir dikdörtgen tablo hücresi aralığını tek bir hücrede birleştirin. Aralığın sol‑üst ve sağ‑alt köşelerindeki hücreleri belirtin. Son argüman, birleştirmenin belirtilen aralığın dışındaki hücreleri içermesine izin verilip verilmeyeceğini kontrol eder; `false` birleştirmenin bu aralık içinde kalmasını sağlar.

Örnek, 70 puan genişliğinde sütun ve satıra sahip 4×4 bir tablo oluşturur ve ardından `(1, 1)` ile `(2, 2)` arasındaki dört merkezi hücreyi birleştirir. Ortaya çıkan hücre iki sütun ve iki satırı kapsar, ancak tablonun temel ızgarası dört sütun ve dört satır olarak kalır. Birleştirilmiş hücrenin içeriğine veya biçimlendirmesine erişmek için sol‑üst konumunu kullanın: bu örnekte `table[1, 1]`. Birleştirme aralığındaki diğer konumlar tablo ızgarasının bir parçası olarak kalır, bu yüzden aralık dışındaki hücrelerin indeksleri değişmez.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 70, 70, 70, 70 };
double[] rowHeights = { 70, 70, 70, 70 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);

table.MergeCells(table[1, 1], table[2, 2], false);

presentation.Save("merged_cells.pptx", SaveFormat.Pptx);
```

## **Tablo Hücrelerini Bölme**

Önceki örnekte hücrelerin birleştirilmesi tablo ızgarasını korur. Bir hücreyi bölmek, yeni bir ızgara sütunu ekleyebilir ve sağındaki hücrelerin sütun indekslerini değiştirebilir. Aspose.Slides, PowerPoint'in tablo ızgara modelini takip eder.

Bu örnek, 70 puan genişliğinde sütun ve satıra sahip 4×4 bir tablo oluşturur ve `(1, 1)` hücresinde [SplitByWidth](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbywidth/) metodunu çağırır. Hücrenin 70 puan genişliğinin yarısı iki eşit genişlikte hücre oluşturmak için kullanılır.

Bu bölünmeden sonra, iki yarı `table[1, 1]` ve `table[2, 1]` olarak erişilir. Tablo ızgarası artık beş sütuna sahiptir: başlangıçta 2 ve 3. sütunlarda bulunan hücreler sırasıyla 3 ve 4. sütunlara taşınır. Satır indeksleri değişmez. Bölünmeden sonraki hücre erişimlerinde bu güncellenmiş sütun indekslerini kullanın.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 70, 70, 70, 70 };
double[] rowHeights = { 70, 70, 70, 70 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);

table[1, 1].SplitByWidth(table[1, 1].Width / 2);

presentation.Save("split_cells.pptx", SaveFormat.Pptx);
```

### **Satır veya Sütun Kapsamıyla Birleştirilmiş Hücreleri Bölme**

Birleştirilmiş şablon hücrelerini veri doldurma için hazırlamak üzere, mevcut bir satır sınırı boyunca bölmek için [SplitByRowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbyrowspan/) ve bir sütun sınırı boyunca bölmek için [SplitByColSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbycolspan/) kullanın.

`index` parametresi, bölünmenin üst kısmındaki satırları veya sol kısmındaki sütunları sayar; birleştirilmiş bölgeye görecelidir:

- Satır bölmesi: `0 < index <` [RowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/rowspan/).
- Sütun bölmesi: `0 < index <` [ColSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/colspan/).

Örnek, sunumun ilk slaytındaki ilk şeklin bir tablo olduğunu ve `(1, 2)` ile `(1, 3)` hücrelerinin dikey olarak birleştirildiğini varsayar. Alt konumdan başlayarak, kökeni bulmak için [FirstColumnIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstcolumnindex/) ve [FirstRowIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstrowindex/) kullanır ve her iki kapsamı da kontrol eder. `SplitByRowSpan(1)` ardından ürün adları için 2. ve 3. satırları ayırır. Yatay iki sütun birleştirme için bunun yerine `SplitByColSpan(1)` kullanın.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("table_template.pptx");
var slide = presentation.Slides[0];
var table = (ITable) slide.Shapes[0];

var selectedCell = table[1, 3];
var firstColumnIndex = selectedCell.FirstColumnIndex;
var firstRowIndex = selectedCell.FirstRowIndex;
var mergedCell = table[firstColumnIndex, firstRowIndex];

if (mergedCell.IsMergedCell && mergedCell.RowSpan == 2 && mergedCell.ColSpan == 1)
{
    mergedCell.SplitByRowSpan(1);

    // Bölme işleminden sonra tablodan elde edilen hücreleri alın.
    var upperCell = table[firstColumnIndex, firstRowIndex];
    var lowerCell = table[firstColumnIndex, firstRowIndex + 1];
    Console.WriteLine($"Upper cell merged: {upperCell.IsMergedCell}");
    Console.WriteLine($"Lower cell merged: {lowerCell.IsMergedCell}");

    upperCell.TextFrame.Text = "Product A";
    lowerCell.TextFrame.Text = "Product B";

    presentation.Save("split_template.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("Select a merged region spanning exactly two rows and one column.");
}
```

Tablo ızgarası ve çevresindeki hücre indeksleri değişmez. Oluşan hücreleri koordinatlarıyla alın; burada ikisinin de kapsamı 1 ve [IsMergedCell](https://reference.aspose.com/slides/net/aspose.slides/icell/ismergedcell/) `False` yazdırır. Daha büyük bölgeler tek bir bölünmeden sonra bile kısmen birleştirilmiş kalabilir.

Orijinal metin ve biçimlendirmesi üst (veya sol) hücrede kalır; yeni hücre boş olur ancak doldurma, kenarlıklar ve kenar boşlukları gibi hücre biçimlendirmesini devralır. Hücreleri bölündükten sonra doldurun ve gerekli metin biçimlendirmesini açıkça ayarlayın.

Kaydedilen sunum, şablonun hücre biçimlendirmesini koruyan ayrı "Product A" ve "Product B" hücreleri içerir. Ayrıntılar için [Cell API Reference](https://reference.aspose.com/slides/net/aspose.slides/cell/) bölümüne bakın.

## **Tablo Hücre Arka Plan Rengini Değiştirme**

Bu örnek, 150 puan genişliğinde sütun ve 50 puan yüksekliğinde satırlara sahip bir tablo oluşturur. `(2, 3)` hücresi için (üçüncü sütun, dördüncü satır) [FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) değerini solid ve [SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/solidfillcolor/) değerini kırmızı olarak ayarlar.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 150, 150, 150, 150 };
double[] rowHeights = { 50, 50, 50, 50, 50 };
var table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);

var cell = table[2, 3];
cell.CellFormat.FillFormat.FillType = FillType.Solid;
cell.CellFormat.FillFormat.SolidFillColor.Color = Color.Red;

presentation.Save("cell_background_color.pptx", SaveFormat.Pptx);
```

## **Bir Tablo Hücresi İçine Resim Ekleme**

Bu örneği çalıştırmadan önce girdi resmini çalışma dizinine koyun. Resmi [Images.FromFile](https://reference.aspose.com/slides/net/aspose.slides/images/fromfile/) ile yükler ve sunumun resim koleksiyonuna [AddImage](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection/addimage/) ile ekler. Ardından resmi, tablonun ilk hücresi olan `(0, 0)` hücresinin resim doldurmasına atar.

[PictureFillMode.Stretch](https://reference.aspose.com/slides/net/aspose.slides/picturefillmode/) resmi hücreyi dolduracak şekilde uzatır, bu da en‑boy oranını değiştirebilir. Sütun genişlikleri ve satır yükseklikleri puan cinsindendir. Yüklenen resim, using bildirimi sayesinde otomatik olarak serbest bırakılır.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 150, 150, 150, 150 };
double[] rowHeights = { 100, 100, 100, 100, 90 };
var table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);

using var image = Images.FromFile("aspose_logo.jpg");
var ppImage = presentation.Images.AddImage(image);

table[0, 0].CellFormat.FillFormat.FillType = FillType.Picture;
table[0, 0].CellFormat.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
table[0, 0].CellFormat.FillFormat.PictureFillFormat.Picture.Image = ppImage;

presentation.Save("table_cell_with_image.pptx", SaveFormat.Pptx);
```

## **SSS**

**Tek bir hücrenin farklı kenarları için farklı çizgi kalınlıkları ve stilleri ayarlayabilir miyim?**

Evet. [top](https://reference.aspose.com/slides/net/aspose.slides/cellformat/bordertop/)/[bottom](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderbottom/)/[left](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderleft/)/[right](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderright/) kenarlıklarının ayrı özellikleri vardır, böylece her bir kenarın kalınlığı ve stili farklı olabilir.

**Bir resmi hücrenin arka planı olarak ayarladıktan sonra sütun/satır boyutunu değiştirirsem ne olur?**

Davranış, [fill mode](https://reference.aspose.com/slides/net/aspose.slides/picturefillmode/) (stretch/tile) değerine bağlıdır. Stretch seçildiğinde resim yeni hücreye uyacak şekilde ayarlanır; tile seçildiğinde ise döşemeler yeniden hesaplanır.

**Bir hücrenin tüm içeriğine bir hiperbağlantı atayabilir miyim?**

[Hyperlinks](/slides/tr/net/manage-hyperlinks/) hücrenin metin çerçevesindeki metin (parça) düzeyinde ya da tüm tablo/şekil düzeyinde ayarlanır. Pratikte, bağlantıyı bir parçaya veya hücredeki tüm metne atarsınız.

**Tek bir hücre içinde farklı yazı tipleri ayarlayabilir miyim?**

Evet. Bir hücrenin metin çerçevesi, bağımsız biçimlendirmeye sahip [portions](https://reference.aspose.com/slides/net/aspose.slides/portion/) (run'lar) — yazı tipi ailesi, stil, boyut ve renk — destekler.