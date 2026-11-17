---
title: PowerPoint Sunumlarında Tablo Hücrelerini .NET'te Yönetme
linktitle: Hücreleri Yönet
type: docs
weight: 30
url: /tr/net/manage-cells/
keywords:
- tablo hücresi
- hücre birleştirme
- kenarlık kaldırma
- hücre bölme
- hücrede resim
- arka plan rengi
- PowerPoint
- sunum
- .NET
- C#
- Aspose.Slides
description: "C# ile PowerPoint tablo hücrelerini yönetin: birleştirilmiş hücreleri tanımlayın, kenarlıkları kaldırın, hücreleri bölün ve .NET için Aspose.Slides ile arka plan renklerini ve resimleri ayarlayın."
---
## **Genel Bakış**

Aspose.Slides, PowerPoint sunumlarında tablo hücrelerine erişmenizi ve bunları değiştirmenizi sağlar. Bu makale, birleştirilmiş tablo hücrelerini nasıl tanımlayacağınızı, hücre kenarlıklarını nasıl kaldıracağınızı, birleştirme veya bölme işleminden sonra hücre numaralandırmasıyla nasıl çalışacağınızı, bir hücrenin arka plan rengini nasıl değiştireceğinizi ve bir tablo hücresine resim eklemeyi açıklar. Örnekler, bir sunumu nasıl oluşturup açacağınızı, bir slayttan tablo almayı, hücre özellikleri aracılığıyla hücre biçimlendirmesini güncellemeyi ve değiştirilmiş sunumu PPTX dosyası olarak kaydetmeyi gösterir.

Aspose.Slides, tablo hücrelerine `(column, row)` sırasıyla sıfır tabanlı dizinler kullanarak erişir.

## **Birleştirilmiş Tablo Hücresini Tanımlama**

Örnek, mevcut bir sunumu açar ve ilk slayttaki ilk şekle tablo olarak erişir. Slayt ve şeklin mevcut olduğunu ve şeklin bir tablo olduğunu varsayar. Ardından tüm satır ve sütunları dolaşır ve birleştirilmiş bölgelerdeki hücreleri tanımlamak için [IsMergedCell](https://reference.aspose.com/slides/net/aspose.slides/icell/ismergedcell/) yöntemini kullanır. Her eşleşme için hücre koordinatlarını `row;column` sırasıyla, [RowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/rowspan/), [ColSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/colspan/) ve bölgenin başlangıç koordinatlarını, [FirstRowIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstrowindex/) ve [FirstColumnIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstcolumnindex/) yazar.

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

## **Tablo Hücresi Kenarlıklarını Kaldırma**

[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) oluşturun ve ilk slaytına [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/) kullanarak bir tablo ekleyin. Sütun genişlikleri, satır yükseklikleri ve tablo konumu puan cinsinden belirtilir. Örnek, dört hücre kenarlığını da [FillType.NoFill](https://reference.aspose.com/slides/net/aspose.slides/filltype/) olarak ayarlar ve böylece kenarlıklar görünmez hâle gelir.

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

## **Köşegen Hücre Kenarlıkları Ekleme**

[BorderDiagonalDown](https://reference.aspose.com/slides/net/aspose.slides/icellformat/borderdiagonaldown/) kullanarak sol üst köşeden sağ alt köşeye, [BorderDiagonalUp](https://reference.aspose.com/slides/net/aspose.slides/icellformat/borderdiagonalup/) ile sol alt köşeden sağ üst köşeye bir çizgi çizin. Köşegen bir köşe başlığı işaretleyebilir; iki köşegen bir X oluşturabilir ve hücreyi geçerli olmadığını gösterebilir.

Her köşegen bir [ILineFormat](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/) nesnesidir. Bunun [FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/fillformat/) içinde, [FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) değerini [FillType.Solid](https://reference.aspose.com/slides/net/aspose.slides/filltype/) olarak ayarlayın ve bir [SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/solidfillcolor/) seçin. Çizginin [Width](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/width/) değerini puan cinsinden belirleyin.

Örnek, bir satırda üç hücre oluşturur: kırmızı aşağı yönlü köşegen, mavi yukarı yönlü köşegen ve her iki köşegen. Üst, alt, sol ve sağ hücre kenarlıkları değişmeden bırakılır.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 210, 210, 210 };
double[] rowHeights = { 160 };
var table = slide.Shapes.AddTable(45, 130, columnWidths, rowHeights);

var downwardBorder = table[0, 0].CellFormat.BorderDiagonalDown;
downwardBorder.FillFormat.FillType = FillType.Solid;
downwardBorder.FillFormat.SolidFillColor.Color = Color.Red;
downwardBorder.Width = 3;

var upwardBorder = table[1, 0].CellFormat.BorderDiagonalUp;
upwardBorder.FillFormat.FillType = FillType.Solid;
upwardBorder.FillFormat.SolidFillColor.Color = Color.Blue;
upwardBorder.Width = 5;

var crossDownwardBorder = table[2, 0].CellFormat.BorderDiagonalDown;
crossDownwardBorder.FillFormat.FillType = FillType.Solid;
crossDownwardBorder.FillFormat.SolidFillColor.Color = Color.Red;
crossDownwardBorder.Width = 3;

var crossUpwardBorder = table[2, 0].CellFormat.BorderDiagonalUp;
crossUpwardBorder.FillFormat.FillType = FillType.Solid;
crossUpwardBorder.FillFormat.SolidFillColor.Color = Color.Blue;
crossUpwardBorder.Width = 5;

presentation.Save("diagonal_cell_borders.pptx", SaveFormat.Pptx);
```

Köşegen bir biçimlendirme özelliğidir, hücrenin bölünmesi değildir. Her hücre tek bir [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/icell/textframe/) tutar; köşegenin iki tarafındaki bölgeler bağımsız olarak düzenlenemez.

Kaydedilen tablo, Microsoft PowerPoint’te görüntülenir:

![Üst‑soldan alt‑sağa kırmızı köşegen, alt‑soldan üst‑sağa mavi köşegen ve iki köşegenin X oluşturduğu üç tablo hücresi.](diagonal-cell-borders.png)

*Soldan sağa: aşağı yönlü köşegen (kırmızı, 3 pt), yukarı yönlü köşegen (mavi, 5 pt) ve her iki köşegen.*

## **Tablo Hücrelerini Birleştirme**

[MergeCells](https://reference.aspose.com/slides/net/aspose.slides/itable/mergecells/) kullanarak bir tablo hücresi dikdörtgen aralığını tek bir hücreye birleştirin. Aralığın sol üst ve sağ alt köşelerindeki hücreleri belirtin. Son parametre, birleştirmenin belirtilen aralığın dışındaki hücreleri içerip içermeyeceğini kontrol eder; `false` değeri birleştirmenin yalnızca bu aralık içinde kalmasını sağlar.

Örnek, 70 puan genişliğinde sütunlar ve satırlar içeren 4x4 bir tablo oluşturur ve ardından `(1, 1)` ile `(2, 2)` arasındaki dört merkezi hücreyi birleştirir. Oluşan hücre iki sütun ve iki satır kapsar, ancak tablonun temel ızgarası dört sütun ve dört satır olarak kalır. Birleştirilen hücrenin içeriğine veya biçimlendirmesine erişmek için sol‑üst konumunu kullanın: bu örnekte `table[1, 1]`. Birleşim aralığındaki diğer konumlar tablo ızgarasının bir parçası olmaya devam eder, bu yüzden aralığın dışındaki hücrelerin indeksleri değişmez.

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

Önceki örnekte hücreleri birleştirmek tablo ızgarasını korur. Bir hücreyi bölmek yeni bir ızgara sütunu ekleyebilir ve sağındaki hücrelerin sütun indekslerini değiştirebilir. Aspose.Slides, PowerPoint'in tablo ızgara modelini izler.

Bu örnek, 70 puan sütun ve satırlara sahip 4x4 bir tablo oluşturur ve `(1, 1)` hücresi üzerinde [SplitByWidth](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbywidth/) yöntemini çağırır. Hücrenin 70 puanlık genişliğinin yarısı iki eşit genişlikte hücre oluşturmak için kullanılır.

Bu bölünmeden sonra iki yarı `table[1, 1]` ve `table[2, 1]` olarak erişilir. Tablo ızgarası şimdi beş sütuna sahiptir: önceki 2 ve 3. sütunlardaki hücreler sırasıyla 3 ve 4. sütunlara taşınır. Satır indeksleri değişmez. Bölünmeden sonra hücrelere erişirken bu güncellenmiş sütun indekslerini kullanın.

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

### **Birleştirilmiş Hücreleri Satır veya Sütun Genişliğine Göre Bölme**

Veri doldurmak için birleştirilmiş şablon hücrelerini hazırlamak amacıyla, mevcut bir satır sınırına göre bölmek için [SplitByRowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbyrowspan/) ve bir sütun sınırına göre bölmek için [SplitByColSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbycolspan/) kullanın.

`index` argümanı, bölünmenin üst kısmındaki satırları ya da sol kısmındaki sütunları sayar; birleştirilmiş bölgeye görecelidir:

- Satır bölünmesi: `0 < index <` [RowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/rowspan/).
- Sütun bölünmesi: `0 < index <` [ColSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/colspan/).

Örnek, bir sunumun ilk slaytındaki ilk şeklin bir tablo olmasını ve `(1, 2)` ile `(1, 3)` hücrelerinin dikey olarak birleştirilmiş olmasını varsayar. Alt konumdan başlayarak, başlangıcı bulmak için [FirstColumnIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstcolumnindex/) ve [FirstRowIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstrowindex/) kullanır ve her iki kapsamı da kontrol eder. `SplitByRowSpan(1)` ardından ürün adları için 2. ve 3. satırları ayırır. Yatay iki sütun birleştirme için `SplitByColSpan(1)` kullanın.

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

    // Bölme işleminden sonra tablodan oluşan hücreleri al.
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

Tablo ızgarası ve çevre hücre indeksleri değişmez. Ortaya çıkan hücreleri koordinatlarıyla alın; burada her ikisi de 1 kapsamına sahiptir ve [IsMergedCell](https://reference.aspose.com/slides/net/aspose.slides/icell/ismergedcell/) `False` yazar. Daha büyük bölgeler bir bölünmeden sonra kısmen birleştirilmiş kalabilir.

Orijinal metin ve biçimlendirmesi üst (veya sol) hücrede kalır; yeni hücre boş olur ancak dolgu, kenarlık ve kenar boşlukları gibi hücre biçimlendirmesini devralır. Hücreleri bölündükten sonra doldurun ve gerekli metin biçimlendirmesini açıkça ayarlayın.

Kaydedilen sunum, şablonun hücre biçimlendirmesini koruyan ayrı "Product A" ve "Product B" hücrelerini içerir. Ayrıntılar için [Cell API Reference](https://reference.aspose.com/slides/net/aspose.slides/cell/) sayfasına bakın.

<!-- visual-explanation:manage-cells:start -->
[![1. sütundaki, 2 ve 3. satırlardaki birleştirilmiş hücre, aynı ızgara indeksleriyle Product A ve Product B olarak bölünür.](visual-manage-cells-62c80896698e.svg)](visual-manage-cells-62c80896698e.svg)

*Satır‑kapsamı bölmesi mevcut sınırı kullanır. Product A ve Product B sırasıyla (1, 2) ve (1, 3) konumlarını işler.*
<!-- visual-explanation:manage-cells:end -->

### **Belirli Bir Yüksekliğe Göre Hücre Bölme**

[SplitByHeight](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbyheight/) üst kısmın yüksekliğini puan cinsinden alır. [SplitByRowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbyrowspan/) üst kısımda bulunan mevcut ızgara satır sayısını alır. Sağ sütunda 40 puanlık bir hücreyi ortalamak için, hücrenin gerçek yüksekliğinden 40 çıkartın ve kalan alanı üstte ve altta eşit olarak bölün.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 160, 160 };
double[] rowHeights = { 140 };

var table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);
table[0, 0].TextFrame.Text = "Left";

var height = table[1, 0].Height;
var margin = (height - 40) / 2;

table[1, 0].SplitByHeight(margin);
table[1, 1].SplitByHeight(40);
table[1, 1].TextFrame.Text = "Middle";

presentation.Save("split_by_height.pptx", SaveFormat.Pptx);
```

İlk bölme bir ızgara satırı ekler ve alt 90 puanı `[1, 1]` konumunda bırakır. İkinci bölme bu hücreyi hedef alır ve altına bir satır daha ekler. Sağ sütun artık `[1, 0]` 50 puan (`margin`), `[1, 1]` 40 puan ve `[1, 2]` 50 puan (`margin`) içerir. Sol hücre, orijinal 140 puan yüksekliğinde üç satırı da kapsar.

![Sol hücre, ortada Middle bulunan üç hücrenin yanında tablo yüksekliğinin tamamını kaplar.](split-by-height.png)

## **Tablo Hücresi Arka Plan Rengini Değiştirme**

Bu örnek, 150 puan genişliğinde sütunlar ve 50 puan yüksekliğinde satırlarla bir tablo oluşturur. `(2, 3)` hücresi için (üçüncü sütun, dördüncü satır) [FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) değerini solid ve [SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/solidfillcolor/) değerini kırmızı olarak ayarlar.

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

## **Tablo Hücresi İçine Resim Ekleme**

Bu örneği çalıştırmadan önce giriş resmini çalışma dizinine koyun. Resmi [Images.FromFile](https://reference.aspose.com/slides/net/aspose.slides/images/fromfile/) ile yükler ve [AddImage](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection/addimage/) ile sunumun görüntü koleksiyonuna ekler. Ardından resmi, tablodaki ilk hücre olan `(0, 0)` hücresinin resim dolgusuna atar.

[PictureFillMode.Stretch](https://reference.aspose.com/slides/net/aspose.slides/picturefillmode/) resmi hücreyi dolduracak şekilde gerer, bu da en‑boy oranının değişmesine neden olabilir. Sütun genişlikleri ve satır yükseklikleri puan cinsindendir. Yüklenen resim, using ifadesiyle otomatik olarak serbest bırakılır.

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

Evet. [top](https://reference.aspose.com/slides/net/aspose.slides/cellformat/bordertop/)/[bottom](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderbottom/)/[left](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderleft/)/[right](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderright/) kenarlıklarının ayrı özellikleri vardır, bu yüzden her bir kenarın kalınlığı ve stili farklı olabilir.

**Bir resmi hücrenin arka planı olarak ayarladıktan sonra sütun/satır boyutunu değiştirirsem ne olur?**

Davranış, [fill mode](https://reference.aspose.com/slides/net/aspose.slides/picturefillmode/) (stretch/tile) değerine bağlıdır. Germe (stretch) seçildiğinde, resim yeni hücreye uyacak şekilde ayarlanır; döşeme (tile) seçildiğinde, döşemeler yeniden hesaplanır.

**Bir hücrenin tüm içeriğine bir hiperlink atayabilir miyim?**

[Hyperlinks](/slides/tr/net/manage-hyperlinks/) hücrenin metin çerçevesi içindeki metin (parça) düzeyinde veya tüm tablo/şekil seviyesinde ayarlanır. Pratikte, bağlantıyı bir parçaya ya da hücredeki tüm metne atarsınız.

**Tek bir hücre içinde farklı yazı tipleri ayarlayabilir miyim?**

Evet. Bir hücrenin metin çerçevesi, bağımsız biçimlendirmeye sahip [portions](https://reference.aspose.com/slides/net/aspose.slides/portion/) (çalıştırmalar) – yazı tipi ailesi, stil, boyut ve renk – destekler.